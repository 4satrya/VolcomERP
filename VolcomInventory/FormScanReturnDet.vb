Public Class FormScanReturnDet
    Public id_scan_return As String = "-1"
    Public id_return_note As String = "-1"
    Dim dt_product As DataTable
    Dim dt_unique As DataTable
    '
    Public is_ok As Boolean = False
    '
    Private Sub FormScanReturnDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormScanReturnDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not id_scan_return = "-1" Then
            Dim q As String = "SELECT sr.is_lock,sr.id_return_note,rn.label_number,rn.`number_return_note`,rn.qty,GROUP_CONCAT(DISTINCT(CONCAT(cst.`comp_number`,' - ',cst.comp_name)) ORDER BY cst.`comp_number` SEPARATOR '\n') AS list_store
FROM tb_scan_return sr 
INNER JOIN tb_return_note rn ON rn.id_return_note=sr.id_return_note
LEFT JOIN tb_return_note_store st ON st.`id_return_note`=rn.`id_return_note`
LEFT JOIN tb_m_comp cst ON cst.`id_comp`=st.`id_comp`
WHERE sr.id_scan_return='" & id_scan_return & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TEReturnNote.Text = dt.Rows(0)("number_return_note").ToString
                TEReturnLabel.Text = dt.Rows(0)("label_number").ToString
                TEQty.EditValue = dt.Rows(0)("qty").ToString
                MEListStore.Text = dt.Rows(0)("list_store").ToString
                id_return_note = dt.Rows(0)("id_return_note").ToString
                If dt.Rows(0)("is_lock").ToString = "1" Then
                    PCAddDel.Visible = False
                    PCButton.Visible = False
                End If
            End If
            TEReturnLabel.Enabled = False
            BReset.Visible = False
        End If

        load_det()
        load_product()
    End Sub

    Sub load_product()
        Dim q As String = "SELECT prd.id_product,prd.product_full_code,prd.product_display_name,pc.size
FROM tb_m_product prd
LEFT JOIN 
(
	SELECT pc.id_product,cd.`code_detail_name` AS size
	FROM tb_m_product_code pc 
	INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail`
	GROUP BY pc.`id_product`
)pc ON pc.id_product=prd.`id_product`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=prd.`id_design`
WHERE dsg.`id_lookup_status_order`!=2"
        dt_product = execute_query(q, -1, True, "", "", "", "")
        'karena produk bisa bolak balik return
        '        q = "SELECT scanned_code FROM 
        '`tb_scan_return_det` srd
        'INNER JOIN tb_scan_return sr ON sr.id_scan_return=srd.id_scan_return AND sr.id_report_status!=5"
        '        dt_unique = execute_query(q, -1, True, "", "", "", "")
    End Sub

    Sub load_det()
        Dim q As String = "SELECT scd.id_scan_return_det,scd.id_product,prd.product_full_code,prd.product_display_name,pc.size,scd.`type`,IF(scd.`type`=1,'Ok',IF(scd.`type`=2,'No Tag','Unique Duplicate')) AS notes 
FROM `tb_scan_return_det` scd
INNER JOIN tb_m_product prd ON prd.id_product=scd.id_product
LEFT JOIN 
(
	SELECT pc.id_product,cd.`code_detail_name` AS size
	FROM tb_m_product_code pc 
	INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail`
	GROUP BY pc.`id_product`
)pc ON pc.id_product=prd.`id_product`
WHERE scd.id_scan_return='" & id_scan_return & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCListProduct.DataSource = dt
        GVListProduct.BestFitColumns()
    End Sub

    Private Sub TEReturnLabel_KeyDown(sender As Object, e As KeyEventArgs) Handles TEReturnLabel.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim q As String = "SELECT rn.*,st_list.store FROM `tb_return_note` rn
