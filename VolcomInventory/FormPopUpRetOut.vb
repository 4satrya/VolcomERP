Public Class FormPopUpRetOut
    Public id_pop_up As String = "-1"

    Private Sub FormPopUpRetOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_ret_out()
    End Sub

    Sub load_ret_out()
        Dim q As String = "SELECT reto.id_prod_order_ret_out,reto.id_prod_order_rec,g.season,po.prod_order_number,po.id_prod_order,reto.prod_order_ret_out_number,c.comp_name,prod_order_ret_out_date,dsg.id_design,dsg.design_code,dsg.design_display_name
FROM tb_prod_order_ret_out reto
INNER JOIN tb_prod_order_rec rec ON rec.id_prod_order_rec = reto.id_prod_order_rec AND rec.id_report_status='6'
INNER JOIN tb_prod_order po ON reto.id_prod_order=po.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=reto.id_comp_contact_to
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
INNER JOIN tb_season_delivery i ON po.id_delivery = i.id_delivery 
INNER JOIN tb_season g ON g.id_season = i.id_season 
WHERE reto.id_report_status=6"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCRetOut.DataSource = dt
        GVRetOut.BestFitColumns()
    End Sub

    Sub load_ret_out_det()
        Dim q As String = "CALL view_return_out_prod('" + GVRetOut.GetFocusedRowCellValue("id_prod_order_ret_out").ToString + "', '0')"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCListPurchase.DataSource = dt
        GVListPurchase.BestFitColumns()
    End Sub

    Private Sub FormPopUpRetOut_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BLoadDetail_Click(sender As Object, e As EventArgs) Handles BLoadDetail.Click
        If GVRetOut.RowCount > 0 Then
            load_ret_out_det()
        End If
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If id_pop_up = "1" Then 'return In prod
            FormProductionRetInSingle.id_prod_order = GVRetOut.GetFocusedRowCellValue("id_prod_order").ToString

            Dim query As String = String.Format("SELECT id_report_status,id_delivery,prod_order_number,id_po_type,DATE_FORMAT(prod_order_date,'%Y-%m-%d') as prod_order_datex,prod_order_lead_time,prod_order_note FROM tb_prod_order WHERE id_prod_order = '{0}'", GVRetOut.GetFocusedRowCellValue("id_prod_order").ToString)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim date_created As String = ""

            If data.Rows.Count > 0 Then
                FormProductionRetInSingle.GroupControlRet.Enabled = True
                FormProductionRetInSingle.GroupControlListBarcode.Enabled = True
                FormProductionRetInSingle.viewDetailReturn()
                FormProductionRetInSingle.view_barcode_list()
                FormProductionRetInSingle.deleteRows()
                FormProductionRetInSingle.id_prod_order_det_list.Clear()
                FormProductionRetInSingle.check_but()
                FormProductionRetInSingle.BtnInfoSrs.Enabled = True

                FormProductionRetInSingle.id_rec = GVRetOut.GetFocusedRowCellValue("id_prod_order_rec").ToString
                FormProductionRetInSingle.id_ret_out = GVRetOut.GetFocusedRowCellValue("id_prod_order_ret_out").ToString
                FormProductionRetInSingle.id_prod_order = GVRetOut.GetFocusedRowCellValue("id_prod_order").ToString
                FormProductionRetInSingle.TxtOrderNumber.Text = GVRetOut.GetFocusedRowCellValue("prod_order_number").ToString
                FormProductionRetInSingle.TERetOutNo.Text = GVRetOut.GetFocusedRowCellValue("prod_order_ret_out_number").ToString

                FormProductionRetInSingle.id_design = GVRetOut.GetFocusedRowCellValue("id_design").ToString
                FormProductionRetInSingle.TEDesign.Text = GVRetOut.GetFocusedRowCellValue("design_display_name").ToString
                FormProductionRetInSingle.TxtSeason.Text = GVRetOut.GetFocusedRowCellValue("season").ToString
                pre_viewImages("2", FormProductionRetInSingle.PEView, GVRetOut.GetFocusedRowCellValue("id_design").ToString, False)
                FormProductionRetInSingle.mainVendor()
                FormProductionRetInSingle.PEView.Enabled = True
                FormProductionRetInSingle.viewDetailReturn()
                FormProductionRetInSingle.view_barcode_list()
                FormProductionRetInSingle.check_but()
                Close()
            Else
                stopCustom("Data is empty.")
            End If
        End If
    End Sub

    Private Sub GVRetOut_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetOut.FocusedRowChanged
        For i As Integer = GVListPurchase.RowCount - 1 To 0 Step -1
            GVListPurchase.DeleteRow(i)
        Next
    End Sub
End Class