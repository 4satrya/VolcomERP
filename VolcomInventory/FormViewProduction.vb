Public Class FormViewProduction
    Public id_prod_order As String = "-1"
    Public id_prod_demand As String = "-1"
    Public id_prod_demand_design As String = "-1"
    Public id_delivery As String = "-1"

    Private Sub FormViewProduction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '
        RCIMainVendorWO.ValueChecked = Convert.ToSByte(1)
        RCIMainVendorWO.ValueUnchecked = Convert.ToSByte(2)
        '
        view_term_production(LECategory)
        view_po_type(LEPOType)
        '
        view_currency(RICECurrency)

        If id_prod_order = "-1" Then
            'new
            TEPONumber.Text = header_number_prod("1")
            TEDate.Text = view_date(0)
            TETolerance.EditValue = 0
        Else
            'edit
            Dim query As String = String.Format("SELECT po.*,DATE_FORMAT(po.prod_order_date,'%Y-%m-%d') AS prod_order_datex,comp.`comp_name`,comp.`comp_number` FROM tb_prod_order po
LEFT JOIN tb_prod_order_wo wo ON wo.`id_prod_order`=po.`id_prod_order` AND wo.`is_main_vendor`='1'
LEFT JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price`
LEFT JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ovhp.`id_comp_contact`
LEFT JOIN tb_m_comp comp ON comp.`id_comp`=cc.`id_comp` WHERE po.id_prod_order = '{0}'", id_prod_order)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TEPONumber.Text = data.Rows(0)("prod_order_number").ToString
            TEVendorName.Text = data.Rows(0)("comp_number").ToString & " - " & data.Rows(0)("comp_name").ToString

            LEPOType.EditValue = data.Rows(0)("id_po_type").ToString()
            LECategory.EditValue = data.Rows(0)("id_term_production").ToString()
            '
            TETolerance.EditValue = data.Rows(0)("tolerance")
            '
            TEDate.Text = view_date_from(data.Rows(0)("prod_order_datex").ToString(), 0)
            MENote.Text = data.Rows(0)("prod_order_note").ToString
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
            view_wo()
        End If
    End Sub
    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.DataSource = data

        lookup.DisplayMember = "currency"
        lookup.ValueMember = "id_currency"
    End Sub
    Sub view_wo()
        'list overhead
        Dim query_wo_list = "SELECT wo.id_prod_order_wo,wo.id_report_status,h.report_status,wo.id_ovh_price,wo.id_payment,
                            g.payment,wo.is_main_vendor, 
                            d.comp_name AS comp_name_to, 
                            f.comp_name AS comp_name_ship_to, 
                            wo.prod_order_wo_number,
                            wo.id_ovh_price,
                            j.overhead,
                            wo.prod_order_wo_date,
                            wo.prod_order_wo_lead_time,
                            wo.`prod_order_wo_top`,wo.prod_order_wo_vat,
                            cur.`currency`,cur.`id_currency`,
                            wo.prod_order_wo_del_date,
                            wod.qty,
                            wod.price,wo.prod_order_wo_kurs
                            FROM tb_prod_order_wo wo 
                            LEFT JOIN 
                            (
	                            SELECT id_prod_order_wo,prod_order_wo_det_price AS price,SUM(prod_order_wo_det_qty) AS qty FROM tb_prod_order_wo_det
	                            GROUP BY id_prod_order_wo
                            ) AS wod ON wod.id_prod_order_wo=wo.`id_prod_order_wo`
                            INNER JOIN tb_m_ovh_price b ON wo.id_ovh_price=b.id_ovh_price 
                            INNER JOIN tb_m_comp_contact c ON b.id_comp_contact = c.id_comp_contact 
                            INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
                            INNER JOIN tb_m_comp_contact e ON wo.id_comp_contact_ship_to = e.id_comp_contact
                            INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp
                            INNER JOIN tb_lookup_payment g ON wo.id_payment = g.id_payment 
                            INNER JOIN tb_lookup_report_status h ON h.id_report_status = wo.id_report_status 
                            INNER JOIN tb_lookup_currency cur ON cur.`id_currency`=wo.`id_currency`
                            INNER JOIN tb_m_ovh j ON b.id_ovh = j.id_ovh
                            WHERE id_prod_order='" & id_prod_order & "'"
        Dim data_wo As DataTable = execute_query(query_wo_list, -1, True, "", "", "", "")
        GCWO.DataSource = data_wo
        GVWO.BestFitColumns()
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
                TEUnitCost.EditValue = GVBOM.Columns("total").SummaryItem.SummaryValue / GVListProduct.Columns("prod_order_qty").SummaryItem.SummaryValue
            End If
            'search note
            If GVBOM.RowCount > 0 Then
                MEBOMNote.Text = GVBOM.GetRowCellValue(0, "bom_note").ToString
            End If
            '
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

    Private Sub TEPDNo_Click(sender As Object, e As EventArgs) Handles TEPDNo.Click
        Cursor = Cursors.WaitCursor
        Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
        showpopup.report_mark_type = "9"
        showpopup.double_click(addSlashes(TEPDNo.Text.ToString))
        showpopup.show()
        Cursor = Cursors.Default
    End Sub
End Class