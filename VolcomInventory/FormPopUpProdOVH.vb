Public Class FormPopUpProdOVH
    Public id_prod_demand_design As String = "-1"
    Public id_wo As String = "-1"
    Public id_ovh_price As String = "-1"
    Private Sub FormPopUpProdOVH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RCIMainVendor.ValueChecked = Convert.ToSByte(1)
        RCIMainVendor.ValueUnchecked = Convert.ToSByte(2)
        '
        load_wo()
    End Sub

    Sub load_wo()
        Dim query As String = "SELECT ovhp.id_ovh_price,cc.id_comp_contact,comp.comp_name,ovh.id_ovh,ovh.overhead_code AS `code`,ovh.overhead AS `name`,cur.id_currency,cur.currency,uom.uom,ovhp.ovh_price AS price_ori,ovhp.ovh_price AS price,ovhp.ovh_price_name,cast_tinyint('2') as is_ovh_main,'1' as kurs "
        query += " FROM tb_m_ovh_price ovhp"
        query += " INNER JOIN tb_m_ovh ovh On ovh.id_ovh=ovhp.id_ovh"
        query += " INNER JOIN tb_m_comp_contact cc On cc.id_comp_contact=ovhp.id_comp_contact"
        query += " INNER JOIN tb_m_comp comp On comp.id_comp=cc.id_comp"
        query += " INNER JOIN tb_lookup_currency cur On cur.id_currency=ovhp.id_currency"
        query += " INNER JOIN tb_m_uom uom ON uom.id_uom=ovh.id_uom"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOVH.DataSource = data
        If data.Rows.Count > 0 Then
            BSaveOvh.Enabled = True
        Else
            BSaveOvh.Enabled = False
        End If
    End Sub

    Private Sub BCancelOvh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelOvh.Click
        Close()
    End Sub

    Private Sub FormPopUpProdOVH_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSaveOvh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSaveOvh.Click
        FormProductionWO.view_list_purchase()
        FormProductionWO.id_ovh_price = GVOVH.GetFocusedRowCellValue("id_ovh_price").ToString
        FormProductionWO.TEWO.Text = GVOVH.GetFocusedRowCellValue("name").ToString
        FormProductionWO.TEWOCode.Text = GVOVH.GetFocusedRowCellValue("code").ToString
        FormProductionWO.TECompCode.Text = get_company_x(get_id_company(GVOVH.GetFocusedRowCellValue("id_comp_contact").ToString), "2")
        FormProductionWO.TECompName.Text = get_company_x(get_id_company(GVOVH.GetFocusedRowCellValue("id_comp_contact").ToString), "1")
        FormProductionWO.MECompAddress.Text = get_company_x(get_id_company(GVOVH.GetFocusedRowCellValue("id_comp_contact").ToString), "3")
        FormProductionWO.TECompAttn.Text = get_company_contact_x(GVOVH.GetFocusedRowCellValue("id_comp_contact").ToString, "1")
        FormProductionWO.TEKurs.EditValue = GVOVH.GetFocusedRowCellValue("kurs")
        FormProductionWO.LECurrency.EditValue = Nothing
        FormProductionWO.LECurrency.ItemIndex = FormProductionWO.LECurrency.Properties.GetDataSourceRowIndex("id_currency", GVOVH.GetFocusedRowCellValue("id_currency").ToString)

        If GVOVH.GetFocusedRowCellValue("is_ovh_main").ToString = "1" Then
            FormProductionWO.CheckEditMainVendor.Checked = True
        Else
            FormProductionWO.CheckEditMainVendor.Checked = False
        End If

        For i As Integer = 0 To FormProductionWO.GVListPurchase.RowCount - 1
            Try
                Dim qty, price, subtotal As Decimal
                qty = Decimal.Parse(FormProductionWO.GVListPurchase.GetRowCellValue(i, "prod_order_qty").ToString)
                price = Decimal.Parse(GVOVH.GetFocusedRowCellValue("price_ori").ToString)
                subtotal = qty * price
                FormProductionWO.GVListPurchase.SetRowCellValue(i, "estimate_cost", price)
                FormProductionWO.GVListPurchase.SetRowCellValue(i, "total_cost", subtotal)
            Catch ex As Exception
            End Try
        Next
        FormProductionWO.GCListPurchase.Refresh()
        FormProductionWO.calculate()
        Close()
    End Sub
    Sub view_ovh_only_bom(ByVal id_pd_design As String)
        Try
            Dim query As String
            'call ovh per bom only
            query = "CALL view_ovh_design('" & id_pd_design & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCOVH.DataSource = data
            If data.Rows.Count > 0 Then
                BSaveOvh.Enabled = True
            Else
                BSaveOvh.Enabled = False
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Private Sub CEBOM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CEBOM.CheckedChanged
        If CEBOM.Checked = True Then
            view_ovh_only_bom(id_prod_demand_design)
        Else
            load_wo()
        End If
    End Sub
End Class