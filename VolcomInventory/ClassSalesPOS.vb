Public Class ClassSalesPOS
    Public Function queryMainNoStock(ByVal condition As String, ByVal order_type As String) As String
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

        Dim query As String = "SELECT ns.id_sales_pos_no_stock, ns.id_comp, c.comp_number, c.comp_name, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp`, 
        ns.`number`, ns.created_date, 
        ns.period_from, ns.period_until, ns.created_by, emp.employee_name AS `created_by_name`, ns.note, ns.id_report_status, stt.report_status
        FROM tb_sales_pos_no_stock ns
        INNER JOIN tb_m_comp c ON c.id_comp = ns.id_comp
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = ns.id_report_status
        INNER JOIN tb_m_user u ON u.id_user = ns.created_by
        INNER JOIN tb_m_employee emp ON emp.id_employee = u.id_employee
        WHERE ns.id_sales_pos_no_stock>0 "
        query += condition + " "
        query += "ORDER BY ns.id_sales_pos_no_stock " + order_type
        Return query
    End Function
End Class
