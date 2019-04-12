Public Class FormReportMarkCancelPick
    Public id_already = ""
    Private Sub FormReportMarkCancelPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim qb As New ClassShowPopUp()
        qb.is_qb = "1"
        qb.report_mark_type = FormReportMarkCancel.LEReportMarkType.EditValue.ToString
        qb.qb_id_not_include = id_already
        qb.load_detail()

        Dim data As DataTable = execute_query(qb.query_view, -1, True, "", "", "", "")
        GCReportList.DataSource = data
        qb.apply_gv_style(GVReportList, "pick")
    End Sub

    Private Sub FormReportMarkCancelPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVReportList.RowCount > 0 Then
            For i As Integer = 0 To ((GVReportList.RowCount - 1) - GetGroupRowCount(GVReportList))
                If CheckEditSelAll.Checked = False Then
                    GVReportList.SetRowCellValue(i, "is_check", "no")
                Else
                    GVReportList.SetRowCellValue(i, "is_check", "yes")
                End If
            Next
        End If
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
        GVReportList.ActiveFilterString = "[is_check]='yes'"
        If GVReportList.RowCount > 0 Then
            For i As Integer = 0 To GVReportList.RowCount - 1
                Dim newRow As DataRow = (TryCast(FormReportMarkCancel.GCReportList.DataSource, DataTable)).NewRow()
                newRow("id_report") = GVReportList.GetRowCellValue(i, "id_report")
                For j As Integer = 1 To GVReportList.Columns.Count - 1
                    If Not GVReportList.Columns(j).FieldName.ToString = "is_check" Then
                        newRow(GVReportList.Columns(j).FieldName.ToString) = GVReportList.GetRowCellValue(i, GVReportList.Columns(j).FieldName.ToString)
                    End If
                Next
                TryCast(FormReportMarkCancel.GCReportList.DataSource, DataTable).Rows.Add(newRow)
            Next
            FormReportMarkCancel.but_show()
            Close()
        Else
            stopCustom("Please choose document first!")
        End If
        GVReportList.ActiveFilterString = ""
    End Sub

    Private Sub SMViewDet_Click(sender As Object, e As EventArgs) Handles SMViewDet.Click
        If GVReportList.RowCount > 0 Then
            Dim sp As New ClassShowPopUp()
            sp.id_report = GVReportList.GetFocusedRowCellValue("id_report").ToString
            sp.report_mark_type = FormReportMarkCancel.LEReportMarkType.EditValue.ToString
            sp.show()
        End If
    End Sub
End Class