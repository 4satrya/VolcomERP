Public Class FormAccountingLedger
    Private Sub BViewJournal_Click(sender As Object, e As EventArgs) Handles BViewJournal.Click
        Dim fromdate As String = ""
        Dim enddate As String = ""

        If DEFromViewJournal.Text = "" Then
            DEFromViewJournal.DateTime = Now
            fromdate = Now.ToString("yyy-MM-dd")
        Else
            fromdate = DateTime.Parse(DEFromViewJournal.EditValue.ToString).ToString("yyy-MM-dd")
        End If

        If DEToViewJournal.Text = "" Then
            DEToViewJournal.DateTime = Now
            enddate = Now.ToString("yyy-MM-dd")
        Else
            enddate = DateTime.Parse(DEToViewJournal.EditValue.ToString).ToString("yyy-MM-dd")
        End If

        view_ledger(LEAccount.EditValue.ToString, fromdate, enddate)
    End Sub

    Sub view_ledger(ByVal id_account As String, ByVal fromdate As String, ByVal enddate As String)
        Dim query As String = ""
        query = "SELECT '-' AS id_acc,'-' AS number,"
        query += " If(SUM(debit)>=SUM(credit),(SUM(debit)-SUM(credit)),0) As debit,"
        query += " IF(SUM(credit)>=SUM(debit),(SUM(credit)-SUM(debit)),0) AS credit,"
        query += " DATE('" & fromdate & "') As `date`,'-' As reff,"
        query += " 'Opening Balance' AS note "
        query += " FROM tb_a_acc_trans_det trd "
        query += " INNER JOIN tb_a_acc_trans tr ON tr.id_acc_trans=trd.id_acc_trans "
        query += " WHERE trd.id_acc='" + id_account + "' AND DATE(tr.date_created) < '" & fromdate & "'"
        query += " UNION "
        query += "SELECT id_acc,tr.acc_trans_number as number,debit,credit,tr.date_created AS `date`,tr.report_number AS reff,tr.acc_trans_note as note FROM tb_a_acc_trans_det trd "
        query += " INNER JOIN tb_a_acc_trans tr On tr.id_acc_trans=trd.id_acc_trans WHERE trd.id_acc='" + id_account + "' "
        query += " AND (DATE(tr.date_created) <= '" & enddate & "') AND (DATE(tr.date_created) >= '" & fromdate & "')"
        query += " UNION "
        query += " Select id_acc,tra.acc_trans_adj_number as number,debit,credit,tr.date_created As `date`,tr.acc_trans_number As reff,tra.acc_trans_adj_note as note FROM tb_a_acc_trans_adj_det trad "
        query += " INNER JOIN tb_a_acc_trans_adj tra ON tra.id_acc_trans_adj=trad.id_acc_trans_adj "
        query += " INNER JOIN tb_a_acc_trans tr On tr.id_acc_trans=tra.id_acc_trans WHERE trad.id_acc='" + id_account + "' "
        query += " AND (DATE(tra.date_created) <= '" & enddate & "') AND (DATE(tra.date_created) >= '" & fromdate & "')"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAccTrans.DataSource = data
    End Sub

    Private Sub FormAccountingLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_account_child(LEAccount)
    End Sub

    Sub load_account_child(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT * FROM tb_a_acc WHERE id_is_det='2'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        viewLookupQuery(lookup, query, 1, "acc_description", "id_acc")
    End Sub
End Class