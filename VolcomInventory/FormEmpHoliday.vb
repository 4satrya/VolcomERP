Public Class FormEmpHoliday
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormEmpHoliday_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpHoliday_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_year()
        load_year_sum()
        load_religion()
    End Sub
    Sub load_year()
        Dim query As String = "SELECT 'ALL' AS `year` UNION SELECT YEAR(emp_holiday_date) AS `year` FROM tb_emp_holiday GROUP BY YEAR(emp_holiday_date) ORDER BY `year` DESC"
        viewSearchLookupQuery(SLEYear, query, "year", "year", "year")
    End Sub
    Sub load_year_sum()
        Dim query As String = "SELECT YEAR(emp_holiday_date) AS `year` FROM tb_emp_holiday GROUP BY YEAR(emp_holiday_date) ORDER BY `year` DESC"
        viewSearchLookupQuery(SLEYearSum, query, "year", "year", "year")
    End Sub
    Sub load_religion()
        Dim query As String = "SELECT '0' AS id_religion,'ALL' AS religion UNION SELECT id_religion,religion FROM tb_lookup_religion"
        viewSearchLookupQuery(SLEReligion, query, "id_religion", "religion", "id_religion")
    End Sub
    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        view_holiday()
    End Sub
    Sub view_holiday_sum()
        Dim date_search As String
        If SLEYearSum.EditValue.ToString = "ALL" Then
            date_search = " LIKE '%%' "
        Else
            date_search = " = '" + SLEYearSum.EditValue.ToString + "'"
        End If
        '
        Dim query As String = "SELECT DAYNAME(emp.emp_holiday_date) AS dow, emp.emp_holiday_date AS hol_date,MONTHNAME(STR_TO_DATE((MONTH(emp.emp_holiday_date)), '%m')) AS hol_month,MONTH(emp.emp_holiday_date) AS id_month,emp.emp_holiday_desc
                                ,IF(emp.id_religion='0',CONCAT(DATE_FORMAT(emp.emp_holiday_date,'%e'),' (',emp.emp_holiday_desc,')'),IF(ISNULL(emp_hindu.id_emp_holiday),'Masuk',CONCAT(DATE_FORMAT(emp.emp_holiday_date,'%e'),' (',emp.emp_holiday_desc,')'))) AS hindu
                                ,IF(emp.id_religion='0',CONCAT(DATE_FORMAT(emp.emp_holiday_date,'%e'),' (',emp.emp_holiday_desc,')'),IF(ISNULL(emp_islam.id_emp_holiday),'Masuk',CONCAT(DATE_FORMAT(emp.emp_holiday_date,'%e'),' (',emp.emp_holiday_desc,')'))) AS islam  
                                ,IF(emp.id_religion='0',CONCAT(DATE_FORMAT(emp.emp_holiday_date,'%e'),' (',emp.emp_holiday_desc,')'),IF(ISNULL(emp_kristen.id_emp_holiday),'Masuk',CONCAT(DATE_FORMAT(emp.emp_holiday_date,'%e'),' (',emp.emp_holiday_desc,')'))) AS kristen  
                                ,IF(emp.id_religion='0',CONCAT(DATE_FORMAT(emp.emp_holiday_date,'%e'),' (',emp.emp_holiday_desc,')'),IF(ISNULL(emp_budha.id_emp_holiday),'Masuk',CONCAT(DATE_FORMAT(emp.emp_holiday_date,'%e'),' (',emp.emp_holiday_desc,')'))) AS budha  
                                FROM tb_emp_holiday emp
                                LEFT JOIN tb_emp_holiday emp_hindu ON emp_hindu.emp_holiday_date=emp.emp_holiday_date AND emp.id_religion='4' 
                                LEFT JOIN tb_emp_holiday emp_islam ON emp_islam.emp_holiday_date=emp.emp_holiday_date AND emp.id_religion='1'
                                LEFT JOIN tb_emp_holiday emp_kristen ON emp_kristen.emp_holiday_date=emp.emp_holiday_date AND emp.id_religion='3'
                                LEFT JOIN tb_emp_holiday emp_budha ON emp_budha.emp_holiday_date=emp.emp_holiday_date AND emp.id_religion='5'
                                WHERE YEAR(emp.emp_holiday_date) " & date_search & " GROUP BY emp.emp_holiday_date ORDER BY emp.emp_holiday_date ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSum.DataSource = data
        GVSum.BestFitColumns()
        GVSum.ExpandAllGroups()
    End Sub
    Sub view_holiday()
        Dim date_search, religion_search As String
        If SLEYear.EditValue.ToString = "ALL" Then
            date_search = " LIKE '%%' "
        Else
            date_search = " = '" + SLEYear.EditValue.ToString + "'"
        End If
        '
        If SLEReligion.EditValue.ToString = "0" Then
            religion_search = " LIKE '%%' "
        Else
            religion_search = " = '" + SLEReligion.EditValue.ToString + "'"
        End If

        Dim query As String = "SELECT hol.*,IF(hol.id_religion=0,'Public Holiday',rel.religion) AS religion FROM tb_emp_holiday hol
                                LEFT JOIN tb_lookup_religion rel ON rel.id_religion=hol.id_religion WHERE YEAR(hol.emp_holiday_date) " + date_search + " AND (hol.id_religion " + religion_search + " OR hol.id_religion=0)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCHoliday.DataSource = data

    End Sub
    Private Sub FormEmpHoliday_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpHoliday_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BImport_Click(sender As Object, e As EventArgs) Handles BImport.Click
        FormImportExcel.id_pop_up = "27"
        FormImportExcel.ShowDialog()
    End Sub

    Private Sub BSearchSum_Click(sender As Object, e As EventArgs) Handles BSearchSum.Click
        view_holiday_sum()
    End Sub
End Class