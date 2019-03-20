Public Class ReportProdDemandRev
    Public Shared id As String = "-1"
    Public Shared dt As DataTable
    Public Shared type As String = ""
    Public Shared rmt As String = ""
    Public Shared is_pre As String = "-1"
    Public Shared id_report_status As String = "-1"

    Private Sub ReportProdDemandRev_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCData.DataSource = dt
        If is_pre = "1" Then
            pre_load_mark_horz_pd(rmt, id, "2", "2", XrTable1)
        Else
            load_mark_horz(rmt, id, "2", "1", XrTable1)
        End If

        'sattus
        If id_report_status = "6" Then
            LabelTitleApprovedDate.Visible = True
            LabelDotApprovedDate.Visible = True
            LabelApprovedDate.Visible = True
        End If

        'printed date & approved date
        Dim qpd As String = "SELECT UPPER(DATE_FORMAT(rm.report_mark_datetime, '%d %M %Y')) AS `approved_date`, DATE_FORMAT(NOW(), '%d/%m/%Y %H:%i') AS `printed_date` 
        FROM tb_report_mark rm 
        WHERE rm.id_report=" + id + " AND rm.report_mark_type=" + rmt + " AND rm.id_mark=2
        ORDER BY rm.id_report_mark DESC LIMIT 1 "
        Dim dpd As DataTable = execute_query(qpd, -1, True, "", "", "", "")
        DataSource = dpd
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "NO" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub


    Dim tot_cost As Decimal
    Dim tot_prc As Decimal
    Dim tot_cost_grp As Decimal
    Dim tot_prc_grp As Decimal
    Dim tot_cost2 As Decimal
    Dim tot_prc2 As Decimal
    Dim tot_cost_grp2 As Decimal
    Dim tot_prc_grp2 As Decimal
    Private Sub GVData_CustomSummaryCalculate_1(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVData.CustomSummaryCalculate
        Dim summaryID As String = Convert.ToString(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If type = "1" Then
            ' Initialization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                tot_cost = 0.0
                tot_prc = 0.0
                tot_cost_grp = 0.0
                tot_prc_grp = 0.0
            End If

            ' Calculation 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST NON ADDITIONAL").ToString, "0.00"))
                Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMOUNT NON ADDITIONAL"), "0.00"))
                Select Case summaryID
                    Case "a"
                        tot_cost += cost
                        tot_prc += prc
                    Case "b"
                        tot_cost_grp += cost
                        tot_prc_grp += prc
                End Select
            End If

            ' Finalization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                Select Case summaryID
                    Case "a" 'total summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc / tot_cost
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                    Case "b" 'group summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc_grp / tot_cost_grp
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                End Select
            End If
        ElseIf type = "2" Then
            ' Initialization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                tot_cost2 = 0.0
                tot_prc2 = 0.0
                tot_cost_grp2 = 0.0
                tot_prc_grp2 = 0.0
            End If

            ' Calculation 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST NON ADDITIONAL").ToString, "0.00"))
                Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMOUNT NON ADDITIONAL"), "0.00"))
                Select Case summaryID
                    Case "c"
                        tot_cost2 += cost
                        tot_prc2 += prc
                    Case "d"
                        tot_cost_grp2 += cost
                        tot_prc_grp2 += prc
                End Select
            End If

            ' Finalization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                Select Case summaryID
                    Case "c" 'total summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc2 / tot_cost2
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                    Case "d" 'group summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc_grp2 / tot_cost_grp2
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                End Select
            End If
        End If
    End Sub

    Private Sub GVData_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVData.RowCellStyle
        Dim currview As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim stt As String = "0"
        Try
            stt = currview.GetRowCellValue(e.RowHandle, "id_pd_status_rev").ToString
        Catch ex As Exception
            stt = "0"
        End Try

        If stt = "1" Then
            e.Appearance.BackColor = Color.Gainsboro
            e.Appearance.FontStyleDelta = FontStyle.Regular
        ElseIf stt = "2" Then
            e.Appearance.BackColor = Color.Gray
            e.Appearance.FontStyleDelta = FontStyle.Regular
        Else
            e.Appearance.BackColor = Color.Empty
            e.Appearance.FontStyleDelta = FontStyle.Regular
        End If
    End Sub

End Class