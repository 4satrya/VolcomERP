Imports System.Text.RegularExpressions

Public Class ClassValidEAN13
    Private Shared Function checksum_ean13(data As [String]) As Integer
        ' Test string for correct length
        If data.Length <> 12 AndAlso data.Length <> 13 Then
            Return -1
        End If

        ' Test string for being numeric
        For i As Integer = 0 To data.Length - 1
            If Integer.Parse(data(i)) < &H30 OrElse Integer.Parse(data(i)) > &H39 Then
                Return -1
            End If
        Next

        Dim sum As Integer = 0

        For i As Integer = 11 To 0 Step -1
            Dim digit As Integer = Integer.Parse(data(i)) - &H30
            If (i And 1) = 1 Then
                sum += digit
            Else
                sum += digit * 3
            End If
        Next
        Dim [mod] As Integer = sum Mod 10
        Return If([mod] = 0, 0, 10 - [mod])
    End Function
End Class
