Public Class FormFabricConsumption
    Public id_design As String = "-1"
    Private Sub FormFabricConsumption_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Sub load_mat()
        Dim q As String = "CALL view_mat()"
        viewSearchLookupRepositoryQuery(RISLEMatDet, q, 0, "mat_det_display_name", "id_mat_det")
    End Sub

    Private Sub FormFabricConsumption_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_mat()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click

    End Sub

    Sub allow_but()
        If GVFabCons.RowCount > 0 Then
            BDel.Visible = True
        Else
            BDel.Visible = False
        End If
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        If GVFabCons.RowCount > 0 Then
            GVFabCons.DeleteSelectedRows()
        End If
    End Sub

    Private Sub BDefaultTemplate_Click(sender As Object, e As EventArgs) Handles BDefaultTemplate.Click

    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        GVFabCons.AddNewRow()
        GVFabCons.FocusedRowHandle = GVFabCons.RowCount - 1
    End Sub
End Class