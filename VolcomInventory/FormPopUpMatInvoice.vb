Public Class FormPopUpMatInvoice 
    Public id_invoice As String = "-1"
    Public id_pop_up As String = "-1"
    Private Sub FormPopUpMatInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewInv()
    End Sub
    Sub viewInv()
        Dim query As String = "SELECT inv.id_inv_pl_mrs,inv.id_currency,inv.inv_pl_mrs_number,m.design_name,k.prod_order_number,j.prod_order_wo_number, inv.id_comp_contact_to, "
        query += " (f.comp_name) AS comp_name_to, h.report_status, inv.id_report_status,inv.id_prod_order_wo, "
        query += "DATE_FORMAT(inv.inv_pl_mrs_date,'%d %M %Y') AS inv_pl_mrs_date,"
        query += "DATE_FORMAT(DATE_ADD(inv.inv_pl_mrs_date,INTERVAL inv.inv_pl_mrs_top DAY),'%d %M %Y') AS inv_pl_mrs_top , inv.id_report_status "
        query += "FROM tb_inv_pl_mrs inv "
        query += "INNER JOIN tb_m_comp_contact e ON inv.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = inv.id_report_status "
        query += "INNER JOIN tb_prod_order_wo j ON inv.id_prod_order_wo = j.id_prod_order_wo "
        query += "INNER JOIN tb_prod_order k ON j.id_prod_order = k.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design l ON k.id_prod_demand_design = l.id_prod_demand_design "
        query += "INNER JOIN tb_m_design m ON m.id_design = l.id_design "
        query += "ORDER BY inv.id_inv_pl_mrs DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdInvoice.DataSource = data
        If data.Rows.Count > 0 Then
            viewInvDet()
        End If
    End Sub
    Sub viewInvDet()
        Dim query As String = "CALL view_inv_mat('" + GVProdInvoice.GetFocusedRowCellValue("id_inv_pl_mrs").ToString + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        '
        If data.Rows.Count > 0 Then
            BSave.Enabled = True
        Else
            BSave.Enabled = False
        End If
    End Sub

    Private Sub GVProdInvoice_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdInvoice.FocusedRowChanged
        viewInvDet()
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub FormPopUpMatInvoice_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        If id_pop_up = "1" Then 'formmarettinvoicedet
            FormMatInvoiceReturDet.id_invoice = GVProdInvoice.GetFocusedRowCellValue("id_inv_pl_mrs").ToString
            FormMatInvoiceReturDet.id_prod_wo = GVProdInvoice.GetFocusedRowCellValue("id_prod_order_wo").ToString
            FormMatInvoiceReturDet.TEInvNumber.Text = GVProdInvoice.GetFocusedRowCellValue("inv_pl_mrs_number").ToString
            FormMatInvoiceReturDet.TEWONumber.Text = GVProdInvoice.GetFocusedRowCellValue("prod_order_wo_number").ToString
            FormMatInvoiceReturDet.TEPONumber.Text = GVProdInvoice.GetFocusedRowCellValue("prod_order_number").ToString
            FormMatInvoiceReturDet.TEDesign.Text = GVProdInvoice.GetFocusedRowCellValue("design_name").ToString
            FormMatInvoiceReturDet.id_comp_to = GVProdInvoice.GetFocusedRowCellValue("id_comp_contact_to").ToString

            FormMatInvoiceReturDet.TECompCode.Text = get_company_x(get_id_company(GVProdInvoice.GetFocusedRowCellValue("id_comp_contact_to").ToString), "2")
            FormMatInvoiceReturDet.TECompName.Text = get_company_x(get_id_company(GVProdInvoice.GetFocusedRowCellValue("id_comp_contact_to").ToString), "1")
            FormMatInvoiceReturDet.MECompAddress.Text = get_company_x(get_id_company(GVProdInvoice.GetFocusedRowCellValue("id_comp_contact_to").ToString), "3")

            FormMatInvoiceReturDet.LECurrency.EditValue = Nothing
            FormMatInvoiceReturDet.LECurrency.ItemIndex = FormMatInvoiceReturDet.LECurrency.Properties.GetDataSourceRowIndex("id_currency", GVProdInvoice.GetFocusedRowCellValue("id_currency").ToString)

            FormMatInvoiceReturDet.GConListPurchase.Enabled = True

            Close()
        End If
    End Sub

    Private Sub GVProdInvoice_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVProdInvoice.ColumnFilterChanged
        viewInvDet()
    End Sub
End Class