Public Class FormSalesTargetProposeAdd
    Dim id As String = FormSalesTargetProposeDet.id
    Dim year As String = FormSalesTargetProposeDet.TxtYear.Text

    Private Sub BtnCloseStoreExisting_Click(sender As Object, e As EventArgs) Handles BtnCloseStoreExisting.Click
        Close()
    End Sub

    Private Sub BtnAddStoreExisting_Click(sender As Object, e As EventArgs) Handles BtnAddStoreExisting.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVData)
        GVData.ActiveFilterString = "[is_select]='Yes' "
        If GVData.RowCount > 0 Then
            For i As Integer = 0 To GVData.RowCount - 1
                Dim id_comp As String = GVData.GetRowCellValue(i, "id_comp").ToString
                Dim comp_number As String = addSlashes(GVData.GetRowCellValue(i, "comp_number").ToString)
                Dim comp_name As String = addSlashes(GVData.GetRowCellValue(i, "comp_name").ToString)
                Dim query As String = "INSERT INTO tb_sales_trg_propose_det(id_sales_trg_propose, id_store_stt, id_comp, comp_number, comp_name, month, value_trg) 
                VALUES(" + id + ", 1, " + id_comp + ", '" + comp_number + "', '" + comp_name + "', '" + year + "-01-01', 0); "
                execute_non_query(query, True, "", "", "", "")
            Next
            FormSalesTargetProposeDet.viewDetail()
            viewExixtingStore()
        Else
            stopCustom("No data selected")
        End If
        GVData.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSalesTargetProposeAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewExixtingStore()
    End Sub

    Sub viewExixtingStore()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT c.id_comp, c.comp_number, c.comp_name, st.store_type, 'No' AS `is_select` 
        FROM tb_m_comp c 
        INNER JOIN tb_lookup_store_type st ON st.id_store_type = c.id_store_type
        LEFT JOIN (
            SELECT td.id_comp 
            FROM tb_sales_trg_propose_det td
            WHERE td.id_sales_trg_propose=" + id + "
            GROUP BY td.id_comp
        ) td ON td.id_comp = c.id_comp
        WHERE c.id_comp_cat=6 AND c.is_active=1 AND ISNULL(td.id_comp)
        ORDER BY c.comp_number ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSalesTargetProposeAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class