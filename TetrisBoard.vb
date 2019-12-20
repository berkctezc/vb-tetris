Option Strict On

Namespace Tetris
    Public Class TetrisBoard
        Private Parent As Control

#Region "Public Properties"
        Private _Rows As Integer
        Public Property Rows() As Integer
            Get
                Return _Rows
            End Get
            Set(ByVal value As Integer)
                _Rows = value
            End Set
        End Property

        Private _Columns As Integer
        Public Property Columns() As Integer
            Get
                Return _Columns
            End Get
            Set(ByVal value As Integer)
                _Columns = value
            End Set
        End Property

        Private _CellSize As Size
        Public Property CellSize() As Size
            Get
                Return _CellSize
            End Get
            Set(ByVal value As Size)
                _CellSize = value
            End Set
        End Property

        Private _Cells(,) As TetrisCell
        Public ReadOnly Property Cells(ByVal row As Integer, ByVal column As Integer) As TetrisCell
            Get
                If row < 0 OrElse column < 0 OrElse row > Rows OrElse column > Columns Then Return Nothing
                Return _Cells(row, column)
            End Get
        End Property

        Private _Style As BorderStyle = BorderStyle.Fixed3D
        Public Property Style() As BorderStyle
            Get
                Return _Style
            End Get
            Set(ByVal value As BorderStyle)
                If _Style <> value Then
                    _Style = value
                    If _Cells IsNot Nothing Then
                        For row = 1 To Rows
                            For column = 1 To Columns
                                _Cells(row, column).Style = _Style
                            Next
                        Next
                    End If
                End If
            End Set
        End Property

        Private _Color As Color
        Public Property Color() As Color
            Get
                Return _Color
            End Get
            Set(ByVal value As Color)
                _Color = value
                If _Color <> value Then
                    _Color = value
                    If _Cells IsNot Nothing Then
                        For row = 1 To Rows
                            For column = 1 To Columns
                                _Cells(row, column).HighlightColor = _Color
                            Next
                        Next
                    End If
                End If
            End Set
        End Property
#End Region

#Region "Public Methods"
        Public Sub New(ByVal container As Control)
            Me.Parent = container
        End Sub

        Public Function IsRowComplete(ByVal row As Integer) As Boolean 'Satırın tamamlanıp tamamlanmamasını kontrol etmek
            For column As Integer = 1 To Columns
                If Cells(row, column).IsEmpty Then Return False
            Next
            Return True
        End Function

        Public Sub RemoveRow(ByVal row As Integer) 'Tamamlandığı onaylanan satırı yok etmek.'
            Dim peakFound As Boolean
            For selectedRow As Integer = row - 1 To 0 Step -1
                peakFound = True
                For column As Integer = 1 To Columns
                    Dim cellToMove As TetrisCell = Cells(selectedRow, column)
                    Dim cellBeneath As TetrisCell = Cells(selectedRow + 1, column)
                    cellBeneath.HighlightColor = cellToMove.HighlightColor
                    cellBeneath.Highlighted = cellToMove.Highlighted
                    cellBeneath.IsEmpty = cellToMove.IsEmpty
                    If Not cellToMove.IsEmpty Then peakFound = False
                Next
                If peakFound Then Exit For
            Next
        End Sub

        Public Sub SetupBoard()
            Dim width As Integer = CellSize.Width  'Hücre Kare Şeklindedir'
            Parent.Controls.Clear()
            ReDim _Cells(Rows, Columns)
            For row = 1 To Rows
                For col = 1 To Columns
                    _Cells(row, col) = New TetrisCell
                    With Cells(row, col)
                        .Row = row
                        .Column = col
                        .Parent = Parent
                        .Size = CellSize
                        .Location = New Point((col - 1) * width, (row - 1) * width)
                        .IsEmpty = True
                        .Highlighted = False
                        .Style = Me.Style
                    End With
                Next
            Next
        End Sub
#End Region
    End Class
End Namespace