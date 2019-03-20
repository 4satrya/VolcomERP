Public Class FormSampleExpenseDet
    Public id_purc As String = "-1"
    Public is_view As String = "-1"

    Private Sub FormSampleExpenseDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub load_head()
        view_currency(LECurrency)
        load_budget()
        TEKurs.EditValue = 1.0

        If id_purc = "-1" Then 'new
            TENumber.Text = "[auto_generate]"
            TECreatedBy.Text = get_user_identify(id_user, "1")
            DEDateCreated.EditValue = Now
            '
            BtnPrint.Visible = False
            BMark.Visible = False
        Else 'edit
            Dim query As String = "SELECT po.number,emp.`employee_name`,po.note,po.`date_created`,po.id_sample_purc_budget,po.`remaining_after`,po.`remaining_before`,po.`id_currency`
FROM tb_sample_po_mat po 
INNER JOIN tb_m_user usr ON usr.`id_user`=po.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE po.id_sample_po_mat='" & id_purc & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TENumber.Text = data.Rows(0)("number").ToString
                DEDateCreated.EditValue = data.Rows(0)("date_created")
                TECreatedBy.Text = data.Rows(0)("employee_name").ToString
                '
                LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
                SLEBudget.EditValue = data.Rows(0)("id_sample_purc_budget").ToString
                TERemainingBudget.EditValue = data.Rows(0)("remaining_before")
                TERemainingBudgetAfter.EditValue = data.Rows(0)("remaining_after")
                '
                MENote.Text = data.Rows(0)("note").ToString
            End If
            BtnPrint.Visible = True
            BMark.Visible = True
            '
            GVAfter.OptionsBehavior.ReadOnly = True
            PCAddDelete.Visible = False
            '
            If is_view = "1" Then
                BtnSave.Visible = False
            End If
        End If

        load_det()
        calculate()
        load_but()
    End Sub

    Sub calculate()
        Dim total, sub_tot, vat As Decimal

        Try
            sub_tot = GVAfter.Columns("sub_total").SummaryItem.SummaryValue
            vat = (TEVat.EditValue / 100) * GVAfter.Columns("sub_total").SummaryItem.SummaryValue
        Catch ex As Exception
        End Try

        TEVatTot.EditValue = vat

        TEGrossTot.EditValue = sub_tot

        total = sub_tot + vat
        TETot.EditValue = total
        '
        load_remaining_budget_after()
    End Sub

    Sub load_remaining_budget_after()
        Dim remaining_after As Decimal = 0.00
        Dim remaining_before As Decimal = 0.00
        Dim used As Decimal = 0.00
        '
        used = TEGrossTot.EditValue
        '
        If id_purc = "-1" Then
            Try
                remaining_before = TERemainingBudget.EditValue
                remaining_after = remaining_before - used
                TERemainingBudgetAfter.EditValue = remaining_after
            Catch ex As Exception
            End Try
        End If
    End Sub

    Sub load_det()
        Dim query As String = "SELECT * FROM `tb_sample_po_mat_det`
WHERE id_sample_po_mat='" & id_purc & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAfter.DataSource = data
    End Sub

    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        If id_purc = "-1" Then 'new
            query += " WHERE is_active_sample='1'"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub

    Sub load_but()
        If GVAfter.RowCount > 0 Then
            BDel.Visible = True
        Else
            BDel.Visible = False
        End If
    End Sub

    Sub load_budget()
        Dim where_active As String = ""
        If id_purc = "-1" Then
            where_active = " AND spb.year >= YEAR(CURRENT_DATE()) AND spb.is_active = 1"
        End If

        Dim query As String = "SELECT spb.`id_sample_purc_budget`,spb.`description`,spb.`year`,spb.`value_rp`,spb.`value_usd`,GROUP_CONCAT(spbd.id_code_division) AS id_code_division,spb.`value_rp` - IFNULL(used_budget.budget_rp,0.00) AS remaining_rp,spb.`value_usd` - IFNULL(used_budget.budget_usd,0.00) AS remaining_usd FROM `tb_sample_purc_budget_div` spbd
