Public Class FormFGLinePlan
    Public is_view As String = "-1"
    Private Sub FormFGLinePlan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()

        'opt view 
        If is_view = "1" Then
            CESelectAll.Visible = False
            BtnImport.Visible = False
            GridColumnis_select.Visible = False
            GCData.ContextMenuStrip = Nothing
        End If
    End Sub

    Sub viewSeason()
        Dim query As String = "(SELECT a.id_season, a.season, b.range AS `range` FROM tb_season a 
                                INNER JOIN tb_range b ON a.id_range = b.id_range 
                                ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Private Sub FormFGLinePlan_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        If is_view = "1" Then
            FormMain.BBNew.Enabled = False
            FormMain.BBEdit.Enabled = False
            FormMain.BBDelete.Enabled = False
        End If
    End Sub

    Private Sub FormFGLinePlan_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewData()
        Dim query As String = "SELECT 'No' AS `is_select`,l.id_fg_line_plan, l.id_season, ss.season, l.id_delivery, del.delivery,
        l.id_division, UPPER(dv.display_name) AS `division`,
        l.id_category, cat.display_name AS `category`,
        l.id_source, UPPER(src.display_name) AS `source`,
        l.id_class, cls.display_name AS `class`,
        l.id_color, col.display_name AS `color`,
        l.description, l.`benchmark`, 
        l.qty, l.mark_up, l.target_price
        FROM tb_fg_line_plan l
        INNER JOIN tb_season ss ON ss.id_season = l.id_season
        INNER JOIN tb_season_delivery del ON del.id_delivery = l.id_delivery
        INNER JOIN tb_m_code_detail dv ON dv.id_code_detail = l.id_division
        INNER JOIN tb_m_code_detail cat ON cat.id_code_detail = l.id_category
        INNER JOIN tb_m_code_detail src ON src.id_code_detail = l.id_source
        INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = l.id_class
        LEFT JOIN tb_m_code_detail col ON col.id_code_detail = l.id_color
        WHERE l.id_season=" + SLESeason.EditValue.ToString + " 
        ORDER BY cls.display_name ASC, l.description ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GridColumnGroup.GroupIndex = 0
        GridColumnGroup.Visible = False
        GVData.BestFitColumns()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewData()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLESeason.EditValueChanged
        GCData.DataSource = Nothing
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "43"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CustomDrawGroupRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GVData.CustomDrawGroupRow
        Dim rowInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = TryCast(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo)
        If rowInfo.Column.FieldName = "group_row" Then
            Dim caption As String = String.Format("{0}:", rowInfo.Column.GetCaption())
            rowInfo.GroupText = rowInfo.GroupText.Replace(caption, "")
        End If
    End Sub

    Private Sub CESelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelectAll.CheckedChanged
        If GVData.RowCount > 0 Then
            Dim cek As String = CESelectAll.EditValue.ToString
            For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                If cek Then
                    GVData.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVData.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Private Sub DeleteThisRowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteThisRowToolStripMenuItem.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this row ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id As String = GVData.GetFocusedRowCellValue("id_fg_line_plan").ToString
                Dim qd As String = "DELETE FROM tb_fg_line_plan WHERE id_fg_line_plan='" + id + "' "
                execute_non_query(qd, True, "", "", "", "")
                viewData()
            End If
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class