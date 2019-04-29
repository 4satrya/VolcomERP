Public Class FormWorkOrderStatus
    Public id_wo As String = ""
    Private Sub FormWorkOrderStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_work_order_status()
    End Sub
    Sub load_work_order_status()
        Dim query As String = "Select wos.`id_work_order_status`,wos.work_order_status FROM tb_lookup_work_order_status wos WHERE id_work_order_status>1"
        viewSearchLookupQuery(SLEType, query, "id_work_order_status", "work_order_status", "id_work_order_status")
        '
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim query As String = ""
        'update wo
        query = "UPDATE tb_work_order SET id_work_order_status='" & SLEType.EditValue.ToString & "' WHERE id_work_order='" & id_wo & "'"
        execute_non_query(query, True, "", "", "", "")
        'insert history
        query = "INSERT INTO tb_work_order_status_history(`id_work_order`,`id_work_order_status`,`note`,`created_date`,`created_by`) VALUES('" & id_wo & "','" & SLEType.EditValue.ToString & "','" & addSlashes(MENote.Text) & "',NOW(),'" & id_user & "')"
        execute_non_query(query, True, "", "", "", "")
        '
        infoCustom("Work recorded")
        FormWorkOrder.load_wo()
        Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormWorkOrderStatus_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class