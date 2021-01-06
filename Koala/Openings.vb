Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class Openings
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("Openings", "Openings",
                "Openings description",
                "Koala", "Structure")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddCurveParameter("ClosedCurves", "ClosedCurves", "List of curves defining opening", GH_ParamAccess.list)
            pManager.AddTextParameter("Surface", "Surface", "Name of surface where is opening", GH_ParamAccess.list)
            pManager.AddTextParameter("NodePrefix", "NodePrefix", "Prefix of nodes defining opening", GH_ParamAccess.item, "NO")
            pManager.AddNumberParameter("Tolerance", "Tolerance", "tolerance for geometry check", GH_ParamAccess.item, 0.001)
            pManager.AddTextParameter("OpeningNamePrefix", "OpeningNamePrefix", "Prefix name of the opening", GH_ParamAccess.item, "O")
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("Nodes", "Nodes", "Output nodes", GH_ParamAccess.list)
            pManager.AddTextParameter("Openings", "Openings", "Output openings", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim ClosedCurves = New List(Of Curve)
            Dim Surface As String = ""
            Dim Surfaces = New List(Of String)
            Dim NodePrefix As String = "NO"
            Dim Tolerance As Double = 0.001
            Dim OpeningNamePrefix As String = "O"
            Dim maxSurfaceCount As Long = 0
            If (Not DA.GetDataList(Of Curve)(0, ClosedCurves)) Then Return
            If (Not DA.GetDataList(Of String)(1, Surfaces)) Then Return
            If (Not DA.GetData(Of String)(2, NodePrefix)) Then Return
            If (Not DA.GetData(Of Double)(3, Tolerance)) Then Return
            If (Not DA.GetData(Of String)(4, OpeningNamePrefix)) Then Return


            If ClosedCurves.Count < Surfaces.Count Then
                Rhino.RhinoApp.WriteLine("Openings: More Surfaces are defined than openings.They will be ignored.")
            ElseIf ClosedCurves.Count < Surfaces.Count Then
                Rhino.RhinoApp.WriteLine("Openings: Less Materials are defined than beams. The last defined section will be used for the extra beams")
            End If
            maxSurfaceCount = Surfaces.Count - 1


            Dim i As Long, j As Long

            Dim edgecount As Long, iedge As Long
            Dim edgenodelist As String, nodesinedge As Long

            Dim currentnode As Long, inode As Long

            Dim SE_nodes(100000, 3) As String 'a node consists of: Name, X, Y, Z > make the array a dynamic list later
            Dim FlatNodeList As New List(Of System.Object)()
            Dim SE_openings(ClosedCurves.Count, 2) As String 'a surface consists of: Name, ReferenceSurface, BoundaryShape. For a circle, BoundaryShape is coded by "Circle;Ni;Nj;Nk"
            Dim FlatOpeningList As New List(Of System.Object)()

            Dim nodecount As Long, openingcount As Long

            'Declarations to work with RhinoCommon objects
            Dim curve As Rhino.Geometry.Curve
            Dim circle As Rhino.Geometry.Circle
            Dim edgelist() As Rhino.Geometry.Curve
            Dim edge As Rhino.Geometry.Curve

            Dim arrPoint As Rhino.Geometry.Point3d
            Dim arrPoints As New Rhino.Collections.Point3dList

            Dim LastEdgeNode As String

            Dim EdgeType As String
            Dim BoundaryShape As String

            Dim stopWatch As New System.Diagnostics.Stopwatch()
            Dim time_elapsed As Double

            'initialize stopwatch
            stopWatch.Start()

            'initialize some variables
            nodecount = 0
            openingcount = 0

            'loop through all openings
            '===========================
            Dim k As Long = 0
            For Each curve In ClosedCurves

                'check if the curve is a closed, planar curve
                If Not curve.IsClosed Or Not curve.IsPlanar(Tolerance) Then
                    Rhino.RhinoApp.WriteLine("KOALA: Encountered curve """ & curve.ToString & """, planarity: " & curve.IsPlanar(Tolerance) & ", closed: " & curve.IsClosed & ". Skipped.")
                    Continue For 'iterate to next curve
                End If


                'check if it's a circle
                If curve.IsCircle Then
                    openingcount = openingcount + 1
                    curve.TryGetCircle(circle)
                    EdgeType = "Circle"
                    arrPoints.Clear()
                    arrPoints.Add(circle.PointAt(0))
                    arrPoints.Add(circle.PointAt(Math.PI / 2))
                    arrPoints.Add(circle.PointAt(Math.PI))

                    edgenodelist = ""
                    BoundaryShape = ""

                    SE_openings(openingcount - 1, 0) = OpeningNamePrefix & openingcount

                    If k <= maxSurfaceCount Then
                        Surface = Surfaces(k)
                    Else
                        Surface = Surfaces(maxSurfaceCount)
                    End If
                    k += 1
                    SE_openings(openingcount - 1, 1) = Surface


                    For Each arrPoint In arrPoints
                        inode = inode + 1

                        If inode = nodesinedge Then
                            'last point > skip because SCIA Engineer will automatically go the the first point of the next edge, or close the curve
                            Exit For
                        End If

                        'create the node, then add it to the edge information
                        nodecount = nodecount + 1
                        SE_nodes(nodecount - 1, 0) = NodePrefix & nodecount
                        SE_nodes(nodecount - 1, 1) = arrPoint(0)
                        SE_nodes(nodecount - 1, 2) = arrPoint(1)
                        SE_nodes(nodecount - 1, 3) = arrPoint(2)
                        currentnode = nodecount

                        If edgenodelist = "" Then
                            edgenodelist = SE_nodes(currentnode - 1, 0)
                        Else
                            edgenodelist = edgenodelist & ";" & SE_nodes(currentnode - 1, 0)
                        End If
                    Next arrPoint

                    'add edge information to the BoundaryShape string
                    If BoundaryShape = "" Then
                        BoundaryShape = EdgeType + ";" + edgenodelist
                    Else
                        BoundaryShape = BoundaryShape + " | " + EdgeType + ";" + edgenodelist
                    End If

                Else
                    'get all curve segments
                    edgelist = curve.DuplicateSegments
                    edgecount = edgelist.Count

                    openingcount = openingcount + 1

                    SE_openings(openingcount - 1, 0) = OpeningNamePrefix & openingcount
                    If k <= maxSurfaceCount Then
                        Surface = Surfaces(k)
                    Else
                        Surface = Surfaces(maxSurfaceCount)
                    End If
                    k += 1
                    SE_openings(openingcount - 1, 1) = Surface

                    iedge = 0
                    BoundaryShape = ""
                    LastEdgeNode = ""

                    For Each edge In edgelist

                        If edge.GetLength() < Tolerance Then
                            Exit For 'iterate to next edge
                        End If

                        iedge = iedge + 1

                        'Get type of curve and nodelist
                        EdgeType = ""
                        GetTypeAndNodes(edge, EdgeType, arrPoints)

                        nodesinedge = arrPoints.Count
                        edgenodelist = ""
                        inode = 0

                        For Each arrPoint In arrPoints
                            inode = inode + 1

                            If inode = nodesinedge Then
                                'last point > skip because SCIA Engineer will automatically go the the first point of the next edge, or close the curve
                                Exit For
                            End If

                            'create the node, then add it to the edge information
                            nodecount = nodecount + 1
                            SE_nodes(nodecount - 1, 0) = NodePrefix & nodecount
                            SE_nodes(nodecount - 1, 1) = arrPoint(0)
                            SE_nodes(nodecount - 1, 2) = arrPoint(1)
                            SE_nodes(nodecount - 1, 3) = arrPoint(2)
                            currentnode = nodecount

                            If edgenodelist = "" Then
                                edgenodelist = SE_nodes(currentnode - 1, 0)
                            Else
                                edgenodelist = edgenodelist & ";" & SE_nodes(currentnode - 1, 0)
                            End If
                        Next arrPoint

                        'add edge information to the BoundaryShape string
                        If BoundaryShape = "" Then
                            BoundaryShape = EdgeType + ";" + edgenodelist
                        Else
                            BoundaryShape = BoundaryShape + " | " + EdgeType + ";" + edgenodelist
                        End If

                    Next edge
                End If

                'store the edge description in the array
                SE_openings(openingcount - 1, 2) = BoundaryShape

            Next curve

            FlatNodeList.Clear()

            For i = 0 To nodecount - 1
                For j = 0 To 3
                    FlatNodeList.Add(SE_nodes(i, j))
                Next j
            Next i
            DA.SetDataList(0, FlatNodeList)


            FlatOpeningList.Clear()

            For i = 0 To openingcount - 1
                For j = 0 To 2
                    FlatOpeningList.Add(SE_openings(i, j))
                Next j
            Next i
            DA.SetDataList(1, FlatOpeningList)


            'stop stopwatch
            stopWatch.Stop()
            time_elapsed = stopWatch.ElapsedMilliseconds
            'rhino.RhinoApp.WriteLine("Koala: Done in " + str(time_elapsed) + " ms.")

        End Sub

        '<Custom additional code> 
        Private Sub GetTypeAndNodes(ByRef edge As Rhino.Geometry.Curve, ByRef EdgeType As String, ByRef arrPoints As Rhino.Collections.Point3dList)

            Dim arc As Rhino.Geometry.Arc
            Dim nurbscurve As Rhino.Geometry.NurbsCurve

            If edge.IsArc() Then
                EdgeType = "Arc"
                'convert to arc
                edge.TryGetArc(arc)
                arrPoints.Clear()
                arrPoints.Add(arc.StartPoint)
                arrPoints.Add(arc.MidPoint)
                arrPoints.Add(arc.EndPoint)
            ElseIf edge.IsLinear() Then
                EdgeType = "Line"
                arrPoints.Clear()
                arrPoints.Add(edge.PointAtStart)
                arrPoints.Add(edge.PointAtEnd)
            Else
                EdgeType = "Spline"
                'convert to Nurbs curve to get the Edit points
                nurbscurve = edge.ToNurbsCurve
                arrPoints = nurbscurve.GrevillePoints
            End If

        End Sub


        ''' <summary>
        ''' Provides an Icon for every component that will be visible in the User Interface.
        ''' Icons need to be 24x24 pixels.
        ''' </summary>
        Protected Overrides ReadOnly Property Icon() As System.Drawing.Bitmap
            Get
                'You can add image files to your project resources and access them like this:
                ' return Resources.IconForThisComponent;
                Return My.Resources.Opening
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("06601144-0421-4aa7-ba9b-af0ab4ba82b8")
            End Get
        End Property
    End Class

End Namespace