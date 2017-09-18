Imports System.Data.OleDb
Imports System.IO

Public Class FormSalesPOSDet
    Public action As String
    Public id_sales_pos As String = "-1"
    Public id_store_contact_from As String = "-1"
    Public id_report_status As String
    Public id_sales_pos_det_list As New List(Of String)
    Public id_comp As String = "-1"
    Dim total_amount As Decimal = 0.0
    Dim currency As String = "-1"
    Dim id_comp_cat_store As String = "-1"
    Dim now_date As String = "-1"
    Public id_wh_locator As String = "-1"
    Public id_wh_rack As String = "-1"
    Public id_wh_drawer As String = "-1"
    '
    Public id_del_ins As String = "-1"
    '
    'updqated 13 januari 2015
    Public dt_stock_store As New DataTable
    Dim last_end_period_select As String = "9999-12-01"
    '
    Public id_do As String = "-1"

    Private Sub FormSalesPOSDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        actionLoad()
        TxtCodeCompFrom.Focus()
    End Sub

    Sub actionLoad()
        'get currency default
        Dim query_currency As String = "SELECT b.id_currency FROM tb_opt a INNER JOIN tb_lookup_currency b ON a.id_currency_default = b.id_currency "
        currency = execute_query(query_currency, 0, True, "", "", "", "")

        'get default store category for pick company
        id_comp_cat_store = execute_query("SELECT id_comp_cat_store FROM tb_opt", 0, True, "", "", "", "")

        'view data
        viewReportStatus()
        viewSoType()
        If action = "ins" Then
            TxtDiscount.EditValue = 0.0
            TxtNetto.EditValue = 0.0
            TxtVatTot.EditValue = 0.0
            TxtTaxBase.EditValue = 0.0

            TxtVirtualPosNumber.Text = header_number_sales("6")
            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            BMark.Enabled = False
            DEForm.Text = view_date(0)
            GCItemList.DataSource = Nothing
        ElseIf action = "upd" Then
            GroupControlList.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BtnBrowseContactFrom.Enabled = False
            '
            BtnAttachment.Enabled = True
            BMark.Enabled = True

            'query view based on edit id's
            Dim query As String = ""
            query += "SELECT pld.pl_sales_order_del_number,a.id_pl_sales_order_del,a.id_so_type, a.id_report_status, a.id_sales_pos, a.sales_pos_date, a.sales_pos_note, "
            query += "a.sales_pos_number, (c.comp_name) AS store_name_from,c.npwp, "
            query += "a.id_store_contact_from, (c.comp_number) AS store_number_from, (c.address_primary) AS store_address_from,d.report_status, DATE_FORMAT(a.sales_pos_date,'%Y-%m-%d') AS sales_pos_datex, c.id_comp, "
            query += "a.sales_pos_due_date, a.sales_pos_start_period, a.sales_pos_end_period, a.sales_pos_discount, a.sales_pos_vat "
            query += "FROM tb_sales_pos a "
            query += "INNER JOIN tb_m_comp_contact b ON a.id_store_contact_from = b.id_comp_contact "
            query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp "
            query += "LEFT JOIN tb_pl_sales_order_del pld ON pld.id_pl_sales_order_del=a.id_pl_sales_order_del "
            query += "INNER JOIN tb_lookup_report_status d ON d.id_report_status = a.id_report_status "
            query += "WHERE a.id_sales_pos = '" + id_sales_pos + "' "
            query += "ORDER BY a.id_sales_pos ASC "

            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_store_contact_from = data.Rows(0)("id_store_contact_from").ToString
            TxtNameCompFrom.Text = data.Rows(0)("store_name_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("store_number_from").ToString
            MEAdrressCompFrom.Text = data.Rows(0)("store_address_from").ToString
            TENPWP.Text = data.Rows(0)("npwp").ToString

            DEForm.Text = view_date_from(data.Rows(0)("sales_pos_datex").ToString, 0)
            TxtVirtualPosNumber.Text = data.Rows(0)("sales_pos_number").ToString
            MENote.Text = data.Rows(0)("sales_pos_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)
            id_comp = data.Rows(0)("id_comp").ToString

            ''updated 8 october 2014
            DEDueDate.EditValue = data.Rows(0)("sales_pos_due_date")
            DEStart.EditValue = data.Rows(0)("sales_pos_start_period")
            DEEnd.EditValue = data.Rows(0)("sales_pos_end_period")
            SPDiscount.EditValue = data.Rows(0)("sales_pos_discount")
            SPVat.EditValue = data.Rows(0)("sales_pos_vat")

            ''detail2
            viewDetail()
            viewStockStore()
            check_but()
            allow_status()
            calculate()

            'DO
            check_do()
            If Not data.Rows(0)("id_pl_sales_order_del").ToString = "" Then
                TEDO.Text = data.Rows(0)("pl_sales_order_del_number").ToString
            End If
        End If
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewSoType()
        Dim query As String = "SELECT * FROM tb_lookup_so_type a ORDER BY a.id_so_type "
        viewLookupQuery(LETypeSO, query, 0, "so_type", "id_so_type")
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_sales_pos('" + id_sales_pos + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        If action = "ins" Then
            'action
        ElseIf action = "upd" Then
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sales_pos_det_list.Add(data.Rows(i)("id_sales_pos_det").ToString)
            Next
        End If
        GCItemList.DataSource = data
    End Sub

    Sub viewStockStore()
        dt_stock_store.Clear()
        '
        Try
            Dim queryx As String = "SELECT dr.id_wh_drawer,rack.id_wh_rack,loc.id_wh_locator FROM tb_m_comp c
                                INNER Join tb_m_wh_drawer dr On dr.id_wh_drawer=c.id_drawer_def
                                INNER JOIN tb_m_wh_rack rack On rack.id_wh_rack=dr.id_wh_rack
                                INNER Join tb_m_wh_locator loc On loc.id_wh_locator=rack.id_wh_locator
                                WHERE c.id_comp='" & id_comp & "'"
            Dim datax As DataTable = execute_query(queryx, -1, True, "", "", "", "")
            id_wh_drawer = datax.Rows(0)("id_wh_drawer").ToString
            id_wh_rack = datax.Rows(0)("id_wh_rack").ToString
            id_wh_locator = datax.Rows(0)("id_wh_locator").ToString
        Catch ex As Exception
        End Try
        '
        Dim end_period As String = "9999-12-01"
        Try
            end_period = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim query As String = "CALL view_stock_fg('" + id_comp + "', '" + id_wh_locator + "', '" + id_wh_rack + "', '" + id_wh_drawer + "', '0', '4', '" + end_period + "') "
        dt_stock_store = execute_query(query, -1, True, "", "", "", "")
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        'Make sure valid data
        makeSafeGV(GVItemList)
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        calculate()

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
        Try
            due_date_cek = DEDueDate.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim do_q As String = ""
        If id_do = "-1" Then
            do_q = "NULL"
        Else
            do_q = "'" + id_do + "'"
        End If

        ValidateChildren()
        If Not formIsValidInPanel(EPForm, PanelControlTopLeft) Or Not formIsValidInPanel(EPForm, PanelControlTopMiddle) Then
            errorInput()
        ElseIf GVItemList.RowCount <= 0 Then
            stopCustom("Item list can't blank ")
        ElseIf start_period_cek = "0000-01-01" Or end_period_cek = "9999-12-01" Or due_date_cek = "-1" Then
            stopCustom("Please fill period and due date!")
            'check stock
            'ElseIf Not valid_stock Then
            'stopCustom(err_str.ToString)
        Else
            Dim sales_pos_number As String = TxtVirtualPosNumber.Text
            Dim sales_pos_note As String = MENote.Text
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim id_so_type As String = LETypeSO.EditValue
            Dim sales_pos_due_date As String = DateTime.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim sales_pos_start_period As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim sales_pos_end_period As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim sales_pos_discount As String = decimalSQL(SPDiscount.EditValue.ToString)
            Dim sales_pos_vat As String = decimalSQL(SPVat.EditValue.ToString)
            total_amount = Double.Parse(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)


            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        'Main tbale
                        Dim query As String = "INSERT INTO tb_sales_pos(id_store_contact_from, sales_pos_number, sales_pos_date, sales_pos_note, id_report_status, id_so_type, sales_pos_total, sales_pos_due_date, sales_pos_start_period, sales_pos_end_period, sales_pos_discount, sales_pos_vat, id_pl_sales_order_del) "
                        query += "VALUES('" + id_store_contact_from + "', '" + sales_pos_number + "', NOW(), '" + sales_pos_note + "', '" + id_report_status + "', '" + id_so_type + "', '" + decimalSQL(total_amount.ToString) + "', '" + sales_pos_due_date + "', '" + sales_pos_start_period + "', '" + sales_pos_end_period + "', '" + sales_pos_discount + "', '" + sales_pos_vat + "'," + do_q + "); SELECT LAST_INSERT_ID(); "
                        id_sales_pos = execute_query(query, 0, True, "", "", "", "")

                        increase_inc_sales("6")

                        'insert who prepared
                        insert_who_prepared("48", id_sales_pos, id_user)

                        'Detail 
                        Dim jum_ins_i As Integer = 0
                        Dim query_detail As String = ""
                        If GVItemList.RowCount > 0 Then
                            query_detail = "INSERT INTO tb_sales_pos_det(id_sales_pos, id_product, id_design_price, design_price, sales_pos_det_qty, id_design_price_retail, design_price_retail) VALUES "
                        End If
                        For i As Integer = 0 To (GVItemList.RowCount - 1)
                            Try
                                Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                                Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                                Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                                Dim sales_pos_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sales_pos_det_qty").ToString)
                                'Dim sales_pos_det_note As String = GVItemList.GetRowCellValue(i, "sales_return_order_det_note").ToString
                                Dim id_design_price_retail As String = GVItemList.GetRowCellValue(i, "id_design_price_retail").ToString
                                Dim design_price_retail As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price_retail").ToString)

                                If jum_ins_i > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "('" + id_sales_pos + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_pos_det_qty + "', '" + id_design_price_retail + "', '" + design_price_retail + "') "
                                jum_ins_i = jum_ins_i + 1
                            Catch ex As Exception

                            End Try
                        Next
                        If jum_ins_i > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If

                        'reserved stock
                        Dim rsv_stock As ClassSalesInv = New ClassSalesInv()
                        rsv_stock.reservedStock(id_sales_pos, "48")

                        FormSalesPOS.viewSalesPOS()
                        FormSalesPOS.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPOS.GVSalesPOS, "id_sales_pos", id_sales_pos)
                        infoCustom("Data inserted")

                        action = "upd"
                        actionLoad()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data changes ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        Dim query As String = "UPDATE tb_sales_pos SET id_store_contact_from ='" + id_store_contact_from + "', sales_pos_number = '" + sales_pos_number + "', sales_pos_note='" + sales_pos_note + "', id_so_type = '" + id_so_type + "', sales_pos_total = '" + decimalSQL(total_amount.ToString) + "', sales_pos_due_date='" + sales_pos_due_date + "', sales_pos_start_period='" + sales_pos_start_period + "', sales_pos_end_period = '" + sales_pos_end_period + "', sales_pos_discount='" + sales_pos_discount + "', sales_pos_vat='" + sales_pos_vat + "' WHERE id_sales_pos ='" + id_sales_pos + "' "
                        execute_non_query(query, True, "", "", "", "")

                        'edit detail table
                        Dim jum_ins_i As Integer = 0
                        Dim query_detail As String = ""
                        If GVItemList.RowCount > 0 Then
                            query_detail = "INSERT INTO tb_sales_pos_det(id_sales_pos, id_product, id_design_price, design_price, sales_pos_det_qty, id_design_price_retail, design_price_retail) VALUES "
                        End If
                        For i As Integer = 0 To (GVItemList.RowCount - 1)
                            Try
                                Dim id_sales_pos_det As String = GVItemList.GetRowCellValue(i, "id_sales_pos_det").ToString
                                Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                                Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                                Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                                Dim sales_pos_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sales_pos_det_qty").ToString)
                                'Dim sales_pos_det_note As String = GVItemList.GetRowCellValue(i, "sales_pos_det_note").ToString
                                Dim id_design_price_retail As String = GVItemList.GetRowCellValue(i, "id_design_price_retail").ToString
                                Dim design_price_retail As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price_retail").ToString)

                                If id_sales_pos_det = "0" Then
                                    If jum_ins_i > 0 Then
                                        query_detail += ", "
                                    End If
                                    query_detail += "('" + id_sales_pos + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_pos_det_qty + "', '" + id_design_price_retail + "', '" + design_price_retail + "') "
                                    jum_ins_i = jum_ins_i + 1
                                Else
                                    Dim query_edit As String = "UPDATE tb_sales_pos_det SET id_product = '" + id_product + "', id_design_price='" + id_design_price + "', design_price = '" + design_price + "', sales_pos_det_qty = '" + sales_pos_det_qty + "', id_design_price_retail = '" + id_design_price_retail + "', design_price_retail = '" + design_price_retail + "'  WHERE id_sales_pos_det = '" + id_sales_pos_det + "' "
                                    execute_non_query(query_edit, True, "", "", "", "")
                                    id_sales_pos_det_list.Remove(id_sales_pos_det)
                                End If
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next
                        If jum_ins_i > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If

                        'delete sisa
                        For k As Integer = 0 To (id_sales_pos_det_list.Count - 1)
                            Try
                                Dim querydel As String = "DELETE FROM tb_sales_pos_det WHERE id_sales_pos_det = '" + id_sales_pos_det_list(k) + "' "
                                execute_non_query(querydel, True, "", "", "", "")
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next

                        FormSalesPOS.viewSalesPOS()
                        FormSalesPOS.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPOS.GVSalesPOS, "id_sales_pos", id_sales_pos)
                        infoCustom("Data updated")
                    Catch ex As Exception
                        errorConnection()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    'sub check_but
    Sub check_but()
        Dim id_productx As String = "0"
        Try
            id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception

        End Try

        'MsgBox("main :" + id_productx)

        'Constraint Status
        If GVItemList.RowCount > 0 And id_productx <> "0" Then
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "48", id_sales_pos) Then
            'BtnBrowseContactFrom.Enabled = True
            GVItemList.OptionsBehavior.Editable = True
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = False
            LETypeSO.Enabled = True
            BtnSave.Enabled = True

            'update 8 oktocer 2014
            DEDueDate.Properties.ReadOnly = False
            SPDiscount.Properties.ReadOnly = False
            SPVat.Properties.ReadOnly = False
            DEStart.Properties.ReadOnly = True
            DEEnd.Properties.ReadOnly = True
        Else
            'BtnBrowseContactFrom.Enabled = False
            GVItemList.OptionsBehavior.Editable = False
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = True
            LETypeSO.Enabled = False
            BtnSave.Enabled = False

            'update 8 oktocer 2014
            DEDueDate.Properties.ReadOnly = True
            SPDiscount.Properties.ReadOnly = True
            SPVat.Properties.ReadOnly = True
            DEStart.Properties.ReadOnly = True
            DEEnd.Properties.ReadOnly = True
        End If


        If check_attach_report_status(id_report_status, "48", id_sales_pos) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
        TxtVirtualPosNumber.Focus()
    End Sub

    Sub getNetto()
        Dim gross_total As Double = 0.0
        Try
            gross_total = Double.Parse(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)
        Catch ex As Exception
        End Try

        Dim netto As Double = gross_total - Decimal.Parse(TxtDiscount.EditValue.ToString)
        TxtNetto.EditValue = netto
        METotSay.Text = ConvertCurrencyToEnglish(netto, currency)
    End Sub

    Sub getVat()
        Dim netto As Double = Double.Parse(TxtNetto.EditValue.ToString)
        Dim vat As Double = Double.Parse(SPVat.EditValue.ToString)
        Dim vat_total As Double = (vat / (100 + vat)) * netto
        TxtVatTot.EditValue = vat_total
    End Sub

    Sub getDiscount()
        Dim gross_total As Double = 0.0
        Try
            gross_total = Double.Parse(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)
        Catch ex As Exception
        End Try

        Dim discount As Double = (Decimal.Parse(SPDiscount.EditValue.ToString) / 100) * gross_total
        TxtDiscount.EditValue = discount
    End Sub

    Sub getTaxBase()
        Dim netto As Double = Double.Parse(TxtNetto.EditValue.ToString)
        Dim vat As Double = Double.Parse(SPVat.EditValue.ToString)
        Dim tax_base_total As Double = (100 / (100 + vat)) * netto
        TxtTaxBase.EditValue = tax_base_total
    End Sub

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "42"

        FormPopUpContact.id_cat = id_comp_cat_store
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSalesPOSDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        'MsgBox(id_comp)
        FormSalesPOSSingle.action_pop = "ins"
        FormSalesPOSSingle.id_product = "0"
        FormSalesPOSSingle.id_sales_pos = id_sales_pos
        FormSalesPOSSingle.id_comp = id_comp
        FormSalesPOSSingle.id_wh_locator = id_wh_locator
        FormSalesPOSSingle.id_wh_rack = id_wh_rack
        FormSalesPOSSingle.id_wh_drawer = id_wh_drawer
        Dim end_period As String = "9999-01-01"
        Try
            end_period = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        FormSalesPOSSingle.date_param = end_period
        FormSalesPOSSingle.ShowDialog()
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        check_but()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        FormSalesPOSSingle.action_pop = "upd"
        FormSalesPOSSingle.id_product = "0"
        Try
            FormSalesPOSSingle.id_product = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try
        FormSalesPOSSingle.id_comp = id_comp
        FormSalesPOSSingle.indeks_edit = GVItemList.FocusedRowHandle()
        FormSalesPOSSingle.id_product_edit = GVItemList.GetFocusedRowCellValue("id_product").ToString
        FormSalesPOSSingle.product_code = GVItemList.GetFocusedRowCellValue("code").ToString
        FormSalesPOSSingle.id_design_price_edit = GVItemList.GetFocusedRowCellValue("id_design_price")
        FormSalesPOSSingle.qty_edit = GVItemList.GetFocusedRowCellValue("sales_pos_det_qty")
        FormSalesPOSSingle.id_sales_pos = id_sales_pos
        FormSalesPOSSingle.ShowDialog()
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
            GCItemList.RefreshDataSource()
            GVItemList.RefreshData()
            calculate()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        For i As Integer = 0 To (GVItemList.RowCount - 1)
            Try
                Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                MsgBox(id_product)
            Catch ex As Exception

            End Try
        Next
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_sales_pos
        FormReportMark.report_mark_type = "48"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        CType(GCItemList.DataSource, DataTable).AcceptChanges()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportSalesInvoice.id_sales_pos = id_sales_pos
        Dim Report As New ReportSalesInvoice()
        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompFrom)
        EPForm.SetIconPadding(TxtNameCompFrom, 30)
    End Sub

    Sub sayCurr()
        total_amount = Double.Parse(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)
        METotSay.Text = ConvertCurrencyToEnglish(total_amount, currency)
    End Sub

    Private Sub DEDueDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DEDueDate.Validating
        EP_DE_cant_blank(EPForm, DEDueDate)
    End Sub

    Private Sub SPDiscount_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPDiscount.EditValueChanged
        calculate()
    End Sub

    Private Sub SPVat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPVat.EditValueChanged
        getVat()
        getTaxBase()
    End Sub

    Private Sub DEStart_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEStart.EditValueChanged
        DEEnd.Properties.MinValue = DEStart.EditValue
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sales_pos
        FormDocumentUpload.report_mark_type = "48"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImport.Click
        Cursor = Cursors.WaitCursor
        Dim start_period As String = "1945-01-01"
        Try
            start_period = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim end_period As String = "9999-12-01"
        Try
            end_period = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        If start_period = "1945-01-01" Or end_period = "9999-12-01" Then
            stopCustom("Please fill start & end period !")
        Else
            viewStockStore()
            load_excel_data()
            'join

            'FormImportExcel.id_pop_up = "6"
            'FormImportExcel.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub load_excel_data()
        Dim oledbconn As New OleDbConnection
        Dim strConn As String
        Dim data_temp As New DataTable
        Dim bof_xls_path As String = get_setup_field("bof_xls_bill_path")
        Dim bof_xls_temp_path As String = get_setup_field("bof_xls_bill_temp_path")
        Dim bof_xls_ws As String = get_setup_field("bof_xls_bill_path_worksheet")

        File.Copy(bof_xls_path, bof_xls_temp_path, True)

        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & bof_xls_temp_path & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text;"""
        oledbconn.ConnectionString = strConn
        Dim MyCommand As OleDbDataAdapter
        MyCommand = New OleDbDataAdapter("select [F2] as code,SUM([F3]) as qty from [" & bof_xls_ws & "] WHERE NOT [F2] IS NULL AND NOT [F3]  IS NULL GROUP BY [F2]", oledbconn)

        'Try
        MyCommand.Fill(data_temp)
        MyCommand.Dispose()

        Dim dt As DataTable = dt_stock_store
        Dim tb1 = data_temp.AsEnumerable()
        Dim tb2 = dt.AsEnumerable()

        Dim query = From table1 In tb1
                    Group Join table_tmp In tb2 On table1("code") Equals table_tmp("code")
                    Into Group
                    From y1 In Group.DefaultIfEmpty()
                    Select New With
                    {
                        .Code = table1.Field(Of String)("code"),
                        .Description = If(y1 Is Nothing, "", y1("name")),
                        .Size = If(y1 Is Nothing, "", y1("size")),
                        .Amount = If(y1 Is Nothing, "", table1("qty") * y1("design_price_retail")),
                        .Qty = CType(table1("qty"), Decimal),
                        .Qty_Volcom = If(y1 Is Nothing, 0.0, y1("qty_all_product")),
                        .Price = If(y1 Is Nothing, 0.0, y1("design_price_retail")),
                        .id_design_price_retail = If(y1 Is Nothing, 0, y1("id_design_price_retail")),
                        .design_price_type = If(y1 Is Nothing, "", y1("design_price_type")),
                        .design_price = If(y1 Is Nothing, 0.0, y1("design_price")),
                        .sales_pos_det_note = If(y1 Is Nothing, "", ""),
                        .id_design = If(y1 Is Nothing, 0, y1("id_design")),
                        .id_product = If(y1 Is Nothing, 0, y1("id_product")),
                        .id_sample = If(y1 Is Nothing, 0, y1("id_sample")),
                        .id_design_price = If(y1 Is Nothing, 0, y1("id_design_price")),
                        .Type = If(y1 Is Nothing, "", y1("design_price_type")),
                        .id_sales_pos_det = If(y1 Is Nothing, "", "0"),
                        .Color = If(y1 Is Nothing, "", y1("color")),
                        .Diff = If((CType(table1("qty"), Decimal) - If(y1 Is Nothing, 0.0, y1("qty_all_product"))) <= 0, 0.0, (CType(table1("qty"), Decimal) - If(y1 Is Nothing, 0.0, y1("qty_all_product"))))
                    }

        GCItemList.DataSource = Nothing
        GCItemList.DataSource = query.ToList()
        GCItemList.RefreshDataSource()
        GVItemList.PopulateColumns()

        'Catch ex As Exception
        'stopCustom("Input must be in accordance with the format specified !")
        'Exit Sub
        'End Try
    End Sub

    Private Sub DEEnd_EditValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles DEEnd.EditValueChanging
        'If end_load Then
        '    Cursor = Cursors.WaitCursor
        '    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Changing end period will reset the list, are you sure to continue??", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '    If confirm = Windows.Forms.DialogResult.Yes Then
        '        viewDetail()
        '    Else
        '        e.Cancel = True
        '    End If
        '    Cursor = Cursors.Default
        'End If
    End Sub
    Private Sub TxtCodeCompFrom_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query As String = "SELECT dr.id_wh_drawer,rack.id_wh_rack,loc.id_wh_locator,cc.id_comp_contact,cc.id_comp,c.npwp,c.comp_number,c.comp_name,c.comp_commission,c.address_primary,c.id_so_type "
            query += " From tb_m_comp_contact cc "
            query += " INNER JOIN tb_m_comp c On c.id_comp=cc.id_comp"
            query += " INNER JOIN tb_m_wh_drawer dr ON dr.id_wh_drawer=c.id_drawer_def"
            query += " INNER JOIN tb_m_wh_rack rack ON rack.id_wh_rack=dr.id_wh_rack"
            query += " INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator=rack.id_wh_locator"
            query += " where cc.is_default=1 and c.id_comp_cat='" + id_comp_cat_store + "' AND c.comp_number='" + TxtCodeCompFrom.Text + "'"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count <= 0 Then
                stopCustom("Store not found.")
                TxtCodeCompFrom.Focus()
            ElseIf data.Rows.Count > 1 Then
                FormPopUpContact.id_pop_up = "42"
                FormPopUpContact.id_cat = id_comp_cat_store
                FormPopUpContact.GVCompany.ActiveFilterString = "[comp_number]='" + TxtCodeCompFrom.Text + "'"
                FormPopUpContact.ShowDialog()
            Else
                'If check_acc(data.Rows(0)("id_comp").ToString) Then
                SPDiscount.EditValue = data.Rows(0)("comp_commission")
                id_comp = data.Rows(0)("id_comp").ToString
                id_store_contact_from = data.Rows(0)("id_comp_contact").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
                MEAdrressCompFrom.Text = data.Rows(0)("address_primary").ToString
                TENPWP.Text = data.Rows(0)("npwp").ToString
                '
                id_wh_drawer = data.Rows(0)("id_wh_drawer").ToString
                id_wh_locator = data.Rows(0)("id_wh_locator").ToString
                id_wh_rack = data.Rows(0)("id_wh_rack").ToString
                '
                LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)
                '
                viewDetail()
                viewStockStore()
                check_but()
                GroupControlList.Enabled = True
                calculate()
                check_do()
                '
                LETypeSO.Focus()
                'Else
                '    stopCustom("Store not registered for auto posting journal.")
                'End If
            End If
        End If
    End Sub
    Function check_acc(ByVal id_cc As String)
        Dim query As String = ""
        query = "SELECT coa_map_d.id_coa_map_det,comp_coa.id_acc,acc.acc_name,acc.acc_description "
        query += " FROM tb_m_comp_coa comp_coa "
        query += " INNER JOIN tb_coa_map_det coa_map_d ON coa_map_d.id_coa_map_det=comp_coa.id_coa_map_det"
        query += " INNER JOIN tb_coa_map coa_map ON coa_map_d.id_coa_map=coa_map.id_coa_map"
        query += " INNER JOIN tb_a_acc acc ON acc.id_acc=comp_coa.id_acc"
        query += " WHERE comp_coa.id_comp='" + id_cc + "' AND coa_map.id_coa_map='1'"
        Dim data_acc As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data_acc.Rows.Count > 0 Then 'id_coa_map = 1
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub TEDO_KeyDown(sender As Object, e As KeyEventArgs) Handles TEDO.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query As String = "SELECT * FROM tb_pl_sales_order_del pldel"
            query += " INNER JOIN tb_m_comp_contact cc On cc.id_comp_contact=pldel.id_store_contact_to"
            query += " INNER JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp"
            query += " LEFT JOIN tb_sales_pos sp ON sp.id_pl_sales_order_del=pldel.id_pl_sales_order_del"
            query += " WHERE pldel.id_report_status='6' AND comp.id_comp='" + id_comp + "' AND pldel.pl_sales_order_del_number='" + TEDO.Text + "'"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count <= 0 Then
                stopCustom("Delivery order is not found for this store.")
                TEDO.Focus()
            ElseIf Not data.Rows(0)("id_sales_pos").ToString = "" Then
                stopCustom("Invoice is already created.")
                TEDO.Focus()
            Else
                'id DO
                id_do = data.Rows(0)("id_pl_sales_order_del").ToString
                ' fill GV
                view_do()
                '
                calculate()
                '
                MENote.Focus()
            End If
        End If
    End Sub
    Sub view_do()
        Dim query_det As String = "CALL view_pl_sales_order_del_inv('" + id_do + "')"
        Dim data_det As DataTable = execute_query(query_det, "-1", True, "", "", "", "")
        GCItemList.DataSource = data_det
    End Sub
    Sub check_do()
        id_do = "-1"
        TEDO.Text = ""
        If LETypeSO.EditValue.ToString = "2" Then
            LDO.Visible = True
            TEDO.Visible = True
            BDO.Visible = True
            '
            PanelControlNav.Visible = False
        Else
            LDO.Visible = False
            TEDO.Visible = False
            BDO.Visible = False
            '
            PanelControlNav.Visible = True
        End If
    End Sub

    Sub next_control_enter(e As KeyEventArgs)
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub LETypeSO_KeyDown(sender As Object, e As KeyEventArgs) Handles LETypeSO.KeyDown
        next_control_enter(e)
    End Sub

    Private Sub DEStart_KeyDown(sender As Object, e As KeyEventArgs) Handles DEStart.KeyDown
        next_control_enter(e)
    End Sub

    Private Sub DEEnd_KeyDown(sender As Object, e As KeyEventArgs) Handles DEEnd.KeyDown
        next_control_enter(e)
    End Sub

    Private Sub DEDueDate_KeyDown(sender As Object, e As KeyEventArgs) Handles DEDueDate.KeyDown
        next_control_enter(e)
    End Sub

    Private Sub MENote_KeyDown(sender As Object, e As KeyEventArgs) Handles MENote.KeyDown
        next_control_enter(e)
    End Sub

    Private Sub LEReportStatus_KeyDown(sender As Object, e As KeyEventArgs) Handles LEReportStatus.KeyDown
        next_control_enter(e)
    End Sub

    Private Sub SPDiscount_KeyDown(sender As Object, e As KeyEventArgs) Handles SPDiscount.KeyDown
        next_control_enter(e)
    End Sub

    Private Sub SPVat_KeyDown(sender As Object, e As KeyEventArgs) Handles SPVat.KeyDown
        next_control_enter(e)
    End Sub

    Private Sub GCItemList_KeyDown(sender As Object, e As KeyEventArgs) Handles GCItemList.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            BtnSave.Focus()
        End If
    End Sub

    Private Sub BDO_Click(sender As Object, e As EventArgs) Handles BDO.Click
        FormPopUpSalesDel.ShowDialog()
    End Sub

    Sub calculate()
        getDiscount()
        getNetto()
        getVat()
        getTaxBase()
    End Sub
End Class