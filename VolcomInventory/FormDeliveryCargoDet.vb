Public Class FormDeliveryCargoDet
    Public id_awbill As String = "-1"

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormDeliveryCargoDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_destination()
        Dim query As String = "SELECT * FROM tb_m_cargo_rate"

        SLEDestination.EditValue = Nothing
        viewSearchLookupQuery(SLEDestination, query, "id_cargo_rate", "destination", "id_cargo_rate")
    End Sub

    Private Sub FormDeliveryCargoDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_awbill = "-1" Then 'new
            TENumber.Text = header_number_general("1")
            DEDateCreated.EditValue = Now
            TEDepartement.Text = get_departement_x(id_departement_user, "1")
            '
            BSave.Visible = True
            BMark.Visible = False
            BCancel.Visible = True
            '
            load_destination()
        Else
            BSave.Visible = False
            BMark.Visible = True
            BCancel.Visible = False
        End If
    End Sub

    Sub load_expedition()
        If SLEDestination.EditValue.ToString = "" Or SLEDestination.EditValue.ToString = "0" Then

        Else
            Dim query As String = "SELECT comp.`comp_name`,rd.* FROM tb_m_cargo_rate_det rd
                                    INNER JOIN tb_m_comp comp ON comp.`id_comp`=rd.`id_cargo`
                                    WHERE rd.`id_cargo_rate`='" & SLEDestination.EditValue.ToString & "' 
                                    AND rd.`cargo_datetime` IN (SELECT MAX(cargo_datetime) FROM tb_m_cargo_rate_det GROUP BY id_cargo_rate,id_cargo)"

            SLECargo.EditValue = Nothing
            viewSearchLookupQuery(SLECargo, query, "id_cargo", "cargo", "id_cargo")

            'calculate_amount()
        End If
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click

    End Sub

    Private Sub SLEDestination_EditValueChanged(sender As Object, e As EventArgs) Handles SLEDestination.EditValueChanged
        load_expedition()
    End Sub

    Private Sub BRecStoreNothing_Click(sender As Object, e As EventArgs) Handles BRecStoreNothing.Click

    End Sub
End Class