Option Strict On
Namespace Tetris
    Public Class TetrisCell
        Inherits Label
#Region "Private Properties"
        Private _Row As Integer = 0
        Public Property Row() As Integer
            Get
                Return _Row
            End Get
            Set(ByVal value As Integer)
                _Row = value
            End Set
        End Property

        Private _Column As Integer = 0
        Public Property Column() As Integer
            Get
                Return _Column
            End Get
            Set(ByVal value As Integer)
                _Column = value
            End Set
        End Property

        Private _IsEmpty As Boolean = True
        Public Property IsEmpty() As Boolean
            Get
                Return _IsEmpty
            End Get
            Set(ByVal value As Boolean)
                _IsEmpty = value
            End Set
        End Property

        Private _HighlightColor As Color = Color.Red
        Public Property HighlightColor() As Color
            Get
                Return _HighlightColor
            End Get
            Set(ByVal value As Color)
                _HighlightColor = value
                If Me.Highlighted Then Me.BackColor = _HighlightColor
            End Set
        End Property

        Private _Style As BorderStyle = BorderStyle.Fixed3D
        Public Property Style() As BorderStyle
            Get
                Return _Style
            End Get
            Set(ByVal value As BorderStyle)
                _Style = value
                If Me.Highlighted Then Me.BorderStyle = _Style
            End Set
        End Property

        Private _Highlighted As Boolean = False
        Public Property Highlighted() As Boolean
            Get
                Return _Highlighted
            End Get
            Set(ByVal value As Boolean)
                _Highlighted = value
                If _Highlighted Then
                    Me.BackColor = HighlightColor
                    Me.BorderStyle = Style
                Else
                    Me.BackColor = Me.Parent.BackColor
                    Me.BorderStyle = BorderStyle.None
                End If
            End Set
        End Property
#End Region
#Region "Public Methods"
        Public Overrides Sub Refresh()
            Dim temp As Boolean = Me.Highlighted
            Me.Highlighted = False
            If Not IsEmpty Then Me.Highlighted = True
        End Sub
#End Region
    End Class
End Namespace
