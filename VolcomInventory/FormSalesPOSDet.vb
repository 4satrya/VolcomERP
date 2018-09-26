Imports System.Data.OleDb
Imports System.IO

Public Class FormSalesPOSDet
    Public action As String
    Public id_sales_pos As String = "-1"
    Public id_store_contact_from As String = "-1"
    Public id_comp_contact_bill As String = "-1"
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
    Public id_memo_type As String = "-1"
    Dim report_mark_type As String = "-1"

    'menu : 1=invoice 2=credit note
    Public id_menu As String = "1"
    Public id_sales_pos_ref As String = "-1"
    Public ol_store_order_cn As String = ""
    Dim vat_def As Decimal = 0

    Private Sub FormSalesPOSDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        actionLoad()
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
        viewInvType()

        'setting menu
        If id_menu = "1" Then
            Text = "Invoice"
            LEInvType.Focus()
        ElseIf id_menu = "2" Then
            Text = "Credit Note"
            LEInvType.Enabled = False
            TEDO.Enabled = False
            CheckEditInvType.Text = "Credit Note Missing"
            TxtCodeCompFrom.Focus()
        ElseIf id_menu = "3" Then
            Text = "Invoice Missing Promo"
            LEInvType.Enabled = False
            TEDO.Enabled = False
            CheckEditInvType.Visible = False
            TxtCodeCompFrom.Focus()
        ElseIf id_menu = "4" Then
            Text = "Invoice Missing Staff"
            LEInvType.Enabled = False
            TEDO.Enabled = False
            CheckEditInvType.Visible = False
            TxtCodeCompFrom.Focus()
            LabelStore.Text = "Missing From"
            LabelBillTo.Visible = True
            TxtCodeBillTo.Visible = True
            TxtNameBillTo.Visible = True
            BtnBrowseBillTo.Visible = True
        ElseIf id_menu = "5" Then
            Text = "Credit Note Online Store"
            LEInvType.Enabled = False
            TEDO.Enabled = False
            CheckEditInvType.Visible = False
            PanelCN.Visible = True
            BtnDel.Visible = True
            BtnListProduct.Visible = True
            BtnImport.Visible = False
            BtnImportOLStore.Visible = False
            TxtCodeCompFrom.Focus()
            TxtOLStoreNumber.Properties.ReadOnly = False
            GridColumnOrder.Visible = False
            GridColumnDel.Visible = False
        End If


        If action = "ins" Then
            TxtDiscount.EditValue = 0.0
            TxtNetto.EditValue = 0.0
            TxtVatTot.EditValue = 0.0
            TxtTaxBase.EditValue = 0.0
            TxtPotPenjualan.EditValue = 0.0


            'get vat default
            Dim dtv As DataTable = execute_query("SELECT vat_inv_default FROM tb_opt ", -1, True, "", "", "", "")
            vat_def = dtv.Rows(0)("vat_inv_default")
            SPVat.EditValue = vat_def

            'TxtVirtualPosNumber.Text = header_number_sales("6")
            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            BtnDraftJournal.Enabled = False
            BMark.Enabled = False
            DEForm.Text = view_date(0)
            GCItemList.DataSource = Nothing
        ElseIf action = "upd" Then
            GroupControlList.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BtnBrowseContactFrom.Enabled = False
            '
            BtnAttachment.Enabled = True
            BtnDraftJournal.Enabled = True
            BMark.Enabled = True
            GridColumnNote.Visible = False

            'query view based on edit id's
            Dim query As String = ""
            query += "SELECT pld.pl_sales_order_del_number,a.id_pl_sales_order_del,a.id_so_type, a.id_report_status, a.id_sales_pos, a.sales_pos_date, a.sales_pos_note, "
            query += "a.sales_pos_number, (c.comp_name) AS store_name_from,c.npwp, "
            query += "a.id_store_contact_from, (c.comp_number) AS store_number_from, (c.address_primary) AS store_address_from,
            IFNULL(a.id_comp_contact_bill,'-1') AS `id_comp_contact_bill`,(cb.comp_number) AS `comp_number_bill`, (cb.comp_name) AS `comp_name_bill`,
            d.report_status, DATE_FORMAT(a.sales_pos_date,'%Y-%m-%d') AS sales_pos_datex, c.id_comp, "
            query += "a.sales_pos_due_date, a.sales_pos_start_period, a.sales_pos_end_period, a.sales_pos_discount, a.sales_pos_potongan, a.sales_pos_vat, a.id_memo_type, a.id_inv_type, so.sales_order_ol_shop_number "
            If id_menu = "5" Then
                query += ", IFNULL(sor.sales_pos_number,'-') AS `sales_pos_number_ref`, sor.sales_order_ol_shop_number AS `sales_order_ol_shop_number_ref` "
            End If
            query += "FROM tb_sales_pos a "
            query += "INNER JOIN tb_m_comp_contact b ON a.id_store_contact_from = b.id_comp_contact "
            query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp "
            query += "LEFT JOIN tb_m_comp_contact bb ON a.id_comp_contact_bill = bb.id_comp_contact
            LEFT JOIN tb_m_comp cb ON cb.id_comp = bb.id_comp "
            query += "LEFT JOIN tb_pl_sales_order_del pld ON pld.id_pl_sales_order_del=a.id_pl_sales_order_del "
            query += "LEFT JOIN tb_sales_order so ON so.id_sales_order = pld.id_sales_order "
            query += "INNER JOIN tb_lookup_report_status d ON d.id_report_status = a.id_report_status "
            If id_menu = "5" Then
                query += "LEFT JOIN (
                    SELECT pd.id_sales_pos, pr.sales_pos_number, so.sales_order_ol_shop_number 
                    FROM tb_sales_pos_det pd
                    INNER JOIN tb_sales_pos_det pdr ON pdr.id_sales_pos_det = pd.id_sales_pos_det_ref
                    INNER JOIN tb_sales_pos pr ON pr.id_sales_pos = pdr.id_sales_pos
                    INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del_det = pdr.id_pl_sales_order_del_det
                    INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = deld.id_sales_order_det
                    INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
                    WHERE pd.id_sales_pos=" + id_sales_pos + "
                    GROUP BY pd.id_sales_pos
                ) sor ON sor.id_sales_pos = a.id_sales_pos "
            End If
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
            If id_menu = "5" Then
                TxtOLStoreNumber.Text = data.Rows(0)("sales_order_ol_shop_number_ref").ToString
                TxtInvoice.Text = data.Rows(0)("sales_pos_number_ref").ToString
            Else
                TxtOLStoreNumber.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
            End If
            MENote.Text = data.Rows(0)("sales_pos_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)
            id_comp = data.Rows(0)("id_comp").ToString

            ''updated 8 october 2014
            DEDueDate.EditValue = data.Rows(0)("sales_pos_due_date")
            DEStart.EditValue = data.Rows(0)("sales_pos_start_period")
            DEEnd.EditValue = data.Rows(0)("sales_pos_end_period")
            SPDiscount.EditValue = data.Rows(0)("sales_pos_discount")
            TxtPotPenjualan.EditValue = data.Rows(0)("sales_pos_potongan")
            SPVat.EditValue = data.Rows(0)("sales_pos_vat")

            'updated 04 ocktobertr 2017
            id_memo_type = data.Rows(0)("id_memo_type").ToString
            If id_memo_type = "1" Then 'sales invoice
                report_mark_type = "48"
            ElseIf id_memo_type = "2" Then 'sales cn
                If id_menu = "2" Then
                    report_mark_type = "66"
                ElseIf id_menu = "5" Then
                    report_mark_type = "118"
                End If
            ElseIf id_memo_type = "3" Then 'missing invoice
                report_mark_type = "54"
            ElseIf id_memo_type = "4" Then 'missing cn
                report_mark_type = "67"
            ElseIf id_memo_type = "5" Then 'missing promo
                report_mark_type = "116"
            ElseIf id_memo_type = "8" Then ' missing staff
                report_mark_type = "117"
            End If
            LEInvType.ItemIndex = LEInvType.Properties.GetDataSourceRowIndex("id_inv_type", data.Rows(0)("id_inv_type").ToString)
            TEDO.Text = data.Rows(0)("pl_sales_order_del_number").ToString
            If id_memo_type = "1" Or id_memo_type = "2" Or id_memo_type = "5" Or id_memo_type = "8" Then
                CheckEditInvType.EditValue = False
            ElseIf id_memo_type = "3" Or id_memo_type = "4" Then
                CheckEditInvType.EditValue = True
            End If
            id_comp_contact_bill = data.Rows(0)("id_comp_contact_bill").ToString
            TxtCodeBillTo.Text = data.Rows(0)("comp_number_bill").ToString
            TxtNameBillTo.Text = data.Rows(0)("comp_name_bill").ToString

            ''detail2
            viewDetail()
            'viewStockStore()
            check_but()
            calculate()
            allow_status()
        End If
    End Sub

    Sub viewInvType()
        Dim query As String = "SELECT * FROM tb_lookup_inv_type i ORDER BY i.id_inv_type ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEInvType, query, 0, "inv_type_display", "id_inv_type")
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
        Dim query As String = "CALL view_sales_pos_less('" + id_sales_pos + "')"
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
        If id_menu = "1" Or id_menu = "4" Then
            dt_stock_store.Clear()

            Dim end_period As String = "9999-12-01"
            Try
                end_period = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
            Catch ex As Exception
            End Try
            Dim query As String = "CALL view_stock_fg('" + id_comp + "', '" + id_wh_locator + "', '" + id_wh_rack + "', '" + id_wh_drawer + "', '0', '4', '" + end_period + "') "
            dt_stock_store = execute_query(query, -1, True, "", "", "", "")
        End If
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

        'cek bill
        Dim cond_bill_to As Boolean = True
        If id_menu = "4" And id_comp_contact_bill = "-1" Then
            cond_bill_to = False
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
        ElseIf Not cond_bill_to Then
            stopCustom("Bill to can't blank")
        Else
            Dim sales_pos_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim id_so_type As String = LETypeSO.EditValue
            Dim sales_pos_due_date As String = DateTime.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim sales_pos_start_period As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim sales_pos_end_period As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim sales_pos_discount As String = decimalSQL(SPDiscount.EditValue.ToString)
            Dim sales_pos_potongan As String = decimalSQL(TxtPotPenjualan.EditValue.ToString)
            Dim sales_pos_vat As String = decimalSQL(SPVat.EditValue.ToString)
            total_amount = Double.Parse(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)
            Dim id_memo_type As String = ""
            Dim sales_pos_number As String = ""
            If id_menu = "1" Then
                If CheckEditInvType.EditValue = True Then
                    report_mark_type = "54"
                    id_memo_type = "3"
                    sales_pos_number = header_number_sales("10")
                Else
                    report_mark_type = "48"
                    id_memo_type = "1"
                    sales_pos_number = header_number_sales("6")
                End If
            ElseIf id_menu = "2" Then
                If CheckEditInvType.EditValue = True Then
                    report_mark_type = "67"
                    id_memo_type = "4"
                    sales_pos_number = header_number_sales("18")
                Else
                    report_mark_type = "66"
                    id_memo_type = "2"
                    sales_pos_number = header_number_sales("17")
                End If
            ElseIf id_menu = "3" Then
                report_mark_type = "116"
                id_memo_type = "5"
                sales_pos_number = header_number_sales("33")
            ElseIf id_menu = "4" Then
                report_mark_type = "117"
                id_memo_type = "8"
                sales_pos_number = header_number_sales("34")
            ElseIf id_menu = "5" Then
                report_mark_type = "118"
                id_memo_type = "2"
                sales_pos_number = header_number_sales("17")
            End If
            Dim id_inv_type As String = LEInvType.EditValue.ToString
            If id_comp_contact_bill = "-1" Then
                id_comp_contact_bill = "NULL "
            End If
            If id_sales_pos_ref = "-1" Then
                id_sales_pos_ref = "NULL "
            End If

            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor

                    'Main tbale
                    Dim query As String = "INSERT INTO tb_sales_pos(id_store_contact_from,id_comp_contact_bill , sales_pos_number, sales_pos_date, sales_pos_note, id_report_status, id_so_type, sales_pos_total, sales_pos_due_date, sales_pos_start_period, sales_pos_end_period, sales_pos_discount, sales_pos_potongan, sales_pos_vat, id_pl_sales_order_del,id_memo_type,id_inv_type, id_sales_pos_ref) "
                    query += "VALUES('" + id_store_contact_from + "'," + id_comp_contact_bill + ", '" + sales_pos_number + "', NOW(), '" + sales_pos_note + "', '" + id_report_status + "', '" + id_so_type + "', '" + decimalSQL(total_amount.ToString) + "', '" + sales_pos_due_date + "', '" + sales_pos_start_period + "', '" + sales_pos_end_period + "', '" + sales_pos_discount + "', '" + sales_pos_potongan + "', '" + sales_pos_vat + "'," + do_q + "," + id_memo_type + "," + id_inv_type + "," + id_sales_pos_ref + "); SELECT LAST_INSERT_ID(); "
                    id_sales_pos = execute_query(query, 0, True, "", "", "", "")


                    If report_mark_type = "48" Then
                        increase_inc_sales("6")
                    ElseIf report_mark_type = "54" Then
                        increase_inc_sales("10")
                    ElseIf report_mark_type = "66" Or report_mark_type = "118" Then
                        increase_inc_sales("17")
                    ElseIf report_mark_type = "67" Then
                        increase_inc_sales("18")
                    ElseIf report_mark_type = "116" Then
                        increase_inc_sales("33")
                    ElseIf report_mark_type = "117" Then
                        increase_inc_sales("34")
                    End If

                    'insert who prepared
                    insert_who_prepared(report_mark_type, id_sales_pos, id_user)

                    'Detail 
                    Dim jum_ins_i As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT INTO tb_sales_pos_det(id_sales_pos, id_product, id_design_price, design_price, sales_pos_det_qty, id_design_price_retail, design_price_retail, note, id_sales_pos_det_ref, id_pl_sales_order_del_det) VALUES "
                    End If
                    For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                        Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                        Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                        Dim sales_pos_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sales_pos_det_qty").ToString)
                        If id_menu = "2" Or id_menu = "5" Then
                            sales_pos_det_qty = sales_pos_det_qty * -1
                        End If
                        Dim id_design_price_retail As String = GVItemList.GetRowCellValue(i, "id_design_price_retail").ToString
                        Dim design_price_retail As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price_retail").ToString)
                        Dim note As String = GVItemList.GetRowCellValue(i, "note").ToString
                        Dim id_sales_pos_det_ref As String = "NULL "
                        Try
                            id_sales_pos_det_ref = GVItemList.GetRowCellValue(i, "id_sales_pos_det_ref").ToString
                        Catch ex As Exception
                        End Try
                        Dim id_pl_sales_order_del_det As String = "NULL "
                        Try
                            id_pl_sales_order_del_det = GVItemList.GetRowCellValue(i, "id_pl_sales_order_del_det").ToString
                            If id_pl_sales_order_del_det = "0" Or id_pl_sales_order_del_det = "" Then
                                id_pl_sales_order_del_det = "NULL "
                            End If
                        Catch ex As Exception
                        End Try

                        If jum_ins_i > 0 Then
                            query_detail += ", "
                        End If
                        query_detail += "('" + id_sales_pos + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_pos_det_qty + "', '" + id_design_price_retail + "', '" + design_price_retail + "','" + note + "'," + id_sales_pos_det_ref + "," + id_pl_sales_order_del_det + ") "
                        jum_ins_i = jum_ins_i + 1
                    Next
                    If jum_ins_i > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'update total qty
                    Dim queryt As String = "UPDATE tb_sales_pos main
                    INNER JOIN (
                        SELECT pd.id_sales_pos,ABS(SUM(pd.sales_pos_det_qty)) AS `total`
                        FROM tb_sales_pos_det pd
                        WHERE pd.id_sales_pos=" + id_sales_pos + "
                        GROUP BY pd.id_sales_pos
                    ) src ON src.id_sales_pos = main.id_sales_pos
                    SET main.sales_pos_total_qty = src.total "
                    execute_non_query(queryt, True, "", "", "", "")

                    If id_menu = "1" Or id_menu = "4" Then
                        'reserved stock
                        Dim rsv_stock As ClassSalesInv = New ClassSalesInv()
                        rsv_stock.reservedStock(id_sales_pos, report_mark_type)
                    End If

                    'draft journal
                    Dim acc As New ClassAccounting()
                    If id_menu = "1" Or id_menu = "2" Or id_menu = "4" Or id_menu = "5" Then
                        acc.generateJournalSalesDraft(id_sales_pos, report_mark_type)
                    End If

                    FormSalesPOS.viewSalesPOS()
                    FormSalesPOS.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPOS.GVSalesPOS, "id_sales_pos", id_sales_pos)
                    action = "upd"
                    actionLoad()

                    If id_menu = "1" Then
                        infoCustom("Invoice " + TxtVirtualPosNumber.Text + " created succesfully")
                        viewDraft()
                    ElseIf id_menu = "2" Or id_menu = "5" Then
                        infoCustom("Credit Note " + TxtVirtualPosNumber.Text + " created succesfully")
                        viewDraft()
                    ElseIf id_menu = "3" Then
                        infoCustom("Invoice Missing Promo " + TxtVirtualPosNumber.Text + " created succesfully")
                    ElseIf id_menu = "4" Then
                        infoCustom("Invoice Missing Staff " + TxtVirtualPosNumber.Text + " created succesfully")
                        viewDraft()
                    End If

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
        GVItemList.OptionsBehavior.Editable = False
        PanelControlNav.Enabled = False
        MENote.Properties.ReadOnly = True
        LETypeSO.Enabled = False

        'update 8 oktocer 2014
        DEDueDate.Properties.ReadOnly = True
        SPDiscount.Properties.ReadOnly = True
        TxtPotPenjualan.Properties.ReadOnly = True
        SPVat.Properties.ReadOnly = True
        DEStart.Properties.ReadOnly = True
        DEEnd.Properties.ReadOnly = True
        BtnSave.Enabled = False

        'update 04 oktober 2017
        LEInvType.Enabled = False
        TEDO.Properties.ReadOnly = True
        TxtCodeCompFrom.Enabled = False
        TxtNameCompFrom.Enabled = False
        BtnBrowseContactFrom.Enabled = False
        CheckEditInvType.Enabled = False
        TxtOLStoreNumber.Properties.ReadOnly = True

        TxtCodeBillTo.Enabled = False
        TxtNameBillTo.Enabled = False
        BtnBrowseBillTo.Enabled = False

        If check_attach_report_status(id_report_status, report_mark_type, id_sales_pos) Then
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

        Dim pot_penjualan As Double = TxtPotPenjualan.EditValue


        Dim netto As Double = gross_total - Decimal.Parse(TxtDiscount.EditValue.ToString) - pot_penjualan
        TxtNetto.EditValue = netto
        METotSay.Text = ConvertCurrencyToEnglish(netto, currency)
    End Sub

    Sub getVat()
        Dim netto As Double = 0
        Try
            netto = Double.Parse(TxtNetto.EditValue.ToString)
        Catch ex As Exception
        End Try
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
        Dim netto As Double = 0
        Try
            netto = Double.Parse(TxtNetto.EditValue.ToString)
        Catch ex As Exception
        End Try
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
        print_raw(GCItemList, "")
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_sales_pos
        FormReportMark.report_mark_type = report_mark_type
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        CType(GCItemList.DataSource, DataTable).AcceptChanges()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportSalesInvoice.id_sales_pos = id_sales_pos
        Dim Report As New ReportSalesInvoice()
        If id_memo_type = "1" Then
            Report.LTitle.Text = "SALES INVOICE"
        ElseIf id_memo_type = "2" Then
            Report.LTitle.Text = "SALES CREDIT NOTE"
        ElseIf id_memo_type = "3" Then
            Report.LTitle.Text = "MISSING INVOICE"
        ElseIf id_memo_type = "4" Then
            Report.LTitle.Text = "MISSING CREDIT NOTE"
        ElseIf id_memo_type = "5" Then
            Report.LTitle.Text = "MISSING INVOICE PROMO"
        End If

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
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
        FormDocumentUpload.report_mark_type = report_mark_type
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
            calculate()
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
        Try
            MyCommand = New OleDbDataAdapter("select [F2] as code,SUM([F3]) as qty,[F4] AS price from [" & bof_xls_ws & "] WHERE NOT [F2] IS NULL AND NOT [F3]  IS NULL GROUP BY [F2],[F4]", oledbconn)
            MyCommand.Fill(data_temp)
            MyCommand.Dispose()
        Catch ex As Exception
            MyCommand = New OleDbDataAdapter("select [F2] as code,SUM([F3]) as qty,'' AS price from [" & bof_xls_ws & "] WHERE NOT [F2] IS NULL AND NOT [F3]  IS NULL GROUP BY [F2]", oledbconn)
            MyCommand.Fill(data_temp)
            MyCommand.Dispose()
        End Try

        'Try
        'get price master
        Dim price_per_date As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim query_price As String = "call view_product_price('AND d.id_active = 1', '" + price_per_date + "') "
        Dim dt_prc As DataTable = execute_query(query_price, -1, True, "", "", "", "")

        Dim tb1 = data_temp.AsEnumerable()
        Dim tb2 = dt_stock_store
        Dim tb3 = dt_prc.AsEnumerable()

        If id_menu = "1" Or id_menu = "4" Then
            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2
                        On table1("code").ToString Equals table_tmp("code").ToString Into sjoin = Group
                        From rs In sjoin.DefaultIfEmpty()
                        Join rp In tb3
                        On table1("code").ToString Equals rp("product_full_code").ToString
                        Select New With
                        {
                            .code = table1("code").ToString,
                            .name = If(rp Is Nothing, "", rp("design_display_name").ToString),
                            .size = If(rp Is Nothing, "", rp("size").ToString),
                            .sales_pos_det_qty = table1("qty"),
                            .limit_qty = If(rs Is Nothing, 0, rs("qty_all_product")),
                            .id_design_price = If(rp Is Nothing, "0", rp("id_design_price").ToString),
                            .design_price = If(rp Is Nothing, 0, rp("design_price")),
                            .design_price_type = If(rp Is Nothing, "", rp("design_price_type").ToString),
                            .id_design_price_retail = If(rp Is Nothing, "0", rp("id_design_price").ToString),
                            .design_price_retail = If(table1("price").ToString = "", If(rp Is Nothing, 0, rp("design_price")), table1("price")),
                            .id_design = If(rp Is Nothing, "0", rp("id_design").ToString),
                            .id_product = If(rp Is Nothing, "0", rp("id_product").ToString),
                            .note = If(rp Is Nothing, "Product not found", If(table1("qty") > If(rs Is Nothing, 0, rs("qty_all_product")), "+" + (table1("qty") - If(rs Is Nothing, 0, rs("qty_all_product"))).ToString, "OK")),
                            .id_sales_pos_det = "0"
                        }

            GCItemList.DataSource = Nothing
            GCItemList.DataSource = query.ToList()
            GCItemList.RefreshDataSource()
        ElseIf id_menu = "2" Or id_menu = "3" Then
            Dim query = From table1 In tb1
                        Join rp In tb3
                        On table1("code").ToString Equals rp("product_full_code").ToString
                        Select New With
                        {
                            .code = table1("code").ToString,
                            .name = If(rp Is Nothing, "", rp("design_display_name").ToString),
                            .size = If(rp Is Nothing, "", rp("size").ToString),
                            .sales_pos_det_qty = table1("qty"),
                            .id_design_price = If(rp Is Nothing, "0", rp("id_design_price").ToString),
                            .design_price = If(rp Is Nothing, 0, rp("design_price")),
                            .design_price_type = If(rp Is Nothing, "", rp("design_price_type").ToString),
                            .id_design_price_retail = If(rp Is Nothing, "0", rp("id_design_price").ToString),
                            .design_price_retail = If(table1("price").ToString = "", If(rp Is Nothing, 0, rp("design_price")), table1("price")),
                            .id_design = If(rp Is Nothing, "0", rp("id_design").ToString),
                            .id_product = If(rp Is Nothing, "0", rp("id_product").ToString),
                            .note = If(rp Is Nothing, "Product not found", "OK"),
                            .id_sales_pos_det = "0"
                        }

            GCItemList.DataSource = Nothing
            GCItemList.DataSource = query.ToList()
            GCItemList.RefreshDataSource()
        End If


        'Catch ex As Exception
        'stopCustom("Input must be in accordance with the format specified !")
        'Exit Sub
        'End Try
    End Sub

    Sub load_excel_ol_store()
        Dim oledbconn As New OleDbConnection
        Dim strConn As String
        Dim data_temp As New DataTable
        Dim bof_xls_path As String = get_setup_field("bof_xls_bill_order_path")
        Dim bof_xls_temp_path As String = get_setup_field("bof_xls_bill_order_temp_path")
        Dim bof_xls_ws As String = get_setup_field("bof_xls_bill_order_path_worksheet")

        File.Copy(bof_xls_path, bof_xls_temp_path, True)

        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & bof_xls_temp_path & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text;"""
        oledbconn.ConnectionString = strConn
        Dim MyCommand As OleDbDataAdapter
        MyCommand = New OleDbDataAdapter("select [F1] as ol_store_order from [" & bof_xls_ws & "] WHERE NOT [F1] IS NULL GROUP BY [F1]", oledbconn)


        MyCommand.Fill(data_temp)
        MyCommand.Dispose()

        'get del
        Dim query_del As String = "SELECT dd.id_pl_sales_order_del_det, d.pl_sales_order_del_number AS `del`, so.sales_order_ol_shop_number AS `ol_store_order`,p.id_product, p.id_design, p.product_full_code AS `code`, dsg.design_display_name AS `name`, cd.code_detail_name AS `size`,
        dd.pl_sales_order_del_det_qty AS `sales_pos_det_qty`, dd.id_design_price, dd.design_price, dd.id_design_price AS `id_design_price_retail`, dd.design_price AS `design_price_retail`, prct.design_price_type, '' AS `note`,'0' AS `id_sales_pos_det`
        FROM tb_pl_sales_order_del_det dd
        INNER JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
        INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
        LEFT JOIN (
	        SELECT ind.id_sales_pos_det, ind.id_pl_sales_order_del_det
	        FROM tb_sales_pos_det ind 
	        INNER JOIN tb_sales_pos inv ON inv.id_sales_pos = ind.id_sales_pos
	        WHERE inv.id_report_status!=5
        ) ind ON ind.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
        INNER JOIN tb_m_product p ON p.id_product = dd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product 
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail AND cd.id_code=33
        INNER JOIN tb_m_design dsg ON dsg.id_design = p.id_design
        INNER JOIN tb_m_design_price prc ON prc.id_design_price = dd.id_design_price
        INNER JOIN tb_lookup_design_price_type prct ON prct.id_design_price_type = prc.id_design_price_type
        WHERE d.id_store_contact_to='" + id_store_contact_from + "' AND d.id_report_status=6 AND !ISNULL(so.sales_order_ol_shop_number) AND so.sales_order_ol_shop_number!='' AND ISNULL(ind.id_sales_pos_det) "
        If LEInvType.EditValue.ToString = "4" Then
            query_del += "HAVING design_price_retail=0 "
        Else
            query_del += "HAVING design_price_retail>0 "
        End If
        Dim dtd As DataTable = execute_query(query_del, -1, True, "", "", "", "")


        Dim tb1 = data_temp.AsEnumerable()
        Dim tb2 = dtd.AsEnumerable()

        Try
            Dim dtr As DataTable = (From table1 In tb1
                                    Join rd In tb2
                                    On Trim(table1("ol_store_order").ToString) Equals Trim(rd("ol_store_order").ToString)
                                    Select rd).CopyToDataTable

            GCItemList.DataSource = Nothing
            GCItemList.DataSource = dtr
            GCItemList.RefreshDataSource()
        Catch ex As Exception
            stopCustom("Order not found or invoice is already created".ToUpper + System.Environment.NewLine + "Error Detail : " + ex.ToString)
        End Try
    End Sub

    Private Sub DEEnd_EditValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles DEEnd.EditValueChanging
        'If end_load Then
        '    Cursor = Cursors.WaitCursor
        '    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Changing end period will reset the list, are you sure To Continue??", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
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
            Dim query As String = "Select dr.id_wh_drawer, rack.id_wh_rack, Loc.id_wh_locator, cc.id_comp_contact, cc.id_comp, c.npwp, c.comp_number, c.comp_name, c.comp_commission, c.address_primary, c.id_so_type "
            query += " From tb_m_comp_contact cc "
            query += " INNER JOIN tb_m_comp c On c.id_comp=cc.id_comp"
            query += " INNER JOIN tb_m_wh_drawer dr ON dr.id_wh_drawer=c.id_drawer_def"
            query += " INNER JOIN tb_m_wh_rack rack ON rack.id_wh_rack=dr.id_wh_rack"
            query += " INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator=rack.id_wh_locator"
            query += " where cc.is_default=1 And c.id_comp_cat='" + id_comp_cat_store + "' AND c.comp_number='" + addSlashes(TxtCodeCompFrom.Text) + "'"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count <= 0 Then
                stopCustom("Store not found.")
                defaultReset()
                TxtCodeCompFrom.Focus()
            ElseIf data.Rows.Count > 1 Then
                FormPopUpContact.id_pop_up = "42"
                FormPopUpContact.id_cat = id_comp_cat_store
                FormPopUpContact.GVCompany.ActiveFilterString = "[comp_number]='" + addSlashes(TxtCodeCompFrom.Text) + "'"
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
                check_but()
                GroupControlList.Enabled = True
                calculate()
                check_do()
                '
                If id_menu = "4" Then
                    TxtCodeBillTo.Focus()
                Else
                    DEDueDate.Focus()
                End If
                'Else
                '    stopCustom("Store not registered for auto posting journal.")
                'End If
            End If
        Else
            defaultReset()
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
            Dim so_cat As String = ""
            Dim typ As String = LEInvType.EditValue.ToString
            If typ = "4" Then
                so_cat = "AND so.id_so_status=3 "
            Else
                so_cat = "AND so.id_so_status!=3 AND so.id_so_status!=7 AND so.id_so_status!=9 "
            End If

            Dim query As String = "SELECT pldel.id_pl_sales_order_del, so.sales_order_ol_shop_number, pldel.id_store_contact_to, comp.id_comp, comp.comp_name, comp.comp_number, comp.address_primary, comp.npwp, comp.id_drawer_def, comp.comp_commission, rck.id_wh_rack, loc.id_wh_locator, sp.id_sales_pos
            FROM tb_pl_sales_order_del pldel 
            INNER JOIN tb_sales_order so ON so.id_sales_order = pldel.id_sales_order "
            query += " INNER JOIN tb_m_comp_contact cc On cc.id_comp_contact=pldel.id_store_contact_to"
            query += " INNER JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
            INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = comp.id_drawer_def 
            INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack 
            INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
            query += " LEFT JOIN tb_sales_pos sp ON sp.id_pl_sales_order_del=pldel.id_pl_sales_order_del AND sp.id_report_status !=5 "
            query += " WHERE pldel.id_report_status='6' AND pldel.is_combine='2' AND pldel.pl_sales_order_del_number='" + addSlashes(TEDO.Text) + "' " + so_cat + " "
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count <= 0 Then
                stopCustom("Delivery order is not found for this store.")
                TxtOLStoreNumber.Text = ""
                defaultReset()
                TEDO.Focus()
            ElseIf Not data.Rows(0)("id_sales_pos").ToString = "" Then
                stopCustom("Invoice is already created.")
                TxtOLStoreNumber.Text = ""
                defaultReset()
                TEDO.Focus()
            Else
                'id DO
                id_do = data.Rows(0)("id_pl_sales_order_del").ToString
                id_store_contact_from = data.Rows(0)("id_store_contact_to").ToString
                id_comp = data.Rows(0)("id_comp").ToString
                id_wh_locator = data.Rows(0)("id_wh_locator").ToString
                id_wh_rack = data.Rows(0)("id_wh_rack").ToString
                id_wh_drawer = data.Rows(0)("id_drawer_def").ToString
                TxtOLStoreNumber.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
                MEAdrressCompFrom.Text = data.Rows(0)("address_primary").ToString
                TENPWP.Text = data.Rows(0)("npwp").ToString
                SPDiscount.EditValue = data.Rows(0)("comp_commission")
                PanelControlNav.Visible = False

                ' fill GV
                view_do()
                '
                calculate()
                '
                DEDueDate.Focus()
            End If
        Else
            TxtCodeCompFrom.Text = ""
            defaultReset()
        End If
    End Sub
    Sub view_do()
        Dim query_det As String = "CALL view_pl_sales_order_del_inv('" + id_do + "', '" + LEInvType.EditValue.ToString + "')"
        Dim data_det As DataTable = execute_query(query_det, "-1", True, "", "", "", "")
        GCItemList.DataSource = data_det
    End Sub
    Sub check_do()
        id_do = "-1"
        'TEDO.Text = ""
        'If LETypeSO.EditValue.ToString = "2" Then
        '    TEDO.Visible = True
        '    BDO.Visible = True
        '    '
        '    PanelControlNav.Visible = False
        'Else
        '    TEDO.Visible = False
        '    BDO.Visible = False
        '    '
        '    PanelControlNav.Visible = True
        'End If
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
        If id_do = "-1" Then
            viewDetail()
        End If

        If e.KeyCode = Keys.Enter Then
            If id_menu = "5" Then
                TxtOLStoreNumber.Focus()
            End If
        End If
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

    Private Sub DEEnd_EditValueChanged(sender As Object, e As EventArgs) Handles DEEnd.EditValueChanged
        'viewDetail()
    End Sub

    Private Sub LEInvType_KeyDown(sender As Object, e As KeyEventArgs) Handles LEInvType.KeyDown
        If e.KeyCode = Keys.Enter Then
            If LEInvType.EditValue.ToString = "0" Then
                TxtCodeCompFrom.Focus()
            Else
                TEDO.Focus()
            End If
        End If
    End Sub

    Private Sub LEInvType_EditValueChanged(sender As Object, e As EventArgs) Handles LEInvType.EditValueChanged
        If action = "ins" Then
            TEDO.Text = ""
            TxtOLStoreNumber.Text = ""
            TxtCodeCompFrom.Text = ""
            defaultReset()

            If LEInvType.EditValue.ToString = "0" Then
                TEDO.Enabled = True
                TxtCodeCompFrom.Enabled = True
                BtnBrowseContactFrom.Enabled = True
                PanelControlNav.Visible = True
            Else
                TEDO.Enabled = True
                TxtCodeCompFrom.Enabled = True
                BtnBrowseContactFrom.Enabled = True
                PanelControlNav.Visible = True
            End If
        End If
    End Sub

    Sub defaultReset()
        id_comp = "-1"
        id_wh_locator = "-1"
        id_wh_rack = "-1"
        id_wh_drawer = "-1"
        TxtNameCompFrom.Text = ""
        MEAdrressCompFrom.Text = ""
        TENPWP.Text = ""
        GCItemList.DataSource = Nothing
    End Sub

    Sub defaultResetBillTo()
        id_comp_contact_bill = "-1"
        TxtNameBillTo.Text = ""
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditInvType.CheckedChanged
        viewDetail()
    End Sub

    Private Sub BtnBrowseBillTo_Click(sender As Object, e As EventArgs) Handles BtnBrowseBillTo.Click
        FormPopUpContact.id_pop_up = "80"
        FormPopUpContact.id_cat = id_comp_cat_store
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub TxtCodeBillTo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeBillTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query As String = "SELECT dr.id_wh_drawer,rack.id_wh_rack,loc.id_wh_locator,cc.id_comp_contact,cc.id_comp,c.npwp,c.comp_number,c.comp_name,c.comp_commission,c.address_primary,c.id_so_type "
            query += " From tb_m_comp_contact cc "
            query += " INNER JOIN tb_m_comp c On c.id_comp=cc.id_comp"
            query += " INNER JOIN tb_m_wh_drawer dr ON dr.id_wh_drawer=c.id_drawer_def"
            query += " INNER JOIN tb_m_wh_rack rack ON rack.id_wh_rack=dr.id_wh_rack"
            query += " INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator=rack.id_wh_locator"
            query += " where cc.is_default=1 And c.id_comp_cat='" + id_comp_cat_store + "' AND c.comp_number='" + addSlashes(TxtCodeBillTo.Text) + "'"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count <= 0 Then
                stopCustom("Store not found.")
                defaultResetBillTo()
                TxtCodeBillTo.Focus()
            ElseIf data.Rows.Count > 1 Then
                FormPopUpContact.id_pop_up = "80"
                FormPopUpContact.id_cat = id_comp_cat_store
                FormPopUpContact.GVCompany.ActiveFilterString = "[comp_number]='" + addSlashes(TxtCodeBillTo.Text) + "'"
                FormPopUpContact.ShowDialog()
            Else
                'If check_acc(data.Rows(0)("id_comp").ToString) Then
                SPDiscount.EditValue = data.Rows(0)("comp_commission")
                id_comp_contact_bill = data.Rows(0)("id_comp_contact").ToString
                TxtNameBillTo.Text = data.Rows(0)("comp_name").ToString
                TxtCodeBillTo.Text = data.Rows(0)("comp_number").ToString
                calculate()
                check_do()
                '
                DEDueDate.Focus()
                'Else
                '    stopCustom("Store not registered for auto posting journal.")
                'End If
            End If
        Else
            defaultResetBillTo()
        End If
    End Sub

    Private Sub BtnBrowseInvoice_Click(sender As Object, e As EventArgs)
        showInv()
    End Sub

    Sub showInv()
        Cursor = Cursors.WaitCursor
        FormSalesCreditNotePopInv.id_pop_up = "4"
        FormSalesCreditNotePopInv.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnListProduct_Click(sender As Object, e As EventArgs) Handles BtnListProduct.Click
        Cursor = Cursors.WaitCursor
        FormSalesCreditNoteSingle.id_sales_pos_ref = id_sales_pos_ref
        FormSalesCreditNoteSingle.action_pop = "ins"
        FormSalesCreditNoteSingle.id_pop_up = "3"
        FormSalesCreditNoteSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnImportOLStore_Click(sender As Object, e As EventArgs) Handles BtnImportOLStore.Click
        Cursor = Cursors.WaitCursor
        If id_store_contact_from = "-1" Then
            stopCustom("Store can't blank")
        Else
            load_excel_ol_store()
            calculate()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtOLStoreNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtOLStoreNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query As String = "SELECT inv.id_sales_pos, inv.sales_pos_number, so.sales_order_ol_shop_number, inv.sales_pos_discount, inv.sales_pos_vat
            FROM tb_sales_pos_det ind
            INNER JOIN tb_sales_pos inv ON inv.id_sales_pos = ind.id_sales_pos
            INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del_det = ind.id_pl_sales_order_del_det
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = deld.id_sales_order_det
            INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
            WHERE so.sales_order_ol_shop_number='" + addSlashes(TxtOLStoreNumber.Text) + "' AND inv.id_report_status=6
            GROUP BY inv.id_sales_pos "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count = 1 Then
                id_sales_pos_ref = data.Rows(0)("id_sales_pos").ToString
                TxtInvoice.Text = data.Rows(0)("sales_pos_number").ToString
                TxtOLStoreNumber.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
                SPDiscount.EditValue = data.Rows(0)("sales_pos_discount")
                SPVat.EditValue = data.Rows(0)("sales_pos_vat")
                calculate()
                viewDetail()
                BtnListProduct.Focus()
            ElseIf data.Rows.Count > 1 Then
                Dim cond As String = ""
                For i As Integer = 0 To data.Rows.Count - 1
                    If i > 0 Then
                        cond += "OR "
                    ElseIf i = 0 Then
                        cond += "AND ( "
                    End If
                    cond += "a.id_sales_pos=" + data.Rows(i)("id_sales_pos").ToString + " "
                Next
                If cond <> "" Then
                    cond += ") "
                End If
                FormSalesCreditNotePopInv.cond = cond
                showInv()
            Else
                stopCustom("Invoice order not found.")
                id_sales_pos_ref = "-1"
                TxtInvoice.Text = ""
                TxtOLStoreNumber.Text = ""
                SPDiscount.EditValue = 0
                SPVat.EditValue = vat_def
                calculate()
                viewDetail()
            End If
        Else
            id_sales_pos_ref = "-1"
            TxtInvoice.Text = ""
            SPDiscount.EditValue = 0
            SPVat.EditValue = vat_def
            calculate()
            viewDetail()
        End If
    End Sub

    Private Sub BtnDraftJournal_Click(sender As Object, e As EventArgs) Handles BtnDraftJournal.Click
        viewDraft()
    End Sub

    Sub viewDraft()
        Cursor = Cursors.WaitCursor
        If id_report_status <> "1" Then
            FormAccountingDraftJournal.is_view = "1"
        End If
        FormAccountingDraftJournal.id_report = id_sales_pos
        FormAccountingDraftJournal.report_number = TxtVirtualPosNumber.Text
        FormAccountingDraftJournal.report_mark_type = report_mark_type
        FormAccountingDraftJournal.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If GVItemList.RowCount > 0 And GVItemList.FocusedRowHandle >= 0 And action = "ins" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
                GCItemList.RefreshDataSource()
                GVItemList.RefreshData()
                calculate()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opened(sender As Object, e As EventArgs) Handles ContextMenuStrip1.Opened
        If action = "ins" Then
            PriceToolStripMenuItem.Visible = True
            DeleteToolStripMenuItem.Visible = True
        Else
            PriceToolStripMenuItem.Visible = False
            DeleteToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub PriceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PriceToolStripMenuItem.Click
        If GVItemList.RowCount > 0 And GVItemList.FocusedRowHandle >= 0 And action = "ins" Then
            FormSalesPosPrice.id_design = GVItemList.GetFocusedRowCellValue("id_design").ToString
            FormSalesPosPrice.ShowDialog()
            GCItemList.RefreshDataSource()
            GVItemList.RefreshData()
            calculate()
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        print_raw(GCItemList, "")
    End Sub

    Private Sub TxtPotPenjualan_EditValueChanged(sender As Object, e As EventArgs) Handles TxtPotPenjualan.EditValueChanged
        calculate()
    End Sub
End Class