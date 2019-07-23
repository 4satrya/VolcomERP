Public Class ReportProductionHOAttachment
    Public Shared id As String = "-1"

    Private Sub ReportProductionHOAttachment_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = "CALL view_pl_prod_report_det_ver2('AND (" + id + ") ')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
    End Sub
End Class