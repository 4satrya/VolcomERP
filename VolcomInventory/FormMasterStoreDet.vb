Public Class FormMasterStoreDet
    Public id_store As String = "-1"

    Private Sub FormMasterStoreDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not id_store = "-1" Then
            Dim data As DataTable = execute_query("SELECT * FROM tb_m_store WHERE id_store = '" + id_store + "'", -1, True, "", "", "", "")

            TEStore.EditValue = data.Rows(0)("store_name").ToString
        End If
    End Sub

    Private Sub FormMasterStoreDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        If id_store = "-1" Then
            'new
            execute_non_query("INSERT INTO tb_m_store (store_name) VALUES ('" + addSlashes(TEStore.EditValue.ToString) + "')", True, "", "", "", "")
        Else
            execute_non_query("UPDATE tb_m_store SET store_name = '" + addSlashes(TEStore.EditValue.ToString) + "' WHERE id_store = '" + id_store + "'", True, "", "", "", "")
        End If

        infoCustom("User external saved.")

        FormMasterStore.form_load()

        Close()
    End Sub
End Class