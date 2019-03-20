Imports System.Drawing.Printing

Public Class FormFGCodeReplaceStoreDetPrint
    Dim add_sato_vpx As Integer = Integer.Parse(get_opt_prod_field("sato_add_vpx"))
    Dim add_zebra_vpx As Integer = Integer.Parse(get_opt_prod_field("zebra_add_vpx"))
    Dim add_sato_hpx As Integer = Integer.Parse(get_opt_prod_field("sato_add_hpx"))
    Dim add_zebra_hpx As Integer = Integer.Parse(get_opt_prod_field("zebra_add_hpx"))

    Private Sub FormFGCodeReplaceStoreDetPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEHeightError.EditValue = 0
        load_printer()
    End Sub

    Sub load_printer()
        Dim query As String = "SELECT id_printer_barcode,printer_barcode FROM tb_lookup_printer_barcode"
        viewLookupQuery(LEPrinter, query, 0, "printer_barcode", "id_printer_barcode")
        LEPrinter.ItemIndex = 0
    End Sub

    Private Sub LEPrinter_EditValueChanged(sender As Object, e As EventArgs) Handles LEPrinter.EditValueChanged
        If Not LEPrinter.EditValue.ToString = "" Then
            If LEPrinter.EditValue.ToString = "1" Then
                add_sato_vpx = Integer.Parse(get_opt_prod_field("sato_add_vpx"))
                add_sato_hpx = Integer.Parse(get_opt_prod_field("sato_add_hpx"))
                TEHeightError.EditValue = add_sato_vpx
                TEHorizontalError.EditValue = add_sato_hpx
            ElseIf LEPrinter.EditValue.ToString = "2" Then
                add_zebra_vpx = Integer.Parse(get_opt_prod_field("zebra_add_vpx"))
                add_zebra_hpx = Integer.Parse(get_opt_prod_field("zebra_add_hpx"))
                TEHeightError.EditValue = add_zebra_vpx
                TEHorizontalError.EditValue = add_zebra_hpx
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
            ElseIf LEPrinter.EditValue.ToString = "2" Then
                Dim query As String = "UPDATE tb_opt_prod SET zebra_add_vpx='" & TEHeightError.EditValue.ToString & "'"
                execute_non_query(query, True, "", "", "", "")
                add_zebra_vpx = Integer.Parse(get_opt_prod_field("zebra_add_vpx"))
                infoCustom("Zebra error height settled")
            End If
        End If
    End Sub
    Private Sub FormFGCodeReplaceStoreDetPrint_DragLeave(sender As Object, e As EventArgs) Handles MyBase.DragLeave
        Dispose()
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        print()
    End Sub

    Sub print()
        Dim print_command As String = ""
        If LEPrinter.EditValue.ToString = "1" Then 'sato
            For j As Integer = 0 To FormFGCodeReplaceStoreDet.GVBarcode.RowCount - 1
                'front
                print_command += "<ESC>A"
                print_command += "<ESC>#E5"
                print_command += "<ESC>H" & (add_sato_hpx + 580).ToString & "<ESC>V00" & (add_sato_vpx + 10).ToString & "<ESC>L0200<ESC>S" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "code").ToString & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 610).ToString & "<ESC>V00" & (add_sato_vpx + 30).ToString & "<ESC>D202160" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "code").ToString & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 580).ToString & "<ESC>V0" & (add_sato_vpx + 200).ToString & "<ESC>L0200<ESC>S" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "name").ToString & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 650).ToString & "<ESC>V0" & (add_sato_vpx + 220).ToString & "<ESC>L0200<ESC>XUsize" & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 740).ToString & "<ESC>V0" & (add_sato_vpx + 220).ToString & "<ESC>L0200<ESC>XUcolor" & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 580).ToString & "<ESC>V0" & (add_sato_vpx + 240).ToString & "<ESC>L0202<ESC>S" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "ret_code").ToString & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 650).ToString & "<ESC>V0" & (add_sato_vpx + 240).ToString & "<ESC>L0202<ESC>S" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "size").ToString & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 645).ToString & "<ESC>V0" & (add_sato_vpx + 235).ToString & "<ESC>(65,40" & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 740).ToString & "<ESC>V0" & (add_sato_vpx + 240).ToString & "<ESC>L0202<ESC>S" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "color").ToString & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 580).ToString & "<ESC>V0" & (add_sato_vpx + 280).ToString & "<ESC>L0202<ESC>S" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "currency").ToString & " " & Decimal.Parse(FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "price").ToString).ToString("N0") & vbNewLine
                print_command += "<ESC>Q1" & vbNewLine
                print_command += "<ESC>Z" & vbNewLine
                print_command += "" & vbNewLine

                'back
                print_command += "<ESC>A"
                print_command += "<ESC>#E5"
                print_command += "<ESC>H" & (add_sato_hpx + 580).ToString & "<ESC>V00" & (add_sato_vpx + 10).ToString & "<ESC>L0200<ESC>S" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "code").ToString & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 610).ToString & "<ESC>V00" & (add_sato_vpx + 30).ToString & "<ESC>D202100" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "code").ToString & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 580).ToString & "<ESC>V0" & (add_sato_vpx + 140).ToString & "<ESC>L0200<ESC>S" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "name").ToString & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 650).ToString & "<ESC>V0" & (add_sato_vpx + 160).ToString & "<ESC>L0200<ESC>XUsize" & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 740).ToString & "<ESC>V0" & (add_sato_vpx + 160).ToString & "<ESC>L0200<ESC>XUcolor" & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 580).ToString & "<ESC>V0" & (add_sato_vpx + 180).ToString & "<ESC>L0202<ESC>S" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "ret_code").ToString & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 650).ToString & "<ESC>V0" & (add_sato_vpx + 180).ToString & "<ESC>L0202<ESC>S" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "size").ToString & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 645).ToString & "<ESC>V0" & (add_sato_vpx + 175).ToString & "<ESC>(65,40" & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 740).ToString & "<ESC>V0" & (add_sato_vpx + 180).ToString & "<ESC>L0202<ESC>S" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "color").ToString & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 580).ToString & "<ESC>V0" & (add_sato_vpx + 220).ToString & "<ESC>L0202<ESC>S" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "currency").ToString & " " & Decimal.Parse(FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "price").ToString).ToString("N0") & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 580).ToString & "<ESC>V0" & (add_sato_vpx + 260).ToString & "<ESC>L0101<ESC>S" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "counting").ToString & vbNewLine
                print_command += "<ESC>H" & (add_sato_hpx + 580).ToString & "<ESC>V0" & (add_sato_vpx + 280).ToString & "<ESC>L0202<ESC>BG02070>I" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "unique_code").ToString & vbNewLine
                print_command += "<ESC>Q1" & vbNewLine
                print_command += "<ESC>Z" & vbNewLine
                print_command += "" & vbNewLine
            Next
            print_command = print_command.ToString().Replace("<ESC>", (ChrW(27)).ToString())
        ElseIf LEPrinter.EditValue.ToString = "2" Then 'zebra
            For j As Integer = 0 To FormFGCodeReplaceStoreDet.GVBarcode.RowCount - 1
                'front
                print_command += "CT~~CD,~CC^~CT~" & vbNewLine
                print_command += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4~SD30^JUS^LRN^CI0^XZ" & vbNewLine
                print_command += "^XA" & vbNewLine
                print_command += "^CI28" & vbNewLine
                print_command += "^MMT" & vbNewLine
                print_command += "^PW800" & vbNewLine
                print_command += "^LL0406" & vbNewLine
                print_command += "^LS0" & vbNewLine
                print_command += "^FT" & (add_zebra_hpx + 159).ToString & "," & (add_zebra_vpx + 285).ToString & "^A0N,34,33^FH\^FD" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "color").ToString & "^FS" & vbNewLine
                print_command += "^FO" & (add_zebra_hpx + 86).ToString & "," & (add_zebra_vpx + 252).ToString & "^GB54,42,42^FS" & vbNewLine
                print_command += "^FT" & (add_zebra_hpx + 86).ToString & "," & (add_zebra_vpx + 285).ToString & "^A0N,34,33^FR^FH\^FD" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "size").ToString & "^FS" & vbNewLine
                print_command += "^FT" & (add_zebra_hpx + 3).ToString & "," & (add_zebra_vpx + 333).ToString & "^A0N,39,38^FH\^FD" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "currency").ToString & " " & Decimal.Parse(FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "price").ToString).ToString("N0") & "^FS" & vbNewLine
                print_command += "^FT" & (add_zebra_hpx + 3).ToString & "," & (add_zebra_vpx + 285).ToString & "^A0N,34,33^FH\^FD" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "ret_code").ToString & "^FS" & vbNewLine
                print_command += "^FT" & (add_zebra_hpx + 1).ToString & "," & (add_zebra_vpx + 215).ToString & "^A0N,17,16^FH\^FD" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "name").ToString & "^FS" & vbNewLine
                print_command += "^FT" & (add_zebra_hpx + 2).ToString & "," & (add_zebra_vpx + 25).ToString & "^A0N,24,40^FH\^FD" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "code").ToString & "^FS" & vbNewLine
                print_command += "^BY2,2,162^FT" & (add_zebra_hpx + 23).ToString & "," & (add_zebra_vpx + 194).ToString & "^B2N,,N,N" & vbNewLine
                print_command += "^FD" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "code").ToString & "^FS" & vbNewLine
                print_command += "^FT" & (add_zebra_hpx + 159).ToString & "," & (add_zebra_vpx + 247).ToString & "^A0N,14,14^FH\^FDcolor^FS" & vbNewLine
                print_command += "^FT" & (add_zebra_hpx + 87).ToString & "," & (add_zebra_vpx + 247).ToString & "^A0N,14,14^FH\^FDsize^FS" & vbNewLine
                print_command += "^PQ1,0,1,Y^XZ" & vbNewLine

                'back
                print_command += "CT~~CD,~CC^~CT~" & vbNewLine
                print_command += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4~SD27^JUS^LRN^CI0^XZ" & vbNewLine
                print_command += "^XA" & vbNewLine
                print_command += "^CI28" & vbNewLine
                print_command += "^MMT" & vbNewLine
                print_command += "^PW800" & vbNewLine
                print_command += "^LL0406" & vbNewLine
                print_command += "^LS0" & vbNewLine
                print_command += "^FT" & (add_zebra_hpx + 159).ToString & "," & (add_zebra_vpx + 225).ToString & "^A0N,34,33^FH\^FD" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "color").ToString & "  ^FS" & vbNewLine
                print_command += "^FO" & (add_zebra_hpx + 86).ToString & "," & (add_zebra_vpx + 192).ToString & "^GB54,42,42^FS" & vbNewLine
                print_command += "^FT" & (add_zebra_hpx + 86).ToString & "," & (add_zebra_vpx + 225).ToString & "^A0N,34,33^FR^FH\^FD" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "size").ToString & "^FS" & vbNewLine
                print_command += "^FT" & (add_zebra_hpx + 3).ToString & "," & (add_zebra_vpx + 268).ToString & "^A0N,34,33^FH\^FD" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "currency").ToString & " " & Decimal.Parse(FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "price").ToString).ToString("N0") & "^FS" & vbNewLine
                print_command += "^FT" & (add_zebra_hpx + 3).ToString & "," & (add_zebra_vpx + 225).ToString & "^A0N,34,33^FH\^FD" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "ret_code").ToString & "^FS" & vbNewLine
                print_command += "^FT" & (add_zebra_hpx + 2).ToString & "," & (add_zebra_vpx + 161).ToString & "^A0N,17,16^FH\^FD" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "name").ToString & "^FS" & vbNewLine
                print_command += "^FT" & (add_zebra_hpx + 3).ToString & "," & (add_zebra_vpx + 307).ToString & "^A0N,17,16^FH\^FD" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "counting").ToString & " ^FS" & vbNewLine
                print_command += "^FT" & (add_zebra_hpx + 3).ToString & "," & (add_zebra_vpx + 28).ToString & "^A0N,24,40^FH\^FD" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "code").ToString & "^FS" & vbNewLine
                print_command += "^BY2,2,111^FT" & (add_zebra_hpx + 23).ToString & "," & (add_zebra_vpx + 143).ToString & "^B2N,,N,N" & vbNewLine
                print_command += "^FD" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "code").ToString & "^FS" & vbNewLine
                print_command += "^FT" & (add_zebra_hpx + 159).ToString & "," & (add_zebra_vpx + 187).ToString & "^A0N,14,14^FH\^FDcolor^FS" & vbNewLine
                print_command += "^FT" & (add_zebra_hpx + 87).ToString & "," & (add_zebra_vpx + 187).ToString & "^A0N,14,14^FH\^FDsize^FS" & vbNewLine
                print_command += "^BY2,3,43^FT" & (add_zebra_hpx + 3).ToString & "," & (add_zebra_vpx + 354).ToString & "^BCN,,N,N" & vbNewLine
                print_command += "^FD>;" & FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "unique_code").ToString & "^FS" & vbNewLine
                print_command += "^PQ1,0,1,Y^XZ" & vbNewLine
            Next
            print_command = print_command.ToString()
        End If

        Dim pd As New PrintDialog()

        pd.PrinterSettings = New PrinterSettings()
        If (pd.ShowDialog() = DialogResult.OK) Then
            Try
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, print_command)
                'Console.WriteLine(print_command)
                For j As Integer = 0 To FormFGCodeReplaceStoreDet.GVBarcode.RowCount - 1
                    log_print(FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "id_product").ToString, FormFGCodeReplaceStoreDet.GVBarcode.GetRowCellValue(j, "counting").ToString, "3") '3 for front and back
                Next
                Dim id_fg_code_replace_store As String = FormFGCodeReplaceStoreDet.id_fg_code_replace_store
                Dim qup As String = "UPDATE tb_fg_code_replace_store SET is_printed=1, printed_date=NOW(), printed_by=" + id_user + " WHERE id_fg_code_replace_store='" + id_fg_code_replace_store + "' "
                execute_non_query(qup, True, "", "", "", "")
                FormFGCodeReplace.CENotPrintedYet.EditValue = False
                FormFGCodeReplace.viewCodeReplaceStore()
                FormFGCodeReplace.GVFGCodeReplaceStore.FocusedRowHandle = find_row(FormFGCodeReplace.GVFGCodeReplaceStore, "id_fg_code_replace_store", id_fg_code_replace_store)
            Catch ex As Exception
                stopCustom(ex.ToString)
            End Try
        End If
    End Sub
    Sub log_print(ByVal id_product As String, ByVal counting As String, ByVal opt As String)
        Dim query_ins As String = "INSERT INTO tb_m_product_log_print(id_product,type,unique_from,unique_to,qty,datetime,id_printer,id_user) VALUES('" & id_product & "','" & opt & "','" & counting & "','" & counting & "','1',NOW(),'" & LEPrinter.EditValue.ToString & "','" & id_user & "')"
        execute_non_query(query_ins, True, "", "", "", "")
    End Sub

    Private Sub BSetHorizontalError_Click(sender As Object, e As EventArgs) Handles BSetHorizontalError.Click
        If Not LEPrinter.EditValue.ToString = "" Then
            If LEPrinter.EditValue.ToString = "1" Then
                Dim query As String = "UPDATE tb_opt_prod SET sato_add_hpx='" & TEHorizontalError.EditValue.ToString & "'"
                execute_non_query(query, True, "", "", "", "")
                add_sato_hpx = Integer.Parse(get_opt_prod_field("sato_add_hpx"))
                infoCustom("SATO error horizontal settled")
            ElseIf LEPrinter.EditValue.ToString = "2" Then
                Dim query As String = "UPDATE tb_opt_prod SET zebra_add_hpx='" & TEHorizontalError.EditValue.ToString & "'"
                execute_non_query(query, True, "", "", "", "")
                add_zebra_hpx = Integer.Parse(get_opt_prod_field("zebra_add_hpx"))
                infoCustom("Zebra error horizontal settled")
            End If
        End If
    End Sub
End Class