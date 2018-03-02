Public Class FormFingerPrint
    '    'Create Standalone SDK class dynamicly.
    '    Public axCZKEM1 As New zkemkeeper.CZKEM

    '    '****************************************************************************************************
    '    '* Before you refer to this demo,we strongly suggest you read the development manual deeply first.  *
    '    '* This part is for demonstrating the communication with your device.                               *
    '    '* **************************************************************************************************
    '#Region "Communication"
    '    Private bIsConnected = False 'the boolean value identifies whether the device is connected
    '    Private iMachineNumber As Integer 'the serial number of the device.After connecting the device ,this value will be changed.

    '    'If your device supports the TCP/IP communications, you can refer to this.
    '    'when you are using the tcp/ip communication,you can distinguish different devices by their IP address.
    '    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
    '        Cursor = Cursors.WaitCursor
    '        If txtIP.Text.Trim() = "" Or txtPort.Text.Trim() = "" Then
    '            MsgBox("IP and Port cannot be null", MsgBoxStyle.Exclamation, "Error")
    '        Else
    '            Dim fp As New ClassFingerPrint
    '            fp.ip = txtIP.Text
    '            fp.port = txtPort.Text
    '            fp.connect()
    '        End If
    '        Cursor = Cursors.Default
    '    End Sub
    '#End Region
End Class