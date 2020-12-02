Public Class FormAccountingLedger
    Private Sub FormAccountingLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = Now
        DETo.EditValue = Now

        DETo.Properties.MinValue = Now

        load_unit()

        view_acc_from()
        view_acc_to()
    End Sub

    Sub view_acc_from()
        Dim where_coa_type As String = ""

        If SLEUnit.EditValue.ToString = "0" Then
            where_coa_type = ""
        ElseIf SLEUnit.EditValue.ToString = "1" Then
            where_coa_type = " WHERE id_coa_type = 1 "
        Else
            where_coa_type = " WHERE id_coa_type = 2 "
        End If

        viewSearchLookupQuery(SLUEFrom, "SELECT acc_name, acc_description, CONCAT(acc_name, ' - ', acc_description) AS acc_name_description FROM tb_a_acc " & where_coa_type & " ORDER BY acc_name ASC", "acc_name", "acc_name_description", "acc_name")
    End Sub

    Sub load_unit()
        Dim query As String = "SELECT 0 AS id_coa_tag,'ALL' AS tag_code,'ALL' AS tag_description 
UNION ALL
SELECT id_coa_tag,tag_code,tag_description FROM `tb_coa_tag`"
        '        query = "SELECT '0' AS id_comp,'-' AS comp_number, 'All Unit' AS comp_name
        'UNION ALL
        'SELECT ad.`id_comp`,c.`comp_number`,c.`comp_name` FROM `tb_a_acc_trans_det` ad
        'INNER JOIN tb_m_comp c ON c.`id_comp`=ad.`id_comp`
        'GROUP BY ad.id_comp"
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
        SLEUnit.EditValue = "1"
    End Sub

    Private Sub FormAccountingLedger_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormAccountingLedger_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormAccountingLedger_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub view_form()
        Cursor = Cursors.WaitCursor

        'clear datasource
        GCAccountingLedger.DataSource = Nothing

        Dim is_char As Boolean = False

        For i = 0 To SLUEFrom.EditValue.ToString.Length - 1
            If Char.IsLetter(SLUEFrom.EditValue.ToString.Chars(i)) Then
                is_char = True
            End If
        Next

        Dim acc_name As String = ""

        If is_char Then
            acc_name += "acc.acc_name LIKE \'" + SLUEFrom.EditValue.ToString + "\'"
        Else
            Dim acc_range As DataTable = execute_query("SELECT acc_name FROM tb_a_acc WHERE CAST(acc_name AS UNSIGNED) >= " + SLUEFrom.EditValue.ToString + " AND CAST(acc_name AS UNSIGNED) <= " + SLUETo.EditValue.ToString + "", -1, True, "", "", "", "")

            For i = 0 To acc_range.Rows.Count - 1
                acc_name += "acc.acc_name LIKE \'" + acc_range.Rows(i)("acc_name").ToString + "%\' OR "
            Next

            acc_name = "(" + acc_name.Substring(0, acc_name.Length - 4) + ")"
        End If

        Dim query As String = "CALL view_acc_ledger('" + Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + Date.Parse(DETo.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + acc_name + "','" & SLEUnit.EditValue.ToString & "')"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            'last balance
            data.Columns.Add("last_balance", GetType(Decimal))

            Dim last_acc As String = data.Rows(0)("acc_name").ToString

            For i = 0 To data.Rows.Count - 1
                If Not last_acc = data.Rows(i)("acc_name").ToString Then
                    data.Rows(i - 1)("last_balance") = data.Rows(i - 1)("balance")
                End If

                last_acc = data.Rows(i)("acc_name").ToString

                'last loop
                If i = data.Rows.Count - 1 Then
                    data.Rows(i)("last_balance") = data.Rows(i)("balance")
                End If
            Next

            'parent
            Dim where_coa_type As String = ""
            If SLEUnit.EditValue.ToString = "0" Then
                where_coa_type = ""
            ElseIf SLEUnit.EditValue.ToString = "1" Then
                where_coa_type = " AND id_coa_type = 1 "
            Else
                where_coa_type = " AND id_coa_type = 2 "
            End If

            Dim query_parent As String = "SELECT id_acc, id_acc_parent, acc_name, acc_description FROM tb_a_acc WHERE CHAR_LENGTH(acc_name) IN (4) " & where_coa_type & " ORDER BY acc_name ASC"

            Dim data_parent As DataTable = execute_query(query_parent, -1, True, "", "", "", "")

            'insert parent
            For i = 0 To data.Rows.Count - 1
                For j = 0 To data_parent.Rows.Count - 1
                    'parent 1
                    If data_parent.Rows(j)("acc_name").ToString.Length = 4 Then
                        If data.Rows(i)("acc_name").ToString.Substring(0, 4) = data_parent.Rows(j)("acc_name").ToString Then
                            data.Rows(i)("acc_name_1") = data_parent.Rows(j)("acc_name").ToString + " - " + data_parent.Rows(j)("acc_description").ToString
                        End If
                    End If
                Next
            Next
        End If

        GCAccountingLedger.DataSource = data

        GVAccountingLedger.BestFitColumns()

        Cursor = Cursors.Default
    End Sub

    Sub print_form()
        Try
            Dim report As ReportAccountingLedger = New ReportAccountingLedger

            report.data = GCAccountingLedger.DataSource

            report.XLPeriod.Text = DEFrom.Text + " - " + DETo.Text
            report.XLAccount.Text = SLUEFrom.Text + " - " + SLUETo.Text

            Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

            tool.ShowPreview()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        view_form()
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        DETo.Properties.MinValue = DEFrom.EditValue
    End Sub

    Sub view_acc_to()
        Dim is_char As Boolean = False

        For i = 0 To SLUEFrom.EditValue.ToString.Length - 1
            If Char.IsLetter(SLUEFrom.EditValue.ToString.Chars(i)) Then
                is_char = True
            End If
        Next

        Dim where_coa_type As String = ""

        If SLEUnit.EditValue.ToString = "0" Then
            where_coa_type = ""
        ElseIf SLEUnit.EditValue.ToString = "1" Then
            where_coa_type = " id_coa_type = 1 AND "
        Else
            where_coa_type = " id_coa_type = 2 AND "
        End If

        If is_char Then
            viewSearchLookupQuery(SLUETo, "SELECT acc_name, acc_description, CONCAT(acc_name, ' - ', acc_description) AS acc_name_description FROM tb_a_acc WHERE " & where_coa_type & " acc_name = '" + SLUEFrom.EditValue.ToString + "'", "acc_name", "acc_name_description", "acc_name")
        Else
            viewSearchLookupQuery(SLUETo, "SELECT acc_name, acc_description, CONCAT(acc_name, ' - ', acc_description) AS acc_name_description FROM tb_a_acc WHERE " & where_coa_type & " CAST(acc_name AS UNSIGNED) >= " + SLUEFrom.EditValue.ToString + " AND CHAR_LENGTH(acc_name) = " + SLUEFrom.EditValue.ToString.Length.ToString + " ORDER BY acc_name ASC", "acc_name", "acc_name_description", "acc_name")
        End If
    End Sub

    Private Sub SLUEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEFrom.EditValueChanged
        view_acc_to()
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor

        Try
            Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
            showpopup.opt = "Buku Besar"
            showpopup.report_mark_type = GVAccountingLedger.GetFocusedRowCellValue("report_mark_type").ToString
            showpopup.id_report = GVAccountingLedger.GetFocusedRowCellValue("id_report").ToString
            showpopup.show()
        Catch ex As Exception
            stopCustom("Document Not Found")
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub ViewReffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewReffToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor

        Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
        showpopup.opt = "Buku Besar"
        showpopup.report_mark_type = GVAccountingLedger.GetFocusedRowCellValue("report_mark_type_ref").ToString
        showpopup.id_report = GVAccountingLedger.GetFocusedRowCellValue("id_report_ref").ToString
        showpopup.show()

        Cursor = Cursors.Default
    End Sub

    Private Sub GVAccountingLedger_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVAccountingLedger.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "acc_trans_note" Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                e.TotalValue = "Sub Total: " + GVAccountingLedger.GetGroupRowDisplayText(e.GroupRowHandle).Replace("Account", "")
            End If
        End If
    End Sub

    Private Sub ViewJournalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewJournalToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor

        Dim id_acc_trans As String = GVAccountingLedger.GetFocusedRowCellValue("id_acc_trans").ToString

        If id_acc_trans <> "0" Then
            Dim s As New ClassShowPopUp()

            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False

            s.id_report = id_acc_trans
            s.report_mark_type = "36"

            s.show()
        Else
            warningCustom("Journal not found.")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub SLEUnit_EditValueChanged(sender As Object, e As EventArgs) Handles SLEUnit.EditValueChanged
        Try
            view_acc_from()
            view_acc_to()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BExportRaw_Click(sender As Object, e As EventArgs) Handles BExportRaw.Click
        If GVAccountingLedger.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "buku_besar.xlsx"
            exportToXLS(path, "buku_besar", GCAccountingLedger)
            Cursor = Cursors.Default
        End If
    End Sub

    Sub exportToXLS(ByVal path_par As String, ByVal sheet_name_par As String, ByVal gc_par As DevExpress.XtraGrid.GridControl)
        Cursor = Cursors.WaitCursor
        Dim path As String = path_par

        ' Customize export options 
        CType(gc_par.MainView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsPrint.PrintHeader = True
        Dim advOptions As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
        advOptions.ShowGroupSummaries = DevExpress.Utils.DefaultBoolean.True
        advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.True
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