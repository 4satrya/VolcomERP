Public Class FormBudgetExpenseRevisionNew
    Public id_dept As String = "-1"
    Dim is_admin As String = FormBudgetExpenseRevision.is_admin

    Private Sub FormBudgetExpenseRevisionNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_dept = id_departement_user
        TxtDept.Text = get_departement_x(id_departement_user, "1")
        If is_admin = "-1" Then
            BtnBrowse.Enabled = False
        End If

        viewAnnual()
        SLEYear.Focus()
    End Sub

    Sub viewAnnual()
        Dim query As String = "SELECT b.year, SUM(b.value_expense) AS `total`
        FROM tb_b_expense b
        INNER JOIN tb_item_coa c ON c.id_item_coa = b.id_item_coa
        WHERE c.id_departement='" + id_dept + "'
        GROUP BY b.year "
        viewSearchLookupQuery(SLEYear, query, "year", "year", "year")
        SLEYear.EditValue = Nothing
        TxtTotal.EditValue = 0.00
    End Sub


    Private Sub FormBudgetExpenseRevisionNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        If SLEYear.EditValue = Nothing Or MEReason.Text = "" Then
            warningCustom("Lengkapi seluruh data.")
        Else
            'check outstanding
            Dim cond_exist = False
            Dim qex As String = "SELECT * FROM tb_b_expense_revision WHERE year='" + SLEYear.Text.ToString + "' AND id_departement='" + id_dept + "' AND (id_report_status=1 OR id_report_status=3) "
            Dim dex As DataTable = execute_query(qex, -1, True, "", "", "", "")
            If dex.Rows.Count > 0 Then
                cond_exist = True
            End If

            If cond_exist Then
                warningCustom("Revisi anggaran tidak dapat dilakukan, karena revisi anggaran tahun " + SLEYear.Text.ToString + " sedang diproses.")
            Else
                Dim year As String = SLEYear.Text.ToString
                Dim value_expense_total_old = decimalSQL(TxtTotal.EditValue.ToString)
                Dim query As String = "INSERT INTO tb_b_expense_revision(id_departement, year, created_date, id_created_user, value_expense_total_old,value_expense_total, note, id_report_status) 
                VALUES('" + id_dept + "', '" + year + "', NOW(), '" + id_user + "','" + value_expense_total_old + "',0,'" + addSlashes(MEReason.Text) + "',1); SELECT LAST_INSERT_ID(); "
                Dim id As String = execute_query(query, 0, True, "", "", "", "")

                'update number
                Dim qn As String = "CALL gen_number(" + id + ",138)"
                execute_non_query(qn, True, "", "", "", "")

                'refresh
                FormBudgetExpenseRevision.viewData()
                FormBudgetExpenseRevision.GVData.FocusedRowHandle = find_row(FormBudgetExpenseRevision.GVData, "id_b_expense_revision", id)
                FormBudgetExpenseRevisionDet.id = id
                FormBudgetExpenseRevisionDet.ShowDialog()
                Close()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEYear_EditValueChanged(sender As Object, e As EventArgs) Handles SLEYear.EditValueChanged
        Try
            TxtTotal.EditValue = SLEYear.Properties.View.GetFocusedRowCellValue("total")
        Catch ex As Exception
            TxtTotal.Text = ""
        End Try
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        Cursor = Cursors.WaitCursor
        FormPopUpDept.id_pop_up = "3"
        FormPopUpDept.ControlBox = False
        FormPopUpDept.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class