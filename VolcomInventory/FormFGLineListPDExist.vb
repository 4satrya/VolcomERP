Public Class FormFGLineListPDExist
    Public dt As DataTable

    Private Sub FormFGLineListPDExist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GCData.DataSource = dt
        GVData.BestFitColumns()
    End Sub

    Private Sub FormFGLineListPDExist_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class