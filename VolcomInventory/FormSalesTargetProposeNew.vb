Public Class FormSalesTargetProposeNew
    Public action As String = "-1"
    Public id As String = "-1"

    Private Sub FormSalesTargetProposeNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If action = "upd" Then
            Dim query_c As New ClassSalesTarget()
            Dim query As String = query_c.queryMain("AND t.id_sales_trg_propose=" + id + "", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtYear.Text = data.Rows(0)("year").ToString
            MENote.Text = data.Rows(0)("note").ToString
            BtnCreateNew.Text = "Save Changes"
        End If
    End Sub


    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSalesTargetProposeNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        Dim cond As Boolean = True
        Dim query_c As New ClassSalesTarget()
        Dim check_upd As String = ""
        If action = "upd" Then
            check_upd = "AND t.id_sales_trg_propose!=" + id + " "
        End If
        Dim queryc As String = query_c.queryMain("AND t.year='" + TxtYear.Text + "' AND t.id_report_status!=5 " + check_upd, "2")
        Dim data As DataTable = execute_query(queryc, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            cond = False
        End If

        If Not cond Then
            warningCustom("Sales target for " + TxtYear.Text + " already created")
        Else
            Cursor = Cursors.WaitCursor
            Dim year As String = TxtYear.Text
            Dim note As String = addSlashes(MENote.Text)
            If action = "ins" Then
                Dim query As String = "INSERT INTO tb_sales_trg_propose(year, number, created_date, updated_date, note, id_report_status, is_confirm)
                VALUES('" + year + "', '', NOW(), NOW(), '" + note + "', 1, 2); SELECT LAST_INSERT_ID(); "
                id = execute_query(query, 0, True, "", "", "", "")

                'update number
                execute_non_query("CALL gen_number(" + id + ", 191)", True, "", "", "", "")

                FormSalesTargetPropose.viewPropose()
                FormSalesTargetPropose.GVData.FocusedRowHandle = find_row(FormSalesTargetPropose.GVData, "id_sales_trg_propose", id)
                FormSalesTargetPropose.is_new = True
                Close()
            ElseIf action = "upd" Then
                Dim query As String = "UPDATE tb_sales_trg_propose SET year='" + year + "', note='" + note + "' WHERE id_sales_trg_propose='" + id + "' "
                execute_non_query(query, True, "", "", "", "")
                FormSalesTargetPropose.viewPropose()
                FormSalesTargetPropose.GVData.FocusedRowHandle = find_row(FormSalesTargetPropose.GVData, "id_sales_trg_propose", id)
                Close()
                FormSalesTargetProposeDet.actionLoad()
            End If
            Cursor = Cursors.Default
        End If
    End Sub
End Class