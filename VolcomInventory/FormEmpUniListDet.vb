Public Class FormEmpUniListDet
    Public id_emp_uni_design As String = "-1"
    Public id_emp_uni_period As String = "-1"
    Dim id_report_status As String = " -1"
    Dim id_wh_drawer As String = "-1"
    Public is_view As String = "-1"

    Private Sub FormEmpUniListDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewWH()
        viewPeriodUniform()
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "Select * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Dim list As New ClassEmpUni()
        Dim query As String = list.queryMainList("And d.id_emp_uni_design='" + id_emp_uni_design + "' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LEPeriodx.ItemIndex = LEPeriodx.Properties.GetDataSourceRowIndex("id_emp_uni_period", data.Rows(0)("id_emp_uni_period").ToString)
        SLEWH.EditValue = data.Rows(0)("id_wh_drawer").ToString
        id_wh_drawer = data.Rows(0)("id_wh_drawer").ToString
        MENote.Text = data.Rows(0)("note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString
        id_emp_uni_period = data.Rows(0)("id_emp_uni_period").ToString


        'check mark
        Dim qm As String = "SELECT * FROM tb_report_mark rm WHERE rm.report_mark_type=123 AND id_report =" + id_emp_uni_design + " "
        Dim dm As DataTable = execute_query(qm, -1, True, "", "", "", "")
        If dm.Rows.Count > 0 Then
            BtnSave.Enabled = False
            PanelControlNav.Visible = False
        Else
            BtnSave.Enabled = True
            PanelControlNav.Visible = True
        End If

        BtnAttachment.Enabled = True
        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        'viewDetail
        viewDetailList()
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_emp_uni_design_new(" + id_emp_uni_design + ") "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.Columns("1").Caption = "1" + System.Environment.NewLine + "XXS"
        GVData.Columns("2").Caption = "2" + System.Environment.NewLine + "XS"
        GVData.Columns("3").Caption = "3" + System.Environment.NewLine + "S"
        GVData.Columns("4").Caption = "4" + System.Environment.NewLine + "M"
        GVData.Columns("5").Caption = "5" + System.Environment.NewLine + "ML"
        GVData.Columns("6").Caption = "6" + System.Environment.NewLine + "L"
        GVData.Columns("7").Caption = "7" + System.Environment.NewLine + "XL"
        GVData.Columns("8").Caption = "8" + System.Environment.NewLine + "XXL"
        GVData.Columns("9").Caption = "9" + System.Environment.NewLine + "ALL"
        GVData.Columns("0").Caption = "0" + System.Environment.NewLine + "SM"
        GVData.RefreshData()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetailList()
        Dim query As String = "SELECT dd.`no`, dd.`point`, d.design_code AS `code`, d.design_display_name AS `name`,
        GROUP_CONCAT(DISTINCT cd.code_detail_name ORDER BY cd.id_code_detail ASC SEPARATOR ',') AS `size_chart`
        FROM tb_emp_uni_design_det dd
        INNER JOIN tb_m_design d ON d.id_design = dd.id_design
        INNER JOIN tb_m_product p ON p.id_design = d.id_design
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        WHERE dd.id_emp_uni_design=" + id_emp_uni_design + "
        GROUP BY dd.id_design
        ORDER BY dd.`no` ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
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
        If GVData.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim note As String = addSlashes(MENote.Text)
                Dim query As String = "UPDATE tb_emp_uni_design SET note='" + note + "' WHERE id_emp_uni_design=" + id_emp_uni_design + " "
                execute_non_query(query, True, "", "", "", "")

                'submit
                Dim qm As String = "SELECT * FROM tb_report_mark rm WHERE rm.report_mark_type=123 AND id_report =" + id_emp_uni_design + " "
                Dim dm As DataTable = execute_query(qm, -1, True, "", "", "", "")
                If dm.Rows.Count <= 0 Then
                    submit_who_prepared("123", id_emp_uni_design, id_user)
                End If

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

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        If is_view = "1" Then
            FormReportMark.is_view = is_view
        End If
        FormReportMark.report_mark_type = "123"
        FormReportMark.id_report = id_emp_uni_design
        FormReportMark.ShowDialog()
        actionLoad()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        If is_view = "1" Then
            FormDocumentUpload.is_view = is_view
        End If
        FormDocumentUpload.id_report = id_emp_uni_design
        FormDocumentUpload.report_mark_type = "123"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnImportExcelNew_Click(sender As Object, e As EventArgs) Handles BtnImportExcelNew.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "33"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        'Dim view As DevExpress.XtraGrid.Views.Base.ColumnView = TryCast(sender, DevExpress.XtraGrid.Views.Base.ColumnView)
        'If (e.Column.FieldName = "1" Or e.Column.FieldName = "2" Or e.Column.FieldName = "3" Or e.Column.FieldName = "4" Or e.Column.FieldName = "5" Or e.Column.FieldName = "6" Or e.Column.FieldName = "7" Or e.Column.FieldName = "8" Or e.Column.FieldName = "9" Or e.Column.FieldName = "0" Or e.Column.FieldName = "total_qty") AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
        '    Dim qty As Decimal = Convert.ToDecimal(e.Value)
        '    If qty = 0 Then
        '        e.DisplayText = "-"
        '    End If
        'End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        If XTCListNew.SelectedTabPageIndex = 0 Then
            print_raw(GCList, "")
        Else
            print_raw(GCData, "")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCList_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs)

    End Sub

    Private Sub XTCListNew_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCListNew.SelectedPageChanged
        If XTCListNew.SelectedTabPageIndex = 0 Then
            viewDetailList()
        Else
            viewDetail()
        End If
    End Sub
End Class