Public Class FormProductionCOP 
    'Public id_prod_order As String = "-1"
    'update to id_design 
    Public id_design As String = "-1"
    Public is_view As String = "2"
    Public is_final As String = "1"
    Dim is_approve As String = "2"

    Private Sub FormProductionCOP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_rate_cat()
        view_status(LEStatus)

        load_form()
    End Sub

    Sub load_rate_cat()
        Dim query As String = "SELECT * FROM tb_lookup_cop_rate_cat"
        viewSearchLookupQuery(SLECurrentBOM, query, "id_cop_rate_cat", "cop_rate_cat", "id_cop_rate_cat")
    End Sub

    Sub load_form()
        'show prod order detail
        If Not id_design = "-1" Then
            Dim query As String = String.Format("SELECT `pp_cop_rate_cat`,`pp_cop_kurs`,`pp_cop_value`,`pp_cop_mng_kurs`,`pp_cop_mng_value`,`pp_is_approve`,`final_cop_rate_cat`,`final_cop_kurs`,`final_cop_value`,`final_cop_mng_kurs`,`final_cop_mng_value`,`final_is_approve`,
rate_management,prod_order_cop_kurs_mng,prod_order_cop_mng,prod_order_cop_mng_addcost,design_name,design_display_name,design_code,id_cop_status,cop_pre_percent_bea_masuk,cop_pre_remark,design_cop,design_cop_addcost FROM tb_m_design WHERE id_design = '{0}'", id_design)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            TEDesign.Text = data.Rows(0)("design_display_name").ToString
            TEDesignCode.Text = data.Rows(0)("design_code").ToString
            'LEStatus.EditValue = data.Rows(0)("id_cop_status").ToString
            TEKursMan.EditValue = data.Rows(0)("prod_order_cop_kurs_mng")

            'pre final
            TEPercentBeamasuk.EditValue = data.Rows(0)("cop_pre_percent_bea_masuk")
            MERemark.Text = data.Rows(0)("cop_pre_remark").ToString
            '
            If data.Rows(0)("id_cop_status").ToString = "2" Then
                BUpdateCOP.Visible = False
                TEKursMan.Properties.ReadOnly = True
                '
                TEUnitPrice.Properties.ReadOnly = True
                TEAddCost.Properties.ReadOnly = True
                TEUnitCostBOM.Properties.ReadOnly = True
                TEUnitCostPD.Properties.ReadOnly = True
                '
            Else
                'if local can edit (Nanti ditutup setelah material average/lifo jalan) / Bu farida minta lokal bisa edit juga 05/13/2019 via lan messenger
                'If FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("product_source").ToString = "Import" Then
                'TEUnitPrice.Properties.ReadOnly = False
                'Else
                'TEUnitPrice.Properties.ReadOnly = True
                'End If

                TEAddCost.Properties.ReadOnly = False
                TEUnitCostBOM.Properties.ReadOnly = False
                TEUnitCostPD.Properties.ReadOnly = False
                '
            End If

            If LEStatus.EditValue.ToString = "1" Then
                'prefinal
                BPrintCOPMan.Visible = False
                '
                TEUnitPrice.EditValue = data.Rows(0)("prod_order_cop_mng") - data.Rows(0)("prod_order_cop_mng_addcost")
                TEAddCost.EditValue = data.Rows(0)("prod_order_cop_mng_addcost")
                '
                SLECurrentBOM.EditValue = data.Rows(0)("pp_cop_rate_cat").ToString

                TEKursCurrent.EditValue = data.Rows(0)("pp_cop_kurs")
                TECOPCurrent.EditValue = data.Rows(0)("pp_cop_value") - data.Rows(0)("prod_order_cop_mng_addcost")
                TEKursMan.EditValue = data.Rows(0)("pp_cop_mng_kurs")
                TECOPMan.EditValue = data.Rows(0)("pp_cop_mng_value") - data.Rows(0)("prod_order_cop_mng_addcost")
                '
                If data.Rows(0)("pp_is_approve").ToString = "1" Then
                    BApprove.Text = "Approved"
                    BApprove.Enabled = False
                    '
                    SLECurrentBOM.Enabled = False
                    TEKursCurrent.Enabled = False
                    BKursCurrent.Enabled = False
                    BKursMan.Enabled = False
                    TEKursMan.Enabled = False
                    TEAddCost.Enabled = False
                    '
                    BUpdateCOP.Enabled = False
                Else
                    BApprove.Text = "Lock + Approve"
                    '
                    SLECurrentBOM.Enabled = True

                    If SLECurrentBOM.EditValue.ToString = "1" Then
                        TEKursCurrent.Enabled = False
                    Else
                        TEKursCurrent.Enabled = True
                    End If

                    BKursCurrent.Enabled = True
                    BKursMan.Enabled = True
                    TEKursMan.Enabled = True
                    TEAddCost.Enabled = True
                    '
                    BUpdateCOP.Enabled = True
                End If
            Else
                'final
                BPrintCOPMan.Visible = True
                '
                TEUnitPrice.EditValue = data.Rows(0)("design_cop") - data.Rows(0)("design_cop_addcost")

                If data.Rows(0)("id_cop_status").ToString = "1" And data.Rows(0)("design_cop_addcost") <= 0 And data.Rows(0)("prod_order_cop_mng_addcost") > 0 Then
                    TEAddCost.EditValue = data.Rows(0)("prod_order_cop_mng_addcost")
                Else
                    TEAddCost.EditValue = data.Rows(0)("design_cop_addcost")
                End If

                '
                SLECurrentBOM.EditValue = data.Rows(0)("final_cop_rate_cat").ToString

                TEKursCurrent.EditValue = data.Rows(0)("final_cop_kurs")
                TECOPCurrent.EditValue = data.Rows(0)("final_cop_value") - data.Rows(0)("design_cop_addcost")
                TEKursMan.EditValue = data.Rows(0)("final_cop_mng_kurs")
                TECOPMan.EditValue = data.Rows(0)("final_cop_mng_value") - data.Rows(0)("design_cop_addcost")
                '
                If data.Rows(0)("final_is_approve").ToString = "1" Then
                    BApprove.Text = "Approved"
                    BApprove.Enabled = False
                    '
                    SLECurrentBOM.Enabled = False
                    TEKursCurrent.Enabled = False
                    BKursCurrent.Enabled = False
                    BKursMan.Enabled = False
                    TEKursMan.Enabled = False
                    TEAddCost.Enabled = False
                    '
                    BUpdateCOP.Enabled = False
                Else
                    BApprove.Text = "Lock + Approve"
                    BApprove.Enabled = True
                    '
                    SLECurrentBOM.Enabled = True

                    If SLECurrentBOM.EditValue.ToString = "1" Then
                        TEKursCurrent.Enabled = False
                    Else
                        TEKursCurrent.Enabled = True
                    End If

                    BKursCurrent.Enabled = True
                    BKursMan.Enabled = True
                    TEKursMan.Enabled = True
                    TEAddCost.Enabled = True
                    '
                    BUpdateCOP.Enabled = True
                End If
            End If
            '
            query = "SELECT prod.id_design,bom.id_currency,bom.kurs,bom.is_default,bom.id_bom FROM tb_bom bom"
            query += " INNER JOIN tb_m_product prod ON bom.id_product=prod.id_product"
            query += " WHERE id_design='" + id_design + "' AND is_default='1'"
            query += " LIMIT 1"
            data = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TEKursBom.EditValue = data.Rows(0)("kurs").ToString()
            Else
                TEKursBom.EditValue = 1
            End If

            query = "SELECT pd_desg.rate_current FROM tb_prod_demand_design pd_desg INNER JOIN tb_prod_demand pd ON pd.id_prod_demand=pd_desg.id_prod_demand WHERE pd.is_pd='1' AND pd.id_report_status='6' AND pd_desg.id_design='" + id_design + "' ORDER BY pd_desg.id_prod_demand_design DESC LIMIT 1"
            data = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TEKursPD.EditValue = data.Rows(0)("rate_current").ToString()
            Else
                TEKursPD.EditValue = 1
            End If

            '
            view_list_prod(id_design)
            view_list_cost(id_design)
            '
            calculate_cost_management()
            calculate_cost_bom()
            calculate_cost_pd()
            '
            calculate()
            calculate_pd()
            calculate_man()
            '
        End If
        '
        If is_view = "1" Then
            BUpdateCOP.Visible = False
        End If
    End Sub

    Sub view_list_prod(ByVal id_designx As String)
        Dim query = "CALL view_desg_rec('" & id_designx & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProd.DataSource = data
        GVListProd.ExpandAllGroups()
    End Sub

    Sub view_list_cost(ByVal id_designx As String)
        Dim query = ""
        '
        If LEStatus.EditValue.ToString = "1" Then
            query = "CALL view_cop_design_po('" & id_designx & "')"
        Else
            query = "CALL view_cop_design('" & id_designx & "')"
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCostBOM.DataSource = data
        Dim data_man As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCostMan.DataSource = data_man
        Dim data_pd As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCostPD.DataSource = data_pd
        '
        GVCostBOM.BestFitColumns()
        GVCostMan.BestFitColumns()
        GVCostPD.BestFitColumns()
    End Sub

    Private Sub GVListProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProd.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVCost_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVCostBOM.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub GVCostMan_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVCostMan.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub GVCostPD_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVCostPD.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Sub calculate()
        Dim qty, total, unit_price As Decimal
        qty = 0.0
        total = 0.0
        unit_price = 0.0
        Try
            qty = GVListProd.Columns("receive_created_qty").SummaryItem.SummaryValue
            total = GVCostBOM.Columns("total_price").SummaryItem.SummaryValue
            TEQtyBOM.EditValue = qty
            TETotalBOM.EditValue = total
        Catch ex As Exception
        End Try

        If TEQtyBOM.EditValue = 0.0 Or TETotalBOM.EditValue = 0.0 Then
            unit_price = 0
        Else
            unit_price = total / qty
        End If

        TEUnitCostBOM.EditValue = unit_price
    End Sub
    Sub calculate_pd()
        Dim qty, total, unit_price As Decimal
        qty = 0.0
        total = 0.0
        unit_price = 0.0
        Try
            qty = GVListProd.Columns("receive_created_qty").SummaryItem.SummaryValue
            total = GVCostPD.Columns("total_price").SummaryItem.SummaryValue
            TEQtyPD.EditValue = qty
            TETotalCostPD.EditValue = total
        Catch ex As Exception
        End Try

        If TEQtyPD.EditValue = 0.0 Or TETotalCostPD.EditValue = 0.0 Then
            unit_price = 0
        Else
            unit_price = total / qty
        End If

        TEUnitCostPD.EditValue = unit_price
    End Sub
    Sub calculate_man()
        Dim qty, total, total_addcost, addcost, unit_price As Decimal
        qty = 0.00
        total = 0.00
        unit_price = 0.00
        total_addcost = 0.00
        addcost = 0.00
        Try
            If LEStatus.EditValue.ToString = "1" Then
                qty = GVListProd.Columns("prod_order_qty").SummaryItem.SummaryValue
            Else
                qty = GVListProd.Columns("receive_created_qty").SummaryItem.SummaryValue
            End If

            total = GVCostMan.Columns("total_price").SummaryItem.SummaryValue
            total_addcost = GVCostMan.Columns("addcost").SummaryItem.SummaryValue
            TEQty.EditValue = qty

            TETotal.EditValue = total
        Catch ex As Exception
        End Try

        If TEQty.EditValue = 0.00 Or TETotal.EditValue = 0.00 Then
            unit_price = 0
        Else
            unit_price = total / qty
        End If
        'addcost
        If TEQty.EditValue = 0.00 Or total_addcost = 0.00 Then
            addcost = 0
        Else
            addcost = total_addcost / qty
        End If
        'TEUnitPrice.EditValue = unit_price
        TEUnitCostActual.EditValue = unit_price
    End Sub
    Private Sub BUpdateCOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUpdateCOP.Click
        Cursor = Cursors.WaitCursor
        If Not id_design = "-1" Then
            'additional cost
            Dim qty As Decimal = 0.00

            Try
                qty = GVListProd.Columns("receive_created_qty").SummaryItem.SummaryValue
            Catch ex As Exception
            End Try

            'Update tb_prod_order
            If LEStatus.EditValue = "2" Then 'final
                If Not id_role_login = get_opt_prod_field("id_role_prod_manager") Then
                    stopCustom("You have no right to edit final COP.")
                ElseIf TECOPCurrent.EditValue <= 0 Or TECOPMan.EditValue <= 0 Then
                    stopCustom("Please click get value COP by rate.")
                Else
                    Dim confirm As DialogResult
                    confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to finalize this COP ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        'final COP
                        Dim query As String = String.Format("UPDATE tb_m_design SET prod_order_cop_qty='{0}',prod_order_cop_last_upd=NOW(), design_cop='{1}',design_cop_addcost='{3}',`final_cop_rate_cat`='{4}',`final_cop_kurs`='{5}',`final_cop_value`='{6}',`final_cop_mng_kurs`='{7}',`final_cop_mng_value`='{8}',final_is_approve=2 WHERE id_design='{2}'", decimalSQL(TEQty.EditValue.ToString), decimalSQL((TEUnitPrice.EditValue + TEAddCost.EditValue).ToString), id_design, decimalSQL(TEAddCost.EditValue.ToString), SLECurrentBOM.EditValue.ToString, decimalSQL(TEKursCurrent.EditValue.ToString), decimalSQL((TECOPCurrent.EditValue + TEAddCost.EditValue).ToString), decimalSQL(TEKursMan.EditValue.ToString), decimalSQL((TECOPMan.EditValue + TEAddCost.EditValue).ToString))
                        execute_non_query(query, True, "", "", "", "")
                        'add pre final juga jika kosong
                        query = String.Format("UPDATE tb_m_design SET prod_order_cop_total_man='{0}',prod_order_cop_kurs_mng='{1}',prod_order_cop_mng='{2}',prod_order_cop_mng_addcost='{4}',`pp_cop_rate_cat`='{5}',`pp_cop_kurs`='{6}',`pp_cop_value`='{7}',`pp_cop_mng_kurs`='{8}',`pp_cop_mng_value`='{9}',pp_is_approve=2 WHERE id_design='{3}' AND (ISNULL(prod_order_cop_mng) OR prod_order_cop_mng=0 OR pp_cop_value=0)", decimalSQL(TETotal.EditValue.ToString), decimalSQL(TEKursMan.EditValue.ToString), decimalSQL((TEUnitPrice.EditValue + TEAddCost.EditValue).ToString), id_design, decimalSQL(TEAddCost.EditValue.ToString), SLECurrentBOM.EditValue.ToString, decimalSQL(TEKursCurrent.EditValue.ToString), decimalSQL((TECOPCurrent.EditValue + TEAddCost.EditValue).ToString), decimalSQL(TEKursMan.EditValue.ToString), decimalSQL((TECOPMan.EditValue + TEAddCost.EditValue).ToString))
                        execute_non_query(query, True, "", "", "", "")
                        '
                        infoCustom("Final COP updated.")
                        load_form()
                    End If
                End If
            Else 'pre final
                If TECOPCurrent.EditValue = 0 Or TECOPMan.EditValue = 0 Then
                    stopCustom("Please fill management & current rate.")
                Else
                    Dim query As String = String.Format("UPDATE tb_m_design SET prod_order_cop_total_man='{0}',prod_order_cop_qty='{1}',prod_order_cop_last_upd=NOW(),prod_order_cop_kurs_mng='{2}',prod_order_cop_mng='{3}',prod_order_cop_mng_addcost='{7}',cop_pre_percent_bea_masuk='{5}',cop_pre_remark='{6}',id_cop_status='1',`pp_cop_rate_cat`='{8}',`pp_cop_kurs`='{9}',`pp_cop_value`='{10}',`pp_cop_mng_kurs`='{11}',`pp_cop_mng_value`='{12}',pp_is_approve=2 WHERE id_design='{4}'", decimalSQL(TETotal.EditValue.ToString), decimalSQL(TEQty.EditValue.ToString), decimalSQL(TEKursMan.EditValue.ToString), decimalSQL((TEUnitPrice.EditValue + TEAddCost.EditValue).ToString), id_design, decimalSQL(TEPercentBeamasuk.EditValue.ToString), addSlashes(MERemark.Text), decimalSQL(TEAddCost.EditValue.ToString), SLECurrentBOM.EditValue.ToString, decimalSQL(TEKursCurrent.EditValue.ToString), decimalSQL((TECOPCurrent.EditValue + TEAddCost.EditValue).ToString), decimalSQL(TEKursMan.EditValue.ToString), decimalSQL((TECOPMan.EditValue + TEAddCost.EditValue).ToString))
                    execute_non_query(query, True, "", "", "", "")
                    infoCustom("Pre Final COP updated.")
                    load_form()
                End If
            End If
        Else
            stopCustom("Please select design first.")
            Close()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub FormProductionCOP_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        view_list_prod(id_design)
        view_list_cost(id_design)
        '
        If XTCCOP.SelectedTabPageIndex = 1 Then
            calculate_cost_management()
            calculate_man()
        ElseIf XTCCOP.SelectedTabPageIndex = 2 Then
            calculate_cost_bom()
            calculate()
        ElseIf XTCCOP.SelectedTabPageIndex = 3 Then
            calculate_cost_pd()
            calculate_pd()
        End If
    End Sub

    Sub calculate_cost_bom()
        If GVCostBOM.RowCount > 0 Then
            Dim kurs As Decimal = TEKursBom.EditValue
            Dim actual_price As Decimal = 0
            Dim price As Decimal = 0
            Dim qty As Decimal = 0
            Dim total As Decimal = 0
            For i As Integer = 0 To (GVCostBOM.RowCount - 1 - GetGroupRowCount(GVCostBOM))
                If GVCostBOM.GetRowCellValue(i, "id_category").ToString = "2" And Not GVCostBOM.GetRowCellValue(i, "id_currency").ToString = "1" Then
                    actual_price = GVCostBOM.GetRowCellValue(i, "actual_price")
                    price = kurs * actual_price
                    GVCostBOM.SetRowCellValue(i, "price", price)
                    '
                    qty = GVCostMan.GetRowCellValue(i, "qty")
                    total = qty * price
                    GVCostBOM.SetRowCellValue(i, "total_price", total)
                End If
            Next
        End If
    End Sub
    Sub calculate_cost_pd()
        If GVCostBOM.RowCount > 0 Then
            Dim kurs As Decimal = TEKursPD.EditValue
            Dim actual_price As Decimal = 0
            Dim price As Decimal = 0
            Dim qty As Decimal = 0
            Dim total As Decimal = 0
            For i As Integer = 0 To (GVCostPD.RowCount - 1 - GetGroupRowCount(GVCostPD))
                If GVCostPD.GetRowCellValue(i, "id_category").ToString = "2" And Not GVCostPD.GetRowCellValue(i, "id_currency").ToString = "1" Then
                    actual_price = GVCostPD.GetRowCellValue(i, "actual_price")
                    price = kurs * actual_price
                    GVCostPD.SetRowCellValue(i, "price", price)
                    '
                    qty = GVCostPD.GetRowCellValue(i, "qty")
                    total = qty * price
                    GVCostPD.SetRowCellValue(i, "total_price", total)
                End If
            Next
        End If
    End Sub
    Sub calculate_cost_management()
        If LEStatus.EditValue.ToString = "1" Then
            LRemark.Visible = True
            TEUnitPrice.Enabled = False
            MERemark.Visible = True
        Else
            LRemark.Visible = False
            TEUnitPrice.Enabled = True
            MERemark.Visible = False
        End If
    End Sub

    Sub view_status(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_cop_status,cop_status FROM tb_lookup_cop_status ORDER BY id_cop_status ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "cop_status"
        lookup.Properties.ValueMember = "id_cop_status"
        lookup.EditValue = data.Rows(0)("id_cop_status").ToString
    End Sub

    Private Sub BPrintCOPMan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrintCOPMan.Click
        ReportProdCOP.id_design = id_design

        Dim Report As New ReportProdCOP()
        Report.kursx = TEKursMan.EditValue
        Report.LTitle.Text = "COST OF PRODUCTION"
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BPrintCOPBOM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrintCOPBOM.Click
        ReportProdCOP.id_design = id_design

        Dim Report As New ReportProdCOP()
        Report.kursx = TEKursBom.EditValue
        Report.LTitle.Text = "COST OF PRODUCTION (KURS BOM)"
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BprintCOPPD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BprintCOPPD.Click
        ReportProdCOP.id_design = id_design

        Dim Report As New ReportProdCOP()
        Report.kursx = TEKursPD.EditValue
        Report.LTitle.Text = "COST OF PRODUCTION (KURS PRODUCTION DEMAND)"
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub


    Private Sub GVCostMan_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVCostMan.PopupMenuShowing
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
        If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
            view.FocusedRowHandle = hitInfo.RowHandle
            ViewMenu.Show(view.GridControl, e.Point)
        End If
    End Sub

    Private Sub SMEditCost_Click(sender As Object, e As EventArgs) Handles SMEditCost.Click
        If is_approve = "1" Then
            warningCustom("This COP already locked")
        Else
            If GVCostMan.RowCount > 0 Then
                If GVCostMan.GetFocusedRowCellValue("id_category").ToString = "2" Then
                    FormProductionCOPDet.id_wo = GVCostMan.GetFocusedRowCellValue("id_report").ToString
                    FormProductionCOPDet.ShowDialog()
                End If
            End If
        End If
    End Sub

    Private Sub LEStatus_EditValueChanged(sender As Object, e As EventArgs) Handles LEStatus.EditValueChanged
        load_form()
    End Sub


    Private Sub ViewLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewLogToolStripMenuItem.Click
        If GVCostMan.RowCount > 0 Then
            If GVCostMan.GetFocusedRowCellValue("id_category").ToString = "2" Then
                FormProductionCOPOVHLog.id_wo = GVCostMan.GetFocusedRowCellValue("id_report").ToString
                FormProductionCOPOVHLog.ShowDialog()
            End If
        End If
    End Sub

    Private Sub BKursMan_Click(sender As Object, e As EventArgs) Handles BKursMan.Click
        If is_approve = "1" Then
            warningCustom("This COP already locked")
        Else
            TEKursMan.EditValue = get_setup_field("rate_management")
            '
            Dim kurs As Decimal = TEKursMan.EditValue
            Dim actual_price As Decimal = 0
            Dim price As Decimal = 0
            Dim qty As Decimal = 0
            Dim total As Decimal = 0
            For i As Integer = 0 To (GVCostMan.RowCount - 1 - GetGroupRowCount(GVCostMan))
                If Not GVCostMan.GetRowCellValue(i, "id_currency").ToString = "1" Then
                    actual_price = GVCostMan.GetRowCellValue(i, "actual_price")
                    price = kurs * actual_price
                Else
                    price = GVCostMan.GetRowCellValue(i, "actual_price")
                End If

                If GVCostMan.GetRowCellValue(i, "id_category").ToString = "3" Then
                    qty = GVCostMan.GetRowCellValue(i, "qty")
                    total = total - (qty * price)
                Else
                    qty = GVCostMan.GetRowCellValue(i, "qty")
                    total += qty * price
                End If
            Next
            '
            If TEQty.EditValue = 0 Or total = 0 Then
                TECOPMan.EditValue = 0
            Else
                TECOPMan.EditValue = total / TEQty.EditValue
            End If
        End If
    End Sub

    Private Sub BKursCurrent_Click(sender As Object, e As EventArgs) Handles BKursCurrent.Click
        If is_approve = "1" Then
            warningCustom("This COP already locked")
        Else
            If SLECurrentBOM.EditValue.ToString = "1" Then
                'BOM
                'TEKursCurrent.EditValue = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_kurs_bom").ToString
                Dim query As String = "SELECT bomd.kurs FROM tb_bom_det bomd
INNER JOIN tb_bom bom ON bom.`id_bom`=bomd.`id_bom` AND bomd.is_ovh_main=1 AND bom.`is_default`=1
INNER JOIN tb_m_product prd ON prd.`id_product`=bom.`id_product`
WHERE prd.`id_design`='" & id_design & "'
GROUP BY prd.`id_design`"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    TEKursCurrent.EditValue = data.Rows(0)("kurs")
                Else
                    TEKursCurrent.EditValue = 1
                End If
            Else
                'Payment to do
                If LEStatus.EditValue.ToString = "2" Then
                    Dim query As String = "SELECT pp_cop_kurs FROM tb_m_design
WHERE `id_design`='" & id_design & "' "
                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If data.Rows.Count > 0 Then
                        TEKursCurrent.EditValue = data.Rows(0)("pp_cop_kurs")
                    Else
                        TEKursCurrent.EditValue = 1
                    End If
                End If
            End If
            '
            Dim kurs As Decimal = TEKursCurrent.EditValue
            Dim actual_price As Decimal = 0
            Dim price As Decimal = 0
            Dim qty As Decimal = 0
            Dim total As Decimal = 0
            For i As Integer = 0 To (GVCostMan.RowCount - 1 - GetGroupRowCount(GVCostMan))
                If Not GVCostMan.GetRowCellValue(i, "id_currency").ToString = "1" Then
                    actual_price = GVCostMan.GetRowCellValue(i, "actual_price")
                    price = kurs * actual_price
                Else
                    price = GVCostMan.GetRowCellValue(i, "actual_price")
                End If

                If GVCostMan.GetRowCellValue(i, "id_category").ToString = "3" Then
                    qty = GVCostMan.GetRowCellValue(i, "qty")
                    total = total - (qty * price)
                Else
                    qty = GVCostMan.GetRowCellValue(i, "qty")
                    total += qty * price
                End If
            Next
            '
            If TEQty.EditValue = 0 Or total = 0 Then
                TECOPCurrent.EditValue = 0
                TEUnitPrice.EditValue = 0
            Else
                TECOPCurrent.EditValue = total / TEQty.EditValue
                TEUnitPrice.EditValue = total / TEQty.EditValue
            End If
        End If
    End Sub

    Private Sub SLECurrentBOM_EditValueChanged(sender As Object, e As EventArgs) Handles SLECurrentBOM.EditValueChanged
        If SLECurrentBOM.EditValue = 1 Then
            TEKursCurrent.Enabled = False
        Else
            TEKursCurrent.Enabled = True
        End If
    End Sub

    Private Sub BApprove_Click(sender As Object, e As EventArgs) Handles BApprove.Click
        Dim query_cek As String = "SELECT * FROM tb_m_design WHERE id_design='" & id_design & "'"
        Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
        '
        If Not id_role_login = get_opt_prod_field("id_role_prod_manager") Then
            stopCustom("You have no right to do this.")
        ElseIf TECOPCurrent.EditValue = 0 Or TECOPMan.EditValue = 0 Then
            stopCustom("Please complete COP by rate")
        ElseIf TEUnitPrice.EditValue = 0 Then
            stopCustom("Please fill COP unit price.")
        ElseIf LEStatus.EditValue.ToString = "1" And data_cek.Rows(0)("pp_cop_value") <= 0 Then
            stopCustom("Please get all value then press update COP first.")
        ElseIf LEStatus.EditValue.ToString = "2" And data_cek.Rows(0)("final_cop_value") <= 0 Then
            stopCustom("Please get all value then press update COP first.")
        Else
            If LEStatus.EditValue.ToString = "1" Then
                'prefinal
                Dim query As String = "UPDATE tb_m_design SET pp_is_approve='1',pp_is_approve_date=NOW(),pp_approve_by='" & id_user & "' WHERE id_design='" & id_design & "'"
                execute_non_query(query, True, "", "", "", "")
                '
                Try
                    Dim nm As New ClassSendEmail
                    nm.par1 = id_design
                    nm.report_mark_type = "186"
                    nm.send_email()
                Catch ex As Exception
                    execute_query("INSERT INTO tb_error_mail(date,description) VALUES(NOW(),'Failed send Pre final COP id_design = " & id_design & "')", -1, True, "", "", "", "")
                End Try
            Else
                'final
                Dim query As String = "UPDATE tb_m_design SET id_cop_status=2,pp_is_approve='1',pp_is_approve_date=NOW(),pp_approve_by='" & id_user & "',final_is_approve='1',final_is_approve_date=NOW(),final_approve_by='" & id_user & "' WHERE id_design='" & id_design & "'"
                execute_non_query(query, True, "", "", "", "")
                '
                Try
                    Dim nm As New ClassSendEmail
                    nm.par1 = id_design
                    nm.report_mark_type = "185"
                    nm.send_email()
                Catch ex As Exception
                    execute_query("INSERT INTO tb_error_mail(date,description) VALUES(NOW(),'Failed send Final COP id_design = " & id_design & "')", -1, True, "", "", "", "")
                End Try
            End If
            load_form()
        End If
    End Sub

    Private Sub TEUnitPrice_EditValueChanged(sender As Object, e As EventArgs) Handles TEUnitPrice.EditValueChanged
        TECOPCurrent.EditValue = TEUnitPrice.EditValue
    End Sub
End Class