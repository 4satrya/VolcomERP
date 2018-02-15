Public Class FormEmpUniListNew
    Private Sub FormEmpUniListNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
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

    Private Sub FormEmpUniListNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewPeriodUniform()
        viewWH()
        Dim id As String = "-1"
        Try
            id = LEPeriodx.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim qc As String = "SELECT * FROM tb_emp_uni_design d WHERE d.id_emp_uni_period='" + id + "' AND d.id_report_status!=5 "
        Dim data As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            SLEWH.EditValue = data.Rows(0)("id_wh_drawer").ToString
            SLEWH.Enabled = False
        Else
            SLEWH.Enabled = True
        End If
    End Sub


    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        Dim id_period As String = LEPeriodx.EditValue.ToString
        Dim id_wh_drawer As String = SLEWH.EditValue.ToString
        If id_period = "" Or id_wh_drawer = "" Then
            stopCustom("Data can't blank")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "INSERT INTO tb_emp_uni_design(id_emp_uni_period, id_wh_drawer, created_date, id_report_status) 
                VALUES('" + id_period + "', '" + id_wh_drawer + "',NOW(),'1'); SELECT LAST_INSERT_ID(); "
                Dim id_new As String = execute_query(query, 0, True, "", "", "", "")
                FormEmpUniList.viewData()
                FormEmpUniList.GVData.FocusedRowHandle = find_row(FormEmpUniList.GVData, "id_emp_uni_design", id_new)
                Close()
                FormEmpUniListDet.id_emp_uni_design = id_new
                FormEmpUniListDet.ShowDialog()
            End If
        End If
    End Sub

    Private Sub LEPeriodx_EditValueChanged(sender As Object, e As EventArgs) Handles LEPeriodx.EditValueChanged
        Dim id As String = "-1"
        Try
            id = LEPeriodx.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim qc As String = "SELECT * FROM tb_emp_uni_design d WHERE d.id_emp_uni_period='" + id + "' AND d.id_report_status!=5 "
        Dim data As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            SLEWH.EditValue = data.Rows(0)("id_wh_drawer").ToString
            SLEWH.Enabled = False
        Else
            SLEWH.Enabled = True
        End If
    End Sub
End Class