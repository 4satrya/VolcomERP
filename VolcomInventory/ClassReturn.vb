Public Class ClassReturn
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
        query += "SELECT a.id_sales_return_order, d.is_use_unique_code, a.id_store_contact_to, a.id_wh_contact_to, IFNULL(d.id_drawer_def,-1) AS `id_wh_drawer_store`, IFNULL(rck.id_wh_rack,-1) AS `id_wh_rack_store`, IFNULL(rck.id_wh_locator,-1) AS `id_wh_locator_store`, CONCAT(d.comp_number,' - ',d.comp_name) AS store_name_to, CONCAT(wh.comp_number,' - ',wh.comp_name) AS wh_name_to,a.id_report_status, f.report_status, "
        query += "a.sales_return_order_note, a.sales_return_order_note, a.sales_return_order_number, "
        query += "a.sales_return_order_date, "
        query += "a.sales_return_order_est_date, "
        query += "IF(DATEDIFF(DATE(NOW()), a.sales_return_order_est_date)>0, CONCAT('+',DATEDIFF(DATE(NOW()), a.sales_return_order_est_date)), DATEDIFF(DATE(NOW()), a.sales_return_order_est_date)) AS time_remaining, "
        query += "IFNULL(g.created_return,0) AS created_return, IFNULL(h.order_qty,0) AS order_qty, IFNULL(i.return_qty,0) AS return_qty, "
        query += "(a.sales_return_order_est_date) AS sales_return_order_est_date_org, "
        query += "DATE(NOW()) AS sales_return_order_date_current, a.id_prepare_status,stt_ord.prepare_status, "
        query += "((IFNULL(i.return_qty,0)/IFNULL(h.order_qty,0))*100) AS `svc_level`, 'No' as `is_select`, IFNULL(ots.outstanding,0) AS `outstanding`, a.final_comment, a.final_date, fe.employee_name AS `final_by_name`, IFNULL(a.id_sales_order,0) AS `id_sales_order`, so.sales_order_ol_shop_number, ot.order_type, IFNULL(DATE_FORMAT(a.pickup_date, '%d %M %Y'), '-') AS pickup_date, IFNULL(epd.employee_name, '-') AS pickup_date_updated_by, IFNULL(DATE_FORMAT(a.pickup_date_updated_at, '%d %M %Y/%H:%i:%s'), '-') AS pickup_date_updated_at, 3pl.id_status AS id_3pl_status, IFNULL(3pl.comp_name, '-') AS 3pl_name, IFNULL(3pl.status, '-') AS 3pl_status "
        query += "FROM tb_sales_return_order a "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "LEFT JOIN tb_m_comp_contact whc ON whc.id_comp_contact = a.id_wh_contact_to "
        query += "LEFT JOIN tb_m_comp wh ON wh.id_comp = whc.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "LEFT JOIN( "
        query += "SELECT a_sub.id_sales_return_order, COUNT(a_sub.id_sales_return) AS created_return FROM tb_sales_return a_sub WHERE a_sub.id_report_status!='5' GROUP BY a_sub.id_sales_return_order "
        query += ") g ON g.id_sales_return_order = a.id_sales_return_order "
        query += "LEFT JOIN ( "
        query += "SELECT rto.id_sales_return_order, SUM(rto_det.sales_return_order_det_qty) AS order_qty "
        query += "FROM tb_sales_return_order rto "
        query += "INNER JOIN tb_sales_return_order_det rto_det ON rto.id_sales_return_order = rto_det.id_sales_return_order "
        query += "WHERE rto.id_report_status='6' "
        query += "GROUP BY rto.id_sales_return_order "
        query += ") h ON h.id_sales_return_order = a.id_sales_return_order "
        query += "LEFT JOIN ( "
        query += "SELECT rt.id_sales_return_order, SUM(rt_det.sales_return_det_qty) AS return_qty "
        query += "FROM tb_sales_return rt "
        query += "INNER JOIN tb_sales_return_det rt_det ON rt.id_sales_return = rt_det.id_sales_return "
        query += "WHERE rt.id_report_status='6' "
        query += "GROUP BY rt.id_sales_return_order "
        query += ") i ON i.id_sales_return_order = a.id_sales_return_order "
        query += "INNER JOIN tb_lookup_prepare_status stt_ord ON stt_ord.id_prepare_status = a.id_prepare_status "
        query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = d.id_drawer_def "
        query += "INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
        query += "LEFT JOIN (
        SELECT ret.id_sales_return_order,COUNT(*) AS `outstanding` FROM tb_sales_return ret
        WHERE ret.id_report_status!=5 AND ret.id_report_status!=6
        GROUP BY ret.id_sales_return_order
        ) ots ON ots.id_sales_return_order = a.id_sales_return_order "
        query += "LEFT JOIN tb_m_user fu ON fu.id_user = a.final_by "
        query += "LEFT JOIN tb_m_employee fe ON fe.id_employee = fu.id_employee "
        query += "LEFT JOIN tb_sales_order so ON so.id_sales_order = a.id_sales_order "
        query += "LEFT JOIN tb_lookup_order_type ot ON ot.id_order_type = a.id_order_type "
        query += "LEFT JOIN tb_m_user upd ON upd.id_user = a.pickup_date_updated_by "
        query += "LEFT JOIN tb_m_employee epd ON epd.id_employee = upd.id_employee "
        query += "LEFT JOIN (
            SELECT id_report 
            FROM tb_mail_manage_det AS d 
            LEFT JOIN tb_mail_manage AS h ON d.id_mail_manage = h.id_mail_manage
            WHERE h.report_mark_type = 45 AND h.id_mail_status = 2
        ) mail ON a.id_sales_return_order = mail.id_report "
        query += "LEFT JOIN (
            SELECT tb.id_sales_order_return, tb.comp_name, tb.id_status, tb.status
            FROM (
                SELECT d.id_mail_3pl_det, d.id_sales_order_return, c.comp_name, l.id_status, l.status
                FROM tb_sales_return_order_mail_3pl_det AS d
                LEFT JOIN tb_sales_return_order_mail_3pl AS h ON d.id_mail_3pl = h.id_mail_3pl
                LEFT JOIN tb_lookup_ror_mail_3pl_status_lookup AS l ON h.id_status = l.id_status
                LEFT JOIN tb_m_comp AS c ON h.id_3pl = c.id_comp
                ORDER BY d.id_mail_3pl_det DESC
            ) AS tb
            GROUP BY tb.id_sales_order_return
        ) 3pl ON a.id_sales_return_order = 3pl.id_sales_order_return "
        query += "WHERE a.id_sales_return_order>0 " + condition
        query += "ORDER BY a.id_sales_return_order " + order_type
        Return query
    End Function
End Class
