Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class NodeRigidArm
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("NodeRigidArm", "NodeRigidArm",
                "NodeRigidArm description",
                "Koala", "Structure")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("RigidArmsPrefix", "RigidArmsPrefix", "", GH_ParamAccess.item, "RA")
            pManager.AddTextParameter("MasterNode", "MasterNode", "", GH_ParamAccess.item)
            pManager.AddTextParameter("SlaveNodes", "SlaveNodes", "", GH_ParamAccess.list)
            pManager.AddBooleanParameter("HingeOnMaster", "HingeOnMaster", "HingeOnMaster", GH_ParamAccess.item, False)
            pManager.AddBooleanParameter("HingeOnSlave", "HingeOnSlave", "HingeOnSlave", GH_ParamAccess.item, False)
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("RigidArms", "RigidArms", "", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim RigidArmsPrefix As String = "RA"
            Dim MasterNode As String = ""
            Dim HingeOnMaster As Boolean = False
            Dim HingeOnSlave As Boolean = False
            Dim slaves = New List(Of String)

            If (Not DA.GetData(Of String)(0, RigidArmsPrefix)) Then Return
            If (Not DA.GetData(Of String)(1, MasterNode)) Then Return
            If (Not DA.GetDataList(Of String)(2, slaves)) Then Return
            DA.GetData(Of Boolean)(3, HingeOnMaster)
            DA.GetData(Of Boolean)(4, HingeOnSlave)

            Dim SE_rigidArms(slaves.Count, 7)
            Dim FlatList As New List(Of System.Object)()
            'a hinge consists of: Beam name, ux, uy, uz, phix, phiy, phiz (0: free, 1: fixed), Position (Begin/End/Both)

            Dim item As String
            Dim i As Long = 1


            'create fixed supports on first & last nodes, fully fixed
            '=====================================
            FlatList.Clear()
            For Each item In slaves
                FlatList.Add(RigidArmsPrefix & i.ToString())
                FlatList.Add(MasterNode)
                FlatList.Add(item)
                FlatList.Add(HingeOnMaster)
                FlatList.Add(HingeOnSlave)
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
                Return My.Resources.RigidArms
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("03dd5c0f-ab95-416d-9d4e-cedc8c33391e")
            End Get
        End Property
    End Class

End Namespace