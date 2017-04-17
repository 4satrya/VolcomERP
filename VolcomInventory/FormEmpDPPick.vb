Public Class FormEmpDPPick
    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormEmpDPPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Private Sub DEStartDP_KeyDown(sender As Object, e As KeyEventArgs) Handles DEStartDP.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilDP.Focus()
        End If
    End Sub

    Private Sub DEUntilDP_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilDP.KeyDown
        If e.KeyCode = Keys.Enter Then
            MENote.Focus()
        End If
    End Sub

    Private Sub DEStartDP_EditValueChanged(sender As Object, e As EventArgs) Handles DEStartDP.EditValueChanged
        Try
            DEUntilDP.Properties.MinValue = DEStartDP.EditValue
            calc()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DEUntilDP_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntilDP.EditValueChanged
        calc()
    End Sub

    Sub calc()
        If Not DEStartDP.EditValue > DEUntilDP.EditValue Then
            '
            Dim date_start As Date = DEStartDP.EditValue
            Dim date_until As Date = DEUntilDP.EditValue
            Dim time_diff As TimeSpan
            Dim diff As Integer
            time_diff = date_until - date_start
            diff = Math.Floor(time_diff.TotalHours)
            TETotHour.EditValue = diff
        Else
            '
            TETotHour.EditValue = 0
        End If
    End Sub

    Private Sub FormEmpDPPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStartDP.EditValue = Now
        DEUntilDP.EditValue = Now
        calc()
        DEStartDP.Focus()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Try
            Dim newRow As DataRow = (TryCast(FormEmpDPDet.GCDP.DataSource, DataTable)).NewRow()
            newRow("dp_time_start") = DEStartDP.EditValue
            newRow("dp_time_end") = DEUntilDP.EditValue
            newRow("subtotal_hour") = TETotHour.EditValue
            newRow("remark") = MENote.Text

            TryCast(FormEmpDPDet.GCDP.DataSource, DataTable).Rows.Add(newRow)
            FormEmpDPDet.GCDP.RefreshDataSource()
            FormEmpDPDet.calc()
            FormEmpDPDet.show_but()
            FormEmpDPDet.GVDP.FocusedRowHandle = 0
            Close()
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub
End Class