LEFT JOIN
(
    SELECT st.`id_return_note`,GROUP_CONCAT(DISTINCT CONCAT(c.comp_number,' - ',c.comp_name) ORDER BY c.`comp_number` ASC SEPARATOR '\r\n') AS store
    FROM `tb_return_note_store` st
    INNER JOIN tb_m_comp c ON c.id_comp=st.id_comp
    GROUP BY st.`id_return_note`
)st_list ON st_list.id_return_note=rn.id_return_note
WHERE rn.label_number='" & addSlashes(TEReturnLabel.Text) & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                id_return_note = dt.Rows(0)("id_return_note").ToString
                TEQty.EditValue = dt.Rows(0)("qty")
                MEListStore.Text = dt.Rows(0)("store").ToString
                TEReturnLabel.Enabled = False
                TEReturnNote.Text = dt.Rows(0)("number_return_note").ToString
                TEScan.Focus()
            End If
        End If
    End Sub

    Private Sub TEScan_KeyDown(sender As Object, e As KeyEventArgs) Handles TEScan.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor

            If Not TEScan.Text = "" And TEScan.Text.Length >= 12 Then
                Dim code_check As String = TEScan.Text.Substring(0, 12)
                Dim code_found As Boolean = False
                Dim unique_duplicate As Boolean = False
                '
                Dim id_product As String = ""
                Dim product_name As String = ""
                Dim product_full_code As String = ""
                Dim size As String = ""

                'check available code
                Dim dt_filter As DataRow() = dt_product.Select("[product_full_code]='" + code_check + "' ")
                If dt_filter.Length > 0 Then
                    id_product = dt_filter(0)("id_product").ToString
                    product_name = dt_filter(0)("product_display_name").ToString
                    product_full_code = dt_filter(0)("product_full_code").ToString
                    size = dt_filter(0)("size").ToString
                    code_found = True
                End If

                'check duplicate unique
                If TEScan.Text.Length = 16 Then
                    For i As Integer = 0 To GVListProduct.RowCount - 1
                        If GVListProduct.GetRowCellValue(i, "product_full_code").ToString = TEScan.Text Then
                            unique_duplicate = True
                            Exit For
                        End If
                    Next
                End If

                'tidak dipakai karena produk bisa bolak balik return
                'If TEScan.Text.Length = 16 Then
                '    Dim dt_unique_filter As DataRow() = dt_unique.Select("[scanned_code]='" + TEScan.Text + "' ")
                '    If dt_unique_filter.Length > 0 Then
                '        unique_duplicate = True
                '    Else

                '    End If
                'End If

                If Not code_found Then
                    stopCustomDialog("Data not found !")
                Else
                    GVListProduct.AddNewRow()
                    GCListProduct.RefreshDataSource()
                    GVListProduct.RefreshData()
                    GVListProduct.FocusedRowHandle = GVListProduct.RowCount - 1
                    '
                    If unique_duplicate Then
                        GVListProduct.SetRowCellValue(GVListProduct.RowCount - 1, "type", "3")
                        GVListProduct.SetRowCellValue(GVListProduct.RowCount - 1, "notes", "Unique duplicate")
                    Else
                        GVListProduct.SetRowCellValue(GVListProduct.RowCount - 1, "type", "1")
                        GVListProduct.SetRowCellValue(GVListProduct.RowCount - 1, "notes", "Ok")
                    End If

                    GVListProduct.SetRowCellValue(GVListProduct.RowCount - 1, "id_product", id_product)
                    GVListProduct.SetRowCellValue(GVListProduct.RowCount - 1, "product_full_code", TEScan.Text)
                    GVListProduct.SetRowCellValue(GVListProduct.RowCount - 1, "product_display_name", product_name)
                    GVListProduct.SetRowCellValue(GVListProduct.RowCount - 1, "size", size)
                    '
                    GVListProduct.RefreshData()
                End If
            Else
                stopCustomDialog("Code too short")
            End If

            TEScan.Text = ""
            TEScan.Focus()

            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BReset_Click(sender As Object, e As EventArgs) Handles BReset.Click
        id_return_note = "-1"
        TEQty.EditValue = 0
        MEListStore.Text = ""
        TEReturnLabel.Text = ""
        TEReturnLabel.Enabled = True
    End Sub

    Private Sub BDeleteScan_Click(sender As Object, e As EventArgs) Handles BDeleteScan.Click
        If GVListProduct.RowCount > 0 Then
            GVListProduct.DeleteSelectedRows()
            TEScan.Text = ""
            TEScan.Focus()
        End If
    End Sub

    Private Sub BInputManual_Click(sender As Object, e As EventArgs) Handles BInputManual.Click
        FormScanReturnDetManual.ShowDialog()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        'check first
        If id_return_note = "-1" Then
            warningCustom("Please put the return note.")
        ElseIf GVListProduct.RowCount = 0 Then
            warningCustom("Please scan first")
        Else
            is_ok = False

            'If Not GVListProduct.Columns("size").SummaryItem.SummaryValue = TEQty.EditValue Then
            '    Dim confirm As DialogResult
            '    confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Qty Return note vs Qty Scan not match, continue save ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            '    If confirm = Windows.Forms.DialogResult.Yes Then
            '        is_ok = True
            '    Else
            '        is_ok = False
            '    End If
            'End If

            FormScanReturnConfirm.ShowDialog()

            If is_ok Then
                'save
                If id_scan_return = "-1" Then
                    'new
                    Dim q As String = "INSERT INTO tb_scan_return(id_return_note,created_date,created_by) VALUES('" & id_return_note & "',NOW(),'" & id_user & "'); SELECT LAST_INSERT_ID();"
                    id_scan_return = execute_query(q, 0, True, "", "", "", "")
                    '
                    q = "INSERT INTO `tb_scan_return_det`(`id_scan_return`,`id_product`,`scanned_code`,`size`,`type`) VALUES"
                    For i = 0 To GVListProduct.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id_scan_return & "','" & GVListProduct.GetRowCellValue(i, "id_product").ToString & "','" & GVListProduct.GetRowCellValue(i, "product_full_code").ToString & "','" & GVListProduct.GetRowCellValue(i, "size").ToString & "','" & GVListProduct.GetRowCellValue(i, "type").ToString & "')"
                    Next
                    execute_non_query(q, True, "", "", "", "")
                    infoCustom("Scan saved.")
                    Close()
                Else
                    'update
                    Dim q As String = "DELETE FROM tb_scan_return_det WHERE id_scan_return='" & id_scan_return & "'"
                    execute_non_query(q, True, "", "", "", "")
                    '
                    q = "INSERT INTO `tb_scan_return_det`(`id_scan_return`,`id_product`,`scanned_code`,`size`,`type`) VALUES"
                    For i = 0 To GVListProduct.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id_scan_return & "','" & GVListProduct.GetRowCellValue(i, "id_product").ToString & "','" & GVListProduct.GetRowCellValue(i, "product_full_code").ToString & "','" & GVListProduct.GetRowCellValue(i, "size").ToString & "','" & GVListProduct.GetRowCellValue(i, "type").ToString & "')"
                    Next
                    execute_non_query(q, True, "", "", "", "")
                    infoCustom("Scan updated.")
                    Close()
                End If
            Else
                Close()
            End If
        End If
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub BResetScan_Click(sender As Object, e As EventArgs) Handles BResetScan.Click
        For i = GVListProduct.RowCount - 1 To 0 Step -1
            GVListProduct.DeleteRow(i)
        Next
    End Sub
End Class