Public Class FormMarkAssignUser
    Public id_mark_asg As String = "-1"
    Private Sub FormMarkAssignUser_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Private Sub FormMarkAssignUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT a.id_mark_asg,a.id_report_status,a.report_mark_type,b.report_mark_type_name,c.report_status "
        query += "FROM tb_mark_asg a "
        query += "INNER JOIN tb_lookup_report_mark_type b ON a.report_mark_type=b.report_mark_type "
        query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status=c.id_report_status "
        query += String.Format("WHERE a.id_mark_asg = '{0}'", id_mark_asg)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LReport.Text = data.Rows(0)("report_mark_type_name").ToString()
        LStatus.Text = data.Rows(0)("report_status").ToString()
        '
        view_user()
        re_order()
    End Sub
    Sub view_user()
        Dim query As String = "SELECT a.lead_time,a.id_mark_asg_user,a.id_user,a.level,iF(a.is_head_dept=1,'Head Dept',IF(a.is_asst_head_dept=1,'Asst Head Dept',c.employee_name)) as employee_name "
        query += "FROM tb_mark_asg_user a "
        query += "LEFT JOIN tb_m_user b ON a.id_user=b.id_user "
        query += "LEFT JOIN tb_m_employee c ON c.id_employee=b.id_employee "
        query += "WHERE a.id_mark_asg='" & id_mark_asg & "' "
        query += "ORDER BY a.level"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCUser.DataSource = data
    End Sub

    Private Sub BAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdd.Click
        '
        FormMarkAssignUserSingle.id_mark_asg = id_mark_asg
        FormMarkAssignUserSingle.ShowDialog()
    End Sub

    Private Sub Bdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bdel.Click
        Dim confirm As DialogResult
        Dim query As String
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this user on list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        Dim id_mark_asg_user As String = GVUser.GetFocusedRowCellDisplayText("id_mark_asg_user").ToString
        If confirm = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                query = String.Format("DELETE FROM tb_mark_asg_user WHERE id_mark_asg_user = '{0}'", id_mark_asg_user)
                execute_non_query(query, True, "", "", "", "")
                view_user()
                re_order()
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("This user can't be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Sub re_order()
        Dim query As String = ""
        If GVUser.RowCount > 0 Then
            For i As Integer = 1 To GVUser.RowCount
                'match with sort
                If Not i.ToString = GVUser.GetRowCellValue(i - 1, "level").ToString Then
                    'update
                    query = String.Format("UPDATE tb_mark_asg_user SET level='{0}' WHERE id_mark_asg_user = '{1}'", i.ToString, GVUser.GetRowCellValue(i - 1, "id_mark_asg_user").ToString)
                    execute_non_query(query, True, "", "", "", "")
                End If
            Next
            view_user()
        End If
    End Sub
End Class