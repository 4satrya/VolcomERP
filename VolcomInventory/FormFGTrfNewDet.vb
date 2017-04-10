Imports Microsoft.Office.Interop

Public Class FormFGTrfNewDet
    Public action As String = ""
    Public id_fg_trf As String = "-1"
    Public id_sales_order As String = "-1"
    Public id_comp_contact_from As String = "-1"
    Public id_comp_contact_to As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Dim dt As New DataTable
    Public id_report_status As String = "-1"
    Public id_report_status_rec As String = "-1"
    Public id_fg_trf_det_list As New List(Of String)
    Public id_fg_trf_det_counting_list As New List(Of String)
    Public id_fg_trf_det_drawer_list As New List(Of String)
    Dim is_scan As Boolean = False
    Dim id_comp_cat_wh As String = "-1"
    Public id_type As String = "-1"
    Dim is_new_rec As Boolean = False
    Public id_wh_drawer_to As String = "-1"
    Public is_only_for_alloc As String = "-1"
    Public id_pre As String = "-1"
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_so As String = get_setup_field("bof_xls_trf")
    Dim id_wh_type As String = "-1"

    Private Sub FormFGTrfNewDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get default store category for pick company
        id_comp_cat_wh = execute_query("SELECT id_comp_cat_wh FROM tb_opt", 0, True, "", "", "", "")

        viewReportStatus()
        actionLoad()
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub FormFGTrfNewDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub actionLoad()
        Try
            'initiation datatable jika blm ada
            dt.Columns.Add("id_product")
            dt.Columns.Add("id_pl_prod_order_rec_det_unique")
            dt.Columns.Add("product_code")
            dt.Columns.Add("product_counting_code")
            dt.Columns.Add("product_full_code")
            dt.Columns.Add("bom_unit_price")
            dt.Columns.Add("is_old_design")
        Catch ex As Exception
        End Try

        'hide diff status
        GridColumnStatus.Visible = False

        If action = "ins" Then
            XTPOutboundScanNew.PageEnabled = True
            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            BMark.Enabled = False
            DDBPrint.Enabled = False
            DEForm.Text = view_date(0)
            check_but()
            check_but_drawer()

            'from waiting menu
            If id_sales_order <> "-1" Then
                viewSalesOrder()
            End If
        ElseIf action = "upd" Then
            GroupControlListItem.Enabled = True
            GroupControlScannedItem.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            XTPOutboundScanNew.PageEnabled = True
            BtnBrowseSO.Enabled = False
            BMark.Enabled = True
            DDBPrint.Enabled = True

            'query view based on edit id's
            Dim query_c As ClassFGTrf = New ClassFGTrf()
            Dim query As String = query_c.queryMain("AND trf.id_fg_trf=''" + id_fg_trf + "''", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_fg_trf = data.Rows(0)("id_fg_trf").ToString
            id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
            id_comp_from = data.Rows(0)("id_comp_from").ToString
            id_comp_to = data.Rows(0)("id_comp_to").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_report_status_rec = id_report_status
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_number_to").ToString
            TxtNumber.Text = data.Rows(0)("fg_trf_number").ToString
            DEForm.Text = view_date_from(data.Rows(0)("fg_trf_datex").ToString, 0)
            MENote.Text = data.Rows(0)("fg_trf_note").ToString
            id_wh_drawer_to = data.Rows(0)("id_wh_drawer").ToString
            TxtDrawerCode.Text = data.Rows(0)("wh_drawer_code").ToString
            TEDrawer.Text = data.Rows(0)("wh_drawer").ToString
            TxtSalesOrder.Text = data.Rows(0)("sales_order_number").ToString
            id_sales_order = data.Rows(0)("id_sales_order").ToString
            is_only_for_alloc = data.Rows(0)("is_only_for_alloc").ToString

            'detail2
            viewDetail()
            view_barcode_list()
            viewDetailDrawer()
            check_but()
            check_but_drawer()
            allow_status()

            If id_pre = "1" Then
                prePrinting()
                Close()
            ElseIf id_pre = "2" Then
                printing()
                Close()
            End If
        End If
    End Sub

    Sub viewSalesOrder()
        Dim query As String = "SELECT a.id_so_type, a.id_so_status, a.id_sales_order, a.id_store_contact_to, d.id_wh_type, (d.comp_name) AS store_name_to,a.id_report_status, f.report_status, "
        query += "a.sales_order_note,a.sales_order_date, a.sales_order_note, a.sales_order_number, "
        query += "DATE_FORMAT(a.sales_order_date,'%d %M %Y') AS sales_order_date, (SELECT COUNT(id_pl_sales_order_del) FROM tb_pl_sales_order_del WHERE tb_pl_sales_order_del.id_sales_order = a.id_sales_order) AS pl_created, "
        query += "a.id_warehouse_contact_to, (wh.comp_number) AS `wh_number`, (wh.comp_name) AS `wh_name` "
        query += "FROM tb_sales_order a "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_comp_contact wh_cont ON wh_cont.id_comp_contact = a.id_warehouse_contact_to "
        query += "INNER JOIN tb_m_comp wh ON wh.id_comp = wh_cont.id_comp "
        query += "WHERE a.id_sales_order = '" + id_sales_order + "' "
        query += "ORDER BY a.id_sales_order DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'SO
        TxtSalesOrder.Text = data.Rows(0)("sales_order_number").ToString

        'store data
        Dim query_comp_to As String = "SELECT id_comp FROM tb_m_comp_contact WHERE id_comp_contact = '" + data.Rows(0)("id_store_contact_to").ToString + "'"
        id_comp_to = execute_query(query_comp_to, 0, True, "", "", "", "")
        id_comp_contact_to = data.Rows(0)("id_store_contact_to").ToString
        TxtCodeCompTo.Text = get_company_x(id_comp_to, 2)
        TxtNameCompTo.Text = get_company_x(id_comp_to, 1)
        id_wh_type = data.Rows(0)("id_wh_type").ToString

        'wh
        Dim query_comp_from As String = "SELECT id_comp FROM tb_m_comp_contact WHERE id_comp_contact = '" + data.Rows(0)("id_warehouse_contact_to").ToString + "'"
        id_comp_from = execute_query(query_comp_from, 0, True, "", "", "", "")
        id_comp_contact_from = data.Rows(0)("id_warehouse_contact_to").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("wh_number").ToString
        TxtNameCompFrom.Text = data.Rows(0)("wh_name").ToString

        'general
        viewSalesOrderDetail()
    End Sub

    Sub viewSalesOrderDetail()
        dt.Clear()
        viewDetail()
        viewDetailDrawer()
        view_barcode_list()
        setDefaultDrawer()
        GroupControlListItem.Enabled = True
        GroupControlScannedItem.Enabled = True
        check_but()
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
        BtnBrowseSO.Enabled = False

        'get default drawer
        Dim query_def_drw As String = ""
        query_def_drw += "SELECT IFNULL(drw.id_wh_drawer,'-1') AS `id_wh_drawer`, IFNULL(drw.wh_drawer_code,'') AS `wh_drawer_code`, "
        query_def_drw += "IFNULL(drw.wh_drawer,'') AS `wh_drawer` "
        query_def_drw += "FROM tb_m_comp comp "
        query_def_drw += "LEFT JOIN tb_m_wh_drawer drw ON comp.id_drawer_def = drw.id_wh_drawer "
        query_def_drw += "WHERE comp.id_comp='" + id_comp_to + "' "
        Dim data_def_drw As DataTable = execute_query(query_def_drw, -1, True, "", "", "", "")
        id_wh_drawer_to = data_def_drw(0)("id_wh_drawer").ToString
        TxtDrawerCode.Text = data_def_drw(0)("wh_drawer_code").ToString
        TEDrawer.Text = data_def_drw(0)("wh_drawer").ToString
    End Sub

    Sub setDefaultDrawer()
        'get drw def
        Dim id_wh_par As String = get_company_contact_x(id_comp_contact_from, "3")
        Dim query As String = ""
        query += "SELECT wh.id_comp, wh.comp_number, loc.id_wh_locator, loc.wh_locator_code, rck.id_wh_rack, rck.wh_rack_code, drw.id_wh_drawer, drw.wh_drawer_code "
        query += "FROM tb_m_comp wh "
        query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = wh.id_drawer_def "
        query += "INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
        query += "WHERE wh.id_comp='" + id_wh_par + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            Dim id_loc_def As String = data.Rows(0)("id_wh_locator").ToString
            Dim id_rck_def As String = data.Rows(0)("id_wh_rack").ToString
            Dim id_drw_def As String = data.Rows(0)("id_wh_drawer").ToString
            Dim wh As String = data.Rows(0)("comp_number").ToString
            Dim locator As String = data.Rows(0)("wh_locator_code").ToString
            Dim rack As String = data.Rows(0)("wh_rack_code").ToString
            Dim drawer As String = data.Rows(0)("wh_drawer_code").ToString
            Dim bom_unit_price As Decimal = 0
            Dim qty_all_product As Decimal = 0
            Dim total_cost As Decimal = 0

            'get stock
            Dim query_stc As String = "CALL view_stock_fg('" + id_wh_par + "','" + id_loc_def + "','" + id_rck_def + "','" + id_drw_def + "', '0','4', '9999-01-01') "
            Dim data_stc As DataTable = execute_query(query_stc, -1, True, "", "", "", "")


            For j As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                Dim data_stc_filter As DataRow() = data_stc.Select("[id_product]='" + GVItemList.GetRowCellValue(j, "id_product").ToString + "' ")
                Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                Dim code As String = GVItemList.GetRowCellValue(j, "code").ToString
                Dim name As String = GVItemList.GetRowCellValue(j, "name").ToString
                Dim size As String = GVItemList.GetRowCellValue(j, "size").ToString
                Dim qty_limit As Decimal = GVItemList.GetRowCellValue(j, "sales_order_det_qty_limit")
                Dim id_fg_trf_det_drawer As String = "0"
                Dim fill_status As Boolean = False

                If data_stc_filter.Length > 0 Then
                    Dim qty_avail As Decimal = data_stc_filter(0)("qty_all_product")
                    If qty_limit > 0 Then
                        If qty_avail = 0 Then
                            qty_all_product = 0
                            bom_unit_price = 0
                            total_cost = 0
                            fill_status = False
                        ElseIf qty_avail >= qty_limit Then
                            qty_all_product = qty_limit
                            bom_unit_price = data_stc_filter(0)("bom_unit_price")
                            total_cost = qty_all_product * bom_unit_price
                            fill_status = True
                        Else
                            qty_all_product = qty_avail
                            bom_unit_price = data_stc_filter(0)("bom_unit_price")
                            total_cost = qty_all_product * bom_unit_price
                            fill_status = True
                        End If
                    Else
                        qty_all_product = 0
                        bom_unit_price = 0
                        total_cost = 0
                        fill_status = False
                    End If
                Else
                    bom_unit_price = 0
                    qty_all_product = 0
                    total_cost = 0
                    fill_status = False
                End If
            Next
        End If
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub


    'sub check_but
    Sub check_but()
        Dim id_productx As String = "0"
        Try
            id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try

        'Constraint Status
        If GVItemList.RowCount > 0 And id_productx <> "0" Then
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        End If
    End Sub

    Sub check_but_drawer()

    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "57", id_fg_trf) Then
            BtnAdd.Enabled = True
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
            MENote.Properties.ReadOnly = False
            GVItemList.OptionsCustomization.AllowGroup = False
            BPickDrawer.Enabled = True
        Else
            BtnAdd.Enabled = False
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
            MENote.Properties.ReadOnly = True
            GVItemList.OptionsCustomization.AllowGroup = True
            GridColumnQtyLimit.Visible = False
            GridColumnQtyWH.Visible = False
            BPickDrawer.Enabled = False
        End If
        PanelNavBarcode.Enabled = False
        BtnVerify.Enabled = False
        BtnSave.Enabled = False

        'ATTACH
        If check_attach_report_status(id_report_status, "57", id_fg_trf) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_pre_print_report_status(id_report_status) Then
            BtnPrePrinting.Enabled = True
        Else
            BtnPrePrinting.Enabled = False
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

        'mark visible
        If is_only_for_alloc = "1" Then
            BMark.Visible = False
        Else
            BMark.Visible = True
        End If
        TxtNumber.Focus()
    End Sub

    Sub view_barcode_list()
        If action = "ins" Then
            Dim query As String = "SELECT ('0') AS no, ('') AS code, ('') AS name, ('') AS size, ('0') AS id_fg_trf_det, ('0') AS id_pl_prod_order_rec_det_unique, ('0') AS id_product,('1') AS is_fix, ('') AS counting_code, ('0') AS id_fg_trf_det_counting "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBarcode.DataSource = data
            deleteRowsBc()
            allowDelete()
        ElseIf action = "upd" Then
            id_fg_trf_det_counting_list.Clear()
            Dim query As String = ""
            query += "SELECT ('') AS no, CONCAT(c.product_full_code, a.fg_trf_det_counting) AS code, "
            query += "c.product_display_name AS `name`, cod.display_name AS `size`, (a.fg_trf_det_counting) AS counting_code, "
            query += "a.id_fg_trf_det_counting, ('2') AS is_fix, "
            query += "a.id_pl_prod_order_rec_det_unique, b.id_product "
            query += "FROM tb_fg_trf_det_counting a "
            query += "INNER JOIN tb_fg_trf_det b ON a.id_fg_trf_det = b.id_fg_trf_det "
            query += "JOIN tb_opt o "
            query += "INNER JOIN tb_m_product c ON c.id_product = b.id_product "
            query += "INNER JOIN tb_m_product_code cc ON cc.id_product = c.id_product "
            query += "INNER JOIN tb_m_code_detail cod ON cod.id_code_detail = cc.id_code_detail AND cod.id_code = o.id_code_product_size "
            query += "WHERE b.id_fg_trf = '" + id_fg_trf + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_fg_trf_det_counting_list.Add(data.Rows(i)("id_fg_trf_det_counting").ToString)
            Next
            GCBarcode.DataSource = data
        End If
    End Sub

    Sub viewDetail()
        If action = "ins" Then
            'action
            Dim query As String = "CALL view_sales_order_limit_for_trf('" + id_sales_order + "', '0', '0')"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            Dim id_product_param As String = ""
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_product_param += data.Rows(i)("id_product").ToString
                If i < (data.Rows.Count - 1) Then
                    id_product_param += ";"
                End If
            Next
            GCItemList.DataSource = data
            codeAvailableIns(id_product_param)
        ElseIf action = "upd" Then
            id_fg_trf_det_list.Clear()
            Dim id_param As String = ""
            Dim query As String = "CALL view_fg_trf('" + id_fg_trf + "')"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_fg_trf_det_list.Add(data.Rows(i)("id_fg_trf_det").ToString)
                id_param = id_param + data.Rows(i)("id_product").ToString
                If i < (data.Rows.Count - 1) Then
                    id_param = id_param + ";"
                End If
            Next
            GCItemList.DataSource = data
            Me.codeAvailableIns(id_param)
        End If
    End Sub

    Sub viewDetailDrawer()

    End Sub

    '-------------------------------------------------------------------------------------
    'SAAT INI PARAMETER HANYA ID PROD KARENA PRODUCTION HANYA ADA 1 COST (19 Sept 2014)
    '-----------------------------------------------------------------------------------
    Sub codeAvailableIns(ByVal id_product_param As String)
        dt.Clear()
        Dim query As String = ""
        query = "CALL view_stock_fg_unique_del('" + id_product_param + "')"
        Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
        dt = datax
        'For k As Integer = 0 To (datax.Rows.Count - 1)
        '    insertDt(datax.Rows(k)("id_product").ToString, datax.Rows(k)("id_pl_prod_order_rec_det_unique").ToString, datax.Rows(k)("product_code").ToString, datax.Rows(k)("product_counting_code").ToString, datax.Rows(k)("product_full_code").ToString, Decimal.Parse(datax.Rows(k)("bom_unit_price").ToString))
        'Next

        'not unique 
        Dim query_c As ClassDesign = New ClassDesign()
        Dim query_not As String = query_c.queryOldDesignCode(id_product_param)
        Dim data_not As DataTable = execute_query(query_not, -1, True, "", "", "", "")

        'merge
        If data_not.Rows.Count > 0 Then
            If dt.Rows.Count = 0 Then
                dt = data_not
            Else
                dt.Merge(data_not, True, MissingSchemaAction.Ignore)
            End If
        End If
    End Sub

    Sub codeAvailableDel(ByVal id_product_param As String)
        Dim i As Integer = dt.Rows.Count - 1
        While (i >= 0)
            If dt.Rows(i)("id_product").ToString = id_product_param Then
                dt.Rows.RemoveAt(i)
            End If
            i = i - 1
        End While
    End Sub

    Sub insertDt(ByVal id_product_param As String, ByVal id_pl_prod_order_rec_det_unique_param As String, ByVal product_code_param As String, ByVal product_counting_code_param As String, ByVal product_full_code_param As String, ByVal cost_param As Decimal)
        Dim R As DataRow = dt.NewRow
        R("id_product") = id_product_param
        R("id_pl_prod_order_rec_det_unique") = id_pl_prod_order_rec_det_unique_param
        R("product_code") = product_code_param
        R("product_counting_code") = product_counting_code_param
        R("product_full_code") = product_full_code_param
        R("bom_unit_price") = cost_param
        R("is_old_design") = "2"
        dt.Rows.Add(R)
    End Sub

    'DeleteRows
    Sub deleteRowsBc()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
        GVBarcode.FocusedColumn = GVBarcode.VisibleColumns(0)
        GVBarcode.ShowEditor()
    End Sub
    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
        End If
    End Sub

    Sub noEdit()
        Try
            Dim is_fix As String = GVBarcode.GetFocusedRowCellDisplayText("is_fix")
            'MsgBox(id_pl_prod_order_rec_det)
            If is_fix <> "2" Then
                GridColumnBarcode.OptionsColumn.AllowEdit = True
            Else
                GridColumnBarcode.OptionsColumn.AllowEdit = False
            End If
            'MsgBox(id_pl_prod_order_rec_det)
        Catch ex As Exception
            'errorCustom(ex.ToString)
        End Try
    End Sub

    Sub countQty(ByVal id_product_param As String)
        GVBarcode.ActiveFilterString = "[id_product]='" + id_product_param + "' "
        Dim tot As Integer = GVBarcode.RowCount
        GVBarcode.ActiveFilterString = ""

        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_product", id_product_param)
        GVItemList.SetFocusedRowCellValue("fg_trf_det_qty", tot)

        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub


    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "57"
        FormReportMark.is_disabled_set_stt = "1"
        FormReportMark.id_report = id_fg_trf
        FormReportMark.form_origin = Name
        FormReportMark.not_allow_complete = "1"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BScan.Click
        If GVItemList.RowCount < 1 Then
            errorCustom("Please add product required !")
        Else
            'FormFGStockOpnameStoreSingle.id_pop_up = "1"
            'FormFGStockOpnameStoreSingle.ShowDialog()
            startScan()
        End If

    End Sub

    Sub disableControl()
        is_scan = True
        BPickDrawer.Enabled = False
        MENote.Enabled = False
        BtnSave.Enabled = False
        BScan.Enabled = False
        BStop.Enabled = True
        BDelete.Enabled = False
        BtnCancel.Enabled = False
        GVItemList.OptionsBehavior.Editable = False
        ControlBox = False
        TxtNumber.Enabled = False
        BtnVerify.Enabled = False
        If action = "upd" Then
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            DDBPrint.Enabled = False
        End If
    End Sub

    Sub startScan()
        disableControl()
        newRowsBc()
        'allowDelete()
    End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop.Click
        For i As Integer = 0 To (GVBarcode.RowCount - 1)
            Dim check_code As String = ""
            Try
                check_code = GVBarcode.GetRowCellValue(i, "code").ToString()
            Catch ex As Exception

            End Try
            If check_code = "" Or check_code = Nothing Or IsDBNull(check_code) Then
                GVBarcode.DeleteRow(i)
            End If
        Next
        GVItemList.FocusedRowHandle = 0
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()

        enableControl()
    End Sub

    Sub enableControl()
        is_scan = False
        BPickDrawer.Enabled = True
        MENote.Enabled = True
        BtnSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BtnCancel.Enabled = True
        allowDelete()
        GVItemList.OptionsBehavior.Editable = True
        ControlBox = True
        TxtNumber.Enabled = True
        TxtDeleteScan.Visible = False
        LabelDelScan.Visible = False
        BtnVerify.Enabled = True
        If action = "upd" Then
            BMark.Enabled = True
            BtnAttachment.Enabled = True
            DDBPrint.Enabled = True
        End If
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        disableControl()
        LabelDelScan.Visible = True
        TxtDeleteScan.Visible = True
        TxtDeleteScan.Focus()
        'Dim id_fg_trf_det_counting As String = "-1"
        'Try
        '    id_fg_trf_det_counting = GVBarcode.GetFocusedRowCellValue("id_fg_trf_det_counting").ToString
        'Catch ex As Exception
        'End Try

        'If action = "ins" Then
        '    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '    If confirm = Windows.Forms.DialogResult.Yes Then
        '        Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
        '        Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
        '        Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
        '        Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

        '        deleteRowsBc()
        '        If id_product <> "" Or id_product <> Nothing Then
        '            GVBarcode.ApplyFindFilter("")
        '            countQty(id_product)
        '        End If

        '        allowDelete()
        '    End If
        'ElseIf action = "upd" Then
        '    If id_fg_trf_det_counting = "0" Then
        '        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '        If confirm = Windows.Forms.DialogResult.Yes Then
        '            Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
        '            Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
        '            Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
        '            Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

        '            deleteRowsBc()
        '            If id_product <> "" Or id_product <> Nothing Then
        '                GVBarcode.ApplyFindFilter("")
        '                countQty(id_product)
        '            End If

        '            allowDelete()
        '        End If
        '    Else
        '        errorCustom("This data already locked and can't delete.")
        '    End If
        'End If
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVBarcode_FocusedColumnChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVBarcode.FocusedColumnChanged
        If Not GVBarcode.FocusedColumn.FieldName = "code" Then
            GVBarcode.FocusedColumn = GVBarcode.Columns("code")
        End If
    End Sub

    Private Sub GVBarcode_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBarcode.FocusedRowChanged
        noEdit()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        Cursor = Cursors.WaitCursor
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim code_duplicate As Boolean = False
        Dim code_item_found As Boolean = False
        Dim counting_code As String = ""
        Dim id_pl_prod_order_rec_det_unique As String = ""
        Dim id_product As String = ""
        Dim product_name As String = ""
        Dim id_design_cat As String = ""
        Dim size As String = ""
        Dim bom_unit_price As Decimal = 0.0
        Dim id_design_price As String = ""
        Dim design_price As Decimal = 0.0
        Dim jum_scan As Integer = 0
        Dim jum_limit As Integer = 0
        Dim is_old As String = "0"

        'check available code
        Dim dt_filter As DataRow() = dt.Select("[product_full_code]='" + code_check + "' ")
        If dt_filter.Length > 0 Then
            counting_code = dt_filter(0)("product_counting_code").ToString
            id_pl_prod_order_rec_det_unique = dt_filter(0)("id_pl_prod_order_rec_det_unique").ToString
            id_product = dt_filter(0)("id_product").ToString
            product_name = dt_filter(0)("name").ToString
            id_design_cat = dt_filter(0)("id_design_cat").ToString
            size = dt_filter(0)("size").ToString
            bom_unit_price = Decimal.Parse(dt_filter(0)("bom_unit_price").ToString)
            is_old = dt_filter(0)("is_old_design").ToString
            code_found = True
        End If

        'get jum del & limit
        GVItemList.ActiveFilterString = "[id_product]='" + id_product + "' "
        GVItemList.FocusedRowHandle = 0
        Try
            ' jum_limit = GVItemList.GetFocusedRowCellValue("qty_from_wh")
            jum_limit = 999999999
        Catch ex As Exception
        End Try
        Try
            jum_scan = GVItemList.GetFocusedRowCellValue("fg_trf_det_qty")
        Catch ex As Exception
        End Try
        makeSafeGV(GVItemList)

        If Not code_found Then
            GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
            GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
            stopCustom("Data not found or duplicate!")
        Else
            'jika akun normal/sale
            If id_wh_type = "1" Or id_wh_type = "2" Then
                If id_wh_type <> id_design_cat Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    If id_wh_type = "1" Then
                        stopCustom(TxtCodeCompTo.Text + " is only for normal product. ")
                    Else
                        stopCustom(TxtCodeCompTo.Text + " is only for sale product. ")
                    End If
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            If is_old = "1" Then 'old product
                If Not code_found Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    stopCustom("Data not found or duplicate!")
                Else
                    If jum_limit <= 0 Then
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                        stopCustom("This item cannot scan, because exceed the limit order.")
                    ElseIf jum_scan >= jum_limit Then
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                        stopCustom("Scanned qty exceed allowed qty")
                    Else
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_pl_prod_order_rec_det_unique", id_pl_prod_order_rec_det_unique)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_fg_trf_det_counting", "0")
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "is_fix", "2")
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "counting_code", counting_code)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_product", id_product)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "name", product_name)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "size", size)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "bom_unit_price", bom_unit_price)
                        countQty(id_product)
                        newRowsBc()
                        GCItemList.RefreshDataSource()
                        GVItemList.RefreshData()
                    End If
                End If
            ElseIf is_old = "2" Then ' new product
                'check duplicate code
                GVBarcode.ActiveFilterString = "[code]='" + code_check + "' AND [is_fix]='2' "
                If GVBarcode.RowCount > 0 Then
                    code_duplicate = True
                End If
                GVBarcode.ActiveFilterString = ""

                If Not code_found Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    stopCustom("Data not found or duplicate!")
                ElseIf code_duplicate Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    stopCustom("Data duplicate !")
                Else
                    If jum_limit <= 0 Then
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                        stopCustom("This item cannot scan, because exceed the limit order.")
                    ElseIf jum_scan >= jum_limit Then
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                        stopCustom("Scanned qty exceed allowed qty")
                    Else
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_pl_prod_order_rec_det_unique", id_pl_prod_order_rec_det_unique)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_fg_trf_det_counting", "0")
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "is_fix", "2")
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "counting_code", counting_code)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_product", id_product)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "name", product_name)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "size", size)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "bom_unit_price", bom_unit_price)
                        countQty(id_product)
                        newRowsBc()
                        GCItemList.RefreshDataSource()
                        GVItemList.RefreshData()
                    End If
                End If
            Else
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                stopCustom("Data not found !")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub deleteDetailBC(ByVal id_product_param As String)
        'delete detail
        Dim i As Integer = GVBarcode.RowCount - 1
        While (i >= 0)
            Dim id_product As String = ""
            Try
                id_product = GVBarcode.GetRowCellValue(i, "id_product").ToString()
            Catch ex As Exception

            End Try
            If id_product = id_product_param Then
                GVBarcode.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub

    Sub deleteDetailDrawer(ByVal id_product_param As String)

    End Sub

    Private Sub BtnAddDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.WaitCursor
        Dim id_product As String = "-1"
        Try
            id_product = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try
        FormSalesDelOrderSingle.id_comp = id_comp_from
        FormSalesDelOrderSingle.id_pop_up = "3"
        FormSalesDelOrderSingle.id_product = "0"
        FormSalesDelOrderSingle.action_pop = "ins"
        FormSalesDelOrderSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub


    Sub countQtyFromWh(ByVal id_product_param As String)
        Dim jum As Decimal = 0.0
        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_product", id_product_param)
        GVItemList.SetFocusedRowCellValue("qty_from_wh", jum)
        allowScanPage()
    End Sub

    Sub allowScanPage()
        makeSafeGV(GVItemList)

        GVItemList.ActiveFilterString = "[qty_from_wh]>0"
        If GVItemList.RowCount > 0 Then
            XTPOutboundScanNew.PageEnabled = True
        Else
            XTPOutboundScanNew.PageEnabled = False
        End If
        GVItemList.ActiveFilterString = ""
    End Sub

    'Color Cell
    Public Sub my_color_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        ' Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        'e.Appearance.BackColor = Color.White
        'e.Appearance.BackColor2 = Color.White

        'Try
        'Dim id_product_style As String = GVItemList.GetFocusedRowCellValue("id_product").ToString
        'Dim id_product_check As String = View.GetRowCellValue(e.RowHandle, View.Columns("id_product"))
        'If id_product_check = id_product_style Then
        ' e.Appearance.BackColor = Color.Lavender
        ' e.Appearance.BackColor2 = Color.White
        'End If
        'Catch ex As Exception

        'End Try
    End Sub

    Public Sub my_color_cell_wht(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White
    End Sub


    Private Sub BtnBrowseContactFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormPopUpContact.id_pop_up = "48"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.id_cat = id_comp_cat_wh
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormPopUpContact.id_pop_up = "49"
        FormPopUpContact.id_cat = id_comp_cat_wh
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormFGStockOpnameWHSingle.id_pop_up = "1"
        FormFGStockOpnameWHSingle.id_wh = id_comp_from
        FormFGStockOpnameWHSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim id_fg_trf_det As String = "-1"
        Try
            id_fg_trf_det = GVItemList.GetFocusedRowCellValue("id_fg_trf_det").ToString
        Catch ex As Exception
        End Try
        Dim id_product As String = GVItemList.GetFocusedRowCellValue("id_product").ToString
        If id_fg_trf_det = "0" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
                GCItemList.RefreshDataSource()
                GVItemList.RefreshData()
                codeAvailableDel(id_product)
                deleteDetailBC(id_product)
                deleteDetailDrawer(id_product)
                check_but()
                Cursor = Cursors.Default
            End If
        Else
            'cek uda ada product yg di scan ato blm
            errorCustom("This data already locked and can't delete.")
        End If
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
        check_but()
    End Sub

    Function verifyTrans() As Boolean
        GridColumnStatus.Visible = True
        Dim cond_check_data As Boolean = True
        Dim dt_cek As DataTable
        If action = "ins" Then
            dt_cek = execute_query("CALL view_sales_order_limit_for_trf(" + id_sales_order + ", 0, 0)", -1, True, "", "", "", "")
        Else
            dt_cek = execute_query("CALL view_sales_order_limit_for_trf(" + id_sales_order + ", 0, " + id_fg_trf + ")", -1, True, "", "", "", "")
        End If
        For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
            Dim id_sales_order_det_cekya As String = GVItemList.GetRowCellValue(i, "id_sales_order_det").ToString
            Dim qty_cek As Integer = GVItemList.GetRowCellValue(i, "fg_trf_det_qty")

            Dim data_filter_cek As DataRow() = dt_cek.Select("[id_sales_order_det]='" + id_sales_order_det_cekya + "' ")
            If data_filter_cek.Length <= 0 Then
                GVItemList.SetRowCellValue(i, "status", "Product not found;")
                cond_check_data = False
            Else
                If qty_cek > data_filter_cek(0)("sales_order_det_qty_limit") Then
                    Dim diff As Integer = 0
                    diff = qty_cek - data_filter_cek(0)("sales_order_det_qty_limit")
                    GVItemList.SetRowCellValue(i, "status", "+" + diff.ToString)
                    cond_check_data = False
                ElseIf qty_cek < data_filter_cek(0)("sales_order_det_qty_limit") Then
                    Dim diff As Integer = 0
                    diff = qty_cek - data_filter_cek(0)("sales_order_det_qty_limit")
                    GVItemList.SetRowCellValue(i, "status", diff.ToString)
                Else
                    GVItemList.SetRowCellValue(i, "status", "0")
                End If
            End If
        Next
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        Return cond_check_data
    End Function


    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        makeSafeGV(GVBarcode)
        makeSafeGV(GVItemList)
        Cursor = Cursors.WaitCursor
        ValidateChildren()

        'cek qty limit SO di DB
        Dim cond_check_data As Boolean = verifyTrans()

        If Not formIsValidInGroup(EPForm, GroupGeneralHeader) Then
            errorInput()
        ElseIf GVItemList.RowCount = 0 Or GVBarcode.RowCount = 0 Then
            errorCustom("Transfer item, drawer detail, and scanned item data can't blank")
        ElseIf Not cond_check_data Then
            stopCustom("Please see error in column status.")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor

                Dim fg_trf_note As String = MENote.Text.ToString
                If action = "ins" Then
                    'query main table
                    Dim fg_trf_number As String = header_number_sales("15")

                    Dim query_main As String = "INSERT tb_fg_trf(id_sales_order, fg_trf_number, id_comp_contact_from, id_comp_contact_to, fg_trf_date, fg_trf_date_rec, fg_trf_note, id_report_status,id_report_status_rec,id_wh_drawer, last_update, last_update_by) "
                    query_main += "VALUES('" + id_sales_order + "','" + fg_trf_number + "', '" + id_comp_contact_from + "', '" + id_comp_contact_to + "', NOW(), NOW(), '" + fg_trf_note + "', '1','1', '" + id_wh_drawer_to + "', NOW(), " + id_user + "); SELECT LAST_INSERT_ID(); "
                    id_fg_trf = execute_query(query_main, 0, True, "", "", "", "")
                    increase_inc_sales("15")

                    'insert who prepared
                    insert_who_prepared("57", id_fg_trf, id_user)

                    'Detail return
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_fg_trf_det(id_fg_trf, id_sales_order_det, id_product, fg_trf_det_qty, fg_trf_det_note, fg_trf_det_qty_rec,fg_trf_det_qty_stored) VALUES "
                    End If
                    For j As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Try
                            Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                            Dim fg_trf_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "fg_trf_det_qty").ToString)
                            Dim fg_trf_det_qty_rec As String = fg_trf_det_qty
                            Dim fg_trf_det_qty_stored As String = fg_trf_det_qty
                            Dim fg_trf_det_note As String = GVItemList.GetRowCellValue(j, "fg_trf_det_note").ToString
                            Dim id_sales_order_det As String = GVItemList.GetRowCellValue(j, "id_sales_order_det").ToString
                            If jum_ins_j > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_fg_trf + "', '" + id_sales_order_det + "', '" + id_product + "', '" + fg_trf_det_qty + "', '" + fg_trf_det_note + "', '" + fg_trf_det_qty_rec + "', '" + fg_trf_det_qty_stored + "') "
                            jum_ins_j = jum_ins_j + 1
                        Catch ex As Exception
                            'MsgBox(ex.ToString)
                        End Try
                    Next
                    If GVItemList.RowCount > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'get all detail id
                    Dim query_get_detail_id As String = "SELECT a.id_fg_trf_det, a.id_product "
                    query_get_detail_id += "FROM tb_fg_trf_det a "
                    query_get_detail_id += "WHERE a.id_fg_trf = '" + id_fg_trf + "' "
                    Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")


                    'counting
                    Dim jum_ins_p As Integer = 0
                    Dim query_counting As String = ""
                    If GVBarcode.RowCount > 0 Then
                        query_counting = "INSERT INTO tb_fg_trf_det_counting(id_fg_trf_det, id_pl_prod_order_rec_det_unique, fg_trf_det_counting) VALUES "
                    End If
                    For p As Integer = 0 To (GVBarcode.RowCount - 1)
                        Dim id_product_counting As String = GVBarcode.GetRowCellValue(p, "id_product")
                        Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetRowCellValue(p, "id_pl_prod_order_rec_det_unique").ToString
                        If id_pl_prod_order_rec_det_unique = "0" Then
                            id_pl_prod_order_rec_det_unique = "NULL "
                        End If
                        Dim fg_trf_det_counting As String = GVBarcode.GetRowCellValue(p, "counting_code").ToString
                        For p1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                            If id_product_counting = data_get_detail_id.Rows(p1)("id_product").ToString Then
                                If jum_ins_p > 0 Then
                                    query_counting += ", "
                                End If
                                query_counting += "('" + data_get_detail_id.Rows(p1)("id_fg_trf_det").ToString + "', " + id_pl_prod_order_rec_det_unique + ", '" + fg_trf_det_counting + "') "
                                jum_ins_p = jum_ins_p + 1
                                Exit For
                            End If
                        Next
                    Next
                    If GVBarcode.RowCount > 0 Then
                        execute_non_query(query_counting, True, "", "", "", "")
                    End If

                    'submit who prepared
                    submit_who_prepared("57", id_fg_trf, id_user)

                    FormFGTrfNew.viewSalesOrder()
                    FormFGTrfNew.viewFGTrf()
                    FormFGTrfNew.GVFGTrf.FocusedRowHandle = find_row(FormFGTrfNew.GVFGTrf, "id_fg_trf", id_fg_trf)
                    action = "upd"
                    actionLoad()
                    exportToBOF(False)
                    infoCustom("Transfer : " + fg_trf_number + " was created successfully.")
                ElseIf action = "upd" Then
                    'update main table
                    Dim fg_trf_number As String = TxtNumber.Text
                    Dim query_main As String = "UPDATE tb_fg_trf SET fg_trf_number = '" + fg_trf_number + "', id_comp_contact_from = '" + id_comp_contact_from + "', id_comp_contact_to = '" + id_comp_contact_to + "', fg_trf_note = '" + fg_trf_note + "', id_wh_drawer='" + id_wh_drawer_to + "', last_update=NOW(), last_update_by=" + id_user + " WHERE id_fg_trf = '" + id_fg_trf + "' "
                    execute_non_query(query_main, True, "", "", "", "")

                    'update detail table
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_fg_trf_det(id_fg_trf, id_product, fg_trf_det_qty, fg_trf_det_note, fg_trf_det_qty_rec, fg_trf_det_qty_stored) "
                    End If
                    For j As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Try
                            Dim id_fg_trf_det As String = GVItemList.GetRowCellValue(j, "id_fg_trf_det").ToString
                            Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                            Dim fg_trf_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "fg_trf_det_qty").ToString)
                            Dim fg_trf_det_qty_rec As String = fg_trf_det_qty
                            Dim fg_trf_det_qty_stored As String = fg_trf_det_qty
                            Dim fg_trf_det_note As String = GVItemList.GetRowCellValue(j, "fg_trf_det_note").ToString

                            If id_fg_trf_det = "0" Then
                                If jum_ins_j > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "VALUES('" + id_fg_trf + "', '" + id_product + "', '" + fg_trf_det_qty + "', '" + fg_trf_det_note + "', '" + fg_trf_det_qty + "', '" + fg_trf_det_qty_stored + "') "
                                jum_ins_j = jum_ins_j + 1
                            Else
                                Dim query_detail_upd As String = "UPDATE tb_fg_trf_det SET id_product = '" + id_product + "', fg_trf_det_qty = '" + fg_trf_det_qty + "', fg_trf_det_qty_rec='" + fg_trf_det_qty_rec + "', fg_trf_det_qty_stored='" + fg_trf_det_qty_stored + "', fg_trf_det_note = '" + fg_trf_det_note + "' WHERE id_fg_trf_det = '" + id_fg_trf_det + "'"
                                execute_non_query(query_detail_upd, True, "", "", "", "")
                                id_fg_trf_det_list.Remove(id_fg_trf_det)
                            End If
                        Catch ex As Exception
                            'MsgBox(ex.ToString)
                        End Try
                    Next
                    If GVItemList.RowCount > 0 And jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    For j_del As Integer = 0 To (id_fg_trf_det_list.Count - 1)
                        Try
                            Dim query_detail_del As String = "DELETE FROM tb_fg_trf_det WHERE id_fg_trf_det = '" + id_fg_trf_det_list(j_del) + "'"
                            execute_non_query(query_detail_del, True, "", "", "", "")
                        Catch ex As Exception

                        End Try
                    Next

                    'get all detail id
                    Dim query_get_detail_id As String = "SELECT a.id_fg_trf_det, a.id_product "
                    query_get_detail_id += "FROM tb_fg_trf_det a "
                    query_get_detail_id += "WHERE a.id_fg_trf = '" + id_fg_trf + "' "
                    Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")

                    'update counting
                    Dim jum_ins_p As Integer = 0
                    Dim query_counting As String = ""
                    If GVBarcode.RowCount > 0 Then
                        query_counting = "INSERT INTO tb_fg_trf_det_counting(id_fg_trf_det, id_pl_prod_order_rec_det_unique, fg_trf_det_counting) VALUES "
                    End If
                    For p As Integer = 0 To (GVBarcode.RowCount - 1)
                        Dim id_fg_trf_det_counting As String = GVBarcode.GetRowCellValue(p, "id_fg_trf_det_counting").ToString
                        Dim id_product_counting As String = GVBarcode.GetRowCellValue(p, "id_product")
                        Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetRowCellValue(p, "id_pl_prod_order_rec_det_unique").ToString
                        If id_pl_prod_order_rec_det_unique = "0" Then
                            id_pl_prod_order_rec_det_unique = "NULL "
                        End If
                        Dim fg_trf_det_counting As String = GVBarcode.GetRowCellValue(p, "counting_code").ToString
                        For p1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                            If id_fg_trf_det_counting = "0" Then
                                If id_product_counting = data_get_detail_id.Rows(p1)("id_product").ToString Then
                                    If jum_ins_p > 0 Then
                                        query_counting += ", "
                                    End If
                                    query_counting += "('" + data_get_detail_id.Rows(p1)("id_fg_trf_det").ToString + "', " + id_pl_prod_order_rec_det_unique + ", '" + fg_trf_det_counting + "') "
                                    jum_ins_p = jum_ins_p + 1
                                    Exit For
                                End If
                            End If
                        Next
                    Next
                    If GVBarcode.RowCount > 0 And jum_ins_p > 0 Then
                        execute_non_query(query_counting, True, "", "", "", "")
                    End If

                    FormFGTrfNew.viewSalesOrder()
                    FormFGTrfNew.viewFGTrf()
                    FormFGTrfNew.GVFGTrf.FocusedRowHandle = find_row(FormFGTrfNew.GVFGTrf, "id_fg_trf", id_fg_trf)
                    action = "upd"
                    actionLoad()
                    exportToBOF(False)
                    infoCustom("Transfer : " + fg_trf_number + " was edited successfully.")
                End If
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnStorage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStorage.Click

        Cursor = Cursors.Default
    End Sub

    Sub getReport()
        Cursor = Cursors.WaitCursor
        GridColumnStatus.Visible = False
        ReportFGTrf.id_fg_trf = id_fg_trf
        ReportFGTrf.id_type = id_type
        ReportFGTrf.dt = GCItemList.DataSource
        Dim Report As New ReportFGTrf()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVItemList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVItemList)

        'Parse val
        Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
        Report.LabelTo.Text = TxtCodeCompTo.Text + " - " + TxtNameCompTo.Text
        Report.LRecNumber.Text = TxtNumber.Text
        Report.LRecDate.Text = DEForm.Text
        Report.LabelNote.Text = MENote.Text
        If id_type = "1" Then
            Report.XrPanel2.Visible = False
        End If

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        If id_type = "-1" Then
            FormDocumentUpload.report_mark_type = "57"
        ElseIf id_type = "1" Then
            FormDocumentUpload.report_mark_type = "58"
        End If
        FormDocumentUpload.id_report = id_fg_trf
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDrawer_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnPrintDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.WaitCursor
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDrawer_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        check_but_drawer()
    End Sub

    Private Sub BPickDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickDrawer.Click
        FormPopUpDrawer.id_pop_up = "3"
        FormPopUpDrawer.id_comp = id_comp_to
        FormPopUpDrawer.ShowDialog()
    End Sub

    Private Sub BtnBrowseSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseSO.Click
        FormPopUpSalesOrder.id_pop_up = "3"
        FormPopUpSalesOrder.ShowDialog()
    End Sub

    Private Sub TxtSalesOrder_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSalesOrder.Validating
        EP_TE_cant_blank(EPForm, TxtSalesOrder)
        EPForm.SetIconPadding(TxtSalesOrder, 30)
    End Sub

    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompFrom)
        EPForm.SetIconPadding(TxtNameCompFrom, 30)
    End Sub


    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompTo)
        EPForm.SetIconPadding(TxtNameCompTo, 30)
    End Sub

    Private Sub TEDrawer_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEDrawer.Validating
        EP_TE_cant_blank(EPForm, TEDrawer)
        EPForm.SetIconPadding(TEDrawer, 30)
    End Sub

    Private Sub BtnPrePrinting_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrePrinting.ItemClick
        prePrinting()
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        ReportFGTrf.id_pre = "1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrint.ItemClick
        printing()
    End Sub

    Sub printing()
        Cursor = Cursors.WaitCursor
        ReportFGTrf.id_pre = "-1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtDeleteScan_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDeleteScan.KeyDown
        If e.KeyCode = Keys.Enter And TxtDeleteScan.Text.Length > 0 Then
            Cursor = Cursors.WaitCursor
            GVBarcode.ActiveFilterString = "[code]='" + TxtDeleteScan.Text + "'"
            If GVBarcode.RowCount <= 0 Then
                stopCustom("Code not found.")
                GVBarcode.ActiveFilterString = ""
                TxtDeleteScan.Text = ""
                TxtDeleteScan.Focus()
            Else
                Dim id_fg_trf_det_counting As String = "-1"
                Try
                    id_fg_trf_det_counting = GVBarcode.GetFocusedRowCellValue("id_fg_trf_det_counting").ToString
                Catch ex As Exception
                End Try

                If action = "ins" Then
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
                        Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
                        Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
                        Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

                        deleteRowsBc()
                        If id_product <> "" Or id_product <> Nothing Then
                            GVBarcode.ActiveFilterString = ""
                            countQty(id_product)
                        End If

                        allowDelete()
                    Else
                        GVBarcode.ActiveFilterString = ""
                    End If
                    TxtDeleteScan.Text = ""
                    TxtDeleteScan.Focus()
                ElseIf action = "upd" Then
                    If id_fg_trf_det_counting = "0" Then
                        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
                            Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
                            Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
                            Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

                            deleteRowsBc()
                            If id_product <> "" Or id_product <> Nothing Then
                                GVBarcode.ActiveFilterString = ""
                                countQty(id_product)
                            End If

                            allowDelete()
                        End If
                    Else
                        errorCustom("This data already locked and can't delete.")
                        GVBarcode.ActiveFilterString = ""
                    End If
                    TxtDeleteScan.Text = ""
                    TxtDeleteScan.Focus()
                End If
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVItemList_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVItemList.RowCellStyle
        If e.RowHandle >= 0 Then
            If (e.Column.FieldName = "status") Then
                Dim val As Integer = 0
                Try
                    val = CType(sender.GetRowCellValue(e.RowHandle, sender.Columns("status")), Integer)
                Catch ex As Exception

                End Try
                If val > 0 Then
                    e.Appearance.BackColor = Color.Salmon
                    e.Appearance.BackColor2 = Color.Salmon
                ElseIf val < 0 Then
                    e.Appearance.BackColor = Color.Yellow
                    e.Appearance.BackColor2 = Color.Yellow
                Else
                    e.Appearance.BackColor = Color.Green
                    e.Appearance.BackColor2 = Color.Green
                End If
            End If
        End If
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
            GridColumnColor.VisibleIndex = 4
            GridColumnQty.VisibleIndex = 5
            GridColumnRemark.VisibleIndex = 6
            GridColumnStatus.VisibleIndex = 7
            GridColumnStatus.Visible = False
            GridColumnNumber.Visible = False
            GridColumnFrom.Visible = False
            GridColumnTo.Visible = False
            GVItemList.OptionsPrint.PrintFooter = True
            GVItemList.OptionsPrint.PrintHeader = True
            Cursor = Cursors.Default
        End If
    End Sub

    Public Sub ExportToExcel(ByVal dtTemp As DevExpress.XtraGrid.Views.Grid.GridView, ByVal filepath As String, show_msg As Boolean)
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
                ElseIf j = 1 Then 'qty
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "fg_trf_det_qty")
                ElseIf j = 2 Then 'number
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "number").ToString
                ElseIf j = 3 Then 'from
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "from").ToString
                ElseIf j = 4 Then 'to
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "to").ToString
                Else
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "fg_trf_det_note").ToString
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

    Private Sub BtnXlsBOF_Click(sender As Object, e As EventArgs) Handles BtnXlsBOF.Click
        exportToBOF(True)
    End Sub

    Private Sub BtnVerify_Click(sender As Object, e As EventArgs) Handles BtnVerify.Click
        Cursor = Cursors.WaitCursor
        'cek qty limit SO di DB
        verifyTrans()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVItemList.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName = "from" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompFrom.Text.ToString
        ElseIf e.Column.FieldName = "to" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompTo.Text.ToString
        ElseIf e.Column.FieldName = "number" AndAlso e.IsGetData Then
            e.Value = TxtNumber.Text.ToString
        End If
    End Sub
End Class