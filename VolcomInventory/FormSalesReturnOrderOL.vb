Public Class FormSalesReturnOrderOL
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Sub viewSalesReturnOrder()
        Cursor = Cursors.WaitCursor
        Dim query_c As ClassSalesReturnOrder = New ClassSalesReturnOrder()
        Dim cond As String = ""

        'date
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        cond += "AND (a.sales_return_order_date>='" + date_from_selected + "' AND a.sales_return_order_date<='" + date_until_selected + "') "
        cond += "AND d.id_commerce_type=2 "
        Dim query As String = query_c.queryMain(cond, "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturnOrder.DataSource = data
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Sub viewPendingCNOLStore()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT so.sales_order_ol_shop_number AS `order_number`, so.customer_name, c.comp_number, c.comp_name
        FROM tb_ol_store_ret_list l
        INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = l.id_ol_store_ret_det
        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = rd.id_sales_order_det
        INNER JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
        INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order 
        LEFT JOIN (
	        SELECT spd.id_ol_store_ret_list 
            FROM tb_sales_pos_det spd
	        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
	        WHERE sp.id_report_status!=5 AND !ISNULL(spd.id_ol_store_ret_list)
	        GROUP BY spd.id_ol_store_ret_list
        ) e ON e.id_ol_store_ret_list = l.id_ol_store_ret_list 
        WHERE l.id_ol_store_ret_stt=6 AND ISNULL(e.id_ol_store_ret_list)
        GROUP BY c.id_comp, so.sales_order_ol_shop_number "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPending.DataSource = data
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSalesReturnOrderOL_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSalesReturnOrderOL_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If XTCROR.SelectedTabPageIndex = 0 Then
            If GVSalesReturnOrder.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                'noManipulating()
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                'noManipulating()
            End If
        ElseIf XTCROR.SelectedTabPageIndex = 1 Then
            If GVPending.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                'noManipulating()
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                'noManipulating()
            End If
        End If
    End Sub

    Private Sub FormSalesReturnOrderOL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'date now
        Dim data As DataTable = execute_query("SELECT DATE(NOW()) AS `tgl`", -1, True, "", "", "", "")
        DEFrom.EditValue = data.Rows(0)("tgl")
        DEUntil.EditValue = data.Rows(0)("tgl")
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewSalesReturnOrder()
    End Sub

    Private Sub GVSalesReturnOrder_DoubleClick(sender As Object, e As EventArgs) Handles GVSalesReturnOrder.DoubleClick
        If GVSalesReturnOrder.RowCount > 0 And GVSalesReturnOrder.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class