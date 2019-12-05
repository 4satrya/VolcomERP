Public Class ClassFollowUpAR
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

        Dim query As String = "SELECT f.id_follow_up_ar, f.id_comp_group, cg.comp_group AS `group`, cg.description AS `group_description`,f.due_date, f.follow_up, 
        f.follow_up_result, f.follow_up_date, f.follow_up_input
        FROM tb_follow_up_ar f
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = f.id_comp_group
        WHERE f.id_follow_up_ar>0 "
        query += condition + " "
        query += "ORDER BY f.id_follow_up_ar " + order_type
        Return query
    End Function
End Class
