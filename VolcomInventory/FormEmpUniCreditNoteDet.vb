Public Class FormEmpUniCreditNoteDet
    Public id_emp_uni_ex As String = "0"

    Public is_view As Boolean = False

    Private id_emp_uni_ex_ref As String = "0"
    Private id_departement As String = "0"
    Private id_pl_sales_order_del As String = "0"
    Private id_comp_contact As String = "0"

    Private max_qty As DataTable = New DataTable

    Private bof_column As String = get_setup_field("bof_column")
    Private bof_xls_so As String = get_setup_field("bof_xls_inv")

    Private printed_name As String = ""

    Private Sub FormEmpUniCreditNoteDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_category()
        view_report_status()
        load_form()
    End Sub

    Private Sub FormEmpUniCreditNoteDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBPick_Click(sender As Object, e As EventArgs) Handles SBPick.Click
        FormEmpUniCreditNotePick.ShowDialog()
    End Sub

    Sub load_form()
        If Not id_emp_uni_ex = "0" Then
            Dim query_c As New ClassEmpUniExpense()

            Dim query As String = query_c.queryMain("AND e.id_emp_uni_ex = " + id_emp_uni_ex, "2")

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TEExpense.Text = data.Rows(0)("emp_uni_ex_number_ref").ToString
            TxtNumber.Text = data.Rows(0)("emp_uni_ex_number").ToString
            DECreated.EditValue = data.Rows(0)("emp_uni_ex_date")
            MENote.Text = data.Rows(0)("emp_uni_ex_note").ToString
            TxtDel.Text = data.Rows(0)("pl_sales_order_del_number").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtAccNo.Text = data.Rows(0)("comp_number").ToString
            TxtAcc.Text = data.Rows(0)("comp_name").ToString
            DEStart.EditValue = data.Rows(0)("period_from")
            DEEnd.EditValue = data.Rows(0)("period_until")
            TxtDepartement.Text = data.Rows(0)("departement").ToString
            SLECat.EditValue = data.Rows(0)("id_item_cat").ToString

            id_pl_sales_order_del = data.Rows(0)("id_pl_sales_order_del").ToString
            id_departement = data.Rows(0)("id_departement").ToString
            id_comp_contact = data.Rows(0)("id_comp_contact").ToString

            printed_name = data.Rows(0)("printed_name").ToString

            'detail
            Dim data_detail As DataTable = execute_query("CALL view_emp_uni_ex(" + id_emp_uni_ex + ")", -1, True, "", "", "", "")

            GCData.DataSource = data_detail
        End If

        If LEReportStatus.EditValue.ToString = "5" Or LEReportStatus.EditValue.ToString = "6" Then
            is_view = True
        End If

        'controls
        If id_emp_uni_ex = "0" Then
            BtnMark.Enabled = False
            BtnViewJournal.Enabled = False
            BtnXlsBOF.Enabled = False
            BtnDraftJournal.Enabled = False
            BtnAttachment.Enabled = True
            BtnPrint.Enabled = False
            BtnSave.Enabled = True
            TEExpense.ReadOnly = False
            SBPick.Enabled = True
            RepositoryItemTextEdit.ReadOnly = False
            MENote.ReadOnly = False
        Else
            BtnMark.Enabled = True
            BtnViewJournal.Enabled = True
            BtnXlsBOF.Enabled = True
            BtnDraftJournal.Enabled = True
            BtnAttachment.Enabled = False
            BtnPrint.Enabled = True
            BtnSave.Enabled = False
            TEExpense.ReadOnly = True
            SBPick.Enabled = False
            RepositoryItemTextEdit.ReadOnly = True
            MENote.ReadOnly = True
        End If

        If LEReportStatus.EditValue.ToString = "6" Then
            BtnDraftJournal.Visible = False
            BtnViewJournal.Visible = True
        End If

        If LEReportStatus.EditValue.ToString <> "5" And bof_column = "1" Then
            BtnXlsBOF.Visible = True
        Else
            BtnXlsBOF.Visible = False
        End If
    End Sub

    Sub view_category()
        Dim query As String = "SELECT * FROM tb_item_cat c WHERE c.is_active=1 ORDER BY c.item_cat ASC"
        viewSearchLookupQuery(SLECat, query, "id_item_cat", "item_cat", "id_item_cat")
    End Sub

    Sub view_report_status()
        Dim query As String = "SELECT * FROM tb_lookup_report_status ORDER BY id_report_status"
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        GVData.DeleteSelectedRows()
    End Sub

    Private Sub TEExpense_KeyDown(sender As Object, e As KeyEventArgs) Handles TEExpense.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim selected_id As String = execute_query("SELECT IFNULL((SELECT id_emp_uni_ex FROM tb_emp_uni_ex WHERE emp_uni_ex_number = '" + addSlashes(TEExpense.EditValue.ToString) + "'), 0) AS id_emp_uni_ex", 0, True, "", "", "", "")

            If selected_id = "0" Then
                stopCustom("Expense number not found.")
            Else
                infoCustom("Expense number found.")

                load_ref(selected_id)
            End If
        End If
    End Sub

    Sub load_ref(selected_id As String)
        Cursor = Cursors.WaitCursor

        id_emp_uni_ex_ref = selected_id

        Dim query_c As New ClassEmpUniExpense()

        Dim query As String = query_c.queryMain("AND e.id_emp_uni_ex = " + id_emp_uni_ex_ref, "2")

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEExpense.Text = data.Rows(0)("emp_uni_ex_number").ToString
        TxtDel.Text = data.Rows(0)("pl_sales_order_del_number").ToString
        TxtAccNo.Text = data.Rows(0)("comp_number").ToString
        TxtAcc.Text = data.Rows(0)("comp_name").ToString
        DEStart.EditValue = data.Rows(0)("period_from")
        DEEnd.EditValue = data.Rows(0)("period_until")
        TxtDepartement.Text = data.Rows(0)("departement").ToString
        SLECat.EditValue = data.Rows(0)("id_item_cat").ToString

        id_pl_sales_order_del = data.Rows(0)("id_pl_sales_order_del").ToString
        id_departement = data.Rows(0)("id_departement").ToString
        id_comp_contact = data.Rows(0)("id_comp_contact").ToString

        Dim data_detail As DataTable = execute_query("CALL view_emp_uni_ex(" + selected_id + ")", -1, True, "", "", "", "")

        GCData.DataSource = data_detail

        'get maximum qty
        Dim q_in As String = ""

        For i = 0 To data_detail.Rows.Count - 1
            q_in += data_detail.Rows(i)("id_emp_uni_ex_det").ToString + ", "
        Next

        q_in = q_in.Substring(0, q_in.Length - 2)

        max_qty = execute_query("
            SELECT d.id_emp_uni_ex_det, (d.qty - IFNULL(t_used.used, 0)) AS max_qty
            FROM tb_emp_uni_ex_det AS d
            LEFT JOIN (
	            SELECT d.id_emp_uni_ex_det_ref, SUM(ABS(d.qty)) AS used
	            FROM tb_emp_uni_ex_det AS d
	            LEFT JOIN tb_emp_uni_ex AS a ON d.id_emp_uni_ex = a.id_emp_uni_ex
	            WHERE a.id_report_status <> 5 AND d.id_emp_uni_ex_det_ref IN (" + q_in + ")
	            GROUP BY d.id_emp_uni_ex_det_ref
            ) AS t_used ON d.id_emp_uni_ex_det = t_used.id_emp_uni_ex_det_ref
            WHERE d.id_emp_uni_ex = " + selected_id + "
        ", -1, True, "", "", "", "")

        'set qty to maximum
        For i = 0 To GVData.RowCount - 1
            If GVData.IsValidRowHandle(i) Then
                For j = 0 To max_qty.Rows.Count - 1
                    If GVData.GetRowCellValue(i, "id_emp_uni_ex_det").ToString = max_qty.Rows(j)("id_emp_uni_ex_det").ToString Then
                        GVData.SetRowCellValue(i, "qty", max_qty.Rows(j)("max_qty"))

                        Exit For
                    End If
                Next
            End If
        Next

        Cursor = Cursors.Default
    End Sub

    Private Sub TEExpense_KeyUp(sender As Object, e As KeyEventArgs) Handles TEExpense.KeyUp
        TEExpense.Text = TEExpense.Text.ToUpper
        TEExpense.SelectionStart = TEExpense.Text.Length
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim start_period_cek As String = "0000-01-01"
        Dim end_period_cek As String = "9999-12-01"

        Try
            start_period_cek = DEStart.EditValue.ToString
        Catch ex As Exception
        End Try

        Try
            end_period_cek = DEEnd.EditValue.ToString
        Catch ex As Exception
        End Try

        'cek coa
        Dim cond_coa As Boolean = True

        Dim qcoa As String = "
                SELECT c.id_coa_out 
                FROM tb_item_coa c
                INNER JOIN tb_a_acc a ON a.id_acc = c.id_coa_out
                WHERE c.id_departement=" + id_departement + " AND c.id_item_cat=" + SLECat.EditValue.ToString

        Dim dcoa As DataTable = execute_query(qcoa, -1, True, "", "", "", "")

        If dcoa.Rows.Count <= 0 Then
            cond_coa = False
        End If

        If id_pl_sales_order_del = "-1" Then
            warningCustom("Delivery can't blank")
        ElseIf id_departement = "-1" Then
            warningCustom("Please select departement")
        ElseIf Not cond_coa Then
            warningCustom("COA not found. Please setup first")
        ElseIf start_period_cek = "0000-01-01" Or end_period_cek = "9999-12-01" Then
            warningCustom("Please fill period")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor

                Dim emp_uni_ex_note As String = addSlashes(MENote.Text)
                Dim period_from As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim period_until As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim id_item_cat As String = SLECat.EditValue.ToString

                'main
                Dim qi As String = "INSERT INTO tb_emp_uni_ex (id_emp_uni_ex_ref, id_comp_contact, id_pl_sales_order_del, emp_uni_ex_number, emp_uni_ex_date, period_from, period_until, emp_uni_ex_note, id_report_status, id_departement, id_item_cat, report_mark_type) 
                VALUES('" + id_emp_uni_ex_ref + "', '" + id_comp_contact + "', '" + id_pl_sales_order_del + "', '" + header_number_sales("40") + "', NOW(), '" + period_from + "', '" + period_until + "', '" + emp_uni_ex_note + "', 1, '" + id_departement + "', '" + id_item_cat + "', 236); SELECT LAST_INSERT_ID();"

                id_emp_uni_ex = execute_query(qi, 0, True, "", "", "", "")

                increase_inc_sales("40")

                'detail
                Dim qd As String = "INSERT INTO tb_emp_uni_ex_det(id_emp_uni_ex, id_emp_uni_ex_det_ref, id_pl_sales_order_del_det, id_product, qty, design_cop, remark) VALUES "

                For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                    If GVData.GetRowCellValue(i, "qty") > 0 Then
                        qd += "('" + id_emp_uni_ex + "', '" + GVData.GetRowCellValue(i, "id_emp_uni_ex_det").ToString + "', '" + GVData.GetRowCellValue(i, "id_pl_sales_order_del_det").ToString + "', '" + GVData.GetRowCellValue(i, "id_product").ToString + "', '-" + decimalSQL(GVData.GetRowCellValue(i, "qty").ToString) + "', '" + decimalSQL(GVData.GetRowCellValue(i, "design_cop").ToString) + "', '" + GVData.GetRowCellValue(i, "remark").ToString + "'), "
                    End If
                Next

                qd = qd.Substring(0, qd.Length - 2)

                execute_non_query(qd, True, "", "", "", "")

                'draft journal
                If Not GridColumn7.SummaryItem.SummaryValue = 0 Then
                    Dim acc As New ClassAccounting()

                    acc.generateJournalSalesDraft(id_emp_uni_ex, "236")
                End If

                'submit mark
                submit_who_prepared("236", id_emp_uni_ex, id_user)

                load_form()

                FormEmpUniCreditNote.view_form()
                FormEmpUniCreditNote.GVData.FocusedRowHandle = find_row(FormEmpUniCreditNote.GVData, "id_emp_uni_ex", id_emp_uni_ex)

                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub GVData_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVData.CellValueChanged
        If e.Column.FieldName = "qty" Then
            For i = 0 To max_qty.Rows.Count - 1
                If GVData.GetRowCellValue(e.RowHandle, "id_emp_uni_ex_det").ToString = max_qty.Rows(i)("id_emp_uni_ex_det").ToString Then
                    If GVData.GetRowCellValue(e.RowHandle, "qty").ToString > max_qty.Rows(i)("max_qty") Then
                        stopCustom("Maximum qty is " + max_qty.Rows(i)("max_qty").ToString + ".")

                        GVData.SetRowCellValue(e.RowHandle, "qty", max_qty.Rows(i)("max_qty"))
                    End If

                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "236"
        FormDocumentUpload.id_report = id_emp_uni_ex
        FormDocumentUpload.is_view = If(id_emp_uni_ex = "0", "-1", "1")
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=236 AND ad.id_report=" + id_emp_uni_ex + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDraftJournal_Click(sender As Object, e As EventArgs) Handles BtnDraftJournal.Click
        Cursor = Cursors.WaitCursor
        FormAccountingDraftJournal.is_view = If(is_view, "1", "-1")
        FormAccountingDraftJournal.id_report = id_emp_uni_ex
        FormAccountingDraftJournal.report_number = TxtNumber.Text
        FormAccountingDraftJournal.report_mark_type = "236"
        FormAccountingDraftJournal.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "236"
        FormReportMark.id_report = id_emp_uni_ex
        If is_view Then
            FormReportMark.is_view = "1"
        End If
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportEmpUniExpense.id_emp_uni_ex = id_emp_uni_ex
        ReportEmpUniExpense.dt = GCData.DataSource
        Dim Report As New ReportEmpUniExpense()

        Report.XrLabel1.Visible = True
        Report.XrLabel2.Visible = True
        Report.XrLabel3.Visible = True

        'Parse val
        'Report.LabelTitle.Text = "UNIFORM ORDER"
        Report.LabelCat.Text = SLECat.Text.ToUpper
        Report.LabelDel.Text = TxtDel.Text.ToUpper
        Report.LabelAcc.Text = TxtAccNo.Text.ToUpper + " - " + TxtAcc.Text.ToUpper
        Report.LabelEmp.Text = TxtNIP.Text.ToUpper + " - " + TxtEmployeeName.Text.ToUpper
        Report.LabelDepartement.Text = TxtDepartement.Text.ToUpper
        Report.LabelPeriod.Text = DEStart.Text.ToUpper + " - " + DEEnd.Text.ToUpper

        Report.LabelTitleNumber.Text = "NO. " + TxtNumber.Text.ToUpper

        Report.LabelTitle.Text = printed_name
        Report.LabelDate.Text = Date.Parse(DECreated.EditValue.ToString).ToString("dd MMMM yyyy")
        Report.XrLabel3.Text = TEExpense.Text

        Report.XrLabel34.Text = "Note : " + MENote.Text
        Report.LabelSay.Text = "Say : " + ConvertCurrencyToEnglish(GridColumn7.SummaryItem.SummaryValue, get_setup_field("id_currency_default"))

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnXlsBOF_Click(sender As Object, e As EventArgs) Handles BtnXlsBOF.Click
        exportToBOF(True)
    End Sub

    Sub exportToBOF(ByVal show_msg As Boolean)
        Cursor = Cursors.WaitCursor
        If bof_column = "1" Then
            Cursor = Cursors.WaitCursor

            'copy stream column
            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVData.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'hide column
            For c As Integer = 0 To GVData.Columns.Count - 1
                GVData.Columns(c).Visible = False
            Next
            GridColumnCode.VisibleIndex = 0
            GridColumnQty.VisibleIndex = 1
            GridColumnCost.VisibleIndex = 2
            GridColumnNumber.VisibleIndex = 3
            GridColumnAccount.VisibleIndex = 4
            GridColumnStart.VisibleIndex = 5
            GridColumnEnd.VisibleIndex = 6
            GridColumnDueEate.VisibleIndex = 7
            GridColumnType.VisibleIndex = 8
            DEStart.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
            DEEnd.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
            GVData.OptionsPrint.PrintFooter = False
            GVData.OptionsPrint.PrintHeader = False


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
                ExportToExcel(GVData, exp, show_msg)
            Catch ex As Exception
                stopCustom("Please close your excel file first then try again later")
            End Try


            'show column
            GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            DEStart.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
            DEEnd.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
            GVData.OptionsPrint.PrintFooter = True
            GVData.OptionsPrint.PrintHeader = True
            Cursor = Cursors.Default
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ExportToExcel(ByVal dtTemp As DevExpress.XtraGrid.Views.Grid.GridView, ByVal filepath As String, show_msg As Boolean)
        Dim strFileName As String = filepath
        If System.IO.File.Exists(strFileName) Then
            System.IO.File.Delete(strFileName)
        End If
        Dim _excel As New Microsoft.Office.Interop.Excel.Application
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

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
                ElseIf j = 2 Then 'harga
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "design_cop")
                ElseIf j = 3 Then 'number
                    wSheet.Cells(rowIndex + 1, colIndex) = TxtNumber.Text
                ElseIf j = 4 Then 'account toko
                    wSheet.Cells(rowIndex + 1, colIndex) = TxtAccNo.Text
                ElseIf j = 5 Then 'period from
                    wSheet.Cells(rowIndex + 1, colIndex) = DEStart.EditValue
                ElseIf j = 6 Then 'period end
                    wSheet.Cells(rowIndex + 1, colIndex) = DEEnd.EditValue
                ElseIf j = 7 Then 'due date
                    wSheet.Cells(rowIndex + 1, colIndex) = DEEnd.EditValue
                ElseIf j = 8 Then 'type
                    wSheet.Cells(rowIndex + 1, colIndex) = "1"
                End If
            Next
        Next

        wSheet.Columns.AutoFit()
        wBook.SaveAs(strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel5)

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