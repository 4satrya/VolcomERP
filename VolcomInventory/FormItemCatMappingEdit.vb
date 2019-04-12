Public Class FormItemCatMappingEdit
    Public id_detail As String = "-1"

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        viewSearchLookupQuery(SLEAccount, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Private Sub FormItemCatMappingEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCOA()

        'load detail
        Dim query As String = "SELECT cd.id_item_coa_propose_det, cd.id_departement, d.departement, cd.id_item_cat, cat.item_cat, cd.id_coa_out, cd.is_request 
        FROM tb_item_coa_propose_det cd
        INNER JOIN tb_m_departement d ON d.id_departement = cd.id_departement
        INNER JOIN tb_item_cat cat ON cat.id_item_cat = cd.id_item_cat
        WHERE cd.id_item_coa_propose_det='" + id_detail + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtCat.Text = data.Rows(0)("item_cat").ToString
        TxtDept.Text = data.Rows(0)("departement").ToString
        SLEAccount.EditValue = data.Rows(0)("id_coa_out")
        Dim is_request As String = data.Rows(0)("is_request").ToString
        If is_request = "1" Then
            CERequest.EditValue = True
        Else
            CERequest.EditValue = False
        End If
    End Sub

    Private Sub FormItemCatMappingEdit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Cursor = Cursors.WaitCursor
        Dim id_coa_out As String = SLEAccount.EditValue.ToString
        Dim is_request As String = ""
        If CERequest.EditValue = True Then
            is_request = "1"
        Else
            is_request = "2"
        End If
        Dim query As String = "UPDATE tb_item_coa_propose_det SET id_coa_out='" + id_coa_out + "', is_request='" + is_request + "' WHERE id_item_coa_propose_det='" + id_detail + "' "
        execute_non_query(query, True, "", "", "", "")
        FormItemCatMappingDet.viewDetail()
        FormItemCatMappingDet.GVMapping.FocusedRowHandle = find_row(FormItemCatMappingDet.GVMapping, "id_item_coa_propose_det", id_detail)
        Close()
        Cursor = Cursors.Default
    End Sub
End Class