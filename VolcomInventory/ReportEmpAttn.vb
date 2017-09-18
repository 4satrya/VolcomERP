Public Class ReportEmpAttn
    Public Shared id_dept As String = "-1"

    Public Shared date_label As String = ""
    Public Shared dept_label As String = ""

    Sub load_report()
        Dim dept As String

        If id_dept = "0" Then
            dept = "%%"
        Else
            dept = id_dept
        End If

        Dim query As String = ""
        query = "SELECT tb.*,(tb.over-tb.late-tb.over_break) AS balance,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),'Yes','No') AS present FROM"
        query += " ("
        query += " SELECT sch.id_schedule,lvl.employee_level,emp.employee_position,ket.id_leave_type,ket.leave_type,sch.info_leave,active.employee_active,active.id_employee_active,sch.id_employee,emp.employee_name,emp.employee_code,emp.id_departement,dept.departement,sch.date, "
        query += " sch.in,sch.in_tolerance,MIN(at_in.datetime) As `att_in`, "
        query += " sch.out,MAX(at_out.datetime) AS `att_out`, "
        query += " sch.break_out,MIN(at_brout.datetime) As start_break, "
        query += " sch.break_in,MAX(at_brin.datetime) AS end_break, "
        query += " scht.schedule_type,note ,"
        query += " IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) AS late ,"
        query += " IF(TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,lv.minutes_total+60))<-(sch.out_tolerance),TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,lv.minutes_total+60)),TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,lv.minutes_total+60))) AS over,"
        query += " IF(TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))>TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),"
        query += " TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))-TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),0) As over_break ,"
        query += " TIMESTAMPDIFF(MINUTE,MIN(at_in.datetime),MAX(at_out.datetime)) AS actual_work_hour ,"
        query += " TIMESTAMPDIFF(MINUTE,If(MIN(at_in.datetime)<sch.In,sch.In,If(MIN(at_in.datetime)<sch.in_tolerance,sch.In,MIN(at_in.datetime))),If(MAX(at_out.datetime)>sch.out,sch.out,MAX(at_out.datetime))) As work_hour "
        query += " FROM tb_emp_schedule sch "
        query += " LEFT JOIN tb_lookup_leave_type ket ON ket.id_leave_type=sch.id_leave_type "
        query += " INNER JOIN tb_m_employee emp On emp.id_employee=sch.id_employee "
        query += " INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level "
        query += " INNER JOIN tb_m_departement dept On dept.id_departement=emp.id_departement "
        query += " INNER JOIN tb_lookup_schedule_type scht On scht.id_schedule_type=sch.id_schedule_type "
        query += " INNER JOIN tb_lookup_employee_active active on emp.id_employee_active=active.id_employee_active"
        query += " LEFT JOIN tb_emp_attn at_in ON at_in.id_employee = sch.id_employee AND (at_in.datetime>=(sch.out - INTERVAL 1 DAY) AND at_in.datetime<=sch.out) AND at_in.type_log = 1 "
        query += " LEFT JOIN tb_emp_attn at_out ON at_out.id_employee = sch.id_employee AND (at_out.datetime>=sch.in AND at_out.datetime<=(sch.in + INTERVAL 1 DAY)) AND at_out.type_log = 2 "
        query += " LEFT JOIN tb_emp_attn at_brout On at_brout.id_employee=sch.id_employee And Date(at_brout.datetime) = sch.Date And at_brout.type_log = 3 "
        query += " LEFT JOIN tb_emp_attn at_brin On at_brin.id_employee=sch.id_employee And Date(at_brin.datetime) = sch.Date And at_brin.type_log = 4 "
        query += " WHERE emp.id_departement Like '" & dept & "' AND emp.id_employee_active='1'"
        'this is last week from monday till sunday
        query += " AND YEARWEEK(sch.`date`,1) = YEARWEEK(NOW(),1) - 1"
        '
        query += " GROUP BY sch.id_schedule"
        query += " ) tb"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSchedule.DataSource = data
        GVSchedule.BestFitColumns()
        GVSchedule.ExpandAllGroups()
        '
        If id_dept = "0" Then
            LDept.Text = "All Departement"
        Else
            Dim query_labelx As String = "SELECT departement FROM tb_m_departement WHERE id_departement='" & id_dept & "'"
            Dim data_labelx As DataTable = execute_query(query_labelx, -1, True, "", "", "", "")
            '
            LDept.Text = data_labelx.Rows(0)("departement").ToString
            '
        End If

        Dim query_label As String = "SELECT DATE_SUB(DATE(NOW()), INTERVAL DAYOFWEEK(NOW())+5 DAY) AS mon_last_week,DATE_SUB(DATE(NOW()), INTERVAL DAYOFWEEK(NOW())-1 DAY) AS sun_last_week;"
        Dim data_label As DataTable = execute_query(query_label, -1, True, "", "", "", "")

        LDateRange.Text = Date.Parse(data_label.Rows(0)("mon_last_week").ToString).ToString("dd MMMM yyyy") & " until " & Date.Parse(data_label.Rows(0)("sun_last_week").ToString).ToString("dd MMMM yyyy")
    End Sub

    Private Sub ReportEmpAttn_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        load_report()
    End Sub
End Class