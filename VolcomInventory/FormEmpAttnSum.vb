﻿Public Class FormEmpAttnSum
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub BViewSchedule_Click(sender As Object, e As EventArgs) Handles BViewSchedule.Click
        load_report()
    End Sub
    Sub load_report()
        Dim date_start, date_until, dept As String

        date_start = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        If LEDept.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDept.EditValue.ToString
        End If

        Dim query As String = ""
        query = "SELECT tb.*,(tb.over-tb.late-tb.over_break) AS balance,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),1,0) AS present FROM"
        query += " ("
        query += " SELECT sch.id_employee,emp.employee_name,emp.employee_code,emp.id_departement,dept.departement,sch.date, "
        query += " sch.in,sch.in_tolerance,MIN(at_in.datetime) As `att_in`, "
        query += " sch.out,MAX(at_out.datetime) AS `att_out`, "
        query += " sch.break_out,MIN(at_brout.datetime) As start_break, "
        query += " sch.break_in,MAX(at_brin.datetime) AS end_break, "
        query += " scht.schedule_type,note ,"
        query += " IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) AS late ,"
        query += " If(MAX(at_out.datetime)>sch.out,TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)),0) As over ,"
        query += " IF(TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))>TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),"
        query += " TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))-TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),0) As over_break ,"
        query += " TIMESTAMPDIFF(MINUTE,MIN(at_in.datetime),MAX(at_out.datetime)) AS actual_work_hour ,"
        query += " TIMESTAMPDIFF(MINUTE,If(MIN(at_in.datetime)<sch.In,sch.In,If(MIN(at_in.datetime)<sch.in_tolerance,sch.In,MIN(at_in.datetime))),If(MAX(at_out.datetime)>sch.out,sch.out,MAX(at_out.datetime))) As work_hour "
        query += " FROM tb_emp_schedule sch "
        query += " INNER JOIN tb_m_employee emp On emp.id_employee=sch.id_employee "
        query += " INNER JOIN tb_m_departement dept On dept.id_departement=emp.id_departement "
        query += " INNER JOIN tb_lookup_schedule_type scht On scht.id_schedule_type=sch.id_schedule_type "
        query += " LEFT JOIN tb_emp_attn at_in On at_in.id_employee=sch.id_employee And Date(at_in.datetime) = sch.Date And at_in.type_log = 1 "
        query += " LEFT JOIN tb_emp_attn at_out On at_out.id_employee=sch.id_employee And Date(at_out.datetime) = sch.Date And at_out.type_log = 2 "
        query += " LEFT JOIN tb_emp_attn at_brout On at_brout.id_employee=sch.id_employee And Date(at_brout.datetime) = sch.Date And at_brout.type_log = 3 "
        query += " LEFT JOIN tb_emp_attn at_brin On at_brin.id_employee=sch.id_employee And Date(at_brin.datetime) = sch.Date And at_brin.type_log = 4 "
        query += " WHERE emp.id_departement Like '" & dept & "'"
        query += " AND sch.date >='" & date_start & "'"
        query += " AND sch.date <='" & date_until & "'"
        query += " GROUP BY sch.id_schedule"
        query += " ) tb"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSchedule.DataSource = data
        GVSchedule.BestFitColumns()
        GVSchedule.ExpandAllGroups()
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
        viewDept()
        DEStart.EditValue = Now
        DEStartSum.EditValue = Now
        '
        DEUntil.EditValue = Now
        DEUntilSum.EditValue = Now
    End Sub

    Sub viewDept()
        Dim query As String = "SELECT 0 as id_departement, 'All departement' as departement UNION (SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        viewLookupQuery(LEDept, query, 0, "departement", "id_departement")
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
    End Sub

    Private Sub BViewSum_Click(sender As Object, e As EventArgs) Handles BViewSum.Click
        load_report_sum()
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
        query = "SELECT tb.id_employee,tb.employee_name,tb.employee_code,tb.id_departement,dep.departement,SUM(tb.late) AS late,SUM(tb.over) AS over,SUM(tb.over_break) AS over_break,SUM(tb.work_hour) AS work_hour,SUM(tb.actual_work_hour) AS actual_work_hour,SUM((tb.over-tb.late-tb.over_break)) AS balance,SUM(IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),1,0)) AS present,SUM(IF(tb.id_schedule_type=1,1,0)) AS workday "
        query += " FROM "
        query += " ("
        query += " SELECT sch.id_schedule_type,sch.id_employee,emp.employee_name,emp.employee_code,emp.id_departement,sch.date, "
        query += " sch.in,sch.in_tolerance,MIN(at_in.datetime) As `att_in`, "
        query += " sch.out,MAX(at_out.datetime) AS `att_out`, "
        query += " sch.break_out,MIN(at_brout.datetime) As start_break, "
        query += " sch.break_in,MAX(at_brin.datetime) AS end_break, "
        query += " scht.schedule_type,note ,"
        query += " IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) AS late ,"
        query += " If(MAX(at_out.datetime)>sch.out,TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)),0) As over ,"
        query += " IF(TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))>TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),"
        query += " TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))-TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),0) As over_break ,"
        query += " TIMESTAMPDIFF(MINUTE,MIN(at_in.datetime),MAX(at_out.datetime)) AS actual_work_hour ,"
        query += " TIMESTAMPDIFF(MINUTE,If(MIN(at_in.datetime)<sch.In,sch.In,If(MIN(at_in.datetime)<sch.in_tolerance,sch.In,MIN(at_in.datetime))),If(MAX(at_out.datetime)>sch.out,sch.out,MAX(at_out.datetime))) As work_hour "
        query += " FROM tb_emp_schedule sch "
        query += " INNER JOIN tb_m_employee emp On emp.id_employee=sch.id_employee "
        query += " INNER JOIN tb_lookup_schedule_type scht On scht.id_schedule_type=sch.id_schedule_type "
        query += " LEFT JOIN tb_emp_attn at_in On at_in.id_employee=sch.id_employee And Date(at_in.datetime) = sch.Date And at_in.type_log = 1 "
        query += " LEFT JOIN tb_emp_attn at_out On at_out.id_employee=sch.id_employee And Date(at_out.datetime) = sch.Date And at_out.type_log = 2 "
        query += " LEFT JOIN tb_emp_attn at_brout On at_brout.id_employee=sch.id_employee And Date(at_brout.datetime) = sch.Date And at_brout.type_log = 3 "
        query += " LEFT JOIN tb_emp_attn at_brin On at_brin.id_employee=sch.id_employee And Date(at_brin.datetime) = sch.Date And at_brin.type_log = 4 "
        query += " WHERE emp.id_departement Like '" & dept & "' AND sch.date >='" & date_start & "' AND sch.date <='" & date_until & "' "
        query += " GROUP BY sch.id_schedule"
        query += " ) tb"
        query += " INNER JOIN tb_m_departement dep On dep.id_departement=tb.id_departement"
        query += " GROUP BY tb.id_employee"

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

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        getReport()
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
        Report.LDept.Text = LEDept.Text
        Report.LDateRange.Text = Date.Parse(DEStart.EditValue.ToString).ToString("dd MMM yyyy") + " - " + Date.Parse(DEUntil.EditValue.ToString).ToString("dd MMM yyyy")

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
        getReportSum()
    End Sub

    Private Sub DEStartSum_EditValueChanged(sender As Object, e As EventArgs) Handles DEStartSum.EditValueChanged
        Try
            DEUntilSum.Properties.MinValue = DEStartSum.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEUntil.Properties.MinValue = DEStart.EditValue
        Catch ex As Exception
        End Try
    End Sub
End Class