﻿Public Class FormSalesReportTrackingParam
    Dim id_comp_cat_store As String = "-1"
    Dim id_comp As String = "-1"
    Dim id_store_contact_from As String = "-1"

    Private Sub TxtCodeCompFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query As String = "Select dr.id_wh_drawer, rack.id_wh_rack, Loc.id_wh_locator, cc.id_comp_contact, cc.id_comp, c.npwp, c.comp_number, c.comp_name, c.comp_commission, c.address_primary, c.id_so_type "
            query += " From tb_m_comp_contact cc "
            query += " INNER JOIN tb_m_comp c On c.id_comp=cc.id_comp"
            query += " INNER JOIN tb_m_wh_drawer dr ON dr.id_wh_drawer=c.id_drawer_def"
            query += " INNER JOIN tb_m_wh_rack rack ON rack.id_wh_rack=dr.id_wh_rack"
            query += " INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator=rack.id_wh_locator"
            query += " where cc.is_default=1 And c.id_comp_cat='" + id_comp_cat_store + "' AND c.comp_number='" + addSlashes(TxtCodeCompFrom.Text) + "'"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count <= 0 Then
                stopCustom("Store not found.")
                TxtCodeCompFrom.Focus()
            ElseIf data.Rows.Count > 1 Then
                FormPopUpContact.id_pop_up = "42"
                FormPopUpContact.id_cat = id_comp_cat_store
                FormPopUpContact.GVCompany.ActiveFilterString = "[comp_number]='" + addSlashes(TxtCodeCompFrom.Text) + "'"
                FormPopUpContact.ShowDialog()
            Else
                id_comp = data.Rows(0)("id_comp").ToString
                id_store_contact_from = data.Rows(0)("id_comp_contact").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
                '
            End If
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSalesReportTrackingParam_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class