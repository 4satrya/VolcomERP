Public Class FormBankWithdrawalAttachement
    Public id_purc_order As String = "-1"

    Private Sub FormBankWithdrawalAttachement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'load pph account
        Dim query_pph As String = "(SELECT 0 AS id_acc, '' AS acc_name, '' AS acc_description, '' AS acc) UNION (SELECT id_acc, acc_name, acc_description, CONCAT(acc_name, ' - ', acc_description) as acc FROM tb_a_acc WHERE id_status = 1 AND id_is_det = 2)"
        viewSearchLookupQuery(SLEPPHAccount, query_pph, "id_acc", "acc", "id_acc")

        SLEPPHAccount.EditValue = "0"

        Dim query As String = "
            SELECT po.purc_order_number, c.comp_number, c.comp_name, IFNULL(po.due_date, DATE(NOW())) AS due_date, po.vat_percent, po.vat_value, po.is_disc_percent ,po.disc_percent, po.disc_value 
            FROM tb_purc_order AS po
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = po.id_comp_contact
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            WHERE po.id_purc_order = " + id_purc_order + "
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TextEditVendor.EditValue = data.Rows(0)("comp_number").ToString + " - " + data.Rows(0)("comp_name").ToString
        TextEditPONumber.EditValue = data.Rows(0)("purc_order_number").ToString

        DateEditDueDate.EditValue = data.Rows(0)("due_date")

        'item
        Dim query_item As String = "
            SELECT pod.`id_purc_order_det`, item.`item_desc`, pod.`qty` AS qty_po, pod.`value` AS val_po, pod.pph_percent, pod.gross_up_value
            FROM tb_purc_order_det pod
            INNER JOIN tb_purc_req_det prd ON prd.`id_purc_req_det`=pod.`id_purc_req_det`
            INNER JOIN tb_purc_req pr ON pr.`id_purc_req`=prd.`id_purc_req`
            INNER JOIN `tb_item` item ON item.`id_item`=pod.`id_item`
            INNER JOIN tb_m_uom uom ON uom.`id_uom`=item.`id_uom`
            WHERE pod.`id_purc_order`=" + id_purc_order + "
        "

        Dim data_item As DataTable = execute_query(query_item, -1, True, "", "", "", "")

        GCPurcReq.DataSource = data_item

        GVPurcReq.BestFitColumns()

        'summary
        TETotal.EditValue = GVPurcReq.Columns("amount").SummaryItem.SummaryValue

        If data.Rows(0)("is_disc_percent").ToString = "1" Then
            TEDiscPercent.EditValue = data.Rows(0)("disc_percent")
            TEDiscTotal.EditValue = data.Rows(0)("disc_value")
        Else
            TEDiscPercent.EditValue = 0.00
            TEDiscTotal.EditValue = data.Rows(0)("disc_value")
        End If

        TEVATPercent.EditValue = data.Rows(0)("vat_percent")
        TEVATValue.EditValue = data.Rows(0)("vat_value")

        TEPPH.EditValue = 0.00

        TEGrandTotal.EditValue = TETotal.EditValue - TEDiscTotal.EditValue + TEVATValue.EditValue - TEPPH.EditValue
    End Sub

    Private Sub SimpleButtonAttachment_Click(sender As Object, e As EventArgs) Handles SimpleButtonAttachment.Click
        Cursor = Cursors.WaitCursor

        FormDocumentUpload.is_no_delete = "-1"
        FormDocumentUpload.is_view = "-1"
        FormDocumentUpload.id_report = id_purc_order
        FormDocumentUpload.report_mark_type = "235"

        FormDocumentUpload.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButtonSet_Click(sender As Object, e As EventArgs) Handles SimpleButtonSet.Click
        If SLEPPHAccount.EditValue.ToString = get_opt_acc_field("id_acc_skbp") Then 'skbp
            For i As Integer = 0 To GVPurcReq.RowCount - 1
                If GVPurcReq.GetRowCellValue(i, "gross_up_value") > 0 Then
                    warningCustom("SKBP cannot use grossup")
                    Exit Sub
                End If
            Next
        End If

        'check attachment
        Dim query_attachment As String = "SELECT COUNT(*) FROM tb_doc WHERE report_mark_type = 235 AND id_report = " + id_purc_order

        Dim cek_attachment As String = If(execute_query(query_attachment, 0, True, "", "", "", "") = "0", "Please add attachment", "")

        'check pph
        Dim cek_pph As String = ""

        If TEPPH.EditValue > 0 Then
            If SLEPPHAccount.EditValue.ToString = "0" Then
                cek_pph = "Please add PPH Account"
            End If
        End If

        If Not cek_attachment = "" Then
            errorCustom(cek_attachment)
        ElseIf Not cek_pph = "" Then
            errorCustom(cek_pph)
        ElseIf TEInvNumber.Text = "" Then
            warningCustom("Please input invoice number")
        Else
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to set ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                For i = 0 To GVPurcReq.RowCount - 1
                    execute_non_query("UPDATE tb_purc_order_det SET pph_percent='" & decimalSQL(GVPurcReq.GetRowCellValue(i, "pph_percent").ToString) & "',pph='" & decimalSQL(GVPurcReq.GetRowCellValue(i, "pph").ToString) & "',gross_up_value='" & decimalSQL(GVPurcReq.GetRowCellValue(i, "gross_up_value").ToString) & "' WHERE id_purc_order_det='" & GVPurcReq.GetRowCellValue(i, "id_purc_order_det").ToString & "'", True, "", "", "", "")
                Next

                Dim query As String = "UPDATE tb_purc_order SET pph_total = " + decimalSQL(TEPPH.EditValue.ToString) + ",due_date = '" + Date.Parse(DateEditDueDate.EditValue.ToString).ToString("yyyy-MM-dd") + "', is_active_payment = 1, pph_total = " + decimalSQL(TEPPH.EditValue.ToString) + ", pph_account = " + If(SLEPPHAccount.EditValue.ToString = "0", "NULL", SLEPPHAccount.EditValue.ToString) + ",inv_number='" & addSlashes(TEInvNumber.Text) & "' WHERE id_purc_order = " + id_purc_order
                execute_non_query(query, True, "", "", "", "")

                If TEPPH.EditValue > 0 Then
                    'Jurnal PPH
                    'main journal
                    Dim id_acc_trans As String = ""
                    Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, acc_trans_note, id_report_status)
                VALUES ('" + header_number_acc("1") + "','" + addSlashes(TextEditPONumber.Text) + "','24','" + id_user + "', NOW(), 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                    id_acc_trans = execute_query(qjm, 0, True, "", "", "", "")
                    increase_inc_acc("1")

                    If SLEPPHAccount.EditValue.ToString = get_opt_acc_field("id_acc_skbp") Then 'skbp
                        query = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, report_mark_type_ref, id_report_ref, report_number_ref)
