Public Class FormViewSamplePurchase
    Public id_sample_purc As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_comp_ship_to As String = "-1"
    Public id_comp_contact_courier As String = "-1"

    Public date_created As String = ""
    Private Sub FormViewSamplePurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_currency(LECurrency)
        view_po_type(LEPOType)
        viewSeason(LESeason)
        view_payment_type(LEpayment)
        view_report_status(LEReportStatus)

        Dim query As String = String.Format("SELECT id_comp_contact_courier,courier_comm,id_report_status,sample_purc_vat,id_season_orign,sample_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,DATE_FORMAT(sample_purc_date,'%Y-%m-%d') as sample_purc_datex,sample_purc_lead_time,sample_purc_top,id_currency,sample_purc_note FROM tb_sample_purc WHERE id_sample_purc = '{0}'", id_sample_purc)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEPONumber.Text = data.Rows(0)("sample_purc_number").ToString

        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

        'LEpayment.EditValue = Nothing
        LEpayment.ItemIndex = LEpayment.Properties.GetDataSourceRowIndex("id_payment", data.Rows(0)("id_payment").ToString)

        LEReportStatus.EditValue = Nothing
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

        LESeason.EditValue = data.Rows(0)("id_season_orign").ToString
        LEPOType.EditValue = data.Rows(0)("id_po_type").ToString()

        id_comp_to = data.Rows(0)("id_comp_contact_to").ToString
        TECompName.Text = get_company_x(get_id_company(id_comp_to), "1")
        TECompCode.Text = get_company_x(get_id_company(id_comp_to), "2")
        MECompAddress.Text = get_company_x(get_id_company(id_comp_to), "3")
        TECompAttn.Text = get_company_contact_x(id_comp_to, "1")

        id_comp_ship_to = data.Rows(0)("id_comp_contact_ship_to").ToString
        TECompShipToName.Text = get_company_x(get_id_company(id_comp_ship_to), "1")
        TECompShipTo.Text = get_company_x(get_id_company(id_comp_ship_to), "2")
        MECompShipToAddress.Text = get_company_x(get_id_company(id_comp_ship_to), "3")

        Try
            id_comp_contact_courier = data.Rows(0)("id_comp_contact_courier").ToString
            TECourier.Text = get_company_x(get_id_company(id_comp_contact_courier), "1")
            TECourierCode.Text = get_company_x(get_id_company(id_comp_contact_courier), "2")
        Catch ex As Exception
        End Try

        TEComm.EditValue = data.Rows(0)("courier_comm")

        MENote.Text = data.Rows(0)("sample_purc_note").ToString

        date_created = data.Rows(0)("sample_purc_datex").ToString
        TEDate.Text = view_date_from(date_created, 0)
        TELeadTime.Text = data.Rows(0)("sample_purc_lead_time").ToString
        TERecDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("sample_purc_lead_time").ToString))
        TETOP.Text = data.Rows(0)("sample_purc_top").ToString
        TEDueDate.Text = view_date_from(date_created, (Integer.Parse(data.Rows(0)("sample_purc_lead_time").ToString) + Integer.Parse(data.Rows(0)("sample_purc_top").ToString)))
        '
        GConListPurchase.Enabled = True
        TEVat.Properties.ReadOnly = True
        view_list_purchase()
        TEVat.Text = data.Rows(0)("sample_purc_vat").ToString
        calculate()
    End Sub
    Sub view_list_purchase()
        Dim query = "CALL view_purc_sample_det('" & id_sample_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
    End Sub

    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_report_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "report_status"
        lookup.Properties.ValueMember = "id_report_status"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_payment_type(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_payment,payment FROM tb_lookup_payment"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "payment"
        lookup.Properties.ValueMember = "id_payment"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_po_type(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_po_type,po_type FROM tb_lookup_po_type ORDER BY id_po_type DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "po_type"
        lookup.Properties.ValueMember = "id_po_type"
        lookup.EditValue = data.Rows(0)("id_po_type").ToString
    End Sub
    'View Season
    Private Sub viewSeason(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_season_orign,season_orign FROM tb_season_orign ORDER BY id_season_orign DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "season_orign"
        lookup.Properties.ValueMember = "id_season_orign"
        lookup.EditValue = data.Rows(0)("id_season_orign").ToString
    End Sub
    Sub calculate()
        Dim total, sub_tot, gross_tot, vat, discount As Decimal

        Try
            sub_tot = Decimal.Parse(GVListPurchase.Columns("total").SummaryText.ToString)
            vat = (Decimal.Parse(TEVat.Text) / 100) * Decimal.Parse(GVListPurchase.Columns("total").SummaryText.ToString)
            discount = Decimal.Parse(GVListPurchase.Columns("discount").SummaryText.ToString)
        Catch ex As Exception
        End Try

        TEDiscount.Text = discount.ToString("0.00")
        TEVatTot.Text = vat.ToString("0.00")

        gross_tot = sub_tot + discount
        TEGrossTot.Text = gross_tot.ToString("0.00")

        total = sub_tot + vat
        TETot.Text = total.ToString("0.00")
        METotSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), LECurrency.EditValue.ToString)
    End Sub
    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_sample_purc
        FormReportMark.report_mark_type = "1"
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BAttach_Click(sender As Object, e As EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sample_purc
        FormDocumentUpload.report_mark_type = "1"
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class