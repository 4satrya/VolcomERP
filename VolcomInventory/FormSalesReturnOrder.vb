Public Class FormSalesReturnOrder 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormSalesReturnOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSalesReturnOrder()
    End Sub

    Sub viewSalesReturnOrder()
        Dim query As String = "SELECT a.id_sales_return_order, a.id_store_contact_to, (d.comp_name) AS store_name_to,a.id_report_status, f.report_status, "
        query += "a.sales_return_order_note, a.sales_return_order_note, a.sales_return_order_number, "
        query += "DATE_FORMAT(a.sales_return_order_date,'%d %M %Y') AS sales_return_order_date, "
        query += "DATE_FORMAT(a.sales_return_order_est_date,'%d %M %Y') AS sales_return_order_est_date, a.id_prepare_status, ps.prepare_status "
        query += "FROM tb_sales_return_order a "
        'query += "INNER JOIN tb_sales_return_order_det b ON a.id_sales_return_order = b.id_sales_return_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_lookup_prepare_status ps ON ps.id_prepare_status = a.id_prepare_status "
        query += "ORDER BY a.id_sales_return_order DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturnOrder.DataSource = data
        check_menu()
    End Sub

    Private Sub FormSalesReturnOrder_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormSalesReturnOrder_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
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
    End Sub

    Private Sub GVSalesReturnOrder_DoubleClick(sender As Object, e As EventArgs) Handles GVSalesReturnOrder.DoubleClick
        If GVSalesReturnOrder.RowCount > 0 And GVSalesReturnOrder.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class