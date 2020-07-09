Public Class FormRetOlStore
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormRetOlStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCompGroup()
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim pre As New ClassRetOLStore()
        Dim query As String = pre.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewCompGroup()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg
        INNER JOIN tb_m_comp c ON c.id_comp_group = cg.id_comp_group AND c.id_commerce_type=2
        GROUP BY cg.id_comp_group "
        viewSearchLookupQuery(SLECompGroup, query, "id_comp_group", "description", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub viewOrderList()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT c.id_comp_group,so.sales_order_ol_shop_number,req.`id_ol_store_ret_req`,req.`ret_req_number`,req.`ret_req_date`,so.sales_order_ol_shop_date AS `order_date`, so.customer_name
FROM tb_sales_order so
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
INNER JOIN `tb_ol_store_ret_req` req ON req.sales_order_ol_shop_number=so.sales_order_ol_shop_number AND req.id_report_status=6
WHERE so.id_report_status=6 AND c.id_commerce_type=2 AND c.id_comp_group='" + SLECompGroup.EditValue.ToString + "'
GROUP BY so.sales_order_ol_shop_number "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOrderList.DataSource = data
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormRetOlStore_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormRetOlStore_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If XTCData.SelectedTabPageIndex = 0 Then
            If GVData.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "0"
                bedit_active = "1"
                bdel_active = "0"
                noManipulating()
            End If
        ElseIf XTCData.SelectedTabPageIndex = 1 Then
            If GVOrderList.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                noManipulating()
            End If
        End If
    End Sub

    Sub noManipulating()
        If XTCData.SelectedTabPageIndex = 0 Then
            Dim indeks As Integer = -1
            Try
                indeks = GVData.FocusedRowHandle
            Catch ex As Exception
            End Try
            If indeks < 0 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        ElseIf XTCData.SelectedTabPageIndex = 1 Then
            Dim indeks As Integer = -1
            Try
                indeks = GVOrderList.FocusedRowHandle
            Catch ex As Exception
            End Try
            If indeks < 0 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SLECompGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLECompGroup.EditValueChanged
        GCOrderList.DataSource = Nothing
    End Sub

    Private Sub BtnViewOrder_Click(sender As Object, e As EventArgs) Handles BtnViewOrder.Click
        viewOrderList()
    End Sub

    Private Sub XTCData_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCData.SelectedPageChanged
        check_menu()
    End Sub
End Class