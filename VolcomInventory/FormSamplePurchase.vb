Public Class FormSamplePurchase
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bcontact_active As String = "1"

    Private Sub FormSamplePurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_season_orign()
        load_vendor()


        view_sample_plan()
    End Sub

    Sub load_season_orign()
        Dim query As String = "SELECT ('0') AS id_season_orign, ('All Season') AS season_orign, ('All Season') AS season_orign_display, ('ALL Season') AS season_orign_year
UNION ALL 
SELECT id_season_orign,season_orign,season_orign_display,season_orign_year FROM `tb_season_orign`"
        viewSearchLookupQuery(SLESeason, query, "id_season_orign", "season_orign", "id_season_orign")
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All Vendor') AS comp_name, ('ALL Vendor') AS comp_name_label UNION ALL 
SELECT comp.id_comp,comp.comp_number, comp.comp_name, CONCAT_WS(' - ', comp.comp_number,comp.comp_name) AS comp_name_label FROM tb_m_comp comp 
WHERE comp.id_comp_cat='1'"
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub FormSamplePurchase_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormSamplePurchase_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    Sub view_sample_plan()
        Dim query As String = "SELECT a.id_sample_plan,a.sample_plan_number,a.sample_plan_note,a.id_comp_contact_to,d.comp_name AS comp_name_to,a.id_season_orign,b.season_orign,a.sample_plan_date,a.sample_plan_date AS date_view,a.id_report_status,e.report_status "
        query += "FROM tb_sample_plan a INNER JOIN tb_season_orign b ON a.id_season_orign=b.id_season_orign "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_lookup_report_status e ON e.id_report_status = a.id_report_status WHERE a.id_report_status='3' OR a.id_report_status='4'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCSamplePlan.DataSource = data
        If data.Rows.Count > 0 Then
            GVSamplePlan.FocusedRowHandle = 0
            view_list_purchase(GVSamplePlan.GetFocusedRowCellValue("id_sample_plan").ToString)
        End If
    End Sub
    Sub view_list_purchase(ByVal id_sample_plan As String)
        Dim query = "CALL view_plan_sample_det('" & id_sample_plan & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
    End Sub
    Sub view_sample_purc()
        Dim query_where As String = ""

        If Not SLESeason.EditValue.ToString = "0" Then
            query_where += " AND a.id_season_orign='" & SLESeason.EditValue.ToString & "'"
        End If

        If Not SLEVendor.EditValue.ToString = "0" Then
            query_where += " AND c.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT a.id_report_status,a.id_currency,cur.currency,samp_purc.amount,samp_purc.amount_before_kurs,h.report_status,a.id_sample_purc, a.id_season_orign, b.season_orign, g.payment,d.comp_name AS comp_name_to, f.comp_name AS comp_name_ship_to, a.sample_purc_number,a.sample_purc_date,a.sample_purc_kurs, DATE_ADD(a.sample_purc_date,INTERVAL a.sample_purc_lead_time DAY) AS sample_purc_lead_time, DATE_ADD(a.sample_purc_date,INTERVAL (a.sample_purc_top+a.sample_purc_lead_time) DAY) AS sample_purc_top 
