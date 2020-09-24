Public Class ClassZaloraApi
    Public api_key As String = get_setup_field("zalora_api_key")
    Public user_id As String = get_setup_field("zalora_user_id")

    Function get_signature(ByVal parameter As DataTable) As String
        Dim url As String = ""

        For i = 0 To parameter.Rows.Count - 1
            url += parameter.Rows(i)("key").ToString + "=" + parameter.Rows(i)("value").ToString + "&"
        Next

        url = url.Substring(0, url.Length - 1)

        Dim encoding As New System.Text.UTF8Encoding

        Dim key() As Byte = encoding.GetBytes(api_key)
        Dim text() As Byte = encoding.GetBytes(url)

        Dim sha265 As New Security.Cryptography.HMACSHA256(key)
        Dim hash_code As Byte() = sha265.ComputeHash(text)
        Dim hash As String = Replace(BitConverter.ToString(hash_code), "-", "")

        Return hash.ToLower
    End Function

    Function download_shipping_label(ByVal order_item_id As String, ByVal type As String) As String
        Dim out As String = ""

        Dim parameter As DataTable = New DataTable

        parameter.Columns.Add("key", GetType(String))
        parameter.Columns.Add("value", GetType(String))

        parameter.Rows.Add("Action", "GetDocument")
        parameter.Rows.Add("DocumentType", type)
        parameter.Rows.Add("Format", "JSON")
        parameter.Rows.Add("OrderItemIds", Uri.EscapeDataString("[" + order_item_id + "]"))
        parameter.Rows.Add("Timestamp", Uri.EscapeDataString(DateTime.Parse(Now().ToUniversalTime().ToString).ToString("yyyy-MM-ddTHH:mm:ss+00:00")))
        parameter.Rows.Add("UserID", Uri.EscapeDataString(user_id))
        parameter.Rows.Add("Version", "1.0")

        Dim signature As String = get_signature(parameter)

        parameter.Rows.Add("Signature", signature)

        Dim url As String = "https://sellercenter-api.zalora.co.id?"

        For i = 0 To parameter.Rows.Count - 1
            url += parameter.Rows(i)("key").ToString + "=" + parameter.Rows(i)("value").ToString + "&"
        Next

        url = url.Substring(0, url.Length - 1)

        Dim request As Net.HttpWebRequest = Net.WebRequest.Create(url)

        request.Method = "GET"

        Dim response As Net.HttpWebResponse = request.GetResponse()

        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

            out = json("SuccessResponse")("Body")("Documents")("Document")("File")
        End Using

        response.Close()

        Return out
    End Function
End Class
