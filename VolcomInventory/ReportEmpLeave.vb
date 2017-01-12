Public Class ReportEmpLeave
    Public Shared report_mark_type As String = "-1"
    Public Shared id_report As String = "-1"

    Sub load_detail()
        Dim query As String = "SELECT formdc.form_dc,empl.emp_leave_number,empl.leave_purpose,lt.leave_type,empl.report_mark_type, empl.id_leave_type,
                                emp.employee_name, emp.employee_code, emp.employee_position, dep.departement, 
                                emp_ch.employee_name AS name_ch, emp_ch.employee_code AS code_ch,emp.employee_join_date,
                                ROUND(empl.leave_remaining/60) AS leave_remaining,ROUND(empl.leave_total/60) AS leave_total,
                                periode.start_periode,periode.end_periode
                                FROM tb_emp_leave empl
                                INNER JOIN tb_lookup_leave_type lt ON lt.id_leave_type=empl.id_leave_type
                                INNER JOIN tb_m_employee emp ON emp.id_employee=empl.id_emp
                                INNER JOIN tb_m_employee emp_ch ON emp_ch.id_employee=empl.id_emp_change
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                LEFT JOIN tb_lookup_form_dc formdc ON formdc.id_form_dc=empl.id_form_dc
                                LEFT JOIN (SELECT id_emp_leave,MIN(datetime_start) AS start_periode,MAX(datetime_until) AS end_periode FROM tb_emp_leave_det GROUP BY id_emp_leave)
                                periode ON periode.id_emp_leave=empl.id_emp_leave
                                WHERE empl.id_emp_leave='" & id_report & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        LNumber.Text = data.Rows(0)("emp_leave_number").ToString
        LName.Text = data.Rows(0)("employee_name").ToString
        LNIK.Text = data.Rows(0)("employee_code").ToString
        LPosition.Text = data.Rows(0)("employee_position").ToString
        LDept.Text = data.Rows(0)("departement").ToString
        LJoinDate.Text = Date.Parse(data.Rows(0)("employee_join_date").ToString).ToString("dd MMMM yyyy")
        LFormDC.Text = data.Rows(0)("form_dc").ToString
        '
        LLeaveType.Text = data.Rows(0)("leave_type").ToString
        LLeavePeriode.Text = Date.Parse(data.Rows(0)("start_periode").ToString).ToString("dd MMMM yyyy HH:mm") & " until " & Date.Parse(data.Rows(0)("end_periode").ToString).ToString("dd MMMM yyyy HH:mm")
        LLeavePurpose.Text = data.Rows(0)("leave_purpose").ToString
        LReplacedBy.Text = data.Rows(0)("name_ch").ToString
        LReplacedByNIK.Text = data.Rows(0)("code_ch").ToString
        '
        LRemainingLeave.Text = data.Rows(0)("leave_remaining").ToString & " hour(s)"
        If data.Rows(0)("id_leave_type").ToString = "1" Then
            LLeaveUsage.Text = data.Rows(0)("leave_total").ToString & " hour(s)"
            LRemainingAfter.Text = (data.Rows(0)("leave_remaining") - data.Rows(0)("leave_total")).ToString & " hour(s)"
        Else
            LLeaveUsage.Text = data.Rows(0)("leave_total").ToString & "(0) hour(s)"
            LRemainingAfter.Text = data.Rows(0)("leave_remaining").ToString & " hour(s)"
        End If
        '
        report_mark_type = data.Rows(0)("report_mark_type").ToString
    End Sub
    Private Sub ReportLeave_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        load_detail()

        If report_mark_type = "95" Then
            load_mark_horz_side("95", id_report, "2", "1", XrTable1)
        ElseIf report_mark_type = "96" Then
            load_mark_horz_side("96", id_report, "2", "1", XrTable1)
        ElseIf report_mark_type = "99" Then
            load_mark_horz_side("99", id_report, "2", "1", XrTable1)
        End If
        BSideRight.HeightF = BSideRight.HeightF + (25.0F * 4)
        BSideLeft.HeightF = BSideLeft.HeightF + (25.0F * 4)
    End Sub
End Class