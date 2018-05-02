Public Class FormAssetPO
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"
    '
    Sub check_but()
        If GVPOList.RowCount > 0 Then
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        Else
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormAssetPO_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_but()
    End Sub

    Private Sub FormAssetPO_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormAssetPO_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormAssetPO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEEnd.EditValue = Now
        '
        load_pil()
        load_po()
    End Sub
    Sub load_po()
        Dim where_string As String = ""
        If LEPil.EditValue.ToString = "1" Then
            'by PO date
            where_string = " WHERE po.asset_po_date >='" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND po.asset_po_date <='" & Date.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
        ElseIf LEPil.EditValue.ToString = "2" Then
            'by created date
            where_string = " WHERE po.created_date >='" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND po.created_date <='" & Date.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
        ElseIf LEPil.EditValue.ToString = "3" Then
            'by last update date
            where_string = " WHERE po.last_upd_date >='" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND po.last_upd_date <='" & Date.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
        End If
        '
        Dim query As String = "SELECT po.*,det.total,(det.total * ((100+po.`vat`)/100)) AS grand_total,term.`term_payment`
                                ,po.created_date,po.last_upd_date,emp_last.employee_name AS emp_created,emp_cre.employee_name AS emp_last_upd,sts.report_status
                                FROM tb_a_asset_po po
                                LEFT JOIN tb_m_user usr_cre ON usr_cre.id_user=po.created_by
                                LEFT JOIN tb_m_employee emp_cre ON emp_cre.id_employee=usr_cre.id_employee
                                LEFT JOIN tb_m_user usr_last ON usr_last.id_user=po.last_upd_by
                                LEFT JOIN tb_m_employee emp_last ON emp_last.id_employee=usr_last.id_employee
                                INNER JOIN `tb_lookup_term_payment` term ON term.`id_term_payment`=po.`id_term_payment`
                                INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=po.id_report_status
                                LEFT JOIN (
                                SELECT det.`id_asset_po`,SUM((det.value-det.disc)*det.qty) AS total FROM tb_a_asset_po_det det
                                GROUP BY det.`id_asset_po`
                                ) det ON det.id_asset_po=po.`id_asset_po`
                                " & where_string
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPOList.DataSource = data
        GVPOList.BestFitColumns()
        check_but()
    End Sub
    Sub load_pil()
        Dim query As String = "SELECT '1' id_pil,'By PO Date' as pil_name
                                UNION
                               SELECT '2' id_pil,'By Created Date' as pil_name
                                UNION
                               SELECT '3' id_pil,'By Last Update Date' as pil_name"
        viewLookupQuery(LEPil, query, 2, "pil_name", "id_pil")
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        load_po()
    End Sub
End Class