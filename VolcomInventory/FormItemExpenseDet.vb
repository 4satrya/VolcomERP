Public Class FormItemExpenseDet
    Public id As String = "-1"
    Public action As String = ""
    Public id_comp As String = "-1"
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim is_confirm As String = "2"
    Dim created_date As String = ""

    Dim id_coa_tag As String = "1"

    Private Sub FormItemExpenseDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEDateReff.EditValue = Now()

        viewReportStatus()
        viewCCRepo()
        viewCOAPPH()
        viewCOA()
        viewCOARepo()
        viewPaymentMethod()
        load_currency()
        '
        view_repo_cat()
        view_repo_type()
        '
        actionLoad()
        '
        GridColumnPPH.UnboundExpression = "Iif([id_acc_pph] = " & get_opt_acc_field("id_acc_skbp") & ", 0, [pph_percent] / 100 * [amount])"
        CEPayLater.Checked = True
        CEPayLater.Enabled = False
    End Sub

    Sub load_currency()
        Dim q As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        viewSearchLookupRepositoryQuery(RISLECurrency, q, 0, "currency", "id_currency")
    End Sub

    Sub view_repo_type()
        Dim q As String = "SELECT id_expense_type,expense_type FROM tb_lookup_expense_type"
        viewSearchLookupRepositoryQuery(RISLEType, q, 0, "expense_type", "id_expense_type")
    End Sub

    Sub viewCCRepo()
        Dim q As String = "SELECT id_comp,comp_number,comp_name FROM tb_m_comp"
        viewSearchLookupRepositoryQuery(RISLECC, q, 0, "comp_number", "id_comp")
    End Sub

    Sub view_repo_cat()
        Dim q As String = "SELECT bo.`id_b_expense_opex` AS id_b_expense,icm.`id_item_cat_main`,icm.`item_cat_main`,icm.`id_expense_type`
