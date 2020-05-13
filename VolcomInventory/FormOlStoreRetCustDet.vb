Public Class FormOlStoreRetCustDet
    Public id_ret As String = "-1"
    Dim is_scan As Boolean = False
    Dim order_id As String = ""
    Dim id_comp_group As String = ""
    '
    Dim scan_mode As String = ""
    Dim dt As DataTable
    '
    Dim id_report_status As String = ""
    Public is_view As String = "-1"
    '
    Private Sub FormOlStoreRetCustDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Close()
    End Sub

    Sub view_comp_group()
        Dim q As String = "SELECT 0 AS id_comp_group,'ALL' AS comp_group,'ALL' AS description
UNION
SELECT id_comp_group,comp_group,description FROM tb_m_comp_group"
        viewSearchLookupQuery(SLECompGroup, q, "id_comp_group", "description", "id_comp_group")
    End Sub

    Sub view_order()
        Dim q As String = "SELECT 'ALL' AS sales_order_ol_shop_number
UNION
SELECT sales_order_ol_shop_number
FROM `tb_ol_store_ret_list` rl
INNER JOIN `tb_ol_store_ret_det` retd ON retd.`id_ol_store_ret`=rl.id_ol_store_ret_det
INNER JOIN tb_ol_store_ret ret ON retd.id_ol_store_ret=ret.id_ol_store_ret
WHERE ret.id_report_status=6 AND (rl.`id_ol_store_ret_stt`=4 OR rl.id_ol_store_ret_stt=5)
GROUP BY ret.sales_order_ol_shop_number"
        viewSearchLookupQuery(SLEOrder, q, "sales_order_ol_shop_number", "sales_order_ol_shop_number", "sales_order_ol_shop_number")
    End Sub

    Sub action_load()
        viewReportStatus()
        view_comp_group()
        view_order()

        If id_ret = "-1" Then 'new
            SLECompGroup.EditValue = FormOlStoreRetCust.SLECompGroup.EditValue
            SLEOrder.EditValue = FormOlStoreRetCust.SLEOrder.EditValue
            '
            DEDateCreated.EditValue = Now
            TENumberRetCust.Text = "[auto generate]"
            '
            If FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "is_ret_to_cust").ToString = "1" Or FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "is_ret_to_cust").ToString = "True" Then
                '
                TERetTo.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "cust_name").ToString
                MEAddress1.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "cust_address").ToString
                '
                TEShipPhone.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "cust_phone").ToString
                TEShipCity.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "cust_city").ToString
                TEPostalCode.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "cust_postal_code").ToString
                TERegion.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "cust_region").ToString
            Else
                TERetTo.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "group_name").ToString
                MEAddress1.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "group_address").ToString
                '
                TEShipPhone.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "group_phone").ToString
                TEShipCity.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "group_city").ToString
                TEPostalCode.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "group_postal_code").ToString
                TERegion.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "group_region").ToString
            End If
        Else
            Dim q As String = "SELECT * FROM `tb_ol_store_cust_ret` WHERE id_ol_store_cust_ret='" & id_ret & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", dt.Rows(0)("id_report_status").ToString)
                id_report_status = dt.Rows(0)("id_report_status").ToString
                SLECompGroup.EditValue = dt.Rows(0)("id_comp_group").ToString
                SLEOrder.EditValue = dt.Rows(0)("sales_order_ol_shop_number").ToString
                '
                DEDateCreated.EditValue = dt.Rows(0)("created_date")
                TENumberRetCust.Text = dt.Rows(0)("number").ToString
                '
                TERetTo.Text = dt.Rows(0)("shipping_name").ToString
                MEAddress1.Text = dt.Rows(0)("shipping_address").ToString
                MENote.Text = dt.Rows(0)("note").ToString
                '
                TEShipPhone.Text = dt.Rows(0)("shipping_phone").ToString
                TEShipCity.Text = dt.Rows(0)("shipping_city").ToString
                TEPostalCode.Text = dt.Rows(0)("shipping_post_code").ToString
                TERegion.Text = dt.Rows(0)("shipping_region").ToString
            End If
            allow_status()
        End If

        load_det()
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        DEDateCreated.Enabled = False
        MENote.Enabled = False
        BtnSaveChanges.Visible = False
        PanelControlNav.Visible = False
        BMark.Visible = True
        BtnPrint.Visible = True
        MENote.Enabled = False

        If id_report_status = "6" Then
            BtnCancell.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
        End If
    End Sub

    Private Sub FormOlStoreRetCustDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        action_load()
    End Sub

    Sub load_det()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT rl.`id_ol_store_ret_list`,retd.id_ol_store_cust_ret_det,retd.id_ol_store_cust_ret,d.id_ol_store_ret_det, d.id_ol_store_ret, 
