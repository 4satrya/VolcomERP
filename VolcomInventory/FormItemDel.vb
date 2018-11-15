﻿Public Class FormItemDel
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"


    Private Sub FormItemDel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewRequest()
    End Sub


    Sub viewRequest()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT r.id_item_req, r.id_departement, dept.departement, r.`number`, r.created_date, r.created_by, e.employee_name AS `created_by_name`, r.note 
        FROM tb_item_req r
        INNER JOIN tb_m_user u ON u.id_user = r.created_by
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        INNER JOIN tb_m_departement dept ON dept.id_departement = r.id_departement
        LEFT JOIN (
	        SELECT rd.id_item_req 
	        FROM tb_item_req_det rd
	        INNER JOIN tb_item_req r ON r.id_item_req = rd.id_item_req
	        WHERE r.id_report_status=6 AND rd.id_prepare_status=1
	        GROUP BY rd.id_item_req
        ) rd ON rd.id_item_req = r.id_item_req
        WHERE r.id_report_status=6 AND !ISNULL(rd.id_item_req) "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRequest.DataSource = data
        GVRequest.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Sub viewDelivery()

    End Sub

    Private Sub FormItemDel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormItemDel_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormItemDel_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If XTCDel.SelectedTabPageIndex = 0 Then
            If GVRequest.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                noManipulating()
            End If
        ElseIf XTCDel.SelectedTabPageIndex = 1 Then
            If GVDelivery.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "0"
                bedit_active = "1"
                bdel_active = "0"
                noManipulating()
            End If
        End If
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = 0
            If XTCDel.SelectedTabPageIndex = 0 Then
                indeks = GVRequest.FocusedRowHandle
                If indeks < 0 Then
                    bnew_active = "0"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                End If
            ElseIf XTCDel.SelectedTabPageIndex = 1 Then
                indeks = GVDelivery.FocusedRowHandle
                If indeks < 0 Then
                    bnew_active = "0"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "0"
                    bedit_active = "1"
                    bdel_active = "0"
                End If
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVRequest_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRequest.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVDelivery_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDelivery.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVRequest_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVRequest.ColumnFilterChanged
        noManipulating()
    End Sub

    Private Sub GVDelivery_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVDelivery.ColumnFilterChanged
        noManipulating()
    End Sub

    Private Sub GVDelivery_DoubleClick(sender As Object, e As EventArgs) Handles GVDelivery.DoubleClick
        Cursor = Cursors.WaitCursor
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCDel_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCDel.SelectedPageChanged
        check_menu()
        If XTCDel.SelectedTabPageIndex = 0 Then
            viewRequest()
        ElseIf XTCDel.SelectedTabPageIndex = 1 Then
            viewDelivery()
        End If
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        If GVRequest.RowCount > 0 And GVRequest.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormItemDelReqDet.id = GVRequest.GetFocusedRowCellValue("id_item_req").ToString
            FormItemDelReqDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub
End Class