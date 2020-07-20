Public Class FormSalesBranch
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public rmt As String = "254"

    Private Sub FormSalesBranch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt_now As DataTable = execute_query("SELECT DATE(NOW()) as tgl", -1, True, "", "", "", "")
        DEFromList.EditValue = dt_now.Rows(0)("tgl")
        DEUntilList.EditValue = dt_now.Rows(0)("tgl")

        viewCoaTag()
        If XTCData.SelectedTabPageIndex = "256" Then
            XTPCN.PageVisible = True
        End If
    End Sub

    Sub viewCoaTag()
        Dim query As String = "SELECT ct.id_coa_tag, ct.tag_code, ct.tag_description, CONCAT(ct.tag_code,' - ', ct.tag_description)  AS `coa_tag`
        FROM tb_coa_tag ct WHERE ct.id_coa_tag>1 ORDER BY ct.id_coa_tag ASC "
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        'date
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromList.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilList.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim where_string As String = "AND (DATE(created_date)>='" + date_from_selected + "' AND DATE(created_date)<='" + date_until_selected + "') "

        'rmt
        where_string += "AND b.report_mark_type='" + rmt + "' "

        Dim sb As New ClassSalesBranch()
        Dim query As String = sb.queryMain(where_string, "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSalesBranch_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        If XTCData.SelectedTabPageIndex = 0 Then
            If GVData.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
                noManipulating()
            End If
        Else
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Sub noManipulating()
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
    End Sub

    Private Sub FormSalesBranch_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BViewPayment_Click(sender As Object, e As EventArgs) Handles BViewPayment.Click
        viewData()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub XTCData_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCData.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub SLEUnit_EditValueChanged(sender As Object, e As EventArgs) Handles SLEUnit.EditValueChanged
        GCSales.DataSource = Nothing
        BCreateCN.Visible = False
    End Sub

    Private Sub BtnViewSalesList_Click(sender As Object, e As EventArgs) Handles BtnViewSalesList.Click
        Cursor = Cursors.WaitCursor
        'minimum date
        Dim query_closing As String = "SELECT DATE_FORMAT(l.date_until,'%Y-%m-%d') AS `closing_date` FROM tb_closing_log l WHERE l.note='Closing End' ORDER BY l.id DESC LIMIT 1 "
        Dim closing_date As String = execute_query(query_closing, 0, True, "", "", "", "")
        Dim query As String = "SELECT m.id_sales_branch, m.number, m.transaction_date
        FROM (
	        SELECT d.id_sales_branch_det, d.value-IFNULL(cn.amount_cn,0.00) AS `amount_limit`, m.id_sales_branch, m.number, m.transaction_date, m.id_coa_tag
	        FROM tb_sales_branch_det d
	        INNER JOIN tb_sales_branch m ON m.id_sales_branch = d.id_sales_branch
	        LEFT JOIN (
		        SELECT d.id_sales_branch_ref_det, SUM(d.value) AS `amount_cn`
		        FROM tb_sales_branch_det d
		        INNER JOIN tb_sales_branch m ON m.id_sales_branch = d.id_sales_branch
		        WHERE m.id_report_status!=5 
		        GROUP BY d.id_sales_branch_ref_det
	        ) cn ON cn.id_sales_branch_ref_det = d.id_sales_branch_det
	        WHERE m.id_report_status=6 AND m.report_mark_type=254 AND d.is_close=2 
	        HAVING amount_limit>0
        ) m
        WHERE m.transaction_date>'" + closing_date + "' AND m.id_coa_tag='" + SLEUnit.EditValue.ToString + "'
        GROUP BY m.id_sales_branch "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSales.DataSource = data
        GVSales.BestFitColumns()
        If GVSales.RowCount > 0 Then
            BCreateCN.Visible = True
        End If
        Cursor = Cursors.Default
    End Sub
End Class