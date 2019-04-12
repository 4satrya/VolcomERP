Public Class ReportCashAdvanceReconcile
    Public Shared id_ca As String
    Public id_pre As String
    Public Shared dt As DataTable

    Private Sub ReportCashAdvanceReconcile_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim y As Integer = 0
        Dim total As Decimal = 0.00

        For i = 0 To dt.Rows.Count - 1
            total += dt.Rows(i)("value")

            'Row
            Dim row As New DevExpress.XtraReports.UI.XRTableRow

            row.HeightF = 20

            'Account
            Dim acc As New DevExpress.XtraReports.UI.XRTableCell

            acc.WidthF = 165
            acc.Text = dt.Rows(i)("acc_description")
            acc.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            row.Controls.Add(acc)

            'Description
            Dim des As New DevExpress.XtraReports.UI.XRTableCell

            des.WidthF = 165
            des.Text = dt.Rows(i)("description")
            des.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            row.Controls.Add(des)

            'Value
            Dim val As New DevExpress.XtraReports.UI.XRTableCell

            val.WidthF = 130
            val.Text = "Rp. " + String.Format("{0:#,##0.00}", dt.Rows(i)("value"))
            val.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            row.Controls.Add(val)

            'Note
            Dim note As New DevExpress.XtraReports.UI.XRTableCell

            note.WidthF = 167
            note.Text = dt.Rows(i)("note")
            note.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            row.Controls.Add(note)

            XrTable2.Controls.Add(row)
        Next

        XLListTotal.Text = "Rp. " + String.Format("{0:#,##0.00}", total)

        If id_pre = "-1" Then
            load_mark_horz("174", id_ca, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("174", id_ca, "2", "2", XrTable1)
        End If
    End Sub
End Class