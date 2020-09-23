Public Class FormPayoutVerAdd
    Private Sub FormPayoutVerAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCOA()
        viewDK()
        resetForm()
    End Sub

    Sub resetForm()
        TxtAmount.EditValue = 0.00
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 AND a.id_coa_type='1' "
        viewSearchLookupQuery(SLECOA, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub viewDK()
        Dim query As String = "SELECT * FROM tb_lookup_dc d WHERE d.id_dc=1 OR d.id_dc=2 "
        viewLookupQuery(LEDK, query, 0, "dc_code", "id_dc")
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        Dim query As String = "INSERT INTO tb_list_payout_ver_det(id_list_payout_ver, id_acc, id_dc, value)
        VALUES('" + FormPayoutVerDet.id + "', '" + SLECOA.EditValue.ToString + "', '" + LEDK.EditValue.ToString + "', '" + decimalSQL(TxtAmount.EditValue.ToString) + "');"
        execute_non_query(query, True, "", "", "", "")
        FormPayoutVerDet.viewDetail()
        resetForm()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
End Class