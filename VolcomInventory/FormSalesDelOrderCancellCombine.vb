Public Class FormSalesDelOrderCancellCombine
    Public id_combine As String = "-1"
    Public id_comp_contact_from As String = "-1"
    Public id_store_contact_to As String = "-1"

    Private Sub FormSalesDelOrderCancellCombine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim del As New ClassSalesDelOrder()
        Dim query As String = del.queryMain("AND a.id_combine=" + id_combine + "", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesDelOrder.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSalesDelOrderCancellCombine_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVSalesDelOrder)
        If FormSalesOrderSvcLevel.statusCombineDel(id_combine) Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                'set null delivery
                Dim jum_ins_j As Integer = 0
                Dim query_detail As String = ""
                If GVSalesDelOrder.RowCount > 0 Then
                    query_detail = "UPDATE tb_pl_sales_order_del SET is_combine=2 , id_combine=NULL WHERE ("
                End If
                Dim del As String = ""
                For j As Integer = 0 To ((GVSalesDelOrder.RowCount - 1) - GetGroupRowCount(GVSalesDelOrder))
                    Dim id_pl_sales_order_del As String = GVSalesDelOrder.GetRowCellValue(j, "id_pl_sales_order_del").ToString

                    If jum_ins_j > 0 Then
                        query_detail += "OR "
                        del += "OR "
                    End If
                    query_detail += "id_pl_sales_order_del='" + id_pl_sales_order_del + "' "
                    del += "r.id_report='" + id_pl_sales_order_del + "' "
                    jum_ins_j = jum_ins_j + 1
                Next
                query_detail += ") "
                If jum_ins_j > 0 Then
                    execute_non_query(query_detail, True, "", "", "", "")
                End If

                'update mark in delivery single
                If del <> "" Then
                    Dim query_mark_single As String = "UPDATE tb_report_mark r SET r.report_mark_start_datetime=NOW() 
                        WHERE r.report_mark_type=43 AND (" + del + ") AND r.id_report_status=3 "
                    execute_non_query(query_mark_single, True, "", "", "", "")
                End If

                'update final status
                Dim qu As String = "UPDATE tb_pl_sales_order_del_combine SET final_status='" + addSlashes(MemoEdit1.Text) + "', id_report_status=5, final_status_time=NOW() WHERE id_combine='" + id_combine + "' "
                execute_non_query(qu, True, "", "", "", "")

                'nonaktif mark
                Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", "103", id_combine)
                execute_non_query(queryrm, True, "", "", "", "")
                FormSalesOrderSvcLevel.viewDO()
                Close()
            End If
        Else
            warningCustom("Combined delivery already process")
        End If
        Cursor = Cursors.Default
    End Sub
End Class