Public Class ReportEmpPayrollReportPajak
    Public id_pre As String
    Public id_payroll As String
    Public data As DataTable

    Private Sub ReportEmpPayrollReportPajak_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCPajak.DataSource = data

        BandedGridColumnJenisKelamin.Caption = "Jenis" + Environment.NewLine + "Kelamin"
        BandedGridColumnJenisKelamin.Width = 50

        GBSalary.Caption = "Penghasilan" + Environment.NewLine + "Bruto"

        BandedGridColumnTotalBPJSC.Caption = "Total BPJS" + Environment.NewLine + "(JKK, JKM, BPJSKES)"
        BandedGridColumnTotalBPJSC.Width = 100

        BandedGridColumnJHTK.Caption = BandedGridColumnJHTK.Caption.Replace(" ", Environment.NewLine)
        BandedGridColumnJPK.Caption = BandedGridColumnJPK.Caption.Replace(" ", Environment.NewLine)
        BandedGridColumnBPJSKESK.Caption = BandedGridColumnBPJSKESK.Caption.Replace(" ", Environment.NewLine)
        BandedGridColumnJHTC.Caption = BandedGridColumnJHTC.Caption.Replace(" ", Environment.NewLine)
        BandedGridColumnJKKC.Caption = BandedGridColumnJKKC.Caption.Replace(" ", Environment.NewLine)
        BandedGridColumnJKMC.Caption = BandedGridColumnJKMC.Caption.Replace(" ", Environment.NewLine)
        BandedGridColumnJPC.Caption = BandedGridColumnJPC.Caption.Replace(" ", Environment.NewLine)
        BandedGridColumnBPJSKESC.Caption = BandedGridColumnBPJSKESC.Caption.Replace(" ", Environment.NewLine)

        GridColumnName.SummaryItem.DisplayFormat = "Grand Total: "

        If data.Rows(0)("is_thr").ToString = "1" Then
            GBSalary.Visible = False
            gridBand3.Visible = False
            gridBand2.Visible = False
        Else
            GBTHR.Visible = False
        End If

        'mark
        If id_pre = "-1" Then
            load_mark_horz("192", id_payroll, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("192", id_payroll, "2", "2", XrTable1)
        End If
    End Sub

    Private Sub GVPajak_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs)
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "employee_name" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    Dim curr_group As String = System.Text.RegularExpressions.Regex.Replace(GVPajak.GetRowCellValue(e.RowHandle, "group_report").ToString, "\(([A-Z])\)", "").ToString()
                    Dim alphabet As String = GVPajak.GetRowCellValue(e.RowHandle, "group_report").ToString.Replace(curr_group, "")

                    Dim curr_departement As String = System.Text.RegularExpressions.Regex.Replace(GVPajak.GetRowCellValue(e.RowHandle, "departement").ToString, "\(([A-Z][0-9])\)", "").ToString()
                    Dim alphabet_departement As String = GVPajak.GetRowCellValue(e.RowHandle, "departement").ToString.Replace(curr_departement, "")

                    If e.GroupLevel = 1 Then
                        e.TotalValue = "Total: " + alphabet_departement.Replace("(", "").Replace(")", "")
                    Else
                        e.TotalValue = "Total: " + alphabet.Replace("(", "").Replace(")", "")
                    End If
            End Select
        End If
    End Sub
End Class