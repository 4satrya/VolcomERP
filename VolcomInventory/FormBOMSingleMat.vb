Public Class FormBOMSingleMat
    Public id_bom As String = "-1"
    Public id_bom_det As String = "-1"

    Public id_pop_up As String = "-1"
    Public id_mat_det As String = "-1"

    Private Sub FormBOMSingleMat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TEQty.EditValue = 0.0
        TEKurs.EditValue = 0.0

        view_currency(LECurrency)
        'LECurrency.EditValue = Nothing
        'LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", get_id_currency(id_bom))
        If id_pop_up = "-1" Then
            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", FormBOMSingle.LECurrency.EditValue.ToString)
            LabelBOMName.Text = FormBOMSingle.LabelPrintedName.Text
        ElseIf id_pop_up = "1" Then 'per PD
            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", FormBOMDesignSingle.LECurrency.EditValue.ToString)
            LabelBOMName.Text = FormBOMDesignSingle.LabelPrintedName.Text
        ElseIf id_pop_up = "2" Then 'per design
            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", FormBOMSingle.LECurrency.EditValue.ToString)
            LabelBOMName.Text = FormBOMSingle.LabelPrintedName.Text
        End If


        view_mat()

        If id_pop_up = "-1" Then
            If id_bom_det <> "-1" Then
                '
                Dim id_mat_det As String
                id_mat_det = get_id_mat_det(id_bom_det)
                GVMat.FocusedRowHandle = find_row(GVMat, "id_mat_det", id_mat_det)
                TEQty.EditValue = FormBOMSingle.GVBomDetMat.GetFocusedRowCellValue("qty")
                TEKurs.EditValue = FormBOMSingle.GVBomDetMat.GetFocusedRowCellValue("kurs")
                If FormBOMSingle.GVBomDetMat.GetFocusedRowCellValue("is_cost").ToString = "1" Then
                    CECOP.Checked = True
                Else
                    CECOP.Checked = False
                End If
                If FormBOMSingle.GVBomDetMat.GetFocusedRowCellValue("is_addcost").ToString = "1" Then
                    CEAddCost.Checked = True
                Else
                    CEAddCost.Checked = False
                End If
                '
            Else
                TEKurs.EditValue = FormBOMSingle.TEKurs.EditValue
            End If
        ElseIf id_pop_up = "1" Then 'per PD
            If id_mat_det <> "-1" Then
                '
                GVMat.FocusedRowHandle = find_row(GVMat, "id_mat_det", id_mat_det)
                TEQty.EditValue = FormBOMDesignSingle.GVBomDetMat.GetFocusedRowCellValue("qty")
                TEKurs.EditValue = FormBOMDesignSingle.GVBomDetMat.GetFocusedRowCellValue("kurs")
                If FormBOMDesignSingle.GVBomDetMat.GetFocusedRowCellValue("is_cost").ToString = "1" Then
                    CECOP.Checked = True
                Else
                    CECOP.Checked = False
                End If
                If FormBOMDesignSingle.GVBomDetMat.GetFocusedRowCellValue("is_addcost").ToString = "1" Then
                    CEAddCost.Checked = True
                Else
                    CEAddCost.Checked = False
                End If
                '
            Else
                TEKurs.EditValue = FormBOMDesignSingle.TEKurs.EditValue
            End If
        ElseIf id_pop_up = "2" Then 'per Design
            If id_bom_det <> "-1" Then
                id_mat_det = get_id_mat_det(id_bom_det)
                GVMat.FocusedRowHandle = find_row(GVMat, "id_mat_det", id_mat_det)
                TEQty.EditValue = FormBOMSingle.GVBomDetMat.GetFocusedRowCellValue("qty")
                TEKurs.EditValue = FormBOMSingle.GVBomDetMat.GetFocusedRowCellValue("kurs")
                If FormBOMSingle.GVBomDetMat.GetFocusedRowCellValue("is_cost").ToString = "1" Then
                    CECOP.Checked = True
                Else
                    CECOP.Checked = False
                End If
                If FormBOMSingle.GVBomDetMat.GetFocusedRowCellValue("is_addcost").ToString = "1" Then
                    CEAddCost.Checked = True
                Else
                    CEAddCost.Checked = False
                End If
            Else
                TEKurs.EditValue = FormBOMSingle.TEKurs.EditValue
            End If
        End If
        load_mat_price()

    End Sub

    Sub view_mat()
        Try
            Dim query As String
            query = "CALL view_mat()"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMat.DataSource = data
            '
            If Not data.Rows.Count < 1 Then
                view_mat_price(GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Sub view_mat_price(ByVal id_mat_detx As String)
        Dim query As String = "CALL view_mat_det_price_cost(" & id_mat_detx & ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatPrice.DataSource = data

        'If id_pop_up = "-1" Then
        '    If id_bom_det <> "-1" Then
        '        '
        '        query = String.Format("SELECT * FROM tb_bom_det WHERE id_bom_det = '{0}'", id_bom_det)
        '        data = execute_query(query, -1, True, "", "", "", "")

        '        GVMatPrice.FocusedRowHandle = find_row(GVMatPrice, "id_mat_det_price", data.Rows(0)("id_mat_det_price").ToString)
        '        load_mat_price()

        '        TEKurs.EditValue = FormBOMSingle.TEKurs.EditValue
        '        TEPrice.EditValue = data.Rows(0)("bom_price")
        '        TEQty.EditValue = data.Rows(0)("component_qty")
        '        '
        '    Else
        '        If Not data.Rows.Count < 1 Then
        '            load_mat_price()
        '        End If
        '    End If
        'ElseIf id_pop_up = "1" Then 'design single
        '    If id_mat_det = "-1" Then
        '        load_mat_price()
        '    Else
        '        TEKurs.EditValue = FormBOMDesignSingle.TEKurs.EditValue
        '        load_mat_price()
        '        TEQty.EditValue = FormBOMDesignSingle.GVBomDetMat.GetFocusedRowCellValue("id_mat_det")
        '    End If
        'End If
    End Sub
    Sub load_mat_price()
        TEVendCur.Text = GVMatPrice.GetFocusedRowCellDisplayText("currency").ToString
        TEVendPrice.EditValue = GVMatPrice.GetFocusedRowCellValue("mat_det_price")
        TEUOM.Text = GVMat.GetFocusedRowCellDisplayText("uom").ToString

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

    Private Sub FormBOMSingleMat_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVMat_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMat.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
        If Not GVMat.RowCount < 1 Then
            view_mat_price(GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
            load_mat_price()
        End If
    End Sub

    Private Sub GVMatPrice_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVMatPrice.RowClick
        load_mat_price()
    End Sub

    Private Sub GVMat_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVMat.RowClick
        view_mat_price(GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
    End Sub

    Private Sub TEKurs_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEKurs.EditValueChanged
        calculate()
    End Sub

    Private Sub TEQty_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEQty.EditValueChanged
        calculate()
    End Sub
    Sub calculate()
        'Try
        'Dim price_kurs, price_tot As Decimal

        Dim price_tot As Decimal

        'If TEVendPrice.Text = "" Or TEKurs.Text = "" Then
        '    TEPrice.Text = "0"
        'Else
        '    price_kurs = Decimal.Parse(TEVendPrice.Text) * Decimal.Parse(TEKurs.Text)
        '    TEPrice.Text = price_kurs.ToString("0.00")
        'End If
        TEPrice.EditValue = TEVendPrice.EditValue
        If TEPrice.EditValue = 0 Or TEQty.EditValue = 0 Then
            TEPriceTot.EditValue = 0
        Else
            price_tot = TEPrice.EditValue * TEQty.EditValue
            TEPriceTot.EditValue = price_tot
        End If
        'Catch ex As Exception
        'End Try
    End Sub
    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim id_component_category, id_component_price, error_text, query As String

        Dim kurs, bom_price, component_qty As Decimal

        id_component_category = "1"
        error_text = "-1"
        '
        id_component_price = "0"
        kurs = "0"
        bom_price = "0"
        component_qty = "0"
        '
        Try
            id_component_price = GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString
            kurs = TEKurs.EditValue
            bom_price = TEPrice.EditValue
            component_qty = TEQty.EditValue
        Catch ex As Exception
            error_text = "1"
        End Try

        If error_text <> "-1" Then
            'ada error
            errorInput()
        ElseIf Not GVMatPrice.RowCount > 0 Then
            stopCustom("Please choose material with proper price.")
        ElseIf Not TEQty.EditValue > 0 Then
            stopCustom("Please insert qty of material.")
        Else
            Dim is_cop, is_addcost As Integer
            If CECOP.Checked = True Then
                is_cop = "1"
            Else
                is_cop = "2"
            End If

            If CEAddCost.Checked = True Then
                is_addcost = "1"
            Else
                is_addcost = "2"
            End If

            If id_pop_up = "-1" Then
                If id_bom_det <> "-1" Then
                    'edit
                    Dim query_jml As String = String.Format("SELECT COUNT(id_bom_det) FROM tb_bom_det WHERE id_mat_det_price='{0}' AND id_bom='{1}' AND id_bom_det !='{2}'", id_component_price, id_bom, id_bom_det)
                    Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                    If Not jml < 1 Then
                        errorDuplicate(" Material.")
                    Else
                        query = String.Format("UPDATE tb_bom_det SET id_mat_det_price='{0}',kurs='{1}',bom_price='{2}',component_qty='{3}',is_cost='{5}',kurs='{6}',is_addcost='{7}' WHERE id_bom_det='{4}'", id_component_price, decimalSQL(kurs.ToString), decimalSQL(bom_price.ToString), decimalSQL(component_qty.ToString), id_bom_det, is_cop, decimalSQL(kurs.ToString), is_addcost)
                        execute_non_query(query, True, "", "", "", "")
                        'update who
                        query = String.Format("UPDATE tb_bom SET id_user_last_update='{0}',bom_date_updated=NOW() WHERE id_bom='{1}'", id_user, id_bom)
                        execute_non_query(query, True, "", "", "", "")
                        '
                        FormBOMSingle.view_bom_det(id_bom)
                        Close()
                    End If
                Else
                    'insert
                    Dim query_jml As String = String.Format("SELECT COUNT(id_bom_det) FROM tb_bom_det WHERE id_mat_det_price='{0}' AND id_bom='{1}'", id_component_price, id_bom)
                    Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                    If Not jml < 1 Then
                        errorDuplicate(" Material.")
                    Else
                        query = String.Format("INSERT INTO tb_bom_det(id_bom,id_mat_det_price,kurs,bom_price,component_qty,id_component_category,is_cost,is_addcost,kurs) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", id_bom, id_component_price, decimalSQL(kurs.ToString), decimalSQL(bom_price.ToString), decimalSQL(component_qty.ToString), id_component_category, is_cop, is_addcost, decimalSQL(kurs.ToString))
                        execute_non_query(query, True, "", "", "", "")
                        'update who
                        query = String.Format("UPDATE tb_bom SET id_user_last_update='{0}',bom_date_updated=NOW() WHERE id_bom='{1}'", id_user, id_bom)
                        execute_non_query(query, True, "", "", "", "")
                        '
                        FormBOMSingle.view_bom_det(id_bom)
                        Close()
                    End If
                End If
            ElseIf id_pop_up = "1" Then 'per PD
                If id_mat_det <> "-1" Then
                    'edit
                    Dim dupe As String = "1"
                    For i As Integer = 0 To FormBOMDesignSingle.GVBomDetMat.RowCount - 1
                        If Not FormBOMDesignSingle.GVBomDetMat.GetRowCellValue(i, "id_component").ToString = id_mat_det Then
                            If FormBOMDesignSingle.GVBomDetMat.GetRowCellValue(i, "id_component").ToString = GVMat.GetFocusedRowCellValue("id_mat_det").ToString Then
                                dupe = "2"
                                Exit For
                            End If
                        End If
                    Next

                    If dupe = "2" Then
                        stopCustom("Material already on list.")
                    Else
                        'edit
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("id_component", GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("id_component_price", GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("code", GVMat.GetFocusedRowCellDisplayText("mat_det_code").ToString)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("name", GVMat.GetFocusedRowCellDisplayText("mat_det_name").ToString)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("size", GVMat.GetFocusedRowCellDisplayText("size").ToString)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("color", GVMat.GetFocusedRowCellDisplayText("color").ToString)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("qty", TEQty.EditValue)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("kurs", TEKurs.EditValue)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("uom", GVMat.GetFocusedRowCellDisplayText("uom").ToString)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("price", GVMatPrice.GetFocusedRowCellDisplayText("mat_det_price"))
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("total", GVMatPrice.GetFocusedRowCellDisplayText("mat_det_price") * TEQty.EditValue)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("is_cost", is_cop)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("is_addcost", is_addcost)
                        FormBOMDesignSingle.GCBomDetMat.RefreshDataSource()
                        FormBOMDesignSingle.GVBomDetMat.RefreshData()
                        FormBOMDesignSingle.calculate_unit_price()
                        Close()
                    End If
                Else
                    'insert
                    Dim dupe As String = "1"
                    For i As Integer = 0 To FormBOMDesignSingle.GVBomDetMat.RowCount - 1
                        If FormBOMDesignSingle.GVBomDetMat.GetRowCellValue(i, "id_component").ToString = GVMat.GetFocusedRowCellValue("id_mat_det").ToString Then
                            dupe = "2"
                            Exit For
                        End If
                    Next
                    If dupe = "2" Then
                        stopCustom("Material already on list.")
                    Else
                        'insert
                        FormBOMDesignSingle.GVBomDetMat.AddNewRow()
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("id_component", GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("id_component_price", GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("code", GVMat.GetFocusedRowCellDisplayText("mat_det_code").ToString)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("name", GVMat.GetFocusedRowCellDisplayText("mat_det_name").ToString)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("size", GVMat.GetFocusedRowCellDisplayText("size").ToString)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("color", GVMat.GetFocusedRowCellDisplayText("color").ToString)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("qty", TEQty.EditValue)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("kurs", TEKurs.EditValue)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("uom", GVMat.GetFocusedRowCellDisplayText("uom").ToString)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("price", GVMatPrice.GetFocusedRowCellDisplayText("mat_det_price"))
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("is_cost", is_cop)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("is_addcost", is_addcost)
                        FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("total", GVMatPrice.GetFocusedRowCellDisplayText("mat_det_price") * TEQty.EditValue)
                        FormBOMDesignSingle.GVBomDetMat.CloseEditor()
                        FormBOMDesignSingle.GCBomDetMat.RefreshDataSource()
                        FormBOMDesignSingle.GVBomDetMat.RefreshData()
                        FormBOMDesignSingle.show_but_mat()
                        FormBOMDesignSingle.calculate_unit_price()
                        Close()
                    End If
                End If
            ElseIf id_pop_up = "2" Then 'per design
                If id_mat_det <> "-1" Then
                    'edit
                    Dim query_jml As String = String.Format("SELECT COUNT(id_bom_det) FROM tb_bom_det WHERE id_mat_det_price='{0}' AND id_bom='{1}' AND id_bom_det !='{2}'", id_component_price, id_bom, id_bom_det)
                    Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")

                    If Not jml < 1 Then
                        errorDuplicate(" Material.")
                    Else
                        query = String.Format("UPDATE tb_bom_det bom_d " +
                        "inner join tb_bom bom ON bom.id_bom=bom_d.id_bom " +
                        "inner join tb_m_mat_det_price mdp ON mdp.id_mat_det_price=bom_d.id_mat_det_price " +
                        "SET bom_d.id_mat_det_price='{0}',bom_d.kurs='{1}',bom_d.bom_price='{2}',bom_d.component_qty='{3}',bom_d.is_cost='{4}',bom_d.is_addcost='{7}' " +
                        "WHERE mdp.id_mat_det='{5}' and bom.id_bom_approve='{6}'", id_component_price, decimalSQL(kurs.ToString), decimalSQL(bom_price.ToString), decimalSQL(component_qty.ToString), is_cop, id_mat_det, FormBOMSingle.id_bom_approve, is_addcost)
                        execute_non_query(query, True, "", "", "", "")
                        'update who
                        query = String.Format("UPDATE tb_bom SET id_user_last_update='{0}',bom_date_updated=NOW() WHERE id_bom_approve='{1}'", id_user, FormBOMSingle.id_bom_approve)
                        execute_non_query(query, True, "", "", "", "")
                        'update ecop
                        query = String.Format("CALL update_bom_tot_app('{0}')", FormBOMSingle.id_bom_approve)
                        execute_non_query(query, True, "", "", "", "")
                        '
                        FormBOMSingle.act_load()
                        Close()
                    End If
                Else
                    'insert
                    Dim query_jml As String = String.Format("SELECT COUNT(id_bom_det) FROM tb_bom_det WHERE id_mat_det_price='{0}' AND id_bom='{1}'", id_component_price, id_bom)
                    Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                    If Not jml < 1 Then
                        errorDuplicate(" Material.")
                    Else
                        'insert
                        query = "INSERT INTO tb_bom_det(id_bom,id_component_category, id_mat_det_price,kurs, bom_price, component_qty, is_cost,is_addcost,is_ovh_main)"
                        query += " Select id_bom,'" + id_component_category + "' As id_component_category,"
                        query += "'" + id_component_price + "' As id_mat_det_price,"
                        query += "'" + decimalSQL(kurs.ToString) + "' AS kurs,"
                        query += "'" + decimalSQL(bom_price.ToString) + "' As bom_price,"
                        query += "'" + decimalSQL(component_qty.ToString) + "' As component_qty,"
                        query += "'" + is_cop.ToString + "' As is_cost,"
                        query += "'" + is_addcost.ToString + "' As is_addcost,"
                        query += " 2 As is_ovh_main"
                        query += " FROM tb_bom WHERE id_bom_approve='" + FormBOMSingle.id_bom_approve + "'"
                        execute_non_query(query, True, "", "", "", "")
                        'update who
                        query = String.Format("UPDATE tb_bom SET id_user_last_update='{0}',bom_date_updated=NOW() WHERE id_bom_approve='{1}'", id_user, FormBOMSingle.id_bom_approve)
                        execute_non_query(query, True, "", "", "", "")
                        'update ecop
                        query = String.Format("CALL update_bom_tot_app('{0}')", FormBOMSingle.id_bom_approve)
                        execute_non_query(query, True, "", "", "", "")
                        '
                        FormBOMSingle.act_load()
                        Close()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GVMatPrice_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatPrice.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
        load_mat_price()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub GVMat_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVMat.ColumnFilterChanged
        If Not GVMat.RowCount < 1 Then
            view_mat_price(GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
            load_mat_price()
        End If
    End Sub
End Class