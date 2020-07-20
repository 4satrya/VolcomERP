Public Class ReportPurcReq
    Public Shared id_req As String
    Public id_pre As String
    Public Shared dt As DataTable
    Public Shared rmt As String = "-1"

    Private Sub ReportPurcReq_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCItemList.DataSource = dt
        GVItemList.BestFitColumns()

        If id_pre = "-1" Then
            load_mark_horz(rmt, id_req, "2", "1", XrTable1)
        Else
            pre_load_mark_horz(rmt, id_req, "2", "2", XrTable1)
        End If
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class