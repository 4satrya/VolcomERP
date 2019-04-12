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

    Private Sub FormBankWithdrawal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()
        load_trans_type()
        load_status_payment()

        load_trans_type_po()
        load_vendor_po()
        load_vendor_expense()
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
        Dim query As String = "SELECT cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'
                                WHERE c.id_comp_cat='8'"
        viewSearchLookupQuery(SLEVendor, query, "id_comp_contact", "comp_name", "id_comp_contact")
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
        End If

        If Not SLEPayTypePayment.EditValue.ToString = "0" Then
            where_string = " AND py.id_pay_type='" & SLEPayTypePayment.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT py.number,sts.report_status,emp.employee_name AS created_by, py.date_created, py.`id_payment`,py.`value` ,CONCAT(c.`comp_number`,' - ',c.`comp_name`) AS comp_name,rm.`report_mark_type_name`,pt.`pay_type`,py.note
FROM tb_payment py
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=py.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN `tb_lookup_report_mark_type` rm ON rm.`report_mark_type`=py.`report_mark_type`
INNER JOIN `tb_lookup_pay_type` pt ON pt.`id_pay_type`=py.`id_pay_type`
INNER JOIN tb_m_user usr ON usr.id_user=py.id_user_created
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=py.id_report_status
WHERE 1=1 " & where_string & " ORDER BY py.id_payment DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        GVList.BestFitColumns()
    End Sub

    Sub load_po()
        Dim where_string As String = ""
        Dim having_string As String = ""

        If Not SLEVendor.EditValue.ToString = "0" Then
            where_string = " AND po.id_comp_contact='" & SLEVendor.EditValue.ToString & "'"
        End If

        If SLEPayType.EditValue.ToString = "2" Then
            where_string = " AND po.is_close_rec='1'"
        End If

        id_pay_type_po = SLEPayType.EditValue.ToString

        If SLEStatusPayment.EditValue.ToString = "0" Then 'open include overdue and only dp
            'having_string = " HAVING total_due>0"
            where_string += " AND po.is_close_pay=2 "
            BCreatePO.Visible = True
        ElseIf SLEStatusPayment.EditValue.ToString = "1" Then 'paid
            where_string += " AND po.is_close_pay=1 "
            'having_string = " HAVING total_due=0"
            BCreatePO.Visible = False
        ElseIf SLEStatusPayment.EditValue.ToString = "2" Then 'overdue
            'having_string = " is_cl"
            where_string += " AND po.pay_due_date < DATE(NOW()) AND po.is_close_pay=2 "
            BCreatePO.Visible = True
        ElseIf SLEStatusPayment.EditValue.ToString = "3" Then 'overdue H-7
            where_string += " AND DATE_SUB(po.pay_due_date, INTERVAL 7 DAYS) < DATE(NOW()) AND po.is_close_pay=2 "
            BCreatePO.Visible = True
        End If

        Dim query As String = "SELECT 'no' AS is_check,po.is_close_pay,po.pay_due_date,po.id_purc_order,c.comp_number,c.comp_name,cc.contact_person,cc.contact_number,po.purc_order_number,po.date_created,emp_cre.employee_name AS emp_created,po.last_update,emp_upd.employee_name AS emp_updated,po.note
,SUM(pod.qty) AS qty_po,(SUM(pod.qty*(pod.value-pod.discount))-po.disc_value+po.vat_value) AS total_po
,IFNULL(SUM(rec.qty),0) AS qty_rec,IF(ISNULL(rec.id_purc_order_det),0,SUM(rec.qty*(pod.value-pod.discount))-(SUM(rec.qty*(pod.value-pod.discount))/SUM(pod.qty*(pod.value-pod.discount))*po.disc_value)+(SUM(rec.qty*(pod.value-pod.discount))/SUM(pod.qty*(pod.value-pod.discount))*po.vat_value)) AS total_rec
,(IFNULL(SUM(rec.qty*pod.value),0)/SUM(pod.qty*pod.value))*100 AS rec_progress,IF(po.is_close_rec=1,'Closed',IF((IFNULL(SUM(rec.qty),0)/SUM(pod.qty))<=0,'Waiting',IF((IFNULL(SUM(rec.qty),0)/SUM(pod.qty))<1,'Partial','Complete'))) AS rec_status
,po.close_rec_reason
,IFNULL(payment.value,0) AS val_pay
,IF(po.is_close_rec=1,
	IF(ISNULL(rec.id_purc_order_det),0,SUM(rec.qty*(pod.value-pod.discount))-(SUM(rec.qty*(pod.value-pod.discount))/SUM(pod.qty*(pod.value-pod.discount))*po.disc_value)+(SUM(rec.qty*(pod.value-pod.discount))/SUM(pod.qty*(pod.value-pod.discount))*po.vat_value))
	,(SUM(pod.qty*(pod.value-pod.discount))-po.disc_value+po.vat_value))-IFNULL(payment.value,0) AS total_due
