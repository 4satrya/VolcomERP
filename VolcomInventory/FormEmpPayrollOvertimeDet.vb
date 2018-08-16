Public Class FormEmpPayrollOvertimeDet
    Public id_overtime As String = "-1"
    Public id_employee As String = "-1"

    Public is_store_employee As String = "-1"

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormEmpPayrollOvertimeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_dp_or_not()
        Dim query As String = "SELECT '1' AS is_not_dp,'Convert to Salary' AS type 
                                UNION
                               SELECT '2' AS is_not_dp,'Convert to DP' AS type "
        viewLookupQuery(LEOVertimeDPOrNot, query, 0, "type", "is_not_dp")
    End Sub

    Sub load_dp_type()
        Dim query As String = "SELECT '1' AS id_dp_type,'Convert based on hours' AS type 
                                UNION
                               SELECT '2' AS id_dp_type,'Convert based on point' AS type "
        viewLookupQuery(LEDPType, query, 0, "type", "id_dp_type")
    End Sub

    Private Sub FormEmpPayrollOvertimeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEPoint.EditValue = 0.0
        TETotHour.EditValue = 0.0
        TEBreak.EditValue = 0.0
        TEPointWages.EditValue = 0.00
        load_dayoff()
        load_ot_type()
        '
        load_dp_or_not()
        load_dp_type()
        '
        If Not id_overtime = "-1" Then 'edit
            Dim query As String = "SELECT p.id_payroll_ot,p.`id_payroll`,p.`id_employee`,p.`id_ot_type`,p.total_break,p.`ot_start`,p.`ot_end`,p.`total_hour`,p.`total_point`,IF(p.`is_day_off`=1,'Yes','No') AS day_off,p.`is_day_off`,lvl.`employee_level`,emp.`employee_name`,emp.`employee_code`,ott.`ot_type`,ott.id_ot_type,p.note,p.wages_per_point
                                FROM tb_emp_payroll_ot p
                                INNER JOIN `tb_lookup_ot_type` ott ON ott.`id_ot_type`=p.`id_ot_type`
                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=p.`id_employee`
                                INNER JOIN `tb_lookup_employee_level` lvl ON lvl.`id_employee_level`=emp.`id_employee_level`
                                WHERE p.`id_payroll_ot`='" & id_overtime & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TEEmployeeCode.Text = data.Rows(0)("employee_code").ToString
                TEEmployeeName.Text = data.Rows(0)("employee_name").ToString
                id_employee = data.Rows(0)("id_employee").ToString
                '
                LEDayoff.ItemIndex = LEDayoff.Properties.GetDataSourceRowIndex("is_dayoff", data.Rows(0)("is_day_off").ToString)
                LECategory.ItemIndex = LECategory.Properties.GetDataSourceRowIndex("id_ot_type", data.Rows(0)("id_ot_type").ToString)
                '
                DEStart.EditValue = data.Rows(0)("ot_start")
                DEUntil.EditValue = data.Rows(0)("ot_end")
                '
                TEBreak.EditValue = data.Rows(0)("total_break")
                TETotHour.EditValue = data.Rows(0)("total_hour")
                TEPoint.EditValue = data.Rows(0)("total_point")
                TEPointWages.EditValue = data.Rows(0)("wages_per_point")
                MENote.Text = data.Rows(0)("note")
                '
                LEOVertimeDPOrNot.Enabled = False
                LEDPType.Enabled = False
                '
            End If
        End If
    End Sub

    Sub load_dayoff()
        Dim query As String = "SELECT '1' AS is_dayoff,'Yes' AS dayoff
                                UNION
                                SELECT '2' AS is_dayoff,'No' AS dayoff"
        viewLookupQuery(LEDayoff, query, 0, "dayoff", "is_dayoff")
    End Sub

    Sub load_ot_type()
        Dim query As String = "SELECT id_ot_type,ot_type,IF(is_event='1','Yes','No') AS is_event,ot_point_wages FROM tb_lookup_ot_type"
        viewLookupQuery(LECategory, query, 0, "ot_type", "id_ot_type")
    End Sub

    Private Sub BPickEmployee_Click(sender As Object, e As EventArgs) Handles BPickEmployee.Click
        FormPopUpEmployee.id_popup = "5"
        FormPopUpEmployee.ShowDialog()
    End Sub

    Private Sub TEEmployeeCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TEEmployeeCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            load_emp_detail()
            LEDayoff.Focus()
        End If
    End Sub
    Sub load_emp_detail()
        Dim query As String = "SELECT emp.*,dep.departement FROM tb_m_employee emp INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement WHERE employee_code='" & TEEmployeeCode.Text & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            TEEmployeeName.Text = data.Rows(0)("employee_name").ToString
            id_employee = data.Rows(0)("id_employee").ToString
            '
        Else
            stopCustom("No employee found.")
        End If
    End Sub

    Private Sub LEDayoff_KeyDown(sender As Object, e As KeyEventArgs) Handles LEDayoff.KeyDown
        If e.KeyCode = Keys.Enter Then
            LECategory.Focus()
        End If
    End Sub

    Private Sub LECategory_KeyDown(sender As Object, e As KeyEventArgs) Handles LECategory.KeyDown
        If e.KeyCode = Keys.Enter Then
            TEPointWages.Focus()
        End If
    End Sub
    Private Sub TEPointWages_KeyDown(sender As Object, e As KeyEventArgs) Handles TEPointWages.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEStart.Focus()
        End If
    End Sub
    Private Sub DEStart_KeyDown(sender As Object, e As KeyEventArgs) Handles DEStart.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntil.Focus()
        End If
    End Sub

    Private Sub DEUntil_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntil.KeyDown
        If e.KeyCode = Keys.Enter Then
            TEBreak.Focus()
        End If
    End Sub

    Private Sub MENote_KeyDown(sender As Object, e As KeyEventArgs) Handles MENote.KeyDown
        If e.KeyCode = Keys.Enter Then
            BSave.Focus()
        End If
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEUntil.Properties.MinValue = DEStart.EditValue
            calc()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TEBreak_KeyDown(sender As Object, e As KeyEventArgs) Handles TEBreak.KeyDown
        If e.KeyCode = Keys.Enter Then
            MENote.Focus()
        End If
    End Sub

    Sub calc()
        Try
            If Not DEStart.EditValue > DEUntil.EditValue Then
                '
                Dim date_start As Date = DEStart.EditValue
                Dim date_until As Date = DEUntil.EditValue
                Dim time_diff As TimeSpan
                Dim diff As Decimal = 0.0
                Dim break As Decimal = 0.0

                Try
                    break = TEBreak.EditValue
                Catch ex As Exception
                End Try

                time_diff = date_until - date_start
                'nearest 0.5
                'diff = Math.Round((time_diff.TotalHours * 2), MidpointRounding.AwayFromZero) / 2
                'rounddown 0.5
                diff = Math.Floor(time_diff.TotalHours / 0.5) * 0.5
                TETotHour.EditValue = diff - break
            Else
                '
                TETotHour.EditValue = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        calc()
    End Sub

    Private Sub TEBreak_EditValueChanged(sender As Object, e As EventArgs) Handles TEBreak.EditValueChanged
        calc()
    End Sub

    Sub calc_point()
        Try
            Dim tot_hour As Decimal = 0.0
            Dim tot_point As Decimal = 0.0

            tot_hour = TETotHour.EditValue

            If LEDayoff.EditValue.ToString = "1" Then
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
            TEPoint.EditValue = tot_point
        Catch ex As Exception
            TEPoint.EditValue = 0
        End Try
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim dt_start As Date = DEStart.EditValue
        Dim dt_end As Date = DEUntil.EditValue
        Dim id_payroll As String = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString

        Dim tot_hour As String = decimalSQL(TETotHour.EditValue.ToString)
        Dim tot_break As String = decimalSQL(TEBreak.EditValue.ToString)
        Dim tot_poin As String = decimalSQL(TEPoint.EditValue.ToString)
        Dim wages_per_point As String = decimalSQL(TEPointWages.EditValue.ToString)
        Dim note As String = MENote.Text

        If id_overtime = "-1" Then 'new
            If LEOVertimeDPOrNot.EditValue.ToString = "1" Then 'salary
                Dim query As String = "INSERT INTO tb_emp_payroll_ot(id_payroll,id_employee,id_ot_type,ot_start,ot_end,total_break,total_hour,total_point,is_day_off,wages_per_point,note)
                                    VALUES('" & id_payroll & "','" & id_employee & "','" & LECategory.EditValue.ToString & "','" & Date.Parse(dt_start.ToString).ToString("yyyy-MM-dd H:mm:ss") & "','" & Date.Parse(dt_end.ToString).ToString("yyyy-MM-dd H:mm:ss") & "','" & tot_break & "','" & tot_hour & "','" & tot_poin & "','" & LEDayoff.EditValue.ToString & "','" & wages_per_point & "','" & note & "');SELECT LAST_INSERT_ID();"
                id_overtime = execute_query(query, 0, True, "", "", "", "")
                FormEmpPayrollOvertime.load_payroll_ot()
                FormEmpPayrollOvertime.GVOverTime.FocusedRowHandle = find_row(FormEmpPayrollOvertime.GVOverTime, "id_payroll_ot", id_overtime)
                Close()
            Else 'DP
                Dim id_sch As String = ""
                Dim query_sch As String = "SELECT sch.id_schedule,sch.`date` FROM tb_emp_schedule sch
                                            WHERE sch.id_employee='" & id_employee & "'  
                                            AND sch.`date`='" & Date.Parse(dt_start.ToString).ToString("yyyy-MM-dd") & "'"
                Dim data_sch As DataTable = execute_query(query_sch, -1, True, "", "", "", "")
                '
                If data_sch.Rows.Count > 0 Then
                    Dim tot_dp As String = ""

                    If LEDPType.EditValue.ToString = "1" Then 'convert based hours
                        tot_dp = tot_hour
                    Else 'convert based point
                        tot_dp = Math.Floor(TEPoint.EditValue).ToString
                    End If
                    Dim query_dp As String = "INSERT INTO tb_emp_dp(dp_number,id_employee,dp_date_created,dp_total,dp_note,id_payroll)
                                    VALUES('" & header_number_emp("2") & "','" & id_employee & "',NOW(),'0','" & note & "','" & id_payroll & "');SELECT LAST_INSERT_ID();"
                    Dim id_dp_parent As String = execute_query(query_dp, 0, True, "", "", "", "")
                    increase_inc_emp("2")
                    'detail
                    query_dp = "INSERT INTO tb_emp_dp_det(id_dp,dp_time_start,dp_time_end,remark,subtotal_hour) VALUES"
                    query_dp += "('" & id_dp_parent & "','" & Date.Parse(dt_start.ToString).ToString("yyyy-MM-dd H:mm:ss") & "','" & Date.Parse(dt_end.ToString).ToString("yyyy-MM-dd H:mm:ss") & "','" & note & "','" & tot_dp & "')"
                    execute_non_query(query_dp, True, "", "", "", "")
                    Close()
                Else
                    stopCustom("Please assign this employee a schedule for this date first!")
                End If
                '
            End If
        Else 'edit
            Dim query As String = "UPDATE tb_emp_payroll_ot SET id_payroll='" & id_payroll & "',id_employee='" & id_employee & "',id_ot_type='" & LECategory.EditValue.ToString & "',ot_start='" & Date.Parse(dt_start.ToString).ToString("yyyy-MM-dd H:mm:ss") & "',ot_end='" & Date.Parse(dt_end.ToString).ToString("yyyy-MM-dd H:mm:ss") & "',total_break='" & tot_break & "',total_hour='" & tot_hour & "',total_point='" & tot_poin & "',is_day_off='" & LEDayoff.EditValue.ToString & "',wages_per_point='" & wages_per_point & "',note='" & note & "'
                                    WHERE id_payroll_ot='" & id_overtime & "'"
            execute_non_query(query, True, "", "", "", "")

            FormEmpPayrollOvertime.load_payroll_ot()
            FormEmpPayrollOvertime.load_payroll_dp()
            FormEmpPayrollOvertime.GVOverTime.FocusedRowHandle = find_row(FormEmpPayrollOvertime.GVOverTime, "id_payroll_ot", id_overtime)

            execute_non_query(query, True, "", "", "", "")
            Close()
        End If
    End Sub

    Private Sub TETotHour_EditValueChanged(sender As Object, e As EventArgs) Handles TETotHour.EditValueChanged
        calc_point()
    End Sub

    Private Sub LECategory_EditValueChanged(sender As Object, e As EventArgs) Handles LECategory.EditValueChanged
        Try
            TEPointWages.EditValue = LECategory.GetSelectedDataRow("ot_point_wages")
        Catch ex As Exception
            TEPointWages.EditValue = 0.00
        End Try
    End Sub

    Private Sub LEOVertimeDPOrNot_EditValueChanged(sender As Object, e As EventArgs) Handles LEOVertimeDPOrNot.EditValueChanged
        If LEOVertimeDPOrNot.EditValue.ToString = "1" Then
            'not dp
            LEDPType.Visible = False
        Else
            LEDPType.Visible = True
        End If
    End Sub

    Private Sub LEDayoff_EditValueChanged(sender As Object, e As EventArgs) Handles LEDayoff.EditValueChanged
        calc_point()
    End Sub
End Class