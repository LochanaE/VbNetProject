Public Class Login
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        UnameTb.Text = ""
        PasswordTb.Text = ""

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If UnameTb.Text = "" Or PasswordTb.Text = "" Then
            MsgBox("Enter UseraName or Password")
        ElseIf UnameTb.Text = "admin" And PasswordTb.Text = "123" Then
            Dim Obj = New students
            Obj.Show()
            Me.Hide()
        Else
            MsgBox("Wrong User Name or Password")
            UnameTb.Text = ""
            PasswordTb.Text = ""
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If PasswordTb.UseSystemPasswordChar = False Then
            PasswordTb.UseSystemPasswordChar = True
        Else
            PasswordTb.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub
End Class