Public Class FormOLStoreUpdateStatus
    Private Sub FormOLStoreUpdateStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewOLStore()
    End Sub

    Sub viewOLStore()
        Cursor = Cursors.WaitCursor
        Dim id_vios As String = get_setup_field("shopify_comp_group")
        Dim query As String = "SELECT cg.id_comp_group, cg.description 
        FROM tb_m_comp_group cg 
        INNER JOIN tb_m_comp c ON c.id_comp_group = cg.id_comp_group
        WHERE cg.id_comp_group NOT IN(" + id_vios + ") AND c.id_commerce_type=2
        GROUP BY cg.id_comp_group
        ORDER BY cg.idx_prior_order ASC "
        viewSearchLookupQuery(SLEOLStore, query, "id_comp_group", "description", "id_comp_group")
        Cursor = Cursors.Default
    End Sub


    Private Sub FormOLStoreUpdateStatus_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnUpdateStatus_Click(sender As Object, e As EventArgs) Handles BtnUpdateStatus.Click
        Cursor = Cursors.WaitCursor
        Dim id_comp_group As String = SLEOLStore.EditValue.ToString
        Dim id_api_type As String = execute_query("SELECT id_api_type FROM tb_m_comp_group WHERE id_comp_group='" + id_comp_group + "'", 0, True, "", "", "", "")
        If id_api_type = "3" Then
            'BLIBLI
            Dim query As String = "SELECT so.sales_order_ol_shop_number AS `order_no`, so.customer_name AS `customer`, sod.id_sales_order_det, sod.item_id, sod.ol_store_id
            FROM tb_sales_order so
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            LEFT JOIN (
	            SELECT stt.id_sales_order_det, MAX(stt.status_date) AS `status_date`, stt.`status`
	            FROM tb_sales_order_det_status stt
	            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = stt.id_sales_order_det
	            INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
	            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
	            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
	            WHERE so.id_report_status=6 AND c.id_comp_group=" + id_comp_group + "
	            GROUP BY stt.id_sales_order_det
            ) stt ON stt.id_sales_order_det = sod.id_sales_order_det
            WHERE so.id_report_status=6 AND c.id_comp_group=" + id_comp_group + " AND ((stt.`status`!='delivered' AND stt.`status`!='cancelled') OR ISNULL(stt.id_sales_order_det)) "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCData.DataSource = data
            Dim err As String = ""
            If GVData.RowCount > 0 Then
                If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                    FormMain.SplashScreenManager1.ShowWaitForm()
                End If

                For i As Integer = 0 To GVData.RowCount - 1
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Updating status " + (i + 1).ToString + " of " + GVData.RowCount.ToString)
                    Try
                        Dim bli As New ClassBliBliApi()
                        Dim dt As DataTable = bli.get_status(GVData.GetRowCellValue(i, "order_no").ToString, GVData.GetRowCellValue(i, "ol_store_id").ToString)
                        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                            Dim id_sales_order_det As String = GVData.GetRowCellValue(i, "id_sales_order_det").ToString
                            Dim status As String = dt.Rows(0)("order_status").ToString
                            Dim status_date As String = DateTime.Parse(dt.Rows(0)("order_status_date").ToString).ToString("yyyy-MM-dd HH:mm")

                            Dim query_ins As String = "INSERT IGNORE INTO tb_sales_order_det_status(id_sales_order_det, status, status_date, input_status_date) 
                            VALUES('" + id_sales_order_det + "', '" + status + "', '" + status_date + "', NOW()) "
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If
                    Catch ex As Exception
                        err += addSlashes(ex.ToString) + ";"
                    End Try
                Next
                FormMain.SplashScreenManager1.CloseWaitForm()
            End If
            If err = "" Then
                infoCustom("Sync status completed")
                Close()
            Else
                Dim qlog As String = "INSERT INTO tb_ol_store_status_log(id_comp_group, log_time, log) VALUES('" + id_comp_group + "', NOW(), '" + addSlashes(err.ToString) + "'); "
                stopCustom("Problem sync : " + err)
                Close()
            End If
        Else
            stopCustom("Not available for this time")
        End If
        Cursor = Cursors.Default
    End Sub
End Class