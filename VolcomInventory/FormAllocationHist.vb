Public Class FormAllocationHist
    Private Sub FormAllocationHist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tgl As DateTime = getTimeDB()
        DEFrom.EditValue = tgl
        DEUntil.EditValue = tgl
    End Sub

    Private Sub FormAllocationHist_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        GCData.DataSource = Nothing
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        GCData.DataSource = Nothing
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
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
        cond += "AND (so.sales_order_date>='" + date_from_selected + "' AND so.sales_order_date<='" + date_until_selected + "') "

        Dim query As String = "SELECT so.id_sales_order, so.sales_order_number, IFNULL(sod.order_qty,0) AS `order_qty`, so.sales_order_date AS `order_date`, 
        emp.employee_name AS `order_by`, so_stt.report_status AS `order_status`,
        f.comp_number AS `comp_number_from`, f.comp_name AS `comp_name_from`,
        t.comp_number AS `comp_number_to`, t.comp_name AS `comp_name_to`,
        trf.id_fg_trf, trf.fg_trf_number AS `trf_number`, trf_stt.report_status AS `trf_status`
        FROM tb_sales_order so
        INNER JOIN tb_m_comp_contact fc ON fc.id_comp_contact = so.id_warehouse_contact_to
        INNER JOIN tb_m_comp f ON f.id_comp = fc.id_comp
        INNER JOIN tb_m_comp_contact tc ON tc.id_comp_contact = so.id_store_contact_to
        INNER JOIN tb_m_comp t ON t.id_comp = tc.id_comp
        INNER JOIN tb_lookup_report_status so_stt ON so_stt.id_report_status = so.id_report_status
        INNER JOIN tb_m_user usr ON usr.id_user = so.id_user_created
        INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee
        INNER JOIN tb_fg_trf trf ON trf.id_sales_order = so.id_sales_order
        INNER JOIN tb_lookup_report_status trf_stt ON trf_stt.id_report_status = trf.id_report_status
        LEFT JOIN (
	        SELECT so.id_sales_order, SUM(sod.sales_order_det_qty) AS `order_qty`
	        FROM tb_sales_order_det sod
	        INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
	        WHERE so.id_report_status=6 AND so.is_transfer_data=1
	        GROUP BY sod.id_sales_order
        ) sod ON sod.id_sales_order = so.id_sales_order
        WHERE so.id_report_status=6 AND so.is_transfer_data=1 " + cond + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw(GCData,"")
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim sp As New ClassShowPopUp
            sp.id_report = GVData.GetFocusedRowCellValue("id_sales_order").ToString
            sp.report_mark_type = "39"
            sp.show()
        End If
    End Sub
End Class