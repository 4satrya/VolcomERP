Public Class FormPopUpMat
    Public id_mat As String = "-1"
    Public id_mat_det_price As String = "-1"
    Public id_po As String = "-1"
    Public id_pop_up As String = "-1"
    'id pop up here..
    '1 = Production MRS
    '2 = Other MRS
    Dim material_image_path As String = get_setup_field("pic_path_mat") & "\"

    Private Sub FormPopUpMat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_mat()
        If id_mat <> "-1" Then
            '
            GVMat.FocusedRowHandle = find_row(GVMat, "id_mat_det", id_mat)
            view_mat_price(GVMat.GetFocusedRowCellValue("id_mat_det").ToString)
            If id_mat_det_price <> "-1" Then
                GVMatPrice.FocusedRowHandle = find_row(GVMatPrice, "id_mat_det_price", id_mat_det_price)
            End If
        End If
        If id_pop_up = "1" Then
            'production MRS
            CEBOM.Visible = True
            BShowBOM.Visible = True
        Else
            CEBOM.Visible = False
            BShowBOM.Visible = False
        End If
    End Sub
    Sub view_mat()
        Try
            Dim query As String
            query = "CALL view_mat()"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMat.DataSource = data
            '
            If Not data.Rows.Count < 1 Then
                view_image()
                view_mat_price(GVMat.GetFocusedRowCellValue("id_mat_det").ToString)
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub view_mat_price(ByVal id_mat_det As String)
        Try
            Dim query As String
            query = "CALL view_mat_det_price_cost(" & id_mat_det & ")"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMatPrice.DataSource = data
            If data.Rows.Count > 0 Then
                BSave.Enabled = True
            Else
                BSave.Enabled = False
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub view_mat_only_bom(ByVal id_pd_design As String)
        Try
            Dim query As String
            query = "CALL view_mat_design('" & id_pd_design & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMat.DataSource = data
            '
            If Not data.Rows.Count < 1 Then
                If id_mat <> "-1" Then
                    '
                    GVMat.FocusedRowHandle = find_row(GVMat, "id_mat_det", id_mat)
                End If
                '
                view_image()
                If id_mat_det_price <> "-1" Then
                    GVMatPrice.FocusedRowHandle = find_row(GVMatPrice, "id_mat_det_price", id_mat_det_price)
                End If
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub view_image()
        If System.IO.File.Exists(material_image_path & GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString & ".jpg") Then
            PictureEdit1.LoadAsync(material_image_path & GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString & ".jpg")
        Else
            PictureEdit1.LoadAsync(material_image_path & "default" & ".jpg")
        End If
    End Sub

    Private Sub FormPopUpMat_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BView.Click
        Try
            If System.IO.File.Exists(material_image_path & GVMat.GetFocusedRowCellDisplayText("id_sample").ToString & ".jpg") Then
                Process.Start(material_image_path & GVMat.GetFocusedRowCellDisplayText("id_sample").ToString & ".jpg")
            Else
                Process.Start(material_image_path & "default" & ".jpg")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        If id_pop_up = "1" Then 'production
            If id_mat <> "-1" Then
                'edit
                'check if exist
                Dim already = False
                If FormProductionMRS.GVMat.RowCount > 0 Then
                    For i As Integer = 0 To FormProductionMRS.GVMat.RowCount - 1
                        If FormProductionMRS.GVMat.GetRowCellValue(i, "id_mat_det_price").ToString = GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString And Not GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString = id_mat_det_price Then
                            already = True
                        End If
                    Next
                End If

                If already = True Then
                    stopCustom("This material already on list.")
                Else
                    FormProductionMRS.GVMat.SetRowCellValue(FormProductionMRS.GVMat.FocusedRowHandle, "id_mat_det", GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                    FormProductionMRS.GVMat.SetRowCellValue(FormProductionMRS.GVMat.FocusedRowHandle, "id_mat_det_price", GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString)
                    FormProductionMRS.GVMat.SetRowCellValue(FormProductionMRS.GVMat.FocusedRowHandle, "size", GVMat.GetFocusedRowCellDisplayText("size").ToString)
                    FormProductionMRS.GVMat.SetRowCellValue(FormProductionMRS.GVMat.FocusedRowHandle, "mat_det_price", GVMatPrice.GetFocusedRowCellDisplayText("mat_det_price"))
                    FormProductionMRS.GVMat.SetRowCellValue(FormProductionMRS.GVMat.FocusedRowHandle, "name", GVMat.GetFocusedRowCellDisplayText("mat_det_name").ToString)
                    FormProductionMRS.GVMat.SetRowCellValue(FormProductionMRS.GVMat.FocusedRowHandle, "code", GVMat.GetFocusedRowCellDisplayText("mat_det_code").ToString)
                    FormProductionMRS.GVMat.SetRowCellValue(FormProductionMRS.GVMat.FocusedRowHandle, "color", GVMat.GetFocusedRowCellDisplayText("color").ToString)
                    FormProductionMRS.GVMat.SetRowCellValue(FormProductionMRS.GVMat.FocusedRowHandle, "qty_all_mat", GVMatPrice.GetFocusedRowCellDisplayText("qty_all_mat").ToString)
                    FormProductionMRS.GVMat.SetRowCellValue(FormProductionMRS.GVMat.FocusedRowHandle, "qty_left", GVMat.GetFocusedRowCellDisplayText("qty_left").ToString)
                    FormProductionMRS.GVMat.SetRowCellValue(FormProductionMRS.GVMat.FocusedRowHandle, "qty", 1)

                    FormProductionMRS.GVMat.FocusedRowHandle = 0
                    Close()
                End If
            Else
                'new
                'check if exist
                Dim already = False
                If FormProductionMRS.GVMat.RowCount > 0 Then
                    For i As Integer = 0 To FormProductionMRS.GVMat.RowCount - 1
                        If FormProductionMRS.GVMat.GetRowCellValue(i, "id_mat_det_price").ToString = GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString Then
                            already = True
                        End If
                    Next
                End If

                If already = True Then
                    stopCustom("Material already in list")
                Else
                    Dim newRow As DataRow = (TryCast(FormProductionMRS.GCMat.DataSource, DataTable)).NewRow()
                    newRow("id_mat_det") = GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString
                    newRow("id_mat_det_price") = GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString
                    newRow("size") = GVMat.GetFocusedRowCellDisplayText("size").ToString
                    newRow("mat_det_price") = GVMatPrice.GetFocusedRowCellDisplayText("mat_det_price")
                    newRow("name") = GVMat.GetFocusedRowCellDisplayText("mat_det_name").ToString
                    newRow("code") = GVMat.GetFocusedRowCellDisplayText("mat_det_code").ToString
                    newRow("color") = GVMat.GetFocusedRowCellDisplayText("color").ToString
                    newRow("qty_all_mat") = GVMatPrice.GetFocusedRowCellDisplayText("qty_all_mat").ToString
                    newRow("qty_left") = GVMat.GetFocusedRowCellDisplayText("qty_left").ToString
                    newRow("qty") = 1

                    TryCast(FormProductionMRS.GCMat.DataSource, DataTable).Rows.Add(newRow)
                    FormProductionMRS.GCMat.RefreshDataSource()
                    FormProductionMRS.check_but()
                    FormProductionMRS.GVMat.FocusedRowHandle = 0
                    Close()
                End If
            End If
        ElseIf id_pop_up = "2" Then 'material
            If id_mat <> "-1" Then
                'edit
                'check if exist
                Dim already = False
                If FormMatMRSDet.GVMat.RowCount > 0 Then
                    For i As Integer = 0 To FormMatMRSDet.GVMat.RowCount - 1
                        If FormMatMRSDet.GVMat.GetRowCellValue(i, "id_mat_det_price").ToString = GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString And Not GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString = id_mat_det_price Then
                            already = True
                        End If
                    Next
                End If

                If already = True Then
                    stopCustom("This material already on list.")
                Else
                    FormMatMRSDet.GVMat.SetRowCellValue(FormMatMRSDet.GVMat.FocusedRowHandle, "id_mat_det", GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                    FormMatMRSDet.GVMat.SetRowCellValue(FormMatMRSDet.GVMat.FocusedRowHandle, "id_mat_det_price", GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString)
                    FormMatMRSDet.GVMat.SetRowCellValue(FormMatMRSDet.GVMat.FocusedRowHandle, "size", GVMat.GetFocusedRowCellDisplayText("size").ToString)
                    FormMatMRSDet.GVMat.SetRowCellValue(FormMatMRSDet.GVMat.FocusedRowHandle, "name", GVMat.GetFocusedRowCellDisplayText("mat_det_name").ToString)
                    FormMatMRSDet.GVMat.SetRowCellValue(FormMatMRSDet.GVMat.FocusedRowHandle, "code", GVMat.GetFocusedRowCellDisplayText("mat_det_code").ToString)
                    FormMatMRSDet.GVMat.SetRowCellValue(FormMatMRSDet.GVMat.FocusedRowHandle, "color", GVMat.GetFocusedRowCellDisplayText("color").ToString)
                    FormMatMRSDet.GVMat.SetRowCellValue(FormMatMRSDet.GVMat.FocusedRowHandle, "uom", GVMat.GetFocusedRowCellDisplayText("uom").ToString)
                    FormMatMRSDet.GVMat.SetRowCellValue(FormMatMRSDet.GVMat.FocusedRowHandle, "qty_all_mat", GVMatPrice.GetFocusedRowCellDisplayText("qty_all_mat").ToString)
                    FormMatMRSDet.GVMat.SetRowCellValue(FormMatMRSDet.GVMat.FocusedRowHandle, "qty", 1)
                    FormMatMRSDet.GVMat.SetRowCellValue(FormMatMRSDet.GVMat.FocusedRowHandle, "qty_left", GVMat.GetFocusedRowCellDisplayText("qty_left").ToString)

                    FormMatMRSDet.GVMat.FocusedRowHandle = 0
                    Close()
                End If
            Else
                'new
                'check if exist
                Dim already = False
                If FormMatMRSDet.GVMat.RowCount > 0 Then
                    For i As Integer = 0 To FormMatMRSDet.GVMat.RowCount - 1
                        If FormMatMRSDet.GVMat.GetRowCellValue(i, "id_mat_det_price").ToString = GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString Then
                            already = True
                        End If
                    Next
                End If

                If already = True Then
                    stopCustom("Material already in list")
                Else
                    Dim newRow As DataRow = (TryCast(FormMatMRSDet.GCMat.DataSource, DataTable)).NewRow()
                    newRow("id_mat_det") = GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString
                    newRow("id_mat_det_price") = GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString
                    newRow("size") = GVMat.GetFocusedRowCellDisplayText("size").ToString
                    newRow("name") = GVMat.GetFocusedRowCellDisplayText("mat_det_name").ToString
                    newRow("code") = GVMat.GetFocusedRowCellDisplayText("mat_det_code").ToString
                    newRow("color") = GVMat.GetFocusedRowCellDisplayText("color").ToString
                    newRow("uom") = GVMat.GetFocusedRowCellDisplayText("uom").ToString
                    newRow("qty_all_mat") = GVMatPrice.GetFocusedRowCellDisplayText("qty_all_mat").ToString
                    newRow("qty_left") = GVMat.GetFocusedRowCellDisplayText("qty_left").ToString
                    newRow("qty") = 1

                    TryCast(FormMatMRSDet.GCMat.DataSource, DataTable).Rows.Add(newRow)
                    FormMatMRSDet.GCMat.RefreshDataSource()
                    FormMatMRSDet.check_but()
                    FormMatMRSDet.GVMat.FocusedRowHandle = 0
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub CEBOM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CEBOM.CheckedChanged
        If CEBOM.Checked = True Then
            'only from bom
            BShowBOM.Enabled = True
            view_mat_only_bom(get_prod_order_x(id_po, "1"))
            If GVMat.RowCount > 0 Then
                view_mat_price(GVMat.GetFocusedRowCellValue("id_mat_det").ToString)
            Else
                view_mat_price("-1")
            End If
        Else
            'all mat
            BShowBOM.Enabled = False
            view_mat()
        End If
    End Sub

    Private Sub BShowBOM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BShowBOM.Click
        FormInfoBOMMat.id_pd_design = get_prod_order_x(id_po, "1")
        FormInfoBOMMat.ShowDialog()
    End Sub

    Private Sub GVMat_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMat.FocusedRowChanged
        If GVMat.RowCount > 0 Then
            view_image()
            view_mat_price(GVMat.GetFocusedRowCellValue("id_mat_det").ToString)
        End If
    End Sub

    Private Sub GVMat_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVMat.ColumnFilterChanged
        If GVMat.RowCount > 0 Then
            view_image()
            view_mat_price(GVMat.GetFocusedRowCellValue("id_mat_det").ToString)
        End If
    End Sub
End Class