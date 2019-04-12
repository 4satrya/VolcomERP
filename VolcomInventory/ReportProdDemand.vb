Imports DevExpress.XtraReports.UI

Public Class ReportProdDemand
    Public Shared id_prod_demand As String
    Public Shared prod_demand_number As String
    Public Shared season As String
    Public Shared phase As String
    Public Shared reff As String
    Public Shared dt As DataTable
    Public Shared coba As String = "-1"
    Public frm_origin As String = "-1"
   
   
    'Xtra Report Before Print
    Private Sub ReportProdDemand_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GridControl1.DataSource = dt

        LabelPD.Text = prod_demand_number
        LabelSeason.Text = season
        LabelReff.Text = reff
        LabelPhase.Text = phase

        load_mark_horz("9", id_prod_demand, "2", "1", XrTable1)
    End Sub

    Private Sub BandedGridView1_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles BandedGridView1.CustomColumnDisplayText
        If e.Column.FieldName = "No_desc_report_column" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BandedGridView1_CustomSummaryCalculate(ByVal sender As System.Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles BandedGridView1.CustomSummaryCalculate
        'diubah ke formproddemand ngambil values GVnya :p

        If frm_origin = "-1" Then
            Dim gv As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(FormProdDemand.BGVProduct, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)
            If (Not e.IsGroupSummary) Then Return
            Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
            item = e.Item
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize AndAlso item.FieldName.ToString = "MARK UP_add_report_column" Then
                Dim summary_gr As Double = 0.0
                Try
                    summary_gr = gv.GetGroupSummaryValue(e.GroupRowHandle, CType(gv.GroupSummary("'TOTAL AMOUNT NON ADDITIONAL_add_report_column'"), DevExpress.XtraGrid.GridGroupSummaryItem)) / gv.GetGroupSummaryValue(e.GroupRowHandle, CType(gv.GroupSummary("'TOTAL COST NON ADDITIONAL_add_report_column'"), DevExpress.XtraGrid.GridGroupSummaryItem))
                Catch ex As Exception
                End Try
                e.TotalValue = summary_gr
            End If
        ElseIf frm_origin = "FormProdDemandSingle" Then
            'Dim gv As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(FormProdDemandSingle.GVDesign, DevExpress.XtraGrid.Views.my)
            'If (Not e.IsGroupSummary) Then Return
            'Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
            'item = e.Item
            'If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize AndAlso item.FieldName.ToString = "MARK UP_add_report_column" Then
            '    Dim summary_gr As Double = 0.0
            '    Try
            '        summary_gr = gv.GetGroupSummaryValue(e.GroupRowHandle, CType(gv.GroupSummary("TOTAL AMOUNT NON ADDITIONAL_add_report_column"), DevExpress.XtraGrid.GridGroupSummaryItem)) / gv.GetGroupSummaryValue(e.GroupRowHandle, CType(gv.GroupSummary("TOTAL COST NON ADDITIONAL_add_report_column"), DevExpress.XtraGrid.GridGroupSummaryItem))
            '    Catch ex As Exception
            '    End Try
            '    e.TotalValue = summary_gr
            'End If
        End If


    End Sub

End Class