Public Class ReportCashAdvanceReconcile
    Public Shared id_ca As String
    Public id_pre As String
    Public Shared dt As DataTable

    Private Sub ReportCashAdvanceReconcile_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim y As Integer = 0
        Dim total As Decimal = 0.00

        For i = 0 To dt.Rows.Count - 1
            total += dt.Rows(i)("value")

            'Account
            Dim acc As New DevExpress.XtraReports.UI.XRLabel

            acc.Text = dt.Rows(i)("acc_description")
            acc.SizeF = New Size(165, 20)
            acc.LocationF = New Point(0, y)
            acc.Font = New Font("Times New Roman", 8)
            acc.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            acc.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPList.Controls.Add(acc)

            'Description
            Dim des As New DevExpress.XtraReports.UI.XRLabel

            des.Text = dt.Rows(i)("description")
            des.SizeF = New Size(165, 20)
            des.LocationF = New Point(165, y)
            des.Font = New Font("Times New Roman", 8)
            des.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            des.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPList.Controls.Add(des)

            'Value
            Dim val As New DevExpress.XtraReports.UI.XRLabel

            val.Text = "Rp. " + String.Format("{0:#,##0.00}", dt.Rows(i)("value"))
            val.SizeF = New Size(130, 20)
            val.LocationF = New Point(330, y)
            val.Font = New Font("Times New Roman", 8)
            val.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            val.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPList.Controls.Add(val)

            'Note
            Dim note As New DevExpress.XtraReports.UI.XRLabel

            note.Text = dt.Rows(i)("note")
            note.SizeF = New Size(167, 20)
            note.LocationF = New Point(460, y)
            note.Font = New Font("Times New Roman", 8)
            note.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            note.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPList.Controls.Add(note)

            y += 20
        Next

        XLListTotal.Text = "Rp. " + String.Format("{0:#,##0.00}", total)

        If id_pre = "-1" Then
            load_mark_horz("174", id_ca, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("174", id_ca, "2", "2", XrTable1)
        End If
    End Sub
End Class