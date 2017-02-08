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
        query = "SELECT tb.*,(tb.over-tb.late-tb.over_break) AS balance,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),1,0) AS present FROM"
        query += " ("
        query += " SELECT sch.id_employee,sch.date, "
        query += " sch.In,sch.in_tolerance,MIN(at_in.datetime) As `att_in`, "
        query += " sch.out,MAX(at_out.datetime) AS `att_out`, "
        query += " sch.break_out,MIN(at_brout.datetime) As start_break, "
        query += " sch.break_in,MAX(at_brin.datetime) AS end_break, "
        query += " scht.schedule_type,note ,"
        query += " IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) AS late ,"
        'query += " If(MAX(at_out.datetime)>sch.out,TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)),0) As over ,"
        query += " TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) As over ,"
        query += " IF(TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))>TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),"
        query += " TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))-TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),0) As over_break ,"
        query += " TIMESTAMPDIFF(MINUTE,MIN(at_in.datetime),MAX(at_out.datetime)) AS actual_work_hour ,"
        query += " TIMESTAMPDIFF(MINUTE,If(MIN(at_in.datetime)<sch.In,sch.In,If(MIN(at_in.datetime)<sch.in_tolerance,sch.In,MIN(at_in.datetime))),If(MAX(at_out.datetime)>sch.out,sch.out,MAX(at_out.datetime))) As work_hour, "
        query += " ket.id_leave_type,ket.leave_type,sch.info_leave "
        query += " FROM tb_emp_schedule sch "
        query += " LEFT JOIN tb_lookup_leave_type ket ON ket.id_leave_type=sch.id_leave_type "
        query += " INNER JOIN tb_lookup_schedule_type scht On scht.id_schedule_type=sch.id_schedule_type "
        'query attendance old
        'query += " LEFT JOIN tb_emp_attn at_in On at_in.id_employee=sch.id_employee And Date(at_in.datetime) = sch.Date And at_in.type_log = 1 "
        'query += " LEFT JOIN tb_emp_attn at_out On at_out.id_employee=sch.id_employee And Date(at_out.datetime) = sch.Date And at_out.type_log = 2 "
        query += " LEFT JOIN tb_emp_attn at_in ON at_in.id_employee = sch.id_employee AND (at_in.datetime>=(sch.out - INTERVAL 1 DAY) AND at_in.datetime<=sch.out) AND at_in.type_log = 1 "
        query += " LEFT JOIN tb_emp_attn at_out ON at_out.id_employee = sch.id_employee AND (at_out.datetime>=sch.in AND at_out.datetime<=(sch.in + INTERVAL 1 DAY)) AND at_out.type_log = 2 "
        query += " LEFT JOIN tb_emp_attn at_brout On at_brout.id_employee=sch.id_employee And Date(at_brout.datetime) = sch.Date And at_brout.type_log = 3 "
        query += " LEFT JOIN tb_emp_attn at_brin On at_brin.id_employee=sch.id_employee And Date(at_brin.datetime) = sch.Date And at_brin.type_log = 4 "
        query += " WHERE sch.id_employee='" & id_employee & "'"
        query += " AND sch.date >='" & date_start & "'"
        query += " AND sch.date <='" & date_until & "'"
        query += " GROUP BY sch.id_schedule"
        query += " ) tb"

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
End Class