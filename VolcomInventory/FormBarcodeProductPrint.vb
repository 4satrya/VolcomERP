Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.IO

Public Class FormBarcodeProductPrint
    Public id_product As String = "-1"
    Dim format_string As String = ""
    Dim last_print_unique As String = "1"

    Dim add_sato_vpx As Integer = Integer.Parse(get_opt_prod_field("sato_add_vpx"))
    Dim add_zebra_vpx As Integer = Integer.Parse(get_opt_prod_field("zebra_add_vpx"))

    Private Sub FormBarcodeProductPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TEHeightError.EditValue = 0

        If Not id_product = "-1" Then
            Dim id_design As String = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("id_design").ToString

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
        load_last_unique()
    End Sub

    Sub load_last_unique()
        Dim query As String = "SELECT last_print_unique FROM tb_m_product WHERE id_product='" + id_product + "'"
        last_print_unique = execute_query(query, 0, True, "", "", "", "")
        SEPrintFrom.EditValue = Integer.Parse(last_print_unique.ToString) + 1
        SEPrintTo.EditValue = Integer.Parse(last_print_unique.ToString) + 1
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
        ElseIf TEPrice.Text.ToString = "" Or TEPrice.Text.ToString = "0"
            stopCustom("Please make sure barcode price is not empty.")
        Else
            Dim print_command As String = ""
            If LEPrinter.EditValue.ToString = "1" Then 'sato
                For j As Integer = 1 To SEQtyPrint.EditValue
                    For i As Integer = SEPrintFrom.EditValue To SEPrintTo.EditValue
                        ''
                        'print_command += "<ESC>A"
                        'print_command += "<ESC>#E5"
                        'print_command += "<ESC>H580<ESC>V0010<ESC>L0200<ESC>S" & TEProdCode.Text & vbNewLine
                        'print_command += "<ESC>H580<ESC>V0030<ESC>D202160" & TEProdCode.Text & vbNewLine
                        'print_command += "<ESC>H580<ESC>V0200<ESC>L0200<ESC>S" & TEDesignName.Text & vbNewLine
                        'print_command += "<ESC>H650<ESC>V0220<ESC>L0200<ESC>XUsize" & vbNewLine
                        'print_command += "<ESC>H740<ESC>V0220<ESC>L0200<ESC>XUcolor" & vbNewLine
                        'print_command += "<ESC>H580<ESC>V0240<ESC>L0202<ESC>S" & TERetCode.Text & vbNewLine
                        'print_command += "<ESC>H650<ESC>V0240<ESC>L0202<ESC>S" & TESize.Text & vbNewLine
                        'print_command += "<ESC>H645<ESC>V0235<ESC>(65,40" & vbNewLine
                        'print_command += "<ESC>H740<ESC>V0240<ESC>L0202<ESC>S" & TEColor.Text & vbNewLine
                        'print_command += "<ESC>H580<ESC>V0280<ESC>L0202<ESC>S" & TECurPrice.Text & " " & TEPrice.Text & vbNewLine
                        'print_command += "<ESC>Q1" & vbNewLine
                        'print_command += "<ESC>Z" & vbNewLine
                        'print_command += "" & vbNewLine

                        ''baru
                        'print_command += "<ESC>A"
                        'print_command += "<ESC>#E5"
                        'print_command += "<ESC>H580<ESC>V0010<ESC>L0200<ESC>S" & TEProdCode.Text & vbNewLine
                        'print_command += "<ESC>H580<ESC>V0030<ESC>D202100" & TEProdCode.Text & vbNewLine
                        'print_command += "<ESC>H580<ESC>V0140<ESC>L0200<ESC>S" & TEDesignName.Text & vbNewLine
                        'print_command += "<ESC>H650<ESC>V0160<ESC>L0200<ESC>XUsize" & vbNewLine
                        'print_command += "<ESC>H740<ESC>V0160<ESC>L0200<ESC>XUcolor" & vbNewLine
                        'print_command += "<ESC>H580<ESC>V0180<ESC>L0202<ESC>S" & TERetCode.Text & vbNewLine
                        'print_command += "<ESC>H650<ESC>V0180<ESC>L0202<ESC>S" & TESize.Text & vbNewLine
                        'print_command += "<ESC>H645<ESC>V0175<ESC>(65,40" & vbNewLine
                        'print_command += "<ESC>H740<ESC>V0180<ESC>L0202<ESC>S" & TEColor.Text & vbNewLine
                        'print_command += "<ESC>H580<ESC>V0220<ESC>L0202<ESC>S" & TECurPrice.Text & " " & TEPrice.Text & vbNewLine
                        'print_command += "<ESC>H580<ESC>V0260<ESC>L0101<ESC>S" & i.ToString(format_string) & vbNewLine
                        'print_command += "<ESC>H580<ESC>V0280<ESC>L0202<ESC>BG02070>I" & TEProdCode.Text & i.ToString(format_string) & vbNewLine
                        'print_command += "<ESC>Q1" & vbNewLine
                        'print_command += "<ESC>Z" & vbNewLine
                        'print_command += "" & vbNewLine
                        '
                        print_command += "<ESC>A"
                        print_command += "<ESC>#E5"
                        print_command += "<ESC>H580<ESC>V00" & (add_sato_vpx + 10).ToString & "<ESC>L0200<ESC>S" & TEProdCode.Text & vbNewLine
                        print_command += "<ESC>H580<ESC>V00" & (add_sato_vpx + 30).ToString & "<ESC>D202160" & TEProdCode.Text & vbNewLine
                        print_command += "<ESC>H580<ESC>V0" & (add_sato_vpx + 200).ToString & "<ESC>L0200<ESC>S" & TEDesignName.Text & vbNewLine
                        print_command += "<ESC>H650<ESC>V0" & (add_sato_vpx + 220).ToString & "<ESC>L0200<ESC>XUsize" & vbNewLine
                        print_command += "<ESC>H740<ESC>V0" & (add_sato_vpx + 220).ToString & "<ESC>L0200<ESC>XUcolor" & vbNewLine
                        print_command += "<ESC>H580<ESC>V0" & (add_sato_vpx + 240).ToString & "<ESC>L0202<ESC>S" & TERetCode.Text & vbNewLine
                        print_command += "<ESC>H650<ESC>V0" & (add_sato_vpx + 240).ToString & "<ESC>L0202<ESC>S" & TESize.Text & vbNewLine
                        print_command += "<ESC>H645<ESC>V0" & (add_sato_vpx + 235).ToString & "<ESC>(65,40" & vbNewLine
                        print_command += "<ESC>H740<ESC>V0" & (add_sato_vpx + 240).ToString & "<ESC>L0202<ESC>S" & TEColor.Text & vbNewLine
                        print_command += "<ESC>H580<ESC>V0" & (add_sato_vpx + 280).ToString & "<ESC>L0202<ESC>S" & TECurPrice.Text & " " & TEPrice.Text & vbNewLine
                        print_command += "<ESC>Q1" & vbNewLine
                        print_command += "<ESC>Z" & vbNewLine
                        print_command += "" & vbNewLine

                        'baru
                        print_command += "<ESC>A"
                        print_command += "<ESC>#E5"
                        print_command += "<ESC>H580<ESC>V00" & (add_sato_vpx + 10).ToString & "<ESC>L0200<ESC>S" & TEProdCode.Text & vbNewLine
                        print_command += "<ESC>H580<ESC>V00" & (add_sato_vpx + 30).ToString & "<ESC>D202100" & TEProdCode.Text & vbNewLine
                        print_command += "<ESC>H580<ESC>V0" & (add_sato_vpx + 140).ToString & "<ESC>L0200<ESC>S" & TEDesignName.Text & vbNewLine
                        print_command += "<ESC>H650<ESC>V0" & (add_sato_vpx + 160).ToString & "<ESC>L0200<ESC>XUsize" & vbNewLine
                        print_command += "<ESC>H740<ESC>V0" & (add_sato_vpx + 160).ToString & "<ESC>L0200<ESC>XUcolor" & vbNewLine
                        print_command += "<ESC>H580<ESC>V0" & (add_sato_vpx + 180).ToString & "<ESC>L0202<ESC>S" & TERetCode.Text & vbNewLine
                        print_command += "<ESC>H650<ESC>V0" & (add_sato_vpx + 180).ToString & "<ESC>L0202<ESC>S" & TESize.Text & vbNewLine
                        print_command += "<ESC>H645<ESC>V0" & (add_sato_vpx + 175).ToString & "<ESC>(65,40" & vbNewLine
                        print_command += "<ESC>H740<ESC>V0" & (add_sato_vpx + 180).ToString & "<ESC>L0202<ESC>S" & TEColor.Text & vbNewLine
                        print_command += "<ESC>H580<ESC>V0" & (add_sato_vpx + 220).ToString & "<ESC>L0202<ESC>S" & TECurPrice.Text & " " & TEPrice.Text & vbNewLine
                        print_command += "<ESC>H580<ESC>V0" & (add_sato_vpx + 260).ToString & "<ESC>L0101<ESC>S" & i.ToString(format_string) & vbNewLine
                        print_command += "<ESC>H580<ESC>V0" & (add_sato_vpx + 280).ToString & "<ESC>L0202<ESC>BG02070>I" & TEProdCode.Text & i.ToString(format_string) & vbNewLine
                        print_command += "<ESC>Q1" & vbNewLine
                        print_command += "<ESC>Z" & vbNewLine
                        print_command += "" & vbNewLine
                        'Console.WriteLine(print_command)
                    Next
                Next
                print_command = print_command.ToString().Replace("<ESC>", (ChrW(27)).ToString())
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
                        print_command += "^FT159," & (add_zebra_vpx + 285).ToString & "^A0N,34,33^FH\^FD" & TEColor.Text & "^FS" & vbNewLine
                        print_command += "^FO86," & (add_zebra_vpx + 252).ToString & "^GB54,42,42^FS" & vbNewLine
                        print_command += "^FT86," & (add_zebra_vpx + 285).ToString & "^A0N,34,33^FR^FH\^FD" & TESize.Text & "^FS" & vbNewLine
                        print_command += "^FT3," & (add_zebra_vpx + 333).ToString & "^A0N,39,38^FH\^FD" & TECurPrice.Text & " " & TEPrice.Text & "^FS" & vbNewLine
                        print_command += "^FT3," & (add_zebra_vpx + 285).ToString & "^A0N,34,33^FH\^FD" & TERetCode.Text & "^FS" & vbNewLine
                        print_command += "^FT1," & (add_zebra_vpx + 215).ToString & "^A0N,17,16^FH\^FD" & TEDesignName.Text & "^FS" & vbNewLine
                        print_command += "^FT2," & (add_zebra_vpx + 25).ToString & "^A0N,17,16^FH\^FD" & TEProdCode.Text & "^FS" & vbNewLine
                        print_command += "^BY2,2,162^FT3," & (add_zebra_vpx + 194).ToString & "^B2N,,N,N" & vbNewLine
                        print_command += "^FD" & TEProdCode.Text & "^FS" & vbNewLine
                        print_command += "^FT159," & (add_zebra_vpx + 247).ToString & "^A0N,14,14^FH\^FDcolor^FS" & vbNewLine
                        print_command += "^FT87," & (add_zebra_vpx + 247).ToString & "^A0N,14,14^FH\^FDsize^FS" & vbNewLine
                        print_command += "^PQ1,0,1,Y^XZ" & vbNewLine

                        'back
                        print_command += "CT~~CD,~CC^~CT~" & vbNewLine
                        print_command += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4~SD27^JUS^LRN^CI0^XZ" & vbNewLine
                        print_command += "^XA" & vbNewLine
                        print_command += "^MMT" & vbNewLine
                        print_command += "^PW277" & vbNewLine
                        print_command += "^LL0406" & vbNewLine
                        print_command += "^LS0" & vbNewLine
                        print_command += "^FT159," & (add_zebra_vpx + 225).ToString & "^A0N,34,33^FH\^FD" & TEColor.Text & "  ^FS" & vbNewLine
                        print_command += "^FO86," & (add_zebra_vpx + 192).ToString & "^GB54,42,42^FS" & vbNewLine
                        print_command += "^FT86," & (add_zebra_vpx + 225).ToString & "^A0N,34,33^FR^FH\^FD" & TESize.Text & "^FS" & vbNewLine
                        print_command += "^FT3," & (add_zebra_vpx + 268).ToString & "^A0N,34,33^FH\^FD" & TECurPrice.Text & " " & TEPrice.Text & "^FS" & vbNewLine
                        print_command += "^FT3," & (add_zebra_vpx + 225).ToString & "^A0N,34,33^FH\^FD" & TERetCode.Text & "^FS" & vbNewLine
                        print_command += "^FT2," & (add_zebra_vpx + 161).ToString & "^A0N,17,16^FH\^FD" & TEDesignName.Text & "^FS" & vbNewLine
                        print_command += "^FT3," & (add_zebra_vpx + 307).ToString & "^A0N,17,16^FH\^FD" & i.ToString(format_string) & " ^FS" & vbNewLine
                        print_command += "^FT3," & (add_zebra_vpx + 28).ToString & "^A0N,17,16^FH\^FD" & TEProdCode.Text & "^FS" & vbNewLine
                        print_command += "^BY2,2,111^FT3," & (add_zebra_vpx + 143).ToString & "^B2N,,N,N" & vbNewLine
                        print_command += "^FD" & TEProdCode.Text & "^FS" & vbNewLine
                        print_command += "^FT159," & (add_zebra_vpx + 187).ToString & "^A0N,14,14^FH\^FDcolor^FS" & vbNewLine
                        print_command += "^FT87," & (add_zebra_vpx + 187).ToString & "^A0N,14,14^FH\^FDsize^FS" & vbNewLine
                        print_command += "^BY2,3,43^FT3," & (add_zebra_vpx + 354).ToString & "^BCN,,N,N" & vbNewLine
                        print_command += "^FD>;" & TEProdCode.Text & i.ToString(format_string) & "^FS" & vbNewLine
                        print_command += "^PQ1,0,1,Y^XZ" & vbNewLine
                    Next
                Next
                print_command = print_command.ToString()
            End If
            '
            Dim pd As New PrintDialog()

            pd.PrinterSettings = New PrinterSettings()
            If (pd.ShowDialog() = DialogResult.OK) Then
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, print_command)
                upd_last_digit("3")
            End If
        End If
    End Sub

    Sub upd_last_digit(ByVal opt As String)
        If Not opt = "1" Then
            If Integer.Parse(SEPrintTo.EditValue) > Integer.Parse(last_print_unique) Then
                Dim query_ins As String = "UPDATE tb_m_product SET last_print_unique='" & SEPrintTo.EditValue.ToString & "' WHERE id_product='" & id_product & "'"
                execute_non_query(query_ins, True, "", "", "", "")
                last_print_unique = SEPrintTo.EditValue
            End If
        End If
        log_print(opt)
        load_last_unique()
    End Sub
    Sub log_print(ByVal opt As String)
        Dim query_ins As String = "INSERT INTO tb_m_product_log_print(id_product,type,unique_from,unique_to,qty,datetime,id_printer,id_user) VALUES('" & id_product & "','" & opt & "','" & SEPrintFrom.EditValue.ToString & "','" & SEPrintTo.EditValue.ToString & "','" & SEQtyPrint.EditValue.ToString & "',NOW(),'" & LEPrinter.EditValue.ToString & "','" & id_user & "')"
        execute_non_query(query_ins, True, "", "", "", "")
    End Sub
    Private Sub FormBarcodeProductPrint_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnPrintBack_Click(sender As Object, e As EventArgs) Handles BtnPrintBack.Click
        If SEPrintTo.EditValue < SEPrintFrom.EditValue Then
            stopCustom("Please make sure barcode unique on the left is before unique on the right.")
        ElseIf TEPrice.Text.ToString = "" Or TEPrice.Text.ToString = "0"
            stopCustom("Please make sure barcode price is not empty.")
        Else
            Dim print_command As String = ""
            If LEPrinter.EditValue.ToString = "1" Then 'sato
                For i As Integer = SEPrintFrom.EditValue To SEPrintTo.EditValue
                    'baru
                    'print_command += "<ESC>A"
                    'print_command += "<ESC>#E5"
                    'print_command += "<ESC>H580<ESC>V0010<ESC>L0200<ESC>S" & TEProdCode.Text & vbNewLine
                    'print_command += "<ESC>H580<ESC>V0030<ESC>D202100" & TEProdCode.Text & vbNewLine
                    'print_command += "<ESC>H580<ESC>V0140<ESC>L0200<ESC>S" & TEDesignName.Text & vbNewLine
                    'print_command += "<ESC>H650<ESC>V0160<ESC>L0200<ESC>XUsize" & vbNewLine
                    'print_command += "<ESC>H740<ESC>V0160<ESC>L0200<ESC>XUcolor" & vbNewLine
                    'print_command += "<ESC>H580<ESC>V0180<ESC>L0202<ESC>S" & TERetCode.Text & vbNewLine
                    'print_command += "<ESC>H650<ESC>V0180<ESC>L0202<ESC>S" & TESize.Text & vbNewLine
                    'print_command += "<ESC>H645<ESC>V0175<ESC>(65,40" & vbNewLine
                    'print_command += "<ESC>H740<ESC>V0180<ESC>L0202<ESC>S" & TEColor.Text & vbNewLine
                    'print_command += "<ESC>H580<ESC>V0220<ESC>L0202<ESC>S" & TECurPrice.Text & " " & TEPrice.Text & vbNewLine
                    'print_command += "<ESC>H580<ESC>V0260<ESC>L0101<ESC>S" & i.ToString(format_string) & vbNewLine
                    'print_command += "<ESC>H580<ESC>V0280<ESC>L0202<ESC>BG02070>I" & TEProdCode.Text & i.ToString(format_string) & vbNewLine
                    'print_command += "<ESC>Q1" & vbNewLine
                    'print_command += "<ESC>Z" & vbNewLine
                    'print_command += "" & vbNewLine
                    'baru
                    print_command += "<ESC>A"
                    print_command += "<ESC>#E5"
                    print_command += "<ESC>H580<ESC>V00" & (add_sato_vpx + 10).ToString & "<ESC>L0200<ESC>S" & TEProdCode.Text & vbNewLine
                    print_command += "<ESC>H580<ESC>V00" & (add_sato_vpx + 30).ToString & "<ESC>D202100" & TEProdCode.Text & vbNewLine
                    print_command += "<ESC>H580<ESC>V0" & (add_sato_vpx + 140).ToString & "<ESC>L0200<ESC>S" & TEDesignName.Text & vbNewLine
                    print_command += "<ESC>H650<ESC>V0" & (add_sato_vpx + 160).ToString & "<ESC>L0200<ESC>XUsize" & vbNewLine
                    print_command += "<ESC>H740<ESC>V0" & (add_sato_vpx + 160).ToString & "<ESC>L0200<ESC>XUcolor" & vbNewLine
                    print_command += "<ESC>H580<ESC>V0" & (add_sato_vpx + 180).ToString & "<ESC>L0202<ESC>S" & TERetCode.Text & vbNewLine
                    print_command += "<ESC>H650<ESC>V0" & (add_sato_vpx + 180).ToString & "<ESC>L0202<ESC>S" & TESize.Text & vbNewLine
                    print_command += "<ESC>H645<ESC>V0" & (add_sato_vpx + 175).ToString & "<ESC>(65,40" & vbNewLine
                    print_command += "<ESC>H740<ESC>V0" & (add_sato_vpx + 180).ToString & "<ESC>L0202<ESC>S" & TEColor.Text & vbNewLine
                    print_command += "<ESC>H580<ESC>V0" & (add_sato_vpx + 220).ToString & "<ESC>L0202<ESC>S" & TECurPrice.Text & " " & TEPrice.Text & vbNewLine
                    print_command += "<ESC>H580<ESC>V0" & (add_sato_vpx + 260).ToString & "<ESC>L0101<ESC>S" & i.ToString(format_string) & vbNewLine
                    print_command += "<ESC>H580<ESC>V0" & (add_sato_vpx + 280).ToString & "<ESC>L0202<ESC>BG02070>I" & TEProdCode.Text & i.ToString(format_string) & vbNewLine
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
            '

            '
            Dim pd As New PrintDialog()

            pd.PrinterSettings = New PrinterSettings()
            If (pd.ShowDialog() = DialogResult.OK) Then
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, print_command)
                upd_last_digit("2")
            End If
        End If
    End Sub

    Private Sub BtnPrintFront_Click(sender As Object, e As EventArgs) Handles BtnPrintFront.Click
        Dim print_command As String = ""
        If TEPrice.Text.ToString = "" Then
            stopCustom("Please make sure barcode price is not empty.")
        Else
            If LEPrinter.EditValue.ToString = "1" Then
                'print_command += "<ESC>A"
                'print_command += "<ESC>#E5"
                'print_command += "<ESC>H615<ESC>V0010<ESC>L0200<ESC>S" & TEProdCode.Text & vbNewLine
                'print_command += "<ESC>H615<ESC>V0030<ESC>D202160" & TEProdCode.Text & vbNewLine
                'print_command += "<ESC>H615<ESC>V0200<ESC>L0200<ESC>S" & TEDesignName.Text & vbNewLine
                'print_command += "<ESC>H685<ESC>V0220<ESC>L0200<ESC>XUsize" & vbNewLine
                'print_command += "<ESC>H775<ESC>V0220<ESC>L0200<ESC>XUcolor" & vbNewLine
                'print_command += "<ESC>H615<ESC>V0240<ESC>L0202<ESC>S" & TERetCode.Text & vbNewLine
                'print_command += "<ESC>H685<ESC>V0240<ESC>L0202<ESC>S" & TESize.Text & vbNewLine
                'print_command += "<ESC>H680<ESC>V0235<ESC>(65,40" & vbNewLine
                'print_command += "<ESC>H775<ESC>V0240<ESC>L0202<ESC>S" & TEColor.Text & vbNewLine
                'print_command += "<ESC>H615<ESC>V0280<ESC>L0202<ESC>S" & TECurPrice.Text & " " & TEPrice.Text & vbNewLine
                'print_command += "<ESC>Q" + SEQtyPrint.EditValue.ToString + "" & vbNewLine
                'print_command += "<ESC>Z" & vbNewLine
                'print_command += "" & vbNewLine

                print_command += "<ESC>A"
                print_command += "<ESC>#E5"
                print_command += "<ESC>H580<ESC>V00" & (add_sato_vpx + 10).ToString & "<ESC>L0200<ESC>S" & TEProdCode.Text & vbNewLine
                print_command += "<ESC>H580<ESC>V00" & (add_sato_vpx + 30).ToString & "<ESC>D202160" & TEProdCode.Text & vbNewLine
                print_command += "<ESC>H580<ESC>V0" & (add_sato_vpx + 200).ToString & "<ESC>L0200<ESC>S" & TEDesignName.Text & vbNewLine
                print_command += "<ESC>H650<ESC>V0" & (add_sato_vpx + 220).ToString & "<ESC>L0200<ESC>XUsize" & vbNewLine
                print_command += "<ESC>H740<ESC>V0" & (add_sato_vpx + 220).ToString & "<ESC>L0200<ESC>XUcolor" & vbNewLine
                print_command += "<ESC>H580<ESC>V0" & (add_sato_vpx + 240).ToString & "<ESC>L0202<ESC>S" & TERetCode.Text & vbNewLine
                print_command += "<ESC>H650<ESC>V0" & (add_sato_vpx + 240).ToString & "<ESC>L0202<ESC>S" & TESize.Text & vbNewLine
                print_command += "<ESC>H645<ESC>V0" & (add_sato_vpx + 235).ToString & "<ESC>(65,40" & vbNewLine
                print_command += "<ESC>H740<ESC>V0" & (add_sato_vpx + 240).ToString & "<ESC>L0202<ESC>S" & TEColor.Text & vbNewLine
                print_command += "<ESC>H580<ESC>V0" & (add_sato_vpx + 280).ToString & "<ESC>L0202<ESC>S" & TECurPrice.Text & " " & TEPrice.Text & vbNewLine
                print_command += "<ESC>Q1" & vbNewLine
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
                print_command += "^FT159," & (add_zebra_vpx + 285).ToString & "^A0N,34,33^FH\^FD" & TEColor.Text & "^FS" & vbNewLine
                print_command += "^FO86," & (add_zebra_vpx + 252).ToString & "^GB54,42,42^FS" & vbNewLine
                print_command += "^FT86," & (add_zebra_vpx + 285).ToString & "^A0N,34,33^FR^FH\^FD" & TESize.Text & "^FS" & vbNewLine
                print_command += "^FT3," & (add_zebra_vpx + 333).ToString & "^A0N,39,38^FH\^FD" & TECurPrice.Text & " " & TEPrice.Text & "^FS" & vbNewLine
                print_command += "^FT3," & (add_zebra_vpx + 285).ToString & "^A0N,34,33^FH\^FD" & TERetCode.Text & "^FS" & vbNewLine
                print_command += "^FT1," & (add_zebra_vpx + 215).ToString & "^A0N,17,16^FH\^FD" & TEDesignName.Text & "^FS" & vbNewLine
                print_command += "^FT2," & (add_zebra_vpx + 25).ToString & "^A0N,17,16^FH\^FD" & TEProdCode.Text & "^FS" & vbNewLine
                print_command += "^BY2,2,162^FT3," & (add_zebra_vpx + 194).ToString & "^B2N,,N,N" & vbNewLine
                print_command += "^FD" & TEProdCode.Text & "^FS" & vbNewLine
                print_command += "^FT159," & (add_zebra_vpx + 247).ToString & "^A0N,14,14^FH\^FDcolor^FS" & vbNewLine
                print_command += "^FT87," & (add_zebra_vpx + 247).ToString & "^A0N,14,14^FH\^FDsize^FS" & vbNewLine
                print_command += "^PQ1,0,1,Y^XZ" & vbNewLine
            End If

            Dim pd As New PrintDialog()

            pd.PrinterSettings = New PrinterSettings()
            If (pd.ShowDialog() = DialogResult.OK) Then
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, print_command)
                upd_last_digit("1")
            End If
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

    Private Sub BLogUnique_Click(sender As Object, e As EventArgs) Handles BLogUnique.Click
        FormBarcodeProductPrintLog.id_product = id_product
        FormBarcodeProductPrintLog.ShowDialog()
    End Sub

    Private Sub LEPrinter_EditValueChanged(sender As Object, e As EventArgs) Handles LEPrinter.EditValueChanged
        If Not LEPrinter.EditValue.ToString = "" Then
            If LEPrinter.EditValue.ToString = "1" Then
                add_sato_vpx = Integer.Parse(get_opt_prod_field("sato_add_vpx"))
                TEHeightError.EditValue = add_sato_vpx
            ElseIf LEPrinter.EditValue.ToString = "2"
                add_zebra_vpx = Integer.Parse(get_opt_prod_field("zebra_add_vpx"))
                TEHeightError.EditValue = add_zebra_vpx
            End If
        End If
    End Sub

    Private Sub BSetHeightError_Click(sender As Object, e As EventArgs) Handles BSetHeightError.Click
        If Not LEPrinter.EditValue.ToString = "" Then
            If LEPrinter.EditValue.ToString = "1" Then
                Dim query As String = "UPDATE tb_opt_prod SET sato_add_vpx='" & TEHeightError.EditValue.ToString & "'"
                execute_non_query(query, True, "", "", "", "")
                add_sato_vpx = Integer.Parse(get_opt_prod_field("sato_add_vpx"))
                infoCustom("SATO error height settled")
            ElseIf LEPrinter.EditValue.ToString = "2"
                Dim query As String = "UPDATE tb_opt_prod SET zebra_add_vpx='" & TEHeightError.EditValue.ToString & "'"
                execute_non_query(query, True, "", "", "", "")
                add_zebra_vpx = Integer.Parse(get_opt_prod_field("zebra_add_vpx"))
                infoCustom("Zebra error height settled")
            End If
        End If
    End Sub
End Class