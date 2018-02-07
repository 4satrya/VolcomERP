Public Class FormEmpUniListDet
    Public id_emp_uni_design As String = "-1"
    Dim id_report_status As String = "-1"

    Private Sub FormEmpUniListDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewWH()
        viewPeriodUniform()
        actionLoad()
    End Sub

    Sub actionLoad()
        Dim list As New ClassEmpUni()
        Dim query As String = list.queryMainList("AND d.id_emp_uni_design='" + id_emp_uni_design + "' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LEPeriodx.ItemIndex = LEPeriodx.Properties.GetDataSourceRowIndex("id_emp_uni_period", data.Rows(0)("id_emp_uni_period").ToString)
        SLEWH.EditValue = data.Rows(0)("id_wh_drawer").ToString
        MENote.Text = data.Rows(0)("note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString

        'check mark
        Dim qm As String = "SELECT * FROM tb_report_mark rm WHERE rm.report_mark_type=123 AND id_report =" + id_emp_uni_design + " "
        Dim dm As DataTable = execute_query(qm, -1, True, "", "", "", "")
        If dm.Rows.Count > 0 Then
            BMark.Visible = True
            BtnSave.Enabled = False
        Else
            BMark.Visible = False
            BtnSave.Enabled = True
        End If

        BtnAttachment.Enabled = True
        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
    End Sub

    Private Sub FormEmpUniListDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    Sub viewPeriodUniform()
        Dim query As String = "SELECT * FROM tb_emp_uni_period p ORDER BY p.id_emp_uni_period DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LEPeriodx.Properties.DataSource = Nothing
        LEPeriodx.Properties.DataSource = data
        LEPeriodx.Properties.DisplayMember = "period_name"
        LEPeriodx.Properties.ValueMember = "id_emp_uni_period"
        LEPeriodx.ItemIndex = 0
    End Sub

    Sub viewWH()
        Dim query As String = ""
        query += "SELECT e.id_drawer_def,e.id_comp, e.comp_number, e.comp_name, CONCAT_WS(' - ', e.comp_number, e.comp_name) AS comp_name_label FROM tb_storage_fg a "
        query += "INNER JOIN tb_m_wh_drawer b ON a.id_wh_drawer = b.id_wh_drawer "
        query += "INNER JOIN tb_m_wh_rack c ON b.id_wh_rack = c.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator d ON c.id_wh_locator = d.id_wh_locator "
        query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
        query += "WHERE e.id_comp_cat=5 "
        query += "GROUP BY e.id_comp "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLEWH.Properties.DataSource = Nothing
        SLEWH.Properties.DataSource = data
        SLEWH.Properties.DisplayMember = "comp_name_label"
        SLEWH.Properties.ValueMember = "id_drawer_def"
        If data.Rows.Count.ToString >= 1 Then
            SLEWH.EditValue = data.Rows(0)("id_drawer_def").ToString
        Else
            SLEWH.EditValue = Nothing
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If GVItemList.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim note As String = addSlashes(MENote.Text)
                Dim query As String = "UPDATE tb_emp_uni_design SET note='" + note + "' WHERE id_emp_uni_design=" + id_emp_uni_design + " "
                execute_non_query(query, True, "", "", "", "")

                'sumbit
                submit_who_prepared("123", id_emp_uni_design, id_user)

                'view data
                FormEmpUniList.viewData()
                FormEmpUniList.GVData.FocusedRowHandle = find_row(FormEmpUniList.GVData, "id_emp_uni_design", id_emp_uni_design)
                actionLoad()
                infoCustom("Uniform List : " + LEPeriodx.Text + " was created successfully. ")
                Cursor = Cursors.Default
            End If
        Else
            stopCustom("Data can't blank !")
        End If
    End Sub
End Class