SELECT " + id_acc_trans + " AS id_acc_trans, po.`pph_account` AS `id_acc`, dep.id_main_comp, SUM(rd.qty) AS `qty`,
0 AS `debit`,
SUM(pod.pph) AS `credit`,
i.item_desc AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number
FROM tb_purc_rec_det rd
INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
INNER JOIN tb_item i ON i.id_item = rd.id_item
INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
WHERE po.id_purc_order=" & id_purc_order & " AND po.`is_close_rec`=1 AND pod.gross_up_value<=0
GROUP BY po.id_purc_order,dep.id_main_comp
UNION ALL
SELECT " + id_acc_trans + " AS id_acc_trans, po.`pph_account` AS `id_acc`, dep.id_main_comp, SUM(rd.qty) AS `qty`,
SUM(pod.pph) AS `debit`,
0 AS `credit`,
i.item_desc AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number
FROM tb_purc_rec_det rd
INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
INNER JOIN tb_item i ON i.id_item = rd.id_item
INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
WHERE po.id_purc_order=" & id_purc_order & " AND po.`is_close_rec`=1 AND pod.gross_up_value<=0
GROUP BY po.id_purc_order,dep.id_main_comp"
                        execute_non_query(query, True, "", "", "", "")
                    Else
                        query = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, report_mark_type_ref, id_report_ref, report_number_ref)
