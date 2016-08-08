Public Class FormEmpHoliday
    Private Sub FormEmpHoliday_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_year()
        load_religion()
        Dim query As String = "SELECT 1 as tes,2 as tes2"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProd.DataSource = data
    End Sub
    Sub load_year()
        Dim query As String = "SELECT 'ALL' AS `year` UNION SELECT YEAR(emp_holiday_date) AS `year` FROM tb_emp_holiday GROUP BY YEAR(emp_holiday_date) ORDER BY `year` DESC"
        viewSearchLookupQuery(SLEYear, query, "year", "year", "year")
    End Sub
    Sub load_religion()
        Dim query As String = "SELECT '0' AS id_religion,'ALL' AS religion UNION SELECT id_religion,religion FROM tb_lookup_religion"
        viewSearchLookupQuery(SLEReligion, query, "id_religion", "religion", "id_religion")
    End Sub
    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        Dim date_search As String = ""
        If SLEYear.EditValue.ToString = "ALL" Then
            date_search = " LIKE '%%' "
        Else
            date_search = " = '" + SLEYear.EditValue.ToString + "'"
        End If
        Dim query As String = "SELECT * FROM tb_emp_holiday WHERE YEAR(emp_holiday_date) " + date_search + " AND id_religion = '" + SLEReligion.EditValue.ToString + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
    End Sub
End Class