Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class NonlinearCombination
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("NonlinearCombination", "NonlinearCombination",
                "NonlinearCombination description",
                "Koala", "Libraries")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("Name", "Name", "Name of combination", GH_ParamAccess.item, "CO1")
            pManager.AddTextParameter("Type", "Type", "Type of combination: Ultimate, Serviceability", GH_ParamAccess.item, "Ultimate")
            pManager.AddTextParameter("CombinationInput", "CombinationInput", "Content of combination, eg: 1.5*LC1;2*LC2", GH_ParamAccess.item, "1.5*LC1;2*LC2")

        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("NLCombinationOutput", "NLCombinationOutput", "", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)
            Dim Name As String = "NC1"
            Dim Type As String = "Ultimate"
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
                Return My.Resources.NonLinearCombination
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("08183d59-48dd-4865-94ae-93a4b74146a6")
            End Get
        End Property
    End Class

End Namespace