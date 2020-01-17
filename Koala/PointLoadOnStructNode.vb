Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class PointLoadOnStructNode
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("PointLoadOnStructNode", "PointLoadOnStructNode",
                "PointLoadOnStructNode description",
                "Koala", "Load")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("LoadCase", "LoadCase", "Name of load case", GH_ParamAccess.item, "LC2")
            pManager.AddTextParameter("NodeList", "NodeList", "List of beam names where to apply load", GH_ParamAccess.list)
            pManager.AddIntegerParameter("CoordSys", "CoordSys", "Coordinate system: GCS or LCS", GH_ParamAccess.item, 0)
            AddOptionsToMenuCoordSysPoint(pManager.Param(2))
            pManager.AddIntegerParameter("Direction", "Direction", "Direction of load: X,Y,Z", GH_ParamAccess.item, 2)
            AddOptionsToMenuDirection(pManager.Param(3))
            pManager.AddNumberParameter("LoadValue", "LoadValue", "Value of Load in KN", GH_ParamAccess.item, -1)
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("ploadsN", "ploads", "", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim LoadCase As String = "LC"
            Dim NodeList = New List(Of String)
            Dim CoordSys As String = "GCS"
            Dim Direction As String = "Z"
            Dim LoadValue As Double = -1.0
            Dim i As Integer


            If (Not DA.GetData(0, LoadCase)) Then Return
            If (Not DA.GetDataList(Of String)(1, NodeList)) Then Return
            If (Not DA.GetData(2, i)) Then Return
            CoordSys = GetStringFromCoordSysPoint(i)
            If (Not DA.GetData(3, i)) Then Return
            Direction = GetStringFromDirection(i)
            If (Not DA.GetData(4, LoadValue)) Then Return


            Dim SE_loads(NodeList.Count, 5)
            Dim FlatList As New List(Of System.Object)()
            'a load consists of: load case, Beam name, coord. system (GCS/LCS), direction (X, Y, Z), value (kN/m)

            Dim itemcount As Long
            Dim item As String

            'initialize some variables
            itemcount = 0

            'create load data
            '=================
            For Each item In NodeList
                SE_loads(itemcount, 0) = LoadCase
                SE_loads(itemcount, 1) = Strings.Trim(item)
                SE_loads(itemcount, 2) = CoordSys
                SE_loads(itemcount, 3) = Direction
                SE_loads(itemcount, 4) = LoadValue
                itemcount += 1
            Next

            'Flatten data for export as simple list

            FlatList.Clear()

            For i = 0 To itemcount - 1
                FlatList.Add(SE_loads(i, 0))
                FlatList.Add(SE_loads(i, 1))
                FlatList.Add(SE_loads(i, 2))
                FlatList.Add(SE_loads(i, 3))
                FlatList.Add(SE_loads(i, 4))
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
                Return My.Resources.PointLoadPoint
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("66299941-baeb-4fc2-a53e-36b333731a25")
            End Get
        End Property
    End Class

End Namespace