Public Class FormPopUpMatRetProd
    Public id_prod_order_wo As String = "-1"
    Public id_prod_order As String = "-1"
    '
    Public id_pl_mrs_det As String = "-1"
    Public id_pop_up As String = "-1"
    Dim material_image_path As String = get_setup_field("pic_path_mat") & "\"

    Private Sub FormPopUpMatRetProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_mat_wo()
        If Not id_pl_mrs_det = "-1" Then 'edit
            GVMat.FocusedRowHandle = find_row(GVMat, "id_pl_mrs_det", id_pl_mrs_det)
        Else 'new

        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormPopUpMatRetProd_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub view_mat_wo()
        Try
            Dim query As String
            query = "CALL view_mat_prod(" & id_prod_order & ")"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMat.DataSource = data
            '
            If Not data.Rows.Count < 1 Then
                GVMat.FocusedRowHandle = 0
                view_image()
                BSave.Enabled = True
            Else
                BSave.Enabled = False
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

    Private Sub GVMat_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMat.FocusedRowChanged
        view_image()
        If GVMat.IsGroupRow(e.FocusedRowHandle) Then
            BSave.Enabled = False
        Else
            BSave.Enabled = True
        End If
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        If id_pop_up = "1" Then 'form mat ret in prod
            If id_pl_mrs_det = "-1" Then 'new
                'check if exist
                Dim already = False
                If FormMatRetInProd.GVRetDetail.RowCount > 0 Then
                    For i As Integer = 0 To FormMatRetInProd.GVRetDetail.RowCount - 1
                        If FormMatRetInProd.GVRetDetail.GetRowCellValue(i, "id_pl_mrs_det").ToString = GVMat.GetFocusedRowCellDisplayText("id_pl_mrs_det").ToString Then
                            already = True
                        End If
                    Next
                End If

                If already = True Then
                    stopCustom("Material already in list")
                Else
                    Dim newRow As DataRow = (TryCast(FormMatRetInProd.GCRetDetail.DataSource, DataTable)).NewRow()
                    newRow("id_pl_mrs_det") = GVMat.GetFocusedRowCellDisplayText("id_pl_mrs_det").ToString
                    newRow("id_mat_det_price") = GVMat.GetFocusedRowCellDisplayText("id_mat_det_price").ToString
                    newRow("pl_mrs_det_price") = GVMat.GetFocusedRowCellDisplayText("pl_mrs_det_price")
                    newRow("pl_mrs_number") = GVMat.GetFocusedRowCellDisplayText("pl_mrs_number")
                    newRow("mat_det_name") = GVMat.GetFocusedRowCellDisplayText("mat_det_name").ToString
                    newRow("mat_det_code") = GVMat.GetFocusedRowCellDisplayText("mat_det_code").ToString
                    newRow("size") = GVMat.GetFocusedRowCellDisplayText("size").ToString
                    newRow("color") = GVMat.GetFocusedRowCellDisplayText("color").ToString
                    newRow("uom") = GVMat.GetFocusedRowCellDisplayText("uom").ToString
                    newRow("mat_prod_ret_in_det_qty") = 1

                    TryCast(FormMatRetInProd.GCRetDetail.DataSource, DataTable).Rows.Add(newRow)
                    FormMatRetInProd.GCRetDetail.RefreshDataSource()
                    FormMatRetInProd.check_but()
                    FormMatRetInProd.GVRetDetail.FocusedRowHandle = 0
                    Close()
                End If
            Else 'edit
                'check if exist
                Dim already = False
                If FormMatRetInProd.GVRetDetail.RowCount > 0 Then
                    For i As Integer = 0 To FormMatRetInProd.GVRetDetail.RowCount - 1
                        If FormMatRetInProd.GVRetDetail.GetRowCellValue(i, "id_pl_mrs_det").ToString = GVMat.GetFocusedRowCellDisplayText("id_pl_mrs_det").ToString() And Not GVMat.GetFocusedRowCellDisplayText("id_pl_mrs_det").ToString() = id_pl_mrs_det Then
                            already = True
                        End If
                    Next
                End If

                If already = True Then
                    stopCustom("Material already in list")
                Else
                    FormMatRetInProd.GVRetDetail.SetRowCellValue(FormMatRetInProd.GVRetDetail.FocusedRowHandle, "id_pl_mrs_det", GVMat.GetFocusedRowCellDisplayText("id_pl_mrs_det").ToString)
                    FormMatRetInProd.GVRetDetail.SetRowCellValue(FormMatRetInProd.GVRetDetail.FocusedRowHandle, "id_mat_det_price", GVMat.GetFocusedRowCellDisplayText("id_mat_det_price").ToString)
                    FormMatRetInProd.GVRetDetail.SetRowCellValue(FormMatRetInProd.GVRetDetail.FocusedRowHandle, "pl_mrs_det_price", GVMat.GetFocusedRowCellDisplayText("pl_mrs_det_price").ToString)
                    FormMatRetInProd.GVRetDetail.SetRowCellValue(FormMatRetInProd.GVRetDetail.FocusedRowHandle, "pl_mrs_number", GVMat.GetFocusedRowCellDisplayText("pl_mrs_number").ToString)
                    FormMatRetInProd.GVRetDetail.SetRowCellValue(FormMatRetInProd.GVRetDetail.FocusedRowHandle, "mat_det_name", GVMat.GetFocusedRowCellDisplayText("mat_det_name").ToString)
                    FormMatRetInProd.GVRetDetail.SetRowCellValue(FormMatRetInProd.GVRetDetail.FocusedRowHandle, "mat_det_code", GVMat.GetFocusedRowCellDisplayText("mat_det_code").ToString)
                    FormMatRetInProd.GVRetDetail.SetRowCellValue(FormMatRetInProd.GVRetDetail.FocusedRowHandle, "size", GVMat.GetFocusedRowCellDisplayText("size").ToString)
                    FormMatRetInProd.GVRetDetail.SetRowCellValue(FormMatRetInProd.GVRetDetail.FocusedRowHandle, "color", GVMat.GetFocusedRowCellDisplayText("color").ToString)
                    FormMatRetInProd.GVRetDetail.SetRowCellValue(FormMatRetInProd.GVRetDetail.FocusedRowHandle, "uom", GVMat.GetFocusedRowCellDisplayText("uom").ToString)
                    FormMatRetInProd.GVRetDetail.SetRowCellValue(FormMatRetInProd.GVRetDetail.FocusedRowHandle, "mat_prod_ret_in_det_qty", 1)

                    FormMatRetInProd.GVRetDetail.FocusedRowHandle = 0
                    FormMatRetInProd.check_but()
                    Close()
                End If
            End If
        End If
    End Sub
End Class