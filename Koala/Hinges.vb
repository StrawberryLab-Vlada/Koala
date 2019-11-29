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
            pManager.AddTextParameter("Hinges", "Hinges", "Definition of hinges", GH_ParamAccess.list)
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
            If (Not DA.GetDataList(Of String)(0, Hinges)) Then Return
            Dim i As Long

            Dim SE_hinges(Hinges.Count, 7)
            Dim FlatList As New List(Of System.Object)()
            'a hinge consists of: Beam name, ux, uy, uz, phix, phiy, phiz (0: free, 1: fixed), Position (Begin/End/Both)

            Dim item As String
            Dim itemcount As Long
            Dim hingebeam As String, hingecode As String, hingepos As String

            'initialize some variables
            itemcount = 0

            'create fixed supports on first & last nodes, fully fixed
            '=====================================
            For Each item In Hinges
                hingebeam = item.Split(";")(0)
                hingebeam = hingebeam.Trim
                hingecode = item.Split(";")(1)
                hingecode = hingecode.Trim
                SE_hinges(itemcount, 0) = hingebeam
                For i = 1 To 6
                    SE_hinges(itemcount, i) = Strings.Mid(hingecode, i, 1)
                Next i

                hingepos = item.Split(";")(2)
                hingepos = hingepos.Trim
                SE_hinges(itemcount, 7) = hingepos

                itemcount += 1

            Next

            'Flatten data for export as simple list
            FlatList.Clear()

            For i = 0 To itemcount - 1
                FlatList.Add(SE_hinges(i, 0))
                FlatList.Add(SE_hinges(i, 1))
                FlatList.Add(SE_hinges(i, 2))
                FlatList.Add(SE_hinges(i, 3))
                FlatList.Add(SE_hinges(i, 4))
                FlatList.Add(SE_hinges(i, 5))
                FlatList.Add(SE_hinges(i, 6))
                FlatList.Add(SE_hinges(i, 7))
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