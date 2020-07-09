Public Class FormOlStoreReturnInputAWB
    Private Sub FormOlStoreReturnInputAWB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewRequest()
    End Sub

    Private Sub FormOlStoreReturnInputAWB_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewRequest()
        Cursor = Cursors.WaitCursor
        'check in
        Dim w_in As String = "0, "
        For i = 0 To FormWHAWBillIn.GVDO.RowCount - 1
            w_in += If(FormWHAWBillIn.GVDO.GetRowCellValue(i, "id_ol_store_ret_req").ToString = "", "0", FormWHAWBillIn.GVDO.GetRowCellValue(i, "id_ol_store_ret_req").ToString) + ", "
        Next

        Dim query As String = "
            SELECT m.id_ol_store_ret_req, m.id_comp_group, cg.description AS comp_group_name, m.sales_order_ol_shop_number, m.number, m.receive_cust_date, m.ret_req_number, m.ret_req_date, m.created_date, m.created_by, e.employee_name AS created_by_name, m.updated_date, m.updated_by, eu.employee_name AS updated_by_name, m.awb_number, m.note, m.id_report_status, stt.report_status, 
            COUNT(d.id_ol_store_ret_req_det) - IFNULL(qt.qty, 0) AS qty_fisik
            FROM tb_ol_store_ret_req_det d
            INNER JOIN tb_ol_store_ret_req m ON m.id_ol_store_ret_req = d.id_ol_store_ret_req
            INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = m.id_report_status
            INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = m.id_comp_group
            INNER JOIN tb_m_user u ON u.id_user = m.created_by
            INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
            INNER JOIN tb_m_user uu ON uu.id_user = m.updated_by
            INNER JOIN tb_m_employee eu ON eu.id_employee = uu.id_employee
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det  = d.id_sales_order_det
            INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            LEFT JOIN (
	            SELECT a.`id_store`, i.`id_ol_store_ret_req`, SUM(i.`qty`) AS qty
	            FROM `tb_wh_awbill_det_in` AS i
	            INNER JOIN `tb_wh_awbill` AS a ON i.`id_awbill` = a.`id_awbill`
	            WHERE i.`id_ol_store_ret_req` IS NOT NULL
	            GROUP BY i.`id_ol_store_ret_req`, a.`id_store`
            ) AS qt ON d.`id_ol_store_ret_req` = qt.id_ol_store_ret_req AND c.`id_comp` = qt.id_store
            WHERE m.id_report_status=6 AND c.id_comp = '" + FormWHAWBillIn.id_comp + "' AND d.id_ol_store_ret_req NOT IN (" + w_in.Substring(0, w_in.Length - 2) + ")
            GROUP BY d.id_ol_store_ret_req, c.id_comp
            HAVING qty_fisik > 0
        "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRequest.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub SBInputAWB_Click(sender As Object, e As EventArgs) Handles SBInputAWB.Click
        'validating
        Dim msg As String = ""

        If TEInputAWB.Text = "" Then
            msg = "AWB number can't blank."
        End If

        If Not GVRequest.GetFocusedRowCellValue("awb_number").ToString = "" Then
            msg = "AWB number already input."
        End If

        'input awb
        If msg = "" Then
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to input AWB ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                execute_non_query("UPDATE tb_ol_store_ret_req SET awb_number = '" + addSlashes(TEInputAWB.EditValue.ToString) + "' WHERE id_ol_store_ret_req = '" + GVRequest.GetFocusedRowCellValue("id_ol_store_ret_req").ToString + "'", True, "", "", "", "")

                TEInputAWB.EditValue = ""

                infoCustom("AWB number saved.")
            End If
        Else
            errorCustom(msg)
        End If

        viewRequest()
    End Sub

    Private Sub GVRequest_DoubleClick(sender As Object, e As EventArgs) Handles GVRequest.DoubleClick
        Dim newRow As DataRow = (TryCast(FormWHAWBillIn.GCDO.DataSource, DataTable)).NewRow()
        newRow("id_wh_awb_det") = "0"
        newRow("do_no") = GVRequest.GetFocusedRowCellValue("sales_order_ol_shop_number").ToString
        newRow("qty") = GVRequest.GetFocusedRowCellValue("qty_fisik")
        newRow("act_qty") = GVRequest.GetFocusedRowCellValue("qty_fisik")
        newRow("id_ol_store_ret_req") = GVRequest.GetFocusedRowCellValue("id_ol_store_ret_req")
        TryCast(FormWHAWBillIn.GCDO.DataSource, DataTable).Rows.Add(newRow)
        FormWHAWBillIn.GCDO.RefreshDataSource()
        FormWHAWBillIn.GVDO.RefreshData()

        Close()
    End Sub
End Class