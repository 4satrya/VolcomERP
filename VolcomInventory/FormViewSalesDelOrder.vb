Public Class FormViewSalesDelOrder 
    Public action As String
    Public id_pl_sales_order_del As String = "-1"
    Public id_sales_order As String = "-1"
    Public id_store_contact_to As String = "-1"
    Public id_comp_contact_from As String = "-1"
    Public id_report_status As String
    Public id_pl_sales_order_del_det_list As New List(Of String)
    Public id_pl_sales_order_del_det_counting_list As New List(Of String)
    Public id_pl_sales_order_del_det_drawer_list As New List(Of String)
    Dim id_season_default As String
    Dim id_delivery_default As String
    Public id_comp_user As String = "-1"
    Public dt As New DataTable
    'Dim is_scan As Boolean = False


    'var check qty
    Public cond_check As Boolean = True
    Public sample_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal

    Private Sub FormViewSalesOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewSoType()
        viewSoStatus()
        viewDelivery()
        actionLoad()
    End Sub

    Sub actionLoad()
        Try
            'initiation datatable jika blm ada
            dt.Columns.Add("id_product")
            dt.Columns.Add("id_pl_prod_order_rec_det_unique")
            dt.Columns.Add("product_code")
            dt.Columns.Add("product_counting_code")
            dt.Columns.Add("product_full_code")
        Catch ex As Exception

        End Try

        GroupControlListItem.Enabled = True
        GroupControlScannedItem.Enabled = True
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
        XTPOutboundScanNew.PageEnabled = True

        'query view based on edit id's
        Dim query As String = "SELECT b.id_so_status, b.id_sales_order, a.id_store_contact_to, a.id_comp_contact_from, (d.comp_name) AS store_name_to, (d1.comp_name) AS comp_name_from, (d.comp_number) AS store_number_to, (d1.comp_number) AS comp_number_from, (d.address_primary) AS store_address_to, a.id_report_status, f.report_status, "
        query += "a.pl_sales_order_del_note, a.pl_sales_order_del_date, a.pl_sales_order_del_number, b.sales_order_number, "
        query += "DATE_FORMAT(a.pl_sales_order_del_date,'%Y-%m-%d') AS pl_sales_order_del_datex, b.id_so_type "
        query += "FROM tb_pl_sales_order_del a "
        query += "INNER JOIN tb_sales_order b ON a.id_sales_order = b.id_sales_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact c1 ON c1.id_comp_contact = a.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp d1 ON c1.id_comp = d1.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_lookup_so_type g ON g.id_so_type = b.id_so_type "
        query += "INNER JOIN tb_lookup_so_status h ON h.id_so_status = b.id_so_status "
        query += "WHERE a.id_pl_sales_order_del = '" + id_pl_sales_order_del + "' "
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        id_report_status = data.Rows(0)("id_report_status").ToString
        id_store_contact_to = data.Rows(0)("id_store_contact_to").ToString
        id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
        TxtSalesOrder.Text = data.Rows(0)("sales_order_number").ToString
        TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
        TxtNameCompTo.Text = data.Rows(0)("store_name_to").ToString
        TxtCodeCompTo.Text = data.Rows(0)("store_number_to").ToString
        MEAdrressCompTo.Text = data.Rows(0)("store_address_to").ToString
        DEForm.Text = view_date_from(data.Rows(0)("pl_sales_order_del_datex").ToString, 0)
        TxtSalesDelOrderNumber.Text = data.Rows(0)("pl_sales_order_del_number").ToString
        MENote.Text = data.Rows(0)("pl_sales_order_del_note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)
        LEStatusSO.ItemIndex = LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", data.Rows(0)("id_so_status").ToString)
        id_sales_order = data.Rows(0)("id_sales_order").ToString

        'detail2
        viewDetail()
        view_barcode_list()
        viewDetailDrawer()
        check_but()
        allow_status()
    End Sub
    Sub viewSalesOrder()
        Dim query As String = "SELECT a.id_so_type, a.id_so_status, a.id_sales_order, a.id_store_contact_to, (d.comp_name) AS store_name_to,a.id_report_status, f.report_status, "
        query += "a.sales_order_note, a.id_delivery, e.delivery, e1.id_season, e1.season,a.sales_order_date, a.sales_order_note, a.sales_order_number, "
        query += "DATE_FORMAT(a.sales_order_date,'%d %M %Y') AS sales_order_date, (SELECT COUNT(id_pl_sales_order_del) FROM tb_pl_sales_order_del WHERE tb_pl_sales_order_del.id_sales_order = a.id_sales_order) AS pl_created "
        query += "FROM tb_sales_order a "
        'query += "INNER JOIN tb_sales_order_det b ON a.id_sales_order = b.id_sales_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_season_delivery e ON e.id_delivery = a.id_delivery "
        query += "INNER JOIN tb_season e1 ON e.id_season = e1.id_season "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "WHERE a.id_sales_order = '" + id_sales_order + "' "
        query += "ORDER BY e1.date_season_start DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'SO
        TxtSalesOrder.Text = data.Rows(0)("sales_order_number").ToString

        'store data
        Dim query_comp_to As String = "SELECT id_comp FROM tb_m_comp_contact WHERE id_comp_contact = '" + data.Rows(0)("id_store_contact_to").ToString + "'"
        Dim id_comp_to As String = execute_query(query_comp_to, 0, True, "", "", "", "")
        id_store_contact_to = data.Rows(0)("id_store_contact_to").ToString
        TxtCodeCompTo.Text = get_company_x(id_comp_to, 2)
        TxtNameCompTo.Text = get_company_x(id_comp_to, 1)
        MEAdrressCompTo.Text = get_company_x(id_comp_to, 3)

        'tipe & status SO
        LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)
        LEStatusSO.ItemIndex = LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", data.Rows(0)("id_so_status").ToString)

        'general
        viewDetail()
        viewDetailDrawer()
        view_barcode_list()
        GroupControlListItem.Enabled = True
        GroupControlScannedItem.Enabled = True
        check_but()
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
    End Sub

    Sub viewSoType()
        Dim query As String = "SELECT * FROM tb_lookup_so_type a ORDER BY a.id_so_type "
        viewLookupQuery(LETypeSO, query, 0, "so_type", "id_so_type")
    End Sub

    Sub viewSoStatus()
        Dim query As String = "SELECT * FROM tb_lookup_so_status a ORDER BY a.id_so_status "
        viewLookupQuery(LEStatusSO, query, 0, "so_status", "id_so_status")
    End Sub

    Sub viewDelivery()

    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_pl_sales_order_del('" + id_pl_sales_order_del + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        'For i As Integer = 0 To (data.Rows.Count - 1)
        '    id_pl_sales_order_del_det_list.Add(data.Rows(i)("id_pl_sales_order_del_det").ToString)
        '    codeAvailableIns(data.Rows(i)("id_product").ToString)
        'Next
        GCItemList.DataSource = data
    End Sub

    Sub view_barcode_list()
        Dim id_productx As String = "-1"
        Try
            id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try

        Dim query As String = ""
        query += "SELECT ('') AS no, CONCAT(c.product_full_code, a.pl_sales_order_del_det_counting) AS code, "
        query += "(a.pl_sales_order_del_det_counting) AS counting_code, "
        query += "a.id_pl_sales_order_del_det_counting, ('2') AS is_fix, "
        query += "a.id_pl_prod_order_rec_det_unique, b.id_product "
        query += "FROM tb_pl_sales_order_del_det_counting a "
        query += "INNER JOIN tb_pl_sales_order_del_det b ON a.id_pl_sales_order_del_det = b.id_pl_sales_order_del_det "
        query += "INNER JOIN tb_m_product c ON c.id_product = b.id_product "
        query += "WHERE b.id_pl_sales_order_del = '" + id_pl_sales_order_del + "' AND b.id_product='" + id_productx + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_pl_sales_order_del_det_counting_list.Add(data.Rows(i)("id_pl_sales_order_del_det_counting").ToString)
        Next
        GCBarcode.DataSource = data
    End Sub

    Sub viewDetailDrawer()

    End Sub

    Sub codeAvailableIns(ByVal id_product_param As String)
        Dim query As String = "CALL view_stock_fg_unique_del('" + id_product_param + "') "
        Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
        For k As Integer = 0 To (datax.Rows.Count - 1)
            Dim R As DataRow = dt.NewRow
            R("id_product") = datax.Rows(k)("id_product").ToString
            R("id_pl_prod_order_rec_det_unique") = datax.Rows(k)("id_pl_prod_order_rec_det_unique").ToString
            R("product_code") = datax.Rows(k)("product_code").ToString
            R("product_counting_code") = datax.Rows(k)("product_counting_code").ToString
            R("product_full_code") = datax.Rows(k)("product_full_code").ToString
            dt.Rows.Add(R)
        Next
        'GCTest.DataSource = dt
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

    'sub check_but
    Sub check_but()
        
    End Sub

    Sub allow_status()
        MENote.Properties.ReadOnly = True
        GVItemList.OptionsCustomization.AllowQuickHideColumns = True
        BtnAttachment.Enabled = True

        TxtSalesDelOrderNumber.Focus()
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

    Private Sub GVBarcode_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        'MsgBox(GVBarcode.GetFocusedRowCellValue("code").ToString)
        'GVBarcode.AddNewRow()
        'MsgBox("k")
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

    Sub countQty(ByVal id_product_param As String)
        Dim tot As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_product As String = GVBarcode.GetRowCellValue(i, "id_product").ToString
            If id_product = id_product_param Then
                tot = tot + 1.0
            End If
        Next

        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_product", id_product_param)
        Dim price As Decimal = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price").ToString)
        GVItemList.SetFocusedRowCellValue("pl_sales_order_del_det_amount", tot * price)
        GVItemList.SetFocusedRowCellValue("pl_sales_order_del_det_qty", tot)
    End Sub


    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        view_barcode_list()
        viewDetailDrawer()
        Cursor = Cursors.Default
    End Sub


    Private Sub FormViewSalesOrder_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.is_view_finalize = "1"
        FormReportMark.id_report = id_pl_sales_order_del
        FormReportMark.report_mark_type = "43"
        FormReportMark.is_view = "1"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub countQtyFromWh(ByVal id_product_param As String)


    End Sub

    Sub allowScanPage()
        'allow page scan
        Dim allow_scan = True
        For i As Integer = 0 To (GVItemList.RowCount - 1)
            Try
                Dim qty_wh_cek As Decimal = Decimal.Parse(GVItemList.GetRowCellValue(i, "qty_from_wh"))
                If qty_wh_cek = 0.0 Then
                    allow_scan = False
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next
        'MsgBox(allow_scan)
        If Not allow_scan Or (GVItemList.RowCount <= 0) Then
            XTPOutboundScanNew.PageEnabled = False
        Else
            XTPOutboundScanNew.PageEnabled = True
        End If
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
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim code_duplicate As Boolean = False
        'Dim id_pl_sales_order_del_det As String = ""
        Dim counting_code As String = ""
        Dim id_pl_prod_order_rec_det_unique As String = ""
        Dim id_product As String = ""

        'check available code
        For i As Integer = 0 To (dt.Rows.Count - 1)
            Dim code As String = dt.Rows(i)("product_full_code").ToString
            'id_pl_sales_order_del_det = dt.Rows(i)("id_pl_prod_order_det").ToString
            counting_code = dt.Rows(i)("product_counting_code").ToString
            id_pl_prod_order_rec_det_unique = dt.Rows(i)("id_pl_prod_order_rec_det_unique").ToString
            id_product = dt.Rows(i)("id_product").ToString
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
            GVBarcode.SetFocusedRowCellValue("id_pl_prod_order_rec_det_unique", id_pl_prod_order_rec_det_unique)
            GVBarcode.SetFocusedRowCellValue("id_pl_sales_order_del_det_counting", "0")
            GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            'GVBarcode.SetFocusedRowCellValue("id_pl_sales_order_del_det", id_pl_sales_order_del_det)
            GVBarcode.SetFocusedRowCellValue("counting_code", counting_code)
            GVBarcode.SetFocusedRowCellValue("id_product", id_product)
            countQty(id_product)
            newRowsBc()
        End If
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

    Sub infoQty()
        If check_edit_report_status(id_report_status, "43", id_pl_sales_order_del) Then
            FormInfoSalesOrder.id_pop_up = "1"
            FormInfoSalesOrder.id_pl_sales_order_del = id_pl_sales_order_del
            FormInfoSalesOrder.id_sales_order = id_sales_order
            FormInfoSalesOrder.id_sales_order_det = "0"
            FormInfoSalesOrder.ShowDialog()
        Else
            FormInfoSalesOrder.id_pop_up = "1"
            FormInfoSalesOrder.id_sales_order = id_sales_order
            FormInfoSalesOrder.id_sales_order_det = "0"
            FormInfoSalesOrder.ShowDialog()
        End If
    End Sub

    'check limit qty
    Sub isAllowRequisition(ByVal sample_name As String, ByVal id_sales_order_det_cek As String, ByVal qty_plx As String)
        cond_check = True
        qty_pl = Decimal.Parse(qty_plx.ToString)
        sample_check = sample_name

        Dim query_check As String = ""
        'cek based on SO limit
        query_check += "SELECT c.id_sales_order, a.id_sales_order_det, a.id_product,a.sales_order_det_qty,(a.sales_order_det_qty - COALESCE(b.jum_del, 0)) AS qty_allow "
        query_check += "FROM tb_sales_order_det a "
        query_check += "LEFT JOIN "
        query_check += "(SELECT b1.id_sales_order_det, SUM(b1.pl_sales_order_del_det_qty) AS jum_del FROM tb_pl_sales_order_del_det b1 "
        query_check += "INNER JOIN tb_pl_sales_order_del b2 ON b1.id_pl_sales_order_del = b2.id_pl_sales_order_del "
        query_check += "WHERE b2.id_report_status != '5' "
        If action = "upd" Then
            query_check += "AND b2.id_pl_sales_order_del != '" + id_pl_sales_order_del + "' "
        End If
        query_check += "GROUP BY b1.id_sales_order_det) b ON a.id_sales_order_det = b.id_sales_order_det "
        query_check += "INNER JOIN tb_sales_order c ON a.id_sales_order = c.id_sales_order "
        query_check += "WHERE c.id_sales_order = '" + id_sales_order + "' AND a.id_sales_order_det LIKE '%" + id_sales_order_det_cek + "%' "

        Dim data As DataTable = execute_query(query_check, -1, True, "", "", "", "")
        allow_sum = Decimal.Parse(data.Rows(0)("qty_allow"))
        If qty_pl > allow_sum Then
            cond_check = False
        End If
    End Sub

   

    'Color Cell
    Public Sub my_color_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        'MsgBox("HAH")
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White

        Try
            Dim id_product_style As String = GVItemList.GetFocusedRowCellValue("id_product").ToString
            Dim id_product_check As String = View.GetRowCellValue(e.RowHandle, View.Columns("id_product"))
            If id_product_check = id_product_style Then
                e.Appearance.BackColor = Color.Lavender
                e.Appearance.BackColor2 = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub my_color_cell2(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White

        Try
            Dim id_product_style As String = GVItemList.GetFocusedRowCellValue("id_product").ToString
            Dim id_product_check As String = View.GetRowCellValue(e.RowHandle, View.Columns("id_product"))
            If id_product_check = id_product_style Then
                e.Appearance.BackColor = Color.White
                e.Appearance.BackColor2 = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_pl_sales_order_del
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.report_mark_type = "43"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    
    Private Sub GVItemList_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVItemList.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        view_barcode_list()
        viewDetailDrawer()
        Cursor = Cursors.Default
    End Sub
End Class