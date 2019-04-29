Public Class ClassSalesInv
    Public Function queryMain(ByVal condition_param As String, ByVal order_type_param As String) As String
        Dim query As String = "CALL view_sales_inv_main('" + condition_param + "', '" + order_type_param + "') "
        Return query
    End Function

    Public Function queryMainReport(ByVal condition_param As String, ByVal order_type_param As String) As String
        Dim query As String = "CALL view_sales_inv_report('" + condition_param + "', '" + order_type_param + "') "
        Return query
    End Function

    Public Function queryDetail(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_sales_pos('" + id_report_param + "')"
        Return query
    End Function

    Public Function queryDetailReport(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_sales_pos_report_new('" + id_report_param + "')"
        Return query
    End Function

    ' ----------------------
    'for stock out
    ' ----------------------
    Public Sub reservedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'reserved stock
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
        SELECT getCompByContact(p.id_store_contact_from, 4), 2, pd.id_product, IFNULL(dsg.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.sales_pos_det_qty, NOW(), '', 2
        FROM tb_sales_pos p
        INNER JOIN tb_sales_pos_det pd ON pd.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_sales_pos=" + id_report_param + " AND pd.sales_pos_det_qty>0 "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub cancelReservedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'cancelled reserved stock
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
        SELECT getCompByContact(p.id_store_contact_from, 4), 1, pd.id_product, IFNULL(dsg.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.sales_pos_det_qty, NOW(), '', 2
        FROM tb_sales_pos p
        INNER JOIN tb_sales_pos_det pd ON pd.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_sales_pos=" + id_report_param + " AND pd.sales_pos_det_qty>0 "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub completedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'completed stock
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
        SELECT getCompByContact(p.id_store_contact_from, 4), 1, pd.id_product, IFNULL(dsg.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.sales_pos_det_qty, NOW(), '', 2
        FROM tb_sales_pos p
        INNER JOIN tb_sales_pos_det pd ON pd.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_sales_pos=" + id_report_param + " AND pd.sales_pos_det_qty>0 
        UNION ALL 
        SELECT getCompByContact(p.id_store_contact_from, 4), 2, pd.id_product, IFNULL(dsg.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.sales_pos_det_qty, NOW(), '', 1
        FROM tb_sales_pos p
        INNER JOIN tb_sales_pos_det pd ON pd.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_sales_pos=" + id_report_param + " AND pd.sales_pos_det_qty>0 "
        execute_non_query(query, True, "", "", "", "")

        'posting journal
        postingJournal(id_report_param, report_mark_type_param)
    End Sub

    Public Sub postingJournal(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        Dim id_bill_type As String = "NULL "
        If report_mark_type_param = "48" Or report_mark_type_param = "54" Or report_mark_type_param = "117" Then
            id_bill_type = "19"
        ElseIf report_mark_type_param = "66" Or report_mark_type_param = "67" Or report_mark_type_param = "118" Then
            id_bill_type = "13"
        ElseIf report_mark_type_param = "132" Then
            id_bill_type = "27"
        End If

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
        Dim qd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, id_status_open) 
        SELECT '" + id + "', d.id_acc, d.id_comp, d.qty, d.debit, d.credit, d.acc_trans_det_note, d.report_mark_type, d.id_report, d.report_number, '1'
        FROM tb_a_acc_trans_draft d
        WHERE d.report_mark_type='" + report_mark_type_param + "' AND d.id_report='" + id_report_param + "' "
        execute_non_query(qd, True, "", "", "", "")

        'update status draft
        Dim qupd As String = "UPDATE tb_a_acc_trans_draft SET id_status_open=2 WHERE report_mark_type='" + report_mark_type_param + "' AND id_report='" + id_report_param + "'  "
        execute_non_query(qupd, True, "", "", "", "")
    End Sub

    Public Sub completedStockMissingStaff(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'completed stock
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
        SELECT getCompByContact(p.id_store_contact_from, 4), 1, pd.id_product, IFNULL(dsg.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.sales_pos_det_qty, NOW(), '', 2
        FROM tb_sales_pos p
        INNER JOIN tb_sales_pos_det pd ON pd.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_sales_pos=" + id_report_param + " AND pd.sales_pos_det_qty>0 
        UNION ALL 
        SELECT getCompByContact(p.id_store_contact_from, 4), 2, pd.id_product, IFNULL(dsg.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.sales_pos_det_qty, NOW(), '', 1
        FROM tb_sales_pos p
        INNER JOIN tb_sales_pos_det pd ON pd.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_sales_pos=" + id_report_param + " AND pd.sales_pos_det_qty>0 
        UNION ALL 
        SELECT getCompByContact(p.id_comp_contact_bill, 4), 1, pd.id_product, IFNULL(dsg.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.sales_pos_det_qty, NOW(), '', 1
        FROM tb_sales_pos p
        INNER JOIN tb_sales_pos_det pd ON pd.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_sales_pos=" + id_report_param + " AND pd.sales_pos_det_qty>0 
        UNION ALL
        SELECT getCompByContact(p.id_comp_contact_bill, 4), 2, pd.id_product, IFNULL(dsg.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.sales_pos_det_qty, NOW(), '', 1
        FROM tb_sales_pos p
        INNER JOIN tb_sales_pos_det pd ON pd.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_sales_pos=" + id_report_param + " AND pd.sales_pos_det_qty>0  "
        execute_non_query(query, True, "", "", "", "")

        'posting
        postingJournal(id_report_param, report_mark_type_param)
    End Sub

    'Public Sub completeReservedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
    '    'complete
    '    Dim query_compl As String = "CALL view_sales_pos('" + id_report_param + "') "
    '    Dim dt_compl As DataTable = execute_query(query_compl, -1, True, "", "", "", "")

    '    Dim stc_remove_rsv As ClassStock = New ClassStock()
    '    Dim stc_compl As ClassStock = New ClassStock()
    '    For s As Integer = 0 To dt_compl.Rows.Count - 1
    '        stc_remove_rsv.prepInsStockFG(dt_compl.Rows(s)("id_wh_drawer").ToString, "1", dt_compl.Rows(s)("id_product").ToString, decimalSQL(dt_compl.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sales_pos_det_qty").ToString), "", "2")
    '        stc_compl.prepInsStockFG(dt_compl.Rows(s)("id_wh_drawer").ToString, "2", dt_compl.Rows(s)("id_product").ToString, decimalSQL(dt_compl.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sales_pos_det_qty").ToString), "", "1")
    '    Next
    '    stc_remove_rsv.insStockFG()
    '    stc_compl.insStockFG()
    'End Sub

    '' ----------------------
    ''for stock in / creedit note
    '' ----------------------
    Public Sub completeInStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'completed stock
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
        SELECT getCompByContact(p.id_store_contact_from, 4), 1, pd.id_product, IFNULL(dsg.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", (pd.sales_pos_det_qty*-1), NOW(), '', 1
        FROM tb_sales_pos p
        INNER JOIN tb_sales_pos_det pd ON pd.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_sales_pos=" + id_report_param + " AND pd.sales_pos_det_qty!=0 "
        execute_non_query(query, True, "", "", "", "")

        'posting journal
        postingJournal(id_report_param, report_mark_type_param)
    End Sub


    Public Sub cancellUnique(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        Dim id_type_unik As String = ""
        Dim qty_unik As String = ""
        Dim col_unik As String = ""

        If report_mark_type_param = "48" Or report_mark_type_param = "54" Or report_mark_type_param = "116" Or report_mark_type_param = "117" Then
            id_type_unik = "2"
            qty_unik = "1"
            col_unik = "id_sales_pos_det_counting"
        End If

        Dim query As String = "INSERT INTO tb_m_unique_code(id_comp, id_product, " + col_unik + ", id_type, unique_code, id_design_price, design_price, qty, is_unique_report, input_date)  
        SELECT cc.id_comp, c.id_product, c.id_sales_pos_det_counting, '" + id_type_unik + "', c.full_code, c.id_design_price, c.design_price, '" + qty_unik + "', 1, NOW() 
        FROM tb_sales_pos pos
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = pos.id_store_contact_from
        INNER JOIN tb_sales_pos_det_counting c ON c.id_sales_pos = pos.id_sales_pos
        WHERE pos.id_sales_pos=" + id_report_param + " "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub insertUnique(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        Dim id_type_unik As String = ""
        Dim qty_unik As String = ""
        Dim col_unik As String = ""

        If report_mark_type_param = "48" Or report_mark_type_param = "54" Or report_mark_type_param = "116" Or report_mark_type_param = "117" Then
            id_type_unik = "2"
            qty_unik = "-1"
            col_unik = "id_sales_pos_det_counting"
        ElseIf report_mark_type_param = "66" Or report_mark_type_param = "67" Or report_mark_type_param = "118" Then
            id_type_unik = "3"
            qty_unik = "1"
            col_unik = "id_sales_pos_det_counting_cn"
        End If

        Dim query As String = "INSERT INTO tb_m_unique_code(id_comp, id_product, " + col_unik + ", id_type, unique_code, id_design_price, design_price, qty, is_unique_report, input_date)  
        SELECT cc.id_comp, c.id_product, c.id_sales_pos_det_counting, '" + id_type_unik + "', c.full_code, c.id_design_price, c.design_price, '" + qty_unik + "', 1, NOW() 
        FROM tb_sales_pos pos
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = pos.id_store_contact_from
        INNER JOIN tb_sales_pos_det_counting c ON c.id_sales_pos = pos.id_sales_pos
        WHERE pos.id_sales_pos=" + id_report_param + " "
        execute_non_query(query, True, "", "", "", "")
    End Sub

End Class
