Public Class FormCashAdvance
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormCashAdvance_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormCashAdvance_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "1"
        bedit_active = "1"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormCashAdvance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_type()
        load_dep()
        load_employee()
        load_status()
        '
    End Sub

    Sub load_status()
        Dim query As String = "SELECT 0 as id_status,'All status' AS status 
UNION SELECT 1 as id_status,'Open' AS status 
UNION SELECT 2 as id_status,'Overdue' AS status 
UNION SELECT 3 as id_status,'On Process' AS status 
UNION SELECT 4 as id_status,'Closed' AS status 
UNION SELECT 5 as id_status,'Cancelled' AS status 
UNION SELECT 6 as id_status,'Not Cancelled' AS status 
"
        viewSearchLookupQuery(SLEStatus, query, "id_status", "status", "id_status")
    End Sub

    Sub load_type()
        Dim query As String = "SELECT 0 as id_cash_advance_type,'All type' as cash_advance_type
UNION
SELECT id_cash_advance_type,cash_advance_type FROM tb_lookup_cash_advance_type"
        viewSearchLookupQuery(SLEType, query, "id_cash_advance_type", "cash_advance_type", "id_cash_advance_type")
    End Sub

    Sub load_dep()
        Dim query As String = "SELECT 0 as id_departement,'All Departement' as departement
