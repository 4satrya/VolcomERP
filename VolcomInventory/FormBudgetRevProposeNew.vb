Public Class FormBudgetRevProposeNew
    Public action As String = ""
    Public id As String = "-1"

    Private Sub FormBudgetRevProposeNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If action = "upd" Then
            Dim query_c As New ClassBudgetRevPropose()
            Dim query As String = query_c.queryMain("AND rp.id_b_revenue_propose=" + id + "", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtYear.Text = data.Rows(0)("year").ToString
            TxtTotal.EditValue = data.Rows(0)("total")
            MENote.Text = data.Rows(0)("note").ToString
        ElseIf action = "ins" Then
            TxtTotal.EditValue = 0.0
        End If
    End Sub

    Private Sub FormBudgetRevProposeNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        save()
    End Sub

    Sub save()
        Dim cond As Boolean = True
        Dim query_c As New ClassBudgetRevPropose()
        Dim check_upd As String = ""
        If action = "upd" Then
            check_upd = "AND rp.id_b_revenue_propose!=" + id + " "
        End If
        Dim queryc As String = query_c.queryMain("AND rp.year='" + TxtYear.Text + "' AND rp.id_report_status!=5 " + check_upd, "2")
        Dim data As DataTable = execute_query(queryc, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            cond = False
        End If

        If Not cond Then
            warningCustom("Anggaran tahun : " + TxtYear.Text + " sudah dibuat")
        Else
            Cursor = Cursors.WaitCursor
            Dim year As String = TxtYear.Text
            Dim total As String = decimalSQL(TxtTotal.EditValue.ToString)
            Dim note As String = addSlashes(MENote.Text)
            If action = "ins" Then
                Dim query As String = "INSERT INTO tb_b_revenue_propose(number, year, total, created_date, id_created_user, note, id_report_status)
                VALUES('" + header_number_sales("36") + "', '" + year + "', '" + total + "', NOW(), '" + id_user + "', '" + note + "','1'); SELECT LAST_INSERT_ID(); "
                id = execute_query(query, 0, True, "", "", "", "")
                FormBudgetRevPropose.viewData()
                FormBudgetRevPropose.GVRev.FocusedRowHandle = find_row(FormBudgetRevPropose.GVRev, "id_b_revenue_propose", id)
                FormBudgetRevPropose.is_new = True
                Close()
            ElseIf action = "upd" Then
                Dim query As String = "UPDATE tb_b_revenue_propose SET year='" + year + "', total='" + total + "', note='" + note + "' WHERE id_b_revenue_propose='" + id + "' "
                execute_non_query(query, True, "", "", "", "")
                FormBudgetRevPropose.viewData()
                FormBudgetRevPropose.GVRev.FocusedRowHandle = find_row(FormBudgetRevPropose.GVRev, "id_b_revenue_propose", id)
                Close()
                FormBudgetRevProposeDet.actionLoad()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub TxtYear_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtYear.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtTotal.Focus()
        End If
    End Sub

    Private Sub TxtTotal_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtTotal.KeyDown
        If e.KeyCode = Keys.Enter Then
            MENote.Focus()
        End If
    End Sub

    Private Sub MENote_KeyDown(sender As Object, e As KeyEventArgs) Handles MENote.KeyDown
        If e.KeyCode = Keys.Enter Then
            save()
        End If
    End Sub
End Class