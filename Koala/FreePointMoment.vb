Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class FreePointMoment
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("FreePointMoment", "FreePointMoment",
                "FreePointMoment description",
                "Koala", "Load")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("LoadCase", "LoadCase", "Name of load case", GH_ParamAccess.item, "LC2")
            pManager.AddIntegerParameter("Validity", "Validity", "Validity: All,Z equals 0", GH_ParamAccess.item, 0)
            AddOptionsToMenuValidity(pManager.Param(1))
            pManager.AddTextParameter("Selection", "Selection", "Selection: All", GH_ParamAccess.item, "All")
            pManager.AddIntegerParameter("CoordSys", "CoordSys", "Coordinate system: GCS or Member LCS", GH_ParamAccess.item, 4)
            AddOptionsToMenuCoordSysFreePoint(pManager.Param(3))
            pManager.AddIntegerParameter("Direction", "Direction", "Direction of load: Mx,My,Mz", GH_ParamAccess.item, 0)
            AddOptionsToMenuDirectionMoment(pManager.Param(4))
            pManager.AddNumberParameter("LoadValue", "LoadValue", "Value of Load in KNm", GH_ParamAccess.item, -1)
            pManager.AddPointParameter("Points", "Points", "List of points", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("FreeMomentPointloads", "FreeMomentPointloads", "Defined free moments in points", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)
            Dim LoadCase As String = ""
            Dim Validity As String = ""
            Dim Selection As String = ""
            Dim CoordSys As String = ""
            Dim Direction As String = ""
            Dim LoadValue As Double = -1.0
            Dim Points = New List(Of Point3d)
            Dim i As Integer
            If (Not DA.GetData(0, LoadCase)) Then Return
            If (Not DA.GetData(1, i)) Then Return
            Validity = GetStringFromuValidity(i)
            If (Not DA.GetData(2, Selection)) Then Return
            If (Not DA.GetData(3, i)) Then Return
            CoordSys = GetStringFromCoordSysLine(i)
            If (Not DA.GetData(4, i)) Then Return
            Direction = GetStringFromDirectionMoment(i)
            If (Not DA.GetData(5, LoadValue)) Then Return
            If (Not DA.GetDataList(Of Point3d)(6, Points)) Then Return


            Dim j As Long

            Dim SE_fploads(Points.Count, 8)
            Dim FlatList As New List(Of System.Object)()
            'a load consists of: load case, validity, selection, coord. system (GCS/LCS), direction (X, Y, Z), value (kN/m), X, Y, Z

            Dim itemcount As Long
            Dim item As Rhino.Geometry.Point3d

            'initialize some variables
            itemcount = 0

            'create load data
            '=================
            For Each item In Points
                SE_fploads(itemcount, 0) = LoadCase
                SE_fploads(itemcount, 1) = Validity
                SE_fploads(itemcount, 2) = Selection
                SE_fploads(itemcount, 3) = CoordSys
                SE_fploads(itemcount, 4) = Direction
                SE_fploads(itemcount, 5) = LoadValue
                SE_fploads(itemcount, 6) = item.X
                SE_fploads(itemcount, 7) = item.Y
                SE_fploads(itemcount, 8) = item.Z
                itemcount = itemcount + 1
            Next

            'Flatten data for export as simple list

            FlatList.Clear()

            For i = 0 To itemcount - 1
                For j = 0 To 8
                    FlatList.Add(SE_fploads(i, j))
                Next j
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
                Return My.Resources.FreePointMoment
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("190bab7f-0553-497c-b710-4ef6e28a6ffa")
            End Get
        End Property
    End Class

End Namespace