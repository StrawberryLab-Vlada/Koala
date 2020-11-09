Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class LineMomentOnBeam
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("LineMomentOnBeam", "LineMomentOnBeam",
                "LineMomentOnBeam description",
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
            pManager.AddIntegerParameter("Direction", "Direction", "Direction of load: Mx,My,Mz", GH_ParamAccess.item, 2)
            AddOptionsToMenuDirectionMoment(pManager.Param(3))
            pManager.AddIntegerParameter("Distribution", "Distribution", "Distribution of the load: Uniform | Trapez", GH_ParamAccess.item, 0)
            AddOptionsToMenuDistributionOfLoad(pManager.Param(4))
            pManager.AddNumberParameter("LoadValue1", "LoadValue1", "Value of Load in KNm/m", GH_ParamAccess.item, -1)
            pManager.AddNumberParameter("LoadValue2", "LoadValue2", "Value of Load in KNm/m", GH_ParamAccess.item, -1)
            pManager.AddIntegerParameter("CoordDefinition", "CoordDefinition", "CoordDefinition - Rela | Abso", GH_ParamAccess.item, 0)
            AddOptionsToMenuCoordDefinition(pManager.Param(7))
            pManager.AddNumberParameter("Position1", "Position1", "Start position of line load on beam", GH_ParamAccess.item, 0)
            pManager.AddNumberParameter("Position2", "Position2", "End position of loado n beam", GH_ParamAccess.item, 1)
            pManager.AddIntegerParameter("Origin", "Origin", "Origin of load: From start| From end", GH_ParamAccess.item, 0)
            AddOptionsToMenuOrigin(pManager.Param(10))

        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("LineMomentBeam", "LineMomentBeam", "Defined line moments on beams", GH_ParamAccess.list)
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
            Dim Direction As String = "Mz"
            Dim LoadValue1 As Double = -1.0
            Dim LoadValue2 As Double = -1.0
            Dim Distribution As String = "Uniform"
            Dim CoordDefinition As String = "Rela"
            Dim Position1 As Double = 0.0
            Dim Position2 As Double = 1.0
            Dim Origin As String = "From start"

            Dim i As Integer


            If (Not DA.GetData(0, LoadCase)) Then Return
            If (Not DA.GetDataList(Of String)(1, BeamList)) Then Return
            If (Not DA.GetData(2, i)) Then Return
            CoordSys = GetStringFromCoordSysPoint(i)
            If (Not DA.GetData(3, i)) Then Return
            Direction = GetStringFromDirectionMoment(i)
            If (Not DA.GetData(4, i)) Then Return
            Distribution = GetStringFromDistributionOfLoad(i)
            If (Not DA.GetData(5, LoadValue1)) Then Return
            Select Case Distribution
                Case "Uniform"
                    LoadValue2 = LoadValue1
                Case "Trapez"
                    DA.GetData(6, LoadValue2)
            End Select
            DA.GetData(7, i)
            CoordDefinition = GetStringFromCoordDefinition(i)
            DA.GetData(8, Position1)
            DA.GetData(9, Position2)
            DA.GetData(10, i)
            Origin = GetStringFromOrigin(i)



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
                SE_loads(itemcount, 4) = Distribution
                SE_loads(itemcount, 5) = LoadValue1
                SE_loads(itemcount, 6) = LoadValue2
                SE_loads(itemcount, 7) = CoordDefinition
                SE_loads(itemcount, 8) = Position1
                SE_loads(itemcount, 9) = Position2
                SE_loads(itemcount, 10) = Origin
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
                Return My.Resources.BeamLineMoment

            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("8060f27e-0590-44e9-b2eb-c8a5ac6b43a1")
            End Get
        End Property
    End Class

End Namespace