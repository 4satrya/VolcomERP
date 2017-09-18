Public Class FormSalesReturnOrderDet 
    Public action As String
    Public id_sales_return_order As String = "-1"
    Public id_store_contact_to As String = "-1"
    Public id_report_status As String
    Public id_sales_return_order_det_list As New List(Of String)
    Dim date_start As Date
    Public id_comp As String = "-1"

    Public id_wh_drawer As String = "-1"
    Public id_wh_rack As String = "-1"
    Public id_wh_locator As String = "-1"
    Dim id_prepare_status As String = "-1"

    Private Sub FormSalesReturnOrderDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
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
        ElseIf action = "upd" Then
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BtnBrowseContactTo.Enabled = False
            BMark.Enabled = True

            'query view based on edit id's
            Dim query As String = "SELECT d.id_comp, a.id_sales_return_order, a.id_store_contact_to, getCompByContact(a.id_store_contact_to, 4) AS `id_wh_drawer_store`, getCompByContact(a.id_store_contact_to, 6) AS `id_wh_rack_store`, getCompByContact(a.id_store_contact_to, 7) AS `id_wh_locator_store`, (d.comp_name) AS store_name_to, (d.comp_number) AS store_number_to, (d.address_primary) AS store_address_to, a.id_report_status, f.report_status, "
            query += "a.sales_return_order_note, a.sales_return_order_date, a.sales_return_order_note, a.sales_return_order_number, "
            query += "DATE_FORMAT(a.sales_return_order_date,'%Y-%m-%d') AS sales_return_order_datex, a.sales_return_order_est_date, a.id_prepare_status "
            query += "FROM tb_sales_return_order a "
            query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
            query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
            query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
            query += "WHERE a.id_sales_return_order = '" + id_sales_return_order + "' "
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_store_contact_to = data.Rows(0)("id_store_contact_to").ToString
            id_comp = data.Rows(0)("id_comp").ToString
            id_wh_drawer = data.Rows(0)("id_wh_drawer_store").ToString
            id_wh_rack = data.Rows(0)("id_wh_rack_store").ToString
            id_wh_locator = data.Rows(0)("id_wh_locator_store").ToString
            TxtNameCompTo.Text = data.Rows(0)("store_name_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("store_number_to").ToString
            MEAdrressCompTo.Text = data.Rows(0)("store_address_to").ToString
            DEForm.Text = view_date_from(data.Rows(0)("sales_return_order_datex").ToString, 0)
            TxtSalesOrderNumber.Text = data.Rows(0)("sales_return_order_number").ToString
            MENote.Text = data.Rows(0)("sales_return_order_note").ToString
            DERetDueDate.EditValue = data.Rows(0)("sales_return_order_est_date")
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_prepare_status = data.Rows(0)("id_prepare_status").ToString
            'detail2
            viewDetail()
            checkStockAvail()
            noEdit()
            check_but()
            allow_status()
        End If
    End Sub

    Sub checkStockAvail()
        If id_report_status = "1" Then
            Dim dt As DataTable = execute_query("CALL view_stock_fg('" + id_comp + "', '" + id_wh_locator + "', '" + id_wh_rack + "', '" + id_wh_drawer + "', '0', '4', '9999-01-01') ", -1, True, "", "", "", "")
            For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                Dim data_filter As DataRow() = dt.Select("[code]='" + GVItemList.GetRowCellValue(i, "code") + "' ")
                Dim qty As Integer = 0
                If data_filter.Length = 0 Then
                    qty = 0
                Else
                    qty = data_filter(0)("qty_all_product")
                End If
                GVItemList.SetRowCellValue(i, "qty_avail", qty)
            Next
        End If
    End Sub


    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_sales_return_order('" + id_sales_return_order + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        If action = "ins" Then
            'action
        ElseIf action = "upd" Then
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sales_return_order_det_list.Add(data.Rows(i)("id_sales_return_order_det").ToString)
            Next
        End If
        GCItemList.DataSource = data
    End Sub

    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompTo)
        EPForm.SetIconPadding(TxtNameCompTo, 30)
    End Sub

    Private Sub DERetDueDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DERetDueDate.Validating
        EP_DE_cant_blank(EPForm, DERetDueDate)
    End Sub

    Private Sub DERetDueDate_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DERetDueDate.EditValueChanged
        ' Try
        date_start = execute_query("select now()", 0, True, "", "", "", "")
        DERetDueDate.Properties.MinValue = date_start
        'Catch ex As Exception

        'End Try
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

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        GVItemList.CloseEditor()
        makeSafeGV(GVItemList)
        ValidateChildren()

        'del not found
        delNotFoundMyRow()

        If Not formIsValidInPanel(EPForm, PanelControlTopLeft) Or Not formIsValidInPanel(EPForm, PanelControlTopRight) Then
            errorInput()
        ElseIf GVItemList.RowCount <= 0 Then
            stopCustom("Item list can't blank !")
        Else
            Dim sales_return_order_number As String = TxtSalesOrderNumber.Text
            Dim sales_return_order_note As String = MENote.Text
            Dim sales_return_order_est_date As String = DateTime.Parse(DERetDueDate.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim id_report_status As String = LEReportStatus.EditValue

            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        'Main tbale
                        Dim query As String = "INSERT INTO tb_sales_return_order(id_store_contact_to, sales_return_order_number, sales_return_order_date, sales_return_order_note, id_report_status, sales_return_order_est_date) "
                        query += "VALUES('" + id_store_contact_to + "', '" + header_number_sales("4") + "', NOW(), '" + sales_return_order_note + "', '" + id_report_status + "', '" + sales_return_order_est_date + "'); SELECT LAST_INSERT_ID(); "
                        id_sales_return_order = execute_query(query, 0, True, "", "", "", "")
                        increase_inc_sales("4")

                        'insert who prepared
                        insert_who_prepared("45", id_sales_return_order, id_user)

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
                                Dim id_return_cat As String = GVItemList.GetRowCellValue(i, "id_return_cat").ToString

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

                        FormSalesReturnOrder.viewSalesReturnOrder()
                        FormSalesReturnOrder.GVSalesReturnOrder.FocusedRowHandle = find_row(FormSalesReturnOrder.GVSalesReturnOrder, "id_sales_return_order", id_sales_return_order)
                        action = "upd"
                        actionLoad()
                        infoCustom("Document #" + TxtSalesOrderNumber.Text + " was created successfully.")
                    Catch ex As Exception
                        errorConnection()
                        Close()
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data changes ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        Dim query As String = "UPDATE tb_sales_return_order SET id_store_contact_to='" + id_store_contact_to + "', sales_return_order_number = '" + sales_return_order_number + "', sales_return_order_note='" + sales_return_order_note + "', sales_return_order_est_date = '" + sales_return_order_est_date + "' WHERE id_sales_return_order='" + id_sales_return_order + "' "
                        execute_non_query(query, True, "", "", "", "")

                        'edit detail table
                        Dim jum_ins_i As Integer = 0
                        Dim query_detail As String = ""
                        If GVItemList.RowCount > 0 Then
                            query_detail = "INSERT INTO tb_sales_return_order_det(id_sales_return_order, id_product, id_design_price, design_price, sales_return_order_det_qty, sales_return_order_det_note, id_return_cat) VALUES "
                        End If
                        For i As Integer = 0 To (GVItemList.RowCount - 1)
                            Try
                                Dim id_sales_return_order_det As String = GVItemList.GetRowCellValue(i, "id_sales_return_order_det").ToString
                                Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                                Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                                Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                                Dim sales_return_order_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sales_return_order_det_qty").ToString)
                                Dim sales_return_order_det_note As String = GVItemList.GetRowCellValue(i, "sales_return_order_det_note").ToString
                                Dim id_return_cat As String = GVItemList.GetRowCellValue(i, "id_return_cat").ToString

                                If id_sales_return_order_det = "0" Then
                                    If jum_ins_i > 0 Then
                                        query_detail += ", "
                                    End If
                                    query_detail += "('" + id_sales_return_order + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_return_order_det_qty + "', '" + sales_return_order_det_note + "', '" + id_return_cat + "')"
                                    jum_ins_i = jum_ins_i + 1
                                Else
                                    Dim query_edit As String = "UPDATE tb_sales_return_order_det SET id_product = '" + id_product + "', id_design_price='" + id_design_price + "', design_price = '" + design_price + "', sales_return_order_det_qty = '" + sales_return_order_det_qty + "', sales_return_order_det_note='" + sales_return_order_det_note + "', id_return_cat = '" + id_return_cat + "' WHERE id_sales_return_order_det = '" + id_sales_return_order_det + "' "
                                    execute_non_query(query_edit, True, "", "", "", "")
                                    id_sales_return_order_det_list.Remove(id_sales_return_order_det)
                                End If
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next
                        If jum_ins_i > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If

                        'delete sisa
                        For k As Integer = 0 To (id_sales_return_order_det_list.Count - 1)
                            Try
                                Dim querydel As String = "DELETE FROM tb_sales_return_order_det WHERE id_sales_return_order_det = '" + id_sales_return_order_det_list(k) + "' "
                                execute_non_query(querydel, True, "", "", "", "")
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next

                        FormSalesReturnOrder.viewSalesReturnOrder()
                        FormSalesReturnOrder.GVSalesReturnOrder.FocusedRowHandle = find_row(FormSalesReturnOrder.GVSalesReturnOrder, "id_sales_return_order", id_sales_return_order)
                        action = "upd"
                        actionLoad()
                        infoCustom("Document #" + TxtSalesOrderNumber.Text + " was edited successfully.")
                    Catch ex As Exception
                        errorConnection()
                        Close()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    'sub check_but
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
        If check_edit_report_status(id_report_status, "45", id_sales_return_order) Then
            PanelControlNav.Enabled = True
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = True
            DERetDueDate.Enabled = True
            TxtCodeCompTo.Properties.ReadOnly = True
        Else
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = True
            BtnSave.Enabled = False
            DERetDueDate.Enabled = False
            TxtCodeCompTo.Properties.ReadOnly = True
        End If

        If id_report_status = "6" Then
            GCItemList.ContextMenuStrip = ContextMenuStrip1
        Else
            GCItemList.ContextMenuStrip = Nothing
        End If

        If check_attach_report_status(id_report_status, "45", id_sales_return_order) Then
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

    Sub noEdit()
        If GVItemList.FocusedRowHandle >= 0 Then
            Dim id_sales_return_order_det_cek As String = GVItemList.GetFocusedRowCellValue("id_sales_return_order_det").ToString
            If id_sales_return_order_det_cek = "0" Then
                GVItemList.Columns("code").OptionsColumn.AllowEdit = True
                GVItemList.Columns("sales_return_order_det_qty").OptionsColumn.AllowEdit = True
            Else
                GVItemList.Columns("code").OptionsColumn.AllowEdit = False
                GVItemList.Columns("sales_return_order_det_qty").OptionsColumn.AllowEdit = False
            End If
        End If
    End Sub

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactTo.Click
        FormPopUpContact.id_pop_up = "40"
        FormPopUpContact.id_cat = "6"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to cancel data changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Close()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormSalesReturnOrderDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        addRow()
        GCItemList.Focus()
        GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
        GVItemList.FocusedColumn = GridColumnCode
        'FormSalesReturnOrderSingle.action_pop = "ins"
        'FormSalesReturnOrderSingle.id_product = "0"
        'FormSalesReturnOrderSingle.id_comp = id_comp
        'FormSalesReturnOrderSingle.id_wh_locator = id_wh_locator
        'FormSalesReturnOrderSingle.id_wh_rack = id_wh_rack
        'FormSalesReturnOrderSingle.id_wh_drawer = id_wh_drawer
        'Dim end_period As String = "9999-01-01"
        'FormSalesReturnOrderSingle.date_param = end_period
        'FormSalesReturnOrderSingle.ShowDialog()
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        check_but()
        noEdit()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click

    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        delRow()
    End Sub

    Sub delRow()
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

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        For i As Integer = 0 To (GVItemList.RowCount - 1)
            Try
                Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                MsgBox(id_product)
            Catch ex As Exception

            End Try
        Next
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_sales_return_order
        FormReportMark.report_mark_type = "45"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
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
        Report.LabelTo.Text = TxtCodeCompTo.Text + " - " + TxtNameCompTo.Text
        Report.LabelAddress.Text = MEAdrressCompTo.Text
        Report.LabelEstReturn.Text = DERetDueDate.Text
        Report.LabelNote.Text = MENote.Text


        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sales_return_order
        FormDocumentUpload.report_mark_type = "45"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        If id_comp <> "-1" Then
            Cursor = Cursors.WaitCursor
            FormImportExcel.id_pop_up = "11"
            FormImportExcel.ShowDialog()
            Cursor = Cursors.Default
        Else
            stopCustom("Please select store/destination first !")
        End If
    End Sub

    Private Sub BtnAddMultiple_Click(sender As Object, e As EventArgs) Handles BtnAddMultiple.Click
        Cursor = Cursors.WaitCursor
        FormSalesReturnOrderSingleV2.id_product = "0"
        FormSalesReturnOrderSingleV2.id_comp = id_comp
        FormSalesReturnOrderSingleV2.id_wh_locator = id_wh_locator
        FormSalesReturnOrderSingleV2.id_wh_rack = id_wh_rack
        FormSalesReturnOrderSingleV2.id_wh_drawer = id_wh_drawer
        FormSalesReturnOrderSingleV2.date_param = "9999-01-01"
        FormSalesReturnOrderSingleV2.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtCodeCompTo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim data As DataTable = get_company_by_code(TxtCodeCompTo.Text, "AND comp.id_comp_cat=6 ")
            If data.Rows.Count = 0 Then
                stopCustom("Account not found !")
                id_comp = "-1"
                id_store_contact_to = "-1"
                id_wh_drawer = "-1"
                id_wh_rack = "-1"
                id_wh_locator = "-1"
                TxtNameCompTo.Text = ""
                TxtCodeCompTo.Text = ""
                MEAdrressCompTo.Text = ""
                viewDetail()
                check_but()
                TxtCodeCompTo.Focus()
            Else
                id_comp = data.Rows(0)("id_comp").ToString
                id_store_contact_to = data.Rows(0)("id_comp_contact").ToString
                id_wh_drawer = data.Rows(0)("id_drawer_def").ToString
                id_wh_rack = data.Rows(0)("id_wh_rack").ToString
                id_wh_locator = data.Rows(0)("id_wh_locator").ToString
                TxtNameCompTo.Text = data.Rows(0)("comp_name").ToString
                TxtCodeCompTo.Text = data.Rows(0)("comp_number").ToString
                MEAdrressCompTo.Text = data.Rows(0)("address_primary").ToString
                viewDetail()
                check_but()
                DERetDueDate.Focus()
            End If
        End If
    End Sub

    Private Sub DERetDueDate_KeyDown(sender As Object, e As KeyEventArgs) Handles DERetDueDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            addRow()
            GCItemList.Focus()
        End If
    End Sub

    Private Sub BtnImport2_Click(sender As Object, e As EventArgs) Handles BtnImport2.Click
        If id_comp <> "-1" Then
            Cursor = Cursors.WaitCursor
            FormImportExcel.id_pop_up = "29"
            FormImportExcel.ShowDialog()
            Cursor = Cursors.Default
        Else
            stopCustom("Please select store/destination first !")
        End If
    End Sub

    Private Sub FormSalesReturnOrderDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

    End Sub

    Sub addRow()
        Cursor = Cursors.WaitCursor
        Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
        newRow("id_sales_return_order_det") = "0"
        newRow("name") = ""
        newRow("code") = ""
        newRow("size") = ""
        newRow("sales_return_order_det_qty") = 0
        newRow("qty_avail") = 0
        newRow("design_price_type") = ""
        newRow("id_design_price") = "0"
        newRow("design_price") = 0
        newRow("id_return_cat") = "1"
        newRow("return_cat") = "Return"
        newRow("amount") = 0
        newRow("sales_return_order_det_note") = ""
        newRow("id_design") = "0"
        newRow("id_product") = "0"
        newRow("id_sample") = "0"
        newRow("is_found") = "2"
        newRow("error_status") = ""
        TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        check_but()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVItemList.FocusedColumnChanged
        Try
            If e.FocusedColumn.ToString = GVItemList.Columns("no").ToString Then
                GVItemList.FocusedColumn = GridColumnCode
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVItemList_KeyDown(sender As Object, e As KeyEventArgs) Handles GVItemList.KeyDown
        'If (e.KeyCode = Keys.N AndAlso e.Modifiers = Keys.Control) Then
        '    addRow()
        '    GCItemList.Focus()
        '    GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
        '    GVItemList.FocusedColumn = GridColumnCode
        'ElseIf (e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control) Then
        '    delRow()
        If e.KeyCode = Keys.Enter Then
            Dim rh As Integer = GVItemList.FocusedRowHandle
            Dim id_sales_return_order_det As String = GVItemList.GetRowCellValue(rh, "id_sales_return_order_det").ToString
            If id_sales_return_order_det = "0" Then
                If GVItemList.FocusedColumn.ToString = "Code" Then
                    GVItemList.CloseEditor()
                    Dim code_pas As String = addSlashes(GVItemList.GetRowCellValue(rh, "code").ToString)
                    Dim dt As DataTable = execute_query("CALL view_stock_fg('" + id_comp + "', '" + id_wh_locator + "', '" + id_wh_rack + "', '" + id_wh_drawer + "', '0', '4', '9999-01-01') ", -1, True, "", "", "", "")
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
                            GVItemList.SetRowCellValue(rh, "qty_avail", data_filter(0)("qty_all_product"))
                            GVItemList.SetRowCellValue(rh, "design_price_type", "")
                            GVItemList.SetRowCellValue(rh, "id_design_price", data_filter(0)("id_design_price_retail").ToString)
                            GVItemList.SetRowCellValue(rh, "design_price", data_filter(0)("design_price_retail"))
                            GVItemList.SetRowCellValue(rh, "id_return_cat", "1")
                            GVItemList.SetRowCellValue(rh, "return_cat", "Return")
                            GVItemList.SetRowCellValue(rh, "amount", 0)
                            GVItemList.SetRowCellValue(rh, "sales_return_order_det_note", "")
                            GVItemList.SetRowCellValue(rh, "id_design", data_filter(0)("id_design").ToString)
                            GVItemList.SetRowCellValue(rh, "id_product", data_filter(0)("id_product").ToString)
                            GVItemList.SetRowCellValue(rh, "id_sample", data_filter(0)("id_sample").ToString)
                            GVItemList.SetRowCellValue(rh, "is_found", "1")
                            GVItemList.SetRowCellValue(rh, "error_status", "")
                            GVItemList.FocusedColumn = GridColumnQty
                            CType(GCItemList.DataSource, DataTable).AcceptChanges()
                        Else
                            GVItemList.SetFocusedRowCellValue("code", "")
                            GVItemList.ActiveFilterString = "[code]='" + code_pas + "'"
                            FormSalesOrderDetEdit.id_pop_up = "1"
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
                        addRow()
                    End If
                    GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
                    GVItemList.FocusedColumn = GridColumnCode
                End If
            End If
        End If
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
        GVItemList.SetRowCellValue(rh, "return_cat", "Return")
        GVItemList.SetRowCellValue(rh, "amount", 0)
        GVItemList.SetRowCellValue(rh, "sales_return_order_det_note", "")
        GVItemList.SetRowCellValue(rh, "id_design", "0")
        GVItemList.SetRowCellValue(rh, "id_product", "0")
        GVItemList.SetRowCellValue(rh, "id_sample", "0")
        GVItemList.SetRowCellValue(rh, "is_found", "2")
        GVItemList.SetRowCellValue(rh, "error_status", "")
    End Sub

    Private Sub AddAnotherProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAnotherProductToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If id_prepare_status = "1" Then
            FormSalesReturnOrderDetEdit.ShowDialog()
        Else
            stopCustom("Return Order already closed")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ReviseQtyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReviseQtyToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If id_prepare_status = "1" Then
            If GVItemList.RowCount > 0 And GVItemList.FocusedRowHandle >= 0 Then
                FormSalesReturnOrderRevise.id_sales_return_order = id_sales_return_order
                FormSalesReturnOrderRevise.id_sales_return_order_det = GVItemList.GetFocusedRowCellValue("id_sales_return_order_det").ToString
                FormSalesReturnOrderRevise.id_product = GVItemList.GetFocusedRowCellValue("id_product").ToString
                FormSalesReturnOrderRevise.ShowDialog()
            End If
        Else
            stopCustom("Return Order already closed")
        End If
        Cursor = Cursors.Default
    End Sub
End Class