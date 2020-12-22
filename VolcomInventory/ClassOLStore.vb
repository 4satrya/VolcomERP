Public Class ClassOLStore
    Sub evaluateOOS(ByVal id_order_par As String, ByVal id_comp_group_par As String)
        execute_non_query_long("CALL check_oos_web_order_grp(" + id_order_par + ", " + id_comp_group_par + ");", True, "", "", "", "")
    End Sub

    Sub checkOOSEmptyOrder(ByVal id_order_par As String, ByVal id_comp_group_par As String)
        execute_non_query_long("CALL check_oos_empty_order_grp(" + id_order_par + ", " + id_comp_group_par + ");", True, "", "", "", "")
    End Sub

    Function checkOOSRestockOrder(ByVal id_order_par As String, ByVal id_comp_group_par As String)
        Dim query_check As String = "SELECT * FROM tb_ol_store_order od WHERE od.id='" + id_order_par + "' AND od.id_comp_group='" + id_comp_group_par + "' AND od.is_poss_replace=1 "
        Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")
        If data_check.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub sendEmailOOS(ByVal id_order_par As String, ByVal id_comp_group_par As String)
        'get id oos
        Dim data As DataTable = viewListOOS("AND os.id_comp_group='" + id_comp_group_par + "' AND os.id_order='" + id_order_par + "' ")
        Dim id_report As String = data.Rows(0)("id_ol_store_oos").ToString
        Dim id_comp_group As String = data.Rows(0)("id_comp_group").ToString
        Dim comp_group As String = data.Rows(0)("comp_group").ToString
        Dim number As String = data.Rows(0)("number").ToString
        Dim created_date As String = DateTime.Parse(data.Rows(0)("created_date").ToString).ToString("dd MMMM yyyy")
        Dim customer_name As String = data.Rows(0)("customer_name").ToString
        Dim order_no As String = data.Rows(0)("order_number").ToString
        Dim id_comp As String = data.Rows(0)("id_comp").ToString
        Dim total_fill As Decimal = data.Rows(0)("total_fill")

        'detail oos
        Dim data_det As DataTable = viewDetailOOS(id_report)

        'penentuan oos seluruhnya atau sebagian
        Dim opt_email As String = ""
        If total_fill <= 0 Then
            'oos seluruhnya
            opt_email = "1"
        Else
            'oos sebagian
            opt_email = "2"
        End If

        'send email
        Dim m As New ClassSendEmail()
        m.id_report = id_report
        m.report_mark_type = "278"
        m.opt = opt_email
        m.comment = id_comp_group
        m.par1 = comp_group
        m.par2 = number
        m.date_string = created_date
        m.design_code = order_no
        m.design = customer_name
        m.dt = data_det
        m.season = id_comp
        m.send_email()
    End Sub

    Function viewListOOS(ByVal cond_par As String) As DataTable
        Dim query As String = "SELECT os.id_ol_store_oos, os.number, os.id_comp_group, cg.description AS `comp_group`, os.id_order, od.sales_order_ol_shop_number AS `order_number`, os.created_date,
        os.manual_send_email_reason, os.sent_email_date,os.id_ol_store_oos_stt, stt.ol_store_oos_stt,
        od.customer_name, SUM(od.ol_order_qty) AS `total_order`, SUM(od.sales_order_det_qty) AS `total_fill`, 
        SUM(od.ol_order_qty)-SUM(od.sales_order_det_qty) AS `total_no_stock`,
        IF(os.is_closed=1, 'Close', 'Open') AS `status`, cg.id_comp, cg.id_api_type
        FROM tb_ol_store_oos os
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = os.id_comp_group
        INNER JOIN tb_ol_store_order od ON od.id_ol_store_oos = os.id_ol_store_oos
        INNER JOIN tb_ol_store_oos_stt stt ON stt.id_ol_store_oos_stt= os.id_ol_store_oos_stt
        WHERE 1=1 " + cond_par + "
        GROUP BY os.id_ol_store_oos 
        ORDER BY os.id_ol_store_oos DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Function viewDetailOOS(ByVal id_oos_par As String)
        Dim query As String = "SELECT od.id_product, od.ol_store_sku, od.sku, od.ol_store_id, od.item_id, p.product_display_name AS `product_name`, cd.code_detail_name AS `size`,
        od.ol_order_qty AS `order_qty`,od.sales_order_det_qty AS `so_qty`,(od.ol_order_qty-od.sales_order_det_qty) AS `oos_qty`
        FROM tb_ol_store_order od
        INNER JOIN tb_m_product p ON p.id_product = od.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        WHERE od.id_ol_store_oos='" + id_oos_par + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Function viewLogOrder(ByVal id_order_par As String, ByVal id_comp_group_par As String) As DataTable
        Dim query As String = "SELECT l.id, l.id_comp_group, cg.comp_group, cg.description AS `comp_group_desc`, l.log_date, l.log_note
        FROM tb_ol_store_order_log l 
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = l.id_comp_group
        WHERE l.id_comp_group='" + id_comp_group_par + "' AND l.id='" + id_order_par + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Function isRestockOpen(ByVal id_oos As String) As Boolean
        Dim query As String = "SELECT * FROM tb_sales_order so
