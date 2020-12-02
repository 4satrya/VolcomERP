Public Class FormScanReturnDetManual
    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If TEDescription.Text = "" Or TEBarcode.Text = "" Or TESize.Text = "" Then
            infoCustom("Please fill all value")
        Else
            FormScanReturnDet.GVListProduct.AddNewRow()
            FormScanReturnDet.GCListProduct.RefreshDataSource()
            FormScanReturnDet.GVListProduct.RefreshData()
            FormScanReturnDet.GVListProduct.FocusedRowHandle = FormScanReturnDet.GVListProduct.RowCount - 1
            '
            FormScanReturnDet.GVListProduct.SetRowCellValue(FormScanReturnDet.GVListProduct.RowCount - 1, "type", "2")
            FormScanReturnDet.GVListProduct.SetRowCellValue(FormScanReturnDet.GVListProduct.RowCount - 1, "notes", "Input manual")

            FormScanReturnDet.GVListProduct.SetRowCellValue(FormScanReturnDet.GVListProduct.RowCount - 1, "id_product", "0")
            FormScanReturnDet.GVListProduct.SetRowCellValue(FormScanReturnDet.GVListProduct.RowCount - 1, "product_full_code", TEBarcode.Text)
            FormScanReturnDet.GVListProduct.SetRowCellValue(FormScanReturnDet.GVListProduct.RowCount - 1, "product_display_name", TEDescription.Text)
            FormScanReturnDet.GVListProduct.SetRowCellValue(FormScanReturnDet.GVListProduct.RowCount - 1, "size", TESize.Text)
            '
            FormScanReturnDet.GVListProduct.RefreshData()
            Close()
        End If
    End Sub

    Private Sub FormScanReturnDetManual_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class