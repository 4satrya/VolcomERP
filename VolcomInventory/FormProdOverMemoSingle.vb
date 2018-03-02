Public Class FormProdOverMemoSingle
    Public data_par As DataTable

    Private Sub FormProdOverMemoSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDesign()
        viewSeason()
        viewVendor()
    End Sub

    Sub noEdit()
        Dim memo_number As String = ""
        Try
            memo_number = GVProd.GetFocusedRowCellValue("memo_number").ToString
        Catch ex As Exception

        End Try
        If memo_number = "" Then
            GVProd.Columns("check").OptionsColumn.AllowEdit = True
        Else
            GVProd.Columns("check").OptionsColumn.AllowEdit = False
        End If
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


    Sub view_production_order()
        Cursor = Cursors.WaitCursor
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
                        CONCAT(comp.comp_number,' - ',comp.comp_name) AS `comp_name`,a.id_prod_order,d.id_sample, a.prod_order_number, d.design_display_name, d.design_code, h.term_production, g.po_type,d.design_cop, 
                        a.prod_order_date,a.id_report_status,c.report_status, 
                        b.id_design,b.id_delivery, e.delivery, f.season, e.id_season , wod.prod_order_wo_det_price
                        ,wo.id_prod_order_wo,
                        IF(a.is_closing_rec=1,'Closed','Opened') AS `rec_status`,
                        a.is_special_rec, a.special_rec_memo, a.special_rec_datetime,
                        mm.memo_number, mm.created_date, mm.expired_date, '' AS `remark`, 'no' AS `check`
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
                        LEFT JOIN(
                            SELECT a.id_prod_order, a.memo_number, a.created_date, a.expired_date 
                            FROM (
	                            SELECT md.id_prod_order, m.memo_number, m.created_date, ADDTIME(m.created_date,CONCAT(m.lead_time,':00:00')) AS `expired_date`
	                            FROM tb_prod_over_memo_det md
	                            INNER JOIN tb_prod_over_memo m ON m.id_prod_over_memo = md.id_prod_over_memo
	                            WHERE m.id_report_status!=5 AND ADDTIME(m.created_date,CONCAT(m.lead_time,':00:00'))> NOW()
	                            ORDER BY m.id_prod_over_memo ASC
                            ) a 
                            GROUP BY a.id_prod_order
                        ) mm ON mm.id_prod_order = a.id_prod_order
                        WHERE 1=1 " & query_where & "
                        GROUP BY a.id_prod_order"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data_par.Rows.Count = 0 Then
            GCProd.DataSource = data
        Else
            Dim t1 = data.AsEnumerable()
            Dim t2 = data_par.AsEnumerable()
            Dim except As DataTable = (From _t1 In t1
                                       Group Join _t2 In t2
                                       On _t1("id_prod_order") Equals _t2("id_prod_order") Into Group
                                       From _t3 In Group.DefaultIfEmpty()
                                       Where _t3 Is Nothing
                                       Select _t1).CopyToDataTable
            GCProd.DataSource = except
        End If

        If data.Rows.Count > 0 Then
            GVProd.BestFitColumns()
            GVProd.ExpandAllGroups()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        view_production_order()
        noEdit()
    End Sub

    Private Sub GVProd_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProd.FocusedRowChanged
        Try
            noEdit()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVProd.RowCount > 0 Then
            Dim cek As String = CheckEditSelAll.EditValue.ToString
            For i As Integer = 0 To ((GVProd.RowCount - 1) - GetGroupRowCount(GVProd))
                Dim memo_number As String = GVProd.GetRowCellValue(i, "memo_number").ToString
                If cek And memo_number <> "" Then
                    GVProd.SetRowCellValue(i, "Select_sct", "Yes")
                Else
                    GVProd.SetRowCellValue(i, "Select_sct", "No")
                End If
            Next
        End If
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        Cursor = Cursors.WaitCursor
        GVProd.ActiveFilterString = ""
        GVProd.ActiveFilterString = "[check]='yes' "
        If GVProd.RowCount = 0 Then
            stopCustom("Please select FG PO first.")
            GVProd.ActiveFilterString = ""
        Else
            For i As Integer = 0 To ((GVProd.RowCount - 1) - GetGroupRowCount(GVProd))
                Dim newRow As DataRow = (TryCast(FormProdOverMemoDet.GCData.DataSource, DataTable)).NewRow()
                newRow("id_prod_over_memo") = "0"
                newRow("id_prod_order") = GVProd.GetRowCellValue(i, "id_prod_order").ToString
                newRow("prod_order_number") = GVProd.GetRowCellValue(i, "prod_order_number").ToString
                newRow("code") = GVProd.GetRowCellValue(i, "design_code").ToString
                newRow("name") = GVProd.GetRowCellValue(i, "design_display_name").ToString
                newRow("remark") = GVProd.GetRowCellValue(i, "remark").ToString
                TryCast(FormProdOverMemoDet.GCData.DataSource, DataTable).Rows.Add(newRow)
                FormProdOverMemoDet.GCData.RefreshDataSource()
                FormProdOverMemoDet.GVData.RefreshData()
            Next
            Close()
        End If

        GVProd.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub FormProdOverMemoSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class