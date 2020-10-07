Public Class FormDesignCopPps
    Dim id_pps As String = "-1"
    Public id_design As String = "-1"
    Dim is_production As String = "-1"
    Public id_comp_contact As String = "-1"

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormDesignCopPps_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_form_input()
        'check kurs first
        Dim query_kurs As String = "SELECT * FROM tb_kurs_trans WHERE DATE(DATE_ADD(created_date, INTERVAL 6 DAY)) >= DATE(NOW()) ORDER BY id_kurs_trans DESC LIMIT 1"
        Dim data_kurs As DataTable = execute_query(query_kurs, -1, True, "", "", "", "")

        If Not data_kurs.Rows.Count > 0 Then
            warningCustom("Get kurs error.")
            TETodayKurs.EditValue = 0.00
        Else
            TETodayKurs.EditValue = data_kurs.Rows(0)("kurs_trans") + data_kurs.Rows(0)("fixed_floating")
        End If
        '
        load_det_input()
        show_but()
    End Sub

    Sub load_det_input()
        Dim query As String = "SELECT description,id_currency," & decimalSQL(TETodayKurs.EditValue.ToString) & " AS kurs,before_kurs,additional FROM tb_design_ecop_pps_det"
        Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCOPComponent.DataSource = dt
        GVCOPComponent.BestFitColumns()
    End Sub

    Sub show_but()
        If GVCOPComponent.RowCount > 0 Then
            BDelete.Visible = True
        Else
            BDelete.Visible = False
        End If
    End Sub

    Sub load_target_cost()
        Dim target_ok As Boolean = False

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

        If target_ok = False Then
            warningCustom("Target cost not available, please contact MD.")
            Close()
        End If
    End Sub

    Private Sub FormDesignCopPps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_target_cost()
        view_currency(LECurrency)
        view_currency_grid()
        load_cold_storage()
        '
        TECostSample.EditValue = 0.0
        TEEcop.EditValue = 0.00
        TEKurs.EditValue = 1.0
        TEAdditionalCost.EditValue = 0.00
        '
        Dim q As String = "SELECT design_code,design_display_name FROM tb_m_design where id_design='" & id_design & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '
        If dt.Rows.Count > 0 Then
            TEDesc.Text = dt.Rows(0)("design_display_name").ToString
            TECode.Text = dt.Rows(0)("design_code").ToString
        End If
        '
        If id_pps = "-1" Then
            'new
            Dim query As String = ""
            'check 
            query = "SELECT pdd.`id_prod_demand`,pd.`id_report_status`,pdd.`id_design` FROM tb_prod_demand_design pdd
