Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class BeamSupport
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("BeamSupport", "BeamSupport",
                "BeamSupport description",
                 "Koala", "Structure")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("ListOfBeams", "ListOfBeams", "Definition of Beams where support is placed", GH_ParamAccess.list)
            pManager.AddIntegerParameter("Rx", "Rx", "Rotation around X axis, Right click and select from options", GH_ParamAccess.item, 1)
            AddOptionstoMenuDOFRotation(pManager.Param(1))
            pManager.AddIntegerParameter("Ry", "Ry", "Rotation around y axis, Right click and select from options", GH_ParamAccess.item, 1)
            AddOptionstoMenuDOFRotation(pManager.Param(2))
            pManager.AddIntegerParameter("Rz", "Rz", "Rotation around X axis, Right click and select from options", GH_ParamAccess.item, 1)
            AddOptionstoMenuDOFRotation(pManager.Param(3))
            pManager.AddIntegerParameter("Tx", "Tx", "Translation in X axis, Right click and select from options", GH_ParamAccess.item, 1)
            AddOptionstoMenuDOFTransition(pManager.Param(4))
            pManager.AddIntegerParameter("Ty", "Ty", "Translation in Y axis, Right click and select from options", GH_ParamAccess.item, 1)
            AddOptionstoMenuDOFTransition(pManager.Param(5))
            pManager.AddIntegerParameter("Tz", "Tz", "Translation in Z axis, Right click and select from options", GH_ParamAccess.item, 1)
            AddOptionstoMenuDOFTransition(pManager.Param(6))
            pManager.AddNumberParameter("StiffnessRx", "StiffnessRx", "Stiffness for Rx in MNm/m/rad", GH_ParamAccess.item, 0.0)
            pManager.AddNumberParameter("StiffnessRy", "StiffnessRy", "Stiffness for Ry in MNm/m/rad", GH_ParamAccess.item, 0.0)
            pManager.AddNumberParameter("StiffnessRz", "StiffnessRz", "Stiffness for Rz in MNm/m/rad", GH_ParamAccess.item, 0.0)
            pManager.AddNumberParameter("StiffnessRx", "StiffnessTx", "Stiffness for Tx in MN/m^2", GH_ParamAccess.item, 0.0)
            pManager.AddNumberParameter("StiffnessTy", "StiffnessTy", "Stiffness for Ty in MN/m^2", GH_ParamAccess.item, 0.0)
            pManager.AddNumberParameter("StiffnessTz", "StiffnessTz", "Stiffness for Tz in MN/m^2", GH_ParamAccess.item, 0.0)
            pManager.AddIntegerParameter("CoordDefinition", "CoordDefinition", "CoordDefinition - Rela | Abso", GH_ParamAccess.item, 0)
            AddOptionsToMenuCoordDefinition(pManager.Param(13))
            pManager.AddNumberParameter("Position1", "Position1", "Start position of support on edge", GH_ParamAccess.item, 0)
            pManager.AddNumberParameter("Position2", "Position2", "End position of support on edge", GH_ParamAccess.item, 1)
            pManager.AddIntegerParameter("Origin", "Origin", "Origin of load: From start| From end", GH_ParamAccess.item, 0)
            AddOptionsToMenuOrigin(pManager.Param(16))
            pManager.AddTextParameter("FunctionRx", "FunctionRx", "Stiffness for Rx in MNm/rad", GH_ParamAccess.item, "")
            pManager.AddTextParameter("FunctionRy", "FunctionRy", "Stiffness for Ry in MNm/rad", GH_ParamAccess.item, "")
            pManager.AddTextParameter("FunctionRz", "FunctionRz", "Stiffness for Rz in MNm/rad", GH_ParamAccess.item, "")
            pManager.AddTextParameter("FunctionTx", "FunctionTx", "Stiffness for Tx in MNm", GH_ParamAccess.item, "")
            pManager.AddTextParameter("FunctionTy", "FunctionTy", "Stiffness for Ty in MNm", GH_ParamAccess.item, "")
            pManager.AddTextParameter("FunctionTz", "FunctionTz", "Stiffness for Tz in MNm", GH_ParamAccess.item, "")
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("BeamSupports", "BeamSupports", "", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)
            Dim BeamSupports = New List(Of String)


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
            Dim CoordDefinition As String = "Rela"
            Dim Position1 As Double = 0.0
            Dim Position2 As Double = 1.0
            Dim Origin As String = "From start"
            Dim i As Integer
            Dim RxFunction As String = ""
            Dim RyFunction As String = ""
            Dim RzFunction As String = ""
            Dim TxFunction As String = ""
            Dim TyFunction As String = ""
            Dim TzFunction As String = ""


            If (Not DA.GetDataList(Of String)(0, BeamSupports)) Then Return

            DA.GetData(Of Integer)(1, Rx)
            DA.GetData(Of Integer)(2, Ry)
            DA.GetData(Of Integer)(3, Rz)
            DA.GetData(Of Integer)(4, Tx)
            DA.GetData(Of Integer)(5, Ty)
            DA.GetData(Of Integer)(6, Tz)
            DA.GetData(Of Double)(7, RxStiffness)
            DA.GetData(Of Double)(8, RyStiffness)
            DA.GetData(Of Double)(9, RzStiffness)
            DA.GetData(Of Double)(10, TxStiffness)
            DA.GetData(Of Double)(11, TyStiffness)
            DA.GetData(Of Double)(12, TzStiffness)
            DA.GetData(13, i)
            CoordDefinition = GetStringFromCoordDefinition(i)
            DA.GetData(14, Position1)
            DA.GetData(15, Position2)
            DA.GetData(16, i)
            Origin = GetStringFromOrigin(i)
            DA.GetData(Of String)(17, RxFunction)
            DA.GetData(Of String)(18, RyFunction)
            DA.GetData(Of String)(19, RzFunction)
            DA.GetData(Of String)(20, TxFunction)
            DA.GetData(Of String)(21, TyFunction)
            DA.GetData(Of String)(22, TzFunction)

            Dim FlatList As New List(Of System.Object)()
            'a support consists of: Reference name, reference type, edge number, X, Y, Z, RX, RY, RZ - 0 is free, 1 is blocked DOF



            Dim item As String

            'Flatten data for export as simple list
            FlatList.Clear()
            For Each item In BeamSupports


                FlatList.Add(item)
                FlatList.Add(Tx)
                FlatList.Add(Ty)
                FlatList.Add(Tz)
                FlatList.Add(Rx)
                FlatList.Add(Ry)
                FlatList.Add(Rz)
                FlatList.Add(TxStiffness * 1000000.0)
                FlatList.Add(TyStiffness * 1000000.0)
                FlatList.Add(TzStiffness * 1000000.0)
                FlatList.Add(RxStiffness * 1000000.0)
                FlatList.Add(RyStiffness * 1000000.0)
                FlatList.Add(RzStiffness * 1000000.0)
                FlatList.Add(CoordDefinition)
                FlatList.Add(Position1)
                FlatList.Add(Position2)
                FlatList.Add(Origin)
                FlatList.Add(TxFunction)
                FlatList.Add(TyFunction)
                FlatList.Add(TzFunction)
                FlatList.Add(RxFunction)
                FlatList.Add(RyFunction)
                FlatList.Add(RzFunction)
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
                Return My.Resources.BeamLineSupport

            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("28dee2ad-8fd4-4bec-ac7b-149887db523a")
            End Get
        End Property
    End Class

End Namespace