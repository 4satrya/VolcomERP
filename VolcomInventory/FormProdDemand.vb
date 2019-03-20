Public Class FormProdDemand
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim total_size_column As Integer = 0
    Public cond_view As String = "-1"
    Public sort_view As String = "2"
    Dim super_user As String = get_setup_field("id_role_super_admin")

    'Form Load
    Private Sub FormProdDemand_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewProdDemand()
    End Sub
    'View Production Demand
    Sub viewProdDemand()
        Dim query_c As ClassProdDemand = New ClassProdDemand()
        If id_role_login <> super_user Then
            cond_view = "AND rg.id_departement =''" + id_departement_user + "'' "
        End If
        Dim query As String = query_c.queryMain(cond_view, sort_view)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdDemand.DataSource = data
        If data.Rows.Count > 0 Then
            GVProdDemand.FocusedRowHandle = 0
            GCProduct.DataSource = Nothing
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        Else
            BMark.Enabled = False
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub
    'Check print status
    Sub checkPrintStatus()
        Dim id_report_status As String = "-1"
        Try
            id_report_status = GVProdDemand.GetFocusedRowCellValue("id_report_status").ToString
        Catch ex As Exception

        End Try
        If check_print_report_status(id_report_status) Then
            BPrint.Enabled = True
            BCreate.Enabled = True
        Else
            BPrint.Enabled = False
            BCreate.Enabled = False
        End If
    End Sub

    'Activated Event
    Private Sub FormProdDemand_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub
    'Deadactivated Event
    Private Sub FormProdDemand_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    'Focused Row Changed
    Private Sub GVProdDemand_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdDemand.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        GCProduct.DataSource = Nothing
        BCreate.Enabled = False
        BPrint.Enabled = False
        noManipulating()
        Cursor = Cursors.Default
    End Sub
    'Row Click Number
    Private Sub GVProdDemand_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVProdDemand.RowClick

        'checkPrintStatus()
    End Sub

    Sub view_product()
        Dim id_prod_demand As String = "-1"
        Try
            id_prod_demand = GVProdDemand.GetFocusedRowCellDisplayText("id_prod_demand").ToString
            If id_prod_demand = "" Then
                id_prod_demand = "-1"
            End If
        Catch ex As Exception
        End Try

        'build report
        Dim prod_demand_report As ClassProdDemand = New ClassProdDemand()
        prod_demand_report.printReport(id_prod_demand, BGVProduct, GCProduct)

        allow_status()
    End Sub

    Sub allow_status()
        Dim id_status As String = "-1"
        Try
            id_status = GVProdDemand.GetFocusedRowCellDisplayText("id_report_status").ToString
        Catch ex As Exception
        End Try
        If check_print_report_status(id_status) Then
            BPrint.Enabled = True
            BCreate.Enabled = True
        Else
            BPrint.Enabled = False
            BCreate.Enabled = False
        End If
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        '... 
        ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        BGVProduct.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        ReportProdDemand.dt = GCProduct.DataSource
        ReportProdDemand.id_prod_demand = GVProdDemand.GetFocusedRowCellDisplayText("id_prod_demand").ToString
        ReportProdDemand.prod_demand_number = GVProdDemand.GetFocusedRowCellDisplayText("prod_demand_number").ToString
        ReportProdDemand.season = GVProdDemand.GetFocusedRowCellDisplayText("season").ToString
        ReportProdDemand.coba = "TOTAL COST_add_report_column"

        Dim Report As New ReportProdDemand()
        Report.BandedGridView1.OptionsBehavior.AutoExpandAllGroups = True
        Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        ReportStyleBanded(Report.BandedGridView1)
        Report.BandedGridView1.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()

    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = GVProdDemand.GetFocusedRowCellDisplayText("id_prod_demand").ToString
        FormReportMark.report_mark_type = "9"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCreate.Click
        FormProdDemandMat.id_prod_demand = GVProdDemand.GetFocusedRowCellDisplayText("id_prod_demand").ToString
        FormProdDemandMat.ShowDialog()
    End Sub



    Private Sub BGVProduct_CustomSummaryCalculate(ByVal sender As System.Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles BGVProduct.CustomSummaryCalculate

        Dim gv As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)
        If (Not e.IsGroupSummary) Then Return
        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
        item = e.Item

        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize AndAlso item.FieldName.ToString = "MARK UP_add_report_column" Then
            Dim summary_gr As Decimal = 0.0
            Try
                summary_gr = gv.GetGroupSummaryValue(e.GroupRowHandle, CType(gv.GroupSummary("TOTAL AMOUNT_add_report_column"), DevExpress.XtraGrid.GridGroupSummaryItem)) / gv.GetGroupSummaryValue(e.GroupRowHandle, CType(gv.GroupSummary("TOTAL COST_add_report_column"), DevExpress.XtraGrid.GridGroupSummaryItem))
                MsgBox(summary_gr.ToString)
            Catch ex As Exception
            End Try
            e.TotalValue = summary_gr
        End If
    End Sub

    Private Sub BGVProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles BGVProduct.CustomColumnDisplayText
        If e.Column.FieldName = "No_desc_report_column" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVProdDemand.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                BMark.Enabled = False
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                BMark.Enabled = True
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVProdDemand_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProdDemand.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        GCProduct.DataSource = Nothing
        BCreate.Enabled = False
        BPrint.Enabled = False
        noManipulating()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnLoadDetailPD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLoadDetailPD.Click
        Cursor = Cursors.WaitCursor
        noManipulating()
        view_product()
        Cursor = Cursors.Default

        'Try
        '    'Prepare Baded
        '    BGVProduct.Columns.Clear()
        '    BGVProduct.Bands.Clear()
        '    BGVProduct.ColumnPanelRowHeight = 50
        '    BGVProduct.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        '    BGVProduct.OptionsBehavior.AutoExpandAllGroups = True

        '    ' Make the group footers always visible.
        '    BGVProduct.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

        '    Dim band_desc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVProduct.Bands.AddBand("PRODUCT DETAIL")
        '    band_desc.AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)
        '    Dim band_size As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVProduct.Bands.AddBand("BREAKDOWN SIZE TOTAL")
        '    band_size.AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)
        '    Dim band_additional As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVProduct.Bands.AddBand("COST/PRICE")
        '    band_additional.AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)

        '    Dim query As String = "CALL view_prod_demand_list('" & GVProdDemand.GetFocusedRowCellValue("id_prod_demand").ToString & "')"
        '    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '    For i As Integer = 0 To data.Columns.Count - 1
        '        If data.Columns(i).ColumnName.ToString.Contains("_desc_report_column") Then
        '            Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 19
        '            band_desc.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)
        '        ElseIf data.Columns(i).ColumnName.ToString.Contains("_Alloc") Then
        '            Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("_"c)

        '            Dim found_band As Boolean = False
        '            For Each group As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BGVProduct.Bands
        '                If group.Caption.ToString = str_arr(1).ToString Then
        '                    found_band = True
        '                    group.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(0).ToString))
        '                    Exit For
        '                End If
        '            Next group

        '            If Not found_band Then
        '                Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVProduct.Bands.AddBand(str_arr(1).ToString)
        '                band_new.AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)
        '                band_new.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(0).ToString))
        '            End If

        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)

        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

        '            Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
        '            item.FieldName = data.Columns(i).ColumnName.ToString
        '            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '            item.DisplayFormat = "{0:n2}"
        '            item.ShowInGroupColumnFooter = BGVProduct.Columns(data.Columns(i).ColumnName.ToString)
        '            BGVProduct.GroupSummary.Add(item)
        '        ElseIf data.Columns(i).ColumnName.ToString.Contains("_size") Then
        '            Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 5
        '            band_size.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))

        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)

        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

        '            Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
        '            item.FieldName = data.Columns(i).ColumnName.ToString
        '            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '            item.DisplayFormat = "{0:n2}"
        '            item.ShowInGroupColumnFooter = BGVProduct.Columns(data.Columns(i).ColumnName.ToString)
        '            BGVProduct.GroupSummary.Add(item)
        '        ElseIf data.Columns(i).ColumnName.ToString.Contains("_add_report_column") Then
        '            Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 18
        '            band_additional.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))

        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        '            BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)

        '            If data.Columns(i).ColumnName.ToString = "TOTAL COST_add_report_column" Or data.Columns(i).ColumnName.ToString = "TOTAL AMOUNT_add_report_column" Then
        '                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        '                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

        '                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

        '                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
        '                item.FieldName = data.Columns(i).ColumnName.ToString
        '                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '                item.DisplayFormat = "{0:n2}"
        '                item.Tag = data.Columns(i).ColumnName.ToString
        '                item.ShowInGroupColumnFooter = BGVProduct.Columns(data.Columns(i).ColumnName.ToString)
        '                BGVProduct.GroupSummary.Add(item)
        '            ElseIf data.Columns(i).ColumnName.ToString = "MARK UP_add_report_column" Then
        '                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        '                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

        '                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom

        '                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
        '                item.FieldName = data.Columns(i).ColumnName.ToString
        '                item.SummaryType = DevExpress.Data.SummaryItemType.Custom
        '                item.DisplayFormat = "{0:n2}"
        '                item.ShowInGroupColumnFooter = BGVProduct.Columns(data.Columns(i).ColumnName.ToString)
        '                BGVProduct.GroupSummary.Add(item)
        '            Else
        '                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        '                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
        '            End If
        '        End If
        '    Next
        '    GCProduct.DataSource = data

        '    'sumary markup
        '    Dim summary_mark As Decimal = 0.0
        '    Try
        '        summary_mark = Double.Parse(BGVProduct.Columns("TOTAL AMOUNT_add_report_column").SummaryItem.SummaryValue.ToString) / Double.Parse(BGVProduct.Columns("TOTAL COST_add_report_column").SummaryItem.SummaryValue.ToString)
        '    Catch ex As Exception
        '    End Try
        '    BGVProduct.Columns("MARK UP_add_report_column").SummaryItem.DisplayFormat = summary_mark.ToString("N2")

        '    'hide column
        '    BGVProduct.Bands.MoveTo(1, band_desc)
        '    BGVProduct.Bands.MoveTo(98, band_size)
        '    BGVProduct.Bands.MoveTo(99, band_additional)
        '    BGVProduct.Columns("id_design_desc_report_column").Visible = False

        '    'DISPOSE
        '    data.Dispose()
        'Catch ex As Exception
        '    errorConnection()
        'End Try

    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim id_prod_demand As String = "-1"
        Try
            id_prod_demand = GVProdDemand.GetFocusedRowCellValue("id_prod_demand").ToString
        Catch ex As Exception
        End Try
        If id_prod_demand = "-1" Or id_prod_demand = "" Then
            stopCustom("Please select specific PD!")
        Else
            infoCustom("Ok Sip")
        End If
    End Sub

    Private Sub GVProdDemand_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProdDemand.DoubleClick
        Cursor = Cursors.WaitCursor
        If GVProdDemand.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
        Cursor = Cursors.Default
    End Sub

End Class