Public Class FormProdClosing
    Public id_pop_up As String = "-1"

    Private Sub FormProdClosing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDesign()
        '
        viewSeason()
        '
        viewVendor()
        '
        view_close()
        If id_pop_up = "-1" Then 'only closing po
            BClosingFGPO.Visible = True
        ElseIf id_pop_up = "1" Then ' only closing rec
            BtnClosingRec.Visible = True
        ElseIf id_pop_up = "2" Then 'all 
            BClosingFGPO.Visible = True
            BtnClosingRec.Visible = True
            SMTolerance.Visible = False
            SMOpenLock.Visible = False
        Else 'only view
            GVProd.OptionsBehavior.ReadOnly = True
        End If
        view_claim_reject()
        view_claim_late()
    End Sub

    Sub view_close()
        Dim query As String = "SELECT poc.id_prod_order_close,poc.number,poc.created_date,emp.`employee_name`,sts.`report_status`
FROM tb_prod_order_close poc
INNER JOIN tb_m_user usr ON usr.`id_user`=poc.`created_by`
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=poc.`id_report_status`
ORDER BY poc.id_prod_order_close DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCClosing.DataSource = data
        GVClosing.BestFitColumns()
    End Sub

    Sub view_claim_reject()
        Dim query As String = "SELECT id_claim_reject,description FROM `tb_m_claim_reject` cr
WHERE cr.`is_active`='1'"
        viewSearchLookupRepositoryQuery(RISLERejectClaim, query, 0, "description", "id_claim_reject")
    End Sub

    Sub view_claim_late()
        Dim query As String = "SELECT id_claim_late,description FROM `tb_m_claim_late` cl
