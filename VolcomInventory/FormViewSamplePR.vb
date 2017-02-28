Public Class FormViewSamplePR
    Public id_rec As String = "-1"
    Public id_purc As String = "-1"
    Public id_pr As String = "-1"
    Public id_comp_contact_pay_to As String = "-1"
    Public is_payment As String = "-1"

    Private Sub FormViewSamplePR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DEPIBKDate.EditValue = Now
        view_report_status(LEReportStatus)
        view_currency(LECurrency)
        view_payment_status(LEPaymentStatus)

        Dim query As String = "SELECT z.pibk_no,z.pibk_date,z.inv_no,z.pr_sample_purc_dp,z.pr_sample_purc_vat,z.id_pr_sample_purc,z.id_comp_contact_to,z.id_report_status,z.pr_sample_purc_number,z.pr_sample_purc_note,DATE_FORMAT(z.pr_sample_purc_date,'%Y-%m-%d') as pr_sample_purc_date,g.season_orign,a.id_sample_purc_rec,a.sample_purc_rec_number,a.delivery_order_number,b.sample_purc_number,DATE_FORMAT(a.sample_purc_rec_date,'%d %M %Y') AS sample_purc_rec_date,d.comp_name AS comp_to,b.id_sample_purc,z.id_payment_status "
        query += "FROM tb_pr_sample_purc z "
        query += "LEFT JOIN tb_sample_purc_rec a ON z.id_sample_purc_rec = a.id_sample_purc_rec "
        query += "INNER JOIN tb_sample_purc b ON z.id_sample_purc=b.id_sample_purc "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_season_orign g ON g.id_season_orign=b.id_season_orign "
        query += "WHERE z.id_pr_sample_purc ='" & id_pr & "' "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEPRNumber.Text = data.Rows(0)("pr_sample_purc_number").ToString
        TEPRDate.Text = view_date_from(data.Rows(0)("pr_sample_purc_date").ToString, 0)
        MENote.Text = data.Rows(0)("pr_sample_purc_note").ToString
        '
        LEReportStatus.EditValue = Nothing
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

        LEPaymentStatus.EditValue = Nothing
        LEPaymentStatus.ItemIndex = LEPaymentStatus.Properties.GetDataSourceRowIndex("id_payment_status", data.Rows(0)("id_payment_status").ToString)

        TEDONumber.Text = data.Rows(0)("delivery_order_number").ToString
        TERecNumber.Text = data.Rows(0)("sample_purc_rec_number").ToString
        '
        TEPIBKNo.Text = data.Rows(0)("pibk_no").ToString
        DEPIBKDate.EditValue = data.Rows(0)("pibk_date")
        TEInvNo.Text = data.Rows(0)("inv_no").ToString
        '
        id_purc = data.Rows(0)("id_sample_purc").ToString
        view_po()

        id_comp_contact_pay_to = data.Rows(0)("id_comp_contact_to").ToString
        TECompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
        MECompAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "3")

        GConListPurchase.Enabled = True
        view_list_pr()

        TEVat.Text = data.Rows(0)("pr_sample_purc_vat").ToString

        TEDPTot.Text = data.Rows(0)("pr_sample_purc_dp").ToString

        calculate()
        If is_payment = "1" Then
            GCPayment.Visible = True
            GCMark.Visible = False
            LEPaymentStatus.Enabled = True
        Else
            GCMark.Visible = True
            GCPayment.Visible = False
            LEPaymentStatus.Enabled = False
        End If
    End Sub

    Private Sub view_payment_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_payment_status,payment_status FROM tb_lookup_payment_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "payment_status"
        lookup.Properties.ValueMember = "id_payment_status"
        lookup.ItemIndex = 0
    End Sub

    Sub view_list_purchase()
        Dim query = "CALL view_pr_sample_from_po('" & id_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data

        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub

    Sub view_list_pr()
        Dim query = "CALL view_pr_sample_from_pr('" & id_pr & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data

        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub

    Sub view_list_rec()
        Dim query = "CALL view_pr_sample_from_rec('" & id_rec & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data

        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub

    Sub view_po()
        Dim query As String = String.Format("SELECT id_report_status,sample_purc_vat,id_season_orign,sample_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,DATE_FORMAT(sample_purc_date,'%Y-%m-%d') as sample_purc_datex,sample_purc_lead_time,sample_purc_top,id_currency,sample_purc_note FROM tb_sample_purc WHERE id_sample_purc = '{0}'", id_purc)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEPONumber.Text = data.Rows(0)("sample_purc_number").ToString

        view_currency(LECurrency)
        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
        LECurrency.Properties.ReadOnly = True

        id_comp_contact_pay_to = data.Rows(0)("id_comp_contact_to").ToString
        TECompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
        MECompAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "3")

        TEDueDate.Text = view_date_from(data.Rows(0)("sample_purc_datex").ToString, (Integer.Parse(data.Rows(0)("sample_purc_lead_time").ToString) + Integer.Parse(data.Rows(0)("sample_purc_top").ToString)))
        TEVat.Text = data.Rows(0)("sample_purc_vat").ToString
    End Sub

    Sub view_rec()
        Dim query As String = "SELECT d.id_sample_purc,a.id_sample_purc_rec, a.sample_purc_rec_number, a.delivery_order_number,  a.delivery_order_date, a.sample_purc_rec_date, "
        query += "(SELECT COUNT(tb_pr_sample_purc.id_pr_sample_purc) FROM tb_pr_sample_purc WHERE tb_pr_sample_purc.id_sample_purc_rec = a.id_sample_purc_rec) AS pr_created, "
        query += "a.sample_purc_rec_note, c.comp_name, c.comp_number,e.season_orign, a.id_comp_contact_to  "
        query += "FROM tb_sample_purc_rec a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_to = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp "
        query += "INNER join tb_sample_purc d on a.id_sample_purc = d.id_sample_purc "
        query += "INNER JOIN tb_season_orign e ON e.id_season_orign = d.id_season_orign "
        query += "WHERE a.id_sample_purc_rec = '" & id_rec & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TERecNumber.Text = data.Rows(0)("sample_purc_rec_number").ToString
        id_purc = data.Rows(0)("id_sample_purc").ToString
        TEPONumber.Text = data.Rows(0)("sample_purc_rec_number").ToString
        TEDONumber.Text = data.Rows(0)("delivery_order_number").ToString
        TECompTo.Text = data.Rows(0)("comp_name").ToString
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

    Sub calculate()
        Dim tot_credit, tot_debit, total, gross_tot, vat, dp As Decimal

        Try
            tot_credit = Decimal.Parse(GVListPurchase.Columns("total").SummaryText.ToString)
            tot_debit = Decimal.Parse(GVListPurchase.Columns("debit").SummaryText.ToString)
            gross_tot = tot_credit - tot_debit
            dp = Decimal.Parse(TEDPTot.EditValue)

            If dp <= 0 Or dp.ToString = "" Then
                vat = (Decimal.Parse(TEVat.Text) / 100) * gross_tot
            Else
                vat = (Decimal.Parse(TEVat.Text) / 100) * dp
            End If
        Catch ex As Exception
        End Try

        TEVatTot.Text = vat.ToString("0.00")
        TEDPTot.Text = dp.ToString("0.00")

        TEGrossTot.Text = gross_tot.ToString("0.00")

        If dp.ToString = "" Or dp = 0 Then
            total = gross_tot + vat
        Else
            total = dp + vat
        End If

        TETot.Text = total.ToString("0.00")

        Try
            METotSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), LECurrency.EditValue.ToString)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
        If e.Column.FieldName = "total" Then
            If Not e.DisplayText = "" Then
                e.DisplayText = Decimal.Parse(e.DisplayText).ToString("N2")
            End If
        End If
        If e.Column.FieldName = "debit" Then
            If Not e.DisplayText = "" Then
                e.DisplayText = Decimal.Parse(e.DisplayText).ToString("N2")
            End If
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_pr
        FormReportMark.report_mark_type = "4"
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMappingCOA.Click
        FormMappingCOA.report_mark_type = "4"
        FormMappingCOA.ShowDialog()
    End Sub
End Class