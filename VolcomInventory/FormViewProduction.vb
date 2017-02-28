Public Class FormViewProduction
    Public id_prod_order As String = "-1"
    Public id_prod_demand As String = "-1"
    Public id_prod_demand_design As String = "-1"
    Public id_delivery As String = "-1"

    Private Sub FormViewProduction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_term_production(LECategory)
        view_po_type(LEPOType)
        If id_prod_order = "-1" Then
            'new
            TEPONumber.Text = header_number_prod("1")
            TEDate.Text = view_date(0)
            TETolerance.EditValue = 0
        Else
            'edit
            Dim query As String = String.Format("SELECT *,DATE_FORMAT(prod_order_date,'%Y-%m-%d') as prod_order_datex FROM tb_prod_order WHERE id_prod_order = '{0}'", id_prod_order)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TEPONumber.Text = data.Rows(0)("prod_order_number").ToString

            LEPOType.EditValue = data.Rows(0)("id_po_type").ToString()
            LECategory.EditValue = data.Rows(0)("id_term_production").ToString()
            '
            TETolerance.EditValue = data.Rows(0)("tolerance")
            '
            TEDate.Text = view_date_from(data.Rows(0)("prod_order_datex").ToString(), 0)
            '
            id_prod_demand_design = data.Rows(0)("id_prod_demand_design").ToString()
            id_prod_demand = get_prod_demand_design_x(id_prod_demand_design, "1")
            id_delivery = get_prod_demand_design_x(id_prod_demand_design, "2")
            '
            TEPDNo.Text = get_prod_demand_x(id_prod_demand, "1")
            TEDesign.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "1")
            TEDesignCode.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "2")
            TESeason.Text = get_season_x(get_id_season(id_delivery), "1")
            TERange.Text = get_range_x(get_id_range(get_id_season(id_delivery)), "1")
            TEDelivery.Text = get_delivery_x(id_delivery, "1")
            TEUSCOde.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "3")
            '
            view_list_purchase()
            view_bom()
        End If
    End Sub

    Sub view_bom()
        Try
            If id_prod_demand_design = "" Then
                id_prod_demand_design = "-1"
            End If
            Dim query As String
            query = "CALL view_bom_design_list(" & id_prod_demand_design & ",1)"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBOM.DataSource = data
            GVBOM.ActiveFilterString = "[is_cost] = 1"
            GVBOM.ExpandAllGroups()
            If GVBOM.RowCount > 0 Then
                METotSay.Text = ConvertCurrencyToEnglish(GVBOM.Columns("total").SummaryItem.SummaryValue.ToString, get_setup_field("id_currency_default"))
                TEUnitCost.EditValue = GVBOM.Columns("total").SummaryItem.SummaryValue
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub GVBOM_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBOM.CustomColumnDisplayText
        If e.Column.FieldName = "id_component_category" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVBOM.IsGroupRow(rowhandle) Then
                rowhandle = GVBOM.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVBOM.GetRowCellDisplayText(rowhandle, "category")
            End If
        End If
    End Sub

    Sub view_list_purchase()
        Dim query = "CALL view_prod_order_det('" & id_prod_order & "','1')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProduct.DataSource = data
        If data.Rows.Count < 1 Then
            METotSay.Text = ""
        Else
            METotSay.Text = ConvertCurrencyToEnglish(GVListProduct.Columns("total_cost").SummaryText.ToString, "1")
        End If
    End Sub

    Private Sub BPickPD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormPopUpPD.id_pop_up = "1"
        FormPopUpPD.ShowDialog()
    End Sub

    Private Sub BPickDesign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormPopUpPDDesign.id_pop_up = "1"
        FormPopUpPDDesign.id_prod_demand = id_prod_demand
        FormPopUpPDDesign.ShowDialog()
    End Sub

    Sub view_term_production(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_term_production,term_production FROM tb_lookup_term_production ORDER BY id_term_production DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "term_production"
        lookup.Properties.ValueMember = "id_term_production"
        lookup.EditValue = data.Rows(0)("id_term_production").ToString
    End Sub

    Sub view_po_type(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_po_type,po_type FROM tb_lookup_po_type ORDER BY id_po_type DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "po_type"
        lookup.Properties.ValueMember = "id_po_type"
        lookup.EditValue = data.Rows(0)("id_po_type").ToString
    End Sub

    Sub view_prod_demand_product()
        Dim query As String = "CALL view_prod_demand_product('" + id_prod_demand_design + "',1)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProduct.DataSource = data
        If data.Rows.Count < 1 Then
            METotSay.Text = ""
        Else
            METotSay.Text = ConvertCurrencyToEnglish(GVListProduct.Columns("total_cost").SummaryText.ToString, "1")
        End If
    End Sub

    Private Sub GVListProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProduct.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_prod_order
        FormReportMark.report_mark_type = "22"
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.id_report = id_prod_order
        FormDocumentUpload.report_mark_type = "22"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class