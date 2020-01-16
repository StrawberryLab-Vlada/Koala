Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class Hinges
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("Hinges", "Hinges",
                "Hinges description",
                "Koala", "Structure")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("ListofBeams", "ListofBeams", "List of beams where to apply hinges", GH_ParamAccess.list)
            pManager.AddIntegerParameter("Position", "Position", "Position of the hinge", GH_ParamAccess.item, 2)
            AddOptionsToMenuHingePosition(pManager.Param(1))
            pManager.AddIntegerParameter("Rx", "Rx", "Rotation around X axis, Right click and select from options", GH_ParamAccess.item, 0)
            AddOptionstoMenuDOFRotation(pManager.Param(2))
            pManager.AddIntegerParameter("Ry", "Ry", "Rotation around y axis, Right click and select from options", GH_ParamAccess.item, 0)
            AddOptionstoMenuDOFRotation(pManager.Param(3))
            pManager.AddIntegerParameter("Rz", "Rz", "Rotation around X axis, Right click and select from options", GH_ParamAccess.item, 0)
            AddOptionstoMenuDOFRotation(pManager.Param(4))
            pManager.AddIntegerParameter("Tx", "Tx", "Translation in X axis, Right click and select from options", GH_ParamAccess.item, 0)
            AddOptionstoMenuDOFRotation(pManager.Param(5))
            pManager.AddIntegerParameter("Ty", "Ty", "Translation in Y axis, Right click and select from options", GH_ParamAccess.item, 0)
            AddOptionstoMenuDOFRotation(pManager.Param(6))
            pManager.AddIntegerParameter("Tz", "Tz", "Translation in Z axis, Right click and select from options", GH_ParamAccess.item, 0)
            AddOptionstoMenuDOFRotation(pManager.Param(7))
            pManager.AddNumberParameter("StiffnessRx", "StiffnessRx", "Stiffness for Rx", GH_ParamAccess.item, 0.0)
            pManager.AddNumberParameter("StiffnessRy", "StiffnessRy", "Stiffness for Ry", GH_ParamAccess.item, 0.0)
            pManager.AddNumberParameter("StiffnessRz", "StiffnessRz", "Stiffness for Rz", GH_ParamAccess.item, 0.0)
            pManager.AddNumberParameter("StiffnessRx", "StiffnessTx", "Stiffness for Tx", GH_ParamAccess.item, 0.0)
            pManager.AddNumberParameter("StiffnessTy", "StiffnessTy", "Stiffness for Ty", GH_ParamAccess.item, 0.0)
            pManager.AddNumberParameter("StiffnessTz", "StiffnessTz", "Stiffness for Tz", GH_ParamAccess.item, 0.0)

        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("Hinges", "Hinges", "", GH_ParamAccess.list)

        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim Hinges = New List(Of String)
            Dim Position As String = "Both"
            Dim Rx As Integer
            Dim Ry As Integer
            Dim Rz As Integer
            Dim Tx As Integer
            Dim Ty As Integer
            Dim Tz As Integer
            Dim RxStiffness As Double
            Dim RyStiffness As Double
            Dim RzStiffness As Double
            Dim TxStiffness As Double
            Dim TyStiffness As Double
            Dim TzStiffness As Double
            Dim i As Integer

            If (Not DA.GetDataList(Of String)(0, Hinges)) Then Return
            DA.GetData(Of Integer)(1, i)
            Position = GetStringFromHingePosition(i)
            DA.GetData(Of Integer)(2, Tx)
            DA.GetData(Of Integer)(3, Ty)
            DA.GetData(Of Integer)(4, Tz)
            DA.GetData(Of Integer)(5, Rx)
            DA.GetData(Of Integer)(6, Ry)
            DA.GetData(Of Integer)(7, Rz)
            DA.GetData(Of Double)(8, TxStiffness)
            DA.GetData(Of Double)(9, TyStiffness)
            DA.GetData(Of Double)(10, TzStiffness)
            DA.GetData(Of Double)(11, RxStiffness)
            DA.GetData(Of Double)(12, RyStiffness)
            DA.GetData(Of Double)(13, RzStiffness)
            Dim SE_hinges(Hinges.Count, 7)
            Dim FlatList As New List(Of System.Object)()
            'a hinge consists of: Beam name, ux, uy, uz, phix, phiy, phiz (0: free, 1: fixed), Position (Begin/End/Both)

            Dim item As String
            Dim itemcount As Long


            'create fixed supports on first & last nodes, fully fixed
            '=====================================
            FlatList.Clear()
            For Each item In Hinges
                FlatList.Add(item)
                FlatList.Add(Position)
                FlatList.Add(Rx)
                FlatList.Add(Ry)
                FlatList.Add(Rz)
                FlatList.Add(Tx)
                FlatList.Add(Ty)
                FlatList.Add(Tz)
                FlatList.Add(RxStiffness)
                FlatList.Add(RyStiffness)
                FlatList.Add(RzStiffness)
                FlatList.Add(TxStiffness)
                FlatList.Add(TyStiffness)
                FlatList.Add(TzStiffness)
            Next

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
                Return My.Resources.Hinge
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("18356149-2e03-4367-ae9e-cd45ba0070f6")
            End Get
        End Property
    End Class

End Namespace