Public Class ReportProductionClaimReturn
    Public Shared id As String = "-1"
    Public Shared dt As DataTable

    Private Sub ReportProductionClaimReturn_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCDetail.DataSource = dt
        load_mark_horz("151", id, "2", "1", XrTable1)
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class