Imports System.Data.SqlClient
Public Class Departments
    Dim con = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=D:\VB\collegeMs\db\CollegeVbDb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
    Private Sub display()
        con.open()
        Dim query = "select * from departmentTbl"
        Dim adapter As SqlDataAdapter
        Dim cmd = New SqlCommand(query, con)
        adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        DepartmentDGV.datasource = ds.Tables(0)

        con.close()
    End Sub
    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click
        If DepNameTb.Text = "" Or DescTb.Text = "" Or DurationTb.Text = "" Then
            MsgBox("Missing Information")
        Else
            Try
                con.open()
                Dim query = "insert into DepartmentTbl Values ('" & DepNameTb.Text & "','" & DescTb.Text & "', '" & DurationTb.Text & "' )"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                MsgBox("Department Saved")
                con.close()
                display()
                Reset()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End If
    End Sub

    Private Sub Departments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        display()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub
    Private Sub Reset()
        DepNameTb.Text = ""
        DurationTb.Text = ""
        DescTb.Text = ""

    End Sub
    Private Sub ResetBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetBtn.Click
        Reset()
    End Sub

    Private Sub DeleteBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBtn.Click
        If key = 0 Then
            MsgBox("Select The Department")
        Else
            Try
                con.open()
                Dim query = "delete from DepartmentTbl where DepId=" & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                MsgBox("Department Deleted")
                con.close()
                display()
                Reset()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End If
    End Sub
    Dim key = 0
    Private Sub DepartmentDGV_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DepartmentDGV.CellMouseClick
        Dim row As DataGridViewRow = DepartmentDGV.Rows(e.RowIndex)
        DepNameTb.Text = row.Cells(1).Value.ToString
        DescTb.Text = row.Cells(2).Value.ToString
        DurationTb.Text = row.Cells(3).Value.ToString
        If DepNameTb.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If

    End Sub

    Private Sub EditBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditBtn.Click
        If DepNameTb.Text = "" Or DescTb.Text = "" Or DurationTb.Text = "" Then
            MsgBox("Missing Information")
        Else
            Try
                con.open()
                Dim query = "update DepartmentTbl set DepName='" & DepNameTb.Text & "',DepDesc='" & DescTb.Text & "',DepDur=" & DurationTb.Text & "where DepId=" & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                MsgBox("Department Updated")
                con.close()
                display()
                Reset()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End If
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
        Dim Obj = New Dashboard()
        Obj.Show()
        Me.Hide()
    End Sub
End Class