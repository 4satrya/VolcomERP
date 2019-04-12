Public Class ClassFingerPrint
    'Create Standalone SDK class dynamicly.
    Public axCZKEM1 As New zkemkeeper.CZKEM

    Public bIsConnected = False 'the boolean value identifies whether the device is connected
    Private iMachineNumber As Integer 'the serial number of the device.After connecting the device ,this value will be changed.
    Public ip As String = ""
    Public port As String = ""

    Public Sub connect()
        Dim idwErrorCode As Integer
        bIsConnected = axCZKEM1.Connect_Net(ip.Trim(), Convert.ToInt32(port.Trim()))
        If bIsConnected = True Then
            iMachineNumber = 1 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
            axCZKEM1.RegEvent(iMachineNumber, 65535) 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            'stopCustom("Unable to connect the device,ErrorCode=" & idwErrorCode)
        End If
    End Sub

    Public Sub disconnect()
        axCZKEM1.Disconnect()
        bIsConnected = False
    End Sub

    Public Sub enable_fp()
        axCZKEM1.EnableDevice(iMachineNumber, True)

    End Sub

    Public Sub disable_fp()
        axCZKEM1.EnableDevice(iMachineNumber, False)
    End Sub

    Public Sub refresh_fp()
        axCZKEM1.RefreshData(iMachineNumber)
    End Sub


    Public Sub get_attlog(ByVal id_machine As String)
        disable_fp()

        Dim sdwEnrollNumber As String = ""
        Dim idwVerifyMode As Integer
        Dim idwInOutMode As Integer
        Dim idwYear As Integer
        Dim idwMonth As Integer
        Dim idwDay As Integer
        Dim idwHour As Integer
        Dim idwMinute As Integer
        Dim idwSecond As Integer
        Dim idwWorkcode As Integer

        Dim idwErrorCode As Integer
        Dim iGLCount = 0
        Dim lvItem As New ListViewItem("Items", 0)

        If axCZKEM1.ReadGeneralLogData(iMachineNumber) Then 'read all the attendance records to the memory
            'get records from the memory
            'insert to database
            Dim query As String = "INSERT INTO tb_emp_attn(employee_code,datetime,type_log,scan_method,id_fingerprint) VALUES"
            Dim query_val As String = ""
            Dim penanda As Integer = 0
            While axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, sdwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode)
                penanda += 1
                If Not penanda = 1 Then
                    query_val += ","
                End If
                query_val += "('" & sdwEnrollNumber.ToString & "','" & idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString() & "','" & idwInOutMode.ToString() & "','" & idwVerifyMode.ToString() & "','" & id_machine & "')"
            End While
            If penanda > 0 Then
                query += query_val
                execute_non_query(query, True, "", "", "", "")
            End If
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            If idwErrorCode > 0 Then
                stopCustom("Reading data from terminal failed, ErrorCode = " & idwErrorCode)
            End If
        End If

        enable_fp()
    End Sub
    Sub clear_attlog()
        Dim idwErrorCode As Integer

        disable_fp()

        If axCZKEM1.ClearGLog(iMachineNumber) = True Then
            axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            stopCustom("Operation failed, ErrorCode = " & idwErrorCode)
        End If

        enable_fp()
    End Sub

    Sub setUserInfo(ByVal user_id As String, ByVal name As String, ByVal password As String, privilege As Integer, user_enabled As Boolean)
        axCZKEM1.SSR_SetUserInfo(1, user_id, name, password, privilege, user_enabled)
    End Sub

    Sub deleteUserInfo(ByVal user_id As String)
        axCZKEM1.SSR_DeleteEnrollData(iMachineNumber, user_id, 12)
    End Sub

    Function get_fp_register() As DataTable
        Dim query As String = "SELECT fp.id_fingerprint,fp.name, fp.ip, fp.port, fp.is_register FROM tb_m_fingerprint fp WHERE fp.is_register='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Sub download_fp_tmp()
        Dim jum As Integer = 0
        Dim sdwEnrollNumber As String = ""
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim bEnabled As Boolean = False
        Dim idwFingerIndex As Integer
        Dim sTmpData As String = ""
        Dim iTmpLength As Integer
        Dim iFlag As Integer

        connect()
        disable_fp()
        axCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
        axCZKEM1.ReadAllTemplate(iMachineNumber) 'read all the users' fingerprint templates to the memory

        Dim query As String = "INSERT INTO tb_m_employee_finger(user_id, name, finger_index, tmp_data, privilege, password, enabled, flag) VALUES "
        While axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            For idwFingerIndex = 0 To 9
                If axCZKEM1.GetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData, iTmpLength) Then 'get the corresponding templates string and length from the memory
                    If jum > 0 Then
                        query += ", "
                    End If
                    Dim enabled_fp As String = ""
                    If bEnabled = True Then
                        enabled_fp = "true"
                    Else
                        enabled_fp = "false"
                    End If
                    query += "('" + sdwEnrollNumber + "', '" + addSlashes(sName) + "', '" + idwFingerIndex.ToString + "', '" + sTmpData + "', '" + iPrivilege.ToString() + "', '" + sPassword + "', '" + enabled_fp + "', '" + iFlag.ToString() + "') "
                    jum += 1
                End If
            Next
        End While
        enable_fp()
        disconnect()
        If jum > 0 Then
            Try
                Dim query_trunc As String = "TRUNCATE `tb_m_employee_finger`"
                execute_non_query(query_trunc, True, "", "", "", "")
                execute_non_query(query, True, "", "", "", "")

            Catch ex As Exception
                stopCustom(ex.ToString)
            End Try
        End If
    End Sub

    Sub download_face_tmp_bulk()
        Dim jum As Integer = 0
        Dim sUserID As String = ""
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim bEnabled As Boolean = False

        Dim iFaceIndex As Integer = 50 'the only possible parameter value
        Dim sTmpData As String = ""
        Dim iLength As Integer

        connect()
        disable_fp()
        axCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory

        Dim query As String = "INSERT INTO tb_m_employee_face(user_id, name, face_index, tmp_data, privilege, password, enabled) VALUES "
        While axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, sUserID, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            If axCZKEM1.GetUserFaceStr(iMachineNumber, sUserID, iFaceIndex, sTmpData, iLength) = True Then 'get the face templates from the memory
                If jum > 0 Then
                    query += ", "
                End If
                Dim enabled_fp As String = ""
                If bEnabled = True Then
                    enabled_fp = "true"
                Else
                    enabled_fp = "false"
                End If
                query += "('" + sUserID + "', '" + sName + "', '" + iFaceIndex.ToString + "', '" + sTmpData + "', '" + iPrivilege.ToString() + "', '" + sPassword + "', '" + enabled_fp + "') "
                jum += 1
            End If
        End While

        enable_fp()
        disconnect()
        If jum > 0 Then
            Try
                Dim query_trunc As String = "TRUNCATE `tb_m_employee_face`"
                execute_non_query(query_trunc, True, "", "", "", "")
                execute_non_query(query, True, "", "", "", "")
            Catch ex As Exception
                stopCustom(ex.ToString)
            End Try
        End If
    End Sub

    Sub download_face_tmp()
        Dim jum As Integer = 0
        Dim sUserID As String = ""
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim bEnabled As Boolean = False

        Dim iFaceIndex As Integer = 50 'the only possible parameter value
        Dim sTmpData As String = ""
        Dim iLength As Integer

        connect()
        disable_fp()
        axCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory


        While axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, sUserID, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            If axCZKEM1.GetUserFaceStr(iMachineNumber, sUserID, iFaceIndex, sTmpData, iLength) = True Then 'get the face templates from the memory
                If jum = 0 Then
                    Dim query_trunc As String = "TRUNCATE `tb_m_employee_face`"
                    execute_non_query(query_trunc, True, "", "", "", "")
                End If

                Dim enabled_fp As String = ""
                If bEnabled = True Then
                    enabled_fp = "true"
                Else
                    enabled_fp = "false"
                End If
                Dim query As String = "INSERT INTO tb_m_employee_face(user_id, name, face_index, tmp_data, privilege, password, enabled) VALUES "
                query += "('" + sUserID + "', '" + addSlashes(sName) + "', '" + iFaceIndex.ToString + "', '" + sTmpData + "', '" + iPrivilege.ToString() + "', '" + sPassword + "', '" + enabled_fp + "') "
                execute_non_query(query, True, "", "", "", "")
                jum += 1
            End If
        End While

        enable_fp()
        disconnect()
    End Sub

    'UPLOAD FINGERPRINT TO ALL MACHINE EXCEPT REGISTER MACHINE
    Sub upload_fp_temp(ByVal fp_off As List(Of String))
        'data fp employee
        Dim query_fp As String = "SELECT * FROM tb_m_employee_finger"
        Dim data_fp As DataTable = execute_query(query_fp, -1, True, "", "", "", "")

        'data fp machine
        Dim query_mcn As String = "SELECT * FROM tb_m_fingerprint a WHERE a.is_register='2'"
        Dim data_mcn As DataTable = execute_query(query_mcn, -1, True, "", "", "", "")
        For i As Integer = 0 To data_mcn.Rows.Count - 1
            If Not fp_off.Contains(data_mcn.Rows(i)("id_fingerprint").ToString) Then
                ip = data_mcn.Rows(i)("ip").ToString
                port = data_mcn.Rows(i)("port").ToString
                connect()
                Dim idwErrorCode As Integer
                Dim sdwEnrollNumber As String
                Dim sName As String = ""
                Dim sPassword As String = ""
                Dim iPrivilege As Integer
                Dim idwFingerIndex As Integer
                Dim sTmpData As String = ""
                Dim sEnabled As String = ""
                Dim bEnabled As Boolean = False
                Dim iflag As Integer
                disable_fp()

                For j As Integer = 0 To data_fp.Rows.Count - 1
                    sdwEnrollNumber = data_fp.Rows(j)("user_id").ToString.Trim()
                    sName = data_fp.Rows(j)("name").ToString.Trim()
                    idwFingerIndex = Convert.ToInt32(data_fp.Rows(j)("finger_index").ToString.Trim())
                    sTmpData = data_fp.Rows(j)("tmp_data").ToString.Trim()
                    iPrivilege = Convert.ToInt32(data_fp.Rows(j)("privilege").ToString.Trim())
                    sPassword = data_fp.Rows(j)("password").ToString.Trim()
                    sEnabled = data_fp.Rows(j)("enabled").ToString.Trim()
                    iflag = Convert.ToInt32(data_fp.Rows(j)("flag").ToString.Trim())
                    If sEnabled = "true" Then
                        bEnabled = True
                    Else
                        bEnabled = False
                    End If
                    If axCZKEM1.SSR_SetUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) Then 'upload user information to the device
                        axCZKEM1.SetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iflag, sTmpData) 'upload templates information to the device
                    Else
                        axCZKEM1.GetLastError(idwErrorCode)
                        MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
                        enable_fp()
                        Return
                    End If
                Next
                axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
                enable_fp()
                disconnect()
            End If
        Next
    End Sub

    'UPLOAD FACE TO ALL MACHINE EXCEPT REGISTER MACHINE
    Sub upload_face_tmp(ByVal fp_off As List(Of String))
        'data fp employee
        Dim query_face As String = "SELECT * FROM tb_m_employee_face"
        Dim data_face As DataTable = execute_query(query_face, -1, True, "", "", "", "")

        'data fp machine
        Dim query_mcn As String = "SELECT * FROM tb_m_fingerprint a WHERE a.is_register='2'"
        Dim data_mcn As DataTable = execute_query(query_mcn, -1, True, "", "", "", "")
        For i As Integer = 0 To data_mcn.Rows.Count - 1
            If Not fp_off.Contains(data_mcn.Rows(i)("id_fingerprint").ToString) Then
                ip = data_mcn.Rows(i)("ip").ToString
                port = data_mcn.Rows(i)("port").ToString
                connect()
                Dim idwErrorCode As Integer

                Dim sUserID As String = ""
                Dim sName As String = ""
                Dim iFaceIndex As Integer
                Dim iLength As Integer
                Dim sPassword As String = ""
                Dim iPrivilege As Integer
                Dim sTmpData As String = ""
                Dim sEnabled As String = ""
                Dim bEnabled As Boolean = False

                disable_fp()
                For j As Integer = 0 To data_face.Rows.Count - 1
                    sUserID = data_face.Rows(j)("user_id").ToString.Trim
                    sName = data_face.Rows(j)("name").ToString.Trim
                    sPassword = data_face.Rows(j)("password").ToString.Trim
                    iPrivilege = Convert.ToInt32(data_face.Rows(j)("privilege").ToString.Trim)
                    iFaceIndex = Convert.ToInt32(data_face.Rows(j)("face_index").ToString.Trim)
                    sTmpData = data_face.Rows(j)("tmp_data").ToString.Trim
                    sEnabled = data_face.Rows(j)("enabled").ToString.Trim

                    If sEnabled = "true" Then
                        bEnabled = True
                    Else
                        bEnabled = False
                    End If

                    If axCZKEM1.SSR_SetUserInfo(iMachineNumber, sUserID, sName, sPassword, iPrivilege, bEnabled) Then 'upload user information to the device
                        axCZKEM1.SetUserFaceStr(iMachineNumber, sUserID, iFaceIndex, sTmpData, iLength) 'upload face templates information to the device
                    Else
                        axCZKEM1.GetLastError(idwErrorCode)
                        MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
                        axCZKEM1.EnableDevice(iMachineNumber, True)
                        Return
                    End If
                Next
                axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
                enable_fp()
                disconnect()
            End If
        Next
    End Sub

    'UPLOAD FINGER TEMPLATE BERDASRKAN IP DAN PORT YANG DI SET
    Sub upload_fp_temp_single(ByVal nik As String)
        'data fp employee
        Dim cond As String = ""
        If nik <> "" Then
            cond = "WHERE user_id='" + nik + "'"
        End If

        Dim query_fp As String = "SELECT * FROM tb_m_employee_finger " + cond
        Dim data_fp As DataTable = execute_query(query_fp, -1, True, "", "", "", "")

        connect()
        Dim idwErrorCode As Integer
        Dim sdwEnrollNumber As String
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim idwFingerIndex As Integer
        Dim sTmpData As String = ""
        Dim sEnabled As String = ""
        Dim bEnabled As Boolean = False
        Dim iflag As Integer
        disable_fp()

        For j As Integer = 0 To data_fp.Rows.Count - 1
            sdwEnrollNumber = data_fp.Rows(j)("user_id").ToString.Trim()
            sName = data_fp.Rows(j)("name").ToString.Trim()
            idwFingerIndex = Convert.ToInt32(data_fp.Rows(j)("finger_index").ToString.Trim())
            sTmpData = data_fp.Rows(j)("tmp_data").ToString.Trim()
            iPrivilege = Convert.ToInt32(data_fp.Rows(j)("privilege").ToString.Trim())
            sPassword = data_fp.Rows(j)("password").ToString.Trim()
            sEnabled = data_fp.Rows(j)("enabled").ToString.Trim()
            iflag = Convert.ToInt32(data_fp.Rows(j)("flag").ToString.Trim())
            If sEnabled = "true" Then
                bEnabled = True
            Else
                bEnabled = False
            End If
            If axCZKEM1.SSR_SetUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) Then 'upload user information to the device
                axCZKEM1.SetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iflag, sTmpData) 'upload templates information to the device
            Else
                axCZKEM1.GetLastError(idwErrorCode)
                MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
                enable_fp()
                Return
            End If
        Next
        axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        enable_fp()
        disconnect()
    End Sub

    'UPLOAD FACE TEMPLATE BERDASRKAN IP DAN PORT YANG DI SET
    Sub upload_face_temp_single(ByVal nik As String)
        'data fp employee
        Dim cond As String = ""
        If nik <> "" Then
            cond = "WHERE user_id='" + nik + "'"
        End If
        Dim query_face As String = "SELECT * FROM tb_m_employee_face " + cond
        Dim data_face As DataTable = execute_query(query_face, -1, True, "", "", "", "")

        connect()
        Dim idwErrorCode As Integer

        Dim sUserID As String = ""
        Dim sName As String = ""
        Dim iFaceIndex As Integer
        Dim iLength As Integer
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim sTmpData As String = ""
        Dim sEnabled As String = ""
        Dim bEnabled As Boolean = False

        disable_fp()
        For j As Integer = 0 To data_face.Rows.Count - 1
            sUserID = data_face.Rows(j)("user_id").ToString.Trim
            sName = data_face.Rows(j)("name").ToString.Trim
            sPassword = data_face.Rows(j)("password").ToString.Trim
            iPrivilege = Convert.ToInt32(data_face.Rows(j)("privilege").ToString.Trim)
            iFaceIndex = Convert.ToInt32(data_face.Rows(j)("face_index").ToString.Trim)
            sTmpData = data_face.Rows(j)("tmp_data").ToString.Trim
            sEnabled = data_face.Rows(j)("enabled").ToString.Trim

            If sEnabled = "true" Then
                bEnabled = True
            Else
                bEnabled = False
            End If

            If axCZKEM1.SSR_SetUserInfo(iMachineNumber, sUserID, sName, sPassword, iPrivilege, bEnabled) Then 'upload user information to the device
                axCZKEM1.SetUserFaceStr(iMachineNumber, sUserID, iFaceIndex, sTmpData, iLength) 'upload face templates information to the device
            Else
                axCZKEM1.GetLastError(idwErrorCode)
                MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
                axCZKEM1.EnableDevice(iMachineNumber, True)
                Return
            End If
        Next
        axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        enable_fp()
        disconnect()
    End Sub

    Sub restart_fp()
        connect()
        Dim idwErrorCode As Integer
        If axCZKEM1.RestartDevice(iMachineNumber) = False Then
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        disconnect()
    End Sub

    Sub power_off()
        connect()
        Dim idwErrorCode As Integer
        If axCZKEM1.PowerOffDevice(iMachineNumber) = False Then
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        disconnect()
    End Sub

    Sub sync_all()
        FormMain.SplashScreenManager1.ShowWaitForm()
        'class declare
        Dim fp_off As New List(Of String)
        Dim fp_off_label As New List(Of String)
        Dim fp As New ClassFingerPrint()
        Dim data_fp As DataTable = fp.get_fp_register()

        'test connection
        Dim query As String = "SELECT * FROM tb_m_fingerprint"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim conn As Boolean = False
        For i As Integer = 0 To data.Rows.Count - 1
            Dim id_fp As String = data.Rows(i)("id_fingerprint").ToString
            fp.ip = data.Rows(i)("ip").ToString
            fp.port = data.Rows(i)("port").ToString
            fp.connect()
            conn = fp.bIsConnected
            If Not conn Then
                fp.disconnect()
                fp_off.Add(id_fp)
                fp_off_label.Add(data.Rows(i)("name").ToString + "/" + data.Rows(i)("ip").ToString)
            Else
                fp.disconnect()
            End If
        Next


        fp.ip = data_fp.Rows(0)("ip").ToString
        fp.port = data_fp.Rows(0)("port").ToString
        fp.connect()
        conn = fp.bIsConnected
        fp.disconnect()
        If conn Then
            fp.download_fp_tmp()
            fp.download_face_tmp()
            fp.upload_fp_temp(fp_off)
            fp.upload_face_tmp(fp_off)
            FormMain.SplashScreenManager1.CloseWaitForm()
            If fp_off_label.Count > 0 Then
                Dim fp_info As String = ""
                For j As Integer = 0 To fp_off_label.Count - 1
                    fp_info += "- " + fp_off_label(j) + System.Environment.NewLine
                Next
                infoCustom("Synchronize completed. Error synchronize machine : " + System.Environment.NewLine + fp_info)
            Else
                infoCustom("Synchronize completed")
            End If
        Else
            FormMain.SplashScreenManager1.CloseWaitForm()
            infoCustom("Fingerprint register is turned off")
        End If
    End Sub
End Class
