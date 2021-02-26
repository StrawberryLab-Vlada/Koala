Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class ThermalLoadOnSurface
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("ThermalLoadOnSurface", "ThermalLoadOnSurface",
                "ThermalLoadOnSurface description",
                "Koala", "Load")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("LoadCase", "LoadCase", "Name of load case", GH_ParamAccess.item, "LC2")
            pManager.AddTextParameter("SurfList", "SurfList", "List of 2D member names where to apply load", GH_ParamAccess.list)
            pManager.AddIntegerParameter("Distribution", "Distribution", "Distribution: Constant - 0 or Linear - 1", GH_ParamAccess.item, 0)
            AddOptionsToMenuThermalDistribution(pManager.Param(2))
            pManager.AddNumberParameter("Delta", "Delta", "Delta", GH_ParamAccess.item, 1)
            pManager.AddNumberParameter("+z - Top delta", "+z - Top delta", "+z - Top delta", GH_ParamAccess.item, 1)
            pManager.AddNumberParameter("-z - Bottom delta", "-z - Bottom delta", "-z - Bottom delta", GH_ParamAccess.item, 2)
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("ThermalSurfaceLoads", "ThermalSurfaceLoads", "", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)
            Dim LoadCase As String = "LC2"
            Dim SurfList = New List(Of String)

            Dim Distribution As String = "Constant"
            Dim Delta As Double = -1.0
            Dim TopDelta As Double = -1.0
            Dim BottomDelta As Double = -1.0

            Dim i As Integer
            If (Not DA.GetData(0, LoadCase)) Then Return
            If (Not DA.GetDataList(Of String)(1, SurfList)) Then Return
            If (Not DA.GetData(2, i)) Then Return
            Distribution = GetStringFromMenuThermalDistribution(i)
            If (Not DA.GetData(3, Delta)) Then Return
            If (Not DA.GetData(4, TopDelta)) Then Return
            If (Not DA.GetData(5, BottomDelta)) Then Return





            Dim SE_surfloads(SurfList.Count, 5)
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
                SE_surfloads(itemcount, 2) = Distribution
                SE_surfloads(itemcount, 3) = Delta
                SE_surfloads(itemcount, 4) = TopDelta
                SE_surfloads(itemcount, 5) = BottomDelta
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
                Return My.Resources.ThermalLoadSurface
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("8df86d5c-85a3-4302-9f69-ceb3fe6614e9")
            End Get
        End Property
    End Class

End Namespace