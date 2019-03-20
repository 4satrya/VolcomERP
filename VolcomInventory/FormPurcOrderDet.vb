Public Class FormPurcOrderDet
    Public id_po As String = "-1"
    Public id_vendor_contact As String = "-1"
    '
    Public is_pick As String = "2"
    Public is_view As String = "-1"
    '
    Private Sub FormPurcOrderDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
        load_report_status()
        '
        DEDueDate.EditValue = Now
        TETotal.EditValue = 0.00
        TEDiscPercent.EditValue = 0.00
        TEDiscTotal.EditValue = 0.00
        TEVATPercent.EditValue = 0.00
        TEVATValue.EditValue = 0.00

        load_payment_term()
        load_order_term()
        load_ship_via()

        If id_po = "-1" Then 'new
            TEPONumber.Text = "[auto generate]"
            DEDateCreated.EditValue = Now()
            TECreatedBy.Text = get_user_identify(id_user, "1")
            DEEstReceiveDate.EditValue = Now
            '
            load_det()
            Try
                If is_pick = "1" Then
                    For i As Integer = 0 To FormPurcOrder.GVPurcReq.RowCount - 1
                        Dim newRow As DataRow = (TryCast(GCPurcReq.DataSource, DataTable)).NewRow()
                        newRow("id_item") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "id_item").ToString
                        newRow("departement") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "departement").ToString
                        newRow("id_purc_req_det") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "id_purc_req_det").ToString
                        newRow("purc_req_number") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "purc_req_number").ToString
                        newRow("pr_created") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "pr_created")
                        newRow("item_desc") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "item_desc").ToString
                        newRow("uom") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "uom")
                        newRow("qty_pr") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "qty_pr")
                        newRow("val_pr") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "val_pr")
                        newRow("qty_po") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "qty_po")
                        '
                        newRow("val_po") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "latest_price")
                        newRow("discount") = 0.00
                        newRow("discount_percent") = 0.00
                        TryCast(GCPurcReq.DataSource, DataTable).Rows.Add(newRow)
                    Next
                    '
                    TEShipDestination.Text = FormPurcOrder.GVPurcReq.GetRowCellValue(0, "ship_destination").ToString
                    MESHipAddress.Text = FormPurcOrder.GVPurcReq.GetRowCellValue(0, "ship_address").ToString
                    '
                End If
                'create summary
                load_summary()
            Catch ex As Exception
                infoCustom(ex.ToString)
            End Try
            BtnPrint.Visible = False
            BMark.Visible = False
        Else 'edit
            'load header
            Dim query As String = "SELECT c.*,po.pay_due_date,cc.contact_number,cc.contact_person,po.vat_percent,po.vat_value,emp.employee_name,po.id_payment_purchasing,po.purc_order_number,po.id_comp_contact,po.note,po.est_date_receive,po.date_created,po.created_by,po.id_report_status,po.is_disc_percent,po.disc_percent,po.disc_value 
