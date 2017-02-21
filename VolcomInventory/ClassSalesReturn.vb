﻿Public Class ClassSalesReturn
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
        query += "SELECT a.id_comp_contact_to, a.id_report_status, a.id_sales_return, a.id_sales_return_order, a.sales_return_date, "
        query += "a.sales_return_note, a.sales_return_number, a.sales_return_store_number,  "
        query += "CONCAT(c.comp_number,' - ',c.comp_name) AS store_name_from, (c.comp_name) AS store_name_to, "
        query += "CONCAT(e.comp_number,' - ',e.comp_name) AS comp_name_to, (e.comp_number) AS comp_number_to, "
        query += "f.sales_return_order_number, g.report_status, a.last_update, getUserEmp(a.last_update_by, '1') AS `last_user`, ('No') AS `is_select` "
        query += "FROM tb_sales_return a  "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_store_contact_from = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp "
        query += "INNER JOIN tb_m_comp_contact d ON a.id_comp_contact_to = d.id_comp_contact "
        query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
        query += "INNER JOIN tb_sales_return_order f ON f.id_sales_return_order = a.id_sales_return_order "
        query += "INNER JOIN tb_lookup_report_status g ON g.id_report_status = a.id_report_status "
        query += "WHERE a.id_sales_return>0 "
        query += condition + " "
        query += "ORDER BY a.id_sales_return " + order_type
        Return query
    End Function

    Public Sub changeStatus(ByVal id_report_par As String, ByVal id_status_reportx_par As String)
        If id_status_reportx_par = "5" Then
            'cancel reserved stock store
            Dim stc_cancel As ClassSalesReturn = New ClassSalesReturn()
            stc_cancel.cancelReservedStock(id_report_par)
        ElseIf id_status_reportx_par = "6" Then
            ' jika complete
            Dim stc_compl As ClassSalesReturn = New ClassSalesReturn()
            stc_compl.completeReservedStock(id_report_par)
        End If

        Dim query As String = String.Format("UPDATE tb_sales_return SET id_report_status='{0}', last_update=NOW(), last_update_by=" + id_user + " WHERE id_sales_return ='{1}'", id_status_reportx_par, id_report_par)
        execute_non_query(query, True, "", "", "", "")
    End Sub

    ' ----------------------
    'for stock out
    ' ----------------------
    Public Sub reservedStock(ByVal id_report_param As String)
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) 
        SELECT getCompByContact(r.id_store_contact_from, 4), '2', rd.id_product, IFNULL(dsg.design_cop,0), '46', '" + id_report_param + "', rd.sales_return_det_qty, NOW(), '', '2' 
        FROM tb_sales_return r 
        INNER JOIN tb_sales_return_det rd ON rd.id_sales_return = r.id_sales_return 
        INNER JOIN tb_m_product prod ON prod.id_product = rd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design 
        WHERE r.id_sales_return=" + id_report_param + " AND rd.sales_return_det_qty>0 "
        execute_non_query(query, True, "", "", "", "")

        'reserved stock old
        'Dim query_res As String = "CALL view_sales_return('" + id_report_param + "') "
        'Dim dt_rsv As DataTable = execute_query(query_res, -1, True, "", "", "", "")
        'Dim stc_rsv As ClassStock = New ClassStock()
        'For s As Integer = 0 To dt_rsv.Rows.Count - 1
        '    If dt_rsv.Rows(s)("sales_return_det_qty") > 0 Then
        '        stc_rsv.prepInsStockFG(dt_rsv.Rows(s)("id_wh_drawer_store").ToString, "2", dt_rsv.Rows(s)("id_product").ToString, decimalSQL(dt_rsv.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_rsv.Rows(s)("sales_return_det_qty").ToString), "", "2")
        '    End If
        'Next
        'stc_rsv.insStockFG()
    End Sub

    Public Sub cancelReservedStock(ByVal id_report_param As String)
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) 
        SELECT getCompByContact(r.id_store_contact_from, 4), '1', rd.id_product, IFNULL(dsg.design_cop,0), '46', '" + id_report_param + "', rd.sales_return_det_qty, NOW(), '', '2' 
        FROM tb_sales_return r 
        INNER JOIN tb_sales_return_det rd ON rd.id_sales_return = r.id_sales_return 
        INNER JOIN tb_m_product prod ON prod.id_product = rd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design 
        WHERE r.id_sales_return=" + id_report_param + " AND rd.sales_return_det_qty>0 "
        execute_non_query(query, True, "", "", "", "")

        'cancelled reserved stock old
        'Dim query_compl As String = "CALL view_sales_return('" + id_report_param + "') "
        'Dim dt_cancel As DataTable = execute_query(query_compl, -1, True, "", "", "", "")

        'Dim stc_remove_rsv As ClassStock = New ClassStock()
        'For s As Integer = 0 To dt_cancel.Rows.Count - 1
        '    stc_remove_rsv.prepInsStockFG(dt_cancel.Rows(s)("id_wh_drawer_store").ToString, "1", dt_cancel.Rows(s)("id_product").ToString, decimalSQL(dt_cancel.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_cancel.Rows(s)("sales_return_det_qty").ToString), "", "2")
        'Next
        'stc_remove_rsv.insStockFG()
    End Sub

    Public Sub completeReservedStock(ByVal id_report_param As String)
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) 
        SELECT getCompByContact(r.id_store_contact_from, 4), '1', rd.id_product, IFNULL(dsg.design_cop,0), '46', '" + id_report_param + "', rd.sales_return_det_qty, NOW(), '', '2' 
        FROM tb_sales_return r 
        INNER JOIN tb_sales_return_det rd ON rd.id_sales_return = r.id_sales_return 
        INNER JOIN tb_m_product prod ON prod.id_product = rd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design 
        WHERE r.id_sales_return=" + id_report_param + " AND rd.sales_return_det_qty>0 
        UNION ALL 
        SELECT getCompByContact(r.id_store_contact_from, 4), '2', rd.id_product, IFNULL(dsg.design_cop,0), '46', '" + id_report_param + "', rd.sales_return_det_qty, NOW(), '', '1' 
        FROM tb_sales_return r 
        INNER JOIN tb_sales_return_det rd ON rd.id_sales_return = r.id_sales_return 
        INNER JOIN tb_m_product prod ON prod.id_product = rd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design 
        WHERE r.id_sales_return=" + id_report_param + " AND rd.sales_return_det_qty>0 
        UNION ALL 
        SELECT getCompByContact(r.id_comp_contact_to, 4), '1', rd.id_product, IFNULL(dsg.design_cop,0), '46', '" + id_report_param + "', rd.sales_return_det_qty, NOW(), '', '1' 
        FROM tb_sales_return r 
        INNER JOIN tb_sales_return_det rd ON rd.id_sales_return = r.id_sales_return 
        INNER JOIN tb_m_product prod ON prod.id_product = rd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design 
        WHERE r.id_sales_return=" + id_report_param + " AND rd.sales_return_det_qty>0 "
        execute_non_query(query, True, "", "", "", "")

        'complete old
        'Dim query_compl As String = "CALL view_sales_return('" + id_report_param + "') "
        'Dim dt_compl As DataTable = execute_query(query_compl, -1, True, "", "", "", "")

        'Dim stc_remove_rsv As ClassStock = New ClassStock()
        'Dim stc_compl As ClassStock = New ClassStock()
        'Dim stc_in As ClassStock = New ClassStock()
        'For s As Integer = 0 To dt_compl.Rows.Count - 1
        '    stc_remove_rsv.prepInsStockFG(dt_compl.Rows(s)("id_wh_drawer_store").ToString, "1", dt_compl.Rows(s)("id_product").ToString, decimalSQL(dt_compl.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sales_return_det_qty").ToString), "", "2")
        '    stc_compl.prepInsStockFG(dt_compl.Rows(s)("id_wh_drawer_store").ToString, "2", dt_compl.Rows(s)("id_product").ToString, decimalSQL(dt_compl.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sales_return_det_qty").ToString), "", "1")
        '    stc_in.prepInsStockFG(dt_compl.Rows(s)("id_wh_drawer").ToString, "1", dt_compl.Rows(s)("id_product").ToString, decimalSQL(dt_compl.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sales_return_det_qty").ToString), "", "1")
        'Next
        'stc_remove_rsv.insStockFG()
        'stc_compl.insStockFG()
        'stc_in.insStockFG()
    End Sub

End Class
