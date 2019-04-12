Imports System.Xml

Public Class ClassAPIZalora
    ' add your data here: 
    Dim userId As String = "system@volcom.co.id" 'login name / your email
    Dim key As String = "6609e836bf62e016c6504c1ff616f6f0cc1ce149" 'your API key/password
    Dim version As String = "1.0"
    Dim timeStamp As String = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss-0000") 'update every calling method
    Public order_number As String = ""
    Public item_id As String = ""
    Public zalora_id As String = ""
    Dim url As String = "https://sellercenter-api.zalora.co.id"

    Private Function URLEncode(EncodeStr As String) As String
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

    Private Function HashString(ByVal StringToHash As String, ByVal HachKey As String) As String
        Dim myEncoder As New System.Text.UTF8Encoding
        Dim Key() As Byte = myEncoder.GetBytes(HachKey)
        Dim Text() As Byte = myEncoder.GetBytes(StringToHash)
        Dim myHMACSHA256 As New System.Security.Cryptography.HMACSHA256(Key)
        Dim HashCode As Byte() = myHMACSHA256.ComputeHash(Text)
        Dim hash As String = Replace(BitConverter.ToString(HashCode), "-", "")
        Return hash.ToLower
    End Function

    '========= REQUEST
    Function urlGetBrand() As String
        Dim action As String = "GetBrands"
        timeStamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss-0000")
        ' ATTENTION: parameters must be in alphabetical order
        Dim stringToHash As String =
        "Action=" + URLEncode(action) +
        "&Timestamp=" + URLEncode(timeStamp) +
        "&UserID=" + URLEncode(userId) +
        "&Version=" + URLEncode(version)
        Dim hash As String = HashString(stringToHash, key)
        ' ATTENTION: parameters must be in alphabetical order
        Dim request As String =
        "Action=" + URLEncode(action) +
        "&Signature=" + URLEncode(hash) +
        "&Timestamp=" + URLEncode(timeStamp) +
        "&UserID=" + URLEncode(userId) +
        "&Version=" + URLEncode(version)
        Return url + "?" + request
    End Function

    Function urlGetDocument(ByVal doc_type As String, ByVal order_item_id As String) As String
        Dim action As String = "GetDocument"
        timeStamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss-0000")
        Dim stringToHash As String =
       "Action=" + URLEncode(action) +
       "&DocumentType=" + URLEncode(doc_type) +
       "&OrderItemIds=" + URLEncode("[" + order_item_id + "]") +
       "&Timestamp=" + URLEncode(timeStamp) +
       "&UserID=" + URLEncode(userId) +
       "&Version=" + URLEncode(version)

        Dim hash As String = HashString(stringToHash, key)
        Dim request As String =
       "Action=" + URLEncode(action) +
       "&DocumentType=" + URLEncode(doc_type) +
       "&OrderItemIds=" + URLEncode("[" + order_item_id + "]") +
       "&Signature=" + URLEncode(hash) +
       "&Timestamp=" + URLEncode(timeStamp) +
       "&UserID=" + URLEncode(userId) +
       "&Version=" + URLEncode(version)
        Return url + "?" + request
    End Function

    Function getStatus(ByVal order_item_id As String) As String
        Dim action As String = "GetOrder"
        timeStamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss-0000")
        Dim stringToHash As String =
       "Action=" + URLEncode(action) +
       "&OrderId=" + URLEncode("2061332") +
       "&Timestamp=" + URLEncode(timeStamp) +
       "&UserID=" + URLEncode(userId) +
       "&Version=" + URLEncode(version)

        Dim hash As String = HashString(stringToHash, key)
        Dim request As String =
       "Action=" + URLEncode(action) +
       "&OrderId=" + URLEncode("2061332") +
       "&Signature=" + URLEncode(hash) +
       "&Timestamp=" + URLEncode(timeStamp) +
       "&UserID=" + URLEncode(userId) +
       "&Version=" + URLEncode(version)

        Dim doc1 As XmlDocument = New XmlDocument()
        Dim result As String = url + "?" + request
        Return result
    End Function

    Function getOrders() As String
        Dim action As String = "GetOrders"
        timeStamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss-0000")
        Dim stringToHash As String =
        "Action=" + URLEncode(action) +
        "&CreatedAfter=" + URLEncode("2019-02-01") +
        "&CreatedBefore=" + URLEncode("2019-02-29") +
        "&Limit=" + URLEncode("1000") +
        "&Offset=" + URLEncode("0") +
        "&Status=" + URLEncode("pending") +
        "&Timestamp=" + URLEncode(timeStamp) +
        "&UserID=" + URLEncode(userId) +
        "&Version=" + URLEncode(version)

        Dim hash As String = HashString(stringToHash, key)
        Dim request As String =
       "Action=" + URLEncode(action) +
        "&CreatedAfter=" + URLEncode("2019-02-01") +
        "&CreatedBefore=" + URLEncode("2019-02-29") +
        "&Limit=" + URLEncode("1000") +
        "&Offset=" + URLEncode("0") +
       "&Signature=" + URLEncode(hash) +
       "&Status=" + URLEncode("pending") +
       "&Timestamp=" + URLEncode(timeStamp) +
       "&UserID=" + URLEncode(userId) +
       "&Version=" + URLEncode(version)
        Dim doc1 As XmlDocument = New XmlDocument()
        Dim result As String = url + "?" + request
        Return result
    End Function

    Function getOrderItems() As String
        Dim action As String = "GetOrderItems"
        timeStamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss-0000")
        Dim stringToHash As String =
        "Action=" + URLEncode(action) +
        "&OrderId=" + URLEncode("2063330") +
        "&Timestamp=" + URLEncode(timeStamp) +
        "&UserID=" + URLEncode(userId) +
        "&Version=" + URLEncode(version)

        Dim hash As String = HashString(stringToHash, key)
        Dim request As String =
       "Action=" + URLEncode(action) +
       "&OrderId=" + URLEncode("2063330") +
       "&Signature=" + URLEncode(hash) +
       "&Timestamp=" + URLEncode(timeStamp) +
       "&UserID=" + URLEncode(userId) +
       "&Version=" + URLEncode(version)
        Dim doc1 As XmlDocument = New XmlDocument()
        Dim result As String = url + "?" + request
        Return result
    End Function
End Class
