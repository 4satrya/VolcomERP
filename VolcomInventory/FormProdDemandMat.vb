Public Class FormProdDemandMat
    Public id_prod_demand As String = "-1"
    Public id_comp_ship_to As String = "-1"
    Public is_in_mat As String = "-1"
    Private Sub FormProdDemandMat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'load
        If is_in_mat = "1" Then
            LProdDemand.Text = FormMatPurchase.GVProdDemand.GetFocusedRowCellDisplayText("prod_demand_number").ToString
        Else
            LProdDemand.Text = FormProdDemand.GVProdDemand.GetFocusedRowCellDisplayText("prod_demand_number").ToString
        End If
        view_prod_mat()
    End Sub
    Sub view_prod_mat()
        Dim query As String = "CALL view_pd_mat(" & id_prod_demand & ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMaterialList.DataSource = data
        GVMaterialList.Columns("id_comp").GroupIndex = 0
    End Sub

    Private Sub GVMaterialList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMaterialList.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub

    Private Sub GVMaterialList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMaterialList.CustomColumnDisplayText
        If e.Column.FieldName = "id_comp" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMaterialList.IsGroupRow(rowhandle) Then
                rowhandle = GVMaterialList.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMaterialList.GetRowCellDisplayText(rowhandle, "comp_name")
            End If
        End If
    End Sub

    Private Sub BCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCreate.Click
        'generate PO
        'check first
        GVMaterialList.ExpandAllGroups()
        If id_comp_ship_to = "-1" Then
            stopCustom("Please choose ship location.")
        Else
            Dim id_vendor_prev As String = "-1"
            Dim id_vendor As String = "-1"
            Dim query, id_comp_to, notex, id_delivery, po_number, id_purc_new, po_created, string_filter As String 'for po
            If is_in_mat = "1" Then
                id_delivery = execute_query("SELECT id_delivery FROM tb_season_delivery WHERE id_season='" & FormMatPurchase.GVProdDemand.GetFocusedRowCellValue("id_season") & "' LIMIT 1", 0, True, "", "", "", "")
            Else
                id_delivery = execute_query("SELECT id_delivery FROM tb_season_delivery WHERE id_season='" & FormProdDemand.GVProdDemand.GetFocusedRowCellValue("id_season") & "' LIMIT 1", 0, True, "", "", "", "")
            End If
            notex = MENote.Text
            id_purc_new = "-1"
            po_created = "-1"
            po_number = "-2"
            string_filter = ""

            For i As Integer = 0 To GVMaterialList.RowCount - 1
                'jika bukan header group
                Try
                    id_vendor = GVMaterialList.GetRowCellValue(i, "id_comp").ToString

                    If Not id_vendor = id_vendor_prev Then
                        'create PO first if new vendor
                        id_comp_to = get_company_x(GVMaterialList.GetRowCellValue(i, "id_comp").ToString, "6")
                        po_number = header_number_mat("1")
                        If po_created = "-1" Then
                            po_created = po_number
                            string_filter = "[mat_purc_number]='" & po_number & "'"
                        Else
                            string_filter += " OR [mat_purc_number]='" & po_number & "'"
                        End If
                        query = String.Format("INSERT INTO tb_mat_purc(id_delivery,mat_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,mat_purc_date,mat_purc_lead_time,mat_purc_top,id_currency,mat_purc_note,mat_purc_vat,mat_purc_kurs) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',DATE(NOW()),'{6}','{7}','{8}','{9}','{10}','{11}');SELECT LAST_INSERT_ID(); ", id_delivery, po_number, id_comp_to, id_comp_ship_to, "1", "1", "0", "0", "1", notex, "0", "1")

                        id_purc_new = execute_query(query, 0, True, "", "", "", "")
                        '
                        insert_who_prepared("13", id_purc_new, id_user)

                        increase_inc_mat("1")
                    End If
                    id_vendor_prev = id_vendor

                    'add detail
                    query = String.Format("INSERT INTO tb_mat_purc_det(id_mat_purc,id_mat_det_price,mat_purc_det_price,mat_purc_det_discount,mat_purc_det_qty,mat_purc_det_note) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id_purc_new, GVMaterialList.GetRowCellValue(i, "id_mat_det_price").ToString, GVMaterialList.GetRowCellValue(i, "price").ToString, "0", GVMaterialList.GetRowCellValue(i, "qty").ToString, "")
                    execute_non_query(query, True, "", "", "", "")
                Catch ex As Exception
                End Try
            Next
            'end of loop
            If po_created = "-1" Then
                infoCustom("No PO Generated.")
            Else
                If Not po_created = po_number Then
                    po_created = po_created & " - " & po_number
                End If
                infoCustom("PO Generated successfully." & vbNewLine & "Generated PO number : " & po_created)
            End If
            If is_in_mat = "1" Then
                '
                FormMatPurchase.XTCPurcMat.SelectedTabPageIndex = 0
                FormMatPurchase.view_mat_purc()
                FormMatPurchase.GVMatPurchase.ActiveFilterString = string_filter
            End If
            Close()
        End If
    End Sub

    Private Sub BSearchCompShipTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSearchCompShipTo.Click
        FormPopUpContact.id_pop_up = "18"
        FormPopUpContact.ShowDialog()
    End Sub
End Class