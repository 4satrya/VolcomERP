Public Class FormOutboundManifest
    Public dt As DataTable
    Public ftr As String = ""

    Private Sub FormOutboundManifest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GCManifest.DataSource = dt
        GVManifest.ActiveFilterString = ftr

        'check group
        'Dim is_block_del_store As String = get_setup_field("is_block_del_store")
        'If is_block_del_store = "1" Then
        '    For i As Integer = 0 To GVManifest.RowCount - 1
        '        Dim id_comp_group As String = GVManifest.GetRowCellValue(i, "id_comp_group").ToString
        '        Dim del As New ClassSalesDelOrder()
        '        If del.checkUnpaidInvoiceGroup(id_comp_group) Then
        '            stopCustom("Slips cannot be printed , because invoice has not been paid by " + GVManifest.GetRowCellValue(i, "comp_group").ToString)
        '            Cursor = Cursors.Default
        '            Close()
        '            Exit Sub
        '        End If
        '    Next
        'End If

        'For i As Integer = 0 To GVManifest.Columns.Count - 1
        '    GVManifest.Columns(i).Visible = False
        'Next

        'GVManifest.Columns("no").Caption = "NO"
        'GVManifest.Columns("do_no").Caption = "DELIVERY SLIP"
        'GVManifest.Columns("scan_date").Caption = "SCANNED DATE"
        'GVManifest.Columns("account").Caption = "STORE ACCOUNT"
        'GVManifest.Columns("reff").Caption = "REFF"
        'GVManifest.Columns("account_name").Caption = "STORE NAME"
        'GVManifest.Columns("qty").Caption = "QTY"
        'GVManifest.Columns("comp_group").Caption = "GROUP STORE"
        'GVManifest.Columns("weight").Caption = "P"
        'GVManifest.Columns("length").Caption = "L"
        'GVManifest.Columns("height").Caption = "T"
        'GVManifest.Columns("volume").Caption = "DIM"
        'GVManifest.Columns("c_weight").Caption = "FINAL WEIGHT"
        'GVManifest.Columns("cargo").Caption = "BPL"
        'GVManifest.Columns("rmk").Caption = "REMARK"

        'GVManifest.Columns("no").VisibleIndex = 0
        'GVManifest.Columns("do_no").VisibleIndex = 1
        'GVManifest.Columns("account").VisibleIndex = 2
        'GVManifest.Columns("account_name").VisibleIndex = 3
        'GVManifest.Columns("qty").VisibleIndex = 4
        'GVManifest.Columns("comp_group").VisibleIndex = 5
        'GVManifest.Columns("weight").VisibleIndex = 6
        'GVManifest.Columns("length").VisibleIndex = 7
        'GVManifest.Columns("height").VisibleIndex = 8
        'GVManifest.Columns("volume").VisibleIndex = 9
        'GVManifest.Columns("c_weight").VisibleIndex = 10
        'GVManifest.Columns("cargo").VisibleIndex = 11
        'GVManifest.Columns("rmk").VisibleIndex = 12
        printManifest()
        Close()
    End Sub

    Private Sub FormOutboundManifest_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVManifest_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles GVManifest.CellMerge
        If (e.Column.FieldName = "id_awbill" Or e.Column.FieldName = "weight" Or e.Column.FieldName = "length" Or e.Column.FieldName = "width" Or e.Column.FieldName = "height" Or e.Column.FieldName = "volume" Or e.Column.FieldName = "c_weight") Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim val1 As String = view.GetRowCellValue(e.RowHandle1, "id_awbill")
            Dim val2 As String = view.GetRowCellValue(e.RowHandle2, "id_awbill")
            e.Merge = (val1.ToString = val2.ToString)
            e.Handled = True
        Else
            e.Merge = False
            e.Handled = True
        End If
    End Sub

    Private Sub GVManifest_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVManifest.CustomColumnDisplayText
        'If e.Column.FieldName = "no" Then
        '    e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        'End If
    End Sub

    Private Sub GVManifest_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles GVManifest.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString
        End If
    End Sub

    Private Sub BAccept_Click(sender As Object, e As EventArgs) Handles BAccept.Click
        printManifest()
    End Sub

    Sub printManifest()
        Cursor = Cursors.WaitCursor
        GridColumnNo.VisibleIndex = 0
        For i As Integer = 0 To GVManifest.RowCount - 1
            GVManifest.SetRowCellValue(i, "no", (i + 1).ToString)
        Next
        GCManifest.RefreshDataSource()
        GVManifest.RefreshData()
        ReportOutboundManifest.dt = GCManifest.DataSource
        Dim Report As New ReportOutboundManifest()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVManifest.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVManifest.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid style
        'ReportStyleGridview(Report.GVManifest)
        Report.GVManifest.AppearancePrint.FilterPanel.BackColor = Color.Transparent
        Report.GVManifest.AppearancePrint.FilterPanel.ForeColor = Color.Black
        Report.GVManifest.AppearancePrint.FilterPanel.Font = New Font("Segoe UI", 8, FontStyle.Regular)

        Report.GVManifest.AppearancePrint.GroupFooter.BackColor = Color.Transparent
        Report.GVManifest.AppearancePrint.GroupFooter.ForeColor = Color.Black
        Report.GVManifest.AppearancePrint.GroupFooter.Font = New Font("Segoe UI", 8, FontStyle.Bold)

        Report.GVManifest.AppearancePrint.GroupRow.BackColor = Color.Transparent
        Report.GVManifest.AppearancePrint.GroupRow.ForeColor = Color.Black
        Report.GVManifest.AppearancePrint.GroupRow.Font = New Font("Segoe UI", 8, FontStyle.Bold)


        Report.GVManifest.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
        Report.GVManifest.AppearancePrint.HeaderPanel.ForeColor = Color.Black
        Report.GVManifest.AppearancePrint.HeaderPanel.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        Report.GVManifest.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap

        Report.GVManifest.AppearancePrint.FooterPanel.BackColor = Color.Transparent
        Report.GVManifest.AppearancePrint.FooterPanel.ForeColor = Color.Black
        Report.GVManifest.AppearancePrint.FooterPanel.Font = New Font("Segoe UI", 8, FontStyle.Bold)

        Report.GVManifest.AppearancePrint.Row.Font = New Font("Segoe UI", 8, FontStyle.Regular)
        Report.GVManifest.OptionsPrint.UsePrintStyles = True

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        GridColumnNo.Visible = False
        Cursor = Cursors.Default
    End Sub
End Class