Public Class FormBudgetRevenueRevisionNew
    Private Sub FormBudgetRevenueRevisionNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewAnnual()
        SLEYear.Focus()
    End Sub

    Sub viewAnnual()
        Dim query As String = "SELECT b.year, SUM(b.b_revenue) AS `total`
        FROM tb_b_revenue b
        WHERE b.is_active=1
        GROUP BY b.year "
        viewSearchLookupQuery(SLEYear, query, "year", "year", "year")
        SLEYear.EditValue = -1
    End Sub

    Private Sub FormBudgetRevenueRevisionNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
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
            Dim qex As String = "SELECT * FROM tb_b_revenue_revision WHERE year='" + SLEYear.Text.ToString + "' AND (id_report_status=1 OR id_report_status=3) "
            Dim dex As DataTable = execute_query(qex, -1, True, "", "", "", "")
            If dex.Rows.Count > 0 Then
                cond_exist = True
            End If

            If cond_exist Then
                warningCustom("Revisi anggaran tidak dapat dilakukan, karena revisi anggaran tahun " + SLEYear.Text.ToString + " sedang diproses.")
            Else
                Dim year As String = SLEYear.Text.ToString
                Dim value_expense_total_old = decimalSQL(TxtTotal.EditValue.ToString)
                Dim query As String = "INSERT INTO tb_b_revenue_revision(year, created_date, id_created_user, value_expense_total_old,value_expense_total, note, id_report_status) 
                VALUES('" + year + "', NOW(), '" + id_user + "','" + value_expense_total_old + "',0,'" + addSlashes(MEReason.Text) + "',1); SELECT LAST_INSERT_ID(); "
                Dim id As String = execute_query(query, 0, True, "", "", "", "")

                'update number
                Dim qn As String = "CALL gen_number(" + id + ",147)"
                execute_non_query(qn, True, "", "", "", "")

                'refresh
                FormBudgetRevPropose.viewRevision()
                FormBudgetRevPropose.GVRevision.FocusedRowHandle = find_row(FormBudgetRevPropose.GVRevision, "id_b_revenue_revision", id)
                FormBudgetRevenueRevisionDet.id = id
                FormBudgetRevenueRevisionDet.ShowDialog()
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
End Class