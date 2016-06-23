Public Class FormEmpHolidayDet
    Public id_emp_holiday As String = "-1"
    Private Sub FormEmpHolidayDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_religion()
        Dim query As String = "SELECT '0' AS id_religion,'ALL' AS religion UNION SELECT id_religion,religion FROM tb_lookup_religion"
        viewSearchLookupQuery(SLEReligion, query, "id_religion", "religion", "id_religion")
    End Sub
    Private Sub FormEmpHolidayDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_religion()
        If Not id_emp_holiday = "-1" Then 'edit
            SLEReligion.EditValue = FormEmpHoliday.GVHoliday.GetFocusedRowCellValue("id_religion").ToString
            DEDate.EditValue = FormEmpHoliday.GVHoliday.GetFocusedRowCellValue("emp_holiday_date").ToString
            MEDesc.Text = FormEmpHoliday.GVHoliday.GetFocusedRowCellValue("emp_holiday_desc").ToString
        End If
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim query As String = ""
        If DEDate.EditValue = Nothing Then
            stopCustom("Date can't be empty.")
        Else
            If id_emp_holiday = "-1" Then 'new
                query = "INSERT INTO tb_emp_holiday(id_religion,emp_holiday_date,emp_holiday_desc) VALUES('" + SLEReligion.EditValue.ToString + "','" + Date.Parse(DEDate.EditValue.ToString).ToString("yyyy-MM-dd") + "','" + MEDesc.Text.ToString + "'); SELECT LAST_INSERT_ID(); "
                id_emp_holiday = execute_query(query, 0, True, "", "", "", "")
                '
                FormEmpHoliday.load_holiday()
                FormEmpHoliday.GVHoliday.FocusedRowHandle = find_row(FormEmpHoliday.GVHoliday, "id_emp_holiday", id_emp_holiday)
                Close()
            Else 'edit
                query = "UPDATE tb_emp_holiday SET id_religion='" + SLEReligion.EditValue.ToString + "', emp_holiday_date='" + Date.Parse(DEDate.EditValue.ToString).ToString("yyyy-MM-dd") + "',emp_holiday_desc'" + MEDesc.Text.ToString + "' WHERE id_emp_holiday='" + id_emp_holiday + "'"
                execute_non_query(query, True, "", "", "", "")
                '
                FormEmpHoliday.load_holiday()
                FormEmpHoliday.GVHoliday.FocusedRowHandle = find_row(FormEmpHoliday.GVHoliday, "id_emp_holiday", id_emp_holiday)
                Close()
            End If
        End If
    End Sub

    Private Sub SLEReligion_KeyDown(sender As Object, e As KeyEventArgs) Handles SLEReligion.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEDate.Focus()
        End If
    End Sub

    Private Sub DEDate_KeyDown(sender As Object, e As KeyEventArgs) Handles DEDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            MEDesc.Focus()
        End If
    End Sub

    Private Sub MEDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles MEDesc.KeyDown
        If e.KeyCode = Keys.Enter Then
            BSave.Focus()
        End If
    End Sub
End Class