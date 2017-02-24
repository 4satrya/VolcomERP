Public Class FormMatRet
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bnew_active2 As String = "1"
    Dim bedit_active2 As String = "1"
    Dim bdel_active2 As String = "1"

    Private Sub FormMatRet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewRetOut()
        viewRetIn()
        viewRetInProd()
    End Sub

    Private Sub FormMatRet_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        pageChanged()
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormMatRet_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    'Seleceted Page Changed
    Private Sub XTCReturn_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCReturnPruchase.SelectedPageChanged
        pageChanged()
    End Sub
    Sub pageChanged()
        If XTCReturnMat.SelectedTabPageIndex = 0 Then 'Purchase
            If XTCReturnPruchase.SelectedTabPageIndex = 0 Then 'Return Out
                If GVRetOut.RowCount > 0 Then
                    bnew_active = 1
                    bedit_active = 1
                    bdel_active = 1
                Else
                    bnew_active = 1
                    bedit_active = 0
                    bdel_active = 0
                End If
                button_main(bnew_active, bedit_active, bdel_active)
            Else  'Return In
                If GVRetIn.RowCount > 0 Then
                    bnew_active = 1
                    bedit_active = 1
                    bdel_active = 1
                Else
                    bnew_active = 1
                    bedit_active = 0
                    bdel_active = 0
                End If
                button_main(bnew_active, bedit_active, bdel_active)
            End If
        Else
            If GVRetInProd.RowCount > 0 Then
                bnew_active = 1
                bedit_active = 1
                bdel_active = 1
            Else
                bnew_active = 1
                bedit_active = 0
                bdel_active = 0
            End If
            button_main(bnew_active, bedit_active, bdel_active)
        End If

    End Sub
    'View Data
    Sub viewRetOut()
        Try
            Dim query As String = "SELECT a.id_report_status,i.report_status,a.id_mat_purc_ret_out, a.mat_purc_ret_out_date, a.mat_purc_ret_out_due_date, a.mat_purc_ret_out_note,  "
            query += "a.mat_purc_ret_out_number , b.mat_purc_number, c.season, (e.comp_name) AS comp_from, (g.comp_name) AS comp_to "
            query += "FROM tb_mat_purc_ret_out a "
            query += "INNER JOIN tb_mat_purc b ON a.id_mat_purc = b.id_mat_purc "
            query += "INNER JOIN tb_season_delivery h ON b.id_delivery = h.id_delivery "
            query += "INNER JOIN tb_season c ON h.id_season = c.id_season "
            query += "INNER JOIN tb_m_comp_contact d ON d.id_comp_contact = a.id_comp_contact_from "
            query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
            query += "INNER JOIN tb_m_comp_contact f ON f.id_comp_contact = a.id_comp_contact_to "
            query += "INNER JOIN tb_m_comp g ON f.id_comp = g.id_comp "
            query += "INNER JOIN tb_lookup_report_status i ON i.id_report_status = a.id_report_status "
            query += "ORDER BY a.id_mat_purc_ret_out DESC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCRetOut.DataSource = data
            If data.Rows.Count > 0 Then
                bnew_active = 1
                bdel_active = 1
                bedit_active = 1
            Else
                bnew_active = 1
                bdel_active = 0
                bedit_active = 0
            End If
            pageChanged()
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
    End Sub
    Sub viewRetIn()
        Try
            Dim query As String = "SELECT a.id_report_status,i.report_status,a.id_mat_purc_ret_in, a.mat_purc_ret_in_date, a.mat_purc_ret_in_note,  "
            query += "a.mat_purc_ret_in_number , b.mat_purc_number, c.season, (e.comp_name) AS comp_from, (g.comp_name) AS comp_to "
            query += "FROM tb_mat_purc_ret_in a "
            query += "INNER JOIN tb_mat_purc b ON a.id_mat_purc = b.id_mat_purc "
            query += "INNER JOIN tb_season_delivery h ON b.id_delivery = h.id_delivery "
            query += "INNER JOIN tb_season c ON h.id_season = c.id_season "
            query += "INNER JOIN tb_m_comp_contact d ON d.id_comp_contact = a.id_comp_contact_from "
            query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
            query += "INNER JOIN tb_m_comp_contact f ON f.id_comp_contact = a.id_comp_contact_to "
            query += "INNER JOIN tb_m_comp g ON f.id_comp = g.id_comp "
            query += "INNER JOIN tb_lookup_report_status i ON i.id_report_status = a.id_report_status "
            query += "ORDER BY a.id_mat_purc_ret_in DESC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCRetIn.DataSource = data
            If data.Rows.Count > 0 Then
                bnew_active2 = 1
                bdel_active2 = 1
                bedit_active2 = 1
            Else
                bnew_active2 = 1
                bdel_active2 = 0
                bedit_active2 = 0
            End If
            pageChanged()
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
    End Sub
    Sub viewRetInProd()
        Try
            Dim query As String = "SELECT a.id_report_status,i.report_status,a.id_mat_prod_ret_in, a.mat_prod_ret_in_date, a.mat_prod_ret_in_note,h.prod_order_number,b.prod_order_wo_number,desg.design_name,  "
            query += "a.mat_prod_ret_in_number , (e.comp_name) AS comp_from "
            query += "FROM tb_mat_prod_ret_in a "
            query += "INNER JOIN tb_prod_order_wo b ON a.id_prod_order_wo = b.id_prod_order_wo "
            query += "INNER JOIN tb_prod_order h ON b.id_prod_order = h.id_prod_order "
            query += "INNER JOIN tb_prod_demand_design pd_desg ON pd_desg.id_prod_demand_design = h.id_prod_demand_design "
            query += "INNER JOIN tb_m_design desg ON desg.id_design = pd_desg.id_design "
            query += "INNER JOIN tb_m_comp_contact d ON d.id_comp_contact = a.id_comp_contact_from "
            query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
            query += "INNER JOIN tb_lookup_report_status i ON i.id_report_status = a.id_report_status ORDER BY a.id_mat_prod_ret_in DESC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCRetInProd.DataSource = data
            If data.Rows.Count > 0 Then
                bnew_active2 = 1
                bdel_active2 = 1
                bedit_active2 = 1
            Else
                bnew_active2 = 1
                bdel_active2 = 0
                bedit_active2 = 0
            End If
            pageChanged()
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
    End Sub
    'Focus Row Changed
    Private Sub GVRetOut_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetOut.FocusedRowChanged
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

    Private Sub GVRetIn_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetIn.FocusedRowChanged
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

    Private Sub XTCReturnMat_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCReturnMat.SelectedPageChanged
        pageChanged()
    End Sub
End Class