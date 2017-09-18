Public Class ClassDelEmpty
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

        Dim query As String = "SELECT del.id_wh_del_empty, del.wh_del_empty_number, 
        del.id_store_contact_from, cc.id_comp, c.comp_number, c.comp_name, CONCAT(c.comp_number,' - ', c.comp_name) AS `store`, c.address_primary, 
        COUNT(deld.id_wh_del_empty_det) AS `total`,
        del.wh_del_empty_date, del.wh_del_empty_note, del.id_report_status, rs.report_status, del.is_fix, del.last_update, emp.employee_name as `last_user`, 'No' AS `is_select`
        FROM tb_wh_del_empty del
        LEFT JOIN tb_wh_del_empty_det deld ON deld.id_wh_del_empty = del.id_wh_del_empty
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = del.id_store_contact_from
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_m_user u ON u.id_user = del.last_update_by
        INNER JOIN tb_m_employee emp ON emp.id_employee = u.id_employee
        INNER JOIN tb_lookup_report_status rs ON del.id_report_status = rs.id_report_status
        WHERE del.id_wh_del_empty>0 "
        query += condition + " "
        query += "GROUP BY del.id_wh_del_empty  "
        query += "ORDER BY del.id_wh_del_empty " + order_type
        Return query
    End Function

    Public Sub changeStatus(ByVal id_report_par As String, ByVal id_status_reportx_par As String)
        If id_status_reportx_par = "5" Then
            Dim query As String = "INSERT INTO tb_storage_fg_prob(id_store, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
		    SELECT c.id_comp,1, ed.id_product, d.design_cop,111, '" + id_report_par + "',1, NOW(),'',2 
		    FROM tb_wh_del_empty_det ed
		    INNER JOIN tb_wh_del_empty e ON e.id_wh_del_empty = ed.id_wh_del_empty
		    INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = e.id_store_contact_from
		    INNER JOIN tb_m_comp c ON c.id_comp= cc.id_comp
		    INNER JOIN tb_m_product p ON p.id_product = ed.id_product
		    INNER JOIN tb_m_design d ON d.id_design = p.id_design
		    WHERE ed.id_wh_del_empty = " + id_report_par + " "
            execute_non_query(query, True, "", "", "", "")
        ElseIf id_status_reportx_par = "6" Then
            'action
            Dim query As String = "INSERT INTO tb_storage_fg_prob(id_store, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
		    SELECT c.id_comp,1, ed.id_product, d.design_cop,111, '" + id_report_par + "',1, NOW(),'',2 
		    FROM tb_wh_del_empty_det ed
		    INNER JOIN tb_wh_del_empty e ON e.id_wh_del_empty = ed.id_wh_del_empty
		    INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = e.id_store_contact_from
		    INNER JOIN tb_m_comp c ON c.id_comp= cc.id_comp
		    INNER JOIN tb_m_product p ON p.id_product = ed.id_product
		    INNER JOIN tb_m_design d ON d.id_design = p.id_design
		    WHERE ed.id_wh_del_empty = " + id_report_par + "
            UNION ALL
            SELECT c.id_comp,2, ed.id_product, d.design_cop,111, '" + id_report_par + "',1, NOW(),'',1 
		    FROM tb_wh_del_empty_det ed
		    INNER JOIN tb_wh_del_empty e ON e.id_wh_del_empty = ed.id_wh_del_empty
		    INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = e.id_store_contact_from
		    INNER JOIN tb_m_comp c ON c.id_comp= cc.id_comp
		    INNER JOIN tb_m_product p ON p.id_product = ed.id_product
		    INNER JOIN tb_m_design d ON d.id_design = p.id_design
		    WHERE ed.id_wh_del_empty = " + id_report_par + " "
            execute_non_query(query, True, "", "", "", "")
        End If
        Dim queryupd As String = String.Format("UPDATE tb_wh_del_empty SET id_report_status='{0}', last_update=NOW(), last_update_by=" + id_user + " WHERE id_wh_del_empty ='{1}'", id_status_reportx_par, id_report_par)
        execute_non_query(queryupd, True, "", "", "", "")
    End Sub
End Class
