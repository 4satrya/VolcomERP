Public Class FormPopUpProdDet
    Public id_prod_order As String
    Public id_prod_order_rec As String
    Public id_prod_order_det As String
    Public id_prod_order_det_edit As String
    Public id_pop_up As String
    Public id_pl As String
    Public id_ret_out As String = "0"
    Public id_ret_in As String = "0"
    Public is_info_form As Boolean = False
    Public id_pd_alloc_par As String = "0"
    Public action As String
    Private Sub FormPopUpPurchaseMatDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT * FROM tb_prod_order WHERE id_prod_order = '" + id_prod_order + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LabelSubTitle.Text = "Production Order No. :" + data.Rows(0)("prod_order_number").ToString
        view_list_purchase()

        'prop column
        'If id_pop_up <> "3" Then
        GridColumnQtyAlloc.Visible = False
        'End If
    End Sub
    Sub view_list_purchase()
        Dim query As String = ""
        If id_pop_up = "1" Then
            'query = "CALL view_stock_prod_rec('" + id_prod_order + "', '0', '" + id_ret_out + "', '" + id_ret_in + "', '" + id_pl + "','0', '" + id_pd_alloc_par + "')"
            query = "CALL view_limit_prod_rec('" + id_prod_order_rec + "','" + id_prod_order + "', '0', '" + id_ret_out + "', '" + id_ret_in + "', '" + id_pl + "','0', '" + id_pd_alloc_par + "')"
        ElseIf id_pop_up = "2" Then
            'query = "CALL view_stock_prod_ret_in_remain('" + id_prod_order + "', '0', '" + id_ret_out + "', '" + id_ret_in + "', '0')"
            query = "CALL view_limit_ret_out('" + id_ret_out + "','" + id_ret_in + "', '1')"
        ElseIf id_pop_up = "3" Then
            'query = "CALL view_stock_prod_rec('" + id_prod_order + "', '0', '" + id_ret_out + "', '" + id_ret_in + "', '" + id_pl + "','0', '" + id_pd_alloc_par + "')"
            query = "CALL view_limit_prod_rec('" + id_prod_order_rec + "','" + id_prod_order + "', '0', '" + id_ret_out + "', '" + id_ret_in + "', '" + id_pl + "','0', '" + id_pd_alloc_par + "')"
        ElseIf id_pop_up = "4" Then
            query = "CALL view_stock_prod_ret_in_remain('" + id_prod_order + "', '0', '" + id_ret_out + "', '" + id_ret_in + "', '0')"
        ElseIf id_pop_up = "5" Then
            query = "CALL view_stock_prod_ret_in_remain('" + id_prod_order + "', '0', '" + id_ret_out + "', '" + id_ret_in + "', '0')"
        End If
        'Console.WriteLine(query)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If id_pop_up = "1" Then
            Dim i As Integer = data.Rows.Count - 1
            If Not is_info_form Then
                While (i >= 0)
                    If FormProductionRetOutSingle.id_prod_order_det_list.Contains(data.Rows(i)("id_prod_order_det").ToString) Then
                        data.Rows.RemoveAt(i)
                    End If
                    i = i - 1
                End While
            End If
            ColPrice.Visible = False
            GridColumnRangeUnique.Visible = False
            ColSubtotal.Visible = False
        ElseIf id_pop_up = "2" Then
            Dim i As Integer = data.Rows.Count - 1
            If Not is_info_form Then
                While (i >= 0)
                    If FormProductionRetInSingle.id_prod_order_det_list.Contains(data.Rows(i)("id_prod_order_det").ToString) Then
                        data.Rows.RemoveAt(i)
                    End If
                    i = i - 1
                End While
            End If
            ColPrice.Visible = False
            GridColumnRangeUnique.Visible = False
            ColSubtotal.Visible = False
        ElseIf id_pop_up = "3" Then
            Dim i As Integer = data.Rows.Count - 1
            If Not is_info_form Then
                While (i >= 0)
                    If FormProductionPLToWHDet.id_prod_order_det_list.Contains(data.Rows(i)("id_prod_order_det").ToString) Then
                        data.Rows.RemoveAt(i)
                    End If
                    i = i - 1
                End While
            End If
        End If
        GCListProduct.DataSource = data
        If data.Rows.Count > 0 Then
            BtnSave.Enabled = True
        Else
            BtnSave.Enabled = False
        End If
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If id_pop_up = "1" Then
            If action = "ins" Then
                FormProductionRetOutSingle.newRows()
                FormProductionRetOutSingle.GVRetDetail.SetFocusedRowCellValue("id_prod_order_ret_out_det", "0")
                FormProductionRetOutSingle.GVRetDetail.SetFocusedRowCellValue("id_prod_order_det", GVListProduct.GetFocusedRowCellDisplayText("id_prod_order_det").ToString)
                FormProductionRetOutSingle.GVRetDetail.SetFocusedRowCellValue("name", GVListProduct.GetFocusedRowCellDisplayText("name").ToString)
                FormProductionRetOutSingle.GVRetDetail.SetFocusedRowCellValue("size", GVListProduct.GetFocusedRowCellValue("size").ToString)
                FormProductionRetOutSingle.GVRetDetail.SetFocusedRowCellValue("uom", GVListProduct.GetFocusedRowCellValue("uom").ToString)
                FormProductionRetOutSingle.GVRetDetail.SetFocusedRowCellValue("prod_order_ret_out_det_qty", "0")
                FormProductionRetOutSingle.GVRetDetail.SetFocusedRowCellValue("code", GVListProduct.GetFocusedRowCellValue("code").ToString)
                FormProductionRetOutSingle.GVRetDetail.SetFocusedRowCellValue("ean_code", GVListProduct.GetFocusedRowCellValue("ean_code").ToString)
                FormProductionRetOutSingle.GVRetDetail.CloseEditor()
                FormProductionRetOutSingle.id_prod_order_det_list.Add(GVListProduct.GetFocusedRowCellDisplayText("id_prod_order_det").ToString)
                FormProductionRetOutSingle.check_but()
                Close()
            ElseIf action = "upd" Then
                Dim id_prod_order_det_old As String = FormProductionRetOutSingle.GVRetDetail.GetFocusedRowCellDisplayText("id_prod_order_det").ToString
                FormProductionRetOutSingle.deleteDetailBc(id_prod_order_det_old)
                FormProductionRetOutSingle.id_prod_order_det_list.Remove(id_prod_order_det_old)
                FormProductionRetOutSingle.GVRetDetail.SetFocusedRowCellValue("id_prod_order_ret_out_det", "0")
                FormProductionRetOutSingle.GVRetDetail.SetFocusedRowCellValue("id_prod_order_det", GVListProduct.GetFocusedRowCellDisplayText("id_prod_order_det").ToString)
                FormProductionRetOutSingle.GVRetDetail.SetFocusedRowCellValue("name", GVListProduct.GetFocusedRowCellDisplayText("name").ToString)
                FormProductionRetOutSingle.GVRetDetail.SetFocusedRowCellValue("size", GVListProduct.GetFocusedRowCellValue("size").ToString)
                FormProductionRetOutSingle.GVRetDetail.SetFocusedRowCellValue("uom", GVListProduct.GetFocusedRowCellValue("uom").ToString)
                FormProductionRetOutSingle.GVRetDetail.SetFocusedRowCellValue("prod_order_ret_out_det_qty", "0")
                FormProductionRetOutSingle.GVRetDetail.SetFocusedRowCellValue("code", GVListProduct.GetFocusedRowCellValue("code").ToString)
                FormProductionRetOutSingle.GVRetDetail.SetFocusedRowCellValue("ean_code", GVListProduct.GetFocusedRowCellValue("ean_code").ToString)
                FormProductionRetOutSingle.GVRetDetail.CloseEditor()
                FormProductionRetOutSingle.id_prod_order_det_list.Add(GVListProduct.GetFocusedRowCellDisplayText("id_prod_order_det").ToString)
                FormProductionRetOutSingle.check_but()
                Close()
            End If
            FormProductionRetOutSingle.GCRetDetail.RefreshDataSource()
            FormProductionRetOutSingle.GVRetDetail.RefreshData()
        ElseIf id_pop_up = "2" Then
            If action = "ins" Then
                FormProductionRetInSingle.newRows()
                FormProductionRetInSingle.GVRetDetail.SetFocusedRowCellValue("id_prod_order_ret_in_det", "0")
                FormProductionRetInSingle.GVRetDetail.SetFocusedRowCellValue("id_prod_order_det", GVListProduct.GetFocusedRowCellDisplayText("id_prod_order_det").ToString)
                FormProductionRetInSingle.GVRetDetail.SetFocusedRowCellValue("name", GVListProduct.GetFocusedRowCellDisplayText("name").ToString)
                FormProductionRetInSingle.GVRetDetail.SetFocusedRowCellValue("size", GVListProduct.GetFocusedRowCellValue("size").ToString)
                FormProductionRetInSingle.GVRetDetail.SetFocusedRowCellValue("uom", GVListProduct.GetFocusedRowCellValue("uom").ToString)
                FormProductionRetInSingle.GVRetDetail.SetFocusedRowCellValue("prod_order_ret_in_det_qty", "0")
                FormProductionRetInSingle.GVRetDetail.SetFocusedRowCellValue("code", GVListProduct.GetFocusedRowCellValue("code").ToString)
                FormProductionRetInSingle.GVRetDetail.SetFocusedRowCellValue("ean_code", GVListProduct.GetFocusedRowCellValue("ean_code").ToString)
                FormProductionRetInSingle.GVRetDetail.CloseEditor()
                FormProductionRetInSingle.id_prod_order_det_list.Add(GVListProduct.GetFocusedRowCellDisplayText("id_prod_order_det").ToString)
                FormProductionRetInSingle.check_but()
                Close()
            ElseIf action = "upd" Then
                Dim id_prod_order_det_old As String = FormProductionRetInSingle.GVRetDetail.GetFocusedRowCellDisplayText("id_prod_order_det").ToString
                FormProductionRetInSingle.deleteDetailBc(id_prod_order_det_old)
                FormProductionRetInSingle.id_prod_order_det_list.Remove(id_prod_order_det_old)
                FormProductionRetInSingle.GVRetDetail.SetFocusedRowCellValue("id_prod_order_ret_in_det", "0")
                FormProductionRetInSingle.GVRetDetail.SetFocusedRowCellValue("id_prod_order_det", GVListProduct.GetFocusedRowCellDisplayText("id_prod_order_det").ToString)
                FormProductionRetInSingle.GVRetDetail.SetFocusedRowCellValue("name", GVListProduct.GetFocusedRowCellDisplayText("name").ToString)
                FormProductionRetInSingle.GVRetDetail.SetFocusedRowCellValue("size", GVListProduct.GetFocusedRowCellValue("size").ToString)
                FormProductionRetInSingle.GVRetDetail.SetFocusedRowCellValue("uom", GVListProduct.GetFocusedRowCellValue("uom").ToString)
                FormProductionRetInSingle.GVRetDetail.SetFocusedRowCellValue("prod_order_ret_in_det_qty", "0")
                FormProductionRetInSingle.GVRetDetail.SetFocusedRowCellValue("code", GVListProduct.GetFocusedRowCellValue("code").ToString)
                FormProductionRetInSingle.GVRetDetail.SetFocusedRowCellValue("ean_code", GVListProduct.GetFocusedRowCellValue("ean_code").ToString)
                FormProductionRetInSingle.GVRetDetail.CloseEditor()
                FormProductionRetInSingle.id_prod_order_det_list.Add(GVListProduct.GetFocusedRowCellDisplayText("id_prod_order_det").ToString)
                FormProductionRetInSingle.check_but()
                Close()
            End If
            FormProductionRetInSingle.GCRetDetail.RefreshDataSource()
            FormProductionRetInSingle.GVRetDetail.RefreshData()
        ElseIf id_pop_up = "3" Then
            If action = "ins" Then
                FormProductionPLToWHDet.newRows()
                FormProductionPLToWHDet.GVRetDetail.SetFocusedRowCellValue("id_pl_prod_order_det", "0")
                FormProductionPLToWHDet.GVRetDetail.SetFocusedRowCellValue("id_prod_order_det", GVListProduct.GetFocusedRowCellDisplayText("id_prod_order_det").ToString)
                FormProductionPLToWHDet.GVRetDetail.SetFocusedRowCellValue("name", GVListProduct.GetFocusedRowCellDisplayText("name").ToString)
                FormProductionPLToWHDet.GVRetDetail.SetFocusedRowCellValue("size", GVListProduct.GetFocusedRowCellValue("size").ToString)
                FormProductionPLToWHDet.GVRetDetail.SetFocusedRowCellValue("uom", GVListProduct.GetFocusedRowCellValue("uom").ToString)
                FormProductionPLToWHDet.GVRetDetail.SetFocusedRowCellValue("pl_prod_order_det_qty", "0")
                FormProductionPLToWHDet.GVRetDetail.SetFocusedRowCellValue("code", GVListProduct.GetFocusedRowCellValue("code").ToString)
                FormProductionPLToWHDet.GVRetDetail.SetFocusedRowCellValue("ean_code", GVListProduct.GetFocusedRowCellValue("ean_code").ToString)
                FormProductionPLToWHDet.GVRetDetail.SetFocusedRowCellValue("range_qty", GVListProduct.GetFocusedRowCellValue("range_qty").ToString)
                FormProductionPLToWHDet.GVRetDetail.CloseEditor()
                FormProductionPLToWHDet.id_prod_order_det_list.Add(GVListProduct.GetFocusedRowCellDisplayText("id_prod_order_det").ToString)
                FormProductionPLToWHDet.check_but()
                id_prod_order_det = GVListProduct.GetFocusedRowCellDisplayText("id_prod_order_det").ToString
                Close()
            ElseIf action = "upd" Then
                Dim id_prod_order_det_old As String = FormProductionPLToWHDet.GVRetDetail.GetFocusedRowCellDisplayText("id_prod_order_det").ToString
                FormProductionPLToWHDet.deleteDetailBc(id_prod_order_det_old)
                FormProductionPLToWHDet.id_prod_order_det_list.Remove(id_prod_order_det_old)
                FormProductionPLToWHDet.GVRetDetail.SetFocusedRowCellValue("id_pl_prod_order_det", "0")
                FormProductionPLToWHDet.GVRetDetail.SetFocusedRowCellValue("id_prod_order_det", GVListProduct.GetFocusedRowCellDisplayText("id_prod_order_det").ToString)
                FormProductionPLToWHDet.GVRetDetail.SetFocusedRowCellValue("name", GVListProduct.GetFocusedRowCellDisplayText("name").ToString)
                FormProductionPLToWHDet.GVRetDetail.SetFocusedRowCellValue("size", GVListProduct.GetFocusedRowCellValue("size").ToString)
                FormProductionPLToWHDet.GVRetDetail.SetFocusedRowCellValue("uom", GVListProduct.GetFocusedRowCellValue("uom").ToString)
                FormProductionPLToWHDet.GVRetDetail.SetFocusedRowCellValue("pl_prod_order_det_qty", "0")
                FormProductionPLToWHDet.GVRetDetail.SetFocusedRowCellValue("code", GVListProduct.GetFocusedRowCellValue("code").ToString)
                FormProductionPLToWHDet.GVRetDetail.SetFocusedRowCellValue("ean_code", GVListProduct.GetFocusedRowCellValue("ean_code").ToString)
                FormProductionPLToWHDet.GVRetDetail.SetFocusedRowCellValue("range_qty", GVListProduct.GetFocusedRowCellValue("range_qty").ToString)
                FormProductionPLToWHDet.GVRetDetail.CloseEditor()
                FormProductionPLToWHDet.id_prod_order_det_list.Add(GVListProduct.GetFocusedRowCellDisplayText("id_prod_order_det").ToString)
                FormProductionPLToWHDet.check_but()
                id_prod_order_det = GVListProduct.GetFocusedRowCellDisplayText("id_prod_order_det").ToString
                Close()
            End If
            FormProductionPLToWHDet.GCRetDetail.RefreshDataSource()
            FormProductionPLToWHDet.GVRetDetail.RefreshData()
        End If
    End Sub

    Private Sub FormPopUpPurchaseMatDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
        'If id_pop_up = "3" Then
        '    If action = "ins" Then
        '        'go to process
        '        FormProcessing.id_process = "1"
        '        FormProcessing.idx = id_prod_order_det
        '        FormProcessing.ShowDialog()
        '    ElseIf action = "upd" Then
        '        'go to process
        '        FormProcessing.id_process = "2"
        '        FormProcessing.idx = id_prod_order_det_edit
        '        FormProcessing.ShowDialog()

        '        ''go to process
        '        FormProcessing.id_process = "1"
        '        FormProcessing.idx = id_prod_order_det
        '        FormProcessing.ShowDialog()
        '    End If
        'End If
    End Sub

    Private Sub GVListProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProduct.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub PanelControl1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelControl1.Paint

    End Sub
End Class