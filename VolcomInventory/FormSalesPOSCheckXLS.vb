Public Class FormSalesPOSCheckXLS
    Public dt As DataTable
    Public id_pop_up As String = "-1"

    Private Sub FormSalesPOSCheckXLS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        GCData.DataSource = dt
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCData, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSalesPOSCheckXLS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        If id_pop_up = "-1" Then
            FormSalesPOSDet.is_continue_load = False
        ElseIf id_pop_up = "1" Then
            FormSalesPOSDet.is_continue_load_det = False
        End If
        Close()
    End Sub

    Private Sub BtnSkip_Click(sender As Object, e As EventArgs) Handles BtnSkip.Click
        Close()
    End Sub
End Class