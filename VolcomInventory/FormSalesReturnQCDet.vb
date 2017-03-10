Imports Microsoft.Office.Interop
Public Class FormSalesReturnQCDet
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
    Public id_reject_type As String = "-1"
    Public reject_type As String = ""
    'Dim is_scan As Boolean = False
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_so As String = get_setup_field("bof_xls_reqc")
    Public is_show_reject As Integer = get_setup_field("is_show_reject")

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
    Public id_pre As String = "-1"
    Public id_wh_type As String = "-1"

    Private Sub FormSalesReturnQCDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewPLCat()
        actionLoad()

        'sementara
        SCCStorage.Panel2.Hide()
        WindowState = FormWindowState.Maximized
    End Sub

    Sub actionLoad()
        Try
            'initiation datatable jika blm ada
            dt.Columns.Add("id_product")
            dt.Columns.Add("id_sales_return_det_counting")
            dt.Columns.Add("product_code")
            dt.Columns.Add("product_counting_code")
            dt.Columns.Add("product_full_code")
            dt.Columns.Add("bom_unit_price")
            dt.Columns.Add("id_design_price")
            dt.Columns.Add("design_price")
            dt.Columns.Add("is_old_design")
        Catch ex As Exception
        End Try

        If action = "ins" Then
            XTPStorage.PageEnabled = False
            TxtSalesReturnQCNumber.Text = ""
            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            BMark.Enabled = False
            DDBPrint.Enabled = False
            DEForm.Text = view_date(0)
            check_but()

            If id_sales_return <> "-1" Then
                viewSalesReturn()
            End If
        ElseIf action = "upd" Then
            GroupControlListItem.Enabled = True
            GroupControlScannedItem.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BtnBrowseRO.Enabled = False
            BtnInfoSrs.Enabled = True
            BtnBrowseContactTo.Enabled = False
            DDBPrint.Enabled = True
            BMark.Enabled = True

            'query view based on edit id's
            Dim query As String = "SELECT drw.wh_drawer_code, (a.id_wh_drawer) AS id_wh_drawer_to,b.id_sales_return,b.id_wh_drawer, (c2.id_comp) AS id_comp_to_return,(b.id_comp_contact_to) AS id_comp_contact_to_return,a.id_store_contact_from, a.id_comp_contact_to, (d.comp_name) AS store_name_from, (d1.comp_name) AS comp_name_to, (d2.comp_name) AS comp_name_to_return, (d.comp_number) AS store_number_from, (d1.comp_number) AS comp_number_to, (d2.comp_number) AS comp_number_to_return,(d.address_primary) AS store_address_from, a.id_report_status, f.report_status, "
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

            'detail2
            viewDetail()
            view_barcode_list()
            viewDetailDrawer()
            viewDetailDrawer2()
            check_but()
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

    Sub viewSalesReturn()
        Dim query As String = ""
        query += "SELECT a.id_sales_return, getCompByContact(a.id_store_contact_from,'1') AS `id_comp_from`, a.id_store_contact_from, getCompByContact(a.id_comp_contact_to,'1') AS `id_comp_to`,a.id_comp_contact_to, (d.comp_number) AS store_code_from,(d.comp_name) AS store_name_from, (d1.comp_number) AS comp_code_to,(d1.comp_name) AS comp_name_to,a.id_report_status, f.report_status, "
        query += "a.sales_return_note, a.sales_return_number, "
        query += "DATE_FORMAT(a.sales_return_date,'%d %M %Y') AS sales_return_date "
        query += "FROM tb_sales_return a "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_from "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact c1 ON c1.id_comp_contact = a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d1 ON c1.id_comp = d1.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN "
        query += "( "
        query += "SELECT a.id_sales_return,  a.id_sales_return_det, "
        query += "(a.sales_return_det_qty - COALESCE(ret.jum_ret, 0)) AS jum "
        query += "FROM tb_sales_return_det a "
        query += "INNER JOIN tb_sales_return b ON b.id_sales_return = a.id_sales_return "
        query += "LEFT JOIN ( "
        query += "SELECT b1.id_sales_return_det, SUM(b1.sales_return_qc_det_qty) AS jum_ret FROM tb_sales_return_qc_det b1 "
        query += "INNER JOIN tb_sales_return_qc b2 ON b1.id_sales_return_qc = b2.id_sales_return_qc "
        query += "WHERE b2.id_report_status != '5' "
        query += "GROUP BY b1.id_sales_return_det "
        query += ")ret ON ret.id_sales_return_det = a.id_sales_return_det  "
        query += "WHERE b.id_report_status = '6' AND (a.sales_return_det_qty - COALESCE(ret.jum_ret, 0)) >'0' "
        query += "GROUP BY a.id_sales_return "
        query += ") g ON g.id_sales_return = a.id_sales_return "
        query += "WHERE a.id_report_status = '6' AND a.id_sales_return='" + id_sales_return + "' "
        query += "ORDER BY a.id_sales_return ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'Return 
        TxtSalesReturnNumber.Text = data.Rows(0)("sales_return_number").ToString

        'store data
        Dim query_comp_from As String = "SELECT id_comp FROM tb_m_comp_contact WHERE id_comp_contact = '" + data.Rows(0)("id_store_contact_from").ToString + "'"
        Dim id_comp_from As String = execute_query(query_comp_from, 0, True, "", "", "", "")
        id_store = id_comp_from
        id_store_contact_from = data.Rows(0)("id_store_contact_from").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("store_code_from").ToString
        TxtNameCompFrom.Text = data.Rows(0)("store_name_from").ToString
        'MEAdrressCompFrom.Text = get_company_x(id_comp_from, 3)

        Dim id_comp_to As String = data.Rows(0)("id_comp_to").ToString
        id_comp_contact_to_return = data.Rows(0)("id_comp_contact_to").ToString
        TxtCodeFrom.Text = data.Rows(0)("comp_code_to").ToString
        TxtNameFrom.Text = data.Rows(0)("comp_name_to").ToString


        'general
        viewDetail()
        viewDetailDrawer()
        viewDetailDrawer2()
        view_barcode_list()
        GroupControlListItem.Enabled = True
        GroupControlScannedItem.Enabled = True
        BtnInfoSrs.Enabled = True
        BtnBrowseRO.Enabled = False
    End Sub

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
        If action = "ins" Then
            Dim query As String = "CALL view_sales_return_limit('" + id_sales_return + "', '0', '0') "
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            GCItemList.DataSource = data
            GVItemList.ActiveFilterString = "[sales_return_det_qty]>0 "
            Dim id_product_str As String = ""
            For i As Integer = 0 To (Me.GVItemList.RowCount - 1)
                If i > 0 Then
                    id_product_str += ";"
                End If
                Dim id_product_param As String = "-1"
                Try
                    id_product_param = Me.GVItemList.GetRowCellValue(i, "id_product").ToString
                Catch ex As Exception
                End Try
                id_product_str += id_product_param
            Next
            codeAvailableIns(id_product_str, id_store, 0)
            GVItemList.ActiveFilterString = ""
        ElseIf action = "upd" Then
            Dim query As String = "CALL view_sales_return_qc('" + id_sales_return_qc + "')"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            'For i As Integer = 0 To (data.Rows.Count - 1)
            'id_sales_return_qc_det_list.Add(data.Rows(i)("id_sales_return_qc_det").ToString)
            'codeAvailableIns(data.Rows(i)("id_product").ToString, id_store, data.Rows(i)("id_design_price").ToString)
            'Next
            GCItemList.DataSource = data
        End If
    End Sub


    Sub view_barcode_list()
        If action = "ins" Then
            Dim query As String = "SELECT ('0') AS no, ('') AS code, ('') AS name, ('') AS size, ('0') AS id_sales_return_qc_det, ('0') AS id_sales_return_det_counting, ('0') AS id_product,('1') AS is_fix, ('') AS counting_code, ('0') AS id_sales_return_qc_det_counting, CAST('0' AS DECIMAL(13,2)) AS bom_unit_price, CAST('0' AS DECIMAL(13,2)) AS design_price, ('0') AS id_design_price,('0') AS `id_reject_type`, ('') AS `reject_type` "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBarcode.DataSource = data
            deleteRowsBc()
            allowDelete()
        ElseIf action = "upd" Then
            Dim query As String = ""
            query += "SELECT ('') AS no, CONCAT(c.product_full_code, a.sales_return_qc_det_counting) AS code, (c.product_full_code) AS product_code, "
            query += "c.product_display_name AS `name`, cod.display_name AS `size`, (a.sales_return_qc_det_counting) AS counting_code, "
            query += "a.id_sales_return_det_counting, a.id_sales_return_qc_det_counting,('2') AS is_fix, "
            query += "d0.id_pl_prod_order_rec_det_unique, b.id_product, "
            query += "d.bom_unit_price, b.id_design_price, b.design_price, a.id_reject_type, rj.reject_type  "
            query += "FROM tb_sales_return_qc_det_counting a "
            query += "INNER JOIN tb_sales_return_qc_det b ON a.id_sales_return_qc_det = b.id_sales_return_qc_det "
            query += "JOIN tb_opt o "
            query += "INNER JOIN tb_m_product c ON c.id_product = b.id_product "
            query += "INNER JOIN tb_m_product_code cc ON cc.id_product = c.id_product "
            query += "INNER JOIN tb_m_code_detail cod ON cod.id_code_detail = cc.id_code_detail AND cod.id_code = o.id_code_product_size "
            query += "LEFT JOIN tb_sales_return_det_counting d0 ON d0.id_sales_return_det_counting = a.id_sales_return_det_counting "
            query += "LEFT JOIN tb_pl_prod_order_rec_det_counting d ON d.id_pl_prod_order_rec_det_unique = d0.id_pl_prod_order_rec_det_unique "
            query += "LEFT JOIN tb_m_reject_type rj ON rj.id_reject_type = a.id_reject_type "
            query += "WHERE b.id_sales_return_qc = '" + id_sales_return_qc + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            'For i As Integer = 0 To (data.Rows.Count - 1)
            '    id_sales_return_qc_det_counting_list.Add(data.Rows(i)("id_sales_return_qc_det_counting").ToString)
            '    insertDt(data.Rows(i)("id_product").ToString, data.Rows(i)("id_sales_return_det_counting").ToString, data.Rows(i)("product_code").ToString, data.Rows(i)("counting_code").ToString, data.Rows(i)("code").ToString, Decimal.Parse(data.Rows(i)("bom_unit_price").ToString), data.Rows(i)("id_design_price").ToString, Decimal.Parse(data.Rows(i)("design_price").ToString))
            'Next
            GCBarcode.DataSource = data
        End If
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

    End Sub

    Sub codeAvailableIns(ByVal id_product_param As String, ByVal id_store_param As String, ByVal id_design_price_param As String)
        Dim query As String = ""
        If action = "ins" Then
            query = "CALL view_stock_fg_unique_ret_qc('" + id_product_param + "','" + id_store_param + "', '" + id_design_price_param + "', '" + id_sales_return + "','0')"
        ElseIf action = "upd" Then
            query = "CALL view_stock_fg_unique_ret_qc('" + id_product_param + "','" + id_store_param + "', '" + id_design_price_param + "', '" + id_sales_return + "','0')"
        End If
        Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
        dt = datax
        'For k As Integer = 0 To (datax.Rows.Count - 1)
        '    insertDt(datax.Rows(k)("id_product").ToString, datax.Rows(k)("id_sales_return_det_counting").ToString, datax.Rows(k)("product_code").ToString, datax.Rows(k)("product_counting_code").ToString, datax.Rows(k)("product_full_code").ToString, Decimal.Parse(datax.Rows(k)("bom_unit_price").ToString), datax.Rows(k)("id_design_price").ToString, Decimal.Parse(datax.Rows(k)("design_price").ToString))
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
        R("is_old_design") = "2"
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

    '--------------SAMPAI SINI
    Private Sub BtnBrowseRO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseRO.Click
        FormPopUpSalesReturn.id_pop_up = "1"
        FormPopUpSalesReturn.ShowDialog()
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
        If check_edit_report_status(id_report_status, "49", id_sales_return_qc) Then
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = False
            LEPLCategory.Enabled = True
            BtnInfoSrs.Enabled = True
            TEDrawer.Properties.ReadOnly = False
            BPickDrawer.Enabled = True
        Else
            MENote.Properties.ReadOnly = True
            BtnSave.Enabled = False
            LEPLCategory.Enabled = False
            BtnInfoSrs.Enabled = False
            TEDrawer.Properties.ReadOnly = True
            BPickDrawer.Enabled = False
        End If
        PanelNavBarcode.Enabled = False
        BtnVerify.Enabled = False

        'attachment
        If check_attach_report_status(id_report_status, "49", id_sales_return_qc) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        'Pre Print
        If check_pre_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        'Print
        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        'Btn Storage
        If check_storage_report_status(id_report_status) Then
            XTPStorage.PageEnabled = True
        Else
            XTPStorage.PageEnabled = False
        End If

        'If id_report_status = "6" Then
        '    PanelNavStorage.Enabled = False
        'Else
        '    PanelNavStorage.Enabled = True
        'End If

        If id_report_status <> "5" And bof_column = "1" Then
            BtnXlsBOF.Visible = True
        Else
            BtnXlsBOF.Visible = False
        End If


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
        'If GVBarcode.RowCount <= 0 Then
        '    BDelete.Enabled = False
        'Else
        '    BDelete.Enabled = True
        'End If
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

        'MsgBox(tot.ToString)
        Dim indeks As Integer = -1
        For j As Integer = 0 To GVItemList.RowCount - 1
            Try
                Dim id_productx As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                If id_productx = id_product_param Then
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

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        If action = "ins" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to cancel ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Close()
            End If
        Else
            Close()
        End If
    End Sub

    Private Sub FormSalesReturnQCDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_sales_return_qc
        FormReportMark.report_mark_type = "49"
        FormReportMark.is_view = "1"
        FormReportMark.form_origin = Name
        FormReportMark.is_view_finalize = "1"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_FocusedRowChanged_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
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
        AddHandler GVDrawer.RowCellStyle, AddressOf my_color_cell
        ''AddHandler GVBarcode.RowCellStyle, AddressOf my_color_cell
        GCDrawer.RefreshDataSource()
        GVDrawer.RefreshData()
        ''GCBarcode.RefreshDataSource()
        ''GVBarcode.RefreshData()
    End Sub


    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactTo.Click
        FormPopUpContact.id_pop_up = "43"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.ShowDialog()
    End Sub

    Sub setDefDrawer()
        'get default drawer
        Dim id_comp_param As String = "0"
        Try
            id_comp_param = get_id_company(id_comp_contact_to)
        Catch ex As Exception
        End Try
        Dim query_def_drw As String = ""
        query_def_drw += "SELECT IFNULL(drw.id_wh_drawer,'-1') AS `id_wh_drawer`, IFNULL(drw.wh_drawer_code,'') AS `wh_drawer_code`, "
        query_def_drw += "IFNULL(drw.wh_drawer,'') AS `wh_drawer` "
        query_def_drw += "FROM tb_m_comp comp "
        query_def_drw += "LEFT JOIN tb_m_wh_drawer drw ON comp.id_drawer_def = drw.id_wh_drawer "
        query_def_drw += "WHERE comp.id_comp='" + id_comp_param + "' "
        Dim data_def_drw As DataTable = execute_query(query_def_drw, -1, True, "", "", "", "")
        id_wh_drawer_to = data_def_drw(0)("id_wh_drawer").ToString
        TEDrawer.Text = data_def_drw(0)("wh_drawer_code").ToString
    End Sub

    Private Sub TxtSalesReturnOrderNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSalesReturnNumber.Validating
        EP_TE_cant_blank(EPForm, TxtSalesReturnNumber)
        EPForm.SetIconPadding(TxtSalesReturnNumber, 58)
    End Sub

    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompFrom)
    End Sub

    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompTo)
        EPForm.SetIconPadding(TxtNameCompTo, 30)
    End Sub

    Function verifyTrans() As Boolean
        GridColumnStt.Visible = True
        Dim cond As Boolean = True
        Dim query_cek = "CALL view_sales_return_limit('" + id_sales_return + "', 0, 0) "
        Dim dt_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
        For c As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
            Dim id_product_cek As String = GVItemList.GetRowCellValue(c, "id_product").ToString
            Dim qty_cek As Decimal = GVItemList.GetRowCellValue(c, "sales_return_qc_det_qty")
            Dim dt_filter_cek As DataRow() = dt_cek.Select("[id_product]='" + id_product_cek + "' ")
            Dim qty_limit As Decimal = 0
            If dt_filter_cek.Length > 0 Then
                qty_limit = dt_filter_cek(0)("sales_return_qc_det_qty_limit")
            Else
                qty_limit = 0
            End If

            If qty_cek > qty_limit Then
                Dim diff As Integer = qty_cek - qty_limit
                GVItemList.SetRowCellValue(c, "status", "+" + diff.ToString)
                cond = False
            ElseIf qty_cek < qty_limit
                Dim diff As Integer = qty_cek - qty_limit
                GVItemList.SetRowCellValue(c, "status", diff.ToString)
            Else
                GVItemList.SetRowCellValue(c, "status", "0")
            End If
        Next
        Return cond
    End Function


    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        makeSafeGV(GVItemList)
        makeSafeGV(GVBarcode)

        Dim cond As Boolean = True
        Dim query_cek As String = ""
        If action = "ins" Then
            cond = verifyTrans()
        End If


        If Not formIsValidInGroup(EPForm, GroupGeneralHeader) Then
            errorInput()
        ElseIf GVItemList.RowCount = 0 Or GVBarcode.RowCount = 0 Then
            stopCustom("Return item and scanned item data can't blank")
        ElseIf Not cond Then
            stopCustom("Please see different in column status.")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim sales_return_qc_note As String = MENote.Text
                Dim id_pl_category As String = LEPLCategory.EditValue.ToString

                If action = "ins" Then
                    Dim sales_return_qc_number As String = header_number_sales("7")

                    'query main table
                    Dim query_main As String = "INSERT tb_sales_return_qc(id_store_contact_from, id_comp_contact_to, id_sales_return, sales_return_qc_number, sales_return_qc_date, sales_return_qc_note,id_report_status, id_pl_category, id_wh_drawer, last_update, last_update_by) "
                    query_main += "VALUES('" + id_store_contact_from + "', '" + id_comp_contact_to + "', '" + id_sales_return + "', '" + sales_return_qc_number + "', NOW(), '" + sales_return_qc_note + "', '1', '" + id_pl_category + "', '" + id_wh_drawer_to + "', NOW(), " + id_user + "); SELECT LAST_INSERT_ID() "
                    id_sales_return_qc = execute_query(query_main, 0, True, "", "", "", "")
                    '
                    increase_inc_sales("7")
                    '
                    'insert who prepared
                    insert_who_prepared("49", id_sales_return_qc, id_user)

                    'Detail return
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    GVItemList.ActiveFilterString = "[sales_return_qc_det_qty]>0 "
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_sales_return_qc_det(id_sales_return_qc, id_sales_return_det, id_product, id_design_price, design_price, sales_return_qc_det_qty, sales_return_qc_det_note) VALUES "
                    End If
                    For j As Integer = 0 To (GVItemList.RowCount - 1)
                        Try
                            Dim id_sales_return_det As String = GVItemList.GetRowCellValue(j, "id_sales_return_det").ToString
                            Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                            Dim id_design_price As String = GVItemList.GetRowCellValue(j, "id_design_price").ToString
                            Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "design_price").ToString)
                            Dim sales_return_qc_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "sales_return_qc_det_qty").ToString)
                            Dim sales_return_qc_det_note As String = GVItemList.GetRowCellValue(j, "sales_return_qc_det_note").ToString

                            If jum_ins_j > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_sales_return_qc + "', '" + id_sales_return_det + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_return_qc_det_qty + "', '" + sales_return_qc_det_note + "') "
                            jum_ins_j = jum_ins_j + 1
                        Catch ex As Exception
                        End Try
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If
                    GVItemList.ActiveFilterString = ""

                    'get all detail id
                    Dim query_get_detail_id As String = "SELECT a.id_sales_return_qc_det, a.id_product, a.id_design_price, a.design_price "
                    query_get_detail_id += "FROM tb_sales_return_qc_det a "
                    query_get_detail_id += "WHERE a.id_sales_return_qc = '" + id_sales_return_qc + "' "
                    Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")


                    'counting
                    Dim jum_ins_p As Integer = 0
                    Dim query_counting As String = ""
                    If GVBarcode.RowCount > 0 Then
                        query_counting = "INSERT INTO tb_sales_return_qc_det_counting(id_sales_return_qc_det, id_sales_return_det_counting, sales_return_qc_det_counting, id_reject_type) VALUES "
                    End If
                    For p As Integer = 0 To (GVBarcode.RowCount - 1)
                        Dim id_product_counting As String = GVBarcode.GetRowCellValue(p, "id_product").ToString
                        Dim id_reject_type As String = GVBarcode.GetRowCellValue(p, "id_reject_type").ToString
                        Dim id_design_price_counting As String = GVBarcode.GetRowCellValue(p, "id_design_price").ToString
                        Dim design_price_counting As Decimal = Decimal.Parse(GVBarcode.GetRowCellValue(p, "design_price").ToString)
                        Dim id_sales_return_det_counting As String = GVBarcode.GetRowCellValue(p, "id_sales_return_det_counting").ToString
                        If id_sales_return_det_counting = "0" Then
                            id_sales_return_det_counting = "NULL "
                        End If
                        Dim sales_return_qc_det_counting As String = GVBarcode.GetRowCellValue(p, "counting_code").ToString
                        For p1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                            If id_product_counting = data_get_detail_id.Rows(p1)("id_product").ToString And id_design_price_counting = data_get_detail_id.Rows(p1)("id_design_price").ToString And design_price_counting = Decimal.Parse(data_get_detail_id.Rows(p1)("design_price").ToString) Then
                                If jum_ins_p > 0 Then
                                    query_counting += ", "
                                End If
                                query_counting += "('" + data_get_detail_id.Rows(p1)("id_sales_return_qc_det").ToString + "', " + id_sales_return_det_counting + ", '" + sales_return_qc_det_counting + "', '" + id_reject_type + "') "
                                jum_ins_p = jum_ins_p + 1
                                Exit For
                            End If
                        Next
                    Next
                    If jum_ins_p > 0 Then
                        execute_non_query(query_counting, True, "", "", "", "")
                    End If

                    'submit who prepared
                    submit_who_prepared("49", id_sales_return_qc, id_user)

                    FormSalesReturnQC.viewSalesReturnQC()
                    FormSalesReturnQC.viewSalesReturn()
                    FormSalesReturnQC.GVSalesReturnQC.FocusedRowHandle = find_row(FormSalesReturnQC.GVSalesReturnQC, "id_sales_return_qc", id_sales_return_qc)
                    action = "upd"
                    actionLoad()
                    exportToBOF(False)
                    infoCustom("Return Transfer #" + sales_return_qc_number.ToString + " was created successfully. ")
                ElseIf action = "upd" Then
                    Dim sales_return_qc_number As String = TxtSalesReturnQCNumber.Text

                    'update main table
                    Dim query_main As String = "UPDATE tb_sales_return_qc SET id_store_contact_from = '" + id_store_contact_from + "', id_comp_contact_to = '" + id_comp_contact_to + "', sales_return_qc_note = '" + sales_return_qc_note + "', id_pl_category = '" + id_pl_category + "', id_wh_drawer='" + id_wh_drawer_to + "', last_update=NOW(), last_update_by=" + id_user + " WHERE id_sales_return_qc = '" + id_sales_return_qc + "'"
                    execute_non_query(query_main, True, "", "", "", "")

                    'update detail table
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_sales_return_qc_det(id_sales_return_qc, id_sales_return_det, id_product, id_design_price, design_price, sales_return_qc_det_qty, sales_return_qc_det_note) VALUES "
                    End If
                    For j As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        'Try
                        Dim id_sales_return_qc_det As String = GVItemList.GetRowCellValue(j, "id_sales_return_qc_det").ToString
                        Dim id_sales_return_det As String = GVItemList.GetRowCellValue(j, "id_sales_return").ToString
                        Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                        Dim id_design_price As String = GVItemList.GetRowCellValue(j, "id_design_price").ToString
                        Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "design_price").ToString)
                        Dim sales_return_qc_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "sales_return_qc_det_qty").ToString)
                        Dim sales_return_qc_det_note As String = GVItemList.GetRowCellValue(j, "sales_return_qc_det_note").ToString

                        If id_sales_return_qc_det = "0" Then
                            'If jum_ins_j > 0 Then
                            '    query_detail += ", "
                            'End If
                            'query_detail += "('" + id_sales_return_qc + "', '" + id_sales_return_det + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_return_qc_det_qty + "', '" + sales_return_qc_det_note + "') "
                            'jum_ins_j = jum_ins_j + 1
                        Else
                            Dim query_detail_upd As String = "UPDATE tb_sales_return_qc_det SET sales_return_qc_det_note = '" + sales_return_qc_det_note + "' WHERE id_sales_return_qc_det = '" + id_sales_return_qc_det + "'"
                            execute_non_query(query_detail_upd, True, "", "", "", "")
                            id_sales_return_qc_det_list.Remove(id_sales_return_qc_det)
                        End If
                    Next
                    If jum_ins_j > 0 Then
                        ' execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'For j_del As Integer = 0 To (id_sales_return_qc_det_list.Count - 1)
                    '    Try
                    '        Dim query_detail_del As String = "DELETE FROM tb_sales_return_qc_det WHERE id_sales_return_qc_det = '" + id_sales_return_qc_det_list(j_del) + "'"
                    '        execute_non_query(query_detail_del, True, "", "", "", "")
                    '    Catch ex As Exception

                    '    End Try
                    'Next

                    'get all detail id
                    'Dim query_get_detail_id As String = "SELECT a.id_sales_return_qc_det, a.id_product, a.id_design_price, a.design_price "
                    'query_get_detail_id += "FROM tb_sales_return_qc_det a "
                    'query_get_detail_id += "WHERE a.id_sales_return_qc = '" + id_sales_return_qc + "' "
                    'Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")

                    ''update counting
                    'Dim jum_ins_p As Integer = 0
                    'Dim query_counting As String = ""
                    'If GVBarcode.RowCount > 0 Then
                    '    query_counting = "INSERT INTO tb_sales_return_qc_det_counting(id_sales_return_qc_det, id_sales_return_det_counting, sales_return_qc_det_counting, id_reject_type) VALUES "
                    'End If
                    'For p As Integer = 0 To (GVBarcode.RowCount - 1)
                    '    Dim id_sales_return_qc_det_counting As String = GVBarcode.GetRowCellValue(p, "id_sales_return_qc_det_counting").ToString
                    '    Dim id_reject_type As String = GVBarcode.GetRowCellValue(p, "id_reject_type").ToString
                    '    Dim id_product_counting As String = GVBarcode.GetRowCellValue(p, "id_product")
                    '    Dim id_sales_return_det_counting As String = GVBarcode.GetRowCellValue(p, "id_sales_return_det_counting").ToString
                    '    If id_sales_return_det_counting = "0" Then
                    '        id_sales_return_det_counting = "NULL "
                    '    End If
                    '    Dim sales_return_qc_det_counting As String = GVBarcode.GetRowCellValue(p, "counting_code").ToString
                    '    Dim id_design_price_counting As String = GVBarcode.GetRowCellValue(p, "id_design_price").ToString
                    '    Dim design_price_counting As Decimal = Decimal.Parse(GVBarcode.GetRowCellValue(p, "design_price").ToString)
                    '    For p1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                    '        If id_sales_return_qc_det_counting = "0" Then
                    '            If id_product_counting = data_get_detail_id.Rows(p1)("id_product").ToString And id_design_price_counting = data_get_detail_id.Rows(p1)("id_design_price").ToString And design_price_counting = Decimal.Parse(data_get_detail_id.Rows(p1)("design_price").ToString) Then
                    '                If jum_ins_p > 0 Then
                    '                    query_counting += ", "
                    '                End If
                    '                query_counting += "('" + data_get_detail_id.Rows(p1)("id_sales_return_qc_det").ToString + "', " + id_sales_return_det_counting + ", '" + sales_return_qc_det_counting + "', '" + id_reject_type + "') "
                    '                jum_ins_p = jum_ins_p + 1
                    '                Exit For
                    '            End If
                    '        End If
                    '    Next
                    'Next
                    'If jum_ins_p > 0 Then
                    '    execute_non_query(query_counting, True, "", "", "", "")
                    'End If

                    'For p_del As Integer = 0 To (id_sales_return_qc_det_counting_list.Count - 1)
                    '    Try
                    '        Dim query_counting_del As String = "DELETE FROM tb_sales_return_qc_det_counting WHERE id_sales_return_qc_det_counting = '" + id_sales_return_qc_det_counting_list(p_del) + "'"
                    '        execute_non_query(query_counting_del, True, "", "", "", "")
                    '    Catch ex As Exception

                    '    End Try
                    'Next


                    FormSalesReturnQC.viewSalesReturnQC()
                    FormSalesReturnQC.viewSalesReturn()
                    FormSalesReturnQC.GVSalesReturnQC.FocusedRowHandle = find_row(FormSalesReturnQC.GVSalesReturnQC, "id_sales_return_qc", id_sales_return_qc)
                    action = "upd"
                    actionLoad()
                    exportToBOF(False)
                    infoCustom("Return Transfer #" + sales_return_qc_number.ToString + " was edited successfully. ")
                End If
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Sub countQtyFromWh(ByVal id_product_param As String)

    End Sub

    Sub disableControl()
        MENote.Enabled = False
        BtnSave.Enabled = False
        BtnVerify.Enabled = False
        BScan.Enabled = False
        BStop.Enabled = True
        BDelete.Enabled = False
        BtnCancel.Enabled = False
        GVItemList.OptionsBehavior.Editable = False
        ControlBox = False
        BtnInfoSrs.Enabled = False
        LEPLCategory.Enabled = False
        TEDrawer.Enabled = False
        BPickDrawer.Enabled = False
    End Sub
    Private Sub BScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BScan.Click
        'FormRejectType.ShowDialog()
        If GVItemList.RowCount > 0 And id_wh_type <> "-1" Then
            disableControl()
            newRowsBc()
        Else
            errorCustom("Item list and destination can't blank")
        End If
    End Sub

    Sub loadRejectType()
        If is_show_reject = "1" And (id_wh_type = "3" Or id_wh_type = "5") Then
            FormRejectType.ShowDialog()
            GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_reject_type", id_reject_type)
            GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "reject_type", reject_type)
        End If
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

        MENote.Enabled = True
        BtnSave.Enabled = True
        BtnVerify.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BDelete.Enabled = True
        BtnCancel.Enabled = True
        allowDelete()
        GVItemList.OptionsBehavior.Editable = True
        ControlBox = True
        BtnInfoSrs.Enabled = True
        LEPLCategory.Enabled = True
        TEDrawer.Enabled = True
        BPickDrawer.Enabled = True
        LabelDelScan.Visible = False
        TxtDeleteScan.Visible = False
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        disableControl()
        LabelDelScan.Visible = True
        TxtDeleteScan.Visible = True
        TxtDeleteScan.Focus()

        'Dim id_sales_return_qc_det_counting As String = "-1"
        'Try
        '    id_sales_return_qc_det_counting = GVBarcode.GetFocusedRowCellValue("id_sales_return_qc_det_counting").ToString
        'Catch ex As Exception
        'End Try

        'If action = "ins" Then
        '    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '    If confirm = Windows.Forms.DialogResult.Yes Then
        '        Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
        '        Dim bom_unit_price As Decimal = Decimal.Parse(GVBarcode.GetFocusedRowCellValue("bom_unit_price").ToString)
        '        Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
        '        Dim id_sales_return_det_counting As String = GVBarcode.GetFocusedRowCellValue("id_sales_return_det_counting").ToString
        '        Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

        '        deleteRowsBc()
        '        If id_product <> "" Or id_product <> Nothing Then
        '            GVBarcode.ApplyFindFilter("")
        '            countQty(id_product)
        '            countUnitCost(id_product, bom_unit_price)
        '        End If
        '        allowDelete()
        '    End If
        'ElseIf action = "upd" Then
        '    If id_sales_return_qc_det_counting = "0" Then
        '        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '        If confirm = Windows.Forms.DialogResult.Yes Then
        '            Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
        '            Dim bom_unit_price As Decimal = Decimal.Parse(GVBarcode.GetFocusedRowCellValue("bom_unit_price").ToString)
        '            Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
        '            Dim id_sales_return_det_counting As String = GVBarcode.GetFocusedRowCellValue("id_sales_return_det_counting").ToString
        '            Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

        '            deleteRowsBc()
        '            If id_product <> "" Or id_product <> Nothing Then
        '                GVBarcode.ApplyFindFilter("")
        '                countQty(id_product)
        '                countUnitCost(id_product, bom_unit_price)
        '            End If

        '            'set into dt (update action only)
        '            allowDelete()

        '        End If
        '    Else
        '         errorCustom("This data already locked and can't delete.")
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
        Dim counting_code As String = ""
        Dim id_sales_return_det_counting As String = ""
        Dim id_product As String = ""
        Dim product_name As String = ""
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
            id_sales_return_det_counting = dt_filter(0)("id_sales_return_det_counting").ToString
            id_product = dt_filter(0)("id_product").ToString
            product_name = dt_filter(0)("name").ToString
            size = dt_filter(0)("size").ToString
            bom_unit_price = Decimal.Parse(dt_filter(0)("bom_unit_price").ToString)
            id_design_price = dt_filter(0)("id_design_price").ToString
            design_price = Decimal.Parse(dt_filter(0)("design_price").ToString)
            is_old = dt_filter(0)("is_old_design").ToString
            code_found = True
        End If

        'get jum del & limit
        GVItemList.ActiveFilterString = "[id_product]='" + id_product + "' "
        GVItemList.FocusedRowHandle = 0
        Try
            jum_limit = GVItemList.GetFocusedRowCellValue("sales_return_qc_det_qty_limit")
        Catch ex As Exception
        End Try
        Try
            jum_scan = GVItemList.GetFocusedRowCellValue("sales_return_qc_det_qty")
        Catch ex As Exception
        End Try
        makeSafeGV(GVItemList)

        If is_old = "1" Then 'old design system
            If jum_scan >= jum_limit Then
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                stopCustom("Scanned qty more than remaining limit")
            Else
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_sales_return_det_counting", id_sales_return_det_counting)
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_sales_return_qc_det_counting", "0")
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "is_fix", "2")
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "counting_code", counting_code)
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_product", id_product)
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "name", product_name)
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "size", size)
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "bom_unit_price", bom_unit_price)
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_design_price", id_design_price)
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "design_price", design_price)
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_reject_type", id_reject_type)
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "reject_type", reject_type)
                loadRejectType()
                countQty(id_product)
                checkUnitCost(id_product, bom_unit_price, id_design_price)
                newRowsBc()
                GCItemList.RefreshDataSource()
                GVItemList.RefreshData()
            End If
        ElseIf is_old = "2" Then 'new design system
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
                If jum_scan >= jum_limit Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    stopCustom("Scanned qty more than remaining limit")
                Else
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_sales_return_det_counting", id_sales_return_det_counting)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_sales_return_qc_det_counting", "0")
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "is_fix", "2")
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "counting_code", counting_code)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_product", id_product)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "name", product_name)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "size", size)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "bom_unit_price", bom_unit_price)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_design_price", id_design_price)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "design_price", design_price)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_reject_type", id_reject_type)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "reject_type", reject_type)
                    loadRejectType()
                    countQty(id_product)
                    checkUnitCost(id_product, bom_unit_price, id_design_price)
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

    Private Sub BtnInfoSrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInfoSrs.Click
        infoQty()
    End Sub

    'SKIP
    Sub infoQty()
        If action = "ins" Then
            FormInfoSalesReturn.id_pop_up = "1"
            FormInfoSalesReturn.id_sales_return = id_sales_return
            FormInfoSalesReturn.id_sales_return_det = "0"
            FormInfoSalesReturn.ShowDialog()
        ElseIf action = "upd" Then
            FormInfoSalesReturn.id_pop_up = "1"
            FormInfoSalesReturn.id_sales_return = id_sales_return
            FormInfoSalesReturn.id_sales_return_det = "0"
            FormInfoSalesReturn.id_sales_return_qc = id_sales_return_qc
            FormInfoSalesReturn.ShowDialog()
        End If
    End Sub


    Private Sub BtnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTest.Click
        ''View
        'FormViewSalesReturnQC.id_sales_return_qc = id_sales_return_qc
        'FormViewSalesReturnQC.ShowDialog()

        'Print
        ReportSalesReturnQC.id_sales_return_qc = id_sales_return_qc
        Dim Report As New ReportSalesReturnQC()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Sub getReport()
        ReportSalesReturnQC.dt = GCItemList.DataSource
        ReportSalesReturnQC.id_sales_return_qc = id_sales_return_qc
        Dim Report As New ReportSalesReturnQC()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVSalesReturnQC.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVSalesReturnQC)

        'Parse val

        Report.LabelFrom.Text = TxtCodeCompFrom.Text + "-" + TxtNameCompFrom.Text
        Report.LabelTo.Text = TxtCodeCompTo.Text + "-" + TxtNameCompTo.Text
        Report.LRecDate.Text = DEForm.Text
        Report.LRecNumber.Text = TxtSalesReturnQCNumber.Text
        Report.LabelReturn.Text = TxtSalesReturnNumber.Text
        Report.LabelNote.Text = MENote.Text
        Report.LabelPLCategory.Text = LEPLCategory.Text


        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Sub checkUnitCost(ByVal id_product_param As String, ByVal bom_unit_price_param As Decimal, ByVal id_design_price_param As String)
        'SEMENTARA ATAU BAHKAN SELAMANYA TIDAK DIPAKAI
        'Dim is_found As Boolean = False
        'Dim indeks_found As Integer = 0

        'For i As Integer = 0 To (GVDrawer.RowCount - 1)
        '    Dim id_product_cek As String = "-1"
        '    Dim cost As Decimal = 0.0
        '    Dim id_design_price_cek As String = "-1"
        '    Try
        '        id_product_cek = GVDrawer.GetRowCellValue(i, "id_product").ToString
        '        cost = Decimal.Parse(GVDrawer.GetRowCellValue(i, "bom_unit_price").ToString)
        '        id_design_price_cek = GVDrawer.GetRowCellValue(i, "id_design_price").ToString
        '        If id_product_cek = id_product_param And bom_unit_price_param = cost And id_design_price_param = id_design_price_cek Then
        '            is_found = True
        '            indeks_found = i
        '            Exit For
        '        End If
        '    Catch ex As Exception
        '    End Try
        'Next

        'If is_found Then
        '    'update qty
        '    countUnitCost(id_product_param, bom_unit_price_param)
        'Else
        '    'tambah baris baru
        '    Dim newRow As DataRow = (TryCast(GCDrawer.DataSource, DataTable)).NewRow()
        '    newRow("id_sales_return_qc_det_drawer") = "0"
        '    newRow("id_sales_return_qc_det") = "0"
        '    'newRow("id_wh_drawer") = "0"
        '    newRow("id_product") = id_product_param
        '    newRow("drawer") = "-"
        '    newRow("rack") = "-"
        '    newRow("locator") = "-"
        '    newRow("sales_return_qc_det_drawer_qty_stored") = 0.0
        '    newRow("sales_return_qc_det_drawer_qty") = 1.0
        '    newRow("bom_unit_price") = bom_unit_price_param
        '    newRow("id_design_price") = id_design_price_param
        '    TryCast(GCDrawer.DataSource, DataTable).Rows.Add(newRow)
        '    GCDrawer.RefreshDataSource()
        '    GVDrawer.RefreshData()
        'End If
    End Sub

    Sub countUnitCost(ByVal id_product_param As String, ByVal bom_unit_price_param As Decimal)
        Dim tot As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_product As String = "-1"
            Dim cost As Decimal = 0.0
            Try
                id_product = GVBarcode.GetRowCellValue(i, "id_product").ToString
                cost = Decimal.Parse(GVBarcode.GetRowCellValue(i, "bom_unit_price").ToString)
            Catch ex As Exception
            End Try

            If id_product = id_product_param And cost = bom_unit_price_param Then
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
                If id_product_cek = id_product_param And bom_unit_price_param = cost Then
                    'MsgBox(tot.ToString)
                    GVDrawer.SetRowCellValue(j, "sales_return_qc_det_drawer_qty", tot)
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub BtnSaveToStorage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveToStorage.Click
        Cursor = Cursors.WaitCursor
        Dim sales_return_qc_det_drawer_qty As Decimal = Decimal.Parse(GVDrawer.GetFocusedRowCellValue("sales_return_qc_det_drawer_qty"))
        Dim sales_return_qc_det_drawer_qty_stored As Decimal = Decimal.Parse(GVDrawer.GetFocusedRowCellValue("sales_return_qc_det_drawer_qty_stored"))
        'MsgBox(pl_prod_order_rec_det_qty_stored)
        'MsgBox(pl_prod_order_rec_det_qty)
        If sales_return_qc_det_drawer_qty <> sales_return_qc_det_drawer_qty_stored Then
            FormProductionStorageIn.id_transaction_det = GVDrawer.GetFocusedRowCellValue("id_sales_return_qc_det_drawer").ToString
            FormProductionStorageIn.id_design = GVItemList.GetFocusedRowCellValue("id_design").ToString
            FormProductionStorageIn.id_sample = GVItemList.GetFocusedRowCellValue("id_sample").ToString
            FormProductionStorageIn.action = "ins"
            FormProductionStorageIn.colorku = GVItemList.GetFocusedRowCellValue("color").ToString
            FormProductionStorageIn.sizeku = GVItemList.GetFocusedRowCellValue("size").ToString
            FormProductionStorageIn.id_report = id_sales_return_qc
            FormProductionStorageIn.report_mark_type = "49"
            FormProductionStorageIn.id_product = GVDrawer.GetFocusedRowCellValue("id_product").ToString
            FormProductionStorageIn.cost = Decimal.Parse(GVDrawer.GetFocusedRowCellValue("bom_unit_price").ToString)
            FormProductionStorageIn.id_pop_up = "4"
            FormProductionStorageIn.id_wh = id_comp_to
            FormProductionStorageIn.id_wh_drawer_origin = id_drawer
            FormProductionStorageIn.ShowDialog()
        Else
            errorCustom("- All item for this product has been stored in warehouse" + System.Environment.NewLine + "- If yo want to edit location storage, please edit on 'Transfer Product' menu")
        End If
        Cursor = Cursors.Default
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

    Private Sub BPickDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickDrawer.Click
        FormPopUpDrawer.id_pop_up = "2"
        Dim id_comp_param As String = "0"
        Try
            id_comp_param = get_id_company(id_comp_contact_to)
        Catch ex As Exception
        End Try
        FormPopUpDrawer.id_comp = id_comp_param
        FormPopUpDrawer.ShowDialog()
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sales_return_qc
        FormDocumentUpload.report_mark_type = "49"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrePrinting_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrePrinting.ItemClick
        prePrinting()
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        ReportSalesReturnQC.id_pre = "1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrint.ItemClick
        printing()
    End Sub

    Sub printing()
        Cursor = Cursors.WaitCursor
        ReportSalesReturnQC.id_pre = "-1"
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
                Dim id_sales_return_qc_det_counting As String = "-1"
                Try
                    id_sales_return_qc_det_counting = GVBarcode.GetFocusedRowCellValue("id_sales_return_qc_det_counting").ToString
                Catch ex As Exception
                End Try

                If action = "ins" Then
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
                        Dim bom_unit_price As Decimal = Decimal.Parse(GVBarcode.GetFocusedRowCellValue("bom_unit_price").ToString)
                        Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
                        ' Dim id_sales_return_det_counting As String = GVBarcode.GetFocusedRowCellValue("id_sales_return_det_counting").ToString
                        Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

                        deleteRowsBc()
                        If id_product <> "" Or id_product <> Nothing Then
                            GVBarcode.ApplyFindFilter("")
                            GVBarcode.ActiveFilterString = ""
                            countQty(id_product)
                            countUnitCost(id_product, bom_unit_price)
                        End If
                        GCItemList.RefreshDataSource()
                        GVItemList.RefreshData()
                        allowDelete()
                    Else
                        GVBarcode.ActiveFilterString = ""
                    End If
                    TxtDeleteScan.Text = ""
                    TxtDeleteScan.Focus()
                ElseIf action = "upd" Then
                    If id_sales_return_qc_det_counting = "0" Then
                        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
                            Dim bom_unit_price As Decimal = Decimal.Parse(GVBarcode.GetFocusedRowCellValue("bom_unit_price").ToString)
                            Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
                            'Dim id_sales_return_det_counting As String = GVBarcode.GetFocusedRowCellValue("id_sales_return_det_counting").ToString
                            Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

                            deleteRowsBc()
                            If id_product <> "" Or id_product <> Nothing Then
                                GVBarcode.ApplyFindFilter("")
                                GVBarcode.ActiveFilterString = ""
                                countQty(id_product)
                                countUnitCost(id_product, bom_unit_price)
                            End If

                            'set into dt (update action only)
                            GCItemList.RefreshDataSource()
                            GVItemList.RefreshData()
                            allowDelete()
                        Else
                            GVBarcode.ActiveFilterString = ""
                        End If
                    Else
                        errorCustom("This data already locked and can't delete.")
                        GVBarcode.ApplyFindFilter("")
                        GVBarcode.ActiveFilterString = ""
                    End If
                    TxtDeleteScan.Text = ""
                    TxtDeleteScan.Focus()
                End If
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormSalesReturnQCDet_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Sub exportToBOF(ByVal show_msg As Boolean)
        If bof_column = "1" Then
            Cursor = Cursors.WaitCursor

            'fill remark
            For r As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                GVItemList.SetRowCellValue(r, "sales_return_qc_det_note", TxtSalesReturnQCNumber.Text)
            Next

            'hide column
            For c As Integer = 0 To GVItemList.Columns.Count - 1
                GVItemList.Columns(c).Visible = False
            Next
            GridColumnCode.VisibleIndex = 0
            GridColumnQty.VisibleIndex = 1
            GridColumnRemark.VisibleIndex = 2
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

            'clear remark
            For r As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                GVItemList.SetRowCellValue(r, "sales_return_qc_det_note", "")
            Next

            'show column
            GridColumnNo.VisibleIndex = 0
            GridColumnCode.VisibleIndex = 1
            GridColumnName.VisibleIndex = 2
            GridColumnSize.VisibleIndex = 3
            GridColumnQty.VisibleIndex = 4
            GridColumnPrice.VisibleIndex = 5
            GridColumnAmount.VisibleIndex = 6
            GridColumnRemark.VisibleIndex = 7
            GridColumnStt.VisibleIndex = 8
            GridColumnStt.Visible = False
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
                If j = 0 Then
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "code").ToString
                ElseIf j = 1 Then
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "sales_return_qc_det_qty")
                Else
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "sales_return_qc_det_note")
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

    Private Sub BtnVerify_Click(sender As Object, e As EventArgs) Handles BtnVerify.Click
        Cursor = Cursors.WaitCursor
        verifyTrans()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnXlsBOF_Click(sender As Object, e As EventArgs) Handles BtnXlsBOF.Click
        exportToBOF(True)
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
End Class