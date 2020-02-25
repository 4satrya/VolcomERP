Public Class ClassBudgetProdDemand
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

        Dim query As String = "SELECT b.id_b_prod_demand_propose, b.`year`, STR_TO_DATE(CONCAT(b.`year`,'-01-01'),'%Y-%m-%d') AS `year_input`, b.`number`, b.created_date, b.note, b.is_confirm, b.id_report_status, rs.report_status 
        FROM tb_b_prod_demand_propose b
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = b.id_report_status
        WHERE b.id_b_prod_demand_propose>0 "
        query += condition + " "
        query += "ORDER BY b.id_b_prod_demand_propose " + order_type
        Return query
    End Function
End Class
