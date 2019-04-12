Imports Microsoft.Office.Interop

Public Class FormEmpUniExpenseDet
    Public id_emp_uni_ex As String = "-1"
    Public action As String = ""
    Dim id_pl_sales_order_del As String = "-1"
    Dim id_comp_contact As String = "-1"
    Dim id_comp As String = "-1"
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Public id_departement As String = "-1"
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_so As String = get_setup_field("bof_xls_inv")

    Private Sub FormEmpUniExpenseDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewItemCat()
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewItemCat()
        Dim query As String = "SELECT * FROM tb_item_cat c WHERE c.is_active=1 ORDER BY c.item_cat ASC"
        viewSearchLookupQuery(SLECat, query, "id_item_cat", "item_cat", "id_item_cat")
    End Sub

    Private Sub FormEmpUniExpenseDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            TxtNumber.Text = "[auto generate]"
            BtnPrint.Visible = False
            BtnAttachment.Visible = False
            BtnMark.Visible = False
            BtnDraftJournal.Visible = False
            viewDetail()
            ActiveControl = SLECat
        ElseIf action = "upd" Then
            BtnPrint.Visible = True
            BtnAttachment.Visible = True
            BtnMark.Visible = True
            BtnDraftJournal.Visible = True
            Dim query_c As New ClassEmpUniExpense()
            Dim query As String = query_c.queryMain("AND e.id_emp_uni_ex=" + id_emp_uni_ex + "", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TxtNumber.Text = data.Rows(0)("emp_uni_ex_number").ToString
            DECreated.EditValue = data.Rows(0)("emp_uni_ex_date")
            MENote.Text = data.Rows(0)("emp_uni_ex_note").ToString
            id_pl_sales_order_del = data.Rows(0)("id_pl_sales_order_del").ToString
            TxtDel.Text = data.Rows(0)("pl_sales_order_del_number").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtAccNo.Text = data.Rows(0)("comp_number").ToString
            TxtAcc.Text = data.Rows(0)("comp_name").ToString
            DEStart.EditValue = data.Rows(0)("period_from")
            DEEnd.EditValue = data.Rows(0)("period_until")
            id_departement = data.Rows(0)("id_departement").ToString
            TxtDepartement.Text = data.Rows(0)("departement").ToString
            SLECat.EditValue = data.Rows(0)("id_item_cat").ToString

            'employee info
            If data.Rows(0)("id_so_status").ToString = "7" Then
                Dim id_emp_uni_budget As String = data.Rows(0)("id_emp_uni_budget").ToString
                Dim qe As String = "SELECT * FROM tb_emp_uni_budget b
                INNER JOIN tb_m_employee e ON e.id_employee = b.id_employee 
                WHERE b.id_emp_uni_budget=" + id_emp_uni_budget + " "
                Dim de As DataTable = execute_query(qe, -1, True, "", "", "", "")
                TxtNIP.Text = de.Rows(0)("employee_code").ToString
                TxtEmployeeName.Text = de.Rows(0)("employee_name").ToString
            End If
            viewDetail()
            allow_status()
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_emp_uni_ex(" + id_emp_uni_ex + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
    End Sub

    Sub allow_status()
        SLECat.Enabled = False
        BtnBrowse.Enabled = False
        TxtNumber.Enabled = False
        MENote.Enabled = False
        BtnSave.Enabled = False
        TxtDel.Enabled = False
        DEStart.Properties.ReadOnly = True
        DEEnd.Properties.ReadOnly = True

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        If id_report_status > 1 Then
            BtnDraftJournal.Visible = False
        End If

        If is_view = "1" Then
            BtnSave.Visible = False
        End If

        If id_report_status <> "5" And bof_column = "1" Then
            BtnXlsBOF.Visible = True
        Else
            BtnXlsBOF.Visible = False
        End If

        If id_report_status = "6" Then
            BtnViewJournal.Visible = True
            BtnViewJournal.BringToFront()
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "132"
        FormReportMark.id_report = id_emp_uni_ex
        If is_view = "1" Then
            FormReportMark.is_view = "1"
        End If
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "132"
        FormDocumentUpload.id_report = id_emp_uni_ex
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'cek periode
        Dim start_period_cek As String = "0000-01-01"
        Dim end_period_cek As String = "9999-12-01"
        Dim due_date_cek As String = "-1"
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
        Dim qcoa As String = "SELECT c.id_coa_out
        FROM tb_item_coa c
        INNER JOIN tb_a_acc a ON a.id_acc = c.id_coa_out
        WHERE c.id_departement=" + id_departement + " AND c.id_item_cat=" + SLECat.EditValue.ToString + " "
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
                Dim qi As String = "INSERT INTO tb_emp_uni_ex(id_comp_contact, id_pl_sales_order_del, emp_uni_ex_number, emp_uni_ex_date, period_from, period_until, emp_uni_ex_note, id_report_status, id_departement, id_item_cat) 
                VALUES('" + id_comp_contact + "','" + id_pl_sales_order_del + "', '" + header_number_sales("35") + "', NOW(), '" + period_from + "','" + period_until + "', '" + emp_uni_ex_note + "', 1, '" + id_departement + "', '" + id_item_cat + "'); SELECT LAST_INSERT_ID(); "
                id_emp_uni_ex = execute_query(qi, 0, True, "", "", "", "")
                increase_inc_sales("35")

                'detail
                Dim qd As String = "INSERT INTO tb_emp_uni_ex_det(id_emp_uni_ex, id_pl_sales_order_del_det, id_product, qty, design_cop, remark) VALUES "
                For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                    If i > 0 Then
                        qd += ", "
                    End If
                    qd += "('" + id_emp_uni_ex + "','" + GVData.GetRowCellValue(i, "id_pl_sales_order_del_det").ToString + "', '" + GVData.GetRowCellValue(i, "id_product").ToString + "', '" + decimalSQL(GVData.GetRowCellValue(i, "qty").ToString) + "', '" + decimalSQL(GVData.GetRowCellValue(i, "design_cop").ToString) + "', '" + GVData.GetRowCellValue(i, "remark").ToString + "') "
                Next
                execute_non_query(qd, True, "", "", "", "")

                'reserved stock
                Dim rsv_stock As ClassEmpUniExpense = New ClassEmpUniExpense()
                rsv_stock.reservedStock(id_emp_uni_ex, 132)

                'draft journal
                Dim acc As New ClassAccounting()
                acc.generateJournalSalesDraft(id_emp_uni_ex, "132")

                'submit mark
                submit_who_prepared("132", id_emp_uni_ex, id_user)

                'refresh
                action = "upd"
                actionLoad()
                exportToBOF(False)
                FormEmpUniExpense.viewData()
                FormEmpUniExpense.GVData.FocusedRowHandle = find_row(FormEmpUniExpense.GVData, "id_emp_uni_ex", id_emp_uni_ex)
                infoCustom("Transaction : " + TxtNumber.Text + " created successfully")
                viewDraft()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub TxtDel_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDel.KeyDown
        If e.KeyCode = Keys.Enter Then
            'hanya bisa do single karena liat di categori SO : uniform
            Dim so_cat As String = ""
            'so_cat = "AND (so.id_so_status=7 OR so.id_so_status=9) "

            Dim query As String = "SELECT pldel.id_pl_sales_order_del, so.sales_order_ol_shop_number, pldel.id_store_contact_to, comp.id_comp, comp.comp_name, comp.comp_number, comp.address_primary, comp.npwp, comp.id_drawer_def, comp.comp_commission, rck.id_wh_rack, loc.id_wh_locator, sp.id_emp_uni_ex, so.id_so_status, so.id_emp_uni_budget
            FROM tb_pl_sales_order_del pldel 
            INNER JOIN tb_sales_order so ON so.id_sales_order = pldel.id_sales_order "
            query += " INNER JOIN tb_m_comp_contact cc On cc.id_comp_contact=pldel.id_store_contact_to"
            query += " INNER JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
            INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = comp.id_drawer_def 
            INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack 
            INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
            query += "LEFT JOIN tb_emp_uni_ex sp ON sp.id_pl_sales_order_del=pldel.id_pl_sales_order_del AND sp.id_report_status !=5 "
            query += " WHERE pldel.id_report_status='6' AND pldel.is_combine=2 AND pldel.pl_sales_order_del_number='" + addSlashes(TxtDel.Text) + "' " + so_cat + " "
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count <= 0 Then
                stopCustom("Delivery is not found for this store.")
                defaultReset()
                TxtDel.Focus()
            ElseIf Not data.Rows(0)("id_emp_uni_ex").ToString = "" Then
                stopCustom("Already created.")
                defaultReset()
                TxtDel.Focus()
            Else
                'id DO
                id_pl_sales_order_del = data.Rows(0)("id_pl_sales_order_del").ToString
                id_comp_contact = data.Rows(0)("id_store_contact_to").ToString
                id_comp = data.Rows(0)("id_comp").ToString
                TxtAccNo.Text = data.Rows(0)("comp_number").ToString
                TxtAcc.Text = data.Rows(0)("comp_name").ToString

                'fill employee info
                Dim id_so_status As String = data.Rows(0)("id_so_status").ToString
                If id_so_status = "7" Then
                    Dim id_emp_uni_budget As String = data.Rows(0)("id_emp_uni_budget").ToString
                    Dim qe As String = "SELECT * FROM tb_emp_uni_budget b
                    INNER JOIN tb_m_employee e ON e.id_employee = b.id_employee 
                    INNER JOIN tb_m_departement d ON d.id_departement = b.id_departement
                    WHERE b.id_emp_uni_budget=" + id_emp_uni_budget + " "
                    Dim de As DataTable = execute_query(qe, -1, True, "", "", "", "")
                    TxtNIP.Text = de.Rows(0)("employee_code").ToString
                    TxtEmployeeName.Text = de.Rows(0)("employee_name").ToString
                    TxtDepartement.Text = de.Rows(0)("departement").ToString
                    id_departement = de.Rows(0)("id_departement").ToString
                End If

                'find dept jka bukan uniform staff
                If id_departement = "-1" Then
                    Dim qgd As String = "SELECT d.id_departement, d.departement
                    FROM tb_m_departement d 
                    WHERE d.id_comp_promo=" + id_comp + " LIMIT 1 "
                    Dim dgd As DataTable = execute_query(qgd, -1, True, "", "", "", "")
                    If dgd.Rows.Count > 0 Then
                        id_departement = dgd.Rows(0)("id_departement").ToString
                        TxtDepartement.Text = dgd.Rows(0)("departement").ToString
                    End If
                    BtnBrowse.Enabled = True
                End If


                ' fill GV
                view_do()
                DEStart.Focus()
            End If
        Else
            defaultReset()
        End If
    End Sub

    Sub defaultReset()
        id_departement = "-1"
        id_comp_contact = "-1"
        id_comp = "-1"
        id_pl_sales_order_del = "-1"
        TxtAcc.Text = ""
        TxtAccNo.Text = ""
        TxtNIP.Text = ""
        TxtEmployeeName.Text = ""
        TxtDepartement.Text = ""
        GCData.DataSource = Nothing
        BtnBrowse.Enabled = False
    End Sub

    Sub view_do()
        Dim query As String = "CALL view_pl_sales_order_del(" + id_pl_sales_order_del + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        'Cursor = Cursors.WaitCursor
        'print(GCData, "DAFTAR PILIHAN UNIFORM #" + TxtNumber.Text + System.Environment.NewLine + TxtEmployeeName.Text)
        'Cursor = Cursors.Default
        Cursor = Cursors.WaitCursor
        ReportEmpUniExpense.id_emp_uni_ex = id_emp_uni_ex
        ReportEmpUniExpense.dt = GCData.DataSource
        Dim Report As New ReportEmpUniExpense()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVData.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVData)

        'Parse val
        'Report.LabelTitle.Text = "UNIFORM ORDER"
        Report.LabelNumber.Text = TxtNumber.Text.ToUpper
        Report.LabelNIK.Text = TxtNIP.Text.ToUpper
        Report.LabelName.Text = TxtEmployeeName.Text.ToUpper
        Report.LabelDate.Text = DECreated.Text.ToString

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDraftJournal_Click(sender As Object, e As EventArgs) Handles BtnDraftJournal.Click
        viewDraft()
    End Sub

    Sub viewDraft()
        Cursor = Cursors.WaitCursor
        FormAccountingDraftJournal.is_view = is_view
        FormAccountingDraftJournal.id_report = id_emp_uni_ex
        FormAccountingDraftJournal.report_number = TxtNumber.Text
        FormAccountingDraftJournal.report_mark_type = "132"
        FormAccountingDraftJournal.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub DEStart_KeyDown(sender As Object, e As KeyEventArgs) Handles DEStart.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEEnd.Focus()
        End If
    End Sub

    Private Sub DEEnd_KeyDown(sender As Object, e As KeyEventArgs) Handles DEEnd.KeyDown
        If e.KeyCode = Keys.Enter Then
            MENote.Focus()
        End If
    End Sub

    Private Sub SLECat_KeyDown(sender As Object, e As KeyEventArgs) Handles SLECat.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtDel.Focus()
        End If
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        Cursor = Cursors.WaitCursor
        FormPopUpDept.id_pop_up = "1"
        FormPopUpDept.ShowDialog()
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

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=132 AND ad.id_report=" + id_emp_uni_ex + "
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
End Class