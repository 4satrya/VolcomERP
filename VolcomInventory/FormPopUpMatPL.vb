Public Class FormPopUpMatPL
    Public id_pl As String = "-1"
    Public id_pop_up As String = "-1"

    Private Sub FormPopUpMatPL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewPL()
    End Sub
    Sub viewPL()
        Dim query As String = "SELECT a.id_currency,a.id_pl_mrs ,m.design_name,k.prod_order_number,a.id_comp_contact_from , a.id_comp_contact_to, a.pl_mrs_note, a.pl_mrs_number, "
        query += "(d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to, h.report_status, a.id_report_status,j.prod_order_wo_number,i.prod_order_mrs_number, "
        query += "DATE_FORMAT(a.pl_mrs_date,'%d %M %Y') AS pl_mrs_date, a.id_report_status FROM tb_pl_mrs a "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_prod_order_mrs i ON a.id_prod_order_mrs = i.id_prod_order_mrs "
        query += "INNER JOIN tb_prod_order k ON i.id_prod_order = k.id_prod_order "
        query += "INNER JOIN tb_prod_order_wo j ON i.id_prod_order_wo = j.id_prod_order_wo "
        query += "INNER JOIN tb_prod_demand_design l ON k.id_prod_demand_design = l.id_prod_demand_design "
        query += "INNER JOIN tb_m_design m ON m.id_design = l.id_design "
        query += "WHERE NOT ISNULL(i.id_prod_order) AND (a.id_report_status = '4' OR a.id_report_status = '3')"
        query += "ORDER BY a.id_pl_mrs DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdPL.DataSource = data
        If data.Rows.Count > 0 Then
            viewFillEmptyData()
        End If
    End Sub
    Sub viewFillEmptyData()
        Dim query As String = "CALL view_inv_mat_pl('" + GVProdPL.GetFocusedRowCellValue("id_pl_mrs").ToString + "','1')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        If data.Rows.Count > 0 Then
            BSave.Enabled = True
        Else
            BSave.Enabled = False
        End If
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        If id_pop_up = "1" Then 'formmatinvoicedet
            FormMatInvoiceDet.id_prod_order_wo = GVProdPL.GetFocusedRowCellValue("id_pl_mrs").ToString
            FormMatInvoiceDet.TEWONumber.Text = GVProdPL.GetFocusedRowCellValue("pl_mrs_number").ToString
            FormMatInvoiceDet.TEPONumber.Text = GVProdPL.GetFocusedRowCellValue("prod_order_number").ToString
            FormMatInvoiceDet.TEDesign.Text = GVProdPL.GetFocusedRowCellValue("design_name").ToString
            FormMatInvoiceDet.id_comp_to = GVProdPL.GetFocusedRowCellValue("id_comp_contact_to").ToString

            FormMatInvoiceDet.TECompCode.Text = get_company_x(get_id_company(GVProdPL.GetFocusedRowCellValue("id_comp_contact_to").ToString), "2")
            FormMatInvoiceDet.TECompName.Text = get_company_x(get_id_company(GVProdPL.GetFocusedRowCellValue("id_comp_contact_to").ToString), "1")
            FormMatInvoiceDet.MECompAddress.Text = get_company_x(get_id_company(GVProdPL.GetFocusedRowCellValue("id_comp_contact_to").ToString), "3")

            FormMatInvoiceDet.LECurrency.EditValue = Nothing
            FormMatInvoiceDet.LECurrency.ItemIndex = FormMatInvoiceDet.LECurrency.Properties.GetDataSourceRowIndex("id_currency", GVProdPL.GetFocusedRowCellValue("id_currency").ToString)

            FormMatInvoiceDet.GConListPurchase.Enabled = True
            '
            'FormMatInvoiceDet.load_pl()
            FormMatInvoiceDet.calculate()
            '
            Close()
        End If
    End Sub

    Private Sub GVProdPL_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdPL.FocusedRowChanged
        viewFillEmptyData()
    End Sub

    Private Sub GVProdPL_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVProdPL.ColumnFilterChanged
        viewFillEmptyData()
    End Sub
End Class