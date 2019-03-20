Public Class FormSampleBudget
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"

        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormPurcReq_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPurcReq_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormPurcReq_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        load_budget()
    End Sub

    Private Sub FormSampleBudget_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEYearBudget.EditValue = Now
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
        '
        DEStartCard.EditValue = Now
        DEUntilCard.EditValue = Now
        '
        load_budget_card()
        load_budget_cat_card()
        '
        SLEBudget.EditValue = Nothing
    End Sub

    Sub load_budget_card()
        Dim where_active As String = ""

        Dim query As String = "SELECT spb.`id_sample_purc_budget`,spb.`description`,spb.`year`,spb.`value_rp`,spb.`value_usd`,GROUP_CONCAT(spbd.id_code_division) AS id_code_division,spb.`value_rp` - IFNULL(used_budget.budget_rp,0.00) AS remaining_rp,spb.`value_usd` - IFNULL(used_budget.budget_usd,0.00) AS remaining_usd FROM `tb_sample_purc_budget_div` spbd
INNER JOIN tb_sample_purc_budget spb ON spb.id_sample_purc_budget=spbd.`id_sample_purc_budget`
INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=spbd.`id_code_division`
LEFT JOIN (
	SELECT sp.id_sample_purc_budget,SUM(IF(sp.id_currency=1,spd.sample_purc_det_qty,0)*spd.sample_purc_det_price) AS budget_rp, SUM(IF(sp.id_currency=2,spd.sample_purc_det_qty,0)*spd.sample_purc_det_price) AS budget_usd FROM tb_sample_purc_det spd
	INNER JOIN tb_sample_purc sp ON sp.id_sample_purc=spd.id_sample_purc
	WHERE sp.id_report_status!=5
	GROUP BY sp.id_sample_purc_budget
)used_budget ON used_budget.id_sample_purc_budget=spb.id_sample_purc_budget
WHERE 1=1 " & where_active & "
GROUP BY spb.`id_sample_purc_budget`"
        viewSearchLookupQuery(SLEBudget, query, "id_sample_purc_budget", "description", "id_sample_purc_budget")
        SLEBudget.Properties.View.BestFitColumns()
    End Sub

    Sub load_budget_cat_card()
        Dim query As String = "	SELECT dt.`id_code`,ct.`sample_purc_budget_cat`,spb.year,concat(ct.`sample_purc_budget_cat`,' ',spb.year) AS description FROM `tb_sample_purc_budget_div` d
	INNER JOIN tb_m_code_detail dt ON d.`id_code_division`=dt.`id_code_detail`
	INNER JOIN `tb_sample_purc_budget_cat` ct ON ct.`id_code`=dt.`id_code`
	INNER JOIN tb_sample_purc_budget spb ON spb.id_sample_purc_budget=d.id_sample_purc_budget
	GROUP BY spb.year,dt.`id_code`"
        viewSearchLookupQuery(SLEBudgetCat, query, "id_code", "description", "id_code")
        SLEBudgetCat.EditValue = Nothing
    End Sub

    Sub load_budget()
        Dim query As String = "SELECT 'no' AS is_check,spb.kurs,spb.id_sample_purc_budget,spb.description,spb.`year`,spb.value_rp,spb.value_usd,GROUP_CONCAT(cd.code_detail_name) AS division,GROUP_CONCAT(cd.id_code_detail) AS id_division
FROM `tb_sample_purc_budget` spb
INNER JOIN `tb_sample_purc_budget_div` spd ON spd.`id_sample_purc_budget`=spb.`id_sample_purc_budget`
INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=spd.`id_code_division`
WHERE spb.`is_active`='1' AND spb.year='" & Date.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy") & "' AND spb.id_sample_purc_budget!=0 
GROUP BY spb.`id_sample_purc_budget`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBudgetList.DataSource = data
        GVBudgetList.BestFitColumns()
    End Sub

    Private Sub BNewBudget_Click(sender As Object, e As EventArgs) Handles BNewBudget.Click
        load_budget()
        '
        Dim query As String = "SELECT COUNT(*) FROM `tb_sample_budget_pps_det` ppd
