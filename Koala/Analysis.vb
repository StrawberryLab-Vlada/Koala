Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class Analysis
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("Analysis", "Analysis",
                "Analysis description",
                "Koala", "Calculate")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("FileName", "FileName", "Name for the XML", GH_ParamAccess.item)
            pManager.AddTextParameter("ESAXMLPath", "ESAXMLPath", "Path to Esa_XML tool", GH_ParamAccess.item)
            pManager.AddIntegerParameter("CalcType", "CalcType", "Type of calculation:  Right click and select from options", GH_ParamAccess.item, 0)
            AddOptionsToMenuCalculationType(pManager.Param(2))
            pManager.AddTextParameter("TemplateName", "TemplateName", "Template file name", GH_ParamAccess.item)
            pManager.AddTextParameter("OutputFile", "OutputFile", "Output file for results", GH_ParamAccess.item)
            pManager.AddBooleanParameter("RunESAXML", "RunESAXML", "Run calculation: True, False - no", GH_ParamAccess.item, False)


        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("Message", "Message", "", GH_ParamAccess.item)
            pManager.AddTextParameter("OutputFile", "OutputFile", "", GH_ParamAccess.item)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim FileName As String = ""
            Dim ESAXMLPath As String = ""
            Dim CalcType As String = "LIN"
            Dim TemplateName As String = ""
            Dim OutputFile As String = ""

            Dim RunESAXML As Boolean = False


            Dim i As Integer
            If (Not DA.GetData(0, FileName)) Then Return
            If (Not DA.GetData(1, ESAXMLPath)) Then Return
            If (Not DA.GetData(2, i)) Then Return
            CalcType = GetStringForCalculationType(i)
            If (Not DA.GetData(3, TemplateName)) Then Return
            If (Not DA.GetData(4, OutputFile)) Then Return
            If (Not DA.GetData(5, RunESAXML)) Then Return


            Dim time_elapsed As Double

            'only run through if button is pressed
            'only run through if button is pressed
            'AutoUpdate = False
            If AutoUpdate = False Then
                If RunESAXML = False Then
                    Exit Sub
                End If
            End If
            Dim strOut As String = ""

            strOut = RunCalculationWithEsaXML(FileName, ESAXMLPath, CalcType, TemplateName, OutputFile, time_elapsed)

            DA.SetData(0, strOut)
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
                Return My.Resources.Analysis
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("804449ff-866f-4e33-9fcf-b8819e369c19")
            End Get
        End Property
    End Class

End Namespace