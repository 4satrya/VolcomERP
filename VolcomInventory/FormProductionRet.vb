Public Class FormProductionRet 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bnew_active2 As String = "1"
    Dim bedit_active2 As String = "1"
    Dim bdel_active2 As String = "1"

    'Form Load
    Private Sub FormProductionRet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewRetOut()
        viewRetIn()
    End Sub
    'Activated Form
    Private Sub FormProductionRet_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        pageChanged()
    End Sub
    'Deadactivate Form
    Private Sub FormProductionRet_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    'Seleceted Page Changed
    Private Sub XTCReturn_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCReturn.SelectedPageChanged
        pageChanged()
    End Sub
    Sub pageChanged()
        noManipulating()
    End Sub

    Sub noManipulating()
        Dim indeks As Integer = -1
        Try
            If XTCReturn.SelectedTabPageIndex = 0 Then
                indeks = GVRetOut.FocusedRowHandle
            ElseIf XTCReturn.SelectedTabPageIndex = 1 Then
                indeks = GVRetIn.FocusedRowHandle
            End If
        Catch ex As Exception
        End Try

        If XTCReturn.SelectedTabPageIndex = 0 Then
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        ElseIf XTCReturn.SelectedTabPageIndex = 1 Then
            If indeks < 0 Then
                bnew_active2 = "1"
                bedit_active2 = "0"
                bdel_active2 = "0"
            Else
                bnew_active2 = "1"
                bedit_active2 = "1"
                bdel_active2 = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active2, bedit_active2, bdel_active2)
        End If
    End Sub
    'View Data
    Sub viewRetOut()
        Try
            Dim query As String = "SELECT h.id_report_status, h.report_status, a.id_prod_order_ret_out, a.prod_order_ret_out_date, a.prod_order_ret_out_due_date, a.prod_order_ret_out_note,  "
            query += "a.prod_order_ret_out_number , b.prod_order_number, c.id_season, c.season, CONCAT(e.comp_number,' - ',e.comp_name) AS comp_from, CONCAT(g.comp_number,' - ',g.comp_name) AS comp_to, dsg.design_code AS `code`, dsg.design_display_name AS `name`, SUM(ad.prod_order_ret_out_det_qty) AS `qty` "
            query += "FROM tb_prod_order_ret_out a "
            query += "INNER JOIN tb_prod_order_ret_out_det ad ON ad.id_prod_order_ret_out = a.id_prod_order_ret_out "
            query += "INNER JOIN tb_prod_order b ON a.id_prod_order = b.id_prod_order "
            query += "INNER JOIN tb_prod_demand_design b1 ON b.id_prod_demand_design = b1.id_prod_demand_design "
            query += "INNER JOIN tb_m_design dsg ON dsg.id_design = b1.id_design "
            query += "INNER JOIN tb_prod_demand b2 ON b2.id_prod_demand = b1.id_prod_demand "
            query += "INNER JOIN tb_season c ON b2.id_season = c.id_season "
            query += "INNER JOIN tb_m_comp_contact d ON d.id_comp_contact = a.id_comp_contact_from "
            query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
            query += "INNER JOIN tb_m_comp_contact f ON f.id_comp_contact = a.id_comp_contact_to "
            query += "INNER JOIN tb_m_comp g ON f.id_comp = g.id_comp "
            query += "INNER JOIN tb_lookup_report_status h ON a.id_report_status = h.id_report_status "
            query += "GROUP BY a.id_prod_order_ret_out "
            query += "ORDER BY a.id_prod_order_ret_out DESC "
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
            Dim query As String = "SELECT h.id_report_status, h.report_status, a.id_prod_order_ret_in, a.prod_order_ret_in_date, a.prod_order_ret_in_note,  "
            query += "a.prod_order_ret_in_number , b.prod_order_number, c.id_season,c.season, CONCAT(e.comp_number,' - ',e.comp_name) AS comp_from, CONCAT(g.comp_number,' - ',g.comp_name) AS comp_to, dsg.design_code AS `code`, dsg.design_display_name AS `name`, SUM(ad.prod_order_ret_in_det_qty) AS `qty` "
            query += "FROM tb_prod_order_ret_in a "
            query += "INNER JOIN tb_prod_order_ret_in_det ad ON ad.id_prod_order_ret_in = a.id_prod_order_ret_in "
            query += "INNER JOIN tb_prod_order b ON a.id_prod_order = b.id_prod_order "
            query += "INNER JOIN tb_prod_demand_design b1 ON b.id_prod_demand_design = b1.id_prod_demand_design "
            query += "INNER JOIN tb_m_design dsg ON dsg.id_design = b1.id_design "
            query += "INNER JOIN tb_prod_demand b2 ON b2.id_prod_demand = b1.id_prod_demand "
            query += "INNER JOIN tb_season c ON b2.id_season = c.id_season "
            query += "INNER JOIN tb_m_comp_contact d ON d.id_comp_contact = a.id_comp_contact_from "
            query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
            query += "INNER JOIN tb_m_comp_contact f ON f.id_comp_contact = a.id_comp_contact_to "
            query += "INNER JOIN tb_m_comp g ON f.id_comp = g.id_comp "
            query += "INNER JOIN tb_lookup_report_status h ON a.id_report_status = h.id_report_status "
            query += "GROUP BY a.id_prod_order_ret_in "
            query += "ORDER BY a.id_prod_order_ret_in DESC "
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
    'Focus Row Changed
    Private Sub GVRetOut_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetOut.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        noManipulating()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVRetIn_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetIn.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        noManipulating()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVRetOut_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVRetOut.DoubleClick
        Cursor = Cursors.WaitCursor
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVRetIn_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVRetIn.DoubleClick
        Cursor = Cursors.WaitCursor
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVRetOut_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVRetOut.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        noManipulating()
        Cursor = Cursors.Default
    End Sub


    Private Sub GVRetIn_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVRetIn.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        noManipulating()
        Cursor = Cursors.Default
    End Sub
End Class