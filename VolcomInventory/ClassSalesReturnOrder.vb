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

    Public Function queryOnHold(ByVal condition As String, ByVal order_type As String, is_view_stock As Boolean, id_comp As String) As String
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

        Dim col_soh As String = ""
        Dim join_soh As String = ""
        If is_view_stock Then
            col_soh = ",IFNULL(stc.qty_soh,0) AS `qty_soh` "
            join_soh = "LEFT JOIN (
	            SELECT j.id_product,
	            SUM(IF(j.id_storage_category=2, CONCAT('-', j.storage_product_qty), j.storage_product_qty)) AS `qty_soh`
	            FROM tb_storage_fg j
	            INNER JOIN tb_m_comp c ON c.id_drawer_def = j.id_wh_drawer
	            WHERE c.id_comp=" + id_comp + "
	            GROUP BY j.id_product, j.id_wh_drawer, j.bom_unit_price
            ) stc ON stc.id_product = rod.id_product "
        End If

        Dim query As String = "SELECT ro.id_sales_return_order, rod.id_sales_return_order_det, ro.sales_return_order_date, ro.sales_return_order_est_date, ro.sales_return_order_est_del_date,
        c.comp_number, c.comp_name, CONCAT(c.comp_number, ' - ',c.comp_name) AS `store`,
        d.id_design, rod.id_product, prod.product_full_code AS `code`, d.design_display_name AS `name`, cd.code_detail_name AS `size`, rod.sales_return_order_det_qty,
        prc.id_design_price, prc.design_price, prc.design_cat, IFNULL(rof.id_sales_return_order,0) AS `id_ro_ref`,IF(ISNULL(rof.id_detail_on_hold), 'No','Yes') AS `is_used`, rof.sales_return_order_number, 0 AS `qty_ror`
        " + col_soh + "
        FROM tb_sales_return_order ro
        INNER JOIN tb_sales_return_order_det rod ON rod.id_sales_return_order = ro.id_sales_return_order
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ro.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_m_product prod ON prod.id_product = rod.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_design d ON d.id_design = prod.id_design
        LEFT JOIN( 
          Select * FROM ( 
          Select price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
          price.id_design_price_type, price_type.design_price_type,
          cat.id_design_cat, cat.design_cat
          From tb_m_design_price price 
          INNER Join tb_lookup_design_price_type price_type On price.id_design_price_type = price_type.id_design_price_type 
          INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
          WHERE price.is_active_wh =1 AND price.design_price_start_date <= NOW() 
          ORDER BY price.design_price_start_date DESC, price.id_design_price DESC ) a 
          GROUP BY a.id_design 
        ) prc ON prc.id_design = prod.id_design 
        LEFT JOIN (
	        SELECT ro.id_sales_return_order, rod.id_detail_on_hold,ro.sales_return_order_number
	        FROM tb_sales_return_order_det rod
	        INNER JOIN tb_sales_return_order ro ON ro.id_sales_return_order = rod.id_sales_return_order
            WHERE ro.id_report_status!=5
	        GROUP BY rod.id_detail_on_hold
        ) rof ON rof.id_detail_on_hold = rod.id_sales_return_order_det
        " + join_soh + "
        WHERE ro.is_on_hold=1 "
        query += condition + " "
        query += "ORDER BY ro.id_sales_return_order " + order_type
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
