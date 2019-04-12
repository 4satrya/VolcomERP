Public Class ReportProdBOM
    Public Shared dt As DataTable

    Public Shared id_prod_order As String = "-1"
    'Public Shared sign_col As String = "-1"
    'Public Shared id_cur As String = "-1"
    Public Shared is_pre As String = "-1"

    Private Sub ReportMatPurchase_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCBOM.DataSource = dt
        If is_pre = "1" Then
            pre_load_mark_horz("22", id_prod_order, "2", "2", XrTable1)
        Else
            load_mark_horz("22", id_prod_order, "2", "1", XrTable1)
        End If
        'printed date 
        Dim qpd As String = "SELECT DATE_FORMAT(NOW(), '%d/%M/%Y %H:%i') AS `printed_date` "
        Dim dpd As DataTable = execute_query(qpd, -1, True, "", "", "", "")
        DataSource = dpd
    End Sub
End Class