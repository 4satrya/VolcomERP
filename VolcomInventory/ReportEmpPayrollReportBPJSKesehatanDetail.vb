Public Class ReportEmpPayrollReportBPJSKesehatanDetail
    Public id_pre As String
    Public id_payroll As String
    Public data As DataTable

    Private Sub ReportEmpPayrollReportBPJSKesehatanDetail_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

        Dim last_departement As String = ""

        Dim departement_total_company As Integer = 0
        Dim departement_total_employee As Integer = 0

        Dim total_company As Integer = 0
        Dim total_employee As Integer = 0

        Dim total_class1 As Integer = 0
        Dim total_class2 As Integer = 0

        For i = 0 To data.Rows.Count - 1
            'total departement
            If Not i = 0 And Not last_departement = data.Rows(i)("departement").ToString Then
                row = XTable.InsertRowBelow(row)

                row.Font = New Font(XTRow.Font.FontFamily, XTRow.Font.Size, FontStyle.Bold)

                row.Cells.Item(0).BackColor = Color.FromArgb(196, 215, 155)
                row.Cells.Item(2).BackColor = Color.FromArgb(196, 215, 155)
                row.Cells.Item(3).BackColor = Color.FromArgb(196, 215, 155)
                row.Cells.Item(4).BackColor = Color.FromArgb(196, 215, 155)
                row.Cells.Item(8).BackColor = Color.FromArgb(196, 215, 155)

                'departement name
                Dim departement_name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

                departement_name.Text = "TOTAL " + data.Rows(i - 1)("departement").ToString.ToUpper
                departement_name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
                departement_name.BackColor = Color.FromArgb(196, 215, 155)

                'departement company
                Dim departement_company As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)

                departement_company.Text = Format(departement_total_company, "##,##0")
                departement_company.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                departement_company.BackColor = Color.FromArgb(196, 215, 155)

                'departement employee
                Dim departement_employee As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

                departement_employee.Text = Format(departement_total_employee, "##,##0")
                departement_employee.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                departement_employee.BackColor = Color.FromArgb(196, 215, 155)

                'departement total
                Dim departement_total As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

                departement_total.Text = Format(departement_total_company + departement_total_employee, "##,##0")
                departement_total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                departement_total.BackColor = Color.FromArgb(196, 215, 155)
            End If

            'row
            If i = 0 Then
                row = XTable.InsertRowBelow(XTRow)

                row.HeightF = 16
            Else
                row = XTable.InsertRowBelow(row)
            End If

            row.Font = New Font(XTRow.Font.FontFamily, XTRow.Font.Size, FontStyle.Regular)

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)

            no.Text = data.Rows(i)("no").ToString
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            no.BackColor = Color.Transparent

            'name
            Dim name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

            name.Text = data.Rows(i)("employee_name").ToString
            name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            name.BackColor = Color.Transparent

            'bpjs
            Dim bpjs As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)

            bpjs.Text = data.Rows(i)("employee_bpjs_kesehatan").ToString
            bpjs.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            bpjs.BackColor = Color.Transparent

            'dob
            Dim dob As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)

            dob.Text = data.Rows(i)("employee_dob").ToString
            dob.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            dob.BackColor = Color.Transparent

            'salary
            Dim salary As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)

            salary.Text = Format(data.Rows(i)("employee_salary"), "##,##0")
            salary.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            salary.BackColor = Color.Transparent

            'company
            Dim company As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)

            company.Text = Format(data.Rows(i)("company_contribution"), "##,##0")
            company.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            company.BackColor = Color.Transparent

            'employee
            Dim employee As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

            employee.Text = Format(data.Rows(i)("employee_contribution"), "##,##0")
            employee.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            employee.BackColor = Color.Transparent

            'total
            Dim total As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

            total.Text = Format(data.Rows(i)("total_contribution"), "##,##0")
            total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            total.BackColor = Color.Yellow

            'bpjs class
            Dim bpjs_class As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)

            bpjs_class.Text = data.Rows(i)("class").ToString
            bpjs_class.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            bpjs_class.BackColor = Color.Transparent

            If Not last_departement = data.Rows(i)("departement").ToString Then
                'reset total
                departement_total_company = 0
                departement_total_employee = 0
            End If

            departement_total_company += data.Rows(i)("company_contribution")
            departement_total_employee += data.Rows(i)("employee_contribution")

            total_company += data.Rows(i)("company_contribution")
            total_employee += data.Rows(i)("employee_contribution")

            If data.Rows(i)("class").ToString = "I" Then
                total_class1 += 1
            ElseIf data.Rows(i)("class").ToString = "II" Then
                total_class2 += 1
            End If

            'total departement last
            If i = data.Rows.Count - 1 Then
                row = XTable.InsertRowBelow(row)

                row.Font = New Font(XTRow.Font.FontFamily, XTRow.Font.Size, FontStyle.Bold)

                row.Cells.Item(0).BackColor = Color.FromArgb(196, 215, 155)
                row.Cells.Item(2).BackColor = Color.FromArgb(196, 215, 155)
                row.Cells.Item(3).BackColor = Color.FromArgb(196, 215, 155)
                row.Cells.Item(4).BackColor = Color.FromArgb(196, 215, 155)
                row.Cells.Item(8).BackColor = Color.FromArgb(196, 215, 155)

                'departement name
                Dim departement_name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

                departement_name.Text = "TOTAL " + data.Rows(i)("departement").ToString.ToUpper
                departement_name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
                departement_name.BackColor = Color.FromArgb(196, 215, 155)

                'departement company
                Dim departement_company As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)

                departement_company.Text = Format(departement_total_company, "##,##0")
                departement_company.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                departement_company.BackColor = Color.FromArgb(196, 215, 155)

                'departement employee
                Dim departement_employee As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

                departement_employee.Text = Format(departement_total_employee, "##,##0")
                departement_employee.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                departement_employee.BackColor = Color.FromArgb(196, 215, 155)

                'departement total
                Dim departement_total As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

                departement_total.Text = Format(departement_total_company + departement_total_employee, "##,##0")
                departement_total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                departement_total.BackColor = Color.FromArgb(196, 215, 155)
            End If

            last_departement = data.Rows(i)("departement").ToString
        Next

        'total all
        XTRowSpace.HeightF = 16
        XTRowTotal.HeightF = 16
        XrTableRow1.HeightF = 16
        XrTableRow2.HeightF = 16
        XrTableRow3.HeightF = 16
        XrTableRow4.HeightF = 16
        XrTableRow5.HeightF = 16
        XrTableRow6.HeightF = 16
        XrTableRow7.HeightF = 16

        XTRowTotal.Cells.Item(1).Text = data.Rows.Count
        XTRowTotal.Cells.Item(4).Text = Format(total_company, "##,##0")
        XTRowTotal.Cells.Item(5).Text = Format(total_employee, "##,##0")
        XTRowTotal.Cells.Item(6).Text = Format(total_company + total_employee, "##,##0")

        XLClass1.Text = total_class1
        XLClass2.Text = total_class2

        XLTotal.Text = Format(total_company + total_employee, "##,##0")

        'mark
        If id_pre = "-1" Then
            load_mark_horz("192", id_payroll, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("192", id_payroll, "2", "2", XrTable1)
        End If
    End Sub
End Class