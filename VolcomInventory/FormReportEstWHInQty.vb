Public Class FormReportEstWHInQty
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Public is_qc As String = "-1"
    '
    Private Sub FormReportEstWHInQty_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormReportEstWHInQty_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormReportEstWHInQty_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub viewSeason()
        Dim query As String = "SELECT '0' as id_season,'All season' AS season UNION (SELECT id_season,season FROM tb_season ORDER BY id_season DESC)"
        viewSearchLookupQuery(SLEReport, query, "id_season", "season", "id_season")
    End Sub

    Private Sub FormReportEstWHInQty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
        load_type()
        DEStart.EditValue = Now
        DEEnd.EditValue = Now
        '
        If is_qc = "1" Then
            GridColumnEstInWH.OptionsColumn.ShowInCustomizationForm = False
            GridColumnEstInWH.Visible = False
            GridColumnStatus.OptionsColumn.ShowInCustomizationForm = True
            GridColumnStatus.Visible = True
            GridColumnEstInStoreDate.OptionsColumn.ShowInCustomizationForm = True
            GridColumnEstInStoreDate.Visible = True
        Else
            GridColumnEstInStoreDate.OptionsColumn.ShowInCustomizationForm = True
            GridColumnEstInStoreDate.Visible = True
            GridColumnEstInWH.OptionsColumn.ShowInCustomizationForm = True
            GridColumnEstInWH.Visible = True
            GridColumnStatus.OptionsColumn.ShowInCustomizationForm = False
            GridColumnStatus.Visible = False
        End If
    End Sub

    Sub load_type()
        Dim query As String = ""
        If is_qc = "1" Then
            query = "SELECT '2' AS opt,'Estimate Receive QC Date' AS type
UNION
SELECT '3' AS opt,'Estimate in Store Date' AS type"
        Else
            query = "SELECT '2' AS opt,'Estimate Receive QC Date' AS type
UNION
SELECT '1' AS opt,'Estimate in WH Date' AS type
UNION
SELECT '3' AS opt,'Estimate in Store Date' AS type"
        End If

        viewSearchLookupQuery(SLEType, query, "opt", "type", "opt")
    End Sub

    Sub load_data()
        Dim date_start As String = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_end As String = Date.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim query As String = "CALL report_est_in_wh_qty('" & is_qc & "','" & SLEType.EditValue.ToString & "','" & date_start & "','" & date_end & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCWorkOrder.DataSource = data
        GVWorkOrder.BestFitColumns()
        '
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEEnd.Properties.MinValue = DEStart.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BViewSum_Click(sender As Object, e As EventArgs) Handles BViewSum.Click
        load_data()
    End Sub

    Private Sub GVWorkOrder_DoubleClick(sender As Object, e As EventArgs) Handles GVWorkOrder.DoubleClick
        Cursor = Cursors.WaitCursor
        If GVWorkOrder.RowCount > 0 And Not GVWorkOrder.IsGroupRow(GVWorkOrder.FocusedRowHandle) Then
            Dim report_mark_type As String = "-1"
            Dim id_report As String = "-1"
            '
            report_mark_type = GVWorkOrder.GetFocusedRowCellValue("report_mark_type").ToString
            id_report = GVWorkOrder.GetFocusedRowCellValue("id_report").ToString
            '
            Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
            showpopup.opt = "no cost"
            showpopup.report_mark_type = report_mark_type
            showpopup.id_report = id_report
            showpopup.show()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BSearchReport_Click(sender As Object, e As EventArgs) Handles BSearchReport.Click
        view_report()
    End Sub

    Sub view_report()
        Dim query_where As String = ""
        If Not SLEReport.EditValue.ToString = "0" Then
            query_where += " AND del.id_season='" & SLEReport.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT pd.*,dsg.`design_code`,dsg.`design_display_name`,listt.`id_mat_purc_list`
,mp.`id_mat_purc`,mp.mat_purc_number,mp.`mat_purc_date`,sts.`report_status`,po_det.mat_cat
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
LEFT JOIN 
(
	SELECT mpd.`id_mat_purc`,GROUP_CONCAT(DISTINCT(mc.`mat_cat`)) AS mat_cat FROM tb_mat_purc_det mpd
	INNER JOIN tb_m_mat_det_price prc ON prc.`id_mat_det_price`=mpd.`id_mat_det_price`
	INNER JOIN tb_m_mat_det md ON md.id_mat_det=prc.`id_mat_det`
	INNER JOIN tb_m_mat m ON m.id_mat=md.`id_mat`
	INNER JOIN tb_m_mat_cat mc ON m.id_mat_cat=mc.`id_mat_cat`
	GROUP BY mpd.`id_mat_purc`,mc.`id_mat_cat`
) po_det ON po_det.id_mat_purc=mp.`id_mat_purc`
LEFT JOIN tb_lookup_report_status sts ON sts.`id_report_status`=mp.`id_report_status`
WHERE IF(ISNULL(listt.id_mat_purc_list),TRUE,IF(ISNULL(mp.id_mat_purc),FALSE,TRUE)) " & query_where & "
GROUP BY pd.id_prod_demand_design,mp.id_mat_purc "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPD.DataSource = data
        GVPD.BestFitColumns()
    End Sub
End Class