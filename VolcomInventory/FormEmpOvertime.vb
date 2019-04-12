Public Class FormEmpOvertime
    Public is_hrd As String = "-1"

    Private Sub FormEmpOvertime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Sub form_load()
        DEStart.EditValue = Now
        DEUntil.EditValue = Now

        view_departement()
        view_employee()
    End Sub

    Sub edit()
        If XtraTabControl.SelectedTabPage.Name = "XTPByEmployee" Then
            Try
                If Not GVEmployee.GetFocusedRowCellValue("id_ot") Is Nothing Then
                    FormEmpOvertimeDet.id = GVEmployee.GetFocusedRowCellValue("id_ot")
                    FormEmpOvertimeDet.is_check = "-1"

                    FormEmpOvertimeDet.Show()
                End If
            Catch ex As Exception
            End Try
        Else
            Try
                If Not GVOvertime.GetFocusedRowCellValue("id_ot") Is Nothing Then
                    FormEmpOvertimeDet.id = GVOvertime.GetFocusedRowCellValue("id_ot")
                    FormEmpOvertimeDet.is_check = "-1"

                    FormEmpOvertimeDet.Show()
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Sub load_overtime(ByVal type As String)
        Dim where_date As String = ""

        If type = "ot_date" Then
            where_date = "AND ot.ot_date BETWEEN '" + Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND '" + Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
        ElseIf type = "created_at" Then
            where_date = "AND DATE(ot.created_at) BETWEEN '" + Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND '" + Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
        End If

        If XtraTabControl.SelectedTabPage.Name = "XTPByEmployee" Then
            Dim where_departement As String = ""

            If Not SLUEDepartement.EditValue.ToString = "0" Then
                where_departement = "AND ot_det.id_departement = " + SLUEDepartement.EditValue.ToString
            End If

            Dim where_employee As String = ""

            If Not SLUEEmployee.EditValue.ToString = "0" Then
                where_employee = "AND ot_det.id_employee = " + SLUEEmployee.EditValue.ToString
            End If

            Dim query As String = "
                SELECT ot.id_ot, ot_det.id_departement, departement.departement, employee.employee_code, employee.employee_name, ot_det.employee_position, ot_det.id_employee_level, employee_level.employee_level, IF(ot_det.conversion_type = 1, 'Salary', 'DP') AS conversion_type, IF(ot_det.is_valid = 1, 'Yes', IF(ot_det.is_valid = 2, 'No', '-')) AS valid, ot.number, CONCAT(IF(ot_type.is_event = 1, 'Event ', ''), ot_type.ot_type) AS ot_type, DATE_FORMAT(ot.ot_date, '%d %M %Y') AS ot_date, DATE_FORMAT(ot.ot_start_time, '%l:%i:%s %p') AS ot_start_time, DATE_FORMAT(ot.ot_end_time, '%l:%i:%s %p') AS ot_end_time, ot.ot_break, (TIMESTAMPDIFF(HOUR, ot.ot_start_time, ot.ot_end_time) - ot.ot_break) AS total_hours, ot.ot_note, DATE_FORMAT(payroll.periode_end, '%M %Y') AS payroll_periode, ot.id_report_status, report_status.report_status, IFNULL(check_status.report_status, 'Not Checked') AS check_status, emp.employee_name AS created_by, DATE_FORMAT(ot.created_at, '%d %M %Y %l:%i:%s %p') AS created_at
                FROM tb_ot_det AS ot_det
                LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
                LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
                LEFT JOIN tb_m_departement AS departement ON ot_det.id_departement = departement.id_departement
                LEFT JOIN tb_lookup_employee_level AS employee_level ON ot_det.id_employee_level = employee_level.id_employee_level
                LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                LEFT JOIN tb_emp_payroll AS payroll ON ot.id_payroll = payroll.id_payroll
                LEFT JOIN tb_lookup_report_status AS report_status ON ot.id_report_status = report_status.id_report_status
                LEFT JOIN tb_lookup_report_status AS check_status ON ot.id_check_status = check_status.id_report_status
                LEFT JOIN tb_m_employee AS emp ON ot.created_by = emp.id_employee
                WHERE 1 " + where_date + " " + where_departement + " " + where_employee + "
                ORDER BY ot_det.id_departement DESC, employee.employee_name ASC, ot.ot_date DESC
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCEmployee.DataSource = data

            GVEmployee.BestFitColumns()
        Else
            Dim query As String = "
                SELECT ot.id_ot, ot.id_ot_type, CONCAT(IF(ot_type.is_event = 1, 'Event ', ''), ot_type.ot_type) AS ot_type, DATE_FORMAT(ot.ot_date, '%d %M %Y') AS ot_date, DATE_FORMAT(ot.ot_start_time, '%l:%i:%s %p') AS ot_start_time, DATE_FORMAT(ot.ot_end_time, '%l:%i:%s %p') AS ot_end_time, ot.ot_break, (TIMESTAMPDIFF(HOUR, ot.ot_start_time, ot.ot_end_time) - ot.ot_break) AS total_hours, ot.ot_note, ot.id_payroll, DATE_FORMAT(payroll.periode_end, '%M %Y') AS payroll_periode, ot.id_report_status, report_status.report_status, IFNULL(check_status.report_status, 'Not Checked') AS check_status, ot.number, employee.employee_name AS created_by, DATE_FORMAT(ot.created_at, '%d %M %Y %l:%i:%s %p') AS created_at
                FROM tb_ot AS ot
                LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                LEFT JOIN tb_emp_payroll AS payroll ON ot.id_payroll = payroll.id_payroll
                LEFT JOIN tb_lookup_report_status AS report_status ON ot.id_report_status = report_status.id_report_status
                LEFT JOIN tb_lookup_report_status AS check_status ON ot.id_check_status = check_status.id_report_status
                LEFT JOIN tb_m_employee AS employee ON ot.created_by = employee.id_employee
                WHERE 1 " + where_date + "
                ORDER BY ot.number DESC
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCOvertime.DataSource = data

            GVOvertime.BestFitColumns()
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
        load_overtime("created_at")
    End Sub

    Private Sub SBViewOD_Click(sender As Object, e As EventArgs) Handles SBViewOD.Click
        load_overtime("ot_date")
    End Sub

    Sub view_departement()
        Dim query As String = "SELECT 0 AS id_departement, 'All departement' AS departement UNION (SELECT id_departement, departement FROM tb_m_departement a ORDER BY a.departement ASC)"

        viewSearchLookupQuery(SLUEDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Sub view_employee()
        Dim where_department As String = ""

        If Not SLUEDepartement.EditValue.ToString = "0" Then
            where_department = "AND e.id_departement = " + SLUEDepartement.EditValue.ToString
        End If

        Dim query As String = "SELECT 0 AS id_employee, '' AS employee_code, 'All employee' AS employee_name UNION (SELECT id_employee, employee_code, employee_name FROM tb_m_employee e WHERE 1 " + where_department + " ORDER BY e.departement ASC, e.id_employee_level ASC)"

        viewSearchLookupQuery(SLUEEmployee, query, "id_employee", "employee_name", "id_employee")
    End Sub

    Private Sub SLUEDepartement_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEDepartement.EditValueChanged
        view_employee()
    End Sub

    Private Sub XtraTabControl_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl.SelectedPageChanged
        If XtraTabControl.SelectedTabPage.Name = "XTPByEmployee" Then
            PCEmployee.Visible = True
        Else
            PCEmployee.Visible = False
        End If
    End Sub

    Private Sub GVOvertime_DoubleClick(sender As Object, e As EventArgs) Handles GVOvertime.DoubleClick
        Try
            FormEmpOvertimeDet.id = GVOvertime.GetFocusedRowCellValue("id_ot")
            FormEmpOvertimeDet.is_check = "-1"

            FormEmpOvertimeDet.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVEmployee_DoubleClick(sender As Object, e As EventArgs) Handles GVEmployee.DoubleClick
        Try
            FormEmpOvertimeDet.id = GVEmployee.GetFocusedRowCellValue("id_ot")
            FormEmpOvertimeDet.is_check = "-1"

            FormEmpOvertimeDet.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SBCheck_Click(sender As Object, e As EventArgs) Handles SBCheck.Click
        If XtraTabControl.SelectedTabPage.Name = "XTPByEmployee" Then
            Try
                If GVEmployee.GetFocusedRowCellValue("id_report_status").ToString = "6" Then
                    FormEmpOvertimeDet.id = GVEmployee.GetFocusedRowCellValue("id_ot")
                    FormEmpOvertimeDet.is_check = "1"

                    FormEmpOvertimeDet.Show()
                Else
                    errorCustom("Overtime must be approved first.")
                End If
            Catch ex As Exception
            End Try
        Else
            Try
                If GVOvertime.GetFocusedRowCellValue("id_report_status").ToString = "6" Then
                    FormEmpOvertimeDet.id = GVOvertime.GetFocusedRowCellValue("id_ot")
                    FormEmpOvertimeDet.is_check = "1"

                    FormEmpOvertimeDet.Show()
                Else
                    errorCustom("Overtime must be approved first.")
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        If DEStart.EditValue > DEUntil.EditValue Then
            DEUntil.EditValue = DEStart.EditValue
        End If
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        If DEStart.EditValue > DEUntil.EditValue Then
            DEStart.EditValue = DEUntil.EditValue
        End If
    End Sub
End Class