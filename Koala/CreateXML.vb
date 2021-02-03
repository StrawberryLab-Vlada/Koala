Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class CreateXML
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("CreateXML", "CreateXML",
                "CreateXML description",
                "Koala", "General")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddIntegerParameter("StructureType", "StructureType", "Type of structure:  Right click and select from options", GH_ParamAccess.item, 8)
            AddOptionstoMenuStructureType(pManager.Param(0))
            pManager.Param(0).Optional = True
            pManager.AddIntegerParameter("UILanguage", "UILanguage", "UI language:  Right click and select from options", GH_ParamAccess.item, 0)
            pManager.Param(1).Optional = True
            AddOptionsToMenuLanguage(pManager.Param(1))
            pManager.AddTextParameter("Materials", "Materials", "Materials: Conctrete, Steel, Timber", GH_ParamAccess.list, "Concrete")
            pManager.Param(2).Optional = True
            pManager.AddNumberParameter("MeshSize", "MeshSize", "Size of mesh", GH_ParamAccess.item, 0.15)
            pManager.Param(3).Optional = True
            pManager.AddTextParameter("Sections", "Sections", "List of cross-sections", GH_ParamAccess.list)
            pManager.Param(4).Optional = True
            pManager.AddTextParameter("Nodes", "Nodes", "List of nodes", GH_ParamAccess.list)
            pManager.Param(5).Optional = True
            pManager.AddTextParameter("Beams", "Beams", "List of beasm", GH_ParamAccess.list)
            pManager.Param(6).Optional = True
            pManager.AddTextParameter("Surfaces", "Surfaces", "List of 2DMembers", GH_ParamAccess.list)
            pManager.Param(7).Optional = True
            pManager.AddTextParameter("Openings", "Openings", "List of openings", GH_ParamAccess.list)
            pManager.Param(8).Optional = True
            pManager.AddTextParameter("Nodesupports", "Nodesupports", "List of node supportss", GH_ParamAccess.list)
            pManager.Param(9).Optional = True
            pManager.AddTextParameter("Edgesupports", "Edgesupports", "List of edge supports", GH_ParamAccess.list)
            pManager.Param(10).Optional = True
            pManager.AddTextParameter("Loadcases", "Loadcases", "List of load cases", GH_ParamAccess.list)
            pManager.Param(11).Optional = True
            pManager.AddTextParameter("Loadgroups", "Loadgroups", "List of load gropus", GH_ParamAccess.list)
            pManager.Param(12).Optional = True
            pManager.AddTextParameter("Lineloads", "Lineloads", "List of line loads", GH_ParamAccess.list)
            pManager.Param(13).Optional = True
            pManager.AddTextParameter("Surfaceloads", "Surfaceloads", "List of surface loads", GH_ParamAccess.list)
            pManager.Param(14).Optional = True
            pManager.AddTextParameter("FreePointloads", "FreePointloads", "List of free point loads", GH_ParamAccess.list)
            pManager.Param(15).Optional = True
            pManager.AddTextParameter("FreelLineloads", "FreelLineloads", "List of free line loads", GH_ParamAccess.list)
            pManager.Param(16).Optional = True
            pManager.AddTextParameter("FreeSurfaceloads", "FreeSurfaceloads", "List of free surface loads", GH_ParamAccess.list)
            pManager.Param(17).Optional = True
            pManager.AddTextParameter("Hinges", "Hinges", "List of hinges", GH_ParamAccess.list)
            pManager.Param(18).Optional = True
            pManager.AddTextParameter("FileName", "FileName", "Output filename", GH_ParamAccess.item, " ")
            pManager.AddTextParameter("Scale", "Scale", "Scale", GH_ParamAccess.item, "1")
            pManager.Param(20).Optional = True
            pManager.AddBooleanParameter("RemDuplNodes", "RemDuplNodes", "Output filename", GH_ParamAccess.item, False)
            pManager.Param(21).Optional = True
            pManager.AddBooleanParameter("OnDemand", "OnDemand", "Output filename on demand", GH_ParamAccess.item, False)
            pManager.Param(22).Optional = True
            pManager.AddTextParameter("Edgeloads", "Edgeloads", "List of line loads on 2D members", GH_ParamAccess.list)
            pManager.Param(23).Optional = True
            pManager.AddTextParameter("PointloadsonPoints", "PointloadsonPoints", "List of point line on nodes", GH_ParamAccess.list)
            pManager.Param(24).Optional = True
            pManager.AddTextParameter("PointloadsonBeams", "PointloadsonBeams", "List of point loads on beams", GH_ParamAccess.list)
            pManager.Param(25).Optional = True
            pManager.AddTextParameter("LinCombinations", "LinCombinations", "List of linear combinations", GH_ParamAccess.list)
            pManager.Param(26).Optional = True
            pManager.AddTextParameter("NonLinCombinations", "NonLinCombinations", "List of nonlinear combinations", GH_ParamAccess.list)
            pManager.Param(27).Optional = True
            pManager.AddTextParameter("StabilityCombinations", "StabilityCombinations", "List of stability combinations", GH_ParamAccess.list)
            pManager.Param(28).Optional = True
            pManager.AddTextParameter("Crosslinks", "Crosslinks", "List crosslinks", GH_ParamAccess.list)
            pManager.Param(29).Optional = True
            pManager.AddTextParameter("PressTensionBeamNL", "PressTensionBeamNL", "List of press/tension only beam local NL", GH_ParamAccess.list)
            pManager.Param(30).Optional = True
            pManager.AddTextParameter("GapElementsBeamNL", "GapElementsBeamNL", "List of gap beam local NL", GH_ParamAccess.list)
            pManager.Param(31).Optional = True
            pManager.AddTextParameter("LimitForceBeamNL", "LimitForceBeamNL", "List of limit force beam local NL", GH_ParamAccess.list)
            pManager.Param(32).Optional = True
            pManager.AddTextParameter("ProjectInformation", "ProjectInformation", "Project informations", GH_ParamAccess.list)
            pManager.Param(33).Optional = True
            pManager.AddTextParameter("Layers", "Layers", "Defined layers", GH_ParamAccess.list)
            pManager.Param(34).Optional = True
            pManager.AddTextParameter("BeamLineSupports", "BeamLineSupports", "Defined line support on beam", GH_ParamAccess.list)
            pManager.Param(35).Optional = True
            pManager.AddTextParameter("PointSupportsOnBeam", "PointSupportsOnBeam", "Defined point supports on beam", GH_ParamAccess.list)
            pManager.Param(36).Optional = True
            pManager.AddTextParameter("Subsoils", "Subsoils", "Defined subsoils for surface support", GH_ParamAccess.list)
            pManager.Param(37).Optional = True
            pManager.AddTextParameter("SurfaceSupports", "SurfaceSupports", "Defined surface supports", GH_ParamAccess.list)
            pManager.Param(38).Optional = True
            pManager.AddTextParameter("Loadpanels", "Loadpanels", "Defined Load panels", GH_ParamAccess.list)
            pManager.Param(39).Optional = True
            pManager.AddTextParameter("PointMomentsOnNodes", "PointMomentsOnNodes", "Defined point moments in points", GH_ParamAccess.list)
            pManager.Param(40).Optional = True
            pManager.AddTextParameter("PointMomentsOnBeams", "PointMomentsOnBeams", "Defined point moments in points on beams", GH_ParamAccess.list)
            pManager.Param(41).Optional = True
            pManager.AddTextParameter("LineMomentsOnBeams", "LineMomentsOnBeams", "Defined line moments on beams", GH_ParamAccess.list)
            pManager.Param(42).Optional = True
            pManager.AddTextParameter("LineMomentsOnEdge", "LineMomentsOnEdge", "Defined line moments on edges", GH_ParamAccess.list)
            pManager.Param(43).Optional = True
            pManager.AddTextParameter("FreeMomentPoints", "FreeMomentPoints", "Defined free point moments", GH_ParamAccess.list)
            pManager.Param(44).Optional = True
            pManager.AddTextParameter("NonlinearFunctions", "NonlinearFunctions", "Defined nonlinear functions", GH_ParamAccess.list)
            pManager.Param(45).Optional = True
            pManager.AddNumberParameter("Tolerance", "Tolerance", "Tolerance for duplicity nodes", GH_ParamAccess.item, 0.001)
            pManager.Param(46).Optional = True
            pManager.AddTextParameter("SlabInternalEdges", "SlabInternalEdges", "List of internal edges for slabs", GH_ParamAccess.list)
            pManager.Param(47).Optional = True
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("filename", "filename", "Output XML", GH_ParamAccess.item)
        End Sub



        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim StructureType As String = "General XYZ"
            Dim UILanguage As String = "0"
            Dim Materials = New List(Of String)
            Dim MeshSize As Double = 0.15
            Dim in_sections = New List(Of String)
            Dim in_nodes = New List(Of String)
            Dim in_beams = New List(Of String)
            Dim in_surfaces = New List(Of String)
            Dim in_openings = New List(Of String)
            Dim in_nodesupports = New List(Of String)
            Dim in_edgesupports = New List(Of String)
            Dim in_lcases = New List(Of String)
            Dim in_lgroups = New List(Of String)
            Dim in_lloads = New List(Of String)
            Dim in_sloads = New List(Of String)
            Dim in_fploads = New List(Of String)
            Dim in_flloads = New List(Of String)
            Dim in_fsloads = New List(Of String)
            Dim in_hinges = New List(Of String)
            Dim in_edgeLoads = New List(Of String)
            Dim in_pointLoadsPoints = New List(Of String)
            Dim in_pointLoadsBeams = New List(Of String)
            Dim FileName As String = " "
            Dim Scale As String = "1"
            Dim RemDuplNodes As Boolean = False
            ' Dim AutoUpdate As Boolean = False
            Dim OnDemand As Boolean = False
            Dim in_LinCombinations = New List(Of String)
            Dim in_NonLinCombinations = New List(Of String)
            Dim in_StabCombinations = New List(Of String)
            Dim in_CrossLinks = New List(Of String)
            Dim in_presstensionElem = New List(Of String)
            Dim in_gapElem = New List(Of String)
            Dim in_limitforceElem = New List(Of String)
            Dim projectInfo = New List(Of String)
            Dim in_layers = New List(Of String)
            Dim in_BeamLineSupport = New List(Of String)
            Dim in_PointSupportsOnBeams = New List(Of String)
            Dim in_Subsoils = New List(Of String)
            Dim in_SurfaceSupports = New List(Of String)
            Dim in_loadpanels = New List(Of String)
            Dim in_pointMomentPoint = New List(Of String)
            Dim in_pointMomentBeam = New List(Of String)
            Dim in_lineMomentBeam = New List(Of String)
            Dim in_lineMomentEdge = New List(Of String)
            Dim in_freePointMoment = New List(Of String)
            Dim in_nonlinearfunctions = New List(Of String)
            Dim in_slabinternalEdges = New List(Of String)
            Dim Tolerance As Double = 0.001



            Dim i As Integer = 0

            If (Not DA.GetData(Of String)(19, FileName)) Then Return
            DA.GetData(Of Integer)(0, i)
            StructureType = GetStringForStructureType(i)
            DA.GetData(Of Integer)(1, i)
            UILanguage = GetStringForLanguage(i)
            DA.GetDataList(Of String)(2, Materials)
            DA.GetData(3, MeshSize)
            DA.GetDataList(Of String)(4, in_sections)
            DA.GetDataList(Of String)(5, in_nodes)
            DA.GetDataList(Of String)(6, in_beams)
            DA.GetDataList(Of String)(7, in_surfaces)
            DA.GetDataList(Of String)(8, in_openings)
            DA.GetDataList(Of String)(9, in_nodesupports)
            DA.GetDataList(Of String)(10, in_edgesupports)
            DA.GetDataList(Of String)(11, in_lcases)
            DA.GetDataList(Of String)(12, in_lgroups)
            DA.GetDataList(Of String)(13, in_lloads)
            DA.GetDataList(Of String)(14, in_sloads)
            DA.GetDataList(Of String)(15, in_fploads)
            DA.GetDataList(Of String)(16, in_flloads)
            DA.GetDataList(Of String)(17, in_fsloads)
            DA.GetDataList(Of String)(18, in_hinges)
            DA.GetData(Of String)(20, Scale)
            DA.GetData(Of Boolean)(21, RemDuplNodes)
            DA.GetData(Of Boolean)(22, OnDemand)
            DA.GetDataList(Of String)(23, in_edgeLoads)
            DA.GetDataList(Of String)(24, in_pointLoadsPoints)
            DA.GetDataList(Of String)(25, in_pointLoadsBeams)
            DA.GetDataList(Of String)(26, in_LinCombinations)
            DA.GetDataList(Of String)(27, in_NonLinCombinations)
            DA.GetDataList(Of String)(28, in_StabCombinations)
            DA.GetDataList(Of String)(29, in_CrossLinks)
            DA.GetDataList(Of String)(30, in_presstensionElem)
            DA.GetDataList(Of String)(31, in_gapElem)
            DA.GetDataList(Of String)(32, in_limitforceElem)
            DA.GetDataList(Of String)(33, projectInfo)
            DA.GetDataList(Of String)(34, in_layers)
            DA.GetDataList(Of String)(35, in_BeamLineSupport)
            DA.GetDataList(Of String)(36, in_PointSupportsOnBeams)
            DA.GetDataList(Of String)(37, in_Subsoils)
            DA.GetDataList(Of String)(38, in_SurfaceSupports)
            DA.GetDataList(Of String)(39, in_loadpanels)
            DA.GetDataList(Of String)(40, in_pointMomentPoint)
            DA.GetDataList(Of String)(41, in_pointMomentBeam)
            DA.GetDataList(Of String)(42, in_lineMomentBeam)
            DA.GetDataList(Of String)(43, in_lineMomentEdge)
            DA.GetDataList(Of String)(44, in_freePointMoment)
            DA.GetDataList(Of String)(45, in_nonlinearfunctions)
            DA.GetData(Of Double)(46, Tolerance)
            DA.GetDataList(Of String)(47, in_slabinternalEdges)


            If AutoUpdate = False Then
                If OnDemand = False Then
                    Exit Sub
                End If
            End If



            CreateXMLFile(FileName, StructureType, Materials, UILanguage, MeshSize, in_sections, in_nodes, in_beams, in_surfaces, in_openings,
                          in_nodesupports, in_edgesupports, in_lcases, in_lgroups, in_lloads, in_sloads, in_fploads, in_flloads, in_fsloads, in_hinges,
                          in_edgeLoads, in_pointLoadsPoints, in_pointLoadsBeams, Scale, in_LinCombinations, in_NonLinCombinations, in_StabCombinations,
                          in_CrossLinks, in_presstensionElem, in_gapElem, in_limitforceElem, projectInfo, in_layers, in_BeamLineSupport, in_PointSupportsOnBeams,
                          in_Subsoils, in_SurfaceSupports, in_loadpanels, in_pointMomentPoint, in_pointMomentBeam, in_lineMomentBeam, in_lineMomentEdge,
                          in_freePointMoment, in_nonlinearfunctions, RemDuplNodes, Tolerance, in_slabinternalEdges)
            DA.SetData(0, FileName)



        End Sub

        Private mAutoUpdate As Boolean = False
        Public Property AutoUpdate() As Boolean
            Get
                Return mAutoUpdate
            End Get
            Set(ByVal value As Boolean)
                mAutoUpdate = value
                If (mAutoUpdate) Then
                    Message = "AutoUpdateEnabled"
                Else
                    Message = "AutoUpdateDisabled"
                End If
            End Set
        End Property
        Public Overrides Function Write(ByVal writer As GH_IO.Serialization.GH_IWriter) As Boolean
            'First add our own field.
            writer.SetBoolean("AutoUpdate", AutoUpdate)
            'Then call the base class implementation.
            Return MyBase.Write(writer)
        End Function
        Public Overrides Function Read(ByVal reader As GH_IO.Serialization.GH_IReader) As Boolean
            'First read our own field.
            AutoUpdate = reader.GetBoolean("AutoUpdate")
            'Then call the base class implementation.
            Return MyBase.Read(reader)
        End Function
        Protected Overrides Sub AppendAdditionalComponentMenuItems(ByVal menu As System.Windows.Forms.ToolStripDropDown)
            'Append the item to the menu, making sure it's always enabled and checked if Absolute is True.
            Dim item As ToolStripMenuItem = Menu_AppendItem(menu, "AutoUpdate", AddressOf Menu_AutoUpdateClicked, True, AutoUpdate)
            'Specifically assign a tooltip text to the menu item.
            item.ToolTipText = "When checked, XML file is updated automatically."
        End Sub
        Private Sub Menu_AutoUpdateClicked(ByVal sender As Object, ByVal e As EventArgs)
            RecordUndoEvent("AutoUpdate")
            AutoUpdate = Not AutoUpdate
            ExpireSolution(True)
        End Sub


        ''' <summary>
        ''' Provides an Icon for every component that will be visible in the User Interface.
        ''' Icons need to be 24x24 pixels.
        ''' </summary>
        Protected Overrides ReadOnly Property Icon() As System.Drawing.Bitmap
            Get
                'You can add image files to your project resources and access them like this:
                ' return Resources.IconForThisComponent;
                Return My.Resources.CreateXML
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("a0d394f8-b648-4b3b-bb9e-16330a2f4a9e")
            End Get
        End Property
    End Class

End Namespace