﻿Public Class FormMasterDesignCOPPD
    Public id_comp_contact As String = "-1"
    Public id_comp As String = "-1"
    Public id_design As String = "-1"
    '
    '
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormMasterDesignCOPPD_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterDesignCOPPD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim id_season As Integer = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("id_season")

        TEEcop.EditValue = 0.00
        TEKurs.EditValue = 1.0
        TEAdditionalCost.EditValue = 0.00

        view_currency(LECurrency)
        TEVendor.Focus()
        '
        id_comp = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("id_comp_pd").ToString
        id_comp_contact = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_pd_vendor").ToString
        TEVendor.Text = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("comp_number_pd").ToString
        TEVendorName.Text = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("comp_name_pd").ToString
        TEKurs.EditValue = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_kurs_pd")
        TEEcop.EditValue = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_pd") - FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_pd_addcost")
        TEAdditionalCost.EditValue = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_pd_addcost")
        '
        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_pd_curr").ToString)
        '
        Dim query As String = "SELECT pdd.`id_prod_demand`,pd.`id_report_status`,pdd.`id_design` FROM tb_prod_demand_design pdd
INNER JOIN tb_prod_demand pd ON pd.`id_prod_demand`=pdd.`id_prod_demand`
WHERE pd.`id_report_status` != '5' AND pdd.`id_design`='" & id_design & "' AND pd.is_pd='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            warningCustom("PD already created, COP already locked.")
            '
            BUpdateVendor.Visible = True
            BtnSave.Visible = False
        Else
            'check if target cost already input
            Dim target_ok As Boolean = True

            If id_season >= get_opt_prod_field("ecop_limit_start") Then
                Dim query_target As String = "SELECT dsg.id_fg_line_plan,(fg_lp.`target_price`/fg_lp.`mark_up`) AS target_cost
FROM tb_m_design dsg
INNER JOIN tb_fg_line_plan fg_lp ON fg_lp.`id_fg_line_plan`=dsg.`id_fg_line_plan` 
WHERE dsg.id_design='" & id_design & "'"
                Dim plan_dt As DataTable = execute_query(query_target, -1, True, "", "", "", "")
                If plan_dt.Rows.Count > 0 Then
                    If plan_dt.Rows(0)("target_cost") = 0 Then
                        target_ok = False
                    Else
                        TETargetCost.EditValue = plan_dt.Rows(0)("target_cost")
                        target_ok = True
                    End If
                Else
                    target_ok = False
                End If
            End If
            '
            If target_ok = True Then
                BUpdateVendor.Visible = False
                BtnSave.Visible = True
            Else
                warningCustom("Target cost belum terdaftar, silahkan hubungi merchandise.")
                '
                BUpdateVendor.Visible = False
                BtnSave.Visible = False
            End If
        End If
    End Sub

    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub

    Private Sub TEVendor_KeyDown(sender As Object, e As KeyEventArgs) Handles TEVendor.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query As String = "select cc.id_comp_contact,cc.id_comp,c.npwp,c.comp_number,c.comp_name,c.comp_commission,c.address_primary,c.id_so_type "
            query += " From tb_m_comp_contact cc "
            query += " inner join tb_m_comp c On c.id_comp=cc.id_comp"
            query += " where cc.is_default=1 and c.id_comp_cat='1' AND c.comp_number='" + TEVendor.Text + "'"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count <= 0 Then
                stopCustom("Store not found.")
                TEVendor.Focus()
            ElseIf data.Rows.Count > 1 Then
                FormPopUpContact.id_pop_up = "68"
                FormPopUpContact.id_cat = 1
                FormPopUpContact.GVCompany.ActiveFilterString = "[comp_number]='" + TEVendor.Text + "'"
                FormPopUpContact.ShowDialog()
            Else
                id_comp = data.Rows(0)("id_comp").ToString
                id_comp_contact = data.Rows(0)("id_comp_contact").ToString
                TEVendorName.Text = data.Rows(0)("comp_name").ToString
                TEVendor.Text = data.Rows(0)("comp_number").ToString
                '
                LECurrency.Focus()
            End If
        End If
    End Sub

    Private Sub LECurrency_KeyDown(sender As Object, e As KeyEventArgs) Handles LECurrency.KeyDown
        If e.KeyCode = Keys.Enter Then
            TEKurs.Focus()
        End If
    End Sub

    Private Sub TEKurs_KeyDown(sender As Object, e As KeyEventArgs) Handles TEKurs.KeyDown
        If e.KeyCode = Keys.Enter Then
            TEEcop.Focus()
        End If
    End Sub

    Private Sub TEEcop_KeyDown(sender As Object, e As KeyEventArgs) Handles TEEcop.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnSave.Focus()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'If id_comp = "-1" Or id_comp = "" Then
        'stopCustom("Please select vendor first")
        'Else
        Dim id_season As Integer = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("id_season")
        Dim is_more_than_limit As Boolean = False

        'check limit
        If id_season >= get_opt_prod_field("ecop_limit_start") Then
            Dim limit As Decimal = 0.00
            Dim target_cost As Decimal = TETargetCost.EditValue
            Dim ecop As Decimal = TEEcop.EditValue
            '
            limit = Decimal.Parse(get_opt_prod_field("ecop_limit_upper_percent"))

            If ecop > (target_cost * ((100 + limit) / 100)) Then
                is_more_than_limit = True
            End If
        End If

        If is_more_than_limit = True Then
            warningCustom("Estimasti Cost melewati batas target cost. " & vbNewLine & "Untuk melanjutkan, silahkan negosiasi dengan vendor atau koordinasikan dengan Merchandise dan Design")
        Else
            Dim query As String = ""
            'check 
            query = "SELECT pdd.`id_prod_demand`,pd.`id_report_status`,pdd.`id_design` FROM tb_prod_demand_design pdd