FROM tb_sample_purc a 
INNER JOIN tb_season_orign b ON a.id_season_orign = b.id_season_orign 
INNER JOIN ( 
	SELECT sp_d.id_sample_purc
	,CAST(SUM(sp_d.sample_purc_det_qty * (sp_d.sample_purc_det_price-sp_d.sample_purc_det_discount)) AS DECIMAL(13,2)) AS amount_before_kurs
	,CAST(SUM((sp_d.sample_purc_det_qty * (sp_d.sample_purc_det_price-sp_d.sample_purc_det_discount))*sp.sample_purc_kurs) AS DECIMAL(13,2)) AS amount
	FROM tb_sample_purc_det sp_d INNER JOIN tb_sample_purc sp ON sp_d.id_sample_purc=sp.id_sample_purc 
	GROUP BY sp_d.id_sample_purc
) AS samp_purc ON samp_purc.id_sample_purc=a.id_sample_purc
INNER JOIN tb_lookup_currency cur ON cur.id_currency=a.id_currency
INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_to = c.id_comp_contact 
INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact 
INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp 
INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment 
INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status
WHERE 1=1 " & query_where & " ORDER BY a.id_sample_purc DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSamplePurchase.DataSource = data
        GVSamplePurchase.BestFitColumns()

        check_but()
    End Sub

    Sub check_but()
        If GVSamplePurchase.RowCount > 0 Then
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            GVSamplePurchase.BestFitColumns()
            '
        Else
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub GVSamplePlan_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSamplePlan.FocusedRowChanged
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
    Sub noManipulating()
        Try
            Dim indeks As Integer = GVSamplePurchase.FocusedRowHandle
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
        Catch ex As Exception
        End Try
    End Sub
    Sub check_menu()
        If XTCTabReceive.SelectedTabPageIndex = 0 Then
            'based purchase order
            If GVListPurchase.RowCount < 1 Then
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
            If GVSamplePlan.RowCount < 1 Then
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

    Private Sub GVSamplePlan_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVSamplePlan.RowClick
        view_list_purchase(GVSamplePlan.GetFocusedRowCellValue("id_sample_plan").ToString)
    End Sub
    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVSamplePurchase_ShowFilterPopupDate(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.FilterPopupDateEventArgs) Handles GVSamplePurchase.ShowFilterPopupDate
        If e.Column.FieldName <> "sample_purc_date" And e.Column.FieldName <> "sample_purc_lead_time" And e.Column.FieldName <> "sample_purc_top" Then Return

        add_filter_date(e)
    End Sub
    Sub add_filter_date(ByVal e As DevExpress.XtraGrid.Views.Grid.FilterPopupDateEventArgs)
        e.List.Clear()
        Dim firstDayOfThisYear As DateTime = New DateTime(DateTime.Today.Year, 1, 1)
        Dim firstDayOfLastYear As DateTime = firstDayOfThisYear.AddYears(-1)
        Dim last_to_date As DateTime = New DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)

        Dim lastYear As DevExpress.Data.Filtering.CriteriaOperator = New DevExpress.Data.Filtering.BinaryOperator( _
        e.Column.FieldName, firstDayOfLastYear, DevExpress.Data.Filtering.BinaryOperatorType.GreaterOrEqual)
        Dim thisYear As DevExpress.Data.Filtering.CriteriaOperator = New DevExpress.Data.Filtering.BinaryOperator( _
        e.Column.FieldName, firstDayOfThisYear, DevExpress.Data.Filtering.BinaryOperatorType.Less)

        Dim thistoYear As DevExpress.Data.Filtering.CriteriaOperator = New DevExpress.Data.Filtering.BinaryOperator( _
        e.Column.FieldName, firstDayOfThisYear, DevExpress.Data.Filtering.BinaryOperatorType.GreaterOrEqual)
        Dim toDate As DevExpress.Data.Filtering.CriteriaOperator = New DevExpress.Data.Filtering.BinaryOperator( _
        e.Column.FieldName, last_to_date, DevExpress.Data.Filtering.BinaryOperatorType.Less)

        Dim crit As DevExpress.Data.Filtering.CriteriaOperator = New DevExpress.Data.Filtering.GroupOperator( _
        DevExpress.Data.Filtering.GroupOperatorType.And, lastYear, thisYear)
        Dim crit2 As DevExpress.Data.Filtering.CriteriaOperator = New DevExpress.Data.Filtering.GroupOperator( _
        DevExpress.Data.Filtering.GroupOperatorType.And, thistoYear, toDate)

        e.List.Add(New DevExpress.XtraEditors.FilterDateElement("Last Year", "", crit))
        e.List.Add(New DevExpress.XtraEditors.FilterDateElement("Year To Date", "", crit2))
    End Sub

    Private Sub GVSamplePurchase_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSamplePurchase.FocusedRowChanged
        noManipulating()
        'Dim indeks As Integer = GVSamplePurchase.FocusedRowHandle
        'MsgBox(indeks.ToString)
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        view_sample_purc()
    End Sub
End Class