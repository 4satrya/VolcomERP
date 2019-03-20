Imports System.Globalization

Public Class FormProdDemandDesignSingle
    Public action As String
    Public id_prod_demand_design As String
    Dim id_prod_demand As String = "-1"
    Dim id_season As String = "-1"
    Dim id_design, id_sample As String
    Dim id_design_initial As String
    Dim royalty, royalty_cost As Decimal
    Dim estimate_cost As Decimal
    Dim first_load As Boolean = False
    Dim ALT_F4 As Boolean = True
    Dim curr_date As Date
    Public form_name As String = "-1"
    Dim id_currency As String = "-1"
    Public data_edit As New DataTable
    Dim allc_cond As String = ""
    Dim id_role_super_admin As String = get_setup_field("id_role_super_admin")
    Public data_column As New DataTable


    'Form Load
    Private Sub FormProdDemandDesignSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If form_name = "-1" Then
            id_season = FormProdDemandSingle.id_season
        ElseIf form_name = "FormMasterDesignSingle" Then
            id_season = FormFGLineList.SLESeason.EditValue.ToString
            If FormMasterDesignSingle.bool_qty_line = True Then
                PCMenu.Visible = True
            Else
                PCMenu.Visible = False
            End If

            'initialisation datatable edit
            Try
                data_edit.Columns.Add("id_prod_demand_product")
                data_edit.Columns.Add("pd_alloc")
                data_edit.Columns.Add("qty")
            Catch ex As Exception
            End Try

            'custom column template inisialisasi
            'initialisation datatable edit
            Try
                data_column.Columns.Add("options_view_det_band")
                data_column.Columns.Add("options_view_det_caption")
                data_column.Columns.Add("options_view_det_column")
                data_column.Columns.Add("options_view_det_visible")
            Catch ex As Exception
            End Try

            'get allocation
            Dim query_alloc As String = "SELECT * FROM tb_lookup_pd_alloc"
            Dim data_alloc As DataTable = execute_query(query_alloc, -1, True, "", "", "", "")
            For d As Integer = 0 To data_alloc.Rows.Count - 1
                If d > 0 Then
                    allc_cond += " + "
                End If
                allc_cond += "[" + data_alloc.Rows(d)("pd_alloc").ToString + "]"
            Next
        End If
        viewDelivery()
        actionLoad()
    End Sub

    'Action Load
    Sub actionLoad()
        'updated 16 december 2014
        TxtRate.EditValue = 0.0
        TxtRateManagement.EditValue = 0.0
        TxtMSRP.EditValue = 0.0
        TxtMSRPRp.EditValue = 0.0

        TxtProposePrice.EditValue = 0.0
        TxtRoyaltyDesign.EditValue = 0.0
        TxtRoyaltySpecial.EditValue = 0.0
        TxtEstimateCost.EditValue = 0.0
        TxtTotalCost.EditValue = 0.0
        TxtInflasi.EditValue = 0.0
        TxtMarkup.EditValue = 0.0

        If action = "upd" Then
            'Read Only Nonactive
            SLEDesign.Enabled = False
            TxtRoyaltyDesign.Properties.ReadOnly = False
            TxtRoyaltySpecial.Properties.ReadOnly = False
            TxtProposePrice.Properties.ReadOnly = False
            DEStart.Properties.ReadOnly = False
            TxtInflasi.Properties.ReadOnly = False
            TxtMarkup.Properties.ReadOnly = True
            TxtEstimateCost.Properties.ReadOnly = True
            TxtTotalCost.Properties.ReadOnly = True
            TxtCostNonAdditional.Properties.ReadOnly = True
            TxtAdditionalCost.Properties.ReadOnly = True
            TxtAdditionalPrice.Properties.ReadOnly = True
            TxtPriceNonAdditional.Properties.ReadOnly = True
            TxtMSRPRp.Properties.ReadOnly = True
            TxtRateManagement.Properties.ReadOnly = True

            'prevent close without save
            BtnCancel.Visible = False


            'parse data
            Dim query As String = "SELECT *, (a.prod_demand_design_total_cost-a.additional_cost) AS `cost_non_additional`, (a.prod_demand_design_propose_price-a.additional_price) AS `price_non_additional`, (COALESCE(a.royalty_design,0)) AS roy_design, (COALESCE(a.royalty_special,0)) AS roy_spec, c.currency "
            query += "FROM tb_prod_demand_design a "
            query += "INNER JOIN tb_m_design b ON a.id_design = b.id_design "
            query += "LEFT JOIN tb_lookup_currency c ON a.id_currency = c.id_currency "
            query += "WHERE a.id_prod_demand_design = '" + id_prod_demand_design + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_prod_demand_design = data.Rows(0)("id_prod_demand_design").ToString
            id_design = data.Rows(0)("id_design").ToString
            viewDesign() 'view design
            SLEDesign.EditValue = id_design
            id_design_initial = data.Rows(0)("id_design").ToString
            LEDelivery.ItemIndex = LEDelivery.Properties.GetDataSourceRowIndex("id_delivery", data.Rows(0)("id_delivery").ToString)
            TxtProposePrice.EditValue = data.Rows(0)("prod_demand_design_propose_price")
            TxtRoyaltyDesign.EditValue = data.Rows(0)("roy_design")
            TxtRoyaltySpecial.EditValue = data.Rows(0)("roy_spec")
            TxtEstimateCost.EditValue = data.Rows(0)("prod_demand_design_estimate_price")
            TxtInflasi.EditValue = data.Rows(0)("inflation")
            id_sample = data.Rows(0)("id_sample").ToString
            id_prod_demand = data.Rows(0)("id_prod_demand").ToString

            'updated 10 desember 2014
            TxtTotalCost.EditValue = data.Rows(0)("prod_demand_design_total_cost")
            DEStart.EditValue = data.Rows(0)("date_available_start")

            'updated 16 december 2014
            TxtRate.EditValue = data.Rows(0)("rate_current")
            TxtRateManagement.EditValue = data.Rows(0)("rate_management")
            TxtCurr.Text = data.Rows(0)("currency").ToString
            id_currency = data.Rows(0)("id_currency").ToString
            TxtMSRP.EditValue = data.Rows(0)("msrp")
            TxtMSRPRp.EditValue = data.Rows(0)("msrp_rp")

            'updated 17 mei 2018
            TxtAdditionalCost.EditValue = data.Rows(0)("additional_cost")
            TxtAdditionalPrice.EditValue = data.Rows(0)("additional_price")
            TxtCostNonAdditional.EditValue = data.Rows(0)("cost_non_additional")
            TxtPriceNonAdditional.EditValue = data.Rows(0)("price_non_additional")

            'image
            pre_viewImages("2", PictureEdit1, id_design, False)

            GroupControlBreakDown.Enabled = True
            GroupControlAllocation.Enabled = True
            BtnEstimate.Enabled = True
            BtnSave.Text = "Save Changes"

            ''fill into form (price & markup)
            viewBreakdown()
            getMarkUp()
            'TxtProposePrice.EditValue = data.Rows(0)("prod_demand_design_propose_price")

            If form_name = "-1" Then
                GroupControlDesign.Visible = True
                GroupControlMSRP.Visible = True
            ElseIf form_name = "FormMasterDesignSingle" Then
                GroupControlDesign.Visible = False
                GroupControlMSRP.Visible = False
                BtnAdd.Visible = False
                BtnDelete.Visible = False
                'TxtRate.Enabled = False
                If FormFGLineList.SLETypeLineList.EditValue.ToString = "3" Then
                    BtnProposePrice.Visible = True
                    BtnEstimate.Visible = True
                    BtnCheckPrice.Visible = False
                Else
                    BtnProposePrice.Visible = False
                    BtnEstimate.Visible = False
                    BtnCheckPrice.Visible = True
                End If
            End If

            'log cost
            logCost()
        ElseIf action = "ins" Then
            id_design = 0
            viewDesign()
            TxtRoyaltyDesign.Properties.ReadOnly = True
            TxtRoyaltySpecial.Properties.ReadOnly = True
            TxtProposePrice.Properties.ReadOnly = True
            DEStart.Properties.ReadOnly = True
            TxtInflasi.Properties.ReadOnly = True
            TxtMarkup.Properties.ReadOnly = True
            TxtEstimateCost.Properties.ReadOnly = True
            TxtTotalCost.Properties.ReadOnly = True
            BtnCheckPrice.Enabled = False
            BtnEstimate.Enabled = False
            TxtRate.Properties.ReadOnly = True
            TxtCurr.Properties.ReadOnly = True
            TxtMSRP.Properties.ReadOnly = True

            'default date price start, end - updated 10 desember 2014
            curr_date = Date.Parse(execute_query("SELECT NOW()", 0, True, "", "", "", ""))
            DEStart.EditValue = curr_date
        End If
    End Sub

    Sub logCost()
        Dim query As String = "SELECT bom.id_bom, bom.bom_name, term.term_production,(bom.bom_unit_price*bom.kurs) AS `prod_demand_log_cost`, IFNULL(emp.employee_name, '-') AS `employee_name`, "
        query += "(bom.bom_date_updated) AS `prod_demand_log_cost_time`, (bom.kurs) AS `prod_demand_log_cost_rate`, "
        query += "curr.currency, IF(bom.is_default='1', 'Yes', 'No') AS `is_default` "
        query += "FROM tb_bom bom  "
        query += "INNER JOIN tb_m_product prod ON prod.id_product = bom.id_product "
        query += "INNER Join tb_lookup_term_production term ON term.id_term_production = bom.id_term_production "
        query += "LEFT JOIN tb_m_user us ON us.id_user = bom.id_user_last_update  "
        query += "LEFT JOIN tb_m_employee emp ON emp.id_employee = us.id_employee "
        query += "LEFT JOIN tb_lookup_currency curr ON curr.id_currency = bom.id_currency "
        query += "WHERE prod.id_design='" + id_design + "' "
        query += "GROUP BY bom.id_bom_approve "
        query += "ORDER BY bom_date_updated DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'Dim query_c As ClassDesign = New ClassDesign()
        'Dim query As String = query_c.getCostHistQuery(id_design)
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCLogCost.DataSource = data
        GVLogCost.BestFitColumns()
    End Sub

    'Get Royalty
    Sub getRoyalty()
        Dim royalty1 As Decimal = 0.0
        Dim royalty2 As Decimal = 0.0

        Try
            royalty1 = Decimal.Parse(TxtRoyaltyDesign.EditValue)
        Catch ex As Exception
        End Try

        Try
            royalty2 = Decimal.Parse(TxtRoyaltySpecial.EditValue)
        Catch ex As Exception
        End Try
        royalty = (royalty1 / 100) + (royalty2 / 100)
    End Sub

    'View Breakdown
    Sub viewBreakdown()
        getRoyalty()
        PBC.EditValue = 0
        GCProductRev.DataSource = Nothing
        GCProductRev.RepositoryItems.Clear()
        GCProductRev.RefreshDataSource()
        GVProductRev.ApplyFindFilter("")
        GVProductRev.ColumnPanelRowHeight = 50
        GVProductRev.Columns.Clear()
        GVProductRev.GroupSummary.Clear()
        GVProductRev.OptionsBehavior.AutoExpandAllGroups = True

        Dim query_rev As String = "CALL view_product_demand_all_rev('" + id_prod_demand_design + "') "
        Dim data_rev As DataTable = execute_query(query_rev, -1, True, "", "", "", "")
        GCProductRev.DataSource = data_rev
        If data_rev.Rows.Count < 1 Then
            'form
            TxtRoyaltyDesign.Properties.ReadOnly = True
            TxtRoyaltySpecial.Properties.ReadOnly = True
            TxtProposePrice.Properties.ReadOnly = False
            DEStart.Properties.ReadOnly = True
            TxtMarkup.Properties.ReadOnly = True
            TxtEstimateCost.Properties.ReadOnly = True
            TxtTotalCost.Properties.ReadOnly = True
            TxtInflasi.Properties.ReadOnly = True
            BtnCheckPrice.Enabled = True
            BtnEstimate.Enabled = False
            BtnSave.Enabled = True

            'button
            BtnEdit.Visible = False
            BtnDelete.Visible = False
            BViewBOM.Visible = False
            'BtnAdd.Enabled = False

            TxtRate.Properties.ReadOnly = True
            TxtCurr.Properties.ReadOnly = True
            TxtMSRP.Properties.ReadOnly = False
        Else
            'form
            TxtRoyaltyDesign.Properties.ReadOnly = False
            TxtRoyaltySpecial.Properties.ReadOnly = False
            TxtProposePrice.Properties.ReadOnly = False
            DEStart.Properties.ReadOnly = False
            BtnCheckPrice.Enabled = True
            BtnEstimate.Enabled = True
            BtnSave.Enabled = True
            TxtMarkup.Properties.ReadOnly = True
            TxtEstimateCost.Properties.ReadOnly = True
            TxtTotalCost.Properties.ReadOnly = True
            TxtInflasi.Properties.ReadOnly = False


            'button
            BtnEdit.Visible = True
            If form_name = "-1" Then
                BtnDelete.Visible = True
            End If
            BViewBOM.Visible = True

            TxtRate.Properties.ReadOnly = True
            TxtCurr.Properties.ReadOnly = True
            TxtMSRP.Properties.ReadOnly = False

            '**HIDE**
            GVProductRev.Columns("id_bom").Visible = False
            GVProductRev.Columns("id_prod_demand_product").Visible = False
            GVProductRev.Columns("id_design").Visible = False
            GVProductRev.Columns("id_product").Visible = False
            GVProductRev.Columns("id_currency").Visible = False
            GVProductRev.Columns("Currency").Visible = False
            GVProductRev.Columns("Kurs").Visible = False
            GVProductRev.Columns("Cost").Visible = False


            '**REPO SPIN EDIT**
            Dim riTE As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
            riTE.IsFloatValue = False
            riTE.MaxLength = 0
            riTE.MinValue = 0
            riTE.MaxValue = 999999999
            riTE.Buttons.Clear()
            GCProductRev.RepositoryItems.Add(riTE)

            '**LOOP COLOM**
            For j As Integer = 0 To GVProductRev.Columns.Count - 1
                Dim col As String = GVProductRev.Columns(j).FieldName.ToString
                GVProductRev.Columns(GVProductRev.Columns(j).FieldName.ToString).AppearanceHeader.Font = New Font(GVProductRev.Appearance.Row.Font.FontFamily, GVProductRev.Appearance.Row.Font.Size, FontStyle.Bold)
                GVProductRev.Columns(GVProductRev.Columns(j).FieldName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap

                If col = "id_prod_demand_product" Or col = "id_design" Or col = "id_product" _
                    Or col = "Code" Or col = "Style" Or col = "Size" Or col = "Qty" Or col = "Cost" _
                    Or col = "Currency" Or col = "id_currency" Or col = "Kurs" Or col = "Total Cost" _
                    Then
                    GVProductRev.Columns(GVProductRev.Columns(j).FieldName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    GVProductRev.Columns(GVProductRev.Columns(j).FieldName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                Else
                    GVProductRev.Columns(GVProductRev.Columns(j).FieldName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    GVProductRev.Columns(GVProductRev.Columns(j).FieldName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    GVProductRev.Columns(GVProductRev.Columns(j).FieldName.ToString).ColumnEdit = riTE

                    'summary
                    GVProductRev.Columns(GVProductRev.Columns(j).FieldName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    GVProductRev.Columns(GVProductRev.Columns(j).FieldName.ToString).SummaryItem.DisplayFormat = "{0:n0}"
                End If

            Next

            '**UNBOUND COLUMN**
            'qty
            Dim columnExtQty As DevExpress.XtraGrid.Columns.GridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
            columnExtQty.FieldName = "Qty"
            columnExtQty.Caption = "Qty"
            columnExtQty.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
            columnExtQty.UnboundExpression = allc_cond
            GVProductRev.Columns.Add(columnExtQty)
            columnExtQty.VisibleIndex = 3
            columnExtQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            columnExtQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            columnExtQty.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            columnExtQty.SummaryItem.DisplayFormat = "{0:n0}"
            columnExtQty.AppearanceHeader.Font = New Font(GVProductRev.Appearance.Row.Font.FontFamily, GVProductRev.Appearance.Row.Font.Size, FontStyle.Bold)
            columnExtQty.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap


            'total cost
            Dim columnTotalCost As DevExpress.XtraGrid.Columns.GridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
            columnTotalCost.FieldName = "Total"
            columnTotalCost.Caption = "Total Cost"
            columnTotalCost.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
            columnTotalCost.UnboundExpression = "[Cost] * [Qty]"
            GVProductRev.Columns.Add(columnTotalCost)
            columnTotalCost.VisibleIndex = 5
            columnTotalCost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            columnTotalCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            columnTotalCost.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            columnTotalCost.SummaryItem.DisplayFormat = "{0:n0}"
            columnTotalCost.AppearanceHeader.Font = New Font(GVProductRev.Appearance.Row.Font.FontFamily, GVProductRev.Appearance.Row.Font.Size, FontStyle.Bold)
            columnTotalCost.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            GVProductRev.Columns("Total").Visible = False

            '*GROUP**
            GVProductRev.Columns("Style").GroupIndex = 0
            GVProductRev.ExpandAllGroups()


            '**OPTIONS VIEW**
            optionsView(GVProductRev, "FormProdDemandDesignSingle", "GVProductRev", "1")

            GVProductRev.FocusedRowHandle = 0
        End If
        checkBtnIdBom()
    End Sub
    'get id bom
    Sub checkBtnIdBom()
        Dim id_bom As String = ""
        Try
            id_bom = GVProductRev.GetFocusedRowCellValue("id_bom").ToString
        Catch ex As Exception

        End Try
        If id_bom = "" Then
            BViewBOM.Enabled = False
        Else
            BViewBOM.Enabled = True
        End If
    End Sub
    'View Design
    Sub viewDesign()
        'updated 23 0ktober 2014
        Dim id_design_temp As String = id_design
        Dim query As String = "CALL view_design_demand_unselected('" + id_design + "', '" + id_prod_demand + "')"
        viewSearchLookupQuery(SLEDesign, query, "id_design", "view_design", "id_design")
        SearchLookUpEdit1View.Columns("season").GroupIndex = 0
        SearchLookUpEdit1View.Columns("category_design").GroupIndex = 1

        'only update action
        If action = "upd" Then
            SLEDesign.EditValue = id_design_temp
        End If

        id_design_initial = SLEDesign.EditValue
        id_sample = execute_query("SELECT id_sample FROM tb_m_design WHERE id_design = '" + id_design + "'", 0, True, "", "", "", "")
        pre_viewImages("2", PictureEdit1, id_design, False)
    End Sub
    'View Delivery
    Sub viewDelivery()
        Dim query As String = "SELECT * FROM tb_season_delivery WHERE id_season = '" + id_season + "'"
        viewLookupQuery(LEDelivery, query, 0, "delivery", "id_delivery")
    End Sub
    'Form Close
    Private Sub FormProdDemandDesignSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
        'checkFormAccess("FormProdDemand")
    End Sub
    'Btn Cancel
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        ALT_F4 = False
        Close()
    End Sub
    'Btn Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        If Not formIsValidInGroup(EPDesign, GroupControlDesign) Or Not formIsValidInGroup(EPDesign, GroupControlMSRP) Then
            errorInput()
        Else
            Dim query As String
            Dim id_delivery As String = LEDelivery.EditValue
            id_design = SLEDesign.EditValue
            Dim prod_demand_design_propose_price As String
            Dim royalty_design As String
            Dim royalty_special As String
            Dim prod_demand_design_estimate_price As String
            Dim inflation As String
            Dim prod_demand_design_total_cost As String
            Dim add_cost As String = decimalSQL(TxtAdditionalCost.EditValue.ToString)
            Dim add_price As String = decimalSQL(TxtAdditionalPrice.EditValue.ToString)
            prod_demand_design_propose_price = decimalSQL(addSlashes(TxtProposePrice.EditValue.ToString))
            prod_demand_design_total_cost = decimalSQL(TxtTotalCost.EditValue.ToString)
            royalty_design = decimalSQL(addSlashes(TxtRoyaltyDesign.EditValue.ToString))
            royalty_special = decimalSQL(addSlashes(TxtRoyaltySpecial.EditValue.ToString))
            prod_demand_design_estimate_price = decimalSQL(TxtTotalCost.EditValue.ToString)
            inflation = decimalSQL(TxtInflasi.EditValue.ToString)
            If id_currency = "" Then
                id_currency = "-1"
            End If

            'updated 16 december 2014
            Dim rate_current As String = decimalSQL(TxtRate.EditValue.ToString)
            Dim msrp As String = decimalSQL(TxtMSRP.EditValue.ToString)
            Dim msrp_rp As String = decimalSQL(TxtMSRPRp.EditValue.ToString)
            Dim date_available_start As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")

            '02 januari 2019
            Dim rate_management As String = decimalSQL(TxtRateManagement.EditValue.ToString)

            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = "INSERT INTO tb_prod_demand_design(id_prod_demand, id_delivery, id_design, prod_demand_design_propose_price, prod_demand_design_estimate_price, rate_current, msrp, msrp_rp, date_available_start) "
                        query += "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');SELECT LAST_INSERT_ID() "
                        query = String.Format(query, id_prod_demand, id_delivery, id_design, prod_demand_design_propose_price, prod_demand_design_estimate_price, rate_current, msrp, msrp_rp, date_available_start)
                        id_prod_demand_design = execute_query(query, 0, True, "", "", "", "")
                        logData("tb_prod_demand_design", 1)
                        infoCustom("Design : " + SLEDesign.Properties.GetDisplayText(SLEDesign.EditValue) + ", successfully added")
                        action = "upd"
                        actionLoad()
                        refreshMain()
                    Catch ex As Exception
                        errorConnection()
                        Close()
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        Dim cond_date As Boolean = True

                        Dim start_date As String = "0000-01-01"
                        Try
                            start_date = DEStart.EditValue.ToString
                        Catch ex As Exception
                        End Try


                        If start_date = "" Or start_date = "0000-01-01" Then
                            cond_date = False
                        Else
                            cond_date = True
                        End If

                        If cond_date Then
                            'Dim date_available_start As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")

                            query = "UPDATE tb_prod_demand_design SET id_design = '" + id_design + "', id_delivery = '" + id_delivery + "', prod_demand_design_propose_price='" + prod_demand_design_propose_price + "', royalty_design = '" + royalty_design + "', royalty_special='" + royalty_special + "', prod_demand_design_estimate_price = '" + prod_demand_design_estimate_price + "', inflation = '" + inflation + "', prod_demand_design_total_cost='" + prod_demand_design_total_cost + "', date_available_start='" + date_available_start + "', rate_current = '" + rate_current + "', rate_management='" + rate_management + "', msrp='" + msrp + "', msrp_rp='" + msrp_rp + "', "
                            If id_currency = "-1" Or id_currency = "" Then
                                query += "id_currency = NULL "
                            Else
                                query += "id_currency = '" + id_currency + "' "
                            End If
                            query += ",additional_cost='" + add_cost + "', additional_price='" + add_price + "' "
                            query += "WHERE id_prod_demand_design = '" + id_prod_demand_design + "' "
                            execute_non_query(query, True, "", "", "", "")
                            logData("tb_prod_demand_design", 2)
                            refreshMain()

                            'cek update cost
                            makeSafeGV(GVLogCost)
                            logCost()
                            If GVLogCost.RowCount < 0 Then 'pasti insert
                                insLogCost(id_design, rate_current, prod_demand_design_total_cost, id_currency)
                            Else
                                Dim jum_row_log As Integer = GVLogCost.RowCount
                                Dim last_cost_log As Decimal = 0.0
                                Try
                                    last_cost_log = GVLogCost.GetRowCellValue(jum_row_log - 1, "prod_demand_log_cost")
                                Catch ex As Exception
                                End Try
                                If last_cost_log <> FormatNumber(TxtTotalCost.EditValue, 2) Then
                                    'insert
                                    insLogCost(id_design, rate_current, prod_demand_design_total_cost, id_currency)
                                End If
                            End If
                        Else
                            stopCustom("Please input valid price available start/end !")
                        End If
                    Catch ex As Exception
                        errorConnection()
                    End Try
                    Cursor = Cursors.Default

                    'update design
                    Dim stt As New ClassDesign
                    stt.updatedTime(id_design)
                End If
            End If
        End If
    End Sub

    Sub insLogCost(ByVal id_design_par As String, ByVal rate_current_par As String, ByVal prod_demand_design_total_cost_par As String, ByVal id_currency_par As String)
        'Dim query_log_cost As String = "INSERT INTO tb_prod_demand_log_cost(id_design, id_user, prod_demand_log_cost_rate, prod_demand_log_cost, prod_demand_log_cost_time, id_currency) "
        'query_log_cost += "VALUES('" + id_design_par + "', '" + id_user + "', '" + rate_current_par + "', '" + prod_demand_design_total_cost_par + "', NOW(), '" + id_currency_par + "' ) "
        'execute_non_query(query_log_cost, True, "", "", "", "")
        logCost()
    End Sub

    Sub refreshMain()
        If form_name = "-1" Then
            FormProdDemandSingle.viewDesignDemand()
            FormProdDemandSingle.GVDesign.FocusedRowHandle = find_row(FormProdDemandSingle.GVDesign, "id_prod_demand_design", id_prod_demand_design)
            FormProdDemand.viewProdDemand()
            FormProdDemand.GVProdDemand.FocusedRowHandle = find_row(FormProdDemand.GVProdDemand, "id_prod_demand", FormProdDemandSingle.id_prod_demand)
            ALT_F4 = False
            Close()
        ElseIf form_name = "FormMasterDesignSingle" Then
            FormFGLineList.viewLineList()
            FormFGLineList.BGVLineList.FocusedRowHandle = find_row(FormFGLineList.BGVLineList, "id_design", id_design)
            infoCustom("Edit has been succesfully.")
        End If
    End Sub
    'Edit Value Changed
    Private Sub SLEDesign_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEDesign.EditValueChanged
        Cursor = Cursors.WaitCursor
        id_design = SLEDesign.EditValue.ToString
        Try
            Dim rowHandle As Integer = SLEDesign.Properties.View.FocusedRowHandle
            id_sample = SLEDesign.Properties.View.GetRowCellValue(rowHandle, "id_sample").ToString
        Catch ex As Exception
            id_sample = "-1"
        End Try
        id_design_initial = id_design
        pre_viewImages("2", PictureEdit1, id_design, False)
        Cursor = Cursors.Default
    End Sub
    'Add Size
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormProdDemandBreakSingle.action = "ins"
        FormProdDemandBreakSingle.ShowDialog()
    End Sub

    'Edit Size
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Cursor = Cursors.WaitCursor
        edit_break()
        Cursor = Cursors.Default
    End Sub

    Sub edit_break()
        If form_name = "-1" Then
            FormProdDemandBreakSingle.action = "upd"
            FormProdDemandBreakSingle.ShowDialog()
        ElseIf form_name = "FormMasterDesignSingle" Then
            If FormMasterDesignSingle.bool_qty_line = True Then
                'rev
                BViewBOM.Visible = False
                BtnEdit.Visible = False
                BtnDoneEditing.Visible = True
                BtnDiscard.Visible = True
                GVProductRev.OptionsBehavior.ReadOnly = False

                'editable only for allocation
                For j As Integer = 0 To GVProductRev.Columns.Count - 1
                    Dim col As String = GVProductRev.Columns(j).FieldName.ToString
                    If col = "id_prod_demand_product" Or col = "id_design" Or col = "id_product" _
                    Or col = "Code" Or col = "Style" Or col = "Size" Or col = "Qty" Or col = "Cost" _
                    Or col = "Currency" Or col = "id_currency" Or col = "Kurs" Or col = "Total Cost" _
                    Then
                        GVProductRev.Columns(j).OptionsColumn.ReadOnly = True
                    Else
                        GVProductRev.Columns(j).OptionsColumn.ReadOnly = False
                    End If
                Next

                'old
                'FormProdDemandBreakSingle.action = "upd"
                'FormProdDemandBreakSingle.id_prod_demand_product = GVProduct.GetFocusedRowCellDisplayText("id_prod_demand_product").ToString
                'FormProdDemandBreakSingle.ShowDialog()
            End If
        End If
    End Sub
    'Check Price
    Private Sub BtnCheckPrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCheckPrice.Click
        Cursor = Cursors.WaitCursor
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want update to current estimate COP?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            'query get cost
            Dim q_cost As String = "SELECT dsg.id_design, "
            q_cost += "CAST(IF(dsg.prod_order_cop_pd_curr!=opt.id_currency_default, dsg.prod_order_cop_pd*dsg.prod_order_cop_kurs_pd, dsg.prod_order_cop_pd) AS DECIMAL(15,2)) as `cost_upd`, "
            q_cost += "dsg.prod_order_cop_pd_addcost, IF(dsg.prod_order_cop_pd_addcost>0,opt.default_add_price,0) AS `default_add_price`, "
            q_cost += "dsg.prod_order_cop_pd, dsg.prod_order_cop_kurs_pd, dsg.prod_order_cop_pd_curr "
            q_cost += "FROM tb_m_design dsg "
            q_cost += "JOIN tb_opt opt "
            q_cost += "WHERE dsg.id_design='" + id_design + "' "
            Dim dt_cost As DataTable = execute_query(q_cost, -1, True, "", "", "", "")
            Dim cost_upd As Decimal = 0.0
            Dim curr_upd As String = "1"
            Dim rate_upd As Decimal = "1"
            Dim add_cost As Decimal = 0.0
            Dim add_price As Decimal = 0.0
            id_currency = "-1"
            Try
                cost_upd = dt_cost.Rows(0)("cost_upd")
            Catch ex As Exception
            End Try
            Try
                curr_upd = dt_cost.Rows(0)("prod_order_cop_pd_curr")
            Catch ex As Exception
            End Try
            Try
                rate_upd = dt_cost.Rows(0)("prod_order_cop_kurs_pd")
            Catch ex As Exception
            End Try
            Try
                id_currency = curr_upd.ToString
            Catch ex As Exception
            End Try
            Try
                add_cost = dt_cost.Rows(0)("prod_order_cop_pd_addcost")
            Catch ex As Exception
            End Try
            Try
                add_price = dt_cost.Rows(0)("default_add_price")
            Catch ex As Exception
            End Try
            TxtEstimateCost.EditValue = cost_upd
            TxtTotalCost.EditValue = cost_upd
            TxtAdditionalCost.EditValue = add_cost
            TxtCostNonAdditional.EditValue = cost_upd - add_cost
            TxtRate.EditValue = rate_upd
            TxtAdditionalPrice.EditValue = add_price
            TxtPriceNonAdditional.EditValue = TxtProposePrice.EditValue - add_price



            getMarkUp()
            viewBreakdown()
            viewAllocation()

            Dim cur As String = ""
            Try
                cur = GVProductRev.GetFocusedRowCellValue("Currency").ToString
            Catch ex As Exception
            End Try
            TxtCurr.Text = cur
        End If
        Cursor = Cursors.Default
    End Sub
    'Edit Value Markup
    Private Sub TxtMarkup_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMarkup.KeyUp

    End Sub
   

    'Edit Propose
    Private Sub TxtProposePrice_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtProposePrice.KeyUp
        TxtPriceNonAdditional.EditValue = TxtProposePrice.EditValue - TxtAdditionalPrice.EditValue
        getMarkUp()
        getRealEstimate()
    End Sub

    'Get Propose Price
    Sub getPropose()
        estimate_cost = FormatNumber(TxtEstimateCost.EditValue, 2)
        Dim markup As Decimal = FormatNumber(TxtMarkup.EditValue, 2)
        Dim mr As Decimal = 0.0
        Dim mi As Decimal = 0.0
        getRoyalty()
        Dim inflation As Decimal = TxtInflasi.EditValue / 100
        Dim propose_price As Decimal

        mr = markup * royalty
        mi = markup * inflation
        'Console.WriteLine(markup)
        'Console.WriteLine(royalty)
        'Console.WriteLine(mr)
        'Console.WriteLine(mi)
        'Console.WriteLine(estimate_cost)

        If 1 - mr - mi > 0 Then
            propose_price = (markup * estimate_cost) / (1 - mr - mi)
            EPDesign.SetError(TxtProposePrice, String.Empty)
        Else
            propose_price = 0.0
            EPDesign.SetError(TxtProposePrice, "Maximum markup exceeded or cannot divide by zero !")
        End If
        TxtProposePrice.EditValue = propose_price


    End Sub
    'Get Estimate BOM
    Private Sub BtnEstimate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEstimate.Click
        Cursor = Cursors.WaitCursor
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want update to current Actual COP?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query_cop As String = "SELECT design_cop FROM tb_m_design WHERE id_design ='" + id_design + "' "
            Dim act_cop As Decimal = Decimal.Parse(execute_query(query_cop, 0, True, "", "", "", ""))
            TxtEstimateCost.EditValue = act_cop
            TxtTotalCost.EditValue = act_cop
            getMarkUp()
            TxtCurr.Text = "Rp"
            id_currency = "1"
            TxtRate.EditValue = 1.0
        End If
        Cursor = Cursors.Default
    End Sub

    Sub getEstimate()
        'Dim total_estimate As Decimal = 0.0
        'Try
        '    total_estimate = GVProductRev.Columns("Total").SummaryItem.SummaryValue
        'Catch ex As Exception
        'End Try

        'Dim total_qty As Decimal = 0.0
        'Try
        '    total_qty = GVProductRev.Columns("Qty").SummaryItem.SummaryValue
        'Catch ex As Exception
        'End Try

        'Dim res_est As Decimal = 0.0
        'Try
        '    res_est = total_estimate / total_qty
        'Catch ex As Exception
        'End Try
        'TxtEstimateCost.EditValue = res_est

        ''updated 9 desember 2014 - get real estimate (bom price + royalty + inflation)
        'getRealEstimate()
    End Sub

    Sub getRealEstimate()
        ''updated 9 desember 2014 - get real estimate (bom price + royalty + inflation)
        'Dim bom_price As Decimal = 0.0
        'Try
        '    bom_price = Decimal.Parse(TxtEstimateCost.EditValue.ToString)
        'Catch ex As Exception
        'End Try



        'getRoyalty()
        'Dim propose_price As Decimal = 0.0
        'Try
        '    propose_price = Decimal.Parse(TxtProposePrice.EditValue.ToString)
        'Catch ex As Exception
        'End Try
        'Dim pr As Decimal = propose_price * royalty

        'Dim inflation As Decimal = 0.0
        'Try
        '    inflation = Decimal.Parse(TxtInflasi.EditValue.ToString) / 100
        'Catch ex As Exception
        'End Try
        'Dim pi As Decimal = propose_price * inflation

        'Dim real_estimate As Decimal = 0.0
        'Try
        '    real_estimate = bom_price + pr + pi
        'Catch ex As Exception
        'End Try
        'TxtTotalCost.EditValue = real_estimate
    End Sub

    'Get Markup
    Sub getMarkUp()
        estimate_cost = 0
        Try
            estimate_cost = Decimal.Parse(TxtCostNonAdditional.EditValue)
        Catch ex As Exception

        End Try
        Dim propose_price As Decimal = 0.0
        Dim markup As Decimal
        Try
            propose_price = Decimal.Parse(TxtPriceNonAdditional.EditValue)
        Catch ex As Exception
        End Try
        getRoyalty()
        Dim inflation As Decimal = TxtInflasi.EditValue / 100
        Try
            ' markup = propose_price / (estimate_cost + (royalty * propose_price) + (inflation * propose_price))
            markup = propose_price / estimate_cost
        Catch ex As Exception
        End Try
        TxtMarkup.EditValue = markup
    End Sub
    'Edit Value Royalty
    Private Sub TxtRoyaltyDesign_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRoyaltyDesign.KeyUp
        getRealEstimate()
        getMarkUp()
    End Sub
    Private Sub TxtRoyaltySpecial_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRoyaltySpecial.KeyUp
        getRealEstimate()
        getMarkUp()
    End Sub
    'Edit Value Estimate Cost
    Private Sub TxtEstimateCost_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEstimateCost.KeyUp
        'getPropose()
    End Sub
    'Validarting
    Private Sub TxtRoyaltyDesign_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtRoyaltyDesign.Validating
        If action = "upd" Then
            ' EP_TE_must_decimal(EPDesign, TxtRoyaltyDesign)
        End If
    End Sub
    Private Sub TxtRoyaltySpecial_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtRoyaltySpecial.Validating
        If action = "upd" Then
            'EP_TE_must_decimal(EPDesign, TxtRoyaltySpecial)
        End If
    End Sub
    Private Sub TxtEstimateCost_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtEstimateCost.Validating
        If action = "upd" Then
            ' EP_TE_must_decimal(EPDesign, TxtEstimateCost)
        End If
    End Sub
    Private Sub TxtMarkup_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtMarkup.Validating
        If action = "upd" Then
            'MsgBox(TxtMarkup.EditValue)
            ' EP_TE_must_decimal(EPDesign, TxtMarkup)
        End If
    End Sub
    Private Sub TxtProposePrice_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtProposePrice.Validating
        If action = "upd" Then
            'MsgBox(TxtProposePrice.EditValue)
            'EP_TE_must_decimal(EPDesign, TxtProposePrice)
        End If
    End Sub
    'Key down
    Private Sub TxtEstimateCost_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEstimateCost.KeyDown
        'If (e.KeyCode = Keys.E AndAlso e.Modifiers = Keys.Control) Then
        '    getEstimate()
        '    getPropose()
        'End If
    End Sub
    Private Sub BViewImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    'View Image
    Private Sub BViewImage_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewImage.Click
        Try
            pre_viewImages("2", PictureEdit1, id_design, True)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BViewBOM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewBOM.Click
        Dim id_b As String = "-1"
        Try
            id_b = GVProductRev.GetFocusedRowCellValue("id_bom").ToString
        Catch ex As Exception
        End Try
        Dim nama_p As String = ""
        Try
            nama_p = GVProductRev.GetFocusedRowCellValue("Style").ToString
        Catch ex As Exception
        End Try
        Dim id_p As String = ""
        Try
            id_p = GVProductRev.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try
        viewBom(id_b, nama_p, id_p)
    End Sub

    Sub viewBom(ByVal id_bom_par As String, ByVal nama_par As String, ByVal id_product_par As String)
        FormViewBOM.id_bom = id_bom_par
        FormViewBOM.nama_product = nama_par
        FormViewBOM.id_product = id_product_par
        FormViewBOM.mark = False
        FormViewBOM.ShowDialog()
    End Sub

    Private Sub GVProduct_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        Cursor = Cursors.WaitCursor
        checkBtnIdBom()
        viewAllocation()
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtInflasi_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtInflasi.KeyUp
        getRealEstimate()
        getMarkUp()
    End Sub


    Private Sub FormProdDemandDesignSingle_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (e.CloseReason = CloseReason.UserClosing) And ALT_F4 Then
            e.Cancel = True
        End If
    End Sub


    Private Sub TxtRate_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRate.EditValueChanged
        getMSRPRP()
    End Sub

    Sub getMSRPRP()
        'UPDATED 16 DECEMBER 2014
        Dim rate As Decimal = 0.0
        Try
            rate = TxtRateManagement.EditValue
        Catch ex As Exception
        End Try

        Dim msrp As Decimal = 0.0
        Try
            msrp = TxtMSRP.EditValue
        Catch ex As Exception
        End Try

        TxtMSRPRp.EditValue = rate * msrp
    End Sub

    Private Sub TxtMSRP_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMSRP.EditValueChanged
        getMSRPRP()
    End Sub

    Private Sub TxtRate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtRate.Validating
        EP_TE_cant_blank(EPDesign, TxtRate)
    End Sub

    Private Sub TxtMSRP_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtMSRP.Validating
        EP_TE_cant_blank(EPDesign, TxtMSRP)
    End Sub

    Private Sub TxtMSRPRp_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtMSRPRp.Validating
        EP_TE_cant_blank(EPDesign, TxtMSRPRp)
    End Sub

    'Updated 16 Januari 2015
    Sub viewAllocation()
        'Dim id_prod_demand_product_ As String = "-1"
        'Try
        '    id_prod_demand_product_ = GVProduct.GetFocusedRowCellValue("id_prod_demand_product")
        'Catch ex As Exception
        'End Try

        'Dim query As String = ""
        'query += "SELECT * FROM tb_prod_demand_alloc allc "
        'query += "INNER JOIN tb_lookup_pd_alloc pd_allc ON allc.id_pd_alloc = pd_allc.id_pd_alloc "
        'query += "WHERE allc.id_prod_demand_product = '" + id_prod_demand_product_ + "' "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'GCAllocation.DataSource = Data
    End Sub

    Private Sub GVProduct_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.WaitCursor
        viewAllocation()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVProduct_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.WaitCursor
        edit_break()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnProposePrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProposePrice.Click
        Cursor = Cursors.WaitCursor
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to update to propose price?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query As String = "CALL generate_pd_upd_act_price('" + id_design + "', FALSE) "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim pp As Decimal = 0.0
            Try
                pp = data.Rows(0)("price_final")
            Catch ex As Exception
            End Try
            TxtProposePrice.EditValue = pp
            getMarkUp()
        End If
        Cursor = Cursors.Default
    End Sub



    Private Sub GroupControlRetail_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupControlRetail.Paint

    End Sub

    Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        Cursor = Cursors.WaitCursor
        logCost()
        Cursor = Cursors.Default
    End Sub
    Sub resetNavBreakdown()
        BtnDiscard.Visible = False
        BtnDoneEditing.Visible = False
        BtnEdit.Visible = True
        BViewBOM.Visible = True
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to discard changes ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            data_edit.Clear()
            resetNavBreakdown()
            viewBreakdown()
        End If
    End Sub

    Private Sub GVProductRev_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProductRev.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        checkBtnIdBom()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVProductRev_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVProductRev.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim row_foc As Integer = e.RowHandle
        Dim col As String = e.Column.FieldName.ToString
        If col = "id_prod_demand_product" Or col = "id_design" Or col = "id_product" _
                    Or col = "Code" Or col = "Style" Or col = "Size" Or col = "Qty" Or col = "Cost" _
                    Or col = "Currency" Or col = "id_currency" Or col = "Kurs" Or col = "Total Cost" _
                    Then
            'no action
        Else
            Dim R As DataRow = data_edit.NewRow
            R("id_prod_demand_product") = GVProductRev.GetRowCellValue(row_foc, "id_prod_demand_product").ToString
            R("pd_alloc") = col
            R("qty") = decimalSQL(e.Value.ToString)
            data_edit.Rows.Add(R)
        End If
        GCProductRev.RefreshDataSource()
        GVProductRev.RefreshData()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDoneEditing_Click(sender As Object, e As EventArgs) Handles BtnDoneEditing.Click
        GVProductRev.ExpandAllGroups()
        PBC.Visible = True
        PBC.Properties.Minimum = 0
        PBC.Properties.Maximum = data_edit.Rows.Count - 1
        PBC.Properties.Step = 1
        For i As Integer = 0 To data_edit.Rows.Count - 1
            Dim query_main As String = "UPDATE tb_prod_demand_alloc pd_allc "
            query_main += "INNER JOIN tb_lookup_pd_alloc allc ON allc.id_pd_alloc = pd_allc.id_pd_alloc "
            query_main += "INNER JOIN tb_prod_demand_product pd_prod ON pd_prod.id_prod_demand_product = pd_allc.id_prod_demand_product "
            query_main += "SET pd_allc.prod_demand_alloc_qty='" + data_edit.Rows(i)("qty").ToString + "'  "
            query_main += "WHERE pd_allc.id_prod_demand_product='" + data_edit.Rows(i)("id_prod_demand_product").ToString + "' AND allc.pd_alloc='" + data_edit.Rows(i)("pd_alloc").ToString + "' AND pd_prod.id_prod_demand_design='" + id_prod_demand_design + "' "
            execute_non_query(query_main, True, "", "", "", "")
            If i = data_edit.Rows.Count - 1 Then
                For j As Integer = 0 To ((GVProductRev.RowCount - 1) - GetGroupRowCount(GVProductRev))
                    Dim query_sub As String = "UPDATE tb_prod_demand_product "
                    query_sub += "SET prod_demand_product_qty='" + decimalSQL(GVProductRev.GetRowCellValue(j, "Qty").ToString) + "' "
                    query_sub += "WHERE id_prod_demand_product='" + GVProductRev.GetRowCellValue(j, "id_prod_demand_product").ToString + "' "
                    execute_non_query(query_sub, True, "", "", "", "")
                Next
            End If
            PBC.PerformStep()
            PBC.Update()
        Next
        data_edit.Clear()
        resetNavBreakdown()
        viewBreakdown()
        PBC.Visible = False
    End Sub

    Private Sub GVProductRev_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVProductRev.PopupMenuShowing
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column And id_role_login = id_role_super_admin Then
            Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = e.Menu

            If Not menu.Column Is Nothing Then
                menu.Items.Add(CreateCheckItem("Options View", menu.Column))
            End If
        End If
    End Sub

    ' Creates a menu item.
    Function CreateCheckItem(ByVal caption As String, ByVal column As DevExpress.XtraGrid.Columns.GridColumn) As DevExpress.Utils.Menu.DXMenuItem
        Dim item As DevExpress.Utils.Menu.DXMenuItem = New DevExpress.Utils.Menu.DXMenuItem(caption, New EventHandler(AddressOf OnCanMovedItemClick))
        item.Tag = New MenuColumnInfo(column)
        Return item
    End Function

    ' Menu item click handler.
    Sub OnCanMovedItemClick(ByVal sender As Object, ByVal e As EventArgs)
        data_column.Clear()
        For i As Integer = 0 To GVProductRev.Columns.Count - 1
            'Console.WriteLine(GVProductRev.Columns(i).Caption.ToString + "-" + GVProductRev.Columns(i).Visible.ToString)
            Dim R As DataRow = data_column.NewRow
            R("options_view_det_band") = "-"
            R("options_view_det_caption") = GVProductRev.Columns(i).FieldName.ToString
            R("options_view_det_column") = GVProductRev.Columns(i).FieldName.ToString
            R("options_view_det_visible") = GVProductRev.Columns(i).Visible.ToString
            data_column.Rows.Add(R)
        Next
        FormOptView.frm_opt_name = "FormProdDemandDesignSingle"
        FormOptView.gv_opt_name = "GVProductRev"
        FormOptView.tag_opt_name = "1"
        FormOptView.dt = data_column
        FormOptView.ShowDialog()
    End Sub

    ' The class that stores menu specific information.
    Class MenuColumnInfo
        Public Sub New(ByVal column As DevExpress.XtraGrid.Columns.GridColumn)
            Me.Column = column
        End Sub
        Public Column As DevExpress.XtraGrid.Columns.GridColumn
    End Class

    Private Sub GVLogCost_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVLogCost.FocusedRowChanged

    End Sub

    Private Sub BtnRateCurrent_Click(sender As Object, e As EventArgs) Handles BtnRateCurrent.Click
        Cursor = Cursors.WaitCursor
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to update rate?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query As String = "SELECT IFNULL(o.rate_management,1) AS `rate_management` FROM tb_opt o "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtRateManagement.EditValue = data.Rows(0)("rate_management")
            getMSRPRP()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVLogCost_DoubleClick(sender As Object, e As EventArgs) Handles GVLogCost.DoubleClick
        Dim id_b As String = "-1"
        Try
            id_b = GVLogCost.GetFocusedRowCellValue("id_bom").ToString
        Catch ex As Exception
        End Try
        Dim nama_p As String = "-"
        Dim id_p As String = ""
        Try
            id_p = GVLogCost.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try
        viewBom(id_b, nama_p, id_p)
    End Sub



    Private Sub BtnDs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDs.Click
        Cursor = Cursors.WaitCursor
        Dim jum_cek As Integer = 0
        Dim str_id As String = ""
        For i As Integer = 0 To ((GVProductRev.RowCount - 1) - GetGroupRowCount(GVProductRev))
            Dim id_prod_demand_product As String = GVProductRev.GetRowCellValue(i, "id_prod_demand_product").ToString
            If jum_cek > 0 Then
                str_id += "; "
            End If
            str_id += id_prod_demand_product
            jum_cek += 1
        Next

        If jum_cek > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to set qty based on Distribution Scheme?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim query As String
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = "CALL generate_qty_ds('" + str_id + "') "
                    execute_non_query(query, True, "", "", "", "")
                    viewBreakdown()
                    viewAllocation()
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        Else
            stopCustom("Nothing item selected!")
        End If
        Cursor = Cursors.Default
    End Sub
End Class