Public Class FormABGRoyaltyZone
    Private Sub FormABGRoyaltyZone_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewYear()
        viewQuarter()
    End Sub

    Sub viewYear()
        Cursor = Cursors.WaitCursor
        Dim query As String = "(SELECT YEAR(sp.sales_pos_date) AS `year`
        FROM tb_sales_pos sp
        WHERE sp.id_report_status!=5
        GROUP BY YEAR(sp.sales_pos_date) 
        ORDER BY `year` DESC)"
        viewSearchLookupQuery(SLEYear, query, "year", "year", "year")
        Cursor = Cursors.Default
    End Sub

    Sub viewQuarter()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT '0' AS `id_quarter`, 'ALL' AS `quarter`
        UNION ALL
        SELECT '1' AS `id_quarter`, 'QUARTER 1' AS `quarter`
        UNION
        SELECT '2' AS `id_quarter`, 'QUARTER 2' AS `quarter`
        UNION
        SELECT '3' AS `id_quarter`, 'QUARTER 3' AS `quarter`
        UNION 
        SELECT '4' AS `id_quarter`, 'QUARTER 4' AS `quarter` "
        viewSearchLookupQuery(SLEQuarter, query, "id_quarter", "quarter", "id_quarter")
        Cursor = Cursors.Default
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        FormMain.SplashScreenManager1.ShowWaitForm()
        Dim year As String = SLEYear.EditValue.ToString
        Dim cond As String = ""
        If SLEQuarter.Text.ToString <> "ALL" Then
            cond = "AND a.quarter=''" + SLEQuarter.Text.ToString + "'' "
        End If
        Dim query As String = "CALL view_abg_royalty_zone('" + year + "', '" + cond + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        'GVData.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Private Sub FormABGRoyaltyZone_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormABGRoyaltyZone_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnExportToXLS_Click(sender As Object, e As EventArgs) Handles BtnExportToXLS.Click
        If GVData.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "abg_roy_zone.xlsx"
            exportToXLS(path, "report", GCData)
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
End Class