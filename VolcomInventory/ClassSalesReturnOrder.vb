Public Class ClassSalesReturnOrder
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

        Dim query As String = "SELECT a.id_sales_return_order, 
        a.id_store_contact_to, d.comp_number AS `store_number_to`,(d.comp_name) AS store_name_to, CONCAT(d.comp_number,' - ', d.comp_name) AS `store`, d.address_primary as `store_address`,
        a.id_wh_contact_to, wh.comp_number AS `wh_number_to`,(wh.comp_name) AS wh_name_to, CONCAT(wh.comp_number,' - ', wh.comp_name) AS `wh`,
        a.id_report_status, f.report_status, 
        a.sales_return_order_note, a.sales_return_order_note, a.sales_return_order_number, so.sales_order_ol_shop_number, 
        DATE_FORMAT(a.sales_return_order_date,'%d %M %Y') AS sales_return_order_date, DATE_FORMAT(a.sales_return_order_date,'%Y-%m-%d') AS sales_return_order_datex,
        DATE_FORMAT(a.sales_return_order_est_date,'%d %M %Y') AS sales_return_order_est_date, a.id_prepare_status, ps.prepare_status, 
        IFNULL(SUM(b.sales_return_order_det_qty),0) AS `total_qty`
        FROM tb_sales_return_order a 
        INNER JOIN tb_sales_return_order_det b ON a.id_sales_return_order = b.id_sales_return_order 
        INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to 
        INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
        LEFT JOIN tb_m_comp_contact whc ON whc.id_comp_contact = a.id_wh_contact_to 
        LEFT JOIN tb_m_comp wh ON wh.id_comp = whc.id_comp 
        INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status 
        INNER JOIN tb_lookup_prepare_status ps ON ps.id_prepare_status = a.id_prepare_status 
        LEFT JOIN tb_sales_order so ON so.id_sales_order = a.id_sales_order "
        query += "WHERE a.id_sales_return_order>0 "
        query += condition + " "
        query += "GROUP BY a.id_sales_return_order "
        query += "ORDER BY a.id_sales_return_order " + order_type
        Return query
    End Function

    'only for OL Store
    Public Sub reservedStock(ByVal id_report_param As String)
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) "
        query += "SELECT getCompByContact(ro.id_store_contact_to, 4), '2', ro_det.id_product, IFNULL(dsg.design_cop,0), '119', '" + id_report_param + "', ro_det.sales_return_order_det_qty, NOW(), '', '2' 
        FROM tb_sales_return_order ro 
        INNER JOIN tb_sales_return_order_det ro_det ON ro_det.id_sales_return_order = ro.id_sales_return_order 
        INNER JOIN tb_m_product prod ON prod.id_product = ro_det.id_product 
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design 
        WHERE ro.id_sales_return_order=" + id_report_param + " "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub cancelReservedStock(ByVal id_report_param As String)
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) "
        query += "SELECT getCompByContact(ro.id_store_contact_to, 4), '1', ro_det.id_product, IFNULL(dsg.design_cop,0), '119', '" + id_report_param + "', ro_det.sales_return_order_det_qty, NOW(), '', '2' 
        FROM tb_sales_return_order ro 
        INNER JOIN tb_sales_return_order_det ro_det ON ro_det.id_sales_return_order = ro.id_sales_return_order 
        INNER JOIN tb_m_product prod ON prod.id_product = ro_det.id_product 
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design 
        WHERE ro.id_sales_return_order=" + id_report_param + " "
        execute_non_query(query, True, "", "", "", "")
    End Sub
End Class
