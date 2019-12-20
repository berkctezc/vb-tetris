<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Giris
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Giris))
        Me.Hakkında = New System.Windows.Forms.Label()
        Me.Oyna = New System.Windows.Forms.Label()
        Me.Çıkış = New System.Windows.Forms.Label()
        Me.Non = New System.Windows.Forms.RadioButton()
        Me.C = New System.Windows.Forms.RadioButton()
        Me.B = New System.Windows.Forms.RadioButton()
        Me.A = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Hakkında
        '
        Me.Hakkında.BackColor = System.Drawing.Color.Transparent
        Me.Hakkında.Font = New System.Drawing.Font("A-Space Demo", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Hakkında.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Hakkında.Location = New System.Drawing.Point(227, 206)
        Me.Hakkında.Name = "Hakkında"
        Me.Hakkında.Size = New System.Drawing.Size(59, 50)
        Me.Hakkında.TabIndex = 8
        Me.Hakkında.Text = "BİLGİ"
        Me.Hakkında.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Oyna
        '
        Me.Oyna.BackColor = System.Drawing.Color.Transparent
        Me.Oyna.Font = New System.Drawing.Font("A-Space Demo", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Oyna.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Oyna.Location = New System.Drawing.Point(148, 206)
        Me.Oyna.Name = "Oyna"
        Me.Oyna.Size = New System.Drawing.Size(59, 50)
        Me.Oyna.TabIndex = 7
        Me.Oyna.Text = "OYNA"
        Me.Oyna.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Çıkış
        '
        Me.Çıkış.BackColor = System.Drawing.Color.Transparent
        Me.Çıkış.Font = New System.Drawing.Font("A-Space Demo", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Çıkış.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Çıkış.Location = New System.Drawing.Point(302, 206)
        Me.Çıkış.Name = "Çıkış"
        Me.Çıkış.Size = New System.Drawing.Size(59, 50)
        Me.Çıkış.TabIndex = 14
        Me.Çıkış.Text = "ÇIKIŞ"
        Me.Çıkış.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Non
        '
        Me.Non.AutoSize = True
        Me.Non.BackColor = System.Drawing.Color.Transparent
        Me.Non.Checked = True
        Me.Non.Font = New System.Drawing.Font("A-Space Demo", 8.25!)
        Me.Non.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Non.Location = New System.Drawing.Point(409, 81)
        Me.Non.Name = "Non"
        Me.Non.Size = New System.Drawing.Size(95, 16)
        Me.Non.TabIndex = 62
        Me.Non.TabStop = True
        Me.Non.Text = "No Theme"
        Me.Non.UseVisualStyleBackColor = False
        '
        'C
        '
        Me.C.AutoSize = True
        Me.C.BackColor = System.Drawing.Color.Transparent
        Me.C.Font = New System.Drawing.Font("A-Space Demo", 8.25!)
        Me.C.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.C.Location = New System.Drawing.Point(410, 60)
        Me.C.Name = "C"
        Me.C.Size = New System.Drawing.Size(86, 16)
        Me.C.TabIndex = 61
        Me.C.Text = "Theme C"
        Me.C.UseVisualStyleBackColor = False
        '
        'B
        '
        Me.B.AutoSize = True
        Me.B.BackColor = System.Drawing.Color.Transparent
        Me.B.Font = New System.Drawing.Font("A-Space Demo", 8.25!)
        Me.B.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.B.Location = New System.Drawing.Point(409, 39)
        Me.B.Name = "B"
        Me.B.Size = New System.Drawing.Size(86, 16)
        Me.B.TabIndex = 59
        Me.B.Text = "Theme B"
        Me.B.UseVisualStyleBackColor = False
        '
        'A
        '
        Me.A.AutoSize = True
        Me.A.BackColor = System.Drawing.Color.Transparent
        Me.A.Font = New System.Drawing.Font("A-Space Demo", 8.25!)
        Me.A.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.A.Location = New System.Drawing.Point(409, 16)
        Me.A.Name = "A"
        Me.A.Size = New System.Drawing.Size(86, 16)
        Me.A.TabIndex = 58
        Me.A.Text = "Theme A"
        Me.A.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkViolet
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label7.Location = New System.Drawing.Point(343, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 46)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "🎵"
        '
        'Giris
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(507, 288)
        Me.Controls.Add(Me.Non)
        Me.Controls.Add(Me.C)
        Me.Controls.Add(Me.B)
        Me.Controls.Add(Me.A)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Çıkış)
        Me.Controls.Add(Me.Hakkında)
        Me.Controls.Add(Me.Oyna)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Giris"
        Me.Text = "Tetris'e Hoşgeldiniz"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Hakkında As Label
    Friend WithEvents Oyna As Label
    Friend WithEvents Çıkış As Label
    Friend WithEvents Non As RadioButton
    Friend WithEvents C As RadioButton
    Friend WithEvents B As RadioButton
    Friend WithEvents A As RadioButton
    Friend WithEvents Label7 As Label
End Class
