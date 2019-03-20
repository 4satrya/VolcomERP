Imports Microsoft.Office.Interop

Public Class FormSalesDelOrderSlip
    Public direct_menu As Boolean = False
    Public action As String
    Public id_pl_sales_order_del_slip As String = "-1"
    Public id_store_contact_to As String = "-1"
    Public id_comp_contact_from As String = "-1"
    Public id_wh_drawer As String = "-1"
    Public id_report_status As String
    Public id_pl_sales_order_del_slip_det_list As New List(Of String)
    Public id_pre As String = "-1"
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_so As String = get_setup_field("bof_xls_do")
    Public is_view As String = "-1"

    Private Sub FormSalesDelOrderSlip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            DDBPrint.Enabled = False
            DEForm.Text = view_date(0)

            'from pre del
            If direct_menu Then
                id_store_contact_to = FormSalesDelOrderDet.id_store_contact_to
                id_comp_contact_from = FormSalesDelOrderDet.id_comp_contact_from
                id_wh_drawer = FormSalesDelOrderDet.id_wh_drawer
                TxtNameCompFrom.Text = FormSalesDelOrderDet.TxtNameCompFrom.Text
                TxtCodeCompFrom.Text = FormSalesDelOrderDet.TxtCodeCompFrom.Text
                TxtNameCompTo.Text = FormSalesDelOrderDet.TxtNameCompTo.Text
                TxtCodeCompTo.Text = FormSalesDelOrderDet.TxtCodeCompTo.Text
                MEAdrressCompTo.Text = FormSalesDelOrderDet.MEAdrressCompTo.Text
                TxtCodeCompFrom.Properties.ReadOnly = True
                TxtCodeCompTo.Properties.ReadOnly = True
                viewSalesDelOrder()
                GCItemList.DataSource = Nothing
                GCSalesDelOrder.Focus()
            Else
                TxtCodeCompFrom.Focus()
            End If
        ElseIf action = "upd" Then
            GroupControlListItem.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BMark.Enabled = True
            DDBPrint.Enabled = True

            'query view based on edit id's
            Dim query_c As New ClassSalesDelOrder()
            Dim query As String = query_c.queryCombine("AND ac.id_combine=" + id_pl_sales_order_del_slip + " ", "1")
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_store_contact_to = data.Rows(0)("id_store_contact_to").ToString
            id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            id_wh_drawer = data.Rows(0)("id_wh_drawer").ToString
            TxtNameCompFrom.Text = data.Rows(0)("wh_name").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("wh_number").ToString
            TxtNameCompTo.Text = data.Rows(0)("store_name_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("store_number_to").ToString
            MEAdrressCompTo.Text = data.Rows(0)("store_address_to").ToString
            DEForm.Text = view_date_from(data.Rows(0)("combine_datex").ToString, 0)
            TxtSalesDelOrderNumber.Text = data.Rows(0)("combine_number").ToString
            MENote.Text = data.Rows(0)("combine_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            'main
            Dim query_cd As ClassSalesDelOrder = New ClassSalesDelOrder()
            Dim queryd As String = query_cd.queryMain("AND a.id_combine='" + id_pl_sales_order_del_slip + "' ", "1")
            Dim datad As DataTable = execute_query(queryd, -1, True, "", "", "", "")
            GCSalesDelOrder.DataSource = datad

            'detail
            Dim predel As String = ""
            For i As Integer = 0 To ((GVSalesDelOrder.RowCount - 1) - GetGroupRowCount(GVSalesDelOrder))
                If i > 0 Then
                    predel += "OR "
                End If
                predel += "k.id_pl_sales_order_del=" + GVSalesDelOrder.GetRowCellValue(i, "id_pl_sales_order_del").ToString + " "
            Next
            viewDetail(predel)
            allow_status()
            XTCDel.SelectedTabPageIndex = 1

            If id_pre = "1" Then
                prePrinting()
                Close()
            ElseIf id_pre = "2" Then
                printing()
                Close()
            End If
        End If
    End Sub


    Sub viewSalesDelOrder()
        Dim del As New ClassSalesDelOrder()
        Dim query As String = del.queryMain("AND a.id_report_status=1 AND a.is_combine=2 AND a.id_comp_contact_from='" + id_comp_contact_from + "' AND a.id_store_contact_to='" + id_store_contact_to + "' AND a.last_update_by=" + id_user + " ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesDelOrder.DataSource = data
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail(ByVal pre_delivery As String)
        Dim query As String = "CALL view_pl_sales_order_del_slip('" + pre_delivery + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "103", id_pl_sales_order_del_slip) Then
            MENote.Properties.ReadOnly = False
            GVItemList.OptionsCustomization.AllowQuickHideColumns = False
            GVItemList.OptionsCustomization.AllowGroup = False
        Else
            MENote.Properties.ReadOnly = True
            GVItemList.OptionsCustomization.AllowQuickHideColumns = True
            GVItemList.OptionsCustomization.AllowGroup = True
        End If
        GridColumnSelect.Visible = False
        PanelLoad.Visible = False
        BtnSave.Enabled = False

        'attachment
        If check_attach_report_status(id_report_status, "103", id_pl_sales_order_del_slip) Then
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

        'view form
        If is_view = "1" Then
            BtnSave.Visible = False
            BtnCancel.Visible = False
            BtnAttachment.Visible = False
            BtnXlsBOF.Visible = False
        End If

        TxtSalesDelOrderNumber.Focus()
    End Sub

    Sub getReport()
        GridColumnNo.VisibleIndex = 0
        GVItemList.ActiveFilterString = "[pl_sales_order_del_det_qty]>0"
        For i As Integer = 0 To GVItemList.RowCount - 1
            GVItemList.SetRowCellValue(i, "no", (i + 1).ToString)
        Next
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        ReportSalesDelOrderSlip.dt = GCItemList.DataSource
        ReportSalesDelOrderSlip.id_pl_sales_order_del = id_pl_sales_order_del_slip
        Dim Report As New ReportSalesDelOrderSlip()

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
        Report.LabelTo.Text = TxtCodeCompTo.Text + "-" + TxtNameCompTo.Text
        Report.LabelFrom.Text = TxtCodeCompFrom.Text + "-" + TxtNameCompFrom.Text
        Report.LabelAddress.Text = MEAdrressCompTo.Text
        Report.LRecDate.Text = DEForm.Text
        Report.LRecNumber.Text = TxtSalesDelOrderNumber.Text
        Report.LabelNote.Text = MENote.Text


        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        GVItemList.ActiveFilterString = ""
        GridColumnNo.Visible = False
    End Sub

    Private Sub BtnPrePrinting_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrePrinting.ItemClick
        prePrinting()
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        ReportSalesDelOrderSlip.id_pre = "1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrint.ItemClick
        printing()
    End Sub

    Sub printing()
        Cursor = Cursors.WaitCursor
        ReportSalesDelOrderSlip.id_pre = "-1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckSelAll.CheckedChanged
        If GVSalesDelOrder.RowCount > 0 Then
            Dim cek As String = CheckSelAll.EditValue.ToString
            For i As Integer = 0 To ((GVSalesDelOrder.RowCount - 1) - GetGroupRowCount(GVSalesDelOrder))
                If cek Then
                    GVSalesDelOrder.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVSalesDelOrder.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Private Sub BtnLoad_Click(sender As Object, e As EventArgs) Handles BtnLoad.Click
        Cursor = Cursors.WaitCursor
        GCItemList.DataSource = Nothing
        GVSalesDelOrder.ActiveFilterString = "[is_select]='Yes' "
        If GVSalesDelOrder.RowCount > 0 Then
            Dim predel As String = ""
            For i As Integer = 0 To ((GVSalesDelOrder.RowCount - 1) - GetGroupRowCount(GVSalesDelOrder))
                If i > 0 Then
                    predel += "OR "
                End If
                predel += "k.id_pl_sales_order_del=" + GVSalesDelOrder.GetRowCellValue(i, "id_pl_sales_order_del").ToString + " "
            Next
            viewDetail(predel)
            CheckSelAll.Enabled = False
            GVSalesDelOrder.OptionsBehavior.Editable = False
            BtnLoad.Enabled = False
            XTCDel.SelectedTabPageIndex = 1
        End If
        GVSalesDelOrder.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtCodeCompFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query_cond As String = "AND (comp.id_comp_cat=5 AND comp.id_departement=6 AND comp.is_active=1) "
            Dim data As DataTable = get_company_by_code(TxtCodeCompFrom.Text, query_cond)
            If data.Rows.Count = 0 Then
                stopCustom("Account not found!")
                id_comp_contact_from = "-1"
                id_wh_drawer = "-1"
                TxtCodeCompFrom.Text = ""
                TxtNameCompFrom.Text = ""
                TxtCodeCompFrom.Focus()
            Else
                Cursor = Cursors.WaitCursor
                id_comp_contact_from = data.Rows(0)("id_comp_contact").ToString
                id_wh_drawer = data.Rows(0)("id_wh_drawer").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
                TxtCodeCompTo.Focus()
                Cursor = Cursors.Default
            End If
        Else
            If Not direct_menu Then
                GCSalesDelOrder.DataSource = Nothing
                GCItemList.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub TxtCodeCompTo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query_cond As String = "AND (comp.id_comp_cat=6 AND comp.is_active=1) "
            Dim data As DataTable = get_company_by_code(TxtCodeCompTo.Text, query_cond)
            If data.Rows.Count = 0 Then
                stopCustom("Account not found!")
                id_store_contact_to = "-1"
                TxtCodeCompTo.Text = ""
                TxtNameCompTo.Text = ""
                MEAdrressCompTo.Text = ""
                TxtCodeCompTo.Focus()
            Else
                Cursor = Cursors.WaitCursor
                id_store_contact_to = data.Rows(0)("id_comp_contact").ToString
                TxtCodeCompTo.Text = data.Rows(0)("comp_number").ToString
                TxtNameCompTo.Text = data.Rows(0)("comp_name").ToString
                MEAdrressCompTo.Text = data.Rows(0)("address_primary").ToString
                viewSalesDelOrder()
                GCSalesDelOrder.Focus()
                Cursor = Cursors.Default
            End If
        Else
            If Not direct_menu Then
                GCSalesDelOrder.DataSource = Nothing
                GCItemList.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub FormSalesDelOrderSlip_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        makeSafeGV(GVSalesDelOrder)
        makeSafeGV(GVItemList)
        'makeSafeGV(GVBarcode)

        If id_comp_contact_from = "-1" Or id_store_contact_to = "-1" Then
            stopCustom("Warehouse or store can't blank")
        ElseIf GVItemList.RowCount = 0 Then
            errorCustom("Detail data can't blank")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                BtnSave.Enabled = False
                Dim combine_note As String = MENote.Text.ToString
                If action = "ins" Then
                    'query main table
                    Dim pl_sales_order_del_slip_number As String = ""
                    Dim query_main As String = "INSERT tb_pl_sales_order_del_combine(combine_number, id_comp_contact_from, id_store_contact_to, combine_date, combine_note, id_report_status, last_update, last_update_by, id_wh_drawer) "
                    query_main += "VALUES('', '" + id_comp_contact_from + "', '" + id_store_contact_to + "', NOW(), '" + combine_note + "', '1', NOW(), " + id_user + ", '" + id_wh_drawer + "'); SELECT LAST_INSERT_ID(); "
                    id_pl_sales_order_del_slip = execute_query(query_main, 0, True, "", "", "", "")


                    'Detail return
                    GVSalesDelOrder.ActiveFilterString = "[is_select]='Yes' "
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVSalesDelOrder.RowCount > 0 Then
                        query_detail = "UPDATE tb_pl_sales_order_del SET is_combine=1 , id_combine='" + id_pl_sales_order_del_slip + "' WHERE ("
                    End If
                    Dim del As String = ""
                    For j As Integer = 0 To ((GVSalesDelOrder.RowCount - 1) - GetGroupRowCount(GVSalesDelOrder))
                        Dim id_pl_sales_order_del As String = GVSalesDelOrder.GetRowCellValue(j, "id_pl_sales_order_del").ToString

                        If jum_ins_j > 0 Then
                            query_detail += "OR "
                            del += "OR "
                        End If
                        query_detail += "id_pl_sales_order_del='" + id_pl_sales_order_del + "' "
                        del += "r.id_report='" + id_pl_sales_order_del + "' "
                        jum_ins_j = jum_ins_j + 1
                    Next
                    query_detail += ") "
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'insert who prepared
                    submit_who_prepared("103", id_pl_sales_order_del_slip, id_user)

                    'update mark in delivery single
                    If del <> "" Then
                        Dim query_mark_single As String = "UPDATE tb_report_mark r SET r.report_mark_start_datetime=NULL 
                        WHERE r.report_mark_type=43 AND (" + del + ") AND r.id_report_status=3 "
                        execute_non_query(query_mark_single, True, "", "", "", "")
                    End If

                    FormSalesDelOrder.viewSalesDelOrder()
                    action = "upd"
                    makeSafeGV(GVSalesDelOrder)
                    makeSafeGV(GVItemList)
                    actionLoad()
                    exportToBOF(False)
                    infoCustom("Delivery Slip : " + TxtSalesDelOrderNumber.Text + " was created successfully.")
                End If
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Sub exportToBOF(ByVal show_msg As Boolean)
        If bof_column = "1" Then
            Cursor = Cursors.WaitCursor

            'hide column
            For c As Integer = 0 To GVItemList.Columns.Count - 1
                GVItemList.Columns(c).Visible = False
            Next
            GridColumnCode.VisibleIndex = 0
            GridColumnQty.VisibleIndex = 1
            GridColumnNumber.VisibleIndex = 2
            GridColumnFrom.VisibleIndex = 3
            GridColumnTo.VisibleIndex = 4
            GridColumnRemark.VisibleIndex = 5
            GVItemList.OptionsPrint.PrintFooter = False


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
                ExportToExcel(GVItemList, exp, show_msg)
            Catch ex As Exception
                stopCustom("Please close your excel file first then try again later")
            End Try

            'show column
            GridColumnCode.VisibleIndex = 0
            GridColumnName.VisibleIndex = 1
            GridColumnSize.VisibleIndex = 2
            GridColumnQty.VisibleIndex = 3
            GridColumnPrice.VisibleIndex = 4
            GridColumnAmount.VisibleIndex = 5
            GridColumnRemark.VisibleIndex = 6
            GridColumnRemark.Visible = False
            GridColumnNumber.Visible = False
            GridColumnFrom.Visible = False
            GridColumnTo.Visible = False
            GVItemList.OptionsPrint.PrintFooter = True
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
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "pl_sales_order_del_det_qty")
                ElseIf j = 2 Then 'number
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "number").ToString
                ElseIf j = 3 Then 'from
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "from").ToString
                ElseIf j = 4 Then 'to
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "to").ToString
                Else 'remark
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "remark")
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

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_pl_sales_order_del_slip
        FormReportMark.report_mark_type = "103"
        FormReportMark.form_origin = Name
        FormReportMark.is_disabled_set_stt = "1"
        FormReportMark.is_view = is_view
        FormReportMark.is_view_finalize = "1"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnXlsBOF_Click(sender As Object, e As EventArgs) Handles BtnXlsBOF.Click
        Cursor = Cursors.WaitCursor
        exportToBOF(True)
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_pl_sales_order_del_slip
        FormDocumentUpload.report_mark_type = "103"
        FormDocumentUpload.is_view = is_view
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVItemList.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName = "from" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompFrom.Text.ToString
        ElseIf e.Column.FieldName = "to" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompTo.Text.ToString
        ElseIf e.Column.FieldName = "number" AndAlso e.IsGetData Then
            e.Value = TxtSalesDelOrderNumber.Text.ToString
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnBrowseWH.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "78"
        FormPopUpContact.id_cat = "5"
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowseStore_Click(sender As Object, e As EventArgs) Handles BtnBrowseStore.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "79"
        FormPopUpContact.id_cat = "6"
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles GVItemList.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString
        End If
    End Sub
End Class