INNER JOIN tb_prod_demand pd ON pd.`id_prod_demand`=pdd.`id_prod_demand`
WHERE pd.`id_report_status` != '5' AND pdd.`id_design`='" & id_design & "' AND pd.is_pd='1'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                warningCustom("ECOP already locked.")
            Else
                load_form_input()
                BCancelPropose.Visible = False
                BMark.Visible = False
            End If
        Else
            'edit
            BCancelPropose.Visible = True
            BMark.Visible = True
        End If
        '
        If is_production = "1" Then
            PCPurchasing.Visible = True
        Else
            PCPurchasing.Visible = False
        End If
    End Sub

    Private Sub view_currency_grid()
        Try
            Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency WHERE is_active_cop='1'"
            viewSearchLookupRepositoryQuery(RISLEComp, query, 0, "currency", "id_currency")
        Catch ex As Exception
        End Try
    End Sub

    Sub load_cold_storage()
        Dim q As String = "SELECT id_cool_storage AS id,cool_storage AS cold_desc FROM tb_lookup_cool_storage ORDER BY id_cool_storage DESC"
        viewSearchLookupQuery(SLEColdStorage, q, "id", "cold_desc", "id")
    End Sub

    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub

    Private Sub TEVendor_EditValueChanged(sender As Object, e As EventArgs) Handles TEVendor.EditValueChanged

    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        GVCOPComponent.DeleteSelectedRows()
        show_but()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        add_row()
        show_but()
    End Sub

    Sub add_row()
        Dim newRow As DataRow = (TryCast(GCCOPComponent.DataSource, DataTable)).NewRow()
        newRow("description") = ""
        newRow("id_currency") = 1
        newRow("kurs") = TETodayKurs.EditValue
        newRow("before_kurs") = 0.00
        newRow("additional") = 0.00

        TryCast(GCCOPComponent.DataSource, DataTable).Rows.Add(newRow)
        GCCOPComponent.RefreshDataSource()
        show_but()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'If id_comp = "-1" Or id_comp = "" Then
        'stopCustom("Please select vendor first")
        'Else
        Dim id_season As Integer = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("id_season")
        Dim is_more_than_limit As Boolean = False

        'check limit
        Dim limit As Decimal = 0.00
        Dim target_cost As Decimal = TETargetCost.EditValue
        Dim target_sample As Decimal = TECostSample.EditValue
        Dim ecop As Decimal = TEEcop.EditValue
        Dim cont As Boolean = True
        '
        limit = Decimal.Parse(get_opt_prod_field("ecop_limit_upper_percent"))

        If is_production = "1" Then
            If ecop > (target_cost * ((100 + limit) / 100)) Or ecop > (target_sample * ((100 + limit) / 100)) Then
                is_more_than_limit = True
            End If
        Else
            If ecop > (target_cost * ((100 + limit) / 100)) Then
                is_more_than_limit = True
            End If
        End If

        'warning
        If is_more_than_limit Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Estimasti Cost melewati batas target cost. Lanjutkan?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                cont = True
            Else
                cont = False
            End If
        End If

        If cont Then
            Dim query As String = ""
            'check 
            query = "SELECT pdd.`id_prod_demand`,pd.`id_report_status`,pdd.`id_design` FROM tb_prod_demand_design pdd
INNER JOIN tb_prod_demand pd ON pd.`id_prod_demand`=pdd.`id_prod_demand`
WHERE pd.`id_report_status` != '5' AND pdd.`id_design`='" & id_design & "' AND pd.is_pd='1'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                warningCustom("ECOP already locked.")
            Else
                Dim id_c As String = ""
                If id_comp_contact = "-1" Or id_comp_contact = "" Then
                    id_c = "NULL"
                Else
                    id_c = "'" & id_comp_contact & "'"
                End If

                Dim qi As String = ""
                qi = "INSERT INTO `tb_design_ecop_pps`(id_comp_contact,id_design,created_by,created_date,id_report_status,is_production_dept,note)
VALUES('" & id_comp_contact & "','" & id_design & "','" & id_user & "',NOW(),'1','" & is_production & "',''); SELECT LAST_INSERT_ID();"
                id_pps = execute_query(qi, 0, True, "", "", "", "")

                qi = "CALL gen_number('" & id_pps & "',270)"
                execute_non_query(qi, True, "", "", "", "")
                'detail
                qi = "INSERT INTO tb_design_ecop_pps_det(`id_design_ecop_pps`,`description`,`id_currency`,`kurs`,`before_kurs`,`additional`) VALUES"
                For i As Integer = 0 To GVCOPComponent.RowCount - 1
                    If Not i = 0 Then
                        qi += ","
                    End If
                    qi += "('" & id_pps & "','" & addSlashes(GVCOPComponent.GetRowCellValue(i, "description").ToString) & "','" & GVCOPComponent.GetRowCellValue(i, "id_currency").ToString & "','" & decimalSQL(GVCOPComponent.GetRowCellValue(i, "kurs").ToString) & "','" & decimalSQL(GVCOPComponent.GetRowCellValue(i, "before_kurs").ToString) & "','" & decimalSQL(GVCOPComponent.GetRowCellValue(i, "additional").ToString) & "')"
                Next
                execute_non_query(qi, True, "", "", "", "")

                submit_who_prepared("270", id_pps, id_user)

                infoCustom("Entry ECOP success")

                Close()
            End If
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click

    End Sub

    Private Sub BCancelPropose_Click(sender As Object, e As EventArgs) Handles BCancelPropose.Click

    End Sub
End Class