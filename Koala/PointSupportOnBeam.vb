Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class PointSupportOnBeam
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("PointSupportOnBeam", "PointSupportOnBeam",
                "PointSupportOnBeam description",
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
            pManager.AddNumberParameter("StiffnessRx", "StiffnessRx", "Stiffness for Rx in MNm/rad", GH_ParamAccess.item, 0.0)
            pManager.AddNumberParameter("StiffnessRy", "StiffnessRy", "Stiffness for Ry in MNm/rad", GH_ParamAccess.item, 0.0)
            pManager.AddNumberParameter("StiffnessRz", "StiffnessRz", "Stiffness for Rz in MNm/rad", GH_ParamAccess.item, 0.0)
            pManager.AddNumberParameter("StiffnessRx", "StiffnessTx", "Stiffness for Tx in MNm", GH_ParamAccess.item, 0.0)
            pManager.AddNumberParameter("StiffnessTy", "StiffnessTy", "Stiffness for Ty in MNm", GH_ParamAccess.item, 0.0)
            pManager.AddNumberParameter("StiffnessTz", "StiffnessTz", "Stiffness for Tz in MNm", GH_ParamAccess.item, 0.0)
            pManager.AddIntegerParameter("CoordDefinition", "CoordDefinition", "CoordDefinition - Rela | Abso", GH_ParamAccess.item, 0)
            AddOptionsToMenuCoordDefinition(pManager.Param(13))
            pManager.AddNumberParameter("PositionX", "Positionx", "Start position of support on edge", GH_ParamAccess.item, 0.5)
            pManager.AddIntegerParameter("Origin", "Origin", "Origin of load: From start| From end", GH_ParamAccess.item, 0)
            AddOptionsToMenuOrigin(pManager.Param(15))
            pManager.AddIntegerParameter("Repeat", "Repeat", "Repeat", GH_ParamAccess.item, 1)
            pManager.AddNumberParameter("DeltaX", "DeltaX", "DeltaX", GH_ParamAccess.item, 0.1)
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("PointSupportsOnBeam", "PointSupportsOnBeam", "", GH_ParamAccess.list)
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
            Dim PositionX As Double = 0.0
            Dim Repeat As Integer = 1
            Dim Origin As String = "From start"
            Dim DeltaX As Double = 0.01
            Dim i As Integer
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
            DA.GetData(14, PositionX)
            DA.GetData(15, i)
            Origin = GetStringFromOrigin(i)
            DA.GetData(16, Repeat)
            DA.GetData(17, DeltaX)


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
                FlatList.Add(PositionX)
                FlatList.Add(Origin)
                FlatList.Add(Repeat)
                FlatList.Add(DeltaX)

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
                Return My.Resources.PointSupportOnBeam
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("192c50e9-147c-4b09-9682-d8ef82952497")
            End Get
        End Property
    End Class

End Namespace