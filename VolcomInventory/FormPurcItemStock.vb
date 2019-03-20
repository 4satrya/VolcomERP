Public Class FormPurcItemStock
    Private Sub FormPurcItemStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each t As DevExpress.XtraTab.XtraTabPage In XTCStock.TabPages
            XTCStock.SelectedTabPage = t
        Next t
        XTCStock.SelectedTabPage = XTCStock.TabPages(0)

        Dim dt As DateTime = getTimeDB()
        DESOHUntil.EditValue = dt
        DEFromSC.EditValue = dt
        DEUntilSC.EditValue = dt
        viewItem()
        viewDept()
        viewCat()
        DESOHUntil.EditValue = getTimeDB()
    End Sub

    Sub viewItem()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT i.id_item, i.item_desc, cat.id_item_cat, cat.item_cat 
        FROM tb_item i
        INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat 
        ORDER BY i.item_desc ASC "
        viewSearchLookupQuery(SLEITem, query, "id_item", "item_desc", "id_item")
        Cursor = Cursors.Default
    End Sub

    Sub viewDept()
        Cursor = Cursors.WaitCursor
        Dim query_all As String = queryDept(True)

        viewLookupQuery(LEDeptSum, query_all, 0, "departement", "id_departement")
        viewLookupQuery(LEDeptSC, query_all, 0, "departement", "id_departement")
        Cursor = Cursors.Default
    End Sub

    Function queryDept(ByVal include_all As Boolean) As String
        Dim query As String = ""
        If include_all Then
            query += "SELECT 0 as id_departement, 'All departement' as departement UNION  "
        End If
        query += "(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        Return query
    End Function

    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_item_cat`, 'All Category' AS `item_cat`
        UNION ALL
        SELECT c.id_item_cat, c.item_cat FROM tb_item_cat c ORDER BY id_item_cat ASC"
        viewLookupQuery(LECat, query, 0, "item_cat", "id_item_cat")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPurcItemStock_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormPurcItemStock_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_until_selected = DateTime.Parse(DESOHUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim dept As String = LEDeptSum.EditValue.ToString
        If dept <> "0" Then
            dept = "AND i.id_departement=" + dept + ""
        Else
            dept = ""
        End If

        Dim stc As New ClassPurcItemStock()
        Dim query As String = stc.queryGetStock(dept, date_until_selected)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOH.DataSource = data
        GVSOH.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewSC_Click(sender As Object, e As EventArgs) Handles BtnViewSC.Click
        viewStockCard()
    End Sub

    Sub viewStockCard()
        Cursor = Cursors.WaitCursor
        Dim date_from_selected As String = "1997-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromSC.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_until_selected = DateTime.Parse(DEUntilSC.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim id_dept As String = LEDeptSC.EditValue.ToString
        Dim id_item As String = SLEITem.EditValue.ToString

        Dim query As String = "CALL view_stock_card_item(" + id_dept + ", " + id_item + ", '" + date_from_selected + "', '" + date_until_selected + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSC.DataSource = data
        GVSC.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub ViewDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDocumentToolStripMenuItem.Click
        If GVSC.RowCount > 0 And GVSC.FocusedRowHandle >= 0 Then
            Dim rmt As String = GVSC.GetFocusedRowCellValue("report_mark_type").ToString
            Dim id_report As String = GVSC.GetFocusedRowCellValue("id_report").ToString
            Dim s As New ClassShowPopUp
            s.id_report = id_report
            s.report_mark_type = rmt
            s.show()
        End If
    End Sub
End Class