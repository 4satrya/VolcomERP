Public Class ClassBliBliApi
    Public api_seller_key As String = get_setup_field("blibli_api_seller_key")
    Public username As String = get_setup_field("blibli_api_username")
    Public password As String = get_setup_field("blibli_api_password")
    Public request_id As String = get_setup_field("blibli_api_request_id")

    Function download_shipping_label(ByVal order_item_id As String) As String
        Dim out As String = ""

        Dim auth As String = Convert.ToBase64String(Text.Encoding.UTF8.GetBytes(username + ":" + password))

        Dim request As Net.HttpWebRequest = Net.WebRequest.Create("https://api.blibli.com/v2/proxy/mta/api/businesspartner/v1/order/downloadShippingLabel?channelId=VOLCOM&requestId=" + request_id + "&storeId=10001&orderItemId=" + order_item_id)

        request.Method = "GET"

        request.Accept = "application/json"
        request.ContentType = "application/json"

        request.Headers.Add("Authorization", "Basic " + auth)
        request.Headers.Add("API-Seller-Key", api_seller_key)

        Dim response As Net.HttpWebResponse = request.GetResponse()

        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

            Try
                out = json("value")("document")
            Catch ex As Exception
            End Try
        End Using

        response.Close()

        Return out
    End Function
End Class
