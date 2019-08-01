Public Class FormAccountingFakturScan
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public id_dept As String = "-1"
    Private Sub FormAccountingFakturScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewTrans()

        'invoice
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        viewStore()

        'cek user
        Dim query As String = "SELECT * 
        FROM tb_m_user u 
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        INNER JOIN tb_m_departement d ON d.id_departement = e.id_departement
        WHERE u.id_user=" + id_user + " AND d.is_office_dept=1 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count <= 0 Then
            XTPInv.PageVisible = False
        End If
    End Sub

    Sub viewTrans()
        Dim query As String = "SELECT *, IF(a.id_faktur_type=2, a.acc_fak_scan_faktur_date, '-') AS `faktur_date_view` FROM tb_a_acc_fak_scan a INNER JOIN tb_lookup_faktur_type b ON a.id_faktur_type=b.id_faktur_type WHERE id_departement='" & id_departement_user & "' ORDER BY a.id_acc_fak_scan DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFak.DataSource = data
        check_menu()
    End Sub

    Sub viewStore()
        Dim query As String = "SELECT 0 AS `id_comp`, 'All' AS `comp_number`, 'All Store' AS `comp_name`, 'All Store' AS `comp`
        UNION
        SELECT c.id_comp, c.comp_number, c.comp_name, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp` FROM tb_m_comp c WHERE c.id_comp_cat=6 "
        viewSearchLookupQuery(SLEStore, query, "id_comp", "comp", "id_comp")
    End Sub

    Private Sub FormAccountingFakturScan_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormAccountingFakturScan_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVFak.RowCount < 1 Then
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
            'checkFormAccess(Name)
            'button_main(bnew_active, bedit_active, bdel_active)
            noManipulating()
        End If
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVFak.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GVFak_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFak.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVFak_DoubleClick(sender As Object, e As EventArgs) Handles GVFak.DoubleClick
        If GVFak.FocusedRowHandle >= 0 And GVFak.RowCount > 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewSalesInvoice()
    End Sub

    Sub viewSalesInvoice()
        Cursor = Cursors.WaitCursor
        Dim date_from_selected, date_until_selected As String
        date_from_selected = "0000-01-01"
        date_until_selected = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim cond As String = "AND (p.sales_pos_end_period>='" + date_from_selected + "' AND p.sales_pos_end_period<='" + date_until_selected + "') "

        Dim id_store As String = SLEStore.EditValue.ToString
        If id_store <> "0" Then
            cond += "HAVING id_comp=" + id_store + " "
        End If
        Dim query As String = "SELECT 'No' AS `is_select`,p.id_sales_pos, p.sales_pos_number, f.id_sales_pos_faktur,f.no_faktur, p.id_comp_contact_bill, 
        IF(ISNULL(p.id_comp_contact_bill), c.id_comp, cb.id_comp) AS `id_comp`, 
        IF(ISNULL(p.id_comp_contact_bill), CONCAT(c.comp_number, ' - ', c.comp_name) , CONCAT(cb.comp_number, ' - ', cb.comp_name) ) AS `comp`,
        IF(!ISNULL(f.id_sales_pos_faktur), f.npwp, IF(ISNULL(p.id_comp_contact_bill), c.npwp, cb.npwp)) AS `npwp`, 
        IF(!ISNULL(f.id_sales_pos_faktur), f.npwp_name, IF(ISNULL(p.id_comp_contact_bill), c.npwp_name, cb.npwp_name)) AS `npwp_name`, 
        IF(!ISNULL(f.id_sales_pos_faktur), f.npwp_address, IF(ISNULL(p.id_comp_contact_bill), c.npwp_address, cb.npwp_address)) AS `npwp_address`, 
        p.sales_pos_date, p.sales_pos_start_period, p.sales_pos_end_period, 
        p.sales_pos_total_qty, p.sales_pos_total,
        f.exported_date, e.employee_name AS `exported_by_name`
        FROM tb_sales_pos p 
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = p.id_store_contact_from
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        LEFT JOIN tb_m_comp_contact ccb ON ccb.id_comp_contact = p.id_comp_contact_bill
        LEFT JOIN tb_m_comp cb ON cb.id_comp = ccb.id_comp
        LEFT JOIN (
	        SELECT a.*, e.employee_name AS `updated_by_name`
            FROM  (	
	            SELECT f.id_sales_pos_faktur, f.id_sales_pos, f.no_faktur, f.npwp, f.npwp_name, f.npwp_address,
		        f.updated_at, f.updated_by, f.exported_date, f.exported_by 
		        FROM tb_sales_pos_faktur f
		        ORDER BY f.id_sales_pos_faktur DESC
	        ) a
	        INNER JOIN tb_m_user u ON u.id_user = a.updated_by
	        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
	        GROUP BY a.id_sales_pos
        ) f ON f.id_sales_pos = p.id_sales_pos
        LEFT JOIN tb_m_user u ON u.id_user = f.exported_by
        LEFT JOIN tb_m_employee e ON e.id_employee = u.id_employee
        WHERE p.id_report_status=6 " + cond + "
        ORDER BY p.id_sales_pos ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCInv.DataSource = data
        GVInv.BestFitColumns()
        Cursor = Cursors.Default
    End Sub
End Class