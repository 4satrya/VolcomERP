Public Class FormInvMat
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormInvoiceMat_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormInvoiceMat_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormInvMat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()
    End Sub

    Sub print_list()

    End Sub

    Private Sub BViewPayment_Click(sender As Object, e As EventArgs) Handles BViewPayment.Click
        load_view()
    End Sub

    Sub load_view()
        If CEInternal.Checked = True Then
            Dim q_where As String = ""

            If Not SLEVendorPayment.EditValue.ToString = "0" Then
                q_where = " AND c.id_comp='" & SLEVendorPayment.EditValue.ToString & "' "
            End If

            If XTCMatInv.SelectedTabPageIndex = 0 Then
                'list invoice
                Dim query As String = "SELECT inv.id_inv_mat,inv.number, inv.id_comp,c.comp_number,c.comp_name,emp.employee_name,sts.report_status
,inv.created_date,inv.due_date,inv.ref_date
,SUM(invd.`value`) AS amount
,SUM(invd.`value`)*((inv.vat_percent)/100) AS amount_vat
,SUM(invd.`value`)*((100+inv.vat_percent)/100) AS total_amount
FROM `tb_inv_mat_det` invd
INNER JOIN tb_inv_mat inv ON inv.`id_inv_mat`=invd.`id_inv_mat` AND inv.is_deposit='1'
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=inv.id_report_status
INNER JOIN tb_m_comp c ON c.id_comp=inv.id_comp " & q_where & "
INNER JOIN tb_m_user usr ON usr.`id_user`=inv.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
GROUP BY invd.`id_inv_mat`"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                '
                GCInvoice.DataSource = data
                GVInvoice.BestFitColumns()
            ElseIf XTCMatInv.SelectedTabPageIndex = 1 Then
                'pl mrs
                Dim query As String = "SELECT 'no' AS is_check,pl.`id_pl_mrs`,inv.id_report,c.`id_comp`,c.`comp_number`,c.`comp_name`,c.`id_acc_ar`,pl.`id_pl_mrs`,pl.`pl_mrs_number`,SUM(pld.`pl_mrs_det_price`*pld.`pl_mrs_det_qty`) AS amount,0 AS `id_prod_order`,'' AS prod_order_number
