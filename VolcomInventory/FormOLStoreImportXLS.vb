Public Class FormOLStoreImportXLS
    Dim comp_group_in As String = "-1"

    Private Sub FormOLStoreImportXLS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comp_group_in = get_setup_field("xls_order_online_store")
        viewOLStore()
    End Sub

    Private Sub FormOLStoreImportXLS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Sub viewOLStore()
        Cursor = Cursors.WaitCursor
        'only for shopee
        Dim query As String = "SELECT cg.id_comp_group, cg.description 
        FROM tb_m_comp_group cg WHERE cg.id_comp_group IN (" + comp_group_in + ")
        ORDER BY cg.idx_prior_order ASC "
        viewSearchLookupQuery(SLEOLStore, query, "id_comp_group", "description", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnProceed_Click(sender As Object, e As EventArgs) Handles BtnProceed.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "54"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class