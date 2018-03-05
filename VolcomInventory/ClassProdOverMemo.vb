Public Class ClassProdOverMemo
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

        Dim query As String = "SELECT m.id_prod_over_memo, m.memo_number, m.created_date, m.lead_time, ADDTIME(m.created_date,CONCAT(m.lead_time,':00:00')) AS `expired_date`, 
        m.id_report_status, rs.report_status, m.memo_note
        FROM tb_prod_over_memo m
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = m.id_report_status
        WHERE m.id_prod_over_memo>0 "
        query += condition + " "
        query += "GROUP BY m.id_prod_over_memo "
        query += "ORDER BY m.id_prod_over_memo " + order_type
        Return query
    End Function
End Class