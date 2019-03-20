Public Class FormSampleReceiveDet
    Public id_order As String = "-1"
    Public id_receive As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Dim sample_purc_rec_det_qty_inp As Decimal

    Private Sub FormSampleReceiveDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'checkFormAccess(Name)
        If Not id_order = "-1" Then
            view_list_purchase()
            view_po()
            GroupControlScannedItem.Enabled = True
            viewDetailBC()
            allowDelete()
            GroupControl2.Enabled = True
        End If

        view_report_status(LEReportStatus)
        viewComp()

        If id_receive = "-1" Then
            'new
            TERecDate.Text = view_date(0)
            TERecNumber.Text = header_number("2")
            BShowOrder.Enabled = True
            BPrint.Visible = False
            BPrePrint.Visible = False
            BMark.Visible = False
            sample_purc_rec_det_qty_inp = 0.0
        Else
            'edit
            Dim order_created As String
            Dim query = "SELECT a.id_report_status,a.sample_purc_rec_note,b.id_comp_contact_to as id_comp_from,b.id_sample_purc,a.id_comp_contact_to as id_comp_to,g.season_orign,a.id_sample_purc_rec,a.sample_purc_rec_number,DATE_FORMAT(b.sample_purc_date,'%Y-%m-%d') as sample_purc_datex,b.sample_purc_lead_time,a.delivery_order_date,a.delivery_order_number,b.sample_purc_number,DATE_FORMAT(a.sample_purc_rec_date,'%Y-%m-%d') AS sample_purc_rec_date, f.comp_name AS comp_from,d.comp_name AS comp_to "
            query += " ,drw.id_wh_drawer,rck.id_wh_rack,loc.id_wh_locator,comp.id_comp "
            query += "FROM tb_sample_purc_rec a INNER JOIN tb_sample_purc b ON a.id_sample_purc=b.id_sample_purc "
            query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=a.id_comp_contact_to "
            query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
            query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact=b.id_comp_contact_to "
            query += "INNER JOIN tb_m_comp f ON f.id_comp=e.id_comp "
            query += "LEFT JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = a.id_wh_drawer "
            query += "LEFT JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
            query += "LEFT JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
            query += "LEFT JOIN tb_m_comp comp ON comp.id_comp = loc.id_comp "
            query += "INNER JOIN tb_season_orign g ON g.id_season_orign=b.id_season_orign WHERE a.id_sample_purc_rec='" & id_receive & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            Try
                SLEStorage.EditValue = data.Rows(0)("id_comp").ToString
                SLELocator.EditValue = data.Rows(0)("id_wh_locator").ToString
                SLERack.EditValue = data.Rows(0)("id_wh_rack").ToString
                SLEDrawer.EditValue = data.Rows(0)("id_wh_drawer").ToString
            Catch ex As Exception
            End Try

            TEPONumber.Text = data.Rows(0)("sample_purc_number").ToString
            TEDONumber.Text = data.Rows(0)("delivery_order_number").ToString
            TERecNumber.Text = data.Rows(0)("sample_purc_rec_number").ToString

            id_order = data.Rows(0)("id_sample_purc").ToString
            id_comp_from = data.Rows(0)("id_comp_from").ToString
            TECompName.Text = data.Rows(0)("comp_from").ToString
            id_comp_to = data.Rows(0)("id_comp_to").ToString
            TECompShipToName.Text = data.Rows(0)("comp_to").ToString

            order_created = data.Rows(0)("sample_purc_datex").ToString
            TEOrderDate.Text = view_date_from(order_created, 0)
            TEEstRecDate.Text = view_date_from(order_created, Integer.Parse(data.Rows(0)("sample_purc_lead_time").ToString))

            TERecDate.Text = view_date_from(data.Rows(0)("sample_purc_rec_date").ToString, 0)

            ' MsgBox(data.Rows(0)("delivery_order_date").ToString)
            Dim tgl_delivery() As String = data.Rows(0)("delivery_order_date").ToString.Split(" ")
            TEDODate.Text = tgl_delivery(0)

            LEReportStatus.EditValue = Nothing
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            MENote.Text = data.Rows(0)("sample_purc_rec_note").ToString

            BShowOrder.Enabled = False
            GroupControl2.Enabled = True

            GroupControlScannedItem.Enabled = True

            TERecNumber.Enabled = False
            viewDetailBC()
            view_list_rec()
            allowDelete()
        End If
        allow_status()
    End Sub
    'view company
    Sub viewComp()
        Dim query As String = "SELECT * FROM tb_m_comp a "
        query += "INNER JOIN tb_m_comp_cat b ON a.id_comp_cat = b.id_comp_cat "
        query += "INNER JOIN tb_m_wh_locator c ON a.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_wh_rack d ON c.id_wh_locator = d.id_wh_locator "
        query += "INNER JOIN tb_m_wh_drawer e ON e.id_wh_rack = d.id_wh_rack "
        query += "GROUP BY a.id_comp ORDER BY comp_number ASC "
        viewSearchLookupQuery(SLEStorage, query, "id_comp", "comp_name", "id_comp")
    End Sub
    'Rekursif Comp-Locator
    Private Sub SLEStorage_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEStorage.EditValueChanged
        viewLoactor()
    End Sub
    Private Sub SLELocator_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocator.EditValueChanged
        viewRack()
    End Sub
    Private Sub SLERack_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERack.EditValueChanged
        viewDrawer()
    End Sub
    'View Locator
    Sub viewLoactor()
        Dim id_comp As String = ""
        Try
            id_comp = SLEStorage.EditValue.ToString
        Catch ex As Exception
            id_comp = "-1"
        End Try
        Dim query As String = ""
        query = "SELECT * FROM tb_m_wh_locator a WHERE id_comp = '" + id_comp + "'"
        viewSearchLookupQuery(SLELocator, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub
    'View Rack
    Sub viewRack()
        Dim id_locator As String = ""
        Try
            id_locator = SLELocator.EditValue.ToString
        Catch ex As Exception
            id_locator = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_rack a WHERE id_wh_locator = '" + id_locator + "'"
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub
    'View Drawer
    Sub viewDrawer()
        Dim id_rack As String = ""
        Try
            id_rack = SLERack.EditValue.ToString
        Catch ex As Exception
            id_rack = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_drawer a WHERE id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub
    Private Sub BShowOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BShowOrder.Click
        FormPopUpPurchase.id_purc = id_order
        FormPopUpPurchase.id_pop_up = "1"
        FormPopUpPurchase.ShowDialog()
    End Sub

    Sub view_po()
        Dim query As String = String.Format("SELECT id_report_status,sample_purc_vat,id_season_orign,sample_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,DATE_FORMAT(sample_purc_date,'%Y-%m-%d') as sample_purc_datex,sample_purc_lead_time,sample_purc_top,id_currency,sample_purc_note FROM tb_sample_purc WHERE id_sample_purc = '{0}'", id_order)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEPONumber.Text = data.Rows(0)("sample_purc_number").ToString

        id_comp_to = data.Rows(0)("id_comp_contact_to").ToString
        TECompName.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
        TECompShipToName.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_ship_to").ToString), "1")

        TEOrderDate.Text = view_date_from(data.Rows(0)("sample_purc_datex").ToString, 0)
        TEEstRecDate.Text = view_date_from(data.Rows(0)("sample_purc_datex").ToString, Integer.Parse(data.Rows(0)("sample_purc_lead_time").ToString))
    End Sub

    Sub view_list_rec()
        Dim query = "CALL view_purc_rec_sample_det('" & id_receive & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        If data.Rows.Count > 0 Then
            For i As Integer = 0 To data.Rows.Count - 1
                For j As Integer = 0 To data.Rows(i)("sample_purc_rec_det_qty") - 1
                    GVBarcode.AddNewRow()
                    GVBarcode.SetFocusedRowCellValue("id_sample", data.Rows(i)("id_sample"))
                    GVBarcode.SetFocusedRowCellValue("code", data.Rows(i)("code"))
                    GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                Next
            Next
            GCListPurchase.DataSource = data
            GCBarcode.RefreshDataSource()
            GVBarcode.RefreshData()
        End If
    End Sub

    Sub view_list_purchase()
        Dim query = "CALL view_purc_sample_det_limit('" & id_order & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
    End Sub

    Sub view_report_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "report_status"
        lookup.Properties.ValueMember = "id_report_status"
        lookup.ItemIndex = 0
    End Sub

    Private Sub TERecNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TERecNumber.Validating
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_sample_purc_rec) FROM tb_sample_purc_rec WHERE sample_purc_rec_number='{0}' AND id_sample_purc_rec!='{1}'", TERecNumber.Text, id_receive)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPSampleRec, TERecNumber, "1")
        Else
            EP_TE_cant_blank(EPSampleRec, TERecNumber)
        End If
    End Sub

    Private Sub BShipTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BShipTo.Click
        FormPopUpContact.id_comp_contact = id_comp_to
        FormPopUpContact.id_pop_up = "3"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub FormSampleReceiveDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_receive
        FormReportMark.report_mark_type = "2"
        FormReportMark.ShowDialog()
    End Sub

    Sub allow_status()
        'MsgBox("Allow")
        If LEReportStatus.EditValue = "3" Or LEReportStatus.EditValue = "4" Or LEReportStatus.EditValue = "6" Or LEReportStatus.EditValue = "7" Then
            BPrint.Enabled = True
            BSave.Enabled = False
            If LEReportStatus.EditValue = "6" Then
                PanelNavBarcode.Enabled = False
                PCStorage.Enabled = False
            End If
            GridColumnQtyStored.Visible = True
            GridColumnQtyStored.VisibleIndex = 6
            ColQty.Visible = False
        ElseIf LEReportStatus.EditValue = "5" Then
            BSave.Enabled = False
            BMark.Enabled = False
            PanelNavBarcode.Enabled = False
            PCStorage.Enabled = False
        Else
            If Not check_edit_report_status(LEReportStatus.EditValue, "2", id_receive) Then
                BSave.Enabled = False
            Else
                BSave.Enabled = True
            End If
            BPrint.Enabled = False
            'PanelControlStorageNav.Visible = False
            GridColumnQtyStored.Visible = False
            ColQty.Visible = True
            'ColQty.VisibleIndex = 4
        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        FormSampleStorageIn.id_sample_purc_rec_det = GVListPurchase.GetFocusedRowCellValue("id_sample_purc_rec_det").ToString
        FormSampleStorageIn.action = "ins"
        FormSampleStorageIn.id_report = id_receive
        FormSampleStorageIn.report_mark_type = "2"
        FormSampleStorageIn.ShowDialog()
        ''rec detail
        'For i As Integer = 0 To GVListPurchase.RowCount - 1
        '    Try
        '        Dim query As String = String.Format("INSERT INTO test_input(test_val) VALUES('{0}')", nominalWrite(GVListPurchase.GetRowCellValue(i, "sample_purc_rec_det_qty").ToString))
        '        execute_non_query(query, True, "", "", "", "")
        '    Catch ex As Exception
        '    End Try
        'Next
    End Sub
    'Cell Value Changed to resrict qty
    Private Sub GVListPurchase_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVListPurchase.CellValueChanged
        Try
            Dim i As Integer = sender.FocusedRowHandle
            If e.Column.FieldName = "sample_purc_rec_det_qty" Then
                Dim qty_limit As Decimal = CType(sender.GetRowCellValue(i, "qty").ToString, Decimal)
                Dim qty_rec As Decimal = CType(sender.GetRowCellValue(i, "sample_purc_rec_det_qty").ToString, Decimal)
                ' MsgBox(qty_limit.ToString)
                'MsgBox(qty_rec.ToString)
                If (qty_rec > qty_limit) Then
                    DevExpress.XtraEditors.XtraMessageBox.Show("- Qty issue must be smaller than qty ordered or equal to qty ordered !" + System.Environment.NewLine + "- Not allowed character input !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Dim qty_bound As Decimal = qty_rec - 1
                    If qty_bound < 0 Then
                        qty_bound = 0
                    End If
                    sender.SetRowCellValue(i, "sample_purc_rec_det_qty", qty_bound.ToString)
                    'sample_purc_rec_det_qty_inp.ToString
                    'Else
                    '    sender.SetRowCellValue(i, "sample_purc_rec_det_qty", qty_rec.ToString)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        '
        ReportSampleReceive.id_receive = id_receive

        Dim Report As New ReportSampleReceive()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim query As String = ""
        Dim err_txt As String = ""
        Dim rec_number, rec_date, do_number, do_date, rec_note, rec_stats As String
        Dim id_sample_rec_new As String

        ValidateChildren()

        rec_number = ""
        rec_date = ""
        do_number = ""
        do_date = ""
        rec_note = ""
        rec_stats = ""

        'validasi
        Try
            rec_number = TERecNumber.Text
            rec_date = TERecDate.Text
            do_number = TEDONumber.Text
            do_date = DateTime.Parse(TEDODate.EditValue.ToString).ToString("yyyy-MM-dd")
            If do_date = "" Then
                do_date = "0000-00-00"
            Else
                do_date = DateTime.Parse(TEDODate.EditValue.ToString).ToString("yyyy-MM-dd")
            End If
            rec_note = MENote.Text
            rec_stats = LEReportStatus.EditValue
        Catch ex As Exception
            err_txt = "1"
        End Try

        For i As Integer = 0 To GVListPurchase.RowCount - 1
            Try
                If GVListPurchase.GetRowCellValue(i, "id_sample_purc_det").ToString = "" Then
                    err_txt = "1"
                End If
            Catch ex As Exception
            End Try
        Next

        'end of validasi
        If id_receive = "-1" Then
            'new
            If err_txt = "1" Or Not formIsValidInGroup(EPSampleRec, GroupControl1) Or id_order = "-1" Or SLEDrawer.EditValue = Nothing Then
                errorInput()
            Else
                Try
                    'insert rec
                    query = String.Format("INSERT INTO tb_sample_purc_rec(id_sample_purc,sample_purc_rec_number,delivery_order_number,delivery_order_date,sample_purc_rec_date,sample_purc_rec_note,id_report_status,id_comp_contact_to,id_wh_drawer) VALUES('{0}','{1}','{2}','{3}',DATE(NOW()),'{4}','{5}','{6}','{7}'); SELECT LAST_INSERT_ID(); ", id_order, rec_number, do_number, do_date, rec_note, rec_stats, id_comp_to, SLEDrawer.EditValue.ToString)
                    id_sample_rec_new = execute_query(query, 0, True, "", "", "", "")

                    increase_inc("2")
                    'insert who prepared
                    insert_who_prepared("2", id_sample_rec_new, id_user)

                    'rec detail
                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        Try
                            If Not GVListPurchase.GetRowCellValue(i, "id_sample_purc_det").ToString = "" And isDecimal(nominalWrite(GVListPurchase.GetRowCellValue(i, "sample_purc_rec_det_qty").ToString)) Then
                                query = String.Format("INSERT INTO tb_sample_purc_rec_det(id_sample_purc_det,id_sample_purc_rec,sample_purc_rec_det_qty,sample_purc_rec_det_note) VALUES('{0}','{1}','{2}','{3}')", GVListPurchase.GetRowCellValue(i, "id_sample_purc_det").ToString, id_sample_rec_new, nominalWrite(GVListPurchase.GetRowCellValue(i, "sample_purc_rec_det_qty").ToString), GVListPurchase.GetRowCellValue(i, "sample_purc_rec_det_note").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Catch ex As Exception
                        End Try
                    Next

                    'end insert who prepared
                    FormSampleReceive.view_sample_rec()
                    FormSampleReceive.GVSampleReceive.FocusedRowHandle = find_row(FormSampleReceive.GVSampleReceive, "id_sample_purc_rec", id_sample_rec_new)
                    FormSampleReceive.XTCTabReceive.SelectedTabPageIndex = 0
                    '
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        Else
            'edit
            If err_txt = "1" Or Not formIsValidInGroup(EPSampleRec, GroupControl1) Or SLEDrawer.EditValue = Nothing Then
                errorInput()
            Else
                Try
                    'UPDATE rec
                    query = String.Format("UPDATE tb_sample_purc_rec SET delivery_order_number='{0}',delivery_order_date='{1}',sample_purc_rec_note='{2}',id_report_status='{3}',id_comp_contact_to='{4}',id_wh_drawer='{6}' WHERE id_sample_purc_rec='{5}'", do_number, do_date, rec_note, rec_stats, id_comp_to, id_receive, SLEDrawer.EditValue.ToString)
                    execute_non_query(query, True, "", "", "", "")
                    'rec detail
                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        Try
                            If Not GVListPurchase.GetRowCellValue(i, "id_sample_purc_det").ToString = "" And isDecimal(nominalWrite(GVListPurchase.GetRowCellValue(i, "sample_purc_rec_det_qty").ToString)) Then
                                query = String.Format("UPDATE tb_sample_purc_rec_det SET sample_purc_rec_det_qty='{0}',sample_purc_rec_det_note='{1}' WHERE id_sample_purc_rec_det='{2}'", nominalWrite(GVListPurchase.GetRowCellValue(i, "sample_purc_rec_det_qty").ToString), GVListPurchase.GetRowCellValue(i, "sample_purc_rec_det_note").ToString, GVListPurchase.GetRowCellValue(i, "id_sample_purc_rec_det").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Catch ex As Exception

                        End Try
                    Next

                    FormSampleReceive.view_sample_rec()
                    FormSampleReceive.GVSampleReceive.FocusedRowHandle = find_row(FormSampleReceive.GVSampleReceive, "id_sample_purc_rec", id_receive)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
    End Sub

    Private Sub GVListPurchase_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVListPurchase.ShownEditor
        Try
            sample_purc_rec_det_qty_inp = GVListPurchase.GetFocusedRowCellDisplayText("sample_purc_rec_det_qty").ToString
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub BtnSaveToStorage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveToStorage.Click
    '    FormSampleStorageIn.id_sample_purc_rec_det = GVListPurchase.GetFocusedRowCellValue("id_sample_purc_rec_det").ToString
    '    FormSampleStorageIn.action = "ins"
    '    FormSampleStorageIn.id_report = id_receive
    '    FormSampleStorageIn.report_mark_type = "2"
    '    FormSampleStorageIn.ShowDialog()
    'End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrePrint.Click
        '
        ReportSampleReceive.id_receive = id_receive
        ReportSampleReceive.id_pre = "1"

        Dim Report As New ReportSampleReceive()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BScan.Click
        If GVListPurchase.RowCount < 1 Then
            errorCustom("Please choose PO.")
        Else
            startScan()
        End If
    End Sub
    Sub startScan()
        If GVListPurchase.RowCount > 0 Then
            BSave.Enabled = False
            BScan.Enabled = False
            BStop.Enabled = True

            ControlBox = False

            BShowOrder.Enabled = False
            newRowsBc()
        Else
            errorCustom("Please choose PO.")
        End If
    End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop.Click
        stopScan()
    End Sub
    Sub stopScan()
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
        GVListPurchase.FocusedRowHandle = 0
        GCListPurchase.RefreshDataSource()
        GVListPurchase.RefreshData()

        BSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False

        ControlBox = True

        allowDelete()
        BShowOrder.Enabled = False
    End Sub
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    'DeleteRows
    Sub deleteRowsBc()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
        GVBarcode.FocusedColumn = GVBarcode.VisibleColumns(0)
        GVBarcode.ShowEditor()
    End Sub
    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVBarcode_FocusedColumnChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVBarcode.FocusedColumnChanged
        If Not GVBarcode.FocusedColumn.FieldName = "code" Then
            GVBarcode.FocusedColumn = GVBarcode.Columns("code")
        End If
    End Sub

    Private Sub GVBarcode_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBarcode.FocusedRowChanged
        noEdit()
    End Sub

    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        'CEK BARCODE
        Cursor = Cursors.WaitCursor
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim id_sample As String = ""
        Dim index_atas As Integer = 0

        'check available code
        For i As Integer = 0 To (GVListPurchase.RowCount - 1)
            Dim code As String = GVListPurchase.GetRowCellValue(i, "code").ToString
            id_sample = GVListPurchase.GetRowCellValue(i, "id_sample").ToString
            If code = code_check Then
                'cek qty
                index_atas = i
                code_found = True
                Exit For
            End If
        Next

        If Not code_found Then
            GVBarcode.SetFocusedRowCellValue("code", "")
            stopCustom("Data not found or duplicate!")
        Else
            If GVListPurchase.GetRowCellValue(index_atas, "sample_purc_rec_det_qty") >= GVListPurchase.GetRowCellValue(index_atas, "qty") Then
                GVBarcode.SetFocusedRowCellValue("code", "")
                stopCustom("Sample quantity received more than quantity ordered.")
            Else
                GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                GVBarcode.SetFocusedRowCellValue("id_sample", id_sample)
                countQty(id_sample)
                newRowsBc()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub noEdit()
        Try
            Dim is_fix As String = GVBarcode.GetFocusedRowCellDisplayText("is_fix")
            If is_fix <> "2" Then
                GridColumnBarcode.OptionsColumn.AllowEdit = True
            Else
                GridColumnBarcode.OptionsColumn.AllowEdit = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub countQty(ByVal id_sample_param As String)
        Dim tot As Decimal = 0.0
        Dim jum_amount_ret As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_sample As String = GVBarcode.GetRowCellValue(i, "id_sample").ToString
            If id_sample = id_sample_param Then
                tot = tot + 1.0
            End If
        Next

        GVListPurchase.FocusedRowHandle = find_row(GVListPurchase, "id_sample", id_sample_param)
        GVListPurchase.SetFocusedRowCellValue("sample_purc_rec_det_qty", tot)
       
        GCListPurchase.RefreshDataSource()
        GVListPurchase.RefreshData()
    End Sub
    Sub viewDetailBC()
        Dim query As String = "SELECT ('0') AS id_sample, ('') AS code, ('') AS no, ('1') AS is_fix "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
        GVBarcode.DeleteSelectedRows()
    End Sub
    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
        End If
    End Sub
    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        Dim id_samplex As String = "-1"

        Try
            id_samplex = GVBarcode.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try

        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_sample As String = GVBarcode.GetFocusedRowCellValue("id_sample").ToString
            Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString
            deleteRowsBc()
            If id_sample <> "" Or id_sample <> Nothing Then
                GVBarcode.ApplyFindFilter("")
                countQty(id_sample)
                warningCustom("tes")
            End If

            allowDelete()
        End If
    End Sub

    Private Sub SLEDrawer_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SLEDrawer.Validating
        If SLEDrawer.EditValue = Nothing Then
            EPSampleRec.SetError(SLEDrawer, "Please select storage.")
        Else
            EPSampleRec.SetError(SLEDrawer, "")
        End If
    End Sub

    Private Sub TEDODate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEDODate.Validating
        If TEDODate.EditValue = Nothing Then
            EPSampleRec.SetError(TEDODate, "Please select delivery date.")
        Else
            EPSampleRec.SetError(TEDODate, "")
        End If
    End Sub
End Class