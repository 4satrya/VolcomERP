Public Class FormDelManifestDet
    Public id_del_manifest As String = "0"

    Public is_block_del_store As String = get_setup_field("is_block_del_store")

    Private loaded As Boolean = False

    Private Sub FormDelManifestDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaded = False

        view_3pl()
        form_load()

        loaded = True
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
        Cursor = Cursors.WaitCursor

        save("draft")

        Cursor = Cursors.Default
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
            SELECT *
            FROM (
                SELECT 0 AS no, mdet.id_wh_awb_det, c.id_comp_group, a.awbill_date, a.id_awbill, IFNULL(pdelc.combine_number, adet.do_no) AS combine_number, adet.do_no, pdel.pl_sales_order_del_number, c.comp_number, c.comp_name, CONCAT((ROUND(IF(pdelc.combine_number IS NULL, adet.qty, z.qty), 0)), ' ') AS qty, ct.city, a.weight, a.width, a.length, a.height, ((a.width * a.length * a.height) / 6000) AS volume, a.c_weight
                FROM tb_del_manifest_det AS mdet
                LEFT JOIN tb_wh_awbill_det AS adet ON mdet.id_wh_awb_det = adet.id_wh_awb_det
                LEFT JOIN tb_wh_awbill AS a ON adet.id_awbill = a.id_awbill
                LEFT JOIN tb_m_comp AS c ON a.id_store = c.id_comp
                LEFT JOIN tb_m_city AS ct ON c.id_city = ct.id_city
                LEFT JOIN tb_pl_sales_order_del AS pdel ON adet.id_pl_sales_order_del = pdel.id_pl_sales_order_del
                LEFT JOIN tb_pl_sales_order_del_combine AS pdelc ON pdel.id_combine = pdelc.id_combine
                LEFT JOIN (
	                SELECT z3.combine_number, SUM(pl_sales_order_del_det_qty) AS qty
	                FROM tb_pl_sales_order_del_det AS z1
	                LEFT JOIN tb_pl_sales_order_del AS z2 ON z1.id_pl_sales_order_del = z2.id_pl_sales_order_del
	                LEFT JOIN tb_pl_sales_order_del_combine AS z3 ON z2.id_combine = z3.id_combine
	                GROUP BY z2.id_combine
                ) AS z ON pdelc.combine_number = z.combine_number
                WHERE mdet.id_del_manifest = " + id_del_manifest + "
            ) AS tb
            ORDER BY tb.comp_number ASC, tb.id_awbill ASC, tb.combine_number ASC
        "

        Dim data_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")

        'manipulate merge qty & total qty
        Dim last_collie As String = ""
        Dim last_combine As String = ""

        Dim total_qty As Integer = 0

        Dim qty_manipulated As String = ""

        For i = 0 To data_det.Rows.Count - 1
            If i = 0 Then
                last_collie = data_det.Rows(i)("id_awbill").ToString
                last_combine = data_det.Rows(i)("combine_number").ToString

                total_qty = total_qty + Integer.Parse(data_det.Rows(i)("qty").ToString.Replace(" ", ""))
            End If

            'merge qty
            If Not last_collie = data_det.Rows(i)("id_awbill").ToString Then
                qty_manipulated = qty_manipulated + " "
            End If

            'total qty
            If Not last_combine = data_det.Rows(i)("combine_number").ToString Then
                total_qty = total_qty + Integer.Parse(data_det.Rows(i)("qty").ToString.Replace(" ", ""))
            End If

            data_det.Rows(i)("qty") = data_det.Rows(i)("qty") + qty_manipulated

            last_collie = data_det.Rows(i)("id_awbill").ToString
            last_combine = data_det.Rows(i)("combine_number").ToString
        Next

        GCList.DataSource = data_det

        'set total qty
        GridColumnQty.SummaryItem.DisplayFormat = total_qty.ToString

        GVList.BestFitColumns()

        'controls
        If data.Rows(0)("id_report_status").ToString = "" Then
            SLUE3PL.ReadOnly = False

            SBCancel.Enabled = False

            If id_del_manifest <> "0" Then
                SBCancel.Enabled = True
            End If

            SBPrint.Enabled = False
            SBPrePrint.Enabled = True
            SBSave.Enabled = True
            SBComplete.Enabled = True

            SBAdd.Enabled = True
            SBRemove.Enabled = True
        Else
            SLUE3PL.ReadOnly = True

            SBCancel.Enabled = False
            SBPrint.Enabled = True
            SBPrePrint.Enabled = True
            SBSave.Enabled = False
            SBComplete.Enabled = False

            If data.Rows(0)("id_report_status").ToString = "5" Then
                SBPrint.Enabled = False
                SBPrePrint.Enabled = False
            End If

            SBAdd.Enabled = False
            SBRemove.Enabled = False
        End If

        SBAttachement.Enabled = True

        If id_del_manifest = "0" Then
            SBPrePrint.Enabled = False
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
        'manipulate numbering, merge qty & total qty
        Dim last_collie As String = ""
        Dim last_combine As String = ""

        Dim total_qty As Integer = 0

        Dim qty_manipulated As String = ""

        Dim no As Integer = 1

        For i = 0 To GVList.RowCount - 1
            If GVList.IsValidRowHandle(i) Then
                If i = 0 Then
                    last_collie = GVList.GetRowCellValue(i, "id_awbill").ToString
                    last_combine = GVList.GetRowCellValue(i, "combine_number").ToString

                    total_qty = total_qty + Integer.Parse(GVList.GetRowCellValue(i, "qty").ToString.Replace(" ", ""))
                End If

                'numbering & merge qty
                If Not last_collie = GVList.GetRowCellValue(i, "id_awbill").ToString Then
                    qty_manipulated = qty_manipulated + " "

                    no = no + 1
                End If

                'total qty
                If Not last_combine = GVList.GetRowCellValue(i, "combine_number").ToString Then
                    total_qty = total_qty + Integer.Parse(GVList.GetRowCellValue(i, "qty").ToString.Replace(" ", ""))
                End If

                GVList.SetRowCellValue(i, "qty", GVList.GetRowCellValue(i, "qty").ToString.Replace(" ", "") + qty_manipulated)

                GVList.SetRowCellValue(i, "no", no)

                last_collie = GVList.GetRowCellValue(i, "id_awbill").ToString
                last_combine = GVList.GetRowCellValue(i, "combine_number").ToString
            End If
        Next

        'set total qty
        GridColumnQty.SummaryItem.DisplayFormat = total_qty.ToString
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        print("2")
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

            If Not id_del_manifest = "0" Then
                FormDelManifest.GVList.FocusedRowHandle = find_row(FormDelManifest.GVList, "id_del_manifest", id_del_manifest)
            End If
        Catch ex As Exception
        End Try

        Dispose()
    End Sub

    Private Sub SBPrePrint_Click(sender As Object, e As EventArgs) Handles SBPrePrint.Click
        Cursor = Cursors.WaitCursor

        If compare_database() Then
            print("1")
        Else
            stopCustom("Please save changes first.")
        End If

        Cursor = Cursors.Default
    End Sub

    Sub print(ByVal id_pre As String)
        Dim id_group As List(Of String) = New List(Of String)

        For i = 0 To GVList.RowCount - 1
            If GVList.IsValidRowHandle(i) Then
                If Not id_group.Contains(GVList.GetRowCellValue(i, "id_comp_group").ToString) Then
                    id_group.Add(GVList.GetRowCellValue(i, "id_comp_group").ToString)
                End If
            End If
        Next

        Dim on_hold As Boolean = False

        If id_pre = "2" Then
            For i = 0 To id_group.Count - 1
                'chek invoice
                Dim del As New ClassSalesDelOrder()

                If is_block_del_store = "1" And del.checkUnpaidInvoice(id_group(i)) Then
                    on_hold = True
                End If
            Next
        End If

        If on_hold Then
            stopCustom("Hold delivery")
        Else
            Dim data_view As DataView = New DataView(GCList.DataSource)

            data_view.Sort = "comp_number ASC, id_awbill ASC, combine_number ASC"

            Dim report As ReportDelManifest = New ReportDelManifest

            report.id_del_manifest = id_del_manifest
            report.id_pre = id_pre
            report.dt = data_view.ToTable

            report.XrLabelNumber.Text = TENumber.Text
            report.XrLabel3PL.Text = SLUE3PL.Text

            Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

            tool.ShowPreview()
        End If
    End Sub

    Private Sub SLUE3PL_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles SLUE3PL.EditValueChanging
        If loaded And GVList.RowCount > 0 Then
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Change 3PL will reset list, are you sure ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                For i = GVList.RowCount - 1 To 0 Step -1
                    If GVList.IsValidRowHandle(i) Then
                        GVList.DeleteRow(i)
                    End If
                Next
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Function compare_database() As Boolean
        Dim query As String = "
            SELECT *
            FROM (
                SELECT 0 AS no, mdet.id_wh_awb_det, c.id_comp_group, a.awbill_date, a.id_awbill, IFNULL(pdelc.combine_number, adet.do_no) AS combine_number, adet.do_no, pdel.pl_sales_order_del_number, c.comp_number, c.comp_name, CONCAT((ROUND(IF(pdelc.combine_number IS NULL, adet.qty, z.qty), 0)), ' ') AS qty, ct.city, a.weight, a.width, a.length, a.height, ((a.width * a.length * a.height) / 6000) AS volume, a.c_weight
                FROM tb_del_manifest_det AS mdet
                LEFT JOIN tb_wh_awbill_det AS adet ON mdet.id_wh_awb_det = adet.id_wh_awb_det
                LEFT JOIN tb_wh_awbill AS a ON adet.id_awbill = a.id_awbill
                LEFT JOIN tb_m_comp AS c ON a.id_store = c.id_comp
                LEFT JOIN tb_m_city AS ct ON c.id_city = ct.id_city
                LEFT JOIN tb_pl_sales_order_del AS pdel ON adet.id_pl_sales_order_del = pdel.id_pl_sales_order_del
                LEFT JOIN tb_pl_sales_order_del_combine AS pdelc ON pdel.id_combine = pdelc.id_combine
                LEFT JOIN (
	                SELECT z3.combine_number, SUM(pl_sales_order_del_det_qty) AS qty
	                FROM tb_pl_sales_order_del_det AS z1
	                LEFT JOIN tb_pl_sales_order_del AS z2 ON z1.id_pl_sales_order_del = z2.id_pl_sales_order_del
	                LEFT JOIN tb_pl_sales_order_del_combine AS z3 ON z2.id_combine = z3.id_combine
	                GROUP BY z2.id_combine
                ) AS z ON pdelc.combine_number = z.combine_number
                WHERE mdet.id_del_manifest = " + id_del_manifest + "
            ) AS tb
            ORDER BY tb.comp_number ASC, tb.id_awbill ASC, tb.combine_number ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim match As Boolean = True

        For i = 0 To data.Rows.Count - 1
            Dim getin As Boolean = False

            For j = 0 To GVList.RowCount - 1
                If GVList.IsValidRowHandle(j) Then
                    If data.Rows(i)("id_wh_awb_det").ToString = GVList.GetRowCellValue(j, "id_wh_awb_det").ToString Then
                        getin = True
                    End If
                End If
            Next

            If Not getin Then
                match = False
            End If
        Next

        For i = 0 To GVList.RowCount - 1
            If GVList.IsValidRowHandle(i) Then
                Dim getin As Boolean = False

                For j = 0 To data.Rows.Count - 1
                    If GVList.GetRowCellValue(i, "id_wh_awb_det").ToString = data.Rows(j)("id_wh_awb_det").ToString Then
                        getin = True
                    End If
                Next

                If Not getin Then
                    match = False
                End If
            End If
        Next

        Return match
    End Function
End Class