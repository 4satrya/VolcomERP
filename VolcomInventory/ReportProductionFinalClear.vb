Public Class ReportProductionFinalClear
    Public Shared id_prod_fc As String = "-1"
    Public Shared id_comp_from As String = "-1"
    Public Shared id_comp_to As String = "-1"
    Public Shared dt As DataTable

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub ReportProductionFinalClear_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCItemList.DataSource = dt
        load_mark_horz("105", id_prod_fc, "2", "1", XrTable1)
    End Sub
End Class