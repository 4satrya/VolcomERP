Public Class FormItemTrfDet
    Public id_trf As String = "-1"

    Private Sub FormItemTrfDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub view_storage()
        Dim q As String = "SELECT id_comp,comp_number,comp_name FROM tb_m_comp WHERE id_comp_cat='9'"
        viewSearchLookupQuery(SLEStorageFrom, q, "id_comp", "comp_name", "id_comp")
        viewSearchLookupQuery(SLEStorageTo, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub view_departement()
        Dim query As String = "SELECT '0' AS id_departement,'Purchasing Storage' AS departement
UNION
SELECT id_departement,departement FROM tb_m_departement"
        viewSearchLookupQuery(SLEDepFrom, query, "id_departement", "departement", "id_departement")
        viewSearchLookupQuery(SLEDepTo, query, "id_departement", "departement", "id_departement")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        Dim query As String = "SELECT rd.`id_item_trf_det`,rd.`id_item`,i.`item_desc`,rd.`qty`,u.`uom`
FROM tb_item_trf_det rd
INNER JOIN tb_item i ON i.id_item = rd.id_item
INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
WHERE rd.id_item_trf='" & id_trf & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
    End Sub

    Private Sub FormItemTrfDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_storage()
        viewReportStatus()

        If id_trf = "-1" Then 'new
            TxtNumber.Text = "[auto generate]"
            DECreated.EditValue = Now
            viewDetail()
        Else 'edit
            Dim q As String = "SELECT tr.number,tr.id_comp_from,tr.id_comp_to,tr.note,tr.id_report_status,emp.employee_name,tr.created_date 
FROM tb_item_trf tr
INNER JOIN tb_m_user usr ON usr.id_user=tr.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE tr.id_item_trf='" & id_trf & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TxtNumber.Text = dt.Rows(0)("number").ToString
                DECreated.EditValue = dt.Rows(0)("created_date")
                SLEStorageFrom.EditValue = dt.Rows(0)("id_comp_from").ToString
                SLEStorageTo.EditValue = dt.Rows(0)("id_comp_to").ToString
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", dt.Rows(0)("id_report_status").ToString)
                MENote.Text = dt.Rows(0)("note").ToString
                '
                viewDetail()
            End If
        End If
    End Sub

    Private Sub BtnDelDetail_Click(sender As Object, e As EventArgs) Handles BtnDelDetail.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this item ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVData.DeleteRow(GVData.FocusedRowHandle)
                CType(GCData.DataSource, DataTable).AcceptChanges()
                GCData.RefreshDataSource()
                GVData.RefreshData()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnAddDetail_Click(sender As Object, e As EventArgs) Handles BtnAddDetail.Click

    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "241"
        FormDocumentUpload.id_report = id_trf
        If LEReportStatus.EditValue.ToString = "5" Or LEReportStatus.EditValue.ToString = "6" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

    End Sub
End Class