Public Class FormReportBudget
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Dim is_purc_dep As String = "1"

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        load_budget()
    End Sub

    Private Sub FormReportBudget_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewMainCategory()
        view_year()
        load_dep()
        DEUntil.EditValue = Now
        '
        ASSum.EnableAnimation = True
        ASSum.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseIn
        ASSum.EasingFunction = New DevExpress.XtraGauges.Core.Model.BounceEase
    End Sub

    Sub load_budget()
        Dim dep As String = "0"
        Dim main_cat As String = "0"
        Dim where_opex As String = ""
        Dim where_capex As String = ""
        '
        If Not SLEDepartement.EditValue.ToString = "0" Then
            where_capex += " AND op.id_departement='" & SLEDepartement.EditValue.ToString & "'"
        End If
        '
        If Not SLEMainCategory.EditValue.ToString = "0" Then
            where_opex += " AND op.id_item_cat_main='" & SLEMainCategory.EditValue.ToString & "'"
            where_capex += " AND op.id_item_cat_main='" & SLEMainCategory.EditValue.ToString & "'"
        End If
        '
        Dim query As String = "(SELECT 'All' AS departement,cm.`id_item_cat_main`,cm.`item_cat_main` AS main_cat,et.`expense_type`
        ,op.`value_expense` AS budget
        ,IFNULL(SUM(IF(trx.is_po=1,trx.`value`,0)),0) AS po_booked
        ,IFNULL(SUM(IF(trx.is_po=2,trx.`value`,0)),0) AS rec
        ,IFNULL(SUM(trx.`value`),0) AS val_used
        ,(op.`value_expense`-IFNULL(SUM(trx.`value`),0)) AS val_remaining
        ,(IFNULL(SUM(trx.`value`),0)/op.value_expense)*100 AS used_percent
        ,0 AS id_departement
        FROM tb_b_expense_opex op
        LEFT JOIN tb_b_expense_opex_trans trx ON op.`id_b_expense_opex`=trx.`id_b_expense_opex` AND DATE(trx.date_trans) <= DATE('" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "')
        LEFT JOIN tb_item_cat_main cm ON cm.`id_item_cat_main`=op.`id_item_cat_main`
        LEFT JOIN tb_lookup_expense_type et ON et.`id_expense_type`=cm.`id_expense_type`
        WHERE op.`year`='" & LEYear.Text.ToString & "' 
        " & where_opex & "
        GROUP BY op.`id_item_cat_main`)
        UNION ALL
        (SELECT dep.departement,cm.`id_item_cat_main`,cm.`item_cat_main` AS main_cat,et.`expense_type`
        ,op.`value_expense` AS budget
        ,IFNULL(SUM(IF(trx.is_po=1,trx.`value`,0)),0) AS po_booked
        ,IFNULL(SUM(IF(trx.is_po=2,trx.`value`,0)),0) AS rec
        ,IFNULL(SUM(trx.`value`),0) AS val_used
        ,IFNULL((op.`value_expense`-SUM(trx.`value`)),0) AS val_remaining
        ,(IFNULL(SUM(trx.`value`),0)/op.value_expense)*100 AS used_percent
        ,dep.id_departement AS id_departement
        FROM tb_b_expense op
        LEFT JOIN tb_b_expense_trans trx ON op.`id_b_expense`=trx.`id_b_expense` AND DATE(trx.date_trans) <= DATE('" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "')
        LEFT JOIN tb_item_cat_main cm ON cm.`id_item_cat_main`=op.`id_item_cat_main`
        LEFT JOIN tb_lookup_expense_type et ON et.`id_expense_type`=cm.`id_expense_type`
        INNER JOIN tb_m_departement dep ON dep.id_departement=op.id_departement
        WHERE op.`year`='" & LEYear.Text.ToString & "'
        " & where_capex & "
        GROUP BY op.`id_item_cat_main`,op.id_departement)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemCat.DataSource = data
        GVItemCat.BestFitColumns()
        '
        PanelChart.Visible = True


        setGaugeInfo()
    End Sub

    Sub setGaugeInfo()

        'isi gauge summary
        TEBudgetSum.EditValue = GVItemCat.Columns("budget").SummaryItem.SummaryValue
        TEActualSum.EditValue = GVItemCat.Columns("val_used").SummaryItem.SummaryValue

        ASSum.Value = GVItemCat.Columns("val_used").SummaryItem.SummaryValue / GVItemCat.Columns("budget").SummaryItem.SummaryValue * 100
        LCSummary.Text = Decimal.Parse((GVItemCat.Columns("val_used").SummaryItem.SummaryValue / GVItemCat.Columns("budget").SummaryItem.SummaryValue) * 100).ToString("N2") + "%"
        'opex capex

        Dim b_opex As Decimal = 0.0
        Dim b_capex As Decimal = 0.0
        '
        Dim u_opex As Decimal = 0.0
        Dim u_capex As Decimal = 0.0

        For i As Integer = 0 To GVItemCat.RowCount - 1
            If GVItemCat.GetRowCellValue(i, "expense_type").ToString.ToUpper = "CAPEX" Then
                b_capex += GVItemCat.GetRowCellValue(i, "budget")
                u_capex += GVItemCat.GetRowCellValue(i, "val_used")
            Else
                b_opex += GVItemCat.GetRowCellValue(i, "budget")
                u_opex += GVItemCat.GetRowCellValue(i, "val_used")
            End If
        Next

        TEBudgetCapex.EditValue = b_capex
        TEUsedCapex.EditValue = u_capex
        TEBudgetOpex.EditValue = b_opex
        TEUsedOpex.EditValue = u_opex

        If Not b_capex = 0 Then
            'isi gauge capex
            ASCapex.Value = u_capex / b_capex * 100
            LCCapex.Text = Decimal.Parse((u_capex / b_capex) * 100).ToString("N2") + "%"
        End If

        If Not b_opex = 0 Then
            'isi gauge opex
            ASOpex.Value = u_opex / b_opex * 100
            LCOpex.Text = Decimal.Parse((u_opex / b_opex) * 100).ToString("N2") + "%"
        End If
    End Sub

    Sub viewMainCategory()
        Dim query As String = "
