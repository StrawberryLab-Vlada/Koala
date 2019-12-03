Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class GapLocalBeamNL
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("GapLocalBeamNL", "GapLocalBeamNL",
                "GapLocalBeamNL description",
                "Koala", "Structure")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("BeamList", "BeamList", "List of beams where to apply gap", GH_ParamAccess.list)
            pManager.AddTextParameter("Type", "Type", "Type: Both directions, Press only, Tension only ", GH_ParamAccess.item, "Both directions")
            pManager.AddNumberParameter("Displacement mm", "Displacement mm", "Displacemnt in mm", GH_ParamAccess.item, 10)
            pManager.AddTextParameter("Position", "Position", "Position: Begin, End", GH_ParamAccess.item, "Begin")

        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("gapElementList", "gapElementList", "", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim i As Long
            Dim Type As String = "Both directions"
            Dim BeamList = New List(Of String)
            Dim Displacement As Double = 0.01
            Dim Position As String = "Begin"

            If (Not DA.GetDataList(Of String)(0, BeamList)) Then Return
            If (Not DA.GetData(Of String)(1, Type)) Then Return
            DA.GetData(Of Double)(2, Displacement)
            DA.GetData(Of String)(3, Position)

            Dim SE_Gaps(BeamList.Count, 4) As String
            Dim FlatList As New List(Of System.Object)()
            'a section consists of: Profile name, section definition, material

            Dim item As String
            Dim itemcount As Long

            'initialize some variables
            itemcount = 0

            'identify section information in the strings
            For Each item In BeamList
                SE_Gaps(itemcount, 0) = Strings.Trim(item)
                SE_Gaps(itemcount, 1) = Type
                SE_Gaps(itemcount, 2) = Displacement / 1000
                SE_Gaps(itemcount, 3) = Position
                itemcount += 1
            Next

            'Flatten data for export as simple list
            FlatList.Clear()

            For i = 0 To itemcount - 1
                FlatList.Add(SE_Gaps(i, 0))
                FlatList.Add(SE_Gaps(i, 1))
                FlatList.Add(SE_Gaps(i, 2))
                FlatList.Add(SE_Gaps(i, 3))
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
                Return My.Resources.Gap
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("5b873ca1-8df8-4b85-9736-a916f00899e3")
            End Get
        End Property
    End Class

End Namespace