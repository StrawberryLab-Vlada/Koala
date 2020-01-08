Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class CustomComponent
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("CustomComponent", "CustomComponent",
                "CustomComponent description",
                "CustomComponent category", "CustomComponent subcategory")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddNumberParameter("Values", "V", "Values to sort", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddNumberParameter("Values", "V", "Sorted values", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)
            Dim values As New List(Of Double)
            If (Not DA.GetDataList(0, values)) Then Return
            If (values.Count = 0) Then Return

            'Don't worry about where the Absolute property comes from, we'll get to it soon.
            If (Absolute) Then
                For i As Int32 = 0 To values.Count - 1
                    values(i) = Math.Abs(values(i))
                Next
            End If

            values.Sort()
            DA.SetDataList(0, values)
        End Sub
        Private m_absolute As Boolean = False
        Public Property Absolute() As Boolean
            Get
                Return m_absolute
            End Get
            Set(ByVal value As Boolean)
                m_absolute = value
                If (m_absolute) Then
                    Message = "Absolute"
                Else
                    Message = "Standard"
                End If
            End Set
        End Property
        Public Overrides Function Write(ByVal writer As GH_IO.Serialization.GH_IWriter) As Boolean
            'First add our own field.
            writer.SetBoolean("Absolute", Absolute)
            'Then call the base class implementation.
            Return MyBase.Write(writer)
        End Function
        Public Overrides Function Read(ByVal reader As GH_IO.Serialization.GH_IReader) As Boolean
            'First read our own field.
            Absolute = reader.GetBoolean("Absolute")
            'Then call the base class implementation.
            Return MyBase.Read(reader)
        End Function
        Protected Overrides Sub AppendAdditionalComponentMenuItems(ByVal menu As System.Windows.Forms.ToolStripDropDown)
            'Append the item to the menu, making sure it's always enabled and checked if Absolute is True.
            Dim item As ToolStripMenuItem = Menu_AppendItem(menu, "Absolute", AddressOf Menu_AbsoluteClicked, True, Absolute)
            'Specifically assign a tooltip text to the menu item.
            item.ToolTipText = "When checked, values are made absolute prior to sorting."
        End Sub
        Private Sub Menu_AbsoluteClicked(ByVal sender As Object, ByVal e As EventArgs)
            RecordUndoEvent("Absolute")
            Absolute = Not Absolute
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
                Return Nothing
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("d80be195-f774-4cff-a570-5ebbe05e7171")
            End Get
        End Property
    End Class

End Namespace