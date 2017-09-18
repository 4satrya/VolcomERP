Public Class FormProductionAssemblyComp
    Public id_prod_ass_det As String = "-1"
    Public data_par As DataTable
    Public id_pop_up As String = "-1"

    Private Sub FormProductionAssemblyComp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDesign()
    End Sub

    Sub viewDesign()
        Dim query As String = "SELECT po.id_prod_order, pdd.id_design, d.design_code AS `code`, d.design_display_name AS `name`
        FROM tb_prod_order po 
        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
        INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
        WHERE po.id_report_status=3 OR po.id_report_status=4 
        ORDER BY po.id_prod_order ASC "
        viewSearchLookupQuery(SLEDesignStockStore, query, "id_prod_order", "name", "id_prod_order")
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVData)
        GCData.DataSource = Nothing
        Dim query As String = "CALL view_stock_prod_rec(" + SLEDesignStockStore.EditValue.ToString + ", 0, 0, 0, 0, 0, 0)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If id_pop_up = "-1" Then
            If data_par.Rows.Count = 0 Then
                GCData.DataSource = data
            Else
                Dim t1 = data.AsEnumerable()
                Dim t2 = data_par.AsEnumerable()
                Dim except As DataTable = (From _t1 In t1
                                           Group Join _t2 In t2
                                           On _t1("id_prod_order_det") Equals _t2("id_prod_order_det") Into Group
                                           From _t3 In Group.DefaultIfEmpty()
                                           Where _t3 Is Nothing
                                           Select _t1).CopyToDataTable
                GCData.DataSource = except
            End If
            GVData.Focus()
            GVData.FocusedColumn = GVData.Columns("qty_sel")
        ElseIf id_pop_up = "1"
            'check design already
            Dim id_design_cek As String = execute_query("SELECT pdd.id_design FROM tb_prod_order po INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design WHERE po.id_prod_order=" + SLEDesignStockStore.EditValue.ToString + "", 0, True, "", "", "", "")
            Dim dt_filter_dsg As DataRow() = data_par.Select("[id_design]='" + id_design_cek + "' ")
            If dt_filter_dsg.Length > 0 Then
                errorCustom("Design already input")
            Else
                Dim data_par_main As DataTable = FormProductionAssemblySingle.GCItemList.DataSource
                If data.Rows.Count <> data_par_main.Rows.Count Then
                    stopCustom("Make sure components have same size chart")
                Else
                    Dim cek As Boolean = True
                    For i As Integer = 0 To data.Rows.Count - 1
                        Dim id_size_cek As String = data.Rows(i)("id_size").ToString
                        Dim dt_filter As DataRow() = data_par_main.Select("[id_size]='" + id_size_cek + "' ")
                        If dt_filter.Length <= 0 Then
                            cek = False
                            Exit For
                        End If
                    Next

                    If Not cek Then
                        stopCustom("Make sure components have same size chart")
                    Else
                        GCData.DataSource = data
                    End If

                    If FormProductionAssemblyQuickAdd.GVComponent.RowCount <= 0 Then
                        GVData.Focus()
                        GVData.FocusedColumn = GVData.Columns("qty_sel")
                    Else
                        For j As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim dt_comp_filter As DataRow() = data_par.Select("[id_size]='" + GVData.GetRowCellValue(j, "id_size").ToString + "' ")
                            Dim qty As Decimal = 0
                            If dt_comp_filter.Length > 0 Then
                                qty = dt_comp_filter(0)("prod_ass_comp_qty_det")
                            Else
                                qty = 0
                            End If
                            GVData.SetRowCellValue(j, "qty_sel", qty)
                        Next
                        GridColumnQtySel.OptionsColumn.AllowEdit = False
                        SimpleButton1.Focus()
                    End If
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormProductionAssemblyComp_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVData)
        If id_pop_up = "-1" Then
            GVData.ActiveFilterString = "[qty_sel]>0"
            If GVData.RowCount > 0 Then
                'cek
                Dim dt_cek As DataTable = execute_query("CALL view_stock_prod_rec(" + SLEDesignStockStore.EditValue.ToString + ", 0, 0, 0, 0, 0, 0)", -1, True, "", "", "", "")
                Dim cond_check_data As Boolean = True
                For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                    Dim id_prod_order_det_cekya As String = GVData.GetRowCellValue(i, "id_prod_order_det").ToString
                    Dim qty_cek As Integer = GVData.GetRowCellValue(i, "qty_sel")

                    'check qty
                    Dim data_filter_cek As DataRow() = dt_cek.Select("[id_prod_order_det]='" + id_prod_order_det_cekya + "' ")
                    If qty_cek > data_filter_cek(0)("qty") Then
                        GVData.SetRowCellValue(i, "info", "Can't exceed " + Decimal.Parse(data_filter_cek(0)("qty").ToString).ToString("n0") + ";")
                        cond_check_data = False
                    Else
                        GVData.SetRowCellValue(i, "info", "")
                    End If
                Next
                GCData.RefreshDataSource()
                GVData.RefreshData()

                If Not cond_check_data Then
                    GridColumnInfo.VisibleIndex = 100
                    stopCustom("Please see notice in 'info' column.")
                Else
                    'inserd detail
                    GridColumnInfo.Visible = False
                    Dim query_ins As String = "INSERT INTO tb_prod_ass_comp_det(id_prod_ass_det, id_prod_order_det, id_product, prod_ass_comp_qty_det) VALUES "
                    Dim jum_ins_j As Integer = 0
                    For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                        If jum_ins_j > 0 Then
                            query_ins += ", "
                        End If
                        query_ins += "('" + id_prod_ass_det + "', '" + GVData.GetRowCellValue(i, "id_prod_order_det").ToString + "', '" + GVData.GetRowCellValue(i, "id_product").ToString + "', '" + GVData.GetRowCellValue(i, "qty_sel").ToString + "') "
                        jum_ins_j = jum_ins_j + 1
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_ins, True, "", "", "", "")
                    End If

                    'update 
                    Dim qty_foc As String = FormProductionAssemblySingle.GVItemList.GetFocusedRowCellValue("prod_ass_det_qty").ToString
                    Dim note_foc As String = addSlashes(FormProductionAssemblySingle.GVItemList.GetFocusedRowCellValue("prod_ass_det_note").ToString)
                    Dim query_upd As String = "UPDATE tb_prod_ass_det SET prod_ass_det_qty='" + qty_foc + "',
                prod_ass_det_note='" + note_foc + "' WHERE id_prod_ass_det=" + id_prod_ass_det + " "
                    execute_non_query(query_upd, True, "", "", "", "")

                    makeSafeGV(GVData)
                    GCData.DataSource = Nothing
                    FormProductionAssembly.viewData()
                    FormProductionAssembly.GVData.FocusedRowHandle = find_row(FormProductionAssembly.GVData, "id_prod_ass", FormProductionAssemblySingle.id_prod_ass)
                    FormProductionAssemblySingle.viewDetailComponent()
                    FormProductionAssemblySingle.viewBom()
                    data_par = Nothing
                    data_par = FormProductionAssemblySingle.GCComponent.DataSource
                End If
            Else
                stopCustom("No item selected")
                makeSafeGV(GVData)
            End If
        ElseIf id_pop_up = "1" Then
            'cek
            Dim dt_cek As DataTable = execute_query("CALL view_stock_prod_rec(" + SLEDesignStockStore.EditValue.ToString + ", 0, 0, 0, 0, 0, 0)", -1, True, "", "", "", "")
            Dim cond_check_data As Boolean = True
            For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                Dim id_prod_order_det_cekya As String = GVData.GetRowCellValue(i, "id_prod_order_det").ToString
                Dim qty_cek As Integer = GVData.GetRowCellValue(i, "qty_sel")

                'check qty
                Dim data_filter_cek As DataRow() = dt_cek.Select("[id_prod_order_det]='" + id_prod_order_det_cekya + "' ")
                Dim info_str As String = ""
                If qty_cek > data_filter_cek(0)("qty") Then
                    info_str += "Can't exceed " + Decimal.Parse(data_filter_cek(0)("qty").ToString).ToString("n0") + "; "
                    cond_check_data = False
                ElseIf qty_cek = 0 Then
                    info_str += "Qty can't zero; "
                    cond_check_data = False
                End If
                GVData.SetRowCellValue(i, "info", info_str)
            Next
            GCData.RefreshDataSource()
            GVData.RefreshData()

            If Not cond_check_data Then
                GridColumnInfo.VisibleIndex = 100
                stopCustom("Please see notice in 'info' column.")
            Else
                Dim data_par_main As DataTable = FormProductionAssemblySingle.GCItemList.DataSource
                GridColumnInfo.Visible = False
                Dim query_ins As String = "INSERT INTO tb_prod_ass_comp_det(id_prod_ass_det, id_prod_order_det, id_product, prod_ass_comp_qty_det) VALUES "
                Dim jum_ins_j As Integer = 0
                For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                    If jum_ins_j > 0 Then
                        query_ins += ", "
                    End If
                    Dim dt_filter As DataRow() = data_par_main.Select("[id_size]='" + GVData.GetRowCellValue(i, "id_size").ToString + "' ")
                    id_prod_ass_det = dt_filter(0)("id_prod_ass_det").ToString
                    query_ins += "('" + id_prod_ass_det + "', '" + GVData.GetRowCellValue(i, "id_prod_order_det").ToString + "', '" + GVData.GetRowCellValue(i, "id_product").ToString + "', '" + GVData.GetRowCellValue(i, "qty_sel").ToString + "') "
                    jum_ins_j = jum_ins_j + 1
                Next
                If jum_ins_j > 0 Then
                    execute_non_query(query_ins, True, "", "", "", "")
                End If

                'update qty main
                Dim query_upd_main As String = "UPDATE tb_prod_ass_det main
                INNER JOIN (
	                SELECT ad.id_prod_ass_det, acd.prod_ass_comp_qty_det AS `qty`
	                FROM tb_prod_ass_comp_det acd
	                INNER JOIN tb_prod_ass_det ad ON ad.id_prod_ass_det = acd.id_prod_ass_det
	                WHERE ad.id_prod_ass=" + FormProductionAssemblySingle.id_prod_ass + "
	                GROUP BY acd.id_prod_ass_det
                ) src ON src.id_prod_ass_det = main.id_prod_ass_det
                SET main.prod_ass_det_qty = src.qty "
                execute_non_query(query_upd_main, True, "", "", "", "")

                FormProductionAssembly.viewData()
                FormProductionAssembly.GVData.FocusedRowHandle = find_row(FormProductionAssembly.GVData, "id_prod_ass", FormProductionAssemblySingle.id_prod_ass)
                FormProductionAssemblyQuickAdd.viewData()
                FormProductionAssemblySingle.viewDetail()
                FormProductionAssemblySingle.viewBom()
                Close()
            End If
        End If
        Cursor = Cursors.Default
    End Sub
End Class