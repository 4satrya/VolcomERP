﻿Public Class ClassRequestRetOLStore
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

        Dim query As String = "SELECT r.id_ol_store_ret_req, r.id_comp_group, cg.description AS `comp_group_name`, r.sales_order_ol_shop_number, r.`number`, r.receive_cust_date,
        r.ret_req_number, r.ret_req_date, r.created_date, r.created_by, e.employee_name AS `created_by_name`, r.updated_date, r.updated_by, eu.employee_name AS `updated_by_name`,
        r.awb_number, r.note, r.id_report_status, stt.report_status, (SELECT COUNT(*) FROM tb_ol_store_ret_req_det WHERE id_ol_store_ret_req = r.id_ol_store_ret_req) AS qty_fisik, r.is_confirm
        FROM tb_ol_store_ret_req r
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = r.id_comp_group
        INNER JOIN tb_m_user u ON u.id_user = r.created_by
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        INNER JOIN tb_m_user uu ON uu.id_user = r.updated_by
        INNER JOIN tb_m_employee eu ON eu.id_employee = uu.id_employee
        WHERE r.id_ol_store_ret_req>0 "
        query += condition + " "
        query += "ORDER BY r.id_ol_store_ret_req " + order_type
        Return query
    End Function
End Class
