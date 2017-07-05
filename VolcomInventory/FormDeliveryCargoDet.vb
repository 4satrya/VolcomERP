Public Class FormDeliveryCargoDet
    Public id_awbill As String = "-1"

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormDeliveryCargoDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormDeliveryCargoDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_awbill = "-1" Then 'new
            TENumber.Text = header_number_general("1")

        Else

        End If
    End Sub
    Sub load_expedition()
        If SLEDestination.EditValue.ToString = "" Or SLEDestination.EditValue.ToString = "0" Then

        Else
            Dim query As String = "SELECT * FROM tb_m_"

            SLECargo.EditValue = Nothing
            viewSearchLookupQuery(SLECargo, query, "id_cargo", "cargo", "id_cargo")

            'calculate_amount()
        End If
    End Sub
    Sub load_dest_code()
        Dim query As String = "SELECT * FROM tb_m_cargo_rate"
        viewSearchLookupQuery(SLEDestination, query, "id_cargo_rate", "cargo_code", "id_cargo_rate")
    End Sub
End Class