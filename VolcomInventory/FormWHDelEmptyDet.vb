Imports Microsoft.Office.Interop

Public Class FormWHDelEmptyDet
    Public action As String
    Public id_wh_del_empty As String = "-1"
    Public id_report_status As String
    Public dt As New DataTable
    Public id_pre As String = "-1"
    Public id_wh_drawer As String = "-1"
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_so As String = get_setup_field("bof_xls_nso")
    Public is_view As String = "-1"
    Public is_fix As String = "2"
    Dim is_scan_prob As String = "-1"
    Dim id_store As String = "-1"

    Private Sub FormWHDelEmptyDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        Dim del As New ClassDelEmpty()
        Dim query As String = del.queryMain("AND del.id_wh_del_empty=" + id_wh_del_empty + "", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        id_store = data.Rows(0)("id_comp").ToString
        TxtCodeCompTo.Text = data.Rows(0)("comp_number").ToString
        TxtNameCompTo.Text = data.Rows(0)("comp_name").ToString
        MEAdrressCompTo.Text = data.Rows(0)("address_primary").ToString
        DETrans.EditValue = data.Rows(0)("wh_del_empty_date")
        TxtSalesDelOrderNumber.Text = data.Rows(0)("wh_del_empty_number").ToString
        id_report_status = data.Rows(0)("id_report_status").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_report_status)
        is_fix = data.Rows(0)("is_fix").ToString

        view_detail()
        allow_status()

        If id_pre = "1" Then
            prePrinting()
            Close()
        ElseIf id_pre = "2" Then
            printing()
            Close()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub view_detail()
        'detail barcode
        Dim query As String = "CALL view_wh_del_empty(" + id_wh_del_empty + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data

        Dim queryd As String = "CALL view_wh_del_empty_sum(" + id_wh_del_empty + ")"
        Dim datad As DataTable = execute_query(queryd, -1, True, "", "", "", "")
        GCProbSum.DataSource = datad
    End Sub

    Sub allow_status()
        If is_fix = "1" Then
            BtnSave.Enabled = False
            PanelNavBarcode.Enabled = False
            BMark.Enabled = True
        Else
            BtnSave.Enabled = True
            PanelNavBarcode.Enabled = True
            BMark.Enabled = False
        End If

        'attachment
        If check_attach_report_status(id_report_status, "111", id_wh_del_empty) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        'pre print
        If check_pre_print_report_status(id_report_status) Then
            BtnPrePrinting.Enabled = True
        Else
            BtnPrePrinting.Enabled = False
        End If

        'print
        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        If id_report_status <> "5" And bof_column = "1" Then
            BtnXlsBOF.Visible = True
        Else
            BtnXlsBOF.Visible = False
        End If
        TxtSalesDelOrderNumber.Focus()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_wh_del_empty
        FormReportMark.report_mark_type = "111"
        FormReportMark.form_origin = Name
        FormReportMark.is_disabled_set_stt = "1"
        FormReportMark.is_view_finalize = "1"
        FormReportMark.is_view = is_view
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_wh_del_empty
        FormDocumentUpload.report_mark_type = "111"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtDeleteScan_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtScan.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim code As String = addSlashes(TxtScan.Text)
            If is_scan_prob = "1" Then 'scan
                Cursor = Cursors.WaitCursor
                Dim query As String = "CALL view_wh_del_empty_avl('" + id_wh_del_empty + "', '" + code + "', '" + id_store + "')"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    Dim stt As String = data.Rows(0)("stt").ToString
                    If stt = "ok" Then
                        TxtScan.Text = ""
                        TxtScan.Focus()
                        view_detail()
                    Else
                        stopCustom(stt)
                        TxtScan.Text = ""
                    End If
                Else
                    stopCustom("Data not found")
                End If
                data.Dispose()
                Cursor = Cursors.Default
            Else 'del
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim query As String = "CALL view_wh_del_empty_del('" + id_wh_del_empty + "', '" + code + "')"
                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If data.Rows.Count > 0 Then
                        Dim stt As String = data.Rows(0)("stt").ToString
                        If stt = "ok" Then
                            TxtScan.Text = ""
                            TxtScan.Focus()
                            view_detail()
                        Else
                            stopCustom(stt)
                            TxtScan.Text = ""
                        End If
                    Else
                        stopCustom("Data not found")
                    End If
                    data.Dispose()
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub BScan_Click(sender As Object, e As EventArgs) Handles BScan.Click
        Cursor = Cursors.WaitCursor
        is_scan_prob = "1"
        BScan.Enabled = False
        BStop.Enabled = True
        BDelete.Enabled = False
        TxtScan.Text = ""
        LabelScan.Visible = True
        TxtScan.Visible = True
        TxtScan.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub BStop_Click(sender As Object, e As EventArgs) Handles BStop.Click
        Cursor = Cursors.WaitCursor
        is_scan_prob = "-1"
        BScan.Enabled = True
        BStop.Enabled = False
        BDelete.Enabled = True
        TxtScan.Text = ""
        LabelScan.Visible = False
        TxtScan.Visible = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        Cursor = Cursors.WaitCursor
        is_scan_prob = "2"
        BScan.Enabled = False
        BStop.Enabled = True
        BDelete.Enabled = False
        TxtScan.Text = ""
        LabelScan.Visible = True
        TxtScan.Visible = True
        TxtScan.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormWHDelEmptyDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVProbSum_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVProbSum.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim wh_del_empty_note As String = addSlashes(MENote.Text)
            Dim query As String = "UPDATE tb_wh_del_empty SET wh_del_empty_note='" + wh_del_empty_note + "', is_fix=1 WHERE id_wh_del_empty='" + id_wh_del_empty + "' "
            execute_non_query(query, True, "", "", "", "")

            'submit who prepared
            submit_who_prepared("111", id_wh_del_empty, id_user)

            actionLoad()
            exportToBOF(False)
            FormWHDelEmpty.viewDel()
            FormWHDelEmpty.GVDel.FocusedRowHandle = find_row(FormWHDelEmpty.GVDel, "id_wh_del_empty", id_wh_del_empty)
            infoCustom("Document " + TxtSalesDelOrderNumber.Text + " was created successfully")
        End If
    End Sub

    Sub getReport()
        GCProbSum.RefreshDataSource()
        GVProbSum.RefreshData()
        ReportWHDelEmpty.dt = GCProbSum.DataSource
        ReportWHDelEmpty.id = id_wh_del_empty
        Dim Report As New ReportWHDelEmpty()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVProbSum.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVProbSum.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVProbSum)

        'Parse val
        Report.LabelTo.Text = TxtCodeCompTo.Text + "-" + TxtNameCompTo.Text
        Report.LabelAddress.Text = MEAdrressCompTo.Text
        Report.LRecNumber.Text = TxtSalesDelOrderNumber.Text
        Report.LabelNote.Text = MENote.Text
        Report.LRecDate.Text = DETrans.Text

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        ReportWHDelEmpty.id_pre = "1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Sub printing()
        Cursor = Cursors.WaitCursor
        ReportWHDelEmpty.id_pre = "-1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrePrinting_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrePrinting.ItemClick
        prePrinting()
    End Sub

    Private Sub BtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrint.ItemClick
        printing()
    End Sub

    Private Sub BtnXlsBOF_Click(sender As Object, e As EventArgs) Handles BtnXlsBOF.Click
        exportToBOF(True)
    End Sub

    Sub exportToBOF(ByVal show_msg As Boolean)
        If bof_column = "1" Then
            Cursor = Cursors.WaitCursor

            'hide column
            For c As Integer = 0 To GVProbSum.Columns.Count - 1
                GVProbSum.Columns(c).Visible = False
            Next
            GridColumnCodeProbSum.VisibleIndex = 0
            GridColumnQtyProbSum.VisibleIndex = 1
            GridColumnNumberProbSum.VisibleIndex = 2
            GridColumnFromProbSum.VisibleIndex = 3
            GridColumnToProbSum.VisibleIndex = 4
            GridColumnRemarkProbSum.VisibleIndex = 5
            GVProbSum.OptionsPrint.PrintFooter = False
            GVProbSum.OptionsPrint.PrintHeader = False


            'export excel
            Dim path_root As String = ""
            Try
                ' Open the file using a stream reader.
                Using sr As New IO.StreamReader(Application.StartupPath & "\bof_path.txt")
                    ' Read the stream to a string and write the string to the console.
                    path_root = sr.ReadToEnd()
                End Using
            Catch ex As Exception
            End Try

            Dim fileName As String = bof_xls_so + ".xls"
            Dim exp As String = IO.Path.Combine(path_root, fileName)
            Try
                ExportToExcel(GVProbSum, exp, show_msg)
            Catch ex As Exception
                stopCustom("Please close your excel file first then try again later")
            End Try

            'show column
            GridColumnNoProbSum.VisibleIndex = 0
            GridColumnCodeProbSum.VisibleIndex = 1
            GridColumnNameProbSum.VisibleIndex = 2
            GridColumnSizeProbSum.VisibleIndex = 3
            GridColumnQtyProbSum.VisibleIndex = 4
            GridColumnPrc.VisibleIndex = 5
            GridColumnAmount.VisibleIndex = 6
            GridColumnNumberProbSum.Visible = False
            GridColumnFromProbSum.Visible = False
            GridColumnToProbSum.Visible = False
            GVProbSum.OptionsPrint.PrintFooter = True
            GVProbSum.OptionsPrint.PrintHeader = True
            Cursor = Cursors.Default
        End If
    End Sub

    Public Sub ExportToExcel(ByVal dtTemp As DevExpress.XtraGrid.Views.Grid.GridView, ByVal filepath As String, show_msg As Boolean)
        Dim strFileName As String = filepath
        If System.IO.File.Exists(strFileName) Then
            System.IO.File.Delete(strFileName)
        End If
        Dim _excel As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()


        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = -1

        ' export the Columns 
        'If CheckBox1.Checked Then
        '    For Each dc In dt.Columns
        '        colIndex = colIndex + 1
        '        wSheet.Cells(1, colIndex) = dc.ColumnName
        '    Next
        'End If

        'export the rows 
        For i As Integer = 0 To dtTemp.RowCount - 1
            rowIndex = rowIndex + 1
            colIndex = 0
            For j As Integer = 0 To dtTemp.VisibleColumns.Count - 1
                colIndex = colIndex + 1
                If j = 0 Then 'code
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "code").ToString
                ElseIf j = 1 Then 'qty
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "qty")
                ElseIf j = 2 Then 'number
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "number").ToString
                ElseIf j = 3 Then 'from
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "from").ToString
                ElseIf j = 4 Then 'to
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "to").ToString
                Else
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "remark").ToString
                End If
            Next
        Next

        wSheet.Columns.AutoFit()
        wBook.SaveAs(strFileName, Excel.XlFileFormat.xlExcel5)

        'release the objects
        ReleaseObject(wSheet)
        wBook.Close(False)
        ReleaseObject(wBook)
        _excel.Quit()
        ReleaseObject(_excel)
        ' some time Office application does not quit after automation: so i am calling GC.Collect method.
        GC.Collect()

        If show_msg Then
            infoCustom("File exported successfully")
        End If
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub
End Class