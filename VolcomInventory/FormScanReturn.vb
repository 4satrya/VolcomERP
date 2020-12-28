Public Class FormScanReturn
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormProductionRec_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormProductionRec_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If XTCScanReturn.SelectedTabPageIndex = 0 Then
            If GVAwb.RowCount < 1 Then
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
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
        Else
            If GVBAP.RowCount < 1 Then
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
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
        End If
    End Sub

    Private Sub FormScanReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
        DEStartBAP.EditValue = Now
        DEUntilBAP.EditValue = Now
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_view()
    End Sub

    Sub load_view()
        Dim date_start As String = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_until As String = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim q As String = "SELECT sr.created_date,rn.date_return_note,sr.`id_scan_return`,rn.`id_return_note`,rn.`label_number`,rn.`number_return_note`,IFNULL(awb.`awb_number`,'Warheouse') AS awb_number,IFNULL(c.`comp_name`,'Warheouse') AS comp_name
,GROUP_CONCAT(DISTINCT(CONCAT(cst.`comp_number`,' - ',cst.comp_name)) ORDER BY cst.`comp_number` SEPARATOR '\n') AS list_store
,rn.`qty` AS qty_return_note
,COUNT(DISTINCT srd.`id_scan_return_det`) AS qty_scan
,IFNULL(bap.qty_bap,0) AS qty_bap
,bap.bap_number
,IF(sr.is_void=2,'-','Void') AS sts_void
FROM tb_scan_return_det srd
INNER JOIN tb_scan_return sr ON sr.`id_scan_return`=srd.`id_scan_return`
INNER JOIN tb_return_note rn ON rn.`id_return_note`=sr.`id_return_note`
LEFT JOIN tb_inbound_awb awb ON rn.`id_inbound_awb`=awb.`id_inbound_awb`
LEFT JOIN tb_m_comp c ON c.`id_comp`=awb.`id_comp`
LEFT JOIN tb_return_note_store st ON st.`id_return_note`=rn.`id_return_note`
LEFT JOIN tb_m_comp cst ON cst.`id_comp`=st.`id_comp`
LEFT JOIN 
(
	SELECT bapd.`id_return_note`,SUM(bapd.`qty`*IF(bapd.`id_type`=1,1,-1)) AS qty_bap ,GROUP_CONCAT(DISTINCT(bap.`bap_number`) ORDER BY bap.`bap_number` SEPARATOR '\n') AS bap_number
	FROM tb_scan_return_bap_det bapd 
	INNER JOIN tb_scan_return_bap bap ON bap.`id_scan_return_bap`=bapd.`id_scan_return_bap`
	GROUP BY bapd.`id_return_note`
)bap ON bap.id_return_note=rn.`id_return_note`
WHERE DATE(rn.`date_created`)>='" & date_start & "' AND DATE(rn.`date_created`)<='" & date_until & "'
GROUP BY srd.`id_scan_return`
"

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCAwb.DataSource = dt
        GVAwb.BestFitColumns()
    End Sub

    Private Sub FormScanReturn_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BViewBAP_Click(sender As Object, e As EventArgs) Handles BViewBAP.Click
        load_bap()
    End Sub

    Sub load_bap()
        Dim date_start As String = Date.Parse(DEStartBAP.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_until As String = Date.Parse(DEUntilBAP.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim q As String = "SELECT IFNULL(c.comp_name,'Warehouse') AS comp_name,id_scan_return_bap,bap_number,`bap_date`,`is_lubang`,`is_seal_rusak`,`is_basah`,`is_other_cond`,`other_cond`,emp.employee_name,bap.created_date
FROM tb_scan_return_bap bap 
LEFT JOIN tb_m_comp c ON c.id_comp=bap.id_3pl
INNER JOIN tb_m_user usr ON usr.id_user=bap.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE DATE(bap.`created_date`)>='" & date_start & "' AND DATE(bap.`created_date`)<='" & date_until & "'"

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCBAP.DataSource = dt
        GVBAP.BestFitColumns()
    End Sub

    Private Sub GVBAP_DoubleClick(sender As Object, e As EventArgs) Handles GVBAP.DoubleClick
        FormScanReturnBAP.id_bap = GVBAP.GetFocusedRowCellValue("id_scan_return_bap").ToString
        FormScanReturnBAP.ShowDialog()
    End Sub

    Private Sub BPrintSummary_Click(sender As Object, e As EventArgs) Handles BPrintSummary.Click
        FormScanReturnSummary.ShowDialog()
    End Sub

    Private Sub BViewScan_Click(sender As Object, e As EventArgs) Handles BViewScan.Click
        Dim date_start As String = Date.Parse(DEStartScan.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_until As String = Date.Parse(DEUntilScan.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim q As String = "SELECT st_list.store AS list_store,rn.`number_return_note`,rn.`label_number`,scd.id_scan_return_det,scd.id_product,IFNULL(prd.product_full_code,scd.scanned_code) AS product_full_code,IFNULL(prd.product_display_name,scd.description) AS product_display_name,pc.size,scd.`type`,IF(scd.`type`=1,'Ok',IF(scd.`type`=2,'No Tag','Unique Duplicate')) AS notes 
FROM `tb_scan_return_det` scd
LEFT JOIN tb_m_product prd ON prd.id_product=scd.id_product
LEFT JOIN 
(
	SELECT pc.id_product,cd.`code_detail_name` AS size
	FROM tb_m_product_code pc 
	INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail`
	GROUP BY pc.`id_product`
)pc ON pc.id_product=prd.`id_product`
INNER JOIN tb_scan_return sc ON sc.`id_scan_return`=scd.`id_scan_return`
INNER JOIN tb_return_note rn ON rn.`id_return_note`=sc.`id_return_note`
LEFT JOIN
(
    SELECT st.`id_return_note`,GROUP_CONCAT(DISTINCT CONCAT(c.comp_number,' - ',c.comp_name) ORDER BY c.`comp_number` ASC SEPARATOR '\n') AS store
    FROM `tb_return_note_store` st
    INNER JOIN tb_m_comp c ON c.id_comp=st.id_comp
    GROUP BY st.`id_return_note`
)st_list ON st_list.id_return_note=rn.id_return_note
WHERE DATE(rn.`date_created`)>='" & date_start & "' AND DATE(rn.`date_created`)<='" & date_until & "'"

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCListProduct.DataSource = dt
        GVListProduct.BestFitColumns()
    End Sub

    Private Sub BPrintScan_Click(sender As Object, e As EventArgs) Handles BPrintScan.Click
        If GVListProduct.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "scan_list.xlsx"
            exportToXLS(path, "scan_list", GCListProduct)
            Cursor = Cursors.Default
        End If
    End Sub

    Sub exportToXLS(ByVal path_par As String, ByVal sheet_name_par As String, ByVal gc_par As DevExpress.XtraGrid.GridControl)
        Cursor = Cursors.WaitCursor
        Dim path As String = path_par

        ' Customize export options 
        CType(gc_par.MainView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsPrint.PrintHeader = True
        Dim advOptions As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
        advOptions.AllowSortingAndFiltering = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowGridLines = DevExpress.Utils.DefaultBoolean.False
        advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False
        advOptions.SheetName = sheet_name_par
        advOptions.ExportType = DevExpress.Export.ExportType.DataAware

        Try
            gc_par.ExportToXlsx(path, advOptions)
            Process.Start(path)
            ' Open the created XLSX file with the default application. 
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub
End Class