INNER JOIN tb_prod_demand pd ON pd.`id_prod_demand`=pdd.`id_prod_demand`
WHERE pd.`id_report_status` != '5' AND pdd.`id_design`='" & id_design & "' AND pd.is_pd='1'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                warningCustom("PD already created, COP already locked.")
            Else
                Dim id_c As String = ""
                If id_comp = "-1" Or id_comp = "" Then
                    id_c = "NULL"
                Else
                    id_c = "'" & id_comp_contact & "'"
                End If
                query = String.Format("UPDATE tb_m_design SET prod_order_cop_pd='{1}',prod_order_cop_pd_addcost='{5}',prod_order_cop_kurs_pd='{2}',prod_order_cop_pd_vendor={3},prod_order_cop_pd_curr='{4}' WHERE id_design='{0}'", id_design, decimalSQL((TEEcop.EditValue + TEAdditionalCost.EditValue).ToString), decimalSQL(TEKurs.EditValue.ToString), id_c, LECurrency.EditValue.ToString, decimalSQL(TEAdditionalCost.EditValue.ToString))
                execute_non_query(query, True, "", "", "", "")
                infoCustom("ECOP entry success.")
                FormMasterDesignCOP.view_design()
                FormMasterDesignCOP.BGVDesign.FocusedRowHandle = find_row_as_is(FormMasterDesignCOP.BGVDesign, "id_design", id_design)
                Close()
            End If
        End If
        'End If
    End Sub

    Private Sub BtnBrowseContactFrom_Click(sender As Object, e As EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "68"
        FormPopUpContact.id_cat = 1
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BUpdateVendor_Click(sender As Object, e As EventArgs) Handles BUpdateVendor.Click
        'check cop propose if any
        Dim query_cek As String = "SELECT * FROM `tb_design_cop_propose_det` cpd 
INNER JOIN `tb_design_cop_propose` cp ON cp.id_design_cop_propose=cpd.id_design_cop_propose AND NOT (cp.id_report_status='6' OR cp.id_report_status='5')
WHERE cpd.id_design='" & id_design & "'"
        Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
        If data_cek.Rows.Count > 0 Then
            'ada pengajuan masih blm proses
            warningCustom("Cant update vendor, another COP Propose in process.")
        Else
            If id_comp = "-1" Or id_comp = "" Then
                stopCustom("Please select vendor first")
            Else
                Dim query As String = ""
                query = String.Format("UPDATE tb_m_design SET prod_order_cop_pd_vendor='{1}' WHERE id_design='{0}'", id_design, id_comp_contact)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Update vendor success.")
                FormMasterDesignCOP.view_design()
                FormMasterDesignCOP.BGVDesign.FocusedRowHandle = find_row_as_is(FormMasterDesignCOP.BGVDesign, "id_design", id_design)
            End If
        End If
    End Sub
End Class