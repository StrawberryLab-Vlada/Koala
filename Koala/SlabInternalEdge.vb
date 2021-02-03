Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class SlabInternalEdge
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("SlabInternalEdge", "SlabInternalEdge",
                "SlabInternalEdge description",
                "Koala", "Structure")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("SurfList", "SurfList", "List of 2D member names where to internal edges", GH_ParamAccess.list)
            pManager.AddCurveParameter("Lines", "Lines", "List of lines", GH_ParamAccess.list)
            pManager.AddTextParameter("InternalEdgeNamePrefix", "InternalEdgeNamePrefix", "Internal Edge Name Prefix", GH_ParamAccess.item, "ES")
            pManager.AddTextParameter("NodePrefix", "NodePrefix", "Node prefix", GH_ParamAccess.item, "NEN")
            pManager.AddNumberParameter("Tolerance", "Tolerance", "Tolerance for duplicity nodes", GH_ParamAccess.item, 0.001)
            pManager.AddBooleanParameter("RemDuplNodes", "RemDuplNodes", "Set True if you want to remove duplicate nodes", GH_ParamAccess.item, False)
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("Nodes", "Nodes", "Output nodes", GH_ParamAccess.list)
            pManager.AddTextParameter("InternalEdges", "InternalEdges", "Output internal edges", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim SurfList = New List(Of String)
            Dim Lines = New List(Of Curve)
            Dim tolerance As Double
            Dim RemDuplNodes As Boolean
            Dim NodePrefix As String = "NES"
            Dim InternalEdgeNamePrefix As String = "ES"

            If (Not DA.GetDataList(Of String)(0, SurfList)) Then Return
            If (Not DA.GetDataList(Of Curve)(1, Lines)) Then Return
            DA.GetData(Of String)(2, InternalEdgeNamePrefix)
            If (Not DA.GetData(Of String)(3, NodePrefix)) Then Return
            If (Not DA.GetData(Of Double)(4, tolerance)) Then Return
            If (Not DA.GetData(Of Boolean)(5, RemDuplNodes)) Then Return


            Dim maxSurfList As Long = 0, maxLines As Long = 0

            Dim Surfacecescount = SurfList.Count

            If Surfacecescount < Lines.Count Then
                Rhino.RhinoApp.WriteLine("SlabInternalEdge: Less Surfaces are defined than Lines. The last defined Surface will be used for the extra lines")
            ElseIf Surfacecescount > Lines.Count Then
                Rhino.RhinoApp.WriteLine("SlabInternalEdge: Too many Lines are defined. They will be ignored.")
            End If
            maxSurfList = SurfList.Count - 1



            Dim SE_slabInternalEdges(Lines.Count, 2)
            Dim FlatInternalEdgeList As New List(Of String)()
            Dim arrPoints As New Rhino.Collections.Point3dList
            Dim EdgeType As String
            Dim nodecount As Long = 0, edgecount As Long = 0
            Dim currentnode As Long
            Dim SE_nodes(100000, 3) As String
            Dim FlatNodeList As New List(Of String)()
            Dim LineShape As String = "Line", LineType As String = "Line"

            For i = 0 To Lines.Count - 1

                'extract geometry from the curve
                GetTypeAndNodes(Lines(i), LineType, arrPoints)

                SE_slabInternalEdges(i, 0) = InternalEdgeNamePrefix + (i + 1).ToString() ' internal edge name
                ' slab name
                If i <= maxSurfList Then
                    SE_slabInternalEdges(i, 1) = SurfList(i)
                Else
                    SE_slabInternalEdges(i, 1) = SurfList(maxSurfList)
                End If



                For Each arrPoint In arrPoints



                    'check if node at these coordinates already exists
                    If RemDuplNodes Then
                        currentnode = GetExistingNode(arrPoint, SE_nodes, nodecount, tolerance)
                    Else
                        currentnode = -1
                    End If

                    If currentnode = -1 Then
                        'create it
                        nodecount = nodecount + 1
                        SE_nodes(nodecount - 1, 0) = NodePrefix & nodecount
                        SE_nodes(nodecount - 1, 1) = arrPoint.X
                        SE_nodes(nodecount - 1, 2) = arrPoint.Y
                        SE_nodes(nodecount - 1, 3) = arrPoint.Z

                        currentnode = nodecount
                    End If

                    'add the node to the line shape
                    LineShape = LineShape & ";" & SE_nodes(currentnode - 1, 0)

                Next arrPoint
                SE_slabInternalEdges(i, 2) = LineShape



                edgecount += 1
            Next

            FlatNodeList.Clear()

            For i = 0 To nodecount - 1
                For j = 0 To 3
                    FlatNodeList.Add(SE_nodes(i, j))
                Next j
            Next i
            DA.SetDataList(0, FlatNodeList)


            FlatInternalEdgeList.Clear()

            For i = 0 To edgecount - 1
                If SE_slabInternalEdges(i, 0) Is Nothing Then
                    Continue For
                End If
                FlatInternalEdgeList.Add(SE_slabInternalEdges(i, 0))
                FlatInternalEdgeList.Add(SE_slabInternalEdges(i, 1))
                FlatInternalEdgeList.Add(SE_slabInternalEdges(i, 2))



            Next i
            DA.SetDataList(1, FlatInternalEdgeList)

        End Sub


        ''' <summary>
        ''' Provides an Icon for every component that will be visible in the User Interface.
        ''' Icons need to be 24x24 pixels.
        ''' </summary>
        Protected Overrides ReadOnly Property Icon() As System.Drawing.Bitmap
            Get
                'You can add image files to your project resources and access them like this:
                ' return Resources.IconForThisComponent;
                Return My.Resources.InternalSlab
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("c3b6f1f3-59ee-4baa-9dff-20ab1c42da42")
            End Get
        End Property
    End Class

End Namespace