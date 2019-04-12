Public Class FormEmpPayrollOvertime
    Public id_periode As String = "-1"
    Private Sub FormEmpPayrollOvertime_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpPayrollOvertime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_payroll_periode()
        load_payroll_ot()
        load_payroll_dp()
    End Sub

    Sub load_payroll_periode()
        Dim query As String = "SELECT p.id_payroll,p.ot_periode_start,p.ot_periode_end,DATE_FORMAT(`ot_periode_end`,'%M %Y') as periode FROM tb_emp_payroll p"
        viewLookupQuery(LEPayrollPeriode, query, 0, "periode", "id_payroll")
        If Not id_periode = "-1" Then
            LEPayrollPeriode.ItemIndex = LEPayrollPeriode.Properties.GetDataSourceRowIndex("id_payroll", id_periode)
        End If
    End Sub

    Sub load_payroll_ot()
        Dim query As String = "SELECT p.id_payroll_ot,p.`id_payroll`,p.`id_employee`,p.`id_ot_type`,p.`ot_start`,p.`ot_end`,p.`total_hour`,p.`total_point`,IF(p.`is_day_off`=1,'Yes','No') AS day_off,lvl.`employee_level`,emp.`employee_name`,emp.`employee_code`,ott.`ot_type`
                                FROM tb_emp_payroll_ot p
                                INNER JOIN `tb_lookup_ot_type` ott ON ott.`id_ot_type`=p.`id_ot_type`
                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=p.`id_employee`
                                INNER JOIN `tb_lookup_employee_level` lvl ON lvl.`id_employee_level`=emp.`id_employee_level`
                                WHERE p.`id_payroll`='" & LEPayrollPeriode.EditValue.ToString & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOverTime.DataSource = data
    End Sub
    Sub load_payroll_dp()
        Dim query As String = "SELECT det.start_dp,det.end_dp,emp.employee_name,emp.employee_position,dep.departement,rpt.report_status,emp.employee_code,dp.* FROM tb_emp_dp dp
                                INNER JOIN tb_m_employee emp ON emp.id_employee=dp.id_employee
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                INNER JOIN tb_lookup_report_status rpt ON rpt.id_report_status=dp.id_report_status
                                INNER JOIN 
                                (SELECT id_dp,MIN(dp_time_start) AS start_dp,MAX(dp_time_end) AS end_dp 
                                FROM tb_emp_dp_det 
                                GROUP BY id_dp) det ON det.id_dp=dp.id_dp
                                WHERE id_payroll='" & LEPayrollPeriode.EditValue.ToString & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDP.DataSource = data
    End Sub
    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        load_add()
    End Sub

    Sub load_add()
        FormEmpPayrollOvertimeDet.id_overtime = "-1"
        FormEmpPayrollOvertimeDet.ShowDialog()
    End Sub

    Private Sub LEPayrollPeriode_EditValueChanged(sender As Object, e As EventArgs) Handles LEPayrollPeriode.EditValueChanged
        load_payroll_ot()
        load_payroll_dp()
    End Sub

    Private Sub BEdit_Click(sender As Object, e As EventArgs) Handles BEdit.Click
        FormEmpPayrollOvertimeDet.id_overtime = GVOverTime.GetFocusedRowCellValue("id_payroll_ot").ToString
        FormEmpPayrollOvertimeDet.ShowDialog()
    End Sub

    Private Sub FormEmpPayrollOvertime_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Add Then
            load_add()
        End If
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            Dim query As String = "DELETE FROM tb_emp_payroll_ot WHERE id_payroll_ot='" & GVOverTime.GetFocusedRowCellValue("id_payroll_ot").ToString & "'"
            execute_non_query(query, True, "", "", "", "")
            load_payroll_ot()
        End If
    End Sub

    Private Sub BOvertimeWindow_Click(sender As Object, e As EventArgs) Handles BOvertimeWindow.Click
        Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(LEPayrollPeriode, DevExpress.XtraEditors.LookUpEdit)
        Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)

        FormEmpPayrollOvertimePick.date_start = Date.Parse(row("ot_periode_start").ToString).ToString("yyyy-MM-dd")
        FormEmpPayrollOvertimePick.date_end = Date.Parse(row("ot_periode_end").ToString).ToString("yyyy-MM-dd")
        FormEmpPayrollOvertimePick.ShowDialog()
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        load_payroll_ot()
        load_payroll_dp()
    End Sub
End Class