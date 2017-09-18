Imports System.Xml

Public Class FormAccountingFakturScanSingle
    Public action As String = ""
    Public id_acc_fak_scan As String = "-1"
    Public id_acc_fak_scan_det_list As New List(Of String)

    Private Sub FormAccountingFakturScanSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewType()
        actionLoad()
        WindowState = FormWindowState.Maximized
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            Dim currentDate As DateTime = DateTime.Now
            TxtPeriod.Text = currentDate.Month
            TxtYear.Text = currentDate.Year
            fillFakturDate()
            GroupControl3.Enabled = False
            BtnExport.Enabled = False
            BtnPrint.Enabled = False
        Else
            BtnSave.Text = "Save Changes"
            GroupControl3.Enabled = True
            BtnExport.Enabled = True
            BtnPrint.Enabled = True
            Dim query As String = ""
            query += "Select fak.id_acc_fak_scan, fak.acc_fak_scan_date, fak.acc_fak_scan_trans_date, acc_fak_scan_faktur_date, fak.id_faktur_type, fak.acc_fak_scan_period, fak.acc_fak_scan_year "
            query += "From tb_a_acc_fak_scan fak Where fak.id_acc_fak_scan ='" + id_acc_fak_scan + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtPeriod.Text = data.Rows(0)("acc_fak_scan_period").ToString
            TxtYear.Text = data.Rows(0)("acc_fak_scan_year").ToString
            LEType.ItemIndex = LEType.Properties.GetDataSourceRowIndex("id_faktur_type", data.Rows(0)("id_faktur_type").ToString)
            DECreated.EditValue = data.Rows(0)("acc_fak_scan_date")
            TxtFakturDate.Text = data.Rows(0)("acc_fak_scan_faktur_date")
            LEType.Enabled = False
        End If
        viewDetail()
    End Sub

    Function getDay(ByVal mth As Integer, ByVal year As Integer) As String
        Dim xres As Date = DateSerial(year, mth + 1, 0)
        Return xres.ToString("dd")
    End Function

    Sub fillFakturDate()
        Dim mth As String = TxtPeriod.Text
        If mth.Length = 1 Then
            mth = "0" + mth
        End If
        TxtFakturDate.Text = getDay(Integer.Parse(TxtPeriod.Text), Integer.Parse(TxtYear.Text)) + "/" + mth + "/" + TxtYear.Text
    End Sub

    Sub viewDetail()
        id_acc_fak_scan_det_list.Clear()
        Dim query As String = ""
        If LEType.EditValue.ToString = "1" Then 'FM
            query += "Select a.id_acc_fak_scan_det, a.id_acc_fak_scan, (c.faktur_type) AS `type`, a.kd_jenis_transaksi, a.fg_pengganti, a.fg_pengganti, "
            query += "a.nomor_faktur, a.masa_pajak, a.tahun_pajak, a.tanggal_faktur, a.npwp, a.nama, a.alamat_lengkap, "
            query += "a.jumlah_dpp, a.jumlah_ppn, a.jumlah_ppnbm, a.is_creditable "
            query += "From tb_a_acc_fak_scan_det a "
            query += "INNER JOIN tb_a_acc_fak_scan b ON b.id_acc_fak_scan=a.id_acc_fak_scan "
            query += "INNER JOIN tb_lookup_faktur_type c ON c.id_faktur_type=b.id_faktur_type "
            query += "Where a.id_acc_fak_scan ='" + id_acc_fak_scan + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If action = "upd" Then
                For i As Integer = 0 To (data.Rows.Count - 1)
                    id_acc_fak_scan_det_list.Add(data.Rows(i)("id_acc_fak_scan_det").ToString)
                Next
            End If
            GCData.DataSource = data
        ElseIf LEType.EditValue.ToString = "2" Then 'FK
            query += "call view_acc_fak_scan_fk_det(" + id_acc_fak_scan + ") "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCFK.DataSource = data
        Else
            'dk/dm
            query += "SELECT "
            query += "('DM') AS `dm`, dm_det.id_acc_fak_scan_dm_det, dm_det.id_acc_fak_scan, dm_det.jenis_transaksi, "
            query += "dm_det.jenis_dokumen, dm_det.kd_jns_transaksi, dm_det.fg_pengganti, dm_det.nomor_dok_lain_ganti, dm_det.nomor_dok_lain, "
            query += "dm_det.tanggal_dok_lain, dm_det.masa_pajak, dm_det.tahun_pajak, dm_det.npwp, dm_det.nama, dm_det.alamat_lengkap, "
            query += "dm_det.jumlah_dpp, dm_det.jumlah_ppn, dm_det.jumlah_ppnbm, dm_det.keterangan "
            query += "From tb_a_acc_fak_scan_dm_det dm_det "
            query += "Where dm_det.id_acc_fak_scan ='" + id_acc_fak_scan + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If action = "upd" Then
                For i As Integer = 0 To (data.Rows.Count - 1)
                    id_acc_fak_scan_det_list.Add(data.Rows(i)("id_acc_fak_scan_dm_det").ToString)
                Next
            End If
            GCDM.DataSource = data
        End If
    End Sub

    Sub viewType()
        Dim query As String = "Select * FROM tb_lookup_faktur_type "
        viewLookupQuery(LEType, query, 0, "faktur_type", "id_faktur_type")
    End Sub

    Private Sub LEType_EditValueChanged(sender As Object, e As EventArgs) Handles LEType.EditValueChanged
        'xtp
        If LEType.EditValue.ToString = "1" Then
            XTPFM.PageVisible = True
            XTPFK.PageVisible = False
            XTPDM.PageVisible = False
            LabelFakturDate.Visible = False
            TxtFakturDate.Visible = False
        ElseIf LEType.EditValue.ToString = "2"
            XTPFM.PageVisible = False
            XTPFK.PageVisible = True
            XTPDM.PageVisible = False
            LabelFakturDate.Visible = True
            TxtFakturDate.Visible = True
        Else
            XTPFM.PageVisible = False
            XTPFK.PageVisible = False
            XTPDM.PageVisible = True
            LabelFakturDate.Visible = False
            TxtFakturDate.Visible = False
        End If

        'column caption
        GridColumnType.Caption = LEType.Text
    End Sub

    Private Sub TxtURL_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        LabelReadScan.Visible = True
        TxtURL.Visible = True
        TxtURL.Text = ""
        TxtURL.Focus()
        BtnDelete.Visible = False
        BtnStart.Visible = False
        BtnFinish.Visible = True
    End Sub

    Private Sub BtnFinish_Click(sender As Object, e As EventArgs) Handles BtnFinish.Click
        TxtURL.Text = ""
        LabelReadScan.Visible = False
        TxtURL.Visible = False
        BtnDelete.Visible = True
        BtnStart.Visible = True
        BtnFinish.Visible = False
        BtnStart.Focus()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        deleteScan()
    End Sub

    Sub deleteScan()
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want To delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            GVData.DeleteSelectedRows()
            GCData.RefreshDataSource()
            GVData.RefreshData()
        End If
    End Sub

    Private Sub TxtURL_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtURL.KeyUp
        If e.KeyCode = Keys.Enter And TxtURL.Text.Length > 0 Then
            Cursor = Cursors.WaitCursor
            Try
                Dim URLString As String = TxtURL.Text.ToString
                Dim reader As XmlTextReader = New XmlTextReader(URLString)
                Dim cond As Boolean = False
                Dim col As String = ""
                Dim i As Integer = 0
                Dim newRow As DataRow = Nothing
                Do While (reader.Read())
                    Select Case reader.NodeType
                        Case XmlNodeType.Element 'Display beginning of element.
                            If reader.Name = "kdJenisTransaksi" _
                                Or reader.Name = "fgPengganti" _
                                Or reader.Name = "nomorFaktur" _
                                Or reader.Name = "tanggalFaktur" _
                                Or reader.Name = "npwpPenjual" _
                                 Or reader.Name = "namaPenjual" _
                                Or reader.Name = "alamatPenjual" _
                                Or reader.Name = "jumlahDpp" _
                                 Or reader.Name = "jumlahPpn" _
                                Or reader.Name = "jumlahPpnBm" Then
                                col = reader.Name
                                cond = True
                            End If
                        Case XmlNodeType.Text 'Display the text in each element.
                            If cond Then
                                If i = 0 Then
                                    newRow = (TryCast(GCData.DataSource, DataTable)).NewRow()
                                    newRow("id_acc_fak_scan_det") = "0"
                                    newRow("id_acc_fak_scan") = "0"
                                    newRow("masa_pajak") = TxtPeriod.Text
                                    newRow("tahun_pajak") = TxtYear.Text
                                    newRow("is_creditable") = "1"
                                    newRow("type") = LEType.Text
                                End If


                                If col = "kdJenisTransaksi" Then
                                    newRow("kd_jenis_transaksi") = reader.Value.ToString
                                ElseIf col = "fgPengganti" Then
                                    newRow("fg_pengganti") = reader.Value.ToString
                                ElseIf col = "nomorFaktur" Then
                                    newRow("nomor_faktur") = reader.Value.ToString
                                ElseIf col = "tanggalFaktur" Then
                                    newRow("tanggal_faktur") = reader.Value.ToString
                                ElseIf col = "npwpPenjual" Then
                                    newRow("npwp") = reader.Value.ToString
                                ElseIf col = "namaPenjual" Then
                                    newRow("nama") = reader.Value.ToString
                                ElseIf col = "alamatPenjual" Then
                                    newRow("alamat_lengkap") = reader.Value.ToString
                                ElseIf col = "jumlahDpp" Then
                                    newRow("jumlah_dpp") = reader.Value.ToString
                                ElseIf col = "jumlahPpn" Then
                                    newRow("jumlah_ppn") = reader.Value.ToString
                                ElseIf col = "jumlahPpnBm" Then
                                    newRow("jumlah_ppnbm") = reader.Value.ToString
                                End If
                                'Console.WriteLine(reader.Value)
                                cond = False
                                i += 1
                            End If
                    End Select
                Loop
                If i > 0 Then
                    TryCast(GCData.DataSource, DataTable).Rows.Add(newRow)
                    GCData.RefreshDataSource()
                    GVData.RefreshData()
                End If
            Catch ex As Exception
                errorProcess()
            End Try
            Cursor = Cursors.Default
            TxtURL.Text = ""
        End If
    End Sub

    Function convert_decimal(ByVal number_string As String) As Decimal
        'example use : Console.WriteLine((convert_decimal("19999.1") + 0.9).ToString)
        Dim DecimalSeparator As String = String.Format(1.1).Substring(1, 1)

        If DecimalSeparator = "," Then
            number_string = number_string.Replace(".", DecimalSeparator)
        Else
            number_string = number_string.Replace(",", DecimalSeparator)
        End If

        Return Decimal.Parse(number_string)
    End Function

    Private Sub FormAccountingFakturScanSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        Dim printableComponentLink1 As New DevExpress.XtraPrinting.PrintableComponentLink(New DevExpress.XtraPrinting.PrintingSystem())
        Dim opt As DevExpress.XtraPrinting.CsvExportOptions = New DevExpress.XtraPrinting.CsvExportOptions()
        opt.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text

        'source
        If LEType.EditValue.ToString = "1" Then ' FM
            printableComponentLink1.Component = GCData
        ElseIf LEType.EditValue.ToString = "2" Then 'FK
            printableComponentLink1.Component = GCFK
        Else
            printableComponentLink1.Component = GCDM
        End If

        printableComponentLink1.CreateDocument()
        Dim path As String = get_setup_field("upload_dir") + "faktur_scan\"
        If Not IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If
        path = path + id_acc_fak_scan + "_" + TxtPeriod.Text + TxtYear.Text + "_" + LEType.Text + ".csv"
        printableComponentLink1.ExportToCsv(path, opt)
        downFaktur(path)
    End Sub

    Sub downFaktur(ByVal source_path As String)
        Try
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            'download
            My.Computer.Network.DownloadFile(source_path, path + id_acc_fak_scan + "_" + TxtPeriod.Text + TxtYear.Text + "_" + LEType.Text + ".csv", "", "", True, 100, True)
            'open folder
            If IO.File.Exists(path + id_acc_fak_scan + "_" + TxtPeriod.Text + TxtYear.Text + "_" + LEType.Text + ".csv") Then
                Dim open_folder As ProcessStartInfo = New ProcessStartInfo()
                open_folder.WindowStyle = ProcessWindowStyle.Maximized
                open_folder.FileName = "explorer.exe"
                open_folder.Arguments = "/Select,""" & path + id_acc_fak_scan + "_" + TxtPeriod.Text + TxtYear.Text + "_" + LEType.Text + ".csv" & """"
                Process.Start(path + id_acc_fak_scan + "_" + TxtPeriod.Text + TxtYear.Text + "_" + LEType.Text + ".csv")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GroupControl1_Paint(sender As Object, e As PaintEventArgs) Handles GroupControl1.Paint

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        Dim id_faktur_type As String = LEType.EditValue.ToString
        Dim acc_fak_scan_period As String = TxtPeriod.Text
        Dim acc_fak_scan_year As String = TxtYear.Text
        Dim acc_fak_scan_faktur_date As String = TxtFakturDate.Text.ToString
        If action = "ins" Then
            'main 
            Dim query As String = "INSERT INTO tb_a_acc_fak_scan(acc_fak_scan_date, acc_fak_scan_trans_date, acc_fak_scan_faktur_date, id_faktur_type, acc_fak_scan_period, acc_fak_scan_year,id_departement) "
            query += "VALUES(NOW(), NOW(), '" + acc_fak_scan_faktur_date + "', '" + id_faktur_type + "','" + acc_fak_scan_period + "', '" + acc_fak_scan_year + "','" + id_departement_user + "'); SELECT LAST_INSERT_ID(); "
            id_acc_fak_scan = execute_query(query, 0, True, "", "", "", "")

            infoCustom("Faktur was created successfully. ")
            FormAccountingFakturScan.viewTrans()
            FormAccountingFakturScan.GVFak.FocusedRowHandle = find_row(FormAccountingFakturScan.GVFak, "id_acc_fak_scan", id_acc_fak_scan)
            action = "upd"
            actionLoad()
        Else
            'main
            Dim query As String = "UPDATE tb_a_acc_fak_scan SET id_faktur_type='" + id_faktur_type + "',acc_fak_scan_period='" + acc_fak_scan_period + "', acc_fak_scan_year='" + acc_fak_scan_year + "', acc_fak_scan_faktur_date='" + acc_fak_scan_faktur_date + "',acc_fak_scan_trans_date=NOW() WHERE id_acc_fak_scan='" + id_acc_fak_scan + "' "
            execute_non_query(query, True, "", "", "", "")

            'edit detail table
            Dim query_detail As String = ""
            Dim jum_ins_j As Integer = 0

            If LEType.EditValue.ToString = "1" Then 'FM
                If GVData.RowCount > 0 Then
                    query_detail = "INSERT INTO tb_a_acc_fak_scan_det(id_acc_fak_scan, kd_jenis_transaksi, fg_pengganti, nomor_faktur, masa_pajak, tahun_pajak, tanggal_faktur, npwp, nama, alamat_lengkap, jumlah_dpp, jumlah_ppn, jumlah_ppnbm, is_creditable) VALUES "
                End If
                For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                    Try
                        Dim id_acc_fak_scan_det As String = GVData.GetRowCellValue(i, "id_acc_fak_scan_det").ToString
                        Dim kd_jenis_transaksi As String = GVData.GetRowCellValue(i, "kd_jenis_transaksi").ToString
                        Dim fg_pengganti As String = GVData.GetRowCellValue(i, "fg_pengganti").ToString
                        Dim nomor_faktur As String = GVData.GetRowCellValue(i, "nomor_faktur").ToString
                        Dim masa_pajak As String = GVData.GetRowCellValue(i, "masa_pajak").ToString
                        Dim tahun_pajak As String = GVData.GetRowCellValue(i, "tahun_pajak").ToString
                        Dim tanggal_faktur As String = GVData.GetRowCellValue(i, "tanggal_faktur").ToString
                        Dim npwp As String = GVData.GetRowCellValue(i, "npwp").ToString
                        Dim nama As String = GVData.GetRowCellValue(i, "nama").ToString
                        Dim alamat_lengkap As String = GVData.GetRowCellValue(i, "alamat_lengkap").ToString
                        Dim jumlah_dpp As String = GVData.GetRowCellValue(i, "jumlah_dpp").ToString
                        Dim jumlah_ppn As String = GVData.GetRowCellValue(i, "jumlah_ppn").ToString
                        Dim jumlah_ppnbm As String = GVData.GetRowCellValue(i, "jumlah_ppnbm").ToString
                        Dim is_creditable As String = GVData.GetRowCellValue(i, "is_creditable").ToString
                        If id_acc_fak_scan_det = "0" Then
                            If jum_ins_j > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_acc_fak_scan + "', '" + kd_jenis_transaksi + "', '" + fg_pengganti + "', '" + nomor_faktur + "', '" + masa_pajak + "', '" + tahun_pajak + "', '" + tanggal_faktur + "', '" + npwp + "', '" + nama + "', '" + alamat_lengkap + "', '" + jumlah_dpp + "', '" + jumlah_ppn + "', '" + jumlah_ppnbm + "', '" + is_creditable + "') "
                            jum_ins_j = jum_ins_j + 1
                        Else
                            Dim query_upd As String = "UPDATE tb_a_acc_fak_scan_det SET "
                            query_upd += "id_acc_fak_scan_det ='" + id_acc_fak_scan_det + "', "
                            query_upd += "kd_jenis_transaksi ='" + kd_jenis_transaksi + "', "
                            query_upd += "fg_pengganti='" + fg_pengganti + "', "
                            query_upd += "nomor_faktur ='" + nomor_faktur + "', "
                            query_upd += "masa_pajak='" + masa_pajak + "', "
                            query_upd += "tahun_pajak ='" + tahun_pajak + "', "
                            query_upd += "tanggal_faktur ='" + tanggal_faktur + "', "
                            query_upd += "npwp ='" + npwp + "', "
                            query_upd += "nama ='" + nama + "', "
                            query_upd += "alamat_lengkap='" + alamat_lengkap + "',  "
                            query_upd += "jumlah_dpp ='" + jumlah_dpp + "', "
                            query_upd += "jumlah_ppn ='" + jumlah_ppn + "', "
                            query_upd += "jumlah_ppnbm ='" + jumlah_ppnbm + "', "
                            query_upd += "is_creditable ='" + is_creditable + "' "
                            query_upd += "WHERE id_acc_fak_scan_det = '" + id_acc_fak_scan_det + "' "
                            execute_non_query(query_upd, True, "", "", "", "")
                            id_acc_fak_scan_det_list.Remove(id_acc_fak_scan_det)
                        End If
                    Catch ex As Exception
                        ex.ToString()
                    End Try
                Next
                If jum_ins_j > 0 Then
                    execute_non_query(query_detail, True, "", "", "", "")
                End If

                'delete sisa
                For k As Integer = 0 To (id_acc_fak_scan_det_list.Count - 1)
                    Try
                        Dim querydel As String = "DELETE FROM tb_a_acc_fak_scan_det WHERE id_acc_fak_scan_det = '" + id_acc_fak_scan_det_list(k) + "' "
                        execute_non_query(querydel, True, "", "", "", "")
                    Catch ex As Exception
                        ex.ToString()
                    End Try
                Next
            ElseIf LEType.EditValue.ToString = "3" Then 'DM
                If GVDM.RowCount > 0 Then
                    query_detail = "INSERT INTO tb_a_acc_fak_scan_dm_det(id_acc_fak_scan, jenis_transaksi, jenis_dokumen, kd_jns_transaksi, fg_pengganti, nomor_dok_lain_ganti, nomor_dok_lain, tanggal_dok_lain, masa_pajak, tahun_pajak, npwp, nama, alamat_lengkap, jumlah_dpp, jumlah_ppn, jumlah_ppnbm, keterangan) VALUES "
                End If
                For i As Integer = 0 To ((GVDM.RowCount - 1) - GetGroupRowCount(GVDM))
                    Try
                        Dim id_acc_fak_scan_dm_det As String = GVDM.GetRowCellValue(i, "id_acc_fak_scan_dm_det").ToString
                        Dim jenis_transaksi As String = GVDM.GetRowCellValue(i, "jenis_transaksi").ToString
                        Dim jenis_dokumen As String = GVDM.GetRowCellValue(i, "jenis_dokumen").ToString
                        Dim kd_jns_transaksi As String = GVDM.GetRowCellValue(i, "kd_jns_transaksi").ToString
                        Dim fg_pengganti As String = GVDM.GetRowCellValue(i, "fg_pengganti").ToString
                        Dim nomor_dok_lain_ganti As String = GVDM.GetRowCellValue(i, "nomor_dok_lain_ganti").ToString
                        Dim nomor_dok_lain As String = GVDM.GetRowCellValue(i, "nomor_dok_lain").ToString
                        Dim tanggal_dok_lain As String = GVDM.GetRowCellValue(i, "tanggal_dok_lain").ToString
                        Dim masa_pajak As String = GVDM.GetRowCellValue(i, "masa_pajak").ToString
                        Dim tahun_pajak As String = GVDM.GetRowCellValue(i, "tahun_pajak").ToString
                        Dim npwp As String = GVDM.GetRowCellValue(i, "npwp").ToString
                        Dim nama As String = GVDM.GetRowCellValue(i, "nama").ToString
                        Dim alamat_lengkap As String = GVDM.GetRowCellValue(i, "alamat_lengkap").ToString
                        Dim jumlah_dpp As String = GVDM.GetRowCellValue(i, "jumlah_dpp").ToString
                        Dim jumlah_ppn As String = GVDM.GetRowCellValue(i, "jumlah_ppn").ToString
                        Dim jumlah_ppnbm As String = GVDM.GetRowCellValue(i, "jumlah_ppnbm").ToString
                        Dim keterangan As String = GVDM.GetRowCellValue(i, "keterangan").ToString

                        If id_acc_fak_scan_dm_det = "0" Then
                            If jum_ins_j > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_acc_fak_scan + "', '" + jenis_transaksi + "', '" + jenis_dokumen + "', '" + kd_jns_transaksi + "', '" + fg_pengganti + "', '" + nomor_dok_lain_ganti + "', '" + nomor_dok_lain + "', '" + tanggal_dok_lain + "', '" + masa_pajak + "', '" + tahun_pajak + "', '" + npwp + "', '" + nama + "', '" + alamat_lengkap + "', '" + jumlah_dpp + "', '" + jumlah_ppn + "', '" + jumlah_ppnbm + "', '" + keterangan + "') "
                            jum_ins_j = jum_ins_j + 1
                        Else
                            Dim query_upd_ As String = "UPDATE tb_a_acc_fak_scan_dm_det SET jenis_transaksi='" + jenis_transaksi + "', jenis_dokumen='" + jenis_dokumen + "', kd_jns_transaksi='" + kd_jns_transaksi + "', fg_pengganti='" + fg_pengganti + "', nomor_dok_lain_ganti='" + nomor_dok_lain_ganti + "', nomor_dok_lain='" + nomor_dok_lain + "', tanggal_dok_lain='" + tanggal_dok_lain + "', masa_pajak='" + masa_pajak + "', tahun_pajak='" + tahun_pajak + "', npwp='" + npwp + "', nama='" + nama + "', alamat_lengkap='" + alamat_lengkap + "', jumlah_dpp='" + jumlah_dpp + "', jumlah_ppn='" + jumlah_ppn + "', jumlah_ppnbm='" + jumlah_ppnbm + "', keterangan='" + keterangan + "' WHERE id_acc_fak_scan_dm_det='" + id_acc_fak_scan_dm_det + "' "
                            execute_non_query(query_upd_, True, "", "", "", "")
                            id_acc_fak_scan_det_list.Remove(id_acc_fak_scan_dm_det)
                        End If
                    Catch ex As Exception
                        ex.ToString()
                    End Try
                Next
                If jum_ins_j > 0 Then
                    execute_non_query(query_detail, True, "", "", "", "")
                End If

                'delete sisa
                For k As Integer = 0 To (id_acc_fak_scan_det_list.Count - 1)
                    Try
                        Dim querydel As String = "DELETE FROM tb_a_acc_fak_scan_dm_det WHERE id_acc_fak_scan_dm_det = '" + id_acc_fak_scan_det_list(k) + "' "
                        execute_non_query(querydel, True, "", "", "", "")
                    Catch ex As Exception
                        ex.ToString()
                    End Try
                Next
            End If


            infoCustom("Faktur was edited successfully. ")
            FormAccountingFakturScan.viewTrans()
            FormAccountingFakturScan.GVFak.FocusedRowHandle = find_row(FormAccountingFakturScan.GVFak, "id_acc_fak_scan", id_acc_fak_scan)
            action = "upd"
            actionLoad()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnImportFK_Click(sender As Object, e As EventArgs) Handles BtnImportFK.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "8"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        If LEType.EditValue.ToString = "1" Then
            print(GCData, "")
        ElseIf LEType.EditValue.ToString = "2" Then
            print(GCFK, "")
        Else
            print(GCDM, "")
        End If
    End Sub

    Private Sub BtnAddDM_Click(sender As Object, e As EventArgs) Handles BtnAddDM.Click
        addDM()
    End Sub

    Sub addDM()
        Dim newRow As DataRow = (TryCast(GCDM.DataSource, DataTable)).NewRow()
        newRow("id_acc_fak_scan_dm_det") = "0"
        newRow("dm") = "DM"
        newRow("id_acc_fak_scan") = id_acc_fak_scan
        newRow("masa_pajak") = TxtPeriod.Text
        newRow("tahun_pajak") = TxtYear.Text
        TryCast(GCDM.DataSource, DataTable).Rows.Add(newRow)
        GCDM.RefreshDataSource()
        GVDM.RefreshData()
        GVDM.FocusedRowHandle = GVDM.RowCount - 1
        GVDM.FocusedColumn = GridColumnDM
    End Sub

    Private Sub BtnDeleteDM_Click(sender As Object, e As EventArgs) Handles BtnDeleteDM.Click
        delDM()
    End Sub

    Sub delDM()
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want To delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            GVDM.DeleteSelectedRows()
        End If
    End Sub

    Private Sub GVDM_KeyDown(sender As Object, e As KeyEventArgs) Handles GVDM.KeyDown
        'e.KeyCode = Keys.F5 And e.Modifiers = Keys.Control
        If (e.KeyCode = Keys.Delete) Then
            delDM()
        ElseIf (e.KeyCode = Keys.F5) Then
            addDM()
        End If
    End Sub

    Private Sub TxtPeriod_EditValueChanged(sender As Object, e As EventArgs) Handles TxtPeriod.EditValueChanged
        Try
            fillFakturDate()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtYear_EditValueChanged(sender As Object, e As EventArgs) Handles TxtYear.EditValueChanged
        Try
            fillFakturDate()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AddRowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddRowToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If XTCFaktur.SelectedTabPageIndex = 0 Then
            Dim newRow As DataRow = (TryCast(GCData.DataSource, DataTable)).NewRow()
            newRow("id_acc_fak_scan_det") = "0"
            newRow("id_acc_fak_scan") = "0"
            newRow("masa_pajak") = TxtPeriod.Text
            newRow("tahun_pajak") = TxtYear.Text
            newRow("is_creditable") = "1"
            newRow("type") = LEType.Text
            newRow("kd_jenis_transaksi") = ""
            newRow("fg_pengganti") = ""
            newRow("nomor_faktur") = ""
            newRow("tanggal_faktur") = ""
            newRow("npwp") = ""
            newRow("nama") = ""
            newRow("alamat_lengkap") = ""
            newRow("jumlah_dpp") = ""
            newRow("jumlah_ppn") = ""
            newRow("jumlah_ppnbm") = ""
            TryCast(GCData.DataSource, DataTable).Rows.Add(newRow)
        ElseIf XTCFaktur.SelectedTabPageIndex = 1 Then
            'nothing
        ElseIf XTCFaktur.SelectedTabPageIndex = 2 Then
            'dm
            addDM()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub DeleteRowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteRowToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If XTCFaktur.SelectedTabPageIndex = 0 Then
            deleteScan()
        ElseIf XTCFaktur.SelectedTabPageIndex = 1 Then
            'nothing
        ElseIf XTCFaktur.SelectedTabPageIndex = 2 Then
            'dm
            delDM()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnImportFKDetail_Click(sender As Object, e As EventArgs) Handles BtnImportFKDetail.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "26"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class