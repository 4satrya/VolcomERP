Public Class ReportEmpPayrollReportBPJSKesehatan
    Public id_pre As String
    Public id_payroll As String
    Public data As DataTable

    Private Sub ReportEmpPayrollReportBPJSKesehatan_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

        Dim total_company As Integer = 0
        Dim total_employee As Integer = 0
        Dim total As Integer = 0

        For i = 0 To data.Rows.Count - 1
            'row
            If i = 0 Then
                row = XTable.InsertRowBelow(XTRow)

                row.HeightF = 16
            Else
                row = XTable.InsertRowBelow(row)
            End If

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)

            no.Text = data.Rows(i)("no").ToString
            no.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            no.BackColor = Color.Transparent

            'departement
            Dim departement As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

            departement.Text = data.Rows(i)("departement").ToString
            departement.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            departement.BackColor = Color.Transparent

            'company contribution
            Dim company_contribution As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)

            company_contribution.Text = Format(data.Rows(i)("company_contribution"), "##,##0")
            company_contribution.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            company_contribution.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            company_contribution.BackColor = Color.Transparent

            'employee contribution
            Dim employee_contribution As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)

            employee_contribution.Text = Format(data.Rows(i)("employee_contribution"), "##,##0")
            employee_contribution.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            employee_contribution.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            employee_contribution.BackColor = Color.Transparent

            'total contribution
            Dim total_contribution As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)

            total_contribution.Text = Format(data.Rows(i)("total_contribution"), "##,##0")
            total_contribution.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
            total_contribution.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            total_contribution.BackColor = Color.Transparent

            'calculate total
            total_company += data.Rows(i)("company_contribution")
            total_employee += data.Rows(i)("employee_contribution")
            total += data.Rows(i)("total_contribution")
        Next

        XTRowTotal.HeightF = 16

        XTRowTotal.Cells.Item(2).Text = Format(total_company, "##,##0")
        XTRowTotal.Cells.Item(3).Text = Format(total_employee, "##,##0")
        XTRowTotal.Cells.Item(4).Text = Format(total, "##,##0")

        'mark
        If id_pre = "-1" Then
            load_mark_horz("192", id_payroll, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("192", id_payroll, "2", "2", XrTable1)
        End If
    End Sub
End Class