FROM tb_b_expense_opex bo
INNER JOIN tb_item_cat_main icm ON icm.`id_item_cat_main`=bo.`id_item_cat_main`
WHERE bo.`year`=YEAR(NOW()) AND bo.is_active='1'
UNION ALL
SELECT bo.`id_b_expense` AS id_b_expense,icm.`id_item_cat_main`,CONCAT('[',dep.departement,']',icm.`item_cat_main`) AS item_cat_main,icm.`id_expense_type`
FROM tb_b_expense bo
INNER JOIN tb_item_cat_main icm ON icm.`id_item_cat_main`=bo.`id_item_cat_main`
INNER JOIN tb_m_departement dep ON dep.id_departement=bo.id_departement
WHERE bo.`year`=YEAR(NOW()) AND bo.is_active='1'"
        viewSearchLookupRepositoryQuery(RISLECatExpense, q, 0, "item_cat_main", "id_b_expense")
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        If id_coa_tag = "1" Then
            query += " AND id_coa_type='1' "
        Else
            query += " AND id_coa_type='2' "
        End If
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub viewCOARepo()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        If id_coa_tag = "1" Then
            query += " AND id_coa_type='1' "
        Else
            query += " AND id_coa_type='2' "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepositoryItemSearchLookUpEdit1.DataSource = Nothing
        RepositoryItemSearchLookUpEdit1.DataSource = data
        RepositoryItemSearchLookUpEdit1.DisplayMember = "acc_description"
        RepositoryItemSearchLookUpEdit1.ValueMember = "id_acc"
    End Sub

    Sub viewCOAPPH()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 AND LEFT(a.acc_name,4)='2111' "
        If id_coa_tag = "1" Then
            query += " AND id_coa_type='1' "
        Else
            query += " AND id_coa_type='2' "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RISLECOAPPH.DataSource = Nothing
        RISLECOAPPH.DataSource = data
        RISLECOAPPH.DisplayMember = "acc_description"
        RISLECOAPPH.ValueMember = "id_acc"
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

            TEInvNo.Enabled = True

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
                DEDateReff.EditValue = data.Rows(0)("date_reff")
                CEPayLater.EditValue = True
            Else
                CEPayLater.EditValue = False
            End If

            TEInvNo.Text = data.Rows(0)("inv_number").ToString
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
            calculate()
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
        Dim query As String = "SELECT ed.id_currency,cur.currency,ed.amount_before,ed.kurs,ed.id_item_expense_det,ed.cc,c.comp_number AS cc_desc, ed.id_item_expense,ed.id_expense_type,ed.id_b_expense,bex.item_cat_main,typ.expense_type,
        ed.id_acc,pphacc.acc_description AS coa_desc_pph, a.acc_description AS `coa_desc`, ed.description,a.acc_name,ed.id_acc_pph,ed.pph_percent,ed.pph, "

        If action = "ins" Then
            query += "0.00 AS tax_percent,0.00 AS `amount` "
        ElseIf action = "upd" Then
            query += "ed.tax_percent,ed.amount "
        End If

        query += "FROM tb_item_expense_det ed
        LEFT JOIN tb_a_acc pphacc ON pphacc.id_acc = ed.id_acc_pph
        INNER JOIN tb_a_acc a ON a.id_acc = ed.id_acc
        INNER JOIN tb_lookup_expense_type typ ON typ.id_expense_type=ed.id_expense_type
        LEFT JOIN tb_m_comp c ON ed.cc=c.id_comp
        INNER JOIN tb_lookup_currency cur ON cur.id_currency=ed.id_currency
        INNER JOIN 
        (
	        SELECT bo.`id_b_expense_opex` AS id_b_expense,icm.`id_item_cat_main`,icm.`item_cat_main`,icm.`id_expense_type`
	        FROM tb_b_expense_opex bo
	        INNER JOIN tb_item_cat_main icm ON icm.`id_item_cat_main`=bo.`id_item_cat_main`
	        WHERE bo.`year`=YEAR(NOW()) AND bo.is_active='1'
	        UNION ALL
	        SELECT bo.`id_b_expense` AS id_b_expense,icm.`id_item_cat_main`,CONCAT('[',dep.departement,']',icm.`item_cat_main`) AS item_cat_main,icm.`id_expense_type`
	        FROM tb_b_expense bo
	        INNER JOIN tb_item_cat_main icm ON icm.`id_item_cat_main`=bo.`id_item_cat_main`
	        INNER JOIN tb_m_departement dep ON dep.id_departement=bo.id_departement
	        WHERE bo.`year`=YEAR(NOW()) AND bo.is_active='1'
        ) bex ON bex.id_b_expense=ed.id_b_expense AND ed.id_expense_type=bex.id_expense_type
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
        '
        GridColumnaccount.Visible = False
        GridColumnAccountDescription.VisibleIndex = 1
        '
        GridColumnPPHCOA.Visible = False
        GridColumnPPHDesc.VisibleIndex = 12
        '
        GridColumnCurr.Visible = False
        GridColumnCurrView.VisibleIndex = 6
        '
        GridColumnBudgetType.Visible = False
        GridColumnBudgetTypeDesc.VisibleIndex = 2
        '
        GCCC.Visible = False
        GCCCDesc.VisibleIndex = 2
        '
        GridColumnBudget.Visible = False
        GridColumnBudgetDesc.VisibleIndex = 3
        '
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
        'If id_report_status = "6" Then

        If id_report_status = "6" Then
            ReportItemExpense.is_pre = False
        Else
            ReportItemExpense.is_pre = True
        End If

        ReportItemExpense.id = id
        ReportItemExpense.dt = GCData.DataSource
        Dim Report As New ReportItemExpense()

        GridColumnPPHDesc.VisibleIndex = -1

        GVData.BestFitColumns()

        'creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVData.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVData)

        GridColumnPPHDesc.VisibleIndex = 9

        'Parse val
        Report.LabelNumber.Text = TxtNumber.Text.ToUpper
        Report.LabelDate.Text = DECreated.Text.ToString
        Report.LNote.Text = MENote.Text.ToString
        Report.LabelPaymentMethod.Text = LEPaymentMethod.Text
        Report.LabelPaymentStatus.Text = TxtPaymentStatus.Text

        If CEPayLater.EditValue = True Then
            Report.LabelBeneficiary.Text = TxtCompName.Text
            Report.LabelDUelDate.Text = DEDueDate.Text
            '
            Report.LPayFrom.Visible = False
            Report.LpayFromTitle.Visible = False
            Report.LpayFromMark.Visible = False
        Else
            Report.LabelBeneficiary.Visible = False
            Report.LabelTitleBeneficiary.Visible = False
            Report.LabelDotBeneficiary.Visible = False
            Report.LabelDUelDate.Visible = False
            Report.LabelTitleDueDate.Visible = False
            Report.LabelDotDueDate.Visible = False
            '
            Report.LPayFrom.Visible = True
            Report.LpayFromTitle.Visible = True
            Report.LpayFromMark.Visible = True
        End If

        Report.LInvNo.Text = TEInvNo.Text
        Report.LPayFrom.Text = SLEPayFrom.Text
        Report.LabelTotalPayment.Text = TxtTotal.Text
        Report.LSay.Text = ConvertCurrencyToIndonesian(Decimal.Parse(TxtTotal.EditValue.ToString))

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        'Else
        '    print_raw_no_export(GCData)
        'End If
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
        GVData.RefreshData()
        makeSafeGV(GVData)

        Dim multiple_curr As Boolean = False

        'cek empty
        Dim cond_empty As Boolean = False
        GVData.ActiveFilterString = "[amount] Is Null OR [amount]=0 OR IsNullOrEmpty([id_acc]) OR ([pph_percent]>0 AND IsNullOrEmpty([id_acc_pph]))"
        If GVData.RowCount > 0 Then
            cond_empty = True
        End If
        makeSafeGV(GVData)

        'cek multiple currency
        For i As Integer = 0 To GVData.RowCount - 1
            If Not GVData.GetRowCellValue(i, "id_currency").ToString = GVData.GetRowCellValue(0, "id_currency").ToString Or Not GVData.GetRowCellValue(i, "kurs").ToString = GVData.GetRowCellValue(0, "kurs").ToString Then
                multiple_curr = True
                Exit For
            End If
        Next

        If SLEPayFrom.EditValue = Nothing Then
            warningCustom("Please select pay from account")
        ElseIf cond_empty Then
            warningCustom("Please complete all detail data")
        ElseIf CEPayLater.EditValue = True And id_comp = "-1" Then
            warningCustom("Please select vendor")
        ElseIf GVData.RowCount <= 0 Then
            warningCustom("Please input detail expense")
        ElseIf TEInvNo.Text = "" Then
            warningCustom("Please input invoice number")
        ElseIf multiple_curr Then
            warningCustom("Please use only same currency with same kurs")
        ElseIf MENote.Text = "" Then
            warningCustom("Please put some note")
        ElseIf DEDateReff.Text = "" Then
            warningCustom("Please put refference date")
        Else
            GVData.ActiveFilterString = ""
            'check invoice duplicate
            Dim inv_no As String = addSlashes(TEInvNo.Text)
            Dim qc As String = "SELECT * FROM tb_item_expense WHERE id_comp='" & id_comp & "' AND inv_number='" & inv_no & "'"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")

            If dtc.Rows.Count > 0 Then
                warningCustom("Invoice number duplicate")
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
                    Dim date_reff As String = ""
                    Dim sub_total As String = decimalSQL(TxtSubTotal.EditValue.ToString)
                    Dim vat_total As String = decimalSQL(TxtVAT.EditValue.ToString)
                    Dim total As String = decimalSQL(TxtTotal.EditValue.ToString)
                    Dim is_open As String = ""
                    If CEPayLater.EditValue = True Then
                        is_pay_later = "1"
                        due_date = "'" + Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
                        date_reff = "" + Date.Parse(DEDateReff.EditValue.ToString).ToString("yyyy-MM-dd") + ""
                        is_open = "1"
                    Else
                        is_pay_later = "2"
                        id_comp = "NULL"
                        due_date = "NULL"
                        is_open = "2"
                    End If
                    Dim qm As String = "INSERT INTO tb_item_expense(id_comp,inv_number, created_date, due_date, created_by, id_acc_from, id_payment_purchasing, id_report_status, note, sub_total, vat_total, total, is_pay_later, is_open, date_reff) VALUES 
                (" + id_comp + ",'" + inv_no + "', NOW()," + due_date + ", '" + id_user + "', '" + id_acc_from + "', '" + id_payment_purchasing + "', 1, '" + note + "','" + sub_total + "', '" + vat_total + "', '" + total + "', '" + is_pay_later + "', '" + is_open + "', '" + date_reff + "'); SELECT LAST_INSERT_ID(); "
                    id = execute_query(qm, 0, True, "", "", "", "")
                    execute_non_query("CALL gen_number(" + id + ",157); ", True, "", "", "", "")

                    'query det
                    Dim qd As String = "INSERT INTO tb_item_expense_det(id_item_expense, id_acc,cc, description, tax_percent, tax_value, id_currency,kurs,amount_before, amount, id_expense_type, id_b_expense, id_acc_pph, pph_percent, pph) VALUES "
                    For d As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                        Dim id_acc As String = GVData.GetRowCellValue(d, "id_acc").ToString
                        Dim cc As String = GVData.GetRowCellValue(d, "cc").ToString
                        Dim description As String = addSlashes(GVData.GetRowCellValue(d, "description").ToString)
                        Dim tax_percent As String = decimalSQL(GVData.GetRowCellValue(d, "tax_percent").ToString)
                        Dim tax_value As String = decimalSQL(GVData.GetRowCellValue(d, "tax_value").ToString)
                        Dim amount As String = decimalSQL(GVData.GetRowCellValue(d, "amount").ToString)
                        Dim id_expense_type As String = GVData.GetRowCellValue(d, "id_expense_type").ToString
                        Dim id_b_expense As String = GVData.GetRowCellValue(d, "id_b_expense").ToString
                        '
                        Dim id_currency As String = GVData.GetRowCellValue(d, "id_currency").ToString
                        Dim kurs As String = decimalSQL(GVData.GetRowCellValue(d, "kurs").ToString)
                        Dim amount_before As String = decimalSQL(GVData.GetRowCellValue(d, "amount_before").ToString)
                        '
                        Dim id_acc_pph As String = "NULL"
                        Dim pph_percent As String = "0"
                        Dim pph As String = "0"
                        '
                        If GVData.GetRowCellValue(d, "pph_percent") > 0 Then
                            id_acc_pph = "'" & GVData.GetRowCellValue(d, "id_acc_pph").ToString & "'"
                            pph_percent = decimalSQL(GVData.GetRowCellValue(d, "pph_percent").ToString)
                            pph = decimalSQL(GVData.GetRowCellValue(d, "pph_value").ToString)
                        End If
                        '
                        If d > 0 Then
                            qd += ", "
                        End If
                        qd += "('" + id + "','" + id_acc + "','" + cc + "', '" + description + "', '" + tax_percent + "', '" + tax_value + "', '" + id_currency + "', '" + kurs + "', '" + amount_before + "', '" + amount + "', '" + id_expense_type + "', '" + id_b_expense + "'," + id_acc_pph + ",'" + pph_percent + "','" + pph + "') "
                    Next
                    '
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
        '
        GVData.SetRowCellValue(GVData.RowCount - 1, "id_expense_type", "1")
        GVData.SetRowCellValue(GVData.RowCount - 1, "cc", "1")
        '
        GVData.SetRowCellValue(GVData.RowCount - 1, "amount", 0)
        GVData.SetRowCellValue(GVData.RowCount - 1, "tax_percent", 0)
        '
        GVData.SetRowCellValue(GVData.RowCount - 1, "pph_percent", 0)
        '
        GVData.SetRowCellValue(GVData.RowCount - 1, "amount_before", 0)
        GVData.SetRowCellValue(GVData.RowCount - 1, "kurs", 1)
        GVData.SetRowCellValue(GVData.RowCount - 1, "id_currency", 1)
        '
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

        If e.Column.FieldName = "id_currency" Or e.Column.FieldName = "kurs" Or e.Column.FieldName = "amount_before" Then
            'calculate amount in RP
            For i = 0 To GVData.RowCount - 1
                Try
                    GVData.SetRowCellValue(i, "amount", If(GVData.GetRowCellValue(i, "id_currency").ToString = "1", GVData.GetRowCellValue(i, "amount_before"), GVData.GetRowCellValue(i, "amount_before") * GVData.GetRowCellValue(i, "kurs")))
                Catch ex As Exception
                    Console.WriteLine(ex.ToString)
                End Try
            Next
        End If

        If e.Column.FieldName = "amount" Or e.Column.FieldName = "tax_percent" Or e.Column.FieldName = "pph_percent" Or e.Column.FieldName = "id_currency" Or e.Column.FieldName = "kurs" Or e.Column.FieldName = "amount_before" Then
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

        Dim pph As Decimal = 0.00
        Try
            pph = GVData.Columns("pph_value").SummaryItem.SummaryValue
        Catch ex As Exception
            pph = 0.00
        End Try
        TEPPH.EditValue = pph

        TxtTotal.EditValue = TxtSubTotal.EditValue + TxtVAT.EditValue - TEPPH.EditValue
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

    Private Sub RISLECatExpense_Popup(sender As Object, e As EventArgs) Handles RISLECatExpense.Popup
        Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = TryCast(GVData.ActiveEditor, DevExpress.XtraEditors.SearchLookUpEdit)
        editor.Properties.View.ActiveFilterString = "[id_expense_type] ='" + GVData.GetFocusedRowCellValue("id_expense_type").ToString + "'"
    End Sub

    Private Sub XTPDraftJournal_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTPDraftJournal.SelectedPageChanged
        If XTPDraftJournal.SelectedTabPageIndex = 1 Then
            GVData.RefreshData()
            load_blank_draft()
            viewDraftJournal()
        End If
    End Sub

    Sub load_blank_draft()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `no`,'' AS id_acc, '' AS acc_name, '' AS acc_description, '' AS `cc`, '' AS report_number, '' AS note, 0.00 AS `debit`, 0.00 AS `credit` "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDraft.DataSource = data
        GVDraft.DeleteSelectedRows()
        GVDraft.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDraftJournal()
        Cursor = Cursors.WaitCursor
        If GVData.RowCount > 0 Then
            makeSafeGV(GVData)
            Dim jum_row As Integer = 0

            'header
            jum_row += 1
            Dim qh As String = "SELECT acc.acc_name,acc.acc_description
