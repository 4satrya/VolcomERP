Public Class FormEmpAttnSum
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public view_one_dept As Boolean = False
    Public view_store As Boolean = False

    Private Sub BViewSchedule_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        load_report()
        Cursor = Cursors.Default
    End Sub
    Sub load_report()
        Dim date_start, date_until, dept As String

        date_start = Date.Parse(DEStartSum.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntilSum.EditValue.ToString).ToString("yyyy-MM-dd")

        If LEDeptSum.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDeptSum.EditValue.ToString
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
                                 scht.schedule_type,note ,
                                 sch.minutes_work,
                                 IF(IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) - IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_until=sch.out,0,lv.minutes_total+60))<0,0,IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) - IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_until=sch.out,0,lv.minutes_total+60))) AS late ,
                                 TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,lv.minutes_total+60)) AS over ,
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
                                WHERE emp.id_departement Like '" & dept & "'
                                AND sch.date >='" & date_start & "'
                                AND sch.date <='" & date_until & "'
                                GROUP BY sch.id_schedule
                                ) tb"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSchedule.DataSource = data
        GVSchedule.BestFitColumns()
        GVSchedule.ExpandAllGroups()
    End Sub
    Sub load_report_schedule()
        Dim date_start, date_until, dept As String

        date_start = Date.Parse(DEStartSum.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntilSum.EditValue.ToString).ToString("yyyy-MM-dd")

        If LEDeptSum.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDeptSum.EditValue.ToString
        End If

        Dim query As String = "SELECT tb.*,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),(tb.minutes_work-tb.over_break-tb.late+IF(tb.over<0,tb.over,0)),0) AS work_hour,(tb.over-tb.late-tb.over_break) AS balance,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),1,0) AS present FROM
                                (
                                 SELECT sch.id_schedule,lvl.employee_level,emp.employee_position,ket.id_leave_type,ket.leave_type,sch.info_leave,active.employee_active,active.id_employee_active,sch.id_employee,emp.employee_name,emp.employee_code,emp.id_departement,dept.departement,sch.date, 
                                 sch.in,sch.in_tolerance,IF(sch.id_schedule_type='1',MIN(at_in.datetime),MIN(at_in_hol.datetime)) AS `att_in`, 
                                 sch.out, IF(sch.id_schedule_type='1',MAX(at_out.datetime),MAX(at_out_hol.datetime)) AS `att_out`, 
                                 sch.break_out,MIN(at_brout.datetime) AS start_break, 
                                 sch.break_in,MAX(at_brin.datetime) AS end_break, 
                                 scht.schedule_type,note ,
                                 sch.minutes_work,
                                 IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) AS late ,
                                 TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) AS over ,
                                IF(TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))>TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),
                                TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))-TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),0) AS over_break ,
                                TIMESTAMPDIFF(MINUTE,MIN(at_in.datetime),MAX(at_out.datetime)) AS actual_work_hour 
                                FROM tb_emp_schedule sch 
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
                                WHERE emp.id_departement Like '" & dept & "'
                                AND sch.date >='" & date_start & "'
                                AND sch.date <='" & date_until & "'
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
        DEStartSum.EditValue = Now
        DEUntilSum.EditValue = Now
        '
        If view_one_dept Or view_store Then
            SMEditKet.Visible = False
        Else
            SMEditKet.Visible = True
        End If
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

    Private Sub BViewSum_Click(sender As Object, e As EventArgs) Handles BViewSum.Click
        Cursor = Cursors.WaitCursor
        If XTCReportAttendance.SelectedTabPageIndex = 0 Then
            load_report_sum()
        ElseIf XTCReportAttendance.SelectedTabPageIndex = 1 Then
            load_report()
        ElseIf XTCReportAttendance.SelectedTabPageIndex = 2 Then
            load_report_schedule()
        ElseIf XTCReportAttendance.SelectedTabPageIndex = 3 Then
            load_schedule_table()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub load_schedule_table()
        Dim startP As Date = Date.Parse(DEStartSum.EditValue.ToString)
        Dim endP As Date = Date.Parse(DEUntilSum.EditValue.ToString)
        Dim curD As Date = startP
        Dim string_date As String = ""
        Dim dept As String = ""

        If LEDeptSum.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDeptSum.EditValue.ToString
        End If

        Dim query As String = "SELECT * FROM tb_m_employee WHERE id_departement LIKE '" & dept & "' AND id_employee_active='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GVScheduleTable.Columns.Clear()

        If data.Rows.Count > 0 Then
            '
            GVScheduleTable.Columns.AddVisible("id_employee", "ID")
            GVScheduleTable.Columns("id_employee").OptionsColumn.AllowEdit = False
            GVScheduleTable.Columns("id_employee").Visible = False

            GVScheduleTable.Columns.AddVisible("employee_code", "NIP")
            GVScheduleTable.Columns("employee_code").OptionsColumn.AllowEdit = False

            GVScheduleTable.Columns.AddVisible("employee_name", "Name")
            GVScheduleTable.Columns("employee_name").OptionsColumn.AllowEdit = False

            While (curD <= endP)
                GVScheduleTable.Columns.AddVisible(curD.ToString("yyyy-MM-dd"), curD.ToString("dddd, dd MMM yyyy"))
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
        Else
            stopCustom("Please select employee first.")
        End If

    End Sub

    Sub load_report_sum()
        Dim date_start, date_until, dept As String

        date_start = Date.Parse(DEStartSum.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntilSum.EditValue.ToString).ToString("yyyy-MM-dd")

        If LEDeptSum.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDeptSum.EditValue.ToString
        End If

        Dim query As String = ""
        query = "SELECT tb.id_schedule,tb.employee_level,tb.employee_position,tb.id_leave_type,tb.leave_type,tb.info_leave,tb.employee_active,tb.id_employee_active,tb.id_employee,tb.employee_name,tb.employee_code,tb.id_departement,dep.departement,SUM(tb.late) AS late,SUM(tb.over) AS over,SUM(tb.over_break) AS over_break,
                SUM(IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),(tb.minutes_work-tb.over_break-tb.late+IF(tb.over<0,tb.over,0)),0)) AS work_hour,
                SUM(tb.actual_work_hour) AS actual_work_hour,SUM((tb.over-tb.late-tb.over_break)) AS balance,SUM(IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),1,0)) AS present,SUM(IF(tb.id_schedule_type=1,1,0)) AS workday 
                FROM
                (
                Select sch.id_schedule,lvl.employee_level,emp.employee_position,ket.id_leave_type,ket.leave_type,sch.info_leave,active.employee_active,active.id_employee_active,sch.id_schedule_type,sch.id_employee,emp.employee_name,emp.employee_code,emp.id_departement,sch.Date, 
                sch.minutes_work,sch.In, IF(sch.id_schedule_type='1',MIN(at_in.datetime),MIN(at_in_hol.datetime)) AS `att_in`, 
                sch.out,IF(sch.id_schedule_type='1',MAX(at_out.datetime),MAX(at_out_hol.datetime)) AS `att_out`, 
                sch.break_out,MIN(at_brout.datetime) As start_break, 
                sch.break_in,MAX(at_brin.datetime) As end_break, 
                scht.schedule_type,note,
                IF(IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) - IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_until=sch.out,0,lv.minutes_total+60))<0,0,IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) - IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_until=sch.out,0,lv.minutes_total+60))) AS late ,
                TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,lv.minutes_total+60)) As over ,
                If(TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))>TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),
                TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))-TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),0) As over_break ,
                TIMESTAMPDIFF(MINUTE,IF(sch.id_schedule_type='1',MIN(at_in.datetime),MIN(at_in_hol.datetime)) ,IF(sch.id_schedule_type='1',MAX(at_out.datetime),MAX(at_out_hol.datetime))) AS actual_work_hour 
                FROM tb_emp_schedule sch 
                LEFT JOIN
                (
                SELECT eld.* FROM tb_emp_leave_det eld
                INNER JOIN tb_emp_leave el ON el.id_emp_leave=eld.id_emp_leave
                WHERE el.id_report_status='6' 
                ) lv ON lv.id_schedule=sch.id_schedule
                LEFT JOIN tb_lookup_leave_type ket On ket.id_leave_type=sch.id_leave_type 
                INNER JOIN tb_m_employee emp On emp.id_employee=sch.id_employee 
                INNER JOIN tb_lookup_employee_level lvl On lvl.id_employee_level=emp.id_employee_level 
                INNER JOIN tb_lookup_schedule_type scht On scht.id_schedule_type=sch.id_schedule_type 
                INNER JOIN tb_lookup_employee_active active On emp.id_employee_active=active.id_employee_active
                LEFT JOIN tb_emp_attn at_in On at_in.id_employee = sch.id_employee And (at_in.datetime>=(sch.out - INTERVAL 1 DAY) And at_in.datetime<=sch.out) And at_in.type_log = 1 
                LEFT JOIN tb_emp_attn at_out On at_out.id_employee = sch.id_employee And (at_out.datetime>=sch.In And at_out.datetime<=(sch.In + INTERVAL 1 DAY)) And at_out.type_log = 2 
                LEFT JOIN tb_emp_attn at_brout On at_brout.id_employee=sch.id_employee And Date(at_brout.datetime) = sch.Date And at_brout.type_log = 3 
                LEFT JOIN tb_emp_attn at_brin On at_brin.id_employee=sch.id_employee And Date(at_brin.datetime) = sch.Date And at_brin.type_log = 4 
                LEFT JOIN tb_emp_attn at_in_hol ON at_in_hol.id_employee = sch.id_employee AND DATE(at_in_hol.datetime) = sch.Date AND at_in_hol.type_log = 1 
                LEFT JOIN tb_emp_attn at_out_hol ON at_out_hol.id_employee = sch.id_employee AND DATE(at_out_hol.datetime) = sch.Date AND at_out_hol.type_log = 2                
                WHERE emp.id_departement Like '" & dept & "' AND sch.date >='" & date_start & "' AND sch.date <='" & date_until & "' 
                GROUP BY sch.id_schedule
                )tb
                INNER Join tb_m_departement dep On dep.id_departement=tb.id_departement
                GROUP BY tb.id_employee"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSum.DataSource = data
        GVSum.BestFitColumns()
        GVSum.ExpandAllGroups()
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
        Report.LDept.Text = LEDeptSum.Text
        Report.LDateRange.Text = Date.Parse(DEStartSum.EditValue.ToString).ToString("dd MMM yyyy") + " - " + Date.Parse(DEUntilSum.EditValue.ToString).ToString("dd MMM yyyy")

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
    Sub getReportSum()
        ReportAttnSum.dt = GCSum.DataSource
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
        Report.LDept.Text = LEDeptSum.Text
        Report.LDateRange.Text = Date.Parse(DEStartSum.EditValue.ToString).ToString("dd MMM yyyy") + " - " + Date.Parse(DEUntilSum.EditValue.ToString).ToString("dd MMM yyyy")

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BPrintSum_Click(sender As Object, e As EventArgs) Handles BPrintSum.Click
        If XTCReportAttendance.SelectedTabPageIndex = 0 Then
            getReportSum()
        ElseIf XTCReportAttendance.SelectedTabPageIndex = 1 Then
            getReport()
        ElseIf XTCReportAttendance.SelectedTabPageIndex = 2 Then
            print(GCListSchedule, LEDeptSum.Text + "(" + Date.Parse(DEStartSum.EditValue.ToString).ToString("dd MMM yyyy") + " - " + Date.Parse(DEUntilSum.EditValue.ToString).ToString("dd MMM yyyy") + ")")
        ElseIf XTCReportAttendance.SelectedTabPageIndex = 3 Then
            print(GCScheduleTable, LEDeptSum.Text + "(" + Date.Parse(DEStartSum.EditValue.ToString).ToString("dd MMM yyyy") + " - " + Date.Parse(DEUntilSum.EditValue.ToString).ToString("dd MMM yyyy") + ")")
        End If
    End Sub

    Private Sub DEStartSum_EditValueChanged(sender As Object, e As EventArgs) Handles DEStartSum.EditValueChanged
        Try
            DEUntilSum.Properties.MinValue = DEStartSum.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SMEditKet_Click(sender As Object, e As EventArgs) Handles SMEditKet.Click
        If GVSchedule.RowCount > 0 And Not GVSchedule.IsGroupRow(GVSchedule.FocusedRowHandle) Then
            FormEmpScheduleKet.id_schedule = GVSchedule.GetFocusedRowCellValue("id_schedule").ToString
            Try
                FormEmpScheduleKet.id_leave_type = GVSchedule.GetFocusedRowCellValue("id_leave_type").ToString
                FormEmpScheduleKet.MEInfo.Text = GVSchedule.GetFocusedRowCellValue("info_leave").ToString
            Catch ex As Exception
            End Try

            FormEmpScheduleKet.ShowDialog()
        End If
    End Sub

End Class