Public Class ClassPurcReceive
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT r.id_purc_rec, r.id_purc_order, po.purc_order_number, r.purc_rec_number, r.do_vendor_number,
        po.id_comp_contact, c.id_comp AS `id_vendor`, c.comp_number AS `vendor_code`, c.comp_name AS `vendor_name`, CONCAT(c.comp_number,' - ', c.comp_name) AS `vendor`,
        r.date_created, date_arrived, r.created_by, ec.employee_name AS `created_by_name`,
        r.last_update, r.last_update_by, eu.employee_name AS `last_update_by_name`,
        r.note, r.id_report_status, rs.report_status, r.is_confirm
        FROM tb_purc_rec r
        INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = po.id_comp_contact
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = r.id_report_status
        INNER JOIN tb_m_user uc ON uc.id_user = r.created_by
        INNER JOIN tb_m_employee ec ON ec.id_employee = uc.id_employee
        LEFT JOIN tb_m_user uu ON uu.id_user = r.last_update_by
        LEFT JOIN tb_m_employee eu ON eu.id_employee = uu.id_employee
        WHERE r.id_purc_rec>0 "
        query += condition + " "
        query += "ORDER BY r.id_purc_rec " + order_type
        Return query
    End Function
End Class