Public Class FormCashAdvanceReport
    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_ca()
    End Sub

    Private Sub FormCashAdvanceReport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormCashAdvanceReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateFrom.EditValue = Now
        DateTo.EditValue = Now
    End Sub

    Sub load_ca()
        Dim date_from As String = ""
        Dim date_to As String = ""

        Try
            date_from = DateTime.Parse(DateFrom.EditValue.ToString).ToString("yyyy-MM-dd")
            date_to = DateTime.Parse(DateTo.EditValue.ToString).ToString("yyyy-MM-dd")


            Dim where_string As String = ""

            Dim query As String = "CALL view_cash_advance_report_coa('" & date_from & "','" & date_to & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            'set cancel
            Dim q_cancel As String = "SELECT id_cash_advance FROM tb_cash_advance_cancel WHERE id_report_status = 6"
            Dim d_cancel As DataTable = execute_query(q_cancel, -1, True, "", "", "", "")

            For i = 0 To data.Rows.Count - 1
                For j = 0 To d_cancel.Rows.Count - 1
                    If data.Rows(i)("id_cash_advance").ToString = d_cancel.Rows(j)("id_cash_advance").ToString Then
                        data.Rows(i)("report_status") = "Cancelled"
                        data.Rows(i)("coa") = ""
                        data.Rows(i)("coa_desc") = ""
                        data.Rows(i)("coa_expense") = ""
                        data.Rows(i)("expense") = 0
                        data.Rows(i)("advance") = 0
                        data.Rows(i)("cash_out") = 0
                    End If
                Next
            Next

            GCReport.DataSource = data
            GVReport.BestFitColumns()
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        load_ca()

        GridColumnDateCreated.Visible = False
        GridColumnStatus.Visible = False
        GridColumnReconcileDueDate.Visible = False
        GridColumnCashInAdvancePeriode.Visible = False
        GridColumnCashOnHandOut.Visible = False
        GridColumnAdvance.Visible = False
        GridColumnOverdue.Visible = False
        GridColumnCOADesc.Visible = False
        '
        GVReport.ActiveFilterString = "[expense]>0"
        '
        print(Me.GCReport, "Expense Report (" & DateTime.Parse(DateFrom.EditValue.ToString).ToString("dd MMMM yyyy") & " - " & DateTime.Parse(DateTo.EditValue.ToString).ToString("dd MMMM yyyy") & ")")
        '
        GVReport.ActiveFilterString = ""
        '
        GridColumnNumber.VisibleIndex = 0
        GridColumnDateCreated.VisibleIndex = 1
        GridColumnEmployee.VisibleIndex = 2
        GridColumnPurpose.VisibleIndex = 3
        GridColumnStatus.VisibleIndex = 4
        GridColumnReconcileDueDate.VisibleIndex = 5
        GridColumnReconcileActualDate.VisibleIndex = 6
        GridColumnCashInAdvancePeriode.VisibleIndex = 7
        GridColumnCashInAdvance.VisibleIndex = 8
        GridColumnCOA.VisibleIndex = 9
        GridColumnCOADesc.VisibleIndex = 10
        GridColumnCoaExpense.VisibleIndex = 11
        GridColumnExpense.VisibleIndex = 12
        GridColumnAdvance.VisibleIndex = 13
        GridColumnCashOnHandOut.VisibleIndex = 14
        GridColumnOverdue.VisibleIndex = 15
    End Sub

    Private Sub BPrintAdvance_Click(sender As Object, e As EventArgs) Handles BPrintAdvance.Click
        load_ca()

        GridColumnDateCreated.Visible = False
        GridColumnStatus.Visible = False
        GridColumnReconcileActualDate.Visible = False
        GridColumnCashInAdvancePeriode.Visible = False
        GridColumnCashInAdvance.Visible = False
        GridColumnExpense.Visible = False
        GridColumnCashOnHandOut.Visible = False
        GridColumnCOADesc.Visible = False
        GridColumnCOA.Visible = False
        GridColumnCoaExpense.Visible = False
        '
        GVReport.ActiveFilterString = "[advance]>0"
        '
        print(Me.GCReport, "Advance Report (" & DateTime.Parse(DateFrom.EditValue.ToString).ToString("dd MMMM yyyy") & " - " & DateTime.Parse(DateTo.EditValue.ToString).ToString("dd MMMM yyyy") & ")")
        '
        GVReport.ActiveFilterString = ""
        '
        GridColumnNumber.VisibleIndex = 0
        GridColumnDateCreated.VisibleIndex = 1
        GridColumnEmployee.VisibleIndex = 2
        GridColumnPurpose.VisibleIndex = 3
        GridColumnStatus.VisibleIndex = 4
        GridColumnReconcileDueDate.VisibleIndex = 5
        GridColumnReconcileActualDate.VisibleIndex = 6
        GridColumnCashInAdvancePeriode.VisibleIndex = 7
        GridColumnCashInAdvance.VisibleIndex = 8
        GridColumnCOA.VisibleIndex = 9
        GridColumnCOADesc.VisibleIndex = 10
        GridColumnCoaExpense.VisibleIndex = 11
        GridColumnExpense.VisibleIndex = 12
        GridColumnAdvance.VisibleIndex = 13
        GridColumnCashOnHandOut.VisibleIndex = 14
        GridColumnOverdue.VisibleIndex = 15
    End Sub

    Private Sub BSummaryReport_Click(sender As Object, e As EventArgs) Handles BSummaryReport.Click
        load_ca()

        Dim saldo_awal As Decimal = Decimal.Parse(get_opt_acc_field("saldo_awal_report_cash_advance"))

        Dim report As ReportCashAdvanceSummary = New ReportCashAdvanceSummary

        report.XLPeriod.Text = "PERIODE " + Date.Parse(DateFrom.EditValue.ToString).ToString("dd MMMM yyyy").ToUpper + " - " + Date.Parse(DateTo.EditValue.ToString).ToString("dd MMMM yyyy").ToUpper

        report.XTCLabelSaldoAkhir.Text = report.XTCLabelSaldoAkhir.Text.Replace("[period_end]", Date.Parse(DateTo.EditValue.ToString).ToString("dd MMMM yyyy"))

        report.XTCSaldoAwal.Text = Format(saldo_awal, "##,##0")
        report.XTCExpense.Text = Format(Decimal.Parse(GridColumnExpense.SummaryItem.SummaryValue.ToString), "##,##0")
        report.XTCSaldoAkhir.Text = Format(Decimal.Parse(saldo_awal) - Decimal.Parse(GridColumnExpense.SummaryItem.SummaryValue.ToString), "##,##0")
        report.XTCAdvance.Text = Format(Decimal.Parse(GridColumnAdvance.SummaryItem.SummaryValue.ToString), "##,##0")
        report.XTCCashOnHand.Text = Format((Decimal.Parse(saldo_awal) - Decimal.Parse(GridColumnExpense.SummaryItem.SummaryValue.ToString)) - Decimal.Parse(GridColumnAdvance.SummaryItem.SummaryValue.ToString), "##,##0")

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        Tool.ShowPreviewDialog()
    End Sub
End Class