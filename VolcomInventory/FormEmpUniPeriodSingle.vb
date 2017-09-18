Public Class FormEmpUniPeriodSingle
    Public action As String

    Private Sub FormEmpUniPeriodSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDetail()
    End Sub

    Sub viewDetail()
        If action = "ins" Then
            GCDetail.DataSource = Nothing
            Dim query As String = "SELECT 
            e.id_employee, e.employee_code, e.employee_name, e.id_departement, d.departement, e.employee_position, e.id_employee_level, l.employee_level,
            NULL AS budget 
            FROM tb_m_employee e
            INNER JOIN tb_m_departement d ON d.id_departement = e.id_departement
            LEFT JOIN tb_lookup_employee_level l ON l.id_employee_level=e.id_employee_level
            WHERE e.id_employee_active=1 "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim data_par As DataTable = FormEmpUniPeriodDet.GCDetail.DataSource
            If data_par.Rows.Count = 0 Then
                GCDetail.DataSource = data
            Else
                Dim t1 = data.AsEnumerable()
                Dim t2 = data_par.AsEnumerable()
                Dim except As DataTable = (From _t1 In t1
                                           Group Join _t2 In t2
                                           On _t1("id_employee") Equals _t2("id_employee") Into Group
                                           From _t3 In Group.DefaultIfEmpty()
                                           Where _t3 Is Nothing
                                           Select _t1).CopyToDataTable
                GCDetail.DataSource = except
            End If
        Else
            Dim query As String = "SELECT 
            e.id_employee, e.employee_code, e.employee_name, e.id_departement, d.departement, e.employee_position, e.id_employee_level, l.employee_level,
            NULL AS budget 
            FROM tb_m_employee e
            INNER JOIN tb_m_departement d ON d.id_departement = e.id_departement
            LEFT JOIN tb_lookup_employee_level l ON l.id_employee_level=e.id_employee_level
            INNER JOIN tb_emp_uni_budget b ON b.id_employee = e.id_employee AND b.id_emp_uni_budget=" + FormEmpUniPeriodDet.GVDetail.GetFocusedRowCellValue("id_emp_uni_budget").ToString + " "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDetail.DataSource = data
            GVDetail.FocusedRowHandle = 0
            GVDetail.SetFocusedRowCellValue("budget", FormEmpUniPeriodDet.GVDetail.GetFocusedRowCellValue("budget"))
            GVDetail.FocusedColumn = GridColumnBudget
            RepositoryItemTextEdit1.NullText = 0
            BtnOK.Text = "Edit"
        End If
    End Sub

    Private Sub FormEmpUniPeriodSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        If action = "ins" Then
            makeSafeGV(GVDetail)
            GVDetail.ActiveFilterString = "[budget]>=0"
            If GVDetail.RowCount > 0 Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to add this budget for these employee?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim j As Integer = 0
                    Dim query As String = "INSERT INTO tb_emp_uni_budget(id_emp_uni_period, id_employee, budget) VALUES "
                    For i As Integer = 0 To ((GVDetail.RowCount - 1) - (GetGroupRowCount(GVDetail)))
                        If j > 0 Then
                            query += ", "
                        End If
                        query += "('" + FormEmpUniPeriodDet.id_emp_uni_period + "', '" + GVDetail.GetRowCellValue(i, "id_employee").ToString + "', '" + decimalSQL(GVDetail.GetRowCellValue(i, "budget").ToString) + "') "
                        j += 1
                    Next
                    If j > 0 Then
                        execute_non_query(query, True, "", "", "", "")
                    End If
                    GVDetail.ActiveFilterString = ""
                    GridColumnDept.GroupIndex = 0
                    FormEmpUniPeriodDet.viewDetail()
                    viewDetail()
                Else
                    GVDetail.ActiveFilterString = ""
                    GridColumnDept.GroupIndex = 0
                End If
            Else
                GVDetail.ActiveFilterString = ""
                GridColumnDept.GroupIndex = 0
            End If
        Else
            GVDetail.FocusedRowHandle = 0
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to edit this budget for this employee?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_budget As String = FormEmpUniPeriodDet.GVDetail.GetFocusedRowCellValue("id_emp_uni_budget").ToString
                Dim query As String = "UPDATE tb_emp_uni_budget SET budget='" + decimalSQL(GVDetail.GetFocusedRowCellValue("budget").ToString) + "' WHERE id_emp_uni_budget=" + id_budget + " "
                execute_non_query(query, True, "", "", "", "")
                FormEmpUniPeriodDet.viewDetail()
                FormEmpUniPeriodDet.GVDetail.FocusedRowHandle = find_row(FormEmpUniPeriodDet.GVDetail, "id_emp_uni_budget", id_budget)
                Close()
            End If
        End If
    End Sub
End Class