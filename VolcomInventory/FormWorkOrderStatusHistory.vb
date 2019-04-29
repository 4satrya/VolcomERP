Public Class FormWorkOrderStatusHistory
    Public id_wo As String = ""
    Private Sub FormWorkOrderStatusHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_history()
    End Sub

    Sub load_history()
        Dim query As String = "SELECT woh.id_work_order_status_history,sts.`work_order_status`,woh.`note`,woh.`created_date`,emp.`employee_name`
FROM `tb_work_order_status_history` woh
INNER JOIN tb_lookup_work_order_status sts ON sts.id_work_order_status=woh.id_work_order_status
INNER JOIN tb_m_user usr ON usr.`id_user`=woh.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE woh.id_work_order='" & id_wo & "'
ORDER BY woh.`created_date` DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCHistory.DataSource = data
        GVHistory.BestFitColumns()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        print(GCHistory, "Work History - " & FormWorkOrder.GVWorkOrder.GetFocusedRowCellValue("number"))
    End Sub
End Class