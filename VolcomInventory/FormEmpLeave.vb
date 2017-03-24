Public Class FormEmpLeave
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Public is_propose As String = "-1"
    '
    Public is_hrd As String = "-1"
    Private Sub FormEmpLeave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
        '
    End Sub

    Private Sub FormEmpLeave_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpLeave_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpLeave_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEUntil.Properties.MinValue = DEStart.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BViewSum_Click(sender As Object, e As EventArgs) Handles BViewSum.Click
        load_sum()
    End Sub
    Sub load_sum()
        Dim date_from As String = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_end As String = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim query As String = "SELECT empl.*,empx.employee_name as who_create,empld.min_date,empld.max_date,status.report_status,emp.employee_name,emp.employee_code,empld.hours_total FROM tb_emp_leave empl
                                INNER JOIN tb_lookup_report_status STATUS ON status.id_report_status=empl.id_report_status
                                INNER JOIN tb_m_employee emp ON emp.id_employee=empl.id_emp
                                INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level  
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                LEFT JOIN tb_m_user usrx ON usrx.id_user=empl.id_user_who_create
                                LEFT JOIN tb_m_employee empx ON empx.id_employee=usrx.id_employee
                                INNER JOIN 
                                (SELECT id_emp_leave,MIN(datetime_start) AS min_date,MAX(datetime_until) AS max_date,ROUND(SUM(minutes_total)/60) AS hours_total FROM tb_emp_leave_det GROUP BY id_emp_leave) empld ON empld.id_emp_leave=empl.id_emp_leave
                                WHERE DATE(empl.emp_leave_date) >= DATE('" & date_from & "') AND DATE(empl.emp_leave_date) <= DATE('" & date_end & "')"
        If is_propose = "1" Then
            query += " AND empl.id_leave_type!=5"
            'Dim id_user_admin_management As String = get_opt_emp_field("id_user_admin_mng").ToString
            'If id_user_admin_management = id_user Then
            '    Dim id_min_lvl As String = get_opt_emp_field("leave_asst_mgr_level").ToString
            '    query += " AND lvl.id_employee_level>0 AND lvl.id_employee_level <'" & id_min_lvl & "' "
            'Else
            '    'query += " AND emp.id_departement='" & id_departement_user & "'"
            '    query += " AND (dep.id_user_admin='" & id_user & "' OR dep.id_user_admin_backup='" & id_user & "')"
            'End If
        End If
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCLeave.DataSource = data
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BViewOnLeave.Click
        Dim date_from As String = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_end As String = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim query As String = "SELECT empl.*,empld.min_date,empld.max_date,status.report_status,emp.employee_name,emp.employee_code,empld.hours_total  FROM tb_emp_leave empl
                                INNER JOIN tb_lookup_report_status STATUS ON status.id_report_status=empl.id_report_status
                                INNER JOIN tb_m_employee emp ON emp.id_employee=empl.id_emp
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level  
                                INNER JOIN (SELECT * FROM (SELECT * FROM tb_emp_leave_det empld_wh WHERE (DATE(empld_wh.datetime_start) >= DATE('" & date_from & "') AND DATE(empld_wh.datetime_start) <= DATE('" & date_end & "'))) empx GROUP BY empx.id_emp_leave) empldwh ON empldwh.id_emp_leave=empl.id_emp_leave 
                                INNER JOIN (SELECT id_emp_leave,MIN(datetime_start) AS min_date,MAX(datetime_until) AS max_date,ROUND(SUM(minutes_total)/60) AS hours_total FROM tb_emp_leave_det GROUP BY id_emp_leave) empld ON empld.id_emp_leave=empldwh.id_emp_leave"
        If is_propose = "1" Then
            query += " WHERE empl.id_leave_type!=5"
            'Dim id_user_admin_management As String = get_opt_emp_field("id_user_admin_mng").ToString
            'If id_user_admin_management = id_user Then
            '    Dim id_min_lvl As String = get_opt_emp_field("leave_asst_mgr_level").ToString
            '    query += " AND lvl.id_employee_level>0 AND lvl.id_employee_level <'" & id_min_lvl & "' "
            'Else
            '    query += " AND (dep.id_user_admin='" & id_user & "' OR dep.id_user_admin_backup='" & id_user & "')"
            'End If
        End If
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCLeave.DataSource = data
    End Sub
End Class