﻿Public Class ClassPromoCollection
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

        Dim query As String = "SELECT p.id_ol_promo_collection, p.id_promo, prm.promo, p.`number`, p.created_date, 
        p.created_by, e.employee_name AS `created_by_name`,
        p.start_period, p.end_period, p.id_report_status, stt.report_status, p.note
        FROM tb_ol_promo_collection p
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = p.id_report_status
        INNER JOIN tb_promo prm ON prm.id_promo = p.id_promo
        INNER JOIN tb_m_user u ON u.id_user = p.created_by
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        WHERE p.id_ol_promo_collection>0 "
        query += condition + " "
        query += "ORDER BY p.id_ol_promo_collection " + order_type
        Return query
    End Function
End Class
