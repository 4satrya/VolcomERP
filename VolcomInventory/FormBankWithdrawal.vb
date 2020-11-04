Public Class FormBankWithdrawal
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Dim id_pay_type_po As String = "-1"

    Private Sub FormBankWithdrawal_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormBankWithdrawal_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Sub load_currency()
        Dim q As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        viewSearchLookupRepositoryQuery(RISLECurrency, q, 0, "currency", "id_currency")
    End Sub

    Private Sub FormBankWithdrawal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEBBKFrom.EditValue = Now
        DEBBKTo.EditValue = Now
        '
        DEFromSum.EditValue = Now
        DEToSum.EditValue = Now
        '
        TEKurs.EditValue = 1.0
        TEKursDPKhusus.EditValue = 1.0
        '
        load_vendor()
        load_trans_type()
        load_status_payment()
        load_currency()
        '
        load_trans_type_po()
        '
        load_vendor_po()
        load_vendor_expense()
        load_vendor_fgpo()
        load_vendor_refund()
        load_group_store_cn()
        load_vendor_dpkhusus()

        'VS sales
        viewCoaTag()

        DECAFrom.EditValue = Date.Parse(Now)
        DECATo.EditValue = Date.Parse(Now)
    End Sub

    Sub load_group_store_cn()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg 
        WHERE cg.is_allow_closing_cn=1 "
        viewSearchLookupQuery(SLEStoreGroup, query, "id_comp_group", "comp_group", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub load_store_cn()
        Cursor = Cursors.WaitCursor
        Dim id_group As String = "-1"
        Try
            id_group = SLEStoreGroup.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim cond_group As String = ""
        If id_group <> "0" Then
            cond_group = "AND c.id_comp_group='" + id_group + "' "
        End If


        Dim query As String = "SELECT cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'
                                WHERE c.id_comp_cat='6' " + cond_group + " "
        viewSearchLookupQuery(SLEStoreInvoice, query, "id_comp_contact", "comp_name", "id_comp_contact")
        Cursor = Cursors.Default
    End Sub

    Sub load_status_payment()
        Dim query As String = "SELECT 0 AS id_status_payment,'Open' AS status_payment
UNION
SELECT 1 AS id_status_payment,'Paid' AS status_payment
UNION
SELECT 2 AS id_status_payment,'Overdue' AS status_payment
UNION
SELECT 3 AS id_status_payment,'Overdue H-7' AS status_payment"
        viewSearchLookupQuery(SLEStatusPayment, query, "id_status_payment", "status_payment", "id_status_payment")
        viewSearchLookupQuery(SLEStatusPaymentExpense, query, "id_status_payment", "status_payment", "id_status_payment")
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT 0 AS id_comp_contact,'All' as comp_name
UNION
SELECT cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'
                                WHERE c.id_comp_cat='8' or c.id_comp_cat='1' "
        viewSearchLookupQuery(SLEVendorPayment, query, "id_comp_contact", "comp_name", "id_comp_contact")
    End Sub

    Sub load_vendor_po()
        Dim query As String = "SELECT cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name,sts.comp_status
                                FROM tb_m_comp c
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'
                                INNER JOIN tb_lookup_comp_status sts ON sts.id_comp_status=c.is_active
                                WHERE (c.id_comp_cat='8' or c.id_comp_cat='1')
                                AND (c.is_active='1' OR c.is_active='2') "
        viewSearchLookupQuery(SLEVendor, query, "id_comp_contact", "comp_name", "id_comp_contact")
    End Sub

    Sub load_vendor_fgpo()
        Dim query As String = "SELECT c.id_comp,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name,sts.comp_status  
                                FROM tb_m_comp c
                                INNER JOIN tb_lookup_comp_status sts ON sts.id_comp_status=c.is_active
                                WHERE c.id_comp_cat='1' OR c.id_comp_cat='8' AND (c.is_active='1' OR c.is_active='2') "
        viewSearchLookupQuery(SLEFGPOVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_vendor_refund()
        Dim query As String = "SELECT c.id_comp,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c
                                WHERE c.id_commerce_type='2'"
        viewSearchLookupQuery(SLEVendorRefund, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_vendor_expense()
        Dim query As String = "SELECT  c.id_comp,cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1' "
        viewSearchLookupQuery(SLEVendorExpense, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_trans_type_po()
        Dim query As String = "SELECT id_pay_type,pay_type FROM tb_lookup_pay_type"
        viewSearchLookupQuery(SLEPayType, query, "id_pay_type", "pay_type", "id_pay_type")
        viewSearchLookupQuery(SLEPayTypeExpense, query, "id_pay_type", "pay_type", "id_pay_type")
    End Sub

    Sub load_trans_type()
        Dim query As String = "SELECT 0 AS id_pay_type,'ALL' AS pay_type
UNION
SELECT id_pay_type,pay_type FROM tb_lookup_pay_type"
        viewSearchLookupQuery(SLEPayTypePayment, query, "id_pay_type", "pay_type", "id_pay_type")
    End Sub

    Sub load_payment()
        Dim where_string As String = ""

        If Not SLEVendorPayment.EditValue.ToString = "0" Then
            where_string = " AND py.id_comp_contact='" & SLEVendorPayment.EditValue.ToString & "'"
            BCreatePay.Visible = True
        Else
            BCreatePay.Visible = False
        End If

        If Not SLEPayTypePayment.EditValue.ToString = "0" Then
            where_string = " AND py.id_pay_type='" & SLEPayTypePayment.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT py.number,sts.report_status,emp.employee_name AS created_by, py.date_created, py.`id_pn`,py.`value` ,CONCAT(c.`comp_number`,' - ',c.`comp_name`) AS comp_name,rm.`report_mark_type_name`,pt.`pay_type`,py.note,py.date_payment
FROM tb_pn py
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=py.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN `tb_lookup_report_mark_type` rm ON rm.`report_mark_type`=py.`report_mark_type`
INNER JOIN `tb_lookup_pay_type` pt ON pt.`id_pay_type`=py.`id_pay_type`
INNER JOIN tb_m_user usr ON usr.id_user=py.id_user_created
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=py.id_report_status
WHERE DATE(py.date_payment) >= '" & Date.Parse(DEBBKFrom.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(py.date_payment) <= '" & Date.Parse(DEBBKTo.EditValue.ToString).ToString("yyyy-MM-dd") & "'
" & where_string & " ORDER BY py.id_pn DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        GVList.BestFitColumns()
    End Sub

    Sub viewCoaTag()
        Dim query As String = "SELECT ct.id_coa_tag, ct.tag_code, ct.tag_description, CONCAT(ct.tag_code,' - ', ct.tag_description)  AS `coa_tag`
        FROM tb_coa_tag ct WHERE ct.id_coa_tag>1 ORDER BY ct.id_coa_tag ASC "
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
    End Sub
    '
    Sub load_fgpo()
        Dim where_string As String = ""

        If Not SLEFGPOVendor.EditValue.ToString = "0" Then
            where_string = " AND c.id_comp = " & SLEFGPOVendor.EditValue.ToString & " "
            BCreatePaymentFGPO.Visible = True
        Else
            BCreatePaymentFGPO.Visible = False
        End If

        Dim query As String = "CALL view_payment_fgpo('" & where_string & "'," & decimalSQL(TEKurs.EditValue.ToString).ToString & ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCFGPO.DataSource = data
        GVFGPO.BestFitColumns()
    End Sub
    '
    Sub load_vendor_dpkhusus()
        Dim query As String = "SELECT c.id_comp,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c
                                WHERE c.id_comp_cat='1' OR c.id_comp_cat='8' AND c.is_active=1"
        viewSearchLookupQuery(SLEDPKhususVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub
    '
    Sub load_po()
        Dim where_string As String = ""
        Dim q_acc As String = ""
        Dim q_join_acc As String = ""
        Dim having_string As String = ""

        Dim q_dp As String = ""

        If Not SLEVendor.EditValue.ToString = "0" Then
            where_string += " AND po.id_comp_contact='" & SLEVendor.EditValue.ToString & "'"
        End If

        If SLEPayType.EditValue.ToString = "2" Then 'payment
            q_acc = ",acc.id_acc,acc.acc_name,acc.acc_description "
            q_join_acc = " INNER JOIN tb_a_acc acc ON acc.id_acc=c.id_acc_ap "
            where_string += " AND po.is_close_rec='1'"
            q_dp = "-IFNULL(payment.value,0)"
        ElseIf SLEPayType.EditValue.ToString = "1" Then 'DP
            q_acc = ",acc.id_acc,acc.acc_name,acc.acc_description "
            q_join_acc = " INNER JOIN tb_a_acc acc ON acc.id_acc=c.id_acc_dp "
            q_dp = "*(payment_purc.dp_percent/100)"
        End If

        id_pay_type_po = SLEPayType.EditValue.ToString

        If XTPPOList.SelectedTabPageIndex = 0 Then
            If SLEStatusPayment.EditValue.ToString = "0" Then 'open include overdue and only dp
                where_string += " AND po.is_close_pay=2 "
                BCreatePO.Visible = True
            ElseIf SLEStatusPayment.EditValue.ToString = "1" Then 'paid
                where_string += " AND po.is_close_pay=1 "
                BCreatePO.Visible = False
            ElseIf SLEStatusPayment.EditValue.ToString = "2" Then 'overdue
                where_string += " AND po.due_date < DATE(NOW()) AND po.is_close_pay=2 "
                BCreatePO.Visible = True
            ElseIf SLEStatusPayment.EditValue.ToString = "3" Then 'overdue H-7
                where_string += " AND DATE_SUB(po.due_date, INTERVAL 7 DAY) < DATE(NOW()) AND po.is_close_pay=2 "
                BCreatePO.Visible = True
            End If
        End If

        If XTPPOList.SelectedTabPageIndex = 1 Then
            BCreatePO.Visible = False
        Else
            BCreatePO.Visible = True
        End If

        Dim query As String = "SELECT 'no' AS is_check,po.inv_number
,po.report_mark_type,po.is_close_pay,po.pay_due_date,po.due_date,po.id_purc_order,c.comp_number,c.comp_name,cc.contact_person,cc.contact_number,po.purc_order_number,po.date_created,emp_cre.employee_name AS emp_created,po.last_update,emp_upd.employee_name AS emp_updated,po.note
,SUM(pod.qty) AS qty_po,((SUM(pod.qty*(pod.value-pod.discount))-po.disc_value+((SUM(pod.qty*(pod.value-pod.discount))-po.disc_value)*(po.vat_percent/100)*(po.dpp_percent/100)))" + q_dp + ") AS total_po
,SUM(pod.qty*(pod.value-pod.discount))-po.disc_value AS amo_po
,((SUM(pod.qty*(pod.value-pod.discount))-po.disc_value)*(po.vat_percent/100)*(po.dpp_percent/100)) AS amo_vat
,IFNULL(SUM(rec.qty),0) AS qty_rec,IF(ISNULL(rec.id_purc_order_det),0,SUM(rec.qty*(pod.value-pod.discount))-(SUM(rec.qty*(pod.value-pod.discount))/SUM(pod.qty*(pod.value-pod.discount))*po.disc_value)+(SUM(rec.qty*(pod.value-pod.discount))/SUM(pod.qty*(pod.value-pod.discount))*((SUM(pod.qty*(pod.value-pod.discount))-po.disc_value)*(po.vat_percent/100)*(po.dpp_percent/100)))) AS total_rec
,(IFNULL(SUM(rec.qty*pod.value),0)/SUM(pod.qty*pod.value))*100 AS rec_progress,IF(po.is_close_rec=1,'Closed',IF((IFNULL(SUM(rec.qty),0)/SUM(pod.qty))<=0,'Waiting',IF((IFNULL(SUM(rec.qty),0)/SUM(pod.qty))<1,'Partial','Complete'))) AS rec_status
,po.close_rec_reason
,IFNULL(payment.value,0) AS val_pay
,IF(po.pph_account=(SELECT id_acc_skbp FROM tb_opt_accounting),0,po.pph_total) AS pph_total,IFNULL(po.pph_account,'') AS pph_account,coa.acc_name AS pph_acc_name,coa.acc_description AS pph_acc_description
,IF(po.is_close_rec=1,
	IF(ISNULL(rec.id_purc_order_det),0,SUM(rec.qty*(pod.value-pod.discount))-(SUM(rec.qty*(pod.value-pod.discount))/SUM(pod.qty*(pod.value-pod.discount))*po.disc_value)+(SUM(rec.qty*(pod.value-pod.discount))/SUM(pod.qty*(pod.value-pod.discount))*((SUM(pod.qty*(pod.value-pod.discount))-po.disc_value)*(po.vat_percent/100)*(po.dpp_percent/100))))
	,((SUM(pod.qty*(pod.value-pod.discount))-po.disc_value+((SUM(pod.qty*(pod.value-pod.discount))-po.disc_value)*(po.vat_percent/100)*(po.dpp_percent/100))))" + q_dp + ")-IFNULL(payment.value,0)-IF(po.pph_account=(SELECT id_acc_skbp FROM tb_opt_accounting),0,po.pph_total) AS total_due
,IFNULL(payment_dp.value,0) as total_dp
,IFNULL(payment_pending.jml,0) as total_pending
,DATEDIFF(po.`due_date`,NOW()) AS due_days
,cf.id_comp AS `id_comp_default`, cf.comp_number as `comp_number_default`
,po.report_mark_type,tag.id_coa_tag,tag.tag_code
,SUM(pod.gross_up_value) AS gross_up_value
" & q_acc & "
FROM tb_purc_order po
LEFT JOIN tb_a_acc coa ON coa.id_acc=po.pph_account
INNER JOIN tb_m_comp cf ON cf.id_comp=1
INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order`=po.`id_purc_order`
INNER JOIN tb_purc_req_det prd ON pod.id_purc_req_det = prd.id_purc_req_det
INNER JOIN tb_m_comp c_tag ON IF(prd.ship_to=0,1,prd.ship_to) = c_tag.id_comp
INNER JOIN tb_coa_tag tag ON c_tag.id_coa_tag = tag.id_coa_tag
INNER JOIN tb_m_user usr_cre ON usr_cre.id_user=po.created_by
INNER JOIN tb_m_employee emp_cre ON emp_cre.id_employee=usr_cre.id_employee
INNER JOIN tb_m_user usr_upd ON usr_upd.id_user=po.last_update_by
INNER JOIN tb_m_employee emp_upd ON emp_upd.id_employee=usr_upd.id_employee
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=po.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
" & q_join_acc & "
LEFT JOIN 
( 
	SELECT recd.`id_purc_order_det`,SUM(recd.`qty`) AS qty FROM tb_purc_rec_det recd 
	INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec`=recd.`id_purc_rec` AND rec.`id_report_status`='6'
	GROUP BY recd.`id_purc_order_det`
) rec ON rec.id_purc_order_det=pod.`id_purc_order_det`
LEFT JOIN
(
	SELECT pyd.id_report, SUM(pyd.`value`) AS `value` FROM `tb_pn_det` pyd
	INNER JOIN tb_pn py ON py.id_pn=pyd.id_pn AND py.id_report_status!=5 AND (pyd.report_mark_type='139' OR pyd.report_mark_type='202')
	GROUP BY pyd.id_report
)payment ON payment.id_report=po.id_purc_order
LEFT JOIN
(
	SELECT pyd.id_report, SUM(pyd.`value`) AS `value` FROM `tb_pn_det` pyd
	INNER JOIN tb_pn py ON py.id_pn=pyd.id_pn AND py.id_report_status!=5 AND (pyd.report_mark_type='139' OR pyd.report_mark_type='202') AND py.id_pay_type=1
	GROUP BY pyd.id_report
)payment_dp ON payment_dp.id_report=po.id_purc_order
LEFT JOIN
(
	SELECT COUNT(pyd.id_report) AS jml,pyd.id_report,py.id_coa_tag FROM `tb_pn_det` pyd
	INNER JOIN tb_pn py ON py.id_pn=pyd.id_pn AND py.id_report_status!=6 AND py.id_report_status!=5 AND (pyd.report_mark_type='139' OR pyd.report_mark_type='202')
	GROUP BY pyd.id_report, py.id_coa_tag
)payment_pending ON payment_pending.id_report=po.id_purc_order AND payment_pending.id_coa_tag = tag.id_coa_tag
LEFT JOIN tb_lookup_payment_purchasing AS payment_purc ON po.id_payment_purchasing = payment_purc.id_payment_purchasing
WHERE po.is_cash_purchase=2 " & where_string & " {query_active} GROUP BY c_tag.id_coa_tag, po.id_purc_order " & having_string
        If XTPPOList.SelectedTabPageIndex = 0 Then
            'active
            If SLEPayType.EditValue.ToString = "1" Then 'DP
                query = query.Replace("{query_active}", "AND payment_purc.is_dp = 1")
            Else
                query = query.Replace("{query_active}", "AND po.is_active_payment = 1")
            End If

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCPOList.DataSource = data
            GVPOList.BestFitColumns()
        Else
            'non active
            query = query.Replace("{query_active}", "AND po.is_active_payment = 2").Replace("c_tag.id_coa_tag,", "")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCPOListNonActive.DataSource = data
            GVPOListNonActive.BestFitColumns()
        End If
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        buttonView_click()
    End Sub

    Sub buttonView_click()
        Dim query_check As String = "SELECT IFNULL(id_acc_dp,0) AS id_acc_dp,IFNULL(id_acc_ap,0) AS id_acc_ap FROM tb_m_comp c
INNER JOIN tb_m_comp_contact cc ON cc.id_comp = c.id_comp
WHERE cc.id_comp_contact='" & SLEVendor.EditValue & "'"
        Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")
        If data_check.Rows(0)("id_acc_dp").ToString = "0" And SLEPayType.EditValue.ToString = "1" Then
            warningCustom("This vendor DP account is not set.")
        ElseIf data_check.Rows(0)("id_acc_ap").ToString = "0" And SLEPayType.EditValue.ToString = "2" Then
            warningCustom("This vendor AP account is not set.")
        Else
            load_po()
        End If
    End Sub

    Private Sub GVPOList_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVPOList.RowStyle
        Try
            If GVPOList.GetRowCellValue(e.RowHandle, "is_close_pay") = "2" Then
                If GVPOList.GetRowCellValue(e.RowHandle, "due_days") < 0 Then 'passed H
                    e.Appearance.BackColor = Color.Crimson
                    e.Appearance.ForeColor = Color.White
                    e.Appearance.FontStyleDelta = FontStyle.Bold
                ElseIf GVPOList.GetRowCellValue(e.RowHandle, "due_days") < 7 Then 'H -7
                    e.Appearance.BackColor = Color.Yellow
                    e.Appearance.ForeColor = Color.Black
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BCreatePO_Click(sender As Object, e As EventArgs) Handles BCreatePO.Click
        GVPOList.ActiveFilterString = ""
        GVPOList.ActiveFilterString = "[is_check]='yes'"

        Dim is_pending As Boolean = False
        'check
        For i As Integer = 0 To GVPOList.RowCount - 1
            If GVPOList.GetRowCellValue(i, "total_pending") > 0 Then
                is_pending = True
            End If
        Next
        If is_pending = True Then
            warningCustom("Please process all pending payment for selected purchase")
        Else
            If id_pay_type_po = "1" Then 'dp
                If GVPOList.RowCount > 0 Then
                    FormBankWithdrawalDet.report_mark_type = GVPOList.GetFocusedRowCellValue("report_mark_type").ToString
                    FormBankWithdrawalDet.id_pay_type = id_pay_type_po
                    FormBankWithdrawalDet.ShowDialog()
                Else
                    warningCustom("No data selected")
                End If
            ElseIf id_pay_type_po = "2" Then 'payment
                If GVPOList.RowCount > 0 Then
                    FormBankWithdrawalDet.report_mark_type = GVPOList.GetFocusedRowCellValue("report_mark_type").ToString
                    FormBankWithdrawalDet.id_pay_type = id_pay_type_po
                    FormBankWithdrawalDet.ShowDialog()
                Else
                    warningCustom("No data selected")
                End If
            Else
                warningCustom("Please view the data first")
            End If
        End If

        GVPOList.ActiveFilterString = ""
    End Sub

    Private Sub BViewPayment_Click(sender As Object, e As EventArgs) Handles BViewPayment.Click
        load_payment()
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        If GVList.RowCount > 0 Then
            FormBankWithdrawalDet.id_payment = GVList.GetFocusedRowCellValue("id_pn")
            FormBankWithdrawalDet.ShowDialog()
        End If
    End Sub

    Private Sub BtnViewExpense_Click(sender As Object, e As EventArgs) Handles BtnViewExpense.Click
        Dim query_check As String = "SELECT IFNULL(id_acc_dp,0) AS id_acc_dp,IFNULL(id_acc_ap,0) AS id_acc_ap FROM tb_m_comp c
WHERE c.id_comp='" & SLEVendorExpense.EditValue & "'"
        Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")
        If data_check.Rows(0)("id_acc_dp").ToString = "0" And SLEPayTypeExpense.EditValue.ToString = "1" Then
            warningCustom("This vendor DP account is not set.")
        ElseIf data_check.Rows(0)("id_acc_ap").ToString = "0" And SLEPayTypeExpense.EditValue.ToString = "2" Then
            warningCustom("This vendor AP account is not set.")
        Else
            load_expense()
        End If
    End Sub

    Sub load_expense()
        Cursor = Cursors.WaitCursor

        Dim where_string As String = ""
        Dim having_string As String = ""

        Dim q_acc As String = ""
        Dim q_join_acc As String = ""

        If Not SLEVendorExpense.EditValue.ToString = "0" Then
            where_string = "AND e.id_comp='" & SLEVendorExpense.EditValue.ToString & "' "
        End If

        If SLEPayTypeExpense.EditValue.ToString = "2" Then 'payment
            q_acc = ",acc.id_acc,acc.acc_name,acc.acc_description "
            q_join_acc = " LEFT JOIN tb_a_acc acc ON acc.id_acc=c.id_acc_ap "
        ElseIf SLEPayTypeExpense.EditValue.ToString = "1" Then 'DP
            q_acc = ",acc.id_acc,acc.acc_name,acc.acc_description "
            q_join_acc = " LEFT JOIN tb_a_acc acc ON acc.id_acc=c.id_acc_dp "
        End If

        If SLEStatusPaymentExpense.EditValue.ToString = "0" Then 'open include overdue and only dp
            where_string += "AND e.is_pay_later=1 AND e.is_open=1 "
            BCreateExpense.Visible = True
        ElseIf SLEStatusPaymentExpense.EditValue.ToString = "1" Then 'paid
            where_string += "AND e.is_pay_later=1 AND e.is_open=2 "
            BCreateExpense.Visible = False
        ElseIf SLEStatusPaymentExpense.EditValue.ToString = "2" Then 'overdue
            where_string += "AND e.is_pay_later=1 AND e.is_open=1 AND e.due_date < DATE(NOW()) "
            BCreateExpense.Visible = True
        ElseIf SLEStatusPaymentExpense.EditValue.ToString = "3" Then 'overdue H-7
            where_string += "AND e.is_pay_later=1 AND e.is_open=1 AND DATE_SUB(e.due_date, INTERVAL 7 DAY)<DATE(NOW()) "
            BCreateExpense.Visible = True
        End If

        Dim e As New ClassItemExpense()
        e.q_acc = q_acc
        e.q_join = q_join_acc
        Dim query As String = e.queryMain(where_string, "1", True)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCExpense.DataSource = data
        GVExpense.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BCreateExpense_Click(sender As Object, e As EventArgs) Handles BCreateExpense.Click
        Cursor = Cursors.WaitCursor

        GVExpense.ActiveFilterString = ""
        GVExpense.ActiveFilterString = "[is_select]='yes'"

        If GVExpense.RowCount > 0 Then
            Dim is_pending As Boolean = False
            'check
            For i As Integer = 0 To ((GVExpense.RowCount - 1) - GetGroupRowCount(GVExpense))
                If GVExpense.GetRowCellValue(i, "total_pending") > 0 Then
                    is_pending = True
                    Exit For
                End If
            Next
            If is_pending = True Then
                warningCustom("Please process all pending payment for selected expense")
            Else
                Dim id_pay_type_expense As String = SLEPayTypeExpense.EditValue.ToString
                If id_pay_type_expense = "1" Then 'dp
                    FormBankWithdrawalDet.report_mark_type = "157"
                    FormBankWithdrawalDet.id_pay_type = id_pay_type_expense
                    FormBankWithdrawalDet.ShowDialog()
                ElseIf id_pay_type_expense = "2" Then 'payment
                    FormBankWithdrawalDet.report_mark_type = "157"
                    FormBankWithdrawalDet.id_pay_type = id_pay_type_expense
                    FormBankWithdrawalDet.ShowDialog()
                End If
            End If
        Else
            warningCustom("No data selected")
        End If
        GVExpense.ActiveFilterString = ""

        Cursor = Cursors.Default
    End Sub

    Private Sub GVExpense_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVExpense.RowStyle
        If GVExpense.RowCount > 0 And GVExpense.FocusedRowHandle >= 0 Then
            Try
                If GVExpense.GetRowCellValue(e.RowHandle, "is_open").ToString = "1" Then
                    If GVExpense.GetRowCellValue(e.RowHandle, "due_days") < 0 Then 'passed H
                        e.Appearance.BackColor = Color.Crimson
                        e.Appearance.ForeColor = Color.White
                        e.Appearance.FontStyleDelta = FontStyle.Bold
                    ElseIf GVExpense.GetRowCellValue(e.RowHandle, "due_days") < 7 Then 'H -7
                        e.Appearance.BackColor = Color.Yellow
                        e.Appearance.ForeColor = Color.Black
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BViewFGPOPay_Click(sender As Object, e As EventArgs) Handles BViewFGPOPay.Click
        load_fgpo()
    End Sub

    Private Sub BCreatePaymentFGPO_Click(sender As Object, e As EventArgs) Handles BCreatePaymentFGPO.Click
        GVFGPO.ActiveFilterString = ""
        GVFGPO.ActiveFilterString = "[is_check]='yes'"

        If GVFGPO.RowCount > 0 Then
            Dim is_pending As Boolean = False
            'check
            For i As Integer = 0 To GVFGPO.RowCount - 1
                If GVFGPO.GetRowCellValue(i, "total_pending") > 0 Then
                    is_pending = True
                End If
            Next

            If is_pending = True Then
                warningCustom("Please process all pending payment for selected purchase")
            Else
                FormBankWithdrawalDet.TEKurs.EditValue = TEKurs.EditValue
                FormBankWithdrawalDet.report_mark_type = "189"
                FormBankWithdrawalDet.ShowDialog()
            End If
        Else
            warningCustom("Please select item first.")
        End If

        GVFGPO.ActiveFilterString = ""
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        If XTCPO.SelectedTabPage.Name = "XTPFGPO" Then
            Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
            showpopup.report_mark_type = GVFGPO.GetFocusedRowCellValue("report_mark_type").ToString
            showpopup.id_report = GVFGPO.GetFocusedRowCellValue("id_report").ToString
            showpopup.show()
        ElseIf XTCPO.SelectedTabPage.Name = "XTPTHR" Then
            FormEmpPayrollReportSummary.id_payroll = GVTHR.GetFocusedRowCellValue("id_payroll").ToString
            FormEmpPayrollReportSummary.ShowDialog()
        ElseIf XTCPO.SelectedTabPage.Name = "XTPJamsostek" Then
            FormEmpPayrollReportBPJSTK.id_payroll = GVJamsostek.GetFocusedRowCellValue("id_payroll").ToString
            FormEmpPayrollReportBPJSTK.ShowDialog()
        ElseIf XTCPO.SelectedTabPage.Name = "XTPBPJSKesehatan" Then
            FormEmpBPJSKesehatanDet.id = GVBPJSKesehatan.GetFocusedRowCellValue("id_pay_bpjs_kesehatan").ToString
            FormEmpBPJSKesehatanDet.is_approve = "1"
            FormEmpBPJSKesehatanDet.ShowDialog()
        End If
    End Sub

    Private Sub BCreatePay_Click(sender As Object, e As EventArgs) Handles BCreatePay.Click
        If Not SLEVendorPayment.EditValue.ToString = "0" Then
            FormBankWithdrawalDet.report_mark_type = "159"
            FormBankWithdrawalDet.ShowDialog()
        End If
    End Sub

    Private Sub ToolStripMenuItemAdd_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAdd.Click
        If XTPPOList.SelectedTabPageIndex = 0 Then
            infoCustom("Already active.")
        ElseIf XTPPOList.SelectedTabPageIndex.ToString = 1 Then
            FormBankWithdrawalAttachement.id_purc_order = GVPOListNonActive.GetFocusedRowCellValue("id_purc_order").ToString
            FormBankWithdrawalAttachement.ShowDialog()
        ElseIf XTPPOList.SelectedTabPageIndex = 2 Then
            FormBankWithdrawalAttachement.id_purc_order = GVPO.GetFocusedRowCellValue("id_purc_order").ToString
            FormBankWithdrawalAttachement.ShowDialog()
        End If
    End Sub

    Private Sub RICEAttachment_Click(sender As Object, e As EventArgs) Handles RICEAttachment.Click
        Cursor = Cursors.WaitCursor

        FormDocumentUpload.is_no_delete = "-1"
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.id_report = GVPOList.GetFocusedRowCellValue("id_purc_order").ToString
        FormDocumentUpload.report_mark_type = "235"

        FormDocumentUpload.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub XTPPOList_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTPPOList.SelectedPageChanged
        If XTPPOList.SelectedTabPageIndex = 1 Then
            LabelControl5.Visible = False
            SLEStatusPayment.Visible = False

            BView.Location = New Point(438, 9)

            BCreatePO.Visible = False

            PanelControl1.Enabled = True
            BCreatePO.Enabled = True
        ElseIf XTPPOList.SelectedTabPageIndex = 2 Then
            PanelControl1.Enabled = False
            BCreatePO.Enabled = False
        Else
            LabelControl5.Visible = True
            SLEStatusPayment.Visible = True

            BCreatePO.Visible = True

            BView.Location = New Point(649, 9)

            PanelControl1.Enabled = True
            BCreatePO.Enabled = True
        End If
    End Sub

    Sub view_bpjskesehatan()
        Dim query As String = "
            SELECT 'no' AS is_check, bpjs.id_pay_bpjs_kesehatan, bpjs.number, DATE_FORMAT(py.periode_end, '%M %Y') AS payroll_periode, IF(py.id_payroll_type = 1, 'Organic', 'Daily Worker') AS payroll_type, total_amount.total_amount
            FROM tb_pay_bpjs_kesehatan AS bpjs
            LEFT JOIN tb_emp_payroll AS py ON bpjs.id_payroll = py.id_payroll
            LEFT JOIN tb_lookup_report_status AS rs ON bpjs.id_report_status = rs.id_report_status
            LEFT JOIN (
                SELECT id_pay_bpjs_kesehatan, SUM(total_amount) AS total_amount
                FROM (
                    SELECT id_pay_bpjs_kesehatan, ROUND((bpjs_kesehatan_contribution + (bpjs_kesehatan_contribution * 100 * 0.04)), 0) AS total_amount
                    FROM tb_pay_bpjs_kesehatan_det
                ) AS tb
                GROUP BY id_pay_bpjs_kesehatan
            ) AS total_amount ON bpjs.id_pay_bpjs_kesehatan = total_amount.id_pay_bpjs_kesehatan
            WHERE bpjs.id_report_status = 6 AND bpjs.is_close_pay = 2
            ORDER BY py.periode_end DESC, py.id_payroll_type ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")



        GCBPJSKesehatan.DataSource = data

        GVBPJSKesehatan.BestFitColumns()
    End Sub

    Sub view_thr()
        Dim query As String = "
            SELECT 'no' AS is_check, p.id_payroll, p.report_number, DATE_FORMAT(p.periode_end, '%M %Y') AS payroll_periode, t.payroll_type, 0 AS amount
            FROM tb_emp_payroll AS p
            LEFT JOIN tb_emp_payroll_type AS t ON p.id_payroll_type = t.id_payroll_type
            WHERE p.id_report_status = 6 AND p.is_close_pay = 2
            ORDER BY p.periode_end DESC, p.id_payroll_type ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim i As Integer = 0

        Dim r As Integer = data.Rows.Count - 1

        'amount
        While i <= r
            Dim id_acc As String = execute_query("
                SELECT map.id_acc
                FROM tb_coa_map_departement AS map
                LEFT JOIN tb_a_acc AS acc ON map.id_acc = acc.id_acc
                LEFT JOIN tb_m_comp AS comp ON map.id_comp = comp.id_comp
                WHERE type = 6
            ", 0, True, "", "", "", "")

            Dim query_a As String = "
                SELECT SUM(CAST(a.credit AS DECIMAL(13, 2))) AS credit
                FROM tb_a_acc_trans_det a 
                INNER JOIN tb_a_acc b ON a.id_acc = b.id_acc 
                LEFT JOIN tb_m_comp c ON c.id_comp = a.id_comp
                WHERE a.id_acc_trans = (SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad WHERE ad.report_mark_type = 192 AND ad.id_report = " + data.Rows(i)("id_payroll").ToString + " GROUP BY ad.id_acc_trans) AND a.id_acc = (" + id_acc + ")
            "

            Dim data_a As DataTable = execute_query(query_a, -1, True, "", "", "", "")

            Dim total As Integer = 0

            For j = 0 To data_a.Rows.Count - 1
                Try
                    total += Decimal.Parse(data_a.Rows(j)("credit").ToString)
                Catch ex As Exception
                End Try
            Next

            Dim data_salary As DataTable = execute_query("CALL view_payroll_sum('" + data.Rows(i)("id_payroll").ToString + "')", -1, True, "", "", "", "")

            'cooperative
            Dim total_cooperative As Integer = 0

            For j = 0 To data_salary.Rows.Count - 1
                Try
                    total_cooperative += data_salary.Rows(j)("d_cooperative_contribution") + data_salary.Rows(j)("d_cooperative_loan")
                Catch ex As Exception
                End Try
            Next

            If total_cooperative > 0 Then
                total = total - total_cooperative
            End If

            data.Rows(i)("amount") = total

            If total_cooperative > 0 Then
                Dim row_cooperative As DataRow = data.NewRow

                row_cooperative("is_check") = "no"
                row_cooperative("id_payroll") = data.Rows(i)("id_payroll")
                row_cooperative("report_number") = data.Rows(i)("report_number").ToString
                row_cooperative("payroll_periode") = data.Rows(i)("payroll_periode").ToString
                row_cooperative("payroll_type") = data.Rows(i)("payroll_type").ToString + " (Cooperative)"
                row_cooperative("amount") = total_cooperative

                data.Rows.Add(row_cooperative)
            End If

            'cash
            Dim total_cash As Integer = 0

            For j = 0 To data_salary.Rows.Count - 1
                Try
                    total_cash += data_salary.Rows(j)("total_cash")
                Catch ex As Exception
                End Try
            Next

            If total_cash > 0 Then
                total = total - total_cash
            End If

            data.Rows(i)("amount") = total

            If total_cash > 0 Then
                Dim row_cash As DataRow = data.NewRow

                row_cash("is_check") = "no"
                row_cash("id_payroll") = data.Rows(i)("id_payroll")
                row_cash("report_number") = data.Rows(i)("report_number").ToString
                row_cash("payroll_periode") = data.Rows(i)("payroll_periode").ToString
                row_cash("payroll_type") = data.Rows(i)("payroll_type").ToString + " (Cash)"
                row_cash("amount") = total_cash

                data.Rows.Add(row_cash)
            End If

            i += 1
        End While

        GCTHR.DataSource = data

        GVTHR.BestFitColumns()
    End Sub

    Private Sub XTCPO_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPO.SelectedPageChanged
        If XTCPO.SelectedTabPage.Name = "XTPBPJSKesehatan" Then
            view_bpjskesehatan()
        ElseIf XTCPO.SelectedTabPage.Name = "XTPTHR" Then
            view_thr()
        ElseIf XTCPO.SelectedTabPage.Name = "XTPJamsostek" Then
            view_jamsostek()
        ElseIf XTCPO.SelectedTabPage.Name = "XTPRefund" Then
            If XTCCN.SelectedTabPageIndex = 0 Then
                load_refund()
            Else
                view_list_cn()
            End If
        ElseIf XTCPO.SelectedTabPage.Name = "XTPVS" Then
            view_vs()
        End If
    End Sub

    Private Sub SBPayBPJSKesehatan_Click(sender As Object, e As EventArgs) Handles SBPayBPJSKesehatan.Click
        GVBPJSKesehatan.ActiveFilterString = ""
        GVBPJSKesehatan.ActiveFilterString = "[is_check]='yes'"

        If GVBPJSKesehatan.RowCount > 0 Then
            'check created
            Dim id_pay_bpjs_kesehatan As String = ""

            For i = 0 To GVBPJSKesehatan.RowCount - 1
                id_pay_bpjs_kesehatan = GVBPJSKesehatan.GetRowCellValue(i, "id_pay_bpjs_kesehatan").ToString + ", "
            Next

            id_pay_bpjs_kesehatan = id_pay_bpjs_kesehatan.Substring(0, id_pay_bpjs_kesehatan.Length - 2)

            Dim total As String = execute_query("
                SELECT COUNT(*) AS total
                FROM tb_pn_det AS pn_det
                LEFT JOIN tb_pn AS pn ON pn_det.id_pn = pn.id_pn
                WHERE pn.id_report_status <> 5 AND pn_det.report_mark_type = 223 AND pn_det.id_report IN (" + id_pay_bpjs_kesehatan + ")
            ", 0, True, "", "", "", "")

            If total = "0" Then
                FormBankWithdrawalDet.id_pay_type = "2"
                FormBankWithdrawalDet.report_mark_type = "223"
                FormBankWithdrawalDet.ShowDialog()
            Else
                stopCustom("Payment already created.")
            End If
        Else
            warningCustom("Please select item first.")
        End If

        GVBPJSKesehatan.ActiveFilterString = ""
    End Sub

    Private Sub SBPayTHR_Click(sender As Object, e As EventArgs) Handles SBPayTHR.Click
        GVTHR.ActiveFilterString = ""
        GVTHR.ActiveFilterString = "[is_check]='yes'"

        If GVTHR.RowCount > 0 Then
            FormBankWithdrawalDet.id_pay_type = "2"
            FormBankWithdrawalDet.report_mark_type = "192"
            FormBankWithdrawalDet.ShowDialog()
        Else
            warningCustom("Please select item first.")
        End If

        GVTHR.ActiveFilterString = ""
    End Sub

    Private Sub ViewBPLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewBPLToolStripMenuItem.Click
        If XTPPOList.SelectedTabPageIndex = 0 Then
            FormPopUpListJournal.id_pop_up = "1"
            FormPopUpListJournal.id_ref = GVPOList.GetFocusedRowCellValue("id_purc_order").ToString
            FormPopUpListJournal.title_for_print = "BPL List PO OG " & GVPOList.GetFocusedRowCellValue("purc_order_number").ToString
            FormPopUpListJournal.ShowDialog()
        Else
            FormPopUpListJournal.id_pop_up = "1"
            FormPopUpListJournal.id_ref = GVPOListNonActive.GetFocusedRowCellValue("id_purc_order").ToString
            FormPopUpListJournal.title_for_print = "BPL List PO OG " & GVPOListNonActive.GetFocusedRowCellValue("purc_order_number").ToString
            FormPopUpListJournal.ShowDialog()
        End If
    End Sub

    Private Sub BCreateRefund_Click(sender As Object, e As EventArgs) Handles BCreateRefund.Click
        Cursor = Cursors.WaitCursor

        GVRefund.ActiveFilterString = ""
        GVRefund.ActiveFilterString = "[is_check]='yes'"

        If GVRefund.RowCount > 0 Then
            Dim is_pending As Boolean = False
            'check
            For i As Integer = 0 To ((GVRefund.RowCount - 1) - GetGroupRowCount(GVRefund))
                If GVRefund.GetRowCellValue(i, "total_pending") > 0 Then
                    is_pending = True
                    Exit For
                End If
            Next
            If is_pending = True Then
                warningCustom("Please process all pending payment for selected expense")
            Else
                FormBankWithdrawalDet.report_mark_type = "118"
                FormBankWithdrawalDet.id_pay_type = "2"
                FormBankWithdrawalDet.ShowDialog()
            End If
        Else
            warningCustom("No data selected")
        End If
        GVExpense.ActiveFilterString = ""

        Cursor = Cursors.Default
    End Sub

    Private Sub BViewRefund_Click(sender As Object, e As EventArgs) Handles BViewRefund.Click
        load_refund()
    End Sub

    Sub load_refund()
        Cursor = Cursors.WaitCursor

        Dim where_string As String = ""

        If Not SLEVendorRefund.EditValue.ToString = "0" Then
            where_string = "AND c.id_comp='" & SLEVendorRefund.EditValue.ToString & "' "
        End If

        Dim q As String = "SELECT 'no' AS is_check,pos.id_sales_pos,1 AS is_dc,'118' AS report_mark_type,acc.id_acc,acc.acc_name,acc.acc_description,pos.sales_pos_number,pos.`sales_pos_date`,pos.`sales_pos_due_date`,r.`sales_order_ol_shop_number`,
sr.`id_sales_return`,c.`id_comp`,c.`comp_number`,c.`comp_name`,r.`rec_date`,sr.`sales_return_number`,r.`ret_req_number`,r.`sales_order_ol_shop_number`,SUM(-1*posd.`sales_pos_det_qty`) AS qty
,SUM(posd.`design_price`-sod.discount) AS total
,IFNULL(payment.value,0) AS total_paid
,IFNULL(payment_pending.jml,0) AS total_pending
,(SUM(posd.`design_price`-sod.discount) - IFNULL(payment.value,0)) AS diff,
rq.rek_no, rq.rek_name, rq.rek_bank, rq.rek_branch
FROM tb_sales_return_det srd
INNER JOIN tb_sales_return sr ON sr.`id_sales_return`=srd.`id_sales_return` AND sr.`id_report_status`=6
INNER JOIN tb_sales_return_order_det rord ON rord.`id_sales_return_order_det`=srd.`id_sales_return_order_det`
INNER JOIN `tb_ol_store_ret_list` rl ON rl.`id_ol_store_ret_list`=rord.`id_ol_store_ret_list`
INNER JOIN tb_sales_pos_det posd ON posd.`id_ol_store_ret_list`=rl.`id_ol_store_ret_list`
INNER JOIN tb_sales_pos pos ON pos.`id_sales_pos`=posd.id_sales_pos AND pos.`id_report_status`=6
INNER JOIN tb_a_acc acc ON acc.id_acc=pos.`id_acc_ar`
INNER JOIN tb_ol_store_ret_det rd ON rd.`id_ol_store_ret_det`=rl.`id_ol_store_ret_det`
INNER JOIN tb_ol_store_ret r ON r.`id_ol_store_ret`=rd.`id_ol_store_ret`
INNER JOIN tb_ol_store_ret_req rq ON rq.id_ol_store_ret_req = r.id_ol_store_ret_req
INNER JOIN tb_m_comp_group cg ON cg.`id_comp_group`=r.`id_comp_group` AND cg.is_refund=1
INNER JOIN tb_sales_order_det sod ON sod.`id_sales_order_det`=rd.`id_sales_order_det`
INNER JOIN tb_sales_order so ON so.`id_sales_order`=sod.`id_sales_order`
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=so.`id_store_contact_to`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
LEFT JOIN
(
	SELECT COUNT(pyd.id_report) AS jml,pyd.id_report FROM `tb_pn_det` pyd
	INNER JOIN tb_pn py ON py.id_pn=pyd.id_pn AND py.id_report_status!=6 AND py.id_report_status!=5 AND py.report_mark_type='118'
	GROUP BY pyd.id_report
)payment_pending ON payment_pending.id_report=pos.`id_sales_pos` 
LEFT JOIN
(
	SELECT pyd.id_report, SUM(pyd.`value`) AS `value` FROM `tb_pn_det` pyd
	INNER JOIN tb_pn py ON py.id_pn=pyd.id_pn AND py.id_report_status!=5 AND py.report_mark_type='118'
	GROUP BY pyd.id_report,pyd.`report_mark_type`
)payment ON payment.id_report=pos.`id_sales_pos` 
WHERE pos.`is_close_rec_payment`='2' " & where_string & "
GROUP BY sr.`id_sales_return`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCRefund.DataSource = dt
        GVRefund.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BloadWaiting_Click(sender As Object, e As EventArgs) Handles BloadWaiting.Click
        Dim q As String = "CALL view_waiting_bbk()"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCwaitingList.DataSource = dt
        GVWaitingList.BestFitColumns()
    End Sub

    Private Sub GVWaitingList_DoubleClick(sender As Object, e As EventArgs) Handles GVWaitingList.DoubleClick
        If GVWaitingList.RowCount > 0 Then
            If GVWaitingList.GetFocusedRowCellValue("type").ToString = "PO Operational Goods" Then
                XTCPO.SelectedTabPageIndex = 1
                If GVWaitingList.GetFocusedRowCellValue("remark").ToString = "Active" Then
                    XTPPOList.SelectedTabPageIndex = 0
                Else
                    XTPPOList.SelectedTabPageIndex = 1
                End If
                SLEPayType.EditValue = "2"
                SLEVendor.EditValue = GVWaitingList.GetFocusedRowCellValue("id_comp").ToString
                buttonView_click()
            ElseIf GVWaitingList.GetFocusedRowCellValue("type").ToString = "Expense" Then
                XTCPO.SelectedTabPageIndex = 2
                SLEPayTypeExpense.EditValue = "2"
                SLEVendorExpense.EditValue = GVWaitingList.GetFocusedRowCellValue("id_comp").ToString
                load_expense()
            ElseIf GVWaitingList.GetFocusedRowCellValue("type").ToString = "BPL FGPO" Then
                XTCPO.SelectedTabPageIndex = 3
                SLEFGPOVendor.EditValue = GVWaitingList.GetFocusedRowCellValue("id_comp").ToString
                load_fgpo()
            ElseIf GVWaitingList.GetFocusedRowCellValue("type").ToString = "Refund" Then
                XTCPO.SelectedTabPageIndex = 6
                SLEVendorRefund.EditValue = GVWaitingList.GetFocusedRowCellValue("id_comp").ToString
                load_refund()
            End If
        End If
    End Sub

    Sub view_jamsostek()
        Dim query As String = "
            SELECT 'no' AS is_check, p.id_payroll, p.report_number, DATE_FORMAT(p.periode_end, '%M %Y') AS payroll_periode, t.payroll_type, 0 AS amount, l.bpjstk, l.id_bpjs_location
            FROM tb_emp_payroll AS p
            LEFT JOIN tb_emp_payroll_type AS t ON p.id_payroll_type = t.id_payroll_type
            LEFT JOIN tb_emp_payroll_det AS d ON p.id_payroll = d.id_payroll
            LEFT JOIN tb_m_employee AS e ON e.id_employee = d.id_employee
            LEFT JOIN tb_m_departement_sub AS s ON e.id_departement_sub = s.id_departement_sub
            LEFT JOIN tb_m_bpjs_location AS l ON s.id_bpjs_location = l.id_bpjs_location
            WHERE p.id_report_status = 6 AND t.is_thr <> 1 AND p.is_close_pay_jamsostek = 2
            GROUP BY s.id_bpjs_location, p.id_payroll
            ORDER BY p.periode_end DESC, l.bpjstk ASC, p.id_payroll_type ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'amount
        For i = 0 To data.Rows.Count - 1
            Dim data_bpjstk As DataTable = execute_query("CALL view_payroll_bpjstk(" + data.Rows(i)("id_payroll").ToString + ")", -1, True, "", "", "", "")

            Dim total_contributtion As Integer = 0

            For j = 0 To data_bpjstk.Rows.Count - 1
                If data.Rows(i)("bpjstk").ToString = data_bpjstk.Rows(j)("bpjs_tk_location").ToString Then
                    total_contributtion += data_bpjstk.Rows(j)("total_contribution")
                End If
            Next

            data.Rows(i)("amount") = total_contributtion
        Next

        GCJamsostek.DataSource = data

        GVJamsostek.BestFitColumns()
    End Sub

    Private Sub SBPayJamsostek_Click(sender As Object, e As EventArgs) Handles SBPayJamsostek.Click
        GVJamsostek.ActiveFilterString = ""
        GVJamsostek.ActiveFilterString = "[is_check]='yes'"

        If GVJamsostek.RowCount > 0 Then
            FormBankWithdrawalDet.id_pay_type = "2"
            FormBankWithdrawalDet.report_mark_type = "247"
            FormBankWithdrawalDet.ShowDialog()
        Else
            warningCustom("Please select item first.")
        End If

        GVJamsostek.ActiveFilterString = ""
    End Sub

    Sub load_ca()
        Dim date_from As String = ""
        Dim date_to As String = ""

        Try
            date_from = DateTime.Parse(DECAFrom.EditValue.ToString).ToString("yyyy-MM-dd")
            date_to = DateTime.Parse(DECATo.EditValue.ToString).ToString("yyyy-MM-dd")

            Dim where_string As String = ""

            Dim query As String = "CALL view_cash_advance_report_coa('" & date_from & "','" & date_to & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            Dim data_final As DataTable = data.Clone

            For i = 0 To data.Rows.Count - 1
                Dim expense As Decimal = 0.00

                Try
                    expense = data.Rows(i)("expense")
                Catch ex As Exception
                End Try

                If expense > 0 And data.Rows(i)("is_bbk").ToString = "2" Then
                    data_final.ImportRow(data.Rows(i))
                End If
            Next

            GCCashAdvance.DataSource = data_final
            GVCashAdvance.BestFitColumns()
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub

    Private Sub SBViewCashAdvance_Click(sender As Object, e As EventArgs) Handles SBViewCashAdvance.Click
        load_ca()
    End Sub

    Private Sub SBPayCashAdvance_Click(sender As Object, e As EventArgs) Handles SBPayCashAdvance.Click
        GVCashAdvance.ActiveFilterString = ""
        GVCashAdvance.ActiveFilterString = "[is_check]='yes'"

        If GVCashAdvance.RowCount > 0 Then
            FormBankWithdrawalDet.id_pay_type = "2"
            FormBankWithdrawalDet.report_mark_type = "167"
            FormBankWithdrawalDet.ShowDialog()
        Else
            warningCustom("Please select item first.")
        End If

        GVCashAdvance.ActiveFilterString = ""
    End Sub

    Private Sub CESelectAllCA_EditValueChanged(sender As Object, e As EventArgs) Handles CESelectAllCA.EditValueChanged
        If CESelectAllCA.EditValue Then
            For i = 0 To GVCashAdvance.RowCount - 1
                GVCashAdvance.SetRowCellValue(i, "is_check", "yes")
            Next
        Else
            For i = 0 To GVCashAdvance.RowCount - 1
                GVCashAdvance.SetRowCellValue(i, "is_check", "no")
            Next
        End If
    End Sub

    Private Sub BCreateBookTrf_Click(sender As Object, e As EventArgs) Handles BCreateBookTrf.Click
        FormBankWithdrawalDet.is_book_transfer = True
        FormBankWithdrawalDet.ShowDialog()
    End Sub

    Private Sub SLEStoreGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreGroup.EditValueChanged
        load_store_cn()
    End Sub

    Private Sub BtnListCN_Click(sender As Object, e As EventArgs) Handles BtnListCN.Click
        view_list_cn()
    End Sub

    Sub view_list_cn()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 'no' AS is_check,sp.id_sales_pos, sp.sales_pos_number, cc.id_comp_contact,c.id_comp,c.comp_number,c.`comp_name`, cg.comp_group, sp.id_acc_ar,
        CAST(((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) AS amount,
        IFNULL(p.value,0) AS total_paid,
        CAST(((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) - IFNULL(p.value,0) AS `diff`,
        IFNULL(p.jum_pending,0) AS `total_pending`, sp.id_acc_ar AS `id_acc`, coa.acc_name, coa.acc_description, sp.report_mark_type
        FROM tb_sales_pos sp
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        LEFT JOIN (
	        SELECT d.id_report, COUNT(d.id_report) AS `jum_pending`,  SUM(d.`value`) AS `value`
	        FROM tb_pn_det d
	        INNER JOIN tb_pn m ON m.id_pn = d.id_pn
	        WHERE m.id_report_status!=5 AND d.report_mark_type IN(66,67)
	        GROUP BY d.id_report
        ) p ON p.id_report = sp.id_sales_pos 
        INNER JOIN tb_a_acc coa ON coa.id_acc = sp.id_acc_ar
        WHERE sp.report_mark_type IN (66,67) AND sp.id_report_status=6 
        AND c.id_comp_group='" + SLEStoreGroup.EditValue.ToString + "'
        AND cc.id_comp_contact='" & SLEStoreInvoice.EditValue.ToString & "'
        AND sp.is_close_rec_payment=2 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCN.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCN_Click(sender As Object, e As EventArgs) Handles BtnCN.Click
        'cek pending
        makeSafeGV(GVCN)
        GVCN.ActiveFilterString = "[is_check]='yes' AND [total_pending]>0"
        If GVCN.RowCount > 0 Then
            warningCustom("Please process all pending payment for selected credit note")
            Exit Sub
        End If

        'process
        makeSafeGV(GVCN)
        GVCN.ActiveFilterString = "[is_check]='yes'"
        FormBankWithdrawalDet.report_mark_type = "66"
        FormBankWithdrawalDet.id_pay_type = "2"
        FormBankWithdrawalDet.ShowDialog()
        makeSafeGV(GVCN)
    End Sub

    Private Sub BViewDPKhususPay_Click(sender As Object, e As EventArgs) Handles BViewDPKhususPay.Click
        Dim where_string As String = ""

        If Not SLEDPKhususVendor.EditValue.ToString = "0" Then
            where_string = " AND c.id_comp = " & SLEDPKhususVendor.EditValue.ToString & " "
            BCreatePaymentDPKhusus.Visible = True
        Else
            BCreatePaymentDPKhusus.Visible = False
        End If

        Dim kursx As String = decimalSQL(TEKursDPKhusus.EditValue.ToString)

        Dim query As String = "
            -- payment
	        SELECT 
	        'no' AS is_check,1 AS is_dc,'189' AS report_mark_type,acc.id_acc,acc.acc_name,acc.acc_description,IF(pn.type='1','DP',IF(pn.type='2','Payment','Extra')) AS `type`,pn.number,pn.id_pn_fgpo AS id_report,pn.created_date,sts.report_status,emp.`employee_name`,c.`comp_number`,c.`comp_name`
	        ,det.amount AS total_bpl
	        ,det.amount_now_kurs AS total 
	        ,IFNULL(payment.value,0) AS total_paid
	        ,IFNULL(payment_pending.jml,0) AS total_pending
	        ,(det.amount - IFNULL(payment.value,0)) AS balance
	        ,cf.id_comp AS `id_comp_default`, cf.comp_number AS `comp_number_default`
	        ,det.value_bef_kurs,det.`id_currency`,det.`currency`,det.`kurs`
	        ,det.vat AS vat_bpl,det.amount_selisih_kurs
	        FROM tb_pn_fgpo pn
	        INNER JOIN tb_m_comp cf ON cf.id_comp=1
	        INNER JOIN tb_m_user usr ON usr.`id_user`=pn.`created_by`
	        INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
	        INNER JOIN tb_m_comp c ON c.`id_comp`=pn.`id_comp` " & where_string & "
	        INNER JOIN tb_a_acc acc ON acc.id_acc=c.id_acc_ap
	        INNER JOIN (
		        SELECT pnd.id_pn_fgpo
		        ,SUM(pnd.`value`+pnd.`vat`) AS amount
		        ,SUM(pnd.`vat`) AS vat
		        ,SUM(pnd.`value_bef_kurs`) AS value_bef_kurs
		        ,CAST(SUM(IF(pnd.id_currency=2,(pnd.`value_bef_kurs`*pnd.`kurs`)-(pnd.`value_bef_kurs`*" & kursx & "),0)) AS DECIMAL(13,2)) AS amount_selisih_kurs 
		        ,CAST(SUM(IF(pnd.id_currency=2,((pnd.`value_bef_kurs`*" & kursx & ")+pnd.`vat`),(pnd.`value`+pnd.`vat`))) AS DECIMAL(13,2)) AS amount_now_kurs 
		        ,cur.`id_currency`,cur.`currency`,pnd.`kurs`
		        FROM tb_pn_fgpo_det pnd
		        INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo` AND pn.`is_open`='1' AND pn.`id_report_status`=6
		        INNER JOIN tb_lookup_currency cur ON cur.`id_currency`=pnd.`id_currency`
		        INNER JOIN tb_m_comp c ON c.id_comp=pn.id_comp " & where_string & "
		        GROUP BY pnd.`id_pn_fgpo`
	        ) det ON det.id_pn_fgpo=pn.`id_pn_fgpo` AND det.amount>0
	        LEFT JOIN
	        (
		        SELECT COUNT(pyd.id_report) AS jml,pyd.id_report FROM `tb_pn_det` pyd
		        INNER JOIN tb_pn py ON py.id_pn=pyd.id_pn AND py.id_report_status!=6 AND py.id_report_status!=5 AND py.report_mark_type='189'
		        GROUP BY pyd.id_report
	        )payment_pending ON payment_pending.id_report=pn.id_pn_fgpo
	        LEFT JOIN
	        (
		        SELECT pyd.id_report, SUM(pyd.`value`) AS `value` FROM `tb_pn_det` pyd
		        INNER JOIN tb_pn py ON py.id_pn=pyd.id_pn AND py.id_report_status!=5 AND pyd.report_mark_type='189'
		        GROUP BY pyd.id_report
	        )payment ON payment.id_report=pn.id_pn_fgpo
	        INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pn.id_report_status
	        WHERE pn.is_open=1 AND pn.id_report_status=6 AND pn.doc_type=4
        "

        GCDPKhusus.DataSource = execute_query(query, -1, True, "", "", "", "")

        GVDPKhusus.BestFitColumns()
    End Sub

    Private Sub BCreatePaymentDPKhusus_Click(sender As Object, e As EventArgs) Handles BCreatePaymentDPKhusus.Click
        GVDPKhusus.ActiveFilterString = ""
        GVDPKhusus.ActiveFilterString = "[is_check]='yes'"

        If GVDPKhusus.RowCount > 0 Then
            FormBankWithdrawalDet.TEKurs.EditValue = TEKursDPKhusus.EditValue
            FormBankWithdrawalDet.report_mark_type = "189"
            FormBankWithdrawalDet.ShowDialog()
        Else
            warningCustom("Please select item first.")
        End If

        GVDPKhusus.ActiveFilterString = ""
    End Sub

    Private Sub BViewPOOG_Click(sender As Object, e As EventArgs) Handles BViewPOOG.Click
        view_po_og()
    End Sub

    Sub view_po_og()
        Dim q As String = "SELECT po.`id_purc_order`,po.`purc_order_number`,emp.`employee_name` AS emp_created,c.comp_name,cc.`contact_person`,cc.`contact_number`,po.`date_created`
FROM tb_purc_order_det pod
INNER JOIN tb_purc_order po ON po.`id_purc_order`=pod.`id_purc_order` AND po.`id_report_status`=6
INNER JOIN tb_m_comp_contact cc ON po.`id_comp_contact`=cc.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN tb_m_user usr ON usr.`id_user`=po.`created_by`
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.`id_employee`
INNER JOIN tb_purc_req_det prd ON prd.`id_purc_req_det`=pod.`id_purc_req_det`
INNER JOIN tb_item it ON it.`id_item`=prd.`id_item`
WHERE po.`is_active_payment`=2 AND po.`is_close_pay`=2 AND po.is_close_rec='1'
GROUP BY pod.`id_purc_order`
ORDER BY pod.id_purc_order DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPO.DataSource = dt
        GVPO.BestFitColumns()
    End Sub

    Private Sub ViewBUMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewBUMToolStripMenuItem.Click
        If XTCPO.SelectedTabPage.Name = "XTPTHR" Then
            Dim id_acc_trans As String = ""
            Try
                id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type = 192 AND ad.id_report = " + GVTHR.GetFocusedRowCellValue("id_payroll").ToString + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
            Catch ex As Exception
                id_acc_trans = ""
            End Try

            If id_acc_trans <> "" Then
                Dim s As New ClassShowPopUp()
                FormViewJournal.is_enable_view_doc = False
                FormViewJournal.BMark.Visible = False
                s.id_report = id_acc_trans
                s.report_mark_type = "36"
                s.show()
            Else
                warningCustom("Auto journal not found.")
            End If
        End If
    End Sub

    Private Sub GVTHR_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVTHR.PopupMenuShowing
        ViewBUMToolStripMenuItem.Visible = True
    End Sub

    Private Sub GVFGPO_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVFGPO.PopupMenuShowing
        ViewBUMToolStripMenuItem.Visible = False
    End Sub

    Private Sub GVBPJSKesehatan_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVBPJSKesehatan.PopupMenuShowing
        ViewBUMToolStripMenuItem.Visible = False
    End Sub

    Private Sub GVJamsostek_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVJamsostek.PopupMenuShowing
        ViewBUMToolStripMenuItem.Visible = False
    End Sub

    Private Sub BCreateToday_Click(sender As Object, e As EventArgs) Handles BCreateToday.Click
        FormBankWithdrawalSum.ShowDialog()
    End Sub

    Sub view_sum()
        Dim q As String = "SELECT pns.`id_pn_summary`,sts.report_status,pns.number,pns.`date_payment`,pns.`created_date`,emp.`employee_name`, cur.`currency`,SUM(IFNULL(pnd.`val_bef_kurs`,0)) AS val_bef_kurs
FROM tb_pn_summary pns
LEFT JOIN tb_pn_summary_det pnsd ON pnsd.id_pn_summary=pns.id_pn_summary
LEFT JOIN tb_pn_det pnd ON pnd.`id_pn`=pnsd.`id_pn` AND pnd.`id_currency`=pns.`id_currency`
INNER JOIN tb_lookup_currency cur ON cur.`id_currency`=pns.`id_currency`
INNER JOIN tb_m_user usr ON usr.`id_user`=pns.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pns.id_report_status
WHERE DATE(pns.date_payment) >= '" & Date.Parse(DEFromSum.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(pns.date_payment) <= '" & Date.Parse(DEToSum.EditValue.ToString).ToString("yyyy-MM-dd") & "'
GROUP BY pns.`id_pn_summary`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCBBKSummary.DataSource = dt
        GVBBKSummary.BestFitColumns()
    End Sub

    Private Sub BViewBBKSum_Click(sender As Object, e As EventArgs) Handles BViewBBKSum.Click
        view_sum()
    End Sub

    Private Sub GVBBKSummary_DoubleClick(sender As Object, e As EventArgs) Handles GVBBKSummary.DoubleClick
        If GVBBKSummary.RowCount > 0 Then
            FormBankWithdrawalSum.id_sum = GVBBKSummary.GetFocusedRowCellValue("id_pn_summary").ToString
            FormBankWithdrawalSum.ShowDialog()
        End If
    End Sub

    Private Sub BBHistoryPaymentDate_Click(sender As Object, e As EventArgs) Handles BBHistoryPaymentDate.Click
        If GVList.RowCount > 0 Then
            FormBankWithdrawalLogPaymentDate.id_pn = GVList.GetFocusedRowCellValue("id_pn").ToString
            FormBankWithdrawalLogPaymentDate.ShowDialog()
        Else
            warningCustom("No BBK selected")
        End If
    End Sub

    Private Sub DEBBKFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEBBKFrom.EditValueChanged
        DEBBKTo.Properties.MinValue = DEBBKFrom.EditValue
    End Sub

    Private Sub BBuyValas_Click(sender As Object, e As EventArgs) Handles BBuyValas.Click

    End Sub

    Private Sub BInfoFGPO_Click(sender As Object, e As EventArgs) Handles BInfoFGPO.Click
        FormFGPOPaymentTracking.ShowDialog()
    End Sub

    Private Sub BtnViewSales_Click(sender As Object, e As EventArgs) Handles BtnViewSales.Click
        view_vs()
    End Sub

    Sub view_vs()
        Cursor = Cursors.WaitCursor
        Dim id_coa_tag As String = SLEUnit.EditValue.ToString
        Dim query As String = "SELECT *, 'no' AS `is_check` 
        FROM (
	        SELECT b.id_sales_branch, b.number, b.id_coa_tag,b.comp_rev_normal_note AS `note`,
	        IFNULL(pyd.total_pay,0) AS `total_pay`,b.comp_rev_normal-IFNULL(pyd.total_pay,0)-IFNULL(cn.amount_cn,0.00) AS `amount`, c.id_comp, c.comp_number, c.comp_name,
	        IFNULL(pyd.on_process,0) AS `on_process`, b.report_mark_type,
            coa.id_acc, coa.acc_name, coa.acc_description
	        FROM tb_sales_branch b 
	        INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp_normal
            INNER JOIN tb_a_acc coa ON coa.id_acc = comp_rev_normal_acc
	        LEFT JOIN (
	          SELECT rd.id_report, rd.vendor , SUM(rd.value) AS `total_pay`, 
	          COUNT(IF(r.id_report_status<5,1,NULL)) AS `on_process`
	          FROM tb_pn_det rd
	          INNER JOIN tb_pn r ON r.id_pn = rd.id_pn
	          WHERE r.id_report_status!=5 AND rd.report_mark_type=254 
	          GROUP BY rd.id_report, rd.vendor
	        ) pyd ON pyd.id_report = b.id_sales_branch AND pyd.vendor = c.comp_number
	        LEFT JOIN (
	          SELECT m.id_sales_branch_ref, c.comp_number, SUM(m.comp_rev_normal) AS `amount_cn`, 
	          COUNT(IF(m.id_report_status<5,1,NULL)) AS `total_cn_pending`
	          FROM tb_sales_branch m
	          INNER JOIN tb_m_comp c ON c.id_comp = m.id_comp_normal
	          WHERE m.id_report_status!=5 
	          GROUP BY m.id_sales_branch_ref, c.comp_number
	        ) cn ON cn.id_sales_branch_ref = b.id_sales_branch AND cn.comp_number = c.comp_number
	        WHERE b.id_report_status=6 AND b.id_memo_type=1
	        GROUP BY b.id_sales_branch
	        UNION ALL
	        SELECT b.id_sales_branch,b.number, b.id_coa_tag, b.comp_rev_normal_note AS `note`,
	        IFNULL(pyd.total_pay,0) AS `total_pay`, b.comp_rev_sale-IFNULL(pyd.total_pay,0)-IFNULL(cn.amount_cn,0.00) AS `amount`, c.id_comp, c.comp_number, c.comp_name,
	        IFNULL(pyd.on_process,0) AS `on_process`,b.report_mark_type,
            coa.id_acc, coa.acc_name, coa.acc_description
	        FROM tb_sales_branch b 
	        INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp_sale
            INNER JOIN tb_a_acc coa ON coa.id_acc = comp_rev_sale_acc
	        LEFT JOIN (
	          SELECT rd.id_report, rd.vendor , SUM(rd.value) AS `total_pay`, 
	          COUNT(IF(r.id_report_status<5,1,NULL)) AS `on_process`
	          FROM tb_pn_det rd
	          INNER JOIN tb_pn r ON r.id_pn = rd.id_pn
	          WHERE r.id_report_status!=5 AND rd.report_mark_type=254 
	          GROUP BY rd.id_report, rd.vendor
	        ) pyd ON pyd.id_report = b.id_sales_branch AND pyd.vendor = c.comp_number
	        LEFT JOIN (
	          SELECT m.id_sales_branch_ref, c.comp_number, SUM(m.comp_rev_sale) AS `amount_cn`, 
	          COUNT(IF(m.id_report_status<5,1,NULL)) AS `total_cn_pending`
	          FROM tb_sales_branch m
	          INNER JOIN tb_m_comp c ON c.id_comp = m.id_comp_sale
	          WHERE m.id_report_status!=5 
	          GROUP BY m.id_sales_branch_ref, c.comp_number
	        ) cn ON cn.id_sales_branch_ref = b.id_sales_branch AND cn.comp_number = c.comp_number
	        WHERE b.id_report_status=6 AND b.id_memo_type=1
	        GROUP BY b.id_sales_branch
        ) a 
        HAVING id_coa_tag='" + id_coa_tag + "' AND amount>0
        ORDER BY id_sales_branch ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSales.DataSource = data
        GVSales.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCreateBBKVS_Click(sender As Object, e As EventArgs) Handles BtnCreateBBKVS.Click
        GVSales.ActiveFilterString = ""
        GVSales.ActiveFilterString = "[is_check]='yes'"

        If GVSales.RowCount > 0 Then
            FormBankWithdrawalDet.id_coa_tag = SLEUnit.EditValue.ToString
            FormBankWithdrawalDet.report_mark_type = "254"
            FormBankWithdrawalDet.ShowDialog()
        Else
            warningCustom("Please select item first.")
        End If

        GVSales.ActiveFilterString = ""
    End Sub
End Class