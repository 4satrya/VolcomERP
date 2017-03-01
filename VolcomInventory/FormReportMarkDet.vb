Public Class FormReportMarkDet
    Public id_report_mark As String = "-1"

    Private Sub FormReportMarkDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = String.Format("SELECT a.id_user,a.report_mark_note,c.employee_name FROM tb_report_mark a INNER JOIN tb_m_user b ON a.id_user=b.id_user INNER JOIN tb_m_employee c ON b.id_employee=c.id_employee WHERE a.id_report_mark = '{0}'", id_report_mark)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'going to marked
        TEEmployee.Text = data.Rows(0)("employee_name").ToString
        MEComment.Text = data.Rows(0)("report_mark_note").ToString
    End Sub

    Private Sub BAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAccept.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to accept this report ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim query As String = ""
                'update all to 2
                reset_is_use_mark(id_report_mark, "2")
                'set accept or refuse is use to 1
                query = String.Format("UPDATE tb_report_mark SET id_mark='2',is_use='1',report_mark_note='{1}',report_mark_datetime=NOW() WHERE id_report_mark='{0}'", FormReportMark.GVMark.GetFocusedRowCellDisplayText("id_report_mark").ToString, MEComment.Text)
                execute_non_query(query, True, "", "", "", "")
                ' here auto approve
                Dim id_status_reportx As String = FormReportMark.GVMark.GetFocusedRowCellValue("id_report_status").ToString
                Dim query_jml As String = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status = '{2}' AND is_use='1'", FormReportMark.report_mark_type, FormReportMark.id_report, id_status_reportx)
                Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                Dim assigned As Boolean = False
                If jml < 1 Then
                    'no one assigned yet
                    assigned = False
                Else
                    assigned = True
                    query_jml = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status <= '{2}' AND id_mark != '2' AND is_use='1'", FormReportMark.report_mark_type, FormReportMark.id_report, id_status_reportx)
                    jml = execute_query(query_jml, 0, True, "", "", "", "")
                End If
                '
                If (jml < 1 And assigned = True) Then
                    FormReportMark.change_status(id_status_reportx)
                End If
                '
                FormReportMark.view_mark()
                FormReportMark.sendNotif("1")
                FormReportMark.GVMark.FocusedRowHandle = find_row(FormReportMark.GVMark, "id_report_mark", id_report_mark)
                FormReportMark.GVMark.ExpandAllGroups()
                'slow but..
                FormWork.view_mark_need()
                'FormWork.view_mark_history()
                Close()
            Catch ex As Exception
                errorConnection()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BRefuse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefuse.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to refuse this report ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        Dim id_user As String = FormMasterUser.GVUser.GetFocusedRowCellDisplayText("id_user").ToString

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            'Try
            Dim query As String = ""
                'update all to 2
                reset_is_use_mark(id_report_mark, "2")
                'set accept or refuse is use to 1
                query = String.Format("UPDATE tb_report_mark SET id_mark='3',is_use='1',report_mark_note='{1}',report_mark_datetime=NOW() WHERE id_report_mark='{0}'", FormReportMark.GVMark.GetFocusedRowCellDisplayText("id_report_mark").ToString, MEComment.Text)
                execute_non_query(query, True, "", "", "", "")
                FormReportMark.view_mark()
                FormReportMark.sendNotif("2")
                FormReportMark.GVMark.FocusedRowHandle = find_row(FormReportMark.GVMark, "id_report_mark", id_report_mark)
                FormReportMark.GVMark.ExpandAllGroups()
                '...
                FormWork.view_mark_need()
                'cancel dan email nolak
                Dim report_mark_type As String = FormReportMark.GVMark.GetFocusedRowCellDisplayText("report_mark_type").ToString
                Dim id_report As String = FormReportMark.GVMark.GetFocusedRowCellDisplayText("id_report").ToString
                If report_mark_type = "95" Or report_mark_type = "96" Or report_mark_type = "99" Or report_mark_type = "102" Or report_mark_type = "104" Then
                    'set cancel
                    FormReportMark.change_status("6")
                    'mail
                    Dim mail As ClassSendEmail = New ClassSendEmail()
                    mail.report_mark_type = report_mark_type
                    mail.send_email_appr(report_mark_type, id_report, False)
                End If
                Close()
                'Catch ex As Exception
                '    errorConnection(ex.ToString)
                'End Try
                Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormReportMarkDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

End Class