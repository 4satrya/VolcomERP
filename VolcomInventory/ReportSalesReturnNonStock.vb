Public Class ReportSalesReturnNonStock
    Public Shared dt As DataTable

    Private Sub ReportSalesReturnNonStock_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCBarcodeProb.DataSource = dt
    End Sub

    Private Sub GVBarcodeProb_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcodeProb.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class