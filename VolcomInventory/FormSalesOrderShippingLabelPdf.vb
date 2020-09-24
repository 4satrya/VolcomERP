Public Class FormSalesOrderShippingLabelPdf
    Public ol_store As String = ""
    Public order_id As String = ""

    Private is_not_found As Boolean = False

    Private Sub FormSalesOrderShippingLabelPdf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim path As String = Application.StartupPath & "\download\"

        If Not IO.Directory.Exists(path) Then
            IO.Directory.CreateDirectory(path)
        End If

        Dim full_path As String = ""

        If ol_store = "blibli" Then
            full_path = path + "BLIBLI-" + order_id + "-" + Now.Ticks.ToString + ".pdf"
        ElseIf ol_store = "zalora" Then
            full_path = path + "ZALORA-" + order_id + "-" + Now.Ticks.ToString + ".html"
        End If

        Dim bytes() As Byte = Nothing

        If ol_store = "blibli" Then
            Dim cls As ClassBliBliApi = New ClassBliBliApi

            Dim out As String = cls.download_shipping_label(order_id)

            If Not out = "" Then
                bytes = Convert.FromBase64String(out)
            End If
        ElseIf ol_store = "zalora" Then
            Dim cls As ClassZaloraApi = New ClassZaloraApi

            Dim out As String = ""

            Dim utf8 As Text.UTF8Encoding = New Text.UTF8Encoding

            out += utf8.GetString(Convert.FromBase64String(cls.download_shipping_label(order_id, "exportInvoice")))
            out += utf8.GetString(Convert.FromBase64String(cls.download_shipping_label(order_id, "invoice")))
            out += utf8.GetString(Convert.FromBase64String(cls.download_shipping_label(order_id, "shippingLabel")))

            If Not out = "" Then
                bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(out)
            End If
        End If

        If bytes IsNot Nothing Then
            Dim stream As IO.FileStream = New IO.FileStream(full_path, IO.FileMode.CreateNew)
            Dim writer As IO.BinaryWriter = New IO.BinaryWriter(stream)

            writer.Write(bytes, 0, bytes.Length)

            writer.Close()

            If ol_store = "zalora" Then

            End If

            WebBrowser.Url = New Uri(full_path)
        Else
            is_not_found = True
        End If
    End Sub

    Private Sub FormSalesOrderShippingLabelPdf_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSalesOrderShippingLabelPdf_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If is_not_found Then
            stopCustom("Not found.")

            Close()
        End If
    End Sub
End Class