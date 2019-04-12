Public Class ReportLineListChanges
    Public Shared id_design_rev As String
    Public Shared id_pre As String
    Public Shared report_mark_type As String
    Public Shared dt As DataTable

    Private Sub ReportLineListChanges_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        For i = 0 To dt.Rows.Count - 1
            'Row
            Dim row As New DevExpress.XtraReports.UI.XRTableRow
            row.HeightF = 20

            'Type
            Dim type As New DevExpress.XtraReports.UI.XRTableCell
            type.Text = dt.Rows(i)("type")
            type.WidthF = 250
            type.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            type.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            row.Cells.Add(type)

            'From
            Dim from As New DevExpress.XtraReports.UI.XRTableCell
            from.Text = dt.Rows(i)("from")
            from.WidthF = 225
            from.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            from.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom
            from.Multiline = True

            row.Cells.Add(from)

            'To
            Dim to_change As New DevExpress.XtraReports.UI.XRTableCell
            to_change.Text = dt.Rows(i)("to")
            to_change.WidthF = 225
            to_change.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            to_change.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom
            to_change.Multiline = True

            row.Cells.Add(to_change)

            'Add row
            XTChangesList.Rows.Add(row)
        Next

        If id_pre = "-1" Then
            load_mark_horz(report_mark_type, id_design_rev, "2", "1", XrTable1)
        Else
            pre_load_mark_horz(report_mark_type, id_design_rev, "2", "2", XrTable1)
        End If
    End Sub
End Class