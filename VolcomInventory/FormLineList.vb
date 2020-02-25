Public Class FormLineList
    Public show_spesific_col As Boolean = False
    Dim dtsize As New DataTable
    Dim dt As New DataTable
    Public id_menu As String = "-1"
    Dim is_dept As String = "-1"
    Dim str As System.IO.Stream

    Private Sub FormLineList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()

        'col
        Dim qry As String = "SELECT * FROM tb_col_line_list l "
        dt = execute_query(qry, -1, True, "", "", "", "")
        If id_menu = "1" Then
            is_dept = "is_mkt"
        ElseIf id_menu = "2" Then
            is_dept = "is_retail"
        ElseIf id_menu = "3" Then
            is_dept = "is_vm"
        Else
            is_dept = "is_md"
        End If
        If show_spesific_col Then
            For j As Integer = 0 To dt.Rows.Count - 1
                Dim col_name As String = dt.Rows(j)("fieldname").ToString
                Dim is_mkt As String = dt.Rows(j)(is_dept).ToString
                If is_mkt = "2" Then
                    Try
                        GVData.Columns(col_name).Visible = False
                        GVData.Columns(col_name).OptionsColumn.ShowInCustomizationForm = False
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If

        'copy stream
        str = New System.IO.MemoryStream()
        GVData.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
    End Sub

    Private Sub FormLineList_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormLineList_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    'view season
    Sub viewSeason()
        Dim query As String = "SELECT * FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "WHERE b.id_range >0 "
        query += "AND b.is_md='1' "
        query += "ORDER BY b.range DESC"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Sub setPropertiesBZColumn(ByVal col_name As String, ByVal field_name As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn)
        'display format
        field_name.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        field_name.DisplayFormat.FormatString = "{0:N0}"
        'summary
        field_name.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        field_name.SummaryItem.DisplayFormat = "{0:N0}"
        'grup summary
        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
        item.FieldName = col_name
        item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item.DisplayFormat = "{0:n0}"
        item.ShowInGroupColumnFooter = GVData.Columns(col_name)
        GVData.GroupSummary.Add(item)
        'custom
        GVData.Columns(col_name).OptionsColumn.ShowInCustomizationForm = True
    End Sub

    Sub viewData()
        FormMain.SplashScreenManager1.ShowWaitForm()

        'fill col
        'For i As Integer = 0 To GVData.Columns.Count - 1
        '    If GVData.Columns(i).Visible = True And GVData.Columns(i).FieldName.Contains("#bz#") Then
        '        Dim querycol As String = "INSERT INTO tb_col_line_list(fieldname, is_md, is_mkt) VALUES('" + addSlashes(GVData.Columns(i).FieldName.ToString) + "',1,2); "
        '        execute_non_query(querycol, True, "", "", "", "")
        '    End If
        'Next

        ' show breakdown size
        Dim break_size As String = ""
        If CEBreakSize.EditValue = True Then
            break_size = "1"
        Else
            break_size = "2"
        End If

        Dim id_ss As String = SLESeason.EditValue.ToString
        Dim query As String = "CALL view_line_list_all_new_bz(" + id_ss + "," + break_size + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data

        ' show caption breakdown size
        'GVData.BeginUpdate()
        If CEBreakSize.EditValue = True Then
            'header heigt
            GVData.ColumnPanelRowHeight = 100

            'set size
            break_size = "1"

            'get caption
            makeSafeGV(GVData)
            GVData.ActiveFilterString = "[id_prod_demand]>0"
            Dim id_pd As String = ""
            For g As Integer = 0 To GVData.RowCount - 1
                If g > 0 Then
                    id_pd += ","
                End If
                id_pd += GVData.GetRowCellValue(g, "id_prod_demand").ToString
            Next
            GVData.ActiveFilterString = ""

            'set breakdown size
            If id_pd <> "" Then
                Dim query_caption As String = " SELECT cd.index_size,CONCAT('qty',cd.index_size) AS `col`,GROUP_CONCAT(DISTINCT cd.code_detail_name ORDER BY cd.code_detail_name ASC SEPARATOR '\n') AS `caption` FROM tb_m_code_detail cd
                WHERE cd.id_code='33'
                AND cd.`index_size` IN (
                    SELECT cd.`index_size` FROM tb_prod_demand_design pdd 
                    INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_design =  pdd.id_prod_demand_design
                    INNER JOIN tb_m_product p ON p.id_product = pdp.id_product
                    INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
                    INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
                    WHERE pdd.id_prod_demand IN(" + id_pd + ") AND pdp.prod_demand_product_qty>0
                    GROUP BY cd.`index_size`
                )
                AND cd.`size_type` IN (
                    SELECT cd.`size_type` FROM tb_prod_demand_design pdd 
                    INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_design =  pdd.id_prod_demand_design
                    INNER JOIN tb_m_product p ON p.id_product = pdp.id_product
                    INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
                    INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
                    WHERE pdd.id_prod_demand IN(" + id_pd + ") AND pdp.prod_demand_product_qty>0
                    GROUP BY cd.`size_type`
                )
                GROUP BY cd.index_size "
                dtsize = execute_query(query_caption, -1, True, "", "", "", "")

                Dim last_ttl As String = ""
                Dim ix As Integer = 0
                Dim last_ttl_actual As String = ""
                Dim ix_actual As Integer = 0
                For j As Integer = 0 To GVData.Columns.Count - 1
                    Dim col_name As String = GVData.Columns(j).FieldName.ToString

                    'check  allow column
                    Dim dtcol_filter As DataRow() = dt.Select("[fieldname]='" + col_name + "' AND [" + is_dept + "]=1 ")

                    'bz
                    If col_name.Contains("#bz#") And dtcol_filter.Length > 0 Then
                        'explodde column
                        Dim col_arr As String() = Split(col_name, "#bz#")
                        Dim col_ttl As String = col_arr(0)
                        Dim col_size As String = "qty" + col_arr(1).ToString

                        'viisible index
                        If last_ttl <> col_ttl Then
                            If last_ttl <> "" Then
                                gridBandPD.Columns.MoveTo(ix, GVData.Columns(last_ttl))
                                ix += 1
                            End If
                            last_ttl = col_ttl
                        End If
                        gridBandPD.Columns.Add(GVData.Columns.AddVisible(col_name))
                        gridBandPD.Columns.MoveTo(ix, GVData.Columns(col_name))

                        'caption
                        Dim dtsize_filter As DataRow() = dtsize.Select("[col]='" + col_size + "' ")
                        If dtsize_filter.Length > 0 Then
                            GVData.Columns(col_name).Caption = dtsize_filter(0)("caption").ToString
                        End If
                        'set properti
                        setPropertiesBZColumn(col_name, GVData.Columns(col_name))
                        'jika 0 divisible
                        If GVData.Columns(col_name).SummaryItem.SummaryValue = 0 Then
                            GVData.Columns(col_name).Visible = False
                        End If

                        ix += 1
                    ElseIf col_name.Contains("#abz#") And dtcol_filter.Length > 0 Then
                        'explodde column
                        Dim col_arr As String() = Split(col_name, "#abz#")
                        Dim col_ttl_actual As String = col_arr(0)
                        Dim col_size As String = "qty" + col_arr(1).ToString

                        'viisible index
                        If last_ttl_actual <> col_ttl_actual Then
                            If last_ttl_actual <> "" Then
                                gridBandActual.Columns.MoveTo(ix_actual, GVData.Columns(last_ttl_actual))
                                ix_actual += 1
                            End If
                            last_ttl_actual = col_ttl_actual
                        End If
                        gridBandActual.Columns.Add(GVData.Columns.AddVisible(col_name))
                        gridBandActual.Columns.MoveTo(ix_actual, GVData.Columns(col_name))

                        'caption
                        Dim dtsize_filter As DataRow() = dtsize.Select("[col]='" + col_size + "' ")
                        If dtsize_filter.Length > 0 Then
                            GVData.Columns(col_name).Caption = dtsize_filter(0)("caption").ToString
                        End If
                        'set properti
                        setPropertiesBZColumn(col_name, GVData.Columns(col_name))
                        'jika 0 divisible
                        If GVData.Columns(col_name).SummaryItem.SummaryValue = 0 Then
                            GVData.Columns(col_name).Visible = False
                        End If

                        ix_actual += 1
                    End If
                Next
                If last_ttl <> "" Then
                    gridBandPD.Columns.MoveTo(ix, GVData.Columns(last_ttl))
                End If
                If last_ttl_actual <> "" Then
                    gridBandActual.Columns.MoveTo(ix_actual, GVData.Columns(last_ttl_actual))
                End If
            End If
        Else
            'header heigt
            GVData.ColumnPanelRowHeight = 35

            'set size
            break_size = "2"
            hideColBreakSize()
        End If
        'GVData.EndUpdate()

        FormMain.SplashScreenManager1.CloseWaitForm()
    End Sub

    Sub hideColBreakSize()
        For k As Integer = 1 To 10
            Dim col_mkt As String = "pd_qty_mkt#bz#" + k.ToString
            Dim col_buff As String = "pd_qty_buff#bz#" + k.ToString
            Dim col_core As String = "pd_qty_core#bz#" + k.ToString
            Dim col_dev As String = "pd_qty_dev#bz#" + k.ToString
            Dim col_act_order_sales As String = "pd_qty_act_order_sales#bz#" + k.ToString
            Dim col_ttl As String = "pd_qty_ttl#bz#" + k.ToString

            'visible
            GVData.Columns(col_mkt).Visible = False
            GVData.Columns(col_buff).Visible = False
            GVData.Columns(col_core).Visible = False
            GVData.Columns(col_dev).Visible = False
            GVData.Columns(col_act_order_sales).Visible = False
            GVData.Columns(col_ttl).Visible = False

            'show custom colown
            GVData.Columns(col_mkt).OptionsColumn.ShowInCustomizationForm = False
            GVData.Columns(col_buff).OptionsColumn.ShowInCustomizationForm = False
            GVData.Columns(col_core).OptionsColumn.ShowInCustomizationForm = False
            GVData.Columns(col_dev).OptionsColumn.ShowInCustomizationForm = False
            GVData.Columns(col_act_order_sales).OptionsColumn.ShowInCustomizationForm = False
            GVData.Columns(col_ttl).OptionsColumn.ShowInCustomizationForm = False
        Next
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            If view.GroupedColumns.Count <> 0 AndAlso Not e.IsForGroupRow Then
                Dim rowHandle As Integer = view.GetRowHandle(e.ListSourceRowIndex)
                e.DisplayText = (view.GetRowGroupIndexByRowHandle(rowHandle) + 1).ToString()
            Else
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
            End If
        End If
    End Sub

    Private ImageDir As String = product_image_path
    Private Images As Hashtable = New Hashtable()
    Private Sub GVData_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVData.CustomUnboundColumnData
        If e.Column.FieldName = "img" AndAlso e.IsGetData And CheckImg.EditValue.ToString = "True" Then
            Images = Nothing
            Images = New Hashtable()
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim id As String = CStr(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "id_design"))

            Dim fileName As String = id & ".jpg".ToLower

            If (Not Images.ContainsKey(fileName)) Then
                Dim img As Image = Nothing
                Dim resizeImg As Image = Nothing

                Try

                    Dim filePath As String = DevExpress.Utils.FilesHelper.FindingFileName(ImageDir, fileName, False)
                    img = Image.FromFile(filePath)
                    resizeImg = img.GetThumbnailImage(100, 100, Nothing, Nothing)
                Catch

                End Try

                Images.Add(fileName, resizeImg)

            End If

            e.Value = Images(fileName)
        End If
    End Sub

    Private Sub CheckImg_CheckedChanged(sender As Object, e As EventArgs) Handles CheckImg.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim val As String = CheckImg.EditValue.ToString
        If val = "True" Then
            BandedGridColumnImg.Visible = True
            BandedGridColumnImg.VisibleIndex = 1
        Else
            BandedGridColumnImg.Visible = False
        End If
        GCData.RefreshDataSource()
        GVData.RefreshData()
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckEditFreeze_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditFreeze.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim val As String = CheckEditFreeze.EditValue.ToString
        If val = "True" Then
            GridBandFreeze.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Else
            GridBandFreeze.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub RepoLinkProdDemand_Click(sender As Object, e As EventArgs) Handles RepoLinkProdDemand.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_prod_demand As String = "-1"
            Try
                id_prod_demand = GVData.GetFocusedRowCellValue("id_prod_demand").ToString
            Catch ex As Exception
            End Try
            If id_prod_demand = "" Or id_prod_demand = "0" Or id_prod_demand = "-1" Then
                stopCustom("Document not found")
                Cursor = Cursors.Default
                Exit Sub
            End If
            FormViewProdDemand.id_prod_demand = id_prod_demand
            FormViewProdDemand.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoLinkPP_Click(sender As Object, e As EventArgs) Handles RepoLinkPP.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_pp As String = "-1"
            Try
                id_pp = GVData.GetFocusedRowCellValue("id_fg_propose_price").ToString
            Catch ex As Exception
            End Try
            If id_pp = "" Or id_pp = "0" Or id_pp = "-1" Then
                stopCustom("Document not found")
                Cursor = Cursors.Default
                Exit Sub
            End If
            Dim sm As New ClassShowPopUp()
            sm.report_mark_type = "70"
            sm.id_report = id_pp
            sm.show()
            Cursor = Cursors.Default
        End If
    End Sub

    'for estimate
    Dim tot_cost_est As Decimal
    Dim tot_prc_est As Decimal
    Dim tot_cost_grp_est As Decimal
    Dim tot_prc_grp_est As Decimal
    'for actual
    Dim tot_cost_actual As Decimal
    Dim tot_prc_actual As Decimal
    Dim tot_cost_grp_actual As Decimal
    Dim tot_prc_grp_actual As Decimal
    Private Sub GVData_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVData.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            tot_cost_est = 0.0
            tot_prc_est = 0.0
            tot_cost_grp_est = 0.0
            tot_prc_grp_est = 0.0
            'act
            tot_cost_actual = 0.0
            tot_prc_actual = 0.0
            tot_cost_grp_actual = 0.0
            tot_prc_grp_actual = 0.0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_cost_estimate_min_additional").ToString, "0.00"))
            Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_amount_estimate_min_additional"), "0.00"))
            Dim cost_actual As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_cost_min_additional").ToString, "0.00"))
            Dim prc_actual As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_amount_min_additional"), "0.00"))
            Select Case summaryID
                Case 1
                    tot_cost_est += cost
                    tot_prc_est += prc
                Case 2
                    tot_cost_grp_est += cost
                    tot_prc_grp_est += prc
                Case 3
                    tot_cost_actual += cost_actual
                    tot_prc_actual += prc_actual
                Case 4
                    tot_cost_grp_actual += cost_actual
                    tot_prc_grp_actual += prc_actual
            End Select
        End If

        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case 1 'total summary estimate
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc_est / tot_cost_est
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case 2 'group summary estimate
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc_grp_est / tot_cost_grp_est
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case 3 'total summary actual
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc_actual / tot_cost_actual
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case 4 'group summary actual
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc_grp_actual / tot_cost_grp_actual
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
            End Select
        End If
    End Sub

    Private Sub BtnExportToXLSRec_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSRec.Click
        If GVData.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            'column option creating and saving the view's layout to a new memory stream 
            'Dim str As System.IO.Stream
            'str = New System.IO.MemoryStream()
            'GVData.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            'str.Seek(0, System.IO.SeekOrigin.Begin)
            'For i As Integer = 0 To GVData.Columns.Count - 1
            '    If GVData.Columns(i).OwnerBand.ToString = "SALES" Or GVData.Columns(i).OwnerBand.ToString = "STOCK ON HAND" Then
            '        GVData.Columns(i).Caption = GVData.Columns(i).FieldName.ToString
            '    End If
            'Next

            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "line_list_" + SLESeason.Text.ToString + ".xlsx"
            exportToXLS(path, "line_list_" + SLESeason.Text.ToString + "", GCData)

            'restore column opt
            'GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            'Str.Seek(0, System.IO.SeekOrigin.Begin)
            Cursor = Cursors.Default
        End If
    End Sub

    Sub exportToXLS(ByVal path_par As String, ByVal sheet_name_par As String, ByVal gc_par As DevExpress.XtraGrid.GridControl)
        Cursor = Cursors.WaitCursor
        Dim path As String = path_par

        ' Customize export options 
        CType(gc_par.MainView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsPrint.PrintHeader = True
        CType(gc_par.MainView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsPrint.AllowMultilineHeaders = True
        Dim advOptions As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
        advOptions.AllowSortingAndFiltering = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowGridLines = DevExpress.Utils.DefaultBoolean.False
        advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False
        advOptions.SheetName = sheet_name_par
        advOptions.ExportType = DevExpress.Export.ExportType.WYSIWYG

        Try
            gc_par.ExportToXlsx(path, advOptions)
            Process.Start(path)
            ' Open the created XLSX file with the default application. 
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub SLESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLESeason.EditValueChanged
        resetview()
    End Sub

    Sub resetview()
        GCData.DataSource = Nothing
        hideColBreakSize()

        'restore column opt
        Try
            GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CEBreakSize_EditValueChanged(sender As Object, e As EventArgs) Handles CEBreakSize.EditValueChanged
        resetview()
    End Sub
End Class