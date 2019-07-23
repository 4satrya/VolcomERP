Public Class ReportEmpPayrollOvertime
    Public id_payroll As String
    Public id_pre As String
    Public is_office_payroll As String

    Private Sub ReportEmpPayrollOvertime_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = "
            SELECT * 
            FROM (
                SELECT IFNULL(dep.departement, dep_ori.departement) AS `Departement`, IF(dep.id_departement = 17, IFNULL(sub.departement_sub, sub_ori.departement_sub), IFNULL(dep.departement, dep_ori.departement)) AS `Sub Departement`, emp.`employee_code` AS `NIP`, emp.`employee_name` AS `Employee`, emp.`employee_position` AS `Employee Position`, sts.`employee_status` AS `Employee Status`, ot.reg_total_point AS `Point Reguler`, ot.reg_total_wages AS `Overtime Reguler`, (ot.mkt_total_point + ot.ia_total_point + ot.sales_total_point + ot.prod_total_point + ot.hrd_total_point + ot.general_total_point) AS `Point Event`, (IFNULL(ot.mkt_total_wages, 0) + IFNULL(ot.ia_total_wages, 0) + IFNULL(ot.sales_total_wages, 0) + IFNULL(ot.prod_total_wages, 0) + IFNULL(ot.hrd_total_wages, 0)) AS `Overtime Event`, ((SELECT IFNULL(`Overtime Reguler`, 0)) + (SELECT IFNULL(`Overtime Event`, 0))) AS `Total Overtime`
                FROM tb_emp_payroll_det pyd
                LEFT JOIN tb_emp_payroll py ON py.id_payroll=pyd.id_payroll
                LEFT JOIN tb_m_employee emp ON pyd.id_employee=emp.id_employee
                LEFT JOIN (
                    SELECT * FROM (
                        SELECT id_employee, id_departement, id_departement_sub, employee_position, employee_position_date
                        FROM tb_m_employee_position
                        WHERE employee_position_date <= (SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "')
                        ORDER BY id_employee_position DESC
                    ) AS tab
                    GROUP BY id_employee
                ) AS emp_pos ON pyd.id_employee = emp_pos.id_employee
                LEFT JOIN tb_m_departement dep ON dep.`id_departement`=emp_pos.`id_departement`
                LEFT JOIN tb_m_departement dep_ori ON dep_ori.id_departement = emp.id_departement
                LEFT JOIN tb_m_departement_sub sub ON sub.`id_departement_sub`=emp_pos.`id_departement_sub`
                LEFT JOIN tb_m_departement_sub sub_ori ON sub_ori.id_departement_sub = emp.id_departement_sub
                LEFT JOIN `tb_lookup_employee_status` sts ON sts.`id_employee_status`=emp.`id_employee_status`
                LEFT JOIN
                (
                    SELECT ot.id_employee AS id_emp
                    ,SUM(IF(ot.id_ot_type=1,total_hour,0)) AS reg_total_hour,SUM(IF(ot.id_ot_type=1,total_point,0)) AS reg_total_point,SUM(IF(ot.id_ot_type=1,ROUND(((IF((SELECT id_payroll_type FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + ")=1,(SELECT ot_sal.basic_salary + ot_sal.allow_job + ot_sal.allow_meal + ot_sal.allow_trans),IFNULL(ot_py.dw_overtime_var,(ot_sal.basic_salary*22)))*(ot_py.ot_reg_pembilang/ot_py.ot_reg_penyebut)*total_point)),10),0)) AS reg_total_wages
                    ,SUM(IF(ot.id_ot_type=2,total_hour,0)) AS mkt_total_hour,SUM(IF(ot.id_ot_type=2,total_point,0)) AS mkt_total_point,SUM(IF(ot.id_ot_type=2,total_point*wages_per_point,0)) AS mkt_total_wages
                    ,SUM(IF(ot.id_ot_type=3,total_hour,0)) AS ia_total_hour,SUM(IF(ot.id_ot_type=3,total_point,0)) AS ia_total_point,SUM(IF(ot.id_ot_type=3,total_point*wages_per_point,0)) AS ia_total_wages
                    ,SUM(IF(ot.id_ot_type=4,total_hour,0)) AS sales_total_hour,SUM(IF(ot.id_ot_type=4,total_point,0)) AS sales_total_point,SUM(IF(ot.id_ot_type=4,total_point*wages_per_point,0)) AS sales_total_wages
                    ,SUM(IF(ot.id_ot_type=5,total_hour,0)) AS prod_total_hour,SUM(IF(ot.id_ot_type=5,total_point,0)) AS prod_total_point,SUM(IF(ot.id_ot_type=5,total_point*wages_per_point,0)) AS prod_total_wages
                    ,SUM(IF(ot.id_ot_type=6,total_hour,0)) AS hrd_total_hour,SUM(IF(ot.id_ot_type=6,total_point,0)) AS hrd_total_point,SUM(IF(ot.id_ot_type=6,total_point*wages_per_point,0)) AS hrd_total_wages
                    ,SUM(IF(ot.id_ot_type=7,total_hour,0)) AS general_total_hour,SUM(IF(ot.id_ot_type=7,total_point,0)) AS general_total_point,SUM(IF(ot.id_ot_type=7,total_point*wages_per_point,0)) AS general_total_wages
                    FROM tb_emp_payroll_ot ot
                    LEFT JOIN tb_emp_payroll AS ot_py ON ot.id_payroll = ot_py.id_payroll
                    LEFT JOIN tb_emp_payroll_det AS ot_py_det ON ot_py.id_payroll = ot_py_det.id_payroll AND ot.id_employee = ot_py_det.id_employee
                    LEFT JOIN (
                SELECT *
                FROM tb_m_employee_salary
                WHERE id_employee_salary IN (SELECT id_salary FROM tb_emp_payroll_det WHERE id_payroll = " + id_payroll + ")
                    ) AS ot_sal ON ot.id_employee = ot_sal.id_employee
                    WHERE ot.id_payroll=IF((SELECT id_payroll_type FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + " LIMIT 1) = 4, (SELECT id_payroll FROM tb_emp_payroll WHERE periode_start = (SELECT periode_start FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + " LIMIT 1) AND periode_end = (SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + " LIMIT 1) AND id_payroll_type = 1 LIMIT 1), " + id_payroll + ")
                    GROUP BY ot.id_payroll,ot.id_employee
                ) ot ON ot.id_emp = pyd.`id_employee`
                WHERE pyd.id_payroll = " + id_payroll + " AND IFNULL(dep.is_office_payroll, dep_ori.is_office_payroll) = " + is_office_payroll + "
                ORDER BY emp.id_employee_level ASC, emp.employee_code ASC
            ) AS overtime
            WHERE overtime.`Total Overtime` > 0
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCOvertime.DataSource = data

        'mark
        If id_pre = "-1" Then
            load_mark_horz("192", id_payroll, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("192", id_payroll, "2", "2", XrTable1)
        End If
    End Sub

    Private Sub GVOverTime_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVOverTime.CustomColumnDisplayText
        If e.IsForGroupRow Then
            'sogo
            If e.DisplayText.ToString.Contains("SOGO") Then
                If e.Column.Caption = "Departement" Then
                    e.DisplayText = "Departement: " + e.DisplayText
                ElseIf e.Column.Caption = "Sub Departement" Then
                    e.DisplayText = "Sub Departement: " + e.DisplayText
                End If
            Else
                If e.Column.Caption = "Departement" Then
                    e.DisplayText = "Departement: " + e.DisplayText
                ElseIf e.Column.Caption = "Sub Departement" Then
                    e.DisplayText = ""
                End If
            End If
        End If
    End Sub

    Dim sum_point_reg As Double = 0
    Dim sum_ot_reg As Double = 0
    Dim sum_point_evt As Double = 0
    Dim sum_ot_evt As Double = 0
    Dim sum_tot As Double = 0

    Private Sub GVOvertime_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVOverTime.CustomSummaryCalculate

        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "Point Reguler" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    sum_point_reg = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    sum_point_reg += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If GVOverTime.GetRowCellValue(e.RowHandle, "Sub Departement").ToString.Contains("SOGO") Then
                        e.TotalValue = sum_point_reg
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = sum_point_reg
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "Overtime Reguler" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    sum_ot_reg = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    sum_ot_reg += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If GVOverTime.GetRowCellValue(e.RowHandle, "Sub Departement").ToString.Contains("SOGO") Then
                        e.TotalValue = sum_ot_reg
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = sum_ot_reg
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "Point Event" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    sum_point_evt = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    sum_point_evt += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If GVOverTime.GetRowCellValue(e.RowHandle, "Sub Departement").ToString.Contains("SOGO") Then
                        e.TotalValue = sum_point_evt
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = sum_point_evt
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "Overtime Event" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    sum_ot_evt = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    sum_ot_evt += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If GVOverTime.GetRowCellValue(e.RowHandle, "Sub Departement").ToString.Contains("SOGO") Then
                        e.TotalValue = sum_ot_evt
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = sum_ot_evt
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "Total Overtime" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    sum_tot = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    sum_tot += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If GVOverTime.GetRowCellValue(e.RowHandle, "Sub Departement").ToString.Contains("SOGO") Then
                        e.TotalValue = sum_tot
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = sum_tot
                        End If
                    End If
            End Select
        End If
    End Sub
End Class