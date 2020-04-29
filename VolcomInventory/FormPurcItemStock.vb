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
        view_storage()
        viewItem()
        viewDept()
        viewCat()
        DESOHUntil.EditValue = getTimeDB()
        '
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
    End Sub

    Sub view_storage()
        Dim q As String = "SELECT 0 as id_comp,'-' AS comp_number,'All Storage' as comp_name
UNION
SELECT id_comp,comp_number,comp_name FROM tb_m_comp WHERE id_comp_cat='9'"
        viewSearchLookupQuery(SLEStorage, q, "id_comp", "comp_name", "id_comp")
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
        viewLookupQuery(LECatPemakaian, query, 0, "item_cat", "id_item_cat")
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

        Dim cond As String = ""

        Dim dept As String = LEDeptSum.EditValue.ToString
        Dim cat As String = LECat.EditValue.ToString
        '
        If dept <> "0" Then
            cond += "AND i.id_departement=" + dept + ""
        Else
            cond += ""
        End If

        If Not SLEStorage.EditValue.ToString = "0" Then
            cond += "AND i.id_comp=" + SLEStorage.EditValue.ToString + ""
        End If

        Dim stc As New ClassPurcItemStock()
        Dim query As String = stc.queryGetStock(cond, cat, date_until_selected)
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

        Dim query As String = "CALL view_stock_card_item(" + id_dept + ", " + id_item + ", '" + date_from_selected + "', '" + date_until_selected + "','')"
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

    Private Sub BStockFisik_Click(sender As Object, e As EventArgs) Handles BStockFisik.Click
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_until_selected = DateTime.Parse(DESOHUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim dept As String = LEDeptSum.EditValue.ToString
        Dim cat As String = LECat.EditValue.ToString

        If dept <> "0" Then
            dept = "AND i.id_departement=" + dept + ""
        Else
            dept = ""
        End If

        Dim stc As New ClassPurcItemStock()
        stc.opt = "fisik"
        Dim query As String = stc.queryGetStock(dept, cat, date_until_selected)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOH.DataSource = data
        GVSOH.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BStockCardFisik_Click(sender As Object, e As EventArgs) Handles BStockCardFisik.Click
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

        Dim query As String = "CALL view_stock_card_item(" + id_dept + ", " + id_item + ", '" + date_from_selected + "', '" + date_until_selected + "','fisik')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSC.DataSource = data
        GVSC.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        DEUntil.Properties.MinValue = DEStart.EditValue
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_pemakaian()
    End Sub

    Sub load_pemakaian()
        Dim date_start As String = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_until As String = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim cat As String = ""

        If Not LECatPemakaian.EditValue.ToString = "0" Then
            cat = " AND it.id_item_cat='" & LECatPemakaian.EditValue.ToString & "'"
        End If

        Dim q As String = "SELECT it.`id_item`,it.`item_desc`,uom.uom
,IFNULL(beg.qty_beg,0) AS qty_beg,IFNULL(beg.harga_satuan_beg,0) AS harga_satuan_beg,IFNULL(beg.amount_beg,0) AS amount_beg
,IFNULL(rec.qty_rec,0) AS qty_rec,IFNULL(rec.harga_satuan_rec,0) AS harga_satuan_rec,IFNULL(rec.amount_rec,0) AS amount_rec
,IFNULL(used.qty_used,0) AS qty_used,IFNULL(used.harga_satuan_used,0) AS harga_satuan_used,IFNULL(used.amount_used,0) AS amount_used
,IFNULL(rem.qty_rem,0) AS qty_rem,IFNULL(rem.harga_satuan_rem,0) AS harga_satuan_rem,IFNULL(rem.amount_rem,0) AS amount_rem
FROM tb_item it
INNER JOIN tb_m_uom uom ON uom.id_uom=it.id_uom_stock " & cat & "
LEFT JOIN (
	SELECT id_item,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS qty_beg
	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`)/SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS harga_satuan_beg
	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`) AS amount_beg
	FROM `tb_storage_item`
	WHERE DATE(storage_item_datetime)<'" & date_start & "'
	GROUP BY id_item
	HAVING qty_beg!=0
)beg ON beg.id_item=it.id_item
LEFT JOIN (
	SELECT id_item,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS qty_rec
	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`)/SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS harga_satuan_rec
	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`) AS amount_rec
	FROM `tb_storage_item`
	WHERE DATE(storage_item_datetime)>='" & date_start & "' AND DATE(storage_item_datetime)<='" & date_until & "' AND report_mark_type='148'
	GROUP BY id_item
	HAVING qty_rec!=0
)rec ON rec.id_item=it.id_item
LEFT JOIN (
	SELECT id_item,SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)) AS qty_used
	,SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)*`value`)/SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)) AS harga_satuan_used
	,SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)*`value`) AS amount_used
	FROM `tb_storage_item`
	WHERE DATE(storage_item_datetime)>='" & date_start & "' AND DATE(storage_item_datetime)<='" & date_until & "' AND NOT report_mark_type='148'
	GROUP BY id_item
	HAVING qty_used!=0
)used ON used.id_item=it.id_item
LEFT JOIN (
	SELECT id_item,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS qty_rem
	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`)/SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS harga_satuan_rem
	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`) AS amount_rem
	FROM `tb_storage_item`
	WHERE DATE(storage_item_datetime)<='" & date_until & "'
	GROUP BY id_item
	HAVING qty_rem!=0
)rem ON rem.id_item=it.id_item
WHERE NOT ISNULL(beg.id_item) OR NOT ISNULL(rec.id_item) OR NOT ISNULL(used.id_item) OR NOT ISNULL(rem.id_item)"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPemakaian.DataSource = dt
        GVPemakaian.BestFitColumns()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        print(GCPemakaian, "Report Pemakaian")
    End Sub
End Class