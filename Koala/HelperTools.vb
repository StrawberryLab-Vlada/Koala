Imports System.IO
Imports Grasshopper.Kernel.Parameters

Module HelperTools

    Public Sub AddOptionstoMenuDOFTransition(menuItem As Param_Integer)
        menuItem.AddNamedValue("Free", 0)
        menuItem.AddNamedValue("Rigid", 1)
        menuItem.AddNamedValue("Flexible", 2)
        menuItem.AddNamedValue("Rigid press only", 3)
        menuItem.AddNamedValue("Rigid tension only", 4)
        menuItem.AddNamedValue("Flexible press only", 5)
        menuItem.AddNamedValue("Flexible tension only", 6)
        menuItem.AddNamedValue("Nonlinear", 7)
    End Sub

    Public Sub AddOptionstoMenuDOFRotation(menuItem As Param_Integer)
        menuItem.AddNamedValue("Free", 0)
        menuItem.AddNamedValue("Rigid", 1)
        menuItem.AddNamedValue("Flexible", 2)
        menuItem.AddNamedValue("Nonlinear", 7)
    End Sub

    Public Sub AddOptionsToMenuLanguage(menuItem As Param_Integer)
        menuItem.AddNamedValue("English", 0)
        menuItem.AddNamedValue("Nederlands", 1)
        menuItem.AddNamedValue("Français", 2)
        menuItem.AddNamedValue("Deutsch", 3)
        menuItem.AddNamedValue("Čeština", 4)
        menuItem.AddNamedValue("Slovenčina", 5)

    End Sub
    Public Function GetStringForLanguage(item As Integer) As String
        Select Case item
            Case 0
                Return "English"
            Case 1
                Return "Nederlands"
            Case 2
                Return "Français"
            Case 3
                Return "Deutsch"
            Case 4
                Return "Čeština"
            Case 5
                Return "Slovenčina"
            Case Else
                Return "English"
        End Select
    End Function

    Public Function GetNumberForUILangauge(item As String) As Long
        Select Case item
            Case "English"
                Return 0
            Case "Nederlands"
                Return 1
            Case "Français"
                Return 2
            Case "Deutsch"
                Return 3
            Case "Čeština"
                Return 4
            Case "Slovenčina"
                Return 5
            Case Else
                Return 0
        End Select
    End Function

    Public Sub AddOptionsToMenuCalculationType(menuItem As Param_Integer)
        menuItem.AddNamedValue("LIN", 0)
        menuItem.AddNamedValue("NEL", 1)
        menuItem.AddNamedValue("STB", 2)
    End Sub

    Public Function GetStringForCalculationType(item As Integer) As String
        Select Case item
            Case 0
                Return "LIN"
            Case 1
                Return "NEL"
            Case 2
                Return "STB"
            Case Else
                Return "LIN"
        End Select
    End Function

    Public Sub AddOptionstoMenuMemberSystemLine(menuItem As Param_Integer)
        menuItem.AddNamedValue("Centre", 1)
        menuItem.AddNamedValue("Top", 2)
        menuItem.AddNamedValue("Bottom", 4)
        menuItem.AddNamedValue("Left", 8)
        menuItem.AddNamedValue("Top left", 10)
        menuItem.AddNamedValue("Bottom left", 12)
        menuItem.AddNamedValue("Right", 16)
        menuItem.AddNamedValue("Top right", 18)
        menuItem.AddNamedValue("Bottom right", 20)

    End Sub

    Public Function GetStringForMemberSystemLineOrPlane(item As Integer) As String
        Select Case item
            Case 1
                Return "Centre"
            Case 2
                Return "Top"
            Case 4
                Return "Bottom"
            Case 8
                Return "Left"
            Case 12
                Return "Top left"
            Case 14
                Return "Bottom left"
            Case 16
                Return "Right"
            Case 18
                Return "Top right"
            Case 20
                Return "Bottom right"
            Case Else
                Return "Centre"
        End Select
    End Function

    Public Sub AddOptionstoMenuMemberSystemPlane(menuItem As Param_Integer)
        menuItem.AddNamedValue("Centre", 1)
        menuItem.AddNamedValue("Top", 2)
        menuItem.AddNamedValue("Bottom", 4)
    End Sub



    Public Sub AddOptionstoMenuFEMNLType2D(menuItem As Param_Integer)
        menuItem.AddNamedValue("none", 0)
        menuItem.AddNamedValue("Press only", 1)
        menuItem.AddNamedValue("Membrane", 2)
    End Sub

    Public Function GetStringForFEMNLType2D(item As Integer) As String
        Select Case item
            Case 0
                Return "none"
            Case 1
                Return "Press only"
            Case 2
                Return "Membrane"
            Case Else
                Return "none"
        End Select
    End Function

    Public Sub AddOptionstoMenuStructureType(menuItem As Param_Integer)
        menuItem.AddNamedValue("Beam", 0)
        menuItem.AddNamedValue("Truss XZ", 1)
        menuItem.AddNamedValue("Frame XZ", 2)
        menuItem.AddNamedValue("Truss XYZ", 3)
        menuItem.AddNamedValue("Frame XYZ", 4)
        menuItem.AddNamedValue("Grid XY", 5)
        menuItem.AddNamedValue("Plate XY", 6)
        menuItem.AddNamedValue("Wall XY", 7)
        menuItem.AddNamedValue("General XYZ", 8)
    End Sub

    Public Function GetStringForStructureType(item As Integer) As String
        Select Case item
            Case 0
                Return "Beam"
            Case 1
                Return "Truss XZ"
            Case 2
                Return "Frame XZ"
            Case 3
                Return "Truss XYZ"
            Case 4
                Return "Frame XYZ"
            Case 5
                Return "Grid XY"
            Case 6
                Return "Plate XY"
            Case 7
                Return "Wall XY"
            Case 8
                Return "General XYZ"
            Case Else
                Return "General XYZ"
        End Select
    End Function

    Public Function GetStringForDOF(item As Integer) As String
        Select Case item
            Case 0
                Return "Free"
            Case 1
                Return "Rigid"
            Case 2
                Return "Flexible"
            Case 3
                Return "Rigid press only"
            Case 4
                Return "Ridig tension only"
            Case 5
                Return "Flexible press only"
            Case 6
                Return "Flexible tension only"

            Case 7
                Return "Nonlinear"
            Case Else
                Return "Free"
        End Select

    End Function

    Public Sub AddOptionsToMenuBeamFEMtype(menuItem As Param_Integer)
        menuItem.AddNamedValue("standard", 0)
        menuItem.AddNamedValue("axial force only", 1)
    End Sub

    Public Function GetStringForBeamFEMtype(item As Integer) As String
        Select Case item
            Case 0
                Return "standard"
            Case 1
                Return "axial force only"
            Case Else
                Return "standard"
        End Select
    End Function

    Public Sub AddOptionsToMenuBeamType(menuItem As Param_Integer)
        menuItem.AddNamedValue("general", 0)
        menuItem.AddNamedValue("beam", 1)
        menuItem.AddNamedValue("column", 2)
        menuItem.AddNamedValue("gable column", 3)
        menuItem.AddNamedValue("secondary column", 4)
        menuItem.AddNamedValue("rafter", 5)
        menuItem.AddNamedValue("purlin", 6)
        menuItem.AddNamedValue("roof bracing", 7)
        menuItem.AddNamedValue("wall bracing", 8)
        menuItem.AddNamedValue("girt", 9)
        menuItem.AddNamedValue("truss chord", 10)
        menuItem.AddNamedValue("truss diagonal", 11)
        menuItem.AddNamedValue("plate rib", 12)
        menuItem.AddNamedValue("beam slab", 13)
    End Sub
    Public Function GetStringForBeamType(item As Integer) As String
        Select Case item
            Case 0
                Return "general"
            Case 1
                Return "beam"
            Case 2
                Return "column"
            Case 3
                Return "gable column"
            Case 4
                Return "secondary column"
            Case 5
                Return "rafter"
            Case 6
                Return "purlin"
            Case 7
                Return "roof bracing"
            Case 8
                Return "wall bracing"
            Case 9
                Return "girt"
            Case 10
                Return "truss chord"
            Case 11
                Return "truss diagonal"
            Case 12
                Return "plate rib"
            Case 13
                Return "beam slab"
            Case Else
                Return "general"
        End Select
    End Function
    Public Sub AddOptionsToMenuCrosslinkType(menuItem As Param_Integer)
        menuItem.AddNamedValue("Fixed", 0)
        menuItem.AddNamedValue("Hinged", 1)
    End Sub

    Public Function GetStringForCrosslinkType(item As Integer) As String
        Select Case item
            Case 0
                Return "Fixed"
            Case 1
                Return "Hinged"
            Case 2
                Return "Coupler"
            Case Else
                Return "Fixed"
        End Select
    End Function


    Public Sub AddOptionstoMenuLinCombiType(menuitem As Param_Integer)
        menuitem.AddNamedValue("Envelope - ultimate", 0)
        menuitem.AddNamedValue("Envelope - serviceability", 1)
        menuitem.AddNamedValue("Linear - ultimate", 2)
        menuitem.AddNamedValue("Linear - serviceability", 3)
        menuitem.AddNamedValue("EN-ULS (STR/GEO) Set B", 4)
        menuitem.AddNamedValue("EN-Accidental 1", 5)
        menuitem.AddNamedValue("EN-Accidental 2", 6)
        menuitem.AddNamedValue("EN-Seismic", 7)
        menuitem.AddNamedValue("EN-SLS Characteristic", 8)
        menuitem.AddNamedValue("EN-SLS Frequent", 9)
        menuitem.AddNamedValue("EN-SLS Quasi-permanent", 10)
        menuitem.AddNamedValue("EN-ULS (STR/GEO) Set C", 11)
    End Sub

    Public Function GetStringForLinCombiType(item As Integer)
        Select Case item
            Case 0
                Return "Envelope - ultimate"
            Case 1
                Return "Envelope - serviceability"
            Case 2
                Return "Linear - ultimate"
            Case 3
                Return "Linear - serviceability"
            Case 4
                Return "EN-ULS (STR/GEO) Set B"
            Case 5
                Return "EN-Accidental 1"
            Case 6
                Return "EN-Accidental 2"
            Case 7
                Return "EN-Seismic"
            Case 8
                Return "EN-SLS Characteristic"
            Case 9
                Return "EN-SLS Frequent"
            Case 10
                Return "EN-SLS Quasi-permanent"
            Case 11
                Return "EN-ULS (STR/GEO) Set C"
            Case Else
                Return "Linear - ultimate"
        End Select
    End Function

    Public Sub AddOptionstomenuItemNLCombiType(menuitem As Param_Integer)
        menuitem.AddNamedValue("Ultimate", 0)
        menuitem.AddNamedValue("Serviceability", 1)
    End Sub

    Public Function GetStringForNLCombiType(item As Integer) As String
        Select Case item
            Case 0
                Return "Ultimate"
            Case 1
                Return "Serviceability"
            Case Else
                Return "Ultimate"
        End Select
    End Function

    Public Sub AddOptionsToMenuDistributionOfLoad(menuitem As Param_Integer)
        menuitem.AddNamedValue("Uniform", 0)
        menuitem.AddNamedValue("Trapez", 1)
    End Sub

    Public Function GetStringFromDistributionOfLoad(item As Integer) As String
        Select Case item
            Case 0
                Return "Uniform"
            Case 1
                Return "Trapez"
            Case Else
                Return "Uniform"
        End Select
    End Function

    Public Sub AddOptionsToMenuDirection(menuitem As Param_Integer)
        menuitem.AddNamedValue("X", 0)
        menuitem.AddNamedValue("Y", 1)
        menuitem.AddNamedValue("Z", 2)
    End Sub

    Public Function GetStringFromDirection(item As Integer) As String
        Select Case item
            Case 0
                Return "X"
            Case 1
                Return "Y"
            Case 2
                Return "Z"
            Case Else
                Return "Z"
        End Select
    End Function


    Public Sub AddOptionsToMenuDirectionMoment(menuitem As Param_Integer)
        menuitem.AddNamedValue("Mx", 0)
        menuitem.AddNamedValue("My", 1)
        menuitem.AddNamedValue("Mz", 2)
    End Sub

    Public Function GetStringFromDirectionMoment(item As Integer) As String
        Select Case item
            Case 0
                Return "Mx"
            Case 1
                Return "My"
            Case 2
                Return "Mz"
            Case Else
                Return "Mz"
        End Select
    End Function

    Public Sub AddOptionsToMenuOrigin(menuitem As Param_Integer)
        menuitem.AddNamedValue("From start", 0)
        menuitem.AddNamedValue("From end", 1)
    End Sub

    Public Function GetStringFromOrigin(item As Integer) As String
        Select Case item
            Case 0
                Return "From start"
            Case 1
                Return "From end"
            Case Else
                Return "From start"
        End Select
    End Function


    Public Sub AddOptionsToMenuCoordDefinition(menuitem As Param_Integer)
        menuitem.AddNamedValue("Rela", 0)
        menuitem.AddNamedValue("Abso", 1)
    End Sub

    Public Function GetStringFromCoordDefinition(item As Integer) As String
        Select Case item
            Case 0
                Return "Rela"
            Case 1
                Return "Abso"
            Case Else
                Return "Rela"
        End Select
    End Function

    Public Sub AddOptionsToMenuCoordSysLine(menuitem As Param_Integer)
        menuitem.AddNamedValue("GCS - Length", 0)
        menuitem.AddNamedValue("GCS - Projection", 1)
        menuitem.AddNamedValue("LCS", 2)
    End Sub

    Public Function GetStringFromCoordSysLine(item As Integer) As String
        Select Case item
            Case 0
                Return "GCS - Length"
            Case 1
                Return "GCS - Projection"
            Case 2
                Return "LCS"
            Case 3
                Return "Member LCS"
            Case 4
                Return "GCS"
            Case Else
                Return "GCS - Length"
        End Select
    End Function


    Public Sub AddOptionsToMenuCoordSysPoint(menuitem As Param_Integer)
        menuitem.AddNamedValue("GCS", 0)
        menuitem.AddNamedValue("LCS", 1)
    End Sub

    Public Function GetStringFromCoordSysPoint(item As Integer) As String
        Select Case item
            Case 0
                Return "GCS"
            Case 1
                Return "LCS"
            Case Else
                Return "GCS"
        End Select
    End Function


    Public Sub AddOptionsToMenuValidity(menuitem As Param_Integer)
        menuitem.AddNamedValue("All", 0)
        menuitem.AddNamedValue("-Z", 1)
        menuitem.AddNamedValue("+Z", 2)
        menuitem.AddNamedValue("From-to", 3)
        menuitem.AddNamedValue("Z=0", 4)
        menuitem.AddNamedValue("-Z (incl. 0)", 5)
        menuitem.AddNamedValue("+Z (incl. 0)", 6)
    End Sub


    Public Function GetStringFromuValidity(item As Integer) As String
        Select Case item
            Case 0
                Return "All"
            Case 1
                Return "-Z"
            Case 2
                Return "+Z"
            Case 3
                Return "From-to"
            Case 4
                Return "Z=0"
            Case 5
                Return "-Z (incl. 0)"
            Case 6
                Return "+Z (incl. 0)"
            Case Else
                Return "All"
        End Select
    End Function


    Public Sub AddOptionsToMenuSelection(menuitem As Param_Integer)
        menuitem.AddNamedValue("Auto", 0)
        menuitem.AddNamedValue("Select", 1)

    End Sub
    Public Function GetStringFromMenuSelection(item As Integer) As String
        Select Case item
            Case 0
                Return "Auto"
            Case 1
                Return "Select"
            Case Else
                Return "Auto"
        End Select
    End Function


    Public Sub AddOptionsToMenuCoordSysFreeLine(menuitem As Param_Integer)
        menuitem.AddNamedValue("GCS - Length", 0)
        menuitem.AddNamedValue("GCS - Projection", 1)
        menuitem.AddNamedValue("Member LCS", 3)
    End Sub
    Public Sub AddOptionsToMenuBeamNLTypePT(menuitem As Param_Integer)
        menuitem.AddNamedValue("Press only", 0)
        menuitem.AddNamedValue("Tension only", 1)
    End Sub

    Public Function GetStringFromBeamNLTypePT(item As Integer) As String
        Select Case item
            Case 0
                Return "Press only"
            Case 1
                Return "Tension only"
            Case Else
                Return "Press only"
        End Select
    End Function
    Public Sub AddOptionsToMenuCoordSysFreePoint(menuitem As Param_Integer)
        menuitem.AddNamedValue("GCS", 4)
        menuitem.AddNamedValue("Member LCS", 3)
    End Sub

    Public Sub AddOptionsToMenuBeamNLGapDirection(menuitem As Param_Integer)
        menuitem.AddNamedValue("Both directions", 0)
        menuitem.AddNamedValue("Press only", 1)
        menuitem.AddNamedValue("Tension only", 1)
    End Sub

    Public Function GetStringFromBeamNLGapDirection(item As Integer) As String
        Select Case item
            Case 0
                Return "Both directions"
            Case 1
                Return "Press only"
            Case 2
                Return "Tension only"
            Case Else
                Return "Both directions"
        End Select
    End Function
    Public Sub AddOptionsToMenuBeamNLGapPosition(menuitem As Param_Integer)
        menuitem.AddNamedValue("Begin", 0)
        menuitem.AddNamedValue("End", 1)

    End Sub

    Public Function GetStringFromBeamNLGapPosition(item As Integer) As String
        Select Case item
            Case 0
                Return "Begin"
            Case 1
                Return "End"
            Case Else
                Return "Begin"
        End Select
    End Function


    Public Sub AddOptionsToMenuBeamNLLimitForceType(menuitem As Param_Integer)
        menuitem.AddNamedValue("Buckling ( results zero )", 0)
        menuitem.AddNamedValue("Plastic yielding", 1)

    End Sub

    Public Function GetStringFromBeamNLLimitForceType(item As Integer) As String
        Select Case item
            Case 0
                Return "Buckling ( results zero )"
            Case 1
                Return "Plastic yielding"
            Case Else
                Return "Buckling ( results zero )"
        End Select
    End Function
    Public Sub AddOptionsToMenuBeamNLLimnitForceDirection(menuitem As Param_Integer)
        menuitem.AddNamedValue("Limit compression", 0)
        menuitem.AddNamedValue("Limit tension", 1)

    End Sub

    Public Function GetStringFromBeamNLLimnitForceDirection(item As Integer) As String
        Select Case item
            Case 0
                Return "Limit compression"
            Case 1
                Return "Limit tension"
            Case Else
                Return "Limit compression"
        End Select
    End Function


    Public Sub AddOptionsToMenuHingePosition(menuitem As Param_Integer)
        menuitem.AddNamedValue("Begin", 0)
        menuitem.AddNamedValue("End", 1)
        menuitem.AddNamedValue("Both", 2)

    End Sub

    Public Function GetStringFromHingePosition(item As Integer) As String
        Select Case item
            Case 0
                Return "Begin"
            Case 1
                Return "End"
            Case 2
                Return "Both"
            Case Else
                Return "Both"
        End Select
    End Function

    Public Sub AddOptionstoMenuSwapOrientation(menuItem As Param_Integer)
        menuItem.AddNamedValue("No", 0)
        menuItem.AddNamedValue("Yes", 1)
    End Sub

    Public Function GetStringFromSwapOrientation(item As Integer) As String
        Select Case item
            Case 0
                Return "No"
            Case 1
                Return "Yes"
            Case Else
                Return "No"
        End Select
    End Function

    Public Sub AddOptionsToMenuPanelType(menuItem As Param_Integer)
        menuItem.AddNamedValue("To panel nodes", 0)
        menuItem.AddNamedValue("To panel edges", 1)
        menuItem.AddNamedValue("To panel edges and beams", 2)
    End Sub
    Public Function GetStringForPanelType(item As Integer) As String
        Select Case item
            Case 0
                Return "To panel nodes"
            Case 1
                Return "To panel edges"
            Case 2
                Return "To panel edges and beams"

            Case Else
                Return "To panel edges and beams"
        End Select
    End Function


    Public Sub AddOptionsToMenuTransferMethod(menuItem As Param_Integer)
        menuItem.AddNamedValue("Accurate(FEM),fixed link with beams", 0)
        menuItem.AddNamedValue("Standard", 1)
        menuItem.AddNamedValue("Accurate(FEM),hinged link with beams", 2)
        menuItem.AddNamedValue("Tributary area", 3)
    End Sub
    Public Function GetStringForTransferMethod(item As Integer) As String
        Select Case item
            Case 0
                Return "Accurate(FEM),fixed link with beams"
            Case 1
                Return "Standard"
            Case 2
                Return "Accurate(FEM),hinged link with beams"
            Case 3
                Return "Tributary area"
            Case Else
                Return "Standard"
        End Select
    End Function

    Sub AddOptionsToMenuSupportingMembersValidity(menuItem As Param_Integer)
        menuItem.AddNamedValue("All", 0)
        menuItem.AddNamedValue("-Z", 1)
        menuItem.AddNamedValue("+Z", 2)
    End Sub
    Public Function GetStringForSupportingMembersValidity(item As Integer) As String
        Select Case item
            Case 0
                Return "All"
            Case 1
                Return "-Z"
            Case 2
                Return "+Z"

            Case Else
                Return "All"
        End Select
    End Function

    Public Sub AddOptionsToMenuTransferDirection(menuItem As Param_Integer)
        menuItem.AddNamedValue("X (LCS panel)", 0)
        menuItem.AddNamedValue("Y (LCS panel)", 1)
        menuItem.AddNamedValue("all (LCS panel)", 2)
    End Sub
    Public Function GetStringForTransferDirection(item As Integer) As String
        Select Case item
            Case 0
                Return "X (LCS panel)"
            Case 1
                Return "Y (LCS panel)"
            Case 2
                Return "all (LCS panel)"

            Case Else
                Return "all (LCS panel)"
        End Select
    End Function

    Public Sub AddOptionsToMenuNLFunctionType(menuItem As Param_Integer)
        menuItem.AddNamedValue("Translation", 0)
        menuItem.AddNamedValue("Rotation", 1)
        menuItem.AddNamedValue("Nonlinear subsoil", 2)
    End Sub
    Public Function GetStringForitemNLFunctionType(item As Integer) As String
        Select Case item
            Case 0
                Return "Translation"
            Case 1
                Return "Rotation"
            Case 2
                Return "Nonlinear subsoil"
            Case Else
                Return "Translation"
        End Select
    End Function


    Public Sub AddOptionsToMenuNLFunctionEndType(menuItem As Param_Integer)
        menuItem.AddNamedValue("Rigid", 0)
        menuItem.AddNamedValue("Free", 1)
        menuItem.AddNamedValue("Flexible", 2)
    End Sub

    Public Function GetStringForitemNLFunctionEndType(item As Integer) As String
        Select Case item
            Case 0
                Return "Rigid"
            Case 1
                Return "Free"
            Case 2
                Return "Flexible"
            Case Else
                Return "Rigid"
        End Select
    End Function

    Public Sub AddOptionstoMenuC1ztype(menuItem As Param_Integer)
        menuItem.AddNamedValue("Flexible", 0)
        menuItem.AddNamedValue("Nonlinear function", 1)
    End Sub

    Public Function GetStringForC1ztype(item As Integer) As String
        Select Case item
            Case 0
                Return "Flexible"
            Case 1
                Return "Nonlinear function"

            Case Else
                Return "Flexible"
        End Select
    End Function


    Public Sub AddOptionsToMenuBeamNLCableInitialMesh(menuitem As Param_Integer)
        menuitem.AddNamedValue("Straight", 0)
        menuitem.AddNamedValue("Calculated", 1)

    End Sub

    Public Function GetStringFromBeamNLCableInitialMesh(item As Integer) As String
        Select Case item
            Case 0
                Return "Straight"
            Case 1
                Return "Calculated"
            Case Else
                Return "Straight"
        End Select
    End Function

    Public Function GetExistingNode(arrPoint As Rhino.Geometry.Point3d, nodes(,) As String, nnodes As Long, epsilon As Double)
        Dim currentnode
        'Start with node not found, loop through all the nodes until one is found within tolerance
        'Not in use now, as it's quite slow compared to within SCIA Engineer
        GetExistingNode = -1
        currentnode = 1

        If nnodes Mod 50 = 0 And nnodes > 100 Then
            Rhino.RhinoApp.WriteLine("Searching node " & CStr(nnodes))
            'rhino.Display.DrawEventArgs
        End If

        While GetExistingNode = -1 And currentnode <= nnodes
            If Math.Abs(arrPoint.X - nodes(currentnode - 1, 1)) < epsilon Then
                If Math.Abs(arrPoint.Y - nodes(currentnode - 1, 2)) < epsilon Then
                    If Math.Abs(arrPoint.Z - nodes(currentnode - 1, 3)) < epsilon Then
                        GetExistingNode = currentnode
                    End If
                End If
            End If
            currentnode += 1

        End While

    End Function


    Public Sub GetTypeAndNodes(ByRef line As Rhino.Geometry.Curve, ByRef LineType As String, ByRef arrPoints As Rhino.Collections.Point3dList)

        Dim arc As Rhino.Geometry.Arc
        Dim nurbscurve As Rhino.Geometry.NurbsCurve
        Dim i As Integer

        If line.IsCircle Then
            Dim circle As Rhino.Geometry.Circle
            line.TryGetCircle(circle)
            LineType = "Circle"
            arrPoints.Clear()
            Dim PointOnCircle As Rhino.Geometry.Point3d
            PointOnCircle = circle.PointAt(0.0)
            arrPoints.Add(PointOnCircle)
            arrPoints.Add(circle.Center)


        ElseIf line.IsLinear() Then
            LineType = "Line"
            arrPoints.Clear()
            arrPoints.Add(line.PointAtStart)
            arrPoints.Add(line.PointAtEnd)
        ElseIf line.IsPolyline Then
            LineType = "Polyline"
            arrPoints.Clear()
            Dim polyline As Rhino.Geometry.Polyline
            line.TryGetPolyline(polyline)
            For i = 0 To polyline.Count - 1
                arrPoints.Add(polyline.ElementAt(i))
            Next i


        ElseIf line.IsArc() Then
            LineType = "Arc"
            'convert to arc
            line.TryGetArc(arc)
            arrPoints.Clear()
            arrPoints.Add(arc.StartPoint)
            arrPoints.Add(arc.MidPoint)
            arrPoints.Add(arc.EndPoint)
            'Dim arc As Rhino.Geometry.Arc

        Else
            LineType = "Spline"
            'convert to Nurbs curve to get the Edit points
            nurbscurve = line.ToNurbsCurve
            arrPoints = nurbscurve.GrevillePoints
        End If

    End Sub

    Private Function ConCat_ht(h, t)
        ConCat_ht = "<h" & h & " t=""" & t & """/>"
    End Function
    Private Function ConCat_hh(h, N)
        ConCat_hh = "<h" & h & " h=""" & N & """/>"
    End Function
    Private Function ConCat_pv(p, v)
        ConCat_pv = "<p" & p & " v=""" & v & """/>"
    End Function
    Private Function ConCat_pvt(p, v, t)
        ConCat_pvt = "<p" & p & " v=""" & v & """ t=""" & t & """/>"
    End Function
    Private Function ConCat_pvx(p, v, x)
        ConCat_pvx = "<p" & p & " v=""" & v & """ x=""" & x & """/>"
    End Function

    Private Function ConCat_pv1v2x(p, v1, v2, x)
        ConCat_pv1v2x = "<p" & p & " v1=""" & v1 & """ v2=""" & v2 & """ x=""" & x & """/>"
    End Function


    Private Function ConCat_pn(p, N)
        ConCat_pn = "<p" & p & " n=""" & N & """/>"
    End Function
    Private Function ConCat_pin(p, i, N)
        ConCat_pin = "<p" & p & " i=""" & i & """ n=""" & N & """/>"
    End Function
    Private Function ConCat_opentable(p, t)
        ConCat_opentable = "<p" & p & " t=""" & t & """>"
    End Function
    Private Function ConCat_closetable(p)
        ConCat_closetable = "</p" & p & ">"
    End Function
    Private Function ConCat_row(id)
        ConCat_row = "<row id=""" & CStr(id) & """>"
    End Function



    '<Custom additional code> 

    'global variables for this component
    '-----------------------------------
    Public gl_UILanguage As String 'required until free loads geometry's definition is language-neutral in SCIA Engineer's XML
    Public UILanguageNumber As Long


    Public Function GetExistingNode(arrPoint, nodes(,), nnodes, epsilon)
        Dim currentnode
        'Start with node not found, loop through all the nodes until one is found within tolerance
        'Not in use now, as it's quite slow compared to within SCIA Engineer
        GetExistingNode = -1
        currentnode = 0

        If nnodes Mod 50 = 0 And nnodes > 100 Then
            Rhino.RhinoApp.WriteLine("Searching node " & CStr(nnodes))
            'rhino.Display.DrawEventArgs
        End If

        While GetExistingNode = -1 And currentnode < nnodes
            If System.Math.Abs(arrPoint(0) - nodes(currentnode, 1)) < epsilon Then
                If System.Math.Abs(arrPoint(1) - nodes(currentnode, 2)) < epsilon Then
                    If System.Math.Abs(arrPoint(2) - nodes(currentnode, 3)) < epsilon Then
                        GetExistingNode = currentnode
                    Else
                        currentnode += 1
                    End If
                Else
                    currentnode += 1
                End If
            Else
                currentnode += 1
            End If

        End While


    End Function

    Private DupNodeDict As Dictionary(Of String, String) = Nothing
    Private isNodeDuplicate As Dictionary(Of String, Boolean) = Nothing

    Public Sub CreateXMLFile(FileName As String, StructureType As String, Materials As List(Of String), UILanguage As String, MeshSize As Double, in_sections As List(Of String), in_nodes As List(Of String), in_beams As List(Of String), in_surfaces As List(Of String),
                             in_openings As List(Of String), in_nodesupports As List(Of String), in_edgesupports As List(Of String), in_lcases As List(Of String), in_lgroups As List(Of String), in_lloads As List(Of String), in_sloads As List(Of String),
                             in_fploads As List(Of String), in_flloads As List(Of String), in_fsloads As List(Of String), in_hinges As List(Of String), in_edgeLoads As List(Of String), in_pointLoadsPoints As List(Of String), in_pointLoadsBeams As List(Of String),
                             Scale As String, in_LinCombinations As List(Of String), in_NonLinCombinations As List(Of String), in_StabCombinations As List(Of String),
                             in_CrossLinks As List(Of String), in_presstensionElem As List(Of String), in_gapElem As List(Of String), in_limitforceElem As List(Of String), projectInfo As List(Of String), in_layers As List(Of String),
                             in_BeamLineSupport As List(Of String), in_PointSupportOnBeam As List(Of String), in_Subsoils As List(Of String), in_SurfaceSupports As List(Of String), in_loadpanels As List(Of String), in_pointMomentPoint As List(Of String),
                             in_pointMomentBeam As List(Of String), in_lineMomentBeam As List(Of String), in_lineMomentEdge As List(Of String), in_freePointMoment As List(Of String), in_nonlinearfunctions As List(Of String),
                             RemDuplNodes As Boolean, Tolerance As Double, in_slabinternalEdges As List(Of String), in_RigidArms As List(Of String), in_Cables As List(Of String))
        Dim i As Long, j As Long


        Dim SE_sections(1000, 3) As String 'a section consists of: Name, Definition, Material

        Dim SE_nodes(100000, 3) As String 'a node consists of: Name, X, Y, Z
        Dim SE_beams(100000, 13) As String 'a beam consists of: Name, Section, Layer, LineShape, LCSType, LCSParam1, LCSParam2, LCSParam3
        'If LCSType = 0 > Standard definition of LCS with an angle > LCSParam1 is the angle in radian
        'If LCSType = 2 > Definition of LCS through a vector for local Z > LCSParam1/2/3 are the X, Y, Z components of the vector

        Dim SE_surfaces(100000, 12) As String 'a surface consists of: Name, Type, Material, Thickness, Layer, BoundaryShape, InternalNodes
        Dim SE_openings(100000, 2) As String 'a surface consists of: Name, Reference surface, BoundaryShape

        Dim SE_nodesupports(100000, 19) As String 'a nodal support consists of: Node name, X, Y, Z, RX, RY, RZ - 0 is free, 1 is blocked DOF
        Dim SE_edgesupports(100000, 25) As String 'an edge support consists of: Reference name, reference type, edge number, X, Y, Z, RX, RY, RZ - 0 is free, 1 is blocked DOF
        Dim SE_lcases(100000, 2) As String 'a load case consists of: Load case name, type (SW, Permanent, Variable), load group
        Dim SE_lgroups(100000, 2) As String 'a load group consists of: Load group name, type (Permanent, Variable), relation (Standard, Exclusive, Together)
        Dim SE_lloads(100000, 13) As String 'a beam line load consists of: Load case, Beam name, coord sys (GCS/LCS), direction (X, Y, Z), Distribution,value1 (kN/m),value2,coord,pos1,pos2
        Dim SE_sloads(100000, 4) As String 'a surface load consists of: Load case, Surface name, coord sys (GCS/LCS), direction (X, Y, Z), value (kN/m)
        Dim SE_fploads(100000, 10) As String 'a free point load consists of: Load case, Selection, Validity, coord sys (GCS/LCS), direction (X, Y, Z), value (kN), PointX, PointY, PointZ
        Dim SE_flloads(100000, 11) As String 'a free line load consists of: load case, validity, selection, coord. system (GCS/LCS), direction (X, Y, Z), value (kN/m), LineShape
        Dim SE_fsloads(100000, 8) As String 'a free surface load consists of: load case, validity, selection, coord. system (GCS/LCS), direction (X, Y, Z), value (kN/m^2), BoundaryShape
        Dim SE_hinges(100000, 14) As String 'a hinge consists of: Beam name, ux, uy, uz, phix, phiy, phiz (0: free, 1: fixed), Position (Begin/End/Both)
        Dim SE_eLoads(100000, 15) As String 'a hinge consists of: Beam name, ux, uy, uz, phix, phiy, phiz (0: free, 1: fixed), Position (Begin/End/Both)
        Dim SE_pointLoadPoint(100000, 6) As String 'a hinge consists of: Beam name, ux, uy, uz, phix, phiy, phiz (0: free, 1: fixed), Position (Begin/End/Both)
        Dim SE_pointLoadBeam(100000, 12) As String 'a hinge consists of: Beam name, ux, uy, uz, phix, phiy, phiz (0: free, 1: fixed), Position (Begin/End/Both)
        Dim SE_lincombinations(100000, 3) As String
        Dim SE_nonlincombinations(100000, 4) As String
        Dim SE_stabcombinations(100000, 2) As String
        Dim SE_Crosslinks(100000, 3) As String
        Dim SE_gapselem(100000, 4) As String
        Dim SE_presstensionelems(100000, 2) As String
        Dim SE_limforceelem(1000000, 4) As String
        Dim SE_layers(1000000, 3) As String
        Dim SE_layersCount As Integer = 0
        Dim SE_beamLineSupports(100000, 23) As String 'a beam line support consists of: Reference name, reference type, edge number, X, Y, Z, RX, RY, RZ - 0 is free, 1 is blocked DOF
        Dim SE_pointSupportOnBeam(100000, 24) As String
        Dim SE_subsoil(100000, 9) As String
        Dim SE_surfaceSupport(100000, 2) As String
        Dim SE_LoadPanels(100000, 7) As String
        Dim SE_PointMomentPointNode(100000, 5) As String
        Dim SE_pointMomentBeam(100000, 10) As String
        Dim SE_lineMomentBeam(100000, 10) As String
        Dim SE_lineMomentEdge(100000, 13) As String
        Dim SE_fMomentPointloads(100000, 10) As String
        Dim SE_NonlinearFunctions(100000, 5) As String
        Dim SE_SlabInternalEdges(100000, 3) As String
        Dim SE_RigidArms(100000, 5) As String
        Dim SE_Cables(100000, 6) As String

        Dim SE_meshsize As Double

        Dim beam_material As Long

        Dim surface_material As Long, surface_layer As Long

        Dim nodecount As Long, beamcount As Long, surfacecount As Long, openingcount As Long
        Dim sectioncount As Long, nodesupportcount As Long, edgesupportcount As Long
        Dim lcasecount As Long, lgroupcount As Long, lloadcount As Long, sloadcount As Long, fploadcount As Long, flloadcount As Long, fsloadcount As Long
        Dim hingecount As Long, eloadscount As Long, pointLoadpointCount As Long, pointLoadbeamCount As Long, lincominationcount As Long, nonlincominationcount As Long
        Dim stabcombicount As Long, crosslinkscount As Long, gapsnr As Long, ptelemnsnr As Long, lfelemnsnr As Long, nBeamLineSupport As Long, nPointSupportonBeam As Long, nSubsoils As Long, nSurfaceSupports As Long, nloadPanels As Long

        Dim pointMomentpointCount As Long, pointMomentbeamCount As Long, lineMomentBeamCount As Long, lineMomentEdgeCount As Long, fpointmomentloadcount As Long, nlfunctionscount As Long, slabInternalEdgesCount As Long, RigidArmsCount As Long, CablesCount As Long

        Dim stopWatch As New System.Diagnostics.Stopwatch()
        Dim time_elapsed As Double
        Dim oSB As System.Text.StringBuilder 'required for fast string building
        Dim objstream As String





        'initialize stopwatch
        stopWatch.Start()

        'initialize some variables
        beam_material = 1
        surface_material = 1
        surface_layer = 1
        nodecount = 0
        beamcount = 0
        surfacecount = 0
        sectioncount = 0
        nodesupportcount = 0
        edgesupportcount = 0
        lcasecount = 0
        lgroupcount = 0
        lloadcount = 0
        sloadcount = 0
        fploadcount = 0
        flloadcount = 0
        fsloadcount = 0
        hingecount = 0
        eloadscount = 0
        pointLoadbeamCount = 0
        pointLoadpointCount = 0
        stabcombicount = 0
        lincominationcount = 0
        nonlincominationcount = 0
        crosslinkscount = 0
        lfelemnsnr = 0
        gapsnr = 0
        ptelemnsnr = 0

        'make some input parameters global variables for this component
        gl_UILanguage = UILanguage
        UILanguageNumber = GetNumberForUILangauge(gl_UILanguage)

        'show that it's busy
        Rhino.RhinoApp.WriteLine("")
        Rhino.RhinoApp.WriteLine("===== KOALA SCIA Engineer plugin - model creation =====")

        'Define the StringBuilder capacity
        oSB = New System.Text.StringBuilder(100)

        Rhino.RhinoApp.WriteLine("Generating model data...")

        'get model data (de-serialize)
        '=============================
        If ((in_sections IsNot Nothing)) Then
            sectioncount = in_sections.Count / 4
            Rhino.RhinoApp.WriteLine("Number of sections: " & sectioncount)
            For i = 0 To sectioncount - 1
                For j = 0 To 3
                    SE_sections(i, j) = in_sections(j + i * 4)
                Next j
            Next i
        End If



        DupNodeDict = New Dictionary(Of String, String)()
        isNodeDuplicate = New Dictionary(Of String, Boolean)()
        If (in_nodes IsNot Nothing) Then

            nodecount = in_nodes.Count / 4
            Rhino.RhinoApp.WriteLine("Number of nodes: " & nodecount)
            For i = 0 To nodecount - 1
                SE_nodes(i, 0) = in_nodes(i * 4)
                SE_nodes(i, 1) = in_nodes(1 + i * 4) * Scale
                SE_nodes(i, 2) = in_nodes(2 + i * 4) * Scale
                SE_nodes(i, 3) = in_nodes(3 + i * 4) * Scale
                If Not DupNodeDict.ContainsKey(SE_nodes(i, 0)) Then
                    DupNodeDict.Add(SE_nodes(i, 0), SE_nodes(i, 0))
                    isNodeDuplicate.Add(SE_nodes(i, 0), False)
                Else
                    Rhino.RhinoApp.WriteLine("Model contains duplicity nodes")
                End If

            Next i

            If (RemDuplNodes) Then
                For i = 0 To nodecount - 1
                    For j = i + 1 To nodecount - 1
                        If (Not isNodeDuplicate(SE_nodes(j, 0))) Then
                            If System.Math.Abs(SE_nodes(i, 1) - SE_nodes(j, 1)) < Tolerance Then
                                If System.Math.Abs(SE_nodes(i, 2) - SE_nodes(j, 2)) < Tolerance Then
                                    If System.Math.Abs(SE_nodes(i, 3) - SE_nodes(j, 3)) < Tolerance Then
                                        DupNodeDict(SE_nodes(j, 0)) = SE_nodes(i, 0)
                                        isNodeDuplicate(SE_nodes(j, 0)) = True
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next
            End If
        End If

        If (in_beams IsNot Nothing) Then
            beamcount = in_beams.Count / 13
            Rhino.RhinoApp.WriteLine("Number of beams: " & beamcount)
            For i = 0 To beamcount - 1
                For j = 0 To 12
                    SE_beams(i, j) = in_beams(j + i * 13)
                Next j
            Next i
        End If

        If (in_surfaces IsNot Nothing) Then
            surfacecount = in_surfaces.Count / 12
            Rhino.RhinoApp.WriteLine("Number of surfaces: " & surfacecount)
            For i = 0 To surfacecount - 1
                For j = 0 To 11
                    SE_surfaces(i, j) = in_surfaces(j + i * 12)
                Next j
            Next i
        End If


        If (in_loadpanels IsNot Nothing) Then
            nloadPanels = in_loadpanels.Count / 8
            Rhino.RhinoApp.WriteLine("Number of loadpanels: " & nloadPanels)
            For i = 0 To nloadPanels - 1
                For j = 0 To 7
                    SE_LoadPanels(i, j) = in_loadpanels(j + i * 8)
                Next j
            Next i
        End If

        If (in_openings IsNot Nothing) Then
            openingcount = in_openings.Count / 3
            Rhino.RhinoApp.WriteLine("Number of openings: " & openingcount)
            For i = 0 To openingcount - 1
                For j = 0 To 2
                    SE_openings(i, j) = in_openings(j + i * 3)
                Next j
            Next i
        End If

        If (in_slabinternalEdges IsNot Nothing) Then
            slabInternalEdgesCount = in_slabinternalEdges.Count / 3
            Rhino.RhinoApp.WriteLine("Number of internal edges: " & slabInternalEdgesCount)
            For i = 0 To slabInternalEdgesCount - 1
                For j = 0 To 2
                    SE_SlabInternalEdges(i, j) = in_slabinternalEdges(j + i * 3)
                Next j
            Next i
        End If

        If (in_RigidArms IsNot Nothing) Then
            RigidArmsCount = in_RigidArms.Count / 5
            Rhino.RhinoApp.WriteLine("Number of RigidArms: " & RigidArmsCount)
            For i = 0 To RigidArmsCount - 1
                For j = 0 To 4
                    SE_RigidArms(i, j) = in_RigidArms(j + i * 5)
                Next j
            Next i
        End If

        If (in_nodesupports IsNot Nothing) Then
            nodesupportcount = in_nodesupports.Count / 20
            Rhino.RhinoApp.WriteLine("Number of node supports: " & nodesupportcount)
            For i = 0 To nodesupportcount - 1
                For j = 0 To 19
                    SE_nodesupports(i, j) = in_nodesupports(j + i * 20)
                Next j
            Next i
        End If

        If (in_edgesupports IsNot Nothing) Then
            edgesupportcount = in_edgesupports.Count / 25
            Rhino.RhinoApp.WriteLine("Number of edge supports: " & edgesupportcount)
            For i = 0 To edgesupportcount - 1
                For j = 0 To 24
                    SE_edgesupports(i, j) = in_edgesupports(j + i * 25)
                Next j
            Next i
        End If

        If (in_lcases IsNot Nothing) Then
            lcasecount = in_lcases.Count / 3
            Rhino.RhinoApp.WriteLine("Number of load cases: " & lcasecount)
            For i = 0 To lcasecount - 1
                For j = 0 To 2
                    SE_lcases(i, j) = in_lcases(j + i * 3)
                Next j
            Next i
        End If

        If (in_lgroups IsNot Nothing) Then
            lgroupcount = in_lgroups.Count / 3
            Rhino.RhinoApp.WriteLine("Number of load groups: " & lgroupcount)
            For i = 0 To lgroupcount - 1
                For j = 0 To 2
                    SE_lgroups(i, j) = in_lgroups(j + i * 3)
                Next j
            Next i
        End If

        If (in_lloads IsNot Nothing) Then
            lloadcount = in_lloads.Count / 13
            Rhino.RhinoApp.WriteLine("Number of beam line loads: " & lloadcount)
            For i = 0 To lloadcount - 1
                For j = 0 To 12
                    SE_lloads(i, j) = in_lloads(j + i * 13)
                Next j
            Next i
        End If
        If (in_edgeLoads IsNot Nothing) Then
            eloadscount = in_edgeLoads.Count / 15
            Rhino.RhinoApp.WriteLine("Number of beam line loads: " & eloadscount)
            For i = 0 To eloadscount - 1
                For j = 0 To 14
                    SE_eLoads(i, j) = in_edgeLoads(j + i * 15)
                Next j
            Next i
        End If

        If (in_lineMomentEdge IsNot Nothing) Then
            lineMomentEdgeCount = in_lineMomentEdge.Count / 13
            Rhino.RhinoApp.WriteLine("Number of beam line loads: " & eloadscount)
            For i = 0 To lineMomentEdgeCount - 1
                For j = 0 To 12
                    SE_lineMomentEdge(i, j) = in_lineMomentEdge(j + i * 13)
                Next j
            Next i
        End If

        If (in_pointLoadsPoints IsNot Nothing) Then
            pointLoadpointCount = in_pointLoadsPoints.Count / 6
            Rhino.RhinoApp.WriteLine("Number of beam line loads: " & pointLoadpointCount)
            For i = 0 To pointLoadpointCount - 1
                For j = 0 To 5
                    SE_pointLoadPoint(i, j) = in_pointLoadsPoints(j + i * 6)
                Next j
            Next i
        End If
        If (in_pointMomentPoint IsNot Nothing) Then
            pointMomentpointCount = in_pointMomentPoint.Count / 5
            Rhino.RhinoApp.WriteLine("Number of beam line loads: " & pointLoadpointCount)
            For i = 0 To pointMomentpointCount - 1
                For j = 0 To 4
                    SE_PointMomentPointNode(i, j) = in_pointMomentPoint(j + i * 5)
                Next j
            Next i
        End If
        If (in_pointLoadsBeams IsNot Nothing) Then
            pointLoadbeamCount = in_pointLoadsBeams.Count / 12
            Rhino.RhinoApp.WriteLine("Number of beam line loads: " & lloadcount)
            For i = 0 To pointLoadbeamCount - 1
                For j = 0 To 11
                    SE_pointLoadBeam(i, j) = in_pointLoadsBeams(j + i * 12)
                Next j
            Next i
        End If

        If (in_pointMomentBeam IsNot Nothing) Then
            pointMomentbeamCount = in_pointMomentBeam.Count / 10
            Rhino.RhinoApp.WriteLine("Number of beam line loads: " & lloadcount)
            For i = 0 To pointMomentbeamCount - 1
                For j = 0 To 9
                    SE_pointMomentBeam(i, j) = in_pointMomentBeam(j + i * 10)
                Next j
            Next i
        End If


        If (in_lineMomentBeam IsNot Nothing) Then
            lineMomentBeamCount = in_lineMomentBeam.Count / 11
            Rhino.RhinoApp.WriteLine("Number of beam line loads: " & lloadcount)
            For i = 0 To lineMomentBeamCount - 1
                For j = 0 To 10
                    SE_lineMomentBeam(i, j) = in_lineMomentBeam(j + i * 11)
                Next j
            Next i
        End If


        If (in_sloads IsNot Nothing) Then
            sloadcount = in_sloads.Count / 5
            Rhino.RhinoApp.WriteLine("Number of surface loads: " & sloadcount)
            For i = 0 To sloadcount - 1
                For j = 0 To 4
                    SE_sloads(i, j) = in_sloads(j + i * 5)
                Next j
            Next i
        End If

        If (in_fploads IsNot Nothing) Then
            fploadcount = in_fploads.Count / 11
            Rhino.RhinoApp.WriteLine("Number of free point loads: " & fploadcount)
            For i = 0 To fploadcount - 1
                For j = 0 To 10
                    SE_fploads(i, j) = in_fploads(j + i * 11)
                Next j
            Next i
        End If

        If (in_freePointMoment IsNot Nothing) Then
            fpointmomentloadcount = in_freePointMoment.Count / 11
            Rhino.RhinoApp.WriteLine("Number of free point loads: " & fpointmomentloadcount)
            For i = 0 To fpointmomentloadcount - 1
                For j = 0 To 10
                    SE_fMomentPointloads(i, j) = in_freePointMoment(j + i * 11)
                Next j
            Next i
        End If

        If (in_flloads IsNot Nothing) Then
            flloadcount = in_flloads.Count / 11
            Rhino.RhinoApp.WriteLine("Number of free line loads: " & flloadcount)
            For i = 0 To flloadcount - 1
                For j = 0 To 10
                    SE_flloads(i, j) = in_flloads(j + i * 11)
                Next j
            Next i
        End If

        If (in_fsloads IsNot Nothing) Then
            fsloadcount = in_fsloads.Count / 9
            Rhino.RhinoApp.WriteLine("Number of free surface loads: " & fsloadcount)
            For i = 0 To fsloadcount - 1
                For j = 0 To 8
                    SE_fsloads(i, j) = in_fsloads(j + i * 9)
                Next j
            Next i
        End If

        If (in_hinges IsNot Nothing) Then
            hingecount = in_hinges.Count / 14
            Rhino.RhinoApp.WriteLine("Number of hinges: " & hingecount)
            For i = 0 To hingecount - 1
                For j = 0 To 13
                    SE_hinges(i, j) = in_hinges(j + i * 14)
                Next j
            Next i
        End If

        If (in_CrossLinks IsNot Nothing) Then
            crosslinkscount = in_CrossLinks.Count / 3
            Rhino.RhinoApp.WriteLine("Number of hinges: " & crosslinkscount)
            For i = 0 To crosslinkscount - 1
                For j = 0 To 2
                    SE_Crosslinks(i, j) = in_CrossLinks(j + i * 4)
                Next j
            Next i
        End If

        SE_meshsize = MeshSize

        If (in_LinCombinations IsNot Nothing) Then
            lincominationcount = in_LinCombinations.Count / 3
            Rhino.RhinoApp.WriteLine("Number of load cases: " & lcasecount)
            For i = 0 To lincominationcount - 1
                For j = 0 To 2
                    SE_lincombinations(i, j) = in_LinCombinations(j + i * 3)
                Next j
            Next i
        End If
        If (in_NonLinCombinations IsNot Nothing) Then
            nonlincominationcount = in_NonLinCombinations.Count / 4
            Rhino.RhinoApp.WriteLine("Number of load cases: " & lcasecount)
            For i = 0 To nonlincominationcount - 1
                For j = 0 To 3
                    SE_nonlincombinations(i, j) = in_NonLinCombinations(j + i * 4)
                Next j
            Next i
        End If

        If (in_StabCombinations IsNot Nothing) Then
            stabcombicount = in_StabCombinations.Count / 3
            Rhino.RhinoApp.WriteLine("Number of load cases: " & lcasecount)
            For i = 0 To stabcombicount - 1
                For j = 0 To 1
                    SE_stabcombinations(i, j) = in_StabCombinations(j + i * 2)
                Next j
            Next i
        End If

        If (in_gapElem IsNot Nothing) Then
            gapsnr = in_gapElem.Count / 4
            Rhino.RhinoApp.WriteLine("Number of load cases: " & lcasecount)
            For i = 0 To gapsnr - 1
                For j = 0 To 3
                    SE_gapselem(i, j) = in_gapElem(j + i * 4)
                Next j
            Next i
        End If

        If (in_presstensionElem IsNot Nothing) Then
            ptelemnsnr = in_presstensionElem.Count / 2
            Rhino.RhinoApp.WriteLine("Number of load cases: " & lcasecount)
            For i = 0 To ptelemnsnr - 1
                For j = 0 To 1
                    SE_presstensionelems(i, j) = in_presstensionElem(j + i * 2)
                Next j
            Next i
        End If


        If (in_limitforceElem IsNot Nothing) Then
            lfelemnsnr = in_limitforceElem.Count / 4
            Rhino.RhinoApp.WriteLine("Number of load cases: " & lcasecount)
            For i = 0 To lfelemnsnr - 1
                For j = 0 To 3
                    SE_limforceelem(i, j) = in_limitforceElem(j + i * 4)
                Next j
            Next i
        End If

        If ((in_layers IsNot Nothing)) Then
            SE_layersCount = in_layers.Count / 3
            Rhino.RhinoApp.WriteLine("Number of layers: " & SE_layersCount)
            For i = 0 To SE_layersCount - 1
                For j = 0 To 2
                    SE_layers(i, j) = in_layers(j + i * 3)
                Next j
            Next i
        End If

        If (in_Cables IsNot Nothing) Then
            CablesCount = in_Cables.Count / 6
            Rhino.RhinoApp.WriteLine("Cable elements: " & CablesCount)
            For i = 0 To CablesCount - 1
                For j = 0 To 5
                    SE_Cables(i, j) = in_Cables(j + i * 6)
                Next j
            Next i
        End If

        If ((in_BeamLineSupport IsNot Nothing)) Then
            nBeamLineSupport = in_BeamLineSupport.Count / 23
            Rhino.RhinoApp.WriteLine("Number of beam line supports: " & nBeamLineSupport)
            For i = 0 To nBeamLineSupport - 1
                For j = 0 To 22
                    SE_beamLineSupports(i, j) = in_BeamLineSupport(j + i * 23)
                Next j
            Next i
        End If

        If ((in_PointSupportOnBeam IsNot Nothing)) Then
            nPointSupportonBeam = in_PointSupportOnBeam.Count / 24
            Rhino.RhinoApp.WriteLine("Number of point supports on beam: " & nPointSupportonBeam)
            For i = 0 To nPointSupportonBeam - 1
                For j = 0 To 23
                    SE_pointSupportOnBeam(i, j) = in_PointSupportOnBeam(j + i * 24)
                Next j
            Next i
        End If

        If ((in_Subsoils IsNot Nothing)) Then
            nSubsoils = in_Subsoils.Count / 9
            Rhino.RhinoApp.WriteLine("Number of number of subsoils: " & nSubsoils)
            For i = 0 To nSubsoils - 1
                For j = 0 To 8
                    SE_subsoil(i, j) = in_Subsoils(j + i * 9)
                Next j
            Next i
        End If

        If ((in_SurfaceSupports IsNot Nothing)) Then
            nSurfaceSupports = in_SurfaceSupports.Count / 2
            Rhino.RhinoApp.WriteLine("Number of surface supports: " & nSurfaceSupports)
            For i = 0 To nSurfaceSupports - 1
                For j = 0 To 1
                    SE_surfaceSupport(i, j) = in_SurfaceSupports(j + i * 2)
                Next j
            Next i
        End If


        If ((in_nonlinearfunctions IsNot Nothing)) Then
            nlfunctionscount = in_nonlinearfunctions.Count / 5
            Rhino.RhinoApp.WriteLine("Number of surface supports: " & nSurfaceSupports)
            For i = 0 To nlfunctionscount - 1
                For j = 0 To 4
                    SE_NonlinearFunctions(i, j) = in_nonlinearfunctions(j + i * 5)
                Next j
            Next i
        End If


        'write the XML file
        '---------------------------------------------------
        Rhino.RhinoApp.Write("Creating the XML file string in memory...")

        Dim fileNameXMLdef As String
        fileNameXMLdef = Path.GetFileName(FileName) + ".def"

        Call WriteXMLFile(oSB, Scale, StructureType, Materials, SE_sections, sectioncount, SE_nodes, nodecount, SE_beams, beamcount, SE_surfaces, surfacecount,
SE_openings, openingcount, SE_nodesupports, nodesupportcount, SE_edgesupports, edgesupportcount,
SE_lcases, lcasecount, SE_lgroups, lgroupcount, SE_lloads, lloadcount, SE_sloads, sloadcount,
SE_fploads, fploadcount, SE_flloads, flloadcount, SE_fsloads, fsloadcount,
SE_hinges, hingecount,
SE_meshsize, SE_eLoads, eloadscount, SE_pointLoadPoint, pointLoadpointCount, SE_pointLoadBeam, pointLoadbeamCount,
SE_lincombinations, lincominationcount, SE_nonlincombinations, nonlincominationcount, SE_stabcombinations,
stabcombicount, SE_Crosslinks, crosslinkscount, SE_gapselem, gapsnr, SE_presstensionelems, ptelemnsnr, SE_limforceelem,
lfelemnsnr, projectInfo, fileNameXMLdef, SE_layers, SE_layersCount, SE_beamLineSupports, nBeamLineSupport, SE_pointSupportOnBeam,
nPointSupportonBeam, SE_subsoil, nSubsoils, SE_surfaceSupport, nSurfaceSupports, SE_LoadPanels, nloadPanels,
SE_PointMomentPointNode, pointMomentpointCount, SE_pointMomentBeam, pointMomentbeamCount, SE_lineMomentBeam, lineMomentBeamCount, SE_lineMomentEdge, lineMomentEdgeCount,
SE_fMomentPointloads, fpointmomentloadcount, SE_NonlinearFunctions, nlfunctionscount, SE_SlabInternalEdges, slabInternalEdgesCount, SE_RigidArms, RigidArmsCount, SE_Cables, CablesCount)

        Rhino.RhinoApp.Write(" Done." & Convert.ToChar(13))

        Rhino.RhinoApp.Write("Writing to file: " & FileName & "...")

        objstream = oSB.ToString()
        System.IO.File.WriteAllText(FileName, objstream)


        Dim XmlDefOutputPath As String
        XmlDefOutputPath = FileName + ".def"
        Dim xmlDef As String
        xmlDef = My.Resources.koala_xml
        System.IO.File.WriteAllText(XmlDefOutputPath, xmlDef)

        Rhino.RhinoApp.Write(" Done." & Convert.ToChar(13))

        'stop stopwatch
        stopWatch.Stop()
        time_elapsed = stopWatch.ElapsedMilliseconds
        Rhino.RhinoApp.WriteLine("Done in " + CStr(time_elapsed) + " ms.")
    End Sub

    Private Sub WriteXMLFile(ByRef oSB, scale, structtype, materials,
    sections(,), sectionnr, nodes(,), nnodes, beams(,), beamnr, surfaces(,), surfacenr,
    openings(,), openingnr, nodesupports(,), nodesupportnr, edgesupports(,), edgesupportnr,
    lcases(,), lcasenr, lgroups(,), lgroupnr, lloads(,), lloadnr, sloads(,), sloadnr,
    fploads(,), fploadnr, flloads(,), flloadnr, fsloads(,), fsloadnr,
    hinges(,), hingenr,
    meshsize, eloads(,), eloadsnr, pointLoadPoint(,), pointLoadpointCount, pointLoadBeam(,),
    pointLoadbeamCount, lincombinations(,), lincominationcount, nonlincombinations(,), nonlincominationcount,
    stabcombi(,), stabcombncount, crosslinks(,), crosslinkscount, gapselem(,), gapsnr, presstensionelems(,), ptelemnsnr, limforceelem(,),
    lfelemnsnr, projectInfo, fileNameXMLdef, SE_layers(,), SE_layersCount, SE_beamLineSupports(,), nbeamLineSupports, SE_pointSupportOnBeam,
    nPointSupportonBeam, SE_subsoil(,), nSubsoils, SE_surfaceSupport(,), nSurfaceSupports, SE_Loadpanels(,), nLoadpanels, SE_PointMomentPointNode(,),
    pointMomentpointCount, SE_pointMomentBeam(,), pointMomentbeamCount, SE_lineMomentBeam(,), lineMomentBeamCount, SE_lineMomentEdge(,),
    lineMomentEdgeCount, SE_fMomentPointloads(,), fpointmomentloadcount, SE_NonlinearFunctions(,), nlfunctionscount, SE_SlabInternalEdges(,), slabInternalEdgesCount, SE_RigidArms(,), RigidArmsCount, SE_Cables(,), CablesCount)

        Dim i As Long
        Dim c As String, cid As String, t As String, tid As String

        'write XML header information -----------------------------------------------------

        oSB.Appendline("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>")
        oSB.AppendLine("<project xmlns=""http://www.scia.cz"">")
        oSB.AppendLine("<def uri=""" & fileNameXMLdef & """/>")

        If structtype <> "" Or materials.count <> 0 Then
            'output project information -----------------------------------------------------
            c = "{AC021036-C943-4B46-88E4-72CFB9D9391C}"
            cid = "EP_GraphicDsObjects.EP_BaseDataProjectHeader.1"
            t = "10753FD4-0179-4825-89F9-ADAEAE8699D0"
            tid = "ProjectData.EP_ProjectData.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            'header
            oSB.AppendLine("<h>")


            oSB.AppendLine(ConCat_ht("0", "Structure"))
            oSB.AppendLine(ConCat_ht("1", "Project"))
            oSB.AppendLine(ConCat_ht("2", "Part"))
            oSB.AppendLine(ConCat_ht("3", "Description"))
            oSB.AppendLine(ConCat_ht("4", "Author"))
            oSB.AppendLine(ConCat_ht("5", "Date"))
            oSB.AppendLine(ConCat_ht("6", "Concrete"))
            oSB.AppendLine(ConCat_ht("7", "Steel"))
            oSB.AppendLine(ConCat_ht("8", "Timber"))
            oSB.AppendLine(ConCat_ht("9", "Steel fibre concrete"))
            oSB.AppendLine(ConCat_ht("10", "Functionality"))




            oSB.AppendLine("</h>")

            'data
            oSB.AppendLine("<obj id=""1"">")
            Select Case structtype
                Case "Beam"
                    oSB.AppendLine(ConCat_pvt("0", 0, "Beam"))
                Case "Truss XZ"
                    oSB.AppendLine(ConCat_pvt("0", 1, "Truss XZ"))
                Case "Frame XZ"
                    oSB.AppendLine(ConCat_pvt("0", 2, "Frame XZ"))
                Case "Truss XYZ"
                    oSB.AppendLine(ConCat_pvt("0", 3, "Truss XYZ"))
                Case "Frame XYZ"
                    oSB.AppendLine(ConCat_pvt("0", 4, "Frame XYZ"))
                Case "Grid XY"
                    oSB.AppendLine(ConCat_pvt("0", 5, "Grid XY"))
                Case "Plate XY"
                    oSB.AppendLine(ConCat_pvt("0", 6, "Plate XY"))
                Case "Wall XY"
                    oSB.AppendLine(ConCat_pvt("0", 7, "Wall XY"))
                Case "General XYZ"
                    oSB.AppendLine(ConCat_pvt("0", 8, "General XYZ"))
                Case Else
                    oSB.AppendLine(ConCat_pvt("0", 8, "General XYZ"))
            End Select

            If (projectInfo.Count <> 0) Then
                oSB.AppendLine(ConCat_pv("1", projectInfo(0)))
                oSB.AppendLine(ConCat_pv("2", projectInfo(1)))
                oSB.AppendLine(ConCat_pv("3", projectInfo(2)))
                oSB.AppendLine(ConCat_pv("4", projectInfo(3)))
                oSB.AppendLine(ConCat_pv("5", projectInfo(4)))

            Else
                oSB.AppendLine(ConCat_pv("1", "-"))
                oSB.AppendLine(ConCat_pv("2", "-"))
                oSB.AppendLine(ConCat_pv("3", "-"))
                oSB.AppendLine(ConCat_pv("4", "-"))
                oSB.AppendLine(ConCat_pv("5", "-"))
            End If
            oSB.AppendLine(ConCat_pv("6", IIf(materials.Contains("Concrete"), "1", "0")))
            oSB.AppendLine(ConCat_pv("7", IIf(materials.Contains("Steel"), "1", "0")))
            oSB.AppendLine(ConCat_pv("8", IIf(materials.Contains("Timber"), "1", "0")))
            oSB.AppendLine(ConCat_pv("9", IIf(materials.Contains("Fiber Concrete"), "1", "0")))
            oSB.AppendLine(ConCat_pv("10", "PrDEx_InitialStress, PrDEx_Subsoil,PrDEx_InitialDeformationsAndCurvature, PrDEx_SecondOrder, PrDEx_Nonlinearity, PrDEx_BeamLocalNonlinearity,PrDEx_SupportNonlinearity, PrDEx_StabilityAnalysis"))
            'If (projectInfo.Count <> 0) Then
            '    oSB.AppendLine(ConCat_pv("11", projectInfo(5)))
            '    oSB.AppendLine(ConCat_pv("12", projectInfo(6)))
            'Else
            '    oSB.AppendLine(ConCat_pv("11", "EC - EN"))
            '    oSB.AppendLine(ConCat_pv("12", "Standard EN"))
            'End If
            oSB.AppendLine("</obj>")

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")

        End If

        If SE_layersCount > 0 Then
            c = "{D3885EC4-BAE5-11D4-B3FA-00104BC3B531}"
            cid = "EP_DSG_Elements.EP_DataLayer.1"
            t = "06959627-BC30-413C-97DC-B412E4F7E9DA"
            tid = "EP_DSG_Elements.EP_DataLayer.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Comment"))
            oSB.AppendLine(ConCat_ht("2", "Structural model only"))
            oSB.AppendLine(ConCat_ht("3", "Current used activity"))
            oSB.AppendLine("</h>")

            For i = 0 To SE_layersCount - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... layer: " + Str(i))
                End If
                Call WriteLayer(oSB, i, SE_layers)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If meshsize > 0 Then

            'output project information -----------------------------------------------------
            c = "{31450A87-BE7E-4EA0-BFD2-4544A3E7BA53}"
            cid = "EP_Model.10.00.EP_MeshSetup.1"
            t = "C706BB08-BD78-41F3-8407-590DED0050F3"
            tid = "EP_Model.10.00.EP_MeshSetup.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            'header
            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Average size of 2d element/curved element"))
            oSB.AppendLine(ConCat_ht("2", "Average number of tiles of 1d element"))
            oSB.AppendLine(ConCat_ht("3", "Division on haunches and arbitrary members"))
            oSB.AppendLine(ConCat_ht("4", "Minimal length of beam element"))
            oSB.AppendLine(ConCat_ht("5", "Maximal length of beam element"))
            oSB.AppendLine("</h>")

            'data
            oSB.AppendLine("<obj id=""1"">")
            oSB.AppendLine(ConCat_pv("1", meshsize))
            oSB.AppendLine("</obj>")

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")

        End If

        If sectionnr > 0 Then
            'output sections ------------------------------------------------------------------
            c = "{2127A9B3-36BD-11D4-B337-00104BC3B531}"
            cid = "CrossSection.EP_CrossSection.1"
            t = "CDB98AF7-B4FE-4360-8240-C9F4A34065B3"
            tid = "CrossSection.EP_CssGeometry.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Catalog ID"))
            oSB.AppendLine(ConCat_ht("2", "Catalog item"))
            oSB.AppendLine(ConCat_ht("3", "Parameters"))
            oSB.AppendLine("</h>")

            For i = 0 To sectionnr - 1

                Call WriteSection(oSB, sections(i, 0), sections(i, 1), sections(i, 2), sections(i, 3))

            Next i

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")

        End If

        If nnodes > 0 Then
            'output nodes ---------------------------------------------------------------------
            c = "{39A7F468-A0D4-4DFF-8E5C-5843E1807D13}"
            cid = "EP_DSG_Elements.EP_StructNode.1"
            t = "E2CADA5A-BD04-4CE2-9F43-C09035196EF8"
            tid = "EP_DSG_Elements.EP_StructNode.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Coord X"))
            oSB.AppendLine(ConCat_ht("2", "Coord Y"))
            oSB.AppendLine(ConCat_ht("3", "Coord Z"))
            oSB.AppendLine("</h>")

            For i = 0 To nnodes - 1
                If i > 0 And (i Mod 500 = 0) Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... node: " + Str(i))
                End If
                If Not isNodeDuplicate(nodes(i, 0)) Then
                    Call WriteNode(oSB, i, nodes)
                End If

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")

        End If

        If beamnr > 0 Then
            'output beams ---------------------------------------------------------------------
            c = "{ECB5D684-7357-11D4-9F6C-00104BC3B443}"
            cid = "EP_DSG_Elements.EP_Beam.1"
            t = "0884F792-2361-4B07-A8D6-828706CB2FE1"
            tid = "EP_DSG_Elements.EP_Beam.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Beg. node"))
            oSB.AppendLine(ConCat_ht("2", "End node"))
            oSB.AppendLine(ConCat_ht("3", "Layer"))
            oSB.AppendLine(ConCat_ht("4", "Cross-section"))
            oSB.AppendLine(ConCat_ht("5", "FEM type"))
            oSB.AppendLine(ConCat_ht("6", "Member system-line at"))
            oSB.AppendLine(ConCat_ht("7", "ey"))
            oSB.AppendLine(ConCat_ht("8", "ez"))
            oSB.AppendLine(ConCat_ht("9", "Table of geometry"))
            oSB.AppendLine(ConCat_ht("10", "Type"))
            oSB.AppendLine(ConCat_ht("11", "LCS"))
            oSB.AppendLine(ConCat_ht("12", "LCS Rotation"))
            oSB.AppendLine(ConCat_ht("13", "X"))
            oSB.AppendLine(ConCat_ht("14", "Y"))
            oSB.AppendLine(ConCat_ht("15", "Z"))

            oSB.AppendLine("</h>")

            For i = 0 To beamnr - 1
                If i > 0 And (i Mod 500 = 0) Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... beam: " + Str(i))
                End If
                Call WriteBeam(oSB, i, beams)
            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If ptelemnsnr > 0 Then
            'output beams ---------------------------------------------------------------------
            c = "{02AC59F3-478B-44C3-A350-E78DA69D7520}"
            cid = "DataAddSupport.EP_NonlinearityInitStress.1"
            t = "7E7FED2A-5579-4B4C-B0A9-4AD2F7E49F66"
            tid = "DataAddSupport.EP_NonlinearityInitStress.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Reference table"))
            oSB.AppendLine(ConCat_ht("2", "Type"))

            oSB.AppendLine("</h>")
            For i = 0 To ptelemnsnr - 1
                If i > 0 And (i Mod 500 = 0) Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... beam: " + Str(i))
                End If
                Call WritePressTensionOnlyBeamNL(oSB, i, presstensionelems)
            Next
            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If gapsnr > 0 Then

            'output beams ---------------------------------------------------------------------
            c = "{02AC59F3-478B-44C3-A350-E78DA69D7520}"
            cid = "DataAddSupport.EP_NonlinearityInitStress.1"
            t = "5E881A0B-B102-4B8A-B77D-84ACAB22C003"
            tid = "DataAddSupport.EP_NonlinearityInitStress.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Reference table"))
            oSB.AppendLine(ConCat_ht("2", "Type"))
            oSB.AppendLine(ConCat_ht("3", "Type"))
            oSB.AppendLine(ConCat_ht("4", "Displacement"))
            oSB.AppendLine(ConCat_ht("5", "Position"))
            oSB.AppendLine("</h>")
            For i = 0 To gapsnr - 1
                If i > 0 And (i Mod 500 = 0) Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... beam: " + Str(i))
                End If
                Call WriteGapLocalBeamNL(oSB, i, gapselem)
            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If CablesCount > 0 Then
            'output beams ---------------------------------------------------------------------
            c = "{02AC59F3-478B-44C3-A350-E78DA69D7520}"
            cid = "DataAddSupport.EP_NonlinearityInitStress.1"
            t = "80F27A2A-A741-4C59-8421-C791B85B068F"
            tid = "DataAddSupport.EP_NonlinearityInitStress.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Reference table"))
            oSB.AppendLine(ConCat_ht("2", "Type"))
            oSB.AppendLine(ConCat_ht("3", "Initial mesh"))
            oSB.AppendLine(ConCat_ht("4", "Self weight"))
            oSB.AppendLine(ConCat_ht("5", "Normal force"))
            oSB.AppendLine(ConCat_ht("6", "Pn"))
            oSB.AppendLine(ConCat_ht("7", "Alpha x"))
            oSB.AppendLine("</h>")
            For i = 0 To CablesCount - 1
                If i > 0 And (i Mod 500 = 0) Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... beam: " + Str(i))
                End If
                Call WriteCableBeamNL(oSB, i, SE_Cables)
            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If


        If lfelemnsnr > 0 Then
            'output beams ---------------------------------------------------------------------
            c = "{02AC59F3-478B-44C3-A350-E78DA69D7520}"
            cid = "DataAddSupport.EP_NonlinearityInitStress.1"
            t = "5604D64C-4042-4F4D-84C3-9F948AAD465E"
            tid = "DataAddSupport.EP_NonlinearityInitStress.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Reference table"))
            oSB.AppendLine(ConCat_ht("2", "Type"))
            oSB.AppendLine(ConCat_ht("3", "Direction"))
            oSB.AppendLine(ConCat_ht("4", "Type"))
            oSB.AppendLine(ConCat_ht("5", "Marginal force"))
            oSB.AppendLine("</h>")
            For i = 0 To lfelemnsnr - 1
                If i > 0 And (i Mod 500 = 0) Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... beam: " + Str(i))
                End If
                Call WriteLimitForceBeamNL(oSB, i, limforceelem)
            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If




        If surfacenr > 0 Then
            'output surfaces ------------------------------------------------------------------
            c = "{8708ED31-8E66-11D4-AD94-F6F5DE2BE344}"
            cid = "EP_DSG_Elements.EP_Plane.1"
            t = "2F3C64B3-BAF2-4E26-ACF1-CB6DDBD6BC0F"
            tid = "EP_DSG_Elements.EP_Plane.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Layer"))
            oSB.AppendLine(ConCat_ht("2", "Type"))
            oSB.AppendLine(ConCat_ht("3", "Material"))
            oSB.AppendLine(ConCat_ht("4", "FEM nonlinear model"))
            oSB.AppendLine(ConCat_ht("5", "Thickness type"))
            oSB.AppendLine(ConCat_ht("6", "Direction"))
            oSB.AppendLine(ConCat_ht("7", "Thickness"))
            oSB.AppendLine(ConCat_ht("8", "Point 1"))
            oSB.AppendLine(ConCat_ht("9", "Member system-plane at"))
            oSB.AppendLine(ConCat_ht("10", "Eccentricity z"))
            oSB.AppendLine(ConCat_ht("11", "Table of geometry"))
            oSB.AppendLine(ConCat_ht("12", "Internal nodes"))
            oSB.AppendLine(ConCat_ht("13", "Swap orientation"))
            oSB.AppendLine(ConCat_ht("14", "LCS angle"))
            oSB.AppendLine(ConCat_ht("15", "Element type"))


            oSB.AppendLine("</h>")

            For i = 0 To surfacenr - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... surface: " + Str(i))
                End If
                Call WriteSurface(oSB, i, surfaces)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If nLoadpanels > 0 Then
            'output load panels ------------------------------------------------------------------
            c = "{8708ED31-8E66-11D4-AD94-F6F5DE2BE344}"
            cid = "EP_DSG_Elements.EP_Plane.1"
            t = "BEA3B878-D1E8-4381-9A87-169EDCF7D602"
            tid = "EP_DSG_Elements.EP_Plane.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Layer"))
            oSB.AppendLine(ConCat_ht("2", "Table of geometry"))

            oSB.AppendLine(ConCat_ht("3", "Element type"))
            oSB.AppendLine(ConCat_ht("4", "Panel type"))
            oSB.AppendLine(ConCat_ht("5", "Load transfer direction"))
            oSB.AppendLine(ConCat_ht("6", "Transfer in X [%]"))
            oSB.AppendLine(ConCat_ht("7", "Transfer in Y [%]"))
            oSB.AppendLine(ConCat_ht("8", "Load transfer method"))
            oSB.AppendLine(ConCat_ht("9", "Selection of entities"))
            oSB.AppendLine(ConCat_ht("10", "Swap orientation"))
            oSB.AppendLine(ConCat_ht("11", "LCS angle"))


            oSB.AppendLine("</h>")

            For i = 0 To nLoadpanels - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... surface: " + Str(i))
                End If
                Call WriteLoadPanels(oSB, i, SE_Loadpanels)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If openingnr > 0 Then
            'output openings ------------------------------------------------------------------
            c = "{EBA9B148-F564-4DB1-9E2D-F1937FFA4523}"
            cid = "EP_DSG_Elements.EP_OpenSlab.1"
            t = "55C2A44E-E3D4-429B-A955-4E5BC1C4C5EA"
            tid = "EP_DSG_Elements.EP_OpenSlab.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Reference table"))
            oSB.AppendLine(ConCat_ht("1", "Name"))
            oSB.AppendLine(ConCat_ht("2", "2D Member"))
            oSB.AppendLine(ConCat_ht("3", "Table of geometry"))
            oSB.AppendLine(ConCat_ht("4", "Material"))
            oSB.AppendLine(ConCat_ht("5", "Thickness"))
            oSB.AppendLine(ConCat_ht("6", "Table of geometry"))
            oSB.AppendLine("</h>")

            For i = 0 To openingnr - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... opening: " + Str(i))
                End If
                Call WriteOpening(oSB, i, openings)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If slabInternalEdgesCount > 0 Then
            c = "{4FCA60AD-9308-468B-BD02-3D4E17830029}"
            cid = "EP_DSG_Elements.EP_SlabInternalEdge.1"
            t = "7ECDC58C-28DD-4CDD-8240-1344E77A7E32"
            tid = "EP_DSG_Elements.EP_SlabInternalEdge.1"
            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "2D Member"))
            oSB.AppendLine(ConCat_ht("2", "Shape"))
            oSB.AppendLine(ConCat_ht("3", "Table of geometry"))
            oSB.AppendLine("</h>")


            For i = 0 To slabInternalEdgesCount - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... opening: " + Str(i))
                End If
                Call WriteInternalEdge(oSB, i, SE_SlabInternalEdges)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")

        End If

        If RigidArmsCount > 0 Then

            c = "{5A3B44E9-D820-4539-B52E-A2230C78495B}"
            cid = "EP_DataAddStructure.EP_RigidArm.1"
            t = "9D6B46ED-E294-4842-906C-90FBFB716601"
            tid = "EP_DataAddStructure.EP_RigidArm.1"
            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")



            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Master"))
            oSB.AppendLine(ConCat_ht("2", "Slave"))
            oSB.AppendLine(ConCat_ht("1", "Hinge on master"))
            oSB.AppendLine(ConCat_ht("2", "Hinge on slave"))
            oSB.AppendLine("</h>")


            For i = 0 To RigidArmsCount - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... opening: " + Str(i))
                End If
                Call WriteRigidArm(oSB, i, SE_RigidArms)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")

        End If


        If nlfunctionscount > 0 Then
            'output nodal supports ------------------------------------------------------------------
            c = "{2C78B173-A1D3-11D4-A433-000000000000}"
            cid = "DataLibScia.EP_NonLinearFunction.1"
            t = "102590D1-4EF3-4E7D-892B-CAB4DDFE8C20"
            tid = "DataLibScia.EP_NonLinearFunction.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Type"))
            oSB.AppendLine(ConCat_ht("2", "Positive end"))
            oSB.AppendLine(ConCat_ht("3", "Negative end"))
            oSB.AppendLine(ConCat_ht("4", "u / F"))
            oSB.AppendLine(ConCat_ht("5", "fi / M"))
            oSB.AppendLine(ConCat_ht("6", "u / F"))
            oSB.AppendLine("</h>")

            For i = 0 To nlfunctionscount - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... nodal supports: " + Str(i))
                End If
                Call WriteNonlinearFunction(oSB, i, SE_NonlinearFunctions)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If nodesupportnr > 0 Then
            'output nodal supports ------------------------------------------------------------------
            c = "{1CBCA4DE-355B-40F7-A91D-8EFD26A6404D}"
            cid = "DataAddSupport.EP_PointSupportPoint.1"
            t = "B692AE6A-CE3D-44B6-8F23-FA69CCE6E7EF"
            tid = "DataAddSupport.EP_PointSupportPoint.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Reference Table"))
            'oSB.AppendLine(ConCat_hh("1", "Node"))
            oSB.AppendLine(ConCat_ht("2", "X"))
            oSB.AppendLine(ConCat_ht("3", "Y"))
            oSB.AppendLine(ConCat_ht("4", "Z"))
            oSB.AppendLine(ConCat_ht("5", "Rx"))
            oSB.AppendLine(ConCat_ht("6", "Ry"))
            oSB.AppendLine(ConCat_ht("7", "Rz"))
            oSB.AppendLine(ConCat_ht("8", "Stiffness X"))
            oSB.AppendLine(ConCat_ht("9", "Stiffness Y"))
            oSB.AppendLine(ConCat_ht("10", "Stiffness Z"))
            oSB.AppendLine(ConCat_ht("11", "Stiffness Rx"))
            oSB.AppendLine(ConCat_ht("12", "Stiffness Ry"))
            oSB.AppendLine(ConCat_ht("13", "Stiffness Rz"))
            oSB.AppendLine(ConCat_ht("14", "Angle [deg]"))
            oSB.AppendLine(ConCat_ht("15", "Function X"))
            oSB.AppendLine(ConCat_ht("16", "Function Y"))
            oSB.AppendLine(ConCat_ht("17", "Function Z"))
            oSB.AppendLine(ConCat_ht("18", "Function Rx"))
            oSB.AppendLine(ConCat_ht("19", "Function Ry"))
            oSB.AppendLine(ConCat_ht("20", "Function Rz"))
            oSB.AppendLine("</h>")

            For i = 0 To nodesupportnr - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... nodal supports: " + Str(i))
                End If
                Call WriteNodeSupport(oSB, i, nodesupports)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If edgesupportnr > 0 Then
            'output edge supports ------------------------------------------------------------------
            c = "{24449635-FE8C-46B5-8C97-9E0CA33F0E70}"
            cid = "DataAddSupport.EP_LineSupportSurface.1"
            t = "DDE61EF9-7735-4DCD-939E-7521D1B4BB6F"
            tid = "DataAddSupport.EP_LineSupportSurface.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Reference table"))
            oSB.AppendLine(ConCat_ht("2", "Edge"))
            oSB.AppendLine(ConCat_ht("3", "X"))
            oSB.AppendLine(ConCat_ht("4", "Y"))
            oSB.AppendLine(ConCat_ht("5", "Z"))
            oSB.AppendLine(ConCat_ht("6", "Rx"))
            oSB.AppendLine(ConCat_ht("7", "Ry"))
            oSB.AppendLine(ConCat_ht("8", "Rz"))
            oSB.AppendLine(ConCat_ht("9", "System"))
            oSB.AppendLine(ConCat_ht("10", "Stiffness X"))
            oSB.AppendLine(ConCat_ht("11", "Stiffness Y"))
            oSB.AppendLine(ConCat_ht("12", "Stiffness Z"))
            oSB.AppendLine(ConCat_ht("13", "Stiffness Rx"))
            oSB.AppendLine(ConCat_ht("14", "Stiffness Ry"))
            oSB.AppendLine(ConCat_ht("15", "Stiffness Rz"))
            oSB.AppendLine(ConCat_ht("16", "Coord. definition"))
            oSB.AppendLine(ConCat_ht("17", "Position x1"))
            oSB.AppendLine(ConCat_ht("18", "Position x2"))
            oSB.AppendLine(ConCat_ht("19", "Origin"))
            oSB.AppendLine(ConCat_ht("20", "Function X"))
            oSB.AppendLine(ConCat_ht("21", "Function Y"))
            oSB.AppendLine(ConCat_ht("22", "Function Z"))
            oSB.AppendLine(ConCat_ht("23", "Function Rx"))
            oSB.AppendLine(ConCat_ht("24", "Function Ry"))
            oSB.AppendLine(ConCat_ht("25", "Function Rz"))


            oSB.AppendLine("</h>")

            For i = 0 To edgesupportnr - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... edge supports: " + Str(i))
                End If
                Call WriteEdgeSupport(oSB, i, edgesupports)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If


        If nbeamLineSupports > 0 Then
            'output edge supports ------------------------------------------------------------------
            c = "{61FC64DE-5B75-4074-BF61-DA1AAA0A194C}"
            cid = "DataAddSupport.EP_LineSupportLine.1"
            t = "8B25091F-28B4-425C-88D9-F9C8743D92DD"
            tid = "DataAddSupport.EP_LineSupportLine.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Reference table"))
            oSB.AppendLine(ConCat_ht("2", "Type"))
            oSB.AppendLine(ConCat_ht("3", "X"))
            oSB.AppendLine(ConCat_ht("4", "Y"))
            oSB.AppendLine(ConCat_ht("5", "Z"))
            oSB.AppendLine(ConCat_ht("6", "Rx"))
            oSB.AppendLine(ConCat_ht("7", "Ry"))
            oSB.AppendLine(ConCat_ht("8", "Rz"))
            oSB.AppendLine(ConCat_ht("9", "Stiffness X"))
            oSB.AppendLine(ConCat_ht("10", "Stiffness Y"))
            oSB.AppendLine(ConCat_ht("11", "Stiffness Z"))
            oSB.AppendLine(ConCat_ht("12", "Stiffness Rx"))
            oSB.AppendLine(ConCat_ht("13", "Stiffness Ry"))
            oSB.AppendLine(ConCat_ht("14", "Stiffness Rz"))
            oSB.AppendLine(ConCat_ht("15", "System"))
            oSB.AppendLine(ConCat_ht("16", "Coord. definition"))
            oSB.AppendLine(ConCat_ht("17", "Position x1"))
            oSB.AppendLine(ConCat_ht("18", "Position x2"))
            oSB.AppendLine(ConCat_ht("19", "Origin"))
            oSB.AppendLine(ConCat_ht("20", "Function X"))
            oSB.AppendLine(ConCat_ht("21", "Function Y"))
            oSB.AppendLine(ConCat_ht("22", "Function Z"))
            oSB.AppendLine(ConCat_ht("23", "Function Rx"))
            oSB.AppendLine(ConCat_ht("24", "Function Ry"))
            oSB.AppendLine(ConCat_ht("25", "Function Rz"))


            oSB.AppendLine("</h>")

            For i = 0 To nbeamLineSupports - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... edge supports: " + Str(i))
                End If
                Call WriteBeamLineSupport(oSB, i, SE_beamLineSupports)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If nPointSupportonBeam > 0 Then
            'output edge supports ------------------------------------------------------------------
            c = "{D8610F70-C515-4688-9A3C-73AF9207AF36}"
            cid = "DataAddSupport.EP_PointSupportLine.1"
            t = "D8E5CBF0-5BDF-4191-9F09-19164FF635BE"
            tid = "DataAddSupport.EP_PointSupportLine.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Reference table"))
            oSB.AppendLine(ConCat_ht("2", "Type"))
            oSB.AppendLine(ConCat_ht("3", "X"))
            oSB.AppendLine(ConCat_ht("4", "Y"))
            oSB.AppendLine(ConCat_ht("5", "Z"))
            oSB.AppendLine(ConCat_ht("6", "Rx"))
            oSB.AppendLine(ConCat_ht("7", "Ry"))
            oSB.AppendLine(ConCat_ht("8", "Rz"))
            oSB.AppendLine(ConCat_ht("9", "Stiffness X"))
            oSB.AppendLine(ConCat_ht("10", "Stiffness Y"))
            oSB.AppendLine(ConCat_ht("11", "Stiffness Z"))
            oSB.AppendLine(ConCat_ht("12", "Stiffness Rx"))
            oSB.AppendLine(ConCat_ht("13", "Stiffness Ry"))
            oSB.AppendLine(ConCat_ht("14", "Stiffness Rz"))
            oSB.AppendLine(ConCat_ht("15", "System"))
            oSB.AppendLine(ConCat_ht("16", "Coord. definition"))
            oSB.AppendLine(ConCat_ht("17", "Position x"))
            oSB.AppendLine(ConCat_ht("18", "Origin"))
            oSB.AppendLine(ConCat_ht("19", "Repeat (n)"))
            oSB.AppendLine(ConCat_ht("20", "Delta x"))
            oSB.AppendLine(ConCat_ht("21", "Function X"))
            oSB.AppendLine(ConCat_ht("22", "Function Y"))
            oSB.AppendLine(ConCat_ht("23", "Function Z"))
            oSB.AppendLine(ConCat_ht("24", "Function Rx"))
            oSB.AppendLine(ConCat_ht("25", "Function Ry"))
            oSB.AppendLine(ConCat_ht("26", "Function Rz"))


            oSB.AppendLine("</h>")

            For i = 0 To nPointSupportonBeam - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... edge supports: " + Str(i))
                End If
                Call WritePointSupportOnBeam(oSB, i, SE_pointSupportOnBeam)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If
        If nSubsoils > 0 Then
            'output edge supports ------------------------------------------------------------------
            c = "{8867A6F2-D7E4-11D4-A47F-00C06C542707}"
            cid = "DataLibScia.EP_Subsoil.1"
            t = "A4C324A5-2F59-452D-86C0-FF1B5427BC81"
            tid = "DataLibScia.EP_Subsoil.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Decription"))
            oSB.AppendLine(ConCat_ht("2", "C1x"))
            oSB.AppendLine(ConCat_ht("3", "C1y"))
            oSB.AppendLine(ConCat_ht("4", "C1z"))
            oSB.AppendLine(ConCat_ht("5", "Stiffness"))
            oSB.AppendLine(ConCat_ht("6", "C2x"))
            oSB.AppendLine(ConCat_ht("7", "C2y"))
            oSB.AppendLine(ConCat_ht("8", "Nonlinear function C1z"))





            oSB.AppendLine("</h>")

            For i = 0 To nSubsoils - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... subsoil: " + Str(i))
                End If
                Call WriteSubsoil(oSB, i, SE_subsoil)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If nSurfaceSupports > 0 Then
            'output edge supports ------------------------------------------------------------------
            c = "{1F4C3BA2-9235-4C0B-A940-4C72C9B59C30}"
            cid = "EP_SurfaceSupportSurface"
            t = "ECC78F0A-BB10-4F0A-9E4C-3B8EB00FF33F"
            tid = "EP_SurfaceSupportSurface"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Reference Table"))
            oSB.AppendLine(ConCat_ht("2", "Type"))
            oSB.AppendLine(ConCat_ht("3", "Subsoil"))
            oSB.AppendLine("</h>")

            For i = 0 To nSurfaceSupports - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... Surface support: " + Str(i))
                End If
                Call WriteSurfaceSupport(oSB, i, SE_surfaceSupport)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If



        If lgroupnr > 0 Then
            'output load groups ------------------------------------------------------------------
            c = "{F9D4AA72-49D5-11D4-A3CF-000000000000}"
            cid = "DataSetScia.EP_LoadGroup.1"
            t = "0BB81CC1-B975-48AB-97D2-0CDE69CD8A6E"
            tid = "DataSetScia.EP_LoadGroup.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Load")) '0: Permanent, 1: Variable
            oSB.AppendLine(ConCat_ht("2", "Relation"))

            oSB.AppendLine("</h>")

            For i = 0 To lgroupnr - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... load group: " + Str(i))
                End If
                Call WriteLGroup(oSB, i, lgroups)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If lcasenr > 0 Then
            'output load cases ------------------------------------------------------------------
            c = "{0908D21F-481F-11D4-AB84-00C06C452330}"
            cid = "DataSetScia.EP_LoadCase.1"
            t = "6D626C96-E1B4-4084-83F2-54200CAD2815"
            tid = "DataSetScia.EP_LoadCase.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Action type")) '0: Permanent, 1: Variable
            oSB.AppendLine(ConCat_ht("2", "Load type"))
            oSB.AppendLine(ConCat_ht("3", "Direction")) '0: -Z, 1: +Z, 2: -Y etc.
            oSB.AppendLine(ConCat_ht("4", "Load group")) '0: Self-weight, 1: Standard, 2: Primary

            oSB.AppendLine("</h>")

            For i = 0 To lcasenr - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... load case: " + Str(i))
                End If
                Call WriteLCase(oSB, i, lcases)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If
        If lincominationcount > 0 Then
            'output linear combinations
            c = "{C0FBF7E1-4A71-11D4-AB86-00C06C452330}"
            cid = "DataSetSciaTom.EP_LoadCombi.1"
            t = "C4D6A765-03F2-4532-89D8-17BC5A7BA10E"
            tid = "DataSetSciaTom.EP_LoadCombi.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Type"))
            oSB.AppendLine(ConCat_ht("2", " Load cases"))

            oSB.AppendLine("</h>")
            For i = 0 To lincominationcount - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... combination: " + Str(i))
                End If
                Call WriteLinCombination(oSB, i, lincombinations)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If
        If nonlincominationcount > 0 Then
            'output linear combinations
            c = "{1E28F6C2-DD8B-11D5-AA60-0050FC1D5C09}"
            cid = "DataSetSciaTom.EP_NonlinearCombi.1"
            t = "2FD99985-4BEA-4C12-8205-3B40C8216912"
            tid = "DataSetSciaTom.EP_NonlinearCombi.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Type"))
            oSB.AppendLine(ConCat_ht("2", " Load cases"))
            oSB.AppendLine(ConCat_ht("3", "Description"))

            oSB.AppendLine("</h>")
            For i = 0 To nonlincominationcount - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... combination: " + Str(i))
                End If
                Call WriteNonLinCombination(oSB, i, nonlincombinations)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If stabcombncount > 0 Then
            'output linear combinations
            c = "{B6CCD4B2-DDDC-11D5-AA60-0050FC1D5C09}"
            cid = "DataSetSciaTom.EP_StabilityCombi.1"
            t = "92AC4054-1B1B-43AE-A7DA-F4B5ED25E92A"
            tid = "DataSetSciaTom.EP_StabilityCombi.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", " Load cases"))

            oSB.AppendLine("</h>")
            For i = 0 To stabcombncount - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... combination: " + Str(i))
                End If
                Call WriteStabilityCombination(oSB, i, stabcombi)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If lloadnr > 0 Then

            'output line loads ------------------------------------------------------------------
            c = "{BC16B3C6-F464-11D4-94D3-000000000000}"
            cid = "DataAddLoad.EP_LineForceLine.1"
            t = "891E5370-4DB8-4D23-93F9-B6391D3AE73E"
            tid = "DataAddLoad.EP_LineForceLine.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Load case"))
            oSB.AppendLine(ConCat_ht("2", "Reference Table"))
            oSB.AppendLine(ConCat_ht("3", "Direction"))
            oSB.AppendLine(ConCat_ht("4", "Distribution"))
            oSB.AppendLine(ConCat_ht("5", "Value - P@1"))
            oSB.AppendLine(ConCat_ht("6", "Value - P@2"))
            oSB.AppendLine(ConCat_ht("7", "System"))
            oSB.AppendLine(ConCat_ht("8", "Location"))
            oSB.AppendLine(ConCat_ht("9", "Position x1"))
            oSB.AppendLine(ConCat_ht("10", "Position x2"))
            oSB.AppendLine(ConCat_ht("11", "Coord. definition"))
            oSB.AppendLine(ConCat_ht("12", "Origin"))
            oSB.AppendLine(ConCat_ht("13", "Eccentricity ey"))
            oSB.AppendLine(ConCat_ht("14", "Eccentricity ez"))

            oSB.AppendLine("</h>")

            For i = 0 To lloadnr - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... line load: " + Str(i))
                End If
                Call WriteLLoad(oSB, i, lloads)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If


        If lineMomentBeamCount > 0 Then

            'output line loads ------------------------------------------------------------------
            c = "{80A77F84-F6A0-11D4-94D7-000000000000}"
            cid = "DataAddLoad.EP_LineMomentLine.1"
            t = "DAB00915-4D9D-46C9-BF3D-67407EFE7663"
            tid = "DataAddLoad.EP_LineMomentLine.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Load case"))
            oSB.AppendLine(ConCat_ht("2", "Reference Table"))
            oSB.AppendLine(ConCat_ht("3", "Direction"))
            oSB.AppendLine(ConCat_ht("4", "Distribution"))
            oSB.AppendLine(ConCat_ht("5", "Value - M@1"))
            oSB.AppendLine(ConCat_ht("6", "Value - M@2"))
            oSB.AppendLine(ConCat_ht("7", "System"))
            oSB.AppendLine(ConCat_ht("8", "Location"))
            oSB.AppendLine(ConCat_ht("9", "Position x1"))
            oSB.AppendLine(ConCat_ht("10", "Position x2"))
            oSB.AppendLine(ConCat_ht("11", "Coord. definition"))
            oSB.AppendLine(ConCat_ht("12", "Origin"))


            oSB.AppendLine("</h>")

            For i = 0 To lineMomentBeamCount - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... line load: " + Str(i))
                End If
                Call WriteLineMomentLoadBeam(oSB, i, SE_lineMomentBeam)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If eloadsnr > 0 Then

            'output line loads ------------------------------------------------------------------
            c = "{BC16B3C8-F464-11D4-94D3-000000000000}"
            cid = "DataAddLoad.EP_LineForceSurface.1"
            t = "3AC40490-0F84-45AB-83EA-5B0EF90A813F"
            tid = "DataAddLoad.EP_LineForceSurface.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Load case"))
            oSB.AppendLine(ConCat_ht("2", "Reference Table"))
            oSB.AppendLine(ConCat_ht("3", "Direction"))
            oSB.AppendLine(ConCat_ht("4", "Distribution"))
            oSB.AppendLine(ConCat_ht("5", "Value - P@1"))
            oSB.AppendLine(ConCat_ht("6", "Value - P@2"))
            oSB.AppendLine(ConCat_ht("7", "System"))
            oSB.AppendLine(ConCat_ht("8", "Location"))
            oSB.AppendLine(ConCat_ht("9", "Position x1"))
            oSB.AppendLine(ConCat_ht("10", "Position x2"))
            oSB.AppendLine(ConCat_ht("11", "Coord. definition"))
            oSB.AppendLine(ConCat_ht("12", "Origin"))
            oSB.AppendLine(ConCat_ht("13", "Eccentricity ey"))
            oSB.AppendLine(ConCat_ht("14", "Eccentricity ez"))
            oSB.AppendLine(ConCat_ht("15", "Edge"))
            oSB.AppendLine("</h>")

            For i = 0 To eloadsnr - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... line load: " + Str(i))
                End If
                Call WriteELoad(oSB, i, eloads)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If



        If lineMomentEdgeCount > 0 Then

            'output line loads ------------------------------------------------------------------
            c = "{C8390D34-1C9A-4190-8EEC-1A1BC146D5DA}"
            cid = "DataAddLoad.EP_LineMomentSurface.1"
            t = "04A59A88-15E2-48EC-ABB6-CB836650FFF6"
            tid = "DataAddLoad.EP_LineMomentSurface.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Load case"))
            oSB.AppendLine(ConCat_ht("2", "Reference Table"))
            oSB.AppendLine(ConCat_ht("3", "Direction"))
            oSB.AppendLine(ConCat_ht("4", "Distribution"))
            oSB.AppendLine(ConCat_ht("5", "Value - M@1"))
            oSB.AppendLine(ConCat_ht("6", "Value - M@2"))
            oSB.AppendLine(ConCat_ht("7", "System"))
            oSB.AppendLine(ConCat_ht("8", "Location"))
            oSB.AppendLine(ConCat_ht("9", "Position x1"))
            oSB.AppendLine(ConCat_ht("10", "Position x2"))
            oSB.AppendLine(ConCat_ht("11", "Coord. definition"))
            oSB.AppendLine(ConCat_ht("12", "Origin"))
            oSB.AppendLine(ConCat_ht("13", "Edge"))
            oSB.AppendLine("</h>")

            For i = 0 To lineMomentEdgeCount - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... line load: " + Str(i))
                End If
                Call WriteMomentLineLoadOnEdge(oSB, i, SE_lineMomentEdge)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        'pointLoadPoint(,), pointLoadpointCount, pointLoadBeam(,), pointLoadbeamCount)
        If pointLoadpointCount > 0 Then
            'output line loads ------------------------------------------------------------------
            c = "{F8371A21-F459-11D4-94D3-000000000000}"
            cid = "DataAddLoad.EP_PointForcePoint.1"
            t = "40BBD456-A2B4-4634-A287-A619174F1858"
            tid = "DataAddLoad.EP_PointForcePoint.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")

            oSB.AppendLine(ConCat_ht("0", "Load case"))
            oSB.AppendLine(ConCat_ht("1", "Name"))
            oSB.AppendLine(ConCat_ht("2", "Reference Table"))
            oSB.AppendLine(ConCat_ht("3", "Direction"))
            oSB.AppendLine(ConCat_ht("4", "System"))
            oSB.AppendLine(ConCat_ht("5", "Value - F"))
            oSB.AppendLine(ConCat_ht("6", "Angle [deg]"))
            oSB.AppendLine("</h>")

            For i = 0 To pointLoadpointCount - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... line load: " + Str(i))
                End If
                Call WritePLoadsPoint(oSB, i, pointLoadPoint)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If


        If pointMomentpointCount > 0 Then 'point moment
            'output line loads ------------------------------------------------------------------
            c = "{80A77F82-F6A0-11D4-94D7-000000000000}"
            cid = "DataAddLoad.EP_PointMomentPoint.1"
            t = "C62A6980-F7BB-478C-92CD-51E25FD6A7F6"
            tid = "DataAddLoad.EP_PointMomentPoint.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")

            oSB.AppendLine(ConCat_ht("0", "Load case"))
            oSB.AppendLine(ConCat_ht("1", "Name"))
            oSB.AppendLine(ConCat_ht("2", "Reference Table"))
            oSB.AppendLine(ConCat_ht("3", "Direction"))
            oSB.AppendLine(ConCat_ht("4", "System"))
            oSB.AppendLine(ConCat_ht("5", "Value - M"))
            oSB.AppendLine("</h>")

            For i = 0 To pointMomentpointCount - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... line load: " + Str(i))
                End If
                Call WriteMLoadsPoint(oSB, i, SE_PointMomentPointNode)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If pointLoadbeamCount > 0 Then
            'output line loads ------------------------------------------------------------------
            c = "{BC16B3C2-F464-11D4-94D3-000000000000}"
            cid = "DataAddLoad.EP_PointForceLine.1"
            t = "0CD415E6-90D2-4DD8-8D53-1C731E06A46D"
            tid = "DataAddLoad.EP_PointForceLine.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")

            oSB.AppendLine(ConCat_ht("0", "Load case"))
            oSB.AppendLine(ConCat_ht("1", "Name"))
            oSB.AppendLine(ConCat_ht("2", "Reference Table"))
            oSB.AppendLine(ConCat_ht("3", "Direction"))
            oSB.AppendLine(ConCat_ht("4", "System"))
            oSB.AppendLine(ConCat_ht("5", "Value - F"))
            oSB.AppendLine(ConCat_ht("6", "Coord. definition"))
            oSB.AppendLine(ConCat_ht("7", "Position x"))
            oSB.AppendLine(ConCat_ht("8", "Origin"))
            oSB.AppendLine(ConCat_ht("9", "Repeat (n)"))
            oSB.AppendLine(ConCat_ht("10", "Eccentricity ey"))
            oSB.AppendLine(ConCat_ht("11", "Eccentricity ez"))
            oSB.AppendLine(ConCat_ht("12", "Delta x"))
            oSB.AppendLine("</h>")

            For i = 0 To pointLoadbeamCount - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... line load: " + Str(i))
                End If
                Call WritePLoadsBeam(oSB, i, pointLoadBeam)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If pointMomentbeamCount > 0 Then
            'output line loads ------------------------------------------------------------------
            c = "{6A363EA4-0BD3-42C0-973A-8C48B14C9FB9}"
            cid = "DataAddLoad.EP_PointMomentLine.1"
            t = "3CF3A1A2-C109-4DB9-A0A0-0F4ACD090188"
            tid = "DataAddLoad.EP_PointMomentLine.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")

            oSB.AppendLine(ConCat_ht("0", "Load case"))
            oSB.AppendLine(ConCat_ht("1", "Name"))
            oSB.AppendLine(ConCat_ht("2", "Reference Table"))
            oSB.AppendLine(ConCat_ht("3", "Direction"))
            oSB.AppendLine(ConCat_ht("4", "System"))
            oSB.AppendLine(ConCat_ht("5", "Value - F"))
            oSB.AppendLine(ConCat_ht("6", "Coord. definition"))
            oSB.AppendLine(ConCat_ht("7", "Position x"))
            oSB.AppendLine(ConCat_ht("8", "Origin"))
            oSB.AppendLine(ConCat_ht("9", "Repeat (n)"))
            oSB.AppendLine(ConCat_ht("10", "Delta x"))
            oSB.AppendLine("</h>")

            For i = 0 To pointMomentbeamCount - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... line load: " + Str(i))
                End If
                Call WriteMLoadsBeam(oSB, i, SE_pointMomentBeam)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If sloadnr > 0 Then

            'output surface loads ------------------------------------------------------------------
            c = "{BC16B3CA-F464-11D4-94D3-000000000000}"
            cid = "DataAddLoad.EP_SurfaceForceSurface.1"
            t = "A4EDBDAC-D94F-4F14-8C9F-41A1DB046706"
            tid = "DataAddLoad.EP_SurfaceForceSurface.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Load case"))
            oSB.AppendLine(ConCat_ht("2", "Reference Table"))
            oSB.AppendLine(ConCat_ht("3", "Direction"))
            oSB.AppendLine(ConCat_ht("4", "Value"))
            oSB.AppendLine(ConCat_ht("5", "System"))
            oSB.AppendLine(ConCat_ht("6", "Location"))

            oSB.AppendLine("</h>")

            For i = 0 To sloadnr - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... surface load: " + Str(i))
                End If
                Call WriteSLoad(oSB, i, sloads)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If fploadnr > 0 Then

            'output free point loads ------------------------------------------------------------------
            c = "{E03984FC-B420-4C03-8D2F-72EA2FAB147D}"
            cid = "DataAddLoad.EP_PointForceFree.1"
            t = "A3BBFA6A-71DE-4B71-9FDB-04BE4DB979D3"
            tid = "DataAddLoad.EP_PointForceFree.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Load case"))
            oSB.AppendLine(ConCat_ht("1", "Name"))
            oSB.AppendLine(ConCat_ht("2", "Direction"))
            oSB.AppendLine(ConCat_ht("3", "Validity"))
            oSB.AppendLine(ConCat_ht("4", "Select"))
            oSB.AppendLine(ConCat_ht("5", "Value - F"))
            oSB.AppendLine(ConCat_ht("6", "Coord X"))
            oSB.AppendLine(ConCat_ht("7", "Coord Y"))
            oSB.AppendLine(ConCat_ht("8", "Coord Z"))
            oSB.AppendLine(ConCat_ht("9", "System"))
            oSB.AppendLine(ConCat_ht("10", "Selected objects"))
            oSB.AppendLine(ConCat_ht("11", "Validity from"))
            oSB.AppendLine(ConCat_ht("12", "Validity to"))



            oSB.AppendLine("</h>")

            For i = 0 To fploadnr - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... free point load: " + Str(i))
                End If
                Call WriteFPLoad(oSB, scale, i, fploads)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If fpointmomentloadcount > 0 Then

            'output free point loads ------------------------------------------------------------------
            c = "{F92DA832-9046-44F4-B5E2-CEC576BDFC09}"
            cid = "DataAddLoad.EP_PointMomentFree.1"
            t = "245E02B5-FA52-48B8-AF2F-DBA106AF4DE8"
            tid = "DataAddLoad.EP_PointMomentFree.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Load case"))
            oSB.AppendLine(ConCat_ht("1", "Name"))
            oSB.AppendLine(ConCat_ht("2", "Direction"))
            oSB.AppendLine(ConCat_ht("3", "Validity"))
            oSB.AppendLine(ConCat_ht("4", "Select"))
            oSB.AppendLine(ConCat_ht("5", "Value - F"))
            oSB.AppendLine(ConCat_ht("6", "Coord X"))
            oSB.AppendLine(ConCat_ht("7", "Coord Y"))
            oSB.AppendLine(ConCat_ht("8", "Coord Z"))
            oSB.AppendLine(ConCat_ht("9", "System"))
            oSB.AppendLine(ConCat_ht("10", "Selected objects"))
            oSB.AppendLine(ConCat_ht("11", "Validity from"))
            oSB.AppendLine(ConCat_ht("12", "Validity to"))

            oSB.AppendLine("</h>")

            For i = 0 To fpointmomentloadcount - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... free point load: " + Str(i))
                End If
                Call WriteFPMomentLoad(oSB, scale, i, SE_fMomentPointloads)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If flloadnr > 0 Then
            'output free line loads ------------------------------------------------------------------
            c = "{F1A8072A-7476-4C66-AB95-27AEE497E75C}"
            cid = "DataAddLoad.EP_LineForceFree.1"
            t = "48C5854A-C31F-4977-A007-E18F00F955A2"
            tid = "DataAddLoad.EP_LineForceFree.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Load case"))
            oSB.AppendLine(ConCat_ht("1", "Name"))
            oSB.AppendLine(ConCat_ht("2", "Direction"))
            oSB.AppendLine(ConCat_ht("3", "Distribution"))
            oSB.AppendLine(ConCat_ht("4", "Value - P@1"))
            oSB.AppendLine(ConCat_ht("5", "Value - P@2"))
            oSB.AppendLine(ConCat_ht("6", "Validity"))
            oSB.AppendLine(ConCat_ht("7", "Select"))
            oSB.AppendLine(ConCat_ht("8", "System"))
            oSB.AppendLine(ConCat_ht("9", "Location"))
            oSB.AppendLine(ConCat_ht("10", "Table of geometry"))
            oSB.AppendLine(ConCat_ht("11", "Selected objects"))
            oSB.AppendLine(ConCat_ht("12", "Validity from"))
            oSB.AppendLine(ConCat_ht("13", "Validity to"))

            oSB.AppendLine("</h>")

            For i = 0 To flloadnr - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... free line load: " + Str(i))
                End If
                Call WriteFLLoad(oSB, scale, i, flloads)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If fsloadnr > 0 Then
            'output free surface loads ------------------------------------------------------------------
            c = "{3E5FFA16-D1A4-4589-AD5A-4A0FC555E8B8}"
            cid = "DataAddLoad.EP_SurfaceForceFree.1"
            t = "E5D57918-2A77-4FB0-87D0-E936E3568D5A"
            tid = "DataAddLoad.EP_SurfaceForceFree.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Load case"))
            oSB.AppendLine(ConCat_ht("1", "Name"))
            oSB.AppendLine(ConCat_ht("2", "Direction"))
            oSB.AppendLine(ConCat_ht("3", "Distribution"))
            oSB.AppendLine(ConCat_ht("4", "q"))
            oSB.AppendLine(ConCat_ht("5", "Validity"))
            oSB.AppendLine(ConCat_ht("6", "Select"))
            oSB.AppendLine(ConCat_ht("7", "System"))
            oSB.AppendLine(ConCat_ht("8", "Location"))
            oSB.AppendLine(ConCat_ht("9", "Table of geometry"))
            oSB.AppendLine(ConCat_ht("10", "Selected objects"))
            oSB.AppendLine(ConCat_ht("11", "Validity from"))
            oSB.AppendLine(ConCat_ht("12", "Validity to"))

            oSB.AppendLine("</h>")

            For i = 0 To fsloadnr - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... free surface load: " + Str(i))
                End If
                Call WriteFSLoad(oSB, scale, i, fsloads)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If

        If hingenr > 0 Then

            'output hinges ------------------------------------------------------------------
            c = "{56DE8D92-C9D3-11D4-A46B-00C06C542707}"
            cid = "DataAddScia.EP_Hinge.1"
            t = "4E5D91E4-1E43-47BA-9161-7FB3D1934A67"
            tid = "DataAddScia.EP_Hinge.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Reference table"))
            oSB.AppendLine(ConCat_ht("2", "Position"))
            oSB.AppendLine(ConCat_ht("3", "ux"))
            oSB.AppendLine(ConCat_ht("4", "uy"))
            oSB.AppendLine(ConCat_ht("5", "uz"))
            oSB.AppendLine(ConCat_ht("6", "fix"))
            oSB.AppendLine(ConCat_ht("7", "fiy"))
            oSB.AppendLine(ConCat_ht("8", "fiz"))
            oSB.AppendLine(ConCat_ht("9", "Stiff - ux"))
            oSB.AppendLine(ConCat_ht("10", "Stiff - uy"))
            oSB.AppendLine(ConCat_ht("11", "Stiff - uz"))
            oSB.AppendLine(ConCat_ht("12", "Stiff - fix"))
            oSB.AppendLine(ConCat_ht("13", "Stiff - fiy"))
            oSB.AppendLine(ConCat_ht("14", "Stiff - fiz"))

            oSB.AppendLine("</h>")

            For i = 0 To hingenr - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... hinge: " + Str(i))
                End If
                Call WriteHinge(oSB, i, hinges)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If
        If crosslinkscount > 0 Then

            'output crosslinks ------------------------------------------------------------------
            c = "{0CE7AF12-7A9D-4DEC-B8D9-C81562C2DF9F}"
            cid = "EP_DSG_Elements.EP_CrossLink.1"
            t = "13DD1788-9602-4247-ADD5-89443365BDEE"
            tid = "EP_DSG_Elements.EP_CrossLink.1"

            oSB.AppendLine("")
            oSB.AppendLine("<container id=""" & c & """ t=""" & cid & """>")
            oSB.AppendLine("<table id=""" & t & """ t=""" & tid & """>")

            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Type"))
            oSB.AppendLine(ConCat_ht("2", "1st member"))
            oSB.AppendLine(ConCat_ht("3", "2st member"))
            oSB.AppendLine("</h>")

            For i = 0 To crosslinkscount - 1
                If i > 0 And i Mod 100 = 0 Then
                    Rhino.RhinoApp.WriteLine("Creating the XML file string in memory... hinge: " + Str(i))
                End If
                Call WriteCrossLink(oSB, i, crosslinks)

            Next

            oSB.AppendLine("</table>")
            oSB.AppendLine("</container>")
        End If



        'close XML file--------------------------------------------------------------------
        oSB.AppendLine("</project>")

    End Sub

    Private Sub WriteLayer(oSB As Object, i As Long, sE_layers(,) As Object)

        oSB.AppendLine("<obj id = """ & i.ToString() & """" & " nm=""" & sE_layers(i, 0) & """>")
        oSB.AppendLine(ConCat_pv("0", sE_layers(i, 0)))
        oSB.AppendLine(ConCat_pv("1", sE_layers(i, 1)))
        Select Case sE_layers(i, 2)
            Case "yes"
                oSB.AppendLine(ConCat_pv("2", "1"))
            Case "no"
                oSB.AppendLine(ConCat_pv("2", "0"))
            Case Else
                oSB.AppendLine(ConCat_pv("2", "0"))
        End Select
        oSB.AppendLine(ConCat_pv("3", "1"))


        oSB.AppendLine("</obj>")
    End Sub

    Private Sub WriteNode(ByRef oSB, inode, nodes(,)) 'write 1 node to the XML stream

        oSB.AppendLine("<obj nm=""" & Trim(nodes(inode, 0)) & """>")

        oSB.AppendLine(ConCat_pv("0", Trim(nodes(inode, 0))))
        oSB.AppendLine(ConCat_pv("1", CStr(nodes(inode, 1))))
        oSB.AppendLine(ConCat_pv("2", CStr(nodes(inode, 2))))
        oSB.AppendLine(ConCat_pv("3", CStr(nodes(inode, 3))))

        oSB.AppendLine("</obj>")

    End Sub

    Private Sub WriteBeam(ByRef oSB, ibeam, beams(,)) 'write 1 beam to the XML stream
        'a beam consists of: Name, Section, Layer, LineShape, LCSType, LCSParam1, LCSParam2, LCSParam3

        Dim LineShape As String, LineType As String

        Dim nodeStart As String, nodeEnd As String, MiddleNode As String
        Dim i As Integer

        oSB.AppendLine("<obj nm=""" & beams(ibeam, 0) & """>")
        oSB.AppendLine(ConCat_pv("0", beams(ibeam, 0))) 'Name

        Dim ShapeAndNodes As String() = beams(ibeam, 3).Split(New Char() {";"c})
        LineType = ShapeAndNodes.ElementAt(0)
        nodeStart = DupNodeDict(ShapeAndNodes.ElementAt(1))
        nodeEnd = DupNodeDict(ShapeAndNodes.Last())


        oSB.AppendLine(ConCat_pn("1", nodeStart)) 'Beg. node
        oSB.AppendLine(ConCat_pn("2", nodeEnd)) 'End node

        oSB.AppendLine(ConCat_pn("3", beams(ibeam, 2))) 'layer
        oSB.AppendLine(ConCat_pn("4", beams(ibeam, 1))) 'Cross-Section


        Select Case beams(ibeam, 9)
            Case "standard"
                oSB.AppendLine(ConCat_pvt("5", "0", "standard"))
            Case "axial force only"
                oSB.AppendLine(ConCat_pvt("5", "1", "axial force only"))
            Case Else
                oSB.AppendLine(ConCat_pvt("5", "0", "standard"))
        End Select

        Select Case beams(ibeam, 10)
            Case "Centre"
                oSB.AppendLine(ConCat_pvt("6", "1", "Centre"))
            Case "Top"
                oSB.AppendLine(ConCat_pvt("6", "2", "Top"))
            Case "Bottom"
                oSB.AppendLine(ConCat_pvt("6", "4", "Bottom"))
            Case "Left"
                oSB.AppendLine(ConCat_pvt("6", "8", "Left"))
            Case "Top left"
                oSB.AppendLine(ConCat_pvt("6", "10", "Top left"))
            Case "Bottom left"
                oSB.AppendLine(ConCat_pvt("6", "12", "Bottom left"))
            Case "Right"
                oSB.AppendLine(ConCat_pvt("6", "16", "Right"))
            Case "Top right"
                oSB.AppendLine(ConCat_pvt("6", "18", "Top right"))
            Case "Bottom right"
                oSB.AppendLine(ConCat_pvt("6", "20", "Bottom right"))
            Case Else
                oSB.AppendLine(ConCat_pvt("6", "1", "Centre"))
        End Select

        oSB.AppendLine(ConCat_pv("7", beams(ibeam, 11))) 'ey
        oSB.AppendLine(ConCat_pv("8", beams(ibeam, 12))) 'ez


        If LineType = "Arc" Then
            MiddleNode = DupNodeDict(ShapeAndNodes.ElementAt(2))
            oSB.AppendLine(ConCat_opentable("9", ""))
            'Table of Geometry
            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("1", "Node"))
            oSB.AppendLine(ConCat_ht("2", "Edge"))
            oSB.AppendLine("</h>")

            oSB.AppendLine(ConCat_row(0))
            oSB.AppendLine(ConCat_pn("1", nodeStart))
            oSB.appendline(ConCat_pv("2", "1"))
            oSB.AppendLine("</row>")
            oSB.AppendLine(ConCat_row(1))
            oSB.AppendLine(ConCat_pn("1", MiddleNode))
            oSB.AppendLine("</row>")
            oSB.AppendLine(ConCat_row(2))
            oSB.AppendLine(ConCat_pn("1", nodeEnd))
            oSB.AppendLine("</row>")
            oSB.AppendLine(ConCat_closetable("9"))
        ElseIf LineType = "Polyline" Then
            oSB.AppendLine(ConCat_opentable("9", ""))
            'Table of Geometry
            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("1", "Node"))
            oSB.AppendLine(ConCat_ht("2", "Edge"))
            oSB.AppendLine("</h>")
            For i = 1 To ShapeAndNodes.Count - 2
                oSB.AppendLine(ConCat_row(i - 1))
                oSB.AppendLine(ConCat_pn("1", DupNodeDict(ShapeAndNodes.ElementAt(i))))
                oSB.appendline(ConCat_pv("2", "0"))
                oSB.AppendLine("</row>")
            Next i
            oSB.AppendLine(ConCat_row(i - 1))
            oSB.AppendLine(ConCat_pn("1", DupNodeDict(ShapeAndNodes.ElementAt(i))))
            oSB.AppendLine("</row>")

            oSB.AppendLine(ConCat_closetable("9"))
        ElseIf LineType = "Line" Then 'line
            oSB.AppendLine(ConCat_opentable("9", ""))
            'Table of Geometry
            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("1", "Node"))
            oSB.AppendLine(ConCat_ht("2", "Edge"))
            oSB.AppendLine("</h>")
            oSB.AppendLine(ConCat_row(0))
            oSB.AppendLine(ConCat_pn("1", nodeStart))
            oSB.appendline(ConCat_pv("2", "0"))
            oSB.AppendLine("</row>")
            oSB.AppendLine(ConCat_row(1))
            oSB.AppendLine(ConCat_pn("1", nodeEnd))
            oSB.AppendLine("</row>")
            oSB.AppendLine(ConCat_closetable("9"))
        ElseIf LineType = "Spline" Then
            oSB.AppendLine(ConCat_opentable("9", ""))
            'Table of Geometry
            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("1", "Node"))
            oSB.AppendLine(ConCat_ht("2", "Edge"))
            oSB.AppendLine("</h>")
            oSB.AppendLine(ConCat_row(0))
            oSB.AppendLine(ConCat_pn("1", nodeStart))
            oSB.appendline(ConCat_pv("2", "7"))
            oSB.AppendLine("</row>")
            For i = 2 To ShapeAndNodes.Count - 1
                oSB.AppendLine(ConCat_row(i - 1))
                oSB.AppendLine(ConCat_pn("1", DupNodeDict(ShapeAndNodes.ElementAt(i))))
                oSB.AppendLine("</row>")
            Next i
            oSB.AppendLine(ConCat_closetable("9"))
        End If
        Select Case beams(ibeam, 8)
            Case "general"
                oSB.appendline(ConCat_pvt("10", "0", "general (0)")) 'type
            Case "column"
                oSB.appendline(ConCat_pvt("10", "2", "column (100)"))
            Case "gable column"
                oSB.appendline(ConCat_pvt("10", "3", "gable column (70)"))
            Case "secondary column"
                oSB.appendline(ConCat_pvt("10", "4", "secondary column (60)"))
            Case "rafter"
                oSB.appendline(ConCat_pvt("10", "5", "rafter (90)"))
            Case "purlin"
                oSB.appendline(ConCat_pvt("10", "6", "purlin (0)"))
            Case "roof bracing"
                oSB.appendline(ConCat_pvt("10", "7", "roof bracing (0)"))
            Case "wall bracing"
                oSB.appendline(ConCat_pvt("10", "8", "wall bracing (0)"))
            Case "girt"
                oSB.appendline(ConCat_pvt("10", "9", "girt (0)"))
            Case "truss chord"
                oSB.appendline(ConCat_pvt("10", "10", "truss chord (95)"))
            Case "truss diagonal"
                oSB.appendline(ConCat_pvt("10", "11", "truss diagonal (90)"))
            Case "plate rib"
                oSB.appendline(ConCat_pvt("10", "12", "plate rib (92)"))
            Case "beam slab"
                oSB.appendline(ConCat_pvt("10", "13", "beam slab (99)"))
            Case Else
                oSB.appendline(ConCat_pvt("10", "0", "general (0)")) 'type
        End Select



        If beams(ibeam, 4) = 0 Then 'standard LCS
            oSB.AppendLine(ConCat_pv("11", beams(ibeam, 4))) 'LCS type
            oSB.AppendLine(ConCat_pv("12", beams(ibeam, 5))) 'LCS rotation
        Else 'LCS by Z vector
            oSB.AppendLine(ConCat_pv("11", beams(ibeam, 4))) 'LCS type
            oSB.AppendLine(ConCat_pv("13", beams(ibeam, 5))) 'X
            oSB.AppendLine(ConCat_pv("14", beams(ibeam, 6))) 'Y
            oSB.AppendLine(ConCat_pv("15", beams(ibeam, 7))) 'Z
        End If

        oSB.AppendLine("</obj>")

    End Sub
    Private Sub WritePressTensionOnlyBeamNL(ByRef oSB, i, beamnlocalnonlin(,))

        oSB.AppendLine("<obj nm=""" & "PTBNL" & Trim(Str(i)) & """>")
        oSB.AppendLine(ConCat_pv("0", "PTBNL" & Trim(Str(i)))) 'Name
        'write beam name as reference table
        oSB.AppendLine("<p1 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h2 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")
        oSB.AppendLine(ConCat_pv("0", "{ECB5D684-7357-11D4-9F6C-00104BC3B443}"))
        oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Beam.1"))
        oSB.AppendLine(ConCat_pv("2", beamnlocalnonlin(i, 0)))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p1>")
        'end of reference table
        Select Case beamnlocalnonlin(i, 1)
            Case "Press only"
                oSB.AppendLine(ConCat_pvt("2", "0", "Press only"))
            Case "Tension only"
                oSB.AppendLine(ConCat_pvt("2", "1", "Tension only"))
        End Select
        oSB.AppendLine("</obj>")
    End Sub
    Private Sub WriteLimitForceBeamNL(ByRef oSB, i, LimitForce(,))
        oSB.AppendLine("<obj nm=""" & "LFBNL" & Trim(Str(i)) & """>")
        oSB.AppendLine(ConCat_pv("0", "LFBNL" & Trim(Str(i)))) 'Name
        'write beam name as reference table
        oSB.AppendLine("<p1 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h2 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")
        oSB.AppendLine(ConCat_pv("0", "{ECB5D684-7357-11D4-9F6C-00104BC3B443}"))
        oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Beam.1"))
        oSB.AppendLine(ConCat_pv("2", LimitForce(i, 0)))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p1>")
        'end of reference table
        oSB.AppendLine(ConCat_pvt("2", "2", "Limit force"))
        Select Case LimitForce(i, 1)
            Case "Limit tension"
                oSB.AppendLine(ConCat_pvt("3", "0", "Limit tension"))
            Case "Limit compression"
                oSB.AppendLine(ConCat_pvt("3", "1", "Limit compression"))
        End Select
        Select Case LimitForce(i, 2)
            Case "Buckling"
                oSB.AppendLine(ConCat_pvt("4", "0", "Buckling ( results zero )"))
            Case "Tension only"
                oSB.AppendLine(ConCat_pvt("4", "1", "Plastic yielding"))
        End Select
        oSB.AppendLine(ConCat_pv("5", LimitForce(i, 3)))

        oSB.AppendLine("</obj>")
    End Sub
    Private Sub WriteGapLocalBeamNL(ByRef oSB, igap, gaps(,))
        oSB.AppendLine("<obj nm=""" & "GBNL" & Trim(Str(igap)) & """>")
        oSB.AppendLine(ConCat_pv("0", "GBNL" & Trim(Str(igap)))) 'Name
        'write beam name as reference table
        oSB.AppendLine("<p1 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h2 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")
        oSB.AppendLine(ConCat_pv("0", "{ECB5D684-7357-11D4-9F6C-00104BC3B443}"))
        oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Beam.1"))
        oSB.AppendLine(ConCat_pv("2", gaps(igap, 0)))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p1>")
        'end of reference table
        oSB.AppendLine(ConCat_pvt("2", "3", "Gap"))
        Select Case gaps(igap, 1)
            Case "Press only"
                oSB.AppendLine(ConCat_pvt("3", "0", "Press only"))
            Case "Tension only"
                oSB.AppendLine(ConCat_pvt("3", "1", "Tension only"))
            Case "Both directions"
                oSB.AppendLine(ConCat_pvt("3", "2", "Both directions"))
        End Select
        oSB.AppendLine(ConCat_pv("4", gaps(igap, 2)))
        Select Case gaps(igap, 3)
            Case "Begin"
                oSB.AppendLine(ConCat_pvt("5", "0", "Begin"))
            Case "End"
                oSB.AppendLine(ConCat_pvt("5", "1", "End"))
        End Select
        oSB.AppendLine("</obj>")
    End Sub

    Private Sub WriteCableBeamNL(ByRef oSB, icable, cables(,))
        oSB.AppendLine("<obj nm=""" & "CBNL" & Trim(Str(icable)) & """>")
        oSB.AppendLine(ConCat_pv("0", "CBNL" & Trim(Str(icable)))) 'Name
        'write beam name as reference table
        oSB.AppendLine("<p1 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h2 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")
        oSB.AppendLine(ConCat_pv("0", "{ECB5D684-7357-11D4-9F6C-00104BC3B443}"))
        oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Beam.1"))
        oSB.AppendLine(ConCat_pv("2", cables(icable, 0)))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p1>")
        'end of reference table
        oSB.AppendLine(ConCat_pvt("2", "5", "Cable"))
        Select Case cables(icable, 1)

            Case "Straight"
                oSB.AppendLine(ConCat_pvt("3", "0", "Straight"))
            Case "Calculated"
                oSB.AppendLine(ConCat_pvt("3", "1", "Calculated"))


        End Select
        If (cables(icable, 2)) Then
            oSB.AppendLine(ConCat_pv("4", 1))
        Else
            oSB.AppendLine(ConCat_pv("4", 0))
        End If
        oSB.AppendLine(ConCat_pv("5", cables(icable, 3)))
        oSB.AppendLine(ConCat_pv("6", cables(icable, 4)))
        oSB.AppendLine(ConCat_pv("7", cables(icable, 5)))


        oSB.AppendLine("</obj>")
    End Sub

    Private Sub WriteSurface(ByRef osb, isurface, surfaces(,)) 'write 1 surface to the XML stream
        Dim row_id As Long, inode As Long
        Dim iedge As Long
        Dim edges() As String, nodes() As String

        osb.AppendLine("<obj nm=""" & surfaces(isurface, 0) & """>")
        osb.AppendLine(ConCat_pv("0", surfaces(isurface, 0)))
        osb.AppendLine(ConCat_pn("1", surfaces(isurface, 4))) 'layer
        Select Case surfaces(isurface, 1)
            Case "Shell"
                osb.AppendLine(ConCat_pv("2", "2")) 'Shell type
            Case "Plate"
                osb.AppendLine(ConCat_pv("2", "0")) 'Plate type
            Case "Wall"
                osb.AppendLine(ConCat_pv("2", "1")) 'wall type
            Case Else
                osb.AppendLine(ConCat_pv("2", "0")) 'Plate type
        End Select

        osb.AppendLine(ConCat_pn("3", surfaces(isurface, 2))) 'material
        Select Case surfaces(isurface, 9)
            Case "none"
                osb.AppendLine(ConCat_pvt("4", "0", "none"))
            Case "Press only"
                osb.AppendLine(ConCat_pvt("4", "1", "Press only"))
            Case "Membrane"
                osb.AppendLine(ConCat_pvt("4", "2", "Membrane"))
            Case Else
                osb.AppendLine(ConCat_pvt("4", "0", "none"))
        End Select

        Dim thickness() As String
        thickness = Split(surfaces(isurface, 3), "|")
        Dim thicknessType As String
        thicknessType = thickness(0)
        Select Case thicknessType
            Case "constant"
                osb.AppendLine(ConCat_pvt("5", "0", "constant"))
                Dim thck As Double
                thck = thickness(1) / 1000
                osb.AppendLine(ConCat_pv("7", CStr(thck))) 'thickness
            Case "variable"
                osb.AppendLine(ConCat_pvt("5", "1", "variable"))
                Dim variableThicknessType As String
                variableThicknessType = thickness(1)

                Select Case variableThicknessType
                    Case "Global X"
                        osb.AppendLine(ConCat_pvt("6", "1", "Global X"))
                    Case "Global Y"
                        osb.AppendLine(ConCat_pvt("6", "2", "Global Y"))
                    Case "Global Z"
                        osb.AppendLine(ConCat_pvt("6", "3", "Global Z"))
                    Case "Local X"
                        osb.AppendLine(ConCat_pvt("6", "4", "Local X"))
                    Case "Local Y"
                        osb.AppendLine(ConCat_pvt("6", "5", "Local Y"))
                    Case "Variable in two directions"
                        osb.AppendLine(ConCat_pvt("6", "6", "Variable in two directions"))
                    Case "Radial"
                        osb.AppendLine(ConCat_pvt("6", "7", "Radial"))
                    Case "Variable in 4 pt."
                        osb.AppendLine(ConCat_pvt("6", "8", "Variable in 4 pt."))

                End Select
                Dim thicknessProperties() As String
                Dim i As Long
                Dim thicknesses As New List(Of Double)
                Dim thicknessNodes As New List(Of String)
                If variableThicknessType = "Radial" Then
                    For i = 2 To thickness.Count() - 1
                        osb.AppendLine(ConCat_pvx("7", thickness(i) / 1000, i - 2)) 'value in mm
                    Next
                Else
                    For i = 2 To thickness.Count() - 1
                        thicknessProperties = Split(thickness(i), ";")
                        thicknesses.Add(thicknessProperties(0))
                        thicknessNodes.Add(thicknessProperties(1))
                    Next
                    For i = 0 To thicknesses.Count() - 1
                        osb.AppendLine(ConCat_pvx("7", thicknesses(i) / 1000, i)) 'value in mm
                    Next
                    For i = 0 To thicknessNodes.Count() - 1
                        osb.AppendLine(ConCat_pvx("8", thicknessNodes(i), i))
                    Next
                End If


        End Select




        Select Case surfaces(isurface, 7)
            Case "Centre"
                osb.AppendLine(ConCat_pvt("9", "1", "Centre"))
            Case "Top"
                osb.AppendLine(ConCat_pvt("9", "2", "Top"))
            Case "Bottom"
                osb.AppendLine(ConCat_pvt("9", "4", "Bottom"))
            Case Else
                osb.AppendLine(ConCat_pvt("9", "1", "Centre"))
        End Select

        osb.AppendLine(ConCat_pv("10", surfaces(isurface, 8)))

        'table of geometry
        osb.AppendLine(ConCat_opentable("11", ""))
        osb.AppendLine("<h>")
        osb.AppendLine(ConCat_ht("0", "Closed curve"))
        osb.AppendLine(ConCat_ht("1", "Node"))
        osb.AppendLine(ConCat_ht("2", "Edge"))
        osb.AppendLine("</h>")

        'loop through all edges
        row_id = 0
        edges = Strings.Split(surfaces(isurface, 5), "|")

        For iedge = 0 To edges.Count - 1
            inode = 0
            osb.AppendLine(ConCat_row(row_id))
            osb.AppendLine(ConCat_pv("0", "1")) 'Closed curve
            osb.AppendLine(ConCat_pn("1", DupNodeDict(Trim(Split(edges(iedge), ";")(1))))) 'first node
            Select Case Strings.Trim(Strings.Split(edges(iedge), ";")(0)) 'curve type
                Case "Line"
                    osb.AppendLine(ConCat_pvt("2", "0", "Line"))
                Case "Arc"
                    osb.AppendLine(ConCat_pvt("2", "1", "Circle arc"))
                Case "Spline"
                    osb.AppendLine(ConCat_pvt("2", "7", "Spline"))
                Case "Circle"
                    osb.AppendLine(ConCat_pvt("2", "2", "Circle by centre and vertex"))
            End Select

            While inode < UBound(Split(edges(iedge), ";")) - 1
                inode = inode + 1
                row_id = row_id + 1
                osb.AppendLine("</row>")
                osb.AppendLine(ConCat_row(row_id))
                If Split(edges(iedge), ";")(1 + inode).Contains("[") Then
                    Dim Normal As String
                    Normal = Split(edges(iedge), ";")(1 + inode).Replace(",", ";")
                    osb.AppendLine(ConCat_pin("1", "-1", Normal))
                Else
                    osb.AppendLine(ConCat_pn("1", Trim(Split(edges(iedge), ";")(1 + inode))))
                End If


            End While
            osb.AppendLine("</row>")
            row_id = row_id + 1

        Next


        osb.AppendLine(ConCat_closetable("11"))

        'loop through all nodes
        row_id = 0
        If Not String.IsNullOrEmpty(surfaces(isurface, 6)) Then
            nodes = Strings.Split(surfaces(isurface, 6), ";")
            'internal nodes
            If nodes.Count <> 0 And Not String.IsNullOrEmpty(nodes(0)) Then
                osb.AppendLine(ConCat_opentable("12", ""))
                osb.AppendLine("<h>")
                osb.AppendLine(ConCat_ht("0", "Node"))
                osb.AppendLine("</h>")



                For inode = 0 To nodes.Count - 1
                    osb.AppendLine(ConCat_row(row_id))
                    osb.AppendLine(ConCat_pn("0", DupNodeDict(Trim(nodes(inode)))))
                    osb.AppendLine("</row>")
                    row_id += 1

                Next inode
            End If

            osb.AppendLine(ConCat_closetable("12"))
        End If

        osb.AppendLine(ConCat_pv("13", surfaces(isurface, 10)))
        osb.AppendLine(ConCat_pv("14", surfaces(isurface, 11)))


        osb.AppendLine(ConCat_pvt("15", "1", "Standard"))

        osb.AppendLine("</obj>")

    End Sub


    Private Sub WriteLoadPanels(ByRef osb, iloadpanel, loadpanels(,)) 'write 1 surface to the XML stream
        Dim row_id As Long, inode As Long
        Dim iedge As Long
        Dim edges() As String, nodes() As String

        osb.AppendLine("<obj nm=""" & loadpanels(iloadpanel, 0) & """>")
        osb.AppendLine(ConCat_pv("0", loadpanels(iloadpanel, 0))) ' name
        osb.AppendLine(ConCat_pn("1", loadpanels(iloadpanel, 4))) 'layer

        'table of geometry
        osb.AppendLine(ConCat_opentable("2", ""))
        osb.AppendLine("<h>")
        osb.AppendLine(ConCat_ht("0", "Closed curve"))
        osb.AppendLine(ConCat_ht("1", "Node"))
        osb.AppendLine(ConCat_ht("2", "Edge"))
        osb.AppendLine("</h>")

        'loop through all edges
        row_id = 0
        edges = Strings.Split(loadpanels(iloadpanel, 2), "|")

        For iedge = 0 To edges.Count - 1
            inode = 0
            osb.AppendLine(ConCat_row(row_id))
            osb.AppendLine(ConCat_pv("0", "1")) 'Closed curve
            osb.AppendLine(ConCat_pn("1", DupNodeDict(Trim(Split(edges(iedge), ";")(1))))) 'first node
            Select Case Strings.Trim(Strings.Split(edges(iedge), ";")(0)) 'curve type
                Case "Line"
                    osb.AppendLine(ConCat_pvt("2", "0", "Line"))
                Case "Arc"
                    osb.AppendLine(ConCat_pvt("2", "1", "Circle arc"))
                Case "Spline"
                    osb.AppendLine(ConCat_pvt("2", "7", "Spline"))
                Case "Circle"
                    osb.AppendLine(ConCat_pvt("2", "2", "Circle by centre and vertex"))
            End Select

            While inode < UBound(Split(edges(iedge), ";")) - 1
                inode = inode + 1
                row_id = row_id + 1
                osb.AppendLine("</row>")
                osb.AppendLine(ConCat_row(row_id))
                If Split(edges(iedge), ";")(1 + inode).Contains("[") Then
                    Dim Normal As String
                    Normal = Split(edges(iedge), ";")(1 + inode).Replace(",", ";")
                    osb.AppendLine(ConCat_pin("1", "-1", Normal))
                Else
                    osb.AppendLine(ConCat_pn("1", Trim(Split(edges(iedge), ";")(1 + inode))))
                End If


            End While
            osb.AppendLine("</row>")
            row_id = row_id + 1

        Next

        osb.AppendLine(ConCat_closetable("2"))



        osb.AppendLine(ConCat_pvt("3", "5", "Load panel"))

        Dim panelType As String
        panelType = GetStringForPanelType(loadpanels(iloadpanel, 3))
        osb.AppendLine(ConCat_pvt("4", loadpanels(iloadpanel, 3), panelType))
        Dim transferDirection As String
        transferDirection = GetStringForTransferDirection(loadpanels(iloadpanel, 4))
        osb.AppendLine(ConCat_pvt("5", loadpanels(iloadpanel, 4), transferDirection))
        osb.AppendLine(ConCat_pv("6", "50"))
        osb.AppendLine(ConCat_pv("7", "50"))
        'osb.AppendLine(ConCat_ht("6", "Transfer in X [%]"))
        'osb.AppendLine(ConCat_ht("7", "Transfer in Y [%]"))


        Dim transferMethod As String
        transferMethod = GetStringForTransferMethod(loadpanels(iloadpanel, 5))
        osb.AppendLine(ConCat_pvt("8", loadpanels(iloadpanel, 5), transferMethod))
        osb.AppendLine(ConCat_pvt("9", "0", "All")) 'selection of entities - -Z +Z all



        osb.AppendLine(ConCat_pv("10", loadpanels(iloadpanel, 6)))
        osb.AppendLine(ConCat_pv("11", loadpanels(iloadpanel, 7)))




        osb.AppendLine("</obj>")

    End Sub
    Private Sub WriteOpening(ByRef osb, iopening, openings(,)) 'write 1 opening to the XML stream
        Dim row_id As Long, inode As Long
        Dim iedge As Long
        Dim edges() As String

        osb.AppendLine("<obj nm=""" & openings(iopening, 0) & """>")
        'write surface name as reference table
        osb.AppendLine("<p0 t="""">")
        osb.AppendLine("<h>")
        osb.AppendLine("<h0 t=""Member Type""/>")
        osb.AppendLine("<h1 t=""Member Type Name""/>")
        osb.AppendLine("<h2 t=""Member Name""/>")
        osb.AppendLine("</h>")
        osb.AppendLine("<row id=""0"">")
        osb.AppendLine(ConCat_pv("0", "{8708ED31-8E66-11D4-AD94-F6F5DE2BE344}"))
        osb.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Plane.1"))
        osb.AppendLine(ConCat_pv("2", openings(iopening, 1)))
        osb.AppendLine("</row>")
        osb.AppendLine("</p0>")
        'end of reference table

        osb.AppendLine(ConCat_pv("1", openings(iopening, 0))) 'name
        osb.AppendLine(ConCat_opentable("3", ""))
        'table of geometry
        osb.AppendLine("<h>")
        osb.AppendLine(ConCat_ht("0", "Closed curve"))
        osb.AppendLine(ConCat_ht("1", "Node"))
        osb.AppendLine(ConCat_ht("2", "Edge"))
        osb.AppendLine("</h>")

        'Loop through all edges
        row_id = 0
        edges = Strings.Split(openings(iopening, 2), "|")

        For iedge = 0 To edges.Count - 1
            inode = 0
            osb.AppendLine(ConCat_row(row_id))
            osb.AppendLine(ConCat_pv("0", "1")) 'Closed curve
            osb.AppendLine(ConCat_pn("1", DupNodeDict(Trim(Split(edges(iedge), ";")(1))))) 'first node
            Select Case Strings.Trim(Strings.Split(edges(iedge), ";")(0)) 'curve type
                Case "Line"
                    osb.AppendLine(ConCat_pvt("2", "0", "Line"))
                Case "Arc"
                    osb.AppendLine(ConCat_pvt("2", "1", "Circle arc"))
                Case "Circle"
                    osb.AppendLine(ConCat_pvt("2", "4", "Circle by 3 pts"))
                Case "Spline"
                    osb.AppendLine(ConCat_pvt("2", "7", "Spline"))
            End Select

            While inode < UBound(Split(edges(iedge), ";")) - 1
                inode = inode + 1
                row_id = row_id + 1
                osb.AppendLine("</row>")
                osb.AppendLine(ConCat_row(row_id))
                osb.AppendLine(ConCat_pn("1", Trim(Split(edges(iedge), ";")(1 + inode))))

            End While
            osb.AppendLine("</row>")
            row_id = row_id + 1

        Next

        osb.AppendLine(ConCat_closetable("3"))
        osb.AppendLine("</obj>")

    End Sub

    Private Sub WriteInternalEdge(ByRef osb, iInternalEdge, SlabInternalEdges(,))

        osb.AppendLine("<obj nm=""" & SlabInternalEdges(iInternalEdge, 0) & """>")

        osb.AppendLine(ConCat_pv("0", SlabInternalEdges(iInternalEdge, 0))) ' name
        osb.AppendLine(ConCat_pn("1", SlabInternalEdges(iInternalEdge, 1))) ' 2D member

        Dim nodeStart As String, nodeEnd As String, MiddleNode As String

        Dim ShapeAndNodes As String() = SlabInternalEdges(iInternalEdge, 2).Split(New Char() {";"c})
        Dim LineType = ShapeAndNodes.ElementAt(0)
        nodeStart = DupNodeDict(ShapeAndNodes.ElementAt(1))
        nodeEnd = DupNodeDict(ShapeAndNodes.Last())
        Dim i As Long = 0
        ' shape
        osb.AppendLine(ConCat_pv("2", LineType)) ' Shape
        osb.AppendLine(ConCat_opentable("3", "")) 'table of geometry
        If LineType = "Arc" Then

            MiddleNode = DupNodeDict(ShapeAndNodes.ElementAt(2))

            'Table of Geometry
            osb.AppendLine("<h>")
            osb.AppendLine(ConCat_ht("1", "Node"))
            osb.AppendLine(ConCat_ht("2", "Edge"))
            osb.AppendLine("</h>")

            osb.AppendLine(ConCat_row(0))
            osb.AppendLine(ConCat_pn("1", nodeStart))
            osb.appendline(ConCat_pv("2", "1"))
            osb.AppendLine("</row>")
            osb.AppendLine(ConCat_row(1))
            osb.AppendLine(ConCat_pn("1", MiddleNode))
            osb.AppendLine("</row>")
            osb.AppendLine(ConCat_row(2))
            osb.AppendLine(ConCat_pn("1", nodeEnd))
            osb.AppendLine("</row>")

        ElseIf LineType = "Polyline" Then

            'Table of Geometry
            osb.AppendLine("<h>")
            osb.AppendLine(ConCat_ht("1", "Node"))
            osb.AppendLine(ConCat_ht("2", "Edge"))
            osb.AppendLine("</h>")
            For i = 1 To ShapeAndNodes.Count - 2
                osb.AppendLine(ConCat_row(i - 1))
                osb.AppendLine(ConCat_pn("1", DupNodeDict(ShapeAndNodes.ElementAt(i))))
                osb.appendline(ConCat_pv("2", "0"))
                osb.AppendLine("</row>")
            Next i
            osb.AppendLine(ConCat_row(i - 1))
            osb.AppendLine(ConCat_pn("1", DupNodeDict(ShapeAndNodes.ElementAt(i))))
            osb.AppendLine("</row>")


        ElseIf LineType = "Line" Then 'line

            'Table of Geometry
            osb.AppendLine("<h>")
            osb.AppendLine(ConCat_ht("1", "Node"))
            osb.AppendLine(ConCat_ht("2", "Edge"))
            osb.AppendLine("</h>")
            osb.AppendLine(ConCat_row(0))
            osb.AppendLine(ConCat_pn("1", nodeStart))
            osb.appendline(ConCat_pv("2", "0"))
            osb.AppendLine("</row>")
            osb.AppendLine(ConCat_row(1))
            osb.AppendLine(ConCat_pn("1", nodeEnd))
            osb.AppendLine("</row>")

        ElseIf LineType = "Spline" Then

            'Table of Geometry
            osb.AppendLine("<h>")
            osb.AppendLine(ConCat_ht("1", "Node"))
            osb.AppendLine(ConCat_ht("2", "Edge"))
            osb.AppendLine("</h>")
            osb.AppendLine(ConCat_row(0))
            osb.AppendLine(ConCat_pn("1", nodeStart))
            osb.appendline(ConCat_pv("2", "7"))
            osb.AppendLine("</row>")
            For i = 2 To ShapeAndNodes.Count - 1
                osb.AppendLine(ConCat_row(i - 1))
                osb.AppendLine(ConCat_pn("1", DupNodeDict(ShapeAndNodes.ElementAt(i))))
                osb.AppendLine("</row>")
            Next i

        End If
        osb.AppendLine(ConCat_closetable("3"))

        osb.AppendLine("</obj>")

    End Sub

    Private Sub WriteRigidArm(ByRef osb, iRigidArm, RigidArms(,))

        osb.AppendLine("<obj nm=""" & RigidArms(iRigidArm, 0) & """>")

        osb.appendline(ConCat_pv("0", RigidArms(iRigidArm, 0)))
        osb.AppendLine(ConCat_pn("1", RigidArms(iRigidArm, 1)))
        osb.appendline(ConCat_pn("2", RigidArms(iRigidArm, 2)))
        If (RigidArms(iRigidArm, 3)) Then
            osb.appendline(ConCat_pv("3", "1"))
        Else
            osb.appendline(ConCat_pv("3", "0"))
        End If
        If (RigidArms(iRigidArm, 4)) Then
            osb.appendline(ConCat_pv("4", "1"))
        Else
            osb.appendline(ConCat_pv("4", "0"))
        End If


        osb.AppendLine("</obj>")


    End Sub

    Private Sub WriteSection(ByRef oSB, sectionname, sectioncode, sectiondef, sectionmat) 'write 1 profile: hot-rolled steel or concrete

        Dim sectiontype As String
        Dim formtype As String
        Dim formcode As Long
        Dim sectH As Double, sectB As Double, sectD As Double, sectBh As Double, sectBs As Double, sectts As Double, sectth As Double, sects As Double
        Dim sectsh As Double, sectBa As Double, sectBb As Double, secttha As Double, sectthb As Double, sectBc As Double, sectthc As Double
        oSB.AppendLine("<obj nm=""" & sectionname & """>")
        oSB.AppendLine(ConCat_pv("0", sectionname)) 'Name

        formtype = Strings.UCase(Strings.Left(sectioncode, 4))

        If formtype = "FORM" Then
            'steel rolled profiles
            formcode = Strings.Split(sectioncode, "-")(1)

            oSB.AppendLine(ConCat_pv("1", "EP_CssLib.EP_ProfLib_Rolled.1"))
            oSB.AppendLine(ConCat_pv("2", formcode))
            oSB.AppendLine("<p3 t="""">")
            oSB.AppendLine("<h>")
            oSB.AppendLine(ConCat_ht("0", "Name"))
            oSB.AppendLine(ConCat_ht("1", "Material"))
            oSB.AppendLine(ConCat_ht("5", "Rolled section"))
            oSB.AppendLine("</h>")
            oSB.AppendLine("<row id=""0"">")
            oSB.AppendLine(ConCat_pv("0", "Material"))
            oSB.AppendLine(ConCat_pn("1", sectionmat))
            oSB.AppendLine("</row>")
            oSB.AppendLine("<row id=""1"">")
            oSB.AppendLine(ConCat_pv("5", sectiondef & "|" & formcode))
            oSB.AppendLine("</row>")
            oSB.AppendLine("</p3>")

        ElseIf formtype = "CONC" Then

            sectiontype = Strings.UCase(Strings.Left(sectiondef, 4))

            Select Case sectiontype
                Case "RECT"
                    'get height and width
                    sectH = Split(Mid(sectiondef, 5), "x")(0) / 1000
                    sectB = Split(Mid(sectiondef, 5), "x")(1) / 1000
                    oSB.AppendLine(ConCat_pv("1", "EP_CssLib.EP_ProfLib_Concrete.1"))
                    oSB.AppendLine(ConCat_pv("2", "0")) '> rectangle
                    oSB.AppendLine("<p3 t="""">")
                    oSB.AppendLine("<h>")
                    oSB.AppendLine(ConCat_ht("0", "Name"))
                    oSB.AppendLine(ConCat_ht("1", "Material"))
                    oSB.AppendLine(ConCat_ht("4", "Length"))
                    oSB.AppendLine("</h>")
                    oSB.AppendLine("<row id=""0"">")
                    oSB.AppendLine(ConCat_pv("0", "Material"))
                    oSB.AppendLine(ConCat_pn("1", sectionmat))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""1"">")
                    oSB.AppendLine(ConCat_pv("0", "H"))
                    oSB.AppendLine(ConCat_pv("4", sectH))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""2"">")
                    oSB.AppendLine(ConCat_pv("0", "B"))
                    oSB.AppendLine(ConCat_pv("4", sectB))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("</p3>")
                Case "ISEC"
                    sectH = Split(Mid(sectiondef, 5), "x")(0) / 1000
                    sectBh = Split(Mid(sectiondef, 5), "x")(1) / 1000
                    sectBs = Split(Mid(sectiondef, 5), "x")(2) / 1000
                    sectts = Split(Mid(sectiondef, 5), "x")(3) / 1000
                    sectth = Split(Mid(sectiondef, 5), "x")(4) / 1000
                    sects = Split(Mid(sectiondef, 5), "x")(5) / 1000
                    oSB.AppendLine(ConCat_pv("1", "EP_CssLib.EP_ProfLib_Concrete.1"))
                    oSB.AppendLine(ConCat_pv("2", "1")) '> Isection
                    oSB.AppendLine("<p3 t="""">")
                    oSB.AppendLine("<h>")
                    oSB.AppendLine(ConCat_ht("0", "Name"))
                    oSB.AppendLine(ConCat_ht("1", "Material"))
                    oSB.AppendLine(ConCat_ht("4", "Length"))
                    oSB.AppendLine("</h>")
                    oSB.AppendLine("<row id=""0"">")
                    oSB.AppendLine(ConCat_pv("0", "Material"))
                    oSB.AppendLine(ConCat_pn("1", sectionmat))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""1"">")
                    oSB.AppendLine(ConCat_pv("0", "H"))
                    oSB.AppendLine(ConCat_pv("4", sectH))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""2"">")
                    oSB.AppendLine(ConCat_pv("0", "Bh"))
                    oSB.AppendLine(ConCat_pv("4", sectBh))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""3"">")
                    oSB.AppendLine(ConCat_pv("0", "Bs"))
                    oSB.AppendLine(ConCat_pv("4", sectBs))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""4"">")
                    oSB.AppendLine(ConCat_pv("0", "ts"))
                    oSB.AppendLine(ConCat_pv("4", sectts))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""5"">")
                    oSB.AppendLine(ConCat_pv("0", "th"))
                    oSB.AppendLine(ConCat_pv("4", sectth))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""6"">")
                    oSB.AppendLine(ConCat_pv("0", "s"))
                    oSB.AppendLine(ConCat_pv("4", sects))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("</p3>")
                Case "TSEC"
                    sectH = Split(Mid(sectiondef, 5), "x")(0) / 1000
                    sectB = Split(Mid(sectiondef, 5), "x")(1) / 1000
                    sectth = Split(Mid(sectiondef, 5), "x")(2) / 1000
                    sectsh = Split(Mid(sectiondef, 5), "x")(3) / 1000
                    oSB.AppendLine(ConCat_pv("1", "EP_CssLib.EP_ProfLib_Concrete.1"))
                    oSB.AppendLine(ConCat_pv("2", "2")) '> Tsection
                    oSB.AppendLine("<p3 t="""">")
                    oSB.AppendLine("<h>")
                    oSB.AppendLine(ConCat_ht("0", "Name"))
                    oSB.AppendLine(ConCat_ht("1", "Material"))
                    oSB.AppendLine(ConCat_ht("4", "Length"))
                    oSB.AppendLine("</h>")
                    oSB.AppendLine("<row id=""0"">")
                    oSB.AppendLine(ConCat_pv("0", "Material"))
                    oSB.AppendLine(ConCat_pn("1", sectionmat))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""1"">")
                    oSB.AppendLine(ConCat_pv("0", "H"))
                    oSB.AppendLine(ConCat_pv("4", sectH))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""2"">")
                    oSB.AppendLine(ConCat_pv("0", "B"))
                    oSB.AppendLine(ConCat_pv("4", sectB))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""3"">")
                    oSB.AppendLine(ConCat_pv("0", "th"))
                    oSB.AppendLine(ConCat_pv("4", sectth))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""4"">")
                    oSB.AppendLine(ConCat_pv("0", "sh"))
                    oSB.AppendLine(ConCat_pv("4", sectsh))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("</p3>")
                Case "LSEC"
                    sectH = Split(Mid(sectiondef, 5), "x")(0) / 1000
                    sectB = Split(Mid(sectiondef, 5), "x")(1) / 1000
                    sectth = Split(Mid(sectiondef, 5), "x")(2) / 1000
                    sectsh = Split(Mid(sectiondef, 5), "x")(3) / 1000
                    oSB.AppendLine(ConCat_pv("1", "EP_CssLib.EP_ProfLib_Concrete.1"))
                    oSB.AppendLine(ConCat_pv("2", "3")) '> L section
                    oSB.AppendLine("<p3 t="""">")
                    oSB.AppendLine("<h>")
                    oSB.AppendLine(ConCat_ht("0", "Name"))
                    oSB.AppendLine(ConCat_ht("1", "Material"))
                    oSB.AppendLine(ConCat_ht("4", "Length"))
                    oSB.AppendLine("</h>")
                    oSB.AppendLine("<row id=""0"">")
                    oSB.AppendLine(ConCat_pv("0", "Material"))
                    oSB.AppendLine(ConCat_pn("1", sectionmat))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""1"">")
                    oSB.AppendLine(ConCat_pv("0", "H"))
                    oSB.AppendLine(ConCat_pv("4", sectH))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""2"">")
                    oSB.AppendLine(ConCat_pv("0", "B"))
                    oSB.AppendLine(ConCat_pv("4", sectB))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""3"">")
                    oSB.AppendLine(ConCat_pv("0", "th"))
                    oSB.AppendLine(ConCat_pv("4", sectth))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""4"">")
                    oSB.AppendLine(ConCat_pv("0", "sh"))
                    oSB.AppendLine(ConCat_pv("4", sectsh))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("</p3>")
                Case "LREV"
                    sectH = Split(Mid(sectiondef, 5), "x")(0) / 1000
                    sectB = Split(Mid(sectiondef, 5), "x")(1) / 1000
                    sectth = Split(Mid(sectiondef, 5), "x")(2) / 1000
                    sectsh = Split(Mid(sectiondef, 5), "x")(3) / 1000
                    oSB.AppendLine(ConCat_pv("1", "EP_CssLib.EP_ProfLib_Concrete.1"))
                    oSB.AppendLine(ConCat_pv("2", "6")) '> L rev 
                    oSB.AppendLine("<p3 t="""">")
                    oSB.AppendLine("<h>")
                    oSB.AppendLine(ConCat_ht("0", "Name"))
                    oSB.AppendLine(ConCat_ht("1", "Material"))
                    oSB.AppendLine(ConCat_ht("4", "Length"))
                    oSB.AppendLine("</h>")
                    oSB.AppendLine("<row id=""0"">")
                    oSB.AppendLine(ConCat_pv("0", "Material"))
                    oSB.AppendLine(ConCat_pn("1", sectionmat))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""1"">")
                    oSB.AppendLine(ConCat_pv("0", "H"))
                    oSB.AppendLine(ConCat_pv("4", sectH))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""2"">")
                    oSB.AppendLine(ConCat_pv("0", "B"))
                    oSB.AppendLine(ConCat_pv("4", sectB))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""3"">")
                    oSB.AppendLine(ConCat_pv("0", "th"))
                    oSB.AppendLine(ConCat_pv("4", sectth))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""4"">")
                    oSB.AppendLine(ConCat_pv("0", "sh"))
                    oSB.AppendLine(ConCat_pv("4", sectsh))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("</p3>")
                Case "CIRC"
                    sectD = Mid(sectiondef, 5) / 1000
                    'get diameter
                    oSB.AppendLine(ConCat_pv("1", "EP_CssLib.EP_ProfLib_Concrete.1"))
                    oSB.AppendLine(ConCat_pv("2", "4")) '> circle
                    oSB.AppendLine("<p3 t="""">")
                    oSB.AppendLine("<h>")
                    oSB.AppendLine(ConCat_ht("0", "Name"))
                    oSB.AppendLine(ConCat_ht("1", "Material"))
                    oSB.AppendLine(ConCat_ht("4", "Length"))
                    oSB.AppendLine("</h>")
                    oSB.AppendLine("<row id=""0"">")
                    oSB.AppendLine(ConCat_pv("0", "Material"))
                    oSB.AppendLine(ConCat_pn("1", sectionmat))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""1"">")
                    oSB.AppendLine(ConCat_pv("0", "D"))
                    oSB.AppendLine(ConCat_pv("4", sectD))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("</p3>")
                Case "OVAL"
                    sectH = Split(Mid(sectiondef, 5), "x")(0) / 1000
                    sectB = Split(Mid(sectiondef, 5), "x")(1) / 1000
                    oSB.AppendLine(ConCat_pv("1", "EP_CssLib.EP_ProfLib_Concrete.1"))
                    oSB.AppendLine(ConCat_pv("2", "5")) '> oval
                    oSB.AppendLine("<p3 t="""">")
                    oSB.AppendLine("<h>")
                    oSB.AppendLine(ConCat_ht("0", "Name"))
                    oSB.AppendLine(ConCat_ht("1", "Material"))
                    oSB.AppendLine(ConCat_ht("4", "Length"))
                    oSB.AppendLine("</h>")
                    oSB.AppendLine("<row id=""0"">")
                    oSB.AppendLine(ConCat_pv("0", "Material"))
                    oSB.AppendLine(ConCat_pn("1", sectionmat))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""1"">")
                    oSB.AppendLine(ConCat_pv("0", "H"))
                    oSB.AppendLine(ConCat_pv("4", sectH))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""2"">")
                    oSB.AppendLine(ConCat_pv("0", "B"))
                    oSB.AppendLine(ConCat_pv("4", sectB))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("</p3>")
            End Select
        ElseIf formtype = "TIMB" Then
            sectiontype = Strings.UCase(Strings.Left(sectiondef, 4))
            Select Case sectiontype
                Case "RECT"
                    sectH = Split(Mid(sectiondef, 5), "x")(0) / 1000
                    sectB = Split(Mid(sectiondef, 5), "x")(1) / 1000
                    oSB.AppendLine(ConCat_pv("1", "EP_CssLib.EP_ProfLib_Timber.1"))
                    oSB.AppendLine(ConCat_pv("2", "0")) '> rectangle
                    oSB.AppendLine("<p3 t="""">")
                    oSB.AppendLine("<h>")
                    oSB.AppendLine(ConCat_ht("0", "Name"))
                    oSB.AppendLine(ConCat_ht("1", "Material"))
                    oSB.AppendLine(ConCat_ht("4", "Length"))
                    oSB.AppendLine("</h>")
                    oSB.AppendLine("<row id=""0"">")
                    oSB.AppendLine(ConCat_pv("0", "Material"))
                    oSB.AppendLine(ConCat_pn("1", sectionmat))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""1"">")
                    oSB.AppendLine(ConCat_pv("0", "H"))
                    oSB.AppendLine(ConCat_pv("4", sectH))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""2"">")
                    oSB.AppendLine(ConCat_pv("0", "B"))
                    oSB.AppendLine(ConCat_pv("4", sectB))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("</p3>")
                Case "ISEC"
                    sectBa = Split(Mid(sectiondef, 5), "x")(0) / 1000
                    secttha = Split(Mid(sectiondef, 5), "x")(1) / 1000
                    sectBb = Split(Mid(sectiondef, 5), "x")(2) / 1000
                    sectthb = Split(Mid(sectiondef, 5), "x")(3) / 1000
                    sectBc = Split(Mid(sectiondef, 5), "x")(4) / 1000
                    sectthc = Split(Mid(sectiondef, 5), "x")(5) / 1000
                    oSB.AppendLine(ConCat_pv("1", "EP_CssLib.EP_ProfLib_Timber.1"))
                    oSB.AppendLine(ConCat_pv("2", "5")) '> Tsection
                    oSB.AppendLine("<p3 t="""">")
                    oSB.AppendLine("<h>")
                    oSB.AppendLine(ConCat_ht("0", "Name"))
                    oSB.AppendLine(ConCat_ht("1", "Material"))
                    oSB.AppendLine(ConCat_ht("4", "Length"))
                    oSB.AppendLine("</h>")
                    oSB.AppendLine("<row id=""0"">")
                    oSB.AppendLine(ConCat_pv("0", "Material"))
                    oSB.AppendLine(ConCat_pn("1", sectionmat))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""1"">")
                    oSB.AppendLine(ConCat_pv("0", "Ba"))
                    oSB.AppendLine(ConCat_pv("4", sectBa))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""2"">")
                    oSB.AppendLine(ConCat_pv("0", "tha"))
                    oSB.AppendLine(ConCat_pv("4", secttha))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""3"">")
                    oSB.AppendLine(ConCat_pv("0", "Bb"))
                    oSB.AppendLine(ConCat_pv("4", sectBb))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""4"">")
                    oSB.AppendLine(ConCat_pv("0", "thb"))
                    oSB.AppendLine(ConCat_pv("4", sectthb))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""5"">")
                    oSB.AppendLine(ConCat_pv("0", "Bc"))
                    oSB.AppendLine(ConCat_pv("4", sectBc))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""6"">")
                    oSB.AppendLine(ConCat_pv("0", "thc"))
                    oSB.AppendLine(ConCat_pv("4", sectthc))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("</p3>")
                Case "TSEC"
                    sectBa = Split(Mid(sectiondef, 5), "x")(0) / 1000
                    secttha = Split(Mid(sectiondef, 5), "x")(1) / 1000
                    sectBb = Split(Mid(sectiondef, 5), "x")(2) / 1000
                    sectthb = Split(Mid(sectiondef, 5), "x")(3) / 1000
                    oSB.AppendLine(ConCat_pv("1", "EP_CssLib.EP_ProfLib_Timber.1"))
                    oSB.AppendLine(ConCat_pv("2", "4")) '> Tsection
                    oSB.AppendLine("<p3 t="""">")
                    oSB.AppendLine("<h>")
                    oSB.AppendLine(ConCat_ht("0", "Name"))
                    oSB.AppendLine(ConCat_ht("1", "Material"))
                    oSB.AppendLine(ConCat_ht("4", "Length"))
                    oSB.AppendLine("</h>")
                    oSB.AppendLine("<row id=""0"">")
                    oSB.AppendLine(ConCat_pv("0", "Material"))
                    oSB.AppendLine(ConCat_pn("1", sectionmat))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""1"">")
                    oSB.AppendLine(ConCat_pv("0", "Ba"))
                    oSB.AppendLine(ConCat_pv("4", sectBa))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""2"">")
                    oSB.AppendLine(ConCat_pv("0", "tha"))
                    oSB.AppendLine(ConCat_pv("4", secttha))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""3"">")
                    oSB.AppendLine(ConCat_pv("0", "Bb"))
                    oSB.AppendLine(ConCat_pv("4", sectBb))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""4"">")
                    oSB.AppendLine(ConCat_pv("0", "thb"))
                    oSB.AppendLine(ConCat_pv("4", sectthb))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("</p3>")
                Case "CIRC"
                    sectD = Mid(sectiondef, 5) / 1000
                    'get diameter
                    oSB.AppendLine(ConCat_pv("1", "EP_CssLib.EP_ProfLib_Timber.1"))
                    oSB.AppendLine(ConCat_pv("2", "1")) '> circle
                    oSB.AppendLine("<p3 t="""">")
                    oSB.AppendLine("<h>")
                    oSB.AppendLine(ConCat_ht("0", "Name"))
                    oSB.AppendLine(ConCat_ht("1", "Material"))
                    oSB.AppendLine(ConCat_ht("4", "Length"))
                    oSB.AppendLine("</h>")
                    oSB.AppendLine("<row id=""0"">")
                    oSB.AppendLine(ConCat_pv("0", "Material"))
                    oSB.AppendLine(ConCat_pn("1", sectionmat))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("<row id=""1"">")
                    oSB.AppendLine(ConCat_pv("0", "D"))
                    oSB.AppendLine(ConCat_pv("4", sectD))
                    oSB.AppendLine("</row>")
                    oSB.AppendLine("</p3>")
            End Select

        End If


        oSB.AppendLine("</obj>")

    End Sub

    Private Sub WriteNonlinearFunction(ByRef oSB, i, SE_NonlinearFunctions(,)) 'write 1 nodal support to the XML stream


        oSB.AppendLine("<obj nm=""" & SE_NonlinearFunctions(i, 0) & """>")
        oSB.AppendLine(ConCat_pv("0", SE_NonlinearFunctions(i, 0)))
        Select Case (SE_NonlinearFunctions(i, 1))
            Case "Translation"
                oSB.AppendLine(ConCat_pvt("1", "0", "Translation"))
            Case "Rotation"
                oSB.AppendLine(ConCat_pvt("1", "1", "Rotation"))
            Case "Nonlinear subsoil"
                oSB.AppendLine(ConCat_pvt("1", "2", "Nonlinear subsoil"))
            Case Else
                oSB.AppendLine(ConCat_pvt("1", "0", "Translation"))
        End Select

        Select Case (SE_NonlinearFunctions(i, 3))
            Case "Rigid"
                oSB.AppendLine(ConCat_pvt("2", "0", "Rigid"))
            Case "Free"
                oSB.AppendLine(ConCat_pvt("2", "1", "Free"))
            Case "Flexible"
                oSB.AppendLine(ConCat_pvt("2", "2", "Flexible"))
            Case Else
                oSB.AppendLine(ConCat_pvt("2", "0", "Rigid"))
        End Select

        Select Case (SE_NonlinearFunctions(i, 3))
            Case "Rigid"
                oSB.AppendLine(ConCat_pvt("3", "0", "Rigid"))
            Case "Free"
                oSB.AppendLine(ConCat_pvt("4", "1", "Free"))
            Case "Flexible"
                oSB.AppendLine(ConCat_pvt("4", "2", "Flexible"))
            Case Else
                oSB.AppendLine(ConCat_pvt("4", "0", "Rigid"))
        End Select

        Dim parts As String() = SE_NonlinearFunctions(i, 4).Split(New Char() {"|"c})

        Dim x As String
        Dim y As String
        Dim j As Long = 0
        Select Case (SE_NonlinearFunctions(i, 1))
            Case "Translation"
                For Each item In parts
                    x = item.Split(";")(0)
                    y = item.Split(";")(1)
                    oSB.AppendLine(ConCat_pv1v2x("4", x, y, j))
                    j += 1
                Next item
            Case "Rotation"
                For Each item In parts
                    x = item.Split(";")(0)
                    y = item.Split(";")(1)
                    oSB.AppendLine(ConCat_pv1v2x("5", x, y, j))
                    j += 1
                Next item
            Case "Nonlinear subsoil"
                For Each item In parts
                    x = item.Split(";")(0)
                    y = item.Split(";")(1)
                    oSB.AppendLine(ConCat_pv1v2x("6", x, y, j))
                    j += 1
                Next item

        End Select

        oSB.AppendLine("</obj>")

    End Sub

    Private Sub WriteNodeSupport(ByRef oSB, isupport, supports(,)) 'write 1 nodal support to the XML stream
        Dim tt As String

        oSB.AppendLine("<obj nm=""Sn" & isupport & """>")
        oSB.AppendLine(ConCat_pv("0", "Sn" & isupport)) 'Support name
        'write beam name as reference table
        oSB.AppendLine("<p1 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h2 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")
        oSB.AppendLine(ConCat_pv("0", "{39A7F468-A0D4-4DFF-8E5C-5843E1807D13}"))
        oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_StructNode.1"))
        oSB.AppendLine(ConCat_pv("2", DupNodeDict(supports(isupport, 0))))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p1>")
        'End Of reference table
        'oSB.AppendLine(ConCat_pn("1", supports(isupport, 0))) 'Node name
        tt = GetStringForDOF(supports(isupport, 1))
        oSB.AppendLine(ConCat_pvt("2", supports(isupport, 1), tt))
        tt = GetStringForDOF(supports(isupport, 2))
        oSB.AppendLine(ConCat_pvt("3", supports(isupport, 2), tt))
        tt = GetStringForDOF(supports(isupport, 3))
        oSB.AppendLine(ConCat_pvt("4", supports(isupport, 3), tt))
        tt = GetStringForDOF(supports(isupport, 4))
        oSB.AppendLine(ConCat_pvt("5", supports(isupport, 4), tt))
        tt = GetStringForDOF(supports(isupport, 5))
        oSB.AppendLine(ConCat_pvt("6", supports(isupport, 5), tt))
        tt = GetStringForDOF(supports(isupport, 6))
        oSB.AppendLine(ConCat_pvt("7", supports(isupport, 6), tt))
        oSB.AppendLine(ConCat_pv("8", supports(isupport, 7)))
        oSB.AppendLine(ConCat_pv("9", supports(isupport, 8)))
        oSB.AppendLine(ConCat_pv("10", supports(isupport, 9)))
        oSB.AppendLine(ConCat_pv("11", supports(isupport, 10)))
        oSB.AppendLine(ConCat_pv("12", supports(isupport, 11)))
        oSB.AppendLine(ConCat_pv("13", supports(isupport, 12)))
        oSB.AppendLine(ConCat_pv("14", supports(isupport, 13)))
        '15-20 NL functions
        oSB.AppendLine(ConCat_pin("15", "1", supports(isupport, 14)))
        oSB.AppendLine(ConCat_pin("16", "1", supports(isupport, 15)))
        oSB.AppendLine(ConCat_pin("17", "1", supports(isupport, 16)))
        oSB.AppendLine(ConCat_pin("18", "1", supports(isupport, 17)))
        oSB.AppendLine(ConCat_pin("19", "1", supports(isupport, 18)))
        oSB.AppendLine(ConCat_pin("20", "1", supports(isupport, 19)))
        oSB.AppendLine("</obj>")

    End Sub

    Private Sub WriteEdgeSupport(ByRef oSB, isupport, supports(,)) 'write 1 edge support to the XML stream
        Dim tt As String

        oSB.AppendLine("<obj nm=""Sle" & isupport & """>")
        oSB.AppendLine(ConCat_pv("0", "Sle" & isupport)) 'Support name

        'write surface name as reference table
        oSB.AppendLine("<p1 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h3 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")

        'different reference depending whether it's towards a surface or an opening
        Select Case supports(isupport, 1)
            Case "SURFACE"
                oSB.AppendLine(ConCat_pv("0", "{8708ED31-8E66-11D4-AD94-F6F5DE2BE344}"))
                oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Plane.1"))
            Case "OPENING"
                oSB.AppendLine(ConCat_pv("0", "{EBA9B148-F564-4DB1-9E2D-F1937FFA4523}"))
                oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_OpenSlab.1"))
            Case Else
                oSB.AppendLine(ConCat_pv("0", "{8708ED31-8E66-11D4-AD94-F6F5DE2BE344}"))
                oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Plane.1"))
        End Select

        oSB.AppendLine(ConCat_pv("2", supports(isupport, 0)))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p1>")
        'end of reference table

        oSB.AppendLine(ConCat_pvt("2", CStr(CLng(supports(isupport, 2)) - 1), supports(isupport, 2))) 'Edge number minus 1 is the index

        tt = GetStringForDOF(supports(isupport, 3))
        oSB.AppendLine(ConCat_pvt("3", supports(isupport, 3), tt))
        tt = GetStringForDOF(supports(isupport, 4))
        oSB.AppendLine(ConCat_pvt("4", supports(isupport, 4), tt))
        tt = GetStringForDOF(supports(isupport, 5))
        oSB.AppendLine(ConCat_pvt("5", supports(isupport, 5), tt))
        tt = GetStringForDOF(supports(isupport, 6))
        oSB.AppendLine(ConCat_pvt("6", supports(isupport, 6), tt))
        tt = GetStringForDOF(supports(isupport, 7))
        oSB.AppendLine(ConCat_pvt("7", supports(isupport, 7), tt))
        tt = GetStringForDOF(supports(isupport, 8))
        oSB.AppendLine(ConCat_pvt("8", supports(isupport, 8), tt))

        oSB.AppendLine(ConCat_pvt("9", "0", "GCS")) 'Coordinate system
        oSB.AppendLine(ConCat_pv("10", supports(isupport, 9)))
        oSB.AppendLine(ConCat_pv("11", supports(isupport, 10)))
        oSB.AppendLine(ConCat_pv("12", supports(isupport, 11)))
        oSB.AppendLine(ConCat_pv("13", supports(isupport, 12)))
        oSB.AppendLine(ConCat_pv("14", supports(isupport, 13)))
        oSB.AppendLine(ConCat_pv("15", supports(isupport, 14)))

        'p11 would be the definition of relative or absolute coordinates
        Select Case supports(isupport, 15)
            Case "Rela"
                oSB.AppendLine(ConCat_pvt("16", "1", "Rela"))
            Case "Abso"
                oSB.AppendLine(ConCat_pvt("16", "0", "Abso"))
        End Select
        oSB.AppendLine(ConCat_pv("17", supports(isupport, 16)))
        oSB.AppendLine(ConCat_pv("18", supports(isupport, 17)))

        'p12 would be the indication of where the coordinates start: From start or From end
        Select Case supports(isupport, 18)
            Case "From start"
                oSB.AppendLine(ConCat_pvt("19", "0", "From start"))
            Case "From end"
                oSB.AppendLine(ConCat_pvt("19", "1", "From end"))
        End Select
        oSB.AppendLine(ConCat_pin("20", "1", supports(isupport, 18)))
        oSB.AppendLine(ConCat_pin("21", "1", supports(isupport, 19)))
        oSB.AppendLine(ConCat_pin("22", "1", supports(isupport, 20)))
        oSB.AppendLine(ConCat_pin("23", "1", supports(isupport, 21)))
        oSB.AppendLine(ConCat_pin("24", "1", supports(isupport, 22)))
        oSB.AppendLine(ConCat_pin("25", "1", supports(isupport, 23)))
        oSB.AppendLine("</obj>")

    End Sub

    Private Sub WriteBeamLineSupport(ByRef oSB, isupport, supports(,)) 'write 1 edge support to the XML stream
        Dim tt As String

        oSB.AppendLine("<obj nm=""BLS" & isupport & """>")
        oSB.AppendLine(ConCat_pv("0", "BLS" & isupport)) 'Support name

        'write beam name as reference table
        oSB.AppendLine("<p1 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h2 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")
        oSB.AppendLine(ConCat_pv("0", "{ECB5D684-7357-11D4-9F6C-00104BC3B443}"))
        oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Beam.1"))
        oSB.AppendLine(ConCat_pv("2", supports(isupport, 0)))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p1>")
        'end of reference table

        'support type
        oSB.AppendLine(ConCat_pvt("2", 0, "Line"))




        tt = GetStringForDOF(supports(isupport, 1))
        oSB.AppendLine(ConCat_pvt("3", supports(isupport, 1), tt))
        tt = GetStringForDOF(supports(isupport, 2))
        oSB.AppendLine(ConCat_pvt("4", supports(isupport, 2), tt))
        tt = GetStringForDOF(supports(isupport, 3))
        oSB.AppendLine(ConCat_pvt("5", supports(isupport, 3), tt))
        tt = GetStringForDOF(supports(isupport, 4))
        oSB.AppendLine(ConCat_pvt("6", supports(isupport, 4), tt))
        tt = GetStringForDOF(supports(isupport, 5))
        oSB.AppendLine(ConCat_pvt("7", supports(isupport, 5), tt))
        tt = GetStringForDOF(supports(isupport, 6))
        oSB.AppendLine(ConCat_pvt("8", supports(isupport, 6), tt))


        oSB.AppendLine(ConCat_pv("9", supports(isupport, 7)))
        oSB.AppendLine(ConCat_pv("10", supports(isupport, 8)))
        oSB.AppendLine(ConCat_pv("11", supports(isupport, 9)))
        oSB.AppendLine(ConCat_pv("12", supports(isupport, 10)))
        oSB.AppendLine(ConCat_pv("13", supports(isupport, 11)))
        oSB.AppendLine(ConCat_pv("14", supports(isupport, 12)))

        oSB.AppendLine(ConCat_pvt("15", "0", "GCS")) 'Coordinate system

        Select Case supports(isupport, 13)
            Case "Rela"
                oSB.AppendLine(ConCat_pvt("16", "1", "Rela"))
            Case "Abso"
                oSB.AppendLine(ConCat_pvt("16", "0", "Abso"))
        End Select
        oSB.AppendLine(ConCat_pv("17", supports(isupport, 14)))
        oSB.AppendLine(ConCat_pv("18", supports(isupport, 15)))

        'p12 would be the indication of where the coordinates start: From start or From end
        Select Case supports(isupport, 16)
            Case "From start"
                oSB.AppendLine(ConCat_pvt("19", "0", "From start"))
            Case "From end"
                oSB.AppendLine(ConCat_pvt("19", "1", "From end"))
        End Select
        oSB.AppendLine(ConCat_pin("20", "1", supports(isupport, 18)))
        oSB.AppendLine(ConCat_pin("21", "1", supports(isupport, 19)))
        oSB.AppendLine(ConCat_pin("22", "1", supports(isupport, 20)))
        oSB.AppendLine(ConCat_pin("23", "1", supports(isupport, 21)))
        oSB.AppendLine(ConCat_pin("24", "1", supports(isupport, 22)))
        oSB.AppendLine(ConCat_pin("25", "1", supports(isupport, 23)))
        oSB.AppendLine("</obj>")

    End Sub

    Private Sub WritePointSupportOnBeam(ByRef oSB, isupport, supports(,)) 'write 1 edge support to the XML stream
        Dim tt As String

        oSB.AppendLine("<obj nm=""PSOB" & isupport & """>")
        oSB.AppendLine(ConCat_pv("0", "PSOB" & isupport)) 'Support name

        'write beam name as reference table
        oSB.AppendLine("<p1 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h2 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")
        oSB.AppendLine(ConCat_pv("0", "{ECB5D684-7357-11D4-9F6C-00104BC3B443}"))
        oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Beam.1"))
        oSB.AppendLine(ConCat_pv("2", supports(isupport, 0)))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p1>")
        'end of reference table

        'support type
        oSB.AppendLine(ConCat_pvt("2", 0, "Standard"))



        tt = GetStringForDOF(supports(isupport, 1))
        oSB.AppendLine(ConCat_pvt("3", supports(isupport, 1), tt))
        tt = GetStringForDOF(supports(isupport, 2))
        oSB.AppendLine(ConCat_pvt("4", supports(isupport, 2), tt))
        tt = GetStringForDOF(supports(isupport, 3))
        oSB.AppendLine(ConCat_pvt("5", supports(isupport, 3), tt))
        tt = GetStringForDOF(supports(isupport, 4))
        oSB.AppendLine(ConCat_pvt("6", supports(isupport, 4), tt))
        tt = GetStringForDOF(supports(isupport, 5))
        oSB.AppendLine(ConCat_pvt("7", supports(isupport, 5), tt))
        tt = GetStringForDOF(supports(isupport, 6))
        oSB.AppendLine(ConCat_pvt("8", supports(isupport, 6), tt))


        oSB.AppendLine(ConCat_pv("9", supports(isupport, 7)))
        oSB.AppendLine(ConCat_pv("10", supports(isupport, 8)))
        oSB.AppendLine(ConCat_pv("11", supports(isupport, 9)))
        oSB.AppendLine(ConCat_pv("12", supports(isupport, 10)))
        oSB.AppendLine(ConCat_pv("13", supports(isupport, 11)))
        oSB.AppendLine(ConCat_pv("14", supports(isupport, 12)))

        oSB.AppendLine(ConCat_pvt("15", "0", "GCS")) 'Coordinate system

        Select Case supports(isupport, 13)
            Case "Rela"
                oSB.AppendLine(ConCat_pvt("16", "1", "Rela"))
            Case "Abso"
                oSB.AppendLine(ConCat_pvt("16", "0", "Abso"))
        End Select
        oSB.AppendLine(ConCat_pv("17", supports(isupport, 14)))

        'p12 would be the indication of where the coordinates start: From start or From end
        Select Case supports(isupport, 15)
            Case "From start"
                oSB.AppendLine(ConCat_pvt("18", "0", "From start"))
            Case "From end"
                oSB.AppendLine(ConCat_pvt("18", "1", "From end"))
        End Select
        oSB.AppendLine(ConCat_pv("19", supports(isupport, 16)))

        oSB.AppendLine(ConCat_pv("20", supports(isupport, 17)))
        oSB.AppendLine(ConCat_pin("21", "1", supports(isupport, 18)))
        oSB.AppendLine(ConCat_pin("22", "1", supports(isupport, 19)))
        oSB.AppendLine(ConCat_pin("23", "1", supports(isupport, 20)))
        oSB.AppendLine(ConCat_pin("24", "1", supports(isupport, 21)))
        oSB.AppendLine(ConCat_pin("25", "1", supports(isupport, 22)))
        oSB.AppendLine(ConCat_pin("26", "1", supports(isupport, 23)))

        oSB.AppendLine("</obj>")

    End Sub

    Private Sub WriteSubsoil(ByRef oSB, i, subsoil(,)) 'write 1 edge support to the XML stream

        oSB.AppendLine("<obj nm=""Subsoil" & i & """>")
        oSB.AppendLine(ConCat_pv("0", subsoil(i, 0)))
        oSB.AppendLine(ConCat_pv("1", subsoil(i, 1)))
        oSB.AppendLine(ConCat_pv("2", subsoil(i, 2)))
        oSB.AppendLine(ConCat_pv("3", subsoil(i, 3)))

        Select Case subsoil(i, 7)
            Case "Flexible"
                oSB.AppendLine(ConCat_pvt("4", "0", "Flexible"))
            Case "Nonlinear function"
                oSB.AppendLine(ConCat_pvt("4", "1", "Nonlinear Function"))
            Case Else
                oSB.AppendLine(ConCat_pvt("4", "0", "Flexible"))
        End Select


        oSB.AppendLine(ConCat_pv("5", subsoil(i, 4)))
        oSB.AppendLine(ConCat_pv("6", subsoil(i, 5)))
        oSB.AppendLine(ConCat_pv("7", subsoil(i, 6)))
        oSB.AppendLine(ConCat_pv("8", subsoil(i, 8)))
        oSB.AppendLine("</obj>")

    End Sub

    Private Sub WriteSurfaceSupport(ByRef oSB, i, surfacesupport(,))

        oSB.AppendLine("<obj nm=""SurfaceSupport" & i & """>")
        oSB.AppendLine(ConCat_pv("0", "SurfaceSupport" & i))

        'write beam name as reference table
        oSB.AppendLine("<p1 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h2 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")
        oSB.AppendLine(ConCat_pv("0", "{8708ED31-8E66-11D4-AD94-F6F5DE2BE344}"))
        oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Plane.1"))
        oSB.AppendLine(ConCat_pv("2", surfacesupport(i, 0)))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p1>")
        'end of reference table
        oSB.AppendLine(ConCat_pvt("2", "0", "Individual"))
        oSB.AppendLine(ConCat_pv("3", surfacesupport(i, 1)))
        oSB.AppendLine("</obj>")

    End Sub

    Private Sub WriteLGroup(ByRef oSB, igroup, groups(,)) 'write 1 load group to the XML stream

        oSB.AppendLine("<obj id=""" & Trim(Str(igroup)) & """ nm=""" & groups(igroup, 0) & """>")
        oSB.AppendLine(ConCat_pv("0", groups(igroup, 0)))
        Select Case Strings.UCase(groups(igroup, 1))
            Case "PERMANENT"
                oSB.AppendLine(ConCat_pvt("1", "0", "Permanent"))
            Case "VARIABLE"
                oSB.AppendLine(ConCat_pvt("1", "1", "Variable"))
                If Strings.UCase(groups(igroup, 2)) = "STANDARD" Then
                    oSB.AppendLine(ConCat_pvt("2", "0", "Standard"))
                ElseIf Strings.UCase(groups(igroup, 2)) = "EXCLUSIVE" Then
                    oSB.AppendLine(ConCat_pvt("2", "1", "Exclusive"))
                ElseIf Strings.UCase(groups(igroup, 2)) = "TOGETHER" Then
                    oSB.AppendLine(ConCat_pvt("2", "2", "Together"))
                End If
        End Select
        oSB.AppendLine("</obj>")

    End Sub
    Private Sub WriteLinCombination(ByRef oSB, icombi, combinations(,)) 'write 1 combination to the XML stream

        oSB.AppendLine("<obj id=""" & Trim(Str(icombi)) & """ nm=""" & combinations(icombi, 0) & """>")
        oSB.AppendLine(ConCat_pv("0", combinations(icombi, 0)))
        Select Case combinations(icombi, 1)
            Case "Envelope - ultimate"
                oSB.AppendLine(ConCat_pvt("1", "0", "Envelope - ultimate"))
            Case "Envelope - serviceability"
                oSB.AppendLine(ConCat_pvt("1", "1", "Envelope - serviceability"))
            Case "Linear - ultimate"
                oSB.AppendLine(ConCat_pvt("1", "2", "Linear - ultimate"))
            Case "Linear - serviceability"
                oSB.AppendLine(ConCat_pvt("1", "3", "Linear - serviceability"))
            Case "EN-ULS (STR/GEO) Set B"
                oSB.AppendLine(ConCat_pvt("1", "4", "EN-ULS (STR/GEO) Set B"))
            Case "EN-Accidental 1"
                oSB.AppendLine(ConCat_pvt("1", "5", "EN-Accidental 1"))
            Case "EN-Accidental 2"
                oSB.AppendLine(ConCat_pvt("1", "6", "EN-Accidental 2"))
            Case "EN-Seismic"
                oSB.AppendLine(ConCat_pvt("1", "7", "EN-Seismic"))
            Case "EN-SLS Characteristic"
                oSB.AppendLine(ConCat_pvt("1", "8", "EN-SLS Characteristic"))
            Case "EN-SLS Frequent"
                oSB.AppendLine(ConCat_pvt("1", "9", "EN-SLS Frequent"))
            Case "EN-SLS Quasi-permanent"
                oSB.AppendLine(ConCat_pvt("1", "10", "EN-SLS Quasi-permanent"))
            Case "EN-ULS (STR/GEO) Set C"
                oSB.AppendLine(ConCat_pvt("1", "11", "EN-ULS (STR/GEO) Set C"))
        End Select
        Dim parts As String() = combinations(icombi, 2).Split(New Char() {";"c})
        Dim Name As String
        Dim Coeff As String
        Dim i As Long = 0
        oSB.AppendLine(ConCat_opentable("2", ""))
        oSB.AppendLine("<h>")
        oSB.AppendLine(ConCat_ht("0", "Name"))
        oSB.AppendLine(ConCat_ht("1", "Coeff."))
        oSB.AppendLine(ConCat_ht("2", "Load case ID"))
        oSB.AppendLine("</h>")
        For Each item In parts
            Coeff = item.Split("*")(0)
            Name = item.Split("*")(1)
            oSB.AppendLine(ConCat_row(i))
            oSB.AppendLine(ConCat_pv("0", Name))
            oSB.appendline(ConCat_pv("1", Coeff))
            oSB.appendline(ConCat_pin("2", i + 1, Name))
            oSB.AppendLine("</row>")
            i += 1
        Next item
        oSB.AppendLine(ConCat_closetable("2"))
        oSB.AppendLine("</obj>")
    End Sub
    Private Sub WriteNonLinCombination(ByRef oSB, icombi, combinations(,)) 'write 1 nonlinear combination to the XML stream

        oSB.AppendLine("<obj id=""" & Trim(Str(icombi)) & """ nm=""" & combinations(icombi, 0) & """>")
        oSB.AppendLine(ConCat_pv("0", combinations(icombi, 0)))
        Select Case combinations(icombi, 1)
            Case "Ultimate"
                oSB.AppendLine(ConCat_pvt("1", "0", "Ultimate"))
            Case "Serviceability"
                oSB.AppendLine(ConCat_pvt("1", "1", "Serviceability"))
        End Select
        Dim parts As String() = combinations(icombi, 2).Split(New Char() {";"c})
        Dim Name As String
        Dim Coeff As String
        Dim i As Long = 0
        oSB.AppendLine(ConCat_opentable("2", ""))
        oSB.AppendLine("<h>")
        oSB.AppendLine(ConCat_ht("0", "Name"))
        oSB.AppendLine(ConCat_ht("1", "Coeff."))
        oSB.AppendLine(ConCat_ht("2", "Load case ID"))
        'description
        oSB.AppendLine("</h>")
        For Each item In parts
            Coeff = item.Split("*")(0)
            Name = item.Split("*")(1)
            oSB.AppendLine(ConCat_row(i))
            oSB.AppendLine(ConCat_pv("0", Name))
            oSB.appendline(ConCat_pv("1", Coeff))
            oSB.appendline(ConCat_pin("2", i + 1, Name))
            oSB.AppendLine("</row>")
            i += 1
        Next item
        oSB.AppendLine(ConCat_closetable("2"))
        oSB.AppendLine(ConCat_pv("3", combinations(icombi, 3)))
        oSB.AppendLine("</obj>")
    End Sub
    Private Sub WriteStabilityCombination(ByRef oSB, icombi, combinations(,)) 'write 1 nonlinear combination to the XML stream

        oSB.AppendLine("<obj id=""" & Trim(Str(icombi)) & """ nm=""" & combinations(icombi, 0) & """>")
        oSB.AppendLine(ConCat_pv("0", combinations(icombi, 0)))
        Dim parts As String() = combinations(icombi, 1).Split(New Char() {";"c})
        Dim Name As String
        Dim Coeff As String
        Dim i As Long = 0
        oSB.AppendLine(ConCat_opentable("1", ""))
        oSB.AppendLine("<h>")
        oSB.AppendLine(ConCat_ht("0", "Name"))
        oSB.AppendLine(ConCat_ht("1", "Coeff."))
        oSB.AppendLine(ConCat_ht("2", "Load case ID"))
        oSB.AppendLine("</h>")
        For Each item In parts
            Coeff = item.Split("*")(0)
            Name = item.Split("*")(1)
            oSB.AppendLine(ConCat_row(i))
            oSB.AppendLine(ConCat_pv("0", Name))
            oSB.appendline(ConCat_pv("1", Coeff))
            oSB.appendline(ConCat_pin("2", i + 1, Name))
            oSB.AppendLine("</row>")
            i += 1
        Next item
        oSB.AppendLine(ConCat_closetable("1"))
        oSB.AppendLine("</obj>")
    End Sub
    Private Sub WriteLCase(ByRef oSB, icase, cases(,)) 'write 1 load case to the XML stream

        oSB.AppendLine("<obj id=""" & Trim(Str(icase)) & """ nm=""" & cases(icase, 0) & """>")
        oSB.AppendLine(ConCat_pv("0", cases(icase, 0)))

        Select Case Strings.UCase(cases(icase, 1))
            Case "SW"
                oSB.AppendLine(ConCat_pvt("1", "0", "Permanent"))
                oSB.AppendLine(ConCat_pvt("2", "0", "Self weight"))
                oSB.AppendLine(ConCat_pvt("3", "0", "-Z"))
            Case "PERMANENT"
                oSB.AppendLine(ConCat_pvt("1", "0", "Permanent"))
                oSB.AppendLine(ConCat_pvt("2", "1", "Standard"))
            Case "VARIABLE"
                oSB.AppendLine(ConCat_pvt("1", "1", "Variable"))
                oSB.AppendLine(ConCat_pvt("2", "0", "Static"))

        End Select
        oSB.AppendLine(ConCat_pn("4", cases(icase, 2)))
        oSB.AppendLine("</obj>")

    End Sub

    Private Sub WriteLLoad(ByRef oSB, iload, loads(,)) 'write 1 line load to the XML stream

        oSB.AppendLine("<obj id=""" & Trim(Str(iload)) & """ nm=""" & "LL" & Trim(Str(iload)) & """>")
        oSB.AppendLine(ConCat_pv("0", "LL" & Trim(Str(iload))))
        oSB.AppendLine(ConCat_pn("1", loads(iload, 0)))
        'write beam name as reference table
        oSB.AppendLine("<p2 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h2 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")
        oSB.AppendLine(ConCat_pv("0", "{ECB5D684-7357-11D4-9F6C-00104BC3B443}"))
        oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Beam.1"))
        oSB.AppendLine(ConCat_pv("2", loads(iload, 1)))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p2>")
        'end of reference table

        'direction

        Select Case loads(iload, 3)
            Case "X"
                oSB.AppendLine(ConCat_pvt("3", "0", "X"))
            Case "Y"
                oSB.AppendLine(ConCat_pvt("3", "1", "Y"))
            Case "Z"
                oSB.AppendLine(ConCat_pvt("3", "2", "Z"))
        End Select
        'distribution & values
        Select Case loads(iload, 4)
            Case "Uniform"
                oSB.AppendLine(ConCat_pvt("4", "0", loads(iload, 4)))
            Case "Trapez"
                oSB.AppendLine(ConCat_pvt("4", "1", loads(iload, 4)))
            Case Else
                oSB.AppendLine(ConCat_pvt("4", "0", loads(iload, 4)))
        End Select

        'load value
        oSB.AppendLine(ConCat_pv("5", loads(iload, 5) * 1000))
        oSB.AppendLine(ConCat_pv("6", loads(iload, 6) * 1000))
        'axis definition

        Select Case loads(iload, 2)
            Case "GCS"
                oSB.AppendLine(ConCat_pvt("7", "0", "GCS"))
            Case "LCS"
                oSB.AppendLine(ConCat_pvt("7", "1", "LCS"))
        End Select
        'p8 would be the "location": length or projection (only for GCS)

        'p9 would be the starting position for the load > default = 0.0
        'p10 would be the end position for the load > default = 1.0
        oSB.AppendLine(ConCat_pv("9", loads(iload, 8)))
        oSB.AppendLine(ConCat_pv("10", loads(iload, 9)))
        'p11 would be the definition of relative or absolute coordinates
        Select Case loads(iload, 7)
            Case "Rela"
                oSB.AppendLine(ConCat_pvt("11", "1", "Rela"))
            Case "Abso"
                oSB.AppendLine(ConCat_pvt("11", "0", "Abso"))
        End Select
        'p12 would be the indication of where the coordinates start: From start or From end
        Select Case loads(iload, 10)
            Case "From start"
                oSB.AppendLine(ConCat_pvt("12", "0", "From start"))
            Case "From end"
                oSB.AppendLine(ConCat_pvt("12", "1", "From end"))
        End Select
        'p13 & p14 would be the ey and ez eccentricities for the line load
        oSB.AppendLine(ConCat_pv("13", loads(iload, 11)))
        oSB.AppendLine(ConCat_pv("14", loads(iload, 12)))
        oSB.AppendLine("</obj>")

    End Sub



    Private Sub WriteLineMomentLoadBeam(ByRef oSB, iload, loads(,)) 'write 1 line load to the XML stream

        oSB.AppendLine("<obj id=""" & Trim(Str(iload)) & """ nm=""" & "LMLB" & Trim(Str(iload)) & """>")
        oSB.AppendLine(ConCat_pv("0", "LMLB" & Trim(Str(iload))))
        oSB.AppendLine(ConCat_pn("1", loads(iload, 0)))
        'write beam name as reference table
        oSB.AppendLine("<p2 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h2 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")
        oSB.AppendLine(ConCat_pv("0", "{ECB5D684-7357-11D4-9F6C-00104BC3B443}"))
        oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Beam.1"))
        oSB.AppendLine(ConCat_pv("2", loads(iload, 1)))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p2>")
        'end of reference table

        'direction

        Select Case loads(iload, 3)
            Case "Mx"
                oSB.AppendLine(ConCat_pvt("3", "0", "Mx"))
            Case "My"
                oSB.AppendLine(ConCat_pvt("3", "1", "My"))
            Case "Mz"
                oSB.AppendLine(ConCat_pvt("3", "2", "Mz"))
        End Select
        'distribution & values
        Select Case loads(iload, 4)
            Case "Uniform"
                oSB.AppendLine(ConCat_pvt("4", "0", loads(iload, 4)))
            Case "Trapez"
                oSB.AppendLine(ConCat_pvt("4", "1", loads(iload, 4)))
            Case Else
                oSB.AppendLine(ConCat_pvt("4", "0", loads(iload, 4)))
        End Select

        'load value
        oSB.AppendLine(ConCat_pv("5", loads(iload, 5) * 1000))
        oSB.AppendLine(ConCat_pv("6", loads(iload, 6) * 1000))
        'axis definition

        Select Case loads(iload, 2)
            Case "GCS"
                oSB.AppendLine(ConCat_pvt("7", "0", "GCS"))
            Case "LCS"
                oSB.AppendLine(ConCat_pvt("7", "1", "LCS"))
        End Select
        'p8 would be the "location": length or projection (only for GCS)

        'p9 would be the starting position for the load > default = 0.0
        'p10 would be the end position for the load > default = 1.0
        oSB.AppendLine(ConCat_pv("9", loads(iload, 8)))
        oSB.AppendLine(ConCat_pv("10", loads(iload, 9)))
        'p11 would be the definition of relative or absolute coordinates
        Select Case loads(iload, 7)
            Case "Rela"
                oSB.AppendLine(ConCat_pvt("11", "1", "Rela"))
            Case "Abso"
                oSB.AppendLine(ConCat_pvt("11", "0", "Abso"))
        End Select
        'p12 would be the indication of where the coordinates start: From start or From end
        Select Case loads(iload, 10)
            Case "From start"
                oSB.AppendLine(ConCat_pvt("12", "0", "From start"))
            Case "From end"
                oSB.AppendLine(ConCat_pvt("12", "1", "From end"))
        End Select

        oSB.AppendLine("</obj>")

    End Sub

    Private Sub WriteELoad(ByRef oSB, iload, loads(,)) 'write 1 line load on surface ede  to the XML stream




        oSB.AppendLine("<obj id=""" & Trim(Str(iload)) & """ nm=""" & "ESL" & Trim(Str(iload)) & """>")
        oSB.AppendLine(ConCat_pv("0", "ESL" & Trim(Str(iload))))
        oSB.AppendLine(ConCat_pn("1", loads(iload, 0)))
        'write surafec name as reference table
        oSB.AppendLine("<p2 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h2 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")
        Select Case (loads(iload, 14))
            Case "edge"
                oSB.AppendLine(ConCat_pv("0", "{8708ED31-8E66-11D4-AD94-F6F5DE2BE344}"))
                oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Plane.1"))
            Case "internal"
                oSB.AppendLine(ConCat_pv("0", "{4FCA60AD-9308-468B-BD02-3D4E17830029}"))
                oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_SlabInternalEdge.1"))
            Case Else
                oSB.AppendLine(ConCat_pv("0", "{8708ED31-8E66-11D4-AD94-F6F5DE2BE344}"))
                oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Plane.1"))
        End Select




        oSB.AppendLine(ConCat_pv("2", loads(iload, 1)))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p2>")
        'end of reference table

        'direction

        Select Case loads(iload, 4)
            Case "X"
                oSB.AppendLine(ConCat_pvt("3", "0", "X"))
            Case "Y"
                oSB.AppendLine(ConCat_pvt("3", "1", "Y"))
            Case "Z"
                oSB.AppendLine(ConCat_pvt("3", "2", "Z"))
        End Select
        'distribution & values
        Select Case loads(iload, 5)
            Case "Uniform"
                oSB.AppendLine(ConCat_pvt("4", "0", loads(iload, 5)))
            Case "Trapez"
                oSB.AppendLine(ConCat_pvt("4", "1", loads(iload, 5)))
            Case Else
                oSB.AppendLine(ConCat_pvt("4", "0", loads(iload, 5)))
        End Select

        'load value
        oSB.AppendLine(ConCat_pv("5", loads(iload, 6) * 1000))
        oSB.AppendLine(ConCat_pv("6", loads(iload, 7) * 1000))
        'axis definition

        Select Case loads(iload, 3)
            Case "GCS - Length"
                oSB.AppendLine(ConCat_pvt("7", "0", "GCS"))
                oSB.AppendLine(ConCat_pvt("8", "0", "Length"))
            Case "GCS - Projection"
                oSB.AppendLine(ConCat_pvt("7", "0", "GCS"))
                oSB.AppendLine(ConCat_pvt("8", "1", "Projection"))
            Case "LCS"
                oSB.AppendLine(ConCat_pvt("7", "1", "LCS"))
            Case Else
                oSB.AppendLine(ConCat_pvt("7", "1", "LCS"))
        End Select

        oSB.AppendLine(ConCat_pv("9", loads(iload, 9)))
        oSB.AppendLine(ConCat_pv("10", loads(iload, 10)))
        'p11 would be the definition of relative or absolute coordinates
        Select Case loads(iload, 8)
            Case "Rela"
                oSB.AppendLine(ConCat_pvt("11", "1", "Rela"))
            Case "Abso"
                oSB.AppendLine(ConCat_pvt("11", "0", "Abso"))
        End Select
        'p12 would be the indication of where the coordinates start: From start or From end
        Select Case loads(iload, 11)
            Case "From start"
                oSB.AppendLine(ConCat_pvt("12", "0", "From start"))
            Case "From end"
                oSB.AppendLine(ConCat_pvt("12", "1", "From end"))
        End Select
        'p13 & p14 would be the ey and ez eccentricities for the line load
        oSB.AppendLine(ConCat_pv("13", loads(iload, 12)))
        oSB.AppendLine(ConCat_pv("14", loads(iload, 13)))
        'edge
        oSB.AppendLine(ConCat_pvt("15", loads(iload, 2) - 1, loads(iload, 2)))
        oSB.AppendLine("</obj>")

    End Sub


    Private Sub WriteMomentLineLoadOnEdge(ByRef oSB, iload, loads(,)) 'write 1 line load on surface ede  to the XML stream


        oSB.AppendLine("<obj id=""" & Trim(Str(iload)) & """ nm=""" & "ESLM" & Trim(Str(iload)) & """>")
        oSB.AppendLine(ConCat_pv("0", "ESLM" & Trim(Str(iload))))
        oSB.AppendLine(ConCat_pn("1", loads(iload, 0)))
        'write surafec name as reference table
        oSB.AppendLine("<p2 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h2 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")
        Select Case (loads(iload, 12))
            Case "edge"
                oSB.AppendLine(ConCat_pv("0", "{8708ED31-8E66-11D4-AD94-F6F5DE2BE344}"))
                oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Plane.1"))
            Case "internal"
                oSB.AppendLine(ConCat_pv("0", "{4FCA60AD-9308-468B-BD02-3D4E17830029}"))
                oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_SlabInternalEdge.1"))
            Case Else
                oSB.AppendLine(ConCat_pv("0", "{8708ED31-8E66-11D4-AD94-F6F5DE2BE344}"))
                oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Plane.1"))
        End Select
        oSB.AppendLine(ConCat_pv("2", loads(iload, 1)))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p2>")
        'end of reference table

        'direction

        Select Case loads(iload, 4)
            Case "Mx"
                oSB.AppendLine(ConCat_pvt("3", "0", "Mx"))
            Case "My"
                oSB.AppendLine(ConCat_pvt("3", "1", "My"))
            Case "Mz"
                oSB.AppendLine(ConCat_pvt("3", "2", "Mz"))
        End Select
        'distribution & values
        Select Case loads(iload, 5)
            Case "Uniform"
                oSB.AppendLine(ConCat_pvt("4", "0", loads(iload, 5)))
            Case "Trapez"
                oSB.AppendLine(ConCat_pvt("4", "1", loads(iload, 5)))
            Case Else
                oSB.AppendLine(ConCat_pvt("4", "0", loads(iload, 5)))
        End Select

        'load value
        oSB.AppendLine(ConCat_pv("5", loads(iload, 6) * 1000))
        oSB.AppendLine(ConCat_pv("6", loads(iload, 7) * 1000))
        'axis definition

        Select Case loads(iload, 3)
            Case "GCS - Length"
                oSB.AppendLine(ConCat_pvt("7", "0", "GCS"))
                oSB.AppendLine(ConCat_pvt("8", "0", "Length"))
            Case "GCS - Projection"
                oSB.AppendLine(ConCat_pvt("7", "0", "GCS"))
                oSB.AppendLine(ConCat_pvt("8", "1", "Projection"))
            Case "LCS"
                oSB.AppendLine(ConCat_pvt("7", "1", "LCS"))
            Case Else
                oSB.AppendLine(ConCat_pvt("7", "1", "LCS"))
        End Select

        oSB.AppendLine(ConCat_pv("9", loads(iload, 9)))
        oSB.AppendLine(ConCat_pv("10", loads(iload, 10)))
        'p11 would be the definition of relative or absolute coordinates
        Select Case loads(iload, 8)
            Case "Rela"
                oSB.AppendLine(ConCat_pvt("11", "1", "Rela"))
            Case "Abso"
                oSB.AppendLine(ConCat_pvt("11", "0", "Abso"))
        End Select
        'p12 would be the indication of where the coordinates start: From start or From end
        Select Case loads(iload, 11)
            Case "From start"
                oSB.AppendLine(ConCat_pvt("12", "0", "From start"))
            Case "From end"
                oSB.AppendLine(ConCat_pvt("12", "1", "From end"))
        End Select

        'edge
        oSB.AppendLine(ConCat_pvt("13", loads(iload, 2) - 1, loads(iload, 2)))
        oSB.AppendLine("</obj>")

    End Sub

    Private Sub WriteSLoad(ByRef oSB, iload, loads(,)) 'write 1 surface load to the XML stream

        oSB.AppendLine("<obj id=""" & Trim(Str(iload)) & """ nm=""" & "SF" & Trim(Str(iload)) & """>")
        oSB.AppendLine(ConCat_pv("0", "SF" & Trim(Str(iload))))
        oSB.AppendLine(ConCat_pn("1", loads(iload, 0)))
        'write beam name as reference table
        oSB.AppendLine("<p2 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h2 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")
        oSB.AppendLine(ConCat_pv("0", "{8708ED31-8E66-11D4-AD94-F6F5DE2BE344}"))
        oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Plane.1"))
        oSB.AppendLine(ConCat_pv("2", loads(iload, 1)))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p2>")
        'end of reference table

        'direction
        Select Case loads(iload, 3)
            Case "X"
                oSB.AppendLine(ConCat_pvt("3", "0", "X"))
            Case "Y"
                oSB.AppendLine(ConCat_pvt("3", "1", "Y"))
            Case "Z"
                oSB.AppendLine(ConCat_pvt("3", "2", "Z"))
        End Select
        'load value
        oSB.AppendLine(ConCat_pv("4", loads(iload, 4) * 1000))
        'coordinate system & "location"
        Select Case loads(iload, 2)
            Case "GCS - Length"
                oSB.AppendLine(ConCat_pvt("5", "0", "GCS"))
                oSB.AppendLine(ConCat_pvt("6", "0", "Length"))
            Case "GCS - Projection"
                oSB.AppendLine(ConCat_pvt("5", "0", "GCS"))
                oSB.AppendLine(ConCat_pvt("6", "1", "Projection"))
            Case "LCS"
                oSB.AppendLine(ConCat_pvt("5", "1", "LCS"))
        End Select
        oSB.AppendLine("</obj>")

    End Sub
    Private Sub WritePLoadsPoint(ByRef oSB, iload, loads(,))

        oSB.AppendLine("<obj id=""" & Trim(Str(iload)) & """ nm=""" & "PLP" & Trim(Str(iload)) & """>")


        oSB.AppendLine(ConCat_pn("0", loads(iload, 0)))
        oSB.AppendLine(ConCat_pv("1", "PLP" & Trim(Str(iload))))
        'write beam name as reference table
        oSB.AppendLine("<p2 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h2 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")
        oSB.AppendLine(ConCat_pv("0", "{39A7F468-A0D4-4DFF-8E5C-5843E1807D13}"))
        oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_StructNode.1"))
        oSB.AppendLine(ConCat_pv("2", DupNodeDict(loads(iload, 1))))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p2>")
        'end of reference table

        'direction
        Select Case loads(iload, 3)
            Case "X"
                oSB.AppendLine(ConCat_pvt("3", "0", "X"))
            Case "Y"
                oSB.AppendLine(ConCat_pvt("3", "1", "Y"))
            Case "Z"
                oSB.AppendLine(ConCat_pvt("3", "2", "Z"))
        End Select
        'coordinate system
        Select Case loads(iload, 2)
            Case "GCS"
                oSB.AppendLine(ConCat_pvt("4", "0", "GCS"))
            Case "LCS"
                oSB.AppendLine(ConCat_pvt("4", "1", "LCS"))
        End Select
        'load value
        oSB.AppendLine(ConCat_pv("5", loads(iload, 4) * 1000))
        'angle
        oSB.AppendLine(ConCat_pv("6", loads(iload, 5)))
        oSB.AppendLine("</obj>")
    End Sub

    Private Sub WriteMLoadsPoint(ByRef oSB, iload, loads(,))

        oSB.AppendLine("<obj id=""" & Trim(Str(iload)) & """ nm=""" & "MLP" & Trim(Str(iload)) & """>")


        oSB.AppendLine(ConCat_pn("0", loads(iload, 0)))
        oSB.AppendLine(ConCat_pv("1", "MLP" & Trim(Str(iload))))
        'write beam name as reference table
        oSB.AppendLine("<p2 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h2 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")
        oSB.AppendLine(ConCat_pv("0", "{39A7F468-A0D4-4DFF-8E5C-5843E1807D13}"))
        oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_StructNode.1"))
        oSB.AppendLine(ConCat_pv("2", DupNodeDict(loads(iload, 1))))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p2>")
        'end of reference table



        'direction
        Select Case loads(iload, 3)
            Case "Mx"
                oSB.AppendLine(ConCat_pvt("3", "0", "Mx"))
            Case "My"
                oSB.AppendLine(ConCat_pvt("3", "1", "My"))
            Case "Mz"
                oSB.AppendLine(ConCat_pvt("3", "2", "Mz"))
        End Select
        'coordinate system
        Select Case loads(iload, 2)
            Case "GCS"
                oSB.AppendLine(ConCat_pvt("4", "0", "GCS"))
            Case "LCS"
                oSB.AppendLine(ConCat_pvt("4", "1", "LCS"))
        End Select
        'load value
        oSB.AppendLine(ConCat_pv("5", loads(iload, 4) * 1000))

        oSB.AppendLine("</obj>")
    End Sub

    Sub WritePLoadsBeam(ByRef oSB, iload, loads(,))

        oSB.AppendLine("<obj id=""" & Trim(Str(iload)) & """ nm=""" & "PLB" & Trim(Str(iload)) & """>")
        oSB.AppendLine(ConCat_pn("0", loads(iload, 0)))
        oSB.AppendLine(ConCat_pv("1", "PLB" & Trim(Str(iload))))
        'write beam name as reference table
        oSB.AppendLine("<p2 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h2 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")
        oSB.AppendLine(ConCat_pv("0", "{ECB5D684-7357-11D4-9F6C-00104BC3B443}"))
        oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Beam.1"))
        oSB.AppendLine(ConCat_pv("2", loads(iload, 1)))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p2>")
        'end of reference table

        'direction
        Select Case loads(iload, 3)
            Case "X"
                oSB.AppendLine(ConCat_pvt("3", "0", "X"))
            Case "Y"
                oSB.AppendLine(ConCat_pvt("3", "1", "Y"))
            Case "Z"
                oSB.AppendLine(ConCat_pvt("3", "2", "Z"))
        End Select
        'coordinate system
        Select Case loads(iload, 2)
            Case "GCS"
                oSB.AppendLine(ConCat_pvt("4", "0", "GCS"))
            Case "LCS"
                oSB.AppendLine(ConCat_pvt("4", "1", "LCS"))
        End Select
        'load value
        oSB.AppendLine(ConCat_pv("5", loads(iload, 4) * 1000))
        Select Case loads(iload, 5)
            Case "Rela"
                oSB.AppendLine(ConCat_pvt("6", "1", "Rela"))
            Case "Abso"
                oSB.AppendLine(ConCat_pvt("6", "0", "Abso"))
        End Select
        oSB.AppendLine(ConCat_pv("7", loads(iload, 6)))
        Select Case loads(iload, 7)
            Case "From start"
                oSB.AppendLine(ConCat_pvt("8", "0", "From start"))
            Case "From end"
                oSB.AppendLine(ConCat_pvt("8", "1", "From end"))
        End Select


        oSB.AppendLine(ConCat_pv("9", loads(iload, 8)))
        oSB.AppendLine(ConCat_pv("10", loads(iload, 9)))
        oSB.AppendLine(ConCat_pv("11", loads(iload, 10)))
        oSB.AppendLine(ConCat_pv("12", loads(iload, 11)))

        oSB.AppendLine("</obj>")
    End Sub
    Sub WriteMLoadsBeam(ByRef oSB, iload, loads(,))

        oSB.AppendLine("<obj id=""" & Trim(Str(iload)) & """ nm=""" & "MLB" & Trim(Str(iload)) & """>")
        oSB.AppendLine(ConCat_pn("0", loads(iload, 0)))
        oSB.AppendLine(ConCat_pv("1", "MLB" & Trim(Str(iload))))
        'write beam name as reference table
        oSB.AppendLine("<p2 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h2 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")
        oSB.AppendLine(ConCat_pv("0", "{ECB5D684-7357-11D4-9F6C-00104BC3B443}"))
        oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Beam.1"))
        oSB.AppendLine(ConCat_pv("2", loads(iload, 1)))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p2>")
        'end of reference table

        'direction
        Select Case loads(iload, 3)
            Case "Mx"
                oSB.AppendLine(ConCat_pvt("3", "0", "Mx"))
            Case "My"
                oSB.AppendLine(ConCat_pvt("3", "1", "My"))
            Case "Mz"
                oSB.AppendLine(ConCat_pvt("3", "2", "Mz"))
        End Select
        'coordinate system
        Select Case loads(iload, 2)
            Case "GCS"
                oSB.AppendLine(ConCat_pvt("4", "0", "GCS"))
            Case "LCS"
                oSB.AppendLine(ConCat_pvt("4", "1", "LCS"))
        End Select
        'load value
        oSB.AppendLine(ConCat_pv("5", loads(iload, 4) * 1000))
        Select Case loads(iload, 5)
            Case "Rela"
                oSB.AppendLine(ConCat_pvt("6", "1", "Rela"))
            Case "Abso"
                oSB.AppendLine(ConCat_pvt("6", "0", "Abso"))
        End Select
        oSB.AppendLine(ConCat_pv("7", loads(iload, 6)))
        Select Case loads(iload, 7)
            Case "From start"
                oSB.AppendLine(ConCat_pvt("8", "0", "From start"))
            Case "From end"
                oSB.AppendLine(ConCat_pvt("8", "1", "From end"))
        End Select


        oSB.AppendLine(ConCat_pv("9", loads(iload, 8)))
        oSB.AppendLine(ConCat_pv("10", loads(iload, 9)))


        oSB.AppendLine("</obj>")
    End Sub




    Private Sub WriteFPLoad(ByRef oSB, scale, iload, loads(,)) 'write 1 free point load to the XML stream
        'a free point load consists of:
        'Load Case, Selection, Validity, coord sys (GCS/LCS), direction (X, Y, Z), value (kN), PointX, PointY, PointZ

        oSB.AppendLine("<obj id=""" & Trim(Str(iload)) & """ nm=""" & "FF" & Trim(Str(iload)) & """>")
        oSB.AppendLine(ConCat_pn("0", loads(iload, 0)))
        oSB.AppendLine(ConCat_pv("1", "FF" & Trim(Str(iload))))
        'direction
        Select Case loads(iload, 4)
            Case "X"
                oSB.AppendLine(ConCat_pvt("2", "0", "X"))
            Case "Y"
                oSB.AppendLine(ConCat_pvt("2", "1", "Y"))
            Case "Z"
                oSB.AppendLine(ConCat_pvt("2", "2", "Z"))
        End Select
        'validity
        Select Case loads(iload, 1)
            Case "All"
                oSB.AppendLine(ConCat_pvt("3", "0", "All"))
            Case "-Z"
                oSB.AppendLine(ConCat_pvt("3", "1", "-Z"))
            Case "+Z"
                oSB.AppendLine(ConCat_pvt("3", "2", "+Z"))
            Case "From-to"
                oSB.AppendLine(ConCat_pvt("3", "3", "From-to"))
            Case "Z=0"
                oSB.AppendLine(ConCat_pvt("3", "4", "Z=0"))
            Case "-Z"
                oSB.AppendLine(ConCat_pvt("3", "5", "-Z (incl. 0)"))
            Case "+Z"
                oSB.AppendLine(ConCat_pvt("3", "6", "+Z (incl. 0)"))
        End Select
        'selection
        oSB.AppendLine(ConCat_pvt("4", "0", "Auto"))
        'load value
        oSB.AppendLine(ConCat_pv("5", loads(iload, 5) * 1000))
        'point X, Y, Z coordinates
        oSB.AppendLine(ConCat_pv("6", loads(iload, 6) * scale))
        oSB.AppendLine(ConCat_pv("7", loads(iload, 7) * scale))
        oSB.AppendLine(ConCat_pv("8", loads(iload, 8) * scale))
        'coordinate system
        Select Case loads(iload, 3)
            Case "GCS"
                oSB.AppendLine(ConCat_pvt("9", "0", "GCS"))
            Case "Member LCS"
                oSB.AppendLine(ConCat_pvt("9", "1", "Member LCS"))
        End Select

        oSB.AppendLine("</obj>")

    End Sub


    Private Sub WriteFPMomentLoad(ByRef oSB, scale, iload, loads(,)) 'write 1 free point load to the XML stream
        'a free point load consists of:
        'Load Case, Selection, Validity, coord sys (GCS/LCS), direction (X, Y, Z), value (kN), PointX, PointY, PointZ

        oSB.AppendLine("<obj id=""" & Trim(Str(iload)) & """ nm=""" & "FMP" & Trim(Str(iload)) & """>")
        oSB.AppendLine(ConCat_pn("0", loads(iload, 0)))
        oSB.AppendLine(ConCat_pv("1", "FMP" & Trim(Str(iload))))
        'direction
        Select Case loads(iload, 4)
            Case "Mx"
                oSB.AppendLine(ConCat_pvt("2", "0", "Mx"))
            Case "My"
                oSB.AppendLine(ConCat_pvt("2", "1", "My"))
            Case "Mz"
                oSB.AppendLine(ConCat_pvt("2", "2", "Mz"))
        End Select
        'validity
        Select Case loads(iload, 1)
            Case "All"
                oSB.AppendLine(ConCat_pvt("3", "0", "All"))
            Case "-Z"
                oSB.AppendLine(ConCat_pvt("3", "1", "-Z"))
            Case "+Z"
                oSB.AppendLine(ConCat_pvt("3", "2", "+Z"))
            Case "From-to"
                oSB.AppendLine(ConCat_pvt("3", "3", "From-to"))
            Case "Z=0"
                oSB.AppendLine(ConCat_pvt("3", "4", "Z=0"))
            Case "-Z"
                oSB.AppendLine(ConCat_pvt("3", "5", "-Z (incl. 0)"))
            Case "+Z"
                oSB.AppendLine(ConCat_pvt("3", "6", "+Z (incl. 0)"))
        End Select
        'selection
        oSB.AppendLine(ConCat_pvt("4", "0", "Auto"))
        'load value
        oSB.AppendLine(ConCat_pv("5", loads(iload, 5) * 1000))
        'point X, Y, Z coordinates
        oSB.AppendLine(ConCat_pv("6", loads(iload, 6) * scale))
        oSB.AppendLine(ConCat_pv("7", loads(iload, 7) * scale))
        oSB.AppendLine(ConCat_pv("8", loads(iload, 8) * scale))
        'coordinate system
        Select Case loads(iload, 3)
            Case "GCS"
                oSB.AppendLine(ConCat_pvt("9", "0", "GCS"))
            Case "Member LCS"
                oSB.AppendLine(ConCat_pvt("9", "1", "Member LCS"))
        End Select
        oSB.AppendLine("</obj>")

    End Sub

    Private Sub WriteFLLoad(ByRef oSB, scale, iload, loads(,)) 'write 1 free line load to the XML stream
        'a free line load consists of:
        'load case, validity, selection, coord. system (GCS/LCS), direction (X, Y, Z), value (kN/m), LineShape

        Dim LineShape As String
        Dim row_id As Long

        oSB.AppendLine("<obj id=""" & Trim(Str(iload)) & """ nm=""" & "FL" & Trim(Str(iload)) & """>")
        oSB.AppendLine(ConCat_pn("0", loads(iload, 0)))
        oSB.AppendLine(ConCat_pv("1", "FL" & Trim(Str(iload))))
        'direction
        Select Case loads(iload, 4)
            Case "X"
                oSB.AppendLine(ConCat_pvt("2", "0", "X"))
            Case "Y"
                oSB.AppendLine(ConCat_pvt("2", "1", "Y"))
            Case "Z"
                oSB.AppendLine(ConCat_pvt("2", "2", "Z"))
        End Select

        'distribution
        Select Case loads(iload, 5)
            Case "Uniform"
                oSB.AppendLine(ConCat_pvt("3", "0", loads(iload, 5)))
            Case "Trapez"
                oSB.AppendLine(ConCat_pvt("3", "1", loads(iload, 5)))
            Case Else
                oSB.AppendLine(ConCat_pvt("3", "0", loads(iload, 5)))
        End Select

        'load value
        oSB.AppendLine(ConCat_pv("4", loads(iload, 6) * 1000))
        oSB.AppendLine(ConCat_pv("5", loads(iload, 7) * 1000))
        'validity
        Select Case loads(iload, 1)
            Case "All"
                oSB.AppendLine(ConCat_pvt("6", "0", "All"))
            Case "-Z"
                oSB.AppendLine(ConCat_pvt("6", "1", "-Z"))
            Case "+Z"
                oSB.AppendLine(ConCat_pvt("6", "2", "+Z"))
            Case "From-to"
                oSB.AppendLine(ConCat_pvt("6", "3", "From-to"))
            Case "Z=0"
                oSB.AppendLine(ConCat_pvt("6", "4", "Z=0"))
            Case "-Z"
                oSB.AppendLine(ConCat_pvt("6", "5", "-Z (incl. 0)"))
            Case "+Z"
                oSB.AppendLine(ConCat_pvt("6", "6", "+Z (incl. 0)"))
        End Select

        'selection (loads(iload,2))
        oSB.AppendLine(ConCat_pvt("7", "0", "Auto"))

        'coordinate system
        Select Case loads(iload, 3)
            Case "GCS - Length"
                oSB.AppendLine(ConCat_pvt("8", "0", "GCS"))
                oSB.AppendLine(ConCat_pvt("9", "0", "Length"))
            Case "GCS - Projection"
                oSB.AppendLine(ConCat_pvt("8", "0", "GCS"))
                oSB.AppendLine(ConCat_pvt("9", "1", "Projection"))
            Case "Member LCS"
                oSB.AppendLine(ConCat_pvt("8", "1", "Member LCS"))
        End Select

        'table of geometry
        LineShape = loads(iload, 8)

        oSB.AppendLine(ConCat_opentable("10", ""))

        oSB.AppendLine("<h>")
        oSB.AppendLine(ConCat_ht("0", "Node"))
        oSB.AppendLine(ConCat_ht("1", "Point definition"))
        oSB.AppendLine(ConCat_ht("2", "Coord X"))
        oSB.AppendLine(ConCat_ht("3", "Coord Y"))
        oSB.AppendLine(ConCat_ht("4", "Coord Z"))
        oSB.AppendLine(ConCat_ht("5", "Edge"))
        oSB.AppendLine("</h>")

        row_id = 0
        oSB.AppendLine(ConCat_row(row_id))
        oSB.AppendLine(ConCat_pv("0", "Head"))
        oSB.AppendLine(ConCat_pvt("1", "0", "Standard"))
        oSB.AppendLine(ConCat_pv("2", Trim(Split(LineShape, ";")(1) * scale))) 'first node X
        oSB.AppendLine(ConCat_pv("3", Trim(Split(LineShape, ";")(2) * scale))) 'first node Y
        oSB.AppendLine(ConCat_pv("4", Trim(Split(LineShape, ";")(3) * scale))) 'first node Z
        Select Case Strings.Trim(Strings.Split(LineShape, ";")(0)) 'curve type - only "Line by 2 pts" is supported by SCIA Engineer
            Case "Line"
                If UILanguageNumber = "0" Then oSB.AppendLine(ConCat_pv("5", "Line")) 'English
                If UILanguageNumber = "1" Then oSB.AppendLine(ConCat_pv("5", "Lijn")) 'Dutch
                If UILanguageNumber = "2" Then oSB.AppendLine(ConCat_pv("5", "Ligne")) 'French
                If UILanguageNumber = "3" Then oSB.AppendLine(ConCat_pv("5", "Linie")) 'German
                If UILanguageNumber = "4" Then oSB.AppendLine(ConCat_pv("5", "Přímka")) 'Czech
                If UILanguageNumber = "5" Then oSB.AppendLine(ConCat_pv("5", "Čiara")) 'Slovak

            Case "Arc"
                oSB.AppendLine(ConCat_pv("5", "Circle arc")) 'not supported in SE
            Case "Spline"
                oSB.AppendLine(ConCat_pv("5", "Spline")) 'not supported in SE
        End Select
        oSB.AppendLine("</row>")

        row_id = row_id + 1
        oSB.AppendLine(ConCat_row(row_id))
        oSB.AppendLine(ConCat_pv("0", "End"))
        oSB.AppendLine(ConCat_pvt("1", "0", "Standard"))
        oSB.AppendLine(ConCat_pv("2", Trim(Split(LineShape, ";")(4) * scale))) 'second node X
        oSB.AppendLine(ConCat_pv("3", Trim(Split(LineShape, ";")(5) * scale))) 'second node Y
        oSB.AppendLine(ConCat_pv("4", Trim(Split(LineShape, ";")(6) * scale))) 'second node Z
        oSB.AppendLine("</row>")

        oSB.AppendLine(ConCat_closetable("10"))

        oSB.AppendLine("</obj>")

    End Sub

    Private Sub WriteFSLoad(ByRef oSB, scale, iload, loads(,)) 'write 1 free surface load to the XML stream
        'a free line load consists of:
        'load case, validity, selection, coord. system (GCS/LCS), direction (X, Y, Z), value (kN/m), BoundaryShape

        Dim BoundaryShape As String
        Dim LineShape As String
        Dim row_id As Long

        oSB.AppendLine("<obj id=""" & Trim(Str(iload)) & """ nm=""" & "FL" & Trim(Str(iload)) & """>")
        oSB.AppendLine(ConCat_pn("0", loads(iload, 0)))
        oSB.AppendLine(ConCat_pv("1", "FL" & Trim(Str(iload))))
        'direction
        Select Case loads(iload, 4)
            Case "X"
                oSB.AppendLine(ConCat_pvt("2", "0", "X"))
            Case "Y"
                oSB.AppendLine(ConCat_pvt("2", "1", "Y"))
            Case "Z"
                oSB.AppendLine(ConCat_pvt("2", "2", "Z"))
        End Select

        'distribution
        oSB.AppendLine(ConCat_pvt("3", "0", "Uniform"))
        'load value
        oSB.AppendLine(ConCat_pv("4", loads(iload, 5) * 1000))

        'validity
        Select Case loads(iload, 1)
            Case "All"
                oSB.AppendLine(ConCat_pvt("5", "0", "All"))
            Case "-Z"
                oSB.AppendLine(ConCat_pvt("5", "1", "-Z"))
            Case "+Z"
                oSB.AppendLine(ConCat_pvt("5", "2", "+Z"))
            Case "From-to"
                oSB.AppendLine(ConCat_pvt("5", "3", "From-to"))
            Case "Z=0"
                oSB.AppendLine(ConCat_pvt("4", "4", "Z=0"))
            Case "-Z"
                oSB.AppendLine(ConCat_pvt("4", "5", "-Z (incl. 0)"))
            Case "+Z"
                oSB.AppendLine(ConCat_pvt("5", "6", "+Z (incl. 0)"))
        End Select

        'selection (loads(iload,2))
        oSB.AppendLine(ConCat_pvt("6", "0", "Auto"))

        'coordinate system
        Select Case loads(iload, 3)
            Case "GCS - Length"
                oSB.AppendLine(ConCat_pvt("7", "0", "GCS"))
                oSB.AppendLine(ConCat_pvt("8", "0", "Length"))
            Case "GCS - Projection"
                oSB.AppendLine(ConCat_pvt("7", "0", "GCS"))
                oSB.AppendLine(ConCat_pvt("8", "1", "Projection"))
            Case "Member LCS"
                oSB.AppendLine(ConCat_pvt("7", "1", "Member LCS"))
        End Select

        'table of geometry

        oSB.AppendLine(ConCat_opentable("9", ""))

        oSB.AppendLine("<h>")
        oSB.AppendLine(ConCat_ht("0", "Node"))
        oSB.AppendLine(ConCat_ht("1", "Point definition"))
        oSB.AppendLine(ConCat_ht("2", "Coord X"))
        oSB.AppendLine(ConCat_ht("3", "Coord Y"))
        oSB.AppendLine(ConCat_ht("4", "Coord Z"))
        oSB.AppendLine(ConCat_ht("5", "Edge"))
        oSB.AppendLine("</h>")

        BoundaryShape = loads(iload, 6)
        row_id = 0

        For Each LineShape In BoundaryShape.Split("|")

            oSB.AppendLine(ConCat_row(row_id))
            oSB.AppendLine(ConCat_pv("0", "Head"))
            oSB.AppendLine(ConCat_pvt("1", "0", "Standard"))
            oSB.AppendLine(ConCat_pv("2", Trim(Split(LineShape, ";")(1) * scale))) 'first node X
            oSB.AppendLine(ConCat_pv("3", Trim(Split(LineShape, ";")(2) * scale))) 'first node Y
            oSB.AppendLine(ConCat_pv("4", Trim(Split(LineShape, ";")(3) * scale))) 'first node Z
            Select Case Strings.Trim(Strings.Split(LineShape, ";")(0)) 'curve type - only "Line by 2 pts" is supported by SCIA Engineer
                Case "Line"
                    If UILanguageNumber = "0" Then oSB.AppendLine(ConCat_pv("5", "Line")) 'English
                    If UILanguageNumber = "1" Then oSB.AppendLine(ConCat_pv("5", "Lijn")) 'Dutch
                    If UILanguageNumber = "2" Then oSB.AppendLine(ConCat_pv("5", "Ligne")) 'French
                    If UILanguageNumber = "3" Then oSB.AppendLine(ConCat_pv("5", "Linie")) 'German
                    If UILanguageNumber = "4" Then oSB.AppendLine(ConCat_pv("5", "Přímka")) 'Czech
                    If UILanguageNumber = "5" Then oSB.AppendLine(ConCat_pv("5", "Čiara")) 'Slovak
                Case "Arc"
                    oSB.AppendLine(ConCat_pv("5", "Circle arc")) 'not supported in SE
                Case "Spline"
                    oSB.AppendLine(ConCat_pv("5", "Spline")) 'not supported in SE
            End Select

            oSB.AppendLine("</row>")

            row_id = row_id + 1
        Next LineShape

        oSB.AppendLine(ConCat_closetable("9"))

        oSB.AppendLine("</obj>")

    End Sub

    Private Sub WriteHinge(ByRef oSB, ihinge, hinges(,)) 'write 1 hinge to the XML stream
        Dim tt As String

        oSB.AppendLine("<obj nm=""H" & ihinge & """>")
        oSB.AppendLine(ConCat_pv("0", "H" & ihinge)) 'Hinge name
        'write beam name as reference table
        oSB.AppendLine("<p1 t="""">")
        oSB.AppendLine("<h>")
        oSB.AppendLine("<h0 t=""Member Type""/>")
        oSB.AppendLine("<h1 t=""Member Type Name""/>")
        oSB.AppendLine("<h2 t=""Member Name""/>")
        oSB.AppendLine("</h>")
        oSB.AppendLine("<row id=""0"">")
        oSB.AppendLine(ConCat_pv("0", "{ECB5D684-7357-11D4-9F6C-00104BC3B443}"))
        oSB.AppendLine(ConCat_pv("1", "EP_DSG_Elements.EP_Beam.1"))
        oSB.AppendLine(ConCat_pv("2", hinges(ihinge, 0)))
        oSB.AppendLine("</row>")
        oSB.AppendLine("</p1>")
        'end of reference table

        Select Case hinges(ihinge, 1)
            Case "Begin"
                oSB.AppendLine(ConCat_pvt("2", "0", "Begin"))
            Case "End"
                oSB.AppendLine(ConCat_pvt("2", "1", "End"))
            Case "Both"
                oSB.AppendLine(ConCat_pvt("2", "2", "Both"))
            Case Else
                oSB.AppendLine(ConCat_pvt("2", "2", "Both"))
        End Select


        tt = GetStringForDOF(hinges(ihinge, 2))
        oSB.AppendLine(ConCat_pvt("3", hinges(ihinge, 2), tt))
        tt = GetStringForDOF(hinges(ihinge, 3))
        oSB.AppendLine(ConCat_pvt("4", hinges(ihinge, 3), tt))
        tt = GetStringForDOF(hinges(ihinge, 4))
        oSB.AppendLine(ConCat_pvt("5", hinges(ihinge, 4), tt))
        tt = GetStringForDOF(hinges(ihinge, 5))
        oSB.AppendLine(ConCat_pvt("6", hinges(ihinge, 5), tt))
        tt = GetStringForDOF(hinges(ihinge, 6))
        oSB.AppendLine(ConCat_pvt("7", hinges(ihinge, 6), tt))
        tt = GetStringForDOF(hinges(ihinge, 7))
        oSB.AppendLine(ConCat_pvt("8", hinges(ihinge, 7), tt))
        oSB.AppendLine(ConCat_pv("9", hinges(ihinge, 8)))
        oSB.AppendLine(ConCat_pv("10", hinges(ihinge, 9)))
        oSB.AppendLine(ConCat_pv("11", hinges(ihinge, 10)))
        oSB.AppendLine(ConCat_pv("12", hinges(ihinge, 11)))
        oSB.AppendLine(ConCat_pv("13", hinges(ihinge, 12)))
        oSB.AppendLine(ConCat_pv("14", hinges(ihinge, 13)))


        oSB.AppendLine("</obj>")

    End Sub

    Sub WriteCrossLink(ByRef oSB, icorsslink, crosslink(,)) 'write 1 hinge to the XML stream


        oSB.AppendLine("<obj nm=""CRL" & icorsslink & """>")
        oSB.AppendLine(ConCat_pv("0", "CRL" & icorsslink)) 'Cross0-link name

        Select Case crosslink(icorsslink, 0)
            Case "Fixed"
                oSB.AppendLine(ConCat_pvt("1", "0", "Fixed"))
            Case "Hinged"
                oSB.AppendLine(ConCat_pvt("1", "1", "Hinged"))
            Case "Coupler"
                oSB.AppendLine(ConCat_pvt("1", "2", "Coupler"))
        End Select
        oSB.AppendLine(ConCat_pv("2", crosslink(icorsslink, 1)))
        oSB.AppendLine(ConCat_pv("3", crosslink(icorsslink, 2)))

        oSB.AppendLine("</obj>")


    End Sub

    Function WrapIfRequired(Filename As String) As String
        Dim containsSpaces = False
        Dim ContainsQuotes = False

        Dim FilePath = Filename.Trim
        If FilePath.Contains(" ") Then containsSpaces = True
        If FilePath.Substring(0, 1) = """" Then ContainsQuotes = True
        If FilePath.Substring(FilePath.Length - 1, 1) = """" And ContainsQuotes = False Then ContainsQuotes = True

        If containsSpaces = True And ContainsQuotes = False Then
            'Only wrap if it contains spaces in string and not already quoted
            Return """" & FilePath & """"""
        Else
            Return FilePath
        End If
    End Function

    Public Function RunCalculationWithEsaXML(FileName As String, ESAXMLPath As String, CalcType As String, TemplateName As String, OutputFile As String, ByRef time_elapsed As Double, SESavedProject As String) As String

        Dim stopWatch As New System.Diagnostics.Stopwatch()


        'initialize stopwatch
        stopWatch.Start()

        Rhino.RhinoApp.WriteLine("")
        Rhino.RhinoApp.WriteLine("===== KOALA SCIA Engineer plugin - running analysis =====")
        Dim strOut As String
        'run ESA_XML
        '---------------------------------------------------
        Try
            Dim myProcess As New System.Diagnostics.Process
            Dim ESAXMLArgs As String
            Dim strErr As String, intExit As Integer

            Dim ExportType As String = ""
            Dim ExportTypeString As String

            ExportType = OutputFile.Split(".").Last
            Select Case ExportType
                Case "tst"
                    ExportTypeString = "-tTST -o"
                Case "xlsx"
                    ExportTypeString = "-sd -tXLSX -o"
                Case "rtf"
                    ExportTypeString = "-sd -tRTF -o"

                Case "pdf"
                    ExportTypeString = "-sd -tPDF -o"
                Case "dds"
                    ExportTypeString = "-sd -tDDS -o"
                Case "txt"
                    ExportTypeString = "-tTXT -o"
                Case "XML"
                    ExportTypeString = "-tXML -o"
                Case Else
                    ExportTypeString = "-tTXT -o"
            End Select
            '.\ESA_XML.exe LIN 'C:\TEMP\MakaraHala\SCIAtemplate.ESA' 'C:\TEMP\MakaraHala\KoalaHall.xml' -sd -tXLSX -oC:\TEMP\MakaraHala\Output.xlsx
            myProcess.StartInfo.FileName = ESAXMLPath

            'TemplateName = WrapIfRequired(TemplateName)
            'FileName = WrapIfRequired(FileName)

            If Not SESavedProject = "" Then
                Dim MultiProcesFile = System.IO.Path.GetDirectoryName(SESavedProject)
                MultiProcesFile += "\runParameters.txt"
                'FileCopy(TemplateName, SESavedProject)
                Dim Parameters = CalcType & " " & TemplateName & " " & FileName & " -tESA -o" & SESavedProject & Environment.NewLine
                If Not OutputFile = "" Then
                    Parameters += CalcType & " " & TemplateName & " " & FileName & " " & ExportTypeString & OutputFile & Environment.NewLine
                End If

                System.IO.File.WriteAllText(MultiProcesFile, Parameters)
                ESAXMLArgs = "CMD" & " " & MultiProcesFile
                'File.Delete(MultiProcesFile)
            Else
                ESAXMLArgs = CalcType & " " & TemplateName & " " & FileName
                If Not OutputFile = "" Then
                    ESAXMLArgs += " " & ExportTypeString & OutputFile
                End If
            End If





            myProcess.StartInfo.Arguments = ESAXMLArgs
            myProcess.StartInfo.UseShellExecute = False
            'myProcess.StartInfo.RedirectStandardOutput = True
            'myProcess.StartInfo.RedirectStandardError = True
            'myProcess.StartInfo.CreateNoWindow = True

            Rhino.RhinoApp.WriteLine("Starting SCIA Engineer...")
            Rhino.RhinoApp.WriteLine("Arguments: " & ESAXMLArgs)
            Rhino.RhinoApp.WriteLine("Please wait...")

            myProcess.Start()

            'Dim calculationOutputReport As StreamReader
            'calculationOutputReport = myProcess.StandardOutput
            'Dim calculationOutputReportString As String
            'calculationOutputReportString = calculationOutputReport.ReadToEnd()
            myProcess.WaitForExit()
            'Dim calculationLogFile As String
            'calculationLogFile = System.IO.Path.GetDirectoryName(OutputFile) + "\CalculationLog.txt"
            'System.IO.File.WriteAllText(calculationLogFile, calculationOutputReportString)
            'calculationLogFile = System.IO.Path.GetDirectoryName(OutputFile) + "\CalculationLog.txt"
            'System.IO.File.WriteAllText(calculationLogFile, calculationOutputReportString)
            intExit = myProcess.ExitCode
            Rhino.RhinoApp.Write("SCIA Engineer finished with exit code: " & intExit)
            'output anything that could come out of SCIA Engineer
            'standard out
            strOut = ""
            Select Case intExit
                Case 0
                    Rhino.RhinoApp.WriteLine(" - Succeeded")
                    strOut = " Calculation Succeeded"
                Case 1
                    Rhino.RhinoApp.WriteLine(" - Unable To initialize MFC")
                    strOut = "Unable To initialize MFC"
                Case 2
                    Rhino.RhinoApp.WriteLine(" - Missing arguments")
                    strOut = "Missing arguments in commandline"
                Case 3
                    Rhino.RhinoApp.WriteLine(" - Invalid arguments")
                    strOut = "Invalid arguments in command line"
                Case 4
                    Rhino.RhinoApp.WriteLine(" - Unable To open ProjectFile")
                    strOut = "Unable To open ProjectFile"
                Case 5
                    Rhino.RhinoApp.WriteLine(" - Calculation failed")
                    strOut = "Calculation failed"
                Case 6
                    Rhino.RhinoApp.WriteLine(" - Unable To initialize application environment")
                    strOut = "Unable To initialize application environment"
                Case 7
                    Rhino.RhinoApp.WriteLine(" - Error during update ProjectFile By XMLUpdateFile")
                    strOut = "Error during update ProjectFile By XMLUpdateFile"
                Case 8
                    Rhino.RhinoApp.WriteLine(" - Error during create export outputs")
                    strOut = "Error during create export outputs"
                Case 9
                    Rhino.RhinoApp.WriteLine(" - Error during create XML outputs")
                    strOut = "Error during create XML outputs"
                Case 99
                    Rhino.RhinoApp.WriteLine(" - Error during update ProjectFile By XLSX Update")
                    strOut = "Error during update ProjectFile By XLSX Update"
                Case Else
                    Rhino.RhinoApp.WriteLine(" - Unknown exit code")
                    strOut = "Unknown exit code"
            End Select


            'strOut = myProcess.StandardOutput.ReadToEnd
            If strOut Is "" Then
            Else
                Rhino.RhinoApp.WriteLine("SCIA Engineer output message: " & strOut)

            End If
            'standard error
            strErr = ""
            'strErr = myProcess.StandardOutput.ReadToEnd
            If strErr <> "" Then Rhino.RhinoApp.WriteLine("SCIA Engineer error message: " & strErr)

            ' DA.SetData(1, OutputFile)
        Catch ex As Exception
            Rhino.RhinoApp.WriteLine("Encountered error launching esa_xml.exe: " & ex.Message)
            strOut = "Encountered error launching esa_xml.exe: " & ex.Message
        End Try


        'stop stopwatch
        stopWatch.Stop()
        time_elapsed = stopWatch.ElapsedMilliseconds
        Rhino.RhinoApp.WriteLine("Done in " + Str(time_elapsed) + " ms.")
        Return strOut
    End Function

End Module
