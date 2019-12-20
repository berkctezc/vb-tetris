Option Strict On
Namespace Tetris
    Public Class TetrisBlock
        Private ParentBoard As TetrisBoard

#Region "Enumerations"
        Public Enum MoveDirection 'Hareket Kabiliyetleri'
            Left
            Right
            Down
        End Enum

        Public Enum Shapes   'Oyundaki şekillerin latin alfebesindeki Karşılıkları'
            I1 = 1
            I2
            I3
            I4
            J1
            J2
            J3
            J4
            L1
            L2
            L3
            L4
            O1
            O2
            O3
            O4
            S1
            S2
            S3
            S4
            T1
            T2
            T3
            T4
            Z1
            Z2
            Z3
            Z4
        End Enum
#End Region

#Region "Public Properties"
        Private _Cells() As TetrisCell
        Public Property Cells() As TetrisCell()
            Get
                Return _Cells
            End Get
            Set(ByVal value As TetrisCell())
                _Cells = value
            End Set
        End Property

        Private _CenterCell As TetrisCell
        Public Property CenterCell() As TetrisCell
            Get
                Return _CenterCell
            End Get
            Set(ByVal value As TetrisCell)
                _CenterCell = value
            End Set
        End Property

        Private _Shape As Shapes
        Public Property Shape() As Shapes
            Get
                Return _Shape
            End Get
            Set(ByVal value As Shapes)
                _Shape = value
                UpdateShape()
            End Set
        End Property
#End Region

#Region "Public Methods"
        Public Sub New(ByVal parentBoard As TetrisBoard)
            Me.ParentBoard = parentBoard
        End Sub
        'Şekilin Hareket alanı'
        Public Function CanMove(ByVal direction As MoveDirection) As Boolean
            Dim newCenterCell As TetrisCell = Nothing
            Select Case direction
                Case MoveDirection.Left
                    newCenterCell = ParentBoard.Cells(CenterCell.Row, CenterCell.Column - 1)
                Case MoveDirection.Right
                    newCenterCell = ParentBoard.Cells(CenterCell.Row, CenterCell.Column + 1)
                Case MoveDirection.Down
                    newCenterCell = ParentBoard.Cells(CenterCell.Row + 1, CenterCell.Column)
            End Select
            Return CanMove(newCenterCell)
        End Function

        Public Function CanMove(ByVal targetPosition As TetrisCell) As Boolean
            If targetPosition Is Nothing Then Return False
            For Each cell In GetShapeCells(Shape, targetPosition)
                If cell Is Nothing OrElse Not cell.IsEmpty Then Return False
            Next
            Return True
        End Function
        'Kat edeceği yolu belirler (eğer alttaki sınırın içinden geçerse crash verir).'
        Public Sub Move(ByVal direction As MoveDirection, Optional ByVal moveUnits As Integer = 1)
            Dim newCenterCell As TetrisCell = Nothing
            Select Case direction
                Case MoveDirection.Left
                    newCenterCell = ParentBoard.Cells(CenterCell.Row, CenterCell.Column - moveUnits)
                Case MoveDirection.Right
                    newCenterCell = ParentBoard.Cells(CenterCell.Row, CenterCell.Column + moveUnits)
                Case MoveDirection.Down
                    newCenterCell = ParentBoard.Cells(CenterCell.Row + moveUnits, CenterCell.Column)
            End Select
            Move(newCenterCell)
        End Sub

        Public Sub Move(ByVal targetPosition As TetrisCell, Optional ByVal moveUnits As Integer = 1)
            CenterCell = targetPosition
            RefreshBackGround()
            UpdateShape()
        End Sub

        Public Function CanRotate() As Boolean
            Dim nextShape As Shapes = GetRotatedShape()
            For Each cell In GetShapeCells(nextShape, CenterCell)
                If cell Is Nothing OrElse Not cell.IsEmpty Then Return False
            Next
            Return True
        End Function

        Public Sub Rotate()
            RefreshBackGround()
            Shape = GetRotatedShape()
        End Sub

        Public Sub Refresh()
            Dim shapeColor As Color = GetShapeColor(Shape)
            For Each cell In Cells
                cell.HighlightColor = shapeColor
                cell.Highlighted = True
            Next
        End Sub

        Public Sub RefreshBackGround()
            Dim cellToClear As TetrisCell
            For i = -3 To 3
                For j = -3 To 3
                    cellToClear = ParentBoard.Cells(CenterCell.Row + i, CenterCell.Column + j)
                    If cellToClear IsNot Nothing Then cellToClear.Refresh()
                Next
            Next
        End Sub
#End Region

