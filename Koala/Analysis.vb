Imports System.Collections.Generic

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
            pManager.AddTextParameter("CalcType", "CalcType", "Type of calculation: LIN, NEL,STB", GH_ParamAccess.item, "LIN")
            pManager.AddTextParameter("TemplateName", "TemplateName", "Template file name", GH_ParamAccess.item)
            pManager.AddTextParameter("OutputFile", "OutputFile", "Output file for results", GH_ParamAccess.item)
            pManager.AddBooleanParameter("AutoUpdate", "AutoUpdate", "Automatic update", GH_ParamAccess.item, False)
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
            Dim AutoUpdate As Boolean = False
            Dim RunESAXML As Boolean = False



            If (Not DA.GetData(0, FileName)) Then Return
            If (Not DA.GetData(1, ESAXMLPath)) Then Return
            If (Not DA.GetData(2, CalcType)) Then Return
            If (Not DA.GetData(3, TemplateName)) Then Return
            If (Not DA.GetData(4, OutputFile)) Then Return
            If (Not DA.GetData(5, AutoUpdate)) Then Return
            If (Not DA.GetData(6, RunESAXML)) Then Return

            Dim stopWatch As New System.Diagnostics.Stopwatch()
            Dim time_elapsed As Double

            'only run through if button is pressed
            'only run through if button is pressed
            If AutoUpdate = False Then
                If RunESAXML = False Then
                    Exit Sub
                End If
            End If


            'initialize stopwatch
            stopWatch.Start()

            Rhino.RhinoApp.WriteLine("")
            Rhino.RhinoApp.WriteLine("===== KOALA SCIA Engineer plugin - running analysis =====")

            'run ESA_XML
            '---------------------------------------------------
            Try
                Dim myProcess As New System.Diagnostics.Process
                Dim ESAXMLArgs As String
                Dim strOut As String, strErr As String, intExit As Integer

                myProcess.StartInfo.FileName = ESAXMLPath
                ESAXMLArgs = CalcType & " " & TemplateName & " " & FileName & " -tTXT -o" & OutputFile
                myProcess.StartInfo.Arguments = ESAXMLArgs
                myProcess.StartInfo.UseShellExecute = False
                'myProcess.StartInfo.RedirectStandardOutput = True
                'myProcess.StartInfo.RedirectStandardError = True
                'myProcess.StartInfo.CreateNoWindow = True

                Rhino.RhinoApp.WriteLine("Starting SCIA Engineer...")
                Rhino.RhinoApp.WriteLine("Arguments: " & ESAXMLArgs)
                Rhino.RhinoApp.WriteLine("Please wait...")

                myProcess.Start()
                myProcess.WaitForExit()
                intExit = myProcess.ExitCode
                Rhino.RhinoApp.Write("SCIA Engineer finished with exit code: " & intExit)
                'output anything that could come out of SCIA Engineer
                'standard out
                strOut = ""
                Select Case intExit
                    Case 0
                        Rhino.RhinoApp.WriteLine(" - Succeeded")
                        strOut = " - Succeeded"
                    Case 1
                        Rhino.RhinoApp.WriteLine(" - Unable To initialize MFC")
                        strOut = " - Unable To initialize MFC"
                    Case 2
                        Rhino.RhinoApp.WriteLine(" - Missing arguments")
                        strOut = " - Missing arguments"
                    Case 3
                        Rhino.RhinoApp.WriteLine(" - Invalid arguments")
                        strOut = " - Invalid arguments"
                    Case 4
                        Rhino.RhinoApp.WriteLine(" - Unable To open ProjectFile")
                        strOut = " - Unable To open ProjectFile"
                    Case 5
                        Rhino.RhinoApp.WriteLine(" - Calculation failed")
                        strOut = " - Calculation failed"
                    Case 6
                        Rhino.RhinoApp.WriteLine(" - Unable To initialize application environment")
                        strOut = " - Unable To initialize application environment"
                    Case 7
                        Rhino.RhinoApp.WriteLine(" - Error during update ProjectFile By XMLUpdateFile")
                        strOut = " - Error during update ProjectFile By XMLUpdateFile"
                    Case 8
                        Rhino.RhinoApp.WriteLine(" - Error during create export outputs")
                        strOut = " - Error during create export outputs"
                    Case 9
                        Rhino.RhinoApp.WriteLine(" - Error during create XML outputs")
                        strOut = " - Error during create XML outputs"
                    Case 99
                        Rhino.RhinoApp.WriteLine(" - Error during update ProjectFile By XLSX Update")
                        strOut = " - Error during update ProjectFile By XLSX Update"
                    Case Else
                        Rhino.RhinoApp.WriteLine(" - Unknown exit code")
                        strOut = " - Unknown exit code"
                End Select


                'strOut = myProcess.StandardOutput.ReadToEnd
                If strOut <> "" Then
                    Rhino.RhinoApp.WriteLine("SCIA Engineer output message: " & strOut)
                    DA.SetData(0, strOut)
                End If
                'standard error
                strErr = ""
                'strErr = myProcess.StandardOutput.ReadToEnd
                If strErr <> "" Then Rhino.RhinoApp.WriteLine("SCIA Engineer error message: " & strErr)

                ' DA.SetData(1, OutputFile)
            Catch ex As Exception
                Rhino.RhinoApp.WriteLine("Encountered error launching esa_xml.exe: " & ex.Message)

            End Try


            'stop stopwatch
            stopWatch.Stop()
            time_elapsed = stopWatch.ElapsedMilliseconds
            Rhino.RhinoApp.WriteLine("Done in " + Str(time_elapsed) + " ms.")

        End Sub

        '<Custom additional code> 




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