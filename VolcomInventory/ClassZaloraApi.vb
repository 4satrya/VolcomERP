Public Class ClassZaloraApi
    Public api_key As String = get_setup_field("zalora_api_key")
    Public user_id As String = get_setup_field("zalora_user_id")
    Dim status_order As String = "pending"
    Dim id_store_group As String = get_setup_field("zalora_comp_group")
    Dim data_size As New DataTable
    'testing environment
    'Public api_key As String = "769595ee282d1a51c09f7bf4921866c86d54125a"
    'Public user_id As String = "septian@volcom.co.id"
    'Dim status_order As String = "ready_to_ship"

    Sub New()
        Dim id_code_detail_size As String = get_setup_field("id_code_product_size")
        Dim query As String = "SELECT cd.id_code_detail,cd.code, cd.code_detail_name FROM tb_m_code_detail cd WHERE cd.id_code=" + id_code_detail_size + " "
        data_size = execute_query(query, -1, True, "", "", "", "")
    End Sub

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

    Sub getOrder2020()
        'from july
        Dim page As Integer = 4
        For p As Integer = 0 To page - 1
            Console.WriteLine("Page : " + (p + 1).ToString)
            Dim parameter As DataTable = New DataTable

            parameter.Columns.Add("key", GetType(String))
            parameter.Columns.Add("value", GetType(String))

            parameter.Rows.Add("Action", "GetOrders")
            parameter.Rows.Add("CreatedAfter", "2020-07-01")
            parameter.Rows.Add("Format", "JSON")
            parameter.Rows.Add("Limit", "1000")
            parameter.Rows.Add("Offset", (p * 1000).ToString)
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

                'var
                Dim id As String = ""
                Dim sales_order_ol_shop_number As String = ""
                Dim customer_name As String = ""

                Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)
                If json("SuccessResponse")("Body")("Orders")("Order").Count > 0 Then
                    'array
                    Dim query As String = "INSERT INTO tb_temp_order_zalora(id, order_number, customer) VALUES "
                    Dim ix As Integer = 0
                    For Each row In json("SuccessResponse")("Body")("Orders")("Order").ToList
                        If ix > 0 Then
                            query += ","
                        End If

                        'reset
                        id = ""
                        sales_order_ol_shop_number = ""
                        customer_name = ""


                        id = row("OrderId").ToString
                        sales_order_ol_shop_number = row("OrderNumber").ToString
                        customer_name = row("CustomerFirstName").ToString + " " + row("CustomerLastName").ToString


                        'detail items
                        query += "('" + id + "', '" + sales_order_ol_shop_number + "', '" + addSlashes(customer_name) + "') "
                        ix += 1
                        'execute_non_query(query, True, "", "", "", "")
                    Next
                    If (ix + 1) > 0 Then
                        execute_non_query_long(query, True, "", "", "", "")
                    End If
                End If


            End Using

            response.Close()
        Next
    End Sub

    Function get_page_order() As Integer
        Dim parameter As DataTable = New DataTable

        parameter.Columns.Add("key", GetType(String))
        parameter.Columns.Add("value", GetType(String))

        parameter.Rows.Add("Action", "GetOrders")
        parameter.Rows.Add("Format", "JSON")
        parameter.Rows.Add("Limit", "1")
        parameter.Rows.Add("Offset", "0")
        parameter.Rows.Add("Status", status_order)
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
        'Console.WriteLine(url)

        request.Method = "GET"

        Dim response As Net.HttpWebResponse = request.GetResponse()

        Dim page As Decimal = 0
        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

            If json("SuccessResponse")("Head").Count > 0 Then
                page = Math.Ceiling(Decimal.Parse(json("SuccessResponse")("Head")("TotalCount").ToString) / 1000)
            End If
        End Using

        response.Close()

        Return page
    End Function

    Sub get_order_list()
        Dim page As Integer = get_page_order()
        For p As Integer = 0 To page - 1
            Dim parameter As DataTable = New DataTable

            parameter.Columns.Add("key", GetType(String))
            parameter.Columns.Add("value", GetType(String))

            parameter.Rows.Add("Action", "GetOrders")
            parameter.Rows.Add("Format", "JSON")
            parameter.Rows.Add("Limit", "1000")
            parameter.Rows.Add("Offset", (p * 1000).ToString)
            parameter.Rows.Add("Status", status_order)
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

                'set into datatable
                Dim dt_order As New DataTable
                dt_order.Columns.Add("id", GetType(String))
                dt_order.Columns.Add("sales_order_ol_shop_number", GetType(String))
                dt_order.Columns.Add("sales_order_ol_shop_date", GetType(DateTime))
                dt_order.Columns.Add("customer_name", GetType(String))
                dt_order.Columns.Add("shipping_name", GetType(String))
                dt_order.Columns.Add("shipping_address", GetType(String))
                dt_order.Columns.Add("shipping_address1", GetType(String))
                dt_order.Columns.Add("shipping_address2", GetType(String))
                dt_order.Columns.Add("shipping_phone", GetType(String))
                dt_order.Columns.Add("shipping_city", GetType(String))
                dt_order.Columns.Add("shipping_post_code", GetType(String))
                dt_order.Columns.Add("shipping_region", GetType(String))
                dt_order.Columns.Add("payment_method", GetType(String))

                'var
                Dim id As String = ""
                Dim sales_order_ol_shop_number As String = ""
                Dim sales_order_ol_shop_date As DateTime = Nothing
                Dim customer_name As String = ""
                Dim shipping_name As String = ""
                Dim shipping_address As String = ""
                Dim shipping_address1 As String = ""
                Dim shipping_address2 As String = ""
                Dim shipping_phone As String = ""
                Dim shipping_city As String = ""
                Dim shipping_post_code As String = ""
                Dim shipping_region As String = ""
                Dim payment_method As String = ""


                Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)
                If json("SuccessResponse")("Body")("Orders")("Order").Count > 0 Then
                    If responseFromServer.Contains("""Order"":[") Then
                        'array
                        For Each row In json("SuccessResponse")("Body")("Orders")("Order").ToList
                            'check first
                            Dim q_check As String = "SELECT * FROM tb_ol_store_order WHERE id='" & row("OrderId").ToString & "' AND id_comp_group='" + id_store_group + "' "
                            Dim dt_check As DataTable = execute_query(q_check, -1, True, "", "", "", "")
                            If Not dt_check.Rows.Count > 0 Then
                                'reset
                                id = ""
                                sales_order_ol_shop_number = ""
                                sales_order_ol_shop_date = Nothing
                                customer_name = ""
                                shipping_name = ""
                                shipping_address = ""
                                shipping_address1 = ""
                                shipping_address2 = ""
                                shipping_phone = ""
                                shipping_city = ""
                                shipping_post_code = ""
                                shipping_region = ""
                                payment_method = ""

                                'clear dan isi dt_order 1 dimensi
                                Try
                                    dt_order.Clear()
                                Catch ex As Exception
                                End Try
                                id = row("OrderId").ToString
                                sales_order_ol_shop_number = row("OrderNumber").ToString
                                sales_order_ol_shop_date = row("CreatedAt")
                                customer_name = row("CustomerFirstName").ToString + " " + row("CustomerLastName").ToString
                                shipping_name = row("AddressShipping")("FirstName").ToString + " " + row("AddressShipping")("LastName").ToString
                                shipping_address = row("AddressShipping")("Address1").ToString + " " + row("AddressShipping")("Address2").ToString
                                shipping_address1 = row("AddressShipping")("Address1").ToString
                                shipping_address2 = row("AddressShipping")("Address2").ToString
                                shipping_phone = row("AddressShipping")("Phone").ToString
                                shipping_city = row("AddressShipping")("City").ToString
                                shipping_post_code = row("AddressShipping")("PostCode").ToString
                                shipping_region = row("AddressShipping")("Region").ToString
                                payment_method = row("PaymentMethod").ToString
                                dt_order.Rows.Add(id, sales_order_ol_shop_number, sales_order_ol_shop_date, customer_name, shipping_name, shipping_address, shipping_address1, shipping_address2, shipping_phone, shipping_city, shipping_post_code, shipping_region, payment_method)

                                'detail items
                                proceed_order_detail(dt_order)
                            End If
                        Next
                    Else
                        'no array
                        'check first
                        Dim q_check As String = "SELECT * FROM tb_ol_store_order WHERE id='" & json("SuccessResponse")("Body")("Orders")("Order")("OrderId").ToString & "' AND id_comp_group='" + id_store_group + "' "
                        Dim dt_check As DataTable = execute_query(q_check, -1, True, "", "", "", "")
                        If Not dt_check.Rows.Count > 0 Then
                            Try
                                dt_order.Clear()
                            Catch ex As Exception
                            End Try
                            id = json("SuccessResponse")("Body")("Orders")("Order")("OrderId").ToString
                            sales_order_ol_shop_number = json("SuccessResponse")("Body")("Orders")("Order")("OrderNumber").ToString
                            sales_order_ol_shop_date = json("SuccessResponse")("Body")("Orders")("Order")("CreatedAt")
                            customer_name = json("SuccessResponse")("Body")("Orders")("Order")("CustomerFirstName").ToString + " " + json("SuccessResponse")("Body")("Orders")("Order")("CustomerLastName").ToString
                            shipping_name = json("SuccessResponse")("Body")("Orders")("Order")("AddressShipping")("FirstName").ToString + " " + json("SuccessResponse")("Body")("Orders")("Order")("AddressShipping")("LastName").ToString
                            shipping_address = json("SuccessResponse")("Body")("Orders")("Order")("AddressShipping")("Address1").ToString + " " + json("SuccessResponse")("Body")("Orders")("Order")("AddressShipping")("Address2").ToString
                            shipping_address1 = json("SuccessResponse")("Body")("Orders")("Order")("AddressShipping")("Address1").ToString
                            shipping_address2 = json("SuccessResponse")("Body")("Orders")("Order")("AddressShipping")("Address2").ToString
                            shipping_phone = json("SuccessResponse")("Body")("Orders")("Order")("AddressShipping")("Phone").ToString
                            shipping_city = json("SuccessResponse")("Body")("Orders")("Order")("AddressShipping")("City").ToString
                            shipping_post_code = json("SuccessResponse")("Body")("Orders")("Order")("AddressShipping")("PostCode").ToString
                            shipping_region = json("SuccessResponse")("Body")("Orders")("Order")("AddressShipping")("Region").ToString
                            payment_method = json("SuccessResponse")("Body")("Orders")("Order")("PaymentMethod").ToString
                            dt_order.Rows.Add(id, sales_order_ol_shop_number, sales_order_ol_shop_date, customer_name, shipping_name, shipping_address, shipping_address1, shipping_address2, shipping_phone, shipping_city, shipping_post_code, shipping_region, payment_method)

                            'detail items
                            proceed_order_detail(dt_order)
                        End If
                    End If
                End If


            End Using

            response.Close()
        Next
    End Sub

    Sub proceed_order_detail(ByVal dtx As DataTable)
        Dim id_order As String = dtx.Rows(0)("id").ToString
        Dim order_number As String = dtx.Rows(0)("sales_order_ol_shop_number").ToString
        'generate tracking number
        Try
            setTrackingNumber(id_order)
        Catch ex As Exception
            Dim od As New ClassSalesOrder()
            od.insertLogWebOrder(id_order, "Failed set tracking number:" + ex.ToString, id_store_group)
        End Try
        'generate invoice
        Try
            setInvoiceNumber(id_order, order_number)
        Catch ex As Exception
            Dim od As New ClassSalesOrder()
            od.insertLogWebOrder(id_order, "Failed set invoice number:" + ex.ToString, id_store_group)
        End Try

        Dim dtd As DataTable = get_order_detail(id_order)
        If dtd.Rows.Count > 0 Then
            If dtd.Rows(0)("tracking_code").ToString <> "" Then 'sudah ada awb
                For d As Integer = 0 To dtd.Rows.Count - 1
                    'general
                    Dim sales_order_ol_shop_number As String = ""
                    Dim sales_order_ol_shop_date As String = ""
                    Dim payment_method As String = ""
                    Dim checkout_id As String = ""
                    Dim tracking_code As String = ""
                    Dim shipment_provider As String = ""
                    Dim financial_status As String = ""
                    Dim total_discounts As String = ""
                    Dim discount_code As String = ""
                    sales_order_ol_shop_number = dtx.Rows(0)("sales_order_ol_shop_number").ToString
                    sales_order_ol_shop_date = DateTime.Parse(dtx.Rows(0)("sales_order_ol_shop_date").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                    payment_method = dtx.Rows(0)("payment_method").ToString
                    checkout_id = ""
                    tracking_code = dtd.Rows(d)("tracking_code").ToString
                    shipment_provider = addSlashes(dtd.Rows(d)("shipment_provider").ToString)
                    financial_status = ""
                    total_discounts = "0"
                    discount_code = ""

                    'data customer
                    Dim customer_name As String = ""
                    customer_name = dtx.Rows(0)("customer_name").ToString

                    'data shipping
                    Dim shipping_name As String = ""
                    Dim shipping_address As String = ""
                    Dim shipping_address1 As String = ""
                    Dim shipping_address2 As String = ""
                    Dim shipping_phone As String = ""
                    Dim shipping_city As String = ""
                    Dim shipping_post_code As String = ""
                    Dim shipping_region As String = ""
                    shipping_name = dtx.Rows(0)("shipping_name").ToString
                    shipping_address = dtx.Rows(0)("shipping_address1").ToString
                    shipping_address += dtx.Rows(0)("shipping_address2").ToString + " "
                    shipping_address += dtx.Rows(0)("shipping_city").ToString + " "
                    shipping_address += dtx.Rows(0)("shipping_region").ToString + " "
                    shipping_address += dtx.Rows(0)("shipping_post_code").ToString + " "
                    shipping_address += "Phone : " + dtx.Rows(0)("shipping_phone").ToString
                    shipping_address1 = dtx.Rows(0)("shipping_address1").ToString
                    shipping_address2 = dtx.Rows(0)("shipping_address2").ToString
                    shipping_phone = dtx.Rows(0)("shipping_phone").ToString
                    shipping_city = dtx.Rows(0)("shipping_city").ToString
                    shipping_post_code = dtx.Rows(0)("shipping_post_code").ToString
                    shipping_region = dtx.Rows(0)("shipping_region").ToString

                    'detail shipping
                    Dim shipping_price As String = "0"

                    'detail item
                    Dim ol_store_sku As String = ""
                    Dim ol_store_id As String = ""
                    Dim item_id As String = ""
                    Dim sku As String = ""
                    Dim design_price As String = ""
                    Dim sales_order_det_qty As String = ""
                    Dim grams As String = ""
                    Dim discount_allocations_amo As String = "0"
                    ol_store_sku = dtd.Rows(d)("ol_store_sku").ToString
                    ol_store_id = dtd.Rows(d)("ol_store_id").ToString
                    item_id = dtd.Rows(d)("item_id").ToString
                    sku = dtd.Rows(d)("sku").ToString
                    design_price = decimalSQL(dtd.Rows(d)("design_price").ToString)
                    sales_order_det_qty = "1"
                    grams = "0"
                    discount_allocations_amo = "0"

                    'insert
                    Dim qins As String = "INSERT tb_ol_store_order(id, sales_order_ol_shop_number, sales_order_ol_shop_date, customer_name, shipping_name, shipping_address,shipping_address1,shipping_address2, shipping_phone, 
                    shipping_city, shipping_post_code, shipping_region, payment_method, tracking_code, shipment_provider, ol_store_sku, ol_store_id, item_id, sku, design_price, sales_order_det_qty, grams, financial_status, total_disc_order, discount_allocations_amo,checkout_id, shipping_price, discount_code, id_comp_group) VALUES "
                    qins += "('" + id_order + "', '" + sales_order_ol_shop_number + "', '" + sales_order_ol_shop_date + "', '" + addSlashes(customer_name) + "', '" + addSlashes(shipping_name) + "', '" + addSlashes(shipping_address) + "','" + addSlashes(shipping_address1) + "','" + addSlashes(shipping_address2) + "', '" + addSlashes(shipping_phone) + "', 
                    '" + addSlashes(shipping_city) + "', '" + addSlashes(shipping_post_code) + "', '" + addSlashes(shipping_region) + "', '" + payment_method + "', '" + tracking_code + "', '" + shipment_provider + "', '" + ol_store_sku + "', '" + ol_store_id + "', '" + item_id + "', '" + sku + "', '" + design_price + "', '" + sales_order_det_qty + "','" + grams + "', '" + addSlashes(financial_status) + "', '" + total_discounts + "', '" + discount_allocations_amo + "','" + addSlashes(checkout_id) + "', '" + shipping_price + "', '" + discount_code + "', '" + id_store_group + "') "
                    execute_non_query(qins, True, "", "", "", "")
                Next
            End If
        End If
    End Sub

    Function get_order_detail(ByVal id As String) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("ol_store_id", GetType(String))
        dt.Columns.Add("item_id", GetType(String))
        dt.Columns.Add("sku", GetType(String))
        dt.Columns.Add("ol_store_sku", GetType(String))
        dt.Columns.Add("design_price", GetType(Decimal))
        dt.Columns.Add("tracking_code", GetType(String))
        dt.Columns.Add("shipment_provider", GetType(String))
        dt.Columns.Add("status", GetType(String))
        dt.Columns.Add("updated_at", GetType(String))

        Dim parameter_det As DataTable = New DataTable

        parameter_det.Columns.Add("key", GetType(String))
        parameter_det.Columns.Add("value", GetType(String))

        parameter_det.Rows.Add("Action", "GetOrderItems")
        parameter_det.Rows.Add("Format", "JSON")
        parameter_det.Rows.Add("OrderId", id)
        parameter_det.Rows.Add("Timestamp", Uri.EscapeDataString(DateTime.Parse(Now().ToUniversalTime().ToString).ToString("yyyy-MM-ddTHH:mm:ss+00:00")))
        parameter_det.Rows.Add("UserID", Uri.EscapeDataString(user_id))
        parameter_det.Rows.Add("Version", "1.0")

        Dim signature_det As String = get_signature(parameter_det)

        parameter_det.Rows.Add("Signature", signature_det)

        Dim url_det As String = "https://sellercenter-api.zalora.co.id?"

        For i = 0 To parameter_det.Rows.Count - 1
            url_det += parameter_det.Rows(i)("key").ToString + "=" + parameter_det.Rows(i)("value").ToString + "&"
        Next

        url_det = url_det.Substring(0, url_det.Length - 1)

        Dim request_det As Net.HttpWebRequest = Net.WebRequest.Create(url_det)

        request_det.Method = "GET"
        Dim response_det As Net.HttpWebResponse = request_det.GetResponse()
        Using dataStreamDet As IO.Stream = response_det.GetResponseStream()
            Dim reader_det As IO.StreamReader = New IO.StreamReader(dataStreamDet)

            Dim responseFromServerDet As String = reader_det.ReadToEnd()

            'array
            Dim json_det As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServerDet)
            If json_det("SuccessResponse")("Body")("OrderItems")("OrderItem").Count > 0 Then
                Dim sku As String = ""

                If responseFromServerDet.Contains("""OrderItem"":[") Then
                    'array
                    For Each row_det In json_det("SuccessResponse")("Body")("OrderItems")("OrderItem").ToList
                        sku = ""
                        sku = getSKU(row_det("Sku").ToString.Substring(0, 9), row_det("Variation").ToString)
                        dt.Rows.Add(row_det("ShopId").ToString, row_det("OrderItemId").ToString, sku, row_det("ShopSku").ToString, row_det("ItemPrice"), row_det("TrackingCode").ToString, row_det("ShipmentProvider").ToString, row_det("Status").ToString, row_det("UpdatedAt").ToString)
                    Next
                Else
                    'non array
                    sku = ""
                    sku = getSKU(json_det("SuccessResponse")("Body")("OrderItems")("OrderItem")("Sku").ToString.Substring(0, 9), json_det("SuccessResponse")("Body")("OrderItems")("OrderItem")("Variation").ToString)
                    dt.Rows.Add(json_det("SuccessResponse")("Body")("OrderItems")("OrderItem")("ShopId").ToString, json_det("SuccessResponse")("Body")("OrderItems")("OrderItem")("OrderItemId").ToString, sku, json_det("SuccessResponse")("Body")("OrderItems")("OrderItem")("ShopSku").ToString, json_det("SuccessResponse")("Body")("OrderItems")("OrderItem")("ItemPrice"), json_det("SuccessResponse")("Body")("OrderItems")("OrderItem")("TrackingCode").ToString, json_det("SuccessResponse")("Body")("OrderItems")("OrderItem")("ShipmentProvider").ToString, json_det("SuccessResponse")("Body")("OrderItems")("OrderItem")("Status").ToString, json_det("SuccessResponse")("Body")("OrderItems")("OrderItem")("UpdatedAt").ToString)
                End If
            End If
        End Using
        response_det.Close()
        Return dt
    End Function

    Function getSKU(ByVal design_code_par As String, ByVal size_par As String) As String
        Dim code9 As String = design_code_par
        Dim variation As String = size_par
        If Not isNumber(variation) Then
            variation = variation
        Else
            variation = variation.PadLeft(2, "0")
        End If
        If variation < "10" Then
            variation = variation
        Else
            variation = If(variation = "One Size", "One Size", variation.Replace("in", ""))
        End If
        Dim data_size_cek As DataRow() = data_size.Select("[code_detail_name]='" + variation + "' ")
        Dim code_size As String = ""
        If data_size_cek.Length <= 0 Then
            code_size = ""
        Else
            code_size = data_size_cek(0)("code").ToString
        End If
        Dim sku As String = code9 + code_size
        Return sku
    End Function

    Sub setTrackingNumber(ByVal id_order_par As String)
        Dim dtd As DataTable = get_order_detail(id_order_par)
        Dim item_id_collect As String = ""
        Dim shipment_provider As String = ""
        For y As Integer = 0 To dtd.Rows.Count - 1
            If y > 0 Then
                item_id_collect += ","
            End If
            item_id_collect += dtd.Rows(y)("item_id").ToString
            shipment_provider = Uri.EscapeDataString(dtd.Rows(y)("shipment_provider").ToString)
        Next
        Dim item_id_collect_encode As String = Uri.EscapeDataString("[" + item_id_collect + "]")
        Dim parameter As DataTable = New DataTable
        parameter.Columns.Add("key", GetType(String))
        parameter.Columns.Add("value", GetType(String))
        parameter.Rows.Add("Action", "SetStatusToPackedByMarketplace")
        parameter.Rows.Add("DeliveryType", "dropship")
        parameter.Rows.Add("Format", "JSON")
        parameter.Rows.Add("OrderItemIds", item_id_collect_encode)
        parameter.Rows.Add("ShippingProvider", shipment_provider)
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
        request.Method = "POST"
        Dim response As Net.HttpWebResponse = request.GetResponse()
        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
        End Using
        response.Close()
    End Sub

    Sub setInvoiceNumber(ByVal id_order_par As String, ByVal order_number_par As String)
        Dim dtd As DataTable = get_order_detail(id_order_par)
        For y As Integer = 0 To dtd.Rows.Count - 1
            Dim item_id As String = dtd.Rows(y)("item_id").ToString

            Dim parameter As DataTable = New DataTable
            parameter.Columns.Add("key", GetType(String))
            parameter.Columns.Add("value", GetType(String))
            parameter.Rows.Add("Action", "SetInvoiceNumber")
            parameter.Rows.Add("Format", "JSON")
            parameter.Rows.Add("InvoiceNumber", "INV" + order_number_par)
            parameter.Rows.Add("OrderItemId", item_id)
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
            request.Method = "POST"
            Dim response As Net.HttpWebResponse = request.GetResponse()
            Using dataStream As IO.Stream = response.GetResponseStream()
                Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)
                Dim responseFromServer As String = reader.ReadToEnd()
            End Using
            response.Close()
        Next
    End Sub

    Sub setReadyToShip(ByVal item_id_par As String, ByVal shipment_provider_par As String, ByVal tracking_no_par As String)
        Dim item_id_collect_encode As String = Uri.EscapeDataString("[" + item_id_par + "]")
        Dim shipment_provider As String = Uri.EscapeDataString(shipment_provider_par)
        Dim tracking_no As String = Uri.EscapeDataString(tracking_no_par)
        Dim parameter As DataTable = New DataTable
        parameter.Columns.Add("key", GetType(String))
        parameter.Columns.Add("value", GetType(String))
        parameter.Rows.Add("Action", "SetStatusToReadyToShip")
        parameter.Rows.Add("DeliveryType", "dropship")
        parameter.Rows.Add("Format", "JSON")
        parameter.Rows.Add("OrderItemIds", item_id_collect_encode)
        parameter.Rows.Add("ShippingProvider", shipment_provider)
        parameter.Rows.Add("Timestamp", Uri.EscapeDataString(DateTime.Parse(Now().ToUniversalTime().ToString).ToString("yyyy-MM-ddTHH:mm:ss+00:00")))
        parameter.Rows.Add("TrackingNumber", tracking_no)
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
        request.Method = "POST"
        Dim response As Net.HttpWebResponse = request.GetResponse()
        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
        End Using
        response.Close()
    End Sub

    Function get_status_update(ByVal id_order_par As String, ByVal item_id_par As String) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("order_status", GetType(String))
        dt.Columns.Add("order_status_date", GetType(String))
        Dim data As DataTable = get_order_detail(id_order_par)
        If data.Rows.Count > 0 Then
            Dim data_filter_cek As DataRow() = data.Select("[item_id]='" + item_id_par + "' ")
            If data_filter_cek.Length <= 0 Then
                dt = Nothing
            Else
                dt.Rows.Add(data_filter_cek(0)("status").ToString, data_filter_cek(0)("updated_at").ToString)
            End If
        Else
            dt = Nothing
        End If
        Return dt
    End Function
End Class
