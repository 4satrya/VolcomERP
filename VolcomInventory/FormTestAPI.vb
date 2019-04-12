Imports System

Public Class FormTestAPI
    Private Sub FormTestAPI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Main()
    End Sub

    Sub Main()
        ' add your data here: 
        Dim userId As String = "catur@volcom.co.id" 'login name / your email
        Dim password As String = "a7c18762d5dd6af2deb8" 'your API key/password
        Dim version As String = "1.0"
        Dim action As String = "GetFailureReasons"
        Dim url As String = "https://api.sellercenter.net/"
        'e.g.: "https://sellercenter-api-linio-co.sellercenter.net/"
        Dim result As String

        ' this is where the magic happens:
        result = generateRequest(url, userId, password, version, action)
        Console.WriteLine(result)
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

    ' use this function instead of HttpServerUtility.UrlEncode()
    ' because we need uppercase letters
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
                Case 1 erg = Replace(erg, Chr(i), "%25")
                Case 2 erg = Replace(erg, Chr(i), "%2B")
                Case 32 erg = Replace(erg, Chr(i), "+")
          Case 3 To 15 erg = Replace(erg, Chr(i), "%0" & Hex(i))
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

End Class