Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportProductionMRS
    Public Shared id_mrs As String = "-1"
    Public Shared id_comp_req_from As String = "-1"
    Public Shared id_comp_req_to As String = "-1"
    Public Shared is_pre As String = "-1"
    Sub view_mrs()
        Try
            Dim query As String
            query = "CALL view_prod_order_mrs('" & id_mrs & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMat.DataSource = data
            '
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMat.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        view_mrs()
    End Sub

    Private Sub TopMargin_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles TopMargin.BeforePrint
        Dim query As String = String.Format("SELECT po.prod_order_number,dsg.`design_display_name`,mrs.prod_order_mrs_number,mrs.id_prod_order,mrs.id_prod_order_wo,mrs.prod_order_mrs_note,mrs.id_report_status,mrs.id_comp_contact_req_from,mrs.id_comp_contact_req_to,DATE_FORMAT(mrs.prod_order_mrs_date,'%Y-%m-%d') AS prod_order_mrs_datex 
FROM tb_prod_order_mrs mrs
INNER JOIN tb_prod_order po ON mrs.id_prod_order=po.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON po.id_prod_demand_design=pdd.id_prod_demand_design
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
WHERE id_prod_order_mrs = '{0}'", id_mrs)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows(0)("id_prod_order_wo").ToString = "" Then
            LWONo.Visible = False
            LLWONo.Visible = False
            LTWONo.Visible = False
        Else
            LWONo.Text = get_prod_wo_x(data.Rows(0)("id_prod_order_wo").ToString, "1")
        End If

        If data.Rows(0)("id_prod_order").ToString = "" Then
            LPONo.Visible = False
            LLPoNo.Visible = False
            LTPONo.Visible = False
            '
            LDesignName.Visible = False
            LLDesign.Visible = False
            LTDesign.Visible = False
            '
            LLMRSType.Text = "Other"
        Else
            LPONo.Text = data.Rows(0)("prod_order_number").ToString
            LDesignName.Text = data.Rows(0)("design_display_name").ToString
        End If

        id_comp_req_from = data.Rows(0)("id_comp_contact_req_from").ToString
        id_comp_req_to = data.Rows(0)("id_comp_contact_req_to").ToString

        LReqFromName.Text = get_company_x(get_id_company(id_comp_req_from), "1")
        LToName.Text = get_company_x(get_id_company(id_comp_req_to), "1")

        LMRSNumber.Text = data.Rows(0)("prod_order_mrs_number").ToString
        LMRSDate.Text = view_date_from(data.Rows(0)("prod_order_mrs_datex").ToString, 0)
        LNote.Text = data.Rows(0)("prod_order_mrs_note").ToString
        LPONo.Text = data.Rows(0)("prod_order_number").ToString
    End Sub

    Private Sub ReportMatWO_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        If is_pre = "1" Then
            pre_load_mark_horz("29", id_mrs, "2", "1", XrTable1)
        Else
            load_mark_horz("29", id_mrs, "2", "1", XrTable1)
        End If
    End Sub
End Class