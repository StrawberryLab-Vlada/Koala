Imports System.Collections.Generic
Imports System.Runtime.Remoting.Metadata.W3cXsd2001
Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class NonlinearFunction
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("NonlinearFunction", "NonlinearFunction",
                "NonlinearFunction description",
                "Koala", "Libraries")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("Name", " Name", "Name of nonlinear function", GH_ParamAccess.item, "NLF1")
            pManager.AddIntegerParameter("Type", "Type", "Type of function", GH_ParamAccess.item, 0)
            AddOptionsToMenuNLFunctionType(pManager.Param(1))
            pManager.AddIntegerParameter("PositiveEnd", "PositiveEnd", "Type of Positive end", GH_ParamAccess.item, 0)
            AddOptionsToMenuNLFunctionEndType(pManager.Param(2))
            pManager.AddIntegerParameter("NegativeEnd", "NegativeEnd", "Type of Negative end", GH_ParamAccess.item, 0)
            AddOptionsToMenuNLFunctionEndType(pManager.Param(3))
            pManager.AddTextParameter("GraphPoints", " GraphPoints", "GraphPoints", GH_ParamAccess.list, {"-1;0"})


        End Sub



        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("NonlinearFunction", "NonlinearFunction", "Defined nonlinear function", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim Name As String = "NFL1"
            Dim i As Integer
            Dim Type As String
            Dim PositiveEnd As String
            Dim NegativeEnd As String
            Dim Points As List(Of String) = Nothing
            Points = New List(Of String)

            If (Not DA.GetData(0, Name)) Then Return
            If (Not DA.GetData(1, i)) Then Return
            Type = GetStringForitemNLFunctionType(i)
            If (Not DA.GetData(2, i)) Then Return
            PositiveEnd = GetStringForitemNLFunctionEndType(i)
            If (Not DA.GetData(3, i)) Then Return
            NegativeEnd = GetStringForitemNLFunctionEndType(i)
            If (Not DA.GetDataList(4, Points)) Then Return

            Dim FlatList As New List(Of System.Object)()


            Dim GraphPoints As String = ""


            For i = 0 To Points.Count - 1
                If (Not i = Points.Count - 1) Then
                    GraphPoints += Points(i) + "|"
                Else
                    GraphPoints += Points(i)
                End If
            Next i

            FlatList.Add(Name)
            FlatList.Add(Type)
            FlatList.Add(PositiveEnd)
            FlatList.Add(NegativeEnd)
            FlatList.Add(GraphPoints)

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
                Return My.Resources.NonLinearFunction
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("d7abd3f8-a1aa-4e46-b450-53ea26148591")
            End Get
        End Property
    End Class

End Namespace