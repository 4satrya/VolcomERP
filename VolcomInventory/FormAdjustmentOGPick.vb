﻿Public Class FormAdjustmentOGPick
    Private Sub FormAdjustmentOGPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_until_selected As String = Date.Parse(Now).ToString("yyyy-MM-dd")

        Dim dept As String = FormAdjustmentOGDet.SLUEFromDepartment.EditValue.ToString
        Dim cat As String = "0"
        '
        If dept = "-1" Then
            dept = ""
        Else
            dept = "AND i.id_departement=" + dept + ""
        End If

        Dim stc As New ClassPurcItemStock()
        Dim query As String = stc.queryGetStock(dept, cat, date_until_selected)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        GVList.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        Dim data As DataTable = FormAdjustmentOGDet.GCList.DataSource

        Dim row As DataRow = data.NewRow

        row("id_item") = GVList.GetFocusedRowCellValue("id_item")
        row("item_desc") = GVList.GetFocusedRowCellValue("item_desc")
        row("uom") = GVList.GetFocusedRowCellValue("uom")
        row("item_cat") = GVList.GetFocusedRowCellValue("item_cat")
        row("qty") = 0
        row("value") = GVList.GetFocusedRowCellValue("value")

        data.Rows.Add(row)

        FormAdjustmentOGDet.GCList.DataSource = data

        Close()
    End Sub
End Class