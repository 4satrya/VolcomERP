Public Class FormEmpOvertimePick
    Public is_hrd As String = "-1"
    Public overtime_date_from As DateTime = Now
    Public overtime_date_to As DateTime = Now
    Public overtime_start_time As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, 8, 30, 0)
    Public overtime_end_time As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, 17, 30, 0)
    Public overtime_break As Decimal = 0.0
    Public overtime_propose As String = ""
    Public total_hours As Decimal = 0.0

    Private Sub FormEmpOvertimePick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If is_hrd = "-1" Then
            Text = "Propose Overtime Pick"
        Else
            Text = "Overtime Management Pick"
        End If

        'load
        DEOvertimeDateFrom.EditValue = overtime_date_from
        DEOvertimeDateTo.EditValue = overtime_date_to
        TEOvertimeStart.EditValue = overtime_start_time
        TEOvertimeEnd.EditValue = overtime_end_time
        TEOvertimeBreak.EditValue = overtime_break
        MEOvertimeNote.EditValue = overtime_propose
        TETotalHours.EditValue = total_hours

        Dim include_all_dept As String = execute_query("SELECT include_all_dept FROM tb_lookup_ot_type WHERE id_ot_type = " + FormEmpOvertimeDet.LUEOvertimeType.EditValue.ToString, 0, True, "", "", "", "")

        Dim whereDept As String = "AND e.id_departement = " + FormEmpOvertimeDet.LEDepartement.EditValue.ToString

        If include_all_dept = "1" Then
            whereDept = ""
        End If

        'not include employee
        Dim date_from As Date = Date.Parse(DEOvertimeDateFrom.EditValue.ToString)
        Dim date_to As Date = Date.Parse(DEOvertimeDateTo.EditValue.ToString)
        Dim time_from As DateTime = DateTime.Parse(TEOvertimeStart.EditValue.ToString)
        Dim time_to As DateTime = DateTime.Parse(TEOvertimeEnd.EditValue.ToString)

        Dim whereNotInclude As String = ""

        whereNotInclude += dateIncludeGrid(date_from, date_to, time_from, time_to)

        whereNotInclude += dateIncludeDb(date_from, date_to, time_from, time_to)

        If Not whereNotInclude = "" Then
            whereNotInclude = "AND e.id_employee NOT IN (" + whereNotInclude.Substring(0, whereNotInclude.Length - 2) + ")"
        End If

        Dim query As String = "
            SELECT is_checked, id_employee, id_departement, id_departement_sub, departement, employee_code, employee_name, employee_position, id_employee_status, employee_status, id_employee_active, employee_active, to_salary, CONCAT(GROUP_CONCAT(CONCAT(date, ':', is_day_off))) AS is_day_off
            FROM (
                SELECT 'no' AS is_checked, e.id_employee, e.id_departement, ds.id_departement_sub, d.departement, e.employee_code, e.employee_name, e.employee_position, e.id_employee_status, st.employee_status, e.id_employee_active, la.employee_active, IF(salary.salary > (ds.ump + (SELECT ot_ump_conversion FROM tb_opt_emp LIMIT 1)) OR e.id_employee_level <= 12, '2', '1') AS to_salary, IF((sch.id_schedule_type = 1) AND ((SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = sch.date AND id_religion IN (0, IF(d.is_store = 1, 0, e.id_religion))) IS NULL), 2, 1) AS is_day_off, sch.date
                FROM tb_m_employee AS e
                LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement 
                LEFT JOIN tb_m_departement_sub AS ds ON IFNULL(e.id_departement_sub, (SELECT id_departement_sub FROM tb_m_departement_sub WHERE id_departement = e.id_departement LIMIT 1)) = ds.id_departement_sub
                LEFT JOIN tb_lookup_employee_status AS st ON e.id_employee_status = st.id_employee_status
                LEFT JOIN tb_lookup_employee_active AS la ON e.id_employee_active = la.id_employee_active
                LEFT JOIN (
                    SELECT id_employee, (basic_salary + allow_job + allow_meal + allow_trans + allow_house + allow_car) AS salary
                    FROM tb_m_employee
                ) AS salary ON e.id_employee = salary.id_employee
                LEFT JOIN tb_emp_schedule AS sch ON sch.id_employee = e.id_employee AND sch.date BETWEEN '" + date_from.ToString("yyyy-MM-dd") + "' AND '" + date_to.ToString("yyyy-MM-dd") + "'
                WHERE 1 " + whereDept + " " + whereNotInclude + "
                ORDER BY d.departement ASC, e.id_employee_level ASC, e.employee_code ASC, sch.date ASC
            ) AS tb
            GROUP BY id_employee
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        'find Active by id
        Dim active As String = ""

        For i = 1 To data.Rows.Count - 1
            If data.Rows(i)("id_employee_active").ToString = "1" Then
                active = data.Rows(i)("employee_active").ToString

                Exit For
            End If
        Next

        GVList.ActiveFilter.Add(GVList.Columns("employee_active"), New DevExpress.XtraGrid.Columns.ColumnFilterInfo("[employee_active] = '" + active + "'"))

        'filter employee get overtime
        Dim ot_memo_employee As Decimal = get_opt_emp_field("ot_memo_employee")
        Dim ot_min_spv As Decimal = get_opt_emp_field("ot_min_spv")

        Dim is_store As String = execute_query("SELECT is_store FROM tb_m_departement WHERE id_departement = " + FormEmpOvertimeDet.LEDepartement.EditValue.ToString, 0, True, "", "", "", "")

        If is_store = "1" Then
            If TETotalHours.EditValue < ot_min_spv Then
                GVList.ActiveFilter.Add(GVList.Columns("to_salary"), New DevExpress.XtraGrid.Columns.ColumnFilterInfo("[to_salary] = '1'"))
            End If
        Else
            If TETotalHours.EditValue < ot_memo_employee Then
                GVList.ActiveFilter.Add(GVList.Columns("to_salary"), New DevExpress.XtraGrid.Columns.ColumnFilterInfo("[to_salary] = '1'"))
            End If
        End If

        GVList.BestFitColumns()
    End Sub

    Private Sub FormEmpOvertimePick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBSelect_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        FormEmpOvertimeDate.Close()

        pick()
    End Sub

    Sub pick()
        Dim hours As Integer = get_opt_emp_field("ot_memo_employee")
        Dim ot_consumption As Decimal = 0.0

        Dim is_store As String = execute_query("SELECT is_store FROM tb_m_departement WHERE id_departement = " + FormEmpOvertimeDet.LEDepartement.EditValue.ToString, 0, True, "", "", "", "")

        If FormEmpOvertimeDet.LUEOvertimeType.EditValue.ToString = "1" And is_store = "2" And TETotalHours.EditValue >= hours Then
            ot_consumption = get_opt_emp_field("ot_consumption")
        End If

        Dim ot_min_spv As Integer = get_opt_emp_field("ot_min_spv")

        GVList.ApplyFindFilter("")

        GVList.ExpandAllGroups()

        Dim data As DataTable = FormEmpOvertimeDet.GCEmployee.DataSource

        Dim date_from As Date = Date.Parse(DEOvertimeDateFrom.EditValue.ToString)
        Dim date_to As Date = Date.Parse(DEOvertimeDateTo.EditValue.ToString)
        Dim time_from As DateTime = DateTime.Parse(TEOvertimeStart.EditValue.ToString)
        Dim time_to As DateTime = DateTime.Parse(TEOvertimeEnd.EditValue.ToString)

        For i = 0 To GVList.RowCount - 1
            If GVList.IsValidRowHandle(i) Then
                If GVList.GetRowCellValue(i, "is_checked") = "yes" Then
                    date_from = Date.Parse(DEOvertimeDateFrom.EditValue.ToString)

                    While date_from <= date_to
                        'day off
                        Dim is_day_off_date As String = "1"

                        Dim is_day_off As String = GVList.GetRowCellValue(i, "is_day_off").ToString

                        If Not is_day_off = "" Then
                            Dim cut As Integer = InStr(is_day_off, date_from.ToString("yyyy-MM-dd") + ":")

                            is_day_off_date = is_day_off.Substring(cut + 10).Substring(0, 1)
                        End If

                        'conversion type
                        Dim conversion_type As String = "3"

                        If GVList.GetRowCellValue(i, "to_salary") = "1" Then
                            conversion_type = "1"
                        Else
                            If is_store = "1" Then
                                conversion_type = "2"
                            Else
                                If is_day_off_date = "1" Then
                                    If TETotalHours.EditValue < ot_min_spv Then
                                        conversion_type = "3"
                                    Else
                                        conversion_type = "2"
                                    End If
                                Else
                                    conversion_type = "3"
                                End If
                            End If
                        End If

                        data.Rows.Add(GVList.GetRowCellValue(i, "id_employee"),
                                GVList.GetRowCellValue(i, "id_departement"),
                                GVList.GetRowCellValue(i, "id_departement_sub"),
                                GVList.GetRowCellValue(i, "departement"),
                                date_from.ToString("dd MMMM yyyy"),
                                GVList.GetRowCellValue(i, "employee_code"),
                                GVList.GetRowCellValue(i, "employee_name"),
                                GVList.GetRowCellValue(i, "employee_position"),
                                GVList.GetRowCellValue(i, "id_employee_status"),
                                GVList.GetRowCellValue(i, "employee_status"),
                                GVList.GetRowCellValue(i, "to_salary"),
                                conversion_type,
                                is_day_off_date,
                                ot_consumption,
                                time_from.ToString("HH:mm:ss"),
                                time_to.ToString("HH:mm:ss"),
                                TEOvertimeBreak.EditValue,
                                TETotalHours.EditValue,
                                MEOvertimeNote.EditValue.ToString)

                        date_from = date_from.AddDays(1)
                    End While
                End If
            End If
        Next

        FormEmpOvertimeDet.GCEmployee.DataSource = data

        FormEmpOvertimeDet.GCEmployee.RefreshDataSource()

        FormEmpOvertimeDet.GVEmployee.BestFitColumns()

        Close()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Function dateIncludeGrid(date_from As Date, date_to As Date, time_from As DateTime, time_to As DateTime) As String
        Dim whereNotInclude As String = ""

        For i = 0 To FormEmpOvertimeDet.GVEmployee.RowCount - 1
            If FormEmpOvertimeDet.GVEmployee.IsValidRowHandle(i) Then
                Dim ot_start_time As DateTime = FormEmpOvertimeDet.GVEmployee.GetRowCellValue(i, "ot_start_time")
                Dim ot_end_time As DateTime = FormEmpOvertimeDet.GVEmployee.GetRowCellValue(i, "ot_end_time")

                Dim date_from_temp As DateTime = date_from

                While date_from_temp <= date_to
                    Dim datetime_from As DateTime = Date.Parse(date_from_temp.ToString("dd MMMM yyyy") + " " + time_from.ToString("HH:mm:ss"))
                    Dim datetime_to As DateTime = Date.Parse(date_from_temp.ToString("dd MMMM yyyy") + " " + time_to.ToString("HH:mm:ss"))

                    If datetime_to < datetime_from Then
                        datetime_to.AddDays(1)
                    End If

                    If ((ot_start_time > datetime_from And ot_start_time < datetime_to) Or (ot_end_time > datetime_from And ot_end_time < datetime_to)) Or ((datetime_from > ot_start_time And datetime_from < ot_end_time) Or (datetime_to > ot_start_time And datetime_to < ot_end_time)) Or ((ot_start_time = datetime_from And ot_end_time = datetime_to)) Then
                        whereNotInclude += FormEmpOvertimeDet.GVEmployee.GetRowCellValue(i, "id_employee").ToString + ", "
                    End If

                    date_from_temp = date_from_temp.AddDays(1)
                End While
            End If
        Next

        Return whereNotInclude
    End Function

    Function dateIncludeDb(date_from As Date, date_to As Date, time_from As DateTime, time_to As DateTime) As String
        Dim whereNotInclude As String = ""

        Dim whereDate As String = ""

        While date_from <= date_to
            Dim datetime_from As DateTime = Date.Parse(date_from.ToString("yyyy-MM-dd") + " " + time_from.ToString("HH:mm:ss"))
            Dim datetime_to As DateTime = Date.Parse(date_from.ToString("yyyy-MM-dd") + " " + time_to.ToString("HH:mm:ss"))

            If datetime_to < datetime_from Then
                datetime_to.AddDays(1)
            End If

            whereDate += "((('" + datetime_from.ToString("yyyy-MM-dd HH:mm:ss") + "' > ot_det.ot_start_time AND '" + datetime_from.ToString("yyyy-MM-dd HH:mm:ss") + "' < ot_det.ot_end_time) OR ('" + datetime_to.ToString("yyyy-MM-dd HH:mm:ss") + "' > ot_det.ot_start_time AND  '" + datetime_to.ToString("yyyy-MM-dd HH:mm:ss") + "' < ot_det.ot_end_time)) OR ((ot_det.ot_start_time > '" + datetime_from.ToString("yyyy-MM-dd HH:mm:ss") + "' AND ot_det.ot_start_time < '" + datetime_to.ToString("yyyy-MM-dd HH:mm:ss") + "') OR (ot_det.ot_end_time > '" + datetime_from.ToString("yyyy-MM-dd HH:mm:ss") + "' AND ot_det.ot_end_time < '" + datetime_to.ToString("yyyy-MM-dd HH:mm:ss") + "')) OR (ot_det.ot_start_time = '" + datetime_from.ToString("yyyy-MM-dd HH:mm:ss") + "' AND ot_det.ot_end_time = '" + datetime_to.ToString("yyyy-MM-dd HH:mm:ss") + "')) OR "

            date_from = date_from.AddDays(1)
        End While

        whereDate = whereDate.Substring(0, whereDate.Length - 4)

        'not include employee from other propose
        Dim query_not_include As String = "
            SELECT ot_det.id_employee
            FROM tb_ot_det AS ot_det
            LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
            WHERE ot.id_report_status <> 5
	            AND (" + whereDate + ")
        "

        Dim data_not_include As DataTable = execute_query(query_not_include, -1, True, "", "", "", "")

        For i = 0 To data_not_include.Rows.Count - 1
            whereNotInclude += data_not_include.Rows(i)("id_employee").ToString + ", "
        Next

        Return whereNotInclude
    End Function

    Private Sub CESelectAll_EditValueChanged(sender As Object, e As EventArgs) Handles CESelectAll.EditValueChanged
        For i = 0 To GVList.RowCount - 1
            If GVList.IsValidRowHandle(i) Then
                If CESelectAll.EditValue Then
                    GVList.SetRowCellValue(i, "is_checked", "yes")
                Else
                    GVList.SetRowCellValue(i, "is_checked", "no")
                End If
            End If
        Next
    End Sub
End Class