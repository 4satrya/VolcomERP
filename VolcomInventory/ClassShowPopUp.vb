Public Class ClassShowPopUp
    Public id_report As String = "-1"
    Public report_mark_type As String = "-1"

    Public is_payment As String = "-1"

    Public report_number As String = ""
    Public report_date As Date = Now
    Public info_col As String = ""
    '
    Public info_report As String = ""
    Public info_design As String = ""
    Public info_design_code As String = ""
    '
    Public query_view As String = ""
    Public query_view_blank As String = ""
    Public query_view_edit As String = ""
    Public id_report_mark_cancel As String = ""

    Public is_qb As String = ""
    Public qb_id_not_include As String = ""
    Public opt As String = ""
    '
    Sub double_click(ByVal var As String)
        If report_mark_type = "9" Then
            'prod demand
            Dim query As String = "SELECT id_prod_demand FROM `tb_prod_demand` WHERE prod_demand_number='" & var & "' LIMIT 1"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_report = data.Rows(0)("id_prod_demand").ToString
        End If
    End Sub
    '
    Sub close()
        If report_mark_type = "1" Then
            'sample purchase
            FormViewSamplePurchase.Close()
        ElseIf report_mark_type = "2" Then
            'sample receive
            FormViewSampleReceive.Close()
        ElseIf report_mark_type = "3" Then
            'sample PL
            FormViewSamplePL.Close()
        ElseIf report_mark_type = "4" Then
            'sample PR
            FormViewSamplePR.Close()
        ElseIf report_mark_type = "8" Then
            'bom
            FormViewBOM.Close()
        ElseIf report_mark_type = "9" Then
            'prod demand
            FormViewProdDemand.Close()
        ElseIf report_mark_type = "10" Then
            'sample packing list delivery
            FormViewSamplePLDel.Close()
        ElseIf report_mark_type = "11" Then
            'sample requisition
            FormViewSampleReq.Close()
        ElseIf report_mark_type = "12" Then
            'sample plan
            FormViewSamplePlan.Close()
        ElseIf report_mark_type = "13" Then
            'Mat PO
            FormViewMatPurc.Close()
        ElseIf report_mark_type = "14" Then
            'sample return from delivery
            FormViewSampleReturn.Close()
        ElseIf report_mark_type = "15" Then
            'Mat WO
            FormViewMatWO.Close()
        ElseIf report_mark_type = "16" Then
            'Mat Rec Purc
            FormViewMatRecPurc.Close()
        ElseIf report_mark_type = "17" Then
            FormViewMatRecWO.Close()
        ElseIf report_mark_type = "18" Then
            'return out material
            FormViewMatRetOut.Close()
        ElseIf report_mark_type = "19" Then
            'return in material
            FormViewMatRetIn.Close()
        ElseIf report_mark_type = "22" Then
            'Production Order
            FormViewProduction.Close()
        ElseIf report_mark_type = "23" Then
            'Production Work Order
            FormViewProductionWO.Close()
        ElseIf report_mark_type = "24" Then
            'material PR PO
            FormViewMatPR.Close()
        ElseIf report_mark_type = "25" Then
            'material PR WO
            FormViewMatPRWO.Close()
        ElseIf report_mark_type = "28" Or report_mark_type = "127" Then
            'receiving QC
            FormViewProductionRec.Close()
        ElseIf report_mark_type = "29" Then
            'production MRS
            FormViewProductionMRS.Close()
        ElseIf report_mark_type = "30" Then
            'production pl MRS
            FormViewMatPLSingle.ShowDialog()
        ElseIf report_mark_type = "31" Then
            'return out production
            FormViewProductionRetOut.Close()
        ElseIf report_mark_type = "32" Then
            'return in production
            FormViewProductionRetIn.Close()
        ElseIf report_mark_type = "36" Then
            'entry journal
            FormViewJournal.Close()
        ElseIf report_mark_type = "41" Then
            'Adj In Fg
            FormFGAdjInDet.Close()
        ElseIf report_mark_type = "42" Then
            'Adj Out Fg
            FormFGAdjOutDet.Close()
        ElseIf report_mark_type = "44" Then
            'non production MRS
            FormViewMatMRS.Close()
        ElseIf report_mark_type = "47" Then
            'return in mat
            FormViewMatRetInProd.Close()
        ElseIf report_mark_type = "48" Or report_mark_type = "66" Or report_mark_type = "118" Or report_mark_type = "54" Or report_mark_type = "67" Or report_mark_type = "116" Or report_mark_type = "117" Or report_mark_type = "183" Then
            'invoice/missing/credit note
            FormViewSalesPOS.Close()
        ElseIf report_mark_type = "50" Then
            'PR Prod Order
            FormViewPRProdWO.Close()
        ElseIf report_mark_type = "65" Then
            'code replacement
            FormViewFGCodeReplaceStore.Close()
        ElseIf report_mark_type = "70" Then
            'propose price
            FormFGProposePriceDetail.Close()
        ElseIf report_mark_type = "95" Or report_mark_type = "164" Or report_mark_type = "165" Then
            'propose leave
            FormEmpLeaveDet.Close()
        ElseIf report_mark_type = "96" Then
            'propose leave need management approval
            FormEmpLeaveDet.Close()
        ElseIf report_mark_type = "99" Then
            'propose leave manager
            FormEmpLeaveDet.Close()
        ElseIf report_mark_type = "102" Then
            'propose leave HRD
            FormEmpLeaveDet.Close()
        ElseIf report_mark_type = "104" Then
            'propose leave HRD
            FormEmpLeaveDet.Close()
        ElseIf report_mark_type = "105" Or report_mark_type = "224" Then
            'final clearance
            FormProductionFinalClearDet.Close()
        ElseIf report_mark_type = "108" Then
            'propose leave manager
            FormEmpLeaveDet.Close()
        ElseIf report_mark_type = "109" Then
            'propose leave manager
            FormEmpLeaveDet.Close()
        ElseIf report_mark_type = "110" Then
            'propose leave manager
            FormEmpLeaveDet.Close()
        ElseIf report_mark_type = "123" Then
            'uniform list
            FormEmpUniListDet.Close()
        ElseIf report_mark_type = "124" Then
            'propose leave manager
            FormEmpLeaveDet.Close()
        ElseIf report_mark_type = "126" Then
            'memo over prod
            FormProdOverMemoDet.Close()
        ElseIf report_mark_type = "128" Then
            'Asset PO
            FormAssetPODet.Close()
        ElseIf report_mark_type = "129" Then
            'Asset Rec
            FormAssetRecDet.Close()
        ElseIf report_mark_type = "130" Then
            'UNIFORM ORDER
            FormEmpUniOrderDet.Close()
        ElseIf report_mark_type = "132" Then
            'UNIFORM EXPENSE
            FormEmpUniExpenseDet.Close()
        ElseIf report_mark_type = "133" Then
            'PROPOSE NEW BUDGET
            FormBudgetRevProposeDet.Close()
        ElseIf report_mark_type = "134" Then
            'PROPOSE NEW ITem Cat
            FormItemCatProposeDet.Close()
        ElseIf report_mark_type = "135" Then
            'PROPOSE NEW ITem COA
            FormItemCatMappingDet.Close()
        ElseIf report_mark_type = "136" Then
            'PROPOSE BUDGET EXPENSE
            FormBudgetExpenseProposeDet.Close()
        ElseIf report_mark_type = "137" Or report_mark_type = "201" Or report_mark_type = "218" Then
            'Purchase Request
            FormPurcReqDet.Close()
        ElseIf report_mark_type = "138" Then
            'PROPOSE REVISION BUDGET EXPENSE
            FormBudgetExpenseRevisionDet.Close()
        ElseIf report_mark_type = "139" Or report_mark_type = "202" Then
            'Purchase Order
            FormPurcOrderDet.Close()
        ElseIf report_mark_type = "142" Then
            'Cancel Form
            FormReportMarkCancel.Close()
        ElseIf report_mark_type = "143" Or report_mark_type = "144" Or report_mark_type = "145" Or report_mark_type = "210" Then
            'PD REVISION
            FormProdDemandRevDet.Close()
        ElseIf report_mark_type = "147" Then
            'Revision revenue budget
            FormBudgetRevenueRevisionDet.Close()
        ElseIf report_mark_type = "148" Then
            'purchase receive non asset
            'FormPurcReceiveDet.Close()
        ElseIf report_mark_type = "150" Or report_mark_type = "155" Or report_mark_type = "172" Or report_mark_type = "173" Then
            'Prpose Cost
            FormMasterDesignCOPPropose.Close()
        ElseIf report_mark_type = "151" Then
            'claim return
            FormProductionClaimReturnDet.Close()
        ElseIf report_mark_type = "152" Then
            'purchase return
            FormPurchaseReturnDet.Close()
        ElseIf report_mark_type = "153" Then
            'Propose Company
            FormMasterCompany.Close()
        ElseIf report_mark_type = "154" Or report_mark_type = "163" Then
            'item req
            FormItemReqDet.Close()
        ElseIf report_mark_type = "157" Then
            'item expense
            FormItemExpenseDet.Close()
        ElseIf report_mark_type = "159" Then
            'payment
            FormBankWithdrawalDet.Close()
        ElseIf report_mark_type = "160" Then
            'asset
            FormPurcAssetDet.Close()
        ElseIf report_mark_type = "162" Then
            'Rec Payment
            FormBankDepositDet.Close()
        ElseIf report_mark_type = "237" Then
            'Tabungan Missing
            FormPaymentMissingDet.Close()
        ElseIf report_mark_type = "167" Then
            'Cash Advance
            FormCashAdvanceDet.Close()
        ElseIf report_mark_type = "168" Then
            'Receive Return
            FormSalesReturnRecDet.Close()
        ElseIf report_mark_type = "169" Then
            'value-added asset
            FormPurcAssetValueAdded.Close()
        ElseIf report_mark_type = "174" Then
            'Cash Advance Reconcile
            FormCashAdvanceReconcile.Close()
        ElseIf report_mark_type = "175" Then
            'Sample budget propose
            FormSampleBudgetDet.Close()
        ElseIf report_mark_type = "176" Or report_mark_type = "177" Or report_mark_type = "178" Then
            'Propose Changes
            FormMasterDesignSingle.Close()
        ElseIf report_mark_type = "180" Then
            'Employee Propose
            FormEmployeePpsDet.Close()
        ElseIf report_mark_type = "184" Or report_mark_type = "213" Or report_mark_type = "214" Or report_mark_type = "219" Or report_mark_type = "220" Then
            'Overtime employee
            FormEmpOvertimeDet.Close()
        ElseIf report_mark_type = "185" Then
            'Sample Purchase Closing
            FormSamplePurcClose.Close()
        ElseIf report_mark_type = "187" Or report_mark_type = "215" Or report_mark_type = "216" Then
            'Overtime employee report
            FormEmpOvertimeVerification.Close()
        ElseIf report_mark_type = "188" Then
            'propose price new product-revision
            FormFGProposePriceRev.Close()
        ElseIf report_mark_type = "189" Then
            'Bukti Pembelian
            FormInvoiceFGPODP.Close()
        ElseIf report_mark_type = "190" Or report_mark_type = "193" Then
            'propose work order MTC/IT
            FormWorkOrderDet.Close()
        ElseIf report_mark_type = "192" Then
            'payroll
            Dim id_payroll As String = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString

            FormEmpPayroll.load_payroll()

            FormEmpPayroll.GVPayrollPeriode.FocusedRowHandle = find_row(FormEmpPayroll.GVPayrollPeriode, "id_payroll", id_payroll)

            FormEmpPayroll.load_payroll_detail()
        ElseIf report_mark_type = "179" Then
            'sample material purchase
            FormSampleExpenseDet.Close()
        ElseIf report_mark_type = "197" Or report_mark_type = "229" Then
            'propose employee salary
            FormProposeEmpSalaryDet.Close()
        ElseIf report_mark_type = "200" Then
            'propose design changes
            FormFGDesignListChanges.Close()
        ElseIf report_mark_type = "203" Or report_mark_type = "204" Then
            'propose budget OPEX
            FormSetupBudgetOPEX.Close()
        ElseIf report_mark_type = "206" Then
            'prod demand sales
            FormViewProdDemand.Close()
        ElseIf report_mark_type = "207" Then
            'Item Cat Main
            FormItemCatMainDet.Close()
        ElseIf report_mark_type = "208" Or report_mark_type = "209" Then
            'propose budget CAPEX
            FormSetupBudgetCAPEXDet.Close()
        ElseIf report_mark_type = "211" Then
            FormEmpInputAttendanceDet.Close()
        ElseIf report_mark_type = "212" Then
            'Prod order closing
            FormProdClosingPps.Close()
        ElseIf report_mark_type = "217" Then
            'bukti pickup
            FormBuktiPickupDet.Close()
        ElseIf report_mark_type = "221" Then
            'debit note
            FormDebitNoteDet.Close()
        ElseIf report_mark_type = "223" Then
            'bpjs kesehatan
            FormEmpBPJSKesehatanDet.Close()
        ElseIf report_mark_type = "222" Then
            'summary qc report
            FormProductionFinalClearSummary.Close()
        ElseIf report_mark_type = "231" Then
            'invoice
            FormInvMatDet.Close()
        ElseIf report_mark_type = "233" Then
            'delay payment
            FormDelayPaymentDet.Close()
        ElseIf report_mark_type = "234" Then
            'follow up ar
            FormFollowUpARHistory.Close()
        ElseIf report_mark_type = "236" Then
            'UNIFORM CREDIT NOTE
            FormEmpUniCreditNoteDet.Close()
        End If
    End Sub
    Sub show()
        If report_mark_type = "1" Then
            'sample purchase
            FormViewSamplePurchase.id_sample_purc = id_report
            FormViewSamplePurchase.ShowDialog()
        ElseIf report_mark_type = "2" Then
            'sample receive
            FormViewSampleReceive.id_receive = id_report
            FormViewSampleReceive.ShowDialog()
        ElseIf report_mark_type = "3" Then
            'sample PL
            FormViewSamplePL.id_pl_sample_purc = id_report
            FormViewSamplePL.ShowDialog()
        ElseIf report_mark_type = "4" Then
            'sample PR
            FormViewSamplePR.is_payment = is_payment
            FormViewSamplePR.id_pr = id_report
            FormViewSamplePR.ShowDialog()
        ElseIf report_mark_type = "5" Then
            'sample ret out

        ElseIf report_mark_type = "6" Then
            'sample ret in

        ElseIf report_mark_type = "7" Then
            'sample receipt

        ElseIf report_mark_type = "8" Then
            'bom
            FormViewBOM.id_bom = id_report
            FormViewBOM.ShowDialog()
        ElseIf report_mark_type = "9" Then
            'prod demand
            FormViewProdDemand.id_prod_demand = id_report
            FormViewProdDemand.report_mark_type = report_mark_type
            FormViewProdDemand.WindowState = FormWindowState.Maximized
            FormViewProdDemand.ShowDialog()
        ElseIf report_mark_type = "10" Then
            'sample packing list delivery
            FormViewSamplePLDel.action = "upd"
            FormViewSamplePLDel.id_pl_sample_del = id_report
            FormViewSamplePLDel.id_comp_contact_to = "-1"
            FormViewSamplePLDel.id_comp_contact_from = "-1"
            FormViewSamplePLDel.ShowDialog()
        ElseIf report_mark_type = "11" Then
            'sample requisition
            FormViewSampleReq.action = "upd"
            FormViewSampleReq.id_sample_requisition = id_report
            FormViewSampleReq.ShowDialog()
        ElseIf report_mark_type = "12" Then
            'sample plan
            FormViewSamplePlan.id_sample_plan = id_report
            FormViewSamplePlan.ShowDialog()
        ElseIf report_mark_type = "13" Then
            'mat purchase
            FormViewMatPurc.id_purc = id_report
            FormViewMatPurc.ShowDialog()
        ElseIf report_mark_type = "14" Then
            'sample return from delivery
            FormViewSampleReturn.action = "upd"
            FormViewSampleReturn.id_sample_return = id_report
            FormViewSampleReturn.ShowDialog()
        ElseIf report_mark_type = "15" Then
            'mat wo
            FormViewMatWO.id_purc = id_report
            FormViewMatWO.ShowDialog()
        ElseIf report_mark_type = "16" Then
            'receive material purchase
            FormViewMatRecPurc.id_receive = id_report
            FormViewMatRecPurc.ShowDialog()
        ElseIf report_mark_type = "17" Then
            'receive material wo
            FormViewMatRecWO.id_receive = id_report
            FormViewMatRecWO.ShowDialog()
        ElseIf report_mark_type = "18" Then
            'return out material
            FormViewMatRetOut.id_mat_purc_ret_out = id_report
            FormViewMatRetOut.ShowDialog()
        ElseIf report_mark_type = "19" Then
            'return in material
            FormViewMatRetIn.id_mat_purc_ret_in = id_report
            FormViewMatRetIn.ShowDialog()
        ElseIf report_mark_type = "20" Then
            'adj in sample
            FormViewSampleAdjIn.action = "upd"
            FormViewSampleAdjIn.id_adj_in_sample = id_report
            FormViewSampleAdjIn.ShowDialog()
        ElseIf report_mark_type = "21" Then
            'adj out sample
            FormViewSampleAdjOut.action = "upd"
            FormViewSampleAdjOut.id_adj_out_sample = id_report
            FormViewSampleAdjOut.ShowDialog()
        ElseIf report_mark_type = "22" Then
            'Production Order
            FormViewProduction.id_prod_order = id_report
            If opt = "no cost" Then
                FormViewProduction.is_no_cost = "1"
            End If
            FormViewProduction.ShowDialog()
        ElseIf report_mark_type = "23" Then
            'Production Work Order
            FormViewProductionWO.id_wo = id_report
            FormViewProductionWO.ShowDialog()
        ElseIf report_mark_type = "24" Then
            'material PR PO
            FormViewMatPR.id_pr = id_report
            FormViewMatPR.ShowDialog()
        ElseIf report_mark_type = "25" Then
            'material PR WO
            FormViewMatPRWO.id_pr = id_report
            FormViewMatPRWO.ShowDialog()
        ElseIf report_mark_type = "26" Then
            'adj in material
            FormViewMatAdjIn.action = "upd"
            FormViewMatAdjIn.id_adj_in_mat = id_report
            FormViewMatAdjIn.ShowDialog()
        ElseIf report_mark_type = "27" Then
            'adj out material
            FormViewMatAdjOut.action = "upd"
            FormViewMatAdjOut.id_adj_out_mat = id_report
            FormViewMatAdjOut.ShowDialog()
        ElseIf report_mark_type = "28" Or report_mark_type = "127" Then
            'receive FG QC
            Dim q_before As String = "SELECT GROUP_CONCAT(rec.prod_order_rec_number) AS rec_before
