Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class LineHinge
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("LineHinge", "LineHinge",
                "LineHinge description",
                "Koala", "Structure")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("2DMemberEdgeList", "2DMemberEdgeList", "List of 2DMembers and their edges names where to apply line hinge:S1;3", GH_ParamAccess.list)
            pManager.AddIntegerParameter("CoordDefinition", "CoordDefinition", "CoordDefinition - Rela | Abso", GH_ParamAccess.item, 0)
            AddOptionsToMenuCoordDefinition(pManager.Param(1))
            pManager.AddNumberParameter("Position1", "Position1", "Start position of line load on beam", GH_ParamAccess.item, 0)
            pManager.AddNumberParameter("Position2", "Position2", "End position of loado n beam", GH_ParamAccess.item, 1)
            pManager.AddIntegerParameter("Origin", "Origin", "Origin of load: From start| From end", GH_ParamAccess.item, 0)
            AddOptionsToMenuOrigin(pManager.Param(4))
            pManager.AddIntegerParameter("Rx", "Rx", "Rotation around X axis, Right click and select from options", GH_ParamAccess.item, 1)
            AddOptionstoMenuDOFRotation(pManager.Param(5))
            pManager.AddIntegerParameter("Tx", "Tx", "Translation in X axis, Right click and select from options", GH_ParamAccess.item, 1)
            AddOptionstoMenuDOFRotation(pManager.Param(6))
            pManager.AddIntegerParameter("Ty", "Ty", "Translation in Y axis, Right click and select from options", GH_ParamAccess.item, 1)
            AddOptionstoMenuDOFRotation(pManager.Param(7))
            pManager.AddIntegerParameter("Tz", "Tz", "Translation in Z axis, Right click and select from options", GH_ParamAccess.item, 1)
            AddOptionstoMenuDOFRotation(pManager.Param(8))
            pManager.AddNumberParameter("StiffnessRx", "StiffnessRx", "Stiffness for Rx", GH_ParamAccess.item, 0.0)
            pManager.AddNumberParameter("StiffnessTx", "StiffnessTx", "Stiffness for Tx", GH_ParamAccess.item, 0.0)
            pManager.AddNumberParameter("StiffnessTy", "StiffnessTy", "Stiffness for Ty", GH_ParamAccess.item, 0.0)
            pManager.AddNumberParameter("StiffnessTz", "StiffnessTz", "Stiffness for Tz", GH_ParamAccess.item, 0.0)
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("lineHinges", "lineHinges", "", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim SurfEdgeList = New List(Of String)

            Dim Rx As Integer
            Dim Tx As Integer
            Dim Ty As Integer
            Dim Tz As Integer
            Dim RxStiffness As Double
            Dim TxStiffness As Double
            Dim TyStiffness As Double
            Dim TzStiffness As Double
            Dim i As Integer





            Dim CoordDefinition As String = "Rela"
            Dim Position1 As Double = 0.0
            Dim Position2 As Double = 1.0
            Dim Origin As String = "From start"

            If (Not DA.GetDataList(Of String)(0, SurfEdgeList)) Then Return
            DA.GetData(1, i)
            CoordDefinition = GetStringFromCoordDefinition(i)
            DA.GetData(2, Position1)
            DA.GetData(3, Position2)
            DA.GetData(4, i)
            Origin = GetStringFromOrigin(i)
            DA.GetData(Of Integer)(5, Tx)
            DA.GetData(Of Integer)(6, Ty)
            DA.GetData(Of Integer)(7, Tz)
            DA.GetData(Of Integer)(8, Rx)
            DA.GetData(Of Double)(9, TxStiffness)
            DA.GetData(Of Double)(10, TyStiffness)
            DA.GetData(Of Double)(11, TzStiffness)
            DA.GetData(Of Double)(12, RxStiffness)

            Dim SE_LineHinges(SurfEdgeList.Count, 13)
            Dim FlatList As New List(Of System.Object)()
            'a hinge consists of: Beam name, ux, uy, uz, phix, phiy, phiz (0: free, 1: fixed), Position (Begin/End/Both)
            Dim itemcount As Integer = 0
            For Each item In SurfEdgeList
                SE_LineHinges(itemcount, 0) = item.Split(";")(0)
                SE_LineHinges(itemcount, 1) = item.Split(";")(1)
                SE_LineHinges(itemcount, 2) = CoordDefinition
                SE_LineHinges(itemcount, 3) = Position1
                SE_LineHinges(itemcount, 4) = Position2
                SE_LineHinges(itemcount, 5) = Origin
                SE_LineHinges(itemcount, 6) = Tx
                SE_LineHinges(itemcount, 7) = Ty
                SE_LineHinges(itemcount, 8) = Tz
                SE_LineHinges(itemcount, 9) = Rx
                SE_LineHinges(itemcount, 10) = TxStiffness
                SE_LineHinges(itemcount, 11) = TyStiffness
                SE_LineHinges(itemcount, 12) = TzStiffness
                SE_LineHinges(itemcount, 13) = RxStiffness
                itemcount += 1
            Next
            FlatList.Clear()

            For i = 0 To itemcount - 1
                FlatList.Add(SE_LineHinges(i, 0))
                FlatList.Add(SE_LineHinges(i, 1))
                FlatList.Add(SE_LineHinges(i, 2))
                FlatList.Add(SE_LineHinges(i, 3))
                FlatList.Add(SE_LineHinges(i, 4))
                FlatList.Add(SE_LineHinges(i, 5))
                FlatList.Add(SE_LineHinges(i, 6))
                FlatList.Add(SE_LineHinges(i, 7))
                FlatList.Add(SE_LineHinges(i, 8))
                FlatList.Add(SE_LineHinges(i, 9))
                FlatList.Add(SE_LineHinges(i, 10))
                FlatList.Add(SE_LineHinges(i, 11))
                FlatList.Add(SE_LineHinges(i, 12))
                FlatList.Add(SE_LineHinges(i, 13))
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
                Return My.Resources.LineHinge

            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("cc3e2e3f-2fca-4b77-aae1-09da921bf7aa")
            End Get
        End Property
    End Class

End Namespace