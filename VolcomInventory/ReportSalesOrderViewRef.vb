Public Class ReportSalesOrderViewRef
    Public Shared dt As DataTable

    Private Sub ReportSalesOrderViewRef_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'fill
        GCNewPrepare.DataSource = dt
        GVNewPrepare.BestFitColumns()

        'printed date & approved date
        Dim qpd As String = "SELECT DATE_FORMAT(NOW(), '%d/%m/%Y %H:%i') AS `printed_date`, '" + name_user + "' AS `print_user` "
        Dim dpd As DataTable = execute_query(qpd, -1, True, "", "", "", "")
        DataSource = dpd


    End Sub
End Class