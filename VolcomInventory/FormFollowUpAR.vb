Public Class FormFollowUpAR
    Private Sub FormFollowUpAR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_group_store()
    End Sub

    Sub load_group_store()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS id_comp_group, 'All' AS comp_group, 'All Group' AS description 
        UNION
        SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg "
        viewSearchLookupQuery(SLEStoreGroup, query, "id_comp_group", "comp_group", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub viewList()
        Cursor = Cursors.WaitCursor
        Dim cond As String = ""
        If SLEStoreGroup.EditValue.ToString <> "0" Then
            cond = "AND f.id_comp_group='" + SLEStoreGroup.EditValue.ToString + "'"
        End If
        Dim f As New ClassFollowUpAR()
        Dim query As String = f.queryMain(cond, "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Sub viewActive()
        Cursor = Cursors.WaitCursor
        Dim cond As String = ""
        If SLEStoreGroup.EditValue.ToString <> "0" Then
            cond = "AND c.id_comp_group='" + SLEStoreGroup.EditValue.ToString + "'"
        End If
        Dim query As String = "SELECT far.id_follow_up_ar,cg.description AS `group` , sp.sales_pos_due_date, far.follow_up_date, far.follow_up, far.follow_up_result,
        SUM(CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) - IFNULL(pyd.`value`,0.00)) AS `amount`, c.id_comp_group
        FROM tb_sales_pos sp 
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
        LEFT JOIN (
           SELECT pyd.id_report, pyd.report_mark_type, 
           COUNT(IF(py.id_report_status!=5 AND py.id_report_status!=6,py.id_rec_payment,NULL)) AS `total_pending`,
           SUM(pyd.value) AS  `value`
           FROM tb_rec_payment_det pyd
           INNER JOIN tb_rec_payment py ON py.`id_rec_payment`=pyd.`id_rec_payment`
           WHERE py.`id_report_status`=6 AND pyd.report_mark_type IN (48, 54,66,67,116, 117, 118, 183)
           GROUP BY pyd.id_report, pyd.report_mark_type
        ) pyd ON pyd.id_report = sp.id_sales_pos AND pyd.report_mark_type = sp.report_mark_type
        LEFT JOIN tb_follow_up_ar far ON far.id_comp_group = c.id_comp_group AND far.due_date = sp.sales_pos_due_date
        WHERE sp.is_close_rec_payment=2 AND sp.id_report_status=6
        AND sp.sales_pos_total>0
        AND sp.report_mark_type!=66 AND sp.report_mark_type!=67 AND sp.report_mark_type!=118  
        AND DATEDIFF(NOW(),sp.sales_pos_due_date)>0
        " + cond + "
        GROUP BY c.id_comp_group, sp.sales_pos_due_date, far.id_follow_up_ar
        ORDER BY cg.description ASC, sp.sales_pos_due_date ASC, far.follow_up_date ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCActive.DataSource = data
        GVActive.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewHistory()
        Cursor = Cursors.WaitCursor

        Dim query As String = "
            SELECT r.id_follow_up_recap, e.employee_name AS created_by, r.created_date, r.follow_up_date, s.report_status
            FROM tb_follow_up_recap AS r
            LEFT JOIN tb_m_user AS u ON r.created_by = u.id_user
            LEFT JOIN tb_m_employee AS e ON u.id_employee= e.id_employee
            LEFT JOIN tb_lookup_report_status AS s ON r.id_report_status = s.id_report_status
            ORDER BY r.id_follow_up_recap DESC
        "

        GridControlHistory.DataSource = execute_query(query, -1, True, "", "", "", "")

        GridViewHistory.BestFitColumns()

        Cursor = Cursors.Default
    End Sub

    Private Sub BView_Click_1(sender As Object, e As EventArgs) Handles BView.Click
        If XTCAR.SelectedTabPageIndex = 0 Then
            viewList()
        ElseIf XTCAR.SelectedTabPageIndex = 1 Then
            viewActive()
        ElseIf XTCAR.SelectedTabPageIndex = 2 Then
            viewHistory()
        End If
    End Sub

    Private Sub FormFollowUpAR_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        checkFormAccess(Name)
    End Sub

    Private Sub XTCAR_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCAR.SelectedPageChanged
        check_menu()

        If XTCAR.SelectedTabPageIndex = 2 Then
            PanelControl1.Visible = False

            viewHistory()
        Else
            PanelControl1.Visible = True
        End If
    End Sub

    Private Sub FormFollowUpAR_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        FormMain.but_edit()
    End Sub

    Private Sub GVActive_DoubleClick(sender As Object, e As EventArgs) Handles GVActive.DoubleClick
        FormMain.but_edit()
    End Sub

    Private Sub SimpleButtonRecap_Click(sender As Object, e As EventArgs) Handles SimpleButtonRecap.Click
        If GVActive.RowCount < 1 Then
            stopCustom("No follow Up.")
        ElseIf Not SLEStoreGroup.EditValue.ToString = "0" Then
            stopCustom("Please select all store.")
        Else
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to create recap ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                viewActive()

                Dim id_follow_up_recap As String = "0"

                Dim query As String = "INSERT INTO tb_follow_up_recap (follow_up_date, created_date, created_by, id_report_status) VALUES (DATE(NOW()), NOW(), " + id_user + ", 1); SELECT LAST_INSERT_ID();"

                id_follow_up_recap = execute_query(query, 0, True, "", "", "", "")

                Dim query_det As String = "INSERT INTO tb_follow_up_recap_det (id_follow_up_recap, id_comp_group, `group`, amount, due_date, follow_up_date, follow_up, follow_up_result) VALUES "

                For i = 0 To GVActive.RowCount - 1
                    If GVActive.IsValidRowHandle(i) Then
                        Dim follow_up_date As String = "NULL"

                        If Not GVActive.GetRowCellValue(i, "follow_up_date").ToString = "" Then
                            follow_up_date = "'" + Date.Parse(GVActive.GetRowCellValue(i, "follow_up_date")).ToString("yyyy-MM-dd") + "'"
                        End If

                        query_det += "(" + id_follow_up_recap + ", " + GVActive.GetRowCellValue(i, "id_comp_group").ToString + ", '" + addSlashes(GVActive.GetRowCellValue(i, "group").ToString) + "', " + decimalSQL(GVActive.GetRowCellValue(i, "amount").ToString) + ", '" + Date.Parse(GVActive.GetRowCellValue(i, "sales_pos_due_date")).ToString("yyyy-MM-dd") + "', " + follow_up_date + ", '" + addSlashes(GVActive.GetRowCellValue(i, "follow_up").ToString) + "', '" + addSlashes(GVActive.GetRowCellValue(i, "follow_up_result").ToString) + "'), "
                    End If
                Next

                query_det = query_det.Substring(0, query_det.Length - 2)

                execute_non_query(query_det, True, "", "", "", "")

                submit_who_prepared("234", id_follow_up_recap, id_user)

                FormFollowUpARHistory.id_follow_up_recap = id_follow_up_recap
                FormFollowUpARHistory.ShowDialog()
            End If
        End If
    End Sub

    Private Sub GridViewHistory_DoubleClick(sender As Object, e As EventArgs) Handles GridViewHistory.DoubleClick
        FormFollowUpARHistory.id_follow_up_recap = GridViewHistory.GetFocusedRowCellValue("id_follow_up_recap").ToString
        FormFollowUpARHistory.ShowDialog()
    End Sub

    Dim last_grp As String = ""
    Dim last_due As String = ""
    Dim tot_amo_grp As Double
    Dim tot_amo As Double
    Private Sub GVActive_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVActive.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            tot_amo_grp = 0.00
            tot_amo = 0.00
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim grp As String = View.GetRowCellValue(e.RowHandle, "id_comp_group").ToString
            Dim due As String = DateTime.Parse(View.GetRowCellValue(e.RowHandle, "sales_pos_due_date").ToString).ToString("yyyy-MM-dd")
            Dim amo As Double = 0.00
            'amo = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "amount").ToString, "0.00"))
            Console.WriteLine(grp.ToString)
            If grp <> last_grp Or due <> last_due Then
                last_grp = grp
                last_due = due
                amo = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "amount").ToString, "0.00"))
            Else
                amo = 0.00
            End If
            Select Case summaryID
                Case 1
                    tot_amo_grp += amo
                Case 2
                    tot_amo += amo
            End Select
        End If

        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case 1 'total group
                    Dim sum_res As Double = 0.00
                    Try
                        sum_res = tot_amo_grp
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case 2 'total 
                    Dim sum_res As Double = 0.00
                    Try
                        sum_res = tot_amo
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
            End Select
        End If
    End Sub
End Class