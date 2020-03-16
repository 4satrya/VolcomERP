Public Class FormEmpOvertime
    Public is_hrd As String = "-1"

    Public last_click As String = ""

    Private Sub FormEmpOvertime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSearchLookupQuery(SLUEPayroll, "SELECT id_payroll, DATE_FORMAT(ot_periode_start, '%d %M %Y') AS periode_start, DATE_FORMAT(ot_periode_end, '%d %M %Y') AS periode_end, DATE_FORMAT(periode_end, '%M %Y') as periode FROM tb_emp_payroll WHERE id_payroll_type = 1 ORDER BY ot_periode_end DESC", "id_payroll", "periode", "id_payroll")

        form_load()

        Dim data_date As DataTable = execute_query("(SELECT id_payroll, DATE_FORMAT(ot_periode_start, '%d %M %Y') AS periode_start, DATE_FORMAT(ot_periode_end, '%d %M %Y') AS periode_end FROM tb_emp_payroll WHERE DATE(NOW()) >= ot_periode_start AND DATE(NOW()) <= ot_periode_end AND id_payroll_type = 1) UNION (SELECT id_payroll, DATE_FORMAT(ot_periode_start, '%d %M %Y') AS periode_start, DATE_FORMAT(ot_periode_end, '%d %M %Y') AS periode_end FROM tb_emp_payroll WHERE id_payroll_type = 1 ORDER BY ot_periode_end DESC LIMIT 1)", -1, True, "", "", "", "")

        SLUEPayroll.EditValue = data_date.Rows(0)("id_payroll")
        DEStart.EditValue = data_date.Rows(0)("periode_start")
        DEUntil.EditValue = data_date.Rows(0)("periode_end")

        If is_hrd = "-1" Then
            SLUEDepartement.EditValue = id_departement_user

            Text = "Propose Overtime"
        Else
            SLUEDepartement.EditValue = 0

            Text = "Overtime Management"
        End If

        If Not is_hrd = "1" Then
            GVVerificationEmployee.Columns("total_hours").Visible = False
            GVVerificationEmployee.Columns("point_ot").Visible = False
        End If
    End Sub

    Sub form_load()
        view_departement()
        view_employee()
        view_conversion_type()
    End Sub

    Sub load_overtime(ByVal type As String)
        Dim where_date As String = ""

        If type = "ot_date" Then
            where_date = "AND ot.id_ot IN (SELECT id_ot FROM tb_ot_det WHERE ot_date BETWEEN '" + Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND '" + Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "')"
        ElseIf type = "created_at" Then
            where_date = "AND DATE(ot.created_at) BETWEEN '" + Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND '" + Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
        End If

        If XTCPropose.SelectedTabPage.Name = "XTPByEmployee" Then
            Dim where_departement As String = ""

            Try
                If Not SLUEDepartement.EditValue.ToString = "0" Then
                    where_departement = "AND ot_det.id_departement = " + SLUEDepartement.EditValue.ToString
                End If
            Catch ex As Exception
            End Try

            Dim where_employee As String = ""

            Try
                If Not SLUEEmployee.EditValue.ToString = "0" Then
                    where_employee = "AND ot_det.id_employee = " + SLUEEmployee.EditValue.ToString
                End If
            Catch ex As Exception
            End Try

            Dim query As String = "
                SELECT ot_det.id_ot_det, ot_det.id_employee, ot_det.id_departement, ot_det.id_departement_sub, departement.departement, employee.employee_code, employee.employee_name, ot_det.employee_position, ot_det.id_employee_status, employee_status.employee_status, ot_det.to_salary, ot_det.conversion_type, ot.id_ot, ot.number, ot.id_ot_type, CONCAT(IF(ot_type.is_event = 1, 'Event ', ''), ot_type.ot_type) AS ot_type, DATE_FORMAT(ot_det.ot_date, '%d %M %Y') AS ot_date, IF(((SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_det.id_employee AND date = ot_det.ot_date) = 1 OR (SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_det.id_employee AND date = ot_det.ot_date) IS NULL) AND ((SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = ot_det.ot_date AND id_religion IN (0, IF(departement.is_store = 1, 0, employee.id_religion))) IS NULL), 2, 1) AS is_day_off, DATE_FORMAT(ot_det.ot_start_time, '%H:%i:%s') AS ot_start_time, DATE_FORMAT(ot_det.ot_end_time, '%H:%i:%s') AS ot_end_time, ot_det.ot_break, ROUND((TIMESTAMPDIFF(MINUTE, ot_det.ot_start_time, ot_det.ot_end_time) / 60) - ot_det.ot_break, 1) AS ot_total_hours, ot_det.ot_note, ot.id_report_status, report_status.report_status, created_by.employee_name AS created_by, DATE_FORMAT(ot.created_at, '%d %M %Y %H:%i:%s') AS created_at
                FROM tb_ot_det AS ot_det
                LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
                LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
                LEFT JOIN tb_m_departement AS departement ON ot_det.id_departement = departement.id_departement
                LEFT JOIN tb_lookup_employee_status AS employee_status ON ot_det.id_employee_status = employee_status.id_employee_status
                LEFT JOIN tb_lookup_report_status AS report_status ON ot.id_report_status = report_status.id_report_status
                LEFT JOIN tb_m_employee AS created_by ON ot.created_by = created_by.id_employee
                WHERE 1 " + where_date + " " + where_departement + " " + where_employee + "
                ORDER BY departement.departement ASC, employee.id_employee_level ASC, employee.employee_code ASC, ot.number DESC, ot_det.ot_date ASC
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCProposeEmployee.DataSource = data

            GVProposeEmployee.BestFitColumns()
        Else
            Dim where_departement As String = ""

            Try
                If Not SLUEDepartement.EditValue.ToString = "0" Then
                    where_departement = "AND ot.id_departement = " + SLUEDepartement.EditValue.ToString
                End If
            Catch ex As Exception
            End Try

            Dim query As String = "
                SELECT ot.id_ot, ot.id_ot_type, CONCAT(IF(ot_type.is_event = 1, 'Event ', ''), ot_type.ot_type) AS ot_type, ot.id_departement, departement.departement, CONCAT(GROUP_CONCAT(DISTINCT DATE_FORMAT(ot_det.ot_date, '%d %M %Y') ORDER BY ot_det.ot_date ASC SEPARATOR ',')) AS ot_date, ot.number, GROUP_CONCAT(DISTINCT ot_det.ot_note SEPARATOR ', ') AS ot_note, ot.id_report_status, report_status.report_status, employee.employee_name AS created_by, DATE_FORMAT(ot.created_at, '%d %M %Y %H:%i:%s') AS created_at
                FROM tb_ot_det AS ot_det
                LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
                LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                LEFT JOIN tb_m_departement AS departement ON ot.id_departement = departement.id_departement
                LEFT JOIN tb_lookup_report_status AS report_status ON ot.id_report_status = report_status.id_report_status
                LEFT JOIN tb_m_employee AS employee ON ot.created_by = employee.id_employee
                WHERE 1 " + where_date + " " + where_departement + " 
                GROUP BY ot.id_ot
                ORDER BY ot.number DESC
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            'date
            Dim last_date As Date = New Date()

            For i = 0 To data.Rows.Count - 1
                Dim final_date As String = ""

                Dim temp_date As String() = data.Rows(i)("ot_date").ToString.Split(",")

                Dim group_date As Integer = 1

                For j = 0 To temp_date.Count - 1
                    Dim now_date As Date = Date.Parse(temp_date(j))

                    If j = 0 Then
                        last_date = now_date

                        final_date = now_date.ToString("dd MMMM yyyy")
                    Else
                        If Not last_date.AddDays(1) = now_date Then
                            If group_date = 1 Then
                                final_date += ", " + now_date.ToString("dd MMMM yyyy")
                            Else
                                final_date += " - " + last_date.ToString("dd MMMM yyyy") + ", " + now_date.ToString("dd MMMM yyyy")
                            End If

                            group_date = 1
                        Else
                            group_date = group_date + 1
                        End If

                        'last date
                        If j = temp_date.Count - 1 Then
                            If last_date.AddDays(1) = now_date Then
                                final_date += " - " + now_date.ToString("dd MMMM yyyy")
                            End If
                        End If

                        last_date = now_date
                    End If
                Next

                data.Rows(i)("ot_date") = final_date
            Next

            GCOvertime.DataSource = data

            GVOvertime.BestFitColumns()
        End If
    End Sub

    Sub load_verification(ByVal type As String)
        Dim where_date As String = ""

        If type = "ot_date" Then
            where_date = "AND ot_verification.ot_date BETWEEN '" + Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND '" + Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
        ElseIf type = "created_at" Then
            where_date = "AND DATE(ot_verification.created_at) BETWEEN '" + Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND '" + Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
        End If

        If XTCVerification.SelectedTabPage.Name = "XTPByEmployeeVerification" Then
            Dim where_departement As String = ""

            Try
                If Not SLUEDepartement.EditValue.ToString = "0" Then
                    where_departement = "AND employee.id_departement = " + SLUEDepartement.EditValue.ToString
                End If
            Catch ex As Exception
            End Try

            Dim where_employee As String = ""

            Try
                If Not SLUEEmployee.EditValue.ToString = "0" Then
                    where_employee = "AND ot_verification_det.id_employee = " + SLUEEmployee.EditValue.ToString
                End If
            Catch ex As Exception
            End Try

            Dim query As String = "
                SELECT * 
                FROM (
                    (SELECT ot_verification_det.id_employee, ot_verification_det.id_departement, ot_verification_det.id_departement_sub, departement.departement, IF(ot_type.is_point_ho = 1, 2, IF(ot_verification_det.id_departement_sub = 46, 1, departement.is_store)) AS is_store, employee.employee_code, employee.employee_name, ot_verification_det.employee_position, ot_verification_det.id_employee_status, employee_status.employee_status, employee.id_employee_level, ot_verification_det.to_salary, ot_verification_det.conversion_type, ot_verification.id_ot, ot_verification.id_ot_verification, ot.number, ot.id_ot_type, CONCAT(IF(ot_type.is_event = 1, 'Event ', ''), ot_type.ot_type) AS ot_type, DATE_FORMAT(ot_verification.ot_date, '%d %M %Y') AS ot_date, IF(((SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_verification_det.id_employee AND date = ot_verification.ot_date) = 1 OR (SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_verification_det.id_employee AND date = ot_verification.ot_date) IS NULL) AND ((SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = ot_verification.ot_date AND id_religion IN (0, IF(departement.is_store = 1, 0, employee.id_religion))) IS NULL), 2, 1) AS is_day_off, DATE_FORMAT(ot_verification_det.start_work_ot, '%H:%i:%s') AS start_work_ot, DATE_FORMAT(ot_verification_det.end_work_ot, '%H:%i:%s') AS end_work_ot, ot_verification_det.break_hours, ROUND((TIMESTAMPDIFF(MINUTE, ot_verification_det.start_work_ot, ot_verification_det.end_work_ot) / 60) - ot_verification_det.break_hours, 1) AS ot_hours, ot_verification_det.total_hours, 0.0 AS point_ot, ot_verification_det.ot_note, IF(ot_verification_det.is_valid = 1, 'yes', 'no') AS is_valid, ot_verification.id_report_status, report_status.report_status, created_by.employee_name AS created_by, DATE_FORMAT(ot_verification.created_at, '%d %M %Y %H:%i:%s') AS created_at
                    FROM tb_ot_verification_det AS ot_verification_det
                    LEFT JOIN tb_ot_verification AS ot_verification ON ot_verification_det.id_ot_verification = ot_verification.id_ot_verification
                    LEFT JOIN tb_ot AS ot ON ot_verification.id_ot = ot.id_ot
                    LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                    LEFT JOIN tb_m_employee AS employee ON ot_verification_det.id_employee = employee.id_employee
                    LEFT JOIN tb_m_departement AS departement ON ot_verification_det.id_departement = departement.id_departement
                    LEFT JOIN tb_lookup_employee_status AS employee_status ON ot_verification_det.id_employee_status = employee_status.id_employee_status
                    LEFT JOIN tb_lookup_report_status AS report_status ON ot_verification.id_report_status = report_status.id_report_status
                    LEFT JOIN tb_m_employee AS created_by ON ot_verification.created_by = created_by.id_employee
                    WHERE 1 AND (ot_verification_det.id_employee IN (SELECT id_employee FROM tb_ot_det WHERE id_ot = ot.id_ot AND ot_date = ot_verification.ot_date)) " + where_date + " " + where_departement + " " + where_employee + ")
                    UNION ALL
                    (SELECT ot_det.id_employee, ot_det.id_departement, ot_det.id_departement_sub, departement.departement, IF(ot_type.is_point_ho = 1, 2, IF(ot_det.id_departement_sub = 46, 1, departement.is_store)) AS is_store, employee.employee_code, employee.employee_name, ot_det.employee_position, ot_det.id_employee_status, employee_status.employee_status, employee.id_employee_level, ot_det.to_salary, ot_det.conversion_type, ot_det.id_ot, 0 AS id_ot_verification, ot.number, ot.id_ot_type, CONCAT(IF(ot_type.is_event = 1, 'Event ', ''), ot_type.ot_type) AS ot_type, DATE_FORMAT(ot_det.ot_date, '%d %M %Y') AS ot_date, IF(((SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_det.id_employee AND date = ot_det.ot_date) = 1 OR (SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_det.id_employee AND date = ot_det.ot_date) IS NULL) AND ((SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = ot_det.ot_date AND id_religion IN (0, IF(departement.is_store = 1, 0, employee.id_religion))) IS NULL), 2, 1) AS is_day_off, '' AS start_work_ot, '' AS end_work_ot, ot_det.ot_break AS break_hours, 0.0 AS ot_hours, 0.0 AS total_hours, 0.0 AS point_ot, ot_det.ot_note, '' AS is_valid, 0 AS id_report_status, 'Waiting Verify' AS report_status, '' AS created_by, '' AS created_at
                    FROM tb_ot_det AS ot_det
                    LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
                    LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                    LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
                    LEFT JOIN tb_m_departement AS departement ON ot_det.id_departement = departement.id_departement
                    LEFT JOIN tb_lookup_employee_status AS employee_status ON ot_det.id_employee_status = employee_status.id_employee_status
                    WHERE 1 " + If(type = "created_at", "", where_date.Replace("ot_verification", "ot_det")) + " " + where_departement.Replace("ot_verification", "ot_det") + " AND ((ot_det.id_ot, ot_det.ot_date) NOT IN (SELECT id_ot, ot_date FROM tb_ot_verification)) AND ot.id_report_status = 6 AND ot_det.ot_date <= DATE(NOW()))
                ) AS tb
                ORDER BY departement ASC, id_employee_level ASC, employee_code ASC, number DESC, ot_date ASC
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCVerificationEmployee.DataSource = data

            calculatePoint()

            GVVerificationEmployee.BestFitColumns()
        Else
            Dim where_departement As String = ""

            Try
                If Not SLUEDepartement.EditValue.ToString = "0" Then
                    where_departement = "AND ot_verification.id_departement = " + SLUEDepartement.EditValue.ToString
                End If
            Catch ex As Exception
            End Try

            Dim query As String = "
                SELECT *
                FROM (
                    (SELECT ot_verification.id_ot_verification, ot_verification.id_ot, ot.id_ot_type, CONCAT(IF(ot_type.is_event = 1, 'Event ', ''), ot_type.ot_type) AS ot_type, ot_verification.id_departement, departement.departement, DATE_FORMAT(ot_verification.ot_date, '%d %M %Y') AS ot_date, ot.number, GROUP_CONCAT(DISTINCT IF(ot_verification_det.ot_note = '', NULL, ot_verification_det.ot_note) SEPARATOR ', ') AS ot_note, ot_verification.id_report_status, report_status.report_status, employee.employee_name AS created_by, DATE_FORMAT(ot_verification.created_at, '%d %M %Y %H:%i:%s') AS created_at
                    FROM tb_ot_verification_det AS ot_verification_det
                    LEFT JOIN tb_ot_verification AS ot_verification ON ot_verification_det.id_ot_verification = ot_verification.id_ot_verification
                    LEFT JOIN tb_ot AS ot ON ot_verification.id_ot = ot.id_ot
                    LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                    LEFT JOIN tb_m_departement AS departement ON ot_verification.id_departement = departement.id_departement
                    LEFT JOIN tb_lookup_report_status AS report_status ON ot_verification.id_report_status = report_status.id_report_status
                    LEFT JOIN tb_m_employee AS employee ON ot_verification.created_by = employee.id_employee
                    WHERE 1 " + where_date + " " + where_departement + "
                    GROUP BY ot_verification_det.id_ot_verification)
                    UNION ALL
                    (SELECT 0 AS id_ot_verification, ot_det.id_ot, ot.id_ot_type, CONCAT(IF(ot_type.is_event = 1, 'Event ', ''), ot_type.ot_type) AS ot_type, ot.id_departement, departement.departement, DATE_FORMAT(ot_det.ot_date, '%d %M %Y') AS ot_date, ot.number, ot_det.ot_note, 0 AS id_report_status, 'Waiting Verify' AS report_status, '' AS created_by, '' AS created_at
                    FROM tb_ot_det AS ot_det
                    LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
                    LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                    LEFT JOIN tb_m_departement AS departement ON ot.id_departement = departement.id_departement
                    WHERE 1 " + If(type = "created_at", "", where_date.Replace("ot_verification", "ot_det")) + " " + where_departement.Replace("ot_verification", "ot_det") + " AND ((ot_det.id_ot, ot_det.ot_date) NOT IN (SELECT id_ot, ot_date FROM tb_ot_verification)) AND ot.id_report_status = 6 AND ot_det.ot_date <= DATE(NOW())
                    GROUP BY ot.number, ot_det.ot_date)
                ) AS tb
                ORDER BY number DESC, ot_date DESC
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCVerification.DataSource = data

            GVVerification.BestFitColumns()
        End If
    End Sub

    Private Sub FormEmpOvertime_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("1", "1", "0")
    End Sub

    Private Sub FormEmpOvertime_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub SBViewCA_Click(sender As Object, e As EventArgs) Handles SBViewCA.Click
        last_click = "created_at"

        If XTCType.SelectedTabPage.Name = "XTPPropose" Then
            load_overtime("created_at")
        Else
            load_verification("created_at")
        End If
    End Sub

    Private Sub SBViewOD_Click(sender As Object, e As EventArgs) Handles SBViewOD.Click
        last_click = "ot_date"

        If XTCType.SelectedTabPage.Name = "XTPPropose" Then
            load_overtime("ot_date")
        Else
            load_verification("ot_date")
        End If
    End Sub

    Sub view_departement()
        Dim query As String = "SELECT 0 AS id_departement, 'All departement' AS departement UNION (SELECT id_departement, departement FROM tb_m_departement a ORDER BY a.departement ASC)"

        viewSearchLookupQuery(SLUEDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Sub view_employee()
        Dim where_department As String = ""

        Try
            If Not SLUEDepartement.EditValue.ToString = "0" Then
                where_department = "AND e.id_departement = " + SLUEDepartement.EditValue.ToString
            End If
        Catch ex As Exception
        End Try

        Dim query As String = "SELECT 0 AS id_employee, '' AS employee_code, 'All employee' AS employee_name UNION (SELECT id_employee, employee_code, employee_name FROM tb_m_employee e WHERE 1 " + where_department + " ORDER BY e.departement ASC, e.id_employee_level ASC)"

        viewSearchLookupQuery(SLUEEmployee, query, "id_employee", "employee_name", "id_employee")
    End Sub

    Sub view_conversion_type()
        viewSearchLookupRepositoryQuery(RISLUEType, "SELECT id_ot_conversion AS id_type, conversion_type AS type, to_salary, to_dp FROM tb_lookup_ot_conversion", 0, "type", "id_type")
        viewSearchLookupRepositoryQuery(RISLUETypeVerification, "SELECT id_ot_conversion AS id_type, conversion_type AS type, to_salary, to_dp FROM tb_lookup_ot_conversion", 0, "type", "id_type")
    End Sub

    Private Sub SLUEDepartement_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEDepartement.EditValueChanged
        view_employee()
    End Sub

    Private Sub XTCPropose_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPropose.SelectedPageChanged
        If XTCPropose.SelectedTabPage.Name = "XTPByEmployee" Then
            PCEmployee.Visible = True
        Else
            PCEmployee.Visible = False
        End If
    End Sub

    Private Sub GVOvertime_DoubleClick(sender As Object, e As EventArgs) Handles GVOvertime.DoubleClick
        Try
            FormEmpOvertimeDet.id = GVOvertime.GetFocusedRowCellValue("id_ot").ToString
            FormEmpOvertimeDet.is_hrd = is_hrd

            FormEmpOvertimeDet.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVEmployee_DoubleClick(sender As Object, e As EventArgs) Handles GVProposeEmployee.DoubleClick
        Try
            FormEmpOvertimeDet.id = GVProposeEmployee.GetFocusedRowCellValue("id_ot").ToString
            FormEmpOvertimeDet.is_hrd = is_hrd

            FormEmpOvertimeDet.id_ot_det = GVProposeEmployee.GetFocusedRowCellValue("id_ot_det").ToString

            FormEmpOvertimeDet.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormEmpOvertime_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub calculatePoint()
        For i = 0 To GVVerificationEmployee.RowCount - 1
            If GVVerificationEmployee.IsValidRowHandle(i) Then
                Dim to_salary As String = GVVerificationEmployee.GetRowCellValue(i, "to_salary").ToString
                Dim is_day_off As String = GVVerificationEmployee.GetRowCellValue(i, "is_day_off").ToString
                Dim total_hours As String = GVVerificationEmployee.GetRowCellValue(i, "total_hours").ToString
                Dim is_store As String = GVVerificationEmployee.GetRowCellValue(i, "is_store").ToString

                Dim point_ot As String = GVVerificationEmployee.GetRowCellValue(i, "point_ot").ToString

                point_ot = If(to_salary = "1", FormEmpOvertimeVerification.calc_point(Decimal.Parse(total_hours), is_day_off, is_store), total_hours)

                GVVerificationEmployee.SetRowCellValue(i, "point_ot", point_ot)
            End If
        Next
    End Sub

    Private Sub SBVerification_Click(sender As Object, e As EventArgs) Handles SBVerification.Click
        Try
            If GVOvertime.GetFocusedRowCellValue("id_report_status").ToString = "6" Then
                FormEmpOvertimeVerification.is_hrd = is_hrd
                FormEmpOvertimeVerification.id = "0"
                FormEmpOvertimeVerification.id_ot = GVOvertime.GetFocusedRowCellValue("id_ot").ToString
                FormEmpOvertimeVerification.is_view = "0"
                FormEmpOvertimeVerification.ot_date = Nothing

                FormEmpOvertimeVerification.ShowDialog()
            Else
                errorCustom("Overtime has not been approved.")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVVerification_DoubleClick(sender As Object, e As EventArgs) Handles GVVerification.DoubleClick
        Try
            FormEmpOvertimeVerification.is_hrd = is_hrd
            FormEmpOvertimeVerification.id = GVVerification.GetFocusedRowCellValue("id_ot_verification").ToString
            FormEmpOvertimeVerification.id_ot = GVVerification.GetFocusedRowCellValue("id_ot").ToString
            FormEmpOvertimeVerification.is_view = "1"
            FormEmpOvertimeVerification.ot_date = Date.Parse(GVVerification.GetFocusedRowCellValue("ot_date").ToString)

            FormEmpOvertimeVerification.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub XTCType_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCType.SelectedPageChanged
        If XTCType.SelectedTabPage.Name = "XTPPropose" Then
            If XTCPropose.SelectedTabPage.Name = "XTPByEmployee" Then
                PCEmployee.Visible = True
            Else
                PCEmployee.Visible = False
            End If
        Else
            If XTCVerification.SelectedTabPage.Name = "XTPByEmployeeVerification" Then
                PCEmployee.Visible = True
            Else
                PCEmployee.Visible = False
            End If
        End If
    End Sub

    Private Sub XTCVerification_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCVerification.SelectedPageChanged
        If XTCVerification.SelectedTabPage.Name = "XTPByEmployeeVerification" Then
            PCEmployee.Visible = True
        Else
            PCEmployee.Visible = False
        End If
    End Sub

    Private Sub GVVerificationEmployee_DoubleClick(sender As Object, e As EventArgs) Handles GVVerificationEmployee.DoubleClick
        Try
            FormEmpOvertimeVerification.is_hrd = is_hrd
            FormEmpOvertimeVerification.id = GVVerificationEmployee.GetFocusedRowCellValue("id_ot_verification").ToString
            FormEmpOvertimeVerification.id_ot = GVVerificationEmployee.GetFocusedRowCellValue("id_ot").ToString
            FormEmpOvertimeVerification.is_view = "1"
            FormEmpOvertimeVerification.ot_date = Date.Parse(GVVerificationEmployee.GetFocusedRowCellValue("ot_date").ToString)
            FormEmpOvertimeVerification.id_employee = GVVerificationEmployee.GetFocusedRowCellValue("id_employee").ToString

            FormEmpOvertimeVerification.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SLUEPayroll_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEPayroll.EditValueChanged
        If SLUEPayroll.EditValue = Nothing Then
            DEStart.EditValue = Date.Now
            DEUntil.EditValue = Date.Now
        Else
            Dim i As Integer = SLUEPayroll.Properties.GetIndexByKeyValue(SLUEPayroll.EditValue)

            DEStart.EditValue = SLUEPayrollView.GetRowCellValue(i, "periode_start")
            DEUntil.EditValue = SLUEPayrollView.GetRowCellValue(i, "periode_end")
        End If
    End Sub

    Private Sub BBIDuplicate_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBIDuplicate.ItemClick
        Try
            FormEmpOvertimeDet.id = GVOvertime.GetFocusedRowCellValue("id_ot").ToString
            FormEmpOvertimeDet.is_hrd = is_hrd
            FormEmpOvertimeDet.id_duplicate = "1"

            FormEmpOvertimeDet.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVOvertime_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVOvertime.RowClick
        If e.Button = MouseButtons.Right Then
            If GVOvertime.GetFocusedRowCellValue("id_report_status").ToString = "5" Then
                PopupMenu.ShowPopup(Control.MousePosition)
            End If
        End If
    End Sub

    Private Sub SLUEDepartement_Click(sender As Object, e As EventArgs) Handles SLUEDepartement.Click
        If id_departement_user = "11" Then
            'sales include sogo
            SLUEDepartement.Properties.View.ActiveFilterString = "[id_departement] = 11 OR [id_departement] = 17"
        Else
            If is_hrd = "-1" Then
                SLUEDepartement.Properties.View.ActiveFilterString = "[id_departement] = " + id_departement_user
            Else
                SLUEDepartement.Properties.View.ActiveFilterString = ""
            End If
        End If
    End Sub
End Class