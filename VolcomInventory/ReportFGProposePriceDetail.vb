Public Class ReportFGProposePriceDetail
    Public Shared id As String = "-1"
    Public Shared dt As DataTable
    Public Shared rmt As String = ""
    Public Shared is_pre As String = "-1"
    Public Shared id_report_status As String = "-1"

    Private Sub ReportFGProposePriceDetail_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
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

    Dim last_parent As Integer = "0"
    Dim start As Integer = 0
    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If GetGroupRowCount(GVData) <= 0 Then
            If e.Column.FieldName = "no" Then
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
            End If
        Else
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            If e.Column.FieldName <> "no" Then Return
            If view.GroupedColumns.Count <> 0 AndAlso Not e.IsForGroupRow Then
                Dim rowHandle As Integer = view.GetRowHandle(e.ListSourceRowIndex)
                e.DisplayText = (view.GetRowGroupIndexByRowHandle(rowHandle) + 1).ToString()
            End If
        End If
    End Sub

    Dim tot_cost As Decimal
    Dim tot_prc As Decimal
    Dim tot_cost_grp As Decimal
    Dim tot_prc_grp As Decimal

    Dim tot_cost_mng As Decimal
    Dim tot_cost_grp_mng As Decimal

    Dim tot_prc_sale As Decimal
    Dim tot_prc_grp_sale As Decimal
    Private Sub GVData_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVData.CustomSummaryCalculate
        Dim summaryID As String = Convert.ToString(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            tot_cost = 0.0
            tot_prc = 0.0
            tot_cost_grp = 0.0
            tot_prc_grp = 0.0

            tot_cost_mng = 0.0
            tot_cost_grp_mng = 0.0

            tot_prc_sale = 0.0
            tot_prc_grp_sale = 0.0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_cost_min_add").ToString, "0.00"))
            Dim cost_mng As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_cost_manag_rate_min_add").ToString, "0.00"))
            Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_amount_min_add"), "0.00"))
            Dim prc_sale As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_amount_sale_min_add"), "0.00"))

            Select Case summaryID
                Case "a"
                    tot_cost += cost
                    tot_prc += prc
                Case "b"
                    tot_cost_grp += cost
                    tot_prc_grp += prc
                Case "a_mng"
                    tot_cost_mng += cost_mng
                    tot_prc += prc
                Case "b_mng"
                    tot_cost_grp_mng += cost_mng
                    tot_prc_grp += prc
                Case "a_sale"
                    tot_cost += cost
                    tot_prc_sale += prc_sale
                Case "b_sale"
                    tot_cost_grp += cost
                    tot_prc_grp_sale += prc_sale
                Case "a_mng_sale"
                    tot_cost_mng += cost_mng
                    tot_prc_sale += prc_sale
                Case "b_mng_sale"
                    tot_cost_grp_mng += cost_mng
                    tot_prc_grp_sale += prc_sale
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
                Case "a_mng" 'total summary mng
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc / tot_cost_mng
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "b_mng" 'group summary mng
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc_grp / tot_cost_grp_mng
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "a_sale" 'total summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc_sale / tot_cost
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "b_sale" 'group summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc_grp_sale / tot_cost_grp
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "a_mng_sale" 'total summary mng
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc_sale / tot_cost_mng
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "b_mng_sale" 'group summary mng
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc_grp_sale / tot_cost_grp_mng
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
            End Select
        End If
    End Sub
End Class