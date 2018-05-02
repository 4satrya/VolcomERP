Public Class FormEmpUniBudgetSet
    Private Sub FormEmpUniBudgetSet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        'buka import form
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "31"
        FormImportExcel.ShowDialog()
        Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormEmpUniBudgetSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtBudget.EditValue = FormEmpUniPeriodDet.TxtBudget.EditValue
        TxtBudget.Enabled = False
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.EditValue = True Then
            TxtBudget.EditValue = FormEmpUniPeriodDet.TxtBudget.EditValue
            TxtBudget.Enabled = True
            TxtBudget.Focus()
        Else
            TxtBudget.EditValue = FormEmpUniPeriodDet.TxtBudget.EditValue
            TxtBudget.Enabled = False
        End If
    End Sub
End Class