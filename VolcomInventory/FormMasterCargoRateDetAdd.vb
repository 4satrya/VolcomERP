Public Class FormMasterCargoRateDetAdd

    Private Sub FormMasterCargoRateDetAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEAreaCode.Text = FormMasterCargoRate.GVCargoRate.GetFocusedRowCellValue("cargo_code").ToString
        TEArea.Text = FormMasterCargoRate.GVCargoRate.GetFocusedRowCellValue("destination").ToString
        TECargoName.Text = FormMasterCargoRateDet.GVCargo.GetFocusedRowCellValue("comp_name").ToString

        TERate.EditValue = 0
        TEMinWeight.EditValue = 0
        TELeadTime.EditValue = 0
    End Sub

    Private Sub FormMasterCargoRateDetAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Dispose()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If FormMasterCargoRateDet.XTCInOut.SelectedTabPageIndex = 0 Then 'inbound
            Dim query_ins As String = ""
            query_ins = "Update tb_m_cargo_rate_det SET is_default='2' WHERE id_cargo_rate = '" & FormMasterCargoRate.GVCargoRate.GetFocusedRowCellValue("id_cargo_rate").ToString & "' AND id_cargo='" & FormMasterCargoRateDet.GVCargo.GetFocusedRowCellValue("id_comp").ToString & "' AND id_type=1;INSERT INTO tb_m_cargo_rate_det(is_default,id_type,id_cargo_rate,id_cargo,cargo_rate,cargo_min_weight,cargo_lead_time,cargo_datetime) VALUES(1,1,'" & FormMasterCargoRate.GVCargoRate.GetFocusedRowCellValue("id_cargo_rate").ToString & "','" & FormMasterCargoRateDet.GVCargo.GetFocusedRowCellValue("id_comp").ToString & "','" & decimalSQL(TERate.EditValue.ToString) & "','" & decimalSQL(TEMinWeight.EditValue.ToString) & "','" & decimalSQL(TELeadTime.EditValue.ToString) & "',NOW())"
            execute_non_query(query_ins, True, "", "", "", "")
            FormMasterCargoRateDet.load_inbound()
            Close()
        Else 'outbound
            Dim query_ins As String = ""
            query_ins = "Update tb_m_cargo_rate_det SET is_default='2' WHERE id_cargo_rate = '" & FormMasterCargoRate.GVCargoRate.GetFocusedRowCellValue("id_cargo_rate").ToString & "' AND id_cargo='" & FormMasterCargoRateDet.GVCargo.GetFocusedRowCellValue("id_comp").ToString & "' AND id_type=2;INSERT INTO tb_m_cargo_rate_det(is_default,id_type,id_cargo_rate,id_cargo,cargo_rate,cargo_min_weight,cargo_lead_time,cargo_datetime) VALUES(1,2,'" & FormMasterCargoRate.GVCargoRate.GetFocusedRowCellValue("id_cargo_rate").ToString & "','" & FormMasterCargoRateDet.GVCargo.GetFocusedRowCellValue("id_comp").ToString & "','" & decimalSQL(TERate.EditValue.ToString) & "','" & decimalSQL(TEMinWeight.EditValue.ToString) & "','" & decimalSQL(TELeadTime.EditValue.ToString) & "',NOW())"
            execute_non_query(query_ins, True, "", "", "", "")
            FormMasterCargoRateDet.load_outbound()
            Close()
        End If
        Dim query As String = ""
    End Sub
End Class