Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry

'' In order to load the result of this wizard, you will also need to
'' add the output bin/ folder of this project to the list of loaded
'' folder in Grasshopper.
'' You can use the _GrasshopperDeveloperSettings Rhino command for that.

Public Class LoadCasesAndGroups
    Inherits GH_Component
    ''' <summary>
    ''' Each implementation of GH_Component must provide a public 
    ''' constructor without any arguments.
    ''' Category represents the Tab in which the component will appear, 
    ''' Subcategory the panel. If you use non-existing tab or panel names, 
    ''' new tabs/panels will automatically be created.
    ''' </summary>
    Public Sub New()
        MyBase.New("KoalaLoadCases", "KoalaLoadCases&Groups",
                "Definition of loadcases",
                "Koala", "Libraries")
    End Sub

    ''' <summary>
    ''' Registers all the input parameters for this component.
    ''' </summary>
    Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)

        pManager.AddTextParameter("LoadCases", "LCs", "LoadCase parametrs - Name;Type;LoadGroup: LC1;SW;LG1", GH_ParamAccess.list, "LC2; Permanent; LG1")
        pManager.AddTextParameter("LoadGroups", "LGs", "LoadGroup parametrs - Name;Type: LG1;Permanent", GH_ParamAccess.list, "LG2; Variable; Standard")

    End Sub

    ''' <summary>
    ''' Registers all the output parameters for this component.
    ''' </summary>
    Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
        pManager.AddTextParameter("LoadCases", "LoadCases", "out_outloadcases", GH_ParamAccess.list)
        pManager.AddTextParameter("LoadGroups", "LoadGroups", "out_outloadgroups", GH_ParamAccess.list)
    End Sub

    ''' <summary>
    ''' This is the method that actually does the work.
    ''' </summary>
    ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
    ''' to store data in output parameters.</param>
    ''' (ByRef out_loadcases As Object, ByRef out_loadgroups As Object) 

    Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

        Dim i As Long
        Dim LoadCases = New List(Of String)
        Dim LoadGroups = New List(Of String)



        If (Not DA.GetDataList(Of String)(0, LoadCases)) Then Return
        If (Not DA.GetDataList(Of String)(1, LoadGroups)) Then Return



        Dim SE_lcases(LoadCases.Count, 2)
        Dim FlatLCaseList As New List(Of System.Object)()
        'a load case consists of: name, type (Permanent/Variable), load group
        Dim SE_lgroups(LoadGroups.Count, 2)
        Dim FlatLGroupList As New List(Of System.Object)()
        'a load group consists of: name, load type (Permanent/Variable), relation type (Nothing for Permanent, Exclusive/Together/Standard, for Variable)


        Dim lcase As String
        Dim lcasecount As Long
        Dim lcasename As String, lcasetype As String, lcasegroup As String

        Dim lgroup As String
        Dim lgroupcount As Long
        Dim lgroupname As String, lgrouptype As String, lgrouprel As String


        'initialize some variables
        lcasecount = 0
        lgroupcount = 0

        'identify information in the strings
        For Each lcase In LoadCases
            lcasename = lcase.Split(";")(0)
            lcasetype = lcase.Split(";")(1)
            lcasegroup = lcase.Split(";")(2)
            SE_lcases(lcasecount, 0) = lcasename.Trim
            SE_lcases(lcasecount, 1) = lcasetype.Trim
            SE_lcases(lcasecount, 2) = lcasegroup.Trim

            lcasecount = lcasecount + 1
        Next

        For Each lgroup In LoadGroups
            lgroupname = lgroup.Split(";")(0)
            lgrouptype = lgroup.Split(";")(1)
            If Strings.Trim(Strings.UCase(lgrouptype)) = "VARIABLE" Then
                lgrouprel = lgroup.Split(";")(2)
            Else
                lgrouprel = "N/A"
            End If

            SE_lgroups(lgroupcount, 0) = lgroupname.Trim
            SE_lgroups(lgroupcount, 1) = lgrouptype.Trim
            SE_lgroups(lgroupcount, 2) = lgrouprel.Trim

            lgroupcount = lgroupcount + 1
        Next

        'Flatten data for export as simple list
        FlatLCaseList.Clear()

        For i = 0 To lcasecount - 1
            FlatLCaseList.Add(SE_lcases(i, 0))
            FlatLCaseList.Add(SE_lcases(i, 1))
            FlatLCaseList.Add(SE_lcases(i, 2))
        Next i

        FlatLGroupList.Clear()

        For i = 0 To lgroupcount - 1
            FlatLGroupList.Add(SE_lgroups(i, 0))
            FlatLGroupList.Add(SE_lgroups(i, 1))
            FlatLGroupList.Add(SE_lgroups(i, 2))
        Next i

        ' out_loadcases = FlatLCaseList
        ' out_loadgroups = FlatLGroupList

        DA.SetDataList(0, FlatLCaseList)
        DA.SetDataList(1, FlatLGroupList)

    End Sub

    ''' <summary>
    ''' Provides an Icon for every component that will be visible in the User Interface.
    ''' Icons need to be 24x24 pixels.
    ''' </summary>
    Protected Overrides ReadOnly Property Icon() As System.Drawing.Bitmap
        Get
            'You can add image files to your project resources and access them like this:
            ' return Resources.IconForThisComponent;
            Return My.Resources.LoadCases

        End Get
    End Property

    ''' <summary>
    ''' Each component must have a unique Guid to identify it. 
    ''' It is vital this Guid doesn't change otherwise old ghx files 
    ''' that use the old ID will partially fail during loading.
    ''' </summary>
    Public Overrides ReadOnly Property ComponentGuid() As Guid
        Get
            Return New Guid("169dcace-cab8-4cdb-9b9a-56310d242078")
        End Get
    End Property
End Class