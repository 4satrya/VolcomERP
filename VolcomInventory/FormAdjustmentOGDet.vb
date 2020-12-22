Public Class FormAdjustmentOGDet
    Public id_adjustment As String = "-1"

    Private Sub FormAdjustmentOGDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_type()
        view_departement()
        view_report_status()

        form_load()
    End Sub

    Private Sub FormAdjustmentOGDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormAdjustmentOG.form_load()

        Dispose()
    End Sub

    Sub form_load()
        Dim query As String = "
            SELECT a.id_type, a.id_departement_from, a.id_departement_to, a.number, a.note, DATE_FORMAT(a.created_at, '%d %M %Y %H:%i:%s') AS created_at, e.employee_name AS created_by, a.id_report_status
            FROM tb_adjustment_og AS a
            LEFT JOIN tb_m_employee AS e ON a.created_by = e.id_employee
            WHERE id_adjustment = " + id_adjustment + "
            UNION ALL
            SELECT 1 AS id_type, 0 AS id_departement_from, 0 AS id_departement_to, '[autogenerate]' AS number, '' AS note, DATE_FORMAT(NOW(), '%d %M %Y %H:%i:%s') AS created_at, '" + get_emp(id_employee_user, "2") + "' AS created_by, 0 AS id_report_status
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        SLUEType.EditValue = data.Rows(0)("id_type").ToString
        SLUEFromDepartment.EditValue = data.Rows(0)("id_departement_from").ToString
        SLUEToDepartement.EditValue = data.Rows(0)("id_departement_to").ToString
        TENumber.EditValue = data.Rows(0)("number").ToString
        TECreatedAt.EditValue = data.Rows(0)("created_at").ToString
        TECreatedBy.EditValue = data.Rows(0)("created_by").ToString
        SLUEStatus.EditValue = data.Rows(0)("id_report_status").ToString
        MENote.EditValue = data.Rows(0)("note").ToString

        Dim query_detail As String = "
            SELECT id_item, item_desc, uom, id_item_cat, item_cat, qty, `value`
            FROM tb_adjustment_og_det
            WHERE id_adjustment = " + id_adjustment + "
        "

        Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

        GCList.DataSource = data_detail

        GVList.BestFitColumns()

        'control
        If data.Rows(0)("id_report_status").ToString = "0" Then
            SBSubmit.Enabled = True
            SBAttachment.Enabled = False
            SBMark.Enabled = False
            SBPrint.Enabled = False

            SLUEType.ReadOnly = False
            SLUEFromDepartment.ReadOnly = False
            SLUEToDepartement.ReadOnly = False
            SBAdd.Enabled = True
            SBRemove.Enabled = True

            GVList.Columns("qty").OptionsColumn.ReadOnly = False

            MENote.ReadOnly = False
        Else
            SBSubmit.Enabled = False
            SBAttachment.Enabled = True
            SBMark.Enabled = True
            SBPrint.Enabled = True

            SLUEType.ReadOnly = True
            SLUEFromDepartment.ReadOnly = True
            SLUEToDepartement.ReadOnly = True
            SBAdd.Enabled = False
            SBRemove.Enabled = False

            GVList.Columns("qty").OptionsColumn.ReadOnly = True

            MENote.ReadOnly = True
        End If

        If data.Rows(0)("id_report_status").ToString = "5" Then
            SBPrint.Enabled = False
        End If
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        FormAdjustmentOGPick.ShowDialog()
    End Sub

    Private Sub SBRemove_Click(sender As Object, e As EventArgs) Handles SBRemove.Click
        GVList.DeleteSelectedRows()
    End Sub

    Sub view_type()
        Dim query As String = "
            SELECT 1 AS id_type, 'Adjustment In' AS `type`
            UNION ALL
            SELECT 2 AS id_type, 'Adjustment Out' AS `type`
            UNION ALL
            SELECT 3 AS id_type, 'Transfer' AS `type`
        "

        viewSearchLookupQuery(SLUEType, query, "id_type", "type", "id_type")
    End Sub

    Sub view_departement()
        Dim query As String = "
            SELECT 0 as id_departement, 'Purchasing Storage' as departement
            UNION ALL            
            SELECT id_departement, departement FROM tb_m_departement
        "

        viewSearchLookupQuery(SLUEFromDepartment, query, "id_departement", "departement", "id_departement")
        viewSearchLookupQuery(SLUEToDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Sub view_report_status()
        Dim query As String = "
            SELECT id_report_status, report_status
            FROM tb_lookup_report_status
        "

        viewSearchLookupQuery(SLUEStatus, query, "id_report_status", "report_status", "id_report_status")
    End Sub

    Private Sub SLUEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEType.EditValueChanged
        If SLUEType.EditValue.ToString = "3" Then
            Label5.Visible = True
            SLUEToDepartement.Visible = True
        Else
            Label5.Visible = False
            SLUEToDepartement.Visible = False
        End If

        Dim query_detail As String = "
            SELECT id_item, item_desc, uom, id_item_cat, item_cat, qty, `value`
            FROM tb_adjustment_og_det
            WHERE id_adjustment = " + id_adjustment + "
        "

        Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

        GCList.DataSource = data_detail

        GVList.BestFitColumns()
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = "241"
        FormReportMark.id_report = id_adjustment

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBAttachment_Click(sender As Object, e As EventArgs) Handles SBAttachment.Click
        Cursor = Cursors.WaitCursor

        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.id_report = id_adjustment
        FormDocumentUpload.report_mark_type = "241"

        FormDocumentUpload.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBSubmit_Click(sender As Object, e As EventArgs) Handles SBSubmit.Click
        Dim msg As String = ""

        If GVList.RowCount = 0 Then
            msg = "Please select item"
        End If

        For i = 0 To GVList.RowCount - 1
            If GVList.GetRowCellValue(i, "qty") = 0 Then
                msg = "Qty cannot be 0"
            End If
        Next

        If MENote.Text = "" Then
            msg = "Please add note"
        End If

        If msg = "" Then
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_type As String = SLUEType.EditValue.ToString
                Dim id_departement_from As String = SLUEFromDepartment.EditValue.ToString
                Dim id_departement_to As String = If(id_type = "3", SLUEToDepartement.EditValue.ToString, "NULL")
                Dim created_at As String = "NOW()"
                Dim created_by As String = id_employee_user
                Dim id_report_status As String = "1"
                Dim note As String = MENote.EditValue.ToString

                Dim query As String = "
                    INSERT INTO tb_adjustment_og (id_type, id_departement_from, id_departement_to, note, created_at, created_by, id_report_status) VALUES (" + id_type + ", " + id_departement_from + "," + id_departement_to + ", '" + addSlashes(note) + "', " + created_at + ", " + created_by + ", " + id_report_status + "); SELECT LAST_INSERT_ID();
                "

                id_adjustment = execute_query(query, 0, True, "", "", "", "")

                execute_non_query("CALL gen_number(" + id_adjustment + ", '241')", True, "", "", "", "")

                For i = 0 To GVList.RowCount - 1
                    Dim id_item As String = GVList.GetRowCellValue(i, "id_item").ToString
                    Dim item_desc As String = "'" + addSlashes(GVList.GetRowCellValue(i, "item_desc").ToString) + "'"
                    Dim uom As String = "'" + addSlashes(GVList.GetRowCellValue(i, "uom").ToString) + "'"
                    Dim id_item_cat As String = GVList.GetRowCellValue(i, "id_item_cat").ToString
                    Dim item_cat As String = "'" + addSlashes(GVList.GetRowCellValue(i, "item_cat").ToString) + "'"
                    Dim qty As String = decimalSQL(GVList.GetRowCellValue(i, "qty").ToString)
                    Dim value As String = decimalSQL(GVList.GetRowCellValue(i, "value").ToString)

                    query = "INSERT INTO tb_adjustment_og_det (id_adjustment, id_item, item_desc, uom, id_item_cat, item_cat, qty, value) VALUES (" + id_adjustment + ", " + id_item + ", " + item_desc + ", " + uom + ", " + id_item_cat + ", " + item_cat + ", " + qty + ", " + value + ")"

                    execute_non_query(query, True, "", "", "", "")
                Next

                submit_who_prepared("241", id_adjustment, id_user)

                Close()
            End If
        Else
            stopCustom(msg)
        End If
    End Sub

    Sub update_changes()
        If SLUEType.EditValue.ToString = "3" Then
            Dim queryOut As String = "
                INSERT INTO tb_storage_item (id_comp, id_departement, id_storage_category, id_item, `value`, report_mark_type, id_report, storage_item_qty, storage_item_datetime, storage_item_notes, id_stock_status)
                SELECT 0 AS id_comp, a.id_departement_from AS id_departement, 2 AS id_storage_category, d.id_item, d.value, 241 AS report_mark_type, a.id_adjustment AS id_report, d.qty AS storage_item_qty, NOW() AS storage_item_datetime, a.note AS storage_item_notes, 1 AS id_stock_status
                FROM tb_adjustment_og_det AS d
                LEFT JOIN tb_adjustment_og AS a ON a.id_adjustment = d.id_adjustment
                WHERE d.id_adjustment = " + id_adjustment

            execute_non_query(queryOut, True, "", "", "", "")

            Dim queryIn As String = "
                INSERT INTO tb_storage_item (id_comp, id_departement, id_storage_category, id_item, `value`, report_mark_type, id_report, storage_item_qty, storage_item_datetime, storage_item_notes, id_stock_status)
                SELECT 0 AS id_comp, a.id_departement_to AS id_departement, 1 AS id_storage_category, d.id_item, d.value, 241 AS report_mark_type, a.id_adjustment AS id_report, d.qty AS storage_item_qty, NOW() AS storage_item_datetime, a.note AS storage_item_notes, 1 AS id_stock_status
                FROM tb_adjustment_og_det AS d
                LEFT JOIN tb_adjustment_og AS a ON a.id_adjustment = d.id_adjustment
                WHERE d.id_adjustment = " + id_adjustment

            execute_non_query(queryIn, True, "", "", "", "")
        Else
            Dim query As String = "
                INSERT INTO tb_storage_item (id_comp, id_departement, id_storage_category, id_item, `value`, report_mark_type, id_report, storage_item_qty, storage_item_datetime, storage_item_notes, id_stock_status)
                SELECT 0 AS id_comp, a.id_departement_from AS id_departement, a.id_type AS id_storage_category, d.id_item, d.value, 241 AS report_mark_type, a.id_adjustment AS id_report, d.qty AS storage_item_qty, NOW() AS storage_item_datetime, a.note AS storage_item_notes, 1 AS id_stock_status
                FROM tb_adjustment_og_det AS d
                LEFT JOIN tb_adjustment_og AS a ON a.id_adjustment = d.id_adjustment
                WHERE d.id_adjustment = " + id_adjustment

            execute_non_query(query, True, "", "", "", "")
        End If
    End Sub

    Private Sub SLUEFromDepartment_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEFromDepartment.EditValueChanged
        Dim query_detail As String = "
            SELECT id_item, item_desc, uom, id_item_cat, item_cat, qty, `value`
            FROM tb_adjustment_og_det
            WHERE id_adjustment = " + id_adjustment + "
        "

        Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

        GCList.DataSource = data_detail

        GVList.BestFitColumns()
    End Sub

    Private Sub GVList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVList.CellValueChanged
        If e.Column.FieldName = "qty" Then
            If e.Value >= 0 Then
                If Not SLUEType.EditValue.ToString = "1" Then
                    Dim date_until_selected As String = Date.Parse(Now).ToString("yyyy-MM-dd")

                    Dim dept As String = SLUEFromDepartment.EditValue.ToString
                    Dim cat As String = "0"
                    '
                    If dept = "-1" Then
                        dept = "AND i.id_item = " + GVList.GetRowCellValue(e.RowHandle, "id_item").ToString
                    Else
                        dept = "AND i.id_item = " + GVList.GetRowCellValue(e.RowHandle, "id_item").ToString + " AND i.id_departement=" + dept + ""
                    End If

                    Dim stc As New ClassPurcItemStock()
                    Dim query As String = stc.queryGetStock(dept, cat, date_until_selected)
                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                    Dim res As Decimal = data.Rows(0)("qty") - GVList.GetRowCellValue(e.RowHandle, "qty")

                    If res < 0 Then
                        stopCustom("Please input value less than " + data.Rows(0)("qty").ToString)

                        GVList.SetRowCellValue(e.RowHandle, "qty", 0)
                    End If
                End If
            Else
                stopCustom("Please input value greater than 0")

                GVList.SetRowCellValue(e.RowHandle, "qty", 0)
            End If
        End If
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim report As ReportAdjustmentOG = New ReportAdjustmentOG

        report.XLNumber.Text = TENumber.Text
        report.XLType.Text = SLUEType.Text
        report.XLFromDepartement.Text = SLUEFromDepartment.Text
        report.XLToDepartement.Text = SLUEToDepartement.Text
        report.XLNote.Text = MENote.Text
        report.XLCreatedDate.Text = TECreatedAt.Text
        report.XLCreatedBy.Text = TECreatedBy.Text

        report.id_adjustment = id_adjustment
        report.data = GCList.DataSource

        If Not SLUEType.EditValue.ToString = "3" Then
            report.XLToDepartementL.Visible = False
            report.XLToDepartementD.Visible = False
            report.XLToDepartement.Visible = False
        End If

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreviewDialog()
    End Sub
End Class