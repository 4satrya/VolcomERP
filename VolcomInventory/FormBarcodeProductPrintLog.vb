Public Class FormBarcodeProductPrintLog
    Public id_product As String = "-1"
    Private Sub FormBarcodeProductPrintLog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormBarcodeProductPrintLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT logp.id_log_print,IF(logp.type='1','Front Only',IF(logp.type='2','Back Only','Front and Back')) AS `type`,logp.unique_from,logp.unique_to,logp.qty,logp.`datetime`,usr.username,printer.printer_barcode"
        query += " FROM tb_m_product_log_print logp"
        query += " INNER JOIN tb_m_user usr ON usr.id_user=logp.id_user"
        query += " INNER JOIN tb_lookup_printer_barcode printer ON printer.id_printer_barcode=logp.id_printer"
        query += " WHERE logp.id_product='" + id_product + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCLog.DataSource = data
        GVLog.BestFitColumns()
    End Sub
End Class