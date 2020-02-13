Public Class FormReportBudgetList
    Public id_cat_main As String = ""
    Public date_time As String = ""
    Public main_cat As String = "-1"
    Public year As String = ""

    Private Sub FormReportBudgetList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_list()
    End Sub

    Sub load_list()
        Dim query As String = "SELECT o.id_b_expense_opex,ot.`value`,ot.is_po,ot.`note`,ot.id_report,ot.report_mark_type
FROM `tb_b_expense_opex_trans` ot
INNER JOIN tb_b_expense_opex o ON ot.`id_b_expense_opex`=o.`id_b_expense_opex`
WHERE o.`year`='" & year & "' AND DATE(ot.date_trans)<='" & date_time & "'
UNION ALL
SELECT et.id_b_expense,et.`value` AS val,et.is_po,et.`note`,et.id_report,et.report_mark_type
FROM `tb_b_expense_trans` et
INNER JOIN tb_b_expense e ON e.`id_b_expense`=et.`id_b_expense`
WHERE e.`year`='" & year & "' AND DATE(et.date_trans)<='" & date_time & "'"
        '
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBudgetCard.DataSource = data
        GVBudgetCard.BestFitColumns()
    End Sub

    Private Sub FormReportBudgetList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class