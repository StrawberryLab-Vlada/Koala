Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class PressTensionOnlyBeamNl
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("PressTensionOnlyBeamNl", "PressTensionOnlyBeamNl",
                "PressTensionOnlyBeamNl description",
                "Koala", "Structure")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("BeamList", "BeamList", "List of beams where to apply gap", GH_ParamAccess.list)
            pManager.AddTextParameter("Type", "Type", "Type: Press only, Tension only ", GH_ParamAccess.item, "Press only")
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("PressTensionNLElementList", "PressTensionNLElementList", "", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim i As Long
            Dim Type As String = "Press only"
            Dim BeamList = New List(Of String)


            If (Not DA.GetDataList(Of String)(0, BeamList)) Then Return
            If (Not DA.GetData(Of String)(1, Type)) Then Return

            Dim SE_elements(BeamList.Count, 2) As String
            Dim FlatList As New List(Of System.Object)()
            'a section consists of: Profile name, section definition, material

            Dim item As String
            Dim itemcount As Long

            'initialize some variables
            itemcount = 0

            'identify section information in the strings
            For Each item In BeamList
                SE_elements(itemcount, 0) = Strings.Trim(item)
                SE_elements(itemcount, 1) = Type

                itemcount += 1
            Next

            'Flatten data for export as simple list
            FlatList.Clear()

            For i = 0 To itemcount - 1
                FlatList.Add(SE_elements(i, 0))
                FlatList.Add(SE_elements(i, 1))
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
                Return My.Resources.PressOnly
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("26133ceb-3c67-47dd-bce8-2728ecfd5b74")
            End Get
        End Property
    End Class

End Namespace