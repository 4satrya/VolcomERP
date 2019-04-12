Public Class FormFGTrfDet 
    Public action As String = ""
    Public id_fg_trf As String = "-1"
    Public id_comp_contact_from As String = "-1"
    Public id_comp_contact_to As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Dim dt As New DataTable
    Public id_report_status As String = "-1"
    Public id_report_status_rec As String = "-1"
    Public id_fg_trf_det_list As New List(Of String)
    Public id_fg_trf_det_counting_list As New List(Of String)
    Public id_fg_trf_det_drawer_list As New List(Of String)
    Dim is_scan As Boolean = False
    Dim id_comp_cat_wh As String = "-1"
    Public id_type As String = "-1"
    Dim is_new_rec As Boolean = False
    Public id_wh_drawer_to As String = "-1"

    Private Sub FormFGTrfDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get default store category for pick company
        id_comp_cat_wh = execute_query("SELECT id_comp_cat_wh FROM tb_opt", 0, True, "", "", "", "")

        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormFGTrfDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        Try
            'initiation datatable jika blm ada
            dt.Columns.Add("id_product")
            dt.Columns.Add("id_pl_prod_order_rec_det_unique")
            dt.Columns.Add("product_code")
            dt.Columns.Add("product_counting_code")
            dt.Columns.Add("product_full_code")
            dt.Columns.Add("bom_unit_price")
        Catch ex As Exception
        End Try

        If action = "ins" Then
            XTPOutboundScanNew.PageEnabled = False
            TxtNumber.Text = header_number_sales("15")
            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            BMark.Enabled = False
            DEForm.Text = view_date(0)
            check_but()
            check_but_drawer()

            'hide collum
            GridColumnQtyReceive.Visible = False
            GridColumnQtyStored.Visible = False
        ElseIf action = "upd" Then
            GroupControlListItem.Enabled = True
            GroupControlDrawerDetail.Enabled = True
            GroupControlScannedItem.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BtnBrowseContactFrom.Enabled = False
            BtnBrowseContactTo.Enabled = False
            XTPOutboundScanNew.PageEnabled = True


            'query view based on edit id's
            Dim query As String = ""
            query += "SELECT "
            query += "ifnull(trf.id_wh_drawer, '-1') as id_wh_drawer, ifnull(drw.wh_drawer_code,'') AS wh_drawer_code, ifnull(drw.wh_drawer, '') as wh_drawer, "
            query += "trf.id_fg_trf, trf.fg_trf_number, DATE_FORMAT(trf.fg_trf_date_rec, '%Y-%m-%d') AS fg_trf_date_recx, DATE_FORMAT(trf.fg_trf_date, '%Y-%m-%d') AS fg_trf_datex, trf.fg_trf_note, trf.id_report_status, trf.id_report_status_rec, rep_status.report_status, "
            query += "IF(ISNULL(trf.fg_trf_date_rec), DATE_FORMAT(NOW(), '%Y-%m-%d'),  DATE_FORMAT(trf.fg_trf_date_rec, '%Y-%m-%d')) AS fg_trf_date_recx, "
            query += "(comp_from.id_comp) AS id_comp_from, (comp_from.comp_number) AS comp_number_from, (comp_from.comp_name) AS comp_name_from, "
            query += "(comp_to.id_comp) AS id_comp_to, (comp_to.comp_number) AS comp_number_to, (comp_to.comp_name) AS comp_name_to, "
            query += "trf.id_comp_contact_from, trf.id_comp_contact_to "
            query += "FROM tb_fg_trf trf "
            query += "INNER JOIN tb_m_comp_contact comp_con_from ON trf.id_comp_contact_from = comp_con_from.id_comp_contact "
            query += "INNER JOIN tb_m_comp comp_from ON comp_con_from.id_comp = comp_from.id_comp "
            query += "INNER JOIN tb_m_comp_contact comp_con_to ON trf.id_comp_contact_to = comp_con_to.id_comp_contact "
            query += "INNER JOIN tb_m_comp comp_to ON comp_con_to.id_comp = comp_to.id_comp "
            query += "INNER JOIN tb_lookup_report_status rep_status ON trf.id_report_status = rep_status.id_report_status "
            query += "LEFT JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = trf.id_wh_drawer "
            query += "WHERE trf.id_fg_trf = '" + id_fg_trf + "' "
            query += "ORDER BY trf.id_fg_trf DESC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_fg_trf = data.Rows(0)("id_fg_trf").ToString
            id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
            id_comp_from = data.Rows(0)("id_comp_from").ToString
            id_comp_to = data.Rows(0)("id_comp_to").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_report_status_rec = data.Rows(0)("id_report_status_rec").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_number_to").ToString
            TxtNumber.Text = data.Rows(0)("fg_trf_number").ToString
            DEForm.Text = view_date_from(data.Rows(0)("fg_trf_datex").ToString, 0)
            MENote.Text = data.Rows(0)("fg_trf_note").ToString
            id_wh_drawer_to = data.Rows(0)("id_wh_drawer").ToString
            TxtDrawerCode.Text = data.Rows(0)("wh_drawer_code").ToString
            TEDrawer.Text = data.Rows(0)("wh_drawer").ToString

            'Receive TRF
            If id_type = "1" Then
                'updated 30 December 2014
                LabelControlDrawer.Visible = True
                TxtDrawerCode.Visible = True
                TEDrawer.Visible = True
                BPickDrawer.Visible = True

                LEReportStatus2.Visible = True
                BtnBrowseContactFrom.Visible = False
                BtnBrowseContactTo.Visible = False
                XTPOutboundScanNew.PageVisible = False
                XTPOutboundItemNew.PageVisible = False
                XTPInboundScanNew.PageVisible = True
                GroupControl1.Enabled = True
                If IsDBNull(data.Rows(0)("id_report_status_rec")) Or data.Rows(0)("id_report_status_rec").ToString = "" Then
                    is_new_rec = True
                    BMark.Enabled = False
                    DEForm.Text = view_date(0)
                    LEReportStatus2.ItemIndex = LEReportStatus2.Properties.GetDataSourceRowIndex("id_report_status", "1")
                    BtnSave.Enabled = True
                Else
                    is_new_rec = False
                    BMark.Enabled = True
                    DEForm.Text = view_date_from(data.Rows(0)("fg_trf_date_recx").ToString, 0)
                    LEReportStatus2.ItemIndex = LEReportStatus2.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status_rec").ToString)
                    BtnSave.Enabled = False
                End If
                MENote.Visible = False
                LabelControl18.Visible = False
                LabelControl2.Visible = True
                BtnAdd.Visible = False
                BtnEdit.Visible = False
                BtnDel.Visible = False
                GridColumnQtyWH.Visible = False
                GridColumnRemark.Visible = False
            Else
                GridColumnQtyReceive.Visible = False
                GridColumnQtyStored.Visible = False
            End If

            'detail2
            viewDetail()
            view_barcode_list()
            viewDetailDrawer()
            check_but()
            check_but_drawer()
            allow_status()
        End If
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
        viewLookupQuery(LEReportStatus2, query, 0, "report_status", "id_report_status")
    End Sub


    'sub check_but
    Sub check_but()
        Dim id_productx As String = "0"
        Try
            id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try

        'Constraint Status
        If GVItemList.RowCount > 0 And id_productx <> "0" Then
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
            BtnAddDrawer.Enabled = True
            BtnEditDrawer.Enabled = True
            BtnDelDrawer.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
            BtnAddDrawer.Enabled = False
            BtnEditDrawer.Enabled = False
            BtnDelDrawer.Enabled = False
        End If
    End Sub

    Sub check_but_drawer()
        Dim id_wh_drawer_ As String = "0"
        Try
            id_wh_drawer_ = GVDrawer.GetFocusedRowCellValue("id_wh_drawer").ToString
        Catch ex As Exception
        End Try

        If GVDrawer.RowCount > 0 And id_wh_drawer_ <> "0" Then
            BtnEditDrawer.Enabled = True
            BtnDelDrawer.Enabled = True
        Else
            BtnEditDrawer.Enabled = False
            BtnDelDrawer.Enabled = False
        End If
    End Sub

    Sub allow_status()
        If id_type = "-1" Then
            If check_edit_report_status(id_report_status, "57", id_fg_trf) Then
                BtnAdd.Enabled = True
                BtnEdit.Enabled = True
                BtnDel.Enabled = True
                PanelControlNavDetail.Enabled = True
                PanelNavBarcode.Enabled = True
                MENote.Properties.ReadOnly = False
                GVItemList.OptionsCustomization.AllowGroup = False
                BtnSave.Enabled = True
            Else
                BtnAdd.Enabled = False
                BtnEdit.Enabled = False
                BtnDel.Enabled = False
                PanelControlNavDetail.Enabled = False
                PanelNavBarcode.Enabled = False
                MENote.Properties.ReadOnly = True
                GVItemList.OptionsCustomization.AllowGroup = True
                BtnSave.Enabled = False
            End If

            'ATTACH
            If check_attach_report_status(id_report_status, "57", id_fg_trf) Then
                BtnAttachment.Enabled = True
            Else
                BtnAttachment.Enabled = False
            End If

            If check_print_report_status(id_report_status) Then
                BtnPrint.Enabled = True
            Else
                BtnPrint.Enabled = False
            End If
        ElseIf id_type = "1" Then
            If check_edit_report_status(id_report_status_rec, "58", id_fg_trf) Or is_new_rec = True Then
                GVItemList.OptionsBehavior.Editable = True
                PanelNavBarcode2.Enabled = True
                BtnSave.Enabled = True
                BPickDrawer.Enabled = True
                GVItemList.OptionsCustomization.AllowGroup = False
            Else
                GVItemList.OptionsBehavior.Editable = False
                PanelNavBarcode2.Enabled = False
                BtnSave.Enabled = False
                BPickDrawer.Enabled = False
                GVItemList.OptionsCustomization.AllowGroup = True
            End If

            'ATTACH
            If check_attach_report_status(id_report_status_rec, "58", id_fg_trf) Then
                BtnAttachment.Enabled = True
            Else
                BtnAttachment.Enabled = False
            End If

            'Print
            If check_print_report_status(id_report_status_rec) Then
                BtnPrint.Enabled = True
            Else
                BtnPrint.Enabled = False
            End If

            'Btn Storage
            If check_storage_report_status(id_report_status_rec) Then
                BtnStorage.Enabled = True
                'GridColumnQtyStored.Visible = True
            Else
                BtnStorage.Enabled = False
                GridColumnQtyStored.Visible = False
            End If

        End If
        TxtNumber.Focus()
    End Sub

    Sub view_barcode_list()
        If action = "ins" Then
            Dim query As String = "SELECT ('0') AS no, ('') AS code, ('0') AS id_fg_trf_det, ('0') AS id_pl_prod_order_rec_det_unique, ('0') AS id_product,('1') AS is_fix, ('') AS counting_code, ('0') AS id_fg_trf_det_counting "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBarcode.DataSource = data
            deleteRowsBc()
            allowDelete()
        ElseIf action = "upd" Then
            Dim query As String = ""
            query += "SELECT ('') AS no, CONCAT(c.product_full_code, a.fg_trf_det_counting) AS code, "
            query += "(a.fg_trf_det_counting) AS counting_code, "
            query += "a.id_fg_trf_det_counting, ('2') AS is_fix, "
            query += "a.id_pl_prod_order_rec_det_unique, b.id_product "
            query += "FROM tb_fg_trf_det_counting a "
            query += "INNER JOIN tb_fg_trf_det b ON a.id_fg_trf_det = b.id_fg_trf_det "
            query += "INNER JOIN tb_m_product c ON c.id_product = b.id_product "
            query += "WHERE b.id_fg_trf = '" + id_fg_trf + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_fg_trf_det_counting_list.Add(data.Rows(i)("id_fg_trf_det_counting").ToString)
            Next
            GCBarcode.DataSource = data

            Dim query2 As String = ""
            query2 += "SELECT ('') AS no, CONCAT(c.product_full_code, a.fg_trf_det_counting) AS code, "
            query2 += "(a.fg_trf_det_counting) AS counting_code, "
            query2 += "a.id_fg_trf_det_counting, ('2') AS is_fix, "
            query2 += "a.id_pl_prod_order_rec_det_unique, b.id_product "
            query2 += "FROM tb_fg_trf_det_counting a "
            query2 += "INNER JOIN tb_fg_trf_det b ON a.id_fg_trf_det = b.id_fg_trf_det "
            query2 += "INNER JOIN tb_m_product c ON c.id_product = b.id_product "
            query2 += "WHERE b.id_fg_trf = '" + id_fg_trf + "' AND a.is_valid = '1' "
            Dim data2 As DataTable = execute_query(query2, -1, True, "", "", "", "")
            GCBarcode2.DataSource = data2
        End If
    End Sub

    Sub viewDetail()
        If action = "ins" Then
            'action
            Dim query As String = "CALL view_fg_trf('" + id_fg_trf + "')"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            GCItemList.DataSource = data
        ElseIf action = "upd" Then
            Dim id_param As String = ""
            Dim query As String = "CALL view_fg_trf('" + id_fg_trf + "')"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_fg_trf_det_list.Add(data.Rows(i)("id_fg_trf_det").ToString)
                id_param = id_param + data.Rows(i)("id_product").ToString
                If i < (data.Rows.Count - 1) Then
                    id_param = id_param + ";"
                End If
            Next
            GCItemList.DataSource = data
            Me.codeAvailableIns(id_param)
        End If
    End Sub

    Sub viewDetailDrawer()
        Dim query As String = "CALL view_fg_trf_drw('" + id_fg_trf + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_fg_trf_det_drawer_list.Add(data.Rows(i)("id_fg_trf_det_drawer").ToString)
        Next
        GCDrawer.DataSource = data
    End Sub
    '-------------------------------------------------------------------------------------
    'SAAT INI PARAMETER HANYA ID PROD KARENA PRODUCTION HANYA ADA 1 COST (19 Sept 2014)
    '-----------------------------------------------------------------------------------
    Sub codeAvailableIns(ByVal id_product_param As String)
        dt.Clear()
        Dim query As String = ""
        query = "CALL view_stock_fg_unique_del('" + id_product_param + "')"
        Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
        For k As Integer = 0 To (datax.Rows.Count - 1)
            insertDt(datax.Rows(k)("id_product").ToString, datax.Rows(k)("id_pl_prod_order_rec_det_unique").ToString, datax.Rows(k)("product_code").ToString, datax.Rows(k)("product_counting_code").ToString, datax.Rows(k)("product_full_code").ToString, Decimal.Parse(datax.Rows(k)("bom_unit_price").ToString))
        Next
    End Sub

    Sub codeAvailableDel(ByVal id_product_param As String)
        Dim i As Integer = dt.Rows.Count - 1
        While (i >= 0)
            If dt.Rows(i)("id_product").ToString = id_product_param Then
                dt.Rows.RemoveAt(i)
            End If
            i = i - 1
        End While
    End Sub

    Sub insertDt(ByVal id_product_param As String, ByVal id_pl_prod_order_rec_det_unique_param As String, ByVal product_code_param As String, ByVal product_counting_code_param As String, ByVal product_full_code_param As String, ByVal cost_param As Decimal)
        Dim R As DataRow = dt.NewRow
        R("id_product") = id_product_param
        R("id_pl_prod_order_rec_det_unique") = id_pl_prod_order_rec_det_unique_param
        R("product_code") = product_code_param
        R("product_counting_code") = product_counting_code_param
        R("product_full_code") = product_full_code_param
        R("bom_unit_price") = cost_param
        dt.Rows.Add(R)
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
    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    Sub newRowsBc2()
        GVBarcode2.AddNewRow()
        GVBarcode2.FocusedRowHandle = GVBarcode.RowCount - 1
        GCBarcode2.RefreshDataSource()
        GVBarcode2.RefreshData()
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
        End If
    End Sub

    Sub noEdit()
        Try
            Dim is_fix As String = GVBarcode.GetFocusedRowCellDisplayText("is_fix")
            'MsgBox(id_pl_prod_order_rec_det)
            If is_fix <> "2" Then
                GridColumnBarcode.OptionsColumn.AllowEdit = True
            Else
                GridColumnBarcode.OptionsColumn.AllowEdit = False
            End If
            'MsgBox(id_pl_prod_order_rec_det)
        Catch ex As Exception
            'errorCustom(ex.ToString)
        End Try
    End Sub

    Sub noEdit2()
        Try
            Dim is_fix As String = GVBarcode2.GetFocusedRowCellDisplayText("is_fix")
            If is_fix <> "2" Then
                GridColumn2.OptionsColumn.AllowEdit = True
            Else
                GridColumn2.OptionsColumn.AllowEdit = False
            End If
        Catch ex As Exception
            'errorCustom(ex.ToString)
        End Try
    End Sub

    Sub countQty(ByVal id_product_param As String)
        Dim tot As Decimal = 0.0
        'MsgBox(id_product_param)
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_product As String = GVBarcode.GetRowCellValue(i, "id_product").ToString
            If id_product = id_product_param Then
                tot = tot + 1.0
            End If
        Next


        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_product", id_product_param)
        GVItemList.SetFocusedRowCellValue("fg_trf_det_qty", tot)

        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub

    Sub countQty2(ByVal id_product_param As String)
        Dim tot As Decimal = 0.0
        For i As Integer = 0 To GVBarcode2.RowCount - 1
            Dim id_product As String = GVBarcode2.GetRowCellValue(i, "id_product").ToString
            If id_product = id_product_param Then
                tot = tot + 1.0
            End If
        Next


        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_product", id_product_param)
        GVItemList.SetFocusedRowCellValue("fg_trf_det_qty_rec", tot)

        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        If id_type = "-1" Then
            FormReportMark.report_mark_type = "57"
        ElseIf id_type = "1" Then
            FormReportMark.report_mark_type = "58"
        End If
        FormReportMark.id_report = id_fg_trf
        FormReportMark.form_origin = Name
        FormReportMark.is_view_finalize = "1"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BScan.Click
        If GVItemList.RowCount < 1 Then
            errorCustom("Please add product required !")
        Else
            'FormFGStockOpnameStoreSingle.id_pop_up = "1"
            'FormFGStockOpnameStoreSingle.ShowDialog()
            startScan()
        End If

    End Sub

    Sub startScan()
        If GVItemList.RowCount > 0 Then
            is_scan = True
            MENote.Enabled = False
            BtnSave.Enabled = False
            BScan.Enabled = False
            BStop.Enabled = True
            BDelete.Enabled = False
            BtnCancel.Enabled = False
            GVItemList.OptionsBehavior.Editable = False
            ControlBox = False
            TxtNumber.Enabled = False
            newRowsBc()
            'allowDelete()
        Else
            errorCustom("Item list can't blank")
        End If
    End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop.Click
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
        GVItemList.FocusedRowHandle = 0
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()

        is_scan = False
        MENote.Enabled = True
        BtnSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BtnCancel.Enabled = True
        allowDelete()
        GVItemList.OptionsBehavior.Editable = True
        ControlBox = True
        TxtNumber.Enabled = True
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        Dim id_fg_trf_det_counting As String = "-1"
        Try
            id_fg_trf_det_counting = GVBarcode.GetFocusedRowCellValue("id_fg_trf_det_counting").ToString
        Catch ex As Exception
        End Try

        If action = "ins" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
                Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
                Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
                Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

                deleteRowsBc()
                If id_product <> "" Or id_product <> Nothing Then
                    GVBarcode.ApplyFindFilter("")
                    countQty(id_product)
                End If

                allowDelete()
            End If
        ElseIf action = "upd" Then
            If id_fg_trf_det_counting = "0" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
                    Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
                    Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
                    Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

                    deleteRowsBc()
                    If id_product <> "" Or id_product <> Nothing Then
                        GVBarcode.ApplyFindFilter("")
                        countQty(id_product)
                    End If

                    allowDelete()
                End If
            Else
                errorCustom("This data already locked and can't delete.")
            End If
        End If
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
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

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        Cursor = Cursors.WaitCursor
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim code_duplicate As Boolean = False
        Dim code_item_found As Boolean = False
        Dim counting_code As String = ""
        Dim id_pl_prod_order_rec_det_unique As String = ""
        Dim id_product As String = ""
        Dim bom_unit_price As Decimal = 0.0
        Dim id_design_price As String = ""
        Dim design_price As Decimal = 0.0

        'check available code
        For i As Integer = 0 To (dt.Rows.Count - 1)
            Dim code As String = dt.Rows(i)("product_full_code").ToString
            counting_code = dt.Rows(i)("product_counting_code").ToString
            id_pl_prod_order_rec_det_unique = dt.Rows(i)("id_pl_prod_order_rec_det_unique").ToString
            id_product = dt.Rows(i)("id_product").ToString
            bom_unit_price = Decimal.Parse(dt.Rows(i)("bom_unit_price").ToString)
            If code = code_check Then
                code_found = True
                Exit For
            End If
        Next

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

        'check in item list
        For g As Integer = 0 To GVItemList.RowCount - 1
            Dim id_product_item As String = GVItemList.GetRowCellValue(g, "id_product").ToString
            Try
                If id_product = id_product_item Then
                    code_item_found = True
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next

        If Not code_found Then
            GVBarcode.SetFocusedRowCellValue("code", "")
            stopCustom("Data not found or duplicate!")
        ElseIf code_duplicate Then
            GVBarcode.SetFocusedRowCellValue("code", "")
            stopCustom("Data duplicate !")
        ElseIf Not code_item_found Then
            GVBarcode.SetFocusedRowCellValue("code", "")
            stopCustom("Data not found or duplicate!")
        Else
            GVBarcode.SetFocusedRowCellValue("id_pl_prod_order_rec_det_unique", id_pl_prod_order_rec_det_unique)
            GVBarcode.SetFocusedRowCellValue("id_fg_trf_det_counting", "0")
            GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            GVBarcode.SetFocusedRowCellValue("counting_code", counting_code)
            GVBarcode.SetFocusedRowCellValue("id_product", id_product)
            GVBarcode.SetFocusedRowCellValue("bom_unit_price", bom_unit_price)
            countQty(id_product)
            newRowsBc()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub deleteDetailBC(ByVal id_product_param As String)
        'delete detail
        Dim i As Integer = GVBarcode.RowCount - 1
        While (i >= 0)
            Dim id_product As String = ""
            Try
                id_product = GVBarcode.GetRowCellValue(i, "id_product").ToString()
            Catch ex As Exception

            End Try
            If id_product = id_product_param Then
                GVBarcode.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub

    Sub deleteDetailDrawer(ByVal id_product_param As String)
        'delete detail
        Dim i As Integer = GVDrawer.RowCount - 1
        While (i >= 0)
            Dim id_product As String = ""
            Try
                id_product = GVDrawer.GetRowCellValue(i, "id_product").ToString()
            Catch ex As Exception

            End Try
            If id_product = id_product_param Then
                GVDrawer.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub

    Private Sub BtnAddDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddDrawer.Click
        Cursor = Cursors.WaitCursor
        Dim id_product As String = "-1"
        Try
            id_product = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try
        FormSalesDelOrderSingle.id_comp = id_comp_from
        FormSalesDelOrderSingle.id_pop_up = "1"
        FormSalesDelOrderSingle.id_product = "0"
        FormSalesDelOrderSingle.action_pop = "ins"
        FormSalesDelOrderSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnEditDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditDrawer.Click
        Cursor = Cursors.WaitCursor
        Dim id_product As String = "-1"
        Dim id_fg_trf_det_drawer As String = "-1"
        Dim id_wh_drawer As String = "-1"
        Dim qty_edit As Decimal = 0.0
        Try
            id_product = GVItemList.GetFocusedRowCellValue("id_product").ToString
            id_fg_trf_det_drawer = GVDrawer.GetFocusedRowCellValue("id_fg_trf_det_drawer").ToString
            id_wh_drawer = GVDrawer.GetFocusedRowCellValue("id_wh_drawer").ToString
            qty_edit = GVDrawer.GetFocusedRowCellValue("fg_trf_det_drawer_qty")
        Catch ex As Exception
        End Try

        If action = "ins" Then
            FormSalesDelOrderSingle.id_comp = id_comp_from
            FormSalesDelOrderSingle.id_pop_up = "1"
            FormSalesDelOrderSingle.indeks_edit = GVDrawer.FocusedRowHandle
            FormSalesDelOrderSingle.id_product = id_product
            FormSalesDelOrderSingle.action_pop = "upd"
            FormSalesDelOrderSingle.ShowDialog()
        ElseIf action = "upd" Then
            If id_fg_trf_det_drawer = "0" Then
                FormSalesDelOrderSingle.id_comp = id_comp_from
                FormSalesDelOrderSingle.id_pop_up = "1"
                FormSalesDelOrderSingle.indeks_edit = GVDrawer.FocusedRowHandle
                FormSalesDelOrderSingle.id_product = id_product
                FormSalesDelOrderSingle.action_pop = "upd"
                FormSalesDelOrderSingle.ShowDialog()
            Else
                errorCustom("This data already locked and can't edit.")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelDrawer.Click
        Cursor = Cursors.WaitCursor
        Dim id_fg_trf_det_drawer As String = "-1"
        Try
            id_fg_trf_det_drawer = GVDrawer.GetFocusedRowCellValue("id_fg_trf_det_drawer").ToString
        Catch ex As Exception
        End Try

        If action = "ins" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this drawer?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_productx As String = GVDrawer.GetFocusedRowCellValue("id_product").ToString
                GVDrawer.DeleteRow(GVDrawer.FocusedRowHandle)
                GCDrawer.RefreshDataSource()
                GVDrawer.RefreshData()
                countQtyFromWh(id_productx)
                check_but_drawer()
            End If
        ElseIf action = "upd" Then
            If id_fg_trf_det_drawer = "0" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this drawer?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim id_productx As String = GVDrawer.GetFocusedRowCellValue("id_product").ToString
                    GVDrawer.DeleteRow(GVDrawer.FocusedRowHandle)
                    GCDrawer.RefreshDataSource()
                    GVDrawer.RefreshData()
                    countQtyFromWh(id_productx)
                    check_but_drawer()
                End If
            Else
                'cek uda ada product yg di scan ato blm
                errorCustom("This data already locked and can't delete.")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub countQtyFromWh(ByVal id_product_param As String)
        Dim jum As Decimal = 0.0
        For i As Integer = 0 To (GVDrawer.RowCount - 1)
            Try
                Dim id_product_i As String = GVDrawer.GetRowCellValue(i, "id_product").ToString
                If id_product_i = id_product_param Then
                    jum = jum + Decimal.Parse(GVDrawer.GetRowCellValue(i, "qty_all_product"))
                End If
            Catch ex As Exception

            End Try
        Next
        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_product", id_product_param)
        GVItemList.SetFocusedRowCellValue("qty_from_wh", jum)
        allowScanPage()

    End Sub

    Sub allowScanPage()
        'allow page scan
        Dim allow_scan = True
        For i As Integer = 0 To (GVItemList.RowCount - 1)
            Try
                Dim qty_wh_cek As Decimal = Decimal.Parse(GVItemList.GetRowCellValue(i, "qty_from_wh"))
                If qty_wh_cek = 0.0 Then
                    allow_scan = False
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next
        'MsgBox(allow_scan)
        If Not allow_scan Or (GVItemList.RowCount <= 0) Then
            XTPOutboundScanNew.PageEnabled = False
        Else
            XTPOutboundScanNew.PageEnabled = True
        End If
    End Sub

    'Color Cell
    Public Sub my_color_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White

        Try
            Dim id_product_style As String = GVItemList.GetFocusedRowCellValue("id_product").ToString
            Dim id_product_check As String = View.GetRowCellValue(e.RowHandle, View.Columns("id_product"))
            If id_product_check = id_product_style Then
                e.Appearance.BackColor = Color.Lavender
                e.Appearance.BackColor2 = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub my_color_cell_wht(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White
    End Sub


    Private Sub BtnBrowseContactFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "48"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.id_cat = id_comp_cat_wh
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactTo.Click
        FormPopUpContact.id_pop_up = "49"
        FormPopUpContact.id_cat = id_comp_cat_wh
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormFGStockOpnameWHSingle.id_pop_up = "1"
        FormFGStockOpnameWHSingle.id_wh = id_comp_from
        FormFGStockOpnameWHSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim id_fg_trf_det As String = "-1"
        Try
            id_fg_trf_det = GVItemList.GetFocusedRowCellValue("id_fg_trf_det").ToString
        Catch ex As Exception
        End Try
        Dim id_product As String = GVItemList.GetFocusedRowCellValue("id_product").ToString
        If id_fg_trf_det = "0" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
                GCItemList.RefreshDataSource()
                GVItemList.RefreshData()
                codeAvailableDel(id_product)
                deleteDetailBC(id_product)
                deleteDetailDrawer(id_product)
                check_but()
                Cursor = Cursors.Default
            End If
        Else
            'cek uda ada product yg di scan ato blm
            errorCustom("This data already locked and can't delete.")
        End If
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
        check_but()
        AddHandler GVDrawer.RowCellStyle, AddressOf my_color_cell
        GCDrawer.RefreshDataSource()
        GVDrawer.RefreshData()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        makeSafeGV(GVBarcode)
        makeSafeGV(GVBarcode2)
        makeSafeGV(GVItemList)
        makeSafeGV(GVDrawer)

        If id_type = "-1" Then
            Cursor = Cursors.WaitCursor
            ValidateChildren()

            'cek kesamaan from wh dengan scan
            Dim is_same_qty As Boolean = True
            For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                Try
                    Dim qty_from_wh As Decimal = Decimal.Parse(GVItemList.GetRowCellValue(i, "qty_from_wh"))
                    Dim fg_trf_det_qty As Decimal = Decimal.Parse(GVItemList.GetRowCellValue(i, "fg_trf_det_qty"))
                    If qty_from_wh <> fg_trf_det_qty Then
                        is_same_qty = False
                        Exit For
                    End If
                Catch ex As Exception
                End Try
            Next

            'cek qty limit rack
            Dim available_stock As Boolean = True
            Dim warning_stock As String = ""
            For ix As Integer = 0 To ((GVDrawer.RowCount - 1) - GetGroupRowCount(GVDrawer))
                Try
                    Dim id_fg_trf_det_drawer As String = GVDrawer.GetRowCellValue(ix, "id_fg_trf_det_drawer").ToString
                    If id_fg_trf_det_drawer = "0" Then
                        Dim qty_all_product As Decimal = GVDrawer.GetRowCellValue(ix, "qty_all_product").ToString
                        Dim id_wh_drawer As String = GVDrawer.GetRowCellValue(ix, "id_wh_drawer").ToString
                        Dim drawer As String = GVDrawer.GetRowCellValue(ix, "drawer").ToString
                        Dim id_wh_rack As String = GVDrawer.GetRowCellValue(ix, "id_wh_rack").ToString
                        Dim id_wh_locator As String = GVDrawer.GetRowCellValue(ix, "id_wh_locator").ToString
                        Dim id_comp As String = GVDrawer.GetRowCellValue(ix, "id_comp").ToString
                        Dim id_product As String = GVDrawer.GetRowCellValue(ix, "id_product").ToString
                        Dim query_cek_stok As String = "CALL view_stock_fg('" + id_comp + "','" + id_wh_locator + "','" + id_wh_rack + "','" + id_wh_drawer + "', '" + id_product + "','4', '9999-01-01')"
                        Dim data_cek_stok As DataTable = execute_query(query_cek_stok, -1, True, "", "", "", "")
                        If qty_all_product > data_cek_stok.Rows(0)("qty_all_product") Then
                            available_stock = False
                            warning_stock = "Out item in " + drawer + " cannot exceed " + data_cek_stok.Rows(0)("qty_all_product") + ""
                            Exit For
                        End If
                    End If
                Catch ex As Exception

                End Try
            Next

            If Not formIsValidInGroup(EPForm, GroupGeneralHeader) Then
                errorInput()
            ElseIf GVItemList.RowCount = 0 Or GVDrawer.RowCount = 0 Or GVBarcode.RowCount = 0 Then
                errorCustom("Transfer item, drawer detail, and scanned item data can't blank")
            ElseIf Not is_same_qty Then
                errorCustom("Qty from wh not equal to qty transfer, please check your input !")
            ElseIf Not available_stock Then
                errorCustom(warning_stock)
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Stock qty will be updated after this process. Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    BtnSave.Enabled = False
                    Dim fg_trf_number As String = TxtNumber.Text
                    Dim fg_trf_note As String = MENote.Text.ToString
                    If action = "ins" Then
                        'query main table
                        Dim query_main As String = "INSERT tb_fg_trf(fg_trf_number, id_comp_contact_from, id_comp_contact_to, fg_trf_date, fg_trf_note, id_report_status) "
                        query_main += "VALUES('" + fg_trf_number + "', '" + id_comp_contact_from + "', '" + id_comp_contact_to + "', NOW(), '" + fg_trf_note + "', '1'); SELECT LAST_INSERT_ID(); "
                        id_fg_trf = execute_query(query_main, 0, True, "", "", "", "")
                        increase_inc_sales("15")

                        'insert who prepared
                        insert_who_prepared("57", id_fg_trf, id_user)

                        'Detail return
                        Dim jum_ins_j As Integer = 0
                        Dim query_detail As String = ""
                        If GVItemList.RowCount > 0 Then
                            query_detail = "INSERT tb_fg_trf_det(id_fg_trf, id_product, fg_trf_det_qty, fg_trf_det_note) VALUES "
                        End If
                        For j As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                            Try
                                Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                                Dim fg_trf_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "fg_trf_det_qty").ToString)
                                Dim fg_trf_det_note As String = GVItemList.GetRowCellValue(j, "fg_trf_det_note").ToString

                                If jum_ins_j > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "('" + id_fg_trf + "', '" + id_product + "', '" + fg_trf_det_qty + "', '" + fg_trf_det_note + "') "
                                jum_ins_j = jum_ins_j + 1
                            Catch ex As Exception
                                'MsgBox(ex.ToString)
                            End Try
                        Next
                        If GVItemList.RowCount > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If

                        'get all detail id
                        Dim query_get_detail_id As String = "SELECT a.id_fg_trf_det, a.id_product "
                        query_get_detail_id += "FROM tb_fg_trf_det a "
                        query_get_detail_id += "WHERE a.id_fg_trf = '" + id_fg_trf + "' "
                        Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")

                        'drawer
                        Dim jum_ins_s As Integer = 0
                        Dim query_drawer As String = ""
                        Dim query_drawer_stock As String = ""
                        If GVDrawer.RowCount > 0 Then
                            query_drawer = "INSERT INTO tb_fg_trf_det_drawer(id_fg_trf_det, id_wh_drawer, bom_unit_price, fg_trf_det_drawer_qty) VALUES "
                            query_drawer_stock = "INSERT tb_storage_fg(id_wh_drawer, id_storage_category, id_product, storage_product_qty, storage_product_datetime, storage_product_notes, bom_unit_price, report_mark_type, id_report, id_stock_status) VALUES "
                        End If
                        For s As Integer = 0 To ((GVDrawer.RowCount - 1) - GetGroupRowCount(GVDrawer))
                            Dim id_product_drawer As String = GVDrawer.GetRowCellValue(s, "id_product")
                            Dim id_wh_drawer As String = GVDrawer.GetRowCellValue(s, "id_wh_drawer")
                            Dim bom_unit_price As String = decimalSQL(GVDrawer.GetRowCellValue(s, "bom_unit_price").ToString)
                            Dim fg_trf_det_drawer_qty As String = decimalSQL(GVDrawer.GetRowCellValue(s, "qty_all_product").ToString)
                            Dim id_fg_trf_det_drawer As String = ""
                            For s1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                                If id_product_drawer = data_get_detail_id.Rows(s1)("id_product").ToString Then
                                    If jum_ins_s > 0 Then
                                        query_drawer += ", "
                                        query_drawer_stock += ", "
                                    End If
                                    query_drawer += "('" + data_get_detail_id.Rows(s1)("id_fg_trf_det").ToString + "', '" + id_wh_drawer + "', '" + bom_unit_price + "', '" + fg_trf_det_drawer_qty + "') "
                                    query_drawer_stock += "('" + id_wh_drawer + "', '2', '" + id_product_drawer + "', '" + fg_trf_det_drawer_qty + "', NOW(), 'Transfer No: " + fg_trf_number + "', '" + bom_unit_price + "', '57', '" + id_fg_trf + "', '2') "
                                    jum_ins_s = jum_ins_s + 1
                                    Exit For
                                End If
                            Next
                        Next
                        If GVDrawer.RowCount > 0 Then
                            execute_non_query(query_drawer, True, "", "", "", "")
                        End If

                        'counting
                        Dim jum_ins_p As Integer = 0
                        Dim query_counting As String = ""
                        If GVBarcode.RowCount > 0 Then
                            query_counting = "INSERT INTO tb_fg_trf_det_counting(id_fg_trf_det, id_pl_prod_order_rec_det_unique, fg_trf_det_counting) VALUES "
                        End If
                        For p As Integer = 0 To (GVBarcode.RowCount - 1)
                            Dim id_product_counting As String = GVBarcode.GetRowCellValue(p, "id_product")
                            Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetRowCellValue(p, "id_pl_prod_order_rec_det_unique").ToString
                            Dim fg_trf_det_counting As String = GVBarcode.GetRowCellValue(p, "counting_code").ToString
                            For p1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                                If id_product_counting = data_get_detail_id.Rows(p1)("id_product").ToString Then
                                    If jum_ins_p > 0 Then
                                        query_counting += ", "
                                    End If
                                    query_counting += "('" + data_get_detail_id.Rows(p1)("id_fg_trf_det").ToString + "', '" + id_pl_prod_order_rec_det_unique + "', '" + fg_trf_det_counting + "') "
                                    jum_ins_p = jum_ins_p + 1
                                    Exit For
                                End If
                            Next
                        Next
                        If GVBarcode.RowCount > 0 Then
                            execute_non_query(query_counting, True, "", "", "", "")
                        End If

                        'insert stock
                        If jum_ins_s > 0 Then
                            execute_non_query(query_drawer_stock, True, "", "", "", "")
                        End If

                        FormFGTrf.viewFGTrf()
                        FormFGTrf.viewFGTrf()
                        FormFGTrf.GVFGTrf.FocusedRowHandle = find_row(FormFGTrf.GVFGTrf, "id_fg_trf", id_fg_trf)
                        Close()
                    ElseIf action = "upd" Then
                        'update main table
                        Dim query_main As String = "UPDATE tb_fg_trf SET fg_trf_number = '" + fg_trf_number + "', id_comp_contact_from = '" + id_comp_contact_from + "', id_comp_contact_to = '" + id_comp_contact_to + "', fg_trf_note = '" + fg_trf_note + "' WHERE id_fg_trf = '" + id_fg_trf + "' "
                        execute_non_query(query_main, True, "", "", "", "")

                        'update detail table
                        Dim jum_ins_j As Integer = 0
                        Dim query_detail As String = ""
                        If GVItemList.RowCount > 0 Then
                            query_detail = "INSERT tb_fg_trf_det(id_fg_trf, id_product, fg_trf_det_qty, fg_trf_det_note) "
                        End If
                        For j As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                            Try
                                Dim id_fg_trf_det As String = GVItemList.GetRowCellValue(j, "id_fg_trf_det").ToString
                                Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                                Dim fg_trf_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "fg_trf_det_qty").ToString)
                                Dim fg_trf_det_note As String = GVItemList.GetRowCellValue(j, "fg_trf_det_note").ToString

                                If id_fg_trf_det = "0" Then
                                    If jum_ins_j > 0 Then
                                        query_detail += ", "
                                    End If
                                    query_detail += "VALUES('" + id_fg_trf + "', '" + id_product + "', '" + fg_trf_det_qty + "', '" + fg_trf_det_note + "') "
                                    jum_ins_j = jum_ins_j + 1
                                Else
                                    Dim query_detail_upd As String = "UPDATE tb_fg_trf_det SET id_product = '" + id_product + "', fg_trf_det_qty = '" + fg_trf_det_qty + "', fg_trf_det_note = '" + fg_trf_det_note + "' WHERE id_fg_trf_det = '" + id_fg_trf_det + "'"
                                    execute_non_query(query_detail_upd, True, "", "", "", "")
                                    id_fg_trf_det_list.Remove(id_fg_trf_det)
                                End If
                            Catch ex As Exception
                                'MsgBox(ex.ToString)
                            End Try
                        Next
                        If GVItemList.RowCount > 0 And jum_ins_j > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If

                        For j_del As Integer = 0 To (id_fg_trf_det_list.Count - 1)
                            Try
                                Dim query_detail_del As String = "DELETE FROM tb_fg_trf_det WHERE id_fg_trf_det = '" + id_fg_trf_det_list(j_del) + "'"
                                execute_non_query(query_detail_del, True, "", "", "", "")
                            Catch ex As Exception

                            End Try
                        Next

                        'get all detail id
                        Dim query_get_detail_id As String = "SELECT a.id_fg_trf_det, a.id_product "
                        query_get_detail_id += "FROM tb_fg_trf_det a "
                        query_get_detail_id += "WHERE a.id_fg_trf = '" + id_fg_trf + "' "
                        Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")

                        'update drawer
                        Dim jum_ins_s As Integer = 0
                        Dim query_drawer As String = ""
                        Dim query_drawer_stock As String = ""
                        If GVDrawer.RowCount > 0 Then
                            query_drawer = "INSERT INTO tb_fg_trf_det_drawer(id_fg_trf_det, id_wh_drawer, bom_unit_price, fg_trf_det_drawer_qty) VALUES "
                            query_drawer_stock = "INSERT tb_storage_fg(id_wh_drawer, id_storage_category, id_product, storage_product_qty, storage_product_datetime, storage_product_notes, bom_unit_price, report_mark_type, id_report, id_stock_status) VALUES "
                        End If
                        For s As Integer = 0 To ((GVDrawer.RowCount - 1) - GetGroupRowCount(GVDrawer))
                            Dim id_fg_trf_det_drawer As String = GVDrawer.GetRowCellValue(s, "id_fg_trf_det_drawer")
                            Dim id_product_drawer As String = GVDrawer.GetRowCellValue(s, "id_product")
                            Dim id_wh_drawer As String = GVDrawer.GetRowCellValue(s, "id_wh_drawer")
                            Dim bom_unit_price As String = decimalSQL(GVDrawer.GetRowCellValue(s, "bom_unit_price").ToString)
                            Dim fg_trf_det_drawer_qty As String = decimalSQL(GVDrawer.GetRowCellValue(s, "qty_all_product").ToString)
                            For s1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                                If id_fg_trf_det_drawer = "0" Then
                                    If id_product_drawer = data_get_detail_id.Rows(s1)("id_product").ToString Then
                                        If jum_ins_s > 0 Then
                                            query_drawer += ", "
                                            query_drawer_stock += ", "
                                        End If
                                        query_drawer += "('" + data_get_detail_id.Rows(s1)("id_fg_trf_det").ToString + "', '" + id_wh_drawer + "', '" + bom_unit_price + "', '" + fg_trf_det_drawer_qty + "') "
                                        query_drawer_stock += "('" + id_wh_drawer + "', '2', '" + id_product_drawer + "', '" + fg_trf_det_drawer_qty + "', NOW(), 'Finished Goods Transfer No: " + fg_trf_number + "', '" + bom_unit_price + "', '57', '" + id_fg_trf + "', '2') "
                                        jum_ins_s = jum_ins_s + 1
                                        Exit For
                                    End If
                                End If
                            Next
                        Next
                        If GVDrawer.RowCount > 0 And jum_ins_s > 0 Then
                            execute_non_query(query_drawer, True, "", "", "", "")
                        End If

                        'update counting
                        Dim jum_ins_p As Integer = 0
                        Dim query_counting As String = ""
                        If GVBarcode.RowCount > 0 Then
                            query_counting = "INSERT INTO tb_fg_trf_det_counting(id_fg_trf_det, id_pl_prod_order_rec_det_unique, fg_trf_det_counting) VALUES "
                        End If
                        For p As Integer = 0 To (GVBarcode.RowCount - 1)
                            Dim id_fg_trf_det_counting As String = GVBarcode.GetRowCellValue(p, "id_fg_trf_det_counting").ToString
                            Dim id_product_counting As String = GVBarcode.GetRowCellValue(p, "id_product")
                            Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetRowCellValue(p, "id_pl_prod_order_rec_det_unique").ToString
                            Dim fg_trf_det_counting As String = GVBarcode.GetRowCellValue(p, "counting_code").ToString
                            For p1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                                If id_fg_trf_det_counting = "0" Then
                                    If id_product_counting = data_get_detail_id.Rows(p1)("id_product").ToString Then
                                        If jum_ins_p > 0 Then
                                            query_counting += ", "
                                        End If
                                        query_counting += "('" + data_get_detail_id.Rows(p1)("id_fg_trf_det").ToString + "', '" + id_pl_prod_order_rec_det_unique + "', '" + fg_trf_det_counting + "') "
                                        jum_ins_p = jum_ins_p + 1
                                        Exit For
                                    End If
                                End If
                            Next
                        Next
                        If GVBarcode.RowCount > 0 And jum_ins_p > 0 Then
                            execute_non_query(query_counting, True, "", "", "", "")
                        End If

                        'insert stock
                        If jum_ins_s > 0 Then
                            execute_non_query(query_drawer_stock, True, "", "", "", "")
                        End If

                        FormFGTrf.viewFGTrf()
                        FormFGTrf.GVFGTrf.FocusedRowHandle = find_row(FormFGTrf.GVFGTrf, "id_fg_trf", id_fg_trf)
                        Close()
                    End If
                    Cursor = Cursors.Default
                End If
            End If
            Cursor = Cursors.Default
        ElseIf id_type = "1" Then
            Cursor = Cursors.WaitCursor
            ValidateChildren()

            'cek kesamaan from wh dengan scan
            Dim is_same_qty As Boolean = True
            For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                Try
                    Dim fg_trf_det_qty_rec As Decimal = Decimal.Parse(GVItemList.GetRowCellValue(i, "fg_trf_det_qty_rec"))
                    Dim fg_trf_det_qty As Decimal = Decimal.Parse(GVItemList.GetRowCellValue(i, "fg_trf_det_qty"))
                    If fg_trf_det_qty_rec <> fg_trf_det_qty Then
                        is_same_qty = False
                        Exit For
                    End If
                Catch ex As Exception
                End Try
            Next

            If Not formIsValidInGroup(EPForm, GroupGeneralHeader) Then
                errorInput()
            ElseIf GVBarcode2.RowCount = 0 Then
                errorCustom("Scanned item data can't blank")
            ElseIf Not is_same_qty Then
                errorCustom("Qty receive not equal to qty transfer, please check your input !")
            ElseIf id_wh_drawer_to = "-1" Then
                errorCustom("Drawer can't blank, please select drawer!")
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor

                    'update main table
                    Dim query_main As String = "UPDATE tb_fg_trf SET id_wh_drawer='" + id_wh_drawer_to + "', id_report_status_rec = '1', fg_trf_date_rec = NOW() WHERE id_fg_trf = '" + id_fg_trf + "' "
                    execute_non_query(query_main, True, "", "", "", "")

                    'insert who prepared
                    insert_who_prepared("58", id_fg_trf, id_user)

                    Dim query_valid_det As String = ""
                    query_valid_det += "UPDATE tb_fg_trf_det a "
                    query_valid_det += "INNER JOIN tb_fg_trf b ON a.id_fg_trf = b.id_fg_trf "
                    query_valid_det += "SET a.fg_trf_det_qty_rec = a.fg_trf_det_qty "
                    query_valid_det += "WHERE a.id_fg_trf = '" + id_fg_trf + "' "
                    execute_non_query(query_valid_det, True, "", "", "", "")

                    'update valid
                    Dim query_valid As String = ""
                    query_valid += "UPDATE tb_fg_trf_det_counting a "
                    query_valid += "INNER JOIN tb_fg_trf_det b ON a.id_fg_trf_det = b.id_fg_trf_det SET a.is_valid = '1' "
                    query_valid += "WHERE b.id_fg_trf = '" + id_fg_trf + "' "
                    execute_non_query(query_valid, True, "", "", "", "")


                    FormFGTrfReceive.viewFGTrf()
                    Close()
                    Cursor = Cursors.Default
                End If
            End If


            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BScan2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BScan2.Click
        is_scan = True
        MENote.Enabled = False
        BtnSave.Enabled = False
        BScan2.Enabled = False
        BStop2.Enabled = True
        BtnCancel.Enabled = False
        GVItemList.OptionsBehavior.Editable = False
        ControlBox = False
        TxtNumber.Enabled = False
        newRowsBc2()
    End Sub


    Private Sub BStop2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop2.Click
        For i As Integer = 0 To (GVBarcode2.RowCount - 1)
            Dim check_code As String = ""
            Try
                check_code = GVBarcode2.GetRowCellValue(i, "code").ToString()
            Catch ex As Exception

            End Try
            If check_code = "" Or check_code = Nothing Or IsDBNull(check_code) Then
                GVBarcode2.DeleteRow(i)
            End If
        Next
        GVItemList.FocusedRowHandle = 0
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()

        is_scan = False
        BtnSave.Enabled = True
        BScan2.Enabled = True
        BStop2.Enabled = False
        BtnCancel.Enabled = True
        GVItemList.OptionsBehavior.Editable = True
        ControlBox = True
        TxtNumber.Enabled = True
    End Sub

    Private Sub GVBarcode2_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode2.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub


    Private Sub GVBarcode2_FocusedColumnChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVBarcode2.FocusedColumnChanged
        If Not GVBarcode2.FocusedColumn.FieldName = "code" Then
            GVBarcode2.FocusedColumn = GVBarcode2.Columns("code")
        End If
    End Sub

    Private Sub GVBarcode2_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBarcode2.FocusedRowChanged
        noEdit2()
    End Sub


    Private Sub GVBarcode2_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode2.HiddenEditor
        Cursor = Cursors.WaitCursor
        Dim code_check As String = GVBarcode2.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim code_duplicate As Boolean = False
        Dim code_item_found As Boolean = False
        Dim code_valid_found As Boolean = False
        Dim counting_code As String = ""
        Dim id_pl_prod_order_rec_det_unique As String = ""
        Dim id_product As String = ""
        Dim bom_unit_price As Decimal = 0.0
        Dim id_design_price As String = ""
        Dim design_price As Decimal = 0.0

        'check available code
        For i As Integer = 0 To (dt.Rows.Count - 1)
            Dim code As String = dt.Rows(i)("product_full_code").ToString
            counting_code = dt.Rows(i)("product_counting_code").ToString
            id_pl_prod_order_rec_det_unique = dt.Rows(i)("id_pl_prod_order_rec_det_unique").ToString
            id_product = dt.Rows(i)("id_product").ToString
            bom_unit_price = Decimal.Parse(dt.Rows(i)("bom_unit_price").ToString)
            If code = code_check Then
                code_found = True
                Exit For
            End If
        Next

        'check duplicate code
        If GVBarcode2.RowCount <= 0 Then
            code_duplicate = False
        Else
            For i As Integer = 0 To (GVBarcode2.RowCount - 1)
                Dim code As String = ""
                If Not IsDBNull(GVBarcode2.GetRowCellValue(i, "code")) Then
                    code = GVBarcode2.GetRowCellValue(i, "code".ToString)
                End If

                Dim is_fix As String = "1"
                If Not IsDBNull(GVBarcode2.GetRowCellValue(i, "is_fix")) Then
                    is_fix = GVBarcode2.GetRowCellValue(i, "is_fix").ToString
                End If

                If code = code_check And is_fix = "2" Then
                    code_duplicate = True
                    Exit For
                End If
            Next
        End If

        'check in item list
        For g As Integer = 0 To GVItemList.RowCount - 1
            Dim id_product_item As String = GVItemList.GetRowCellValue(g, "id_product").ToString
            Try
                If id_product = id_product_item Then
                    code_item_found = True
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next

        'check trf
        For v As Integer = 0 To GVBarcode.RowCount - 1
            Dim code_trf As String = ""
            Try
                code_trf = GVBarcode.GetRowCellValue(v, "code").ToString
            Catch ex As Exception
            End Try
            If code_check = code_trf Then
                code_valid_found = True
                Exit For
            End If
        Next

        If Not code_found Then
            GVBarcode2.SetFocusedRowCellValue("code", "")
            stopCustom("Data not found or duplicate!")
        ElseIf code_duplicate Then
            GVBarcode2.SetFocusedRowCellValue("code", "")
            stopCustom("Data duplicate !")
        ElseIf Not code_item_found Then
            GVBarcode2.SetFocusedRowCellValue("code", "")
            stopCustom("Data not found or duplicate!")
        ElseIf Not code_valid_found Then
            GVBarcode2.SetFocusedRowCellValue("code", "")
            stopCustom("Data not found!")
        Else
            GVBarcode2.SetFocusedRowCellValue("id_pl_prod_order_rec_det_unique", id_pl_prod_order_rec_det_unique)
            GVBarcode2.SetFocusedRowCellValue("id_fg_so_wh_det_counting", "0")
            GVBarcode2.SetFocusedRowCellValue("is_fix", "2")
            GVBarcode2.SetFocusedRowCellValue("counting_code", counting_code)
            GVBarcode2.SetFocusedRowCellValue("id_product", id_product)
            GVBarcode2.SetFocusedRowCellValue("bom_unit_price", bom_unit_price)
            countQty2(id_product)
            newRowsBc2()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnStorage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStorage.Click
        Cursor = Cursors.WaitCursor
        Dim fg_trf_det_qty_stored As Decimal = Decimal.Parse(GVItemList.GetFocusedRowCellValue("fg_trf_det_qty_stored"))
        Dim fg_trf_det_qty_rec As Decimal = Decimal.Parse(GVItemList.GetFocusedRowCellValue("fg_trf_det_qty_rec"))
        If fg_trf_det_qty_rec <> fg_trf_det_qty_stored Then
            'FormProductionStorageIn.cost = Decimal.Parse(TxtUnitCost.EditValue.ToString)
            Dim id_fg_trf_det = GVItemList.GetFocusedRowCellValue("id_fg_trf_det").ToString
            Dim costx As Decimal = 0.0
            For i As Integer = 0 To GVDrawer.RowCount - 1
                Dim id_fg_trf_det_cek As String = "0"
                Try
                    id_fg_trf_det_cek = GVDrawer.GetRowCellValue(i, "id_fg_trf_det").ToString
                    If id_fg_trf_det_cek = id_fg_trf_det Then
                        costx = Decimal.Parse(GVDrawer.GetRowCellValue(i, "bom_unit_price").ToString)
                        Exit For
                    End If
                Catch ex As Exception
                End Try
            Next
            'MsgBox(costx.ToString)
            FormProductionStorageIn.id_pop_up = "5"
            FormProductionStorageIn.cost = costx
            FormProductionStorageIn.id_transaction_det = id_fg_trf_det
            FormProductionStorageIn.id_design = GVItemList.GetFocusedRowCellValue("id_design").ToString
            FormProductionStorageIn.id_product = GVItemList.GetFocusedRowCellValue("id_product").ToString
            FormProductionStorageIn.id_sample = GVItemList.GetFocusedRowCellValue("id_sample").ToString
            FormProductionStorageIn.action = "ins"
            FormProductionStorageIn.colorku = GVItemList.GetFocusedRowCellValue("color").ToString
            FormProductionStorageIn.sizeku = GVItemList.GetFocusedRowCellValue("size").ToString
            FormProductionStorageIn.id_report = id_fg_trf
            FormProductionStorageIn.report_mark_type = "58"
            FormProductionStorageIn.id_wh = id_comp_to
            FormProductionStorageIn.ShowDialog()
        Else
            errorCustom("- All item for this product has been stored in warehouse" + System.Environment.NewLine + "- If yo want to edit location storage, please edit on 'Warehouse & Locator' menu")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTest.Click
        FormViewFGTrf.id_fg_trf = id_fg_trf
        'FormViewFGTrf.id_type = "1"
        FormViewFGTrf.ShowDialog()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportFGTrf.id_fg_trf = id_fg_trf
        ReportFGTrf.id_type = id_type
        ReportFGTrf.dt = GCItemList.DataSource
        Dim Report As New ReportFGTrf()

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
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        If id_type = "-1" Then
            FormDocumentUpload.report_mark_type = "57"
        ElseIf id_type = "1" Then
            FormDocumentUpload.report_mark_type = "58"
        End If
        FormDocumentUpload.id_report = id_fg_trf
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDrawer_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDrawer.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnPrintDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintDrawer.Click
        Cursor = Cursors.WaitCursor
        AddHandler GVDrawer.RowCellStyle, AddressOf my_color_cell_wht
        ReportStyleGridview(GVDrawer)
        print(GCDrawer, "Item List Based on Drawer")
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDrawer_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDrawer.FocusedRowChanged
        check_but_drawer()
    End Sub

    Private Sub BPickDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickDrawer.Click
        FormPopUpDrawer.id_pop_up = "3"
        Dim id_comp_param As String = "0"
        Try
            id_comp_param = get_id_company(id_comp_contact_to)
        Catch ex As Exception
        End Try
        FormPopUpDrawer.id_comp = id_comp_param
        FormPopUpDrawer.ShowDialog()
    End Sub
End Class