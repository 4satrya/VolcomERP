Public Class ReportEmpDP
    Public Shared id_report As String = "-1"
    Sub load_detail()
        Dim query As String = "SELECT dp.dp_note,emp.employee_name,emp.employee_position,dep.departement,rpt.report_status,emp.employee_code,dp.* FROM tb_emp_dp dp
                                INNER JOIN tb_m_employee emp ON emp.id_employee=dp.id_employee
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                INNER JOIN tb_lookup_report_status rpt ON rpt.id_report_status=dp.id_report_status
                                WHERE dp.id_dp='" & id_report & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        LNumber.Text = data.Rows(0)("dp_number").ToString
        LName.Text = data.Rows(0)("employee_name").ToString
        LNIK.Text = data.Rows(0)("employee_code").ToString
        LPosition.Text = data.Rows(0)("employee_position").ToString
        LDept.Text = data.Rows(0)("departement").ToString
        '
        LDPNote.Text = data.Rows(0)("dp_note").ToString
        '
        LDPPeriod.Text = Date.Parse(data.Rows(0)("dp_time_start").ToString).ToString("dd MMM yyyy H:mm:ss") & " until " & Date.Parse(data.Rows(0)("dp_time_end").ToString).ToString("dd MMM yyyy H:mm:ss")
        LDpTot.Text = data.Rows(0)("dp_total").ToString
        LDPExp.Text = Date.Parse(data.Rows(0)("dp_time_end").ToString).AddMonths(6).ToString("dd MMM yyyy")
        '
    End Sub
    Private Sub ReportLeave_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        load_detail()

        load_mark_horz_side("97", id_report, "2", "1", XrTable1, "1")

        BSideRight.HeightF = BSideRight.HeightF + (25.0F * 4)
        BSideLeft.HeightF = BSideLeft.HeightF + (25.0F * 4)
    End Sub
End Class