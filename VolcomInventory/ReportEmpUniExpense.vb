Public Class ReportEmpUniExpense
    Public Shared id_emp_uni_ex As String = "-1"
    Public Shared dt As DataTable

    Private Sub ReportEmpUniExpense_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCData.DataSource = dt
        load_mark_horz("132", id_emp_uni_ex, "2", "1", XrTable1)
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class