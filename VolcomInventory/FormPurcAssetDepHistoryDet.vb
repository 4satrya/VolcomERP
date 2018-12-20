Public Class FormPurcAssetDepHistoryDet
    Public id As String = "-1"
    Dim id_asset As String = ""

    Private Sub FormPurcAssetDepHistoryDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormPurcAssetDepHistoryDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub LabelLinkAssetNumber_Click(sender As Object, e As EventArgs) Handles LabelLinkAssetNumber.Click
        Cursor = Cursors.WaitCursor
        Dim p As New ClassShowPopUp()
        p.report_mark_type = "160"
        p.id_report = id_asset
        p.show()
        Cursor = Cursors.Default
    End Sub
End Class