Public Class FormMailManageReturnPendingInvoice
    Public rmt As String = "-1"
    Public show_direct As Boolean = False

    Private Sub FormMailManageReturnPendingInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If rmt = "45" Then
            viewData()

            If show_direct Then
                FormMailManageReturn.already_open_invoice = True
                If GVData.RowCount <= 0 Then
                    Close()
                End If
            End If
            XTPSalesInvoice.PageVisible = True
        End If
    End Sub

    Private Sub FormMailManageReturnPendingInvoice_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT d.id_comp_group, cg.comp_group AS `group`, cg.description AS `group_description`, d.id_store_company, hc.comp_name AS `comp_group_office`, SUM(b.design_price * b.sales_return_order_det_qty) AS amount
                FROM tb_sales_return_order a
                INNER JOIN tb_sales_return_order_det b ON a.id_sales_return_order = b.id_sales_return_order
                INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to 
                INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
		LEFT JOIN tb_m_comp_group cg ON cg.id_comp_group = d.id_comp_group
		LEFT JOIN tb_m_comp hc ON hc.id_comp = d.id_store_company
                WHERE ISNULL(a.id_sales_order) AND a.is_on_hold = 2 AND a.id_report_status = 6 AND a.is_pending_mail = 1
                GROUP BY d.id_comp_group, d.id_store_company
                ORDER BY a.id_sales_return_order ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        If rmt = "45" Then
            If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
                Cursor = Cursors.WaitCursor
                FormMailManageReturn.SLEStoreGroup.EditValue = GVData.GetFocusedRowCellValue("id_comp_group").ToString
                FormMailManageReturn.SLEStoreCompany.EditValue = GVData.GetFocusedRowCellValue("id_store_company").ToString
                FormMailManageReturn.viewPendingInvoice()
                Close()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnViewDetail_Click(sender As Object, e As EventArgs) Handles BtnViewDetail.Click
        viewDetail()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        viewDetail()
    End Sub

    Private Sub GVUnpaidData_DoubleClick(sender As Object, e As EventArgs)
        viewDetail()
    End Sub
End Class