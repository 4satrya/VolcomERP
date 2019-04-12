Public Class FormEmpUniPeriodSelect
    Public data As DataTable
    Public id_pop_up As String = "-1"

    Private Sub FormEmpUniPeriodSelect_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpUniPeriodSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_pop_up = "2" Then
            Dim query_c As ClassEmpUni = New ClassEmpUni()
            Dim query As String = query_c.queryMain("AND u.id_emp_uni_period!=" + FormEmpUniPeriodDet.id_emp_uni_period + "", "2")
            data = execute_query(query, -1, True, "", "", "", "")
            GVUni.BestFitColumns()
        End If
        GCUni.DataSource = data
    End Sub

    Sub choose()
        Cursor = Cursors.WaitCursor
        If GVUni.RowCount > 0 And GVUni.FocusedRowHandle >= 0 Then
            If id_pop_up = "-1" Then 'admin
                Dim id_periode As String = GVUni.GetFocusedRowCellValue("id_emp_uni_period").ToString
                FormEmpUniPeriodDet.MdiParent = FormMain
                FormEmpUniPeriodDet.action = "upd"
                FormEmpUniPeriodDet.id_emp_uni_period = id_periode
                Close()
                FormEmpUniPeriodDet.is_public_form = True
                FormEmpUniPeriodDet.Show()
                FormEmpUniPeriodDet.WindowState = FormWindowState.Maximized
                FormEmpUniPeriodDet.Focus()
            ElseIf id_pop_up = "1" Then
                FormMain.id_period_uniform_sel = GVUni.GetFocusedRowCellValue("id_emp_uni_period").ToString
                Close()
            ElseIf id_pop_up = "2" Then
                Dim id_periode As String = GVUni.GetFocusedRowCellValue("id_emp_uni_period").ToString
                Dim id_employee_u As String = FormEmpUniPeriodSingle.GVDetail.GetFocusedRowCellValue("id_employee").ToString
                Dim qs As String = "SELECT ((b.budget/pr.budget_point)*100)-IFNULL(SUM(l.`point`),0) AS `sisa`, IFNULL(so.id_report_status,0) AS `id_report_status`
                FROM tb_sales_order so
                INNER JOIN tb_emp_uni_period pr ON pr.id_emp_uni_period = so.id_emp_uni_period
                INNER JOIN tb_emp_uni_budget b ON b.id_emp_uni_budget = so.id_emp_uni_budget AND b.id_employee=" + id_employee_u + "
                INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
                INNER JOIN tb_m_product p ON p.id_product = sod.id_product
                INNER JOIN (
	                SELECT udd.`no`,udd.id_design,udd.`point` 
	                FROM tb_emp_uni_design_det udd 
	                INNER JOIN tb_emp_uni_design ud ON ud.id_emp_uni_design = udd.id_emp_uni_design
	                WHERE ud.id_emp_uni_period=" + id_periode + " AND ud.id_report_status=6
	                GROUP BY udd.id_design
	                ORDER BY udd.`no` ASC
                ) l ON l.id_design = p.id_design
                WHERE so.id_emp_uni_period=" + id_periode + " AND so.id_report_status=6 "
                Dim ds As DataTable = execute_query(qs, -1, True, "", "", "", "")
                If ds.Rows(0)("id_report_status") = "6" Then
                    If ds.Rows.Count > 0 Then
                        Dim db As DataTable = execute_query("SELECT * FROM tb_emp_uni_period p WHERE p.id_emp_uni_period=" + id_periode + "", -1, True, "", "", "", "")
                        FormEmpUniPeriodSingle.GVDetail.SetFocusedRowCellValue("budget", (db.Rows(0)("budget_point") / 100) * ds.Rows(0)("sisa"))
                    Else
                        stopCustom("Sisa budget tidak ditemukan")
                    End If
                Else
                    stopCustom("Sisa budget tidak ditemukan")
                End If
                Close()
                ' MsgBox()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        choose()
    End Sub

    Private Sub GVUni_DoubleClick(sender As Object, e As EventArgs) Handles GVUni.DoubleClick
        choose()
    End Sub
End Class