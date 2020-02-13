Public Class FormEmpBPJSKesehatanDet
    Public id As String = "0"
    Public is_approve As String = "0"

    Private loaded As Boolean = False

    Private Sub FormEmpBPJSKesehatanDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaded = False

        viewSearchLookupQuery(SLUEPayroll, "SELECT id_payroll, DATE_FORMAT(periode_end, '%M %Y') AS periode, id_payroll_type, IF(id_payroll_type = 1, 'Organic', 'Daily Worker') AS payroll_type, CONCAT((SELECT periode), ' - ', (SELECT payroll_type)) AS description FROM tb_emp_payroll  WHERE id_payroll_type IN (1, 4) ORDER BY periode_end DESC, id_payroll_type ASC", "id_payroll", "description", "id_payroll")
        viewLookupQuery(LUEReportStatus, "(SELECT 0 AS id_report_status, 'Draft' AS report_status) UNION ALL (SELECT id_report_status, report_status FROM tb_lookup_report_status)", 0, "report_status", "id_report_status")

        Dim id_report_status As String = execute_query("SELECT IFNULL((SELECT id_report_status FROM tb_pay_bpjs_kesehatan WHERE id_pay_bpjs_kesehatan = " + id + "), 0) AS id_report_status", 0, True, "", "", "", "")

        If id = "0" Then
            load_default()
        Else
            load_form()
        End If

        'controls
        If id_report_status = "0" Then
            SBAutoGenerate.Enabled = True
            SBRemove.Enabled = True
            SBAdd.Enabled = True
            SBMark.Enabled = False
            SBAttachment.Enabled = False
            SBClose.Enabled = True
            SBPrint.Enabled = False
            SBSave.Enabled = True
            SBSubmit.Enabled = True

            SLUEPayroll.ReadOnly = False

            GCFixedSalary.OptionsColumn.AllowEdit = True
        Else
            SBAutoGenerate.Enabled = False
            SBRemove.Enabled = False
            SBAdd.Enabled = False
            SBMark.Enabled = True
            SBAttachment.Enabled = True
            SBClose.Enabled = True
            SBPrint.Enabled = False
            SBSave.Enabled = False
            SBSubmit.Enabled = False

            SLUEPayroll.ReadOnly = True

            GCFixedSalary.OptionsColumn.AllowEdit = False
        End If

        If is_approve = "1" Then
            SBAutoGenerate.Enabled = False
            SBRemove.Enabled = False
            SBAdd.Enabled = False
            SBClose.Enabled = True
            SBPrint.Enabled = False
            SBSave.Enabled = False
            SBSubmit.Enabled = False

            SLUEPayroll.ReadOnly = True

            GCFixedSalary.OptionsColumn.AllowEdit = False
        End If

        LUEReportStatus.Properties.ReadOnly = True

        loaded = True
    End Sub

    Sub load_default()
        Dim data As DataTable = New DataTable

        data.Columns.Add("id_departement", GetType(String))
        data.Columns.Add("id_departement_sub", GetType(String))
        data.Columns.Add("departement", GetType(String))
        data.Columns.Add("departement_sub", GetType(String))
        data.Columns.Add("id_employee", GetType(String))
        data.Columns.Add("employee_code", GetType(String))
        data.Columns.Add("employee_name", GetType(String))
        data.Columns.Add("employee_position", GetType(String))
        data.Columns.Add("employee_bpjs_kesehatan", GetType(String))
        data.Columns.Add("employee_dob", GetType(String))
        data.Columns.Add("id_employee_status", GetType(String))
        data.Columns.Add("employee_status", GetType(String))
        data.Columns.Add("fixed_salary", GetType(Integer))
        data.Columns.Add("bpjs_kesehatan_contribution", GetType(Decimal))

        GCInput.DataSource = data

        TENumber.EditValue = "[autogenerate]"
        SLUEPayroll.EditValue = execute_query("SELECT id_payroll FROM tb_emp_payroll WHERE DATE(NOW()) >= periode_start AND DATE(NOW()) <= periode_end AND id_payroll_type = 1", 0, True, "", "", "", "")
        LUEReportStatus.ItemIndex = 0
        TECreatedAt.EditValue = DateTime.Parse(Now).ToString("dd MMMM yyyy HH:mm:ss")
        TECreatedBy.EditValue = get_emp(id_employee_user, "2")
    End Sub

    Sub load_form()
        Dim data As DataTable = execute_query("SELECT * FROM tb_pay_bpjs_kesehatan WHERE id_pay_bpjs_kesehatan = " + id, -1, True, "", "", "", "")

        TENumber.EditValue = data.Rows(0)("number").ToString
        SLUEPayroll.EditValue = data.Rows(0)("id_payroll")
        LUEReportStatus.ItemIndex = LUEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status"))
        TECreatedAt.EditValue = DateTime.Parse(data.Rows(0)("created_at")).ToString("dd MMMM yyyy HH:mm:ss")
        TECreatedBy.EditValue = get_emp(data.Rows(0)("created_by"), "2")

        'detail
        Dim query_det As String = "
            SELECT bpjs_det.id_departement, bpjs_det.id_departement_sub, dep.departement, IF(bpjs_det.id_departement = 17, dep_sub.departement_sub, dep.departement) AS departement_sub, bpjs_det.id_employee, emp.employee_code, emp.employee_name, bpjs_det.employee_position, emp.employee_bpjs_kesehatan, DATE_FORMAT(emp.employee_dob, '%d %M %Y') AS employee_dob, bpjs_det.id_employee_status, sts.employee_status, bpjs_det.fixed_salary, bpjs_det.bpjs_kesehatan_contribution
            FROM tb_pay_bpjs_kesehatan_det AS bpjs_det
            LEFT JOIN tb_m_employee AS emp ON bpjs_det.id_employee = emp.id_employee
            LEFT JOIN tb_m_departement AS dep ON bpjs_det.id_departement = dep.id_departement
            LEFT JOIN tb_m_departement_sub AS dep_sub ON bpjs_det.id_departement_sub = dep_sub.id_departement_sub
            LEFT JOIN tb_lookup_employee_status AS sts ON bpjs_det.id_employee_status = sts.id_employee_status
            WHERE bpjs_det.id_pay_bpjs_kesehatan = " + id + "
            ORDER BY dep.departement ASC, emp.id_employee_level ASC, emp.employee_code ASC
        "

        Dim data_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")

        GCInput.DataSource = data_det

        GVInput.BestFitColumns()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        FormEmpBPJSKesehatanPick.ShowDialog()
    End Sub

    Private Sub SBRemove_Click(sender As Object, e As EventArgs) Handles SBRemove.Click
        GVInput.DeleteSelectedRows()
    End Sub

    Private Sub SBAutoGenerate_Click(sender As Object, e As EventArgs) Handles SBAutoGenerate.Click
        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Auto generate will reset employee list, are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim where_dw As String = ""

            Dim id_payroll_type As String = execute_query("SELECT id_payroll_type FROM tb_emp_payroll WHERE id_payroll = " + SLUEPayroll.EditValue.ToString, 0, True, "", "", "", "")

            If id_payroll_type = "1" Then
                where_dw = "AND emp.id_employee_status IN (1, 2)"
            ElseIf id_payroll_type = "4" Then
                where_dw = "AND emp.id_employee_status IN (3)"
            End If

            Dim query As String = "
                SELECT emp.id_departement, emp.id_departement_sub, dep.departement, IF(emp.id_departement = 17, dep_sub.departement_sub, dep.departement) AS departement_sub, emp.id_employee, emp.employee_code, emp.employee_name, emp.employee_position, emp.employee_bpjs_kesehatan, DATE_FORMAT(emp.employee_dob, '%d %M %Y') AS employee_dob, emp.id_employee_status, sts.employee_status, IF(emp.id_employee_status = 3, (emp.basic_salary * dep.total_workdays), (emp.basic_salary + emp.allow_job + emp.allow_meal + emp.allow_trans)) AS fixed_salary, CAST(IF((SELECT fixed_salary) < py.ump, (py.ump * 0.01), IF((SELECT fixed_salary) >= py.bpjs_max, py.bpjs_max * 0.01, (SELECT fixed_salary) * 0.01)) AS DECIMAL(13, 2)) AS bpjs_kesehatan_contribution
                FROM tb_m_employee AS emp
                LEFT JOIN tb_m_departement AS dep ON emp.id_departement = dep.id_departement
                LEFT JOIN tb_m_departement_sub AS dep_sub ON emp.id_departement_sub = dep_sub.id_departement_sub
                LEFT JOIN tb_lookup_employee_status AS sts ON emp.id_employee_status = sts.id_employee_status
                LEFT JOIN tb_emp_payroll AS py ON py.id_payroll = " + SLUEPayroll.EditValue.ToString + "
                WHERE emp.id_employee_active = 1 AND emp.is_bpjs_volcom = 1 AND emp.basic_salary > 0 " + where_dw + "
                ORDER BY dep.departement ASC, emp.id_employee_level ASC, emp.employee_code ASC
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCInput.DataSource = data

            GVInput.BestFitColumns()
        End If
    End Sub

    Private Sub SBSubmit_Click(sender As Object, e As EventArgs) Handles SBSubmit.Click
        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked, are you sure want to submit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            save("submit")

            Close()
        End If
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        save("draft")

        Close()
    End Sub

    Sub save(type As String)
        Dim id_report_status As String = If(type = "submit", "1", "0")

        Dim query As String = ""

        If id = "0" Then
            query = "INSERT INTO tb_pay_bpjs_kesehatan (id_payroll, id_report_status, number, created_by, created_at) VALUES (" + SLUEPayroll.EditValue.ToString + ", " + id_report_status + ", NULL, " + id_employee_user + ", NOW()); SELECT LAST_INSERT_ID();"

            id = execute_query(query, 0, True, "", "", "", "")
        Else
            query = "UPDATE tb_pay_bpjs_kesehatan SET id_payroll = " + SLUEPayroll.EditValue.ToString + ", id_report_status = " + id_report_status + " WHERE id_pay_bpjs_kesehatan = " + id

            execute_non_query(query, True, "", "", "", "")
        End If

        execute_non_query("DELETE FROM tb_pay_bpjs_kesehatan_det WHERE id_pay_bpjs_kesehatan = " + id, True, "", "", "", "")

        Dim query_det As String = "INSERT INTO tb_pay_bpjs_kesehatan_det (id_pay_bpjs_kesehatan, id_employee, id_departement, id_departement_sub, employee_position, id_employee_status, fixed_salary, bpjs_kesehatan_contribution) VALUES "

        For i = 0 To GVInput.RowCount - 1
            If GVInput.IsValidRowHandle(i) Then
                Dim id_employee As String = GVInput.GetRowCellValue(i, "id_employee").ToString
                Dim id_departement As String = GVInput.GetRowCellValue(i, "id_departement").ToString
                Dim id_departement_sub As String = GVInput.GetRowCellValue(i, "id_departement_sub").ToString
                Dim employee_position As String = GVInput.GetRowCellValue(i, "employee_position").ToString
                Dim id_employee_status As String = GVInput.GetRowCellValue(i, "id_employee_status").ToString
                Dim fixed_salary As String = GVInput.GetRowCellValue(i, "fixed_salary").ToString
                Dim bpjs_kesehatan_contribution As String = GVInput.GetRowCellValue(i, "bpjs_kesehatan_contribution").ToString

                query_det += "(" + id + ", " + id_employee + ", " + id_departement + ", " + id_departement_sub + ", '" + addSlashes(employee_position) + "', " + id_employee_status + ", " + decimalSQL(fixed_salary) + ", " + decimalSQL(bpjs_kesehatan_contribution) + "), "
            End If
        Next

        query_det = query_det.Substring(0, query_det.Length - 2)

        execute_query(query_det, -1, True, "", "", "", "")

        execute_non_query("CALL gen_number(" + id + ", 223)", True, "", "", "", "")

        If type = "submit" Then
            submit_who_prepared("223", id, id_user)
        End If
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim query As String = "SELECT ump, bpjs_max, bpjs_max_kelas_2, DATE_FORMAT(periode_end, '%M %Y') AS period, IF(id_payroll_type = 1, 'Organic', 'Daily Worker') AS payroll_type FROM tb_emp_payroll WHERE id_payroll = " + SLUEPayroll.EditValue.ToString

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim query_opt As String = "SELECT bpjs_virtual_acc_1, bpjs_virtual_acc_2 FROM tb_opt"

        Dim data_opt As DataTable = execute_query(query_opt, -1, True, "", "", "", "")

        Dim id_report_status As String = execute_query("SELECT IFNULL((SELECT id_report_status FROM tb_pay_bpjs_kesehatan WHERE id_pay_bpjs_kesehatan = " + id + "), 0) AS id_report_status", 0, True, "", "", "", "")

        'all
        Dim report As ReportEmpPayrollReportBPJSKesehatan = New ReportEmpPayrollReportBPJSKesehatan

        report.PrintingSystem.ContinuousPageNumbering = False

        report.XLTitle.Text = report.XLTitle.Text.Replace("[type]", data.Rows(0)("payroll_type").ToUpper)
        report.XLPeriod.Text = data.Rows(0)("period").ToUpper

        report.id_pre = If(id_report_status = "6", "-1", "1")
        report.id_report = id
        report.data = GCAllDepartements.DataSource
        report.report_mark_type = "223"

        report.CreateDocument()

        'detail
        Dim report_detail As ReportEmpPayrollReportBPJSKesehatanDetail = New ReportEmpPayrollReportBPJSKesehatanDetail

        report_detail.PrintingSystem.ContinuousPageNumbering = False

        report_detail.XLPeriod.Text = data.Rows(0)("period").ToUpper
        report_detail.XLKodeBU.Text = data_opt.Rows(0)("bpjs_virtual_acc_1").ToString.Substring(data_opt.Rows(0)("bpjs_virtual_acc_1").ToString.Length - 8)
        report_detail.XLVirtualAcc.Text = data_opt.Rows(0)("bpjs_virtual_acc_1").ToString
        report_detail.XLMaxKelas1.Text = Format(data.Rows(0)("bpjs_max"), "##,##0")
        report_detail.XLMaxKelas2.Text = Format(data.Rows(0)("bpjs_max_kelas_2"), "##,##0")
        report_detail.XLUMK.Text = Format(data.Rows(0)("ump"), "##,##0")

        report_detail.id_pre = If(id_report_status = "6", "-1", "1")
        report_detail.id_report = id
        report_detail.data = GCEmployee.DataSource
        report_detail.report_mark_type = "223"

        report_detail.CreateDocument()

        'combine
        Dim list As List(Of DevExpress.XtraPrinting.Page) = New List(Of DevExpress.XtraPrinting.Page)

        For i = 0 To report.Pages.Count - 1
            list.Add(report.Pages(i))
        Next

        For i = 0 To report_detail.Pages.Count - 1
            list.Add(report_detail.Pages(i))
        Next

        report.Pages.AddRange(list)

        Dim tool_detail As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool_detail.ShowPreview()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = "223"
        FormReportMark.id_report = id

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub FormEmpBPJSKesehatanDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            FormEmpBPJSKesehatan.load_form()

            If Not id = "0" Then
                FormEmpBPJSKesehatan.GVList.FocusedRowHandle = find_row(FormEmpBPJSKesehatan.GVList, "id_pay_bpjs_kesehatan", id)
            End If
        Catch ex As Exception
        End Try

        Dispose()
    End Sub

    Sub update_changes()
        Dim query As String = "
            INSERT INTO tb_emp_payroll_deduction (id_payroll, id_salary_deduction, id_employee, total_days, increase, deduction, note)
            SELECT bpjs.id_payroll, 1 AS id_salary_deduction, bpjs_det.id_employee, NULL AS total_days, NULL AS increase, bpjs_det.bpjs_kesehatan_contribution AS deduction, NULL AS note
            FROM tb_pay_bpjs_kesehatan_det AS bpjs_det
            LEFT JOIN tb_pay_bpjs_kesehatan AS bpjs ON bpjs_det.id_pay_bpjs_kesehatan = bpjs.id_pay_bpjs_kesehatan
            WHERE bpjs.id_pay_bpjs_kesehatan = " + id + "
        "

        execute_non_query(query, True, "", "", "", "")
    End Sub

    Sub gen_report()
        Dim bpjs_max_kelas_2 As String = execute_query("SELECT bpjs_max_kelas_2 FROM tb_emp_payroll WHERE id_payroll = " + SLUEPayroll.EditValue.ToString, 0, True, "", "", "", "")

        'detail
        Dim data As DataTable = New DataTable

        data.Columns.Add("id_departement", GetType(String))
        data.Columns.Add("departement", GetType(String))
        data.Columns.Add("departement_sub", GetType(String))
        data.Columns.Add("no", GetType(Integer))
        data.Columns.Add("employee_name", GetType(String))
        data.Columns.Add("employee_bpjs_kesehatan", GetType(String))
        data.Columns.Add("employee_dob", GetType(String))
        data.Columns.Add("employee_salary", GetType(Decimal))
        data.Columns.Add("company_contribution", GetType(Decimal))
        data.Columns.Add("employee_contribution", GetType(Decimal))
        data.Columns.Add("total_contribution", GetType(Integer))
        data.Columns.Add("class", GetType(String))

        'departement
        Dim data_dept As DataTable = New DataTable

        data_dept.Columns.Add("is_sub", GetType(Integer))
        data_dept.Columns.Add("no", GetType(Integer))
        data_dept.Columns.Add("departement", GetType(String))
        data_dept.Columns.Add("company_contribution", GetType(Decimal))
        data_dept.Columns.Add("employee_contribution", GetType(Decimal))
        data_dept.Columns.Add("total_contribution", GetType(Integer))

        For i = 0 To GVInput.RowCount - 1
            If GVInput.IsValidRowHandle(i) Then
                'detail
                Dim id_departement As String = GVInput.GetRowCellValue(i, "id_departement").ToString
                Dim departement As String = GVInput.GetRowCellValue(i, "departement").ToString
                Dim departement_sub As String = GVInput.GetRowCellValue(i, "departement_sub").ToString
                Dim no As String = 0
                Dim employee_name As String = GVInput.GetRowCellValue(i, "employee_name").ToString
                Dim employee_bpjs_kesehatan As String = GVInput.GetRowCellValue(i, "employee_bpjs_kesehatan").ToString
                Dim employee_dob As String = Date.Parse(GVInput.GetRowCellValue(i, "employee_dob").ToString).ToString("dd MMMM yyyy")
                Dim employee_salary As String = GVInput.GetRowCellValue(i, "fixed_salary")
                Dim company_contribution As String = GVInput.GetRowCellValue(i, "bpjs_kesehatan_contribution") * 100 * 0.04
                Dim employee_contribution As String = GVInput.GetRowCellValue(i, "bpjs_kesehatan_contribution")
                Dim total_contribution As String = (GVInput.GetRowCellValue(i, "bpjs_kesehatan_contribution") * 100 * 0.04) + GVInput.GetRowCellValue(i, "bpjs_kesehatan_contribution")
                Dim bpjs_class As String = If(GVInput.GetRowCellValue(i, "fixed_salary") > Decimal.Parse(bpjs_max_kelas_2), "I", "II")

                total_contribution = Decimal.Round(Decimal.Parse(total_contribution.ToString)).ToString

                data.Rows.Add(id_departement, departement, departement_sub, no, employee_name, employee_bpjs_kesehatan, employee_dob, employee_salary, company_contribution, employee_contribution, total_contribution, bpjs_class)

                'departement
                Dim index As Integer = -1

                'skip sogo *remove if, if total all sogo include
                If Not GVInput.GetRowCellValue(i, "id_departement").ToString = "17" Then
                    For j = 0 To data_dept.Rows.Count - 1
                        If data_dept.Rows(j)("departement").ToString = GVInput.GetRowCellValue(i, "departement").ToString Then
                            index = j

                            Exit For
                        End If

                        index = -1
                    Next

                    If index = -1 Then
                        data_dept.Rows.Add(
                            0,
                            0,
                            GVInput.GetRowCellValue(i, "departement").ToString,
                            company_contribution,
                            employee_contribution,
                            total_contribution
                        )
                    Else
                        data_dept.Rows(index)("company_contribution") = data_dept.Rows(index)("company_contribution") + company_contribution
                        data_dept.Rows(index)("employee_contribution") = data_dept.Rows(index)("employee_contribution") + employee_contribution
                        data_dept.Rows(index)("total_contribution") = data_dept.Rows(index)("total_contribution") + total_contribution
                    End If
                End If

                'sogo
                If GVInput.GetRowCellValue(i, "id_departement").ToString = "17" Then
                    For j = 0 To data_dept.Rows.Count - 1
                        If data_dept.Rows(j)("departement").ToString = GVInput.GetRowCellValue(i, "departement_sub").ToString Then
                            index = j

                            Exit For
                        End If

                        index = -1
                    Next

                    If index = -1 Then
                        data_dept.Rows.Add(
                            1,
                            Nothing,
                            GVInput.GetRowCellValue(i, "departement_sub").ToString,
                            company_contribution,
                            employee_contribution,
                            total_contribution
                        )
                    Else
                        data_dept.Rows(index)("company_contribution") = data_dept.Rows(index)("company_contribution") + company_contribution
                        data_dept.Rows(index)("employee_contribution") = data_dept.Rows(index)("employee_contribution") + employee_contribution
                        data_dept.Rows(index)("total_contribution") = data_dept.Rows(index)("total_contribution") + total_contribution
                    End If
                End If
            End If
        Next

        'detail
        GCEmployee.DataSource = data

        GVEmployee.BestFitColumns()

        'numbering
        For i = 0 To GVEmployee.RowCount - 1
            If GVEmployee.IsValidRowHandle(i) Then
                GVEmployee.SetRowCellValue(i, "no", i + 1)
            End If
        Next

        'departement
        GCAllDepartements.DataSource = data_dept

        GVAllDepartements.BestFitColumns()

        'numbering
        Dim n As Integer = 1

        For i = 0 To GVAllDepartements.RowCount - 1
            If GVAllDepartements.IsValidRowHandle(i) Then
                '*uncomment if, if total all sogo include
                'If GVAllDepartements.GetRowCellValue(i, "is_sub") = 0 Then
                GVAllDepartements.SetRowCellValue(i, "no", n)

                n = n + 1
                'End If
            End If
        Next
    End Sub

    Private Sub XtraTabControl_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl.SelectedPageChanged
        If XtraTabControl.SelectedTabPageIndex = 1 Then
            gen_report()

            Dim id_report_status As String = execute_query("SELECT IFNULL((SELECT id_report_status FROM tb_pay_bpjs_kesehatan WHERE id_pay_bpjs_kesehatan = " + id + "), 0) AS id_report_status", 0, True, "", "", "", "")

            If id_report_status = "0" Then
                SBPrint.Enabled = False
            Else
                SBPrint.Enabled = True
            End If
        Else
            SBPrint.Enabled = False
        End If
    End Sub

    Private Sub GVInput_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVInput.CellValueChanged
        If e.Column.FieldName = "fixed_salary" Then
            Dim data As DataTable = execute_query("SELECT ump, bpjs_max FROM tb_emp_payroll WHERE id_payroll = " + SLUEPayroll.EditValue.ToString, -1, True, "", "", "", "")

            Dim bpjs_kesehatan_contribution As Decimal = 0.00

            If GVInput.GetRowCellValue(e.RowHandle, "fixed_salary") < data.Rows(0)("ump") Then
                bpjs_kesehatan_contribution = data.Rows(0)("ump") * 0.01
            ElseIf GVInput.GetRowCellValue(e.RowHandle, "fixed_salary") >= data.Rows(0)("bpjs_max") Then
                bpjs_kesehatan_contribution = data.Rows(0)("bpjs_max") * 0.01
            Else
                bpjs_kesehatan_contribution = GVInput.GetRowCellValue(e.RowHandle, "fixed_salary") * 0.01
            End If

            GVInput.SetRowCellValue(e.RowHandle, "bpjs_kesehatan_contribution", bpjs_kesehatan_contribution)
        End If
    End Sub

    Private Sub SLUEPayroll_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles SLUEPayroll.EditValueChanging
        If loaded And GVInput.RowCount > 0 Then
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Change payroll period will reset employee list, are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim data As DataTable = CType(GCInput.DataSource, DataTable).Clone

                GCInput.DataSource = data
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub SBAttachment_Click(sender As Object, e As EventArgs) Handles SBAttachment.Click
        Cursor = Cursors.WaitCursor

        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.id_report = id
        FormDocumentUpload.report_mark_type = "223"
        FormDocumentUpload.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Dim company_contribution As Integer = 0
    Dim employee_contribution As Integer = 0
    Dim total_contribution As Integer = 0

    Private Sub GVAllDepartements_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVAllDepartements.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        '*uncomment if, if total all sogo include
        'If GVAllDepartements.GetRowCellValue(e.RowHandle, "is_sub") = 0 Then
        If item.FieldName.ToString = "company_contribution" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    company_contribution = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    company_contribution += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = company_contribution
            End Select
        End If

        If item.FieldName.ToString = "employee_contribution" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    employee_contribution = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    employee_contribution += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = employee_contribution
            End Select
        End If

        If item.FieldName.ToString = "total_contribution" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    total_contribution = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    total_contribution += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = total_contribution
            End Select
        End If
        'End If
    End Sub

    Private Sub GVInput_CustomDrawGroupRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GVInput.CustomDrawGroupRow
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = TryCast(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo)

        If info.Column.FieldName = "departement_sub" And Not info.EditValue.ToString.Contains("SOGO") Then
            info.GroupText = " "
        End If
    End Sub

    Private Sub GVEmployee_CustomDrawGroupRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GVEmployee.CustomDrawGroupRow
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = TryCast(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo)

        If info.Column.FieldName = "departement_sub" And Not info.EditValue.ToString.Contains("SOGO") Then
            info.GroupText = " "
        End If
    End Sub

    Private Sub GVEmployee_CustomDrawRowFooter(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GVEmployee.CustomDrawRowFooter
        e.Graphics.FillRectangle(New SolidBrush(Color.White), e.Bounds)

        Dim format As StringFormat = e.Appearance.GetStringFormat.Clone

        format.Alignment = StringAlignment.Near

        If GVEmployee.GetGroupRowDisplayText(e.RowHandle).Contains("Group") Then
            e.Graphics.DrawString("Grand Total: " + GVEmployee.GetGroupRowValue(e.RowHandle), e.Appearance.GetFont, e.Appearance.GetForeBrush(e.Cache), e.Bounds, format)
        Else
            If GVEmployee.GetGroupRowDisplayText(e.RowHandle).Contains("SOGO") Then
                e.Graphics.DrawString("Total " + GVEmployee.GetGroupRowDisplayText(e.RowHandle), e.Appearance.GetFont, e.Appearance.GetForeBrush(e.Cache), e.Bounds, format)
            Else
                If Not GVEmployee.GetGroupRowDisplayText(e.RowHandle).Contains("Sub") Then
                    e.Graphics.DrawString("Total " + GVEmployee.GetGroupRowDisplayText(e.RowHandle), e.Appearance.GetFont, e.Appearance.GetForeBrush(e.Cache), e.Bounds, format)
                End If
            End If
        End If

        e.Handled = True
    End Sub

    Private Sub GVEmployee_CustomDrawRowFooterCell(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs) Handles GVEmployee.CustomDrawRowFooterCell
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If view.GetGroupRowDisplayText(e.RowHandle).Contains("Departement Sub") And Not view.GetGroupRowValue(e.RowHandle).ToString.Contains("SOGO") Then
            e.Appearance.ForeColor = Color.White
            e.Handled = True
        End If
    End Sub
End Class