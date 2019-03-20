Public Class FormPopUpSalesReturnOrder 
    Public id_pop_up As String = "-1"
    Public id_sales_return_order As String = "-1"
    Public id_sales_return_order_det As String = "-1"
    Public id_sales_return As String = "-1"
    Public indeks_edit As Integer = 0

    Private Sub FormPopUpSalesReturnOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSalesReturnOrder()
        If id_sales_return_order <> "-1" Then
            GVSalesReturnOrder.FocusedRowHandle = find_row(GVSalesReturnOrder, "id_sales_return_order", id_sales_return_order)
        End If
        'If id_sales_return_order_det <> "-1" Then
        '    GVItemList.FocusedRowHandle = find_row(GVItemList, "id_sales_return_order_det", id_sales_return_order_det)
        'End If
    End Sub

    Sub viewSalesReturnOrder()
        Dim condition As String = "AND a.id_report_status = '6' AND (a.id_prepare_status='1') "
        If id_sales_return_order <> "-1" Then
            condition += "AND id_sales_return_order = '" + id_sales_return_order + "' "
        End If
        Dim query_c As ClassReturn = New ClassReturn()
        Dim query As String = query_c.queryMain(condition, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturnOrder.DataSource = data
        If data.Rows.Count > 0 Then
            'show all
            'BSave.Enabled = True
        Else
            'BSave.Enabled = False
        End If
    End Sub

    Sub viewListSalesReturnOrderDet(ByVal id_sales_return_order As String)
        Dim query As String = "CALL view_sales_return_order_limit('" + id_sales_return_order + "','" + id_sales_return_order_det + "', '" + id_sales_return + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub FormPopUpSalesReturnOrder_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    '1 : delivery order
    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor
        If id_pop_up = "1" Then
            'Return Order
            FormSalesReturnDet.id_sales_return_order = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
            FormSalesReturnDet.TxtSalesReturnOrderNumber.Text = GVSalesReturnOrder.GetFocusedRowCellValue("sales_return_order_number").ToString

            'store data
            Dim query_comp_to As String = "SELECT id_comp FROM tb_m_comp_contact WHERE id_comp_contact = '" + GVSalesReturnOrder.GetFocusedRowCellValue("id_store_contact_to").ToString + "'"
            Dim id_comp_to As String = execute_query(query_comp_to, 0, True, "", "", "", "")
            FormSalesReturnDet.id_store = id_comp_to
            FormSalesReturnDet.id_store_contact_from = GVSalesReturnOrder.GetFocusedRowCellValue("id_store_contact_to").ToString
            FormSalesReturnDet.TxtCodeCompFrom.Text = get_company_x(id_comp_to, 2)
            FormSalesReturnDet.TxtNameCompFrom.Text = get_company_x(id_comp_to, 1)
            FormSalesReturnDet.MEAdrressCompFrom.Text = get_company_x(id_comp_to, 3)
            FormSalesReturnDet.id_wh_drawer_store = GVSalesReturnOrder.GetFocusedRowCellValue("id_wh_drawer_store").ToString
            FormSalesReturnDet.id_wh_rack_store = GVSalesReturnOrder.GetFocusedRowCellValue("id_wh_rack_store").ToString
            FormSalesReturnDet.id_wh_locator_store = GVSalesReturnOrder.GetFocusedRowCellValue("id_wh_locator_store").ToString

            'hapus unique
            For i As Integer = 0 To (FormSalesReturnDet.GVItemList.RowCount - 1)
                Dim id_product As String = "-1"
                Try
                    id_product = FormSalesReturnDet.GVItemList.GetRowCellValue(i, "id_product").ToString
                Catch ex As Exception
                End Try
                FormSalesReturnDet.codeAvailableDel(id_product)
            Next

            'general
            FormSalesReturnDet.viewDetail()
            FormSalesReturnDet.view_barcode_list()
            FormSalesReturnDet.GroupControlListItem.Enabled = True
            FormSalesReturnDet.GroupControlScannedItem.Enabled = True
            FormSalesReturnDet.BtnInfoSrs.Enabled = True
            FormSalesReturnDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            Close()
        ElseIf id_pop_up = "2" Then
            Dim amount As Decimal = 0.0
            If id_sales_return_order_det = "-1" Then 'new
                'cek duplikat
                Dim is_duplicate As Boolean = False
                For i As Integer = 0 To (FormSalesReturnDet.GVItemList.RowCount - 1)
                    Dim id_product_cek As String = "0"
                    Dim id_design_price_cek As String = "0"
                    Dim design_price_cek As Decimal = 0.0
                    Try
                        id_product_cek = FormSalesReturnDet.GVItemList.GetRowCellValue(i, "id_product").ToString
                        id_design_price_cek = FormSalesReturnDet.GVItemList.GetRowCellValue(i, "id_design_price").ToString
                        design_price_cek = Decimal.Parse(FormSalesReturnDet.GVItemList.GetRowCellValue(i, "design_price").ToString)
                    Catch ex As Exception
                    End Try
                    If id_product_cek = GVItemList.GetFocusedRowCellValue("id_product").ToString And id_design_price_cek = GVItemList.GetFocusedRowCellValue("id_design_price").ToString And design_price_cek = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price").ToString) Then
                        'MsgBox(id_product_cek)
                        'MsgBox(GVItemList.GetFocusedRowCellValue("id_product").ToString)
                        is_duplicate = True
                        Exit For
                    End If
                Next

                If is_duplicate Then
                    errorCustom("This product already exist in Delivery Item List !")
                Else
                    Dim newRow As DataRow = (TryCast(FormSalesReturnDet.GCItemList.DataSource, DataTable)).NewRow()
                    newRow("id_sales_return_det") = "0"
                    newRow("id_sales_return_order_det") = GVItemList.GetFocusedRowCellValue("id_sales_return_order_det").ToString
                    newRow("name") = GVItemList.GetFocusedRowCellValue("name").ToString
                    newRow("code") = GVItemList.GetFocusedRowCellValue("code").ToString
                    newRow("size") = GVItemList.GetFocusedRowCellValue("size").ToString
                    'newRow("sales_return_det_qty") = GVItemList.GetFocusedRowCellValue("sales_return_det_qty")
                    'newRow("qty_from_wh") = GVItemList.GetFocusedRowCellValue("sales_return_det_qty")
                    'newRow("id_design_price") = GVItemList.GetFocusedRowCellValue("id_design_price").ToString
                    'newRow("design_price") = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price"))
                    'newRow("sales_return_det_amount") = Decimal.Parse(amount.ToString)
                    'newRow("sales_return_order_det_note") = GVItemList.GetFocusedRowCellValue("sales_return_order_det_note").ToString
                    'newRow("id_design") = GVItemList.GetFocusedRowCellValue("id_design").ToString
                    'newRow("id_product") = GVItemList.GetFocusedRowCellValue("id_product").ToString
                    'newRow("id_sample") = GVItemList.GetFocusedRowCellValue("id_sample").ToString
                    'newRow("design_price_type") = GVItemList.GetFocusedRowCellValue("design_price_type").ToString
                    TryCast(FormSalesReturnDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                    FormSalesReturnDet.GCItemList.RefreshDataSource()
                    FormSalesReturnDet.GVItemList.RefreshData()
                    FormSalesReturnDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                    FormSalesReturnDet.GVItemList.FocusedRowHandle = find_row(FormSalesReturnDet.GVItemList, "id_product", GVItemList.GetFocusedRowCellValue("id_product").ToString)
                    FormSalesReturnDet.codeAvailableIns(GVItemList.GetFocusedRowCellValue("id_product").ToString, GVItemList.GetFocusedRowCellValue("id_product").ToString, FormSalesReturnDet.id_store, GVItemList.GetFocusedRowCellValue("id_design_price").ToString)
                    FormSalesReturnDet.check_but()
                    Close()
                End If
            Else 'edit
                Dim is_duplicate As Boolean = False
                For i As Integer = 0 To (FormSalesReturnDet.GVItemList.RowCount - 1)
                    Dim id_product_cek As String = 0
                    Dim id_design_price_cek As String = "0"
                    Dim design_price_cek As Decimal = 0.0
                    Try
                        id_product_cek = FormSalesReturnDet.GVItemList.GetRowCellValue(i, "id_product").ToString
                        id_design_price_cek = FormSalesReturnDet.GVItemList.GetRowCellValue(i, "id_design_price").ToString
                        design_price_cek = Decimal.Parse(FormSalesReturnDet.GVItemList.GetRowCellValue(i, "design_price").ToString)
                    Catch ex As Exception

                    End Try
                    If id_product_cek = GVItemList.GetFocusedRowCellValue("id_product").ToString And id_design_price_cek = GVItemList.GetFocusedRowCellValue("id_design_price").ToString And design_price_cek = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price").ToString) And i <> indeks_edit Then
                        is_duplicate = True
                        Exit For
                    End If
                Next

                If is_duplicate Then
                    errorCustom("This product already exist in Delivery Item List !")
                Else
                    FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "id_sales_return_det", "0")
                    FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "id_sales_return_order_det", GVItemList.GetFocusedRowCellValue("id_sales_return_order_det").ToString)
                    FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "name", GVItemList.GetFocusedRowCellValue("name").ToString)
                    FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "code", GVItemList.GetFocusedRowCellValue("code").ToString)
                    FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "size", GVItemList.GetFocusedRowCellValue("size").ToString)
                    FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "sales_return_det_qty", GVItemList.GetFocusedRowCellValue("sales_return_det_qty"))
                    FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "qty_from_wh", GVItemList.GetFocusedRowCellValue("sales_return_det_qty"))
                    FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "id_design_price", GVItemList.GetFocusedRowCellValue("id_design_price").ToString)
                    FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "design_price", Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price")))
                    FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "sales_return_det_amount", amount.ToString)
                    FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "sales_return_order_det_note", GVItemList.GetFocusedRowCellValue("sales_return_order_det_note").ToString)
                    FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "id_design", GVItemList.GetFocusedRowCellValue("id_design").ToString)
                    FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "id_product", GVItemList.GetFocusedRowCellValue("id_product").ToString)
                    FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "id_sample", GVItemList.GetFocusedRowCellValue("id_sample").ToString)
                    FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "design_price_type", GVItemList.GetFocusedRowCellValue("design_price_type").ToString)
                    FormSalesReturnDet.GCItemList.RefreshDataSource()
                    FormSalesReturnDet.GVItemList.RefreshData()
                    FormSalesReturnDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                    FormSalesReturnDet.codeAvailableDel(GVItemList.GetFocusedRowCellValue("id_product").ToString)
                    FormSalesReturnDet.codeAvailableIns(GVItemList.GetFocusedRowCellValue("id_product").ToString, GVItemList.GetFocusedRowCellValue("id_product").ToString, FormSalesReturnDet.id_store, GVItemList.GetFocusedRowCellValue("id_design_price").ToString)
                    FormSalesReturnDet.check_but()
                    Close()
                End If
            End If
            'FormSalesReturnDet.allowScanPage()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesReturnOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesReturnOrder.FocusedRowChanged
        Dim id_sales_return_order As String = "0"
        Try
            id_sales_return_order = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
        Catch ex As Exception

        End Try
        If id_sales_return_order <> "0" Then
            BSave.Enabled = True
        Else
            BSave.Enabled = False
        End If
        viewListSalesReturnOrderDet(id_sales_return_order)
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        If id_sales_return_order <> "-1" Then
            Dim id_sales_return_order_det As String = "0"
            Try
                id_sales_return_order_det = GVItemList.GetFocusedRowCellValue("id_sales_return_order_det").ToString
            Catch ex As Exception

            End Try

            If id_sales_return_order_det = "0" Then
                BSave.Enabled = False
            Else
                BSave.Enabled = True
            End If
        End If
    End Sub
End Class