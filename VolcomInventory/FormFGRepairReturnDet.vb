Imports Microsoft.Office.Interop

Public Class FormFGRepairReturnDet
    Public id_fg_repair_return As String = "-1"
    Public action As String = "-1"
    Public id_report_status As String = "-1"
    Public id_fg_repair_return_det_list As New List(Of String)
    Public id_pre As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_wh_locator_from As String = "-1"
    Public id_wh_rack_from As String = "-1"
    Public id_wh_drawer_from As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_wh_locator_to As String = "-1"
    Public id_wh_rack_to As String = "-1"
    Public id_wh_drawer_to As String = "-1"
    Public dt As New DataTable
    Dim is_delete_scan As Boolean = False
    Public id_type As String = "-1"
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_repair As String = get_setup_field("bof_xls_repair_return")
    Dim rmt As String = ""
    Dim is_from_vendor As String = ""


    Private Sub FormFGRepairReturnDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FormFGRepairReturn.is_from_vendor = True Then
            Text = "Receive Repair from Vendor"
            bof_xls_repair = get_setup_field("bof_xls_repair_return_from_vendor")
            rmt = "141"
            is_from_vendor = "1"
        Else
            rmt = "93"
            is_from_vendor = "2"
        End If

        viewReportStatus()
        actionLoad()
        WindowState = FormWindowState.Maximized
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            BMark.Enabled = False
            DDBPrint.Enabled = False
            DEForm.Text = view_date(0)
            TxtCodeCompFrom.Focus()
        ElseIf action = "upd" Then
            XTPSummary.PageVisible = True
            XtraTabControl1.SelectedTabPageIndex = 1
            GVScan.OptionsBehavior.AutoExpandAllGroups = True
            BMark.Enabled = True
            DDBPrint.Enabled = True

            'query view based on edit id's
            Dim query_c As ClassFGRepairReturn = New ClassFGRepairReturn()
            Dim query As String = query_c.queryMain("AND r.id_fg_repair_return='" + id_fg_repair_return + "' ", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_fg_repair_return = data.Rows(0)("id_fg_repair_return").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtNumber.Text = data.Rows(0)("fg_repair_return_number").ToString
            DEForm.Text = view_date_from(data.Rows(0)("fg_repair_return_datex").ToString, 0)
            MENote.Text = data.Rows(0)("fg_repair_return_note").ToString
            id_comp_from = data.Rows(0)("id_comp_from").ToString
            id_comp_to = data.Rows(0)("id_comp_to").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_number_to").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
            is_from_vendor = data.Rows(0)("is_from_vendor").ToString
            If is_from_vendor = "1" Then
                rmt = "141"
            Else
                rmt = "93"
            End If
            setDefaultDrawerFrom()
            setDefaultDrawerTo()

            'detail2
            viewDetail()
            viewDetailSum()
            allow_status()

            If id_pre = "1" Then
                prePrinting()
                Close()
            ElseIf id_pre = "2" Then
                printing()
                Close()
            End If
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, rmt, id_fg_repair_return) Then
            MENote.Enabled = False
            BtnSave.Enabled = False
        Else
            MENote.Enabled = False
            BtnSave.Enabled = False
        End If
        PanelNavBarcode.Enabled = False
        TxtCodeCompFrom.Enabled = False
        TxtCodeCompTo.Enabled = False
        BtnBrowseFrom.Enabled = False
        BtnBrowseTo.Enabled = False
        GridColumnQty.OptionsColumn.AllowEdit = False
        GVScan.OptionsCustomization.AllowGroup = True

        'ATTACH
        If check_attach_report_status(id_report_status, rmt, id_fg_repair_return) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_pre_print_report_status(id_report_status) Then
            BtnPrePrinting.Enabled = True
        Else
            BtnPrePrinting.Enabled = False
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
        TxtNumber.Focus()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Private Sub TxtCodeCompFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query_cond As String = ""
            If is_from_vendor = "2" Then
                query_cond = "AND comp.id_departement = '" + id_departement_user + "' "
            End If
            Dim data As DataTable = get_company_by_code(TxtCodeCompFrom.Text, query_cond)
            If data.Rows.Count = 0 Then
                stopCustom("Account not found!")
                TxtCodeCompFrom.Text = ""
                TxtNameCompFrom.Text = ""
                id_comp_from = "-1"
                TxtCodeCompFrom.Focus()
            Else
                Cursor = Cursors.WaitCursor
                id_comp_from = data.Rows(0)("id_comp").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
                setDefaultDrawerFrom()
                viewDetail()
                codeAvailableIns()
                TxtCodeCompTo.Focus()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub TxtCodeCompTo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query_cond As String = "-1"
            Dim data As DataTable = get_company_by_code(TxtCodeCompTo.Text, query_cond)
            If data.Rows.Count = 0 Then
                stopCustom("Account not found!")
                TxtCodeCompTo.Text = ""
                TxtNameCompTo.Text = ""
                id_comp_to = "-1"
                TxtCodeCompTo.Focus()
            Else
                Cursor = Cursors.WaitCursor
                id_comp_to = data.Rows(0)("id_comp").ToString
                TxtNameCompTo.Text = data.Rows(0)("comp_name").ToString
                TxtCodeCompTo.Text = data.Rows(0)("comp_number").ToString
                setDefaultDrawerTo()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Sub setDefaultDrawerFrom()
        'get drw def
        Dim data As DataTable = queryDefaultDrawer(id_comp_from)
        If data.Rows.Count > 0 Then
            id_wh_locator_from = data.Rows(0)("id_wh_locator").ToString
            id_wh_rack_from = data.Rows(0)("id_wh_rack").ToString
            id_wh_drawer_from = data.Rows(0)("id_wh_drawer").ToString
        Else
            stopCustom("There is no drawer default for this company")
            TxtCodeCompFrom.Text = ""
            TxtNameCompFrom.Text = ""
            id_comp_from = "-1"
            id_wh_locator_from = "-1"
            id_wh_rack_from = "-1"
            id_wh_drawer_from = "-1"
        End If
    End Sub

    Sub setDefaultDrawerTo()
        'get drw def
        Dim data As DataTable = queryDefaultDrawer(id_comp_to)
        If data.Rows.Count > 0 Then
            id_wh_locator_to = data.Rows(0)("id_wh_locator").ToString
            id_wh_rack_to = data.Rows(0)("id_wh_rack").ToString
            id_wh_drawer_to = data.Rows(0)("id_wh_drawer").ToString
        Else
            stopCustom("There is no drawer default for this company")
            TxtCodeCompTo.Text = ""
            TxtNameCompTo.Text = ""
            id_comp_to = "-1"
            id_wh_locator_to = "-1"
            id_wh_rack_to = "-1"
            id_wh_drawer_to = "-1"
        End If
    End Sub

    Function queryDefaultDrawer(ByVal id_comp As String) As DataTable
        Dim query As String = ""
        query += "SELECT wh.id_comp, wh.comp_number, loc.id_wh_locator, loc.wh_locator_code, rck.id_wh_rack, rck.wh_rack_code, drw.id_wh_drawer, drw.wh_drawer_code, drw.wh_drawer "
        query += "FROM tb_m_comp wh "
        query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = wh.id_drawer_def "
        query += "INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
        query += "WHERE wh.id_comp='" + id_comp + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Sub viewDetail()
        Dim query As String = "CALL view_fg_repair_return('" + id_fg_repair_return + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCScan.DataSource = data
    End Sub

    Sub viewDetailSum()
        Dim query As String = "CALL view_fg_repair_return_sum('" + id_fg_repair_return + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCScanSum.DataSource = data
        GridColumnStatus.Visible = False
        GridColumnQtyAvail.Visible = False
    End Sub

    Sub codeAvailableIns()
        SplashScreenManager1.ShowWaitForm()
        dt.Clear()
        Dim query As String = "CALL view_stock_fg_unique_repair() "
        dt = execute_query(query, -1, True, "", "", "", "")

        'not unique 
        Dim query_not As String = ""
        Dim data_not As DataTable
        If is_from_vendor = "1" Then
            query_not = "SELECT 0 AS `id_pl_prod_order_rec_det_unique`,j.id_product, prod.product_full_code AS `product_code`, '' AS `counting_code`, '' AS `product_counting_code`, prod.product_full_code, prod.product_full_code AS `code`,
            d.design_display_name AS `name`, cd.code_detail_name AS `size`, d.design_cop AS `bom_unit_price`,
            0 AS qty, 2 AS `is_rec`, d.is_old_design,
            prc.id_design_price, prc.design_price, prc.id_design_price_type, prc.design_price_type, prc.id_design_cat, prc.design_cat
            FROM tb_fg_repair_det j
            INNER JOIN tb_fg_repair jm ON jm.id_fg_repair = j.id_fg_repair
            INNER JOIN tb_m_product prod ON prod.id_product = j.id_product
            INNER JOIN tb_m_product_code prodc ON prodc.id_product = prod.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prodc.id_code_detail
            INNER JOIN tb_m_design d ON d.id_design = prod.id_design
            LEFT JOIN( 
             Select * FROM ( 
                Select price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
                price.id_design_price_type, price_type.design_price_type,
                cat.id_design_cat, cat.design_cat
                From tb_m_design_price price 
                INNER Join tb_lookup_design_price_type price_type On price.id_design_price_type = price_type.id_design_price_type 
                INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
                WHERE price.is_active_wh=1 AND price.design_price_start_date <= NOW() 
              ORDER BY price.design_price_start_date DESC, price.id_design_price DESC 
             ) a 
             GROUP BY a.id_design 
            ) prc ON prc.id_design = prod.id_design 
            WHERE d.is_old_design=1 AND jm.is_to_vendor=1 AND jm.id_wh_drawer_to=" + id_wh_drawer_from + "
            GROUP BY j.id_product "
        Else
            Dim query_c As ClassDesign = New ClassDesign()
            query_not = query_c.queryOldDesignCodeByDrawer(id_wh_drawer_from)
        End If
        data_not = execute_query(query_not, -1, True, "", "", "", "")

        'merge with not unique
        If data_not.Rows.Count > 0 Then
            If dt.Rows.Count = 0 Then
                dt = data_not
            Else
                dt.Merge(data_not, True, MissingSchemaAction.Ignore)
            End If
        End If

        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub BtnBrowseFrom_Click(sender As Object, e As EventArgs) Handles BtnBrowseFrom.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "71"
        If is_from_vendor = "2" Then
            FormPopUpContact.id_departement = id_departement_user
        End If
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowseTo_Click(sender As Object, e As EventArgs) Handles BtnBrowseTo.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "72"
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BScan_Click(sender As Object, e As EventArgs) Handles BScan.Click
        disableControl()
        is_delete_scan = False
        TxtScannedCode.Visible = True
        LblScannedCode.Visible = True
        TxtScannedCode.Focus()
    End Sub

    Sub disableControl()
        GVScan.OptionsCustomization.AllowSort = False
        BScan.Enabled = False
        BStop.Enabled = True
        BDelete.Enabled = False
        GroupGeneralHeader.Enabled = False
        GroupControl3.Enabled = False
        PanelControl3.Enabled = False
        XTPSummary.PageVisible = False
    End Sub

    Private Sub BStop_Click(sender As Object, e As EventArgs) Handles BStop.Click
        TxtScannedCode.Text = ""
        GVScan.OptionsCustomization.AllowSort = True
        TxtScannedCode.Visible = False
        LblScannedCode.Visible = False
        BStop.Enabled = False
        BScan.Enabled = True
        BDelete.Enabled = True
        GroupGeneralHeader.Enabled = True
        GroupControl3.Enabled = True
        PanelControl3.Enabled = True
        BScan.Focus()
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        disableControl()
        is_delete_scan = True
        TxtScannedCode.Visible = True
        LblScannedCode.Visible = True
        TxtScannedCode.Focus()
        'Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        'If confirm = Windows.Forms.DialogResult.Yes Then
        '    GVScan.DeleteSelectedRows()
        '    GCScan.RefreshDataSource()
        '    GVScan.RefreshData()
        'End If
    End Sub

    Private Sub TxtScannedCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtScannedCode.KeyDown
        If e.KeyCode = Keys.Enter And TxtScannedCode.Text.Length > 0 Then
            Cursor = Cursors.WaitCursor
            If Not is_delete_scan Then 'scan
                makeSafeGV(GVScan)
                checkAvailable(TxtScannedCode.Text)
                TxtScannedCode.Text = ""
                TxtScannedCode.Focus()
            Else 'delete scan
                GVScan.ActiveFilterString = "[code]='" + TxtScannedCode.Text + "'"
                If GVScan.RowCount <= 0 Then
                    stopCustom("Code not found.")
                    GVScan.ActiveFilterString = ""
                    TxtScannedCode.Text = ""
                    TxtScannedCode.Focus()
                Else
                    If action = "ins" Then
                        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Dim id_pl_prod_order_rec_det_unique As String = GVScan.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
                            GVScan.DeleteRow(GVScan.FocusedRowHandle)
                            GVScan.ActiveFilterString = ""
                            GCScan.RefreshDataSource()
                            GVScan.RefreshData()
                        Else
                            GVScan.ActiveFilterString = ""
                        End If
                        TxtScannedCode.Text = ""
                        TxtScannedCode.Focus()
                    End If
                End If
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub checkAvailable(ByVal code_par As String)
        'check in GV
        GVScan.ActiveFilterString = ""
        Dim dt_filter As DataRow() = dt.Select("[code]='" + code_par + "' ")
        If dt_filter.Length > 0 Then
            If dt_filter(0)("is_old_design").ToString = "2" Then
                GVScan.ActiveFilterString = "[code]='" + code_par + "'"
                If GVScan.RowCount > 0 Then
                    GVScan.ActiveFilterString = ""
                    stopCustom("Duplicate code")
                    Exit Sub
                Else
                    GVScan.ActiveFilterString = ""
                End If
            End If

            Dim newRow As DataRow = (TryCast(GCScan.DataSource, DataTable)).NewRow()
            newRow("id_fg_repair_return_det") = "0"
            newRow("id_fg_repair_return") = 0
            newRow("id_product") = dt_filter(0)("id_product").ToString
            newRow("code") = dt_filter(0)("code").ToString
            newRow("product_code") = dt_filter(0)("product_code").ToString
            newRow("name") = dt_filter(0)("name").ToString
            newRow("size") = dt_filter(0)("size").ToString
            newRow("id_pl_prod_order_rec_det_unique") = dt_filter(0)("id_pl_prod_order_rec_det_unique").ToString
            newRow("fg_repair_return_det_counting") = dt_filter(0)("product_counting_code").ToString
            TryCast(GCScan.DataSource, DataTable).Rows.Add(newRow)
            GCScan.RefreshDataSource()
            GVScan.RefreshData()
        Else
            stopCustom("Code not found!")
        End If
    End Sub

    Private Sub GVScan_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVScan.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVScanSum_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVScanSum.CustomColumnDisplayText
        If e.Column.Name = "GridColumnNoSum" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            ReportFGRepairReturnDet.id_pre = "1"
        Else
            ReportFGRepairReturn.id_pre = "1"
        End If
        getReport()
        Cursor = Cursors.Default
    End Sub

    Sub printing()
        Cursor = Cursors.WaitCursor
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            ReportFGRepairReturnDet.id_pre = "-1"
        Else
            ReportFGRepairReturn.id_pre = "-1"
        End If
        getReport()
        Cursor = Cursors.Default
    End Sub

    Sub getReport()
        Cursor = Cursors.WaitCursor
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            GridColumnStatus.Visible = False
            ReportFGRepairReturnDet.id_fg_repair_return = id_fg_repair_return
            ReportFGRepairReturnDet.id_type = id_type
            ReportFGRepairReturnDet.dt = GCScan.DataSource
            Dim Report As New ReportFGRepairReturnDet()

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVScan.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVScan.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVScan)

            'Parse val
            Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
            Report.LabelTo.Text = TxtCodeCompTo.Text + " - " + TxtNameCompTo.Text
            Report.LRecNumber.Text = TxtNumber.Text
            Report.LRecDate.Text = DEForm.Text
            Report.LabelNote.Text = MENote.Text
            If id_type = "1" Then
                Report.XrPanel2.Visible = False
            End If

            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
        Else
            GridColumnStatus.Visible = False
            ReportFGRepairReturn.rmt = rmt
            ReportFGRepairReturn.id_fg_repair_return = id_fg_repair_return
            ReportFGRepairReturn.id_type = id_type
            ReportFGRepairReturn.dt = GCScanSum.DataSource
            Dim Report As New ReportFGRepairReturn()

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVScanSum.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVScanSum.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVScanSum)

            'Parse val
            Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
            Report.LabelTo.Text = TxtCodeCompTo.Text + " - " + TxtNameCompTo.Text
            Report.LRecNumber.Text = TxtNumber.Text
            Report.LRecDate.Text = DEForm.Text
            Report.LabelNote.Text = MENote.Text
            If id_type = "1" Then
                Report.XrPanel2.Visible = False
            End If

            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormFGRepairDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id_fg_repair_return
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = rmt
        FormReportMark.id_report = id_fg_repair_return
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrePrinting_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrePrinting.ItemClick
        prePrinting()
    End Sub

    Private Sub BtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrint.ItemClick
        printing()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        makeSafeGV(GVScan)
        Dim cond_stc As Boolean = True

        If action = "ins" And GVScan.RowCount > 0 Then
            'insert to temporary
            XTPSummary.PageVisible = True
            XtraTabControl1.SelectedTabPageIndex = 1

            Dim data_temp As DataTable = GCScan.DataSource
            Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
            Dim connection As New MySql.Data.MySqlClient.MySqlConnection(connection_string)
            connection.Open()
            Dim command As MySql.Data.MySqlClient.MySqlCommand = connection.CreateCommand()
            Dim qry As String = "DROP TABLE IF EXISTS tb_fg_repair_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_fg_repair_temp AS ( SELECT * FROM ("
            For d As Integer = 0 To data_temp.Rows.Count - 1
                Dim id_product As String = data_temp.Rows(d)("id_product").ToString
                Dim id_pl_prod_order_rec_det_unique As String = data_temp.Rows(d)("id_pl_prod_order_rec_det_unique").ToString
                Dim code As String = data_temp.Rows(d)("code").ToString
                Dim name As String = data_temp.Rows(d)("name").ToString
                Dim size As String = data_temp.Rows(d)("size").ToString
                If d > 0 Then
                    qry += "UNION ALL "
                End If
                qry += "SELECT '" + id_product + "' AS `id_product`, '" + id_pl_prod_order_rec_det_unique + "' AS `id_pl_prod_order_rec_det_unique`, '" + code + "' AS `code`, '" + name + "' AS `name`, '" + size + "' AS `size`  "
            Next
            qry += ") a ); ALTER TABLE tb_fg_repair_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
            command.CommandText = qry
            command.ExecuteNonQuery()
            command.Dispose()
            'Console.WriteLine(qry)

            Dim data_view As New DataTable
            Dim qry_view As String = "SELECT a.id_product, a.code, a.name, a.size, COUNT(a.id_product) AS `qty` 
                                FROM tb_fg_repair_temp a 
                                GROUP BY a.id_product"
            Dim adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(qry_view, connection)
            adapter.SelectCommand.CommandTimeout = 300
            adapter.Fill(data_view)
            adapter.Dispose()

            connection.Close()
            connection.Dispose()

            'get data stock
            Dim query_stock As String = ""
            If is_from_vendor = "1" Then
                query_stock = "SELECT rd.id_product, (COUNT(rd.id_product) - IFNULL(rin.qty_in,0)) AS `qty_all_product`, prc.*
                FROM tb_fg_repair r 
                INNER JOIN tb_fg_repair_det rd ON rd.id_fg_repair = r.id_fg_repair
                INNER JOIN tb_m_product p ON p.id_product = rd.id_product
                LEFT JOIN (
	                SELECT rd.id_product, COUNT(rd.id_product) AS `qty_in`
	                FROM tb_fg_repair_return r 
	                INNER JOIN tb_fg_repair_return_det rd ON rd.id_fg_repair_return = r.id_fg_repair_return
	                WHERE r.is_from_vendor=1 AND r.id_wh_drawer_from=" + id_wh_drawer_from + " AND r.id_report_status=6
	                GROUP BY rd.id_product
                ) rin ON rin.id_product = rd.id_product
                LEFT JOIN (
	                SELECT id_design, (id_design_price) AS id_design_price_retail, (design_price) AS design_price_retail 
	                FROM (SELECT * FROM tb_m_design_price WHERE design_price_start_date<=DATE('9999-12-01') AND is_active_wh = '1' AND is_design_cost='0'
	                ORDER BY design_price_start_date DESC) prc
	                GROUP BY id_design
                ) prc ON prc.id_design = p.id_design
                WHERE r.is_to_vendor=1 AND r.id_wh_drawer_to=" + id_wh_drawer_from + " AND r.id_report_status=6
                GROUP BY rd.id_product "
            Else
                query_stock = "call view_stock_fg('" + id_comp_from + "', '" + id_wh_locator_from + "', '" + id_wh_rack_from + "', '" + id_wh_drawer_from + "', '0', '4', '9999-01-01')"
            End If
            Dim data_stock As DataTable = execute_query(query_stock, -1, True, "", "", "", "")
            Dim tb1 = data_view.AsEnumerable()
            Dim tb2 = data_stock.AsEnumerable()
            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2 On table1("id_product").ToString Equals table_tmp("id_product").ToString
                        Into Group
                        From y1 In Group.DefaultIfEmpty()
                        Select New With
                        {
                            .code = table1.Field(Of String)("code").ToString,
                            .name = table1.Field(Of String)("name").ToString,
                            .size = table1.Field(Of String)("size").ToString,
                            .qty = table1("qty"),
                            .available_qty = If(y1 Is Nothing, 0, y1("qty_all_product")),
                            .design_price_retail = If(y1 Is Nothing, 0, y1("design_price_retail")),
                            .id_product = If(y1 Is Nothing, 0, y1("id_product")),
                            .status = If(table1("qty") <= If(y1 Is Nothing, 0, y1("qty_all_product")), "OK", "Can't exceed " + If(y1 Is Nothing, "0", y1("qty_all_product").ToString))
                        }
            GCScanSum.DataSource = Nothing
            GCScanSum.DataSource = query.ToList()
            GCScanSum.RefreshDataSource()


            'find not ok
            GVScanSum.ActiveFilterString = "[status]<>'OK'"
            If GVScanSum.RowCount > 0 Then
                cond_stc = False
            Else
                cond_stc = True
            End If
            GVScanSum.ActiveFilterString = ""
        End If

        If id_wh_drawer_from = "-1" Or id_wh_drawer_to = "-1" Then
            stopCustom("Account can't blank!")
        ElseIf GVScan.RowCount <= 0
            stopCustom("Data can't blank!")
        ElseIf Not cond_stc Then
            stopCustom("Some item can't exceed qty limit, please see error in column status!")
        Else
            Dim fg_repair_return_note As String = MENote.Text.ToString
            If action = "ins" Then 'insert
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Stock qty will be updated after this process. Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    'main query
                    Dim query As String = "INSERT INTO tb_fg_repair_return(id_wh_drawer_from, id_wh_drawer_to, fg_repair_return_number, fg_repair_return_date, fg_repair_return_note, id_report_status, is_from_vendor) 
                                           VALUES('" + id_wh_drawer_from + "', '" + id_wh_drawer_to + "','" + header_number_sales("29") + "', NOW(), '" + fg_repair_return_note + "', '1', " + is_from_vendor + "); SELECT LAST_INSERT_ID(); "
                    id_fg_repair_return = execute_query(query, 0, True, "", "", "", "")
                    increase_inc_sales("29")

                    'insert who prepared
                    submit_who_prepared(rmt, id_fg_repair_return, id_user)

                    'Detail 
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVScan.RowCount > 0 Then
                        query_detail = "INSERT tb_fg_repair_return_det(id_fg_repair_return, id_product, id_pl_prod_order_rec_det_unique, fg_repair_return_det_counting) VALUES "
                    End If
                    For j As Integer = 0 To ((GVScan.RowCount - 1) - GetGroupRowCount(GVScan))
                        Dim id_product = GVScan.GetRowCellValue(j, "id_product").ToString
                        Dim id_pl_prod_order_rec_det_unique = GVScan.GetRowCellValue(j, "id_pl_prod_order_rec_det_unique").ToString
                        If id_pl_prod_order_rec_det_unique = "0" Then
                            id_pl_prod_order_rec_det_unique = "NULL"
                        End If
                        Dim fg_repair_return_det_counting As String = GVScan.GetRowCellValue(j, "fg_repair_return_det_counting").ToString

                        If jum_ins_j > 0 Then
                            query_detail += ", "
                        End If
                        query_detail += "('" + id_fg_repair_return + "', '" + id_product + "', " + id_pl_prod_order_rec_det_unique + ", '" + fg_repair_return_det_counting + "') "
                        jum_ins_j = jum_ins_j + 1
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    If is_from_vendor = "2" Then
                        'reserved stock
                        Dim rsv_stock As ClassFGRepairReturn = New ClassFGRepairReturn()
                        rsv_stock.reservedStock(id_fg_repair_return)
                    End If


                    'refresh data
                    FormFGRepairReturn.viewData()
                    FormFGRepairReturn.GVRepairReturn.FocusedRowHandle = find_row(FormFGRepairReturn.GVRepairReturn, "id_fg_repair_return", id_fg_repair_return)
                    action = "upd"
                    actionLoad()

                    'bof
                    exportToBOF(False)

                    infoCustom("Document #" + TxtNumber.Text + " was created successfully.")
                    Cursor = Cursors.Default
                End If
            Else 'update
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim query As String = "UPDATE tb_fg_repair_return SET fg_repair_return_note='" + fg_repair_return_note + "' WHERE id_fg_repair_return='" + id_fg_repair_return + "' "
                    execute_non_query(query, True, "", "", "", "")

                    'refresh data
                    FormFGRepairReturn.viewData()
                    FormFGRepairReturn.GVRepairReturn.FocusedRowHandle = find_row(FormFGRepairReturn.GVRepairReturn, "id_fg_repair_return", id_fg_repair_return)
                    action = "upd"
                    actionLoad()
                    infoCustom("Document #" + TxtNumber.Text + " was updated successfully.")
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub BtnXlsBOF_Click(sender As Object, e As EventArgs) Handles BtnXlsBOF.Click
        exportToBOF(True)
    End Sub

    Sub exportToBOF(ByVal show_msg As Boolean)
        If bof_column = "1" Then
            Cursor = Cursors.WaitCursor

            'kolom ori - creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVScanSum.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)


            'hide column
            For c As Integer = 0 To GVScanSum.Columns.Count - 1
                GVScanSum.Columns(c).Visible = False
            Next
            GridColumnCodeSum.VisibleIndex = 0
            GridColumnQty.VisibleIndex = 1
            'GVItemList.OptionsPrint.PrintFooter = False
            'GVItemList.OptionsPrint.PrintHeader = False


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

            Dim fileName As String = bof_xls_repair + ".xls"
            Dim exp As String = IO.Path.Combine(path_root, fileName)
            Try
                ExportToExcel(GVScanSum, exp, show_msg)
            Catch ex As Exception
                stopCustom("Please close your excel file first then try again later")
            End Try

            'show column
            GVScanSum.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Cursor = Cursors.Default
        End If
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
            For j As Integer = 0 To 4
                colIndex = colIndex + 1
                If j = 0 Then 'code
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "code").ToString
                ElseIf j = 1 Then 'qty
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "qty")
                ElseIf j = 2 Then 'number
                    wSheet.Cells(rowIndex + 1, colIndex) = TxtNumber.Text.ToString
                ElseIf j = 3 Then 'from
                    wSheet.Cells(rowIndex + 1, colIndex) = TxtCodeCompFrom.Text.ToString
                ElseIf j = 4 Then 'to
                    wSheet.Cells(rowIndex + 1, colIndex) = TxtCodeCompTo.Text.ToString
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