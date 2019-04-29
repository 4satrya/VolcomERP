Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI
Public Class ReportSampleReceive
    Public Shared id_order As String = "-1"
    Public Shared id_receive As String = "-1"
    Public Shared id_comp_from As String = "-1"
    Public Shared id_comp_to As String = "-1"
    Public Shared id_pre As String = "-1"
    Sub view_list_rec()
        Dim query = "CALL view_purc_rec_sample_det('" & id_receive & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GClistPurchase.DataSource = data
    End Sub
    Private Sub GVListPurchase_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub ReportSampleReceive_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query = "SELECT a.id_report_status,a.sample_purc_rec_note,b.id_comp_contact_to as id_comp_from,b.id_sample_purc,a.id_comp_contact_to as id_comp_to,g.season_orign,a.id_sample_purc_rec,a.sample_purc_rec_number,b.sample_purc_date as sample_purc_datex,b.sample_purc_lead_time,a.delivery_order_date AS delivery_order_date,a.delivery_order_number,b.sample_purc_number,a.sample_purc_rec_date AS sample_purc_rec_date, f.comp_name AS comp_from,d.comp_name AS comp_to "
        query += "FROM tb_sample_purc_rec a INNER JOIN tb_sample_purc b ON a.id_sample_purc=b.id_sample_purc "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact=b.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp f ON f.id_comp=e.id_comp "
        query += "INNER JOIN tb_season_orign g ON g.id_season_orign=b.id_season_orign WHERE a.id_sample_purc_rec='" & id_receive & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        LPONumber.Text = data.Rows(0)("sample_purc_number").ToString
        LDONumber.Text = data.Rows(0)("delivery_order_number").ToString
        LRecNumber.Text = data.Rows(0)("sample_purc_rec_number").ToString

        id_comp_from = data.Rows(0)("id_comp_from").ToString
        LFromName.Text = data.Rows(0)("comp_from").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        LToName.Text = data.Rows(0)("comp_to").ToString

        LPODate.Text = Date.Parse(data.Rows(0)("sample_purc_datex").ToString).ToString("dd MMMM yyyy")
        LRecDate.Text = Date.Parse(data.Rows(0)("sample_purc_rec_date").ToString).ToString("dd MMMM yyyy")
        LDODate.Text = Date.Parse(data.Rows(0)("delivery_order_date").ToString).ToString("dd MMMM yyyy")

        LNote.Text = data.Rows(0)("sample_purc_rec_note").ToString

        view_list_rec()

        If id_pre = "-1" Then
            load_mark_horz("2", id_receive, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("2", id_receive, "2", "2", XrTable1)
        End If

    End Sub

    Private Sub PageFooter_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint
        LTotalReceived.Text = GVListPurchase.Columns("sample_purc_rec_det_qty").SummaryText.ToString
    End Sub
End Class