INNER JOIN tb_sample_budget_pps pps ON pps.`id_sample_budget_pps`=ppd.`id_sample_budget_pps`
WHERE ppd.year_after='" & DEYearBudget.Text & "' AND pps.`id_report_status` != 5 AND pps.`id_report_status` !=6"
        Dim jml As String = execute_query(query, 0, True, "", "", "", "").ToString

        If GVBudgetList.RowCount > 0 Then
            stopCustom("Please use revision")
        ElseIf Not jml = "0" Then
            stopCustom("There is ongoing proposal, please cancel it first")
        Else
            FormSampleBudgetDet.ShowDialog()
        End If
    End Sub

    Private Sub BShowList_Click(sender As Object, e As EventArgs) Handles BShowList.Click
        load_propose()
    End Sub

    Sub load_propose()
        Dim query As String = "SELECT pps.*,emp.employee_name,sts.report_status FROM `tb_sample_budget_pps` pps
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
WHERE DATE(pps.date_created) <='" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(pps.date_created) >='" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "'
ORDER BY pps.id_sample_budget_pps DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "'")
        GCProposeList.DataSource = data
        GVProposeList.BestFitColumns()
    End Sub

    Private Sub BEdit_Click(sender As Object, e As EventArgs) Handles BEdit.Click
        FormSampleBudgetDet.id_pps = GVProposeList.GetFocusedRowCellValue("id_sample_budget_pps").ToString
        FormSampleBudgetDet.ShowDialog()
    End Sub

    Private Sub BRevision_Click(sender As Object, e As EventArgs) Handles BRevision.Click
        load_budget()
        '
        Dim query As String = "SELECT COUNT(*) FROM `tb_sample_budget_pps_det` ppd
INNER JOIN tb_sample_budget_pps pps ON pps.`id_sample_budget_pps`=ppd.`id_sample_budget_pps`
WHERE ppd.year_after='" & DEYearBudget.Text & "' AND pps.`id_report_status` != 5 AND pps.`id_report_status` !=6"
        Dim jml As String = execute_query(query, 0, True, "", "", "", "").ToString

        If Not jml = "0" Then
            stopCustom("There is ongoing proposal, please cancel it first")
        ElseIf GVBudgetList.RowCount = 0 Then
            stopCustom("Nothing to revise")
        Else
            FormSampleBudgetDet.is_rev = "1"
            FormSampleBudgetDet.ShowDialog()
        End If
        '
    End Sub

    Private Sub BShowAll_Click(sender As Object, e As EventArgs) Handles BShowAll.Click
        Dim query As String = "SELECT pps.*,emp.employee_name,sts.report_status FROM `tb_sample_budget_pps` pps
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
ORDER BY pps.id_sample_budget_pps DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "'")
        GCProposeList.DataSource = data
        GVProposeList.BestFitColumns()
    End Sub

    Private Sub BSearchCard_Click(sender As Object, e As EventArgs) Handles BSearchCard.Click
        Dim query As String = "CALL view_sample_budget_po_card('" & Date.Parse(DEStartCard.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DEUntilCard.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & SLEBudget.EditValue.ToString & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "'")
        GCBudgetCard.DataSource = data
        GVBudgetCard.BestFitColumns()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Cursor = Cursors.WaitCursor
        '

        ReportSampleBudgetUsage.dt = GCBudgetCard.DataSource
        Dim Report As New ReportSampleBudgetUsage()
        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVBudgetCard.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVBudgetCard.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVBudgetCard)
        Report.GVBudgetCard.AppearancePrint.Row.Font = New Font("Tahoma", 7, FontStyle.Regular)
        Report.GVBudgetCard.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 7, FontStyle.Regular)
        Report.GVBudgetCard.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 7, FontStyle.Regular)
        '
        'Parse val
        Report.LBudget.Text = SLEBudget.Text
        Report.LBudgetYear.Text = SLEBudget.Properties.View.GetFocusedRowCellValue("year").ToString
        Report.LPeriode.Text = DEStartCard.Text & " - " & DEUntilCard.Text

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()

        Cursor = Cursors.Default
    End Sub

    Private Sub BSearchBudgetCat_Click(sender As Object, e As EventArgs) Handles BSearchBudgetCat.Click
        If SLEBudgetCat.EditValue = Nothing Then
            warningCustom("Please select category.")
        Else
            '
            Dim id_code As String = SLEBudgetCat.EditValue.ToString
            Dim year As String = SLEBudgetCat.Properties.View.GetFocusedRowCellValue("year").ToString
            Dim query As String = "CALL view_sample_budget_po_card_cat('" & Date.Parse(DEStartCard.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DEUntilCard.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & id_code & "','" & year & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "'")

            GCBudgetCard.DataSource = data
            GVBudgetCard.BestFitColumns()
        End If
    End Sub
End Class