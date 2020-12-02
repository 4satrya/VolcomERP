Public Class FormSalesReturnStoreReturn
    Public dt As DataTable = Nothing

    Private Sub FormSalesReturnStoreReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GCData.DataSource = dt
        GVData.BestFitColumns()
    End Sub

    Private Sub FormSalesReturnStoreReturn_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub choose()
        FormSalesReturnDet.id_wh_awb_det = GVData.GetFocusedRowCellValue("id_wh_awb_det").ToString
        FormSalesReturnDet.id_return_note = GVData.GetFocusedRowCellValue("id_return_note").ToString
        FormSalesReturnDet.TxtStoreReturnNumber.Text = GVData.GetFocusedRowCellValue("do_no").ToString
        FormSalesReturnDet.TxtStoreReturnNumber.Properties.ReadOnly = True
        Close()
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        choose()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            choose()
        End If
    End Sub
End Class