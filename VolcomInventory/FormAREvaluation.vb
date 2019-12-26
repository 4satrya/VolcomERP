﻿Public Class FormAREvaluation
    Public eval_date As String = ""

    Private Sub FormAREvaluation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'get last evaluation
        Dim query As String = "SELECT DATE_FORMAT(MAX(a.eval_date),'%Y-%m-%d %H:%i:%s') AS `last_eval_date`,
        DATE_FORMAT(MAX(a.eval_date),'%d %M %Y %H:%i:%s') AS `last_eval_date_label`
        FROM tb_ar_eval a "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        eval_date = data.Rows(0)("last_eval_date").ToString
        BtnBrowseEval.Text = data.Rows(0)("last_eval_date_label").ToString
    End Sub

    Private Sub FormAREvaluation_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnViewData_Click(sender As Object, e As EventArgs) Handles BtnViewData.Click
        If XTCData.SelectedTabPageIndex = 1 Then
            viewInvoiceDetail()
        ElseIf XTCData.SelectedTabPageIndex = 2 Then
            viewCompGroup()
        End If
    End Sub

    Sub viewInvoiceDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT e.id_comp_group, cg.description AS `group_store`, 
        e.id_sales_pos AS `id_inv`, e.report_number AS `inv_number`, e.report_mark_type AS `inv_rmt`,
        CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) AS `inv_amount`,
        IF(e.is_paid=1,'Paid', 'Not Paid') AS `paid_status`, 
        IFNULL(m.id_propose_delay_payment,0) AS `id_propose_delay_payment`, m.number as `memo_number`,
        e.release_date, e.note, IF(e.is_active=1,'Active', 'Not Active') AS `active_status`
        FROM tb_ar_eval e 
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = e.id_sales_pos
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
        LEFT JOIN tb_rec_payment bbm ON bbm.id_rec_payment = e.id_rec_payment
        LEFT JOIN tb_propose_delay_payment_det md ON md.id_propose_delay_payment_det = e.id_propose_delay_payment_det
        LEFT JOIN tb_propose_delay_payment m ON m.id_propose_delay_payment  = md.id_propose_delay_payment
        WHERE e.eval_date='" + eval_date + "'
        ORDER BY e.id_sales_pos ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCInvoiceDetail.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewCompGroup()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT e.id_comp_group, cg.description AS `group_store`, 
        COUNT(e.id_sales_pos) AS `inv`,
        COUNT(sp.id_sales_pos), IFNULL(p.paid,0) AS `paid`
        FROM tb_ar_eval e 
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = e.id_sales_pos
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
        LEFT JOIN (
	        SELECT e.id_comp_group, COUNT(e.id_sales_pos) AS `paid` FROM tb_ar_eval e 
	        WHERE e.eval_date='" + eval_date + "' AND e.is_paid=1
	        GROUP BY e.id_comp_group 
        ) p ON e.id_comp_group = p.id_comp_group
        WHERE e.eval_date='" + eval_date + "'
        GROUP BY e.id_comp_group "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCGroup.DataSource = data
        GVGroup.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowseEval_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BtnBrowseEval.ButtonClick
        Cursor = Cursors.WaitCursor
        FormAREvaluationPickDate.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub RepoLinkInvoice_Click(sender As Object, e As EventArgs) Handles RepoLinkInvoice.Click
        If GVInvoiceDetail.RowCount > 0 And GVInvoiceDetail.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim inv As New ClassShowPopUp()
            inv.id_report = GVInvoiceDetail.GetFocusedRowCellValue("id_inv").ToString
            inv.report_mark_type = GVInvoiceDetail.GetFocusedRowCellValue("inv_rmt").ToString
            inv.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoBtnBBM_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepoBtnBBM.ButtonClick
        If GVInvoiceDetail.RowCount > 0 And GVInvoiceDetail.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormInvoiceTrackingBBM.Text = FormInvoiceTrackingBBM.Text + " " + GVInvoiceDetail.GetFocusedRowCellValue("inv_number").ToString
            FormInvoiceTrackingBBM.rmt = GVInvoiceDetail.GetFocusedRowCellValue("inv_rmt").ToString
            FormInvoiceTrackingBBM.id_report = GVInvoiceDetail.GetFocusedRowCellValue("id_inv").ToString
            FormInvoiceTrackingBBM.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnEvaluation_Click(sender As Object, e As EventArgs) 
        Dim tgl As String = execute_query("SELECT DATE_FORMAT(NOW(),'%Y-%m-%d %H:%i:%s') AS `eval_date`", 0, True, "", "", "", "")
        Try
            Dim query As String = "CALL getEvaluationAR('" + tgl + "');"
            execute_non_query(query, True, "", "", "", "")
            execute_non_query("INSERT tb_ar_eval_log(eval_date, log_time, log) VALUES('" + tgl + "',NOW(), 'Evaluation Success');", True, "", "", "", "")
            infoCustom("Evaluation Success")
        Catch ex As Exception
            execute_non_query("INSERT tb_ar_eval_log(eval_date, log_time, log) VALUES('" + tgl + "',NOW(), '" + addSlashes(ex.ToString) + "');", True, "", "", "", "")
        End Try
    End Sub

    Private Sub RepoLinkMemo_Click(sender As Object, e As EventArgs) Handles RepoLinkMemo.Click
        If GVInvoiceDetail.RowCount > 0 And GVInvoiceDetail.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_memo As String = GVInvoiceDetail.GetFocusedRowCellValue("id_propose_delay_payment").ToString
            If id_memo <> "0" Then
                Dim inv As New ClassShowPopUp()
                inv.id_report = id_memo
                inv.report_mark_type = "233"
                inv.show()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub XTCData_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCData.SelectedPageChanged
        If XTCData.SelectedTabPageIndex = 0 Then
            PanelNav.Visible = False
        ElseIf XTCData.SelectedTabPageIndex = 1 Then
            PanelNav.Visible = True
        ElseIf XTCData.SelectedTabPageIndex = 2 Then
            PanelNav.Visible = True
        End If
    End Sub
End Class