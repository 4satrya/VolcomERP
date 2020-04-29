Public Class FormItemTrf
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"

    Private Sub FormSalesPOS_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSalesPOS_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormItemTrf_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_list()

    End Sub

    Private Sub FormItemTrf_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BNew_Click(sender As Object, e As EventArgs) Handles BNew.Click
        FormItemTrfDet.id_trf = "-1"
        FormItemTrfDet.ShowDialog()
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        If GVTrf.RowCount > 0 Then
            If Not check_edit_report_status(GVTrf.GetFocusedRowCellValue("id_report_status").ToString, "241", GVTrf.GetFocusedRowCellValue("id_item_trf").ToString) Or GVTrf.GetFocusedRowCellValue("id_report_status").ToString = "5" Then
                stopCustom("This data already locked.")
            Else
                Cursor = Cursors.WaitCursor

                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim q As String = String.Format("DELETE FROM tb_item_trf WHERE id_item_trf ='{0}'", GVTrf.GetFocusedRowCellValue("id_item_trf").ToString)
                        execute_non_query(q, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("241", GVTrf.GetFocusedRowCellValue("id_item_trf").ToString)
                        load_list()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                End If
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BEdit_Click(sender As Object, e As EventArgs) Handles BEdit.Click
        If GVTrf.RowCount > 0 Then
            FormItemTrfDet.id_trf = GVTrf.GetFocusedRowCellValue("id_item_trf")
            FormItemTrfDet.ShowDialog()
        End If
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        load_list()
    End Sub
End Class