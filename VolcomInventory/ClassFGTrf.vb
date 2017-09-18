Public Class ClassFGTrf
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        Dim query As String = "CALL view_fg_trf_main('" + condition + "', '" + order_type + "') "
        Return query
    End Function

    Public Function transactionList(ByVal condition As String, ByVal order_type As String) As DataTable
        Dim query As String = "CALL view_fg_trf_main2(""" + condition + """, " + order_type + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Public Function queryDetail(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_fg_trf('" + id_report_param + "')"
        Return query
    End Function

    Public Sub changeStatus(ByVal id_report_par As String, ByVal id_status_reportx_par As String)
        'rollback stock if cancelled and complerted
        If id_status_reportx_par = "6" Then
            Dim query_complete As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) "
            query_complete += "SELECT (getCompByContact(trf.id_comp_contact_from, 4)) AS `drawer`, '1', trf_det.id_product, dsg.design_cop, '39' AS `report_mark_type`, trf.id_sales_order AS `id_report`, trf_det.fg_trf_det_qty, NOW(), '', '2' "
            query_complete += "FROM tb_fg_trf trf "
            query_complete += "INNER JOIN tb_fg_trf_det trf_det ON trf_det.id_fg_trf = trf.id_fg_trf "
            query_complete += "INNER JOIN tb_m_product prod ON prod.id_product = trf_det.id_product "
            query_complete += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
            query_complete += "WHERE trf.id_fg_trf=" + id_report_par + " AND trf_det.fg_trf_det_qty >0  "
            query_complete += "UNION ALL "
            query_complete += "SELECT (getCompByContact(trf.id_comp_contact_from, 4)) AS `drawer`, '2', trf_det.id_product, dsg.design_cop, '57' AS `report_mark_type`, trf.id_fg_trf AS `id_report`, trf_det.fg_trf_det_qty, NOW(), '', '1' "
            query_complete += "FROM tb_fg_trf trf "
            query_complete += "INNER JOIN tb_fg_trf_det trf_det ON trf_det.id_fg_trf = trf.id_fg_trf "
            query_complete += "INNER JOIN tb_m_product prod ON prod.id_product = trf_det.id_product "
            query_complete += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
            query_complete += "WHERE trf.id_fg_trf=" + id_report_par + " AND trf_det.fg_trf_det_qty >0  "
            query_complete += "UNION ALL "
            query_complete += "SELECT (trf.id_wh_drawer) AS `drawer`, '1', trf_det.id_product, dsg.design_cop, '57' AS `report_mark_type`, trf.id_fg_trf AS `id_report`, trf_det.fg_trf_det_qty, NOW(), '', '1' "
            query_complete += "FROM tb_fg_trf trf "
            query_complete += "INNER JOIN tb_fg_trf_det trf_det ON trf_det.id_fg_trf = trf.id_fg_trf "
            query_complete += "INNER JOIN tb_m_product prod ON prod.id_product = trf_det.id_product "
            query_complete += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
            query_complete += "WHERE trf.id_fg_trf=" + id_report_par + " AND trf_det.fg_trf_det_qty >0  "
            execute_non_query(query_complete, True, "", "", "", "")

            'save unreg unique
            execute_non_query("CALL generate_unreg_barcode(" + id_report_par + ",2)", True, "", "", "", "")
        End If
        Dim query As String = String.Format("UPDATE tb_fg_trf SET id_report_status='{0}', id_report_status_rec = '" + id_status_reportx_par + "', last_update=NOW(), last_update_by=" + id_user + " WHERE id_fg_trf ='{1}'", id_status_reportx_par, id_report_par)
        execute_non_query(query, True, "", "", "", "")
    End Sub
End Class
