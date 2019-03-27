﻿Public Class FormEmpOvertimePick
    Public is_hrd As String = "-1"

    Private Sub FormEmpOvertimePick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim notIncluded As String = ""

        For i = 0 To FormEmpOvertimeDet.GVEmployee.RowCount - 1
            notIncluded += FormEmpOvertimeDet.GVEmployee.GetRowCellValue(i, "id_employee") + ", "
        Next

        If Not notIncluded = "" Then
            notIncluded = notIncluded.Substring(0, notIncluded.Length - 2)

            notIncluded = "AND id_employee NOT IN (" + notIncluded + ")"
        End If

        Dim query As String = "
            SELECT e.id_employee, 'no' AS is_checked, d.departement, e.employee_code, e.employee_name, e.employee_position, ll.employee_level
            FROM tb_m_employee AS e 
            LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement 
            LEFT JOIN tb_lookup_employee_level AS ll ON e.id_employee_level = ll.id_employee_level
            WHERE id_employee_active = 1 " + notIncluded + "
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()
    End Sub

    Private Sub FormEmpOvertimePick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBSelect_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        pick()
    End Sub

    Sub pick()
        GVList.ExpandAllGroups()

        Dim data As DataTable = FormEmpOvertimeDet.GCEmployee.DataSource

        For i = 0 To GVList.RowCount - 1
            If GVList.GetRowCellValue(i, "is_checked") = "yes" Then
                data.Rows.Add(GVList.GetRowCellValue(i, "id_employee"), GVList.GetRowCellValue(i, "employee_code"), GVList.GetRowCellValue(i, "employee_name"), GVList.GetRowCellValue(i, "employee_position"), GVList.GetRowCellValue(i, "employee_level"))
            End If
        Next

        FormEmpOvertimeDet.GCEmployee.DataSource = data

        Close()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub
End Class