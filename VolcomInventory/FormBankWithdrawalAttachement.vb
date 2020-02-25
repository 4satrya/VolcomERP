Public Class FormBankWithdrawalAttachement
    Public id_purc_order As String = "-1"

    Private Sub FormBankWithdrawalAttachement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'load pph account
        Dim query_pph As String = "(SELECT 0 AS id_acc, '' AS acc_name, '' AS acc_description, '' AS acc) UNION (SELECT id_acc, acc_name, acc_description, CONCAT(acc_name, ' - ', acc_description) as acc FROM tb_a_acc WHERE id_status = 1 AND id_is_det = 2)"
        viewSearchLookupQuery(SLEPPHAccount, query_pph, "id_acc", "acc", "id_acc")

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
            SELECT pod.`id_purc_order_det`, item.`item_desc`, pod.`qty` AS qty_po, pod.`value` AS val_po, pod.pph_percent
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
        'check attachment
        Dim query_attachment As String = "SELECT COUNT(*) FROM tb_doc WHERE report_mark_type = 235 AND id_report = " + id_purc_order

        Dim cek_attachment As String = If(execute_query(query_attachment, 0, True, "", "", "", "") = "0", "Please add attachment", "")

        If Not cek_attachment = "" Then
            errorCustom(cek_attachment)
        Else
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to set ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                Dim query As String = "UPDATE tb_purc_order SET due_date = '" + Date.Parse(DateEditDueDate.EditValue.ToString).ToString("yyyy-MM-dd") + "', is_active_payment = 1, pph_total = " + decimalSQL(TEPPH.EditValue.ToString) + ", pph_account = " + If(SLEPPHAccount.EditValue.ToString = "0", "NULL", SLEPPHAccount.EditValue.ToString) + " WHERE id_purc_order = " + id_purc_order

                execute_non_query(query, True, "", "", "", "")

                execute_non_query("UPDATE tb_purc_order SET pph_total = " + decimalSQL(TEPPH.EditValue.ToString) + " WHERE id_purc_order =" + id_purc_order, True, "", "", "", "")

                FormBankWithdrawal.buttonView_click()

                Close()
            End If
        End If
    End Sub

    Private Sub FormBankWithdrawalAttachement_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVPurcReq_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVPurcReq.CellValueChanged
        Dim pph As Decimal = 0.00

        For i = 0 To GVPurcReq.RowCount - 1
            If GVPurcReq.IsValidRowHandle(i) Then
                pph += (GVPurcReq.GetRowCellValue(i, "pph_percent") * GVPurcReq.GetRowCellValue(i, "amount") / 100)
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
End Class