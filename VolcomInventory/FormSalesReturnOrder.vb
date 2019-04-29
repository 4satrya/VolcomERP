Public Class FormSalesReturnOrder 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Sub viewStore()
        Dim query As String = "SELECT 0 AS `id_comp`, '-' AS `comp_number` , 'All Store' AS `comp_name`
        UNION ALL
        SELECT c.id_comp,c.comp_number, CONCAT(c.comp_number,' - ', c.comp_name) AS `comp_name`
        FROM tb_m_comp c
        WHERE c.is_active=1 AND c.id_comp_cat=6
        ORDER BY comp_number ASC "
        viewSearchLookupQuery(SLEStore, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub FormSalesReturnOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewStore()
        viewSalesReturnOrder()
    End Sub

    Sub viewSalesReturnOrder()
        Dim query As String = "SELECT a.id_sales_return_order, a.id_store_contact_to, CONCAT(d.comp_number,' - ',d.comp_name) AS store_name_to,a.id_report_status, f.report_status, "
        query += "a.sales_return_order_note, a.sales_return_order_note, a.sales_return_order_number, "
        query += "DATE_FORMAT(a.sales_return_order_date,'%d %M %Y') AS sales_return_order_date, "
        query += "DATE_FORMAT(a.sales_return_order_est_date,'%d %M %Y') AS sales_return_order_est_date, a.id_prepare_status, ps.prepare_status "
        query += "FROM tb_sales_return_order a "
        'query += "INNER JOIN tb_sales_return_order_det b ON a.id_sales_return_order = b.id_sales_return_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_lookup_prepare_status ps ON ps.id_prepare_status = a.id_prepare_status "
        query += "WHERE ISNULL(a.id_sales_order) AND a.is_on_hold=2 "
        query += "ORDER BY a.id_sales_return_order DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturnOrder.DataSource = data
        check_menu()
    End Sub

    Sub viewOnHold()
        Cursor = Cursors.WaitCursor
        Dim id_comp As String = ""
        If SLEStore.EditValue.ToString = "0" Then
            id_comp = ""
        Else
            id_comp = "AND c.id_comp='" + SLEStore.EditValue.ToString + "' "
        End If

        Dim ro As New ClassSalesReturnOrder()
        Dim query As String = ro.queryOnHold(id_comp, "2", False, "0")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOnHold.DataSource = data
        GVOnHold.BestFitColumns()
        Cursor = Cursors.Default
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

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewOnHold()
    End Sub

    Private Sub GVOnHold_DoubleClick(sender As Object, e As EventArgs) Handles GVOnHold.DoubleClick
        If GVOnHold.RowCount > 0 And GVOnHold.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub ViewDetailOnHoldToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailOnHoldToolStripMenuItem.Click
        If GVOnHold.RowCount > 0 And GVOnHold.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub ShowWhereItIsUsedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowWhereItIsUsedToolStripMenuItem.Click
        'id_ro_ref
        If GVOnHold.RowCount > 0 And GVOnHold.FocusedRowHandle >= 0 Then
            Dim id_ro_ref As String = GVOnHold.GetFocusedRowCellValue("id_ro_ref").ToString
            Cursor = Cursors.WaitCursor
            If id_ro_ref <= "0" Then
                stopCustom("Transaction not found")
            Else
                FormSalesReturnOrderDet.id_sales_return_order = id_ro_ref
                FormSalesReturnOrderDet.action = "upd"
                FormSalesReturnOrderDet.ShowDialog()
            End If
            Cursor = Cursors.Default
        End If
    End Sub
End Class