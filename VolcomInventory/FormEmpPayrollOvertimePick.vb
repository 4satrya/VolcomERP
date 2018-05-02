Public Class FormEmpPayrollOvertimePick
    Public date_start As String = ""
    Public date_end As String = ""

    Private Sub FormEmpPayrollOvertimePick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_ot_type()
        viewDept()
        viewEmployee()
        '
    End Sub
    Sub load_ot_type()
        Dim query As String = "SELECT id_ot_type,ot_type,IF(is_event='1','Yes','No') AS is_event,ot_point_wages FROM tb_lookup_ot_type"
        viewLookupRepositoryQuery(RILEOtCategory, query, 0, "ot_type", "id_ot_type")
    End Sub
    Sub viewEmployee()
        Dim query As String = "SELECT '0' AS `id_employee`,'-' AS `employee_code`,'All Employee' AS `employee_name`
                                UNION
                                SELECT a.`id_employee`,a.`employee_code`,a.`employee_name` 
                                FROM `tb_emp_payroll_det` pyd
                                INNER JOIN tb_m_employee a ON a.`id_employee`=pyd.`id_employee`
                                WHERE a.`id_departement`='" & LEDeptSum.EditValue.ToString & "' AND pyd.id_payroll='" & FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString & "'"
        viewSearchLookupQuery(SLEEmployee, query, "id_employee", "employee_name", "id_employee")
    End Sub
    Sub viewDept()
        Dim query As String = "SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC "
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
    End Sub

    Private Sub BViewSum_Click(sender As Object, e As EventArgs) Handles BViewSum.Click
        Dim dept As String = ""
        Dim emp As String = ""

        If SLEEmployee.EditValue.ToString = "0" Then
            emp = "%%"
        Else
            emp = SLEEmployee.EditValue.ToString
        End If

        dept = LEDeptSum.EditValue.ToString

        Dim query As String = "SELECT '' AS ot_note,0.00 as ot_hour,0 as wages_point,0 as ot_break,0 as point,'no' as is_check,1 as id_ot_type,tb.*,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),(tb.minutes_work-tb.over_break-tb.late+IF(tb.over<0,tb.over,0)),0) AS work_hour,(tb.over-tb.late-tb.over_break) AS balance,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),1,0) AS present 
                                ,TIMESTAMPDIFF(MINUTE,tb.att_in,tb.in_tolerance) AS early,TIMESTAMPDIFF(MINUTE,tb.out,tb.att_out) AS overtime,IF((SELECT early)>(SELECT overtime),IFNULL(tb.att_in,tb.date),IFNULL(tb.out,tb.date)) AS ot_in,IF((SELECT early)>(SELECT overtime),IFNULL(tb.in_tolerance,tb.date),IFNULL(tb.att_out,tb.date)) AS ot_out
                                FROM
                                (
                                 SELECT sch.id_schedule,lvl.employee_level,emp.employee_position,ket.id_leave_type,ket.leave_type,sch.info_leave,active.employee_active,active.id_employee_active,sch.id_employee,emp.employee_name,emp.employee_code,emp.id_departement,dept.departement,dept.is_store,sch.date, 
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
                                ) lv ON lv.id_schedule=sch.id_schedule
                                LEFT JOIN tb_lookup_leave_type ket ON ket.id_leave_type=sch.id_leave_type 
                                INNER JOIN tb_m_employee emp ON emp.id_employee=sch.id_employee 
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
                                WHERE emp.id_departement = '" & dept & "'
                                AND sch.date >='" & date_start & "'
                                AND sch.date <='" & date_end & "'
                                AND emp.id_employee LIKE '" & emp & "'
                                GROUP BY sch.id_schedule
                                ) tb"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSchedule.DataSource = data
        GVSchedule.BestFitColumns()
        GVSchedule.ExpandAllGroups()
    End Sub

    Private Sub LEDeptSum_EditValueChanged(sender As Object, e As EventArgs) Handles LEDeptSum.EditValueChanged
        Try
            viewEmployee()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'filter
        makeSafeGV(GVSchedule)
        GVSchedule.ActiveFilterString = "[is_check]='yes'"
        If GVSchedule.RowCount > 0 Then
            For i As Integer = 0 To GVSchedule.RowCount - 1
                Dim id_payroll As String = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
                Dim id_employee As String = GVSchedule.GetRowCellValue(i, "id_employee").ToString
                Dim id_ot_type As String = GVSchedule.GetRowCellValue(i, "id_ot_type").ToString
                Dim ot_in As Date = GVSchedule.GetRowCellValue(i, "ot_in")
                Dim ot_end As Date = GVSchedule.GetRowCellValue(i, "ot_out")
                '
                Dim tot_hour As String = GVSchedule.GetRowCellValue(i, "ot_hour")
                Dim tot_break As String = GVSchedule.GetRowCellValue(i, "ot_break")
                Dim tot_poin As String = GVSchedule.GetRowCellValue(i, "point")
                Dim wages_per_point As String = GVSchedule.GetRowCellValue(i, "wages_point")
                '
                Dim is_dayoff As String = If(GVSchedule.GetRowCellValue(i, "id_schedule_type").ToString = "1", "2", "1")
                Dim note As String = GVSchedule.GetRowCellValue(i, "ot_note").ToString
                '
                Dim query As String = "INSERT INTO tb_emp_payroll_ot(id_payroll,id_employee,id_ot_type,ot_start,ot_end,total_break,total_hour,total_point,is_day_off,wages_per_point,note)
                                    VALUES('" & id_payroll & "','" & id_employee & "','" & id_ot_type & "','" & Date.Parse(ot_in.ToString).ToString("yyyy-MM-dd H:mm:ss") & "','" & Date.Parse(ot_end.ToString).ToString("yyyy-MM-dd H:mm:ss") & "','" & tot_break & "','" & tot_hour & "','" & tot_poin & "','" & is_dayoff & "','" & wages_per_point & "','" & note & "');"
                execute_non_query(query, True, "", "", "", "")
            Next
            makeSafeGV(GVSchedule)
            FormEmpPayrollOvertime.load_payroll_ot()
            Close()
        Else
            stopCustom("Please choose first.")
        End If
    End Sub

    Private Sub FormEmpPayrollOvertimePick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub RILEOtCategory_EditValueChanged(sender As Object, e As EventArgs) Handles RILEOtCategory.EditValueChanged
        Dim tes As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim row As DataRowView = CType(tes.Properties.GetDataSourceRowByKeyValue(tes.EditValue), DataRowView)
        GVSchedule.SetFocusedRowCellValue("wages_point", row("ot_point_wages"))
        GVSchedule.RefreshData()
    End Sub
    Function calc_point(ByVal id_schedule_type As String, ByVal tot_hour As Decimal, ByVal is_store_employee As String)
        Dim tot_point As Decimal = 0.0
        Try
            If Not id_schedule_type = "1" Then
                'hari libur
                If is_store_employee = "1" Then 'toko
                    tot_point = If(tot_hour > 8, ((tot_hour - 8) * 4), 0) + If(tot_hour > 7, ((tot_hour - If(tot_hour > 7, (tot_hour - 8), 0) - 7) * 3), 0) + (tot_hour - If(tot_hour > 7, (tot_hour - 7), 0)) * 2
                Else 'office
                    tot_point = If(tot_hour > 9, ((tot_hour - 9) * 4), 0) + If(tot_hour > 8, ((tot_hour - If(tot_hour > 9, (tot_hour - 9), 0) - 8) * 3), 0) + (tot_hour - If(tot_hour > 8, (tot_hour - 8), 0)) * 2
                End If
            Else
                'hari kerja
                tot_point = If(tot_hour > 1, ((tot_hour - 1) * 2), 0) + ((tot_hour - If(tot_hour > 1, (tot_hour - 1), 0)) * 1.5)
            End If
        Catch ex As Exception
            tot_point = 0.0
        End Try
        Return tot_point
    End Function

    Function calc_hour(ByVal ot_start As Date, ByVal ot_end As Date, ByVal break As Integer)
        Dim diff As Decimal = 0.0

        If Not ot_start > ot_end Then
            '
            Dim date_start As Date = ot_start
            Dim date_until As Date = ot_end
            Dim time_diff As TimeSpan
            time_diff = date_until - date_start
            'nearest 0.5
            'diff = Math.Round((time_diff.TotalHours * 2), MidpointRounding.AwayFromZero) / 2
            'rounddown 0.5
            diff = Math.Floor(time_diff.TotalHours / 0.5) * 0.5
            diff = diff - break
        Else
            '
            diff = 0
        End If
        Return diff
    End Function

    Private Sub GVSchedule_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVSchedule.CellValueChanged
        If e.Column.FieldName = "ot_in" Or e.Column.FieldName = "ot_out" Or e.Column.FieldName = "ot_break" Or e.Column.FieldName = "id_ot_type" Then
            Try
                Dim ot_start As Date = GVSchedule.GetFocusedRowCellValue("ot_in")
                Dim ot_end As Date = GVSchedule.GetFocusedRowCellValue("ot_out")
                Dim ot_break As Integer = GVSchedule.GetFocusedRowCellValue("ot_break")

                Dim tot_hour As Decimal = calc_hour(ot_start, ot_end, ot_break)
                Dim id_sch_type As String = GVSchedule.GetFocusedRowCellValue("id_schedule_type").ToString
                Dim is_store As String = GVSchedule.GetFocusedRowCellValue("is_store").ToString
                GVSchedule.SetFocusedRowCellValue("ot_hour", tot_hour)
                GVSchedule.SetFocusedRowCellValue("point", calc_point(id_sch_type, tot_hour, is_store))
                GVSchedule.RefreshData()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
End Class