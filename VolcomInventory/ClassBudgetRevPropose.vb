Public Class ClassBudgetRevPropose
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

        Dim query As String = "SELECT rp.id_b_revenue_propose, rp.`number`, rp.year, rp.total, rp.created_date, rp.id_created_user, e.employee_name AS `created_user`, 
        rp.id_report_status, rs.report_status, rp.note, rp.is_confirm
        FROM tb_b_revenue_propose rp
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = rp.id_report_status
        INNER JOIN tb_m_user u ON u.id_user = rp.id_created_user
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        WHERE rp.id_b_revenue_propose>0 "
        query += condition + " "
        query += "ORDER BY rp.id_b_revenue_propose " + order_type
        Return query
    End Function

    Public Function queryMainRev(ByVal condition As String, ByVal order_type As String) As String
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

        Dim query As String = "SELECT p.id_b_revenue_revision, p.number, 
        p.created_date, e.employee_name AS `created_user`, p.year, p.value_expense_total, p.id_report_status, rs.report_status, p.note, p.is_confirm
        FROM tb_b_revenue_revision p
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = p.id_report_status
        INNER JOIN tb_m_user u ON u.id_user = p.id_created_user
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        WHERE p.id_b_revenue_revision>0 "
        query += condition + " "
        query += "ORDER BY p.id_b_revenue_revision " + order_type
        Return query
    End Function
End Class
