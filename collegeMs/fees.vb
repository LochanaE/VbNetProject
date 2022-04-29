Imports System.Data.SqlClient

Public Class fees
    Dim con = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=D:\VB\collegeMs\db\CollegeVbDb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
    Private Sub FillStudents()
        con.open()
        Dim query = "select * from StudentTbl"
        Dim cmd As New SqlCommand(query, con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        adapter.Fill(Tbl)
        StidCb.DataSource = Tbl
        StidCb.DisplayMember = "StID"
        StidCb.ValueMember = "StID"
        con.close()
    End Sub
    Private Sub display()
        con.open()
        Dim query = "select * from PaymentTbl"
        Dim adapter As SqlDataAdapter
        Dim cmd = New SqlCommand(query, con)
        adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        FeesDGV.DataSource = ds.Tables(0)
        con.close()
    End Sub
    Private Sub clear()
        AmountTb.Text = ""
        StNameTb.Text = ""
        StidCb.SelectedIndex = -1
    End Sub
    Private Sub UpdateStudent()
        Try
            con.open()
            Dim query = "update StudentTbl set StFee=" & AmountTb.Text & "where StId=" & StidCb.SelectedValue.ToString() & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Student Updated")
            con.close()
            'display()
            'clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PayBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayBtn.Click
        If StNameTb.Text = "" Or AmountTb.Text = "" Then
            MsgBox("Missing Information")
        ElseIf Convert.ToInt32(AmountTb.Text) > 100000 Or Convert.ToInt32(AmountTb.Text) < 1 Then
            MsgBox("Worng Amount")
        Else
            Try
                con.open()
                Dim query = "insert into PaymentTbl Values (" & StidCb.SelectedValue.ToString & ",'" & StNameTb.Text & "','" & Period.Value.Date.Year.ToString() & "'," & AmountTb.Text & ")"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                MsgBox("Payment Successfull")
                con.close()
                display()
                UpdateStudent()
                clear()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End If
    End Sub
    Private Sub GetStName()
        con.open()
        Dim query = "Select * from StudentTbl where StID= " & StidCb.SelectedValue.ToString() & ""
        Dim cmd As New SqlCommand(query, con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            StNameTb.Text = reader(1).ToString()
        End While
        con.close()
    End Sub
    Private Sub fees_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        display()
        FillStudents()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

    Private Sub StidCb_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StidCb.SelectionChangeCommitted
        GetStName()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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
        Dim Obj = New Departments()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
        Dim Obj = New students()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click
        Dim Obj = New Dashboard()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub StidCb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StidCb.SelectedIndexChanged

    End Sub
End Class