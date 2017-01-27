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

        Dim query As String = "SELECT a.id_pl_sales_order_del, a.id_sales_order, a.id_store_contact_to, (d.id_comp) AS `id_store`,(d.comp_name) AS store_name_to, (d.comp_number) AS store_number_to, CONCAT(d.comp_number, ' - ', d.comp_name) AS `store`, (d.address_primary) AS store_address_to, d.id_so_type, a.id_report_status, f.report_status, "
        query += "a.pl_sales_order_del_note, a.pl_sales_order_del_date, DATE_FORMAT(a.pl_sales_order_del_date,'%Y-%m-%d') AS pl_sales_order_del_datex, a.pl_sales_order_del_number, b.sales_order_number, "
        query += "DATE_FORMAT(a.pl_sales_order_del_date,'%d %M %Y') AS pl_sales_order_del_date, id_comp_contact_from,(wh.id_comp) AS `id_wh`, (wh.comp_number) AS `wh_number`,(wh.comp_name) AS `wh_name`, CONCAT(wh.comp_number, ' - ', wh.comp_name) AS `wh`, a.id_wh_drawer, drw.wh_drawer_code, drw.wh_drawer, cat.id_so_status, cat.so_status, "
        query += "a.last_update, getUserEmp(a.last_update_by, 1) AS `last_user`, ('No') AS `is_select`, IFNULL(det.`total`,0) AS `total`, rmg.`total_remaining`  "
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
        query += "WHERE a.id_pl_sales_order_del>0 "
        query += condition + " "
        query += "ORDER BY a.id_pl_sales_order_del " + order_type
        Return query
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

        Dim query As String = "SELECT a.id_pl_sales_order_del, a.id_store_contact_to, (d.comp_name) AS store_name_to, id_comp_contact_from,a.id_report_status, f.report_status, "
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
            Dim query_complete As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) "
            query_complete += "SELECT del.id_wh_drawer AS `drawer`, '1', del_det.id_product, dsg.design_cop, '39' AS `report_mark_type`, del.id_sales_order AS `id_report`, del_det.pl_sales_order_del_det_qty, NOW(), '', '2' "
            query_complete += "FROM tb_pl_sales_order_del del "
            query_complete += "INNER JOIN tb_pl_sales_order_del_det del_det ON del.id_pl_sales_order_del = del_det.id_pl_sales_order_del "
            query_complete += "INNER JOIN tb_m_product prod ON prod.id_product = del_det.id_product  "
            query_complete += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
            query_complete += "WHERE del.id_pl_sales_order_del=" + id_report_par + " AND del_det.pl_sales_order_del_det_qty>0 "
            query_complete += "UNION ALL "
            query_complete += "SELECT del.id_wh_drawer AS `drawer`, '2', del_det.id_product, dsg.design_cop, '43' AS `report_mark_type`, del.id_pl_sales_order_del AS `id_report`, del_det.pl_sales_order_del_det_qty, NOW(), '','1' "
            query_complete += "FROM tb_pl_sales_order_del del "
            query_complete += "INNER JOIN tb_pl_sales_order_del_det del_det ON del.id_pl_sales_order_del = del_det.id_pl_sales_order_del "
            query_complete += "INNER JOIN tb_m_product prod ON prod.id_product = del_det.id_product  "
            query_complete += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
            query_complete += "WHERE del.id_pl_sales_order_del=" + id_report_par + " AND del_det.pl_sales_order_del_det_qty>0 "
            query_complete += "UNION ALL "
            query_complete += "SELECT getCompByContact(del.id_store_contact_to, 4) AS `drawer`, '1', del_det.id_product, dsg.design_cop, '43' AS `report_mark_type`, del.id_pl_sales_order_del AS `id_report`, del_det.pl_sales_order_del_det_qty, NOW(), '','1' "
            query_complete += "FROM tb_pl_sales_order_del del "
            query_complete += "INNER JOIN tb_pl_sales_order_del_det del_det ON del.id_pl_sales_order_del = del_det.id_pl_sales_order_del "
            query_complete += "INNER JOIN tb_m_product prod ON prod.id_product = del_det.id_product  "
            query_complete += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
            query_complete += "WHERE del.id_pl_sales_order_del=" + id_report_par + " AND del_det.pl_sales_order_del_det_qty>0 "
            execute_non_query(query_complete, True, "", "", "", "")
        End If
        Dim query As String = String.Format("UPDATE tb_pl_sales_order_del SET id_report_status='{0}', last_update=NOW(), last_update_by=" + id_user + " WHERE id_pl_sales_order_del ='{1}'", id_status_reportx_par, id_report_par)
        execute_non_query(query, True, "", "", "", "")
    End Sub
End Class
