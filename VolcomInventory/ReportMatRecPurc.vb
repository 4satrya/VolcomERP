Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportMatRecPurc
    Public Shared id_order As String = "-1"
    Public Shared id_receive As String = "-1"
    Public Shared id_comp_from As String = "-1"
    Public Shared id_comp_to As String = "-1"
    Public Shared is_pre As String = "-1"
    Sub view_list_rec()
        Dim query = "CALL view_purc_rec_mat_det('" & id_receive & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        query = "CALL view_purc_rec_mat_det_pcs('" & id_receive & "')"
        Dim data_piece As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim ds As New DataSet()
        ds.Tables.AddRange(New DataTable() {data, data_piece})
        ds.Relations.Add("Detail", data.Columns("id_mat_det"), data_piece.Columns("id_mat_det"))

        GCListPurchase.DataSource = data
        ExpandAllRows(GVListPurchase)
    End Sub
    Public Sub ExpandAllRows(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView)
        View.BeginUpdate()
        Try
            Dim dataRowCount As Integer = View.DataRowCount
            Dim rHandle As Integer
            For rHandle = 0 To dataRowCount - 1
                View.SetMasterRowExpanded(rHandle, True)
            Next
        Finally
            View.EndUpdate()
        End Try
    End Sub
    Private Sub GVListPurchase_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub ReportMatRecPurc_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim order_created As String
        Dim query = "SELECT a.id_report_status,a.mat_purc_rec_note,b.id_comp_contact_to as id_comp_from,b.id_mat_purc,a.id_comp_contact_to as id_comp_to,g.season,a.id_mat_purc_rec,a.mat_purc_rec_number,DATE_FORMAT(b.mat_purc_date,'%Y-%m-%d') as mat_purc_datex,b.mat_purc_lead_time,a.delivery_order_date,a.delivery_order_number,b.mat_purc_number,DATE_FORMAT(a.mat_purc_rec_date,'%Y-%m-%d') AS mat_purc_rec_date, f.comp_name AS comp_from,d.comp_name AS comp_to "
        query += "FROM tb_mat_purc_rec a INNER JOIN tb_mat_purc b ON a.id_mat_purc=b.id_mat_purc "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact=b.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp f ON f.id_comp=e.id_comp "
        query += "INNER JOIN tb_season_delivery h ON b.id_delivery=h.id_delivery "
        query += "INNER JOIN tb_season g ON g.id_season=h.id_season WHERE a.id_mat_purc_rec='" & id_receive & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        LPONumber.Text = data.Rows(0)("mat_purc_number").ToString
        LDONumber.Text = data.Rows(0)("delivery_order_number").ToString
        LRecNumber.Text = data.Rows(0)("mat_purc_rec_number").ToString

        id_comp_from = data.Rows(0)("id_comp_from").ToString
        LFromName.Text = data.Rows(0)("comp_from").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        LToName.Text = data.Rows(0)("comp_to").ToString

        order_created = data.Rows(0)("mat_purc_datex").ToString
        LPODate.Text = view_date_from(order_created, 0)

        LRecDate.Text = "DATE : " & view_date_from(data.Rows(0)("mat_purc_rec_date").ToString, 0)
        LDODate.Text = Date.Parse(data.Rows(0)("delivery_order_date").ToString).ToString("dd/MM/yyyy")

        LNote.Text = data.Rows(0)("mat_purc_rec_note").ToString

        view_list_rec()

        If is_pre = "1" Then
            pre_load_mark_horz("16", id_receive, "2", "2", XrTable1)
        Else
            load_mark_horz("16", id_receive, "2", "1", XrTable1)
        End If

    End Sub

    Private Sub PageFooter_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint
        LTotalReceived.Text = GVListPurchase.Columns("mat_purc_rec_det_qty").SummaryText.ToString
    End Sub
End Class