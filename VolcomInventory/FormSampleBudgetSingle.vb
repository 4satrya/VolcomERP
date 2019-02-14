Public Class FormSampleBudgetSingle
    Private Sub FormSampleBudgetSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEYearBudget.EditValue = Now
        TEBudgetRp.EditValue = 0.00
        TEBudgetUSD.EditValue = 0.00
        '
        load_division()
    End Sub

    Sub load_division()
        Dim query As String = "SELECT 'no' AS is_check,cd.* FROM tb_m_code_detail cd
WHERE cd.`id_code`='16'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDivision.DataSource = data
        GVDivision.BestFitColumns()
    End Sub

    Private Sub FormSampleBudgetSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        GVDivision.ActiveFilterString = "[is_check] = 'yes'"
        If GVDivision.RowCount <= 0 Then
            warningCustom("Please select division to budget")
        Else
            FormSampleBudgetDet.GVAfter.AddNewRow()
            FormSampleBudgetDet.GVAfter.FocusedRowHandle = FormSampleBudgetDet.GVAfter.RowCount - 1
            FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("description_after", TEDescription.Text)
            FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("year_after", DEYearBudget.EditValue)
            FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("value_usd_after", TEBudgetUSD.EditValue)
            FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("value_rp_after", TEBudgetRp.EditValue)
            Dim id_code_detail As String = ""
            Dim code_detail As String = ""
            For i As Integer = 0 To GVDivision.RowCount - 1
                If Not i = 0 Then
                    id_code_detail += ","
                    code_detail += ","
                End If
                id_code_detail += GVDivision.GetRowCellValue(i, "id_code_detail").ToString
                code_detail += GVDivision.GetRowCellValue(i, "code_detail_name").ToString
            Next
            FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("id_division_after", id_code_detail)
            FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("division_after", code_detail)
            FormSampleBudgetDet.GVAfter.RefreshData()
            Close()
        End If
        GVDivision.ActiveFilterString = ""
    End Sub
End Class