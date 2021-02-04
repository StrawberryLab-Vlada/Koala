Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class NLCable
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("Cable", "Cable",
                "NLCable description",
                "Koala", "Structure")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("BeamList", "BeamList", "List of beams where to apply gap", GH_ParamAccess.list)
            pManager.AddIntegerParameter("InitialMesh", "InitialMesh", "Initial Mesh: Calculated, Straight", GH_ParamAccess.item, 0)
            AddOptionsToMenuBeamNLGapDirection(pManager.Param(1))
            pManager.AddNumberParameter("NormalForce kN", "NormalForce kN", "NormalForce kN", GH_ParamAccess.item, 10)
            pManager.AddBooleanParameter("SelfWeigth", "SelfWeigth", "SelfWeigth", GH_ParamAccess.item, True)
            pManager.AddNumberParameter("Pn kN/m", "Pn kN/m", "Pn kN/m", GH_ParamAccess.item, 0)
            pManager.AddNumberParameter("Alpha x deg", "Alpha x deg", "Alpha x deg", GH_ParamAccess.item, 0)

        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
            pManager.AddTextParameter("CableElementList", "CableElementList", "", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim i As Integer
            Dim InitialMesh As String = "Both directions"
            Dim BeamList = New List(Of String)
            Dim NormalForce As Double = 0.01
            Dim Pn As Double = 0.0
            Dim Alphax As Double = 0.0
            Dim SelfWeigh As Boolean = True

            If (Not DA.GetDataList(Of String)(0, BeamList)) Then Return
            If (Not DA.GetData(Of Integer)(1, i)) Then Return
            InitialMesh = GetStringFromBeamNLCableInitialMesh(i)
            DA.GetData(Of Double)(2, NormalForce)
            DA.GetData(Of Boolean)(3, SelfWeigh)
            DA.GetData(Of Double)(4, Pn)
            DA.GetData(Of Double)(5, Alphax)



            Dim SE_Cables(BeamList.Count, 5) As String
            Dim FlatList As New List(Of System.Object)()
            'a section consists of: Profile name, section definition, material

            Dim item As String
            Dim itemcount As Long

            'initialize some variables
            itemcount = 0

            'identify section information in the strings
            For Each item In BeamList
                SE_Cables(itemcount, 0) = Strings.Trim(item)
                SE_Cables(itemcount, 1) = InitialMesh
                SE_Cables(itemcount, 2) = SelfWeigh
                SE_Cables(itemcount, 3) = NormalForce * 1000
                SE_Cables(itemcount, 4) = Pn * 1000
                SE_Cables(itemcount, 5) = (Alphax * Math.PI) / 180

                itemcount += 1
            Next

            'Flatten data for export as simple list
            FlatList.Clear()

            For i = 0 To itemcount - 1
                FlatList.Add(SE_Cables(i, 0))
                FlatList.Add(SE_Cables(i, 1))
                FlatList.Add(SE_Cables(i, 2))
                FlatList.Add(SE_Cables(i, 3))
                FlatList.Add(SE_Cables(i, 4))
                FlatList.Add(SE_Cables(i, 5))
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
                Return My.Resources.Cable
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("ba5ea3b4-a31a-4ad9-9007-f842e4f4c821")
            End Get
        End Property
    End Class

End Namespace