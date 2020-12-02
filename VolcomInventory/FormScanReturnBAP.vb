Public Class FormScanReturnBAP
    Public id_bap As String = "-1"
    Private Sub FormScanReturnBAP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEBAP.EditValue = Now
        load_type()
        load_3pl()
        load_surat_jalan()
        '
        If Not id_bap = "-1" Then
            Dim q As String = "SELECT bap_number,`bap_date`,`is_lubang`,`is_seal_rusak`,`is_basah`,`is_other_cond`,`other_cond`,id_3pl,is_lock FROM tb_scan_return_bap WHERE id_scan_return_bap='" & id_bap & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TEBAPNumber.Text = dt.Rows(0)("bap_number").ToString
                TEAlasanLain.Text = dt.Rows(0)("other_cond").ToString
                If dt.Rows(0)("is_lubang").ToString = "1" Then
                    CELubang.Checked = True
                Else
                    CELubang.Checked = False
                End If
                If dt.Rows(0)("is_seal_rusak").ToString = "1" Then
                    CELakbanRusak.Checked = True
                Else
                    CELakbanRusak.Checked = False
                End If
                If dt.Rows(0)("is_basah").ToString = "1" Then
                    CEBasah.Checked = True
                Else
                    CEBasah.Checked = False
                End If
                If dt.Rows(0)("is_other_cond").ToString = "1" Then
                    CEAlasanLain.Checked = True
                Else
                    CEAlasanLain.Checked = False
                End If
                SLEVendor.EditValue = dt.Rows(0)("id_3pl").ToString
                '
                If dt.Rows(0)("is_lock").ToString = "1" Then
                    BSave.Visible = False
                Else
                    BSave.Visible = True
                End If
            End If
        End If
        '
        load_det()
        check_but()
    End Sub

    Sub load_3pl()
        Dim q As String = "SELECT 0 AS id_comp,'WAREHOUSE' AS comp_number,'WAREHOUSE' AS comp_name
