Public Class FormPopUpSalesOrder 
    Public id_pop_up As String = "-1"
    Public id_sales_order As String = "-1"
    Public id_sales_order_det As String = "-1"
    Public indeks_edit As Integer = 0

    Private Sub FormPopUpSalesOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GCSalesOrder.Focus()
        viewSalesOrder()
        If id_sales_order <> "-1" Then
            GVSalesOrder.FocusedRowHandle = find_row(GVSalesOrder, "id_sales_order", id_sales_order)
        End If
        If id_sales_order_det <> "-1" Then
            GVItemList.FocusedRowHandle = find_row(GVItemList, "id_sales_order_det", id_sales_order_det)
        End If
    End Sub

    Sub viewSalesOrder()
        Dim query_c As ClassSalesOrder = New ClassSalesOrder()
        Dim query As String = ""
        Dim cond As String = ""
        If id_pop_up = "1" Then
            cond += "AND a.id_report_status='6' AND a.id_prepare_status='1' AND a.id_so_status!=5 "
        ElseIf id_pop_up = "3" Then
            cond += "AND a.id_report_status='6' AND a.id_prepare_status='1' AND a.id_so_status=5 "
        ElseIf id_pop_up = "4" Then
            cond += "AND a.id_report_status='6' AND a.id_so_status!=5 And a.id_store_contact_to=" + FormSalesReturnOrderOLDet.id_store_contact_to + " "
        End If
        query = query_c.queryMain(cond, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesOrder.DataSource = data
        RepositoryItemProgressBar1.LookAndFeel.SkinName = "Blue"
    End Sub

    Sub viewListSalesOrderDet(ByVal id_sales_order As String)
        Dim query As String = ""
        If id_pop_up = "4" Then
            query = "CALL view_sales_order_ol_store('" + id_sales_order + "')"
        Else
            query = "CALL view_sales_order('" + id_sales_order + "')"
        End If

        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub FormPopUpSalesOrder_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    '1 : delivery order
    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        choose()
    End Sub

    Sub choose()
        Cursor = Cursors.WaitCursor
        If id_pop_up = "1" Then
            'SO
            FormSalesDelOrderDet.id_sales_order = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
            FormSalesDelOrderDet.TxtSalesOrder.Text = GVSalesOrder.GetFocusedRowCellValue("sales_order_number").ToString

            'store data
            Dim query_comp_to As String = "SELECT id_comp FROM tb_m_comp_contact WHERE id_comp_contact = '" + GVSalesOrder.GetFocusedRowCellValue("id_store_contact_to").ToString + "'"
            Dim id_comp_to As String = execute_query(query_comp_to, 0, True, "", "", "", "")
            FormSalesDelOrderDet.id_store_contact_to = GVSalesOrder.GetFocusedRowCellValue("id_store_contact_to").ToString
            FormSalesDelOrderDet.TxtCodeCompTo.Text = get_company_x(id_comp_to, 2)
            FormSalesDelOrderDet.TxtNameCompTo.Text = get_company_x(id_comp_to, 1)
            FormSalesDelOrderDet.MEAdrressCompTo.Text = get_company_x(id_comp_to, 3)
            FormSalesDelOrderDet.id_wh_drawer = GVSalesOrder.GetFocusedRowCellValue("id_wh_drawer").ToString
            FormSalesDelOrderDet.TxtDrawerCode.Text = GVSalesOrder.GetFocusedRowCellValue("wh_drawer_code").ToString
            FormSalesDelOrderDet.TxtDrawer.Text = GVSalesOrder.GetFocusedRowCellValue("wh_drawer").ToString

            'comp
            FormSalesDelOrderDet.id_comp_contact_from = GVSalesOrder.GetFocusedRowCellValue("id_warehouse_contact_to").ToString
            FormSalesDelOrderDet.TxtCodeCompFrom.Text = GVSalesOrder.GetFocusedRowCellValue("warehouse_number_to").ToString
            FormSalesDelOrderDet.TxtNameCompFrom.Text = GVSalesOrder.GetFocusedRowCellValue("warehouse").ToString

            'tipe & status SO
            FormSalesDelOrderDet.LETypeSO.ItemIndex = FormSalesDelOrderDet.LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", GVSalesOrder.GetFocusedRowCellValue("id_so_type").ToString)
            FormSalesDelOrderDet.LEStatusSO.ItemIndex = FormSalesDelOrderDet.LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", GVSalesOrder.GetFocusedRowCellValue("id_so_status").ToString)

            'general
            FormSalesDelOrderDet.dt.Clear()
            FormSalesDelOrderDet.viewDetail()
            FormSalesDelOrderDet.view_barcode_list()
            FormSalesDelOrderDet.setDefaultDrawer()
            FormSalesDelOrderDet.GroupControlListItem.Enabled = True
            FormSalesDelOrderDet.GroupControlScannedItem.Enabled = True
            FormSalesDelOrderDet.XTPOutboundScanNew.PageEnabled = True
            FormSalesDelOrderDet.BtnInfoSrs.Enabled = True
            FormSalesDelOrderDet.check_but()
            FormSalesDelOrderDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            'FormSalesDelOrderDet.BtnBrowseSO.Enabled = False
            Close()
        ElseIf id_pop_up = "2" Then
            Dim amount As Decimal = 0.0
            If id_sales_order_det = "-1" Then 'new
                'cek duplikat
                Dim is_duplicate As Boolean = False
                For i As Integer = 0 To (FormSalesDelOrderDet.GVItemList.RowCount - 1)
                    Dim id_product_cek As String = 0
                    Try
                        id_product_cek = FormSalesDelOrderDet.GVItemList.GetRowCellValue(i, "id_product").ToString
                    Catch ex As Exception

                    End Try
                    If id_product_cek = GVItemList.GetFocusedRowCellValue("id_product").ToString Then
                        'MsgBox(id_product_cek)
                        'MsgBox(GVItemList.GetFocusedRowCellValue("id_product").ToString)
                        is_duplicate = True
                        Exit For
                    End If
                Next

                If is_duplicate Then
                    errorCustom("This product already exist in Delivery Item List !")
                Else
                    Dim newRow As DataRow = (TryCast(FormSalesDelOrderDet.GCItemList.DataSource, DataTable)).NewRow()
                    newRow("id_pl_sales_order_del_det") = "0"
                    newRow("id_sales_order_det") = GVItemList.GetFocusedRowCellValue("id_sales_order_det").ToString
                    newRow("name") = GVItemList.GetFocusedRowCellValue("name").ToString
                    newRow("code") = GVItemList.GetFocusedRowCellValue("code").ToString
                    newRow("size") = GVItemList.GetFocusedRowCellValue("size").ToString
                    newRow("pl_sales_order_del_det_qty") = GVItemList.GetFocusedRowCellValue("qty_from_wh")
                    newRow("qty_from_wh") = GVItemList.GetFocusedRowCellValue("qty_from_wh")
                    newRow("id_design_price") = GVItemList.GetFocusedRowCellValue("id_design_price").ToString
                    newRow("design_price") = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price"))
                    newRow("pl_sales_order_del_det_amount") = Decimal.Parse(amount.ToString)
                    newRow("sales_order_det_note") = GVItemList.GetFocusedRowCellValue("sales_order_det_note").ToString
                    newRow("id_design") = GVItemList.GetFocusedRowCellValue("id_design").ToString
                    newRow("id_product") = GVItemList.GetFocusedRowCellValue("id_product").ToString
                    newRow("id_sample") = GVItemList.GetFocusedRowCellValue("id_sample").ToString
                    TryCast(FormSalesDelOrderDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                    FormSalesDelOrderDet.GCItemList.RefreshDataSource()
                    FormSalesDelOrderDet.GVItemList.RefreshData()
                    FormSalesDelOrderDet.GVItemList.ExpandAllGroups()
                    FormSalesDelOrderDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                    FormSalesDelOrderDet.GVItemList.FocusedRowHandle = find_row(FormSalesDelOrderDet.GVItemList, "id_product", GVItemList.GetFocusedRowCellValue("id_product").ToString)
                    FormSalesDelOrderDet.codeAvailableIns(GVItemList.GetFocusedRowCellValue("id_product").ToString)
                    Close()
                End If
            Else 'edit
                Dim is_duplicate As Boolean = False
                For i As Integer = 0 To (FormSalesDelOrderDet.GVItemList.RowCount - 1)
                    Dim id_product_cek As String = 0
                    Try
                        id_product_cek = FormSalesDelOrderDet.GVItemList.GetRowCellValue(i, "id_product").ToString
                    Catch ex As Exception

                    End Try
                    If id_product_cek = GVItemList.GetFocusedRowCellValue("id_product").ToString And i <> indeks_edit Then
                        is_duplicate = True
                        Exit For
                    End If
                Next

                If is_duplicate Then
                    errorCustom("This product already exist in Delivery Item List !")
                Else
                    FormSalesDelOrderDet.GVItemList.SetRowCellValue(FormSalesDelOrderDet.GVItemList.FocusedRowHandle, "id_pl_sales_order_del_det", "0")
                    FormSalesDelOrderDet.GVItemList.SetRowCellValue(FormSalesDelOrderDet.GVItemList.FocusedRowHandle, "id_sales_order_det", GVItemList.GetFocusedRowCellValue("id_sales_order_det").ToString)
                    FormSalesDelOrderDet.GVItemList.SetRowCellValue(FormSalesDelOrderDet.GVItemList.FocusedRowHandle, "name", GVItemList.GetFocusedRowCellValue("name").ToString)
                    FormSalesDelOrderDet.GVItemList.SetRowCellValue(FormSalesDelOrderDet.GVItemList.FocusedRowHandle, "code", GVItemList.GetFocusedRowCellValue("code").ToString)
                    FormSalesDelOrderDet.GVItemList.SetRowCellValue(FormSalesDelOrderDet.GVItemList.FocusedRowHandle, "size", GVItemList.GetFocusedRowCellValue("size").ToString)
                    FormSalesDelOrderDet.GVItemList.SetRowCellValue(FormSalesDelOrderDet.GVItemList.FocusedRowHandle, "pl_sales_order_del_det_qty", GVItemList.GetFocusedRowCellValue("qty_from_wh"))
                    FormSalesDelOrderDet.GVItemList.SetRowCellValue(FormSalesDelOrderDet.GVItemList.FocusedRowHandle, "qty_from_wh", GVItemList.GetFocusedRowCellValue("qty_from_wh"))
                    FormSalesDelOrderDet.GVItemList.SetRowCellValue(FormSalesDelOrderDet.GVItemList.FocusedRowHandle, "id_design_price", GVItemList.GetFocusedRowCellValue("id_design_price").ToString)
                    FormSalesDelOrderDet.GVItemList.SetRowCellValue(FormSalesDelOrderDet.GVItemList.FocusedRowHandle, "design_price", Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price")))
                    FormSalesDelOrderDet.GVItemList.SetRowCellValue(FormSalesDelOrderDet.GVItemList.FocusedRowHandle, "pl_sales_order_del_det_amount", amount.ToString)
                    FormSalesDelOrderDet.GVItemList.SetRowCellValue(FormSalesDelOrderDet.GVItemList.FocusedRowHandle, "sales_order_det_note", GVItemList.GetFocusedRowCellValue("sales_order_det_note").ToString)
                    FormSalesDelOrderDet.GVItemList.SetRowCellValue(FormSalesDelOrderDet.GVItemList.FocusedRowHandle, "id_design", GVItemList.GetFocusedRowCellValue("id_design").ToString)
                    FormSalesDelOrderDet.GVItemList.SetRowCellValue(FormSalesDelOrderDet.GVItemList.FocusedRowHandle, "id_product", GVItemList.GetFocusedRowCellValue("id_product").ToString)
                    FormSalesDelOrderDet.GVItemList.SetRowCellValue(FormSalesDelOrderDet.GVItemList.FocusedRowHandle, "id_sample", GVItemList.GetFocusedRowCellValue("id_sample").ToString)
                    FormSalesDelOrderDet.GCItemList.RefreshDataSource()
                    FormSalesDelOrderDet.GVItemList.RefreshData()
                    FormSalesDelOrderDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                    FormSalesDelOrderDet.codeAvailableDel(GVItemList.GetFocusedRowCellValue("id_product").ToString)
                    FormSalesDelOrderDet.codeAvailableIns(GVItemList.GetFocusedRowCellValue("id_product").ToString)
                    Close()
                End If
            End If
            FormSalesDelOrderDet.allowScanPage()
        ElseIf id_pop_up = "3" Then
            'SO
            FormFGTrfNewDet.id_sales_order = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
            FormFGTrfNewDet.TxtSalesOrder.Text = GVSalesOrder.GetFocusedRowCellValue("sales_order_number").ToString

            'store data
            Dim query_comp_to As String = "SELECT id_comp FROM tb_m_comp_contact WHERE id_comp_contact = '" + GVSalesOrder.GetFocusedRowCellValue("id_store_contact_to").ToString + "'"
            Dim id_comp_to As String = execute_query(query_comp_to, 0, True, "", "", "", "")
            FormFGTrfNewDet.id_comp_contact_to = GVSalesOrder.GetFocusedRowCellValue("id_store_contact_to").ToString
            FormFGTrfNewDet.TxtCodeCompTo.Text = get_company_x(id_comp_to, 2)
            FormFGTrfNewDet.TxtNameCompTo.Text = get_company_x(id_comp_to, 1)
            FormFGTrfNewDet.id_comp_to = id_comp_to

            'comp
            FormFGTrfNewDet.id_comp_contact_from = GVSalesOrder.GetFocusedRowCellValue("id_warehouse_contact_to").ToString
            FormFGTrfNewDet.TxtCodeCompFrom.Text = GVSalesOrder.GetFocusedRowCellValue("warehouse_number_to").ToString
            FormFGTrfNewDet.TxtNameCompFrom.Text = GVSalesOrder.GetFocusedRowCellValue("warehouse_name_to").ToString

            'general
            FormFGTrfNewDet.viewSalesOrderDetail()
            Close()
        ElseIf id_pop_up = "4" Then
            FormSalesReturnOrderOLDet.id_sales_order = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
            FormSalesReturnOrderOLDet.TxtOLStoreNumber.Text = GVSalesOrder.GetFocusedRowCellValue("sales_order_ol_shop_number").ToString
            Close()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesOrder.FocusedRowChanged
        Dim id_sales_order As String = "0"
        Try
            id_sales_order = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
        Catch ex As Exception

        End Try
        If id_sales_order <> "0" Then
            BSave.Enabled = True
        Else
            BSave.Enabled = False
        End If
        viewListSalesOrderDet(id_sales_order)
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        If id_sales_order <> "-1" Then
            Dim id_sales_order_det As String = "0"
            Try
                id_sales_order_det = GVItemList.GetFocusedRowCellValue("id_sales_order_det").ToString
            Catch ex As Exception

            End Try

            If id_sales_order_det = "0" Then
                BSave.Enabled = False
            Else
                BSave.Enabled = True
            End If
        End If
    End Sub

    Private Sub FormPopUpSalesOrder_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        GVSalesOrder.ShowFindPanel()
        GVSalesOrder.ShowFindPanel()
    End Sub

    Private Sub GVSalesOrder_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVSalesOrder.ColumnFilterChanged
        Dim id_sales_order As String = "0"
        Try
            id_sales_order = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
        Catch ex As Exception

        End Try
        If id_sales_order <> "0" Then
            BSave.Enabled = True
        Else
            BSave.Enabled = False
        End If
        viewListSalesOrderDet(id_sales_order)
    End Sub

    Private Sub GVSalesOrder_DoubleClick(sender As Object, e As EventArgs) Handles GVSalesOrder.DoubleClick
        If GVSalesOrder.RowCount > 0 And GVSalesOrder.FocusedRowHandle >= 0 Then
            choose()
        End If
    End Sub
End Class