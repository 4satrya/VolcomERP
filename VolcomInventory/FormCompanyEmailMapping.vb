Public Class FormCompanyEmailMapping
    Private Sub FormCompanyEmailMapping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormCompanyEmailMapping_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormCompanyEmailMapping_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormCompanyEmailMapping_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub form_load()
        Dim query_store As String = "
            SELECT mm.id_mail_manage_mapping, CONCAT(mcg.comp_group, ' | ', mcg.description) AS comp_group, comp.comp_name, mcc.contact_person, mcc.position, mcc.email, rmt.report_mark_type_name, mmt.mail_member_type
            FROM tb_mail_manage_mapping AS mm
            LEFT JOIN tb_m_comp_group AS mcg ON mm.id_comp_group = mcg.id_comp_group
            LEFT JOIN tb_m_comp_contact AS mcc ON mm.id_comp_contact = mcc.id_comp_contact
            LEFT JOIN tb_m_comp AS comp ON mcc.id_comp = comp.id_comp
            LEFT JOIN tb_lookup_report_mark_type AS rmt ON mm.report_mark_type = rmt.report_mark_type
            LEFT JOIN tb_lookup_mail_member_type AS mmt ON mm.id_mail_member_type = mmt.id_mail_member_type
            ORDER BY mcg.comp_group ASC, comp.comp_name ASC, rmt.report_mark_type_name ASC, mmt.mail_member_type ASC
        "

        Dim data_store As DataTable = execute_query(query_store, -1, True, "", "", "", "")

        GCListStoreGroup.DataSource = data_store

        GVListStoreGroup.BestFitColumns()

        Dim query_int As String = "
            SELECT mm.id_mail_manage_mapping_intern, CONCAT(cgroup.comp_group, ' | ', cgroup.description) AS comp_group, CONCAT(memp.employee_code, ' | ', memp.employee_name) AS employee_name, memp.employee_position, memp.email_external, rmt.report_mark_type_name, mmt.mail_member_type
            FROM tb_mail_manage_mapping_intern AS mm
            LEFT JOIN tb_m_user AS musr ON mm.id_user = musr.id_user
            LEFT JOIN tb_m_employee AS memp ON musr.id_employee = memp.id_employee
            LEFT JOIN tb_m_comp_group AS cgroup ON mm.id_comp_group = cgroup.id_comp_group
            LEFT JOIN tb_lookup_report_mark_type AS rmt ON mm.report_mark_type = rmt.report_mark_type
            LEFT JOIN tb_lookup_mail_member_type AS mmt ON mm.id_mail_member_type = mmt.id_mail_member_type
            ORDER BY memp.employee_code ASC, rmt.report_mark_type_name ASC, mmt.mail_member_type ASC
        "

        Dim data_int As DataTable = execute_query(query_int, -1, True, "", "", "", "")

        GCListInternal.DataSource = data_int

        GVListInternal.BestFitColumns()
    End Sub
End Class