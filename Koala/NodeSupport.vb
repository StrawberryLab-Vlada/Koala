Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class NodeSupport
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("NodeSupport", "NodeSupport",
                "NodeSupport description",
                "Koala", "Structure")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("NodeSupports", "NodeSupports", "Definition of nodal supports:N1;111000", GH_ParamAccess.list, "N1;111000")
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
            If (Not DA.GetDataList(Of String)(0, NodeSupports)) Then Return
            Dim i As Long

            Dim SE_nodesupports(NodeSupports.Count, 6)
            Dim FlatList As New List(Of System.Object)()
            'a support consists of: Node name, X, Y, Z, RX, RY, RZ - 0 is free, 1 is blocked DOF

            Dim item As String
            Dim itemcount As Long
            Dim supportnode As String, supportcode As String

            'initialize some variables
            itemcount = 0

            For Each item In NodeSupports
                supportnode = item.Split(";")(0)
                supportnode = supportnode.Trim
                supportcode = item.Split(";")(1)
                supportcode = supportcode.Trim
                SE_nodesupports(itemcount, 0) = supportnode
                For i = 1 To 6
                    SE_nodesupports(itemcount, i) = Strings.Mid(supportcode, i, 1)
                Next i

                itemcount += 1

            Next

            'Flatten data for export as simple list
            FlatList.Clear()

            For i = 0 To itemcount - 1
                FlatList.Add(SE_nodesupports(i, 0))
                FlatList.Add(SE_nodesupports(i, 1))
                FlatList.Add(SE_nodesupports(i, 2))
                FlatList.Add(SE_nodesupports(i, 3))
                FlatList.Add(SE_nodesupports(i, 4))
                FlatList.Add(SE_nodesupports(i, 5))
                FlatList.Add(SE_nodesupports(i, 6))
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
                Return New Guid("9d3ad712-36d5-48d6-8784-b51009f1ced6")
            End Get
        End Property
    End Class

End Namespace