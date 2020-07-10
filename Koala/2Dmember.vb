Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class _2Dmember
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("2Dmember", "2Dmember",
                "2Dmember description",
                "Koala", "Structure")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddBrepParameter("Surfaces", "Surfaces", "List of definiton curves for beams", GH_ParamAccess.list)
            pManager.AddTextParameter("Material", "Material", "Material", GH_ParamAccess.list, "C20/25")
            pManager.AddTextParameter("Thickness", "Thickness", "Thickness", GH_ParamAccess.list) ', "0.2"
            pManager.AddTextParameter("SurfLayer", "SurfLayer", "Definition of SurfLayer", GH_ParamAccess.item, "Surflayer")
            pManager.AddTextParameter("InternalNodes", "InternalNodes", "InternalNodes", GH_ParamAccess.list)
            pManager.Param(4).Optional = True
            pManager.AddTextParameter("NodePrefix", "NodePrefix", "Node prefix", GH_ParamAccess.item, "N2D")
            pManager.AddNumberParameter("Tolerance", "Tolerance", "Tolerance for duplicity nodes", GH_ParamAccess.item, 0.001)
            pManager.AddBooleanParameter("RemDuplNodes", "RemDuplNodes", "Set True if you want to remove duplicate nodes", GH_ParamAccess.item, False)
            pManager.AddIntegerParameter("MemberSystemPlane", "MemberSystemPlane", "System plane of the member:  Right click and select from options or Centre - 1, Top - 2, Bottom - 4", GH_ParamAccess.list, 1)
            AddOptionstoMenuMemberSystemPlane(pManager.Param(8))
            pManager.AddNumberParameter("Eccentricity z", "Eccentricity z", "Eccentricity of the plane", GH_ParamAccess.list, 0.0)
            pManager.AddIntegerParameter("FEM nonlinear model", "FEM nonlinear model", "Nonlinear model: Right click and select from options or none - 0, Press only - 1, Membarene - 2", GH_ParamAccess.list, 0)
            AddOptionstoMenuFEMNLType2D(pManager.Param(10))
            pManager.AddTextParameter("SurfaceNamePrefix", "SurfaceNamePrefix", "Surface name prefix", GH_ParamAccess.item, "S")
            pManager.AddIntegerParameter("SwapOrientation", "SwapOrientation", "Swap orientation of surface No - 0, Yes - 1", GH_ParamAccess.list, 0)
            AddOptionstoMenuSwapOrientation(pManager.Param(12))
            pManager.AddNumberParameter("LCSangle", "LCSangle", "LCS angle[deg]", GH_ParamAccess.list, 0)
            'pManager.AddTextParameter("Type", "Type", "Type of element: Plate, Wall, Shell", GH_ParamAccess.item, "Plate")

        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("Nodes", "Nodes", "Output nodes", GH_ParamAccess.list)
            pManager.AddTextParameter("Surfaces", "Surfaces", "Output surfaces", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim Surfaces = New List(Of Brep)
            Dim Material As New List(Of String) 'String = "C20/25"
            Dim Thickness As New List(Of String)
            Dim SurfLayer As String = "Surfaces"
            Dim InternalNodes = New List(Of String)
            Dim NodePrefix As String = "NS"
            Dim Tolerance As Double = 0.001
            Dim RemDuplNodes As Boolean = False
            Dim MemberPlane As String = "Centre"
            Dim MemberPlanes = New List(Of Integer)
            Dim EccentricityZ As Double = 0.0
            Dim EccentricityZs = New List(Of Double)
            Dim FEMNLType As String = "none"
            Dim FEMNLTypes = New List(Of Integer)
            Dim SurfaceNamePrefix As String = "S"
            Dim i As Integer = 0
            Dim SwapOrientation As Integer = 0
            Dim SwapOrientations = New List(Of Integer)
            Dim AngleLCS As Double = 0.0
            Dim AngleLCSs = New List(Of Double)

            If (Not DA.GetDataList(Of Brep)(0, Surfaces)) Then Return
            If (Not DA.GetDataList(Of String)(1, Material)) Then Return
            If (Not DA.GetDataList(Of String)(2, Thickness)) Then Return
            If (Not DA.GetData(Of String)(3, SurfLayer)) Then Return
            DA.GetDataList(Of String)(4, InternalNodes)
            If (Not DA.GetData(Of String)(5, NodePrefix)) Then Return
            If (Not DA.GetData(Of Double)(6, Tolerance)) Then Return
            If (Not DA.GetData(Of Boolean)(7, RemDuplNodes)) Then Return
            If (Not DA.GetDataList(Of Integer)(8, MemberPlanes)) Then Return
            'If (Not DA.GetData(Of Integer)(8, i)) Then Return
            'MemberPlane = GetStringForMemberSystemLineOrPlane(i)
            'If (Not DA.GetData(Of Double)(9, EccentricityZ)) Then Return
            If (Not DA.GetDataList(Of Double)(9, EccentricityZs)) Then Return
            If (Not DA.GetDataList(Of Integer)(10, FEMNLTypes)) Then Return
            'If (Not DA.GetData(Of Integer)(10, i)) Then Return
            'FEMNLType = GetStringForFEMNLType2D(i)
            If (Not DA.GetData(Of String)(11, SurfaceNamePrefix)) Then Return
            If (Not DA.GetDataList(Of Integer)(12, SwapOrientations)) Then Return
            'If (Not DA.GetData(Of Integer)(12, SwapOrientation)) Then Return
            ' SwapOrientation = GetStringFromSwapOrientation(i)
            'If (Not DA.GetData(Of Double)(13, AngleLCS)) Then Return
            If (Not DA.GetDataList(Of Double)(13, AngleLCSs)) Then Return
            Dim j As Long

            AngleLCS = (AngleLCS * Math.PI) / 180
            Dim edgecount As Long, iedge As Long
            Dim edgenodelist As String, nodesinedge As Long

            Dim currentnode As Long, inode As Long

            Dim SE_nodes(100000, 3) As String  'a node consists of: Name, X, Y, Z > make the array a dynamic list later
            Dim FlatNodeList As New List(Of String)()
            Dim SE_surfaces(Surfaces.Count, 11) As String 'a surface consists of: Name, Type, Material, Thickness, Layer, BoundaryShape, InternalNodes
            Dim FlatSurfaceList As New List(Of String)()

            Dim nodecount As Long, surfacecount As Long

            'Declarations to work with RhinoCommon objects
            Dim brep As Rhino.Geometry.Brep
            Dim nakededges() As Rhino.Geometry.Curve
            Dim fullSurf As Rhino.Geometry.Surface
            Dim edge As Rhino.Geometry.Curve
            Dim joinedcurves() As Rhino.Geometry.Curve
            Dim segments() As Rhino.Geometry.Curve

            Dim arrPoint As Rhino.Geometry.Point3d
            Dim arrPoints As New Rhino.Collections.Point3dList

            Dim FirstPoint As Rhino.Geometry.Point3d, FirstNode As String, ClosedSurface As Boolean
            Dim LastEdgeNode As String

            Dim SurfType As String

            Dim EdgeType As String
            Dim BoundaryShape As String

            Dim line As String, SurfaceName As String, NodeList As String

            Dim stopWatch As New System.Diagnostics.Stopwatch()
            Dim time_elapsed As Double
            Dim maxMemberPlanes As Long, maxEz As Long, maxFEMNLtypes As Long, maxSwapOrient As Long, maxAngelLCS As Long, maxMaterials As Long, maxThickness As Long

            'initialize stopwatch
            stopWatch.Start()

            'initialize some variables
            nodecount = 0
            surfacecount = 0
            SurfType = ""


            Dim Surfacecescount = Surfaces.Count
            'check nr of z vectors
            If Surfacecescount < MemberPlanes.Count Then
                Rhino.RhinoApp.WriteLine("Koala2Dmembers: Too many MemberPlanes are defined. They will be ignored.")
            ElseIf Surfacecescount > MemberPlanes.count Then
                Rhino.RhinoApp.WriteLine("Koala2Dmembers: Less MemberPlanes are defined than beams. The last defined Z vector will be used for the extra beams")
            End If
            maxMemberPlanes = MemberPlanes.Count - 1

            'check nr of layers
            If Surfacecescount < EccentricityZs.Count Then
                Rhino.RhinoApp.WriteLine("Koala2Dmembers: Too many EccentricityZs are defined. They will be ignored.")
            ElseIf Surfacecescount > EccentricityZs.count Then
                Rhino.RhinoApp.WriteLine("Koala2Dmembers: Less EccentricityZs are defined than beams. The last defined layer will be used for the extra beams")
            End If
            maxEz = EccentricityZs.Count - 1

            'check nr of sections
            If Surfacecescount < FEMNLTypes.Count Then
                Rhino.RhinoApp.WriteLine("Koala2Dmembers: Too many FEMNLTypes are defined. They will be ignored.")
            ElseIf Surfacecescount > FEMNLTypes.Count Then
                Rhino.RhinoApp.WriteLine("Koala2Dmembers: Less FEMNLTypes are defined than beams. The last defined section will be used for the extra beams")
            End If
            maxFEMNLtypes = FEMNLTypes.Count - 1

            'check maxStructuralTypes of sections
            If Surfacecescount < SwapOrientations.Count Then
                Rhino.RhinoApp.WriteLine("Koala2Dmembers: Too many  SwapOrientations are defined. They will be ignored.")
            ElseIf Surfacecescount > SwapOrientations.Count Then
                Rhino.RhinoApp.WriteLine("Koala2Dmembers: Less SwapOrientations are defined than beams. The last defined section will be used for the extra beams")
            End If
            maxSwapOrient = SwapOrientations.Count - 1

            'check maxFEMTypes of sections
            If Surfacecescount < AngleLCSs.Count Then
                Rhino.RhinoApp.WriteLine("Koala2Dmembers: Too many  FEMtypes are defined. They will be ignored.")
            ElseIf Surfacecescount > AngleLCSs.Count Then
                Rhino.RhinoApp.WriteLine("Koala2Dmembers: Less FEMtypes are defined than beams. The last defined section will be used for the extra beams")
            End If
            maxAngelLCS = AngleLCSs.Count - 1

            'check maxMaterials of sections
            If Surfacecescount < Material.Count Then
                Rhino.RhinoApp.WriteLine("Koala2Dmembers: Too many  Materials are defined. They will be ignored.")
            ElseIf Surfacecescount > Material.Count Then
                Rhino.RhinoApp.WriteLine("Koala2Dmembers: Less Materials are defined than beams. The last defined section will be used for the extra beams")
            End If
            maxMaterials = Material.Count - 1

            'check maxThickness of sections
            If Surfacecescount < Thickness.Count Then
                Rhino.RhinoApp.WriteLine("Koala2Dmembers: Too many  Thicknesses are defined. They will be ignored.")
            ElseIf Surfacecescount > Thickness.Count Then
                Rhino.RhinoApp.WriteLine("Koala2Dmembers: Less Thicknesses are defined than beams. The last defined section will be used for the extra beams")
            End If
            maxThickness = Thickness.Count - 1



            'loop through all surfaces
            '===========================

            For Each brep In Surfaces

                'check if the surface can be handled to SCIA Engineer: non-planar surfaces may have a maximum of 4 boundary edges

                'get surface boundary
                nakededges = brep.DuplicateNakedEdgeCurves(True, False) 'this contains an unsorted list of edges

                'join
                joinedcurves = Rhino.Geometry.Curve.JoinCurves(nakededges)
                'explode the first curve back to segments - this should now be properly sorted
                If joinedcurves(0).IsCircle() Then
                    ReDim Preserve segments(0)


                    segments.SetValue(joinedcurves(0), 0)
                    edgecount = 1

                Else
                    segments = joinedcurves(0).DuplicateSegments
                    edgecount = segments.Count
                End If

                fullSurf = brep.Faces(0)

                FirstNode = ""
                ClosedSurface = False
                If edgecount <= 4 And Not (fullSurf.IsPlanar(Tolerance)) Then
                    'shells, max 4 edges
                    SurfType = "Shell"
                ElseIf fullSurf.IsPlanar(Tolerance) Then
                    'plates
                    SurfType = "Plate"
                Else
                    'not supported: shell with more than 4 edges
                    Rhino.RhinoApp.WriteLine("KoalaSurfaces: Encountered surface with " & edgecount & " (>4) edges and non-planar: not supported, will be skipped")
                    Rhino.RhinoApp.WriteLine("KoalaSurfaces: Tip: subdivide the brep into individual faces (with max. 4 edges per face)")
                    'Continue For
                End If

                surfacecount += 1

                SE_surfaces(surfacecount - 1, 0) = SurfaceNamePrefix + surfacecount.ToString()
                SE_surfaces(surfacecount - 1, 1) = SurfType
                If i <= maxMaterials Then
                    SE_surfaces(surfacecount - 1, 2) = Material(i)
                Else
                    SE_surfaces(surfacecount - 1, 2) = Material(maxMaterials)
                End If
                If i <= maxThickness Then
                    SE_surfaces(surfacecount - 1, 3) = Thickness(i)
                Else
                    SE_surfaces(surfacecount - 1, 3) = Thickness(maxThickness)
                End If


                SE_surfaces(surfacecount - 1, 4) = SurfLayer

                iedge = 0
                BoundaryShape = ""
                LastEdgeNode = ""

                For Each edge In segments

                    If edge.GetLength() < Tolerance Then
                        'skip this edge
                        Exit For
                    End If

                    'Get type of curve and nodelist
                    EdgeType = ""
                    GetTypeAndNodes(edge, EdgeType, arrPoints)

                    nodesinedge = arrPoints.Count
                    edgenodelist = ""
                    inode = 0

                    For Each arrPoint In arrPoints

                        inode = inode + 1

                        'for edges 2 and beyond, skip the first node
                        If LastEdgeNode <> "" And inode = 1 Then
                            edgenodelist = LastEdgeNode
                        Else
                            'check if the surface is closed: the new point is identical with the first node
                            If FirstNode <> "" And arrPoint.DistanceToSquared(FirstPoint) < Tolerance * Tolerance Then
                                ClosedSurface = True
                                Exit For
                            Else
                                'check if a node already exists at these coordinates
                                If RemDuplNodes Then
                                    currentnode = GetExistingNode(arrPoint, SE_nodes, nodecount, Tolerance)
                                Else
                                    currentnode = -1
                                End If

                                If currentnode = -1 Then
                                    'create it, then add it to the edge information
                                    nodecount = nodecount + 1
                                    SE_nodes(nodecount - 1, 0) = NodePrefix & nodecount.ToString()
                                    If FirstNode = "" Then
                                        'store the position of the first node to later check if the surface is closed
                                        FirstNode = SE_nodes(nodecount - 1, 0)
                                        FirstPoint = arrPoint
                                    End If
                                    SE_nodes(nodecount - 1, 1) = arrPoint(0)
                                    SE_nodes(nodecount - 1, 2) = arrPoint(1)
                                    SE_nodes(nodecount - 1, 3) = arrPoint(2)
                                    currentnode = nodecount
                                End If

                                If edgenodelist = "" Then
                                    edgenodelist = SE_nodes(currentnode - 1, 0)
                                Else
                                    If inode < nodesinedge Then 'closed curve for SCIA Engineer > don't add the last point
                                        edgenodelist = edgenodelist & ";" & SE_nodes(currentnode - 1, 0)
                                    ElseIf inode = nodesinedge And EdgeType = "Circle" Then
                                        edgenodelist = edgenodelist & ";" & SE_nodes(currentnode - 1, 0)

                                    End If
                                End If
                            End If

                        End If

                    Next arrPoint

                    LastEdgeNode = SE_nodes(currentnode - 1, 0)

                    'add edge information to the BoundaryShape string
                    If BoundaryShape = "" Then
                        If EdgeType = "Circle" Then
                            Dim circle As Rhino.Geometry.Circle
                            edge.TryGetCircle(circle)

                            BoundaryShape = EdgeType + ";" + edgenodelist + ";" + "[" + (circle.Center.X + circle.Normal.X).ToString() + "," + (circle.Center.Y + circle.Normal.Y).ToString() + "," + (circle.Center.Z + circle.Normal.Z).ToString() + "]"
                        Else
                            BoundaryShape = EdgeType + ";" + edgenodelist
                        End If
                    Else
                        BoundaryShape = BoundaryShape + " | " + EdgeType + ";" + edgenodelist
                    End If
                    iedge += 1

                    'don't go to next edge if the surface is closed
                    If ClosedSurface Then Exit For

                Next edge 'iterate to next edge

                SE_surfaces(surfacecount - 1, 5) = BoundaryShape
                SE_surfaces(surfacecount - 1, 6) = "" 'initialize list of internal nodes to empty string

                If i <= maxMemberPlanes Then
                    MemberPlane = GetStringForMemberSystemLineOrPlane(MemberPlanes(i))
                Else
                    MemberPlane = GetStringForMemberSystemLineOrPlane(MemberPlanes(maxMemberPlanes))
                End If
                SE_surfaces(surfacecount - 1, 7) = MemberPlane

                If i <= maxEz Then
                    EccentricityZ = EccentricityZs(i)
                Else
                    EccentricityZ = EccentricityZs(maxEz)
                End If
                SE_surfaces(surfacecount - 1, 8) = EccentricityZ

                If i <= maxFEMNLtypes Then
                    FEMNLType = GetStringForFEMNLType2D(FEMNLTypes(i))
                Else
                    FEMNLType = GetStringForFEMNLType2D(FEMNLTypes(maxFEMNLtypes))
                End If
                SE_surfaces(surfacecount - 1, 9) = FEMNLType

                If i <= maxSwapOrient Then
                    SwapOrientation = SwapOrientations(i)
                Else
                    SwapOrientation = SwapOrientations(maxSwapOrient)
                End If
                SE_surfaces(surfacecount - 1, 10) = SwapOrientation

                If i <= maxAngelLCS Then
                    AngleLCS = (AngleLCSs(i) * Math.PI) / 180
                Else
                    AngleLCS = (AngleLCSs(maxAngelLCS) * Math.PI) / 180
                End If
                SE_surfaces(surfacecount - 1, 11) = AngleLCS
            Next brep 'iterate to next surface

            'add internal nodes to the surfaces
            If InternalNodes IsNot Nothing And InternalNodes.Count <> 0 Then
                For Each line In InternalNodes
                    SurfaceName = Trim(line.Split("|")(0))
                    NodeList = Trim(line.Split("|")(1))

                    For i = 0 To surfacecount - 1
                        If SurfaceName = SE_surfaces(i, 0) Then
                            SE_surfaces(i, 6) = NodeList
                            Exit For
                        End If
                    Next i
                Next line
            End If

            FlatNodeList.Clear()

            For i = 0 To nodecount - 1
                For j = 0 To 3
                    FlatNodeList.Add(SE_nodes(i, j))
                Next j
            Next i
            DA.SetDataList(0, FlatNodeList)


            FlatSurfaceList.Clear()

            For i = 0 To surfacecount - 1
                For j = 0 To 11
                    FlatSurfaceList.Add(SE_surfaces(i, j))
                Next j
            Next i
            DA.SetDataList(1, FlatSurfaceList)

            'stop stopwatch
            stopWatch.Stop()
            time_elapsed = stopWatch.ElapsedMilliseconds
            'rhino.RhinoApp.WriteLine("Koala: Done in " + str(time_elapsed) + " ms.")

        End Sub

        ''' <summary>
        ''' Provides an Icon for every component that will be visible in the User Interface.
        ''' Icons need to be 24x24 pixels.
        ''' </summary>
        Protected Overrides ReadOnly Property Icon() As System.Drawing.Bitmap
            Get
                'You can add image files to your project resources and access them like this:
                Return My.Resources._2DMember
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("241d3b00-3cfe-4be4-9ebb-9cc86888baf8")
            End Get
        End Property
    End Class

End Namespace