Public Class FormFGTracking 
    Dim id_design_image As String = "0"

    Private Sub FormFGTracking_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormFGTracking_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        checkFormAccess(Name)
    End Sub

    Private Sub BtnTracking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTracking.Click
        Cursor = Cursors.WaitCursor
        Dim code As String = BtnEditCode.Text
        Dim date_from As String = "0000-01-01"
        Dim date_until As String = "9999-01-01"
        Try
            date_from = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
            date_until = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        id_design_image = "0"
        Dim query As String = "CALL view_fg_unique('" + code + "', '" + date_from + "', '" + date_until + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            If i = 0 Then
                LabelTitle.Text = data.Rows(i)("name").ToString
                LabelCode.Text = data.Rows(i)("code").ToString
                LabelSize.Text = data.Rows(i)("size").ToString
                LabelColor.Text = data.Rows(i)("color").ToString
                LabelDivision.Text = data.Rows(i)("product_division").ToString
                LabelBranding.Text = data.Rows(i)("product_branding").ToString
                LabelSource.Text = data.Rows(i)("product_source").ToString
                LabelPrice.Text = Decimal.Parse(data.Rows(i)("design_price").ToString).ToString("N2")
                LabelPriceType.Text = data.Rows(i)("design_price_type").ToString
                LabelProductStatus.Text = data.Rows(i)("design_cat").ToString
                id_design_image = data.Rows(i)("id_design").ToString
                Exit For
            End If
        Next
        GCTracking.DataSource = data
        GroupControlInfo.Enabled = True
        GroupControlTraccking.Enabled = True
        pre_viewImages("2", PictureEdit1, id_design_image, False)
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFGTracking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnViewImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewImg.Click
        pre_viewImages("2", PictureEdit1, id_design_image, True)
    End Sub

    Private Sub GVTracking_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVTracking.PopupMenuShowing
        If GVTracking.RowCount > 0 Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub SMViewDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMViewDel.Click
        Cursor = Cursors.WaitCursor
        If GVTracking.RowCount > 0 And GVTracking.GetFocusedRowCellValue("id_trans").ToString > 0 Then
            Dim id_trans As String = "-1"
            Dim report_mark_type As String = "-1"
            Try
                id_trans = GVTracking.GetFocusedRowCellValue("id_trans").ToString
                report_mark_type = GVTracking.GetFocusedRowCellValue("report_mark_type").ToString
            Catch ex As Exception
            End Try

            Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
            showpopup.report_mark_type = report_mark_type
            showpopup.id_report = id_trans
            showpopup.show()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnEditCode_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BtnEditCode.ButtonClick
        Cursor = Cursors.WaitCursor
        FormPopUpProductUnique.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnUniqueAll_Click(sender As Object, e As EventArgs) Handles BtnUniqueAll.Click
        Cursor = Cursors.WaitCursor
        FormUniqueCode.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class