Public Class FormInbound3PL
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
    End Sub

    Sub load_3pl()
        Dim q As String = "SELECT 0 AS id_comp,'ALL' AS comp_number,'ALL' AS comp_name
UNION ALL
SELECT c.id_comp,c.comp_number,c.comp_name
FROM tb_3pl_rate rate
INNER JOIN tb_lookup_del_type del ON del.id_del_type=rate.id_del_type AND del.is_able_inbound=1
INNER JOIN tb_m_comp c ON c.id_comp=rate.id_comp
WHERE rate.id_type='2' AND rate.is_active='1'
GROUP BY rate.id_comp"
        viewSearchLookupQuery(SLEVendor, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub FormInbound3PL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_3pl()

        DEStart.EditValue = Now
        DEUntil.EditValue = Now
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_view()
    End Sub

    Sub load_view()
        Dim date_start As String = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_until As String = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim q_where As String = ""

        If Not SLEVendor.EditValue.ToString = "0" Then
            q_where = "  AND awb.id_comp='" & SLEVendor.EditValue.ToString & "' "
        End If

        Dim q As String = "SELECT awb.`id_inbound_awb`,awb.`id_comp`,c.`comp_name`,emp.`employee_name`,del.`del_type`,awb.`awb_number`,awb.`created_date`,st_list.store AS store_list
,koli_list.total_koli,koli_list.total_berat_dimensi,koli_list.total_berat
FROM tb_inbound_awb awb
INNER JOIN tb_m_comp c ON c.`id_comp`=awb.`id_comp`
INNER JOIN tb_lookup_del_type del ON del.`id_del_type`=awb.`id_del_type`
INNER JOIN tb_m_user usr ON usr.id_user=awb.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
LEFT JOIN
(
    SELECT st.`id_inbound_awb`,GROUP_CONCAT(DISTINCT CONCAT(c.comp_number,' - ',c.comp_name) ORDER BY c.`comp_number` ASC SEPARATOR '\n') AS store
    FROM tb_inbound_store st
    INNER JOIN tb_m_comp c ON c.id_comp=st.id_comp
    GROUP BY st.`id_inbound_awb`
)st_list ON st_list.id_inbound_awb=awb.id_inbound_awb
LEFT JOIN
(
    SELECT id_inbound_awb,COUNT(id_inbound_koli) AS total_koli, SUM(berat_dimensi) AS total_berat_dimensi,SUM(berat) AS total_berat
    FROM tb_inbound_koli
    GROUP BY id_inbound_awb
)koli_list ON koli_list.id_inbound_awb=awb.id_inbound_awb
WHERE DATE(awb.`created_date`)>='" & date_start & "' AND DATE(awb.`created_date`)<='" & date_until & "' " & q_where & "
ORDER BY awb.id_inbound_awb DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCAwb.DataSource = dt
        GVAwb.BestFitColumns()
    End Sub

    Private Sub FormInbound3PL_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVAwb_DoubleClick(sender As Object, e As EventArgs) Handles GVAwb.DoubleClick
        FormInboundAWB.id_awb_inbound = GVAwb.GetFocusedRowCellValue("id_inbound_awb").ToString
        FormInboundAWB.ShowDialog()
    End Sub

    Private Sub BPrintSummary_Click(sender As Object, e As EventArgs) Handles BPrintSummary.Click
        If Not SLEVendor.EditValue.ToString = "0" Then
            Dim Report As New ReportInboundAWB()

            Dim date_start As String = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim date_until As String = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

            Dim q As String = "SELECT awb.`id_inbound_awb`,awb.created_date,awb.`awb_number`,awb.`id_comp`,koli.`panjang`,koli.`lebar`,koli.`tinggi`,koli.`berat`,koli.`berat_dimensi`,IF(koli.`berat`>koli.`berat_dimensi`,koli.`berat`,koli.`berat_dimensi`) AS final_berat
,st_list.store AS store_list
FROM tb_inbound_koli koli
INNER JOIN tb_inbound_awb awb ON awb.`id_inbound_awb`=koli.`id_inbound_awb`
LEFT JOIN
(
    SELECT st.`id_inbound_awb`,GROUP_CONCAT(DISTINCT CONCAT(c.comp_number,' - ',c.comp_name) ORDER BY c.`comp_number` ASC SEPARATOR '\n') AS store
    FROM tb_inbound_store st
    INNER JOIN tb_m_comp c ON c.id_comp=st.id_comp
    GROUP BY st.`id_inbound_awb`
)st_list ON st_list.id_inbound_awb=awb.id_inbound_awb
WHERE DATE(awb.`created_date`)>='" & date_start & "' AND DATE(awb.`created_date`)<='" & date_until & "' 
AND awb.`id_comp`='" & SLEVendor.EditValue.ToString & "' GROUP BY koli.`id_inbound_koli`"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            Report.data_awb = dt

            q = "SELECT DATE_FORMAT('" & date_start & "','%d %M %Y') AS date_start,DATE_FORMAT('" & date_until & "','%d %M %Y') AS date_until,DATE_FORMAT(NOW(),'%d %M %Y') AS date_cur,c.comp_name
,emp_ppr.employee_name AS prepare_by_name,emp_ppr.employee_position AS prepare_by_position
,emp_mngr.employee_name AS wh_manager_name,emp_mngr.employee_position AS wh_manager_position
FROM tb_m_comp c 
INNER JOIN tb_m_departement dep ON dep.id_departement=6
INNER JOIN tb_m_user usr_mngr ON usr_mngr.id_user=dep.id_user_head
INNER JOIN tb_m_employee emp_mngr ON emp_mngr.id_employee=usr_mngr.id_employee
INNER JOIN tb_m_user usr_ppr ON usr_ppr.id_user='" & id_user & "'
INNER JOIN tb_m_employee emp_ppr ON emp_ppr.id_employee=usr_ppr.id_employee
WHERE c.id_comp='" & SLEVendor.EditValue.ToString & "'"
            dt = execute_query(q, -1, True, "", "", "", "")
            Report.DataSource = dt

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        Else
            warningCustom("Choose 3PL first")
        End If
    End Sub
End Class