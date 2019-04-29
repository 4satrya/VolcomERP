Public Class FormOLStoreOrderId
    Public id_main As String = "-1"
    Public id_det As String = "-1"

    Private Sub FormOLStoreOrderId_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If TxtOrderNumber.Text.Trim = "" Or TxtItemId.Text.Trim = "" Or TxtOLStoreId.Text.Trim = "" Then
            warningCustom("Please complete all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to update these orders ID ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'main
                Dim query As String = "UPDATE tb_sales_order SET sales_order_ol_shop_number='" + addSlashes(TxtOrderNumber.Text.Trim) + "' WHERE id_sales_order='" + id_main + "';
                UPDATE tb_sales_order_det SET item_id='" + addSlashes(TxtItemId.Text.Trim) + "', ol_store_id='" + addSlashes(TxtOLStoreId.Text.Trim) + "' WHERE id_sales_order_det='" + id_det + "'; "
                execute_non_query(query, True, "", "", "", "")

                'refresh
                FormOLStore.viewDetail()
                FormOLStore.GVDetail.FocusedRowHandle = find_row(FormOLStore.GVDetail, "id_sales_order_det", id_det)
                Close()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub FormOLStoreOrderId_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub
End Class