Public Class FormMasterCompany
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bcontact_active As String = "1"

    Private Sub FormCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        apply_skin()
        view_company()
    End Sub

    Sub view_company()
        Dim data As DataTable = execute_query("
            SELECT tb_m_comp.id_comp as id_comp, tb_m_comp.comp_number as comp_number, tb_m_comp.comp_name as comp_name, tb_m_comp.address_primary as address_primary, tb_m_comp.is_active as is_active, tb_m_comp_cat.comp_cat_name as company_category, (SELECT comp_status FROM tb_lookup_comp_status WHERE tb_m_comp.is_active = id_comp_status) AS comp_status, tb_m_comp_contact.contact_person, tb_m_comp_contact.contact_number, tb_m_comp_contact.email AS contact_email
            FROM tb_m_comp, tb_m_comp_cat, (SELECT * FROM tb_m_comp_contact WHERE is_default = 1) AS tb_m_comp_contact WHERE tb_m_comp.id_comp_cat = tb_m_comp_cat.id_comp_cat AND tb_m_comp.id_comp = tb_m_comp_contact.id_comp
            ORDER BY comp_name
        ", -1, True, "", "", "", "")
        GCCompany.DataSource = data
        If data.Rows.Count > 0 Then
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            '
            bcontact_active = "1"
            button_main_ext("1", bcontact_active)
        Else
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            '
            bcontact_active = "0"
            button_main_ext("1", bcontact_active)
        End If
    End Sub

    Private Sub FormCompany_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterCompany_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
        button_main_ext("1", bcontact_active)
    End Sub

    Private Sub FormMasterCompany_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVCompany_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVCompany.DoubleClick
        If GVCompany.RowCount > 0 And GVCompany.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub
End Class