Public Class FormNotification
    Public id_notif As String = "-1"

    Private Sub FormNotification_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub viewNotif()
        Cursor = Cursors.WaitCursor
        Dim query_notif As String = "CALL view_notif_list('" + id_user + "','-1')"
        Dim data_notif As DataTable = execute_query(query_notif, -1, True, "", "", "", "")
        GCNotif.DataSource = data_notif
        Cursor = Cursors.Default
    End Sub

    Private Sub FormNotification_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Cursor = Cursors.WaitCursor
        FormMain.show_rb(Name)
        viewNotif()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormNotification_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormNotification_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVNotif_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVNotif.RowStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If (e.RowHandle >= 0) Then
            Dim is_read As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("is_read"))
            If is_read = "2" Or is_read = "3" Then
                e.Appearance.ForeColor = Color.White
                e.Appearance.FontStyleDelta = FontStyle.Bold
                e.Appearance.BackColor = Color.CornflowerBlue
                e.Appearance.BackColor2 = Color.CornflowerBlue
            End If
        End If
    End Sub

    Private Sub GVNotif_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVNotif.CellValueChanged

    End Sub

    Sub updAsRead(ByVal id_notif_det As String, ByVal is_read As String)
        Dim query As String = "UPDATE tb_notif_det SET is_read='" + is_read + "' WHERE id_notif_det='" + id_notif_det + "' "
        execute_non_query(query, True, "", "", "", "")
        If is_read = "1" Then
            Dim n As Integer = Integer.Parse(FormMain.Badge1.Properties.Text.ToString) - 1
            FormMain.checkTotalNotif(n)
        Else
            Dim n As Integer = Integer.Parse(FormMain.Badge1.Properties.Text.ToString) + 1
            FormMain.checkTotalNotif(n)
        End If
    End Sub

    Private Sub GVNotif_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVNotif.PopupMenuShowing
        If GVNotif.RowCount > 0 And GVNotif.FocusedRowHandle >= 0 Then
            If GVNotif.GetFocusedRowCellValue("id_notif").ToString <> "0" Then
                If GVNotif.GetFocusedRowCellValue("is_read").ToString = "1" Then 'read
                    SMUnread.Visible = True
                    SMRead.Visible = False
                    SMDelete.Visible = True
                Else
                    SMUnread.Visible = False
                    SMRead.Visible = True
                    SMDelete.Visible = True
                End If
            Else
                SMUnread.Visible = False
                SMRead.Visible = False
                SMDelete.Visible = False
            End If

            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub SMRead_Click(sender As Object, e As EventArgs) Handles SMRead.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim is_read As String = "1"
            Dim id_notif_detx As String = GVNotif.GetFocusedRowCellValue("id_notif_det").ToString
            updAsRead(id_notif_detx, is_read)
            viewNotif()
            GVNotif.FocusedRowHandle = find_row(GVNotif, "id_notif_det", id_notif_detx)
            Cursor = Cursors.Default
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub SMUnread_Click(sender As Object, e As EventArgs) Handles SMUnread.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim is_read As String = "2"
            Dim id_notif_detx As String = GVNotif.GetFocusedRowCellValue("id_notif_det").ToString
            updAsRead(id_notif_detx, is_read)
            viewNotif()
            GVNotif.FocusedRowHandle = find_row(GVNotif, "id_notif_det", id_notif_detx)
            Cursor = Cursors.Default
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub HyperlinkLabelAllRead_Click(sender As Object, e As EventArgs) Handles HyperlinkLabelAllRead.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to mark all as read?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_notif_det SET is_read='1' WHERE id_notif_det>0 AND ("
            Dim query_i As Integer = 0
            For i As Integer = 0 To ((GVNotif.RowCount - 1) - GetGroupRowCount(GVNotif))
                If query_i > 0 Then
                    query += "OR "
                End If
                query += "id_notif_det='" + GVNotif.GetRowCellValue(i, "id_notif_det").ToString + "' "
                query_i += 1
            Next
            query += ") "
            execute_non_query(query, True, "", "", "", "")
            FormMain.checkTotalNotif(0)
            viewNotif()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SMDelete_Click(sender As Object, e As EventArgs) Handles SMDelete.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim id_notif_det As String = GVNotif.GetFocusedRowCellValue("id_notif_det").ToString
            Dim query As String = "DELETE FROM tb_notif_det WHERE id_notif_det='" + id_notif_det + "' "
            execute_non_query(query, True, "", "", "", "")
            viewNotif()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVNotif_DoubleClick(sender As Object, e As EventArgs) Handles GVNotif.DoubleClick
        If GVNotif.FocusedRowHandle >= 0 And GVNotif.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_notif_detx As String = GVNotif.GetFocusedRowCellValue("id_notif_det").ToString
            Dim notif_tag As String = GVNotif.GetFocusedRowCellValue("notif_tag").ToString
            Dim id_report As String = GVNotif.GetFocusedRowCellValue("id_report").ToString
            Dim report_number As String = GVNotif.GetFocusedRowCellValue("report_number").ToString
            Dim id_type As String = GVNotif.GetFocusedRowCellValue("id_type").ToString
            Dim rmt As String = ""
            Try
                rmt = GVNotif.GetFocusedRowCellValue("report_mark_type").ToString
            Catch ex As Exception
                rmt = ""
            End Try
            If id_notif_detx <> "0" Then
                frmNotif(GVNotif.GetFocusedRowCellValue("notif_frm_to").ToString, id_report, rmt, report_number, notif_tag)
                viewNotif()
                GVNotif.FocusedRowHandle = find_row(GVNotif, "id_notif_det", id_notif_detx)
            Else
                If id_type = "1" Then
                    FormWork.MdiParent = FormMain
                    FormWork.Show()
                    FormWork.WindowState = FormWindowState.Maximized
                    FormWork.Focus()
                    FormWork.XTCGeneral.SelectedTabPageIndex = 0
                    FormWork.view_mark_need()
                ElseIf id_type = "3" Then
                    Try
                        FormFGDesignList.MdiParent = FormMain
                        FormFGDesignList.id_pop_up = "1"
                        FormFGDesignList.Show()
                        FormFGDesignList.WindowState = FormWindowState.Maximized
                        FormFGDesignList.Focus()
                        FormFGDesignList.viewData()
                    Catch ex As Exception
                        errorProcess()
                    End Try
                End If
            End If
            Cursor = Cursors.Default
        End If
    End Sub
End Class