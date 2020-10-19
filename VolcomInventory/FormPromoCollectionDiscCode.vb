Public Class FormPromoCollectionDiscCode
    Private Sub FormPromoCollectionDiscCode_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        choose()
    End Sub

    Sub choose()
        Cursor = Cursors.WaitCursor
        If GVData.RowCount > 0 Then
            FormPromoCollectionDet.id = GVData.GetFocusedRowCellValue("id_ol_promo_collection").ToString
            FormPromoCollectionDet.ShowDialog()
            Close()
        Else
            stopCustom("Please select group discount")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        choose()
    End Sub

    Private Sub FormPromoCollectionDiscCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT c.id_ol_promo_collection, c.discount_title, c.start_period, c.end_period 
        FROM tb_ol_promo_collection c 
        WHERE c.is_use_discount_code=1 AND c.id_report_status=1 AND c.is_confirm=2 
        ORDER BY c.id_ol_promo_collection ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub
End Class