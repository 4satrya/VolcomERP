Public Class FormNtwainCoba
    Private Sub BScan_Click(sender As Object, e As EventArgs) Handles BScan.Click
        PictureEdit1.Image = Scanner.Scan
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If Not PictureEdit1.Image Is Nothing Then
            save_image_ori(PictureEdit1, Application.StartupPath + "\imagestemp\", "wiascanner.jpg")

            Dim command As String = "/K net use \\192.168.1.30\dataapp\wia /user:Catur bangcat48 & COPY """ + Application.StartupPath + "\imagestemp\wiascanner.jpg"" ""\\192.168.1.30\dataapp\wia\wiascanner.jpg"" /Y & exit"

            Dim p As New ProcessStartInfo("CMD.EXE")

            p.WindowStyle = ProcessWindowStyle.Hidden
            p.CreateNoWindow = True
            p.UseShellExecute = False
            p.Arguments = command

            Process.Start(p)
        Else
            errorCustom("Please scan image first.")
        End If
    End Sub
End Class