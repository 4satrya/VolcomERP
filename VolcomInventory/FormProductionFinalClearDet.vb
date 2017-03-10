Imports Microsoft.Office.Interop

Public Class FormProductionFinalClearDet
    Public id_prod_fc As String = "-1"
    Public action As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_report_status As String = "-1"
    Dim id_prod_order As String = "-1"
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_so As String = get_setup_field("bof_xls_fcl")
    Public is_view As String = "-1"

    Private Sub FormProductionFinalClearDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewPLCat()
        actionLoad()
    End Sub

    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    'View PL Category
    Sub viewPLCat()
        Dim query As String = "SELECT * FROM tb_lookup_pl_category a WHERE a.id_pl_category>1 ORDER BY a.id_pl_category  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEPLCategory, query, 0, "pl_category", "id_pl_category")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            BMark.Enabled = False
            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            DEForm.Text = view_date(0)
            TxtCodeCompFrom.Focus()
        ElseIf action = "upd" Then
            GroupControlItemList.Enabled = True
            BtnAttachment.Enabled = True
            BMark.Enabled = True

            'query view based on edit id's
            Dim query_c As ClassProductionFinalClear = New ClassProductionFinalClear()
            Dim query As String = query_c.queryMain("AND f.id_prod_fc='" + id_prod_fc + "' ", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_prod_fc = data.Rows(0)("id_prod_fc").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LEPLCategory.ItemIndex = LEPLCategory.Properties.GetDataSourceRowIndex("id_pl_category", data.Rows(0)("id_pl_category").ToString)
            TxtNumber.Text = data.Rows(0)("prod_fc_number").ToString
            DEForm.Text = view_date_from(data.Rows(0)("prod_fc_datex").ToString, 0)
            MENote.Text = data.Rows(0)("prod_fc_note").ToString
            id_comp_from = data.Rows(0)("id_comp_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_from_number").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_from_name").ToString
            id_comp_to = data.Rows(0)("id_comp_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_to_number").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_to_name").ToString
            TxtOrder.Text = data.Rows(0)("prod_order_number").ToString
            TxtSeason.Text = data.Rows(0)("season").ToString
            TxtDel.Text = data.Rows(0)("delivery").ToString
            TxtVendorCode.Text = data.Rows(0)("vendor_number").ToString
            TxtVendorName.Text = data.Rows(0)("vendor_name").ToString
            TxtStyleCode.Text = data.Rows(0)("code").ToString
            TxtStyle.Text = data.Rows(0)("name").ToString

            'detail2
            viewDetail()
            allow_status()
        End If
    End Sub

    Sub viewDetail()
        If action = "ins" Then
            Dim query As String = "CALL view_prod_order_det(" + id_prod_order + ", 1)"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCItemList.DataSource = data
        ElseIf action = "upd" Then
            Dim query As String = "CALL view_prod_fc(" + id_prod_fc + ")"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCItemList.DataSource = data
        End If

    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "105", id_prod_fc) Then
            MENote.Enabled = True
        Else
            MENote.Enabled = False
        End If
        BtnSave.Enabled = False
        GVItemList.OptionsBehavior.Editable = False
        MENote.Enabled = False
        TxtCodeCompFrom.Enabled = False
        TxtNameCompFrom.Enabled = False
        TxtCodeCompTo.Enabled = False
        TxtNameCompTo.Enabled = False
        TxtOrder.Enabled = False
        TxtSeason.Enabled = False
        TxtDel.Enabled = False
        TxtVendorCode.Enabled = False
        TxtVendorName.Enabled = False
        TxtStyleCode.Enabled = False
        TxtStyle.Enabled = False
        LEPLCategory.Enabled = False



        'ATTACH
        If check_attach_report_status(id_report_status, "105", id_prod_fc) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

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

        If is_view = "1" Then
            BtnSave.Visible = False
            BtnXlsBOF.Visible = False
        End If

        TxtNumber.Focus()
    End Sub

    Private Sub TxtCodeCompFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim data As DataTable = get_company_by_code(TxtCodeCompFrom.Text, "AND comp.id_departement=" + id_departement_user + "")
            If data.Rows.Count = 0 Then
                stopCustom("Account not found!")
                id_comp_from = "-1"
                TxtNameCompFrom.Text = ""
                TxtCodeCompFrom.Text = ""
                TxtCodeCompFrom.Focus()
            Else
                id_comp_from = data.Rows(0)("id_comp").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
                TxtCodeCompTo.Focus()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub TxtCodeCompTo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim data As DataTable = get_company_by_code(addSlashes(TxtCodeCompTo.Text), "AND comp.id_departement=" + id_departement_user + "")
            If data.Rows.Count = 0 Then
                stopCustom("Account not found!")
                id_comp_to = "-1"
                TxtNameCompTo.Text = ""
                TxtCodeCompTo.Text = ""
                TxtCodeCompTo.Focus()
            Else
                id_comp_to = data.Rows(0)("id_comp").ToString
                TxtNameCompTo.Text = data.Rows(0)("comp_name").ToString
                TxtCodeCompTo.Text = data.Rows(0)("comp_number").ToString
                TxtOrder.Focus()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub TxtOrder_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtOrder.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim order As String = addSlashes(TxtOrder.Text.ToString)
            Dim query As String = "SELECT po.id_prod_order, po.prod_order_number, c.comp_number AS `vendor_code`, c.comp_name AS `vendor`,
            dsg.design_code AS `code`, dsg.design_display_name AS `name`, s.id_season, s.season,d.delivery
            FROM tb_prod_order po 
            INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
            INNER JOIN tb_m_design dsg ON dsg.id_design = pdd.id_design
            LEFT JOIN tb_prod_order_wo wo ON wo.id_prod_order = po.id_prod_order AND wo.is_main_vendor=1
            LEFT JOIN tb_m_ovh_price ovp ON ovp.id_ovh_price = wo.id_ovh_price
            LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ovp.id_comp_contact
            LEFT JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            INNER JOIN tb_season_delivery d ON d.id_delivery = po.id_delivery
            INNER JOIN tb_season s ON s.id_season = d.id_season
            WHERE (po.id_report_status=3 OR po.id_report_status=4 OR po.id_report_status=6) AND po.prod_order_number='" + order + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count = 0 Then
                stopCustom("Order not found!")
                id_prod_order = "-1"
                TxtOrder.Text = ""
                TxtSeason.Text = ""
                TxtDel.Text = ""
                TxtVendorCode.Text = ""
                TxtVendorName.Text = ""
                TxtStyleCode.Text = ""
                TxtStyle.Text = ""
                TxtOrder.Text = ""
                viewDetail()
                TxtOrder.Focus()
            Else
                id_prod_order = data.Rows(0)("id_prod_order").ToString
                TxtOrder.Text = data.Rows(0)("prod_order_number").ToString
                TxtSeason.Text = data.Rows(0)("season").ToString
                TxtDel.Text = data.Rows(0)("delivery").ToString
                TxtVendorCode.Text = data.Rows(0)("vendor_code").ToString
                TxtVendorName.Text = data.Rows(0)("vendor").ToString
                TxtStyleCode.Text = data.Rows(0)("code").ToString
                TxtStyle.Text = data.Rows(0)("name").ToString
                viewDetail()
                LEPLCategory.Focus()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub LEPLCategory_KeyDown(sender As Object, e As KeyEventArgs) Handles LEPLCategory.KeyDown
        If e.KeyCode = Keys.Enter Then
            GCItemList.Focus()
            GVItemList.FocusedColumn = GridColumnQtySum
        End If
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub FormProductionFinalClearDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "105"
        FormReportMark.id_report = id_prod_fc
        If is_view = "1" Then
            FormReportMark.is_view = "1"
        End If
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "105"
        FormDocumentUpload.id_report = id_prod_fc
        If is_view = "1" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnXlsBOF_Click(sender As Object, e As EventArgs) Handles BtnXlsBOF.Click
        exportToBOF(True)
    End Sub

    Sub exportToBOF(ByVal show_msg As Boolean)
        If bof_column = "1" Then
            Cursor = Cursors.WaitCursor

            'hide column
            For c As Integer = 0 To GVItemList.Columns.Count - 1
                GVItemList.Columns(c).Visible = False
            Next
            GridColumnCodeSum.VisibleIndex = 0
            GridColumnQtySum.VisibleIndex = 1
            GVItemList.OptionsPrint.PrintFooter = False
            GVItemList.OptionsPrint.PrintHeader = False


            'export excel
            Dim path_root As String = ""
            Try
                ' Open the file using a stream reader.
                Using sr As New IO.StreamReader(Application.StartupPath & "\pro_path.txt")
                    ' Read the stream to a string and write the string to the console.
                    path_root = sr.ReadToEnd()
                End Using
            Catch ex As Exception
            End Try

            Dim fileName As String = bof_xls_so + ".xls"
            Dim exp As String = IO.Path.Combine(path_root, fileName)
            Try
                ExportToExcel(GVItemList, exp, show_msg)
            Catch ex As Exception
                stopCustom("Please close your excel file first then try again later")
            End Try


            'show column
            GridColumnNoSum.VisibleIndex = 0
            GridColumnCodeSum.VisibleIndex = 1
            GridColumnStyleSum.VisibleIndex = 2
            GridColumnSizeSum.VisibleIndex = 3
            GridColumnQtySum.VisibleIndex = 4
            GridColumnNoteSum.VisibleIndex = 5
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
                If j = 0 Then
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "code").ToString
                Else
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "prod_fc_det_qty")
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

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportProductionFinalClear.id_prod_fc = id_prod_fc
        ReportProductionFinalClear.dt = GCItemList.DataSource
        Dim Report As New ReportProductionFinalClear()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVItemList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVItemList)

        'Parse val
        Report.LFromName.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
        Report.LToName.Text = TxtCodeCompTo.Text + " - " + TxtNameCompTo.Text
        Report.LRecNumber.Text = TxtNumber.Text
        Report.LRecDate.Text = DEForm.Text
        Report.LNote.Text = MENote.Text
        Report.LPONumber.Text = TxtOrder.Text
        Report.LSeason.Text = TxtSeason.Text + " / " + TxtDel.Text
        Report.LVendor.Text = TxtVendorCode.Text + " - " + TxtVendorName.Text
        Report.LDesign.Text = TxtStyleCode.Text + " - " + TxtStyle.Text
        Report.Lcat.Text = LEPLCategory.Text

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        If id_comp_from = "-1" Or id_comp_to = "-1" Or id_prod_order = "-1" Or GVItemList.RowCount <= 0 Then
            stopCustom("Data can't blank")
        Else
            If action = "ins" Then
                Dim id_pl_category As String = LEPLCategory.EditValue.ToString
                Dim prod_fc_note As String = addSlashes(MENote.Text.ToString)

                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to save changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim query As String = "INSERT INTO tb_prod_fc(id_prod_order, id_comp_from, id_comp_to, id_pl_category, prod_fc_number, prod_fc_date, prod_fc_note, id_report_status) "
                    query += "VALUES('" + id_prod_order + "','" + id_comp_from + "', '" + id_comp_to + "', '" + id_pl_category + "', '" + header_number_prod("12") + "' , NOW(), '" + prod_fc_note + "', '1'); SELECT LAST_INSERT_ID(); "
                    id_prod_fc = execute_query(query, 0, True, "", "", "", "")
                    increase_inc_prod("12")

                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_prod_fc_det(id_prod_fc, id_prod_order_det, id_product, prod_fc_det_qty, prod_fc_det_note) VALUES "
                    End If
                    For j As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Try
                            Dim id_prod_order_det As String = GVItemList.GetRowCellValue(j, "id_prod_order_det").ToString
                            Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                            Dim prod_fc_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "prod_fc_det_qty").ToString)
                            Dim prod_fc_det_note As String = GVItemList.GetRowCellValue(j, "prod_fc_det_note").ToString

                            If jum_ins_j > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_prod_fc + "', '" + id_prod_order_det + "', '" + id_product + "', '" + prod_fc_det_qty + "', '" + prod_fc_det_note + "') "
                            jum_ins_j = jum_ins_j + 1
                        Catch ex As Exception
                        End Try
                    Next
                    If GVItemList.RowCount > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'submit who prepared
                    submit_who_prepared("105", id_prod_fc, id_user)


                    FormProductionFinalClear.viewFinalClear()
                    FormProductionFinalClear.GVFinalClear.FocusedRowHandle = find_row(FormProductionFinalClear.GVFinalClear, "id_prod_fc", id_prod_fc)
                    action = "upd"
                    actionLoad()
                    exportToBOF(False)
                    infoCustom("Final Clearance : " + TxtNumber.Text + " was created successfully.")
                    Cursor = Cursors.Default
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub
End Class