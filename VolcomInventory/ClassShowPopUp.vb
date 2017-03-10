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
        ElseIf report_mark_type = "28" Then
            'receive FG QC
            FormViewProductionRec.id_receive = id_report
            FormViewProductionRec.ShowDialog()
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
            'Entry Journal
            FormViewJournalAdj.id_trans_adj = id_report
            FormViewJournalAdj.ShowDialog()
        ElseIf report_mark_type = "41" Then
            'FG IN
            FormViewFGAdjIn.id_adj_in_fg = id_report
            FormViewFGAdjIn.ShowDialog()
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
        ElseIf report_mark_type = "49" Then
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
            FormViewFGMissing.id_fg_missing = id_report
            FormViewFGMissing.ShowDialog()
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
            FormViewSalesCreditNote.id_sales_pos = id_report
            FormViewSalesCreditNote.ShowDialog()
        ElseIf report_mark_type = "67" Then
            'MISSING CREDIT NOTE
            FormViewFGMissingCreditNoteStore.id_sales_pos = id_report
            FormViewFGMissingCreditNoteStore.ShowDialog()
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
            FormViewFGProposePrice.id_fg_propose_price = id_report
            FormViewFGProposePrice.ShowDialog()
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
        ElseIf report_mark_type = "80" Then
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
        ElseIf report_mark_type = "91" Then
            'repair FG
            FormViewFGRepair.id_fg_repair = id_report
            FormViewFGRepair.ShowDialog()
        ElseIf report_mark_type = "92" Then
            'repair rec FG
            FormViewFGRepairRec.id_fg_repair_rec = id_report
            FormViewFGRepairRec.ShowDialog()
        ElseIf report_mark_type = "93" Then
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
        ElseIf report_mark_type = "104" Then
            'propose leave HRD
            FormEmpLeaveDet.id_emp_leave = id_report
            FormEmpLeaveDet.report_mark_type = "104"
            FormEmpLeaveDet.is_view = "1"
            FormEmpLeaveDet.ShowDialog()
        ElseIf report_mark_type = "105" Then
            'final clear
            FormProductionFinalClearDet.id_prod_fc = id_report
            FormProductionFinalClearDet.action = "upd"
            FormProductionFinalClearDet.is_view = "1"
            FormProductionFinalClearDet.ShowDialog()
        Else
            'MsgBox(id_report)
            stopCustom("Document Not Found")
        End If
    End Sub
    Sub load_detail()
        Dim query As String = ""
        Dim data As DataTable = Nothing
        Dim field_number, field_date, field_id, table_name As String

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
            table_name = "tb_bom a INNER JOIN tb_m_product b ON a.id_product = b.id_product"
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
        ElseIf report_mark_type = "28" Then
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
            field_date = "acc_trans_date"
        ElseIf report_mark_type = "37" Then
            'REC PL FG TO WH
            table_name = "tb_pl_prod_order_rec"
            field_id = "id_pl_prod_order_rec"
            field_number = "pl_prod_order_rec_number"
            field_date = "pl_prod_order_rec_date"
        ElseIf report_mark_type = "39" Then
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
            field_date = "acc_trans_adj_date"
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
        ElseIf report_mark_type = "45" Then
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
        ElseIf report_mark_type = "49" Then
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
        ElseIf report_mark_type = "91" Then
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
        ElseIf report_mark_type = "93" Then
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
        ElseIf report_mark_type = "95" Then
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
        ElseIf report_mark_type = "104" Then
            'Propose leave
            table_name = "tb_emp_leave"
            field_id = "id_emp_leave"
            field_number = "emp_leave_number"
            field_date = "emp_leave_date"
        ElseIf report_mark_type = "105" Then
            'FINAL CLEARANCE
            table_name = "tb_prod_fc"
            field_id = "id_prod_fc"
            field_number = "prod_fc_number"
            field_date = "prod_fc_date"
        Else
            query = "Select '-' AS report_number, NOW() as report_date"
        End If

        If query = "" Then
            query = "SELECT " + field_number + " AS report_number," + field_date + " AS report_date FROM " + table_name + " WHERE " + field_id + "='" + id_report + "'"
        End If

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
            ElseIf report_mark_type = "37" Then
                'rec wh
                query = "SELECT CONCAT(c.comp_number,' - ', c.comp_name) AS `info` 
                FROM tb_pl_prod_order_rec rec
                INNER JOIN tb_pl_prod_order pl ON pl.id_pl_prod_order = rec.id_pl_prod_order
                INNER JOIN tb_prod_order po ON po.id_prod_order = pl.id_prod_order
                LEFT JOIN tb_prod_order_wo wo ON wo.id_prod_order = po.id_prod_order AND wo.is_main_vendor=1
                LEFT JOIN tb_m_ovh_price op ON op.id_ovh_price = wo.id_ovh_price
                LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact = op.id_comp_contact
                LEFT JOIN tb_m_comp c ON c.id_comp = cc.id_comp 
                WHERE rec.id_pl_prod_order_rec=" + id_report + " "
                info_col = execute_query(query, 0, True, "", "", "", "")
            ElseIf report_mark_type = "43" Then
                'pre delivery
                query = "SELECT CONCAT(c.comp_number,' - ', c.comp_name) AS `info` 
                FROM tb_pl_sales_order_del del
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = del.id_store_contact_to
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp 
                WHERE del.id_pl_sales_order_del=" + id_report + " "
                info_col = execute_query(query, 0, True, "", "", "", "")
            ElseIf report_mark_type = "46" Then
                'return
                query = "SELECT CONCAT(c.comp_number,' - ', c.comp_name) AS `info` FROM tb_sales_return r
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = r.id_store_contact_from
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp WHERE r.id_sales_return=" + id_report + " "
                info_col = execute_query(query, 0, True, "", "", "", "")
            ElseIf report_mark_type = "49" Then
                'return transfer
                query = "SELECT r.sales_return_number AS `info_report`, CONCAT(c.comp_number,' - ', c.comp_name) AS `info_col` 
                FROM tb_sales_return_qc rt
                INNER JOIN tb_sales_return r ON r.id_sales_return = rt.id_sales_return
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = rt.id_store_contact_from
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp 
                WHERE rt.id_sales_return_qc=" + id_report + " "
                Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
                If datax.Rows.Count > 0 Then
                    info_col = datax.Rows(0)("info_col").ToString
                    info_report = datax.Rows(0)("info_report").ToString
                End If
            End If
        End If
    End Sub
End Class
