Public Class ReportMasterCompanySingle
    Public DTLegal As New DataTable

    Private Sub ReportMasterCompanySingle_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        If DTLegal.Rows.Count <= 0 Then
            XLLegal.Visible = False
            XTLegal.Visible = False
        Else
            For i = 0 To DTLegal.Rows.Count - 1
                'Row
                Dim row As New DevExpress.XtraReports.UI.XRTableRow

                row.HeightF = 20

                'Type
                Dim type As New DevExpress.XtraReports.UI.XRTableCell

                type.Text = DTLegal.Rows(i)("legal_type").ToString
                type.WidthF = 200
                type.Padding = New DevExpress.XtraPrinting.PaddingInfo(2)
                type.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

                row.Controls.Add(type)

                'Number
                Dim number As New DevExpress.XtraReports.UI.XRTableCell

                number.Text = DTLegal.Rows(i)("number").ToString
                number.WidthF = 220
                number.Padding = New DevExpress.XtraPrinting.PaddingInfo(2)
                number.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

                row.Controls.Add(number)

                'Active Until
                Dim until As New DevExpress.XtraReports.UI.XRTableCell

                until.Text = If(DTLegal.Rows(i)("active_until").ToString = "", "", Date.Parse(DTLegal.Rows(i)("active_until").ToString).ToString("dd MM yyyy"))
                until.WidthF = 229
                until.Padding = New DevExpress.XtraPrinting.PaddingInfo(2)
                until.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

                row.Controls.Add(until)

                XTLegal.Controls.Add(row)
            Next
        End If
    End Sub
End Class