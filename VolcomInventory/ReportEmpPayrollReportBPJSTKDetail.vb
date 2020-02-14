Public Class ReportEmpPayrollReportBPJSTKDetail
    Public id_pre As String
    Public id_payroll As String
    Public data As DataTable

    Private Sub ReportEmpPayrollReportBPJSTKDetail_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

        Dim last_departement As String = ""

        Dim number As Integer = 1

        Dim departement_company_contribution_1 As Decimal = 0
        Dim departement_company_contribution_2 As Decimal = 0
        Dim departement_employee_contribution_1 As Decimal = 0
        Dim departement_employee_contribution_2 As Decimal = 0
        Dim departement_salary_before As Decimal = 0
        Dim departement_salary As Decimal = 0
        Dim departement_total As Decimal = 0

        Dim total_company_contribution_1 As Decimal = 0
        Dim total_company_contribution_2 As Decimal = 0
        Dim total_employee_contribution_1 As Decimal = 0
        Dim total_employee_contribution_2 As Decimal = 0
        Dim total_salary_before As Decimal = 0
        Dim total_salary As Decimal = 0
        Dim total As Decimal = 0

        For i = 0 To data.Rows.Count - 1
            'total departement
            If Not i = 0 And Not last_departement = data.Rows(i)("departement").ToString Then
                row = XTable.InsertRowBelow(row)

                row.Font = New Font(XTRow.Font.FontFamily, XTRow.Font.Size, FontStyle.Bold)

                row.Cells.Item(0).BackColor = Color.LightGray
                row.Cells.Item(1).BackColor = Color.LightGray
                row.Cells.Item(3).BackColor = Color.LightGray
                row.Cells.Item(4).BackColor = Color.LightGray
                row.Cells.Item(5).BackColor = Color.LightGray
                row.Cells.Item(6).BackColor = Color.LightGray
                row.Cells.Item(7).BackColor = Color.LightGray

                'total
                Dim total_text As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)

                total_text.Text = "TOTAL"
                total_text.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
                total_text.BackColor = Color.LightGray

                'salary before
                Dim sal_before As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

                sal_before.Text = Format(departement_salary_before, "##,##0")
                sal_before.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                sal_before.BackColor = Color.LightGray

                'salary
                Dim sal As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

                sal.Text = Format(departement_salary, "##,##0")
                sal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                sal.BackColor = Color.LightGray

                'company 1
                Dim departement_company_1 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)

                departement_company_1.Text = Format(departement_company_contribution_1, "##,##0.00")
                departement_company_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                departement_company_1.BackColor = Color.LightGray

                'company 2
                Dim departement_company_2 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(9)

                departement_company_2.Text = Format(departement_company_contribution_2, "##,##0.00")
                departement_company_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                departement_company_2.BackColor = Color.LightGray

                'employee 1
                Dim employee_company_1 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(10)

                employee_company_1.Text = Format(departement_employee_contribution_1, "##,##0.00")
                employee_company_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                employee_company_1.BackColor = Color.LightGray

                'employee 2
                Dim employee_company_2 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(11)

                employee_company_2.Text = Format(departement_employee_contribution_2, "##,##0.00")
                employee_company_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                employee_company_2.BackColor = Color.LightGray

                'total
                Dim total_departement As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(12)

                total_departement.Text = Format(departement_total, "##,##0.00")
                total_departement.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                total_departement.BackColor = Color.LightGray
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

            no.Text = number.ToString
            no.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            no.BackColor = Color.White

            'kjp
            Dim employee_bpjs_tk As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

            employee_bpjs_tk.Text = data.Rows(i)("employee_bpjs_tk").ToString
            employee_bpjs_tk.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            employee_bpjs_tk.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            employee_bpjs_tk.BackColor = Color.White

            'nama
            Dim employee_name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)

            employee_name.Text = data.Rows(i)("employee_name").ToString
            employee_name.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            employee_name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            employee_name.BackColor = Color.White

            'jenis kelamin
            Dim employee_sex As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)

            employee_sex.Text = data.Rows(i)("employee_sex").ToString
            employee_sex.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            employee_sex.BackColor = Color.Transparent

            'dob
            Dim employee_dob As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)

            employee_dob.Text = data.Rows(i)("employee_dob").ToString
            employee_dob.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            employee_dob.BackColor = Color.Transparent

            'kep prog
            Dim kep_prog As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)

            kep_prog.Text = data.Rows(i)("kep_prog").ToString
            kep_prog.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            kep_prog.BackColor = Color.Transparent

            'salary before
            Dim employee_salary_before As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

            employee_salary_before.Text = Format(data.Rows(i)("employee_salary_before"), "##,##0")
            employee_salary_before.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            employee_salary_before.BackColor = Color.Transparent

            'salary
            Dim employee_salary As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

            employee_salary.Text = Format(data.Rows(i)("employee_salary"), "##,##0")
            employee_salary.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            employee_salary.BackColor = Color.Transparent

            'company 1
            Dim company_contribution_1 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)

            company_contribution_1.Text = Format(data.Rows(i)("company_contribution_1"), "##,##0.00")
            company_contribution_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            company_contribution_1.BackColor = Color.Transparent

            'company 2
            Dim company_contribution_2 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(9)

            company_contribution_2.Text = Format(data.Rows(i)("company_contribution_2"), "##,##0.00")
            company_contribution_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            company_contribution_2.BackColor = Color.Transparent

            'employee 1
            Dim employee_contribution_1 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(10)

            employee_contribution_1.Text = Format(data.Rows(i)("employee_contribution_1"), "##,##0.00")
            employee_contribution_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            employee_contribution_1.BackColor = Color.Transparent

            'employee 2
            Dim employee_contribution_2 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(11)

            employee_contribution_2.Text = Format(data.Rows(i)("employee_contribution_2"), "##,##0.00")
            employee_contribution_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            employee_contribution_2.BackColor = Color.Transparent

            'total
            Dim total_contribution As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(12)

            total_contribution.Text = Format((data.Rows(i)("total_contribution")), "##,##0.00")
            total_contribution.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            total_contribution.BackColor = Color.Transparent

            If Not last_departement = data.Rows(i)("departement").ToString Then
                departement_company_contribution_1 = 0
                departement_company_contribution_2 = 0
                departement_employee_contribution_1 = 0
                departement_employee_contribution_2 = 0
                departement_salary_before = 0
                departement_salary = 0
                departement_total = 0
            End If

            number += 1

            departement_company_contribution_1 += data.Rows(i)("company_contribution_1")
            departement_company_contribution_2 += data.Rows(i)("company_contribution_2")
            departement_employee_contribution_1 += data.Rows(i)("employee_contribution_1")
            departement_employee_contribution_2 += data.Rows(i)("employee_contribution_2")
            departement_salary_before += data.Rows(i)("employee_salary_before")
            departement_salary += data.Rows(i)("employee_salary")
            departement_total += data.Rows(i)("total_contribution")

            total_company_contribution_1 += data.Rows(i)("company_contribution_1")
            total_company_contribution_2 += data.Rows(i)("company_contribution_2")
            total_employee_contribution_1 += data.Rows(i)("employee_contribution_1")
            total_employee_contribution_2 += data.Rows(i)("employee_contribution_2")
            total_salary_before += data.Rows(i)("employee_salary_before")
            total_salary += data.Rows(i)("employee_salary")
            total += data.Rows(i)("total_contribution")

            'total departement last
            If i = data.Rows.Count - 1 Then
                row = XTable.InsertRowBelow(row)

                row.Font = New Font(XTRow.Font.FontFamily, XTRow.Font.Size, FontStyle.Bold)

                row.Cells.Item(0).BackColor = Color.LightGray
                row.Cells.Item(1).BackColor = Color.LightGray
                row.Cells.Item(3).BackColor = Color.LightGray
                row.Cells.Item(4).BackColor = Color.LightGray
                row.Cells.Item(5).BackColor = Color.LightGray
                row.Cells.Item(6).BackColor = Color.LightGray
                row.Cells.Item(7).BackColor = Color.LightGray

                'total
                Dim total_text As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)

                total_text.Text = "TOTAL"
                total_text.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
                total_text.BackColor = Color.LightGray

                'salary before
                Dim sal_before As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

                sal_before.Text = Format(departement_salary_before, "##,##0")
                sal_before.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                sal_before.BackColor = Color.LightGray

                'salary
                Dim sal As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

                sal.Text = Format(departement_salary, "##,##0")
                sal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                sal.BackColor = Color.LightGray

                'company 1
                Dim departement_company_1 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)

                departement_company_1.Text = Format(departement_company_contribution_1, "##,##0.00")
                departement_company_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                departement_company_1.BackColor = Color.LightGray

                'company 2
                Dim departement_company_2 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(9)

                departement_company_2.Text = Format(departement_company_contribution_2, "##,##0.00")
                departement_company_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                departement_company_2.BackColor = Color.LightGray

                'employee 1
                Dim employee_company_1 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(10)

                employee_company_1.Text = Format(departement_employee_contribution_1, "##,##0.00")
                employee_company_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                employee_company_1.BackColor = Color.LightGray

                'employee 2
                Dim employee_company_2 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(11)

                employee_company_2.Text = Format(departement_employee_contribution_2, "##,##0.00")
                employee_company_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                employee_company_2.BackColor = Color.LightGray

                'total
                Dim total_departement As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(12)

                total_departement.Text = Format(departement_total, "##,##0.00")
                total_departement.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                total_departement.BackColor = Color.LightGray
            End If

            last_departement = data.Rows(i)("departement").ToString
        Next

        XTTotal.HeightF = 16

        XTTotal.Cells.Item(2).Text = Format(total_salary_before, "##,##0")
        XTTotal.Cells.Item(3).Text = Format(total_salary, "##,##0")
        XTTotal.Cells.Item(4).Text = Format(total_company_contribution_1, "##,##0.00")
        XTTotal.Cells.Item(5).Text = Format(total_company_contribution_2, "##,##0.00")
        XTTotal.Cells.Item(6).Text = Format(total_employee_contribution_1, "##,##0.00")
        XTTotal.Cells.Item(7).Text = Format(total_employee_contribution_2, "##,##0.00")
        XTTotal.Cells.Item(8).Text = Format(total, "##,##0.00")

        'mark
        If id_pre = "-1" Then
            load_mark_horz("192", id_payroll, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("192", id_payroll, "2", "2", XrTable1)
        End If

        'remove last signature
        For i = 0 To XrTable1.Rows.Count - 1
            For j = 0 To XrTable1.Rows.Item(i).Cells.Count - 1
                If j = XrTable1.Rows.Item(i).Cells.Count - 1 Then
                    XrTable1.Rows.Item(i).Cells.RemoveAt(j)
                End If
            Next
        Next
    End Sub
End Class