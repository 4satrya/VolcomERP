Public Class FormMasterCompGroupDet 
    Public id_comp_group As String = "-1"
    Private Sub FormMasterCompGroupDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_group_header()
        If Not id_comp_group = "-1" Then
            Dim query As String = "SELECT * FROM tb_m_comp_group WHERE id_comp_group = " + id_comp_group
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            SLUECompanyGroupHeader.EditValue = data.Rows(0)("id_comp_group_header").ToString
            TECompanyGroup.EditValue = data.Rows(0)("comp_group").ToString
            TEDescription.EditValue = data.Rows(0)("description").ToString
        End If
    End Sub

    Sub view_group_header()
        viewSearchLookupQuery(SLUECompanyGroupHeader, "SELECT 0 AS id_comp_group_header, '' AS comp_group_header, '' AS description, '' AS description_name UNION SELECT id_comp_group_header, comp_group_header, description, CONCAT(comp_group_header, ' - ', description) AS description_name FROM tb_m_comp_group_header", "id_comp_group_header", "description_name", "id_comp_group_header")
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor
        If id_comp_group = "-1" Then 'new
            Dim query As String = "INSERT INTO tb_m_comp_group(id_comp_group_header,comp_group,description) VALUES(" + If(SLUECompanyGroupHeader.EditValue.ToString = "0", "NULL", "'" + SLUECompanyGroupHeader.EditValue.ToString + "'") + ",'" + addSlashes(TECompanyGroup.Text) + "','" & addSlashes(TEDescription.Text) & "');SELECT LAST_INSERT_ID() "
            id_comp_group = execute_query(query, 0, True, "", "", "", "")
            FormPopUpCompGroup.view_comp_group()
            FormPopUpCompGroup.GVGroupComp.FocusedRowHandle = find_row(FormPopUpCompGroup.GVGroupComp, "id_comp_group", id_comp_group)
            Close()
        Else 'edit
            Dim query As String = "UPDATE tb_m_comp_group SET id_comp_group_header=" + If(SLUECompanyGroupHeader.EditValue.ToString = "0", "NULL", "'" + SLUECompanyGroupHeader.EditValue.ToString + "'") + ",comp_group='" + addSlashes(TECompanyGroup.Text) + "',description='" & addSlashes(TEDescription.Text) & "' WHERE id_comp_group='" + id_comp_group + "'"
            execute_non_query(query, True, "", "", "", "")
            FormPopUpCompGroup.view_comp_group()
            FormPopUpCompGroup.GVGroupComp.FocusedRowHandle = find_row(FormPopUpCompGroup.GVGroupComp, "id_comp_group", id_comp_group)
            Close()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormMasterCompGroupDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButtonAddRemove_Click(sender As Object, e As EventArgs) Handles SimpleButtonAddRemove.Click
        FormMasterCompGroupHead.ShowDialog()
    End Sub
End Class