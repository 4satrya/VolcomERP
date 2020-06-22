Public Class ClassSalesBranch
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

        Dim query As String = "SELECT b.id_sales_branch, b.id_coa_tag, ct.tag_description AS `unit`, b.created_date, b.transaction_date, 
        b.id_report_status, stt.report_status, b.note, b.`value` 
        FROM tb_sales_branch b
        INNER JOIN tb_coa_tag ct ON ct.id_coa_tag = b.id_coa_tag
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = b.id_report_status
        WHERE b.id_sales_branch>0 "
        query += condition + " "
        query += "ORDER BY b.id_sales_branch " + order_type
        Return query
    End Function
End Class
