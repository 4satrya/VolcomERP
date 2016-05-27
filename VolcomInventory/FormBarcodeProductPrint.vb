Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.IO

Public Class FormBarcodeProductPrint
    Public id_product As String = "-1"
    Dim format_string As String = ""

    Private Sub FormBarcodeProductPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not id_product = "-1" Then
            Dim id_design As String = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("id_design").ToString

            TELastUnique.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            TELastUnique.Properties.DisplayFormat.FormatString = "{0:d4}"
            TELastUnique.EditValue = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("last_unique")


            TEDesignCode.EditValue = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("design_code").ToString
            TEDesignName.EditValue = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("design_display_name").ToString
            TEProdCode.EditValue = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("product_full_code").ToString

            TECurPrice.EditValue = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("currency").ToString

            TESize.EditValue = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("Size").ToString
            TEColor.EditValue = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("Color_display").ToString
            TERetCode.EditValue = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("ret_code").ToString

            pre_viewImages("2", PEView, id_design, False)

            For i As Integer = 0 To FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("digit_code") - 1
                format_string += "0"
            Next

            If get_setup_field("print_barcode_old").ToString = "1" Then
                format_string = "0000"
                SEPrintFrom.Properties.DisplayFormat.FormatString = "0000"
                SEPrintFrom.Properties.EditMask = "0000"
                SEPrintFrom.Properties.MaxValue = "9999"
                SEPrintFrom.Properties.MinValue = "1"

                SEPrintTo.Properties.DisplayFormat.FormatString = "0000"
                SEPrintTo.Properties.EditMask = "0000"
                SEPrintTo.Properties.MaxValue = "9999"
                SEPrintTo.Properties.MinValue = "1"
                SEPrintTo.EditValue = "1"

                TECurPrice.Text = "Rp"
                TEPrice.Properties.ReadOnly = False
            ElseIf get_setup_field("print_barcode_old").ToString = "2" Then
                format_string = "0000"
                SEPrintFrom.Properties.DisplayFormat.FormatString = "0000"
                SEPrintFrom.Properties.EditMask = "0000"
                SEPrintFrom.Properties.MaxValue = "9999"
                SEPrintFrom.Properties.MinValue = "1"

                SEPrintTo.Properties.DisplayFormat.FormatString = "0000"
                SEPrintTo.Properties.EditMask = "0000"
                SEPrintTo.Properties.MaxValue = "9999"
                SEPrintTo.Properties.MinValue = "1"
                SEPrintTo.EditValue = "1"

                TEPrice.EditValue = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("design_price")
                TEPrice.Properties.ReadOnly = True
            Else
                TEPrice.EditValue = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("design_price")

                SEPrintFrom.Properties.DisplayFormat.FormatString = format_string
                SEPrintFrom.Properties.EditMask = format_string
                SEPrintFrom.Properties.MaxValue = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("range_akhir").ToString
                SEPrintFrom.Properties.MinValue = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("range_awal").ToString

                SEPrintTo.Properties.DisplayFormat.FormatString = format_string
                SEPrintTo.Properties.EditMask = format_string
                SEPrintTo.Properties.MaxValue = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("range_akhir").ToString
                SEPrintTo.Properties.MinValue = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("range_awal").ToString
                SEPrintTo.EditValue = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("range_akhir").ToString

                TEPrice.Properties.ReadOnly = True
            End If

            TEProdBarcode.EditValue = TEProdCode.EditValue

            load_unique()
            load_printer()
        End If
    End Sub

    Sub load_printer()
        Dim query As String = "SELECT id_printer_barcode,printer_barcode FROM tb_lookup_printer_barcode"
        viewLookupQuery(LEPrinter, query, 0, "printer_barcode", "id_printer_barcode")
        LEPrinter.ItemIndex = 0
    End Sub

    Private Sub SEPrintFrom_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEPrintFrom.EditValueChanged
        load_unique()
    End Sub

    Private Sub SEPrintTo_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEPrintTo.EditValueChanged
        load_unique()
    End Sub

    Sub load_unique()
        TEPrintFrom.EditValue = TEProdCode.EditValue.ToString & "" & SEPrintFrom.Text
        TEPrintTo.EditValue = TEProdCode.EditValue.ToString & "" & SEPrintTo.Text
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        If SEPrintTo.EditValue < SEPrintFrom.EditValue Then
            stopCustom("Please make sure barcode unique on the left is before unique on the right.")
        Else
            Dim print_command As String = ""
            If LEPrinter.EditValue.ToString = "1" Then 'sato
                For j As Integer = 1 To SEQtyPrint.EditValue
                    For i As Integer = SEPrintFrom.EditValue To SEPrintTo.EditValue
                        '
                        print_command += "<ESC>A"
                        print_command += "<ESC>#E5"
                        print_command += "<ESC>H580<ESC>V0010<ESC>L0200<ESC>S" & TEProdCode.Text & vbNewLine
                        print_command += "<ESC>H580<ESC>V0030<ESC>D202160" & TEProdCode.Text & vbNewLine
                        print_command += "<ESC>H580<ESC>V0200<ESC>L0200<ESC>S" & TEDesignName.Text & vbNewLine
                        print_command += "<ESC>H650<ESC>V0220<ESC>L0200<ESC>XUsize" & vbNewLine
                        print_command += "<ESC>H740<ESC>V0220<ESC>L0200<ESC>XUcolor" & vbNewLine
                        print_command += "<ESC>H580<ESC>V0240<ESC>L0202<ESC>S" & TERetCode.Text & vbNewLine
                        print_command += "<ESC>H650<ESC>V0240<ESC>L0202<ESC>S" & TESize.Text & vbNewLine
                        print_command += "<ESC>H645<ESC>V0235<ESC>(65,40" & vbNewLine
                        print_command += "<ESC>H740<ESC>V0240<ESC>L0202<ESC>S" & TEColor.Text & vbNewLine
                        print_command += "<ESC>H580<ESC>V0280<ESC>L0202<ESC>S" & TECurPrice.Text & " " & TEPrice.Text & vbNewLine
                        print_command += "<ESC>Q1" & vbNewLine
                        print_command += "<ESC>Z" & vbNewLine
                        print_command += "" & vbNewLine

                        'baru
                        print_command += "<ESC>A"
                        print_command += "<ESC>#E5"
                        print_command += "<ESC>H580<ESC>V0010<ESC>L0200<ESC>S" & TEProdCode.Text & vbNewLine
                        print_command += "<ESC>H580<ESC>V0030<ESC>D202100" & TEProdCode.Text & vbNewLine
                        print_command += "<ESC>H580<ESC>V0140<ESC>L0200<ESC>S" & TEDesignName.Text & vbNewLine
                        print_command += "<ESC>H650<ESC>V0160<ESC>L0200<ESC>XUsize" & vbNewLine
                        print_command += "<ESC>H740<ESC>V0160<ESC>L0200<ESC>XUcolor" & vbNewLine
                        print_command += "<ESC>H580<ESC>V0180<ESC>L0202<ESC>S" & TERetCode.Text & vbNewLine
                        print_command += "<ESC>H650<ESC>V0180<ESC>L0202<ESC>S" & TESize.Text & vbNewLine
                        print_command += "<ESC>H645<ESC>V0175<ESC>(65,40" & vbNewLine
                        print_command += "<ESC>H740<ESC>V0180<ESC>L0202<ESC>S" & TEColor.Text & vbNewLine
                        print_command += "<ESC>H580<ESC>V0220<ESC>L0202<ESC>S" & TECurPrice.Text & " " & TEPrice.Text & vbNewLine
                        print_command += "<ESC>H580<ESC>V0260<ESC>L0101<ESC>S" & i.ToString(format_string) & vbNewLine
                        print_command += "<ESC>H580<ESC>V0280<ESC>L0202<ESC>BG02070>I" & TEProdCode.Text & i.ToString(format_string) & vbNewLine
                        print_command += "<ESC>Q1" & vbNewLine
                        print_command += "<ESC>Z" & vbNewLine
                        print_command += "" & vbNewLine
                    Next
                Next
                'print_command = print_command.ToString().Replace("<ESC>", (ChrW(27)).ToString())
            ElseIf LEPrinter.EditValue.ToString = "2" 'zebra
                For j As Integer = 1 To SEQtyPrint.EditValue
                    For i As Integer = SEPrintFrom.EditValue To SEPrintTo.EditValue
                        'front new
                        print_command += "CT~~CD,~CC^~CT~" & vbNewLine
                        print_command += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4~SD30^JUS^LRN^CI0^XZ" & vbNewLine
                        print_command += "^XA" & vbNewLine
                        print_command += "^MMT" & vbNewLine
                        print_command += "^PW277" & vbNewLine
                        print_command += "^LL0406" & vbNewLine
                        print_command += "^LS0" & vbNewLine
                        print_command += "^FT159,307^A0N,34,33^FH\^FD" & TEColor.Text & "^FS" & vbNewLine
                        print_command += "^FO86,274^GB54,42,42^FS" & vbNewLine
                        print_command += "^FT86,307^A0N,34,33^FR^FH\^FD" & TESize.Text & "^FS" & vbNewLine
                        print_command += "^FT3,355^A0N,39,38^FH\^FD" & TECurPrice.Text & " " & TEPrice.Text & "^FS" & vbNewLine
                        print_command += "^FT3,307^A0N,34,33^FH\^FD" & TERetCode.Text & "^FS" & vbNewLine
                        print_command += "^FT1,237^A0N,17,16^FH\^FD" & TEDesignName.Text & "^FS" & vbNewLine
                        print_command += "^FT2,47^A0N,17,16^FH\^FD" & TEProdCode.Text & "^FS" & vbNewLine
                        print_command += "^BY2,2,162^FT3,216^B2N,,N,N" & vbNewLine
                        print_command += "^FD" & TEProdCode.Text & "^FS" & vbNewLine
                        print_command += "^FT159,269^A0N,14,14^FH\^FDcolor^FS" & vbNewLine
                        print_command += "^FT87,268^A0N,14,14^FH\^FDsize^FS" & vbNewLine
                        print_command += "^PQ1,0,1,Y^XZ" & vbNewLine

                        'back
                        print_command += "CT~~CD,~CC^~CT~" & vbNewLine
                        print_command += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4~SD27^JUS^LRN^CI0^XZ" & vbNewLine
                        print_command += "^XA" & vbNewLine
                        print_command += "^MMT" & vbNewLine
                        print_command += "^PW277" & vbNewLine
                        print_command += "^LL0406" & vbNewLine
                        print_command += "^LS0" & vbNewLine
                        print_command += "^FT159,247^A0N,34,33^FH\^FD" & TEColor.Text & "  ^FS" & vbNewLine
                        print_command += "^FO86,214^GB54,42,42^FS" & vbNewLine
                        print_command += "^FT86,247^A0N,34,33^FR^FH\^FD" & TESize.Text & "^FS" & vbNewLine
                        print_command += "^FT3,291^A0N,34,33^FH\^FD" & TECurPrice.Text & " " & TEPrice.Text & "^FS" & vbNewLine
                        print_command += "^FT3,247^A0N,34,33^FH\^FD" & TERetCode.Text & "^FS" & vbNewLine
                        print_command += "^FT2,183^A0N,17,16^FH\^FD" & TEDesignName.Text & "^FS" & vbNewLine
                        print_command += "^FT3,329^A0N,17,16^FH\^FD" & i.ToString(format_string) & " ^FS" & vbNewLine
                        print_command += "^FT3,50^A0N,17,16^FH\^FD" & TEProdCode.Text & "^FS" & vbNewLine
                        print_command += "^BY2,2,111^FT3,165^B2N,,N,N" & vbNewLine
                        print_command += "^FD" & TEProdCode.Text & "^FS" & vbNewLine
                        print_command += "^FT159,209^A0N,14,14^FH\^FDcolor^FS" & vbNewLine
                        print_command += "^FT87,208^A0N,14,14^FH\^FDsize^FS" & vbNewLine
                        print_command += "^BY2,3,43^FT3,376^BCN,,N,N" & vbNewLine
                        print_command += "^FD>;" & TEProdCode.Text & i.ToString(format_string) & "^FS" & vbNewLine
                        print_command += "^PQ1,0,1,Y^XZ" & vbNewLine

                    Next
                Next

                print_command = print_command.ToString()
            End If

            Dim pd As New PrintDialog()

            pd.PrinterSettings = New PrinterSettings()
            If (pd.ShowDialog() = DialogResult.OK) Then
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, print_command)
                'update last unique
                Dim query_upd As String = ""
                query_upd = String.Format("UPDATE tb_m_product SET last_print_unique='{1}' WHERE id_product='{0}'", id_product, SEPrintTo.EditValue.ToString)
                execute_non_query(query_upd, True, "", "", "", "")
                '
                TELastUnique.EditValue = SEPrintTo.Text
                '
                FormBarcodeProduct.viewProd()
                FormBarcodeProduct.GVProdList.FocusedRowHandle = find_row(FormBarcodeProduct.GVProdList, "id_product", id_product)
            End If
        End If
    End Sub


    Private Sub FormBarcodeProductPrint_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnPrintBack_Click(sender As Object, e As EventArgs) Handles BtnPrintBack.Click
        If SEPrintTo.EditValue < SEPrintFrom.EditValue Then
            stopCustom("Please make sure barcode unique on the left is before unique on the right.")
        Else
            Dim print_command As String = ""
            If LEPrinter.EditValue.ToString = "1" Then 'sato
                For i As Integer = SEPrintFrom.EditValue To SEPrintTo.EditValue
                    'baru
                    print_command += "<ESC>A"
                    print_command += "<ESC>#E5"
                    print_command += "<ESC>H580<ESC>V0010<ESC>L0200<ESC>S" & TEProdCode.Text & vbNewLine
                    print_command += "<ESC>H580<ESC>V0030<ESC>D202100" & TEProdCode.Text & vbNewLine
                    print_command += "<ESC>H580<ESC>V0140<ESC>L0200<ESC>S" & TEDesignName.Text & vbNewLine
                    print_command += "<ESC>H650<ESC>V0160<ESC>L0200<ESC>XUsize" & vbNewLine
                    print_command += "<ESC>H740<ESC>V0160<ESC>L0200<ESC>XUcolor" & vbNewLine
                    print_command += "<ESC>H580<ESC>V0180<ESC>L0202<ESC>S" & TERetCode.Text & vbNewLine
                    print_command += "<ESC>H650<ESC>V0180<ESC>L0202<ESC>S" & TESize.Text & vbNewLine
                    print_command += "<ESC>H645<ESC>V0175<ESC>(65,40" & vbNewLine
                    print_command += "<ESC>H740<ESC>V0180<ESC>L0202<ESC>S" & TEColor.Text & vbNewLine
                    print_command += "<ESC>H580<ESC>V0220<ESC>L0202<ESC>S" & TECurPrice.Text & " " & TEPrice.Text & vbNewLine
                    print_command += "<ESC>H580<ESC>V0260<ESC>L0101<ESC>S" & i.ToString(format_string) & vbNewLine
                    print_command += "<ESC>H580<ESC>V0280<ESC>L0202<ESC>BG02070>I" & TEProdCode.Text & i.ToString(format_string) & vbNewLine
                    print_command += "<ESC>Q1" & vbNewLine
                    print_command += "<ESC>Z" & vbNewLine
                    print_command += "" & vbNewLine
                    '
                    print_command = print_command.ToString().Replace("<ESC>", (ChrW(27)).ToString())
                Next
            ElseIf LEPrinter.EditValue.ToString = "2" 'zebra
                For i As Integer = SEPrintFrom.EditValue To SEPrintTo.EditValue
                    'back
                    print_command += "CT~~CD,~CC^~CT~" & vbNewLine
                    print_command += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4~SD27^JUS^LRN^CI0^XZ" & vbNewLine
                    print_command += "^XA" & vbNewLine
                    print_command += "^MMT" & vbNewLine
                    print_command += "^PW277" & vbNewLine
                    print_command += "^LL0406" & vbNewLine
                    print_command += "^LS0" & vbNewLine
                    print_command += "^FT159,247^A0N,34,33^FH\^FD" & TEColor.Text & "  ^FS" & vbNewLine
                    print_command += "^FO86,214^GB54,42,42^FS" & vbNewLine
                    print_command += "^FT86,247^A0N,34,33^FR^FH\^FD" & TESize.Text & "^FS" & vbNewLine
                    print_command += "^FT3,291^A0N,34,33^FH\^FD" & TECurPrice.Text & " " & TEPrice.Text & "^FS" & vbNewLine
                    print_command += "^FT3,247^A0N,34,33^FH\^FD" & TERetCode.Text & "^FS" & vbNewLine
                    print_command += "^FT2,183^A0N,17,16^FH\^FD" & TEDesignName.Text & "^FS" & vbNewLine
                    print_command += "^FT3,329^A0N,17,16^FH\^FD" & i.ToString(format_string) & " ^FS" & vbNewLine
                    print_command += "^FT3,50^A0N,17,16^FH\^FD" & TEProdCode.Text & "^FS" & vbNewLine
                    print_command += "^BY2,2,111^FT3,165^B2N,,N,N" & vbNewLine
                    print_command += "^FD" & TEProdCode.Text & "^FS" & vbNewLine
                    print_command += "^FT159,209^A0N,14,14^FH\^FDcolor^FS" & vbNewLine
                    print_command += "^FT87,208^A0N,14,14^FH\^FDsize^FS" & vbNewLine
                    print_command += "^BY2,3,43^FT3,376^BCN,,N,N" & vbNewLine
                    print_command += "^FD>;" & TEProdCode.Text & i.ToString(format_string) & "^FS" & vbNewLine
                    print_command += "^PQ1,0,1,Y^XZ" & vbNewLine
                Next
            End If

            Dim pd As New PrintDialog()

            pd.PrinterSettings = New PrinterSettings()
            If (pd.ShowDialog() = DialogResult.OK) Then
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, print_command)
            End If
        End If
    End Sub

    Private Sub BtnPrintFront_Click(sender As Object, e As EventArgs) Handles BtnPrintFront.Click
        Dim print_command As String = ""
        'Console.WriteLine(i.ToString(format_string))
        If LEPrinter.EditValue.ToString = "1" Then
            print_command += "<ESC>A"
            print_command += "<ESC>#E5"
            print_command += "<ESC>H615<ESC>V0010<ESC>L0200<ESC>S" & TEProdCode.Text & vbNewLine
            print_command += "<ESC>H615<ESC>V0030<ESC>D202160" & TEProdCode.Text & vbNewLine
            print_command += "<ESC>H615<ESC>V0200<ESC>L0200<ESC>S" & TEDesignName.Text & vbNewLine
            print_command += "<ESC>H685<ESC>V0220<ESC>L0200<ESC>XUsize" & vbNewLine
            print_command += "<ESC>H775<ESC>V0220<ESC>L0200<ESC>XUcolor" & vbNewLine
            print_command += "<ESC>H615<ESC>V0240<ESC>L0202<ESC>S" & TERetCode.Text & vbNewLine
            print_command += "<ESC>H685<ESC>V0240<ESC>L0202<ESC>S" & TESize.Text & vbNewLine
            print_command += "<ESC>H680<ESC>V0235<ESC>(65,40" & vbNewLine
            print_command += "<ESC>H775<ESC>V0240<ESC>L0202<ESC>S" & TEColor.Text & vbNewLine
            print_command += "<ESC>H615<ESC>V0280<ESC>L0202<ESC>S" & TECurPrice.Text & " " & TEPrice.Text & vbNewLine
            print_command += "<ESC>Q" + SEQtyPrint.EditValue.ToString + "" & vbNewLine
            print_command += "<ESC>Z" & vbNewLine
            print_command += "" & vbNewLine

            print_command = print_command.ToString().Replace("<ESC>", (ChrW(27)).ToString())
        ElseIf LEPrinter.EditValue.ToString = "2" Then
            'front new
            print_command += "CT~~CD,~CC^~CT~" & vbNewLine
            print_command += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4~SD30^JUS^LRN^CI0^XZ" & vbNewLine
            print_command += "^XA" & vbNewLine
            print_command += "^MMT" & vbNewLine
            print_command += "^PW277" & vbNewLine
            print_command += "^LL0406" & vbNewLine
            print_command += "^LS0" & vbNewLine
            print_command += "^FT159,307^A0N,34,33^FH\^FD" & TEColor.Text & "^FS" & vbNewLine
            print_command += "^FO86,274^GB54,42,42^FS" & vbNewLine
            print_command += "^FT86,307^A0N,34,33^FR^FH\^FD" & TESize.Text & "^FS" & vbNewLine
            print_command += "^FT3,355^A0N,39,38^FH\^FD" & TECurPrice.Text & " " & TEPrice.Text & "^FS" & vbNewLine
            print_command += "^FT3,307^A0N,34,33^FH\^FD" & TERetCode.Text & "^FS" & vbNewLine
            print_command += "^FT1,237^A0N,17,16^FH\^FD" & TEDesignName.Text & "^FS" & vbNewLine
            print_command += "^FT2,47^A0N,17,16^FH\^FD" & TEProdCode.Text & "^FS" & vbNewLine
            print_command += "^BY2,2,162^FT3,216^B2N,,N,N" & vbNewLine
            print_command += "^FD" & TEProdCode.Text & "^FS" & vbNewLine
            print_command += "^FT159,269^A0N,14,14^FH\^FDcolor^FS" & vbNewLine
            print_command += "^FT87,268^A0N,14,14^FH\^FDsize^FS" & vbNewLine
            print_command += "^PQ" + SEQtyPrint.EditValue.ToString + ",0,1,Y^XZ" & vbNewLine
        End If

        Dim pd As New PrintDialog()

        pd.PrinterSettings = New PrinterSettings()
        If (pd.ShowDialog() = DialogResult.OK) Then
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, print_command)
        End If
    End Sub
    Private Sub TEPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles TEPrice.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub SEPrintFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles SEPrintFrom.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub SEPrintTo_KeyDown(sender As Object, e As KeyEventArgs) Handles SEPrintTo.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub SEQtyPrint_KeyDown(sender As Object, e As KeyEventArgs) Handles SEQtyPrint.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub LEPrinter_KeyDown(sender As Object, e As KeyEventArgs) Handles LEPrinter.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub
End Class