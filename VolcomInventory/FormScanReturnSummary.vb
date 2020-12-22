Public Class FormScanReturnSummary
    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_view_wh()
    End Sub

    Sub load_3pl()
        Dim q As String = "SELECT c.id_comp,c.comp_number,c.comp_name
FROM tb_3pl_rate rate
INNER JOIN tb_lookup_del_type del ON del.id_del_type=rate.id_del_type AND del.is_able_inbound=1
INNER JOIN tb_m_comp c ON c.id_comp=rate.id_comp
WHERE rate.id_type='2' AND rate.is_active='1'
GROUP BY rate.id_comp"
        viewSearchLookupQuery(SLEVendor, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_emp()
        Dim q As String = "SELECT id_employee,employee_code,employee_name FROM tb_m_employee WHERE id_employee_status='1' AND id_departement='6'"
        viewSearchLookupQuery(SLEEmp, q, "id_employee", "employee_name", "id_employee")
    End Sub

    Sub load_view_wh()
        Dim date_start As String = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim q As String = "SELECT rn.id_return_note,emp.employee_name,IF(rn.id_type=1,'WH Inbound','3PL') AS `type`,st_list.store AS store_list,rn.id_inbound_awb,rn.label_number,rn.date_created,rn.number_return_note,rn.qty AS qty_return_note,rn.date_return_note,rn.date_created
,IFNULL(bap.qty_bap,0) AS qty_bap, bap.bap_number
,IFNULL(sc.qty_scan,0) AS qty_scan
,IF(rn.qty - IFNULL(sc.qty_scan,0)-IFNULL(bap.qty_bap,0)=0,'Ok','Not Balance') as status
FROM `tb_return_note` rn
LEFT JOIN
(
    SELECT st.`id_return_note`,GROUP_CONCAT(DISTINCT CONCAT(c.comp_number,' - ',c.comp_name) ORDER BY c.`comp_number` ASC SEPARATOR '\n') AS store
    FROM `tb_return_note_store` st
    INNER JOIN tb_m_comp c ON c.id_comp=st.id_comp
    GROUP BY st.`id_return_note`
)st_list ON st_list.id_return_note=rn.id_return_note
LEFT JOIN 
(
	SELECT bapd.`id_return_note`,SUM(bapd.`qty`*IF(bapd.`id_type`=1,1,-1)) AS qty_bap ,GROUP_CONCAT(DISTINCT(bap.`bap_number`) ORDER BY bap.`bap_number` SEPARATOR '\n') AS bap_number
	FROM tb_scan_return_bap_det bapd 
	INNER JOIN tb_scan_return_bap bap ON bap.`id_scan_return_bap`=bapd.`id_scan_return_bap`
	GROUP BY bapd.`id_return_note`
)bap ON bap.id_return_note=rn.`id_return_note`
LEFT JOIN 
(
    SELECT sc.`id_return_note`,COUNT(scd.`id_scan_return_det`) AS qty_scan
    FROM tb_scan_return_det scd
    INNER JOIN tb_scan_return sc ON sc.`id_scan_return`=scd.`id_scan_return`
    WHERE sc.is_void!=1
    GROUP BY sc.`id_return_note`
)sc ON sc.id_return_note=rn.id_return_note
INNER JOIN tb_m_employee emp ON emp.id_employee=rn.id_emp_driver
WHERE rn.id_type=1 AND rn.id_emp_driver='" & SLEEmp.EditValue.ToString & "' AND DATE(rn.`date_created`)>='" & date_start & "' AND DATE(rn.`date_created`)<='" & date_start & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCLocal.DataSource = dt
        GVLocal.BestFitColumns()
    End Sub

    Sub load_view_3pl()
        Dim date_start As String = Date.Parse(DEStart3pl.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim q As String = "SELECT rn.id_return_note,IF(rn.id_type=1,'WH Inbound','3PL') AS `type`,st_list.store AS store_list
,rn.id_inbound_awb,rn.label_number,rn.date_created
,rn.number_return_note,rn.qty AS qty_return_note,rn.date_return_note,rn.date_created
,IFNULL(bap.qty_bap,0) AS qty_bap, bap.bap_number
,IFNULL(sc.qty_scan,0) AS qty_scan
,IF(rn.qty - IFNULL(sc.qty_scan,0)-IFNULL(bap.qty_bap,0)=0,'Ok','Not Balance') AS `status`
,awb.`awb_number`
,c.comp_name
FROM `tb_return_note` rn
INNER JOIN `tb_inbound_awb` awb ON awb.`id_inbound_awb`=rn.`id_inbound_awb`
INNER JOIN tb_m_comp c ON c.id_comp=awb.id_comp
LEFT JOIN
(
    SELECT st.`id_return_note`,GROUP_CONCAT(DISTINCT CONCAT(c.comp_number,' - ',c.comp_name) ORDER BY c.`comp_number` ASC SEPARATOR '\n') AS store
    FROM `tb_return_note_store` st
    INNER JOIN tb_m_comp c ON c.id_comp=st.id_comp
    GROUP BY st.`id_return_note`
)st_list ON st_list.id_return_note=rn.id_return_note
LEFT JOIN 
(
	SELECT bapd.`id_return_note`,SUM(bapd.`qty`*IF(bapd.`id_type`=1,1,-1)) AS qty_bap ,GROUP_CONCAT(DISTINCT(bap.`bap_number`) ORDER BY bap.`bap_number` SEPARATOR '\n') AS bap_number
	FROM tb_scan_return_bap_det bapd 
	INNER JOIN tb_scan_return_bap bap ON bap.`id_scan_return_bap`=bapd.`id_scan_return_bap`
	GROUP BY bapd.`id_return_note`
)bap ON bap.id_return_note=rn.`id_return_note`
LEFT JOIN 
(
    SELECT sc.`id_return_note`,COUNT(scd.`id_scan_return_det`) AS qty_scan
    FROM tb_scan_return_det scd
    INNER JOIN tb_scan_return sc ON sc.`id_scan_return`=scd.`id_scan_return`
    WHERE sc.is_void!=1
    GROUP BY sc.`id_return_note`
)sc ON sc.id_return_note=rn.id_return_note
WHERE rn.id_type=2 AND awb.id_comp='" & SLEVendor.EditValue.ToString & "' AND DATE(rn.`date_created`)>='" & date_start & "' AND DATE(rn.`date_created`)<='" & date_start & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GC3PL.DataSource = dt
        GV3PL.BestFitColumns()
    End Sub

    Private Sub FormScanReturnSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_emp()
        load_3pl()
        DEStart.EditValue = Now
        DEStart3pl.EditValue = Now
    End Sub

    Private Sub BPrintSummary_Click(sender As Object, e As EventArgs) Handles BPrintSummary.Click
        Dim is_ok As Boolean = True
        For i As Integer = 0 To GVLocal.RowCount - 1
            If Not GVLocal.GetRowCellValue(i, "status").ToString = "Ok" Then
                warningCustom("Qty Return Note tidak sama dengan qty scan + qty BAP")
                is_ok = False
                Exit For
            End If
        Next
        If is_ok Then
            'warning lock
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("BAP, scan return, dan return note akan terkunci. Lanjutkan ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                'lock
                Dim q As String = ""
                'lock bap
                For i = 0 To GVLocal.RowCount - 1
                    q = "UPDATE tb_scan_return_bap SET is_lock=1 WHERE id_scan_return_bap IN (SELECT id_scan_return_bap FROM tb_scan_return_bap_det WHERE id_return_note='" & GVLocal.GetRowCellValue(i, "id_return_note").ToString & "')"
                    execute_non_query(q, True, "", "", "", "")
                Next

                'lock scan return
                For i = 0 To GVLocal.RowCount - 1
                    q = "UPDATE tb_scan_return SET is_lock=1 WHERE id_return_note='" & GVLocal.GetRowCellValue(i, "id_return_note").ToString & "'"
                    execute_non_query(q, True, "", "", "", "")
                Next

                'lock return note
                For i = 0 To GVLocal.RowCount - 1
                    q = "UPDATE tb_return_note SET is_lock=1 WHERE id_return_note='" & GVLocal.GetRowCellValue(i, "id_return_note").ToString & "'"
                    execute_non_query(q, True, "", "", "", "")
                Next

                'print
                Dim Report As New ReportScanReturnLocal()
                q = "SELECT '" & Date.Parse(DEStart.EditValue.ToString).ToString("dd MMMM yyyy") & "' AS created_date
,DATE_FORMAT(NOW(),'%d %M %Y') AS date_cur
,emp_ppr.employee_name AS prepare_by_name,emp_ppr.employee_position AS prepare_by_position
,emp_mngr.employee_name AS wh_manager_name,emp_mngr.employee_position AS wh_manager_position
,emp.employee_name AS deliver_staff_name,emp.employee_position AS deliver_staff_position
,'" & Decimal.Parse(GVLocal.Columns("qty_scan").SummaryItem.SummaryValue.ToString).ToString("N0") & "' AS tot_qty_scan
,'" & Decimal.Parse(GVLocal.Columns("qty_bap").SummaryItem.SummaryValue.ToString).ToString("N0") & "' AS tot_qty_bap
,'" & Decimal.Parse(GVLocal.Columns("qty_return_note").SummaryItem.SummaryValue.ToString).ToString("N0") & "' AS tot_qty_return_note
FROM tb_m_employee emp 
INNER JOIN tb_m_departement dep ON dep.id_departement=6
INNER JOIN tb_m_user usr_mngr ON usr_mngr.id_user=dep.id_user_head
INNER JOIN tb_m_employee emp_mngr ON emp_mngr.id_employee=usr_mngr.id_employee
INNER JOIN tb_m_user usr_ppr ON usr_ppr.id_user='" & id_user & "'
INNER JOIN tb_m_employee emp_ppr ON emp_ppr.id_employee=usr_ppr.id_employee
WHERE emp.id_employee='" & SLEEmp.EditValue.ToString & "'"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                Report.DataSource = dt
                '
                Report.data_det = GCLocal.DataSource
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreviewDialog()
            End If
        End If
    End Sub

    Private Sub BView3PL_Click(sender As Object, e As EventArgs) Handles BView3PL.Click
        load_view_3pl()
    End Sub

    Private Sub BPrint3PL_Click(sender As Object, e As EventArgs) Handles BPrint3PL.Click
        Dim is_ok As Boolean = True
        For i As Integer = 0 To GV3PL.RowCount - 1
            If Not GV3PL.GetRowCellValue(i, "status").ToString = "Ok" Then
                warningCustom("Qty Return Note tidak sama dengan qty scan + qty BAP")
                is_ok = False
                Exit For
            End If
        Next
        If is_ok Then
            'warning lock
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("BAP, scan return, dan return note akan terkunci. Lanjutkan ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                'lock
                Dim q As String = ""
                'lock bap
                For i = 0 To GV3PL.RowCount - 1
                    q = "UPDATE tb_scan_return_bap SET is_lock=1 WHERE id_scan_return_bap IN (SELECT id_scan_return_bap FROM tb_scan_return_bap_det WHERE id_return_note='" & GV3PL.GetRowCellValue(i, "id_return_note").ToString & "')"
                    execute_non_query(q, True, "", "", "", "")
                Next

                'lock scan return
                For i = 0 To GV3PL.RowCount - 1
                    q = "UPDATE tb_scan_return SET is_lock=1 WHERE id_return_note='" & GV3PL.GetRowCellValue(i, "id_return_note").ToString & "'"
                    execute_non_query(q, True, "", "", "", "")
                Next

                'lock return note
                For i = 0 To GV3PL.RowCount - 1
                    q = "UPDATE tb_return_note SET is_lock=1 WHERE id_return_note='" & GV3PL.GetRowCellValue(i, "id_return_note").ToString & "'"
                    execute_non_query(q, True, "", "", "", "")
                Next

                'print
                Dim Report As New ReportScanReturn3PL()
                q = "SELECT c.comp_name,'" & Date.Parse(DEStart3pl.EditValue.ToString).ToString("dd MMMM yyyy") & "' AS created_date
,DATE_FORMAT(NOW(),'%d %M %Y') AS date_cur
,emp_ppr.employee_name AS prepare_by_name,emp_ppr.employee_position AS prepare_by_position
,emp_mngr.employee_name AS wh_manager_name,emp_mngr.employee_position AS wh_manager_position
,'" & Decimal.Parse(GV3PL.Columns("qty_scan").SummaryItem.SummaryValue.ToString).ToString("N0") & "' AS tot_qty_scan
,'" & Decimal.Parse(GV3PL.Columns("qty_bap").SummaryItem.SummaryValue.ToString).ToString("N0") & "' AS tot_qty_bap
,'" & Decimal.Parse(GV3PL.Columns("qty_return_note").SummaryItem.SummaryValue.ToString).ToString("N0") & "' AS tot_qty_return_note
FROM tb_m_comp c 
INNER JOIN tb_m_departement dep ON dep.id_departement=6
INNER JOIN tb_m_user usr_mngr ON usr_mngr.id_user=dep.id_user_head
INNER JOIN tb_m_employee emp_mngr ON emp_mngr.id_employee=usr_mngr.id_employee
INNER JOIN tb_m_user usr_ppr ON usr_ppr.id_user='" & id_user & "'
INNER JOIN tb_m_employee emp_ppr ON emp_ppr.id_employee=usr_ppr.id_employee
WHERE c.id_comp='" & SLEVendor.EditValue.ToString & "'"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                Report.DataSource = dt
                '
                '                q = "SELECT awb.`id_inbound_awb`,awb.`awb_number`,awb.`id_comp`,koli.`panjang`,koli.`lebar`,koli.`tinggi`,koli.`berat`,koli.`berat_dimensi`,IF(koli.`berat`>koli.`berat_dimensi`,koli.`berat`,koli.`berat_dimensi`) AS final_berat
                'FROM tb_inbound_koli koli
                'INNER JOIN tb_inbound_awb awb ON awb.`id_inbound_awb`=koli.`id_inbound_awb`
                'INNER JOIN tb_return_note rn ON rn.`id_inbound_awb`=awb.`id_inbound_awb`
                'WHERE rn.`date_created`='" & Date.Parse(DEStart3pl.EditValue.ToString).ToString("yyyy-MM-dd") & "' 
                'AND awb.`id_comp`='" & SLEVendor.EditValue.ToString & "'
                'GROUP BY koli.`id_inbound_koli`"
                '                dt = execute_query(q, -1, True, "", "", "", "")
                '                Report.data_awb = dt
                '
                Report.data_det = GC3PL.DataSource
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreviewDialog()
            End If
        End If
    End Sub
End Class