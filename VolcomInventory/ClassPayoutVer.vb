Public Class ClassPayoutVer
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

        Dim query As String = "SELECT v.id_list_payout_ver, v.`number`, v.id_web_order, v.order_number, v.checkout_id, 
        v.created_date, v.created_by, e.employee_name AS `created_by_name`, v.is_existing_order, v.type_ver
        FROM tb_list_payout_ver v
        INNER JOIN tb_m_user u ON u.id_user = v.created_by
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee 
        WHERE 1=1 "
        query += condition + " "
        query += "ORDER BY v.id_list_payout_ver " + order_type
        Return query
    End Function
End Class
