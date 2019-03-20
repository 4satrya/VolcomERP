Public Class ReportMasterProductDelivery
    Public Shared id_del As String = "-1"
    Public Shared store As String = ""
    Public Shared period As String = ""
    Dim now As String = ""

    Private Sub ReportMasterProductDelivery_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'general
        XrLabel8.Text += " (" + execute_query("SELECT DATE_FORMAT(NOW(), '%d/%m/%Y %H:%i')", 0, True, "", "", "", "") + ")"
        LabelStore.Text = store
        LabelPeriod.Text = period

        'call proc
        Dim delc As New ClassSalesDelOrder()
        Dim data As DataTable = delc.getMasterDelivery(id_del)
        GCData.DataSource = data
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class