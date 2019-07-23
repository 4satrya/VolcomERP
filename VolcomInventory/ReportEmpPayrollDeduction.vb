Public Class ReportEmpPayrollDeduction
    Public type As String = ""
    Public id_payroll As String = ""
    Public is_office_payroll As String = ""
    Public id_pre As String

    Private data_column As DataTable = New DataTable

    Private Sub ReportEmpPayrollDeduction_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'get column
        Dim query_column As String = "
            (
                SELECT tb.id_salary_" + type + "_cat, tb.id_salary_" + type + ", tb.salary_" + type + "_cat, tb.salary_" + type + ", MAX(tb.total) AS total
                FROM (
                    SELECT sald.id_salary_" + type + "_cat, sald.id_salary_" + type + ", saldc.salary_" + type + "_cat, sald.salary_" + type + ", COUNT(sald.id_salary_" + type + ") AS total
                    FROM tb_emp_payroll_" + If(type = "adjustment", "adj", type) + " pyd
                    INNER JOIN tb_lookup_salary_" + type + " sald ON sald.id_salary_" + type + "=pyd.id_salary_" + If(type = "adjustment", "adj", type) + "
                    INNER JOIN tb_lookup_salary_" + type + "_cat saldc ON saldc.id_salary_" + type + "_cat=sald.id_salary_" + type + "_cat
                    WHERE pyd.id_payroll='" + id_payroll + "'
                    GROUP BY pyd.id_employee, sald.id_salary_" + type + "
                    ORDER BY sald.id_salary_" + type + "_cat ASC, sald.id_salary_" + type + " ASC
                ) AS tb
                GROUP BY tb.salary_" + type + "
                ORDER BY tb.id_salary_" + type + "_cat ASC, tb.id_salary_" + type + " ASC
            )
            UNION
            (
                SELECT 99 AS id_salary_" + type + "_cat, 99 AS id_salary_" + type + ", '' AS salary_" + type + "_cat, 'Total' AS salary_" + type + ", 1 AS total
            ) 
            ORDER BY id_salary_" + type + "_cat ASC, id_salary_" + type + " ASC
        "

        data_column = execute_query(query_column, -1, True, "", "", "", "")

        'employee
        Dim query_employee As String = "
            SELECT IFNULL(dep.departement, dep_ori.departement) AS departement,IF(dep.id_departement = 17, IFNULL(sub.departement_sub, sub_ori.departement_sub), IFNULL(dep.departement, dep_ori.departement)) AS departement_sub,emp.employee_code,emp.employee_name,IFNULL(emp_pos.employee_position,emp.`employee_position`) AS employee_position,lvl.employee_status,
                GROUP_CONCAT(sald.salary_" + type + " ORDER BY sald.id_salary_" + type + "_cat ASC, sald.id_salary_" + type + " ASC) AS salary_" + type + "_c,
                GROUP_CONCAT(ROUND(pyd." + If(type = "deduction", "deduction", "value") + ", 0) ORDER BY sald.id_salary_" + type + "_cat ASC, sald.id_salary_" + type + " ASC) AS salary_" + type + "_v
            FROM tb_emp_payroll_" + If(type = "adjustment", "adj", type) + " AS pyd
            LEFT JOIN tb_m_employee emp ON emp.id_employee=pyd.id_employee
            LEFT JOIN (
                SELECT * FROM (
                    SELECT id_employee, id_departement, id_departement_sub, employee_position, employee_position_date
                    FROM tb_m_employee_position
                    WHERE employee_position_date <= (SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "')
                    ORDER BY id_employee_position DESC
                ) AS tab
                GROUP BY id_employee
            ) AS emp_pos ON pyd.id_employee = emp_pos.id_employee
            LEFT JOIN tb_m_departement dep ON dep.id_departement=emp_pos.id_departement
            LEFT JOIN tb_m_departement dep_ori ON dep_ori.id_departement = emp.id_departement
            LEFT JOIN tb_m_departement_sub sub ON sub.`id_departement_sub`=emp_pos.`id_departement_sub`
            LEFT JOIN tb_m_departement_sub sub_ori ON sub_ori.id_departement_sub = emp.id_departement_sub
            LEFT JOIN tb_lookup_employee_status lvl ON lvl.id_employee_status=emp.id_employee_status
            LEFT JOIN tb_lookup_salary_" + type + " sald ON sald.id_salary_" + type + "=pyd.id_salary_" + If(type = "adjustment", "adj", type) + "
            LEFT JOIN tb_lookup_salary_" + type + "_cat saldc ON saldc.id_salary_" + type + "_cat=sald.id_salary_" + type + "_cat
            WHERE pyd.id_payroll='" + id_payroll + "' AND IFNULL(dep.is_office_payroll, dep_ori.is_office_payroll) = '" + is_office_payroll + "'
            GROUP BY pyd.id_employee
            ORDER BY emp.id_employee_level ASC, emp.employee_code ASC 
        "

        Dim data_employee As DataTable = execute_query(query_employee, -1, True, "", "", "", "")

        'data
        Dim data As DataTable = New DataTable()

        data.Columns.Add("Departement", GetType(String))
        data.Columns.Add("Sub Departement", GetType(String))
        data.Columns.Add("NIP", GetType(String))
        data.Columns.Add("Employee", GetType(String))
        data.Columns.Add("Employee Position", GetType(String))
        data.Columns.Add("Employee Status", GetType(String))

        For i = 0 To data_column.Rows.Count - 1
            Dim salary_adjustment As String = data_column.Rows(i)("salary_" + type + "").ToString

            For j = 1 To data_column.Rows(i)("total")
                Dim column As DataColumn = New DataColumn()

                column.ColumnName = salary_adjustment + " " + j.ToString
                column.DataType = GetType(Integer)
                column.DefaultValue = 0

                data.Columns.Add(column)
            Next
        Next

        'insert to data
        For i = 0 To data_employee.Rows.Count - 1
            Dim row As DataRow = data.NewRow

            row("Departement") = data_employee.Rows(i)("departement").ToString
            row("Sub Departement") = data_employee.Rows(i)("departement_sub").ToString
            row("NIP") = data_employee.Rows(i)("employee_code").ToString
            row("Employee") = data_employee.Rows(i)("employee_name").ToString
            row("Employee Position") = data_employee.Rows(i)("employee_position").ToString
            row("Employee Status") = data_employee.Rows(i)("employee_status").ToString

            Dim column As String() = Split(data_employee.Rows(i)("salary_" + type + "_c").ToString, ",")
            Dim value As String() = Split(data_employee.Rows(i)("salary_" + type + "_v").ToString, ",")

            Dim first_column As String = ""

            Dim k As Integer = 1

            Dim total As Integer = 0

            For j = 0 To column.Count - 1
                If first_column = column(j).ToString Then
                    k = k + 1
                Else
                    k = 1
                End If

                Dim row_column As String = column(j).ToString + " " + k.ToString

                'add to row
                row(row_column) = Convert.ToDecimal(value(j))

                'calculate total
                total = total + Convert.ToDecimal(value(j))

                first_column = column(j).ToString
            Next

            'add total
            row("Total 1") = total

            data.Rows.Add(row)
        Next

        'add column to grid
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand

        Dim last_cat As String = ""

        For i = 0 To data_column.Rows.Count - 1
            Dim salary_adjustment_cat As String = data_column.Rows(i)("salary_" + type + "_cat").ToString
            Dim salary_adjustment As String = data_column.Rows(i)("salary_" + type + "").ToString

            For j = 1 To data_column.Rows(i)("total")
                'band
                If Not last_cat = salary_adjustment_cat Then
                    band = GVDeduction.Bands.AddBand(salary_adjustment_cat)
                End If

                last_cat = salary_adjustment_cat

                'column
                Dim column As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()

                column.FieldName = salary_adjustment + " " + j.ToString
                column.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                column.Caption = salary_adjustment.Replace(" ", Environment.NewLine)
                column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                column.DisplayFormat.FormatString = "N0"
                column.Visible = True
                column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                column.SummaryItem.DisplayFormat = "{0:N0}"
                column.MinWidth = 70
                column.Width = 70

                band.Columns.Add(column)

                'grup summary
                Dim group_summary As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()

                group_summary.DisplayFormat = "{0:N0}"
                group_summary.FieldName = salary_adjustment + " " + j.ToString
                group_summary.ShowInGroupColumnFooter = column
                group_summary.SummaryType = DevExpress.Data.SummaryItemType.Custom

                GVDeduction.GroupSummary.Add(group_summary)
            Next
        Next

        GCDeduction.DataSource = data

        'mark
        If id_pre = "-1" Then
            load_mark_horz("192", id_payroll, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("192", id_payroll, "2", "2", XrTable1)
        End If
    End Sub

    Private Sub GVDeduction_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDeduction.CustomColumnDisplayText
        If e.IsForGroupRow Then
            'sogo
            If e.DisplayText.ToString.Contains("SOGO") Then
                If e.Column.Caption = "Departement" Then
                    e.DisplayText = "Departement: " + e.DisplayText
                ElseIf e.Column.Caption = "Sub Departement" Then
                    e.DisplayText = "Sub Departement: " + e.DisplayText
                End If
            Else
                If e.Column.Caption = "Departement" Then
                    e.DisplayText = "Departement: " + e.DisplayText
                ElseIf e.Column.Caption = "Sub Departement" Then
                    e.DisplayText = ""
                End If
            End If
        End If
    End Sub

    Dim total_list As DataTable = New DataTable

    Dim sum As Decimal = 0

    Private Sub GVDeduction_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVDeduction.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        For i = 0 To data_column.Rows.Count - 1
            Dim salary_adjustment_cat As String = data_column.Rows(i)("salary_" + type + "_cat").ToString
            Dim salary_adjustment As String = data_column.Rows(i)("salary_" + type + "").ToString

            For j = 1 To data_column.Rows(i)("total")
                If item.FieldName.ToString = salary_adjustment + " " + j.ToString Then
                    Select Case e.SummaryProcess
                        Case DevExpress.Data.CustomSummaryProcess.Start
                            sum = 0
                        Case DevExpress.Data.CustomSummaryProcess.Calculate
                            sum += e.FieldValue
                        Case DevExpress.Data.CustomSummaryProcess.Finalize
                            If GVDeduction.GetRowCellValue(e.RowHandle, "Sub Departement").ToString.Contains("SOGO") Then
                                e.TotalValue = sum
                            Else
                                If e.GroupLevel = 0 Then
                                    e.TotalValue = sum
                                End If
                            End If
                    End Select
                End If
            Next
        Next
    End Sub
End Class