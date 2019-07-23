Public Class FormEmpPayrollOvertime
    Public id_periode As String = "-1"
    Private Sub FormEmpPayrollOvertime_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpPayrollOvertime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'load_payroll_periode()
        load_payroll_ot()
        load_payroll_dp()

        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = '" + FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + "'", 0, True, "", "", "", "")

        If id_report_status = "0" Then
            SBPrint.Enabled = False
        Else
            SBPrint.Enabled = True
        End If
    End Sub

    Sub load_payroll_periode()
        Dim query As String = "SELECT p.id_payroll,p.ot_periode_start,p.ot_periode_end,DATE_FORMAT(`ot_periode_end`,'%M %Y') as periode FROM tb_emp_payroll p WHERE id_payroll_type = 1"
        viewLookupQuery(LEPayrollPeriode, query, 0, "periode", "id_payroll")
        If Not id_periode = "-1" Then
            LEPayrollPeriode.ItemIndex = LEPayrollPeriode.Properties.GetDataSourceRowIndex("id_payroll", id_periode)
        End If
    End Sub

    Sub load_payroll_ot()
        Dim id_payroll As String = id_periode

        'get id_payroll if dw
        If FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString = "4" Then
            id_payroll = execute_query("
                SELECT id_payroll 
                FROM tb_emp_payroll
                WHERE periode_start = (SELECT periode_start FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + ") AND periode_end = (SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + ") AND id_payroll_type = 1
                LIMIT 1
            ", 0, True, "", "", "", "")
        End If

        'where organic or dw
        Dim where_staff As String = If(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString = "4", "emp.id_employee_status = 3", "emp.id_employee_status <> 3")

        'where wages dw
        Dim where_wages As String = If(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString = "4", "sal.`basic_salary` * 22", "sal.`basic_salary` + sal.`allow_job` + sal.`allow_meal` + sal.`allow_trans`")

        Dim query As String = "SELECT p.id_payroll_ot,p.`id_payroll`,IF(IFNULL(dep.is_office_payroll, dep_ori.is_office_payroll) = '2', 'STORE', 'OFFICE') AS group_report,p.`id_employee`,p.`id_ot_type`,DATE_FORMAT(p.`ot_start`, '%d %M %Y') AS ot_date, DATE_FORMAT(p.`ot_start`, '%d %b %Y %H:%i:%s') AS ot_start, DATE_FORMAT(p.`ot_end`, '%d %b %Y %H:%i:%s') AS ot_end,p.`total_break`,ROUND((TIMESTAMPDIFF(MINUTE, p.`ot_start`, p.`ot_end`) / 60) - p.`total_break`, 1) AS total_hour_actual,p.`total_hour`,p.`total_point`,IF(p.`is_day_off`=1,'Yes','No') AS day_off,IFNULL(dep.departement, dep_ori.departement) AS departement,IF(dep.id_departement = 17, IFNULL(sub.departement_sub, sub_ori.departement_sub), IFNULL(dep.departement, dep_ori.departement)) AS departement_sub,IFNULL(emp_pos.employee_position,emp.`employee_position`) AS employee_position,lvl.`employee_status`,emp.`employee_name`,emp.`employee_code`,CONCAT(IF(ott.`is_event` = 1, 'Event ', ''), ott.`ot_type`) AS ot_type, ROUND(IF(ott.`is_event` = 1, p.wages_per_point, ((SELECT (" + where_wages + ") FROM tb_emp_payroll_det AS pd LEFT JOIN tb_m_employee_salary AS sal ON pd.id_salary = sal.id_employee_salary WHERE pd.id_employee = p.`id_employee` AND pd.id_payroll = '" & id_periode & "') * (pay.ot_reg_pembilang / pay.ot_reg_penyebut))),10) AS wages_per_point, ROUND(IF(ott.`is_event` = 1, p.`total_point` * p.wages_per_point, p.`total_point` * ((SELECT (" + where_wages + ") FROM tb_emp_payroll_det AS pd LEFT JOIN tb_m_employee_salary AS sal ON pd.id_salary = sal.id_employee_salary WHERE pd.id_employee = p.`id_employee` AND pd.id_payroll = '" & id_periode & "') * (pay.ot_reg_pembilang / pay.ot_reg_penyebut))),10) AS wages_per_point_total, p.note, dep.is_office_payroll
                FROM tb_emp_payroll_ot p
                LEFT JOIN `tb_lookup_ot_type` ott ON ott.`id_ot_type`=p.`id_ot_type`
                LEFT JOIN tb_m_employee emp ON emp.`id_employee`=p.`id_employee`
                LEFT JOIN (
                    SELECT * FROM (
                        SELECT id_employee, id_departement, id_departement_sub, employee_position, employee_position_date
                        FROM tb_m_employee_position
                        WHERE employee_position_date <= (SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = '" & id_payroll & "')
                        ORDER BY id_employee_position DESC
                    ) AS tab
                    GROUP BY id_employee
                ) AS emp_pos ON p.id_employee = emp_pos.id_employee
                LEFT JOIN tb_m_departement dep ON dep.id_departement=emp_pos.id_departement
                LEFT JOIN tb_m_departement dep_ori ON dep_ori.id_departement = emp.id_departement
                LEFT JOIN tb_m_departement_sub sub ON sub.`id_departement_sub`=emp_pos.`id_departement_sub`
                LEFT JOIN tb_m_departement_sub sub_ori ON sub_ori.id_departement_sub = emp.id_departement_sub
                LEFT JOIN tb_emp_payroll pay ON p.`id_payroll`=pay.`id_payroll`
                LEFT JOIN `tb_lookup_employee_status` lvl ON lvl.`id_employee_status`=emp.`id_employee_status`
                WHERE p.`id_payroll`='" & id_payroll & "' AND " + where_staff + "
                ORDER BY emp.id_employee_status ASC, emp.employee_code ASC, p.`ot_start` ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOvertime.DataSource = data
        GVOvertime.BestFitColumns()
    End Sub
    Sub load_payroll_dp()
        Dim query As String = "SELECT ot_det.id_employee, employee.employee_code, employee.employee_name, dep.departement, employee.employee_position, employee_status.employee_status, DATE_FORMAT(ot.ot_date, '%d %M %Y') AS ot_date, DATE_FORMAT(ot_det.start_work, '%l:%i:%s %p') AS ot_start, DATE_FORMAT(ot_det.end_work, '%l:%i:%s %p') AS ot_end, ot_det.break_hours AS total_break, (TIMESTAMPDIFF(HOUR, ot_det.start_work, ot_det.end_work) - ot_det.break_hours) AS total_hour, ot.ot_note AS note
                                FROM tb_ot_det AS ot_det
                                LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
                                LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
                                LEFT JOIN tb_m_departement dep ON dep.`id_departement`=employee.`id_departement`
                                LEFT JOIN tb_lookup_employee_status AS employee_status ON employee.id_employee_status = employee_status.id_employee_status
                                WHERE ot_det.conversion_type = 2 AND ot_det.is_valid = 1 AND ot.id_check_status = 6 AND ot.id_payroll = '" + id_periode + "'
                                ORDER BY employee.id_employee_status ASC, employee.employee_code ASC, ot.ot_date ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDP.DataSource = data
        GVDP.BestFitColumns()
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
        FormEmpPayrollOvertimeDet.id_overtime = GVOvertime.GetFocusedRowCellValue("id_payroll_ot").ToString
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
            Dim query As String = "DELETE FROM tb_emp_payroll_ot WHERE id_payroll_ot='" & GVOvertime.GetFocusedRowCellValue("id_payroll_ot").ToString & "'"
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

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim id_payroll As String = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString

        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = " + FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString, 0, True, "", "", "", "")

        Dim already_office As Boolean = False
        Dim already_store As Boolean = False

        Dim data As DataTable = GCOvertime.DataSource

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "1" Then
                already_office = True
            ElseIf data.Rows(j)("is_office_payroll").ToString = "2"
                already_store = True
            End If
        Next

        'office
        Dim report1 As ReportEmpPayrollOvertime = New ReportEmpPayrollOvertime

        report1.id_payroll = id_payroll
        report1.id_pre = If(id_report_status = "6", "-1", "1")
        report1.is_office_payroll = "1"
        report1.XLPeriod.Text = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy")
        report1.XLType.Text = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("payroll_type_name").ToString
        report1.XLLocation.Text = "Office"

        report1.CreateDocument()

        'store
        Dim report2 As ReportEmpPayrollOvertime = New ReportEmpPayrollOvertime

        report2.id_payroll = id_payroll
        report2.id_pre = If(id_report_status = "6", "-1", "1")
        report2.is_office_payroll = "2"
        report2.XLPeriod.Text = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy")
        report2.XLType.Text = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("payroll_type_name").ToString
        report2.XLLocation.Text = "Store"

        report2.CreateDocument()

        'combine
        Dim list As List(Of DevExpress.XtraPrinting.Page) = New List(Of DevExpress.XtraPrinting.Page)

        'report1
        If already_office Then
            For i = 0 To report1.Pages.Count - 1
                list.Add(report1.Pages(i))
            Next
        End If

        'report2
        If already_store Then
            For i = 0 To report2.Pages.Count - 1
                list.Add(report2.Pages(i))
            Next
        End If

        If already_office Then
            report1.Pages.AddRange(list)

            Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report1)

            tool.ShowPreview()
        End If

        If already_store And Not already_office Then
            report2.Pages.AddRange(list)

            Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report2)

            tool.ShowPreview()
        End If
    End Sub

    Private Sub GVOvertime_CustomDrawRowFooter(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GVOvertime.CustomDrawRowFooter
        e.Graphics.FillRectangle(New SolidBrush(Color.White), e.Bounds)

        e.Handled = True
    End Sub

    Private Sub GVOvertime_CustomDrawRowFooterCell(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs) Handles GVOvertime.CustomDrawRowFooterCell
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If view.GetGroupRowDisplayText(e.RowHandle).Contains("Sub Departement") And Not view.GetGroupRowValue(e.RowHandle).ToString.Contains("SOGO") Then
            e.Appearance.ForeColor = Color.White
            e.Handled = True
        End If
    End Sub

    Private Sub GVOvertime_CustomDrawGroupRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GVOvertime.CustomDrawGroupRow
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = TryCast(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo)

        If info.Column.Caption = "Sub Departement" And Not info.EditValue.ToString.Contains("SOGO") Then
            info.GroupText = " "
        End If
    End Sub
End Class