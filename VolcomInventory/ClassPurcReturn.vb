Public Class ClassPurcReturn
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

        Dim query As String = "SELECT ret.id_purc_return, ret.id_purc_order, po.purc_order_number,
        po.id_comp_contact, c.id_comp AS `id_vendor`, c.comp_number AS `vendor_code`, c.comp_name AS `vendor_name`, CONCAT(c.comp_number,' - ', c.comp_name) AS `vendor`,
        ret.`number`, ret.created_date, ret.created_by, ec.employee_name AS `created_by_name`,
        ret.id_report_status, rs.report_status, ret.note
        FROM tb_purc_return ret
        INNER JOIN tb_purc_order po ON po.id_purc_order = ret.id_purc_order
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = po.id_comp_contact
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = ret.id_report_status
        INNER JOIN tb_m_user uc ON uc.id_user = ret.created_by
        INNER JOIN tb_m_employee ec ON ec.id_employee = uc.id_employee
        WHERE ret.id_purc_return>0  "
        query += condition + " "
        query += "ORDER BY ret.id_purc_return " + order_type
        Return query
    End Function

    Public Sub updateStock(ByVal id_purc_return As String, ByVal id_storage_cat As String)
        Dim query As String = "INSERT INTO tb_storage_item (id_departement, id_storage_category,id_item, `value`, report_mark_type, id_report, storage_item_qty, storage_item_datetime, id_stock_status)
        SELECT req.id_departement, " + id_storage_cat + ",rd.id_item, getAvgCost(rd.id_item) AS `cost`, 152, rd.id_purc_return,rd.qty, NOW(),1
        FROM tb_purc_return_det rd
        INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
        INNER JOIN tb_purc_req_det reqd ON reqd.id_purc_req_det = pod.id_purc_req_det
        INNER JOIN tb_purc_req req ON req.id_purc_req = reqd.id_purc_req
        WHERE rd.id_purc_return=" + id_purc_return + " "
        execute_non_query(query, True, "", "", "", "")
    End Sub
End Class
