Public Class FormSalesReturnInputTanggalPickup
    Private Sub FormSalesReturnInputTanggalPickup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DETanggalInput.EditValue = Date.Now
    End Sub

    Private Sub FormSalesReturnInputTanggalPickup_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        If Not DETanggalInput.Text = "" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save pickup date ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                For i = 0 To FormSalesOrderSvcLevel.GVSalesReturnOrder.RowCount - 1
                    Dim query As String = "UPDATE tb_sales_return_order SET pickup_date = '" + Date.Parse(DETanggalInput.EditValue.ToString).ToString("yyyy-MM-dd") + "', pickup_date_updated_by = " + id_user + ", pickup_date_updated_at = NOW() WHERE id_sales_return_order = " + FormSalesOrderSvcLevel.GVSalesReturnOrder.GetRowCellValue(i, "id_sales_return_order").ToString

                    execute_non_query(query, True, "", "", "", "")
                Next

                FormSalesOrderSvcLevel.viewReturnOrder()

                Close()
            End If
        Else
            stopCustom("Please input pickup date.")
        End If
    End Sub
End Class