Public Class FormProdClosing
    Private Sub FormProdClosing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDesign()
        '
        viewSeason()
        '
        viewVendor()
    End Sub
    Sub viewVendor()
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All Vendor') AS comp_name, ('ALL Vendor') AS comp_name_label UNION ALL "
        query += "SELECT comp.id_comp,comp.comp_number, comp.comp_name, CONCAT_WS(' - ', comp.comp_number,comp.comp_name) AS comp_name_label FROM tb_m_comp comp "
        query += "WHERE comp.id_comp_cat='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLEVendor.Properties.DataSource = Nothing
        SLEVendor.Properties.DataSource = data
        SLEVendor.Properties.DisplayMember = "comp_name_label"
        SLEVendor.Properties.ValueMember = "id_comp"
        If data.Rows.Count.ToString >= 1 Then
            SLEVendor.EditValue = data.Rows(0)("id_comp").ToString
        Else
            SLEVendor.EditValue = Nothing
        End If
    End Sub
    Sub viewSeason()
        Dim query As String = "SELECT '-1' AS id_season, 'All Season' as season UNION "
        query += "(SELECT id_season,season FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub
    Sub viewDesign()
        Dim query As String = ""
        query += "CALL view_design_order(TRUE)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLEDesignStockStore.Properties.DataSource = Nothing
        SLEDesignStockStore.Properties.DataSource = data
        SLEDesignStockStore.Properties.DisplayMember = "display_name"
        SLEDesignStockStore.Properties.ValueMember = "id_design"
        If data.Rows.Count.ToString >= 1 Then
            SLEDesignStockStore.EditValue = data.Rows(0)("id_design").ToString
        Else
            SLEDesignStockStore.EditValue = Nothing
        End If
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

        Dim opt_max_dom As Integer = 0 ' max tolerance domestic PO
        Dim opt_claim_dom As Integer = 0 'claim domestic PO
        Dim opt_max_int As Integer = 0 ' max tolerance international PO
        Dim opt_claim_int As Integer = 0 'claim international PO

        Dim query = "SELECT 'no' AS `check`,
                        IFNULL(SUM(rec.prod_order_rec_det_qty),0) AS qty_rec, 
                        IFNULL(SUM(pod.prod_order_qty),0) AS qty_order, 
                        comp.comp_name,a.id_prod_order,d.id_sample, a.prod_order_number, d.design_display_name, d.design_code, h.term_production, g.po_type,d.design_cop, 
                        a.prod_order_date,a.id_report_status,c.report_status, 
                        b.id_design,b.id_delivery, e.delivery, f.season, e.id_season , wod.prod_order_wo_det_price
                        ,wo.id_prod_order_wo, IF(wo.claim_discount=1,'Claim',IF(wo.claim_discount=2,'Discount','-')) as claim_discount,(wo.claim_disc_percentage/100) as claim_disc_percentage,wo.claim_disc_value
                        ,IF(wo.is_proc_disc_claim=1,'Yes','No') as is_proc_disc_claim
                        FROM tb_prod_order a 
                        INNER JOIN tb_prod_order_det pod ON pod.id_prod_order=a.id_prod_order 
                        INNER JOIN tb_prod_demand_design b ON a.id_prod_demand_design = b.id_prod_demand_design 
                        INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status 
                        INNER JOIN tb_m_design d ON b.id_design = d.id_design 
                        INNER JOIN tb_season_delivery e ON b.id_delivery=e.id_delivery 
                        INNER JOIN tb_season f ON f.id_season=e.id_season 
                        INNER JOIN tb_lookup_po_type g ON g.id_po_type=a.id_po_type 
                        INNER JOIN tb_lookup_term_production h ON h.id_term_production=a.id_term_production 
                        LEFT JOIN tb_prod_order_wo wo ON wo.id_prod_order=a.id_prod_order AND wo.is_main_vendor='1' 
                        LEFT JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price 
                        LEFT JOIN (SELECT id_prod_order_wo,prod_order_wo_det_price FROM tb_prod_order_wo_det GROUP BY id_prod_order_wo) wod ON wod.`id_prod_order_wo`=wo.`id_prod_order_wo`
                        LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact 
                        LEFT JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
                        LEFT JOIN  
                        ( 
                        SELECT recd.id_prod_order_det,SUM(recd.prod_order_rec_det_qty) AS prod_order_rec_det_qty 
                        FROM 
                        tb_prod_order_rec rec 
                        LEFT JOIN tb_prod_order_rec_det recd On recd.id_prod_order_rec=rec.id_prod_order_rec AND rec.id_report_status=6
                        GROUP BY recd.id_prod_order_det 
                        ) rec On rec.id_prod_order_det=pod.id_prod_order_det 
                        WHERE 1=1 " & query_where & "
                        GROUP BY a.id_prod_order"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCProd.DataSource = data
        If data.Rows.Count > 0 Then
            GVProd.FocusedRowHandle = 0
            GVProd.BestFitColumns()
            GVProd.ExpandAllGroups()
        End If
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVProd.RowCount > 0 Then
            Dim cek As String = CheckEditSelAll.EditValue.ToString
            For i As Integer = 0 To ((GVProd.RowCount - 1) - GetGroupRowCount(GVProd))
                If cek Then
                    GVProd.SetRowCellValue(i, "check", "yes")
                Else
                    GVProd.SetRowCellValue(i, "check", "no")
                End If
            Next
        End If
    End Sub

    Private Sub BClosingFGPO_Click(sender As Object, e As EventArgs) Handles BClosingFGPO.Click
        Cursor = Cursors.WaitCursor
        GVProd.ActiveFilterString = ""
        GVProd.ActiveFilterString = "[check]='yes' "
        If GVProd.RowCount = 0 Then
            stopCustom("Please select FG PO first.")
            GVProd.ActiveFilterString = ""
        Else
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to close this FG PO?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                For i As Integer = 0 To (GVProd.RowCount - 1) - GetGroupRowCount(GVProd)
                    Dim query As String = "CALL closing_fgpo('" & GVProd.GetRowCellValue(i, "id_prod_order").ToString & "')"
                    execute_non_query(query, True, "", "", "", "")
                Next
                infoCustom("FG PO Closed.")
            End If
        End If

        GVProd.ActiveFilterString = ""
        view_production_order()
        Cursor = Cursors.Default
    End Sub
End Class