Imports Microsoft.Office.Interop
Public Class FormProductionRetOutSingle
    Public action As String
    Public id_prod_order_ret_out As String = "0"
    Public id_prod_order As String = "-1"
    Public id_comp_contact_to As String
    Public id_comp_contact_from As String
    Public id_prod_order_det_list, id_prod_order_ret_out_det_list As New List(Of String)
    Dim date_start As Date
    Public id_report_status As String
    Public cond_check As Boolean = True
    Public sample_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal
    Public id_design As String = "-1"
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls As String = get_setup_field("bof_xls_retout")

    Private Sub FormProductionRetOutSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BtnBrowsePO.Focus()
        viewReportStatus() 'get report status
        actionLoad()
    End Sub

    Sub load_ovh()
        Dim query As String = "SELECT ovhp.`id_ovh_price`,c.`comp_name`,ovh.`overhead`,ovhp.`ovh_price` FROM tb_m_ovh_price ovhp
INNER JOIN tb_m_ovh ovh ON ovh.`id_ovh`=ovhp.`id_ovh`
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ovhp.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`"
        viewSearchLookupQuery(SLEOvh, query, "id_ovh_price", "overhead", "id_ovh_price")
        SLEOvh.Properties.View.FocusedRowHandle = 1
    End Sub

    Sub load_type_ret()
        Dim query As String = "SELECT id_return_qc_type,return_qc_type FROM `tb_lookup_return_qc_type` "
        viewLookupQuery(LERetType, query, 0, "return_qc_type", "id_return_qc_type")
    End Sub

    Private Sub FormProductionRetOutSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        load_ovh()
        load_type_ret()

        If action = "ins" Then
            TxtRetOutNumber.Text = ""
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            DERet.Text = view_date(0)

            'own source
            Dim id_qc As String = execute_query("SELECT id_qc_dept FROM tb_opt", 0, True, "", "", "", "")
            Dim query_get_comp_name As String = "SELECT b.comp_name, b.comp_number FROM tb_m_comp_contact a "
            query_get_comp_name += "INNER JOIN tb_m_comp b ON a.id_comp = b.id_comp "
            query_get_comp_name += "WHERE a.id_comp_contact = '" + id_qc + "' AND b.id_departement = '" + id_departement_user + "'"
            Try
                Dim data_comp_from As DataTable = execute_query(query_get_comp_name, -1, True, "", "", "", "")
                TxtNameCompFrom.Text = data_comp_from(0)("comp_name").ToString
                TxtCodeCompFrom.Text = data_comp_from(0)("comp_number").ToString
                id_comp_contact_from = id_qc
            Catch ex As Exception
                TxtNameCompFrom.Text = ""
                TxtCodeCompFrom.Text = ""
                id_comp_contact_from = id_qc
            End Try
        ElseIf action = "upd" Then
            'Enable/Disable
            BMark.Enabled = True
            BtnBrowsePO.Enabled = False
            GroupControlRet.Enabled = True
            GroupControlListBarcode.Enabled = True
            BtnInfoSrs.Enabled = True


            'View data
            Dim query As String = "SELECT id_return_qc_type,id_ovh_price,DATE_FORMAT(a.prod_order_ret_out_date,'%Y-%m-%d') as prod_order_ret_out_datex, a.id_report_status, a.id_prod_order, a.id_prod_order_ret_out, a.prod_order_ret_out_date, "
            query += "a.prod_order_ret_out_due_date, a.prod_order_ret_out_note, a.prod_order_ret_out_number,  "
            query += "dsg.id_design, dsg.design_display_name,b.prod_order_number, (c.id_comp_contact) AS id_comp_contact_from, (d.comp_name) AS comp_name_contact_from, (d.comp_number) AS comp_code_contact_from, (d.address_primary) AS comp_address_contact_from, "
            query += "(e.id_comp_contact) AS id_comp_contact_to, (f.comp_name) AS comp_name_contact_to, (f.comp_number) AS comp_code_contact_to,(f.address_primary) AS comp_address_contact_to, dsg.id_sample, ss.season "
            query += "FROM tb_prod_order_ret_out a "
            query += "INNER JOIN tb_prod_order b ON a.id_prod_order = b.id_prod_order "
            query += "INNER JOIN tb_season_delivery del ON del.id_delivery = b.id_delivery "
            query += "INNER JOIN tb_season ss ON ss.id_season = del.id_season "
            query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
            query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
            query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
            query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
            query += "INNER JOIN tb_prod_demand_design pd_design ON pd_design.id_prod_demand_design = b.id_prod_demand_design "
            query += "INNER JOIN tb_m_design dsg ON dsg.id_design = pd_design.id_design "
            query += "WHERE a.id_prod_order_ret_out='" + id_prod_order_ret_out + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtOrderNumber.Text = data.Rows(0)("prod_order_number").ToString
            id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_code_contact_from").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_contact_from").ToString
            id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_code_contact_to").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name_contact_to").ToString
            MEAdrressCompTo.Text = data.Rows(0)("comp_address_contact_to").ToString
            'Dim start_date_arr() As String = data.Rows(0)("prod_order_ret_out_date").ToString.Split(" ")
            DERet.Text = view_date_from(data.Rows(0)("prod_order_ret_out_datex").ToString, 0)
            'Dim start_due_date_arr() As String = data.Rows(0)("prod_order_ret_out_due_date").ToString.Split(" ")
            DERetDueDate.EditValue = data.Rows(0)("prod_order_ret_out_due_date")
            TxtRetOutNumber.Text = data.Rows(0)("prod_order_ret_out_number").ToString
            MENote.Text = data.Rows(0)("prod_order_ret_out_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_prod_order = data.Rows(0)("id_prod_order").ToString
            id_design = data.Rows(0)("id_design").ToString
            TxtDesign.Text = data.Rows(0)("design_display_name").ToString
            TxtSeason.Text = data.Rows(0)("season").ToString
            '
            LERetType.ItemIndex = LERetType.Properties.GetDataSourceRowIndex("id_return_qc_type", data.Rows(0)("id_return_qc_type").ToString)
            If LERetType.EditValue.ToString = "2" Then
                SLEOvh.EditValue = data.Rows(0)("id_ovh_price").ToString
            End If
            '
            pre_viewImages("2", PEView, id_design, False)
            PEView.Enabled = True

            view_barcode_list()
            viewDetailReturn()
            check_but()
            allow_status()
        End If
    End Sub
    Sub allow_status()
        If check_edit_report_status(id_report_status, "31", id_prod_order_ret_out) Then
            BtnBrowseContactFrom.Enabled = True
            BtnBrowseContactTo.Enabled = True
            GVRetDetail.OptionsBehavior.Editable = True
            BtnAdd.Enabled = True
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
            MENote.Properties.ReadOnly = False
            DERetDueDate.Enabled = True
            BtnSave.Enabled = True
            BScan.Enabled = True
            BDelete.Enabled = True
            BtnInfoSrs.Enabled = True
            GVRetDetail.OptionsCustomization.AllowGroup = False
        Else
            BtnBrowseContactFrom.Enabled = False
            BtnBrowseContactTo.Enabled = False
            GVRetDetail.OptionsBehavior.Editable = False
            BtnAdd.Enabled = False
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
            MENote.Properties.ReadOnly = True
            DERet.Properties.ReadOnly = True
            DERetDueDate.Enabled = False
            BtnSave.Enabled = False
            BScan.Enabled = False
            BDelete.Enabled = False
            BtnInfoSrs.Enabled = False
            GVRetDetail.OptionsCustomization.AllowGroup = True
        End If

        'attachment
        'If check_attach_report_status(id_report_status, "31", id_prod_order_ret_out) Then
        '    BtnAttachment.Enabled = True
        'Else
        '    BtnAttachment.Enabled = False
        'End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        'bof column
        If bof_column = "1" And LEReportStatus.EditValue.ToString <> "5" Then
            BtnXlsBOF.Visible = True
        Else
            BtnXlsBOF.Visible = False
        End If

        TxtRetOutNumber.Focus()
    End Sub

    Sub mainVendor()
        'main vendor if reguler
        If LERetType.EditValue.ToString = "1" Then
            Dim data_vend As DataTable = getMainVendor(id_prod_order)
            Try
                id_comp_contact_to = data_vend.Rows(0)("id_comp_contact").ToString
                TxtCodeCompTo.Text = data_vend.Rows(0)("comp_number").ToString
                TxtNameCompTo.Text = data_vend.Rows(0)("comp_name").ToString
                MEAdrressCompTo.Text = data_vend.Rows(0)("address_primary").ToString
            Catch ex As Exception
                id_comp_contact_to = "-1"
                TxtCodeCompTo.Text = ""
                TxtNameCompTo.Text = ""
                MEAdrressCompTo.Text = ""
            End Try
        Else
            Dim query_vend As String = "SELECT cc.id_comp_contact,c.comp_number,c.comp_name,c.address_primary FROM tb_m_ovh_price ovhp
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovhp.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
WHERE ovhp.id_ovh_price='" & SLEOvh.EditValue.ToString & "'"
            Dim data_vend As DataTable = execute_query(query_vend, -1, True, "", "", "", "")
            Try
                id_comp_contact_to = data_vend.Rows(0)("id_comp_contact").ToString
                TxtCodeCompTo.Text = data_vend.Rows(0)("comp_number").ToString
                TxtNameCompTo.Text = data_vend.Rows(0)("comp_name").ToString
                MEAdrressCompTo.Text = data_vend.Rows(0)("address_primary").ToString
            Catch ex As Exception
                id_comp_contact_to = "-1"
                TxtCodeCompTo.Text = ""
                TxtNameCompTo.Text = ""
                MEAdrressCompTo.Text = ""
            End Try
        End If

    End Sub

    'sub check_but
    Sub check_but()
        'Constraint Status
        If GVRetDetail.RowCount > 0 Then
            BtnEdit.Visible = True
            BtnDel.Visible = True
        Else
            BtnEdit.Visible = False
            BtnDel.Visible = False
        End If
    End Sub
    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub view_barcode_list()
        Dim query As String = "SELECT ('0') AS no, ('') AS ean_code, ('0') AS id_prod_order_det, ('1') AS is_fix "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
        deleteRowsBc()
        allowDelete()
    End Sub

    Sub viewDetailReturn()
        If action = "ins" Then
            Dim query As String = "CALL view_stock_prod_rec('" + id_prod_order + "', '0', '0', '0', '0', '0', '0')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_prod_order_det_list.Add(data.Rows(i)("id_prod_order_det").ToString)
            Next
            GCRetDetail.DataSource = data
            If LERetType.EditValue.ToString = "2" Then
                GridColumnPriceOVH.VisibleIndex = "6"
                GridColumnAmount.VisibleIndex = "7"
                'getprice
                Dim prc As Decimal = 0.00
                prc = SLEOvh.Properties.View.GetFocusedRowCellValue("ovh_price").ToString
                For i As Integer = 0 To GVRetDetail.RowCount - 1
                    GVRetDetail.SetRowCellValue(i, "ovh_price", prc)
                Next
            Else
                GridColumnPriceOVH.VisibleIndex = "-1"
                GridColumnAmount.VisibleIndex = "-1"
            End If
        ElseIf action = "upd" Then
            Dim query As String = "CALL view_return_out_prod('" + id_prod_order_ret_out + "', '0')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_prod_order_det_list.Add(data.Rows(i)("id_prod_order_det").ToString)
                id_prod_order_ret_out_det_list.Add(data.Rows(i)("id_prod_order_ret_out_det").ToString)
                For j As Integer = 0 To data.Rows(i)("prod_order_ret_out_det_qty") - 1
                    GVBarcode.AddNewRow()
                    GVBarcode.SetFocusedRowCellValue("ean_code", data.Rows(i)("ean_code"))
                    GVBarcode.SetFocusedRowCellValue("id_prod_order_det", data.Rows(i)("id_prod_order_det"))
                    GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                Next
            Next

            GCRetDetail.DataSource = data
            GCBarcode.RefreshDataSource()
            GVBarcode.RefreshData()

            If LERetType.EditValue.ToString = "1" Then
                GridColumnPriceOVH.VisibleIndex = "-1"
                GridColumnAmount.VisibleIndex = "-1"
            End If
        End If

        SLEOvh.Enabled = False
        LERetType.Enabled = False
        check_but()
    End Sub
    'Button
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        makeSafeGV(GVRetDetail)

        'Cek isi qty tidak terpakai karena qty = 0 akan dihapus stelah posisi ter approve
        'Dim cond_qty As Boolean = True
        'Dim qty As Decimal
        'For i As Integer = 0 To (GVRetDetail.RowCount - 1)
        '    qty = GVRetDetail.GetRowCellValue(i, "prod_order_ret_out_det_qty")
        '    If qty = 0.0 Then
        '        cond_qty = False
        '    End If
        'Next

        'cek dengan requisition di DB
        For i As Integer = 0 To ((GVRetDetail.RowCount - 1) - GetGroupRowCount(GVRetDetail))
            Dim id_prod_order_det_cekya As String = GVRetDetail.GetRowCellValue(i, "id_prod_order_det").ToString
            Dim qty_plya As String = GVRetDetail.GetRowCellValue(i, "prod_order_ret_out_det_qty").ToString
            Dim sample_checkya As String = GVRetDetail.GetRowCellValue(i, "name").ToString + " / Size : " + GVRetDetail.GetRowCellValue(i, "size").ToString
            isAllowRequisition(sample_checkya, id_prod_order_det_cekya, qty_plya)
            If Not cond_check Then
                Exit For
            End If
        Next

        If Not formIsValidInPanel(EPRet, PanelControlTopMiddle) Or Not formIsValidInPanel(EPRet, PanelControlTopRight) Then
            errorInput()
        ElseIf GVRetDetail.RowCount = 0 Then
            errorCustom("Qty can't blank or zero value !")
        ElseIf Not cond_check Then
            errorCustom("Product : '" + sample_check + "' cannot exceed " + allow_sum.ToString("F2") + ", please check in Info Qty ! ")
            infoQty()
        Else
            Dim query As String
            Dim prod_order_ret_out_number As String = ""
            'Dim prod_order_ret_out_due_date_format As Date = CType(DERetDueDate.Text, Date)
            Dim prod_order_ret_out_due_date As String = DateTime.Parse(DERetDueDate.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim prod_order_ret_out_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim id_prod_order_det, prod_order_ret_out_det_qty, prod_order_ret_out_det_note As String
            Dim id_prod_order_ret_out_det As String
            Dim id_ovh_price As String = "NULL"
            Dim id_return_qc_type As String = "1"
            '
            If LERetType.EditValue.ToString = "2" Then
                id_ovh_price = "'" & SLEOvh.EditValue.ToString & "'"
            End If
            '
            id_return_qc_type = LERetType.EditValue.ToString
            '
            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        BtnSave.Enabled = False
                        prod_order_ret_out_number = header_number_prod("4")

                        'Main tbale
                        query = "INSERT INTO tb_prod_order_ret_out(id_prod_order, prod_order_ret_out_number, id_comp_contact_to, id_comp_contact_from, prod_order_ret_out_date, prod_order_ret_out_due_date, prod_order_ret_out_note, id_report_status,id_ovh_price,id_return_qc_type) "
                        query += "VALUES('" + id_prod_order + "', '" + prod_order_ret_out_number + "', '" + id_comp_contact_to + "', '" + id_comp_contact_from + "', NOW(), '" + prod_order_ret_out_due_date + "', '" + prod_order_ret_out_note + "', '" + id_report_status + "'," & id_ovh_price & ",'" & id_return_qc_type & "') ; SELECT LAST_INSERT_ID(); "
                        id_prod_order_ret_out = execute_query(query, 0, True, "", "", "", "")

                        'insert who prepared
                        increase_inc_prod("4")
                        insert_who_prepared("31", id_prod_order_ret_out, id_user)

                        'Detail return
                        For j As Integer = 0 To ((GVRetDetail.RowCount - 1) - GetGroupRowCount(GVRetDetail))
                            Try
                                id_prod_order_det = GVRetDetail.GetRowCellValue(j, "id_prod_order_det").ToString
                                prod_order_ret_out_det_qty = decimalSQL(GVRetDetail.GetRowCellValue(j, "prod_order_ret_out_det_qty").ToString)
                                prod_order_ret_out_det_note = GVRetDetail.GetRowCellValue(j, "prod_order_ret_out_det_note").ToString
                                query = "INSERT tb_prod_order_ret_out_det(id_prod_order_ret_out, id_prod_order_det, prod_order_ret_out_det_qty,ovh_price, prod_order_ret_out_det_note) "
                                query += "VALUES('" + id_prod_order_ret_out + "', '" + id_prod_order_det + "', '" + prod_order_ret_out_det_qty + "','" + decimalSQL(GVRetDetail.GetRowCellValue(j, "ovh_price").ToString) + "', '" + prod_order_ret_out_det_note + "') "
                                execute_non_query(query, True, "", "", "", "")
                            Catch ex As Exception
                                stopCustom(ex.ToString)
                            End Try
                        Next

                        'submit
                        submit_who_prepared("31", id_prod_order_ret_out, id_user)

                        FormProductionRet.viewRetOut()
                        FormProductionRet.GVRetOut.FocusedRowHandle = find_row(FormProductionRet.GVRetOut, "id_prod_order_ret_out", id_prod_order_ret_out)
                        action = "upd"
                        actionLoad()

                        exportToBOF(False)

                        infoCustom("Document #" + prod_order_ret_out_number + " was created successfully.")
                    Catch ex As Exception
                        stopCustom(ex.ToString)
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        prod_order_ret_out_number = TxtRetOutNumber.Text

                        'edit main table
                        query = "UPDATE tb_prod_order_ret_out SET id_prod_order = '" + id_prod_order + "', prod_order_ret_out_number = '" + prod_order_ret_out_number + "', id_comp_contact_to = '" + id_comp_contact_to + "', id_comp_contact_from = '" + id_comp_contact_from + "', prod_order_ret_out_due_date = '" + prod_order_ret_out_due_date + "', prod_order_ret_out_due_date = '" + prod_order_ret_out_due_date + "', id_report_status = '" + id_report_status + "', prod_order_ret_out_note = '" + prod_order_ret_out_note + "',id_ovh_price=" & id_ovh_price & ",id_return_qc_type='" & id_return_qc_type & "' WHERE id_prod_order_ret_out = '" + id_prod_order_ret_out + "' "
                        execute_non_query(query, True, "", "", "", "")

                        'edit detail table
                        For j As Integer = 0 To ((GVRetDetail.RowCount - 1) - GetGroupRowCount(GVRetDetail))
                            Try
                                id_prod_order_ret_out_det = GVRetDetail.GetRowCellValue(j, "id_prod_order_ret_out_det").ToString
                                id_prod_order_det = GVRetDetail.GetRowCellValue(j, "id_prod_order_det").ToString
                                prod_order_ret_out_det_qty = decimalSQL(GVRetDetail.GetRowCellValue(j, "prod_order_ret_out_det_qty").ToString)
                                prod_order_ret_out_det_note = GVRetDetail.GetRowCellValue(j, "prod_order_ret_out_det_note").ToString
                                If id_prod_order_ret_out_det = "0" Then
                                    query = "INSERT tb_prod_order_ret_out_det(id_prod_order_ret_out, id_prod_order_det, prod_order_ret_out_det_qty,ovh_price, prod_order_ret_out_det_note) "
                                    query += "VALUES('" + id_prod_order_ret_out + "', '" + id_prod_order_det + "', '" + prod_order_ret_out_det_qty + "','" + decimalSQL(GVRetDetail.GetRowCellValue(j, "ovh_price").ToString) + "', '" + prod_order_ret_out_det_note + "') "
                                    execute_non_query(query, True, "", "", "", "")
                                Else
                                    query = "UPDATE tb_prod_order_ret_out_det SET id_prod_order_det = '" + id_prod_order_det + "', prod_order_ret_out_det_qty = '" + prod_order_ret_out_det_qty + "',ovh_price='" + decimalSQL(GVRetDetail.GetRowCellValue(j, "ovh_price").ToString) + "', prod_order_ret_out_det_note = '" + prod_order_ret_out_det_note + "' WHERE id_prod_order_ret_out_det = '" + id_prod_order_ret_out_det + "'"
                                    execute_non_query(query, True, "", "", "", "")
                                    id_prod_order_ret_out_det_list.Remove(id_prod_order_ret_out_det)
                                End If
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next

                        'delete sisa
                        For k As Integer = 0 To (id_prod_order_ret_out_det_list.Count - 1)
                            Try
                                query = "DELETE FROM tb_prod_order_ret_out_det WHERE id_prod_order_ret_out_det = '" + id_prod_order_ret_out_det_list(k) + "' "
                                execute_non_query(query, True, "", "", "", "")
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next

                        'View
                        FormProductionRet.viewRetOut()
                        FormProductionRet.GVRetOut.FocusedRowHandle = find_row(FormProductionRet.GVRetOut, "id_prod_order_ret_out", id_prod_order_ret_out)
                        action = "upd"
                        actionLoad()

                        exportToBOF(False)

                        infoCustom("Document #" + prod_order_ret_out_number + " was edited successfully.")
                    Catch ex As Exception
                        errorConnection()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    Private Sub BtnBrowsePO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowsePO.Click
        If LERetType.EditValue.ToString = "2" And SLEOvh.Text = "" Then
            warningCustom("Please select overhead first")
        Else
            FormPopUpProd.id_pop_up = "2"
            FormPopUpProd.ShowDialog()
        End If
    End Sub
    Private Sub BtnBrowseContactFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "29"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.ShowDialog()
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormPopUpProdDet.id_pop_up = "1"
        FormPopUpProdDet.action = "ins"
        FormPopUpProdDet.id_prod_order = id_prod_order
        FormPopUpProdDet.id_ret_out = id_prod_order_ret_out
        FormPopUpProdDet.ShowDialog()
    End Sub
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If (MessageBox.Show("Are you sure to delete this row?", "Delete Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
        Dim id_prod_order_det As String = GVRetDetail.GetFocusedRowCellDisplayText("id_prod_order_det").ToString
        id_prod_order_det_list.Remove(id_prod_order_det)
        deleteRows()
        deleteDetailBc(id_prod_order_det)
    End Sub

    Sub deleteDetailBc(ByVal id_prod_order_det As String)
        'delete detail
        Dim i As Integer = GVBarcode.RowCount - 1
        While (i >= 0)
            Dim id_prod_order_detx As String = ""
            Try
                id_prod_order_detx = GVBarcode.GetRowCellValue(i, "id_prod_order_det").ToString()
            Catch ex As Exception

            End Try
            If id_prod_order_det = id_prod_order_detx Then
                GVBarcode.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        FormPopUpProdDet.id_pop_up = "1"
        FormPopUpProdDet.action = "upd"
        FormPopUpProdDet.id_prod_order = id_prod_order
        FormPopUpProdDet.id_ret_out = id_prod_order_ret_out
        FormPopUpProdDet.ShowDialog()
    End Sub
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        GVRetDetail.BestFitColumns()
        ReportProductionRetOut.dt = GCRetDetail.DataSource
        ReportProductionRetOut.id_prod_order_ret_out = id_prod_order_ret_out
        Dim Report As New ReportProductionRetOut()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVRetDetail.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVRetDetail.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVRetDetail)

        'Parse val
        Report.LabelPO.Text = TxtOrderNumber.Text
        Report.LabelNo.Text = TxtRetOutNumber.Text
        Report.LabelFrom.Text = TxtCodeCompFrom.Text + "-" + TxtNameCompFrom.Text
        Report.LabelTo.Text = TxtCodeCompTo.Text + "-" + TxtNameCompTo.Text
        Report.LabelDate.Text = DERet.Text
        Report.LabelDueDate.Text = DERetDueDate.Text
        Report.LabelDesign.Text = TxtDesign.Text.ToString
        Report.LabelSeason.Text = TxtSeason.Text.ToString
        Report.LabelNote.Text = MENote.Text
        '
        If LERetType.EditValue.ToString = "2" Then
            Report.LOVH1.Visible = True
            Report.LOVH2.Visible = True
            Report.LOVH3.Visible = True
            Report.LOVH3.Text = SLEOvh.Text.ToString
        Else
            Report.LOVH1.Visible = False
            Report.LOVH2.Visible = False
            Report.LOVH3.Visible = False
        End If
        '
        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub
    'Validating
    Private Sub TxtOrderNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtOrderNumber.Validating
        EP_TE_cant_blank(EPRet, TxtOrderNumber)
        EPRet.SetIconPadding(TxtOrderNumber, 58)
    End Sub
    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPRet, TxtNameCompFrom)
        EPRet.SetIconPadding(TxtNameCompFrom, 30)
    End Sub
    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(EPRet, TxtNameCompTo)
        EPRet.SetIconPadding(TxtNameCompTo, 30)
    End Sub
    'Row Manipulation
    Sub focusColumnCode()
        GVRetDetail.FocusedColumn = GVRetDetail.VisibleColumns(0)
        GVRetDetail.ShowEditor()
    End Sub
    Sub newRows()
        GVRetDetail.AddNewRow()
    End Sub
    Sub deleteRows()
        GVRetDetail.DeleteRow(GVRetDetail.FocusedRowHandle)
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_prod_order_ret_out
        FormReportMark.report_mark_type = "31"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub DERetDueDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DERetDueDate.Validating
        EP_DE_cant_blank(EPRet, DERetDueDate)
    End Sub

    Private Sub DERetDueDate_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DERetDueDate.EditValueChanged
        ' Try
        date_start = execute_query("select now()", 0, True, "", "", "", "")
        DERetDueDate.Properties.MinValue = date_start
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactTo.Click
        If TxtOrderNumber.Text = "" Then
            warningCustom("Please select order first")
        Else
            FormPopUpContact.id_pop_up = "30"
            FormPopUpContact.id_cat = "1"
            FormPopUpContact.ShowDialog()
        End If
    End Sub

    'DeleteRows
    Sub deleteRowsBc()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
        GVBarcode.FocusedColumn = GVBarcode.VisibleColumns(0)
        GVBarcode.ShowEditor()
    End Sub
    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
    End Sub

    Private Sub BScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BScan.Click
        MENote.Enabled = False
        BtnBrowsePO.Enabled = False
        BtnBrowseContactFrom.Enabled = False
        BtnBrowseContactTo.Enabled = False
        BtnSave.Enabled = False
        BScan.Enabled = False
        BStop.Enabled = True
        BDelete.Enabled = False
        BtnCancel.Enabled = False
        GVRetDetail.OptionsBehavior.Editable = False
        ControlBox = False
        BtnAdd.Enabled = False
        BtnEdit.Enabled = False
        BtnDel.Enabled = False
        DERetDueDate.Properties.ReadOnly = True
        BtnInfoSrs.Enabled = False
        newRowsBc()
        'allowDelete()
    End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop.Click
        For i As Integer = 0 To (GVBarcode.RowCount - 1)
            Dim check_code As String = ""
            Try
                check_code = GVBarcode.GetRowCellValue(i, "ean_code").ToString()
            Catch ex As Exception

            End Try
            If check_code = "" Or check_code = Nothing Or IsDBNull(check_code) Then
                GVBarcode.DeleteRow(i)
            End If
        Next

        MENote.Enabled = True
        BtnBrowsePO.Enabled = True
        BtnBrowseContactFrom.Enabled = True
        BtnBrowseContactTo.Enabled = True
        BtnSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BtnCancel.Enabled = True
        allowDelete()
        GVRetDetail.OptionsBehavior.Editable = True
        ControlBox = True
        BtnAdd.Enabled = True
        BtnEdit.Enabled = True
        BtnDel.Enabled = True
        DERetDueDate.Enabled = True
        DERetDueDate.Properties.ReadOnly = False
        BtnInfoSrs.Enabled = True
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_prod_order_det As String = GVBarcode.GetFocusedRowCellValue("id_prod_order_det").ToString
            deleteRowsBc()
            If id_prod_order_det <> "" Or id_prod_order_det <> Nothing Then
                GVBarcode.ApplyFindFilter("")
                countQty(id_prod_order_det)
            End If
            allowDelete()
        End If
    End Sub

    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        '' MsgBox(GVBarcode.GetFocusedRowCellValue("ean_code").ToString)
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("ean_code").ToString
        Dim code_found As Boolean = False
        Dim id_prod_order_det As String = ""
        For i As Integer = 0 To (GVRetDetail.RowCount - 1)
            Dim code As String = GVRetDetail.GetRowCellValue(i, "ean_code").ToString
            id_prod_order_det = GVRetDetail.GetRowCellValue(i, "id_prod_order_det").ToString
            If code = code_check Then
                code_found = True
                Exit For
            End If
        Next
        If Not code_found Then
            GVBarcode.SetFocusedRowCellValue("ean_code", "")
            stopCustom("Data not found !")
        Else
            GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            GVBarcode.SetFocusedRowCellValue("id_prod_order_det", id_prod_order_det)
            countQty(id_prod_order_det)
            newRowsBc()
            'allowDelete()
        End If
    End Sub

    Private Sub GVBarcode_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVBarcode.CellValueChanged
        'MsgBox(GVBarcode.GetFocusedRowCellValue("ean_code").ToString)
        'GVBarcode.AddNewRow()
        'MsgBox("k")
    End Sub

    Private Sub GVBarcode_FocusedColumnChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVBarcode.FocusedColumnChanged
        If Not GVBarcode.FocusedColumn.FieldName = "ean_code" Then
            GVBarcode.FocusedColumn = GVBarcode.Columns("ean_code")
        End If
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
        End If
    End Sub

    Sub noEdit()
        Try
            Dim is_fix As String = GVBarcode.GetFocusedRowCellDisplayText("is_fix")
            'MsgBox(id_prod_order_rec_det)
            If is_fix <> "2" Then
                GridColumnBarcode.OptionsColumn.AllowEdit = True
            Else
                GridColumnBarcode.OptionsColumn.AllowEdit = False
            End If
            'MsgBox(id_prod_order_rec_det)
        Catch ex As Exception
            'errorCustom(ex.ToString)
        End Try
    End Sub

    Private Sub GVBarcode_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBarcode.FocusedRowChanged
        noEdit()
    End Sub

    Sub countQty(ByVal id_prod_order_detx As String)
        Dim tot As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_prod_order_det As String = GVBarcode.GetRowCellValue(i, "id_prod_order_det").ToString
            If id_prod_order_det = id_prod_order_detx Then
                tot = tot + 1.0
            End If
        Next
        GVRetDetail.FocusedRowHandle = find_row(GVRetDetail, "id_prod_order_det", id_prod_order_detx)
        GVRetDetail.SetFocusedRowCellValue("prod_order_ret_out_det_qty", tot)
        GCRetDetail.RefreshDataSource()
        GVRetDetail.RefreshData()
    End Sub

    Private Sub GVRetDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRetDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnInfoSrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInfoSrs.Click
        infoQty()
    End Sub

    Sub isAllowRequisition(ByVal sample_name As String, ByVal id_prod_order_det_cek As String, ByVal qty_plx As String)
        cond_check = True
        qty_pl = Decimal.Parse(qty_plx.ToString)
        sample_check = sample_name
        Dim query_check As String = "CALL view_stock_prod_rec('" + id_prod_order + "', '" + id_prod_order_det_cek + "', '" + id_prod_order_ret_out + "', '0','0', '0', '0') "
        Dim data As DataTable = execute_query(query_check, -1, True, "", "", "", "")
        allow_sum = Decimal.Parse(data.Rows(0)("qty"))
        If qty_pl > allow_sum Then
            cond_check = False
        End If
    End Sub

    Sub infoQty()
        FormPopUpProdDet.id_pop_up = "1"
        FormPopUpProdDet.action = "ins"
        FormPopUpProdDet.id_prod_order = id_prod_order
        FormPopUpProdDet.id_ret_out = id_prod_order_ret_out
        FormPopUpProdDet.BtnSave.Visible = False
        FormPopUpProdDet.is_info_form = True
        FormPopUpProdDet.ShowDialog()
    End Sub

    Private Sub PEView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PEView.DoubleClick
        Cursor = Cursors.WaitCursor
        pre_viewImages("2", PEView, id_design, True)
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_prod_order_ret_out
        FormDocumentUpload.report_mark_type = "31"
        '
        If Not check_edit_report_status(id_report_status, "31", id_prod_order_ret_out) Then
            FormDocumentUpload.is_no_delete = "1"
        End If
        '
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnXlsBOF_Click(sender As Object, e As EventArgs) Handles BtnXlsBOF.Click
        exportToBOF(True)
    End Sub

    Sub exportToBOF(ByVal show_msg As Boolean)
        If bof_column = "1" Then
            Cursor = Cursors.WaitCursor

            'hide column
            For c As Integer = 0 To GVRetDetail.Columns.Count - 1
                GVRetDetail.Columns(c).Visible = False
            Next
            GridColumnCode.VisibleIndex = 0
            GridColumnQty.VisibleIndex = 1
            GridColumnNumber.VisibleIndex = 2
            GridColumnFrom.VisibleIndex = 3
            GridColumnTo.VisibleIndex = 4
            GridColumnRemark.VisibleIndex = 5
            GVRetDetail.OptionsPrint.PrintFooter = False
            GVRetDetail.OptionsPrint.PrintHeader = False


            'export excel
            Dim path_root As String = ""
            Try
                ' Open the file using a stream reader.
                Using sr As New IO.StreamReader(Application.StartupPath & "\pro_path.txt")
                    ' Read the stream to a string and write the string to the console.
                    path_root = sr.ReadToEnd()
                End Using
            Catch ex As Exception
            End Try

            Dim fileName As String = bof_xls + ".xls"
            Dim exp As String = IO.Path.Combine(path_root, fileName)
            Try
                ExportToExcel(GVRetDetail, exp, show_msg)
            Catch ex As Exception
                stopCustom("Please close your excel file first then try again later")
            End Try

            'show column
            GridColumnNox.VisibleIndex = 0
            GridColumnCode.VisibleIndex = 1
            GridColumnEanCode.VisibleIndex = 2
            GridColumnName.VisibleIndex = 3
            GridColumnSize.VisibleIndex = 4
            GridColumnQty.VisibleIndex = 5
            If LERetType.EditValue.ToString = "2" Then
                GridColumnPriceOVH.VisibleIndex = 6
                GridColumnAmount.VisibleIndex = 7
                GridColumnRemark.VisibleIndex = 8
            Else
                GridColumnRemark.VisibleIndex = 6
            End If

            GridColumnNumber.Visible = False
            GridColumnFrom.Visible = False
            GridColumnTo.Visible = False
            GVRetDetail.OptionsPrint.PrintFooter = True
            GVRetDetail.OptionsPrint.PrintHeader = True
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ExportToExcel(ByVal dtTemp As DevExpress.XtraGrid.Views.Grid.GridView, ByVal filepath As String, show_msg As Boolean)
        Dim strFileName As String = filepath
        If System.IO.File.Exists(strFileName) Then
            System.IO.File.Delete(strFileName)
        End If
        Dim _excel As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()


        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = -1

        ' export the Columns 
        'If CheckBox1.Checked Then
        '    For Each dc In dt.Columns
        '        colIndex = colIndex + 1
        '        wSheet.Cells(1, colIndex) = dc.ColumnName
        '    Next
        'End If

        'export the rows 
        For i As Integer = 0 To dtTemp.RowCount - 1
            rowIndex = rowIndex + 1
            colIndex = 0
            For j As Integer = 0 To dtTemp.VisibleColumns.Count - 1
                colIndex = colIndex + 1
                If j = 0 Then
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "code").ToString
                ElseIf j = 1 Then
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "prod_order_ret_out_det_qty")
                ElseIf j = 2 Then
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "number").ToString
                ElseIf j = 3 Then
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "from").ToString
                ElseIf j = 4 Then
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "to").ToString
                Else
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "prod_order_ret_out_det_note").ToString
                End If
            Next
        Next

        wSheet.Columns.AutoFit()
        wBook.SaveAs(strFileName, Excel.XlFileFormat.xlExcel5)

        'release the objects
        ReleaseObject(wSheet)
        wBook.Close(False)
        ReleaseObject(wBook)
        _excel.Quit()
        ReleaseObject(_excel)
        ' some time Office application does not quit after automation: so i am calling GC.Collect method.
        GC.Collect()

        If show_msg Then
            infoCustom("File exported successfully")
        End If
    End Sub

    Private Sub GVRetDetail_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVRetDetail.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName = "from" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompFrom.Text.ToString
        ElseIf e.Column.FieldName = "to" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompTo.Text.ToString
        ElseIf e.Column.FieldName = "number" AndAlso e.IsGetData Then
            e.Value = TxtRetOutNumber.Text.ToString
        End If
    End Sub

    Private Sub LERetType_EditValueChanged(sender As Object, e As EventArgs) Handles LERetType.EditValueChanged
        If LERetType.EditValue.ToString = "1" Then
            'reguler
            SLEOvh.Enabled = False
            SLEOvh.EditValue = Nothing
        Else
            SLEOvh.Enabled = True
            SLEOvh.EditValue = Nothing
        End If
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub
End Class