FROM tb_m_comp c 
INNER JOIN tb_a_acc acc ON acc.id_acc=id_acc_ap
WHERE c.id_comp='" + id_comp + "' "
            Dim dh As DataTable = execute_query(qh, -1, True, "", "", "", "")
            If dh.Rows.Count > 0 Then
                'total
                If TxtSubTotal.EditValue > 0 Then
                    Dim newRowh As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    newRowh("no") = jum_row
                    newRowh("acc_name") = dh.Rows(0)("acc_name").ToString
                    newRowh("acc_description") = dh.Rows(0)("acc_name").ToString & " - " & dh.Rows(0)("acc_description").ToString
                    newRowh("cc") = "000"
                    newRowh("report_number") = ""
                    newRowh("note") = MENote.Text
                    newRowh("debit") = 0
                    newRowh("credit") = TxtSubTotal.EditValue + TxtVAT.EditValue - TEPPH.EditValue
                    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowh)
                    GCDraft.RefreshDataSource()
                    GVDraft.RefreshData()
                End If

                'detil
                For i As Integer = 0 To GVData.RowCount - 1
                    'Dim found As Boolean = False
                    'Dim row_found As Integer = 0
                    'For j As Integer = 0 To GVDraft.RowCount - 1
                    '    row_found = j
                    'Next

                    'If found Then
                    '    GVDraft.SetRowCellValue(row_found, "debit", GVDraft.GetRowCellValue(row_found, "debit") + Math.Abs(GVData.GetRowCellValue(i, "valuex")))
                    'Else
                    '    jum_row += 1
                    '    Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    '    newRow("no") = jum_row
                    '    newRow("id_acc") = GVData.GetRowCellValue(i, "id_acc").ToString
                    '    newRow("acc_description") = GVData.GetRowCellDisplayText(i, "id_acc").ToString
                    '    newRow("cc") = "000"
                    '    newRow("report_number") = GVData.GetRowCellValue(i, "report_number").ToString
                    '    newRow("note") = GVData.GetRowCellValue(i, "info_design").ToString
                    '    If GVData.GetRowCellValue(i, "valuex") < 0 Then
                    '        newRow("debit") = 0
                    '        newRow("credit") = Math.Abs(GVData.GetRowCellValue(i, "valuex"))
                    '    Else
                    '        newRow("debit") = Math.Abs(GVData.GetRowCellValue(i, "valuex"))
                    '        newRow("credit") = 0
                    '    End If
                    '    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                    '    GCDraft.RefreshDataSource()
                    '    GVDraft.RefreshData()
                    'End If
                    jum_row += 1
                    Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    newRow("no") = jum_row
                    newRow("id_acc") = GVData.GetRowCellValue(i, "id_acc").ToString

                    If id = "-1" Then
                        Try
                            newRow("acc_name") = get_acc(GVData.GetRowCellValue(i, "id_acc").ToString, "1")
                            newRow("acc_description") = get_acc(GVData.GetRowCellValue(i, "id_acc").ToString, "2")
                            newRow("cc") = GVData.GetRowCellValue(i, "cc_desc").ToString
                        Catch ex As Exception
                        End Try
                    Else
                        newRow("acc_name") = GVData.GetRowCellValue(i, "acc_name").ToString
                        newRow("acc_description") = GVData.GetRowCellValue(i, "coa_desc").ToString
                        newRow("cc") = GVData.GetRowCellDisplayText(i, "cc").ToString
                    End If

                    newRow("report_number") = ""
                    newRow("note") = GVData.GetRowCellValue(i, "description").ToString
                    If GVData.GetRowCellValue(i, "amount") < 0 Then
                        newRow("debit") = 0
                        newRow("credit") = Math.Abs(GVData.GetRowCellValue(i, "amount"))
                    Else
                        newRow("debit") = Math.Abs(GVData.GetRowCellValue(i, "amount"))
                        newRow("credit") = 0
                    End If
                    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                    GCDraft.RefreshDataSource()
                    GVDraft.RefreshData()
                    'pph
                    If GVData.GetRowCellValue(i, "id_acc_pph").ToString = get_opt_acc_field("id_acc_skbp") And GVData.GetRowCellValue(i, "pph_percent") > 0 Then
                        'SKBP
                        'debit
                        jum_row += 1
                        Dim newRowvat As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                        newRowvat("no") = jum_row
                        Try
                            newRowvat("acc_name") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "1")
                            newRowvat("acc_description") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2")
                            newRowvat("note") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2") & " (PPH " & GVData.GetRowCellValue(i, "pph_percent").ToString & " %)"
                        Catch ex As Exception
                        End Try
                        newRowvat("cc") = "000"
                        newRowvat("report_number") = ""
                        newRowvat("debit") = (GVData.GetRowCellValue(i, "pph_percent") / 100) * GVData.GetRowCellValue(i, "amount")
                        newRowvat("credit") = 0
                        TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)

                        'credit
                        jum_row += 1
                        newRowvat = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                        newRowvat("no") = jum_row
                        Try
                            newRowvat("acc_name") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "1")
                            newRowvat("acc_description") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2")
                            newRowvat("note") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2") & " (PPH " & GVData.GetRowCellValue(i, "pph_percent").ToString & " %)"
                        Catch ex As Exception
                        End Try
                        newRowvat("cc") = "000"
                        newRowvat("report_number") = ""
                        newRowvat("debit") = 0
                        newRowvat("credit") = (GVData.GetRowCellValue(i, "pph_percent") / 100) * GVData.GetRowCellValue(i, "amount")
                        TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)
                    ElseIf GVData.GetRowCellValue(i, "pph_percent") > 0 Then
                        jum_row += 1
                        Dim newRowvat As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                        newRowvat("no") = jum_row
                        Try
                            newRowvat("acc_name") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "1")
                            newRowvat("acc_description") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2")
                            newRowvat("note") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2") & " (PPH " & GVData.GetRowCellValue(i, "pph_percent").ToString & " %)"
                        Catch ex As Exception
                        End Try
                        newRowvat("cc") = "000"
                        newRowvat("report_number") = ""
                        newRowvat("debit") = 0
                        newRowvat("credit") = GVData.GetRowCellValue(i, "pph_value")
                        TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)
                    End If
                Next
                'vat
                If TxtVAT.EditValue > 0 Then
                    jum_row += 1
                    Dim newRowvat As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    newRowvat("no") = jum_row
                    newRowvat("acc_name") = get_acc(get_opt_purchasing_field("acc_coa_vat_in"), "1")
                    newRowvat("acc_description") = get_acc(get_opt_purchasing_field("acc_coa_vat_in"), "2")
                    newRowvat("cc") = "000"
                    newRowvat("report_number") = ""
                    newRowvat("note") = MENote.Text
                    newRowvat("debit") = TxtVAT.EditValue
                    newRowvat("credit") = 0
                    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)
                    jum_row += 1
                End If
                '
                GCDraft.RefreshDataSource()
                GVDraft.RefreshData()

                GVDraft.BestFitColumns()
            Else
                MsgBox("DP/AP account is not set")
                XTPDraftJournal.SelectedTabPageIndex = 0
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        GVData.ActiveFilterString = "[amount] Is Null OR [amount]=0 OR IsNullOrEmpty([id_acc]) OR ([pph_percent]>0 AND IsNullOrEmpty([id_acc_pph]))"
    End Sub

    Private Sub GrossUpPPHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GrossUpPPHToolStripMenuItem.Click
        If GVData.RowCount > 0 Then
            Try
                Dim dpp As Decimal = Decimal.Parse(GVData.GetFocusedRowCellValue("amount").ToString)
                Dim pph As Decimal = Decimal.Parse(GVData.GetFocusedRowCellValue("pph_percent").ToString)
                '
                Dim grossup_val As Decimal = 0.00
                grossup_val = (100 / (100 - pph)) * dpp
                GVData.SetFocusedRowCellValue("amount", grossup_val)
                calculate()
            Catch ex As Exception
                warningCustom("Please check your input")
            End Try
        End If
    End Sub

    Private Sub RISLECurrency_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles RISLECurrency.EditValueChanging
        GCData.RefreshDataSource()
        GVData.RefreshData()
    End Sub
End Class