﻿Public Class FormSamplePurcCloseDet
    Public id_close As String = "-1"

    Private Sub FormSamplePurcCloseDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEDateCreated.EditValue = Now
        TENumber.Text = "[auto generate]"
        TECreatedBy.Text = "[auto generate]"
    End Sub

    Sub load_Det()

    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click

    End Sub
End Class