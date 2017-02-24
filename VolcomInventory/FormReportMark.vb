Public Class FormReportMark
    Public not_allow_complete As String = "-1"
    Public not_allow_cancelled As String = "-1"
    Public report_mark_type As String = "-1"
    Public id_report As String = "-1"
    Public id_report_status_report As String = "-1"
    Public form_origin As String
    Public is_view As String = "-1"
    Public is_disabled_set_stt = "-1"

    Public report_number As String = ""
    Public is_view_finalize As String = "-1"
    '
    ' report_mark_type
    ' WARNING : if want to add new report type, also add on the tb_lookup_report_mark_type ^_-
    ' is_view = "1" only for workplace (FormView*)

    Private Sub FormReportMark_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'checkFormAccessSingle(Name)
        act_load()
    End Sub
    Sub act_load()
        Dim query As String = ""
        query = "SELECT COUNT(id_report_mark) FROM tb_report_mark WHERE id_report='" + id_report + "' AND report_mark_type='" + report_mark_type + "'"
        Dim jml As Integer = execute_query(query, 0, True, "", "", "", "")
        If jml = 0 Then 'not submitted yet
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Form is not submitted yet, do you want to submit this form ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                submit_who_prepared(report_mark_type, id_report, id_user)

                infoCustom("Form submitted.")
                act_load()
            Else
                Opacity = 0
                Close()
            End If
        Else 'normal
            view_mark()
            view_report_status(LEReportStatus)
            If is_view = "1" Then
                GroupControl2.Visible = False
            Else
                GroupControl2.Visible = True
            End If
            If is_disabled_set_stt = "1" Then
                LEReportStatus.Enabled = False
                BSetStatus.Enabled = False
            End If

            'view finalize
            If is_view_finalize = "1" Then
                view_mark_final()
                If GVFinal.RowCount > 0 Then
                    GroupControl3.Visible = True
                End If
            End If
        End If
    End Sub
    Private Sub view_report_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status WHERE id_report_status!='7' "
        If not_allow_complete = "1" Then
            query += "AND id_report_status!='6' "
        End If
        If not_allow_cancelled = "1" Then
            query += "AND id_report_status!='5' "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "report_status"
        lookup.Properties.ValueMember = "id_report_status"

        If report_mark_type = "1" Then
            'sample purchase
            query = String.Format("SELECT id_report_status,sample_purc_number as report_number FROM tb_sample_purc WHERE id_sample_purc = '{0}'", id_report)
        ElseIf report_mark_type = "2" Then
            'sample receive
            query = String.Format("SELECT id_report_status,sample_purc_rec_number as report_number FROM tb_sample_purc_rec WHERE id_sample_purc_rec = '{0}'", id_report)
        ElseIf report_mark_type = "3" Then
            'sample PL
            query = String.Format("SELECT id_report_status,pl_sample_purc_number as report_number FROM tb_pl_sample_purc WHERE id_pl_sample_purc = '{0}'", id_report)
        ElseIf report_mark_type = "4" Then
            'sample PR
            query = String.Format("SELECT id_report_status,pr_sample_purc_number as report_number FROM tb_pr_sample_purc WHERE id_pr_sample_purc = '{0}'", id_report)
        ElseIf report_mark_type = "5" Then
            'sample ret out
            query = String.Format("SELECT id_report_status,sample_purc_ret_in_number as report_number FROM tb_sample_purc_ret_out WHERE id_sample_purc_ret_out = '{0}'", id_report)
        ElseIf report_mark_type = "6" Then
            'sample ret in
            query = String.Format("SELECT id_report_status,sample_purc_ret_out_number as report_number FROM tb_sample_purc_ret_in WHERE id_sample_purc_ret_in = '{0}'", id_report)
        ElseIf report_mark_type = "7" Then
            'sample receipt
            query = String.Format("SELECT (id_report_status_rec) AS id_report_status FROM tb_pl_sample_purc WHERE id_pl_sample_purc = '{0}'", id_report)
        ElseIf report_mark_type = "8" Then
            'bom
            query = String.Format("SELECT id_report_status FROM tb_bom WHERE id_bom = '{0}'", id_report)
        ElseIf report_mark_type = "9" Or report_mark_type = "80" Or report_mark_type = "81" Then
            'prod demand
            query = String.Format("SELECT id_report_status,(prod_demand_number) AS report_number FROM tb_prod_Demand WHERE id_prod_demand = '{0}'", id_report)
        ElseIf report_mark_type = "10" Then
            'sample PL
            query = String.Format("SELECT id_report_status,pl_sample_del_number as report_number FROM tb_pl_sample_del WHERE id_pl_sample_del = '{0}'", id_report)
        ElseIf report_mark_type = "11" Then
            'sample Requisition
            query = String.Format("SELECT id_report_status, sample_requisition_number as report_number FROM tb_sample_requisition WHERE id_sample_requisition = '{0}'", id_report)
        ElseIf report_mark_type = "12" Then
            'sample plan
            query = String.Format("SELECT id_report_status,sample_plan_number as report_number FROM tb_sample_plan WHERE id_sample_plan = '{0}'", id_report)
        ElseIf report_mark_type = "13" Then
            'material purchasing
            query = String.Format("SELECT id_report_status,mat_purc_number as report_number FROM tb_mat_purc WHERE id_mat_purc = '{0}'", id_report)
        ElseIf report_mark_type = "14" Then
            'sample Return
            query = String.Format("SELECT id_report_status,sample_return_number as report_number FROM tb_sample_return WHERE id_sample_return = '{0}'", id_report)
        ElseIf report_mark_type = "15" Then
            'material wo
            query = String.Format("SELECT id_report_status,mat_wo_number as report_number FROM tb_mat_wo WHERE id_mat_wo = '{0}'", id_report)
        ElseIf report_mark_type = "16" Then
            'receive material purchase
            query = String.Format("SELECT id_report_status,mat_purc_rec_number as report_number FROM tb_mat_purc_rec WHERE id_mat_purc_rec = '{0}'", id_report)
        ElseIf report_mark_type = "17" Then
            'receive material wo
            query = String.Format("SELECT id_report_status,mat_wo_rec_number as report_number FROM tb_mat_wo_rec WHERE id_mat_wo_rec = '{0}'", id_report)
        ElseIf report_mark_type = "18" Then
            'Return Material Out
            query = String.Format("SELECT id_report_status,mat_purc_ret_out_number as report_number FROM tb_mat_purc_ret_out WHERE id_mat_purc_ret_out = '{0}'", id_report)
        ElseIf report_mark_type = "19" Then
            'Return Material In
            query = String.Format("SELECT id_report_status,mat_purc_ret_in_number as report_number FROM tb_mat_purc_ret_in WHERE id_mat_purc_ret_in = '{0}'", id_report)
        ElseIf report_mark_type = "20" Then
            'SAMPle Adj In
            query = String.Format("SELECT id_report_status,adj_in_sample_number as report_number FROM tb_adj_in_sample WHERE id_adj_in_sample = '{0}'", id_report)
        ElseIf report_mark_type = "21" Then
            'SAMPle Adj Out
            query = String.Format("SELECT id_report_status,adj_out_sample_number as report_number FROM tb_adj_out_sample WHERE id_adj_out_sample = '{0}'", id_report)
        ElseIf report_mark_type = "22" Then
            'Production Order
            query = String.Format("SELECT id_report_status FROM tb_prod_order WHERE id_prod_order = '{0}'", id_report)
        ElseIf report_mark_type = "23" Then
            'Production Work Order
            query = String.Format("SELECT id_report_status,prod_order_wo_number as report_number FROM tb_prod_order_wo WHERE id_prod_order_wo = '{0}'", id_report)
        ElseIf report_mark_type = "24" Then
            'Material PO PR
            query = String.Format("SELECT id_report_status,pr_mat_purc_number as report_number FROM tb_pr_mat_purc WHERE id_pr_mat_purc = '{0}'", id_report)
        ElseIf report_mark_type = "25" Then
            'Material WO PR
            query = String.Format("SELECT id_report_status,pr_mat_wo_number as report_number FROM tb_pr_mat_wo WHERE id_pr_mat_wo = '{0}'", id_report)
        ElseIf report_mark_type = "26" Then
            'Mat Adj In
            query = String.Format("SELECT id_report_status,adj_in_mat_number as report_number FROM tb_adj_in_mat WHERE id_adj_in_mat = '{0}'", id_report)
        ElseIf report_mark_type = "27" Then
            'Mat Adj Out
            query = String.Format("SELECT id_report_status,adj_out_mat_number as report_number FROM tb_adj_out_mat WHERE id_adj_out_mat = '{0}'", id_report)
        ElseIf report_mark_type = "28" Then
            'Production rec
            query = String.Format("SELECT id_report_status,prod_order_rec_number as report_number FROM tb_prod_order_rec WHERE id_prod_order_rec = '{0}'", id_report)
        ElseIf report_mark_type = "29" Then
            'Production MRS
            query = String.Format("SELECT id_report_status FROM tb_prod_order_mrs WHERE id_prod_order_mrs = '{0}'", id_report)
        ElseIf report_mark_type = "30" Then
            'PL MRS Production
            query = String.Format("SELECT id_report_status,pl_mrs_number as report_number FROM tb_pl_mrs WHERE id_pl_mrs = '{0}'", id_report)
        ElseIf report_mark_type = "31" Then
            'Production ret out
            query = String.Format("SELECT id_report_status,prod_order_ret_out_number as report_number FROM tb_prod_order_ret_out WHERE id_prod_order_ret_out = '{0}'", id_report)
        ElseIf report_mark_type = "32" Then
            'Production ret in
            query = String.Format("SELECT id_report_status,prod_order_ret_in_number as report_number FROM tb_prod_order_ret_in WHERE id_prod_order_ret_in = '{0}'", id_report)
        ElseIf report_mark_type = "33" Then
            'PL FG To WH
            query = String.Format("SELECT id_report_status,pl_prod_order_number as report_number FROM tb_pl_prod_order WHERE id_pl_prod_order = '{0}'", id_report)
        ElseIf report_mark_type = "34" Then
            'Inv Mat PL MRS
            query = String.Format("SELECT id_report_status,inv_pl_mrs_number as report_number FROM tb_inv_pl_mrs WHERE id_inv_pl_mrs = '{0}'", id_report)
        ElseIf report_mark_type = "35" Then
            'Inv Mat PL MRS
            query = String.Format("SELECT id_report_status,inv_pl_mrs_ret_number as report_number FROM tb_inv_pl_mrs_ret WHERE id_inv_pl_mrs_ret = '{0}'", id_report)
        ElseIf report_mark_type = "36" Then
            'Entry Journal
            query = String.Format("SELECT id_report_status FROM tb_a_acc_trans WHERE id_acc_trans = '{0}'", id_report)
        ElseIf report_mark_type = "37" Then
            'REC PL FG To WH
            query = String.Format("SELECT id_report_status,pl_prod_order_rec_number as report_number FROM tb_pl_prod_order_rec WHERE id_pl_prod_order_rec = '{0}'", id_report)
        ElseIf report_mark_type = "39" Then
            'SALES ORDER
            query = String.Format("SELECT id_report_status FROM tb_sales_order WHERE id_sales_order = '{0}'", id_report)
        ElseIf report_mark_type = "40" Then
            'Entry Journal Adjustment
            query = String.Format("SELECT id_report_status FROM tb_a_acc_trans_adj WHERE id_acc_trans_adj = '{0}'", id_report)
        ElseIf report_mark_type = "41" Then
            'FG Adj In
            query = String.Format("SELECT id_report_status,adj_in_fg_number as report_number FROM tb_adj_in_fg WHERE id_adj_in_fg = '{0}'", id_report)
        ElseIf report_mark_type = "42" Then
            'FG Adj Out
            query = String.Format("SELECT id_report_status,adj_out_fg_number as report_number FROM tb_adj_out_fg WHERE id_adj_out_fg = '{0}'", id_report)
        ElseIf report_mark_type = "43" Then
            'SALES DELIVERY ORDER
            query = String.Format("SELECT id_report_status,pl_sales_order_del_number as report_number FROM tb_pl_sales_order_del WHERE id_pl_sales_order_del = '{0}'", id_report)
        ElseIf report_mark_type = "44" Then
            'Mat MRS
            query = String.Format("SELECT id_report_status FROM tb_prod_order_mrs WHERE id_prod_order_mrs = '{0}'", id_report)
        ElseIf report_mark_type = "45" Then
            'SALES RETURN ORDER
            query = String.Format("SELECT id_report_status, sales_return_order_number AS report_number FROM tb_sales_return_order WHERE id_sales_return_order = '{0}'", id_report)
        ElseIf report_mark_type = "46" Then
            'SALES RETURN
            query = String.Format("SELECT id_report_status,sales_return_number as report_number FROM tb_sales_return WHERE id_sales_return = '{0}'", id_report)
        ElseIf report_mark_type = "47" Then
            'Mat return Prod
            query = String.Format("SELECT id_report_status,mat_prod_ret_in_number as report_number FROM tb_mat_prod_ret_in WHERE id_mat_prod_ret_in = '{0}'", id_report)
        ElseIf report_mark_type = "48" Then
            'SALES VIRTUAL POS
            query = String.Format("SELECT id_report_status,sales_pos_number as report_number FROM tb_sales_pos WHERE id_sales_pos = '{0}'", id_report)
        ElseIf report_mark_type = "49" Then
            'SALES RETURN QC
            query = String.Format("SELECT id_report_status,sales_return_qc_number as report_number FROM tb_sales_return_qc WHERE id_sales_return_qc = '{0}'", id_report)
        ElseIf report_mark_type = "50" Then
            'PR Prod Order
            query = String.Format("SELECT id_report_status,pr_prod_order_number as report_number FROM tb_pr_prod_order WHERE id_pr_prod_order = '{0}'", id_report)
        ElseIf report_mark_type = "51" Then
            'SALES INVOICE
            query = String.Format("SELECT id_report_status,sales_invoice_number as report_number FROM tb_sales_invoice WHERE id_sales_invoice = '{0}'", id_report)
        ElseIf report_mark_type = "52" Then
            'Stok Opname mat
            query = String.Format("SELECT id_report_status,mat_so_number as report_number FROM tb_mat_so WHERE id_mat_so = '{0}'", id_report)
        ElseIf report_mark_type = "53" Then
            'FG SO STORE
            query = String.Format("SELECT id_report_status,fg_so_store_number as report_number FROM tb_fg_so_store WHERE id_fg_so_store = '{0}'", id_report)
        ElseIf report_mark_type = "54" Then
            'FG MISSING
            query = String.Format("SELECT id_report_status,sales_pos_number as report_number FROM tb_sales_pos WHERE id_sales_pos = '{0}'", id_report)
        ElseIf report_mark_type = "55" Then
            'FG MISSING INVOICE
            query = String.Format("SELECT id_report_status,fg_missing_invoice_number as report_number FROM tb_fg_missing_invoice WHERE id_fg_missing_invoice = '{0}'", id_report)
        ElseIf report_mark_type = "56" Then
            'FG SO WH
            query = String.Format("SELECT id_report_status,fg_so_wh_number as report_number FROM tb_fg_so_wh WHERE id_fg_so_wh = '{0}'", id_report)
        ElseIf report_mark_type = "57" Then
            'FG TRF
            query = String.Format("SELECT id_report_status,fg_trf_number as report_number FROM tb_fg_trf WHERE id_fg_trf = '{0}'", id_report)
        ElseIf report_mark_type = "58" Then
            'FG TRF REC
            query = String.Format("SELECT (id_report_status_rec) AS id_report_status,fg_trf_number as report_number FROM tb_fg_trf WHERE id_fg_trf = '{0}'", id_report)
        ElseIf report_mark_type = "60" Then
            'SAMPLE DEL
            query = String.Format("SELECT id_report_status, sample_del_number as report_number FROM tb_sample_del WHERE id_sample_del = '{0}'", id_report)
        ElseIf report_mark_type = "61" Then
            'SAMPLE DEL REC
            query = String.Format("SELECT id_report_status, sample_del_rec_number as report_number FROM tb_sample_del_rec WHERE id_sample_del_rec = '{0}'", id_report)
        ElseIf report_mark_type = "62" Then
            'SO SAMPLE
            query = String.Format("SELECT id_report_status, sample_order_number as report_number FROM tb_sample_order WHERE id_sample_order = '{0}'", id_report)
        ElseIf report_mark_type = "63" Then
            'DELIVERY ORDER SAMPLE FOR SALES
            query = String.Format("SELECT id_report_status, pl_sample_order_del_number as report_number FROM tb_pl_sample_order_del WHERE id_pl_sample_order_del = '{0}'", id_report)
        ElseIf report_mark_type = "64" Then
            'SAMPLE SO
            query = String.Format("SELECT id_report_status, sample_so_number as report_number FROM tb_sample_so WHERE id_sample_so = '{0}'", id_report)
        ElseIf report_mark_type = "65" Then
            'FG CODE REPLACEMENT STORE
            query = String.Format("SELECT id_report_status, fg_code_replace_store_number as report_number FROM tb_fg_code_replace_store WHERE id_fg_code_replace_store = '{0}'", id_report)
        ElseIf report_mark_type = "66" Then
            'SALES CREDIT NOTE
            query = String.Format("SELECT id_report_status,sales_pos_number as report_number FROM tb_sales_pos WHERE id_sales_pos = '{0}'", id_report)
        ElseIf report_mark_type = "67" Then
            'MISSING CREDIT NOTE STORE
            query = String.Format("SELECT id_report_status,sales_pos_number as report_number FROM tb_sales_pos WHERE id_sales_pos = '{0}'", id_report)
        ElseIf report_mark_type = "68" Then
            'FG CODE REPLACEMENT WH
            query = String.Format("SELECT id_report_status, fg_code_replace_wh_number as report_number FROM tb_fg_code_replace_wh WHERE id_fg_code_replace_wh = '{0}'", id_report)
        ElseIf report_mark_type = "69" Then
            'FG Write Off
            query = String.Format("SELECT id_report_status,fg_woff_number as report_number FROM tb_fg_woff WHERE id_fg_woff = '{0}'", id_report)
        ElseIf report_mark_type = "70" Then
            'FG PROPOSE PRICE
            query = String.Format("SELECT id_report_status,fg_propose_price_number as report_number FROM tb_fg_propose_price WHERE id_fg_propose_price = '{0}'", id_report)
        ElseIf report_mark_type = "72" Then
            'QC Adj In
            query = String.Format("SELECT id_report_status,prod_order_qc_adj_in_number as report_number FROM tb_prod_order_qc_adj_in WHERE id_prod_order_qc_adj_in = '{0}'", id_report)
        ElseIf report_mark_type = "73" Then
            'QC Adj Out
            query = String.Format("SELECT id_report_status,prod_order_qc_adj_out_number as report_number FROM tb_prod_order_qc_adj_out WHERE id_prod_order_qc_adj_out = '{0}'", id_report)
        ElseIf report_mark_type = "75" Then
            'ANALISIS NEW PRODUK
            query = String.Format("SELECT id_report_status,fg_so_reff_number as report_number FROM tb_fg_so_reff WHERE id_fg_so_reff = '{0}'", id_report)
        ElseIf report_mark_type = "76" Then
            'Promo
            query = String.Format("SELECT id_report_status,sales_pos_number as report_number FROM tb_sales_pos WHERE id_sales_pos = '{0}'", id_report)
        ElseIf report_mark_type = "79" Then
            'BOM Approve
            query = String.Format("SELECT id_report_status,'-' as report_number FROM tb_bom_approve WHERE id_bom_approve = '{0}'", id_report)
        ElseIf report_mark_type = "82"
            'PRICE EXCEL
            query = String.Format("SELECT id_report_status,fg_price_number as report_number FROM tb_fg_price WHERE id_fg_price = '{0}'", id_report)
        ElseIf report_mark_type = "85"
            'SAMPLE PL
            query = String.Format("SELECT id_report_status,sample_pl_number as report_number FROM tb_sample_pl WHERE id_sample_pl = '{0}'", id_report)
        ElseIf report_mark_type = "86"
            'PRICE SAMPLE EXCEL
            query = String.Format("SELECT id_report_status,sample_price_number as report_number FROM tb_sample_price WHERE id_sample_price = '{0}'", id_report)
        ElseIf report_mark_type = "87"
            'INVENTORY ALLOCATION
            query = String.Format("SELECT id_report_status, fg_wh_alloc_number as report_number FROM tb_fg_wh_alloc WHERE id_fg_wh_alloc = '{0}'", id_report)
        ElseIf report_mark_type = "88"
            'GENERATE SO
            query = String.Format("SELECT id_report_status, sales_order_gen_reff as report_number FROM tb_sales_order_gen WHERE id_sales_order_gen = '{0}'", id_report)
        ElseIf report_mark_type = "89"
            'Return Internal Sale
            query = String.Format("SELECT id_report_status, sample_pl_ret_number as report_number FROM tb_sample_pl_ret WHERE id_sample_pl_ret = '{0}'", id_report)
        ElseIf report_mark_type = "91" Then
            'REPAIR
            query = String.Format("SELECT id_report_status, fg_repair_number as report_number FROM tb_fg_repair WHERE id_fg_repair = '{0}'", id_report)
        ElseIf report_mark_type = "92" Then
            'REPAIR REC
            query = String.Format("SELECT id_report_status, fg_repair_number_rec as report_number FROM tb_fg_repair_rec WHERE id_fg_repair_rec = '{0}'", id_report)
        ElseIf report_mark_type = "93" Then
            'REPAIR RETURN
            query = String.Format("SELECT id_report_status, fg_repair_return_number as report_number FROM tb_fg_repair_return WHERE id_fg_repair_return = '{0}'", id_report)
        ElseIf report_mark_type = "94" Then
            'REPAIR RETURN REC
            query = String.Format("SELECT id_report_status, fg_repair_return_rec_number as report_number FROM tb_fg_repair_return_rec WHERE id_fg_repair_return_rec = '{0}'", id_report)
        ElseIf report_mark_type = "95" Then
            'Leave Propose
            query = String.Format("SELECT id_report_status, emp_leave_number as report_number FROM tb_emp_leave WHERE id_emp_leave = '{0}'", id_report)
        ElseIf report_mark_type = "96" Then
            'Leave Propose need management approval
            query = String.Format("SELECT id_report_status, emp_leave_number as report_number FROM tb_emp_leave WHERE id_emp_leave = '{0}'", id_report)
        ElseIf report_mark_type = "97" Then
            'DP propose
            query = String.Format("SELECT id_report_status, dp_number as report_number FROM tb_emp_dp WHERE id_dp = '{0}'", id_report)
        ElseIf report_mark_type = "98" Then
            'Employee Change Schedule
            query = String.Format("SELECT id_report_status, emp_ch_schedule_number as report_number FROM tb_emp_ch_schedule WHERE id_emp_ch_schedule = '{0}'", id_report)
        ElseIf report_mark_type = "99" Then
            'Leave Propose Admin Management
            query = String.Format("SELECT id_report_status, emp_leave_number as report_number FROM tb_emp_leave WHERE id_emp_leave = '{0}'", id_report)
        ElseIf report_mark_type = "100" Then
            'Schedule Propose With Approval
            query = String.Format("SELECT id_report_status, assign_sch_number as report_number FROM tb_emp_assign_sch WHERE id_assign_sch = '{0}'", id_report)
        ElseIf report_mark_type = "101" Then
            'Air Ways Bill
            query = String.Format("SELECT id_report_status, id_awbill as report_number FROM tb_wh_awbill WHERE id_awbill = '{0}'", id_report)
        ElseIf report_mark_type = "102" Then
            'Leave Propose HRD
            query = String.Format("SELECT id_report_status, emp_leave_number as report_number FROM tb_emp_leave WHERE id_emp_leave = '{0}'", id_report)
        ElseIf report_mark_type = "104" Then
            'Leave Propose For Admin Manager
            query = String.Format("SELECT id_report_status, emp_leave_number as report_number FROM tb_emp_leave WHERE id_emp_leave = '{0}'", id_report)
        End If

        data = execute_query(query, -1, True, "", "", "", "")

        LEReportStatus.EditValue = Nothing
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status_report = data.Rows(0)("id_report_status").ToString
        Try
            report_number = data.Rows(0)("report_number").ToString
        Catch ex As Exception
        End Try
        'if canceled
        If data.Rows(0)("id_report_status").ToString = "5" Or data.Rows(0)("id_report_status").ToString = "6" Then
            LEReportStatus.Enabled = False
            BSetStatus.Visible = False
            BLeadTime.Visible = False
            BClearLeadTime.Visible = False
            '
            BReset.Visible = False
        Else
            If is_disabled_set_stt = "-1" Then
                LEReportStatus.Enabled = True
            End If
            BSetStatus.Visible = True
            BLeadTime.Visible = True
            BClearLeadTime.Visible = True
            '
            BReset.Visible = True
        End If
    End Sub
    Sub view_mark()
        Dim query As String = "SELECT a.id_report,a.report_mark_type,emp.employee_name,a.id_mark_asg,a.id_report_status,a.report_mark_note,a.id_report_mark,b.report_status,a.id_user,e.mark,CONCAT_WS(' ',DATE_FORMAT(a.report_mark_datetime,'%d %M %Y'),TIME(a.report_mark_datetime)) AS date_time,a.report_mark_note,a.is_use "
        query += ",CONCAT_WS(' ',DATE_FORMAT(a.report_mark_start_datetime,'%d %M %Y'),TIME(a.report_mark_start_datetime)) AS date_time_start "
        query += ",CONCAT_WS(' ',DATE_FORMAT((ADDTIME(report_mark_start_datetime,report_mark_lead_time)),'%d %M %Y'),TIME((ADDTIME(report_mark_start_datetime,report_mark_lead_time)))) AS lead_time "
        query += ",CONCAT_WS(' ',DATE(ADDTIME(report_mark_start_datetime,report_mark_lead_time)),TIME((ADDTIME(report_mark_start_datetime,report_mark_lead_time)))) AS raw_lead_time "
        query += "FROM tb_report_mark a "
        query += "INNER JOIN tb_lookup_report_status b ON a.id_report_status=b.id_report_status "
        query += "LEFT JOIN tb_m_user c ON a.id_user=c.id_user "
        query += "LEFT JOIN tb_m_employee d ON d.id_employee=c.id_employee "
        query += "LEFT JOIN tb_m_employee emp ON emp.id_employee=a.id_employee "
        query += "INNER JOIN tb_lookup_mark e ON e.id_mark=a.id_mark "
        query += "WHERE a.report_mark_type='" & report_mark_type & "' AND a.id_report='" & id_report & "' "
        query += "ORDER BY a.id_report_status,a.level"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMark.DataSource = data
        GVMark.ExpandAllGroups()
        If data.Rows.Count < 1 Then
            BLeadTime.Visible = False
        Else
            BLeadTime.Visible = True
        End If

        'Check Edit
        Dim id_rep_status As String = GVMark.GetFocusedRowCellDisplayText("id_report_status").ToString
        If report_mark_type = "11" Then
            If form_origin = "FormSampleReqSingle" Then
                FormSampleReqSingle.action = "upd"
                FormSampleReqSingle.id_report_status = id_rep_status
                FormSampleReqSingle.actionLoad()
            Else

            End If
        End If
    End Sub

    Sub view_mark_final()
        Dim query As String = "SELECT fnl.id_final_comment, rs.id_report_status, fnl.report_mark_type, fnl.id_report, rs.report_status,  "
        query += "emp.employee_name, fnl.final_comment,  "
        query += "CONCAT_WS(' ',DATE_FORMAT(fnl.final_comment_date,'%d %M %Y'),TIME(fnl.final_comment_date)) AS `final_date`  "
        query += "FROM tb_report_mark_final_comment fnl  "
        query += "INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = fnl.id_report_status  "
        query += "INNER JOIN tb_m_user usr ON usr.id_user = fnl.id_user  "
        query += "INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee  "
        query += "WHERE fnl.id_report='" + id_report + "' AND fnl.report_mark_type='" + report_mark_type + "'  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFinal.DataSource = data
        GVFinal.ExpandAllGroups()
    End Sub

    Function check_available(ByVal id_report_markx As String)
        Dim result As Boolean = False
        Dim id_report_statusx As String = "-1"
        Dim id_userx As String = "-1"

        Dim query As String = String.Format("SELECT id_user,id_report_status FROM tb_report_mark WHERE id_report_mark = '{0}'", id_report_markx)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        ' going to marked
        id_report_statusx = data.Rows(0)("id_report_status").ToString
        id_userx = data.Rows(0)("id_user").ToString
        '
        If id_userx = id_user And check_available_asg(id_report_markx) Then
            Dim query_jml As String = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status < '{2}' AND id_mark != '2' AND is_use='1' AND id_report_mark!='{3}'", report_mark_type, id_report, id_report_statusx, id_report_markx)
            Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
            If jml < 1 Then
                result = True
            End If
        End If

        Return result
    End Function
    Function check_available_asg(ByVal id_report_markx As String)
        Dim result As Boolean = False
        Dim id_report_statusx As String = "-1"

        Dim query As String = "SELECT id_report,id_mark_asg,report_mark_type FROM tb_report_mark WHERE id_report_mark='" & id_report_markx & "' LIMIT 1"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim id_mark_asg, id_report, report_mark_type As String

        id_mark_asg = data.Rows(0)("id_mark_asg").ToString()
        id_report = data.Rows(0)("id_report").ToString()
        report_mark_type = data.Rows(0)("report_mark_type").ToString()

        Dim query_jml As String = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_mark_asg='{2}' AND id_mark != '1' AND is_use='1' AND id_report_mark!='{3}'", report_mark_type, id_report, id_mark_asg, id_report_markx)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If jml < 1 Then
            result = True
        End If

        Return result
    End Function
    Function check_available_asg_color(ByVal id_report_markx As String)
        Dim result As Boolean = False
        Dim id_report_statusx As String = "-1"

        Dim query As String = "SELECT id_report,id_mark_asg,report_mark_type FROM tb_report_mark WHERE id_report_mark='" & id_report_markx & "' LIMIT 1"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim id_mark_asg, id_report, report_mark_type As String

        id_mark_asg = data.Rows(0)("id_mark_asg").ToString()
        id_report = data.Rows(0)("id_report").ToString()
        report_mark_type = data.Rows(0)("report_mark_type").ToString()

        Dim query_jml As String = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_mark_asg='{2}' AND id_mark != '1' AND is_use='1' ", report_mark_type, id_report, id_mark_asg, id_report_markx)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If jml < 1 Then
            result = True
        End If

        Return result
    End Function
    Function check_available_lead_time(ByVal id_report_markx As String)
        Dim result As Boolean = False
        Dim id_report_statusx As String = "-1"
        Dim id_userx As String = "-1"

        Dim query As String = String.Format("SELECT id_user,id_report_status FROM tb_report_mark WHERE id_report_mark = '{0}'", id_report_markx)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        ' going to marked
        id_report_statusx = data.Rows(0)("id_report_status").ToString
        Dim query_jml As String = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status < '{2}' AND id_mark != '2' AND is_use='1'", report_mark_type, id_report, id_report_statusx)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If jml < 1 Then
            result = True
        End If

        Return result
    End Function
    Private Sub GVMark_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVMark.DoubleClick
        'MsgBox(id_report_status_report)
        If id_report_status_report.ToString <> "5" And id_report_status_report.ToString <> "6" Then
            If id_report_status_report >= GVMark.GetFocusedRowCellDisplayText("id_report_status").ToString Then
                stopCustom("This mark already locked.")
            Else
                If check_available(GVMark.GetFocusedRowCellDisplayText("id_report_mark").ToString) Then
                    'the user
                    FormReportMarkDet.id_report_mark = GVMark.GetFocusedRowCellDisplayText("id_report_mark").ToString
                    FormReportMarkDet.ShowDialog()
                Else
                    stopCustom("This mark not available." & vbNewLine & "Make sure : " & vbNewLine & "- You're the correct user." & vbNewLine & "- This mark not marked yet.")
                End If
            End If
        End If
    End Sub

    Private Sub GVMark_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMark.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub FormReportMark_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub

    Private Sub BSetStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSetStatus.Click
        Cursor = Cursors.WaitCursor
        Dim id_status_reportx As String = LEReportStatus.EditValue
        Dim query As String = ""
        Dim assigned As Boolean = False
        'check
        Dim query_jml As String
        Dim jml As Integer
        If Not id_status_reportx = id_report_status_report Then
            If id_status_reportx = "6" Or id_status_reportx = "4" Then
                'completed or processed
                assigned = True
                query_jml = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status <= '3' AND id_mark != '2' AND is_use='1'", report_mark_type, id_report)
                jml = execute_query(query_jml, 0, True, "", "", "", "")
            Else
                'check there are marking 
                query_jml = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status = '{2}' AND is_use='1'", report_mark_type, id_report, id_status_reportx)
                jml = execute_query(query_jml, 0, True, "", "", "", "")
                If jml < 1 Then
                    'no one assigned yet
                    assigned = False
                Else
                    assigned = True
                    query_jml = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status <= '{2}' AND id_mark != '2' AND is_use='1'", report_mark_type, id_report, id_status_reportx)
                    jml = execute_query(query_jml, 0, True, "", "", "", "")
                End If
            End If

            If (jml < 1 And assigned = True) Or id_status_reportx = "5" Then
                If id_status_reportx < id_report_status_report Or id_status_reportx = "5" Then
                    '
                    If id_status_reportx = "5" Then
                        Dim confirm As DialogResult
                        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to cancel this document ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            assigned = True
                            query = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", report_mark_type, id_report, id_status_reportx)
                            execute_non_query(query, True, "", "", "", "")
                            view_mark()
                        Else
                            assigned = False
                        End If
                    ElseIf id_status_reportx = "6" Or id_status_reportx = "4" Or id_status_reportx = "3" Then
                        'completed or processed
                        assigned = True
                    Else
                        Dim confirm As DialogResult
                        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Choosing this status will reset all mark above this status, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            assigned = True
                            query = String.Format("UPDATE tb_report_mark SET id_mark='1',report_mark_lead_time=NULL,report_mark_start_datetime=NULL,report_mark_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'{2}'", report_mark_type, id_report, id_status_reportx)
                            execute_non_query(query, True, "", "", "", "")
                            view_mark()
                        Else
                            assigned = False
                        End If
                    End If
                ElseIf id_status_reportx = "6" Then 'completed
                    'If is_coa_posting(report_mark_type) Then
                    '    Dim confirm As DialogResult
                    '    confirm = DevExpress.XtraEditors.XtraMessageBox.Show("By choosing this status, program will automatically create entry to journal, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    '    If confirm = Windows.Forms.DialogResult.Yes Then
                    '        assigned = True
                    '        posting_journal()
                    '        view_mark()
                    '    Else
                    '        assigned = False
                    '    End If
                    'Else
                    '    assigned = True
                    'End If
                    assigned = True
                End If

                If assigned = True Then
                    change_status(id_status_reportx)
                End If
            Else
                stopCustom("Unable change to this status, report doesn't meet requirement to this status.")
            End If

            view_mark()
            view_report_status(LEReportStatus)
            'slow here
            'FormWork.view_mark_history()
            'FormWork.view_mark_need()
        Else
            infoCustom("Nothing changed.")
        End If
        Cursor = Cursors.Default
    End Sub
    Sub auto_journal()
        Dim id_status_reportx As String = LEReportStatus.EditValue
        Dim acc_trans_number As String = ""
        Dim last_id As String = ""
        Dim id_cc As String = "-1"
        Dim query As String = ""
        Dim query_det As String = ""
        Dim id_ref As String = ""
        Dim id_acc As String = ""
        Dim acc_name As String = ""
        Dim acc_desc As String = ""
        Dim debit, credit As Decimal
        Dim comp_name As String = ""
        Dim no_journal As String = ""
        Dim id_trans As String = ""

        'q_posting = String.Format("INSERT INTO tb_a_acc_trans(acc_trans_number,id_user,date_created,acc_trans_note) VALUES('{0}','{1}',NOW(),'Auto posting {2}');SELECT LAST_INSERT_ID()", acc_trans_number, id_user, report_number)
        'last_id = execute_query(q_posting, 0, True, "", "", "", "")

        If report_mark_type = "48" And id_status_reportx = "6" Then ' sales FG; 1 = BPJ
            query = "SELECT s_p.id_sales_pos,comp_c.id_comp,comp.comp_name,s_p.sales_pos_number, s_p.sales_pos_total,s_p.sales_pos_discount,s_p.sales_pos_vat,(s_p.sales_pos_total*((100-s_p.sales_pos_discount)/100) ) AS netto, ((100/(100+s_p.sales_pos_vat))*(s_p.sales_pos_total*((100-s_p.sales_pos_discount)/100))) AS kena_ppn,((s_p.sales_pos_vat/(100+s_p.sales_pos_vat))*(s_p.sales_pos_total*((100-s_p.sales_pos_discount)/100))) AS ppn"
            query += " FROM tb_sales_pos s_p INNER JOIN tb_m_comp_contact comp_c ON comp_c.id_comp_contact=s_p.id_store_contact_from "
            query += " INNER JOIN tb_m_comp comp ON comp.id_comp=comp_c.id_comp "
            query += " WHERE sales_pos_number = '" + report_number + "' AND id_memo_type='1'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            'auto posting COA
            id_cc = data.Rows(0)("id_comp").ToString
            report_number = data.Rows(0)("sales_pos_number").ToString
            id_ref = data.Rows(0)("id_sales_pos").ToString
            comp_name = data.Rows(0)("comp_name").ToString

            query = "SELECT coa_map_d.id_coa_map_det,comp_coa.id_acc,acc.acc_name,acc.acc_description "
            query += " FROM tb_m_comp_coa comp_coa "
            query += " INNER JOIN tb_coa_map_det coa_map_d ON coa_map_d.id_coa_map_det=comp_coa.id_coa_map_det"
            query += " INNER JOIN tb_coa_map coa_map ON coa_map_d.id_coa_map=coa_map.id_coa_map"
            query += " INNER JOIN tb_a_acc acc ON acc.id_acc=comp_coa.id_acc"
            query += " WHERE comp_coa.id_comp='" + id_cc + "' AND coa_map.id_coa_map='1'"
            Dim data_acc As DataTable = execute_query(query, -1, True, "", "", "", "")

            If data_acc.Rows.Count > 0 Then 'id_coa_map = 1
                no_journal = header_number_acc("3") 'journal number
                'insert journal header
                query = String.Format("INSERT INTO tb_a_acc_trans(acc_trans_number,date_created,id_user,acc_trans_note,id_bill_type,report_mark_type,id_report,report_number,id_cc) VALUES('{0}',NOW(),'{1}','{2}','{3}','{4}','{5}','{6}','{7}'); SELECT LAST_INSERT_ID()", no_journal, id_user, "Auto posting sales finish goods.", 1, report_mark_type, id_ref, report_number, id_cc)
                id_trans = execute_query(query, 0, True, "", "", "", "")

                increase_inc_acc("3")

                'id_acc piutang dagang
                Dim data_filter As DataRow() = data_acc.Select("[id_coa_map_det]='1'")
                id_acc = data_filter(0)("id_acc").ToString
                acc_name = data_filter(0)("acc_name").ToString
                acc_desc = data_filter(0)("acc_description").ToString

                debit = 0
                credit = data.Rows(0)("netto")

                query_det = add_journal(id_trans, id_acc, acc_name, acc_desc, debit, credit, id_cc, report_mark_type, id_ref, report_number)
                'end id_acc piutang dagang

                'id_acc PPN
                data_filter = data_acc.Select("[id_coa_map_det]='2'")
                id_acc = data_filter(0)("id_acc").ToString
                acc_name = data_filter(0)("acc_name").ToString
                acc_desc = data_filter(0)("acc_description").ToString

                debit = data.Rows(0)("ppn")
                credit = 0
                query_det += "," + add_journal(id_trans, id_acc, acc_name, acc_desc, debit, credit, id_cc, report_mark_type, id_ref, report_number)
                'end id_acc PPN

                'id_acc penjualan
                data_filter = data_acc.Select("[id_coa_map_det]='3'")
                id_acc = data_filter(0)("id_acc").ToString
                acc_name = data_filter(0)("acc_name").ToString
                acc_desc = data_filter(0)("acc_description").ToString

                debit = data.Rows(0)("kena_ppn")
                credit = 0
                query_det += "," + add_journal(id_trans, id_acc, acc_name, acc_desc, debit, credit, id_cc, report_mark_type, id_ref, report_number)
                'end id_acc penjualan

                query = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,id_status_open,report_mark_type,id_report,report_number,id_comp) VALUES" + query_det
                execute_non_query(query, True, "", "", "", "")
            Else
                stopCustom("Store account not registered")
            End If
        End If
    End Sub
    Function add_journal(ByVal id_acc_trans As String, ByVal id_acc As String, ByVal acc_name As String, ByVal note As String, ByVal debit As Decimal, ByVal credit As Decimal, ByVal id_comp As String, ByVal report_mark_type As String, ByVal id_report As String, ByVal report_numberx As String)
        Dim query As String = "('" + id_acc_trans + "','" + id_acc + "','" + decimalSQL(debit.ToString) + "','" + decimalSQL(credit.ToString) + "','" + note + "',1,'" + report_mark_type + "','" + id_report + "','" + report_numberx + "','" + id_comp + "')"
        Return query
    End Function
    Sub change_status(ByVal id_status_reportx As String)
        Dim query As String = ""
        If report_mark_type = "1" Then
            'sample purchase
            query = String.Format("UPDATE tb_sample_purc SET id_report_status='{0}' WHERE id_sample_purc='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormSamplePurchaseDet.allow_status()
                FormViewSamplePurchase.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSamplePurchase.view_sample_purc()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "2" Then
            'sample receive
            query = String.Format("UPDATE tb_sample_purc_rec SET id_report_status='{0}' WHERE id_sample_purc_rec='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            If id_status_reportx = 6 Then 'Completed
                Dim query_del As String = "DELETE FROM tb_sample_purc_rec_det WHERE id_sample_purc_rec='" + id_report + "' AND sample_purc_rec_det_qty <= 0"
                execute_non_query(query_del, True, "", "", "", "")
                '
                Dim query_completed As String = "SELECT * FROM tb_sample_purc_rec_det a "
                query_completed += "INNER JOIN tb_sample_purc_det b ON a.id_sample_purc_det = b.id_sample_purc_det "
                query_completed += "INNER JOIN tb_m_sample_price c ON c.id_sample_price = b.id_sample_price "
                query_completed += "INNER JOIN tb_sample_purc_rec d ON d.id_sample_purc_rec = a.id_sample_purc_rec "
                query_completed += "LEFT JOIN "
                query_completed += "( "
                query_completed += "SELECT id_sample_price as id_sample_price_cost,sample_price as sample_price_cost,id_sample FROM tb_m_sample_price WHERE is_default_cost=1 "
                query_completed += ") cost ON cost.id_sample=c.id_sample "
                query_completed += "WHERE a.id_sample_purc_rec = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_completed, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_sample_purc_rec_det As String = data.Rows(i)("id_sample_purc_rec_det").ToString
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_sample As String = data.Rows(i)("id_sample").ToString
                    Dim id_sample_price As String = data.Rows(i)("id_sample_price_cost").ToString
                    Dim sample_price As Decimal = data.Rows(i)("sample_price_cost")
                    Dim sample_return_det_qty As String = data.Rows(i)("sample_purc_rec_det_qty").ToString
                    Dim sample_return_number As String = data.Rows(i)("sample_purc_rec_number").ToString
                    Dim query_upd_storage As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes,id_report,report_mark_type,id_stock_status,id_sample_price,sample_price) "
                    'update storage
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + sample_return_det_qty + "', NOW(), 'Completed, Sample Receive No. : " + sample_return_number + "','" + id_report + "','" + report_mark_type + "','1','" + id_sample_price + "','" + decimalSQL(sample_price.ToString) + "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                    'update stored
                    Dim query_upd_stored As String = "UPDATE tb_sample_purc_rec_det SET sample_purc_rec_det_qty_stored = sample_purc_rec_det_qty WHERE id_sample_purc_rec_det='" & id_sample_purc_rec_det & "' "
                    execute_non_query(query_upd_stored, True, "", "", "", "")
                Next
            End If
            infoCustom("Status changed.")
            Try
                FormSampleReceiveDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleReceiveDet.allow_status()
                FormSampleReceiveDet.view_list_rec()
                FormSampleReceive.view_sample_rec()
                FormSampleReceive.GVSampleReceive.FocusedRowHandle = find_row(FormSampleReceive.GVSampleReceive, "id_sample_purc_rec", id_report)
                FormViewSampleReceive.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                'FormWork.view_sample_rec()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "3" Then
            'sample PL
            If id_status_reportx = 3 Then
                Dim query_del_zero As String = "DELETE FROM tb_pl_sample_purc_det WHERE id_pl_sample_purc = '" + id_report + "' AND pl_sample_purc_det_qty= '0.00'"
                execute_non_query(query_del_zero, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_pl_sample_purc SET id_report_status='{0}' WHERE id_pl_sample_purc='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormSamplePLSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSamplePLSingle.action = "upd"
                FormSamplePLSingle.id_report_status = id_status_reportx
                FormSamplePLSingle.actionLoad()
                FormViewSamplePL.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormWork.viewPL()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "4" Then
            'sample PR
            query = String.Format("UPDATE tb_pr_sample_purc SET id_report_status='{0}' WHERE id_pr_sample_purc='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormSamplePRDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSamplePRDet.allow_status()
                FormViewSamplePR.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormWork.view_sample_pr()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "5" Then
            'sample ret out
            query = String.Format("UPDATE tb_sample_purc_ret_out SET id_report_status='{0}' WHERE id_sample_purc_ret_out='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormSampleRetOutSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleRetOutSingle.action = "upd"
                FormSampleRetOutSingle.id_report_status = id_status_reportx
                FormSampleRetOutSingle.actionLoad()
                'FormViewSampleReceive.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                'FormWork.view_sample_rec()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "6" Then
            'sample ret in
            query = String.Format("UPDATE tb_sample_purc_ret_in SET id_report_status='{0}' WHERE id_sample_purc_ret_in='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormSampleRetInSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleRetInSingle.action = "upd"
                FormSampleRetInSingle.id_report_status = id_status_reportx
                FormSampleRetInSingle.actionLoad()
                'FormViewSampleReceive.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                'FormWork.view_sample_rec()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "7" Then
            'sample Receipt
            query = String.Format("UPDATE tb_pl_sample_purc SET id_report_status_rec='{0}' WHERE id_pl_sample_purc='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormSampleReceiptSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleReceiptSingle.action = "upd"
                FormSampleReceiptSingle.id_report_status_rec = id_status_reportx
                FormSampleReceiptSingle.actionLoad()
                'FormViewSampleReceive.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                'FormWork.view_sample_rec()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "8" Then
            'bom
            query = String.Format("UPDATE tb_bom SET id_report_status='{0}' WHERE id_bom='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormBOMSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormBOMSingle.allow_status()
                'FormViewSamplePurchase.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                'FormWork.view_sample_purc()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "9" Or report_mark_type = "80" Or report_mark_type = "81" Then
            'PROD DEMAND
            'posting ke master price disini
            '--------------------------

            If id_status_reportx = 6 Then ' COMPLETED
                'get default curr
                Dim auto_insert_price_from_pd As String = execute_query("SELECT auto_insert_price_from_pd FROM tb_opt", 0, True, "", "", "", "")
                Dim id_currency As String = execute_query("SELECT id_currency_default FROM tb_opt", 0, True, "", "", "", "")

                'insert price
                If auto_insert_price_from_pd = "1" Then
                    Dim query_post_price As String = ""
                    query_post_price += "INSERT INTO tb_m_design_price(id_design, id_design_price_type, design_price_name, id_currency, design_price, design_price_date, design_price_start_date, is_print, is_active_wh, id_user) "
                    query_post_price += "SELECT id_design, '1', 'Normal Price', '" + id_currency + "', prod_demand_design_propose_price, NOW(), date_available_start, '1', '1', '" + id_user + "' FROM tb_prod_demand_design WHERE id_prod_demand = '" + id_report + "' "
                    execute_non_query(query_post_price, True, "", "", "", "")
                End If

                'non md 
                If FormProdDemandSingle.SLEKind.EditValue.ToString <> "1" Then
                    Dim query_post_price As String = ""
                    query_post_price += "INSERT INTO tb_m_design_price(id_design, id_design_price_type, design_price_name, id_currency, design_price, design_price_date, design_price_start_date, is_print, is_active_wh, id_user) "
                    query_post_price += "SELECT id_design, '1', 'Normal Price', '" + id_currency + "', 0, NOW(), NOW(), '1', '1', '" + id_user + "' FROM tb_prod_demand_design WHERE id_prod_demand = '" + id_report + "' "
                    execute_non_query(query_post_price, True, "", "", "", "")
                End If
            End If

            'update status
            query = String.Format("UPDATE tb_prod_demand SET id_report_status='{0}' WHERE id_prod_demand='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                If form_origin = "FormProdDemand" Then
                    FormProdDemand.viewProdDemand()
                    FormProdDemand.GVProdDemand.FocusedRowHandle = find_row(FormProdDemand.GVProdDemand, "id_prod_demand", id_report)
                    FormProdDemand.view_product()
                ElseIf form_origin = "FormWork" Then
                    FormWork.viewProdDemand()
                    FormWork.GVProdDemand.FocusedRowHandle = find_row(FormWork.GVProdDemand, "id_prod_demand", id_report)
                ElseIf form_origin = "FormProdDemandSingle" Then
                    FormProdDemandSingle.id_prod_demand = id_report
                    FormProdDemandSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormProdDemandSingle.action = "upd"
                    FormProdDemandSingle.id_report_status = id_status_reportx
                    FormProdDemandSingle.actionLoad()
                    FormProdDemand.viewProdDemand()
                    FormProdDemand.GVProdDemand.FocusedRowHandle = find_row(FormProdDemand.GVProdDemand, "id_prod_demand", id_report)
                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "10" Then
            'sample PL Del
            If id_status_reportx = 5 Then 'Cancel
                Dim query_cancel As String = "SELECT * FROM tb_pl_sample_del a "
                query_cancel += "INNER JOIN tb_pl_sample_del_det b ON a.id_pl_sample_del = b.id_pl_sample_del "
                query_cancel += "INNER JOIN tb_sample_requisition_det c ON b.id_sample_requisition_det = c.id_sample_requisition_det "
                query_cancel += "WHERE a.id_pl_sample_del = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_sample As String = data.Rows(i)("id_sample").ToString
                    Dim pl_sample_del_det_qty As String = data.Rows(i)("pl_sample_del_det_qty").ToString
                    Dim pl_sample_del_number As String = data.Rows(i)("pl_sample_del_number").ToString
                    Dim id_sample_price As String = data.Rows(i)("id_sample_price").ToString
                    Dim sample_price As Decimal = data.Rows(i)("sample_price")

                    Dim query_upd_storage As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes,id_report,report_mark_type,id_stock_status,id_sample_price,sample_price) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + pl_sample_del_det_qty + "', NOW(), 'Out sample was cancelled, PL : " + pl_sample_del_number + "','" + id_report + "','" + report_mark_type + "','2','" + id_sample_price + "','" + decimalSQL(sample_price.ToString) + "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                Next
            ElseIf id_status_reportx = 6 Then 'Completed
                Dim query_cancel As String = "SELECT * FROM tb_pl_sample_del a "
                query_cancel += "INNER JOIN tb_pl_sample_del_det b ON a.id_pl_sample_del = b.id_pl_sample_del "
                query_cancel += "INNER JOIN tb_sample_requisition_det c ON b.id_sample_requisition_det = c.id_sample_requisition_det "
                query_cancel += "WHERE a.id_pl_sample_del = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_sample As String = data.Rows(i)("id_sample").ToString
                    Dim pl_sample_del_det_qty As String = data.Rows(i)("pl_sample_del_det_qty").ToString
                    Dim pl_sample_del_number As String = data.Rows(i)("pl_sample_del_number").ToString
                    Dim id_sample_price As String = data.Rows(i)("id_sample_price").ToString
                    Dim sample_price As Decimal = data.Rows(i)("sample_price")
                    '
                    Dim query_upd_storage As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes,id_report,report_mark_type,id_stock_status,id_sample_price,sample_price) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + pl_sample_del_det_qty + "', NOW(), 'Completed, Sample PL : " + pl_sample_del_number + "','" + id_report + "','" + report_mark_type + "','2','" + id_sample_price + "','" + decimalSQL(sample_price.ToString) + "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                    '
                    query_upd_storage = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes,id_report,report_mark_type,id_stock_status,id_sample_price,sample_price) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '2', '" + id_sample + "', '" + pl_sample_del_det_qty + "', NOW(), 'Completed, Sample PL : " + pl_sample_del_number + "','" + id_report + "','" + report_mark_type + "','1','" + id_sample_price + "','" + decimalSQL(sample_price.ToString) + "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                Next
            End If

            query = String.Format("UPDATE tb_pl_sample_del SET id_report_status='{0}' WHERE id_pl_sample_del='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            'Try
            If form_origin = "FormSamplePLDelSingle" Then
                FormSamplePLDelSingle.id_pl_sample_del = id_report
                FormSamplePLDelSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSamplePLDelSingle.action = "upd"
                FormSamplePLDelSingle.id_report_status = id_status_reportx
                FormSamplePLDelSingle.actionLoad()
                FormSamplePLDel.viewPL()
                FormSamplePLDel.viewSampleReq()
                FormSamplePLDel.GVPL.FocusedRowHandle = find_row(FormSamplePLDel.GVPL, "id_pl_sample_del", id_report)
            Else
                FormViewSamplePLDel.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormWork.viewPLDel()
            End If
            'Catch ex As Exception
            'End Try
        ElseIf report_mark_type = "11" Then
            'sample requisition
            query = String.Format("UPDATE tb_sample_requisition SET id_report_status='{0}' WHERE id_sample_requisition='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormSampleReqSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleReqSingle.action = "upd"
                FormSampleReqSingle.id_report_status = id_status_reportx
                FormSampleReqSingle.actionLoad()
                FormSampleReq.viewSampleReq()
                'FormViewSampleReceive.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                'FormWork.view_sample_rec()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "12" Then
            'sample planning
            query = String.Format("UPDATE tb_sample_plan SET id_report_status='{0}' WHERE id_sample_plan='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormSamplePlanDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSamplePlanDet.allow_status()
                FormSamplePlan.view_sample_plan()
                FormViewSamplePlan.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                'FormWork.view_sample_purc()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "13" Then
            'material purchase
            query = String.Format("UPDATE tb_mat_purc SET id_report_status='{0}' WHERE id_mat_purc='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormMatPurchaseDet.id_report_status_g = id_status_reportx
                FormMatPurchaseDet.allow_status()
                FormMatPurchase.view_mat_purc()
                FormMatPurchase.GVMatPurchase.FocusedRowHandle = find_row(FormMatPurchase.GVMatPurchase, "id_mat_purc", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "14" Then
            'sample Return

            If id_status_reportx = 6 Then 'Completed
                Dim query_cancel As String = "SELECT * FROM tb_sample_return a "
                query_cancel += "INNER JOIN tb_sample_return_det b ON a.id_sample_return = b.id_sample_return "
                query_cancel += "WHERE a.id_sample_return = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")

                Dim jum_ins_i As Integer = 0
                Dim query_upd_storage As String = ""
                If data.Rows.Count > 0 Then
                    query_upd_storage = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes,id_report,report_mark_type,id_stock_status,id_sample_price,sample_price) VALUES "
                End If
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_sample As String = data.Rows(i)("id_sample").ToString
                    Dim id_sample_price As String = data.Rows(i)("id_sample_price").ToString
                    Dim sample_price As Decimal = data.Rows(i)("sample_price")
                    Dim sample_return_det_qty As String = data.Rows(i)("sample_return_det_qty").ToString
                    Dim sample_return_number As String = data.Rows(i)("sample_return_number").ToString

                    If jum_ins_i > 0 Then
                        query_upd_storage += ", "
                    End If
                    query_upd_storage += "('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + decimalSQL(sample_return_det_qty) + "', NOW(), 'Completed,Sample Return No. : " + sample_return_number + "','" + id_report + "','" + report_mark_type + "','1','" + id_sample_price + "','" + decimalSQL(sample_price.ToString) + "') "
                    jum_ins_i = jum_ins_i + 1
                Next
                If data.Rows.Count > 0 Then
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                End If
            End If

            query = String.Format("UPDATE tb_sample_return SET id_report_status='{0}' WHERE id_sample_return='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            'Try
            If form_origin = "FormSampleReturnSingle" Then
                FormSampleReturnSingle.id_sample_return = id_report
                FormSampleReturnSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleReturnSingle.action = "upd"
                FormSampleReturnSingle.id_report_status = id_status_reportx
                FormSampleReturnSingle.actionLoad()
                FormSampleReturn.viewSampleReturn()
                FormSampleReturn.GVRetSample.FocusedRowHandle = find_row(FormSampleReturn.GVRetSample, "id_sample_return", id_report)
                FormSampleReturn.viewPl()
            Else
                FormViewSampleReturn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormWork.viewSampleReturn()
            End If
            'Catch ex As Exception
            'End Try
        ElseIf report_mark_type = "15" Then
            'material wo
            If id_status_reportx = "6" Then 'completed
                query = String.Format("UPDATE tb_mat_wo SET id_report_status='{0}',mat_wo_complete_date=NOW() WHERE id_mat_wo='{1}'", id_status_reportx, id_report)
            Else
                query = String.Format("UPDATE tb_mat_wo SET id_report_status='{0}' WHERE id_mat_wo='{1}'", id_status_reportx, id_report)
            End If

            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormMatWODet.allow_status()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "16" Then
            'Receive material purchase
            If id_status_reportx = 6 Then 'Completed
                Dim is_ok As String = "1"
                For i As Integer = 0 To FormMatRecPurcDet.GVListPurchase.RowCount - 1
                    If FormMatRecPurcDet.GVListPurchase.GetRowCellValue(i, "cost") = 0 Then
                        is_ok = "2"
                        Exit For
                    End If
                Next
                If is_ok = "1" Then
                    query = String.Format("UPDATE tb_mat_purc_rec SET id_report_status='{0}' WHERE id_mat_purc_rec='{1}'", id_status_reportx, id_report)
                    execute_non_query(query, True, "", "", "", "")
                    '
                    Dim query_del As String = "DELETE FROM tb_mat_purc_rec_det WHERE id_mat_purc_rec='" + id_report + "' AND mat_purc_rec_det_qty <= 0"
                    execute_non_query(query_del, True, "", "", "", "")
                    '
                    Dim query_completed As String = "SELECT c.id_mat_det,b.id_mat_det_price,b.mat_purc_det_price,a.mat_purc_rec_det_qty,d.id_wh_drawer,d.mat_purc_rec_number,IFNULL(cost.id_mat_det_price_cost,0) as id_mat_det_price_cost,IFNULL(cost.mat_det_price_cost,0.0) as mat_det_price_cost FROM tb_mat_purc_rec_det a "
                    query_completed += "INNER JOIN tb_mat_purc_det b ON a.id_mat_purc_det = b.id_mat_purc_det "
                    query_completed += "INNER JOIN tb_m_mat_det_price c ON c.id_mat_det_price = b.id_mat_det_price "
                    query_completed += "INNER JOIN tb_mat_purc_rec d ON d.id_mat_purc_rec = a.id_mat_purc_rec "
                    query_completed += "LEFT JOIN ( "
                    query_completed += "SELECT id_mat_det_price as id_mat_det_price_cost,mat_det_price as mat_det_price_cost,id_mat_det FROM tb_m_mat_det_price WHERE is_default_cost=1 "
                    query_completed += ") cost ON cost.id_mat_det=c.id_mat_det "
                    query_completed += "WHERE a.id_mat_purc_rec = '" + id_report + "' "
                    Dim data As DataTable = execute_query(query_completed, -1, True, "", "", "", "")
                    Dim jum_ins_i As Integer = 0
                    Dim query_upd_storage As String = ""
                    If data.Rows.Count > 0 Then
                        query_upd_storage = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_report,report_mark_type,id_stock_status,id_mat_det_price,price) VALUES "
                    End If
                    For i As Integer = 0 To (data.Rows.Count - 1)
                        Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                        Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                        Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price_cost").ToString
                        Dim mat_det_price As Decimal = data.Rows(i)("mat_det_price_cost")
                        Dim mat_wo_rec_det_qty As String = data.Rows(i)("mat_purc_rec_det_qty").ToString
                        Dim mat_wo_rec_number As String = data.Rows(i)("mat_purc_rec_number").ToString
                        If i > 0 Then
                            query_upd_storage += ", "
                        End If
                        'update storage
                        query_upd_storage += "('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + decimalSQL(mat_wo_rec_det_qty.ToString) + "', NOW(), 'Completed, Material PO Receive No. : " + mat_wo_rec_number + "','" + id_report + "','" + report_mark_type + "','1','" + id_mat_det_price + "','" + decimalSQL(mat_det_price.ToString) + "')"
                    Next
                    If data.Rows.Count > 0 Then
                        execute_non_query(query_upd_storage, True, "", "", "", "")
                    End If
                    infoCustom("Status changed.")
                    Try
                        FormMatRecPurcDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                        FormMatRecPurcDet.allow_status()
                        FormViewMatRecPurc.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                        FormMatRecPurc.view_mat_rec_purc()
                        FormMatRecPurc.GVMatRecPurc.FocusedRowHandle = find_row(FormMatRecPurc.GVMatRecPurc, "id_mat_rec_purc", id_report)
                    Catch ex As Exception
                    End Try
                Else
                    stopCustom("Please make sure all material have cost.")
                End If
            Else
                query = String.Format("UPDATE tb_mat_purc_rec SET id_report_status='{0}' WHERE id_mat_purc_rec='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Status changed.")
                Try
                    FormMatRecPurcDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormMatRecPurcDet.allow_status()
                    FormViewMatRecPurc.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormMatRecPurc.view_mat_rec_purc()
                    FormMatRecPurc.GVMatRecPurc.FocusedRowHandle = find_row(FormMatRecPurc.GVMatRecPurc, "id_mat_rec_purc", id_report)
                Catch ex As Exception
                End Try
            End If
        ElseIf report_mark_type = "17" Then
            'Receive material wo
            If id_status_reportx = 6 Then 'Completed
                Dim is_ok As String = "1"
                For i As Integer = 0 To FormMatRecWODet.GVListPurchase.RowCount - 1
                    If FormMatRecWODet.GVListPurchase.GetRowCellValue(i, "cost") = 0 Then
                        is_ok = "2"
                        Exit For
                    End If
                Next
                If is_ok = "1" Then
                    Dim query_del As String = "DELETE FROM tb_mat_wo_rec_det WHERE id_mat_wo_rec='" + id_report + "' AND mat_wo_rec_det_qty <= 0"
                    execute_non_query(query_del, True, "", "", "", "")
                    '
                    Dim query_completed As String = "SELECT b.id_mat_det,b.id_mat_det_price,b.mat_wo_det_price,a.mat_wo_rec_det_qty,d.id_wh_drawer,d.mat_wo_rec_number,IFNULL(cost.id_mat_det_price_cost,0) as id_mat_det_price_cost,IFNULL(cost.mat_det_price_cost,0.0) as mat_det_price_cost FROM tb_mat_wo_rec_det a "
                    query_completed += "INNER JOIN tb_mat_wo_det b ON a.id_mat_wo_det = b.id_mat_wo_det "
                    query_completed += "INNER JOIN tb_mat_wo_rec d ON d.id_mat_wo_rec = a.id_mat_wo_rec "
                    query_completed += "LEFT JOIN ( "
                    query_completed += "SELECT id_mat_det_price as id_mat_det_price_cost,mat_det_price as mat_det_price_cost,id_mat_det FROM tb_m_mat_det_price WHERE is_default_cost=1 "
                    query_completed += ") cost ON cost.id_mat_det=b.id_mat_det "
                    query_completed += "WHERE a.id_mat_wo_rec = '" + id_report + "' "
                    Dim data As DataTable = execute_query(query_completed, -1, True, "", "", "", "")
                    For i As Integer = 0 To (data.Rows.Count - 1)
                        Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                        Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                        Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price_cost").ToString
                        Dim mat_det_price As Decimal = data.Rows(i)("mat_det_price_cost")
                        Dim mat_wo_rec_det_qty As String = data.Rows(i)("mat_wo_rec_det_qty").ToString
                        Dim mat_wo_rec_number As String = data.Rows(i)("mat_wo_rec_number").ToString
                        Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_report,report_mark_type,id_stock_status,id_mat_det_price,price) "
                        'update storage
                        query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + mat_wo_rec_det_qty + "', NOW(), 'Completed, Material WO Receive No. : " + mat_wo_rec_number + "','" + id_report + "','" + report_mark_type + "','1','" + id_mat_det_price + "','" + decimalSQL(mat_det_price.ToString) + "')"
                        execute_non_query(query_upd_storage, True, "", "", "", "")
                        'update stored
                    Next
                    query = String.Format("UPDATE tb_mat_wo_rec SET id_report_status='{0}' WHERE id_mat_wo_rec='{1}'", id_status_reportx, id_report)
                    execute_non_query(query, True, "", "", "", "")
                    infoCustom("Status changed.")
                    Try
                        FormMatRecWODet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                        FormMatRecWODet.allow_status()
                        FormViewMatRecWO.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    Catch ex As Exception
                    End Try
                Else
                    stopCustom("Please make sure all material have cost.")
                End If

            Else
                query = String.Format("UPDATE tb_mat_wo_rec SET id_report_status='{0}' WHERE id_mat_wo_rec='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Status changed.")
                Try
                    FormMatRecWODet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormMatRecWODet.allow_status()
                    FormViewMatRecWO.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                Catch ex As Exception
                End Try
            End If
        ElseIf report_mark_type = "18" Then
            'Return Material Out
            If id_status_reportx = 6 Then 'complete
                Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det,id_mat_det_price,price, storage_mat_qty, storage_mat_datetime, storage_mat_notes,report_mark_type,id_report,id_stock_status) "
                query_upd_storage += " SELECT a.id_wh_drawer,'2',c.id_mat_det,b.id_mat_det_price,a.price,a.mat_purc_ret_out_det_qty,NOW(),'Completed, Material purchase return out : " & report_number & "','18','" & id_report & "','1' FROM tb_mat_purc_ret_out_det a INNER JOIN tb_mat_purc_det b ON b.id_mat_purc_det=a.id_mat_purc_det INNER JOIN tb_m_mat_det_price c ON c.id_mat_det_price=b.id_mat_det_price WHERE id_mat_purc_ret_out='" & id_report & "' AND NOT ISNULL(id_wh_drawer) AND NOT ISNULL(price)"
                execute_non_query(query_upd_storage, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_mat_purc_ret_out SET id_report_status='{0}' WHERE id_mat_purc_ret_out='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormMatRetOutDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormMatRetOutDet.check_but()
                FormMatRetOutDet.allow_status()
                FormMatRet.viewRetOut()
                FormViewMatRetOut.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "19" Then
            'Return Material in
            query = String.Format("UPDATE tb_mat_purc_ret_in SET id_report_status='{0}' WHERE id_mat_purc_ret_in='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            If id_status_reportx = 6 Then 'Completed
                Dim query_cancel As String = "SELECT c.id_wh_drawer,d.id_mat_det,b.id_mat_det_price,b.mat_purc_det_price,a.mat_purc_ret_in_det_qty,c.mat_purc_ret_in_number,IFNULL(cost.id_mat_det_price_cost,0) as id_mat_det_price_cost,IFNULL(cost.mat_det_price_cost,0.0) as mat_det_price_cost FROM tb_mat_purc_ret_in_det a "
                query_cancel += "INNER JOIN tb_mat_purc_det b ON a.id_mat_purc_det = b.id_mat_purc_det "
                query_cancel += "INNER JOIN tb_m_mat_det_price d ON d.id_mat_det_price = b.id_mat_det_price "
                query_cancel += "INNER JOIN tb_mat_purc_ret_in c ON a.id_mat_purc_ret_in = c.id_mat_purc_ret_in "
                query_cancel += "LEFT JOIN( "
                query_cancel += "SELECT id_mat_det_price as id_mat_det_price_cost,mat_det_price as mat_det_price_cost,id_mat_det FROM tb_m_mat_det_price WHERE is_default_cost=1 "
                query_cancel += ") cost ON cost.id_mat_det=d.id_mat_det "
                query_cancel += "WHERE a.id_mat_purc_ret_in = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")

                Dim jum_ins_i As Integer = 0
                Dim query_upd_storage As String = ""
                If data.Rows.Count > 0 Then
                    query_upd_storage = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_report,report_mark_type,id_stock_status,id_mat_det_price,price) VALUES "
                End If

                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                    Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price_cost").ToString
                    Dim mat_det_price As Decimal = data.Rows(i)("mat_det_price_cost")
                    Dim mat_qty As String = data.Rows(i)("mat_purc_ret_in_det_qty").ToString
                    Dim mat_number As String = data.Rows(i)("mat_purc_ret_in_number").ToString

                    If jum_ins_i > 0 Then
                        query_upd_storage += ", "
                    End If

                    query_upd_storage += "('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + decimalSQL(mat_qty.ToString) + "', NOW(), 'Completed, Material Return In No. : " + mat_number + "','" + id_report + "','" + report_mark_type + "','1','" + id_mat_det_price + "','" + decimalSQL(mat_det_price.ToString) + "') "

                    jum_ins_i = jum_ins_i + 1
                Next
                If data.Rows.Count > 0 Then
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                End If
            End If
            infoCustom("Status changed.")
            Try
                FormMatRetInDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormMatRetInDet.check_but()
                FormMatRetInDet.allow_status()
                FormMatRet.viewRetIn()
                FormViewMatRetIn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "20" Then
            'Sample Adj In (UPDATED 17 October 2014)
            If id_status_reportx = "6" Then 'Cancel
                Dim query_cancel As String = "SELECT * FROM tb_adj_in_sample a "
                query_cancel += "INNER JOIN tb_adj_in_sample_det b ON a.id_adj_in_sample = b.id_adj_in_sample "
                query_cancel += "WHERE a.id_adj_in_sample = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_sample As String = data.Rows(i)("id_sample").ToString
                    Dim adj_in_sample_det_qty As String = data.Rows(i)("adj_in_sample_det_qty").ToString
                    Dim adj_in_sample_number As String = data.Rows(i)("adj_in_sample_number").ToString
                    Dim adj_in_sample_det_price As String = decimalSQL(data.Rows(i)("adj_in_sample_det_price").ToString)
                    Dim id_sample_price As String = data.Rows(i)("id_sample_price").ToString
                    Dim query_upd_storage As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + decimalSQL(adj_in_sample_det_qty) + "', NOW(), 'Sample IN completed, Adjustment In No. : " + adj_in_sample_number + "', '" + id_sample_price + "', '" + adj_in_sample_det_price + "', '20', '" + id_report + "', '1') "
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                Next
            End If

            query = String.Format("UPDATE tb_adj_in_sample SET id_report_status='{0}' WHERE id_adj_in_sample='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            'Try
            If form_origin = "FormSampleAdjustmentInSingle" Then
                FormSampleAdjustmentInSingle.id_adj_in_sample = id_report
                FormSampleAdjustmentInSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleAdjustmentInSingle.action = "upd"
                FormSampleAdjustmentInSingle.id_report_status = id_status_reportx
                FormSampleAdjustmentInSingle.actionLoad()
                FormSampleAdjustment.viewAdjInSample()
                FormSampleAdjustment.GVAdjSampleIn.FocusedRowHandle = find_row(FormSampleAdjustment.GVAdjSampleIn, "id_adj_in_sample", id_report)
            ElseIf form_origin = "FormViewSampleAdjIn" Then
                FormViewSampleAdjIn.id_adj_in_sample = id_report
                FormViewSampleAdjIn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormViewSampleAdjIn.action = "upd"
                FormViewSampleAdjIn.id_report_status = id_status_reportx
                FormViewSampleAdjIn.actionLoad()
                FormWork.viewAdjInSample()
            End If
            'Catch ex As Exception
            'End Try
        ElseIf report_mark_type = "21" Then
            'Sample Adj Out
            If id_status_reportx = 5 Then 'Cancel
                Dim query_cancel As String = "SELECT * FROM tb_adj_out_sample a "
                query_cancel += "INNER JOIN tb_adj_out_sample_det b ON a.id_adj_out_sample = b.id_adj_out_sample "
                query_cancel += "WHERE a.id_adj_out_sample = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")

                Dim jum_ins_i As Integer = 0
                Dim query_drawer_stock As String = ""
                If data.Rows.Count > 0 Then
                    query_drawer_stock = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, id_sample_price, sample_price, qty_sample, datetime_storage_sample, storage_sample_notes, report_mark_type, id_report, id_stock_status) VALUES "
                End If
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_sample As String = data.Rows(i)("id_sample").ToString
                    Dim adj_out_sample_det_qty As String = decimalSQL(data.Rows(i)("adj_out_sample_det_qty").ToString)
                    Dim adj_out_sample_number As String = data.Rows(i)("adj_out_sample_number").ToString
                    Dim id_sample_price As String = data.Rows(i)("id_sample_price").ToString
                    Dim adj_out_sample_det_price As String = decimalSQL(data.Rows(i)("adj_out_sample_det_price").ToString)

                    'insert stock
                    If jum_ins_i > 0 Then
                        query_drawer_stock += ", "
                    End If
                    query_drawer_stock += "('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + id_sample_price + "', '" + adj_out_sample_det_price + "','" + adj_out_sample_det_qty + "', NOW(), 'Adjusment Out Cancelled Order No: " + adj_out_sample_number + "', '21', '" + id_report + "', '2') "
                    jum_ins_i = jum_ins_i + 1
                Next
                If jum_ins_i > 0 Then
                    execute_non_query(query_drawer_stock, True, "", "", "", "")
                End If
            ElseIf id_status_reportx = 6 Then
                Dim query_cancel As String = "SELECT * FROM tb_adj_out_sample a "
                query_cancel += "INNER JOIN tb_adj_out_sample_det b ON a.id_adj_out_sample = b.id_adj_out_sample "
                query_cancel += "WHERE a.id_adj_out_sample = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")

                Dim jum_ins_i As Integer = 0
                Dim query_drawer_stock As String = ""
                Dim query_drawer_stock2 As String = ""
                If data.Rows.Count > 0 Then
                    query_drawer_stock = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, id_sample_price, sample_price, qty_sample, datetime_storage_sample, storage_sample_notes, report_mark_type, id_report, id_stock_status) VALUES "
                    query_drawer_stock2 = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, id_sample_price, sample_price, qty_sample, datetime_storage_sample, storage_sample_notes, report_mark_type, id_report, id_stock_status) VALUES "
                End If
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_sample As String = data.Rows(i)("id_sample").ToString
                    Dim adj_out_sample_det_qty As String = decimalSQL(data.Rows(i)("adj_out_sample_det_qty").ToString)
                    Dim adj_out_sample_number As String = data.Rows(i)("adj_out_sample_number").ToString
                    Dim id_sample_price As String = data.Rows(i)("id_sample_price").ToString
                    Dim adj_out_sample_det_price As String = decimalSQL(data.Rows(i)("adj_out_sample_det_price").ToString)

                    'insert stock
                    If jum_ins_i > 0 Then
                        query_drawer_stock += ", "
                        query_drawer_stock2 += ", "
                    End If
                    query_drawer_stock += "('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + id_sample_price + "', '" + adj_out_sample_det_price + "','" + adj_out_sample_det_qty + "', NOW(), 'Adjusment Out Completed Order No: " + adj_out_sample_number + "', '21', '" + id_report + "', '2') "
                    query_drawer_stock2 += "('" + id_wh_drawer + "', '2', '" + id_sample + "', '" + id_sample_price + "', '" + adj_out_sample_det_price + "','" + adj_out_sample_det_qty + "', NOW(), 'Adjusment Out Completed Order No: " + adj_out_sample_number + "', '21', '" + id_report + "', '1') "
                    jum_ins_i = jum_ins_i + 1
                Next
                If jum_ins_i > 0 Then
                    execute_non_query(query_drawer_stock, True, "", "", "", "")
                    execute_non_query(query_drawer_stock2, True, "", "", "", "")
                End If

            End If

            query = String.Format("UPDATE tb_adj_out_sample SET id_report_status='{0}' WHERE id_adj_out_sample='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            'Try
            If form_origin = "FormSampleAdjustmentOutSingle" Then
                FormSampleAdjustmentOutSingle.id_adj_out_sample = id_report
                FormSampleAdjustmentOutSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleAdjustmentOutSingle.action = "upd"
                FormSampleAdjustmentOutSingle.id_report_status = id_status_reportx
                FormSampleAdjustmentOutSingle.actionLoad()
                FormSampleAdjustment.viewAdjOutSample()
                FormSampleAdjustment.GVAdjOutSample.FocusedRowHandle = find_row(FormSampleAdjustment.GVAdjOutSample, "id_adj_out_sample", id_report)
            ElseIf form_origin = "FormViewSampleAdjOut" Then
                FormViewSampleAdjOut.id_adj_out_sample = id_report
                FormViewSampleAdjOut.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormViewSampleAdjOut.action = "upd"
                FormViewSampleAdjOut.id_report_status = id_status_reportx
                FormViewSampleAdjOut.actionLoad()
                FormWork.viewAdjOutSample()
            End If
            'Catch ex As Exception
            'End Try
        ElseIf report_mark_type = "22" Then
            'Production Order
            query = String.Format("UPDATE tb_prod_order SET id_report_status='{0}' WHERE id_prod_order='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormProductionDet.id_report_status_g = id_status_reportx
                FormProductionDet.allow_status()
                FormProduction.view_production_order()
                FormProduction.GVProd.FocusedRowHandle = find_row(FormProduction.GVProd, "id_prod_order", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "23" Then
            'Production Work Order 
            Try
                If id_status_reportx = "6" Then
                    Dim query_upd_contact As String = ""
                    query_upd_contact += "Update tb_prod_order pdo INNER JOIN ( "
                    query_upd_contact += "Select If(wo.is_main_vendor ='1', ovh_prc.id_comp_contact,NULL) AS id_comp_contact, wo.id_prod_order "
                    query_upd_contact += "From tb_prod_order_wo wo "
                    query_upd_contact += "INNER Join tb_m_ovh_price ovh_prc On wo.id_ovh_price = ovh_prc.id_ovh_price "
                    query_upd_contact += "WHERE wo.id_prod_order_wo ='" + id_report + "' "
                    query_upd_contact += ") wo On pdo.id_prod_order = wo.id_prod_order "
                    query_upd_contact += "SET pdo.id_comp_contact_main=wo.id_comp_contact "
                    execute_non_query(query_upd_contact, True, "", "", "", "")
                End If

                query = String.Format("UPDATE tb_prod_order_wo Set id_report_status='{0}' WHERE id_prod_order_wo='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Status changed.")

                FormProductionWO.id_report_status_g = id_status_reportx
                FormProductionWO.allow_status()
                FormProductionDet.view_wo()
                FormProductionDet.GVProdWO.FocusedRowHandle = find_row(FormProductionDet.GVProdWO, "id_prod_order_wo", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "24" Then
            'Material PO PR
            query = String.Format("UPDATE tb_pr_mat_purc SET id_report_status='{0}' WHERE id_pr_mat_purc='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                If form_origin = "FormMatPRDet" Then
                    FormMatPRDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormMatPRDet.allow_status()
                    FormMatPR.view_mat_pr()
                    FormMatPR.view_mat_purc()
                    FormMatPR.view_mat_rec()
                Else
                    FormViewMatPR.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormWork.view_mat_pr()
                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "25" Then
            'Material WO PR
            query = String.Format("UPDATE tb_pr_mat_wo SET id_report_status='{0}' WHERE id_pr_mat_wo='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                If form_origin = "FormMatPRWODet" Then
                    FormMatPRWODet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormMatPRWODet.allow_status()
                    FormMatPRWO.view_mat_pr()
                    FormMatPRWO.view_mat_wo()
                    FormMatPRWO.view_mat_rec()
                Else
                    FormViewMatPRWO.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormWork.view_mat_pr_wo()
                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "26" Then
            'Material Adj In

            query = String.Format("UPDATE tb_adj_in_mat SET id_report_status='{0}' WHERE id_adj_in_mat='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                If form_origin = "FormMatAdjInSingle" Then
                    FormMatAdjInSingle.id_adj_in_mat = id_report
                    FormMatAdjInSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormMatAdjInSingle.action = "upd"
                    FormMatAdjInSingle.id_report_status = id_status_reportx
                    FormMatAdjInSingle.actionLoad()
                    FormMatAdj.viewAdjIn()
                ElseIf form_origin = "FormViewMatAdjIn" Then
                    FormViewMatAdjIn.id_adj_in_mat = id_report
                    FormViewMatAdjIn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormViewMatAdjIn.action = "upd"
                    FormViewMatAdjIn.id_report_status = id_status_reportx
                    FormViewMatAdjIn.actionLoad()
                    FormWork.viewMatAdjIn()
                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "27" Then
            'Material Adj Out
            Cursor = Cursors.WaitCursor
            If id_status_reportx = 5 Then 'Cancel
                Dim query_cancel As String = "SELECT * FROM tb_adj_out_mat a "
                query_cancel += "INNER JOIN tb_adj_out_mat_det b ON a.id_adj_out_mat = b.id_adj_out_mat "
                query_cancel += "WHERE a.id_adj_out_mat = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                    Dim adj_out_mat_det_qty As Decimal = data.Rows(i)("adj_out_mat_det_qty")
                    Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price").ToString
                    Dim adj_out_mat_det_price As Decimal = data.Rows(i)("adj_out_mat_det_price")
                    Dim adj_out_mat_number As String = data.Rows(i)("adj_out_mat_number").ToString
                    Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_mat_det_price,price,id_stock_status,report_mark_type,id_report) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + decimalSQL(adj_out_mat_det_qty.ToString) + "', NOW(), 'Material Adjustment Out cancelled, Adjustment Out : " + adj_out_mat_number + "','" & id_mat_det_price & "','" & decimalSQL(adj_out_mat_det_price.ToString) & "','2','27','" & id_report & "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                Next
            ElseIf id_status_reportx = 6 Then 'completed
                'stock
                Dim query_cancel As String = "SELECT * FROM tb_adj_out_mat a "
                query_cancel += "INNER JOIN tb_adj_out_mat_det b ON a.id_adj_out_mat = b.id_adj_out_mat "
                query_cancel += "WHERE a.id_adj_out_mat = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                    Dim adj_out_mat_det_qty As Decimal = data.Rows(i)("adj_out_mat_det_qty")
                    Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price").ToString
                    Dim adj_out_mat_det_price As Decimal = data.Rows(i)("adj_out_mat_det_price")
                    Dim adj_out_mat_number As String = data.Rows(i)("adj_out_mat_number").ToString
                    Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_mat_det_price,price,id_stock_status,report_mark_type,id_report) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + decimalSQL(adj_out_mat_det_qty.ToString) + "', NOW(), 'Completed, Adjustment Out : " + adj_out_mat_number + "','" & id_mat_det_price & "','" & decimalSQL(adj_out_mat_det_price.ToString) & "','2','27','" & id_report & "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")

                    query_upd_storage = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_mat_det_price,price,id_stock_status,report_mark_type,id_report) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '2', '" + id_mat_det + "', '" + decimalSQL(adj_out_mat_det_qty.ToString) + "', NOW(), 'Completed, Adjustment Out : " + adj_out_mat_number + "','" & id_mat_det_price & "','" & decimalSQL(adj_out_mat_det_price.ToString) & "','1','27','" & id_report & "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                Next
            End If

            query = String.Format("UPDATE tb_adj_out_mat SET id_report_status='{0}' WHERE id_adj_out_mat='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            If form_origin = "FormMatAdjOutSingle" Then
                FormMatAdjOutSingle.id_adj_out_mat = id_report
                FormMatAdjOutSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormMatAdjOutSingle.action = "upd"
                FormMatAdjOutSingle.id_report_status = id_status_reportx
                FormMatAdjOutSingle.actionLoad()
                FormMatAdj.viewAdjOut()
            ElseIf form_origin = "FormViewMatAdjOut" Then
                FormViewMatAdjOut.id_adj_out_mat = id_report
                FormViewMatAdjOut.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormViewMatAdjOut.action = "upd"
                FormViewMatAdjOut.id_report_status = id_status_reportx
                FormViewMatAdjOut.actionLoad()
                FormWork.viewMatAdjOut()
            End If
            Cursor = Cursors.Default
        ElseIf report_mark_type = "28" Then
            'prod receive qc
            Try
                If id_status_reportx = "6" Then
                    'generate unique
                    Dim query_gen As String = "CALL generate_prod_unique('" & id_report & "',1)"
                    execute_non_query(query_gen, True, "", "", "", "")
                    'delete empty data
                    For i As Integer = 0 To (FormProductionRecDet.GVListPurchase.RowCount - 1)
                        Dim id_prod_order_rec_det As String = FormProductionRecDet.GVListPurchase.GetRowCellValue(i, "id_prod_order_rec_det").ToString
                        Dim qty As Decimal = FormProductionRecDet.GVListPurchase.GetRowCellValue(i, "prod_order_rec_det_qty")
                        If qty = 0.0 Then
                            Dim query_del As String = "DELETE FROM tb_prod_order_rec_det WHERE id_prod_order_rec_det = '" + id_prod_order_rec_det + "'"
                            execute_non_query(query_del, True, "", "", "", "")
                        End If
                    Next
                End If

                query = String.Format("UPDATE tb_prod_order_rec SET id_report_status='{0}' WHERE id_prod_order_rec='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Status changed.")

                If form_origin = "FormProductionRecDet" Then
                    FormProductionRecDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormProductionRecDet.allow_status()
                    FormProductionRecDet.view_list_rec()
                    FormProductionRec.view_prod_order_rec()
                    FormProductionRec.GVProdRec.FocusedRowHandle = find_row(FormProductionRec.GVProdRec, "id_prod_order_rec", id_report)
                Else
                    FormViewProductionRec.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormWork.view_production_rec()
                End If
            Catch ex As Exception
                errorConnection()
            End Try
        ElseIf report_mark_type = "29" Then
            'Production MRS
            query = String.Format("UPDATE tb_prod_order_mrs SET id_report_status='{0}' WHERE id_prod_order_mrs='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormProductionMRS.id_report_status_g = id_status_reportx
                FormProductionMRS.allow_status()
                FormProductionDet.view_mrs()
                FormProductionDet.GVMRS.FocusedRowHandle = find_row(FormProductionDet.GVMRS, "id_prod_order_mrs", id_report)
                '
                FormMatMRSDet.id_report_status_g = id_status_reportx
                FormMatMRSDet.allow_status()
                FormMatMRSDet.view_mrs()
                FormMatMRS.GVMRS.FocusedRowHandle = find_row(FormMatMRS.GVMRS, "id_prod_order_mrs", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "30" Then
            'PL MRS Production
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If
            '
            If id_status_reportx = 5 Then 'Cancel
                'stock
                Dim query_cancel As String = "SELECT * FROM tb_pl_mrs a "
                query_cancel += "INNER JOIN tb_pl_mrs_det b ON a.id_pl_mrs = b.id_pl_mrs "
                query_cancel += "INNER JOIN tb_prod_order_mrs_det c ON b.id_prod_order_mrs_det = c.id_prod_order_mrs_det "
                query_cancel += "WHERE a.id_pl_mrs = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                    Dim pl_mrs_det_qty As String = decimalSQL(data.Rows(i)("pl_mrs_det_qty").ToString)
                    Dim pl_mrs_number As String = data.Rows(i)("pl_mrs_number").ToString
                    Dim pl_mrs_det_price As Decimal = data.Rows(i)("pl_mrs_det_price")
                    Dim id_mat_det_pricex As String = data.Rows(i)("id_mat_det_price").ToString
                    Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det,id_mat_det_price, price, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_stock_status,report_mark_type,id_report) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "','" + id_mat_det_pricex + "','" + decimalSQL(pl_mrs_det_price.ToString) + "', '" + decimalSQL(pl_mrs_det_qty) + "', NOW(), 'Out material was cancelled, PL : " + pl_mrs_number + "','2','" + report_mark_type + "','" + id_report + "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                Next
            ElseIf id_status_reportx = 6 Then 'completed
                'stock
                Dim query_cancel As String = "SELECT * FROM tb_pl_mrs a "
                query_cancel += "INNER JOIN tb_pl_mrs_det b ON a.id_pl_mrs = b.id_pl_mrs "
                query_cancel += "INNER JOIN tb_prod_order_mrs_det c ON b.id_prod_order_mrs_det = c.id_prod_order_mrs_det "
                query_cancel += "WHERE a.id_pl_mrs = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                    Dim pl_mrs_det_qty As Decimal = data.Rows(i)("pl_mrs_det_qty")
                    Dim pl_mrs_number As String = data.Rows(i)("pl_mrs_number").ToString
                    Dim pl_mrs_det_price As Decimal = data.Rows(i)("pl_mrs_det_price")
                    Dim id_mat_det_pricex As String = data.Rows(i)("id_mat_det_price").ToString
                    Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det,id_mat_det_price, price, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_stock_status,report_mark_type,id_report) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "','" + id_mat_det_pricex + "','" + decimalSQL(pl_mrs_det_price.ToString) + "', '" + decimalSQL(pl_mrs_det_qty.ToString) + "', NOW(), 'Completion of packing list, PL : " + pl_mrs_number + "','2','" + report_mark_type + "','" + id_report + "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                    query_upd_storage = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det,id_mat_det_price, price, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_stock_status,report_mark_type,id_report) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '2', '" + id_mat_det + "','" + id_mat_det_pricex + "','" + decimalSQL(pl_mrs_det_price.ToString) + "', '" + decimalSQL(pl_mrs_det_qty.ToString) + "', NOW(), 'Completion of packing list, PL : " + pl_mrs_number + "','1','" + report_mark_type + "','" + id_report + "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                Next
            End If

            query = String.Format("UPDATE tb_pl_mrs SET id_report_status='{0}' WHERE id_pl_mrs='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormMatPLSingle.id_report_status = id_status_reportx
                FormMatPLSingle.actionLoad()
                If FormMatPL.XTCPL.SelectedTabPageIndex = 0 Then 'production
                    FormMatPL.viewPL()
                    FormMatPL.GVProdPL.FocusedRowHandle = find_row(FormMatPL.GVProdPL, "id_pl_mrs", id_report)
                ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 1 Then 'wo
                    FormMatPL.viewPLWO()
                    FormMatPL.GVPLWO.FocusedRowHandle = find_row(FormMatPL.GVPLWO, "id_pl_mrs", id_report)
                Else 'other
                    FormMatPL.viewPLOther()
                    FormMatPL.GVPLOther.FocusedRowHandle = find_row(FormMatPL.GVPLOther, "id_pl_mrs", id_report)
                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "31" Then
            'Return Out FG

            'update status
            query = String.Format("UPDATE tb_prod_order_ret_out SET id_report_status='{0}' WHERE id_prod_order_ret_out ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            'delete qty =0
            If id_status_reportx > "2" Then
                Dim query_del As String = "DELETE FROM tb_prod_order_ret_out_det WHERE id_prod_order_ret_out='" + id_report + "' AND prod_order_ret_out_det_qty<='0.00' "
                execute_non_query(query_del, True, "", "", "", "")
            End If

            Try
                If form_origin = "FormProductionRetOutSingle" Then
                    FormProductionRetOutSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormProductionRetOutSingle.check_but()
                    FormProductionRetOutSingle.actionLoad()
                    FormProductionRet.viewRetOut()
                Else
                    FormViewProductionRetOut.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormWork.view_production_ret_out()
                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "32" Then
            'Return IN FG
            query = String.Format("UPDATE tb_prod_order_ret_in SET id_report_status='{0}' WHERE id_prod_order_ret_in ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                If form_origin = "FormProductionRetInSingle" Then
                    FormProductionRetInSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormProductionRetInSingle.check_but()
                    FormProductionRetInSingle.actionLoad()
                    FormProductionRet.viewRetIn()
                Else
                    'FormViewProductionRetIn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    'FormWork.view_production_ret_in()
                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "33" Then
            'PL FG TO WH
            query = String.Format("UPDATE tb_pl_prod_order SET id_report_status='{0}' WHERE id_pl_prod_order ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                If form_origin = "FormProductionPLToWHDet" Then
                    FormProductionPLToWHDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormProductionPLToWHDet.check_but()
                    FormProductionPLToWHDet.actionLoad()
                    FormProductionPLToWH.viewPL()
                Else

                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "34" Then
            'Invoice Mat PL MRS
            query = String.Format("UPDATE tb_inv_pl_mrs SET id_report_status='{0}' WHERE id_inv_pl_mrs ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormMatInvoiceDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormMatInvoiceDet.id_report_status_g = id_status_reportx
                FormMatInvoiceDet.allow_status()
                FormMatInvoice.viewInv()
                FormMatInvoice.GVProdInvoice.FocusedRowHandle = find_row(FormMatInvoice.GVProdInvoice, "id_inv_pl_mrs", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "35" Then
            'Retur invoice Mat PL MRS
            query = String.Format("UPDATE tb_inv_pl_mrs_ret SET id_report_status='{0}' WHERE id_inv_pl_mrs_ret ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormMatInvoiceReturDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormMatInvoiceReturDet.id_report_status_g = id_status_reportx
                FormMatInvoiceReturDet.allow_status()
                FormMatInvoice.view_retur()
                FormMatInvoice.GVProdInvoice.FocusedRowHandle = find_row(FormMatInvoice.GVProdInvoice, "id_inv_pl_mrs_ret", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "36" Then
            'Journal Entry
            query = String.Format("UPDATE tb_a_acc_trans SET id_report_status='{0}' WHERE id_acc_trans ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormAccountingJournalDet.id_report_status_g = id_status_reportx
                FormAccountingJournalDet.allow_status()
                FormAccountingJournal.view_entry(FormAccountingJournal.LEBilling.EditValue.ToString, Now.ToString("yyy-MM-dd"), Now.ToString("yyy-MM-dd"))
                FormAccountingJournal.GVAccTrans.FocusedRowHandle = find_row(FormAccountingJournal.GVAccTrans, "id_acc_trans", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "37" Then
            'Rec PL FG TO WH
            Try
                Dim ch_stt As ClassProductionPLToWHRec = New ClassProductionPLToWHRec()
                ch_stt.changeStatus(id_report, id_status_reportx)

                infoCustom("Status changed.")

                FormProductionPLToWHRecDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormProductionPLToWHRecDet.check_but()
                FormProductionPLToWHRecDet.actionLoad()
                FormProductionPLToWHRec.viewPL()
                FormProductionPLToWHRec.view_sample_purc()
            Catch ex As Exception
                errorProcess()
            End Try
        ElseIf report_mark_type = "39" Then
            'SALES Order
            If id_status_reportx = "5" Then
                Dim cancel As New ClassSalesOrder()
                cancel.cancelReservedStock(id_report)
            ElseIf id_status_reportx = "6" Then
                'created transfer
                Dim qv As String = "SELECT so.id_warehouse_contact_to, so.id_store_contact_to, so.id_sales_order, c.id_drawer_def 
                FROM tb_sales_order so 
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                WHERE so.id_sales_order=" + id_report + " AND so.id_so_status=5 AND c.is_only_for_alloc=1 "
                Dim dtv As DataTable = execute_query(qv, -1, True, "", "", "", "")
                If dtv.Rows.Count > 0 Then
                    For m As Integer = 0 To dtv.Rows.Count - 1
                        'main
                        Dim qm As String = "INSERT INTO tb_fg_trf(id_comp_contact_from, id_comp_contact_to, id_sales_order, fg_trf_number, fg_trf_date, fg_trf_date_rec, fg_trf_note, id_report_status, id_report_status_rec, id_wh_drawer, last_update, last_update_by) 
                        VALUES('" + dtv.Rows(m)("id_warehouse_contact_to").ToString + "', '" + dtv.Rows(m)("id_store_contact_to").ToString + "', '" + dtv.Rows(m)("id_sales_order").ToString + "', '" + header_number_sales("15") + "', NOW(), NOW(), '', '3', '3', '" + dtv.Rows(m)("id_drawer_def").ToString + "', NOW(), " + id_user + "); SELECT LAST_INSERT_ID(); "
                        Dim id_so As String = execute_query(qm, 0, True, "", "", "", "")
                        increase_inc_sales("15")

                        'detail
                        Dim qd As String = "INSERT INTO tb_fg_trf_det(id_fg_trf, id_product, id_sales_order_det, fg_trf_det_qty, fg_trf_det_qty_rec, fg_trf_det_qty_stored, fg_trf_det_note)
                        SELECT '" + id_so + "', sd.id_product, sd.id_sales_order_det, sd.sales_order_det_qty, sd.sales_order_det_qty, sd.sales_order_det_qty,'' 
                        FROM tb_sales_order_det sd 
                        WHERE sd.id_sales_order=" + dtv.Rows(m)("id_sales_order").ToString + " "
                        execute_non_query(qd, -1, True, "", "", "")
                    Next
                End If
            End If

            query = String.Format("UPDATE tb_sales_order SET id_report_status='{0}' WHERE id_sales_order ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            'Try
            If form_origin = "FormSalesOrderDet" Then
                FormSalesOrderDet.exportToBOF(False)
                FormSalesOrderDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesOrderDet.check_but()
                FormSalesOrderDet.actionLoad()
                FormSalesOrder.viewSalesOrder()
                FormSalesOrder.GVSalesOrder.FocusedRowHandle = find_row(FormSalesOrder.GVSalesOrder, "id_sales_order", id_report)
            Else

            End If
            'Catch ex As Exception
            'End Try
        ElseIf report_mark_type = "40" Then
            'Entry Journal
            query = String.Format("UPDATE tb_a_acc_trans_adj SET id_report_status='{0}' WHERE id_acc_trans_adj ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormAccountingJournalAdjDet.id_report_status_g = id_status_reportx
                FormAccountingJournalAdjDet.allow_status()
                FormAccountingJournalAdj.view_jurnal()
                FormAccountingJournalAdj.GVAccTrans.FocusedRowHandle = find_row(FormAccountingJournalAdj.GVAccTrans, "id_trans_adj", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "41" Then
            'FG Adj In
            If id_status_reportx = 6 Then 'completed
                Dim query_cancel As String = "SELECT * FROM tb_adj_in_fg a "
                query_cancel += "INNER JOIN tb_adj_in_fg_det b ON a.id_adj_in_fg = b.id_adj_in_fg "
                query_cancel += "WHERE a.id_adj_in_fg = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_product As String = data.Rows(i)("id_product").ToString
                    Dim adj_in_fg_det_qty As String = decimalSQL(data.Rows(i)("adj_in_fg_det_qty").ToString)
                    Dim adj_in_fg_det_price As String = decimalSQL(data.Rows(i)("adj_in_fg_det_price").ToString)
                    Dim adj_in_fg_number As String = data.Rows(i)("adj_in_fg_number").ToString

                    Dim query_upd_storage As String = ""
                    query_upd_storage = "INSERT tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, storage_product_qty, storage_product_datetime, storage_product_notes,report_mark_type,id_report,id_stock_status) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_product + "'," + adj_in_fg_det_price + ",'" + adj_in_fg_det_qty + "', NOW(), 'Completed, Adjustment In : " + adj_in_fg_number + "','41','" & id_report & "','1')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                Next
            End If

            query = String.Format("UPDATE tb_adj_in_fg SET id_report_status='{0}' WHERE id_adj_in_fg = '{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                If form_origin = "FormFGAdjInDet" Then
                    FormFGAdjInDet.id_adj_in_fg = id_report
                    FormFGAdjInDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormFGAdjInDet.action = "upd"
                    FormFGAdjInDet.id_report_status = id_status_reportx
                    FormFGAdjInDet.actionLoad()
                    FormFGAdj.viewAdjIn()
                ElseIf form_origin = "FormViewFGAdjIn" Then
                    'FormViewFGAdjIn.id_adj_in_fg = id_report
                    'FormViewFGAdjIn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    'FormViewFGAdjIn.action = "upd"
                    'FormViewFGAdjIn.id_report_status = id_status_reportx
                    'FormViewFGAdjIn.actionLoad()
                    'FormWork.viewMatAdjIn()
                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "42" Then
            'FG Adj Out
            Cursor = Cursors.WaitCursor
            If id_status_reportx = 5 Then 'Cancel
                Dim query_cancel As String = "SELECT * FROM tb_adj_out_fg a "
                query_cancel += "INNER JOIN tb_adj_out_fg_det b ON a.id_adj_out_fg = b.id_adj_out_fg "
                query_cancel += "WHERE a.id_adj_out_fg = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_product As String = data.Rows(i)("id_product").ToString
                    Dim adj_out_fg_det_qty As Decimal = data.Rows(i)("adj_out_fg_det_qty")
                    Dim adj_out_fg_det_price As Decimal = data.Rows(i)("adj_out_fg_det_price")
                    Dim adj_out_fg_number As String = data.Rows(i)("adj_out_fg_number").ToString
                    Dim query_upd_storage As String = "INSERT tb_storage_fg(id_wh_drawer, id_storage_category, id_product, storage_product_qty, storage_product_datetime, storage_product_notes, bom_unit_price,id_stock_status,report_mark_type,id_report) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_product + "', '" + decimalSQL(adj_out_fg_det_qty.ToString) + "', NOW(), 'Finished Goods Out cancelled, Adjustment Out : " + adj_out_fg_number + "','" & decimalSQL(adj_out_fg_det_price.ToString) & "','2','42','" & id_report & "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                Next
            ElseIf id_status_reportx = 6 Then 'completed
                'stock
                Dim query_cancel As String = "SELECT * FROM tb_adj_out_fg a "
                query_cancel += "INNER JOIN tb_adj_out_fg_det b ON a.id_adj_out_fg = b.id_adj_out_fg "
                query_cancel += "WHERE a.id_adj_out_fg = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_product As String = data.Rows(i)("id_product").ToString
                    Dim adj_out_fg_det_qty As Decimal = data.Rows(i)("adj_out_fg_det_qty")
                    Dim adj_out_fg_det_price As Decimal = data.Rows(i)("adj_out_fg_det_price")
                    Dim adj_out_fg_number As String = data.Rows(i)("adj_out_fg_number").ToString
                    Dim query_upd_storage As String = "INSERT tb_storage_fg(id_wh_drawer, id_storage_category, id_product, storage_product_qty, storage_product_datetime, storage_product_notes, bom_unit_price,id_stock_status,report_mark_type,id_report) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_product + "', '" + decimalSQL(adj_out_fg_det_qty.ToString) + "', NOW(), 'Completed, Adjustment Out : " + adj_out_fg_number + "','" & decimalSQL(adj_out_fg_det_price.ToString) & "','2','42','" & id_report & "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")

                    query_upd_storage = "INSERT tb_storage_fg(id_wh_drawer, id_storage_category, id_product, storage_product_qty, storage_product_datetime, storage_product_notes, bom_unit_price, id_stock_status, report_mark_type, id_report) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '2', '" + id_product + "', '" + decimalSQL(adj_out_fg_det_qty.ToString) + "', NOW(), 'Completed, Adjustment Out : " + adj_out_fg_number + "','" & decimalSQL(adj_out_fg_det_price.ToString) & "','1','42','" & id_report & "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                Next
            End If

            query = String.Format("UPDATE tb_adj_out_fg SET id_report_status='{0}' WHERE id_adj_out_fg='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            If form_origin = "FormFGAdjOutDet" Then
                FormFGAdjOutDet.id_adj_out_fg = id_report
                FormFGAdjOutDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGAdjOutDet.action = "upd"
                FormFGAdjOutDet.id_report_status = id_status_reportx
                FormFGAdjOutDet.actionLoad()
                FormFGAdj.viewAdjOut()
            End If
            Cursor = Cursors.Default
        ElseIf report_mark_type = "43" Then
            'SALES Del Order
            Dim stt As ClassSalesDelOrder = New ClassSalesDelOrder()
            stt.changeStatus(id_report, id_status_reportx)
            infoCustom("Status changed.")

            If form_origin = "FormSalesDelOrderDet" Then
                FormSalesDelOrderDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesDelOrderDet.check_but()
                FormSalesDelOrderDet.actionLoad()
                FormSalesDelOrder.viewSalesDelOrder()
                FormSalesDelOrder.GVSalesDelOrder.FocusedRowHandle = find_row(FormSalesDelOrder.GVSalesDelOrder, "id_pl_sales_order_del", id_report)
            Else
                'no code
            End If
        ElseIf report_mark_type = "44" Then
            'MRS WO
            query = String.Format("UPDATE tb_prod_order_mrs SET id_report_status='{0}' WHERE id_prod_order_mrs ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormMatMRSDet.id_report_status_g = id_status_reportx
                FormMatMRSDet.allow_status()
                If FormMatMRS.XTCMRS.SelectedTabPageIndex = 0 Then 'wo mat
                    FormMatMRS.view_mrs_wo()
                    FormMatMRS.GVMRSWO.FocusedRowHandle = find_row(FormMatMRS.GVMRSWO, "id_prod_order_mrs", id_report)
                ElseIf FormMatMRS.XTCMRS.SelectedTabPageIndex = 1 Then 'other
                    FormMatMRS.view_mrs()
                    FormMatMRS.GVMRS.FocusedRowHandle = find_row(FormMatMRS.GVMRS, "id_prod_order_mrs", id_report)
                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "45" Then
            'SALES Return Order
            Try
                query = String.Format("UPDATE tb_sales_return_order SET id_report_status='{0}' WHERE id_sales_return_order ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Status changed.")
            Catch ex As Exception
                errorConnection()
                Close()
            End Try

            If form_origin = "FormSalesReturnOrderDet" Then
                FormSalesReturnOrderDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesReturnOrderDet.check_but()
                FormSalesReturnOrderDet.actionLoad()
                FormSalesReturnOrder.viewSalesReturnOrder()
                FormSalesReturnOrder.GVSalesReturnOrder.FocusedRowHandle = find_row(FormSalesReturnOrder.GVSalesReturnOrder, "id_sales_return_order", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "46" Then
            'SALES RETURN
            Dim stt As ClassSalesReturn = New ClassSalesReturn()
            stt.changeStatus(id_report, id_status_reportx)
            infoCustom("Status changed.")

            If form_origin = "FormSalesReturnDet" Then
                FormSalesReturnDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesReturnDet.check_but()
                FormSalesReturnDet.actionLoad()
                FormSalesReturn.viewSalesReturn()
                FormSalesReturn.viewSalesReturnOrder()
                FormSalesReturn.GVSalesReturn.FocusedRowHandle = find_row(FormSalesReturn.GVSalesReturn, "id_sales_return", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "47" Then
            'Return Production
            query = String.Format("UPDATE tb_mat_prod_ret_in SET id_report_status='{0}' WHERE id_mat_prod_ret_in ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            If id_status_reportx = 6 Then 'Completed
                Dim query_del As String = "DELETE FROM tb_mat_prod_ret_in_det WHERE id_mat_prod_ret_in_det='" + id_report + "' AND mat_prod_ret_in_det_qty <= 0"
                execute_non_query(query_del, True, "", "", "", "")
                '
                Dim query_completed As String = "SELECT c.id_mat_det,b.id_mat_det_price,a.mat_prod_ret_in_det_price,a.mat_prod_ret_in_det_qty,d.id_wh_drawer,d.mat_prod_ret_in_number,IFNULL(cost.id_mat_det_price_cost,0) as id_mat_det_price_cost,IFNULL(cost.mat_det_price_cost,0.0) as mat_det_price_cost FROM tb_mat_prod_ret_in_det a "
                query_completed += "INNER JOIN tb_pl_mrs_det b ON a.id_pl_mrs_det = b.id_pl_mrs_det "
                query_completed += "INNER JOIN tb_m_mat_det_price c ON c.id_mat_det_price = b.id_mat_det_price "
                query_completed += "INNER JOIN tb_mat_prod_ret_in d ON d.id_mat_prod_ret_in = a.id_mat_prod_ret_in "
                query_completed += "LEFT JOIN( "
                query_completed += "SELECT id_mat_det_price as id_mat_det_price_cost,mat_det_price as mat_det_price_cost,id_mat_det FROM tb_m_mat_det_price WHERE is_default_cost=1 "
                query_completed += ") cost ON cost.id_mat_det=c.id_mat_det "
                query_completed += "WHERE a.id_mat_prod_ret_in = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_completed, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                    Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price_cost").ToString
                    Dim mat_det_price As Decimal = data.Rows(i)("mat_det_price_cost")
                    Dim mat_wo_rec_det_qty As String = data.Rows(i)("mat_prod_ret_in_det_qty").ToString
                    Dim mat_wo_rec_number As String = data.Rows(i)("mat_prod_ret_in_number").ToString
                    Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_report,report_mark_type,id_stock_status,id_mat_det_price,price) "
                    'update storage
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + mat_wo_rec_det_qty + "', NOW(), 'Completed, Material Return In Production Receive No. : " + mat_wo_rec_number + "','" + id_report + "','" + report_mark_type + "','1','" + id_mat_det_price + "','" + decimalSQL(mat_det_price.ToString) + "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                    'update stored
                Next
            End If
            infoCustom("Status changed.")
            Try
                FormMatRetInProd.id_report_status = id_status_reportx
                FormMatRetInProd.allow_status()
                FormMatRet.viewRetInProd()
                FormMatRet.GVRetInProd.FocusedRowHandle = find_row(FormMatRet.GVRetInProd, "id_mat_prod_ret_in", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "48" Then
            'SALES POS
            If id_status_reportx = "5" Then
                'cancelled
                Dim cancel_rsv_stock As ClassSalesInv = New ClassSalesInv()
                cancel_rsv_stock.cancelReservedStock(id_report, "48")
            ElseIf id_status_reportx = "6" Then
                'completed
                Dim complete_rsv_stock As ClassSalesInv = New ClassSalesInv()
                complete_rsv_stock.completeReservedStock(id_report, "48")
            End If

            'update status
            query = String.Format("UPDATE tb_sales_pos SET id_report_status='{0}' WHERE id_sales_pos ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            If form_origin = "FormSalesPOSDet" Then
                FormSalesPOSDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesPOSDet.check_but()
                FormSalesPOSDet.actionLoad()
                FormSalesPOS.viewSalesPOS()
                FormSalesPOS.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPOS.GVSalesPOS, "id_sales_pos", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "49" Then
            'SALES RETURN QC
            Dim st As ClassSalesReturnQC = New ClassSalesReturnQC()
            st.changeStatus(id_report, id_status_reportx)
            infoCustom("Status changed.")

            If form_origin = "FormSalesReturnQCDet" Then
                FormSalesReturnQCDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesReturnQCDet.check_but()
                FormSalesReturnQCDet.actionLoad()
                FormSalesReturnQC.viewSalesReturnQC()
                FormSalesReturnQC.GVSalesReturnQC.FocusedRowHandle = find_row(FormSalesReturnQC.GVSalesReturnQC, "id_sales_return_qc", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "50" Then
            'Return Production
            query = String.Format("UPDATE tb_pr_prod_order SET id_report_status='{0}' WHERE id_pr_prod_order ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormProdPRWODet.id_report_status = id_status_reportx
                FormProdPRWODet.allow_status()
                FormProdPRWO.view_pr()
                FormProdPRWO.GVMatPR.FocusedRowHandle = find_row(FormProdPRWO.GVMatPR, "id_pr_prod_order", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "51" Then
            'SALES INVOICE
            Try
                query = String.Format("UPDATE tb_sales_invoice SET id_report_status='{0}' WHERE id_sales_invoice ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Status changed.")

                If form_origin = "FormSalesInvoiceDet" Then
                    FormSalesInvoiceDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormSalesInvoiceDet.check_but()
                    FormSalesInvoiceDet.actionLoad()
                    FormSalesInvoice.viewSalesInvoice()
                    FormSalesInvoice.GVSalesInvoice.FocusedRowHandle = find_row(FormSalesInvoice.GVSalesInvoice, "id_sales_invoice", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "52" Then
            'Mat Stock Opname
            query = String.Format("UPDATE tb_mat_so SET id_report_status='{0}' WHERE id_mat_so ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
            Try
                FormMatStockOpnameDet.id_report_status = id_status_reportx
                FormMatStockOpnameDet.allow_status()
                FormMatStockOpnameResultDet.id_report_status = id_status_reportx
                FormMatStockOpnameResultDet.allow_status()
                FormMatStockOpname.view_so()
                FormMatStockOpname.GVMatPR.FocusedRowHandle = find_row(FormMatStockOpname.GVMatPR, "id_mat_so", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "53" Then
            'FG SO STORE
            Try
                query = String.Format("UPDATE tb_fg_so_store SET id_report_status='{0}' WHERE id_fg_so_store ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Status changed.")

                If form_origin = "FormFGStockOpnameStoreDet" Then
                    'FormSalesInvoiceDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    ' FormFGStockOpnameStoreDet.check_but()
                    FormFGStockOpnameStoreDet.actionLoad()
                    FormFGStockOpnameStore.viewSoStore()
                    FormFGStockOpnameStore.GVSOStore.FocusedRowHandle = find_row(FormFGStockOpnameStore.GVSOStore, "id_fg_so_store", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "54" Then
            'FG MISSING
            Try
                If id_status_reportx = "5" Then
                    'cancelled
                    Dim cancel_rsv_stock As ClassSalesInv = New ClassSalesInv()
                    cancel_rsv_stock.cancelReservedStock(id_report, "54")
                ElseIf id_status_reportx = "6" Then
                    'completed
                    Dim complete_rsv_stock As ClassSalesInv = New ClassSalesInv()
                    complete_rsv_stock.completeReservedStock(id_report, "54")
                End If

                query = String.Format("UPDATE tb_sales_pos SET id_report_status='{0}' WHERE id_sales_pos ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Status changed.")

                If form_origin = "FormFGMissingDet" Then
                    FormFGMissingDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormFGMissingDet.check_but()
                    FormFGMissingDet.actionLoad()
                    FormFGMissing.viewFGMissing()
                    FormFGMissing.GVFGMissing.FocusedRowHandle = find_row(FormFGMissing.GVFGMissing, "id_sales_pos", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "55" Then
            'FG MISSING INVOICE
            Try
                query = String.Format("UPDATE tb_fg_missing_invoice SET id_report_status='{0}' WHERE id_fg_missing_invoice ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Status changed.")

                If form_origin = "FormFGMissingInvoiceDet" Then
                    FormFGMissingInvoiceDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormFGMissingInvoiceDet.check_but()
                    FormFGMissingInvoiceDet.actionLoad()
                    FormFGMissingInvoice.viewFGMissingInvoice()
                    FormFGMissingInvoice.GVFGMissingInvoice.FocusedRowHandle = find_row(FormFGMissingInvoice.GVFGMissingInvoice, "id_fg_missing_invoice", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "56" Then
            'FG SO WH
            Try
                query = String.Format("UPDATE tb_fg_so_wh SET id_report_status='{0}' WHERE id_fg_so_wh ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Status changed.")

                If form_origin = "FormFGStockOpnameWHDet" Then
                    'FormSalesInvoiceDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    ' FormFGStockOpnameStoreDet.check_but()
                    FormFGStockOpnameWHDet.actionLoad()
                    FormFGStockOpnameWH.viewSOWH()
                    FormFGStockOpnameWH.GVSOWH.FocusedRowHandle = find_row(FormFGStockOpnameWH.GVSOWH, "id_fg_so_wh", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "57" Then
            'TRANSFER
            Dim stt As ClassFGTrf = New ClassFGTrf()
            stt.changeStatus(id_report, id_status_reportx)
            infoCustom("Status changed.")

            If form_origin = "FormFGTrfDet" Then
                FormFGTrfDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGTrfDet.check_but()
                FormFGTrfDet.actionLoad()
                FormFGTrf.viewFGTrf()
                FormFGTrf.GVFGTrf.FocusedRowHandle = find_row(FormFGTrf.GVFGTrf, "id_fg_trf", id_report)
            ElseIf form_origin = "FormFGTrfNewDet" Then
                FormFGTrfNewDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGTrfNewDet.check_but()
                FormFGTrfNewDet.actionLoad()
                FormFGTrfNew.viewFGTrf()
                FormFGTrfNew.GVFGTrf.FocusedRowHandle = find_row(FormFGTrfNew.GVFGTrf, "id_fg_trf", id_report)
            Else
                'no code
            End If
        ElseIf report_mark_type = "58" Then
            'REC TRF
            Try
                If id_status_reportx = "6" Then
                    ' jika complete
                    Dim query_save_st As String = ""
                    query_save_st += "INSERT INTO tb_storage_fg(id_wh_drawer,id_storage_category,id_product,bom_unit_price,report_mark_type,id_report,storage_product_qty,storage_product_datetime,storage_product_notes,id_stock_status) "
                    query_save_st += "SELECT trf.id_wh_drawer, '1', trf_det.id_product, dsg.design_cop, '58', '" + id_report + "', trf_det.fg_trf_det_qty_rec, "
                    query_save_st += "NOW(), CONCAT('Receive Transfer Completed, No : ', trf.fg_trf_number), '1' "
                    query_save_st += "FROM tb_fg_trf_det trf_det "
                    query_save_st += "INNER JOIN tb_fg_trf trf ON trf.id_fg_trf = trf_det.id_fg_trf "
                    query_save_st += "INNER JOIN tb_m_product prd ON prd.id_product = trf_det.id_product "
                    query_save_st += "INNER JOIN tb_m_design dsg ON dsg.id_design = prd.id_design "
                    query_save_st += "WHERE trf.id_fg_trf = '" + id_report + "' "
                    execute_non_query(query_save_st, True, "", "", "", "")
                End If

                query = String.Format("UPDATE tb_fg_trf SET id_report_status_rec='{0}' WHERE id_fg_trf ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Status changed.")

                If form_origin = "FormFGTrfDet" Then
                    FormFGTrfDet.LEReportStatus2.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormFGTrfDet.check_but()
                    FormFGTrfDet.actionLoad()
                    FormFGTrfReceive.viewFGTrf()
                    FormFGTrfReceive.GVFGTrf.FocusedRowHandle = find_row(FormFGTrfReceive.GVFGTrf, "id_fg_trf", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "60" Then
            'PL SAMPLE DEL
            query = String.Format("UPDATE tb_sample_del SET id_report_status='{0}' WHERE id_sample_del ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'rollback stock if cancelled and complerted
            If id_status_reportx = "5" Then
                Dim query_drawer As String = "SELECT c.sample_del_number, b.id_sample, a.id_wh_drawer, a.sample_del_det_drawer_qty,a.id_sample_price, a.sample_price FROM tb_sample_del_det_drawer a "
                query_drawer += "INNER JOIN tb_sample_del_det b ON a.id_sample_del_det = b.id_sample_del_det "
                query_drawer += "INNER JOIN tb_sample_del c ON c.id_sample_del = b.id_sample_del "
                query_drawer += "WHERE b.id_sample_del = '" + id_report + "' "
                Dim data_drawer As DataTable = execute_query(query_drawer, -1, True, "", "", "", "")

                'prepare rollback stock
                Dim query_drawer_stock As String = ""
                Dim jum_ins_c As Integer = 0
                If data_drawer.Rows.Count > 0 Then
                    query_drawer_stock = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) VALUES "
                End If
                For c As Integer = 0 To (data_drawer.Rows.Count - 1)
                    If c > 0 Then
                        query_drawer_stock += ", "
                    End If
                    query_drawer_stock += "('" + data_drawer(c)("id_wh_drawer").ToString + "', '1', '" + data_drawer(c)("id_sample").ToString + "', '" + decimalSQL(data_drawer(c)("sample_del_det_drawer_qty").ToString) + "', NOW(), 'PL sample Delivery No: " + data_drawer(c)("sample_del_number").ToString + ", has been canceled', '" + data_drawer(c)("id_sample_price").ToString + "','" + decimalSQL(data_drawer(c)("sample_price").ToString) + "', '60', '" + id_report + "', '2') "
                Next

                'excequte rollback
                If data_drawer.Rows.Count > 0 Then
                    execute_non_query(query_drawer_stock, True, "", "", "", "")
                End If
            ElseIf id_status_reportx = "6" Then
                Dim query_drawer As String = "SELECT c.sample_del_number, b.id_sample, a.id_wh_drawer, a.sample_del_det_drawer_qty, a.id_sample_price, a.sample_price FROM tb_sample_del_det_drawer a "
                query_drawer += "INNER JOIN tb_sample_del_det b ON a.id_sample_del_det = b.id_sample_del_det "
                query_drawer += "INNER JOIN tb_sample_del c ON c.id_sample_del = b.id_sample_del "
                query_drawer += "WHERE b.id_sample_del = '" + id_report + "' "
                Dim data_drawer As DataTable = execute_query(query_drawer, -1, True, "", "", "", "")

                'prepare rollback stock
                Dim query_drawer_stock_reserved As String = ""
                Dim query_drawer_stock_preparedx As String = ""
                Dim jum_ins_c As Integer = 0
                If data_drawer.Rows.Count > 0 Then
                    query_drawer_stock_reserved = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) VALUES "
                    query_drawer_stock_preparedx = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) VALUES "
                End If
                For c As Integer = 0 To (data_drawer.Rows.Count - 1)
                    If c > 0 Then
                        query_drawer_stock_reserved += ", "
                        query_drawer_stock_preparedx += ", "
                    End If
                    query_drawer_stock_reserved += "('" + data_drawer(c)("id_wh_drawer").ToString + "', '1', '" + data_drawer(c)("id_sample").ToString + "', '" + decimalSQL(data_drawer(c)("sample_del_det_drawer_qty").ToString) + "', NOW(), 'PL Sample Delivery Completed and delete reserved stock, no : " + data_drawer(c)("sample_del_number").ToString + "',  '" + data_drawer(c)("id_sample_price").ToString + "', '" + decimalSQL(data_drawer(c)("sample_price").ToString) + "', '60', '" + id_report + "', '2') "
                    query_drawer_stock_preparedx += "('" + data_drawer(c)("id_wh_drawer").ToString + "', '2', '" + data_drawer(c)("id_sample").ToString + "', '" + decimalSQL(data_drawer(c)("sample_del_det_drawer_qty").ToString) + "', NOW(), 'PL Sample Delivery, no : " + data_drawer(c)("sample_del_number").ToString + "', '" + data_drawer(c)("id_sample_price").ToString + "','" + decimalSQL(data_drawer(c)("sample_price").ToString) + "', '60', '" + id_report + "', '1') "
                Next

                'excequte
                If data_drawer.Rows.Count > 0 Then
                    execute_non_query(query_drawer_stock_reserved, True, "", "", "", "")
                    execute_non_query(query_drawer_stock_preparedx, True, "", "", "", "")
                End If
            End If

            infoCustom("Status changed.")

            If form_origin = "FormSampleDelDet" Then
                FormSampleDelDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleDelDet.check_but()
                FormSampleDelDet.actionLoad()
                FormSampleDel.viewSampleDel()
                FormSampleDel.GVSampleDel.FocusedRowHandle = find_row(FormSampleDel.GVSampleDel, "id_sample_del", id_report)
            Else
                'no code
            End If
        ElseIf report_mark_type = "61" Then
            'RECEIVING SAMPLE DEL
            Try
                query = String.Format("UPDATE tb_sample_del_rec SET id_report_status='{0}' WHERE id_sample_del_rec ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Status changed.")

                If form_origin = "FormSampleDelRecDet" Then
                    FormSampleDelRecDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormSampleDelRecDet.actionLoad()
                    FormSampleDelRec.viewSampleDel()
                    FormSampleDelRec.viewSampleDelRec()
                    FormSampleDelRec.GVSampleDelRec.FocusedRowHandle = find_row(FormSampleDelRec.GVSampleDelRec, "id_sample_del_rec", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "62" Then
            'SO SAMPLE ORDER
            Try
                query = String.Format("UPDATE tb_sample_order SET id_report_status='{0}' WHERE id_sample_order ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Status changed.")

                If form_origin = "FormSampleOrderDet" Then
                    FormSampleOrderDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormSampleOrderDet.actionLoad()
                    FormSampleOrder.viewSampleOrder()
                    FormSampleOrder.GVSampleOrder.FocusedRowHandle = find_row(FormSampleOrder.GVSampleOrder, "id_sample_order", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "63" Then
            ' DELIVERY ORDER SAMPLE FOR SALES
            query = String.Format("UPDATE tb_pl_sample_order_del SET id_report_status='{0}' WHERE id_pl_sample_order_del ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'rollback stock if cancelled and complerted
            If id_status_reportx = "5" Then
                Dim query_c As ClassSampleDelOrder = New ClassSampleDelOrder
                Dim query_drawer As String = query_c.queryDetailDrawer("AND a1.id_pl_sample_order_del = ''" + id_report + "''", "1")
                Dim data_drawer As DataTable = execute_query(query_drawer, -1, True, "", "", "", "")

                'prepare rollback stock
                Dim query_drawer_stock As String = ""
                Dim jum_ins_c As Integer = 0
                If data_drawer.Rows.Count > 0 Then
                    query_drawer_stock = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) VALUES "
                End If
                For c As Integer = 0 To (data_drawer.Rows.Count - 1)
                    If c > 0 Then
                        query_drawer_stock += ", "
                    End If
                    query_drawer_stock += "('" + data_drawer(c)("id_wh_drawer").ToString + "', '1', '" + data_drawer(c)("id_sample").ToString + "', '" + decimalSQL(data_drawer(c)("qty_all_sample").ToString) + "', NOW(), 'Delivery Order Sample No: " + data_drawer(c)("pl_sample_order_del_number").ToString + ", has been canceled', '" + data_drawer(c)("id_sample_price").ToString + "','" + decimalSQL(data_drawer(c)("sample_price").ToString) + "', '63', '" + id_report + "', '2') "
                Next

                'excequte rollback
                If data_drawer.Rows.Count > 0 Then
                    execute_non_query(query_drawer_stock, True, "", "", "", "")
                End If
            ElseIf id_status_reportx = "6" Then
                Dim query_c As ClassSampleDelOrder = New ClassSampleDelOrder
                Dim query_drawer As String = query_c.queryDetailDrawer("AND a1.id_pl_sample_order_del = ''" + id_report + "''", "1")
                Dim data_drawer As DataTable = execute_query(query_drawer, -1, True, "", "", "", "")

                'prepare rollback stock
                Dim query_drawer_stock_reserved As String = ""
                Dim query_drawer_stock_preparedx As String = ""
                Dim jum_ins_c As Integer = 0
                If data_drawer.Rows.Count > 0 Then
                    query_drawer_stock_reserved = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) VALUES "
                    query_drawer_stock_preparedx = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) VALUES "
                End If
                For c As Integer = 0 To (data_drawer.Rows.Count - 1)
                    If c > 0 Then
                        query_drawer_stock_reserved += ", "
                        query_drawer_stock_preparedx += ", "
                    End If
                    query_drawer_stock_reserved += "('" + data_drawer(c)("id_wh_drawer").ToString + "', '1', '" + data_drawer(c)("id_sample").ToString + "', '" + decimalSQL(data_drawer(c)("qty_all_sample").ToString) + "', NOW(), 'Delivery Order Sample Completed and delete reserved stock, no : " + data_drawer(c)("pl_sample_order_del_number").ToString + "',  '" + data_drawer(c)("id_sample_price").ToString + "', '" + decimalSQL(data_drawer(c)("sample_price").ToString) + "', '63', '" + id_report + "', '2') "
                    query_drawer_stock_preparedx += "('" + data_drawer(c)("id_wh_drawer").ToString + "', '2', '" + data_drawer(c)("id_sample").ToString + "', '" + decimalSQL(data_drawer(c)("qty_all_sample").ToString) + "', NOW(), 'Delivery Order Sample, no : " + data_drawer(c)("pl_sample_order_del_number").ToString + "', '" + data_drawer(c)("id_sample_price").ToString + "','" + decimalSQL(data_drawer(c)("sample_price").ToString) + "', '63', '" + id_report + "', '1') "
                Next

                'excequte
                If data_drawer.Rows.Count > 0 Then
                    execute_non_query(query_drawer_stock_reserved, True, "", "", "", "")
                    execute_non_query(query_drawer_stock_preparedx, True, "", "", "", "")
                End If
            End If

            infoCustom("Status changed.")

            If form_origin = "FormSampleDelOrderDet" Then
                FormSampleDelOrderDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleDelOrderDet.check_but()
                FormSampleDelOrderDet.actionLoad()
                FormSampleDelOrder.viewSampleDelOrder()
                FormSampleDelOrder.viewSampleOrder()
                FormSampleDelOrder.GVSampleDelOrder.FocusedRowHandle = find_row(FormSampleDelOrder.GVSampleDelOrder, "id_pl_sample_order_del", id_report)
            Else
                'no code
            End If
        ElseIf report_mark_type = "64" Then
            'SAMPLE SO
            Try
                query = String.Format("UPDATE tb_sample_so SET id_report_status='{0}' WHERE id_sample_so ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Status changed.")

                If form_origin = "FormSampleStockOpname" Then
                    FormSampleStockOpnameDet.actionLoad()
                    FormSampleStockOpname.viewSOWH()
                    FormSampleStockOpname.GVSOWH.FocusedRowHandle = find_row(FormSampleStockOpname.GVSOWH, "id_sample_so", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "65" Then
            'CODE REPLACEMENT
            'action complete
            If id_status_reportx = "6" Then
                Dim query_replace As String = "CALL generate_replace_barcode('" + id_report + "')"
                execute_non_query(query_replace, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_fg_code_replace_store SET id_report_status='{0}' WHERE id_fg_code_replace_store ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            If form_origin = "FormFGCodeReplaceStoreDet" Then
                FormFGCodeReplaceStoreDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGCodeReplaceStoreDet.check_but()
                FormFGCodeReplaceStoreDet.actionLoad()
                FormFGCodeReplace.viewCodeReplaceStore()
                FormFGCodeReplace.GVFGCodeReplaceStore.FocusedRowHandle = find_row(FormFGCodeReplace.GVFGCodeReplaceStore, "id_fg_code_replace_store", id_report)
            Else
                'no code
            End If
        ElseIf report_mark_type = "66" Then
            'SALES CREDIT NOTE
            Try
                If id_status_reportx = "6" Then
                    'completed
                    Dim stc_in As ClassSalesInv = New ClassSalesInv()
                    stc_in.completeInStock(id_report, "66")
                End If

                query = String.Format("UPDATE tb_sales_pos SET id_report_status='{0}' WHERE id_sales_pos ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Status changed.")

                If form_origin = "FormSalesCreditNoteDet" Then
                    FormSalesCreditNoteDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormSalesCreditNoteDet.check_but()
                    FormSalesCreditNoteDet.actionLoad()
                    FormSalesCreditNote.viewSalesPOS()
                    FormSalesCreditNote.GVSalesPOS.FocusedRowHandle = find_row(FormSalesCreditNote.GVSalesPOS, "id_sales_pos", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "67" Then
            'MISSING CREDIT NOTE
            Try
                query = String.Format("UPDATE tb_sales_pos SET id_report_status='{0}' WHERE id_sales_pos ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Status changed.")

                If form_origin = "FormFGMissingCreditNoteStoreDet" Then
                    FormFGMissingCreditNoteStoreDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormFGMissingCreditNoteStoreDet.check_but()
                    FormFGMissingCreditNoteStoreDet.actionLoad()
                    FormFGMissingCreditNote.viewFGMissingStoreCN()
                    FormFGMissingCreditNote.GVFGMissingCNStore.FocusedRowHandle = find_row(FormFGMissingCreditNote.GVFGMissingCNStore, "id_sales_pos", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "68" Then
            'CODE REPLACEMENT WH
            'action complete
            If id_status_reportx = "6" Then
                Dim query_replace As String = "CALL generate_replace_barcode_wh('" + id_report + "')"
                execute_non_query(query_replace, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_fg_code_replace_wh SET id_report_status='{0}' WHERE id_fg_code_replace_wh ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            If form_origin = "FormFGCodeReplaceWHDet" Then
                FormFGCodeReplaceWHDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGCodeReplaceWHDet.check_but()
                FormFGCodeReplaceWHDet.actionLoad()
                FormFGCodeReplace.viewCodeReplaceWH()
                FormFGCodeReplace.GVFGCodeReplaceWH.FocusedRowHandle = find_row(FormFGCodeReplace.GVFGCodeReplaceWH, "id_fg_code_replace_wh", id_report)
            Else
                'no code
            End If
        ElseIf report_mark_type = "69" Then
            'FG WRITE OFF
            If id_status_reportx = "5" Then
                Dim query_c As ClassFGWoff = New ClassFGWoff()
                Dim query_roll As String = query_c.queryRollbackStock(id_report)
                execute_non_query(query_roll, True, "", "", "", "")
            ElseIf id_status_reportx = "6" Then
                Dim query_c As ClassFGWoff = New ClassFGWoff()
                Dim query_out As String = query_c.queryCompletedStock(id_report)
                execute_non_query(query_out, True, "", "", "", "")
            End If

            'cheange status
            query = String.Format("UPDATE tb_fg_woff SET id_report_status='{0}' WHERE id_fg_woff ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            If form_origin = "FormFGWoffDet" Then
                FormFGWoffDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGWoffDet.check_but()
                FormFGWoffDet.actionLoad()
                FormFGWoff.viewFGWoff()
                FormFGWoff.GVFGWoff.FocusedRowHandle = find_row(FormFGWoff.GVFGWoff, "id_fg_woff", id_report)
            End If
        ElseIf report_mark_type = "70" Then
            'FG PROPOSE PRICE
            query = String.Format("UPDATE tb_fg_propose_price SET id_report_status='{0}' WHERE id_fg_propose_price ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            'post ke master price if completed
            If id_status_reportx = "6" Then
                Dim q_post As String = "CALL generate_pp_normal_final('" + id_report + "', '" + id_user + "')"
                execute_non_query(q_post, True, "", "", "", "")
            End If

            If form_origin = "FormFGProposePriceDet" Then
                FormFGProposePriceDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGProposePriceDet.check_but_imp()
                FormFGProposePriceDet.check_but_loc()
                FormFGProposePriceDet.actionLoad()
                FormFGProposePrice.viewPropose()
                FormFGProposePrice.GVFGPropose.FocusedRowHandle = find_row(FormFGProposePrice.GVFGPropose, "id_fg_propose_price", id_report)
            End If
        ElseIf report_mark_type = "72" Then
            'QC Adj In
            query = String.Format("UPDATE tb_prod_order_qc_adj_in SET id_report_status='{0}' WHERE id_prod_order_qc_adj_in ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            If form_origin = "FormProdQCAdjIn" Then
                FormProdQCAdjIn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormProdQCAdjIn.actionLoad()
                FormProdQCAdj.viewAdjIn()
                FormProdQCAdj.GVAdjIn.FocusedRowHandle = find_row(FormProdQCAdj.GVAdjIn, "id_prod_order_qc_adj_in", id_report)
            Else
                FormViewProdQCAdjIn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            End If
        ElseIf report_mark_type = "73" Then
            'QC Adj Out
            query = String.Format("UPDATE tb_prod_order_qc_adj_out SET id_report_status='{0}' WHERE id_prod_order_qc_adj_out ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            If form_origin = "FormProdQCAdjOut" Then
                FormProdQCAdjOut.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormProdQCAdjOut.actionLoad()
                FormProdQCAdj.viewAdjOut()
                FormProdQCAdj.GVAdjOut.FocusedRowHandle = find_row(FormProdQCAdj.GVAdjOut, "id_prod_order_qc_adj_out", id_report)
            Else
                FormViewProdQcAdjOut.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            End If
        ElseIf report_mark_type = "75" Then
            'ANALISIS SO
            If id_status_reportx = "6" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This process will create prepare order new product documents automatically. Are you sure to continue this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    PBC.Visible = True

                    'delete mark
                    Dim query_del_mark As String = ""
                    query_del_mark += "DELETE "
                    query_del_mark += "FROM tb_report_mark "
                    query_del_mark += "WHERE id_report IN ( "
                    query_del_mark += "SELECT * FROM ( "
                    query_del_mark += "select id_sales_order from tb_sales_order a where a.id_fg_so_reff='" + id_report + "' "
                    query_del_mark += ") a "
                    query_del_mark += ") AND report_mark_type='39' "
                    execute_non_query(query_del_mark, True, "", "", "", "")

                    'delete prepare order terkait 
                    Dim query_del As String = "DELETE FROM tb_sales_order WHERE id_fg_so_reff='" + id_report + "' "
                    execute_non_query(query_del, True, "", "", "", "")

                    'get product
                    Dim ix As Integer = 0
                    Dim id_product_sel As String = ""
                    For j As Integer = 0 To ((FormFGSalesOrderReffDet.GVDesign.RowCount - 1) - GetGroupRowCount(FormFGSalesOrderReffDet.GVDesign)) 'looping product
                        Dim id_product As String = FormFGSalesOrderReffDet.GVDesign.GetRowCellValue(j, "id_product").ToString
                        If ix > 0 Then
                            id_product_sel += "OR "
                        End If
                        id_product_sel += "ds.id_product = '" + id_product + "' "
                        ix += 1
                    Next

                    'looping based on store
                    Dim str_err As String = ""
                    Dim sales_order_reff As String = ""
                    Dim data_fg_store As DataTable = FormFGSalesOrderReffDet.GCDesign.DataSource

                    If data_fg_store.Rows.Count > 0 Then
                        PBC.Properties.Minimum = 0
                        PBC.Properties.Maximum = data_fg_store.Rows.Count - 1
                        PBC.Properties.Step = 1
                        PBC.Properties.PercentView = True
                    End If

                    Dim cond_success As Boolean = False
                    Dim nx As Integer = 0
                    Dim min_so As Integer = 0 'utk melihat minimal SO
                    For i As Integer = 0 To data_fg_store.Columns.Count - 1 'looping account
                        Dim col As String = data_fg_store.Columns(i).ToString
                        If col.Contains("#id#") Then
                            nx += 1
                            Dim col_foc_arr As String() = Split(col, "#id#")
                            Try
                                Dim id_sales_order As String = "0"
                                Dim id_delivery As String = FormFGSalesOrderReffDet.SLEDel.EditValue.ToString
                                Dim id_store_to As String = col_foc_arr(1)
                                Dim id_store_contact_to As String = get_company_x(id_store_to, "6")
                                Dim id_warehouse_contact_to As String = FormFGSalesOrderReffDet.id_comp_contact_par
                                Dim id_so_type As String = col_foc_arr(3)
                                Dim id_so_cat As String = col_foc_arr(4)
                                Dim id_so_status As String = "1"
                                If id_so_cat = "1" Then
                                    id_so_status = "1"
                                Else
                                    id_so_status = "5"
                                End If


                                'cek harus dibuat so atau tidak
                                Dim query_cek_so As String = ""
                                query_cek_so += "SELECT SUM(ds.fg_so_reff_det_qty) AS `tot_ds` FROM tb_fg_so_reff_det ds "
                                query_cek_so += "INNER JOIN tb_fg_ds_store ds_store ON ds.id_fg_ds_store = ds_store.id_fg_ds_store "
                                query_cek_so += "INNER JOIN tb_m_comp comp ON comp.id_comp = ds_store.id_comp "
                                query_cek_so += "WHERE ds.id_fg_so_reff='" + id_report + "' AND ds_store.id_season='" + FormFGSalesOrderReffDet.SLESeason.EditValue.ToString + "' "
                                query_cek_so += "AND ( "
                                query_cek_so += id_product_sel + " "
                                query_cek_so += ") "
                                query_cek_so += "AND comp.id_comp = '" + id_store_to + "' "
                                Dim tot_ds As String = execute_query(query_cek_so, 0, True, "", "", "", "")

                                'create so
                                If tot_ds > "0" Then
                                    'minimal SO
                                    min_so += 1
                                    If min_so = 1 Then
                                        sales_order_reff = header_number_sales("21")
                                        increase_inc_sales("21")
                                    End If

                                    'insert SO by store
                                    Dim sales_order_number As String = header_number_sales("2")
                                    Dim query_so As String = "INSERT INTO tb_sales_order(id_store_contact_to, id_warehouse_contact_to, sales_order_number, sales_order_date, sales_order_note, id_so_type, id_so_status, id_report_status, id_fg_so_reff, id_user_created) "
                                    query_so += "VALUES ('" + id_store_contact_to + "', '" + id_warehouse_contact_to + "', '" + sales_order_number + "', now(), '', '" + id_so_type + "', '" + id_so_status + "', '6', '" + id_report + "', '" + id_user + "'); SELECT LAST_INSERT_ID(); "
                                    Dim id_sales_order_new As String = execute_query(query_so, 0, True, "", "", "", "")

                                    'increment sales ord number
                                    increase_inc_sales("2")

                                    'insert who prepared
                                    insert_who_approved("39", id_sales_order_new, id_user)

                                    'insert detail
                                    Dim query_det As String = ""
                                    query_det += "INSERT INTO tb_sales_order_det(id_sales_order, id_product, id_design_price, design_price, sales_order_det_qty) "
                                    query_det += "SELECT ('" + id_sales_order_new + "'),ds.id_product, prc.id_design_price, prc.design_price, ds.fg_so_reff_det_qty "
                                    query_det += "FROM tb_fg_so_reff_det ds "
                                    query_det += "INNER JOIN tb_fg_ds_store ds_store ON ds.id_fg_ds_store = ds_store.id_fg_ds_store "
                                    query_det += "INNER JOIN tb_m_comp comp ON comp.id_comp = ds_store.id_comp "
                                    query_det += "INNER JOIN tb_lookup_pd_alloc pd_alloc ON pd_alloc.id_pd_alloc = comp.id_pd_alloc "
                                    query_det += "INNER JOIN tb_m_product prod ON prod.id_product = ds.id_product "
                                    query_det += "LEFT JOIN ( "
                                    query_det += "SELECT * FROM ( "
                                    query_det += "SELECT price.id_design, price.design_price, price.design_price_date, price.id_design_price "
                                    query_det += "FROM tb_m_design_price price "
                                    query_det += "INNER JOIN tb_lookup_design_price_type price_type "
                                    query_det += "ON price.id_design_price_type = price_type.id_design_price_type "
                                    query_det += "INNER JOIN tb_lookup_currency curr ON curr.id_currency = price.id_currency "
                                    query_det += "INNER JOIN tb_m_user `user` ON user.id_user = price.id_user "
                                    query_det += "INNER JOIN tb_m_employee emp ON emp.id_employee = user.id_employee "
                                    query_det += "WHERE price.is_active_wh='1' AND price.design_price_start_date <= NOW() "
                                    query_det += "ORDER BY price.design_price_start_date DESC ) a "
                                    query_det += "GROUP BY a.id_design "
                                    query_det += ") prc ON prc.id_design = prod.id_design "
                                    query_det += "WHERE ds.id_fg_so_reff = '" + id_report + "' AND ds_store.id_season = '" + FormFGSalesOrderReffDet.SLESeason.EditValue.ToString + "' "
                                    query_det += "AND ( "
                                    query_det += id_product_sel + " "
                                    query_det += ") "
                                    query_det += "AND ds.fg_so_reff_det_qty >0 "
                                    query_det += "AND comp.id_comp = '" + id_store_to + "' "
                                    query_det += "ORDER BY ds.id_product ASC "
                                    execute_non_query(query_det, True, "", "", "", "")
                                End If
                            Catch ex As Exception
                                str_err += "- " + col_foc_arr(0).ToString + System.Environment.NewLine
                            End Try

                            'colom statis = 15
                            PBC.PerformStep()
                            PBC.Update()
                        End If
                    Next

                    If str_err = "" Then
                        query = String.Format("UPDATE tb_fg_so_reff SET id_report_status='{0}' WHERE id_fg_so_reff ='{1}'", id_status_reportx, id_report)
                        execute_non_query(query, True, "", "", "", "")
                        infoCustom("Status changed and prepare order was created succesfully.")
                        If form_origin = "FormFGSalesOrderReffDet" Then
                            FormFGSalesOrderReffDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                            FormFGSalesOrderReffDet.actionLoad()
                            FormFGSalesOrderReff.viewSOReff()
                            FormFGSalesOrderReff.GVSOReff.FocusedRowHandle = find_row(FormFGSalesOrderReff.GVSOReff, "id_fg_so_reff", id_report)
                            PBC.Visible = False
                            PBC.EditValue = 0
                        Else
                            ' FormViewProdQCAdjIn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                        End If
                    Else
                        stopCustom("There are some problem with this process. These account are not successfully to create prepare order : " + System.Environment.NewLine + str_err + System.Environment.NewLine + "Please try again later !")
                        PBC.Visible = False
                        PBC.EditValue = 0
                    End If
                End If
            Else
                query = String.Format("UPDATE tb_fg_so_reff SET id_report_status='{0}' WHERE id_fg_so_reff ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Status changed.")

                If form_origin = "FormFGSalesOrderReffDet" Then
                    FormFGSalesOrderReffDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormFGSalesOrderReffDet.actionLoad()
                    FormFGSalesOrderReff.viewSOReff()
                    FormFGSalesOrderReff.GVSOReff.FocusedRowHandle = find_row(FormFGSalesOrderReff.GVSOReff, "id_fg_so_reff", id_report)
                Else
                    ' FormViewProdQCAdjIn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                End If
            End If
        ElseIf report_mark_type = "76" Then
            'SALES INVOICE PROMO
            If id_status_reportx = "5" Then
                'cancelled
                Dim cancel_rsv_stock As ClassSalesInv = New ClassSalesInv()
                cancel_rsv_stock.cancelReservedStock(id_report, "76")
            ElseIf id_status_reportx = "6" Then
                'completed
                Dim complete_rsv_stock As ClassSalesInv = New ClassSalesInv()
                complete_rsv_stock.completeReservedStock(id_report, "76")
            End If

            query = String.Format("UPDATE tb_sales_pos SET id_report_status='{0}' WHERE id_sales_pos ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            If form_origin = "FormSalesPromoDet" Then
                FormSalesPromoDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesPromoDet.check_but()
                FormSalesPromoDet.actionLoad()
                FormSalesPromo.viewSalesPOS()
                FormSalesPromo.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPromo.GVSalesPOS, "id_sales_pos", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "79" Then
            'BOM Per Design
            Try
                Dim id_design As String = "-1"
                If form_origin = "FormBomSingle" Then
                    id_design = FormBOMSingle.id_design
                ElseIf form_origin = "FormBOMDesignSingle" Then
                    id_design = FormBOMDesignSingle.id_design
                End If
                query = String.Format("UPDATE tb_bom_approve SET id_report_status='{0}' WHERE id_bom_approve ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                query = String.Format("UPDATE tb_bom bom INNER JOIN tb_m_product prod ON prod.id_product=bom.id_product SET bom.id_report_status='{0}' WHERE bom.id_bom_approve='{1}' AND prod.id_design='{2}'", id_status_reportx, id_report, FormBOMSingle.id_design)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Status changed.")
                If form_origin = "FormBomSingle" Then
                    FormBOMSingle.act_load()
                ElseIf form_origin = "FormBOMDesignSingle" Then
                    FormBOMDesignSingle.act_load()
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "82" Then
            'FG PRICE
            'post ke master price if completed
            If id_status_reportx = "6" Then
                Dim query_ins As String = "INSERT INTO tb_m_design_price(id_design, id_design_price_type, design_price_name, id_currency, design_price, design_price_date, design_price_start_date, is_print, id_user) "
                query_ins += "SELECT det.id_design, prc.id_design_price_type, det.design_price_name, det.id_currency, det.design_price, "
                query_ins += "NOW(), NOW(), det.is_print, '" + id_user + "' "
                query_ins += "FROM tb_fg_price_det det "
                query_ins += "INNER JOIN tb_fg_price prc ON prc.id_fg_price = det.id_fg_price "
                query_ins += "WHERE det.id_fg_price='" + id_report + "' "
                execute_non_query(query_ins, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_fg_price SET id_report_status='{0}' WHERE id_fg_price ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            If form_origin = "FormMasterPriceSingle" Then
                FormMasterPriceSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormMasterPriceSingle.check_but()
                FormMasterPriceSingle.actionLoad()
                FormMasterPrice.viewPrice()
                FormMasterPrice.GVPrice.FocusedRowHandle = find_row(FormMasterPrice.GVPrice, "id_fg_price", id_report)
            End If
        ElseIf report_mark_type = "85" Then
            'SAMPLE PL
            If id_status_reportx = "5" Then
                'cancelled
                Dim cancel_rsv_stock As ClassSamplePLtoWH = New ClassSamplePLtoWH()
                cancel_rsv_stock.cancelReservedStock(id_report, report_mark_type)
            ElseIf id_status_reportx = "6" Then
                'completed
                Dim complete_rsv_stock As ClassSamplePLtoWH = New ClassSamplePLtoWH()
                complete_rsv_stock.completeReservedStock(id_report, report_mark_type)
            End If

            query = String.Format("UPDATE tb_sample_pl SET id_report_status='{0}' WHERE id_sample_pl ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            If form_origin = "FormSamplePLToWHDet" Then
                FormSamplePLToWHDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSamplePLToWHDet.check_but()
                FormSamplePLToWHDet.actionLoad()
                FormSamplePLToWH.viewSamplePL()
                FormSamplePLToWH.GVSamplePL.FocusedRowHandle = find_row(FormSamplePLToWH.GVSamplePL, "id_sample_pl", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "86" Then
            'SAMPLE PRICE
            'post ke master price if completed
            If id_status_reportx = "6" Then
                Dim query_ins As String = "INSERT INTO tb_m_sample_ret_price(id_sample, id_design_price_type, sample_ret_price_name, id_currency, sample_ret_price, sample_ret_price_date, sample_ret_price_start_date, is_print, id_user) "
                query_ins += "SELECT det.id_sample, prc.id_design_price_type, det.sample_price_name, det.id_currency, det.sample_price, "
                query_ins += "NOW(), NOW(), det.is_print, '" + id_user + "' "
                query_ins += "FROM tb_sample_price_det det "
                query_ins += "INNER JOIN tb_sample_price prc ON prc.id_sample_price = det.id_sample_price "
                query_ins += "WHERE det.id_sample_price='" + id_report + "' "
                execute_non_query(query_ins, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_sample_price SET id_report_status='{0}' WHERE id_sample_price ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            If form_origin = "FormMasterPriceSampleSingle" Then
                FormMasterPriceSampleSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormMasterPriceSampleSingle.check_but()
                FormMasterPriceSampleSingle.actionLoad()
                FormMasterPriceSample.viewPrice()
                FormMasterPriceSample.GVPrice.FocusedRowHandle = find_row(FormMasterPriceSample.GVPrice, "id_sample_price", id_report)
            End If
        ElseIf report_mark_type = "87" Then
            'inventory allocation
            If id_status_reportx = "5" Then
                'cancelled
                Dim cancel_rsv_stock As ClassFGWHAlloc = New ClassFGWHAlloc()
                cancel_rsv_stock.cancelReservedStock(id_report)
            ElseIf id_status_reportx = "6" Then
                'completed
                Dim cmpl_stock As ClassFGWHAlloc = New ClassFGWHAlloc()
                cmpl_stock.completeReservedStock(id_report)
            End If

            query = String.Format("UPDATE tb_fg_wh_alloc SET id_report_status='{0}' WHERE id_fg_wh_alloc ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            If form_origin = "FormFGWHAllocDet" Then
                FormFGWHAllocDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGWHAllocDet.check_but()
                FormFGWHAllocDet.actionLoad()
                FormFGWHAlloc.viewFGWHAlloc()
                FormFGWHAlloc.GVFGWHAlloc.FocusedRowHandle = find_row(FormFGWHAlloc.GVFGWHAlloc, "id_fg_wh_alloc", id_report)
            End If
        ElseIf report_mark_type = "88" Then
            'generate prepare order
            If id_status_reportx = "5" Then
                Dim cancel As New ClassSalesOrder()
                cancel.cancelReservedStockGen(id_report)
            ElseIf id_status_reportx = "6" Then
                'created transfer
                Dim qv As String = "SELECT so.id_warehouse_contact_to, so.id_store_contact_to, so.id_sales_order, c.id_drawer_def 
                FROM tb_sales_order so 
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                WHERE so.id_sales_order_gen=" + id_report + " AND so.id_so_status=5 AND c.is_only_for_alloc=1 "
                Dim dtv As DataTable = execute_query(qv, -1, True, "", "", "", "")
                If dtv.Rows.Count > 0 Then
                    For m As Integer = 0 To dtv.Rows.Count - 1
                        'main
                        Dim qm As String = "INSERT INTO tb_fg_trf(id_comp_contact_from, id_comp_contact_to, id_sales_order, fg_trf_number, fg_trf_date, fg_trf_date_rec, fg_trf_note, id_report_status, id_report_status_rec, id_wh_drawer, last_update, last_update_by) 
                        VALUES('" + dtv.Rows(m)("id_warehouse_contact_to").ToString + "', '" + dtv.Rows(m)("id_store_contact_to").ToString + "', '" + dtv.Rows(m)("id_sales_order").ToString + "', '" + header_number_sales("15") + "', NOW(), NOW(), '', '3', '3', '" + dtv.Rows(m)("id_drawer_def").ToString + "', NOW(), " + id_user + "); SELECT LAST_INSERT_ID(); "
                        Dim id_so As String = execute_query(qm, 0, True, "", "", "", "")
                        increase_inc_sales("15")

                        'detail
                        Dim qd As String = "INSERT INTO tb_fg_trf_det(id_fg_trf, id_product, id_sales_order_det, fg_trf_det_qty, fg_trf_det_qty_rec, fg_trf_det_qty_stored, fg_trf_det_note)
                        SELECT '" + id_so + "', sd.id_product, sd.id_sales_order_det, sd.sales_order_det_qty, sd.sales_order_det_qty, sd.sales_order_det_qty,'' 
                        FROM tb_sales_order_det sd 
                        WHERE sd.id_sales_order=" + dtv.Rows(m)("id_sales_order").ToString + " "
                        execute_non_query(qd, -1, True, "", "", "")
                    Next
                End If
            End If


            Dim query_update_so As String = "UPDATE tb_sales_order SET id_report_status='" + id_status_reportx + "' WHERE id_sales_order_gen='" + id_report + "' "
            execute_non_query(query_update_so, True, "", "", "", "")

            query = String.Format("UPDATE tb_sales_order_gen SET id_report_status='{0}' WHERE id_sales_order_gen ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            If form_origin = "FormSalesOrderGen" Then
                FormSalesOrderGen.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesOrderGen.check_but()
                FormSalesOrderGen.actionLoad()
                FormSalesOrder.viewSalesOrderGen()
                FormSalesOrder.GVGen.FocusedRowHandle = find_row(FormSalesOrder.GVGen, "id_sales_order_gen", id_report)
            End If
        ElseIf report_mark_type = "89" Then
            'SAMPLE PL
            If id_status_reportx = "6" Then
                'completed
                Dim complete_rsv_stock As ClassSampleReturnPL = New ClassSampleReturnPL()
                complete_rsv_stock.completeStock(id_report, report_mark_type)
            End If

            query = String.Format("UPDATE tb_sample_pl_ret SET id_report_status='{0}' WHERE id_sample_pl_ret ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            If form_origin = "FormSampleReturnPLDet" Then
                FormSampleReturnPLDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleReturnPLDet.check_but()
                FormSampleReturnPLDet.actionLoad()
                FormSampleReturnPL.viewSamplePL()
                FormSampleReturnPL.GVSamplePL.FocusedRowHandle = find_row(FormSampleReturnPL.GVSamplePL, "id_sample_pl_ret", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "91" Then
            'FG REPAIR
            If id_status_reportx = "5" Then
                Dim cancel As New ClassFGRepair()
                cancel.cancelReservedStock(id_report)
            ElseIf id_status_reportx = "6" Then
                Dim compl As New ClassFGRepair()
                compl.completedStock(id_report)
            End If

            query = String.Format("UPDATE tb_fg_repair SET id_report_status='{0}' WHERE id_fg_repair ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            If form_origin = "FormFGRepairDet" Then
                FormFGRepairDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGRepairDet.actionLoad()
                FormFGRepair.viewData()
                FormFGRepair.GVRepair.FocusedRowHandle = find_row(FormFGRepair.GVRepair, "id_fg_repair", id_report)
            End If
        ElseIf report_mark_type = "92" Then
            'FG REPAIR REC
            If id_status_reportx = "6" Then
                Dim compl As New ClassFGRepairRec()
                compl.completedStock(id_report)
            End If

            query = String.Format("UPDATE tb_fg_repair_rec SET id_report_status='{0}' WHERE id_fg_repair_rec ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            If form_origin = "FormFGRepairRecDet" Then
                FormFGRepairRecDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGRepairRecDet.actionLoad()
                FormFGRepairRec.viewData()
                FormFGRepairRec.viewRepairList()
                FormFGRepairRec.GVRepairRec.FocusedRowHandle = find_row(FormFGRepairRec.GVRepairRec, "id_fg_repair_rec", id_report)
            End If
        ElseIf report_mark_type = "93" Then
            'FG REPAIR RETURN
            If id_status_reportx = "5" Then
                Dim cancel As New ClassFGRepairReturn()
                cancel.cancelReservedStock(id_report)
            ElseIf id_status_reportx = "6" Then
                Dim compl As New ClassFGRepairReturn()
                compl.completedStock(id_report)
            End If

            query = String.Format("UPDATE tb_fg_repair_return SET id_report_status='{0}' WHERE id_fg_repair_return ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            If form_origin = "FormFGRepairReturnDet" Then
                FormFGRepairReturnDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGRepairReturnDet.actionLoad()
                FormFGRepairReturn.viewData()
                FormFGRepairReturn.GVRepairReturn.FocusedRowHandle = find_row(FormFGRepairReturn.GVRepairReturn, "id_fg_repair_return", id_report)
            End If
        ElseIf report_mark_type = "94" Then
            'FG REPAIR RETURN REC
            If id_status_reportx = "6" Then
                Dim compl As New ClassFGRepairReturnRec()
                compl.completedStock(id_report)
            End If

            query = String.Format("UPDATE tb_fg_repair_return_rec SET id_report_status='{0}' WHERE id_fg_repair_return_rec ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")

            If form_origin = "FormFGRepairReturnRecDet" Then
                FormFGRepairReturnRecDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGRepairReturnRecDet.actionLoad()
                FormFGRepairReturnRec.viewData()
                FormFGRepairReturnRec.viewRepairList()
                FormFGRepairReturnRec.GVRepairRec.FocusedRowHandle = find_row(FormFGRepairReturnRec.GVRepairRec, "id_fg_repair_return_rec", id_report)
            End If
        ElseIf report_mark_type = "95" Then
            'LEAVE PROPOSE
            If id_status_reportx = "3" Then
                'update schedule to cuti
                Dim query_upd As String = ""
                query_upd = "UPDATE tb_emp_schedule emps
                                INNER JOIN
                                (SELECT empld.id_schedule,empl.leave_purpose,empl.id_leave_type FROM tb_emp_leave_det empld
                                INNER JOIN tb_emp_leave empl ON empld.id_emp_leave=empl.id_emp_leave
                                WHERE empld.id_emp_leave='" & id_report & "')
                                a ON a.id_schedule=emps.id_schedule
                                SET emps.id_leave_type=a.id_leave_type,emps.info_leave=a.leave_purpose"
                execute_non_query(query_upd, True, "", "", "", "")
                'add if advance
                query_upd = "INSERT INTO tb_emp_stock_leave_adv(id_emp,id_emp_leave,qty,adv_datetime)
                                SELECT lve.id_emp,ld.id_emp_leave,SUM(ld.minutes_total) AS qty,NOW()
                                FROM tb_emp_leave_det ld
                                INNER JOIN tb_emp_leave lve ON lve.id_emp_leave=ld.id_emp_leave
                                WHERE ld.id_emp_leave='" & id_report & "' AND lve.id_leave_type='4'
                                GROUP BY ld.id_emp_leave"
                execute_non_query(query_upd, True, "", "", "", "")
                'complete 
                id_status_reportx = "6"
                'mail
                Dim mail As ClassSendEmail = New ClassSendEmail()
                mail.report_mark_type = report_mark_type
                mail.send_email_appr(report_mark_type, id_report, True)
            ElseIf id_status_reportx = "5" Then 'cancel
                Dim query_del As String = "DELETE FROM tb_emp_stock_leave WHERE id_emp_leave='" & id_report & "'"
                execute_non_query(query_del, True, "", "", "", "")
            End If
            query = String.Format("UPDATE tb_emp_leave SET id_report_status='{0}' WHERE id_emp_leave ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'FormEmpLeave.load_sum()
            infoCustom("Status changed.")
        ElseIf report_mark_type = "96" Then
            'LEAVE PROPOSE
            If id_status_reportx = "3" Then
                'update schedule to cuti
                Dim query_upd As String = ""
                query_upd = "UPDATE tb_emp_schedule emps
                                INNER JOIN
                                (SELECT empld.id_schedule,empl.leave_purpose,empl.id_leave_type FROM tb_emp_leave_det empld
                                INNER JOIN tb_emp_leave empl ON empld.id_emp_leave=empl.id_emp_leave
                                WHERE empld.id_emp_leave='" & id_report & "')
                                a ON a.id_schedule=emps.id_schedule
                                SET emps.id_leave_type=a.id_leave_type,emps.info_leave=a.leave_purpose"
                execute_non_query(query_upd, True, "", "", "", "")
                'add if advance
                query_upd = "INSERT INTO tb_emp_stock_leave_adv(id_emp,id_emp_leave,qty,adv_datetime)
                                SELECT lve.id_emp,ld.id_emp_leave,SUM(ld.minutes_total) AS qty,NOW()
                                FROM tb_emp_leave_det ld
                                INNER JOIN tb_emp_leave lve ON lve.id_emp_leave=ld.id_emp_leave
                                WHERE ld.id_emp_leave='" & id_report & "' AND lve.id_leave_type='4'
                                GROUP BY ld.id_emp_leave"
                execute_non_query(query_upd, True, "", "", "", "")
                'complete 
                id_status_reportx = "6"
                'mail
                Dim mail As ClassSendEmail = New ClassSendEmail()
                mail.report_mark_type = report_mark_type
                mail.send_email_appr(report_mark_type, id_report, True)
            ElseIf id_status_reportx = "5" Then 'cancel
                Dim query_del As String = "DELETE FROM tb_emp_stock_leave WHERE id_emp_leave='" & id_report & "'"
                execute_non_query(query_del, True, "", "", "", "")
            End If
            query = String.Format("UPDATE tb_emp_leave SET id_report_status='{0}' WHERE id_emp_leave ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            FormEmpLeave.load_sum()
            infoCustom("Status changed.")
        ElseIf report_mark_type = "97" Then
            'DP
            If id_status_reportx = "3" Then
                'complete 
                Dim query_det As String = "SELECT id_dp,id_employee,dp_total,dp_time_end,dp_note FROM tb_emp_dp WHERE id_dp='" & id_report & "'"
                Dim data_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")
                If data_det.Rows.Count > 0 Then
                    query = "INSERT INTO tb_emp_stock_leave(id_emp_dp,id_emp,qty,plus_minus,date_leave,date_expired,is_process_exp,note,`type`) VALUES
                        ('" & id_report & "','" & data_det.Rows(0)("id_employee").ToString & "','" & (data_det.Rows(0)("dp_total") * 60).ToString & "','1',NOW(),'" & Date.Parse(data_det.Rows(0)("dp_time_end").ToString).AddMonths(6).ToString("yyyy-MM-dd") & "','2','" & data_det.Rows(0)("dp_note").ToString & "','2')"
                    execute_non_query(query, True, "", "", "", "")
                End If
                '
                id_status_reportx = "6"
            ElseIf id_status_reportx = "5" Then 'cancel
                Dim query_del As String = "DELETE FROM tb_emp_stock_leave WHERE id_emp_dp='" & id_report & "'"
                execute_non_query(query_del, True, "", "", "", "")
            End If
            query = String.Format("UPDATE tb_emp_dp SET id_report_status='{0}' WHERE id_dp ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
        ElseIf report_mark_type = "98" Then
            'Employee change schedule
            If id_status_reportx = "3" Then
                'complete 
                query = "UPDATE tb_emp_schedule sch
                            INNER JOIN(
                            SELECT schdf.id_schedule
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.in))) AS `in` 
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.out))) AS `out` 
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.in_tolerance))) AS `in_tolerance` 
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.break_out))) AS `break_out` 
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.break_in))) AS `break_in` 
                            ,schdt.minutes_work AS `minutes_work` 
                            ,schdt.id_schedule_type AS `id_schedule_type` 
                            ,schdt.note AS `note` 
                            ,schdt.shift_code AS `shift_code` 
                            FROM tb_emp_ch_schedule_det schdf
                            INNER JOIN tb_emp_ch_schedule_det schdt ON schdt.id_emp_ch_schedule=schdf.id_emp_ch_schedule 
                            AND schdt.from_to='2'
                            WHERE schdf.from_to = '1'
                            AND schdf.id_emp_ch_schedule='" & id_report & "'
                            ) switch ON switch.id_schedule=sch.id_schedule
                            SET sch.in=switch.in
                            ,sch.out=switch.out
                            ,sch.in_tolerance=switch.in_tolerance
                            ,sch.break_out=switch.break_out
                            ,sch.break_in=switch.break_in
                            ,sch.minutes_work=switch.minutes_work
                            ,sch.id_schedule_type=switch.id_schedule_type
                            ,sch.note=switch.note
                            ,sch.shift_code=switch.shift_code"
                execute_non_query(query, True, "", "", "", "")
                query = "UPDATE tb_emp_schedule sch
                            INNER JOIN(
                            SELECT schdf.id_schedule
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.in))) AS `in` 
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.out))) AS `out` 
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.in_tolerance))) AS `in_tolerance` 
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.break_out))) AS `break_out` 
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.break_in))) AS `break_in` 
                            ,schdt.minutes_work AS `minutes_work` 
                            ,schdt.id_schedule_type AS `id_schedule_type` 
                            ,schdt.note AS `note` 
                            ,schdt.shift_code AS `shift_code` 
                            FROM tb_emp_ch_schedule_det schdf
                            INNER JOIN tb_emp_ch_schedule_det schdt ON schdt.id_emp_ch_schedule=schdf.id_emp_ch_schedule 
                            AND schdt.from_to='1'
                            WHERE schdf.from_to ='2'
                            AND schdf.id_emp_ch_schedule='" & id_report & "'
                            ) switch ON switch.id_schedule=sch.id_schedule
                            SET sch.in=switch.in
                            ,sch.out=switch.out
                            ,sch.in_tolerance=switch.in_tolerance
                            ,sch.break_out=switch.break_out
                            ,sch.break_in=switch.break_in
                            ,sch.minutes_work=switch.minutes_work
                            ,sch.id_schedule_type=switch.id_schedule_type
                            ,sch.note=switch.note
                            ,sch.shift_code=switch.shift_code"
                execute_non_query(query, True, "", "", "", "")
                id_status_reportx = "6"
            End If
            query = String.Format("UPDATE tb_emp_ch_schedule SET id_report_status='{0}' WHERE id_emp_ch_schedule ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
        ElseIf report_mark_type = "99" Then
            'LEAVE PROPOSE
            If id_status_reportx = "3" Then
                'update schedule to cuti
                Dim query_upd As String = ""
                query_upd = "UPDATE tb_emp_schedule emps
                                INNER JOIN
                                (SELECT empld.id_schedule,empl.leave_purpose,empl.id_leave_type FROM tb_emp_leave_det empld
                                INNER JOIN tb_emp_leave empl ON empld.id_emp_leave=empl.id_emp_leave
                                WHERE empld.id_emp_leave='" & id_report & "')
                                a ON a.id_schedule=emps.id_schedule
                                SET emps.id_leave_type=a.id_leave_type,emps.info_leave=a.leave_purpose"
                execute_non_query(query_upd, True, "", "", "", "")
                'add if advance
                query_upd = "INSERT INTO tb_emp_stock_leave_adv(id_emp,id_emp_leave,qty,adv_datetime)
                                SELECT lve.id_emp,ld.id_emp_leave,SUM(ld.minutes_total) AS qty,NOW()
                                FROM tb_emp_leave_det ld
                                INNER JOIN tb_emp_leave lve ON lve.id_emp_leave=ld.id_emp_leave
                                WHERE ld.id_emp_leave='" & id_report & "' AND lve.id_leave_type='4'
                                GROUP BY ld.id_emp_leave"
                execute_non_query(query_upd, True, "", "", "", "")
                'complete 
                id_status_reportx = "6"
                'mail
                Dim mail As ClassSendEmail = New ClassSendEmail()
                mail.report_mark_type = report_mark_type
                mail.send_email_appr(report_mark_type, id_report, True)
            ElseIf id_status_reportx = "5" Then 'cancel
                Dim query_del As String = "DELETE FROM tb_emp_stock_leave WHERE id_emp_leave='" & id_report & "'"
                execute_non_query(query_del, True, "", "", "", "")
            End If
            query = String.Format("UPDATE tb_emp_leave SET id_report_status='{0}' WHERE id_emp_leave ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            FormEmpLeave.load_sum()
            infoCustom("Status changed.")
        ElseIf report_mark_type = "100" Then
            'Schedule PROPOSE with approval
            If id_status_reportx = "3" Then
                'update schedule 
                Dim query_after As String = "SELECT sch.id_employee,IFNULL(s.id_shift,0) as id_shift,sch.date FROM tb_emp_assign_sch_det sch
                                                LEFT JOIN tb_emp_shift s ON sch.shift_code=s.shift_code
                                                WHERE id_emp_assign_sch='" & id_report & "' AND `type`='2'"
                Dim data_after As DataTable = execute_query(query_after, -1, True, "", "", "", "")
                For j As Integer = 0 To data_after.Rows.Count - 1
                    Dim id_shift, id_empployee_varx, date_var As String
                    id_shift = data_after(j)("id_shift").ToString
                    id_empployee_varx = data_after(j)("id_employee").ToString
                    date_var = Date.Parse(data_after(j)("date").ToString).ToString("yyy-MM-dd")

                    If Not id_shift = "" Then
                        If id_shift = "0" Then
                            Dim query_shift As String = "CALL add_shift(" & id_empployee_varx & ",1,'" & date_var & "','" & date_var & "',2)"
                            execute_non_query(query_shift, True, "", "", "", "")
                        Else
                            Dim query_shift As String = "CALL add_shift(" & id_empployee_varx & "," & id_shift & ",'" & date_var & "','" & date_var & "',1)"
                            execute_non_query(query_shift, True, "", "", "", "")
                        End If
                    End If
                Next

                'complete 
                id_status_reportx = "6"
            End If
            query = String.Format("UPDATE tb_emp_assign_sch SET id_report_status='{0}' WHERE id_assign_sch ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
        ElseIf report_mark_type = "101" Then
            'Air Ways Bill
            If id_status_reportx = "3" Then
                'complete 
                id_status_reportx = "6"
            End If
            query = String.Format("UPDATE tb_wh_awbill SET id_report_status='{0}' WHERE id_awbill ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Status changed.")
        ElseIf report_mark_type = "102" Then
            'LEAVE PROPOSE
            If id_status_reportx = "3" Or id_status_reportx = "6" Then
                'update schedule to cuti
                Dim query_upd As String = ""
                query_upd = "UPDATE tb_emp_schedule emps
                                INNER JOIN
                                (SELECT empld.id_schedule,empl.leave_purpose,empl.id_leave_type FROM tb_emp_leave_det empld
                                INNER JOIN tb_emp_leave empl ON empld.id_emp_leave=empl.id_emp_leave
                                WHERE empld.id_emp_leave='" & id_report & "')
                                a ON a.id_schedule=emps.id_schedule
                                SET emps.id_leave_type=a.id_leave_type,emps.info_leave=a.leave_purpose"
                execute_non_query(query_upd, True, "", "", "", "")
                'add if advance
                query_upd = "INSERT INTO tb_emp_stock_leave_adv(id_emp,id_emp_leave,qty,adv_datetime)
                                SELECT lve.id_emp,ld.id_emp_leave,SUM(ld.minutes_total) AS qty,NOW()
                                FROM tb_emp_leave_det ld
                                INNER JOIN tb_emp_leave lve ON lve.id_emp_leave=ld.id_emp_leave
                                WHERE ld.id_emp_leave='" & id_report & "' AND lve.id_leave_type='4'
                                GROUP BY ld.id_emp_leave"
                execute_non_query(query_upd, True, "", "", "", "")
                'complete 
                id_status_reportx = "6"
                'mail
                Dim mail As ClassSendEmail = New ClassSendEmail()
                mail.report_mark_type = report_mark_type
                mail.send_email_appr(report_mark_type, id_report, True)
            ElseIf id_status_reportx = "5" Then 'cancel
                Dim query_del As String = "DELETE FROM tb_emp_stock_leave WHERE id_emp_leave='" & id_report & "'"
                execute_non_query(query_del, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_emp_leave SET id_report_status='{0}' WHERE id_emp_leave ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            FormEmpLeave.load_sum()
            infoCustom("Status changed.")
        ElseIf report_mark_type = "104" Then
            'LEAVE PROPOSE
            If id_status_reportx = "3" Or id_status_reportx = "6" Then
                'update schedule to cuti
                Dim query_upd As String = ""
                query_upd = "UPDATE tb_emp_schedule emps
                                INNER JOIN
                                (SELECT empld.id_schedule,empl.leave_purpose,empl.id_leave_type FROM tb_emp_leave_det empld
                                INNER JOIN tb_emp_leave empl ON empld.id_emp_leave=empl.id_emp_leave
                                WHERE empld.id_emp_leave='" & id_report & "')
                                a ON a.id_schedule=emps.id_schedule
                                SET emps.id_leave_type=a.id_leave_type,emps.info_leave=a.leave_purpose"
                execute_non_query(query_upd, True, "", "", "", "")
                'add if advance
                query_upd = "INSERT INTO tb_emp_stock_leave_adv(id_emp,id_emp_leave,qty,adv_datetime)
                                SELECT lve.id_emp,ld.id_emp_leave,SUM(ld.minutes_total) AS qty,NOW()
                                FROM tb_emp_leave_det ld
                                INNER JOIN tb_emp_leave lve ON lve.id_emp_leave=ld.id_emp_leave
                                WHERE ld.id_emp_leave='" & id_report & "' AND lve.id_leave_type='4'
                                GROUP BY ld.id_emp_leave"
                execute_non_query(query_upd, True, "", "", "", "")
                'complete 
                id_status_reportx = "6"
                'mail
                Dim mail As ClassSendEmail = New ClassSendEmail()
                mail.report_mark_type = report_mark_type
                mail.send_email_appr(report_mark_type, id_report, True)
            ElseIf id_status_reportx = "5" Then 'cancel
                Dim query_del As String = "DELETE FROM tb_emp_stock_leave WHERE id_emp_leave='" & id_report & "'"
                execute_non_query(query_del, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_emp_leave SET id_report_status='{0}' WHERE id_emp_leave ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            FormEmpLeave.load_sum()
            infoCustom("Status changed.")
        End If

        'adding lead time
        Dim query_auto As String = "SELECT DISTINCT(id_report_status) as id_report_status FROM tb_report_mark  WHERE id_report='" & id_report & "' AND report_mark_type='" & report_mark_type & "' AND id_report_status>'" & id_status_reportx & "' ORDER BY id_report_status LIMIT 1"
        Dim data_auto As DataTable = execute_query(query_auto, -1, True, "", "", "", "")
        If data_auto.Rows.Count > 0 Then
            Dim query_set As String = "SELECT * FROM tb_report_mark WHERE id_report='" & id_report & "' AND report_mark_type='" & report_mark_type & "' AND id_report_status>'" & id_status_reportx & "' AND id_report_status='" & data_auto.Rows(0)("id_report_status").ToString & "' ORDER BY level"
            Dim data_set As DataTable = execute_query(query_set, -1, True, "", "", "", "")
            For i As Integer = 0 To data_set.Rows.Count - 1
                If data_set.Rows(i)("level").ToString() = "1" Then
                    query = "UPDATE tb_report_mark b SET b.report_mark_start_datetime=NOW(),b.report_mark_lead_time=(SELECT IFNULL(z.lead_time,'00-00-00') FROM tb_mark_asg_user z WHERE z.id_mark_asg=b.id_mark_asg AND z.id_user=b.id_user LIMIT 1) WHERE b.id_report_mark='" & data_set.Rows(i)("id_report_mark").ToString & "'"
                Else
                    query = "UPDATE tb_report_mark b SET b.report_mark_start_datetime=(SELECT a.report_mark_start_datetime_end FROM (SELECT ADDTIME(z.report_mark_start_datetime,z.report_mark_lead_time) AS report_mark_start_datetime_end FROM tb_report_mark z WHERE z.id_mark_asg=" & data_set.Rows(i)("id_mark_asg").ToString() & " AND z.id_report=" & data_set.Rows(i)("id_report").ToString() & " AND z.level=" & data_set.Rows(i)("level").ToString() & "-1 LIMIT 1) a),b.report_mark_lead_time=(SELECT IFNULL(z.lead_time,'00-00-00') FROM tb_mark_asg_user z WHERE z.id_mark_asg=b.id_mark_asg AND z.id_user=b.id_user LIMIT 1) WHERE b.id_report_mark='" & data_set.Rows(i)("id_report_mark").ToString & "'"
                End If
                execute_non_query(query, True, "", "", "", "")
            Next
        End If

        'auto_journal()

        view_report_status(LEReportStatus)
    End Sub
    Sub posting_journal()
        Dim q_posting As String = ""
        Dim acc_trans_number As String = ""
        acc_trans_number = header_number_acc("1")

        q_posting = String.Format("INSERT INTO tb_a_acc_trans(acc_trans_number,id_user,date_created,acc_trans_note) VALUES('{0}','{1}',NOW(),'Auto posting {2}');SELECT LAST_INSERT_ID()", acc_trans_number, id_user, report_number)
        'execute_non_query(q_posting, True, "", "", "", "")

        'q_posting = "SELECT LAST_INSERT_ID()"
        Dim last_id As String = execute_query(q_posting, 0, True, "", "", "", "")

        If report_mark_type = "1" Then ' sample purchase det
            Dim id_acc_x As String = ""
            q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
            '-debit
            '-- item
            If get_coa_mapping("1", "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping("1", "1"), get_coa_mapping("1", "2") & "" & FormSamplePurchaseDet.TECompCode.Text, FormSamplePurchaseDet.TECompName.Text)
            Else
                id_acc_x = get_coa_mapping("1", "1")
            End If

            q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, decimalSQL(FormSamplePurchaseDet.TEGrossTot.EditValue.ToString), 0, "Sample - " & FormSamplePurchaseDet.TECompName.Text, report_mark_type, id_report)
            'credit
            If get_coa_mapping("2", "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping("2", "1"), get_coa_mapping("2", "2") & "" & FormSamplePurchaseDet.TECompCode.Text, FormSamplePurchaseDet.TECompName.Text)
            Else
                id_acc_x = get_coa_mapping("2", "1")
            End If

            q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, decimalSQL(FormSamplePurchaseDet.TEGrossTot.EditValue.ToString), "PO Sample - " & FormSamplePurchaseDet.TECompName.Text, report_mark_type, id_report)
            execute_non_query(q_posting, True, "", "", "", "")
        ElseIf report_mark_type = "2" Then 'receive sample purc
            'MsgBox(FormSampleReceiveDet.GVListPurchase.Columns("sample_purc_rec_det_price").SummaryItem.SummaryValue.ToString)
            'declare account
            Dim id_coa_m_d As String = "3"
            Dim id_coa_m_k As String = "4"
            'vendor name and code
            Dim _comp_code As String = get_company_x(FormSampleReceiveDet.id_comp_from, "2")
            Dim _comp_name As String = FormSampleReceiveDet.TECompName.Text
            Dim _value_str As String = decimalSQL(FormSampleReceiveDet.GVListPurchase.Columns("sample_purc_rec_det_price").SummaryItem.SummaryValue.ToString)
            '
            Dim id_acc_x As String = ""
            q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
            '-debit
            '-- item
            If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_d, "1")
            End If

            q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Sample Receive - " & _comp_name, report_mark_type, id_report)
            'credit
            If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_k, "1")
            End If

            q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Sample Receive - " & _comp_name, report_mark_type, id_report)
            execute_non_query(q_posting, True, "", "", "", "")
        ElseIf report_mark_type = "13" Then 'mat purc
            If FormMatPurchaseDet.LEPOType.EditValue.ToString = "1" Then 'domestic
                'declare account
                Dim id_coa_m_d As String = "13"
                Dim id_coa_m_k As String = "14"
                'vendor name and code
                Dim _comp_code As String = FormMatPurchaseDet.TECompCode.Text
                Dim _comp_name As String = FormMatPurchaseDet.TECompName.Text
                Dim _value_str As String = decimalSQL(FormMatPurchaseDet.TEGrossTot.EditValue.ToString)
                '
                Dim id_acc_x As String = ""
                q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
                '-debit
                '-- item
                If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
                Else
                    id_acc_x = get_coa_mapping(id_coa_m_d, "1")
                End If

                q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Purchase Domestic - " & _comp_name, report_mark_type, id_report)
                'credit
                If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
                Else
                    id_acc_x = get_coa_mapping(id_coa_m_k, "1")
                End If

                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Purchase Domestic - " & _comp_name, report_mark_type, id_report)
                execute_non_query(q_posting, True, "", "", "", "")
            ElseIf FormMatPurchaseDet.LEPOType.EditValue.ToString = "2" Then 'international
                'declare account
                Dim id_coa_m_d As String = "5"
                Dim id_coa_m_k As String = "6"
                'vendor name and code
                Dim _comp_code As String = FormMatPurchaseDet.TECompCode.Text
                Dim _comp_name As String = FormMatPurchaseDet.TECompName.Text
                Dim _value_str As String = decimalSQL(FormMatPurchaseDet.TEGrossTot.EditValue.ToString)
                '
                Dim id_acc_x As String = ""
                q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
                '-debit
                '-- item
                If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
                Else
                    id_acc_x = get_coa_mapping(id_coa_m_d, "1")
                End If

                q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Purchase Import - " & _comp_name, report_mark_type, id_report)
                'credit
                If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
                Else
                    id_acc_x = get_coa_mapping(id_coa_m_k, "1")
                End If

                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Purchase Import - " & _comp_name, report_mark_type, id_report)
                execute_non_query(q_posting, True, "", "", "", "")
            ElseIf FormMatPurchaseDet.LEPOType.EditValue.ToString = "3" Then 'merchandise
                'declare account
                Dim id_coa_m_d As String = "15"
                Dim id_coa_m_k As String = "16"
                'vendor name and code
                Dim _comp_code As String = FormMatPurchaseDet.TECompCode.Text
                Dim _comp_name As String = FormMatPurchaseDet.TECompName.Text
                Dim _value_str As String = decimalSQL(FormMatPurchaseDet.TEGrossTot.EditValue.ToString)
                '
                Dim id_acc_x As String = ""
                q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
                '-debit
                '-- item
                If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
                Else
                    id_acc_x = get_coa_mapping(id_coa_m_d, "1")
                End If

                q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Purchase Non Merchandise - " & _comp_name, report_mark_type, id_report)
                'credit
                If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
                Else
                    id_acc_x = get_coa_mapping(id_coa_m_k, "1")
                End If

                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Purchase Non Merchandise - " & _comp_name, report_mark_type, id_report)
                execute_non_query(q_posting, True, "", "", "", "")
            End If
        ElseIf report_mark_type = "16" Then 'mat purc receive
            Dim query_det As String = "SELECT b.id_po_type FROM tb_mat_purc_rec a INNER JOIN tb_mat_purc b ON a.id_mat_purc=b.id_mat_purc WHERE a.id_mat_purc_rec='" & id_report & "'"
            Dim id_po_type As String = execute_query(query_det, 0, True, "", "", "", "")

            If id_po_type = "1" Then 'domestic
                'declare account
                Dim id_coa_m_d As String = "17"
                Dim id_coa_m_k As String = "18"
                'vendor name and code
                Dim _comp_code As String = get_company_x(get_company_contact_x(FormMatRecPurcDet.id_comp_from, "3"), "2")
                Dim _comp_name As String = FormMatRecPurcDet.TECompName.Text
                Dim _value_str As String = decimalSQL(FormMatRecPurcDet.GVListPurchase.Columns("mat_purc_rec_det_price").SummaryItem.SummaryValue.ToString)
                '
                Dim id_acc_x As String = ""
                q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
                '-debit
                '-- item
                If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
                Else
                    id_acc_x = get_coa_mapping(id_coa_m_d, "1")
                End If

                q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Receive Purchasing Domestic - " & _comp_name, report_mark_type, id_report)
                'credit
                If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
                Else
                    id_acc_x = get_coa_mapping(id_coa_m_k, "1")
                End If

                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Receive Purchasing Domestic - " & _comp_name, report_mark_type, id_report)
                execute_non_query(q_posting, True, "", "", "", "")
            ElseIf id_po_type = "2" Then 'import
                'declare account
                Dim id_coa_m_d As String = "7"
                Dim id_coa_m_k As String = "8"
                'vendor name and code
                Dim _comp_code As String = get_company_x(FormMatRecPurcDet.id_comp_from, "2")
                Dim _comp_name As String = FormMatRecPurcDet.TECompName.Text
                Dim _value_str As String = decimalSQL(FormMatRecPurcDet.GVListPurchase.Columns("mat_purc_rec_det_price").SummaryItem.SummaryValue.ToString)
                '
                Dim id_acc_x As String = ""
                q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
                '-debit
                '-- item
                If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
                Else
                    id_acc_x = get_coa_mapping(id_coa_m_d, "1")
                End If

                q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Receive Purchasing Import - " & _comp_name, report_mark_type, id_report)
                'credit
                If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
                Else
                    id_acc_x = get_coa_mapping(id_coa_m_k, "1")
                End If

                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Receive Purchasing Import  - " & _comp_name, report_mark_type, id_report)
                execute_non_query(q_posting, True, "", "", "", "")
            ElseIf id_po_type = "3" Then 'non merchandise
                'declare account
                Dim id_coa_m_d As String = "19"
                Dim id_coa_m_k As String = "20"
                'vendor name and code
                Dim _comp_code As String = get_company_x(FormMatRecPurcDet.id_comp_from, "2")
                Dim _comp_name As String = FormMatRecPurcDet.TECompName.Text
                Dim _value_str As String = decimalSQL(FormMatRecPurcDet.GVListPurchase.Columns("mat_purc_rec_det_price").SummaryItem.SummaryValue.ToString)
                '
                Dim id_acc_x As String = ""
                q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
                '-debit
                '-- item
                If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
                Else
                    id_acc_x = get_coa_mapping(id_coa_m_d, "1")
                End If

                q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Receive Purchasing Non Merchandise - " & _comp_name, report_mark_type, id_report)
                'credit
                If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
                Else
                    id_acc_x = get_coa_mapping(id_coa_m_k, "1")
                End If

                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Receive Purchasing Non Merchandise - " & _comp_name, report_mark_type, id_report)
                execute_non_query(q_posting, True, "", "", "", "")
            End If
        ElseIf report_mark_type = "15" Then 'mat wo
            'declare account
            Dim id_coa_m_d As String = "33"
            Dim id_coa_m_k As String = "34"
            'vendor name and code
            Dim _comp_code As String = FormMatWODet.TECompCode.Text
            Dim _comp_name As String = FormMatWODet.TECompName.Text
            Dim _value_str As String = decimalSQL(FormMatWODet.GVListPurchase.Columns("total").SummaryItem.SummaryValue.ToString)
            '
            Dim id_acc_x As String = ""
            q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
            '-debit
            '-- item
            If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_d, "1")
            End If

            q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Work Order - " & _comp_name, report_mark_type, id_report)
            'credit
            If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_k, "1")
            End If

            q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Work Order - " & _comp_name, report_mark_type, id_report)
            execute_non_query(q_posting, True, "", "", "", "")
        ElseIf report_mark_type = "17" Then 'mat rec wo
            'declare account
            Dim id_coa_m_d As String = "35"
            Dim id_coa_m_k As String = "36"
            'vendor name and code
            Dim _comp_code As String = get_company_x(FormMatRecWODet.id_comp_from, "2")
            Dim _comp_name As String = FormMatRecWODet.TECompName.Text
            Dim _value_str As String = decimalSQL(FormMatRecWODet.GVListPurchase.Columns("total_price").SummaryItem.SummaryValue.ToString)
            '
            Dim id_acc_x As String = ""
            q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
            '-debit
            '-- item
            If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_d, "1")
            End If

            q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material WO Receiving - " & _comp_name, report_mark_type, id_report)
            'credit
            If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_k, "1")
            End If

            q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material WO Receiving - " & _comp_name, report_mark_type, id_report)
            execute_non_query(q_posting, True, "", "", "", "")
        ElseIf report_mark_type = "18" Then 'mat ret out
            Dim query_det As String = "SELECT b.id_po_type FROM tb_mat_purc_ret_out a INNER JOIN tb_mat_purc b ON a.id_mat_purc=b.id_mat_purc WHERE a.id_mat_purc_ret_out='" & id_report & "'"
            Dim id_po_type As String = execute_query(query_det, 0, True, "", "", "", "")

            If id_po_type = "1" Then 'domestic
                'declare account
                Dim id_coa_m_d As String = "21"
                Dim id_coa_m_k As String = "22"
                'vendor name and code
                Dim _comp_code As String = FormMatRetOutDet.TxtCodeCompTo.Text
                Dim _comp_name As String = FormMatRetOutDet.TxtNameCompTo.Text
                Dim _value_str As String = decimalSQL(FormMatRetOutDet.GVRetDetail.Columns("mat_purc_ret_out_det_price").SummaryItem.SummaryValue.ToString)
                '
                Dim id_acc_x As String = ""
                q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
                '-debit
                '-- item
                If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
                Else
                    id_acc_x = get_coa_mapping(id_coa_m_d, "1")
                End If

                q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Return Out - " & _comp_name, report_mark_type, id_report)
                'credit
                If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
                Else
                    id_acc_x = get_coa_mapping(id_coa_m_k, "1")
                End If

                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Return Out - " & _comp_name, report_mark_type, id_report)
                execute_non_query(q_posting, True, "", "", "", "")
            ElseIf id_po_type = "2" Then 'import
                'declare account
                Dim id_coa_m_d As String = "9"
                Dim id_coa_m_k As String = "10"
                'vendor name and code
                Dim _comp_code As String = FormMatRetOutDet.TxtCodeCompTo.Text
                Dim _comp_name As String = FormMatRetOutDet.TxtNameCompTo.Text
                Dim _value_str As String = decimalSQL(FormMatRetOutDet.GVRetDetail.Columns("mat_purc_ret_out_det_price").SummaryItem.SummaryValue.ToString)
                '
                Dim id_acc_x As String = ""
                q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
                '-debit
                '-- item
                If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
                Else
                    id_acc_x = get_coa_mapping(id_coa_m_d, "1")
                End If

                q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Return Out - " & _comp_name, report_mark_type, id_report)
                'credit
                If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
                Else
                    id_acc_x = get_coa_mapping(id_coa_m_k, "1")
                End If

                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Return Out - " & _comp_name, report_mark_type, id_report)
                execute_non_query(q_posting, True, "", "", "", "")
            ElseIf id_po_type = "3" Then 'non merchandise
                'declare account
                Dim id_coa_m_d As String = "23"
                Dim id_coa_m_k As String = "24"
                'vendor name and code
                Dim _comp_code As String = FormMatRetOutDet.TxtCodeCompTo.Text
                Dim _comp_name As String = FormMatRetOutDet.TxtNameCompTo.Text
                Dim _value_str As String = decimalSQL(FormMatRetOutDet.GVRetDetail.Columns("mat_purc_ret_out_det_price").SummaryItem.SummaryValue.ToString)
                '
                Dim id_acc_x As String = ""
                q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
                '-debit
                '-- item
                If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
                Else
                    id_acc_x = get_coa_mapping(id_coa_m_d, "1")
                End If

                q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Return Out - " & _comp_name, report_mark_type, id_report)
                'credit
                If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
                Else
                    id_acc_x = get_coa_mapping(id_coa_m_k, "1")
                End If

                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Return Out - " & _comp_name, report_mark_type, id_report)
                execute_non_query(q_posting, True, "", "", "", "")
            End If
        ElseIf report_mark_type = "26" Then 'mat adj in
            'declare account
            Dim id_coa_m_d As String = "25"
            Dim id_coa_m_k As String = "26"
            'vendor name and code
            Dim _comp_code As String = ""
            Dim _comp_name As String = ""
            Dim _value_str As String = decimalSQL(FormMatAdjInSingle.GVDetail.Columns("adj_in_mat_det_amount").SummaryItem.SummaryValue.ToString)
            '
            Dim id_acc_x As String = ""
            q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
            '-debit
            '-- item
            If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_d, "1")
            End If

            q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Adjustment In " & _comp_name, report_mark_type, id_report)
            'credit
            If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_k, "1")
            End If

            q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Adjustment In " & _comp_name, report_mark_type, id_report)
            execute_non_query(q_posting, True, "", "", "", "")
        ElseIf report_mark_type = "30" Then 'mat PL
            'declare account
            Dim id_coa_m_d As String = "37"
            Dim id_coa_m_k As String = "38"
            'vendor name and code
            Dim _comp_code As String = FormMatPLSingle.TxtCodeCompTo.Text
            Dim _comp_name As String = FormMatPLSingle.TxtNameCompTo.Text
            Dim _value_str As String = decimalSQL(FormMatPLSingle.GVDrawer.Columns("total_price").SummaryItem.SummaryValue.ToString)
            '
            Dim id_acc_x As String = ""
            q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
            '-debit
            '-- item
            If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_d, "1")
            End If

            q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Packing List " & _comp_name, report_mark_type, id_report)
            'credit
            If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_k, "1")
            End If

            q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Packing List " & _comp_name, report_mark_type, id_report)
            execute_non_query(q_posting, True, "", "", "", "")
        ElseIf report_mark_type = "27" Then 'mat adj out
            'declare account
            Dim id_coa_m_d As String = "27"
            Dim id_coa_m_k As String = "28"
            'vendor name and code
            Dim _comp_code As String = ""
            Dim _comp_name As String = ""
            Dim _value_str As String = decimalSQL(FormMatAdjOutSingle.GVDetail.Columns("adj_out_mat_det_amount").SummaryItem.SummaryValue.ToString)
            '
            Dim id_acc_x As String = ""
            q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
            '-debit
            '-- item
            If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_d, "1")
            End If

            q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Adjustment Out " & _comp_name, report_mark_type, id_report)
            'credit
            If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_k, "1")
            End If

            q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Adjustment Out " & _comp_name, report_mark_type, id_report)
            execute_non_query(q_posting, True, "", "", "", "")
        ElseIf report_mark_type = "20" Then 'sample adjustment in
            'declare account
            Dim id_coa_m_d As String = "29"
            Dim id_coa_m_k As String = "30"
            'vendor name and code
            Dim _comp_code As String = ""
            Dim _comp_name As String = ""
            Dim _value_str As String = decimalSQL(FormSampleAdjustmentInSingle.GVDetail.Columns("adj_in_sample_det_amount").SummaryItem.SummaryValue.ToString)
            '
            Dim id_acc_x As String = ""
            q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
            '-debit
            '-- item
            If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_d, "1")
            End If

            q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Sample Adjustment In " & _comp_name, report_mark_type, id_report)
            'credit
            If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_k, "1")
            End If

            q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Sample Adjustment In " & _comp_name, report_mark_type, id_report)
            execute_non_query(q_posting, True, "", "", "", "")
        ElseIf report_mark_type = "21" Then 'sample adjustment out
            'declare account
            Dim id_coa_m_d As String = "31"
            Dim id_coa_m_k As String = "32"
            'vendor name and code
            Dim _comp_code As String = ""
            Dim _comp_name As String = ""
            Dim _value_str As String = decimalSQL(FormSampleAdjustmentOutSingle.GVDetail.Columns("adj_out_sample_det_amount").SummaryItem.SummaryValue.ToString)
            '
            Dim id_acc_x As String = ""
            q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
            '-debit
            '-- item
            If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_d, "1")
            End If

            q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Sample Adjustment Out " & _comp_name, report_mark_type, id_report)
            'credit
            If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_k, "1")
            End If

            q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Sample Adjustment Out " & _comp_name, report_mark_type, id_report)
            execute_non_query(q_posting, True, "", "", "", "")
        ElseIf report_mark_type = "23" Then 'Production Work Order
            'declare account
            Dim id_coa_m_d As String = "45"
            Dim id_coa_m_k As String = "46"
            Dim id_coa_m_v As String = "47" 'vat
            Dim id_v_dc As String = get_coa_mapping(id_coa_m_v, "5")
            'vendor name and code
            Dim _comp_code As String = FormMatInvoiceReturDet.TECompCode.Text
            Dim _comp_name As String = FormMatInvoiceReturDet.TECompName.Text
            Dim _value_str As String = decimalSQL(FormMatInvoiceReturDet.TETot.EditValue.ToString)
            Dim _value_gross_str As String = decimalSQL(FormMatInvoiceReturDet.TEGrossTot.EditValue.ToString)
            Dim _value_vat_str As String = decimalSQL(FormMatInvoiceReturDet.TEVatTot.EditValue.ToString)
            '
            Dim id_acc_x As String = ""
            q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
            '-debit
            '-- item
            If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_d, "1")
            End If

            If id_v_dc = "1" Then 'debit
                q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_gross_str, 0, "Material Invoice Retur " & _comp_name, report_mark_type, id_report)
            Else
                q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Invoice Retur " & _comp_name, report_mark_type, id_report)
            End If

            'credit
            If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_k, "1")
            End If
            '
            If id_v_dc = "1" Then 'debit
                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Invoice Retur " & _comp_name, report_mark_type, id_report)
            Else
                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_gross_str, "Material Invoice Retur " & _comp_name, report_mark_type, id_report)
            End If

            'vat
            If get_coa_mapping(id_coa_m_v, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_v, "1"), get_coa_mapping(id_coa_m_v, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_v, "1")
            End If
            '
            If id_v_dc = "1" Then 'debit
                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_vat_str, 0, "Material Invoice Retur Vat " & _comp_name, report_mark_type, id_report)
            Else
                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_vat_str, "Material Invoice Retur Vat " & _comp_name, report_mark_type, id_report)
            End If

            execute_non_query(q_posting, True, "", "", "", "")
        ElseIf report_mark_type = "34" Then 'Mat Invoice
            'declare account
            Dim id_coa_m_d As String = "39"
            Dim id_coa_m_k As String = "40"
            Dim id_coa_m_v As String = "41" 'vat
            Dim id_v_dc As String = get_coa_mapping(id_coa_m_v, "5")
            'vendor name and code
            Dim _comp_code As String = FormMatInvoiceDet.TECompCode.Text
            Dim _comp_name As String = FormMatInvoiceDet.TECompName.Text
            Dim _value_str As String = decimalSQL(FormMatInvoiceDet.TETot.EditValue.ToString)
            Dim _value_gross_str As String = decimalSQL(FormMatInvoiceDet.TEGrossTot.EditValue.ToString)
            Dim _value_vat_str As String = decimalSQL(FormMatInvoiceDet.TEVatTot.EditValue.ToString)
            '
            Dim id_acc_x As String = ""
            q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
            '-debit
            '-- item
            If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_d, "1")
            End If

            If id_v_dc = "1" Then 'debit
                q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_gross_str, 0, "Material Invoice " & _comp_name, report_mark_type, id_report)
            Else
                q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Invoice " & _comp_name, report_mark_type, id_report)
            End If

            'credit
            If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_k, "1")
            End If
            '
            If id_v_dc = "1" Then 'debit
                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Invoice " & _comp_name, report_mark_type, id_report)
            Else
                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_gross_str, "Material Invoice " & _comp_name, report_mark_type, id_report)
            End If

            'vat
            If get_coa_mapping(id_coa_m_v, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_v, "1"), get_coa_mapping(id_coa_m_v, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_v, "1")
            End If
            '
            If id_v_dc = "1" Then 'debit
                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_vat_str, 0, "Material Invoice Vat " & _comp_name, report_mark_type, id_report)
            Else
                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_vat_str, "Material Invoice Vat " & _comp_name, report_mark_type, id_report)
            End If

            execute_non_query(q_posting, True, "", "", "", "")
        ElseIf report_mark_type = "35" Then 'Mat Invoice Retur
            'declare account
            Dim id_coa_m_d As String = "42"
            Dim id_coa_m_k As String = "43"
            Dim id_coa_m_v As String = "44" 'vat
            Dim id_v_dc As String = get_coa_mapping(id_coa_m_v, "5")
            'vendor name and code
            Dim _comp_code As String = FormMatInvoiceReturDet.TECompCode.Text
            Dim _comp_name As String = FormMatInvoiceReturDet.TECompName.Text
            Dim _value_str As String = decimalSQL(FormMatInvoiceReturDet.TETot.EditValue.ToString)
            Dim _value_gross_str As String = decimalSQL(FormMatInvoiceReturDet.TEGrossTot.EditValue.ToString)
            Dim _value_vat_str As String = decimalSQL(FormMatInvoiceReturDet.TEVatTot.EditValue.ToString)
            '
            Dim id_acc_x As String = ""
            q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
            '-debit
            '-- item
            If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_d, "1")
            End If

            If id_v_dc = "1" Then 'debit
                q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_gross_str, 0, "Material Invoice Retur " & _comp_name, report_mark_type, id_report)
            Else
                q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Invoice Retur " & _comp_name, report_mark_type, id_report)
            End If

            'credit
            If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_k, "1")
            End If
            '
            If id_v_dc = "1" Then 'debit
                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Invoice Retur " & _comp_name, report_mark_type, id_report)
            Else
                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_gross_str, "Material Invoice Retur " & _comp_name, report_mark_type, id_report)
            End If

            'vat
            If get_coa_mapping(id_coa_m_v, "4").ToString = "1" Then
                id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_v, "1"), get_coa_mapping(id_coa_m_v, "2") & _comp_code, _comp_name)
            Else
                id_acc_x = get_coa_mapping(id_coa_m_v, "1")
            End If
            '
            If id_v_dc = "1" Then 'debit
                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_vat_str, 0, "Material Invoice Retur Vat " & _comp_name, report_mark_type, id_report)
            Else
                q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_vat_str, "Material Invoice Retur Vat " & _comp_name, report_mark_type, id_report)
            End If

            execute_non_query(q_posting, True, "", "", "", "")
        End If
        insert_who_prepared("36", last_id, id_user)
        increase_inc_acc("1")
    End Sub
    Private Sub BLeadTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLeadTime.Click
        If check_available_lead_time(GVMark.GetFocusedRowCellDisplayText("id_report_mark").ToString) Then
            FormReportMarkTime.id_report_mark = GVMark.GetFocusedRowCellDisplayText("id_report_mark").ToString
            FormReportMarkTime.ShowDialog()
        Else
            stopCustom("Previous mark must be completed.")
        End If
    End Sub

    Private Sub GVMark_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMark.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub

    Private Sub GVMark_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVMark.RowStyle
        If (e.RowHandle >= 0) Then
            'pick field
            'see if already marked
            If check_available_asg_color(sender.GetRowCellDisplayText(e.RowHandle, sender.Columns("id_report_mark"))) Then
                'already marked
                Dim lead_time As String = sender.GetRowCellDisplayText(e.RowHandle, sender.Columns("raw_lead_time"))
                'condition
                If Not lead_time = "" Then
                    If Integer.Parse(check_date_passed_now(lead_time)) > 0 Then
                        e.Appearance.BackColor = Color.Salmon
                        e.Appearance.BackColor2 = Color.Salmon
                    End If
                End If
            End If
            '
            If sender.GetRowCellDisplayText(e.RowHandle, sender.Columns("id_user")).ToString = id_user Then
                e.Appearance.Font = New Font(GVMark.Appearance.Row.Font, FontStyle.Bold)
            End If
        End If
    End Sub

    Private Sub BClearLeadTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BClearLeadTime.Click
        'MsgBox(id_report_status_report)
        If id_report_status_report.ToString = "1" And check_edit_report_status(id_report_status_report, report_mark_type, id_report) Then
            'clear lead time
            Dim query As String = ""
            query = String.Format("UPDATE tb_report_mark SET report_mark_start_datetime=NULL,report_mark_lead_time=NULL,report_mark_datetime=NULL WHERE id_report_mark='{0}'", GVMark.GetFocusedRowCellDisplayText("id_report_mark").ToString)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Lead time cleared.")
            view_mark()
        Else
            stopCustom("This report already approved.")
        End If
    End Sub

    Public Sub sendNotif(ByVal type_par As String)
        Dim type As String = ""
        If type_par = "1" Then
            type = "accepted"
        Else
            type = "refused"
        End If

        Dim dt As DataTable = get_who_prepared(report_mark_type, id_report)
        If report_mark_type = "9" Or report_mark_type = "80" Or report_mark_type = "81" Then
            pushNotif("Production Demand", "Document #" + report_number + " is " + type, "FormProdDemand", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1")
        ElseIf report_mark_type = "11" Then
            pushNotif("Sample Requisition", "Document #" + report_number + " is " + type + " by " + get_user_identify(dt.Rows(0)("id_user"), "1") + ".", "FormSampleReq", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1")
        ElseIf report_mark_type = "28" Then
            pushNotif("Receiving QC", "Document #" + report_number + " is " + type + " by " + get_user_identify(id_user, "1") + ".", "FormProductionRec", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1")
        ElseIf report_mark_type = "31" Then
            pushNotif("Return Out", "Document #" + report_number + " is " + type, "FormProductionRet", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1")
        ElseIf report_mark_type = "32" Then
            pushNotif("Return In", "Document #" + report_number + " is " + type, "FormProductionRet", dt.Rows(0)("id_user"), id_user, id_report, report_number, "2")
        ElseIf report_mark_type = "33" Then
            pushNotif("Packing List", "Document #" + report_number + " is " + type, "FormProductionPLToWH", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1")
        ElseIf report_mark_type = "37" Then
            pushNotif("Received FG in Warehouse", "Document #" + report_number + " is " + type, "FormProductionPLToWHRec", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1")
        ElseIf report_mark_type = "45" Then
            pushNotif("Return Order", "Document #" + report_number + " is " + type, "FormSalesReturnOrder", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1")
        ElseIf report_mark_type = "46" Then
            pushNotif("Return", "Document #" + report_number + " is " + type, "FormSalesReturn", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1")
        ElseIf report_mark_type = "49" Then
            pushNotif("Return QC", "Document #" + report_number + " is " + type, "FormSalesReturnQC", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1")
        ElseIf report_mark_type = "82" Then
            pushNotif("Product Price From Excel", "Document #" + report_number + " is " + type, "FormMasterPrice", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1")
        ElseIf report_mark_type = "85" Then
            pushNotif("Packing List Sampple", "Document #" + report_number + " " + type, "FormSamplePLToWH", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1")
        ElseIf report_mark_type = "86" Then
            pushNotif("Sample Price From Excel", "Document #" + report_number + " is " + type, "FormMasterPriceSample", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1")
        ElseIf report_mark_type = "87" Then
            pushNotif("Inventory Allocation", "Document #" + report_number + " " + type, "FormFGWHAlloc", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1")
        ElseIf report_mark_type = "88" Then
            pushNotif("Generate Prepare Order", "Document #" + report_number + " " + type + " by " + get_user_identify(id_user, "1") + ".", "FormSalesOrder", dt.Rows(0)("id_user"), id_user, id_report, report_number, "2")
        End If
    End Sub

    Private Sub BReset_Click(sender As Object, e As EventArgs) Handles BReset.Click
        Dim query As String

        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Reset all mark on this document, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            query = String.Format("UPDATE tb_report_mark SET id_mark='1',report_mark_lead_time=NULL,report_mark_start_datetime=NULL,report_mark_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'{2}'", report_mark_type, id_report, 1)
            execute_non_query(query, True, "", "", "", "")
            change_status(1)
            view_mark()
        End If
    End Sub
End Class