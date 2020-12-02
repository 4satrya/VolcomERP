Public Class FormListStore
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"

    Private Sub FormListStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_company()
    End Sub

    Sub view_company()
        Dim q As String = ""

        q = "SELECT tb_m_comp.id_comp as id_comp, tb_m_comp.comp_number as comp_number, tb_m_comp.comp_name as comp_name, tb_m_comp.address_primary as address_primary, tb_m_comp.is_active as is_active, tb_m_comp_cat.comp_cat_name as company_category, (SELECT comp_status FROM tb_lookup_comp_status WHERE tb_m_comp.is_active = id_comp_status) AS comp_status, tb_m_comp_contact.contact_person, tb_m_comp_contact.contact_number, tb_m_comp_contact.email AS contact_email, tb_m_sub_district.sub_district
            FROM tb_m_comp, tb_m_comp_cat, (SELECT * FROM tb_m_comp_contact WHERE is_default = 1) AS tb_m_comp_contact, tb_m_sub_district WHERE tb_m_comp.id_comp_cat = tb_m_comp_cat.id_comp_cat AND tb_m_comp.id_comp = tb_m_comp_contact.id_comp AND tb_m_sub_district.id_sub_district = tb_m_comp.id_sub_district
            AND tb_m_comp.id_comp_cat='6'
            ORDER BY comp_name"

        Dim data As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCCompany.DataSource = data
        GVCompany.BestFitColumns()
    End Sub

    Private Sub FormListStore_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormListStore_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class