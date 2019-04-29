Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportMatMRS
    Public Shared id_mrs As String = "-1"
    Public id_wo As String = "-1"
    Public id_prod_order As String = "-1"
    Public id_comp_req_from As String = "-1"
    Public id_comp_req_to As String = "-1"
    Public id_report_status_g As String = "-1"
    Public mrs_type As String = "1" '1= other ; 2= mat wo\
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
        Dim query As String = String.Format("SELECT *,DATE_FORMAT(prod_order_mrs_date,'%Y-%m-%d') as prod_order_mrs_datex FROM tb_prod_order_mrs WHERE id_prod_order_mrs = '{0}'", id_mrs)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        mrs_type = data.Rows(0)("mrs_type").ToString
        id_comp_req_from = data.Rows(0)("id_comp_contact_req_from").ToString
        id_comp_req_to = data.Rows(0)("id_comp_contact_req_to").ToString

        LMRSNumber.Text = data.Rows(0)("prod_order_mrs_number").ToString

        LReqFromName.Text = get_company_x(get_id_company(id_comp_req_from), "1")
        'TECompCode.Text = get_company_x(get_id_company(id_comp_req_from), "2")
        LToName.Text = get_company_x(get_id_company(id_comp_req_to), "1")
        'TECompToCode.Text = get_company_x(get_id_company(id_comp_req_to), "2")

        LMRSDate.Text = view_date_from(data.Rows(0)("prod_order_mrs_datex").ToString, 0)

        LNote.Text = data.Rows(0)("prod_order_mrs_note").ToString
        If mrs_type = "1" Then 'other
            LWONo.Visible = False
            LLWONo.Visible = False
            LTWONo.Visible = False
            '
            LLMRSType.Text = "Other"
        Else 'mat wo
            id_wo = data.Rows(0)("id_mat_wo").ToString
            query = "SELECT mat_wo_number FROM tb_mat_wo WHERE id_mat_wo='" & id_wo & "'"
            data = execute_query(query, -1, True, "", "", "", "")

            LWONo.Text = data.Rows(0)("mat_wo_number").ToString
        End If
    End Sub

    Private Sub ReportMatWO_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        pre_load_mark_horz("44", id_mrs, "2", "2", XrTable1)
    End Sub
End Class