Public Class FormBudgetProdDemandNew
    Private Sub FormBudgetProdDemandNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEYearBudget.EditValue = Now
    End Sub

    Private Sub FormBudgetProdDemandNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        'cek ada outstanidng gk
        Dim qcek As String = "SELECT COUNT(*) AS `jum_created` 
        FROM tb_b_prod_demand_propose b
        WHERE b.`year`='" + DEYearBudget.Text + "' AND b.id_report_status!=5 "
        Dim cek As String = execute_query(qcek, 0, True, "", "", "", "")
        If cek <> "0" Then
            stopCustom("Propose budget already processed.")
            Exit Sub
        End If

        If DEYearBudget.Text = "" Or MENote.Text = "" Then
            warningCustom("Please complete all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create propose budget ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                'insert
                Dim query As String = "INSERT INTO tb_b_prod_demand_propose(year,created_date, note)
                VALUES('" + DEYearBudget.Text + "', NOW(), '" + addSlashes(MENote.Text) + "'); SELECT LAST_INSERT_ID(); "
                Dim id As String = execute_query(query, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id + ", 238); ", True, "", "", "", "")

                'refresh
                Dim dtnow As DateTime = getTimeDB()
                FormBudgetProdDemand.DEFrom.EditValue = dtnow
                FormBudgetProdDemand.DEUntil.EditValue = dtnow
                FormBudgetProdDemand.viewProposeByDate()
                FormBudgetProdDemand.GVProposed.FocusedRowHandle = find_row(FormBudgetProdDemand.GVProposed, "id_b_prod_demand_propose", id)
                Close()

                'detail
                FormBudgetProdDemandDet.id = id
                FormBudgetProdDemandDet.ShowDialog()
            End If
        End If
    End Sub
End Class