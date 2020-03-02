Public Class FormReportBudgetList
    Public id_cat_main As String = ""
    Public id_departement As String = ""
    Public date_time As String = ""
    Public main_cat As String = "-1"
    Public year As String = ""

    Private Sub FormReportBudgetList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_list()
    End Sub

    Sub load_list()
        Dim q_dep_opex As String = ""
        Dim q_dep_capex As String = ""

        If Not id_departement = "0" Then
            q_dep_opex = " AND ot.id_departement='" & id_departement & "'"
            q_dep_capex = " AND et.id_departement='" & id_departement & "'"
        End If

        Dim query As String = "SELECT o.id_b_expense_opex,ot.`value`,ot.is_po,ot.`note`,ot.id_report,ot.report_mark_type,IF(ISNULL(po.purc_order_number),IF(ISNULL(rec.purc_rec_number),'',rec.purc_rec_number),po.purc_order_number) AS report_number
FROM `tb_b_expense_opex_trans` ot
INNER JOIN tb_b_expense_opex o ON ot.`id_b_expense_opex`=o.`id_b_expense_opex` AND o.id_item_cat_main='" & id_cat_main & "' " & q_dep_opex & "
LEFT JOIN tb_purc_order po ON po.id_purc_order=ot.id_report AND (ot.report_mark_type='139' or ot.report_mark_type='202')
LEFT JOIN tb_purc_rec rec ON rec.id_purc_rec=ot.id_report AND ot.report_mark_type='148'
WHERE o.`year`='" & year & "' AND DATE(ot.date_trans)<='" & date_time & "'
UNION ALL
SELECT et.id_b_expense,et.`value` AS val,et.is_po,et.`note`,et.id_report,et.report_mark_type,IF(ISNULL(po.purc_order_number),IF(ISNULL(rec.purc_rec_number),'',rec.purc_rec_number),po.purc_order_number) AS report_number
FROM `tb_b_expense_trans` et
INNER JOIN tb_b_expense e ON e.`id_b_expense`=et.`id_b_expense` AND e.id_item_cat_main='" & id_cat_main & "' " & q_dep_capex & "
LEFT JOIN tb_purc_order po ON po.id_purc_order=et.id_report AND (et.report_mark_type='139' or et.report_mark_type='202')
LEFT JOIN tb_purc_rec rec ON rec.id_purc_rec=et.id_report AND et.report_mark_type='148'
WHERE e.`year`='" & year & "' AND DATE(et.date_trans)<='" & date_time & "'"
        '
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBudgetCard.DataSource = data
        GVBudgetCard.BestFitColumns()
    End Sub

    Private Sub FormReportBudgetList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
        showpopup.report_mark_type = GVBudgetCard.GetFocusedRowCellValue("report_mark_type").ToString
        showpopup.id_report = GVBudgetCard.GetFocusedRowCellValue("id_report").ToString
        showpopup.show()
        Cursor = Cursors.Default
    End Sub
End Class