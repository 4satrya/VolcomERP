Imports Microsoft.Office.Interop

Public Class FormMasterProductForBOF
    Dim bof_xls_so As String = get_setup_field("bof_xls_master")
    Private Sub FormMasterProductForBOF_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormMasterProductForBOF_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormMasterProductForBOF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
    End Sub

    Sub viewSeason()
        Dim query As String = ""
        query += "Select a.id_season, a.season, b.id_range, b.`range`  "
        query += "From tb_season a "
        query += "INNER Join tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY `range` DESC "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_master_for_bof(" + SLESeason.EditValue.ToString + ") "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        If GVData.RowCount > 0 Then
            BtnPrint.Visible = True
            BtnGenerate.Visible = True
        End If
        GVData.Columns("id_design").Visible = False
        GVData.Columns("final_cost").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GVData.Columns("final_cost").DisplayFormat.FormatString = "{0:n2}"
        GVData.Columns("normal_price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GVData.Columns("normal_price").DisplayFormat.FormatString = "{0:n2}"
        GVData.Columns("sale_price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GVData.Columns("sale_price").DisplayFormat.FormatString = "{0:n2}"
        GVData.Columns("last_exported_date").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        GVData.Columns("last_exported_date").DisplayFormat.FormatString = "dd MMMM yyyy \/ hh:mm tt"
        GVData.Columns("select").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        GVData.Columns("exported").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        GVData.Columns("last_exported_by").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        GVData.Columns("last_exported_date").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        GVData.Columns("status").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        'column properties
        For i As Integer = 0 To GVData.Columns.Count - 1
            If i = 0 Then
                GVData.Columns(i).OptionsColumn.AllowEdit = True
            Else
                GVData.Columns(i).OptionsColumn.AllowEdit = False
            End If
        Next

        'create repository
        Dim riCheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        riCheck.ValueChecked = "Yes"
        riCheck.ValueUnchecked = "No"
        GCData.RepositoryItems.Add(riCheck)
        GVData.Columns("select").ColumnEdit = riCheck
        GVData.Columns("select").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GVData.Columns("select").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GVData.BestFitColumns()
        noEdit()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Private Sub SLESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLESeason.EditValueChanged
        BtnPrint.Visible = False
        BtnGenerate.Visible = False
        GCData.DataSource = Nothing
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If GVData.RowCount > 0 Then
            Dim cek As String = CheckEdit1.EditValue.ToString
            For i As Integer = ((GVData.RowCount - 1) - GetGroupRowCount(GVData)) To 0 Step -1
                Dim stt As String = GVData.GetRowCellValue(i, "status").ToString
                If cek And stt = "OK" Then
                    GVData.SetRowCellValue(i, "select", "Yes")
                Else
                    GVData.SetRowCellValue(i, "select", "No")
                End If
            Next
        End If
    End Sub

    Sub noEdit()
        If GVData.FocusedRowHandle >= 0 Then
            Dim stt As String = GVData.GetFocusedRowCellValue("status").ToString
            If stt = "OK" Then
                GVData.Columns("select").OptionsColumn.AllowEdit = True
            Else
                GVData.Columns("select").OptionsColumn.AllowEdit = False
            End If
        End If
    End Sub

    Private Sub GVData_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVData.ColumnFilterChanged
        noEdit()
    End Sub

    Private Sub GVData_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVData.FocusedRowChanged
        noEdit()
    End Sub

    Private Sub GVData_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVData.RowCellStyle
        Dim stt As String = sender.GetRowCellValue(e.RowHandle, sender.Columns("status")).ToString
        If stt <> "OK" Then
            e.Appearance.BackColor = Color.Salmon
            e.Appearance.BackColor2 = Color.Salmon
            e.Appearance.FontStyleDelta = FontStyle.Bold
        Else
            e.Appearance.BackColor = Color.White
            e.Appearance.BackColor2 = Color.White
            e.Appearance.FontStyleDelta = FontStyle.Regular
        End If
    End Sub

    Sub gen()
        Cursor = Cursors.WaitCursor

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
            ExportToExcel(GVData, exp, True)
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    'Sub updateinfo()
    '    If GVData.RowCount > 0 Then
    '        For i As Integer = 0 To GVData.RowCount - 1
    '            'update db
    '            Dim query_upd As String = "UPDATE tb_m_design SET last_export_by=" + id_user + ", last_export=NOW(), is_export_bof=1 WHERE id_design=" + GVData.GetRowCellValue(i, "id_design").ToString + " "
    '            execute_non_query(query_upd, True, "", "", "", "")
    '        Next
    '    End If
    'End Sub

    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click
        makeSafeGV(GVData)
        GVData.ActiveFilterString = "[select]='Yes'"
        If GVData.RowCount > 0 Then
            gen()
        Else
            stopCustom("No record found")
        End If
        GVData.ActiveFilterString = ""
        viewData()
    End Sub

    Private Sub ExportToExcel(ByVal dtTemp As DevExpress.XtraGrid.Views.Grid.GridView, ByVal filepath As String, show_msg As Boolean)
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


        'export the rows 
        For i As Integer = 0 To dtTemp.RowCount - 1
            rowIndex = rowIndex + 1
            colIndex = 0
            For j As Integer = 5 To dtTemp.VisibleColumns.Count - 1
                colIndex = colIndex + 1
                If j = 16 Or j = 17 Or j = 18 Then
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, dtTemp.Columns(j).FieldName)
                ElseIf j <> 11 Then
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, dtTemp.Columns(j).FieldName).ToString
                Else
                    colIndex = colIndex - 1
                End If
            Next
            'update
            Dim query_upd As String = "UPDATE tb_m_design SET last_export_by=" + id_user + ", last_export=NOW(), is_export_bof=1 WHERE id_design=" + GVData.GetRowCellValue(i, "id_design").ToString + " "
            execute_non_query(query_upd, True, "", "", "", "")
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

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCData, "")
        Cursor = Cursors.Default
    End Sub
End Class