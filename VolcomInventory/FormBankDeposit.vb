Public Class FormBankDeposit
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Dim id_pay_type_po As String = "-1"
    Dim id_own_online_store As String = ""
    '
    Private Sub FormBankDeposit_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormBankDeposit_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        If XTCPO.SelectedTabPageIndex = 0 Then
            If GVList.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub FormBankDeposit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt_now As DataTable = execute_query("SELECT DATE(NOW()) as tgl", -1, True, "", "", "", "")
        DEFromList.EditValue = dt_now.Rows(0)("tgl")
        DEUntilList.EditValue = dt_now.Rows(0)("tgl")

        'get id own online store
        id_own_online_store = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_store) FROM tb_m_comp_volcom_ol c", 0, True, "", "", "", "")

        load_vendor()
        load_status_payment()

        'invoice list
        load_group_store()

        'payout
        load_payout()

        'VS sales
        viewCoaTag()
        viewCoaTagAll()
        load_status_sales()
    End Sub

    Sub load_status_payment()
        Dim query As String = "SELECT 1 AS id_status_payment,'Open' AS status_payment
UNION
SELECT 2 AS id_status_payment,'Full Received' AS status_payment
UNION
SELECT 3 AS id_status_payment,'Overdue' AS status_payment
UNION
SELECT 4 AS id_status_payment,'Overdue H-7' AS status_payment"
        viewSearchLookupQuery(SLEStatusInvoice, query, "id_status_payment", "status_payment", "id_status_payment")
    End Sub

    Sub load_status_sales()
        Dim query As String = "SELECT 1 AS id_status_payment,'Close' AS status_payment
        UNION
        SELECT 2 AS id_status_payment,'Open' AS status_payment 
        ORDER BY id_status_payment DESC "
        viewSearchLookupQuery(SLEStatusSales, query, "id_status_payment", "status_payment", "id_status_payment")
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT 0 AS id_comp_contact,'All' as comp_name
UNION
SELECT cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'
                                WHERE c.id_comp_cat='6' "
        viewSearchLookupQuery(SLEStoreDeposit, query, "id_comp_contact", "comp_name", "id_comp_contact")
    End Sub

    Sub load_group_store()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS id_comp_group, 'All' AS comp_group, 'All Group' AS description 
        UNION
        SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg "
        viewSearchLookupQuery(SLEStoreGroup, query, "id_comp_group", "comp_group", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub load_vendor_po()
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


        Dim query As String = "SELECT 0 AS id_comp_contact,'All' as comp_name
        UNION
        SELECT cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'
                                WHERE c.id_comp_cat='6' " + cond_group + " AND c.id_comp NOT IN (" + id_own_online_store + ") "
        viewSearchLookupQuery(SLEStoreInvoice, query, "id_comp_contact", "comp_name", "id_comp_contact")
        Cursor = Cursors.Default
    End Sub

    Sub load_deposit()
        Dim where_string As String = ""

        If Not SLEStoreDeposit.EditValue.ToString = "0" Then
            where_string = " AND rec_py.id_comp_contact='" & SLEStoreDeposit.EditValue.ToString & "'"
        End If

        If SLEUnitView.EditValue.ToString <> "0" Then
            where_string += " AND rec_py.id_coa_tag='" + SLEUnitView.EditValue.ToString + "'"
        End If

        'date
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromList.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilList.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        where_string += " AND (DATE(date_created)>='" + date_from_selected + "' AND DATE(date_created)<='" + date_until_selected + "') "

        'Left Join tb_m_comp_contact cc ON cc.`id_comp_contact`=rec_py.`id_comp_contact`
        'Left Join tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        ',CONCAT(c.`comp_number`,' - ',c.`comp_name`) AS comp_name
        Dim query As String = "SELECT rec_py.number,sts.report_status,emp.employee_name AS created_by, rec_py.date_created, rec_py.date_received, rec_py.val_need_pay, rec_py.`id_rec_payment`,rec_py.`value` ,rec_py.note, la.employee_name AS `last_approved_by`, t.tag_description AS `unit`
FROM tb_rec_payment rec_py
INNER JOIN tb_m_user usr ON usr.id_user=rec_py.id_user_created
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=rec_py.id_report_status
LEFT JOIN (
	SELECT a.id_report, a.id_user, a.username, a.employee_name 
	FROM (
		SELECT rm.id_report, rm.id_user, u.username, e.employee_name
		FROM tb_report_mark rm 
		INNER JOIN tb_m_user u ON u.id_user = rm.id_user
		INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
		WHERE (rm.report_mark_type=162) AND rm.id_report_status>1 AND rm.id_mark=2
		ORDER BY rm.report_mark_datetime DESC
	) a
	GROUP BY a.id_report
) la ON la.id_report = rec_py.`id_rec_payment`
INNER JOIN tb_coa_tag t ON t.id_coa_tag = rec_py.id_coa_tag
WHERE 1=1 " & where_string & " ORDER BY rec_py.id_rec_payment DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        GVList.BestFitColumns()
    End Sub

    Sub load_invoice()
        Dim where_string As String = ""

        If Not SLEStoreGroup.EditValue.ToString = "0" Then
            where_string += " AND c.id_comp_group='" + SLEStoreGroup.EditValue.ToString + "'"
        End If

        If Not SLEStoreInvoice.EditValue.ToString = "0" Then
            where_string += " AND cc.id_comp_contact='" & SLEStoreInvoice.EditValue.ToString & "'"
        End If

        If SLEStatusInvoice.EditValue.ToString = "1" Then 'All open
            where_string += " AND sp.is_close_rec_payment='2'"
        ElseIf SLEStatusInvoice.EditValue.ToString = "2" Then 'closed
            where_string += " AND sp.is_close_rec_payment='1'"
        ElseIf SLEStatusInvoice.EditValue.ToString = "3" Then 'open overdue
            where_string += " AND sp.is_close_rec_payment='2' AND sp.sales_pos_due_date<DATE(NOW())"
        ElseIf SLEStatusInvoice.EditValue.ToString = "3" Then 'open overdue H-7
            where_string += " AND sp.is_close_rec_payment='2' AND DATE_SUB(sp.sales_pos_due_date, INTERVAL 7 DAY)<DATE(NOW())"
        End If

        Dim var_acc As String = "IFNULL(sp.id_acc_ar,0)"
        Dim query As String = "SELECT 'no' AS is_check,sp.is_close_rec_payment,sp.`id_sales_pos`,sp.sales_pos_note,sp.`sales_pos_number`,sp.`id_memo_type`,typ.`memo_type`,typ.`is_receive_payment`,sp.`sales_pos_date`,sp.`id_store_contact_from`, c.id_comp,c.comp_number,c.`comp_name`, cg.comp_group,sp.`sales_pos_due_date`,CONCAT(DATE_FORMAT(sp.`sales_pos_start_period`,'%d %M %Y'),' - ',DATE_FORMAT(sp.`sales_pos_end_period`,'%d %M %Y')) AS period
        ,sp.`sales_pos_total`,sp.`sales_pos_discount`,sp.`sales_pos_vat`,sp.`sales_pos_potongan`,CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) AS amount
        ,sp.report_mark_type,rmt.report_mark_type_name,IFNULL(pyd.`value`,0.00) AS total_rec,CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))-IFNULL(pyd.`value`,0.00) AS total_due
        ,IFNULL(pyd.total_pending,0) AS `total_pending`
        ,DATEDIFF(sp.`sales_pos_due_date`,NOW()) AS due_days,
        " + var_acc + " AS `id_acc`, coa.acc_name, coa.acc_description,
        IF(typ.`is_receive_payment`=2,1,2) AS `id_dc`, IF(typ.`is_receive_payment`=2,'D','K') AS `dc_code`,
        CONCAT(c.comp_name,' Per ', DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y')) AS `note`,
        cf.id_comp AS `id_comp_default`, cf.comp_number as `comp_number_default`
        FROM tb_sales_pos sp 
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
        LEFT JOIN tb_a_acc coa ON coa.id_acc = " + var_acc + "
        INNER JOIN tb_m_comp cf ON cf.id_comp=1
        WHERE sp.`id_report_status`='6' " & where_string & " 
        AND c.id_comp NOT IN (" + id_own_online_store + ")
        GROUP BY sp.`id_sales_pos`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCInvoiceList.DataSource = data
        GVInvoiceList.BestFitColumns()
    End Sub

    Sub load_payout()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT t.id_list_payout_trans, t.number, SUM(p.payment) AS `amount`, SUM(p.trans_fee) AS `trans_fee`, SUM(p.payment)-SUM(p.trans_fee) AS `nett`
        FROM tb_list_payout_trans t
        INNER JOIN tb_list_payout p ON p.id_list_payout_trans = t.id_list_payout_trans
        LEFT JOIN tb_rec_payment b ON b.id_list_payout_trans = t.id_list_payout_trans AND b.id_report_status!=5
        WHERE ISNULL(b.id_rec_payment)
        GROUP BY p.id_list_payout_trans "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPayout.DataSource = data
        GVPayout.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewCoaTag()
        Dim query As String = "SELECT ct.id_coa_tag, ct.tag_code, ct.tag_description, CONCAT(ct.tag_code,' - ', ct.tag_description)  AS `coa_tag`
        FROM tb_coa_tag ct WHERE ct.id_coa_tag>1 ORDER BY ct.id_coa_tag ASC "
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
    End Sub

    Sub viewCoaTagAll()
        Dim query As String = "
        SELECT 0 AS id_coa_tag, 'All' AS `tag_code`, 'All' AS `tag_description`, 'All' AS `coa_tag`
        UNION
        SELECT ct.id_coa_tag, ct.tag_code, ct.tag_description, CONCAT(ct.tag_code,' - ', ct.tag_description)  AS `coa_tag`
        FROM tb_coa_tag ct ORDER BY id_coa_tag ASC "
        viewSearchLookupQuery(SLEUnitView, query, "id_coa_tag", "tag_description", "id_coa_tag")
    End Sub

    Sub load_sales()
        Cursor = Cursors.WaitCursor

        'get company tag
        Dim id_comp_tag As String = execute_query("SELECT id_comp FROM tb_coa_tag WHERE id_coa_tag='" + SLEUnit.EditValue.ToString + "'", 0, True, "", "", "", "")

        Dim query As String = "SELECT 'no' AS `is_select`,d.id_sales_branch_det AS `id_report_det`,d.id_sales_branch AS `id_report`,rmt.report_mark_type, rmt.report_mark_type_name, m.number AS `report_number`,
        d.id_acc, coa.acc_name , coa.acc_description, d.id_comp, comp.comp_number, d.vendor, 2 AS `id_dc`, 'K' AS `dc_code`, d.note,
        d.value AS `amount`, IFNULL(pyd.total_rec,0.00) AS `total_rec`, (d.value - IFNULL(pyd.total_rec,0)) AS `total_due`, IFNULL(pyd.on_process,0) AS `total_pending`
        FROM tb_sales_branch_det d
        INNER JOIN tb_sales_branch m ON m.id_sales_branch = d.id_sales_branch
        INNER JOIN tb_a_acc coa ON coa.id_acc = d.id_acc
        INNER JOIN tb_m_comp comp ON comp.id_comp = " + id_comp_tag + "
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type = 254
        LEFT JOIN (
	        SELECT rd.id_report_det , SUM(rd.value) AS `total_rec`, COUNT(IF(r.id_report_status<5,1,NULL)) AS `on_process`
	        FROM tb_rec_payment_det rd
	        INNER JOIN tb_rec_payment r ON r.id_rec_payment = rd.id_rec_payment
	        WHERE r.id_report_status!=5 AND rd.report_mark_type=254
	        GROUP BY rd.id_report_det
        ) pyd ON pyd.id_report_det = d.id_sales_branch_det
        WHERE m.id_report_status=6 AND d.id_dc=1 AND d.is_close='" + SLEStatusSales.EditValue.ToString + "' AND m.id_coa_tag='" + SLEUnit.EditValue.ToString + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSales.DataSource = data
        GVSales.ExpandAllGroups()
        GVSales.BestFitColumns()
        If SLEStatusSales.EditValue.ToString = "2" And GVSales.RowCount > 0 Then
            BtnCreateBBMforVS.Visible = True
        Else
            BtnCreateBBMforVS.Visible = False
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVInvoiceList_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVInvoiceList.RowStyle
        Try
            If GVInvoiceList.GetRowCellValue(e.RowHandle, "is_close_rec_payment") = "2" Then
                If GVInvoiceList.GetRowCellValue(e.RowHandle, "due_days") < 0 Then 'passed H
                    e.Appearance.BackColor = Color.Crimson
                    e.Appearance.ForeColor = Color.White
                    e.Appearance.FontStyleDelta = FontStyle.Bold
                ElseIf GVInvoiceList.GetRowCellValue(e.RowHandle, "due_days") < 7 Then 'H -7
                    e.Appearance.BackColor = Color.Yellow
                    e.Appearance.ForeColor = Color.Black
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        Cursor = Cursors.WaitCursor
        load_invoice()
        Cursor = Cursors.Default
    End Sub

    Private Sub BCreatePO_Click(sender As Object, e As EventArgs) Handles BCreatePO.Click
        makeSafeGV(GVInvoiceList)

        'check pending doc
        GVInvoiceList.ActiveFilterString = "[is_check]='yes' AND [total_pending]>0"
        If GVInvoiceList.RowCount > 0 Then
            Dim err_pending As String = ""
            For i As Integer = 0 To GVInvoiceList.RowCount - 1
                If i > 0 Then
                    err_pending += System.Environment.NewLine
                End If
                err_pending += "- " + GVInvoiceList.GetRowCellValue(i, "sales_pos_number").ToString
            Next
            warningCustom("Please process all pending receive payment for invoice number : " + System.Environment.NewLine + err_pending)
            GVInvoiceList.ActiveFilterString = ""
            Exit Sub
        End If

        'check coa
        makeSafeGV(GVInvoiceList)
        GVInvoiceList.ActiveFilterString = "[is_check]='yes' AND [id_acc]=0"
        If GVInvoiceList.RowCount > 0 Then
            Dim err_coa As String = ""
            For i As Integer = 0 To GVInvoiceList.RowCount - 1
                If i > 0 Then
                    err_coa += System.Environment.NewLine
                End If
                err_coa += "- " + GVInvoiceList.GetRowCellValue(i, "sales_pos_number").ToString
            Next
            warningCustom("AR account not found for invoice number : " + System.Environment.NewLine + err_coa)
            GVInvoiceList.ActiveFilterString = ""
            Exit Sub
        End If

        'process
        GVInvoiceList.ActiveFilterString = "[is_check]='yes'"
        If GVInvoiceList.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            FormBankDepositDet.ShowDialog()
            Cursor = Cursors.Default
        Else
            warningCustom("No data selected")
        End If
        GVInvoiceList.ActiveFilterString = ""
    End Sub

    Private Sub BViewPayment_Click(sender As Object, e As EventArgs) Handles BViewPayment.Click
        load_deposit()
        check_menu()
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        If GVList.RowCount > 0 And GVList.FocusedRowHandle >= 0 Then
            FormBankDepositDet.id_deposit = GVList.GetFocusedRowCellValue("id_rec_payment")
            FormBankDepositDet.ShowDialog()
        End If
    End Sub

    Private Sub SLEStoreGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreGroup.EditValueChanged
        load_vendor_po()
    End Sub

    Private Sub XTCPO_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPO.SelectedPageChanged
        check_menu()
        If XTCPO.SelectedTabPageIndex = 0 Then
            GCInvoiceList.DataSource = Nothing
            GCPayout.DataSource = Nothing
            resetViewSales()
        End If
    End Sub

    Private Sub BImportPayout_Click(sender As Object, e As EventArgs) Handles BImportPayout.Click
        Cursor = Cursors.WaitCursor
        Dim numb As String = addSlashes(TEPayoutNumber.Text).Trim
        If numb = "" Then
            warningCustom("Please input payout number")
            Cursor = Cursors.Default
        Else
            'cek di table
            Dim query As String = "SELECT * FROM tb_list_payout_trans p WHERE p.number='" + numb + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                warningCustom("Payout already exist")
                Cursor = Cursors.Default
            Else
                FormImportExcel.id_pop_up = "50"
                FormImportExcel.ShowDialog()
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If GVPayout.RowCount > 0 And GVPayout.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormBankDepositDet.id_list_payout_trans = GVPayout.GetFocusedRowCellValue("id_list_payout_trans").ToString
            FormBankDepositDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVPayout_DoubleClick(sender As Object, e As EventArgs) Handles GVPayout.DoubleClick
        If GVPayout.RowCount > 0 And GVPayout.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormPayoutHistoryDetail.id = GVPayout.GetFocusedRowCellValue("id_list_payout_trans").ToString
            FormPayoutHistoryDetail.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnHistoryPayout_Click(sender As Object, e As EventArgs) Handles BtnHistoryPayout.Click
        Cursor = Cursors.WaitCursor
        FormPayoutHistory.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        load_sales()
    End Sub

    Private Sub BtnCreateBBMforVS_Click(sender As Object, e As EventArgs) Handles BtnCreateBBMforVS.Click
        makeSafeGV(GVSales)

        'check pending doc
        GVSales.ActiveFilterString = "[is_select]='yes' AND [total_pending]>0"
        If GVSales.RowCount > 0 Then
            Dim err_pending As String = ""
            For i As Integer = 0 To GVSales.RowCount - 1
                If i > 0 Then
                    err_pending += System.Environment.NewLine
                End If
                err_pending += "- " + GVSales.GetRowCellValue(i, "report_number").ToString
            Next
            warningCustom("Please process all pending receive payment for invoice number : " + System.Environment.NewLine + err_pending)
            GVSales.ActiveFilterString = ""
            Exit Sub
        End If

        'process
        GVSales.ActiveFilterString = "[is_select]='yes'"
        If GVSales.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            FormBankDepositDet.id_coa_tag = SLEUnit.EditValue.ToString
            FormBankDepositDet.type_rec = "3"
            FormBankDepositDet.ShowDialog()
            Cursor = Cursors.Default
        Else
            warningCustom("No data selected")
        End If
        GVSales.ActiveFilterString = ""
    End Sub

    Private Sub SLEUnit_EditValueChanged(sender As Object, e As EventArgs) Handles SLEUnit.EditValueChanged
        resetViewSales()
    End Sub

    Private Sub SLEStatusSales_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStatusSales.EditValueChanged
        resetViewSales()
    End Sub

    Sub resetViewSales()
        GCSales.DataSource = Nothing
        BtnCreateBBMforVS.Visible = False
    End Sub
End Class