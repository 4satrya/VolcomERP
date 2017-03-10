Public Class FormProductionSummary
    Private Sub FormProductionSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        DEFromPD.EditValue = data_dt.Rows(0)("dt")
        DEUntilPD.EditValue = data_dt.Rows(0)("dt")
        DEFrom.Focus()
    End Sub

    Private Sub FormProductionSummary_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
    End Sub

    Private Sub FormProductionSummary_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewApprovedPO()
        Cursor = Cursors.WaitCursor
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "CALL view_po_approved('" + date_from_selected + "', '" + date_until_selected + "', '" + id_user + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesign.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewApprovedPO()
    End Sub

    Private Sub DEFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntil.Focus()
        End If
    End Sub

    Private Sub DEUntil_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntil.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnView.Focus()
        End If
    End Sub

    Private Sub XTCSum_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSum.SelectedPageChanged
        If XTCSum.SelectedTabPageIndex = 0 Then
            DEFrom.Focus()
        ElseIf XTCSum.SelectedTabPageIndex = 1 Then
            DEFromPD.Focus()
        End If
    End Sub

    Private Sub BtnViewPD_Click(sender As Object, e As EventArgs) Handles BtnViewPD.Click
        viewPD()
    End Sub

    Sub viewPD()
        Cursor = Cursors.WaitCursor
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromPD.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilPD.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "CALL view_pd_list('" + date_from_selected + "', '" + date_until_selected + "', '" + id_user + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPD.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub DEFromPD_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromPD.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilPD.Focus()
        End If
    End Sub

    Private Sub DEUntilPD_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilPD.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewPD.Focus()
        End If
    End Sub

    Private Sub FormProductionSummary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVPD_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVPD.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim row_foc As Integer = e.RowHandle
        Dim col As String = e.Column.FieldName.ToString
        If col = "is_select" Then
            Dim val As String = e.Value.ToString()
            Dim id_report As String = GVPD.GetRowCellValue(row_foc, "id_prod_demand").ToString()
            Dim id_source As String = GVPD.GetRowCellValue(row_foc, "id_source").ToString()
            If val = "Yes" Then
                Dim query As String = "DELETE FROM tb_work_pd WHERE id_report=" + id_report + " AND id_source=" + id_source + " AND id_user=" + id_user + ";
                INSERT INTO tb_work_pd VALUES('" + id_user + "', '" + id_report + "', '" + id_source + "', NOW()); "
                execute_non_query(query, True, "", "", "", "")
            Else
                Dim query As String = "DELETE FROM tb_work_pd WHERE id_report=" + id_report + " AND id_source=" + id_source + " AND id_user=" + id_user + "; "
                execute_non_query(query, True, "", "", "", "")
            End If
        End If
        GCPD.RefreshDataSource()
        GVPD.RefreshData()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVPD_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVPD.RowStyle
        If e.RowHandle >= 0 Then
            Dim val As String = ""
            Try
                val = sender.GetRowCellValue(e.RowHandle, sender.Columns("is_select"))
            Catch ex As Exception

            End Try
            If val = "Yes" Then
                e.Appearance.BackColor = Color.Yellow
                e.Appearance.BackColor2 = Color.Yellow
            Else
                e.Appearance.BackColor = Color.White
                e.Appearance.BackColor2 = Color.White
            End If
        End If
    End Sub

    Private Sub GVDesign_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVDesign.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim row_foc As Integer = e.RowHandle
        Dim col As String = e.Column.FieldName.ToString
        If col = "is_select" Then
            Dim val As String = e.Value.ToString()
            Dim id_report As String = GVDesign.GetRowCellValue(row_foc, "id_prod_order").ToString()
            If val = "Yes" Then
                Dim query As String = "DELETE FROM tb_work_po WHERE id_report=" + id_report + " AND id_user=" + id_user + ";
                INSERT INTO tb_work_po VALUES('" + id_user + "', '" + id_report + "', NOW()); "
                execute_non_query(query, True, "", "", "", "")
            Else
                Dim query As String = "DELETE FROM tb_work_po WHERE id_report=" + id_report + " AND id_user=" + id_user + "; "
                execute_non_query(query, True, "", "", "", "")
            End If
        End If
        GCDesign.RefreshDataSource()
        GVDesign.RefreshData()
        Cursor = Cursors.Default
    End Sub


    Private Sub GVDesign_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVDesign.RowStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If (e.RowHandle >= 0) Then
            Dim category As String = View.GetRowCellValue(e.RowHandle, View.Columns("is_select"))
            If category = "Yes" Then
                e.Appearance.BackColor = Color.Yellow
                e.Appearance.BackColor2 = Color.Yellow
            Else
                e.Appearance.BackColor = Color.White
                e.Appearance.BackColor2 = Color.White
            End If
        End If
    End Sub
End Class