,IFNULL(payment_dp.value,0) as total_dp
,IFNULL(payment_pending.jml,0) as total_pending
,DATEDIFF(po.`pay_due_date`,NOW()) AS due_days
FROM tb_purc_order po
INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order`=po.`id_purc_order`
INNER JOIN tb_m_user usr_cre ON usr_cre.id_user=po.created_by
INNER JOIN tb_m_employee emp_cre ON emp_cre.id_employee=usr_cre.id_employee
INNER JOIN tb_m_user usr_upd ON usr_upd.id_user=po.last_update_by
INNER JOIN tb_m_employee emp_upd ON emp_upd.id_employee=usr_upd.id_employee
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=po.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
LEFT JOIN 
( 
	SELECT recd.`id_purc_order_det`,SUM(recd.`qty`) AS qty FROM tb_purc_rec_det recd 
	INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec`=recd.`id_purc_rec` AND rec.`id_report_status`='6'
	GROUP BY recd.`id_purc_order_det`
) rec ON rec.id_purc_order_det=pod.`id_purc_order_det`
LEFT JOIN
(
	SELECT pyd.id_report, SUM(pyd.`value`) AS `value` FROM `tb_payment_det` pyd
	INNER JOIN tb_payment py ON py.id_payment=pyd.id_payment AND py.id_report_status!=5 AND py.report_mark_type='139'
	GROUP BY pyd.id_report
)payment ON payment.id_report=po.id_purc_order
LEFT JOIN
(
	SELECT pyd.id_report, SUM(pyd.`value`) AS `value` FROM `tb_payment_det` pyd
	INNER JOIN tb_payment py ON py.id_payment=pyd.id_payment AND py.id_report_status!=5 AND py.report_mark_type='139' AND py.id_pay_type=1
	GROUP BY pyd.id_report
)payment_dp ON payment_dp.id_report=po.id_purc_order
LEFT JOIN
(
	SELECT COUNT(pyd.id_report) as jml,pyd.id_report FROM `tb_payment_det` pyd
	INNER JOIN tb_payment py ON py.id_payment=pyd.id_payment AND py.id_report_status!=6 AND py.id_report_status!=5 AND py.report_mark_type='139'
	GROUP BY pyd.id_report
)payment_pending ON payment_pending.id_report=po.id_purc_order
WHERE 1=1 " & where_string & " GROUP BY po.id_purc_order " & having_string
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPOList.DataSource = data
        GVPOList.BestFitColumns()
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_po()
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
                '
                If GVPOList.RowCount > 0 Then
                    FormBankWithdrawalDet.report_mark_type = "139"
                    FormBankWithdrawalDet.id_pay_type = id_pay_type_po
                    FormBankWithdrawalDet.ShowDialog()
                Else
                    warningCustom("No data selected")
                End If
            ElseIf id_pay_type_po = "2" Then 'payment
                If GVPOList.RowCount > 0 Then
                    FormBankWithdrawalDet.report_mark_type = "139"
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
            FormBankWithdrawalDet.id_payment = GVList.GetFocusedRowCellValue("id_payment")
            FormBankWithdrawalDet.ShowDialog()
        End If
    End Sub

    Private Sub BtnViewExpense_Click(sender As Object, e As EventArgs) Handles BtnViewExpense.Click
        load_expense()
    End Sub

    Sub load_expense()
        Cursor = Cursors.WaitCursor

        Dim where_string As String = ""
        Dim having_string As String = ""
        If Not SLEVendorExpense.EditValue.ToString = "0" Then
            where_string = "AND e.id_comp='" & SLEVendorExpense.EditValue.ToString & "' "
        End If

        If SLEStatusPaymentExpense.EditValue.ToString = "0" Then 'open include overdue and only dp\
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
End Class