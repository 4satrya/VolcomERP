Public Class FormViewSalesPOS 
    Public action As String
    Public id_sales_pos As String = "0"
    Public id_store_contact_from As String = "-1"
    Public id_comp_contact_bill As String = "-1"
    Public id_report_status As String
    Public id_sales_pos_det_list As New List(Of String)
    Public id_comp As String = "-1"
    Dim total_amount As Decimal = 0.0
    Dim currency As String = "-1"
    Dim id_comp_cat_store As String = "-1"
    Dim id_memo_type As String = "-1"
    Dim report_mark_type As String = "-1"

    'menu : 1=invoice 2=credit note
    Public id_menu As String = "1"


    Private Sub FormSalesPOSDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            LabelControl1.Text = "Missing From"
            LabelBillTo.Visible = True
            TxtCodeBillTo.Visible = True
            TxtNameBillTo.Visible = True
        ElseIf id_menu = "5" Then
            Text = "Credit Note Online Store"
            LEInvType.Enabled = False
            TEDO.Enabled = False
            CheckEditInvType.Visible = False
            LabelInvoice.Visible = True
            TxtInvoice.Visible = True
            TxtCodeCompFrom.Focus()
        End If

        actionLoad()
    End Sub

    Sub actionLoad()
        GroupControlList.Enabled = True
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
        '
        BtnAttachment.Enabled = True
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
        LEInvType.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_inv_type", data.Rows(0)("id_inv_type").ToString)
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
        viewDetailCode()
        check_but()
        calculate()
        allow_status()
    End Sub
    Sub check_do()
        'TEDO.Text = ""
        'If LETypeSO.EditValue.ToString = "1" Then
        '    LDO.Visible = False
        '    TEDO.Visible = False
        'Else
        '    LDO.Visible = True
        '    TEDO.Visible = True
        'End If
    End Sub

    Sub viewInvType()
        Dim query As String = "SELECT * FROM tb_lookup_inv_type i ORDER BY i.id_inv_type ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEInvType, query, 0, "inv_type_display", "id_inv_type")
    End Sub

    Sub calculate()
        getDiscount()
        getNetto()
        getVat()
        getTaxBase()
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
        GCItemList.DataSource = data
    End Sub

    Sub viewDetailCode()
        Dim query As String = "SELECT c.id_sales_pos_det_counting, c.id_sales_pos, c.id_product, c.id_pl_prod_order_rec_det_unique, c.counting_code, 
        c.full_code, prod.product_full_code AS `code`, prod.product_display_name AS `name`, cd.code_detail_name AS `size`, c.id_design_price, c.design_price
        FROM tb_sales_pos_det_counting c
        INNER JOIN tb_m_product prod ON prod.id_product = c.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        WHERE c.id_sales_pos=" + id_sales_pos + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCode.DataSource = data
        GVCode.BestFitColumns()
    End Sub


    'sub check_but
    Sub check_but()
       
    End Sub

    Sub allow_status()
        GVItemList.OptionsBehavior.Editable = False
        MENote.Properties.ReadOnly = True
        LETypeSO.Enabled = False

        'update 8 oktocer 2014
        DEDueDate.Properties.ReadOnly = True
        SPDiscount.Properties.ReadOnly = True
        SPVat.Properties.ReadOnly = True
        DEStart.Properties.ReadOnly = True
        DEEnd.Properties.ReadOnly = True

        'update 04 oktober 2017
        LEInvType.Enabled = False
        TEDO.Properties.ReadOnly = True
        TxtCodeCompFrom.Enabled = False
        TxtNameCompFrom.Enabled = False
        CheckEditInvType.Enabled = False

        TxtCodeBillTo.Enabled = False
        TxtNameBillTo.Enabled = False

        BtnAttachment.Enabled = True
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

    Private Sub FormSalesPOSDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        check_but()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub sayCurr()
        total_amount = Double.Parse(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)
        METotSay.Text = ConvertCurrencyToEnglish(total_amount, currency)
    End Sub


    Private Sub SPDiscount_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPDiscount.EditValueChanged
        getDiscount()
        getNetto()
        getVat()
        getTaxBase()
    End Sub

    Private Sub SPVat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPVat.EditValueChanged
        getVat()
        getTaxBase()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_sales_pos
        FormReportMark.report_mark_type = report_mark_type
        FormReportMark.form_origin = Name
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sales_pos
        FormDocumentUpload.report_mark_type = report_mark_type
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDraft_Click(sender As Object, e As EventArgs) Handles BtnDraft.Click
        Cursor = Cursors.WaitCursor
        FormAccountingDraftJournal.is_view = "1"
        FormAccountingDraftJournal.id_report = id_sales_pos
        FormAccountingDraftJournal.report_number = TxtVirtualPosNumber.Text
        FormAccountingDraftJournal.report_mark_type = report_mark_type
        FormAccountingDraftJournal.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVCode_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVCode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class