Public Class ReportWHDelEmpty
    Public Shared id As String
    Public Shared dt As DataTable
    Public Shared id_pre As String = "-1"

    Private Sub ReportWHDelEmpty_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCProbSum.DataSource = dt
        If id_pre = "-1" Then
            load_mark_horz("111", id, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("111", id, "2", "2", XrTable1)
        End If
    End Sub

    Private Sub GVProbSum_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVProbSum.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class