Public Class FormItemReqAddStore
    Private Sub FormItemReqAddStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCat()
        viewStore()
        start()
    End Sub

    Sub start()
        SLEStore.EditValue = Nothing
        TxtQty.EditValue = 0.0
        MENote.Text = ""
    End Sub

    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_item_cat`, 'All Category' AS `item_cat`
        UNION ALL
        SELECT c.id_item_cat, c.item_cat 
        FROM tb_item_cat c 
        INNER JOIN tb_item i ON i.id_item_cat = c.id_item_cat
        WHERE c.id_expense_type=1
        GROUP BY c.id_item_cat
        ORDER BY id_item_cat ASC"
        viewSearchLookupQuery(SLECat, query, "id_item_cat", "item_cat", "id_item_cat")
        Cursor = Cursors.Default
    End Sub


    Sub viewItem()
        Cursor = Cursors.WaitCursor
        Dim id_item_cat As String = "-1"
        Try
            id_item_cat = SLECat.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim cond As String = ""
        If id_item_cat = "0" Then
            cond = ""
        Else
            cond = "AND i.id_item_cat = '" + id_item_cat + "' "
        End If
        Dim query As String = "SELECT i.id_item, i.item_desc , u.uom
        FROM tb_item i 
        INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
        INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
        WHERE i.id_item>0 AND cat.id_expense_type=1 " + cond
        viewSearchLookupQuery(SLEItem, query, "id_item", "item_desc", "id_item")
        Cursor = Cursors.Default
    End Sub

    Sub viewStock()
        Cursor = Cursors.WaitCursor

        Dim id_item As String = "-1"
        Try
            id_item = SLEItem.EditValue.ToString
        Catch ex As Exception
        End Try

        'get qty yg sudah diinput
        makeSafeGV(FormItemReqDet.GVDetail)
        FormItemReqDet.GVDetail.ActiveFilterString = "[id_item]='" + id_item + "' "
        Dim current As Decimal = 0
        Try
            current = FormItemReqDet.GVDetail.Columns("qty").SummaryItem.SummaryValue
        Catch ex As Exception
        End Try
        makeSafeGV(FormItemReqDet.GVDetail)

        'Prepare paramater
        Dim date_until_selected As String = "9999-01-01"
        Dim cond As String = "AND i.id_departement=" + id_departement_user + " AND i.id_item='" + id_item + "' "
        Dim stc As New ClassPurcItemStock()
        Dim query As String = stc.queryGetStock(cond, date_until_selected)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")


        If data.Rows.Count > 0 Then
            Dim avail As Decimal = data.Rows(0)("qty") - current
            If avail <= 0 Then
                TxtAvailable.EditValue = 0.00
            Else
                TxtAvailable.EditValue = avail
            End If
        Else
            TxtAvailable.EditValue = 0.0
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewStore()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT c.id_comp,c.comp_number, c.comp_name, CONCAT(c.comp_number,' - ', c.comp_name) AS `comp`
        FROM tb_m_comp c WHERE c.id_comp_cat=6
        ORDER BY c.comp_number ASC "
        viewSearchLookupQuery(SLEStore, query, "id_comp", "comp", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormItemReqAddStore_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SLECat_EditValueChanged(sender As Object, e As EventArgs) Handles SLECat.EditValueChanged
        viewItem()
    End Sub

    Private Sub SLEItem_EditValueChanged(sender As Object, e As EventArgs) Handles SLEItem.EditValueChanged
        viewStock()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(FormItemReqDet.GVDetail)

        'check existing
        Dim cond_exist As Boolean = False
        Dim id_store_cek As String = "-1"
        Try
            id_store_cek = SLEStore.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim id_item_cek As String = SLEItem.EditValue.ToString
        FormItemReqDet.GVDetail.ActiveFilterString = "[id_item]='" + id_item_cek + "' AND [id_comp]='" + id_store_cek + "' "
        If FormItemReqDet.GVDetail.RowCount > 0 Then
            cond_exist = True
        End If
        makeSafeGV(FormItemReqDet.GVDetail)

        If SLEStore.EditValue = Nothing Then
            warningCustom("Please input store")
        ElseIf cond_exist Then
            warningCustom("Already exist !")
        ElseIf TxtQty.EditValue <= 0 Then
            warningCustom("Please input quantity")
        Else
            If TxtQty.EditValue > TxtAvailable.EditValue Then
                warningCustom("Can't exceed " + TxtAvailable.EditValue.ToString)
            Else
                Dim col_foc_str As String() = Split(SLEStore.Text, " - ")
                Dim newRow As DataRow = (TryCast(FormItemReqDet.GCDetail.DataSource, DataTable)).NewRow()
                newRow("id_item") = SLEItem.EditValue.ToString
                newRow("item_desc") = SLEItem.Text.ToString
                newRow("id_comp") = SLEStore.EditValue.ToString
                newRow("comp_number") = col_foc_str(0)
                newRow("comp_name") = col_foc_str(1)
                newRow("qty") = TxtQty.EditValue
                newRow("remark") = addSlashes(MENote.Text)
                TryCast(FormItemReqDet.GCDetail.DataSource, DataTable).Rows.Add(newRow)
                FormItemReqDet.GCDetail.RefreshDataSource()
                FormItemReqDet.GVDetail.RefreshData()
                start()
                viewStock()
            End If
        End If
        Cursor = Cursors.Default
    End Sub
End Class