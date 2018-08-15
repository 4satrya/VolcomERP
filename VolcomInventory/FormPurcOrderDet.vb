Public Class FormPurcOrderDet
    Public id_po As String = "-1"
    Public id_cc As String = ""

    Private Sub FormPurcOrderDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormPurcOrderDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class