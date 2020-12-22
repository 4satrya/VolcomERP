Public Class FormItemExpense
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormItemExpense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEBBKFrom.EditValue = Now
        DEBBKTo.EditValue = Now
        '
        load_unit()
        viewData()
    End Sub

    Sub load_unit()
        Dim query As String = "SELECT 0 AS id_coa_tag,'ALL' AS tag_code,'ALL' AS tag_description 
UNION ALL
SELECT id_coa_tag,tag_code,tag_description FROM `tb_coa_tag`"
        '        query = "SELECT '0' AS id_comp,'-' AS comp_number, 'All Unit' AS comp_name
        'UNION ALL
        'SELECT ad.`id_comp`,c.`comp_number`,c.`comp_name` FROM `tb_a_acc_trans_det` ad
        'INNER JOIN tb_m_comp c ON c.`id_comp`=ad.`id_comp`
        'GROUP BY ad.id_comp"
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
        SLEUnit.EditValue = "1"
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim exp As New ClassItemExpense()
        Dim cond As String = "-1"

        cond = " AND DATE(e.created_date)>='" & Date.Parse(DEBBKFrom.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(e.created_date)<='" & Date.Parse(DEBBKTo.EditValue.ToString).ToString("yyyy-MM-dd") & "'"

        If Not SLEUnit.EditValue.ToString = "0" Then
            cond += "  AND e.id_coa_tag='" & SLEUnit.EditValue.ToString & "' "
        End If

        Dim query As String = exp.queryMain(cond, "2", False)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormItemExpense_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormItemExpense_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormItemExpense_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVData.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "0"
            noManipulating()
        End If
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = 0
            indeks = GVData.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVData_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVData.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnBankWithdrawal_Click(sender As Object, e As EventArgs) Handles BtnBankWithdrawal.Click
        Cursor = Cursors.WaitCursor
        'if already open
        Try
            FormBankWithdrawal.Close()
            FormBankWithdrawal.Dispose()
        Catch ex As Exception
        End Try

        Try
            FormBankWithdrawal.MdiParent = FormMain
            FormBankWithdrawal.Show()
            FormBankWithdrawal.WindowState = FormWindowState.Maximized
            FormBankWithdrawal.Focus()
            FormBankWithdrawal.XTCPO.SelectedTabPageIndex = 2
        Catch ex As Exception
            errorCustom(ex.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub DEBBKFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEBBKFrom.EditValueChanged
        DEBBKTo.Properties.MinValue = DEBBKFrom.EditValue
    End Sub

    Private Sub BViewPayment_Click(sender As Object, e As EventArgs) Handles BViewPayment.Click
        viewData()
    End Sub
End Class