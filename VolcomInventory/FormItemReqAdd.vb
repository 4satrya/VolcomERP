Public Class FormItemReqAdd
    Public data_par As DataTable
    '
    Dim is_from_storage As Boolean = False
    Public id_departement As String = "-1"
    '
    Private Sub FormItemReqAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCat()
        fill_dt()
    End Sub

    Sub fill_dt()
        data_par = FormItemReqDet.GCData.DataSource
    End Sub

    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_item_cat`, 'All Category' AS `item_cat`
        UNION ALL
        SELECT c.id_item_cat, c.item_cat FROM tb_item_cat c ORDER BY id_item_cat ASC"
        viewLookupQuery(LECat, query, 0, "item_cat", "id_item_cat")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormItemReqAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVSOH)

        'group by dept
        GridColumnDept.GroupIndex = 0

        'id purchasing store
        Dim id_purc_store As String = get_purc_setup_field("id_purc_store")

        'Prepare paramater
        Dim date_until_selected As String = "9999-01-01"
        Dim id_item_cat As String = LECat.EditValue.ToString
        If id_item_cat = "0" Then
            id_item_cat = ""
        Else
            id_item_cat = "AND im.id_item_cat='" + id_item_cat + "' "
        End If
        '
        Dim cond As String = ""

        If is_from_storage = True Then
            cond = "AND (i.id_departement=" + id_purc_store + ") " + id_item_cat
        Else
            cond = "AND (i.id_departement=" + id_departement + ") " + id_item_cat
        End If

        Dim stc As New ClassPurcItemStock()
        Dim id_wh_storage As String = get_purc_setup_field("id_comp_def_storage")
        Dim query As String = stc.queryGetStock(cond & " AND cat.is_only_transfer='2' AND i.id_comp='" & id_wh_storage & "' ", "0", date_until_selected)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'data
        If data_par.Rows.Count = 0 Then
            GCSOH.DataSource = data
        Else
            Dim t1 = data.AsEnumerable()
            Dim t2 = data_par.AsEnumerable()
            Try
                Dim except As DataTable = (From _t1 In t1
                                           Group Join _t2 In t2
                                               On _t1("id_item").ToString Equals _t2("id_item").ToString Into Group
                                           From _t3 In Group.DefaultIfEmpty()
                                           Where _t3 Is Nothing
                                           Select _t1).CopyToDataTable
                GCSOH.DataSource = except
            Catch ex As Exception
                warningCustom("No items available." + System.Environment.NewLine + ex.ToString)
            End Try
        End If
        GVSOH.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        If CEStoreRequest.Checked = True Then
            is_from_storage = True
            GridColumnQty.Visible = False
        Else
            is_from_storage = False
            GridColumnQty.VisibleIndex = 3
        End If
        '
        viewData()
    End Sub

    Private Sub LECat_EditValueChanged(sender As Object, e As EventArgs) Handles LECat.EditValueChanged
        GCSOH.DataSource = Nothing
    End Sub

    Private Sub GVSOH_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVSOH.CellValueChanged
        If e.Column.FieldName = "qty_req" Then
            Dim rh As Integer = e.RowHandle
            If e.Value >= 0 Then
                Dim old_value As Decimal = GVSOH.ActiveEditor.OldEditValue
                If e.Value > GVSOH.GetRowCellValue(rh, "qty") And is_from_storage = False Then
                    warningCustom("Can't exceed " + GVSOH.GetRowCellValue(rh, "qty").ToString)
                    GVSOH.SetRowCellValue(rh, "qty_req", old_value)
                End If
            Else
                GVSOH.SetRowCellValue(rh, "qty_req", 0)
            End If
            GVSOH.BestFitColumns()
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVSOH)
        GVSOH.ActiveFilterString = "[qty_req]>0"
        If GVSOH.RowCount > 0 Then
            For i As Integer = 0 To ((GVSOH.RowCount - 1) - GetGroupRowCount(GVSOH))
                Dim newRow As DataRow = (TryCast(FormItemReqDet.GCData.DataSource, DataTable)).NewRow()
                newRow("id_item") = GVSOH.GetRowCellValue(i, "id_item").ToString
                newRow("item_desc") = GVSOH.GetRowCellValue(i, "item_desc").ToString
                newRow("qty") = GVSOH.GetRowCellValue(i, "qty_req")
                If is_from_storage = True Then
                    newRow("is_store_request") = "yes"
                Else
                    newRow("is_store_request") = "no"
                End If
                newRow("remark") = GVSOH.GetRowCellValue(i, "remark").ToString
                TryCast(FormItemReqDet.GCData.DataSource, DataTable).Rows.Add(newRow)
                FormItemReqDet.GCData.RefreshDataSource()
                FormItemReqDet.GVData.RefreshData()
            Next
            Close()
        Else
            warningCustom("No item selected")
            makeSafeGV(GVSOH)
            GridColumnDept.GroupIndex = 0
        End If
        Cursor = Cursors.Default
    End Sub
End Class