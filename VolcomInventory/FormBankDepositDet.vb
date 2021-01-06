Imports DevExpress.XtraReports.UI

Public Class FormBankDepositDet
    Public id_deposit As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Public type_rec As String = "1" '1 = invoice
    Public id_list_payout_trans As String = "-1"
    Public id_virtual_acc_trans As String = "-1"
    Public id_payout_zalora As String = "-1"
    Public id_coa_tag As String = "1"
    Public id_coa_type As String = "1"

    '
    Private Sub FormBankDepositDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Sub form_load()
        viewCoaTag()
        viewReportStatus()
        load_receive_from()
        load_pay_from()
        load_store()
        '
        TEPayNumber.Text = "[auto_generate]"
        Dim dt_now As DateTime = getTimeDB()
        DEDateCreated.EditValue = dt_now
        DERecDate.EditValue = dt_now
        TETotal.EditValue = 0.00
        TENeedToPay.EditValue = 0.00
        '
        If id_deposit = "-1" Then 'new
            load_det()
            BtnPrint.Visible = False
            BMark.Visible = False
            BtnSave.Visible = True

            'load header
            SLEStore.EditValue = FormBankDeposit.SLEStoreInvoice.EditValue

            'load detail
            If type_rec = "1" Then
                SLEUnit.Enabled = False
                If FormBankDeposit.XTCPO.SelectedTabPageIndex = 1 Then
                    For i As Integer = 0 To FormBankDeposit.GVInvoiceList.RowCount - 1
                        'id_report,number,total,balance due
                        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                        newRow("id_report") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "id_sales_pos").ToString
                        newRow("id_report_det") = "0"
                        newRow("report_mark_type") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "report_mark_type").ToString
                        newRow("report_mark_type_name") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "report_mark_type_name").ToString
                        newRow("number") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "sales_pos_number").ToString
                        newRow("id_comp") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "id_comp").ToString
                        newRow("id_acc") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "id_acc").ToString
                        newRow("acc_name") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "acc_name").ToString
                        newRow("acc_description") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "acc_description").ToString
                        newRow("comp_number") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "comp_number").ToString
                        newRow("vendor") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "comp_number").ToString
                        newRow("total_rec") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "total_rec")
                        newRow("value") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "total_due")
                        newRow("balance_due") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "total_due")
                        newRow("note") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "note").ToString
                        newRow("id_dc") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "id_dc").ToString
                        newRow("dc_code") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "dc_code").ToString
                        newRow("value_view") = Math.Abs(FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "total_due"))
                        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                    Next
                ElseIf FormBankDeposit.XTCPO.SelectedTabPageIndex = 2 Then
                    Dim query_view_payout As String = "SELECT sp.`id_sales_pos` AS `id_report`,0 AS `id_report_det`,
                    sp.report_mark_type,rmt.report_mark_type_name,
                    sp.`sales_pos_number` AS `number`, 
                    c.id_comp AS `id_comp`, 
                    sp.id_acc_ar AS `id_acc`, coa.acc_name, coa.acc_description,
                    c.comp_number AS `comp_number`,c.`comp_number` AS `vendor`
                    ,IFNULL(pyd.`value`,0.00) AS total_rec,
                    CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))-IFNULL(pyd.`value`,0.00) AS `value`,
                    CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))-IFNULL(pyd.`value`,0.00) AS `balance_due`,
                    CONCAT(c.comp_name,' Per ', DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y')) AS `note`,IF(typ.`is_receive_payment`=2,1,2) AS `id_dc`, IF(typ.`is_receive_payment`=2,'D','K') AS `dc_code`,
                    ABS((SELECT balance_due)) AS `value_view`
                    FROM tb_list_payout_det d
                    INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = d.id_sales_pos
                    INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
                    INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
                    INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
                    INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
                    INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
                    LEFT JOIN (
                      SELECT pyd.id_report, pyd.report_mark_type, 
                      COUNT(IF(py.id_report_status!=5 AND py.id_report_status!=6,py.id_rec_payment,NULL)) AS `total_pending`,
                      SUM(pyd.value) AS  `value`
                      FROM tb_rec_payment_det pyd
                      INNER JOIN tb_rec_payment py ON py.`id_rec_payment`=pyd.`id_rec_payment`
                      WHERE py.`id_report_status`!=5
                      GROUP BY pyd.id_report, pyd.report_mark_type
                    ) pyd ON pyd.id_report = sp.id_sales_pos AND pyd.report_mark_type = sp.report_mark_type
                    LEFT JOIN tb_a_acc coa ON coa.id_acc = sp.id_acc_ar
                    INNER JOIN tb_m_comp cf ON cf.id_comp=1
                    WHERE d.id_list_payout_trans=" + id_list_payout_trans + " 
                    UNION
                    SELECT sp.id_invoice_ship AS `id_report`,0 AS `id_report_det`,
                    sp.report_mark_type,rmt.report_mark_type_name,
                    sp.`number` AS `number`, 
                    c.id_comp AS `id_comp`, 
                    sp.id_acc_ar AS `id_acc`, coa.acc_name, coa.acc_description,
                    c.comp_number AS `comp_number`,c.`comp_number` AS `vendor`
                    ,IFNULL(pyd.`value`,0.00) AS total_rec,
                    sp.`value`-IFNULL(pyd.`value`,0.00) AS `value`,
                    sp.value-IFNULL(pyd.`value`,0.00) AS `balance_due`,
                    CONCAT(c.comp_name,' Per ', DATE_FORMAT(sp.start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.end_period,'%d-%m-%y')) AS `note`,2 AS `id_dc`, 'K' AS `dc_code`,
                    ABS((SELECT balance_due)) AS `value_view`
                    FROM tb_list_payout_det d
                    INNER JOIN tb_invoice_ship sp ON sp.id_invoice_ship = d.id_invoice_ship
                    INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= sp.id_comp_contact
                    INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
                    INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
                    INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
                    LEFT JOIN (
                     SELECT pyd.id_report, pyd.report_mark_type, 
                     COUNT(IF(py.id_report_status!=5 AND py.id_report_status!=6,py.id_rec_payment,NULL)) AS `total_pending`,
                     SUM(pyd.value) AS  `value`
                     FROM tb_rec_payment_det pyd
                     INNER JOIN tb_rec_payment py ON py.`id_rec_payment`=pyd.`id_rec_payment`
                     WHERE py.`id_report_status`!=5
                     GROUP BY pyd.id_report, pyd.report_mark_type
                    ) pyd ON pyd.id_report = sp.id_invoice_ship AND pyd.report_mark_type = sp.report_mark_type
                    LEFT JOIN tb_a_acc coa ON coa.id_acc = sp.id_acc_ar
                    INNER JOIN tb_m_comp cf ON cf.id_comp=1
                    WHERE d.id_list_payout_trans=" + id_list_payout_trans + " 
                    UNION
                    SELECT '0' AS `id_report`,0 AS `id_report_det`,
                    '0' AS report_mark_type,'' AS report_mark_type_name,
                    '" + FormBankDeposit.GVPayout.GetFocusedRowCellValue("number").ToString + "' AS `number`, 
                    cf.id_comp AS `id_comp`, 
                    coa.id_acc AS `id_acc`, coa.acc_name, coa.acc_description,
                    cf.comp_number AS `comp_number`,'' AS `vendor`
                    ,0 AS total_rec,
                    SUM(p.trans_fee)*-1 AS `value`,
                    SUM(p.trans_fee)*-1 AS `balance_due`,
                    a.note_payout_fee AS `note`,'1' AS `id_dc`, 'D' AS `dc_code`,
                    SUM(p.trans_fee) AS `value_view`
                    FROM tb_list_payout p 
                    INNER JOIN tb_m_comp cf ON cf.id_comp=1
                    JOIN tb_opt_accounting a 
                    INNER JOIN tb_a_acc coa ON coa.id_acc = a.id_acc_payout_fee
                    WHERE p.id_list_payout_trans='" + id_list_payout_trans + "'
                    GROUP BY p.id_list_payout_trans 
                    UNION 
                    /*other income & expense*/
                    (SELECT 
                    v.id_list_payout_ver AS `id_report`,0 AS `id_report_det`,
                    rmt.`report_mark_type`, rmt.`report_mark_type_name`,v.`number`,
                    cf.id_comp AS `id_comp`, 
                    coa.id_acc AS `id_acc`, coa.acc_name, coa.acc_description,
                    cf.comp_number AS `comp_number`,'' AS `vendor`, 0 AS `total_rec`,
                    SUM(vd.value)*IF(vd.id_dc=1,-1,1) AS `value`,
                    SUM(vd.value)*IF(vd.id_dc=1,-1,1) AS `balance_due`,
                    CONCAT(coa.acc_description,' (Order No : ',v.order_number,')') AS `note`, vd.id_dc AS `id_dc`, dc.dc_code AS `dc_code`,
                    SUM(vd.value) AS `value_view` 
                    FROM  tb_list_payout_trans p 
                    INNER JOIN tb_m_comp cf ON cf.id_comp=1
                    JOIN tb_opt_accounting a 
                    INNER JOIN tb_list_payout_det pd ON pd.id_list_payout_trans = p.id_list_payout_trans 
                    INNER JOIN tb_list_payout_ver v ON v.id_list_payout_ver = pd.id_list_payout_ver
                    INNER JOIN tb_list_payout_ver_det vd ON vd.id_list_payout_ver = v.id_list_payout_ver 
                    INNER JOIN tb_a_acc coa ON coa.id_acc = vd.id_acc
                    INNER JOIN tb_lookup_dc dc ON dc.id_dc = vd.id_dc
                    JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=264
                    WHERE p.id_list_payout_trans='" + id_list_payout_trans + "' 
                    GROUP BY v.order_number, vd.id_list_payout_ver_det
                    ORDER BY v.order_number ASC, id_dc ASC) "
                    Dim data_view_payout As DataTable = execute_query(query_view_payout, -1, True, "", "", "", "")
                    GCList.DataSource = data_view_payout
                    GVList.OptionsBehavior.ReadOnly = True
                    'id bank
                    SLEPayRecTo.EditValue = execute_query("SELECT a.id_acc_bank_ol_store FROM tb_opt_accounting a", 0, True, "", "", "", "")
                    'note
                    MENote.Text = "Payout No : " + FormBankDeposit.GVPayout.GetFocusedRowCellValue("number").ToString
                ElseIf FormBankDeposit.XTCPO.SelectedTabPageIndex = 3 Then
                    Dim query_view_trans As String = "SELECT sp.`id_sales_pos` AS `id_report`,0 AS `id_report_det`,
                    sp.report_mark_type,rmt.report_mark_type_name,
                    sp.`sales_pos_number` AS `number`, 
                    c.id_comp AS `id_comp`, 
                    sp.id_acc_ar AS `id_acc`, coa.acc_name, coa.acc_description,
                    c.comp_number AS `comp_number`,c.`comp_number` AS `vendor`
                    ,IFNULL(pyd.`value`,0.00) AS total_rec,
                    CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))-IFNULL(pyd.`value`,0.00) AS `value`,
                    CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))-IFNULL(pyd.`value`,0.00) AS `balance_due`,
                    CONCAT(c.comp_name,' Per ', DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y')) AS `note`,IF(typ.`is_receive_payment`=2,1,2) AS `id_dc`, IF(typ.`is_receive_payment`=2,'D','K') AS `dc_code`,
                    ABS((SELECT balance_due)) AS `value_view`
                    FROM tb_virtual_acc_trans_inv d
                    INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = d.id_sales_pos
                    INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
                    INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
                    INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
                    INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
                    INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
                    LEFT JOIN (
                     SELECT pyd.id_report, pyd.report_mark_type, 
                     COUNT(IF(py.id_report_status!=5 AND py.id_report_status!=6,py.id_rec_payment,NULL)) AS `total_pending`,
                     SUM(pyd.value) AS  `value`
                     FROM tb_rec_payment_det pyd
                     INNER JOIN tb_rec_payment py ON py.`id_rec_payment`=pyd.`id_rec_payment`
                     WHERE py.`id_report_status`!=5
                     GROUP BY pyd.id_report, pyd.report_mark_type
                    ) pyd ON pyd.id_report = sp.id_sales_pos AND pyd.report_mark_type = sp.report_mark_type
                    LEFT JOIN tb_a_acc coa ON coa.id_acc = sp.id_acc_ar
                    INNER JOIN tb_m_comp cf ON cf.id_comp=1
                    WHERE d.id_virtual_acc_trans=" + id_virtual_acc_trans + "
                    UNION
                    SELECT sp.id_invoice_ship AS `id_report`,0 AS `id_report_det`,
                    sp.report_mark_type,rmt.report_mark_type_name,
                    sp.`number` AS `number`, 
                    c.id_comp AS `id_comp`, 
                    sp.id_acc_ar AS `id_acc`, coa.acc_name, coa.acc_description,
                    c.comp_number AS `comp_number`,c.`comp_number` AS `vendor`
                    ,IFNULL(pyd.`value`,0.00) AS total_rec,
                    sp.`value`-IFNULL(pyd.`value`,0.00) AS `value`,
                    sp.value-IFNULL(pyd.`value`,0.00) AS `balance_due`,
                    CONCAT(c.comp_name,' Per ', DATE_FORMAT(sp.start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.end_period,'%d-%m-%y')) AS `note`,2 AS `id_dc`, 'K' AS `dc_code`,
                    ABS((SELECT balance_due)) AS `value_view`
                    FROM tb_virtual_acc_trans_inv d
                    INNER JOIN tb_invoice_ship sp ON sp.id_invoice_ship = d.id_invoice_ship
                    INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= sp.id_comp_contact
                    INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
                    INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
                    INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
                    LEFT JOIN (
                    SELECT pyd.id_report, pyd.report_mark_type, 
                    COUNT(IF(py.id_report_status!=5 AND py.id_report_status!=6,py.id_rec_payment,NULL)) AS `total_pending`,
                    SUM(pyd.value) AS  `value`
                    FROM tb_rec_payment_det pyd
                    INNER JOIN tb_rec_payment py ON py.`id_rec_payment`=pyd.`id_rec_payment`
                    WHERE py.`id_report_status`!=5
                    GROUP BY pyd.id_report, pyd.report_mark_type
                    ) pyd ON pyd.id_report = sp.id_invoice_ship AND pyd.report_mark_type = sp.report_mark_type
                    LEFT JOIN tb_a_acc coa ON coa.id_acc = sp.id_acc_ar
                    INNER JOIN tb_m_comp cf ON cf.id_comp=1
                    WHERE d.id_virtual_acc_trans=" + id_virtual_acc_trans + " 
                    UNION
                    /*trans fee*/
                    SELECT '0' AS `id_report`,0 AS `id_report_det`,
                    '0' AS report_mark_type,'' AS report_mark_type_name,
                    '' AS `number`, 
                    cf.id_comp AS `id_comp`, 
                    coa.id_acc AS `id_acc`, coa.acc_name, coa.acc_description,
                    cf.comp_number AS `comp_number`,'' AS `vendor`
                    ,0 AS total_rec,
                    SUM(p.transaction_fee)*-1 AS `value`,
                    SUM(p.transaction_fee)*-1 AS `balance_due`,
                    a.note_payout_fee AS `note`,'1' AS `id_dc`, 'D' AS `dc_code`,
                    SUM(p.transaction_fee) AS `value_view`
                    FROM tb_virtual_acc_trans_det p 
                    INNER JOIN tb_m_comp cf ON cf.id_comp=1
                    JOIN tb_opt_accounting a 
                    INNER JOIN tb_a_acc coa ON coa.id_acc = a.id_acc_payout_fee
                    WHERE p.id_virtual_acc_trans='" + id_virtual_acc_trans + "' AND p.transaction_fee>0
                    GROUP BY p.id_virtual_acc_trans 
                    UNION
                    /*other income & expense*/
                    (SELECT 
                    v.id_list_payout_ver AS `id_report`,0 AS `id_report_det`,
                    rmt.report_mark_type AS `report_mark_type`, rmt.report_mark_type_name AS `report_mark_type_name`,v.number AS `number`,
                    cf.id_comp AS `id_comp`, 
                    coa.id_acc AS `id_acc`, coa.acc_name, coa.acc_description,
                    cf.comp_number AS `comp_number`,'' AS `vendor`, 0 AS `total_rec`,
                    SUM(vd.value)*IF(vd.id_dc=1,-1,1) AS `value`,
                    SUM(vd.value)*IF(vd.id_dc=1,-1,1) AS `balance_due`,
                    CONCAT(coa.acc_description,' (Order No : ',v.order_number,')') AS `note`, vd.id_dc AS `id_dc`, dc.dc_code AS `dc_code`,
                    SUM(vd.value) AS `value_view` 
                    FROM  tb_virtual_acc_trans p 
                    INNER JOIN tb_m_comp cf ON cf.id_comp=1
                    JOIN tb_opt_accounting a 
                    INNER JOIN tb_virtual_acc_trans_inv pd ON pd.id_virtual_acc_trans = p.id_virtual_acc_trans 
                    INNER JOIN tb_list_payout_ver v ON v.id_list_payout_ver = pd.id_list_payout_ver
                    INNER JOIN tb_list_payout_ver_det vd ON vd.id_list_payout_ver = v.id_list_payout_ver 
                    INNER JOIN tb_a_acc coa ON coa.id_acc = vd.id_acc
                    INNER JOIN tb_lookup_dc dc ON dc.id_dc = vd.id_dc
                    JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=265
                    WHERE p.id_virtual_acc_trans='" + id_virtual_acc_trans + "' 
                    GROUP BY v.order_number, vd.id_list_payout_ver_det
                    ORDER BY v.order_number ASC, id_dc ASC) "
                    Dim data_view_trans As DataTable = execute_query(query_view_trans, -1, True, "", "", "", "")
                    GCList.DataSource = data_view_trans
                    GVList.OptionsBehavior.ReadOnly = True
                    'id bank
                    SLEPayRecTo.EditValue = execute_query("SELECT a.id_acc_bank_ol_store FROM tb_opt_accounting a", 0, True, "", "", "", "")
                    'note
                    Dim qv As String = "SELECT b.bank, DATE_FORMAT(a.transaction_date, '%d %M %Y') AS `trans_date_view`, a.transaction_date AS `trans_date`
                    FROM tb_virtual_acc_trans a 
                    INNER JOIN tb_virtual_acc b ON b.id_virtual_acc = a.id_virtual_acc WHERE a.id_virtual_acc_trans=" + id_virtual_acc_trans + " "
                    Dim dv As DataTable = execute_query(qv, -1, True, "", "", "", "")
                    MENote.Text = "Virtual Acc " + dv.Rows(0)("bank").ToString + " : " + dv.Rows(0)("trans_date_view").ToString
                    DERecDate.EditValue = dv.Rows(0)("trans_date")
                ElseIf FormBankDeposit.XTCPO.SelectedTabPageIndex = 5 Then
                    'zalora payout
                    Dim pz As New ClassPayoutZalora()
                    Dim data As DataTable = pz.viewERPPayout(id_payout_zalora)
                    For i As Integer = 0 To data.Rows.Count - 1
                        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                        newRow("id_report") = data.Rows(i)("id_ref").ToString
                        newRow("id_report_det") = "0"
                        newRow("report_mark_type") = data.Rows(i)("rmt_ref").ToString
                        newRow("report_mark_type_name") = data.Rows(i)("rmt_name_ref").ToString
                        newRow("number") = data.Rows(i)("ref").ToString
                        newRow("id_comp") = data.Rows(i)("id_comp").ToString
                        newRow("id_acc") = data.Rows(i)("id_acc").ToString
                        newRow("acc_name") = data.Rows(i)("acc_name").ToString
                        newRow("acc_description") = data.Rows(i)("acc_description").ToString
                        newRow("comp_number") = data.Rows(i)("comp_number").ToString
                        If data.Rows(i)("recon_type").ToString.Contains("Manual") Then
                            newRow("vendor") = "Zalora"
                        Else
                            newRow("vendor") = data.Rows(i)("comp_number").ToString
                        End If
                        newRow("total_rec") = 0
                        newRow("value") = data.Rows(i)("amo")
                        newRow("balance_due") = data.Rows(i)("amo")
                        newRow("note") = data.Rows(i)("name").ToString
                        newRow("id_dc") = If(data.Rows(i)("amo") < 0, "1", "2")
                        newRow("dc_code") = If(data.Rows(i)("amo") < 0, "D", "K")
                        newRow("value_view") = Math.Abs(data.Rows(i)("amo"))
                        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                    Next
                End If
            ElseIf type_rec = "3" Then
                SLEUnit.EditValue = id_coa_tag
                SLEUnit.Enabled = False
                If FormBankDeposit.XTCPO.SelectedTabPageIndex = 4 Then
                    For i As Integer = 0 To FormBankDeposit.GVSales.RowCount - 1
                        'id_report,number,total,balance due
                        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                        newRow("id_report") = FormBankDeposit.GVSales.GetRowCellValue(i, "id_report").ToString
                        newRow("id_report_det") = FormBankDeposit.GVSales.GetRowCellValue(i, "id_report_det").ToString
                        newRow("report_mark_type") = FormBankDeposit.GVSales.GetRowCellValue(i, "report_mark_type").ToString
                        newRow("report_mark_type_name") = FormBankDeposit.GVSales.GetRowCellValue(i, "report_mark_type_name").ToString
                        newRow("number") = FormBankDeposit.GVSales.GetRowCellValue(i, "report_number").ToString
                        newRow("id_comp") = FormBankDeposit.GVSales.GetRowCellValue(i, "id_comp").ToString
                        newRow("id_acc") = FormBankDeposit.GVSales.GetRowCellValue(i, "id_acc").ToString
                        newRow("acc_name") = FormBankDeposit.GVSales.GetRowCellValue(i, "acc_name").ToString
                        newRow("acc_description") = FormBankDeposit.GVSales.GetRowCellValue(i, "acc_description").ToString
                        newRow("comp_number") = FormBankDeposit.GVSales.GetRowCellValue(i, "comp_number").ToString
                        newRow("vendor") = FormBankDeposit.GVSales.GetRowCellValue(i, "vendor").ToString
                        newRow("total_rec") = FormBankDeposit.GVSales.GetRowCellValue(i, "total_rec")
                        newRow("value") = FormBankDeposit.GVSales.GetRowCellValue(i, "total_due")
                        newRow("balance_due") = FormBankDeposit.GVSales.GetRowCellValue(i, "total_due")
                        newRow("note") = FormBankDeposit.GVSales.GetRowCellValue(i, "note").ToString
                        newRow("id_dc") = FormBankDeposit.GVSales.GetRowCellValue(i, "id_dc").ToString
                        newRow("dc_code") = FormBankDeposit.GVSales.GetRowCellValue(i, "dc_code").ToString
                        newRow("value_view") = Math.Abs(FormBankDeposit.GVSales.GetRowCellValue(i, "total_due"))
                        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                    Next
                End If
            End If
            calculate_amount()
        Else
            PanelControlNav.Visible = False
            BtnPrint.Visible = True
            BMark.Visible = True
            BtnSave.Visible = False
            SLEUnit.Enabled = False
            SLEPayFrom.Enabled = False
            SLEPayRecTo.Enabled = False
            MENote.Enabled = False
            PanelControlPreview.Visible = True
            '
            Dim query As String = "SELECT * FROM tb_rec_payment WHERE id_rec_payment='" & id_deposit & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TEPayNumber.Text = data.Rows(0)("number").ToString
                SLEStore.EditValue = data.Rows(0)("id_comp_contact").ToString
                '
                If data.Rows(0)("id_report_status").ToString = "6" Then
                    BtnViewJournal.Visible = True
                Else
                    BtnViewJournal.Visible = False
                End If
                '
                DEDateCreated.EditValue = data.Rows(0)("date_created")
                DERecDate.EditValue = data.Rows(0)("date_received")
                SLEPayRecTo.EditValue = data.Rows(0)("id_acc_pay_rec").ToString
                '
                SLEPayFrom.EditValue = data.Rows(0)("id_acc_pay_to").ToString
                TENeedToPay.EditValue = data.Rows(0)("val_need_pay")
                '
                MENote.EditValue = data.Rows(0)("note").ToString
                id_report_status = data.Rows(0)("id_report_status").ToString
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
                type_rec = data.Rows(0)("type_rec").ToString
                id_coa_tag = data.Rows(0)("id_coa_tag").ToString
                SLEUnit.EditValue = id_coa_tag
            End If
            '
            load_det()
            PanelControlNav.Visible = False
            DERecDate.Properties.ReadOnly = True
            GridColumnAlreadyReceived.Visible = False
            GridColumnBBaldue.Visible = False
            GridColumnReceive.OptionsColumn.AllowEdit = False
            GridColumnNote.OptionsColumn.AllowEdit = False
            If id_report_status = "6" Then
                XTPDraft.PageVisible = False
            End If
            calculate_amount()
        End If
    End Sub

    Private Sub GVList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVList.CellValueChanged
        If e.Column.FieldName.ToString = "value" Then
            'set value
            calculate_amount()
        ElseIf e.Column.FieldName.ToString = "value_view" Then
            Dim rh As Integer = e.RowHandle
            Dim val As Decimal = 0
            Dim id_dc As String = GVList.GetRowCellValue(rh, "id_dc").ToString
            If id_dc = "1" Then 'debit
                val = e.Value * -1
            Else
                val = e.Value
            End If
            GVList.SetRowCellValue(rh, "value", val)
        End If
    End Sub

    Sub viewCoaTag()
        Dim query As String = "SELECT ct.id_coa_tag, ct.tag_code, ct.tag_description, CONCAT(ct.tag_code,' - ', ct.tag_description)  AS `coa_tag`
        FROM tb_coa_tag ct ORDER BY ct.id_coa_tag ASC "
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub load_det()
        Dim query As String = "SELECT recd.id_rec_payment_det,recd.id_report,recd.report_mark_type, recd.id_report_det,
        rmt.report_mark_type_name,recd.number,recd.total_rec,recd.`value`,recd.balance_due,recd.note,
        if(recd.id_dc=1, recd.`value`*-1, recd.`value`) AS `value_view`,
        recd.id_comp, c.comp_number, c.comp_name, recd.id_acc, coa.acc_name, coa.acc_description, coa.acc_description, 
        recd.id_dc,dc.dc_code, recd.vendor
        FROM tb_rec_payment_det recd 
        LEFT JOIN tb_lookup_report_mark_type rmt ON rmt.`report_mark_type`=recd.report_mark_type
        LEFT JOIN tb_m_comp c ON c.id_comp = recd.id_comp
        INNER JOIN tb_a_acc coa ON coa.id_acc = recd.id_acc
        INNER JOIN tb_lookup_dc dc ON dc.id_dc = recd.id_dc
        WHERE recd.id_rec_payment='" & id_deposit & "' ORDER BY recd.id_rec_payment_det ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        GVList.BestFitColumns()
    End Sub

    Sub viewBlankJournal()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `no`, '' AS acc_name, '' AS acc_description, '' AS `cc`, '' AS report_number, '' AS note, 0.00 AS `debit`, 0.00 AS `credit` "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDraft.DataSource = data
        GVDraft.DeleteSelectedRows()
        GVDraft.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDraftJournal()
        Cursor = Cursors.WaitCursor
        If GVList.RowCount > 0 Then
            makeSafeGV(GVList)
            Dim jum_row As Integer = 0

            'header
            Dim cc_draft As String = ""
            If SLEUnit.EditValue.ToString = "1" Then
                cc_draft = "000"
            Else
                Dim query_draft As String = "SELECT c.comp_number 
                FROM tb_coa_tag t
                INNER JOIN tb_m_comp c ON c.id_comp = t.id_comp
                WHERE t.id_coa_tag='" + SLEUnit.EditValue.ToString + "' "
                cc_draft = execute_query(query_draft, 0, True, "", "", "", "")
            End If
            jum_row += 1
            Dim qh As String = "SELECT * FROM tb_a_acc WHERE id_acc='" + SLEPayRecTo.EditValue.ToString + "' "
            Dim dh As DataTable = execute_query(qh, -1, True, "", "", "", "")
            Dim newRowh As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
            newRowh("no") = jum_row
            newRowh("acc_name") = dh.Rows(0)("acc_name").ToString
            newRowh("acc_description") = dh.Rows(0)("acc_description").ToString
            newRowh("cc") = cc_draft
            newRowh("report_number") = ""
            newRowh("note") = MENote.Text
            newRowh("debit") = TETotal.EditValue
            newRowh("credit") = 0
            TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowh)
            GCDraft.RefreshDataSource()
            GVDraft.RefreshData()

            'detil
            For i As Integer = 0 To GVList.RowCount - 1
                jum_row += 1
                Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                newRow("no") = jum_row
                newRow("acc_name") = GVList.GetRowCellValue(i, "acc_name").ToString
                newRow("acc_description") = GVList.GetRowCellValue(i, "acc_description").ToString
                newRow("cc") = GVList.GetRowCellValue(i, "comp_number").ToString
                newRow("report_number") = GVList.GetRowCellValue(i, "number").ToString
                newRow("note") = GVList.GetRowCellValue(i, "note").ToString
                If GVList.GetRowCellValue(i, "id_dc").ToString = "1" Then
                    newRow("debit") = Math.Abs(GVList.GetRowCellValue(i, "value"))
                    newRow("credit") = 0
                Else
                    newRow("debit") = 0
                    newRow("credit") = GVList.GetRowCellValue(i, "value")
                End If
                TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                GCDraft.RefreshDataSource()
                GVDraft.RefreshData()
            Next
            GVDraft.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub load_receive_from()
        Dim id_unit As String = "-1"
        Try
            id_unit = SLEUnit.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2' "
        If id_deposit = "-1" Then
            If id_unit <> "1" Then
                query += "AND id_coa_type='2' "
            Else
                query += "AND id_coa_type='1' "
            End If
        End If
        viewSearchLookupQuery(SLEPayRecTo, query, "id_acc", "acc_description", "id_acc")
    End Sub
    '
    Sub load_pay_from()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2' "
        If id_deposit = "-1" Then
            query += "AND id_coa_type='" + id_coa_type + "' "
        End If
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
    End Sub
    '
    Sub calculate_amount()
        GVList.RefreshData()
        Dim gross_total As Double = 0.0
        Try
            gross_total = Double.Parse(GVList.Columns("value").SummaryItem.SummaryValue.ToString)
        Catch ex As Exception
        End Try
        '
        If gross_total >= 0 Then
            LPayFrom.Visible = False
            LNeedToPay.Visible = False
            '
            SLEPayFrom.Visible = False
            TENeedToPay.Visible = False
            '
            TENeedToPay.EditValue = 0.00
            TETotal.EditValue = gross_total
        Else
            'sementara blm dipake
            'LPayFrom.Visible = True
            'LNeedToPay.Visible = True
            ''
            'SLEPayFrom.Visible = True
            'TENeedToPay.Visible = True
            ''
            'TETotal.EditValue = 0.00
            'TENeedToPay.EditValue = -gross_total
        End If
        '
        GVList.BestFitColumns()
    End Sub

    Sub load_store()
        'Dim query As String = "SELECT cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name 
        '                        FROM tb_m_comp c
        '                        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'"
        'viewSearchLookupQuery(SLEStore, query, "id_comp_contact", "comp_name", "id_comp_contact")
    End Sub

    Private Sub FormBankDepositDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        makeSafeGV(GVList)
        GCList.RefreshDataSource()
        GVList.RefreshData()
        calculate_amount()

        Dim query As String = ""
        'check first
        'more than value
        Dim value_exceed As Boolean = False
        For i As Integer = 0 To GVList.RowCount - 1
            If GVList.GetRowCellValue(i, "balance_due") < 0 Then 'need minus not exceed 0
                If GVList.GetRowCellValue(i, "value") > 0 Or GVList.GetRowCellValue(i, "value") < GVList.GetRowCellValue(i, "balance_due") Then
                    value_exceed = True
                End If
            Else 'normal
                If GVList.GetRowCellValue(i, "value") < 0 Or GVList.GetRowCellValue(i, "value") > GVList.GetRowCellValue(i, "balance_due") Then
                    value_exceed = True
                End If
            End If
        Next
        '

        'cek balance journal
        Dim cond_bal As Boolean = True
        XTCBBM.SelectedTabPageIndex = 1
        makeSafeGV(GVDraft)
        If GVDraft.Columns("debit").SummaryItem.SummaryValue = GVDraft.Columns("credit").SummaryItem.SummaryValue Then
            cond_bal = True
            XTCBBM.SelectedTabPageIndex = 0
        Else
            cond_bal = False
        End If

        If TETotal.EditValue = 0 And TENeedToPay.EditValue = 0 Then
            warningCustom("Please make sure amount is not 0")
        ElseIf value_exceed = True Then
            warningCustom("Please make sure amount credit note is not exceed 0, received amount not below 0, and not exceed balance due")
        ElseIf Not cond_bal Then
            warningCustom("Journal not balance please check your input")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim date_received As String = DateTime.Parse(DERecDate.EditValue.ToString).ToString("yyyy-MM-dd")
                If id_deposit = "-1" Then 'new
                    Dim id_comp_contact As String = "NULL"
                    'if there is need to pay
                    Dim need_to_pay_amount As String = "0.00"
                    Dim need_to_pay_account As String = "NULL"
                    If TENeedToPay.EditValue > 0 Then
                        need_to_pay_amount = decimalSQL(TENeedToPay.EditValue.ToString)
                        need_to_pay_account = SLEPayFrom.EditValue.ToString
                    End If
                    If id_list_payout_trans = "-1" Then
                        id_list_payout_trans = "NULL"
                    End If
                    If id_virtual_acc_trans = "-1" Then
                        id_virtual_acc_trans = "NULL"
                    End If
                    If id_payout_zalora = "-1" Then
                        id_payout_zalora = "NULL"
                    End If

                    query = "INSERT INTO tb_rec_payment(`id_acc_pay_rec`,`id_comp_contact`,`id_user_created`,`date_created`, `date_received`,`value`,`note`,`val_need_pay`,`id_acc_pay_to`,`id_report_status`, type_rec, id_list_payout_trans, id_virtual_acc_trans, id_coa_tag, id_payout_zalora)
                    VALUES ('" & SLEPayRecTo.EditValue.ToString & "'," + id_comp_contact + ",'" & id_user & "',NOW(),'" + date_received + "','" & decimalSQL(TETotal.EditValue.ToString) & "','" & addSlashes(MENote.Text) & "','" & need_to_pay_amount & "'," & need_to_pay_account & ",'1', '" + type_rec + "', " + id_list_payout_trans + ", " + id_virtual_acc_trans + ",'" + SLEUnit.EditValue.ToString + "'," + id_payout_zalora + "); SELECT LAST_INSERT_ID();"
                    id_deposit = execute_query(query, 0, True, "", "", "", "")

                    'detail
                    query = "INSERT INTO tb_rec_payment_det(`id_rec_payment`,`id_report`,`report_mark_type`,`number`,`total_rec`,`value`,`balance_due`,`note`, id_comp, id_acc, id_dc, vendor, id_report_det) VALUES"
                    For i As Integer = 0 To GVList.RowCount - 1
                        Dim id_report As String = GVList.GetRowCellValue(i, "id_report").ToString
                        If id_report = "0" Then
                            id_report = "NULL"
                        End If
                        Dim id_report_det As String = GVList.GetRowCellValue(i, "id_report_det").ToString
                        If id_report_det = "0" Then
                            id_report_det = "NULL"
                        End If
                        Dim report_mark_type As String = GVList.GetRowCellValue(i, "report_mark_type").ToString
                        If report_mark_type = "0" Then
                            report_mark_type = "NULL"
                        End If
                        Dim id_comp As String = GVList.GetRowCellValue(i, "id_comp").ToString
                        If id_comp = "0" Then
                            id_comp = "NULL"
                        End If
                        Dim id_acc As String = GVList.GetRowCellValue(i, "id_acc").ToString
                        Dim id_dc As String = GVList.GetRowCellValue(i, "id_dc").ToString
                        Dim vendor As String = GVList.GetRowCellValue(i, "vendor").ToString

                        If Not i = 0 Then
                            query += ","
                        End If
                        query += "('" & id_deposit & "'," + id_report + "," + report_mark_type + ",'" & GVList.GetRowCellValue(i, "number").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "total_rec").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "value").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "balance_due").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "', " + id_comp + ", " + id_acc + ", " + id_dc + ", '" + vendor + "', " + id_report_det + ") "
                    Next
                    execute_non_query(query, True, "", "", "", "")

                    'generate number
                    query = "CALL gen_number('" & id_deposit & "','162')"
                    execute_non_query(query, True, "", "", "", "")
                    'add mark
                    submit_who_prepared("162", id_deposit, id_user)
                    'done
                    infoCustom("Receive Payment created. Waiting for approval")
                    'FormBankDeposit.load_invoice()
                    'FormBankDeposit.SLEStoreDeposit.EditValue = SLEStore.EditValue
                    FormBankDeposit.GCInvoiceList.DataSource = Nothing
                    FormBankDeposit.load_deposit()
                    If id_list_payout_trans <> "-1" Then
                        FormBankDeposit.load_payout()
                    End If
                    If id_virtual_acc_trans <> "-1" Then
                        FormBankDeposit.load_vacc()
                    End If
                    If id_payout_zalora <> "-1" Then
                        FormBankDeposit.view_zalora_payout()
                    End If
                    FormBankDeposit.GVList.FocusedRowHandle = find_row(FormBankDeposit.GVList, "id_rec_payment", id_deposit)
                    FormBankDeposit.XTCPO.SelectedTabPageIndex = 0
                    form_load()
                End If
            End If
        End If
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=162 AND ad.id_report=" + id_deposit + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            FormViewJournal.show_trans_number = True
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "162"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_deposit
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportBankDepositNew.id = id_deposit
        ReportBankDepositNew.id_report_status = id_report_status
        ReportBankDepositNew.rmt = "162"
        Dim Report As New ReportBankDepositNew()

        Report.LabelUnit.Text = SLEUnit.Text
        If CEPrintPreview.EditValue = True Then
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        Else
            Dim instance As New Printing.PrinterSettings
            Dim DefaultPrinter As String = instance.PrinterName

            ' THIS IS TO PRINT THE REPORT
            Report.PrinterName = DefaultPrinter
            Report.CreateDocument()
            Report.PrintingSystem.ShowMarginsWarning = False
            Report.Print()
        End If


        '        ReportBankDeposit.id_deposit = id_deposit
        '        ReportBankDeposit.dt = GCList.DataSource
        '        Dim Report As New ReportBankDeposit()
        '        ' '... 
        '        ' ' creating and saving the view's layout to a new memory stream 
        '        Dim str As System.IO.Stream
        '        str = New System.IO.MemoryStream()
        '        GVList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '        str.Seek(0, System.IO.SeekOrigin.Begin)
        '        Report.GVList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '        str.Seek(0, System.IO.SeekOrigin.Begin)

        '        'Grid Detail
        '        ReportStyleGridview(Report.GVList)

        '        'Parse val
        '        Dim query As String = "SELECT rec_py.id_report_status,acc.`acc_description` AS acc_pay_rec,IFNULL(acc_pay.`acc_description`,'') AS acc_pay_to,rec_py.number,sts.report_status,emp.employee_name AS created_by, rec_py.date_created, FORMAT(rec_py.val_need_pay,2,'id_ID') AS total_need_pay, rec_py.`id_rec_payment`,FORMAT(rec_py.`value`,2,'ID_id') AS total_amount,CONCAT(c.`comp_number`,' - ',c.`comp_name`) AS comp_name,rec_py.note
        'FROM tb_rec_payment rec_py
        'INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=rec_py.`id_comp_contact`
        'INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        'INNER JOIN tb_m_user usr ON usr.id_user=rec_py.id_user_created
        'INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
        'INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=rec_py.id_report_status
        'INNER JOIN tb_a_acc acc ON acc.`id_acc`=rec_py.`id_acc_pay_rec`
        'LEFT JOIN tb_a_acc acc_pay ON acc_pay.`id_acc`=rec_py.`id_acc_pay_to`
        'WHERE rec_py.`id_rec_payment`='" & id_deposit & "'"
        '        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '        '
        '        If Not data.Rows(0)("acc_pay_to").ToString = "" Then
        '            Report.LRecTo.Text = "[acc_pay_to]"
        '            Report.LTotalAmount.Text = "[total_need_pay]"
        '            '
        '            Report.LRecToText.Text = "Pay From"
        '            Report.LTotalAmountText.Text = "Amount"
        '        End If
        '        '
        '        Report.DataSource = data

        '        If Not data.Rows(0)("id_report_status").ToString = "6" Then
        '            Report.id_pre = "2"
        '        Else
        '            Report.id_pre = "1"
        '        End If

        '        'Show the report's preview. 
        '        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        '        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub XTCBBM_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCBBM.SelectedPageChanged
        If XTCBBM.SelectedTabPageIndex = 1 Then
            viewBlankJournal()
            viewDraftJournal()
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If GVList.RowCount > 0 And GVList.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this detail ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVList.DeleteSelectedRows()
                GCList.RefreshDataSource()
                GVList.RefreshData()
                calculate_amount()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub SLEPayFrom_EditValueChanged(sender As Object, e As EventArgs) Handles SLEPayFrom.EditValueChanged

    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If id_deposit = "-1" Then
            Cursor = Cursors.WaitCursor
            FormBankDepositAdd.action = "ins"
            If SLEUnit.EditValue.ToString <> "1" Then
                FormBankDepositAdd.id_coa_type = "2"
            End If
            FormBankDepositAdd.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        If id_deposit = "-1" And GVList.FocusedRowHandle >= 0 Then
            If GVList.GetFocusedRowCellValue("id_report") = "0" Then
                Cursor = Cursors.WaitCursor
                FormBankDepositAdd.action = "upd"
                FormBankDepositAdd.ShowDialog()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub SLEUnit_EditValueChanged(sender As Object, e As EventArgs) Handles SLEUnit.EditValueChanged
        If id_deposit = "-1" Then
            load_receive_from()
            load_det()
        End If
    End Sub
End Class