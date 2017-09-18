Public Class FormMasterCargoRateDet
    Public id_cargo_rate As String = "-1"

    Private Sub FormMasterCargoRateDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_cargo
    End Sub

    Sub load_cargo()
        Dim query As String = "SELECT * FROM tb_m_comp WHERE id_comp_cat='7'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCargo.DataSource = data

        If data.Rows.Count > 0 Then
            load_inbound()
            load_outbound()
        End If
    End Sub

    Sub load_inbound()
        Dim query As String = "SELECT cd.* FROM tb_m_cargo_rate_det cd WHERE id_type='1' AND id_cargo='" & GVCargo.GetFocusedRowCellValue("id_comp").ToString & "' AND id_cargo_rate='" & id_cargo_rate & "' ORDER BY cd.cargo_datetime DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCInbound.DataSource = data
    End Sub

    Sub load_outbound()
        Dim query As String = "SELECT cd.* FROM tb_m_cargo_rate_det cd WHERE id_type='2' AND id_cargo='" & GVCargo.GetFocusedRowCellValue("id_comp").ToString & "' AND id_cargo_rate='" & id_cargo_rate & "' ORDER BY cd.cargo_datetime DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOutbound.DataSource = data
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormMasterCargoRateDetAdd.ShowDialog()
    End Sub

    Private Sub GVCargo_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVCargo.FocusedRowChanged
        load_inbound()
        load_outbound()
    End Sub
End Class