#Region "Private Methods"
        Private Sub UpdateShape()
            Cells = GetShapeCells(Shape, CenterCell)
            Refresh()
        End Sub

        Private Function GetRotatedShape() As Shapes
            Dim rotatedShape As Integer = If(Shape Mod 4 = 0, Shape - 3, Shape + 1)
            Return CType(rotatedShape, Shapes)
        End Function
        'Şekillerin Dönme Durumları '
        Private Function GetShapeCells(ByVal theShape As Shapes, ByVal referenceCell As TetrisCell) As TetrisCell()
            Dim theCells() As TetrisCell
            Select Case theShape
                Case Shapes.I1, Shapes.I3
                    theCells = GetCells(referenceCell, -1, 0, 0, 0, 1, 0, 2, 0)
                Case Shapes.I2, Shapes.I4
                    theCells = GetCells(referenceCell, 0, -1, 0, 0, 0, 1, 0, 2)
                Case Shapes.J1
                    theCells = GetCells(referenceCell, -1, 0, 0, 0, 1, 0, 1, -1)
                Case Shapes.J2
                    theCells = GetCells(referenceCell, 0, 1, 0, 0, 0, -1, -1, -1)
                Case Shapes.J3
                    theCells = GetCells(referenceCell, 1, 0, 0, 0, -1, 0, -1, 1)
                Case Shapes.J4
                    theCells = GetCells(referenceCell, 0, -1, 0, 0, 0, 1, 1, 1)
                Case Shapes.L1
                    theCells = GetCells(referenceCell, -1, 0, 0, 0, 1, 0, 1, 1)
                Case Shapes.L2
                    theCells = GetCells(referenceCell, 0, 1, 0, 0, 0, -1, 1, -1)
                Case Shapes.L3
                    theCells = GetCells(referenceCell, 1, 0, 0, 0, -1, 0, -1, -1)
                Case Shapes.L4
                    theCells = GetCells(referenceCell, 0, -1, 0, 0, 0, 1, -1, 1)
                Case Shapes.O1, Shapes.O2, Shapes.O3, Shapes.O4
                    theCells = GetCells(referenceCell, -1, 0, 0, 0, 0, -1, -1, -1)
                Case Shapes.S1, Shapes.S3
                    theCells = GetCells(referenceCell, 0, -1, 0, 0, -1, 0, -1, 1)
                Case Shapes.S2, Shapes.S4
                    theCells = GetCells(referenceCell, 1, 0, 0, 0, 0, -1, -1, -1)
                Case Shapes.T1
                    theCells = GetCells(referenceCell, 0, -1, 0, 0, 0, 1, 1, 0)
                Case Shapes.T2
                    theCells = GetCells(referenceCell, -1, 0, 0, 0, 1, 0, 0, -1)
                Case Shapes.T3
                    theCells = GetCells(referenceCell, 0, 1, 0, 0, 0, -1, -1, 0)
                Case Shapes.T4
                    theCells = GetCells(referenceCell, 1, 0, 0, 0, -1, 0, 0, 1)
                Case Shapes.Z1, Shapes.Z3
                    theCells = GetCells(referenceCell, 0, -1, 0, 0, 1, 0, 1, 1)
                Case Shapes.Z2, Shapes.Z4
                    theCells = GetCells(referenceCell, -1, 0, 0, 0, 0, -1, 1, -1)
                Case Else
                    theCells = Nothing
            End Select
            Return theCells
        End Function

        Private Function GetCells(ByVal referenceCell As TetrisCell, ByVal ParamArray relativeCoordinates() As Integer) As TetrisCell()
            Dim theCells((relativeCoordinates.Count \ 2) - 1) As TetrisCell
            Dim refRow As Integer = referenceCell.Row
            Dim refCol As Integer = referenceCell.Column
            For i As Integer = 0 To theCells.Count - 1
                theCells(i) = ParentBoard.Cells(refRow + relativeCoordinates(i * 2), refCol + relativeCoordinates(i * 2 + 1))
            Next
            Return theCells
        End Function
        'Renkler'
        Private Function GetShapeColor(ByVal theShape As Shapes) As Color
            If ParentBoard.Color <> Color.Empty Then Return ParentBoard.Color
            Select Case theShape
                Case Shapes.I1 To Shapes.I4
                    Return Color.Green
                Case Shapes.J1 To Shapes.J4
                    Return Color.Orange
                Case Shapes.L1 To Shapes.L4
                    Return Color.Brown
                Case Shapes.O1 To Shapes.O4
                    Return Color.Red
                Case Shapes.S1 To Shapes.S4
                    Return Color.Cyan
                Case Shapes.T1 To Shapes.T4
                    Return Color.Blue
                Case Shapes.Z1 To Shapes.Z4
                    Return Color.Aqua
            End Select
        End Function
#End Region
    End Class
End Namespace