Public Class FormFGAdjOutSingle 
    Public id_pop_up As String = "-1"
    Public id_wh As String = "-1"
    Public allow_all_wh As Boolean = True
    Public allow_all_locator As Boolean = True
    Public allow_all_rack As Boolean = True
    Public allow_all_drawer As Boolean = True

    Dim id_product As String
    Public action As String
    Public id_wh_rack_edit, id_wh_locator_edit, id_wh_drawer_edit, pl_mrs_det_qty, pl_mrs_det_note, id_product_edit As String
    Public id_adj_out_fg As String

    Public id_currency As String = "1"
    Public currency As String = ""

    '1 = Adjustment Out

    'Form
    Private Sub FormFGAdjOutSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TECurrency.Text = currency

        If id_pop_up = "1" Then
            viewWHStock()
            If action = "ins" Then
                'viewFGStorage()
            ElseIf action = "upd" Then
                SLEWH.EditValue = id_wh
                SLELocator.EditValue = id_wh_locator_edit
                SLERack.EditValue = id_wh_rack_edit
                SLEDrawer.EditValue = id_wh_drawer_edit
                viewFGStorage()
                SPQtyPL.Text = pl_mrs_det_qty.ToString
                MERemark.Text = pl_mrs_det_note.ToString
            End If
        End If
    End Sub

    Private Sub FormFGAdjOutSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    'View Data
    Sub viewWHStock()
        Dim query As String = ""
        'get id category on opt
        query = "SELECT id_comp_cat_wh FROM tb_opt "
        Dim id_comp_cat_wh As String = execute_query(query, 0, True, "", "", "", "")
        query = "SELECT id_comp_cat_store FROM tb_opt "
        Dim id_comp_cat_store As String = execute_query(query, 0, True, "", "", "", "")

        'view data comp/warehouse
        query = ""
        If allow_all_wh Then
            query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All WH') AS comp_name UNION ALL "
        End If
        query += "SELECT a.id_comp, a.comp_number, a.comp_name FROM tb_m_comp a WHERE (a.id_comp_cat = '" + id_comp_cat_wh + "' OR  a.id_comp_cat = '" + id_comp_cat_store + "') "
        If id_wh <> "-1" Then
            query += "AND a.id_comp = '" + id_wh + "' "
        End If
        query += "ORDER BY comp_number ASC "
        viewSearchLookupQuery(SLEWH, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub viewWHLocatorSLE()
        Dim id_comp As String = SLEWH.EditValue.ToString
        Dim query As String = ""
        If allow_all_locator Then
            query += "SELECT ('0') AS id_comp, ('0') AS id_wh_locator, ('-') AS wh_locator_code, ('All Loactor') AS wh_locator, ('-') AS wh_locator_description UNION ALL "
        End If
        query += "SELECT a.id_comp, a.id_wh_locator, a.wh_locator_code, a.wh_locator, a.wh_locator_description FROM tb_m_wh_locator a WHERE a.id_comp = '" + id_comp + "' "
        viewSearchLookupQuery(SLELocator, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub
    Sub viewWHRack()
        Dim id_locator As String = SLELocator.EditValue.ToString
        Dim query As String = ""
        If allow_all_rack Then
            query += "SELECT ('0') AS id_locator, ('0') AS id_wh_rack, ('-') AS wh_rack_code, ('All Rack') AS wh_rack, ('-') AS wh_rack_description UNION ALL "
        End If
        query += "SELECT a.id_wh_locator, a.id_wh_rack, a.wh_rack_code, a.wh_rack, a.wh_rack_description FROM tb_m_wh_rack a WHERE a.id_wh_locator = '" + id_locator + "' "
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub
    Sub viewWHDrawer()
        Dim id_rack As String = SLERack.EditValue.ToString
        Dim query As String = ""
        If allow_all_drawer Then
            query = "SELECT ('0') AS id_rack, ('0') AS id_wh_drawer, ('-') AS wh_drawer_code, ('All Drawer') AS wh_drawer, ('-') AS wh_drawer_description UNION ALL "
        End If
        query += "SELECT a.id_wh_rack, a.id_wh_drawer, a.wh_drawer_code, a.wh_drawer, a.wh_drawer_description FROM tb_m_wh_drawer a WHERE a.id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub
    Sub viewFGStorage()
        Cursor = Cursors.WaitCursor
        Dim id_wh_drawer_view As String = "-1"
        Dim id_wh_rack_view As String = "-1"
        Dim id_wh_locator_view As String = "-1"
        Dim id_wh_view As String = "-1"

        If Not SLEDrawer.EditValue = Nothing Then
            id_wh_drawer_view = SLEDrawer.EditValue.ToString
        End If
        If Not SLERack.EditValue = Nothing Then
            id_wh_rack_view = SLERack.EditValue.ToString()
        End If
        If Not SLELocator.EditValue = Nothing Then
            id_wh_locator_view = SLELocator.EditValue.ToString()
        End If
        If Not SLEWH.EditValue = Nothing Then
            id_wh_view = SLEWH.EditValue.ToString()
        End If

        'Try
        If id_pop_up = "1" Then

            Dim query As String = "CALL view_stock_fg('" + id_wh_view + "','" + id_wh_locator_view + "','" + id_wh_rack_view + "','" + id_wh_drawer_view + "', '0', '4', '9999-01-01')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            'data = execute_query(query, -1, True, "", "", "", "")

            'query = data.Rows(0)("sql_string").ToString
            'data = execute_query(query, -1, True, "", "", "", "")

            'For j As Integer = 0 To data.Rows.Count - 1
            '    If action = "upd" Then
            '        If id_pl_mrs_det <> "0" Then
            '            If data.Rows(j)("id_wh_drawer") = id_wh_drawer_edit And data.Rows(j)("price") = FormMatPLSingle.GVDrawer.GetFocusedRowCellValue("pl_mrs_det_price").ToString And data.Rows(j)("id_product_price") = FormMatPLSingle.GVDrawer.GetFocusedRowCellValue("id_product_price").ToString Then
            '                data.Rows(j)("qty_all_mat") = Decimal.Parse(data.Rows(j)("qty_all_mat")) + Decimal.Parse(pl_mrs_det_qty)
            '            End If
            '        End If
            '    End If
            'Next

            GCFG.DataSource = data

            If action = "ins" Then
                GVFG.Columns("name").GroupIndex = 0
            End If
            If data.Rows.Count > 0 Then
                BtnChoose.Enabled = True
                BtnImg.Enabled = True
            Else
                BtnChoose.Enabled = False
                BtnImg.Enabled = False
            End If
            setRequired()
        End If
        'Catch ex As Exception
        '    errorConnection()
        '   Close()
        'End Try
        Cursor = Cursors.Default
    End Sub
    Sub viewImg()
        Dim id_dsg As String = "-1"
        Try
            id_dsg = GVFG.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception
        End Try
        pre_viewImages("2", PictureEdit1, id_dsg, False)

        If id_product <> "" Then
            BtnChoose.Enabled = True
            'BPickPrice.Enabled = True
            TEUnitPrice.EditValue = 0
        Else
            BtnChoose.Enabled = False
            'BPickPrice.Enabled = False
            TEUnitPrice.EditValue = 0
        End If
    End Sub
    Private Sub SLEWH_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEWH.EditValueChanged
        Try
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
            If SLEDrawer.EditValue Is Nothing Then
                BtnViewStock.Enabled = False
            Else
                BtnViewStock.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    'Button
    Private Sub BtnViewStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewStock.Click
        Try
            viewFGStorage()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        ValidateChildren()
        If Not formIsValidInGroup(EPStorageFG, GroupControlInput) Then
            stopCustom("Please check your input.")
        Else
            If id_pop_up = "1" Then
                Dim qty_input_grid As Decimal = Decimal.Parse(SPQtyPL.Text.ToString)
                If Not qty_input_grid = 0 Then '-------NEW----------
                    If action = "ins" Then
                        'check duplicate
                        Dim already As Boolean = False
                        For i As Integer = 0 To FormFGAdjOutDet.GVDetail.RowCount - 1
                            Dim id_product_cek As String = ""
                            Dim id_wh_drawer_cek As String = ""
                            Dim cost_cek As Decimal = 0.0
                            Try
                                id_product_cek = FormFGAdjOutDet.GVDetail.GetRowCellValue(i, "id_product").ToString
                                id_wh_drawer_cek = FormFGAdjOutDet.GVDetail.GetRowCellValue(i, "id_wh_drawer").ToString
                                cost_cek = Decimal.Parse(FormFGAdjOutDet.GVDetail.GetRowCellValue(i, "adj_out_fg_det_price").ToString)
                            Catch ex As Exception
                            End Try
                            If id_product_cek = GVFG.GetFocusedRowCellDisplayText("id_product").ToString And id_wh_drawer_cek = GVFG.GetFocusedRowCellDisplayText("id_wh_drawer").ToString And cost_cek = Decimal.Parse(GVFG.GetFocusedRowCellDisplayText("bom_unit_price").ToString) Then
                                already = True
                                Exit For
                            End If
                        Next

                        If Not already Then
                            FormFGAdjOutDet.newRows()
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("id_product", GVFG.GetFocusedRowCellDisplayText("id_product").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("name", GVFG.GetFocusedRowCellDisplayText("name").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("code", GVFG.GetFocusedRowCellValue("code").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("size", GVFG.GetFocusedRowCellValue("size").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("adj_out_fg_det_qty", qty_input_grid.ToString("N2"))
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("adj_out_fg_det_note", MERemark.Text)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("uom", GVFG.GetFocusedRowCellValue("uom").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("wh_drawer", GVFG.GetFocusedRowCellValue("wh_drawer").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("comp", GVFG.GetFocusedRowCellValue("comp_number").ToString + " - " + GVFG.GetFocusedRowCellValue("comp_name").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("id_wh_locator", GVFG.GetFocusedRowCellValue("id_wh_locator").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("id_wh_drawer", GVFG.GetFocusedRowCellValue("id_wh_drawer").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("id_wh_rack", GVFG.GetFocusedRowCellValue("id_wh_rack").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("id_comp", GVFG.GetFocusedRowCellValue("id_comp").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("adj_out_fg_det_price", TEUnitPrice.EditValue)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("adj_out_fg_det_amount", (TEUnitPrice.EditValue * qty_input_grid))

                            'Save in Gridview
                            FormFGAdjOutDet.GVDetail.CloseEditor()
                            FormFGAdjOutDet.GCDetail.RefreshDataSource()
                            FormFGAdjOutDet.GVDetail.RefreshData()
                            FormFGAdjOutDet.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
                            FormFGAdjOutDet.check_but()
                            FormFGAdjOutDet.total_amount = Double.Parse(FormFGAdjOutDet.GVDetail.Columns("adj_out_fg_det_amount").SummaryItem.SummaryValue.ToString)
                            FormFGAdjOutDet.METotSay.Text = ConvertCurrencyToEnglish(FormFGAdjOutDet.total_amount, FormFGAdjOutDet.LECurrency.EditValue.ToString)
                            'Close()
                        Else
                            stopCustom("This product already on list.")
                        End If
                    ElseIf action = "upd" Then ' -------EDIT------------
                        'check duplicate
                        Dim already As Boolean = False
                        For i As Integer = 0 To FormFGAdjOutDet.GVDetail.RowCount - 1
                            If Not FormFGAdjOutDet.GVDetail.FocusedRowHandle = i Then
                                Dim id_product_cek As String = ""
                                Dim id_wh_drawer_cek As String = ""
                                Dim cost_cek As Decimal = 0.0
                                Try
                                    id_product_cek = FormFGAdjOutDet.GVDetail.GetRowCellValue(i, "id_product").ToString
                                    id_wh_drawer_cek = FormFGAdjOutDet.GVDetail.GetRowCellValue(i, "id_wh_drawer").ToString
                                    cost_cek = Decimal.Parse(FormFGAdjOutDet.GVDetail.GetRowCellValue(i, "adj_out_fg_det_price").ToString)
                                Catch ex As Exception
                                End Try
                                If id_product_cek = GVFG.GetFocusedRowCellDisplayText("id_product").ToString And id_wh_drawer_cek = GVFG.GetFocusedRowCellDisplayText("id_wh_drawer").ToString And cost_cek = Decimal.Parse(GVFG.GetFocusedRowCellDisplayText("bom_unit_price").ToString) And i <> FormFGAdjOutDet.GVDetail.FocusedRowHandle Then
                                    already = True
                                    Exit For
                                End If
                            End If
                        Next

                        If Not already Then
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("id_product", GVFG.GetFocusedRowCellDisplayText("id_product").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("name", GVFG.GetFocusedRowCellDisplayText("name").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("code", GVFG.GetFocusedRowCellValue("code").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("size", GVFG.GetFocusedRowCellValue("size").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("adj_out_fg_det_qty", qty_input_grid.ToString("N2"))
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("adj_out_fg_det_note", MERemark.Text)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("wh_drawer", GVFG.GetFocusedRowCellValue("wh_drawer").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("id_wh_drawer", GVFG.GetFocusedRowCellValue("id_wh_drawer").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("id_wh_locator", GVFG.GetFocusedRowCellValue("id_wh_locator").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("id_wh_rack", GVFG.GetFocusedRowCellValue("id_wh_rack").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("uom", GVFG.GetFocusedRowCellValue("uom").ToString)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("adj_out_fg_det_price", TEUnitPrice.EditValue)
                            FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("adj_out_fg_det_amount", (TEUnitPrice.EditValue * qty_input_grid))

                            'Save in Gridview
                            FormFGAdjOutDet.GVDetail.CloseEditor()
                            FormFGAdjOutDet.GCDetail.RefreshDataSource()
                            FormFGAdjOutDet.GVDetail.RefreshData()
                            FormFGAdjOutDet.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
                            FormFGAdjOutDet.check_but()
                            FormFGAdjOutDet.total_amount = Double.Parse(FormFGAdjOutDet.GVDetail.Columns("adj_out_fg_det_amount").SummaryItem.SummaryValue.ToString)
                            FormFGAdjOutDet.METotSay.Text = ConvertCurrencyToEnglish(FormFGAdjOutDet.total_amount, FormFGAdjOutDet.LECurrency.EditValue.ToString)
                            'Close()
                        Else
                            stopCustom("This product already on list.")
                        End If
                    End If
                Else
                    errorCustom("Qty PL not allowed zero value ! ")
                End If
            End If
        End If
    End Sub
    Private Sub BtnImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImg.Click
        pre_viewImages("2", PictureEdit1, GVFG.GetFocusedRowCellValue("id_design").ToString, True)
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'GridView
    Private Sub GVSample_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVFG.RowClick
        Try
            setRequired()
        Catch ex As Exception

        End Try
    End Sub
    'Set required
    Sub setRequired()
        id_product = "0"
        Try
            id_product = GVFG.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception

        End Try
        viewImg()
        If id_product <> "0" Then
            TxtQtyLimit.EditValue = GVFG.GetFocusedRowCellValue("qty_all_product").ToString
            TECurrency.Text = GVFG.GetFocusedRowCellValue("currency").ToString
            TEUnitPrice.EditValue = Decimal.Parse(GVFG.GetFocusedRowCellValue("bom_unit_price").ToString)
            BtnChoose.Enabled = True
            'MsgBox(id_product)
            'MsgBox(GVFG.GetFocusedRowCellValue("bom_unit_price").ToString)
            SPQtyPL.EditValue = 0.0
            MERemark.Text = ""
        Else
            BtnChoose.Enabled = False
        End If
    End Sub

    'Spin QTY
    Private Sub SPQtyPL_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPQtyPL.EditValueChanged
        Try
            Dim SpQty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
            Dim qty_rec As Decimal = SpQty.EditValue
            Dim qty_limit As Decimal = GVFG.GetFocusedRowCellDisplayText("qty_all_product")
            Dim current_name As String = GVFG.GetFocusedRowCellDisplayText("name").ToString
            Dim current_uom As String = GVFG.GetFocusedRowCellDisplayText("uom").ToString
            If qty_rec > qty_limit Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Product sample : '" + current_name + "', cannot exceed " + qty_limit.ToString + " " + current_uom + " ! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SpQty.EditValue = qty_limit
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GVFG_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFG.FocusedRowChanged
        Try
            setRequired()
        Catch ex As Exception

        End Try
    End Sub
End Class