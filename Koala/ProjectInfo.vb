Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class ProjectInfo
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("ProjectInfo", "ProjectInfo",
                "Informations about project",
                "Koala", "General")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("Project name", "ProjectName", "Name of the project", GH_ParamAccess.item, "Project 1")
            pManager.AddTextParameter("Part", "Part", "Name of the project", GH_ParamAccess.item, "Project 1")
            pManager.Param(1).Optional = True
            pManager.AddTextParameter("Description", "Description", "Description", GH_ParamAccess.item, "Your description for project")
            pManager.Param(2).Optional = True
            pManager.AddTextParameter("Author", "Author", "Author of the project", GH_ParamAccess.item, "Your Name")
            pManager.Param(3).Optional = True
            pManager.AddTextParameter("Date", "Date", "Date", GH_ParamAccess.item, "02-01-2020")
            pManager.Param(4).Optional = True
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("Project", "Project", "Project", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim ProjectName As String = "ProjectInfo 1"
            Dim Part As String = "Project 1"
            Dim Description As String = " Version 1"
            Dim Author As String = "My name"
            Dim dateOfCreation As String = "01-02-2020"
            If (Not DA.GetData(Of String)(0, ProjectName)) Then Return
            DA.GetData(Of String)(1, Part)
            DA.GetData(Of String)(2, Description)
            DA.GetData(Of String)(3, Author)
            DA.GetData(Of String)(4, dateOfCreation)


            Dim FlatList As New List(Of System.Object)()


            FlatList.Clear()


            FlatList.Add(ProjectName)
            FlatList.Add(Part)
            FlatList.Add(Description)
            FlatList.Add(Author)
            FlatList.Add(dateOfCreation)


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
                Return My.Resources.ProjectInfo
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("413c8fc3-897e-47d3-ab39-5e86d465bd82")
            End Get
        End Property
    End Class

End Namespace