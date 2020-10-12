Public Class FormVerifyECOP
    Private Sub FormVerifyECOP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewDesign()
        Dim query As String = ""
        query = "CALL view_design_order(TRUE)"
        viewSearchLookupQuery(SLEDesign, query, "id_design", "design_display_name", "id_design")
    End Sub

    Sub view_pps()
        Dim q_where As String = ""

        If Not SLEDesign.EditValue.ToString = "0" Then
            q_where = " AND pps.id_design='" & SLEDesign.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT 'no' AS is_check,pps.id_design_ecop_pps,pps.number,dsg.design_code,dsg.design_display_name,SUM(IF(id_currency=1,ppsd.`before_kurs`,ppsd.`before_kurs`*ppsd.`kurs`)) AS total_ecop_purc,SUM(ppsd.`additional`) AS total_additional_purc
,(fg_lp.`target_price`/fg_lp.`mark_up`) AS target_cost
,cop_sample.total_sample,cop_sample.total_additional_sample
FROM `tb_design_ecop_pps_det` ppsd
INNER JOIN `tb_design_ecop_pps` pps ON pps.`id_design_ecop_pps`=ppsd.`id_design_ecop_pps`
LEFT JOIN(
	SELECT cop.`id_design`,SUM(IF(cop.id_currency=1,cop.before_kurs,(cop.before_kurs*cop.kurs))) AS total_sample,SUM(cop.`additional`) AS total_additional_sample
	FROM tb_m_design_cop cop
	WHERE cop.is_active=1 AND cop.`is_production_dept`=2
	GROUP BY cop.id_design
) cop_sample ON cop_sample.id_design = pps.id_design
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pps.`id_design`
INNER JOIN tb_fg_line_plan fg_lp ON fg_lp.`id_fg_line_plan`=dsg.`id_fg_line_plan`
WHERE pps.need_verify=1 AND pps.verify_status=0 " & q_where
        Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEcopPPS.DataSource = dt
        GVEcopPPS.BestFitColumns()
    End Sub

    Private Sub BSearchProposeECOP_Click(sender As Object, e As EventArgs) Handles BSearchProposeECOP.Click
        view_pps()
    End Sub

    Private Sub FormVerifyECOP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDesign()
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVEcopPPS.RowCount > 0 Then
            Dim cek As String = CheckEditSelAll.EditValue.ToString
            For i As Integer = 0 To ((GVEcopPPS.RowCount - 1) - GetGroupRowCount(GVEcopPPS))
                If cek Then
                    GVEcopPPS.SetRowCellValue(i, "is_check", "yes")
                Else
                    GVEcopPPS.SetRowCellValue(i, "is_check", "no")
                End If
            Next
        End If
    End Sub
End Class