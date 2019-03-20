Public Class FormPurcReceiveCOANotice
    Public dt As DataTable

    Private Sub FormPurcReceiveCOANotice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GCData.DataSource = dt
        GVData.BestFitColumns()
        System.Media.SystemSounds.Beep.Play()
    End Sub

    Private Sub FormPurcReceiveCOANotice_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw_no_export(GCData)
    End Sub
End Class