Public Class ReportDeptHeadSurvey
    Public Shared dt As DataTable

    Private Sub ReportDeptHeadSurvey_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim y As Integer = 13 + 20

        For i = 0 To dt.Rows.Count - 1
            Dim ct_no As New DevExpress.XtraReports.UI.XRLabel

            ct_no.Text = (i + 1).ToString + "."
            ct_no.SizeF = New Size(20, 13)
            ct_no.LocationF = New Point(0, y)
            ct_no.Font = New Font("Arial", 8)
            ct_no.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.Detail.Controls.Add(ct_no)

            Dim ct_q As New DevExpress.XtraReports.UI.XRLabel

            ct_q.Text = dt.Rows(i)("question")
            ct_q.SizeF = New Size(450, 13)
            ct_q.LocationF = New Point(20, y)
            ct_q.Font = New Font("Arial", 8)
            ct_q.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.Detail.Controls.Add(ct_q)

            Dim x As Integer = 500

            For j = 1 To 5
                Dim ct_r As New DevExpress.XtraReports.UI.XRLabel

                ct_r.Text = j
                ct_r.SizeF = New Size(50, 13)
                ct_r.LocationF = New Point(x, y)
                ct_r.Font = New Font("Arial", 8)
                ct_r.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                ct_r.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter

                Me.Detail.Controls.Add(ct_r)

                If dt.Rows(i)("value") = j.ToString Then
                    Dim ct_rv As New DevExpress.XtraReports.UI.XRShape

                    ct_rv.SizeF = New Size(20, 20)
                    ct_rv.LocationF = New Point(x + 15, y - 3.5)

                    Me.Detail.Controls.Add(ct_rv)
                End If

                x = x + 50
            Next

            y = y + 13 + 5

            Dim ct_qr As New DevExpress.XtraReports.UI.XRLabel

            ct_qr.Text = dt.Rows(i)("information")
            ct_qr.SizeF = New Size(730, 13)
            ct_qr.LocationF = New Point(20, y)
            ct_qr.Font = New Font("Arial", 8)
            ct_qr.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.Detail.Controls.Add(ct_qr)

            y = y + 13 + 10
        Next
    End Sub
End Class