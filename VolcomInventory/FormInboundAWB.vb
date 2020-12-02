Public Class FormInboundAWB
    Public id_awb_inbound As String = "-1"
    Dim divide_by As Decimal = 0.00

    Sub load_type()
        Dim q As String = "SELECT rate.id_del_type,del.del_type
FROM tb_3pl_rate rate
INNER JOIN tb_lookup_del_type del ON del.id_del_type=rate.id_del_type AND del.is_able_inbound=1
WHERE id_type='2' AND is_active='1'
GROUP BY del.id_del_type"
        viewSearchLookupQuery(SLEDelType, q, "id_del_type", "del_type", "id_del_type")
    End Sub

    Sub load_3pl()
        Dim q As String = "SELECT c.id_comp,c.comp_number,c.comp_name
FROM tb_3pl_rate rate
INNER JOIN tb_lookup_del_type del ON del.id_del_type=rate.id_del_type AND del.is_able_inbound=1
INNER JOIN tb_m_comp c ON c.id_comp=rate.id_comp
WHERE rate.id_type='2' AND rate.is_active='1'
AND rate.id_del_type='" & SLEDelType.EditValue.ToString & "'
GROUP BY rate.id_comp"
        viewSearchLookupQuery(SLEVendor, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_repo_store()
        Dim q As String = "SELECT id_comp,comp_number,CONCAT(comp_number, ' - ',comp_name) AS comp_name
FROM tb_m_comp 
WHERE id_comp_cat='6' AND is_active='1' AND id_sub_district=(SELECT id_sub_district FROM tb_3pl_rate WHERE id_3pl_rate='" & SLERate.EditValue.ToString & "' LIMIT 1)"
        viewSearchLookupRepositoryQuery(RISLECompany, q, 0, "comp_name", "id_comp")
    End Sub

    Private Sub FormInboundAWB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_type()
        load_3pl()
        '
        load_koli()
        load_store()
        load_repo_store()
        '
        If Not id_awb_inbound = "-1" Then
            Dim q As String = "SELECT inb.id_comp,inb.id_del_type,inb.awb_number,dt.volume_divide_by,inb.id_3pl_rate
FROM `tb_inbound_awb` inb
INNER JOIN tb_lookup_del_type dt ON dt.id_del_type=inb.id_del_type
WHERE inb.id_inbound_awb='" & id_awb_inbound & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                SLEDelType.EditValue = dt.Rows(0)("id_del_type").ToString
                SLEVendor.EditValue = dt.Rows(0)("id_comp").ToString
                SLERate.EditValue = dt.Rows(0)("id_3pl_rate").ToString
                TEAwb.Text = dt.Rows(0)("awb_number").ToString
                '
                divide_by = dt.Rows(0)("volume_divide_by")
                '
                XTCdetail.Enabled = True
                TEAwb.Enabled = False
                BNext.Enabled = True
                BSubmitAwb.Enabled = False
                '
                'check sudah dipakai
                Dim qc As String = "SELECT * from tb_return_note WHERE id_inbound_awb='" & id_awb_inbound & "' AND is_void=2"
                Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                If dtc.Rows.Count > 0 Then
                    BUpdateKoli.Visible = False
                    BUpdateStore.Visible = False
                End If
            End If
        End If
        '
    End Sub

    Sub load_koli()
        Dim q As String = ""
        If id_awb_inbound = "-1" Then
            q = "SELECT koli_notes,divide_by,panjang,lebar,tinggi,berat
FROM `tb_inbound_koli`
WHERE id_inbound_awb='" & id_awb_inbound & "'"
        Else
            q = "SELECT koli_notes,divide_by,panjang,lebar,tinggi,berat
FROM `tb_inbound_koli`
WHERE id_inbound_awb='" & id_awb_inbound & "'"
        End If

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCKoli.DataSource = dt
        GVKoli.BestFitColumns()
        check_but()
    End Sub

    Sub load_store()
        Dim q As String = "SELECT id_comp
FROM `tb_inbound_store`
WHERE id_inbound_awb='" & id_awb_inbound & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCStore.DataSource = dt
        GVStore.BestFitColumns()
        check_but()
    End Sub

    Private Sub BSubmitAwb_Click(sender As Object, e As EventArgs) Handles BSubmitAwb.Click
        'save AWB
        If TEAwb.Text = "" Then
            warningCustom("Please input AWB")
        Else
            'check AWB
            Dim qc As String = "SELECT * FROM tb_inbound_awb
WHERE id_comp='" & SLEVendor.EditValue.ToString & "' AND awb_number='" & addSlashes(TEAwb.Text.ToString) & "'"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                warningCustom("AWB already exist.")
            Else
                Dim q As String = "INSERT INTO `tb_inbound_awb`(id_comp,id_del_type,id_3pl_rate,awb_number,created_by,created_date)
VALUES('" & SLEVendor.EditValue.ToString & "','" & SLEDelType.EditValue.ToString & "','" & SLERate.EditValue.ToString & "','" & addSlashes(TEAwb.Text.ToString) & "','" & id_user & "',NOW());SELECT LAST_INSERT_ID()"
                id_awb_inbound = execute_query(q, 0, True, "", "", "", "")
                '
                empty_store()
                empty_koli()
                'divide by
                Dim qdb As String = "SELECT volume_divide_by FROM `tb_lookup_del_type` WHERE id_del_type='" & SLEDelType.EditValue.ToString & "'"
                Dim dtb As DataTable = execute_query(qdb, -1, True, "", "", "", "")
                divide_by = dtb.Rows(0)("volume_divide_by")
                '
                XTCdetail.Enabled = True
                TEAwb.Enabled = False
                BNext.Enabled = True
                BSubmitAwb.Enabled = False
            End If
        End If
    End Sub

    Sub empty_store()
        For i = GVStore.RowCount - 1 To 0 Step -1
            GVStore.DeleteRow(i)
        Next
        check_but()
    End Sub

    Sub empty_koli()
        For i = GVKoli.RowCount - 1 To 0 Step -1
            GVKoli.DeleteRow(i)
        Next
        check_but()
    End Sub

    Private Sub FormInboundAWB_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SLEVendor_EditValueChanged(sender As Object, e As EventArgs) Handles SLEVendor.EditValueChanged
        load_rate()
    End Sub

    Sub load_rate()
        Dim q As String = "SELECT rte.id_3pl_rate,ds.id_sub_district,ds.sub_district,rte.cargo_rate,rte.cargo_lead_time,rte.cargo_min_weight
FROM `tb_3pl_rate` rte
INNER JOIN tb_m_sub_district ds ON ds.id_sub_district=rte.id_sub_district
WHERE rte.is_active=1 AND rte.id_del_type='" & SLEDelType.EditValue.ToString & "' AND rte.id_comp='" & SLEVendor.EditValue.ToString & "'"
        viewSearchLookupQuery(SLERate, q, "id_3pl_rate", "sub_district", "id_3pl_rate")
    End Sub

    Sub check_but()
        If GVKoli.RowCount > 0 Then
            BDelKoli.Visible = True
        Else
            BDelKoli.Visible = False
        End If
        '
        If GVStore.RowCount > 0 Then
            BDelStore.Visible = True
        Else
            BDelStore.Visible = False
        End If
    End Sub

    Private Sub BDelStore_Click(sender As Object, e As EventArgs) Handles BDelStore.Click
        If GVStore.RowCount > 0 Then
            GVStore.DeleteSelectedRows()
            check_but()
        End If
    End Sub

    Private Sub BDelKoli_Click(sender As Object, e As EventArgs) Handles BDelKoli.Click
        If GVKoli.RowCount > 0 Then
            GVKoli.DeleteSelectedRows()
            check_but()
        End If
    End Sub

    Private Sub BNext_Click(sender As Object, e As EventArgs) Handles BNext.Click
        BSubmitAwb.Enabled = True
        BNext.Enabled = False
        TEAwb.Enabled = True
        XTCdetail.Enabled = False

        empty_store()
        empty_koli()

        TEAwb.Text = ""
        id_awb_inbound = "-1"

        TEAwb.Focus()
    End Sub

    Private Sub BUpdateStore_Click(sender As Object, e As EventArgs) Handles BUpdateStore.Click
        If id_awb_inbound = "-1" Then
            Close()
        Else
            Dim is_ok As Boolean = True

            GVStore.RefreshData()

            For i = 0 To GVStore.RowCount - 1
                If GVStore.GetRowCellValue(i, "id_comp").ToString = "" Then
                    is_ok = False
                End If
            Next

            If is_ok Then
                Dim q As String = ""
                q = "DELETE FROM tb_inbound_store WHERE id_inbound_awb='" & id_awb_inbound & "'"
                execute_non_query(q, True, "", "", "", "")
                q = "INSERT INTO `tb_inbound_store`(id_inbound_awb,id_comp)
VALUES"
                For i As Integer = 0 To GVStore.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id_awb_inbound & "','" & GVStore.GetRowCellValue(i, "id_comp").ToString & "')"
                Next
                execute_non_query(q, True, "", "", "", "")
                infoCustom("Update success")
            Else
                warningCustom("Please choose vendor.")
            End If
        End If
    End Sub

    Private Sub BUpdateKoli_Click(sender As Object, e As EventArgs) Handles BUpdateKoli.Click
        If id_awb_inbound = "-1" Then
            Close()
        Else
            'check null
            Dim is_ok As Boolean = True

            GVKoli.RefreshData()

            For i = 0 To GVKoli.RowCount - 1
                If GVKoli.GetRowCellValue(i, "koli_notes").ToString = "" Or GVKoli.GetRowCellValue(i, "berat") = 0 Then
                    is_ok = False
                End If
            Next

            If is_ok Then
                Dim q As String = ""
                q = "DELETE FROM tb_inbound_koli WHERE id_inbound_awb='" & id_awb_inbound & "'"
                execute_non_query(q, True, "", "", "", "")
                q = "INSERT INTO `tb_inbound_koli`(id_inbound_awb,koli_notes,divide_by,panjang,lebar,tinggi,berat,berat_dimensi)
VALUES"
                For i As Integer = 0 To GVKoli.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id_awb_inbound & "','" & GVKoli.GetRowCellValue(i, "koli_notes").ToString & "','" & decimalSQL(Decimal.Parse(GVKoli.GetRowCellValue(i, "divide_by").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVKoli.GetRowCellValue(i, "panjang").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVKoli.GetRowCellValue(i, "lebar").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVKoli.GetRowCellValue(i, "tinggi").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVKoli.GetRowCellValue(i, "berat").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVKoli.GetRowCellValue(i, "berat_dimensi").ToString).ToString) & "')"

                Next
                execute_non_query(q, True, "", "", "", "")
                infoCustom("Update success")
            Else
                warningCustom("Please check your input.")
            End If
        End If
    End Sub

    Private Sub SLEDelType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEDelType.EditValueChanged
        load_3pl()
    End Sub

    Private Sub BAddStore_Click(sender As Object, e As EventArgs) Handles BAddStore.Click
        GVStore.AddNewRow()
        check_but()
    End Sub

    Private Sub BAddKoli_Click(sender As Object, e As EventArgs) Handles BAddKoli.Click
        Try
            GVKoli.AddNewRow()
            GVKoli.RefreshData()

            GVKoli.SetRowCellValue(GVKoli.RowCount - 1, "divide_by", divide_by)
            GVKoli.SetRowCellValue(GVKoli.RowCount - 1, "panjang", 0.00)
            GVKoli.SetRowCellValue(GVKoli.RowCount - 1, "lebar", 0.00)
            GVKoli.SetRowCellValue(GVKoli.RowCount - 1, "tinggi", 0.00)
            GVKoli.SetRowCellValue(GVKoli.RowCount - 1, "berat", 0.00)

            check_but()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)

        End Try
    End Sub

    Private Sub SLERate_EditValueChanged(sender As Object, e As EventArgs) Handles SLERate.EditValueChanged
        load_repo_store()
    End Sub
End Class