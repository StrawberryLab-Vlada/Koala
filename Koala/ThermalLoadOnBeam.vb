Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class ThermalLoadOnBeam
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("ThermalLoadOnBeam", "ThermalLoadOnBeam",
                "ThermalLoadOnBeam description",
                "Koala", "Load")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("LoadCase", "LoadCase", "Name of load case", GH_ParamAccess.item, "LC2")
            pManager.AddTextParameter("BeamList", "BeamList", "List of beam names where to apply load", GH_ParamAccess.list)
            pManager.AddIntegerParameter("Distribution", "Distribution", "Distribution: Constant - 0 or Linear - 1", GH_ParamAccess.item, 0)
            AddOptionsToMenuThermalDistribution(pManager.Param(2))
            pManager.AddNumberParameter("Delta", "Delta", "Delta", GH_ParamAccess.item, 1)
            pManager.AddNumberParameter("+z - Top delta", "+z - Top delta", "+z - Top delta", GH_ParamAccess.item, 1)
            pManager.AddNumberParameter("-z - Bottom delta", "-z - Bottom delta", "-z - Bottom delta", GH_ParamAccess.item, 1)
            pManager.AddNumberParameter("+y - Left delta", "+y - Left delta", "+z - Top delta", GH_ParamAccess.item, 1)
            pManager.AddNumberParameter("-y - Right delta", "-y - Right delta", "-z - Bottom delta", GH_ParamAccess.item, 1)
            pManager.AddIntegerParameter("CoordDefinition", "CoordDefinition", "CoordDefinition - Rela | Abso", GH_ParamAccess.item, 0)
            AddOptionsToMenuCoordDefinition(pManager.Param(8))
            pManager.AddNumberParameter("Position1", "Position1", "Start position of line load on beam", GH_ParamAccess.item, 0)
            pManager.AddNumberParameter("Position2", "Position2", "End position of loado n beam", GH_ParamAccess.item, 1)
            pManager.AddIntegerParameter("Origin", "Origin", "Origin of load: From start| From end", GH_ParamAccess.item, 0)
            AddOptionsToMenuOrigin(pManager.Param(11))

        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("ThermalBeamLoads", "ThermalBeamLoads", "", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim LoadCase As String = "LC2"
            Dim BeamList = New List(Of String)

            Dim Distribution As String = "Constant"
            Dim Delta As Double = -1.0
            Dim TopDelta As Double = -1.0
            Dim BottomDelta As Double = -1.0
            Dim RightDelta As Double = -1.0
            Dim LeftDelta As Double = -1.0
            Dim CoordDefinition As String = "Rela"
            Dim Origin As String = "From start"
            Dim Position1 As Double = 0.0
            Dim Position2 As Double = 1.0

            Dim i As Integer
            If (Not DA.GetData(0, LoadCase)) Then Return
            If (Not DA.GetDataList(Of String)(1, BeamList)) Then Return
            If (Not DA.GetData(2, i)) Then Return
            Distribution = GetStringFromMenuThermalDistribution(i)
            If (Not DA.GetData(3, Delta)) Then Return
            If (Not DA.GetData(4, TopDelta)) Then Return
            If (Not DA.GetData(5, BottomDelta)) Then Return
            If (Not DA.GetData(6, RightDelta)) Then Return
            If (Not DA.GetData(7, LeftDelta)) Then Return
            DA.GetData(8, i)
            CoordDefinition = GetStringFromCoordDefinition(i)
            DA.GetData(9, Position1)
            DA.GetData(10, Position2)
            DA.GetData(11, i)
            Origin = GetStringFromOrigin(i)




            Dim SE_surfloads(BeamList.Count, 11)
            Dim FlatList As New List(Of System.Object)()
            'a load consists of: load case, surface name, coord. system (GCS/LCS), direction (X, Y, Z), value (kN/m)

            Dim itemcount As Long
            Dim item As String

            'initialize some variables
            itemcount = 0

            'create load data
            '=================
            For Each item In BeamList
                SE_surfloads(itemcount, 0) = LoadCase
                SE_surfloads(itemcount, 1) = Strings.Trim(item)
                SE_surfloads(itemcount, 2) = Distribution
                SE_surfloads(itemcount, 3) = Delta
                SE_surfloads(itemcount, 4) = RightDelta
                SE_surfloads(itemcount, 5) = LeftDelta
                SE_surfloads(itemcount, 6) = TopDelta
                SE_surfloads(itemcount, 7) = BottomDelta
                SE_surfloads(itemcount, 8) = CoordDefinition
                SE_surfloads(itemcount, 9) = Position1
                SE_surfloads(itemcount, 10) = Position2
                SE_surfloads(itemcount, 11) = Origin
                itemcount += 1
            Next

            'Flatten data for export as simple list

            FlatList.Clear()

            For i = 0 To itemcount - 1
                FlatList.Add(SE_surfloads(i, 0))
                FlatList.Add(SE_surfloads(i, 1))
                FlatList.Add(SE_surfloads(i, 2))
                FlatList.Add(SE_surfloads(i, 3))
                FlatList.Add(SE_surfloads(i, 4))
                FlatList.Add(SE_surfloads(i, 5))
                FlatList.Add(SE_surfloads(i, 6))
                FlatList.Add(SE_surfloads(i, 7))
                FlatList.Add(SE_surfloads(i, 8))
                FlatList.Add(SE_surfloads(i, 9))
                FlatList.Add(SE_surfloads(i, 10))
                FlatList.Add(SE_surfloads(i, 11))
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
                Return My.Resources.ThermalLoadBeam

            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("f8cbd97f-e4da-4efc-8c5c-5015afbb421c")
            End Get
        End Property
    End Class

End Namespace