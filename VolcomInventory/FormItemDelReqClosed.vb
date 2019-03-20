Public Class FormItemDelReqClosed
    Public where_string As String = ""

    Private Sub FormItemDelReqClosed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MENote.Focus()
    End Sub

    Private Sub FormItemDelReqClosed_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Dim final_reason As String = addSlashes(MENote.Text)
        If final_reason = "" Then
            warningCustom("All fields are required")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to close these request?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                'query upd 
                Dim query_upd As String = "UPDATE tb_item_req_det rd SET rd.id_prepare_status=2,rd.final_reason='" + final_reason + "' WHERE 1=1 AND (" + where_string + ") "
                execute_non_query(query_upd, True, "", "", "", "")

                'in stock
                Dim query_stock As String = "INSERT INTO tb_storage_item (id_departement, id_storage_category,id_item, `value`, report_mark_type, id_report, storage_item_qty, storage_item_datetime, id_stock_status)
            SELECT r.id_departement, 1, rd.id_item, getAvgCost(rd.id_item), 154, r.id_item_req, rd.qty, NOW(), 1
            FROM tb_item_req r
            INNER JOIN tb_item_req_det rd ON rd.id_item_req = r.id_item_req
            WHERE 1=1 AND (" + where_string + ") "
                execute_non_query(query_stock, True, "", "", "", "")

                'refresh
                makeSafeGV(FormItemDelReqDet.GVData)
                FormItemDelReqDet.viewDetail()
                FormItemDel.viewRequest()
                Close()
            End If
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
End Class