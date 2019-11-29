Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class SurfaceLoad
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("SurfaceLoad", "SurfaceLoad",
                "SurfaceLoad description",
                "Koala", "Load")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("LoadCase", "LoadCase", "Name of load case", GH_ParamAccess.item, "LC2")
            pManager.AddTextParameter("SurfList", "SurfList", "List of 2D member names where to apply load", GH_ParamAccess.list)
            pManager.AddTextParameter("CoordSys", "CoordSys", "Coordinate system: GCS - Length,GCS - Projection, LCS", GH_ParamAccess.item, "GCS - Length")
            pManager.AddTextParameter("Direction", "Direction", "Direction of load: X,Y,Z", GH_ParamAccess.item, "Z")
            pManager.AddNumberParameter("LoadValue", "LoadValue", "Value of Load in KN/m", GH_ParamAccess.item, -4)
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("Sloads", "Sloads", "", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)
            Dim LoadCase As String = "LC1"
            Dim SurfList = New List(Of String)
            Dim CoordSys As String = "GCS - Length"
            Dim Direction As String = "Z"
            Dim LoadValue As Double = -1.0

            If (Not DA.GetData(0, LoadCase)) Then Return
            If (Not DA.GetDataList(Of String)(1, SurfList)) Then Return
            If (Not DA.GetData(2, CoordSys)) Then Return
            If (Not DA.GetData(3, Direction)) Then Return
            If (Not DA.GetData(4, LoadValue)) Then Return





            Dim SE_surfloads(SurfList.Count, 4)
            Dim FlatList As New List(Of System.Object)()
            'a load consists of: load case, surface name, coord. system (GCS/LCS), direction (X, Y, Z), value (kN/m)

            Dim itemcount As Long
            Dim item As String

            'initialize some variables
            itemcount = 0

            'create load data
            '=================
            For Each item In SurfList
                SE_surfloads(itemcount, 0) = LoadCase
                SE_surfloads(itemcount, 1) = Strings.Trim(item)
                SE_surfloads(itemcount, 2) = CoordSys
                SE_surfloads(itemcount, 3) = Direction
                SE_surfloads(itemcount, 4) = LoadValue
                itemcount += 1
            Next

            'Flatten data for export as simple list

            FlatList.Clear()
            Dim i As Long
            For i = 0 To itemcount - 1
                FlatList.Add(SE_surfloads(i, 0))
                FlatList.Add(SE_surfloads(i, 1))
                FlatList.Add(SE_surfloads(i, 2))
                FlatList.Add(SE_surfloads(i, 3))
                FlatList.Add(SE_surfloads(i, 4))
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
                Return My.Resources.SurfaceLoad
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("d5946b9c-fd5c-4d13-ba02-b0dbe6da9334")
            End Get
        End Property
    End Class

End Namespace