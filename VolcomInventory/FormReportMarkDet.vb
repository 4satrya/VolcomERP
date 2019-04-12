Public Class FormReportMarkDet
    Public id_report_mark As String = "-1"
    Dim report_mark_type As String = "-1"
    Dim id_report As String = "-1"
    Dim id_report_status As String = "-1"
    '
    Dim is_need_upload As String = "2"

    Private Sub FormReportMarkDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
        Dim query As String = String.Format("SELECT a.id_user,a.report_mark_note,c.employee_name,a.is_need_upload,a.id_report,a.report_mark_type FROM tb_report_mark a INNER JOIN tb_m_user b ON a.id_user=b.id_user INNER JOIN tb_m_employee c ON b.id_employee=c.id_employee WHERE a.id_report_mark = '{0}'", id_report_mark)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'going to marked
        TEEmployee.Text = data.Rows(0)("employee_name").ToString
        MEComment.Text = data.Rows(0)("report_mark_note").ToString
        is_need_upload = data.Rows(0)("is_need_upload").ToString
        id_report = data.Rows(0)("id_report").ToString
        report_mark_type = data.Rows(0)("report_mark_type").ToString
        '
        If is_need_upload = "1" Then
            Dim query_upd As String = "SELECT * FROM tb_doc WHERE id_report='" & id_report & "' AND report_mark_type='" & report_mark_type & "' AND id_user_upload='" & id_user & "'"
            Dim data_upd As DataTable = execute_query(query_upd, -1, True, "", "", "", "")
            If Not data_upd.Rows.Count > 0 Then
                BAccept.Text = "Upload"
            Else
                BAccept.Text = "Approve"
            End If
        End If
    End Sub

    Sub updateMarkSingle(ByVal id_mark_var As String)
        'for deliverycombine
        If FormReportMark.report_mark_type = "103" Then
            'combine delivery
            Dim id_user_combine_app As String = FormReportMark.GVMark.GetFocusedRowCellValue("id_user").ToString
            Dim query_get_app_single As String = "SELECT rm.id_report_mark, rm.id_mark_asg, rm.id_report FROM tb_report_mark rm
            INNER JOIN tb_pl_sales_order_del del ON del.id_pl_sales_order_del = rm.id_report AND del.id_combine=" + FormReportMark.id_report + " 
            WHERE rm.id_user=" + id_user_combine_app + " AND rm.id_report_status=" + id_report_status + " AND rm.report_mark_type=43 "
            Dim data As DataTable = execute_query(query_get_app_single, -1, True, "", "", "", "")
            Dim rm As String = ""
            Dim asg As String = ""
            For i As Integer = 0 To data.Rows.Count - 1
                If i > 0 Then
                    rm += "OR "
                    asg += "OR "
                End If
                rm += "id_report_mark=" + data.Rows(i)("id_report_mark").ToString + " "
                asg += "(id_mark_asg=" + data.Rows(i)("id_mark_asg").ToString + " AND id_report=" + data.Rows(i)("id_report").ToString + ") "
            Next
            If rm <> "" Then
                'update all to 2
                Dim query_upd_single As String = String.Format("UPDATE tb_report_mark Set is_use='2' WHERE (" + asg + ") ;UPDATE tb_report_mark Set id_mark='{0}',is_use='1',report_mark_note='{1}',report_mark_datetime=NOW() WHERE (" + rm + ") ", id_mark_var, addSlashes(MEComment.Text))
                execute_non_query(query_upd_single, True, "", "", "", "")
            End If
        End If
    End Sub


    Private Sub BAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAccept.Click
        Cursor = Cursors.WaitCursor
        If BAccept.Text = "Upload" Then
            FormDocumentUpload.id_report = id_report
            FormDocumentUpload.report_mark_type = report_mark_type
            FormDocumentUpload.is_no_delete = "1"
            FormDocumentUpload.form_orign = Name
            FormDocumentUpload.ShowDialog()
        Else
            accept("form")
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub accept(ByVal opt As String)
        Try
            Dim query As String = ""
            'update all to 2
            reset_is_use_mark(id_report_mark, "2")
            'set accept or refuse is use to 1
            Dim comment As String = ""
            If opt = "form" Then
                id_report_mark = FormReportMark.GVMark.GetFocusedRowCellDisplayText("id_report_mark").ToString
                comment = addSlashes(MEComment.Text)
                report_mark_type = FormReportMark.report_mark_type
                id_report = FormReportMark.id_report
                id_report_status = FormReportMark.GVMark.GetFocusedRowCellValue("id_report_status").ToString
            ElseIf opt = "outside" Then
                Dim query_view As String = "SELECT id_report,id_report_status,report_mark_type FROM tb_report_mark WHERE id_report_mark='" & id_report_mark & "'"
                Dim data_view As DataTable = execute_query(query_view, -1, True, "", "", "", "")
                If data_view.Rows.Count > 0 Then
                    report_mark_type = data_view.Rows(0)("report_mark_type").ToString
                    id_report = data_view.Rows(0)("id_report").ToString
                    id_report_status = data_view.Rows(0)("id_report_status").ToString
                End If
            End If

            query = String.Format("UPDATE tb_report_mark SET id_mark='2',is_use='1',report_mark_note='{1}',report_mark_datetime=NOW() WHERE id_report_mark='{0}'", id_report_mark, comment)
            execute_non_query(query, True, "", "", "", "")
            updateMarkSingle(2)
            ' here auto approve
            Dim query_jml As String = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status = '{2}' AND is_use='1'", report_mark_type, id_report, id_report_status)
            Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
            Dim assigned As Boolean = False
            If jml < 1 Then
                'no one assigned yet
                assigned = False
            Else
                assigned = True
                query_jml = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status <= '{2}' AND id_mark != '2' AND is_use='1'", report_mark_type, FormReportMark.id_report, id_report_status)
                jml = execute_query(query_jml, 0, True, "", "", "", "")
            End If
            '
            If (jml < 1 And assigned = True) Then
                FormReportMark.id_report = id_report
                FormReportMark.report_mark_type = report_mark_type
                FormReportMark.change_status(id_report_status)
            End If
            '
            If opt = "form" Then
                FormReportMark.view_mark()
                FormReportMark.sendNotif("1")
                FormReportMark.GVMark.FocusedRowHandle = find_row(FormReportMark.GVMark, "id_report_mark", id_report_mark)
                FormReportMark.GVMark.ExpandAllGroups()
            End If

            'slow but..
            If is_auto_load_workplace = "1" Then
                FormWork.view_mark_need()
            End If

            'FormWork.view_mark_history()
            '
            close_form(report_mark_type)
            FormReportMark.Close()
            Close()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Sub close_form(ByVal report_mark_typex)
        Try
            Dim popup As ClassShowPopUp = New ClassShowPopUp()
            popup.report_mark_type = report_mark_typex
            popup.close()
        Catch ex As Exception
        End Try
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
            query = String.Format("UPDATE tb_report_mark SET id_mark='3',is_use='1',report_mark_note='{1}',report_mark_datetime=NOW() WHERE id_report_mark='{0}'", FormReportMark.GVMark.GetFocusedRowCellDisplayText("id_report_mark").ToString, addSlashes(MEComment.Text))
            execute_non_query(query, True, "", "", "", "")
            updateMarkSingle(3)
            FormReportMark.view_mark()
            FormReportMark.GVMark.FocusedRowHandle = find_row(FormReportMark.GVMark, "id_report_mark", id_report_mark)
            FormReportMark.GVMark.ExpandAllGroups()
            '...
            FormWork.view_mark_need()
            'cancel dan email nolak
            Dim report_mark_type As String = FormReportMark.GVMark.GetFocusedRowCellDisplayText("report_mark_type").ToString
            Dim id_report As String = FormReportMark.GVMark.GetFocusedRowCellDisplayText("id_report").ToString
            If report_mark_type = "95" Or report_mark_type = "96" Or report_mark_type = "99" Or report_mark_type = "102" Or report_mark_type = "104" Or report_mark_type = "108" Or report_mark_type = "109" Or report_mark_type = "110" Or report_mark_type = "124" Then
                'set cancel
                FormReportMark.report_mark_type = report_mark_type
                FormReportMark.id_report = id_report
                FormReportMark.change_status("5")
                'mail
                Dim mail As ClassSendEmail = New ClassSendEmail()
                mail.report_mark_type = report_mark_type
                mail.send_email_appr(report_mark_type, id_report, False)
            ElseIf report_mark_type = "130" Then
                'uniform
                Dim qupd As String = "UPDATE tb_sales_order set is_selected=2 WHERE id_sales_order=" + id_report + " "
                execute_non_query(qupd, True, "", "", "", "")

                'delete all mark
                Dim qm As String = "DELETE FROM tb_report_mark WHERE id_report=" + id_report + " AND report_mark_type=" + report_mark_type + " "
                execute_non_query(qm, True, "", "", "", "")
            ElseIf report_mark_type = "134" Or report_mark_type = "135" Then
                'set cancel item cat & mapping
                FormReportMark.report_mark_type = report_mark_type
                FormReportMark.id_report = id_report
                FormReportMark.change_status("5")
            ElseIf report_mark_type = "160" Then
                'cancell asset
                Dim a As New ClassPurcAsset()
                a.cancellPropose(id_report, FormPurcAssetDet.id_purc_rec)
            End If
            FormReportMark.sendNotif("2")
            close_form(FormReportMark.report_mark_type)
            FormReportMark.Close()
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

    Private Sub BAttachment_Click(sender As Object, e As EventArgs) Handles BAttachment.Click
        FormDocumentUpload.id_report = id_report
        FormDocumentUpload.report_mark_type = report_mark_type
        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.form_orign = Name
        If Not is_need_upload = "1" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
    End Sub
End Class