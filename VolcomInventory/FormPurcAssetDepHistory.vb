Public Class FormPurcAssetDepHistory
    Public cond As String = "-1"

    Private Sub FormPurcAssetDepHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim hist As New ClassPurcAsset()

        'condition
        Dim query As String = hist.queryMainDepHistory(cond, "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCHistory.DataSource = data
        GVHistory.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPurcAssetDepHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        If GVHistory.RowCount > 0 And GVHistory.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id As String = GVHistory.GetFocusedRowCellValue("id_purc_rec_asset_dep").ToString
            Dim id_acc_trans As String = ""
            Try
                id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=161 AND ad.id_report=" + id + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
            Catch ex As Exception
                id_acc_trans = ""
            End Try

            If id_acc_trans <> "" Then
                Dim s As New ClassShowPopUp()
                FormViewJournal.is_enable_view_doc = False
                FormViewJournal.BMark.Visible = False
                s.id_report = id_acc_trans
                s.report_mark_type = "36"
                s.show()
            Else
                warningCustom("Auto journal not found.")
            End If
            Cursor = Cursors.Default
        End If
    End Sub
End Class