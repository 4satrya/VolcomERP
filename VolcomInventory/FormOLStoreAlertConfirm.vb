Public Class FormOLStoreAlertConfirm
    Public dt As DataTable

    Private Sub FormOLStoreAlertConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GCData.DataSource = dt
        GVData.BestFitColumns()
    End Sub

    Private Sub FormOLStoreAlertConfirm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw(GCData, "")
    End Sub
End Class