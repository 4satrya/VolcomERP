Public Class FormViewSalesReturnOrder 
    Public action As String
    Public id_sales_return_order As String = "-1"
    Public id_store_contact_to As String = "-1"
    Public id_report_status As String
    Public id_sales_return_order_det_list As New List(Of String)
    Dim date_start As Date
    Public id_comp As String = "-1"
    Public is_detail_soh As String = "-1"
    Public id_prepare_status As String = "-1"

    Public id_wh_drawer As String = "-1"
    Public id_wh_rack As String = "-1"
    Public id_wh_locator As String = "-1"

    Public is_print As String = "-1"

    Private Sub FormViewSalesReturnOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub actionLoad()
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
        BtnBrowseContactTo.Enabled = False

        'query view based on edit id's
        Dim query As String = "SELECT d.id_comp, a.id_sales_return_order, a.id_store_contact_to, getCompByContact(a.id_store_contact_to, 4) AS `id_wh_drawer`, getCompByContact(a.id_store_contact_to, 6) AS `id_wh_rack`, getCompByContact(a.id_store_contact_to, 7) AS `id_wh_locator`, (d.comp_name) AS store_name_to, (d.comp_number) AS store_number_to, (d.address_primary) AS store_address_to, a.id_report_status, f.report_status, "
        query += "a.sales_return_order_note, a.sales_return_order_date, a.sales_return_order_note, a.sales_return_order_number, "
        query += "DATE_FORMAT(a.sales_return_order_date,'%Y-%m-%d') AS sales_return_order_datex, a.sales_return_order_est_date, prep_stt.prepare_status, a.id_prepare_status "
        query += "FROM tb_sales_return_order a "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_lookup_prepare_status prep_stt ON prep_stt.id_prepare_status = a.id_prepare_status "
        query += "WHERE a.id_sales_return_order = '" + id_sales_return_order + "' "
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        id_report_status = data.Rows(0)("id_report_status").ToString
        id_store_contact_to = data.Rows(0)("id_store_contact_to").ToString
        id_wh_drawer = data.Rows(0)("id_wh_drawer").ToString
        id_wh_rack = data.Rows(0)("id_wh_rack").ToString
        id_wh_locator = data.Rows(0)("id_wh_locator").ToString
        id_comp = data.Rows(0)("id_comp").ToString
        TxtNameCompTo.Text = data.Rows(0)("store_name_to").ToString
        TxtCodeCompTo.Text = data.Rows(0)("store_number_to").ToString
        MEAdrressCompTo.Text = data.Rows(0)("store_address_to").ToString
        DEForm.Text = view_date_from(data.Rows(0)("sales_return_order_datex").ToString, 0)
        TxtSalesOrderNumber.Text = data.Rows(0)("sales_return_order_number").ToString
        MENote.Text = data.Rows(0)("sales_return_order_note").ToString
        DERetDueDate.EditValue = data.Rows(0)("sales_return_order_est_date")
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_prepare_status = data.Rows(0)("id_prepare_status").ToString
        TxtOrderStatus.Text = data.Rows(0)("prepare_status").ToString

        If is_detail_soh <> "-1" Then
            TxtOrderStatus.Visible = True
            LabelOrderStatus.Visible = True
            GroupControl3.Visible = False
            BtnOrderStatus.Visible = True
            GridColumnRemark.Visible = False
            GridColumnAmount.Visible = False
            GridColumnPrice.Visible = False
            GridColumnSOH.Visible = False
            GridColumnQty.Visible = True
            GridColumnNo.VisibleIndex = 0
            GridColumnCode.VisibleIndex = 1
            GridColumnName.VisibleIndex = 2
            GridColumnSize.VisibleIndex = 3
            GridColumnQty.VisibleIndex = 4
            GridColumnQtyReturn.VisibleIndex = 5
        End If

        'detail2
        viewDetail()
        check_but()
        allow_status()

        If is_print = "1" Then
            printOrder()
            Close()
        End If
    End Sub

    Sub printOrder()
        Cursor = Cursors.WaitCursor
        ReportSalesReturnOrder.id_sales_return_order = id_sales_return_order
        ReportSalesReturnOrder.dt = GCItemList.DataSource
        ReportSalesReturnOrder.is_hidden_app_list = "1"
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
        Tool.ShowPreviewDialog()
        Cursor = Cursors.Default
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        If is_detail_soh <> "-1" Then
            Dim query As String = "CALL view_sales_return_order_limit('" + id_sales_return_order + "',0,0)"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            GCItemList.DataSource = data
            'Dim dt As DataTable = execute_query("CALL view_stock_fg('" + id_comp + "', '" + id_wh_locator + "', '" + id_wh_rack + "', '" + id_wh_drawer + "', '0', '4', '9999-01-01')", -1, True, "", "", "", "")
            'Dim tb1 = data.AsEnumerable()
            'Dim tb2 = dt.AsEnumerable()
            'Dim query_new = From table1 In tb1
            '                Group Join table_tmp In tb2 On table1("code") Equals table_tmp("code")
            '                Into Group
            '                From y1 In Group.DefaultIfEmpty()
            '                Select New With
            '                {
            '                .code = table1.Field(Of String)("code"),
            '                .name = table1.Field(Of String)("name"),
            '                .size = table1.Field(Of String)("size"),
            '                .sales_return_order_det_qty = CType(table1("sales_return_order_det_qty"), Decimal),
            '                .sales_return_det_qty_view = CType(table1("sales_return_det_qty_view"), Decimal),
            '                .soh = If(y1 Is Nothing, 0.0, y1("qty_all_product")),
            '                .design_price = CType(table1("design_price"), Decimal),
            '                .amount = CType(table1("amount"), Decimal)
            '                }
            'GCItemList.DataSource = query_new.ToList
        Else
            Dim query As String = "CALL view_sales_return_order('" + id_sales_return_order + "')"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            GCItemList.DataSource = data
        End If
    End Sub

    Private Sub DERetDueDate_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DERetDueDate.EditValueChanged
        ' Try
        date_start = execute_query("select now()", 0, True, "", "", "", "")
        DERetDueDate.Properties.MinValue = date_start
        'Catch ex As Exception

        'End Try
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
            'BtnBrowseContactTo.Enabled = True
            GVItemList.OptionsBehavior.Editable = True
            MENote.Properties.ReadOnly = False
            DERetDueDate.Enabled = True
            'BtnInfoSrs.Enabled = True
            'LEPLCategory.Enabled = True
        Else
            'BtnBrowseContactTo.Enabled = False
            GVItemList.OptionsBehavior.Editable = False
            MENote.Properties.ReadOnly = True
            DERetDueDate.Enabled = False
            'BtnInfoSrs.Enabled = False
            'LEPLCategory.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            'BtnPrint.Enabled = True
        Else
            'BtnPrint.Enabled = False
        End If
        TxtSalesOrderNumber.Focus()
    End Sub

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactTo.Click
        FormPopUpContact.id_pop_up = "40"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub FormViewSalesReturnOrder_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        check_but()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.is_view = "1"
        FormReportMark.id_report = id_sales_return_order
        FormReportMark.report_mark_type = "45"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sales_return_order
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.report_mark_type = "45"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnOrderStatus_Click(sender As Object, e As EventArgs) Handles BtnOrderStatus.Click
        Dim id_prepare As String = id_sales_return_order
        Dim id_cur_stt As String = id_prepare_status
        FormSalesOrderPacking.id_trans = id_prepare
        FormSalesOrderPacking.id_cur_status = id_cur_stt
        FormSalesOrderPacking.id_pop_up = "3"
        FormSalesOrderPacking.ShowDialog()
    End Sub
End Class