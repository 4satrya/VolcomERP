Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports MySql.Data.MySqlClient

Module Database
    Public app_host As String
    Public app_username As String
    Public app_password As String
    Public app_database As String

    Function execute_non_query(ByVal command_text As String, ByVal is_local As Boolean, ByVal host As String, ByVal username As String, ByVal password As String, ByVal database As String)
        If is_local = True Then
            host = app_host
            username = app_username
            password = app_password
            database = app_database
        End If

        'Enable when developing
        'Console.WriteLine(command_text)

        Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True; Allow User Variables=True;", host, username, password, database)

        Dim connection As MySqlConnection = New MySqlConnection(connection_string)
        connection.Open()
        Dim command As MySqlCommand = connection.CreateCommand()
        command.CommandText = command_text
        command.ExecuteNonQuery()
        command.Dispose()
        connection.Close()
        connection.Dispose()

        ''insert log
        'Dim query As String = "SELECT is_log_active FROM tb_opt"
        'Dim is_log_active As Integer = execute_query(query, 0, True, "", "", "", "")
        'If is_log_active = 1 Then
        '    query = String.Format("INSERT INTO tb_log VALUES('{0}', '{1}', NOW())", id_user, command_text)
        '    execute_non_query(query, True, "", "", "", "")
        'End If

        Return True
    End Function

    Function execute_query(ByVal command_text As String, ByVal col_index As Integer, ByVal is_local As Boolean, ByVal host As String, ByVal username As String, ByVal password As String, ByVal database As String)
        If is_local = True Then
            host = app_host
            username = app_username
            password = app_password
            database = app_database
        End If

        Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", host, username, password, database)

        'Enable when developing
        'Console.WriteLine(command_text)

        If col_index < 0 Then 'return data table
            Dim connection As New MySqlConnection(connection_string)
            connection.Open() 
            Dim data As New DataTable
            Dim adapter As New MySqlDataAdapter(command_text, connection)
            adapter.SelectCommand.CommandTimeout = 300
            adapter.Fill(data)
            adapter.Dispose()
            data.Dispose()
            connection.Close()
            connection.Dispose()

            Return data
        Else 'return reader
            Dim connection As MySqlConnection = New MySqlConnection(connection_string)
            connection.Open()
            Dim command As MySqlCommand = connection.CreateCommand()
            command.CommandText = command_text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            reader.Read()
            Dim result As String = reader.GetValue(col_index).ToString
            command.Dispose()
            connection.Close()
            connection.Dispose()

            Return result
        End If

        Return 0
    End Function

    Function show_databases(ByVal is_local As Boolean, ByVal host As String, ByVal username As String, ByVal password As String)
        If is_local = True Then
            host = app_host
            username = app_username
            password = app_password
        End If

        Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Convert Zero Datetime=True", host, username, password)

        Dim connection As New MySqlConnection(connection_string)
        connection.Open()
        Dim data As New DataTable
        Dim adapter As New MySqlDataAdapter("SHOW DATABASES", connection)
        adapter.Fill(data)
        adapter.Dispose()
        data.Dispose()
        connection.Close()
        connection.Dispose()

        Return data
    End Function

    Function check_connection(ByVal is_local As Boolean, ByVal host As String, ByVal username As String, ByVal password As String, ByVal database As String)
        If is_local = True Then
            host = app_host
            username = app_username
            password = app_password
            database = app_database
        End If

        Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", host, username, password, database)

        Dim connection As New MySqlConnection(connection_string)
        connection.Open()
        connection.Close()
        connection.Dispose()

        Return True
    End Function

    Sub write_database_configuration(ByVal ip As String, ByVal un As String, ByVal ps As String, ByVal db As String)
        Dim path As String = My.Application.Info.DirectoryPath.ToString & "\DatabaseConfiguration.xml"

        Dim xml_writer As New XmlTextWriter(path, System.Text.Encoding.UTF8)
        xml_writer.WriteStartDocument(True)
        xml_writer.Formatting = Formatting.Indented
        xml_writer.Indentation = 2
        xml_writer.WriteStartElement("database_config")
        xml_writer.WriteStartElement("ip_address")
        xml_writer.WriteString(ip)
        xml_writer.WriteEndElement()
        xml_writer.WriteStartElement("username")
        xml_writer.WriteString(un)
        xml_writer.WriteEndElement()
        xml_writer.WriteStartElement("password")
        xml_writer.WriteString(ps)
        xml_writer.WriteEndElement()
        xml_writer.WriteStartElement("database")
        xml_writer.WriteString(db)
        xml_writer.WriteEndElement()
        xml_writer.WriteEndElement()
        xml_writer.WriteEndDocument()
        xml_writer.Close()

        Dim xmldoc As New XmlDocument()
        xmldoc.Load(path)
        Dim sharedkey As New TripleDESCryptoServiceProvider()
        Dim md5 As New MD5CryptoServiceProvider()
        sharedkey.Key = md5.ComputeHash(System.Text.Encoding.Unicode.GetBytes("csmtafc"))

        Dim exml As EncryptedXml = New EncryptedXml(xmldoc)
        Dim encryptElement As XmlElement = CType(xmldoc.SelectSingleNode("/database_config"), XmlElement)
        Dim encryptXML As Byte() = exml.EncryptData(encryptElement, sharedkey, False)
        Dim ed As New EncryptedData()
        ed.Type = EncryptedXml.XmlEncElementUrl
        ed.EncryptionMethod = New EncryptionMethod(EncryptedXml.XmlEncTripleDESUrl)
        ed.CipherData = New CipherData()
        ed.CipherData.CipherValue = encryptXML
        EncryptedXml.ReplaceElement(encryptElement, ed, False)

        xmldoc.Save(path)
    End Sub

    Sub read_database_configuration()
        Dim path As String = My.Application.Info.DirectoryPath.ToString & "\DatabaseConfiguration.xml"
        Dim sharedkey As New TripleDESCryptoServiceProvider()
        Dim md5 As New MD5CryptoServiceProvider()
        sharedkey.Key = md5.ComputeHash(System.Text.Encoding.Unicode.GetBytes("csmtafc"))

        Dim encryptedDoc As New XmlDocument()
        encryptedDoc.Load(path)

        Dim EncryptedElement As XmlElement = CType(encryptedDoc.GetElementsByTagName("EncryptedData")(0), XmlElement)

        Dim ed As New EncryptedData()
        ed.LoadXml(EncryptedElement)

        Dim encryptXML As New EncryptedXml()
        Dim decryptedXML As Byte() = encryptXML.DecryptData(ed, sharedkey)

        encryptXML.ReplaceData(EncryptedElement, decryptedXML)

        Dim xmlnode As XmlNodeList
        xmlnode = encryptedDoc.GetElementsByTagName("database_config")
        app_host = xmlnode(0).ChildNodes.Item(0).InnerText.Trim()
        app_username = xmlnode(0).ChildNodes.Item(1).InnerText
        app_password = xmlnode(0).ChildNodes.Item(2).InnerText
        app_database = xmlnode(0).ChildNodes.Item(3).InnerText.Trim()
    End Sub

    Public Function SqlSafe(ByVal strInput As String) As String
        SqlSafe = replace(strInput, "'", "''")
        SqlSafe = replace(SqlSafe, """", """""")
    End Function
End Module
