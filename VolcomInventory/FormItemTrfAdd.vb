Public Class FormItemTrfAdd
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click

    End Sub

    Private Sub FormItemTrfAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVSOH)
        GVSOH.ActiveFilterString = "[qty_req]>0"
        If GVSOH.RowCount > 0 Then
            For i As Integer = 0 To ((GVSOH.RowCount - 1) - GetGroupRowCount(GVSOH))
                Dim newRow As DataRow = (TryCast(FormItemReqDet.GCData.DataSource, DataTable)).NewRow()
                newRow("id_item") = GVSOH.GetRowCellValue(i, "id_item").ToString
                newRow("item_desc") = GVSOH.GetRowCellValue(i, "item_desc").ToString
                newRow("qty") = GVSOH.GetRowCellValue(i, "qty_req")
                TryCast(FormItemReqDet.GCData.DataSource, DataTable).Rows.Add(newRow)
                FormItemReqDet.GCData.RefreshDataSource()
                FormItemReqDet.GVData.RefreshData()
            Next
            Close()
        Else
            warningCustom("No item selected")
            makeSafeGV(GVSOH)
            GridColumnDept.GroupIndex = 0
        End If
        Cursor = Cursors.Default
    End Sub
End Class