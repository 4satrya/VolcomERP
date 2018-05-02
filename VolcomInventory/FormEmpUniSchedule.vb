Public Class FormEmpUniSchedule
    Private Sub FormEmpUniSchedule_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormEmpUniSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT *, 'No' AS `is_select` FROM tb_m_departement d ORDER BY d.id_departement ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAdd.DataSource = data
        Dim dt As DateTime = getTimeDB()
        DEStart.EditValue = dt
        DEEnd.EditValue = dt
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVAdd)
        GVAdd.ActiveFilterString = "[is_select]='Yes'"
        If GVAdd.RowCount > 0 Then
            For i As Integer = 0 To ((GVAdd.RowCount - 1) - GetGroupRowCount(GVAdd))
                Dim qins As String = "INSERT INTO tb_emp_uni_schedule(id_emp_uni_period, id_departement, start, end) VALUES 
                ('" + FormEmpUniPeriodDet.id_emp_uni_period + "', '" + GVAdd.GetRowCellValue(i, "id_departement").ToString + "', '" + DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd H:mm:ss") + "','" + DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd H:mm:ss") + "') "
                execute_non_query(qins, True, "", "", "", "")
            Next
            FormEmpUniPeriodDet.viewSchedule()
            Close()
        Else
            stopCustom("no item selected")
            GVAdd.ActiveFilterString = ""
            makeSafeGV(GVAdd)
        End If
        Cursor = Cursors.Default
    End Sub
End Class