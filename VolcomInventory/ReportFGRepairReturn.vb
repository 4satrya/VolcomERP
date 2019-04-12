Public Class ReportFGRepairReturn
    Public Shared id_pre As String = "-1"
    Public Shared id_fg_repair_return As String = "-1"
    Public Shared id_type As String = "-1"
    Public Shared dt As DataTable
    Public Shared rmt As String = ""

    Private Sub ReportFGRepairReturn_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCScanSum.DataSource = dt
        If id_type = "-1" Then
            'Mark
            If id_pre = "-1" Then
                load_mark_horz(rmt, id_fg_repair_return, "2", "1", XrTable1)
            Else
                pre_load_mark_horz(rmt, id_fg_repair_return, "2", "2", XrTable1)
            End If
        ElseIf id_type = "1" Then
            'Mark
            If id_pre = "-1" Then
                load_mark_horz(rmt, id_fg_repair_return, "2", "1", XrTable1)
            Else
                pre_load_mark_horz(rmt, id_fg_repair_return, "2", "2", XrTable1)
            End If

        End If
    End Sub

    Private Sub GVScanSum_CustomColumnDisplayText_1(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVScanSum.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub


End Class