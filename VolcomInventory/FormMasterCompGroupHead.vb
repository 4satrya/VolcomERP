Public Class FormMasterCompGroupHead
    Private Sub SimpleButtonAdd_Click(sender As Object, e As EventArgs) Handles SimpleButtonAdd.Click
        FormMasterCompGroupHeadDet.id_comp_group_header = "-1"
        FormMasterCompGroupHeadDet.ShowDialog()
    End Sub

    Private Sub SimpleButtonEdit_Click(sender As Object, e As EventArgs) Handles SimpleButtonEdit.Click
        FormMasterCompGroupHeadDet.id_comp_group_header = GVGroupComp.GetFocusedRowCellValue("id_comp_group_header").ToString
        FormMasterCompGroupHeadDet.ShowDialog()
    End Sub

    Private Sub SimpleButtonRemove_Click(sender As Object, e As EventArgs) Handles SimpleButtonRemove.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this group ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query As String = "DELETE FROM tb_m_comp_group_header WHERE id_comp_group_header = '" + GVGroupComp.GetFocusedRowCellValue("id_comp_group_header").ToString + "'"
            execute_non_query(query, True, "", "", "", "")

            form_load()
        End If
    End Sub

    Private Sub FormMasterCompGroupHead_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Sub form_load()
        Dim query As String = "SELECT * FROM tb_m_comp_group_header"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCGroupComp.DataSource = data
        GVGroupComp.BestFitColumns()
    End Sub

    Private Sub FormMasterCompGroupHead_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormMasterCompGroupDet.view_group_header()
        FormMasterCompGroupDet.SLUECompanyGroupHeader.EditValue = FormMasterCompGroupDet.SLUECompanyGroupHeader.OldEditValue

        Dispose()
    End Sub
End Class