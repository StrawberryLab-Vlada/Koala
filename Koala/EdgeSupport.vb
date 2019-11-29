Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class EdgeSupport
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("EdgeSupport", "EdgeSupport",
                "EdgeSupport description",
                "Koala", "Structure")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("EdgeSupports", "EdgeSupports", "Definition of edge support", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("Edgesupports", "Edgesupports", "", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)
            Dim EdgeSupports = New List(Of String)

            Dim i As Long
            If (Not DA.GetDataList(Of String)(0, EdgeSupports)) Then Return
            Dim SE_edgesupports(EdgeSupports.Count, 8)
            Dim FlatList As New List(Of System.Object)()
            'a support consists of: Reference name, reference type, edge number, X, Y, Z, RX, RY, RZ - 0 is free, 1 is blocked DOF

            Dim item As String
            Dim itemcount As Long
            Dim referenceobj As String, referencetype As String, supportedge As String, supportcode As String

            'initialize some variables
            itemcount = 0

            For Each item In EdgeSupports
                referenceobj = item.Split(";")(0)
                referenceobj = referenceobj.Trim

                referencetype = item.Split(";")(1)
                referencetype = referencetype.Trim

                supportedge = item.Split(";")(2)
                supportedge = supportedge.Trim

                supportcode = item.Split(";")(3)
                supportcode = supportcode.Trim
                SE_edgesupports(itemcount, 0) = referenceobj
                SE_edgesupports(itemcount, 1) = referencetype
                SE_edgesupports(itemcount, 2) = supportedge
                For i = 1 To 6
                    SE_edgesupports(itemcount, 2 + i) = Strings.Mid(supportcode, i, 1)
                Next i

                itemcount += 1

            Next

            'Flatten data for export as simple list
            FlatList.Clear()

            For i = 0 To itemcount - 1
                FlatList.Add(SE_edgesupports(i, 0))
                FlatList.Add(SE_edgesupports(i, 1))
                FlatList.Add(SE_edgesupports(i, 2))
                FlatList.Add(SE_edgesupports(i, 3))
                FlatList.Add(SE_edgesupports(i, 4))
                FlatList.Add(SE_edgesupports(i, 5))
                FlatList.Add(SE_edgesupports(i, 6))
                FlatList.Add(SE_edgesupports(i, 7))
                FlatList.Add(SE_edgesupports(i, 8))
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
                Return My.Resources.LineSupport

            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("61dc16e7-8e8b-40da-8a64-2b9686281a39")
            End Get
        End Property
    End Class

End Namespace