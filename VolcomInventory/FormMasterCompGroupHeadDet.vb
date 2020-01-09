Public Class FormMasterCompGroupHeadDet
    Public id_comp_group_header As String = "-1"

    Private Sub FormMasterCompGroupHeadDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT * FROM tb_m_comp_group_header WHERE id_comp_group_header = " + id_comp_group_header
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If Not id_comp_group_header = "-1" Then
            TECompanyGroup.EditValue = data.Rows(0)("comp_group_header").ToString
            TEDescription.EditValue = data.Rows(0)("description").ToString
        End If
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If id_comp_group_header = "-1" Then
            Dim query As String = "INSERT INTO tb_m_comp_group_header (comp_group_header, description) VALUES ('" + addSlashes(TECompanyGroup.EditValue.ToString) + "','" + addSlashes(TEDescription.EditValue.ToString) + "')"
            execute_non_query(query, True, "", "", "", "")
        Else
            Dim query As String = "UPDATE tb_m_comp_group_header SET comp_group_header = '" + addSlashes(TECompanyGroup.EditValue.ToString) + "', description = '" + addSlashes(TEDescription.EditValue.ToString) + "' WHERE id_comp_group_header = '" + id_comp_group_header + "'"
            execute_non_query(query, True, "", "", "", "")
        End If

        Close()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormMasterCompGroupHeadDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormMasterCompGroupHead.form_load()

        Dispose()
    End Sub
End Class