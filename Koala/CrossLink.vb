Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class CrossLink
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("CrossLink", "CrossLink",
                "CrossLink description",
                "Koala", "Structure")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddIntegerParameter("Type", "Type", "Type of cross-link:  Right click and select from options", GH_ParamAccess.item, 0)
            AddOptionsToMenuCrosslinkType(pManager.Param(0))
            pManager.AddTextParameter("CoupledMembers", "CoupledMembers", "1stmember;2ndmember", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("CrossLinks", "CrossLinks", "Defined cross-links", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim i As Integer
            Dim Type As String = "Fixed"
            Dim CoupledMembers = New List(Of String)

            If (Not DA.GetData(Of Integer)(0, i)) Then Return
            Type = GetStringForCrosslinkType(i)
            If (Not DA.GetDataList(Of String)(1, CoupledMembers)) Then Return

            Dim SE_Crosslinks(CoupledMembers.Count, 3) As String
            Dim FlatList As New List(Of System.Object)()
            'a section consists of: Profile name, section definition, material

            Dim item As String
            Dim itemcount As Long
            Dim Firtsmember As String, SecondMember As String

            'initialize some variables
            itemcount = 0

            'identify section information in the strings
            For Each item In CoupledMembers
                If (item IsNot "") Then
                    Firtsmember = item.Split(";")(0)
                    SecondMember = item.Split(";")(1)
                    SE_Crosslinks(itemcount, 0) = Type
                    SE_Crosslinks(itemcount, 1) = Firtsmember.Trim
                    SE_Crosslinks(itemcount, 2) = SecondMember.Trim
                    itemcount += 1
                End If
            Next

            'Flatten data for export as simple list
            FlatList.Clear()

            For i = 0 To itemcount - 1
                FlatList.Add(SE_Crosslinks(i, 0))
                FlatList.Add(SE_Crosslinks(i, 1))
                FlatList.Add(SE_Crosslinks(i, 2))
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
                Return My.Resources.Cross_link
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("91e2c185-7637-42f1-8cdc-970a7bc0a93a")
            End Get
        End Property
    End Class

End Namespace