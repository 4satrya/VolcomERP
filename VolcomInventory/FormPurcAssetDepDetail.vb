Public Class FormPurcAssetDepDetail
    Public id_asset As String = ""

    Private Sub FormPurcAssetDepDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = ""

        'first month
        Dim acq_date As String = Date.Parse(FormPurcAsset.GVDep.GetFocusedRowCellValue("acq_date").ToString).ToString("yyyy-MM-dd")
        Dim expired_date As String = Date.Parse(FormPurcAsset.GVDep.GetFocusedRowCellValue("expired_date").ToString).ToString("yyyy-MM-dd")
        Dim last_dep_date As String = ""
        Try
            last_dep_date = Date.Parse(FormPurcAsset.GVDep.GetFocusedRowCellValue("last_dep_date").ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        If FormPurcAsset.GVDep.GetFocusedRowCellValue("dep_first_month") > 0 Then
            query += "SELECT DATE_FORMAT('" + acq_date + "','%M %Y') AS `period`, " + decimalSQL(FormPurcAsset.GVDep.GetFocusedRowCellValue("dep_first_month").ToString) + " AS `dep_value` "
        End If


        'full day
        If FormPurcAsset.GVDep.GetFocusedRowCellValue("full_day") > 0 Then
            If query <> "" Then
                query += "UNION ALL "
            End If
            For i As Integer = 1 To FormPurcAsset.GVDep.GetFocusedRowCellValue("full_day")
                If i > 1 Then
                    query += "UNION ALL "
                End If
                query += "SELECT "
                If FormPurcAsset.GVDep.GetFocusedRowCellValue("dep_first_month") > 0 Then
                    query += "DATE_FORMAT(DATE_ADD('" + acq_date + "', INTERVAL " + i.ToString + " MONTH),'%M %Y') AS `period`, "
                Else
                    query += "DATE_FORMAT(DATE_ADD('" + last_dep_date + "', INTERVAL " + i.ToString + " MONTH),'%M %Y') AS `period`, "
                End If
                query += decimalSQL(FormPurcAsset.GVDep.GetFocusedRowCellValue("dep_full_day").ToString) + " AS `dep_value` "
            Next
        End If

        'last_ month
        If FormPurcAsset.GVDep.GetFocusedRowCellValue("dep_last_month") > 0 Then
            If query <> "" Then
                query += "UNION ALL "
            End If
            query += "SELECT DATE_FORMAT('" + expired_date + "','%M %Y') AS `period`, " + decimalSQL(FormPurcAsset.GVDep.GetFocusedRowCellValue("dep_last_month").ToString) + " AS `dep_value` "
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
    End Sub

    Private Sub FormPurcAssetDepDetail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub LabelLinkAssetNumber_Click(sender As Object, e As EventArgs) Handles LabelLinkAssetNumber.Click
        Cursor = Cursors.WaitCursor
        Dim p As New ClassShowPopUp()
        p.report_mark_type = "160"
        p.id_report = id_asset
        p.show()
        Cursor = Cursors.Default
    End Sub
End Class