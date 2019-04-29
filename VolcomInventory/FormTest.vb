Imports System
Imports System.Net
Imports System.Xml

Public Class FormTest
    Dim webResponse As WebResponse
    Private Sub FormTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Main()
    End Sub

    Sub Main()
        ' add your data here: 
        Dim api As New ClassAPIZalora()

        ' this is where the magic happens:

        Dim doc1 As XmlDocument = New XmlDocument()
        Dim result As String = api.urlGetDocument("shippingLabel", "3184991")
        'Dim result As String = api.urlGetBrand
        doc1.Load(result)
        Console.WriteLine(result)
        Dim root As XmlElement = doc1.DocumentElement
        Dim nodes As XmlNodeList = root.SelectNodes("/SuccessResponse/Body/Documents/Document")

        Console.WriteLine(nodes.Item(0)("DocumentType").InnerText)
        Console.WriteLine(nodes.Item(0)("MimeType").InnerText)
        Console.WriteLine(nodes.Item(0)("File").InnerText)
        WebBrowser1.Url = New Uri("D:\test.html")
        'For Each node As XmlNode In nodes
        'Dim tempf As String = node("temp_f").InnerText
        'Dim tempc As String = node("temp_c").InnerText
        'Console.WriteLine("#" + node("DocumentType").InnerText.ToString + " " + node("MimeType").InnerText.ToString + " " + node("File").InnerText.ToString)
        'Next


        'Dim URLString As String = result
        'Dim reader As Xml.XmlTextReader = New Xml.XmlTextReader(URLString)

        'While reader.Read()

        '    Select Case reader.NodeType
        '        Case Xml.XmlNodeType.Element
        '            Console.Write("<" & reader.Name)

        '            While reader.MoveToNextAttribute()
        '                Console.Write(" " & reader.Name & "='" & reader.Value & "'")
        '            End While

        '            Console.Write(">")
        '            Console.WriteLine(">")
        '        Case Xml.XmlNodeType.Text
        '            Console.WriteLine(reader.Value)
        '        Case Xml.XmlNodeType.EndElement
        '            Console.Write("</" & reader.Name)
        '            Console.WriteLine(">")
        '    End Select
        'End While
    End Sub


    Function generateRequest(Url As String, user As String, key As String, version As String, action As String) As String
        Dim timeStamp As String = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss-0000")
        ' ATTENTION: parameters must be in alphabetical order
        Dim stringToHash As String =
        "Action=" + URLEncode(action) +
        "&Timestamp=" + URLEncode(timeStamp) +
        "&UserID=" + URLEncode(user) +
        "&Version=" + URLEncode(version)
        Dim hash As String = HashString(stringToHash, key)
        ' ATTENTION: parameters must be in alphabetical order
        Dim request As String =
        "Action=" + URLEncode(action) +
        "&Signature=" + URLEncode(hash) +
        "&Timestamp=" + URLEncode(timeStamp) +
        "&UserID=" + URLEncode(user) +
        "&Version=" + URLEncode(version)
        Return Url + "?" + request
    End Function

    Function URLEncode(EncodeStr As String) As String
        Dim i As Integer
        Dim erg As String
        erg = EncodeStr
        erg = Replace(erg, "%", Chr(1))
        erg = Replace(erg, "+", Chr(2))
        For i = 0 To 255
            Select Case i
        ' *** Allowed 'regular' characters
                Case 37, 43, 45, 46, 48 To 57, 65 To 90, 95, 97 To 122, 126
                Case 1 ' *** Replace original % 
                    erg = Replace(erg, Chr(i), "%25")
                Case 2 ' *** Replace original + 
                    erg = Replace(erg, Chr(i), "%2B")
                Case 32
                    erg = Replace(erg, Chr(i), "+")
                Case 3 To 15
                    erg = Replace(erg, Chr(i), "%0" & Hex(i))
                Case Else
                    erg = Replace(erg, Chr(i), "%" & Hex(i))
            End Select
        Next
        Return erg
    End Function

    Function HashString(ByVal StringToHash As String, ByVal HachKey As String) As String
        Dim myEncoder As New System.Text.UTF8Encoding
        Dim Key() As Byte = myEncoder.GetBytes(HachKey)
        Dim Text() As Byte = myEncoder.GetBytes(StringToHash)
        Dim myHMACSHA256 As New System.Security.Cryptography.HMACSHA256(Key)
        Dim HashCode As Byte() = myHMACSHA256.ComputeHash(Text)
        Dim hash As String = Replace(BitConverter.ToString(HashCode), "-", "")
        Return hash.ToLower
    End Function

    Private Sub FormTest_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class