Public Class FormItemExpenseDet
    Public id As String = "-1"
    Public action As String = ""
    Public id_comp As String = "-1"
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim is_confirm As String = "2"
    Dim created_date As String = ""

    Private Sub FormItemExpenseDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewCOA()
        viewCOARepo()
        viewPaymentMethod()
        actionLoad()
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub viewCOARepo()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepositoryItemSearchLookUpEdit1.DataSource = Nothing
        RepositoryItemSearchLookUpEdit1.DataSource = data
        RepositoryItemSearchLookUpEdit1.DisplayMember = "acc_description"
        RepositoryItemSearchLookUpEdit1.ValueMember = "id_acc"
    End Sub

    Sub viewPaymentMethod()
        Dim query As String = "SELECT * FROM tb_lookup_payment_purchasing p
        ORDER BY p.id_payment_purchasing ASC "
        viewLookupQuery(LEPaymentMethod, query, 0, "payment_purchasing", "id_payment_purchasing")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        TxtSubTotal.EditValue = 0.00
        TxtVAT.EditValue = 0.00
        TxtTotal.EditValue = 0.00
        If action = "ins" Then
            Dim err_coa As String = ""

            'cek coa persediaan dan hutang
            Dim cond_coa As Boolean = True
            Dim qcoa As String = "SELECT * 
            FROM tb_opt_purchasing o
            INNER JOIN tb_a_acc k ON k.id_acc = o.acc_coa_vat_in 
            WHERE !ISNULL(k.id_acc) "
            Dim dcoa As DataTable = execute_query(qcoa, -1, True, "", "", "", "")
            If dcoa.Rows.Count <= 0 Then
                err_coa += "- COA : Vat In " + System.Environment.NewLine
                cond_coa = False
            End If

            If Not cond_coa Then
                warningCustom("Please contact Accounting Department to setup these COA : " + System.Environment.NewLine + err_coa)
                Close()
            End If

            'date
            DEDueDate.EditValue = getTimeDB()

            'purc order detail
            GVData.OptionsCustomization.AllowSort = False
            SLEPayFrom.Focus()
            TxtNumber.Text = "[auto generate]"
            DECreated.EditValue = getTimeDB()
            viewDetail()
        Else
            GVData.OptionsCustomization.AllowSort = True

            Dim e As New ClassItemExpense()
            Dim query As String = e.queryMain("AND e.id_item_expense ='" + id + "' ", "1", False)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            SLEPayFrom.EditValue = data.Rows(0)("id_acc_from").ToString
            Dim is_pay_later As String = data.Rows(0)("is_pay_later").ToString
            If is_pay_later = "1" Then
                id_comp = data.Rows(0)("id_comp").ToString
                TxtCompNumber.Text = data.Rows(0)("comp_number").ToString
                TxtCompName.Text = data.Rows(0)("comp_name").ToString
                DEDueDate.EditValue = data.Rows(0)("due_date")
                CEPayLater.EditValue = True
            Else
                CEPayLater.EditValue = False
            End If
            LEPaymentMethod.EditValue = data.Rows(0)("id_payment_purchasing").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtNumber.Text = data.Rows(0)("number").ToString
            created_date = DateTime.Parse(data.Rows(0)("created_date")).ToString("yyyy-MM-dd HH:mm:ss")
            DECreated.EditValue = data.Rows(0)("created_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtSubTotal.EditValue = data.Rows(0)("sub_total")
            TxtVAT.EditValue = data.Rows(0)("vat_total")
            TxtTotal.EditValue = data.Rows(0)("total")
            TxtPaymentStatus.Text = data.Rows(0)("paid_status").ToString

            viewDetail()
            allow_status()
        End If
    End Sub

    Private Sub CEPayLater_CheckedChanged(sender As Object, e As EventArgs) Handles CEPayLater.CheckedChanged
        If CEPayLater.EditValue = True Then
            SLEPayFrom.Enabled = False
            BtnBrowse.Enabled = True
            DEDueDate.Enabled = True
        Else
            SLEPayFrom.Enabled = True
            id_comp = "-1"
            TxtCompName.Text = ""
            TxtCompNumber.Text = ""
            BtnBrowse.Enabled = False
            DEDueDate.Enabled = False
        End If
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT ed.id_item_expense_det, ed.id_item_expense, 
        ed.id_acc, a.acc_description AS `coa_desc`, ed.description, "
        If action = "ins" Then
            query += "0.00 AS tax_percent,0.00 AS `amount` "
        ElseIf action = "upd" Then
            query += "ed.tax_percent,ed.amount "
        End If
        query += "From tb_item_expense_det ed
        INNER JOIN tb_a_acc a ON a.id_acc = ed.id_acc
        WHERE ed.id_item_expense=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnCancell.Visible = True
        BtnMark.Visible = True
        BtnAttachment.Visible = True
        BtnPrint.Visible = True
        GVData.OptionsBehavior.Editable = False
        SLEPayFrom.Enabled = False
        LEPaymentMethod.Enabled = False
        CEPayLater.Enabled = False
        BtnBrowse.Enabled = False
        DEDueDate.Enabled = False
        BtnSave.Visible = False
        MENote.Enabled = False
        GCData.ContextMenuStrip = Nothing
        PanelControlNav.Visible = False
        GridColumnaccount.Visible = False
        GridColumnAccountDescription.VisibleIndex = 1

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnViewJournal.Visible = True
            BtnViewJournal.BringToFront()
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
        End If
    End Sub

    Private Sub FormItemExpenseDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancell this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_item_expense SET id_report_status=5 WHERE id_item_expense='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 157, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormItemExpense.viewData()
            FormItemExpense.GVData.FocusedRowHandle = find_row(FormItemExpense.GVData, "id_item_expense", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        If id_report_status = "6" Then
            ReportItemExpense.id = id
            ReportItemExpense.dt = GCData.DataSource
            Dim Report As New ReportItemExpense()

            '... 
            ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVData.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVData)

            'Parse val
            Report.LabelNumber.Text = TxtNumber.Text.ToUpper
            Report.LabelDate.Text = DECreated.Text.ToString
            Report.LNote.Text = MENote.Text.ToString
            Report.LabelPaymentMethod.Text = LEPaymentMethod.Text
            Report.LabelPaymentStatus.Text = TxtPaymentStatus.Text
            If CEPayLater.EditValue = True Then
                Report.LabelBeneficiary.Text = TxtCompName.Text
                Report.LabelDUelDate.Visible = DEDueDate.Text
            Else
                Report.LabelBeneficiary.Visible = False
                Report.LabelTitleBeneficiary.Visible = False
                Report.LabelDotBeneficiary.Visible = False
                Report.LabelDUelDate.Visible = False
                Report.LabelTitleDueDate.Visible = False
                Report.LabelDotDueDate.Visible = False
            End If
            Report.LabelPayFrom.Text = SLEPayFrom.Text
            Report.LabelTotalPayment.Text = TxtTotal.Text

            'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        Else
            print_raw_no_export(GCData)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        attach()
    End Sub

    Sub attach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "157"
        FormDocumentUpload.id_report = id
        FormDocumentUpload.is_only_pdf = True
        If is_view = "1" Or Not check_edit_report_status(id_report_status, "157", id) Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "157"
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        makeSafeGV(GVData)

        'cek empty
        Dim cond_empty As Boolean = False
        GVData.ActiveFilterString = "[amount] Is Null OR [amount]=0 OR IsNullOrEmpty([id_acc])"
        If GVData.RowCount > 0 Then
            cond_empty = True
        End If
        makeSafeGV(GVData)

        If SLEPayFrom.EditValue = Nothing Then
            warningCustom("Please select pay from account")
        ElseIf cond_empty Then
            warningCustom("Please complete all detail data")
        ElseIf CEPayLater.EditValue = True And id_comp = "-1" Then
            warningCustom("Please select vendor")
        ElseIf GVData.RowCount <= 0 Then
            warningCustom("Please input detail expense")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'query main
                Dim id_acc_from As String = SLEPayFrom.EditValue.ToString
                Dim id_payment_purchasing As String = LEPaymentMethod.EditValue.ToString
                Dim note As String = addSlashes(MENote.Text)
                Dim is_pay_later As String = ""
                Dim due_date As String = ""
                Dim sub_total As String = decimalSQL(TxtSubTotal.EditValue.ToString)
                Dim vat_total As String = decimalSQL(TxtVAT.EditValue.ToString)
                Dim total As String = decimalSQL(TxtTotal.EditValue.ToString)
                Dim is_open As String = ""
                If CEPayLater.EditValue = True Then
                    is_pay_later = "1"
                    due_date = "'" + DateTime.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
                    is_open = "1"
                Else
                    is_pay_later = "2"
                    id_comp = "NULL"
                    due_date = "NULL"
                    is_open = "2"
                End If
                Dim qm As String = "INSERT INTO tb_item_expense(id_comp, created_date, due_date, created_by, id_acc_from, id_payment_purchasing, id_report_status, note, sub_total, vat_total, total, is_pay_later, is_open) VALUES 
                (" + id_comp + ", NOW()," + due_date + ", '" + id_user + "', '" + id_acc_from + "', '" + id_payment_purchasing + "', 1, '" + note + "','" + sub_total + "', '" + vat_total + "', '" + total + "', '" + is_pay_later + "', '" + is_open + "'); SELECT LAST_INSERT_ID(); "
                id = execute_query(qm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id + ",157); ", True, "", "", "", "")

                'query det
                Dim qd As String = "INSERT INTO tb_item_expense_det(id_item_expense, id_acc, description, tax_percent, tax_value, amount) VALUES "
                For d As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                    Dim id_acc As String = GVData.GetRowCellValue(d, "id_acc").ToString
                    Dim description As String = GVData.GetRowCellValue(d, "description").ToString
                    Dim tax_percent As String = decimalSQL(GVData.GetRowCellValue(d, "tax_percent").ToString)
                    Dim tax_value As String = decimalSQL(GVData.GetRowCellValue(d, "tax_value").ToString)
                    Dim amount As String = decimalSQL(GVData.GetRowCellValue(d, "amount").ToString)

                    If d > 0 Then
                        qd += ", "
                    End If
                    qd += "('" + id + "','" + id_acc + "', '" + description + "', '" + tax_percent + "', '" + tax_value + "', '" + amount + "') "
                Next
                If GVData.RowCount > 0 Then
                    execute_non_query(qd, True, "", "", "", "")
                End If

                'submit
                submit_who_prepared(157, id, id_user)

                'refresh
                action = "upd"
                actionLoad()
                FormItemExpense.viewData()
                FormItemExpense.GVData.FocusedRowHandle = find_row(FormItemExpense.GVData, "id_item_expense", id)
                infoCustom("Expense : " + TxtNumber.Text.ToString + " was created successfully. Waiting for approval")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=157 AND ad.id_report=" + id + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        GVData.AddNewRow()
        GVData.FocusedRowHandle = GVData.RowCount - 1
        GVData.SetRowCellValue(GVData.RowCount - 1, "amount", 0)
        GVData.SetRowCellValue(GVData.RowCount - 1, "tax_percent", 0)
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        del()
    End Sub

    Sub del()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            GVData.DeleteSelectedRows()
            GCData.RefreshDataSource()
            GVData.RefreshData()
            calculate()
        End If
    End Sub

    Private Sub GVData_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVData.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim rh As Integer = e.RowHandle
        If e.Column.FieldName = "amount" Or e.Column.FieldName = "tax_percent" Then
            GCData.RefreshDataSource()
            GVData.RefreshData()
            calculate()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub calculate()
        Cursor = Cursors.WaitCursor
        Dim sub_total As Decimal = 0.00
        Try
            sub_total = GVData.Columns("amount").SummaryItem.SummaryValue
        Catch ex As Exception
            sub_total = 0.00
        End Try
        TxtSubTotal.EditValue = sub_total

        Dim vat As Decimal = 0.00
        Try
            vat = GVData.Columns("tax_value").SummaryItem.SummaryValue
        Catch ex As Exception
            vat = 0.00
        End Try
        TxtVAT.EditValue = vat
        TxtTotal.EditValue = TxtSubTotal.EditValue + TxtVAT.EditValue
        Cursor = Cursors.Default
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        del()
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "90"
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class