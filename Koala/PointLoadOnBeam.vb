Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class PointLoadOnBeam
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("PointLoadOnBeam", "PointLoadOnBeam",
                "PointLoadOnBeam description",
                "Koala", "Load")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("LoadCase", "LoadCase", "Name of load case", GH_ParamAccess.item, "LC2")
            pManager.AddTextParameter("BeamList", "BeamList", "List of beam names where to apply load", GH_ParamAccess.list)
            pManager.AddIntegerParameter("CoordSys", "CoordSys", "Coordinate system: GCS or LCS", GH_ParamAccess.item, 0)
            AddOptionsToMenuCoordSysPoint(pManager.Param(2))
            pManager.AddIntegerParameter("Direction", "Direction", "Direction of load: X,Y,Z", GH_ParamAccess.item, 2)
            AddOptionsToMenuDirection(pManager.Param(3))
            pManager.AddIntegerParameter("LoadValue", "LoadValue", "Value of Load in KN", GH_ParamAccess.item, -1)
            pManager.AddIntegerParameter("CoordDefinition", "CoordDefinition", "CoordDefinition - Rela | Abso", GH_ParamAccess.item, 0)
            AddOptionsToMenuCoordDefinition(pManager.Param(5))
            pManager.AddNumberParameter("Position", "Position", "Position of load on beam", GH_ParamAccess.item, 0.5)
            pManager.AddIntegerParameter("Origin", "Origin", "Origin of load: From start| From end", GH_ParamAccess.item, 0)
            AddOptionsToMenuOrigin(pManager.Param(7))
            pManager.AddIntegerParameter("Repeat", "Repeat", "Repeat", GH_ParamAccess.item, 1)
            pManager.AddNumberParameter("ey", "ey", "Eccentricity of load in y axis", GH_ParamAccess.item, 0)
            pManager.AddNumberParameter("ez", "ez", "Eccentricity of load in z axis", GH_ParamAccess.item, 0)
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("ploadsB", "ploadsB", "", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)
            Dim LoadCase As String = "LC"
            Dim BeamList = New List(Of String)
            Dim CoordSys As String = "GCS"
            Dim Direction As String = "Z"
            Dim LoadValue As Double = -1.0
            Dim CoordDefinition As String = "Rela"
            Dim Position As Double = 0.5
            Dim Origin As String = "From start"
            Dim Repeat As Long = 1
            Dim ey As Double = 0.0
            Dim ez As Double = 0.0
            Dim i As Integer

            If (Not DA.GetData(Of String)(0, LoadCase)) Then Return
            If (Not DA.GetDataList(Of String)(1, BeamList)) Then Return
            If (Not DA.GetData(Of Integer)(2, i)) Then Return
            CoordSys = GetStringFromCoordSysPoint(i)
            If (Not DA.GetData(Of Integer)(3, i)) Then Return
            Direction = GetStringFromDirection(i)
            If (Not DA.GetData(Of Double)(4, LoadValue)) Then Return
            DA.GetData(Of Integer)(5, i)
            CoordDefinition = GetStringFromCoordDefinition(i)
            DA.GetData(Of Double)(6, Position)
            DA.GetData(Of Integer)(7, i)
            Origin = GetStringFromOrigin(i)
            DA.GetData(Of Long)(8, Repeat)
            DA.GetData(Of Double)(9, ey)
            DA.GetData(Of Double)(10, ez)



            Dim SE_loads(BeamList.Count, 11)
            Dim FlatList As New List(Of System.Object)()
            'a load consists of: load case, Beam name, coord. system (GCS/LCS), direction (X, Y, Z), value (kN/m)

            Dim itemcount As Long
            Dim item As String

            'initialize some variables
            itemcount = 0

            'create load data
            '=================
            For Each item In BeamList
                SE_loads(itemcount, 0) = LoadCase
                SE_loads(itemcount, 1) = Strings.Trim(item)
                SE_loads(itemcount, 2) = CoordSys
                SE_loads(itemcount, 3) = Direction
                SE_loads(itemcount, 4) = LoadValue
                SE_loads(itemcount, 5) = CoordDefinition
                SE_loads(itemcount, 6) = Position
                SE_loads(itemcount, 7) = Origin
                SE_loads(itemcount, 8) = Repeat
                SE_loads(itemcount, 9) = ey
                SE_loads(itemcount, 10) = ez
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
                FlatList.Add(SE_loads(i, 5))
                FlatList.Add(SE_loads(i, 6))
                FlatList.Add(SE_loads(i, 7))
                FlatList.Add(SE_loads(i, 8))
                FlatList.Add(SE_loads(i, 9))
                FlatList.Add(SE_loads(i, 10))
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
                Return My.Resources.PointLoadBeam
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("c27815ae-4a75-46ef-821d-144874c164cc")
            End Get
        End Property
    End Class

End Namespace