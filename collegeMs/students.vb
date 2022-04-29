Imports System.Data.SqlClient
Public Class students
    Dim con = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=D:\VB\collegeMs\db\CollegeVbDb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
    Private Sub FillDepartment()
        con.open()
        Dim query = "select * from DepartmentTbl"
        Dim cmd As New SqlCommand(query, con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        adapter.Fill(Tbl)
        DepCb.DataSource = Tbl
        DepCb.DisplayMember = "DepName"
        DepCb.ValueMember = "DepName"
        con.close()
    End Sub
    Private Sub display()
        con.open()
        Dim query = "select * from StudentTbl"
        Dim adapter As SqlDataAdapter
        Dim cmd = New SqlCommand(query, con)
        adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        StudentDGV.DataSource = ds.Tables(0)
        con.close()
    End Sub
    Private Sub clear()
        StnameTb.Text = ""
        FeesTb.Text = ""
        phoneTb.Text = ""
        GenCb.SelectedIndex = 0
        DepCb.SelectedIndex = 0
    End Sub
    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click
        If StnameTb.Text = "" Or FeesTb.Text = "" Or phoneTb.Text = "" Or GenCb.SelectedIndex = -1 Or DepCb.SelectedIndex = -1 Then
            MsgBox("Missing Information")
        Else
            Try
                con.open()
                Dim query = "insert into StudentTbl Values ('" & StnameTb.Text & "','" & GenCb.SelectedItem.ToString() & "', '" & STDOB.Value.Date & "','" & phoneTb.Text & "','" & DepCb.SelectedValue.ToString() & "','" & FeesTb.Text & "')"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                MsgBox("Student Saved")
                con.close()
                display()
                clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub students_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillDepartment()
        display()
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        Application.Exit()
    End Sub

    Private Sub ResetBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetBtn.Click
        clear()
    End Sub
    Dim key = 0

    Private Sub StudentDGV_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles StudentDGV.CellMouseClick
        Dim row As DataGridViewRow = StudentDGV.Rows(e.RowIndex)
        StnameTb.Text = row.Cells(1).Value.ToString
        GenCb.SelectedItem = row.Cells(2).Value.ToString
        STDOB.Text = row.Cells(3).Value.ToString
        phoneTb.Text = row.Cells(4).Value.ToString
        DepCb.SelectedValue = row.Cells(5).Value.ToString
        FeesTb.Text = row.Cells(6).Value.ToString
        If StnameTb.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub DeleteBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBtn.Click
        If key = 0 Then
            MsgBox("Select The Student")
        Else
            Try
                con.open()
                Dim query = "delete from StudentTbl where StId=" & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                MsgBox("Student Deleted")
                con.close()
                display()
                clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub EditBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditBtn.Click
        If StnameTb.Text = "" Or FeesTb.Text = "" Or phoneTb.Text = "" Or GenCb.SelectedIndex = -1 Or DepCb.SelectedIndex = -1 Then
            MsgBox("Missing Information")
        Else
            Try
                con.open()
                Dim query = "update StudentTbl set StName='" & StnameTb.Text & "',StGend='" & GenCb.SelectedItem.ToString() & "',StDOB='" & STDOB.Text & "', StPhone ='" & phoneTb.Text & "',StDep='" & DepCb.SelectedValue.ToString() & "',StFee=" & FeesTb.Text & "where StId=" & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                MsgBox("Student Updated")
                con.close()
                display()
                clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub NoDuelist()
        con.open()
        Dim query = "select * from StudentTbl where StFee >=  100000"
        Dim adapter As SqlDataAdapter
        Dim cmd = New SqlCommand(query, con)
        adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        StudentDGV.DataSource = ds.Tables(0)
        con.close()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        NoDuelist()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        display()
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