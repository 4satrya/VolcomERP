Public Class FormEmpPayrollReportBPJSTK
    Public id_payroll As String = "-1"

    Private Sub FormEmpPayrollReportBPJSTK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '== all ==
        Dim query_all As String = "CALL view_payroll_bpjstk(" + id_payroll + ")"

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
        GCEmployeeSalary.Caption = "Upah " + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy")
        GCEmployeeSalaryBefore.Caption = "Upah " + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).AddMonths(-1).ToString("MMMM yyyy")

        Dim query As String = "CALL view_payroll_bpjstk_detail(" + id_payroll + ")"

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

    Private Sub FormEmpPayrollReportBPJSTK_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = " + id_payroll, 0, True, "", "", "", "")

        'all
        Dim report As ReportEmpPayrollReportBPJSTK = New ReportEmpPayrollReportBPJSTK

        report.PrintingSystem.ContinuousPageNumbering = False

        report.XLPeriod.Text = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy").ToUpper

        report.id_pre = If(id_report_status = "6", "-1", "1")
        report.id_payroll = id_payroll
        report.data = GCAllDepartements.DataSource

        report.CreateDocument()

        'detail
        Dim data As DataTable = GCEmployee.DataSource

        Dim location As List(Of String) = New List(Of String)

        For i = 0 To data.Rows.Count - 1
            If Not location.Contains(data.Rows(i)("bpjs_tk_location").ToString) Then
                location.Add(data.Rows(i)("bpjs_tk_location").ToString)
            End If
        Next

        Dim list_report As List(Of ReportEmpPayrollReportBPJSTKDetail) = New List(Of ReportEmpPayrollReportBPJSTKDetail)

        For i = 0 To location.Count - 1
            Dim data_new As DataTable = data.Clone

            For j = 0 To data.Rows.Count - 1
                If location(i).ToString = data.Rows(j)("bpjs_tk_location").ToString Then
                    data_new.ImportRow(data.Rows(j))
                End If
            Next

            Dim report_detail As ReportEmpPayrollReportBPJSTKDetail = New ReportEmpPayrollReportBPJSTKDetail

            report_detail.XLPeriod.Text = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy").ToUpper

            report_detail.id_pre = If(id_report_status = "6", "-1", "1")
            report_detail.id_payroll = id_payroll
            report_detail.data = data_new

            report_detail.XLLocation.Text = "PT. VOLCOM INDONESIA (" + location(i).ToString + ")"

            report_detail.XrTableCell15.Text = "UPAH " + Environment.NewLine + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy").ToUpper
            report_detail.XrTableCell11.Text = "UPAH " + Environment.NewLine + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).AddMonths(-1).ToString("MMMM yyyy").ToUpper

            report_detail.CreateDocument()

            list_report.Add(report_detail)
        Next

        'combine
        Dim list As List(Of DevExpress.XtraPrinting.Page) = New List(Of DevExpress.XtraPrinting.Page)

        For i = 0 To report.Pages.Count - 1
            list.Add(report.Pages(i))
        Next

        For i = 0 To list_report.Count - 1
            For j = 0 To list_report(i).Pages.Count - 1
                list.Add(list_report(i).Pages(j))
            Next
        Next

        report.Pages.AddRange(list)

        Dim tool_detail As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool_detail.ShowPreview()
    End Sub
End Class