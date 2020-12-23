Public Class FormSalesPOSCompare
    Public dt_xls As DataTable
    Public dt_stock As DataTable
    Public dt_prc As DataTable

    Private Sub FormSalesPOSCompare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        Dim tb1 = dt_xls.AsEnumerable()
        Dim tb2 = dt_stock.AsEnumerable
        Dim tb3 = dt_prc.AsEnumerable()
        Dim query = From table1 In tb1
                    Group Join table_tmp In tb2
                    On table1("code").ToString.Trim Equals table_tmp("code").ToString Into sjoin = Group
                    From rs In sjoin.DefaultIfEmpty()
                    Group Join table_price In tb3
                    On table1("code").ToString.Trim Equals table_price("product_full_code").ToString Into pjoin = Group
                    From rp In pjoin.DefaultIfEmpty
                    Select New With
                    {
                        .code = table1("code").ToString,
                        .name = If(rp Is Nothing, "", rp("design_display_name").ToString),
                        .size = If(rp Is Nothing, "", rp("size").ToString),
                        .limit_qty = If(rs Is Nothing, 0, rs("qty_all_product")),
                        .sales_qty = table1("qty"),
                        .sales_pos_det_qty = If(table1("qty") <= If(rs Is Nothing, 0, rs("qty_all_product")), table1("qty"), If(rs Is Nothing, 0, rs("qty_all_product"))),
                        .no_stock_qty = table1("qty") - If(table1("qty") <= If(rs Is Nothing, 0, rs("qty_all_product")), table1("qty"), If(rs Is Nothing, 0, rs("qty_all_product"))),
                        .id_design_price = If(rp Is Nothing, "0", rp("id_design_price").ToString),
                        .design_price = If(rp Is Nothing, 0, rp("design_price")),
                        .design_price_type = If(rp Is Nothing, "", rp("design_price_type").ToString),
                        .id_design_price_retail = If(rp Is Nothing, "0", rp("id_design_price").ToString),
                        .design_price_retail = If(rp Is Nothing, 0, rp("design_price")),
                        .input_price = table1("price"),
                        .id_design = If(rp Is Nothing, "0", rp("id_design").ToString),
                        .id_product = If(rp Is Nothing, "0", rp("id_product").ToString),
                        .is_select = "No",
                        .note = If(rs Is Nothing, "Product not found", If(table1("qty") > If(rs Is Nothing, 0, rs("qty_all_product")), "+" + (table1("qty") - If(rs Is Nothing, 0, rs("qty_all_product"))).ToString, "OK")),
                        .note_price = If(If(rp Is Nothing, 0, rp("design_price")) = table1("price"), "OK", "Not Valid"),
                        .stt = If(If(If(rp Is Nothing, 0, rp("design_price")) = table1("price"), "OK", "Not Valid") = "OK", If(table1("qty") = If(table1("qty") <= If(rs Is Nothing, 0, rs("qty_all_product")), table1("qty"), If(rs Is Nothing, 0, rs("qty_all_product"))), "OK", "No Stock"), "Price not valid"),
                        .id_sales_pos_det = "0"
                    }
        GCData.DataSource = Nothing
        GCData.DataSource = query.ToList()
        GCData.RefreshDataSource()
        GVData.RefreshData()
        GVData.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub FormSalesPOSCompare_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVData_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVData.RowCellStyle

    End Sub

    Private Sub GVData_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVData.RowStyle
        Dim stt As String = ""
        Try
            stt = GVData.GetRowCellValue(e.RowHandle, "stt").ToString
        Catch ex As Exception
        End Try
        If stt = "No Stock" Then
            e.Appearance.BackColor = Color.Yellow
            e.Appearance.BackColor2 = Color.Yellow
        ElseIf stt = "Price not valid" Then
            e.Appearance.BackColor = Color.Salmon
            e.Appearance.BackColor2 = Color.Salmon
        Else
            e.Appearance.BackColor = Color.Empty
            e.Appearance.BackColor2 = Color.Empty
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCData, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVData)
        FormSalesPOSDet.viewDetail()
        FormSalesPOSDet.viewProb()
        For i As Integer = 0 To GVData.RowCount - 1
            Dim note_price As String = GVData.GetRowCellValue(i, "note_price").ToString
            If note_price = "OK" Then
                If GVData.GetRowCellValue(i, "sales_pos_det_qty") > 0 Then
                    insertInvoiceList(i)
                End If
                If GVData.GetRowCellValue(i, "no_stock_qty") > 0 Then
                    insertProblemList(i)
                End If
            Else
                'masuk ke problem list
                insertProblemList(i)
            End If
        Next
        Cursor = Cursors.Default

        'close
        Close()
    End Sub

    Sub insertInvoiceList(ByVal rh As Integer)
        Dim newRow As DataRow = (TryCast(FormSalesPOSDet.GCItemList.DataSource, DataTable)).NewRow()
        newRow("code") = GVData.GetRowCellValue(rh, "code").ToString
        newRow("name") = GVData.GetRowCellValue(rh, "name").ToString
        newRow("size") = GVData.GetRowCellValue(rh, "size").ToString
        newRow("sales_pos_det_qty") = GVData.GetRowCellValue(rh, "sales_pos_det_qty")
        newRow("sales_pos_det_amount") = GVData.GetRowCellValue(rh, "sales_pos_det_qty") * GVData.GetRowCellValue(rh, "design_price_retail")
        newRow("limit_qty") = GVData.GetRowCellValue(rh, "limit_qty")
        newRow("id_design_price") = GVData.GetRowCellValue(rh, "id_design_price").ToString
        newRow("design_price") = GVData.GetRowCellValue(rh, "design_price")
        newRow("design_price_type") = GVData.GetRowCellValue(rh, "design_price_type").ToString
        newRow("id_design_price_retail") = GVData.GetRowCellValue(rh, "id_design_price_retail").ToString
        newRow("design_price_retail") = GVData.GetRowCellValue(rh, "design_price_retail")
        newRow("id_design") = GVData.GetRowCellValue(rh, "id_design").ToString
        newRow("id_product") = GVData.GetRowCellValue(rh, "id_product").ToString
        newRow("is_select") = "No"
        newRow("note") = "OK"
        newRow("id_sales_pos_det") = GVData.GetRowCellValue(rh, "id_sales_pos_det").ToString
        newRow("id_sales_pos_prob") = "0"
        newRow("id_sales_pos_prob_price") = "0"
        TryCast(FormSalesPOSDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
        FormSalesPOSDet.GCItemList.RefreshDataSource()
        FormSalesPOSDet.GVItemList.RefreshData()
        FormSalesPOSDet.calculate()
    End Sub

    Sub insertProblemList(ByVal rh As Integer)
        'check invalid price
        Dim is_invalid_price As String = ""
        Dim id_design_price_valid As String = ""
        Dim design_price_valid As Decimal = 0.00
        Dim note_price As String = GVData.GetRowCellValue(rh, "note_price").ToString
        Dim hold_qty As Decimal = 0.00
        If note_price <> "OK" Then
            is_invalid_price = "1"
            id_design_price_valid = "0"
            design_price_valid = 0.00
            hold_qty = GVData.GetRowCellValue(rh, "sales_pos_det_qty")
        Else
            is_invalid_price = "2"
            id_design_price_valid = GVData.GetRowCellValue(rh, "id_design_price_retail").ToString
            design_price_valid = GVData.GetRowCellValue(rh, "design_price_retail")
            hold_qty = 0.00
        End If
        'check no stock
        Dim is_no_stock As String = ""
        If GVData.GetRowCellValue(rh, "no_stock_qty") > 0 Then
            is_no_stock = "1"
        Else
            is_no_stock = "2"
        End If

        Dim newRow As DataRow = (TryCast(FormSalesPOSDet.GCProbList.DataSource, DataTable)).NewRow()
        newRow("is_invalid_price") = is_invalid_price
        newRow("is_no_stock") = is_no_stock
        newRow("id_product") = GVData.GetRowCellValue(rh, "id_product").ToString
        newRow("code") = GVData.GetRowCellValue(rh, "code").ToString
        newRow("name") = GVData.GetRowCellValue(rh, "name").ToString
        newRow("size") = GVData.GetRowCellValue(rh, "size").ToString
        newRow("id_design_price_retail") = GVData.GetRowCellValue(rh, "id_design_price_retail").ToString
        newRow("design_price_retail") = GVData.GetRowCellValue(rh, "design_price_retail")
        newRow("design_price_store") = GVData.GetRowCellValue(rh, "input_price")
        newRow("id_design_price_valid") = id_design_price_valid
        newRow("design_price_valid") = design_price_valid
        newRow("store_qty") = GVData.GetRowCellValue(rh, "sales_qty")
        newRow("invoice_qty") = hold_qty
        newRow("no_stock_qty") = GVData.GetRowCellValue(rh, "no_stock_qty")
        newRow("note_price") = note_price
        TryCast(FormSalesPOSDet.GCProbList.DataSource, DataTable).Rows.Add(newRow)
        FormSalesPOSDet.GCProbList.RefreshDataSource()
        FormSalesPOSDet.GVProbList.RefreshData()
        FormSalesPOSDet.GVProbList.BestFitColumns()
    End Sub
End Class