Public Class FormViewProdDemand
    Public id_prod_demand As String
    Public report_mark_type As String
    Public id_pd_kind As String = "-1"

    Dim id_role_super_admin As String = "-1"
    Public data_column As New DataTable

    Private Sub FormViewProdDemand_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' MsgBox(report_mark_type)
        Dim query As String = "SELECT * FROM tb_prod_demand a 
        INNER JOIN tb_season b ON a.id_season = b.id_season 
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = a.id_report_status
        WHERE a.id_prod_demand = '" + id_prod_demand + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LabelTitle.Text = data.Rows(0)("prod_demand_number").ToString
        LabelSubTitle.Text = "Season : " + data.Rows(0)("season").ToString
        LabelStatus.Text = "Status : " + data.Rows(0)("report_status").ToString
        id_pd_kind = data.Rows(0)("id_pd_kind").ToString
        If data.Rows(0)("id_report_status").ToString = "6" Then
            PanelControlCompleted.Visible = True
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
        Dim prod_demand_report As ClassProdDemand = New ClassProdDemand()
        prod_demand_report.printReportLess(id_prod_demand + " AND is_void=2", BGVProduct, GCProduct)

        'bestfit
        BGVProduct.BestFitColumns()
    End Sub

    Dim tot_cost As Decimal
    Dim tot_prc As Decimal
    Dim tot_cost_grp As Decimal
    Dim tot_prc_grp As Decimal
    Private Sub BGVProduct_CustomSummaryCalculate(ByVal sender As System.Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles BGVProduct.CustomSummaryCalculate

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
    Function CreateCheckItem(ByVal caption As String, ByVal column As DevExpress.XtraGrid.Columns.GridColumn) As DevExpress.Utils.Menu.DXMenuItem
        Dim item As DevExpress.Utils.Menu.DXMenuItem = New DevExpress.Utils.Menu.DXMenuItem(caption, New EventHandler(AddressOf OnCanMovedItemClick))
        item.Tag = New MenuColumnInfo(column)
        Return item
    End Function

    ' The class that stores menu specific information.
    Class MenuColumnInfo
        Public Sub New(ByVal column As DevExpress.XtraGrid.Columns.GridColumn)
            Me.Column = column
        End Sub
        Public Column As DevExpress.XtraGrid.Columns.GridColumn
    End Class

    ' Menu item click handler.
    Sub OnCanMovedItemClick(ByVal sender As Object, ByVal e As EventArgs)
        data_column.Clear()
        For i As Integer = 0 To BGVProduct.Columns.Count - 1
            Dim R As DataRow = data_column.NewRow
            R("options_view_det_band") = BGVProduct.Columns(i).OwnerBand.ToString
            R("options_view_det_caption") = BGVProduct.Columns(i).Caption.ToString
            R("options_view_det_column") = BGVProduct.Columns(i).FieldName.ToString
            R("options_view_det_visible") = BGVProduct.Columns(i).Visible.ToString
            data_column.Rows.Add(R)
        Next
        FormOptView.frm_opt_name = "FormViewProdDemand"
        FormOptView.gv_opt_name = "BGVProduct"
        FormOptView.tag_opt_name = "1"
        FormOptView.dt = data_column
        FormOptView.ShowDialog()
    End Sub

    Private Sub BGVProduct_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles BGVProduct.PopupMenuShowing
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column And id_role_login = id_role_super_admin Then
            Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = e.Menu

            If Not menu.Column Is Nothing Then
                menu.Items.Add(CreateCheckItem("Options View", menu.Column))
            End If
        End If
    End Sub

    Private Sub FormViewProdDemand_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub CheckEditShowNonActive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditShowNonActive.CheckedChanged
        Cursor = Cursors.WaitCursor
        If CheckEditShowNonActive.EditValue = True Then
            Dim prod_demand_report As ClassProdDemand = New ClassProdDemand()
            prod_demand_report.printReportLess(id_prod_demand, BGVProduct, GCProduct)
        Else
            Dim prod_demand_report As ClassProdDemand = New ClassProdDemand()
            prod_demand_report.printReportLess(id_prod_demand + " AND is_void=2 ", BGVProduct, GCProduct)
        End If
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
End Class