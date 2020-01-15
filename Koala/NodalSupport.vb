Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Grasshopper.Kernel
Imports Grasshopper.Kernel.Parameters
Imports Rhino.Geometry


Namespace Koala

    Public Class NodalSupport
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("NodalSupport", "NodalSupport",
                "NodalSupport description",
                "Koala", "Structure")
        End Sub





        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)

            pManager.AddTextParameter("ListOfNodes", "ListOfNodes", "List of node where support will be applied", GH_ParamAccess.list)
            pManager.AddIntegerParameter("Rx", "Rx", "Rotation around X axis", GH_ParamAccess.item, 0)
            AddOptionstoMenuDOFTransition(pManager.Param(1))
            pManager.AddIntegerParameter("Ry", "Ry", "Rotation around y axis", GH_ParamAccess.item, 0)
            AddOptionstoMenuDOFTransition(pManager.Param(2))
            pManager.AddIntegerParameter("Rz", "Rz", "Rotation around X axis", GH_ParamAccess.item, 0)
            AddOptionstoMenuDOFTransition(pManager.Param(3))
            pManager.AddIntegerParameter("Tx", "Tx", "Translation in X axis", GH_ParamAccess.item, 0)
            AddOptionstoMenuDOFRotation(pManager.Param(4))
            pManager.AddIntegerParameter("Ty", "Ty", "Translation in Y axis", GH_ParamAccess.item, 0)
            AddOptionstoMenuDOFRotation(pManager.Param(5))
            pManager.AddIntegerParameter("Tz", "Tz", "Translation in Z axis", GH_ParamAccess.item, 0)
            AddOptionstoMenuDOFRotation(pManager.Param(6))
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
            pManager.AddTextParameter("NodeSupports", "NodeSupports", "", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim NodeSupports = New List(Of String)
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

            If (Not DA.GetDataList(Of String)(0, NodeSupports)) Then Return
            DA.GetData(Of Integer)(1, Tx)
            DA.GetData(Of Integer)(2, Ty)
            DA.GetData(Of Integer)(3, Tz)
            DA.GetData(Of Integer)(4, Rx)
            DA.GetData(Of Integer)(5, Ry)
            DA.GetData(Of Integer)(6, Rz)
            DA.GetData(Of Double)(7, TxStiffness)
            DA.GetData(Of Double)(8, TyStiffness)
            DA.GetData(Of Double)(9, TzStiffness)
            DA.GetData(Of Double)(10, RxStiffness)
            DA.GetData(Of Double)(11, RyStiffness)
            DA.GetData(Of Double)(12, RzStiffness)


            Dim FlatList As New List(Of System.Object)()
            For Each item In NodeSupports
                FlatList.Add(item)
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
                Return My.Resources.NodeSupport
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("3f10e7ee-df4b-40e2-b02e-016fd5d04830")
            End Get
        End Property
    End Class

End Namespace