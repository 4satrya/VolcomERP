Public Class ClassSalesDelOrder
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

        Dim query As String = "SELECT a.id_pl_sales_order_del, a.id_sales_order, a.id_store_contact_to, d.id_commerce_type,(d.id_comp) AS `id_store`,(d.comp_name) AS store_name_to, (d.comp_number) AS store_number_to, CONCAT(d.comp_number, ' - ', d.comp_name) AS `store`, (d.address_primary) AS store_address_to, d.id_comp_group, dg.comp_group, d.id_so_type, a.id_report_status, f.report_status, "
        query += "a.pl_sales_order_del_note, a.pl_sales_order_del_date, DATE_FORMAT(a.pl_sales_order_del_date,'%Y-%m-%d') AS pl_sales_order_del_datex, a.pl_sales_order_del_number, b.sales_order_number, b.sales_order_ol_shop_number, IFNULL(b.customer_name,'') AS `customer_name`, "
        query += "DATE_FORMAT(a.pl_sales_order_del_date,'%d %M %Y') AS pl_sales_order_del_date, a.id_comp_contact_from,(wh.id_comp) AS `id_wh`, (wh.comp_number) AS `wh_number`,(wh.comp_name) AS `wh_name`, CONCAT(wh.comp_number, ' - ', wh.comp_name) AS `wh`, a.id_wh_drawer, drw.wh_drawer_code, drw.wh_drawer, cat.id_so_status, cat.so_status, "
        query += "a.last_update, le.employee_name AS `last_user`, ('No') AS `is_select`, IFNULL(det.`total`,0) AS `total`, rmg.`total_remaining`, eu.period_name, ut.uni_type, ube.employee_code, ube.employee_name, a.is_combine, IFNULL(a.id_combine,0) AS `id_combine`, IFNULL(comb.combine_number,'-') AS `combine_number`, b.sales_order_ol_shop_number, IFNULL(pb.prepared_by,'-') AS `prepared_by`, a.is_use_unique_code, "
        query += "IFNULL(dm.id_del_manifest,0) AS `id_del_manifest`, dm.`manifest_number` "
        query += "FROM tb_pl_sales_order_del a "
        query += "INNER JOIN tb_sales_order b ON a.id_sales_order = b.id_sales_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_comp_contact wh_cont ON wh_cont.id_comp_contact = a.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp wh ON wh.id_comp = wh_cont.id_comp "
        query += "INNER JOIN tb_lookup_so_status cat ON cat.id_so_status = b.id_so_status "
        query += "LEFT JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = a.id_wh_drawer "
        query += "LEFT JOIN( "
        query += "SELECT del.id_pl_sales_order_del, SUM(det.pl_sales_order_del_det_qty) AS `total` "
        query += "FROM tb_pl_sales_order_del del "
        query += "INNER JOIN tb_pl_sales_order_del_det det ON del.id_pl_sales_order_del = det.id_pl_sales_order_del "
        query += "GROUP BY del.id_pl_sales_order_del "
        query += ") det ON det.id_pl_sales_order_del = a.id_pl_sales_order_del "
        query += "LEFT JOIN ( "
        query += "SELECT so.id_sales_order, SUM(so_det.sales_order_det_qty) AS `total_so`, del.`total_del`, "
        query += "(SUM(so_det.sales_order_det_qty)-IFNULL(del.`total_del`,0)) AS `total_remaining` "
        query += "FROM tb_sales_order so "
        query += "INNER JOIN tb_sales_order_det so_det ON so_det.id_sales_order = so.id_sales_order "
        query += "LEFT JOIN ( "
        query += "SELECT del.id_sales_order, SUM(del_det.pl_sales_order_del_det_qty) AS `total_del` "
        query += "FROM tb_pl_sales_order_del del "
        query += "INNER JOIN tb_pl_sales_order_del_det del_det ON del_det.id_pl_sales_order_del=del.id_pl_sales_order_del "
        query += "WHERE del.id_report_status!=5 "
        query += "GROUP BY del.id_sales_order "
        query += ") del ON del.id_sales_order = so.id_sales_order "
        query += "GROUP BY so.id_sales_order "
        query += ") rmg ON rmg.id_sales_order = a.id_sales_order "
        query += "LEFT JOIN tb_emp_uni_period eu ON eu.id_emp_uni_period=b.id_emp_uni_period 
        LEFT JOIN tb_lookup_uni_type ut ON ut.id_uni_type = b.id_uni_type 
        LEFT JOIN tb_emp_uni_budget ub ON ub.id_emp_uni_budget = b.id_emp_uni_budget
        LEFT JOIN tb_m_employee ube ON ube.id_employee = ub.id_employee 
        LEFT JOIN tb_pl_sales_order_del_combine comb ON comb.id_combine = a.id_combine 
        LEFT JOIN (
            SELECT rm.id_report, e.employee_name AS `prepared_by` 
            FROM tb_report_mark rm
            INNER JOIN tb_m_employee e ON e.id_employee = rm.id_employee
            WHERE rm.report_mark_type=43 AND rm.id_report_status=1
            GROUP BY rm.id_report
        ) pb ON pb.id_report = a.id_pl_sales_order_del "
        query += "LEFT JOIN tb_m_comp_group dg ON d.id_comp_group = dg.id_comp_group 
        LEFT JOIN tb_m_user lu ON lu.id_user = a.last_update_by
        LEFT JOIN tb_m_employee le ON le.id_employee = lu.id_employee 
        LEFT JOIN (
            SELECT o.id_del_manifest,ad.id_pl_sales_order_del, o.number AS `manifest_number`
            FROM tb_del_manifest_det od
            INNER JOIN tb_del_manifest o ON o.id_del_manifest = od.id_del_manifest
            INNER JOIN tb_wh_awbill_det ad ON ad.id_wh_awb_det = od.id_wh_awb_det
            WHERE o.id_report_status!=5 AND !ISNULL(ad.id_pl_sales_order_del)
        ) dm ON dm.id_pl_sales_order_del = a.id_pl_sales_order_del "
        query += "WHERE a.id_pl_sales_order_del>0 "
        query += condition + " "
        query += "ORDER BY a.id_pl_sales_order_del " + order_type
        Return query
    End Function

    Public Function queryMainLess(ByVal condition As String, ByVal order_type As String) As String
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

        Dim query As String = "SELECT a.id_pl_sales_order_del, a.id_sales_order, a.id_store_contact_to, d.id_commerce_type,(d.id_comp) AS `id_store`, d.id_comp_group,(d.comp_name) AS store_name_to, (d.comp_number) AS store_number_to, CONCAT(d.comp_number, ' - ', d.comp_name) AS `store`, (d.address_primary) AS store_address_to, d.id_so_type, a.id_report_status, f.report_status, "
        query += "a.pl_sales_order_del_note, a.pl_sales_order_del_date, DATE_FORMAT(a.pl_sales_order_del_date,'%Y-%m-%d') AS pl_sales_order_del_datex, a.pl_sales_order_del_number, b.sales_order_number, b.sales_order_ol_shop_number, b.customer_name, b.tracking_code, "
        query += "DATE_FORMAT(a.pl_sales_order_del_date,'%d %M %Y') AS pl_sales_order_del_date, a.id_comp_contact_from,(wh.id_comp) AS `id_wh`, (wh.comp_number) AS `wh_number`,(wh.comp_name) AS `wh_name`, CONCAT(wh.comp_number, ' - ', wh.comp_name) AS `wh`, a.id_wh_drawer, drw.wh_drawer_code, drw.wh_drawer, cat.id_so_status, cat.so_status, "
        query += "a.last_update, getUserEmp(a.last_update_by, 1) AS `last_user`, ('No') AS `is_select`, IFNULL(det.`total`,0) AS `total`, eu.period_name, ut.uni_type, ube.employee_code, ube.employee_name, a.is_combine, IFNULL(a.id_combine,0) AS `id_combine`, IFNULL(comb.combine_number,'-') AS `combine_number`, b.sales_order_ol_shop_number, IFNULL(pb.prepared_by,'-') AS `prepared_by`, a.is_use_unique_code "
        query += "FROM tb_pl_sales_order_del a "
        query += "INNER JOIN tb_sales_order b ON a.id_sales_order = b.id_sales_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_comp_contact wh_cont ON wh_cont.id_comp_contact = a.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp wh ON wh.id_comp = wh_cont.id_comp "
        query += "INNER JOIN tb_lookup_so_status cat ON cat.id_so_status = b.id_so_status "
        query += "LEFT JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = a.id_wh_drawer "
        query += "LEFT JOIN( "
        query += "SELECT del.id_pl_sales_order_del, SUM(det.pl_sales_order_del_det_qty) AS `total` "
        query += "FROM tb_pl_sales_order_del del "
        query += "INNER JOIN tb_pl_sales_order_del_det det ON del.id_pl_sales_order_del = det.id_pl_sales_order_del "
        query += "GROUP BY del.id_pl_sales_order_del "
        query += ") det ON det.id_pl_sales_order_del = a.id_pl_sales_order_del "
        query += "LEFT JOIN tb_emp_uni_period eu ON eu.id_emp_uni_period=b.id_emp_uni_period 
        LEFT JOIN tb_lookup_uni_type ut ON ut.id_uni_type = b.id_uni_type 
        LEFT JOIN tb_emp_uni_budget ub ON ub.id_emp_uni_budget = b.id_emp_uni_budget
        LEFT JOIN tb_m_employee ube ON ube.id_employee = ub.id_employee 
        LEFT JOIN tb_pl_sales_order_del_combine comb ON comb.id_combine = a.id_combine 
        LEFT JOIN (
            SELECT rm.id_report, e.employee_name AS `prepared_by` 
            FROM tb_report_mark rm
            INNER JOIN tb_m_employee e ON e.id_employee = rm.id_employee
            WHERE rm.report_mark_type=43 AND rm.id_report_status=1
            GROUP BY rm.id_report
        ) pb ON pb.id_report = a.id_pl_sales_order_del "
        query += "WHERE a.id_pl_sales_order_del>0 "
        query += condition + " "
        query += "ORDER BY a.id_pl_sales_order_del " + order_type
        Return query
    End Function

    Public Function queryCombine(ByVal condition As String, ByVal order_type As String) As String
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

        Dim query As String = "SELECT a.id_pl_sales_order_del, a.id_sales_order, ac.id_store_contact_to, (d.id_comp) AS `id_store`,(d.comp_name) AS store_name_to, (d.comp_number) AS store_number_to, CONCAT(d.comp_number, ' - ', d.comp_name) AS `store`, (d.address_primary) AS store_address_to, d.id_so_type, ac.id_report_status, f.report_status, 
        a.pl_sales_order_del_note, a.pl_sales_order_del_date,  DATE_FORMAT(ac.combine_date,'%Y-%m-%d') AS combine_datex, DATE_FORMAT(a.pl_sales_order_del_date,'%Y-%m-%d') AS pl_sales_order_del_datex, a.pl_sales_order_del_number, b.sales_order_number, 
        DATE_FORMAT(a.pl_sales_order_del_date,'%d %M %Y') AS pl_sales_order_del_date, ac.id_comp_contact_from,(wh.id_comp) AS `id_wh`, (wh.comp_number) AS `wh_number`,(wh.comp_name) AS `wh_name`, CONCAT(wh.comp_number, ' - ', wh.comp_name) AS `wh`, ac.id_wh_drawer, drw.wh_drawer_code, drw.wh_drawer, 
        ac.last_update, getUserEmp(ac.last_update_by, 1) AS `last_user`, ('No') AS `is_select`,a.is_combine, a.id_combine, IFNULL(ac.combine_number,'-') AS `combine_number`, ac.combine_note , a.is_use_unique_code
        FROM tb_pl_sales_order_del a 
        INNER JOIN tb_pl_sales_order_del_combine ac ON ac.id_combine = a.id_combine
        INNER JOIN tb_sales_order b ON a.id_sales_order = b.id_sales_order 
        INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = ac.id_store_contact_to 
        INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
        INNER JOIN tb_lookup_report_status f ON f.id_report_status = ac.id_report_status 
        INNER JOIN tb_m_comp_contact wh_cont ON wh_cont.id_comp_contact = ac.id_comp_contact_from 
        INNER JOIN tb_m_comp wh ON wh.id_comp = wh_cont.id_comp 
        LEFT JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = ac.id_wh_drawer  
        WHERE a.id_pl_sales_order_del>0 "
        query += condition + " "
        query += "ORDER BY a.id_pl_sales_order_del " + order_type
        Return query
    End Function

    Public Function transactionList(ByVal condition As String, ByVal order_type As String, ByVal is_by_barcode As Boolean) As DataTable
        Dim query As String = ""
        If is_by_barcode Then
            query = "CALL view_pl_sales_order_del_main(""" + condition + """, " + order_type + ") "
        Else
            query = "CALL view_pl_sales_order_del_main_code(""" + condition + """, " + order_type + ") "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Public Function queryMainInvoice(ByVal condition As String, ByVal order_type As String) As String
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

        Dim query As String = "SELECT a.id_pl_sales_order_del, a.id_store_contact_to, (d.comp_name) AS store_name_to, a.id_comp_contact_from,a.id_report_status, f.report_status, "
        query += "a.pl_sales_order_del_note, a.pl_sales_order_del_date, a.pl_sales_order_del_number, b.sales_order_number, "
        query += "DATE_FORMAT(a.pl_sales_order_del_date,'%d %M %Y') AS pl_sales_order_del_date, (wh.id_comp) AS `id_wh`, (wh.comp_name) AS `wh_name`, cat.id_so_status, cat.so_status, "
        query += "a.last_update, getUserEmp(a.last_update_by, 1) AS `last_user`, ('No') AS `is_select` "
        query += "FROM tb_pl_sales_order_del a "
        query += "INNER JOIN tb_sales_order b ON a.id_sales_order = b.id_sales_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_comp_contact wh_cont ON wh_cont.id_comp_contact = a.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp wh ON wh.id_comp = wh_cont.id_comp "
        query += "LEFT JOIN tb_sales_pos sp ON sp.id_pl_sales_order_del=a.id_pl_sales_order_del "
        query += "INNER JOIN tb_lookup_so_status cat ON cat.id_so_status = b.id_so_status "
        query += "WHERE a.id_pl_sales_order_del>0 AND ISNULL(sp.id_sales_pos) "
        query += condition + " "
        query += "ORDER BY a.id_pl_sales_order_del " + order_type
        Return query
    End Function
    Public Sub changeStatus(ByVal id_report_par As String, ByVal id_status_reportx_par As String)
        'rollback stock if cancelled and complerted
        If id_status_reportx_par = "6" Then
            Dim qso As String = "SELECT d.id_sales_order, so.id_so_status 
            FROM tb_pl_sales_order_del d 
            INNER JOIN tb_sales_order so ON so.id_sales_order = d.id_sales_order
            WHERE d.id_pl_sales_order_del='" + id_report_par + "' "
            Dim dso As DataTable = execute_query(qso, -1, True, "", "", "", "")
            Dim id_so As String = dso.Rows(0)("id_sales_order").ToString
            Dim id_so_status As String = dso.Rows(0)("id_so_status").ToString

            If id_so_status <> "14" Then
                'reguler
                Dim query_complete As String = "
                -- delete so first (strage)
                DELETE FROM tb_storage_fg 
                WHERE report_mark_type=39 AND id_report=" + id_so + " AND report_mark_type_ref=43 AND id_report_ref=" + id_report_par + " AND id_storage_category=1 AND id_stock_status=2 ;
                -- delete del first (strage)
                DELETE FROM tb_storage_fg 
                WHERE report_mark_type=43 AND id_report=" + id_report_par + ";
                -- insert storage
                INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status, report_mark_type_ref, id_report_ref) "
                query_complete += "SELECT del.id_wh_drawer AS `drawer`, '1', del_det.id_product, dsg.design_cop, '39' AS `report_mark_type`, del.id_sales_order AS `id_report`, del_det.pl_sales_order_del_det_qty, NOW(), '', '2', 43, '" + id_report_par + "' "
                query_complete += "FROM tb_pl_sales_order_del del "
                query_complete += "INNER JOIN tb_pl_sales_order_del_det del_det ON del.id_pl_sales_order_del = del_det.id_pl_sales_order_del "
                query_complete += "INNER JOIN tb_m_product prod ON prod.id_product = del_det.id_product  "
                query_complete += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
                query_complete += "WHERE del.id_pl_sales_order_del=" + id_report_par + " AND del_det.pl_sales_order_del_det_qty>0 "
                query_complete += "UNION ALL "
                query_complete += "SELECT del.id_wh_drawer AS `drawer`, '2', del_det.id_product, dsg.design_cop, '43' AS `report_mark_type`, del.id_pl_sales_order_del AS `id_report`, del_det.pl_sales_order_del_det_qty, NOW(), '','1', NULL,NULL "
                query_complete += "FROM tb_pl_sales_order_del del "
                query_complete += "INNER JOIN tb_pl_sales_order_del_det del_det ON del.id_pl_sales_order_del = del_det.id_pl_sales_order_del "
                query_complete += "INNER JOIN tb_m_product prod ON prod.id_product = del_det.id_product  "
                query_complete += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
                query_complete += "WHERE del.id_pl_sales_order_del=" + id_report_par + " AND del_det.pl_sales_order_del_det_qty>0 "
                query_complete += "UNION ALL "
                query_complete += "SELECT getCompByContact(del.id_store_contact_to, 4) AS `drawer`, '1', del_det.id_product, dsg.design_cop, '43' AS `report_mark_type`, del.id_pl_sales_order_del AS `id_report`, del_det.pl_sales_order_del_det_qty, NOW(), '','1', NULL,NULL "
                query_complete += "FROM tb_pl_sales_order_del del "
                query_complete += "INNER JOIN tb_pl_sales_order_del_det del_det ON del.id_pl_sales_order_del = del_det.id_pl_sales_order_del "
                query_complete += "INNER JOIN tb_m_product prod ON prod.id_product = del_det.id_product  "
                query_complete += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
                query_complete += "WHERE del.id_pl_sales_order_del=" + id_report_par + " AND del_det.pl_sales_order_del_det_qty>0; "
                execute_non_query(query_complete, True, "", "", "", "")
            Else
                'pure wholesale
                Dim query_complete As String = "
                -- delete so first (strage)
                DELETE FROM tb_storage_fg 
                WHERE report_mark_type=39 AND id_report=" + id_so + " AND report_mark_type_ref=43 AND id_report_ref=" + id_report_par + " AND id_storage_category=1 AND id_stock_status=2 ;
                -- delete del first (strage)
                DELETE FROM tb_storage_fg 
                WHERE report_mark_type=43 AND id_report=" + id_report_par + ";
                -- insert storage
                INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status, report_mark_type_ref, id_report_ref) "
                query_complete += "SELECT del.id_wh_drawer AS `drawer`, '1', del_det.id_product, dsg.design_cop, '39' AS `report_mark_type`, del.id_sales_order AS `id_report`, del_det.pl_sales_order_del_det_qty, NOW(), '', '2', 43, '" + id_report_par + "' "
                query_complete += "FROM tb_pl_sales_order_del del "
                query_complete += "INNER JOIN tb_pl_sales_order_del_det del_det ON del.id_pl_sales_order_del = del_det.id_pl_sales_order_del "
                query_complete += "INNER JOIN tb_m_product prod ON prod.id_product = del_det.id_product  "
                query_complete += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
                query_complete += "WHERE del.id_pl_sales_order_del=" + id_report_par + " AND del_det.pl_sales_order_del_det_qty>0 "
                query_complete += "UNION ALL "
                query_complete += "SELECT del.id_wh_drawer AS `drawer`, '2', del_det.id_product, dsg.design_cop, '43' AS `report_mark_type`, del.id_pl_sales_order_del AS `id_report`, del_det.pl_sales_order_del_det_qty, NOW(), '','1', NULL,NULL "
                query_complete += "FROM tb_pl_sales_order_del del "
                query_complete += "INNER JOIN tb_pl_sales_order_del_det del_det ON del.id_pl_sales_order_del = del_det.id_pl_sales_order_del "
                query_complete += "INNER JOIN tb_m_product prod ON prod.id_product = del_det.id_product  "
                query_complete += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
                query_complete += "WHERE del.id_pl_sales_order_del=" + id_report_par + " AND del_det.pl_sales_order_del_det_qty>0 "
                execute_non_query(query_complete, True, "", "", "", "")

                'INVOCIE
                'main
                Dim query_inv As String = "INSERT INTO tb_sales_pos(id_store_contact_from,id_comp_contact_bill , sales_pos_number, sales_pos_date, sales_pos_note, id_report_status, id_so_type, sales_pos_total, sales_pos_due_date, sales_pos_start_period, sales_pos_end_period, sales_pos_discount, sales_pos_potongan, sales_pos_vat, id_pl_sales_order_del,id_memo_type,id_inv_type, id_sales_pos_ref, report_mark_type, is_use_unique_code, id_acc_ar, id_acc_sales, id_acc_sales_return) 
                SELECT del.id_store_contact_to AS id_store_contact_from,NULL AS id_comp_contact_bill , '" + header_number_sales("6") + "' AS sales_pos_number, 
                DATE(NOW()) AS sales_pos_date, 
                '' AS sales_pos_note, 6 AS id_report_status, 0 AS id_so_type, 0 AS sales_pos_total, DATE_ADD(DATE(so.sales_order_ol_shop_date),INTERVAL IFNULL(sd.due,0) DAY) AS sales_pos_due_date, 
                so.sales_order_ol_shop_date AS sales_pos_start_period,so.sales_order_ol_shop_date AS sales_pos_end_period,
                c.comp_commission AS sales_pos_discount, 0 AS sales_pos_potongan, o.vat_inv_default AS sales_pos_vat, del.id_pl_sales_order_del, 1 AS id_memo_type,0 AS id_inv_type, NULL AS id_sales_pos_ref, 48 AS report_mark_type,o.is_use_unique_code_all AS is_use_unique_code, 
                c.id_acc_ar, c.id_acc_sales, c.id_acc_sales_return 
                FROM tb_pl_sales_order_del del 
                INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
                JOIN tb_opt o
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = del.id_store_contact_to
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                LEFT JOIN tb_store_due sd ON sd.id_comp = c.id_comp
                WHERE del.id_pl_sales_order_del=" + id_report_par + "; SELECT LAST_INSERT_ID(); "
                Dim id_sales_pos As String = execute_query(query_inv, 0, True, "", "", "", "")
                'gen number
                execute_non_query("CALL gen_number(" + id_sales_pos + ", 48);", True, "", "", "", "")
                'increase number
                'increase_inc_sales("6")
                'detail
                Dim query_detail_inv As String = "INSERT INTO tb_sales_pos_det(id_sales_pos, id_product, id_design_price, design_price, sales_pos_det_qty, id_design_price_retail, design_price_retail, note, id_sales_pos_det_ref, id_pl_sales_order_del_det, id_pos_combine_summary) 
                SELECT " + id_sales_pos + ", id_product, id_design_price, design_price, dd.pl_sales_order_del_det_qty AS sales_pos_det_qty, 
                dd.id_design_price AS id_design_price_retail, dd.design_price AS design_price_retail, '' AS note, NULL AS id_sales_pos_det_ref, 
                dd.id_pl_sales_order_del_det AS id_pl_sales_order_del_det, NULL AS id_pos_combine_summary 
                FROM tb_pl_sales_order_del_det dd
                WHERE dd.id_pl_sales_order_del=" + id_report_par + "; 
                -- update total qty
                UPDATE tb_sales_pos main
                INNER JOIN (
                    SELECT pd.id_sales_pos,ABS(SUM(pd.sales_pos_det_qty)) AS `total`, ABS(SUM(pd.sales_pos_det_qty * pd.design_price_retail)) AS `total_amount`
                    FROM tb_sales_pos_det pd
                    WHERE pd.id_sales_pos=" + id_sales_pos + "
                    GROUP BY pd.id_sales_pos
                ) src ON src.id_sales_pos = main.id_sales_pos
                SET main.sales_pos_total_qty = src.total, main.sales_pos_total=src.total_amount; "
                execute_non_query(query_detail_inv, True, "", "", "", "")
                'submit prepared
                Dim id_user_prepared_inv As String = get_opt_acc_field("invoice_prepared_by")
                submit_who_prepared("48", id_sales_pos, id_user_prepared_inv)
                'nonaktif mark
                Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", "48", id_sales_pos)
                execute_non_query(queryrm, True, "", "", "", "")
                'journal draft
                Dim acc As New ClassAccounting()
                Try
                    acc.generateJournalSalesDraftWithMapping(id_sales_pos, "48")
                Catch ex As Exception
                    stopCustom("Automatic draft journal failed. Please contact administrator. " + System.Environment.NewLine + ex.ToString)
                End Try
                'journal
                Dim gl As New ClassSalesInv()
                Try
                    gl.postingJournal(id_sales_pos, "48")
                Catch ex As Exception
                    stopCustom("Automatic journal failed. Please contact administrator. " + System.Environment.NewLine + ex.ToString)
                End Try
            End If

            'unique
            Try
                Dim query_store As String = "SELECT getCompByContact(id_store_contact_to, 1) AS `id_store`,  getCompByContact(id_store_contact_to, 4) AS `id_drawer_store` FROM tb_pl_sales_order_del WHERE id_pl_sales_order_del='" + id_report_par + "' "
                Dim data_store As DataTable = execute_query(query_store, -1, True, "", "", "", "")
                Dim id_store As String = data_store.Rows(0)("id_store").ToString
                Dim id_drawer_store As String = data_store.Rows(0)("id_drawer_store").ToString
                Dim quniq As String = "INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique`, `id_pl_sales_order_del_det_counting`,`id_type`,`unique_code`,
                    `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`) 
                    SELECT cc.id_comp, c.id_drawer_def, td.id_product, tc.id_pl_prod_order_rec_det_unique,  tc.id_pl_sales_order_del_det_counting, '1', 
                    CONCAT(p.product_full_code,tc.pl_sales_order_del_det_counting), td.id_design_price, td.design_price, 1, IF(ISNULL(u.is_unique_report),1, u.is_unique_report) AS `is_unique_report`, NOW() 
                    FROM tb_pl_sales_order_del_det td
                    INNER JOIN tb_pl_sales_order_del t ON t.id_pl_sales_order_del = td.id_pl_sales_order_del
                    INNER JOIN tb_pl_sales_order_del_det_counting tc ON tc.id_pl_sales_order_del_det = td.id_pl_sales_order_del_det
                    INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact =  t.id_store_contact_to
                    INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                    INNER JOIN tb_m_product p ON p.id_product = td.id_product
                    INNER JOIN tb_m_design d ON d.id_design = p.id_design
                    LEFT JOIN (
                        SELECT u.id_product, u.is_unique_report 
                        FROM tb_m_unique_code u
                        WHERE u.id_comp=" + id_store + " AND u.id_wh_drawer = " + id_drawer_store + "
                        GROUP BY u.id_product
                    ) u ON u.id_product = p.id_product
                    WHERE t.id_pl_sales_order_del=" + id_report_par + "
                    AND d.is_old_design=2 AND t.is_use_unique_code=1 "
                execute_non_query(quniq, True, "", "", "", "")
            Catch ex As Exception
                stopCustom("failed insert unique :" + ex.ToString)
            End Try

            'save unreg unique
            execute_non_query("CALL generate_unreg_barcode(" + id_report_par + ",1)", True, "", "", "", "")
        ElseIf id_status_reportx_par = "5" Then
            Dim quniq As String = "INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique`, `id_pl_sales_order_del_det_counting`,`id_type`,`unique_code`,
            `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`) 
            SELECT cc.id_comp, t.id_wh_drawer, td.id_product, tc.id_pl_prod_order_rec_det_unique,  tc.id_pl_sales_order_del_det_counting, '1', 
            CONCAT(p.product_full_code,tc.pl_sales_order_del_det_counting), td.id_design_price, td.design_price, 1, 1, NOW() 
            FROM tb_pl_sales_order_del_det td
            INNER JOIN tb_pl_sales_order_del t ON t.id_pl_sales_order_del = td.id_pl_sales_order_del
            INNER JOIN tb_pl_sales_order_del_det_counting tc ON tc.id_pl_sales_order_del_det = td.id_pl_sales_order_del_det
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact =  t.id_comp_contact_from
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            INNER JOIN tb_m_product p ON p.id_product = td.id_product
            INNER JOIN tb_m_design d ON d.id_design = p.id_design
            WHERE t.id_pl_sales_order_del=" + id_report_par + "
            AND d.is_old_design=2 AND t.is_use_unique_code_wh=1 "
            execute_non_query(quniq, True, "", "", "", "")
        End If
        Dim query As String = String.Format("UPDATE tb_pl_sales_order_del SET id_report_status='{0}', last_update=NOW(), last_update_by=" + id_user + " WHERE id_pl_sales_order_del ='{1}'", id_status_reportx_par, id_report_par)
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub changeStatusHead(ByVal id_report_par As String, ByVal id_status_reportx_par As String)
        'rollback stock if cancelled and complerted
        If id_status_reportx_par = "6" Then
            Dim query_complete As String = "
            -- delete so
            DELETE FROM tb_storage_fg 
            WHERE report_mark_type=39 AND report_mark_type_ref=43 AND id_report_ref=" + id_report_par + " AND id_storage_category=1 AND id_stock_status=2 ;
            -- delete storage
            DELETE f.* FROM tb_storage_fg f 
            INNER JOIN (
	            SELECT d.id_pl_sales_order_del FROM tb_pl_sales_order_del d
	            WHERE d.id_combine=" + id_report_par + "
            ) del ON del.id_pl_sales_order_del = f.id_report
            WHERE f.report_mark_type=43;
            -- insert storage
            INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status, report_mark_type_ref, id_report_ref) "
            query_complete += "SELECT del.id_wh_drawer AS `drawer`, '1', del_det.id_product, dsg.design_cop, '39' AS `report_mark_type`, del.id_sales_order AS `id_report`, del_det.pl_sales_order_del_det_qty, NOW(), '', '2', 43, " + id_report_par + " "
            query_complete += "FROM tb_pl_sales_order_del del "
            query_complete += "INNER JOIN tb_pl_sales_order_del_det del_det ON del.id_pl_sales_order_del = del_det.id_pl_sales_order_del "
            query_complete += "INNER JOIN tb_m_product prod ON prod.id_product = del_det.id_product  "
            query_complete += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
            query_complete += "WHERE del.id_combine=" + id_report_par + " AND del_det.pl_sales_order_del_det_qty>0 "
            query_complete += "UNION ALL "
            query_complete += "SELECT del.id_wh_drawer AS `drawer`, '2', del_det.id_product, dsg.design_cop, '43' AS `report_mark_type`, del.id_pl_sales_order_del AS `id_report`, del_det.pl_sales_order_del_det_qty, NOW(), '','1', NULL, NULL "
            query_complete += "FROM tb_pl_sales_order_del del "
            query_complete += "INNER JOIN tb_pl_sales_order_del_det del_det ON del.id_pl_sales_order_del = del_det.id_pl_sales_order_del "
            query_complete += "INNER JOIN tb_m_product prod ON prod.id_product = del_det.id_product  "
            query_complete += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
            query_complete += "WHERE del.id_combine=" + id_report_par + " AND del_det.pl_sales_order_del_det_qty>0 "
            query_complete += "UNION ALL "
            query_complete += "SELECT getCompByContact(del.id_store_contact_to, 4) AS `drawer`, '1', del_det.id_product, dsg.design_cop, '43' AS `report_mark_type`, del.id_pl_sales_order_del AS `id_report`, del_det.pl_sales_order_del_det_qty, NOW(), '','1', NULL, NULL "
            query_complete += "FROM tb_pl_sales_order_del del "
            query_complete += "INNER JOIN tb_pl_sales_order_del_det del_det ON del.id_pl_sales_order_del = del_det.id_pl_sales_order_del "
            query_complete += "INNER JOIN tb_m_product prod ON prod.id_product = del_det.id_product  "
            query_complete += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
            query_complete += "WHERE del.id_combine=" + id_report_par + " AND del_det.pl_sales_order_del_det_qty>0 "
            execute_non_query(query_complete, True, "", "", "", "")

            'unique
            Try
                Dim query_store As String = "SELECT getCompByContact(id_store_contact_to, 1) AS `id_store`,  getCompByContact(id_store_contact_to, 4) AS `id_drawer_store` FROM tb_pl_sales_order_del_combine WHERE id_combine='" + id_report_par + "' "
                Dim data_store As DataTable = execute_query(query_store, -1, True, "", "", "", "")
                Dim id_store As String = data_store.Rows(0)("id_store").ToString
                Dim id_drawer_store As String = data_store.Rows(0)("id_drawer_store").ToString

                Dim quniq As String = "INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique`, `id_pl_sales_order_del_det_counting`,`id_type`,`unique_code`,
                `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`) 
                SELECT cc.id_comp, c.id_drawer_def, td.id_product, tc.id_pl_prod_order_rec_det_unique,  tc.id_pl_sales_order_del_det_counting, '1', 
                CONCAT(p.product_full_code,tc.pl_sales_order_del_det_counting), td.id_design_price, td.design_price, 1, IF(ISNULL(u.is_unique_report),1, u.is_unique_report) AS `is_unique_report`, NOW() 
                FROM tb_pl_sales_order_del_det td
                INNER JOIN tb_pl_sales_order_del t ON t.id_pl_sales_order_del = td.id_pl_sales_order_del
                INNER JOIN tb_pl_sales_order_del_det_counting tc ON tc.id_pl_sales_order_del_det = td.id_pl_sales_order_del_det
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact =  t.id_store_contact_to
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                INNER JOIN tb_m_product p ON p.id_product = td.id_product
                INNER JOIN tb_m_design d ON d.id_design = p.id_design
                LEFT JOIN (
                    SELECT u.id_product, u.is_unique_report 
                    FROM tb_m_unique_code u
                    WHERE u.id_comp=" + id_store + " AND u.id_wh_drawer=" + id_drawer_store + "
                    GROUP BY u.id_product
                ) u ON u.id_product = p.id_product
                WHERE t.id_combine=" + id_report_par + "
                AND d.is_old_design=2 AND t.is_use_unique_code=1 "
                execute_non_query(quniq, True, "", "", "", "")
            Catch ex As Exception
                stopCustom("failed insert unique :" + ex.ToString)
            End Try
        ElseIf id_status_reportx_par = "5" Then
            Dim quniq As String = "INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique`, `id_pl_sales_order_del_det_counting`,`id_type`,`unique_code`,
            `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`) 
            SELECT cc.id_comp, t.id_wh_drawer, td.id_product,  tc.id_pl_prod_order_rec_det_unique,tc.id_pl_sales_order_del_det_counting, '1', 
            CONCAT(p.product_full_code,tc.pl_sales_order_del_det_counting), td.id_design_price, td.design_price, 1, 1, NOW() 
            FROM tb_pl_sales_order_del_det td
            INNER JOIN tb_pl_sales_order_del t ON t.id_pl_sales_order_del = td.id_pl_sales_order_del
            INNER JOIN tb_pl_sales_order_del_det_counting tc ON tc.id_pl_sales_order_del_det = td.id_pl_sales_order_del_det
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact =  t.id_comp_contact_from
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            INNER JOIN tb_m_product p ON p.id_product = td.id_product
            INNER JOIN tb_m_design d ON d.id_design = p.id_design
            WHERE t.id_combine=" + id_report_par + "
            AND d.is_old_design=2 AND t.is_use_unique_code_wh=1 "
            execute_non_query(quniq, True, "", "", "", "")
        End If

        'update pre delivery
        Dim query_pre As String = String.Format("UPDATE tb_pl_sales_order_del del 
        SET del.id_report_status='{0}', del.last_update=NOW(), del.last_update_by='{1}'
        WHERE del.id_combine='{2}' ", id_status_reportx_par, id_user, id_report_par)
        execute_non_query(query_pre, True, "", "", "", "")

        'update delivery slip
        Dim query As String = String.Format("UPDATE tb_pl_sales_order_del_combine SET id_report_status='{0}', last_update=NOW(), last_update_by=" + id_user + " WHERE id_combine ='{1}'", id_status_reportx_par, id_report_par)
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub insertUniqueCode(ByVal id_report_par As String, ByVal id_comp_par As String, ByVal is_use_unique_code_par As String)
        If is_use_unique_code_par = "1" Then
            'Dim query As String = "INSERT INTO tb_m_unique_code(`id_comp` , `id_product` ,`id_pl_sales_order_del_det_counting`, `id_type`, `unique_code` , 
            '`id_design_price` , `design_price` , `qty` , `is_unique_report` , `input_date` )
            'SELECT " + id_comp_par + ",dd.id_product, ddu.id_pl_sales_order_del_det_counting,1, CONCAT(p.product_full_code,ddu.pl_sales_order_del_det_counting) AS `code`, dd.id_design_price, dd.design_price, 1, IF(ISNULL(u.is_unique_report),1, u.is_unique_report) AS `is_unique_report`, NOW()
            'FROM tb_pl_sales_order_del_det dd 
            'INNER JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del
            'INNER JOIN tb_pl_sales_order_del_det_counting ddu ON ddu.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
            'INNER JOIN tb_m_product p ON p.id_product = dd.id_product
            'INNER JOIN tb_m_design dsg ON dsg.id_design = p.id_design
            'LEFT JOIN (
            ' SELECT u.id_product, u.is_unique_report 
            ' FROM tb_m_unique_code u
            ' WHERE u.id_comp=" + id_comp_par + "
            ' GROUP BY u.id_product
            ') u ON u.id_product = dd.id_product
            'WHERE dd.id_pl_sales_order_del=" + id_report_par + " AND dsg.is_old_design=2 "
            'execute_non_query(query, True, "", "", "", "")
        End If
    End Sub

    Public Sub insertUniqueCodeHead(ByVal id_report_par As String, ByVal id_comp_par As String, ByVal is_use_unique_code_par As String)
        'Dim query As String = "INSERT INTO tb_m_unique_code(`id_comp` , `id_product` ,`id_pl_sales_order_del_det_counting`, `id_type`, `unique_code` , 
        '`id_design_price` , `design_price` , `qty` , `is_unique_report` , `input_date` )
        'SELECT " + id_comp_par + ",dd.id_product, ddu.id_pl_sales_order_del_det_counting,1, CONCAT(p.product_full_code,ddu.pl_sales_order_del_det_counting) AS `code`, dd.id_design_price, dd.design_price, 1, IF(ISNULL(u.is_unique_report),1, u.is_unique_report) AS `is_unique_report`, NOW()
        'FROM tb_pl_sales_order_del_det dd 
        'INNER JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del
        'INNER JOIN tb_pl_sales_order_del_det_counting ddu ON ddu.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
        'INNER JOIN tb_m_product p ON p.id_product = dd.id_product
        'INNER JOIN tb_m_design dsg ON dsg.id_design = p.id_design
        'LEFT JOIN (
        ' SELECT u.id_product, u.is_unique_report 
        ' FROM tb_m_unique_code u
        ' WHERE u.id_comp=" + id_comp_par + "
        ' GROUP BY u.id_product
        ') u ON u.id_product = dd.id_product
        'WHERE d.id_combine=" + id_report_par + " AND d.is_use_unique_code=1 AND dsg.is_old_design=2 "
        'execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Function getMasterDelivery(ByVal del As String) As DataTable
        Dim query As String = "SELECT m.*, cd.code_detail_name AS `size`
        FROM (
	        SELECT dd.id_product, p.product_full_code AS `code`, dsg.design_display_name AS `name`, dd.design_price
	        FROM tb_pl_sales_order_del d
	        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
	        INNER JOIN tb_m_product p ON p.id_product = dd.id_product
	        INNER JOIN tb_m_design dsg ON dsg.id_design = p.id_design
	        WHERE dsg.is_old_design=1 AND (" + del + ")
	        GROUP BY dd.id_product
	        UNION ALL
	        SELECT dd.id_product, p.product_full_code AS `code`, dsg.design_display_name AS `name`, dd.design_price
	        FROM tb_pl_sales_order_del d
	        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
	        INNER JOIN tb_pl_sales_order_del_det_counting dc ON dc.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
	        INNER JOIN tb_m_unique_code mc ON mc.id_pl_sales_order_del_det_counting = dc.id_pl_sales_order_del_det_counting AND mc.id_type=1
	        INNER JOIN tb_m_product p ON p.id_product = dd.id_product
	        INNER JOIN tb_m_design dsg ON dsg.id_design = p.id_design
	        WHERE dsg.is_old_design=2 AND (" + del + ")
	        AND mc.is_unique_report=2
	        GROUP BY dd.id_product
	        UNION ALL 
	        SELECT dd.id_product, mc.unique_code AS `code`, dsg.design_display_name AS `name`, dd.design_price
	        FROM tb_pl_sales_order_del d
	        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
	        INNER JOIN tb_pl_sales_order_del_det_counting dc ON dc.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
	        INNER JOIN tb_m_unique_code mc ON mc.id_pl_sales_order_del_det_counting = dc.id_pl_sales_order_del_det_counting AND mc.id_type=1
	        INNER JOIN tb_m_product p ON p.id_product = dd.id_product
	        INNER JOIN tb_m_design dsg ON dsg.id_design = p.id_design
	        WHERE dsg.is_old_design=2 AND (" + del + ")
	        AND mc.is_unique_report=1
	        GROUP BY dd.id_product
        ) m
        INNER JOIN tb_m_product_code pc ON pc.id_product = m.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        ORDER BY `code` ASC, `name` ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Public Sub sendEmailConfirmation(ByVal id_report As String)
        'only online store
        Dim query As String = "SELECT del.id_pl_sales_order_del, del.pl_sales_order_del_number AS `del_number`, 
        DATE_FORMAT(del.pl_sales_order_del_date, '%d %M %Y') AS `scan_date`, DATE_FORMAT(fcom.report_mark_datetime,'%d %M %Y %H:%i') AS `appr_date`,
        so.sales_order_number AS `order_number`, so.sales_order_ol_shop_number AS `ol_store_order_number`, DATE_FORMAT(so.sales_order_date,'%d %M %Y') AS `order_date`, so.customer_name,
        CONCAT(s.comp_number, ' - ', s.comp_name) AS `store`, sg.comp_group AS `store_group_code`, sg.description AS `store_group`
        FROM tb_pl_sales_order_del del 
        INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = del.id_store_contact_to
        INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
        INNER JOIN tb_m_comp_group sg ON sg.id_comp_group = s.id_comp_group
        INNER JOIN tb_report_mark fcom ON fcom.id_report = del.id_pl_sales_order_del AND fcom.report_mark_type=43 AND fcom.is_use=1 AND fcom.id_mark=2 AND fcom.id_report_status=3
        INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
        WHERE del.id_pl_sales_order_del='" + id_report + "' AND s.id_commerce_type=2 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            Try
                Dim em As New ClassSendEmail
                em.report_mark_type = "43_ready"
                em.id_report = id_report
                em.dt = data
                em.send_email()
            Catch ex As Exception
                Dim qerr As String = "INSERT INTO tb_error_mail(date,description, note_penyelesaian) VALUES(NOW(), 'Failed send ready to ship confirmation; id del:" + id_report + "; error:" + addSlashes(ex.ToString) + "', ''); "
                execute_non_query(qerr, True, "", "", "", "")
            End Try
        End If
    End Sub

    Public Function queryDelConceptStore(ByVal condition As String, id_store As String) As String
        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT 
        dd.id_product, p.id_design,
        IF(dsg.is_old_design=1,p.product_full_code, IF(ISNULL(u.is_unique_report), CONCAT(p.product_full_code,ddc.pl_sales_order_del_det_counting), p.product_full_code)) AS `code`, 
        p.product_display_name AS `name`, cd.code_detail_name AS `size`,
        COUNT(ddc.id_pl_sales_order_del_det_counting) AS `qty`, 
        dd.design_price, pt.design_price_type, 2 AS `is_combine`,
        IF(ISNULL(u.is_unique_report), 1, u.is_unique_report) AS `is_unique_report`
        FROM tb_pl_sales_order_del d
        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
        INNER JOIN tb_pl_sales_order_del_det_counting ddc ON ddc.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
        INNER JOIN tb_m_product p ON p.id_product = dd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_design dsg ON dsg.id_design = p.id_design
        LEFT JOIN (
            SELECT u.id_product, u.is_unique_report 
            FROM tb_m_unique_code u
            WHERE u.id_comp=" + id_store + "
            GROUP BY u.id_product
        ) u ON u.id_product = p.id_product
        INNER JOIN tb_m_design_price prc ON prc.id_design_price = dd.id_design_price
        INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_m_comp_contact whcc ON whcc.id_comp_contact = d.id_comp_contact_from
        INNER JOIN tb_m_comp wh ON wh.id_comp = whcc.id_comp
        WHERE 1=1 "
        query += condition
        query += "GROUP BY IF(dsg.is_old_design=1,p.product_full_code, IF(ISNULL(u.is_unique_report), CONCAT(p.product_full_code,ddc.pl_sales_order_del_det_counting), p.product_full_code))
        ORDER BY pt.design_price_type ASC, dsg.design_display_name ASC, p.product_full_code ASC "
        Return query
    End Function

    Public Function queryDelRegular(ByVal condition As String, id_store As String) As String
        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT 
        dd.id_product, p.id_design, p.product_full_code AS `code`, 
        p.product_display_name AS `name`, cd.code_detail_name AS `size`,
        SUM(dd.pl_sales_order_del_det_qty) AS `qty`, 
        dd.design_price, pt.design_price_type, 2 AS `is_combine`,
        2 AS `is_unique_report`
        FROM tb_pl_sales_order_del d
        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
        INNER JOIN tb_m_product p ON p.id_product = dd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_design dsg ON dsg.id_design = p.id_design
        INNER JOIN tb_m_design_price prc ON prc.id_design_price = dd.id_design_price
        INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_m_comp_contact whcc ON whcc.id_comp_contact = d.id_comp_contact_from
        INNER JOIN tb_m_comp wh ON wh.id_comp = whcc.id_comp
        WHERE 1=1 "
        query += condition
        query += "GROUP BY p.id_product
        ORDER BY pt.design_price_type ASC, dsg.design_display_name ASC, p.product_full_code ASC "
        Return query
    End Function

    Sub sendDeliveryConfirmationOfflineStore(ByVal id_report As String, ByVal rmt As String)
        Try
            Dim query As String = ""
            If rmt = "43" Then
                'single del
                query = "SELECT s.id_outlet,s.id_comp AS `id_store`,CONCAT(s.comp_number, ' - ', s.comp_name) AS `store_account`, s.address_primary AS `store_address`,
                    CONCAT(w.comp_number, ' - ', w.comp_name) AS `wh_account` ,
                    d.pl_sales_order_del_number AS `del_number`, DATE_FORMAT(d.pl_sales_order_del_date,'%d-%m-%Y') AS `del_created_date`, DATE_FORMAT(d.last_update,'%d-%m-%Y %H:%i') AS `del_date`,
                    so.sales_order_number AS `order_number`, cat.so_status AS `order_cat`,
                    SUM(dd.pl_sales_order_del_det_qty) AS `total_qty`, SUM(dd.pl_sales_order_del_det_qty * dd.design_price) AS `amount`,
                    2 AS `is_combine`, d.is_use_unique_code, d.pl_sales_order_del_note AS `note`, '43' AS `rmt`
                    FROM tb_pl_sales_order_del d
                    INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
                    INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = d.id_store_contact_to
                    INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
                    INNER JOIN tb_m_comp_contact wc ON wc.id_comp_contact = d.id_comp_contact_from
                    INNER JOIN tb_m_comp w ON w.id_comp = wc.id_comp
                    INNER JOIN tb_sales_order so ON so.id_sales_order = d.id_sales_order
                    INNER JOIN tb_lookup_so_status cat ON cat.id_so_status = so.id_so_status
                    WHERE d.id_pl_sales_order_del=" + id_report + "
                    GROUP BY d.id_pl_sales_order_del "
            Else
                'combine del
                query = "SELECT s.id_outlet,s.id_comp AS `id_store`,CONCAT(s.comp_number, ' - ', s.comp_name) AS `store_account`, s.address_primary AS `store_address`,
                    CONCAT(w.comp_number, ' - ', w.comp_name) AS `wh_account` ,
                    dc.combine_number AS `del_number`, DATE_FORMAT(dc.combine_date,'%d-%m-%Y') AS `del_created_date`, DATE_FORMAT(dc.last_update,'%d-%m-%Y %H:%i') AS `del_date`,
                    '-' AS `order_number`, '-' AS `order_cat`,
                    SUM(dd.pl_sales_order_del_det_qty) AS `total_qty`, SUM(dd.pl_sales_order_del_det_qty * dd.design_price) AS `amount`,
                    1 AS `is_combine`, d.is_use_unique_code, dc.combine_note AS `note`, '103' AS `rmt`
                    FROM tb_pl_sales_order_del d
                    INNER JOIN tb_pl_sales_order_del_combine dc ON dc.id_combine = d.id_combine
                    INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
                    INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = d.id_store_contact_to
                    INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
                    INNER JOIN tb_m_comp_contact wc ON wc.id_comp_contact = d.id_comp_contact_from
                    INNER JOIN tb_m_comp w ON w.id_comp = wc.id_comp
                    INNER JOIN tb_sales_order so ON so.id_sales_order = d.id_sales_order
                    INNER JOIN tb_lookup_so_status cat ON cat.id_so_status = so.id_so_status
                    WHERE d.id_combine=" + id_report + "
                    GROUP BY d.id_combine "
            End If
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim em As New ClassSendEmail
            em.report_mark_type = "43"
            em.opt = "2"
            em.id_report = id_report
            em.dt = data
            em.send_email()
        Catch ex As Exception
            Dim qerr As String = "INSERT INTO tb_error_mail(date,description, note_penyelesaian) VALUES(NOW(), 'Failed send delivery confirmation; id del:" + id_report + "; error:" + addSlashes(ex.ToString) + "', ''); "
            execute_non_query(qerr, True, "", "", "", "")
        End Try
    End Sub

    Function checkUnpaidInvoice(ByVal id_comp_group_par As String) As Boolean
        Dim query As String = "SELECT * FROM tb_ar_eval e WHERE e.id_comp_group=" + id_comp_group_par + " AND e.is_active=1 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