,po.id_order_term,po.id_shipping_method,po.ship_destination,po.ship_address
FROM tb_purc_order po
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=po.id_comp_contact
INNER JOIN tb_m_comp c ON cc.id_comp=c.`id_comp`
INNER JOIN tb_m_user usr ON usr.id_user=po.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE po.id_purc_order='" & id_po & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                id_vendor_contact = data.Rows(0)("id_comp_contact").ToString
                TEVendorName.Text = data.Rows(0)("comp_name").ToString
                MEAdrressCompTo.Text = data.Rows(0)("address_primary").ToString
                TEVendorAttn.Text = data.Rows(0)("contact_person").ToString
                TEVendorEmail.Text = data.Rows(0)("email").ToString
                TEVendorPhone.Text = data.Rows(0)("contact_number").ToString
                TEVendorFax.Text = data.Rows(0)("fax").ToString
                TEVendorCode.Text = data.Rows(0)("comp_number").ToString
                '
                TEShipDestination.Text = data.Rows(0)("ship_destination").ToString
                MESHipAddress.Text = data.Rows(0)("ship_address").ToString
                '
                DEDateCreated.EditValue = data.Rows(0)("date_created")
                TEPONumber.Text = data.Rows(0)("purc_order_number")
                TECreatedBy.Text = data.Rows(0)("employee_name").ToString
                LEPaymentTerm.ItemIndex = LEPaymentTerm.Properties.GetDataSourceRowIndex("id_payment_purchasing", data.Rows(0)("id_payment_purchasing").ToString)
                DEEstReceiveDate.EditValue = data.Rows(0)("est_date_receive")
                DEDueDate.EditValue = data.Rows(0)("pay_due_date")
                '
                MENote.Text = data.Rows(0)("note").ToString
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
                LEOrderTerm.ItemIndex = LEOrderTerm.Properties.GetDataSourceRowIndex("id_order_term", data.Rows(0)("id_order_term").ToString)
                LEShipVia.ItemIndex = LEShipVia.Properties.GetDataSourceRowIndex("id_shipping_method", data.Rows(0)("id_shipping_method").ToString)
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
                '
                load_det()
                load_summary()
                TETotal.EditValue = GVSummary.Columns("sub_total").SummaryItem.SummaryValue

                TEVATPercent.EditValue = data.Rows(0)("vat_percent")
                TEVATValue.EditValue = data.Rows(0)("vat_value")

                If data.Rows(0)("is_disc_percent").ToString = "1" Then
                    CEPercent.Checked = True
                    TEDiscPercent.EditValue = data.Rows(0)("disc_percent")
                    TEDiscTotal.EditValue = data.Rows(0)("disc_value")
                Else
                    CEPercent.Checked = False
                    TEDiscPercent.EditValue = 0.00
                    TEDiscTotal.EditValue = data.Rows(0)("disc_value")
                End If

            End If
            BtnPrint.Visible = True
            BMark.Visible = True
            '
            TEVendorCode.ReadOnly = True
            BPickVendor.Visible = False
            DEEstReceiveDate.Enabled = False
            LEPaymentTerm.Enabled = False
            '
            CEPercent.Enabled = False
            TEDiscPercent.Enabled = False
            TEDiscTotal.Enabled = False
            TEShipDestination.Enabled = False
            MESHipAddress.Enabled = False
            LEOrderTerm.Enabled = False
            LEShipVia.Enabled = False
            '
            If (Not check_edit_report_status(LEReportStatus.EditValue.ToString, "139", id_po)) Or is_view = "1" Then
                MENote.Enabled = False
                BtnSave.Visible = False
            Else
                MENote.Enabled = True
                BtnSave.Visible = True
            End If
        End If
    End Sub

    Sub load_report_status()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub load_summary()
        'delete all row
        For j As Integer = GVSummary.RowCount - 1 To 0 Step -1
            GVSummary.DeleteRow(j)
        Next
        'add
        For i As Integer = 0 To GVPurcReq.RowCount - 1
            Dim is_found As Boolean = False
            For k As Integer = 0 To GVSummary.RowCount - 1
                If GVSummary.GetRowCellValue(k, "id_item").ToString = GVPurcReq.GetRowCellValue(i, "id_item").ToString Then
                    is_found = True
                    'add qty
                    GVSummary.SetRowCellValue(k, "qty_po", (GVSummary.GetRowCellValue(k, "qty_po") + GVPurcReq.GetRowCellValue(i, "qty_po")))
                End If
            Next
            If is_found = False Then 'add new row
                Dim newRow As DataRow = (TryCast(GCSummary.DataSource, DataTable)).NewRow()
                newRow("id_item") = GVPurcReq.GetRowCellValue(i, "id_item").ToString
                newRow("item_desc") = GVPurcReq.GetRowCellValue(i, "item_desc").ToString
                newRow("uom") = GVPurcReq.GetRowCellValue(i, "uom")
                newRow("qty_po") = GVPurcReq.GetRowCellValue(i, "qty_po")
                '
                newRow("val_po") = GVPurcReq.GetRowCellValue(i, "val_po")
                newRow("discount") = GVPurcReq.GetRowCellValue(i, "discount")
                newRow("discount_percent") = GVPurcReq.GetRowCellValue(i, "discount_percent")
                TryCast(GCSummary.DataSource, DataTable).Rows.Add(newRow)
            End If
            '

        Next

        GVSummary.RefreshData()
        TETotal.EditValue = GVSummary.Columns("sub_total").SummaryItem.SummaryValue
    End Sub

    Sub load_det()
        is_process = "1"
        Dim query As String = "SELECT pod.`id_item`,dep.`departement`,prd.`id_purc_req_det`,pr.`purc_req_number`,pr.`date_created` AS pr_created,item.`item_desc`,uom.`uom`,prd.`qty` AS qty_pr,prd.`value` AS val_pr,pod.`qty` AS qty_po,pod.`value` AS val_po,pod.`discount`,pod.`discount_percent`
                                FROM tb_purc_order_det pod
                                INNER JOIN tb_purc_req_det prd ON prd.`id_purc_req_det`=pod.`id_purc_req_det`
                                INNER JOIN tb_purc_req pr ON pr.`id_purc_req`=prd.`id_purc_req`
                                INNER JOIN tb_m_departement dep ON dep.`id_departement`=pr.`id_departement`
                                INNER JOIN `tb_item` item ON item.`id_item`=pod.`id_item`
                                INNER JOIN tb_m_uom uom ON uom.`id_uom`=item.`id_uom`
                                WHERE pod.`id_purc_order`='" & id_po & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPurcReq.DataSource = data
        GVPurcReq.BestFitColumns()
        'summary_query
        Dim query_sum As String = "SELECT '' AS id_item,'' AS item_desc,0.00 AS qty_po,0.00 AS discount,'' AS uom,0.00 AS val_po,0.00 as discount_percent,0.00 as discount"
        Dim data_sum As DataTable = execute_query(query_sum, -1, True, "", "", "", "")
        GCSummary.DataSource = data_sum
        is_process = "2"
    End Sub

    Sub load_payment_term()
        Dim query As String = "SELECT id_payment_purchasing,payment_purchasing FROM `tb_lookup_payment_purchasing` WHERE is_active='1'"
        viewLookupQuery(LEPaymentTerm, query, 0, "payment_purchasing", "id_payment_purchasing")
    End Sub

    Sub load_order_term()
        Dim query As String = "SELECT id_order_term,order_term FROM `tb_lookup_purc_order_term` WHERE is_active='1'"
        viewLookupQuery(LEOrderTerm, query, 0, "order_term", "id_order_term")
    End Sub

    Sub load_ship_via()
        Dim query As String = "SELECT id_shipping_method,shipping_method FROM `tb_lookup_shipping_method` WHERE is_active='1'"
        viewLookupQuery(LEShipVia, query, 0, "shipping_method", "id_shipping_method")
    End Sub

    Private Sub FormPurcOrderDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If id_po = "-1" Then 'new
            If GVSummary.RowCount = 0 Then
                warningCustom("Please make sure item listed")
            ElseIf id_vendor_contact = "-1" Then
                warningCustom("Please make sure vendor already selected")
            ElseIf TETotal.EditValue = 0 Then
                warningCustom("Please make sure item price listed")
            ElseIf id_vendor_contact = "-1" Then
                warningCustom("Please input vendor")
            Else
                'header
                Dim is_check As String = "1"
                If CEPercent.Checked = True Then
                    is_check = "1"
                Else
                    is_check = "2"
                End If

                Dim query As String = "INSERT INTO `tb_purc_order`(`id_comp_contact`,id_payment_purchasing,`note`,`date_created`,est_date_receive,pay_due_date,`created_by`,`last_update`,`last_update_by`,`id_report_status`,is_disc_percent,disc_percent,disc_value,vat_percent,vat_value,ship_destination,ship_address)
                                    VALUES('" & id_vendor_contact & "','" & LEPaymentTerm.EditValue.ToString & "','" & addSlashes(MENote.Text) & "',NOW(),'" & Date.Parse(DEEstReceiveDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & id_user & "',NOW(),'" & id_user & "','1','" & is_check & "','" & decimalSQL(TEDiscPercent.EditValue.ToString) & "','" & decimalSQL(TEDiscTotal.EditValue.ToString) & "','" & decimalSQL(TEVATPercent.EditValue.ToString) & "','" & decimalSQL(TEVATValue.EditValue.ToString) & "','" & addSlashes(TEShipDestination.Text) & "','" & addSlashes(MESHipAddress.Text) & "'); SELECT LAST_INSERT_ID(); "
                id_po = execute_query(query, 0, True, "", "", "", "")
                'generate number
                query = "CALL gen_number('" & id_po & "','139')"
                execute_non_query(query, True, "", "", "", "")
                'detail
                For i As Integer = 0 To GVPurcReq.RowCount - 1
                    query = "INSERT INTO `tb_purc_order_det`(`id_purc_order`,`id_item`,`id_purc_req_det`,`qty`,`value`,`discount_percent`,`discount`)
                        VALUES('" & id_po & "','" & GVPurcReq.GetRowCellValue(i, "id_item").ToString & "','" & GVPurcReq.GetRowCellValue(i, "id_purc_req_det").ToString & "','" & decimalSQL(GVPurcReq.GetRowCellValue(i, "qty_po").ToString) & "','" & decimalSQL(GVPurcReq.GetRowCellValue(i, "val_po").ToString) & "','" & decimalSQL(GVPurcReq.GetRowCellValue(i, "discount_percent").ToString) & "','" & decimalSQL(GVPurcReq.GetRowCellValue(i, "discount").ToString) & "')"
                    execute_non_query(query, True, "", "", "", "")
                Next
                'expense trans
                'insert to expense trans
                Dim query_trans As String = "INSERT INTO `tb_b_expense_trans`(id_b_expense,date_trans,`value`,id_report,report_mark_type,note) 
                                            SELECT prd.id_b_expense,NOW(),pod.`value`,pod.`id_purc_order` AS id_report,'139' AS report_mark_type,'Purchase Order'
                                            FROM `tb_purc_order_det` pod
                                            INNER JOIN `tb_purc_req_det` prd ON prd.`id_purc_req_det`=pod.`id_purc_req_det`
                                            WHERE pod.`id_purc_order`='" & id_po & "'
                                            UNION
                                            SELECT prd.id_b_expense,NOW(),-(prd.`value`),prd.`id_purc_req` AS id_report,'137' AS report_mark_type,'Purchase Request vs Purchase Order'
                                            FROM `tb_purc_order_det` pod
                                            INNER JOIN `tb_purc_req_det` prd ON prd.`id_purc_req_det`=pod.`id_purc_req_det`
                                            WHERE pod.`id_purc_order`='" & id_po & "'"
                execute_non_query(query_trans, True, "", "", "", "")
                '
                submit_who_prepared("139", id_po, id_user)
                '
                FormPurcOrder.load_req()
                infoCustom("Order Created")
                load_form()
            End If
        Else 'edit
            Dim query As String = "UPDATE `tb_purc_order` SET `note`='" & addSlashes(MENote.Text) & "' WHERE id_purc_order='" & id_po & "'"
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Order Updated")
            load_form()
        End If
    End Sub

    Private Sub BPickVendor_Click(sender As Object, e As EventArgs) Handles BPickVendor.Click
        FormPopUpContact.id_pop_up = "86"
        FormPopUpContact.id_cat = "8"
        FormPopUpContact.is_must_active = "1"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "139"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_po
        FormReportMark.ShowDialog()
    End Sub

    Dim is_process As String = "2"

    Private Sub GVSummary_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVSummary.CellValueChanged
        If is_process = "2" Then
            If e.Column.FieldName.ToString = "val_po" Then
                'set value
                GVSummary.GetFocusedRowCellValue("id_item")
                calc_total(e.RowHandle, "2")
            ElseIf e.Column.FieldName.ToString = "discount_percent" Then
                'discount with percentage
                calc_total(e.RowHandle, "1")
            ElseIf e.Column.FieldName.ToString = "discount" Then
                'discount without percentage
                calc_total(e.RowHandle, "2")
            End If
            refresh_detail(e.RowHandle, GVSummary.GetFocusedRowCellValue("id_item").ToString)
        End If
    End Sub

    Sub refresh_detail(ByVal summary_rowhandle As Integer, ByVal id_item As String)
        For i As Integer = 0 To GVPurcReq.RowCount - 1
            If GVPurcReq.GetRowCellValue(i, "id_item").ToString = id_item Then
                GVPurcReq.SetRowCellValue(i, "val_po", GVSummary.GetRowCellValue(summary_rowhandle, "val_po"))
                GVPurcReq.SetRowCellValue(i, "discount_percent", GVSummary.GetRowCellValue(summary_rowhandle, "discount_percent"))
                GVPurcReq.SetRowCellValue(i, "discount", GVSummary.GetRowCellValue(summary_rowhandle, "discount"))
            End If
        Next
    End Sub

    Sub calc_total(ByVal rowhandle As Integer, ByVal opt As String)
        is_process = "1"
        'opt
        If opt = "1" Then
            '1 = from percentage
            Dim disc_prcent As Decimal = 0.00
            Dim val As Decimal = 0.00
            Dim disc As Decimal = 0.00
            Dim qty As Decimal = 0.00
            Dim subtot As Decimal = 0.00

            val = GVSummary.GetRowCellValue(rowhandle, "val_po")
            disc_prcent = GVSummary.GetRowCellValue(rowhandle, "discount_percent")
            qty = GVSummary.GetRowCellValue(rowhandle, "qty_po")
            disc = ((val * disc_prcent) / 100)
            subtot = (val - disc) * qty
            '
            GVSummary.SetRowCellValue(rowhandle, "discount", disc)
            GVSummary.SetRowCellValue(rowhandle, "sub_total", subtot)
            GVSummary.RefreshData()
            '
        ElseIf opt = "2" Then
            '2 = from value
            Dim disc_prcent As Decimal = 0.00
            Dim val As Decimal = 0.00
            Dim disc As Decimal = 0.00
            Dim qty As Decimal = 0.00
            Dim subtot As Decimal = 0.00

            val = GVSummary.GetRowCellValue(rowhandle, "val_po")
            qty = GVSummary.GetRowCellValue(rowhandle, "qty_po")
            disc = GVSummary.GetRowCellValue(rowhandle, "discount")
            subtot = (val - disc) * qty
            '
            GVSummary.SetRowCellValue(rowhandle, "discount_percent", 0.00)
            GVSummary.SetRowCellValue(rowhandle, "sub_total", subtot)
            GVSummary.RefreshData()
        End If
        '
        TETotal.EditValue = GVSummary.Columns("sub_total").SummaryItem.SummaryValue
        '
        is_process = "2"
    End Sub

    Private Sub TEVendorCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TEVendorCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query As String = "SELECT c.*,cc.* FROM tb_m_comp c
                                    INNER JOIN 
                                    (
	                                    SELECT cc.`id_comp_contact`,cc.`contact_person`,cc.`contact_number`,cc.`id_comp` FROM tb_m_comp_contact cc 
	                                    WHERE cc.`is_default`='1'
	                                    GROUP BY cc.`id_comp`
                                    )cc ON cc.id_comp=c.`id_comp`
                                    WHERE c.id_comp_cat='8'
                                    AND c.comp_number='" & TEVendorCode.Text & "'"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count < 1 Then
                stopCustom("Store not found.")
                TEVendorCode.Focus()
            ElseIf data.Rows.Count > 1 Then
                FormPopUpContact.id_pop_up = "86"
                FormPopUpContact.id_cat = "1"
                FormPopUpContact.GVCompany.ActiveFilterString = "[comp_number]='" + addSlashes(TEVendorCode.Text) + "'"
                FormPopUpContact.ShowDialog()
            Else
                id_vendor_contact = data.Rows(0)("id_comp_contact").ToString
                TEVendorName.Text = data.Rows(0)("comp_name").ToString
                MEAdrressCompTo.Text = data.Rows(0)("address_primary").ToString
                '
                TEVendorAttn.Text = data.Rows(0)("contact_person").ToString
                TEVendorEmail.Text = data.Rows(0)("email").ToString
                TEVendorPhone.Text = data.Rows(0)("contact_number").ToString
                TEVendorFax.Text = data.Rows(0)("fax").ToString
            End If
        End If
    End Sub

    Private Sub TEDiscPercent_EditValueChanged(sender As Object, e As EventArgs) Handles TEDiscPercent.EditValueChanged
        If CEPercent.Checked = True Then
            TEDiscTotal.EditValue = (TETotal.EditValue * TEDiscPercent.EditValue) / 100
            calculate_grand_total()
        End If
    End Sub

    Private Sub TEDiscTotal_EditValueChanged(sender As Object, e As EventArgs) Handles TEDiscTotal.EditValueChanged
        If CEPercent.Checked = False Then
            TEDiscPercent.EditValue = 0.00
            calculate_grand_total()
        End If
    End Sub

    Sub calculate_grand_total()
        Try
            TEVATValue.EditValue = (TETotal.EditValue - TEDiscTotal.EditValue) * (TEVATPercent.EditValue / 100)
            TEGrandTotal.EditValue = TETotal.EditValue - TEDiscTotal.EditValue + TEVATValue.EditValue
        Catch ex As Exception
            TEGrandTotal.EditValue = 0.00
        End Try
    End Sub

    Private Sub CEPercent_CheckedChanged(sender As Object, e As EventArgs) Handles CEPercent.CheckedChanged
        If CEPercent.Checked = True Then
            'use percent
            TEDiscPercent.Enabled = True
            TEDiscTotal.Enabled = False
        Else
            'use value
            TEDiscPercent.Enabled = False
            TEDiscTotal.Enabled = True
        End If
    End Sub

    Private Sub TETotal_EditValueChanged(sender As Object, e As EventArgs) Handles TETotal.EditValueChanged
        calculate_grand_total()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportPurcOrder.id_po = id_po
        ReportPurcOrder.dt = GCSummary.DataSource
        Dim Report As New ReportPurcOrder()
        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVSummary.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVSummary.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVSummary)

        'Parse val
        Report.LPoNumber.Text = "Number : " & TEPONumber.Text
        Report.LTerm.Text = LEPaymentTerm.Text.ToUpper
        Report.LCreateDate.Text = Date.Parse(DEDateCreated.EditValue.ToString).ToString("dd MMMM yyyy")
        Report.LEstRecDate.Text = Date.Parse(DEEstReceiveDate.EditValue.ToString).ToString("dd MMMM yyyy").ToUpper
        Report.LTermOrder.Text = LEOrderTerm.Text.ToUpper
        Report.LShipVia.Text = LEShipVia.Text.ToUpper
        Report.LPaymentDueDate.Text = Date.Parse(DEDueDate.EditValue.ToString).ToString("dd MMMM yyyy").ToUpper
        '
        Report.LTotal.Text = TETotal.Text
        Report.LDiscount.Text = TEDiscTotal.Text
        Report.LVat.Text = TEVATValue.Text
        Report.LGrandTotal.Text = TEGrandTotal.Text
        Report.LNote.Text = MENote.Text
        '
        Report.LabelAttn.Text = TEVendorAttn.Text
        Report.LTo.Text = TEVendorName.Text
        Report.LToAdress.Text = MEAdrressCompTo.Text & vbNewLine & TEVendorPhone.Text & vbNewLine & TEVendorEmail.Text

        Report.LShipTo.Text = get_company_x(get_id_company(get_setup_field("id_own_company")), "1")
        Report.LShipToAddress.Text = get_company_x(get_id_company(get_setup_field("id_own_company")), "3")

        If Not LEReportStatus.EditValue = "6" Then
            Report.id_pre = "2"
        Else
            Report.id_pre = "1"
        End If

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub TEVATPercent_EditValueChanged(sender As Object, e As EventArgs) Handles TEVATPercent.EditValueChanged
        Try
            calculate_grand_total()
        Catch ex As Exception
        End Try
    End Sub
End Class