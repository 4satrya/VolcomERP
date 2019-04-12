Public Class FormPopUpMatPLInv 
    Public id_pl As String = "-1"
    Public id_prod_wo As String = "-1"
    Public id_pop_up As String = "-1"

    Private Sub FormPopUpMatPLInv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        query += "WHERE NOT ISNULL(i.id_prod_order) AND (a.id_report_status = '4' OR a.id_report_status = '3' OR a.id_report_status = '6') AND j.id_prod_order_wo='" & id_prod_wo & "'"
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
            'check if exist
            Dim already = False
            If FormMatInvoiceDet.GVProdPL.RowCount > 0 Then
                For i As Integer = 0 To FormMatInvoiceDet.GVProdPL.RowCount - 1
                    If FormMatInvoiceDet.GVProdPL.GetRowCellValue(i, "id_pl_mrs").ToString = GVProdPL.GetFocusedRowCellDisplayText("id_pl_mrs").ToString Then
                        already = True
                    End If
                Next
            End If

            If already = True Then
                stopCustom("Packing list already on list")
            Else
                Dim newRow As DataRow = (TryCast(FormMatInvoiceDet.GCProdPL.DataSource, DataTable)).NewRow()
                newRow("id_pl_mrs") = GVProdPL.GetFocusedRowCellDisplayText("id_pl_mrs").ToString
                newRow("pl_mrs_number") = GVProdPL.GetFocusedRowCellDisplayText("pl_mrs_number").ToString
                newRow("prod_order_mrs_number") = GVProdPL.GetFocusedRowCellDisplayText("prod_order_mrs_number")
                newRow("comp_name_from") = GVProdPL.GetFocusedRowCellDisplayText("comp_name_from")
                newRow("comp_name_to") = GVProdPL.GetFocusedRowCellDisplayText("comp_name_to").ToString
                newRow("pl_mrs_date") = GVProdPL.GetFocusedRowCellDisplayText("pl_mrs_date").ToString
                newRow("report_status") = GVProdPL.GetFocusedRowCellDisplayText("report_status").ToString
                newRow("id_report_status") = GVProdPL.GetFocusedRowCellDisplayText("id_report_status").ToString

                TryCast(FormMatInvoiceDet.GCProdPL.DataSource, DataTable).Rows.Add(newRow)
                FormMatInvoiceDet.GCProdPL.RefreshDataSource()
                FormMatInvoiceDet.check_but()
                FormMatInvoiceDet.GVProdPL.FocusedRowHandle = 0
                'detail PL
                If GVDetail.RowCount > 0 Then
                    For i As Integer = 0 To (GVDetail.RowCount - 1)
                        Dim newRowx As DataRow = (TryCast(FormMatInvoiceDet.GCListPurchase.DataSource, DataTable)).NewRow()
                        newRowx("id_pl_mrs_det") = GVDetail.GetRowCellValue(i, "id_pl_mrs_det").ToString
                        newRowx("id_pl_mrs") = GVProdPL.GetFocusedRowCellDisplayText("id_pl_mrs").ToString
                        newRowx("code") = GVDetail.GetRowCellValue(i, "code").ToString
                        newRowx("name") = GVDetail.GetRowCellValue(i, "name")
                        newRowx("qty") = GVDetail.GetRowCellValue(i, "qty")
                        newRowx("price") = GVDetail.GetRowCellValue(i, "price")
                        newRowx("uom") = GVDetail.GetRowCellValue(i, "uom").ToString
                        newRowx("total_price") = GVDetail.GetRowCellValue(i, "total_price")
                        newRowx("id_mat_det") = GVDetail.GetRowCellValue(i, "id_mat_det").ToString
                        newRowx("pl_mrs_number") = GVProdPL.GetFocusedRowCellDisplayText("pl_mrs_number").ToString

                        TryCast(FormMatInvoiceDet.GCListPurchase.DataSource, DataTable).Rows.Add(newRowx)
                        FormMatInvoiceDet.GCListPurchase.RefreshDataSource()
                    Next
                    FormMatInvoiceDet.calculate()
                End If

                Close()
            End If
        End If
    End Sub

    Private Sub GVProdPL_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdPL.FocusedRowChanged
        viewFillEmptyData()
    End Sub

    Private Sub FormPopUpMatPLInv_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub GVProdPL_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVProdPL.ColumnFilterChanged
        viewFillEmptyData()
    End Sub
End Class