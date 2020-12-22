Public Class FormOLStoreLog

    Public id_order As String = "-1"
    Public id_comp_group As String = "-1"

    Private Sub FormOLStoreLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim ol As New ClassOLStore()
        Dim data As DataTable = ol.viewLogOrder(id_order, id_comp_group)
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormOLStoreLog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class