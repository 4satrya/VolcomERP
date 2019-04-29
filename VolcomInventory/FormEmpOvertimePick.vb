Public Class FormEmpOvertimePick
    Public is_hrd As String = "-1"

    Private Sub FormEmpOvertimePick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim notIncluded As String = ""

        For i = 0 To FormEmpOvertimeDet.GVEmployee.RowCount - 1
            If FormEmpOvertimeDet.GVEmployee.IsValidRowHandle(i) Then
                notIncluded += FormEmpOvertimeDet.GVEmployee.GetRowCellValue(i, "id_employee") + ", "
            End If
        Next

        Dim whereHrd As String = If(is_hrd = "-1", "AND e.id_departement = " + id_departement_user + "", "")

        If Not notIncluded = "" Then
            notIncluded = notIncluded.Substring(0, notIncluded.Length - 2)

            notIncluded = "AND id_employee NOT IN (" + notIncluded + ")"
        End If

        Dim query As String = "
            SELECT e.id_employee, 'no' AS is_checked, e.id_departement, d.departement, e.employee_code, e.employee_name, e.employee_position, e.id_employee_level, ll.employee_level, e.id_employee_active, la.employee_active, IF(e.id_employee_level < 13, 'yes', 'no') AS only_dp
            FROM tb_m_employee AS e 
            LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement 
            LEFT JOIN tb_lookup_employee_level AS ll ON e.id_employee_level = ll.id_employee_level
            LEFT JOIN tb_lookup_employee_active AS la ON e.id_employee_active = la.id_employee_active
            WHERE 1 " + whereHrd + " " + notIncluded + "
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        ' find Active by id
        Dim active As String = ""

        For i = 1 To data.Rows.Count - 1
            If data.Rows(i)("id_employee_active").ToString = "1" Then
                active = data.Rows(i)("employee_active").ToString

                Exit For
            End If
        Next

        GVList.ActiveFilter.Add(GVList.Columns("employee_active"), New DevExpress.XtraGrid.Columns.ColumnFilterInfo("[employee_active] = '" + active + "'"))

        GVList.BestFitColumns()
    End Sub

    Private Sub FormEmpOvertimePick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBSelect_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        pick()
    End Sub

    Sub pick()
        GVList.ApplyFindFilter("")

        GVList.ExpandAllGroups()

        Dim data As DataTable = FormEmpOvertimeDet.GCEmployee.DataSource

        For i = 0 To GVList.RowCount - 1
            If GVList.GetRowCellValue(i, "is_checked") = "yes" Then
                Dim conversion_type As String = If(GVList.GetRowCellValue(i, "only_dp") = "yes", "2", "1")

                data.Rows.Add(GVList.GetRowCellValue(i, "id_employee"),
                              GVList.GetRowCellValue(i, "only_dp"),
                              GVList.GetRowCellValue(i, "id_departement"),
                              GVList.GetRowCellValue(i, "departement"),
                              GVList.GetRowCellValue(i, "employee_code"),
                              GVList.GetRowCellValue(i, "employee_name"),
                              GVList.GetRowCellValue(i, "employee_position"),
                              GVList.GetRowCellValue(i, "id_employee_level"),
                              GVList.GetRowCellValue(i, "employee_level"),
                              conversion_type,
                              "",
                              "",
                              "no")
            End If
        Next

        FormEmpOvertimeDet.GCEmployee.DataSource = data

        FormEmpOvertimeDet.GCEmployee.RefreshDataSource()

        FormEmpOvertimeDet.GVEmployee.BestFitColumns()

        Close()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub
End Class