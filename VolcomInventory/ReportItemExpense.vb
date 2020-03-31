Public Class ReportItemExpense
    Public Shared id As String = "-1"
    Public Shared dt As DataTable
    Public Shared is_pre As Boolean = False

    Private Sub ReportItemExpense_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCData.DataSource = dt
        If is_pre Then
            pre_load_mark_horz("157", id, "2", "2", XrTable1)
        Else
            load_mark_horz("157", id, "2", "2", XrTable1)
        End If
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class