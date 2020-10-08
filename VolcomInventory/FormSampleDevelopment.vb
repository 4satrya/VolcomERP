Public Class FormSampleDevelopment
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Sub check_menu()
        If GVDesign.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub FormSampleDevelopment_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormSampleDevelopment_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormSampleDevelopment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
        '
        viewDesign()
        viewVendor()
        viewSeasonPo()
        viewVendorKO()
    End Sub

    Sub viewSeasonPo()
        Dim query As String = "SELECT '-1' AS id_season, 'All Season' as season UNION "
        query += "(SELECT id_season,season FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeasonPO, query, "id_season", "season", "id_season")
        viewSearchLookupQuery(SLESeasonEcopPPS, query, "id_season", "season", "id_season")
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

    Sub viewVendorKO()
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All Vendor') AS comp_name, ('ALL Vendor') AS comp_name_label UNION ALL "
        query += "SELECT comp.id_comp,comp.comp_number, comp.comp_name, CONCAT_WS(' - ', comp.comp_number,comp.comp_name) AS comp_name_label FROM tb_m_comp comp "
        query += "WHERE comp.id_comp_cat='1'"
        viewSearchLookupQuery(SLEVendorCopyProto2, query, "id_comp", "comp_name_label", "id_comp")
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
        Dim query As String = "SELECT * FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "WHERE b.id_range >0 "
        query += "ORDER BY b.range DESC"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub viewData()
        GVDesign.RowHeight = 10

        Dim id_ss As String = SLESeason.EditValue.ToString
        Dim cond As String = ""
        If id_ss = "-1" Then
            cond = "-1"
        Else
            cond = "And f1.id_season=" + id_ss + " "
        End If
        Dim query As String = "CALL view_sample_dev('" + cond + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCDesign.DataSource = data
        GVDesign.BestFitColumns()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        FormSampleDevelopmentDet.id_design = GVDesign.GetFocusedRowCellValue("id_design").ToString
        FormSampleDevelopmentDet.ShowDialog()
    End Sub

    Private Sub CheckEditFreeze_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditFreeze.CheckedChanged
        If CheckEditFreeze.Checked = True Then
            GBDesign.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Else
            GBDesign.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
        End If
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        Cursor = Cursors.WaitCursor
        view_production_order()
        Cursor = Cursors.Default
    End Sub

    Sub view_production_order()
        Dim query_where As String = ""

        If Not SLEDesignStockStore.EditValue.ToString = "0" Then
            query_where += " AND b.id_design='" & SLEDesignStockStore.EditValue.ToString & "'"
        End If

        If Not SLESeasonPO.EditValue.ToString = "-1" Then
            query_where += " AND e.id_season='" & SLESeasonPO.EditValue.ToString & "'"
        End If

        If Not SLEVendor.EditValue.ToString = "0" Then
            query_where += " AND cc.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query = "SELECT 'no' AS is_check,'' AS NO,
