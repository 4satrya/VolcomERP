Public Class FormPurcAssetValueAddedList
    Public id_parent As String = ""

    Private Sub FormPurcAssetValueAddedList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim a As New ClassPurcAsset()
        Dim query As String = a.queryMain("AND a.id_parent='" + id_parent + "' AND a.is_value_added=1 ", "2", False)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub


    Private Sub FormPurcAssetValueAddedList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub LabelLinkAssetNumber_Click(sender As Object, e As EventArgs) Handles LabelLinkAssetNumber.Click
        Cursor = Cursors.WaitCursor
        Dim s As New ClassShowPopUp()
        s.id_report = id_parent
        s.report_mark_type = "160"
        s.show()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormPurcAssetValueAdded.action = "ins"
        FormPurcAssetValueAdded.id_parent = id_parent
        FormPurcAssetValueAdded.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        Cursor = Cursors.WaitCursor
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            FormPurcAssetValueAdded.action = "upd"
            FormPurcAssetValueAdded.id_parent = id_parent
            FormPurcAssetValueAdded.id = GVData.GetFocusedRowCellValue("id_purc_rec_asset")
            FormPurcAssetValueAdded.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub
End Class