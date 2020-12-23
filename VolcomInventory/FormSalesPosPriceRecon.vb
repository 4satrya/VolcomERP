Public Class FormSalesPosPriceRecon
    Public id As String = "-1"
    Public action As String = ""
    Dim rmt As String = "281"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "2"
    Public is_view As String = "-1"

    Private Sub FormSalesPosPriceRecon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Private Sub FormSalesPosPriceRecon_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            'view
            Dim time_now As DateTime = getTimeDB()
            DECreated.EditValue = time_now
            viewDetail()

            'insert row
            If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                FormMain.SplashScreenManager1.ShowWaitForm()
            End If
            For d As Integer = 0 To FormSalesPOS.GVProbList.RowCount - 1
                Dim newRow As DataRow = (TryCast(GCData.DataSource, DataTable)).NewRow()
                newRow("id_sales_pos_prob") = FormSalesPOS.GVProbList.GetRowCellValue(d, "id_sales_pos_prob").ToString
                newRow("id_sales_pos") = FormSalesPOS.GVProbList.GetRowCellValue(d, "id_sales_pos").ToString
                newRow("sales_pos_number") = FormSalesPOS.GVProbList.GetRowCellValue(d, "sales_pos_number").ToString
                newRow("id_comp") = FormSalesPOS.GVProbList.GetRowCellValue(d, "id_comp").ToString
                newRow("comp_number") = FormSalesPOS.GVProbList.GetRowCellValue(d, "comp_number").ToString
                newRow("comp_name") = FormSalesPOS.GVProbList.GetRowCellValue(d, "comp_name").ToString
                newRow("id_product") = FormSalesPOS.GVProbList.GetRowCellValue(d, "id_product").ToString
                newRow("code") = FormSalesPOS.GVProbList.GetRowCellValue(d, "code").ToString
                newRow("name") = FormSalesPOS.GVProbList.GetRowCellValue(d, "name").ToString
                newRow("size") = FormSalesPOS.GVProbList.GetRowCellValue(d, "size").ToString
                newRow("id_design_price_retail") = FormSalesPOS.GVProbList.GetRowCellValue(d, "id_design_price_retail").ToString
                newRow("design_price_retail") = FormSalesPOS.GVProbList.GetRowCellValue(d, "design_price_retail")
                newRow("design_price_store") = FormSalesPOS.GVProbList.GetRowCellValue(d, "design_price_store")
                Dim dt_prc As DataTable = getUsedPrice(FormSalesPOS.GVProbList.GetRowCellValue(d, "id_product").ToString, decimalSQL(FormSalesPOS.GVProbList.GetRowCellValue(d, "design_price_store").ToString))
                If dt_prc.Rows.Count > 0 Then
                    newRow("id_design_price_valid") = dt_prc.Rows(0)("id_design_price").ToString
                    newRow("design_price_valid") = dt_prc.Rows(0)("design_price")
                    newRow("note") = "OK"
                Else
                    newRow("id_design_price_valid") = "0"
                    newRow("design_price_valid") = 0.00
                    newRow("note") = "Price not found"
                End If
                TryCast(GCData.DataSource, DataTable).Rows.Add(newRow)
                GCData.RefreshDataSource()
                GVData.RefreshData()
                GVData.BestFitColumns()
            Next
            FormMain.SplashScreenManager1.CloseWaitForm()
        ElseIf action = "upd" Then
            Dim query As String = "SELECT r.id_sales_pos_recon, r.number, r.created_date, r.note, r.id_report_status, rs.report_status, r.is_confirm 
            FROM tb_sales_pos_recon r
            INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = r.id_report_status
            WHERE r.id_sales_pos_recon='" + id + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("number").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            is_confirm = data.Rows(0)("is_confirm").ToString
            MENote.Text = data.Rows(0)("note").ToString
            viewDetail()
            allowStatus()
        End If
    End Sub

    Function getUsedPrice(ByVal id_prod_par As String, ByVal price_par As String) As DataTable
        Dim query As String = "SELECT prc.id_design_price, prc.design_price 
        FROM tb_m_product p
        INNER JOIN tb_m_design_price prc ON prc.id_design = p.id_design
        WHERE p.id_product='" + id_prod_par + "' AND prc.design_price='" + price_par + "'
        ORDER BY prc.id_design_price DESC
        LIMIT 1 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "Select rd.id_sales_pos_recon_det, rd.id_sales_pos_recon,
        rd.id_sales_pos_prob, rd.id_sales_pos, rd.id_comp, sp.sales_pos_number, c.comp_number, c.comp_name,
        rd.id_product, p.product_full_code As `code`, p.product_display_name As `name`, cd.code_detail_name As `size`,
        rd.id_design_price_retail, rd.design_price_retail, rd.design_price_store,
        rd.id_design_price_valid, rd.design_price_valid, rd.note, sp.report_mark_type AS `rmt_inv`
        FROM tb_sales_pos_recon_det rd
        INNER JOIN tb_m_product p ON p.id_product = rd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = rd.id_sales_pos
        INNER JOIN tb_m_comp c ON c.id_comp = rd.id_comp
        WHERE rd.id_sales_pos_recon='" + id + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allowStatus()
        If is_confirm = "2" And is_view = "-1" Then
            MENote.Properties.ReadOnly = False
            BtnCreate.Visible = True
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            BtnCancell.Visible = False
        Else
            MENote.Properties.ReadOnly = True
            BtnCreate.Visible = False
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            BtnCancell.Visible = True
        End If
        BtnAttachment.Visible = True

        'reset propose
        If is_view = "-1" And is_confirm = "1" Then
            BtnResetPropose.Visible = True
        Else
            BtnResetPropose.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
        End If
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        If action = "ins" Then
            makeSafeGV(GVData)
            GVData.ActiveFilterString = "[note]<>'OK'"
            Dim cond_ok As Boolean = True
            If GVData.RowCount > 0 Then
                cond_ok = False
            End If
            makeSafeGV(GVData)

            If Not cond_ok Then
                stopCustom("There is price not valid")
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    'save
                    Dim note As String = addSlashes(MENote.Text.ToString)
                    Dim query As String = "INSERT INTO tb_sales_pos_recon(created_date, note, id_report_status) 
                    VALUES(NOW(), '" + note + "',1); SELECT LAST_INSERT_ID(); "
                    id = execute_query(query, 0, True, "", "", "", "")
                    execute_non_query("CALL gen_number(" + id + ", " + rmt + ");", True, "", "", "", "")

                    'detail
                    Dim query_det As String = "INSERT INTO tb_sales_pos_recon_det(id_sales_pos_recon, id_sales_pos_prob, id_sales_pos, id_comp, id_product, id_design_price_retail, design_price_retail, design_price_store, id_design_price_valid, design_price_valid, note) VALUES "
                    For d As Integer = 0 To GVData.RowCount - 1
                        Dim id_sales_pos_prob As String = GVData.GetRowCellValue(d, "id_sales_pos_prob").ToString
                        Dim id_sales_pos As String = GVData.GetRowCellValue(d, "id_sales_pos").ToString
                        Dim id_comp As String = GVData.GetRowCellValue(d, "id_comp").ToString
                        Dim id_product As String = GVData.GetRowCellValue(d, "id_product").ToString
                        Dim id_design_price_retail As String = GVData.GetRowCellValue(d, "id_design_price_retail").ToString
                        Dim design_price_retail As String = decimalSQL(GVData.GetRowCellValue(d, "design_price_retail").ToString)
                        Dim design_price_store As String = decimalSQL(GVData.GetRowCellValue(d, "design_price_store").ToString)
                        Dim id_design_price_valid As String = GVData.GetRowCellValue(d, "id_design_price_valid").ToString
                        Dim design_price_valid As String = decimalSQL(GVData.GetRowCellValue(d, "design_price_valid").ToString)
                        Dim note_det As String = GVData.GetRowCellValue(d, "note").ToString
                        If d > 0 Then
                            query_det += ","
                        End If
                        query_det += "('" + id + "', '" + id_sales_pos_prob + "', '" + id_sales_pos + "', '" + id_comp + "', '" + id_product + "', '" + id_design_price_retail + "', '" + design_price_retail + "', '" + design_price_store + "', '" + id_design_price_valid + "', '" + design_price_valid + "', '" + note_det + "') "
                    Next
                    If GVData.RowCount > 0 Then
                        execute_non_query(query_det, True, "", "", "", "")
                    End If

                    'refresh main
                    Try
                        FormSalesPOS.viewProbList()
                    Catch ex As Exception
                    End Try
                    Try
                        FormSalesProbTransHistory.viewPriceRecon()
                    Catch ex As Exception
                    End Try
                    'refresh det
                    action = "upd"
                    actionLoad()
                    warningCustom("Please add attachment")
                    showAttach()
                    Cursor = Cursors.Default
                End If
            End If
        Else
            Cursor = Cursors.WaitCursor
            saveChangesHead()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        showAttach()
    End Sub

    Sub showAttach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id
        If is_confirm = "1" Or is_view = "1" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        'chek file
        Dim cond_file As Boolean = False
        Dim qf As String = "SELECT * FROM tb_doc d WHERE d.report_mark_type='" + rmt + "' AND d.id_report='" + id + "' "
        Dim df As DataTable = execute_query(qf, -1, True, "", "", "", "")
        If df.Rows.Count > 0 Then
            cond_file = True
        Else
            cond_file = False
        End If

        If Not cond_file Then
            stopCustom("Please attach document first")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to propose this document ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                saveChangesHead()
                Dim query As String = "UPDATE tb_sales_pos_recon SET is_confirm=1 WHERE id_sales_pos_recon='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                submit_who_prepared(rmt, id, id_user)

                action = "upd"
                actionLoad()
                infoCustom("Propose submitted")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Sub saveChangesHead()
        Cursor = Cursors.WaitCursor
        Dim query As String = "UPDATE tb_sales_pos_recon SET note='" + addSlashes(MENote.Text.ToString) + "' WHERE id_sales_pos_recon='" + id + "'"
        execute_non_query(query, True, "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnResetPropose_Click(sender As Object, e As EventArgs) Handles BtnResetPropose.Click
        Dim query As String = "SELECT * FROM tb_report_mark rm WHERE rm.report_mark_type=" + rmt + " AND rm.id_report_status=3
        AND rm.is_requisite=2 AND rm.id_mark=2 AND rm.id_report=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count = 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action will be reset approval and you can update this propose. Are you sure you want to reset this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query_upd As String = "-- delete report mark
                DELETE FROM tb_report_mark WHERE report_mark_type=" + rmt + " AND id_report=" + id + "; 
                -- reset confirm
                UPDATE tb_sales_pos_recon SET is_confirm=2 WHERE id_sales_pos_recon=" + id + "; "
                execute_non_query(query_upd, True, "", "", "", "")

                'refresh
                Try
                    FormSalesPOS.viewProbList()
                Catch ex As Exception
                End Try
                Try
                    FormSalesProbTransHistory.viewPriceRecon()
                Catch ex As Exception
                End Try
                actionLoad()
            End If
        Else
            stopCustom("This propose already process")
        End If
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_sales_pos_recon SET id_report_status=5 WHERE id_sales_pos_recon='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id)
            execute_non_query(queryrm, True, "", "", "", "")

            Try
                FormSalesPOS.viewProbList()
            Catch ex As Exception
            End Try
            Try
                FormSalesProbTransHistory.viewPriceRecon()
            Catch ex As Exception
            End Try
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = rmt
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub RepoLinkInvoice_Click(sender As Object, e As EventArgs) Handles RepoLinkInvoice.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim m As New ClassShowPopUp()
            m.report_mark_type = GVData.GetFocusedRowCellValue("rmt_inv").ToString
            m.id_report = GVData.GetFocusedRowCellValue("id_sales_pos").ToString
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub
End Class