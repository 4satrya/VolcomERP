Public Class FormAccountingFakturScan
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public id_dept As String = "-1"
    Private Sub FormAccountingFakturScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewTrans()

        'invoice
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        viewStore()

        'cek user
        Dim query As String = "SELECT * 
        FROM tb_m_user u 
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        INNER JOIN tb_m_departement d ON d.id_departement = e.id_departement
        WHERE u.id_user=" + id_user + " AND d.is_office_dept=1 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count <= 0 Then
            XTPInv.PageVisible = False
        End If
    End Sub

    Sub viewTrans()
        Dim query As String = "SELECT *, IF(a.id_faktur_type=2, a.acc_fak_scan_faktur_date, '-') AS `faktur_date_view` FROM tb_a_acc_fak_scan a INNER JOIN tb_lookup_faktur_type b ON a.id_faktur_type=b.id_faktur_type WHERE id_departement='" & id_departement_user & "' ORDER BY a.id_acc_fak_scan DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFak.DataSource = data
        check_menu()
    End Sub

    Sub viewStore()
        Dim query As String = "SELECT 0 AS `id_comp`, 'All' AS `comp_number`, 'All Store' AS `comp_name`, 'All Store' AS `comp`
        UNION
        SELECT c.id_comp, c.comp_number, c.comp_name, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp` FROM tb_m_comp c WHERE c.id_comp_cat=6 "
        viewSearchLookupQuery(SLEStore, query, "id_comp", "comp", "id_comp")
    End Sub

    Private Sub FormAccountingFakturScan_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormAccountingFakturScan_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVFak.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            'noManipulating()
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            'checkFormAccess(Name)
            'button_main(bnew_active, bedit_active, bdel_active)
            noManipulating()
        End If
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVFak.FocusedRowHandle
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

    Private Sub GVFak_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFak.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVFak_DoubleClick(sender As Object, e As EventArgs) Handles GVFak.DoubleClick
        If GVFak.FocusedRowHandle >= 0 And GVFak.RowCount > 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class