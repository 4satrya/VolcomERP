Public Class FormChangeStatus
    Public id_pop_up As String = "-1"
    Public id_current As String = ""
    '1 = Finalize WH- Rec Prod
    '2 = Finalize WH- DO
    '3 = RETURN
    '4 = RETURN QC
    '5 = TRF

    Sub viewReportStatus()
        Dim query As String = "SELECT id_report_status, report_status FROM tb_lookup_report_status WHERE id_report_status=5 OR id_report_status=6 ORDER BY id_report_status DESC "
        viewSearchLookupQuery(SLEStatusRec, query, "id_report_status", "report_status", "id_report_status")
    End Sub

    Private Sub FormChangeStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
    End Sub

    Private Sub BtnUpdateRec_Click(sender As Object, e As EventArgs) Handles BtnUpdateRec.Click
        'var
        Dim report_mark_type As String = ""
        Dim assigned As Boolean = True
        Dim note As String = MEComment.Text
        Dim id_status_reportx As String = SLEStatusRec.EditValue.ToString
        Dim gv As DevExpress.XtraGrid.Views.Grid.GridView
        Dim id As String = ""
        'completed or processed
        If id_pop_up = "1" Then 'rec
            report_mark_type = "37"
            gv = FormSalesOrderSvcLevel.GVPL
            id = "id_pl_prod_order_rec"
        ElseIf id_pop_up = "2" Then 'DO
            report_mark_type = "43"
            gv = FormSalesOrderSvcLevel.GVSalesDelOrder
            id = "id_pl_sales_order_del"
        ElseIf id_pop_up = "3" Then 'RETURN
            report_mark_type = "46"
            gv = FormSalesOrderSvcLevel.GVSalesReturn
            id = "id_sales_return"
        ElseIf id_pop_up = "4" Then 'RETURN QC
            report_mark_type = "49"
            gv = FormSalesOrderSvcLevel.GVSalesReturnQC
            id = "id_sales_return_qc"
        ElseIf id_pop_up = "5" Then 'TRF
            report_mark_type = "57"
            gv = FormSalesOrderSvcLevel.GVFGTrf
            id = "id_fg_trf"
        Else
            gv = Nothing
        End If

        For c As Integer = 0 To ((gv.RowCount - 1) - GetGroupRowCount(gv))
            Dim id_report As String = gv.GetRowCellValue(c, id).ToString
            Dim query_jml As String = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status <= '3' AND id_mark != '2' AND is_use='1'", report_mark_type, id_report)
            Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
            If jml >= 1 Then
                assigned = False
            End If
        Next

        If (assigned = True) Or id_status_reportx = "5" Then
            If id_pop_up = "1" Then
                Dim check_stt As Boolean = False
                For c As Integer = 0 To ((FormSalesOrderSvcLevel.GVPL.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVPL))
                    Dim rs As String = FormSalesOrderSvcLevel.GVPL.GetRowCellValue(c, "id_report_status").ToString
                    If rs = "5" Or rs = "6" Then
                        check_stt = True
                        Exit For
                    End If
                Next

                If check_stt Then
                    stopCustom("Can't update status because data is already locked.")
                    FormSalesOrderSvcLevel.GVPL.ActiveFilterString = ""
                    Close()
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to set " + SLEStatusRec.Text.ToLower.ToString + " status for these data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        For i As Integer = 0 To ((FormSalesOrderSvcLevel.GVPL.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVPL))
                            Dim ch_stt As ClassProductionPLToWHRec = New ClassProductionPLToWHRec()
                            ch_stt.changeStatus(FormSalesOrderSvcLevel.GVPL.GetRowCellValue(i, "id_pl_prod_order_rec").ToString, SLEStatusRec.EditValue.ToString)
                            removeAppList(report_mark_type, FormSalesOrderSvcLevel.GVPL.GetRowCellValue(i, "id_pl_prod_order_rec").ToString, id_status_reportx)
                            insertFinalComment(report_mark_type, FormSalesOrderSvcLevel.GVPL.GetRowCellValue(i, "id_pl_prod_order_rec").ToString, id_status_reportx, note)
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        Cursor = Cursors.Default
                    End If
                End If
                FormSalesOrderSvcLevel.GVPL.ActiveFilterString = ""
                FormSalesOrderSvcLevel.viewRecProduct()
                Close()
            ElseIf id_pop_up = "2" Then
                Dim check_stt As Boolean = False
                For c As Integer = 0 To ((FormSalesOrderSvcLevel.GVSalesDelOrder.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVSalesDelOrder))
                    Dim rs As String = FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(c, "id_report_status").ToString
                    If rs = "5" Or rs = "6" Then
                        check_stt = True
                        Exit For
                    End If
                Next

                If check_stt Then
                    stopCustom("Can't update status because data is already locked.")
                    FormSalesOrderSvcLevel.GVSalesDelOrder.ActiveFilterString = ""
                    Close()
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to set " + SLEStatusRec.Text.ToLower.ToString + " status for these data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        For i As Integer = 0 To ((FormSalesOrderSvcLevel.GVSalesDelOrder.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVSalesDelOrder))
                            Dim stt As ClassSalesDelOrder = New ClassSalesDelOrder()
                            stt.changeStatus(FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_pl_sales_order_del").ToString, SLEStatusRec.EditValue.ToString)
                            removeAppList(report_mark_type, FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_pl_sales_order_del").ToString, id_status_reportx)
                            insertFinalComment(report_mark_type, FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_pl_sales_order_del").ToString, id_status_reportx, note)
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        Cursor = Cursors.Default
                    End If
                End If
                FormSalesOrderSvcLevel.GVSalesDelOrder.ActiveFilterString = ""
                FormSalesOrderSvcLevel.viewDO()
                FormSalesOrderSvcLevel.viewSalesOrder()
                Close()
            ElseIf id_pop_up = "3" Then
                Dim check_stt As Boolean = False
                For c As Integer = 0 To ((FormSalesOrderSvcLevel.GVSalesReturn.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVSalesReturn))
                    Dim rs As String = FormSalesOrderSvcLevel.GVSalesReturn.GetRowCellValue(c, "id_report_status").ToString
                    If rs = "5" Or rs = "6" Then
                        check_stt = True
                        Exit For
                    End If
                Next

                If check_stt Then
                    stopCustom("Can't update status because data is already locked.")
                    FormSalesOrderSvcLevel.GVSalesReturn.ActiveFilterString = ""
                    Close()
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to set " + SLEStatusRec.Text.ToLower.ToString + " status for these data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        For i As Integer = 0 To ((FormSalesOrderSvcLevel.GVSalesReturn.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVSalesReturn))
                            Dim stt As ClassSalesReturn = New ClassSalesReturn()
                            stt.changeStatus(FormSalesOrderSvcLevel.GVSalesReturn.GetRowCellValue(i, "id_sales_return").ToString, SLEStatusRec.EditValue.ToString)
                            removeAppList(report_mark_type, FormSalesOrderSvcLevel.GVSalesReturn.GetRowCellValue(i, "id_sales_return").ToString, id_status_reportx)
                            insertFinalComment(report_mark_type, FormSalesOrderSvcLevel.GVSalesReturn.GetRowCellValue(i, "id_sales_return").ToString, id_status_reportx, note)
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        Cursor = Cursors.Default
                    End If
                End If
                FormSalesOrderSvcLevel.GVSalesReturn.ActiveFilterString = ""
                FormSalesOrderSvcLevel.viewReturn()
                Close()
            ElseIf id_pop_up = "4" Then
                Dim check_stt As Boolean = False
                For c As Integer = 0 To ((FormSalesOrderSvcLevel.GVSalesReturnQC.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVSalesReturnQC))
                    Dim rs As String = FormSalesOrderSvcLevel.GVSalesReturnQC.GetRowCellValue(c, "id_report_status").ToString
                    If rs = "5" Or rs = "6" Then
                        check_stt = True
                        Exit For
                    End If
                Next

                If check_stt Then
                    stopCustom("Can't update status because data is already locked.")
                    FormSalesOrderSvcLevel.GVSalesReturnQC.ActiveFilterString = ""
                    Close()
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to set " + SLEStatusRec.Text.ToLower.ToString + " status for these data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        For i As Integer = 0 To ((FormSalesOrderSvcLevel.GVSalesReturnQC.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVSalesReturnQC))
                            Dim stt As ClassSalesReturnQC = New ClassSalesReturnQC()
                            stt.changeStatus(FormSalesOrderSvcLevel.GVSalesReturnQC.GetRowCellValue(i, "id_sales_return_qc").ToString, SLEStatusRec.EditValue.ToString)
                            removeAppList(FormSalesOrderSvcLevel.GVSalesReturnQC.GetRowCellValue(i, "rmk").ToString, FormSalesOrderSvcLevel.GVSalesReturnQC.GetRowCellValue(i, "id_sales_return_qc").ToString, id_status_reportx)
                            insertFinalComment(report_mark_type, FormSalesOrderSvcLevel.GVSalesReturnQC.GetRowCellValue(i, "id_sales_return_qc").ToString, id_status_reportx, note)
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        Cursor = Cursors.Default
                    End If
                End If
                FormSalesOrderSvcLevel.GVSalesReturnQC.ActiveFilterString = ""
                FormSalesOrderSvcLevel.viewReturnQC()
                Close()
            ElseIf id_pop_up = "5" Then
                Dim check_stt As Boolean = False
                For c As Integer = 0 To ((FormSalesOrderSvcLevel.GVFGTrf.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVFGTrf))
                    Dim rs As String = FormSalesOrderSvcLevel.GVFGTrf.GetRowCellValue(c, "id_report_status").ToString
                    If rs = "5" Or rs = "6" Then
                        check_stt = True
                        Exit For
                    End If
                Next

                If check_stt Then
                    stopCustom("Can't update status because data is already locked.")
                    FormSalesOrderSvcLevel.GVFGTrf.ActiveFilterString = ""
                    Close()
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to set " + SLEStatusRec.Text.ToLower.ToString + " status for these data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        For i As Integer = 0 To ((FormSalesOrderSvcLevel.GVFGTrf.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVFGTrf))
                            Dim stt As ClassFGTrf = New ClassFGTrf()
                            stt.changeStatus(FormSalesOrderSvcLevel.GVFGTrf.GetRowCellValue(i, "id_fg_trf").ToString, SLEStatusRec.EditValue.ToString)
                            removeAppList(report_mark_type, FormSalesOrderSvcLevel.GVFGTrf.GetRowCellValue(i, "id_fg_trf").ToString, id_status_reportx)
                            insertFinalComment(report_mark_type, FormSalesOrderSvcLevel.GVFGTrf.GetRowCellValue(i, "id_fg_trf").ToString, id_status_reportx, note)
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        Cursor = Cursors.Default
                    End If
                End If
                FormSalesOrderSvcLevel.GVFGTrf.ActiveFilterString = ""
                FormSalesOrderSvcLevel.viewTrf()
                FormSalesOrderSvcLevel.viewSalesOrder()
                Close()
            End If
        Else
            stopCustom("Unable change to this status, report doesn't meet requirement to this status.")
        End If
    End Sub

    Private Sub FormChangeStatus_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub insertFinalComment(ByVal rmt As String, ByVal id_report As String, ByVal id_report_status As String, ByVal comment As String)
        Dim query As String = "INSERT INTO tb_report_mark_final_comment(report_mark_type, id_report, id_report_status, id_user, final_comment, final_comment_date) VALUES "
        query += "('" + rmt + "', '" + id_report + "', '" + id_report_status + "', '" + id_user + "', '" + comment + "', NOW()) "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Private Sub removeAppList(ByVal report_mark_type As String, ByVal id_report As String, ByVal id_status_reportx As String)
        If SLEStatusRec.EditValue.ToString = "5" Then
            Dim query As String = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", report_mark_type, id_report, id_status_reportx)
            execute_non_query(query, True, "", "", "", "")
        End If
    End Sub
End Class