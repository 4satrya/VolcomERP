Public Class FormPurcItem
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormPurcItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_expense_type()
        load_active()
        load_cat()
        load_item()
    End Sub

    Sub load_active()
        Dim query As String = "SELECT 0 AS id_status,'All' AS `status`
                                UNION
                                SELECT id_status,`status` FROM `tb_lookup_status`"
        viewSearchLookupQuery(SLEActive, query, "id_status", "status", "id_status")
    End Sub

    Sub load_cat()
        Dim q_where As String = ""
        '
        If Not SLEType.EditValue.ToString = "0" Then
            q_where = " AND id_expense_type='" & SLEType.EditValue.ToString & "'"
        End If
        '
        Dim query As String = "SELECT 0 AS id_item_cat,'All' AS `item_cat`
                                UNION
                                SELECT id_item_cat,item_cat FROM tb_item_cat WHERE is_active='1'" & q_where
        viewSearchLookupQuery(SLECat, query, "id_item_cat", "item_cat", "id_item_cat")
    End Sub

    Sub load_expense_type()
        Dim query As String = "SELECT 0 AS id_expense_type,'All' AS `expense_type`
                                UNION
                                SELECT id_expense_type,expense_type FROM tb_lookup_expense_type"
        viewSearchLookupQuery(SLEType, query, "id_expense_type", "expense_type", "id_expense_type")
    End Sub

    Sub load_item()
        Dim q_type As String = ""
        Dim q_active As String = ""
        Dim q_cat As String = ""
        '
        If SLEType.EditValue.ToString = "0" Then
            q_type = "'%%'"
        Else
            q_type = "'" & SLEType.EditValue.ToString & "'"
        End If
        '
        If SLEActive.EditValue.ToString = "0" Then
            q_active = "'%%'"
        Else
            q_active = "'" & SLEActive.EditValue.ToString & "'"
        End If

        If SLECat.EditValue.ToString = "0" Then
            q_cat = "'%%'"
        Else
            q_cat = "'" & SLECat.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT id_item,item.id_item,item.item_desc,type.expense_type,cat.`item_cat`,uom.uom,empc.`employee_name` AS emp_created,item_type.`item_type`,empu.`employee_name` AS emp_updated,date_created,date_updated,IF(item.`is_active`=1,'yes','no') AS is_active 
                                FROM tb_item item
                                INNER JOIN tb_item_cat cat ON cat.`id_item_cat`=item.`id_item_cat`
                                INNER JOIN tb_m_uom uom ON uom.`id_uom`=item.`id_uom`
                                INNER JOIN tb_m_user usrc ON usrc.`id_user`=item.`id_user_created`
                                INNER JOIN tb_m_employee empc ON empc.`id_employee`=usrc.`id_employee`
                                INNER JOIN tb_lookup_expense_type `type` ON type.id_expense_type=cat.id_expense_type
                                INNER JOIN tb_lookup_purc_item_type item_type ON item_type.`id_item_type`=item.`id_item_type`
                                LEFT JOIN tb_m_user usru ON usru.`id_user`=item.`id_user_updated`
                                LEFT JOIN tb_m_employee empu ON empu.`id_employee`=usru.`id_employee`
                                WHERE cat.id_expense_type LIKE " & q_type & " AND item.id_item_cat LIKE " & q_cat & " AND item.is_active LIKE " & q_active
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItem.DataSource = data
    End Sub

    Private Sub FormPurcItem_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormPurcItem_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVItem.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            'noManipulating()
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            'noManipulating()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        load_item()
    End Sub

    Private Sub SLEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEType.EditValueChanged
        load_cat()
    End Sub
End Class