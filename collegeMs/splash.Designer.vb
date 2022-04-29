<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class splash
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(splash))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LoadingBar = New Guna.UI2.WinForms.Guna2ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label1.Location = New System.Drawing.Point(195, 296)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(612, 44)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "COLLEGE MANAGEMENT SYSTEM"
        '
        'LoadingBar
        '
        Me.LoadingBar.BackColor = System.Drawing.Color.Transparent
        Me.LoadingBar.BorderRadius = 5
        Me.LoadingBar.FillColor = System.Drawing.Color.Transparent
        Me.LoadingBar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
        Me.LoadingBar.Location = New System.Drawing.Point(158, 477)
        Me.LoadingBar.Margin = New System.Windows.Forms.Padding(4)
        Me.LoadingBar.Name = "LoadingBar"
        Me.LoadingBar.ProgressColor = System.Drawing.Color.LawnGreen
        Me.LoadingBar.ProgressColor2 = System.Drawing.Color.White
        Me.LoadingBar.ShadowDecoration.Parent = Me.LoadingBar
        Me.LoadingBar.Size = New System.Drawing.Size(677, 11)
        Me.LoadingBar.TabIndex = 2
        Me.LoadingBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        '
        'Timer1
        '
        '
        'splash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(979, 528)
        Me.Controls.Add(Me.LoadingBar)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "splash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LoadingBar As Guna.UI2.WinForms.Guna2ProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
