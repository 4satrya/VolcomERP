Public Class ClassStockTake
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
        Dim query As String = "SELECT st.id_st_period, st.st_period_date, st.st_period_created_date, st.st_period_created_date, 
        st.st_period_update_date, st.st_period_update_by, e.employee_name, st.st_period_description 
        FROM tb_st_period st 
        INNER JOIN tb_m_user u ON u.id_user = st.st_period_update_by
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        WHERE st.id_st_period>0 "
        query += condition + " "
        query += "ORDER BY st.id_st_period " + order_type
        Return query
    End Function
End Class
