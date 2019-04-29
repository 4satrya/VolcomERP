Public Class FormEmployeePpsWebcam
    Private Sub FormEmployeePpsWebcam_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormEmployeePpsWebcam_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBCapture_Click(sender As Object, e As EventArgs) Handles SBCapture.Click
        If SBCapture.Text = "Capture" Then
            PictureEdit.Image = CameraControl.TakeSnapshot()

            CameraControl.Visible = False
            PictureEdit.Visible = True

            SBSave.Enabled = True

            SBCapture.Text = "Try Again"
        Else
            CameraControl.Visible = True
            PictureEdit.Visible = False

            SBSave.Enabled = False

            SBCapture.Text = "Capture"
        End If
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        FormEmployeePpsDet.PE.Image = PictureEdit.Image

        Close()
    End Sub
End Class