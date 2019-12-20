Option Strict On
Imports TetrisProje.Tetris
Imports TetrisProje.Tetris.TetrisBlock
Partial Class TetrisGame
    Private GameBoard As TetrisBoard
    Private FallingBlock As TetrisBlock
    Private PreviewBoard As TetrisBoard
    Private PreviewBlock As TetrisBlock
    Private Score As Double
    Private Level As Integer
    Private Speed As Integer
    Private Lines As Integer
    Private RandomNumbers As New Random
    Private Status As GameStatus = GameStatus.Stopped

    'Oyunun bütün durumları'
    Private Enum GameStatus
        Running  'Çalışma durumu'
        Paused   'Duraklatma durumu' 
        Stopped  'Durdurma durumu'
    End Enum
#Region "Event Handlers"
    Private Sub TetrisGame_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Sıradaki Bloğun Önizlemesi'
        PreviewBoard = New TetrisBoard(PreviewBox)
        With PreviewBoard
            .Rows = 4
            .Columns = 4
            .CellSize = New Size(20, 20)
            .Style = BorderStyle.FixedSingle
            .SetupBoard()
        End With
        'Sıradaki şeklin rastgele oluşturması'
        PreviewBlock = New TetrisBlock(PreviewBoard)
        PreviewBlock.CenterCell = PreviewBoard.Cells(2, 2)
        PreviewBlock.Shape = GetRandomShape()

        'Oyun alanının sınırlanırını belirlemek.'
        GameBoard = New TetrisBoard(GameBox)
        With GameBoard
            .Rows = 20
            .Columns = 10
            .CellSize = New Size(20, 20)
            .Style = BorderStyle.FixedSingle
            .SetupBoard()
        End With
        FallingBlock = New TetrisBlock(GameBoard)
        ShowMessage(String.Format("{0}Tetrise{0}Hoşgeldiniz{0}{0}{0}Yeni Oyuna Başlamak için Tıklayın", vbCrLf))
    End Sub

    'Formdaki X tuşuna sonlandırma işleminin atanması'
    Private Sub TetrisGame_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Application.Exit()
        End If
    End Sub

    'Yönlendirmelerin tuşlara atanması'
    Private Sub TetrisGame_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Left, Keys.Right, Keys.Down, Keys.Up, Keys.Space, Keys.W, Keys.A, Keys.S, Keys.D
                If Status = GameStatus.Running Then
                    With FallingBlock
                        Select Case e.KeyCode
                            Case Keys.Left
                                If .CanMove(MoveDirection.Left) Then .Move(MoveDirection.Left)
                            Case Keys.Right
                                If .CanMove(MoveDirection.Right) Then .Move(MoveDirection.Right)
                            Case Keys.Down
                                If .CanMove(MoveDirection.Down) Then .Move(MoveDirection.Down)
                            Case Keys.Up 'Döndürme'
                                If .CanRotate Then .Rotate()
                            Case Keys.Space 'Döndürme'
                                If .CanRotate Then .Rotate()
                            Case Keys.W  'Döndürme'
                                If .CanRotate Then .Rotate()
                            Case Keys.A
                                If .CanMove(MoveDirection.Left) Then .Move(MoveDirection.Left)
                            Case Keys.D
                                If .CanMove(MoveDirection.Right) Then .Move(MoveDirection.Right)
                            Case Keys.S
                                If .CanMove(MoveDirection.Down) Then .Move(MoveDirection.Down)
                        End Select
                    End With
                End If
            'İşlev Tuşlarının Atanması'
            Case Keys.Enter                     'Yeni Oyun Başlatma Tuşu'
                If Status = GameStatus.Stopped Then
                    StartNewGame()
                ElseIf DialogResult.Yes = MessageBox.Show("Oyunu Sonlandırmak İstiyor musunuz?", "Onayla", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    StartNewGame()
                End If
            Case Keys.T          'Oyunu Duraklatma'
                If Status <> GameStatus.Stopped Then TogglePauseGame()
            Case Keys.Y          'Yeni Oyun Başlatma Tuşu'
                If Status = GameStatus.Stopped Then
                    StartNewGame()
                ElseIf DialogResult.Yes = MessageBox.Show("Oyunu Sonlandırmak İstiyor musunuz?", "Onayla", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    StartNewGame()
                End If
        End Select
    End Sub

    'Duraklatınca Çıkan Uyarı'
    Private Sub MessageLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessageLabel.Click
        Select Case Status
            Case GameStatus.Stopped
                StartNewGame()
            Case GameStatus.Paused
                TogglePauseGame()
        End Select
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If FallingBlock.CanMove(MoveDirection.Down) Then
            FallingBlock.Move(MoveDirection.Down)
        Else
            'Blokların Tabana Sabitlenmesi'
            For Each cell As TetrisCell In FallingBlock.Cells
                cell.IsEmpty = False
            Next

            'Satır Tamamlanınca Silinmesi'
            Dim checkRows = From cell In FallingBlock.Cells
                            Order By cell.Row
                            Select cell.Row Distinct
            Dim rowsRemoved As Integer = 0
            For Each row In checkRows
                If GameBoard.IsRowComplete(row) Then
                    GameBoard.RemoveRow(row)
                    rowsRemoved += 1
                End If
            Next

            'İstatistiklerin Güncellenmesi'
            Score += Math.Pow(rowsRemoved, 2) * 100
            Lines += rowsRemoved
            Speed = 1 + Lines \ 10
            If Speed Mod 10 = 0 Then Level += 1 : Speed = 1
            Timer1.Interval = (10 - Speed) * 75
            UpdateStatistics()

            'Sıradaki Bloğun Çağrılması'
            DropNextFallingBlock()

            'Oyunun Bitişini Kontrol Etme(Tavana Değdiği Zaman)'
            If Not FallingBlock.CanMove(FallingBlock.CenterCell) Then EndGame()
        End If
    End Sub
#End Region
#Region "Private Methods"
    Private Function GetRandomShape() As TetrisBlock.Shapes
        Dim number As Integer = RandomNumbers.Next(Shapes.I1, Shapes.Z4 + 1) 'Listeden aralığın seçilmesi (Baştan Sona)'
        Return CType(number, TetrisBlock.Shapes)
    End Function

    'Önizlenen görüntünün oyuna çağrılması '
    Private Sub DropNextFallingBlock()
        FallingBlock.CenterCell = GameBoard.Cells(2, GameBoard.Columns \ 2)
        FallingBlock.Shape = PreviewBlock.Shape
        PreviewBlock.Shape = GetRandomShape()
        PreviewBlock.RefreshBackGround()
        PreviewBlock.Refresh()
    End Sub
    'Herşey sıfırlanıp yeni oyun başlatılıyor'
    Private Sub StartNewGame()
        Score = 0
        Lines = 0
        Speed = 1
        Level = 1
        Timer1.Interval = 1000
        UpdateStatistics()

        GameBoard.SetupBoard()
        DropNextFallingBlock()
        MessageLabel.Visible = False
        Timer1.Enabled = True
        Status = GameStatus.Running
    End Sub
    'Oyun Sona Erdiğinde Gösterilen Mesaj'
    Private Sub EndGame()
        Timer1.Enabled = False
        Status = GameStatus.Stopped
        ShowMessage(String.Format("{0}{0}Oyun Bitti{0}{0}{0}{0}Yeni Oyuna Başlamak için Tıklayın", vbCrLf))
    End Sub
    'İstatiatikleri güncelliyor'
    Private Sub UpdateStatistics()
        ScoreLabel.Text = Score.ToString("000")
        LinesLabel.Text = Lines.ToString
        LevelLabel.Text = Level.ToString
        SpeedLabel.Text = Speed.ToString
    End Sub

    'Oyunu Duraklatma Geçişi'
    Private Sub TogglePauseGame()
        If Status = GameStatus.Paused Then
            Status = GameStatus.Running
            MessageLabel.Visible = False
            Timer1.Enabled = True
        Else
            Status = GameStatus.Paused
            ShowMessage(String.Format("{0}{0}Oyun Duraklatıldı{0}{0}{0}{0}Devam Etmek İçin Tıklayın", vbCrLf))
        End If
    End Sub
    Private Sub ShowMessage(ByVal message As String)
        MessageLabel.Text = message
        MessageLabel.Visible = True
        Timer1.Enabled = False
    End Sub
End Class
#End Region