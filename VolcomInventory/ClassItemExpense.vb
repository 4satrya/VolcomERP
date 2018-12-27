﻿Public Class ClassItemExpense
    Public Function queryMain(ByVal condition As String, ByVal order_type As String, ByVal get_total_dp As Boolean) As String
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

        'dp
        Dim col_dp As String = ""
        Dim join_dp As String = ""
        If get_total_dp Then
            col_dp = ", IFNULL(edp.total,0) AS `total_dp` "
            join_dp = "LEFT JOIN (
                SELECT pd.id_report, SUM(pd.`value`) AS total 
                FROM tb_payment p
                INNER JOIN tb_payment_det pd ON pd.id_payment = p.id_payment
                WHERE p.report_mark_type=157 AND p.id_report_status!=5 AND p.id_pay_type=1
                GROUP BY pd.id_report
            ) edp ON edp.id_report = e.id_item_expense AND e.is_pay_later=1 "
        End If

        Dim query As String = "SELECT e.id_item_expense, IFNULL(e.id_comp,0) AS `id_comp`, c.comp_number, c.comp_name, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp`, e.`number`, e.created_date, e.due_date, e.created_by, emp.employee_name AS `created_by_name`, e.id_acc_from, e.id_payment_purchasing, e.id_report_status, stt.report_status, IF(e.id_report_status!=6, '-', IF(e.is_pay_later=2,'Paid', IF(e.is_open=2, 'Close', IF(NOW()>e.due_date,'Overdue', 'Open')))) AS `paid_status`, e.note, e.is_pay_later,
        e.sub_total, e.vat_total,e.total, IFNULL(er.total,0) AS `total_paid`, IF(e.is_pay_later=1,(e.total-IFNULL(er.total,0)),0) AS `balance`, 'No' AS `is_select`
        " + col_dp + "
        FROM tb_item_expense e
        INNER JOIN tb_m_user u ON u.id_user = e.created_by
        INNER JOIN tb_m_employee emp ON emp.id_employee = u.id_employee
        INNER JOIN tb_a_acc pfr ON pfr.id_acc = e.id_acc_from
        INNER JOIN tb_lookup_payment_purchasing pp ON pp.id_payment_purchasing = e.id_payment_purchasing
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = e.id_report_status
        LEFT JOIN (
            SELECT pd.id_report, SUM(pd.`value`) AS total 
            FROM tb_payment p
            INNER JOIN tb_payment_det pd ON pd.id_payment = p.id_payment
            WHERE p.report_mark_type=157 AND p.id_report_status!=5
            GROUP BY pd.id_report
        ) er ON er.id_report = e.id_item_expense AND e.is_pay_later=1
        " + join_dp + "
        LEFT JOIN tb_m_comp c ON c.id_comp = e.id_comp 
        WHERE e.id_item_expense>0 "
        query += condition + " "
        query += "ORDER BY e.id_item_expense " + order_type
        Return query
    End Function
End Class