-- biaya
SELECT " + id_acc_trans + " AS id_acc_trans, o.id_coa_out AS `id_acc`, dep.id_main_comp, SUM(rd.qty) AS `qty`,
SUM(pod.`gross_up_value`) AS `debit`,
0 AS `credit`,
i.item_desc AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number
FROM tb_purc_rec_det rd
INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
INNER JOIN tb_item i ON i.id_item = rd.id_item
INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
INNER JOIN tb_item_coa o ON o.id_item_cat=i.id_item_cat AND o.id_departement=req.id_departement
INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
WHERE po.id_purc_order=" & id_purc_order & " AND po.`is_close_rec`=1 AND pod.gross_up_value>0
GROUP BY po.id_purc_order,dep.id_main_comp
UNION ALL
-- pph grossup
SELECT " + id_acc_trans + " AS id_acc_trans, po.`pph_account` AS `id_acc`, dep.id_main_comp, SUM(rd.qty) AS `qty`,
0 AS `debit`,
SUM(pod.`gross_up_value`) AS `credit`,
i.item_desc AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number
FROM tb_purc_rec_det rd
INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
INNER JOIN tb_item i ON i.id_item = rd.id_item
INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
WHERE po.id_purc_order=" & id_purc_order & " AND po.`is_close_rec`=1 AND pod.gross_up_value>0
GROUP BY po.id_purc_order,dep.id_main_comp
UNION ALL
-- hutang non grossup
SELECT " + id_acc_trans + " AS id_acc_trans, comp.id_acc_ap AS `id_acc`, dep.id_main_comp, SUM(rd.qty) AS `qty`,
SUM(pod.pph) AS `debit`,
0 AS `credit`,
i.item_desc AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number
FROM tb_purc_rec_det rd
INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
INNER JOIN tb_item i ON i.id_item = rd.id_item
INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
WHERE po.id_purc_order=" & id_purc_order & " AND po.`is_close_rec`=1 AND pod.gross_up_value<=0
GROUP BY po.id_purc_order,dep.id_main_comp
UNION ALL
-- pph non grossup
SELECT " + id_acc_trans + " AS id_acc_trans, po.`pph_account` AS `id_acc`, dep.id_main_comp, SUM(rd.qty) AS `qty`,
0 AS `debit`,
SUM(pod.pph) AS `credit`,
i.item_desc AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number
FROM tb_purc_rec_det rd
INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
INNER JOIN tb_item i ON i.id_item = rd.id_item
INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
WHERE po.id_purc_order=" & id_purc_order & " AND po.`is_close_rec`=1 AND pod.gross_up_value<=0
GROUP BY po.id_purc_order,dep.id_main_comp"
                        execute_non_query(query, True, "", "", "", "")
                    End If
                End If

                Close()
            End If
            FormBankWithdrawal.view_po_og()
        End If
    End Sub

    Private Sub FormBankWithdrawalAttachement_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVPurcReq_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVPurcReq.CellValueChanged
        calculate()
    End Sub

    Sub calculate()
        Dim pph As Decimal = 0.00

        For i = 0 To GVPurcReq.RowCount - 1
            If GVPurcReq.IsValidRowHandle(i) Then
                pph += Math.Floor(GVPurcReq.GetRowCellValue(i, "pph_percent") * (GVPurcReq.GetRowCellValue(i, "amount") + GVPurcReq.GetRowCellValue(i, "gross_up_value")) / 100)
            End If
        Next

        TEPPH.EditValue = pph

        TEGrandTotal.EditValue = TETotal.EditValue - TEDiscTotal.EditValue + TEVATValue.EditValue - TEPPH.EditValue
    End Sub

    Private Sub TEPPH_EditValueChanged(sender As Object, e As EventArgs) Handles TEPPH.EditValueChanged
        Try
            TEGrandTotal.EditValue = TETotal.EditValue - TEDiscTotal.EditValue + TEVATValue.EditValue - TEPPH.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GrossUpPPHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GrossUpPPHToolStripMenuItem.Click
        If GVPurcReq.RowCount > 0 Then
            Try
                Dim dpp As Decimal = Decimal.Parse(GVPurcReq.GetFocusedRowCellValue("amount").ToString)
                Dim pph As Decimal = Decimal.Parse(GVPurcReq.GetFocusedRowCellValue("pph_percent").ToString)
                '
                Dim grossup_val As Decimal = 0.00
                grossup_val = ((100 / (100 - pph)) * dpp) - dpp
                GVPurcReq.SetFocusedRowCellValue("gross_up_value", grossup_val)
                calculate()
            Catch ex As Exception
                warningCustom("Please check your input")
            End Try
        End If
    End Sub
End Class