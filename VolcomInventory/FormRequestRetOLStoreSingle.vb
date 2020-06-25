Public Class FormRequestRetOLStoreSingle
    Private Sub FormRequestRetOLStoreSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Dim query As String = "SELECT sod.id_sales_order_det, dd.id_product,p.product_full_code AS `code` ,CONCAT(p.product_full_code,dc.pl_sales_order_del_det_counting) AS `scanned_code`, p.product_display_name AS `name`, cd.code_detail_name AS `size`,
        sod.ol_store_id, sod.item_id, dd.design_price, stt.design_cat
        FROM tb_sales_order so
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = sod.id_sales_order_det
        INNER JOIN tb_pl_sales_order_del_det_counting dc ON dc.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
        INNER JOIN tb_m_product p ON p.id_product = dd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        LEFT JOIN (
	        SELECT d.id_sales_order_det 
	        FROM tb_ol_store_ret_req_det d
	        INNER JOIN tb_ol_store_ret_req m ON m.id_ol_store_ret_req = d.id_ol_store_ret_req
	        WHERE m.id_report_status!=5
	        GROUP BY d.id_sales_order_det
        ) a ON a.id_sales_order_det = sod.id_sales_order_det
        INNER JOIN tb_m_design_price prc ON prc.id_design_price = dd.id_design_price
        INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type
        INNER JOIN tb_lookup_design_cat stt ON stt.id_design_cat = pt.id_design_cat
        WHERE so.sales_order_ol_shop_number='" + addSlashes(FormRequestRetOLStore.TxtOrderNumber.Text) + "' AND c.id_comp_group=" + FormRequestRetOLStore.SLECompGroup.EditValue.ToString + " AND ISNULL(a.id_sales_order_det) "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim data_par As DataTable = FormRequestRetOLStore.GCData.DataSource
        If data_par.Rows.Count = 0 Then
            GCData.DataSource = data
        Else
            Dim t1 = data.AsEnumerable()
            Dim t2 = data_par.AsEnumerable()
            Try
                Dim except As DataTable = (From _t1 In t1
                                           Group Join _t2 In t2
                                           On _t1("id_sales_order_det").ToString Equals _t2("id_sales_order_det").ToString Into Group
                                           From _t3 In Group.DefaultIfEmpty()
                                           Where _t3 Is Nothing
                                           Select _t1).CopyToDataTable
                GCData.DataSource = except
            Catch ex As Exception
                GCData.DataSource = Nothing
            End Try
        End If
    End Sub

    Private Sub FormRequestRetOLStoreSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub choose()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim newRow As DataRow = (TryCast(FormRequestRetOLStore.GCData.DataSource, DataTable)).NewRow()
            newRow("id_ol_store_ret_req_det") = "0"
            newRow("id_ol_store_ret_req") = "0"
            newRow("id_sales_order_det") = GVData.GetFocusedRowCellValue("id_sales_order_det").ToString
            newRow("id_product") = GVData.GetFocusedRowCellValue("id_product").ToString
            newRow("code") = GVData.GetFocusedRowCellValue("code").ToString
            newRow("product_full_code") = GVData.GetFocusedRowCellValue("scanned_code").ToString
            newRow("name") = GVData.GetFocusedRowCellValue("name").ToString
            newRow("size") = GVData.GetFocusedRowCellValue("size").ToString
            newRow("item_id") = GVData.GetFocusedRowCellValue("item_id").ToString
            newRow("ol_store_id") = GVData.GetFocusedRowCellValue("ol_store_id").ToString
            newRow("design_cat") = GVData.GetFocusedRowCellValue("design_cat").ToString
            newRow("design_price") = GVData.GetFocusedRowCellValue("design_price")
            TryCast(FormRequestRetOLStore.GCData.DataSource, DataTable).Rows.Add(newRow)
            FormRequestRetOLStore.GCData.RefreshDataSource()
            FormRequestRetOLStore.GVData.RefreshData()

            'refresh
            viewData()
            Cursor = Cursors.WaitCursor
        End If
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        choose()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        choose()
    End Sub
End Class