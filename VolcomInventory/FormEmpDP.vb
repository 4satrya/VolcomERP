Public Class FormEmpDP
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Public is_propose As String = "-1"

    Private Sub FormEmpDP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_date()
    End Sub
    Sub load_dp()
        Dim date_from As String = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_end As String = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim query As String = "SELECT det.start_dp,det.end_dp,emp.employee_name,emp.employee_position,dep.departement,rpt.report_status,emp.employee_code,dp.* FROM tb_emp_dp dp
                                INNER JOIN tb_m_employee emp ON emp.id_employee=dp.id_employee
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                INNER JOIN tb_lookup_report_status rpt ON rpt.id_report_status=dp.id_report_status
                                LEFT JOIN 
                                (SELECT id_dp,MIN(dp_time_start) AS start_dp,MAX(dp_time_end) AS end_dp FROM tb_emp_dp_det GROUP BY id_dp) det ON det.id_dp=dp.id_dp
                                WHERE DATE(dp.dp_date_created) >= DATE('" & date_from & "') AND DATE(dp.dp_date_created) <= DATE('" & date_end & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCLeave.DataSource = data
    End Sub
    Sub load_dp_date()
        Dim date_from As String = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_end As String = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim query As String = "SELECT det.start_dp,det.end_dp,emp.employee_name,emp.employee_position,dep.departement,rpt.report_status,emp.employee_code,dp.* FROM tb_emp_dp dp
                                INNER JOIN tb_m_employee emp ON emp.id_employee=dp.id_employee
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                INNER JOIN tb_lookup_report_status rpt ON rpt.id_report_status=dp.id_report_status
                                INNER JOIN 
                                (SELECT id_dp,MIN(dp_time_start) AS start_dp,MAX(dp_time_end) AS end_dp 
                                FROM tb_emp_dp_det 
                                WHERE (DATE(dp_time_start) >= DATE('" & date_from & "') AND DATE(dp_time_start) <= DATE('" & date_end & "')) OR (DATE(dp_time_end) >= DATE('" & date_from & "') AND DATE(dp_time_end) <= DATE('" & date_end & "'))
                                GROUP BY id_dp) det ON det.id_dp=dp.id_dp"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCLeave.DataSource = data
    End Sub
    Sub load_date()
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
    End Sub

    Private Sub FormEmpDP_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpDP_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BViewSum_Click(sender As Object, e As EventArgs) Handles BViewSum.Click
        load_dp()
    End Sub

    Private Sub BViewDP_Click(sender As Object, e As EventArgs) Handles BViewDP.Click
        load_dp_date()
    End Sub
End Class