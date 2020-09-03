Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class LoadPanels
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("LoadPanels", "LoadPanels",
                "LoadPanels description",
                "Koala", "Structure")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("LoadPanelNamePrefix", "LoadPanelNamePrefix", "Load panel name prefix", GH_ParamAccess.item, "LP")
            pManager.AddBrepParameter("Surfaces", "Surfaces", "List of definiton flat surfaces for loadpanels", GH_ParamAccess.list)
            pManager.AddTextParameter("LoadPanelsLayer", "LoadPanelsLayer", "Definition of SurfLayer", GH_ParamAccess.item, "LoadPanelsLayer")
            pManager.AddIntegerParameter("PanelType", "PanelType", "Panel type: to panel nodes (0), to panel edges(1), to panel edges and beams(2)", GH_ParamAccess.list, 2)
            AddOptionsToMenuPanelType(pManager.Param(3))
            pManager.AddIntegerParameter("TransferDirection", "TransferDirection", "Transfer Direction: X (0), Y(1), all (2)", GH_ParamAccess.list, 2)
            AddOptionsToMenuTransferDirection(pManager.Param(4))
            'pManager.AddTextParameter("TransferDirectionRatio", "TransferDirectionRatio", "Transfer Direction Ratio X|Y e.g. 50|50", GH_ParamAccess.item, "50|50")
            pManager.AddIntegerParameter("TransferMethod", "TransferMethod", "Transfer Method: Standard (1), Tributary area(3), Accurate(FEM),fixed link with beams (0), Accurate(FEM),hinged link with beams (2) ", GH_ParamAccess.list, 1)
            AddOptionsToMenuTransferMethod(pManager.Param(5))
            pManager.AddNumberParameter("Tolerance", "Tolerance", "Tolerance for duplicity nodes", GH_ParamAccess.item, 0.001)
            pManager.AddBooleanParameter("RemDuplNodes", "RemDuplNodes", "Set True if you want to remove duplicate nodes", GH_ParamAccess.item, False)
            pManager.AddIntegerParameter("SwapOrientation", "SwapOrientation", "Swap orientation of surface No - 0, Yes - 1", GH_ParamAccess.list, 0)
            pManager.AddNumberParameter("LCSangle", "LCSangle", "LCS angle[deg]", GH_ParamAccess.list, 0)
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("Nodes", "Nodes", "Output nodes", GH_ParamAccess.list)
            pManager.AddTextParameter("LoadPanels", "LoadPanels", "Output Load panels", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim LoadPanelNamePrefix As String = "LP"
            Dim Surfaces = New List(Of Brep)
            Dim LoadPanelsLayer As String = "LoadPanelsLayer"
            Dim Tolerance As Double = 0.001
            Dim RemDuplNodes As Boolean = False
            Dim i As Long
            Dim PanelTypes = New List(Of Integer)
            Dim TransferDirection = New List(Of Integer)

            Dim TransferMethod = New List(Of Integer)
            Dim SwapOrientation As Integer = 0
            Dim SwapOrientations = New List(Of Integer)
            Dim AngleLCS As Double = 0.0
            Dim AngleLCSs = New List(Of Double)
            Dim NodePrefix = LoadPanelNamePrefix & "N"

            If (Not DA.GetData(Of String)(0, LoadPanelNamePrefix)) Then Return
            If (Not DA.GetDataList(Of Brep)(1, Surfaces)) Then Return
            If (Not DA.GetData(Of String)(2, LoadPanelsLayer)) Then Return
            If (Not DA.GetDataList(Of Integer)(3, PanelTypes)) Then Return
            If (Not DA.GetDataList(Of Integer)(4, TransferDirection)) Then Return
            If (Not DA.GetDataList(Of Integer)(5, TransferMethod)) Then Return

            If (Not DA.GetData(Of Double)(6, Tolerance)) Then Return
            If (Not DA.GetData(Of Boolean)(7, RemDuplNodes)) Then Return


            If (Not DA.GetDataList(Of Integer)(8, SwapOrientations)) Then Return
            If (Not DA.GetDataList(Of Double)(9, AngleLCSs)) Then Return
            Dim j As Long

            AngleLCS = (AngleLCS * Math.PI) / 180
            Dim edgecount As Long, iedge As Long
            Dim edgenodelist As String, nodesinedge As Long

            Dim currentnode As Long, inode As Long

            Dim SE_nodes(100000, 3) As String  'a node consists of: Name, X, Y, Z > make the array a dynamic list later
            Dim FlatNodeList As New List(Of String)()
            Dim SE_surfaces(Surfaces.Count, 7) As String
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
            Dim maxPanelTypes As Long, maxTransferDirection As Long, maxTransferMethod As Long, maxSwapOrient As Long, maxAngelLCS As Long

            'initialize stopwatch
            stopWatch.Start()

            'initialize some variables
            nodecount = 0
            surfacecount = 0
            SurfType = ""


            Dim Surfacecescount = Surfaces.Count
            'check nr of z vectors
            If Surfacecescount < PanelTypes.Count Then
                Rhino.RhinoApp.WriteLine("KoalaLoadPanels: Too many PanelTypes are defined. They will be ignored.")
            ElseIf Surfacecescount > PanelTypes.Count Then
                Rhino.RhinoApp.WriteLine("KoalaLoadPanels: Less PanelTypes are defined than load panels. The last defined panel type will be used for the extra load panels")
            End If
            maxPanelTypes = PanelTypes.Count - 1

            'check nr of layers
            If Surfacecescount < TransferDirection.Count Then
                Rhino.RhinoApp.WriteLine("KoalaLoadPanels: Too many TransferDirection are defined. They will be ignored.")
            ElseIf Surfacecescount > TransferDirection.Count Then
                Rhino.RhinoApp.WriteLine("KoalaLoadPanels: Less TransferDirection are defined than load panels. The last defined transfer direction will be used for the extra panels")
            End If
            maxTransferDirection = TransferDirection.Count - 1

            'check nr of sections
            If Surfacecescount < TransferMethod.Count Then
                Rhino.RhinoApp.WriteLine("KoalaLoadPanels: Too many TransferMethod are defined. They will be ignored.")
            ElseIf Surfacecescount > TransferMethod.Count Then
                Rhino.RhinoApp.WriteLine("KoalaLoadPanels: Less TransferMethod are defined than load panels. The last defined transfer method will be used for the extra panels")
            End If
            maxTransferMethod = TransferMethod.Count - 1

            'check maxStructuralTypes of sections
            If Surfacecescount < SwapOrientations.Count Then
                Rhino.RhinoApp.WriteLine("KoalaLoadPanels: Too many  SwapOrientations are defined. They will be ignored.")
            ElseIf Surfacecescount > SwapOrientations.Count Then
                Rhino.RhinoApp.WriteLine("KoalaLoadPanels: Less SwapOrientations are defined than beams. The last defined section will be used for the extra panels")
            End If
            maxSwapOrient = SwapOrientations.Count - 1

            'check maxFEMTypes of sections
            If Surfacecescount < AngleLCSs.Count Then
                Rhino.RhinoApp.WriteLine("KoalaLoadPanels: Too many  AngleLCSs are defined. They will be ignored.")
            ElseIf Surfacecescount > AngleLCSs.Count Then
                Rhino.RhinoApp.WriteLine("Koala2KoalaLoadPanelsDmembers: Less AngleLCSs are defined than beams. The last defined section will be used for the extra panels")
            End If
            maxAngelLCS = AngleLCSs.Count - 1





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

                SE_surfaces(surfacecount - 1, 0) = LoadPanelNamePrefix + surfacecount.ToString()

                SE_surfaces(surfacecount - 1, 1) = LoadPanelsLayer


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

                SE_surfaces(surfacecount - 1, 2) = BoundaryShape

                If i <= maxPanelTypes Then
                    SE_surfaces(surfacecount - 1, 3) = PanelTypes(i)
                Else
                    SE_surfaces(surfacecount - 1, 4) = PanelTypes(maxPanelTypes)
                End If
                If i <= maxTransferDirection Then
                    SE_surfaces(surfacecount - 1, 4) = TransferDirection(i)
                Else
                    SE_surfaces(surfacecount - 1, 5) = TransferDirection(maxTransferDirection)
                End If
                If i <= maxTransferMethod Then
                    SE_surfaces(surfacecount - 1, 5) = TransferMethod(i)
                Else
                    SE_surfaces(surfacecount - 1, 5) = TransferMethod(maxTransferMethod)
                End If

                If i <= maxSwapOrient Then
                    SwapOrientation = SwapOrientations(i)
                Else
                    SwapOrientation = SwapOrientations(maxSwapOrient)
                End If
                SE_surfaces(surfacecount - 1, 6) = SwapOrientation

                If i <= maxAngelLCS Then
                    AngleLCS = (AngleLCSs(i) * Math.PI) / 180
                Else
                    AngleLCS = (AngleLCSs(maxAngelLCS) * Math.PI) / 180
                End If
                SE_surfaces(surfacecount - 1, 7) = AngleLCS
            Next brep 'iterate to next surface

            For i = 0 To nodecount - 1
                For j = 0 To 3
                    FlatNodeList.Add(SE_nodes(i, j))
                Next j
            Next i
            DA.SetDataList(0, FlatNodeList)


            FlatSurfaceList.Clear()

            For i = 0 To surfacecount - 1
                For j = 0 To 7
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
                ' return Resources.IconForThisComponent;
                Return My.Resources.LoadPanel
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("baaa25dc-a287-4455-8621-0cd8609c6071")
            End Get
        End Property
    End Class

End Namespace