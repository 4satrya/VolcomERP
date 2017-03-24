Public Class ReportEmpChSchedule
    Public Shared id_report As String = "-1"
    Sub load_detail()
        Dim query As String = "SELECT emp.*,chsch.*,dep.departement FROM tb_emp_ch_schedule chsch
                                    INNER JOIN tb_m_employee emp ON emp.id_employee=chsch.id_employee 
                                    INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                    WHERE chsch.id_emp_ch_schedule='" & id_report & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        LNumber.Text = data.Rows(0)("emp_ch_schedule_number").ToString
        LName.Text = data.Rows(0)("employee_name").ToString
        LNIK.Text = data.Rows(0)("employee_code").ToString
        LPosition.Text = data.Rows(0)("employee_position").ToString
        LDept.Text = data.Rows(0)("departement").ToString
        '
        LChNote.Text = data.Rows(0)("note").ToString
        '
        load_det_ch_sch("1")
        load_det_ch_sch("2")
        '
    End Sub
    Sub load_det_ch_sch(ByVal opt As String)
        'opt : 1=from; 2=to;
        Dim query_det As String = "SELECT * FROM tb_emp_ch_schedule_det WHERE id_emp_ch_schedule='" & id_report & "' AND from_to='" & opt & "'"
        Dim data As DataTable = execute_query(query_det, -1, True, "", "", "", "")

        If opt = "1" Then
            LFChCode.Text = data.Rows(0)("shift_code").ToString
            LFChNote.Text = data.Rows(0)("note").ToString
            '
            LFChDate.Text = Date.Parse(data.Rows(0)("date").ToString).ToString("dd MMM yyyy")
            If Not data.Rows(0)("in").ToString = "" Then
                LFChIn.Text = Date.Parse(data.Rows(0)("in").ToString).ToString("HH : mm")
            End If
            If Not data.Rows(0)("out").ToString = "" Then
                LFChOut.Text = Date.Parse(data.Rows(0)("out").ToString).ToString("HH : mm")
            End If
        ElseIf opt = "2" Then
            LTChCode.Text = data.Rows(0)("shift_code").ToString
            LTChNote.Text = data.Rows(0)("note").ToString
            '
            LTChDate.Text = Date.Parse(data.Rows(0)("date").ToString).ToString("dd MMM yyyy")
            If Not data.Rows(0)("in").ToString = "" Then
                LTChIn.Text = Date.Parse(data.Rows(0)("in").ToString).ToString("HH : mm")
            End If
            If Not data.Rows(0)("out").ToString = "" Then
                LTChOut.Text = Date.Parse(data.Rows(0)("out").ToString).ToString("HH : mm")
            End If

        End If
    End Sub
    Private Sub ReportLeave_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        load_detail()

        load_mark_horz_side("98", id_report, "2", "1", XrTable1, "1")

        BSideRight.HeightF = BSideRight.HeightF + (25.0F * 4)
        BSideLeft.HeightF = BSideLeft.HeightF + (25.0F * 4)
    End Sub
End Class