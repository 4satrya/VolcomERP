Public Class FormFGCodeReplaceStoreDet 
    Public action As String = "-1"
    Public id_fg_code_replace_store As String = "-1"
    Public id_report_status As String = "-1"
    Public id_fg_code_replace_store_det_list As New List(Of String)
    Public form_type As String = "1"
    Dim is_verified As String = "-1"

    Private Sub FormFGCodeReplaceStoreDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormFGCodeReplaceStoreDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            TxtNumber.Text = ""
            BtnPrint.Enabled = False
            BMark.Enabled = False
            DEForm.Text = view_date(0)
            viewDetail()
            GroupControlListItem.Enabled = True
            check_but()

            'visible column counting
            GridColumnCountingStart.Visible = False
            GridColumnCountingEnd.Visible = False
        ElseIf action = "upd" Then
            BMark.Enabled = True
            GroupControlListItem.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True

            'visible column counting
            GridColumnCountingStart.Visible = False
            GridColumnCountingEnd.Visible = False

            'query view based on edit id's
            Dim query_c As ClassFGCodeReplace = New ClassFGCodeReplace()
            Dim query As String = query_c.queryMainStore("AND rep.id_fg_code_replace_store=''" + id_fg_code_replace_store + "'' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_fg_code_replace_store = data.Rows(0)("id_fg_code_replace_store").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtNumber.Text = data.Rows(0)("fg_code_replace_store_number").ToString
            DEForm.Text = view_date_from(data.Rows(0)("fg_code_replace_store_datex").ToString, 0)
            MENote.Text = data.Rows(0)("fg_code_replace_store_note").ToString
            is_verified = data.Rows(0)("is_verified").ToString

            'detail2
            viewDetail()
            check_but()
            allow_status()
        End If
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub check_but()
        'Dim id_productx As String = "0"
        'Try
        '    id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        'Catch ex As Exception
        'End Try

        ''Constraint Status
        'If GVItemList.RowCount > 0 And id_productx <> "0" Then
        '    BtnEdit.Enabled = True
        '    BtnDel.Enabled = True
        'Else
        '    BtnEdit.Enabled = False
        '    BtnDel.Enabled = False
        'End If
    End Sub

    Sub viewDetail()
        Dim id_param As String = ""
        Dim query_c As ClassFGCodeReplace = New ClassFGCodeReplace()
        Dim query As String = query_c.queryDetailStore(id_fg_code_replace_store)
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        If action = "upd" Then
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_fg_code_replace_store_det_list.Add(data.Rows(i)("id_fg_code_replace_store_det").ToString)
            Next
        End If
        GCItemList.DataSource = data
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "65", id_fg_code_replace_store) Then
            GVItemList.OptionsBehavior.Editable = True
            GVItemList.OptionsCustomization.AllowGroup = False
            MENote.Properties.ReadOnly = False
            GVItemList.OptionsCustomization.AllowGroup = False
            BtnSave.Enabled = False
            PanelControlNav.Enabled = True
            GVItemList.OptionsCustomization.AllowGroup = False
        Else
            GVItemList.OptionsBehavior.Editable = False
            GVItemList.OptionsCustomization.AllowGroup = True
            MENote.Properties.ReadOnly = True
            GVItemList.OptionsCustomization.AllowGroup = True
            BtnSave.Enabled = False
            PanelControlNav.Enabled = False
            GVItemList.OptionsCustomization.AllowGroup = True
        End If
        PanelControlNav.Visible = False

        If id_report_status <> "5" Then
            GridColumnCountingStart.VisibleIndex = 7
            GridColumnCountingEnd.VisibleIndex = 8
        Else
            GridColumnCountingStart.Visible = False
            GridColumnCountingEnd.Visible = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        If form_type = "1" Then
            XTPList.PageVisible = False
        Else
            XTPList.PageVisible = True
            viewBarcode()
            XTCCodeReplace.SelectedTabPageIndex = 1
            If form_type = "2" Then
                BtnPrintBarcode.Visible = True
                BtnVerifiy.Visible = False
                If is_verified = "1" Then
                    GridColumnStatus.Visible = False
                End If
            Else
                BtnPrintBarcode.Visible = False
                If is_verified = "2" Then
                    PanelControlScan.Visible = True
                    ActiveControl = TxtScan
                    BtnVerifiy.Visible = True
                Else
                    PanelControlScan.Visible = False
                    BtnVerifiy.Visible = False
                End If
            End If
        End If
    End Sub

    Sub viewBarcode()
        Dim query As String = "CALL generate_replace_barcode_list(" + id_fg_code_replace_store + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCBarcode.DataSource = data
    End Sub


    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormFGCodeReplaceStoreAdd.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click

    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If GVItemList.RowCount > 0 And GVItemList.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
                GCItemList.RefreshDataSource()
                GVItemList.RefreshData()
                check_but()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVItemList)
        ValidateChildren()

        If Not formIsValidInGroup(EPForm, GroupGeneralHeader) Then
            errorInput()
        ElseIf GVItemList.RowCount < 1 Then
            stopCustom("Item list can't blank !")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim fg_code_replace_store_number As String = TxtNumber.Text
                Dim fg_code_replace_store_note As String = MENote.Text
                Dim id_report_status As String = LEReportStatus.EditValue

                If action = "ins" Then
                    'Main tbale
                    Dim query As String = "INSERT INTO tb_fg_code_replace_store(fg_code_replace_store_number, fg_code_replace_store_date, fg_code_replace_store_note, id_report_status) "
                    query += "VALUES('" + header_number_sales("16") + "', NOW(), '" + fg_code_replace_store_note + "', '" + id_report_status + "'); SELECT LAST_INSERT_ID(); "
                    id_fg_code_replace_store = execute_query(query, 0, True, "", "", "", "")

                    increase_inc_sales("16")

                    'insert who prepared
                    insert_who_prepared("65", id_fg_code_replace_store, id_user)

                    'Detail 
                    Dim jum_i As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT INTO tb_fg_code_replace_store_det(id_fg_code_replace_store,id_product,id_pl_sales_order_del_det, id_comp,fg_code_replace_store_det_qty,counting_start,counting_end) VALUES "
                    End If
                    For i As Integer = 0 To ((GVItemList.RowCount - 1) - (GetGroupRowCount(GVItemList)))
                        Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                        Dim fg_code_replace_store_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "fg_code_replace_store_det_qty").ToString)
                        Dim counting_start As String = GVItemList.GetRowCellValue(i, "counting_start").ToString
                        Dim counting_end As String = GVItemList.GetRowCellValue(i, "counting_end").ToString
                        Dim id_comp As String = GVItemList.GetRowCellValue(i, "id_comp").ToString

                        If jum_i > 0 Then
                            query_detail += ", "
                        End If
                        query_detail += "('" + id_fg_code_replace_store + "', '" + id_product + "', NULL,'" + id_comp + "', '" + fg_code_replace_store_det_qty + "', '" + counting_start + "', '" + counting_end + "') "
                        jum_i = jum_i + 1
                    Next
                    If GVItemList.RowCount > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'call procedure
                    execute_non_query("CALL generate_replace_barcode_new('" + id_fg_code_replace_store + "')", True, "", "", "", "")

                    'submit who prepared
                    submit_who_prepared("65", id_fg_code_replace_store, id_user)

                    FormFGCodeReplace.viewCodeReplaceStore()
                    FormFGCodeReplace.GVFGCodeReplaceStore.FocusedRowHandle = find_row(FormFGCodeReplace.GVFGCodeReplaceStore, "id_fg_code_replace_store", id_fg_code_replace_store)
                    action = "upd"
                    actionLoad()
                    infoCustom("Transaction #" + TxtNumber.Text + " created successfully ")
                ElseIf action = "upd" Then
                    Dim query As String = "UPDATE tb_fg_code_replace_store SET fg_code_replace_store_note='" + fg_code_replace_store_note + "' WHERE id_fg_code_replace_store='" + id_fg_code_replace_store + "' "
                    execute_non_query(query, True, "", "", "", "")

                    'edit detail table
                    Dim jum_i As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT INTO tb_fg_code_replace_store_det(id_fg_code_replace_store,id_product,id_pl_sales_order_del_det,fg_code_replace_store_det_qty,counting_start,counting_end) VALUES "
                    End If
                    For i As Integer = 0 To ((GVItemList.RowCount - 1) - (GetGroupRowCount(GVItemList)))
                        Dim id_fg_code_replace_store_det As String = GVItemList.GetRowCellValue(i, "id_fg_code_replace_store_det").ToString
                        Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                        Dim id_pl_sales_order_del_det As String = GVItemList.GetRowCellValue(i, "id_pl_sales_order_del_det").ToString
                        Dim fg_code_replace_store_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "fg_code_replace_store_det_qty").ToString)
                        Dim counting_start As String = GVItemList.GetRowCellValue(i, "counting_start").ToString
                        Dim counting_end As String = GVItemList.GetRowCellValue(i, "counting_end").ToString

                        If id_fg_code_replace_store_det = "0" Then
                            If jum_i > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_fg_code_replace_store + "', '" + id_product + "', '" + id_pl_sales_order_del_det + "', '" + fg_code_replace_store_det_qty + "', '" + counting_start + "', '" + counting_end + "') "
                            jum_i = jum_i + 1
                        Else
                            'tidak ada yang diedit
                            'Dim query_edit As String = "UPDATE tb_fg_code_replace_store_det SET WHERE id_sample_order_det = '" + id_sample_order_det + "' "
                            'execute_non_query(query_edit, True, "", "", "", "")
                            id_fg_code_replace_store_det_list.Remove(id_fg_code_replace_store_det)
                        End If
                    Next
                    If GVItemList.RowCount > 0 And jum_i > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'delete sisa
                    For k As Integer = 0 To (id_fg_code_replace_store_det_list.Count - 1)
                        Try
                            Dim querydel As String = "DELETE FROM tb_fg_code_replace_store_det WHERE id_fg_code_replace_store_det = '" + id_fg_code_replace_store_det_list(k) + "' "
                            execute_non_query(querydel, True, "", "", "", "")
                        Catch ex As Exception
                            ex.ToString()
                        End Try
                    Next
                End If
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportFGCodeReplaceStore.id_report = id_fg_code_replace_store
        ReportFGCodeReplaceStore.dt = GCItemList.DataSource
        Dim Report As New ReportFGCodeReplaceStore()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GridView1)

        Report.LabelNo.Text = TxtNumber.Text
        Report.LabelDate.Text = DEForm.Text
        Report.LabelNote.Text = MENote.Text

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "65"
        FormReportMark.id_report = id_fg_code_replace_store
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "65"
        FormDocumentUpload.id_report = id_fg_code_replace_store
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTest.Click
        
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnVerifiy_Click(sender As Object, e As EventArgs) Handles BtnVerifiy.Click
        makeSafeGV(GVBarcode)
        GVBarcode.ActiveFilterString = "[status]='-'"

        If GVBarcode.RowCount > 0 Then
            stopCustom("Data not match !")
            GVBarcode.ActiveFilterString = ""
        Else
            GVBarcode.ActiveFilterString = ""
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Data match. Please click 'OK' to completed verification ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                PBC.Properties.Minimum = 0
                PBC.Properties.Maximum = GVBarcode.RowCount - 1
                PBC.Properties.Step = 1
                For i As Integer = 0 To ((GVBarcode.RowCount - 1) - (GetGroupRowCount(GVBarcode)))
                    'pl rec
                    Dim query_ins_pl As String = "INSERT INTO tb_pl_prod_order_rec_det_counting (id_pl_prod_order_rec_det, pl_prod_order_rec_det_counting, id_product, bom_unit_price, id_counting_type) "
                    query_ins_pl += "VALUES ('0', '" + GVBarcode.GetRowCellValue(i, "counting").ToString + "', '" + GVBarcode.GetRowCellValue(i, "id_product").ToString + "', '" + decimalSQL(GVBarcode.GetRowCellValue(i, "design_cop").ToString) + "','2'); SELECT LAST_INSERT_ID(); "
                    Dim id_pl As String = execute_query(query_ins_pl, 0, True, "", "", "", "")

                    'prob- only for store
                    If GVBarcode.GetRowCellValue(i, "id_comp_cat").ToString = "6" Then
                        Dim query_prob As String = "INSERT INTO tb_fg_unique_problem(id_pl_prod_order_rec_det_unique, id_fg_code_replace_store_det, id_comp, id_product, report_mark_type, counting_code, insert_date, note) 
                        VALUES('" + id_pl + "', '" + GVBarcode.GetRowCellValue(i, "id_fg_code_replace_store_det").ToString + "','" + GVBarcode.GetRowCellValue(i, "id_comp").ToString + "', '" + GVBarcode.GetRowCellValue(i, "id_product").ToString + "', '65', '" + GVBarcode.GetRowCellValue(i, "counting").ToString + "', NOW(), 'Code Replacement " + TxtNumber.Text + "') "
                        execute_non_query(query_prob, True, "", "", "", "")
                    End If

                    PBC.PerformStep()
                    PBC.Update()
                Next

                'del temp
                execute_non_query("DELETE FROM tb_fg_code_replace_store_temp WHERE id_fg_code_replace_store=" + id_fg_code_replace_store + "", True, "", "", "", "")

                'update stt
                Dim query_upd As String = "UPDATE tb_fg_code_replace_store SET is_verified=1, verified_date=NOW(), verified_by='" + id_user + "' WHERE   id_fg_code_replace_store=" + id_fg_code_replace_store + " "
                execute_non_query(query_upd, True, "", "", "", "")

                actionLoad()
                FormFGCodeReplace.viewCodeReplaceStore()
                FormFGCodeReplace.GVFGCodeReplaceStore.FocusedRowHandle = find_row(FormFGCodeReplace.GVFGCodeReplaceStore, "id_fg_code_replace_store", id_fg_code_replace_store)
                infoCustom("Verification compeleted")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        TxtScan.Focus()
    End Sub

    Private Sub FormFGCodeReplaceStoreDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then
            TxtScan.Focus()
        End If
    End Sub

    Private Sub TxtScan_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtScan.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim code As String = TxtScan.Text
            makeSafeGV(GVBarcode)
            GVBarcode.ActiveFilterString = "[unique_code]='" + code + "' "
            If GVBarcode.RowCount = 1 Then
                If GVBarcode.GetFocusedRowCellValue("status") = "verified" Then
                    infoCustom("Code duplicate !")
                Else
                    'Dim queryIns As String = "INSERT INTO tb_fg_code_replace_store_temp VALUES ('" + addSlashes(code) + "', '" + GVBarcode.GetFocusedRowCellValue("id_fg_code_replace_store_det") + "', '" + id_fg_code_replace_store + "') "
                    'execute_query(queryIns, -1, True, "", "", "", "")
                    GVBarcode.SetFocusedRowCellValue("status", "verified")
                End If
            Else
                    infoCustom("Code not found !")
            End If
            GVBarcode.ActiveFilterString = ""
            TxtScan.Text = ""
            TxtScan.Focus()
        End If
    End Sub

    Private Sub BtnPrintBarcode_Click(sender As Object, e As EventArgs) Handles BtnPrintBarcode.Click
        FormFGCodeReplaceStoreDetPrint.ShowDialog()
    End Sub
End Class