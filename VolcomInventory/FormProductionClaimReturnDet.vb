Public Class FormProductionClaimReturnDet
    Public action As String = ""
    Public id As String = "-1"
    Public id_report_status As String = "-1"
    Dim created_date As String = ""
    Public id_prod_order As String = "-1"
    Public is_view As String = "-1"
    Public id_comp_contact As String = "-1"
    Public id_design As String = "-1"

    Private Sub FormProductionClaimReturnDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            'purc order detail
            BtnBrowse.Focus()
            TxtNumber.Text = "[auto generate]"
            DECreated.EditValue = getTimeDB()
        Else
            Dim r As New ClassProductionClaimReturn()
            Dim query As String = r.queryMain("AND cr.id_prod_claim_return='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtNumber.Text = data.Rows(0)("number").ToString
            created_date = DateTime.Parse(data.Rows(0)("created_date")).ToString("yyyy-MM-dd HH:mm:ss")
            DECreated.EditValue = data.Rows(0)("created_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_prod_order = data.Rows(0)("id_prod_order").ToString
            TxtOrderNumber.Text = data.Rows(0)("prod_order_number").ToString
            TxtVendor.Text = data.Rows(0)("comp").ToString
            id_design = data.Rows(0)("id_design").ToString
            TxtDesignCode.Text = data.Rows(0)("code").ToString
            TxtDesignName.Text = data.Rows(0)("name").ToString
            pre_viewImages("2", PEView, id_design, False)

            viewDetail()
            allow_status()
            checkUpload()
        End If
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        If action = "ins" Then
            query = "SELECT pod.id_prod_order_det,prod.id_product, prod.product_full_code AS `code`, prod.product_ean_code AS `ean_code`, d.design_display_name AS `name`, cd.code_detail_name AS `size`, o.ovh_price AS `price`,
            0 AS `qty`, '' AS `remark`, '' AS `stt` 
            FROM tb_prod_order po
            INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order = po.id_prod_order AND wo.id_report_status!=5 AND wo.is_main_vendor=1
            INNER JOIN tb_m_ovh_price o ON o.id_ovh_price = wo.id_ovh_price
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = o.id_comp_contact
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            INNER JOIN tb_prod_order_det pod ON pod.id_prod_order = po.id_prod_order
            INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_product = pod.id_prod_demand_product
            INNER JOIN tb_m_product prod ON prod.id_product = pdp.id_product
            INNER JOIN tb_m_product_code pc ON pc.id_product = prod.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
            INNER JOIN tb_m_design d ON d.id_design = prod.id_design
            WHERE po.id_prod_order=" + id_prod_order + " "
        ElseIf action = "upd" Then
            query = "SELECT d.id_prod_order_det,prod.id_product, prod.product_full_code AS `code`, prod.product_ean_code AS `ean_code`, dsg.design_display_name AS `name`, cd.code_detail_name AS `size`,d.price,
            d.qty, d.remark, '' AS `stt` 
            FROM tb_prod_claim_return_det d
            INNER JOIN tb_m_product prod ON prod.id_product = d.id_product
            INNER JOIN tb_m_product_code pc ON pc.id_product = prod.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
            WHERE d.id_prod_claim_return=" + id + " "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnBrowse.Enabled = False
        BtnCancell.Visible = True
        BtnMark.Visible = True
        BtnAttachment.Visible = True
        BtnPrint.Visible = True
        GVDetail.OptionsBehavior.Editable = False

        If check_edit_report_status(id_report_status, "151", id) Then
            BtnSave.Visible = False
            MENote.Enabled = True
        Else
            BtnSave.Visible = False
            MENote.Enabled = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
        End If
    End Sub

    Private Sub FormProductionClaimReturnDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancell this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_prod_claim_return SET id_report_status=5 WHERE id_prod_claim_return='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 151, id)
            execute_non_query(queryrm, True, "", "", "", "")

            FormProductionClaimReturn.viewData()
            FormProductionClaimReturn.GVData.FocusedRowHandle = find_row(FormProductionClaimReturn.GVData, "id_prod_claim_return", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        If id_report_status = "6" Then
            Dim gcx As DevExpress.XtraGrid.GridControl = Nothing
            Dim gvx As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            gcx = GCDetail
            gvx = GVDetail

            ReportProductionClaimReturn.id = id
            ReportProductionClaimReturn.dt = gcx.DataSource
            Dim Report As New ReportProductionClaimReturn()

            '' '... 
            '' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            gvx.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVDetail.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVDetail)

            'Parse val
            Report.LabelNumber.Text = TxtOrderNumber.Text.ToUpper
            Report.LabelOrderNumber.Text = TxtOrderNumber.Text.ToUpper
            Report.LabelVendor.Text = TxtVendor.Text.ToUpper
            Report.LabelDate.Text = DECreated.Text.ToUpper.ToString
            Report.LNote.Text = MENote.Text.ToString
            Report.LabelCode.Text = TxtDesignCode.Text
            Report.LabelStyle.Text = TxtDesignName.Text


            'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        Else
            print_raw_no_export(GCDetail)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        attach()
    End Sub

    Sub attach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "151"
        FormDocumentUpload.id_report = id
        FormDocumentUpload.is_only_pdf = True

        'cek ud submit ato blm
        Dim query As String = "SELECT * FROM tb_report_mark d
        WHERE d.report_mark_type=151 AND d.id_report=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Or is_view = "1" Or id_report_status = "5" Or id_report_status = "6" Then
            FormDocumentUpload.is_view = "1"
        End If

        FormDocumentUpload.ShowDialog()
        checkUpload()
        Cursor = Cursors.Default
    End Sub

    Sub checkUpload()
        'check
        Dim rmt As String = "151"
        Dim qry As String = "SELECT * FROM tb_doc d
        WHERE d.report_mark_type=" + rmt + " AND d.id_report=" + id + " "
        Dim dt As DataTable = execute_query(qry, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            BtnMark.Enabled = True
        Else
            BtnMark.Enabled = False
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "151"
        FormReportMark.id_report = id
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDetail_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVDetail.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim rh As Integer = e.RowHandle
        Dim id_prod_order_det As String = GVDetail.GetRowCellValue(rh, "id_prod_order_det").ToString
        Dim id_product As String = GVDetail.GetRowCellValue(rh, "id_product").ToString
        If e.Column.FieldName = "qty" Then
            If e.Value > 0 Then
                Dim old_value As Decimal = GVDetail.ActiveEditor.OldEditValue
                Dim qcek As String = "CALL view_stock_prod_ret_in_remain('" + id_prod_order + "', '" + id_prod_order_det + "', '0', '0', '0') "
                Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
                If e.Value > dcek.Rows(0)("qty") Then
                    warningCustom("Qty can't exceed " + dcek.Rows(0)("qty").ToString)
                    GVDetail.SetRowCellValue(rh, "qty", old_value)
                End If
                GVDetail.BestFitColumns()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim cond_data As Boolean = True
        GridColumnStatus.Visible = False
        Dim qcs As String = "CALL view_stock_prod_ret_in_remain('" + id_prod_order + "', '0', '0', '0', '0') "
        Dim dcs As DataTable = execute_query(qcs, -1, True, "", "", "", "")
        makeSafeGV(GVDetail)
        For i As Integer = 0 To ((GVDetail.RowCount - 1) - GetGroupRowCount(GVDetail))
            Dim id_prod_order_det_cek As String = GVDetail.GetRowCellValue(i, "id_prod_order_det").ToString
            Dim qty_cek As Decimal = GVDetail.GetRowCellValue(i, "qty")
            Dim data_filter_cek As DataRow() = dcs.Select("[id_prod_order_det]='" + id_prod_order_det_cek + "' ")
            If qty_cek > data_filter_cek(0)("qty") Then
                GVDetail.SetRowCellValue(i, "stt", "Qty can't exceed " + data_filter_cek(0)("qty").ToString + ";")
                cond_data = False
            Else
                GVDetail.SetRowCellValue(i, "stt", "OK")
            End If
        Next

        If GVDetail.Columns("qty").SummaryItem.SummaryValue <= 0 Or id_prod_order = "-1" Or id_comp_contact = "-1" Then
            warningCustom("Please complete all data")
        ElseIf Not cond_data Then
            GridColumnStatus.VisibleIndex = 100
            warningCustom("Can't save, some item exceed limit qty")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                BtnSave.Enabled = False
                'query main
                Dim note As String = addSlashes(MENote.Text.ToString)
                Dim qm As String = "INSERT INTO tb_prod_claim_return(id_comp_contact, id_prod_order, number, created_date, note, id_report_status) VALUES 
                ('" + id_comp_contact + "', '" + id_prod_order + "', '', NOW(), '" + note + "', 1); SELECT LAST_INSERT_ID(); "
                id = execute_query(qm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id + ",151); ", True, "", "", "", "")

                'query det
                Dim qd As String = "INSERT INTO tb_prod_claim_return_det(id_prod_claim_return, id_prod_order_det, id_product, qty, price, remark) VALUES "
                Dim ix As Integer = 0
                For d As Integer = 0 To ((GVDetail.RowCount - 1) - GetGroupRowCount(GVDetail))
                    Dim id_prod_order_det As String = GVDetail.GetRowCellValue(d, "id_prod_order_det").ToString
                    Dim id_product As String = GVDetail.GetRowCellValue(d, "id_product").ToString
                    Dim qty As String = decimalSQL(GVDetail.GetRowCellValue(d, "qty").ToString)
                    Dim price As String = decimalSQL(GVDetail.GetRowCellValue(d, "price").ToString)
                    Dim remark As String = GVDetail.GetRowCellValue(d, "remark").ToString

                    If GVDetail.GetRowCellValue(d, "qty") > 0 Then
                        If ix > 0 Then
                            qd += ", "
                        End If
                        qd += "('" + id + "', '" + id_prod_order_det + "', '" + id_product + "', '" + qty + "', '" + price + "', '" + remark + "') "
                        ix += 1
                    End If
                Next
                If ix > 0 Then
                    execute_non_query(qd, True, "", "", "", "")
                End If

                'submit
                'submit_who_prepared(151, id, id_user)

                'refresh
                action = "upd"
                actionLoad()
                FormProductionClaimReturn.viewData()
                FormProductionClaimReturn.GVData.FocusedRowHandle = find_row(FormProductionClaimReturn.GVData, "id_prod_claim_return", id)

                infoCustom("Claim Return : " + TxtNumber.Text.ToString + " was created successfully. Please upload supporting documents")
                attach()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        Cursor = Cursors.WaitCursor
        FormPopUpProd.id_pop_up = "11"
        FormPopUpProd.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub PEView_DoubleClick(sender As Object, e As EventArgs) Handles PEView.DoubleClick
        Cursor = Cursors.WaitCursor
        pre_viewImages("2", PEView, id_design, True)
        Cursor = Cursors.Default
    End Sub
End Class