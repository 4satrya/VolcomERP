Public Class ReportEmpPayrollReportBPJSKesehatanDetail
    Public id_pre As String
    Public id_report As String
    Public data As DataTable
    Public report_mark_type As String

    Private Sub ReportEmpPayrollReportBPJSKesehatanDetail_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

        Dim last_departement As String = ""
        Dim last_departement_sub As String = ""

        Dim departement_total_company As Decimal = 0
        Dim departement_total_employee As Decimal = 0
        Dim departement_total_all As Decimal = 0

        Dim departement_sub_total_company As Decimal = 0
        Dim departement_sub_total_employee As Decimal = 0
        Dim departement_sub_total_all As Decimal = 0

        Dim total_company As Decimal = 0
        Dim total_employee As Decimal = 0
        Dim total_all As Decimal = 0

        Dim total_class1 As Decimal = 0
        Dim total_class2 As Decimal = 0

        For i = 0 To data.Rows.Count - 1
            'last sogo
            If Not i = 0 And Not data.Rows(i)("id_departement").ToString = "17" Then
                If data.Rows(i - 1)("id_departement").ToString = "17" Then
                    row = XTable.InsertRowBelow(row)

                    row.Font = New Font(XTRow.Font.FontFamily, XTRow.Font.Size, FontStyle.Bold)

                    row.Cells.Item(0).BackColor = Color.LightGray
                    row.Cells.Item(2).BackColor = Color.LightGray
                    row.Cells.Item(3).BackColor = Color.LightGray
                    row.Cells.Item(4).BackColor = Color.LightGray
                    row.Cells.Item(8).BackColor = Color.LightGray

                    'departement name
                    Dim departement_name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

                    departement_name.Text = "TOTAL " + data.Rows(i - 1)("departement_sub").ToString.ToUpper
                    departement_name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
                    departement_name.BackColor = Color.LightGray

                    'departement company
                    Dim departement_company As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)

                    departement_company.Text = Format(departement_sub_total_company, "##,##0.00")
                    departement_company.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                    departement_company.BackColor = Color.LightGray

                    'departement employee
                    Dim departement_employee As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

                    departement_employee.Text = Format(departement_sub_total_employee, "##,##0.00")
                    departement_employee.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                    departement_employee.BackColor = Color.LightGray

                    'departement total
                    Dim departement_total As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

                    departement_total.Text = Format(departement_sub_total_all, "##,##0")
                    departement_total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                    departement_total.BackColor = Color.LightGray
                End If
            End If

            'total departement
            If Not i = 0 And Not last_departement = data.Rows(i)("departement").ToString Then
                row = XTable.InsertRowBelow(row)

                row.Font = New Font(XTRow.Font.FontFamily, XTRow.Font.Size, FontStyle.Bold)

                row.Cells.Item(0).BackColor = Color.LightGray
                row.Cells.Item(2).BackColor = Color.LightGray
                row.Cells.Item(3).BackColor = Color.LightGray
                row.Cells.Item(4).BackColor = Color.LightGray
                row.Cells.Item(8).BackColor = Color.LightGray

                'departement name
                Dim departement_name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

                departement_name.Text = "TOTAL " + data.Rows(i - 1)("departement").ToString.ToUpper
                departement_name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
                departement_name.BackColor = Color.LightGray

                'departement company
                Dim departement_company As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)

                departement_company.Text = Format(departement_total_company, "##,##0.00")
                departement_company.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                departement_company.BackColor = Color.LightGray

                'departement employee
                Dim departement_employee As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

                departement_employee.Text = Format(departement_total_employee, "##,##0.00")
                departement_employee.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                departement_employee.BackColor = Color.LightGray

                'departement total
                Dim departement_total As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

                departement_total.Text = Format(departement_total_all, "##,##0")
                departement_total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                departement_total.BackColor = Color.LightGray
            End If

            'total sogo
            If data.Rows(i)("id_departement").ToString = "17" And Not departement_sub_total_employee = 0 Then
                If Not i = 0 And Not last_departement_sub = data.Rows(i)("departement_sub").ToString Then
                    row = XTable.InsertRowBelow(row)

                    row.Font = New Font(XTRow.Font.FontFamily, XTRow.Font.Size, FontStyle.Bold)

                    row.Cells.Item(0).BackColor = Color.LightGray
                    row.Cells.Item(2).BackColor = Color.LightGray
                    row.Cells.Item(3).BackColor = Color.LightGray
                    row.Cells.Item(4).BackColor = Color.LightGray
                    row.Cells.Item(8).BackColor = Color.LightGray

                    'departement name
                    Dim departement_name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

                    departement_name.Text = "TOTAL " + data.Rows(i - 1)("departement_sub").ToString.ToUpper
                    departement_name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
                    departement_name.BackColor = Color.LightGray

                    'departement company
                    Dim departement_company As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)

                    departement_company.Text = Format(departement_sub_total_company, "##,##0.00")
                    departement_company.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                    departement_company.BackColor = Color.LightGray

                    'departement employee
                    Dim departement_employee As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

                    departement_employee.Text = Format(departement_sub_total_employee, "##,##0.00")
                    departement_employee.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                    departement_employee.BackColor = Color.LightGray

                    'departement total
                    Dim departement_total As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

                    departement_total.Text = Format(departement_sub_total_all, "##,##0")
                    departement_total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                    departement_total.BackColor = Color.LightGray
                End If
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

            company.Text = Format(data.Rows(i)("company_contribution"), "##,##0.00")
            company.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            company.BackColor = Color.Transparent

            'employee
            Dim employee As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

            employee.Text = Format(data.Rows(i)("employee_contribution"), "##,##0.00")
            employee.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            employee.BackColor = Color.Transparent

            'total
            Dim total As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

            total.Text = Format(data.Rows(i)("total_contribution"), "##,##0")
            total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            total.BackColor = Color.WhiteSmoke

            'bpjs class
            Dim bpjs_class As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)

            bpjs_class.Text = data.Rows(i)("class").ToString
            bpjs_class.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            bpjs_class.BackColor = Color.Transparent

            If Not last_departement = data.Rows(i)("departement").ToString Then
                'reset total
                departement_total_company = 0
                departement_total_employee = 0
                departement_total_all = 0
            End If

            departement_total_company += data.Rows(i)("company_contribution")
            departement_total_employee += data.Rows(i)("employee_contribution")
            departement_total_all += data.Rows(i)("total_contribution")

            total_company += data.Rows(i)("company_contribution")
            total_employee += data.Rows(i)("employee_contribution")
            total_all += data.Rows(i)("total_contribution")

            'sogo
            If data.Rows(i)("id_departement").ToString = "17" Then
                If Not last_departement_sub = data.Rows(i)("departement_sub").ToString Then
                    departement_sub_total_company = 0
                    departement_sub_total_employee = 0
                    departement_sub_total_all = 0
                End If

                departement_sub_total_company += data.Rows(i)("company_contribution")
                departement_sub_total_employee += data.Rows(i)("employee_contribution")
                departement_sub_total_all += data.Rows(i)("total_contribution")
            End If


            If data.Rows(i)("class").ToString = "I" Then
                total_class1 += 1
            ElseIf data.Rows(i)("class").ToString = "II" Then
                total_class2 += 1
            End If

            'total departement last
            If i = data.Rows.Count - 1 Then
                row = XTable.InsertRowBelow(row)

                row.Font = New Font(XTRow.Font.FontFamily, XTRow.Font.Size, FontStyle.Bold)

                row.Cells.Item(0).BackColor = Color.LightGray
                row.Cells.Item(2).BackColor = Color.LightGray
                row.Cells.Item(3).BackColor = Color.LightGray
                row.Cells.Item(4).BackColor = Color.LightGray
                row.Cells.Item(8).BackColor = Color.LightGray

                'departement name
                Dim departement_name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

                departement_name.Text = "TOTAL " + data.Rows(i)("departement").ToString.ToUpper
                departement_name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
                departement_name.BackColor = Color.LightGray

                'departement company
                Dim departement_company As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)

                departement_company.Text = Format(departement_total_company, "##,##0.00")
                departement_company.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                departement_company.BackColor = Color.LightGray

                'departement employee
                Dim departement_employee As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

                departement_employee.Text = Format(departement_total_employee, "##,##0.00")
                departement_employee.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                departement_employee.BackColor = Color.LightGray

                'departement total
                Dim departement_total As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

                departement_total.Text = Format(departement_total_all, "##,##0")
                departement_total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                departement_total.BackColor = Color.LightGray
            End If

            last_departement = data.Rows(i)("departement").ToString

            If data.Rows(i)("id_departement").ToString = "17" Then
                last_departement_sub = data.Rows(i)("departement_sub").ToString
            End If
        Next

        'total all
        XTRowSpace.HeightF = 16
        XTRowTotal.HeightF = 16
        'XrTableRow1.HeightF = 16
        'XrTableRow2.HeightF = 16
        'XrTableRow3.HeightF = 16
        'XrTableRow4.HeightF = 16
        'XrTableRow5.HeightF = 16
        'XrTableRow6.HeightF = 16
        'XrTableRow7.HeightF = 16

        XTRowTotal.Cells.Item(1).Text = data.Rows.Count
        XTRowTotal.Cells.Item(4).Text = Format(total_company, "##,##0.00")
        XTRowTotal.Cells.Item(5).Text = Format(total_employee, "##,##0.00")
        XTRowTotal.Cells.Item(6).Text = Format(total_all, "##,##0")

        'XLClass1.Text = total_class1
        'XLClass2.Text = total_class2

        'XLTotal.Text = Format(total_company + total_employee, "##,##0")

        'mark
        If id_pre = "-1" Then
            load_mark_horz(report_mark_type, id_report, "2", "1", XrTable1)
        Else
            pre_load_mark_horz(report_mark_type, id_report, "2", "2", XrTable1)
        End If
    End Sub
End Class