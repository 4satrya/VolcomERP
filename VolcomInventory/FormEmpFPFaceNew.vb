Public Class FormEmpFPFaceNew
    Public ip As String = ""
    Public port As String = ""
    Private Sub FormEmpFPFaceNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        lvFace.Items.Clear()
        lvFace.BeginUpdate()

        Dim lvItem As New ListViewItem("Items", 0)

        Cursor = Cursors.WaitCursor
        axCZKEM1.EnableDevice(iMachineNumber, False)
        axCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory

        While axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, sUserID, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            If axCZKEM1.GetUserFaceStr(iMachineNumber, sUserID, iFaceIndex, sTmpData, iLength) = True Then 'get the face templates from the memory
                lvItem = lvFace.Items.Add(sUserID)
                lvItem.SubItems.Add(sName)
                lvItem.SubItems.Add(sPassword)
                lvItem.SubItems.Add(iPrivilege.ToString())
                lvItem.SubItems.Add(iFaceIndex.ToString())
                lvItem.SubItems.Add(sTmpData)
                lvItem.SubItems.Add(iLength.ToString())
                If bEnabled = True Then
                    lvItem.SubItems.Add("true")
                Else
                    lvItem.SubItems.Add("false")
                End If
            End If
        End While
        lvFace.EndUpdate()
        axCZKEM1.EnableDevice(iMachineNumber, True)
        fp.disconnect()
        MsgBox("end")
    End Sub

    Private Sub FormEmpFPFaceNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class