Public Class ClassFGRepair
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

        Dim query As String = ""
        query += "Select r.id_fg_repair, "
        query += "r.id_wh_drawer_from, comp_frm.id_comp As `id_comp_from`, comp_frm.comp_number As `comp_number_from`, comp_frm.comp_name As `comp_name_from`, CONCAT(comp_frm.comp_number,' - ', comp_frm.comp_name) AS `comp_from`, "
        query += "r.id_wh_drawer_to, comp_to.id_comp As `id_comp_to`, comp_to.comp_number As `comp_number_to`, comp_to.comp_name As `comp_name_to`, CONCAT(comp_to.comp_number,' - ', comp_to.comp_name) AS `comp_to`, "
        query += "r.fg_repair_number, r.fg_repair_date, DATE_FORMAT(r.fg_repair_date, '%Y-%m-%d') AS fg_repair_datex, "
        query += "r.fg_repair_note, r.id_report_status, stt.report_status, r.is_to_vendor "
        query += "From tb_fg_repair r "
        query += "INNER Join tb_m_wh_drawer drw_frm On drw_frm.id_wh_drawer = r.id_wh_drawer_from  "
        query += "INNER Join tb_m_comp comp_frm On comp_frm.id_drawer_def = drw_frm.id_wh_drawer  "
        query += "INNER Join tb_m_wh_drawer drw_to On drw_to.id_wh_drawer = r.id_wh_drawer_to "
        query += "INNER Join tb_m_comp comp_to On comp_to.id_drawer_def = drw_to.id_wh_drawer "
        query += "INNER Join tb_lookup_report_status stt On stt.id_report_status = r.id_report_status "
        query += "WHERE r.id_fg_repair>0 "
        query += condition + " "
        query += "ORDER BY r.id_fg_repair " + order_type
        Return query
    End Function

    ' ----------------------
    'for stock out
    ' ----------------------
    Public Sub reservedStock(ByVal id_report_param As String)
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) 
                            SELECT rp.id_wh_drawer_from, '2', rpd.id_product, dsg.design_cop, '91', '" + id_report_param + "', COUNT(rpd.id_product) AS `qty` , NOW(),'','2'
  	                        FROM tb_fg_repair_det rpd
	                        INNER JOIN tb_fg_repair rp ON rp.id_fg_repair = rpd.id_fg_repair
                            INNER JOIN tb_m_product prod ON prod.id_product = rpd.id_product
                            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
	                        WHERE rpd.id_fg_repair='" + id_report_param + "' 
  	                        GROUP BY rpd.id_product"
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub cancelReservedStock(ByVal id_report_param As String)
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) 
                            SELECT rp.id_wh_drawer_from, '1', rpd.id_product, dsg.design_cop, '91', '" + id_report_param + "', COUNT(rpd.id_product) AS `qty` , NOW(),'','2'
  	                        FROM tb_fg_repair_det rpd
	                        INNER JOIN tb_fg_repair rp ON rp.id_fg_repair = rpd.id_fg_repair
                            INNER JOIN tb_m_product prod ON prod.id_product = rpd.id_product
                            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
	                        WHERE rpd.id_fg_repair='" + id_report_param + "' 
  	                        GROUP BY rpd.id_product"
        execute_non_query(query, True, "", "", "", "")
    End Sub


    Public Sub completedStock(ByVal id_report_param As String)
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) 
                            SELECT rp.id_wh_drawer_from, '1', rpd.id_product, dsg.design_cop, '91', '" + id_report_param + "', COUNT(rpd.id_product) AS `qty` , NOW(),'','2'
  	                        FROM tb_fg_repair_det rpd
	                        INNER JOIN tb_fg_repair rp ON rp.id_fg_repair = rpd.id_fg_repair
                            INNER JOIN tb_m_product prod ON prod.id_product = rpd.id_product
                            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
	                        WHERE rpd.id_fg_repair='" + id_report_param + "' 
  	                        GROUP BY rpd.id_product
                            UNION ALL
                            SELECT rp.id_wh_drawer_from, '2', rpd.id_product, dsg.design_cop, '91', '" + id_report_param + "', COUNT(rpd.id_product) AS `qty` , NOW(),'','1'
  	                        FROM tb_fg_repair_det rpd
	                        INNER JOIN tb_fg_repair rp ON rp.id_fg_repair = rpd.id_fg_repair
                            INNER JOIN tb_m_product prod ON prod.id_product = rpd.id_product
                            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
	                        WHERE rpd.id_fg_repair='" + id_report_param + "' 
  	                        GROUP BY rpd.id_product
                            "
        execute_non_query(query, True, "", "", "", "")
    End Sub



End Class