d.id_sales_order_det, sod.id_product, d.product_full_code AS code, p.product_display_name AS `name`, cd.code_detail_name AS `size`, sod.item_id, sod.ol_store_id,
d.id_pl_sales_order_del_det_counting
FROM `tb_ol_store_cust_ret_det` retd
INNER JOIN tb_ol_store_ret_list rl ON rl.`id_ol_store_ret_list`=retd.id_ol_store_ret_list
INNER JOIN tb_ol_store_ret_det d ON d.id_ol_store_ret_det=rl.id_ol_store_ret_det
INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = d.id_sales_order_det
INNER JOIN tb_m_product p ON p.id_product = sod.id_product
INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
INNER JOIN tb_pl_sales_order_del_det_counting c ON c.id_pl_sales_order_del_det_counting = d.id_pl_sales_order_del_det_counting
        WHERE retd.id_ol_store_cust_ret=" + id_ret + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default

        Dim q As String = ""

        'If id_ret = "-1" Then 'new
        '    q = "SELECT rl.`id_ol_store_ret_list`,p.`id_product`,CONCAT(p.`product_full_code`,plc.`pl_sales_order_del_det_counting`) AS code,p.`product_display_name` AS name,cd.`code_detail_name` AS size
        ',0 AS qty_scan,IF(ISNULL(retc.id_ol_store_ret_list),1,0) AS qty_limit
        'FROM tb_ol_store_ret_list rl
        'INNER JOIN tb_ol_store_ret_det rd ON rd.`id_ol_store_ret_det`=rl.id_ol_store_ret_det
        'INNER JOIN tb_ol_store_ret r ON r.`id_ol_store_ret`=rd.`id_ol_store_ret`
        'INNER JOIN `tb_pl_sales_order_del_det_counting` plc ON rd.`id_pl_sales_order_del_det_counting`=plc.id_pl_sales_order_del_det_counting
        'INNER JOIN tb_sales_order_det sod ON sod.`id_sales_order_det`=rd.id_sales_order_det
        'INNER JOIN tb_m_product p ON p.`id_product`=sod.`id_product`
        'INNER JOIN tb_m_product_code pc ON pc.`id_product`=p.`id_product`
        'INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail` AND cd.`id_code`='33'
        'INNER JOIN tb_lookup_ol_store_ret_stt stt ON stt.id_ol_store_ret_stt=rl.id_ol_store_ret_stt
        'LEFT JOIN tb_m_user usr ON usr.id_user=rl.`update_by`
        'LEFT JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
        'LEFT JOIN 
        '(
        '	SELECT id_ol_store_ret_list 
        '	FROM `tb_ol_store_cust_ret_det` crd
        '	INNER JOIN tb_ol_store_cust_ret cr ON cr.`id_ol_store_cust_ret`=crd.`id_ol_store_cust_ret` AND cr.`id_report_status`!=5
        ') retc ON retc.id_ol_store_ret_list=rl.`id_ol_store_ret_list`
        'WHERE rl.id_ol_store_ret_stt='4' AND r.id_comp_group='" & SLECompGroup.EditValue.ToString & "' AND r.sales_order_ol_shop_number='" & SLEOrder.EditValue.ToString & "' "
        'Else 'edit
        '    q = "SELECT rl.`id_ol_store_ret_list`,p.`id_product`,CONCAT(p.`product_full_code`,plc.`pl_sales_order_del_det_counting`) AS code,p.`product_display_name` AS name,cd.`code_detail_name` AS size
        ',0 AS qty_scan,IF(ISNULL(retc.id_ol_store_ret_list),1,0) AS qty_limit        
        'FROM `tb_ol_store_cust_ret_det` retd
        'INNER JOIN tb_ol_store_ret_list rl ON rl.`id_ol_store_ret_list`=retd.id_ol_store_ret_list
        'INNER JOIN tb_ol_store_ret_det rd ON rd.`id_ol_store_ret_det`=rl.id_ol_store_ret_det
        'INNER JOIN `tb_pl_sales_order_del_det_counting` plc ON rd.`id_pl_sales_order_del_det_counting`=plc.id_pl_sales_order_del_det_counting
        'INNER JOIN tb_sales_order_det sod ON sod.`id_sales_order_det`=rd.id_sales_order_det
        'INNER JOIN tb_m_product p ON p.`id_product`=sod.`id_product`
        'INNER JOIN tb_m_product_code pc ON pc.`id_product`=p.`id_product`
        'INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail` AND cd.`id_code`='33'
        'INNER JOIN tb_lookup_ol_store_ret_stt stt ON stt.id_ol_store_ret_stt=rl.id_ol_store_ret_stt
        'LEFT JOIN tb_m_user usr ON usr.id_user=rl.`update_by`
        'LEFT JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
        'LEFT JOIN 
        '(
        '	SELECT id_ol_store_ret_list 
        '	FROM `tb_ol_store_cust_ret_det` crd
        '	INNER JOIN tb_ol_store_cust_ret cr ON cr.`id_ol_store_cust_ret`=crd.`id_ol_store_cust_ret` AND cr.`id_report_status`!=5
        '	WHERE NOT crd.`id_ol_store_cust_ret`='" & id_ret & "'
        ') retc ON retc.id_ol_store_ret_list=rl.`id_ol_store_ret_list`
        'WHERE retd.id_ol_store_cust_ret='" & id_ret & "'"
        'End If

        '        Dim data As DataTable = execute_query(q, "-1", True, "", "", "", "")
        '        GCData.DataSource = data
        '        GVData.BestFitColumns()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        TxtScannedCode.Enabled = True
        Try
            dt.Clear()
        Catch ex As Exception
        End Try
        Dim order_number As String = addSlashes(SLEOrder.EditValue.ToString)
        Dim id_comp_group As String = SLECompGroup.EditValue.ToString

        Dim query As String = ""

        If id_ret = "-1" Then 'new
            query = "SELECT rl.`id_ol_store_ret_list`,p.`id_product`,CONCAT(p.`product_full_code`,plc.`pl_sales_order_del_det_counting`) AS code,p.`product_display_name` AS name,cd.`code_detail_name` AS size
        ,0 AS qty_scan,IF(ISNULL(retc.id_ol_store_ret_list),1,0) AS qty_limit
        FROM tb_ol_store_ret_list rl
        INNER JOIN tb_ol_store_ret_det rd ON rd.`id_ol_store_ret_det`=rl.id_ol_store_ret_det
        INNER JOIN tb_ol_store_ret r ON r.`id_ol_store_ret`=rd.`id_ol_store_ret`
        INNER JOIN `tb_pl_sales_order_del_det_counting` plc ON rd.`id_pl_sales_order_del_det_counting`=plc.id_pl_sales_order_del_det_counting
        INNER JOIN tb_sales_order_det sod ON sod.`id_sales_order_det`=rd.id_sales_order_det
        INNER JOIN tb_m_product p ON p.`id_product`=sod.`id_product`
        INNER JOIN tb_m_product_code pc ON pc.`id_product`=p.`id_product`
        INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail` AND cd.`id_code`='33'
        INNER JOIN tb_lookup_ol_store_ret_stt stt ON stt.id_ol_store_ret_stt=rl.id_ol_store_ret_stt
        LEFT JOIN tb_m_user usr ON usr.id_user=rl.`update_by`
        LEFT JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
        LEFT JOIN 
        (
        	SELECT id_ol_store_ret_list 
        	FROM `tb_ol_store_cust_ret_det` crd
        	INNER JOIN tb_ol_store_cust_ret cr ON cr.`id_ol_store_cust_ret`=crd.`id_ol_store_cust_ret` AND cr.`id_report_status`!=5
        ) retc ON retc.id_ol_store_ret_list=rl.`id_ol_store_ret_list`
        WHERE rl.id_ol_store_ret_stt='4' AND r.id_comp_group='" & SLECompGroup.EditValue.ToString & "' AND r.sales_order_ol_shop_number='" & SLEOrder.EditValue.ToString & "' "
        Else 'edit
            query = "SELECT rl.`id_ol_store_ret_list`,p.`id_product`,CONCAT(p.`product_full_code`,plc.`pl_sales_order_del_det_counting`) AS code,p.`product_display_name` AS name,cd.`code_detail_name` AS size
        ,0 AS qty_scan,IF(ISNULL(retc.id_ol_store_ret_list),1,0) AS qty_limit        
        FROM `tb_ol_store_cust_ret_det` retd
        INNER JOIN tb_ol_store_ret_list rl ON rl.`id_ol_store_ret_list`=retd.id_ol_store_ret_list
        INNER JOIN tb_ol_store_ret_det rd ON rd.`id_ol_store_ret_det`=rl.id_ol_store_ret_det
        INNER JOIN `tb_pl_sales_order_del_det_counting` plc ON rd.`id_pl_sales_order_del_det_counting`=plc.id_pl_sales_order_del_det_counting
        INNER JOIN tb_sales_order_det sod ON sod.`id_sales_order_det`=rd.id_sales_order_det
        INNER JOIN tb_m_product p ON p.`id_product`=sod.`id_product`
        INNER JOIN tb_m_product_code pc ON pc.`id_product`=p.`id_product`
        INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail` AND cd.`id_code`='33'
        INNER JOIN tb_lookup_ol_store_ret_stt stt ON stt.id_ol_store_ret_stt=rl.id_ol_store_ret_stt
        LEFT JOIN tb_m_user usr ON usr.id_user=rl.`update_by`
        LEFT JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
        LEFT JOIN 
        (
        	SELECT id_ol_store_ret_list 
        	FROM `tb_ol_store_cust_ret_det` crd
        	INNER JOIN tb_ol_store_cust_ret cr ON cr.`id_ol_store_cust_ret`=crd.`id_ol_store_cust_ret` AND cr.`id_report_status`!=5
        	WHERE NOT crd.`id_ol_store_cust_ret`='" & id_ret & "'
        ) retc ON retc.id_ol_store_ret_list=rl.`id_ol_store_ret_list`
        WHERE retd.id_ol_store_cust_ret='" & id_ret & "'"
        End If

        dt = execute_query(query, -1, True, "", "", "", "")
        scan_mode = "add"
        LabelScannedCode.Appearance.ForeColor = Color.Green
        TxtScannedCode.Properties.Appearance.ForeColor = Color.Green
        TxtScannedCode.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub TxtScannedCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtScannedCode.KeyDown
        Cursor = Cursors.WaitCursor
        If e.KeyData = Keys.Enter Then
            Dim code As String = addSlashes(TxtScannedCode.Text)
            If scan_mode = "add" Then
                ' add scan
                Dim dtf As DataRow() = dt.Select("[code]='" + code + "' ")
                If dtf.Length <= 0 Then
                    stopCustomDialog("Code : " + code + " not found. ")
                    GVData.FocusedRowHandle = GVData.RowCount - 1
                    TxtScannedCode.Text = ""
                    TxtScannedCode.Focus()
                Else
                    makeSafeGV(GVData)
                    Dim tot_qty As Integer = 0
                    GVData.ActiveFilterString = "[code]='" + code + "'"
                    If GVData.RowCount > 0 Then
                        tot_qty = GVData.RowCount
                    End If
                    GVData.ActiveFilterString = ""
                    If tot_qty < dtf(0)("qty_limit") Then
                        Dim newRow As DataRow = (TryCast(GCData.DataSource, DataTable)).NewRow()
                        newRow("id_ol_store_cust_ret_det") = "0"
                        newRow("id_ol_store_ret_list") = dtf(0)("id_ol_store_ret_list").ToString
                        newRow("code") = dtf(0)("code").ToString
                        newRow("name") = dtf(0)("name").ToString
                        newRow("size") = dtf(0)("size").ToString
                        TryCast(GCData.DataSource, DataTable).Rows.Add(newRow)
                        GCData.RefreshDataSource()
                        GVData.RefreshData()
                        GVData.FocusedRowHandle = GVData.RowCount - 1
                        TxtScannedCode.Text = ""
                        TxtScannedCode.Focus()
                    Else
                        stopCustomDialog("Maximum scan : " + dtf(0)("qty_limit").ToString)
                        TxtScannedCode.Text = ""
                        TxtScannedCode.Focus()
                    End If
                End If
            Else
                makeSafeGV(GVData)
                GVData.ActiveFilterString = "[code]='" + code + "'"
                If GVData.RowCount > 0 Then
                    GVData.DeleteSelectedRows()
                    GCData.RefreshDataSource()
                    GVData.RefreshData()
                    GVData.FocusedRowHandle = GVData.RowCount - 1
                    TxtScannedCode.Text = ""
                    TxtScannedCode.Focus()
                Else
                    stopCustomDialog("Code : " + code + " not found. ")
                    GVData.FocusedRowHandle = GVData.RowCount - 1
                    TxtScannedCode.Text = ""
                    TxtScannedCode.Focus()
                End If
                GVData.ActiveFilterString = ""
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        Cursor = Cursors.WaitCursor
        scan_mode = "delete"
        LabelScannedCode.Appearance.ForeColor = Color.Red
        TxtScannedCode.Properties.Appearance.ForeColor = Color.Red
        TxtScannedCode.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "245"
        FormDocumentUpload.id_report = id_ret
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        makeSafeGV(GVData)
        If GVData.RowCount <= 0 Then
            warningCustom("Please fill data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                BtnSaveChanges.Enabled = False
                Dim id_comp_group As String = SLECompGroup.EditValue.ToString
                Dim sales_order_ol_shop_number As String = addSlashes(SLEOrder.EditValue.ToString)
                Dim rec_date As String = DateTime.Parse(DEDateCreated.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim note As String = addSlashes(MENote.Text)
                Dim ship_name As String = addSlashes(TERetTo.Text)
                Dim ship_address As String = addSlashes(MEAddress1.Text)
                Dim ship_phone As String = addSlashes(TEShipPhone.Text)
                Dim ship_post_code As String = addSlashes(TEPostalCode.Text)
                Dim ship_region As String = addSlashes(TERegion.Text)
                Dim ship_city As String = addSlashes(TEShipCity.Text)

                'main 
                Dim query As String = "INSERT INTO tb_ol_store_cust_ret(`id_comp_group`,`sales_order_ol_shop_number`,`shipping_name`,`shipping_address`,`shipping_phone`,`shipping_city`,`shipping_post_code`,`shipping_region`,`created_date`,`created_by`,`note`,`id_report_status`) VALUES 
                ('" + id_comp_group + "', '" + sales_order_ol_shop_number + "','" + ship_name + "','" + ship_address + "','" + ship_phone + "','" + ship_city + "','" + ship_post_code + "','" + ship_region + "', NOW(), '" + id_user + "', '" + note + "',1);SELECT LAST_INSERT_ID(); "
                id_ret = execute_query(query, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_ret + ", 245); ", True, "", "", "", "")

                'detail
                Dim query_det As String = "INSERT INTO tb_ol_store_cust_ret_det(id_ol_store_cust_ret, id_ol_store_ret_list) VALUES "
                For i As Integer = 0 To GVData.RowCount - 1
                    Dim id_ol_store_ret_list As String = GVData.GetRowCellValue(i, "id_ol_store_ret_list").ToString

                    If i > 0 Then
                        query_det += ","
                    End If
                    query_det += "('" + id_ret + "', '" + id_ol_store_ret_list + "') "
                Next

                If GVData.RowCount > 0 Then
                    execute_non_query(query_det, True, "", "", "", "")
                End If

                'submit
                submit_who_prepared("245", id_ret, id_user)

                'refresh
                FormOlStoreRetCust.XTCRetCust.SelectedTabPageIndex = 0
                FormOlStoreRetCust.load_view()
                FormOlStoreRetCust.GVRetCust.FocusedRowHandle = find_row(FormOlStoreRetCust.GVRetCust, "id_ol_store_cust_ret", id_ret)
                action_load()
                infoCustom("Return to customer created. Waiting for approval")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "245"
        FormReportMark.id_report = id_ret
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class