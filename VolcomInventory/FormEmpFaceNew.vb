Public Class FormEmpFaceNew
    Public ip As String = ""
    Public port As String = ""

    Private Sub FormEmpFaceNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "Face Template : " + ip
        Dim fp As New ClassFingerPrint()
        fp.ip = ip
        fp.port = port
        fp.connect()
        Dim axCZKEM1 As zkemkeeper.CZKEM = fp.axCZKEM1
        Dim iMachineNumber As Integer = 1
        Dim sUserID As String = ""
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim bEnabled As Boolean = False

        Dim iFaceIndex As Integer = 50 'the only possible parameter value
        Dim sTmpData As String = ""
        Dim iLength As Integer

        Dim dt As New DataTable
        Try
            dt.Columns.Add("number")
            dt.Columns.Add("name")
            dt.Columns.Add("password")
            dt.Columns.Add("privilege")
            dt.Columns.Add("index")
            dt.Columns.Add("tmp_data")
            dt.Columns.Add("length")
            dt.Columns.Add("enabled")
        Catch ex As Exception
        End Try


        Cursor = Cursors.WaitCursor
        axCZKEM1.EnableDevice(iMachineNumber, False)
        axCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory

        While axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, sUserID, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            If axCZKEM1.GetUserFaceStr(iMachineNumber, sUserID, iFaceIndex, sTmpData, iLength) = True Then 'get the face templates from the memory
                'Console.WriteLine(sUserID)
                'Dim R As DataRow = dt.NewRow
                'R("number") = sUserID
                'R("name") = sName
                'R("password") = sPassword
                'R("privilege") = iPrivilege.ToString()
                'R("index") = iFaceIndex.ToString()
                'R("tmp_data") = sTmpData
                'R("length") = iLength.ToString()
                'If bEnabled = True Then
                '    R("enabled") = "true"
                'Else
                '    R("enabled") = "false"
                'End If
                'dt.Rows.Add(R)
            End If
        End While
        axCZKEM1.EnableDevice(iMachineNumber, True)
        fp.disconnect()
        GCData.DataSource = dt
    End Sub

    Private Sub FormEmpFaceNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class