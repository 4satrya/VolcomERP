Public Class FormEmloyeePps
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"
    '
    Public is_hrd As String = "-1"

    Private Sub FormEmployeePps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDept()
        viewEmployee()
    End Sub

    Sub load_pps()
        Dim where_dept As String = ""

        If Not LEDeptSum.EditValue.ToString = "0" Then
            Dim data_emp_dept As DataTable = execute_query("SELECT id_employee FROM tb_m_employee WHERE id_departement = '" + LEDeptSum.EditValue.ToString + "'", -1, True, "", "", "", "")

            For i = 0 To data_emp_dept.Rows.Count - 1
                where_dept += "'" + data_emp_dept.Rows(i)("id_employee").ToString + "'"

                If i < data_emp_dept.Rows.Count - 1 Then
                    where_dept += ", "
                End If
            Next

            If Not where_dept = "" Then
                where_dept = "AND pps.id_employee IN(" + where_dept + ")"
            End If
        End If

        Dim where_emp As String = If(Not SLUEEmployee.EditValue.ToString = "0", "AND pps.id_employee = '" + SLUEEmployee.EditValue.ToString + "'", "")

        Dim query As String = "
            SELECT pps.id_employee_pps, pps.id_type, pps.id_employee, t.pps_type, pps.number, (SELECT employee_name FROM tb_m_employee WHERE id_employee = pps.created_by) AS created_by, DATE_FORMAT(pps.created_date, '%d %M %Y %H:%i:%s') AS created_date, pps.employee_code, pps.employee_name, pps.is_hrd, pps.note, r.report_status
            FROM tb_employee_pps AS pps
            LEFT JOIN tb_lookup_pps_type AS t ON pps.id_type = t.id_pps_type
            LEFT JOIN tb_lookup_report_status AS r ON pps.id_report_status = r.id_report_status
            WHERE 1 " + where_emp + " " + where_dept + "
            ORDER BY pps.id_employee_pps DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCEmployeePps.DataSource = data

        GVEmployeePps.BestFitColumns()
    End Sub

    Sub viewDept()
        Dim query As String = "SELECT 0 as id_departement, 'All departement' as departement UNION  "
        query += "(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
    End Sub

    Sub viewEmployee()
        Dim query As String = "SELECT 0 AS id_employee, '' AS employee_code, 'All employee' AS employee_name, 0 AS id_departement, 0 AS id_employee_active UNION (SELECT e.id_employee, e.employee_code, e.employee_name, e.id_departement, e.id_employee_active FROM tb_m_employee e LEFT JOIN tb_m_departement d ON e.id_departement = d.id_departement ORDER BY e.employee_name)"
        viewSearchLookupQuery(SLUEEmployee, query, "id_employee", "employee_name", "id_employee")
    End Sub

    Private Sub FormEmployeePps_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmployeePps_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpLeave_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SLUEEmployee_Click(sender As Object, e As EventArgs) Handles SLUEEmployee.Click
        SearchLookUpEditEmp.ActiveFilterString = ""

        If LEDeptSum.EditValue.ToString <> "0" Then
            SearchLookUpEditEmp.ActiveFilterString += "[id_departement] = " + LEDeptSum.EditValue.ToString
        End If

        If SearchLookUpEditEmp.ActiveFilterString <> "" Then
            SearchLookUpEditEmp.ActiveFilterString += "OR [id_employee] = 0"
        End If
    End Sub

    Private Sub LEDeptSum_EditValueChanged(sender As Object, e As EventArgs) Handles LEDeptSum.EditValueChanged
        SLUEEmployee.EditValue = 0
    End Sub

    Private Sub BViewSum_Click(sender As Object, e As EventArgs) Handles BViewSum.Click
        load_pps()
    End Sub

    Private Sub BNew_Click(sender As Object, e As EventArgs) Handles BNew.Click
        FormEmployeePpsDet.is_new = "1"
        FormEmployeePpsDet.is_hrd = is_hrd

        FormEmployeePpsDet.ShowDialog()
    End Sub

    Private Sub BEdit_Click(sender As Object, e As EventArgs) Handles BEdit.Click
        FormEmployeePpsList.is_hrd = is_hrd

        FormEmployeePpsList.ShowDialog()
    End Sub

    Private Sub GVEmployeePps_DoubleClick(sender As Object, e As EventArgs) Handles GVEmployeePps.DoubleClick
        FormEmployeePpsDet.id_pps = GVEmployeePps.GetFocusedRowCellValue("id_employee_pps").ToString
        FormEmployeePpsDet.is_new = If(GVEmployeePps.GetFocusedRowCellValue("id_type").ToString = "1", "-1", "1")
        FormEmployeePpsDet.id_employee = If(GVEmployeePps.GetFocusedRowCellValue("id_employee").ToString = "", "-1", GVEmployeePps.GetFocusedRowCellValue("id_employee").ToString)
        FormEmployeePpsDet.is_hrd = If(is_hrd = "-1", "-1", GVEmployeePps.GetFocusedRowCellValue("is_hrd").ToString)

        FormEmployeePpsDet.ShowDialog()
    End Sub
End Class