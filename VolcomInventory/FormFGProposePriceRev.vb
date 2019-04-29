Public Class FormFGProposePriceRev
    Public id As String = "-1"
    Public id_pp As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim rmt As String = ""
    Dim season As String = ""
    Public id_season As String = "-1"
    Public id_source As String = "-1"
    Public id_division As String = "-1"
    Dim markup_target As Decimal = 0.00
    Public id_pp_type As String = "-1"

    Private Sub FormFGProposePriceRev_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormFGProposePriceRev_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Dim r As New ClassFGProposePrice
        Dim data As DataTable = r.dataMainRev("AND ppr.id_fg_propose_price_rev='" + id + "' ", "1")
        id_pp = data.Rows(0)("id_fg_propose_price").ToString
        TxtNumber.Text = data.Rows(0)("fg_propose_price_number").ToString
        TxtRevision.Text = data.Rows(0)("rev_count").ToString
        MENote.Text = data.Rows(0)("note").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        is_confirm = data.Rows(0)("is_confirm").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString
        season = data.Rows(0)("season").ToString
        id_season = data.Rows(0)("id_season").ToString
        id_source = data.Rows(0)("id_source").ToString
        id_division = data.Rows(0)("id_division").ToString
        markup_target = data.Rows(0)("markup_target")
        rmt = "188"
        id_pp_type = data.Rows(0)("id_pp_type").ToString

        repoPriceMaster()
        repoPricePrint()
        viewDetail()
        allow_status()
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 'No' AS `is_select`, '' AS `no`, ppd.id_fg_propose_price_rev_det, ppd.id_fg_propose_price_rev,
        ppd.id_fg_propose_price_detail, 
        ppd.id_design, d.design_code, d.design_code_import, del.id_delivery, del.delivery, d.id_season_orign, ss_org.season_orign_display AS `season_orign`, ctr.id_country, ctr.country_display_name AS `country`,
        src.id_src, src.src AS `source`,cls.id_class, cls.class, d.design_display_name, col.id_color, col.color, sc.size_chart, 
        DATE_FORMAT(d.design_eos,'%b %y') AS `eos_date`, rc.ret_code, DATE_FORMAT(rc.ret_date, '%b %y') AS `ret_date`, CONCAT(PERIOD_DIFF(DATE_FORMAT(rc.ret_date, '%Y%m'),DATE_FORMAT(del.delivery_date, '%Y%m')), ' MTH') AS `age`,
        ppd.id_prod_demand_design, po.id_prod_order,po.prod_order_number, po.vendor, po.qty AS `qty_po`, ppd.`qty`,
        ppd.id_cop_status, cs.cop_status, ppd.msrp, ppd.additional_cost, 
        IF(ppd.cop_rate_cat=1,'BOM', 'Payment') AS `rate_type`,ppd.cop_rate_cat, ppd.cop_kurs, ppd.cop_value, (ppd.cop_value - ppd.additional_cost) AS `cop_value_min_add`,
        ppd.cop_mng_kurs, ppd.cop_mng_value, (ppd.cop_mng_value - ppd.additional_cost) AS `cop_mng_value_min_add`,
        ppd.price, ppd.sale_price, ppd.additional_price, ppd.cop_date,
        ppd.id_design_price_type_master, ptm.design_price_type AS `design_price_type_master`, ppd.id_design_price_type_print, ptp.design_price_type AS `design_price_type_print`,
        ppd.remark, ppd.id_pd_status_rev, sa.pd_status_rev AS `status`
        FROM tb_fg_propose_price_rev_det ppd
        INNER JOIN tb_m_design d ON d.id_design = ppd.id_design
        INNER JOIN tb_season_delivery del ON del.id_delivery = d.id_delivery
        INNER JOIN tb_season_orign ss_org ON ss_org.id_season_orign = d.id_season_orign
        INNER JOIN tb_m_country ctr ON ctr.id_country = ss_org.id_country
        LEFT JOIN (
         SELECT d.id_design, cls.id_code_detail AS `id_src`, cls.display_name AS `src` 
         FROM tb_m_design d
         INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
         INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=5
         GROUP BY d.id_design
        ) src ON src.id_design = d.id_design
        LEFT JOIN (
         SELECT d.id_design, cls.id_code_detail AS `id_class`, cls.display_name AS `class` 
         FROM tb_m_design d
         INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
         INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=30
         GROUP BY d.id_design
        ) cls ON cls.id_design = d.id_design
        LEFT JOIN (
         SELECT d.id_design, cls.id_code_detail AS `id_color`, cls.display_name AS `color` 
         FROM tb_m_design d
         INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
         INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=14
         GROUP BY d.id_design
        ) col ON col.id_design = d.id_design
        LEFT JOIN (
          SELECT pdp.id_prod_demand_design, GROUP_CONCAT(DISTINCT cd.code_detail_name ORDER BY cd.id_code_detail ASC SEPARATOR ',') AS `size_chart`
          FROM tb_prod_demand_product pdp
          INNER JOIN tb_m_product prod ON prod.id_product = pdp.id_product
          INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
          INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
          GROUP BY pdp.id_prod_demand_design
        ) sc ON sc.id_prod_demand_design = ppd.id_prod_demand_design
        INNER JOIN (
          SELECT po.id_prod_demand_design,po.id_prod_order,po.prod_order_number, c.comp_name AS `vendor`, SUM(pod.prod_order_qty) AS `qty`
          FROM tb_prod_order po
          INNER JOIN tb_prod_order_det pod ON pod.id_prod_order = po.id_prod_order
          INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order = po.id_prod_order AND wo.is_main_vendor=1
          INNER JOIN tb_m_ovh_price ovhp ON ovhp.id_ovh_price = wo.id_ovh_price
          INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ovhp.id_comp_contact
          INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
          WHERE po.id_report_status!=5
          GROUP BY po.id_prod_demand_design
        ) po ON po.id_prod_demand_design = ppd.id_prod_demand_design
        INNER JOIN tb_lookup_ret_code rc ON rc.id_ret_code = d.id_ret_code
        INNER JOIN tb_lookup_cop_status cs ON cs.id_cop_status = ppd.id_cop_status
        INNER JOIN tb_lookup_pd_status_rev sa ON sa.id_pd_status_rev = ppd.id_pd_status_rev
        INNER JOIN tb_lookup_design_price_type ptm ON ptm.id_design_price_type = ppd.id_design_price_type_master
        INNER JOIN tb_lookup_design_price_type ptp ON ptp.id_design_price_type = ppd.id_design_price_type_print
        WHERE ppd.id_fg_propose_price_rev=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRevision.DataSource = data

        'opt column
        If id_pp_type = "1" Then 'reguler
            GridColumnSalePrice.OptionsColumn.ReadOnly = True

            GridColumnSalePrice.Visible = False
            GridColumnSalePriceMinAdditional.Visible = False
            GridColumnSetAsMaster.Visible = False
            GridColumnSetAsPrint.Visible = False
            GridColumnMarkUpSale.Visible = False
            GridColumnMarkUpManagRateSale.Visible = False
        Else 'non reguler
            GridColumnSalePrice.OptionsColumn.ReadOnly = False

            GridColumnSalePrice.VisibleIndex = GridColumnPriceRev.VisibleIndex + 1
            GridColumnSalePriceMinAdditional.VisibleIndex = GridColumnPriceMinAdditionalRev.VisibleIndex + 1
            If is_confirm = "1" Then
                GridColumnSetAsMasterDisplay.VisibleIndex = GridColumnSalePriceMinAdditional.VisibleIndex + 1
                GridColumnSetAsPrintDisplay.VisibleIndex = GridColumnSetAsMasterDisplay.VisibleIndex + 1
            Else
                GridColumnSetAsMaster.VisibleIndex = GridColumnSalePriceMinAdditional.VisibleIndex + 1
                GridColumnSetAsPrint.VisibleIndex = GridColumnSetAsMaster.VisibleIndex + 1
            End If
            GridColumnMarkUpSale.VisibleIndex = GridColumnMarkUpManagRateRev.VisibleIndex + 1
            GridColumnMarkUpManagRateSale.VisibleIndex = GridColumnMarkUpSale.VisibleIndex + 1
        End If


        GVRevision.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub repoPriceMaster()
        Dim query As String = "SELECT  pt.id_design_price_type AS `id_design_price_type_master`, pt.design_price_type
        FROM tb_lookup_design_price_type pt
        WHERE pt.id_design_price_type>0 "
        If id_pp_type = "1" Then
            query += "AND pt.id_design_price_type=1 "
        Else
            query += "AND (pt.id_design_price_type=1 OR pt.id_design_price_type=4) "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepoLEPriceMaster.DataSource = Nothing
        RepoLEPriceMaster.DataSource = data
        RepoLEPriceMaster.DisplayMember = "design_price_type"
        RepoLEPriceMaster.ValueMember = "id_design_price_type_master"
    End Sub

    Sub repoPricePrint()
        Dim query As String = "SELECT  pt.id_design_price_type AS `id_design_price_type_print`, pt.design_price_type
        FROM tb_lookup_design_price_type pt
        WHERE pt.id_design_price_type>0 "
        If id_pp_type = "1" Then
            query += "AND pt.id_design_price_type=1 "
        Else
            query += "AND (pt.id_design_price_type=1 OR pt.id_design_price_type=4) "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepoLEPricePrint.DataSource = Nothing
        RepoLEPricePrint.DataSource = data
        RepoLEPricePrint.DisplayMember = "design_price_type"
        RepoLEPricePrint.ValueMember = "id_design_price_type_print"
    End Sub

    Sub viewPPAll()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_fg_propose_price_rev_det`,'' AS `no`,ppd.id_fg_propose_price_detail, 
        ppd.id_design, d.design_code, d.design_code_import, del.id_delivery, del.delivery, d.id_season_orign, ss_org.season_orign_display AS `season_orign`, ctr.id_country, ctr.country_display_name AS `country`,
        src.id_src, src.src AS `source`,cls.id_class, cls.class, d.design_display_name, col.id_color, col.color, sc.size_chart, 
        DATE_FORMAT(d.design_eos,'%b %y') AS `eos_date`, rc.ret_code, DATE_FORMAT(rc.ret_date, '%b %y') AS `ret_date`, CONCAT(PERIOD_DIFF(DATE_FORMAT(rc.ret_date, '%Y%m'),DATE_FORMAT(del.delivery_date, '%Y%m')), ' MTH') AS `age`,
        ppd.id_prod_demand_design, po.id_prod_order,po.prod_order_number, po.vendor, po.qty AS `qty_po`, ppd.`qty`,
        ppd.id_cop_status, cs.cop_status, ppd.msrp, ppd.additional_cost, 
        IF(ppd.cop_rate_cat=1,'BOM', 'Payment') AS `rate_type`,ppd.cop_rate_cat, ppd.cop_kurs, ppd.cop_value, (ppd.cop_value - ppd.additional_cost) AS `cop_value_min_add`,
        ppd.cop_mng_kurs, ppd.cop_mng_value, (ppd.cop_mng_value - ppd.additional_cost) AS `cop_mng_value_min_add`,
        ppd.price, ppd.sale_price, ppd.additional_price, ppd.cop_date,
        ppd.id_design_price_type_master, ptm.design_price_type AS `design_price_type_master`, ppd.id_design_price_type_print, ptp.design_price_type AS `design_price_type_print`,
        ppd.remark
        FROM tb_fg_propose_price_detail ppd
        INNER JOIN tb_m_design d ON d.id_design = ppd.id_design
        INNER JOIN tb_season_delivery del ON del.id_delivery = d.id_delivery
        INNER JOIN tb_season_orign ss_org ON ss_org.id_season_orign = d.id_season_orign
        INNER JOIN tb_m_country ctr ON ctr.id_country = ss_org.id_country
        LEFT JOIN (
          SELECT d.id_design, cls.id_code_detail AS `id_src`, cls.display_name AS `src` 
          FROM tb_m_design d
          INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
          INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=5
          GROUP BY d.id_design
        ) src ON src.id_design = d.id_design
        LEFT JOIN (
          SELECT d.id_design, cls.id_code_detail AS `id_class`, cls.display_name AS `class` 
          FROM tb_m_design d
          INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
          INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=30
          GROUP BY d.id_design
        ) cls ON cls.id_design = d.id_design
        LEFT JOIN (
          SELECT d.id_design, cls.id_code_detail AS `id_color`, cls.display_name AS `color` 
          FROM tb_m_design d
          INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
          INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=14
          GROUP BY d.id_design
        ) col ON col.id_design = d.id_design
        LEFT JOIN (
	        SELECT pdp.id_prod_demand_design, GROUP_CONCAT(DISTINCT cd.code_detail_name ORDER BY cd.id_code_detail ASC SEPARATOR ',') AS `size_chart`
	        FROM tb_prod_demand_product pdp
	        INNER JOIN tb_m_product prod ON prod.id_product = pdp.id_product
	        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
	        GROUP BY pdp.id_prod_demand_design
        ) sc ON sc.id_prod_demand_design = ppd.id_prod_demand_design
        INNER JOIN (
	        SELECT po.id_prod_demand_design,po.id_prod_order,po.prod_order_number, c.comp_name AS `vendor`, SUM(pod.prod_order_qty) AS `qty`
	        FROM tb_prod_order po
	        INNER JOIN tb_prod_order_det pod ON pod.id_prod_order = po.id_prod_order
	        INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order = po.id_prod_order AND wo.is_main_vendor=1
	        INNER JOIN tb_m_ovh_price ovhp ON ovhp.id_ovh_price = wo.id_ovh_price
	        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ovhp.id_comp_contact
	        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
	        WHERE po.id_report_status!=5
	        GROUP BY po.id_prod_demand_design
        ) po ON po.id_prod_demand_design = ppd.id_prod_demand_design
        INNER JOIN tb_lookup_ret_code rc ON rc.id_ret_code = d.id_ret_code
        INNER JOIN tb_lookup_cop_status cs ON cs.id_cop_status = ppd.id_cop_status
        INNER JOIN tb_lookup_status sa ON sa.id_status = ppd.is_active 
        INNER JOIN tb_lookup_design_price_type ptm ON ptm.id_design_price_type = ppd.id_design_price_type_master
        INNER JOIN tb_lookup_design_price_type ptp ON ptp.id_design_price_type = ppd.id_design_price_type_print
        WHERE ppd.id_fg_propose_price='" + id_pp + "' AND ppd.id_design NOT IN (
            SELECT id_design FROM tb_fg_propose_price_rev_det WHERE id_fg_propose_price_rev='" + id + "'
        ) 
        UNION ALL
        SELECT  ppd.id_fg_propose_price_rev_det,'' AS `no`, ppd.id_fg_propose_price_detail, 
        ppd.id_design, d.design_code, d.design_code_import, del.id_delivery, del.delivery, d.id_season_orign, ss_org.season_orign_display AS `season_orign`, ctr.id_country, ctr.country_display_name AS `country`,
        src.id_src, src.src AS `source`,cls.id_class, cls.class, d.design_display_name, col.id_color, col.color, sc.size_chart, 
        DATE_FORMAT(d.design_eos,'%b %y') AS `eos_date`, rc.ret_code, DATE_FORMAT(rc.ret_date, '%b %y') AS `ret_date`, CONCAT(PERIOD_DIFF(DATE_FORMAT(rc.ret_date, '%Y%m'),DATE_FORMAT(del.delivery_date, '%Y%m')), ' MTH') AS `age`,
        ppd.id_prod_demand_design, po.id_prod_order,po.prod_order_number, po.vendor, po.qty AS `qty_po`, ppd.`qty`,
        ppd.id_cop_status, cs.cop_status, ppd.msrp, ppd.additional_cost, 
        IF(ppd.cop_rate_cat=1,'BOM', 'Payment') AS `rate_type`,ppd.cop_rate_cat, ppd.cop_kurs, ppd.cop_value, (ppd.cop_value - ppd.additional_cost) AS `cop_value_min_add`,
        ppd.cop_mng_kurs, ppd.cop_mng_value, (ppd.cop_mng_value - ppd.additional_cost) AS `cop_mng_value_min_add`,
        ppd.price, ppd.sale_price, ppd.additional_price, ppd.cop_date,
        ppd.id_design_price_type_master, ptm.design_price_type AS `design_price_type_master`, ppd.id_design_price_type_print, ptp.design_price_type AS `design_price_type_print`,
        ppd.remark
        FROM tb_fg_propose_price_rev_det ppd
        INNER JOIN tb_m_design d ON d.id_design = ppd.id_design
        INNER JOIN tb_season_delivery del ON del.id_delivery = d.id_delivery
        INNER JOIN tb_season_orign ss_org ON ss_org.id_season_orign = d.id_season_orign
        INNER JOIN tb_m_country ctr ON ctr.id_country = ss_org.id_country
        LEFT JOIN (
         SELECT d.id_design, cls.id_code_detail AS `id_src`, cls.display_name AS `src` 
         FROM tb_m_design d
         INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
         INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=5
         GROUP BY d.id_design
        ) src ON src.id_design = d.id_design
        LEFT JOIN (
         SELECT d.id_design, cls.id_code_detail AS `id_class`, cls.display_name AS `class` 
         FROM tb_m_design d
         INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
         INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=30
         GROUP BY d.id_design
        ) cls ON cls.id_design = d.id_design
        LEFT JOIN (
         SELECT d.id_design, cls.id_code_detail AS `id_color`, cls.display_name AS `color` 
         FROM tb_m_design d
         INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
         INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=14
         GROUP BY d.id_design
        ) col ON col.id_design = d.id_design
        LEFT JOIN (
          SELECT pdp.id_prod_demand_design, GROUP_CONCAT(DISTINCT cd.code_detail_name ORDER BY cd.id_code_detail ASC SEPARATOR ',') AS `size_chart`
          FROM tb_prod_demand_product pdp
          INNER JOIN tb_m_product prod ON prod.id_product = pdp.id_product
          INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
          INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
          GROUP BY pdp.id_prod_demand_design
        ) sc ON sc.id_prod_demand_design = ppd.id_prod_demand_design
        INNER JOIN (
          SELECT po.id_prod_demand_design,po.id_prod_order,po.prod_order_number, c.comp_name AS `vendor`, SUM(pod.prod_order_qty) AS `qty`
          FROM tb_prod_order po
          INNER JOIN tb_prod_order_det pod ON pod.id_prod_order = po.id_prod_order
          INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order = po.id_prod_order AND wo.is_main_vendor=1
          INNER JOIN tb_m_ovh_price ovhp ON ovhp.id_ovh_price = wo.id_ovh_price
          INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ovhp.id_comp_contact
          INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
          WHERE po.id_report_status!=5
          GROUP BY po.id_prod_demand_design
        ) po ON po.id_prod_demand_design = ppd.id_prod_demand_design
        INNER JOIN tb_lookup_ret_code rc ON rc.id_ret_code = d.id_ret_code
        INNER JOIN tb_lookup_cop_status cs ON cs.id_cop_status = ppd.id_cop_status
        INNER JOIN tb_lookup_pd_status_rev sa ON sa.id_pd_status_rev = ppd.id_pd_status_rev
        INNER JOIN tb_lookup_design_price_type ptm ON ptm.id_design_price_type = ppd.id_design_price_type_master
        INNER JOIN tb_lookup_design_price_type ptp ON ptp.id_design_price_type = ppd.id_design_price_type_print
        WHERE ppd.id_fg_propose_price_rev=" + id + " 
        ORDER BY design_display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data

        'opt column
        If id_pp_type = "1" Then 'reguler
            GridColumnSalePriceAll.Visible = False
            GridColumnSalePriceMinAdditionalAll.Visible = False
            GridColumnSetAsMasterDisplayAll.Visible = False
            GridColumnSetAsPrintDisplayAll.Visible = False
            GridColumnMarkUpSaleAll.Visible = False
            GridColumnMarkUpManagRateSaleAll.Visible = False
        Else 'non reguler
            GridColumnSalePriceAll.VisibleIndex = GridColumnPrice.VisibleIndex + 1
            GridColumnSalePriceMinAdditionalAll.VisibleIndex = GridColumnPriceMinAdditional.VisibleIndex + 1
            GridColumnSetAsMasterDisplayAll.VisibleIndex = GridColumnSalePriceMinAdditionalAll.VisibleIndex + 1
            GridColumnSetAsPrintDisplayAll.VisibleIndex = GridColumnSetAsMasterDisplayAll.VisibleIndex + 1
            GridColumnMarkUpSaleAll.VisibleIndex = GridColumnMarkUpManagRate.VisibleIndex + 1
            GridColumnMarkUpManagRateSaleAll.VisibleIndex = GridColumnMarkUpSaleAll.VisibleIndex + 1
        End If

        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = True
            BtnAdd.Visible = True
            BtnDel.Visible = True
            BtnUpdateCOP.Visible = True
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            GVRevision.OptionsBehavior.Editable = True
            GridColumnIsSelectRev.VisibleIndex = 0
            PanelControlSelAll.Visible = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            BtnAdd.Visible = False
            BtnDel.Visible = False
            BtnUpdateCOP.Visible = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            GVRevision.OptionsBehavior.Editable = False
            GridColumnIsSelectRev.Visible = False
            PanelControlSelAll.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnConfirm.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            BtnAdd.Visible = False
            BtnDel.Visible = False
            BtnUpdateCOP.Visible = False
            BtnSaveChanges.Visible = False
            GVRevision.OptionsBehavior.Editable = False
            GridColumnIsSelectRev.Visible = False
            PanelControlSelAll.Visible = False
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormFGProposePriceRevAdd.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_fg_propose_price_rev SET id_report_status=5 WHERE id_fg_propose_price_rev='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormFGProposePrice.viewRevision()
            FormFGProposePrice.GVRev.FocusedRowHandle = find_row(FormFGProposePrice.GVRev, "id_fg_propose_price_rev", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVRevision)
        'cek file
        Dim cond_exist_file As Boolean = True
        'Dim query_file As String = "SELECT * FROM tb_doc d WHERE d.report_mark_type=" + rmt + " AND d.id_report=" + id + ""
        'Dim data_file As DataTable = execute_query(query_file, -1, True, "", "", "", "")
        'If data_file.Rows.Count <= 0 Then
        '    cond_exist_file = False
        'End If

        If Not cond_exist_file Then
            stopCustom("Please attach document first")
        ElseIf GVRevision.RowCount <= 0 Then
            stopCustom("No revisions were made. If you want to cancel this revision, please click 'Cancel Propose'")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm PP revision ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update 
                saveHead()
                saveChangesDetail()

                'update confirm
                Dim query As String = "UPDATE tb_fg_propose_price_rev SET is_confirm=1 WHERE id_fg_propose_price_rev='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'submit approval 
                submit_who_prepared(rmt, id, id_user)
                BtnConfirm.Visible = False
                actionLoad()
                infoCustom("PP Revision submitted. Waiting for approval.")
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        If Not check_allow_print(id_report_status, rmt, id) Then
            warningCustom("Can't print, please complete all approval on system first")
        Else
            Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            If XTCRevision.SelectedTabPageIndex = 0 Then
                gv = GVRevision
                ReportFGProposePriceRev.dt = GCRevision.DataSource
                ReportFGProposePriceRev.type = "1"
            ElseIf XTCRevision.SelectedTabPageIndex = 1 Then
                gv = GVData
                ReportFGProposePriceRev.dt = GCData.DataSource
                ReportFGProposePriceRev.type = "2"
            End If
            ReportFGProposePriceRev.id = id
            If id_report_status <> "6" Then
                ReportFGProposePriceRev.is_pre = "1"
            Else
                ReportFGProposePriceRev.is_pre = "-1"
            End If
            ReportFGProposePriceRev.id_report_status = LEReportStatus.EditValue.ToString

            ReportFGProposePriceRev.rmt = rmt
            Dim Report As New ReportFGProposePriceRev()

            '' '... 
            '' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            gv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'style
            Report.GVData.OptionsPrint.UsePrintStyles = True
            Report.GVData.AppearancePrint.FilterPanel.BackColor = Color.Transparent
            Report.GVData.AppearancePrint.FilterPanel.ForeColor = Color.Black
            Report.GVData.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 5, FontStyle.Regular)

            Report.GVData.AppearancePrint.GroupFooter.BackColor = Color.Transparent
            Report.GVData.AppearancePrint.GroupFooter.ForeColor = Color.Black
            Report.GVData.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 5, FontStyle.Bold)

            Report.GVData.AppearancePrint.GroupRow.BackColor = Color.Transparent
            Report.GVData.AppearancePrint.GroupRow.ForeColor = Color.Black
            Report.GVData.AppearancePrint.GroupRow.Font = New Font("Tahoma", 5, FontStyle.Bold)


            Report.GVData.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
            Report.GVData.AppearancePrint.HeaderPanel.ForeColor = Color.Black
            Report.GVData.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 5, FontStyle.Bold)

            Report.GVData.AppearancePrint.FooterPanel.BackColor = Color.Transparent
            Report.GVData.AppearancePrint.FooterPanel.ForeColor = Color.Black
            Report.GVData.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 5.3, FontStyle.Bold)

            Report.GVData.AppearancePrint.Row.Font = New Font("Tahoma", 5.3, FontStyle.Regular)

            Report.GVData.OptionsPrint.ExpandAllDetails = True
            Report.GVData.OptionsPrint.UsePrintStyles = True
            Report.GVData.OptionsPrint.PrintDetails = True
            Report.GVData.OptionsPrint.PrintFooter = True

            Report.LabelNumber.Text = TxtNumber.Text
            Report.LabelRev.Text = TxtRevision.Text
            Report.LabelDate.Text = DECreated.Text.ToUpper
            Report.LabelSeason.Text = season.ToUpper
            Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
            Report.LNote.Text = MENote.Text

            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Or is_confirm = "1" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = rmt
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVRevision_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRevision.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub XTCRevision_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCRevision.SelectedPageChanged
        If XTCRevision.SelectedTabPageIndex = 1 Then
            viewPPAll()
        End If
    End Sub

    Private Sub CEShowHighlight_CheckedChanged(sender As Object, e As EventArgs) Handles CEShowHighlight.CheckedChanged
        AddHandler GVData.RowStyle, AddressOf custom_cell
        GCData.Focus()
    End Sub

    Public Sub custom_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If CEShowHighlight.EditValue = True Then
            Dim currview As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim stt As String = "0"
            Try
                stt = currview.GetRowCellValue(e.RowHandle, "id_fg_propose_price_rev_det").ToString
            Catch ex As Exception
                stt = "0"
            End Try

            If stt <> "0" Then
                e.Appearance.BackColor = Color.Yellow
            Else
                e.Appearance.BackColor = Color.Empty
            End If
        Else
            e.Appearance.BackColor = Color.Empty
        End If
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        makeSafeGV(GVRevision)
        saveChangesDetail()
        GVRevision.ActiveFilterString = "[is_select]='Yes'"
        If GVRevision.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete " + GVRevision.RowCount.ToString + " items ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim id_ppd As String = ""
                For i As Integer = 0 To (GVRevision.RowCount - 1)
                    If i > 0 Then
                        id_ppd += "OR "
                    End If
                    id_ppd += "id_fg_propose_price_rev_det='" + GVRevision.GetRowCellValue(i, "id_fg_propose_price_rev_det").ToString + "' "
                Next

                'delete
                Dim query As String = "DELETE FROM tb_fg_propose_price_rev_det WHERE (" + id_ppd + ")"
                execute_non_query(query, True, "", "", "", "")
                viewDetail()
                Cursor = Cursors.Default
            End If
        Else
            stopCustom("No data selected")
        End If
        GVRevision.ActiveFilterString = ""
    End Sub

    Sub saveChangesDetail()
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVRevision)
        If GVRevision.RowCount > 0 Then
            For i As Integer = 0 To (GVRevision.RowCount - 1)
                Dim id_fg_propose_price_rev_det As String = GVRevision.GetRowCellValue(i, "id_fg_propose_price_rev_det").ToString
                Dim msrp As String = decimalSQL(GVRevision.GetRowCellValue(i, "msrp").ToString)
                Dim price As String = decimalSQL(GVRevision.GetRowCellValue(i, "price").ToString)
                Dim sale_price As String = decimalSQL(GVRevision.GetRowCellValue(i, "sale_price").ToString)
                Dim additional_price As String = decimalSQL(GVRevision.GetRowCellValue(i, "additional_price").ToString)
                Dim remark As String = addSlashes(GVRevision.GetRowCellValue(i, "remark").ToString)
                Dim id_design_price_type_master As String = GVRevision.GetRowCellValue(i, "id_design_price_type_master").ToString
                Dim id_design_price_type_print As String = GVRevision.GetRowCellValue(i, "id_design_price_type_print").ToString

                Dim query As String = "UPDATE tb_fg_propose_price_rev_det SET msrp='" + msrp + "', price='" + price + "', sale_price='" + sale_price + "',
                additional_price='" + additional_price + "', remark='" + remark + "', id_design_price_type_master='" + id_design_price_type_master + "',id_design_price_type_print='" + id_design_price_type_print + "' WHERE id_fg_propose_price_rev_det='" + id_fg_propose_price_rev_det + "' "
                execute_non_query(query, True, "", "", "", "")
            Next
        End If
        Cursor = Cursors.Default
    End Sub

    Sub saveHead()
        'head
        Dim note As String = addSlashes(MENote.Text)

        Dim query_head As String = "UPDATE tb_fg_propose_price_rev SET note='" + note + "' WHERE id_fg_propose_price_rev='" + id + "' "
        execute_non_query(query_head, True, "", "", "", "")
    End Sub

    Private Sub CEFreeze_CheckedChanged(sender As Object, e As EventArgs) Handles CEFreeze.CheckedChanged
        If CEFreeze.EditValue = True Then
            If is_confirm = "2" Then
                GridColumnIsSelectRev.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            End If
            GridColumnNoRev.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            GridColumnDesignCodeRev.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            GridColumnCodeImportRev.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            GridColumnDesignNameRev.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Else
            GridColumnIsSelectRev.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            GridColumnNoRev.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            GridColumnDesignCodeRev.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            GridColumnCodeImportRev.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            GridColumnDesignNameRev.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None

            'index
            If is_confirm = "2" Then
                GridColumnIsSelectRev.VisibleIndex = 0
            End If
            GridColumnNoRev.VisibleIndex = 1
            GridColumnDesignCodeRev.VisibleIndex = 2
            GridColumnCodeImportRev.VisibleIndex = 3
            GridColumnDesignNameRev.VisibleIndex = 4
        End If
    End Sub

    Private Sub CEFreezeColAll_CheckedChanged(sender As Object, e As EventArgs) Handles CEFreezeColAll.CheckedChanged
        If CEFreezeColAll.EditValue = True Then
            GridColumnNo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            GridColumnDesignCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            GridColumnCodeImport.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            GridColumnDesignName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Else
            GridColumnNo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            GridColumnDesignCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            GridColumnCodeImport.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            GridColumnDesignName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None


            GridColumnNo.VisibleIndex = 0
            GridColumnDesignCode.VisibleIndex = 1
            GridColumnCodeImport.VisibleIndex = 2
            GridColumnDesignName.VisibleIndex = 3
        End If
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            'head
            saveHead()

            'detail
            saveChangesDetail()

            actionLoad()
            FormFGProposePrice.viewRevision()
            FormFGProposePrice.GVRev.FocusedRowHandle = find_row(FormFGProposePrice.GVRev, "id_fg_propose_price_rev", id)
        End If
    End Sub

    Sub updateCOP()
        Cursor = Cursors.WaitCursor
        'get all data
        Dim pp As New ClassFGProposePrice()
        Dim data As DataTable = pp.dataCOPList(id_season, id_source, id_division, False)

        'update per row
        For i As Integer = 0 To (GVRevision.RowCount - 1)
            Dim id_fg_propose_price_rev_det As String = GVRevision.GetRowCellValue(i, "id_fg_propose_price_rev_det").ToString
            Dim id_design As String = GVRevision.GetRowCellValue(i, "id_design").ToString
            Dim id_prod_demand_design As String = "NULL"
            Dim id_cop_status As String = "NULL"
            Dim qty As String = "0"
            Dim additional_cost As String = "0"
            Dim cop_rate_cat As String = "1"
            Dim cop_kurs As String = "0"
            Dim cop_value As String = "0"
            Dim cop_mng_kurs As String = "0"
            Dim cop_mng_value As String = "0"

            Dim dt As DataRow() = data.Select("[id_design]='" + id_design + "' ")
            Dim query As String = ""
            If dt.Length <= 0 Then
                query = "UPDATE tb_fg_propose_price_rev_det SET qty=0, additional_cost=0, cop_date=NOW(), cop_kurs=0, 
                        cop_value=0, cop_mng_kurs=0,cop_mng_value=0 WHERE id_fg_propose_price_rev_det=" + id_fg_propose_price_rev_det + " "
            Else
                id_prod_demand_design = dt(0)("id_prod_demand_design").ToString
                id_cop_status = dt(0)("id_cop_status").ToString
                qty = decimalSQL(dt(0)("qty").ToString)
                additional_cost = decimalSQL(dt(0)("additional_cost").ToString)
                cop_rate_cat = dt(0)("cop_rate_cat").ToString
                cop_kurs = decimalSQL(dt(0)("cop_kurs").ToString)
                cop_value = decimalSQL(dt(0)("cop_value").ToString)
                cop_mng_kurs = decimalSQL(dt(0)("cop_mng_kurs").ToString)
                cop_mng_value = decimalSQL(dt(0)("cop_mng_value").ToString)
                query = "UPDATE tb_fg_propose_price_rev_det SET id_prod_demand_design=" + id_prod_demand_design + ", id_cop_status=" + id_cop_status + ",
                        qty=" + qty + ", additional_cost=" + additional_cost + ", cop_date=NOW(), cop_rate_cat='" + cop_rate_cat + "', cop_kurs=" + cop_kurs + ", 
                        cop_value=" + cop_value + ", cop_mng_kurs=" + cop_mng_kurs + ",cop_mng_value=" + cop_mng_value + " 
                        WHERE id_fg_propose_price_rev_det=" + id_fg_propose_price_rev_det + " "
            End If
            execute_non_query(query, True, "", "", "", "")
        Next

        'refresh
        viewDetail()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnUpdateCOP_Click(sender As Object, e As EventArgs) Handles BtnUpdateCOP.Click
        makeSafeGV(GVRevision)
        saveChangesDetail()
        GVRevision.ActiveFilterString = "[is_select]='Yes'"
        If GVRevision.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action might update current cost with latest cost.  Are you sure you want to update these COP ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                updateCOP()
            End If
        Else
            stopCustom("No data selected")
        End If
        GVRevision.ActiveFilterString = ""
    End Sub

    Private Sub CESelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelAll.CheckedChanged
        Dim res As String = ""
        If CESelAll.EditValue = True Then
            res = "Yes"
        Else
            res = "No"
        End If

        For i As Integer = 0 To (GVRevision.RowCount - 1) - GetGroupRowCount(GVRevision)
            GVRevision.SetRowCellValue(i, "is_select", res)
        Next
    End Sub

    Private Sub GVRevision_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVRevision.CellValueChanged
        GVData.BestFitColumns()
    End Sub

    Private Sub GVRevision_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVRevision.RowCellStyle
        If e.RowHandle >= 0 Then
            If (e.Column.FieldName = "mark_up") And id_pp_type = "1" Then
                Dim val As Decimal = 0
                Try
                    val = sender.GetRowCellValue(e.RowHandle, sender.Columns("mark_up"))
                Catch ex As Exception
                End Try

                If val >= markup_target Then
                    e.Appearance.BackColor = Color.LightSeaGreen
                    e.Appearance.BackColor2 = Color.LightSeaGreen
                Else
                    e.Appearance.BackColor = Color.Crimson
                    e.Appearance.BackColor2 = Color.Crimson
                End If
            ElseIf (e.Column.FieldName = "mark_up_mng") And id_pp_type = "1" Then
                Dim val As Decimal = 0
                Try
                    val = sender.GetRowCellValue(e.RowHandle, sender.Columns("mark_up_mng"))
                Catch ex As Exception
                End Try

                If val >= markup_target Then
                    e.Appearance.BackColor = Color.LightSeaGreen
                    e.Appearance.BackColor2 = Color.LightSeaGreen
                Else
                    e.Appearance.BackColor = Color.Crimson
                    e.Appearance.BackColor2 = Color.Crimson
                End If
            End If
        End If
    End Sub
End Class