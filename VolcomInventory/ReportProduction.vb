Public Class ReportProduction
    Public Shared id_prod_order As String = "-1"
    Public Shared sign_col As String = "-1"
    Public Shared id_cur As String = "-1"
    Public Shared is_pre As String = "-1"
    Sub view_mat_purchase()
        Dim query = "CALL view_prod_order_det('" & id_prod_order & "','1')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProduct.DataSource = data
    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        view_mat_purchase()
    End Sub

    Private Sub TopMargin_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles TopMargin.BeforePrint
        Dim query As String = String.Format("SELECT *,DATE_FORMAT(prod_order_date,'%Y-%m-%d') as prod_order_datex FROM tb_prod_order WHERE id_prod_order = '{0}'", id_prod_order)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        LPONumber.Text = data.Rows(0)("prod_order_number").ToString

        LPODate.Text = view_date_from(data.Rows(0)("prod_order_datex").ToString(), 0)

        Dim id_prod_demand As String = "-1"
        Dim id_prod_demand_design As String = "-1"
        Dim id_delivery As String = "-1"

        id_prod_demand_design = data.Rows(0)("id_prod_demand_design").ToString()
        id_prod_demand = get_prod_demand_design_x(id_prod_demand_design, "1")
        id_delivery = get_prod_demand_design_x(id_prod_demand_design, "2")
        '
        LPDNo.Text = get_prod_demand_x(id_prod_demand, "1")
        LDesign.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "1")
        LDesignCode.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "2")
        LSeason.Text = get_season_x(get_id_season(id_delivery), "1")
        LRange.Text = get_range_x(get_id_range(get_id_season(id_delivery)), "1")
        LDelivery.Text = get_delivery_x(id_delivery, "1")
        LDesignUSCode.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "3")
        LPDOType.Text = get_potype_x(data.Rows(0)("id_po_type").ToString, "1")
        LTerm.Text = get_term_production_x(data.Rows(0)("id_term_production").ToString)
        LCur.Text = get_currency(get_setup_field("id_currency_default"))
        LNote.Text = data.Rows(0)("prod_order_note").ToString
        '
        'printed date & approved date
        Dim qpd As String = "SELECT DATE_FORMAT(NOW(), '%d/%M/%Y %H:%i') AS `printed_date` "
        Dim dpd As DataTable = execute_query(qpd, -1, True, "", "", "", "")
        DataSource = dpd
    End Sub

    Private Sub ReportMatPurchase_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        If is_pre = "1" Then

            pre_load_mark_horz("22", id_prod_order, "2", "2", XrTable1)
        Else
            load_mark_horz("22", id_prod_order, "2", "1", XrTable1)
        End If
    End Sub

    Private Sub PageFooter_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint
        If GVListProduct.RowCount > 0 Then
            Dim sub_tot, qty, unit_cost As Decimal
            Try
                qty = Decimal.Parse(GVListProduct.Columns("prod_order_qty").SummaryText.ToString)
                sub_tot = Decimal.Parse(GVListProduct.Columns("total_cost").SummaryText.ToString)
                unit_cost = sub_tot / qty
            Catch ex As Exception
            End Try

            LQty.Text = qty.ToString("N2")
            LTot.Text = sub_tot.ToString("N2")
            LUnitCost.Text = unit_cost.ToString("N2")

            LSay.Text = ConvertCurrencyToEnglish(GVListProduct.Columns("total_cost").SummaryText.ToString, get_setup_field("id_currency_default"))
        End If
    End Sub

    Private Sub GVListProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProduct.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class