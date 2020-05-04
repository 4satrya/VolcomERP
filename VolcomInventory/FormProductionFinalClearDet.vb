Imports Microsoft.Office.Interop

Public Class FormProductionFinalClearDet
    Public id_prod_fc As String = "-1"
    Public action As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_report_status As String = "-1"
    Public id_prod_order As String = "-1"
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_so As String = get_setup_field("bof_xls_fcl")
    Public is_view As String = "-1"
    Public id_design As String = "-1"
    Public dt As New DataTable
    Dim dt_exist As New DataTable
    Dim is_use_qc_report As String = "-1"
    Public id_prod_order_rec As String = "-1"

    Private Sub FormProductionFinalClearDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewPLCat()
        viewPLCatSub()
        actionLoad()
    End Sub

    Sub load_cat_rec()
        Dim q As String = "SELECT id_pl_category,pl_category FROM tb_lookup_pl_category"
        viewSearchLookupQuery(SLERecType, q, "id_pl_category", "pl_category", "id_pl_category")
    End Sub

    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    'View PL Category
    Sub viewPLCat()
        Dim query As String = "SELECT * FROM tb_lookup_pl_category a ORDER BY a.id_pl_category ASC  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEPLCategory, query, 0, "pl_category", "id_pl_category")
    End Sub

    'View PL Category
    Sub viewPLCatSub()
        Dim id_cat As String = "-1"
        Try
            id_cat = LEPLCategory.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT * FROM tb_lookup_pl_category_sub a WHERE a.id_pl_category='" + id_cat + "' ORDER BY a.id_pl_category_sub ASC  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LECLaim, query, 0, "pl_category_sub", "id_pl_category_sub")
    End Sub

    Sub actionLoad()
        load_cat_rec()

        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            Try
                'initiation datatable jika blm ada
                dt.Columns.Add("id_product")
                dt.Columns.Add("id_prod_order_det")
                dt.Columns.Add("product_code")
                dt.Columns.Add("product_counting_code")
                dt.Columns.Add("product_full_code")
                dt.Columns.Add("is_old_design")
            Catch ex As Exception
            End Try

            BMark.Enabled = False
            BtnPrint.Enabled = False
            BtnPrePrinting.Enabled = False
            BtnAttachment.Enabled = False
            DEForm.Text = view_date(0)
            TxtCodeCompFrom.Focus()

            If id_prod_order_rec <> "-1" Then
                Dim query As String = "SELECT po.id_prod_order, po.prod_order_number,rec.prod_order_rec_number, po.prod_order_date, 
                comp.comp_number AS `vendor_number`, comp.comp_name AS `vendor_name`, 
                d.id_design, d.design_code, d.design_display_name, ss.season, del.delivery, po.id_report_status,
                cfr.id_comp AS `id_comp_from`,cfr.comp_number as `comp_number_from`, cfr.comp_name AS `comp_name_from`, po.is_use_qc_report, rec.id_pl_category
                FROM tb_prod_order_rec rec 
                INNER JOIN tb_prod_order po ON po.id_prod_order=rec.id_prod_order
                INNER JOIN tb_prod_order_wo wo On wo.id_prod_order = po.id_prod_order AND wo.is_main_vendor='1' AND wo.id_report_status!=5
                INNER JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price = wo.id_ovh_price
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact 
                INNER JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
                INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
                INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
                INNER JOIN tb_season_delivery del ON del.id_delivery = po.id_delivery
                INNER JOIN tb_season ss ON ss.id_season = del.id_season
                INNER JOIN tb_m_comp cfr ON cfr.id_comp = 74
                WHERE rec.id_prod_order_rec='" + id_prod_order_rec + "' "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                is_use_qc_report = data.Rows(0)("is_use_qc_report").ToString
                id_design = data.Rows(0)("id_design").ToString
                id_comp_from = data.Rows(0)("id_comp_from").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
                TxtOrder.Text = data.Rows(0)("prod_order_number").ToString
                TERec.Text = data.Rows(0)("prod_order_rec_number").ToString
                TxtSeason.Text = data.Rows(0)("season").ToString
                TxtDel.Text = data.Rows(0)("delivery").ToString
                TxtVendorCode.Text = data.Rows(0)("vendor_number").ToString
                TxtVendorName.Text = data.Rows(0)("vendor_name").ToString
                TxtStyleCode.Text = data.Rows(0)("design_code").ToString
                TxtStyle.Text = data.Rows(0)("design_display_name").ToString
                LEPLCategory.EditValue = data.Rows(0)("id_pl_category").ToString

                SLERecType.EditValue = data.Rows(0)("id_pl_category").ToString

                viewDetail()
                view_barcode_list()
                pre_viewImages("2", PEView, id_design, False)
                BtnBrowseFrom.Enabled = False
                BtnBrowseTo.Enabled = False
                BtnBrowsePO.Enabled = False
                GroupControlListBarcode.Enabled = True

                'kalo gk pake qc report ketik qty
                If is_use_qc_report = "2" Then
                    PanelNavBarcode.Visible = False
                    getLimitQty()
                    GridColumnQtySum.OptionsColumn.AllowEdit = True
                End If
                '
                BtnInfoSrs.Enabled = True
            End If
        ElseIf action = "upd" Then
            GroupControlItemList.Enabled = True
            GroupControlListBarcode.Enabled = True
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
            If Not IsDBNull(data.Rows(0)("id_pl_category_sub")) Then
                LECLaim.ItemIndex = LECLaim.Properties.GetDataSourceRowIndex("id_pl_category_sub", data.Rows(0)("id_pl_category_sub").ToString)
            Else
                LECLaim.EditValue = Nothing
            End If
            SLERecType.EditValue = data.Rows(0)("id_pl_category_rec").ToString
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
            TERec.Text = data.Rows(0)("prod_order_rec_number").ToString
            TxtSeason.Text = data.Rows(0)("season").ToString
            TxtDel.Text = data.Rows(0)("delivery").ToString
            TxtVendorCode.Text = data.Rows(0)("vendor_number").ToString
            TxtVendorName.Text = data.Rows(0)("vendor_name").ToString
            TxtStyleCode.Text = data.Rows(0)("code").ToString
            TxtStyle.Text = data.Rows(0)("name").ToString
            id_design = data.Rows(0)("id_design").ToString
            pre_viewImages("2", PEView, id_design, False)

            'detail2
            viewDetail()
            view_barcode_list()
            allow_status()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        If action = "ins" Then
            'Dim query As String = "CALL view_prod_order_det(" + id_prod_order + ", 1)"
            Dim query As String = "SELECT 0 AS `id_prod_fc_det`, 0 AS `id_prod_fc`, pod.id_prod_order_det, pod.id_prod_order,
            prod.id_product, prod.product_full_code AS `code`, prod.product_name as `name`, cd.code_detail_name as `size`,
            0 AS `prod_fc_det_qty`, 0 AS `qty_limit`,'' AS `prod_fc_det_note`
            FROM tb_prod_order_det pod
            INNER JOIN tb_prod_demand_product pd_prod ON pd_prod.id_prod_demand_product = pod.id_prod_demand_product
            INNER JOIN tb_m_product prod ON prod.id_product = pd_prod.id_product
            INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
            WHERE pod.id_prod_order=" + id_prod_order + " "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCItemList.DataSource = data
            GVItemList.BestFitColumns()

            'load unique code
            FormProcessing.id_process = "5"
            FormProcessing.idx_main = id_prod_order
            FormProcessing.ShowDialog()
        ElseIf action = "upd" Then
            Dim query As String = "CALL view_prod_fc(" + id_prod_fc + ")"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCItemList.DataSource = data
            GVItemList.BestFitColumns()
        End If
    End Sub

    Sub view_barcode_list()
        If action = "ins" Then
            Dim query As String = "SELECT ('0') AS no, ('') AS code, ('0') AS id_prod_order_det,'0' AS `id_product`, ('1') AS is_fix, ('0') AS id_prod_fc_counting, '' AS `scan_status` "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBarcode.DataSource = data
            GVBarcode.BestFitColumns()
            deleteRowsBc()
        ElseIf action = "upd" Then
            Dim query As String = "SELECT ('') AS `no`, a.full_code AS code, 
            a.id_prod_fc,  a.id_prod_fc_counting, ('2') AS is_fix, a.id_prod_order_det , a.id_product
            FROM tb_prod_fc_counting a 
            INNER JOIN tb_m_product c ON c.id_product = a.id_product 
            WHERE a.id_prod_fc=" + id_prod_fc + " "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBarcode.DataSource = data
            GVBarcode.BestFitColumns()
        End If
    End Sub

    'DeleteRows
    Sub deleteRowsBc()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
    End Sub

    Sub allow_status()
        Dim report_mark_type As String = execute_query("SELECT report_mark_type FROM tb_prod_fc WHERE id_prod_fc = " + id_prod_fc, 0, True, "", "", "", "")

        If check_edit_report_status(id_report_status, report_mark_type, id_prod_fc) Then
            MENote.Enabled = True
        Else
            MENote.Enabled = False
        End If
        BtnSave.Enabled = False
        GVItemList.OptionsBehavior.Editable = False
        GVBarcode.OptionsBehavior.Editable = False
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
        LECLaim.Enabled = False
        BtnBrowseFrom.Enabled = False
        BtnBrowseTo.Enabled = False
        BtnBrowsePO.Enabled = False
        PanelNavBarcode.Visible = False


        'preprint
        If id_report_status <> "5" Then
            BtnPrePrinting.Enabled = True
        Else
            BtnPrePrinting.Enabled = False
        End If

        'ATTACH
        If check_attach_report_status(id_report_status, report_mark_type, id_prod_fc) Then
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
            dsg.id_design, dsg.design_code AS `code`, dsg.design_display_name AS `name`, s.id_season, s.season,d.delivery
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
                id_design = "-1"
                TxtOrder.Text = ""
                TxtSeason.Text = ""
                TxtDel.Text = ""
                TxtVendorCode.Text = ""
                TxtVendorName.Text = ""
                TxtStyleCode.Text = ""
                TxtStyle.Text = ""
                TxtOrder.Text = ""
                viewDetail()
                pre_viewImages("2", PEView, id_design, False)
                TxtOrder.Focus()
            Else
                id_prod_order = data.Rows(0)("id_prod_order").ToString
                id_design = data.Rows(0)("id_design").ToString
                TxtOrder.Text = data.Rows(0)("prod_order_number").ToString
                TxtSeason.Text = data.Rows(0)("season").ToString
                TxtDel.Text = data.Rows(0)("delivery").ToString
                TxtVendorCode.Text = data.Rows(0)("vendor_code").ToString
                TxtVendorName.Text = data.Rows(0)("vendor").ToString
                TxtStyleCode.Text = data.Rows(0)("code").ToString
                TxtStyle.Text = data.Rows(0)("name").ToString
                viewDetail()
                pre_viewImages("2", PEView, id_design, False)
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
        FormReportMark.report_mark_type = execute_query("SELECT report_mark_type FROM tb_prod_fc WHERE id_prod_fc = " + id_prod_fc, 0, True, "", "", "", "")
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
        FormDocumentUpload.report_mark_type = execute_query("SELECT report_mark_type FROM tb_prod_fc WHERE id_prod_fc = " + id_prod_fc, 0, True, "", "", "", "")
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
            GridColumnNumber.VisibleIndex = 2
            GridColumnFrom.VisibleIndex = 3
            GridColumnTo.VisibleIndex = 4
            GridColumnNoteSum.VisibleIndex = 5
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
            GridColumnNumber.Visible = False
            GridColumnFrom.Visible = False
            GridColumnTo.Visible = False
            GVItemList.OptionsPrint.PrintFooter = True
            GVItemList.OptionsPrint.PrintHeader = True
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
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "prod_fc_det_qty")
                ElseIf j = 2 Then 'number
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "number").ToString
                ElseIf j = 3 Then 'from
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "from").ToString
                ElseIf j = 4 Then 'to
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "to").ToString
                Else
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "prod_fc_det_note").ToString
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

    Sub print()
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

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVItemList)

        'check existing code in other trans
        makeSafeGV(GVBarcode)
        Dim cond_exist As Boolean = False
        If is_use_qc_report = "1" Then
            getCodeExisting()
            For c As Integer = 0 To GVBarcode.RowCount - 1
                Dim dt_exist_filter As DataRow() = dt_exist.Select("[full_code]='" + GVBarcode.GetRowCellValue(c, "code").ToString + "' ")
                If dt_exist_filter.Length > 0 Then
                    GVBarcode.SetRowCellValue(c, "scan_status", "Already scan in transaction number : " + dt_exist_filter(0)("number").ToString)
                Else
                    GVBarcode.SetRowCellValue(c, "scan_status", "OK")
                End If
            Next
            GVBarcode.ActiveFilterString = "[scan_status]<>'OK'"
            If GVBarcode.RowCount > 0 Then
                cond_exist = True
                GridColumnscan_status.VisibleIndex = 20
            Else
                cond_exist = False
                GridColumnscan_status.Visible = False
            End If
            GVBarcode.ActiveFilterString = ""
            makeSafeGV(GVBarcode)
        End If

        If id_comp_from = "-1" Or id_comp_to = "-1" Or id_prod_order = "-1" Or GVItemList.RowCount <= 0 Then
            stopCustom("Data can't blank")
        ElseIf cond_exist Then
            stopCustom("Barcode already scan in other transaction, please see detail in field 'scan status'")
        Else
            If action = "ins" Then
                Dim id_pl_category As String = LEPLCategory.EditValue.ToString
                Dim id_pl_category_sub As String = LECLaim.EditValue.ToString
                Dim prod_fc_note As String = addSlashes(MENote.Text.ToString)

                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to save changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim report_mark_type As String = If(id_pl_category = "1", "224", "105")
                    Dim query As String = "INSERT INTO tb_prod_fc(id_prod_order,id_prod_order_rec, id_comp_from, id_comp_to, id_pl_category, id_pl_category_sub, prod_fc_number, prod_fc_date, prod_fc_note, id_report_status, report_mark_type) "
                    query += "VALUES('" + id_prod_order + "','" + id_prod_order_rec + "','" + id_comp_from + "', '" + id_comp_to + "', '" + id_pl_category + "', '" + id_pl_category_sub + "', '" + header_number_prod("12") + "' , NOW(), '" + prod_fc_note + "', '1', '" + report_mark_type + "'); SELECT LAST_INSERT_ID(); "
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

                    'detail unique
                    If is_use_qc_report = "1" Then
                        If GVBarcode.RowCount > 0 Then
                            Dim qu As String = "INSERT INTO tb_prod_fc_counting(id_prod_fc, id_prod_order_det, id_product, full_code, note) VALUES "
                            For u As Integer = 0 To GVBarcode.RowCount - 1
                                Dim id_prod_order_det As String = GVBarcode.GetRowCellValue(u, "id_prod_order_det").ToString
                                Dim id_product As String = GVBarcode.GetRowCellValue(u, "id_product").ToString
                                Dim full_code As String = addSlashes(GVBarcode.GetRowCellValue(u, "code").ToString)
                                If u > 0 Then
                                    qu += ", "
                                End If
                                qu += "('" + id_prod_fc + "', '" + id_prod_order_det + "', '" + id_product + "', '" + full_code + "', '') "
                            Next
                            execute_non_query(qu, True, "", "", "", "")
                        End If
                    End If

                    'submit who prepared
                    submit_who_prepared(report_mark_type, id_prod_fc, id_user)


                    FormProductionFinalClear.GCProd.DataSource = Nothing
                    FormProductionFinalClear.XTCQCReport.SelectedTabPageIndex = 0
                    FormProductionFinalClear.viewFinalClear()
                    FormProductionFinalClear.GVFinalClear.FocusedRowHandle = find_row(FormProductionFinalClear.GVFinalClear, "id_prod_fc", id_prod_fc)
                    action = "upd"
                    actionLoad()
                    exportToBOF(False)
                    infoCustom("QC Result : " + TxtNumber.Text + " was created successfully.")
                    Cursor = Cursors.Default
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub PEView_DoubleClick(sender As Object, e As EventArgs) Handles PEView.DoubleClick
        Cursor = Cursors.WaitCursor
        pre_viewImages("2", PEView, id_design, True)
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowseFrom_Click(sender As Object, e As EventArgs) Handles BtnBrowseFrom.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "75"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.ShowDialog()
        If id_comp_from <> "-1" Then
            TxtCodeCompTo.Focus()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowseTo_Click(sender As Object, e As EventArgs) Handles BtnBrowseTo.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "76"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.ShowDialog()
        If id_comp_to <> "-1" Then
            TxtOrder.Focus()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowsePO_Click(sender As Object, e As EventArgs) Handles BtnBrowsePO.Click
        Cursor = Cursors.WaitCursor
        'FormPopUpProd.id_pop_up = "9"
        'FormPopUpProd.ShowDialog()
        'If id_prod_order <> "-1" Then
        'LEPLCategory.Focus()
        'End If
        FormPopUpRecQC.id_pop_up = "3"
        FormPopUpRecQC.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVItemList.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName = "from" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompFrom.Text.ToString
        ElseIf e.Column.FieldName = "to" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompTo.Text.ToString
        ElseIf e.Column.FieldName = "number" AndAlso e.IsGetData Then
            e.Value = TxtNumber.Text.ToString
        End If
    End Sub

    Private Sub BtnPrePrinting_Click(sender As Object, e As EventArgs) Handles BtnPrePrinting.Click
        'If id_report_status = "1" Then
        FormProdDemandPrintOpt.id = id_prod_fc
        FormProdDemandPrintOpt.rmt = execute_query("SELECT report_mark_type FROM tb_prod_fc WHERE id_prod_fc = " + id_prod_fc, 0, True, "", "", "", "")
        FormProdDemandPrintOpt.ShowDialog()
        ' End If
        ReportProductionFinalClear.is_pre_print = "1"
        print()
    End Sub

    Private Sub LEPLCategory_EditValueChanged(sender As Object, e As EventArgs) Handles LEPLCategory.EditValueChanged
        Cursor = Cursors.WaitCursor
        viewPLCatSub()
        Dim id_comp_cat As String = "-1"
        Try
            Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
            Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
            id_comp_cat = row("id_comp").ToString
        Catch ex As Exception
        End Try
        getCompTo(id_comp_cat)
        Cursor = Cursors.Default
    End Sub

    Sub getCompTo(ByVal id_comp_cat As String)
        'get comp to
        Dim query As String = "SELECT c.comp_number, c.comp_name FROM tb_m_comp c WHERE c.id_comp = '" + id_comp_cat + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        id_comp_to = id_comp_cat
        TxtCodeCompTo.Text = data.Rows(0)("comp_number").ToString
        TxtNameCompTo.Text = data.Rows(0)("comp_name").ToString
    End Sub

    Private Sub GVItemList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVItemList.CellValueChanged
        If GVItemList.RowCount > 0 And GVItemList.FocusedRowHandle >= 0 Then
            Dim row_foc As Integer = e.RowHandle
            If e.Column.FieldName = "prod_fc_det_qty" Then
                If Not e.Value = 0 Then
                    If e.Value > GVItemList.GetRowCellValue(row_foc, "qty_limit") Then
                        stopCustom("Can't exceed " + GVItemList.GetRowCellValue(row_foc, "qty_limit").ToString)
                        GVItemList.SetRowCellValue(row_foc, "prod_fc_det_qty", GVItemList.ActiveEditor.OldEditValue)
                        GVItemList.BestFitColumns()
                    Else
                        GVItemList.BestFitColumns()
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        If action = "ins" Then
            BDelete.Enabled = False
            BScan.Enabled = False
            BStop.Enabled = True
            LabelDelScan.Visible = True
            TxtDeleteScan.Visible = True
            TxtDeleteScan.Text = ""
            TxtDeleteScan.Focus()
        End If
    End Sub

    Private Sub TxtDeleteScan_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDeleteScan.KeyDown
        If e.KeyCode = Keys.Enter And TxtDeleteScan.Text.Length > 0 And action = "ins" Then
            Cursor = Cursors.WaitCursor
            GVBarcode.ActiveFilterString = "[code]='" + TxtDeleteScan.Text + "'"
            If GVBarcode.RowCount <= 0 Then
                stopCustom("Code not found.")
                GVBarcode.ActiveFilterString = ""
                TxtDeleteScan.Text = ""
                TxtDeleteScan.Focus()
            Else
                Dim id_prod_fc_counting As String = "-1"
                Try
                    id_prod_fc_counting = GVBarcode.GetFocusedRowCellValue("id_prod_fc_counting").ToString
                Catch ex As Exception
                End Try

                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim id_prod_order_det As String = GVBarcode.GetFocusedRowCellValue("id_prod_order_det").ToString
                    deleteRowsBc()
                    If id_prod_order_det <> "" Or id_prod_order_det <> Nothing Then
                        GVBarcode.ActiveFilterString = ""
                        countQty(id_prod_order_det)
                    End If
                    GCItemList.RefreshDataSource()
                    GVItemList.RefreshData()
                    allowDelete()
                Else
                    GVBarcode.ActiveFilterString = ""
                End If
                TxtDeleteScan.Text = ""
                TxtDeleteScan.Focus()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
        End If
    End Sub

    Sub countQty(ByVal id_prod_order_detx As String)
        Dim tot As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_prod_order_det As String = GVBarcode.GetRowCellValue(i, "id_prod_order_det").ToString
            If id_prod_order_det = id_prod_order_detx Then
                tot = tot + 1.0
            End If
        Next
        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_prod_order_det", id_prod_order_detx)
        GVItemList.SetFocusedRowCellValue("prod_fc_det_qty", tot)
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub

    Private Sub BStop_Click(sender As Object, e As EventArgs) Handles BStop.Click
        LabelDelScan.Visible = False
        TxtDeleteScan.Visible = False
        TxtDeleteScan.Text = ""
        MENote.Enabled = True
        BtnSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BtnCancel.Enabled = True
        allowDelete()
        GVItemList.OptionsBehavior.Editable = True
        ControlBox = True
        LEPLCategory.Enabled = True
        For i As Integer = 0 To (GVBarcode.RowCount - 1)
            Dim check_code As String = ""
            Try
                check_code = GVBarcode.GetRowCellValue(i, "code").ToString()
            Catch ex As Exception

            End Try
            If check_code = "" Or check_code = Nothing Or IsDBNull(check_code) Then
                GVBarcode.DeleteRow(i)
            End If
        Next
    End Sub

    Private Sub BScan_Click(sender As Object, e As EventArgs) Handles BScan.Click
        getLimitQty()
        getCodeExisting()
        MENote.Enabled = False
        BtnSave.Enabled = False
        BScan.Enabled = False
        BStop.Enabled = True
        BDelete.Enabled = False
        BtnCancel.Enabled = False
        GVItemList.OptionsBehavior.Editable = False
        ControlBox = False
        LEPLCategory.Enabled = False
        newRowsBc()
    End Sub

    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
    End Sub

    Sub getLimitQty()
        Cursor = Cursors.WaitCursor
        'Dim query As String = "SELECT pod.id_prod_order_det, pod.id_prod_order,pd_prod.id_product,
        '    IFNULL(rec.prod_order_rec_det_qty,0) AS `total_rec`,
        '    IFNULL(ro.tot_ret_out,0) AS `total_ret_out`, 
        '    IFNULL(ri.tot_ret_in,0) AS `total_ret_in`, 
        '    IFNULL(adj_in.tot_adj_in,0) AS `total_adj_in`,
        '    IFNULL(adj_out.tot_adj_out,0) AS `total_adj_out`,
        '    IFNULL(qcr.tot_qc_report,0) AS `total_qc_report`,
        '    ((SELECT total_rec) - (SELECT total_ret_out) + (SELECT total_ret_in)  + (SELECT total_adj_in) - (SELECT total_adj_out) - (SELECT total_qc_report)) AS `qty_limit`
        '    FROM tb_prod_order_det pod
        '    INNER JOIN tb_prod_demand_product pd_prod ON pd_prod.id_prod_demand_product = pod.id_prod_demand_product
        '    LEFT JOIN (
        '     SELECT b1.id_prod_order_det, b2.id_prod_order_rec, SUM(b1.prod_order_rec_det_qty) AS  prod_order_rec_det_qty
        '     FROM tb_prod_order_rec_det b1
        '     INNER JOIN tb_prod_order_rec b2 ON b1.id_prod_order_rec = b2.id_prod_order_rec
        '     WHERE b2.id_report_status =6 AND b2.id_prod_order=" + id_prod_order + "
        '     GROUP BY b1.id_prod_order_det
        '    ) rec ON rec.id_prod_order_det = pod.id_prod_order_det
        '    LEFT JOIN (
        '     SELECT d1.id_prod_order_det, d2.id_prod_order_ret_out, 
        '     SUM(d1.prod_order_ret_out_det_qty) AS tot_ret_out 
        '     FROM tb_prod_order_ret_out_det d1 
        '     INNER JOIN tb_prod_order_ret_out d2 ON d1.id_prod_order_ret_out = d2.id_prod_order_ret_out 
        '     WHERE d2.id_report_status !=5 AND d2.id_prod_order=" + id_prod_order + "
        '     GROUP BY d1.id_prod_order_det
        '    ) ro ON ro.id_prod_order_det = pod.id_prod_order_det 
        '    LEFT JOIN(
        '     SELECT e1.id_prod_order_det, e2.id_prod_order_ret_in,SUM(e1.prod_order_ret_in_det_qty) AS tot_ret_in 
        '     FROM tb_prod_order_ret_in_det e1 
        '     INNER JOIN tb_prod_order_ret_in e2 ON e1.id_prod_order_ret_in = e2.id_prod_order_ret_in 
        '     WHERE e2.id_report_status =6 AND e2.id_prod_order=" + id_prod_order + "
        '     GROUP BY e1.id_prod_order_det
        '    ) ri ON ri.id_prod_order_det = pod.id_prod_order_det
        '    LEFT JOIN(
        '     SELECT adj_in_d.id_prod_order_det, adj_in_d.id_prod_order_qc_adj_in_det,SUM(adj_in_d.prod_order_qc_adj_in_det_qty) AS tot_adj_in
        '     FROM tb_prod_order_qc_adj_in_det adj_in_d
        '     INNER JOIN tb_prod_order_qc_adj_in adj_in ON adj_in_d.id_prod_order_qc_adj_in = adj_in.id_prod_order_qc_adj_in 
        '     WHERE adj_in.id_report_status =6 AND adj_in.id_prod_order=" + id_prod_order + "
        '     GROUP BY adj_in_d.id_prod_order_det
        '    ) adj_in ON pod.id_prod_order_det = adj_in.id_prod_order_det
        '    LEFT JOIN (
        '     SELECT adj_out_d.id_prod_order_det, adj_out_d.id_prod_order_qc_adj_out_det,SUM(adj_out_d.prod_order_qc_adj_out_det_qty) AS tot_adj_out
        '     FROM tb_prod_order_qc_adj_out_det adj_out_d
        '     INNER JOIN tb_prod_order_qc_adj_out adj_out ON adj_out_d.id_prod_order_qc_adj_out = adj_out.id_prod_order_qc_adj_out 
        '     WHERE adj_out.id_report_status !=5 AND adj_out.id_prod_order=" + id_prod_order + "
        '     GROUP BY adj_out_d.id_prod_order_det
        '    ) adj_out ON pod.id_prod_order_det = adj_out.id_prod_order_det
        '    LEFT JOIN (
        '     SELECT fd.id_prod_order_det, SUM(fd.prod_fc_det_qty) AS `tot_qc_report` 
        '     FROM tb_prod_fc f
        '     INNER JOIN tb_prod_fc_det fd ON fd.id_prod_fc = f.id_prod_fc
        '     WHERE f.id_report_status!=5 AND f.id_prod_order=" + id_prod_order + "
        '     GROUP BY fd.id_prod_order_det
        '    ) qcr ON qcr.id_prod_order_det = pod.id_prod_order_det
        '    WHERE pod.id_prod_order=" + id_prod_order + " "
        Dim query As String = "SELECT pod.id_prod_order_det, pod.id_prod_order,pd_prod.id_product,
            IFNULL(rec.prod_order_rec_det_qty,0) AS `total_rec`,
            IFNULL(ro.tot_ret_out,0) AS `total_ret_out`, 
            IFNULL(ri.tot_ret_in,0) AS `total_ret_in`, 
            IFNULL(adj_in.tot_adj_in,0) AS `total_adj_in`,
            IFNULL(adj_out.tot_adj_out,0) AS `total_adj_out`,
            IFNULL(qcr.tot_qc_report,0) AS `total_qc_report`,
            ((SELECT total_rec) - (SELECT total_ret_out) + (SELECT total_ret_in)  + (SELECT total_adj_in) - (SELECT total_adj_out) - (SELECT total_qc_report)) AS `qty_limit`
            FROM tb_prod_order_det pod
            INNER JOIN tb_prod_demand_product pd_prod ON pd_prod.id_prod_demand_product = pod.id_prod_demand_product
            LEFT JOIN (
             SELECT b1.id_prod_order_det, b2.id_prod_order_rec, SUM(b1.prod_order_rec_det_qty) AS prod_order_rec_det_qty
             FROM tb_prod_order_rec_det b1
             INNER JOIN tb_prod_order_rec b2 ON b1.id_prod_order_rec = b2.id_prod_order_rec
             WHERE b2.id_report_status =6 AND b2.id_prod_order=" + id_prod_order + " AND b2.id_prod_order_rec='" + id_prod_order_rec + "'
             GROUP BY b1.id_prod_order_det
            ) rec ON rec.id_prod_order_det = pod.id_prod_order_det
            LEFT JOIN (
             SELECT d1.id_prod_order_det, d2.id_prod_order_ret_out, 
             SUM(d1.prod_order_ret_out_det_qty) AS tot_ret_out 
             FROM tb_prod_order_ret_out_det d1 
             INNER JOIN tb_prod_order_ret_out d2 ON d1.id_prod_order_ret_out = d2.id_prod_order_ret_out 
             WHERE d2.id_report_status !=5 AND d2.id_prod_order=" + id_prod_order + " AND d2.id_prod_order_rec='" + id_prod_order_rec + "'
             GROUP BY d1.id_prod_order_det
            ) ro ON ro.id_prod_order_det = pod.id_prod_order_det 
            LEFT JOIN(
             SELECT e1.id_prod_order_det, e2.id_prod_order_ret_in,SUM(e1.prod_order_ret_in_det_qty) AS tot_ret_in 
             FROM tb_prod_order_ret_in_det e1 
             INNER JOIN tb_prod_order_ret_in e2 ON e1.id_prod_order_ret_in = e2.id_prod_order_ret_in 
             WHERE e2.id_report_status =6 AND e2.id_prod_order=" + id_prod_order + " AND e2.id_prod_order_rec='" + id_prod_order_rec + "'
             GROUP BY e1.id_prod_order_det
            ) ri ON ri.id_prod_order_det = pod.id_prod_order_det
            LEFT JOIN(
             SELECT adj_in_d.id_prod_order_det, adj_in_d.id_prod_order_qc_adj_in_det,SUM(adj_in_d.prod_order_qc_adj_in_det_qty) AS tot_adj_in
             FROM tb_prod_order_qc_adj_in_det adj_in_d
             INNER JOIN tb_prod_order_qc_adj_in adj_in ON adj_in_d.id_prod_order_qc_adj_in = adj_in.id_prod_order_qc_adj_in 
             WHERE adj_in.id_report_status =6 AND adj_in.id_prod_order=" + id_prod_order + "
             GROUP BY adj_in_d.id_prod_order_det
            ) adj_in ON pod.id_prod_order_det = adj_in.id_prod_order_det
            LEFT JOIN (
             SELECT adj_out_d.id_prod_order_det, adj_out_d.id_prod_order_qc_adj_out_det,SUM(adj_out_d.prod_order_qc_adj_out_det_qty) AS tot_adj_out
             FROM tb_prod_order_qc_adj_out_det adj_out_d
             INNER JOIN tb_prod_order_qc_adj_out adj_out ON adj_out_d.id_prod_order_qc_adj_out = adj_out.id_prod_order_qc_adj_out 
             WHERE adj_out.id_report_status !=5 AND adj_out.id_prod_order=" + id_prod_order + "
             GROUP BY adj_out_d.id_prod_order_det
            ) adj_out ON pod.id_prod_order_det = adj_out.id_prod_order_det
            LEFT JOIN (
             SELECT fd.id_prod_order_det, SUM(fd.prod_fc_det_qty) AS `tot_qc_report` 
             FROM tb_prod_fc f
             INNER JOIN tb_prod_fc_det fd ON fd.id_prod_fc = f.id_prod_fc
             WHERE f.id_report_status!=5 AND f.id_prod_order=" + id_prod_order + "
             GROUP BY fd.id_prod_order_det
            ) qcr ON qcr.id_prod_order_det = pod.id_prod_order_det
            WHERE pod.id_prod_order=" + id_prod_order + " "
        Dim dt_cek As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
            Dim id_prod_order_det_cekya As String = GVItemList.GetRowCellValue(i, "id_prod_order_det").ToString

            Dim data_filter_cek As DataRow() = dt_cek.Select("[id_prod_order_det]='" + id_prod_order_det_cekya + "' ")
            If data_filter_cek.Length <= 0 Then
                GVItemList.SetRowCellValue(i, "qty_limit", 0)
            Else
                Dim qty_limit As Integer = data_filter_cek(0)("qty_limit")
                GVItemList.SetRowCellValue(i, "qty_limit", qty_limit)
            End If
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVBarcode_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVBarcode.FocusedColumnChanged
        If Not GVBarcode.FocusedColumn.FieldName = "code" Then
            GVBarcode.FocusedColumn = GVBarcode.Columns("code")
        End If
    End Sub

    Private Sub GVBarcode_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBarcode.FocusedRowChanged
        noEdit()
    End Sub

    Sub noEdit()
        Try
            Dim is_fix As String = GVBarcode.GetFocusedRowCellDisplayText("is_fix")
            'MsgBox(id_prod_order_rec_det)
            If is_fix <> "2" Then
                GridColumnBarcode.OptionsColumn.AllowEdit = True
            Else
                GridColumnBarcode.OptionsColumn.AllowEdit = False
            End If
            'MsgBox(id_prod_order_rec_det)
        Catch ex As Exception
            'errorCustom(ex.ToString)
        End Try
    End Sub

    Private Sub GVBarcode_HiddenEditor(sender As Object, e As EventArgs) Handles GVBarcode.HiddenEditor
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim code_duplicate As Boolean = False
        Dim id_prod_order_det As String = ""
        Dim id_product As String = ""
        Dim counting_code As String = ""
        Dim index_atas As Integer = 0
        Dim is_old As String = "0"
        Dim jum_scan As Integer = 0
        Dim jum_limit As Integer = 0

        'check available code
        Dim dt_filter As DataRow() = dt.Select("[product_full_code]='" + code_check + "' ")
        If dt_filter.Length > 0 Then
            counting_code = dt_filter(0)("product_counting_code").ToString
            id_prod_order_det = dt_filter(0)("id_prod_order_det").ToString
            id_product = dt_filter(0)("id_product").ToString
            is_old = dt_filter(0)("is_old_design").ToString
            code_found = True
        End If

        If is_old = "1" Then
            GVItemList.FocusedRowHandle = find_row(GVItemList, "id_prod_order_det", id_prod_order_det)
            If GVItemList.GetFocusedRowCellValue("prod_fc_det_qty") >= GVItemList.GetFocusedRowCellValue("qty_limit") Then
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                stopCustom("Can't scan. Maximum qty for size " + GVItemList.GetFocusedRowCellValue("size").ToString + " :  " + GVItemList.GetFocusedRowCellValue("qty_limit").ToString)
            Else
                GVBarcode.SetFocusedRowCellValue("id_prod_fc_counting", "0")
                GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                GVBarcode.SetFocusedRowCellValue("id_prod_order_det", id_prod_order_det)
                GVBarcode.SetFocusedRowCellValue("id_product", id_product)
                countQty(id_prod_order_det)
                newRowsBc()
            End If
        ElseIf is_old = "2" Then
            'check duplicate code
            If GVBarcode.RowCount <= 0 Then
                code_duplicate = False
            Else
                For i As Integer = 0 To (GVBarcode.RowCount - 1)
                    Dim code As String = ""
                    If Not IsDBNull(GVBarcode.GetRowCellValue(i, "code")) Then
                        code = GVBarcode.GetRowCellValue(i, "code".ToString)
                    End If

                    Dim is_fix As String = "1"
                    If Not IsDBNull(GVBarcode.GetRowCellValue(i, "is_fix")) Then
                        is_fix = GVBarcode.GetRowCellValue(i, "is_fix").ToString
                    End If

                    If code = code_check And is_fix = "2" Then
                        code_duplicate = True
                        Exit For
                    End If
                Next
            End If

            'check other trans
            Dim cond_exist As Boolean = False
            Dim err_exist As String = ""
            Dim dt_exist_filter As DataRow() = dt_exist.Select("[full_code]='" + code_check + "' ")
            If dt_exist_filter.Length > 0 Then
                cond_exist = True
                err_exist = code_check + " is already scan in transaction number : " + dt_exist_filter(0)("number").ToString
            Else
                cond_exist = False
                err_exist = ""
            End If

            If Not code_found Then
                GVBarcode.SetFocusedRowCellValue("code", "")
                stopCustom("Data not found !")
            ElseIf code_duplicate Then
                GVBarcode.SetFocusedRowCellValue("code", "")
                stopCustom("Data duplicate !")
            ElseIf cond_exist Then
                GVBarcode.SetFocusedRowCellValue("code", "")
                stopCustom(err_exist)
            Else
                GVItemList.FocusedRowHandle = find_row(GVItemList, "id_prod_order_det", id_prod_order_det)
                If GVItemList.GetFocusedRowCellValue("prod_fc_det_qty") >= GVItemList.GetFocusedRowCellValue("qty_limit") Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    stopCustom("Can't scan. Maximum qty for size " + GVItemList.GetFocusedRowCellValue("size").ToString + " :  " + GVItemList.GetFocusedRowCellValue("qty_limit").ToString)
                Else
                    GVBarcode.SetFocusedRowCellValue("id_prod_fc_counting", "0")
                    GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                    GVBarcode.SetFocusedRowCellValue("id_prod_order_det", id_prod_order_det)
                    GVBarcode.SetFocusedRowCellValue("id_product", id_product)
                    countQty(id_prod_order_det)
                    newRowsBc()
                End If
            End If
        Else
            GVBarcode.SetFocusedRowCellValue("code", "")
            stopCustom("Data not found !")
        End If
    End Sub

    Sub getCodeExisting()
        Cursor = Cursors.WaitCursor
        dt_exist.Clear()
        Dim query As String = "SELECT qu.full_code, q.prod_fc_number AS `number`
        FROM tb_prod_fc_counting qu
        INNER JOIN tb_prod_fc q ON q.id_prod_fc = qu.id_prod_fc
        INNER JOIN tb_m_product p ON p.id_product = qu.id_product
        INNER JOIN tb_m_design d ON d.id_design = p.id_design
        WHERE q.id_prod_order=" + id_prod_order + " AND q.id_report_status!=5 AND d.is_old_design=2 "
        dt_exist = execute_query(query, -1, True, "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnInfoSrs_Click(sender As Object, e As EventArgs) Handles BtnInfoSrs.Click
        FormPopUpProdDet.id_pop_up = "3"
        FormPopUpProdDet.id_prod_order_rec = id_prod_order_rec
        FormPopUpProdDet.id_prod_order = id_prod_order
        FormPopUpProdDet.BtnSave.Visible = False
        FormPopUpProdDet.is_info_form = True
        FormPopUpProdDet.ShowDialog()
    End Sub
End Class