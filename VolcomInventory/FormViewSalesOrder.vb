Imports DevExpress.XtraReports.UI

Public Class FormViewSalesOrder
    Public action As String
    Public id_sales_order As String = "-1"
    Public id_store_contact_to As String = "-1"
    Public id_store As String = "-1"
    Public id_report_status As String
    Public id_sales_order_det_list As New List(Of String)
    Public id_so_type As String = "-1"
    Public id_comp_contact_par As String = "-1"
    Public id_comp_par As String = "-1"
    Dim id_comp_cat_wh As String = "-1"
    Public is_print As String = "-1"
    Dim id_so_status As String = "-1"
    Dim id_commerce_type As String = "-1"

    Private Sub FormViewSalesOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        viewReportStatus()
        viewSoType()
        viewSoStatus()
        viewSeason()
        actionLoad()
        If is_print = "1" Then
            printSO()
            Close()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub actionLoad()
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
        BMark.Enabled = True

        'query view based on edit id's
        Dim query As String = "SELECT a.id_so_status, a.id_sales_order, a.id_store_contact_to, d.id_commerce_type, (d.id_comp) AS id_store,(d.comp_name) AS store_name_to, (d.comp_number) AS store_number_to, (d.address_primary) AS store_address_to, a.id_warehouse_contact_to, (wh.id_comp) AS id_comp_par,(wh.comp_name) AS warehouse_name_to, (wh.comp_number) AS warehouse_number_to, a.id_report_status, f.report_status, "
        query += "a.sales_order_note, a.sales_order_date, a.sales_order_note, a.sales_order_number, "
        query += "DATE_FORMAT(a.sales_order_date,'%Y-%m-%d') AS sales_order_datex, a.id_so_type, IFNULL(an.fg_so_reff_number,'-') AS `fg_so_reff_number`, ps.id_prepare_status, ps.prepare_status, eu.period_name, ut.uni_type, ube.employee_code, ube.employee_name, a.sales_order_ol_shop_number, a.customer_name "
        query += "FROM tb_sales_order a "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact wh_c ON wh_c.id_comp_contact = a.id_warehouse_contact_to "
        query += "INNER JOIN tb_m_comp wh ON wh_c.id_comp = wh.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_lookup_so_type g ON g.id_so_type = a.id_so_type "
        query += "INNER JOIN tb_lookup_so_status h ON h.id_so_status = a.id_so_status "
        query += "LEFT JOIN tb_fg_so_reff an ON an.id_fg_so_reff = a.id_fg_so_reff "
        query += "INNER JOIN tb_lookup_prepare_status ps ON ps.id_prepare_status = a.id_prepare_status 
        LEFT JOIN tb_emp_uni_period eu ON eu.id_emp_uni_period=a.id_emp_uni_period 
        LEFT JOIN tb_lookup_uni_type ut ON ut.id_uni_type = a.id_uni_type 
        LEFT JOIN tb_emp_uni_budget ub ON ub.id_emp_uni_budget = a.id_emp_uni_budget
        LEFT JOIN tb_m_employee ube ON ube.id_employee = ub.id_employee "
        query += "WHERE a.id_sales_order = '" + id_sales_order + "' "
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

        id_report_status = data.Rows(0)("id_report_status").ToString
        TxtReff.Text = data.Rows(0)("fg_so_reff_number").ToString

        id_store = data.Rows(0)("id_store").ToString
        id_commerce_type = data.Rows(0)("id_commerce_type").ToString
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
        TxtOLShopNumber.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
        MENote.Text = data.Rows(0)("sales_order_note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)
        LEStatusSO.ItemIndex = LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", data.Rows(0)("id_so_status").ToString)
        TxtPackingStatus.Text = data.Rows(0)("prepare_status").ToString

        'uni
        id_so_status = data.Rows(0)("id_so_status").ToString
        If id_so_status = "7" Then
            LabelUni1.Visible = True
            LabelUni2.Visible = True
            TxtUni1.Visible = True
            TxtUni2.Visible = True
            TxtUni1.Text = data.Rows(0)("employee_code").ToString
            TxtUni2.Text = data.Rows(0)("employee_name").ToString
        End If

        'ol store order
        If id_commerce_type = "2" Then
            LabelUni2.Visible = True
            TxtUni2.Visible = True
            TxtUni2.Text = data.Rows(0)("customer_name").ToString
        End If

        'detail2
        viewDetail()
        check_but()
        allow_status()

        'detail column
        If id_commerce_type = "2" Then
            GridColumnItemId.VisibleIndex = 1
            GridColumnOLStoreId.VisibleIndex = 2
        End If
    End Sub

    Private Report As ReportSalesOrder
    Sub printSO()
        Cursor = Cursors.WaitCursor
        GVItemList.BestFitColumns()
        ReportSalesOrder.dt = GCItemList.DataSource
        ReportSalesOrder.id_sales_order = id_sales_order
        Report = New ReportSalesOrder()

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
        If id_so_status = "7" Then
            Report.LabelNIK.Visible = True
            Report.LabelNIKDot.Visible = True
            Report.LabelTitleNIK.Visible = True
            Report.LabelName.Visible = True
            Report.LabelNameDot.Visible = True
            Report.LabelTitleName.Visible = True
            Report.LabelNIK.Text = TxtUni1.Text
            Report.LabelName.Text = TxtUni2.Text
        End If

        If id_commerce_type = "2" Then
            Report.LabelTitleName.Visible = True
            Report.LabelNameDot.Visible = True
            Report.LabelName.Visible = True
            Report.LabelName.Text = TxtUni2.Text

            Report.LabelOLStoreOrder.Visible = True
            Report.LabelTitleOLStoreOrder.Visible = True
            Report.LabelDotOLStoreOrder.Visible = True
            Report.LabelOLStoreOrder.Text = TxtOLShopNumber.Text
        End If

        AddHandler Report.PrintingSystem.EndPrint, AddressOf PrintingSystem_EndPrint
        Report.ShowPreviewDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub PrintingSystem_EndPrint(ByVal sender As Object, ByVal e As EventArgs)
        'insert log
        Dim query As String = "INSERT INTO tb_sales_order_log_print(id_sales_order, id_user, log_date) VALUES('" + id_sales_order + "','" + id_user + "', NOW()) "
        execute_non_query(query, True, "", "", "", "")
        Report.ClosePreview()
    End Sub

    Sub viewSeason()

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
        Dim query As String = ""
        If id_commerce_type = "2" Then
            query = "CALL view_sales_order_ol_store('" + id_sales_order + "')"

        Else
            query = "CALL view_sales_order('" + id_sales_order + "')"
        End If
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub


    'sub check_but
    Sub check_but()

    End Sub

    Sub allow_status()
        MENote.Properties.ReadOnly = True
        LETypeSO.Enabled = False
        LEStatusSO.Enabled = False
        BtnAttachment.Enabled = True
        TxtSalesOrderNumber.Focus()
    End Sub



    Private Sub FormViewSalesOrder_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SLESeason_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            viewDelivery()
        Catch ex As Exception

        End Try
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
        FormReportMark.id_report = id_sales_order
        FormReportMark.report_mark_type = "39"
        FormReportMark.form_origin = Name
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sales_order
        FormDocumentUpload.report_mark_type = "39"
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class