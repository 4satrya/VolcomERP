Public Class FormEmpAttnSum
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public view_one_dept As Boolean = False
    Public view_store As Boolean = False

    Sub load_report(ByVal opt As String)
        Dim date_start, date_until, dept, status, employee As String

        date_start = Date.Parse(DEStartSum.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntilSum.EditValue.ToString).ToString("yyyy-MM-dd")

        If LEDeptSum.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDeptSum.EditValue.ToString
        End If

        If LEEmployeeStatus.EditValue.ToString = "0" Then
            status = "%%"
        Else
            status = LEEmployeeStatus.EditValue.ToString
        End If

        If SLUEEmployee.EditValue.ToString = "0" Then
            employee = "%%"
        Else
            employee = SLUEEmployee.EditValue.ToString
        End If

        Dim query As String = "SELECT tb.*,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),(tb.minutes_work-tb.over_break-tb.late+IF(tb.over<0,tb.over,0)),0) AS work_hour,(tb.over-tb.late-tb.over_break) AS balance,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),1,0) AS present FROM
                                (
                                 SELECT sch.id_schedule,lvl.employee_level,emp.employee_position,ket.id_leave_type,ket.leave_type,sch.info_leave,active.employee_active,active.id_employee_active,sch.id_employee,emp.employee_name,emp.employee_code,emp.id_departement,dept.departement,sch.date, 
                                 sch.in,sch.in_tolerance,
                                 IF(sch.id_schedule_type='1',MIN(at_in.datetime),MIN(at_in_hol.datetime)) AS `att_in`, 
                                 sch.out,
                                 IF(sch.id_schedule_type='1',MAX(at_out.datetime),MAX(at_out_hol.datetime)) AS `att_out`, 
                                 sch.break_out,MIN(at_brout.datetime) AS start_break, 
                                 sch.break_in,MAX(at_brin.datetime) AS end_break, 
                                 scht.id_schedule_type,
                                 scht.schedule_type,note ,
                                 sch.minutes_work,
                                 IF(IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) - IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_until=sch.out,0,IF(lv.id_leave_type=5 OR lv.id_leave_type=6,lv.minutes_total,lv.minutes_total+60)))<0,0,IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) - IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_until=sch.out,0,IF(lv.id_leave_type=5 OR lv.id_leave_type=6,lv.minutes_total,lv.minutes_total+60)))) AS late ,
                                 IF(TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,IF(lv.id_leave_type=5 OR lv.id_leave_type=6,lv.minutes_total,lv.minutes_total+60)))<-(sch.out_tolerance),TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,IF(lv.id_leave_type=5 OR lv.id_leave_type=6,lv.minutes_total,lv.minutes_total+60))),TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,IF(lv.id_leave_type=5 OR lv.id_leave_type=6,lv.minutes_total,lv.minutes_total+60)))) AS over,
                                 IF(TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))>TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),
                                 TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))-TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),0) AS over_break ,
                                 TIMESTAMPDIFF(MINUTE,IF(sch.id_schedule_type='1',MIN(at_in.datetime),MIN(at_in_hol.datetime)) ,IF(sch.id_schedule_type='1',MAX(at_out.datetime),MAX(at_out_hol.datetime))) AS actual_work_hour 
                                FROM tb_emp_schedule sch 
                                LEFT JOIN
                                (
                                    SELECT eld.*,el.`id_leave_type` FROM tb_emp_leave_det eld
                                    INNER JOIN tb_emp_leave el ON el.id_emp_leave=eld.id_emp_leave
                                    WHERE el.id_report_status='6' 
                                    GROUP BY eld.id_schedule
                                ) lv ON lv.id_schedule=sch.id_schedule
                                LEFT JOIN tb_lookup_leave_type ket ON ket.id_leave_type=sch.id_leave_type 
                                INNER JOIN tb_m_employee emp ON emp.id_employee=sch.id_employee "
        If opt = "pic" Then
            query += " INNER JOIN 
                    (
	                    SELECT emp.id_employee
	                    FROM tb_m_departement dep
	                    INNER JOIN tb_m_user usr ON usr.id_user=dep.id_user_head OR usr.id_user=dep.`id_user_asst_head`
	                    INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee
	                    WHERE dep.is_office_dept='1'
	                    UNION
	                    SELECT id_employee FROM tb_emp_attn_spec
	                    GROUP BY id_employee
                    ) dept_head ON dept_head.id_employee=emp.id_employee "
        End If
        query += "INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level 
                                INNER JOIN tb_m_departement dept ON dept.id_departement=emp.id_departement 
                                INNER JOIN tb_lookup_schedule_type scht ON scht.id_schedule_type=sch.id_schedule_type 
                                INNER JOIN tb_lookup_employee_active active ON emp.id_employee_active=active.id_employee_active
                                LEFT JOIN tb_emp_attn at_in ON at_in.id_employee = sch.id_employee AND (at_in.datetime>=(sch.out - INTERVAL 1 DAY) AND at_in.datetime<=sch.out) AND at_in.type_log = 1 
                                LEFT JOIN tb_emp_attn at_out ON at_out.id_employee = sch.id_employee AND (at_out.datetime>=sch.in AND at_out.datetime<=(sch.in + INTERVAL 1 DAY)) AND at_out.type_log = 2 
                                LEFT JOIN tb_emp_attn at_brout ON at_brout.id_employee=sch.id_employee AND DATE(at_brout.datetime) = sch.Date AND at_brout.type_log = 3 
                                LEFT JOIN tb_emp_attn at_brin ON at_brin.id_employee=sch.id_employee AND DATE(at_brin.datetime) = sch.Date AND at_brin.type_log = 4
                                LEFT JOIN tb_emp_attn at_in_hol ON at_in_hol.id_employee = sch.id_employee AND DATE(at_in_hol.datetime) = sch.Date AND at_in_hol.type_log = 1 
                                LEFT JOIN tb_emp_attn at_out_hol ON at_out_hol.id_employee = sch.id_employee AND DATE(at_out_hol.datetime) = sch.Date AND at_out_hol.type_log = 2   
                                WHERE emp.id_departement Like '" & dept & "'
                                AND sch.date >='" & date_start & "'
                                AND sch.date <='" & date_until & "'
                                AND emp.id_employee_active LIKE '" & status & "' AND emp.id_employee LIKE '" & employee & "'
                                GROUP BY sch.id_schedule
                                ) tb"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSchedule.DataSource = data
        GVSchedule.BestFitColumns()
        GVSchedule.ExpandAllGroups()
    End Sub
    Sub load_report_dep_head_pic()
        Dim date_start, date_until, dept, status As String

        date_start = Date.Parse(DEStartSum.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntilSum.EditValue.ToString).ToString("yyyy-MM-dd")

        If LEDeptSum.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDeptSum.EditValue.ToString
        End If

        If LEEmployeeStatus.EditValue.ToString = "0" Then
            status = "%%"
        Else
            status = LEEmployeeStatus.EditValue.ToString
        End If

        Dim query As String = "SELECT tb.*,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),(tb.minutes_work-tb.over_break-tb.late+IF(tb.over<0,tb.over,0)),0) AS work_hour,(tb.over-tb.late-tb.over_break) AS balance,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),1,0) AS present FROM
                                (
                                 SELECT sch.id_schedule,lvl.employee_level,emp.employee_position,ket.id_leave_type,ket.leave_type,sch.info_leave,active.employee_active,active.id_employee_active,sch.id_employee,emp.employee_name,emp.employee_code,emp.id_departement,dept.departement,sch.date, 
                                 sch.in,sch.in_tolerance,
                                 IF(sch.id_schedule_type='1',MIN(at_in.datetime),MIN(at_in_hol.datetime)) AS `att_in`, 
                                 sch.out,
                                 IF(sch.id_schedule_type='1',MAX(at_out.datetime),MAX(at_out_hol.datetime)) AS `att_out`, 
                                 sch.break_out,MIN(at_brout.datetime) AS start_break, 
                                 sch.break_in,MAX(at_brin.datetime) AS end_break, 
                                 scht.id_schedule_type,
                                 scht.schedule_type,note ,
                                 sch.minutes_work,
                                 IF(IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) - IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_until=sch.out,0,lv.minutes_total+60))<0,0,IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) - IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_until=sch.out,0,lv.minutes_total+60))) AS late ,
                                 IF(TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,lv.minutes_total+60))<-(sch.out_tolerance),TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,lv.minutes_total+60)),TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,lv.minutes_total+60))) AS over,
                                 IF(TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))>TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),
                                 TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))-TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),0) AS over_break ,
                                 TIMESTAMPDIFF(MINUTE,IF(sch.id_schedule_type='1',MIN(at_in.datetime),MIN(at_in_hol.datetime)) ,IF(sch.id_schedule_type='1',MAX(at_out.datetime),MAX(at_out_hol.datetime))) AS actual_work_hour 
                                FROM tb_emp_schedule sch 
                                LEFT JOIN
                                (
                                    SELECT eld.* FROM tb_emp_leave_det eld
                                    INNER JOIN tb_emp_leave el ON el.id_emp_leave=eld.id_emp_leave
                                    WHERE el.id_report_status='6' 
                                    GROUP BY eld.id_schedule 
                                ) lv ON lv.id_schedule=sch.id_schedule
                                LEFT JOIN tb_lookup_leave_type ket ON ket.id_leave_type=sch.id_leave_type 
                                INNER JOIN tb_m_employee emp ON emp.id_employee=sch.id_employee 
                                INNER JOIN 
                                (
	                                SELECT emp.id_employee
	                                FROM tb_m_departement dep
	                                INNER JOIN tb_m_user usr ON usr.id_user=dep.id_user_head OR usr.id_user=dep.`id_user_asst_head`
	                                INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee
	                                WHERE dep.is_office_dept='1'
	                                UNION
	                                SELECT id_employee FROM tb_emp_attn_spec
	                                GROUP BY id_employee
                                ) dept_head ON dept_head.id_employee=emp.id_employee
                                INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level 
                                INNER JOIN tb_m_departement dept ON dept.id_departement=emp.id_departement 
                                INNER JOIN tb_lookup_schedule_type scht ON scht.id_schedule_type=sch.id_schedule_type 
                                INNER JOIN tb_lookup_employee_active active ON emp.id_employee_active=active.id_employee_active
                                LEFT JOIN tb_emp_attn at_in ON at_in.id_employee = sch.id_employee AND (at_in.datetime>=(sch.out - INTERVAL 1 DAY) AND at_in.datetime<=sch.out) AND at_in.type_log = 1 
                                LEFT JOIN tb_emp_attn at_out ON at_out.id_employee = sch.id_employee AND (at_out.datetime>=sch.in AND at_out.datetime<=(sch.in + INTERVAL 1 DAY)) AND at_out.type_log = 2 
                                LEFT JOIN tb_emp_attn at_brout ON at_brout.id_employee=sch.id_employee AND DATE(at_brout.datetime) = sch.Date AND at_brout.type_log = 3 
                                LEFT JOIN tb_emp_attn at_brin ON at_brin.id_employee=sch.id_employee AND DATE(at_brin.datetime) = sch.Date AND at_brin.type_log = 4
                                LEFT JOIN tb_emp_attn at_in_hol ON at_in_hol.id_employee = sch.id_employee AND DATE(at_in_hol.datetime) = sch.Date AND at_in_hol.type_log = 1 
                                LEFT JOIN tb_emp_attn at_out_hol ON at_out_hol.id_employee = sch.id_employee AND DATE(at_out_hol.datetime) = sch.Date AND at_out_hol.type_log = 2   
                                WHERE emp.id_departement Like '" & dept & "'
                                AND sch.date >='" & date_start & "'
                                AND sch.date <='" & date_until & "'
                                AND emp.id_employee_active LIKE '" & status & "'
                                GROUP BY sch.id_schedule
                                ) tb"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSchedule.DataSource = data
        GVSchedule.BestFitColumns()
        GVSchedule.ExpandAllGroups()
    End Sub
    Sub load_report_schedule(ByVal opt As String)
        Dim date_start, date_until, dept, status, employee As String

        date_start = Date.Parse(DEStartSum.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntilSum.EditValue.ToString).ToString("yyyy-MM-dd")

        If LEDeptSum.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDeptSum.EditValue.ToString
        End If

        If LEEmployeeStatus.EditValue.ToString = "0" Then
            status = "%%"
        Else
            status = LEEmployeeStatus.EditValue.ToString
        End If

        If SLUEEmployee.EditValue.ToString = "0" Then
            employee = "%%"
        Else
            employee = SLUEEmployee.EditValue.ToString
        End If

        Dim query As String = "SELECT tb.*,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),(tb.minutes_work-tb.over_break-tb.late+IF(tb.over<0,tb.over,0)),0) AS work_hour,(tb.over-tb.late-tb.over_break) AS balance,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),1,0) AS present FROM
                                (
                                 SELECT sch.id_schedule,lvl.employee_level,emp.employee_position,ket.id_leave_type,ket.leave_type,sch.info_leave,active.employee_active,active.id_employee_active,sch.id_employee,emp.employee_name,emp.employee_code,emp.id_departement,dept.departement,sch.date, 
                                 sch.in,sch.in_tolerance,IF(sch.id_schedule_type='1',MIN(at_in.datetime),MIN(at_in_hol.datetime)) AS `att_in`, 
                                 sch.out, IF(sch.id_schedule_type='1',MAX(at_out.datetime),MAX(at_out_hol.datetime)) AS `att_out`, 
                                 sch.break_out,MIN(at_brout.datetime) AS start_break, 
                                 sch.break_in,MAX(at_brin.datetime) AS end_break, 
                                 scht.schedule_type,note ,
                                 sch.minutes_work,sch.out_tolerance,
                                 IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) AS late ,
                                 TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) AS over ,
                                IF(TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))>TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),
                                TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))-TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),0) AS over_break ,
                                TIMESTAMPDIFF(MINUTE,MIN(at_in.datetime),MAX(at_out.datetime)) AS actual_work_hour 
                                FROM tb_emp_schedule sch 
                                LEFT JOIN tb_lookup_leave_type ket ON ket.id_leave_type=sch.id_leave_type 
                                INNER JOIN tb_m_employee emp ON emp.id_employee=sch.id_employee "
        If opt = "pic" Then
            query += " INNER JOIN 
                    (
	                    SELECT emp.id_employee
	                    FROM tb_m_departement dep
	                    INNER JOIN tb_m_user usr ON usr.id_user=dep.id_user_head OR usr.id_user=dep.`id_user_asst_head`
	                    INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee
	                    WHERE dep.is_office_dept='1'
	                    UNION
	                    SELECT id_employee FROM tb_emp_attn_spec
	                    GROUP BY id_employee
                    ) dept_head ON dept_head.id_employee=emp.id_employee "
        End If
        query += "INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level 
                                INNER JOIN tb_m_departement dept ON dept.id_departement=emp.id_departement 
                                INNER JOIN tb_lookup_schedule_type scht ON scht.id_schedule_type=sch.id_schedule_type 
                                INNER JOIN tb_lookup_employee_active active ON emp.id_employee_active=active.id_employee_active
                                LEFT JOIN tb_emp_attn at_in ON at_in.id_employee = sch.id_employee AND (at_in.datetime>=(sch.out - INTERVAL 1 DAY) AND at_in.datetime<=sch.out) AND at_in.type_log = 1 
                                LEFT JOIN tb_emp_attn at_out ON at_out.id_employee = sch.id_employee AND (at_out.datetime>=sch.in AND at_out.datetime<=(sch.in + INTERVAL 1 DAY)) AND at_out.type_log = 2 
                                LEFT JOIN tb_emp_attn at_brout ON at_brout.id_employee=sch.id_employee AND DATE(at_brout.datetime) = sch.Date AND at_brout.type_log = 3 
                                LEFT JOIN tb_emp_attn at_brin ON at_brin.id_employee=sch.id_employee AND DATE(at_brin.datetime) = sch.Date AND at_brin.type_log = 4 
                                LEFT JOIN tb_emp_attn at_in_hol ON at_in_hol.id_employee = sch.id_employee AND DATE(at_in_hol.datetime) = sch.Date AND at_in_hol.type_log = 1 
                                LEFT JOIN tb_emp_attn at_out_hol ON at_out_hol.id_employee = sch.id_employee AND DATE(at_out_hol.datetime) = sch.Date AND at_out_hol.type_log = 2
                                WHERE emp.id_departement Like '" & dept & "'
                                AND sch.date >='" & date_start & "'
                                AND sch.date <='" & date_until & "'
                                AND emp.id_employee_active LIKE '" & status & "' AND emp.id_employee LIKE '" & employee & "'
                                GROUP BY sch.id_schedule
                                ) tb"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListSchedule.DataSource = data
        GVListSchedule.BestFitColumns()
        GVListSchedule.ExpandAllGroups()
    End Sub
    Sub load_report_schedule_head_pic()
        Dim date_start, date_until, dept, status As String

        date_start = Date.Parse(DEStartSum.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntilSum.EditValue.ToString).ToString("yyyy-MM-dd")

        If LEDeptSum.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDeptSum.EditValue.ToString
        End If

        If LEEmployeeStatus.EditValue.ToString = "0" Then
            status = "%%"
        Else
            status = LEEmployeeStatus.EditValue.ToString
        End If

        Dim query As String = "SELECT tb.*,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),(tb.minutes_work-tb.over_break-tb.late+IF(tb.over<0,tb.over,0)),0) AS work_hour,(tb.over-tb.late-tb.over_break) AS balance,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),1,0) AS present FROM
                                (
                                 SELECT sch.id_schedule,lvl.employee_level,emp.employee_position,ket.id_leave_type,ket.leave_type,sch.info_leave,active.employee_active,active.id_employee_active,sch.id_employee,emp.employee_name,emp.employee_code,emp.id_departement,dept.departement,sch.date, 
                                 sch.in,sch.in_tolerance,IF(sch.id_schedule_type='1',MIN(at_in.datetime),MIN(at_in_hol.datetime)) AS `att_in`, 
                                 sch.out, IF(sch.id_schedule_type='1',MAX(at_out.datetime),MAX(at_out_hol.datetime)) AS `att_out`, 
                                 sch.break_out,MIN(at_brout.datetime) AS start_break, 
                                 sch.break_in,MAX(at_brin.datetime) AS end_break, 
                                 scht.schedule_type,note ,
                                 sch.minutes_work,sch.out_tolerance,
                                 IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) AS late ,
                                 TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) AS over ,
                                IF(TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))>TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),
                                TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))-TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),0) AS over_break ,
                                TIMESTAMPDIFF(MINUTE,MIN(at_in.datetime),MAX(at_out.datetime)) AS actual_work_hour 
                                FROM tb_emp_schedule sch 
                                LEFT JOIN tb_lookup_leave_type ket ON ket.id_leave_type=sch.id_leave_type 
                                INNER JOIN tb_m_employee emp ON emp.id_employee=sch.id_employee 
                                INNER JOIN 
                                (
	                                SELECT emp.id_employee
	                                FROM tb_m_departement dep
	                                INNER JOIN tb_m_user usr ON usr.id_user=dep.id_user_head OR usr.id_user=dep.`id_user_asst_head`
	                                INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee
	                                WHERE dep.is_office_dept='1'
	                                UNION
	                                SELECT id_employee FROM tb_emp_attn_spec
	                                GROUP BY id_employee
                                ) dept_head ON dept_head.id_employee=emp.id_employee
                                INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level 
                                INNER JOIN tb_m_departement dept ON dept.id_departement=emp.id_departement 
                                INNER JOIN tb_lookup_schedule_type scht ON scht.id_schedule_type=sch.id_schedule_type 
                                INNER JOIN tb_lookup_employee_active active ON emp.id_employee_active=active.id_employee_active
                                LEFT JOIN tb_emp_attn at_in ON at_in.id_employee = sch.id_employee AND (at_in.datetime>=(sch.out - INTERVAL 1 DAY) AND at_in.datetime<=sch.out) AND at_in.type_log = 1 
                                LEFT JOIN tb_emp_attn at_out ON at_out.id_employee = sch.id_employee AND (at_out.datetime>=sch.in AND at_out.datetime<=(sch.in + INTERVAL 1 DAY)) AND at_out.type_log = 2 
                                LEFT JOIN tb_emp_attn at_brout ON at_brout.id_employee=sch.id_employee AND DATE(at_brout.datetime) = sch.Date AND at_brout.type_log = 3 
                                LEFT JOIN tb_emp_attn at_brin ON at_brin.id_employee=sch.id_employee AND DATE(at_brin.datetime) = sch.Date AND at_brin.type_log = 4 
                                LEFT JOIN tb_emp_attn at_in_hol ON at_in_hol.id_employee = sch.id_employee AND DATE(at_in_hol.datetime) = sch.Date AND at_in_hol.type_log = 1 
                                LEFT JOIN tb_emp_attn at_out_hol ON at_out_hol.id_employee = sch.id_employee AND DATE(at_out_hol.datetime) = sch.Date AND at_out_hol.type_log = 2
                                WHERE emp.id_departement Like '" & dept & "'
                                AND sch.date >='" & date_start & "'
                                AND sch.date <='" & date_until & "'
                                AND emp.id_employee_active LIKE '" & status & "'
                                GROUP BY sch.id_schedule
                                ) tb"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListSchedule.DataSource = data
        GVListSchedule.BestFitColumns()
        GVListSchedule.ExpandAllGroups()
    End Sub
    Private Sub FormEmpAttnSum_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpAttnSum_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpAttnSum_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpAttnSum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each t As DevExpress.XtraTab.XtraTabPage In XTCReportAttendance.TabPages
            XTCReportAttendance.SelectedTabPage = t
        Next t
        XTCReportAttendance.SelectedTabPage = XTCReportAttendance.TabPages(0)

        viewDept()
        viewStatus()
        viewEmployee()
        DEStartSum.EditValue = Now
        DEUntilSum.EditValue = Now
        '
        'If view_one_dept Or view_store Then
        '    SMEditKet.Visible = False
        'Else
        '    SMEditKet.Visible = True
        'End If
    End Sub

    Sub viewDept()
        Dim query As String = ""
        If view_one_dept Then
            query += "(SELECT id_departement,departement FROM tb_m_departement a WHERE id_departement='" + id_departement_user + "' ORDER BY a.departement ASC) "
        ElseIf view_store Then
            query += "(SELECT id_departement,departement FROM tb_m_departement a WHERE is_store='1' ORDER BY a.departement ASC) "
        Else
            query += "SELECT 0 as id_departement, 'All departement' as departement UNION  "
            query += "(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        End If
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
    End Sub
    Sub viewStatus()
        Dim query As String = ""
        query += "SELECT 0 as id_employee_active, 'All employee' as employee_active UNION  "
        query += "(SELECT id_employee_active,employee_active FROM `tb_lookup_employee_active`) "
        viewLookupQuery(LEEmployeeStatus, query, 0, "employee_active", "id_employee_active")
        LEEmployeeStatus.ItemIndex = LEEmployeeStatus.Properties.GetDataSourceRowIndex("id_employee_active", "1")
        If view_one_dept = True Or view_store = True Then
            LEEmployeeStatus.ReadOnly = True
        Else
            LEEmployeeStatus.ReadOnly = False
        End If
    End Sub
    Sub viewEmployee()
        Dim query As String = ""
        If view_one_dept Then
            query += "SELECT 0 AS id_employee, '' AS employee_code, 'All employee' AS employee_name, 0 AS id_departement, 0 AS id_employee_active UNION (SELECT e.id_employee, e.employee_code, e.employee_name, e.id_departement, e.id_employee_active FROM tb_m_employee e LEFT JOIN tb_m_departement d ON e.id_departement = d.id_departement WHERE e.id_departement = " + id_departement_user + " ORDER BY e.employee_name)"
        ElseIf view_store Then
            query += "SELECT 0 AS id_employee, '' AS employee_code, 'All employee' AS employee_name, 0 AS id_departement, 0 AS id_employee_active UNION (SELECT e.id_employee, e.employee_code, e.employee_name, e.id_departement, e.id_employee_active FROM tb_m_employee e LEFT JOIN tb_m_departement d ON e.id_departement = d.id_departement WHERE d.is_store = 1 ORDER BY e.employee_name)"
        Else
            query += "SELECT 0 AS id_employee, '' AS employee_code, 'All employee' AS employee_name, 0 AS id_departement, 0 AS id_employee_active UNION (SELECT e.id_employee, e.employee_code, e.employee_name, e.id_departement, e.id_employee_active FROM tb_m_employee e LEFT JOIN tb_m_departement d ON e.id_departement = d.id_departement ORDER BY e.employee_name)"
        End If
        viewSearchLookupQuery(SLUEEmployee, query, "id_employee", "employee_name", "id_employee")
    End Sub
    Private Sub BViewSum_Click(sender As Object, e As EventArgs) Handles BViewSum.Click
        Cursor = Cursors.WaitCursor
        If XTCReportAttendance.SelectedTabPageIndex = 0 Then
            load_report_sum("")
        ElseIf XTCReportAttendance.SelectedTabPageIndex = 1 Then
            load_report("")
        ElseIf XTCReportAttendance.SelectedTabPageIndex = 2 Then
            load_report_schedule("")
        ElseIf XTCReportAttendance.SelectedTabPageIndex = 3 Then
            load_schedule_table()
        ElseIf XTCReportAttendance.SelectedTabPageIndex = 4 Then
            load_report_sum_month("")
        End If
        Cursor = Cursors.Default
    End Sub

    Sub load_schedule_table()
        Dim startP As Date = Date.Parse(DEStartSum.EditValue.ToString)
        Dim endP As Date = Date.Parse(DEUntilSum.EditValue.ToString)
        Dim curD As Date = startP
        Dim string_date As String = ""
        Dim dept As String = ""
        Dim status As String = ""
        Dim employee As String = ""

        If LEDeptSum.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDeptSum.EditValue.ToString
        End If

        If LEEmployeeStatus.EditValue.ToString = "0" Then
            status = "%%"
        Else
            status = LEEmployeeStatus.EditValue.ToString
        End If

        If SLUEEmployee.EditValue.ToString = "0" Then
            employee = "%%"
        Else
            employee = SLUEEmployee.EditValue.ToString
        End If

        Dim query As String = "SELECT * FROM tb_m_employee WHERE id_departement LIKE '" & dept & "' AND id_employee_active LIKE '" & status & "' AND id_employee LIKE '" & employee & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GVScheduleTable.Columns.Clear()

        If data.Rows.Count > 0 Then
            '
            GVScheduleTable.Columns.AddVisible("id_employee", "ID")
            GVScheduleTable.Columns("id_employee").OptionsColumn.AllowEdit = False
            GVScheduleTable.Columns("id_employee").Visible = False

            GVScheduleTable.Columns.AddVisible("employee_code", "NIP")
            GVScheduleTable.Columns("employee_code").OptionsColumn.AllowEdit = False
            GVScheduleTable.Columns("employee_code").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            GVScheduleTable.Columns.AddVisible("employee_name", "Name")
            GVScheduleTable.Columns("employee_name").OptionsColumn.AllowEdit = False
            GVScheduleTable.Columns("employee_name").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            While (curD <= endP)
                GVScheduleTable.Columns.AddVisible(curD.ToString("yyyy-MM-dd"), curD.ToString("dddd, dd MMM yyyy"))

                If curD.DayOfWeek = DayOfWeek.Saturday Or curD.DayOfWeek = DayOfWeek.Sunday Then
                    GVScheduleTable.Columns(curD.ToString("yyyy-MM-dd")).AppearanceCell.BackColor = Color.Pink
                ElseIf check_public_holiday(curD) = "1" Then
                    GVScheduleTable.Columns(curD.ToString("yyyy-MM-dd")).AppearanceCell.BackColor = Color.Red
                End If

                string_date += ",'" & curD.ToString("yyyy-MM-dd") & "'"
                curD = curD.AddDays(1)
            End While
            '
            Dim query_x As String = "SELECT '' as id_employee,'' as employee_code,'' as employee_name" & string_date
            Dim data_x As DataTable = execute_query(query_x, -1, True, "", "", "", "")
            GCScheduleTable.DataSource = data_x
            GVScheduleTable.DeleteRow(0)
            '
            For i As Integer = 0 To data.Rows.Count - 1
                Dim query_emp As String = "SELECT emp.date,IFNULL(t.leave_type,emp.shift_code) AS shift_code FROM tb_emp_schedule emp LEFT JOIN tb_lookup_leave_type t ON t.id_leave_type=emp.id_leave_type WHERE emp.id_employee='" & data.Rows(i)("id_employee").ToString & "' AND emp.date >= '" & startP.ToString("yyyy-MM-dd") & "' AND emp.date <= '" & endP.ToString("yyyy-MM-dd") & "'"
                Dim data_emp As DataTable = execute_query(query_emp, -1, True, "", "", "", "")

                Dim newRow As DataRow = (TryCast(GCScheduleTable.DataSource, DataTable)).NewRow()
                newRow("id_employee") = data.Rows(i)("id_employee").ToString
                newRow("employee_code") = data.Rows(i)("employee_code").ToString
                newRow("employee_name") = data.Rows(i)("employee_name").ToString
                If data_emp.Rows.Count > 0 Then
                    For j As Integer = 0 To data_emp.Rows.Count - 1
                        newRow(Date.Parse(data_emp.Rows(j)("date").ToString).ToString("yyyy-MM-dd")) = data_emp.Rows(j)("shift_code").ToString.ToUpper
                    Next
                End If

                TryCast(GCScheduleTable.DataSource, DataTable).Rows.Add(newRow)
                GCScheduleTable.RefreshDataSource()
            Next
            GVScheduleTable.BestFitColumns()
            GVScheduleTable.OptionsSelection.EnableAppearanceFocusedRow = False
            GVScheduleTable.OptionsSelection.EnableAppearanceFocusedCell = False
        Else
            stopCustom("Please select employee first.")
        End If

    End Sub

    Sub load_schedule_table_head_pic()
        Dim startP As Date = Date.Parse(DEStartSum.EditValue.ToString)
        Dim endP As Date = Date.Parse(DEUntilSum.EditValue.ToString)
        Dim curD As Date = startP
        Dim string_date As String = ""
        Dim dept As String = ""
        Dim status As String = ""

        If LEDeptSum.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDeptSum.EditValue.ToString
        End If

        If LEEmployeeStatus.EditValue.ToString = "0" Then
            status = "%%"
        Else
            status = LEEmployeeStatus.EditValue.ToString
        End If

        Dim query As String = "SELECT emp.* FROM tb_m_employee emp
                                INNER JOIN 
                                (
	                                SELECT emp.id_employee
	                                FROM tb_m_departement dep
	                                INNER JOIN tb_m_user usr ON usr.id_user=dep.id_user_head OR usr.id_user=dep.`id_user_asst_head`
	                                INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee
	                                WHERE dep.is_office_dept='1'
	                                UNION
	                                SELECT id_employee FROM tb_emp_attn_spec
	                                GROUP BY id_employee
                                ) dept_head ON dept_head.id_employee=emp.id_employee
                                WHERE emp.id_departement LIKE '" & dept & "' AND emp.id_employee_active LIKE '" & status & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GVScheduleTable.Columns.Clear()

        If data.Rows.Count > 0 Then
            '
            GVScheduleTable.Columns.AddVisible("id_employee", "ID")
            GVScheduleTable.Columns("id_employee").OptionsColumn.AllowEdit = False
            GVScheduleTable.Columns("id_employee").Visible = False

            GVScheduleTable.Columns.AddVisible("employee_code", "NIP")
            GVScheduleTable.Columns("employee_code").OptionsColumn.AllowEdit = False
            GVScheduleTable.Columns("employee_code").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            GVScheduleTable.Columns.AddVisible("employee_name", "Name")
            GVScheduleTable.Columns("employee_name").OptionsColumn.AllowEdit = False
            GVScheduleTable.Columns("employee_name").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            While (curD <= endP)
                GVScheduleTable.Columns.AddVisible(curD.ToString("yyyy-MM-dd"), curD.ToString("dddd, dd MMM yyyy"))

                If curD.DayOfWeek = DayOfWeek.Saturday Or curD.DayOfWeek = DayOfWeek.Sunday Then
                    GVScheduleTable.Columns(curD.ToString("yyyy-MM-dd")).AppearanceCell.BackColor = Color.Pink
                ElseIf check_public_holiday(curD) = "1" Then
                    GVScheduleTable.Columns(curD.ToString("yyyy-MM-dd")).AppearanceCell.BackColor = Color.Red
                End If

                string_date += ",'" & curD.ToString("yyyy-MM-dd") & "'"
                curD = curD.AddDays(1)
            End While
            '
            Dim query_x As String = "SELECT '' as id_employee,'' as employee_code,'' as employee_name" & string_date
            Dim data_x As DataTable = execute_query(query_x, -1, True, "", "", "", "")
            GCScheduleTable.DataSource = data_x
            GVScheduleTable.DeleteRow(0)
            '
            For i As Integer = 0 To data.Rows.Count - 1
                Dim query_emp As String = "SELECT emp.date,IFNULL(t.leave_type,emp.shift_code) AS shift_code FROM tb_emp_schedule emp LEFT JOIN tb_lookup_leave_type t ON t.id_leave_type=emp.id_leave_type WHERE emp.id_employee='" & data.Rows(i)("id_employee").ToString & "' AND emp.date >= '" & startP.ToString("yyyy-MM-dd") & "' AND emp.date <= '" & endP.ToString("yyyy-MM-dd") & "'"
                Dim data_emp As DataTable = execute_query(query_emp, -1, True, "", "", "", "")

                Dim newRow As DataRow = (TryCast(GCScheduleTable.DataSource, DataTable)).NewRow()
                newRow("id_employee") = data.Rows(i)("id_employee").ToString
                newRow("employee_code") = data.Rows(i)("employee_code").ToString
                newRow("employee_name") = data.Rows(i)("employee_name").ToString
                If data_emp.Rows.Count > 0 Then
                    For j As Integer = 0 To data_emp.Rows.Count - 1
                        newRow(Date.Parse(data_emp.Rows(j)("date").ToString).ToString("yyyy-MM-dd")) = data_emp.Rows(j)("shift_code").ToString.ToUpper
                    Next
                End If

                TryCast(GCScheduleTable.DataSource, DataTable).Rows.Add(newRow)
                GCScheduleTable.RefreshDataSource()
            Next
            GVScheduleTable.BestFitColumns()
            GVScheduleTable.OptionsSelection.EnableAppearanceFocusedRow = False
            GVScheduleTable.OptionsSelection.EnableAppearanceFocusedCell = False
        Else
            stopCustom("Please select employee first.")
        End If

    End Sub

    Function check_public_holiday(date_par As Date)
        Dim is_public_holiday = "2"

        Dim query As String = "SELECT * FROM tb_emp_holiday WHERE id_religion=0 AND emp_holiday_date='" & date_par.ToString("yyyy-MM-dd") & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            is_public_holiday = "1"
        End If

        Return is_public_holiday
    End Function

    Sub load_report_sum(ByVal opt As String)
        Dim date_start, date_until, dept, status, employee As String

        date_start = Date.Parse(DEStartSum.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntilSum.EditValue.ToString).ToString("yyyy-MM-dd")

        If LEDeptSum.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDeptSum.EditValue.ToString
        End If

        If LEEmployeeStatus.EditValue.ToString = "0" Then
            status = "%%"
        Else
            status = LEEmployeeStatus.EditValue.ToString
        End If

        If SLUEEmployee.EditValue.ToString = "0" Then
            employee = "%%"
        Else
            employee = SLUEEmployee.EditValue.ToString
        End If

        Dim query As String = ""
        query = "SELECT tb.id_schedule,tb.employee_level,tb.employee_position,tb.employee_active,tb.id_employee_active,tb.id_employee,tb.employee_name,tb.employee_code,tb.id_departement,dep.departement,SUM(tb.late) AS late,SUM(tb.early_home) AS early_home,SUM(tb.over) AS over,SUM(tb.over_break) AS over_break,
                SUM(IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),(tb.minutes_work-tb.over_break-tb.late-tb.early_home),0)) AS work_hour,
                SUM(tb.actual_work_hour) AS actual_work_hour,SUM((tb.over_break+tb.early_home)) AS total_minus,SUM(tb.over-tb.over_break-tb.late) AS balance,SUM(IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),1,0)) AS present,SUM(IF(tb.id_schedule_type=1,1,0)) AS workday 
                ,SUM(tb.tot_sick) AS tot_sick
                FROM
                (
	                SELECT sch.id_schedule_type,sch.id_schedule,lvl.employee_level,emp.employee_position,ket.id_leave_type,ket.leave_type,sch.info_leave,active.employee_active,active.id_employee_active,sch.id_employee,emp.employee_name,emp.employee_code,emp.id_departement,dept.departement,sch.date, 
	                sch.in,sch.in_tolerance,
	                IF(sch.id_schedule_type='1',MIN(at_in.datetime),MIN(at_in_hol.datetime)) AS `att_in`, 
	                sch.out,
	                IF(sch.id_schedule_type='1',MAX(at_out.datetime),MAX(at_out_hol.datetime)) AS `att_out`, 
	                sch.break_out,MIN(at_brout.datetime) AS start_break, 
	                sch.break_in,MAX(at_brin.datetime) AS end_break, 
	                scht.schedule_type,note ,
	                sch.minutes_work,
                    SUM(IF(IFNULL(lv.id_leave_type,0)=2,lv.minutes_total,0)) as tot_sick,
	                IF(IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) - IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_until=sch.out,0,lv.minutes_total+60))<0,0,IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) - IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_until=sch.out,0,lv.minutes_total+60))) AS late ,
	                IF(TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,IF(lv.id_leave_type=5 OR lv.id_leave_type=6,lv.minutes_total,lv.minutes_total+60)))<-(sch.out_tolerance),-(TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,IF(lv.id_leave_type=5 OR lv.id_leave_type=6,lv.minutes_total,lv.minutes_total+60)))),0) AS early_home ,
	                IF(TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,IF(lv.id_leave_type=5 OR lv.id_leave_type=6,lv.minutes_total,lv.minutes_total+60)))<-(sch.out_tolerance),TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,IF(lv.id_leave_type=5 OR lv.id_leave_type=6,lv.minutes_total,lv.minutes_total+60))),TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,IF(lv.id_leave_type=5 OR lv.id_leave_type=6,lv.minutes_total,lv.minutes_total+60)))) AS over,
	                IF(TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))>TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),
	                TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))-TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),0) AS over_break ,
	                TIMESTAMPDIFF(MINUTE,IF(sch.id_schedule_type='1',MIN(at_in.datetime),MIN(at_in_hol.datetime)) ,IF(sch.id_schedule_type='1',MAX(at_out.datetime),MAX(at_out_hol.datetime))) AS actual_work_hour 
	                FROM tb_emp_schedule sch 
	                LEFT JOIN
	                (
	                    SELECT eld.*,el.`id_leave_type` FROM tb_emp_leave_det eld
	                    INNER JOIN tb_emp_leave el ON el.id_emp_leave=eld.id_emp_leave
	                    WHERE el.id_report_status='6' 
	                ) lv ON lv.id_schedule=sch.id_schedule
	                LEFT JOIN tb_lookup_leave_type ket ON ket.id_leave_type=sch.id_leave_type 
	                INNER JOIN tb_m_employee emp ON emp.id_employee=sch.id_employee "
        If opt = "pic" Then
            query += " INNER JOIN 
                    (
	                    SELECT emp.id_employee
	                    FROM tb_m_departement dep
	                    INNER JOIN tb_m_user usr ON usr.id_user=dep.id_user_head OR usr.id_user=dep.`id_user_asst_head`
	                    INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee
	                    WHERE dep.is_office_dept='1'
	                    UNION
	                    SELECT id_employee FROM tb_emp_attn_spec
	                    GROUP BY id_employee
                    ) dept_head ON dept_head.id_employee=emp.id_employee "
        End If
        query += "INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level 
	                INNER JOIN tb_m_departement dept ON dept.id_departement=emp.id_departement 
	                INNER JOIN tb_lookup_schedule_type scht ON scht.id_schedule_type=sch.id_schedule_type 
	                INNER JOIN tb_lookup_employee_active active ON emp.id_employee_active=active.id_employee_active
	                LEFT JOIN tb_emp_attn at_in ON at_in.id_employee = sch.id_employee AND (at_in.datetime>=(sch.out - INTERVAL 1 DAY) AND at_in.datetime<=sch.out) AND at_in.type_log = 1 
	                LEFT JOIN tb_emp_attn at_out ON at_out.id_employee = sch.id_employee AND (at_out.datetime>=sch.in AND at_out.datetime<=(sch.in + INTERVAL 1 DAY)) AND at_out.type_log = 2 
	                LEFT JOIN tb_emp_attn at_brout ON at_brout.id_employee=sch.id_employee AND DATE(at_brout.datetime) = sch.Date AND at_brout.type_log = 3 
	                LEFT JOIN tb_emp_attn at_brin ON at_brin.id_employee=sch.id_employee AND DATE(at_brin.datetime) = sch.Date AND at_brin.type_log = 4
	                LEFT JOIN tb_emp_attn at_in_hol ON at_in_hol.id_employee = sch.id_employee AND DATE(at_in_hol.datetime) = sch.Date AND at_in_hol.type_log = 1 
	                LEFT JOIN tb_emp_attn at_out_hol ON at_out_hol.id_employee = sch.id_employee AND DATE(at_out_hol.datetime) = sch.Date AND at_out_hol.type_log = 2     
	                WHERE emp.id_departement LIKE '" & dept & "' AND sch.date >='" & date_start & "' AND sch.date <='" & date_until & "' AND emp.id_employee_active LIKE '" & status & "' AND emp.id_employee LIKE '" & employee & "'
	                GROUP BY sch.id_schedule
                )tb
                INNER JOIN tb_m_departement dep ON dep.id_departement=tb.id_departement
                GROUP BY tb.id_employee"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSum.DataSource = data
        GVSum.BestFitColumns()
        GVSum.ExpandAllGroups()
    End Sub

    Sub load_report_sum_head_pic()
        Dim date_start, date_until, dept, status As String

        date_start = Date.Parse(DEStartSum.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntilSum.EditValue.ToString).ToString("yyyy-MM-dd")

        If LEDeptSum.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDeptSum.EditValue.ToString
        End If

        If LEEmployeeStatus.EditValue.ToString = "0" Then
            status = "%%"
        Else
            status = LEEmployeeStatus.EditValue.ToString
        End If

        Dim query As String = ""
        query = "SELECT tb.id_schedule,tb.employee_level,tb.employee_position,tb.id_leave_type,tb.leave_type,tb.info_leave,tb.employee_active,tb.id_employee_active,tb.id_employee,tb.employee_name,tb.employee_code,tb.id_departement,dep.departement,SUM(tb.late) AS late,SUM(tb.over) AS over,SUM(tb.over_break) AS over_break,
                SUM(IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),(tb.minutes_work-tb.over_break-tb.late+IF(tb.over<0,tb.over,0)),0)) AS work_hour,
                SUM(tb.actual_work_hour) AS actual_work_hour,SUM((tb.over-tb.late-tb.over_break)) AS balance,SUM(IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),1,0)) AS present,SUM(IF(tb.id_schedule_type=1,1,0)) AS workday 
                FROM
                (
	                SELECT sch.id_schedule_type,sch.id_schedule,lvl.employee_level,emp.employee_position,ket.id_leave_type,ket.leave_type,sch.info_leave,active.employee_active,active.id_employee_active,sch.id_employee,emp.employee_name,emp.employee_code,emp.id_departement,dept.departement,sch.date, 
	                sch.in,sch.in_tolerance,
	                IF(sch.id_schedule_type='1',MIN(at_in.datetime),MIN(at_in_hol.datetime)) AS `att_in`, 
	                sch.out,
	                IF(sch.id_schedule_type='1',MAX(at_out.datetime),MAX(at_out_hol.datetime)) AS `att_out`, 
	                sch.break_out,MIN(at_brout.datetime) AS start_break, 
	                sch.break_in,MAX(at_brin.datetime) AS end_break, 
	                scht.schedule_type,note ,
	                sch.minutes_work,
	                IF(IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) - IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_until=sch.out,0,lv.minutes_total+60))<0,0,IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) - IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_until=sch.out,0,lv.minutes_total+60))) AS late ,
	                IF(TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,lv.minutes_total+60))<-(sch.out_tolerance),TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,lv.minutes_total+60)),0) AS over ,
	                IF(TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))>TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),
	                TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))-TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),0) AS over_break ,
	                TIMESTAMPDIFF(MINUTE,IF(sch.id_schedule_type='1',MIN(at_in.datetime),MIN(at_in_hol.datetime)) ,IF(sch.id_schedule_type='1',MAX(at_out.datetime),MAX(at_out_hol.datetime))) AS actual_work_hour 
	                FROM tb_emp_schedule sch 
	                LEFT JOIN
	                (
	                SELECT eld.* FROM tb_emp_leave_det eld
	                INNER JOIN tb_emp_leave el ON el.id_emp_leave=eld.id_emp_leave
	                WHERE el.id_report_status='6' 
	                ) lv ON lv.id_schedule=sch.id_schedule
	                LEFT JOIN tb_lookup_leave_type ket ON ket.id_leave_type=sch.id_leave_type 
	                INNER JOIN tb_m_employee emp ON emp.id_employee=sch.id_employee 
                    INNER JOIN 
                    (
	                    SELECT emp.id_employee
	                    FROM tb_m_departement dep
	                    INNER JOIN tb_m_user usr ON usr.id_user=dep.id_user_head OR usr.id_user=dep.`id_user_asst_head`
	                    INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee
	                    WHERE dep.is_office_dept='1'
	                    UNION
	                    SELECT id_employee FROM tb_emp_attn_spec
	                    GROUP BY id_employee
                    ) dept_head ON dept_head.id_employee=emp.id_employee
	                INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level 
	                INNER JOIN tb_m_departement dept ON dept.id_departement=emp.id_departement 
	                INNER JOIN tb_lookup_schedule_type scht ON scht.id_schedule_type=sch.id_schedule_type 
	                INNER JOIN tb_lookup_employee_active active ON emp.id_employee_active=active.id_employee_active
	                LEFT JOIN tb_emp_attn at_in ON at_in.id_employee = sch.id_employee AND (at_in.datetime>=(sch.out - INTERVAL 1 DAY) AND at_in.datetime<=sch.out) AND at_in.type_log = 1 
	                LEFT JOIN tb_emp_attn at_out ON at_out.id_employee = sch.id_employee AND (at_out.datetime>=sch.in AND at_out.datetime<=(sch.in + INTERVAL 1 DAY)) AND at_out.type_log = 2 
	                LEFT JOIN tb_emp_attn at_brout ON at_brout.id_employee=sch.id_employee AND DATE(at_brout.datetime) = sch.Date AND at_brout.type_log = 3 
	                LEFT JOIN tb_emp_attn at_brin ON at_brin.id_employee=sch.id_employee AND DATE(at_brin.datetime) = sch.Date AND at_brin.type_log = 4
	                LEFT JOIN tb_emp_attn at_in_hol ON at_in_hol.id_employee = sch.id_employee AND DATE(at_in_hol.datetime) = sch.Date AND at_in_hol.type_log = 1 
	                LEFT JOIN tb_emp_attn at_out_hol ON at_out_hol.id_employee = sch.id_employee AND DATE(at_out_hol.datetime) = sch.Date AND at_out_hol.type_log = 2   
	                WHERE emp.id_departement LIKE '" & dept & "' AND sch.date >='" & date_start & "' AND sch.date <='" & date_until & "' AND emp.id_employee_active LIKE '" & status & "'
	                GROUP BY sch.id_schedule
                )tb
                INNER JOIN tb_m_departement dep ON dep.id_departement=tb.id_departement
                GROUP BY tb.id_employee"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSum.DataSource = data
        GVSum.BestFitColumns()
        GVSum.ExpandAllGroups()
    End Sub

    Sub load_report_sum_month(ByVal opt As String)
        Dim date_start, date_until, dept, status, employee As String

        date_start = Date.Parse(DEStartSum.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntilSum.EditValue.ToString).ToString("yyyy-MM-dd")

        If LEDeptSum.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDeptSum.EditValue.ToString
        End If

        If LEEmployeeStatus.EditValue.ToString = "0" Then
            status = "%%"
        Else
            status = LEEmployeeStatus.EditValue.ToString
        End If

        If SLUEEmployee.EditValue.ToString = "0" Then
            employee = "%%"
        Else
            employee = SLUEEmployee.EditValue.ToString
        End If

        Dim query As String = ""
        query = "SELECT tb.id_schedule,tb.employee_level,tb.employee_position,tb.employee_active,tb.id_employee_active,tb.id_employee,tb.employee_name,tb.employee_code,tb.id_departement,dep.departement,DATE_FORMAT(tb.date,'%M %Y') AS month_year,SUM(tb.late) AS late,SUM(tb.early_home) AS early_home,SUM(tb.over) AS over,SUM(tb.over_break) AS over_break,
                SUM(IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),(tb.minutes_work-tb.over_break-tb.late-tb.early_home),0)) AS work_hour,
                SUM(tb.actual_work_hour) AS actual_work_hour,SUM((tb.over_break+tb.early_home)) AS total_minus,SUM(tb.over-tb.over_break-tb.late) AS balance,SUM(IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),1,0)) AS present,SUM(IF(tb.id_schedule_type=1,1,0)) AS workday 
                ,SUM(tb.tot_sick) AS tot_sick
                FROM
                (
	                SELECT sch.id_schedule_type,sch.id_schedule,lvl.employee_level,emp.employee_position,ket.id_leave_type,ket.leave_type,sch.info_leave,active.employee_active,active.id_employee_active,sch.id_employee,emp.employee_name,emp.employee_code,emp.id_departement,dept.departement,sch.date, 
	                sch.in,sch.in_tolerance,
	                IF(sch.id_schedule_type='1',MIN(at_in.datetime),MIN(at_in_hol.datetime)) AS `att_in`, 
	                sch.out,
	                IF(sch.id_schedule_type='1',MAX(at_out.datetime),MAX(at_out_hol.datetime)) AS `att_out`, 
	                sch.break_out,MIN(at_brout.datetime) AS start_break, 
	                sch.break_in,MAX(at_brin.datetime) AS end_break, 
	                scht.schedule_type,note ,
	                sch.minutes_work,
                    SUM(IF(IFNULL(lv.id_leave_type,0)=2,lv.minutes_total,0)) as tot_sick,
	                IF(IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) - IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_until=sch.out,0,lv.minutes_total+60))<0,0,IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) - IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_until=sch.out,0,lv.minutes_total+60))) AS late ,
	                IF(TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,IF(lv.id_leave_type=5 OR lv.id_leave_type=6,lv.minutes_total,lv.minutes_total+60)))<-(sch.out_tolerance),-(TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,IF(lv.id_leave_type=5 OR lv.id_leave_type=6,lv.minutes_total,lv.minutes_total+60)))),0) AS early_home ,
	                IF(TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,IF(lv.id_leave_type=5 OR lv.id_leave_type=6,lv.minutes_total,lv.minutes_total+60)))<-(sch.out_tolerance),TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,IF(lv.id_leave_type=5 OR lv.id_leave_type=6,lv.minutes_total,lv.minutes_total+60))),TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,IF(lv.id_leave_type=5 OR lv.id_leave_type=6,lv.minutes_total,lv.minutes_total+60)))) AS over,
	                IF(TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))>TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),
	                TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))-TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),0) AS over_break ,
	                TIMESTAMPDIFF(MINUTE,IF(sch.id_schedule_type='1',MIN(at_in.datetime),MIN(at_in_hol.datetime)) ,IF(sch.id_schedule_type='1',MAX(at_out.datetime),MAX(at_out_hol.datetime))) AS actual_work_hour 
	                FROM tb_emp_schedule sch 
	                LEFT JOIN
	                (
	                    SELECT eld.*,el.`id_leave_type` FROM tb_emp_leave_det eld
	                    INNER JOIN tb_emp_leave el ON el.id_emp_leave=eld.id_emp_leave
	                    WHERE el.id_report_status='6' 
	                ) lv ON lv.id_schedule=sch.id_schedule
	                LEFT JOIN tb_lookup_leave_type ket ON ket.id_leave_type=sch.id_leave_type 
	                INNER JOIN tb_m_employee emp ON emp.id_employee=sch.id_employee "
        If opt = "pic" Then
            query += " INNER JOIN 
                    (
	                    SELECT emp.id_employee
	                    FROM tb_m_departement dep
	                    INNER JOIN tb_m_user usr ON usr.id_user=dep.id_user_head OR usr.id_user=dep.`id_user_asst_head`
	                    INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee
	                    WHERE dep.is_office_dept='1'
	                    UNION
	                    SELECT id_employee FROM tb_emp_attn_spec
	                    GROUP BY id_employee
                    ) dept_head ON dept_head.id_employee=emp.id_employee "
        End If
        query += "INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level 
	                INNER JOIN tb_m_departement dept ON dept.id_departement=emp.id_departement 
	                INNER JOIN tb_lookup_schedule_type scht ON scht.id_schedule_type=sch.id_schedule_type 
	                INNER JOIN tb_lookup_employee_active active ON emp.id_employee_active=active.id_employee_active
	                LEFT JOIN tb_emp_attn at_in ON at_in.id_employee = sch.id_employee AND (at_in.datetime>=(sch.out - INTERVAL 1 DAY) AND at_in.datetime<=sch.out) AND at_in.type_log = 1 
	                LEFT JOIN tb_emp_attn at_out ON at_out.id_employee = sch.id_employee AND (at_out.datetime>=sch.in AND at_out.datetime<=(sch.in + INTERVAL 1 DAY)) AND at_out.type_log = 2 
	                LEFT JOIN tb_emp_attn at_brout ON at_brout.id_employee=sch.id_employee AND DATE(at_brout.datetime) = sch.Date AND at_brout.type_log = 3 
	                LEFT JOIN tb_emp_attn at_brin ON at_brin.id_employee=sch.id_employee AND DATE(at_brin.datetime) = sch.Date AND at_brin.type_log = 4
	                LEFT JOIN tb_emp_attn at_in_hol ON at_in_hol.id_employee = sch.id_employee AND DATE(at_in_hol.datetime) = sch.Date AND at_in_hol.type_log = 1 
	                LEFT JOIN tb_emp_attn at_out_hol ON at_out_hol.id_employee = sch.id_employee AND DATE(at_out_hol.datetime) = sch.Date AND at_out_hol.type_log = 2     
	                WHERE emp.id_departement LIKE '" & dept & "' AND sch.date >='" & date_start & "' AND sch.date <='" & date_until & "' AND emp.id_employee_active LIKE '" & status & "' AND emp.id_employee LIKE '" & employee & "'
	                GROUP BY sch.id_schedule
                )tb
                INNER JOIN tb_m_departement dep ON dep.id_departement=tb.id_departement
                GROUP BY tb.id_employee, MONTH(tb.date), YEAR(tb.date)
                ORDER BY tb.employee_name ASC, tb.date ASC"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSumMonthly.DataSource = data
        GVSumMonthly.BestFitColumns()
        GVSumMonthly.ExpandAllGroups()
    End Sub

    Private Sub GVSchedule_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSchedule.CustomColumnDisplayText
        If e.Column.FieldName = "present" Then
            If e.Value = "1" Then
                e.DisplayText = "Yes"
            Else
                e.DisplayText = "No"
            End If
        End If
    End Sub

    Sub getReport()
        ReportAttnSum.dt = GCSchedule.DataSource
        ReportAttnSum.id_report_type = "1"
        Dim Report As New ReportAttnSum()
        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVSchedule.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVSchedule.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVSchedule)

        'Parse val
        Report.LType.Text = If(SLUEEmployee.EditValue.ToString = "0", "Departement", "Name")
        Report.LDept.Text = If(SLUEEmployee.EditValue.ToString = "0", LEDeptSum.Text, SLUEEmployee.Text)
        Report.LDateRange.Text = Date.Parse(DEStartSum.EditValue.ToString).ToString("dd MMM yyyy") + " - " + Date.Parse(DEUntilSum.EditValue.ToString).ToString("dd MMM yyyy")

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
    Sub getReportSum()
        ReportAttnSum.dt = GCSum.DataSource
        ReportAttnSum.id_report_type = "-1"
        Dim Report As New ReportAttnSum()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVSum.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVSchedule.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVSchedule)

        'Parse val
        Report.LType.Text = If(SLUEEmployee.EditValue.ToString = "0", "Departement", "Name")
        Report.LDept.Text = If(SLUEEmployee.EditValue.ToString = "0", LEDeptSum.Text, SLUEEmployee.Text)
        Report.LDateRange.Text = Date.Parse(DEStartSum.EditValue.ToString).ToString("dd MMM yyyy") + " - " + Date.Parse(DEUntilSum.EditValue.ToString).ToString("dd MMM yyyy")

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
    Sub getReportSumMonth()
        ReportAttnSum.dt = GCSumMonthly.DataSource
        ReportAttnSum.id_report_type = "-1"
        Dim Report As New ReportAttnSum()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVSumMonthly.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVSchedule.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVSchedule)

        'Parse val
        Report.LType.Text = If(SLUEEmployee.EditValue.ToString = "0", "Departement", "Name")
        Report.LDept.Text = If(SLUEEmployee.EditValue.ToString = "0", LEDeptSum.Text, SLUEEmployee.Text)
        Report.LDateRange.Text = Date.Parse(DEStartSum.EditValue.ToString).ToString("dd MMM yyyy") + " - " + Date.Parse(DEUntilSum.EditValue.ToString).ToString("dd MMM yyyy")

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BPrintSum_Click(sender As Object, e As EventArgs) Handles BPrintSum.Click
        Dim title As String = If(SLUEEmployee.EditValue.ToString = "0", LEDeptSum.Text, SLUEEmployee.Text)

        If XTCReportAttendance.SelectedTabPageIndex = 0 Then
            getReportSum()
        ElseIf XTCReportAttendance.SelectedTabPageIndex = 1 Then
            getReport()
        ElseIf XTCReportAttendance.SelectedTabPageIndex = 2 Then
            print(GCListSchedule, title + "(" + Date.Parse(DEStartSum.EditValue.ToString).ToString("dd MMM yyyy") + " - " + Date.Parse(DEUntilSum.EditValue.ToString).ToString("dd MMM yyyy") + ")")
        ElseIf XTCReportAttendance.SelectedTabPageIndex = 3 Then
            print(GCScheduleTable, title + "(" + Date.Parse(DEStartSum.EditValue.ToString).ToString("dd MMM yyyy") + " - " + Date.Parse(DEUntilSum.EditValue.ToString).ToString("dd MMM yyyy") + ")")
        ElseIf XTCReportAttendance.SelectedTabPageIndex = 4 Then
            getReportSumMonth()
        End If
    End Sub

    Private Sub DEStartSum_EditValueChanged(sender As Object, e As EventArgs) Handles DEStartSum.EditValueChanged
        Try
            DEUntilSum.Properties.MinValue = DEStartSum.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SMEditKet_Click(sender As Object, e As EventArgs)
        'If GVSchedule.RowCount > 0 And Not GVSchedule.IsGroupRow(GVSchedule.FocusedRowHandle) Then
        '    FormEmpScheduleKet.id_schedule = GVSchedule.GetFocusedRowCellValue("id_schedule").ToString
        '    Try
        '        FormEmpScheduleKet.id_leave_type = GVSchedule.GetFocusedRowCellValue("id_leave_type").ToString
        '        FormEmpScheduleKet.MEInfo.Text = GVSchedule.GetFocusedRowCellValue("info_leave").ToString
        '    Catch ex As Exception
        '    End Try

        '    FormEmpScheduleKet.ShowDialog()
        'End If
    End Sub

    Private Sub GVSchedule_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVSchedule.RowCellStyle
        If GVSchedule.GetRowCellValue(e.RowHandle, "id_employee_active").ToString = "1" And GVSchedule.GetRowCellValue(e.RowHandle, "id_schedule_type").ToString = "1" And Date.Parse(GVSchedule.GetRowCellValue(e.RowHandle, "date").ToString).Date < Now.Date And GVSchedule.GetRowCellValue(e.RowHandle, "present").ToString = "0" And GVSchedule.GetRowCellValue(e.RowHandle, "id_leave_type").ToString = "" Then
            e.Appearance.BackColor = Color.Yellow
        ElseIf GVSchedule.GetRowCellValue(e.RowHandle, "id_employee_active").ToString = "1" And GVSchedule.GetRowCellValue(e.RowHandle, "id_schedule_type").ToString = "2" Then
            e.Appearance.BackColor = Color.LightGreen
        ElseIf GVSchedule.GetRowCellValue(e.RowHandle, "id_employee_active").ToString = "1" And GVSchedule.GetRowCellValue(e.RowHandle, "id_schedule_type").ToString = "3" Then
            e.Appearance.BackColor = Color.Lime
        End If
    End Sub

    Private Sub BHeadAndPIC_Click(sender As Object, e As EventArgs) Handles BHeadAndPIC.Click
        Cursor = Cursors.WaitCursor

        SLUEEmployee.EditValue = 0

        If XTCReportAttendance.SelectedTabPageIndex = 0 Then
            load_report_sum("pic")
        ElseIf XTCReportAttendance.SelectedTabPageIndex = 1 Then
            load_report("pic")
        ElseIf XTCReportAttendance.SelectedTabPageIndex = 2 Then
            load_report_schedule("pic")
        ElseIf XTCReportAttendance.SelectedTabPageIndex = 3 Then
            load_schedule_table_head_pic()
        ElseIf XTCReportAttendance.SelectedTabPageIndex = 4 Then
            load_report_sum_month("pic")
        End If
        Cursor = Cursors.Default
    End Sub

    Dim tot_minus As Decimal
    Dim tot_late As Decimal
    Dim tot_sick As Decimal
    Dim tot_minutes_work As Decimal

    Dim tot_minus_grp As Decimal
    Dim tot_late_grp As Decimal
    Dim tot_sick_grp As Decimal
    Dim tot_minutes_work_grp As Decimal

    Private Sub GVSum_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVSum.CustomSummaryCalculate
        Dim summaryID As String = CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag.ToString
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            tot_minus = 0.00
            tot_late = 0.00
            tot_sick = 0.00
            tot_minutes_work = 0.00
            '
            tot_minus_grp = 0.00
            tot_late_grp = 0.00
            tot_sick_grp = 0.00
            tot_minutes_work_grp = 0.00
        End If

        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim minus As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "late").ToString, "0.00"))
            Dim late As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_minus").ToString, "0.00"))
            Dim sick As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "tot_sick").ToString, "0.00"))
            Dim minutes_work As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "work_hour").ToString, "0.00"))

            Select Case summaryID
                Case "footer"
                    tot_minus += minus
                    tot_late += late
                    tot_sick += sick
                    tot_minutes_work += minutes_work
                Case "grup"
                    tot_minus_grp += minus
                    tot_late_grp += late
                    tot_sick_grp += sick
                    tot_minutes_work_grp += minutes_work
            End Select
        End If
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case "footer" 'total summary
                    Dim sum_res As Decimal = 0.00
                    Try
                        sum_res = ((tot_minus + tot_late + tot_sick) / tot_minutes_work) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "grup" 'group summary
                    Dim sum_res As Decimal = 0.00
                    Try
                        sum_res = ((tot_minus_grp + tot_late_grp + tot_sick_grp) / tot_minutes_work_grp) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
            End Select
        End If
    End Sub

    Private Sub SLUEEmployee_Click(sender As Object, e As EventArgs) Handles SLUEEmployee.Click
        SearchLookUpEditEmp.ActiveFilterString = ""

        If LEDeptSum.EditValue.ToString <> "0" Then
            SearchLookUpEditEmp.ActiveFilterString += "[id_departement] = " + LEDeptSum.EditValue.ToString
        End If

        If LEEmployeeStatus.EditValue.ToString <> "0" Then
            If SearchLookUpEditEmp.ActiveFilterString <> "" Then
                SearchLookUpEditEmp.ActiveFilterString += " AND [id_employee_active] = " + LEEmployeeStatus.EditValue.ToString
            Else
                SearchLookUpEditEmp.ActiveFilterString += "[id_employee_active] = " + LEEmployeeStatus.EditValue.ToString
            End If
        End If

        If SearchLookUpEditEmp.ActiveFilterString <> "" Then
            SearchLookUpEditEmp.ActiveFilterString += "OR [id_employee] = 0"
        End If
    End Sub

    Private Sub LEDeptSum_EditValueChanged(sender As Object, e As EventArgs) Handles LEDeptSum.EditValueChanged
        SLUEEmployee.EditValue = 0
    End Sub

    Private Sub LEEmployeeStatus_EditValueChanged(sender As Object, e As EventArgs) Handles LEEmployeeStatus.EditValueChanged
        SLUEEmployee.EditValue = 0
    End Sub
End Class