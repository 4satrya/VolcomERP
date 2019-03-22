Public Class FormEmployeePpsList
    Public is_hrd As String = "-1"

    Private Sub FormEmployeePpsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            SELECT e.id_employee, d.departement, e.employee_code, e.employee_name, e.employee_position, ls.employee_status, la.employee_active
            FROM tb_m_employee AS e 
            LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement 
            LEFT JOIN tb_lookup_employee_status AS ls ON e.id_employee_status = ls.id_employee_status
            LEFT JOIN tb_lookup_employee_active AS la ON e.id_employee_active = la.id_employee_active
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCEmployeeList.DataSource = data

        GVEmployeeList.BestFitColumns()
    End Sub

    Private Sub SBSelect_Click(sender As Object, e As EventArgs) Handles SBSelect.Click
        If checkHasPropose() Then
            warningCustom("Employee still has proposed changes.")
        Else
            Close()

            FormEmployeePpsDet.id_employee = GVEmployeeList.GetFocusedRowCellValue("id_employee")
            FormEmployeePpsDet.is_hrd = is_hrd

            FormEmployeePpsDet.ShowDialog()
        End If
    End Sub

    Private Sub FormEmployeePpsList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVEmployeeList_DoubleClick(sender As Object, e As EventArgs) Handles GVEmployeeList.DoubleClick
        If checkHasPropose() Then
            warningCustom("Employee still has proposed changes.")
        Else
            Close()

            FormEmployeePpsDet.id_employee = GVEmployeeList.GetFocusedRowCellValue("id_employee")
            FormEmployeePpsDet.is_hrd = is_hrd

            FormEmployeePpsDet.ShowDialog()
        End If
    End Sub

    Function checkHasPropose() As Boolean
        Dim status As Boolean = False

        Dim id_employee As String = GVEmployeeList.GetFocusedRowCellValue("id_employee").ToString

        Dim query As String = "SELECT IFNULL((SELECT COUNT(id_employee) FROM tb_employee_pps WHERE id_employee = '" + id_employee + "' AND id_report_status NOT IN (5, 6) GROUP BY employee_code), 0)"

        Dim data As String = execute_query(query, 0, True, "", "", "", "")

        If Not data = "0" Then
            status = True
        End If

        Return status
    End Function
End Class