Public Class FormSalesPOS
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim current_year As String

    'selected-Tab1
    Public id_store_selected As String = "-1"
    Public label_store_selected As String = "-1"
    Public date_from_selected As String = "0000-01-01"
    Public date_until_selected As String = "9999-12-01"
    Public label_type_selected As String = "1"
    Public dt As DataTable

    'menu : 1=invoice 2=credit note
    Public id_menu As String = "1"

    Private Sub FormSalesPOS_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSalesPOS_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormSalesPOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'General
        'Dim query_curr_year As String = "SELECT YEAR(NOW())"
        'current_year = execute_query(query_curr_year, 0, True, "", "", "", "")

        'setting menu
        If id_menu = "1" Then
            Text = "Invoice"
        ElseIf id_menu = "2" Then
            Text = "Credit Note"
        ElseIf id_menu = "3" Then
            Text = "Invoice Missing Promo"
        ElseIf id_menu = "4" Then
            Text = "Invoice Missing Staff"
        ElseIf id_menu = "5" Then
            Text = "Credit Note Online Store"
        End If

        'Tab Daily
        viewStore()
        viewOption()
        DEFrom.DateTime = Now
        DEUntil.DateTime = Now
        viewSalesPOS()
    End Sub

    '========= TAB DAILY TRANSACTION==========================================
    Sub viewSalesPOS()
        Try
            Dim query_c As ClassSalesInv = New ClassSalesInv()
            Dim query As String = ""
            If id_menu = "1" Then
                query = query_c.queryMain("And (a.id_memo_type=''1'' OR a.id_memo_type=''3'') AND c.id_comp LIKE ''" + id_store_selected + "'' AND (a.sales_pos_end_period >=''" + date_from_selected + "'' AND a.sales_pos_end_period <=''" + date_until_selected + "'') ", "2")
            ElseIf id_menu = "2" Then
                query = query_c.queryMain("AND (a.id_memo_type=''2'' OR a.id_memo_type=''4'') AND c.id_comp LIKE ''" + id_store_selected + "'' AND (a.sales_pos_end_period >=''" + date_from_selected + "'' AND a.sales_pos_end_period <=''" + date_until_selected + "'') ", "2")
            ElseIf id_menu = "3" Then
                query = query_c.queryMain("AND (a.id_memo_type=''5'') AND c.id_comp LIKE ''" + id_store_selected + "'' AND (a.sales_pos_end_period >=''" + date_from_selected + "'' AND a.sales_pos_end_period <=''" + date_until_selected + "'') ", "2")
            ElseIf id_menu = "4" Then
                query = query_c.queryMain("AND (a.id_memo_type=''8'') AND c.id_comp LIKE ''" + id_store_selected + "'' AND (a.sales_pos_end_period >=''" + date_from_selected + "'' AND a.sales_pos_end_period <=''" + date_until_selected + "'') ", "2")
            ElseIf id_menu = "5" Then
                query = query_c.queryMain("AND a.id_memo_type=''2'' AND !ISNULL(a.id_sales_pos_ref) AND c.id_comp LIKE ''" + id_store_selected + "'' AND (a.sales_pos_end_period >=''" + date_from_selected + "'' AND a.sales_pos_end_period <=''" + date_until_selected + "'') ", "2")
            End If

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCSalesPOS.DataSource = data
            dt = data
            check_menu()
            GVSalesPOS.BestFitColumns()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Function CreateData() As DataTable
        Dim query As String = ""
        query += "SELECT f.so_type, a.id_report_status, a.id_sales_pos, a.sales_pos_date, a.sales_pos_note, "
        query += "a.sales_pos_number, (CONCAT_WS(' - ', c.comp_number, c.comp_name)) AS store_name_from, d.report_status, e.sales_pos_det_qty, a.sales_pos_total, a.sales_pos_discount, "
        query += "a.sales_pos_due_date, a.sales_pos_total, a.sales_pos_vat, "
        query += "CONCAT_WS(' - ', DATE_FORMAT(a.sales_pos_start_period, '%d %M %Y') ,DATE_FORMAT(a.sales_pos_end_period, '%d %M %Y')) AS sales_pos_period, "
        query += "CAST(((a.sales_pos_total - ((a.sales_pos_discount/100) * a.sales_pos_total))) AS DECIMAL(13,2)) AS sales_pos_netto, "
        query += "CAST(((100/(100+a.sales_pos_vat))*(a.sales_pos_total-((a.sales_pos_discount/100)*a.sales_pos_total))) AS DECIMAL(13,2)) AS sales_pos_revenue, "
        query += "(IF(a.id_report_status='5' OR a.id_report_status ='6', '-', IF(DATEDIFF(NOW(), a.sales_pos_due_date)<=0, DATEDIFF(NOW(), a.sales_pos_due_date),CONCAT('+', DATEDIFF(NOW(), a.sales_pos_due_date))))) AS sales_pos_age "
        query += "FROM tb_sales_pos a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_store_contact_from = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp "
        query += "INNER JOIN tb_lookup_report_status d ON d.id_report_status = a.id_report_status "
        query += "INNER JOIN ( "
        query += "SELECT pos_det.id_sales_pos, SUM(pos_det.sales_pos_det_qty) AS sales_pos_det_qty FROM tb_sales_pos_det pos_det GROUP BY pos_det.id_sales_pos "
        query += ") e ON e.id_sales_pos = a.id_sales_pos "
        query += "INNER JOIN tb_lookup_so_type f ON f.id_so_type = a.id_so_type "
        query += "WHERE c.id_comp LIKE '" + id_store_selected + "' AND (a.sales_pos_end_period >='" + date_from_selected + "' AND a.sales_pos_end_period <='" + date_until_selected + "') "
        query += "AND a.id_memo_type='1' "
        query += "ORDER BY a.id_sales_pos ASC "
        Dim dtm As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim date_from_selectedx As String = "0001-01-01"
        If date_from_selected = "0000-01-01" Then
            date_from_selectedx = "0001-01-01"
        Else
            date_from_selectedx = date_from_selected
        End If

        'MsgBox(date_from_selected.ToString)
        If label_type_selected = "1" Then
            query = "CALL view_sales_pos('0')"
            Dim dtd_temp As DataTable = execute_query(query, -1, True, "", "", "", "")
            dtd_temp.DefaultView.RowFilter = "id_comp LIKE '" + id_store_selected + "' AND (sales_pos_end_period >=#" + date_from_selectedx + "# AND sales_pos_end_period <=#" + date_until_selected + "#) "
            Dim dtd As DataTable = dtd_temp.DefaultView.ToTable
            Dim ds As New DataSet()
            ds.Tables.AddRange(New DataTable() {dtm, dtd})
            ds.Relations.Add("Detail Transaction", dtm.Columns("id_sales_pos"), dtd.Columns("id_sales_pos"))
        End If
        Return dtm
    End Function

    Sub check_menu()
        If XTCPOS.SelectedTabPageIndex = 0 Then
            If GVSalesPOS.RowCount < 1 Then
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
        End If
    End Sub

    Sub viewStore()
        Dim query As String = getQueryStore()
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            If i = 0 Then
                label_store_selected = data.Rows(i)("comp_name_label").ToString
                Exit For
            End If
        Next
        SLEStore.Properties.DataSource = Nothing
        SLEStore.Properties.DataSource = data
        SLEStore.Properties.DisplayMember = "comp_name_label"
        SLEStore.Properties.ValueMember = "id_comp"
        If data.Rows.Count.ToString >= 1 Then
            SLEStore.EditValue = data.Rows(0)("id_comp").ToString
        Else
            SLEStore.EditValue = Nothing
        End If
    End Sub

    Private Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor

        'hide/show expand
        'label_type_selected = LEOptionView.EditValue.ToString
        'If label_type_selected = "1" Then
        '    BExpand.Visible = True
        '    BHide.Visible = True
        'Else
        '    BExpand.Visible = False
        '    BHide.Visible = False
        'End If

        'Prepare paramater
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

        Try
            id_store_selected = SLEStore.EditValue.ToString
        Catch ex As Exception
        End Try

        'modify value
        If id_store_selected = "0" Then
            label_store_selected = "All Store"
            id_store_selected = "%%"
        Else
            label_store_selected = SLEStore.Properties.View.GetFocusedRowCellValue("comp_name_label").ToString
        End If

        viewSalesPOS()
        Cursor = Cursors.Default
    End Sub

    Sub viewOption()
        Dim query As String = getOptionView()
        viewLookupQuery(LEOptionView, query, 0, "option_view", "id_option_view")
    End Sub

    Public Sub ExpandAllRows(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView)
        View.BeginUpdate()
        Try
            Dim dataRowCount As Integer = View.DataRowCount
            Dim rHandle As Integer
            For rHandle = 0 To dataRowCount - 1
                View.SetMasterRowExpanded(rHandle, True)
            Next
        Finally
            View.EndUpdate()
        End Try
    End Sub

    Public Sub HideAllRows(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView)
        View.BeginUpdate()
        Try
            Dim dataRowCount As Integer = View.DataRowCount
            Dim rHandle As Integer
            For rHandle = 0 To dataRowCount - 1
                View.SetMasterRowExpanded(rHandle, False)
            Next
        Finally
            View.EndUpdate()
        End Try
    End Sub

    Private Sub BExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BExpand.Click
        ExpandAllRows(GVSalesPOS)
    End Sub

    Private Sub BHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BHide.Click
        HideAllRows(GVSalesPOS)
    End Sub

    Private Sub GVSalesPOS_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSalesPOS.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVSalesPOSDet_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSalesPOSDet.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnNoStock_Click(sender As Object, e As EventArgs) Handles BtnNoStock.Click
        Cursor = Cursors.WaitCursor
        If id_departement_user = "14" Then 'IA
            FormSalesPOSNoStock.id_menu = "2"
        Else
            FormSalesPOSNoStock.id_menu = "1"
        End If
        FormSalesPOSNoStock.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesPOS_DoubleClick(sender As Object, e As EventArgs) Handles GVSalesPOS.DoubleClick
        If GVSalesPOS.RowCount > 0 And GVSalesPOS.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub
End Class