Public Class FormViewProductionWO
    Public id_wo As String = "-1"
    Public id_ovh_price As String = "-1"
    Public id_po As String = "-1"
    Public id_prod_demand_design As String = "-1"
    Public id_comp_ship_to As String = "-1"
    Public date_created As Date
    Public id_report_status_g As String = "1"
    Public id_wo_type As String = "-1"
    Public id_design As String = "-1"

    Private Sub FormViewProductionWO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_currency(LECurrency)
        viewSeason(LESeason)
        'view delivery
        view_payment_type(LEpayment)

        TEDelDate.EditValue = Now

        Dim default_kurs As Decimal = 1.0
        TEKurs.EditValue = default_kurs

        date_created = Now
        DEDateNow.EditValue = date_created
        DEEstRecDate.EditValue = date_created
        DEDueDate.EditValue = date_created

        BMark.Visible = True

        Dim query = "SELECT pdd.id_design,a.id_report_status,h.report_status,a.id_prod_order_wo,a.id_ovh_price,a.id_payment, "
        query += "a.id_prod_order,g.payment,b.id_currency,a.prod_order_wo_note,a.prod_order_wo_kurs, "
        query += "d.comp_name AS comp_name_to, "
        query += "f.comp_name AS comp_name_ship_to,a.id_comp_contact_ship_to, "
        query += "a.prod_order_wo_number,a.id_ovh_price,j.overhead, "
        query += "a.prod_order_wo_del_date, "
        query += "DATE_FORMAT(a.prod_order_wo_date,'%Y-%m-%d') as prod_order_wo_datex,a.prod_order_wo_date,a.prod_order_wo_lead_time,a.prod_order_wo_top,a.prod_order_wo_vat, a.is_main_vendor "
        query += "FROM tb_prod_order_wo a INNER JOIN tb_m_ovh_price b ON a.id_ovh_price=b.id_ovh_price "
        query += "INNER JOIN tb_prod_order po ON po.id_prod_order=a.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design "
        query += "INNER JOIN tb_m_comp_contact c ON b.id_comp_contact = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_ovh j ON b.id_ovh = j.id_ovh "
        query += "WHERE a.id_prod_order_wo='" & id_wo & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        id_po = data.Rows(0)("id_prod_order").ToString
        id_design = data.Rows(0)("id_design").ToString
        load_po(id_po)
        '
        id_ovh_price = data.Rows(0)("id_ovh_price").ToString
        '
        TEWONumber.Text = data.Rows(0)("prod_order_wo_number").ToString
        '
        TEKurs.EditValue = data.Rows(0)("prod_order_wo_kurs")

        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

        LEpayment.EditValue = Nothing
        LEpayment.ItemIndex = LEpayment.Properties.GetDataSourceRowIndex("id_payment", data.Rows(0)("id_payment").ToString)

        id_report_status_g = data.Rows(0)("id_report_status").ToString

        TEWO.Text = data.Rows(0)("overhead").ToString()

        id_comp_ship_to = data.Rows(0)("id_comp_contact_ship_to").ToString
        TECompShipToName.Text = get_company_x(get_id_company(id_comp_ship_to), "1")
        TECompShipTo.Text = get_company_x(get_id_company(id_comp_ship_to), "2")
        MECompShipToAddress.Text = get_company_x(get_id_company(id_comp_ship_to), "3")

        MENote.Text = data.Rows(0)("prod_order_wo_note").ToString

        date_created = data.Rows(0)("prod_order_wo_date")
        DEDateNow.EditValue = date_created
        'Dim tgl_delivery() As String = data.Rows(0)("prod_order_wo_del_date").ToString.Split(" ")
        'TEDelDate.Text = tgl_delivery(0)

        TEDelDate.EditValue = data.Rows(0)("prod_order_wo_del_date")

        TELeadTime.Text = data.Rows(0)("prod_order_wo_lead_time").ToString
        DEEstRecDate.EditValue = date_created.AddDays(data.Rows(0)("prod_order_wo_lead_time"))
        'TERecDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("prod_order_wo_lead_time").ToString))

        TETOP.Text = data.Rows(0)("prod_order_wo_top").ToString
        DEDueDate.EditValue = date_created.AddDays(data.Rows(0)("prod_order_wo_lead_time") + (data.Rows(0)("prod_order_wo_top")))
        'TEDueDate.Text = view_date_from(date_created, (Integer.Parse(data.Rows(0)("prod_order_wo_lead_time").ToString) + Integer.Parse(data.Rows(0)("prod_order_wo_top").ToString)))
        '
        GConListPurchase.Enabled = True
        'BPickWO.Enabled = False
        TEVat.Properties.ReadOnly = False
        Dim is_main_vendor As Boolean

        If data.Rows(0)("is_main_vendor").ToString = "1" Then
            is_main_vendor = True
            Text = "View F.G. Purchase Order"
        Else
            is_main_vendor = False
        End If

        CheckEditMainVendor.EditValue = is_main_vendor

        load_wo()
        TEVat.Text = data.Rows(0)("prod_order_wo_vat").ToString
        calculate()
        'load bom unit price
        Dim query_bom As String = "SELECT * FROM tb_bom_det bomd
                                    INNER JOIN tb_bom bom ON bom.`id_bom`=bomd.`id_bom`
                                    INNER JOIN tb_m_product prod ON prod.`id_product`=bom.`id_product`
                                    INNER JOIN tb_m_ovh_price ovhp ON ovhp.id_ovh_price=bomd.id_ovh_price
                                    WHERE bom.`is_default`='1' 
                                    AND id_component_category='2' 
                                    AND ovhp.id_ovh=(SELECT id_ovh FROM tb_m_ovh_price WHERE id_ovh_price='" & id_ovh_price & "')
                                    AND prod.`id_design`='" & id_design & "'
                                    GROUP BY id_design"
        Dim datatable As DataTable = execute_query(query_bom, -1, True, "", "", "", "")
        If datatable.Rows.Count > 0 Then
            TEBOMUnitPrice.EditValue = datatable.Rows(0)("bom_price")
            If GVListPurchase.RowCount > 0 Then
                TEBOMDiff.EditValue = TEBOMUnitPrice.EditValue - GVListPurchase.GetFocusedRowCellValue("estimate_cost")
            End If
        End If
    End Sub

    Sub load_po(ByVal id_po As String)
        Dim query As String = String.Format("SELECT *,DATE_FORMAT(prod_order_date,'%Y-%m-%d') as prod_order_datex FROM tb_prod_order WHERE id_prod_order = '{0}'", id_po)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        id_prod_demand_design = data.Rows(0)("id_prod_demand_design").ToString
        TEDesign.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "1")
        LESeason.EditValue = get_id_season(get_prod_demand_design_x(id_prod_demand_design, "2"))
        LEDelivery.EditValue = get_prod_demand_design_x(id_prod_demand_design, "2")
        TEPONumber.Text = data.Rows(0)("prod_order_number").ToString
        TEDesignCode.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "2")
    End Sub
    Sub load_wo()
        view_list_purchase()

        Dim query As String = "SELECT a.id_currency, a.ovh_price, b.overhead as name, b.overhead_code as code,a.id_comp_contact from tb_m_ovh_price a INNER JOIN tb_m_ovh b ON a.id_ovh=b.id_ovh WHERE a.id_ovh_price='" & id_ovh_price & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEWO.Text = data.Rows(0)("name").ToString
        TEWOCode.Text = data.Rows(0)("code").ToString
        TECompCode.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact").ToString), "2")
        TECompName.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact").ToString), "1")
        MECompAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact").ToString), "3")
        TECompAttn.Text = get_company_contact_x(data.Rows(0)("id_comp_contact").ToString, "1")
        LECurrency.EditValue = data.Rows(0)("id_currency").ToString

        query = "SELECT id_prod_order_det,prod_order_wo_det_qty,prod_order_wo_det_price FROM tb_prod_order_wo_det WHERE id_prod_order_wo='" & id_wo & "'"
        data = execute_query(query, -1, True, "", "", "", "")

        For i As Integer = 0 To data.Rows.Count - 1
            Try
                Dim qty, price, subtotal As Decimal
                qty = Decimal.Parse(data.Rows(i)("prod_order_wo_det_qty").ToString)
                price = Decimal.Parse(data.Rows(i)("prod_order_wo_det_price").ToString)
                subtotal = qty * price
                Dim rowh As Integer = find_row(GVListPurchase, "id_prod_order_det", data.Rows(i)("id_prod_order_det").ToString)
                GVListPurchase.SetRowCellValue(rowh, "estimate_cost", price)
                GVListPurchase.SetRowCellValue(rowh, "total_cost", subtotal)
            Catch ex As Exception
            End Try
        Next

        calculate()
    End Sub

    Sub view_list_purchase()
        Dim query = "CALL view_prod_order_det('" & id_po & "','1')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        calculate()
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
    Private Sub view_wo_type(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_ovh,overhead FROM tb_m_ovh ORDER BY id_ovh ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "overhead"
        lookup.Properties.ValueMember = "id_ovh"
        lookup.EditValue = data.Rows(0)("id_ovh").ToString
        id_wo_type = lookup.EditValue.ToString
    End Sub
    'View Season
    Private Sub viewSeason(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_season,season FROM tb_season ORDER BY id_season DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "season"
        lookup.Properties.ValueMember = "id_season"

        If data.Rows.Count > 0 Then
            lookup.EditValue = data.Rows(0)("id_season").ToString
            view_delivery(data.Rows(0)("id_season").ToString, LEDelivery)
        End If
    End Sub
    Sub view_delivery(ByVal id_season As String, ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_delivery,delivery FROM tb_season_delivery WHERE id_season='" & id_season & "' ORDER BY id_delivery DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "delivery"
        lookup.Properties.ValueMember = "id_delivery"
        If data.Rows.Count > 0 Then
            lookup.EditValue = data.Rows(0)("id_delivery").ToString
        End If
    End Sub

    Private Sub TELeadTime_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TELeadTime.EditValueChanged
        If id_wo <> "-1" Then
            Try
                'TERecDate.Text = view_date_from(date_created, Integer.Parse(TELeadTime.Text))
                DEEstRecDate.EditValue = date_created.AddDays(TELeadTime.EditValue)
                DEDueDate.EditValue = date_created.AddDays(TELeadTime.EditValue + TETOP.EditValue)
            Catch ex As Exception
                ' DEEstRecDate.EditValue = date_created
            End Try
        Else
            Try
                'TERecDate.Text = view_date(Integer.Parse(TELeadTime.Text))
                DEEstRecDate.EditValue = date_created.AddDays(TELeadTime.EditValue)
                DEDueDate.EditValue = date_created.AddDays(TELeadTime.EditValue + TETOP.EditValue)
            Catch ex As Exception
                'TERecDate.Text = view_date(0)
                'DEEstRecDate.EditValue = date_created
            End Try
        End If
    End Sub

    Private Sub TETOP_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TETOP.EditValueChanged

        If id_wo <> "-1" Then
            Try
                'TEDueDate.Text = view_date_from(date_created, (Integer.Parse(TELeadTime.Text) + Integer.Parse(TETOP.Text)))\
                DEDueDate.EditValue = date_created.AddDays(TELeadTime.EditValue + TETOP.EditValue)
            Catch ex As Exception
                'TEDueDate.Text = view_date_from(date_created, 0)
                'DEDueDate.EditValue = Now
            End Try
        Else
            Try
                'TEDueDate.Text = view_date(Integer.Parse(TELeadTime.Text) + Integer.Parse(TETOP.Text))
                DEDueDate.EditValue = date_created.AddDays(TELeadTime.EditValue + TETOP.EditValue)
            Catch ex As Exception
                'TEDueDate.Text = view_date(0)
                'DEDueDate.EditValue = Now
            End Try
        End If
    End Sub

    Private Sub LEpayment_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEpayment.EditValueChanged
        If LEpayment.EditValue = 1 Or LEpayment.EditValue = 4 Or LEpayment.EditValue = 5 Then
            TETOP.Enabled = True
        Else
            TETOP.Text = 0
            If id_wo <> "-1" Then
                'TEDueDate.Text = view_date_from(date_created, (Integer.Parse(TELeadTime.Text) + Integer.Parse(TETOP.Text)))
                DEDueDate.EditValue = date_created.AddDays(TELeadTime.EditValue + TETOP.EditValue)
            Else
                'TEDueDate.Text = view_date(Integer.Parse(TELeadTime.Text) + Integer.Parse(TETOP.Text))
                DEDueDate.EditValue = date_created.AddDays(TELeadTime.EditValue + TETOP.EditValue)
            End If
            TETOP.Enabled = False
        End If
    End Sub

    Private Sub FormSamplePurchaseDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub calculate()
        GVListPurchase.RefreshData()

        Dim total, sub_tot, gross_tot, vat As Decimal

        Try
            sub_tot = GVListPurchase.Columns("total_cost").SummaryItem.SummaryValue
            vat = (TEVat.EditValue / 100) * sub_tot
        Catch ex As Exception
        End Try

        TEVatTot.EditValue = vat

        gross_tot = sub_tot
        TEGrossTot.EditValue = gross_tot

        total = sub_tot + vat
        TETot.EditValue = total
        METotSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), LECurrency.EditValue.ToString)
    End Sub

    Private Sub TEVat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEVat.EditValueChanged
        calculate()
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_wo
        FormReportMark.report_mark_type = "23"
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub LESeason_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LESeason.EditValueChanged
        view_delivery(LESeason.EditValue, LEDelivery)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.id_report = id_wo
        FormDocumentUpload.report_mark_type = "23"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class