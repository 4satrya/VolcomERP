Public Class ReportEmpPerAppraisalSUM
    Public Shared dt As DataTable

    Private Sub ReportEmpPerAppraisalSUM_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim y As Integer = 0
        Dim id_group As Integer = 0
        Dim group_total As Decimal = 0
        Dim max_total As Decimal = 0

        For i = 0 To dt.Rows.Count - 1
            'Total
            If id_group <> 0 And id_group <> dt.Rows(i)("id_question_sum_group") Then
                Dim tb_tq As New DevExpress.XtraReports.UI.XRLabel

                tb_tq.Text = ""
                tb_tq.SizeF = New Size(100, 17)
                tb_tq.LocationF = New Point(0, y)
                tb_tq.Font = New Font("Arial", 8, FontStyle.Bold)
                tb_tq.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                tb_tq.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                tb_tq.BackColor = Color.LightGray

                Me.XPResume.Controls.Add(tb_tq)

                Dim tb_tt As New DevExpress.XtraReports.UI.XRLabel

                tb_tt.Text = "Total"
                tb_tt.SizeF = New Size(200, 17)
                tb_tt.LocationF = New Point(100, y)
                tb_tt.Font = New Font("Arial", 8, FontStyle.Bold)
                tb_tt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                tb_tt.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                tb_tt.BackColor = Color.LightGray

                Me.XPResume.Controls.Add(tb_tt)

                Dim tb_ts As New DevExpress.XtraReports.UI.XRLabel

                tb_ts.Text = ""
                tb_ts.SizeF = New Size(150, 17)
                tb_ts.LocationF = New Point(300, y)
                tb_ts.Font = New Font("Arial", 8)
                tb_ts.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                tb_ts.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                tb_ts.BackColor = Color.LightGray

                Me.XPResume.Controls.Add(tb_ts)

                Dim tb_tf As New DevExpress.XtraReports.UI.XRLabel

                tb_tf.Text = FormatNumber(group_total, 2).ToString + "%"
                tb_tf.SizeF = New Size(150, 17)
                tb_tf.LocationF = New Point(450, y)
                tb_tf.Font = New Font("Arial", 8, FontStyle.Bold)
                tb_tf.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                tb_tf.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                tb_tf.BackColor = Color.LightGray

                Me.XPResume.Controls.Add(tb_tf)

                Dim tb_tm As New DevExpress.XtraReports.UI.XRLabel

                tb_tm.Text = FormatNumber(max_total, 2).ToString + "%"
                tb_tm.SizeF = New Size(150, 17)
                tb_tm.LocationF = New Point(600, y)
                tb_tm.Font = New Font("Arial", 8, FontStyle.Bold)
                tb_tm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                tb_tm.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                tb_tm.BackColor = Color.LightGray

                Me.XPResume.Controls.Add(tb_tm)

                y = y + 17
            End If

            'Group
            If id_group <> dt.Rows(i)("id_question_sum_group") Then
                Dim tb_g As New DevExpress.XtraReports.UI.XRLabel

                tb_g.Text = dt.Rows(i)("group_name").ToString
                tb_g.SizeF = New Size(750, 17)
                tb_g.LocationF = New Point(0, y)
                tb_g.Font = New Font("Arial", 8, FontStyle.Bold)
                tb_g.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                tb_g.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                tb_g.BackColor = Color.Yellow

                Me.XPResume.Controls.Add(tb_g)

                y = y + 17

                group_total = 0
                max_total = 0
            End If

            'Question
            Dim tb_t As New DevExpress.XtraReports.UI.XRLabel

            tb_t.Text = dt.Rows(i)("question").ToString
            tb_t.SizeF = New Size(200, 17)
            tb_t.LocationF = New Point(100, y)
            tb_t.Font = New Font("Arial", 8)
            tb_t.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            tb_t.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XPResume.Controls.Add(tb_t)

            'Point
            Dim tb_p As New DevExpress.XtraReports.UI.XRLabel

            tb_p.Text = dt.Rows(i)("value").ToString
            tb_p.SizeF = New Size(150, 17)
            tb_p.LocationF = New Point(300, y)
            tb_p.Font = New Font("Arial", 8)
            tb_p.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_p.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_p.BackColor = Color.PeachPuff

            Me.XPResume.Controls.Add(tb_p)

            'Formula
            Dim tb_f As New DevExpress.XtraReports.UI.XRLabel

            tb_f.Text = FormatNumber(dt.Rows(i)("result").ToString, 2).ToString + "%"
            tb_f.SizeF = New Size(150, 17)
            tb_f.LocationF = New Point(450, y)
            tb_f.Font = New Font("Arial", 8)
            tb_f.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_f.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XPResume.Controls.Add(tb_f)

            'Standard
            Dim tb_s As New DevExpress.XtraReports.UI.XRLabel

            tb_s.Text = FormatNumber(dt.Rows(i)("max_value"), 2).ToString + "%"
            tb_s.SizeF = New Size(150, 17)
            tb_s.LocationF = New Point(600, y)
            tb_s.Font = New Font("Arial", 8)
            tb_s.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_s.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XPResume.Controls.Add(tb_s)

            y = y + 17

            id_group = dt.Rows(i)("id_question_sum_group")

            group_total = group_total + dt.Rows(i)("result")
            max_total = max_total + dt.Rows(i)("max_value")

            If i = dt.Rows.Count - 1 Then
                'Total Last
                Dim tb_tq As New DevExpress.XtraReports.UI.XRLabel

                tb_tq.Text = ""
                tb_tq.SizeF = New Size(100, 17)
                tb_tq.LocationF = New Point(0, y)
                tb_tq.Font = New Font("Arial", 8, FontStyle.Bold)
                tb_tq.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                tb_tq.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                tb_tq.BackColor = Color.LightGray

                Me.XPResume.Controls.Add(tb_tq)

                Dim tb_tt As New DevExpress.XtraReports.UI.XRLabel

                tb_tt.Text = "Total"
                tb_tt.SizeF = New Size(200, 17)
                tb_tt.LocationF = New Point(100, y)
                tb_tt.Font = New Font("Arial", 8, FontStyle.Bold)
                tb_tt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                tb_tt.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                tb_tt.BackColor = Color.LightGray

                Me.XPResume.Controls.Add(tb_tt)

                Dim tb_ts As New DevExpress.XtraReports.UI.XRLabel

                tb_ts.Text = ""
                tb_ts.SizeF = New Size(150, 17)
                tb_ts.LocationF = New Point(300, y)
                tb_ts.Font = New Font("Arial", 8)
                tb_ts.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                tb_ts.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                tb_ts.BackColor = Color.LightGray

                Me.XPResume.Controls.Add(tb_ts)

                Dim tb_tf As New DevExpress.XtraReports.UI.XRLabel

                tb_tf.Text = FormatNumber(group_total, 2).ToString + "%"
                tb_tf.SizeF = New Size(150, 17)
                tb_tf.LocationF = New Point(450, y)
                tb_tf.Font = New Font("Arial", 8, FontStyle.Bold)
                tb_tf.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                tb_tf.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                tb_tf.BackColor = Color.LightGray

                Me.XPResume.Controls.Add(tb_tf)

                Dim tb_tm As New DevExpress.XtraReports.UI.XRLabel

                tb_tm.Text = FormatNumber(max_total, 2).ToString + "%"
                tb_tm.SizeF = New Size(150, 17)
                tb_tm.LocationF = New Point(600, y)
                tb_tm.Font = New Font("Arial", 8, FontStyle.Bold)
                tb_tm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                tb_tm.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                tb_tm.BackColor = Color.LightGray

                Me.XPResume.Controls.Add(tb_tm)
            End If
        Next
    End Sub
End Class