Imports Microsoft.Office.Interop

Public Class FormSalesOrderDet
    Public action As String
    Public id_sales_order As String = "-1"
    Public id_store_contact_to As String = "-1"
    Public id_store As String = "-1"
    Public id_store_cat As String = "-1"
    Public id_report_status As String
    Public id_sales_order_det_list As New List(Of String)
    Public id_so_type As String = "0"
    Public id_comp_contact_par As String = "-1"
    Public id_comp_par As String = "-1"
    Dim id_comp_cat_wh As String = "-1"
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_so As String = get_setup_field("bof_xls_so")
    Public dt As DataTable

    Private Sub FormSalesOrderDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        id_comp_cat_wh = get_setup_field("id_comp_cat_wh")
        viewReportStatus()
        viewSoType()
        viewSoStatus()
        actionLoad()

        'packing status invisible
        LabelControl4.Visible = False
        TxtPackingStatus.Visible = False
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub getDataReference()
        Try
            dt.Clear()
        Catch ex As Exception
        End Try
        Dim query As String = "CALL view_sales_order_prod_list('0', '" + id_comp_par + "', '" + id_store + "')"
        dt = execute_query(query, -1, True, "", "", "", "")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            TxtPackingStatus.Text = "-"
            TxtSalesOrderNumber.Text = ""
            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            BMark.Enabled = False
            DEForm.Text = view_date(0)
            viewDetail(id_sales_order)
            noEdit()
            check_but()
        ElseIf action = "upd" Then
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BMark.Enabled = True

            'query view based on edit id's
            Dim query As String = "SELECT a.id_so_status, a.id_sales_order, a.id_store_contact_to, (d.id_comp) AS id_store,(d.comp_name) AS store_name_to, (d.comp_number) AS store_number_to, (d.address_primary) AS store_address_to, a.id_warehouse_contact_to, (wh.id_comp) AS id_comp_par,(wh.comp_name) AS warehouse_name_to, (wh.comp_number) AS warehouse_number_to, a.id_report_status, f.report_status, "
            query += "a.sales_order_note, a.sales_order_date, a.sales_order_note, a.sales_order_number, "
            query += "DATE_FORMAT(a.sales_order_date,'%Y-%m-%d') AS sales_order_datex, a.id_so_type, IFNULL(an.fg_so_reff_number,'-') AS `fg_so_reff_number`, ps.id_prepare_status, ps.prepare_status "
            query += "FROM tb_sales_order a "
            query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
            query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
            query += "INNER JOIN tb_m_comp_contact wh_c ON wh_c.id_comp_contact = a.id_warehouse_contact_to "
            query += "INNER JOIN tb_m_comp wh ON wh_c.id_comp = wh.id_comp "
            query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
            query += "INNER JOIN tb_lookup_so_type g ON g.id_so_type = a.id_so_type "
            query += "INNER JOIN tb_lookup_so_status h ON h.id_so_status = a.id_so_status "
            query += "LEFT JOIN tb_fg_so_reff an ON an.id_fg_so_reff = a.id_fg_so_reff "
            query += "INNER JOIN tb_lookup_prepare_status ps ON ps.id_prepare_status = a.id_prepare_status "
            query += "WHERE a.id_sales_order = '" + id_sales_order + "' "
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtReff.Text = data.Rows(0)("fg_so_reff_number").ToString

            id_store = data.Rows(0)("id_store").ToString
            id_store_contact_to = data.Rows(0)("id_store_contact_to").ToString
            TxtNameCompTo.Text = data.Rows(0)("store_name_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("store_number_to").ToString
            MEAdrressCompTo.Text = data.Rows(0)("store_address_to").ToString

            id_comp_par = data.Rows(0)("id_comp_par").ToString
            id_comp_contact_par = data.Rows(0)("id_warehouse_contact_to").ToString
            TxtWHCodeTo.Text = data.Rows(0)("warehouse_number_to").ToString
            TxtWHNameTo.Text = data.Rows(0)("warehouse_name_to").ToString

            DEForm.Text = view_date_from(data.Rows(0)("sales_order_datex").ToString, 0)
            TxtSalesOrderNumber.Text = data.Rows(0)("sales_order_number").ToString
            MENote.Text = data.Rows(0)("sales_order_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)
            LEStatusSO.ItemIndex = LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", data.Rows(0)("id_so_status").ToString)
            TxtPackingStatus.Text = data.Rows(0)("prepare_status").ToString
            'detail2
            viewDetail(id_sales_order)
            noEdit()
            getDataReference()
            check_but()
            allow_status()
        End If
    End Sub

    Sub viewSoType()
        Dim query As String = "SELECT * FROM tb_lookup_so_type a ORDER BY a.id_so_type "
        viewLookupQuery(LETypeSO, query, 0, "so_type", "id_so_type")
    End Sub

    Sub viewSoStatus()
        Dim query As String = "SELECT a.id_so_status, a.so_status FROM tb_lookup_so_status a "
        query += "INNER JOIN tb_lookup_so_status_acc b ON a.id_so_status = b.id_so_status "
        query += "WHERE b.id_departement='" + id_departement_user + "' "
        query += "ORDER BY a.id_so_status "
        viewLookupQuery(LEStatusSO, query, 0, "so_status", "id_so_status")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail(ByVal id_sales_order_par As String)
        Dim query As String = "CALL view_sales_order('" + id_sales_order_par + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        If action = "ins" Then
            'action
        ElseIf action = "upd" Then
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sales_order_det_list.Add(data.Rows(i)("id_sales_order_det").ToString)
            Next
        End If
        GCItemList.DataSource = data
    End Sub

    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompTo)
        EPForm.SetIconPadding(TxtNameCompTo, 28)
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        GVItemList.CloseEditor()
        BtnSave.Focus()
        makeSafeGV(GVItemList)
        ValidateChildren()

        'del not found
        delNotFoundMyRow()

        'check stock
        Dim cond_data As Boolean = True
        getDataReference()
        For c As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
            Dim id_product_cek As String = GVItemList.GetRowCellValue(c, "id_product").ToString
            Dim qty_cek As Integer = GVItemList.GetRowCellValue(c, "sales_order_det_qty")
            Dim id_sales_order_det As String = GVItemList.GetRowCellValue(c, "id_sales_order_det").ToString
            If id_sales_order_det = "0" Then
                Dim data_filter_cek As DataRow() = dt.Select("[id_product]='" + id_product_cek + "' ")
                If data_filter_cek.Length <= 0 Then
                    GVItemList.SetRowCellValue(c, "error_status", "Product not found;")
                    cond_data = False
                Else
                    If qty_cek > data_filter_cek(0)("total_allow") Then
                        GVItemList.SetRowCellValue(c, "error_status", "Qty can't exceed " + data_filter_cek(0)("total_allow").ToString + ";")
                        cond_data = False
                    Else
                        GVItemList.SetRowCellValue(c, "error_status", "")
                    End If
                End If
            End If
        Next
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()

        'check account trf
        Dim cond_cat_trf As Boolean = True
        If id_store_cat = "5" And LEStatusSO.EditValue.ToString <> "5" Then
            cond_cat_trf = False
        End If

        'check account store
        Dim cond_cat_str As Boolean = True
        If id_store_cat <> "5" And LEStatusSO.EditValue.ToString = "5" Then
            cond_cat_str = False
        End If

        If Not formIsValidInPanel(EPForm, PanelControlTopLeft) Or Not formIsValidInPanel(EPForm, PanelControlTopMain) Then
            errorInput()
        ElseIf Not cond_data Then
            stopCustom("Please see error log in item list !")
            GridColumnErr.Visible = True
            GridColumnErr.VisibleIndex = 100
        ElseIf Not cond_cat_trf Then
            stopCustom("Please select category 'Transfer' !")
        ElseIf Not cond_cat_str Then
            stopCustom("Transfer order can't process, please select another category !")
        Else
            Dim sales_order_note As String = MENote.Text
            Dim id_so_type As String = LETypeSO.EditValue.ToString
            Dim id_so_status As String = LEStatusSO.EditValue.ToString
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim sales_order_number As String = ""

            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    sales_order_number = header_number_sales("2")
                    'Main tbale
                    Dim query As String = "INSERT INTO tb_sales_order(id_store_contact_to, id_warehouse_contact_to, sales_order_number, sales_order_date, sales_order_note, id_so_type, id_report_status, id_so_status, id_user_created) "
                    query += "VALUES('" + id_store_contact_to + "', '" + id_comp_contact_par + "', '" + sales_order_number + "', NOW(), '" + sales_order_note + "', '" + id_so_type + "', '" + id_report_status + "', '" + id_so_status + "', '" + id_user + "'); SELECT LAST_INSERT_ID(); "
                    id_sales_order = execute_query(query, 0, True, "", "", "", "")

                    increase_inc_sales("2")

                    'insert who prepared
                    insert_who_prepared("39", id_sales_order, id_user)

                    'Detail 
                    Dim query_detail As String = ""
                    Dim jum_ins_j As Integer = 0
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT INTO tb_sales_order_det(id_sales_order, id_product, id_design_price, design_price, sales_order_det_qty, sales_order_det_note) VALUES "
                    End If
                    For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Try
                            Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                            Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                            Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                            Dim sales_order_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sales_order_det_qty").ToString)
                            Dim sales_order_det_note As String = GVItemList.GetRowCellValue(i, "sales_order_det_note").ToString

                            If jum_ins_j > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_sales_order + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_order_det_qty + "', '" + sales_order_det_note + "')"
                            jum_ins_j = jum_ins_j + 1
                        Catch ex As Exception
                        End Try
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'reserved
                    Dim rsv As New ClassSalesOrder()
                    rsv.reservedStock(id_sales_order)

                    FormSalesOrder.viewSalesOrder()
                    FormSalesOrder.viewDet()
                    FormSalesOrder.GVSalesOrder.FocusedRowHandle = find_row(FormSalesOrder.GVSalesOrder, "id_sales_order", id_sales_order)
                    action = "upd"
                    actionLoad()

                    'gen xls
                    exportToBOF(False)

                    infoCustom("Prepare order : " + sales_order_number.ToString + " was created successfully. ")
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    sales_order_number = TxtSalesOrderNumber.Text
                    Dim query As String = "UPDATE tb_sales_order SET id_store_contact_to='" + id_store_contact_to + "', id_warehouse_contact_to='" + id_comp_contact_par + "', sales_order_number = '" + sales_order_number + "', sales_order_note='" + sales_order_note + "', id_so_type='" + id_so_type + "', id_so_status = '" + id_so_status + "' WHERE id_sales_order='" + id_sales_order + "' "
                    execute_non_query(query, True, "", "", "", "")

                    'edit detail table
                    Dim query_detail As String = ""
                    Dim jum_ins_j As Integer = 0
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT INTO tb_sales_order_det(id_sales_order, id_product, id_design_price, design_price, sales_order_det_qty, sales_order_det_note) VALUES "
                    End If
                    For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Try
                            Dim id_sales_order_det As String = GVItemList.GetRowCellValue(i, "id_sales_order_det").ToString
                            Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                            Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                            Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                            Dim sales_order_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sales_order_det_qty").ToString)
                            Dim sales_order_det_note As String = GVItemList.GetRowCellValue(i, "sales_order_det_note").ToString
                            If id_sales_order_det = "0" Then
                                If jum_ins_j > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "('" + id_sales_order + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_order_det_qty + "', '" + sales_order_det_note + "')"
                                jum_ins_j = jum_ins_j + 1
                            Else
                                Dim query_edit As String = "UPDATE tb_sales_order_det SET id_product = '" + id_product + "', id_design_price='" + id_design_price + "', design_price = '" + design_price + "', sales_order_det_qty = '" + sales_order_det_qty + "', sales_order_det_note='" + sales_order_det_note + "' WHERE id_sales_order_det = '" + id_sales_order_det + "' "
                                execute_non_query(query_edit, True, "", "", "", "")
                                id_sales_order_det_list.Remove(id_sales_order_det)
                            End If
                        Catch ex As Exception
                            ex.ToString()
                        End Try
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'delete sisa
                    For k As Integer = 0 To (id_sales_order_det_list.Count - 1)
                        Try
                            Dim querydel As String = "DELETE FROM tb_sales_order_det WHERE id_sales_order_det = '" + id_sales_order_det_list(k) + "' "
                            execute_non_query(querydel, True, "", "", "", "")
                        Catch ex As Exception
                            ex.ToString()
                        End Try
                    Next

                    FormSalesOrder.viewSalesOrder()
                    FormSalesOrder.viewDet()
                    FormSalesOrder.GVSalesOrder.FocusedRowHandle = find_row(FormSalesOrder.GVSalesOrder, "id_sales_order", id_sales_order)
                    action = "upd"
                    actionLoad()

                    'gen xls
                    exportToBOF(False)

                    infoCustom("Prepare order : " + sales_order_number.ToString + " was edited successfully. ")
                    Cursor = Cursors.Default
                End If
            End If

            'hide col err
            GridColumnErr.Visible = False
        End If
        Cursor = Cursors.Default
    End Sub

    'sub check_but
    Sub check_but()
        'Dim id_productx As String = "0"
        'Try
        '    id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        'Catch ex As Exception

        'End Try

        ''MsgBox("main :" + id_productx)

        'Constraint Status
        If GVItemList.RowCount > 0 Then
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "39", id_sales_order) Then
            BtnBrowseContactTo.Enabled = False
            BtnBrowseWH.Enabled = False
            GVItemList.OptionsBehavior.Editable = True
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = True
            LETypeSO.Enabled = False
            LEStatusSO.Enabled = True
            TxtCodeCompTo.Enabled = False
            TxtWHCodeTo.Enabled = False
        Else
            BtnBrowseContactTo.Enabled = False
            BtnBrowseWH.Enabled = False
            GVItemList.OptionsBehavior.Editable = False
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = True
            BtnSave.Enabled = False
            LETypeSO.Enabled = False
            LEStatusSO.Enabled = False
            TxtCodeCompTo.Enabled = False
            TxtWHCodeTo.Enabled = False
        End If

        'attachment
        If check_attach_report_status(id_report_status, "39", id_sales_order) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        If id_report_status <> "5" And bof_column = "1" Then
            BtnXlsBOF.Visible = True
        Else
            BtnXlsBOF.Visible = False
        End If
        TxtSalesOrderNumber.Focus()
    End Sub

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactTo.Click
        FormPopUpContact.id_pop_up = "38"
        FormPopUpContact.id_so_type = id_so_type
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSalesOrderDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormSalesOrderSingle.action_pop = "ins"
        FormSalesOrderSingle.ShowDialog()
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
        FormSalesOrderSingle.action_pop = "upd"
        FormSalesOrderSingle.indeks_edit = GVItemList.FocusedRowHandle()
        FormSalesOrderSingle.id_product_edit = GVItemList.GetFocusedRowCellValue("id_product").ToString
        FormSalesOrderSingle.product_code = GVItemList.GetFocusedRowCellValue("code").ToString
        FormSalesOrderSingle.id_design_price_edit = GVItemList.GetFocusedRowCellValue("id_design_price")
        FormSalesOrderSingle.qty_edit = GVItemList.GetFocusedRowCellValue("sales_order_det_qty")
        FormSalesOrderSingle.remark_edit = GVItemList.GetFocusedRowCellValue("sales_order_det_note").ToString
        FormSalesOrderSingle.ShowDialog()
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        delMyRow()
    End Sub

    Public Sub delAllList(ByVal rh_par As Integer)
        For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
            GVItemList.DeleteRow(i)
        Next
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        'For i As Integer = 0 To (GVItemList.RowCount - 1)
        '    Try
        '        Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
        '        MsgBox(id_product)
        '    Catch ex As Exception

        '    End Try
        'Next
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_sales_order
        FormReportMark.report_mark_type = "39"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportSalesOrder.dt = GCItemList.DataSource
        ReportSalesOrder.id_sales_order = id_sales_order
        Dim Report As New ReportSalesOrder()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVSalesOrder.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVSalesOrder)

        'Parse val
        Report.LabelTo.Text = TxtCodeCompTo.Text + "-" + TxtNameCompTo.Text
        Report.LabelWarehouse.Text = TxtWHCodeTo.Text + "-" + TxtWHNameTo.Text
        Report.LabelCategory.Text = LEStatusSO.Text
        Report.LabelReff.Text = TxtReff.Text
        Report.LRecDate.Text = DEForm.Text
        Report.LRecNumber.Text = TxtSalesOrderNumber.Text
        Report.LabelNote.Text = MENote.Text
        Report.LabelType.Text = LETypeSO.Text

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sales_order
        FormDocumentUpload.report_mark_type = "39"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseWH.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "62"
        FormPopUpContact.id_cat = id_comp_cat_wh
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAddV2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddV2.Click
        If id_comp_par = "-1" Or id_store = "-1" Then
            stopCustom("Please select warehouse and store first !")
        Else
            Cursor = Cursors.WaitCursor
            FormSalesOrderSingleV2.id_wh_par = id_comp_par
            FormSalesOrderSingleV2.id_store_par = id_store
            FormSalesOrderSingleV2.data_par = GCItemList.DataSource
            FormSalesOrderSingleV2.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub LETypeSO_EditValueChanged(sender As Object, e As EventArgs) Handles LETypeSO.EditValueChanged
        id_so_type = LETypeSO.EditValue.ToString
        If action = "ins" Then
            id_store_contact_to = ""
            TxtCodeCompTo.Text = ""
            TxtNameCompTo.Text = ""
            MEAdrressCompTo.Text = ""
        End If
    End Sub

    Private Sub TxtCodeCompTo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim id_so_type As String = LETypeSO.EditValue.ToString
            Dim query_cond As String = ""
            If id_so_type <> "0" Then
                query_cond = "AND comp.id_so_type='" + id_so_type + "' AND (comp.id_comp_cat=2 OR comp.id_comp_cat=5 OR comp.id_comp_cat=6) "
            Else
                query_cond = "AND (comp.id_so_type='" + id_so_type + "' OR ISNULL(comp.id_so_type)) AND (comp.id_comp_cat=2 OR comp.id_comp_cat=5 OR comp.id_comp_cat=6) "
            End If
            Dim data As DataTable = get_company_by_code(TxtCodeCompTo.Text, query_cond)
            If data.Rows.Count = 0 Then
                stopCustom("Account not found!")
                viewDetail("-1")
                id_store = "-1"
                id_store_cat = "-1"
                id_store_contact_to = "-1"
                TxtNameCompTo.Text = ""
                MEAdrressCompTo.Text = ""
                TxtCodeCompTo.Focus()
            Else
                Cursor = Cursors.WaitCursor
                viewDetail("-1")
                noEdit()
                id_store = data.Rows(0)("id_comp").ToString
                id_store_cat = data.Rows(0)("id_comp_cat").ToString
                id_store_contact_to = data.Rows(0)("id_comp_contact").ToString
                TxtNameCompTo.Text = data.Rows(0)("comp_name").ToString
                MEAdrressCompTo.Text = data.Rows(0)("address_primary").ToString
                TxtWHCodeTo.Focus()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub TxtWHCodeTo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtWHCodeTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim data As DataTable = get_company_by_code(TxtWHCodeTo.Text, "AND id_comp_cat = '" + id_comp_cat_wh + "' ")
            If data.Rows.Count = 0 Then
                stopCustom("Warehouse not found!")
                viewDetail("-1")
                id_comp_par = "-1"
                id_comp_contact_par = "-1"
                TxtWHNameTo.Text = ""
                TxtWHCodeTo.Focus()
            Else
                Cursor = Cursors.WaitCursor
                viewDetail("-1")
                noEdit()
                id_comp_par = data.Rows(0)("id_comp").ToString
                id_comp_contact_par = data.Rows(0)("id_comp_contact").ToString
                TxtWHNameTo.Text = data.Rows(0)("comp_name").ToString
                getDataReference()
                LEStatusSO.Focus()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnAddV3_Click(sender As Object, e As EventArgs) Handles BtnAddV3.Click
        Cursor = Cursors.WaitCursor
        addMyRow()
        GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
        GCItemList.Focus()
        GVItemList.FocusedColumn = GridColumnCode
        Cursor = Cursors.Default
    End Sub

    Sub addMyRow()
        Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
        newRow("id_sales_order_det") = "0"
        newRow("name") = ""
        newRow("code") = ""
        newRow("size") = ""
        newRow("sales_order_det_qty") = 0
        newRow("id_design_price") = 0
        newRow("design_price") = 0
        newRow("design_price_type") = ""
        newRow("amount") = 0
        newRow("qty_avail") = 0
        newRow("sales_order_det_note") = ""
        newRow("id_design") = "0"
        newRow("id_product") = "0"
        newRow("id_sample") = "0"
        newRow("is_found") = "2"
        newRow("error_status") = ""
        TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
        'CType(GCItemList.DataSource, DataTable).AcceptChanges()
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        check_but()
    End Sub

    Sub delMyRow()
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            If action = "ins" Then
                Cursor = Cursors.WaitCursor
                GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
                CType(GCItemList.DataSource, DataTable).AcceptChanges()
                GCItemList.RefreshDataSource()
                GVItemList.RefreshData()
                check_but()
                Cursor = Cursors.Default
            ElseIf action = "upd" Then
                Cursor = Cursors.WaitCursor
                Dim id_sales_order_det_par As String = GVItemList.GetFocusedRowCellValue("id_sales_order_det").ToString
                If id_sales_order_det_par = "0" Then
                    GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
                    CType(GCItemList.DataSource, DataTable).AcceptChanges()
                    GCItemList.RefreshDataSource()
                    GVItemList.RefreshData()
                    check_but()
                Else
                    Try
                        Dim query_del As String = "DELETE FROM tb_sales_order_det WHERE id_sales_order_det='" + id_sales_order_det_par + "' "
                        execute_non_query(query_del, True, "", "", "", "")
                        FormSalesOrder.viewDet()
                        GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
                        CType(GCItemList.DataSource, DataTable).AcceptChanges()
                        GCItemList.RefreshDataSource()
                        GVItemList.RefreshData()
                        check_but()
                        getDataReference()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub LEStatusSO_KeyDown(sender As Object, e As KeyEventArgs) Handles LEStatusSO.KeyDown
        If e.KeyCode = Keys.Enter Then
            addMyRow()
            GCItemList.Focus()
        End If
    End Sub

    Private Sub GVItemList_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVItemList.FocusedColumnChanged
        Try
            If e.FocusedColumn.ToString = GVItemList.Columns("no").ToString Then
                GVItemList.FocusedColumn = GridColumnCode
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub GVItemList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVItemList.CellValueChanged

    End Sub

    Private Sub GVItemList_KeyDown(sender As Object, e As KeyEventArgs) Handles GVItemList.KeyDown
        If (e.KeyCode = Keys.N AndAlso e.Modifiers = Keys.Control) Then
            addMyRow()
            GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
            GVItemList.FocusedColumn = GridColumnCode
        ElseIf (e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control) Then
            If GVItemList.RowCount > 0 And GVItemList.FocusedRowHandle >= 0 Then
                delMyRow()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            Dim rh As Integer = GVItemList.FocusedRowHandle
            Dim id_sales_order_det As String = GVItemList.GetRowCellValue(rh, "id_sales_order_det").ToString
            If id_sales_order_det = "0" Then
                If GVItemList.FocusedColumn.ToString = "Code" Then
                    GVItemList.CloseEditor()
                    Dim code_pas As String = GVItemList.GetRowCellValue(rh, "code").ToString
                    Dim data_filter As DataRow() = dt.Select("[product_full_code]='" + code_pas + "' ")
                    If data_filter.Length = 0 Then
                        stopCustom("Product not found !")
                        setDefautMyRow(rh)
                        CType(GCItemList.DataSource, DataTable).AcceptChanges()
                    Else
                        Dim dt_dupe As DataTable = GCItemList.DataSource
                        Dim data_filter_dupe As DataRow() = dt_dupe.Select("[code]='" + code_pas + "' AND [is_found]='1' ")
                        If data_filter_dupe.Length <= 0 Then
                            GVItemList.SetRowCellValue(rh, "id_sales_order_det", "0")
                            GVItemList.SetRowCellValue(rh, "name", data_filter(0)("design_display_name").ToString)
                            GVItemList.SetRowCellValue(rh, "size", data_filter(0)("Size").ToString)
                            GVItemList.SetRowCellValue(rh, "sales_order_det_qty", 0)
                            GVItemList.SetRowCellValue(rh, "id_design_price", data_filter(0)("id_design_price").ToString)
                            GVItemList.SetRowCellValue(rh, "design_price", data_filter(0)("design_price"))
                            GVItemList.SetRowCellValue(rh, "design_price_type", data_filter(0)("design_price_type").ToString)
                            GVItemList.SetRowCellValue(rh, "amount", 0)
                            GVItemList.SetRowCellValue(rh, "qty_avail", data_filter(0)("total_allow"))
                            GVItemList.SetRowCellValue(rh, "sales_order_det_note", "")
                            GVItemList.SetRowCellValue(rh, "id_design", data_filter(0)("id_design").ToString)
                            GVItemList.SetRowCellValue(rh, "id_product", data_filter(0)("id_product").ToString)
                            GVItemList.SetRowCellValue(rh, "id_sample", data_filter(0)("id_sample").ToString)
                            GVItemList.SetRowCellValue(rh, "is_found", "1")
                            GVItemList.SetRowCellValue(rh, "error_status", "")
                            GVItemList.FocusedColumn = GridColumnQty
                            CType(GCItemList.DataSource, DataTable).AcceptChanges()
                        Else
                            stopCustom("You already entry this product.")
                            setDefautMyRow(rh)
                            CType(GCItemList.DataSource, DataTable).AcceptChanges()
                        End If
                    End If
                ElseIf GVItemList.FocusedColumn.ToString = "Qty" Then
                    GVItemList.CloseEditor()
                    Dim qty_par As Integer = GVItemList.GetRowCellValue(rh, "sales_order_det_qty")
                    Dim qty_limit As Integer = GVItemList.GetRowCellValue(rh, "qty_avail")
                    If qty_par > qty_limit Then
                        stopCustom("Qty can't exceed " + qty_limit.ToString)
                        GVItemList.SetRowCellValue(rh, "sales_order_det_qty", 0)
                    Else
                        GVItemList.SetRowCellValue(rh, "amount", qty_par * GVItemList.GetRowCellValue(rh, "design_price"))
                        GVItemList.FocusedColumn = GridColumnRemark
                    End If
                ElseIf GVItemList.FocusedColumn.ToString = "Remark" Then 'for remark
                    GVItemList.CloseEditor()
                    addMyRow()
                    GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
                    GVItemList.FocusedColumn = GridColumnCode
                End If
            Else
                If GVItemList.FocusedColumn.ToString = "Remark" Then 'for remark
                    GVItemList.CloseEditor()
                    addMyRow()
                    GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
                    GVItemList.FocusedColumn = GridColumnCode
                End If
            End If
        End If
    End Sub

    Sub setDefautMyRow(ByVal rhx As Integer)
        GVItemList.SetRowCellValue(rhx, "id_sales_order_det", "0")
        GVItemList.SetRowCellValue(rhx, "code", "")
        GVItemList.SetRowCellValue(rhx, "name", "")
        GVItemList.SetRowCellValue(rhx, "size", "")
        GVItemList.SetRowCellValue(rhx, "sales_order_det_qty", 0)
        GVItemList.SetRowCellValue(rhx, "id_design_price", "0")
        GVItemList.SetRowCellValue(rhx, "design_price", 0)
        GVItemList.SetRowCellValue(rhx, "design_price_type", "")
        GVItemList.SetRowCellValue(rhx, "amount", 0)
        GVItemList.SetRowCellValue(rhx, "qty_avail", 0)
        GVItemList.SetRowCellValue(rhx, "sales_order_det_note", "")
        GVItemList.SetRowCellValue(rhx, "id_design", "0")
        GVItemList.SetRowCellValue(rhx, "id_product", "0")
        GVItemList.SetRowCellValue(rhx, "id_sample", "0")
        GVItemList.SetRowCellValue(rhx, "is_found", "2")
        GVItemList.SetRowCellValue(rhx, "error_status", "")
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

    Private Sub GVItemList_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVItemList.RowCellStyle
        If e.Column.FieldName = "error_status" Then
            If sender.GetRowCellValue(e.RowHandle, sender.Columns("error_status")) <> "" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.White
            Else
                e.Appearance.BackColor = Color.White
                e.Appearance.BackColor2 = Color.White
            End If
        End If
    End Sub

    Sub noEdit()
        If GVItemList.FocusedRowHandle >= 0 Then
            Dim id_sales_order_det_cek As String = GVItemList.GetFocusedRowCellValue("id_sales_order_det").ToString
            If id_sales_order_det_cek = "0" Then
                GVItemList.Columns("code").OptionsColumn.AllowEdit = True
                GVItemList.Columns("sales_order_det_qty").OptionsColumn.AllowEdit = True
            Else
                GVItemList.Columns("code").OptionsColumn.AllowEdit = False
                GVItemList.Columns("sales_order_det_qty").OptionsColumn.AllowEdit = False
            End If
        End If
    End Sub

    Private Sub BtnImportExcel_Click(sender As Object, e As EventArgs) Handles BtnImportExcel.Click
        Cursor = Cursors.WaitCursor
        If id_comp_par = "-1" Or id_store = "-1" Then
            stopCustom("Please select warehouse and store first !")
        Else
            FormImportExcel.id_pop_up = "15"
            FormImportExcel.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LETypeSO_KeyDown(sender As Object, e As KeyEventArgs) Handles LETypeSO.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtCodeCompTo.Focus()
        End If
    End Sub

    Private Sub TxtWHNameTo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtWHNameTo.Validating
        EP_TE_cant_blank(EPForm, TxtWHNameTo)
        EPForm.SetIconPadding(TxtWHNameTo, 28)
    End Sub

    Private Sub BtnImportExcelNew_Click(sender As Object, e As EventArgs) Handles BtnImportExcelNew.Click
        Cursor = Cursors.WaitCursor
        If id_comp_par = "-1" Or id_store = "-1" Then
            stopCustom("Please select warehouse and store first !")
        Else
            FormImportExcel.id_pop_up = "25"
            FormImportExcel.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnXlsBOF_Click(sender As Object, e As EventArgs) Handles BtnXlsBOF.Click
        exportToBOF(True)
    End Sub

    Sub exportToBOF(ByVal show_msg As Boolean)
        If bof_column = "1" Then
            Cursor = Cursors.WaitCursor

            'hide column
            For c As Integer = 0 To GVItemList.Columns.Count - 1
                GVItemList.Columns(c).Visible = False
            Next
            GridColumnCode.VisibleIndex = 0
            GridColumnQty.VisibleIndex = 1
            GridColumnNumber.VisibleIndex = 2
            GridColumnFrom.VisibleIndex = 3
            GridColumnTo.VisibleIndex = 4
            GridColumnRemark.VisibleIndex = 5
            GVItemList.OptionsPrint.PrintFooter = False
            GVItemList.OptionsPrint.PrintHeader = False


            'export excel
            Dim path_root As String = ""
            Try
                ' Open the file using a stream reader.
                Using sr As New IO.StreamReader(Application.StartupPath & "\bof_path.txt")
                    ' Read the stream to a string and write the string to the console.
                    path_root = sr.ReadToEnd()
                End Using
            Catch ex As Exception
            End Try

            Dim fileName As String = bof_xls_so + ".xls"
            Dim exp As String = IO.Path.Combine(path_root, fileName)
            Try
                ExportToExcel(GVItemList, exp, show_msg)
            Catch ex As Exception
                stopCustom("Please close your excel file first then try again later")
            End Try

            'show column
            GridColumnNo.VisibleIndex = 0
            GridColumnCode.VisibleIndex = 1
            GridColumnName.VisibleIndex = 2
            GridColumnSize.VisibleIndex = 3
            GridColumnQty.VisibleIndex = 4
            GridColumnPrice.VisibleIndex = 5
            GridColumnAmount.VisibleIndex = 6
            GridColumnRemark.VisibleIndex = 7
            GridColumnNumber.Visible = False
            GridColumnFrom.Visible = False
            GridColumnTo.Visible = False
            GVItemList.OptionsPrint.PrintFooter = True
            GVItemList.OptionsPrint.PrintHeader = True
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ExportToExcel(ByVal dtTemp As DevExpress.XtraGrid.Views.Grid.GridView, ByVal filepath As String, show_msg As Boolean)
        Dim strFileName As String = filepath
        If System.IO.File.Exists(strFileName) Then
            System.IO.File.Delete(strFileName)
        End If
        Dim _excel As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()


        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = -1

        ' export the Columns 
        'If CheckBox1.Checked Then
        '    For Each dc In dt.Columns
        '        colIndex = colIndex + 1
        '        wSheet.Cells(1, colIndex) = dc.ColumnName
        '    Next
        'End If

        'export the rows 
        For i As Integer = 0 To dtTemp.RowCount - 1
            rowIndex = rowIndex + 1
            colIndex = 0
            For j As Integer = 0 To dtTemp.VisibleColumns.Count - 1
                colIndex = colIndex + 1
                If j = 0 Then 'code
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "code").ToString
                ElseIf j = 1 'qty
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "sales_order_det_qty")
                ElseIf j = 2 'number
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "number").ToString
                ElseIf j = 3 'from
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "from").ToString
                ElseIf j = 4 'to
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "to").ToString
                Else 'remark det
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "sales_order_det_note").ToString
                End If
            Next
        Next

        wSheet.Columns.AutoFit()
        wBook.SaveAs(strFileName, Excel.XlFileFormat.xlExcel5)

        'release the objects
        ReleaseObject(wSheet)
        wBook.Close(False)
        ReleaseObject(wBook)
        _excel.Quit()
        ReleaseObject(_excel)
        ' some time Office application does not quit after automation: so i am calling GC.Collect method.
        GC.Collect()

        If show_msg Then
            infoCustom("File exported successfully")
        End If
    End Sub
    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub GVItemList_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVItemList.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName = "from" AndAlso e.IsGetData Then
            e.Value = TxtWHCodeTo.Text.ToString
        ElseIf e.Column.FieldName = "to" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompTo.Text.ToString
        ElseIf e.Column.FieldName = "number" AndAlso e.IsGetData Then
            e.Value = TxtSalesOrderNumber.Text.ToString
        End If
    End Sub
End Class