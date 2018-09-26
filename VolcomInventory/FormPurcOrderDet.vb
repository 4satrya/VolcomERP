Public Class FormPurcOrderDet
    Public id_po As String = "-1"
    Public id_vendor_contact As String = ""
    '
    Public is_pick As String = "2"
    '
    Private Sub FormPurcOrderDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TETotal.EditValue = 0.00
        TEDiscPercent.EditValue = 0.00
        TEDiscTotal.EditValue = 0.00

        load_term()
        load_det()
        If id_po = "-1" Then 'new
            TEPONumber.Text = "[auto generate]"
            DEDateCreated.EditValue = Now()
            TEReqBy.Text = get_user_identify(id_user, "1")
            DEEstReceiveDate.EditValue = Now
            '
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
                        newRow("val_po") = 0.00
                        newRow("discount") = 0.00
                        newRow("discount_percent") = 0.00
                        TryCast(GCPurcReq.DataSource, DataTable).Rows.Add(newRow)
                    Next
                End If
                'create summary
                load_summary()
            Catch ex As Exception
                infoCustom(ex.ToString)
            End Try
        Else 'edit

        End If
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
        Next
    End Sub

    Sub load_det()
        Dim query As String = "SELECT pod.`id_purc_order_det`,pod.`id_purc_req_det`
                                ,itm.`item_desc`,pod.`qty` AS qty_pr,pod.`value` AS val_pr
                                ,dep.`departement`
                                ,req.`date_created` as pr_created
                                ,req.`purc_req_number`
                                ,0.00 AS qty_po
                                ,0.00 AS val_po
                                ,0.00 AS discount
                                ,0.00 AS discount_percent
                                ,uom.uom
                                ,itm.id_item
                                FROM tb_purc_order_det pod
                                INNER JOIN tb_item itm ON itm.`id_item`=pod.`id_item`
                                INNER JOIN tb_m_uom uom ON uom.id_uom=itm.id_uom
                                INNER JOIN tb_purc_req_det reqd ON reqd.`id_purc_req_det`=pod.`id_purc_req_det`
                                INNER JOIN tb_purc_req req ON req.`id_purc_req`=reqd.`id_purc_req`
                                INNER JOIN tb_m_departement dep ON dep.`id_departement`=req.`id_departement`
                                WHERE pod.id_purc_order='" & id_po & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPurcReq.DataSource = data
        GVPurcReq.BestFitColumns()
        'summary_query
        Dim query_sum As String = "SELECT '' AS id_item,'' AS item_desc,0.00 AS qty_po,0.00 AS discount,'' AS uom,0.00 AS val_po,0.00 as discount_percent,0.00 as discount,0.00 as sub_total"
        Dim data_sum As DataTable = execute_query(query_sum, -1, True, "", "", "", "")
        GCSummary.DataSource = data_sum
    End Sub

    Sub load_term()
        Dim query As String = "SELECT id_payment_purchasing,payment_purchasing FROM `tb_lookup_payment_purchasing` WHERE is_active='1'"
        viewLookupQuery(LEPaymentTerm, query, 0, "payment_purchasing", "id_payment_purchasing")
    End Sub

    Private Sub FormPurcOrderDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If id_po = "-1" Then 'new
            'header
            Dim query As String = "INSERT"
            execute_query(query, -1, True, "", "", "", "")
            'detail

        Else 'edit

        End If
    End Sub

    Private Sub BPickVendor_Click(sender As Object, e As EventArgs) Handles BPickVendor.Click
        FormPopUpContact.id_pop_up = "86"
        FormPopUpContact.id_cat = "1"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click

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
                                    WHERE c.id_comp_cat='1'
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
            TEGrandTotal.EditValue = TETotal.EditValue - TEDiscTotal.EditValue
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
End Class