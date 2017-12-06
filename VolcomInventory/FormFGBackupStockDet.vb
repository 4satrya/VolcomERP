Public Class FormFGBackupStockDet
    Public id_st_period As String = "-1"
    Public action As String = ""

    Private Sub FormFGBackupStockDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub actionLoad()
        If action = "ins" Then

        ElseIf action = "upd" Then

        End If
    End Sub

    Sub viewComp()

    End Sub
End Class