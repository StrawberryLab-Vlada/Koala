Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class Subsoil
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("Subsoil", "Subsoil",
                "Subsoil description",
                "Koala", "Libraries")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)

            pManager.AddTextParameter("SubsoilName", "SubsoilName", "Name of subsoil", GH_ParamAccess.item, "Subsoil0")
            pManager.AddTextParameter("Description", "Description", "Description", GH_ParamAccess.item, "Defined subsoil for surface support")
            pManager.AddNumberParameter("C1x", "C1x", "C1x in MN/m^3", GH_ParamAccess.item, 50.0)
            pManager.AddNumberParameter("C1y", "C1y", "C1y in MN/m^3", GH_ParamAccess.item, 50.0)
            pManager.AddNumberParameter("C1z", "C1z", "C1z in MN/m^3", GH_ParamAccess.item, 50.0)
            pManager.AddNumberParameter("C2x", "C2x", "C2x in MN/m^3", GH_ParamAccess.item, 50.0)
            pManager.AddNumberParameter("C2y", "C2y", "C2y in MN/m^3", GH_ParamAccess.item, 50.0)
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("Subsoil", "Subsoil", "", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim SubsoilName As String = "Subsoil0"
            Dim Description As String = "Subsoil0"
            Dim C1x As Double
            Dim C1y As Double
            Dim C1z As Double
            Dim C2x As Double
            Dim C2y As Double




            If (Not DA.GetData(Of String)(0, SubsoilName)) Then Return
            DA.GetData(Of String)(1, Description)
            DA.GetData(Of Double)(2, C1x)
            DA.GetData(Of Double)(3, C1y)
            DA.GetData(Of Double)(4, C1z)
            DA.GetData(Of Double)(5, C2x)
            DA.GetData(Of Double)(6, C2y)

            Dim FlatList As New List(Of System.Object)()
            'a hinge consists of: Beam name, ux, uy, uz, phix, phiy, phiz (0: free, 1: fixed), Position (Begin/End/Both)

            Dim item As String



            'create fixed supports on first & last nodes, fully fixed
            '=====================================
            FlatList.Clear()

            FlatList.Add(SubsoilName)
            FlatList.Add(Description)
            FlatList.Add(C1x * 1000000)
            FlatList.Add(C1y * 1000000)
            FlatList.Add(C1z * 1000000)
            FlatList.Add(C2x * 1000000)
            FlatList.Add(C2y * 1000000)



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
                Return My.Resources.SubSoil
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("92fa3ece-6d80-48ff-82a2-5d02cc0e2491")
            End Get
        End Property
    End Class

End Namespace