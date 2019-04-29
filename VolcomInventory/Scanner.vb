Public Class Scanner
    Shared Function Scan() As Image
        Dim cdd As WIA.CommonDialog = New WIA.CommonDialog

        Dim device As WIA.Device = Nothing

        Try
            device = cdd.ShowSelectDevice(WIA.WiaDeviceType.UnspecifiedDeviceType, True, False)
        Catch ex As Exception
            errorCustom("No scanners were detected.")
        End Try

        If Not device Is Nothing Then
            Dim manage As WIA.DeviceManager = New WIA.DeviceManager()
            Dim wiaDev As WIA.Device = Nothing

            For Each info As WIA.DeviceInfo In manage.DeviceInfos
                If info.DeviceID = device.DeviceID Then
                    Dim infoprop As WIA.Properties = Nothing
                    infoprop = info.Properties

                    wiaDev = info.Connect()

                    Exit For
                End If
            Next

            Dim item As WIA.Item = wiaDev.Items(1)

            Dim cds As WIA.CommonDialog = New WIA.CommonDialog

            Dim file As WIA.ImageFile = cds.ShowTransfer(item, WIA.FormatID.wiaFormatBMP, False)

            Dim imageStream As IO.MemoryStream = New IO.MemoryStream(CType(file.FileData.BinaryData, Byte()))

            Dim imageOri As New Bitmap(imageStream)

            'resize
            Dim width As Integer = 0
            Dim height As Integer = 0
            Dim maxSize As Integer = 1024

            If imageOri.Width > maxSize Or imageOri.Height > maxSize Then
                If imageOri.Width > imageOri.Height Then
                    width = maxSize
                    height = (maxSize / imageOri.Width) * imageOri.Height
                Else
                    width = (maxSize / imageOri.Height) * imageOri.Width
                    height = maxSize
                End If
            End If

            Dim imageRes As New Bitmap(width, height)

            Using gfx As Graphics = Graphics.FromImage(imageRes)
                gfx.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                gfx.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                gfx.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                gfx.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                gfx.CompositingMode = Drawing2D.CompositingMode.SourceOver

                gfx.DrawImage(imageOri, 0, 0, imageRes.Width, imageRes.Height)
            End Using

            Return CType(imageRes, Image)
        Else
            Return CType(Nothing, Image)
        End If
    End Function
End Class
