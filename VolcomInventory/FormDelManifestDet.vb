Public Class FormDelManifestDet
    Public id_del_manifest As String = "0"

    Public is_block_del_store As String = get_setup_field("is_block_del_store")

    Private Sub FormDelManifestDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_3pl()
        form_load()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        If SLUE3PL.EditValue.ToString = "0" Then
            stopCustom("Please select 3PL.")
        Else
            FormDelManifestPick.ShowDialog()
        End If
    End Sub

    Private Sub SBRemove_Click(sender As Object, e As EventArgs) Handles SBRemove.Click
        GVList.DeleteSelectedRows()
    End Sub

    Private Sub SBComplete_Click(sender As Object, e As EventArgs) Handles SBComplete.Click
        save("complete")
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        save("draft")
    End Sub

    Private Sub SBCancel_Click(sender As Object, e As EventArgs) Handles SBCancel.Click
        save("cancel")
    End Sub

    Sub form_load()
        Dim query As String = "
            SELECT m.id_del_manifest, m.id_comp, m.number, DATE_FORMAT(m.created_date, '%d %M %Y %H:%i:%s') AS created_date, DATE_FORMAT(m.updated_date, '%d %M %Y %H:%i:%s') AS updated_date, ea.employee_name AS created_by, eb.employee_name AS updated_by, m.id_report_status, IFNULL(l.report_status, 'Draft') AS report_status
            FROM tb_del_manifest AS m
            LEFT JOIN tb_m_user AS ua ON m.created_by = ua.id_user
            LEFT JOIN tb_m_employee AS ea ON ua.id_employee = ea.id_employee
            LEFT JOIN tb_m_user AS ub ON m.created_by = ub.id_user
            LEFT JOIN tb_m_employee AS eb ON ub.id_employee = eb.id_employee
            LEFT JOIN tb_lookup_report_status AS l ON m.id_report_status = l.id_report_status
            WHERE m.id_del_manifest = " + id_del_manifest + "

            UNION

            SELECT 0 AS id_del_manifest, 0 AS id_comp, '[autogenerate]' AS number, DATE_FORMAT(NOW(), '%d %M %Y %H:%i:%s') AS created_date, '' AS updated_date, (SELECT employee_name FROM tb_m_employee WHERE id_employee = " + id_employee_user + ") AS created_by, '' AS updated_by, '' AS id_report_status, '' AS report_status
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        SLUE3PL.EditValue = data.Rows(0)("id_comp")
        TENumber.EditValue = data.Rows(0)("number").ToString
        TECreatedDate.EditValue = data.Rows(0)("created_date").ToString
        TEUpdatedDate.EditValue = data.Rows(0)("updated_date").ToString
        TECreatedBy.EditValue = data.Rows(0)("created_by").ToString
        TEUpdatedBy.EditValue = data.Rows(0)("updated_by").ToString
        TEReportStatus.EditValue = data.Rows(0)("report_status").ToString

        Dim query_det As String = "
            SELECT 0 AS no, mdet.id_wh_awb_det, c.id_comp_group, cg.id_comp_group_header, a.awbill_date, adet.do_no, pdel.pl_sales_order_del_number, c.comp_number, c.comp_name, adet.qty, ct.city, a.weight, a.width, a.length, a.height, ((a.width * a.length * a.height) / 6000) AS volume, a.c_weight
            FROM tb_del_manifest_det AS mdet
            LEFT JOIN tb_wh_awbill_det AS adet ON mdet.id_wh_awb_det = adet.id_wh_awb_det
            LEFT JOIN tb_wh_awbill AS a ON adet.id_awbill = a.id_awbill
            LEFT JOIN tb_m_comp AS c ON a.id_store = c.id_comp
            LEFT JOIN tb_m_comp_group AS cg ON cg.id_comp_group = c.id_comp_group
            LEFT JOIN tb_m_city AS ct ON c.id_city = ct.id_city
            LEFT JOIN tb_pl_sales_order_del AS pdel ON adet.id_pl_sales_order_del = pdel.id_pl_sales_order_del
            WHERE mdet.id_del_manifest = " + id_del_manifest + "
        "

        GCList.DataSource = execute_query(query_det, -1, True, "", "", "", "")

        GVList.BestFitColumns()

        'controls
        If data.Rows(0)("id_report_status").ToString = "" Then
            SLUE3PL.ReadOnly = False

            SBCancel.Enabled = False

            If id_del_manifest <> "0" Then
                SBCancel.Enabled = True
            End If

            SBPrint.Enabled = False
            SBSave.Enabled = True
            SBComplete.Enabled = True

            SBAdd.Enabled = True
            SBRemove.Enabled = True
        Else
            SLUE3PL.ReadOnly = True

            SBCancel.Enabled = False
            SBPrint.Enabled = True
            SBSave.Enabled = False
            SBComplete.Enabled = False

            If data.Rows(0)("id_report_status").ToString = "5" Then
                SBPrint.Enabled = False
            End If

            SBAdd.Enabled = False
            SBRemove.Enabled = False
        End If

        SBAttachement.Enabled = True

        If id_del_manifest = "0" Then
            SBAttachement.Enabled = False
        End If
    End Sub

    Sub view_3pl()
        Dim query As String = "(SELECT 0 AS id_comp, '' AS comp_name) UNION ALL (SELECT id_comp, comp_name AS comp_name FROM tb_m_comp WHERE id_comp_cat = 7)"

        viewSearchLookupQuery(SLUE3PL, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub save(ByVal type As String)
        If SLUE3PL.EditValue.ToString = "0" Then
            stopCustom("Please select 3PL.")
        ElseIf GVList.RowCount < 1 Then
            stopCustom("Please add delivery.")
        Else
            Dim continue_save As Boolean = True

            If type = "complete" Or type = "cancel" Then
                Dim confirm As DialogResult

                confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to " + type + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                If confirm = Windows.Forms.DialogResult.Yes Then
                    continue_save = True
                Else
                    continue_save = False
                End If
            End If

            If continue_save Then
                Dim query As String = ""

                If id_del_manifest = "0" Then
                    query = "INSERT INTO tb_del_manifest (id_comp, created_date, created_by) VALUES (" + SLUE3PL.EditValue.ToString + ", NOW(), " + id_user + "); SELECT LAST_INSERT_ID();"

                    id_del_manifest = execute_query(query, 0, True, "", "", "", "")
                Else
                    'update
                    query = "UPDATE tb_del_manifest SET id_comp = " + SLUE3PL.EditValue.ToString + ", updated_date = NOW(), updated_by = " + id_user + ", id_report_status = " + If(type = "draft", "NULL", If(type = "complete", "6", "5")) + " WHERE id_del_manifest = " + id_del_manifest

                    execute_non_query(query, True, "", "", "", "")

                    'delete
                    query = "DELETE FROM tb_del_manifest_det WHERE id_del_manifest = " + id_del_manifest

                    execute_non_query(query, True, "", "", "", "")
                End If

                'detail
                query = "INSERT INTO tb_del_manifest_det (id_del_manifest, id_wh_awb_det) VALUES "

                For i = 0 To GVList.RowCount - 1
                    If GVList.IsValidRowHandle(i) Then
                        query += "(" + id_del_manifest + ", " + GVList.GetRowCellValue(i, "id_wh_awb_det").ToString + "), "
                    End If
                Next

                query = query.Substring(0, query.Length - 2)

                execute_non_query(query, True, "", "", "", "")

                execute_non_query("CALL gen_number(" + id_del_manifest + ", '232')", True, "", "", "", "")

                If type = "draft" Then
                    form_load()
                Else
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub GVList_RowCountChanged(sender As Object, e As EventArgs) Handles GVList.RowCountChanged
        For i = 0 To GVList.RowCount - 1
            If GVList.IsValidRowHandle(i) Then
                GVList.SetRowCellValue(i, "no", i + 1)
            End If
        Next
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim id_group As List(Of String) = New List(Of String)

        For i = 0 To GVList.RowCount - 1
            If GVList.IsValidRowHandle(i) Then
                If Not id_group.Contains(GVList.GetRowCellValue(i, "id_comp_group_header").ToString) Then
                    id_group.Add(GVList.GetRowCellValue(i, "id_comp_group_header").ToString)
                End If
            End If
        Next

        Dim on_hold As Boolean = False

        For i = 0 To id_group.Count - 1
            'chek invoice
            Dim del As New ClassSalesDelOrder()

            If is_block_del_store = "1" And del.checkUnpaidInvoiceGroup(id_group(i)) Then
                on_hold = True
            End If
        Next

        If on_hold Then
            stopCustom("Hold delivery")
        Else
            Dim report As ReportDelManifest = New ReportDelManifest

            report.id_del_manifest = id_del_manifest
            report.dt = GCList.DataSource

            report.XrLabelNumber.Text = TENumber.Text
            report.XrLabel3PL.Text = SLUE3PL.Text

            Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

            tool.ShowPreview()
        End If
    End Sub

    Private Sub SBAttachement_Click(sender As Object, e As EventArgs) Handles SBAttachement.Click
        Cursor = Cursors.WaitCursor

        Dim id_report_status As String = execute_query("SELECT IFNULL((SELECT id_report_status FROM tb_del_manifest WHERE id_del_manifest = " + id_del_manifest + "), 0) AS id_report_status", 0, True, "", "", "", "")

        FormDocumentUpload.is_no_delete = If(Not id_report_status = "0", "1", "-1")
        FormDocumentUpload.is_view = If(Not id_report_status = "0", "1", "-1")
        FormDocumentUpload.id_report = id_del_manifest
        FormDocumentUpload.report_mark_type = "232"

        FormDocumentUpload.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub FormDelManifestDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            FormDelManifest.form_load()
        Catch ex As Exception
        End Try

        Dispose()
    End Sub
End Class