FROM tb_prod_order_rec rec 
WHERE (rec.id_report_status!='6' AND rec.id_report_status!='5') AND rec.`id_prod_order_rec` < '" & id_report & "' AND rec.`id_prod_order`=(SELECT id_prod_order FROM tb_prod_order_rec WHERE id_prod_order_rec='" & id_report & "')
GROUP BY rec.`id_prod_order`"
            Dim dt As DataTable = execute_query(q_before, -1, True, "", "", "", "")
            '
            If dt.Rows.Count > 0 Then
                warningCustom("Please approve receiving before this : " & dt.Rows(0)("rec_before").ToString)
            Else
                FormViewProductionRec.id_receive = id_report
                FormViewProductionRec.ShowDialog()
            End If
        ElseIf report_mark_type = "29" Then
            'Production Work Order
            FormViewProductionMRS.id_mrs = id_report
            FormViewProductionMRS.ShowDialog()
        ElseIf report_mark_type = "30" Then
            'Production Work Order
            FormViewMatPLSingle.id_pl_mrs = id_report
            FormViewMatPLSingle.ShowDialog()
        ElseIf report_mark_type = "31" Then
            'return Out FG
            FormViewProductionRetOut.id_prod_order_ret_out = id_report
            FormViewProductionRetOut.ShowDialog()
        ElseIf report_mark_type = "32" Then
            'return in FG
            FormViewProductionRetIn.id_prod_order_ret_in = id_report
            FormViewProductionRetIn.ShowDialog()
        ElseIf report_mark_type = "33" Then
            'PL FG TO WH
            FormViewProductionPLToWH.id_pl_prod_order = id_report
            FormViewProductionPLToWH.ShowDialog()
        ElseIf report_mark_type = "34" Then
            'Inv Mat PL MRS
            FormViewMatInvoice.id_invoice = id_report
            FormViewMatInvoice.ShowDialog()
        ElseIf report_mark_type = "35" Then
            'Inv Ret Mat PL MRS
            FormViewMatInvoiceRetur.id_retur = id_report
            FormViewMatInvoiceRetur.ShowDialog()
        ElseIf report_mark_type = "36" Then
            'Entry Journal
            FormViewJournal.id_trans = id_report
            FormViewJournal.ShowDialog()
        ElseIf report_mark_type = "37" Then
            'RECEIVING WH
            FormViewProductionPLToWHRec.id_pl_prod_order_rec = id_report
            FormViewProductionPLToWHRec.ShowDialog()
        ElseIf report_mark_type = "39" Then
            'SALES ORDER
            FormViewSalesOrder.id_sales_order = id_report
            FormViewSalesOrder.ShowDialog()
        ElseIf report_mark_type = "40" Then
            'Adjustment Journal
            FormAccountingJournalAdjDet.is_view = "1"
            FormAccountingJournalAdjDet.id_trans_adj = id_report
            FormAccountingJournalAdjDet.ShowDialog()
        ElseIf report_mark_type = "41" Then
            'FG IN
            FormViewFGAdjIn.id_adj_in_fg = id_report
            FormViewFGAdjIn.ShowDialog()
        ElseIf report_mark_type = "42" Then
            'FG OUT
            FormViewFGAdjOut.id_adj_out_fg = id_report
            FormViewFGAdjOut.ShowDialog()
        ElseIf report_mark_type = "43" Then
            'SALES ORDER DEL
            FormViewSalesDelOrder.id_pl_sales_order_del = id_report
            FormViewSalesDelOrder.ShowDialog()
        ElseIf report_mark_type = "44" Then
            'Entry Journal
            FormViewMatMRS.id_mrs = id_report
            FormViewMatMRS.ShowDialog()
        ElseIf report_mark_type = "45" Then
            'SALES RETURN ORDER
            FormViewSalesReturnOrder.id_sales_return_order = id_report
            FormViewSalesReturnOrder.ShowDialog()
        ElseIf report_mark_type = "46" Then
            'SALES RETURN
            FormViewSalesReturn.id_sales_return = id_report
            FormViewSalesReturn.ShowDialog()
        ElseIf report_mark_type = "47" Then
            'Entry Journal
            FormViewMatRetInProd.id_mat_prod_ret_in = id_report
            FormViewMatRetInProd.ShowDialog()
        ElseIf report_mark_type = "48" Then
            'SALES POS
            FormViewSalesPOS.id_sales_pos = id_report
            FormViewSalesPOS.ShowDialog()
        ElseIf report_mark_type = "49" Or report_mark_type = "106" Then
            'SALES RETURN QC
            FormViewSalesReturnQC.id_sales_return_qc = id_report
            FormViewSalesReturnQC.ShowDialog()
        ElseIf report_mark_type = "50" Then
            'PR Prod Order
            FormViewPRProdWO.id_pr = id_report
            FormViewPRProdWO.ShowDialog()
        ElseIf report_mark_type = "51" Then
            'SALES INVOICE
            FormViewSalesInvoice.id_sales_invoice = id_report
            FormViewSalesInvoice.ShowDialog()
        ElseIf report_mark_type = "53" Then
            'FG SO STORE
            FormViewFGStockOpname.id_fg_so_store = id_report
            FormViewFGStockOpname.ShowDialog()
        ElseIf report_mark_type = "54" Then
            'FG MISSING
            FormViewSalesPOS.id_sales_pos = id_report
            FormViewSalesPOS.ShowDialog()
        ElseIf report_mark_type = "55" Then
            'FG MISSING INVOICE
            FormViewFGMissingInvoice.id_fg_missing_invoice = id_report
            FormViewFGMissingInvoice.ShowDialog()
        ElseIf report_mark_type = "56" Then
            'FG SO WH
            FormViewFGStockOpnameWH.id_fg_so_wh = id_report
            FormViewFGStockOpnameWH.ShowDialog()
        ElseIf report_mark_type = "57" Then
            'TRANSFER
            FormViewFGTrf.id_fg_trf = id_report
            FormViewFGTrf.ShowDialog()
        ElseIf report_mark_type = "58" Then
            'FG TRF REC
            FormViewFGTrf.id_type = "1"
            FormViewFGTrf.id_fg_trf = id_report
            FormViewFGTrf.ShowDialog()
        ElseIf report_mark_type = "60" Then
            'PL SAMPLE DEL TI WH
            FormViewSampleDel.id_sample_del = id_report
            FormViewSampleDel.ShowDialog()
        ElseIf report_mark_type = "61" Then
            'REC PL SAMPLE DEL TI WH
            FormViewSampleDelRec.id_sample_del_rec = id_report
            FormViewSampleDelRec.ShowDialog()
        ElseIf report_mark_type = "62" Then
            'SALES ORDER SAMPLE
            FormViewSampleOrder.id_sample_order = id_report
            FormViewSampleOrder.ShowDialog()
        ElseIf report_mark_type = "63" Then
            'DELIVERY ORDER SAMPLE
            FormViewSampleDelOrder.id_pl_sample_order_del = id_report
            FormViewSampleDelOrder.ShowDialog()
        ElseIf report_mark_type = "64" Then
            'Sample Stock Opname
            FormViewSampleStockOpname.id_sample_so = id_report
            FormViewSampleStockOpname.ShowDialog()
        ElseIf report_mark_type = "65" Then
            'CODE REPLACEMENT
            FormViewFGCodeReplaceStore.id_fg_code_replace_store = id_report
            FormViewFGCodeReplaceStore.ShowDialog()
        ElseIf report_mark_type = "66" Then
            'CREDIT NOTE
            FormViewSalesPOS.id_menu = "2"
            FormViewSalesPOS.id_sales_pos = id_report
            FormViewSalesPOS.ShowDialog()
        ElseIf report_mark_type = "67" Then
            'MISSING CREDIT NOTE
            FormViewSalesPOS.id_menu = "2"
            FormViewSalesPOS.id_sales_pos = id_report
            FormViewSalesPOS.ShowDialog()
        ElseIf report_mark_type = "68" Then
            'CODE REPLACEMENT WH
            FormViewFGCodeReplaceWH.id_fg_code_replace_wh = id_report
            FormViewFGCodeReplaceWH.ShowDialog()
        ElseIf report_mark_type = "69" Then
            'WRITE OFF
            FormViewFGWoff.id_fg_woff = id_report
            FormViewFGWoff.ShowDialog()
        ElseIf report_mark_type = "70" Then
            'PROPOSE PRICE
            FormFGProposePriceDetail.id = id_report
            FormFGProposePriceDetail.is_view = "1"
            FormFGProposePriceDetail.ShowDialog()
        ElseIf report_mark_type = "72" Then
            'QC Adj In
            FormViewProdQCAdjIn.id_adj_in = id_report
            FormViewProdQCAdjIn.ShowDialog()
        ElseIf report_mark_type = "73" Then
            'QC Adj Out
            FormViewProdQcAdjOut.id_adj_out = id_report
            FormViewProdQcAdjOut.ShowDialog()
        ElseIf report_mark_type = "75" Then
            'ANALAISIS SO
            FormViewFGSalesOrderReff.id_fg_so_reff = id_report
            FormViewFGSalesOrderReff.ShowDialog()
        ElseIf report_mark_type = "76" Then
            'Sales Promo
            FormViewSalesPromo.id_sales_pos = id_report
            FormViewSalesPromo.ShowDialog()
        ElseIf report_mark_type = "77" Then
            'Invoice FG missing WH
            FormViewFGMissingWH.id_fg_missing = id_report
            FormViewFGMissingWH.ShowDialog()
        ElseIf report_mark_type = "79" Then
            'Invoice FG missing WH
            Dim query As String = "SELECT id_bom FROM tb_bom WHERE id_bom_approve='" + id_report + "' LIMIT 1"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            FormViewBOM.id_bom_approve = id_report
            FormViewBOM.id_bom = data.Rows(0)("id_bom").ToString
            FormViewBOM.ShowDialog()
        ElseIf report_mark_type = "80" Or report_mark_type = "206" Then
            'prod demand mkt
            FormViewProdDemand.id_prod_demand = id_report
            FormViewProdDemand.report_mark_type = report_mark_type
            FormViewProdDemand.ShowDialog()
        ElseIf report_mark_type = "81" Then
            'prod demand hrd
            FormViewProdDemand.id_prod_demand = id_report
            FormViewProdDemand.report_mark_type = report_mark_type
            FormViewProdDemand.ShowDialog()
        ElseIf report_mark_type = "82" Then
            '   master price
            FormViewMasterPrice.id_fg_price = id_report
            FormViewMasterPrice.ShowDialog()
        ElseIf report_mark_type = "85" Then
            '   sample PL
            FormViewSamplePLToWH.id_sample_pl = id_report
            FormViewSamplePLToWH.ShowDialog()
        ElseIf report_mark_type = "86" Then
            '   master price sample
            FormViewMasterPriceSample.id_sample_price = id_report
            FormViewMasterPriceSample.ShowDialog()
        ElseIf report_mark_type = "87" Then
            'inventory allocation
            FormViewFGWHAlloc.id_fg_wh_alloc = id_report
            FormViewFGWHAlloc.ShowDialog()
        ElseIf report_mark_type = "88" Then
            'generate prepare order
            FormViewSalesOrderGen.id_sales_order_gen = id_report
            FormViewSalesOrderGen.ShowDialog()
        ElseIf report_mark_type = "89" Then
            'return Internal Sale
            FormViewSampleReturnPL.id_sample_pl = id_report
            FormViewSampleReturnPL.ShowDialog()
        ElseIf report_mark_type = "91" Or report_mark_type = "140" Then
            'repair FG
            FormViewFGRepair.id_fg_repair = id_report
            FormViewFGRepair.ShowDialog()
        ElseIf report_mark_type = "92" Then
            'repair rec FG
            FormViewFGRepairRec.id_fg_repair_rec = id_report
            FormViewFGRepairRec.ShowDialog()
        ElseIf report_mark_type = "93" Or report_mark_type = "141" Then
            'repair return FG
            FormViewFGRepairReturn.id_fg_repair_return = id_report
            FormViewFGRepairReturn.ShowDialog()
        ElseIf report_mark_type = "94" Then
            'repair return rec FG
            FormViewFGRepairReturnRec.id_fg_repair_return_rec = id_report
            FormViewFGRepairReturnRec.ShowDialog()
        ElseIf report_mark_type = "95" Then
            'propose leave
            FormEmpLeaveDet.id_emp_leave = id_report
            FormEmpLeaveDet.report_mark_type = "95"
            FormEmpLeaveDet.is_view = "1"
            FormEmpLeaveDet.ShowDialog()
        ElseIf report_mark_type = "96" Then
            'propose leave need management approval
            FormEmpLeaveDet.id_emp_leave = id_report
            FormEmpLeaveDet.report_mark_type = "96"
            FormEmpLeaveDet.is_view = "1"
            FormEmpLeaveDet.ShowDialog()
        ElseIf report_mark_type = "97" Then
            'DP propose
            FormEmpDPDet.id_emp_dp = id_report
            FormEmpDPDet.is_view = "1"
            FormEmpDPDet.ShowDialog()
        ElseIf report_mark_type = "98" Then
            'Employee change schedule
            FormEmpChScheduleDet.id_ch_sch = id_report
            FormEmpChScheduleDet.is_view = "1"
            FormEmpChScheduleDet.ShowDialog()
        ElseIf report_mark_type = "99" Then
            'propose leave
            FormEmpLeaveDet.id_emp_leave = id_report
            FormEmpLeaveDet.report_mark_type = "99"
            FormEmpLeaveDet.is_view = "1"
            FormEmpLeaveDet.ShowDialog()
        ElseIf report_mark_type = "100" Then
            'propose schedule with approval
            FormEmpAttnAssignDet.id_emp_assign_sch = id_report
            FormEmpAttnAssignDet.is_view = "1"
            FormEmpAttnAssignDet.ShowDialog()
        ElseIf report_mark_type = "101" Then
            'air ways bill
            FormWHAWBillDet.id_awb = id_report
            FormWHAWBillDet.is_view = "1"
            FormWHAWBillDet.ShowDialog()
        ElseIf report_mark_type = "102" Then
            'propose leave HRD
            FormEmpLeaveDet.id_emp_leave = id_report
            FormEmpLeaveDet.report_mark_type = "102"
            FormEmpLeaveDet.is_view = "1"
            FormEmpLeaveDet.ShowDialog()
        ElseIf report_mark_type = "103" Then
            'delivery combine
            FormSalesDelOrderSlip.action = "upd"
            FormSalesDelOrderSlip.id_pl_sales_order_del_slip = id_report
            FormSalesDelOrderSlip.is_view = "1"
            FormSalesDelOrderSlip.ShowDialog()
        ElseIf report_mark_type = "104" Then
            'propose leave HRD
            FormEmpLeaveDet.id_emp_leave = id_report
            FormEmpLeaveDet.report_mark_type = "104"
            FormEmpLeaveDet.is_view = "1"
            FormEmpLeaveDet.ShowDialog()
        ElseIf report_mark_type = "105" Or report_mark_type = "224" Then
            'final clear
            FormProductionFinalClearDet.id_prod_fc = id_report
            FormProductionFinalClearDet.action = "upd"
            FormProductionFinalClearDet.is_view = "1"
            FormProductionFinalClearDet.ShowDialog()
        ElseIf report_mark_type = "107" Then
            'assembly
            FormProductionAssemblySingle.id_prod_ass = id_report
            FormProductionAssemblySingle.action = "upd"
            FormProductionAssemblySingle.is_view = "1"
            FormProductionAssemblySingle.ShowDialog()
        ElseIf report_mark_type = "108" Then
            'Propose Leave (Staff-Supervisor KK Unit)
            FormEmpLeaveDet.id_emp_leave = id_report
            FormEmpLeaveDet.report_mark_type = "108"
            FormEmpLeaveDet.is_view = "1"
            FormEmpLeaveDet.ShowDialog()
        ElseIf report_mark_type = "109" Then
            'Propose Leave (Coord-Asst Mgr KK Unit)
            FormEmpLeaveDet.id_emp_leave = id_report
            FormEmpLeaveDet.report_mark_type = "109"
            FormEmpLeaveDet.is_view = "1"
            FormEmpLeaveDet.ShowDialog()
        ElseIf report_mark_type = "110" Then
            'Propose Leave (Manager KK Unit)
            FormEmpLeaveDet.id_emp_leave = id_report
            FormEmpLeaveDet.report_mark_type = "110"
            FormEmpLeaveDet.is_view = "1"
            FormEmpLeaveDet.ShowDialog()
        ElseIf report_mark_type = "111" Then
            'non stock out
            FormSalesReturnDet.id_sales_return = id_report
            FormSalesReturnDet.action = "upd"
            FormSalesReturnDet.is_view = "1"
            FormSalesReturnDet.ShowDialog()
        ElseIf report_mark_type = "113" Then
            'return khusus
            FormSalesReturnDet.id_sales_return = id_report
            FormSalesReturnDet.action = "upd"
            FormSalesReturnDet.is_view = "1"
            FormSalesReturnDet.ShowDialog()
        ElseIf report_mark_type = "116" Then
            'INVOICE MISSING PROMO
            FormViewSalesPOS.id_menu = "3"
            FormViewSalesPOS.id_sales_pos = id_report
            FormViewSalesPOS.ShowDialog()
        ElseIf report_mark_type = "117" Then
            'INVOICE MISSING staaff
            FormViewSalesPOS.id_menu = "4"
            FormViewSalesPOS.id_sales_pos = id_report
            FormViewSalesPOS.ShowDialog()
        ElseIf report_mark_type = "118" Then
            'CREDIT NOTE OL STORE
            FormViewSalesPOS.id_menu = "5"
            FormViewSalesPOS.id_sales_pos = id_report
            FormViewSalesPOS.ShowDialog()
        ElseIf report_mark_type = "119" Then
            'return order onlince
            FormSalesReturnOrderOLDet.is_view = "1"
            FormSalesReturnOrderOLDet.action = "upd"
            FormSalesReturnOrderOLDet.id_sales_return_order = id_report
            FormSalesReturnOrderOLDet.ShowDialog()
        ElseIf report_mark_type = "120" Then
            'return online
            FormSalesReturnDet.id_sales_return = id_report
            FormSalesReturnDet.action = "upd"
            FormSalesReturnDet.is_view = "1"
            FormSalesReturnDet.ShowDialog()
        ElseIf report_mark_type = "123" Then
            'uniform List
            FormEmpUniListDet.is_view = "1"
            FormEmpUniListDet.id_emp_uni_design = id_report
            FormEmpUniListDet.ShowDialog()
        ElseIf report_mark_type = "124" Then
            'Propose Leave (Manager KK Unit)
            FormEmpLeaveDet.id_emp_leave = id_report
            FormEmpLeaveDet.report_mark_type = "124"
            FormEmpLeaveDet.is_view = "1"
            FormEmpLeaveDet.ShowDialog()
        ElseIf report_mark_type = "126" Then
            'memo over prod
            FormProdOverMemoDet.id_prod_over_memo = id_report
            FormProdOverMemoDet.action = "upd"
            FormProdOverMemoDet.is_view = "1"
            FormProdOverMemoDet.ShowDialog()
        ElseIf report_mark_type = "128" Then
            'Asset PO
            FormAssetPODet.id_po = id_report
            FormAssetPODet.is_view = "1"
            FormAssetPODet.ShowDialog()
        ElseIf report_mark_type = "129" Then
            'Asset Rec
            FormAssetRecDet.id_rec = id_report
            FormAssetRecDet.is_view = "1"
            FormAssetRecDet.ShowDialog()
        ElseIf report_mark_type = "130" Then
            'uniform
            FormEmpUniOrderDet.id_sales_order = id_report
            FormEmpUniOrderDet.is_view = "1"
            FormEmpUniOrderDet.ShowDialog()
        ElseIf report_mark_type = "132" Then
            'UNIFORM EXPENSE
            FormEmpUniExpenseDet.id_emp_uni_ex = id_report
            FormEmpUniExpenseDet.action = "upd"
            FormEmpUniExpenseDet.is_view = "1"
            FormEmpUniExpenseDet.ShowDialog()
        ElseIf report_mark_type = "133" Then
            'BUDGET REV
            FormBudgetRevProposeDet.id = id_report
            FormBudgetRevProposeDet.is_view = "1"
            FormBudgetRevProposeDet.ShowDialog()
        ElseIf report_mark_type = "134" Then
            'propose new item cat
            FormItemCatProposeDet.id = id_report
            FormItemCatProposeDet.is_view = "1"
            FormItemCatProposeDet.ShowDialog()
        ElseIf report_mark_type = "135" Then
            'propose new item coa
            FormItemCatMappingDet.id = id_report
            FormItemCatMappingDet.is_view = "1"
            FormItemCatMappingDet.ShowDialog()
        ElseIf report_mark_type = "136" Then
            'PROPOSE BUDGET EXPENSE
            FormBudgetExpenseProposeDet.action = "upd"
            FormBudgetExpenseProposeDet.id = id_report
            FormBudgetExpenseProposeDet.is_view = "1"
            FormBudgetExpenseProposeDet.ShowDialog()
        ElseIf report_mark_type = "137" Or report_mark_type = "201" Or report_mark_type = "218" Then
            'Purchase Request
            FormPurcReqDet.is_view = "1"
            FormPurcReqDet.id_req = id_report
            FormPurcReqDet.ShowDialog()
        ElseIf report_mark_type = "138" Then
            'PROPOSE REVISION BUDGET EXPENSE
            FormBudgetExpenseRevisionDet.id = id_report
            FormBudgetExpenseRevisionDet.is_view = "1"
            FormBudgetExpenseRevisionDet.ShowDialog()
        ElseIf report_mark_type = "139" Or report_mark_type = "202" Then
            'Purchase Order
            FormPurcOrderDet.id_po = id_report
            FormPurcOrderDet.is_view = "1"
            FormPurcOrderDet.ShowDialog()
        ElseIf report_mark_type = "143" Or report_mark_type = "144" Or report_mark_type = "145" Or report_mark_type = "210" Then
            'PD REVISION
            FormProdDemandRevDet.id = id_report
            FormProdDemandRevDet.is_view = "1"
            FormProdDemandRevDet.ShowDialog()
        ElseIf report_mark_type = "142" Then
            'cancel Form
            FormReportMarkCancel.id_report_mark_cancel = id_report
            FormReportMarkCancel.is_view = "1"
            FormReportMarkCancel.ShowDialog()
        ElseIf report_mark_type = "147" Then
            'REVENUE BUDGET REVISION
            FormBudgetRevenueRevisionDet.id = id_report
            FormBudgetRevenueRevisionDet.is_view = "1"
            FormBudgetRevenueRevisionDet.ShowDialog()
        ElseIf report_mark_type = "148" Then
            'PURCHASE RECEIVE NON ASSET
            FormPurcReceiveDet.action = "upd"
            FormPurcReceiveDet.id = id_report
            FormPurcReceiveDet.is_view = "1"
            FormPurcReceiveDet.ShowDialog()
        ElseIf report_mark_type = "150" Or report_mark_type = "155" Or report_mark_type = "172" Or report_mark_type = "173" Then
            'COP Propose
            FormMasterDesignCOPPropose.id_propose = id_report
            FormMasterDesignCOPPropose.is_view = "1"
            FormMasterDesignCOPPropose.ShowDialog()
        ElseIf report_mark_type = "151" Then
            'claim return
            FormProductionClaimReturnDet.action = "upd"
            FormProductionClaimReturnDet.id = id_report
            FormProductionClaimReturnDet.is_view = "1"
            FormProductionClaimReturnDet.ShowDialog()
        ElseIf report_mark_type = "152" Then
            'purchaser return
            FormPurchaseReturnDet.action = "upd"
            FormPurchaseReturnDet.id = id_report
            FormPurchaseReturnDet.is_view = "1"
            FormPurchaseReturnDet.ShowDialog()
        ElseIf report_mark_type = "153" Then
            'propose company
            FormMasterCompanySingle.id_company = id_report
            FormMasterCompanySingle.is_view = "1"
            FormMasterCompanySingle.ShowDialog()
        ElseIf report_mark_type = "154" Or report_mark_type = "163" Then
            'item req
            FormItemReqDet.action = "upd"
            FormItemReqDet.id = id_report
            FormItemReqDet.is_view = "1"
            FormItemReqDet.ShowDialog()
        ElseIf report_mark_type = "156" Or report_mark_type = "166" Then
            'item del
            FormItemDelDetail.action = "upd"
            FormItemDelDetail.id = id_report
            FormItemDelDetail.is_view = "1"
            FormItemDelDetail.ShowDialog()
        ElseIf report_mark_type = "157" Then
            'expense
            FormItemExpenseDet.action = "upd"
            FormItemExpenseDet.id = id_report
            FormItemExpenseDet.is_view = "1"
            FormItemExpenseDet.ShowDialog()
        ElseIf report_mark_type = "159" Then
            'payment
            FormBankWithdrawalDet.id_payment = id_report
            FormBankWithdrawalDet.is_view = "1"
            FormBankWithdrawalDet.ShowDialog()
        ElseIf report_mark_type = "160" Then
            'asset
            FormPurcAssetDet.action = "upd"
            FormPurcAssetDet.id = id_report
            FormPurcAssetDet.is_view = "1"
            FormPurcAssetDet.ShowDialog()
        ElseIf report_mark_type = "162" Then
            'payment
            FormBankDepositDet.id_deposit = id_report
            FormBankDepositDet.is_view = "1"
            FormBankDepositDet.ShowDialog()
        ElseIf report_mark_type = "237" Then
            'Tabungan Missing
            FormPaymentMissingDet.id_missing_payment = id_report
            FormPaymentMissingDet.is_view = "1"
            FormPaymentMissingDet.ShowDialog()
        ElseIf report_mark_type = "164" Then
            'propose leave
            FormEmpLeaveDet.id_emp_leave = id_report
            FormEmpLeaveDet.report_mark_type = "164"
            FormEmpLeaveDet.is_view = "1"
            FormEmpLeaveDet.ShowDialog()
        ElseIf report_mark_type = "165" Then
            'propose leave
            FormEmpLeaveDet.id_emp_leave = id_report
            FormEmpLeaveDet.report_mark_type = "165"
            FormEmpLeaveDet.is_view = "1"
            FormEmpLeaveDet.ShowDialog()
        ElseIf report_mark_type = "167" Then
            'Cash Advance
            FormCashAdvanceDet.id_ca = id_report
            FormCashAdvanceDet.is_view = "1"
            FormCashAdvanceDet.ShowDialog()
        ElseIf report_mark_type = "168" Then
            'receive return
            FormSalesReturnRecDet.id = id_report
            FormSalesReturnRecDet.ShowDialog()
        ElseIf report_mark_type = "169" Then
            'value-added asset
            FormPurcAssetValueAdded.action = "upd"
            FormPurcAssetValueAdded.id = id_report
            FormPurcAssetValueAdded.is_view = "1"
            FormPurcAssetValueAdded.ShowDialog()
        ElseIf report_mark_type = "174" Then
            'Cash Advance Reconcile
            FormCashAdvanceReconcile.id_ca = id_report
            FormCashAdvanceReconcile.is_view = "1"
            FormCashAdvanceReconcile.ShowDialog()
        ElseIf report_mark_type = "175" Then
            'Sample budget propose
            FormSampleBudgetDet.id_pps = id_report
            FormSampleBudgetDet.is_view = "1"
            FormSampleBudgetDet.ShowDialog()
        ElseIf report_mark_type = "176" Or report_mark_type = "177" Or report_mark_type = "178" Then
            'Propose Changes
            Dim id_pop_up As String = ""
            Dim form_name As String = ""

            If report_mark_type = "177" Then
                id_pop_up = "-1"
                form_name = "FormFGLineList"
            ElseIf report_mark_type = "178" Then
                id_pop_up = "3"
                form_name = "FormFGLineList"
            ElseIf report_mark_type = "176" Then
                id_pop_up = "5"
                form_name = "FormFGDesignList"
            End If

            Dim id_dsg As String = execute_query("SELECT id_design FROM tb_m_design_rev WHERE id_design_rev = '" + id_report + "'", 0, True, "", "", "", "")

            FormMasterDesignSingle.id_pop_up = id_pop_up
            FormMasterDesignSingle.form_name = form_name
            FormMasterDesignSingle.id_design = id_dsg
            FormMasterDesignSingle.WindowState = FormWindowState.Maximized
            FormMasterDesignSingle.is_propose_changes = True
            FormMasterDesignSingle.id_propose_changes = id_report

            FormMasterDesignSingle.ShowDialog()
        ElseIf report_mark_type = "180" Then
            Dim data_pps As DataTable = execute_query("SELECT id_type, id_employee FROM tb_employee_pps WHERE id_employee_pps = '" + id_report + "'", -1, True, "", "", "", "")

            FormEmployeePpsDet.id_pps = id_report
            FormEmployeePpsDet.is_new = If(data_pps.Rows(0)("id_type").ToString = "1", "-1", "1")
            FormEmployeePpsDet.id_employee = If(data_pps.Rows(0)("id_employee").ToString = "", "-1", data_pps.Rows(0)("id_employee").ToString)
            FormEmployeePpsDet.show_payroll = True

            FormEmployeePpsDet.ShowDialog()
        ElseIf report_mark_type = "184" Or report_mark_type = "213" Or report_mark_type = "214" Or report_mark_type = "219" Or report_mark_type = "220" Then
            FormEmpOvertimeDet.id = id_report
            FormEmpOvertimeDet.is_hrd = "1"
            FormEmpOvertimeDet.is_view = "1"

            FormEmpOvertimeDet.ShowDialog()
        ElseIf report_mark_type = "185" Then
            'Sample Purchase Closing
            FormSamplePurcCloseDet.id_close = id_report
            FormSamplePurcCloseDet.is_view = "1"

            FormSamplePurcCloseDet.ShowDialog()
        ElseIf report_mark_type = "187" Or report_mark_type = "215" Or report_mark_type = "216" Then
            Dim data_ver As DataTable = execute_query("SELECT id_ot, ot_date FROM tb_ot_verification WHERE id_ot_verification = '" + id_report + "'", -1, True, "", "", "", "")

            FormEmpOvertimeVerification.is_hrd = "1"
            FormEmpOvertimeVerification.id = id_report
            FormEmpOvertimeVerification.id_ot = data_ver.Rows(0)("id_ot").ToString
            FormEmpOvertimeVerification.is_view = "1"
            FormEmpOvertimeVerification.ot_date = data_ver.Rows(0)("ot_date")

            FormEmpOvertimeVerification.ShowDialog()
        ElseIf report_mark_type = "183" Then
            'sales invuuce diff margin
            FormViewSalesPOS.id_menu = "4"
            FormViewSalesPOS.id_sales_pos = id_report
            FormViewSalesPOS.ShowDialog()
        ElseIf report_mark_type = "188" Then
            'propose price new product-revision
            FormFGProposePriceRev.is_view = "1"
            FormFGProposePriceRev.id = id_report
            FormFGProposePriceRev.ShowDialog()
        ElseIf report_mark_type = "189" Then
            'Bukti Pembelian
            FormInvoiceFGPODP.id_invoice = id_report
            FormInvoiceFGPODP.is_view = "1"

            FormInvoiceFGPODP.ShowDialog()
        ElseIf report_mark_type = "190" Or report_mark_type = "193" Then
            'work order MTC/IT
            FormWorkOrderDet.is_view = "1"
            FormWorkOrderDet.id_wo = id_report
            FormWorkOrderDet.ShowDialog()
        ElseIf report_mark_type = "192" Then
            FormEmpPayroll.is_view = "1"
            FormEmpPayroll.MdiParent = FormMain
            FormEmpPayroll.Show()
            FormEmpPayroll.WindowState = FormWindowState.Maximized
            FormEmpPayroll.Focus()

            FormEmpPayroll.GVPayrollPeriode.FocusedRowHandle = find_row(FormEmpPayroll.GVPayrollPeriode, "id_payroll", id_report)
            FormEmpPayroll.XTCPayroll.SelectedTabPageIndex = 1
        ElseIf report_mark_type = "179" Then
            'sample material purchase
            FormSampleExpenseDet.id_purc = id_report
            FormSampleExpenseDet.ShowDialog()
        ElseIf report_mark_type = "197" Or report_mark_type = "229" Then
            'propose employee salary
            FormProposeEmpSalaryDet.id_employee_sal_pps = id_report
            FormProposeEmpSalaryDet.is_duplicate = "-1"
            FormProposeEmpSalaryDet.ShowDialog()
        ElseIf report_mark_type = "200" Then
            'propose design changes
            FormFGDesignListChanges.id = id_report
            FormFGDesignListChanges.is_view = "1"
            FormFGDesignListChanges.ShowDialog()
        ElseIf report_mark_type = "203" Or report_mark_type = "204" Then
            'propose budget OPEX
            FormSetupBudgetOPEXDet.id_pps = id_report
            FormSetupBudgetOPEXDet.is_view = "1"
            FormSetupBudgetOPEXDet.ShowDialog()
        ElseIf report_mark_type = "207" Then
            'Item Cat Main
            FormItemCatMainDet.id_propose = id_report
            FormItemCatMainDet.is_view = "1"
            FormItemCatMainDet.ShowDialog()
        ElseIf report_mark_type = "208" Or report_mark_type = "209" Then
            'propose budget CAPEX
            FormSetupBudgetCAPEXDet.id_pps = id_report
            FormSetupBudgetCAPEXDet.is_view = "1"
            FormSetupBudgetCAPEXDet.ShowDialog()
        ElseIf report_mark_type = "211" Then
            FormEmpInputAttendanceDet.id = id_report
            FormEmpInputAttendanceDet.ShowDialog()
        ElseIf report_mark_type = "212" Then
            'prod order closing
            FormProdClosingPps.id_pps = id_report
            FormProdClosingPps.ShowDialog()
        ElseIf report_mark_type = "217" Then
            'bukti pickup
            FormBuktiPickupDet.id_pickup = id_report
            FormBuktiPickupDet.ShowDialog()
        ElseIf report_mark_type = "221" Then
            'debit note
            FormDebitNoteDet.id_dn = id_report
            FormDebitNoteDet.is_view = "1"
            FormDebitNoteDet.ShowDialog()
        ElseIf report_mark_type = "223" Then
            'bpjs kesehatan
            FormEmpBPJSKesehatanDet.id = id_report
            FormEmpBPJSKesehatanDet.is_approve = "1"
            FormEmpBPJSKesehatanDet.ShowDialog()
        ElseIf report_mark_type = "222" Then
            'summary qc report
            FormProductionFinalClearSummary.id_prod_fc_sum = id_report
            FormProductionFinalClearSummary.is_vew = "1"
            FormProductionFinalClearSummary.ShowDialog()
        ElseIf report_mark_type = "231" Then
            'invoice
            FormInvMatDet.id_inv = id_report
            FormInvMatDet.is_view = "1"
            FormInvMatDet.ShowDialog()
        ElseIf report_mark_type = "233" Then
            'delay payment
            FormDelayPaymentDet.id = id_report
            FormDelayPaymentDet.is_view = "1"
            FormDelayPaymentDet.ShowDialog()
        ElseIf report_mark_type = "234" Then
            'follow up ar
            FormFollowUpARHistory.id_follow_up_recap = id_report
            FormFollowUpARHistory.is_view = "1"
            FormFollowUpARHistory.ShowDialog()
        ElseIf report_mark_type = "236" Then
            'UNIFORM CREDIT NOTE
            FormEmpUniCreditNoteDet.id_emp_uni_ex = id_report
            FormEmpUniCreditNoteDet.is_view = "1"
            FormEmpUniCreditNoteDet.ShowDialog()
        Else
            'MsgBox(id_report)
            stopCustom("Document Not Found")
        End If
    End Sub

    Sub load_detail()
        Dim query As String = ""
        Dim data As DataTable = Nothing
        Dim field_number, field_date, field_id, table_name As String
        '
        Dim colum_caption() As String = {}
        Dim colum_field() As String = {}
        '
        field_date = "" : field_number = "" : table_name = "" : field_id = ""

        If report_mark_type = "1" Then
            'sample purchase
            table_name = "tb_sample_purc"
            field_id = "id_sample_purc"
            field_number = "sample_purc_number"
            field_date = "sample_purc_date"
        ElseIf report_mark_type = "2" Then
            'sample receive
            table_name = "tb_sample_purc_rec"
            field_id = "id_sample_purc"
            field_number = "sample_purc_rec_number"
            field_date = "sample_purc_rec_date"
        ElseIf report_mark_type = "3" Then
            'sample PL
            table_name = "tb_pl_sample_purc"
            field_id = "id_pl_sample_purc"
            field_number = "pl_sample_purc_number"
            field_date = "pl_sample_purc_date"
        ElseIf report_mark_type = "4" Then
            'sample PR
            table_name = "tb_pr_sample_purc"
            field_id = "id_pr_sample_purc"
            field_number = "pr_sample_purc_number"
            field_date = "pr_sample_purc_date"
        ElseIf report_mark_type = "5" Then
            'sample ret out
            table_name = "tb_sample_purc_ret_out"
            field_id = "id_sample_purc_ret_out"
            field_number = "sample_purc_ret_out_number"
            field_date = "sample_purc_ret_out_date"
        ElseIf report_mark_type = "6" Then
            'sample ret in
            table_name = "tb_sample_purc_ret_in"
            field_id = "id_sample_purc_ret_in"
            field_number = "sample_purc_ret_in_number"
            field_date = "sample_purc_ret_in_date"
        ElseIf report_mark_type = "7" Then
            'sample receipt
            table_name = "tb_pl_sample_purc"
            field_id = "id_pl_sample_purc"
            field_number = "receipt_sample_number"
            field_date = "receipt_sample_date"
        ElseIf report_mark_type = "8" Then
            'bom
            table_name = "tb_bom a INNER JOIN tb_m_product b On a.id_product = b.id_product"
            field_id = "a.id_bom"
            field_number = "CONCAT_WS('/',b.product_full_code,a.bom_name)"
            field_date = "bom_date_created"
        ElseIf report_mark_type = "9" Then
            'prod demand
            table_name = "tb_prod_demand"
            field_id = "id_prod_demand"
            field_number = "prod_demand_number"
            field_date = "prod_demand_date"
        ElseIf report_mark_type = "10" Then
            'PL DEL
            table_name = "tb_pl_sample_del"
            field_id = "id_pl_sample_del"
            field_number = "pl_sample_del_number"
            field_date = "pl_sample_del_date"
        ElseIf report_mark_type = "11" Then
            'sample REQ
            table_name = "tb_sample_requisition"
            field_id = "id_sample_requisition"
            field_number = "sample_requisition_number"
            field_date = "sample_requisition_date"
        ElseIf report_mark_type = "12" Then
            'sample plan
            table_name = "tb_sample_plan"
            field_id = "id_sample_plan"
            field_number = "sample_plan_number"
            field_date = "sample_plan_date"
        ElseIf report_mark_type = "13" Then
            'material purchase
            table_name = "tb_mat_purc"
            field_id = "id_mat_purc"
            field_number = "mat_purc_number"
            field_date = "mat_purc_date"
        ElseIf report_mark_type = "14" Then
            'sample return
            table_name = "tb_sample_return"
            field_id = "id_sample_return"
            field_number = "sample_return_number"
            field_date = "sample_return_date"
        ElseIf report_mark_type = "15" Then
            'material wo
            table_name = "tb_mat_wo"
            field_id = "id_mat_wo"
            field_number = "mat_wo_number"
            field_date = "mat_wo_date"
        ElseIf report_mark_type = "16" Then
            'receive material purchase
            table_name = "tb_mat_purc_rec"
            field_id = "id_mat_purc_rec"
            field_number = "mat_purc_rec_number"
            field_date = "mat_purc_rec_date"
        ElseIf report_mark_type = "17" Then
            'receive material wo
            table_name = "tb_mat_wo_rec"
            field_id = "id_mat_wo_rec"
            field_number = "mat_wo_rec_number"
            field_date = "mat_wo_rec_date"
        ElseIf report_mark_type = "18" Then
            'return out material
            table_name = "tb_mat_purc_ret_out"
            field_id = "id_mat_purc_ret_out"
            field_number = "mat_purc_ret_out_number"
            field_date = "mat_purc_ret_out_date"
        ElseIf report_mark_type = "19" Then
            'return in material
            table_name = "tb_mat_purc_ret_in"
            field_id = "id_mat_purc_ret_in"
            field_number = "mat_purc_ret_in_number"
            field_date = "mat_purc_ret_in_date"
        ElseIf report_mark_type = "20" Then
            'Adj In Sample
            table_name = "tb_adj_in_sample"
            field_id = "id_adj_in_sample"
            field_number = "adj_in_sample_number"
            field_date = "adj_in_sample_date"
        ElseIf report_mark_type = "21" Then
            'Adj Out Sample
            table_name = "tb_adj_out_sample"
            field_id = "id_adj_out_sample"
            field_number = "adj_out_sample_number"
            field_date = "adj_out_sample_date"
        ElseIf report_mark_type = "22" Then
            'Production Order
            table_name = "tb_prod_order"
            field_id = "id_prod_order"
            field_number = "prod_order_number"
            field_date = "prod_order_date"
        ElseIf report_mark_type = "23" Then
            'Production Order Work order
            table_name = "tb_prod_order_wo"
            field_id = "id_prod_order_wo"
            field_number = "prod_order_wo_number"
            field_date = "prod_order_wo_date"
        ElseIf report_mark_type = "24" Then
            'Material PR PO
            table_name = "tb_pr_mat_purc"
            field_id = "id_pr_mat_purc"
            field_number = "pr_mat_purc_number"
            field_date = "pr_mat_purc_date"
        ElseIf report_mark_type = "25" Then
            'Material PR WO
            table_name = "tb_pr_mat_wo"
            field_id = "id_pr_mat_wo"
            field_number = "pr_mat_wo_number"
            field_date = "pr_mat_wo_date"
        ElseIf report_mark_type = "26" Then
            'Adj In Material
            table_name = "tb_adj_in_mat"
            field_id = "id_adj_in_mat"
            field_number = "adj_in_mat_number"
            field_date = "adj_in_mat_date"
        ElseIf report_mark_type = "27" Then
            'Adj Out Material
            table_name = "tb_adj_out_mat"
            field_id = "id_adj_out_mat"
            field_number = "adj_out_mat_number"
            field_date = "adj_out_mat_date"
        ElseIf report_mark_type = "28" Or report_mark_type = "127" Then
            'receive QC FG
            table_name = "tb_prod_order_rec"
            field_id = "id_prod_order_rec"
            field_number = "prod_order_rec_number"
            field_date = "prod_order_rec_date"
        ElseIf report_mark_type = "29" Then
            'MRS Material
            table_name = "tb_prod_order_mrs"
            field_id = "id_prod_order_mrs"
            field_number = "prod_order_mrs_number"
            field_date = "prod_order_mrs_date"
        ElseIf report_mark_type = "30" Then
            'PL MRS Production
            table_name = "tb_pl_mrs"
            field_id = "id_pl_mrs"
            field_number = "pl_mrs_number"
            field_date = "pl_mrs_date"
        ElseIf report_mark_type = "31" Then
            'return out FG
            table_name = "tb_prod_order_ret_out"
            field_id = "id_prod_order_ret_out"
            field_number = "prod_order_ret_out_number"
            field_date = "prod_order_ret_out_date"
        ElseIf report_mark_type = "32" Then
            'return in FG
            table_name = "tb_prod_order_ret_in"
            field_id = "id_prod_order_ret_in"
            field_number = "prod_order_ret_in_number"
            field_date = "prod_order_ret_in_date"
        ElseIf report_mark_type = "33" Then
            'PL FG TO WH
            table_name = "tb_pl_prod_order"
            field_id = "id_pl_prod_order"
            field_number = "pl_prod_order_number"
            field_date = "pl_prod_order_date"
        ElseIf report_mark_type = "34" Then
            'Invoice Material PL MRS
            table_name = "tb_inv_pl_mrs"
            field_id = "id_inv_pl_mrs"
            field_number = "inv_pl_mrs_number"
            field_date = "inv_pl_mrs_date"
        ElseIf report_mark_type = "35" Then
            'Retur Invoice Material PL MRS
            table_name = "tb_inv_pl_mrs_ret"
            field_id = "id_inv_pl_mrs_ret"
            field_number = "inv_pl_mrs_ret_number"
            field_date = "inv_pl_mrs_ret_date"
        ElseIf report_mark_type = "36" Then
            'Entry Journal
            table_name = "tb_a_acc_trans"
            field_id = "id_acc_trans"
            field_number = "acc_trans_number"
            field_date = "date_created"
        ElseIf report_mark_type = "37" Then
            'REC PL FG TO WH
            table_name = "tb_pl_prod_order_rec"
            field_id = "id_pl_prod_order_rec"
            field_number = "pl_prod_order_rec_number"
            field_date = "pl_prod_order_rec_date"
        ElseIf report_mark_type = "39" Or report_mark_type = "130" Then
            'SALES ORDER
            table_name = "tb_sales_order"
            field_id = "id_sales_order"
            field_number = "sales_order_number"
            field_date = "sales_order_date"
        ElseIf report_mark_type = "40" Then
            'Entry Journal Adj
            table_name = "tb_a_acc_trans_adj"
            field_id = "id_acc_trans_adj"
            field_number = "acc_trans_adj_number"
            field_date = "date_created"
        ElseIf report_mark_type = "41" Then
            'Adj In FG
            table_name = "tb_adj_in_fg"
            field_id = "id_adj_in_fg"
            field_number = "adj_in_fg_number"
            field_date = "adj_in_fg_date"
        ElseIf report_mark_type = "42" Then
            'Adj Out FG
            table_name = "tb_adj_out_fg"
            field_id = "id_adj_out_fg"
            field_number = "adj_out_fg_number"
            field_date = "adj_out_fg_date"
        ElseIf report_mark_type = "43" Then
            'SALES DEL ORDER
            table_name = "tb_pl_sales_order_del"
            field_id = "id_pl_sales_order_del"
            field_number = "pl_sales_order_del_number"
            field_date = "pl_sales_order_del_date"
        ElseIf report_mark_type = "44" Then
            'MRS WO
            table_name = "tb_prod_order_mrs"
            field_id = "id_prod_order_mrs"
            field_number = "prod_order_mrs_number"
            field_date = "prod_order_mrs_date"
        ElseIf report_mark_type = "45" Or report_mark_type = "119" Then
            'SALES RETURN ORDER
            table_name = "tb_sales_return_order"
            field_id = "id_sales_return_order"
            field_number = "sales_return_order_number"
            field_date = "sales_return_order_date"
        ElseIf report_mark_type = "46" Then
            'SALES RETURN
            table_name = "tb_sales_return"
            field_id = "id_sales_return"
            field_number = "sales_return_number"
            field_date = "sales_return_date"
        ElseIf report_mark_type = "47" Then
            'Return In Material
            table_name = "tb_mat_prod_ret_in"
            field_id = "id_mat_prod_ret_in"
            field_number = "mat_prod_ret_in_number"
            field_date = "mat_prod_ret_in_date"
        ElseIf report_mark_type = "48" Then
            'SALES POS
            table_name = "tb_sales_pos"
            field_id = "id_sales_pos"
            field_number = "sales_pos_number"
            field_date = "sales_pos_date"
        ElseIf report_mark_type = "49" Or report_mark_type = "106" Then
            'SALES RETURN QC
            table_name = "tb_sales_return_qc"
            field_id = "id_sales_return_qc"
            field_number = "sales_return_qc_number"
            field_date = "sales_return_qc_date"
        ElseIf report_mark_type = "50" Then
            'PR PRoduction
            table_name = "tb_pr_prod_order"
            field_id = "id_pr_prod_order"
            field_number = "pr_prod_order_number"
            field_date = "pr_prod_order_date"
        ElseIf report_mark_type = "51" Then
            'SALES INVOICE
            table_name = "tb_sales_invoice"
            field_id = "id_sales_invoice"
            field_number = "sales_invoice_number"
            field_date = "sales_invoice_date"
        ElseIf report_mark_type = "52" Then
            'Mat Stock opname
            table_name = "tb_mat_so"
            field_id = "id_mat_so"
            field_number = "mat_so_number"
            field_date = "mat_so_date"
        ElseIf report_mark_type = "53" Then
            'FG SO STORE
            table_name = "tb_fg_so_store"
            field_id = "id_fg_so_store"
            field_number = "fg_so_store_number"
            field_date = "fg_so_store_date"
        ElseIf report_mark_type = "54" Then
            'FG MISSING
            table_name = "tb_sales_pos"
            field_id = "id_sales_pos"
            field_number = "sales_pos_number"
            field_date = "sales_pos_date"
        ElseIf report_mark_type = "55" Then
            'FG MISSING INVOICE
            table_name = "tb_fg_missing_invoice"
            field_id = "id_fg_missing_invoice"
            field_number = "fg_missing_invoice_number"
            field_date = "fg_missing_invoice_date"
        ElseIf report_mark_type = "56" Then
            'FG SO WH
            table_name = "tb_fg_so_wh"
            field_id = "id_fg_so_wh"
            field_number = "fg_so_wh_number"
            field_date = "fg_so_wh_date"
        ElseIf report_mark_type = "57" Then
            'FG TRF
            table_name = "tb_fg_trf"
            field_id = "id_fg_trf"
            field_number = "fg_trf_number"
            field_date = "fg_trf_date"
        ElseIf report_mark_type = "58" Then
            'FG TRF REC
            table_name = "tb_fg_trf"
            field_id = "id_fg_trf"
            field_number = "fg_trf_number"
            field_date = "fg_trf_date"
        ElseIf report_mark_type = "60" Then
            'PL SAMPLE DELIVERY
            table_name = "tb_sample_del"
            field_id = "id_sample_del"
            field_number = "sample_del_number"
            field_date = "sample_del_date"
        ElseIf report_mark_type = "61" Then
            'PL SAMPLE DELIVERY REC
            table_name = "tb_sample_del_rec"
            field_id = "id_sample_del_rec"
            field_number = "sample_del_rec_number"
            field_date = "sample_del_rec_date"
        ElseIf report_mark_type = "62" Then
            'SALES ORDER SAMPLE
            table_name = "tb_sample_order"
            field_id = "id_sample_order"
            field_number = "sample_order_number"
            field_date = "sample_order_date"
        ElseIf report_mark_type = "63" Then
            'DELIVERY ORDER SAMPME
            table_name = "tb_pl_sample_order_del"
            field_id = "id_pl_sample_order_del"
            field_number = "pl_sample_order_del_number"
            field_date = "pl_sample_order_del_date"
        ElseIf report_mark_type = "64" Then
            'Sample Stock Opname
            table_name = "tb_sample_so"
            field_id = "id_sample_so"
            field_number = "sample_so_number"
            field_date = "sample_so_date"
        ElseIf report_mark_type = "65" Then
            'CODE REPLACEMENT
            table_name = "tb_fg_code_replace_store"
            field_id = "id_fg_code_replace_store"
            field_number = "fg_code_replace_store_number"
            field_date = "fg_code_replace_store_date"
        ElseIf report_mark_type = "66" Then
            'SALES CREDIT NOTE
            table_name = "tb_sales_pos"
            field_id = "id_sales_pos"
            field_number = "sales_pos_number"
            field_date = "sales_pos_date"
        ElseIf report_mark_type = "67" Then
            'MISSING CREDIT NOTE
            table_name = "tb_sales_pos"
            field_id = "id_sales_pos"
            field_number = "sales_pos_number"
            field_date = "sales_pos_date"
        ElseIf report_mark_type = "68" Then
            'CODE REPLACEMENT
            table_name = "tb_fg_code_replace_wh"
            field_id = "id_fg_code_replace_wh"
            field_number = "fg_code_replace_wh_number"
            field_date = "fg_code_replace_wh_date"
        ElseIf report_mark_type = "69" Then
            'FG WOFF
            table_name = "tb_fg_woff"
            field_id = "id_fg_woff"
            field_number = "fg_woff_number"
            field_date = "fg_woff_date"
        ElseIf report_mark_type = "70" Then
            'FG PROPSE PRCE
            table_name = "tb_fg_propose_price"
            field_id = "id_fg_propose_price"
            field_number = "fg_propose_price_number"
            field_date = "fg_propose_price_date"
        ElseIf report_mark_type = "72" Then
            'QC adj IN
            table_name = "tb_prod_order_qc_adj_in"
            field_id = "id_prod_order_qc_adj_in"
            field_number = "prod_order_qc_adj_in_number"
            field_date = "prod_order_qc_adj_in_date"
        ElseIf report_mark_type = "73" Then
            'QC adj OUT
            table_name = "tb_prod_order_qc_adj_out"
            field_id = "id_prod_order_qc_adj_out"
            field_number = "prod_order_qc_adj_out_number"
            field_date = "prod_order_qc_adj_out_date"
        ElseIf report_mark_type = "75" Then
            'QANALIIS SO
            table_name = "tb_fg_so_reff"
            field_id = "id_fg_so_reff"
            field_number = "fg_so_reff_number"
            field_date = "fg_so_reff_date"
        ElseIf report_mark_type = "76" Then
            'Sales Promo
            table_name = "tb_sales_pos"
            field_id = "id_sales_pos"
            field_number = "sales_pos_number"
            field_date = "sales_pos_date"
        ElseIf report_mark_type = "77" Then
            'FG Missing WH Invoice
            table_name = "tb_sales_pos"
            field_id = "id_sales_pos"
            field_number = "sales_pos_number"
            field_date = "sales_pos_date"
        ElseIf report_mark_type = "79" Then
            'FG Missing WH Invoice
            table_name = "tb_bom"
            field_id = "id_bom"
            Dim queryx As String = "SELECT bom_date_created FROM tb_bom WHERE id_bom_approve='" + id_report + "' LIMIT 1"
            Dim datax As DataTable = execute_query(queryx, -1, True, "", "", "", "")
            field_number = "'-'"
            field_date = "'" & Date.Parse(datax.Rows(0)("bom_date_created")).ToString("yyyy-MM-dd") & "'"
        ElseIf report_mark_type = "82" Then
            'MASTER PRICE FROM EXCEL
            table_name = "tb_fg_price"
            field_id = "id_fg_price"
            field_number = "fg_price_number"
            field_date = "fg_price_date"
        ElseIf report_mark_type = "86" Then
            'MASTER PRICE SAMPLE FROM EXCEL
            table_name = "tb_sample_price"
            field_id = "id_sample_price"
            field_number = "sample_price_number"
            field_date = "sample_price_date"
        ElseIf report_mark_type = "87" Then
            'INVENTORY ALLOCATION
            table_name = "tb_fg_wh_alloc"
            field_id = "id_fg_wh_alloc"
            field_number = "fg_wh_alloc_number"
            field_date = "fg_wh_alloc_date"
        ElseIf report_mark_type = "88" Then
            'GENERATE PREPARE ORDER
            table_name = "tb_sales_order_gen"
            field_id = "id_sales_order_gen"
            field_number = "sales_order_gen_reff"
            field_date = "sales_order_gen_date"
        ElseIf report_mark_type = "89" Then
            'Return Internal Sale
            table_name = "tb_sample_pl_ret"
            field_id = "id_sample_pl_ret"
            field_number = "sample_pl_ret_number"
            field_date = "sample_pl_ret_date"
        ElseIf report_mark_type = "91" Or report_mark_type = "140" Then
            'Repair fg
            table_name = "tb_fg_repair"
            field_id = "id_fg_repair"
            field_number = "fg_repair_number"
            field_date = "fg_repair_date"
        ElseIf report_mark_type = "92" Then
            'Repair rec fg
            table_name = "tb_fg_repair_rec"
            field_id = "id_fg_repair_rec"
            field_number = "fg_repair_rec_number"
            field_date = "fg_repair_rec_date"
        ElseIf report_mark_type = "93" Or report_mark_type = "141" Then
            'Repair return fg
            table_name = "tb_fg_repair_return"
            field_id = "id_fg_repair_return"
            field_number = "fg_repair_return_number"
            field_date = "fg_repair_return_date"
        ElseIf report_mark_type = "94" Then
            'Repair return rec fg
            table_name = "tb_fg_repair_return_rec"
            field_id = "id_fg_repair_return_rec"
            field_number = "fg_repair_return_rec_number"
            field_date = "fg_repair_return_rec_date"
        ElseIf report_mark_type = "95" Or report_mark_type = "164" Or report_mark_type = "165" Then
            'Propose leave
            table_name = "tb_emp_leave"
            field_id = "id_emp_leave"
            field_number = "emp_leave_number"
            field_date = "emp_leave_date"
        ElseIf report_mark_type = "96" Then
            'Propose leave need management approval
            table_name = "tb_emp_leave"
            field_id = "id_emp_leave"
            field_number = "emp_leave_number"
            field_date = "emp_leave_date"
        ElseIf report_mark_type = "97" Then
            'DP
            table_name = "tb_emp_dp"
            field_id = "id_dp"
            field_number = "dp_number"
            field_date = "dp_date_created"
        ElseIf report_mark_type = "98" Then
            'DP
            table_name = "tb_emp_ch_schedule"
            field_id = "id_emp_ch_schedule"
            field_number = "emp_ch_schedule_number"
            field_date = "emp_ch_schedule_date"
        ElseIf report_mark_type = "99" Then
            'Propose leave
            table_name = "tb_emp_leave"
            field_id = "id_emp_leave"
            field_number = "emp_leave_number"
            field_date = "emp_leave_date"
        ElseIf report_mark_type = "100" Then
            'Propose schedule with approval
            table_name = "tb_emp_assign_sch"
            field_id = "id_assign_sch"
            field_number = "assign_sch_number"
            field_date = "assign_sch_date"
        ElseIf report_mark_type = "101" Then
            'Air Ways Bill
            table_name = "tb_wh_awbill"
            field_id = "id_awbill"
            field_number = "id_awbill"
            field_date = "awbill_date"
        ElseIf report_mark_type = "102" Then
            'Propose leave
            table_name = "tb_emp_leave"
            field_id = "id_emp_leave"
            field_number = "emp_leave_number"
            field_date = "emp_leave_date"
        ElseIf report_mark_type = "103" Then
            'combine delivery
            table_name = "tb_pl_sales_order_del_combine"
            field_id = "id_combine"
            field_number = "combine_number"
            field_date = "combine_date"
        ElseIf report_mark_type = "104" Then
            'Propose leave
            table_name = "tb_emp_leave"
            field_id = "id_emp_leave"
            field_number = "emp_leave_number"
            field_date = "emp_leave_date"
        ElseIf report_mark_type = "105" Or report_mark_type = "224" Then
            'FINAL CLEARANCE
            table_name = "tb_prod_fc"
            field_id = "id_prod_fc"
            field_number = "prod_fc_number"
            field_date = "prod_fc_date"
        ElseIf report_mark_type = "107" Then
            'ASSEMBLY
            table_name = "tb_prod_ass"
            field_id = "id_prod_ass"
            field_number = "prod_ass_number"
            field_date = "prod_ass_date"
        ElseIf report_mark_type = "108" Then
            'Propose leave
            table_name = "tb_emp_leave"
            field_id = "id_emp_leave"
            field_number = "emp_leave_number"
            field_date = "emp_leave_date"
        ElseIf report_mark_type = "109" Then
            'Propose leave
            table_name = "tb_emp_leave"
            field_id = "id_emp_leave"
            field_number = "emp_leave_number"
            field_date = "emp_leave_date"
        ElseIf report_mark_type = "110" Then
            'Propose leave
            table_name = "tb_emp_leave"
            field_id = "id_emp_leave"
            field_number = "emp_leave_number"
            field_date = "emp_leave_date"
        ElseIf report_mark_type = "111" Then
            'non stock out
            table_name = "tb_sales_return"
            field_id = "id_sales_return"
            field_number = "sales_return_number"
            field_date = "sales_return_date"
        ElseIf report_mark_type = "113" Then
            'return khusus
            table_name = "tb_sales_return"
            field_id = "id_sales_return"
            field_number = "sales_return_number"
            field_date = "sales_return_date"
        ElseIf report_mark_type = "116" Then
            'missing promo
            table_name = "tb_sales_pos"
            field_id = "id_sales_pos"
            field_number = "sales_pos_number"
            field_date = "sales_pos_date"
        ElseIf report_mark_type = "117" Then
            'missing staff
            table_name = "tb_sales_pos"
            field_id = "id_sales_pos"
            field_number = "sales_pos_number"
            field_date = "sales_pos_date"
        ElseIf report_mark_type = "118" Then
            'SALES CREDIT NOTE
            table_name = "tb_sales_pos"
            field_id = "id_sales_pos"
            field_number = "sales_pos_number"
            field_date = "sales_pos_date"
        ElseIf report_mark_type = "120" Then
            'return ol store
            table_name = "tb_sales_return"
            field_id = "id_sales_return"
            field_number = "sales_return_number"
            field_date = "sales_return_date"
        ElseIf report_mark_type = "124" Then
            'Propose leave
            table_name = "tb_emp_leave"
            field_id = "id_emp_leave"
            field_number = "emp_leave_number"
            field_date = "emp_leave_date"
        ElseIf report_mark_type = "126" Then
            'OVER PRODUCTION MEMO
            table_name = "tb_prod_over_memo"
            field_id = "id_prod_over_memo"
            field_number = "memo_number"
            field_date = "created_date"
        ElseIf report_mark_type = "128" Then
            'Asset PO
            table_name = "tb_a_asset_po"
            field_id = "id_asset_po"
            field_number = "asset_po_no"
            field_date = "asset_po_date"
        ElseIf report_mark_type = "129" Then
            'Asset Rec
            table_name = "tb_a_asset_rec"
            field_id = "id_asset_rec"
            field_number = "asset_rec_no"
            field_date = "asset_rec_date"
        ElseIf report_mark_type = "132" Or report_mark_type = "236" Then
            'uniform expense
            table_name = "tb_emp_uni_ex"
            field_id = "id_emp_uni_ex"
            field_number = "emp_uni_ex_number"
            field_date = "emp_uni_ex_date"
        ElseIf report_mark_type = "133" Then
            'budget revenue
            table_name = "tb_b_revenue_propose"
            field_id = "id_b_revenue_propose"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "134" Then
            'item cat
            table_name = "tb_item_cat_propose"
            field_id = "id_item_cat_propose"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "135" Then
            'item cat
            table_name = "tb_item_coa_propose"
            field_id = "id_item_coa_propose"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "136" Then
            'budget Expense
            table_name = "tb_b_expense_propose"
            field_id = "id_b_expense_propose"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "137" Or report_mark_type = "201" Or report_mark_type = "218" Then
            'purchase request
            table_name = "tb_purc_req"
            field_id = "id_purc_req"
            field_number = "purc_req_number"
            field_date = "date_created"
        ElseIf report_mark_type = "138" Then
            'rev budget Expense
            table_name = "tb_b_expense_revision"
            field_id = "id_b_expense_revision"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "139" Or report_mark_type = "202" Then
            'purchase request
            table_name = "tb_purc_order"
            field_id = "id_purc_order"
            field_number = "purc_order_number"
            field_date = "date_created"
        ElseIf report_mark_type = "143" Or report_mark_type = "144" Or report_mark_type = "145" Or report_mark_type = "210" Then
            ' PD REV
            table_name = "tb_prod_demand_rev"
            field_id = "id_prod_demand_rev"
            field_number = "rev_count"
            field_date = "created_date"
        ElseIf report_mark_type = "142" Then
            'Cancel Report
            table_name = "tb_report_mark_cancel"
            field_id = "id_report_mark_cancel"
            field_number = "id_report_mark_cancel"
            field_date = "created_datetime"
        ElseIf report_mark_type = "147" Then
            'revision revenue budget
            table_name = "tb_b_revenue_revision"
            field_id = "id_b_revenue_revision"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "148" Then
            'purchase receive
            table_name = "tb_purc_rec"
            field_id = "id_purc_rec"
            field_number = "purc_rec_number"
            field_date = "date_created"
        ElseIf report_mark_type = "150" Or report_mark_type = "155" Or report_mark_type = "172" Or report_mark_type = "173" Then
            'Design COP Propose
            table_name = "tb_design_cop_propose"
            field_id = "id_design_cop_propose"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "151" Then
            'claim return
            table_name = "tb_prod_claim_return"
            field_id = "id_prod_claim_return"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "152" Then
            'purchaser return
            table_name = "tb_purc_return"
            field_id = "id_purc_return"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "153" Then
            'propose company
            table_name = "tb_m_comp"
            field_id = "id_comp"
            field_number = "comp_name"
            field_date = "last_updated"
        ElseIf report_mark_type = "154" Or report_mark_type = "163" Then
            'item req
            table_name = "tb_item_req"
            field_id = "id_item_req"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "156" Or report_mark_type = "166" Then
            'item del
            table_name = "tb_item_del"
            field_id = "id_item_del"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "157" Then
            'item_espense
            table_name = "tb_item_expense"
            field_id = "id_item_expense"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "159" Then
            'item del
            table_name = "tb_pn"
            field_id = "id_pn"
            field_number = "number"
            field_date = "date_created"
        ElseIf report_mark_type = "160" Or report_mark_type = "169" Then
            'asset
            table_name = "tb_purc_rec_asset"
            field_id = "id_purc_rec_asset"
            field_number = "asset_number"
            field_date = "acq_date"
        ElseIf report_mark_type = "162" Then
            'item del
            table_name = "tb_rec_payment"
            field_id = "id_rec_payment"
            field_number = "number"
            field_date = "date_created"
        ElseIf report_mark_type = "237" Then
            'Tabungan Missing
            table_name = "tb_missing_payment"
            field_id = "id_missing_payment"
            field_number = "number"
            field_date = "date_created"
        ElseIf report_mark_type = "167" Then
            'item del
            table_name = "tb_cash_advance"
            field_id = "id_cash_advance"
            field_number = "number"
            field_date = "date_created"
        ElseIf report_mark_type = "168" Then
            'receive return
            table_name = "tb_sales_return_rec"
            field_id = "id_sales_return_rec"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "174" Then
            'Cash Advance Reconcile
            table_name = "tb_cash_advance"
            field_id = "id_cash_advance"
            field_number = "number"
            field_date = "date_created"
        ElseIf report_mark_type = "175" Then
            'Sample budget propose
            table_name = "tb_sample_budget_pps"
            field_id = "id_sample_budget_pps"
            field_number = "number"
            field_date = "date_created"
        ElseIf report_mark_type = "183" Then
            'sales invoice diff margin
            table_name = "tb_sales_pos"
            field_id = "id_sales_pos"
            field_number = "sales_pos_number"
            field_date = "sales_pos_date"
        ElseIf report_mark_type = "185" Then
            'sample purchase close
            table_name = "tb_sample_purc_close"
            field_id = "id_sample_purc_close"
            field_number = "number"
            field_date = "date_created"
        ElseIf report_mark_type = "188" Then
            'propose price new product-revision
            table_name = "tb_fg_propose_price_rev"
            field_id = "id_fg_propose_price_rev"
            field_number = "rev_count"
            field_date = "created_date"
        ElseIf report_mark_type = "189" Then
            'bukti pembelian
            table_name = "tb_pn_fgpo"
            field_id = "id_pn_fgpo"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "190" Or report_mark_type = "193" Then
            'work order MTC/IT
            table_name = "tb_work_order"
            field_id = "id_work_order"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "192" Then
            'payroll
            table_name = "tb_emp_payroll"
            field_id = "id_payroll"
            field_number = "report_number"
            field_date = "NOW()"
        ElseIf report_mark_type = "197" Or report_mark_type = "229" Then
            'propose employee salary
            table_name = "tb_employee_sal_pps"
            field_id = "id_employee_sal_pps"
            field_number = "number"
            field_date = "created_at"
        ElseIf report_mark_type = "180" Then
            'propose employee
            table_name = "tb_employee_pps"
            field_id = "id_employee_pps"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "184" Or report_mark_type = "213" Or report_mark_type = "214" Or report_mark_type = "219" Or report_mark_type = "220" Then
            'Overtime employee
            table_name = "tb_ot"
            field_id = "id_ot"
            field_number = "number"
            field_date = "created_at"
        ElseIf report_mark_type = "187" Or report_mark_type = "215" Or report_mark_type = "216" Then
            'Overtime employee report
            table_name = "tb_ot_verification"
            field_id = "id_ot_verification"
            field_number = "(SELECT number FROM tb_ot WHERE id_ot = tb_ot_verification.id_ot)"
            field_date = "NOW()"
        ElseIf report_mark_type = "200" Then
            'propose design changes
            table_name = "tb_m_design_changes"
            field_id = "id_changes"
            field_number = "number"
            field_date = "NOW()"
        ElseIf report_mark_type = "203" Or report_mark_type = "204" Then
            'propose budget OPEX
            table_name = "tb_b_opex_pps"
            field_id = "id_b_opex_pps"
            field_number = "number"
            field_date = "date_created"
        ElseIf report_mark_type = "207" Then
            'Item Cat Main
            table_name = "tb_item_cat_main_pps"
            field_id = "id_item_cat_main_pps"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "208" Or report_mark_type = "209" Then
            'propose budget CAPEX
            table_name = "tb_b_expense_propose"
            field_id = "id_b_expense_propose"
            field_number = "number"
            field_date = "date_created"
        ElseIf report_mark_type = "211" Then
            table_name = "tb_emp_attn_input"
            field_id = "id_emp_attn_input"
            field_number = "number"
            field_date = "created_at"
        ElseIf report_mark_type = "212" Then
            'prod order closing propose
            table_name = "tb_prod_order_close"
            field_id = "id_prod_order_close"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "217" Then
            'bukti pickup
            table_name = "tb_del_pickup"
            field_id = "id_pickup"
            field_number = "id_pickup"
            field_date = "created_date"
        ElseIf report_mark_type = "221" Then
            'debit note
            table_name = "tb_debit_note"
            field_id = "id_debit_note"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "223" Then
            'bpjs kesehatan
            table_name = "tb_pay_bpjs_kesehatan"
            field_id = "id_pay_bpjs_kesehatan"
            field_number = "number"
            field_date = "created_at"
        ElseIf report_mark_type = "222" Then
            'summary qc report
            table_name = "tb_prod_fc_sum"
            field_id = "id_prod_fc_sum"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "231" Then
            'summary qc report
            table_name = "tb_inv_mat"
            field_id = "id_inv_mat"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "233" Then
            'delay payment
            table_name = "tb_propose_delay_payment"
            field_id = "id_propose_delay_payment"
            field_number = "number"
            field_date = "created_date"
        ElseIf report_mark_type = "234" Then
            'follow up ar
            table_name = "tb_follow_up_recap"
            field_id = "id_follow_up_recap"
            field_number = "''"
            field_date = "created_date"
        Else
            query = "Select '-' AS report_number, NOW() as report_date"
        End If

        If query = "" Then
            query = "SELECT " + field_number + " AS report_number," + field_date + " AS report_date FROM " + table_name + " WHERE " + field_id + "='" + id_report + "'"
        End If
        If Not is_qb = "1" Then

            data = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                report_number = data.Rows(0)("report_number").ToString()
                report_date = data.Rows(0)("report_date")
                'info col
                If report_mark_type = "22" Then
                    'po production
                    query = "SELECT desg.design_code,desg.design_display_name, pot.po_type FROM tb_prod_order po
                        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
                        INNER JOIN tb_m_design desg ON desg.id_design=pdd.id_design
                        INNER JOIN tb_lookup_po_type pot ON pot.id_po_type=po.id_po_type WHERE po.id_prod_order='" & id_report & "'"
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("po_type").ToString
                        info_report = ""
                        info_design_code = datax.Rows(0)("design_code").ToString
                        info_design = datax.Rows(0)("design_display_name").ToString
                    End If
                ElseIf report_mark_type = "23" Then
                    'wo production
                    query = "SELECT desg.design_code,desg.design_display_name,pot.po_type,po.prod_order_number FROM tb_prod_order_wo wo
                        INNER JOIN tb_prod_order po ON po.id_prod_order=wo.id_prod_order
                        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
                        INNER JOIN tb_m_design desg ON desg.id_design=pdd.id_design
                        INNER JOIN tb_lookup_po_type pot ON pot.id_po_type=po.id_po_type WHERE wo.id_prod_order_wo='" & id_report & "'"
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("po_type").ToString
                        info_report = datax.Rows(0)("prod_order_number").ToString
                        info_design_code = datax.Rows(0)("design_code").ToString
                        info_design = datax.Rows(0)("design_display_name").ToString
                    End If
                ElseIf report_mark_type = "28" Or report_mark_type = "127" Then
                    'receiving QC
                    query = "SELECT a.id_report_status,h.report_status, g.id_season,g.season,a.id_prod_order_rec,a.prod_order_rec_number, "
                    query += "(a.delivery_order_date) AS delivery_order_date,a.delivery_order_number,b.prod_order_number, "
                    query += "(a.prod_order_rec_date) AS prod_order_rec_date, CONCAT(f.comp_number,' - ',f.comp_name) AS comp_from, CONCAT(d.comp_number,' - ',d.comp_name) AS comp_to, dsg.design_code,dsg.design_display_name, po_type.po_type "
                    query += "FROM tb_prod_order_rec a  "
                    query += "INNER JOIN tb_prod_order b ON a.id_prod_order=b.id_prod_order "
                    query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_comp_contact_to "
                    query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
                    query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact = a.id_comp_contact_from  "
                    query += "INNER JOIN tb_m_comp f ON f.id_comp = e.id_comp "
                    query += "INNER JOIN tb_season_delivery i ON b.id_delivery = i.id_delivery "
                    query += "INNER JOIN tb_season g ON g.id_season = i.id_season "
                    query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
                    query += "INNER JOIN tb_prod_demand_design pd_dsg ON pd_dsg.id_prod_demand_design = b.id_prod_demand_design "
                    query += "INNER JOIN tb_m_design dsg ON dsg.id_design = pd_dsg.id_design "
                    query += "INNER JOIN tb_lookup_po_type po_type ON po_type.id_po_type = b.id_po_type "
                    query += "WHERE a.id_prod_order_rec=" + id_report + " "
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("po_type").ToString
                        info_report = datax.Rows(0)("prod_order_number").ToString
                        info_design_code = datax.Rows(0)("design_code").ToString
                        info_design = datax.Rows(0)("design_display_name").ToString
                    End If
                ElseIf report_mark_type = "29" Then
                    'mrs production
                    query = "SELECT desg.design_code,desg.design_display_name,pot.po_type,po.prod_order_number
                            FROM tb_prod_order_mrs mrs
                            INNER JOIN tb_prod_order po ON po.id_prod_order=mrs.id_prod_order
                            INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
                            INNER JOIN tb_m_design desg ON desg.id_design=pdd.id_design
                            INNER JOIN tb_lookup_po_type pot ON pot.id_po_type=po.id_po_type
                            WHERE mrs.`id_prod_order_mrs`='" & id_report & "'"
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("po_type").ToString
                        info_report = datax.Rows(0)("prod_order_number").ToString
                        info_design_code = datax.Rows(0)("design_code").ToString
                        info_design = datax.Rows(0)("design_display_name").ToString
                    End If
                ElseIf report_mark_type = "30" Then
                    'PL MRS production
                    query = "SELECT desg.design_code,desg.design_display_name,po.prod_order_number FROM tb_pl_mrs plm
                        INNER JOIN tb_prod_order_mrs pom ON pom.id_prod_order_mrs=plm.id_prod_order_mrs
                        INNER JOIN tb_prod_order po ON po.id_prod_order=pom.id_prod_order
                        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
                        INNER JOIN tb_m_design desg ON desg.id_design=pdd.id_design
                        WHERE plm.id_pl_mrs='" & id_report & "'"
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = ""
                        info_report = datax.Rows(0)("prod_order_number").ToString
                        info_design_code = datax.Rows(0)("design_code").ToString
                        info_design = datax.Rows(0)("design_display_name").ToString
                    End If
                ElseIf report_mark_type = "31" Then
                    'return out production
                    query = "SELECT a.id_prod_order_ret_out,a.prod_order_ret_out_number, "
                    query += "b.prod_order_number, "
                    query += "dsg.design_code,dsg.design_display_name, po_type.po_type "
                    query += "FROM tb_prod_order_ret_out a  "
                    query += "INNER JOIN tb_prod_order b ON a.id_prod_order=b.id_prod_order "
                    query += "INNER JOIN tb_prod_demand_design pd_dsg ON pd_dsg.id_prod_demand_design = b.id_prod_demand_design "
                    query += "INNER JOIN tb_m_design dsg ON dsg.id_design = pd_dsg.id_design "
                    query += "INNER JOIN tb_lookup_po_type po_type ON po_type.id_po_type = b.id_po_type "
                    query += "WHERE a.id_prod_order_ret_out=" + id_report + " "
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("po_type").ToString
                        info_report = datax.Rows(0)("prod_order_number").ToString
                        info_design_code = datax.Rows(0)("design_code").ToString
                        info_design = datax.Rows(0)("design_display_name").ToString
                    End If
                ElseIf report_mark_type = "32" Then
                    'return in production
                    query = "SELECT a.id_prod_order_ret_in,a.prod_order_ret_in_number, "
                    query += "b.prod_order_number, "
                    query += "dsg.design_code,dsg.design_display_name, po_type.po_type "
                    query += "FROM tb_prod_order_ret_in a  "
                    query += "INNER JOIN tb_prod_order b ON a.id_prod_order=b.id_prod_order "
                    query += "INNER JOIN tb_prod_demand_design pd_dsg ON pd_dsg.id_prod_demand_design = b.id_prod_demand_design "
                    query += "INNER JOIN tb_m_design dsg ON dsg.id_design = pd_dsg.id_design "
                    query += "INNER JOIN tb_lookup_po_type po_type ON po_type.id_po_type = b.id_po_type "
                    query += "WHERE a.id_prod_order_ret_in=" + id_report + " "
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("po_type").ToString
                        info_report = datax.Rows(0)("prod_order_number").ToString
                        info_design_code = datax.Rows(0)("design_code").ToString
                        info_design = datax.Rows(0)("design_display_name").ToString
                    End If
                ElseIf report_mark_type = "33" Then
                    'pl to wh
                    query = "SELECT a.id_pl_prod_order,a.pl_prod_order_number, "
                    query += "b.prod_order_number, "
                    query += "dsg.design_code,dsg.design_display_name, po_type.po_type "
                    query += "FROM tb_pl_prod_order a  "
                    query += "INNER JOIN tb_prod_order b ON a.id_prod_order=b.id_prod_order "
                    query += "INNER JOIN tb_prod_demand_design pd_dsg ON pd_dsg.id_prod_demand_design = b.id_prod_demand_design "
                    query += "INNER JOIN tb_m_design dsg ON dsg.id_design = pd_dsg.id_design "
                    query += "INNER JOIN tb_lookup_po_type po_type ON po_type.id_po_type = b.id_po_type "
                    query += "WHERE a.id_pl_prod_order=" + id_report + " "
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("po_type").ToString
                        info_report = datax.Rows(0)("prod_order_number").ToString
                        info_design_code = datax.Rows(0)("design_code").ToString
                        info_design = datax.Rows(0)("design_display_name").ToString
                    End If
                ElseIf report_mark_type = "37" Then
                    'rec wh
                    query = "SELECT CONCAT(c.comp_number,' - ', c.comp_name) AS `vendor`,
                d.design_code AS `code`, d.design_display_name AS `name`,
                CAST(IFNULL(SUM(recd.pl_prod_order_rec_det_qty),0) AS DECIMAL(10,0)) AS `total_qty`
                FROM tb_pl_prod_order_rec rec
                LEFT JOIN tb_pl_prod_order_rec_det recd ON recd.id_pl_prod_order_rec = rec.id_pl_prod_order_rec
                INNER JOIN tb_pl_prod_order pl ON pl.id_pl_prod_order = rec.id_pl_prod_order
                INNER JOIN tb_prod_order po ON po.id_prod_order = pl.id_prod_order
                LEFT JOIN tb_prod_order_wo wo ON wo.id_prod_order = po.id_prod_order AND wo.is_main_vendor=1
                LEFT JOIN tb_m_ovh_price op ON op.id_ovh_price = wo.id_ovh_price
                LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact = op.id_comp_contact
                LEFT JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
                INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
                WHERE rec.id_pl_prod_order_rec=" + id_report + "
                GROUP BY rec.id_pl_prod_order_rec "
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("total_qty").ToString
                        info_report = datax.Rows(0)("vendor").ToString
                        info_design_code = datax.Rows(0)("code").ToString
                        info_design = datax.Rows(0)("name").ToString
                    End If
                ElseIf report_mark_type = "43" Then
                    'pre delivery
                    query = "SELECT CONCAT(c.comp_number,' - ', c.comp_name) AS `store`,
                CAST(IFNULL(SUM(delt.pl_sales_order_del_det_qty),0) AS DECIMAL(10,0)) AS `total_qty`
                FROM tb_pl_sales_order_del del
                LEFT JOIN tb_pl_sales_order_del_det delt ON delt.id_pl_sales_order_del = del.id_pl_sales_order_del
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = del.id_store_contact_to
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                WHERE del.id_pl_sales_order_del=" + id_report + "
                GROUP BY del.id_pl_sales_order_del "
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("total_qty").ToString
                        info_report = datax.Rows(0)("store").ToString
                    End If
                ElseIf report_mark_type = "46" Or report_mark_type = "113" Or report_mark_type = "120" Then
                    'return
                    query = "SELECT CONCAT(c.comp_number,' - ', c.comp_name) AS `store`,
                CAST(IFNULL(SUM(rd.sales_return_det_qty),0) AS DECIMAL(10,0)) AS `total_qty`
                FROM tb_sales_return r
                LEFT JOIN tb_sales_return_det rd ON rd.id_sales_return = r.id_sales_return
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = r.id_store_contact_from
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                WHERE r.id_sales_return=" + id_report + "
                GROUP BY r.id_sales_return "
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("total_qty").ToString
                        info_report = datax.Rows(0)("store").ToString
                    End If
                ElseIf report_mark_type = "47" Then
                    'mat return in production
                    query = "SELECT a.id_mat_prod_ret_in,a.mat_prod_ret_in_number, "
                    query += "b.prod_order_number, "
                    query += "dsg.design_code,dsg.design_display_name, po_type.po_type "
                    query += "FROM tb_mat_prod_ret_in a  "
                    query += "INNER JOIN tb_prod_order b ON a.id_prod_order=b.id_prod_order "
                    query += "INNER JOIN tb_prod_demand_design pd_dsg ON pd_dsg.id_prod_demand_design = b.id_prod_demand_design "
                    query += "INNER JOIN tb_m_design dsg ON dsg.id_design = pd_dsg.id_design "
                    query += "INNER JOIN tb_lookup_po_type po_type ON po_type.id_po_type = b.id_po_type "
                    query += "WHERE a.id_mat_prod_ret_in=" + id_report + " "
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("po_type").ToString
                        'info_report = datax.Rows(0)("prod_order_number").ToString
                        info_report = datax.Rows(0)("mat_prod_ret_in_number").ToString
                        info_design_code = datax.Rows(0)("design_code").ToString
                        info_design = datax.Rows(0)("design_display_name").ToString
                    End If
                ElseIf report_mark_type = "49" Or report_mark_type = "106" Then
                    'return transfer
                    query = "SELECT r.sales_return_number AS `return`,
                CONCAT(c.comp_number,' - ', c.comp_name) AS `store`,
                CAST(IFNULL(SUM(rtd.sales_return_qc_det_qty),0) AS DECIMAL(10,0)) AS `total_qty`
                FROM tb_sales_return_qc rt
                LEFT JOIN tb_sales_return_qc_det rtd ON rtd.id_sales_return_qc = rt.id_sales_return_qc
                INNER JOIN tb_sales_return r ON r.id_sales_return = rt.id_sales_return
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = rt.id_store_contact_from
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                WHERE rt.id_sales_return_qc=" + id_report + "
                GROUP BY rt.id_sales_return_qc "
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("total_qty").ToString
                        info_report = datax.Rows(0)("store").ToString
                        info_design = datax.Rows(0)("return").ToString
                    End If
                ElseIf report_mark_type = "50" Then
                    'PR Production
                    query = "SELECT desg.design_code,desg.design_display_name,po.prod_order_number
                        FROM tb_pr_prod_order pr
                        INNER JOIN `tb_prod_order_wo` wo ON wo.id_prod_order_wo=pr.id_prod_order_wo
                        INNER JOIN tb_prod_order po ON po.id_prod_order=wo.id_prod_order
                        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
                        INNER JOIN tb_m_design desg ON desg.id_design=pdd.id_design
                        WHERE pr.id_pr_prod_order='" & id_report & "'"
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = ""
                        info_report = datax.Rows(0)("prod_order_number").ToString
                        info_design_code = datax.Rows(0)("design_code").ToString
                        info_design = datax.Rows(0)("design_display_name").ToString
                    End If
                ElseIf report_mark_type = "57" Then
                    'transfer
                    query = "SELECT
                CONCAT(c.comp_number,' - ', c.comp_name) AS `to`,
                CAST(IFNULL(SUM(td.fg_trf_det_qty),0) AS DECIMAL(10,0)) AS `total_qty`
                FROM tb_fg_trf t
                LEFT JOIN tb_fg_trf_det td ON td.id_fg_trf = t.id_fg_trf
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = t.id_comp_contact_to
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                WHERE t.id_fg_trf=" + id_report + "
                GROUP BY t.id_fg_trf "
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("total_qty").ToString
                        info_report = datax.Rows(0)("to").ToString
                    End If
                ElseIf report_mark_type = "95" Or report_mark_type = "96" Or report_mark_type = "99" Or report_mark_type = "102" Or report_mark_type = "104" Or report_mark_type = "164" Or report_mark_type = "165" Then
                    query = "SELECT emp.employee_name FROM tb_emp_leave el
                            INNER JOIN tb_m_employee emp ON emp.id_employee=el.id_emp
                            WHERE el.id_emp_leave='" + id_report + "'"
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("employee_name").ToString
                    End If
                ElseIf report_mark_type = "100" Then
                    query = "SELECT sch.id_departement, dep.`departement`, dep_sub.departement_sub FROM `tb_emp_assign_sch` sch
                         LEFT JOIN tb_m_departement dep ON dep.`id_departement`=sch.`id_departement`
                         LEFT JOIN tb_m_departement_sub dep_sub ON dep_sub.`id_departement_sub`=sch.`id_departement_sub`
                         WHERE sch.`id_assign_sch`='" + id_report + "'"
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        If datax.Rows(0)("id_departement").ToString = "17" Then
                            info_col = datax.Rows(0)("departement_sub").ToString
                        Else
                            info_col = datax.Rows(0)("departement").ToString
                        End If
                    End If
                ElseIf report_mark_type = "103" Then
                    'combine delivery
                    query = "SELECT CONCAT(c.comp_number,' - ', c.comp_name) AS `store`,
                CAST(IFNULL(SUM(delt.pl_sales_order_del_det_qty),0) AS DECIMAL(10,0)) AS `total_qty`
                FROM tb_pl_sales_order_del del
                LEFT JOIN tb_pl_sales_order_del_det delt ON delt.id_pl_sales_order_del = del.id_pl_sales_order_del
                INNER JOIN tb_pl_sales_order_del_combine comb ON comb.id_combine = del.id_combine
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = comb.id_store_contact_to
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                WHERE del.id_combine=" + id_report + "
                GROUP BY del.id_combine "
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("total_qty").ToString
                        info_report = datax.Rows(0)("store").ToString
                    End If
                ElseIf report_mark_type = "105" Or report_mark_type = "224" Then
                    'final clearance
                    Dim fcl As New ClassProductionFinalClear()
                    query = fcl.queryMain("AND f.id_prod_fc=" + id_report + " ", "1")
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("pl_category").ToString
                        info_report = datax.Rows(0)("prod_order_number").ToString
                        info_design_code = datax.Rows(0)("code").ToString
                        info_design = datax.Rows(0)("name").ToString
                    End If
                ElseIf report_mark_type = "107" Then
                    'assembly
                    Dim ass As New ClassProductionAssembly()
                    query = ass.queryMain("AND a.id_prod_ass=" + id_report + " ", "1")
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = ""
                        info_report = ""
                        info_design_code = datax.Rows(0)("code").ToString
                        info_design = datax.Rows(0)("name").ToString
                    End If
                ElseIf report_mark_type = "111" Then
                    'non stock
                    'return
                    query = "SELECT CONCAT(c.comp_number,' - ', c.comp_name) AS `store`,
                CAST(IFNULL(COUNT(rd.id_sales_return_problem),0) AS DECIMAL(10,0)) AS `total_qty`
                FROM tb_sales_return r
                LEFT JOIN tb_sales_return_problem rd ON rd.id_sales_return = r.id_sales_return
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = r.id_store_contact_from
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                WHERE r.id_sales_return=" + id_report + "
                GROUP BY r.id_sales_return "
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("total_qty").ToString
                        info_report = datax.Rows(0)("store").ToString
                    End If
                ElseIf report_mark_type = "130" Then
                    'uniform ordder
                    query = "SELECT sod.id_sales_order, e.id_employee, e.employee_code,e.employee_name, SUM(sod.sales_order_det_qty) AS `total_qty`
                FROM tb_sales_order_det sod
                INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
                LEFT JOIN tb_emp_uni_budget b ON b.id_emp_uni_budget = so.id_emp_uni_budget
                LEFT JOIN tb_m_employee e ON e.id_employee = b.id_employee
                WHERE sod.id_sales_order=" + id_report + "
                GROUP BY sod.id_sales_order "
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("total_qty").ToString
                        info_design_code = datax.Rows(0)("employee_code").ToString
                        info_design = datax.Rows(0)("employee_name").ToString
                    End If
                ElseIf report_mark_type = "133" Then
                    'budget rev
                    query = "SELECT year FROM tb_b_revenue_propose WHERE id_b_revenue_propose=" + id_report + " "
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("year").ToString
                    End If
                ElseIf report_mark_type = "143" Or report_mark_type = "144" Or report_mark_type = "145" Or report_mark_type = "210" Then
                    'pd revision
                    query = "SELECT tb_prod_demand_rev.id_report_status,CONCAT(tb_prod_demand.prod_demand_number,'/REV ', tb_prod_demand_rev.rev_count) as report_number
                    FROM tb_prod_demand_rev
                    INNER JOIN tb_prod_demand ON tb_prod_demand.id_prod_demand = tb_prod_demand_rev.id_prod_demand
                    WHERE id_prod_demand_rev=" + id_report + " "
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        report_number = datax.Rows(0)("report_number").ToString
                    End If
                ElseIf report_mark_type = "147" Then
                    'budget rev
                    query = "SELECT year FROM tb_b_revenue_revision WHERE id_b_revenue_revision=" + id_report + " "
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("year").ToString
                    End If
                ElseIf report_mark_type = "148" Then
                    'purchase receive non asset
                ElseIf report_mark_type = "151" Then
                    'claim return
                    query = "SELECT po.prod_order_number, d.design_code, d.design_display_name
                    FROM tb_prod_claim_return cr
                    INNER JOIN tb_prod_order po ON po.id_prod_order = cr.id_prod_order
                    INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
                    INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
                    WHERE cr.id_prod_claim_return='" + id_report + "' "
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_report = datax.Rows(0)("prod_order_number").ToString
                        info_design_code = datax.Rows(0)("design_code").ToString
                        info_design = datax.Rows(0)("design_display_name").ToString
                    End If
                ElseIf report_mark_type = "152" Then
                    'purchase return
                    query = "SELECT po.purc_order_number
                    FROM tb_purc_return ret
                    INNER JOIN tb_purc_order po ON po.id_purc_order = ret.id_purc_order
                    WHERE ret.id_purc_return=" + id_report + ""
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_report = datax.Rows(0)("purc_order_number").ToString
                    End If
                ElseIf report_mark_type = "188" Then
                    'propose price new product-revision
                    query = "SELECT tb_fg_propose_price_rev.id_report_status,CONCAT(tb_fg_propose_price.fg_propose_price_number,'/REV ', tb_fg_propose_price_rev.rev_count) as report_number
                    FROM tb_fg_propose_price_rev
                    INNER JOIN tb_fg_propose_price ON tb_fg_propose_price.id_fg_propose_price = tb_fg_propose_price_rev.id_fg_propose_price
                    WHERE tb_fg_propose_price_rev.id_fg_propose_price_rev=" + id_report + " "
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        report_number = datax.Rows(0)("report_number").ToString
                    End If
                ElseIf report_mark_type = "180" Then
                    'employee propose
                    query = "SELECT employee_name
                    FROM tb_employee_pps
                    WHERE id_employee_pps = " + id_report + ""
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_design = "Employee: " + datax.Rows(0)("employee_name").ToString
                    End If
                ElseIf report_mark_type = "192" Then
                    'payroll
                    query = "SELECT IF(pytype.is_thr = 1, DATE_FORMAT(py.periode_end,'%Y'), DATE_FORMAT(py.periode_end,'%M %Y')) AS period, pytype.payroll_type
                    FROM tb_emp_payroll AS py
                    LEFT JOIN tb_emp_payroll_type AS pytype ON py.id_payroll_type = pytype.id_payroll_type
                    WHERE py.id_payroll = " + id_report + ""
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("payroll_type").ToString
                        info_design = "Period: " + datax.Rows(0)("period").ToString
                    End If
                ElseIf report_mark_type = "187" Or report_mark_type = "215" Or report_mark_type = "216" Then
                    'Overtime employee report
                    query = "SELECT DATE_FORMAT(ot_date,'%d %M %Y') AS ot_date FROM tb_ot_verification WHERE id_ot_verification = '" + id_report + "'"
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_design = "Date: " + datax.Rows(0)("ot_date").ToString
                    End If
                ElseIf report_mark_type = "223" Then
                    'bpjs kesehatan
                    query = "SELECT DATE_FORMAT(periode_end,'%M %Y') AS period, IF(id_payroll_type = 1, 'Organic', 'Daily Worker') AS payroll_type
                    FROM tb_emp_payroll
                    WHERE id_payroll = (SELECT id_payroll FROM tb_pay_bpjs_kesehatan WHERE id_pay_bpjs_kesehatan = " + id_report + ")"
                    Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If datax.Rows.Count > 0 Then
                        info_col = datax.Rows(0)("payroll_type").ToString
                        info_design = "Period: " + datax.Rows(0)("period").ToString
                    End If
                End If
            End If
        Else
            '======= query viewing =======
            'add parameter
            'build query view
            If report_mark_type = "x" Then

            ElseIf report_mark_type = "13" Then
                query_view = "Select 'no' AS is_check,tb." & field_id & " AS id_report,tb." & field_number & " AS number,tb." & field_date & " AS date_created
                                ,c.`comp_name`,SUM(det.`mat_purc_det_qty`) AS tot_qty
                                ,cur.currency AS currency ,SUM(det.`mat_purc_det_qty`*det.`mat_purc_det_price`) AS amount_usd
                                ,tb.`mat_purc_kurs` AS kurs
                                ,SUM(det.`mat_purc_det_qty`*IF(tb.`id_currency`=1,det.`mat_purc_det_price`,tb.`mat_purc_kurs`*det.`mat_purc_det_price`)) AS tot_amount
                                FROM " & table_name & " tb
                                INNER JOIN `tb_m_comp_contact` cc ON cc.`id_comp_contact`=tb.`id_comp_contact_to`
                                INNER JOIN `tb_m_comp` c ON c.`id_comp`=cc.`id_comp`
                                INNER JOIN tb_lookup_currency cur ON cur.id_currency=tb.id_currency
                                INNER JOIN `tb_mat_purc_det` det ON det.`id_mat_purc`=tb.`id_mat_purc`
                                WHERE tb.id_report_status='6'"
                If Not qb_id_not_include = "" Then 'popup pick setelah ada isi tabelnya
                    query_view += " AND tb." & field_id & " NOT IN " & qb_id_not_include
                End If
                query_view += " GROUP BY tb." & field_id & ""
                '
                query_view_blank = "SELECT tb. " & field_id & " AS id_report,tb." & field_number & " AS number,tb." & field_date & " AS date_created
                                    ,c.`comp_name`,0.00 AS tot_qty,cur.currency AS currency,0.00 AS amount_usd,0.00 AS kurs,0.00 AS tot_amount
                                    FROM " & table_name & " tb
                                    INNER JOIN `tb_m_comp_contact` cc ON cc.`id_comp_contact`=tb.`id_comp_contact_to`
                                    INNER JOIN `tb_m_comp` c ON c.`id_comp`=cc.`id_comp`
                                    INNER JOIN `tb_mat_purc_det` det ON det.`id_mat_purc`=tb.`id_mat_purc`
                                    INNER JOIN tb_lookup_currency cur ON cur.id_currency=tb.id_currency
                                   WHERE tb.id_report_status='-1'"
                query_view_edit = "SELECT rmcr.id_report,tb." & field_number & " AS number,tb." & field_date & " AS date_created,rmcr.id_report_mark_cancel_report as id_rmcr " & generate_left_join_cancel("column") & "
                                ,c.`comp_name`,SUM(det.`mat_purc_det_qty`) AS tot_qty
                                ,cur.currency AS currency
                                ,SUM(det.`mat_purc_det_qty`*det.`mat_purc_det_price`) AS amount_usd
                                ,tb.`mat_purc_kurs` AS kurs
                                ,SUM(det.`mat_purc_det_qty`*IF(tb.`id_currency`=1,det.`mat_purc_det_price`,tb.`mat_purc_kurs`*det.`mat_purc_det_price`)) AS tot_amount
                                FROM tb_report_mark_cancel_report rmcr
                               " & generate_left_join_cancel("query") & "
                               INNER JOIN " & table_name & " tb ON tb." & field_id & "=rmcr.id_report
                               INNER JOIN `tb_m_comp_contact` cc ON cc.`id_comp_contact`=tb.`id_comp_contact_to`
                                INNER JOIN `tb_m_comp` c ON c.`id_comp`=cc.`id_comp`
                                INNER JOIN tb_lookup_currency cur ON cur.id_currency=tb.id_currency
                                INNER JOIN `tb_mat_purc_det` det ON det.`id_mat_purc`=tb.`id_mat_purc`
                               WHERE rmcr.id_report_mark_cancel='" & id_report_mark_cancel & "'
                               GROUP BY tb." & field_id
            ElseIf report_mark_type = "139" Then 'PO Opex
                query_view = "Select 'no' AS is_check,tb." & field_id & " AS id_report,tb." & field_number & " AS number,tb." & field_date & " AS date_created
                                ,c.`comp_name`,et.expense_type
                                FROM " & table_name & " tb
                                INNER JOIN `tb_m_comp_contact` cc ON cc.`id_comp_contact`=tb.`id_comp_contact`
                                INNER JOIN `tb_m_comp` c ON c.`id_comp`=cc.`id_comp`
                                INNER JOIN `tb_lookup_expense_type` et ON et.`id_expense_type`=tb.`id_expense_type`
                                LEFT JOIN tb_purc_rec rec ON rec.`id_purc_order`=tb.`id_purc_order` AND rec.`id_report_status`!=5
                                WHERE tb.id_report_status='6' AND tb.`id_expense_type`='1' AND ISNULL(rec.`id_purc_rec`)"
                If Not qb_id_not_include = "" Then 'popup pick setelah ada isi tabelnya
                    query_view += " AND tb." & field_id & " NOT IN " & qb_id_not_include
                End If
                query_view += " GROUP BY tb." & field_id & ""
                '
                query_view_blank = "SELECT tb. " & field_id & " AS id_report,tb." & field_number & " AS number,tb." & field_date & " AS date_created
                                    ,c.`comp_name`,et.expense_type
                                    FROM " & table_name & " tb
                                    INNER JOIN `tb_m_comp_contact` cc ON cc.`id_comp_contact`=tb.`id_comp_contact`
                                    INNER JOIN `tb_m_comp` c ON c.`id_comp`=cc.`id_comp`
                                    INNER JOIN `tb_lookup_expense_type` et ON et.`id_expense_type`=tb.`id_expense_type`
                                   WHERE tb.id_report_status='-1'"
                query_view_edit = "SELECT rmcr.id_report,tb." & field_number & " AS number,tb." & field_date & " AS date_created,rmcr.id_report_mark_cancel_report as id_rmcr,c.`comp_name`,et.expense_type " & generate_left_join_cancel("column") & "
                                FROM tb_report_mark_cancel_report rmcr
                               " & generate_left_join_cancel("query") & "
                               INNER JOIN " & table_name & " tb ON tb." & field_id & "=rmcr.id_report
                               INNER JOIN `tb_m_comp_contact` cc ON cc.`id_comp_contact`=tb.`id_comp_contact`
                               INNER JOIN `tb_m_comp` c ON c.`id_comp`=cc.`id_comp`
                               INNER JOIN `tb_lookup_expense_type` et ON et.`id_expense_type`=tb.`id_expense_type`
                               LEFT JOIN tb_purc_rec rec ON rec.`id_purc_order`=tb.`id_purc_order` AND rec.`id_report_status`!=5
                               WHERE rmcr.id_report_mark_cancel='" & id_report_mark_cancel & "' AND ISNULL(rec.`id_purc_rec`)
                               GROUP BY tb." & field_id
            ElseIf report_mark_type = "202" Then 'capex
                query_view = "Select 'no' AS is_check,tb." & field_id & " AS id_report,tb." & field_number & " AS number,tb." & field_date & " AS date_created
                                ,c.`comp_name`,et.expense_type
                                FROM " & table_name & " tb
                                INNER JOIN `tb_m_comp_contact` cc ON cc.`id_comp_contact`=tb.`id_comp_contact`
                                INNER JOIN `tb_m_comp` c ON c.`id_comp`=cc.`id_comp`
                                INNER JOIN `tb_lookup_expense_type` et ON et.`id_expense_type`=tb.`id_expense_type`
                                LEFT JOIN tb_purc_rec rec ON rec.`id_purc_order`=tb.`id_purc_order` AND rec.`id_report_status`!=5
                                WHERE tb.id_report_status='6' AND tb.`id_expense_type`='2' AND ISNULL(rec.`id_purc_rec`)"
                If Not qb_id_not_include = "" Then 'popup pick setelah ada isi tabelnya
                    query_view += " AND tb." & field_id & " NOT IN " & qb_id_not_include
                End If
                query_view += " GROUP BY tb." & field_id & ""
                '
                query_view_blank = "SELECT tb. " & field_id & " AS id_report,tb." & field_number & " AS number,tb." & field_date & " AS date_created
                                    ,c.`comp_name`,et.expense_type
                                    FROM " & table_name & " tb
                                    INNER JOIN `tb_m_comp_contact` cc ON cc.`id_comp_contact`=tb.`id_comp_contact`
                                    INNER JOIN `tb_m_comp` c ON c.`id_comp`=cc.`id_comp`
                                    INNER JOIN `tb_lookup_expense_type` et ON et.`id_expense_type`=tb.`id_expense_type`
                                   WHERE tb.id_report_status='-1'"
                query_view_edit = "SELECT rmcr.id_report,tb." & field_number & " AS number,tb." & field_date & " AS date_created,rmcr.id_report_mark_cancel_report as id_rmcr,c.`comp_name`,et.expense_type " & generate_left_join_cancel("column") & "
                                FROM tb_report_mark_cancel_report rmcr
                               " & generate_left_join_cancel("query") & "
                               INNER JOIN " & table_name & " tb ON tb." & field_id & "=rmcr.id_report
                               INNER JOIN `tb_m_comp_contact` cc ON cc.`id_comp_contact`=tb.`id_comp_contact`
                               INNER JOIN `tb_m_comp` c ON c.`id_comp`=cc.`id_comp`
                               INNER JOIN `tb_lookup_expense_type` et ON et.`id_expense_type`=tb.`id_expense_type`
                               LEFT JOIN tb_purc_rec rec ON rec.`id_purc_order`=tb.`id_purc_order` AND rec.`id_report_status`!=5
                               WHERE rmcr.id_report_mark_cancel='" & id_report_mark_cancel & "' AND ISNULL(rec.`id_purc_rec`)
                               GROUP BY tb." & field_id
            ElseIf report_mark_type = "22" Then
                query_view = "SELECT 'no' AS is_check,tb.id_prod_order AS id_report,tb.prod_order_date AS date_created,ovh.comp_name,tb.prod_order_number AS number,dsg.`design_code_import`,dsg.design_code,dsg.`design_display_name`,SUM(det.prod_order_qty) AS qty,ovh.currency,ovh.unit_price,SUM(ovh.unit_price*det.prod_order_qty) AS amount FROM tb_prod_order tb
