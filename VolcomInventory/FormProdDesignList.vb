Public Class FormProdDesignList
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormProdDesignList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormProdDesignList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
    End Sub

    Sub viewSeason()
        Dim query As String = "SELECT '-1' AS id_season, 'All Season' as season UNION "
        query += "(SELECT id_season,season FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub view_design()
        Dim query_where As String = ""

        If Not SLESeason.EditValue.ToString = "-1" Then
            query_where += " AND season.id_season='" & SLESeason.EditValue.ToString & "'"
        End If

        Try
            Dim query As String = "CALL view_all_design_param(""" + query_where + """)"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDesign.DataSource = data
            BGVDesign.BestFitColumns()
            BGVDesign.ExpandAllGroups()
            check_menu()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub GVDesign_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub

    Sub check_menu()
        If BGVDesign.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub FormMasterDesignCOP_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormMasterDesignCOP_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        view_design()
    End Sub

    Private Sub CEFreeze_CheckedChanged(sender As Object, e As EventArgs) Handles CEFreeze.CheckedChanged
        If CEFreeze.Checked = True Then 'freeze band detail
            GridBandDetail.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Else 'not freeze
            GridBandDetail.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
        End If
    End Sub

    Private Sub CEShowImg_CheckedChanged(sender As Object, e As EventArgs) Handles CEShowImg.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim val As String = CEShowImg.EditValue.ToString
        If val = "True" Then
            Picture.Visible = True
            Picture.VisibleIndex = 0
        Else
            Picture.Visible = False
        End If
        GCDesign.RefreshDataSource()
        BGVDesign.RefreshData()
        Cursor = Cursors.Default
    End Sub

    Private ImageDir As String = product_image_path
    Private Images As Hashtable = New Hashtable()
    Private Sub BGVDesign_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles BGVDesign.CustomUnboundColumnData
        If e.Column.FieldName = "img" AndAlso e.IsGetData And CEShowImg.EditValue.ToString = "True" Then
            Images = Nothing
            Images = New Hashtable()
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim id As String = CStr(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "id_design"))

            Dim fileName As String = id & ".jpg".ToLower

            If (Not Images.ContainsKey(fileName)) Then
                Dim img As Image = Nothing
                Dim resizeImg As Image = Nothing

                Try

                    Dim filePath As String = DevExpress.Utils.FilesHelper.FindingFileName(ImageDir, fileName, False)
                    img = Image.FromFile(filePath)
                    resizeImg = img.GetThumbnailImage(100, 100, Nothing, Nothing)
                Catch

                End Try

                Images.Add(fileName, resizeImg)

            End If

            e.Value = Images(fileName)
        End If
    End Sub
End Class