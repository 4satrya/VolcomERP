Public Class ClassEmpUniExpense
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

        Dim query As String = "SELECT e.id_emp_uni_ex, e.id_item_cat, cat.item_cat, e.id_departement, dept.departement, e.id_comp_contact, c.comp_number, c.comp_name, CONCAT(c.comp_number,' - ', c.comp_name) AS `comp`, 
        e.id_pl_sales_order_del, del.pl_sales_order_del_number, 
        e.emp_uni_ex_number, e.emp_uni_ex_date, e.emp_uni_ex_note, e.id_report_status , rs.report_status,
        so.id_so_status, so.id_emp_uni_budget, e.period_from, e.period_until
        FROM tb_emp_uni_ex e
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = e.id_comp_contact
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = e.id_report_status
        INNER JOIN tb_item_cat cat ON cat.id_item_cat = e.id_item_cat
        INNER JOIN tb_m_departement dept ON dept.id_departement = e.id_departement
        LEFT JOIN tb_pl_sales_order_del del ON del.id_pl_sales_order_del = e.id_pl_sales_order_del
        LEFT JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
        WHERE e.id_emp_uni_ex>0 "
        query += condition + " "
        query += "ORDER BY e.id_emp_uni_ex " + order_type
        Return query
    End Function


    Public Sub reservedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'reserved stock
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
        SELECT getCompByContact(p.id_comp_contact, 4), 2, pd.id_product, IFNULL(pd.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.qty, NOW(), '', 2
        FROM tb_emp_uni_ex p
        INNER JOIN tb_emp_uni_ex_det pd ON pd.id_emp_uni_ex = p.id_emp_uni_ex
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_emp_uni_ex=" + id_report_param + " AND pd.qty>0 "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub cancelReservedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'cancelled reserved stock
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
        SELECT getCompByContact(p.id_comp_contact, 4), 1, pd.id_product, IFNULL(pd.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.qty, NOW(), '', 2
        FROM tb_emp_uni_ex p
        INNER JOIN tb_emp_uni_ex_det pd ON pd.id_emp_uni_ex = p.id_emp_uni_ex
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_emp_uni_ex=" + id_report_param + " AND pd.qty>0 "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub completedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'completedReservedStock 
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
        SELECT getCompByContact(p.id_comp_contact, 4), 1, pd.id_product, IFNULL(pd.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.qty, NOW(), '', 2
        FROM tb_emp_uni_ex p
        INNER JOIN tb_emp_uni_ex_det pd ON pd.id_emp_uni_ex = p.id_emp_uni_ex
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_emp_uni_ex=" + id_report_param + " AND pd.qty>0 
        UNION ALL
        SELECT getCompByContact(p.id_comp_contact, 4), 2, pd.id_product, IFNULL(pd.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.qty, NOW(), '', 1
        FROM tb_emp_uni_ex p
        INNER JOIN tb_emp_uni_ex_det pd ON pd.id_emp_uni_ex = p.id_emp_uni_ex
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_emp_uni_ex=" + id_report_param + " AND pd.qty>0 "
        execute_non_query(query, True, "", "", "", "")

        'posting journal
        postingJournal(id_report_param, report_mark_type_param)
    End Sub

    Public Sub postingJournal(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        Dim id_bill_type As String = "27"


        'select user prepared 
        Dim qu As String = "SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type_param + " AND rm.id_report='" + id_report_param + "' AND rm.id_report_status=1 "
        Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
        Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
        Dim report_number As String = du.Rows(0)("report_number").ToString

        'main journal
        Dim query As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, acc_trans_note, id_report_status) 
        VALUES ('" + header_number_acc("1") + "','" + report_number + "'," + id_bill_type + ",'" + id_user_prepared + "', NOW(), 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
        Dim id As String = execute_query(query, 0, True, "", "", "", "")
        increase_inc_acc("1")

        'det journal
        Dim qd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, id_status_open, period_from, period_until) 
        SELECT '" + id + "', d.id_acc, d.id_comp, d.qty, d.debit, d.credit, d.acc_trans_det_note, d.report_mark_type, d.id_report, d.report_number, '1', d.period_from, d.period_until
        FROM tb_a_acc_trans_draft d
        WHERE d.report_mark_type='" + report_mark_type_param + "' AND d.id_report='" + id_report_param + "' "
        execute_non_query(qd, True, "", "", "", "")

        'update status draft
        Dim qupd As String = "UPDATE tb_a_acc_trans_draft SET id_status_open=2 WHERE report_mark_type='" + report_mark_type_param + "' AND id_report='" + id_report_param + "'  "
        execute_non_query(qupd, True, "", "", "", "")
    End Sub
End Class
