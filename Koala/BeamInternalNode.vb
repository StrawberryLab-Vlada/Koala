Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class BeamInternalNode
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("BeamInternalNode", "BeamInternalNode",
                "BeamInternalNode description",
                "Koala", "Structure")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddPointParameter("PointList", "PointList", "List of points", GH_ParamAccess.list)
            pManager.AddTextParameter("BeamNames", "BeamNames", "List of Beam Names where to put internal nodes", GH_ParamAccess.list)
            pManager.AddTextParameter("NodePrefix", "NodePrefix", "Prefix for nodes", GH_ParamAccess.item, "N")

        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("Nodes", "Nodes", "output internal nodes", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim i As Long, j As Long

            Dim Points = New List(Of Point3d)
            Dim BeamNames = New List(Of String)
            Dim NodePrefix As String
            NodePrefix = "N"


            If (Not DA.GetDataList(Of Point3d)(0, Points)) Then Return
            If (Not DA.GetDataList(Of String)(1, BeamNames)) Then Return
            If (Not DA.GetData(Of String)(2, NodePrefix)) Then Return

            Dim SE_nodes(Points.Count, 4) 'a node consists of: Name, X, Y, Z
            Dim FlatList As New List(Of System.Object)()


            Dim maxNames As Long = 0, maxPoint As Long = 0

            Dim BeamNamesCount = BeamNames.Count

            If BeamNamesCount < Points.Count Then
                Rhino.RhinoApp.WriteLine("InternalBeamNodes: Less BeamNames are defined than Points. The last defined Name will be used for the extra points")
            ElseIf BeamNamesCount > Points.Count Then
                Rhino.RhinoApp.WriteLine("InternalBeamNodes: Too many BeamNames are defined. They will be ignored.")
            End If
            maxNames = BeamNames.Count - 1

            Dim item As Rhino.Geometry.Point3d
            Dim itemcount As Long

            'initialize some variables
            itemcount = 0

            For Each item In Points
                itemcount = itemcount + 1

                SE_nodes(itemcount, 0) = NodePrefix & itemcount
                SE_nodes(itemcount, 1) = item.X
                SE_nodes(itemcount, 2) = item.Y
                SE_nodes(itemcount, 3) = item.Z
                If itemcount - 1 < maxNames Then
                    SE_nodes(itemcount, 4) = BeamNames(itemcount - 1)
                Else
                    SE_nodes(itemcount, 4) = BeamNames(maxNames)
                End If


            Next

            'Flatten data for export as simple list
            FlatList.Clear()

            For i = 1 To itemcount
                For j = 0 To 4
                    FlatList.Add(SE_nodes(i, j))
                Next j
            Next i

            DA.SetDataList(0, FlatList)

        End Sub


        ''' <summary>
        ''' Provides an Icon for every component that will be visible in the User Interface.
        ''' Icons need to be 24x24 pixels.
        ''' </summary>
        Protected Overrides ReadOnly Property Icon() As System.Drawing.Bitmap
            Get
                'You can add image files to your project resources and access them like this:
                ' return Resources.IconForThisComponent;
                Return My.Resources.BeamInternalNode
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("e9e506d9-ead0-44c0-b6a3-8bee3d1bd926")
            End Get
        End Property
    End Class

End Namespace