Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportProductionWO
    Public Shared id_prod_wo As String = "-1"
    Public Shared sign_col As String = "-1"
    Public Shared id_cur As String = "-1"
    Public Shared id_po As String = "-1"
    Public Shared is_pre As String = "-1"
    '
    Public Shared is_main As String = "-1"
    Public Shared is_po_print As String = "-1"

    Dim id_ovh_price As String = "-1"

    Sub view_wo()
        Dim query = "CALL view_prod_order_wo_det('" & id_prod_wo & "','1')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data

        calculate()
    End Sub

    Sub calculate()
        Dim total, sub_tot, gross_tot, vat, discount As Decimal

        Try
            sub_tot = Decimal.Parse(GVListPurchase.Columns("id_prod_order_det").SummaryText.ToString)
            vat = (Decimal.Parse(LVat.Text) / 100) * Decimal.Parse(GVListPurchase.Columns("id_prod_order_det").SummaryText.ToString)
        Catch ex As Exception
        End Try

        LVatTot.Text = vat.ToString("N2")

        gross_tot = sub_tot + discount
        LGrossTot.Text = gross_tot.ToString("N2")

        total = sub_tot + vat
        LTot.Text = total.ToString("N2")
        LSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), id_cur)
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint

    End Sub

    Private Sub TopMargin_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles TopMargin.BeforePrint

    End Sub

    Sub view_top()
        Dim query = "SELECT dsg.design_code_import,po.`id_po_type`,pd.prod_demand_number,a.id_report_status,h.report_status,a.id_prod_order,a.id_prod_order_wo,a.id_ovh_price,a.id_payment, 
