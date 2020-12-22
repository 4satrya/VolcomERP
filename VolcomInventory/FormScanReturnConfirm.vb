Public Class FormScanReturnConfirm
    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub FormScanReturnConfirm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormScanReturnConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEQtyScan.EditValue = FormScanReturnDet.GVListProduct.Columns("size").SummaryItem.SummaryValue
        TEQtyRetNote.EditValue = FormScanReturnDet.TEQty.EditValue
        TEQtyDiff.EditValue = FormScanReturnDet.GVListProduct.Columns("size").SummaryItem.SummaryValue - FormScanReturnDet.TEQty.EditValue
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        FormScanReturnDet.is_ok = True
        Close()
    End Sub
End Class