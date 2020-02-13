Public Class FormSalesInv
    Public id_design_per_outlet As String = "-1"

    Private Sub FormSalesInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`, LAST_DAY(DATE(NOW())) AS `last_date` ", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        DEUntil.Properties.MaxValue = data_dt.Rows(0)("last_date")
        DEFromAcc.EditValue = data_dt.Rows(0)("dt")
        DEUntilAcc.EditValue = data_dt.Rows(0)("dt")
        DEUntilAcc.Properties.MaxValue = data_dt.Rows(0)("last_date")

        loadComp()
        loadFilterOpt()
        loadFilterOptAcc()
        viewPeriodType()
        viewDisplay()
        showCaptionSize()
        LEFilterOptAcc.EditValue = "0"
    End Sub

    Private Sub FormSalesInv_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormSalesInv_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub showCaptionSize()
        '-----by product
        setCaptionSize(GVByProduct)
        '------ by account
        setCaptionSize(GVByAccount)
    End Sub

    Sub setCaptionSize(ByVal gv As DevExpress.XtraGrid.Views.Grid.GridView)
        'sal
        gv.Columns("sal_qty1").Caption = "1" + System.Environment.NewLine + "XXS"
        gv.Columns("sal_qty2").Caption = "2" + System.Environment.NewLine + "XS"
        gv.Columns("sal_qty3").Caption = "3" + System.Environment.NewLine + "S"
        gv.Columns("sal_qty4").Caption = "4" + System.Environment.NewLine + "M"
        gv.Columns("sal_qty5").Caption = "5" + System.Environment.NewLine + "ML"
        gv.Columns("sal_qty6").Caption = "6" + System.Environment.NewLine + "L"
        gv.Columns("sal_qty7").Caption = "7" + System.Environment.NewLine + "XL"
        gv.Columns("sal_qty8").Caption = "8" + System.Environment.NewLine + "XXL"
        gv.Columns("sal_qty9").Caption = "9" + System.Environment.NewLine + "ALL"
        gv.Columns("sal_qty0").Caption = "0" + System.Environment.NewLine + "SM"
        'soh
        gv.Columns("inv_qty1").Caption = "1" + System.Environment.NewLine + "XXS"
        gv.Columns("inv_qty2").Caption = "2" + System.Environment.NewLine + "XS"
        gv.Columns("inv_qty3").Caption = "3" + System.Environment.NewLine + "S"
        gv.Columns("inv_qty4").Caption = "4" + System.Environment.NewLine + "M"
        gv.Columns("inv_qty5").Caption = "5" + System.Environment.NewLine + "ML"
        gv.Columns("inv_qty6").Caption = "6" + System.Environment.NewLine + "L"
        gv.Columns("inv_qty7").Caption = "7" + System.Environment.NewLine + "XL"
        gv.Columns("inv_qty8").Caption = "8" + System.Environment.NewLine + "XXL"
        gv.Columns("inv_qty9").Caption = "9" + System.Environment.NewLine + "ALL"
        gv.Columns("inv_qty0").Caption = "0" + System.Environment.NewLine + "SM"
    End Sub

    Sub loadComp()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT '0' AS `id_comp`, 'All Account' AS `comp_name`, 0 AS `id_comp_cat`
        UNION
        SELECT c.id_comp,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name, c.id_comp_cat
        FROM tb_m_comp c
        WHERE (c.id_comp_cat='5' OR c.id_comp_cat='6') "
        viewSearchLookupQuery(SLEComp, query, "id_comp", "comp_name", "id_comp")
        viewSearchLookupQuery(SLEAccount, query, "id_comp", "comp_name", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Sub loadFilterOpt()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_filter_opt`, 'No Filter' AS `filter_opt`
        UNION
        SELECT 1 AS `id_filter_opt`, 'Class' AS `filter_opt`
        UNION
        SELECT 2 AS `id_filter_opt`, 'Category' AS `filter_opt`
        UNION
        SELECT 3 AS `id_filter_opt`, 'Sub Category' AS `filter_opt`
        UNION
        SELECT 4 AS `id_filter_opt`, 'Status Product' AS `filter_opt` "
        viewLookupQuery(LEFilterOpt, query, 0, "filter_opt", "id_filter_opt")
        Cursor = Cursors.Default
    End Sub

    Sub loadFilterOptAcc()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_filter_opt`, 'No Filter' AS `filter_opt`
        UNION
        SELECT 1 AS `id_filter_opt`, 'Class' AS `filter_opt`
        UNION
        SELECT 2 AS `id_filter_opt`, 'Category' AS `filter_opt`
        UNION
        SELECT 3 AS `id_filter_opt`, 'Sub Category' AS `filter_opt`
        UNION
        SELECT 4 AS `id_filter_opt`, 'Status Product' AS `filter_opt` 
        UNION
        SELECT 5 AS `id_filter_opt`, 'Season' AS `filter_opt`"
        viewLookupQuery(LEFilterOptAcc, query, 0, "filter_opt", "id_filter_opt")
        Cursor = Cursors.Default
    End Sub

    Sub loadSubFilter()
        Cursor = Cursors.WaitCursor
        Dim id_filter_opt As String = "1"
        Try
            id_filter_opt = myCoalesce(LEFilterOpt.EditValue.ToString, "1")
        Catch ex As Exception
        End Try

        Dim query As String = ""
        Select Case id_filter_opt
            Case 1
                query = "SELECT cd.id_code_detail AS `id_sub_filter`, cd.code_detail_name AS `sub_filter`, cd.display_name AS `sub_filter_display` 
                FROM tb_m_code_detail cd 
                WHERE cd.id_code IN (SELECT o.id_code_fg_class FROM tb_opt o) "
            Case 2
                query = "SELECT cd.id_code_detail AS `id_sub_filter`, cd.display_name AS `sub_filter`, cd.display_name AS `sub_filter_display` 
                FROM tb_m_code_detail cd 
                WHERE cd.id_code IN (SELECT o.id_code_fg_cat FROM tb_opt o)
                GROUP BY cd.display_name "
            Case 3
                query = "SELECT cd.id_code_detail AS `id_sub_filter`, cd.code_detail_name AS `sub_filter`, cd.display_name AS `sub_filter_display` 
                FROM tb_m_code_detail cd 
                WHERE cd.id_code IN (SELECT o.id_code_fg_subcat FROM tb_opt o) "
            Case 4
                query = "SELECT cd.id_design_cat AS `id_sub_filter`, cd.design_cat AS `sub_filter`, cd.design_cat AS `sub_filter_display` 
                FROM tb_lookup_design_cat cd "
            Case Else
                query = "SELECT 1 AS `id_sub_filter`, '-' AS `sub_filter`,  '-' AS `sub_filter_display` "
        End Select
        viewSearchLookupQuery(SLESubFilter, query, "id_sub_filter", "sub_filter_display", "id_sub_filter")
        Cursor = Cursors.Default
    End Sub

    Sub loadSubFilterAcc()
        Cursor = Cursors.WaitCursor
        Dim id_filter_opt As String = "1"
        Try
            id_filter_opt = myCoalesce(LEFilterOptAcc.EditValue.ToString, "1")
        Catch ex As Exception
        End Try

        Dim query As String = ""
        Select Case id_filter_opt
            Case 1
                query = "SELECT cd.id_code_detail AS `id_sub_filter`, cd.code_detail_name AS `sub_filter`, cd.display_name AS `sub_filter_display` 
                FROM tb_m_code_detail cd 
                WHERE cd.id_code IN (SELECT o.id_code_fg_class FROM tb_opt o) "
            Case 2
                query = "SELECT cd.id_code_detail AS `id_sub_filter`, cd.display_name AS `sub_filter`, cd.display_name AS `sub_filter_display` 
                FROM tb_m_code_detail cd 
                WHERE cd.id_code IN (SELECT o.id_code_fg_cat FROM tb_opt o)
                GROUP BY cd.display_name "
            Case 3
                query = "SELECT cd.id_code_detail AS `id_sub_filter`, cd.code_detail_name AS `sub_filter`, cd.display_name AS `sub_filter_display` 
                FROM tb_m_code_detail cd 
                WHERE cd.id_code IN (SELECT o.id_code_fg_subcat FROM tb_opt o) "
            Case 4
                query = "SELECT cd.id_design_cat AS `id_sub_filter`, cd.design_cat AS `sub_filter`, cd.design_cat AS `sub_filter_display` 
                FROM tb_lookup_design_cat cd "
            Case 5
                query = "SELECT cd.id_season AS `id_sub_filter`, cd.season AS `sub_filter`, CONCAT(r.`range`,' | ', cd.season_printed_name) AS `sub_filter_display` 
                FROM tb_season cd 
                INNER JOIN tb_range r ON r.id_range = cd.id_range "
            Case Else
                query = "SELECT 1 AS `id_sub_filter`, '-' AS `sub_filter`,  '-' AS `sub_filter_display` "
        End Select
        viewSearchLookupQuery(SLESubFilterAcc, query, "id_sub_filter", "sub_filter_display", "id_sub_filter")
        Cursor = Cursors.Default
    End Sub

    Sub viewPeriodType()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT '1' AS `id_period_type`,'Sales Date' AS `period_type`
        UNION
        SELECT '2' AS `id_period_type`,'Entry Date' AS `period_type` "
        viewSearchLookupQuery(SLEPeriodType, query, "id_period_type", "period_type", "id_period_type")
        viewSearchLookupQuery(SLEPeriodTypeAcc, query, "id_period_type", "period_type", "id_period_type")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnExportToXLSRec_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSRec.Click
        If GVByProduct.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            'column option creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVByProduct.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            For i As Integer = 0 To GVByProduct.Columns.Count - 1
                If GVByProduct.Columns(i).OwnerBand.ToString = "SALES" Or GVByProduct.Columns(i).OwnerBand.ToString = "STOCK ON HAND" Then
                    GVByProduct.Columns(i).Caption = GVByProduct.Columns(i).FieldName.ToString
                End If
            Next

            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "sales_inv_by_product.xlsx"
            exportToXLS(path, "sales inventory by product", GCByProduct)

            'restore column opt
            GVByProduct.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
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
        advOptions.ExportType = DevExpress.Export.ExportType.DataAware

        Try
            gc_par.ExportToXlsx(path, advOptions)
            Process.Start(path)
            ' Open the created XLSX file with the default application. 
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub LEFilterOpt_EditValueChanged(sender As Object, e As EventArgs) Handles LEFilterOpt.EditValueChanged
        loadSubFilter()
        GCByProduct.DataSource = Nothing
    End Sub

    Sub viewDisplay()
        Cursor = Cursors.Default
        Dim query As String = "SELECT 1 AS `id_display`, 'All' AS `display`
        UNION
        SELECT 2 AS `id_display`, 'Sales Only' AS `display` "
        viewLookupQuery(LEDisplay, query, 0, "display", "id_display")
        viewLookupQuery(LEDisplayAcc, query, 0, "display", "id_display")
        LEDisplayAcc.EditValue = "2"
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewByProduct()
    End Sub

    Sub viewByProduct()
        Cursor = Cursors.WaitCursor
        FormMain.SplashScreenManager1.ShowWaitForm()

        'Prepare paramater date
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'other
        Dim id_comp As String = SLEComp.EditValue.ToString
        Dim id_period_type As String = SLEPeriodType.EditValue.ToString
        Dim is_with_sizetype_param As String = ""
        If CESizetyp.EditValue = True Then
            is_with_sizetype_param = "1"
        Else
            is_with_sizetype_param = "2"
        End If

        'display
        Dim opt_display_param As String = LEDisplay.EditValue.ToString
        If opt_display_param = "1" Then
            gridBandSOH.Visible = True
        Else
            gridBandSOH.Visible = False
        End If

        'where string
        Dim where_param As String = ""
        Dim id_filter_opt As String = LEFilterOpt.EditValue.ToString
        Dim id_sub_filter As String = SLESubFilter.EditValue.ToString
        Select Case id_filter_opt
            Case 1
                where_param = "AND cls.id_class=" + id_sub_filter + " "
            Case 2
                where_param = "AND kat.kat=''" + SLESubFilter.Text.ToString + "'' "
            Case 3
                where_param = "AND subkat.id_subkat=" + id_sub_filter + " "
            Case 4
                where_param = "AND prc.id_design_cat=" + id_sub_filter + " "
            Case Else
                where_param = ""
        End Select

        'excecute
        Dim query As String = "CALL view_sales_inv('" + date_from_selected + "', '" + date_until_selected + "', '" + id_comp + "', '" + id_period_type + "', '" + is_with_sizetype_param + "', '" + opt_display_param + "', '" + where_param + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCByProduct.DataSource = data
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnHideFilter_Click(sender As Object, e As EventArgs) Handles BtnHideFilter.Click
        PanelControlViewByProduct.Visible = False
        BtnShowFilter.Visible = True
    End Sub

    Private Sub BtnShowFilter_Click(sender As Object, e As EventArgs) Handles BtnShowFilter.Click
        PanelControlViewByProduct.Visible = True
        BtnShowFilter.Visible = False
    End Sub

    Private Sub CESizetyp_CheckedChanged(sender As Object, e As EventArgs) Handles CESizetyp.CheckedChanged
        If CESizetyp.EditValue = True Then
            BandedGridColumnsize_type.VisibleIndex = BandedGridColumnage.VisibleIndex + 1
        Else
            BandedGridColumnsize_type.Visible = False
        End If
    End Sub

    Private Sub SLEComp_EditValueChanged(sender As Object, e As EventArgs) Handles SLEComp.EditValueChanged
        GCByProduct.DataSource = Nothing
    End Sub

    Private Sub SLESubFilter_EditValueChanged(sender As Object, e As EventArgs) Handles SLESubFilter.EditValueChanged
        GCByProduct.DataSource = Nothing
    End Sub

    Private Sub SLEPeriodType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEPeriodType.EditValueChanged
        GCByProduct.DataSource = Nothing
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        GCByProduct.DataSource = Nothing
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        GCByProduct.DataSource = Nothing
    End Sub

    Private Sub LEDisplay_EditValueChanged(sender As Object, e As EventArgs) Handles LEDisplay.EditValueChanged
        GCByProduct.DataSource = Nothing
    End Sub

    Private Sub CESizetyp_EditValueChanged(sender As Object, e As EventArgs) Handles CESizetyp.EditValueChanged
        GCByProduct.DataSource = Nothing
    End Sub

    Private Sub GVByProduct_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVByProduct.CustomColumnDisplayText
        If (e.Column.FieldName.Contains("sal_qty") Or e.Column.FieldName.Contains("inv_qty") Or e.Column.FieldName.Contains("age")) Then
            Dim qty As Decimal = Convert.ToDecimal(e.Value)
            If qty = 0 Then
                e.DisplayText = "-"
            End If
        ElseIf e.Column.FieldName = "no" Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            If view.GroupedColumns.Count <> 0 AndAlso Not e.IsForGroupRow Then
                Dim rowHandle As Integer = view.GetRowHandle(e.ListSourceRowIndex)
                e.DisplayText = (view.GetRowGroupIndexByRowHandle(rowHandle) + 1).ToString()
            End If
        End If
    End Sub

    Private Sub CEFindAllProduct_EditValueChanged(sender As Object, e As EventArgs) Handles CEFindAllProduct.EditValueChanged
        resetViewByAccount()
        id_design_per_outlet = "-1"
        TxtProduct.Text = ""
        If CEFindAllProduct.EditValue = True Then
            BtnBrowseProduct.Enabled = False
        Else
            BtnBrowseProduct.Enabled = True
        End If
    End Sub

    Private Sub BtnBrowseProduct_Click(sender As Object, e As EventArgs) Handles BtnBrowseProduct.Click
        Cursor = Cursors.WaitCursor
        FormSearchDesign.id_pop_up = "4"
        FormSearchDesign.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEAccount_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAccount.EditValueChanged
        resetViewByAccount()
    End Sub

    Sub resetViewByAccount()
        GCByAccount.DataSource = Nothing
    End Sub

    Private Sub TxtProduct_EditValueChanged(sender As Object, e As EventArgs) Handles TxtProduct.EditValueChanged
        resetViewByAccount()
    End Sub

    Private Sub LEFilterOptAcc_EditValueChanged(sender As Object, e As EventArgs) Handles LEFilterOptAcc.EditValueChanged
        resetViewByAccount()
        loadSubFilterAcc()
    End Sub

    Private Sub SLESubFilterAcc_EditValueChanged(sender As Object, e As EventArgs) Handles SLESubFilterAcc.EditValueChanged
        resetViewByAccount()
    End Sub

    Private Sub SLEPeriodTypeAcc_EditValueChanged(sender As Object, e As EventArgs) Handles SLEPeriodTypeAcc.EditValueChanged
        resetViewByAccount()
    End Sub

    Private Sub DEFromAcc_EditValueChanged(sender As Object, e As EventArgs) Handles DEFromAcc.EditValueChanged
        resetViewByAccount()
    End Sub

    Private Sub DEUntilAcc_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntilAcc.EditValueChanged
        resetViewByAccount()
    End Sub

    Private Sub LEDisplayAcc_EditValueChanged(sender As Object, e As EventArgs) Handles LEDisplayAcc.EditValueChanged
        resetViewByAccount()
    End Sub

    Private Sub BtnHideFilterAcc_Click(sender As Object, e As EventArgs) Handles BtnHideFilterAcc.Click
        PanelControlViewByAcc.Visible = False
        BtnShowFilterAcc.Visible = True
    End Sub

    Private Sub BtnExportToXLSAcc_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSAcc.Click
        If GVByAccount.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            'column option creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVByAccount.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            For i As Integer = 0 To GVByAccount.Columns.Count - 1
                If GVByAccount.Columns(i).OwnerBand.ToString = "SALES" Or GVByAccount.Columns(i).OwnerBand.ToString = "STOCK ON HAND" Then
                    GVByAccount.Columns(i).Caption = GVByAccount.Columns(i).FieldName.ToString
                End If
            Next

            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "sales_inv_by_account.xlsx"
            exportToXLS(path, "sales inventory by account", GCByAccount)

            'restore column opt
            GVByAccount.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewAcc_Click(sender As Object, e As EventArgs) Handles BtnViewAcc.Click
        viewByAccount
    End Sub

    Sub viewByAccount()
        Cursor = Cursors.WaitCursor
        FormMain.SplashScreenManager1.ShowWaitForm()

        'Prepare paramater date
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromAcc.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilAcc.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'other
        Dim id_comp As String = SLEAccount.EditValue.ToString
        Dim id_period_type As String = SLEPeriodTypeAcc.EditValue.ToString

        'display
        Dim opt_display_param As String = LEDisplayAcc.EditValue.ToString
        If opt_display_param = "1" Then
            GridBandSOHAcc.Visible = True
        Else
            GridBandSOHAcc.Visible = False
        End If

        'where string
        Dim where_param As String = ""
        Dim id_filter_opt As String = LEFilterOptAcc.EditValue.ToString
        Dim id_sub_filter As String = SLESubFilterAcc.EditValue.ToString
        Select Case id_filter_opt
            Case 1
                where_param = "AND cls.id_class=" + id_sub_filter + " "
            Case 2
                where_param = "AND kat.kat=''" + SLESubFilter.Text.ToString + "'' "
            Case 3
                where_param = "AND subkat.id_subkat=" + id_sub_filter + " "
            Case 4
                where_param = "AND prc.id_design_cat=" + id_sub_filter + " "
            Case 5
                where_param = "AND d.id_season=" + id_sub_filter + " "
            Case Else
                where_param = ""
        End Select
        If id_design_per_outlet = "-1" Then
            id_design_per_outlet = "0"
        End If

        'excecute
        Dim query As String = "CALL view_sales_inv_per_account('" + date_from_selected + "', '" + date_until_selected + "', '" + id_comp + "','" + id_design_per_outlet + "', '" + id_period_type + "', '" + opt_display_param + "', '" + where_param + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCByAccount.DataSource = data
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnShowFilterAcc_Click(sender As Object, e As EventArgs) Handles BtnShowFilterAcc.Click
        PanelControlViewByAcc.Visible = True
        BtnShowFilterAcc.Visible = False
    End Sub

    Private Sub GVByAccount_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVByAccount.CustomColumnDisplayText
        If (e.Column.FieldName.Contains("sal_qty") Or e.Column.FieldName.Contains("inv_qty") Or e.Column.FieldName.Contains("age")) Then
            Dim qty As Decimal = Convert.ToDecimal(e.Value)
            If qty = 0 Then
                e.DisplayText = "-"
            End If
        ElseIf e.Column.FieldName = "no" Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            If view.GroupedColumns.Count <> 0 AndAlso Not e.IsForGroupRow Then
                Dim rowHandle As Integer = view.GetRowHandle(e.ListSourceRowIndex)
                e.DisplayText = (view.GetRowGroupIndexByRowHandle(rowHandle) + 1).ToString()
            End If
        End If
    End Sub
End Class