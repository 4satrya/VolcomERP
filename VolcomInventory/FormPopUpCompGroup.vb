Public Class FormPopUpCompGroup
    Public is_menu As String = "0"

    Private Sub FormPopUpCompGroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If is_menu = "1" Then
            PanelControl3.Visible = False
        Else
            GridColumnContactName.Visible = False
            GridColumnPosition.Visible = False
            GridColumnContactNumber.Visible = False
            GridColumnEmail.Visible = False
            GridColumnStatus.Visible = False
        End If

        view_comp_group()
    End Sub

    Sub view_comp_group()
        Dim query As String = "SELECT cgroup.id_comp_group,CONCAT(cgrouphead.comp_group_header, ' - ', cgrouphead.description) AS comp_group_header,cgroup.comp_group,cgroup.description,ccontact.id_comp,comp.comp_name,ccontact.contact_person,ccontact.contact_number,ccontact.position,ccontact.email,(SELECT comp_status FROM tb_lookup_comp_status WHERE comp.is_active = id_comp_status) AS comp_status FROM tb_m_comp_group AS cgroup LEFT JOIN tb_m_comp AS comp ON cgroup.id_comp = comp.id_comp LEFT JOIN tb_m_comp_contact AS ccontact ON cgroup.id_comp = ccontact.id_comp AND ccontact.is_default = 1 LEFT JOIN tb_m_comp_group_header AS cgrouphead ON cgroup.id_comp_group_header = cgrouphead.id_comp_group_header"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCGroupComp.DataSource = data
        GVGroupComp.BestFitColumns()
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

    Private Sub FormPopUpCompGroup_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If is_menu = "1" Then
            FormMain.show_rb(Name)
            checkFormAccess(Name)
            button_main("1", "1", "0")
        End If
    End Sub

    Private Sub FormPopUpCompGroup_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        If is_menu = "1" Then
            FormMain.hide_rb()
        End If
    End Sub

    Private Sub GVGroupComp_DoubleClick(sender As Object, e As EventArgs) Handles GVGroupComp.DoubleClick
        If is_menu = "1" Then
            FormMasterCompGroupDet.id_comp_group = GVGroupComp.GetFocusedRowCellValue("id_comp_group").ToString
            FormMasterCompGroupDet.ShowDialog()
        End If
    End Sub

    Private Sub GVGroupComp_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GVGroupComp.RowCellClick
        If is_menu = "1" Then
            If e.Button = MouseButtons.Right Then
                PopupMenu.ShowPopup(Cursor.Position)

                If GVGroupComp.GetFocusedRowCellValue("id_comp").ToString = "" Then
                    BBIContact.Caption = "Add Contact"
                Else
                    BBIContact.Caption = "View/Edit Contact"
                End If
            End If
        End If
    End Sub

    Private Sub BBIContact_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBIContact.ItemClick
        If is_menu = "1" Then
            If GVGroupComp.GetFocusedRowCellValue("id_comp").ToString = "" Then
                FormMasterCompanySingle.id_company = "-1"
                FormMasterCompanySingle.id_comp_group_add = GVGroupComp.GetFocusedRowCellValue("id_comp_group").ToString
                FormMasterCompanySingle.ShowDialog()
            Else
                FormMasterCompanySingle.id_company = GVGroupComp.GetFocusedRowCellDisplayText("id_comp").ToString
                FormMasterCompanySingle.id_comp_group_add = GVGroupComp.GetFocusedRowCellValue("id_comp_group").ToString
                FormMasterCompanySingle.ShowDialog()
            End If
        End If
    End Sub
End Class