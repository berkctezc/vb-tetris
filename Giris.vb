Public Class Giris
    Private Sub Giris_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Programın sessiz açılmasına yarayan satır.'
        Non.Checked = True
    End Sub
    Private Sub Oyna_Click(sender As Object, e As EventArgs) Handles Oyna.Click
        'Oyna Labelina basıldığında giriş ekranı gizlenip Tetris oyunun olduğu Form açılıyor.'
        Me.Hide()
        TetrisGame.Show()
    End Sub
    Private Sub Çıkış_Click(sender As Object, e As EventArgs) Handles Çıkış.Click
        Close()
    End Sub
    Private Sub Hakkında_Click(sender As Object, e As EventArgs) Handles Hakkında.Click
        'AboutBoxu açan kod satırı'
        Bilgi.Show()
    End Sub
    Private Sub Non_CheckedChanged(sender As Object, e As EventArgs) Handles Non.CheckedChanged
        'Sessiz seçeneği'
        My.Computer.Audio.Stop()
    End Sub

    'Resources'e eklediğimiz ses dosyalarını çalıştırıyoruz.'
    Private Sub A_CheckedChanged(sender As Object, e As EventArgs) Handles A.CheckedChanged
        My.Computer.Audio.Play(My.Resources.ThemeA, AudioPlayMode.BackgroundLoop)
    End Sub
    Private Sub B_CheckedChanged(sender As Object, e As EventArgs) Handles B.CheckedChanged
        My.Computer.Audio.Play(My.Resources.ThemeB, AudioPlayMode.BackgroundLoop)
    End Sub
    Private Sub C_CheckedChanged(sender As Object, e As EventArgs) Handles C.CheckedChanged
        My.Computer.Audio.Play(My.Resources.ThemeC, AudioPlayMode.BackgroundLoop)
    End Sub
End Class