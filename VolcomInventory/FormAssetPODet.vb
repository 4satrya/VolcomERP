Public Class FormAssetPODet
    Public id_po As String = "-1"
    Public is_view As String = "-1"
    Private Sub FormAssetPODet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEVat.EditValue = 10
        '
        DEPODate.EditValue = Now
        DEEstRecDate.EditValue = Now
        '
        load_cat()
        load_dept()
        load_top()
        '
        load_det()
        load_list()
        calculate()
    End Sub

    Sub load_top()
        Dim query As String = "SELECT id_term_payment,term_payment FROM tb_lookup_term_payment"
        viewLookupQuery(LEPil, query, 0, "term_payment", "id_term_payment")
    End Sub

    Sub load_det()
        If id_po = "-1" Then 'new
            BtnPrint.Visible = False
            BtnAttachment.Visible = False
            BMark.Visible = False
        Else 'edit
            Dim query As String = "SELECT * FROM tb_a_asset_po WHERE id_asset_po='" & id_po & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TEVendor.Text = data.Rows(0)("comp_name").ToString
                TEAttn.Text = data.Rows(0)("comp_attn").ToString
                MEAddress.Text = data.Rows(0)("comp_address").ToString
                TEPhone.Text = data.Rows(0)("comp_phone").ToString
                TEFax.Text = data.Rows(0)("comp_fax").ToString
                DEPODate.EditValue = data.Rows(0)("asset_po_date")
                DEEstRecDate.EditValue = data.Rows(0)("est_rec_date")
                TEPONumber.Text = data.Rows(0)("asset_po_no").ToString
                LEPil.ItemIndex = LEPil.Properties.GetDataSourceRowIndex("id_term_payment", data.Rows(0)("id_term_payment").ToString)
                '
                MENote.Text = data.Rows(0)("note").ToString
                TEVat.EditValue = data.Rows(0)("vat")
                '
                If data.Rows(0)("id_report_status").ToString = "6" Or is_view = "1" Then
                    BtnSave.Visible = False
                End If
                '
            End If

            BtnPrint.Visible = True
            BtnAttachment.Visible = True
            BMark.Visible = True
        End If
    End Sub

    Sub load_list()
        Dim query As String = "SELECT *,CAST(((value-disc)*qty) as DECIMAL(13,2)) as total FROM tb_a_asset_po_det WHERE id_asset_po='" & id_po & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub load_dept()
        Dim query As String = "SELECT id_departement,departement FROM tb_m_departement"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupRepositoryQuery(RILEDepartement, query, 0, "departement", "id_departement")
    End Sub
    Sub addMyRow()
        Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
        newRow("id_asset_po_det") = "0"
        newRow("id_asset_cat") = 1
        newRow("id_departement") = 1
        newRow("vendor_sku") = ""
        newRow("desc") = ""
        newRow("qty") = 0
        newRow("value") = 0.0
        newRow("disc") = 0.0
        newRow("total") = 0.00
        newRow("note") = ""
        TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
        'CType(GCItemList.DataSource, DataTable).AcceptChanges()
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        '
        GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
        GCItemList.Focus()
        GVItemList.FocusedColumn = GridColumnSKU
    End Sub
    Sub deleteRow()
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVItemList)
        If GVItemList.RowCount <= 0 Then
            stopCustom("Not found")
        Else
            GVItemList.DeleteSelectedRows()
            makeSafeGV(GVItemList)
        End If
        GVItemList.RefreshData()
        Cursor = Cursors.Default
    End Sub
    Sub load_cat()
        Dim query As String = "SELECT id_asset_cat,asset_cat FROM tb_a_asset_cat"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupRepositoryQuery(RILEAssetCat, query, 0, "asset_cat", "id_asset_cat")
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        addMyRow()
        GVItemList.BestFitColumns()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If id_po = "-1" Then 'new
            Dim date_po As String = Date.Parse(DEPODate.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim date_est_rec As String = Date.Parse(DEEstRecDate.EditValue.ToString).ToString("yyyy-MM-dd")

            Dim query As String = "INSERT INTO tb_a_asset_po(id_term_payment,asset_po_no,asset_po_date,est_rec_date,comp_name,comp_attn,comp_address,comp_phone,comp_fax,note,vat,created_by,created_date,last_upd_by,last_upd_date)
                                    VALUES('" & LEPil.EditValue.ToString & "','" & addSlashes(TEPONumber.Text) & "','" & Date.Parse(DEPODate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DEEstRecDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & addSlashes(TEVendor.Text) & "','" & addSlashes(TEAttn.Text) & "','" & addSlashes(MEAddress.Text) & "','" & addSlashes(TEPhone.Text) & "','" & addSlashes(TEFax.Text) & "','" & addSlashes(MENote.Text) & "','" & decimalSQL(TEVat.EditValue.ToString) & "','" & id_user & "',NOW(),'" & id_user & "',NOW());
                                    SELECT LAST_INSERT_ID(); "
            id_po = execute_query(query, 0, True, "", "", "", "")
            'detail
            For i As Integer = 0 To GVItemList.RowCount - 1
                Dim category As String = GVItemList.GetRowCellValue(i, "id_asset_cat").ToString
                Dim departement As String = GVItemList.GetRowCellValue(i, "id_departement").ToString
                Dim sku As String = addSlashes(GVItemList.GetRowCellValue(i, "vendor_sku").ToString)
                Dim desc As String = addSlashes(GVItemList.GetRowCellValue(i, "desc").ToString)
                Dim qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "qty").ToString)
                Dim value As String = decimalSQL(GVItemList.GetRowCellValue(i, "value").ToString)
                Dim disc As String = decimalSQL(GVItemList.GetRowCellValue(i, "disc").ToString)
                Dim note As String = addSlashes(GVItemList.GetRowCellValue(i, "note").ToString)

                query = "INSERT INTO tb_a_asset_po_det(id_asset_po,id_asset_cat,id_departement,vendor_sku,`desc`,qty,`value`,disc,note)
                        VALUES('" & id_po & "','" & category & "','" & departement & "','" & sku & "','" & desc & "','" & qty & "','" & value & "','" & disc & "','" & note & "')"
                execute_non_query(query, True, "", "", "", "")
            Next
            FormAssetPO.load_po()
            FormAssetPO.GVPOList.FocusedRowHandle = find_row(FormAssetPO.GVPOList, "id_asset_po", id_po)
            infoCustom("Purchase listed")
            load_det()
            load_list()
        Else 'edit
            Dim date_po As String = Date.Parse(DEPODate.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim date_est_rec As String = Date.Parse(DEEstRecDate.EditValue.ToString).ToString("yyyy-MM-dd")

            Dim query As String = "UPDATE tb_a_asset_po SET 
                                    id_term_payment='" & LEPil.EditValue.ToString & "',asset_po_no='" & addSlashes(TEPONumber.Text) & "',asset_po_date='" & Date.Parse(DEPODate.EditValue.ToString).ToString("yyyy-MM-dd") & "',est_rec_date='" & Date.Parse(DEEstRecDate.EditValue.ToString).ToString("yyyy-MM-dd") & "',comp_name='" & addSlashes(TEVendor.Text) & "'
                                    ,comp_attn='" & addSlashes(TEAttn.Text) & "',comp_address='" & addSlashes(MEAddress.Text) & "',comp_phone='" & addSlashes(TEPhone.Text) & "',comp_fax='" & addSlashes(TEFax.Text) & "',note='" & addSlashes(MENote.Text) & "',vat='" & decimalSQL(TEVat.EditValue.ToString) & "',last_upd_by='" & id_user & "',last_upd_date=NOW() WHERE id_asset_po='" & id_po & "'"
            execute_non_query(query, True, "", "", "", "")
            '
            query = "DELETE FROM tb_a_asset_po_det WHERE id_asset_po='" & id_po & "'"
            execute_non_query(query, True, "", "", "", "")
            'detail
            For i As Integer = 0 To GVItemList.RowCount - 1
                Dim category As String = GVItemList.GetRowCellValue(i, "id_asset_cat").ToString
                Dim departement As String = GVItemList.GetRowCellValue(i, "id_departement").ToString
                Dim sku As String = addSlashes(GVItemList.GetRowCellValue(i, "vendor_sku").ToString)
                Dim desc As String = addSlashes(GVItemList.GetRowCellValue(i, "desc").ToString)
                Dim qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "qty").ToString)
                Dim value As String = decimalSQL(GVItemList.GetRowCellValue(i, "value").ToString)
                Dim disc As String = decimalSQL(GVItemList.GetRowCellValue(i, "disc").ToString)
                Dim note As String = addSlashes(GVItemList.GetRowCellValue(i, "note").ToString)

                query = "INSERT INTO tb_a_asset_po_det(id_asset_po,id_asset_cat,id_departement,vendor_sku,`desc`,qty,`value`,disc,note)
                        VALUES('" & id_po & "','" & category & "','" & departement & "','" & sku & "','" & desc & "','" & qty & "','" & value & "','" & disc & "','" & note & "')"
                execute_non_query(query, True, "", "", "", "")
            Next
            '
            FormAssetPO.load_po()
            FormAssetPO.GVPOList.FocusedRowHandle = find_row(FormAssetPO.GVPOList, "id_asset_po", id_po)
            infoCustom("Purchase updated")
            load_det()
            load_list()
        End If
    End Sub

    Private Sub FormAssetPODet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            'TAMBAH
            addMyRow()
        ElseIf e.KeyCode = Keys.F2 Then
            'DELETE
            deleteRow()
        End If
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        GVItemList.DeleteSelectedRows()
        calculate()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub GVItemList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVItemList.CellValueChanged
        Try
            If e.Column.FieldName = "qty" Or e.Column.FieldName = "value" Or e.Column.FieldName = "disc" Then
                GVItemList.SetRowCellValue(e.RowHandle, "total", ((GVItemList.GetRowCellValue(e.RowHandle, "value") - GVItemList.GetRowCellValue(e.RowHandle, "disc")) * GVItemList.GetRowCellValue(e.RowHandle, "qty")))
            End If
        Catch ex As Exception
        End Try
        calculate()
    End Sub

    Sub calculate()
        Try
            GVItemList.RefreshData()
            TETotal.EditValue = GVItemList.Columns("total").SummaryItem.SummaryValue
            TEVATAmount.EditValue = (TETotal.EditValue * TEVat.EditValue) / 100
            TEGrandTotal.EditValue = TETotal.EditValue + TEVATAmount.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_po
        FormDocumentUpload.report_mark_type = "128"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TEVat_EditValueChanged(sender As Object, e As EventArgs) Handles TEVat.EditValueChanged
        calculate()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_po
        FormReportMark.report_mark_type = "128"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub FormAssetPODet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class