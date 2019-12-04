Public Class ReportSalarySlip
    Public where_string As String = ""
    Public id_payroll As String = ""
    Private Sub ReportEmpUni_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim is_thr As String = execute_query("SELECT is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = (SELECT id_payroll_type FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + ")", 0, True, "", "", "", "")

        If is_thr = "1" Then
            XLWorking.Text = "Working Years"

            XLHouse.Visible = False
            XLHouse2.Visible = False
            LHousingAllow.Visible = False
            XLAttendance.Visible = False
            XLAttendance2.Visible = False
            LAttnAllow.Visible = False
            XLOvertime.Visible = False
            XLOvertime2.Visible = False
            LOvertimePay.Visible = False
            XLRemaining.Visible = False
            XLRemaining2.Visible = False
            LDPPay.Visible = False
            XLBonus.Visible = False
            XLBonus2.Visible = False
            LBonus.Visible = False
            XLOvertimeHours.Visible = False
            XLOvertimeHours2.Visible = False
            LOvertimePoint.Visible = False

            XLDeduction.Text = ""
            XLDeduction2.Text = ""
            LTotalDeduction.Text = ""

            XPDeduction.Visible = False

            XLAdjustment.LocationF = New PointF(0, 202.61)
            XLAdjustment2.LocationF = New PointF(317.5, 202.61)
            LAdjustment.LocationF = New PointF(349.25, 202.61)

            XLWorking.LocationF = New PointF(608.01, 202.61)
            XLWorking2.LocationF = New PointF(813.69, 202.61)
            LWorkingDays.LocationF = New PointF(845.44, 202.61)

            XPFooter.LocationF = New PointF(0, 272.61)
        End If

        Dim query As String = "CALL view_salary_slip('" & where_string & "','" & id_payroll & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        DataSource = data
    End Sub
End Class