WHERE cl.`is_active`='1'"
        viewSearchLookupRepositoryQuery(RISLEClaimLate, query, 0, "description", "id_claim_late")
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

        Dim query = "SELECT 'no' AS `check`,'1' AS id_claim_reject,'1' AS id_claim_late,
                        IFNULL(SUM(rec.prod_order_rec_det_qty),0) AS qty_rec, 
                        IFNULL(SUM(pod.prod_order_qty),0) AS qty_order, 
                        CONCAT(comp.comp_number,' - ',comp.comp_name) AS `comp_name`,a.id_prod_order,d.id_sample, a.prod_order_number, d.design_display_name, d.design_code, h.term_production, g.po_type,d.design_cop, 
                        a.prod_order_date,a.id_report_status,c.report_status, 
                        b.id_design,b.id_delivery, e.delivery, f.season, e.id_season , wod.prod_order_wo_det_price
                        ,wo.id_prod_order_wo, a.claim_discount,(a.tolerance_minus * -1) AS `tolerance_minus`, a.tolerance_over,
                        IF(wo.is_proc_disc_claim=1,'Yes','No') AS is_proc_disc_claim, 
                        IF(a.is_closing_rec=1,'Closed','Opened') AS `rec_status`,
                        a.is_special_rec, a.special_rec_memo, a.special_rec_datetime
                        ,rec_date.first_rec_date,ko.lead_time_prod,wo.prod_order_wo_del_date
                        ,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL ko.lead_time_prod DAY) AS est_rec_date
                        ,IF(DATEDIFF(rec_date.first_rec_date,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL ko.lead_time_prod DAY))<0,0,DATEDIFF(rec_date.first_rec_date,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL ko.lead_time_prod DAY))) AS late
                        ,IF(IFNULL(pln.qty,0)>IFNULL(qcr.qty_normal,0),IFNULL(pln.qty,0),IFNULL(qcr.qty_normal,0)) AS qc_normal
                        ,IFNULL(qcr.qty_normal_minor,0) AS qc_normal_minor
                        ,IFNULL(qcr.qty_minor,0) AS qc_minor
                        ,IFNULL(qcr.qty_minor_major,0) AS qc_minor_major
                        ,IFNULL(qcr.qty_major,0) AS qc_major
                        ,IFNULL(qcr.qty_afkir,0) AS qc_afkir
                        ,(IF(IFNULL(pln.qty,0)>IFNULL(qcr.qty_normal,0),IFNULL(pln.qty,0),IFNULL(qcr.qty_normal,0)) + IFNULL(qcr.qty_normal_minor,0) + IFNULL(qcr.qty_minor,0) + IFNULL(qcr.qty_minor_major,0) + IFNULL(qcr.qty_major,0) + IFNULL(qcr.qty_afkir,0)) AS qc_total
                        ,IFNULL(SUM(rec.prod_order_rec_det_qty),0) - (IF(IFNULL(pln.qty,0)>IFNULL(qcr.qty_normal,0),IFNULL(pln.qty,0),IFNULL(qcr.qty_normal,0)) + IFNULL(qcr.qty_normal_minor,0) + IFNULL(qcr.qty_minor,0) + IFNULL(qcr.qty_minor_major,0) + IFNULL(qcr.qty_major,0) + IFNULL(qcr.qty_afkir,0)) AS qc_outstanding
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
                            LEFT JOIN tb_prod_order_rec_det recd ON recd.id_prod_order_rec=rec.id_prod_order_rec AND rec.id_report_status=6
                            GROUP BY recd.id_prod_order_det 
                        ) rec ON rec.id_prod_order_det=pod.id_prod_order_det 
                        LEFT JOIN
                        (
                            SELECT fc.`id_prod_order`,SUM(IF(fc.id_pl_category_sub=1,fcd.prod_fc_det_qty,0)) AS qty_normal,
                            SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0)) AS qty_normal_minor,
                            SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0)) AS qty_minor,
                            SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0)) AS qty_minor_major,
                            SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0)) AS qty_major,
                            SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0)) AS qty_afkir 
                            FROM tb_prod_fc_det fcd
                            INNER JOIN tb_prod_fc fc ON fc.`id_prod_fc`=fcd.`id_prod_fc` AND fc.`id_report_status`=6
                            WHERE NOT ISNULL(fc.`id_pl_category_sub`)
                            GROUP BY fc.`id_prod_order`
                        )qcr ON qcr.id_prod_order=a.`id_prod_order`
                        LEFT JOIN
                        (
                            SELECT id_prod_order,SUM(pl_prod_order_det_qty) AS qty
                            FROM `tb_pl_prod_order_det` pld
                            INNER JOIN tb_pl_prod_order pl ON pl.id_report_status=6 AND pl.id_pl_prod_order=pld.id_pl_prod_order
                            WHERE id_pl_category='1'
                            GROUP BY id_prod_order
                        )pln ON pln.id_prod_order=a.id_prod_order
                        LEFT JOIN (
                            SELECT wo.id_prod_order, wo.prod_order_wo_del_date,wo.id_ovh_price,  cur.currency, wo.prod_order_wo_vat, wod.prod_order_wo_det_price, wo.`prod_order_wo_kurs`
                        FROM tb_prod_order_wo wo
                        INNER JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo = wo.id_prod_order_wo
                        INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = wod.id_prod_order_det
                        INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
                        WHERE wo.is_main_vendor=1 
                        GROUP BY wo.id_prod_order_wo
                        ) wo_price ON wo_price.id_prod_order=a.id_prod_order
                        LEFT JOIN (
	                        SELECT id_prod_order,lead_time_prod,lead_time_payment FROM (
	                        SELECT * FROM tb_prod_order_ko_det
	                        ORDER BY id_prod_order_ko_det DESC
                        )ko GROUP BY ko.id_prod_order
                        ) ko ON ko.id_prod_order=a.id_prod_order
                        LEFT JOIN
                        (
                            SELECT rec.id_prod_order,MIN(rec.arrive_date) AS first_rec_date
                            FROM `tb_prod_order_rec` rec
                            WHERE rec.id_report_status='6'
                            GROUP BY rec.id_prod_order
                        ) rec_date ON rec_date.id_prod_order=a.id_prod_order 
                        LEFT JOIN
                        (
                            SELECT poc.id_prod_order_close,id_prod_order FROM tb_prod_order_close_det pocd
                            INNER JOIN tb_prod_order_close poc ON poc.id_report_status!=5 AND poc.id_prod_order_close=pocd.id_prod_order_close
                        ) poc ON poc.id_prod_order=a.id_prod_order
                        WHERE a.is_closing_rec='2' AND ISNULL(poc.id_prod_order_close) AND a.id_report_status=6 " & query_where & "
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

    Private Sub BtnClosingRec_Click(sender As Object, e As EventArgs) Handles BtnClosingRec.Click
        Cursor = Cursors.WaitCursor
        GVProd.ActiveFilterString = ""
        GVProd.ActiveFilterString = "[check]='yes' "
        If GVProd.RowCount = 0 Then
            stopCustom("Please select FG PO first.")
            GVProd.ActiveFilterString = ""
        Else
            'check first
            Dim err_text As String = ""
            Dim err_text_outstanding As String = ""
            Dim err_text_rec As String = ""
            Dim can_close As Boolean = True
            'outstanding qc
            For i As Integer = 0 To GVProd.RowCount - 1 - GetGroupRowCount(GVProd)
                If GVProd.GetRowCellValue(i, "qc_outstanding") >= 1 Then
                    can_close = False
                    err_text_outstanding += vbNewLine & "- " & GVProd.GetRowCellValue(i, "prod_order_number").ToString & " (" & GVProd.GetRowCellValue(i, "design_display_name").ToString & ")"
                End If
            Next
            If Not err_text_outstanding = "" Then
                err_text = "There is outstanding work in QC for this FGPO : " & err_text_outstanding
            End If
            'not yet receiving
            For i As Integer = 0 To GVProd.RowCount - 1 - GetGroupRowCount(GVProd)
                If GVProd.GetRowCellValue(i, "qty_rec") = 0 Then
                    can_close = False
                    err_text_rec += vbNewLine & "- " & GVProd.GetRowCellValue(i, "prod_order_number").ToString & " (" & GVProd.GetRowCellValue(i, "design_display_name").ToString & ")"
                End If
            Next
            If Not err_text_rec = "" Then
                If Not err_text = "" Then
                    err_text += vbNewLine
                End If
                err_text += "This FGPO not yet received : " & err_text_rec
            End If

            If can_close Then
                Dim query As String = "INSERT INTO tb_prod_order_close(created_date,created_by,id_report_status) VALUES(NOW(),'" & id_user & "','1'); SELECT LAST_INSERT_ID(); "
                Dim id_pps As String = execute_query(query, 0, True, "", "", "", "")
                query = "CALL gen_number('" & id_pps & "','212')"
                execute_non_query(query, True, "", "", "", "")
                'detail
                query = "INSERT INTO tb_prod_order_close_det(id_prod_order_close,id_prod_order,id_claim_reject,id_claim_late) VALUES"
                For i As Integer = 0 To GVProd.RowCount - 1 - GetGroupRowCount(GVProd)
                    If Not i = 0 Then
                        query += ","
                    End If
                    query += "('" & id_pps & "','" & GVProd.GetRowCellValue(i, "id_prod_order").ToString & "','" & GVProd.GetRowCellValue(i, "id_claim_reject").ToString & "','" & GVProd.GetRowCellValue(i, "id_claim_late").ToString & "')"
                Next
                execute_non_query(query, True, "", "", "", "")
                FormProdClosingPps.id_pps = id_pps
                FormProdClosingPps.ShowDialog()
                view_production_order()
            Else
                warningCustom(err_text)
            End If
            'Dim confirm As DialogResult
            'confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to close receiving for this FG PO?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            'If confirm = Windows.Forms.DialogResult.Yes Then
            '    Dim prod_order As String = ""
            '    For i As Integer = 0 To (GVProd.RowCount - 1) - GetGroupRowCount(GVProd)
            '        If i > 0 Then
            '            prod_order += "OR "
            '        End If
            '        prod_order += "id_prod_order=" + GVProd.GetRowCellValue(i, "id_prod_order").ToString + " "
            '    Next
            '    Dim query As String = "UPDATE tb_prod_order SET is_closing_rec=1 WHERE (" + prod_order + ") "
            '    execute_non_query(query, True, "", "", "", "")
            'End If
            GVProd.ActiveFilterString = ""
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub BtnTol_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        GVProd.ActiveFilterString = ""
        GVProd.ActiveFilterString = "[check]='yes' "
        If GVProd.RowCount = 0 Then
            stopCustom("Please select FG PO first.")
            GVProd.ActiveFilterString = ""
        Else
            Dim prod_order As String = ""
            For i As Integer = 0 To (GVProd.RowCount - 1) - GetGroupRowCount(GVProd)
                If i > 0 Then
                    prod_order += "OR "
                End If
                prod_order += "id_prod_order=" + GVProd.GetRowCellValue(i, "id_prod_order").ToString + " "
            Next
            FormProdClosingTolerance.cond = "(" + prod_order + ")"
            FormProdClosingTolerance.ShowDialog()
        End If

        GVProd.ActiveFilterString = ""
        view_production_order()
        Cursor = Cursors.Default
    End Sub

    Private Sub SMOpenLock_Click(sender As Object, e As EventArgs) Handles SMOpenLock.Click
        If GVProd.RowCount > 0 And GVProd.FocusedRowHandle >= 0 Then
            If GVProd.GetFocusedRowCellValue("id_report_status").ToString <> "5" Then
                FormProductionSpecialRecSingle.id_pop_up = "1"
                FormProductionSpecialRecSingle.TEMemoNumber.Text = GVProd.GetFocusedRowCellValue("special_rec_memo").ToString
                FormProductionSpecialRecSingle.ShowDialog()
            End If
        End If
    End Sub

    Private Sub FormProdClosing_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormProdClosing_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub SMTolerance_Click(sender As Object, e As EventArgs) Handles SMTolerance.Click
        Cursor = Cursors.WaitCursor
        If GVProd.RowCount > 0 And GVProd.FocusedRowHandle >= 0 Then
            Dim prod_order As String = "id_prod_order=" + GVProd.GetFocusedRowCellValue("id_prod_order").ToString + " "
            FormProdClosingTolerance.TxtTolOver.EditValue = GVProd.GetFocusedRowCellValue("tolerance_over")
            FormProdClosingTolerance.TxtTolMinus.EditValue = -1 * GVProd.GetFocusedRowCellValue("tolerance_minus")
            FormProdClosingTolerance.TxtTolDiscount.EditValue = GVProd.GetFocusedRowCellValue("claim_discount")
            FormProdClosingTolerance.cond = "(" + prod_order + ")"
            FormProdClosingTolerance.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVClosing_DoubleClick(sender As Object, e As EventArgs) Handles GVClosing.DoubleClick
        If GVClosing.RowCount > 0 Then
            FormProdClosingPps.id_pps = GVClosing.GetFocusedRowCellValue("id_prod_order_close").ToString
            FormProdClosingPps.ShowDialog()
        Else
            infoCustom("No closing proposed")
        End If
    End Sub

    Private Sub BFilter_Click(sender As Object, e As EventArgs) Handles BFilter.Click
        Cursor = Cursors.WaitCursor
        GVProd.ActiveFilterString = ""
        GVProd.ActiveFilterString = "[qty_rec]>0 AND [qc_outstanding] <= 0"
        Cursor = Cursors.Default
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        view_close()
    End Sub
End Class