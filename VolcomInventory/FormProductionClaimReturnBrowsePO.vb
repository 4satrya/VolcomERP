Public Class FormProductionClaimReturnBrowsePO
    Private Sub FormProductionClaimReturnBrowsePO_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        view_production_order()
    End Sub

    Sub view_production_order()
        Dim query_where As String = ""

        If Not SLEDesignStockStore.EditValue.ToString = "0" Then
            query_where += " AND b.id_design='" & SLEDesignStockStore.EditValue.ToString & "'"
        End If

        If Not SLESeason.EditValue.ToString = "-1" Then
            query_where += " AND e.id_season='" & SLESeason.EditValue.ToString & "'"
        End If

        If Not SLEVendor.EditValue.ToString = "0" Then
            query_where += " AND cc.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query = "SELECT "
        query += "IFNULL(SUM(rec.prod_order_rec_det_qty),0) AS qty_rec, "
        query += "IFNULL(SUM(pod.prod_order_qty),0) As qty_order, "
        query += "IFNULL(SUM(qty_plwh.qty),0) As qty_plwh, "
        query += "comp.comp_name,a.id_prod_order,d.id_sample, a.prod_order_number, d.design_display_name, d.design_code, h.term_production, g.po_type,d.design_cop, "
        query += "a.prod_order_date,a.id_report_status,c.report_status, "
        query += "b.id_design,b.id_delivery, e.delivery, f.season, e.id_season "
        query += ",IF(ISNULL(mark.id_mark),'no','yes') AS is_submit,maxd.employee_name as last_mark "
        query += "FROM tb_prod_order a "
        query += "INNER JOIN tb_prod_order_det pod ON pod.id_prod_order=a.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design b On a.id_prod_demand_design = b.id_prod_demand_design "
        query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
        query += "INNER JOIN tb_m_design d On b.id_design = d.id_design "
        query += "INNER JOIN tb_season_delivery e On b.id_delivery=e.id_delivery "
        query += "INNER JOIN tb_season f On f.id_season=e.id_season "
        query += "INNER JOIN tb_lookup_po_type g On g.id_po_type=a.id_po_type "
        query += "INNER JOIN tb_lookup_term_production h On h.id_term_production=a.id_term_production "
        query += "LEFT JOIN tb_prod_order_wo wo On wo.id_prod_order=a.id_prod_order And wo.is_main_vendor='1' "
        query += "LEFT JOIN tb_m_ovh_price ovh_p On ovh_p.id_ovh_price=wo.id_ovh_price "
        query += "LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact "
        query += "LEFT JOIN tb_m_comp comp On comp.id_comp=cc.id_comp "
        query += "LEFT JOIN 
                    (
	                    SELECT * FROM tb_report_mark GROUP BY report_mark_type,id_report
                    ) mark ON mark.id_report=a.id_prod_order AND mark.report_mark_type='22' "
        query += "LEFT JOIN  "
        query += "( "
        query += "SELECT recd.id_prod_order_det,SUM(recd.prod_order_rec_det_qty) AS prod_order_rec_det_qty "
        query += "FROM "
        query += "tb_prod_order_rec rec "
        query += "LEFT JOIN tb_prod_order_rec_det recd On recd.id_prod_order_rec=rec.id_prod_order_rec AND rec.id_report_status != 5 "
        query += "GROUP BY recd.id_prod_order_det "
        query += ") rec On rec.id_prod_order_det=pod.id_prod_order_det "
        query += "LEFT JOIN
                    (
                    SELECT pld.`id_prod_order_det`,SUM(pld.`pl_prod_order_det_qty`) as qty FROM tb_pl_prod_order_det pld
                    INNER JOIN tb_pl_prod_order pl ON pl.`id_pl_prod_order`=pld.`id_pl_prod_order`
                    WHERE pl.`id_report_status`='6'
                    GROUP BY pld.`id_prod_order_det`
                    ) qty_plwh ON qty_plwh.id_prod_order_det=pod.id_prod_order_det "
        query += "LEFT JOIN
                 (SELECT mark.id_report_mark,mark.id_report,emp.employee_name,maxd.report_mark_datetime,mark.report_number
                    FROM tb_report_mark mark
                    INNER JOIN tb_m_employee emp ON emp.`id_employee`=mark.id_employee
                    INNER JOIN 
                    (
	                    SELECT mark.id_report,mark.report_mark_type,MAX(report_mark_datetime) AS report_mark_datetime
	                    FROM tb_report_mark mark
	                    WHERE mark.id_mark='2' AND NOT ISNULL(report_mark_start_datetime) AND report_mark_type='22'
	                    GROUP BY report_mark_type,id_report
                    ) maxd ON maxd.id_report=mark.id_report AND maxd.report_mark_type=mark.report_mark_type AND maxd.report_mark_datetime=mark.report_mark_datetime
                    WHERE mark.id_mark='2' AND NOT ISNULL(mark.report_mark_start_datetime) AND mark.report_mark_type='22'
                  ) maxd ON maxd.id_report = a.id_prod_order 
        INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order = a.id_prod_order AND wo.is_main_vendor=1 "
        query += "WHERE 1=1 " & query_where
        query += "GROUP BY a.id_prod_order"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCProd.DataSource = data
        If data.Rows.Count > 0 Then
            GVProd.FocusedRowHandle = 0
            GVProd.BestFitColumns()
            GVProd.ExpandAllGroups()
        End If
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        If GVProd.RowCount > 0 And GVProd.FocusedRowHandle >= 0 Then

        End If
    End Sub
End Class