Public Class FormMappingStoreDet
    Public id_comp As String = "-1"

    Private Sub FormMappingStoreDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_company()
        view_store()

        Dim id_store As String = execute_query("SELECT id_store FROM tb_m_comp WHERE id_comp = '" + id_comp + "'", 0, True, "", "", "", "")

        SLUECompany.EditValue = id_comp
        SLUEStore.EditValue = id_store
    End Sub

    Sub view_company()
        viewSearchLookupQuery(SLUECompany, "SELECT id_comp, comp_name FROM tb_m_comp WHERE id_comp_cat = 6", "id_comp", "comp_name", "id_comp")
    End Sub

    Sub view_store()
        viewSearchLookupQuery(SLUEStore, "SELECT id_store, store_name FROM tb_m_store", "id_store", "store_name", "id_store")
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        execute_non_query("UPDATE tb_m_comp SET id_store = '" + SLUEStore.EditValue.ToString + "' WHERE id_comp = '" + SLUECompany.EditValue.ToString + "'", True, "", "", "", "")

        infoCustom("Data saved.")

        FormMappingStore.form_load()

        Close()
    End Sub

    Private Sub FormMappingStoreDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class