g.payment,a.id_currency,a.prod_order_wo_kurs,a.prod_order_wo_note, b.id_comp_contact, (SELECT id_own_company_contact FROM tb_opt) AS id_comp_contact_ship_to,
a.prod_order_wo_number,a.id_ovh_price,j.overhead,
DATE_FORMAT(a.prod_order_wo_date,'%Y-%m-%d') AS prod_order_wo_datex,a.prod_order_wo_lead_time,a.prod_order_wo_top,a.prod_order_wo_vat 
,dsg.design_code_import
,po_type.`po_type`,po.prod_order_number,po.prod_order_note 
FROM tb_prod_order_wo a INNER JOIN tb_m_ovh_price b ON a.id_ovh_price=b.id_ovh_price 
INNER JOIN tb_m_comp_contact c ON b.id_comp_contact = c.id_comp_contact 
INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact 
INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp 
INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment 
INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status 
INNER JOIN tb_m_ovh j ON b.id_ovh = j.id_ovh 
INNER JOIN tb_prod_order po ON po.`id_prod_order`=a.`id_prod_order`
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
INNER JOIN tb_prod_demand pd ON pd.`id_prod_demand`=pdd.`id_prod_demand`
INNER JOIN `tb_lookup_po_type` po_type ON po_type.`id_po_type`=po.`id_po_type`
WHERE a.id_prod_order_wo='" & id_prod_wo & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        load_po(id_po)

        If is_main = "1" Then
            LTitle.Text = "F.G. PURCHASE ORDER"
            LWONumber.Text = data.Rows(0)("prod_order_number").ToString
            LNote.Text = data.Rows(0)("prod_order_note").ToString
            If data.Rows(0)("id_po_type") = "2" Then 'international
                LUSCodeTitle.Visible = True
                LUSCodeDot.Visible = True
                LUSCode.Visible = True
                LUSCode.Text = data.Rows(0)("design_code_import").ToString
            Else
                LUSCodeTitle.Visible = False
                LUSCodeDot.Visible = False
                LUSCode.Visible = False
            End If
        Else
            LTitle.Text = "WORK ORDER"
            LWONumber.Text = data.Rows(0)("prod_order_wo_number").ToString
            LNote.Text = data.Rows(0)("prod_order_wo_note").ToString
            '
            If data.Rows(0)("id_po_type") = "2" Then 'international
                LUSCodeTitle.Visible = True
                LUSCodeDot.Visible = True
                LUSCode.Visible = True
                LUSCode.Text = data.Rows(0)("design_code_import").ToString
            Else
                LUSCodeTitle.Visible = False
                LUSCodeDot.Visible = False
                LUSCode.Visible = False
            End If
        End If

        DisplayName = "Production Work Order " & data.Rows(0)("prod_order_wo_number").ToString

        Dim kurs As Decimal = data.Rows(0)("prod_order_wo_kurs")
        LKurs.Text = kurs.ToString("N2")

        Dim curr As String = get_currency(data.Rows(0)("id_currency").ToString)

        LCur_1.Text = curr
        LCur_2.Text = curr
        LCur_3.Text = curr

        Dim date_created As String = data.Rows(0)("prod_order_wo_datex").ToString
        LPODate.Text = view_date_from(date_created, 0)
        LLeadTime.Text = data.Rows(0)("prod_order_wo_lead_time").ToString
        LRecDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("prod_order_wo_lead_time").ToString))
        LTOP.Text = data.Rows(0)("prod_order_wo_top").ToString
        LDueDate.Text = view_date_from(date_created, (Integer.Parse(data.Rows(0)("prod_order_wo_lead_time").ToString) + Integer.Parse(data.Rows(0)("prod_order_wo_top").ToString)))
        LVat.Text = data.Rows(0)("prod_order_wo_vat").ToString
        LPayment.Text = get_payment(data.Rows(0)("id_payment").ToString)
        id_ovh_price = data.Rows(0)("id_ovh_price").ToString
        LPDNo.Text = data.Rows(0)("prod_demand_number").ToString

        Dim id_comp_ship_to As String = "-1"

        id_comp_ship_to = data.Rows(0)("id_comp_contact_ship_to").ToString
        LShipToName.Text = get_company_x(get_id_company(id_comp_ship_to), "1")
        LShipToAddress.Text = get_company_x(get_id_company(id_comp_ship_to), "3")


        LWOType.Text = data.Rows(0)("overhead").ToString

        LPOType.Text = data.Rows(0)("po_type").ToString

        LToName.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact").ToString), "1")
        LToAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact").ToString), "3")
        LToAttn.Text = get_company_contact_x(data.Rows(0)("id_comp_contact").ToString, "1")
        id_cur = data.Rows(0)("id_currency").ToString
        '
    End Sub

    Sub load_po(ByVal id_po As String)
        Dim query As String = String.Format("SELECT *,DATE_FORMAT(prod_order_date,'%Y-%m-%d') as prod_order_datex FROM tb_prod_order WHERE id_prod_order = '{0}'", id_po)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim id_prod_demand_design As String = "-1"

        id_prod_demand_design = data.Rows(0)("id_prod_demand_design").ToString
        LDesignName.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "1")
        LSeason.Text = get_season_x(get_id_season(get_prod_demand_design_x(id_prod_demand_design, "2")), "1")
        LDelivery.Text = get_delivery_x(get_prod_demand_design_x(id_prod_demand_design, "2"), "1")
        LRange.Text = get_range_x(get_id_range(get_id_season(get_prod_demand_design_x(id_prod_demand_design, "2"))), "1")
        LPONo.Text = data.Rows(0)("prod_order_number").ToString
        LDesignCode.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "2")
    End Sub

    Private Sub ReportMatWO_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        If is_po_print = "1" Then
            Dim query As String = "SELECT id_prod_order_wo FROM tb_prod_order_wo WHERE id_prod_order='" & id_po & "' AND is_main_vendor=1 AND id_report_status!=5"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_prod_wo = data.Rows(0)("id_prod_order_wo")
            is_main = "1"
        End If

        view_wo()
        view_top()

        If is_pre = "1" Then
            pre_load_mark_horz("22", id_po, LToName.Text, "2", XrTable1)
        Else
            load_mark_horz("22", id_po, LToName.Text, "2", XrTable1)
        End If
    End Sub

    Private Sub PageFooter_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint
        calculate()
    End Sub
End Class