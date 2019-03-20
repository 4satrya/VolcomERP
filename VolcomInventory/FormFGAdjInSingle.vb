Public Class FormFGAdjInSingle 
    Public id_pop_up As String
    Public id_comp_from, id_wh, action As String
    Public id_product_edit, id_product_price_edit As String
    Dim id_product_old As String
    Public id_wh_rack_edit, id_wh_locator_edit, id_wh_drawer_edit, adj_x_fg_det_note As String
    Public adj_x_fg_det_qty, adj_x_fg_det_price As Decimal
    Public adj_x_fg_det_kurs As Decimal = 1.0
    Dim ketemu As Boolean = False
    Public indeks_edit As Integer
    Public cond_check As Boolean = True
    Public fg_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal
    Public id_adj_x_fg_det As String
    '--------------------------------

    'Form
    Private Sub FormFGAdjInSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewWHStock()

        If action = "upd" Then
            SLEWH.EditValue = id_wh
            SLELocator.EditValue = id_wh_locator_edit
            SLERack.EditValue = id_wh_rack_edit
            SLEDrawer.EditValue = id_wh_drawer_edit
            TxtCost.EditValue = adj_x_fg_det_price / adj_x_fg_det_kurs
            TxtKurs.EditValue = adj_x_fg_det_kurs
            TxtRealCost.EditValue = adj_x_fg_det_price
            SPQtyPL.EditValue = adj_x_fg_det_qty
            MENote.Text = adj_x_fg_det_note.ToString
            GVFG.FocusedRowHandle = find_row(GVFG, "id_product", id_product_edit)
        ElseIf action = "ins" Then
            TxtKurs.EditValue = 1
        End If
    End Sub
    Private Sub FormFGAdjInSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'View
    Sub viewStock()
        Dim id_product_selected As String = "-1"

        Dim queryx As String = "SELECT id_product FROM tb_m_product WHERE product_full_code='" + addSlashes(TxtDesignCode.Text) + "'"
        Dim datax As DataTable = execute_query(queryx, -1, True, "", "", "", "")
        If datax.Rows.Count = 0 Or TxtDesignCode.Text = "" Then
            stopCustom("Product not found !")
            TxtDesignCode.Focus()
        Else
            id_product_selected = datax.Rows(0)("id_product").ToString.ToUpper
            'Dim query As String = "CALL view_stock_fg(0, 0, 0, 0, '" & id_product_selected & "',1, '9999-01-01')"
            Dim query As String = "CALL view_product_param('" & id_product_selected & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim i As Integer = data.Rows.Count - 1
            GCFG.DataSource = data
            viewImg()
            chooseCondition()
            If action = "ins" Then
                checkExistInput()
            End If
        End If
    End Sub

    Sub viewImg()
        Dim id_dsg As String = "-1"
        Try
            id_dsg = GVFG.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception

        End Try
        pre_viewImages("2", PictureEdit1, id_dsg, False)
    End Sub
    Sub viewWHStock()
        Dim query As String = ""
        'get id category on opt
        query = "SELECT id_comp_cat_wh FROM tb_opt "
        Dim id_comp_cat_wh As String = execute_query(query, 0, True, "", "", "", "")

        'view data comp/warehouse
        query = ""
        query += "SELECT a.id_comp, a.comp_number, CONCAT(a.comp_number,' - ', a.comp_name) AS `comp_name` FROM tb_m_comp a WHERE a.id_comp_cat='5' or a.id_comp_cat='6'"
        'query += "WHERE a.id_comp_cat = '" + id_comp_cat_wh + "' "
        'If id_wh <> "-1" Then
        '    query += "AND a.id_comp = '" + id_wh + "' "
        'End If
        query += "ORDER BY comp_number ASC "
        viewSearchLookupQuery(SLEWH, query, "id_comp", "comp_name", "id_comp")
    End Sub
    Sub viewWHLocatorSLE()
        Dim id_comp As String = ""
        Try
            id_comp = SLEWH.EditValue.ToString
        Catch ex As Exception
            id_comp = "-1"
        End Try
        Dim query As String = ""
        query += "SELECT a.id_comp, a.id_wh_locator, a.wh_locator_code, a.wh_locator, a.wh_locator_description FROM tb_m_wh_locator a WHERE a.id_comp = '" + id_comp + "' "
        viewSearchLookupQuery(SLELocator, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub
    Sub viewWHRack()
        Dim id_locator As String = ""
        Try
            id_locator = SLELocator.EditValue.ToString
        Catch ex As Exception
            id_locator = "-1"
        End Try
        Dim query As String = ""
        query += "SELECT a.id_wh_locator, a.id_wh_rack, a.wh_rack_code, a.wh_rack, a.wh_rack_description FROM tb_m_wh_rack a WHERE a.id_wh_locator = '" + id_locator + "' "
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub
    Sub viewWHDrawer()
        Dim id_rack As String = ""
        Try
            id_rack = SLERack.EditValue.ToString
        Catch ex As Exception
            id_rack = "-1"
        End Try
        Dim query As String = ""
        query += "SELECT a.id_wh_rack, a.id_wh_drawer, a.wh_drawer_code, a.wh_drawer, a.wh_drawer_description FROM tb_m_wh_drawer a WHERE a.id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub

    'Button Actoion
    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Dim qty_input_grid As Decimal = Decimal.Parse(SPQtyPL.EditValue)
        If qty_input_grid > 0 Then
            If action = "ins" Then
                'Edit di Induk insert save langsung ke db
                checkExistInput()
                If Not ketemu Then
                    If id_adj_x_fg_det <> "0" Then
                        If id_pop_up = "1" Then 'edit
                            FormFGAdjInDet.newRows()
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_product", GVFG.GetFocusedRowCellDisplayText("id_product").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("name", GVFG.GetFocusedRowCellDisplayText("name").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("size", GVFG.GetFocusedRowCellValue("size").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("uom", GVFG.GetFocusedRowCellValue("uom").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("code", GVFG.GetFocusedRowCellValue("code").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_qty", qty_input_grid)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_price", TxtRealCost.EditValue)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_amount", TxtAmount.EditValue)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_note", MENote.Text)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_wh_drawer", SLEDrawer.EditValue.ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_wh_rack", SLERack.EditValue.ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_wh_locator", SLELocator.EditValue.ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_comp", SLEWH.EditValue.ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("comp", SLEWH.Properties.GetDisplayText(SLEWH.EditValue))
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("wh_drawer", SLEDrawer.Properties.GetDisplayText(SLEDrawer.EditValue))
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("wh_rack", SLERack.Properties.GetDisplayText(SLERack.EditValue))
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("wh_locator", SLELocator.Properties.GetDisplayText(SLELocator.EditValue))
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("comp_name", SLEWH.Properties.GetDisplayText(SLEWH.EditValue))
                            FormFGAdjInDet.GVDetail.CloseEditor()
                            FormFGAdjInDet.GCDetail.RefreshDataSource()
                            FormFGAdjInDet.GVDetail.RefreshData()
                            'Close()
                        End If
                    Else
                        If id_pop_up = 1 Then 'Ins Standard Adj In
                            FormFGAdjInDet.newRows()
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_adj_in_fg_det", "0")
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_product", GVFG.GetFocusedRowCellDisplayText("id_product").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("name", GVFG.GetFocusedRowCellDisplayText("name").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("size", GVFG.GetFocusedRowCellValue("size").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("uom", GVFG.GetFocusedRowCellValue("uom").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("code", GVFG.GetFocusedRowCellValue("code").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_qty", qty_input_grid)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_price", TxtRealCost.EditValue)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_amount", TxtAmount.EditValue)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_note", MENote.Text)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_wh_drawer", SLEDrawer.EditValue.ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_wh_rack", SLERack.EditValue.ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_wh_locator", SLELocator.EditValue.ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_comp", SLEWH.EditValue.ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("comp", SLEWH.Properties.GetDisplayText(SLEWH.EditValue))
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("wh_drawer", SLEDrawer.Properties.GetDisplayText(SLEDrawer.EditValue))
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("wh_rack", SLERack.Properties.GetDisplayText(SLERack.EditValue))
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("wh_locator", SLELocator.Properties.GetDisplayText(SLELocator.EditValue))
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("comp_name", SLEWH.Properties.GetDisplayText(SLEWH.EditValue))
                            FormFGAdjInDet.GVDetail.CloseEditor()
                            FormFGAdjInDet.GCDetail.RefreshDataSource()
                            FormFGAdjInDet.GVDetail.RefreshData()
                            'Close()
                        End If
                    End If
                Else
                    errorCustom("This material already exist in Adjustment List !")
                End If
            ElseIf action = "upd" Then
                checkExistInput()
                If Not ketemu Then
                    'Edit di Induk update save langsung ke db
                    If id_adj_x_fg_det <> "0" Then
                        If id_pop_up = "1" Then 'Edit DB Adj In
                            'Dim query_upd_return_det As String = "UPDATE tb_adj_in_fg_det SET id_product = '" + GVFG.GetFocusedRowCellValue("id_product").ToString + "',id_adj_in_mat = '" + FormFGAdjInDet.id_adj_in_mat + "',adj_in_fg_det_note = '" + MENote.Text + "', adj_in_fg_det_qty = '" + decimalSQL(SPQtyPL.EditValue.ToString) + "', id_wh_drawer = '" + SLEDrawer.EditValue.ToString + "', adj_in_fg_det_price = '" + decimalSQL(TxtRealCost.EditValue.ToString) + "' WHERE id_adj_in_fg_det = '" + id_adj_x_fg_det + "' "
                            'execute_non_query(query_upd_return_det, True, "", "", "", "")
                            'Dim query_upd_storage1 As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_product, storage_fg_qty, storage_fg_datetime, storage_fg_notes) "
                            'query_upd_storage1 += "VALUES('" + id_wh_drawer_edit.ToString + "', '2', '" + id_product_edit + "', '" + adj_x_fg_det_qty.ToString + "', NOW(), 'Data Edited, Adjustment In mat No. : " + FormFGAdjInDet.TxtAdjNumber.Text + "')"
                            'execute_non_query(query_upd_storage1, True, "", "", "", "")
                            'Dim query_upd_storage2 As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_product, storage_fg_qty, storage_fg_datetime, storage_fg_notes) "
                            'query_upd_storage2 += "VALUES('" + SLEDrawer.EditValue.ToString + "', '1', '" + GVFG.GetFocusedRowCellDisplayText("id_product").ToString + "', '" + decimalSQL(SPQtyPL.EditValue.ToString) + "', NOW(), 'Data Edited, Adjustment In mat No. : " + FormFGAdjInDet.TxtAdjNumber.Text + "')"
                            'execute_non_query(query_upd_storage2, True, "", "", "", "")
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_product", GVFG.GetFocusedRowCellDisplayText("id_product").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("name", GVFG.GetFocusedRowCellDisplayText("name").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("size", GVFG.GetFocusedRowCellValue("size").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("uom", GVFG.GetFocusedRowCellValue("uom").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("code", GVFG.GetFocusedRowCellValue("code").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_qty", qty_input_grid)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_price", TxtRealCost.EditValue)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_amount", TxtAmount.EditValue)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_note", MENote.Text)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_wh_drawer", SLEDrawer.EditValue.ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_wh_rack", SLERack.EditValue.ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_wh_locator", SLELocator.EditValue.ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_comp", SLEWH.EditValue.ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("wh_drawer", SLEDrawer.Properties.GetDisplayText(SLEDrawer.EditValue))
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("wh_rack", SLERack.Properties.GetDisplayText(SLERack.EditValue))
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("wh_locator", SLELocator.Properties.GetDisplayText(SLELocator.EditValue))
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("comp_name", SLEWH.Properties.GetDisplayText(SLEWH.EditValue))
                            FormFGAdjInDet.GVDetail.CloseEditor()
                            FormFGAdjInDet.GCDetail.RefreshDataSource()
                            FormFGAdjInDet.GVDetail.RefreshData()
                            Close()
                        End If
                    Else
                        If id_pop_up = "1" Then 'Edit Standard Adj In
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_adj_in_fg_det", "0")
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_product", GVFG.GetFocusedRowCellDisplayText("id_product").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("name", GVFG.GetFocusedRowCellDisplayText("name").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("size", GVFG.GetFocusedRowCellValue("size").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("uom", GVFG.GetFocusedRowCellValue("uom").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("code", GVFG.GetFocusedRowCellValue("code").ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_qty", qty_input_grid)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_price", TxtRealCost.EditValue)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_amount", TxtAmount.EditValue)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_note", MENote.Text)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_wh_drawer", SLEDrawer.EditValue.ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_wh_rack", SLERack.EditValue.ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_wh_locator", SLELocator.EditValue.ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_comp", SLEWH.EditValue.ToString)
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("wh_drawer", SLEDrawer.Properties.GetDisplayText(SLEDrawer.EditValue))
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("wh_rack", SLERack.Properties.GetDisplayText(SLERack.EditValue))
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("wh_locator", SLELocator.Properties.GetDisplayText(SLELocator.EditValue))
                            FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("comp_name", SLEWH.Properties.GetDisplayText(SLEWH.EditValue))
                            FormFGAdjInDet.GVDetail.CloseEditor()
                            FormFGAdjInDet.GCDetail.RefreshDataSource()
                            FormFGAdjInDet.GVDetail.RefreshData()
                            Close()
                        End If
                    End If
                Else
                    errorCustom("This material already exist in Adjustment List !")
                End If
            End If
            FormFGAdjInDet.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
            FormFGAdjInDet.check_but()
            FormFGAdjInDet.total_amount = Double.Parse(FormFGAdjInDet.GVDetail.Columns("adj_in_fg_det_amount").SummaryItem.SummaryValue.ToString)
            FormFGAdjInDet.METotSay.Text = ConvertCurrencyToEnglish(FormFGAdjInDet.total_amount, FormFGAdjInDet.LECurrency.EditValue.ToString)
        Else
            errorCustom("Qty not allowed zero value ! ")
        End If
    End Sub

    Private Sub BtnViewImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewImg.Click
        pre_viewImages("2", PictureEdit1, GVFG.GetFocusedRowCellValue("id_design").ToString, True)
    End Sub

    'SLE EVENT
    Private Sub SLEWH_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEWH.EditValueChanged
        Try
            'MsgBox("Load Locator")
            viewWHLocatorSLE()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SLELocator_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocator.EditValueChanged
        Try
            viewWHRack()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SLERack_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERack.EditValueChanged
        Try
            viewWHDrawer()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SLEDrawer_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEDrawer.EditValueChanged
        Try
            chooseCondition()
            checkExistInput()
        Catch ex As Exception

        End Try
    End Sub

    'Aneka Function
    Sub chooseCondition()
        Dim id_product As String = GVFG.GetFocusedRowCellDisplayText("id_product").ToString
        If SLEDrawer.EditValue Is Nothing Or id_product = "" Then
            BtnChoose.Enabled = False
            LabelAttention.Text = "Drawer is not available this time"
            LabelAttention.Visible = True
            SPQtyPL.Enabled = False
            MENote.Enabled = False
            TxtCost.Enabled = False
            TxtKurs.Enabled = False
        Else
            BtnChoose.Enabled = True
            LabelAttention.Visible = False
            SPQtyPL.Enabled = True
            MENote.Enabled = True
            TxtCost.Enabled = True
            TxtKurs.Enabled = True
        End If
    End Sub

    Sub checkExistInput()
        ketemu = False
        Dim id_product_cek As String = GVFG.GetFocusedRowCellDisplayText("id_product").ToString
        Try
            Dim id_wh_drawer_cek As String = SLEDrawer.EditValue.ToString
            For i As Integer = 0 To (FormFGAdjInDet.GVDetail.RowCount - 1)
                Try
                    Dim id_product_data As String = FormFGAdjInDet.GVDetail.GetRowCellValue(i, "id_product")
                    Dim id_wh_drawer_data As String = FormFGAdjInDet.GVDetail.GetRowCellValue(i, "id_wh_drawer")
                    If id_product_data <> "" Then
                        If action = "ins" Then
                            If id_product_cek = id_product_data And id_wh_drawer_cek = id_wh_drawer_data Then
                                ketemu = True
                                Exit For
                            End If
                        ElseIf action = "upd" Then
                            If id_product_cek = id_product_data And id_wh_drawer_cek = id_wh_drawer_data And i <> indeks_edit Then
                                ketemu = True
                                Exit For
                            End If
                        End If
                    End If
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception
            chooseCondition()
        End Try
    End Sub

    Private Sub GVFG_BeforeLeaveRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles GVFG.BeforeLeaveRow
        id_product_old = GVFG.GetFocusedRowCellDisplayText("id_product").ToString
    End Sub

    Private Sub GVFG_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVFG.DoubleClick
        'Dim id_product As String = GVFG.GetFocusedRowCellDisplayText("id_product").ToString
        'If Not id_product = "" Then
        '    FormInfoDrawer.id_product = GVFG.GetFocusedRowCellDisplayText("id_product").ToString
        '    FormInfoDrawer.LabelSubTitle.Text = GVFG.GetFocusedRowCellDisplayText("code").ToString + "/" + GVFG.GetFocusedRowCellDisplayText("fg_det_name").ToString
        '    FormInfoDrawer.ShowDialog()
        'End If
    End Sub

    Private Sub GVFG_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFG.FocusedRowChanged
        Dim cost As Decimal = 0.0
        Try
            cost = Decimal.Parse(GVFG.GetFocusedRowCellValue("design_cop").ToString)
        Catch ex As Exception
        End Try
        TxtRealCost.EditValue = cost

        If action = "ins" Then
            Dim qty_input As Decimal = SPQtyPL.EditValue
            chooseCondition()
            viewImg()
            checkExistInput()
        ElseIf action = "upd" Then
            chooseCondition()
            viewImg()
            getAmount()
        End If
    End Sub
    Sub getRealCost()
        Try
            Dim po_price_dec As Decimal = TxtCost.EditValue
            Dim kurs, price As Decimal
            kurs = TxtKurs.EditValue
            price = kurs * po_price_dec
            TxtRealCost.EditValue = price
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnViewStockSum_Click(sender As Object, e As EventArgs) Handles BtnViewStockSum.Click
        viewStock()
    End Sub

    Sub getAmount()
        Dim qty As Decimal = Decimal.Parse(SPQtyPL.EditValue)
        Dim cost As Decimal = Decimal.Parse(TxtRealCost.EditValue)
        TxtAmount.EditValue = qty * cost
    End Sub

    Private Sub TxtCost_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCost.EditValueChanged
        getRealCost()
    End Sub

    Private Sub TxtKurs_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKurs.EditValueChanged
        getRealCost()
    End Sub

    Private Sub SPQtyPL_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPQtyPL.EditValueChanged
        getAmount()
    End Sub

    Private Sub TxtRealCost_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRealCost.EditValueChanged
        getAmount()
    End Sub

    Private Sub GVFG_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVFG.CustomColumnDisplayText
        
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
End Class