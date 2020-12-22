Public Class FormOLStoreOOS
    Public id_type As String = "1"

    Private Sub FormOLStoreOOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewType()
        viewProgress()
        If id_type = "2" Then
            'MD Menu
            viewData()
        ElseIf id_type = "3" Then
            'sales menu
            LEProgress.ItemIndex = LEProgress.Properties.GetDataSourceRowIndex("id_ol_store_oos_stt", "3")
            viewData()
        End If
    End Sub

    Private Sub FormOLStoreOOS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCData, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim ooslist As New ClassOLStore()
        Dim id_type As String = LEType.EditValue.ToString
        Dim cond As String = ""
        If id_type <> "0" Then
            If id_type = "1" Then
                cond = "AND os.is_closed=2 "
            Else
                cond = "AND os.is_closed=1 "
            End If
        Else
            cond = ""
        End If
        Dim id_ol_store_oos_stt As String = LEProgress.EditValue.ToString
        If id_ol_store_oos_stt <> "0" Then
            cond += "AND os.id_ol_store_oos_stt='" + id_ol_store_oos_stt + "' "
        End If
        Dim data As DataTable = ooslist.viewListOOS(cond)
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewType()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_type`,'All' AS `type`
        UNION ALL
        SELECT 1 AS `id_type`,'Open' AS `type`
        UNION ALL
        SELECT 2 AS `id_type`,'Close' AS `type` "
        viewLookupQuery(LEType, query, 0, "type", "id_type")
        Cursor = Cursors.Default
    End Sub

    Sub viewProgress()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_ol_store_oos_stt`, 'All' AS `ol_store_oos_stt`
        UNION ALL
        SELECT s.id_ol_store_oos_stt, s.ol_store_oos_stt FROM tb_ol_store_oos_stt s  WHERE s.id_ol_store_oos_stt<=5 "
        viewLookupQuery(LEProgress, query, 0, "ol_store_oos_stt", "id_ol_store_oos_stt")
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormOLStoreOOSDetail.id = GVData.GetFocusedRowCellValue("id_ol_store_oos").ToString
            FormOLStoreOOSDetail.id_type = id_type
            FormOLStoreOOSDetail.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub
End Class