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
        query += "SELECT a.id_sales_return_order, a.id_store_contact_to, IFNULL(d.id_drawer_def,-1) AS `id_wh_drawer_store`, IFNULL(rck.id_wh_rack,-1) AS `id_wh_rack_store`, IFNULL(rck.id_wh_locator,-1) AS `id_wh_locator_store`, CONCAT(d.comp_number,' - ',d.comp_name) AS store_name_to,a.id_report_status, f.report_status, "
        query += "a.sales_return_order_note, a.sales_return_order_note, a.sales_return_order_number, "
        query += "a.sales_return_order_date, "
        query += "a.sales_return_order_est_date, "
        query += "IF(DATEDIFF(DATE(NOW()), a.sales_return_order_est_date)>0, CONCAT('+',DATEDIFF(DATE(NOW()), a.sales_return_order_est_date)), DATEDIFF(DATE(NOW()), a.sales_return_order_est_date)) AS time_remaining, "
        query += "IFNULL(g.created_return,0) AS created_return, IFNULL(h.order_qty,0) AS order_qty, IFNULL(i.return_qty,0) AS return_qty, "
        query += "(a.sales_return_order_est_date) AS sales_return_order_est_date_org, "
        query += "DATE(NOW()) AS sales_return_order_date_current, a.id_prepare_status,stt_ord.prepare_status, "
        query += "((IFNULL(i.return_qty,0)/IFNULL(h.order_qty,0))*100) AS `svc_level`, 'No' as `is_select`, IFNULL(ots.outstanding,0) AS `outstanding`, a.final_comment, a.final_date, fe.employee_name AS `final_by_name` "
        query += "FROM tb_sales_return_order a "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
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
        query += "WHERE a.id_sales_return_order>0 " + condition
        query += "ORDER BY a.id_sales_return_order " + order_type
        Return query
    End Function
End Class
