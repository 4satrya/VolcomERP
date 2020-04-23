Public Class ClassShopifyApi
    Public username As String = get_setup_field("shopify_api_username")
    Public password As String = get_setup_field("shopify_api_password")
    Public shop As String = get_setup_field("shopify_api_shop")

    Function get_location_id() As String
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        Dim request As Net.WebRequest = Net.WebRequest.Create("https://" + username + ":" + password + "@" + shop + "/admin/api/2020-04/locations.json")

        request.Method = "GET"

        request.Credentials = New Net.NetworkCredential(username, password)

        Dim location_id As String = ""

        Dim response As Net.WebResponse = request.GetResponse()

        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

            For Each row In json("locations").ToList
                location_id = row("id").ToString
            Next
        End Using

        response.Close()

        Return location_id
    End Function

    Function get_product() As DataTable
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        Dim data As DataTable = New DataTable

        data.Columns.Add("variant_id", GetType(String))
        data.Columns.Add("product_id", GetType(String))
        data.Columns.Add("sku", GetType(String))
        data.Columns.Add("inventory_item_id", GetType(String))
        data.Columns.Add("compare_price", GetType(String))
        data.Columns.Add("design_price", GetType(String))

        Dim url As String = "https://" + username + ":" + password + "@" + shop + "/admin/api/2020-04/products.json"

        Dim since_id As String = ""

        For i = 0 To 1000
            Dim url_since_id As String = url + (If(Not since_id = "", "?since_id=" + since_id, ""))

            Dim request As Net.WebRequest = Net.WebRequest.Create(url_since_id)

            request.Method = "GET"

            request.Credentials = New Net.NetworkCredential(username, password)

            Dim response As Net.WebResponse = request.GetResponse()

            Using dataStream As IO.Stream = response.GetResponseStream()
                Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

                Dim responseFromServer As String = reader.ReadToEnd()

                Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

                If json("products").Count > 0 Then
                    For Each row In json("products").ToList
                        since_id = row("id")

                        For Each row2 In row("variants").ToList
                            data.Rows.Add(row2("id"), row2("product_id"), row2("sku"), row2("inventory_item_id"), row2("compare_at_price"), row2("price"))
                        Next
                    Next
                Else
                    Exit For
                End If
            End Using

            response.Close()
        Next

        Return data
    End Function

    Sub add_product(location_id As String, inventory_item_id As String, available_adjustment As String)
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        Dim request As Net.WebRequest = Net.WebRequest.Create("https://" + username + ":" + password + "@" + shop + "/admin/api/2020-04/inventory_levels/adjust.json")

        request.Method = "POST"

        request.Credentials = New Net.NetworkCredential(username, password)

        Dim body As String = "location_id=" + location_id + "&inventory_item_id=" + inventory_item_id + "&available_adjustment=" + available_adjustment

        Dim body_array As Byte() = System.Text.Encoding.UTF8.GetBytes(body)

        request.ContentType = "application/x-www-form-urlencoded"

        request.ContentLength = body_array.Length

        Dim data_stream As IO.Stream = request.GetRequestStream()

        data_stream.Write(body_array, 0, body_array.Length)

        data_stream.Close()

        Dim response As Net.WebResponse = request.GetResponse()

        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()
        End Using

        response.Close()
    End Sub

    Sub sync_sku()
        Dim product As DataTable = get_product()

        For i = 0 To product.Rows.Count - 1
            Dim query As String = "INSERT IGNORE INTO tb_m_product_shopify (variant_id, sku, product_id, inventory_item_id) VALUES ('" + product.Rows(i)("variant_id").ToString + "', '" + product.Rows(i)("sku").ToString + "', '" + product.Rows(i)("product_id").ToString + "', '" + product.Rows(i)("inventory_item_id").ToString + "')"

            execute_non_query(query, True, "", "", "", "")

            Dim q_price As String = "INSERT INTO tb_m_price_shopify (sku, compare_price, design_price, date) VALUES ('" + product.Rows(i)("sku").ToString + "', '" + product.Rows(i)("compare_price").ToString + "', '" + product.Rows(i)("design_price").ToString + "', NOW())"

            execute_non_query(q_price, True, "", "", "", "")
        Next
    End Sub


    Sub get_order_erp()
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        'get url order
        Dim cond_order As String = get_setup_field("url_order")

        'get max id
        Dim since_id As String = execute_query("SELECT IFNULL(MAX(id),0) AS `since_id` FROM tb_ol_store_order ", 0, True, "", "", "", "")

        Dim url As String = "https://" + username + ":" + password + "@" + shop + "/admin/api/2020-04/orders.json?since_id=" + since_id + cond_order
        Console.WriteLine(url)
        Dim request As Net.WebRequest = Net.WebRequest.Create(url)
        request.Method = "GET"
        request.Credentials = New Net.NetworkCredential(username, password)
        Dim response As Net.WebResponse = request.GetResponse()

        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

            If json("orders").Count > 0 Then
                For Each row In json("orders").ToList
                    'var data general
                    Dim id As String = ""
                    Dim sales_order_ol_shop_number As String = ""
                    Dim sales_order_ol_shop_date As String = ""
                    Dim payment_method As String = ""
                    Dim tracking_code As String = ""
                    Dim financial_status As String = ""

                    id = row("id").ToString
                    sales_order_ol_shop_number = row("order_number").ToString
                    sales_order_ol_shop_date = DateTime.Parse(row("created_at").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                    payment_method = row("gateway").ToString
                    tracking_code = ""
                    financial_status = row("financial_status").ToString

                    'data customer
                    Dim customer_name As String = ""
                    customer_name = row("customer")("first_name").ToString + " " + row("customer")("last_name").ToString

                    'data shipping
                    Dim shipping_name As String = ""
                    Dim shipping_address As String = ""
                    Dim shipping_phone As String = ""
                    Dim shipping_city As String = ""
                    Dim shipping_post_code As String = ""
                    Dim shipping_region As String = ""
                    Try
                        shipping_name = If(row("shipping_address")("name") Is Nothing, "", row("shipping_address")("name").ToString)
                    Catch ex As Exception
                        shipping_name = ""
                    End Try
                    Try
                        shipping_address = If(row("shipping_address")("address1") Is Nothing, "", row("shipping_address")("address1").ToString)
                    Catch ex As Exception
                        shipping_address = ""
                    End Try
                    Try
                        shipping_phone = If(row("shipping_address")("phone") Is Nothing, "", row("shipping_address")("phone").ToString)
                    Catch ex As Exception
                        shipping_phone = ""
                    End Try
                    Try
                        shipping_city = If(row("shipping_address")("city") Is Nothing, "", row("shipping_address")("city").ToString)
                    Catch ex As Exception
                        shipping_city = ""
                    End Try
                    Try
                        shipping_post_code = If(row("shipping_address")("zip") Is Nothing, "", row("shipping_address")("zip").ToString)
                    Catch ex As Exception
                        shipping_post_code = ""
                    End Try
                    Try
                        shipping_region = If(row("shipping_address")("province") Is Nothing, "", row("shipping_address")("province").ToString)
                    Catch ex As Exception
                        shipping_region = ""
                    End Try



                    'detail line item
                    Dim qins As String = "INSERT tb_ol_store_order(id, sales_order_ol_shop_number, sales_order_ol_shop_date, customer_name, shipping_name, shipping_address, shipping_phone, 
                    shipping_city, shipping_post_code, shipping_region, payment_method, tracking_code, ol_store_sku, ol_store_id, sku, design_price, sales_order_det_qty, financial_status) VALUES "
                    Dim ol_store_sku As String = ""
                    Dim ol_store_id As String = ""
                    Dim sku As String = ""
                    Dim design_price As String = ""
                    Dim sales_order_det_qty As String = ""
                    Dim i As Integer = 0
                    For Each row_item In row("line_items").ToList
                        ol_store_sku = row_item("sku").ToString
                        ol_store_id = row_item("id").ToString
                        sku = row_item("sku").ToString
                        design_price = decimalSQL(row_item("price").ToString)
                        sales_order_det_qty = decimalSQL(row_item("quantity").ToString)

                        If i > 0 Then
                            qins += ","
                        End If
                        qins += "('" + id + "', '" + sales_order_ol_shop_number + "', '" + sales_order_ol_shop_date + "', '" + customer_name + "', '" + shipping_name + "', '" + shipping_address + "', '" + shipping_phone + "', 
                        '" + shipping_city + "', '" + shipping_post_code + "', '" + shipping_region + "', '" + payment_method + "', '" + tracking_code + "', '" + ol_store_sku + "', '" + ol_store_id + "', '" + sku + "', '" + design_price + "', '" + sales_order_det_qty + "', '" + addSlashes(financial_status) + "') "
                        i += 1
                    Next

                    'insert ortder
                    If i > 0 Then
                        execute_non_query(qins, True, "", "", "", "")
                    End If
                Next
            End If
        End Using

        response.Close()
    End Sub

    Private Function SendRequest(str_url As String, jsonDataBytes As Byte(), contentType As String, method As String, ByVal username As String, ByVal pass As String) As String
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        Dim response As String
        Dim request As Net.WebRequest


        Dim url As Uri = New Uri(str_url)

        request = Net.WebRequest.Create(url)
        request.ContentLength = jsonDataBytes.Length
        request.ContentType = contentType
        request.Method = method
        request.Credentials = New Net.NetworkCredential(username, password)


        Using requestStream = request.GetRequestStream
            requestStream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
            requestStream.Close()

            Using responseStream = request.GetResponse.GetResponseStream
                Using reader As New IO.StreamReader(responseStream)
                    response = reader.ReadToEnd()
                End Using
            End Using
        End Using

        Return response
    End Function

    Sub upd_price(ByVal product_code As String, ByVal normal_price As String, ByVal current_price As String)
        '        Dim data = Text.Encoding.UTF8.GetBytes("{
        '  ""product"": {
        '    ""variants"": [
        '      {
        '        ""id"": 31852294832164,
        '        ""price"": ""1""
        '      }
        '    ]
        '  }
        '}")

        Dim q As String = "SELECT variant_id,sku
FROM 
(
	SELECT * FROM `tb_m_product_shopify` 
	WHERE sku = '" & product_code & "'
	ORDER BY variant_id DESC
) p 
GROUP BY p.sku"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

        For i = 0 To dt.Rows.Count - 1
            Dim data = Text.Encoding.UTF8.GetBytes("{
  ""variant"": {
    ""id"": " & dt.Rows(i)("variant_id").ToString & ",
    ""price"": """ & current_price & """,
    ""compare_at_price"": """ & normal_price & """
  }
}")
            Dim result_post As String = SendRequest("https://" & username & ":" & password & "@" & shop & "/admin/api/2020-04/variants/" & dt.Rows(i)("variant_id").ToString & ".json", data, "application/json", "PUT", username, password)
            'Console.WriteLine(result_post.ToString)
        Next
    End Sub
End Class
