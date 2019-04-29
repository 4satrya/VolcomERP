Public Class ClassDepartement
    Private id_dept As String = "-1"
    Private dept_name As String = ""
    Private dept_head_id As String = "-1"
    Private dept_head As String = ""
    Private dept_head_email As String = ""

    Public Sub New(ByVal id_dept_new As String)
        id_dept = id_dept_new
        Dim query As String = "SELECT dept.departement,dept.id_user_head,emp.employee_name,emp.email_lokal FROM tb_m_departement dept LEFT JOIN tb_m_user usr ON dept.id_user_head=usr.id_user LEFT JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee WHERE dept.id_departement='" + id_dept_new + "'"
        Dim data_dt As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data_dt.Rows.Count > 0 Then
            dept_name = data_dt.Rows(0)("departement").ToString
            dept_head_id = data_dt.Rows(0)("id_user_head").ToString
            dept_head = data_dt.Rows(0)("employee_name").ToString
            dept_head_email = data_dt.Rows(0)("email_lokal").ToString
        End If
    End Sub
End Class
