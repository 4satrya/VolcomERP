﻿Public Class ClassOLStore
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
        Dim query As String = "SELECT os.id_ol_store_oos, os.number, os.id_comp_group, cg.comp_group, os.id_order, od.sales_order_ol_shop_number AS `order_number`, os.created_date,
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
End Class