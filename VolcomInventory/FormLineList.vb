Public Class FormLineList
    Public show_spesific_col As Boolean = False

    Private Sub FormLineList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()

        'fill col
        'For i As Integer = 0 To GVData.Columns.Count - 1
        '    If GVData.Columns(i).Visible = True Then
        '        Dim query As String = "INSERT INTO tb_col_line_list(fieldname, is_md, is_mkt) VALUES('" + addSlashes(GVData.Columns(i).FieldName.ToString) + "',1,2); "
        '        execute_non_query(query, True, "", "", "", "")
        '    End If
        'Next
        If show_spesific_col Then
            Dim qry As String = "SELECT * FROM tb_col_line_list l "
            Dim dt As DataTable = execute_query(qry, -1, True, "", "", "", "")
            For j As Integer = 0 To dt.Rows.Count - 1
                Dim col_name As String = dt.Rows(j)("fieldname").ToString
                Dim is_mkt As String = dt.Rows(j)("is_mkt").ToString
                If is_mkt = "2" Then
                    Try
                        GVData.Columns(col_name).Visible = False
                        GVData.Columns(col_name).OptionsColumn.ShowInCustomizationForm = False
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If
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

    Sub viewData()
        FormMain.SplashScreenManager1.ShowWaitForm()
        Dim id_ss As String = SLESeason.EditValue.ToString
        Dim query As String = "CALL view_line_list_all_new(" + id_ss + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        FormMain.SplashScreenManager1.CloseWaitForm()
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
End Class