Public Class FormMasterDesignFabricationDet
    Public id_design_fabrication As String = "0"

    Private Sub FormMasterDesignFabricationDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_design_fabrication <> "0" Then
            Dim query As String = "
                SELECT df.id_design_fabrication, df.design_fabrication, df.created_date, ec.employee_name AS created_by, df.updated_date, eu.employee_name AS updated_by
                FROM tb_design_fabrication AS df
                LEFT JOIN tb_m_employee AS ec ON df.created_by = ec.id_employee
                LEFT JOIN tb_m_employee AS eu ON df.updated_by = eu.id_employee
                WHERE df.id_design_fabrication = '" + id_design_fabrication + "'
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TEFabrication.EditValue = data.Rows(0)("design_fabrication").ToString
            DECreatedDate.EditValue = data.Rows(0)("created_date")
            TECreatedBy.EditValue = data.Rows(0)("created_by").ToString
            DEUpdatedDate.EditValue = data.Rows(0)("updated_date")
            TEUpdatedBy.EditValue = data.Rows(0)("updated_by").ToString
        End If
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        Dim query As String = ""

        If id_design_fabrication = "0" Then
            query = "INSERT INTO tb_design_fabrication (design_fabrication, created_date, created_by) VALUES ('" + addSlashes(TEFabrication.EditValue.ToString) + "', NOW(), " + id_employee_user + ")"
        Else
            query = "UPDATE tb_design_fabrication SET design_fabrication = '" + addSlashes(TEFabrication.EditValue.ToString) + "', updated_date = NOW(), updated_by = " + id_employee_user + " WHERE id_design_fabrication = " + id_design_fabrication
        End If

        execute_non_query(query, True, "", "", "", "")

        FormMasterDesignFabrication.load_form()
        FormMasterDesignFabricationLookup.form_load()

        Close()
    End Sub

    Sub delete()
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this fabrication?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            execute_non_query("DELETE FROM tb_design_fabrication WHERE id_design_fabrication = " + id_design_fabrication, True, "", "", "", "")

            FormMasterDesignFabrication.load_form()
        End If
    End Sub

    Private Sub FormMasterDesignFabricationDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class