,'-' AS design_display_name
FROM tb_pl_mrs_det pld
INNER JOIN tb_pl_mrs pl ON pl.`id_pl_mrs`=pld.`id_pl_mrs`
LEFT JOIN 
(
    SELECT id_report
    FROM `tb_inv_mat_det` invd
    INNER JOIN tb_inv_mat inv ON inv.id_inv_mat=invd.id_inv_mat AND inv.id_report_status!=5 AND inv.id_inv_mat_type=1
)inv ON inv.id_report=pl.id_pl_mrs
INNER JOIN `tb_prod_order_mrs` mrs ON mrs.`id_prod_order_mrs`=pl.`id_prod_order_mrs` AND ISNULL(mrs.id_prod_order)
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pl.`id_comp_contact_to` AND pl.`id_pl_mat_type`='2'
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp` " & q_where & "
WHERE ISNULL(inv.id_report)
GROUP BY pl.`id_pl_mrs`"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                GCPL.DataSource = data
                GVPL.BestFitColumns()
                If SLEVendorPayment.EditValue.ToString = "0" Then
                    BCreateBKM.Visible = False
                    BCreateBPB.Visible = False
                Else
                    BCreateBKM.Visible = True
                    BCreateBPB.Visible = False
                End If
            ElseIf XTCMatInv.SelectedTabPageIndex = 2 Then
                'retur

            End If
        Else
            'check AR
            Dim is_ok As Boolean = True

            If Not SLEVendorPayment.EditValue.ToString = "0" Then
                Dim query_check As String = "SELECT IFNULL(id_acc_ar,0) AS id_acc_ar FROM tb_m_comp c
WHERE c.id_comp='" & SLEVendorPayment.EditValue.ToString & "'"
                Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")
                If data_check.Rows(0)("id_acc_ar").ToString = "0" Then
                    is_ok = False
                End If
            End If

            '
            If Not is_ok Then
                warningCustom("This company AR account is not set.")
            Else
                Dim q_where As String = ""

                If Not SLEVendorPayment.EditValue.ToString = "0" Then
                    q_where = " AND c.id_comp='" & SLEVendorPayment.EditValue.ToString & "' "
                End If

                If XTCMatInv.SelectedTabPageIndex = 0 Then
                    'list invoice
                    Dim query As String = "SELECT inv.id_inv_mat,inv.number, inv.id_comp,c.comp_number,c.comp_name,emp.employee_name,sts.report_status
,inv.created_date,inv.due_date,inv.ref_date
,SUM(invd.`value`) AS amount
,SUM(invd.`value`)*((inv.vat_percent)/100) AS amount_vat
,SUM(invd.`value`)*((100+inv.vat_percent)/100) AS total_amount
FROM `tb_inv_mat_det` invd
INNER JOIN tb_inv_mat inv ON inv.`id_inv_mat`=invd.`id_inv_mat` AND inv.is_deposit='2'
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=inv.id_report_status
INNER JOIN tb_m_comp c ON c.id_comp=inv.id_comp " & q_where & "
INNER JOIN tb_m_user usr ON usr.`id_user`=inv.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=invd.`id_prod_order`
GROUP BY invd.`id_inv_mat`"
                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                    '
                    GCInvoice.DataSource = data
                    GVInvoice.BestFitColumns()
                ElseIf XTCMatInv.SelectedTabPageIndex = 1 Then
                    'pl mrs
                    Dim query As String = "SELECT 'no' AS is_check,pl.`id_pl_mrs`,inv.id_report,c.`id_comp`,c.`comp_number`,c.`comp_name`,c.`id_acc_ar`,pl.`id_pl_mrs`,pl.`pl_mrs_number`,SUM(pld.`pl_mrs_det_price`*pld.`pl_mrs_det_qty`) AS amount,mrs.`id_prod_order`,po.`prod_order_number`
,dsg.`design_display_name`
FROM tb_pl_mrs_det pld
INNER JOIN tb_pl_mrs pl ON pl.`id_pl_mrs`=pld.`id_pl_mrs`
LEFT JOIN 
(
    SELECT id_report
    FROM `tb_inv_mat_det` invd
    INNER JOIN tb_inv_mat inv ON inv.id_inv_mat=invd.id_inv_mat AND inv.id_report_status!=5 AND inv.id_inv_mat_type=1
)inv ON inv.id_report=pl.id_pl_mrs
INNER JOIN `tb_prod_order_mrs` mrs ON mrs.`id_prod_order_mrs`=pl.`id_prod_order_mrs`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=mrs.`id_prod_order`
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pl.`id_comp_contact_to` AND pl.`id_pl_mat_type`='2'
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp` " & q_where & "
WHERE ISNULL(inv.id_report)
GROUP BY pl.`id_pl_mrs`"
                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                    GCPL.DataSource = data
                    GVPL.BestFitColumns()
                    If SLEVendorPayment.EditValue.ToString = "0" Then
                        BCreateBKM.Visible = False
                        BCreateBPB.Visible = False
                    Else
                        BCreateBKM.Visible = False
                        BCreateBPB.Visible = True
                    End If
                ElseIf XTCMatInv.SelectedTabPageIndex = 2 Then
                    'retur
                    Dim query As String = "SELECT 'no' AS is_check,c.`id_comp`,c.`comp_number`,c.`comp_name`,c.`id_acc_ar`,ret.`id_mat_prod_ret_in`,ret.`mat_prod_ret_in_number`,SUM(retd.`mat_prod_ret_in_det_price`*retd.`mat_prod_ret_in_det_qty`) AS amount,po.`id_prod_order`,po.`prod_order_number`
