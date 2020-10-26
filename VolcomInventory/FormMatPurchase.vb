Public Class FormMatPurchase
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormMatPurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEEnd.EditValue = Now
        '
        viewSeason()
        view_mat_purc()
        view_mat_det_pd()
        '
        viewVendorKO()
        'GVMatPurchase.ActiveFilterString = "[id_mat_purc] > 1 AND [id_mat_purc] < 6"
    End Sub

    Sub view_mat_det_pd()
        Dim query As String = "SELECT '0' AS id_mat_det, '0' AS id_mat, 'ALL' AS mat_det_code, 'ALL' AS mat_det_display_name , '-' AS uom
UNION
SELECT md.`id_mat_det`,md.`id_mat`,md.`mat_det_code`,md.`mat_det_display_name` ,uom.`uom`
FROM tb_m_mat_det md
INNER JOIN tb_m_mat mat ON mat.`id_mat`=md.`id_mat`
INNER JOIN tb_m_uom uom ON uom.`id_uom`=mat.`id_uom`"
        viewSearchLookupQuery(SLEMatDet, query, "id_mat_det", "mat_det_display_name", "id_mat_det")
    End Sub

    Sub viewVendorKO()
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All Vendor') AS comp_name, ('ALL Vendor') AS comp_name_label UNION ALL "
        query += "SELECT comp.id_comp,comp.comp_number, comp.comp_name, CONCAT_WS(' - ', comp.comp_number,comp.comp_name) AS comp_name_label FROM tb_m_comp comp "
        query += "WHERE comp.id_comp_cat='1'"
        viewSearchLookupQuery(SLEVendorKO, query, "id_comp", "comp_name_label", "id_comp")
    End Sub

    Private Sub viewSeason()
        Dim query As String = "SELECT '0' as id_season,'All season' AS season UNION (SELECT id_season,season FROM tb_season ORDER BY id_season DESC)"
        viewSearchLookupQuery(LESeason, query, "id_season", "season", "id_season")
        viewSearchLookupQuery(SLEReport, query, "id_season", "season", "id_season")
    End Sub
    Private Sub FormMatPurchase_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormMatPurchase_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    Sub view_mat_purc()
        Dim query_where As String = ""
        If Not LESeason.EditValue.ToString = "0" Then
            query_where += " AND del.id_season='" & LESeason.EditValue.ToString & "'"
        End If

        Dim query = q_mat(query_where)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatPurchase.DataSource = data
        check_menu()
    End Sub
    Sub check_menu()
        If XTCPurcMat.SelectedTabPageIndex = 0 Then
            If GVMatPurchase.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
        Else
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub GVSamplePurchase_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatPurchase.FocusedRowChanged
        no_focus_gv(sender, e)
    End Sub

    Sub no_focus_gv(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub

    Private Sub GVSamplePurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMatPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "id_delivery" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatPurchase.IsGroupRow(rowhandle) Then
                rowhandle = GVMatPurchase.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMatPurchase.GetRowCellDisplayText(rowhandle, "delivery")
            End If
        End If
        If e.Column.FieldName = "id_season" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatPurchase.IsGroupRow(rowhandle) Then
                rowhandle = GVMatPurchase.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMatPurchase.GetRowCellDisplayText(rowhandle, "season")
            End If
        End If
    End Sub
    '========= from PD =============

    Private Sub GVProdDemand_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub

    Private Sub GVMatPurchase_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVMatPurchase.DoubleClick
        If GVMatPurchase.RowCount > 0 Then
            FormMatPurchaseDet.id_purc = GVMatPurchase.GetFocusedRowCellDisplayText("id_mat_purc")
            FormMatPurchaseDet.ShowDialog()
        End If
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        view_mat_purc()
    End Sub

    Private Sub BClearFilter_Click(sender As Object, e As EventArgs) Handles BClearFilter.Click
        GVMatPurchase.ActiveFilterString = ""
    End Sub

    Private Sub BFilter_Click(sender As Object, e As EventArgs) Handles BFilter.Click
        GVMatPurchase.ActiveFilterString = "[mat_purc_date] >= #" & Date.Parse(DEStart.EditValue.ToString).ToString("d") & "# AND [mat_purc_date] <= #" & Date.Parse(DEEnd.EditValue.ToString).ToString("d") & "#"
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        FormMatPurcSum.dt = GCMatPurchase.DataSource
        FormMatPurcSum.GVProd.ActiveFilterString = "[is_check]='yes'"
        FormMatPurcSum.ShowDialog()
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVMatPurchase.RowCount > 0 Then
            For i As Integer = 0 To ((GVMatPurchase.RowCount - 1) - GetGroupRowCount(GVMatPurchase))
                If CheckEditSelAll.Checked = False Then
                    GVMatPurchase.SetRowCellValue(i, "is_check", "no")
                Else
                    GVMatPurchase.SetRowCellValue(i, "is_check", "yes")
                End If
            Next
        End If
    End Sub

    Private Sub BViewKO_Click(sender As Object, e As EventArgs) Handles BViewKO.Click
        Dim query_where As String = ""
        '
        If Not SLEVendorKO.EditValue.ToString = "0" Then
            query_where += " AND c.id_comp='" & SLEVendorKO.EditValue.ToString & "'"
        End If
        '
        Dim query As String = "SELECT ko.*,c.`comp_name` FROM tb_prod_order_ko ko
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ko.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
WHERE ko.id_prod_order_ko 
IN (SELECT MAX(id_prod_order_ko) AS id FROM `tb_prod_order_ko`
GROUP BY id_prod_order_ko_reff) AND is_purc_mat=1 " & query_where & " ORDER BY ko.id_prod_order_ko DESC"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCKO.DataSource = data
        If GVKO.RowCount > 0 Then
            BEditKO.Visible = True
        Else
            BEditKO.Visible = False
        End If
        GVKO.BestFitColumns()
    End Sub

    Private Sub BEditKO_Click(sender As Object, e As EventArgs) Handles BEditKO.Click
        FormProductionKO.id_ko = GVKO.GetFocusedRowCellValue("id_prod_order_ko").ToString
        FormProductionKO.ShowDialog()
    End Sub

    Private Sub BGenerateFromPD_Click(sender As Object, e As EventArgs) Handles BGenerateFromPD.Click
        FormMatPurchasePD.ShowDialog()
    End Sub

    Sub load_list_mat_from_pd()
        Dim query As String = ""
        Dim query_where = ""
        If Not SLEMatDet.EditValue.ToString = "0" Then
            query_where = " WHERE md.id_mat_det='" & SLEMatDet.EditValue.ToString & "'"
        End If

        query = q_list(query_where)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListMatPD.DataSource = data
        GVListMatPD.BestFitColumns()
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_list_mat_from_pd()
    End Sub

    Private Sub GVListMatPD_DoubleClick(sender As Object, e As EventArgs) Handles GVListMatPD.DoubleClick
        If GVListMatPD.RowCount > 0 Then
            FormMatPurchasePD.id_list = GVListMatPD.GetFocusedRowCellValue("id_mat_purc_list").ToString
            FormMatPurchasePD.ShowDialog()
        End If
    End Sub

    Private Sub BCreatePO_Click(sender As Object, e As EventArgs) Handles BCreatePO.Click
        GVListMatPD.ActiveFilterString = "[is_check]='yes'"
        If GVListMatPD.RowCount > 0 Then
            'create PO
            'check vendor, id_currency must same
            Dim id_comp_contact As String = ""
            Dim id_currency As String = ""
            Dim not_same As Boolean = False
            Dim po_created As Boolean = False
            For i As Integer = 0 To GVListMatPD.RowCount - 1
                If id_comp_contact = "" And id_currency = "" Then
                    id_comp_contact = GVListMatPD.GetRowCellValue(i, "id_comp_contact").ToString
                    id_currency = GVListMatPD.GetRowCellValue(i, "id_currency").ToString
                Else
                    If Not id_comp_contact = GVListMatPD.GetRowCellValue(i, "id_comp_contact").ToString Or Not id_currency = GVListMatPD.GetRowCellValue(i, "id_currency").ToString Then
                        not_same = True
                        Exit For
                    End If
                End If
                Dim query_check As String = "SELECT id_mat_purc FROM tb_mat_purc_list WHERE id_mat_purc_list='" & GVListMatPD.GetRowCellValue(i, "id_mat_purc_list") & "'"
                Dim id_cek As String = execute_query(query_check, 0, True, "", "", "", "")
                '
                If Not id_cek = "" Then
                    po_created = True
                End If
            Next
            '
            If not_same = True Then
                warningCustom("Make sure only material with same vendor and same currency selected.")
            ElseIf po_created = True Then
                warningCustom("Make sure PO not already created.")
            Else
                FormMatPurchaseDet.is_from_list = "1"
                FormMatPurchaseDet.ShowDialog()
            End If
        Else
            warningCustom("Please choose list first")
        End If
        GVListMatPD.ActiveFilterString = ""
    End Sub

    Private Sub XTCPurcMat_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPurcMat.SelectedPageChanged
        check_menu()
    End Sub

    Sub open_mat()
        FormMasterRawMaterialDetSingle.action = "upd"

        FormMasterRawMaterialDetSingle.id_mat = GVListMatPD.GetFocusedRowCellValue("id_mat").ToString
        FormMasterRawMaterialDetSingle.LabelPrintedName.Text = GVListMatPD.GetFocusedRowCellValue("mat_display_name").ToString
        FormMasterRawMaterialDetSingle.TxtMaterialTypeCode.Text = GVListMatPD.GetFocusedRowCellValue("mat_code").ToString

        FormMasterRawMaterialDetSingle.id_mat_det = GVListMatPD.GetFocusedRowCellValue("id_mat_det").ToString
        FormMasterRawMaterialDetSingle.ShowDialog()
    End Sub

    Private Sub SMMasterMat_Click(sender As Object, e As EventArgs) Handles SMMasterMat.Click
        If GVListMatPD.RowCount > 0 Then
            open_mat()
        End If
    End Sub

    Private Sub BSearchReport_Click(sender As Object, e As EventArgs) Handles BSearchReport.Click
        view_report()
    End Sub

    Sub view_report()
        Dim query_where As String = ""
        If Not SLEReport.EditValue.ToString = "0" Then
            query_where += " WHERE del.id_season='" & SLEReport.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT pd.*,dsg.`design_code`,dsg.`design_display_name`,listt.`id_mat_purc_list`
,COUNT(listt.`id_mat_purc_list`) AS jml_list,GROUP_CONCAT(listt.`id_mat_purc_list`) AS id_list_group,GROUP_CONCAT(LPAD(listt.`id_mat_purc_list`,6,'0')) AS list_group
,COUNT(mp.`id_mat_purc`) AS jml_po,GROUP_CONCAT(DISTINCT(mp.`id_mat_purc`)) AS id_po_group ,GROUP_CONCAT(DISTINCT(mp.mat_purc_number)) AS po_group
FROM
(
	SELECT IFNULL(pdpo.id_prod_demand,newest_pd.id_prod_demand) AS id_prod_demand,
	IFNULL(pdpo.id_design,newest_pd.id_design) AS id_design,
	IFNULL(pdpo.id_prod_demand_design,newest_pd.id_prod_demand_design) AS id_prod_demand_design,
	IFNULL(pdpo.id_product,newest_pd.id_product) AS id_product,
	IFNULL(pdpo.id_prod_demand_product,newest_pd.id_prod_demand_product) AS id_prod_demand_product,
	IFNULL(pdpo.prod_demand_product_qty,newest_pd.prod_demand_product_qty) AS prod_demand_product_qty,
	IFNULL(pdpo.prod_demand_number,newest_pd.prod_demand_number) AS prod_demand_number,
    IFNULL(pdpo.id_delivery,newest_pd.id_delivery) AS id_delivery
	FROM (
		SELECT * FROM (
			SELECT pdd.id_delivery,pd.id_prod_demand,pdd.`id_design`,pdd.`id_prod_demand_design`,pdp.`id_product`,pdp.`id_prod_demand_product`,pdp.`prod_demand_product_qty`,pd.`prod_demand_number` FROM tb_prod_demand pd
			INNER JOIN tb_prod_demand_design pdd ON pd.`id_prod_demand`=pdd.`id_prod_demand`
			INNER JOIN tb_prod_demand_product pdp ON pdp.`id_prod_demand_design`=pdd.`id_prod_demand_design`
			WHERE pd.id_report_status=6 AND pd.`is_pd`=1 AND pd.`is_void_pd`=2
			ORDER BY pdp.id_prod_demand_product DESC
		) pd GROUP BY id_product
	) newest_pd 
	LEFT JOIN
	(
		SELECT pdd.id_delivery,pd.`id_prod_demand`,pdd.`id_design`,pdd.`id_prod_demand_design`,pdp.id_product,pdp.id_prod_demand_product,pdp.prod_demand_product_qty,po.id_prod_order,pd.`prod_demand_number` 
		FROM tb_prod_order po
		INNER JOIN `tb_prod_demand_design` pdd ON po.id_prod_demand_design=pdd.`id_prod_demand_design`
		INNER JOIN tb_prod_demand pd ON pdd.`id_prod_demand`=pd.`id_prod_demand`
		INNER JOIN tb_prod_demand_product pdp ON pdp.`id_prod_demand_design`=pdd.`id_prod_demand_design`
		WHERE pd.`is_pd`=1 AND pd.`is_void_pd` =2 AND pd.`id_report_status`=6 AND po.`id_report_status`!=5
		GROUP BY pdp.id_product
	)pdpo ON pdpo.id_product=newest_pd.id_product
	GROUP BY IFNULL(pdpo.id_prod_demand_design,newest_pd.id_prod_demand_design)
)pd 
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pd.id_design
INNER JOIN `tb_season_delivery` del ON pd.`id_delivery`=del.`id_delivery`
LEFT JOIN `tb_mat_purc_list_pd` listpd ON listpd.`id_prod_demand_design`=pd.id_prod_demand_design
LEFT JOIN tb_mat_purc_list listt ON listt.`id_mat_purc_list`=listpd.`id_mat_purc_list` AND listt.`is_cancel`!=1
LEFT JOIN `tb_mat_purc` mp ON mp.`id_mat_purc`=listt.`id_mat_purc` AND mp.`id_report_status`!=5
" & query_where & "
GROUP BY pd.id_prod_demand_design"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPD.DataSource = data
        GVPD.BestFitColumns()
    End Sub

    Private Sub BShowFilterPanel_Click(sender As Object, e As EventArgs) Handles BShowFilterPanel.Click
        PCFilterDate.Visible = True
    End Sub

    Private Sub ViewPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewPOToolStripMenuItem.Click
        If GVPD.GetFocusedRowCellValue("id_po_group").ToString = "" Then
            warningCustom("No PO listed")
        Else
            XTCPurcMat.SelectedTabPageIndex = 0
            Dim query = q_mat(" AND a.id_mat_purc IN (" & GVPD.GetFocusedRowCellValue("id_po_group").ToString & ")")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMatPurchase.DataSource = data
            GVMatPurchase.ExpandAllGroups()
            check_menu()
        End If
    End Sub

    Function q_mat(ByVal q_where As String)
        Dim query As String = "SELECT '' AS `no`,a.mat_purc_vat as vat,'no' AS is_check,IFNULL(rev.mat_purc_number,'-') AS mat_purc_rev_number,a.id_report_status,h.report_status,a.id_mat_purc, 
DATE_ADD(a.`mat_purc_date`,INTERVAL a.`mat_purc_lead_time` DAY) AS est_del_date,a.id_comp_contact_to AS id_comp_contact,d.id_comp AS id_comp,
DATE_ADD(a.`mat_purc_date`,INTERVAL (a.`mat_purc_lead_time`+a.`mat_purc_top`) DAY) AS payment_due_date,
a.`mat_purc_lead_time` AS lead_time,a.`mat_purc_top` AS top,
b.id_season,a.id_delivery,i.delivery, rang.`range`,
b.season, g.payment,
d.comp_name AS comp_name_to,  d.`comp_number` AS comp_number_to,
f.comp_name AS comp_name_ship_to, 
a.mat_purc_number,
a.mat_purc_date, del.`id_season`, 
DATE_ADD(a.mat_purc_date,INTERVAL a.mat_purc_lead_time DAY) AS mat_purc_lead_time, 
DATE_ADD(a.mat_purc_date,INTERVAL (a.mat_purc_top+a.mat_purc_lead_time) DAY) AS mat_purc_top 
,cur.`currency` AS po_curr,a.`mat_purc_kurs` AS po_kurs
,SUM(mpd.`mat_purc_det_price` * mpd.`mat_purc_det_qty`)* ((100 + a.mat_purc_vat)/100) AS po_amount
,SUM(mpd.`mat_purc_det_qty`) AS qty_order
,SUM(IF(a.`id_currency`=1,1,a.`mat_purc_kurs`) * mpd.`mat_purc_det_price` * mpd.`mat_purc_det_qty`) * ((100 + a.mat_purc_vat)/100) AS po_amount_rp
,uom.`uom`
,SUM(mpd.`mat_purc_det_qty`) AS qty_po,IFNULL(SUM(rec.qty_rec),0) AS qty_rec
FROM tb_mat_purc a INNER JOIN tb_season_delivery i ON a.id_delivery = i.id_delivery 
INNER JOIN tb_season b ON i.id_season = b.id_season 
INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_to = c.id_comp_contact 
INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact 
INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp 
INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment 
LEFT JOIN tb_mat_purc rev ON rev.id_mat_purc = a.id_mat_purc_rev 
INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status
INNER JOIN `tb_season_delivery` del ON a.`id_delivery`=del.`id_delivery`
INNER JOIN tb_season ssn ON ssn.`id_season`=del.`id_season`
INNER JOIN `tb_range` rang ON rang.id_range=ssn.id_range
INNER JOIN tb_mat_purc_det mpd ON mpd.`id_mat_purc`=a.`id_mat_purc`
INNER JOIN tb_lookup_currency cur ON cur.id_currency=a.id_currency
INNER JOIN tb_m_mat_det_price prc ON prc.`id_mat_det_price`=mpd.`id_mat_det_price`
INNER JOIN tb_m_mat_det md ON md.`id_mat_det`=prc.`id_mat_det`
INNER JOIN tb_m_mat mat ON mat.`id_mat`=md.`id_mat`
INNER JOIN tb_m_uom uom ON uom.`id_uom`=mat.`id_uom`
LEFT JOIN 
(
	SELECT recd.id_mat_purc_det,SUM(mat_purc_rec_det_qty) AS qty_rec
	FROM `tb_mat_purc_rec_det` recd 
	INNER JOIN `tb_mat_purc_rec` rec ON rec.id_mat_purc_rec=recd.id_mat_purc_rec AND rec.id_report_status=6
	GROUP BY recd.id_mat_purc_det
)rec ON rec.id_mat_purc_det=mpd.id_mat_purc_det
WHERE 1=1 " & q_where & "
GROUP BY mpd.`id_mat_purc`"
        Return query
    End Function

    Function q_list(ByVal q_where As String)
        Dim query As String = "SELECT 'no' AS is_check,pl.`id_mat_purc_list`,LPAD(pl.`id_mat_purc_list`,6,'0') AS number
,md.mat_det_display_name,md.mat_det_code,IFNULL(mp.mat_purc_number,'-') AS mat_purc_number,IF(ISNULL(pl.id_mat_purc),IF(pl.is_cancel=1,'Canceled','Waiting to PO'),'PO Created') AS `status`
,mdp.id_mat_det_price,mdp.id_comp_contact,mdp.mat_det_price,mdp.id_currency,cur.currency
,cc.id_comp_contact,c.comp_name,c.comp_number,c.address_primary,cc.contact_person
,md.mat_det_name,color.display_name AS color,size.display_name AS size
,m.mat_code,m.mat_display_name,m.id_mat,md.id_mat_det
,mdp.min_qty_in_bulk,mdp.bulk_unit, CONCAT(mdp.min_qty_in_bulk,'/',IF(mdp.bulk_unit='','pcs',mdp.bulk_unit)) AS conversion
,SUM(plp.`total_qty_pd`*pl.`qty_consumption`)+CEIL(SUM(plp.total_qty_pd*pl.`qty_consumption`)*(pl.tolerance/100)) AS total_qty_list
,ROUND((SUM(plp.`total_qty_pd`*pl.`qty_consumption`)+CEIL(SUM(plp.total_qty_pd*pl.`qty_consumption`)*(pl.tolerance/100)))/mdp.min_qty_in_bulk,2) AS total_qty_list_conv
,IF(mdp.min_qty_in_bulk=1,'',CONCAT(CEIL((SUM(plp.`total_qty_pd`*pl.`qty_consumption`)+CEIL(SUM(plp.total_qty_pd*pl.`qty_consumption`)*(pl.tolerance/100)))/mdp.min_qty_in_bulk),' ',mdp.bulk_unit)) AS order_note
,CEIL((SUM(plp.`total_qty_pd`*pl.`qty_consumption`)+CEIL(SUM(plp.total_qty_pd*pl.`qty_consumption`)*(pl.tolerance/100)))/mdp.min_qty_in_bulk) AS total_qty_order_conv
,CEIL((SUM(plp.`total_qty_pd`*pl.`qty_consumption`)+CEIL(SUM(plp.total_qty_pd*pl.`qty_consumption`)*(pl.tolerance/100)))/mdp.min_qty_in_bulk)*mdp.min_qty_in_bulk AS total_qty_order
FROM `tb_mat_purc_list` pl
INNER JOIN `tb_mat_purc_list_pd` plp ON plp.id_mat_purc_list=pl.id_mat_purc_list
INNER JOIN tb_m_mat_det md ON md.`id_mat_det`=pl.`id_mat_det`
INNER JOIN tb_m_mat m ON m.id_mat=md.id_mat
LEFT JOIN tb_mat_purc mp ON mp.`id_mat_purc`=pl.`id_mat_purc`
INNER JOIN tb_m_mat_det_price mdp ON mdp.is_default_po='1' AND mdp.id_mat_det=pl.id_mat_det
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=mdp.id_comp_contact
INNER JOIN tb_lookup_currency cur ON cur.id_currency=mdp.id_currency
LEFT JOIN
(
	SELECT mdc.id_mat_det,mcd.display_name FROM tb_m_mat_det_code mdc
	INNER JOIN tb_m_code_detail mcd ON mcd.id_code_detail=mdc.id_code_detail AND mcd.id_code=1
) color ON color.id_mat_det=md.id_mat_det
LEFT JOIN
(
	SELECT mdc.id_mat_det,mcd.display_name FROM tb_m_mat_det_code mdc
	INNER JOIN tb_m_code_detail mcd ON mcd.id_code_detail=mdc.id_code_detail AND mcd.id_code=13
) size ON size.id_mat_det=md.id_mat_det
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
" & q_where & "
GROUP BY pl.`id_mat_purc_list`"
        Return query
    End Function

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If GVPD.GetFocusedRowCellValue("id_list_group").ToString = "" Then
            warningCustom("No List created")
        Else
            XTCPurcMat.SelectedTabPageIndex = 1
            XTCListPD.SelectedTabPageIndex = 0
            Dim query = q_list(" WHERE pl.`id_mat_purc_list` IN (" & GVPD.GetFocusedRowCellValue("id_list_group").ToString & ")")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCListMatPD.DataSource = data
            GVListMatPD.BestFitColumns()
            check_menu()
        End If
    End Sub
End Class