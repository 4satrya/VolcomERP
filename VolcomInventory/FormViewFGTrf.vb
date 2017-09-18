Public Class FormViewFGTrf 
    Public action As String = ""
    Public id_fg_trf As String = "-1"
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
    Dim is_only_for_alloc As String = "-1"

    Private Sub FormFGTrfDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormFGTrfDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        GroupControlListItem.Enabled = True
        GroupControlDrawerDetail.Enabled = True
        GroupControlScannedItem.Enabled = True
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
        XTPOutboundScanNew.PageEnabled = True


        'query view based on edit id's
        Dim query As String = ""
        query += "SELECT "
        query += "trf.id_fg_trf, trf.fg_trf_number, DATE_FORMAT(trf.fg_trf_date_rec, '%Y-%m-%d') AS fg_trf_date_recx, DATE_FORMAT(trf.fg_trf_date, '%Y-%m-%d') AS fg_trf_datex, trf.fg_trf_note, trf.id_report_status, trf.id_report_status_rec, rep_status.report_status, "
        query += "IF(ISNULL(trf.fg_trf_date_rec), DATE_FORMAT(NOW(), '%Y-%m-%d'),  DATE_FORMAT(trf.fg_trf_date_rec, '%Y-%m-%d')) AS fg_trf_date_recx, "
        query += "(comp_from.id_comp) AS id_comp_from, (comp_from.comp_number) AS comp_number_from, (comp_from.comp_name) AS comp_name_from, "
        query += "(comp_to.id_comp) AS id_comp_to, (comp_to.comp_number) AS comp_number_to, (comp_to.comp_name) AS comp_name_to, comp_to.is_only_for_alloc, "
        query += "trf.id_comp_contact_from, trf.id_comp_contact_to "
        query += "FROM tb_fg_trf trf "
        query += "INNER JOIN tb_m_comp_contact comp_con_from ON trf.id_comp_contact_from = comp_con_from.id_comp_contact "
        query += "INNER JOIN tb_m_comp comp_from ON comp_con_from.id_comp = comp_from.id_comp "
        query += "INNER JOIN tb_m_comp_contact comp_con_to ON trf.id_comp_contact_to = comp_con_to.id_comp_contact "
        query += "INNER JOIN tb_m_comp comp_to ON comp_con_to.id_comp = comp_to.id_comp "
        query += "INNER JOIN tb_lookup_report_status rep_status ON trf.id_report_status = rep_status.id_report_status "
        query += "WHERE trf.id_fg_trf = '" + id_fg_trf + "' "
        query += "ORDER BY trf.id_fg_trf DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        id_fg_trf = data.Rows(0)("id_fg_trf").ToString
        id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
        id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
        id_comp_from = data.Rows(0)("id_comp_from").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        id_report_status = data.Rows(0)("id_report_status").ToString
        id_report_status_rec = data.Rows(0)("id_report_status_rec").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
        TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
        TxtCodeCompTo.Text = data.Rows(0)("comp_number_to").ToString
        TxtNumber.Text = data.Rows(0)("fg_trf_number").ToString
        DEForm.Text = view_date_from(data.Rows(0)("fg_trf_datex").ToString, 0)
        MENote.Text = data.Rows(0)("fg_trf_note").ToString
        is_only_for_alloc = data.Rows(0)("is_only_for_alloc").ToString

        'Receive TRF
        If id_type = "1" Then
            LEReportStatus2.Visible = True
            GroupControl1.Enabled = True
            If IsDBNull(data.Rows(0)("id_report_status_rec")) Or data.Rows(0)("id_report_status_rec").ToString = "" Then
                is_new_rec = True
                BMark.Enabled = False
                DEForm.Text = view_date(0)
                LEReportStatus2.ItemIndex = LEReportStatus2.Properties.GetDataSourceRowIndex("id_report_status", "1")
            Else
                is_new_rec = False
                BMark.Enabled = True
                DEForm.Text = view_date_from(data.Rows(0)("fg_trf_date_recx").ToString, 0)
                LEReportStatus2.ItemIndex = LEReportStatus2.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status_rec").ToString)
            End If
            MENote.Visible = False
            LabelControl18.Visible = False
            LabelControl2.Visible = True
            GridColumnQtyWH.Visible = False
            GridColumnRemark.Visible = False
        Else
            GridColumnQtyReceive.Visible = False
            GridColumnQtyStored.Visible = False
        End If

        'detail2
        viewDetail()
        'view_barcode_list()
        viewDetailDrawer()
        allow_status()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
        viewLookupQuery(LEReportStatus2, query, 0, "report_status", "id_report_status")
    End Sub

    Sub allow_status()
        If id_type = "-1" Then
            If check_edit_report_status(id_report_status, "57", id_fg_trf) Then
                GVItemList.OptionsBehavior.Editable = True
                MENote.Properties.ReadOnly = False
            Else
                GVItemList.OptionsBehavior.Editable = False
                MENote.Properties.ReadOnly = True
            End If

        ElseIf id_type = "1" Then
            If check_edit_report_status(id_report_status, "58", id_fg_trf) Or is_new_rec = True Then
                GVItemList.OptionsBehavior.Editable = True
            Else
                GVItemList.OptionsBehavior.Editable = False
            End If

        End If

        'mark button
        Dim query_cek As String = "SELECT * FROM tb_report_mark WHERE report_mark_type=57 AND id_report=" + id_fg_trf + " "
        Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
        If data_cek.Rows.Count > 0 Then
            BMark.Enabled = True
        Else
            BMark.Enabled = False
        End If
        TxtNumber.Focus()
    End Sub

    Sub view_barcode_list(ByVal id_fg_trf_dety_param As String)
        Dim query As String = ""
        query += "SELECT ('') AS no, CONCAT(c.product_full_code, a.fg_trf_det_counting) AS code, "
        query += "(a.fg_trf_det_counting) AS counting_code, "
        query += "a.id_fg_trf_det_counting, ('2') AS is_fix, "
        query += "a.id_pl_prod_order_rec_det_unique, b.id_product "
        query += "FROM tb_fg_trf_det_counting a "
        query += "INNER JOIN tb_fg_trf_det b ON a.id_fg_trf_det = b.id_fg_trf_det "
        query += "INNER JOIN tb_m_product c ON c.id_product = b.id_product "
        query += "WHERE b.id_fg_trf = '" + id_fg_trf + "' AND a.id_fg_trf_det = '" + id_fg_trf_dety_param + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
    End Sub

    Sub viewDetail()
        Dim id_param As String = ""
        Dim query As String = "CALL view_fg_trf('" + id_fg_trf + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub viewDetailDrawer()
        Dim query As String = ""
        query += "SELECT a.id_fg_trf_det_drawer, a.id_fg_trf_det,a1.id_product, a.id_wh_drawer, c.id_wh_rack, d.id_wh_locator, e.id_comp, b.id_wh_drawer, c.wh_rack, d.wh_locator, e.comp_name, "
        query += "(b.wh_drawer_code) AS drawer, (c.wh_rack_code) AS rack,  "
        query += "(d.wh_locator_code) AS locator, (e.comp_number) AS wh, a.bom_unit_price, "
        query += "(a.fg_trf_det_drawer_qty) AS qty_all_product, (a.fg_trf_det_drawer_qty) AS qty_all_product_old,(a.fg_trf_det_drawer_qty * a.bom_unit_price) AS total_cost  "
        query += "FROM tb_fg_trf_det_drawer a   "
        query += "INNER JOIN tb_fg_trf_det a1 ON a1.id_fg_trf_det = a.id_fg_trf_det "
        query += "INNER JOIN tb_m_wh_drawer b ON a.id_wh_drawer = b.id_wh_drawer  "
        query += "INNER JOIN tb_m_wh_rack c ON c.id_wh_rack = b.id_wh_rack  "
        query += "INNER JOIN tb_m_wh_locator d ON d.id_wh_locator = c.id_wh_locator INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp WHERE a1.id_fg_trf = '" + id_fg_trf + "'  "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'GCDrawer.DataSource = data
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
    


    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub


    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        If id_type = "-1" Then
            FormReportMark.report_mark_type = "57"
        ElseIf id_type = "1" Then
            FormReportMark.report_mark_type = "58"
        End If
        FormReportMark.id_report = id_fg_trf
        FormReportMark.form_origin = Name
        FormReportMark.is_view = "1"
        FormReportMark.is_view_finalize = "1"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
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

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
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

        Dim id_fg_trf_det_param As String = "-1"
        Try
            id_fg_trf_det_param = GVItemList.GetFocusedRowCellValue("id_fg_trf_det").ToString
        Catch ex As Exception
        End Try
        view_barcode_list(id_fg_trf_det_param)

    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        If id_type = "-1" Then
            FormDocumentUpload.report_mark_type = "57"
        ElseIf id_type = "1" Then
            FormDocumentUpload.report_mark_type = "58"
        End If
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.id_report = id_fg_trf
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        prePrinting()
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        ReportFGTrf.id_pre = "1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Sub getReport()
        Cursor = Cursors.WaitCursor
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
End Class