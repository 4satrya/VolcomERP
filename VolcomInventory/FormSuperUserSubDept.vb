Public Class FormSuperUserSubDept
    Private Sub FormSuperUserDept_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT * FROM tb_m_departement_sub"
        viewSearchLookupQuery(SearchLookUpEdit1, query, "id_departement_sub", "departement_sub", "id_departement_sub")
        SearchLookUpEdit1.EditValue = id_departement_sub_user
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        id_departement_sub_user = SearchLookUpEdit1.EditValue.ToString
        Close()
    End Sub

    Private Sub FormSuperUserDept_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class