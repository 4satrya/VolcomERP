Public Class FormMasterStore
    Private Sub FormMasterStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormMasterStore_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("1", "1", "0")
    End Sub

    Private Sub FormMasterStore_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormMasterStore_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub form_load()
        Dim data As DataTable = execute_query("SELECT * FROM tb_m_store", -1, True, "", "", "", "")

        GCMasterStore.DataSource = data

        GVMasterStore.BestFitColumns()
    End Sub

    Private Sub GVMasterStore_DoubleClick(sender As Object, e As EventArgs) Handles GVMasterStore.DoubleClick
        FormMain.but_edit()
    End Sub
End Class