UNION ALL
SELECT c.id_comp,c.comp_number,c.comp_name
FROM tb_3pl_rate rate
INNER JOIN tb_lookup_del_type del ON del.id_del_type=rate.id_del_type AND del.is_able_inbound=1
INNER JOIN tb_m_comp c ON c.id_comp=rate.id_comp
WHERE rate.id_type='2' AND rate.is_active='1'
GROUP BY rate.id_comp"
        viewSearchLookupQuery(SLEVendor, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub BDeleteScan_Click(sender As Object, e As EventArgs) Handles BDeleteScan.Click
        If GVListProduct.RowCount > 0 Then
            GVListProduct.DeleteSelectedRows()
        End If
    End Sub

    Sub load_det()
        Dim q As String = "SELECT id_type,id_return_note,id_product,`code`,description,size,qty,note
FROM tb_scan_return_bap_det WHERE id_scan_return_bap='" & id_bap & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCListProduct.DataSource = dt
        GVListProduct.BestFitColumns()
    End Sub

    Sub load_surat_jalan()
        Dim q_where As String = ""

        If SLEVendor.EditValue.ToString = "0" Then
            q_where = " AND rn.id_type='1'"
        Else
            q_where = " AND awb.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim q As String = "SELECT rn.`id_return_note`,rn.`label_number`,rn.`number_return_note`,rn.`qty`,IFNULL(sc.qty_scan,0) AS qty_scan
FROM tb_return_note rn
LEFT JOIN tb_inbound_awb awb ON awb.id_inbound_awb=rn.id_inbound_awb
INNER JOIN
(
	SELECT st.`id_return_note`,GROUP_CONCAT(DISTINCT CONCAT(c.comp_number,' - ',c.comp_name) ORDER BY c.`comp_number` ASC SEPARATOR '\n') AS store
	FROM `tb_return_note_store` st
	INNER JOIN tb_m_comp c ON c.id_comp=st.id_comp
	GROUP BY st.`id_return_note`
)store ON store.id_return_note=rn.`id_return_note`
LEFT JOIN
(
	SELECT sc.id_return_note,sc.id_scan_return,COUNT(scd.id_scan_return_det) AS qty_scan
	FROM `tb_scan_return_det` scd
	INNER JOIN tb_scan_return sc ON sc.id_scan_return=scd.id_scan_return
	WHERE sc.is_void=2
	GROUP BY sc.id_scan_return
)sc ON sc.id_return_note=rn.`id_return_note`
WHERE rn.`is_lock`=2 AND rn.`is_void`=2 " & q_where
        viewSearchLookupRepositoryQuery(RISLEReturnNote, q, 0, "number_return_note", "id_return_note")
    End Sub

    Sub load_type()
        Dim q As String = "SELECT '1' AS id_type,'Missing' AS `type`
UNION ALL
SELECT '2' AS id_type,'Over' AS `type`"
        viewSearchLookupRepositoryQuery(RISLEType, q, 0, "type", "id_type")
    End Sub

    Private Sub FormScanReturnBAP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim is_ok As Boolean = True

        'check
        For i As Integer = 0 To GVListProduct.RowCount - 1
            If GVListProduct.GetRowCellValue(i, "id_type").ToString = "" Or GVListProduct.GetRowCellValue(i, "code").ToString = "" Or GVListProduct.GetRowCellValue(i, "description").ToString = "" Or GVListProduct.GetRowCellValue(i, "size").ToString = "" Or GVListProduct.GetRowCellValue(i, "qty") <= 0 Or GVListProduct.GetRowCellValue(i, "id_return_note").ToString = "" Then
                warningCustom("Please complete your list")
                is_ok = False
                Exit For
            End If
        Next

        If is_ok Then
            If GVListProduct.RowCount <= 0 Then
                warningCustom("Please input on list")
            Else
                If id_bap = "-1" Then 'new
                    Dim q As String = "INSERT `tb_scan_return_bap`(`bap_date`,`is_lubang`,`is_seal_rusak`,`is_basah`,`is_other_cond`,`other_cond`,`created_date`,`created_by`,`update_date`,`update_by`,`id_3pl`)
VALUES('" & Date.Parse(DEBAP.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & If(CELubang.Checked = True, "1", "2") & "','" & If(CELakbanRusak.Checked = True, "1", "2") & "','" & If(CEBasah.Checked = True, "1", "2") & "','" & If(CEAlasanLain.Checked = True, "1", "2") & "','" & addSlashes(TEAlasanLain.Text) & "',NOW(),'" & id_user & "',NOW(),'" & id_user & "','" & SLEVendor.EditValue.ToString & "');SELECT LAST_INSERT_ID();"
                    id_bap = execute_query(q, 0, True, "", "", "", "")
                    'gen number
                    q = "CALL gen_bap_scan_return(" & id_bap & ")"
                    execute_non_query(q, True, "", "", "", "")
                    'detail
                    q = "INSERT INTO tb_scan_return_bap_det(`id_scan_return_bap`,`id_return_note`,`id_type`,`id_product`,`code`,`description`,`size`,`qty`,`note`)
VALUES"
                    For i As Integer = 0 To GVListProduct.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id_bap & "','" & GVListProduct.GetRowCellValue(i, "id_return_note").ToString & "','" & GVListProduct.GetRowCellValue(i, "id_type").ToString & "','" & GVListProduct.GetRowCellValue(i, "id_product").ToString & "','" & addSlashes(GVListProduct.GetRowCellValue(i, "code").ToString) & "','" & addSlashes(GVListProduct.GetRowCellValue(i, "description").ToString) & "','" & GVListProduct.GetRowCellValue(i, "size").ToString & "','" & decimalSQL(Decimal.Parse(GVListProduct.GetRowCellValue(i, "qty").ToString).ToString) & "','" & addSlashes(GVListProduct.GetRowCellValue(i, "note").ToString) & "')"
                    Next
                    execute_non_query(q, True, "", "", "", "")
                    '
                    infoCustom("BAP created")
                Else 'edit
                    Dim q As String = ""
                    q = "UPDATE `tb_scan_return_bap` SET `bap_date`='" & Date.Parse(DEBAP.EditValue.ToString).ToString("yyyy-MM-dd") & "',`is_lubang`='" & If(CELubang.Checked = True, "1", "2") & "'
,`is_seal_rusak`='" & If(CELakbanRusak.Checked = True, "1", "2") & "',`is_basah`='" & If(CEBasah.Checked = True, "1", "2") & "',`is_other_cond`='" & If(CEAlasanLain.Checked = True, "1", "2") & "',`other_cond`='" & addSlashes(TEAlasanLain.Text) & "',`update_date`=NOW(),`update_by`='" & id_user & "',id_3pl='" & SLEVendor.EditValue.ToString & "' WHERE id_scan_return_bap='" & id_bap & "'"
                    execute_non_query(q, True, "", "", "", "")
                    'detail
                    q = "DELETE FROM tb_scan_return_bap_det WHERE id_scan_return_bap='" & id_bap & "'"
                    execute_non_query(q, True, "", "", "", "")
                    q = "INSERT INTO tb_scan_return_bap_det(`id_scan_return_bap`,`id_return_note`,`id_type`,`id_product`,`code`,`description`,`size`,`qty`,`note`)
VALUES"
                    For i As Integer = 0 To GVListProduct.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id_bap & "','" & GVListProduct.GetRowCellValue(i, "id_return_note").ToString & "','" & GVListProduct.GetRowCellValue(i, "id_type").ToString & "','" & GVListProduct.GetRowCellValue(i, "id_product").ToString & "','" & addSlashes(GVListProduct.GetRowCellValue(i, "code").ToString) & "','" & addSlashes(GVListProduct.GetRowCellValue(i, "description").ToString) & "','" & GVListProduct.GetRowCellValue(i, "size").ToString & "','" & decimalSQL(Decimal.Parse(GVListProduct.GetRowCellValue(i, "qty").ToString).ToString) & "','" & addSlashes(GVListProduct.GetRowCellValue(i, "note").ToString) & "')"
                    Next
                    execute_non_query(q, True, "", "", "", "")
                    '
                    infoCustom("BAP updated")
                End If
            End If
        End If
    End Sub

    Sub check_but()
        If GVListProduct.RowCount > 0 Then
            BDeleteScan.Visible = True
        Else
            BDeleteScan.Visible = False
        End If

        If id_bap = "-1" Then
            BPrint.Visible = False
        Else
            BPrint.Visible = True
        End If
    End Sub

    Private Sub CEAlasanLain_CheckedChanged(sender As Object, e As EventArgs) Handles CEAlasanLain.CheckedChanged
        If CEAlasanLain.Checked = True Then
            TEAlasanLain.Enabled = True
        Else
            TEAlasanLain.Enabled = False
        End If
    End Sub

    Private Sub BInputManual_Click(sender As Object, e As EventArgs) Handles BInputManual.Click
        GVListProduct.AddNewRow()
        GVListProduct.FocusedRowHandle = GVListProduct.RowCount - 1
        '
        GVListProduct.SetRowCellValue(GVListProduct.RowCount - 1, "type", "1")
        GVListProduct.SetRowCellValue(GVListProduct.RowCount - 1, "id_product", "0")
        GVListProduct.SetRowCellValue(GVListProduct.RowCount - 1, "qty", 1)
        '
        FormScanReturnDet.GVListProduct.RefreshData()
        check_but()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Dim Report As New ReportScanReturnBAP()
        Dim q As String = "SELECT rn.id_return_note,rn.number_return_note,GROUP_CONCAT(DISTINCT(CONCAT(c.`comp_number`,' - ',c.`comp_name`)) ORDER BY c.`comp_number` SEPARATOR '\n' ) AS store_list
,bd.`code`,bd.description,bd.size,bd.qty,bd.note
FROM `tb_scan_return_bap_det` bd
INNER JOIN tb_return_note rn ON rn.id_return_note=bd.id_return_note
INNER JOIN tb_return_note_store st ON st.id_return_note=rn.id_return_note
INNER JOIN tb_m_comp c ON c.`id_comp`=st.id_comp
WHERE bd.id_scan_return_bap='" & id_bap & "'
GROUP BY bd.id_scan_return_bap_det
ORDER BY rn.id_return_note"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        Report.id_bap = id_bap
        Report.data_det = dt
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
    End Sub

    Private Sub FormScanReturnBAP_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then
            If GVListProduct.RowCount > 0 Then
                FormScanReturnBAPProduct.ShowDialog()
            End If
        End If
    End Sub

    Private Sub SLEVendor_EditValueChanged(sender As Object, e As EventArgs) Handles SLEVendor.EditValueChanged
        load_surat_jalan()
        empty_grid()
    End Sub

    Sub empty_grid()
        For i As Integer = GVListProduct.RowCount - 1 To 0 Step -1
            GVListProduct.DeleteRow(i)
        Next
    End Sub
End Class