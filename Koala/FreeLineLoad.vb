Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Namespace Koala

    Public Class FreeLineLoad
        Inherits GH_Component
        ''' <summary>
        ''' Each implementation of GH_Component must provide a public 
        ''' constructor without any arguments.
        ''' Category represents the Tab in which the component will appear, 
        ''' Subcategory the panel. If you use non-existing tab or panel names, 
        ''' new tabs/panels will automatically be created.
        ''' </summary>
        Public Sub New()
            MyBase.New("FreeLineLoad", "FreeLineLoad",
                "MyComponent1 description",
                "Koala", "Load")
        End Sub

        ''' <summary>
        ''' Registers all the input parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
            pManager.AddTextParameter("LoadCase", "LoadCase", "Name of load case", GH_ParamAccess.item)
            pManager.AddTextParameter("Validity", "Validity", "Validity: All,Z equals 0", GH_ParamAccess.item)
            pManager.AddTextParameter("Selection", "Selection", "Selection: Auto", GH_ParamAccess.item)
            pManager.AddTextParameter("CoordSys", "CoordSys", "Coordinate system: GCS - Length, GCS - Projection or Member LCS", GH_ParamAccess.item)
            pManager.AddTextParameter("Direction", "Direction", "Direction of load: X,Y,Z", GH_ParamAccess.item)
            pManager.AddTextParameter("Distribution", "Distribution", "Distribution of the load: Uniform | Trapez", GH_ParamAccess.item, "Uniform")
            pManager.AddNumberParameter("LoadValue1", "LoadValue1", "Value of Load in KN/m", GH_ParamAccess.item, -1.0)
            pManager.AddNumberParameter("LoadValue2", "LoadValue2", "Value of Load in KN/m", GH_ParamAccess.item, -1.0)
            pManager.AddCurveParameter("Lines", "Lines", "List of lines", GH_ParamAccess.list)

        End Sub

        ''' <summary>
        ''' Registers all the output parameters for this component.
        ''' </summary>
        Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)

            pManager.AddTextParameter("FreeLineloads", "FreeLineloads", "", GH_ParamAccess.list)
        End Sub

        ''' <summary>
        ''' This is the method that actually does the work.
        ''' </summary>
        ''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
        ''' to store data in output parameters.</param>
        Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)

            Dim LoadCase As String = ""
            Dim Validity As String = ""
            Dim Selection As String = ""
            Dim CoordSys As String = ""
            Dim Direction As String = ""
            Dim Distribution As String = ""
            Dim LoadValue1 As Double = -1.0
            Dim LoadValue2 As Double = -1.0
            Dim Lines = New List(Of Curve)

            If (Not DA.GetData(0, LoadCase)) Then Return
            If (Not DA.GetData(1, Validity)) Then Return
            If (Not DA.GetData(2, Selection)) Then Return
            If (Not DA.GetData(3, CoordSys)) Then Return
            If (Not DA.GetData(4, Direction)) Then Return
            DA.GetData(5, Distribution)
            If (Not DA.GetData(6, LoadValue1)) Then Return
            Select Case Distribution
                Case "Uniform"
                    LoadValue2 = LoadValue1
                Case "Trapez"
                    DA.GetData(6, LoadValue2)
                Case Else
                    LoadValue2 = LoadValue1
            End Select
            If (Not DA.GetDataList(Of Curve)(6, Lines)) Then Return

            Dim i As Long, j As Long

            Dim SE_flloads(Lines.Count, 9)
            Dim FlatList As New List(Of System.Object)()
            'a free line load consists of: load case, validity, selection, coord. system (GCS/LCS), direction (X, Y, Z), value (kN/m), LineShape

            Dim itemcount As Long
            Dim item As Rhino.Geometry.Curve

            Dim BoundaryShape As String


            'initialize some variables
            itemcount = 0

            'create load data
            '=================

            For Each item In Lines
                BoundaryShape = GetBoundaryShape(item)
                If BoundaryShape.Split(";")(0) <> "Line" Then
                    Rhino.RhinoApp.WriteLine("KOALA: only straight line segments are supported for free line loads. Different geometries will be skipped.")
                    Continue For
                End If

                SE_flloads(itemcount, 0) = LoadCase
                SE_flloads(itemcount, 1) = Validity
                SE_flloads(itemcount, 2) = Selection
                SE_flloads(itemcount, 3) = CoordSys
                SE_flloads(itemcount, 4) = Direction
                SE_flloads(itemcount, 5) = Distribution
                SE_flloads(itemcount, 6) = LoadValue1
                SE_flloads(itemcount, 7) = LoadValue2
                SE_flloads(itemcount, 8) = BoundaryShape
                itemcount = itemcount + 1
            Next

            'Flatten data for export as simple list

            FlatList.Clear()

            For i = 0 To itemcount - 1
                For j = 0 To 6
                    FlatList.Add(SE_flloads(i, j))
                Next j
            Next i
            DA.SetData(0, FlatList)


        End Sub

        '<Custom additional code> 
        Private Function GetBoundaryShape(ByRef curve As Rhino.Geometry.Curve) As String

            Dim arrPoint As Rhino.Geometry.Point3d
            Dim arrPoints As New Rhino.Collections.Point3dList

            Dim EdgeType As String
            Dim edgenodelist As String

            EdgeType = ""
            edgenodelist = ""

            'Get type of curve and nodelist
            GetTypeAndNodes(curve, EdgeType, arrPoints)
            For Each arrPoint In arrPoints
                If edgenodelist = "" Then
                    edgenodelist = arrPoint.X & ";" & arrPoint.Y & ";" & arrPoint.Z
                Else
                    edgenodelist = edgenodelist & ";" & arrPoint.X & ";" & arrPoint.Y & ";" & arrPoint.Z
                End If
            Next arrPoint

            GetBoundaryShape = EdgeType + ";" + edgenodelist

        End Function

        Private Sub GetTypeAndNodes(ByRef edge As Rhino.Geometry.Curve, ByRef EdgeType As String, ByRef arrPoints As Rhino.Collections.Point3dList)

            Dim arc As Rhino.Geometry.Arc
            Dim nurbscurve As Rhino.Geometry.NurbsCurve

            If edge.IsArc() Then
                EdgeType = "Arc"
                'convert to arc
                edge.TryGetArc(arc)
                arrPoints.Clear()
                arrPoints.Add(arc.StartPoint)
                arrPoints.Add(arc.MidPoint)
                arrPoints.Add(arc.EndPoint)
            ElseIf edge.IsLinear() Then
                EdgeType = "Line"
                arrPoints.Clear()
                arrPoints.Add(edge.PointAtStart)
                arrPoints.Add(edge.PointAtEnd)
            Else
                EdgeType = "Spline"
                'convert to Nurbs curve to get the Edit points
                nurbscurve = edge.ToNurbsCurve
                arrPoints = nurbscurve.GrevillePoints
            End If

        End Sub



        ''' <summary>
        ''' Provides an Icon for every component that will be visible in the User Interface.
        ''' Icons need to be 24x24 pixels.
        ''' </summary>
        Protected Overrides ReadOnly Property Icon() As System.Drawing.Bitmap
            Get
                'You can add image files to your project resources and access them like this:
                ' return Resources.IconForThisComponent;
                Return My.Resources.FreeLineLoad
            End Get
        End Property

        ''' <summary>
        ''' Each component must have a unique Guid to identify it. 
        ''' It is vital this Guid doesn't change otherwise old ghx files 
        ''' that use the old ID will partially fail during loading.
        ''' </summary>
        Public Overrides ReadOnly Property ComponentGuid() As Guid
            Get
                Return New Guid("82294a3a-b741-4dd0-99bb-b02c0365020a")
            End Get
        End Property
    End Class

End Namespace