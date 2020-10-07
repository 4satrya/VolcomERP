Public Class FormSalesOrderShippingLabelPdf
    Public ol_store As String = ""
    Public order_id As String = ""

    Private is_not_found As Boolean = False

    Private Sub FormSalesOrderShippingLabelPdf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim path As String = Application.StartupPath & "\download\"

        If Not IO.Directory.Exists(path) Then
            IO.Directory.CreateDirectory(path)
        End If

        Dim full_path_invoice As String = ""
        Dim full_path_shippinglabel As String = ""

        If ol_store = "blibli" Then
            full_path_shippinglabel = path + "BLIBLI-" + order_id + "-" + Now.Ticks.ToString + ".pdf"
        ElseIf ol_store = "zalora" Then
            full_path_invoice = path + "ZALORA-INV-" + order_id + "-" + Now.Ticks.ToString + ".html"
            full_path_shippinglabel = path + "ZALORA-SHI-" + order_id + "-" + Now.Ticks.ToString + ".html"
        End If

        Dim bytes_invoice() As Byte = Nothing
        Dim bytes_shippinglabel() As Byte = Nothing

        If ol_store = "blibli" Then
            Dim cls As ClassBliBliApi = New ClassBliBliApi

            Dim out_shippinglabel As String = cls.download_shipping_label(order_id)

            If Not out_shippinglabel = "" Then
                bytes_shippinglabel = Convert.FromBase64String(out_shippinglabel)
            End If
        ElseIf ol_store = "zalora" Then
            Dim cls As ClassZaloraApi = New ClassZaloraApi

            Dim out_invoice As String = cls.download_shipping_label(order_id, "invoice")
            Dim out_shippinglabel As String = cls.download_shipping_label(order_id, "shippingLabel")

            If Not out_invoice = "" Then
                bytes_invoice = Convert.FromBase64String(out_invoice)
            End If

            If Not out_shippinglabel = "" Then
                bytes_shippinglabel = Convert.FromBase64String(out_shippinglabel)
            End If

            'replace https
            bytes_invoice = System.Text.Encoding.UTF8.GetBytes(System.Text.Encoding.UTF8.GetString(bytes_invoice).Replace("https", "http"))
            bytes_shippinglabel = System.Text.Encoding.UTF8.GetBytes(System.Text.Encoding.UTF8.GetString(bytes_shippinglabel).Replace("https", "http"))
        End If

        If ol_store = "blibli" Then
            If bytes_shippinglabel IsNot Nothing Then
                Dim stream As IO.FileStream = New IO.FileStream(full_path_shippinglabel, IO.FileMode.CreateNew)
                Dim writer As IO.BinaryWriter = New IO.BinaryWriter(stream)

                writer.Write(bytes_shippinglabel, 0, bytes_shippinglabel.Length)

                writer.Close()

                Dim browser As WebBrowser = New WebBrowser

                browser.Dock = DockStyle.Fill

                browser.Url = New Uri(full_path_shippinglabel)

                Controls.Add(browser)
            Else
                is_not_found = True
            End If
        ElseIf ol_store = "zalora" Then
            If bytes_invoice IsNot Nothing And bytes_shippinglabel IsNot Nothing Then
                'invoice
                Dim stream_invoice As IO.FileStream = New IO.FileStream(full_path_invoice, IO.FileMode.CreateNew)
                Dim writer_invoice As IO.BinaryWriter = New IO.BinaryWriter(stream_invoice)

                writer_invoice.Write(bytes_invoice, 0, bytes_invoice.Length)

                writer_invoice.Close()

                'shipping label
                Dim stream_shippinglabel As IO.FileStream = New IO.FileStream(full_path_shippinglabel, IO.FileMode.CreateNew)
                Dim writer_shippinglabel As IO.BinaryWriter = New IO.BinaryWriter(stream_shippinglabel)

                writer_shippinglabel.Write(bytes_shippinglabel, 0, bytes_shippinglabel.Length)

                writer_shippinglabel.Close()

                'tab
                Dim tab As DevExpress.XtraTab.XtraTabControl = New DevExpress.XtraTab.XtraTabControl

                tab.Dock = DockStyle.Fill

                tab.TabPages.Add("Invoice")
                tab.TabPages.Add("Shipping Label")

                'pdf
                Dim pdf_invoice As Pechkin.GlobalConfig = New Pechkin.GlobalConfig

                pdf_invoice.SetPaperOrientation(True)
                pdf_invoice.SetPaperSize(Printing.PaperKind.A4)

                Dim obj_invoice As Pechkin.ObjectConfig = New Pechkin.ObjectConfig

                obj_invoice.SetPageUri(full_path_invoice)
                obj_invoice.SetPrintBackground(True)
                obj_invoice.SetScreenMediaType(True)
                obj_invoice.SetLoadImages(True)

                Dim converter_invoice As Pechkin.Synchronized.SynchronizedPechkin = New Pechkin.Synchronized.SynchronizedPechkin(pdf_invoice)

                Dim result_invoice() As Byte = converter_invoice.Convert(obj_invoice)

                IO.File.WriteAllBytes(full_path_invoice.Replace(".html", ".pdf"), result_invoice)

                Dim pdf_shippinglabel As TuesPechkin.HtmlToPdfDocument = New TuesPechkin.HtmlToPdfDocument

                pdf_shippinglabel.GlobalSettings.PaperSize = Printing.PaperKind.A4Rotated

                Dim obj_shippinglabel As TuesPechkin.ObjectSettings = New TuesPechkin.ObjectSettings

                obj_shippinglabel.PageUrl = full_path_shippinglabel
                obj_shippinglabel.WebSettings.PrintBackground = True
                obj_shippinglabel.WebSettings.PrintMediaType = True
                obj_shippinglabel.WebSettings.LoadImages = True

                pdf_shippinglabel.Objects.Add(obj_shippinglabel)

                Dim converter_shippinglabel As TuesPechkin.IConverter = New TuesPechkin.StandardConverter(New TuesPechkin.PdfToolset(New TuesPechkin.Win32EmbeddedDeployment(New TuesPechkin.TempFolderDeployment())))

                Dim result_shippinglabel() As Byte = converter_shippinglabel.Convert(pdf_shippinglabel)

                IO.File.WriteAllBytes(full_path_shippinglabel.Replace(".html", ".pdf"), result_shippinglabel)

                'browser
                Dim browser_invoice As WebBrowser = New WebBrowser

                browser_invoice.Dock = DockStyle.Fill

                browser_invoice.Url = New Uri(full_path_invoice.Replace(".html", ".pdf"))

                Dim browser_shippinglabel As WebBrowser = New WebBrowser

                browser_shippinglabel.Dock = DockStyle.Fill

                browser_shippinglabel.Url = New Uri(full_path_shippinglabel.Replace(".html", ".pdf"))

                tab.TabPages.Item(0).Controls.Add(browser_invoice)
                tab.TabPages.Item(1).Controls.Add(browser_shippinglabel)

                Controls.Add(tab)
            Else
                is_not_found = True
            End If
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