Public Class FormPurcOrderCloseReceiving
    'close, move
    Public change_type As String = ""

    Public id_close_receiving As String = "0"
    Public id_receive_date As String = "0"

    Private id_report_status As String = ""

    Private Sub FormPurcOrderCloseReceiving_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Sub form_load()
        Dim query_select As String = ""

        If change_type = "close" Then
            query_select = "
                (SELECT c.number, DATE_FORMAT(c.created_date, '%d %M %Y %H:%i:%s') AS created_date, e.employee_name AS created_by, c.id_report_status, s.report_status
                FROM tb_purc_order_close AS c
                LEFT JOIN tb_m_employee AS e ON c.created_by = e.id_employee
                LEFT JOIN tb_lookup_report_status AS s ON c.id_report_status = s.id_report_status
                WHERE id_close_receiving = " + id_close_receiving + ")
            "
        ElseIf change_type = "move" Then
            query_select = "
                (SELECT m.number, DATE_FORMAT(m.created_date, '%d %M %Y %H:%i:%s') AS created_date, e.employee_name AS created_by, m.id_report_status, s.report_status
                FROM tb_purc_order_move_date AS m
                LEFT JOIN tb_m_employee AS e ON m.created_by = e.id_employee
                LEFT JOIN tb_lookup_report_status AS s ON m.id_report_status = s.id_report_status
                WHERE id_receive_date = " + id_receive_date + ")
            "
        End If

        Dim query As String = "
            " + query_select + "
            
            UNION ALL

            (SELECT '[autogenerate]' AS number, DATE_FORMAT(NOW(), '%d %M %Y %H:%i:%s') AS created_date, '" + get_emp(id_employee_user, "2") + "' AS created_by, 0 AS id_report_status, '' AS report_status)
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TENumber.EditValue = data.Rows(0)("number").ToString
        TECreatedDate.EditValue = data.Rows(0)("created_date").ToString
        TECreatedBy.EditValue = data.Rows(0)("created_by").ToString
        TEReportStatus.EditValue = data.Rows(0)("report_status").ToString
        id_report_status = data.Rows(0)("id_report_status").ToString

        'details
        If change_type = "close" Then
            GCPO.DataSource = execute_query("
                SELECT po.est_date_receive, po.id_purc_order, c.comp_number, c.comp_name, po.purc_order_number, (SUM(pod.qty * (pod.value - pod.discount)) - po.disc_value + po.vat_value) AS total_po, IF(ISNULL(rec.id_purc_order_det), 0, SUM(rec.qty * (pod.value - pod.discount)) - (SUM(rec.qty * (pod.value - pod.discount)) / SUM(pod.qty * (pod.value - pod.discount)) * po.disc_value) + (SUM(rec.qty * (pod.value - pod.discount)) / SUM(pod.qty * (pod.value-pod.discount)) * po.vat_value)) AS total_rec, (IFNULL(SUM(rec.qty * pod.value), 0) / SUM(pod.qty * pod.value)) * 100 AS rec_progress, IFNULL(SUM(rec.qty), 0) AS rec_qty, SUM(pod.qty) AS po_qty, IF(po.is_close_rec = 1, 'Closed', IF((IFNULL(SUM(rec.qty), 0) / SUM(pod.qty)) <= 0, 'Waiting', IF((IFNULL(SUM(rec.qty), 0) / SUM(pod.qty)) < 1, 'Partial', 'Complete'))) AS rec_status, cl_d.close_rec_reason AS close_rec_reason, '' AS to_est_date_receive
                FROM tb_purc_order_close_det cl_d
                INNER JOIN tb_purc_order po ON cl_d.id_purc_order = po.id_purc_order
                INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order` = po.`id_purc_order`
                INNER JOIN tb_m_user usr_cre ON usr_cre.id_user = po.created_by
                INNER JOIN tb_m_employee emp_cre ON emp_cre.id_employee = usr_cre.id_employee
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = po.id_comp_contact
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                LEFT JOIN 
                ( 
                    SELECT recd.`id_purc_order_det`, SUM(recd.`qty`) AS qty 
                    FROM tb_purc_rec_det recd 
                    INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec` = recd.`id_purc_rec` AND rec.`id_report_status` = '6'
                    GROUP BY recd.`id_purc_order_det`
                ) rec ON rec.id_purc_order_det = pod.`id_purc_order_det`
                LEFT JOIN
                (
                    SELECT id_purc_order, IFNULL(SUM(IF(id_report_status NOT IN (5, 6), 1, 0)), 0) AS rec_report_submit
                    FROM tb_purc_rec
                    GROUP BY id_purc_order
                ) rec_report ON po.id_purc_order = rec_report.id_purc_order
                WHERE cl_d.id_close_receiving = " + id_close_receiving + "
                GROUP BY po.id_purc_order
            ", -1, True, "", "", "", "")

            GVPO.Columns("to_est_date_receive").Visible = False
        ElseIf change_type = "move" Then
            GCPO.DataSource = execute_query("
                SELECT m_d.est_date_receive, po.id_purc_order, c.comp_number, c.comp_name, po.purc_order_number, (SUM(pod.qty * (pod.value - pod.discount)) - po.disc_value + po.vat_value) AS total_po, IF(ISNULL(rec.id_purc_order_det), 0, SUM(rec.qty * (pod.value - pod.discount)) - (SUM(rec.qty * (pod.value - pod.discount)) / SUM(pod.qty * (pod.value - pod.discount)) * po.disc_value) + (SUM(rec.qty * (pod.value - pod.discount)) / SUM(pod.qty * (pod.value-pod.discount)) * po.vat_value)) AS total_rec, (IFNULL(SUM(rec.qty * pod.value), 0) / SUM(pod.qty * pod.value)) * 100 AS rec_progress, IFNULL(SUM(rec.qty), 0) AS rec_qty, SUM(pod.qty) AS po_qty, IF(po.is_close_rec = 1, 'Closed', IF((IFNULL(SUM(rec.qty), 0) / SUM(pod.qty)) <= 0, 'Waiting', IF((IFNULL(SUM(rec.qty), 0) / SUM(pod.qty)) < 1, 'Partial', 'Complete'))) AS rec_status, '' AS close_rec_reason, m_d.to_est_date_receive
                FROM tb_purc_order_move_date_det m_d
                INNER JOIN tb_purc_order po ON m_d.id_purc_order = po.id_purc_order
                INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order` = po.`id_purc_order`
                INNER JOIN tb_m_user usr_cre ON usr_cre.id_user = po.created_by
                INNER JOIN tb_m_employee emp_cre ON emp_cre.id_employee = usr_cre.id_employee
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = po.id_comp_contact
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                LEFT JOIN 
                ( 
                    SELECT recd.`id_purc_order_det`, SUM(recd.`qty`) AS qty 
                    FROM tb_purc_rec_det recd 
                    INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec` = recd.`id_purc_rec` AND rec.`id_report_status` = '6'
                    GROUP BY recd.`id_purc_order_det`
                ) rec ON rec.id_purc_order_det = pod.`id_purc_order_det`
                LEFT JOIN
                (
                    SELECT id_purc_order, IFNULL(SUM(IF(id_report_status NOT IN (5, 6), 1, 0)), 0) AS rec_report_submit
                    FROM tb_purc_rec
                    GROUP BY id_purc_order
                ) rec_report ON po.id_purc_order = rec_report.id_purc_order
                WHERE m_d.id_receive_date = " + id_receive_date + "
                GROUP BY po.id_purc_order
            ", -1, True, "", "", "", "")

            GVPO.Columns("close_rec_reason").Visible = False
        End If

        GVPO.BestFitColumns()

        'controls
        If id_report_status = "0" Then
            'new
            SBAdd.Enabled = True
            SBRemove.Enabled = True
            SBSave.Visible = True
            SBMark.Visible = False
            SBPrint.Visible = False
        Else
            'submitted
            SBAdd.Enabled = False
            SBRemove.Enabled = False
            SBSave.Visible = False
            SBMark.Visible = True
            SBPrint.Visible = True

            SBClose.Location = New Point(686, 15)
            SBPrint.Location = New Point(594, 15)
        End If
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        FormPurcOrderCloseReceivingList.ShowDialog()
    End Sub

    Private Sub SBRemove_Click(sender As Object, e As EventArgs) Handles SBRemove.Click
        GVPO.DeleteSelectedRows()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        If GVPO.RowCount > 0 Then
            Dim cnt As Boolean = True

            If change_type = "close" Then
                For i = 0 To GVPO.RowCount - 1
                    If GVPO.GetRowCellValue(i, "close_rec_reason").ToString = "" Then
                        cnt = False
                    End If
                Next
            ElseIf change_type = "move" Then
                For i = 0 To GVPO.RowCount - 1
                    If GVPO.GetRowCellValue(i, "to_est_date_receive").ToString = "" Then
                        cnt = False
                    End If
                Next
            End If


            If cnt Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to save ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim query As String = ""

                    'header
                    If change_type = "close" Then
                        query = "INSERT INTO tb_purc_order_close (created_date, created_by, id_report_status) VALUES (NOW(), " + id_employee_user + ", 1); SELECT LAST_INSERT_ID();"

                        id_close_receiving = execute_query(query, 0, True, "", "", "", "")
                    ElseIf change_type = "move" Then
                        query = "INSERT INTO tb_purc_order_move_date (created_date, created_by, id_report_status) VALUES (NOW(), " + id_employee_user + ", 1); SELECT LAST_INSERT_ID();"

                        id_receive_date = execute_query(query, 0, True, "", "", "", "")
                    End If

                    'detail
                    If change_type = "close" Then
                        query = "INSERT INTO tb_purc_order_close_det (id_close_receiving, id_purc_order, close_rec_reason) VALUES "

                        For i = 0 To GVPO.RowCount - 1
                            query += "(" + id_close_receiving + ", " + GVPO.GetRowCellValue(i, "id_purc_order").ToString + ", '" + addSlashes(GVPO.GetRowCellValue(i, "close_rec_reason").ToString) + "'), "
                        Next
                    ElseIf change_type = "move" Then
                        query = "INSERT INTO tb_purc_order_move_date_det (id_receive_date, id_purc_order, est_date_receive, to_est_date_receive) VALUES "

                        For i = 0 To GVPO.RowCount - 1
                            query += "(" + id_receive_date + ", " + GVPO.GetRowCellValue(i, "id_purc_order").ToString + ", '" + Date.Parse(GVPO.GetRowCellValue(i, "est_date_receive").ToString).ToString("yyyy-MM-dd") + "', '" + Date.Parse(GVPO.GetRowCellValue(i, "to_est_date_receive").ToString).ToString("yyyy-MM-dd") + "'), "
                        Next
                    End If

                    execute_non_query(query.Substring(0, query.Length - 2), True, "", "", "", "")

                    'gen number & submit
                    If change_type = "close" Then
                        execute_non_query("CALL gen_number(" + id_close_receiving + ", '259')", True, "", "", "", "")

                        submit_who_prepared("259", id_close_receiving, id_user)
                    ElseIf change_type = "move" Then
                        execute_non_query("CALL gen_number(" + id_receive_date + ", '260')", True, "", "", "", "")

                        submit_who_prepared("260", id_receive_date, id_user)
                    End If

                    infoCustom("Saved.")

                    form_load()
                End If
            Else
                If change_type = "close" Then
                    stopCustom("Please add Close Receiving Reason.")
                ElseIf change_type = "move" Then
                    stopCustom("Please add To Est. Receive Date.")
                End If
            End If
        Else
            stopCustom("No PO selected.")
        End If
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = If(change_type = "close", "259", "260")
        FormReportMark.id_report = If(change_type = "close", id_close_receiving, id_receive_date)

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub FormPurcOrderCloseReceiving_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If change_type = "close" Then
            FormPurcOrder.load_close_receiving()
        ElseIf change_type = "move" Then
            FormPurcOrder.load_receive_date()
        End If

        Dispose()
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim Report As New ReportPurcOrderCloseReceiving()

        Report.id = If(change_type = "close", id_close_receiving, id_receive_date)
        Report.data = GCPO.DataSource
        Report.id_pre = If(id_report_status = "6", "-1", "1")
        Report.report_mark_type = If(change_type = "close", "259", "260")

        Report.XLNumber.Text = TENumber.EditValue.ToString
        Report.XLCreatedAt.Text = TECreatedDate.EditValue.ToString
        Report.XLCreatedBy.Text = TECreatedBy.EditValue.ToString

        If change_type = "close" Then
            Report.GVPO.Columns("to_est_date_receive").Visible = False
        Else
            Report.GVPO.Columns("close_rec_reason").Visible = False
        End If

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
    End Sub
End Class