a.id_term_production ,comp.id_comp,cc.id_comp_contact,comp.comp_name,comp.comp_number,a.id_prod_order,d.id_sample, a.prod_order_number, d.design_display_name, d.design_code,d.design_code_import, h.term_production, g.po_type,d.design_cop, 
a.prod_order_date,a.id_report_status,c.report_status,season_del_dsg.est_wh_date,season_del_dsg.delivery_date,
b.id_design,b.id_delivery, e.delivery, f.season, e.id_season,`range`.range,
RIGHT(d.design_display_name,3) AS color,LEFT(d.design_display_name,LENGTH(d.design_display_name)-3) AS class_dsg 
,py.payment,DATE_ADD(wo.prod_order_wo_del_date,INTERVAL prod_order_wo_lead_time DAY) AS est_del_date,IF(ISNULL(ko.lead_time_prod),NULL,DATE_ADD(wo.prod_order_wo_del_date,INTERVAL ko.lead_time_prod DAY)) AS est_del_date_ko,wo.prod_order_wo_lead_time AS lead_time,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL (wo.prod_order_wo_lead_time+wo.prod_order_wo_top) DAY) AS payment_due_date,prod_order_wo_top AS lead_time_pay 
,wo_price.prod_order_wo_vat AS vat,wo_price.wo_price AS po_amount_rp,wo_price.wo_price_no_kurs AS po_amount,wo_price.currency AS po_curr,wo_price.prod_order_wo_kurs AS po_kurs,IFNULL(SUM(pod.prod_order_qty),0)*(d.prod_order_cop_bom * d.prod_order_cop_bom_curr) AS bom_amount,(d.prod_order_cop_bom * d.prod_order_cop_bom_curr) AS bom_unit 
,IF(ISNULL(kp.sample_proto_2),a.sample_proto_2,kp.sample_proto_2) AS sample_proto_2 
,cps.id_prod_order_cps2,cps.number AS cps_number,cps.revision AS cps_revision,cps.eta_copy_proto_2
,NOW() as date_now
,IF(a.cps2_verify=2,'Not verified','Verified') AS sts_verify,a.cps2_verify_note,a.cps2_verify_date
FROM tb_prod_order a 
INNER JOIN tb_prod_order_det pod ON pod.id_prod_order=a.id_prod_order AND a.id_report_status!=5 
INNER JOIN tb_prod_demand_design b ON a.id_prod_demand_design = b.id_prod_demand_design 
INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status 
INNER JOIN tb_m_design d ON b.id_design = d.id_design 
INNER JOIN tb_season_delivery e ON b.id_delivery=e.id_delivery 
INNER JOIN tb_season_delivery season_del_dsg ON d.id_delivery=season_del_dsg.id_delivery 
INNER JOIN tb_season f ON f.id_season=e.id_season 
INNER JOIN tb_range `range` ON `range`.id_range=`f`.id_range 
INNER JOIN tb_lookup_po_type g ON g.id_po_type=a.id_po_type 
INNER JOIN tb_lookup_term_production h ON h.id_term_production=a.id_term_production 
LEFT JOIN tb_prod_order_wo wo ON wo.id_prod_order=a.id_prod_order AND wo.is_main_vendor='1' 
LEFT JOIN tb_lookup_payment py ON py.id_payment=wo.id_payment 
LEFT JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price 
LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact 
LEFT JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
LEFT JOIN (
	SELECT wo.id_prod_order, wo.id_ovh_price, wo.prod_order_wo_kurs, cur.currency,wo.prod_order_wo_vat,
	(SUM(CAST(wod.prod_order_wo_det_price * pod.prod_order_qty AS DECIMAL(13,2))) * wo.prod_order_wo_kurs * (100 + wo.prod_order_wo_vat)/100) AS `wo_price`
	,(SUM(CAST(wod.prod_order_wo_det_price * pod.prod_order_qty AS DECIMAL(13,2))) * (100 + wo.prod_order_wo_vat)/100) AS `wo_price_no_kurs`
	FROM tb_prod_order_wo wo
	INNER JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo = wo.id_prod_order_wo
	INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = wod.id_prod_order_det
	INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
	WHERE wo.is_main_vendor=1 
	GROUP BY wo.id_prod_order_wo
) wo_price ON wo_price.id_prod_order= a.id_prod_order 
LEFT JOIN (
    SELECT * FROM (
	    SELECT * FROM tb_prod_order_ko_det
	    ORDER BY id_prod_order_ko_det DESC
    )ko GROUP BY ko.id_prod_order
) ko ON ko.id_prod_order=a.id_prod_order 
LEFT JOIN (
    SELECT * FROM (
	    SELECT * FROM tb_prod_order_kp_det
	    ORDER BY id_prod_order_kp_det DESC
    )kp GROUP BY kp.id_prod_order
) kp ON kp.id_prod_order=a.id_prod_order 
LEFT JOIN
(
    SELECT cps.number,cps.`id_prod_order_cps2`,cps.`revision`,cpsd.`eta_copy_proto_2` ,cpsd.id_prod_order
    FROM 
    (
        SELECT MAX(cps2d.id_prod_order_cps2_det) AS id_prod_order_cps2_det
        FROM `tb_prod_order_cps2_det` cps2d
        INNER JOIN `tb_prod_order_cps2` cps2 ON cps2.`id_prod_order_cps2`=cps2d.`id_prod_order_cps2` AND cps2.`is_locked`=1
        GROUP BY cps2d.id_prod_order
    )det
    INNER JOIN tb_prod_order_cps2_det cpsd ON cpsd.`id_prod_order_cps2_det`=det.id_prod_order_cps2_det
    INNER JOIN tb_prod_order_cps2 cps ON cpsd.id_prod_order_cps2=cps.id_prod_order_cps2
)cps ON cps.id_prod_order=a.id_prod_order
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

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Dim is_ok As Boolean = True

        GVProd.ActiveFilterString = "[is_check]='yes'"

        'confimation
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            GridColumnSeasonView.GroupIndex = -1
            GridColumnDelivery.GroupIndex = -1

            If GVProd.RowCount > 1 Then
                For i As Integer = 0 To GVProd.RowCount - 1
                    If Not GVProd.IsGroupRow(i) Then
                        'Console.WriteLine(GVProd.GetRowCellValue(0, "id_comp_contact").ToString & " - " & GVProd.GetRowCellValue(i, "id_comp_contact").ToString)
                        If Not GVProd.GetRowCellValue(0, "id_comp_contact").ToString = GVProd.GetRowCellValue(i, "id_comp_contact").ToString Then
                            is_ok = False
                            warningCustom("Different vendor contact selected")
                            Exit For
                        End If
                    End If
                Next
                '
            ElseIf GVProd.RowCount < 1 Then
                is_ok = False
                warningCustom("No FGPO selected")
            End If

            If is_ok Then
                '
                Dim id_user_purc_mngr As String = execute_query("SELECT usr.id_user 
FROM tb_m_departement dep
INNER JOIN tb_m_user usr ON usr.`id_user`=dep.id_user_head
WHERE dep.id_departement=4", 0, True, "", "", "", "")

                Dim id_user_sample_mngr As String = get_opt_prod_field("id_user_sample_mngr")
                Dim id_user_sample As String = get_opt_prod_field("id_user_sample")

                Dim query_copy_proto2 As String = "INSERT INTO tb_prod_order_cps2(`revision`,`id_comp_contact`,`date_created`,`created_by`,id_user_purc_mngr,id_user_sample,id_user_sample_mngr) VALUES('0','" & GVProd.GetFocusedRowCellValue("id_comp_contact").ToString & "',NOW(),'" & id_user & "','" & id_user_purc_mngr & "','" & id_user_sample & "','" & id_user_sample_mngr & "'); SELECT LAST_INSERT_ID(); "
                Dim id_copy_proto2 As String = execute_query(query_copy_proto2, 0, True, "", "", "", "")
                'insert po
                Dim query_kpd As String = "INSERT INTO tb_prod_order_cps2_det(`id_prod_order_cps2`,`revision`,`id_prod_order`,`eta_copy_proto_2`) VALUES"
                For i As Integer = 0 To GVProd.RowCount - 1
                    If Not i = 0 Then
                        query_kpd += ","
                    End If
                    '
                    query_kpd += "('" & id_copy_proto2 & "','0','" & GVProd.GetRowCellValue(i, "id_prod_order").ToString & "',DATE(NOW()))"
                Next

                execute_non_query(query_kpd, True, "", "", "", "")
                'generate cps2 number
                query_copy_proto2 = "SELECT COUNT(*)+1+IF(YEAR(CURRENT_DATE())<'2020',1,0) 
INTO @number_report 
FROM 
(SELECT * FROM `tb_prod_order_cps2` WHERE YEAR(date_created) = YEAR(CURRENT_DATE()) GROUP BY id_prod_order_cps2_reff) kp
WHERE kp.id_prod_order_cps2_reff < '" & id_copy_proto2 & "' AND kp.id_prod_order_cps2_reff != 0;
SELECT CONCAT(LPAD(@number_report,3,'0'),'/EXT/PRL-SR/',convert_romawi(DATE_FORMAT(NOW(),'%m')),'/',DATE_FORMAT(NOW(),'%y')) INTO @report_number;
UPDATE tb_prod_order_cps2 SET `id_prod_order_cps2_reff`='" & id_copy_proto2 & "',number=@report_number WHERE id_prod_order_cps2='" & id_copy_proto2 & "'"
                execute_non_query(query_copy_proto2, True, "", "", "", "")
                'show cps2 form
                FormProductionSampleOrder.id = id_copy_proto2
                FormProductionSampleOrder.ShowDialog()
            End If

            GridColumnSeasonView.GroupIndex = 0
            GridColumnDelivery.GroupIndex = 1
        End If

        GVProd.ActiveFilterString = ""
    End Sub

    Private Sub BSearchCopyProto2_Click(sender As Object, e As EventArgs) Handles BSearchCopyProto2.Click
        Dim query_where As String = ""
        '
        If Not SLEVendorCopyProto2.EditValue.ToString = "0" Then
            query_where += " AND c.id_comp='" & SLEVendorCopyProto2.EditValue.ToString & "'"
        End If
        '
        Dim query As String = "SELECT kp.*,IF(kp.is_void='1','Void','-') AS status,c.`comp_name` ,GROUP_CONCAT(dsg.design_code,' - ',dsg.design_display_name SEPARATOR '\n') AS design_list
FROM tb_prod_order_cps2 kp
INNER JOIN tb_prod_order_cps2_det kpd ON kpd.id_prod_order_cps2=kp.id_prod_order_cps2
INNER JOIN tb_prod_order po ON po.id_prod_order=kpd.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=kp.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
WHERE kp.id_prod_order_cps2 
IN (SELECT MAX(id_prod_order_cps2) AS id FROM `tb_prod_order_cps2`
GROUP BY id_prod_order_cps2_reff) AND is_purc_mat=2 " & query_where & " GROUP BY kp.id_prod_order_cps2
ORDER BY kp.id_prod_order_cps2 DESC"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCopyProto2.DataSource = data
        If GVCopyProto2.RowCount > 0 Then
            BEditCopyProto2.Visible = True
        Else
            BEditCopyProto2.Visible = False
        End If
        GVCopyProto2.BestFitColumns()
    End Sub

    Private Sub BEditCopyProto2_Click(sender As Object, e As EventArgs) Handles BEditCopyProto2.Click
        view_cps2()
    End Sub

    Sub view_cps2()
        FormProductionSampleOrder.id = GVCopyProto2.GetFocusedRowCellValue("id_prod_order_cps2").ToString
        FormProductionSampleOrder.ShowDialog()
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVProd.RowCount > 0 Then
            For i As Integer = 0 To ((GVProd.RowCount - 1) - GetGroupRowCount(GVProd))
                If CheckEditSelAll.Checked = False Then
                    GVProd.SetRowCellValue(i, "is_check", "no")
                Else
                    GVProd.SetRowCellValue(i, "is_check", "yes")
                End If
            Next
        End If
    End Sub

    Private Sub BVerifyCPS2_Click(sender As Object, e As EventArgs) Handles BVerifyCPS2.Click
        If GVProd.RowCount > 0 Then
            If Not GVProd.GetFocusedRowCellValue("id_prod_order_cps2").ToString = "" Then
                'verify popup
                FormSampleDevelopmentVerifyCPS2.id_po = GVProd.GetFocusedRowCellValue("id_prod_order").ToString
                FormSampleDevelopmentVerifyCPS2.TEFGPO.Text = GVProd.GetFocusedRowCellValue("prod_order_number").ToString
                FormSampleDevelopmentVerifyCPS2.DEVerifyDate.EditValue = GVProd.GetFocusedRowCellValue("date_now")
                '
                FormSampleDevelopmentVerifyCPS2.TEDesignCode.Text = GVProd.GetFocusedRowCellValue("design_code").ToString
                FormSampleDevelopmentVerifyCPS2.TEDesignName.Text = GVProd.GetFocusedRowCellValue("design_display_name").ToString
                FormSampleDevelopmentVerifyCPS2.TEVendor.Text = GVProd.GetFocusedRowCellValue("comp_name").ToString
                '
                FormSampleDevelopmentVerifyCPS2.ShowDialog()
            Else
                warningCustom("Please create and lock Copy Prototype Sample 2 Order first.")
            End If
        End If
    End Sub

    Private Sub EntryECOPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntryECOPToolStripMenuItem.Click
        FormDesignCopPps.id_design = GVDesign.GetFocusedRowCellValue("id_design").ToString
        FormDesignCopPps.id_pps = "-1"
        FormDesignCopPps.ShowDialog()
    End Sub

    Private Sub BViewEstECOPPPS_Click(sender As Object, e As EventArgs) Handles BViewEstECOPPPS.Click
        load_pps()
    End Sub

    Sub load_pps()
        Dim q As String = "SELECT id_design_ecop_pps,pps.`number`,d.id_design,d.`design_code`,d.`design_display_name` ,emp.`employee_name` AS created_by,pps.`created_date`
FROM `tb_design_ecop_pps` pps
INNER JOIN tb_m_design d ON d.`id_design`=pps.`id_design`
INNER JOIN tb_m_user usr ON usr.`id_user`=pps.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
ORDER BY pps.id_design_ecop_pps DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCEcopPPS.DataSource = dt
        GVEcopPPS.BestFitColumns()
    End Sub

    Private Sub GVEcopPPS_DoubleClick(sender As Object, e As EventArgs) Handles GVEcopPPS.DoubleClick
        If GVEcopPPS.RowCount > 0 Then
            FormDesignCopPps.id_design = GVEcopPPS.GetFocusedRowCellValue("id_design").ToString
            FormDesignCopPps.id_pps = GVEcopPPS.GetFocusedRowCellValue("id_design_ecop_pps").ToString
            FormDesignCopPps.ShowDialog()
        End If
    End Sub
End Class