Public Class FormViewSalesReturnQC 
    Public action As String
    Public id_sales_return_qc As String = "-1"
    Public id_sales_return As String = "-1"
    Public id_store_contact_from As String = "-1"
    Public id_store As String = "-1"
    Public id_comp_contact_to As String = "-1"
    Public id_comp_contact_to_return As String = "-1"
    Public id_report_status As String
    Public id_sales_return_qc_det_list As New List(Of String)
    Public id_sales_return_qc_det_counting_list As New List(Of String)
    Public id_sales_return_qc_det_drawer_list As New List(Of String)
    Public id_sales_return_qc_det_drawer_detail_list As New List(Of String)
    Public id_comp_user As String = "-1"
    Public dt As New DataTable
    Public id_comp_to As String = "-1"
    Public id_comp_to_return As String = "-1"
    'Dim is_scan As Boolean = False

    'var check qty
    Public cond_check As Boolean = True
    Public sample_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal

    'updated 28 Desember 2014
    Public id_drawer As String = "-1"
    Public id_wh_drawer_to As String = "-1"
    Dim locator_sel As String = "-1"
    Dim rack_sel As String = "-1"
    Dim drawer_sel As String = "-1"
    Dim report_mark_type_loc As String = "-1"
    Public id_wh_type As String = "-1"

    Private Sub FormSalesReturnQCDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewPLCat()
        actionLoad()

        'sementara
        SCCStorage.Panel2.Hide()
    End Sub

    Sub actionLoad()
        GroupControlListItem.Enabled = True
        GroupControlScannedItem.Enabled = True
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True

        'query view based on edit id's
        Dim query As String = "SELECT drw.wh_drawer_code, (a.id_wh_drawer) AS id_wh_drawer_to,b.id_sales_return,b.id_wh_drawer, (c2.id_comp) AS id_comp_to_return,(b.id_comp_contact_to) AS id_comp_contact_to_return,a.id_store_contact_from, a.id_comp_contact_to, (d.comp_name) AS store_name_from, (d1.comp_name) AS comp_name_to, get_custom_rmk(d1.id_wh_type,49) AS `report_mark_type`, (d2.comp_name) AS comp_name_to_return, (d.comp_number) AS store_number_from, (d1.comp_number) AS comp_number_to, (d2.comp_number) AS comp_number_to_return,(d.address_primary) AS store_address_from, a.id_report_status, f.report_status, "
        query += "a.sales_return_qc_note,a.sales_return_qc_date, a.sales_return_qc_number, b.sales_return_number, "
        query += "DATE_FORMAT(a.sales_return_qc_date,'%Y-%m-%d') AS sales_return_qc_datex, (c.id_comp) AS id_store, (c1.id_comp) AS id_comp_to, a.id_pl_category  "
        query += "FROM tb_sales_return_qc a "
        query += "INNER JOIN tb_sales_return b ON a.id_sales_return = b.id_sales_return "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_from "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact c1 ON c1.id_comp_contact = a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d1 ON c1.id_comp = d1.id_comp "
        query += "INNER JOIN tb_m_comp_contact c2 ON c2.id_comp_contact = b.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d2 ON c2.id_comp = d2.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = a.id_wh_drawer "
        query += "WHERE a.id_sales_return_qc = '" + id_sales_return_qc + "' "
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        id_report_status = data.Rows(0)("id_report_status").ToString
        id_store_contact_from = data.Rows(0)("id_store_contact_from").ToString
        id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
        TxtSalesReturnQCNumber.Text = data.Rows(0)("sales_return_qc_number").ToString
        TxtSalesReturnNumber.Text = data.Rows(0)("sales_return_number").ToString
        TxtNameCompFrom.Text = data.Rows(0)("store_name_from").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("store_number_from").ToString
        TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
        TxtCodeCompTo.Text = data.Rows(0)("comp_number_to").ToString
        TxtNameFrom.Text = data.Rows(0)("comp_name_to_return").ToString
        TxtCodeFrom.Text = data.Rows(0)("comp_number_to_return").ToString
        MEAdrressCompFrom.Text = data.Rows(0)("store_address_from").ToString
        DEForm.Text = view_date_from(data.Rows(0)("sales_return_qc_datex").ToString, 0)
        MENote.Text = data.Rows(0)("sales_return_qc_note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        LEPLCategory.ItemIndex = LEPLCategory.Properties.GetDataSourceRowIndex("id_pl_category", data.Rows(0)("id_pl_category").ToString)
        id_sales_return = data.Rows(0)("id_sales_return").ToString
        id_store = data.Rows(0)("id_store").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        id_comp_contact_to_return = data.Rows(0)("id_comp_contact_to_return").ToString
        id_comp_to_return = data.Rows(0)("id_comp_to_return").ToString
        id_drawer = data.Rows(0)("id_wh_drawer").ToString

        TEDrawer.Text = data.Rows(0)("wh_drawer_code").ToString
        id_wh_drawer_to = data.Rows(0)("id_wh_drawer_to").ToString
        report_mark_type_loc = data.Rows(0)("report_mark_type").ToString
        'drawer_sel = data.Rows(0)("wh_drawer").ToString
        'rack_sel = data.Rows(0)("wh_rack").ToString
        'locator_sel = data.Rows(0)("wh_locator").ToString

        'detail2
        viewDetail()
        view_barcode_list()
        viewDetailDrawer()
        viewDetailDrawer2()
        check_but()
        allow_status()

        'XTPStorage.PageEnabled = True
        'BtnTest.Visible = True
    End Sub
    'Sub viewSalesReturnOrder()
    '    Dim query As String = "SELECT a.id_sales_return_order, a.id_store_contact_to, (d.comp_name) AS store_name_to,a.id_report_status, f.report_status, "
    '    query += "a.sales_return_order_note, a.sales_return_order_note, a.sales_return_order_number, "
    '    query += "DATE_FORMAT(a.sales_return_order_date,'%d %M %Y') AS sales_return_order_date, "
    '    query += "DATE_FORMAT(a.sales_return_order_est_date,'%d %M %Y') AS sales_return_order_est_date "
    '    query += "FROM tb_sales_return_order a "
    '    'query += "INNER JOIN tb_sales_return_order_det b ON a.id_sales_return_order = b.id_sales_return_order "
    '    query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
    '    query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
    '    query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
    '    query += "WHERE a.id_sales_return_order ='" + id_sales_return_order + "' "
    '    query += "ORDER BY a.id_sales_return_order ASC "
    '    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

    '    'SO
    '    TxtSalesReturnNumber.Text = data.Rows(0)("sales_return_order_number").ToString

    '    'store data
    '    Dim query_comp_to As String = "SELECT id_comp FROM tb_m_comp_contact WHERE id_comp_contact = '" + data.Rows(0)("id_store_contact_to").ToString + "'"
    '    Dim id_comp_from As String = execute_query(query_comp_to, 0, True, "", "", "", "")
    '    id_store = id_comp_from
    '    id_store_contact_from = data.Rows(0)("id_store_contact_to").ToString
    '    TxtCodeCompFrom.Text = get_company_x(id_comp_from, 2)
    '    TxtNameCompFrom.Text = get_company_x(id_comp_from, 1)
    '    'MEAdrressCompTo.Text = get_company_x(id_comp_to, 3)

    '    'general
    '    viewDetail()
    '    viewDetailDrawer()
    '    viewDetailDrawer2()
    '    view_barcode_list()
    '    GroupControlListItem.Enabled = True
    '    GroupControlScannedItem.Enabled = True
    '    BtnInfoSrs.Enabled = True
    '    GVItemList.OptionsBehavior.AutoExpandAllGroups = True
    'End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewPLCat()
        Dim query As String = "SELECT * FROM tb_lookup_pl_category a ORDER BY a.id_pl_category  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEPLCategory, query, 0, "pl_category", "id_pl_category")
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_sales_return_qc('" + id_sales_return_qc + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub


    Sub view_barcode_list()
        Dim id_sales_return_qc_det = "-1"
        Try
            id_sales_return_qc_det = GVItemList.GetFocusedRowCellValue("id_sales_return_qc_det").ToString
        Catch ex As Exception
        End Try

        Dim query As String = ""
        query += "SELECT ('') AS no, CONCAT(c.product_full_code, a.sales_return_qc_det_counting) AS code, (c.product_full_code) AS product_code, "
        query += "(a.sales_return_qc_det_counting) AS counting_code, "
        query += "a.id_sales_return_det_counting, a.id_sales_return_qc_det_counting,('2') AS is_fix, "
        query += "d0.id_pl_prod_order_rec_det_unique, b.id_product, "
        query += "d.bom_unit_price, b.id_design_price, b.design_price, rj.reject_type "
        query += "FROM tb_sales_return_qc_det_counting a "
        query += "INNER JOIN tb_sales_return_qc_det b ON a.id_sales_return_qc_det = b.id_sales_return_qc_det "
        query += "INNER JOIN tb_m_product c ON c.id_product = b.id_product "
        query += "LEFT JOIN tb_sales_return_det_counting d0 ON d0.id_sales_return_det_counting = a.id_sales_return_det_counting "
        query += "LEFT JOIN tb_pl_prod_order_rec_det_counting d ON d.id_pl_prod_order_rec_det_unique = d0.id_pl_prod_order_rec_det_unique "
        query += "LEFT JOIN tb_m_reject_type rj ON rj.id_reject_type = a.id_reject_type "
        query += "WHERE b.id_sales_return_qc = '" + id_sales_return_qc + "' AND a.id_sales_return_qc_det = '" + id_sales_return_qc_det + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
    End Sub

    Sub viewDetailDrawer()
        Dim query As String = ""
        query += "SELECT a.id_sales_return_qc_det_drawer, ('0') AS id_sales_return_det_drawer ,a.id_sales_return_qc_det, "
        query += "a.sales_return_qc_det_drawer_qty, a.sales_return_qc_det_drawer_qty_stored, a.bom_unit_price, b.id_product, "
        query += "('-') AS drawer, "
        query += "('-') AS rack, "
        query += "('-') AS locator, "
        query += "('-') AS wh, "
        query += "b.id_design_price, b.design_price "
        query += "FROM tb_sales_return_qc_det_drawer a "
        query += "INNER JOIN tb_sales_return_qc_det b ON a.id_sales_return_qc_det = b.id_sales_return_qc_det "
        'query += "LEFT JOIN tb_m_wh_drawer c ON c.id_wh_drawer = a.id_wh_drawer "
        'query += "LEFT JOIN tb_m_wh_rack d ON d.id_wh_rack = c.id_wh_rack "
        'query += "LEFT JOIN tb_m_wh_locator e ON e.id_wh_locator = d.id_wh_locator "
        'query += "LEFT JOIN tb_m_comp f ON f.id_comp = e.id_comp "
        query += "WHERE b.id_sales_return_qc = '" + id_sales_return_qc + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_sales_return_qc_det_drawer_list.Add(data.Rows(i)("id_sales_return_qc_det_drawer").ToString)
        Next
        GCDrawer.DataSource = data
    End Sub

    Sub viewDetailDrawer2()
        'SKIP
        'Dim query As String = ""
        'query += "SELECT IF(ISNULL(a.id_sales_return_det_drawer_detail), '0', a.id_sales_return_det_drawer_detail) as id_sales_return_det_drawer_detail, b.id_sales_return_det_drawer, "
        'query += "b1.id_sales_return, "
        'query += "(c.wh_drawer_code) AS drawer, "
        'query += "(d.wh_rack_code) AS rack, "
        'query += "(e.wh_locator_code) AS locator, "
        'query += "(f.comp_number) AS wh  "
        'query += "FROM tb_sales_return_det_drawer_detail a "
        'query += "INNER JOIN tb_sales_return_det_drawer b ON a.id_sales_return_det_drawer = b.id_sales_return_det_drawer "
        'query += "INNER JOIN tb_sales_return_det b1 ON b1.id_sales_return_det = b.id_sales_return_det "
        'query += "INNER JOIN tb_m_wh_drawer c ON c.id_wh_drawer = a.id_wh_drawer "
        'query += "INNER JOIN tb_m_wh_rack d ON d.id_wh_rack = c.id_wh_rack "
        'query += "INNER JOIN tb_m_wh_locator e ON e.id_wh_locator = d.id_wh_locator "
        'query += "INNER JOIN tb_m_comp f ON f.id_comp = e.id_comp "
        'query += "WHERE b1.id_sales_return = '" + id_sales_return + "' "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'For i As Integer = 0 To (data.Rows.Count - 1)
        '    id_sales_return_det_drawer_detail_list.Add(data.Rows(i)("id_sales_return_det_drawer_detail").ToString)
        'Next
        'GCDrawerDetail.DataSource = data
    End Sub

    Sub codeAvailableIns(ByVal id_product_param As String, ByVal id_store_param As String, ByVal id_design_price_param As String)
        Dim query As String = ""
      query = "CALL view_stock_fg_unique_ret_qc('" + id_product_param + "','" + id_store_param + "', '" + id_design_price_param + "', '" + id_sales_return + "','" + id_sales_return_qc + "')"
        Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
        For k As Integer = 0 To (datax.Rows.Count - 1)
            insertDt(datax.Rows(k)("id_product").ToString, datax.Rows(k)("id_sales_return_det_counting").ToString, datax.Rows(k)("product_code").ToString, datax.Rows(k)("product_counting_code").ToString, datax.Rows(k)("product_full_code").ToString, Decimal.Parse(datax.Rows(k)("bom_unit_price").ToString), datax.Rows(k)("id_design_price").ToString, Decimal.Parse(datax.Rows(k)("design_price").ToString))
        Next
        'GCTest.DataSource = dt
    End Sub

    Sub insertDt(ByVal id_product_param As String, ByVal id_sales_return_det_counting_param As String, ByVal product_code_param As String, ByVal product_counting_code_param As String, ByVal product_full_code_param As String, ByVal cost_param As Decimal, ByVal id_design_price_param As String, ByVal design_price_param As Decimal)
        Dim R As DataRow = dt.NewRow
        R("id_product") = id_product_param
        R("id_sales_return_det_counting") = id_sales_return_det_counting_param
        R("product_code") = product_code_param
        R("product_counting_code") = product_counting_code_param
        R("product_full_code") = product_full_code_param
        R("bom_unit_price") = cost_param
        R("id_design_price") = id_design_price_param
        R("design_price") = design_price_param
        dt.Rows.Add(R)
    End Sub

    Sub codeAvailableDel(ByVal id_product_param As String, ByVal id_design_price_param As String)
        Dim i As Integer = dt.Rows.Count - 1
        While (i >= 0)
            If dt.Rows(i)("id_product").ToString = id_product_param And dt.Rows(i)("id_design_price").ToString = id_design_price_param Then
                dt.Rows.RemoveAt(i)
            End If
            i = i - 1
        End While
    End Sub

    'sub check_but
    Sub check_but()
        Dim id_productx As String = "0"
        Try
            id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception

        End Try
    End Sub

    Sub allow_status()
        LEPLCategory.Enabled = False
        TEDrawer.Properties.ReadOnly = True
        BtnAttachment.Enabled = True

        TxtSalesReturnQCNumber.Focus()
    End Sub

    'DeleteRows
    Sub deleteRowsBc()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
        GVBarcode.FocusedColumn = GVBarcode.VisibleColumns(0)
        GVBarcode.ShowEditor()
    End Sub
    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub allowDelete()

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

    Sub countQty(ByVal id_product_param As String, ByVal id_design_price_param As String, ByVal design_price_param As Decimal)
        Dim tot As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_product As String = GVBarcode.GetRowCellValue(i, "id_product").ToString
            Dim id_design_price As String = GVBarcode.GetRowCellValue(i, "id_design_price").ToString
            Dim design_price As Decimal = Decimal.Parse(GVBarcode.GetRowCellValue(i, "design_price").ToString)
            If id_product = id_product_param And id_design_price = id_design_price_param And design_price = design_price_param Then
                tot = tot + 1.0
            End If
        Next
        'MsgBox(tot.ToString)
        Dim indeks As Integer = 0
        For j As Integer = 0 To GVItemList.RowCount - 1
            Try
                Dim id_productx As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                Dim id_design_pricex As String = GVItemList.GetRowCellValue(j, "id_design_price").ToString
                Dim design_pricex As Decimal = Decimal.Parse(GVItemList.GetRowCellValue(j, "design_price").ToString)
                If id_productx = id_product_param And id_design_pricex = id_design_price_param And design_pricex = design_price_param Then
                    indeks = j
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next

        GVItemList.FocusedRowHandle = indeks
        Dim price As Decimal = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price").ToString)
        GVItemList.SetFocusedRowCellValue("sales_return_qc_det_amount", tot * price)
        GVItemList.SetFocusedRowCellValue("sales_return_qc_det_qty", tot)
    End Sub



    Private Sub FormSalesReturnQCDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_sales_return_qc
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = report_mark_type_loc
        FormReportMark.form_origin = Name
        FormReportMark.is_view_finalize = "1"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_FocusedRowChanged_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        view_barcode_list()
        Cursor = Cursors.Default
    End Sub



    Sub countQtyFromWh(ByVal id_product_param As String)
        'Dim jum As Decimal = 0.0
        'For i As Integer = 0 To (GVDrawer.RowCount - 1)
        '    Try
        '        Dim id_product_i As String = GVDrawer.GetRowCellValue(i, "id_product").ToString
        '        If id_product_i = id_product_param Then
        '            jum = jum + Decimal.Parse(GVDrawer.GetRowCellValue(i, "qty_all_product"))
        '        End If
        '    Catch ex As Exception

        '    End Try
        'Next
        'GVItemList.FocusedRowHandle = find_row(GVItemList, "id_product", id_product_param)
        'GVItemList.SetFocusedRowCellValue("qty_from_wh", jum)
        'allowScanPage()
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
        'Dim id_pl_sales_order_del_det As String = ""
        Dim counting_code As String = ""
        Dim id_sales_return_det_counting As String = ""
        Dim id_product As String = ""
        Dim bom_unit_price As Decimal = 0.0
        Dim id_design_price As String = ""
        Dim design_price As Decimal = 0.0

        'check available code
        For i As Integer = 0 To (dt.Rows.Count - 1)
            Dim code As String = dt.Rows(i)("product_full_code").ToString
            'id_pl_sales_order_del_det = dt.Rows(i)("id_pl_prod_order_det").ToString
            counting_code = dt.Rows(i)("product_counting_code").ToString
            id_sales_return_det_counting = dt.Rows(i)("id_sales_return_det_counting").ToString
            id_product = dt.Rows(i)("id_product").ToString
            bom_unit_price = Decimal.Parse(dt.Rows(i)("bom_unit_price").ToString)
            id_design_price = dt.Rows(i)("id_design_price").ToString
            design_price = Decimal.Parse(dt.Rows(i)("design_price").ToString)
            If code = code_check Then
                'MsgBox(id_product)
                code_found = True
                Exit For
            End If
        Next

        'check duplicate code
        If GVBarcode.RowCount <= 0 Then
            code_duplicate = False
        Else
            For i As Integer = 0 To (GVBarcode.RowCount - 1)
                Dim code As String = ""
                If Not IsDBNull(GVBarcode.GetRowCellValue(i, "code")) Then
                    code = GVBarcode.GetRowCellValue(i, "code".ToString)
                End If

                Dim is_fix As String = "1"
                If Not IsDBNull(GVBarcode.GetRowCellValue(i, "is_fix")) Then
                    is_fix = GVBarcode.GetRowCellValue(i, "is_fix").ToString
                End If

                If code = code_check And is_fix = "2" Then
                    code_duplicate = True
                    Exit For
                End If
            Next
        End If


        If Not code_found Then
            GVBarcode.SetFocusedRowCellValue("code", "")
            stopCustom("Data not found or duplicate!")
        ElseIf code_duplicate Then
            GVBarcode.SetFocusedRowCellValue("code", "")
            stopCustom("Data duplicate !")
        Else
            'MsgBox(id_pl_prod_order_rec_det_unique)
            'MsgBox(counting_code)
            'MsgBox(id_product)
            'MsgBox(bom_unit_price)
            GVBarcode.SetFocusedRowCellValue("id_sales_return_det_counting", id_sales_return_det_counting)
            GVBarcode.SetFocusedRowCellValue("id_sales_return_qc_det_counting", "0")
            GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            'GVBarcode.SetFocusedRowCellValue("id_pl_sales_order_del_det", id_pl_sales_order_del_det)
            GVBarcode.SetFocusedRowCellValue("counting_code", counting_code)
            GVBarcode.SetFocusedRowCellValue("id_product", id_product)
            GVBarcode.SetFocusedRowCellValue("bom_unit_price", bom_unit_price)
            GVBarcode.SetFocusedRowCellValue("id_design_price", id_design_price)
            GVBarcode.SetFocusedRowCellValue("design_price", design_price)
            countQty(id_product, id_design_price, design_price)
            checkUnitCost(id_product, bom_unit_price, id_design_price)
            newRowsBc()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub deleteDetailBC(ByVal id_product_param As String, ByVal id_design_price_param As String)
        'delete detail
        Dim i As Integer = GVBarcode.RowCount - 1
        While (i >= 0)
            Dim id_product As String = ""
            Dim id_design_price As String = ""
            Try
                id_product = GVBarcode.GetRowCellValue(i, "id_product").ToString()
                id_design_price = GVBarcode.GetRowCellValue(i, "id_design_price").ToString()
            Catch ex As Exception

            End Try
            If id_product = id_product_param And id_design_price = id_design_price_param Then
                GVBarcode.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub

    Sub deleteDetailDrawer(ByVal id_product_param As String)
        'delete(detail)
        Dim i As Integer = GVDrawer.RowCount - 1
        While (i >= 0)
            'MsgBox(id_product_param)
            Dim id_product As String = ""
            Try
                id_product = GVDrawer.GetRowCellValue(i, "id_product").ToString()
            Catch ex As Exception

            End Try
            If id_product = id_product_param Then
                GVDrawer.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub

    'SKIP
    Sub infoQty()
        FormInfoSalesReturn.id_pop_up = "1"
        FormInfoSalesReturn.id_sales_return = id_sales_return
        FormInfoSalesReturn.id_sales_return_det = "0"
        FormInfoSalesReturn.id_sales_return_qc = id_sales_return_qc
        FormInfoSalesReturn.ShowDialog()
    End Sub


    Sub checkUnitCost(ByVal id_product_param As String, ByVal bom_unit_price_param As Decimal, ByVal id_design_price_param As String)
        Dim is_found As Boolean = False
        Dim indeks_found As Integer = 0

        For i As Integer = 0 To (GVDrawer.RowCount - 1)
            Dim id_product_cek As String = "-1"
            Dim cost As Decimal = 0.0
            Dim id_design_price_cek As String = "-1"
            Try
                id_product_cek = GVDrawer.GetRowCellValue(i, "id_product").ToString
                cost = Decimal.Parse(GVDrawer.GetRowCellValue(i, "bom_unit_price").ToString)
                id_design_price_cek = GVDrawer.GetRowCellValue(i, "id_design_price").ToString
                If id_product_cek = id_product_param And bom_unit_price_param = cost And id_design_price_param = id_design_price_cek Then
                    is_found = True
                    indeks_found = i
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next

        If is_found Then
            'update qty
            'MsgBox("update")
            countUnitCost(id_product_param, bom_unit_price_param, id_design_price_param)
        Else
            'tambah baris baru
            'MsgBox("new")
            Dim newRow As DataRow = (TryCast(GCDrawer.DataSource, DataTable)).NewRow()
            newRow("id_sales_return_qc_det_drawer") = "0"
            newRow("id_sales_return_qc_det") = "0"
            'newRow("id_wh_drawer") = "0"
            newRow("id_product") = id_product_param
            newRow("drawer") = "-"
            newRow("rack") = "-"
            newRow("locator") = "-"
            newRow("sales_return_qc_det_drawer_qty_stored") = 0.0
            newRow("sales_return_qc_det_drawer_qty") = 1.0
            newRow("bom_unit_price") = bom_unit_price_param
            newRow("id_design_price") = id_design_price_param
            TryCast(GCDrawer.DataSource, DataTable).Rows.Add(newRow)
            GCDrawer.RefreshDataSource()
            GVDrawer.RefreshData()
        End If
    End Sub

    Sub countUnitCost(ByVal id_product_param As String, ByVal bom_unit_price_param As Decimal, ByVal id_design_price_param As String)
        Dim tot As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_product As String = "-1"
            Dim cost As Decimal = 0.0
            Dim id_design_price As String = "-1"
            Try
                id_product = GVBarcode.GetRowCellValue(i, "id_product").ToString
                cost = Decimal.Parse(GVBarcode.GetRowCellValue(i, "bom_unit_price").ToString)
                id_design_price = GVBarcode.GetRowCellValue(i, "id_design_price").ToString
            Catch ex As Exception
            End Try

            If id_product = id_product_param And cost = bom_unit_price_param And id_design_price = id_design_price_param Then
                tot = tot + 1.0
            End If
        Next

        'cari yg sesuai
        For j As Integer = 0 To (GVDrawer.RowCount - 1)
            Dim id_product_cek As String = "-1"
            Dim cost As Decimal = 0.0
            Dim id_design_price_cek As String = "-1"
            Try
                id_product_cek = GVDrawer.GetRowCellValue(j, "id_product").ToString
                cost = Decimal.Parse(GVDrawer.GetRowCellValue(j, "bom_unit_price").ToString)
                id_design_price_cek = GVDrawer.GetRowCellValue(j, "id_design_price").ToString
                If id_product_cek = id_product_param And bom_unit_price_param = cost And id_design_price_param = id_design_price_cek Then
                    'MsgBox(tot.ToString)
                    GVDrawer.SetRowCellValue(j, "sales_return_qc_det_drawer_qty", tot)
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next
    End Sub

   
    Private Sub GVDrawer_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDrawer.FocusedRowChanged
        Try
            Dim id_product As String = GVDrawer.GetFocusedRowCellValue("id_product").ToString
            Dim id_design_price As String = GVDrawer.GetFocusedRowCellValue("id_design_price").ToString

            Dim indeks As Integer
            For i As Integer = 0 To (GVItemList.RowCount - 1)
                Try
                    If id_product = GVItemList.GetRowCellValue(i, "id_product").ToString And id_design_price = GVItemList.GetRowCellValue(i, "id_design_price").ToString Then
                        'MsgBox(id_product.ToString + " " + GVDrawer.GetRowCellValue(i, "id_product").ToString)
                        'MsgBox(id_design_price.ToString + " " + GVDrawer.GetRowCellValue(i, "id_design_price").ToString)
                        indeks = i
                        Exit For
                    End If
                Catch ex As Exception
                End Try
            Next
            GVItemList.FocusedRowHandle = indeks

            'drawer detail
            check_but_drawer()
        Catch ex As Exception
        End Try
    End Sub

    'Color Cell
    Public Sub my_color_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        'MsgBox("HAH")
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White

        Try
            Dim id_product_style As String = GVItemList.GetFocusedRowCellValue("id_product").ToString
            Dim id_design_price_style As String = GVItemList.GetFocusedRowCellValue("id_design_price").ToString

            Dim id_product_check As String = View.GetRowCellValue(e.RowHandle, View.Columns("id_product"))
            Dim id_design_price_check As String = View.GetRowCellValue(e.RowHandle, View.Columns("id_design_price"))
            If id_product_check = id_product_style And id_design_price_check = id_design_price_style Then
                e.Appearance.BackColor = Color.Lavender
                e.Appearance.BackColor2 = Color.White
                GVDrawer.FocusedRowHandle = e.RowHandle
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub check_but_drawer()
        If GVDrawer.RowCount > 0 Then
            PanelNavStorage.Enabled = True
        Else
            PanelNavStorage.Enabled = False
        End If
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.id_report = id_sales_return_qc
        FormDocumentUpload.report_mark_type = report_mark_type_loc
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVItemList.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        view_barcode_list()
        Cursor = Cursors.Default
    End Sub
End Class