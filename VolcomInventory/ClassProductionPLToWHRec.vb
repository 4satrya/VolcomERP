Public Class ClassProductionPLToWHRec
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

        Dim query As String = "SELECT CONCAT(vend_c.comp_number, ' - ', vend_c.comp_name) AS vendor, i.prod_order_number,dsg.id_design, (dsg.design_display_name) AS `design_name`, dsg.design_code AS `code`, k.pl_category, i.prod_order_number, a0.id_pl_prod_order_rec , a0.id_comp_contact_from , a0.id_comp_contact_to, a0.pl_prod_order_rec_note, a0.pl_prod_order_rec_number, a.pl_prod_order_number, "
        query += "CONCAT(d.comp_number,' - ',d.comp_name) AS comp_name_from, CONCAT(f.comp_number,' - ',f.comp_name) AS comp_name_to, h.report_status, a0.id_report_status, "
        query += "a0.pl_prod_order_rec_date, ss.id_season, ss.season, IFNULL(det.total_qty,0) AS `total_qty`, "
        query += "a0.last_update, getUserEmp(a0.last_update_by, '1') AS last_user, ('No') AS is_select "
        query += "FROM tb_pl_prod_order_rec a0 "
        query += "INNER JOIN tb_pl_prod_order a ON a.id_pl_prod_order = a0.id_pl_prod_order "
        query += "INNER JOIN tb_m_comp_contact c ON a0.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a0.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a0.id_report_status "
        query += "INNER JOIN tb_prod_order i ON a.id_prod_order = i.id_prod_order "
        query += "LEFT JOIN tb_prod_order_wo vend_wo ON vend_wo.id_prod_order = i.id_prod_order AND vend_wo.is_main_vendor='1' "
        query += "LEFT JOIN tb_m_ovh_price vend_ovh ON vend_ovh.id_ovh_price = vend_wo.id_ovh_price "
        query += "LEFT JOIN tb_m_comp_contact vend_cc On vend_cc.id_comp_contact = vend_ovh.id_comp_contact "
        query += "LEFT JOIN tb_m_comp vend_c ON vend_c.id_comp = vend_cc.id_comp "
        query += "INNER JOIN tb_pl_prod_order_det j On a.id_pl_prod_order = j.id_pl_prod_order "
        query += "INNER JOIN tb_lookup_pl_category k On k.id_pl_category = a.id_pl_category "
        query += "INNER JOIN tb_season_delivery del On del.id_delivery = i.id_delivery "
        query += "INNER JOIN tb_season ss On ss.id_season = del.id_season "
        query += "INNER JOIN tb_prod_demand_design pd_dsg On pd_dsg.id_prod_demand_design = i.id_prod_demand_design "
        query += "INNER JOIN tb_m_design dsg On dsg.id_design = pd_dsg.id_design "
        query += "LEFT JOIN ( "
        query += "Select det.id_pl_prod_order_rec, SUM(det.pl_prod_order_rec_det_qty) As `total_qty` "
        query += "FROM tb_pl_prod_order_rec_det det "
        query += "GROUP BY det.id_pl_prod_order_rec "
        query += ") det On det.id_pl_prod_order_rec = a0.id_pl_prod_order_rec "
        query += "WHERE a0.id_pl_prod_order_rec>0 "
        query += condition
        query += "GROUP BY a0.id_pl_prod_order_rec "
        query += "ORDER BY a0.id_pl_prod_order_rec " + order_type
        Return query
    End Function

    Public Sub changeStatus(ByVal id_report_par As String, ByVal id_status_reportx_par As String)
        If id_status_reportx_par = "6" Then
            'insert stock
            Dim query_stc As String = ""
            query_stc += "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) "
            query_stc += "SELECT pl.id_wh_drawer, '1', pd_prod.id_product, dsg.design_cop , '37' , '" + id_report_par + "', pl_det.pl_prod_order_rec_det_qty, "
            query_stc += "NOW(), CONCAT('Completed, Receiving Warehouse : ', pl.pl_prod_order_rec_number), '1'   "
            query_stc += "FROM tb_pl_prod_order_rec_det pl_det "
            query_stc += "INNER JOIN tb_pl_prod_order_rec pl ON pl.id_pl_prod_order_rec = pl_det.id_pl_prod_order_rec "
            query_stc += "INNER JOIN tb_pl_prod_order_det pl_qc_det ON pl_qc_det.id_pl_prod_order_det = pl_det.id_pl_prod_order_det "
            query_stc += "INNER JOIN tb_prod_order_det po_det ON po_det.id_prod_order_det = pl_qc_det.id_prod_order_det "
            query_stc += "INNER JOIN tb_prod_demand_product pd_prod ON pd_prod.id_prod_demand_product = po_det.id_prod_demand_product "
            query_stc += "INNER JOIN tb_m_product prod ON prod.id_product = pd_prod.id_product "
            query_stc += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
            query_stc += "WHERE pl_det.id_pl_prod_order_rec = '" + id_report_par + "' AND pl_det.pl_prod_order_rec_det_qty>0 "
            execute_non_query(query_stc, True, "", "", "", "")

            'first receiving
            Dim id_designx As String = execute_query("SELECT dsg.id_design FROM tb_pl_prod_order_rec rec INNER JOIN tb_pl_prod_order pl ON pl.id_pl_prod_order = rec.id_pl_prod_order INNER JOIN tb_prod_order pdo ON pdo.id_prod_order = pl.id_prod_order INNER JOIN tb_prod_demand_design pd_dsg ON pd_dsg.id_prod_demand_design = pdo.id_prod_demand_design INNER JOIN tb_m_design dsg ON dsg.id_design = pd_dsg.id_design WHERE rec.id_pl_prod_order_rec =" + id_report_par + "", 0, True, "", "", "", "")
            Dim design_first_rec_whx As String = execute_query("SELECT IF(ISNULL(design_first_rec_wh), '0', design_first_rec_wh) AS cek_date FROM tb_m_design WHERE id_design = '" + id_designx + "' ", 0, True, "", "", "", "")
            If design_first_rec_whx = "0" Then
                Dim query_aging As String = "UPDATE tb_m_design SET design_first_rec_wh = NOW() WHERE id_design = '" + id_designx + "' "
                execute_non_query(query_aging, True, "", "", "", "")
            End If
        End If

        Dim query As String = String.Format("UPDATE tb_pl_prod_order_rec SET id_report_status='{0}', last_update=NOW(), last_update_by=" + id_user + " WHERE id_pl_prod_order_rec ='{1}'", id_status_reportx_par, id_report_par)
        execute_non_query(query, True, "", "", "", "")
    End Sub
End Class
