Public Class FormProductionCOP 
    'Public id_prod_order As String = "-1"
    'update to id_design 
    Public id_design As String = "-1"
    Public is_view As String = "2"
    Public is_final As String = "1"

    Private Sub FormProductionCOP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
        'show prod order detail
        view_status(LEStatus)

        If Not id_design = "-1" Then
            Dim query As String = String.Format("SELECT rate_management,prod_order_cop_kurs_mng,prod_order_cop_mng,prod_order_cop_mng_addcost,design_name,design_display_name,design_code,id_cop_status,cop_pre_percent_bea_masuk,cop_pre_remark,design_cop_addcost FROM tb_m_design WHERE id_design = '{0}'", id_design)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            TEDesign.Text = data.Rows(0)("design_display_name").ToString
            TEDesignCode.Text = data.Rows(0)("design_code").ToString
            LEStatus.EditValue = data.Rows(0)("id_cop_status").ToString
            TEKursMan.EditValue = data.Rows(0)("prod_order_cop_kurs_mng")
            '
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
                TEUnitPrice.EditValue = True
                TEAddCost.Properties.ReadOnly = True
                TEUnitCostBOM.EditValue = True
                TEUnitCostPD.EditValue = True
                '
                TEUnitPrice.EditValue = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("design_cop") - data.Rows(0)("design_cop_addcost")
                TEAddCost.EditValue = data.Rows(0)("design_cop_addcost")
            Else
                TEUnitPrice.Properties.ReadOnly = False
                TEAddCost.Properties.ReadOnly = False
                TEUnitCostBOM.Properties.ReadOnly = False
                TEUnitCostPD.Properties.ReadOnly = False
                '
                TEUnitPrice.EditValue = data.Rows(0)("prod_order_cop_mng").ToString - data.Rows(0)("prod_order_cop_mng_addcost")
                TEAddCost.EditValue = data.Rows(0)("prod_order_cop_mng_addcost")
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
            BRefresh.Visible = False
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
        Dim query = "CALL view_cop_design('" & id_designx & "')"
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
            qty = GVListProd.Columns("receive_created_qty").SummaryItem.SummaryValue
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
        TEAddCostActual.EditValue = addcost
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
                If id_role_login = get_opt_prod_field("id_role_prod_manager") Then
                    Dim confirm As DialogResult
                    confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to finalize this COP ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        'Dim query As String = String.Format("UPDATE tb_m_design SET prod_order_cop_total_man='{0}',prod_order_cop_total_bom='{1}',prod_order_cop_total_pd='{2}',prod_order_cop_qty='{3}',prod_order_cop_last_upd=NOW(),prod_order_cop_kurs_mng='{4}',prod_order_cop_kurs_bom='{5}',prod_order_cop_kurs_pd='{6}',prod_order_cop_mng='{8}',prod_order_cop_bom='{9}',prod_order_cop_pd='{10}', design_cop='{11}', id_cop_status='2' WHERE id_design='{7}'", decimalSQL(TETotal.EditValue.ToString), decimalSQL(TETotalBOM.EditValue.ToString), decimalSQL(TETotalCostPD.EditValue.ToString), decimalSQL(TEQty.EditValue.ToString), decimalSQL(TEKursMan.EditValue.ToString), decimalSQL(TEKursBom.EditValue.ToString), decimalSQL(TEKursPD.EditValue.ToString), id_design, decimalSQL(TEUnitPrice.EditValue.ToString), decimalSQL(TEUnitCostBOM.EditValue.ToString), decimalSQL(TEUnitCostPD.EditValue.ToString), decimalSQL(TEUnitCostBOM.EditValue.ToString))
                        'execute_non_query(query, True, "", "", "", "")
                        'final COP
                        Dim query As String = String.Format("UPDATE tb_m_design SET prod_order_cop_qty='{0}',prod_order_cop_last_upd=NOW(), design_cop='{1}',design_cop_addcost='{3}', id_cop_status='2' WHERE id_design='{2}'", decimalSQL(TEQty.EditValue.ToString), decimalSQL((TEUnitPrice.EditValue + TEAddCost.EditValue).ToString), id_design, decimalSQL(TEAddCost.EditValue.ToString))
                        execute_non_query(query, True, "", "", "", "")
                        'add pre final juga jika kosong
                        query = String.Format("UPDATE tb_m_design SET prod_order_cop_total_man='{0}',prod_order_cop_kurs_mng='{1}',prod_order_cop_mng='{2}',prod_order_cop_mng_addcost='{4}' WHERE id_design='{3}' AND (ISNULL(prod_order_cop_mng) OR prod_order_cop_mng=0)", decimalSQL(TETotal.EditValue.ToString), decimalSQL(TEKursMan.EditValue.ToString), decimalSQL((TEUnitPrice.EditValue + TEAddCost.EditValue).ToString), id_design, decimalSQL(TEAddCost.EditValue.ToString))
                        execute_non_query(query, True, "", "", "", "")
                        infoCustom("Final COP updated.")
                        Close()
                    End If
                Else
                    stopCustom("You have no right to edit final COP.")
                End If
            Else 'pre final
                Dim query As String = String.Format("UPDATE tb_m_design SET prod_order_cop_total_man='{0}',prod_order_cop_qty='{1}',prod_order_cop_last_upd=NOW(),prod_order_cop_kurs_mng='{2}',prod_order_cop_mng='{3}',prod_order_cop_mng_addcost='{7}',cop_pre_percent_bea_masuk='{5}',cop_pre_remark='{6}',id_cop_status='1' WHERE id_design='{4}'", decimalSQL(TETotal.EditValue.ToString), decimalSQL(TEQty.EditValue.ToString), decimalSQL(TEKursMan.EditValue.ToString), decimalSQL((TEUnitPrice.EditValue + TEAddCost.EditValue).ToString), id_design, decimalSQL(TEPercentBeamasuk.EditValue.ToString), addSlashes(MERemark.Text), decimalSQL(TEAddCost.EditValue.ToString))
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Pre Final COP updated.")
                Close()
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

    Private Sub BRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefresh.Click
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
            LPercentBeaMasuk.Visible = True
            TEPercentBeamasuk.Visible = True
            MERemark.Visible = True
        Else
            LRemark.Visible = False
            LPercentBeaMasuk.Visible = False
            TEPercentBeamasuk.Visible = False
            MERemark.Visible = False
        End If
        '
        If GVCostMan.RowCount > 0 And LEStatus.EditValue.ToString = "1" Then 'pre final
            Dim kurs As Decimal = TEKursMan.EditValue
            Dim actual_price As Decimal = 0
            Dim price As Decimal = 0
            Dim qty As Decimal = 0
            Dim total As Decimal = 0
            For i As Integer = 0 To (GVCostMan.RowCount - 1 - GetGroupRowCount(GVCostMan))
                If GVCostMan.GetRowCellValue(i, "id_category").ToString = "2" And Not GVCostMan.GetRowCellValue(i, "id_currency").ToString = "1" Then
                    actual_price = GVCostMan.GetRowCellValue(i, "actual_price")
                    price = kurs * actual_price
                    GVCostMan.SetRowCellValue(i, "price", price)
                    '
                    qty = GVCostMan.GetRowCellValue(i, "qty")
                    total = qty * price
                    GVCostMan.SetRowCellValue(i, "total_price", total)
                End If
            Next
        Else 'final
        End If
    End Sub

    Private Sub TEKursMan_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEKursMan.KeyUp
        calculate_cost_management()
        calculate_man()
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

    Private Sub BKursMan_Click(sender As Object, e As EventArgs) Handles BKursMan.Click
        TEKursMan.EditValue = get_setup_field("rate_management")
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
        If GVCostMan.RowCount > 0 Then
            If GVCostMan.GetFocusedRowCellValue("id_category").ToString = "2" Then
                FormProductionCOPDet.id_wo = GVCostMan.GetFocusedRowCellValue("id_report").ToString
                FormProductionCOPDet.ShowDialog()
            End If
        End If
    End Sub

    Private Sub LEStatus_EditValueChanged(sender As Object, e As EventArgs) Handles LEStatus.EditValueChanged
        view_list_prod(id_design)
        view_list_cost(id_design)
        '
        calculate_cost_management()
        calculate_cost_bom()
        calculate_cost_pd()
        '
        calculate_man()
        calculate()
        calculate_pd()
    End Sub

    Private Sub BSameCost_Click(sender As Object, e As EventArgs) Handles BSameCost.Click
        TEUnitPrice.EditValue = TEUnitCostActual.EditValue
    End Sub

    Private Sub ViewLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewLogToolStripMenuItem.Click
        If GVCostMan.RowCount > 0 Then
            If GVCostMan.GetFocusedRowCellValue("id_category").ToString = "2" Then
                FormProductionCOPOVHLog.id_wo = GVCostMan.GetFocusedRowCellValue("id_report").ToString
                FormProductionCOPOVHLog.ShowDialog()
            End If
        End If
    End Sub
End Class