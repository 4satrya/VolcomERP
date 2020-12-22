Public Class FormSalesOrderPacking 
    Public id_trans As String = "-1"
    Public id_cur_status As String = "-1"
    Public id_pop_up As String = "-1"

    Private Sub FormSalesOrderPacking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT * FROM tb_lookup_prepare_status a WHERE a.id_prepare_status>0 "
        If id_pop_up = "4" Or id_pop_up = "5" Then
            query += "AND a.id_prepare_status=2 "
        End If
        viewSearchLookupQuery(SLEPackingStatus, query, "id_prepare_status", "prepare_status", "id_prepare_status")
        If id_pop_up <> "4" And id_pop_up <> "5" Then
            SLEPackingStatus.EditValue = id_cur_status
        End If

        'cancell order by MD
        If id_pop_up = "6" Then
            SLEPackingStatus.EditValue = "2"
            SLEPackingStatus.Enabled = False
        End If
    End Sub

    Private Sub FormSalesOrderPacking_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to update Order Status?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            SimpleButton1.Enabled = False
            If id_pop_up = "-1" Then
                Cursor = Cursors.WaitCursor
                Dim query_upd As String = "UPDATE tb_sales_order SET id_prepare_status='" + SLEPackingStatus.EditValue.ToString + "' WHERE id_sales_order='" + id_trans + "' "
                execute_non_query(query_upd, True, "", "", "", "")
                FormSalesOrderList.viewSalesOrder()
                Close()
                Cursor = Cursors.Default
            ElseIf id_pop_up = "1" Then
                Cursor = Cursors.WaitCursor

                'closed stock
                Dim query_close_stock As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) "
                query_close_stock += "SELECT stc.id_wh_drawer, '1', stc.id_product, stc.bom_unit_price, stc.report_mark_type, stc.id_report, "
                query_close_stock += "SUM(IF(stc.id_stock_status='2', (IF(stc.id_storage_category='1', CONCAT('-', stc.storage_product_qty), stc.storage_product_qty)),'0')) AS `qty`, "
                query_close_stock += "NOW(), '', '2' "
                query_close_stock += "FROM tb_storage_fg stc "
                query_close_stock += "WHERE stc.report_mark_type=39 AND stc.id_report=" + id_trans + " "
                query_close_stock += "GROUP BY stc.id_product "
                query_close_stock += "HAVING qty>0 "
                execute_non_query(query_close_stock, True, "", "", "", "")

                Dim query_upd As String = "UPDATE tb_sales_order SET id_prepare_status='" + SLEPackingStatus.EditValue.ToString + "' WHERE id_sales_order='" + id_trans + "' "
                execute_non_query(query_upd, True, "", "", "", "")
                FormSalesOrderSvcLevel.viewSalesOrder()
                Close()
                Cursor = Cursors.Default
            ElseIf id_pop_up = "2" Then
                Cursor = Cursors.WaitCursor
                Dim query_upd As String = "UPDATE tb_sales_return_order SET id_prepare_status='" + SLEPackingStatus.EditValue.ToString + "' WHERE id_sales_return_order='" + id_trans + "' "
                execute_non_query(query_upd, True, "", "", "", "")
                FormSalesOrderSvcLevel.viewReturnOrder()
                Close()
                Cursor = Cursors.Default
            ElseIf id_pop_up = "3" Then
                Cursor = Cursors.WaitCursor
                Dim query_upd As String = "UPDATE tb_sales_return_order SET id_prepare_status='" + SLEPackingStatus.EditValue.ToString + "' WHERE id_sales_return_order='" + id_trans + "' "
                execute_non_query(query_upd, True, "", "", "", "")
                FormSalesOrderSvcLevel.viewReturnOrder()
                FormViewSalesReturnOrder.actionLoad()
                Close()
                Cursor = Cursors.Default
            ElseIf id_pop_up = "4" Then
                Cursor = Cursors.WaitCursor
                Dim final_comment As String = addSlashes(MENote.Text)
                Dim type_restock As String = FormSalesOrderSvcLevel.LETypeRestockTOO.EditValue.ToString
                Dim ord As New ClassSalesOrder()
                'oos action
                If type_restock = "2" Then
                    Dim is_processed_order As String = get_setup_field("is_processed_order")
                    If is_processed_order = "1" Then
                        stopCustom("Sync still running")
                        Cursor = Cursors.Default
                        Exit Sub
                    Else
                        ord.setProceccedWebOrder("1")
                    End If
                End If
                Dim qry As String = ""
                Dim qry_stt As String = ""
                For i As Integer = 0 To ((FormSalesOrderSvcLevel.GVSalesOrder.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVSalesOrder))
                    If i > 0 Then
                        qry += "OR "
                        qry_stt += "OR "
                    End If
                    qry += "stc.id_report='" + FormSalesOrderSvcLevel.GVSalesOrder.GetRowCellValue(i, "id_sales_order").ToString + "' "
                    qry_stt += "id_sales_order='" + FormSalesOrderSvcLevel.GVSalesOrder.GetRowCellValue(i, "id_sales_order").ToString + "' "
                Next
                If qry <> "" Then
                    'closed stock
                    Dim query_close_stock As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) "
                    query_close_stock += "SELECT stc.id_wh_drawer, '1', stc.id_product, stc.bom_unit_price, stc.report_mark_type, stc.id_report, "
                    query_close_stock += "SUM(IF(stc.id_stock_status='2', (IF(stc.id_storage_category='1', CONCAT('-', stc.storage_product_qty), stc.storage_product_qty)),'0')) AS `qty`, "
                    query_close_stock += "NOW(), '', '2' "
                    query_close_stock += "FROM tb_storage_fg stc "
                    query_close_stock += "WHERE stc.report_mark_type=39 AND (" + qry + ") "
                    query_close_stock += "GROUP BY stc.id_product,stc.id_report "
                    query_close_stock += "HAVING qty>0 "
                    execute_non_query(query_close_stock, True, "", "", "", "")

                    Dim query_upd As String = "UPDATE tb_sales_order SET id_prepare_status='" + SLEPackingStatus.EditValue.ToString + "', final_comment='" + final_comment + "', final_date=NOW(), final_by='" + id_user + "' WHERE (" + qry_stt + ") "
                    execute_non_query(query_upd, True, "", "", "", "")

                    'oos action
                    If type_restock = "2" Then
                        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                            FormMain.SplashScreenManager1.ShowWaitForm()
                        End If
                        For o As Integer = 0 To ((FormSalesOrderSvcLevel.GVSalesOrder.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVSalesOrder))
                            Dim id_oos As String = FormSalesOrderSvcLevel.GVSalesOrder.GetRowCellValue(o, "id_ol_store_oos").ToString
                            Dim qoss As String = "SELECT oos.id_ol_store_oos, oos.id_comp_group, oos.id_order, cg.id_api_type
                            FROM tb_ol_store_oos oos 
                            INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = oos.id_comp_group
                            WHERE oos.id_ol_store_oos='" + id_oos + "' "
                            Dim doss As DataTable = execute_query(qoss, -1, True, "", "", "", "")
                            If doss.Rows.Count > 0 Then
                                Dim id_comp_group As String = doss.Rows(0)("id_comp_group").ToString
                                Dim id_api_type As String = doss.Rows(0)("id_api_type").ToString
                                Dim id_web_order As String = doss.Rows(0)("id_order").ToString
                                'finalisasi restock
                                Dim oos As New ClassOLStore()
                                oos.oosRestockChecking(id_web_order, id_comp_group, id_oos, id_api_type)
                            End If
                        Next
                        ord.setProceccedWebOrder("2")
                        FormMain.SplashScreenManager1.CloseWaitForm()
                    End If
                    FormSalesOrderSvcLevel.viewSalesOrder()
                    Close()
                End If
                Cursor = Cursors.Default
            ElseIf id_pop_up = "5" Then
                Cursor = Cursors.WaitCursor
                Dim final_comment As String = addSlashes(MENote.Text)
                Dim qry As String = ""
                Dim qry_stt As String = ""
                Dim jum_so As Integer = 0
                For i As Integer = 0 To ((FormSalesOrderSvcLevel.GVSalesReturnOrder.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVSalesReturnOrder))
                    Dim id_sales_order As String = FormSalesOrderSvcLevel.GVSalesReturnOrder.GetRowCellValue(i, "id_sales_order").ToString
                    If i > 0 Then
                        qry_stt += "OR "
                    End If
                    qry_stt += "id_sales_return_order='" + FormSalesOrderSvcLevel.GVSalesReturnOrder.GetRowCellValue(i, "id_sales_return_order").ToString + "' "
                    If id_sales_order <> "0" Then
                        If jum_so > 0 Then
                            qry += "OR "
                        End If
                        qry += "stc.id_report='" + FormSalesOrderSvcLevel.GVSalesReturnOrder.GetRowCellValue(i, "id_sales_return_order").ToString + "' "
                        jum_so += 1
                    End If
                Next
                If qry <> "" Then
                    'closed stock
                    Dim query_close_stock As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) "
                    query_close_stock += "SELECT stc.id_wh_drawer, '1', stc.id_product, stc.bom_unit_price, stc.report_mark_type, stc.id_report, "
                    query_close_stock += "SUM(IF(stc.id_stock_status='2', (IF(stc.id_storage_category='1', CONCAT('-', stc.storage_product_qty), stc.storage_product_qty)),'0')) AS `qty`, "
                    query_close_stock += "NOW(), '', '2' "
                    query_close_stock += "FROM tb_storage_fg stc "
                    query_close_stock += "WHERE stc.report_mark_type=119 AND (" + qry + ") "
                    query_close_stock += "GROUP BY stc.id_product,stc.id_report "
                    query_close_stock += "HAVING qty>0 "
                    execute_non_query(query_close_stock, True, "", "", "", "")
                End If
                If qry_stt <> "" Then
                    Dim query_upd As String = "UPDATE tb_sales_return_order SET id_prepare_status='" + SLEPackingStatus.EditValue.ToString + "', final_comment='" + final_comment + "', final_date=NOW(), final_by='" + id_user + "' WHERE (" + qry_stt + ") "
                    execute_non_query(query_upd, True, "", "", "", "")
                    FormSalesOrderSvcLevel.viewReturnOrder()
                    Close()
                End If
                Cursor = Cursors.Default
            ElseIf id_pop_up = "6" Then
                'cancell by MD
                Cursor = Cursors.WaitCursor
                If Not FormSalesOrder.isWHProcess() Then
                    Dim final_comment As String = addSlashes(MENote.Text)
                    Dim id_so As String = FormSalesOrder.GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
                    Dim id_user_special As String = FormSalesOrder.id_user_special
                    Dim so As New ClassSalesOrder()
                    so.cancelReservedStock(id_so)

                    'update stt
                    Dim query_upd As String = "UPDATE tb_sales_order SET id_prepare_status='" + SLEPackingStatus.EditValue.ToString + "', final_comment='" + final_comment + "', final_date=NOW(), final_by='" + id_user_special + "' WHERE id_sales_order='" + id_so + "' "
                    execute_non_query(query_upd, True, "", "", "", "")
                    FormSalesOrder.viewSalesOrder()
                    FormSalesOrder.GVSalesOrder.FocusedRowHandle = find_row(FormSalesOrder.GVSalesOrder, "id_sales_order", id_so)
                    FormSalesOrder.id_user_special = "-1"
                    Close()
                Else
                    warningCustom("Already process by Warehouse Department")
                End If
                Cursor = Cursors.Default
            End If
        End If
    End Sub
End Class