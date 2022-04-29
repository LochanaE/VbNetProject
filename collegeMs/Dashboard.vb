Imports System.Data.SqlClient

Public Class Dashboard
    Dim con = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=D:\VB\collegeMs\db\CollegeVbDb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
    Private Sub CountStud()
        Dim StNum As Integer
        con.open()
        Dim sql = "Select COUNT(*) from StudentTbl"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, con)
        StNum = cmd.ExecuteScalar
        Stdlbl.Text = StNum
        con.close()
    End Sub
    Private Sub CountTeachers()
        Dim TNum As Integer
        con.open()
        Dim sql = "Select COUNT(*) from TeacherTbl"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, con)
        TNum = cmd.ExecuteScalar
        Teacherlbl.Text = TNum
        con.close()
    End Sub
    Private Sub CountDep()
        Dim DepNum As Integer
        con.open()
        Dim sql = "Select COUNT(*) from DepartmentTbl"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, con)
        DepNum = cmd.ExecuteScalar
        Deplbl.Text = DepNum
        con.close()
    End Sub
    Private Sub SumFees()
        Dim FeesAmount As Integer
        con.open()
        Dim sql = "Select Sum(Amount) from PaymentTbl"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, con)
        FeesAmount = cmd.ExecuteScalar
        Dim Am As String
        Am = Convert.ToString(FeesAmount)
        Feeslbl.Text = "Rs" + Am
        con.close()
    End Sub
    Private Sub Dashboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CountStud()
        CountTeachers()
        CountDep()
        SumFees()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        Dim Obj = New Login()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click
        Dim Obj = New Teachers()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        Dim Obj = New students()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
        Dim Obj = New fees()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click
        Dim Obj = New Departments()
        Obj.Show()
        Me.Hide()
    End Sub
End Class