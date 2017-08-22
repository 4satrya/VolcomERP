Public Class FormEmpFingerNew
    Public ip As String = ""
    Public port As String = ""

    Private Sub FormEmpFingerNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "Finger Template : " + ip
        Using fp As ClassFingerPrint = New ClassFingerPrint()
            fp.ip = ip
            fp.port = port
            fp.connect()
            Dim axCZKEM1 As zkemkeeper.CZKEM = fp.axCZKEM1
            Dim iMachineNumber As Integer = 1
            Dim sdwEnrollNumber As String = ""
            Dim sName As String = ""
            Dim sPassword As String = ""
            Dim iPrivilege As Integer
            Dim bEnabled As Boolean = False
            Dim idwFingerIndex As Integer
            Dim sTmpData As String = ""
            Dim iTmpLength As Integer
            Dim iFlag As Integer

            Dim dt As New DataTable
            Try
                dt.Columns.Add("number")
                dt.Columns.Add("name")
                dt.Columns.Add("index")
                dt.Columns.Add("tmp_data")
                dt.Columns.Add("privilege")
                dt.Columns.Add("password")
                dt.Columns.Add("enabled")
                dt.Columns.Add("flag")
            Catch ex As Exception
            End Try

            axCZKEM1.EnableDevice(iMachineNumber, False)

            Cursor = Cursors.WaitCursor
            axCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
            axCZKEM1.ReadAllTemplate(iMachineNumber) 'read all the users' fingerprint templates to the memory

            While axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) 'get all the users' information from the memory
                For idwFingerIndex = 0 To 9
                    If axCZKEM1.GetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData, iTmpLength) Then 'get the corresponding templates string and length from the memory
                        Dim R As DataRow = dt.NewRow
                        R("number") = sdwEnrollNumber.ToString()
                        R("name") = sName
                        R("index") = idwFingerIndex.ToString()
                        R("tmp_data") = sTmpData
                        R("privilege") = iPrivilege.ToString()
                        R("password") = sPassword
                        If bEnabled = True Then
                            R("enabled") = "true"
                        Else
                            R("enabled") = "false"
                        End If
                        R("flag") = iFlag.ToString()
                        dt.Rows.Add(R)
                    End If
                Next
            End While
            axCZKEM1.EnableDevice(iMachineNumber, True)
            fp.disconnect()
            GCData.DataSource = dt
        End Using
    End Sub

    Private Sub FormEmpFingerNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class