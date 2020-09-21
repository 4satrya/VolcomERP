Public Class FormTrackingReturn
    Public for_update As Boolean = False

    Private Sub FormTrackingReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = Now
        DETo.EditValue = Now

        viewSearchLookupQuery(SLEStoreGroup, "SELECT 0 AS id_comp_group, 'All' AS comp_group, 'All Group' AS description UNION SELECT cg.id_comp_group, cg.comp_group, cg.description FROM tb_m_comp_group cg", "id_comp_group", "comp_group", "id_comp_group")

        viewSearchLookupQuery(SLUEStore, "SELECT 0 AS id_comp, '' AS comp_number, 'All Store' AS comp_name, 'All Store' AS comp_combine UNION SELECT id_comp, comp_number, comp_name, CONCAT(comp_number, ' - ', comp_name) AS comp_combine FROM tb_m_comp WHERE id_comp_cat = 6", "id_comp", "comp_combine", "id_comp")

        If for_update Then
            SBUpdate.Visible = True
            GBSelect.Visible = True
            CheckEdit.Visible = True
        Else
            SBUpdate.Visible = False
            GBSelect.Visible = False
            CheckEdit.Visible = False
        End If
    End Sub

    Private Sub FormTrackingReturn_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormTrackingReturn_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormTrackingReturn_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub load_form()
        Dim datefrom As String = "0000-01-01"
        Dim dateto As String = "9999-12-31"

        Try
            datefrom = Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            dateto = Date.Parse(DETo.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "CALL view_tracking_return(" + SLEStoreGroup.EditValue.ToString + ", " + SLUEStore.EditValue.ToString + ", '" + datefrom + "', '" + dateto + "')"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        load_form()
    End Sub

    Private Sub SLEStoreGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreGroup.EditValueChanged
        Dim where_group As String = ""

        If Not SLEStoreGroup.EditValue.ToString = "0" Then
            where_group = " AND id_comp_group = " + SLEStoreGroup.EditValue.ToString
        End If

        viewSearchLookupQuery(SLUEStore, "SELECT 0 AS id_comp, '' AS comp_number, 'All Store' AS comp_name, 'All Store' AS comp_combine UNION SELECT id_comp, comp_number, comp_name, CONCAT(comp_number, ' - ', comp_name) AS comp_combine FROM tb_m_comp WHERE id_comp_cat = 6" + where_group, "id_comp", "comp_combine", "id_comp")
    End Sub

    Private Sub SBUpdate_Click(sender As Object, e As EventArgs) Handles SBUpdate.Click
        GVList.FindFilterText = ""
        GVList.ActiveFilterString = "[is_select] = 'yes'"

        If GVList.RowCount > 0 Then
            For i = 0 To GVList.RowCount - 1
                If GVList.IsValidRowHandle(i) Then
                    Dim query As String = "UPDATE tb_wh_awbill_det_in SET is_active = 2, updated_date = NOW(), updated_by = " + id_user + " WHERE id_wh_awb_det = " + GVList.GetRowCellValue(i, "id_wh_awb_det").ToString

                    execute_non_query(query, True, "", "", "", "")
                End If
            Next

            infoCustom("Status updated.")

            load_form()
        Else
            stopCustom("Please select surat jalan.")
        End If

        GVList.ActiveFilterString = ""
    End Sub

    Private Sub RepositoryItemCheckEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles RepositoryItemCheckEdit.EditValueChanging
        If GVList.GetFocusedRowCellValue("is_active").ToString = "2" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub CheckEdit_EditValueChanged(sender As Object, e As EventArgs) Handles CheckEdit.EditValueChanged
        For i = 0 To GVList.RowCount - 1
            If CheckEdit.EditValue Then
                If GVList.GetRowCellValue(i, "is_active").ToString = "1" Then
                    GVList.SetRowCellValue(i, "is_select", "yes")
                End If
            Else
                GVList.SetRowCellValue(i, "is_select", "no")
            End If
        Next
    End Sub
End Class