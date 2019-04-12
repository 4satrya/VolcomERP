Public Class FormOLStoreDetCheckStockvb
    Public dt As DataTable
    Private Sub FormOLStoreDetCheckStockvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GCProduct.DataSource = dt
        GVProduct.BestFitColumns()
    End Sub

    Private Sub FormOLStoreDetCheckStockvb_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCProduct, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub ViewDetailOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailOrderToolStripMenuItem.Click
        If GVProduct.RowCount > 0 And GVProduct.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormImportExcel.GVData.ActiveFilterString = "[id_product]='" + GVProduct.GetFocusedRowCellValue("id_product").ToString + "' 
            AND [id_wh_drawer]='" + GVProduct.GetFocusedRowCellValue("id_wh_drawer").ToString + "' "
            Close()
            Cursor = Cursors.Default
        End If
    End Sub
End Class