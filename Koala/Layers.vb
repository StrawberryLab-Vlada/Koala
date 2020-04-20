Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class Layers
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("Layers", "Layers",
                "Component for definition of layers",
                "Koala", "Libraries")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("LayerDefinition", "LayerDefinition", "Name;Description;IsStructuralOnly - BeamLayer;Layer for beams;no", GH_ParamAccess.list, "BeamLayer;Layer For beams;no")
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("DefinedLayers", "DefinedLayers", "DefinedLayers", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim i As Long
            Dim Layers = New List(Of String)


            If (Not DA.GetDataList(Of String)(0, Layers)) Then Return

            Dim SE_layers(Layers.Count, 3) As String
            Dim FlatList As New List(Of System.Object)()
            'a section consists of: Profile name, section definition, material

            Dim item As String
            Dim itemcount As Long
            Dim layername As String, IslayerStructuralOnly As String, layerDescription As String

            'initialize some variables
            itemcount = 0

            'identify section information in the strings
            For Each item In Layers
                layername = item.Split(";")(0)
                layerDescription = item.Split(";")(1)
                IslayerStructuralOnly = item.Split(";")(2)
                SE_layers(itemcount, 0) = layername.Trim
                SE_layers(itemcount, 1) = layerDescription.Trim
                SE_layers(itemcount, 2) = IslayerStructuralOnly.Trim
                itemcount += 1
            Next

            'Flatten data for export as simple list
            FlatList.Clear()

            For i = 0 To itemcount - 1
                FlatList.Add(SE_layers(i, 0))
                FlatList.Add(SE_layers(i, 1))
                FlatList.Add(SE_layers(i, 2))
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
                Return My.Resources.Layers
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("9ef2b488-64b1-43d1-a19b-b730043c9205")
            End Get
        End Property
    End Class

End Namespace