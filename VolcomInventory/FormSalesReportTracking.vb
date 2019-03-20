Public Class FormSalesReportTracking
    Public var_periode As String = ""
    Public var_store As String = ""
    Public var_rep_area As String = ""
    Public var_island As String = ""
    Public var_grup As String = ""
    Public var_price_cat As String = ""
    Public var_promo As String = ""
    Public var_division As String = ""
    Public var_season As String = ""
    Public var_prc_type As String = ""

    Private Sub FormSalesPOS_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
    End Sub

    Private Sub FormSalesPOS_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormSalesReportTracking_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_data(ByVal id_comp As String, ByVal date_start As String, ByVal date_end As String, ByVal id_rep As String, ByVal island As String, ByVal id_comp_group As String, ByVal id_price_cat As String, ByVal id_promo As String, ByVal id_division As String, ByVal id_season As String, ByVal id_price_type As String)
        Dim query As String = "CALL sales_tracking('" & id_comp & "','" & date_start & "','" & date_end & "','" & id_rep & "','" & island & "','" & id_comp_group & "','" & id_price_cat & "','" & id_promo & "','" & id_division & "','" & id_season & "','" & id_price_type & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'Console.WriteLine(query)
        GCListDesign.DataSource = data
        BGVListDesign.BestFitColumns()
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        FormSalesReportTrackingParam.ShowDialog()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        'print(GCListDesign, "Tracking List")
        Cursor = Cursors.WaitCursor
        ReportSalesReportTracking.dt = GCListDesign.DataSource
        Dim Report As New ReportSalesReportTracking()
        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        BGVListDesign.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.BGVListDesign.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.BGVListDesign)

        'Parse val
        Report.LPeriode.Text = var_periode
        Report.LStore.Text = var_store
        Report.LRepArea.Text = var_rep_area
        Report.LIsland.Text = var_island
        Report.LGrupStore.Text = var_grup
        Report.LPriceCat.Text = var_price_cat
        Report.LPromo.Text = var_promo
        Report.LDivision.Text = var_division
        Report.LSeason.Text = var_season
        Report.LPriceType.Text = var_prc_type

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub
End Class