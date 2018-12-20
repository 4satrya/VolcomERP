Public Class FormBudgetExpenseView
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public is_view As String = "-1"

    Private Sub FormBudgetExpenseView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDept()
        viewCat()
        viewYear()
        viewMonth()

        ArcScaleComponent3.EnableAnimation = True
        ArcScaleComponent3.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseIn
        ArcScaleComponent3.EasingFunction = New DevExpress.XtraGauges.Core.Model.BounceEase
        ArcScaleComponent3.Value = 50.89
        LabelComponent3.Text = "50.89 %"
    End Sub

    Sub resetView()
        Cursor = Cursors.WaitCursor
        ArcScaleComponent3.Value = 0
        LabelComponent3.Text = "0%"
        GCData.DataSource = Nothing
        PanelChart.Visible = False
        TxtBudget.EditValue = 0.0
        TxtActual.EditValue = 0.0
        LEMonth.ItemIndex = LEMonth.Properties.GetDataSourceRowIndex("id_month", "0")
        Cursor = Cursors.Default
    End Sub

    Sub viewMonth()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_month`, 'All' AS `month`
        UNION ALL
        SELECT m.id_month, m.`month`
        FROM tb_lookup_month m 
        ORDER BY id_month ASC "
        viewLookupQuery(LEMonth, query, 0, "month", "id_month")
        Cursor = Cursors.Default
    End Sub

    Sub viewDept()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        query += "(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
        Cursor = Cursors.Default
    End Sub

    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_item_cat`, 'All Category' AS `item_cat`
        UNION ALL
        SELECT c.id_item_cat, c.item_cat FROM tb_item_cat c ORDER BY id_item_cat ASC"
        viewLookupQuery(LECat, query, 0, "item_cat", "id_item_cat")
        Cursor = Cursors.Default
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

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim cond_cat As String = ""
        If LECat.EditValue.ToString <> "0" Then
            cond_cat = "AND c.id_item_cat = '" + LECat.EditValue.ToString + "' "
        End If
        Dim query As String = "SELECT c.id_item_coa,coa.acc_name AS `exp_acc`, coa.acc_description AS `exp_description`, cat.item_cat, et.expense_type,
        IFNULL(SUM(case when MONTH(em.month) = '1' THEN em.value_expense END),0) AS `1_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '2' THEN em.value_expense END),0) AS `2_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '3' THEN em.value_expense END),0) AS `3_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '4' THEN em.value_expense END),0) AS `4_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '5' THEN em.value_expense END),0) AS `5_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '6' THEN em.value_expense END),0) AS `6_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '7' THEN em.value_expense END),0) AS `7_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '8' THEN em.value_expense END),0) AS `8_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '9' THEN em.value_expense END),0) AS `9_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '10' THEN em.value_expense END),0) AS `10_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '11' THEN em.value_expense END),0) AS `11_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '12' THEN em.value_expense END),0) AS `12_budget`,
        IFNULL(r.`1`,0) AS `1_actual`,
        IFNULL(r.`2`,0) AS `2_actual`,
        IFNULL(r.`3`,0) AS `3_actual`,
        IFNULL(r.`4`,0) AS `4_actual`,
        IFNULL(r.`5`,0) AS `5_actual`,
        IFNULL(r.`6`,0) AS `6_actual`,
        IFNULL(r.`7`,0) AS `7_actual`,
        IFNULL(r.`8`,0) AS `8_actual`,
        IFNULL(r.`9`,0) AS `9_actual`,
        IFNULL(r.`10`,0) AS `10_actual`,
        IFNULL(r.`11`,0) AS `11_actual`,
        IFNULL(r.`12`,0) AS `12_actual`
        FROM tb_b_expense_month em
        LEFT JOIN tb_b_expense e ON e.id_b_expense = em.id_b_expense
        LEFT JOIN tb_item_coa c ON c.id_item_coa = e.id_item_coa
        LEFT JOIN tb_item_cat cat ON cat.id_item_cat = c.id_item_cat
        LEFT JOIN tb_lookup_expense_type et ON et.id_expense_type = cat.id_expense_type
        LEFT JOIN tb_a_acc coa ON coa.id_acc = c.id_coa_out
        LEFT JOIN (
            SELECT jd.id_acc, 
            SUM(case when MONTH(j.date_created) = '1' THEN jd.debit END) AS `1`,
            SUM(case when MONTH(j.date_created) = '2' THEN jd.debit END) AS `2`,
            SUM(case when MONTH(j.date_created) = '3' THEN jd.debit END) AS `3`,
            SUM(case when MONTH(j.date_created) = '4' THEN jd.debit END) AS `4`,
            SUM(case when MONTH(j.date_created) = '5' THEN jd.debit END) AS `5`,
            SUM(case when MONTH(j.date_created) = '6' THEN jd.debit END) AS `6`,
            SUM(case when MONTH(j.date_created) = '7' THEN jd.debit END) AS `7`,
            SUM(case when MONTH(j.date_created) = '8' THEN jd.debit END) AS `8`,
            SUM(case when MONTH(j.date_created) = '9' THEN jd.debit END) AS `9`,
            SUM(case when MONTH(j.date_created) = '10' THEN jd.debit END) AS `10`,
            SUM(case when MONTH(j.date_created) = '11' THEN jd.debit END) AS `11`,
            SUM(case when MONTH(j.date_created) = '12' THEN jd.debit END) AS `12`
            FROM tb_a_acc_trans_det jd
            INNER JOIN tb_a_acc_trans j ON j.id_acc_trans = jd.id_acc_trans
            JOIN tb_opt_purchasing o
            WHERE (jd.report_mark_type=148 OR jd.report_mark_type=156 OR jd.report_mark_type=157 OR jd.report_mark_type=161 or jd.report_mark_type=166) 
            AND jd.debit <>0
            AND jd.id_acc<>o.acc_coa_receive
            AND jd.id_acc<>o.acc_coa_vat_in
            GROUP BY jd.id_acc
        ) r ON r.id_acc = coa.id_acc
        WHERE c.id_departement='" + LEDeptSum.EditValue.ToString + "' AND e.year='" + LEYear.Text.ToString + "' 
        " + cond_cat + "
        GROUP BY e.id_item_coa "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        If GVData.RowCount > 0 Then
            PanelChart.Visible = True
            LEMonth.ItemIndex = LEMonth.Properties.GetDataSourceRowIndex("id_month", "0")
            setGaugeInfo()
        End If
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub setGaugeInfo()
        'isi gauge
        Dim id_month As String = "0"
        Try
            id_month = LEMonth.EditValue.ToString
        Catch ex As Exception
        End Try

        If id_month = "0" Then
            TxtBudget.EditValue = GVData.Columns("total_budget").SummaryItem.SummaryValue
            TxtActual.EditValue = GVData.Columns("total_actual").SummaryItem.SummaryValue
            ArcScaleComponent3.Value = GVData.Columns("BandedGridColumn13").SummaryItem.SummaryValue
            LabelComponent3.Text = Decimal.Parse(GVData.Columns("BandedGridColumn13").SummaryItem.SummaryValue.ToString).ToString("N2") + "%"
        Else
            TxtBudget.EditValue = GVData.Columns(id_month + "_budget").SummaryItem.SummaryValue
            TxtActual.EditValue = GVData.Columns(id_month + "_actual").SummaryItem.SummaryValue
            ArcScaleComponent3.Value = GVData.Columns("BandedGridColumn" + id_month).SummaryItem.SummaryValue
            LabelComponent3.Text = Decimal.Parse(GVData.Columns("BandedGridColumn" + id_month).SummaryItem.SummaryValue.ToString).ToString("N2") + "%"
        End If
    End Sub

    Sub check_menu()
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
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVData.FocusedRowHandle
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

    Private Sub FormBudgetExpenseView_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormBudgetExpenseView_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Dim dtb_hist As DataTable = Nothing
    Private Sub CEBudgetHistory_CheckedChanged(sender As Object, e As EventArgs) Handles CEBudgetHistory.CheckedChanged
        dtb_hist = Nothing
        GCBudgetHist.DataSource = Nothing
        If CEBudgetHistory.EditValue = True Then
            GroupControlBudgetRevision.Visible = True
            Dim query As String = "SELECT c.id_item_coa, m.month, CONCAT(MONTH(m.month),'_','budget') AS `col_name`, COUNT(m.month) AS `jum` 
            FROM tb_b_expense_month_log ml
            INNER JOIN tb_b_expense_month m ON m.id_b_expense_month = ml.id_b_expense_month
            INNER JOIN tb_b_expense e ON e.id_b_expense = m.id_b_expense
            INNER JOIN tb_item_coa c ON c.id_item_coa = e.id_item_coa
            WHERE e.year='" + LEYear.EditValue.ToString + "' AND c.id_departement='" + LEDeptSum.EditValue.ToString + "' AND ml.report_mark_type=138 
            GROUP BY c.id_item_coa,m.month
            HAVING jum>0 "
            dtb_hist = execute_query(query, -1, True, "", "", "", "")
            viewBudgetHistory()
        Else
            GroupControlBudgetRevision.Visible = False
        End If
        AddHandler GVData.RowCellStyle, AddressOf custom_cell
        GCData.Focus()
    End Sub

    Public Sub custom_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If CEBudgetHistory.EditValue = True Then
            Dim currview As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            If e.Column.FieldName.ToString.Contains("_budget") Then
                Dim data_filter_cek As DataRow() = dtb_hist.Select("[id_item_coa]='" + currview.GetRowCellValue(e.RowHandle, "id_item_coa").ToString + "' AND [col_name]='" + e.Column.FieldName.ToString + "'")
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

    Private Sub GVData_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVData.FocusedColumnChanged
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 And CEBudgetHistory.EditValue = True Then
            viewBudgetHistory()
        End If
    End Sub

    Sub viewBudgetHistory()
        Cursor = Cursors.WaitCursor
        If GVData.FocusedColumn.FieldName.ToString.Contains("_budget") Then
            Dim col_foc As String() = GVData.FocusedColumn.FieldName.ToString.Split("_")
            Dim col As String = col_foc(0)
            Dim month As String = LEYear.Text + "-" + col + "-" + "01"
            Dim id_item_coa As String = GVData.GetFocusedRowCellValue("id_item_coa").ToString
            Dim query As String = "SELECT IF(ml.report_mark_type=136,p.number, r.number) AS `trans_number`,
            ml.log_date AS `trans_date`, ml.value_old AS `trans_before_value`, ml.value_new AS `trans_after_value`, ml.id_report, ml.report_mark_type
            FROM tb_b_expense_month_log ml
            INNER JOIN  tb_b_expense_month m ON m.id_b_expense_month = ml.id_b_expense_month
            INNER JOIN tb_b_expense e ON e.id_b_expense = m.id_b_expense
            INNER JOIN tb_item_coa c ON c.id_item_coa = e.id_item_coa
            LEFT JOIN tb_b_expense_propose p ON p.id_b_expense_propose = ml.id_report AND ml.report_mark_type=136
            LEFT JOIN tb_b_expense_revision r ON r.id_b_expense_revision = ml.id_report AND ml.report_mark_type=138
            WHERE e.year='" + LEYear.EditValue.ToString + "' AND c.id_departement='" + LEDeptSum.EditValue.ToString + "' AND e.id_item_coa='" + id_item_coa + "' AND m.month='" + month + "'
            ORDER BY ml.id_b_expense_month_log ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBudgetHist.DataSource = data
            GVBudgetHist.BestFitColumns()
        Else
            GCBudgetHist.DataSource = Nothing
            GVBudgetHist.BestFitColumns()
        End If
        Cursor = Cursors.Default
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

    Dim tot_1_budget As Decimal
    Dim tot_2_budget As Decimal
    Dim tot_3_budget As Decimal
    Dim tot_4_budget As Decimal
    Dim tot_5_budget As Decimal
    Dim tot_6_budget As Decimal
    Dim tot_7_budget As Decimal
    Dim tot_8_budget As Decimal
    Dim tot_9_budget As Decimal
    Dim tot_10_budget As Decimal
    Dim tot_11_budget As Decimal
    Dim tot_12_budget As Decimal
    Dim tot_1_budget_grp As Decimal
    Dim tot_2_budget_grp As Decimal
    Dim tot_3_budget_grp As Decimal
    Dim tot_4_budget_grp As Decimal
    Dim tot_5_budget_grp As Decimal
    Dim tot_6_budget_grp As Decimal
    Dim tot_7_budget_grp As Decimal
    Dim tot_8_budget_grp As Decimal
    Dim tot_9_budget_grp As Decimal
    Dim tot_10_budget_grp As Decimal
    Dim tot_11_budget_grp As Decimal
    Dim tot_12_budget_grp As Decimal
    Dim tot_1_actual As Decimal
    Dim tot_2_actual As Decimal
    Dim tot_3_actual As Decimal
    Dim tot_4_actual As Decimal
    Dim tot_5_actual As Decimal
    Dim tot_6_actual As Decimal
    Dim tot_7_actual As Decimal
    Dim tot_8_actual As Decimal
    Dim tot_9_actual As Decimal
    Dim tot_10_actual As Decimal
    Dim tot_11_actual As Decimal
    Dim tot_12_actual As Decimal
    Dim tot_1_actual_grp As Decimal
    Dim tot_2_actual_grp As Decimal
    Dim tot_3_actual_grp As Decimal
    Dim tot_4_actual_grp As Decimal
    Dim tot_5_actual_grp As Decimal
    Dim tot_6_actual_grp As Decimal
    Dim tot_7_actual_grp As Decimal
    Dim tot_8_actual_grp As Decimal
    Dim tot_9_actual_grp As Decimal
    Dim tot_10_actual_grp As Decimal
    Dim tot_11_actual_grp As Decimal
    Dim tot_12_actual_grp As Decimal
    Dim tot_budget As Decimal
    Dim tot_actual As Decimal
    Dim tot_budget_grp As Decimal
    Dim tot_actual_grp As Decimal
    Private Sub GVData_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVData.CustomSummaryCalculate
        Dim summaryID As String = Convert.ToString(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            tot_1_budget = 0.0
            tot_2_budget = 0.0
            tot_3_budget = 0.0
            tot_4_budget = 0.0
            tot_5_budget = 0.0
            tot_6_budget = 0.0
            tot_7_budget = 0.0
            tot_8_budget = 0.0
            tot_9_budget = 0.0
            tot_10_budget = 0.0
            tot_11_budget = 0.0
            tot_12_budget = 0.0
            tot_1_actual = 0.0
            tot_2_actual = 0.0
            tot_3_actual = 0.0
            tot_4_actual = 0.0
            tot_5_actual = 0.0
            tot_6_actual = 0.0
            tot_7_actual = 0.0
            tot_8_actual = 0.0
            tot_9_actual = 0.0
            tot_10_actual = 0.0
            tot_11_actual = 0.0
            tot_12_actual = 0.0

            tot_1_budget_grp = 0.0
            tot_2_budget_grp = 0.0
            tot_3_budget_grp = 0.0
            tot_4_budget_grp = 0.0
            tot_5_budget_grp = 0.0
            tot_6_budget_grp = 0.0
            tot_7_budget_grp = 0.0
            tot_8_budget_grp = 0.0
            tot_9_budget_grp = 0.0
            tot_10_budget_grp = 0.0
            tot_11_budget_grp = 0.0
            tot_12_budget_grp = 0.0
            tot_1_actual_grp = 0.0
            tot_2_actual_grp = 0.0
            tot_3_actual_grp = 0.0
            tot_4_actual_grp = 0.0
            tot_5_actual_grp = 0.0
            tot_6_actual_grp = 0.0
            tot_7_actual_grp = 0.0
            tot_8_actual_grp = 0.0
            tot_9_actual_grp = 0.0
            tot_10_actual_grp = 0.0
            tot_11_actual_grp = 0.0
            tot_12_actual_grp = 0.0

            tot_budget = 0.0
            tot_actual = 0.0
            tot_budget_grp = 0.0
            tot_actual_grp = 0.0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim _1_budget As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "1_budget").ToString, "0.00"))
            Dim _2_budget As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "2_budget").ToString, "0.00"))
            Dim _3_budget As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "3_budget").ToString, "0.00"))
            Dim _4_budget As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "4_budget").ToString, "0.00"))
            Dim _5_budget As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "5_budget").ToString, "0.00"))
            Dim _6_budget As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "6_budget").ToString, "0.00"))
            Dim _7_budget As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "7_budget").ToString, "0.00"))
            Dim _8_budget As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "8_budget").ToString, "0.00"))
            Dim _9_budget As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "9_budget").ToString, "0.00"))
            Dim _10_budget As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "10_budget").ToString, "0.00"))
            Dim _11_budget As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "11_budget").ToString, "0.00"))
            Dim _12_budget As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "12_budget").ToString, "0.00"))
            Dim _1_actual As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "1_actual").ToString, "0.00"))
            Dim _2_actual As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "2_actual").ToString, "0.00"))
            Dim _3_actual As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "3_actual").ToString, "0.00"))
            Dim _4_actual As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "4_actual").ToString, "0.00"))
            Dim _5_actual As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "5_actual").ToString, "0.00"))
            Dim _6_actual As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "6_actual").ToString, "0.00"))
            Dim _7_actual As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "7_actual").ToString, "0.00"))
            Dim _8_actual As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "8_actual").ToString, "0.00"))
            Dim _9_actual As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "9_actual").ToString, "0.00"))
            Dim _10_actual As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "10_actual").ToString, "0.00"))
            Dim _11_actual As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "11_actual").ToString, "0.00"))
            Dim _12_actual As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "12_actual").ToString, "0.00"))
            Dim budget As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_budget").ToString, "0.00"))
            Dim actual As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_actual"), "0.00"))
            Select Case summaryID
                Case "1_pros_sum"
                    tot_1_budget += _1_budget
                    tot_1_actual += _1_actual
                Case "1_pros_gsum"
                    tot_1_budget_grp += _1_budget
                    tot_1_actual_grp += _1_actual
                Case "2_pros_sum"
                    tot_2_budget += _2_budget
                    tot_2_actual += _2_actual
                Case "2_pros_gsum"
                    tot_2_budget_grp += _1_budget
                    tot_2_actual_grp += _1_actual
                Case "3_pros_sum"
                    tot_3_budget += _3_budget
                    tot_3_actual += _3_actual
                Case "3_pros_gsum"
                    tot_3_budget_grp += _3_budget
                    tot_3_actual_grp += _3_actual
                Case "4_pros_sum"
                    tot_4_budget += _4_budget
                    tot_4_actual += _4_actual
                Case "4_pros_gsum"
                    tot_4_budget_grp += _4_budget
                    tot_4_actual_grp += _4_actual
                Case "5_pros_sum"
                    tot_5_budget += _5_budget
                    tot_5_actual += _5_actual
                Case "5_pros_gsum"
                    tot_5_budget_grp += _5_budget
                    tot_5_actual_grp += _5_actual
                Case "6_pros_sum"
                    tot_6_budget += _6_budget
                    tot_6_actual += _6_actual
                Case "6_pros_gsum"
                    tot_6_budget_grp += _6_budget
                    tot_6_actual_grp += _6_actual
                Case "7_pros_sum"
                    tot_7_budget += _7_budget
                    tot_7_actual += _7_actual
                Case "7_pros_gsum"
                    tot_7_budget_grp += _7_budget
                    tot_7_actual_grp += _7_actual
                Case "8_pros_sum"
                    tot_8_budget += _8_budget
                    tot_8_actual += _8_actual
                Case "8_pros_gsum"
                    tot_8_budget_grp += _8_budget
                    tot_8_actual_grp += _8_actual
                Case "9_pros_sum"
                    tot_9_budget += _9_budget
                    tot_9_actual += _9_actual
                Case "9_pros_gsum"
                    tot_9_budget_grp += _9_budget
                    tot_9_actual_grp += _9_actual
                Case "10_pros_sum"
                    tot_10_budget += _10_budget
                    tot_10_actual += _10_actual
                Case "10_pros_gsum"
                    tot_10_budget_grp += _10_budget
                    tot_10_actual_grp += _10_actual
                Case "11_pros_sum"
                    tot_11_budget += _11_budget
                    tot_11_actual += _11_actual
                Case "11_pros_gsum"
                    tot_11_budget_grp += _11_budget
                    tot_11_actual_grp += _11_actual
                Case "12_pros_sum"
                    tot_12_budget += _12_budget
                    tot_12_actual += _12_actual
                Case "12_pros_gsum"
                    tot_12_budget_grp += _12_budget
                    tot_12_actual_grp += _12_actual
                Case "total_pros_sum"
                    tot_budget += budget
                    tot_actual += actual
                Case "total_pros_gsum"
                    tot_budget_grp += budget
                    tot_actual_grp += actual
            End Select
        End If

        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case "1_pros_sum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_1_actual / tot_1_budget) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "1_pros_gsum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_1_actual_grp / tot_1_budget_grp) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "2_pros_sum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_2_actual / tot_2_budget) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "2_pros_gsum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_2_actual_grp / tot_2_budget_grp) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "3_pros_sum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_3_actual / tot_3_budget) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "3_pros_gsum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_3_actual_grp / tot_3_budget_grp) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "4_pros_sum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_4_actual / tot_4_budget) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "4_pros_gsum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_4_actual_grp / tot_4_budget_grp) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "5_pros_sum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_5_actual / tot_5_budget) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "5_pros_gsum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_5_actual_grp / tot_5_budget_grp) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "6_pros_sum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_6_actual / tot_6_budget) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "6_pros_gsum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_6_actual_grp / tot_6_budget_grp) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "7_pros_sum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_7_actual / tot_7_budget) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "7_pros_gsum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_7_actual_grp / tot_7_budget_grp) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "8_pros_sum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_8_actual / tot_8_budget) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "8_pros_gsum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_8_actual_grp / tot_8_budget_grp) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "9_pros_sum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_9_actual / tot_9_budget) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "9_pros_gsum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_9_actual_grp / tot_9_budget_grp) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "10_pros_sum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_10_actual / tot_10_budget) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "10_pros_gsum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_10_actual_grp / tot_10_budget_grp) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "11_pros_sum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_11_actual / tot_11_budget) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "11_pros_gsum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_11_actual_grp / tot_11_budget_grp) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "12_pros_sum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_12_actual / tot_12_budget) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "12_pros_gsum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_12_actual_grp / tot_12_budget_grp) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "total_pros_sum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_actual / tot_budget) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "total_pros_gsum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_actual_grp / tot_budget_grp) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
            End Select
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LEDeptSum_EditValueChanged(sender As Object, e As EventArgs) Handles LEDeptSum.EditValueChanged
        resetView()
    End Sub

    Private Sub LEYear_EditValueChanged(sender As Object, e As EventArgs) Handles LEYear.EditValueChanged
        resetView()
    End Sub

    Private Sub LECat_EditValueChanged(sender As Object, e As EventArgs) Handles LECat.EditValueChanged
        resetView()
    End Sub

    Private Sub LEMonth_EditValueChanged(sender As Object, e As EventArgs) Handles LEMonth.EditValueChanged
        setGaugeInfo()
    End Sub
End Class