Public Class FormPopUpDesign
    Public id_pop_up As String = "-1"

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewData()
        Cursor = Cursors.Default
    End Sub

    'view season
    Sub viewSeason()
        Dim query As String = ""
        query += "Select (-1) As id_season, ('All Season') AS season,  (-1) AS id_range, (0) AS `range` "
        query += "UNION ALL "
        query += "Select a.id_season, a.season, b.id_range, b.`range`  "
        query += "From tb_season a "
        query += "INNER Join tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY `range` ASC "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub viewData()
        GVDesign.OptionsFind.AlwaysVisible = True
        GVDesign.ShowFindPanel()
        GVDesign.ShowFindPanel()
        Dim id_ss As String = SLESeason.EditValue.ToString
        Dim cond As String = ""
        If id_ss = "-1" Then
            cond = "-1"
        Else
            cond = "And f1.id_season=" + id_ss + " "
        End If
        Dim query As String = "CALL view_all_design_param('" + cond + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesign.DataSource = data
    End Sub

    Private Sub FormPopUpDesign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
        SLESeason.Focus()
    End Sub

    Private Sub SLESeason_KeyDown(sender As Object, e As KeyEventArgs) Handles SLESeason.KeyDown
        If e.KeyCode = Keys.Enter Then
            viewData()
        End If
    End Sub

    Private Sub GVDesign_KeyDown(sender As Object, e As KeyEventArgs) Handles GVDesign.KeyDown
        If e.KeyCode = Keys.Enter Then
            choose()
        End If
    End Sub

    Private Sub GCDesign_KeyDown(sender As Object, e As KeyEventArgs) Handles GCDesign.KeyDown
        If e.KeyCode = Keys.Enter Then

        End If
    End Sub

    Sub choose()
        Cursor = Cursors.WaitCursor
        If GVDesign.RowCount > 0 Then
            If id_pop_up = "1" Then
                FormFGStock.TxtCodeDsgSC.Text = GVDesign.GetFocusedRowCellValue("design_code").ToString
                FormFGStock.id_design_selected = GVDesign.GetFocusedRowCellValue("id_design").ToString.ToUpper
                FormFGStock.LabelControl5.Text = GVDesign.GetFocusedRowCellValue("design_display_name").ToString.ToUpper
                FormFGStock.LabelColor.Text = GVDesign.GetFocusedRowCellValue("color").ToString.ToUpper
                FormFGStock.LabelBranding.Text = GVDesign.GetFocusedRowCellValue("product_class").ToString.ToUpper + " (" + GVDesign.GetFocusedRowCellValue("product_class_display").ToString.ToUpper + ")"
                FormFGStock.LabelSource.Text = GVDesign.GetFocusedRowCellValue("size_chart").ToString.ToUpper
                FormFGStock.LabelCurrentPrice.Text = GVDesign.GetFocusedRowCellValue("design_price").ToString.ToUpper
                FormFGStock.LabelPriceType.Text = GVDesign.GetFocusedRowCellValue("design_price_type").ToString.ToUpper
                pre_viewImages("2", FormFGStock.PictureEdit1, FormFGStock.id_design_selected, False)
                FormFGStock.GroupControlInfo.Enabled = True
                FormFGStock.GroupControlTraccking.Enabled = True
                FormFGStock.GCFGStockCard.DataSource = Nothing
                Close()
                FormFGStock.TxtCodeDsgSC.Focus()
            ElseIf id_pop_up = "2" Then
                FormProductionAssemblyNew.id_design = GVDesign.GetFocusedRowCellValue("id_design").ToString
                FormProductionAssemblyNew.ButtonEdit1.Text = GVDesign.GetFocusedRowCellValue("design_code").ToString
                FormProductionAssemblyNew.TxtDesign.Text = GVDesign.GetFocusedRowCellValue("design_display_name").ToString
                Close()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        choose()
    End Sub

    Private Sub FormPopUpDesign_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPopUpDesign_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If id_pop_up = "1" Then
            SLESeason.ShowPopup()
        End If
    End Sub
End Class