INNER JOIN tb_sample_purc_budget spb ON spb.id_sample_purc_budget=spbd.`id_sample_purc_budget`
INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=spbd.`id_code_division`
LEFT JOIN (
	SELECT sp.id_sample_purc_budget,SUM(IF(sp.id_currency=1,spd.sample_purc_det_qty,0)*spd.sample_purc_det_price) AS budget_rp, SUM(IF(sp.id_currency=2,spd.sample_purc_det_qty,0)*spd.sample_purc_det_price) AS budget_usd FROM tb_sample_purc_det spd
	INNER JOIN tb_sample_purc sp ON sp.id_sample_purc=spd.id_sample_purc
	WHERE sp.id_report_status!=5
	GROUP BY sp.id_sample_purc_budget
)used_budget ON used_budget.id_sample_purc_budget=spb.id_sample_purc_budget
WHERE 1=1 " & where_active & "
GROUP BY spb.`id_sample_purc_budget`"
        viewSearchLookupQuery(SLEBudget, query, "id_sample_purc_budget", "description", "id_sample_purc_budget")
        'remaining
        SLEBudget.EditValue = Nothing
        SLEBudget.Properties.NullText = "-- Choose budget --"
        load_remaining_budget()
    End Sub

    Sub load_remaining_budget()
        If id_purc = "-1" Then
            Try
                If SLEBudget.EditValue = 0 Then
                    TERemainingBudget.EditValue = 0.00
                Else
                    If LECurrency.EditValue.ToString = "1" Then 'rp
                        TERemainingBudget.EditValue = SLEBudget.Properties.View.GetFocusedRowCellValue("remaining_rp")
                    ElseIf LECurrency.EditValue.ToString = "2" Then 'usd
                        TERemainingBudget.EditValue = SLEBudget.Properties.View.GetFocusedRowCellValue("remaining_usd")
                    End If
                End If
            Catch ex As Exception
                TERemainingBudget.EditValue = 0.00
            End Try
        End If
    End Sub

    Private Sub FormSampleExpenseDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub SLEBudget_EditValueChanged(sender As Object, e As EventArgs) Handles SLEBudget.EditValueChanged
        load_remaining_budget()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        Dim newRow As DataRow = (TryCast(GCAfter.DataSource, DataTable)).NewRow()
        newRow("id_sample_po_mat_det") = 0
        newRow("description") = ""
        newRow("value") = 0.00
        newRow("qty") = 0.00
        newRow("uom") = ""
        TryCast(GCAfter.DataSource, DataTable).Rows.Add(newRow)
        GCAfter.RefreshDataSource()
        GVAfter.RefreshData()
        load_but()
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        GVAfter.DeleteSelectedRows()
        calculate()
        load_but()
    End Sub

    Private Sub GVAfter_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVAfter.CustomUnboundColumnData
        If e.Column.FieldName = "sub_total" Then
            Try
                TEGrossTot.EditValue = 0.00
                TEGrossTot.EditValue = Double.Parse(GVAfter.Columns("sub_total").SummaryItem.SummaryValue.ToString)
                calculate()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim is_ok As Boolean = True

        For i As Integer = 0 To GVAfter.RowCount - 1
            If GVAfter.GetRowCellValue(i, "sub_total") <= 0 Or GVAfter.GetRowCellValue(i, "description").ToString = "" Or GVAfter.GetRowCellValue(i, "uom").ToString = "" Then
                is_ok = False
            End If
        Next

        If is_ok = False Then
            warningCustom("Please complete item detail")
        ElseIf GVAfter.RowCount <= 0 Then
            warningCustom("Please input item detail")
        ElseIf SLEBudget.EditValue Is Nothing Then
            warningCustom("Please select budget first")
        ElseIf TEKurs.EditValue <= 0 Then
            warningCustom("Today transaction kurs still not submitted, please contact FC.")
        Else
            If id_purc = "-1" Then
                'new
                Dim query As String = "INSERT INTO tb_sample_po_mat(id_sample_purc_budget,id_currency,date_created,created_by,note,remaining_before,remaining_after)
VALUES('" & SLEBudget.EditValue.ToString & "','" & LECurrency.EditValue.ToString & "',NOW(),'" & id_user & "','" & addSlashes(MENote.Text) & "','" & decimalSQL(TERemainingBudget.EditValue.ToString) & "','" & decimalSQL(TERemainingBudgetAfter.EditValue.ToString) & "'); SELECT LAST_INSERT_ID(); "
                id_purc = execute_query(query, 0, True, "", "", "", "")
                query = "INSERT INTO tb_sample_po_mat_det(id_sample_po_mat,description,qty,`value`,uom) VALUES"
                For i As Integer = 0 To GVAfter.RowCount - 1
                    If Not i = 0 Then
                        query += ","
                    End If
                    query += "('" & id_purc & "','" & addSlashes(GVAfter.GetRowCellValue(i, "description").ToString) & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "qty").ToString) & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "value").ToString) & "','" & addSlashes(GVAfter.GetRowCellValue(i, "uom").ToString) & "')"
                Next
                execute_non_query(query, True, "", "", "", "")
                '
                query = "CALL gen_number('" & id_purc & "','179')"
                execute_non_query(query, True, "", "", "", "")
                '
                submit_who_prepared("179", id_purc, id_user)
                '
                load_head()
            Else
                'edit

            End If
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_purc
        FormReportMark.report_mark_type = "179"
        FormReportMark.is_view = is_view
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click

    End Sub

    Private Sub TEVat_EditValueChanged(sender As Object, e As EventArgs) Handles TEVat.EditValueChanged
        calculate()
    End Sub

    Private Sub LECurrency_EditValueChanged(sender As Object, e As EventArgs) Handles LECurrency.EditValueChanged
        Try
            load_remaining_budget()
            load_remaining_budget_after()
            If id_purc = "-1" Then
                If LECurrency.EditValue.ToString = "2" Then
                    Dim query_kurs As String = "SELECT * FROM tb_kurs_trans WHERE DATE(created_date) = DATE(NOW()) ORDER BY id_kurs_trans DESC"
                    Dim data_kurs As DataTable = execute_query(query_kurs, -1, True, "", "", "", "")

                    If Not data_kurs.Rows.Count > 0 Then
                        warningCustom("Today transaction kurs still not submitted, please contact FC.")
                        TEKurs.EditValue = 0.0
                    Else
                        TEKurs.EditValue = data_kurs.Rows(0)("kurs_trans")
                    End If
                Else
                    TEKurs.EditValue = 1.0
                End If
            End If
            '
            calculate()
        Catch ex As Exception
        End Try
    End Sub
End Class