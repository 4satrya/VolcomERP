Public Class FormPopUpCompGroup 
    Private Sub FormPopUpCompGroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_comp_group()
    End Sub

    Sub view_comp_group()
        Dim query As String = "SELECT id_comp_group,comp_group,description FROM tb_m_comp_group"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCGroupComp.DataSource = data
    End Sub

    Private Sub BAddComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddComp.Click
        FormMasterCompGroupDet.id_comp_group = "-1"
        FormMasterCompGroupDet.ShowDialog()
    End Sub

    Private Sub BEditComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormMasterCompGroupDet.id_comp_group = GVGroupComp.GetFocusedRowCellValue("id_comp_group").ToString
        FormMasterCompGroupDet.TECompanyGroup.Text = GVGroupComp.GetFocusedRowCellValue("comp_group").ToString
        FormMasterCompGroupDet.ShowDialog()
    End Sub


    Private Sub BDelComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim confirm As DialogResult
        Dim query As String

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this group ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        Dim id_comp_group As String = GVGroupComp.GetFocusedRowCellValue("id_comp_group").ToString

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                query = String.Format("DELETE FROM tb_m_comp_group WHERE id_comp_group = '{0}'", id_comp_group)
                execute_non_query(query, True, "", "", "", "")
                view_comp_group()
            Catch ex As Exception
                errorDelete()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormPopUpCompGroup_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVGroupComp_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVGroupComp.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class