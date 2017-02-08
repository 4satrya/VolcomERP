Public Class FormEmpChSchedule
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Private Sub FormEmpChSchedule_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpChSchedule_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpChSchedule_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpChSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
        load_chschedule()
    End Sub

    Sub load_chschedule()
        Dim date_from As String = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_end As String = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim query As String = "SELECT ch.*,scd_from.date AS date_f,scd_from.shift_code as shift_code_f,scd_to.date AS date_t,scd_to.shift_code as shift_code_t ,status.report_status, emp.employee_code, emp.employee_name
                            FROM tb_emp_ch_schedule ch
                            INNER JOIN tb_m_employee emp ON emp.id_employee=ch.id_employee
                            INNER JOIN tb_emp_ch_schedule_det scd_from ON scd_from.id_emp_ch_schedule=ch.id_emp_ch_schedule AND scd_from.from_to='1'
                            INNER JOIN tb_emp_ch_schedule_det scd_to ON scd_to.id_emp_ch_schedule=ch.id_emp_ch_schedule AND scd_to.from_to='2'
                            INNER JOIN tb_lookup_report_status status ON status.id_report_status=ch.id_report_status
                            WHERE DATE(ch.emp_ch_schedule_date) >= DATE('" & date_from & "') AND DATE(ch.emp_ch_schedule_date) <= DATE('" & date_end & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCChangeSch.DataSource = data
        BGVChangeSch.BestFitColumns()
    End Sub

    Private Sub BViewSum_Click(sender As Object, e As EventArgs) Handles BViewSum.Click
        load_chschedule()
    End Sub
End Class