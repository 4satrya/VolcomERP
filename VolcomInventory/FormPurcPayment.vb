Public Class FormPurcPayment
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormPurcPayment_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPurcPayment_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormPurcPayment_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub view_vendor()
        Dim query As String = "SELECT 0 AS id_comp,'All Vendor' AS comp_number,'All Vendor' AS comp_name
                               UNION
                               SELECT id_comp,comp_number,comp_name FROM tb_m_comp WHERE id_comp_cat='8'"
        viewSearchLookupQuery(SLEVendorReceive, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub check_menu()
        If XTCPO.SelectedTabPageIndex = 0 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub BViewReceive_Click(sender As Object, e As EventArgs) Handles BViewReceive.Click
        view_receive()
    End Sub

    Sub view_receive()
        Cursor = Cursors.WaitCursor
        Dim where_string As String = ""

        If Not SLEVendorReceive.EditValue.ToString = "0" Then
            where_string = " AND c.id_comp='" & SLEVendorReceive.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT 'no' AS is_check,po.`id_purc_order`,pr.`date_created`,po.note,GROUP_CONCAT(pr.`purc_rec_number`) AS `purc_rec_number`,GROUP_CONCAT(pr.`do_vendor_number`) AS `do_vendor_number`,po.purc_order_number,c.`comp_name`,c.`comp_number`,SUM(prd.`qty`) AS qty_rec,SUM(prd.`qty`*pod.`value`) AS val_rec FROM tb_purc_rec_det prd
                                INNER JOIN tb_purc_rec pr ON pr.`id_purc_rec`=prd.`id_purc_rec` AND pr.`id_report_status`='6'
                                INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order_det`=prd.`id_purc_order_det`
                                INNER JOIN tb_purc_order po ON po.`id_purc_order`=pod.`id_purc_order` AND po.`id_report_status`='6'
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=po.`id_comp_contact`
                                INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
                                " & where_string & "
                                GROUP BY po.`id_purc_order`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCPOList.DataSource = data
        GVPOList.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPurcPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_vendor()
        view_receive()
    End Sub
End Class