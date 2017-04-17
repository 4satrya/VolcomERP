Public Class FormEmpDPDet
    Public id_employee As String = "-1"
    Public id_emp_dp As String = "-1"
    '
    Public is_view As String = "-1"
    '
    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub
    '
    Private Sub FormEmpDPDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    '
    Private Sub BPickEmployee_Click(sender As Object, e As EventArgs) Handles BPickEmployee.Click
        FormPopUpEmployee.id_popup = "3"
        FormPopUpEmployee.ShowDialog()
    End Sub
    '
    Private Sub FormEmpDPDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TENumber.Text = header_number_emp("2")
        DEDateCreated.EditValue = Now
        '
        If id_emp_dp = "-1" Then 'new
            BMark.Visible = False
            BPrint.Visible = False
            BSave.Visible = True
        Else 'edit
            BMark.Visible = True
            BPrint.Visible = True
            BSave.Visible = False
            '
            Dim query As String = "SELECT dp.dp_note,emp.employee_name,emp.employee_position,dep.departement,rpt.report_status,emp.employee_code,dp.* FROM tb_emp_dp dp
                                INNER JOIN tb_m_employee emp ON emp.id_employee=dp.id_employee
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                INNER JOIN tb_lookup_report_status rpt ON rpt.id_report_status=dp.id_report_status
                                WHERE dp.id_dp='" & id_emp_dp & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            DEDateCreated.EditValue = data.Rows(0)("dp_date_created")
            TENumber.Text = data.Rows(0)("dp_number").ToString
            '
            TEEmployeeCode.Text = data.Rows(0)("employee_code").ToString
            TEEmployeeName.Text = data.Rows(0)("employee_name").ToString
            TEDept.Text = data.Rows(0)("departement").ToString
            TEPosition.Text = data.Rows(0)("employee_position").ToString
            '
            id_employee = data.Rows(0)("id_employee").ToString
            MEDPNote.Text = data.Rows(0)("dp_note").ToString
            '
            If is_view = "1" Or check_edit_report_status(id_emp_dp, "97", id_emp_dp) Then
                BPickEmployee.Visible = False
                TEEmployeeCode.Properties.ReadOnly = True
                MEDPNote.ReadOnly = True
                BSave.Visible = False
                BPrint.Visible = False
            End If
        End If
        load_det()
    End Sub
    Sub load_det()
        Dim query As String = "SELECT * FROM tb_emp_dp_det WHERE id_dp='" & id_emp_dp & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCDP.DataSource = data
        calc()
        show_but()
    End Sub
    Sub show_but()
        If GVDP.RowCount > 0 Then
            BDelDP.Visible = True
        Else
            BDelDP.Visible = False
        End If
    End Sub
    Sub calc()
        If GVDP.RowCount > 0 Then
            TETotHour.EditValue = GVDP.Columns("subtotal_hour").SummaryItem.SummaryValue
        End If
    End Sub

    Private Sub TEEmployeeCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TEEmployeeCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            load_emp_detail()
            BAddDP.Focus()
        End If
    End Sub
    Sub load_emp_detail()
        Dim query As String = "SELECT emp.*,dep.departement FROM tb_m_employee emp INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement WHERE employee_code='" & TEEmployeeCode.Text & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            TEEmployeeName.Text = data.Rows(0)("employee_name").ToString
            TEDept.Text = data.Rows(0)("departement").ToString
            TEPosition.Text = data.Rows(0)("employee_position").ToString
            id_employee = data.Rows(0)("id_employee").ToString
            '
        Else
            stopCustom("No employee found.")
        End If
    End Sub
    Private Sub FormempDPdet_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        TEEmployeeCode.Focus()
    End Sub

    Private Sub DEStartDP_EditValueChanged(sender As Object, e As EventArgs)
        calc()
    End Sub

    Private Sub DEUntilDP_EditValueChanged(sender As Object, e As EventArgs)
        calc()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If id_emp_dp = "-1" Then 'new
            If GVDP.RowCount > 0 Then
                Dim query As String = "INSERT INTO tb_emp_dp(dp_number,id_employee,dp_date_created,dp_total,dp_note)
                                        VALUES('" & header_number_emp("2") & "','" & id_employee & "',NOW(),'" & TETotHour.EditValue.ToString & "','" & MEDPNote.Text & "');SELECT LAST_INSERT_ID();"
                id_emp_dp = execute_query(query, 0, True, "", "", "", "")
                query = "INSERT INTO tb_emp_dp_det(id_dp,dp_time_start,dp_time_end,remark,subtotal_hour) VALUES"
                For i As Integer = 0 To GVDP.RowCount - 1
                    Dim subtot_hr As Integer = GVDP.GetRowCellValue(i, "subtotal_hour")
                    Dim dt_start As Date = GVDP.GetRowCellValue(i, "dp_time_start")
                    Dim dt_end As Date = GVDP.GetRowCellValue(i, "dp_time_end")
                    Dim remark As String = GVDP.GetRowCellValue(i, "remark").ToString

                    If Not i = 0 Then
                        query += ","
                    End If
                    query += "('" & id_emp_dp & "','" & Date.Parse(dt_start.ToString).ToString("yyyy-MM-dd H:mm:ss") & "','" & Date.Parse(dt_end.ToString).ToString("yyyy-MM-dd H:mm:ss") & "','" & remark & "','" & decimalSQL(subtot_hr.ToString).ToString & "')"
                Next
                execute_non_query(query, True, "", "", "", "")
                submit_who_prepared("97", id_emp_dp, id_user)
                infoCustom("DP registered, waiting approval.")
                FormEmpDP.load_dp()
                FormEmpDP.GVLeave.FocusedRowHandle = find_row(FormEmpDP.GVLeave, "id_dp", id_emp_dp)
                Close()
            Else
                stopCustom("Please insert DP detail first.")
            End If
        Else
            If GVDP.RowCount > 0 Then
                Dim query As String = "UDPATE tb_emp_dp SET id_employee='" & id_employee & "',dp_total='" & TETotHour.EditValue.ToString & "',dp_note='" & MEDPNote.Text & "' WHERE id_dp='" & id_emp_dp & "'"
                execute_non_query(query, True, "", "", "", "")
                '
                query = "DELETE FROM tb_emp_dp WHERE id_dp='" & id_emp_dp & "'"
                execute_non_query(query, True, "", "", "", "")
                '
                query = "INSERT INTO tb_emp_dp_det(id_dp,dp_time_start,dp_time_end,remark,subtotal_hour) VALUES"
                For i As Integer = 0 To GVDP.RowCount - 1
                    Dim subtot_hr As Integer = GVDP.GetRowCellValue(i, "subtotal_hour")
                    Dim dt_start As Date = GVDP.GetRowCellValue(i, "dp_time_start")
                    Dim dt_end As Date = GVDP.GetRowCellValue(i, "dp_time_end")
                    Dim remark As Date = GVDP.GetRowCellValue(i, "remark")

                    If Not i = 0 Then
                        query += ","
                    End If
                    query += "('" & id_emp_dp & "','" & Date.Parse(dt_start.ToString).ToString("yyyy-MM-dd H:mm:ss") & "','" & Date.Parse(dt_end.ToString).ToString("yyyy-MM-dd H:mm:ss") & "','" & remark & "','" & decimalSQL(subtot_hr.ToString).ToString & "')"
                Next
                execute_non_query(query, True, "", "", "", "")
                infoCustom("DP updated")
                FormEmpDP.load_dp()
                FormEmpDP.GVLeave.FocusedRowHandle = find_row(FormEmpDP.GVLeave, "id_dp", id_emp_dp)
                Close()
            Else
                stopCustom("Please insert DP detail first.")
            End If
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "97"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_emp_dp
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        ReportEmpDP.id_report = id_emp_dp

        Dim Report As New ReportEmpDP()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BAddDP_Click(sender As Object, e As EventArgs) Handles BAddDP.Click
        FormEmpDPPick.ShowDialog()
    End Sub

    Private Sub BDelDP_Click(sender As Object, e As EventArgs) Handles BDelDP.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            GVDP.DeleteSelectedRows()
            calc()
        End If
    End Sub
End Class