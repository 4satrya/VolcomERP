Public Class FormAccountingFKDetail
    Public id As String = "-1"

    Private Sub FormAccountingFKDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewHeader()
    End Sub

    Sub viewHeader()
        Cursor = Cursors.WaitCursor
        Dim query As String = FormAccountingFakturScan.viewHeader("AND (" + id + ") ")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCHeader.DataSource = data
        GVHeader.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewFK()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 
        -2 AS col0, ('FK') AS col1, ('KD_JENIS_TRANSAKSI') AS col2, ('FG_PENGGANTI') AS col3, ('NOMOR_FAKTUR') AS col4, ('MASA_PAJAK') AS col5, ('TAHUN_PAJAK') AS col6, 
        ('TANGGAL_FAKTUR') AS col7, ('NPWP') AS col8, ('NAMA') AS col9, ('ALAMAT_LENGKAP') AS col10, ('JUMLAH_DPP') AS col11, 
        ('JUMLAH_PPN') AS col12, ('JUMLAH_PPNBM') AS col13, ('ID_KETERANGAN_TAMBAHAN') AS col14, ('FG_UANG_MUKA') AS col15, ('UANG_MUKA_DPP') AS col16, ('UANG_MUKA_PPN') AS col17, 
        ('UANG_MUKA_PPNBM') AS col18, ('REFERENSI') AS col19 
        UNION ALL 
        SELECT  
        -1 AS col0, ('LT') AS col1, ('NPWP') AS col2, ('NAMA') AS col3, ('JALAN') AS col4, ('BLOK') AS col5, ('NOMOR') AS col6, 
        ('RT') AS col7, ('RW') AS col8, ('KECAMATAN') AS col9, ('KELURAHAN') AS col10, ('KABUPATEN') AS col11, 
        ('PROPINSI') AS col12, ('KODE_POS') AS col13, ('NOMOR_TELEPON') AS col14, ('') AS col15, ('') AS col16, ('') AS col17, 
        ('') AS col18, ('') AS col19 
        UNION ALL 
        SELECT  
        0 AS col0, ('OF') AS col1, ('KODE_OBJEK') AS col2, ('NAMA') AS col3, ('HARGA_SATUAN') AS col4, ('JUMLAH_BARANG') AS col5, ('HARGA_TOTAL') AS col6, 
        ('DISKON') AS col7, ('DPP') AS col8, ('PPN') AS col9, ('TARIF_PPNBM') AS col10, ('PPNBM') AS col11, 
        ('') AS col12, ('') AS col13, ('') AS col14, ('') AS col15, ('') AS col16, ('') AS col17, 
        ('') AS col18, ('') AS col19 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFK.DataSource = data
        GVFK.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormAccountingFKDetail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        makeSafeGV(GVHeader)
        GVHeader.ActiveFilterString = "IsNullOrEmpty([no_faktur]) OR [no_faktur]='' OR [npwp]='' "
        If GVHeader.RowCount > 0 Then
            makeSafeGV(GVHeader)
            stopCustom("All fields are required")
            Exit Sub
        End If

        makeSafeGV(GVHeader)
        For i As Integer = 0 To GVHeader.RowCount - 1
            Cursor = Cursors.WaitCursor
            Dim id_faktur As String = GVHeader.GetRowCellValue(i, "id_sales_pos_faktur").ToString
            Dim id_sales_pos As String = GVHeader.GetRowCellValue(i, "id_sales_pos").ToString
            Dim no_faktur As String = addSlashes(GVHeader.GetRowCellValue(i, "no_faktur").ToString)
            Dim npwp As String = addSlashes(GVHeader.GetRowCellValue(i, "npwp").ToString)
            Dim npwp_name As String = addSlashes(GVHeader.GetRowCellValue(i, "npwp_name").ToString)
            Dim npwp_address As String = addSlashes(GVHeader.GetRowCellValue(i, "npwp_address").ToString)

            Dim query As String = ""
            If id_faktur = "0" Then 'new
                query = "INSERT INTO tb_sales_pos_faktur(id_sales_pos, no_faktur, npwp, npwp_name, npwp_address, updated_at, updated_by) 
                VALUES('" + id_sales_pos + "', '" + no_faktur + "', '" + npwp + "', '" + npwp_name + "', '" + npwp_address + "', NOW(), '" + id_user + "'); "
                execute_non_query(query, True, "", "", "", "")
            Else
                query = "UPDATE tb_sales_pos_faktur SET no_faktur='" + no_faktur + "', npwp='" + npwp + "', npwp_name='" + npwp_name + "',
                npwp_address='" + npwp_address + "', updated_at=NOW(), updated_by=" + id_user + " 
                WHERE id_sales_pos_faktur='" + id_faktur + "' "
                execute_non_query(query, True, "", "", "", "")
            End If
            Cursor = Cursors.Default
        Next
        XTPExportedCSV.PageEnabled = True
        XTCFKDetail.SelectedTabPageIndex = 1
        XTPNoFaktur.PageEnabled = False
    End Sub

    Private Sub XTCFKDetail_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCFKDetail.SelectedPageChanged
        If XTCFKDetail.SelectedTabPageIndex = 0 Then
            viewHeader()
        Else
            viewFK()
        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnPrev_Click(sender As Object, e As EventArgs) Handles BtnPrev.Click
        XTPNoFaktur.PageEnabled = True
        XTCFKDetail.SelectedTabPageIndex = 0
        XTPExportedCSV.PageEnabled = False
    End Sub
End Class