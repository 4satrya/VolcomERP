Public Class FormMappingStore
    Private Sub FormMappingStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Sub form_load()
        Dim data As DataTable = execute_query("
            SELECT c.id_comp, s.store_name, c.comp_number, c.comp_name, c.address_primary
            FROM tb_m_comp AS c
            LEFT JOIN tb_m_store AS s ON c.id_store = s.id_store
            WHERE c.id_comp_cat = 6
            ORDER BY c.comp_number ASC
        ", -1, True, "", "", "", "")

        GCMappingStore.DataSource = data

        GVMappingStore.BestFitColumns()
    End Sub

    Private Sub GVMappingStore_DoubleClick(sender As Object, e As EventArgs) Handles GVMappingStore.DoubleClick
        FormMappingStoreDet.id_comp = GVMappingStore.GetFocusedRowCellValue("id_comp").ToString

        FormMappingStoreDet.ShowDialog()
    End Sub

    Private Sub FormMappingStore_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMappingStore_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormMappingStore_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class