SELECT 0 AS id_item_cat_main,'All' AS item_cat_main,'All' AS expense_type
UNION
SELECT t.id_item_cat_main,t.item_cat_main,tt.expense_type 
FROM tb_item_cat_main t
INNER JOIN tb_lookup_expense_type tt ON tt.`id_expense_type`=t.`id_expense_type` "
        viewSearchLookupQuery(SLEMainCategory, query, "id_item_cat_main", "item_cat_main", "id_item_cat_main")
    End Sub

    Sub view_year()
        Dim query As String = "SELECT `year` FROM `tb_b_expense_opex`
UNION
SELECT `year` FROM `tb_b_expense`
GROUP BY `year`"
        viewLookupQuery(LEYear, query, 0, "year", "year")
    End Sub

    Sub load_dep()
        Dim query As String = ""
        If is_purc_dep = "1" Then
            query = "SELECT '0' AS id_departement,'ALL' AS departement 
                               UNION
                               SELECT id_departement,departement FROM tb_m_departement"
        Else
            query = "SELECT id_departement,departement FROM tb_m_departement WHERE id_departement='" & id_departement_user & "'"
        End If

        viewSearchLookupQuery(SLEDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Private Sub FormReportBudget_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormReportBudget_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Dim tot_budget As Decimal
    Dim tot_used As Decimal

    Private Sub GVItemCat_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVItemCat.CustomSummaryCalculate
        Dim summaryID As String = Convert.ToString(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)

        If summaryID = "1" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_budget = 0
                    tot_used = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    tot_budget += GVItemCat.GetRowCellValue(e.RowHandle, "budget")
                    tot_used += GVItemCat.GetRowCellValue(e.RowHandle, "val_used")
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = (tot_used / tot_budget) * 100
            End Select
        End If
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        If GVItemCat.RowCount > 0 Then
            FormReportBudgetList.id_cat_main = GVItemCat.GetFocusedRowCellValue("id_item_cat_main").ToString
            FormReportBudgetList.id_departement = GVItemCat.GetFocusedRowCellValue("id_departement").ToString
            FormReportBudgetList.date_time = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
            FormReportBudgetList.year = LEYear.Text
            FormReportBudgetList.ShowDialog()
        End If
    End Sub
End Class