UNION
SELECT id_departement,departement FROM tb_m_departement"
        viewSearchLookupQuery(SLEDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Sub load_employee()
        Dim query As String = "SELECT 0 as id_employee,'All Employee' as employee_name
UNION
SELECT id_employee,employee_name FROM tb_m_employee"

        If Not SLEDepartement.EditValue.ToString = "0" Then
            query += " WHERE tb_m_employee.id_departement='" & SLEDepartement.EditValue.ToString & "'"
        End If

        viewSearchLookupQuery(SLEEmployee, query, "id_employee", "employee_name", "id_employee")
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_cash_advance()
    End Sub

    Sub load_cash_advance()
        Dim date_from As String = ""
        Dim date_to As String = ""

        Try
            date_from = DateTime.Parse(DateFrom.EditValue.ToString).ToString("yyyy-MM-dd")
            date_to = DateTime.Parse(DateTo.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim where_string As String = ""

        Try
            If Not SLEType.EditValue.ToString = "0" Then
                where_string += " AND ca.id_cash_advance_type='" & SLEType.EditValue.ToString & "' "
            End If

            If SLEEmployee.EditValue.ToString = "0" Then 'all employee
                If Not SLEDepartement.EditValue.ToString = "0" Then 'from spesific departement
                    where_string += " AND ca.id_departement='" & SLEDepartement.EditValue.ToString & "' "
                End If
            Else 'spesific employee
                where_string += " AND ca.id_employee='" & SLEEmployee.EditValue.ToString & "' "
            End If

            If Not SLEStatus.EditValue.ToString = "0" Then
                If SLEStatus.EditValue.ToString = "1" Then 'open
                    where_string += " AND ca.rb_id_report_status !=6 AND ca.id_report_status !=5 AND IFNULL(recon.jml,0) <= 0 AND DATE(ca.report_back_due_date)>=DATE(NOW())"
                ElseIf SLEStatus.EditValue.ToString = "2" Then 'overdue
                    where_string += " AND ca.rb_id_report_status !=6 AND ca.id_report_status !=5 AND IFNULL(recon.jml,0) <= 0 AND DATE(ca.report_back_due_date)<DATE(NOW())"
                ElseIf SLEStatus.EditValue.ToString = "3" Then 'on process
                    where_string += " AND ca.rb_id_report_status !=6 AND ca.id_report_status !=5 AND IFNULL(recon.jml,0) > 0"
                ElseIf SLEStatus.EditValue.ToString = "4" Then 'closed
                    where_string += " AND ca.rb_id_report_status =6"
                ElseIf SLEStatus.EditValue.ToString = "5" Then 'cancelled
                    where_string += " AND ca.id_report_status =5"
                ElseIf SLEStatus.EditValue.ToString = "6" Then 'cancelled
                    where_string += " AND ca.id_report_status !=5"
                End If
            End If

            If Not date_from = "" Then
                where_string += " AND ca.date_created >= '" + date_from + "'"
            End If

            If Not date_to = "" Then
                where_string += " AND ca.date_created <= '" + date_to + "'"
            End If
        Catch ex As Exception
        End Try

        Dim query As String = "SELECT 'no' AS is_check,ca.act_report_back_date,ca.`id_cash_advance`,ca.`number`,ca.`id_cash_advance_type`,cat.`cash_advance_type`,ca.`date_created`,ca.`created_by`,emp_created.`employee_name` AS emp_created
,ca.`id_employee`,emp.`employee_name`,ca.`id_departement`,dep.`departement`,ca.`val_ca`,ca.`note`,ca.`id_report_status`,sts.`report_status`,sts_rb.report_status AS report_back_status
,ca.report_back_date,ca.report_back_due_date,ca.id_report_status,IFNULL(recon.jml,0) as jml,IFNULL(recon.recon_value,ca.`val_ca`) AS recon_value
,IF(ca.id_report_status=5, 'Cancelled', IF(ca.rb_id_report_status !=6 AND IFNULL(recon.jml,0) <= 0,IF(DATE(ca.report_back_due_date)<DATE(NOW()),'Overdue','Open'),IF(ca.rb_id_report_status =6,'Closed','On Process'))) AS rb_status
,IF(ca.rb_id_report_status !=6 AND IFNULL(recon.jml,0) <= 0 AND ca.id_report_status!=5,DATEDIFF(NOW(),ca.report_back_due_date),0) AS overdue
FROM tb_cash_advance ca
INNER JOIN tb_lookup_cash_advance_type cat ON cat.`id_cash_advance_type`=ca.`id_cash_advance_type`
INNER JOIN tb_m_user usr_created ON usr_created.`id_user`=ca.`created_by`
INNER JOIN tb_m_employee emp_created ON emp_created.`id_employee`=usr_created.`id_employee`
INNER JOIN tb_m_departement dep ON dep.`id_departement`=ca.`id_departement`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=ca.`id_employee`
INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=ca.`id_report_status`
INNER JOIN tb_lookup_report_status sts_rb ON sts_rb.id_report_status=ca.rb_id_report_status
LEFT JOIN 
( 
    SELECT id_cash_advance, count(jml) as jml, SUM(recon_value) as recon_value
    FROM (
        SELECT id_cash_advance,count(id_cash_advance) as jml,SUM(`value`) AS recon_value FROM tb_cash_advance_report GROUP BY id_cash_advance
        UNION
        SELECT id_cash_advance,count(id_cash_advance) as jml,0 AS recon_value FROM tb_cash_advance_report_det GROUP BY id_cash_advance
    ) AS tb
    GROUP BY id_cash_advance
) recon ON recon.id_cash_advance=ca.id_cash_advance
WHERE 1=1 " & where_string & " ORDER BY ca.`date_created` DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListOpen.DataSource = data
        GVListOpen.BestFitColumns()
    End Sub

    Private Sub SLEDepartement_EditValueChanged(sender As Object, e As EventArgs) Handles SLEDepartement.EditValueChanged
        load_employee()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        load_cash_advance()

        print_list()
    End Sub

    Private Sub BAccountability_Click(sender As Object, e As EventArgs) Handles BAccountability.Click
        If GVListOpen.RowCount > 0 Then
            If GVListOpen.GetFocusedRowCellValue("id_report_status").ToString = "6" Then
                'If GVListOpen.GetFocusedRowCellValue("rb_status").ToString = "Closed" Then
                'warningCustom("Cash advance already closed")
                'Else
                FormCashAdvanceReconcile.id_ca = GVListOpen.GetFocusedRowCellValue("id_cash_advance").ToString
                FormCashAdvanceReconcile.ShowDialog()
                'End If
            ElseIf GVListOpen.GetFocusedRowCellValue("id_report_status").ToString = "5" Then
                warningCustom("This report is cancelled")
            Else
                warningCustom("This report need approve first")
            End If
        End If
    End Sub

    Private Sub GVListOpen_DoubleClick(sender As Object, e As EventArgs) Handles GVListOpen.DoubleClick
        FormCashAdvanceDet.id_ca = GVListOpen.GetFocusedRowCellValue("id_cash_advance")
        FormCashAdvanceDet.ShowDialog()
    End Sub

    Sub print_list()
        GCType.Visible = False
        GCCreatedDate.Visible = False
        GCProposalStatus.Visible = False
        GCReportBackDueDate.Visible = False
        GCReportBackStatus.Visible = False

        GVListOpen.BestFitColumns()

        print(Me.GCListOpen, "Cash Advance")

        GCNumber.VisibleIndex = 0
        GCType.VisibleIndex = 1
        GCCreatedDate.VisibleIndex = 2
        GCDepartement.VisibleIndex = 3
        GCEmployee.VisibleIndex = 4
        GCCashInAdvance.VisibleIndex = 5
        GCNote.VisibleIndex = 6
        GCProposalStatus.VisibleIndex = 7
        GCReportBackDate.VisibleIndex = 8
        GCReportBackDueDate.VisibleIndex = 9
        GCReportBackStatus.VisibleIndex = 10
    End Sub

    Private Sub BCreateReport_Click(sender As Object, e As EventArgs) Handles BCreateReport.Click
        FormCashAdvanceReport.ShowDialog()
    End Sub
End Class