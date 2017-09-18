Public Class FormEmpAttnIndView
    Public id_employee As String = "-1"

    Private Sub FormEmpAttnIndView_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Sub load_report()
        Dim date_start, date_until As String

        date_start = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim query As String = ""
        query = "SELECT tb.*,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),(tb.minutes_work-tb.over_break-tb.late+IF(tb.over<0,tb.over,0)),0) AS work_hour,(tb.over-tb.late-tb.over_break) AS balance,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),1,0) AS present FROM
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
                WHERE sch.id_employee='" & id_employee & "'
                And sch.date >='" & date_start & "'
                And sch.date <='" & date_until & "'
                GROUP BY sch.id_schedule
                ) tb"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSchedule.DataSource = data
        GVSchedule.BestFitColumns()
    End Sub

    Private Sub BViewSchedule_Click(sender As Object, e As EventArgs) Handles BViewSchedule.Click
        If XTCAttnIndView.SelectedTabPageIndex = 0 Then
            load_report()
        Else
            load_report_dinas()
        End If
    End Sub

    Sub load_report_dinas()
        Dim date_start, date_until As String

        date_start = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim query As String = "SELECT emp.employee_code,emp.employee_name,att.datetime,DATE(att.datetime) as date,TIME(att.datetime) as time,type_log.type_log,fp.name AS fp_machine,IF(att.scan_method=1,'Fingerprint','Face') AS scan_method FROM tb_emp_attn att
                                INNER JOIN tb_m_employee emp ON emp.id_employee=att.id_employee
                                INNER JOIN tb_lookup_type_log type_log ON type_log.id_type_log=att.type_log
                                INNER JOIN tb_m_fingerprint fp ON fp.id_fingerprint=att.id_fingerprint
                                WHERE DATE(att.datetime) >='" & date_start & "' AND DATE(att.datetime) <='" & date_until & "' AND (att.type_log=5 OR att.type_log=6) AND att.id_employee='" & id_employee & "'
                                ORDER BY att.datetime ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCLogAttn.DataSource = data
        GVLogAttn.BestFitColumns()
    End Sub

    Private Sub FormEmpAttnIndView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
        load_report()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        If XTCAttnIndView.SelectedTabPageIndex = 0 Then
            getReport()
        Else
            getReportDinas()
        End If
    End Sub

    Sub getReportDinas()
        ReportEmpAttnInd.dt = GCLogAttn.DataSource
        Dim Report As New ReportEmpAttnInd()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVLogAttn.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVEmployee.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVEmployee)

        'Parse val
        Report.LTitle.Text = "REPORT INDIVIDUAL (DINAS)"
        Report.Lname.Text = TEName.Text
        Report.Lcode.Text = TECode.Text
        Report.LDept.Text = TEDept.Text
        Report.LPosition.Text = TEPosition.Text
        Report.LDateRange.Text = Date.Parse(DEStart.EditValue.ToString).ToString("dd MMM yyyy") + " - " + Date.Parse(DEUntil.EditValue.ToString).ToString("dd MMM yyyy")

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Sub getReport()
        ReportEmpAttnInd.dt = GCSchedule.DataSource
        Dim Report As New ReportEmpAttnInd()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVSchedule.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVEmployee.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVEmployee)

        'Parse val
        Report.LTitle.Text = "REPORT INDIVIDUAL (ATTENDANCE)"
        Report.Lname.Text = TEName.Text
        Report.Lcode.Text = TECode.Text
        Report.LDept.Text = TEDept.Text
        Report.LPosition.Text = TEPosition.Text
        Report.LDateRange.Text = Date.Parse(DEStart.EditValue.ToString).ToString("dd MMM yyyy") + " - " + Date.Parse(DEUntil.EditValue.ToString).ToString("dd MMM yyyy")

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEUntil.Properties.MinValue = DEStart.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVSchedule_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVSchedule.RowCellStyle
        If GVSchedule.GetRowCellValue(e.RowHandle, "id_schedule_type").ToString = "1" And Date.Parse(GVSchedule.GetRowCellValue(e.RowHandle, "date").ToString).Date < Now.Date And GVSchedule.GetRowCellValue(e.RowHandle, "present").ToString = "0" And GVSchedule.GetRowCellValue(e.RowHandle, "id_leave_type").ToString = "" Then
            e.Appearance.BackColor = Color.Yellow
        End If
    End Sub
End Class