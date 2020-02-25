Public Class FormEmpOvertimeVerification
    Public is_hrd As String = "-1"
    Public id As String = "0"
    Public id_ot As String = ""
    Public is_view As String = "0"
    Public ot_date As Date = Nothing

    Public id_employee As String = "0"

    Private ot_min_staff As Integer = get_opt_emp_field("ot_min_staff")
    Private ot_min_spv As Integer = get_opt_emp_field("ot_min_spv")

    Private is_store As String = "2"

    Private loaded As Boolean = False

    Private Sub FormEmpOvertimeVerification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor

        viewLookupQuery(LUEOvertimeType, "SELECT id_ot_type, CONCAT(IF(is_event = 1, 'Event ', ''), ot_type) AS ot_type, is_point_ho FROM tb_lookup_ot_type", 0, "ot_type", "id_ot_type")
        viewSearchLookupRepositoryQuery(RISLUEType, "SELECT id_ot_conversion AS id_type, conversion_type AS type, to_salary, to_dp FROM tb_lookup_ot_conversion", 0, "type", "id_type")
        viewSearchLookupRepositoryQuery(RISLUEType2, "SELECT id_ot_conversion AS id_type, conversion_type AS type, to_salary, to_dp FROM tb_lookup_ot_conversion", 0, "type", "id_type")
        viewSearchLookupQuery(SLUEPayroll, "SELECT id_payroll, DATE_FORMAT(periode_end, '%M %Y') as periode FROM tb_emp_payroll WHERE id_payroll_type = 1 ORDER BY periode_end DESC", "id_payroll", "periode", "id_payroll")
        viewSearchLookupQuery(LEDepartement, "SELECT * FROM tb_m_departement", "id_departement", "departement", "id_departement")

        'overtime
        Dim query_ot As String = "
            SELECT ot.id_ot, ot.id_ot_type, ot_type.ot_type, ot.id_departement, departement.departement, ot.number, ot.id_report_status, report_status.report_status, employee.employee_name AS created_by, DATE_FORMAT(ot.created_at, '%d %M %Y %H:%i:%s') AS created_at
            FROM tb_ot AS ot
            LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
            LEFT JOIN tb_m_departement AS departement ON ot.id_departement = departement.id_departement
            LEFT JOIN tb_lookup_report_status AS report_status ON ot.id_report_status = report_status.id_report_status
            LEFT JOIN tb_m_employee AS employee ON ot.created_by = employee.id_employee
            WHERE ot.id_ot = " + id_ot + "
        "

        Dim data_ot As DataTable = execute_query(query_ot, -1, True, "", "", "", "")

        TENumber.EditValue = data_ot.Rows(0)("number").ToString
        LUEOvertimeType.ItemIndex = LUEOvertimeType.Properties.GetDataSourceRowIndex("id_ot_type", data_ot.Rows(0)("id_ot_type").ToString)

        LEDepartement.EditValue = data_ot.Rows(0)("id_departement")
        LEDepartement.Properties.ReadOnly = True

        TECreatedBy.EditValue = data_ot.Rows(0)("created_by").ToString
        TECreatedAt.EditValue = data_ot.Rows(0)("created_at").ToString

        LUEOvertimeType.ReadOnly = True

        RISLUEType.ReadOnly = True

        is_store = execute_query("SELECT is_store FROM tb_m_departement WHERE id_departement = " + LEDepartement.EditValue.ToString, 0, True, "", "", "", "")

        'propose
        Dim query_pro As String = "
            SELECT ot_det.id_employee, ot_det.id_departement, ot_det.id_departement_sub, departement.departement, DATE_FORMAT(ot_det.ot_date, '%d %M %Y') AS ot_date, employee.employee_code, employee.employee_name, ot_det.employee_position, ot_det.id_employee_status, employee_status.employee_status, ot_det.to_salary, IF(((SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_det.id_employee AND date = ot_det.ot_date) = 1 OR (SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_det.id_employee AND date = ot_det.ot_date) IS NULL) AND ((SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = ot_det.ot_date AND id_religion IN (0, IF(" + is_store + " = 1, 0, employee.id_religion))) IS NULL), 2, 1) AS is_day_off, ot_det.ot_consumption, ot_det.conversion_type, DATE_FORMAT(ot_det.ot_start_time, '%H:%i:%s') AS ot_start_time, DATE_FORMAT(ot_det.ot_end_time, '%H:%i:%s') AS ot_end_time, ot_det.ot_break, ROUND((TIMESTAMPDIFF(MINUTE, ot_det.ot_start_time, ot_det.ot_end_time) / 60) - ot_det.ot_break, 1) AS ot_total_hours, ot_det.ot_note
            FROM tb_ot_det AS ot_det
            LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
            LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
            LEFT JOIN tb_m_departement AS departement ON ot_det.id_departement = departement.id_departement
            LEFT JOIN tb_lookup_employee_status AS employee_status ON ot_det.id_employee_status = employee_status.id_employee_status
            WHERE ot_det.id_ot = " + id_ot + "
            ORDER BY ot_det.ot_date ASC, departement.departement ASC, employee.id_employee_level ASC, employee.employee_code ASC
        "

        Dim data_pro As DataTable = execute_query(query_pro, -1, True, "", "", "", "")

        GCEmployee.DataSource = data_pro

        'date search
        viewSearchLookupQuery(DESearch, "SELECT DATE_FORMAT(ot_date, '%d %M %Y') AS ot_date FROM tb_ot_det WHERE id_ot = " + id_ot + " GROUP BY ot_date", "ot_date", "ot_date", "ot_date")

        'load
        If Not ot_date = Nothing Then
            DESearch.EditValue = ot_date.ToString("dd MMMM yyyy")

            SBView_Click(SBView, New EventArgs)
        End If

        'controls
        If is_view = "1" Then
            DESearch.ReadOnly = True
            SBView.Enabled = False
        End If

        If is_hrd = "-1" Then
            SBComplete.Visible = False
            RITETimeVer.ReadOnly = True
            RITEHours.ReadOnly = True
            SBFill.Visible = False
            BGCActualHours.Visible = False
            BGCPointOt.Visible = False
            SLUEPayroll.Properties.ReadOnly = True
        End If

        loaded = True

        Cursor = Cursors.Default
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        id = execute_query("SELECT IFNULL((SELECT id_ot_verification FROM tb_ot_verification WHERE id_ot = " + id_ot + " AND ot_date = '" + Date.Parse(DESearch.EditValue.ToString).ToString("yyyy-MM-dd") + "'), 0) AS id_ot_verification", 0, True, "", "", "", "")

        GVEmployee.ActiveFilterString = "[ot_date] = '" + Date.Parse(DESearch.EditValue.ToString).ToString("dd MMMM yyyy") + "'"

        GVAttendance.ActiveFilterString = ""

        If id = "0" Then
            change_payroll()

            Dim date_search As String = Date.Parse(DESearch.EditValue.ToString).ToString("yyyy-MM-dd")

            Dim departement_include As String = execute_query("SELECT GROUP_CONCAT(DISTINCT id_departement) AS id_departement FROM tb_ot_det WHERE ot_date = '" + date_search.ToString + "' AND id_ot = " + id_ot, 0, True, "", "", "", "")

            'attendance
            Dim query_att As String = "
                SELECT * FROM (
                    SELECT sch.id_employee, emp.id_departement, dep_sub.id_departement_sub, dep.departement, DATE_FORMAT(sch.date, '%d %M %Y') AS date, emp.employee_code, emp.employee_name, emp.employee_position, emp.id_employee_level, emp.id_employee_status, sts.employee_status, IF(salary.salary > (dep_sub.ump + (SELECT ot_ump_conversion FROM tb_opt_emp LIMIT 1)) OR emp.id_employee_level <= 12, '2', '1') AS to_salary, IF((sch.id_schedule_type = 1 OR sch.id_schedule_type IS NULL) AND ((SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = '" + date_search.ToString + "' AND id_religion IN (0, IF(" + is_store + " = 1, 0, emp.id_religion))) IS NULL), 2, 1) AS is_day_off, IF((SELECT to_salary) = 1, 1, IF((SELECT is_day_off) = 1, 2, IF(" + is_store + " = 1, 2, 3))) AS conversion_type, DATE_FORMAT(IF(sch.id_schedule_type = '1', IFNULL(at_input.time_in, MIN(at_in.datetime)), IFNULL(at_input.time_in, MIN(at_in_hol.datetime))), '%H:%i:%s') AS start_work_att, DATE_FORMAT(IF(sch.id_schedule_type = '1', IFNULL(at_input.time_out, MAX(at_out.datetime)), IFNULL(at_input.time_out, MAX(at_out_hol.datetime))), '%H:%i:%s') AS end_work_att, '' AS start_work_ot, '' AS end_work_ot, 0.0 AS break_hours, 0.0 AS ot_hours, 0.0 AS total_hours, 0.0 AS point_ot, '' AS ot_note, 'no' AS is_valid, sch.id_schedule_type, DATE_FORMAT(sch.in, '%H:%i:%s') AS `in`, DATE_FORMAT(sch.out, '%H:%i:%s') AS `out`, 2 AS ot_potention
                    FROM tb_emp_schedule AS sch
                    LEFT JOIN tb_m_employee AS emp ON emp.id_employee = sch.id_employee
                    LEFT JOIN tb_m_departement AS dep ON emp.id_departement = dep.id_departement 
                    LEFT JOIN tb_m_departement_sub AS dep_sub ON IFNULL(emp.id_departement_sub, (SELECT id_departement_sub FROM tb_m_departement_sub WHERE id_departement = emp.id_departement LIMIT 1)) = dep_sub.id_departement_sub
                    LEFT JOIN tb_lookup_employee_status AS sts ON emp.id_employee_status = sts.id_employee_status
                    LEFT JOIN (
                        SELECT id_employee, (basic_salary + allow_job + allow_meal + allow_trans + allow_house + allow_car) AS salary
                        FROM tb_m_employee
                    ) AS salary ON emp.id_employee = salary.id_employee
                    LEFT JOIN tb_emp_attn AS at_in ON at_in.id_employee = sch.id_employee AND (at_in.datetime >= (sch.out - INTERVAL 18 HOUR) AND at_in.datetime <= sch.out) AND at_in.type_log = 1 
                    LEFT JOIN tb_emp_attn AS at_out ON at_out.id_employee = sch.id_employee AND (at_out.datetime >= sch.in AND at_out.datetime <= (sch.in + INTERVAL 18 HOUR)) AND at_out.type_log = 2 
                    LEFT JOIN tb_emp_attn AS at_in_hol ON at_in_hol.id_employee = sch.id_employee AND DATE(at_in_hol.datetime) = sch.date AND at_in_hol.type_log = 1 
                    LEFT JOIN tb_emp_attn AS at_out_hol ON at_out_hol.id_employee = sch.id_employee AND DATE(at_out_hol.datetime) = sch.date AND at_out_hol.type_log = 2
                    LEFT JOIN (
                        SELECT input_det.id_employee, input_det.date, input_det.time_in, input_det.time_out
                        FROM tb_emp_attn_input_det AS input_det
                        LEFT JOIN tb_emp_attn_input AS input ON input_det.id_emp_attn_input = input.id_emp_attn_input
                        WHERE input.id_report_status = 6 AND input_det.date = '" + date_search.ToString + "'
                    ) AS at_input ON sch.id_employee = at_input.id_employee
                    WHERE sch.date = '" + date_search.ToString + "' AND emp.id_departement IN (" + departement_include + ")
                    GROUP BY sch.id_schedule
                ) AS tb
                ORDER BY tb.departement ASC, tb.id_employee_level ASC, tb.employee_code ASC
            "

            'sogo only for october 2019
            'If LEDepartement.EditValue.ToString = "17" Then
            '    query_att = "
            '        SELECT emp.id_employee, emp.id_departement, emp.id_departement_sub, dep.departement, DATE_FORMAT('" + date_search.ToString + "', '%d %M %Y') AS `date`, emp.employee_code, emp.employee_name, emp.employee_position, emp.id_employee_level, emp.id_employee_status, sts.employee_status, 1 AS to_salary, IF((SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = '" + date_search.ToString + "' AND id_religion IN (0, emp.id_religion)) IS NULL, 2, 1) AS is_day_off, 1 AS conversion_type, 1 AS is_store, DATE_FORMAT(input.time_in, '%H:%i:%s') AS start_work_att, DATE_FORMAT(input.time_out, '%H:%i:%s') AS end_work_att, '' AS start_work_ot, '' AS end_work_ot, 0.0 break_hours, 0.0 AS ot_hours, 0.0 total_hours, 0.0 point_ot, '' AS ot_note, 'no' AS is_valid, 1 AS id_schedule_type, '' AS `in`, '' AS `out`, 2 AS ot_potention
            '        FROM tb_m_employee AS emp
            '        LEFT JOIN tb_m_departement AS dep ON emp.id_departement = dep.id_departement
            '        LEFT JOIN tb_lookup_employee_status AS sts ON emp.id_employee_status = sts.id_employee_status
            '        LEFT JOIN (
            '            SELECT input_det.id_employee, input_det.time_in, input_det.time_out
            '            FROM tb_emp_attn_input_det AS input_det
            '            LEFT JOIN tb_emp_attn_input AS input ON input_det.id_emp_attn_input = input.id_emp_attn_input
            '            WHERE input_det.date = '" + date_search.ToString + "'
            '        ) AS input ON emp.id_employee = input.id_employee
            '        WHERE emp.id_departement = " + LEDepartement.EditValue.ToString + "
            '    "
            'End If

            Dim data_att As DataTable = execute_query(query_att, -1, True, "", "", "", "")

            GCAttendance.DataSource = data_att

            'verification
            For i = 0 To GVAttendance.RowCount - 1
                If GVAttendance.IsValidRowHandle(i) Then
                    If (Not GVAttendance.GetRowCellValue(i, "start_work_att").ToString = "") And (Not GVAttendance.GetRowCellValue(i, "end_work_att").ToString = "") Then
                        For j = 0 To GVEmployee.RowCount - 1
                            If GVEmployee.IsValidRowHandle(j) Then
                                Dim ot_min As Integer = If(GVAttendance.GetRowCellValue(i, "to_salary").ToString = "1", ot_min_staff, ot_min_spv)

                                Dim after_work As Decimal = 0.0
                                Dim before_work As Decimal = 0.0

                                Dim after_work_ot As Decimal = 0.0
                                Dim before_work_ot As Decimal = 0.0

                                Dim work_hours As Decimal = 0.0
                                Dim ot_hours As Decimal = 0.0

                                Dim overtime_in As DateTime = New DateTime
                                Dim overtime_out As DateTime = New DateTime

                                Dim schedule_in As DateTime = New DateTime
                                Dim schedule_out As DateTime = New DateTime

                                Dim start_work_att As DateTime = New DateTime
                                Dim end_work_att As DateTime = New DateTime

                                Try
                                    overtime_in = DateTime.Parse(DateTime.Parse(GVEmployee.GetRowCellValue(j, "ot_date").ToString).ToString("dd MMMM yyyy") + " " + DateTime.Parse(GVEmployee.GetRowCellValue(j, "ot_start_time").ToString).ToString("HH:mm:ss"))
                                    overtime_out = DateTime.Parse(DateTime.Parse(GVEmployee.GetRowCellValue(j, "ot_date").ToString).ToString("dd MMMM yyyy") + " " + DateTime.Parse(GVEmployee.GetRowCellValue(j, "ot_end_time").ToString).ToString("HH:mm:ss"))

                                    If overtime_out < overtime_in Then
                                        overtime_out = overtime_out.AddDays(1)
                                    End If
                                Catch ex As Exception
                                End Try

                                Try
                                    schedule_in = DateTime.Parse(DateTime.Parse(GVAttendance.GetRowCellValue(i, "date").ToString).ToString("dd MMMM yyyy") + " " + DateTime.Parse(GVAttendance.GetRowCellValue(i, "in").ToString).ToString("HH:mm:ss"))
                                    schedule_out = DateTime.Parse(DateTime.Parse(GVAttendance.GetRowCellValue(i, "date").ToString).ToString("dd MMMM yyyy") + " " + DateTime.Parse(GVAttendance.GetRowCellValue(i, "out").ToString).ToString("HH:mm:ss"))

                                    If schedule_out < schedule_in Then
                                        schedule_out = schedule_out.AddDays(1)
                                    End If
                                Catch ex As Exception
                                End Try

                                Try
                                    start_work_att = DateTime.Parse(DateTime.Parse(GVAttendance.GetRowCellValue(i, "date").ToString).ToString("dd MMMM yyyy") + " " + DateTime.Parse(GVAttendance.GetRowCellValue(i, "start_work_att").ToString).ToString("HH:mm:ss"))
                                    end_work_att = DateTime.Parse(DateTime.Parse(GVAttendance.GetRowCellValue(i, "date").ToString).ToString("dd MMMM yyyy") + " " + DateTime.Parse(GVAttendance.GetRowCellValue(i, "end_work_att").ToString).ToString("HH:mm:ss"))

                                    If end_work_att < start_work_att Then
                                        end_work_att = end_work_att.AddDays(1)
                                    End If
                                Catch ex As Exception
                                End Try

                                Dim ot_start_time As DateTime = If(schedule_out > overtime_in, schedule_out, overtime_in)
                                Dim ot_end_time As DateTime = If(schedule_in < overtime_out, overtime_out, schedule_in)

                                'over of schedule
                                after_work = (end_work_att - schedule_out).TotalHours
                                before_work = (schedule_in - start_work_att).TotalHours

                                'over of overtime
                                after_work_ot = (end_work_att - ot_start_time).TotalHours - GVEmployee.GetRowCellValue(j, "ot_break")
                                before_work_ot = (ot_end_time - start_work_att).TotalHours - GVEmployee.GetRowCellValue(j, "ot_break")

                                work_hours = (end_work_att - start_work_att).TotalHours - GVEmployee.GetRowCellValue(j, "ot_break")
                                ot_hours = (overtime_out - overtime_in).TotalHours - GVEmployee.GetRowCellValue(j, "ot_break")

                                If GVAttendance.GetRowCellValue(i, "id_schedule_type").ToString = "1" Then
                                    If after_work >= ot_min And after_work_ot >= ot_min Then
                                        GVAttendance.SetRowCellValue(i, "ot_potention", "1")

                                        Dim total_hours As Decimal = Math.Floor(after_work_ot / 0.5) * 0.5

                                        GVAttendance.SetRowCellValue(i, "start_work_ot", DateTime.Parse(ot_start_time.ToString).ToString("HH:mm:ss"))
                                        GVAttendance.SetRowCellValue(i, "end_work_ot", GVAttendance.GetRowCellValue(i, "end_work_att"))
                                        GVAttendance.SetRowCellValue(i, "break_hours", GVEmployee.GetRowCellValue(j, "ot_break"))
                                        GVAttendance.SetRowCellValue(i, "ot_hours", after_work_ot)
                                        GVAttendance.SetRowCellValue(i, "total_hours", total_hours)

                                        If GVAttendance.GetRowCellValue(i, "id_employee").ToString = GVEmployee.GetRowCellValue(j, "id_employee").ToString Then
                                            GVAttendance.SetRowCellValue(i, "is_valid", "yes")
                                            GVAttendance.SetRowCellValue(i, "ot_note", GVEmployee.GetRowCellValue(j, "ot_note").ToString)
                                        End If
                                    ElseIf before_work >= ot_min And before_work_ot >= ot_min Then
                                        GVAttendance.SetRowCellValue(i, "ot_potention", "1")

                                        Dim total_hours As Decimal = Math.Floor(before_work_ot / 0.5) * 0.5

                                        GVAttendance.SetRowCellValue(i, "start_work_ot", GVAttendance.GetRowCellValue(i, "start_work_att"))
                                        GVAttendance.SetRowCellValue(i, "end_work_ot", DateTime.Parse(ot_end_time.ToString).ToString("HH:mm:ss"))
                                        GVAttendance.SetRowCellValue(i, "break_hours", GVEmployee.GetRowCellValue(j, "ot_break"))
                                        GVAttendance.SetRowCellValue(i, "ot_hours", before_work_ot)
                                        GVAttendance.SetRowCellValue(i, "total_hours", total_hours)

                                        If GVAttendance.GetRowCellValue(i, "id_employee").ToString = GVEmployee.GetRowCellValue(j, "id_employee").ToString Then
                                            GVAttendance.SetRowCellValue(i, "is_valid", "yes")
                                            GVAttendance.SetRowCellValue(i, "ot_note", GVEmployee.GetRowCellValue(j, "ot_note").ToString)
                                        End If
                                    End If

                                    'overtime on public holiday
                                    If GVAttendance.GetRowCellValue(i, "is_day_off").ToString = "1" And GVAttendance.GetRowCellValue(i, "id_employee").ToString = GVEmployee.GetRowCellValue(j, "id_employee").ToString Then
                                        GVAttendance.SetRowCellValue(i, "ot_potention", "1")

                                        Dim total_hours As Decimal = Math.Floor(work_hours / 0.5) * 0.5

                                        GVAttendance.SetRowCellValue(i, "start_work_ot", GVAttendance.GetRowCellValue(i, "start_work_att"))
                                        GVAttendance.SetRowCellValue(i, "end_work_ot", GVAttendance.GetRowCellValue(i, "end_work_att"))
                                        GVAttendance.SetRowCellValue(i, "break_hours", GVEmployee.GetRowCellValue(j, "ot_break"))
                                        GVAttendance.SetRowCellValue(i, "ot_hours", work_hours)
                                        GVAttendance.SetRowCellValue(i, "total_hours", total_hours)

                                        GVAttendance.SetRowCellValue(i, "is_valid", "yes")
                                        GVAttendance.SetRowCellValue(i, "ot_note", GVEmployee.GetRowCellValue(j, "ot_note").ToString)
                                    End If
                                Else
                                    If work_hours >= ot_min Then
                                        GVAttendance.SetRowCellValue(i, "ot_potention", "1")

                                        Dim total_hours As Decimal = Math.Floor(work_hours / 0.5) * 0.5

                                        GVAttendance.SetRowCellValue(i, "start_work_ot", GVAttendance.GetRowCellValue(i, "start_work_att"))
                                        GVAttendance.SetRowCellValue(i, "end_work_ot", GVAttendance.GetRowCellValue(i, "end_work_att"))
                                        GVAttendance.SetRowCellValue(i, "break_hours", GVEmployee.GetRowCellValue(j, "ot_break"))
                                        GVAttendance.SetRowCellValue(i, "ot_hours", work_hours)
                                        GVAttendance.SetRowCellValue(i, "total_hours", total_hours)

                                        If GVAttendance.GetRowCellValue(i, "id_employee").ToString = GVEmployee.GetRowCellValue(j, "id_employee").ToString Then
                                            GVAttendance.SetRowCellValue(i, "is_valid", "yes")
                                            GVAttendance.SetRowCellValue(i, "ot_note", GVEmployee.GetRowCellValue(j, "ot_note").ToString)
                                        End If
                                    End If
                                End If

                                'overtime in shedule
                                If GVAttendance.GetRowCellValue(i, "id_employee").ToString = GVEmployee.GetRowCellValue(j, "id_employee").ToString And GVAttendance.GetRowCellValue(i, "ot_potention").ToString = "2" Then
                                    If (overtime_in >= start_work_att And overtime_in <= end_work_att) Or (overtime_out >= start_work_att And overtime_out <= end_work_att) Then
                                        Dim start_work_sch As DateTime = If(overtime_in > start_work_att, overtime_in, start_work_att)
                                        Dim end_work_sch As DateTime = If(overtime_out < end_work_att, overtime_out, end_work_att)

                                        Dim ot_hours_sch As Decimal = (end_work_sch - start_work_sch).TotalHours - GVEmployee.GetRowCellValue(j, "ot_break")
                                        Dim total_hours As Decimal = Math.Floor(ot_hours_sch / 0.5) * 0.5

                                        If total_hours >= ot_min Then
                                            GVAttendance.SetRowCellValue(i, "ot_potention", "1")

                                            GVAttendance.SetRowCellValue(i, "start_work_ot", DateTime.Parse(start_work_sch.ToString).ToString("HH:mm:ss"))
                                            GVAttendance.SetRowCellValue(i, "end_work_ot", DateTime.Parse(end_work_sch.ToString).ToString("HH:mm:ss"))
                                            GVAttendance.SetRowCellValue(i, "break_hours", GVEmployee.GetRowCellValue(j, "ot_break"))
                                            GVAttendance.SetRowCellValue(i, "ot_hours", ot_hours_sch)
                                            GVAttendance.SetRowCellValue(i, "total_hours", total_hours)

                                            GVAttendance.SetRowCellValue(i, "is_valid", "yes")
                                            GVAttendance.SetRowCellValue(i, "ot_note", GVEmployee.GetRowCellValue(j, "ot_note").ToString)
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If
            Next

            'show not attendance
            For i = 0 To GVAttendance.RowCount - 1
                If GVAttendance.IsValidRowHandle(i) Then
                    For j = 0 To GVEmployee.RowCount - 1
                        If GVEmployee.IsValidRowHandle(j) Then
                            If GVAttendance.GetRowCellValue(i, "id_employee").ToString = GVEmployee.GetRowCellValue(j, "id_employee").ToString Then
                                GVAttendance.SetRowCellValue(i, "ot_potention", "1")
                            End If
                        End If
                    Next
                End If
            Next

            'check other propose
            Dim query_other As String = "
                SELECT ot_det.id_employee, ot_det.ot_start_time, ot_det.ot_end_time
                FROM tb_ot_det AS ot_det
                LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
                WHERE ot.id_report_status <> 5 AND ot_det.ot_date = '" + date_search.ToString + "' AND ot.id_ot <> '" + id_ot + "'
            "

            Dim data_other As DataTable = execute_query(query_other, -1, True, "", "", "", "")

            For i = 0 To GVAttendance.RowCount - 1
                If GVAttendance.IsValidRowHandle(i) Then
                    For j = 0 To data_other.Rows.Count - 1
                        If GVAttendance.GetRowCellValue(i, "ot_potention").ToString = "1" And GVAttendance.GetRowCellValue(i, "id_employee").ToString = data_other.Rows(j)("id_employee").ToString Then
                            GVAttendance.SetRowCellValue(i, "ot_potention", "2")
                        End If
                    Next
                End If
            Next

            GVAttendance.ActiveFilterString = "[ot_potention] = '1'"

            GVAttendance.RefreshData()

            TEReportStatus.EditValue = ""

            'controls
            SBSave.Enabled = True
            SBComplete.Enabled = True
            SBComplete.Visible = If(is_hrd = "1", True, False)
            SBPrint.Enabled = False
            SBMark.Enabled = False
            RISLUEType2.ReadOnly = False
            RITETimeVer.ReadOnly = If(is_hrd = "1", False, True)
            RITEBreak2.ReadOnly = False
            RITEHours.ReadOnly = If(is_hrd = "1", False, True)
            RITENote.ReadOnly = False
            RICEValid.ReadOnly = False
            SBReset.Enabled = False
        Else
            Dim query_ver As String = "
                SELECT vr.id_payroll, vr.id_report_status, rs.report_status
                FROM tb_ot_verification AS vr
                LEFT JOIN tb_lookup_report_status AS rs ON vr.id_report_status = rs.id_report_status
                WHERE id_ot_verification = " + id + "
            "

            Dim data_ver As DataTable = execute_query(query_ver, -1, True, "", "", "", "")

            TEReportStatus.EditValue = data_ver.Rows(0)("report_status").ToString
            SLUEPayroll.EditValue = data_ver.Rows(0)("id_payroll").ToString

            'detail
            Dim query_det As String = "
                SELECT vrd.id_employee, vrd.id_departement, vrd.id_departement_sub, d.departement, DATE_FORMAT(vr.ot_date, '%d %M %Y') AS date, e.employee_code, e.employee_name, e.employee_position, e.id_employee_status, sts.employee_status, vrd.to_salary, IF((sch.id_schedule_type = 1 OR sch.id_schedule_type IS NULL) AND ((SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = vr.ot_date AND id_religion IN (0, IF(" + is_store + " = 1, 0, e.id_religion))) IS NULL), 2, 1) AS is_day_off, vrd.conversion_type, IF(vrd.start_work_att = '0000-00-00 00:00:00', '', DATE_FORMAT(vrd.start_work_att, '%H:%i:%s')) AS start_work_att, IF(vrd.end_work_att = '0000-00-00 00:00:00', '', DATE_FORMAT(vrd.end_work_att, '%H:%i:%s')) AS end_work_att, DATE_FORMAT(vrd.start_work_ot, '%H:%i:%s') AS start_work_ot, DATE_FORMAT(vrd.end_work_ot, '%H:%i:%s') AS end_work_ot, vrd.break_hours, ROUND((TIMESTAMPDIFF(MINUTE, vrd.start_work_ot, vrd.end_work_ot) / 60) - vrd.break_hours, 1) AS ot_hours, vrd.total_hours, 0.0 AS point_ot, vrd.ot_note, sch.id_schedule_type, DATE_FORMAT(sch.in, '%H:%i:%s') AS `in`, DATE_FORMAT(sch.out, '%H:%i:%s') AS `out`, 1 AS ot_potention, IF(vrd.is_valid = 1, 'yes', 'no') AS is_valid
                FROM tb_ot_verification_det AS vrd
                LEFT JOIN tb_ot_verification AS vr ON vrd.id_ot_verification = vr.id_ot_verification
                LEFT JOIN tb_m_employee AS e ON vrd.id_employee = e.id_employee
                LEFT JOIN tb_lookup_employee_status AS sts ON e.id_employee_status = sts.id_employee_status
                LEFT JOIN tb_m_departement AS d ON vrd.id_departement = d.id_departement
                LEFT JOIN tb_emp_schedule AS sch ON vrd.id_employee = sch.id_employee AND sch.date = vr.ot_date
                WHERE vrd.id_ot_verification = " + id + "
                ORDER BY d.departement ASC, e.id_employee_level ASC, e.employee_code ASC
            "

            Dim data_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")

            GCAttendance.DataSource = data_det

            'controls
            If data_ver.Rows(0)("id_report_status").ToString = "1" Then
                SBSave.Enabled = False
                SBComplete.Enabled = If(is_hrd = "1", True, False)
                SBPrint.Enabled = True
                SBMark.Enabled = True
                RISLUEType2.ReadOnly = If(is_hrd = "1", False, True)
                RITETimeVer.ReadOnly = If(is_hrd = "1", False, True)
                RITEBreak2.ReadOnly = If(is_hrd = "1", False, True)
                RITEHours.ReadOnly = If(is_hrd = "1", False, True)
                RITENote.ReadOnly = If(is_hrd = "1", False, True)
                RICEValid.ReadOnly = If(is_hrd = "1", False, True)
                SBReset.Enabled = True
            Else
                SBSave.Enabled = False
                SBComplete.Enabled = False
                SBPrint.Enabled = True
                SBMark.Enabled = True
                RISLUEType2.ReadOnly = True
                RITETimeVer.ReadOnly = True
                RITEBreak2.ReadOnly = True
                RITEHours.ReadOnly = True
                RITENote.ReadOnly = True
                RICEValid.ReadOnly = True
                SBReset.Enabled = False
            End If
        End If

        'calculate point
        If GVAttendance.RowCount > 0 Then
            For i = 0 To GVAttendance.RowCount - 1
                If GVAttendance.IsValidRowHandle(i) Then
                    Dim to_salary As String = GVAttendance.GetRowCellValue(i, "to_salary").ToString
                    Dim is_day_off As String = GVAttendance.GetRowCellValue(i, "is_day_off").ToString
                    Dim total_hours As String = GVAttendance.GetRowCellValue(i, "total_hours").ToString
                    Dim point_ot As String = GVAttendance.GetRowCellValue(i, "point_ot").ToString

                    point_ot = If(to_salary = "1", calc_point(Decimal.Parse(total_hours), is_day_off, is_store), total_hours)

                    GVAttendance.SetRowCellValue(i, "point_ot", point_ot)
                End If
            Next
        End If
    End Sub

    Private Sub FormEmpOvertimeVerification_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If FormEmpOvertime.last_click = "ot_date" Then
            FormEmpOvertime.load_verification("ot_date")
        ElseIf FormEmpOvertime.last_click = "created_at" Then
            FormEmpOvertime.load_verification("created_at")
        End If

        If FormEmpOvertime.XTCVerification.SelectedTabPage.Name = "XTPByEmployeeVerification" Then
            Dim id_row As String = "0"

            For i = 0 To FormEmpOvertime.GVVerificationEmployee.RowCount - 1
                If FormEmpOvertime.GVVerificationEmployee.IsValidRowHandle(i) Then
                    If FormEmpOvertime.GVVerificationEmployee.GetRowCellValue(i, "id_ot").ToString = id_ot And Date.Parse(FormEmpOvertime.GVVerificationEmployee.GetRowCellValue(i, "ot_date")) = ot_date And FormEmpOvertime.GVVerificationEmployee.GetRowCellValue(i, "id_employee").ToString = id_employee Then
                        id_row = i

                        Exit For
                    End If
                End If
            Next

            FormEmpOvertime.GVVerificationEmployee.FocusedRowHandle = id_row
        Else
            Dim id_row As String = "0"

            For i = 0 To FormEmpOvertime.GVVerification.RowCount - 1
                If FormEmpOvertime.GVVerification.IsValidRowHandle(i) Then
                    If FormEmpOvertime.GVVerification.GetRowCellValue(i, "id_ot").ToString = id_ot And Date.Parse(FormEmpOvertime.GVVerification.GetRowCellValue(i, "ot_date")) = ot_date Then
                        id_row = i

                        Exit For
                    End If
                End If
            Next

            FormEmpOvertime.GVVerification.FocusedRowHandle = id_row
        End If

        Dispose()
    End Sub

    Private Sub FormEmpOvertimeVerification_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        GroupControl1.Width = Convert.ToInt32(Me.Width * 0.4) - 10
        GroupControl2.Width = Convert.ToInt32(Me.Width * 0.6) - 10
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        submit("save")
    End Sub

    Sub submit(type As String)
        GVAttendance.ActiveFilterString = "[ot_potention] = '1'"

        If GVAttendance.RowCount > 0 Then
            Dim check_warning As String = ""

            'check blank overtime
            For i = 0 To GVAttendance.RowCount - 1
                If GVAttendance.IsValidRowHandle(i) Then
                    If GVAttendance.GetRowCellValue(i, "is_valid").ToString = "yes" Then
                        If GVAttendance.GetRowCellValue(i, "ot_note").ToString = "" Then
                            check_warning = "Overtime propose cannot be blank."
                        End If

                        If GVAttendance.GetRowCellValue(i, "start_work_ot").ToString = "" Or GVAttendance.GetRowCellValue(i, "end_work_ot").ToString = "" Then
                            check_warning = "Overtime start work or end work cannot be blank."
                        End If
                    End If
                End If
            Next

            If check_warning = "" Then
                Dim confirm As DialogResult

                confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim query As String = ""

                    Dim ot_date As String = Date.Parse(DESearch.EditValue.ToString).ToString("yyyy-MM-dd")
                    Dim id_payroll As String = SLUEPayroll.EditValue.ToString

                    Dim need_approval As Boolean = False

                    If id = "0" Then
                        need_approval = True

                        query = "
                            INSERT INTO tb_ot_verification (id_ot, id_departement, ot_date, id_payroll, id_report_status, created_by, created_at) VALUES (" + id_ot + ", " + LEDepartement.EditValue.ToString + ", '" + ot_date + "', " + id_payroll + ", 1, " + id_employee_user + ", NOW()); SELECT LAST_INSERT_ID();
                        "

                        id = execute_query(query, 0, True, "", "", "", "")
                    Else
                        'update
                        query = "
                            UPDATE tb_ot_verification SET id_ot = " + id_ot + ", id_departement = " + LEDepartement.EditValue.ToString + ", ot_date = '" + ot_date + "', id_payroll = " + id_payroll + ", updated_by = " + id_employee_user + ", updated_at = NOW() WHERE id_ot_verification = " + id + "
                        "

                        execute_non_query(query, True, "", "", "", "")

                        'delete detail
                        query = "DELETE FROM tb_ot_verification_det WHERE id_ot_verification = " + id

                        execute_non_query(query, True, "", "", "", "")
                    End If

                    For i = 0 To GVAttendance.RowCount - 1
                        If GVAttendance.IsValidRowHandle(i) Then
                            Dim start_work_att As String = "NULL"
                            Dim end_work_att As String = "NULL"
                            Dim start_work_ot As String = "NULL"
                            Dim end_work_ot As String = "NULL"

                            Dim id_employee As String = GVAttendance.GetRowCellValue(i, "id_employee").ToString
                            Dim id_departement As String = GVAttendance.GetRowCellValue(i, "id_departement").ToString
                            Dim id_departement_sub As String = GVAttendance.GetRowCellValue(i, "id_departement_sub").ToString
                            Dim employee_position As String = GVAttendance.GetRowCellValue(i, "employee_position").ToString
                            Dim id_employee_status As String = GVAttendance.GetRowCellValue(i, "id_employee_status").ToString
                            Dim to_salary As String = GVAttendance.GetRowCellValue(i, "to_salary").ToString
                            Dim conversion_type As String = GVAttendance.GetRowCellValue(i, "conversion_type").ToString
                            Dim is_valid As String = If(GVAttendance.GetRowCellValue(i, "is_valid").ToString = "yes", "1", "2")

                            Try
                                start_work_att = DateTime.Parse(DateTime.Parse(GVAttendance.GetRowCellValue(i, "date").ToString).ToString("dd MMMM yyyy") + " " + DateTime.Parse(GVAttendance.GetRowCellValue(i, "start_work_att").ToString).ToString("HH:mm:ss")).ToString("yyyy-MM-dd HH:mm:ss")
                            Catch ex As Exception
                            End Try

                            Try
                                end_work_att = DateTime.Parse(DateTime.Parse(GVAttendance.GetRowCellValue(i, "date").ToString).ToString("dd MMMM yyyy") + " " + DateTime.Parse(GVAttendance.GetRowCellValue(i, "end_work_att").ToString).ToString("HH:mm:ss")).ToString("yyyy-MM-dd HH:mm:ss")

                                If DateTime.Parse(end_work_att) < DateTime.Parse(start_work_att) Then
                                    end_work_att = DateTime.Parse(end_work_att).AddDays(1).ToString("yyyy-MM-dd HH:mm:ss")
                                End If
                            Catch ex As Exception
                            End Try

                            Try
                                start_work_ot = DateTime.Parse(DateTime.Parse(GVAttendance.GetRowCellValue(i, "date").ToString).ToString("dd MMMM yyyy") + " " + DateTime.Parse(GVAttendance.GetRowCellValue(i, "start_work_ot").ToString).ToString("HH:mm:ss")).ToString("yyyy-MM-dd HH:mm:ss")
                            Catch ex As Exception
                            End Try

                            Try
                                end_work_ot = DateTime.Parse(DateTime.Parse(GVAttendance.GetRowCellValue(i, "date").ToString).ToString("dd MMMM yyyy") + " " + DateTime.Parse(GVAttendance.GetRowCellValue(i, "end_work_ot").ToString).ToString("HH:mm:ss")).ToString("yyyy-MM-dd HH:mm:ss")

                                If DateTime.Parse(end_work_ot) < DateTime.Parse(start_work_ot) Then
                                    end_work_ot = DateTime.Parse(end_work_ot).AddDays(1).ToString("yyyy-MM-dd HH:mm:ss")
                                End If
                            Catch ex As Exception
                            End Try

                            Dim break_hours As String = GVAttendance.GetRowCellValue(i, "break_hours").ToString
                            Dim total_hours As String = GVAttendance.GetRowCellValue(i, "total_hours").ToString
                            Dim ot_note As String = GVAttendance.GetRowCellValue(i, "ot_note").ToString

                            query = "INSERT INTO tb_ot_verification_det (id_ot_verification, id_employee, id_departement, id_departement_sub, employee_position, id_employee_status, to_salary, conversion_type, start_work_att, end_work_att, start_work_ot, end_work_ot, break_hours, total_hours, ot_note, is_valid) VALUES (" + id + ", " + id_employee + ", " + id_departement + ", " + id_departement_sub + ", '" + addSlashes(employee_position) + "', " + id_employee_status + ", " + to_salary + ", " + conversion_type + ", " + If(start_work_att = "NULL", start_work_att, "'" + start_work_att + "'") + ", " + If(end_work_att = "NULL", end_work_att, "'" + end_work_att + "'") + ", " + If(start_work_ot = "NULL", start_work_ot, "'" + start_work_ot + "'") + ", " + If(end_work_ot = "NULL", end_work_ot, "'" + end_work_ot + "'") + ", " + decimalSQL(break_hours) + ", " + decimalSQL(total_hours) + ", '" + addSlashes(ot_note) + "', '" + is_valid + "')"

                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Next

                    'approval
                    If need_approval Then
                        Dim is_user_head As Boolean = If(execute_query("SELECT id_user_head FROM tb_m_departement WHERE id_departement = " + LEDepartement.EditValue.ToString, 0, True, "", "", "", "") = id_user, True, False)

                        If LEDepartement.EditValue.ToString = "8" Or id_departement_user = "8" Then
                            'departement hrd
                            If is_user_head Then
                                'manager hrd submit
                                submit_who_prepared("216", id, id_user)
                                execute_non_query("UPDATE tb_ot_verification SET report_mark_type = 216 WHERE id_ot_verification = " + id, True, "", "", "", "")
                            Else
                                'admin hrd submit
                                submit_who_prepared("215", id, id_user)
                                execute_non_query("UPDATE tb_ot_verification SET report_mark_type = 215 WHERE id_ot_verification = " + id, True, "", "", "", "")
                            End If
                        Else
                            'other departement
                            If is_user_head Then
                                'manager submit
                                submit_who_prepared("215", id, id_user)
                                execute_non_query("UPDATE tb_ot_verification SET report_mark_type = 215 WHERE id_ot_verification = " + id, True, "", "", "", "")
                            Else
                                'admin submit
                                submit_who_prepared("187", id, id_user)
                                execute_non_query("UPDATE tb_ot_verification SET report_mark_type = 187 WHERE id_ot_verification = " + id, True, "", "", "", "")
                            End If
                        End If
                    End If

                    If type = "complete" Then
                        FormReportMark.report_mark_type = execute_query("SELECT report_mark_type FROM tb_ot_verification WHERE id_ot_verification = " + id, 0, True, "", "", "", "")
                        FormReportMark.id_report = id
                        FormReportMark.change_status("6")
                    End If

                    If Not ot_date = Nothing Then
                        SBView_Click(SBView, New EventArgs)
                    Else
                        Close()
                    End If
                Else
                    GVAttendance.ActiveFilterString = "[ot_potention] = '1'"
                End If
            Else
                errorCustom(check_warning)

                GVAttendance.ActiveFilterString = "[ot_potention] = '1'"
            End If
        Else
            errorCustom("No valid overtime.")

            GVAttendance.ActiveFilterString = "[ot_potention] = '1'"
        End If
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Dispose()
    End Sub

    Sub change_payroll()
        Dim id_payroll As String = execute_query("SELECT IFNULL((SELECT id_payroll FROM tb_emp_payroll WHERE id_payroll_type = 1 AND DATE(NOW()) BETWEEN periode_start AND periode_end), 0)", 0, True, "", "", "", "")

        If Not id_payroll = "0" Then
            SLUEPayroll.EditValue = id_payroll
        Else
            SLUEPayroll.EditValue = Nothing

            stopCustom("Please add payroll period.")
        End If
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = execute_query("SELECT report_mark_type FROM tb_ot_verification WHERE id_ot_verification = " + id, 0, True, "", "", "", "")
        FormReportMark.id_report = id

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Function calc_point(ByVal tot_hour As Decimal, ByVal is_day_off As String, ByVal is_store As String) As Decimal
        Dim tot_point As Decimal = 0.0

        Try
            If is_day_off = "1" Then
                'hari libur
                If is_store = "1" Then 'toko
                    tot_point = If(tot_hour > 8, ((tot_hour - 8) * 4), 0) + If(tot_hour > 7, ((tot_hour - If(tot_hour > 7, (tot_hour - 8), 0) - 7) * 3), 0) + (tot_hour - If(tot_hour > 7, (tot_hour - 7), 0)) * 2
                Else 'office
                    tot_point = If(tot_hour > 9, ((tot_hour - 9) * 4), 0) + If(tot_hour > 8, ((tot_hour - If(tot_hour > 9, (tot_hour - 9), 0) - 8) * 3), 0) + (tot_hour - If(tot_hour > 8, (tot_hour - 8), 0)) * 2
                End If
            Else
                'hari kerja
                tot_point = If(tot_hour > 1, ((tot_hour - 1) * 2), 0) + ((tot_hour - If(tot_hour > 1, (tot_hour - 1), 0)) * 1.5)
            End If
        Catch ex As Exception
        End Try

        Return tot_point
    End Function

    Sub update_changes()
        Dim query As String = ""

        query = "
            SELECT vr.id_payroll, vrd.id_employee, ot.id_ot_type, vrd.start_work_ot AS ot_start, vrd.end_work_ot AS ot_end, vrd.break_hours AS total_break, vrd.total_hours AS total_hour, 0.0 AS total_point, IF((sch.id_schedule_type = 1 OR sch.id_schedule_type IS NULL) AND ((SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = vr.ot_date AND id_religion IN (0, IF(s.is_store = 1, 0, e.id_religion))) IS NULL), 2, 1) AS is_day_off, ott.ot_point_wages AS wages_per_point, vrd.ot_note AS note, vrd.id_ot_verification_det, py.periode_end, vrd.to_salary, vrd.conversion_type, s.is_store
            FROM tb_ot_verification_det AS vrd
            LEFT JOIN tb_ot_verification AS vr ON vrd.id_ot_verification = vr.id_ot_verification
            LEFT JOIN tb_m_employee AS e ON vrd.id_employee = e.id_employee
            LEFT JOIN tb_ot AS ot ON vr.id_ot = ot.id_ot
            LEFT JOIN tb_lookup_ot_type AS ott ON ot.id_ot_type = ott.id_ot_type
            LEFT JOIN tb_emp_payroll AS py ON vr.id_payroll = py.id_payroll
            LEFT JOIN tb_m_departement AS d ON vrd.id_departement = d.id_departement
            LEFT JOIN tb_m_departement AS s ON vr.id_departement = s.id_departement
            LEFT JOIN tb_emp_schedule AS sch ON vrd.id_employee = sch.id_employee AND sch.date = vr.ot_date
            WHERE vrd.id_ot_verification = " + id + " AND vrd.is_valid = 1
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim id_payroll As String = data.Rows(i)("id_payroll").ToString
            Dim id_employee As String = data.Rows(i)("id_employee").ToString
            Dim id_ot_type As String = data.Rows(i)("id_ot_type").ToString
            Dim ot_start As String = Date.Parse(data.Rows(i)("ot_start").ToString()).ToString("yyyy-MM-dd HH:mm:ss")
            Dim ot_end As String = Date.Parse(data.Rows(i)("ot_end").ToString()).ToString("yyyy-MM-dd HH:mm:ss")
            Dim total_break As String = data.Rows(i)("total_break").ToString
            Dim total_hour As String = data.Rows(i)("total_hour").ToString
            Dim total_point As String = data.Rows(i)("total_point").ToString
            Dim is_day_off As String = data.Rows(i)("is_day_off").ToString
            Dim wages_per_point As String = data.Rows(i)("wages_per_point").ToString
            Dim note As String = data.Rows(i)("note").ToString
            Dim id_ot_verification_det As String = data.Rows(i)("id_ot_verification_det").ToString
            Dim periode_end As String = data.Rows(i)("periode_end").ToString
            Dim to_salary As String = data.Rows(i)("to_salary").ToString
            Dim conversion_type As String = data.Rows(i)("conversion_type").ToString
            Dim is_store As String = data.Rows(i)("is_store").ToString

            total_point = If(to_salary = "1", calc_point(Decimal.Parse(total_hour), is_day_off, is_store), total_hour)

            Dim qty As String = Math.Round((Decimal.Parse(total_point) * 60)).ToString
            Dim date_expired As String = Date.Parse(periode_end).AddMonths(6).ToString("yyyy-MM-dd")

            If conversion_type = "1" Then
                'overtime
                query = "INSERT INTO tb_emp_payroll_ot (id_payroll, id_employee, id_ot_type, ot_start, ot_end, total_break, total_hour, total_point, is_day_off, wages_per_point, note, id_ot_verification_det) VALUES (" + id_payroll + ", " + id_employee + ", " + id_ot_type + ", '" + ot_start + "', '" + ot_end + "', " + decimalSQL(total_break) + ", " + decimalSQL(total_hour) + ", " + decimalSQL(total_point) + ", " + is_day_off + ", " + decimalSQL(wages_per_point) + ", '" + addSlashes(note) + "', " + id_ot_verification_det + ")"

                execute_non_query(query, True, "", "", "", "")
            ElseIf conversion_type = "2" Then
                'dp
                query = "INSERT INTO tb_emp_stock_leave (id_ot_verification_det, id_emp, qty, plus_minus, date_leave, date_expired, is_process_exp, note, type) VALUES (" + id_ot_verification_det + ", " + id_employee + ", " + qty + ", 1, NOW(), '" + date_expired + "', 1, '" + note + "', 2)"

                execute_non_query(query, True, "", "", "", "")
            End If
        Next
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_ot_verification WHERE id_ot_verification = " + id, 0, True, "", "", "", "")

        Dim Report As New ReportEmpOvertimeVerification()

        Report.id = id
        Report.data1 = GCEmployee.DataSource
        Report.data2 = GCAttendance.DataSource
        Report.id_pre = "1"

        Report.XLNumber.Text = TENumber.Text.ToString
        Report.XLOTtype.Text = LUEOvertimeType.Text.ToString
        Report.XLDate.Text = DESearch.Text
        Report.XLPayrollPeriod.Text = SLUEPayroll.Text
        Report.XLCreatedAt.Text = TECreatedBy.Text.ToString
        Report.XLCreatedBy.Text = TECreatedAt.Text.ToString

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
    End Sub

    Private Sub SBReset_Click(sender As Object, e As EventArgs) Handles SBReset.Click
        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All approval will be reset. Are you sure want to reset overtime verification ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim report_mark_type As String = execute_query("SELECT report_mark_type FROM tb_ot_verification WHERE id_ot_verification = " + id, 0, True, "", "", "", "")

            Dim query As String = ""

            query = "DELETE FROM tb_ot_verification_det WHERE id_ot_verification = " + id

            execute_non_query(query, True, "", "", "", "")

            query = "DELETE FROM tb_ot_verification WHERE id_ot_verification = " + id

            execute_non_query(query, True, "", "", "", "")

            query = "DELETE FROM tb_report_mark WHERE report_mark_type = " + report_mark_type + " AND id_report = " + id

            execute_non_query(query, True, "", "", "", "")

            SBView_Click(SBView, New EventArgs)
        End If
    End Sub

    Private clone As DataView = Nothing

    Private Sub GVAttendance_ShownEditor(sender As Object, e As EventArgs) Handles GVAttendance.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If view.FocusedColumn.FieldName = "conversion_type" AndAlso TypeOf view.ActiveEditor Is DevExpress.XtraEditors.SearchLookUpEdit Then
            Dim edit As DevExpress.XtraEditors.SearchLookUpEdit
            Dim table As DataTable
            Dim row As DataRow

            edit = CType(view.ActiveEditor, DevExpress.XtraEditors.SearchLookUpEdit)

            Try
                table = CType(edit.Properties.DataSource, DataTable)
            Catch ex As Exception
                table = CType(edit.Properties.DataSource, DataView).Table
            End Try

            clone = New DataView(table)

            row = view.GetDataRow(view.FocusedRowHandle)

            If view.GetFocusedRowCellValue("total_hours") < ot_min_staff Then
                clone.RowFilter = "[to_salary] = 2 AND [to_dp] = 2"
            Else
                If view.GetFocusedRowCellValue("to_salary").ToString = "1" Then
                    clone.RowFilter = ""
                Else
                    If is_store = "1" Then
                        If view.GetFocusedRowCellValue("total_hours") < ot_min_spv Then
                            clone.RowFilter = "[to_salary] = 2 AND [to_dp] = 2"
                        Else
                            clone.RowFilter = "[to_salary] = 2"
                        End If
                    Else
                        If view.GetFocusedRowCellValue("is_day_off").ToString = "1" Then
                            If view.GetFocusedRowCellValue("total_hours") < ot_min_spv Then
                                clone.RowFilter = "[to_salary] = 2 AND [to_dp] = 2"
                            Else
                                clone.RowFilter = "[to_salary] = 2"
                            End If
                        Else
                            clone.RowFilter = "[to_salary] = 2 AND [to_dp] = 2"
                        End If
                    End If
                End If
            End If

            edit.Properties.DataSource = clone
        End If
    End Sub

    Private Sub GVAttendance_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVAttendance.CellValueChanged
        If loaded Then
            If e.Column.FieldName.ToString = "total_hours" Then
                'check conversion type
                If GVAttendance.GetRowCellValue(e.RowHandle, "total_hours") < ot_min_staff Then
                    GVAttendance.SetRowCellValue(e.RowHandle, "conversion_type", 3)

                    GVAttendance.SetRowCellValue(e.RowHandle, "is_valid", "no")
                Else
                    If Not GVAttendance.GetRowCellValue(e.RowHandle, "to_salary").ToString = "1" Then
                        If GVAttendance.GetRowCellValue(e.RowHandle, "total_hours").ToString < ot_min_spv Then
                            GVAttendance.SetRowCellValue(e.RowHandle, "conversion_type", 3)

                            GVAttendance.SetRowCellValue(e.RowHandle, "is_valid", "no")
                        End If
                    End If
                End If

                Dim total_point As Decimal = If(GVAttendance.GetRowCellValue(e.RowHandle, "to_salary").ToString = "1", calc_point(GVAttendance.GetRowCellValue(e.RowHandle, "total_hours"), GVAttendance.GetRowCellValue(e.RowHandle, "is_day_off").ToString, is_store), GVAttendance.GetRowCellValue(e.RowHandle, "total_hours"))

                GVAttendance.SetRowCellValue(e.RowHandle, "point_ot", total_point)
            End If

            If e.Column.FieldName.ToString = "start_work_ot" Or e.Column.FieldName.ToString = "end_work_ot" Or e.Column.FieldName.ToString = "break_hours" Then
                Try
                    Dim start_work_ot As DateTime = DateTime.Parse(DateTime.Parse(GVAttendance.GetRowCellValue(e.RowHandle, "date").ToString).ToString("dd MMMM yyyy") + " " + DateTime.Parse(GVAttendance.GetRowCellValue(e.RowHandle, "start_work_ot").ToString).ToString("HH:mm:ss"))
                    Dim end_work_ot As DateTime = DateTime.Parse(DateTime.Parse(GVAttendance.GetRowCellValue(e.RowHandle, "date").ToString).ToString("dd MMMM yyyy") + " " + DateTime.Parse(GVAttendance.GetRowCellValue(e.RowHandle, "end_work_ot").ToString).ToString("HH:mm:ss"))

                    If end_work_ot < start_work_ot Then
                        end_work_ot = end_work_ot.AddDays(1)
                    End If

                    Dim break_hours As Decimal = GVAttendance.GetRowCellValue(e.RowHandle, "break_hours")

                    Dim diff As TimeSpan = end_work_ot.Subtract(start_work_ot)

                    Dim total As Decimal = 0.0

                    total = Math.Round(Math.Round(diff.TotalHours, 1) - break_hours, 1)

                    GVAttendance.SetRowCellValue(e.RowHandle, "ot_hours", total)
                    GVAttendance.SetRowCellValue(e.RowHandle, "total_hours", (Math.Floor(total / 0.5) * 0.5))
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Private Sub SBFill_Click(sender As Object, e As EventArgs) Handles SBFill.Click
        GVAttendance.ActiveFilterString = ""

        For i = 0 To GVAttendance.RowCount - 1
            If GVAttendance.IsValidRowHandle(i) Then
                For j = 0 To GVEmployee.RowCount - 1
                    If GVEmployee.IsValidRowHandle(j) Then
                        If GVAttendance.GetRowCellValue(i, "id_employee").ToString = GVEmployee.GetRowCellValue(j, "id_employee").ToString Then
                            If i = GVAttendance.FocusedRowHandle Then
                                Dim fill As Boolean = False

                                GVAttendance.SetRowCellValue(i, "ot_potention", "1")

                                If GVAttendance.GetRowCellValue(i, "start_work_ot").ToString = "" Then
                                    GVAttendance.SetRowCellValue(i, "start_work_ot", GVEmployee.GetRowCellValue(j, "ot_start_time"))

                                    fill = True
                                End If

                                If GVAttendance.GetRowCellValue(i, "end_work_ot").ToString = "" Then
                                    GVAttendance.SetRowCellValue(i, "end_work_ot", GVEmployee.GetRowCellValue(j, "ot_end_time"))

                                    fill = True
                                End If

                                If fill Then
                                    GVAttendance.SetRowCellValue(i, "break_hours", GVEmployee.GetRowCellValue(j, "ot_break"))
                                    GVAttendance.SetRowCellValue(i, "ot_note", GVEmployee.GetRowCellValue(j, "ot_note").ToString)
                                End If
                            End If
                        End If
                    End If
                Next
            End If
        Next

        GVAttendance.ActiveFilterString = "[ot_potention] = '1'"
    End Sub

    Private Sub SBComplete_Click(sender As Object, e As EventArgs) Handles SBComplete.Click
        submit("complete")
    End Sub

    Sub check_overtime()
        Dim is_store As String = execute_query("SELECT is_store FROM tb_m_departement WHERE id_departement = (SELECT id_departement FROM tb_ot WHERE id_ot = " + id_ot + ")", 0, True, "", "", "", "")
        Dim date_search As String = Date.Parse(DESearch.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim departement_include As String = execute_query("SELECT GROUP_CONCAT(DISTINCT id_departement) AS id_departement FROM tb_ot_det WHERE ot_date = '" + date_search + "' AND id_ot = " + id_ot, 0, True, "", "", "", "")

        Dim ot_min_staff As Integer = get_opt_emp_field("ot_min_staff")
        Dim ot_min_spv As Integer = get_opt_emp_field("ot_min_spv")

        'propose
        Dim query_propose As String = "
            SELECT ot_det.id_employee, ot_det.id_departement, ot_det.id_departement_sub, departement.departement, ot_det.ot_date, employee.employee_code, employee.employee_name, ot_det.employee_position, ot_det.id_employee_status, employee_status.employee_status, ot_det.to_salary, IF(((SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_det.id_employee AND DATE = ot_det.ot_date) = 1 OR (SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_det.id_employee AND DATE = ot_det.ot_date) IS NULL) AND ((SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = ot_det.ot_date AND id_religion IN (0, IF(" + is_store + " = 1, 0, employee.id_religion))) IS NULL), 2, 1) AS is_day_off, ot_det.ot_consumption, ot_det.conversion_type, ot_det.ot_start_time AS ot_start_time, ot_det.ot_end_time AS ot_end_time, ot_det.ot_break, ROUND((TIMESTAMPDIFF(MINUTE, ot_det.ot_start_time, ot_det.ot_end_time) / 60) - ot_det.ot_break, 1) AS ot_total_hours, ot_det.ot_note
            FROM tb_ot_det AS ot_det
            LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
            LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
            LEFT JOIN tb_m_departement AS departement ON ot_det.id_departement = departement.id_departement
            LEFT JOIN tb_lookup_employee_status AS employee_status ON ot_det.id_employee_status = employee_status.id_employee_status
            WHERE ot_det.id_ot = " + id_ot + " AND ot_det.ot_date = '" + date_search + "'
            ORDER BY ot_det.ot_date ASC, departement.departement ASC, employee.id_employee_level ASC, employee.employee_code ASC
        "

        Dim data_propose As DataTable = execute_query(query_propose, -1, True, "", "", "", "")

        'attendance
        Dim query_att As String = "
            SELECT * FROM (
                SELECT sch.id_employee, emp.id_departement, dep_sub.id_departement_sub, dep.departement, sch.date, emp.employee_code, emp.employee_name, emp.employee_position, emp.id_employee_level, emp.id_employee_status, sts.employee_status, IF(salary.salary > (dep_sub.ump + (SELECT ot_ump_conversion FROM tb_opt_emp LIMIT 1)) OR emp.id_employee_level <= 12, '2', '1') AS to_salary, IF((sch.id_schedule_type = 1 OR sch.id_schedule_type IS NULL) AND ((SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = '" + date_search + "' AND id_religion IN (0, IF(" + is_store + " = 1, 0, emp.id_religion))) IS NULL), 2, 1) AS is_day_off, IF((SELECT to_salary) = 1, 1, IF((SELECT is_day_off) = 1, 2, IF(" + is_store + " = 1, 2, 3))) AS conversion_type, IF(sch.id_schedule_type = '1', IFNULL(at_input.time_in, MIN(at_in.datetime)), IFNULL(at_input.time_in, MIN(at_in_hol.datetime))) AS start_work_att, IF(sch.id_schedule_type = '1', IFNULL(at_input.time_out, MAX(at_out.datetime)), IFNULL(at_input.time_out, MAX(at_out_hol.datetime))) AS end_work_att, '' AS start_work_ot, '' AS end_work_ot, 0.0 AS break_hours, 0.0 AS ot_hours, 0.0 AS total_hours, 0.0 AS point_ot, '' AS ot_note, 'no' AS is_valid, sch.id_schedule_type, sch.in, sch.out, 2 AS ot_potention
                FROM tb_emp_schedule AS sch
                LEFT JOIN tb_m_employee AS emp ON emp.id_employee = sch.id_employee
                LEFT JOIN tb_m_departement AS dep ON emp.id_departement = dep.id_departement 
                LEFT JOIN tb_m_departement_sub AS dep_sub ON IFNULL(emp.id_departement_sub, (SELECT id_departement_sub FROM tb_m_departement_sub WHERE id_departement = emp.id_departement LIMIT 1)) = dep_sub.id_departement_sub
                LEFT JOIN tb_lookup_employee_status AS sts ON emp.id_employee_status = sts.id_employee_status
                LEFT JOIN (
                    SELECT id_employee, (basic_salary + allow_job + allow_meal + allow_trans + allow_house + allow_car) AS salary
                    FROM tb_m_employee
                ) AS salary ON emp.id_employee = salary.id_employee
                LEFT JOIN tb_emp_attn AS at_in ON at_in.id_employee = sch.id_employee AND (at_in.datetime >= (sch.out - INTERVAL 18 HOUR) AND at_in.datetime <= sch.out) AND at_in.type_log = 1 
                LEFT JOIN tb_emp_attn AS at_out ON at_out.id_employee = sch.id_employee AND (at_out.datetime >= sch.in AND at_out.datetime <= (sch.in + INTERVAL 18 HOUR)) AND at_out.type_log = 2 
                LEFT JOIN tb_emp_attn AS at_in_hol ON at_in_hol.id_employee = sch.id_employee AND DATE(at_in_hol.datetime) = sch.date AND at_in_hol.type_log = 1 
                LEFT JOIN tb_emp_attn AS at_out_hol ON at_out_hol.id_employee = sch.id_employee AND DATE(at_out_hol.datetime) = sch.date AND at_out_hol.type_log = 2
                LEFT JOIN (
                    SELECT input_det.id_employee, input_det.date, input_det.time_in, input_det.time_out
                    FROM tb_emp_attn_input_det AS input_det
                    LEFT JOIN tb_emp_attn_input AS input ON input_det.id_emp_attn_input = input.id_emp_attn_input
                    WHERE input.id_report_status = 6 AND input_det.date = '" + date_search + "'
                ) AS at_input ON sch.id_employee = at_input.id_employee
                WHERE sch.date = '" + date_search + "' AND emp.id_departement IN (" + departement_include + ")
                GROUP BY sch.id_schedule
            ) AS tb
            ORDER BY tb.departement ASC, tb.id_employee_level ASC, tb.employee_code ASC
        "

        Dim data_att As DataTable = execute_query(query_att, -1, True, "", "", "", "")

        For i = 0 To data_att.Rows.Count - 1
            If (Not data_att.Rows(i)("start_work_att").ToString = "") And (Not data_att.Rows(i)("end_work_att").ToString = "") Then
                For j = 0 To data_propose.Rows.Count - 1
                    Dim ot_min As Integer = If(data_att.Rows(i)("to_salary").ToString = "1", ot_min_staff, ot_min_spv)

                    Dim after_work As Decimal = 0.0
                    Dim before_work As Decimal = 0.0

                    Dim after_work_ot As Decimal = 0.0
                    Dim before_work_ot As Decimal = 0.0

                    Dim work_hours As Decimal = 0.0
                    Dim ot_hours As Decimal = 0.0

                    Dim overtime_in As DateTime = New DateTime
                    Dim overtime_out As DateTime = New DateTime

                    Dim schedule_in As DateTime = New DateTime
                    Dim schedule_out As DateTime = New DateTime

                    Dim start_work_att As DateTime = New DateTime
                    Dim end_work_att As DateTime = New DateTime

                    Try
                        overtime_in = DateTime.Parse(data_propose.Rows(j)("ot_start_time"))
                        overtime_out = DateTime.Parse(data_propose.Rows(j)("ot_end_time"))
                    Catch ex As Exception
                    End Try

                    Try
                        schedule_in = DateTime.Parse(data_att.Rows(i)("in"))
                        schedule_out = DateTime.Parse(data_att.Rows(i)("out"))
                    Catch ex As Exception
                    End Try

                    Try
                        start_work_att = DateTime.Parse(data_att.Rows(i)("start_work_att"))
                        end_work_att = DateTime.Parse(data_att.Rows(i)("end_work_att"))
                    Catch ex As Exception
                    End Try

                    Dim ot_start_time As DateTime = If(schedule_out > overtime_in, schedule_out, overtime_in)
                    Dim ot_end_time As DateTime = If(schedule_in < overtime_out, overtime_out, schedule_in)

                    'over of schedule
                    after_work = (end_work_att - schedule_out).TotalHours
                    before_work = (schedule_in - start_work_att).TotalHours

                    'over of overtime
                    after_work_ot = (end_work_att - ot_start_time).TotalHours - data_propose.Rows(j)("ot_break")
                    before_work_ot = (ot_end_time - start_work_att).TotalHours - data_propose.Rows(j)("ot_break")

                    work_hours = (end_work_att - start_work_att).TotalHours - data_propose.Rows(j)("ot_break")
                    ot_hours = (overtime_out - overtime_in).TotalHours - data_propose.Rows(j)("ot_break")

                    If data_att.Rows(i)("id_schedule_type").ToString = "1" Then
                        If after_work >= ot_min And after_work_ot >= ot_min Then
                            data_att.Rows(i)("ot_potention") = "1"

                            Dim total_hours As Decimal = Math.Floor(after_work_ot / 0.5) * 0.5

                            data_att.Rows(i)("start_work_ot") = ot_start_time
                            data_att.Rows(i)("end_work_ot") = data_att.Rows(i)("end_work_att")
                            data_att.Rows(i)("break_hours") = data_propose.Rows(j)("ot_break")
                            data_att.Rows(i)("ot_hours") = after_work_ot
                            data_att.Rows(i)("total_hours") = total_hours

                            If data_att.Rows(i)("id_employee").ToString = data_propose.Rows(j)("id_employee").ToString Then
                                data_att.Rows(i)("is_valid") = "yes"
                                data_att.Rows(i)("ot_note") = data_propose.Rows(j)("ot_note").ToString
                            End If
                        ElseIf before_work >= ot_min And before_work_ot >= ot_min Then
                            data_att.Rows(i)("ot_potention") = "1"

                            Dim total_hours As Decimal = Math.Floor(before_work_ot / 0.5) * 0.5

                            data_att.Rows(i)("start_work_ot") = data_att.Rows(i)("start_work_att")
                            data_att.Rows(i)("end_work_ot") = ot_end_time
                            data_att.Rows(i)("break_hours") = data_propose.Rows(j)("ot_break")
                            data_att.Rows(i)("ot_hours") = before_work_ot
                            data_att.Rows(i)("total_hours") = total_hours

                            If data_att.Rows(i)("id_employee").ToString = data_propose.Rows(j)("id_employee").ToString Then
                                data_att.Rows(i)("is_valid") = "yes"
                                data_att.Rows(i)("ot_note") = data_propose.Rows(j)("ot_note").ToString
                            End If
                        End If

                        'overtime on public holiday
                        If data_att.Rows(i)("is_day_off").ToString = "1" And data_att.Rows(i)("id_employee").ToString = data_propose.Rows(j)("id_employee").ToString Then
                            data_att.Rows(i)("ot_potention") = "1"

                            Dim total_hours As Decimal = Math.Floor(work_hours / 0.5) * 0.5

                            data_att.Rows(i)("start_work_ot") = data_att.Rows(i)("start_work_att")
                            data_att.Rows(i)("end_work_ot") = data_att.Rows(i)("end_work_att")
                            data_att.Rows(i)("break_hours") = data_propose.Rows(j)("ot_break")
                            data_att.Rows(i)("ot_hours") = work_hours
                            data_att.Rows(i)("total_hours") = total_hours

                            data_att.Rows(i)("is_valid") = "yes"
                            data_att.Rows(i)("ot_note") = data_propose.Rows(j)("ot_note").ToString
                        End If
                    Else
                        data_att.Rows(i)("ot_potention") = "1"

                        Dim total_hours As Decimal = Math.Floor(work_hours / 0.5) * 0.5

                        data_att.Rows(i)("start_work_ot") = data_att.Rows(i)("start_work_att")
                        data_att.Rows(i)("end_work_ot") = data_att.Rows(i)("end_work_att")
                        data_att.Rows(i)("break_hours") = data_propose.Rows(j)("ot_break")
                        data_att.Rows(i)("ot_hours") = work_hours
                        data_att.Rows(i)("total_hours") = total_hours

                        If data_att.Rows(i)("id_employee").ToString = data_propose.Rows(j)("id_employee").ToString Then
                            data_att.Rows(i)("is_valid") = "yes"
                            data_att.Rows(i)("ot_note") = data_propose.Rows(j)("ot_note").ToString
                        End If
                    End If

                    'overtime in shedule
                    If data_att.Rows(i)("id_employee").ToString = data_propose.Rows(j)("id_employee").ToString And data_att.Rows(i)("ot_potention").ToString = "2" Then
                        If (overtime_in >= start_work_att And overtime_in <= end_work_att) Or (overtime_out >= start_work_att And overtime_out <= end_work_att) Then
                            Dim start_work_sch As DateTime = If(overtime_in > start_work_att, overtime_in, start_work_att)
                            Dim end_work_sch As DateTime = If(overtime_out < end_work_att, overtime_out, end_work_att)

                            Dim ot_hours_sch As Decimal = (end_work_sch - start_work_sch).TotalHours - data_propose.Rows(j)("ot_break")
                            Dim total_hours As Decimal = Math.Floor(ot_hours_sch / 0.5) * 0.5

                            If total_hours >= ot_min Then
                                data_att.Rows(i)("ot_potention") = "1"

                                data_att.Rows(i)("start_work_ot") = start_work_sch
                                data_att.Rows(i)("end_work_ot") = end_work_sch
                                data_att.Rows(i)("break_hours") = data_propose.Rows(j)("ot_break")
                                data_att.Rows(i)("ot_hours") = ot_hours_sch
                                data_att.Rows(i)("total_hours") = total_hours

                                data_att.Rows(i)("is_valid") = "yes"
                                data_att.Rows(i)("ot_note") = data_propose.Rows(j)("ot_note").ToString
                            End If
                        End If
                    End If
                Next
            End If
        Next

        'check other propose
        Dim query_other As String = "
            SELECT ot_det.id_employee, ot_det.ot_start_time, ot_det.ot_end_time
            FROM tb_ot_det AS ot_det
            LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
            WHERE ot.id_report_status <> 5 AND ot_det.ot_date = '" + date_search + "' AND ot.id_ot <> '" + id_ot + "'
        "

        Dim data_other As DataTable = execute_query(query_other, -1, True, "", "", "", "")

        For i = 0 To data_att.Rows.Count - 1
            For j = 0 To data_other.Rows.Count - 1
                If data_att.Rows(i)("ot_potention").ToString = "1" And data_att.Rows(i)("id_employee").ToString = data_other.Rows(j)("id_employee").ToString Then
                    data_att.Rows(i)("ot_potention") = "2"
                End If
            Next
        Next

        'check match
        Dim match As Boolean = True

        For i = 0 To data_propose.Rows.Count - 1
            For j = 0 To data_att.Rows.Count - 1
                If data_propose.Rows(i)("id_employee").ToString = data_att.Rows(j)("id_employee").ToString And data_att.Rows(j)("ot_potention").ToString = "2" Then
                    match = False
                End If
            Next
        Next

        If Not match Then
            MsgBox("Overtime not match")
        End If
    End Sub

    Private Sub GVAttendance_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVAttendance.RowCellStyle
        If loaded Then
            If GVAttendance.GetRowCellValue(e.RowHandle, "total_hours") <= 0 Then
                e.Appearance.BackColor = Color.FromArgb(243, 217, 217)
            Else
                Dim is_proposed As Boolean = False

                For i = 0 To GVEmployee.RowCount - 1
                    If GVEmployee.IsValidRowHandle(i) Then
                        If GVEmployee.GetRowCellValue(i, "id_employee").ToString = GVAttendance.GetRowCellValue(e.RowHandle, "id_employee").ToString Then
                            is_proposed = True
                        End If
                    End If
                Next

                If Not is_proposed Then
                    e.Appearance.BackColor = Color.FromArgb(217, 217, 243)
                End If
            End If
        End If
    End Sub
End Class