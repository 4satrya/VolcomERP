Public Class FormViewProdDemand
    Public id_prod_demand As String
    Public report_mark_type As String
    Public id_pd_kind As String = "-1"

    Dim id_role_super_admin As String = "-1"
    Public data_column As New DataTable
    Dim is_load_break_size As Boolean = False
    Dim is_confirm As Boolean = False
    Public is_for_production As Boolean = False
    Dim created_date As String = ""
    Dim season As String = ""
    Dim division As String = ""
    Dim id_report_status As String = ""
    Dim status As String = ""
    Dim rate_current As String = ""
    Dim note As String = ""
    Dim rmt As String = "-1"

    Private Sub FormViewProdDemand_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' MsgBox(report_mark_type)
        Dim query As String = "SELECT * FROM tb_prod_demand a 
        INNER JOIN tb_season b ON a.id_season = b.id_season 
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = a.id_report_status
        INNER JOIN tb_lookup_pd_budget bt ON bt.id_pd_budget = a.id_pd_budget
        LEFT JOIN tb_m_code_detail cd ON cd.id_code_detail = a.id_division
        WHERE a.id_prod_demand = '" + id_prod_demand + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LabelTitle.Text = data.Rows(0)("prod_demand_number").ToString
        LabelSubTitle.Text = "Season : " + data.Rows(0)("season").ToString
        LabelStatus.Text = "Status : " + data.Rows(0)("report_status").ToString
        LabelBudgetType.Text = "Budget type : " + data.Rows(0)("pd_budget").ToString
        id_pd_kind = data.Rows(0)("id_pd_kind").ToString
        If id_pd_kind = "1" Then 'MD
            rmt = "9"
        ElseIf id_pd_kind = "2" Then 'MKT
            rmt = "80"
        Else 'HRD
            rmt = "81"
        End If
        If data.Rows(0)("is_confirm").ToString = "1" Then
            is_confirm = True
        Else
            is_confirm = False
        End If
        created_date = Date.Parse(data.Rows(0)("prod_demand_date").ToString).ToString("dd MMMM yyyy").ToUpper
        season = data.Rows(0)("season").ToString.ToUpper
        division = data.Rows(0)("code_detail_name").ToString.ToUpper
        id_report_status = data.Rows(0)("id_report_status").ToString
        status = data.Rows(0)("report_status").ToString.ToUpper
        rate_current = data.Rows(0)("rate_current").ToString
        note = data.Rows(0)("prod_demand_note").ToString

        PanelControlCompleted.Visible = True
        If data.Rows(0)("id_report_status").ToString = "6" Then
            CheckEditShowNonActive.Visible = True
            XTPRevision.PageVisible = True
        End If


        'initial role super admin
        id_role_super_admin = get_setup_field("id_role_super_admin")

        'custom column template inisialisasi
        'initialisation datatable edit
        Try
            data_column.Columns.Add("options_view_det_band")
            data_column.Columns.Add("options_view_det_caption")
            data_column.Columns.Add("options_view_det_column")
            data_column.Columns.Add("options_view_det_visible")
        Catch ex As Exception
        End Try

        view_product()

        If is_for_production Then
            BtnPrint.Visible = True
            BMark.Visible = False
            BGVProduct.Columns("ADDITIONAL COST_add_report_column").Visible = False
            BGVProduct.Columns("PROPOSE PRICE_add_report_column").Visible = False
            BGVProduct.Columns("ADDITIONAL PRICE_add_report_column").Visible = False
            BGVProduct.Columns("PROPOSE PRICE NON ADDITIONAL_add_report_column").Visible = False
            BGVProduct.Columns("MARK UP_add_report_column").Visible = False
            BGVProduct.Columns("TOTAL AMOUNT NON ADDITIONAL_add_report_column").Visible = False
            BGVProduct.Columns("TOTAL AMOUNT_add_report_column").Visible = False
            BGVProduct.Columns("MOVE/DROP_desc_report_column").Visible = False
            BGVProduct.Columns("MARKETING_add_report_column").Visible = False
            BGVProduct.Columns("BUFFER STYLE_add_report_column").Visible = False
            BGVProduct.Columns("CORE_add_report_column").Visible = False
            BGVProduct.Columns("ACT ORDER SALES_add_report_column").Visible = False

            BGVProduct.Columns("ADDITIONAL COST_add_report_column").OptionsColumn.ShowInCustomizationForm = False
            BGVProduct.Columns("PROPOSE PRICE_add_report_column").OptionsColumn.ShowInCustomizationForm = False
            BGVProduct.Columns("ADDITIONAL PRICE_add_report_column").OptionsColumn.ShowInCustomizationForm = False
            BGVProduct.Columns("PROPOSE PRICE NON ADDITIONAL_add_report_column").OptionsColumn.ShowInCustomizationForm = False
            BGVProduct.Columns("MARK UP_add_report_column").OptionsColumn.ShowInCustomizationForm = False
            BGVProduct.Columns("TOTAL AMOUNT NON ADDITIONAL_add_report_column").OptionsColumn.ShowInCustomizationForm = False
            BGVProduct.Columns("TOTAL AMOUNT_add_report_column").OptionsColumn.ShowInCustomizationForm = False
            BGVProduct.Columns("MOVE/DROP_desc_report_column").OptionsColumn.ShowInCustomizationForm = False
            CEBreakSize.EditValue = True
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_prod_demand
        FormReportMark.report_mark_type = report_mark_type
        FormReportMark.is_view = "1"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub view_product()
        'build report
        Dim query As String = "CALL view_prod_demand_list_less('" + id_prod_demand + " AND is_void=2 ')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProduct.DataSource = data

        'bestfit
        BGVProduct.BestFitColumns()
    End Sub

    Dim tot_cost As Decimal
    Dim tot_prc As Decimal
    Dim tot_cost_grp As Decimal
    Dim tot_prc_grp As Decimal

    Private Sub BGVProduct_CustomSummaryCalculate_1(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles BGVProduct.CustomSummaryCalculate

        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            tot_cost = 0.0
            tot_prc = 0.0
            tot_cost_grp = 0.0
            tot_prc_grp = 0.0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST NON ADDITIONAL_add_report_column").ToString, "0.00"))
            Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMOUNT NON ADDITIONAL_add_report_column"), "0.00"))
            Select Case summaryID
                Case 46
                    tot_cost += cost
                    tot_prc += prc
                Case 47
                    tot_cost_grp += cost
                    tot_prc_grp += prc
            End Select
        End If

        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case 46 'total summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc / tot_cost
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case 47 'group summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc_grp / tot_cost_grp
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
            End Select
        End If
    End Sub

    Private Sub BGVProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles BGVProduct.CustomColumnDisplayText
        If e.Column.FieldName = "No_desc_report_column" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_prod_demand
        FormDocumentUpload.report_mark_type = report_mark_type
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    ' Creates a menu item.
    'Function CreateCheckItem(ByVal caption As String, ByVal column As DevExpress.XtraGrid.Columns.GridColumn) As DevExpress.Utils.Menu.DXMenuItem
    '    Dim item As DevExpress.Utils.Menu.DXMenuItem = New DevExpress.Utils.Menu.DXMenuItem(caption, New EventHandler(AddressOf OnCanMovedItemClick))
    '    item.Tag = New MenuColumnInfo(column)
    '    Return item
    'End Function

    ' The class that stores menu specific information.
    Class MenuColumnInfo
        Public Sub New(ByVal column As DevExpress.XtraGrid.Columns.GridColumn)
            Me.Column = column
        End Sub
        Public Column As DevExpress.XtraGrid.Columns.GridColumn
    End Class

    ' Menu item click handler.
    'Sub OnCanMovedItemClick(ByVal sender As Object, ByVal e As EventArgs)
    '    data_column.Clear()
    '    For i As Integer = 0 To BGVProduct.Columns.Count - 1
    '        Dim R As DataRow = data_column.NewRow
    '        R("options_view_det_band") = BGVProduct.Columns(i).OwnerBand.ToString
    '        R("options_view_det_caption") = BGVProduct.Columns(i).Caption.ToString
    '        R("options_view_det_column") = BGVProduct.Columns(i).FieldName.ToString
    '        R("options_view_det_visible") = BGVProduct.Columns(i).Visible.ToString
    '        data_column.Rows.Add(R)
    '    Next
    '    FormOptView.frm_opt_name = "FormViewProdDemand"
    '    FormOptView.gv_opt_name = "BGVProduct"
    '    FormOptView.tag_opt_name = "1"
    '    FormOptView.dt = data_column
    '    FormOptView.ShowDialog()
    'End Sub

    'Private Sub BGVProduct_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
    '    If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column And id_role_login = id_role_super_admin Then
    '        Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = e.Menu

    '        If Not menu.Column Is Nothing Then
    '            menu.Items.Add(CreateCheckItem("Options View", menu.Column))
    '        End If
    '    End If
    'End Sub

    Private Sub FormViewProdDemand_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub CheckEditShowNonActive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditShowNonActive.CheckedChanged
        Cursor = Cursors.WaitCursor
        If CheckEditShowNonActive.EditValue = True Then
            Dim query As String = "CALL view_prod_demand_list_less('" + id_prod_demand + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCProduct.DataSource = data
        Else
            Dim query As String = "CALL view_prod_demand_list_less('" + id_prod_demand + " AND is_void=2 ')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCProduct.DataSource = data
        End If
        'cek breakdown size
        is_load_break_size = False
        checkBreakSize()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCPD_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPD.SelectedPageChanged
        If XTCPD.SelectedTabPageIndex = 1 Then
            viewRevision()
        End If
    End Sub

    Sub viewRevision()
        Cursor = Cursors.WaitCursor
        Dim r As New ClassProdDemand
        Dim query As String = r.queryMainRev("AND r.id_prod_demand=" + id_prod_demand + "", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim rmt As String = ""
            If id_pd_kind = "1" Then 'MD
                rmt = "143"
            ElseIf id_pd_kind = "2" Then 'MKT
                rmt = "144"
            Else 'HRD
                rmt = "145"
            End If
            Dim m As New ClassShowPopUp()
            m.id_report = GVData.GetFocusedRowCellValue("id_prod_demand_rev").ToString
            m.report_mark_type = rmt
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ViewBreakdownSizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewBreakdownSizeToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If BGVProduct.RowCount > 0 And BGVProduct.FocusedRowHandle >= 0 Then
            Dim id_prod_demand_design As String = BGVProduct.GetFocusedRowCellValue("id_prod_demand_design").ToString
            FormProdDemandBreakSize.LabelTitle.Text = BGVProduct.GetFocusedRowCellValue("DESCRIPTION_desc_report_column").ToString
            FormProdDemandBreakSize.LabelSubTitle.Text = BGVProduct.GetFocusedRowCellValue("CODE_desc_report_column").ToString
            FormProdDemandBreakSize.id_pdd = id_prod_demand_design
            FormProdDemandBreakSize.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BGVProduct_CustomColumnDisplayText_1(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "No_desc_report_column" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub CEBreakSize_CheckedChanged(sender As Object, e As EventArgs) Handles CEBreakSize.CheckedChanged
        checkBreakSize()
    End Sub

    Sub checkBreakSize()
        Cursor = Cursors.WaitCursor
        Dim pd As New ClassProdDemand
        If CEBreakSize.EditValue = True Then
            'jika belum load
            If Not is_load_break_size Then
                pd.generateBreakSize(id_prod_demand, BGVProduct)
            End If

            'show column
            pd.showBreakSize(BGVProduct)
            is_load_break_size = True
        Else
            'hide
            pd.hideBreakSize(BGVProduct)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportProdDemandNew.dt = GCProduct.DataSource
        ReportProdDemandNew.id_prod_demand = id_prod_demand
        ReportProdDemandNew.is_pre = "-1"
        ReportProdDemandNew.is_hidden_mark = "1"
        ReportProdDemandNew.id_report_status = id_report_status

        ReportProdDemandNew.rmt = rmt
        Dim Report As New ReportProdDemandNew()

        '' '... 
        '' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        BGVProduct.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVDesign.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'style
        Report.GVDesign.OptionsPrint.UsePrintStyles = True
        Report.GVDesign.AppearancePrint.FilterPanel.BackColor = Color.Transparent
        Report.GVDesign.AppearancePrint.FilterPanel.ForeColor = Color.Black
        Report.GVDesign.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 5, FontStyle.Regular)

        Report.GVDesign.AppearancePrint.GroupFooter.BackColor = Color.Transparent
        Report.GVDesign.AppearancePrint.GroupFooter.ForeColor = Color.Black
        Report.GVDesign.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 5, FontStyle.Bold)

        Report.GVDesign.AppearancePrint.GroupRow.BackColor = Color.Transparent
        Report.GVDesign.AppearancePrint.GroupRow.ForeColor = Color.Black
        Report.GVDesign.AppearancePrint.GroupRow.Font = New Font("Tahoma", 5, FontStyle.Bold)


        Report.GVDesign.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
        Report.GVDesign.AppearancePrint.HeaderPanel.ForeColor = Color.Black
        Report.GVDesign.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 5, FontStyle.Bold)

        Report.GVDesign.AppearancePrint.FooterPanel.BackColor = Color.Transparent
        Report.GVDesign.AppearancePrint.FooterPanel.ForeColor = Color.Black
        Report.GVDesign.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 5.3, FontStyle.Bold)

        Report.GVDesign.AppearancePrint.Row.Font = New Font("Tahoma", 5.3, FontStyle.Regular)

        Report.GVDesign.OptionsPrint.ExpandAllDetails = True
        Report.GVDesign.OptionsPrint.UsePrintStyles = True
        Report.GVDesign.OptionsPrint.PrintDetails = True
        Report.GVDesign.OptionsPrint.PrintFooter = True


        Report.LabelNumber.Text = LabelTitle.Text
        Report.LabelDate.Text = created_date
        Report.LabelSeason.Text = season
        Report.LabelDivision.Text = division
        Report.LabelStatus.Text = status
        Report.LabelRateCurrent.Text = rate_current
        Report.LNote.Text = note

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        Cursor = Cursors.Default
    End Sub
End Class