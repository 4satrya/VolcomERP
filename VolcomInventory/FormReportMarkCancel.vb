Public Class FormReportMarkCancel
    Public id_report_mark_cancel As String = "-1"
    Public id_report_mark_cancel_user As String = "-1"
    '
    Public is_view As String = "2"
    Public id_report_mark As String = "-1"
    Public id_report_status As String = "-1"
    Public is_complete As String = "-1"
    '
    Private Sub FormReportMarkCancel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        act_load()
    End Sub
    '
    Sub load_report_mark_type()
        Dim query As String = "SELECT report_mark_type,report_mark_type_name FROM `tb_lookup_report_mark_type` WHERE is_able_cancel='1'"
        viewLookupQuery(LEReportMarkType, query, 0, "report_mark_type_name", "report_mark_type")
    End Sub

    Sub act_load()
        load_report_mark_type()
        If is_view = "1" Then
            Dim query As String = "SELECT rmc.*,emp.employee_name FROM tb_report_mark_cancel rmc 
                                            LEFT JOIN tb_m_user usr ON usr.id_user=rmc.created_by
                                            LEFT JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee 
                                            WHERE rmc.id_report_mark_cancel='" & id_report_mark_cancel & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TECancelBy.Text = data.Rows(0)("employee_name").ToString
                TENumber.Text = data.Rows(0)("number").ToString
                DEDateProposed.EditValue = data.Rows(0)("created_datetime")
                MEReason.Text = data.Rows(0)("reason").ToString
                LEReportMarkType.ItemIndex = LEReportMarkType.Properties.GetDataSourceRowIndex("report_mark_type", data.Rows(0)("report_mark_type").ToString)
                LEReportMarkType.Enabled = False
                '
                PCAddDel.Visible = False
                BAddColumn.Visible = False
                BUpdateValue.Visible = False
                MEReason.Enabled = False
                '
                load_det()
                '
                BSubmit.Text = "Mark"
            End If

        Else
            'not view
            If id_report_mark_cancel = "-1" Then 'new
                DEDateProposed.EditValue = Now
                PCAttachment.Visible = False
                BSubmit.Text = "Save"
                BViewApproval.Visible = False
                BAddColumn.Visible = False
                BUpdateValue.Visible = False
            Else 'edit
                Dim query_view As String = "SELECT rmc.*,emp.`employee_name` FROM tb_report_mark_cancel rmc
                                            INNER JOIN tb_m_user usr ON usr.`id_user`=rmc.`created_by`
                                            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
                                            WHERE rmc.id_report_mark_cancel='" & id_report_mark_cancel & "'"
                Dim data_view As DataTable = execute_query(query_view, -1, True, "", "", "", "")
                '
                TECancelBy.Text = data_view.Rows(0)("employee_name").ToString
                TENumber.Text = data_view.Rows(0)("id_report_mark_cancel").ToString
                DEDateProposed.EditValue = data_view.Rows(0)("created_datetime")
                MEReason.Text = data_view.Rows(0)("reason").ToString
                LEReportMarkType.ItemIndex = LEReportMarkType.Properties.GetDataSourceRowIndex("report_mark_type", data_view.Rows(0)("report_mark_type").ToString)
                '
                PCAttachment.Visible = True
                LEReportMarkType.Enabled = False

                MEReason.Enabled = False
                '
                load_det()
                '
                PCAddDel.Visible = False

                If data_view(0)("is_submit").ToString = "1" Then
                    BViewApproval.Visible = True
                    PCSubmit.Visible = False
                    PCPrint.Visible = True
                    BPrint.Text = "Print"
                    '
                    is_view = "1"
                    BAddColumn.Visible = False
                    BUpdateValue.Visible = False
                Else
                    BViewApproval.Visible = True
                    PCSubmit.Visible = True
                    PCPrint.Visible = True
                    BSubmit.Text = "Submit"
                    BPrint.Text = "Print Preview"
                    '
                    BAddColumn.Visible = True
                    BUpdateValue.Visible = True
                End If
            End If
        End If
        '
        If is_complete = "1" Then
            Dim query_comp As String = "SELECT * FROM tb_doc WHERE id_user_upload='" & id_user & "' AND report_mark_type='142' AND id_report='" & id_report_mark_cancel & "'"
            Dim data_comp As DataTable = execute_query(query_comp, -1, True, "", "", "", "")
            If data_comp.Rows.Count > 0 Then
                PCSubmit.Visible = True
                BSubmit.Text = "Complete"
            Else
                PCSubmit.Visible = False
            End If
            BViewApproval.Visible = True
        End If
        '
        but_show()
    End Sub
    Sub load_det()
        Dim qb As New ClassShowPopUp()
        qb.is_qb = "1"
        qb.id_report_mark_cancel = id_report_mark_cancel
        qb.report_mark_type = LEReportMarkType.EditValue.ToString
        qb.load_detail()
        Dim data As DataTable = execute_query(qb.query_view_edit, -1, True, "", "", "", "")
        GVReportList.Columns.Clear()
        GCReportList.DataSource = data
        qb.apply_gv_style(GVReportList, "-1")
    End Sub

    Sub but_show()
        If is_view = "1" Or Not id_report_mark_cancel = "-1" Then
            PCAddDel.Visible = False
        Else
            PCAddDel.Visible = True
            If GVReportList.RowCount > 0 Then
                BDelete.Visible = True
            Else
                BDelete.Visible = False
            End If
        End If
    End Sub

    Private Sub FormReportMarkCancel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BAttachment_Click(sender As Object, e As EventArgs) Handles BAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_report_mark_cancel
        If is_view = "1" Then
            FormDocumentUpload.is_no_delete = "1"
        End If
        FormDocumentUpload.report_mark_type = "142"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BApprove_Click(sender As Object, e As EventArgs) Handles BSubmit.Click
        Cursor = Cursors.WaitCursor
        If BSubmit.Text = "Save" Then 'new
            If GVReportList.RowCount > 0 Then
                Dim query As String = "INSERT INTO tb_report_mark_cancel(created_by,created_datetime,reason,report_mark_type) VALUES('" & id_user & "',NOW(),'" & addSlashes(MEReason.Text) & "','" & LEReportMarkType.EditValue.ToString & "');SELECT LAST_INSERT_ID() "
                id_report_mark_cancel = execute_query(query, 0, True, "", "", "", "")

                query = "CALL gen_number('" & id_report_mark_cancel & "','142')"
                execute_non_query(query, True, "", "", "", "")

                Dim query_det As String = "INSERT INTO tb_report_mark_cancel_report(id_report_mark_cancel,id_report) VALUES"
                For i As Integer = 0 To GVReportList.RowCount - 1
                    If Not i = 0 Then
                        query_det += ","
                    End If
                    query_det += "('" & id_report_mark_cancel & "','" & GVReportList.GetRowCellValue(i, "id_report").ToString & "')"
                Next
                execute_non_query(query_det, True, "", "", "", "")
                FormReportMarkCancelList.load_cancel_form()
                infoCustom("Cancel detail saved, proceed to uploading supporting document")
                act_load()
            Else
                warningCustom("Please select the report first")
            End If
        ElseIf BSubmit.Text = "Submit" Then
            'check attachment sudah apa belum
            Dim query_cek As String = "SELECT * FROM tb_doc WHERE report_mark_type='142' AND id_report='" & id_report_mark_cancel & "'"
            Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
            If data_cek.Rows.Count > 0 Then
                Dim query As String = "UPDATE tb_report_mark_cancel SET reason='" & addSlashes(MEReason.Text) & "',is_submit='1' WHERE id_report_mark_cancel='" & id_report_mark_cancel & "'"
                execute_non_query(query, True, "", "", "", "")
                '
                submit_cancel_approval("142", LEReportMarkType.EditValue.ToString, id_report_mark_cancel, id_user)
                '
                infoCustom("Cancel document proposed")
                Close()
            Else
                warningCustom("Please attach supporting document first")
            End If
        ElseIf BSubmit.Text = "Mark" Then
            'Dim confirm As DialogResult
            'confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to approve ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            'If confirm = Windows.Forms.DialogResult.Yes Then
            '    FormReportMarkDet.id_report_mark = id_report_mark
            '    FormReportMarkDet.accept("outside")
            'End If
            FormReportMark.id_report = id_report_mark_cancel
            FormReportMark.report_mark_type = "142"
            FormReportMark.is_view = "1"
            FormReportMark.ShowDialog()
        ElseIf BSubmit.Text = "Complete" Then
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to complete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim frm As New FormReportMark
                frm.id_report = id_report_mark_cancel
                frm.report_mark_type = "142"
                frm.change_status("6")
                FormWork.view_cancel_list()
                Close()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LEReportMarkType_EditValueChanged(sender As Object, e As EventArgs) Handles LEReportMarkType.EditValueChanged
        Try
            GVReportList.Columns.Clear()
            Dim qb As New ClassShowPopUp()
            qb.is_qb = "1"
            qb.report_mark_type = LEReportMarkType.EditValue.ToString
            qb.load_detail()
            Dim data As DataTable

            If id_report_mark_cancel_user = "-1" Then
                data = execute_query(qb.query_view_blank, -1, True, "", "", "", "")
            Else
                data = execute_query(qb.query_view_edit, -1, True, "", "", "", "")
            End If

            GCReportList.DataSource = data
            qb.apply_gv_style(GVReportList, "-1")
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        GVReportList.DeleteSelectedRows()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        Dim id_already As String = ""
        If GVReportList.RowCount > 0 Then
            id_already = "("
            For i As Integer = 0 To GVReportList.RowCount - 1
                If Not i = 0 Then
                    id_already += ","
                End If
                id_already += GVReportList.GetRowCellValue(i, "id_report").ToString
            Next
            id_already += ")"
        End If
        FormReportMarkCancelPick.id_already = id_already
        FormReportMarkCancelPick.ShowDialog()
    End Sub

    Private Sub SMViewDet_Click(sender As Object, e As EventArgs) Handles SMViewDet.Click
        If GVReportList.RowCount > 0 Then
            Dim sp As New ClassShowPopUp()
            sp.id_report = GVReportList.GetFocusedRowCellValue("id_report").ToString
            sp.report_mark_type = LEReportMarkType.EditValue.ToString
            sp.show()
        End If
    End Sub

    Private Sub BViewApproval_Click(sender As Object, e As EventArgs) Handles BViewApproval.Click
        FormReportMark.is_view = "1"
        FormReportMark.id_report = id_report_mark_cancel
        FormReportMark.report_mark_type = "142"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        'print(GCBOM, "Bill Of Material - " & TEDesign.Text & " - " & TEDesignCode.Text)
        '... 
        ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVReportList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        ReportCancelForm.id_report_mark_cancel = id_report_mark_cancel
        ReportCancelForm.dt = GCReportList.DataSource

        Dim Report As New ReportCancelForm()

        Dim query As String = "SELECT '" & LEReportMarkType.Text & "' AS report_mark_type_name,'" & MEReason.Text & "' AS reason"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Report.DataSource = data

        Report.GVReportList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        If Not BPrint.Text = "Print" Then
            MsgBox("a")
            Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.Print, DevExpress.XtraPrinting.CommandVisibility.None)
            Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect, DevExpress.XtraPrinting.CommandVisibility.None)
            Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.PrintSelection, DevExpress.XtraPrinting.CommandVisibility.None)
        End If
        Tool.ShowPreview()
    End Sub

    Private Sub BAddColumn_Click(sender As Object, e As EventArgs) Handles BAddColumn.Click
        FormReportMarkCancelColumn.id_report_cancel = id_report_mark_cancel
        FormReportMarkCancelColumn.ShowDialog()
    End Sub

    Private Sub BUpdateValue_Click(sender As Object, e As EventArgs) Handles BUpdateValue.Click
        Dim query_upd As String = ""
        Dim det_upd As String = ""
        Dim query_col As String = ""
        Dim data_col As DataTable
        'delete
        query_upd = "DELETE tb_report_mark_cancel_column_val FROM tb_report_mark_cancel_column_val 