INNER JOIN tb_prod_order_det det ON det.id_prod_order=tb.id_prod_order
INNER JOIN (
	SELECT wo.`id_prod_order_wo`,wo.`id_prod_order`,SUM(wod.`prod_order_wo_det_qty`*wod.`prod_order_wo_det_price`*IF(wo.`id_currency`=1,1,wo.`prod_order_wo_kurs`)) AS amount FROM tb_prod_order_wo wo
	INNER JOIN tb_prod_order_wo_det wod ON wod.`id_prod_order_wo`=wo.`id_prod_order_wo`
	GROUP BY wo.`id_prod_order`
)wo ON wo.id_prod_order=tb.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=tb.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
INNER JOIN (
	SELECT wo.`id_prod_order`,c.`comp_name`,cur.`currency`,wod.`prod_order_wo_det_price` AS unit_price
    FROM tb_prod_order_wo wo
    INNER JOIN tb_prod_order_wo_det wod ON wod.`id_prod_order_wo`=wo.`id_prod_order_wo`
    INNER JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price` AND wo.`is_main_vendor`='1'
    INNER JOIN tb_lookup_currency cur ON cur.`id_currency`=ovhp.`id_currency`
    INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ovhp.`id_comp_contact`
    INNER JOIN tb_m_comp c ON c.id_comp=cc.`id_comp`
    GROUP BY wo.id_prod_order_wo
)ovh ON ovh.id_prod_order=tb.id_prod_order
LEFT JOIN (
	SELECT id_design 
	FROM `tb_fg_propose_price_detail` ppd
	INNER JOIN tb_fg_propose_price pp ON pp.`id_fg_propose_price`=ppd.`id_fg_propose_price`
	WHERE pp.id_report_status!=5
	GROUP BY ppd.id_design
)pp ON pp.id_design=dsg.`id_design`
LEFT JOIN (
	SELECT id_prod_order FROM tb_prod_order_rec WHERE id_report_status!=5
)rec ON rec.id_prod_order=det.`id_prod_order`
WHERE tb.id_report_status='6' AND IF(ISNULL(rec.id_prod_order),2,1)=2 "
                If Not qb_id_not_include = "" Then 'popup pick setelah ada isi tabelnya
                    query_view += " AND tb." & field_id & " NOT IN " & qb_id_not_include
                End If
                query_view += " GROUP BY tb.id_prod_order"
                '
                query_view_blank = "SELECT tb.id_prod_order AS id_report,tb.prod_order_date AS date_created,ovh.comp_name,tb.prod_order_number AS number,dsg.`design_code_import`,dsg.design_code,dsg.`design_display_name`,0.00 AS qty,ovh.currency,ovh.unit_price,0.00 AS amount FROM tb_prod_order tb
                                    INNER JOIN tb_prod_order_det det ON det.id_prod_order=tb.id_prod_order
                                    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=tb.`id_prod_demand_design`
                                    INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
                                    INNER JOIN (
	                                    SELECT wo.`id_prod_order`,c.`comp_name`,cur.`currency`,wod.`prod_order_wo_det_price` AS unit_price
                                        FROM tb_prod_order_wo wo
                                        INNER JOIN tb_prod_order_wo_det wod ON wod.`id_prod_order_wo`=wo.`id_prod_order_wo`
                                        INNER JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price` AND wo.`is_main_vendor`='1'
                                        INNER JOIN tb_lookup_currency cur ON cur.`id_currency`=ovhp.`id_currency`
                                        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ovhp.`id_comp_contact`
                                        INNER JOIN tb_m_comp c ON c.id_comp=cc.`id_comp`
                                        GROUP BY wo.id_prod_order_wo
                                    )ovh ON ovh.id_prod_order=tb.id_prod_order
                                    WHERE tb.id_prod_order='-1'"
                '
                query_view_edit = "SELECT tb.id_prod_order AS id_report,tb.prod_order_date AS date_created,ovh.comp_name,tb.prod_order_number AS number,dsg.`design_code_import`,dsg.design_code,dsg.`design_display_name`,SUM(det.prod_order_qty) AS qty,ovh.currency,ovh.unit_price,SUM(ovh.unit_price*det.prod_order_qty) AS amount,rmcr.id_report_mark_cancel_report as id_rmcr " & generate_left_join_cancel("column") & " FROM tb_prod_order tb
                                    INNER JOIN tb_prod_order_det det ON det.id_prod_order=tb.id_prod_order
                                    INNER JOIN (
	                                    SELECT wo.`id_prod_order_wo`,wo.`id_prod_order`,SUM(wod.`prod_order_wo_det_qty`*wod.`prod_order_wo_det_price`*IF(wo.`id_currency`=1,1,wo.`prod_order_wo_kurs`)) AS amount FROM tb_prod_order_wo wo
	                                    INNER JOIN tb_prod_order_wo_det wod ON wod.`id_prod_order_wo`=wo.`id_prod_order_wo`
	                                    GROUP BY wo.`id_prod_order`
                                    )wo ON wo.id_prod_order=tb.id_prod_order
                                    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=tb.`id_prod_demand_design`
                                    INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
                                    INNER JOIN (
	                                    SELECT wo.`id_prod_order`,c.`comp_name`,cur.`currency`,wod.`prod_order_wo_det_price` AS unit_price
                                        FROM tb_prod_order_wo wo
                                        INNER JOIN tb_prod_order_wo_det wod ON wod.`id_prod_order_wo`=wo.`id_prod_order_wo`
                                        INNER JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price` AND wo.`is_main_vendor`='1'
                                        INNER JOIN tb_lookup_currency cur ON cur.`id_currency`=ovhp.`id_currency`
                                        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ovhp.`id_comp_contact`
                                        INNER JOIN tb_m_comp c ON c.id_comp=cc.`id_comp`
                                        GROUP BY wo.id_prod_order_wo
                                    )ovh ON ovh.id_prod_order=tb.id_prod_order
                                    INNER JOIN tb_report_mark_cancel_report rmcr ON rmcr.id_report=tb.id_prod_order AND rmcr.id_report_mark_cancel='" & id_report_mark_cancel & "'
                                    " & generate_left_join_cancel("query") & "
                                    GROUP BY tb.id_prod_order"
            ElseIf report_mark_type = "105" Or report_mark_type = "224" Then
                'QC Report/Final CLearance
                'saat pick
                query_view = "SELECT 'no' AS is_check,f." & field_id & " AS `id_report`, f." & field_number & " AS `number`, f." & field_date & " AS `date_created`, po.id_prod_order, po.prod_order_number, ovh.comp_name AS `vendor`,d.design_code AS `code`, d.design_display_name AS `name`, 
                cat.pl_category AS `category`, fd.total_qty
                FROM tb_prod_fc f
                INNER JOIN (
	                SELECT fd.id_prod_fc, SUM(fd.prod_fc_det_qty) AS `total_qty` 
	                FROM tb_prod_fc_det fd
	                INNER JOIN tb_prod_fc f ON f.id_prod_fc = fd.id_prod_fc
	                WHERE f.id_report_status=6
	                GROUP BY fd.id_prod_fc
                ) fd ON fd.id_prod_fc = f.id_prod_fc
                INNER JOIN tb_lookup_pl_category cat ON cat.id_pl_category = f.id_pl_category
                INNER JOIN tb_prod_order po ON po.id_prod_order = f.id_prod_order
                INNER JOIN (
	                SELECT wo.`id_prod_order`,c.`comp_name`,cur.`currency`,wod.`prod_order_wo_det_price` AS unit_price
                    FROM tb_prod_order_wo wo
                    INNER JOIN tb_prod_order_wo_det wod ON wod.`id_prod_order_wo`=wo.`id_prod_order_wo`
                    INNER JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price` AND wo.`is_main_vendor`='1'
                    INNER JOIN tb_lookup_currency cur ON cur.`id_currency`=ovhp.`id_currency`
                    INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ovhp.`id_comp_contact`
                    INNER JOIN tb_m_comp c ON c.id_comp=cc.`id_comp`
                    GROUP BY wo.id_prod_order_wo
                )ovh ON ovh.id_prod_order=po.id_prod_order
                INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
                INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
                WHERE f.id_report_status=6 AND po.is_closing_rec=2 "
                'Left Join(
                ' SELECT pl.id_prod_order, pl.id_pl_category
                '    From tb_pl_prod_order pl
                ' Where pl.id_report_status! = 5
                '    Group By pl.id_prod_order, pl.id_pl_category
                ') pl ON pl.id_prod_order = f.id_prod_order And pl.id_pl_category = f.id_pl_category
                'AND ISNULL(pl.id_prod_order) 
                If Not qb_id_not_include = "" Then 'popup pick setelah ada isi tabelnya
                    query_view += " AND f." & field_id & " NOT IN " & qb_id_not_include
                End If

                'saat blank - edit value pilih rmt
                query_view_blank = "SELECT f." & field_id & " AS `id_report`, f." & field_number & " AS `number`, f." & field_date & " AS `date_created`, 0 as id_prod_order, '' AS prod_order_number, '' AS `vendor`, '' AS `code`, '' AS `name`, 
                '' AS `category`, 0 AS `total_qty`
                FROM tb_prod_fc f
                WHERE f.id_report_status='-1' "

                'saat edit
                query_view_edit = "SELECT rmcr.id_report,f." & field_number & " AS number,f." & field_date & " AS date_created,rmcr.id_report_mark_cancel_report as id_rmcr,
                                po.id_prod_order,po.prod_order_number, ovh.comp_name AS `vendor`,d.design_code AS `code`, d.design_display_name AS `name`, 
                                cat.pl_category AS `category`, fd.total_qty " & generate_left_join_cancel("column") & "
                                FROM tb_report_mark_cancel_report rmcr 
                                INNER JOIN " & table_name & " f ON f." & field_id & "=rmcr.id_report
                                INNER JOIN (
	                                SELECT fd.id_prod_fc, SUM(fd.prod_fc_det_qty) AS `total_qty` 
	                                FROM tb_prod_fc_det fd
	                                INNER JOIN tb_prod_fc f ON f.id_prod_fc = fd.id_prod_fc
	                                WHERE f.id_report_status=6
	                                GROUP BY fd.id_prod_fc
                                ) fd ON fd.id_prod_fc = f.id_prod_fc
                                INNER JOIN tb_lookup_pl_category cat ON cat.id_pl_category = f.id_pl_category
                                INNER JOIN tb_prod_order po ON po.id_prod_order = f.id_prod_order
                                INNER JOIN (
	                                SELECT wo.`id_prod_order`,c.`comp_name`,cur.`currency`,wod.`prod_order_wo_det_price` AS unit_price
                                    FROM tb_prod_order_wo wo
                                    INNER JOIN tb_prod_order_wo_det wod ON wod.`id_prod_order_wo`=wo.`id_prod_order_wo`
                                    INNER JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price` AND wo.`is_main_vendor`='1'
                                    INNER JOIN tb_lookup_currency cur ON cur.`id_currency`=ovhp.`id_currency`
                                    INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ovhp.`id_comp_contact`
                                    INNER JOIN tb_m_comp c ON c.id_comp=cc.`id_comp`
                                    GROUP BY wo.id_prod_order_wo
                                )ovh ON ovh.id_prod_order=po.id_prod_order
                                INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
                                INNER JOIN tb_m_design d ON d.id_design = pdd.id_design 
                                 " & generate_left_join_cancel("query") & "
                                WHERE rmcr.id_report_mark_cancel='" & id_report_mark_cancel & "' "
            Else
                query_view = "SELECT 'no' AS is_check,tb." & field_id & " AS id_report,tb." & field_number & " AS number,tb." & field_date & " AS date_created FROM " & table_name & " tb WHERE tb.id_report_status='6'"
                If Not qb_id_not_include = "" Then 'popup pick setelah ada isi tabelnya
                    query_view += " AND tb." & field_id & " NOT IN " & qb_id_not_include
                End If
                query_view_blank = "SELECT tb. " & field_id & " AS id_report,tb." & field_number & " AS number,tb." & field_date & " AS date_created FROM " & table_name & " tb WHERE tb.id_report_status='-1'"
                query_view_edit = "SELECT rmcr.id_report,tb." & field_number & " AS number,tb." & field_date & " AS date_created,rmcr.id_report_mark_cancel_report as id_rmcr " & generate_left_join_cancel("column") & "
                               FROM tb_report_mark_cancel_report rmcr
                               " & generate_left_join_cancel("query") & "
                               INNER JOIN " & table_name & " tb ON tb." & field_id & "=rmcr.id_report WHERE rmcr.id_report_mark_cancel='" & id_report_mark_cancel & "'"
            End If
            '======= end of query viewing ======
        End If
    End Sub

    Function generate_left_join_cancel(ByVal opt As String)
        Dim val_return As String
        If opt = "query" Then
            Dim query As String = ""
            Dim query_col As String = ""
            '
            If report_mark_type = "x" Then

            Else
                query_col = "SELECT * FROM tb_report_mark_cancel_column WHERE id_report_mark_cancel='" & id_report_mark_cancel & "'"
                Dim data_col As DataTable = execute_query(query_col, -1, True, "", "", "", "")
                If data_col.Rows.Count > 0 Then
                    query = "LEFT JOIN (
                              SELECT
                                col.id_report_mark_cancel_report"
                    For i As Integer = 0 To data_col.Rows.Count - 1
                        query += ",MAX(CASE WHEN id_column = '" & data_col.Rows(i)("id_column").ToString & "' THEN val END) AS '" & data_col.Rows(i)("column_name").ToString & "'"
                    Next

                    query += "FROM (
	                            SELECT c.id_column,c.`id_report_mark_cancel`,c.`column_name`,cv.`id_column_val`,cv.`val`,cv.`id_report_mark_cancel_report` FROM `tb_report_mark_cancel_column_val` cv
	                            INNER JOIN `tb_report_mark_cancel_column` c ON c.`id_column`=cv.`id_column`
	                            WHERE c.`id_report_mark_cancel`='" & id_report_mark_cancel & "'
                              )col
                              GROUP BY col.id_report_mark_cancel_report
                         )col ON col.id_report_mark_cancel_report=rmcr.id_report_mark_cancel_report"
                End If
            End If
            val_return = query
        ElseIf opt = "column" Then
            Dim column As String = ""

            If report_mark_type = "x" Then

            Else
                Dim query_col As String = ""
                query_col = "SELECT * FROM tb_report_mark_cancel_column WHERE id_report_mark_cancel='" & id_report_mark_cancel & "'"
                Dim data_col As DataTable = execute_query(query_col, -1, True, "", "", "", "")
                If data_col.Rows.Count > 0 Then
                    column = ",col.* "
                End If
            End If

            val_return = column
        Else
            val_return = ""
        End If

        Return val_return
    End Function

    Sub apply_gv_style(ByVal gv As DevExpress.XtraGrid.Views.Grid.GridView, ByVal opt As String)
        If report_mark_type = "x" Then
        ElseIf report_mark_type = "13" Then
            If opt = "pick" Then
                gv.Columns("is_check").Caption = "*"
                gv.Columns("is_check").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                gv.Columns("is_check").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                '
                Dim rpce As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                rpce.ValueUnchecked = "no"
                rpce.ValueChecked = "yes"
                '
                gv.Columns("is_check").ColumnEdit = rpce
            End If
            gv.Columns("id_report").Visible = False
            Try
                gv.Columns("id_rmcr").Visible = False
                gv.Columns("id_report_mark_cancel_report").Visible = False
            Catch ex As Exception
            End Try

            gv.Columns("tot_qty").Caption = "Total Qty"
            gv.Columns("tot_qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            gv.Columns("tot_qty").DisplayFormat.FormatString = "{0:n2}"

            gv.Columns("kurs").Caption = "Kurs"
            gv.Columns("kurs").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            gv.Columns("kurs").DisplayFormat.FormatString = "{0:n2}"

            gv.Columns("amount_usd").Caption = "Total Amount"
            gv.Columns("amount_usd").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            gv.Columns("amount_usd").DisplayFormat.FormatString = "{0:n2}"

            gv.Columns("tot_amount").Caption = "Total Amount (Rp)"
            gv.Columns("tot_amount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            gv.Columns("tot_amount").DisplayFormat.FormatString = "{0:n2}"

            gv.Columns("currency").Caption = "Currency"
            gv.Columns("comp_name").Caption = "Vendor"
            gv.Columns("date_created").Caption = "Created Date"
            gv.Columns("date_created").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            gv.Columns("date_created").DisplayFormat.FormatString = "dd MMM yyyy"
            gv.Columns("number").Caption = "Number"

            gv.Columns("id_report").OptionsColumn.AllowEdit = False
            gv.BestFitColumns()
        ElseIf report_mark_type = "139" Or report_mark_type = "202" Then 'PO opex
            If opt = "pick" Then
                gv.Columns("is_check").Caption = "*"
                gv.Columns("is_check").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                gv.Columns("is_check").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                '
                Dim rpce As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                rpce.ValueUnchecked = "no"
                rpce.ValueChecked = "yes"
                '
                gv.Columns("is_check").ColumnEdit = rpce
            End If
            gv.Columns("id_report").Visible = False
            Try
                gv.Columns("id_rmcr").Visible = False
                gv.Columns("id_report_mark_cancel_report").Visible = False
            Catch ex As Exception
            End Try

            gv.Columns("expense_type").Caption = "PO Type"
            gv.Columns("comp_name").Caption = "Vendor"

            gv.Columns("date_created").Caption = "Created Date"
            gv.Columns("date_created").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            gv.Columns("date_created").DisplayFormat.FormatString = "dd MMM yyyy"
            gv.Columns("number").Caption = "Number"

            gv.Columns("id_report").OptionsColumn.AllowEdit = False
            gv.BestFitColumns()
        ElseIf report_mark_type = "22" Then
            If opt = "pick" Then
                gv.Columns("is_check").Caption = "*"
                gv.Columns("is_check").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                gv.Columns("is_check").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                '
                Dim rpce As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                rpce.ValueUnchecked = "no"
                rpce.ValueChecked = "yes"
                '
                gv.Columns("is_check").ColumnEdit = rpce
            End If
            gv.Columns("id_report").Visible = False

            Try
                gv.Columns("id_rmcr").Visible = False
                gv.Columns("id_report_mark_cancel_report").Visible = False
            Catch ex As Exception
            End Try

            gv.Columns("date_created").Caption = "Created Date"
            gv.Columns("date_created").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            gv.Columns("date_created").DisplayFormat.FormatString = "dd MMM yyyy"
            gv.Columns("number").Caption = "Number"
            gv.Columns("qty").Caption = "Quantity"
            gv.Columns("qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            gv.Columns("qty").DisplayFormat.FormatString = "{0:n0}"
            gv.Columns("qty").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gv.Columns("qty").SummaryItem.DisplayFormat = "{0:n0}"
            gv.Columns("currency").Caption = "Currency"
            gv.Columns("unit_price").Caption = "Price"
            gv.Columns("unit_price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            gv.Columns("unit_price").DisplayFormat.FormatString = "{0:n2}"
            gv.Columns("amount").Caption = "Amount"
            gv.Columns("amount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            gv.Columns("amount").DisplayFormat.FormatString = "N2"
            gv.Columns("amount").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gv.Columns("amount").SummaryItem.DisplayFormat = "{0:N2}"
            gv.Columns("comp_name").Caption = "Vendor"
            gv.Columns("design_display_name").Caption = "Style Name"
            gv.Columns("design_code_import").Caption = "Code Import"
            gv.Columns("design_code").Caption = "Code Local"
            gv.Columns("id_report").OptionsColumn.AllowEdit = False
            gv.OptionsView.ShowFooter = True
            '
            gv.AppearancePrint.HeaderPanel.BackColor = Color.LightGray
            gv.AppearancePrint.HeaderPanel.ForeColor = Color.Black
            gv.AppearancePrint.HeaderPanel.Font = New Font("Segoe UI", 7, FontStyle.Bold)

            gv.AppearancePrint.FooterPanel.BackColor = Color.LightGray
            gv.AppearancePrint.FooterPanel.ForeColor = Color.Black
            gv.AppearancePrint.FooterPanel.Font = New Font("Segoe UI", 7, FontStyle.Bold)

            gv.AppearancePrint.Row.Font = New Font("Segoe UI", 7, FontStyle.Regular)

            gv.OptionsPrint.ExpandAllDetails = True
            gv.OptionsPrint.UsePrintStyles = True
            gv.OptionsPrint.PrintDetails = True
            gv.OptionsPrint.PrintFooter = True
            gv.OptionsView.ColumnAutoWidth = False
            '
            gv.BestFitColumns()
        ElseIf report_mark_type = "105" Or report_mark_type = "224" Then
            'final clearance
            If opt = "pick" Then
                gv.Columns("is_check").Caption = "*"
                gv.Columns("is_check").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                gv.Columns("is_check").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                '
                Dim rpce As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                rpce.ValueUnchecked = "no"
                rpce.ValueChecked = "yes"
                '
                gv.Columns("is_check").ColumnEdit = rpce
            End If
            gv.Columns("id_report").Visible = False
            gv.Columns("id_prod_order").Visible = False
            Try
                gv.Columns("id_rmcr").Visible = False
                gv.Columns("id_report_mark_cancel_report").Visible = False
            Catch ex As Exception
            End Try

            gv.Columns("number").Caption = "Number"
            gv.Columns("date_created").Caption = "Created Date"
            gv.Columns("date_created").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            gv.Columns("date_created").DisplayFormat.FormatString = "dd MMM yyyy"
            gv.Columns("total_qty").Caption = "Qty"
            gv.Columns("total_qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            gv.Columns("total_qty").DisplayFormat.FormatString = "{0:n0}"
            gv.Columns("total_qty").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gv.Columns("total_qty").SummaryItem.DisplayFormat = "{0:n0}"
            gv.Columns("prod_order_number").Caption = "FGPO"
            gv.Columns("vendor").Caption = "Vendor"
            gv.Columns("name").Caption = "Style Name"
            gv.Columns("code").Caption = "Code"
            gv.Columns("category").Caption = "Category"
            gv.Columns("id_report").OptionsColumn.AllowEdit = False
            gv.OptionsView.ShowFooter = True
            '
            gv.AppearancePrint.HeaderPanel.BackColor = Color.LightGray
            gv.AppearancePrint.HeaderPanel.ForeColor = Color.Black
            gv.AppearancePrint.HeaderPanel.Font = New Font("Segoe UI", 7, FontStyle.Bold)

            gv.AppearancePrint.FooterPanel.BackColor = Color.LightGray
            gv.AppearancePrint.FooterPanel.ForeColor = Color.Black
            gv.AppearancePrint.FooterPanel.Font = New Font("Segoe UI", 7, FontStyle.Bold)

            gv.AppearancePrint.Row.Font = New Font("Segoe UI", 7, FontStyle.Regular)

            gv.OptionsPrint.ExpandAllDetails = True
            gv.OptionsPrint.UsePrintStyles = True
            gv.OptionsPrint.PrintDetails = True
            gv.OptionsPrint.PrintFooter = True
            gv.OptionsView.ColumnAutoWidth = False
            '
            gv.BestFitColumns()
        Else
            If opt = "pick" Then
                gv.Columns("is_check").Caption = "*"
                gv.Columns("is_check").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                gv.Columns("is_check").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                '
                Dim rpce As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                rpce.ValueUnchecked = "no"
                rpce.ValueChecked = "yes"
                '
                gv.Columns("is_check").ColumnEdit = rpce
            End If
            gv.Columns("id_report").Visible = False
            Try
                gv.Columns("id_rmcr").Visible = False
                gv.Columns("id_report_mark_cancel_report").Visible = False
            Catch ex As Exception
            End Try
            gv.Columns("date_created").Caption = "Created Date"
            gv.Columns("date_created").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            gv.Columns("date_created").DisplayFormat.FormatString = "dd MMM yyyy"
            gv.Columns("number").Caption = "Number"

            gv.Columns("id_report").OptionsColumn.AllowEdit = False
            gv.BestFitColumns()
        End If
    End Sub
End Class
