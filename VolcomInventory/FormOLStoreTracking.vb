Public Class FormOLStoreTracking

    Private Sub FormOLStoreTracking_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormOLStoreTracking_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub resetInput()
        TxtStore.Text = ""
        TxtCustomer.Text = ""
        TxtPhone.Text = ""
        MEAddress.Text = ""
        TxtTrackingCode.Text = ""
        TxtPaymentMethod.Text = ""
        GCData.DataSource = Nothing
    End Sub

    Private Sub TxtOrderNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtOrderNumber.KeyDown
        resetInput()
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        'head
        Dim order_number As String = addSlashes(TxtOrderNumber.Text.Trim)
        Dim query As String = "SELECT s.id_comp_group,sg.description AS `store_group`, so.customer_name, so.shipping_phone, so.shipping_address, so.tracking_code, so.payment_method
        FROM tb_sales_order so 
        INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = so.id_store_contact_to
        INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
        INNER JOIN tb_m_comp_group sg ON sg.id_comp_group = s.id_comp_group
        WHERE so.sales_order_ol_shop_number='" + order_number + "'
        AND so.id_report_status!=5
        GROUP BY so.sales_order_ol_shop_number "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            TxtStore.Text = data.Rows(0)("store_group").ToString
            TxtCustomer.Text = data.Rows(0)("customer_name").ToString
            TxtPhone.Text = data.Rows(0)("shipping_phone").ToString
            MEAddress.Text = data.Rows(0)("shipping_address").ToString
            TxtTrackingCode.Text = data.Rows(0)("tracking_code").ToString
            TxtPaymentMethod.Text = data.Rows(0)("payment_method").ToString
            Dim id_comp_group As String = data.Rows(0)("id_comp_group").ToString

            'detail
            Dim qd As String = "SELECT a.id_report ,a.report_mark_type, rmt.report_mark_type_name AS `trans_type`, a.trans_time, a.trans_number, a.id_report_status, rs.report_status
            FROM (
	            -- so
	            SELECT so.id_sales_order AS `id_report`,rm.report_mark_type,rm.report_mark_datetime AS `trans_time`, so.sales_order_number AS `trans_number`, so.id_report_status
	            FROM tb_sales_order so 
	            INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = so.id_store_contact_to
	            INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
	            INNER JOIN tb_m_comp_group sg ON sg.id_comp_group = s.id_comp_group
	            INNER JOIN tb_report_mark rm ON rm.id_report = so.id_sales_order AND rm.report_mark_type=39 AND rm.id_report_status=1
	            WHERE so.sales_order_ol_shop_number='" + order_number + "' AND s.id_comp_group='" + id_comp_group + "' AND s.id_commerce_type=2 AND so.id_report_status=6
	            UNION ALL 
	            -- del
	            SELECT del.id_pl_sales_order_del AS `id_report`, rm.report_mark_type,rm.report_mark_datetime AS `trans_time`, del.pl_sales_order_del_number AS `trans_number`, del.id_report_status
	            FROM tb_pl_sales_order_del del
	            INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = del.id_store_contact_to
	            INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
	            INNER JOIN tb_m_comp_group sg ON sg.id_comp_group = s.id_comp_group
	            INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
	            INNER JOIN tb_report_mark rm ON rm.id_report = del.id_pl_sales_order_del AND rm.report_mark_type=43 AND rm.id_report_status=1
	            WHERE so.sales_order_ol_shop_number='" + order_number + "'  AND s.id_comp_group='" + id_comp_group + "' AND s.id_commerce_type=2
	            UNION ALL
	            -- invoice
	            SELECT sal.id_sales_pos AS `id_report`,rm.report_mark_type,rm.report_mark_datetime AS `trans_time`, sal.sales_pos_number AS `trans_number`, sal.id_report_status
	            FROM tb_sales_pos sal
	            INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = sal.id_store_contact_from
	            INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
	            INNER JOIN tb_m_comp_group sg ON sg.id_comp_group = s.id_comp_group
	            INNER JOIN tb_sales_pos_det sald ON sald.id_sales_pos = sal.id_sales_pos
	            INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del_det = sald.id_pl_sales_order_del_det
	            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
	            INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
	            INNER JOIN tb_report_mark rm ON rm.id_report = sal.id_sales_pos AND (rm.report_mark_type=48 OR rm.report_mark_type=54) AND rm.id_report_status=1
	            WHERE (sal.report_mark_type=48 OR sal.report_mark_type=54) AND so.sales_order_ol_shop_number='" + order_number + "'  AND s.id_comp_group='" + id_comp_group + "' AND s.id_commerce_type=2
	            UNION ALL
	            -- cn
	            SELECT sal.id_sales_pos AS `id_report`,rm.report_mark_type,rm.report_mark_datetime AS `trans_time`, sal.sales_pos_number AS `trans_number`, sal.id_report_status
	            FROM tb_sales_pos sal
	            INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = sal.id_store_contact_from
	            INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
	            INNER JOIN tb_m_comp_group sg ON sg.id_comp_group = s.id_comp_group
	            INNER JOIN tb_sales_pos_det sald ON sald.id_sales_pos = sal.id_sales_pos
	            INNER JOIN tb_sales_pos_det saldref ON saldref.id_sales_pos_det = sald.id_sales_pos_det_ref
                INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del_det = saldref.id_pl_sales_order_del_det
	            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
	            INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
	            INNER JOIN tb_report_mark rm ON rm.id_report = sal.id_sales_pos AND rm.report_mark_type=118 AND rm.id_report_status=1
	            WHERE (sal.report_mark_type=118) AND so.sales_order_ol_shop_number='" + order_number + "'  AND s.id_comp_group='" + id_comp_group + "' AND s.id_commerce_type=2
	            UNION ALL
	            -- ro
	            SELECT ro.id_sales_return_order AS `id_report`,rm.report_mark_type,rm.report_mark_datetime AS `trans_time`, ro.sales_return_order_number AS `trans_number`, ro.id_report_status
	            FROM tb_sales_return_order ro
	            INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = ro.id_store_contact_to
	            INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
	            INNER JOIN tb_m_comp_group sg ON sg.id_comp_group = s.id_comp_group
	            INNER JOIN tb_sales_order so ON so.id_sales_order = ro.id_sales_order
	            INNER JOIN tb_report_mark rm ON rm.id_report = ro.id_sales_return_order AND rm.report_mark_type=119 AND rm.id_report_status=1
	            WHERE so.sales_order_ol_shop_number='" + order_number + "'  AND s.id_comp_group='" + id_comp_group + "' AND s.id_commerce_type=2
	            UNION ALL
	            -- ret
	            SELECT ret.id_sales_return AS `id_report`,rm.report_mark_type,rm.report_mark_datetime AS `trans_time`, ret.sales_return_number AS `trans_number`, ret.id_report_status
	            FROM tb_sales_return ret
	            INNER JOIN tb_sales_return_order ro ON ro.id_sales_return_order = ret.id_sales_return_order
	            INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = ret.id_store_contact_from
	            INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
	            INNER JOIN tb_m_comp_group sg ON sg.id_comp_group = s.id_comp_group
	            INNER JOIN tb_sales_order so ON so.id_sales_order = ro.id_sales_order
	            INNER JOIN tb_report_mark rm ON rm.id_report = ret.id_sales_return AND rm.report_mark_type=120 AND rm.id_report_status=1
	            WHERE so.sales_order_ol_shop_number='" + order_number + "'  AND s.id_comp_group='" + id_comp_group + "' AND s.id_commerce_type=2
	            UNION ALL
	            -- rec payment
	            SELECT r.id_rec_payment AS `id_report`,rm.report_mark_type,rm.report_mark_datetime AS `trans_time`, r.number AS `trans_number`, r.id_report_status
	            FROM tb_rec_payment_det rd
	            INNER JOIN tb_rec_payment r ON r.id_rec_payment = rd.id_rec_payment
	            INNER JOIN tb_sales_pos sal ON sal.id_sales_pos = rd.id_report
	            INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = sal.id_store_contact_from
	            INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
	            INNER JOIN tb_m_comp_group sg ON sg.id_comp_group = s.id_comp_group
	            INNER JOIN tb_sales_pos_det sald ON sald.id_sales_pos = sal.id_sales_pos
	            INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del_det = sald.id_pl_sales_order_del_det
	            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
	            INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
	            INNER JOIN tb_report_mark rm ON rm.id_report = r.id_rec_payment AND rm.report_mark_type=162 AND rm.id_report_status=1
	            WHERE (rd.report_mark_type=48 OR rd.report_mark_type=54) AND s.id_comp_group='" + id_comp_group + "' AND s.id_commerce_type=2 
	            AND so.sales_order_ol_shop_number='" + order_number + "'
	            UNION ALL
	            -- ret pay
	            SELECT r.id_rec_payment AS `id_report`, rm.report_mark_type,rm.report_mark_datetime AS `trans_time`, r.number AS `trans_number`, r.id_report_status
	            FROM tb_rec_payment_det rd
	            INNER JOIN tb_rec_payment r ON r.id_rec_payment = rd.id_rec_payment
	            INNER JOIN tb_sales_pos sal ON sal.id_sales_pos = rd.id_report
	            INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = sal.id_store_contact_from
	            INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
	            INNER JOIN tb_m_comp_group sg ON sg.id_comp_group = s.id_comp_group
	            INNER JOIN tb_sales_pos_det sald ON sald.id_sales_pos = sal.id_sales_pos
	            INNER JOIN tb_sales_pos_det saldref ON saldref.id_sales_pos_det = sald.id_sales_pos_det_ref
                INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del_det = saldref.id_pl_sales_order_del_det
	            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
	            INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
	            INNER JOIN tb_report_mark rm ON rm.id_report = r.id_rec_payment AND rm.report_mark_type=162 AND rm.id_report_status=1
	            WHERE rd.report_mark_type=118 AND s.id_comp_group='" + id_comp_group + "' AND s.id_commerce_type=2 
	            AND so.sales_order_ol_shop_number='" + order_number + "'  
            ) a 
            INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type = a.report_mark_type
            INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = a.id_report_status
            ORDER BY `trans_time` ASC "
            Dim dd As DataTable = execute_query(qd, -1, True, "", "", "", "")
            GCData.DataSource = dd
            GVData.BestFitColumns()
        Else
            stopCustom("Order not found")
            resetInput()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Close()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_report As String = GVData.GetFocusedRowCellValue("id_report").ToString
            Dim report_mark_type As String = GVData.GetFocusedRowCellValue("report_mark_type").ToString
            Dim m As New ClassShowPopUp
            m.id_report = id_report
            m.report_mark_type = report_mark_type
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub
End Class