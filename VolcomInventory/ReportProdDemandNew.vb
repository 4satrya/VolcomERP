Public Class ReportProdDemandNew
    Public Shared id_prod_demand As String = "-1"
    Public Shared dt As DataTable
    Public Shared rmt As String = "-1"
    Public Shared is_pre As String = "-1"
    Public Shared is_hidden_mark As String = "-1"
    Public Shared id_report_status As String = "-1"

    Private Sub ReportProdDemandNew_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCDesign.DataSource = dt
        If is_hidden_mark = "-1" Then
            If is_pre = "1" Then
                pre_load_mark_horz_pd(rmt, id_prod_demand, "2", "2", XrTable1)
            Else
                load_mark_horz(rmt, id_prod_demand, "2", "1", XrTable1)
            End If
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
        WHERE rm.id_report=" + id_prod_demand + " AND rm.report_mark_type=" + rmt + " AND rm.id_mark=2
        ORDER BY rm.id_report_mark DESC LIMIT 1 "
        Dim dpd As DataTable = execute_query(qpd, -1, True, "", "", "", "")
        DataSource = dpd

        'find updated created/approve date in revision
        Dim id_pdr As String = ""
        Try
            id_pdr = execute_query("SELECT pdr.id_prod_demand_rev 
        FROM tb_prod_demand_rev pdr
        WHERE pdr.id_prod_demand=" + id_prod_demand + " AND pdr.id_report_status=6
        ORDER BY pdr.id_prod_demand_rev DESC LIMIT 1 ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_pdr = ""
        End Try
        If id_pdr <> "" Then
            Dim query_date_rev As String = "SELECT UPPER(DATE_FORMAT(rm.report_mark_datetime, '%d %M %Y')) AS `approved_date` 
            FROM tb_report_mark rm 
            WHERE rm.id_report=" + id_pdr + " AND (rm.report_mark_type=143 OR rm.report_mark_type=144 OR rm.report_mark_type=145)  AND rm.id_mark=2
            ORDER BY rm.id_report_mark DESC LIMIT 1 "
            Dim data_date_rev As DataTable = execute_query(query_date_rev, -1, True, "", "", "", "")
            LabelApprovedDate.Text = Date.Parse(data_date_rev.Rows(0)("approved_date").ToString).ToString("dd MMMM yyyy").ToUpper
        End If
    End Sub

    Private Sub GVDesign_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDesign.CustomColumnDisplayText
        If e.Column.FieldName = "No_desc_report_column" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Dim tot_cost As Decimal
    Dim tot_prc As Decimal
    Dim tot_cost_grp As Decimal
    Dim tot_prc_grp As Decimal
    Private Sub GVDesign_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVDesign.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            tot_cost = 0.0
            tot_prc = 0.0
            tot_cost_grp = 0.0
            tot_prc_grp = 0.0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST NON ADDITIONAL_add_report_column").ToString, "0.00"))
            Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMOUNT NON ADDITIONAL_add_report_column"), "0.00"))
            Select Case summaryID
                Case 46
                    tot_cost += cost
                    tot_prc += prc
                Case 47
                    tot_cost_grp += cost
                    tot_prc_grp += prc
            End Select
        End If

        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case 46 'total summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc / tot_cost
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case 47 'group summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc_grp / tot_cost_grp
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
            End Select
        End If
    End Sub
End Class