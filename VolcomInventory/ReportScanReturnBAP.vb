Public Class ReportScanReturnBAP
    Public data_det As DataTable
    Public id_bap As String = "-1"
    Private Sub ReportScanReturnBAP_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        XRHeader.Html = "<p style='text-align: justify'>Pada hari ini <b><u>[day_s]</u></b>, tanggal <b><u>[date_s]</u></b>, bulan <b><u>[month_s]</u></b>, tahun <b><u>[year_s]</u></b>, kami yang bertandatangan di bawah ini, telah melakukan serah terima kiriman produk sesuai prosedur yang berlaku pada <br /><b>PT. Volcom Indonesia</b>. Dari hasil serah terima produk tersebut, dapat kami sampaikan sebagai berikut:</p>"
        XRpoint2.Html = "Fisik produk <b><u>TIDAK SESUAI</u></b>  dengan Dokumen terkait yang terdapat di dalam paket / box.<br/>Adapun produk yang tidak sesuai adalah sebagai berikut :"

        '
        Dim q As String = "SET @@lc_time_names = 'id_ID';
SELECT IFNULL(c.`comp_name`,'Warehouse') AS comp_name,bap_number,emp_wh_mngr.employee_name AS wh_manager_name,emp_wh_mngr.employee_position AS wh_manager_position,emp.employee_name,emp.employee_position,DAYNAME(bap_date) AS day_s,DATE_FORMAT(bap_date,'%d') AS date_s,DATE_FORMAT(bap_date,'%M') AS month_s,DATE_FORMAT(bap_date,'%Y') AS year_s,IF(`is_lubang`=1,'V','') AS is_lubang,IF(`is_seal_rusak`=1,'V','') AS `is_seal_rusak`,IF(`is_basah`=1,'V','') AS `is_basah`,IF(`is_other_cond`=1,'V','') AS `is_other_cond`,`other_cond`
FROM `tb_scan_return_bap` bap
INNER JOIN tb_m_user usr ON usr.id_user=bap.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_m_user usr_wh_mngr ON usr_wh_mngr.id_user=(SELECT id_user_head FROM tb_m_departement WHERE id_departement='6' LIMIT 1)
INNER JOIN tb_m_employee emp_wh_mngr ON  emp_wh_mngr.id_employee=usr_wh_mngr.id_employee
LEFT JOIN tb_m_comp c ON c.`id_comp`=bap.`id_3pl`
WHERE bap.`id_scan_return_bap` = '" & id_bap & "'"
        DataSource = execute_query(q, -1, True, "", "", "", "")
        '
        Dim id_current As String = ""
        Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

        For i = 0 To data_det.Rows.Count - 1
            'row
            If i = 0 Then
                row = XTDetail.InsertRowBelow(XTTop)
                row.HeightF = 16
            Else
                row = XTDetail.InsertRowBelow(row)
            End If

            row.Font = New Font("Tahoma", 7.5, FontStyle.Regular)

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)

            no.Text = i + 1.ToString
            no.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            no.BackColor = Color.Transparent

            If Not id_current = data_det.Rows(i)("id_return_note").ToString Then
                id_current = data_det.Rows(i)("id_return_note").ToString

                'return Note number
                Dim rn_number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

                rn_number.Text = data_det.Rows(i)("number_return_note").ToString
                rn_number.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
                rn_number.BackColor = Color.Transparent

                'search how many rowspan
                For j = i To data_det.Rows.Count - 1
                    If id_current = data_det.Rows(i)("id_return_note").ToString Then
                        rn_number.RowSpan += 1
                    End If
                Next

                'list store
                Dim list_store As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
                list_store.WordWrap = True
                list_store.Multiline = True
                list_store.Text = data_det.Rows(i)("store_list").ToString
                list_store.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
                list_store.BackColor = Color.Transparent

                'search how many rowspan
                For j = i To data_det.Rows.Count - 1
                    If id_current = data_det.Rows(i)("id_return_note").ToString Then
                        list_store.RowSpan += 1
                    End If
                Next
            End If

            'kode barang
            Dim kode_barang As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)

            kode_barang.Text = data_det.Rows(i)("code").ToString
            kode_barang.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            kode_barang.BackColor = Color.Transparent

            'deskripsi barang
            Dim desc_barang As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)

            desc_barang.Text = data_det.Rows(i)("description").ToString
            desc_barang.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            desc_barang.BackColor = Color.Transparent

            'Size barang
            Dim size_barang As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)

            size_barang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            size_barang.Text = data_det.Rows(i)("size").ToString
            size_barang.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            size_barang.BackColor = Color.Transparent

            'Qty barang
            Dim qty_barang As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

            qty_barang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            qty_barang.Text = Decimal.Parse(data_det.Rows(i)("qty").ToString).ToString("N0")
            qty_barang.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            qty_barang.BackColor = Color.Transparent

            'Notes 
            Dim notes As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

            notes.WordWrap = True
            notes.Multiline = True
            notes.Text = data_det.Rows(i)("note").ToString
            notes.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom
            notes.BackColor = Color.Transparent
        Next
    End Sub
End Class