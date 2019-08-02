Public Class FormEmpPayrollReportBPJSKesehatan
    Public id_payroll As String = "-1"

    Private Sub FormEmpPayrollReportBPJSKesehatan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '== all ==
        Dim query_all As String = "view_payroll_bpjs(" + id_payroll + ")"

        Dim data_all As DataTable = execute_query(query_all, -1, True, "", "", "", "")

        GCAllDepartements.DataSource = data_all

        'number
        For i = 0 To GVAllDepartements.RowCount - 1
            If GVAllDepartements.IsValidRowHandle(i) Then
                GVAllDepartements.SetRowCellValue(i, "no", i + 1)
            End If
        Next

        GVAllDepartements.BestFitColumns()

        '== detail ==
        Dim query As String = "CALL view_payroll_bpjs_detail(" + id_payroll + ")"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCEmployee.DataSource = data

        'number
        For i = 0 To GVEmployee.RowCount - 1
            If GVEmployee.IsValidRowHandle(i) Then
                GVEmployee.SetRowCellValue(i, "no", i + 1)
            End If
        Next

        GVEmployee.BestFitColumns()

        'controls
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'", 0, True, "", "", "", "")

        If id_report_status = "0" Then
            SBPrint.Enabled = False
        Else
            SBPrint.Enabled = True
        End If
    End Sub

    Private Sub FormEmpPayrollReportBPJSKesehatan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim query As String = "SELECT ump, bpjs_max, bpjs_max_kelas_2 FROM tb_emp_payroll WHERE id_payroll = " + id_payroll

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim query_opt As String = "SELECT bpjs_virtual_acc_1, bpjs_virtual_acc_2 FROM tb_opt"

        Dim data_opt As DataTable = execute_query(query_opt, -1, True, "", "", "", "")

        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = " + id_payroll, 0, True, "", "", "", "")

        Dim id_payroll_before As String = execute_query("SELECT id_payroll FROM tb_emp_payroll WHERE periode_end LIKE CONCAT((SELECT DATE_FORMAT(DATE_SUB(periode_end, INTERVAL 1 MONTH), '%Y-%m') FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + "), '%') AND id_payroll_type = (SELECT id_payroll_type FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + ")", 0, True, "", "", "", "")

        'Dim total_before As String = execute_query("
        'SELECT (IFNULL(company_contribution, 0) + IFNULL(employee_contribution, 0)) AS deduction
        'FROM (
        ' SELECT SUM(IF(ded.id_salary_deduction = 1, (ded.deduction / 0.01) * 0.04, 0)) AS company_contribution, SUM(ded.deduction) AS employee_contribution
        ' FROM tb_emp_payroll_deduction AS ded
        ' LEFT JOIN tb_lookup_salary_deduction AS ded_lookup ON ded.id_salary_deduction = ded_lookup.id_salary_deduction
        ' WHERE ded.id_payroll = " + id_payroll_before + " AND ded_lookup.id_salary_deduction_cat = 2
        ') AS tb", 0, True, "", "", "", "")

        'all
        Dim report As ReportEmpPayrollReportBPJSKesehatan = New ReportEmpPayrollReportBPJSKesehatan

        report.PrintingSystem.ContinuousPageNumbering = False

        report.XLPeriod.Text = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy").ToUpper

        report.id_pre = If(id_report_status = "6", "-1", "1")
        report.id_payroll = id_payroll
        report.data = GCAllDepartements.DataSource

        report.CreateDocument()

        'detail
        Dim data_class As DataTable = execute_query("CALL view_payroll_bpjs_detail(" + id_payroll_before + ")", -1, True, "", "", "", "")

        'Dim total_class1_before As Integer = 0
        'Dim total_class2_before As Integer = 0

        'For i = 0 To data_class.Rows.Count - 1
        '    If data_class.Rows(i)("class").ToString = "I" Then
        '        total_class1_before += 1
        '    ElseIf data_class.Rows(i)("class").ToString = "II" Then
        '        total_class2_before += 1
        '    End If
        'Next

        Dim report_detail As ReportEmpPayrollReportBPJSKesehatanDetail = New ReportEmpPayrollReportBPJSKesehatanDetail

        report_detail.XLPeriod.Text = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy").ToUpper
        report_detail.XLKodeBU.Text = data_opt.Rows(0)("bpjs_virtual_acc_1").ToString.Substring(data_opt.Rows(0)("bpjs_virtual_acc_1").ToString.Length - 8)
        report_detail.XLVirtualAcc.Text = data_opt.Rows(0)("bpjs_virtual_acc_1").ToString
        report_detail.XLMaxKelas1.Text = Format(data.Rows(0)("bpjs_max"), "##,##0")
        report_detail.XLMaxKelas2.Text = Format(data.Rows(0)("bpjs_max_kelas_2"), "##,##0")
        report_detail.XLUMK.Text = Format(data.Rows(0)("ump"), "##,##0")

        'report_detail.XLTotalBefore.Text = Format(Decimal.Parse(total_before), "##,##0")
        'report_detail.XLClass1Before.Text = total_class1_before
        'report_detail.XLClass2Before.Text = total_class2_before

        report_detail.id_pre = If(id_report_status = "6", "-1", "1")
        report_detail.id_payroll = id_payroll
        report_detail.data = GCEmployee.DataSource

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
End Class