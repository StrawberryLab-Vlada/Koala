Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala 

    Public Class FreeSurfaceLoad
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("FreeSurfaceLoad", "FreeSurfaceLoad",
                "FreeSurfaceLoad description",
                "Koala", "Load")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("LoadCase", "LoadCase", "Name of load case", GH_ParamAccess.item, "LC2")
            pManager.AddTextParameter("Validity", "Validity", "Validity: All,Z equals 0", GH_ParamAccess.item, "All")
            pManager.AddTextParameter("Selection", "Selection", "Selection: Auto", GH_ParamAccess.item, "Auto")
            pManager.AddTextParameter("CoordSys", "CoordSys", "Coordinate system: GCS - Length, GCS - Projection, Member LCS", GH_ParamAccess.item, "GCS - Length")
            pManager.AddTextParameter("Direction", "Direction", "Direction of load: X,Y,Z", GH_ParamAccess.item, "Z")
            pManager.AddNumberParameter("LoadValue", "LoadValue", "Value of Load in KN/m", GH_ParamAccess.item, -1)
            pManager.AddCurveParameter("Boundaries", "Boundaries", "List of lines", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("FreeSurfaceloads", "FreeSurfaceloads", "", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            'note: only straight segments are supported in SCIA Engineer's XML today (SE 18.1.3035) > limitation of Koala as well

            Dim LoadCase As String = "LC1"
            Dim Validity As String = "All"
            Dim Selection As String = "Auto"
            Dim CoordSys As String = "GCS - Length"
            Dim Direction As String = "Z"
            Dim LoadValue As Double = -1.0
            Dim Boundaries = New List(Of Curve)

            If (Not DA.GetData(0, LoadCase)) Then Return
            If (Not DA.GetData(1, Validity)) Then Return
            If (Not DA.GetData(2, Selection)) Then Return
            If (Not DA.GetData(3, CoordSys)) Then Return
            If (Not DA.GetData(4, Direction)) Then Return
            If (Not DA.GetData(5, LoadValue)) Then Return
            If (Not DA.GetDataList(Of Curve)(6, Boundaries)) Then Return
            Dim i As Long, j As Long

            Dim SE_fsloads(Boundaries.Count, 6)
            Dim FlatList As New List(Of System.Object)()
            'a free surface load consists of: load case, validity, selection, coord. system (GCS/LCS), direction (X, Y, Z), value (kN/m^2), BoundaryShape

            Dim itemcount As Long
            Dim item As Rhino.Geometry.Curve
            Dim segments() As Rhino.Geometry.Curve
            Dim segment As Rhino.Geometry.Curve

            Dim BoundaryShape As String, LineShape As String

            'initialize some variables
            itemcount = 0

            'create load data
            '=================

            For Each item In Boundaries

                segments = item.DuplicateSegments

                BoundaryShape = ""

                For Each segment In segments

                    'Get full geometry description
                    LineShape = GetClosedBoundaryShape(segment)

                    If LineShape.Split(";")(0) <> "Line" Then
                        Rhino.RhinoApp.WriteLine("KOALA: only straight line segments are supported for free line loads. Different geometries will be skipped.")
                        Continue For
                    End If

                    If BoundaryShape = "" Then
                        BoundaryShape = LineShape
                    Else
                        BoundaryShape = BoundaryShape & " | " & LineShape
                    End If

                Next segment

                SE_fsloads(itemcount, 0) = LoadCase
                SE_fsloads(itemcount, 1) = Validity
                SE_fsloads(itemcount, 2) = Selection
                SE_fsloads(itemcount, 3) = CoordSys
                SE_fsloads(itemcount, 4) = Direction
                SE_fsloads(itemcount, 5) = LoadValue
                SE_fsloads(itemcount, 6) = BoundaryShape
                itemcount += 1
            Next

            'Flatten data for export as simple list

            FlatList.Clear()

            For i = 0 To itemcount - 1
                For j = 0 To 6
                    FlatList.Add(SE_fsloads(i, j))
                Next j
            Next i



            DA.SetDataList(0, FlatList)


        End Sub

        '<Custom additional code> 
        Private Function GetClosedBoundaryShape(ByRef curve As Rhino.Geometry.Curve) As String

            Dim arrPoint As Rhino.Geometry.Point3d
            Dim arrPoints As New Rhino.Collections.Point3dList

            Dim EdgeType As String
            Dim edgenodelist As String

            Dim i As Long

            EdgeType = ""
            edgenodelist = ""

            'Get type of curve and nodelist
            GetTypeAndNodes(curve, EdgeType, arrPoints)
            i = 0
            For Each arrPoint In arrPoints
                'don't add the last point to the list!
                If i >= arrPoints.Count - 1 Then
                    Exit For
                End If

                If edgenodelist = "" Then
                    edgenodelist = arrPoint.X & ";" & arrPoint.Y & ";" & arrPoint.Z
                Else
                    edgenodelist = edgenodelist & ";" & arrPoint.X & ";" & arrPoint.Y & ";" & arrPoint.Z
                End If

                i += 1

            Next arrPoint

            GetClosedBoundaryShape = EdgeType + ";" + edgenodelist

        End Function

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
                Return My.Resources.FreeSurfaceLoad

            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("8bb2139d-3082-480f-8c0e-de049cc89821")
            End Get
        End Property
    End Class

End Namespace