Imports System.Net
Imports System.Reflection

Public Class ClassUser
    Function logLogin(ByVal type As String)
        Dim sts As Boolean = True
        'type 1=login; 2=logout
        Dim id_season_temp As String = ""
        Dim season_over As String = "2"

        If type = "2" Then
            season_over = "1"
        End If

        If id_user > "0" And id_user <> "" Then
            Dim versionNumber As Version
            versionNumber = Assembly.GetExecutingAssembly().GetName().Version

            Dim query As String = "INSERT INTO tb_log_login(id_user, time,type,ip_address,version_number,is_season_over) 
            VALUES('" + id_user + "', NOW(), '" + type + "','" & GetIPv4Address() & "','" & versionNumber.ToString & "','" & season_over & "'); SELECT LAST_INSERT_ID(); "
            id_season_temp = execute_query(query, 0, True, "", "", "", "")
            '
            If type = "1" Then
                id_login_session = id_season_temp
                sts = check_login_session()
            ElseIf type = "2" Then
                checkSeasonLogout()
            End If
        End If

        Return sts
    End Function

    Sub checkSeasonLogout()
        If get_setup_field("is_enable_season") = "1" Then 'logout
            Dim q As String = "UPDATE tb_log_login SET is_season_over='1' WHERE id_user='" & id_user & "' AND is_season_over='2' AND id_season='" & id_login_session & "'"
            execute_non_query(q, True, "", "", "", "")
        End If
    End Sub



    Private Function GetIPv4Address() As String
        GetIPv4Address = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIPv4Address = ipheal.ToString()
            End If
        Next
    End Function

    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = ""
        query += "SELECT l.id_user, e.id_employee, e.employee_code, e.employee_name, e.employee_position,l.ip_address,l.version_number, l.`time`, 
        l.`type`, IF(l.`type`=1,'Login', 'Logout') AS `type_display`
        FROM tb_log_login l
        INNER JOIN tb_m_user u ON l.id_user = u.id_user
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee "
        query += "WHERE 5>1 "
        query += condition + " "
        query += "ORDER BY l.time " + order_type
        Return query
    End Function
End Class