,dsg.`design_display_name`
FROM `tb_mat_prod_ret_in_det` retd
INNER JOIN tb_mat_prod_ret_in ret ON ret.`id_mat_prod_ret_in`=retd.`id_mat_prod_ret_in`
LEFT JOIN 
(
    SELECT id_report
    FROM `tb_inv_mat_det` invd
    INNER JOIN tb_inv_mat inv ON inv.id_inv_mat=invd.id_inv_mat AND inv.id_report_status!=5 AND inv.id_inv_mat_type=2
)inv ON inv.id_report=pl.id_mat_prod_ret_in
INNER JOIN tb_prod_order po ON po.`id_prod_order`=ret.`id_prod_order`
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ret.`id_comp_contact_from` AND ret.`id_pl_mat_type`='2'
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp` " & q_where & "
WHERE ISNULL(inv.id_report)
GROUP BY ret.`id_mat_prod_ret_in`"
                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                    GCRetur.DataSource = data
                    GVRetur.BestFitColumns()
                    If SLEVendorPayment.EditValue.ToString = "0" Then
                        BCreateBRP.Visible = False
                    Else
                        BCreateBRP.Visible = True
                    End If
                End If
            End If

        End If
    End Sub

    Sub check_but()
        If XTCMatInv.SelectedTabPageIndex = 0 Then

        ElseIf XTCMatInv.SelectedTabPageIndex = 1 Then
            'pl mrs
            If SLEVendorPayment.EditValue.ToString = "0" Then
                BCreateBPB.Visible = False
            Else
                BCreateBPB.Visible = False
            End If
        ElseIf XTCMatInv.SelectedTabPageIndex = 2 Then
            'retur
            If SLEVendorPayment.EditValue.ToString = "0" Then
                BCreateBRP.Visible = False
            Else
                BCreateBRP.Visible = False
            End If
        End If
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT 0 AS id_comp,'All' AS comp_number,'All' AS comp_name,'0' AS id_acc_ar
UNION
SELECT c.`id_comp`,c.`comp_number`,c.`comp_name`,c.`id_acc_ar` 
FROM tb_pl_mrs pl
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pl.`id_comp_contact_to` AND pl.`id_pl_mat_type`='2'
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp` 
GROUP BY c.`id_comp`"
        viewSearchLookupQuery(SLEVendorPayment, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub FormInvMat_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCreateBPB_Click(sender As Object, e As EventArgs) Handles BCreateBPB.Click
        GVPL.ActiveFilterString = "[is_check]='yes'"

        If GVPL.RowCount > 0 Then
            FormInvMatDet.id_inv = "-1"
            FormInvMatDet.ShowDialog()
        End If

        GVPL.ActiveFilterString = ""
    End Sub

    Private Sub BCreateBRP_Click(sender As Object, e As EventArgs) Handles BCreateBRP.Click
        GVRetur.ActiveFilterString = "[is_check]='yes'"

        If GVRetur.RowCount > 0 Then
            FormInvMatDet.id_inv = "-1"
            FormInvMatDet.ShowDialog()
        End If

        GVRetur.ActiveFilterString = ""
    End Sub

    Private Sub GVInvoice_DoubleClick(sender As Object, e As EventArgs) Handles GVInvoice.DoubleClick
        If GVInvoice.RowCount > 0 Then
            FormInvMatDet.id_inv = GVInvoice.GetFocusedRowCellValue("id_inv_mat").ToString
            FormInvMatDet.ShowDialog()
        End If
    End Sub

    Private Sub BCreateBKM_Click(sender As Object, e As EventArgs) Handles BCreateBKM.Click
        GVPL.ActiveFilterString = "[is_check]='yes'"

        If GVPL.RowCount > 0 Then
            FormInvMatDet.id_inv = "-1"
            FormInvMatDet.is_deposit = "1"
            FormInvMatDet.ShowDialog()
        End If

        GVPL.ActiveFilterString = ""
    End Sub
End Class