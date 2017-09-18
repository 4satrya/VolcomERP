Public Class FormPopUpWOProd
    Public id_prod_order As String = "-1"
    Public id_wo As String = "-1"
    Public id_popup As String = "-1"
    '1 = formproductionMRS
    '2 = formprodWOPR
    Private Sub FormPopUpWOProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_wo()
    End Sub

    Sub view_wo()
        Dim query = "SELECT dsg.design_code,dsg.design_display_name,po.prod_order_number,a.id_report_status,h.report_status,a.id_prod_order_wo,a.id_ovh_price,a.id_prod_order "
        query += ",(SELECT IFNULL(MAX(prod_order_wo_prog_percent),0) FROM tb_prod_order_wo_prog WHERE id_prod_order_wo = a.id_prod_order_wo) as progress,"
        query += "g.payment,a.prod_order_wo_kurs,a.id_currency, "
        query += "b.id_comp_contact,d.comp_name AS comp_name_to, "
        query += "f.comp_name AS comp_name_ship_to, "
        query += "a.prod_order_wo_number,a.id_ovh_price,j.overhead, "
        query += "a.prod_order_wo_date, "
        query += "DATE_ADD(a.prod_order_wo_date,INTERVAL a.prod_order_wo_lead_time DAY) AS prod_order_wo_lead_time, "
        query += "DATE_ADD(a.prod_order_wo_date,INTERVAL (a.prod_order_wo_top+a.prod_order_wo_lead_time) DAY) AS prod_order_wo_topx, "
        query += "DATE_ADD(a.prod_order_wo_date,INTERVAL (a.prod_order_wo_top+a.prod_order_wo_lead_time) DAY) AS prod_order_wo_top "
        query += "FROM tb_prod_order_wo a INNER JOIN tb_m_ovh_price b ON a.id_ovh_price=b.id_ovh_price "
        query += "INNER JOIN tb_prod_order po ON po.id_prod_order=a.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design "
        query += "INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design "
        query += "INNER JOIN tb_m_comp_contact c ON b.id_comp_contact = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_ovh j ON b.id_ovh = j.id_ovh "
        If id_popup = "1" Then
            query += "WHERE a.id_prod_order='" & id_prod_order & "'"
            GridColumnPONumber.Visible = False
        ElseIf id_popup = "2" Then
            query += "WHERE a.id_report_status='3' OR a.id_report_status='4' OR a.id_report_status='6'"
            GridColumnPONumber.Visible = True
        End If
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
        GVProdWO.BestFitColumns()
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
        If GVProdWO.RowCount > 0 Then
            If id_popup = "1" Then
                'not use WO on MRS prod
                'FormProductionMRS.id_wo = GVProdWO.GetFocusedRowCellValue("id_prod_order_wo").ToString
                'FormProductionMRS.TEWONumber.Text = GVProdWO.GetFocusedRowCellValue("prod_order_wo_number").ToString
                'FormProductionMRS.id_comp_req_from = GVProdWO.GetFocusedRowCellValue("id_comp_contact").ToString
                'FormProductionMRS.TECompName.Text = get_company_x(get_id_company(GVProdWO.GetFocusedRowCellValue("id_comp_contact").ToString), "1")
                'FormProductionMRS.TECompCode.Text = get_company_x(get_id_company(GVProdWO.GetFocusedRowCellValue("id_comp_contact").ToString), "2")
                'Close()
            ElseIf id_popup = "2" Then
                FormProdPRWODet.id_prod_order_wo = GVProdWO.GetFocusedRowCellValue("id_prod_order_wo").ToString
                FormProdPRWODet.id_prod_order = GVProdWO.GetFocusedRowCellValue("id_prod_order").ToString
                FormProdPRWODet.TEWONumber.Text = GVProdWO.GetFocusedRowCellValue("prod_order_wo_number").ToString
                FormProdPRWODet.id_comp_contact_pay_to = GVProdWO.GetFocusedRowCellValue("id_comp_contact").ToString
                FormProdPRWODet.TECompTo.Text = get_company_x(get_id_company(GVProdWO.GetFocusedRowCellValue("id_comp_contact").ToString), "1")
                FormProdPRWODet.MECompAddress.Text = get_company_x(get_id_company(GVProdWO.GetFocusedRowCellValue("id_comp_contact").ToString), "3")
                FormProdPRWODet.TEPONumber.Text = GVProdWO.GetFocusedRowCellValue("prod_order_number").ToString
                FormProdPRWODet.DEDueDate.EditValue = GVProdWO.GetFocusedRowCellValue("prod_order_wo_top")
                FormProdPRWODet.TEKurs.EditValue = GVProdWO.GetFocusedRowCellValue("prod_order_wo_kurs")

                FormProdPRWODet.LECurrency.EditValue = Nothing
                FormProdPRWODet.LECurrency.ItemIndex = FormProdPRWODet.LECurrency.Properties.GetDataSourceRowIndex("id_currency", GVProdWO.GetFocusedRowCellValue("id_currency").ToString)

                FormProdPRWODet.GConListPurchase.Enabled = True
                FormProdPRWODet.view_list_wo()
                Close()
            End If
        End If
    End Sub

    Private Sub GVProdWO_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVProdWO.RowClick
        If GVProdWO.RowCount > 0 Then
            view_wo(GVProdWO.GetFocusedRowCellValue("id_prod_order_wo").ToString)
        End If
    End Sub

    Private Sub GVProdWO_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdWO.FocusedRowChanged
        If GVProdWO.RowCount > 0 Then
            view_wo(GVProdWO.GetFocusedRowCellValue("id_prod_order_wo").ToString)
        End If
    End Sub
End Class