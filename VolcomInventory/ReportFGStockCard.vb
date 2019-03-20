Public Class ReportFGStockCard
    Public Shared id_design As String = "-1"
    Public Shared code_design As String = ""
    Public Shared desc_design As String = ""
    Public Shared id_wh As String = "-1"
    Public Shared code_wh As String = ""
    Public Shared wh As String = ""
    Public Shared componentLink As New DevExpress.XtraPrinting.PrintableComponentLink(New DevExpress.XtraPrinting.PrintingSystem())
    Public Shared GC As DevExpress.XtraGrid.GridControl
    Public Shared GV As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Public Shared dt As DataTable
    Public Shared str_param As System.IO.Stream

    Private Sub ReportFGStockCard_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GridControl1.DataSource = dt
    End Sub

    Private Sub BandedGridView1_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles BandedGridView1.CustomColumnDisplayText
        If (e.Column.FieldName.Contains("enter") Or e.Column.FieldName = "TTL" Or e.Column.FieldName.Contains("Bal")) Then
            Dim qty As Decimal = Convert.ToDecimal(e.Value)
            If qty = 0 Then
                e.DisplayText = "-"
            End If
        End If
    End Sub
End Class