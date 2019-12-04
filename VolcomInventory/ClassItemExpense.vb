Public Class ClassItemExpense
    Public q_join As String = ""
    Public q_acc As String = ""

    Public Function queryMain(ByVal condition As String, ByVal order_type As String, ByVal is_for_payment As Boolean) As String
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

        Dim col_dp As String = ""
        Dim join_dp As String = ""
        Dim col_pay_pending = ""
        Dim join_pay_pending = ""
        If is_for_payment Then
            'dp
            col_dp = ", IFNULL(edp.total,0) AS `total_dp` "
            join_dp = "LEFT JOIN (
                SELECT pd.id_report, SUM(pd.`value`) AS total 
                FROM tb_pn p
                INNER JOIN tb_pn_det pd ON pd.id_pn = p.id_pn
                WHERE p.report_mark_type=157 AND p.id_report_status!=5 AND p.id_pay_type=1
                GROUP BY pd.id_report
            ) edp ON edp.id_report = e.id_item_expense AND e.is_pay_later=1 "

            'payment pending
            col_pay_pending = ", IFNULL(payment_pending.jml,0) AS `total_pending` "
            join_pay_pending = "LEFT JOIN (
                SELECT COUNT(pyd.id_report) as jml,pyd.id_report FROM `tb_pn_det` pyd
                INNER JOIN tb_pn py ON py.id_pn=pyd.id_pn AND py.id_report_status!=6 AND py.id_report_status!=5 AND py.report_mark_type='157'
                GROUP BY pyd.id_report
            ) payment_pending ON payment_pending.id_report = e.id_item_expense AND e.is_pay_later=1 "
        End If

        Dim query As String = "SELECT e.id_item_expense,157 AS report_mark_type, IFNULL(e.id_comp,0) AS `id_comp`, c.comp_number, c.comp_name, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp`, e.`number`, e.created_date, e.due_date, e.created_by, emp.employee_name AS `created_by_name`, e.id_acc_from, e.id_payment_purchasing, e.id_report_status, stt.report_status, IF(e.id_report_status!=6, '-', IF(e.is_pay_later=2,'Paid', IF(e.is_open=2, 'Paid', IF(DATE(NOW())>e.due_date,'Overdue', 'Open')))) AS `paid_status`, e.note, e.is_pay_later, e.is_open,
        e.sub_total, e.vat_total,e.total, IFNULL(er.total,0) AS `total_paid`, IF(e.is_pay_later=1,(e.total-IFNULL(er.total,0)),0) AS `balance`, 'No' AS `is_select`, DATEDIFF(e.`due_date`,NOW()) AS due_days
        ,cf.id_comp AS `id_comp_default`, cf.comp_number as `comp_number_default`
        " + col_dp + "
        " + col_pay_pending + "
        " + q_acc + "
        FROM tb_item_expense e
        INNER JOIN tb_m_comp cf ON cf.id_comp=1
        INNER JOIN tb_m_user u ON u.id_user = e.created_by
        INNER JOIN tb_m_employee emp ON emp.id_employee = u.id_employee
        INNER JOIN tb_a_acc pfr ON pfr.id_acc = e.id_acc_from
        INNER JOIN tb_lookup_payment_purchasing pp ON pp.id_payment_purchasing = e.id_payment_purchasing
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = e.id_report_status
        LEFT JOIN (
            SELECT pd.id_report, SUM(pd.`value`) AS total 
            FROM tb_pn p
            INNER JOIN tb_pn_det pd ON pd.id_pn = p.id_pn
            WHERE p.report_mark_type=157 AND p.id_report_status!=5
            GROUP BY pd.id_report
        ) er ON er.id_report = e.id_item_expense AND e.is_pay_later=1
        " + join_dp + "
        " + join_pay_pending + "
        LEFT JOIN tb_m_comp c ON c.id_comp = e.id_comp 
        " + q_join + "
        WHERE e.id_item_expense>0 "
        query += condition + " "
        query += "ORDER BY e.id_item_expense " + order_type
        Return query
    End Function
End Class
