Public Class ClassItemDel
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

        Dim query As String = "SELECT del.id_item_del, del.id_item_req, req.`number` AS `req_number`,  
        req.created_by AS `requested_by`, er.employee_name AS `requested_by_name`, 
        req.id_departement, dept.departement, del.`number`, del.created_date, 
        del.created_by, ed.employee_name AS `created_by_name`, del.note, del.id_report_status, stt.report_status, req.is_for_store
        FROM tb_item_del del
        INNER JOIN tb_item_req req ON req.id_item_req = del.id_item_req
        INNER JOIN tb_m_departement dept ON dept.id_departement = req.id_departement
        INNER JOIN tb_m_user ur ON ur.id_user = req.created_by
        INNER JOIN tb_m_employee er ON er.id_employee = ur.id_employee
        INNER JOIN tb_m_user ud ON ud.id_user = del.created_by
        INNER JOIN tb_m_employee ed ON ed.id_employee = ud.id_employee
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = del.id_report_status
        WHERE del.id_item_del>0 "
        query += condition + " "
        query += "ORDER BY del.id_item_del " + order_type
        Return query
    End Function
End Class
