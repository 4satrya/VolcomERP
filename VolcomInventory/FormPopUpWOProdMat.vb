Public Class FormPopUpWOProdMat 
    Public id_wo As String = "-1"
    Public id_pop_up As String = "-1"

    Private Sub FormPopUpWOProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_wo()
    End Sub

    Sub view_wo()
        Dim query = "SELECT a.id_report_status,h.report_status,po.prod_order_number,desg.design_name,desg.design_code,a.id_prod_order_wo,a.id_ovh_price "
        query += ",(SELECT IFNULL(MAX(prod_order_wo_prog_percent),0) FROM tb_prod_order_wo_prog WHERE id_prod_order_wo = a.id_prod_order_wo) as progress,"
        query += "g.payment, "
        query += "b.id_comp_contact,d.comp_name AS comp_name_to, "
        query += "f.comp_name AS comp_name_ship_to, "
        query += "a.prod_order_wo_number,a.id_ovh_price,j.overhead, "
        query += "DATE_FORMAT(a.prod_order_wo_date,'%d %M %Y') AS prod_order_wo_date, "
        query += "DATE_FORMAT(DATE_ADD(a.prod_order_wo_date,INTERVAL a.prod_order_wo_lead_time DAY),'%d %M %Y') AS prod_order_wo_lead_time, "
        query += "DATE_FORMAT(DATE_ADD(a.prod_order_wo_date,INTERVAL (a.prod_order_wo_top+a.prod_order_wo_lead_time) DAY),'%d %M %Y') AS prod_order_wo_top "
        query += "FROM tb_prod_order_wo a INNER JOIN tb_m_ovh_price b ON a.id_ovh_price=b.id_ovh_price "
        query += "INNER JOIN tb_prod_order po ON po.id_prod_order = a.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design pd_desg ON pd_desg.id_prod_demand_design = po.id_prod_demand_design "
        query += "INNER JOIN tb_m_design desg ON desg.id_design = pd_desg.id_design "
        query += "INNER JOIN tb_m_comp_contact c ON b.id_comp_contact = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_ovh j ON b.id_ovh = j.id_ovh "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdWO.DataSource = data
        If data.Rows.Count > 0 Then
            If id_wo = "-1" Then
                GVProdWO.FocusedRowHandle = find_row(GVProdWO, "id_prod_order_wo", id_wo)
            Else
                GVProdWO.FocusedRowHandle = 0
            End If
            view_wo(GVProdWO.GetFocusedRowCellValue("id_prod_order_wo").ToString)
            BSave.Enabled = True
        Else
            BSave.Enabled = False
        End If
    End Sub
    Sub view_wo(ByVal id_prod_wo As String)
        Dim query = "CALL view_prod_order_wo_det('" & id_prod_wo & "','1')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
    End Sub
    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormPopUpWOProd_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        If id_pop_up = "1" Then 'ret in prod
            If GVProdWO.RowCount > 0 Then
                FormMatRetInProd.id_prod_order_wo = GVProdWO.GetFocusedRowCellValue("id_prod_order_wo").ToString
                'FormMatRetInProd.TEWONumber.Text = GVProdWO.GetFocusedRowCellValue("prod_order_wo_number").ToString
                FormMatRetInProd.id_comp_contact_from = GVProdWO.GetFocusedRowCellValue("id_comp_contact").ToString
                FormMatRetInProd.TxtNameCompFrom.Text = get_company_x(get_id_company(GVProdWO.GetFocusedRowCellValue("id_comp_contact").ToString), "1")
                FormMatRetInProd.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVProdWO.GetFocusedRowCellValue("id_comp_contact").ToString), "2")
                FormMatRetInProd.MEAdrressCompFrom.Text = get_company_x(get_id_company(GVProdWO.GetFocusedRowCellValue("id_comp_contact").ToString), "3")
                FormMatRetInProd.TEPONumber.Text = GVProdWO.GetFocusedRowCellValue("prod_order_number").ToString
                FormMatRetInProd.TEDesign.Text = GVProdWO.GetFocusedRowCellValue("design_name").ToString
                FormMatRetInProd.TEDesignCode.Text = GVProdWO.GetFocusedRowCellValue("design_code").ToString

                FormMatRetInProd.GroupControlRet.Enabled = True
                FormMatRetInProd.viewDetailReturnExt("-1")
                FormMatRetInProd.check_but()
                Close()
            Else
                warningCustom("No data selected.")
            End If
        ElseIf id_pop_up = "2" Then 'inv mat prod
            If GVProdWO.RowCount > 0 Then
                FormMatInvoiceDet.id_prod_order_wo = GVProdWO.GetFocusedRowCellValue("id_prod_order_wo").ToString
                FormMatInvoiceDet.TEWONumber.Text = GVProdWO.GetFocusedRowCellValue("prod_order_wo_number").ToString
                FormMatInvoiceDet.id_comp_to = GVProdWO.GetFocusedRowCellValue("id_comp_contact").ToString
                FormMatInvoiceDet.TECompName.Text = get_company_x(get_id_company(GVProdWO.GetFocusedRowCellValue("id_comp_contact").ToString), "1")
                FormMatInvoiceDet.TECompCode.Text = get_company_x(get_id_company(GVProdWO.GetFocusedRowCellValue("id_comp_contact").ToString), "2")
                FormMatInvoiceDet.MECompAddress.Text = get_company_x(get_id_company(GVProdWO.GetFocusedRowCellValue("id_comp_contact").ToString), "3")
                FormMatInvoiceDet.TEPONumber.Text = GVProdWO.GetFocusedRowCellValue("prod_order_number").ToString
                FormMatInvoiceDet.TEDesign.Text = GVProdWO.GetFocusedRowCellValue("design_name").ToString
                FormMatInvoiceDet.check_but()
                FormMatInvoiceDet.GConListPurchase.Enabled = True
                Close()
            Else
                warningCustom("No data selected.")
            End If
        End If
    End Sub

    Private Sub GVProdWO_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVProdWO.RowClick
        If GVProdWO.RowCount > 0 Then
            view_wo(GVProdWO.GetFocusedRowCellValue("id_prod_order_wo").ToString)
        End If
    End Sub
End Class