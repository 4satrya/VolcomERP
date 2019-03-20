Public Class ReportEmpPerAppraisalPAU
    Public Shared dt_question As DataTable
    Public Shared dt_group_question As DataTable
    Public Shared dt_result As DataTable
    Public Shared dt_conclusion As DataTable

    Private Sub ReportEmpPerAppraisalDet_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim y As Integer = 0
        Dim last_group As Integer = 0

        Dim result_x() As Integer = {220, 290, 360, 430, 500}
        Dim subtotal() As Integer = {0, 0, 0, 0, 0}

        'Aspek yg Dinilai
        For i = 0 To dt_question.Rows.Count - 1
            'Sub total
            If last_group <> 0 And last_group <> dt_question.Rows(i)("id_question_gen_app_group") Then
                Dim tb_ts As New DevExpress.XtraReports.UI.XRLabel

                tb_ts.Text = "SUB TOTAL"
                tb_ts.SizeF = New Size(80, 17)
                tb_ts.LocationF = New Point(result_x(0) - 80, y)
                tb_ts.Font = New Font("Arial", 8)
                tb_ts.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

                Me.XPAspek.Controls.Add(tb_ts)

                For j = 0 To result_x.Length() - 1
                    Dim tb_v As New DevExpress.XtraReports.UI.XRLabel

                    tb_v.Text = subtotal(j)
                    tb_v.SizeF = New Size(70, 17)
                    tb_v.LocationF = New Point(result_x(j), y)
                    tb_v.Font = New Font("Arial", 8)
                    tb_v.Borders = DevExpress.XtraPrinting.BorderSide.All
                    tb_v.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                    tb_v.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter

                    Me.XPAspek.Controls.Add(tb_v)
                Next

                Dim tb_st As New DevExpress.XtraReports.UI.XRLabel

                tb_st.Text = "TOTAL"
                tb_st.SizeF = New Size(90, 17)
                tb_st.LocationF = New Point(570, y)
                tb_st.Font = New Font("Arial", 8, FontStyle.Bold)
                tb_st.Borders = DevExpress.XtraPrinting.BorderSide.All
                tb_st.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                tb_st.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter

                Me.XPAspek.Controls.Add(tb_st)

                Dim tb_stt As New DevExpress.XtraReports.UI.XRLabel

                tb_stt.Text = subtotal(0) + subtotal(1) + subtotal(2) + subtotal(3) + subtotal(4)
                tb_stt.SizeF = New Size(90, 17)
                tb_stt.LocationF = New Point(660, y)
                tb_stt.Font = New Font("Arial", 8, FontStyle.Bold)
                tb_stt.Borders = DevExpress.XtraPrinting.BorderSide.All
                tb_stt.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                tb_stt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter

                Me.XPAspek.Controls.Add(tb_stt)

                y = y + 13 + 5
            End If

            'Group
            If last_group <> dt_question.Rows(i)("id_question_gen_app_group") Then
                Dim tb_g As New DevExpress.XtraReports.UI.XRLabel

                tb_g.Text = dt_question.Rows(i)("group_name")
                tb_g.SizeF = New Size(200, 13)
                tb_g.LocationF = New Point(0, y)
                tb_g.Font = New Font("Arial", 8, FontStyle.Bold)
                tb_g.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

                Me.XPAspek.Controls.Add(tb_g)

                y = y + 13 + 5

                subtotal(0) = 0
                subtotal(1) = 0
                subtotal(2) = 0
                subtotal(3) = 0
                subtotal(4) = 0
            End If

            last_group = dt_question.Rows(i)("id_question_gen_app_group")

            'Number
            Dim tb_n As New DevExpress.XtraReports.UI.XRLabel

            tb_n.Text = (i + 1).ToString + "."
            tb_n.SizeF = New Size(20, 13)
            tb_n.LocationF = New Point(20, y)
            tb_n.Font = New Font("Arial", 8)
            tb_n.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XPAspek.Controls.Add(tb_n)

            'Question
            Dim tb_q As New DevExpress.XtraReports.UI.XRLabel

            tb_q.Text = dt_question.Rows(i)("question")
            tb_q.SizeF = New Size(200, 13)
            tb_q.LocationF = New Point(40, y)
            tb_q.Font = New Font("Arial", 8, FontStyle.Bold)
            tb_q.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XPAspek.Controls.Add(tb_q)

            'Result Value
            For j = 0 To result_x.Length() - 1
                Dim tb_v As New DevExpress.XtraReports.UI.XRLabel

                tb_v.Text = ""

                If j = 0 And dt_question.Rows(i)("value") <= 1 Then
                    tb_v.Text = dt_question.Rows(i)("value")

                    subtotal(0) = subtotal(0) + dt_question.Rows(i)("value")
                End If

                If j = 1 And dt_question.Rows(i)("value") >= 2 And dt_question.Rows(i)("value") <= 4 Then
                    tb_v.Text = dt_question.Rows(i)("value")

                    subtotal(1) = subtotal(1) + dt_question.Rows(i)("value")
                End If

                If j = 2 And dt_question.Rows(i)("value") >= 5 And dt_question.Rows(i)("value") <= 6 Then
                    tb_v.Text = dt_question.Rows(i)("value")

                    subtotal(2) = subtotal(2) + dt_question.Rows(i)("value")
                End If

                If j = 3 And dt_question.Rows(i)("value") >= 7 And dt_question.Rows(i)("value") <= 8 Then
                    tb_v.Text = dt_question.Rows(i)("value")

                    subtotal(3) = subtotal(3) + dt_question.Rows(i)("value")
                End If

                If j = 4 And dt_question.Rows(i)("value") >= 9 And dt_question.Rows(i)("value") <= 10 Then
                    tb_v.Text = dt_question.Rows(i)("value")

                    subtotal(4) = subtotal(4) + dt_question.Rows(i)("value")
                End If

                tb_v.SizeF = New Size(70, 17)
                tb_v.LocationF = New Point(result_x(j), y)
                tb_v.Font = New Font("Arial", 8)
                tb_v.Borders = DevExpress.XtraPrinting.BorderSide.All
                tb_v.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                tb_v.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter

                Me.XPAspek.Controls.Add(tb_v)
            Next

            'Result Information
            Dim tb_i As New DevExpress.XtraReports.UI.XRLabel

            tb_i.Text = dt_question.Rows(i)("information")
            tb_i.SizeF = New Size(180, 17)
            tb_i.LocationF = New Point(570, y)
            tb_i.Font = New Font("Arial", 8)
            tb_i.Borders = DevExpress.XtraPrinting.BorderSide.All
            tb_i.Padding = New DevExpress.XtraPrinting.PaddingInfo(7, 2, 0, 0)

            Me.XPAspek.Controls.Add(tb_i)

            y = y + 17

            'Detail
            Dim tb_qd As New DevExpress.XtraReports.UI.XRLabel

            tb_qd.Text = dt_question.Rows(i)("question_detail")
            tb_qd.SizeF = New Size(750, 13)
            tb_qd.LocationF = New Point(40, y)
            tb_qd.Font = New Font("Arial", 8, FontStyle.Italic)
            tb_qd.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XPAspek.Controls.Add(tb_qd)

            y = y + 13 + 5

            'Last Sub total
            If i = dt_question.Rows.Count - 1 Then
                Dim tb_ts As New DevExpress.XtraReports.UI.XRLabel

                tb_ts.Text = "SUB TOTAL"
                tb_ts.SizeF = New Size(80, 17)
                tb_ts.LocationF = New Point(result_x(0) - 80, y)
                tb_ts.Font = New Font("Arial", 8)
                tb_ts.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

                Me.XPAspek.Controls.Add(tb_ts)

                For j = 0 To result_x.Length() - 1
                    Dim tb_v As New DevExpress.XtraReports.UI.XRLabel

                    tb_v.Text = subtotal(j)
                    tb_v.SizeF = New Size(70, 17)
                    tb_v.LocationF = New Point(result_x(j), y)
                    tb_v.Font = New Font("Arial", 8)
                    tb_v.Borders = DevExpress.XtraPrinting.BorderSide.All
                    tb_v.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                    tb_v.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter

                    Me.XPAspek.Controls.Add(tb_v)
                Next

                Dim tb_st As New DevExpress.XtraReports.UI.XRLabel

                tb_st.Text = "TOTAL"
                tb_st.SizeF = New Size(90, 17)
                tb_st.LocationF = New Point(570, y)
                tb_st.Font = New Font("Arial", 8, FontStyle.Bold)
                tb_st.Borders = DevExpress.XtraPrinting.BorderSide.All
                tb_st.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                tb_st.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter

                Me.XPAspek.Controls.Add(tb_st)

                Dim tb_stt As New DevExpress.XtraReports.UI.XRLabel

                tb_stt.Text = subtotal(0) + subtotal(1) + subtotal(2) + subtotal(3) + subtotal(4)
                tb_stt.SizeF = New Size(90, 17)
                tb_stt.LocationF = New Point(660, y)
                tb_stt.Font = New Font("Arial", 8, FontStyle.Bold)
                tb_stt.Borders = DevExpress.XtraPrinting.BorderSide.All
                tb_stt.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                tb_stt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter

                Me.XPAspek.Controls.Add(tb_stt)

                y = y + 13 + 5
            End If
        Next

        'Total Nilai & Bobot
        y = 0

        For i = 0 To dt_group_question.Rows.Count - 1
            'Group Name
            Dim tb_g As New DevExpress.XtraReports.UI.XRLabel

            tb_g.Text = dt_group_question.Rows(i)("group_name")
            tb_g.SizeF = New Size(150, 17)
            tb_g.LocationF = New Point(0, y)
            If i = dt_group_question.Rows.Count - 1 Then
                tb_g.Font = New Font("Arial", 8, FontStyle.Bold)
            Else
                tb_g.Font = New Font("Arial", 8)
            End If
            tb_g.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XPGroupQuestion.Controls.Add(tb_g)

            'Equal
            Dim tb_e As New DevExpress.XtraReports.UI.XRLabel

            If i = dt_group_question.Rows.Count - 1 Then
                tb_e.Text = ""
            Else
                tb_e.Text = "="
            End If
            tb_e.SizeF = New Size(20, 17)
            tb_e.LocationF = New Point(150, y)
            If i = dt_group_question.Rows.Count - 1 Then
                tb_e.Font = New Font("Arial", 8, FontStyle.Bold)
            Else
                tb_e.Font = New Font("Arial", 8)
            End If
            tb_e.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XPGroupQuestion.Controls.Add(tb_e)

            'Formula
            Dim tb_f As New DevExpress.XtraReports.UI.XRLabel

            tb_f.Text = dt_group_question.Rows(i)("formula")
            tb_f.SizeF = New Size(100, 17)
            tb_f.LocationF = New Point(170, y)
            If i = dt_group_question.Rows.Count - 1 Then
                tb_f.Font = New Font("Arial", 8, FontStyle.Bold)
            Else
                tb_f.Font = New Font("Arial", 8)
            End If
            tb_f.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XPGroupQuestion.Controls.Add(tb_f)

            'Total
            Dim tb_t As New DevExpress.XtraReports.UI.XRLabel

            tb_t.Text = dt_group_question.Rows(i)("total")
            tb_t.SizeF = New Size(50, 17)
            tb_t.LocationF = New Point(270, y)
            If i = dt_group_question.Rows.Count - 1 Then
                tb_t.Font = New Font("Arial", 8, FontStyle.Bold)
            Else
                tb_t.Font = New Font("Arial", 8)
            End If
            tb_t.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XPGroupQuestion.Controls.Add(tb_t)

            y = y + 17
        Next

        'Penilaian Umum
        y = 0

        For i = 0 To dt_result.Rows.Count - 1
            'Result
            Dim tb_r As New DevExpress.XtraReports.UI.XRLabel

            tb_r.Text = dt_result.Rows(i)("result")
            tb_r.SizeF = New Size(50, 17)
            tb_r.LocationF = New Point(0, y)
            If dt_result.Rows(i)("result") = "" Then
                tb_r.Font = New Font("Arial", 8)
            Else
                tb_r.Font = New Font("Arial", 8, FontStyle.Bold)
            End If
            tb_r.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XPResult.Controls.Add(tb_r)

            'Name
            Dim tb_n As New DevExpress.XtraReports.UI.XRLabel

            tb_n.Text = dt_result.Rows(i)("name")
            tb_n.SizeF = New Size(150, 17)
            tb_n.LocationF = New Point(50, y)
            If dt_result.Rows(i)("result") = "" Then
                tb_n.Font = New Font("Arial", 8)
            Else
                tb_n.Font = New Font("Arial", 8, FontStyle.Bold)
            End If
            tb_n.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XPResult.Controls.Add(tb_n)

            'Range
            Dim tb_ra As New DevExpress.XtraReports.UI.XRLabel

            tb_ra.Text = dt_result.Rows(i)("range")
            tb_ra.SizeF = New Size(130, 17)
            tb_ra.LocationF = New Point(235, y)
            If dt_result.Rows(i)("result") = "" Then
                tb_ra.Font = New Font("Arial", 8)
            Else
                tb_ra.Font = New Font("Arial", 8, FontStyle.Bold)
            End If
            tb_ra.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XPResult.Controls.Add(tb_ra)

            y = y + 17
        Next

        'Kesimpulan
        y = 0

        For i = 0 To dt_conclusion.Rows.Count - 1
            'Number
            Dim tb_n As New DevExpress.XtraReports.UI.XRLabel

            tb_n.Text = (i + 1).ToString + "."
            tb_n.SizeF = New Size(20, 13)
            tb_n.LocationF = New Point(0, y)
            tb_n.Font = New Font("Arial", 8)
            tb_n.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XPConclusion.Controls.Add(tb_n)

            'Question
            Dim tb_q As New DevExpress.XtraReports.UI.XRLabel

            tb_q.Text = dt_conclusion.Rows(i)("question")
            tb_q.SizeF = New Size(730, 13)
            tb_q.LocationF = New Point(20, y)
            tb_q.Font = New Font("Arial", 8)
            tb_q.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XPConclusion.Controls.Add(tb_q)

            y = y + 13

            'Conclusion
            Dim tb_c As New DevExpress.XtraReports.UI.XRLabel

            tb_c.Text = dt_conclusion.Rows(i)("conclusion")
            tb_c.SizeF = New Size(730, 13)
            tb_c.LocationF = New Point(20, y)
            tb_c.Font = New Font("Arial", 8)
            tb_c.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_c.Multiline = True

            Me.XPConclusion.Controls.Add(tb_c)

            y = y + 23
        Next
    End Sub
End Class