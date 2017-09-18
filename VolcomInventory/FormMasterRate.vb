Public Class FormMasterRate
    Private Sub FormMasterRate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_rate_management()
    End Sub

    Sub load_rate_management()
        TERateManagement.EditValue = get_setup_field("rate_management")
    End Sub

    Private Sub BUpdate_Click(sender As Object, e As EventArgs) Handles BUpdate.Click
        Dim query As String = "UPDATE tb_opt SET rate_management='" & decimalSQL(TERateManagement.EditValue.ToString) & "'"
        execute_non_query(query, True, "", "", "", "")
        Close()
    End Sub
End Class