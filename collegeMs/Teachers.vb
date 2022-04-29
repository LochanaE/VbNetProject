Imports System.Data.SqlClient

Public Class Teachers
    Dim con = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=D:\VB\collegeMs\db\CollegeVbDb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
    Private Sub FillDepartment()
        con.open()
        Dim query = "select * from DepartmentTbl"
        Dim cmd As New SqlCommand(query, con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        adapter.Fill(Tbl)
        DepCB.DataSource = Tbl
        DepCB.DisplayMember = "DepName"
        DepCB.ValueMember = "DepName"
        con.close()

    End Sub
    Private Sub display()
        con.open()
        Dim query = "select * from TeacherTbl"
        Dim adapter As SqlDataAdapter
        Dim cmd = New SqlCommand(query, con)
        adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        TeacherDGV.DataSource = ds.Tables(0)
        con.close()
    End Sub
    Private Sub Clear()
        TnameTb.Text = ""
        GenCb.SelectedIndex = 0
        AddTb.Text = ""
        PhoneTb.Text = ""
        DepCB.SelectedIndex = 0

    End Sub
    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click
        If TnameTb.Text = "" Or AddTb.Text = "" Or PhoneTb.Text = "" Or GenCb.SelectedIndex = -1 Or DepCB.SelectedIndex = -1 Then
            MsgBox("Missing Information")
        Else
            Try
                con.open()
                Dim query = "insert into TeacherTbl Values ('" & TnameTb.Text & "','" & GenCb.SelectedItem.ToString() & "','" & TDOB.Value.Date & "','" & PhoneTb.Text & "','" & DepCB.SelectedValue.ToString() & "','" & AddTb.Text & "')"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                MsgBox("Teacher Saved")
                con.close()
                display()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Teachers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        display()
        FillDepartment()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

    Private Sub ResetBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetBtn.Click
        Clear()
    End Sub

    Private Sub DeletBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeletBtn.Click
        If key = 0 Then
            MsgBox("Select The Teacher")
        Else
            Try
                con.open()
                Dim query = "delete from TeacherTbl where TID=" & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                MsgBox("Teacher Deleted")
                con.close()
                display()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Dim key = 0
    Private Sub TeacherDGV_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles TeacherDGV.CellMouseClick
        Dim row As DataGridViewRow = TeacherDGV.Rows(e.RowIndex)
        TnameTb.Text = row.Cells(1).Value.ToString
        GenCb.SelectedItem = row.Cells(2).Value.ToString
        TDOB.Text = row.Cells(3).Value.ToString
        PhoneTb.Text = row.Cells(4).Value.ToString
        DepCB.SelectedValue = row.Cells(5).Value.ToString
        AddTb.Text = row.Cells(6).Value.ToString
        If TnameTb.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub EditBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditBtn.Click
        If TnameTb.Text = "" Or AddTb.Text = "" Or PhoneTb.Text = "" Or GenCb.SelectedIndex = -1 Or DepCB.SelectedIndex = -1 Then
            MsgBox("Missing Information")
        Else
            Try
                con.open()
                Dim query = "update TeacherTbl set TName='" & TnameTb.Text & "',TGender='" & GenCb.SelectedItem.ToString() & "',TDOB='" & TDOB.Text & "',TPhone ='" & PhoneTb.Text & "',TDep='" & DepCB.SelectedValue.ToString() & "',TAdd='" & AddTb.Text & "'where TID=" & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                MsgBox("Teacher Updated")
                con.close()
                display()
                Clear()
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

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click
        Dim Obj = New Dashboard()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
        Dim Obj = New fees()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        Dim Obj = New Departments()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click
        Dim Obj = New students()
        Obj.Show()
        Me.Hide()
    End Sub
End Class