INNER JOIN tb_report_mark_cancel_column  ON tb_report_mark_cancel_column.id_column=tb_report_mark_cancel_column_val.id_column WHERE tb_report_mark_cancel_column.id_report_mark_cancel='" & id_report_mark_cancel & "'"
        execute_non_query(query_upd, True, "", "", "", "")
        'insert
        query_col = "SELECT id_column,column_name FROM tb_report_mark_cancel_column WHERE id_report_mark_cancel='" & id_report_mark_cancel & "'"
        data_col = execute_query(query_col, -1, True, "", "", "", "")
        '
        If data_col.Rows.Count > 0 Then
            query_upd = "INSERT INTO tb_report_mark_cancel_column_val(id_column,id_report_mark_cancel_report,val) VALUES"
            For i As Integer = 0 To GVReportList.RowCount - 1
                For j As Integer = 0 To data_col.Rows.Count - 1
                    If Not det_upd = "" Then
                        det_upd += ","
                    End If
                    det_upd += "('" & data_col.Rows(j)("id_column").ToString & "','" & GVReportList.GetRowCellValue(i, "id_rmcr").ToString & "','" & addSlashes(GVReportList.GetRowCellValue(i, data_col.Rows(j)("column_name").ToString)) & "')"
                Next
            Next
            execute_non_query(query_upd & det_upd, True, "", "", "", "")
            load_det()
        Else
            warningCustom("No additional column.")
        End If
    End Sub
End Class