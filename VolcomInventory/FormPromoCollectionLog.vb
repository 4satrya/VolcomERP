Public Class FormPromoCollectionLog
    Public dt As DataTable

    Private Sub FormPromoCollectionLog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPromoCollectionLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GCData.DataSource = dt
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw(GCData, "")
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
End Class