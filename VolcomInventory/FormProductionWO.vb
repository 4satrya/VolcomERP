Public Class FormProductionWO
    Public id_wo As String = "-1"
    Public id_ovh_price As String = "-1"
    Public id_po As String = "-1"
    Public id_prod_demand_design As String = "-1"
    Public id_comp_ship_to As String = "-1"
    'Public date_created As String = ""
    Public date_created As Date
    Public id_report_status_g As String = "1"
    Public id_wo_type As String = "-1"

    Private Sub FormProductionWO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_form()
    End Sub
    Sub load_form()
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

        If id_wo = "-1" Then
            'new
            'TEDate.Text = view_date(0)
            'TERecDate.Text = view_date(0)
            'TEDueDate.Text = view_date(0)

            TEWONumber.Text = header_number_prod("2")
            'view_list_purchase()
            'view PO
            load_po(id_po)
            '
            BPrint.Visible = False
            BtnAttachment.Visible = False
            '
        Else
            load_po(id_po)

            BPrint.Visible = True
            BtnAttachment.Visible = True

            Dim query = "SELECT a.id_report_status,h.report_status,a.id_prod_order_wo,a.id_ovh_price,a.id_payment, "
            query += "a.id_prod_order,g.payment,b.id_currency,a.prod_order_wo_note,a.prod_order_wo_kurs, "
            query += "d.comp_name AS comp_name_to, "
            query += "f.comp_name AS comp_name_ship_to,(SELECT id_own_company_contact FROM tb_opt) AS id_comp_contact_ship_to, "
            query += "a.prod_order_wo_number,a.id_ovh_price,j.overhead, "
            query += "a.prod_order_wo_del_date, "
            query += "DATE_FORMAT(a.prod_order_wo_date,'%Y-%m-%d') as prod_order_wo_datex,a.prod_order_wo_date,a.prod_order_wo_lead_time,a.prod_order_wo_top,a.prod_order_wo_vat, a.is_main_vendor "
            query += "FROM tb_prod_order_wo a INNER JOIN tb_m_ovh_price b ON a.id_ovh_price=b.id_ovh_price "
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
                Text = "F.G. Purchase Order"
            Else
                is_main_vendor = False
            End If

            CheckEditMainVendor.EditValue = is_main_vendor

            load_wo()
            TEVat.Text = data.Rows(0)("prod_order_wo_vat").ToString
            calculate()
        End If
        allow_status()
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

    Private Sub BSearchCompShipTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSearchCompShipTo.Click
        FormPopUpContact.id_pop_up = "24"

        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim id_currency, err_txt, query, ovh_type, wo_number, lead_time, top, payment_type, notex, vat, id_wo_new, del_date As String
        err_txt = "-1"
        Dim kurs As Decimal = 0.0
        Dim is_main_vendor As String = CheckEditMainVendor.EditValue.ToString

        If is_main_vendor = "True" Then
            is_main_vendor = "1"
        Else
            is_main_vendor = "2"
        End If

        ovh_type = id_wo_type
        payment_type = LEpayment.EditValue
        id_currency = LECurrency.EditValue

        kurs = TEKurs.EditValue
        wo_number = TEWONumber.Text
        lead_time = TELeadTime.Text
        top = TETOP.Text
        notex = MENote.Text
        vat = TEVat.EditValue

        Dim date_del As Date = TEDelDate.EditValue
        del_date = date_del.ToString("yyyy-MM-dd")

        ValidateChildren()

        If id_ovh_price = "" Or Not formIsValidInGroup(EPMatWO, GroupGeneralHeader) Or id_comp_ship_to = "-1" Then
            'error input
            stopCustom("Please make sure :" & vbNewLine & "- Work Order is not blank" & vbNewLine & "- Ship To is not blank" & vbNewLine & "- Work Order number is correct")
        Else
            If id_wo <> "-1" Then
                'edit
                Try
                    'reset main vendor
                    If is_main_vendor = "1" Then
                        query = "UPDATE tb_prod_order_wo SET is_main_vendor='2' WHERE id_prod_order='" + FormProductionDet.id_prod_order + "'"
                        execute_non_query(query, True, "", "", "", "")
                    End If
                    query = String.Format("UPDATE tb_prod_order_wo SET prod_order_wo_number='{0}',id_comp_contact_ship_to='{1}',id_payment='{2}',prod_order_wo_lead_time='{3}',prod_order_wo_top='{4}',prod_order_wo_note='{5}',prod_order_wo_vat='{6}',prod_order_wo_del_date='{7}',prod_order_wo_kurs='{9}',id_currency='{10}', is_main_vendor='{11}',id_ovh_price='{12}' WHERE id_prod_order_wo='{8}'", wo_number, id_comp_ship_to, payment_type, lead_time, top, notex, vat, del_date, id_wo, decimalSQL(kurs.ToString), id_currency, is_main_vendor, id_ovh_price)
                    execute_non_query(query, True, "", "", "", "")
                    '
                    'update mark
                    query = String.Format("UPDATE tb_report_mark SET info='{0}' WHERE id_report='{1}' AND report_mark_type='23'", FormProductionDet.LEPOType.Text, id_wo)
                    execute_non_query(query, True, "", "", "", "")
                    '
                    query = String.Format("DELETE FROM tb_prod_order_wo_det WHERE id_prod_order_wo='{0}'", id_wo)
                    execute_non_query(query, True, "", "", "", "")
                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        If Not GVListPurchase.GetRowCellValue(i, "id_prod_order_det").ToString = "" Then
                            'safe
                            query = String.Format("INSERT INTO tb_prod_order_wo_det(id_prod_order_wo,id_prod_order_det,prod_order_wo_det_price,prod_order_wo_det_qty,prod_order_wo_det_note) VALUES('{0}','{1}','{2}','{3}','{4}')", id_wo, GVListPurchase.GetRowCellValue(i, "id_prod_order_det").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "estimate_cost").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "prod_order_qty").ToString), GVListPurchase.GetRowCellValue(i, "note").ToString)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Next
                    '
                    query = "CALL update_trigger_PO_WO('" + id_wo + "')"
                    execute_non_query(query, True, "", "", "", "")
                    '
                    FormProductionDet.view_wo()
                    FormProductionDet.GVProdWO.FocusedRowHandle = find_row(FormProductionDet.GVProdWO, "id_prod_order_wo", id_wo)
                    '
                    infoCustom("WO updated")
                    load_form()
                Catch ex As Exception
                    errorConnection()
                End Try
            Else
                'new
                wo_number = header_number_prod(2)
                Try
                    'insert
                    'reset main vendor
                    If is_main_vendor = "1" Then
                        query = "UPDATE tb_prod_order_wo SET is_main_vendor='2' WHERE id_prod_order='" + FormProductionDet.id_prod_order + "'"
                        execute_non_query(query, True, "", "", "", "")
                    End If
                    '
                    query = String.Format("INSERT INTO tb_prod_order_wo(id_prod_order,id_ovh_price,prod_order_wo_number,id_comp_contact_ship_to,id_payment,prod_order_wo_date,prod_order_wo_lead_time,prod_order_wo_top,prod_order_wo_note,prod_order_wo_vat,prod_order_wo_del_date,prod_order_wo_kurs,id_currency,is_main_vendor) VALUES('{0}','{1}','{2}','{3}','{4}',DATE(NOW()),'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}'); SELECT LAST_INSERT_ID()", id_po, id_ovh_price, wo_number, id_comp_ship_to, payment_type, lead_time, top, notex, vat, del_date, decimalSQL(kurs.ToString), id_currency, is_main_vendor)
                    id_wo_new = execute_query(query, 0, True, "", "", "", "")
                    '
                    'insert_who_prepared("23", id_wo_new, id_user)

                    increase_inc_prod("2")
                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        If Not GVListPurchase.GetRowCellValue(i, "id_prod_order_det").ToString = "" Then
                            'safe
                            query = String.Format("INSERT INTO tb_prod_order_wo_det(id_prod_order_wo,id_prod_order_det,prod_order_wo_det_price,prod_order_wo_det_qty,prod_order_wo_det_note) VALUES('{0}','{1}','{2}','{3}','{4}')", id_wo_new, GVListPurchase.GetRowCellValue(i, "id_prod_order_det").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "estimate_cost").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "prod_order_qty").ToString), GVListPurchase.GetRowCellValue(i, "note").ToString)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Next
                    '
                    query = "CALL update_trigger_PO_WO('" + id_wo_new + "')"
                    execute_non_query(query, True, "", "", "", "")
                    '
                    FormProductionDet.view_wo()
                    FormProductionDet.GVProdWO.FocusedRowHandle = find_row(FormProductionDet.GVProdWO, "id_prod_order_wo", id_wo_new)
                    '
                    infoCustom("WO created")
                    id_wo = id_wo_new
                    load_form()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
    End Sub

    'Private Sub TEPONumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEWONumber.Validating
    'Dim query_jml As String
    '    query_jml = String.Format("SELECT COUNT(id_prod_order_wo) FROM tb_prod_order_wo WHERE prod_order_wo_number='{0}' AND id_prod_order_wo!='{1}'", TEWONumber.Text, id_wo)
    'Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
    'If Not jml < 1 Then
    '        EP_TE_already_used(EPMatWO, TEWONumber, "1")
    'Else
    '        EP_TE_cant_blank(EPMatWO, TEWONumber)
    'End If
    'End Sub

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
        If LEpayment.EditValue = 1 Or LEpayment.EditValue = 4 Or LEpayment.EditValue = 5 Or LEpayment.EditValue = 6 Or LEpayment.EditValue = 7 Then
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

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        ReportProductionWO.id_prod_wo = id_wo
        ReportProductionWO.id_po = id_po
        ReportProductionWO.is_po_print = "-1"

        If check_print_report_status(id_report_status_g) Then
            ReportProductionWO.is_pre = "-1"
        Else
            ReportProductionWO.is_pre = "1"
        End If

        If CheckEditMainVendor.Checked = True Then
            ReportProductionWO.is_main = "1"
        Else
            ReportProductionWO.is_main = "-1"
        End If

        Dim Report As New ReportProductionWO()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormReportMark.id_report = id_wo
        FormReportMark.report_mark_type = "23"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub
    Sub allow_status()
        If check_edit_report_status(id_report_status_g, "23", id_wo) Then
            BSave.Enabled = True
            BPickWO.Enabled = True
            '
            BSearchCompShipTo.Enabled = True
            BReviseWO.Visible = False
        Else
            BSave.Enabled = False
            BPickWO.Enabled = False
            '
            BSearchCompShipTo.Enabled = False
            BReviseWO.Visible = True
        End If

        'If check_print_report_status(id_report_status_g) Then
        '    BPrint.Enabled = True
        'Else
        '    BPrint.Enabled = False
        'End If
    End Sub

    Private Sub LESeason_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LESeason.EditValueChanged
        view_delivery(LESeason.EditValue, LEDelivery)
    End Sub

    Private Sub BPickWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickWO.Click
        FormPopUpProdOVH.id_prod_demand_design = get_prod_order_x(id_po, "1")
        FormPopUpProdOVH.ShowDialog()
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_wo
        FormDocumentUpload.report_mark_type = "23"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub DEEstRecDate_EditValueChanged(sender As Object, e As EventArgs) Handles DEEstRecDate.EditValueChanged
        If id_wo <> "-1" Then
            Try
                'TERecDate.Text = view_date_from(date_created, Integer.Parse(TELeadTime.Text))
                TELeadTime.EditValue = DateDiff(DateInterval.Day, date_created, DEEstRecDate.EditValue)
                'TETOP.EditValue = DateDiff(DateInterval.Day, DEEstRecDate.EditValue, DEDueDate.EditValue)
            Catch ex As Exception
                'TELeadTime.EditValue = 0
            End Try
        Else
            Try
                'TERecDate.Text = view_date(Integer.Parse(TELeadTime.Text))
                TELeadTime.EditValue = DateDiff(DateInterval.Day, date_created, DEEstRecDate.EditValue)
                'TETOP.EditValue = DateDiff(DateInterval.Day, DEEstRecDate.EditValue, DEDueDate.EditValue)
            Catch ex As Exception
                'TERecDate.Text = view_date(0)
                'TELeadTime.EditValue = 0
            End Try
        End If
    End Sub

    Private Sub DEDueDate_EditValueChanged(sender As Object, e As EventArgs) Handles DEDueDate.EditValueChanged
        If id_wo <> "-1" Then
            Try
                'TERecDate.Text = view_date_from(date_created, Integer.Parse(TELeadTime.Text))
                TETOP.EditValue = DateDiff(DateInterval.Day, DEEstRecDate.EditValue, DEDueDate.EditValue)
            Catch ex As Exception
            End Try
        Else
            Try
                'TERecDate.Text = view_date(Integer.Parse(TELeadTime.Text))
                TETOP.EditValue = DateDiff(DateInterval.Day, DEEstRecDate.EditValue, DEDueDate.EditValue)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BReviseWO_Click(sender As Object, e As EventArgs) Handles BReviseWO.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Revise WO will remove all mark in this document, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query As String = ""
            query = "DELETE FROM tb_report_mark WHERE id_report='" & id_wo & "' AND report_mark_type='23'"
            execute_non_query(query, True, "", "", "", "")
            query = "UPDATE tb_prod_order_wo SET id_report_status='1' WHERE id_prod_order_wo='" & id_wo & "'"
            execute_non_query(query, True, "", "", "", "")
        End If
        load_form()
        '
        infoCustom("WO revised, please attach document related to this revision")
        '
        FormDocumentUpload.id_report = id_wo
        FormDocumentUpload.report_mark_type = "23"
        FormDocumentUpload.ShowDialog()
    End Sub
End Class