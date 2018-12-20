Public Class FormEmpUniPeriodDet
    Public action As String = "-1"
    Public id_emp_uni_period As String = "-1"
    Public is_public_form As Boolean = False

    Private Sub FormEmpUniPeriodDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            XTCUni.Enabled = False
            BtnSave.Text = "Create New"
            TxtTolerance.EditValue = 0
            TxtBudget.EditValue = 0
        Else
            Dim query_c As New ClassEmpUni()
            Dim query As String = query_c.queryMain("AND u.id_emp_uni_period=" + id_emp_uni_period + "", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtPeriodName.Text = data.Rows(0)("period_name").ToString
            DEStart.EditValue = data.Rows(0)("selection_date_start")
            DEEnd.EditValue = data.Rows(0)("selection_date_end")
            DEDist.EditValue = data.Rows(0)("distribution_date")
            TxtTolerance.EditValue = data.Rows(0)("tolerance")
            TxtBudget.EditValue = data.Rows(0)("budget_point")
            If data.Rows(0)("id_status").ToString = "1" Then
                CEActive.Checked = True
            Else
                CEActive.Checked = False
            End If
            XTCUni.Enabled = True
            BtnSave.Text = "Save Changes"
            viewDept()

            'permission
            If is_public_form Then
                BtnAdd.Visible = False
                BtnDelete.Visible = False
                BtnImportExcel.Visible = False
                BtnPrintForm.Visible = False
                PanelControl1.Visible = False
                PanelControl6.Visible = False
                TxtPeriodName.Enabled = False
                DEStart.Enabled = False
                DEEnd.Enabled = False
                DEDist.Enabled = False
                TxtBudget.Enabled = False
                TxtTolerance.Enabled = False
                CEActive.Visible = False
                GridColumnBudget.Visible = False
                GridColumnBugdetDiff.Visible = False
                GridColumnOrderAmount.Visible = False
                LabelControl7.Visible = False
                TxtBudget.Visible = False
            End If
        End If
    End Sub

    Sub viewDept()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        If Not is_public_form Then
            query += "SELECT 0 as id_departement, 'All departement' as departement UNION  "
            query += "(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        Else
            query += "(SELECT id_departement,departement FROM tb_m_departement a WHERE (a.id_user_admin=" + id_user + " OR a.id_user_admin_backup=" + id_user + " OR a.id_departement=" + id_departement_user + ") ORDER BY a.departement ASC) "
        End If
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim dept As String = "0"
        Try
            dept = LEDeptSum.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "CALL view_emp_uni_budget(" + id_emp_uni_period + ", '" + dept + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewSchedule()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT s.id_schedule, s.id_emp_uni_period, s.id_departement, d.departement, s.`start`, s.`end` 
        FROM tb_emp_uni_schedule s
        INNER JOIN tb_m_departement d ON d.id_departement = s.id_departement
        WHERE s.id_emp_uni_period=" + id_emp_uni_period + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSchedule.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewDesignList()
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_emp_uni_design(" + id_emp_uni_period + ",0,0) "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesignList.DataSource = data
        GVDesignList.Columns("1").Caption = "1" + System.Environment.NewLine + "XXS"
        GVDesignList.Columns("2").Caption = "2" + System.Environment.NewLine + "XS"
        GVDesignList.Columns("3").Caption = "3" + System.Environment.NewLine + "S"
        GVDesignList.Columns("4").Caption = "4" + System.Environment.NewLine + "M"
        GVDesignList.Columns("5").Caption = "5" + System.Environment.NewLine + "ML"
        GVDesignList.Columns("6").Caption = "6" + System.Environment.NewLine + "L"
        GVDesignList.Columns("7").Caption = "7" + System.Environment.NewLine + "XL"
        GVDesignList.Columns("8").Caption = "8" + System.Environment.NewLine + "XXL"
        GVDesignList.Columns("9").Caption = "9" + System.Environment.NewLine + "ALL"
        GVDesignList.Columns("0").Caption = "0" + System.Environment.NewLine + "SM"
        GVDesignList.RefreshData()
        Cursor = Cursors.Default
    End Sub

    Sub viewOrder()
        Cursor = Cursors.WaitCursor
        Dim query_c As New ClassEmpUni()
        Dim query As String = query_c.queryMainOrder("AND p.id_emp_uni_period=" + id_emp_uni_period + " ", "2", "-1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesOrder.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If DEStart.Text <> "" And DEEnd.Text <> "" And DEDist.Text <> "" Then
            Dim period_name As String = addSlashes(TxtPeriodName.Text)
            Dim selection_date_start As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim selection_date_end As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim distribution_date As String = DateTime.Parse(DEDist.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim tolerance As String = decimalSQL(TxtTolerance.EditValue.ToString)
            Dim budget_point As String = decimalSQL(TxtBudget.EditValue.ToString)
            Dim id_status As String = CEActive.EditValue.ToString
            If id_status = "True" Then
                id_status = "1"
                'Dim uni As New ClassEmpUni
                'uni.nonaktifPeriod()
            Else
                id_status = "2"
            End If

            If action = "ins" Then
                Dim query As String = "INSERT INTO tb_emp_uni_period(period_name, selection_date_start, selection_date_end, created_date, distribution_date, tolerance, budget_point, id_status) VALUES "
                query += "('" + period_name + "', '" + selection_date_start + "', '" + selection_date_end + "', NOW(), '" + distribution_date + "','" + tolerance + "','" + budget_point + "', '" + id_status + "'); SELECT LAST_INSERT_ID(); "
                id_emp_uni_period = execute_query(query, 0, True, "", "", "", "")
                action = "upd"
                actionLoad()
                infoCustom("Uniform period was created successfully, please input detail budget.")
            Else
                Dim query As String = "UPDATE tb_emp_uni_period SET period_name='" + period_name + "', selection_date_start='" + selection_date_start + "', selection_date_end='" + selection_date_end + "', distribution_date='" + distribution_date + "', budget_point='" + budget_point + "', tolerance='" + tolerance + "', id_status='" + id_status + "' WHERE id_emp_uni_period='" + id_emp_uni_period + "' "
                execute_non_query(query, True, "", "", "", "")

                'update point
                execute_non_query("CALL set_emp_uni_point(" + id_emp_uni_period + ")", True, "", "", "", "")

                action = "upd"
                actionLoad()
                infoCustom("Uniform period was edited successfully.")
            End If
            FormEmpUniPeriod.viewUniformPeriod()
            FormEmpUniPeriod.GVUni.FocusedRowHandle = find_row(FormEmpUniPeriod.GVUni, "id_emp_uni_period", id_emp_uni_period)
        Else
            stopCustom("Period can't blank")
        End If

    End Sub



    Private Sub FormEmpUniPeriodDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormEmpUniPeriodSingle.action = "ins"
        FormEmpUniPeriodSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Dim id As String = "-1"
        Try
            id = GVDetail.GetFocusedRowCellValue("id_emp_uni_budget").ToString
        Catch ex As Exception
        End Try
        If id <> "-1" Then
            FormEmpUniPeriodSingle.action = "upd"
            FormEmpUniPeriodSingle.ShowDialog()
        End If
    End Sub

    Private Sub BtnPrintBudget_Click(sender As Object, e As EventArgs) Handles BtnPrintBudget.Click
        Cursor = Cursors.WaitCursor
        print(GCDetail, "UNIFORM BUDGET : " + TxtPeriodName.Text.ToUpper)
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Dim id As String = "-1"
        Try
            id = GVDetail.GetFocusedRowCellValue("id_emp_uni_budget").ToString
        Catch ex As Exception
        End Try
        If id <> "-1" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this budget for this employee?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim query As String = "DELETE FROM tb_emp_uni_budget WHERE id_emp_uni_budget=" + id + " "
                    execute_non_query(query, True, "", "", "", "")
                    viewDetail()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        End If
    End Sub

    Private Sub XTCUni_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCUni.SelectedPageChanged
        If XTCUni.SelectedTabPageIndex = 0 Then
            BtnSave.Visible = True
        ElseIf XTCUni.SelectedTabPageIndex = 1 Then
            BtnSave.Visible = False
            viewDesignList()
        ElseIf XTCUni.SelectedTabPageIndex = 2 Then
            BtnSave.Visible = False
            viewSchedule()
        Else
            BtnSave.Visible = False
        End If
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        viewDesignList()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCDesignList, TxtPeriodName.Text + " - " + "DESIGN LIST")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrintOrder_Click(sender As Object, e As EventArgs) Handles BtnPrintOrder.Click
        Cursor = Cursors.WaitCursor
        print(GCSalesOrder, "UNIFORM ORDER - " + TxtPeriodName.Text.ToString)
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCreateNewOrder_Click(sender As Object, e As EventArgs) Handles BtnCreateNewOrder.Click
        Cursor = Cursors.WaitCursor
        FormEmpUniOrderNew.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesOrder_DoubleClick(sender As Object, e As EventArgs) Handles GVSalesOrder.DoubleClick
        If GVSalesOrder.RowCount > 0 And GVSalesOrder.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormEmpUniOrderDet.id_sales_order = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
            FormEmpUniOrderDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnImportExcel_Click(sender As Object, e As EventArgs) Handles BtnImportExcel.Click
        Cursor = Cursors.WaitCursor
        Dim qc As String = "SELECT * FROM tb_sales_order so WHERE so.id_emp_uni_period = '" + id_emp_uni_period + "' AND so.id_report_status!=5 "
        Dim dc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dc.Rows.Count > 0 Then
            stopCustom("Fitur ini tidak dapat digunakan karena pemilihan uniform sedang berlangsung.")
        Else
            FormImportExcel.id_pop_up = "31"
            FormImportExcel.ShowDialog()
        End If
        ' FormEmpUniBudgetSet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub PrintFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintFormToolStripMenuItem.Click
        'print form here
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BtnPrintForm.Click
        If GVDetail.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            ReportEmpUni.id_period = id_emp_uni_period
            Dim Report As New ReportEmpUni()
            Report.LabelPeriode.Text = TxtPeriodName.Text
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub LEDeptSum_EditValueChanged(sender As Object, e As EventArgs) Handles LEDeptSum.EditValueChanged
        viewDetail()
    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles BtnOrderDetail.Click
        orderDetail()
    End Sub

    Sub orderDetail()
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_emp_uni_budget As String = GVDetail.GetFocusedRowCellValue("id_emp_uni_budget").ToString
            Dim uni As New ClassEmpUni()
            uni.is_public_form = is_public_form
            uni.openOrderDetail(id_emp_uni_period, id_emp_uni_budget, GVDetail.GetFocusedRowCellValue("id_order").ToString, GVDetail.GetFocusedRowCellValue("id_departement").ToString)

            'Dim qorder As String = "SELECT * FROM tb_sales_order WHERE id_emp_uni_period=" + id_emp_uni_period + " AND id_emp_uni_budget=" + GVDetail.GetFocusedRowCellValue("id_emp_uni_budget").ToString + " AND id_report_status!=5 "
            'Dim dorder As DataTable = execute_query(qorder, -1, True, "", "", "", "")
            'If dorder.Rows.Count > 0 Then 'sudah ada order
            '    FormEmpUniOrderDet.id_sales_order = GVDetail.GetFocusedRowCellValue("id_order").ToString
            '    FormEmpUniOrderDet.ShowDialog()
            'Else 'blm ada
            '    'get destination
            '    Dim id_dept As String = GVDetail.GetFocusedRowCellValue("id_departement").ToString
            '    Dim id_store_contact_to As String = "-1"
            '    Try
            '        id_store_contact_to = execute_query("SELECT cc.id_comp_contact FROM tb_m_departement d 
            '    INNER JOIN tb_m_comp c ON c.id_comp = d.id_comp_promo
            '    INNER JOIN tb_m_comp_contact cc ON cc.id_comp = c.id_comp AND cc.is_default=1
            '    WHERE d.id_departement=" + id_dept + " ", 0, True, "", "", "", "")
            '    Catch ex As Exception
            '    End Try

            '    'get from
            '    Dim id_warehouse_contact_to = "-1"
            '    Try
            '        id_warehouse_contact_to = execute_query("SELECT cc.id_comp_contact 
            '        FROM tb_emp_uni_design l 
            '        INNER JOIN tb_m_comp c ON c.id_drawer_def = l.id_wh_drawer
            '        INNER JOIN tb_m_comp_contact cc ON cc.id_comp = c.id_comp AND cc.is_default=1
            '        WHERE l.id_emp_uni_period=" + id_emp_uni_period + " AND l.id_report_status=6
            '        GROUP BY l.id_emp_uni_period", 0, True, "", "", "", "")
            '    Catch ex As Exception
            '    End Try

            '    'get id_emp_uni_budget
            '    Dim tolerance As String = decimalSQL(GVDetail.GetFocusedRowCellValue("tolerance").ToString)

            '    'get discount
            '    Dim discount As Decimal = 0

            '    'check
            '    If id_store_contact_to = "-1" Then
            '        stopCustom("Destination account is not found")
            '    ElseIf id_warehouse_contact_to = "-1" Then
            '        stopCustom("WH account is not found")
            '    Else
            '        Dim query As String = "INSERT INTO tb_sales_order(id_store_contact_to, id_warehouse_contact_to, sales_order_number, sales_order_date, sales_order_note, id_so_type, id_report_status, id_so_status, id_user_created, id_emp_uni_period, id_emp_uni_budget, tolerance, discount) "
            '        query += "VALUES('" + id_store_contact_to + "', '" + id_warehouse_contact_to + "', '', NOW(), '', '0', '1', '7', '" + id_user + "','" + id_emp_uni_period + "'," + id_emp_uni_budget + ",'" + tolerance + "','" + decimalSQL(discount.ToString) + "'); SELECT LAST_INSERT_ID(); "
            '        Dim id_new As String = execute_query(query, 0, True, "", "", "", "")

            '        'submit_who_prepared("39", id_new, id_user)

            '        FormEmpUniOrderDet.id_sales_order = id_new
            '        FormEmpUniOrderDet.ShowDialog()
            '    End If
            'End If

            'refrsh
            viewDetail()
            GVDetail.FocusedRowHandle = find_row(GVDetail, "id_emp_uni_budget", id_emp_uni_budget)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVDetail_DoubleClick(sender As Object, e As EventArgs) Handles GVDetail.DoubleClick
        orderDetail()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCSchedule, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDeleteSchedule_Click(sender As Object, e As EventArgs) Handles BtnDeleteSchedule.Click
        Dim id As String = "-1"
        Try
            id = GVSchedule.GetFocusedRowCellValue("id_schedule").ToString
        Catch ex As Exception
        End Try
        If id <> "-1" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this schedule?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    Dim query As String = "DELETE FROM tb_emp_uni_schedule WHERE id_schedule=" + id + " "
                    execute_non_query(query, True, "", "", "", "")
                    viewSchedule()
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnAddSchedule_Click(sender As Object, e As EventArgs) Handles BtnAddSchedule.Click
        Cursor = Cursors.WaitCursor
        FormEmpUniSchedule.ShowDialog()
        Cursor = Cursors.Default
    End Sub


End Class