Public Class FormBudgetRevPropose
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public is_new As Boolean = False

    Private Sub FormBudgetRevPropose_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewYear()
        viewMonth()
    End Sub

    Sub viewMonth()
        Dim query As String = "SELECT * FROM tb_lookup_month m ORDER BY m.id_month ASC "
        viewLookupQuery(LEMonthFrom, query, 0, "month", "id_month")
        viewLookupQuery(LEMonthUntil, query, 0, "month", "id_month")
    End Sub

    Sub viewYear()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        Dim j As Integer = 0
        Dim dym As DataTable = execute_query("SELECT YEAR(DATE_ADD(NOW(),INTERVAL 10 YEAR)) AS `ym`", -1, True, "", "", "", "")
        For i As Integer = 2018 To dym.Rows(0)("ym")
            If j > 0 Then
                query += "UNION ALL "
            End If
            query += "SELECT " + i.ToString + " AS `year` "
            j += 1
        Next
        viewLookupQuery(LEYear, query, 0, "year", "year")
        Cursor = Cursors.Default
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim r As New ClassBudgetRevPropose()
        Dim query As String = r.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRev.DataSource = data
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Sub viewRevision()
        Cursor = Cursors.WaitCursor
        Dim r As New ClassBudgetRevPropose()
        Dim query As String = r.queryMainRev("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRevision.DataSource = data
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormBudgetRevPropose_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormBudgetRevPropose_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormBudgetRevPropose_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub check_menu()
        If XTCRev.SelectedTabPageIndex = 0 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            button_main(bnew_active, bedit_active, bdel_active)
        ElseIf XTCRev.SelectedTabPageIndex = 1 Then
            If GVRev.RowCount < 1 Then
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
        ElseIf XTCRev.SelectedTabPageIndex = 2 Then
            If GVRevision.RowCount < 1 Then
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
        End If
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = 0
            If XTCRev.SelectedTabPageIndex = 1 Then
                indeks = GVRev.FocusedRowHandle
            ElseIf XTCRev.SelectedTabPageIndex = 2 Then
                indeks = GVRevision.FocusedRowHandle
            End If
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVRev_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRev.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVRev_DoubleClick(sender As Object, e As EventArgs) Handles GVRev.DoubleClick
        Cursor = Cursors.WaitCursor
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Sub openNewTrans()
        If is_new Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            is_new = False
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub XTCRev_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCRev.SelectedPageChanged
        check_menu()
        If XTCRev.SelectedTabPageIndex = 0 Then

        ElseIf XTCRev.SelectedTabPageIndex = 1 Then
            viewData()
        ElseIf XTCRev.SelectedTabPageIndex = 2 Then
            viewRevision()
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewDataMain()
    End Sub

    Sub viewDataMain()
        Cursor = Cursors.WaitCursor

        'periode
        Dim from As String = LEMonthFrom.EditValue.ToString
        Dim until As String = LEMonthUntil.EditValue.ToString

        Dim query As String = "SELECT c.id_comp AS `id_store`, c.comp_number, c.comp_name,cg.comp_group,
        IFNULL(SUM(case when r.month = '1' THEN r.b_revenue END),0) AS `1_budget`,
        IFNULL(SUM(case when r.month = '2' THEN r.b_revenue END),0) AS `2_budget`,
        IFNULL(SUM(case when r.month= '3' THEN r.b_revenue END),0) AS `3_budget`,
        IFNULL(SUM(case when r.month = '4' THEN r.b_revenue END),0) AS `4_budget`,
        IFNULL(SUM(case when r.month = '5' THEN r.b_revenue END),0) AS `5_budget`,
        IFNULL(SUM(case when r.month = '6' THEN r.b_revenue END),0) AS `6_budget`,
        IFNULL(SUM(case when r.month = '7' THEN r.b_revenue END),0) AS `7_budget`,
        IFNULL(SUM(case when r.month = '8' THEN r.b_revenue END),0) AS `8_budget`,
        IFNULL(SUM(case when r.month = '9' THEN r.b_revenue END),0) AS `9_budget`,
        IFNULL(SUM(case when r.month = '10' THEN r.b_revenue END),0) AS `10_budget`,
        IFNULL(SUM(case when r.month = '11' THEN r.b_revenue END),0) AS `11_budget`,
        IFNULL(SUM(case when r.month = '12' THEN r.b_revenue END),0) AS `12_budget`,
        0 AS `1_actual`,
        0 AS `2_actual`,
        0 AS `3_actual`,
        0 AS `4_actual`,
        0 AS `5_actual`,
        0 AS `6_actual`,
        0 AS `7_actual`,
        0 AS `8_actual`,
        0 AS `9_actual`,
        0 AS `10_actual`,
        0 AS `11_actual`,
        0 AS `12_actual`
        FROM tb_b_revenue r
        INNER JOIN tb_m_comp c ON c.id_comp = r.id_store
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        LEFT JOIN (
            SELECT r.id_store, SUM(r.b_revenue) AS `b_revenue` 
            FROM tb_b_revenue r
            WHERE r.`year`='" + LEYear.EditValue.ToString + "' AND r.`month`<'" + from + "' AND r.is_active=1
            GROUP BY r.id_store 
        ) b ON b.id_store = r.id_store
        WHERE r.YEAR ='" + LEYear.EditValue.ToString + "' AND r.is_active=1 AND (r.month>='" + from + "' AND r.month<='" + until + "')
        GROUP BY r.id_store "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Dim dtb_hist As DataTable = Nothing
    Private Sub CEBudgetHistory_CheckedChanged(sender As Object, e As EventArgs) Handles CEBudgetHistory.CheckedChanged
        dtb_hist = Nothing
        GCBudgetHist.DataSource = Nothing
        If CEBudgetHistory.EditValue = True Then
            GroupControlBudgetRevision.Visible = True
            Dim query As String = "SELECT r.id_store, r.`month`, CONCAT(r.`month`,'_','budget') AS `col_name`, COUNT(r.month) AS `jum`  
            FROM tb_b_revenue_log l
            INNER JOIN tb_b_revenue r ON r.id_b_revenue = l.id_b_revenue
            WHERE r.`year`='" + LEYear.EditValue.ToString + "' AND l.report_mark_type=147
            GROUP BY r.id_store,r.`month`
            HAVING jum>0 "
            dtb_hist = execute_query(query, -1, True, "", "", "", "")
            viewBudgetHistory()
        Else
            GroupControlBudgetRevision.Visible = False
        End If
        AddHandler GVData.RowCellStyle, AddressOf custom_cell
        GCData.Focus()
    End Sub

    Sub viewBudgetHistory()
        Cursor = Cursors.WaitCursor
        If GVData.FocusedColumn.FieldName.ToString.Contains("_budget") Then
            Dim col_foc As String() = GVData.FocusedColumn.FieldName.ToString.Split("_")
            Dim col As String = col_foc(0)
            Dim month As String = col
            Dim id_store As String = GVData.GetFocusedRowCellValue("id_store").ToString
            Dim query As String = "SELECT IF(rl.report_mark_type=133,rp.number, rr.number) AS `trans_number`,
            rl.log_date AS `trans_date`, rl.value_old AS `trans_before_value`, rl.value_new AS `trans_after_value`, rl.id_report, rl.report_mark_type
            FROM tb_b_revenue_log rl
            INNER JOIN tb_b_revenue r ON r.id_b_revenue = rl.id_b_revenue
            LEFT JOIN tb_b_revenue_propose rp ON rp.id_b_revenue_propose = rl.id_report
            LEFT JOIN tb_b_revenue_revision rr ON rr.id_b_revenue_revision = rl.id_report
            WHERE r.`year`='" + LEYear.EditValue.ToString + "' AND r.id_store=" + id_store + " AND r.`month`='" + month + "'
            ORDER BY rl.id_b_revenue_log ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBudgetHist.DataSource = data
            GVBudgetHist.BestFitColumns()
        Else
            GCBudgetHist.DataSource = Nothing
            GVBudgetHist.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub custom_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If CEBudgetHistory.EditValue = True Then
            Dim currview As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            If e.Column.FieldName.ToString.Contains("_budget") Then
                Dim data_filter_cek As DataRow() = dtb_hist.Select("[id_store]='" + currview.GetRowCellValue(e.RowHandle, "id_store").ToString + "' AND [col_name]='" + e.Column.FieldName.ToString + "'")
                If data_filter_cek.Length > 0 Then
                    If e.Column.FieldName.ToString = data_filter_cek(0)("col_name").ToString Then
                        e.Appearance.BackColor = Color.Yellow
                    Else
                        e.Appearance.BackColor = Color.Empty
                    End If
                Else
                    e.Appearance.BackColor = Color.Empty
                End If
            End If
        Else
            e.Appearance.BackColor = Color.Empty
        End If
    End Sub

    Public Sub custom_cell_default(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If e.Column.FieldName.ToString.Contains("_budget") Then
            e.Appearance.BackColor = Color.Empty
        End If
    End Sub

    Private Sub GVRevision_DoubleClick(sender As Object, e As EventArgs) Handles GVRevision.DoubleClick
        If GVRevision.RowCount > 0 And GVRevision.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub GVData_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVData.FocusedColumnChanged
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 And CEBudgetHistory.EditValue = True Then
            viewBudgetHistory()
        End If
    End Sub

    Private Sub GVData_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVData.FocusedRowChanged
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 And CEBudgetHistory.EditValue = True Then
            viewBudgetHistory()
        End If
    End Sub

    Private Sub GVBudgetHist_DoubleClick(sender As Object, e As EventArgs) Handles GVBudgetHist.DoubleClick
        If GVBudgetHist.RowCount > 0 And GVBudgetHist.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_report As String = GVBudgetHist.GetFocusedRowCellValue("id_report").ToString
            Dim rmt As String = GVBudgetHist.GetFocusedRowCellValue("report_mark_type").ToString
            Dim p As New ClassShowPopUp()
            p.id_report = id_report
            p.report_mark_type = rmt
            p.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub LEMonthUntil_EditValueChanged(sender As Object, e As EventArgs) Handles LEMonthUntil.EditValueChanged
        If LEMonthUntil.EditValue < LEMonthFrom.EditValue Then
            LEMonthUntil.EditValue = LEMonthFrom.EditValue
        End If
    End Sub

    Private Sub LEMonthFrom_EditValueChanged(sender As Object, e As EventArgs) Handles LEMonthFrom.EditValueChanged
        LEMonthUntil.EditValue = LEMonthFrom.EditValue
    End Sub
End Class