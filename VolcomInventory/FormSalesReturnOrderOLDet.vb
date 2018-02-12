Public Class FormSalesReturnOrderOLDet
    Public id_sales_return_order As String = ""
    Public id_store As String = "-1"
    Public id_store_contact_to As String = "-1"
    Public id_wh_contact_to As String = "-1"
    Public id_sales_order As String = "-1"
    Public action As String = "-1"
    Public id_report_status As String
    Public id_wh_drawer As String = "-1"
    Public is_view = "-1"
    Dim store_address As String = ""
    Public is_print As String = "-1"
    Public is_detail_soh As String = "-1"


    Private Sub FormSalesReturnOrderOLDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            TxtSalesOrderNumber.Text = ""
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            DEForm.Text = view_date(0)
            Dim data As DataTable = execute_query("SELECT DATE(NOW()) AS `tgl`", -1, True, "", "", "", "")
            DERetDueDate.EditValue = data.Rows(0)("tgl")
            ActiveControl = TxtStoreCode
        ElseIf action = "upd" Then
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BMark.Enabled = True

            'query view based on edit id's
            Dim ro As New ClassSalesReturnOrder()
            Dim query As String = ro.queryMain("AND a.id_sales_return_order=" + id_sales_return_order + " ", "1")
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_store_contact_to = data.Rows(0)("id_store_contact_to").ToString
            id_wh_contact_to = data.Rows(0)("id_wh_contact_to").ToString
            TxtStoreName.Text = data.Rows(0)("store_name_to").ToString
            TxtStoreCode.Text = data.Rows(0)("store_number_to").ToString
            store_address = data.Rows(0)("store_address").ToString
            TxtWHName.Text = data.Rows(0)("wh_name_to").ToString
            TxtWHCode.Text = data.Rows(0)("wh_number_to").ToString
            TxtOLStoreNumber.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
            DEForm.Text = view_date_from(data.Rows(0)("sales_return_order_datex").ToString, 0)
            TxtSalesOrderNumber.Text = data.Rows(0)("sales_return_order_number").ToString
            MENote.Text = data.Rows(0)("sales_return_order_note").ToString
            DERetDueDate.EditValue = data.Rows(0)("sales_return_order_est_date")
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            If is_detail_soh <> "-1" Then
                GridColumnRemark.Visible = False
                GridColumnAmount.Visible = False
                GridColumnPrice.Visible = False
                GridColumnPriceType.Visible = False
                GridColumnQty.Visible = True
                GridColumnNo.VisibleIndex = 0
                GridColumnCode.VisibleIndex = 1
                GridColumnName.VisibleIndex = 2
                GridColumnSize.VisibleIndex = 3
                GridColumnQty.VisibleIndex = 4
                GridColumnQty.Caption = "Order"
                GridColumnQtyReturn.VisibleIndex = 5
            End If

            'detail2
            viewDetail()
            checkStockAvail()
            noEdit()
            check_but()
            allow_status()

            If is_print = "1" Then
                printOrder()
                Close()
            End If
        End If
    End Sub

    Sub viewDetail()
        If is_detail_soh <> "-1" Then
            Dim query As String = "CALL view_sales_return_order_limit('" + id_sales_return_order + "',0,0)"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            GCItemList.DataSource = data
        Else
            Dim query As String = "CALL view_sales_return_order('" + id_sales_return_order + "')"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            GCItemList.DataSource = data
        End If
    End Sub

    Sub checkStockAvail()
        'If id_report_status = "1" Then
        '    Dim dt As DataTable = execute_query("CALL view_stock_fg('" + id_comp + "', '" + id_wh_locator + "', '" + id_wh_rack + "', '" + id_wh_drawer + "', '0', '4', '9999-01-01') ", -1, True, "", "", "", "")
        '    For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
        '        Dim data_filter As DataRow() = dt.Select("[code]='" + GVItemList.GetRowCellValue(i, "code") + "' ")
        '        Dim qty As Integer = 0
        '        If data_filter.Length = 0 Then
        '            qty = 0
        '        Else
        '            qty = data_filter(0)("qty_all_product")
        '        End If
        '        GVItemList.SetRowCellValue(i, "qty_avail", qty)
        '    Next
        'End If
    End Sub

    Sub noEdit()
        'If GVItemList.FocusedRowHandle >= 0 Then
        '    Dim id_sales_return_order_det_cek As String = GVItemList.GetFocusedRowCellValue("id_sales_return_order_det").ToString
        '    If id_sales_return_order_det_cek = "0" Then
        '        GVItemList.Columns("code").OptionsColumn.AllowEdit = True
        '        GVItemList.Columns("sales_return_order_det_qty").OptionsColumn.AllowEdit = True
        '    Else
        '        GVItemList.Columns("code").OptionsColumn.AllowEdit = False
        '        GVItemList.Columns("sales_return_order_det_qty").OptionsColumn.AllowEdit = False
        '    End If
        'End If
    End Sub

    Sub check_but()
        'Dim id_productx As String = "0"
        'Try
        '    id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        'Catch ex As Exception

        'End Try

        ''MsgBox("main :" + id_productx)

        ''Constraint Status
        'If GVItemList.RowCount > 0 And id_productx <> "0" Then
        '    BtnEdit.Enabled = True
        '    BtnDel.Enabled = True
        'Else
        '    BtnEdit.Enabled = False
        '    BtnDel.Enabled = False
        'End If
    End Sub

    Sub allow_status()
        BtnBrowseOrder.Enabled = False
        BtnBrowseStore.Enabled = False
        BtnBrowseWH.Enabled = False
        BtnSave.Enabled = False
        PanelControlNav.Enabled = False
        MENote.Properties.ReadOnly = True
        DERetDueDate.Enabled = False
        TxtStoreCode.Properties.ReadOnly = True
        TxtWHCode.Properties.ReadOnly = True
        TxtOLStoreNumber.Properties.ReadOnly = True

        If check_attach_report_status(id_report_status, "119", id_sales_return_order) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
        TxtSalesOrderNumber.Focus()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_sales_return_order
        FormReportMark.report_mark_type = "119"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.is_view = is_view
        FormDocumentUpload.id_report = id_sales_return_order
        FormDocumentUpload.report_mark_type = "119"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub printOrder()
        Cursor = Cursors.WaitCursor
        ReportSalesReturnOrder.id_sales_return_order = id_sales_return_order
        ReportSalesReturnOrder.dt = GCItemList.DataSource
        Dim Report As New ReportSalesReturnOrder()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GridView1)

        'Parse val
        Report.LRecNumber.Text = TxtSalesOrderNumber.Text
        Report.LRecDate.Text = DEForm.Text
        Report.LabelTo.Text = TxtStoreCode.Text + " - " + TxtStoreName.Text
        Report.LabelWH.Text = TxtWHCode.Text + " - " + TxtWHName.Text
        Report.LabelOLStoreOrder.Text = TxtOLStoreNumber.Text
        Report.LabelAddress.Text = store_address
        Report.LabelEstReturn.Text = DERetDueDate.Text
        Report.LabelNote.Text = MENote.Text


        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        printOrder()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSalesReturnOrderOLDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnBrowseStore_Click(sender As Object, e As EventArgs) Handles BtnBrowseStore.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_cat = "6"
        FormPopUpContact.id_pop_up = "81"
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowseWH_Click(sender As Object, e As EventArgs) Handles BtnBrowseWH.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_cat = "5"
        FormPopUpContact.id_pop_up = "82"
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowseOrder_Click(sender As Object, e As EventArgs) Handles BtnBrowseOrder.Click
        show_order()
    End Sub

    Sub show_order()
        Cursor = Cursors.WaitCursor
        FormPopUpSalesOrder.id_pop_up = "4"
        FormPopUpSalesOrder.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormSalesReturnOrderOLSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub delNotFoundMyRow()
        GVItemList.ActiveFilterString = "[is_found]='2'"
        Dim i As Integer = GVItemList.RowCount - 1
        While (i >= 0)
            GVItemList.DeleteRow(i)
            i = i - 1
        End While
        makeSafeGV(GVItemList)
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        GVItemList.CloseEditor()
        makeSafeGV(GVItemList)
        ValidateChildren()

        'del not found
        delNotFoundMyRow()

        'check stock
        Cursor = Cursors.WaitCursor
        Dim cond_data As Boolean = True
        Dim dt As DataTable = execute_query("CALL view_stock_ol_store2('" + id_sales_order + "'," + id_store + ")", -1, True, "", "", "", "")
        For c As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
            Dim id_product_cek As String = GVItemList.GetRowCellValue(c, "id_product").ToString
            Dim qty_cek As Integer = GVItemList.GetRowCellValue(c, "sales_return_order_det_qty")
            Dim data_filter_cek As DataRow() = dt.Select("[id_product]='" + id_product_cek + "' ")
            If data_filter_cek.Length <= 0 Then
                GVItemList.SetRowCellValue(c, "error_status", "Product not found;")
                cond_data = False
            Else
                If qty_cek > data_filter_cek(0)("qty") Then
                    GVItemList.SetRowCellValue(c, "error_status", "Qty can't exceed " + data_filter_cek(0)("qty").ToString + ";")
                    cond_data = False
                Else
                    GVItemList.SetRowCellValue(c, "error_status", "")
                End If
            End If
        Next
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        Cursor = Cursors.Default

        If id_store_contact_to = "-1" Or id_wh_contact_to = "-1" Then
            stopCustom("Store/WH can't blank ")
        ElseIf GVItemList.RowCount <= 0 Then
            stopCustom("Item list can't blank !")
        ElseIf Not cond_data Then
            stopCustom("Please see error log in item list !")
            GridColumnErr.Visible = True
            GridColumnErr.VisibleIndex = 100
        Else
            GridColumnErr.Visible = False
            Dim sales_return_order_number As String = TxtSalesOrderNumber.Text
            Dim sales_return_order_note As String = MENote.Text
            Dim sales_return_order_est_date As String = DateTime.Parse(DERetDueDate.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim id_report_status As String = LEReportStatus.EditValue

            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    'Main tbale
                    Dim query As String = "INSERT INTO tb_sales_return_order(id_store_contact_to, id_wh_contact_to, id_sales_order, sales_return_order_number, sales_return_order_date, sales_return_order_note, id_report_status, sales_return_order_est_date) "
                    query += "VALUES('" + id_store_contact_to + "','" + id_wh_contact_to + "', '" + id_sales_order + "', '" + header_number_sales("4") + "', NOW(), '" + sales_return_order_note + "', '" + id_report_status + "', '" + sales_return_order_est_date + "'); SELECT LAST_INSERT_ID(); "
                    id_sales_return_order = execute_query(query, 0, True, "", "", "", "")
                    increase_inc_sales("4")

                    'insert who prepared
                    insert_who_prepared("119", id_sales_return_order, id_user)

                    'Detail 
                    Dim jum_ins_i As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT INTO tb_sales_return_order_det(id_sales_return_order, id_product, id_design_price, design_price, sales_return_order_det_qty, sales_return_order_det_note, id_return_cat) VALUES "
                    End If
                    For i As Integer = 0 To (GVItemList.RowCount - 1)
                        Try
                            Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                            Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                            Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                            Dim sales_return_order_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sales_return_order_det_qty").ToString)
                            Dim sales_return_order_det_note As String = GVItemList.GetRowCellValue(i, "sales_return_order_det_note").ToString
                            Dim id_return_cat As String = "1"

                            If jum_ins_i > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_sales_return_order + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_return_order_det_qty + "', '" + sales_return_order_det_note + "', '" + id_return_cat + "')"
                            jum_ins_i = jum_ins_i + 1
                        Catch ex As Exception
                        End Try
                    Next
                    If jum_ins_i > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'reserved qty
                    Dim ro As New ClassSalesReturnOrder
                    ro.reservedStock(id_sales_return_order)

                    FormSalesReturnOrderOL.viewSalesReturnOrder()
                    FormSalesReturnOrderOL.GVSalesReturnOrder.FocusedRowHandle = find_row(FormSalesReturnOrderOL.GVSalesReturnOrder, "id_sales_return_order", id_sales_return_order)
                    action = "upd"
                    actionLoad()
                    infoCustom("Document #" + TxtSalesOrderNumber.Text + " was created successfully.")
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                'cant update
            End If
        End If
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        If GVItemList.RowCount > 0 And GVItemList.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
                CType(GCItemList.DataSource, DataTable).AcceptChanges()
                GCItemList.RefreshDataSource()
                GVItemList.RefreshData()
                check_but()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub TxtStoreCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtStoreCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim data As DataTable = get_company_by_code(addSlashes(TxtStoreCode.Text), "AND comp.id_comp_cat=6 AND comp.id_commerce_type=2 ")
            If data.Rows.Count = 0 Then
                stopCustom("Account not found !")
                resetStore(True)
                resetOrder(True)
                TxtStoreCode.Focus()
            Else
                id_store = data.Rows(0)("id_comp").ToString
                id_store_contact_to = data.Rows(0)("id_comp_contact").ToString
                TxtStoreCode.Text = data.Rows(0)("comp_number").ToString
                TxtStoreName.Text = data.Rows(0)("comp_name").ToString
                id_wh_drawer = data.Rows(0)("id_drawer_def").ToString
                resetOrder(True)
                viewDetail()
                check_but()
                TxtWHCode.Focus()
            End If
        Else
            resetStore(False)
            resetOrder(True)
        End If
    End Sub

    Sub resetStore(ByVal include_code As Boolean)
        id_store = "-1"
        id_store_contact_to = "-1"
        TxtStoreName.Text = ""
        id_wh_drawer = "-1"
        If GVItemList.RowCount > 0 Then
            viewDetail()
        End If
        If include_code Then
            TxtStoreCode.Text = ""
        End If
    End Sub

    Private Sub TxtWHCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtWHCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim data As DataTable = get_company_by_code(addSlashes(TxtWHCode.Text), "AND comp.id_comp_cat=5 ")
            If data.Rows.Count = 0 Then
                stopCustom("Account not found !")
                resetWH(True)
                TxtWHCode.Focus()
            Else
                id_wh_contact_to = data.Rows(0)("id_comp_contact").ToString
                TxtWHCode.Text = data.Rows(0)("comp_number").ToString
                TxtWHName.Text = data.Rows(0)("comp_name").ToString
                check_but()
                TxtOLStoreNumber.Focus()
            End If
        Else
            resetWH(False)
        End If
    End Sub

    Sub resetWH(ByVal include_code As Boolean)
        id_wh_contact_to = "-1"
        TxtWHName.Text = ""
        If include_code Then
            TxtWHCode.Text = ""
        End If
    End Sub

    Private Sub DERetDueDate_KeyDown(sender As Object, e As KeyEventArgs) Handles DERetDueDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            addMyRow()
        End If
    End Sub

    Sub addMyRow()
        Cursor = Cursors.WaitCursor
        Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
        newRow("code") = ""
        newRow("name") = ""
        newRow("size") = ""
        newRow("sales_return_order_det_qty") = 0
        newRow("amount") = 0
        newRow("design_price_type") = ""
        newRow("design_price") = 0
        newRow("sales_return_order_det_note") = ""
        newRow("id_design") = "0"
        newRow("id_product") = "0"
        newRow("id_design_price") = "0"
        newRow("id_sales_return_order_det") = "0"
        newRow("is_found") = "2"
        newRow("error_status") = ""
        TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
        'CType(GCItemList.DataSource, DataTable).AcceptChanges()
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        check_but()
        GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
        GCItemList.Focus()
        GVItemList.FocusedColumn = GridColumnCode
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAddLine_Click(sender As Object, e As EventArgs) Handles BtnAddLine.Click
        addMyRow()
    End Sub

    Sub setDefautMyRow(ByVal rh As Integer)
        GVItemList.SetRowCellValue(rh, "id_sales_return_order_det", "0")
        GVItemList.SetRowCellValue(rh, "name", "")
        GVItemList.SetRowCellValue(rh, "code", "")
        GVItemList.SetRowCellValue(rh, "size", "")
        GVItemList.SetRowCellValue(rh, "sales_return_order_det_qty", 0)
        GVItemList.SetRowCellValue(rh, "qty_avail", 0)
        GVItemList.SetRowCellValue(rh, "design_price_type", "")
        GVItemList.SetRowCellValue(rh, "id_design_price", "0")
        GVItemList.SetRowCellValue(rh, "design_price", 0)
        GVItemList.SetRowCellValue(rh, "id_return_cat", "1")
        GVItemList.SetRowCellValue(rh, "amount", 0)
        GVItemList.SetRowCellValue(rh, "sales_return_order_det_note", "")
        GVItemList.SetRowCellValue(rh, "id_design", "0")
        GVItemList.SetRowCellValue(rh, "id_product", "0")
        GVItemList.SetRowCellValue(rh, "is_found", "2")
        GVItemList.SetRowCellValue(rh, "error_status", "")
    End Sub

    Private Sub GVItemList_KeyDown(sender As Object, e As KeyEventArgs) Handles GVItemList.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim rh As Integer = GVItemList.FocusedRowHandle
            Dim id_sales_return_order_det As String = GVItemList.GetRowCellValue(rh, "id_sales_return_order_det").ToString
            If id_sales_return_order_det = "0" Then
                If GVItemList.FocusedColumn.ToString = "Code" Then
                    GVItemList.CloseEditor()
                    Dim code_pas As String = addSlashes(GVItemList.GetRowCellValue(rh, "code").ToString)
                    Dim dt As DataTable = execute_query("CALL view_stock_ol_store2('" + id_sales_order + "'," + id_store + ")", -1, True, "", "", "", "")
                    Dim data_filter As DataRow() = dt.Select("[code]='" + code_pas + "' ")
                    If data_filter.Length = 0 Then
                        stopCustom("Product not found !")
                        setDefautMyRow(rh)
                        CType(GCItemList.DataSource, DataTable).AcceptChanges()
                    Else
                        Dim dt_dupe As DataTable = GCItemList.DataSource
                        Dim data_filter_dupe As DataRow() = dt_dupe.Select("[code]='" + code_pas + "' ")
                        If data_filter_dupe.Length <= 0 Then
                            GVItemList.SetRowCellValue(rh, "id_sales_return_order_det", "0")
                            GVItemList.SetRowCellValue(rh, "name", data_filter(0)("name").ToString)
                            GVItemList.SetRowCellValue(rh, "code", data_filter(0)("code").ToString)
                            GVItemList.SetRowCellValue(rh, "size", data_filter(0)("size").ToString)
                            GVItemList.SetRowCellValue(rh, "sales_return_order_det_qty", 0)
                            GVItemList.SetRowCellValue(rh, "qty_avail", data_filter(0)("qty"))
                            GVItemList.SetRowCellValue(rh, "design_price_type", data_filter(0)("design_price_type").ToString)
                            GVItemList.SetRowCellValue(rh, "id_design_price", data_filter(0)("id_design_price").ToString)
                            GVItemList.SetRowCellValue(rh, "design_price", data_filter(0)("design_price"))
                            GVItemList.SetRowCellValue(rh, "id_return_cat", "1")
                            GVItemList.SetRowCellValue(rh, "return_cat", "Return")
                            GVItemList.SetRowCellValue(rh, "amount", 0)
                            GVItemList.SetRowCellValue(rh, "sales_return_order_det_note", "")
                            GVItemList.SetRowCellValue(rh, "id_design", data_filter(0)("id_design").ToString)
                            GVItemList.SetRowCellValue(rh, "id_product", data_filter(0)("id_product").ToString)
                            GVItemList.SetRowCellValue(rh, "is_found", "1")
                            GVItemList.SetRowCellValue(rh, "error_status", "")
                            GVItemList.FocusedColumn = GridColumnQty
                            CType(GCItemList.DataSource, DataTable).AcceptChanges()
                        Else
                            GVItemList.SetFocusedRowCellValue("code", "")
                            GVItemList.ActiveFilterString = "[code]='" + code_pas + "'"
                            FormSalesOrderDetEdit.id_pop_up = "2"
                            FormSalesOrderDetEdit.ShowDialog()
                            GVItemList.ActiveFilterString = ""
                            GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
                            GVItemList.FocusedColumn = GridColumnCode
                            'stopCustom("You already entry this product.")
                            'setDefautMyRow(rh)
                            'CType(GCItemList.DataSource, DataTable).AcceptChanges()
                        End If
                    End If
                ElseIf GVItemList.FocusedColumn.ToString = "Qty" Then
                    GVItemList.CloseEditor()
                    Dim qty_par As Integer = GVItemList.GetRowCellValue(rh, "sales_return_order_det_qty")
                    Dim qty_limit As Integer = GVItemList.GetRowCellValue(rh, "qty_avail")
                    If qty_par > qty_limit Then
                        stopCustom("Qty can't exceed " + qty_limit.ToString)
                        GVItemList.SetRowCellValue(rh, "sales_return_order_det_qty", 0)
                    Else
                        GVItemList.SetRowCellValue(rh, "amount", qty_par * GVItemList.GetRowCellValue(rh, "design_price"))
                        GVItemList.FocusedColumn = GridColumnRemark
                    End If
                ElseIf GVItemList.FocusedColumn.ToString = "Remark" Then 'for remark
                    GVItemList.CloseEditor()
                    If GVItemList.GetRowCellValue(GVItemList.RowCount - 1, "code").ToString <> "" Then
                        addMyRow()
                    End If
                    GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
                    GVItemList.FocusedColumn = GridColumnCode
                End If
            End If
        End If
    End Sub

    Private Sub TxtOLStoreNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtOLStoreNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query_c As ClassSalesOrder = New ClassSalesOrder()
            Dim cond As String = "AND a.sales_order_ol_shop_number='" + addSlashes(TxtOLStoreNumber.Text) + "' AND a.id_report_status='6' AND a.id_so_status!=5 And a.id_store_contact_to=" + id_store_contact_to + " "
            Dim query As String = query_c.queryMain(cond, "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count = 0 Then
                stopCustom("Order not found !")
                resetOrder(True)
                TxtOLStoreNumber.Focus()
            ElseIf data.Rows.Count > 1 Then
                TxtOLStoreNumber.Text = ""
                show_order()
            Else
                id_sales_order = data.Rows(0)("id_sales_order").ToString
                TxtOLStoreNumber.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
                check_but()
                DERetDueDate.Focus()
            End If
        Else
            resetOrder(False)
        End If
    End Sub

    Sub resetOrder(ByVal include_order As Boolean)
        id_sales_order = "-1"
        If include_order Then
            TxtOLStoreNumber.Text = ""
        End If
    End Sub
End Class