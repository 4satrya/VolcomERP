Public Class FormSampleReceive
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bcontact_active As String = "1"

    Private Sub FormSampleReceive_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_sample_rec()
        view_sample_purc()
    End Sub

    Sub view_sample_rec()
        Dim query = "SELECT a.id_report_status,h.report_status,g.season_orign,a.id_sample_purc_rec,a.sample_purc_rec_number,a.delivery_order_date,a.delivery_order_number,b.sample_purc_number,a.sample_purc_rec_date, f.comp_name AS comp_from,d.comp_name AS comp_to "
        query += "FROM tb_sample_purc_rec a INNER JOIN tb_sample_purc b ON a.id_sample_purc=b.id_sample_purc "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact=b.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp f ON f.id_comp=e.id_comp "
        query += "INNER JOIN tb_season_orign g ON g.id_season_orign=b.id_season_orign "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status=a.id_report_status "
        query += "ORDER BY g.id_season_orign DESC, a.id_sample_purc_rec DESC "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleReceive.DataSource = data
        check_menu()
    End Sub

    Private Sub FormSampleReceive_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSampleReceive_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormSampleReceive_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVSamplePurchase_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSampleReceive.FocusedRowChanged
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

    Sub view_sample_purc()
        Dim query = "SELECT a.id_sample_purc,NOW() as date_now, "
        query += "a.id_season_orign, "
        query += "b.season_orign, g.payment,"
        query += "d.comp_name AS comp_name_to, "
        query += "f.comp_name AS comp_name_ship_to, "
        query += "a.sample_purc_number,"
        query += "(SELECT COUNT(tb_sample_purc_rec.id_sample_purc_rec) FROM tb_sample_purc_rec WHERE tb_sample_purc_rec.id_sample_purc = a.id_sample_purc) AS qty_receive, "
        query += "a.sample_purc_date, "
        query += "DATE_ADD(a.sample_purc_date,INTERVAL a.sample_purc_lead_time DAY) AS sample_purc_lead_time, "
        query += "DATE_ADD(a.sample_purc_date,INTERVAL (a.sample_purc_top+a.sample_purc_lead_time) DAY) AS sample_purc_top "
        query += "FROM tb_sample_purc a INNER JOIN tb_season_orign b ON a.id_season_orign = b.id_season_orign "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_to = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment "
        query += "WHERE a.id_report_status = '6' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSamplePurchaseNeed.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            view_list_purchase(GVSamplePurchaseNeed.GetFocusedRowCellValue("id_sample_purc").ToString)
        End If
    End Sub

    Sub view_list_purchase(ByVal id_sample_purc As String)
        Dim query = "CALL view_purc_sample_det('" & id_sample_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
    End Sub

    Sub check_menu()
        If XTCTabReceive.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVSampleReceive.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
        ElseIf XTCTabReceive.SelectedTabPageIndex = 1 Then
            'based on PO
            If GVSamplePurchaseNeed.RowCount < 1 Then
                'hide all
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
        End If
    End Sub

    Private Sub XTCTabReceive_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCTabReceive.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVSamplePurchaseNeed_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSamplePurchaseNeed.FocusedRowChanged
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

    Private Sub GVSamplePurchaseNeed_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVSamplePurchaseNeed.RowClick
        view_list_purchase(GVSamplePurchaseNeed.GetFocusedRowCellValue("id_sample_purc").ToString)
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVSamplePurchaseNeed_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSamplePurchaseNeed.DoubleClick
        If GVSamplePurchaseNeed.RowCount > 0 Then
            GVSampleReceive.ApplyFindFilter(GVSamplePurchaseNeed.GetFocusedRowCellValue("sample_purc_number").ToString)
            XTCTabReceive.SelectedTabPageIndex = 0
            check_menu()
        End If
    End Sub

    Private Sub GVSamplePurchaseNeed_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVSamplePurchaseNeed.RowCellStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        Dim date_now As Date
        Dim date_rec As Date

        If e.Column.FieldName = "qty_receive" Then
            date_now = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("date_now")))
            date_rec = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("sample_purc_lead_time")))
            If date_now > date_rec And View.GetRowCellDisplayText(e.RowHandle, View.Columns("qty_receive")) <= 0 Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.BackColor2 = Color.LightSalmon
            End If
        End If
    End Sub
End Class