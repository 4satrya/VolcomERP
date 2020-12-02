Public Class FormMasterRawMaterial
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bnew_active2 As String = "1"
    Dim bedit_active2 As String = "1"
    Dim bdel_active2 As String = "1"
    'Form Load
    Private Sub FormMasterRawMaterial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewMat()
        viewMatDetail()
        viewMatDetailList()
    End Sub
    'View Material Data
    Sub viewMat()
        Dim query As String = "SELECT * FROM tb_m_mat a "
        query += "INNER JOIN tb_m_uom b ON a.id_uom = b.id_uom "
        query += "INNER JOIN tb_m_mat_cat c ON a.id_mat_cat = c.id_mat_cat "
        query += "ORDER BY a.mat_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRawMat.DataSource = data
        pageChanged()
        If data.Rows.Count > 0 Then
            viewMatDetail()
            XTPMaterialDetail.PageEnabled = True
        Else
            XTPMaterialDetail.PageEnabled = False
        End If
    End Sub
    'View Material Detail
    Sub viewMatDetail()
        LabelMatContent.Text = GVRawMat.GetFocusedRowCellDisplayText("mat_name").ToString
        Dim query As String = "SELECT * FROM tb_m_mat_det a  "
        query += "INNER JOIN tb_m_mat b ON a.id_mat = b.id_mat  "
        query += "LEFT JOIN tb_lookup_inventory_method c ON a.id_method = c.id_method  "
        query += "WHERE a.id_mat = '" + GVRawMat.GetFocusedRowCellDisplayText("id_mat").ToString + "' "
        query += "ORDER BY a.mat_det_date ASC,  id_mat_det ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatDetail.DataSource = data
        pageChanged()
    End Sub
    '
    Sub viewMatDetailList()
        Dim query As String = "SELECT * FROM tb_m_mat_det a  
                                INNER JOIN tb_m_mat b ON a.id_mat = b.id_mat  
                                LEFT JOIN tb_lookup_inventory_method c ON a.id_method = c.id_method  
                                LEFT JOIN tb_m_mat_det_price mdp ON mdp.id_mat_det = a.id_mat_det AND mdp.is_default_cost='1'
                                ORDER BY a.mat_det_date ASC, a.id_mat_det ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListMat.DataSource = data
        pageChanged()
    End Sub
    'Activated Form
    Private Sub FormMasterRawMaterial_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        pageChanged()
    End Sub
    'Deadactivated Form
    Private Sub FormMasterRawMaterial_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    'Page Changed
    Private Sub XTCMaterialType_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCMaterialType.SelectedPageChanged
        pageChanged()
    End Sub
    Sub pageChanged()
        If XTCList.SelectedTabPageIndex = 0 Then
            If XTCMaterialType.SelectedTabPageIndex = 0 Then
                If GVRawMat.RowCount > 0 Then
                    'show all
                    bnew_active = "1"
                    bedit_active = "1"
                    bdel_active = "1"
                Else
                    'hide all except new
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                End If
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            ElseIf XTCMaterialType.SelectedTabPageIndex = 1 Then
                If GVMatDetail.RowCount > 0 Then
                    'show all
                    bnew_active2 = "1"
                    bedit_active2 = "1"
                    bdel_active2 = "1"
                Else
                    'hide all except new
                    bnew_active2 = "1"
                    bedit_active2 = "0"
                    bdel_active2 = "0"
                End If
                checkFormAccess(Name)
                button_main(bnew_active2, bedit_active2, bdel_active2)
            End If
        ElseIf XTCList.SelectedTabPageIndex = 1
            If GVListMat.RowCount > 0 Then
                bnew_active = "0"
                bedit_active = "1"
                bdel_active = "0"
            Else
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub GVRawMat_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVRawMat.DoubleClick
        FormMain.but_edit()
    End Sub

    Private Sub GVMatDetail_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVMatDetail.DoubleClick
        FormMain.but_edit()
    End Sub

    Private Sub BtnImportFK_Click(sender As Object, e As EventArgs) 
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "12"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVRawMat_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRawMat.FocusedRowChanged
        Try
            viewMatDetail()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub XTCList_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCList.SelectedPageChanged
        pageChanged()
    End Sub

    Private Sub BProposeMat_Click(sender As Object, e As EventArgs) Handles BProposeMat.Click
        FormMasterRawMatPps.action = "ins"

        'FormMasterRawMaterialDetSingle.id_mat = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellValue("id_mat").ToString
        'FormMasterRawMaterialDetSingle.LabelPrintedName.Text = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("mat_display_name").ToString
        'FormMasterRawMaterialDetSingle.TxtMaterialTypeCode.Text = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("mat_code").ToString

        FormMasterRawMatPps.ShowDialog()
    End Sub

    Private Sub BRefreshPPS_Click(sender As Object, e As EventArgs) Handles BRefreshPPS.Click
        view_refresh_pps()
    End Sub

    Sub view_refresh_pps()
        Dim q As String = "SELECT mat.mat_code,sts.report_status,pps.fob_price,pps.`id_mat_det_pps`,pps.`mat_det_code`,mat.`mat_display_name`,pps.`mat_det_display_name`,uom.`uom`,pps.`mat_det_date`,emp.`employee_name`,emp_u.`employee_name` AS emp_update,pps.`mat_det_date`,pps.`last_update_date`
FROM `tb_m_mat_det_pps` pps
INNER JOIN tb_m_mat mat ON mat.`id_mat`=pps.`id_mat`
INNER JOIN tb_m_uom uom ON uom.`id_uom`=mat.`id_uom`
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
LEFT JOIN tb_m_user usr ON usr.`id_user`=pps.`created_by`
LEFT JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
LEFT JOIN tb_m_user usr_u ON usr_u.`id_user`=pps.`last_update_by`
LEFT JOIN tb_m_employee emp_u ON emp_u.`id_employee`=usr_u.`id_employee`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPropose.DataSource = dt
        GVPropose.BestFitColumns()
    End Sub

    Private Sub GVPropose_DoubleClick(sender As Object, e As EventArgs) Handles GVPropose.DoubleClick
        If GVPropose.RowCount > 0 Then
            FormMasterRawMatPps.action = "upd"
            FormMasterRawMatPps.id_pps = GVPropose.GetFocusedRowCellValue("id_mat_det_pps").ToString
            FormMasterRawMatPps.ShowDialog()
        End If
    End Sub
End Class