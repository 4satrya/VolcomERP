Public Class ClassShipInvoice
    Public id_invoice_ship As String = "-1"
    Public rmt As String = "249"

    Sub create(ByVal id_del As String)
        'cek ship price
        Dim qc As String = "SELECT o.id  AS `id_order`, o.sales_order_ol_shop_date AS `order_date`, o.shipping_price, o.sales_order_ol_shop_number AS `order_number`
        FROM tb_pl_sales_order_del d
        INNER JOIN tb_sales_order so ON so.id_sales_order = d.id_sales_order
        INNER JOIN tb_ol_store_order o ON o.id = so.id_sales_order_ol_shop
        WHERE d.id_pl_sales_order_del=" + id_del + " 
        AND o.shipping_price>0
        GROUP BY o.id "
        Dim dc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dc.Rows.Count > 0 Then
            'cek
            Dim qe As String = "SELECT * FROM tb_invoice_ship WHERE id_report='" + dc.Rows(0)("id_order").ToString + "' AND id_report_status!=5 "
            Dim de As DataTable = execute_query(qe, -1, True, "", "", "", "")
            If de.Rows.Count <= 0 Then
                'create invoice
                Dim qmain As String = "INSERT INTO tb_invoice_ship(id_comp_contact, id_acc_ar, id_report, number, created_date, due_date, start_period, end_period, value, id_report_status) 
                SELECT  cc.id_comp_contact, c.id_acc_ar, '" + dc.Rows(0)("id_order").ToString + "', '', NOW(),  
                DATE_ADD(DATE('" + DateTime.Parse(dc.Rows(0)("order_date").ToString).ToString("yyyy-MM-dd") + "'),INTERVAL IFNULL(sd.due,0) DAY) AS sales_pos_due_date, '" + DateTime.Parse(dc.Rows(0)("order_date").ToString).ToString("yyyy-MM-dd") + "' AS `start_period`, '" + DateTime.Parse(dc.Rows(0)("order_date").ToString).ToString("yyyy-MM-dd") + "' AS `end_period`,
                '" + decimalSQL(dc.Rows(0)("shipping_price").ToString) + "' AS `value`, 1 AS `id_report_status`
                FROM  tb_m_comp_volcom_ol s 
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp = s.id_store AND cc.is_default=1
                INNER JOIN tb_m_comp c ON c.id_comp = s.id_store
                LEFT JOIN tb_store_due sd ON sd.id_comp = c.id_comp
                WHERE s.id_design_cat=1; SELECT LAST_INSERT_ID(); "
                id_invoice_ship = execute_query(qmain, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number('" + id_invoice_ship + "', '249');", True, "", "", "", "")
                'detil
                Dim qdet As String = "INSERT INTO tb_invoice_ship_det(id_invoice_ship, id_acc, value, note)
                SELECT '" + id_invoice_ship + "', o.id_acc_pendapatan_shipping, '" + decimalSQL(dc.Rows(0)("shipping_price").ToString) + "', 'Shipping #" + dc.Rows(0)("order_number").ToString + "'
                FROM tb_opt_accounting o "
                execute_non_query(qdet, True, "", "", "", "")
                'submit prepared
                Dim id_user_prepared_inv As String = get_opt_acc_field("invoice_prepared_by")
                submit_who_prepared(rmt, id_invoice_ship, id_user_prepared_inv)
                'nonaktif mark
                Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", "249", id_invoice_ship)
                execute_non_query(queryrm, True, "", "", "", "")
                'set journal
                setJournal()
                'set completed
                Dim query_stt As String = "UPDATE tb_invoice_ship SET id_report_status=6 WHERE id_invoice_ship='" + id_invoice_ship + "'"
                execute_non_query(query_stt, True, "", "", "", "")
            End If
        End If
    End Sub

    Sub setJournal()
        Dim id_bill_type As String = "29"
        'select user prepared 
        Dim qu As String = "SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type=" + rmt + " AND rm.id_report='" + id_invoice_ship + "' AND rm.id_report_status=1 "
        Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
        Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
        Dim report_number As String = du.Rows(0)("report_number").ToString

        'main journal
        Dim query As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, date_reference, acc_trans_note, id_report_status) 
        SELECT '',s.number," + id_bill_type + ",rm.id_user, s.created_date,s.end_period, 'Auto Posting', '6'
        FROM tb_invoice_ship s
        INNER JOIN tb_report_mark rm ON rm.id_report = s.id_invoice_ship AND rm.report_mark_type=" + rmt + " AND rm.id_report_status=1
        WHERE s.id_invoice_ship=" + id_invoice_ship + "; SELECT LAST_INSERT_ID(); "
        Dim id As String = execute_query(query, 0, True, "", "", "", "")
        execute_non_query("CALL gen_number(" + id + ",36)", True, "", "", "", "")

        'det journal
        Dim qd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, id_status_open) 
        SELECT '" + id + "', m.id_acc_ar, cc.id_comp, m.`value` AS `debit`, 0 AS `credit`, d.note, m.report_mark_type, m.id_invoice_ship, m.`number`,1 
        FROM tb_invoice_ship_det d
        INNER JOIN tb_invoice_ship m ON m.id_invoice_ship = d.id_invoice_ship 
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = m.id_comp_contact
        WHERE d.id_invoice_ship=" + id_invoice_ship + "
        UNION ALL 
        SELECT '" + id + "', d.id_acc, cc.id_comp, 0 AS `debit`, d.`value` AS `credit`, d.note, m.report_mark_type, m.id_invoice_ship, m.`number`,1 
        FROM tb_invoice_ship_det d
        INNER JOIN tb_invoice_ship m ON m.id_invoice_ship = d.id_invoice_ship 
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = m.id_comp_contact
        WHERE d.id_invoice_ship=" + id_invoice_ship + " "
        execute_non_query(qd, True, "", "", "", "")
    End Sub

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

        Dim query As String = "SELECT s.id_invoice_ship, s.id_comp_contact, c.id_comp, c.comp_number, c.comp_name,
        s.id_acc_ar, coa.acc_name, coa.acc_description, s.id_report, od.sales_order_ol_shop_number AS `order_number`, od.customer_name, s.number, 
        s.created_date, s.due_date, s.start_period, s.end_period, s.value AS `amount`, 
        s.id_report_status, rs.report_status, s.is_close_rec, s.report_mark_type, rmt.report_mark_type_name
        FROM tb_invoice_ship s
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = s.id_comp_contact
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_a_acc coa ON coa.id_acc = s.id_acc_ar
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = s.id_report_status
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type = s.report_mark_type
        INNER JOIN tb_ol_store_order od ON od.id = s.id_report
        WHERE s.id_invoice_ship>0 "
        query += condition + " "
        query += "ORDER BY s.id_invoice_ship " + order_type
        Return query
    End Function
End Class