WHERE so.id_report_status=6 AND so.id_ol_store_oos='" + id_oos + "' AND so.id_prepare_status=1 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function adaNoStock(ByVal id_order_par As String, ByVal id_comp_group_par As String) As Boolean
        Dim query As String = "SELECT (od.ol_order_qty - od.sales_order_det_qty) AS `no_stock` 
FROM tb_ol_store_order od WHERE od.id='" + id_order_par + "' AND od.id_comp_group='" + id_comp_group_par + "'
HAVING no_stock>0 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function isValidFullfill(ByVal id_order_par As String, ByVal id_comp_group_par As String, ByVal id_oos_par As String) As Boolean
        Dim query As String = "SELECT od.id_product, SUM(od.sales_order_det_qty) AS `so_qty`, IFNULL(st.reserved_qty,0) AS `rsv_qty`
FROM tb_ol_store_order od 
LEFT JOIN (
	SELECT f.id_product,SUM(IF(f.id_stock_status=2, (IF(f.id_storage_category=1, CONCAT('-', f.storage_product_qty), f.storage_product_qty)),0)) AS `reserved_qty`
  	FROM tb_storage_fg f
  	WHERE f.report_mark_type=278 AND f.id_report='" + id_oos_par + "'
  	GROUP BY f.id_product
) st ON st.id_product = od.id_product
WHERE od.id='" + id_order_par + "' AND od.id_comp_group='" + id_comp_group_par + "'
GROUP BY od.id_product
HAVING so_qty<>rsv_qty"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Function isPartialOrder(ByVal id_order_par As String, ByVal id_comp_group_par As String) As Boolean
        Dim query As String = "SELECT SUM(od.sales_order_det_qty) AS `total_fill` 
        FROM tb_ol_store_order od
        WHERE od.id_comp_group='" + id_comp_group_par + "' AND od.id='" + id_order_par + "'
        GROUP BY od.id "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim total_fill As Decimal = 0.00
        If data.Rows.Count <= 0 Then
            total_fill = 0.00
        Else
            total_fill = data.Rows(0)("total_fill")
        End If
        If total_fill <= 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Sub decideCompleteOrder(ByVal id_web_order As String, ByVal id_comp_group As String, ByVal id_oos As String, ByVal id_api_type As String)
        Dim ord As New ClassSalesOrder()
        Dim err_sync As String = ""
        Try
            Dim qry As String = "CALL create_oos_close_stock_grp('" + id_oos + "', '" + id_web_order + "', '" + id_comp_group + "');CALL create_oos_sync_grp(" + id_web_order + ", " + id_comp_group + ", " + id_oos + ",4);"
            execute_non_query_long(qry, True, "", "", "", "")
        Catch ex As Exception
            err_sync = addSlashes(ex.ToString)
            ord.insertLogWebOrder(id_web_order, "Problem closing order :" + addSlashes(ex.ToString), id_comp_group)
        End Try
        'other action
        Dim err_other_act As String = ""
        If id_api_type = "2" Then
            'ZALORA
            Try
                Dim zal As New ClassZaloraApi()
                err_other_act = zal.setRTSPending()
            Catch ex As Exception
                err_other_act = "Problem set RTS :" + addSlashes(ex.ToString)
                ord.insertLogWebOrder(id_web_order, err_other_act, id_comp_group)
            End Try
        End If
    End Sub

    Sub decidePartialOrder(ByVal id_web_order As String, ByVal id_comp_group As String, ByVal id_oos As String)
        Dim ord As New ClassSalesOrder()
        Dim err_send As String = ""
        Try
            sendEmailOOS(id_web_order, id_comp_group)
            execute_non_query("UPDATE tb_ol_store_oos SET id_ol_store_oos_stt=3, sent_email_date=NOW() WHERE id_ol_store_oos='" + id_oos + "' ", True, "", "", "", "")
            ord.insertLogWebOrder(id_web_order, "Evaluate result : No stock;Send Email OOS success; Status=email sent", id_comp_group)
        Catch ex As Exception
            err_send = addSlashes(ex.ToString)
            ord.insertLogWebOrder(id_web_order, "Evaluate result : No stock & Send Email OOS failed. Detail:" + err_send, id_comp_group)
        End Try
    End Sub

    Sub decideCancelOrder(ByVal id_web_order As String, ByVal id_comp_group As String, ByVal id_oos As String, ByVal id_api_type As String)
        Dim ord As New ClassSalesOrder()
        'email confirmation
        Dim err_send As String = ""
        Try
            sendEmailOOS(id_web_order, id_comp_group)
            execute_non_query("UPDATE tb_ol_store_oos SET id_ol_store_oos_stt=3, sent_email_date=NOW() WHERE id_ol_store_oos='" + id_oos + "' ", True, "", "", "", "")
            ord.insertLogWebOrder(id_web_order, "Evaluate result : No stock;Send Email OOS success; Status=email sent", id_comp_group)
        Catch ex As Exception
            err_send = addSlashes(ex.ToString)
            ord.insertLogWebOrder(id_web_order, "Evaluate result : No stock & Send Email OOS failed. Detail:" + err_send, id_comp_group)
        End Try

        'close order
        'code here
        'check jika kosong langsung di closed
        Dim err_close As String = ""
        Try
            checkOOSEmptyOrder(id_web_order, id_comp_group)
        Catch ex As Exception
            err_close = addSlashes(ex.ToString)
            ord.insertLogWebOrder(id_web_order, "Failed close order :" + err_close, id_comp_group)
        End Try


        'other action
        Dim err_other_act As String = ""
        If id_api_type = "2" Then
            'ZALORA
            Try
                Dim zal As New ClassZaloraApi()
                err_other_act = zal.setRTSPending()
            Catch ex As Exception
                err_other_act = addSlashes(ex.ToString)
                ord.insertLogWebOrder(id_web_order, "Failed set rts :" + err_other_act, id_comp_group)
            End Try
        End If
    End Sub

    Sub oosRestockChecking(ByVal id_web_order As String, ByVal id_comp_group As String, ByVal id_oos As String, ByVal id_api_type As String)
        Dim is_open_restock As Boolean = isRestockOpen(id_oos)
        'cek no stock
        Dim is_no_stock As Boolean = adaNoStock(id_web_order, id_comp_group)
        'cek fulfill
        Dim is_partial_order As Boolean = isPartialOrder(id_web_order, id_comp_group)
        'cek valid fullfill & reserved qty
        Dim is_valid_fullfill As Boolean = isValidFullfill(id_web_order, id_comp_group, id_oos)
        Dim ord As New ClassSalesOrder()

        'jika tidak ada yang open restock & tidak ada no stock & valid fulfill lansung sync
        'decision : complete order
        If Not is_open_restock And Not is_no_stock And is_valid_fullfill Then
            'completed order
            decideCompleteOrder(id_web_order, id_comp_group, id_oos, id_api_type)
        End If

        'jika tidak ada yang open restock
        ' ada no stock
        ' ada fulfill
        ' valid fullfill
        'decision : email no stock partial item
        If Not is_open_restock And is_no_stock And is_partial_order And is_valid_fullfill Then
            'partial order
            decidePartialOrder(id_web_order, id_comp_group, id_oos)
        End If

        'jika tidak ada yang open restock
        ' semua no stock
        ' ada fulfill
        ' valid fullfill
        'decision : cancel order
        If Not is_open_restock And is_no_stock And Not is_partial_order And is_valid_fullfill Then
            'cancel order
            decideCancelOrder(id_web_order, id_comp_group, id_oos, id_api_type)
        End If
    End Sub
End Class
