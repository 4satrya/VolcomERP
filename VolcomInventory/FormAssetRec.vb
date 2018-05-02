Public Class FormAssetRec
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"
    '
    Sub check_but()
        If GVRecList.RowCount > 0 Then
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

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        load_rec()
    End Sub

    Sub load_rec()
        Dim where_string As String = ""
        If LEPil.EditValue.ToString = "1" Then
            'by PO date
            where_string = " WHERE rec.asset_rec_date >='" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND rec.asset_rec_date <='" & Date.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
        ElseIf LEPil.EditValue.ToString = "2" Then
            'by created date
            where_string = " WHERE rec.created_date >='" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND rec.created_date <='" & Date.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
        ElseIf LEPil.EditValue.ToString = "3" Then
            'by last update date
            where_string = " WHERE rec.last_upd_date >='" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND rec.last_upd_date <='" & Date.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
        End If
        '
        Dim query As String = "SELECT rec.*,po.`comp_name`,po.`asset_po_no`,det.total_qty,det.total,sts.`report_status`,emp_last.employee_name AS emp_created,emp_cre.employee_name AS emp_last_upd FROM tb_a_asset_rec rec
                                LEFT JOIN tb_m_user usr_cre ON usr_cre.id_user=rec.id_user_created
                                LEFT JOIN tb_m_employee emp_cre ON emp_cre.id_employee=usr_cre.id_employee
                                LEFT JOIN tb_m_user usr_last ON usr_last.id_user=rec.id_user_last_upd
                                LEFT JOIN tb_m_employee emp_last ON emp_last.id_employee=usr_last.id_employee
                                INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=rec.id_report_status
                                INNER JOIN tb_a_asset_po po ON po.`id_asset_po`=rec.`id_asset_po`
                                LEFT JOIN (
                                SELECT det.`id_asset_rec`,SUM(det.qty_rec) AS total_qty , SUM(det.`qty_rec`*det.`value_rec`) AS total FROM tb_a_asset_rec_det det
                                GROUP BY det.`id_asset_rec`
                                ) det ON det.id_asset_rec=rec.`id_asset_rec`
                                " & where_string
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRecList.DataSource = data
        GVRecList.BestFitColumns()
        check_but()
    End Sub

    Private Sub FormAssetRec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEEnd.EditValue = Now
        '
        load_pil()
        load_rec()
    End Sub
    Sub load_pil()
        Dim query As String = "SELECT '1' id_pil,'By Receiving Date' as pil_name
                                UNION
                               SELECT '2' id_pil,'By Created Date' as pil_name
                                UNION
                               SELECT '3' id_pil,'By Last Update Date' as pil_name"
        viewLookupQuery(LEPil, query, 2, "pil_name", "id_pil")
    End Sub

    Private Sub FormAssetRec_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_but()
    End Sub

    Private Sub FormAssetRec_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class