Public Class ClassProdDemand
    'all PD
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        Dim query As String = "CALL view_prod_demand_main('" + condition + "', '" + order_type + "') "
        Return query
    End Function

    ' find design in PD
    Public Function queryFindDsg(ByVal id_dsg_par As String) As String
        Dim query As String = "CALL view_prod_demand_find_dsg('" + id_dsg_par + "') "
        Return query
    End Function

    'Print
    Public Sub printReportLess(ByVal id_prod_demand As String, ByVal BGVProduct As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView, ByVal GCProduct As DevExpress.XtraGrid.GridControl)
        'Try
        'Prepare Baded
        BGVProduct.Columns.Clear()
        BGVProduct.Bands.Clear()
        BGVProduct.GroupSummary.Clear()
        BGVProduct.ColumnPanelRowHeight = 40
        BGVProduct.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        BGVProduct.OptionsBehavior.AutoExpandAllGroups = True

        ' Make the group footers always visible.
        BGVProduct.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

        'prepare band
        Dim band_desc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVProduct.Bands.AddBand("")
        band_desc.AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)
        Dim band_additional As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVProduct.Bands.AddBand("")
        band_additional.AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)

        'declare band for merge coluumn
        Dim band_arr() As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
        Dim band_alloc_break() As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

        'declare arr to store break sizw column initial
        Dim break_alloc_initial As New List(Of String)

        'query
        Dim query As String = "CALL view_prod_demand_list_less('" & id_prod_demand & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        BGVProduct.BeginUpdate()

        'setup band size total
        Dim query_break_c As ClassDesign = New ClassDesign()
        Dim data_break_total As DataTable = query_break_c.getBreakTotalLineList("2")


        'setup band size alloc
        Dim query_break_alloc As ClassDesign = New ClassDesign()
        Dim data_band_alloc As DataTable = query_break_alloc.getBreakAllocLineList("1")


        'var bantu utk band dinamis
        Dim i_break As Integer = 0
        For i As Integer = 0 To data.Columns.Count - 1
            If data.Columns(i).ColumnName.ToString.Contains("_desc_report_column") Or data.Columns(i).ColumnName.ToString = "id_prod_demand_design" Or data.Columns(i).ColumnName.ToString = "id_prod_demand_design_alloc" Then
                If data.Columns(i).ColumnName.ToString.Contains("_desc_report_column") Then
                    Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 19
                    band_desc.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                Else
                    band_desc.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                End If

                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)
                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
            ElseIf data.Columns(i).ColumnName.ToString.Contains("_Alloc") Then
                i_break += 1
                Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("_"c)

                Dim found_band As Boolean = False
                For Each group As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BGVProduct.Bands
                    If group.Caption.ToString = str_arr(1).ToString Then
                        found_band = True
                        If str_arr(0).ToString = "TOTAL" Then
                            group.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(1).ToString))
                        Else
                            group.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(0).ToString))
                            'size position
                            Dim data_filterx As DataRow() = data_band_alloc.Select("[display_name]='" + data.Columns(i).ColumnName.ToString + "'")
                            BGVProduct.SetColumnPosition(BGVProduct.Columns(data.Columns(i).ColumnName.ToString), data_filterx(0)("code_row_index").ToString, data_filterx(0)("code_col_index").ToString)
                        End If
                        Exit For
                    End If
                Next group


                If Not found_band Then
                    If str_arr(0).ToString = "TOTAL" Then
                        Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVProduct.Bands.AddBand("")
                        band_new.AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)
                        band_new.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(1).ToString))
                        band_arr.AddMyMergeBand(band_new)
                    Else
                        Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVProduct.Bands.AddBand(str_arr(1).ToString)
                        band_new.AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)
                        band_new.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(0).ToString))
                        band_alloc_break.AddMyMergeBand(band_new)

                        'initial to breakdown size
                        Dim band_dyn_name As String = "brk" + i_break.ToString + "_"
                        band_new.Columns.Add(BGVProduct.Columns.AddVisible(band_dyn_name + "1", ""))
                        band_new.Columns.Add(BGVProduct.Columns.AddVisible(band_dyn_name + "2", ""))
                        band_new.Columns.Add(BGVProduct.Columns.AddVisible(band_dyn_name + "3", ""))
                        band_new.Columns.Add(BGVProduct.Columns.AddVisible(band_dyn_name + "4", ""))
                        BGVProduct.SetColumnPosition(BGVProduct.Columns(band_dyn_name + "1"), 0, 0)
                        BGVProduct.SetColumnPosition(BGVProduct.Columns(band_dyn_name + "2"), 1, 0)
                        BGVProduct.SetColumnPosition(BGVProduct.Columns(band_dyn_name + "3"), 2, 0)
                        BGVProduct.SetColumnPosition(BGVProduct.Columns(band_dyn_name + "4"), 3, 0)
                        break_alloc_initial.Add(band_dyn_name + "1")
                        break_alloc_initial.Add(band_dyn_name + "2")
                        break_alloc_initial.Add(band_dyn_name + "3")
                        break_alloc_initial.Add(band_dyn_name + "4")

                        'size position
                        Dim data_filterx As DataRow() = data_band_alloc.Select("[display_name]='" + data.Columns(i).ColumnName.ToString + "'")
                        BGVProduct.SetColumnPosition(BGVProduct.Columns(data.Columns(i).ColumnName.ToString), data_filterx(0)("code_row_index").ToString, data_filterx(0)("code_col_index").ToString)
                    End If
                End If

                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)

                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n2}"
                item.ShowInGroupColumnFooter = BGVProduct.Columns(data.Columns(i).ColumnName.ToString)
                BGVProduct.GroupSummary.Add(item)
                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
            ElseIf data.Columns(i).ColumnName.ToString.Contains("_add_report_column") Then
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 18
                band_additional.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))

                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)

                If data.Columns(i).ColumnName.ToString = "MARKETING_add_report_column" Or data.Columns(i).ColumnName.ToString = "UNIFORM_add_report_column" Or data.Columns(i).ColumnName.ToString = "BUFFER STYLE_add_report_column" Or data.Columns(i).ColumnName.ToString = "BUFFER ACCIDENTAL_add_report_column" Or data.Columns(i).ColumnName.ToString = "REJECT_add_report_column" Or data.Columns(i).ColumnName.ToString = "CORE_add_report_column" Or data.Columns(i).ColumnName.ToString = "ACT ORDER SALES_add_report_column" Or data.Columns(i).ColumnName.ToString = "TOTAL QTY_add_report_column" Or data.Columns(i).ColumnName.ToString = "TOTAL COST NON ADDITIONAL_add_report_column" Or data.Columns(i).ColumnName.ToString = "TOTAL AMOUNT NON ADDITIONAL_add_report_column" Or data.Columns(i).ColumnName.ToString = "TOTAL COST_add_report_column" Or data.Columns(i).ColumnName.ToString = "TOTAL AMOUNT_add_report_column" Then
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n2}"
                    item.ShowInGroupColumnFooter = BGVProduct.Columns(data.Columns(i).ColumnName.ToString)
                    BGVProduct.GroupSummary.Add(item)
                ElseIf data.Columns(i).ColumnName.ToString = "MARK UP_add_report_column" Then
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.Tag = 46
                    CType(BGVProduct.Columns(data.Columns(i).ColumnName.ToString).View, DevExpress.XtraGrid.Views.Grid.GridView).OptionsView.ShowFooter = True

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                    item.DisplayFormat = "{0:n2}"
                    item.Tag = 47
                    item.ShowInGroupColumnFooter = BGVProduct.Columns(data.Columns(i).ColumnName.ToString)
                    BGVProduct.GroupSummary.Add(item)
                Else
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
                End If
                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
            End If

            If data.Columns(i).ColumnName.ToString = "id_design_desc_report_column" _
                Or data.Columns(i).ColumnName.ToString = "id_design_desc_report_column" _
                Or data.Columns(i).ColumnName.ToString = "id_design_desc_report_column" _
                Then
                BGVProduct.Columns(data.Columns(i).ColumnName.ToString).OptionsColumn.ShowInCustomizationForm = False
            End If
        Next

        For n_brk As Integer = 0 To (break_alloc_initial.Count - 1)
            BGVProduct.Columns(break_alloc_initial(n_brk)).Dispose()
        Next
        BGVProduct.EndUpdate()
        GCProduct.DataSource = data
        band_arr.AddMyMergeBand(band_desc)
        band_arr.AddMyMergeBand(band_additional)
        Dim helper As New MyPaintHelper(BGVProduct, band_arr)


        'hide column
        BGVProduct.Bands.MoveTo(1, band_desc)
        BGVProduct.Bands.MoveTo(99, band_additional)
        BGVProduct.Columns("id_design_desc_report_column").Visible = False
        BGVProduct.Columns("id_prod_demand_design").Visible = False
        BGVProduct.Columns("SEASON ORIGIN_desc_report_column").Visible = False
        BGVProduct.Columns("STYLE COUNTRY_desc_report_column").Visible = False
        BGVProduct.Columns("PRODUCT SOURCE_desc_report_column").Visible = False


        'clear band array
        band_arr = Nothing
        band_alloc_break = Nothing
        break_alloc_initial.Clear()

        'best Fit
        BGVProduct.BestFitColumns()


        'DISPOSE
        data.Dispose()
        ' Catch ex As Exception
        'stopCustom(ex.ToString)
        'End Try
    End Sub

    Public Sub printReport(ByVal id_prod_demand As String, ByVal BGVProduct As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView, ByVal GCProduct As DevExpress.XtraGrid.GridControl)
        Try
            'Prepare Baded
            BGVProduct.Columns.Clear()
            BGVProduct.Bands.Clear()
            BGVProduct.GroupSummary.Clear()
            BGVProduct.ColumnPanelRowHeight = 40
            BGVProduct.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            BGVProduct.OptionsBehavior.AutoExpandAllGroups = True

            ' Make the group footers always visible.
            BGVProduct.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

            'prepare band
            Dim band_desc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVProduct.Bands.AddBand("")
            band_desc.AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)
            Dim band_break_total As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVProduct.Bands.AddBand("") 'diabaikan karena akan dimerge
            band_break_total.AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)
            Dim band_size As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVProduct.Bands.AddBand("TOTAL QTY BREAKDOWN SIZE")
            band_size.AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)
            Dim band_additional As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVProduct.Bands.AddBand("")
            band_additional.AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)

            'declare band for merge coluumn
            Dim band_arr() As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim band_alloc_break() As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            'declare arr to store break sizw column initial
            Dim break_alloc_initial As New List(Of String)

            'query
            Dim query As String = "CALL view_prod_demand_list('" & id_prod_demand & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            BGVProduct.BeginUpdate()

            'setup band size total
            Dim query_break_c As ClassDesign = New ClassDesign()
            Dim data_break_total As DataTable = query_break_c.getBreakTotalLineList("2")
            band_size.Columns.Add(BGVProduct.Columns.AddVisible("brk_1", ""))
            band_size.Columns.Add(BGVProduct.Columns.AddVisible("brk_2", ""))
            band_size.Columns.Add(BGVProduct.Columns.AddVisible("brk_3", ""))
            band_size.Columns.Add(BGVProduct.Columns.AddVisible("brk_4", ""))
            BGVProduct.SetColumnPosition(BGVProduct.Columns("brk_1"), 0, 0)
            BGVProduct.SetColumnPosition(BGVProduct.Columns("brk_2"), 1, 0)
            BGVProduct.SetColumnPosition(BGVProduct.Columns("brk_3"), 2, 0)
            BGVProduct.SetColumnPosition(BGVProduct.Columns("brk_4"), 3, 0)

            'setup band size alloc
            Dim query_break_alloc As ClassDesign = New ClassDesign()
            Dim data_band_alloc As DataTable = query_break_alloc.getBreakAllocLineList("1")


            'var bantu utk band dinamis
            Dim i_break As Integer = 0
            For i As Integer = 0 To data.Columns.Count - 1
                If data.Columns(i).ColumnName.ToString.Contains("_desc_report_column") Or data.Columns(i).ColumnName.ToString = "id_prod_demand_design" Or data.Columns(i).ColumnName.ToString = "id_prod_demand_design_alloc" Then
                    If data.Columns(i).ColumnName.ToString.Contains("_desc_report_column") Then
                        Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 19
                        band_desc.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                    Else
                        band_desc.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                    End If

                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
                ElseIf data.Columns(i).ColumnName.ToString.Contains("_Alloc") Then
                    i_break += 1
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("_"c)

                    Dim found_band As Boolean = False
                    For Each group As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BGVProduct.Bands
                        If group.Caption.ToString = str_arr(1).ToString Then
                            found_band = True
                            If str_arr(0).ToString = "TOTAL" Then
                                group.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(1).ToString))
                            Else
                                group.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(0).ToString))
                                'size position
                                Dim data_filterx As DataRow() = data_band_alloc.Select("[display_name]='" + data.Columns(i).ColumnName.ToString + "'")
                                BGVProduct.SetColumnPosition(BGVProduct.Columns(data.Columns(i).ColumnName.ToString), data_filterx(0)("code_row_index").ToString, data_filterx(0)("code_col_index").ToString)
                            End If
                            Exit For
                        End If
                    Next group


                    If Not found_band Then
                        If str_arr(0).ToString = "TOTAL" Then
                            Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVProduct.Bands.AddBand("")
                            band_new.AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)
                            band_new.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(1).ToString))
                            band_arr.AddMyMergeBand(band_new)
                        Else
                            Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVProduct.Bands.AddBand(str_arr(1).ToString)
                            band_new.AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)
                            band_new.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(0).ToString))
                            band_alloc_break.AddMyMergeBand(band_new)

                            'initial to breakdown size
                            Dim band_dyn_name As String = "brk" + i_break.ToString + "_"
                            band_new.Columns.Add(BGVProduct.Columns.AddVisible(band_dyn_name + "1", ""))
                            band_new.Columns.Add(BGVProduct.Columns.AddVisible(band_dyn_name + "2", ""))
                            band_new.Columns.Add(BGVProduct.Columns.AddVisible(band_dyn_name + "3", ""))
                            band_new.Columns.Add(BGVProduct.Columns.AddVisible(band_dyn_name + "4", ""))
                            BGVProduct.SetColumnPosition(BGVProduct.Columns(band_dyn_name + "1"), 0, 0)
                            BGVProduct.SetColumnPosition(BGVProduct.Columns(band_dyn_name + "2"), 1, 0)
                            BGVProduct.SetColumnPosition(BGVProduct.Columns(band_dyn_name + "3"), 2, 0)
                            BGVProduct.SetColumnPosition(BGVProduct.Columns(band_dyn_name + "4"), 3, 0)
                            break_alloc_initial.Add(band_dyn_name + "1")
                            break_alloc_initial.Add(band_dyn_name + "2")
                            break_alloc_initial.Add(band_dyn_name + "3")
                            break_alloc_initial.Add(band_dyn_name + "4")

                            'size position
                            Dim data_filterx As DataRow() = data_band_alloc.Select("[display_name]='" + data.Columns(i).ColumnName.ToString + "'")
                            BGVProduct.SetColumnPosition(BGVProduct.Columns(data.Columns(i).ColumnName.ToString), data_filterx(0)("code_row_index").ToString, data_filterx(0)("code_col_index").ToString)
                        End If
                    End If

                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)

                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n2}"
                    item.ShowInGroupColumnFooter = BGVProduct.Columns(data.Columns(i).ColumnName.ToString)
                    BGVProduct.GroupSummary.Add(item)
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
                ElseIf data.Columns(i).ColumnName.ToString.Contains("_size") Then
                    Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 5
                    If data.Columns(i).ColumnName.ToString = "TOTAL QTY_size" Then
                        band_break_total.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                    Else
                        band_size.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                        'size position
                        Dim data_filter As DataRow() = data_break_total.Select("[display_name]='" + data.Columns(i).ColumnName.ToString + "'")
                        BGVProduct.SetColumnPosition(BGVProduct.Columns(data.Columns(i).ColumnName.ToString), data_filter(0)("code_row_index").ToString, data_filter(0)("code_col_index").ToString)
                    End If


                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)

                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n2}"
                    item.ShowInGroupColumnFooter = BGVProduct.Columns(data.Columns(i).ColumnName.ToString)
                    BGVProduct.GroupSummary.Add(item)
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
                ElseIf data.Columns(i).ColumnName.ToString.Contains("_add_report_column") Then
                    Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 18
                    band_additional.Columns.Add(BGVProduct.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))

                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVProduct.Appearance.Row.Font.FontFamily, BGVProduct.Appearance.Row.Font.Size, FontStyle.Bold)

                    If data.Columns(i).ColumnName.ToString = "TOTAL COST NON ADDITIONAL_add_report_column" Or data.Columns(i).ColumnName.ToString = "TOTAL AMOUNT NON ADDITIONAL_add_report_column" Or data.Columns(i).ColumnName.ToString = "TOTAL COST_add_report_column" Or data.Columns(i).ColumnName.ToString = "TOTAL AMOUNT_add_report_column" Then
                        BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                        BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                        item.FieldName = data.Columns(i).ColumnName.ToString
                        item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        item.DisplayFormat = "{0:n2}"
                        item.ShowInGroupColumnFooter = BGVProduct.Columns(data.Columns(i).ColumnName.ToString)
                        BGVProduct.GroupSummary.Add(item)
                    ElseIf data.Columns(i).ColumnName.ToString = "MARK UP_add_report_column" Then
                        BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                        BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                        BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"
                        BGVProduct.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.Tag = 46
                        CType(BGVProduct.Columns(data.Columns(i).ColumnName.ToString).View, DevExpress.XtraGrid.Views.Grid.GridView).OptionsView.ShowFooter = True

                        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                        item.FieldName = data.Columns(i).ColumnName.ToString
                        item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                        item.DisplayFormat = "{0:n2}"
                        item.Tag = 47
                        item.ShowInGroupColumnFooter = BGVProduct.Columns(data.Columns(i).ColumnName.ToString)
                        BGVProduct.GroupSummary.Add(item)
                    Else
                        BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        BGVProduct.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
                    End If
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
                End If

                If data.Columns(i).ColumnName.ToString = "id_design_desc_report_column" _
                Or data.Columns(i).ColumnName.ToString = "id_design_desc_report_column" _
                Or data.Columns(i).ColumnName.ToString = "id_design_desc_report_column" _
                Then
                    BGVProduct.Columns(data.Columns(i).ColumnName.ToString).OptionsColumn.ShowInCustomizationForm = False
                End If
            Next
            BGVProduct.Columns("brk_1").Dispose()
            BGVProduct.Columns("brk_2").Dispose()
            BGVProduct.Columns("brk_3").Dispose()
            BGVProduct.Columns("brk_4").Dispose()
            For n_brk As Integer = 0 To (break_alloc_initial.Count - 1)
                BGVProduct.Columns(break_alloc_initial(n_brk)).Dispose()
            Next
            BGVProduct.EndUpdate()
            GCProduct.DataSource = data
            band_arr.AddMyMergeBand(band_desc)
            band_arr.AddMyMergeBand(band_additional)
            band_arr.AddMyMergeBand(band_break_total)
            Dim helper As New MyPaintHelper(BGVProduct, band_arr)


            'hide band
            band_size.Visible = False
            For j As Integer = 0 To band_alloc_break.Length - 1
                band_alloc_break(j).Visible = False
            Next

            'hide column
            BGVProduct.Bands.MoveTo(1, band_desc)
            BGVProduct.Bands.MoveTo(98, band_break_total)
            BGVProduct.Bands.MoveTo(99, band_additional)
            BGVProduct.Columns("id_design_desc_report_column").Visible = False
            BGVProduct.Columns("id_prod_demand_design").Visible = False
            BGVProduct.Columns("id_prod_demand_design_alloc").Visible = False
            BGVProduct.Columns("SEASON ORIGIN_desc_report_column").Visible = False
            BGVProduct.Columns("STYLE COUNTRY_desc_report_column").Visible = False
            BGVProduct.Columns("PRODUCT SOURCE_desc_report_column").Visible = False


            'clear band array
            band_arr = Nothing
            band_alloc_break = Nothing
            break_alloc_initial.Clear()

            'best Fit
            BGVProduct.BestFitColumns()


            'DISPOSE
            data.Dispose()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Public Function queryMainRev(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT r.id_prod_demand_rev, r.id_prod_demand, pd.prod_demand_number, pd.id_pd_kind, r.rev_count, r.id_report_status, stt.report_status, r.created_date, r.note, r.is_confirm
        FROM tb_prod_demand_rev r
        INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = r.id_prod_demand
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status
        WHERE r.id_prod_demand_rev>0 "
        query += condition + " "
        query += "GROUP BY r.id_prod_demand_rev "
        query += "ORDER BY r.id_prod_demand_rev " + order_type
        Return query
    End Function
End Class
