Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class LinearCombination
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("LinearCombination", "LinearCombination",
                "LinearCombination description",
                "Koala", "Libraries")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("Name", "Name", "Name of combination", GH_ParamAccess.item, "CO1")
            pManager.AddTextParameter("Type", "Type", "Type of combination: Envelope - ultimate, Envelope - serviceability, Linear - ultimate, Linear - serviceability, EN - ULS(Str() / GEO) Set B, EN - Accidental 1, EN - Accidental 2, EN - Seismic, EN - SLS Characteristic, EN - SLS Frequent, EN - SLS Quasi-permanent, EN - ULS(Str() / GEO) Set C", GH_ParamAccess.item, "Linear - ultimate")
            pManager.AddTextParameter("CombinationInput", "CombinationInput", "Content of combination, eg: 1.5*LC1;2*LC2", GH_ParamAccess.item, "1.5*LC1;2*LC2")
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("CombinationOutput", "CombinationOutput", "", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim Name As String = "CO1"
            Dim Type As String = "Linear - ultimate"
            Dim Content As String = "1*LC2"
            If (Not DA.GetData(Of String)(0, Name)) Then Return
            If (Not DA.GetData(Of String)(1, Type)) Then Return
            If (Not DA.GetData(Of String)(2, Content)) Then Return

            Dim FlatList As New List(Of System.Object) From {
                Name,
                Type,
                Content
            }
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
                Return My.Resources.LinearCombination
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("aaacdb21-4d03-4a50-8bff-2a52ad55b5ff")
            End Get
        End Property
    End Class

End Namespace