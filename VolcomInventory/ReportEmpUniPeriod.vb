Public Class ReportEmpUniPeriod
    Public Shared dt As DataTable

    Private Sub ReportEmpUniPeriod_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCDetail.DataSource = dt
        'printed date & approved date
        Dim qpd As String = "SELECT 
        ep.employee_name AS `prepared_by`, ep.employee_position AS `prepared_position`,
        ec1.employee_name AS `checked_by1`, ec1.employee_position AS `checked_position1`,
        ec2.employee_name AS `checked_by2`, ec2.employee_position AS `checked_position2`,
        ec3.employee_name AS `checked_by3`, ec3.employee_position AS `checked_position3`,
        CONCAT(ea1.employee_name, ' / ', ea2.employee_name) AS `approved_by`,
        DATE_FORMAT(NOW(), '%d/%m/%Y %H:%i') AS `printed_date`
        FROM tb_opt o
        INNER JOIN tb_m_employee ep ON ep.id_employee=" + id_employee_user + "
        INNER JOIN tb_m_employee ec1 ON ec1.id_employee = o.id_emp_hrd_manager
        INNER JOIN tb_m_employee ec2 ON ec2.id_employee = o.id_emp_accounting_manager
        INNER JOIN tb_m_employee ec3 ON ec3.id_employee = o.id_emp_fc
        INNER JOIN tb_m_employee ea1 ON ea1.id_employee = o.id_emp_director
        INNER JOIN tb_m_employee ea2 ON ea2.id_employee = o.id_emp_vice_director "
        Dim dpd As DataTable = execute_query(qpd, -1, True, "", "", "", "")
        DataSource = dpd
    End Sub
End Class