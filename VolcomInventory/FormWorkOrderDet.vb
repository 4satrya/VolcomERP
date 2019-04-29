Public Class FormWorkOrderDet
    Public id_wo As String = "-1"
    Public id_status As String = "1"
    Public is_view As String = "-1"
    Public rmt As String = "-1"

    Private Sub FormWorkOrderDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
        load_work_order_type()
        load_urgency()
        TEReqNUmber.Text = "[auto_generate]"
        TEReqBy.Text = get_emp(id_user, "4")
        TEDep.Text = get_emp(id_user, "5")
        DEDateCreated.EditValue = Now

        If id_wo = "-1" Then
            'new
            BtnPrint.Visible = False
            BMark.Visible = False
            BAttachment.Visible = False
        Else
            'edit
            Dim query As String = "SELECT wo.is_urgent,wo.`id_work_order`,wo.report_mark_type,wot.report_mark_type,wot.id_sub_departement,wo.id_report_status,wo.`id_work_order_type`,wo.`number`,wo.`note`,wo.`created_date`,emp.`employee_name`,dep.`departement` FROM tb_work_order wo
INNER JOIN tb_m_user usr ON usr.`id_user`=wo.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_m_departement dep ON dep.`id_departement`=wo.`id_departement_created`
INNER jOIN tb_lookup_work_order_type wot ON wot.id_work_order_type=wo.id_work_order_type
WHERE wo.`id_work_order`='" & id_wo & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TEReqNUmber.Text = data.Rows(0)("number").ToString
                TEReqBy.Text = data.Rows(0)("employee_name").ToString
                DEDateCreated.EditValue = data.Rows(0)("created_date")
                SLEType.EditValue = data.Rows(0)("id_work_order_type").ToString
                SLEUrgency.EditValue = data.Rows(0)("is_urgent").ToString
                id_status = data.Rows(0)("id_report_status").ToString
                MENote.Text = data.Rows(0)("note").ToString
                '
                rmt = data.Rows(0)("report_mark_type").ToString
            End If
            '
            BtnPrint.Visible = True
            BMark.Visible = True
            SLEType.Enabled = False
            '
            If check_edit_report_status(id_status, rmt, id_wo) Then
                BtnSave.Visible = False
            Else
                BtnSave.Visible = True
            End If
            '
            If id_departement_sub_user = data.Rows(0)("id_sub_departement").ToString() Then
                BUpdateUrgency.Visible = True
            Else
                BUpdateUrgency.Visible = False
            End If
            '
            BAttachment.Visible = True
        End If
    End Sub

    Sub load_work_order_type()
        Dim query As String = "Select wot.`id_work_order_type`,wot.report_mark_type, wot.`work_order_type`, dep.`departement` FROM tb_lookup_work_order_type wot
INNER JOIN tb_m_departement_sub sub ON sub.`id_departement_sub`=wot.`id_sub_departement`
INNER JOIN tb_m_departement dep ON dep.`id_departement`=sub.`id_departement`"
        viewSearchLookupQuery(SLEType, query, "id_work_order_type", "work_order_type", "id_work_order_type")
        '
    End Sub

    Sub load_urgency()
        Dim query As String = "Select '2' AS is_urgent,'Not Urgent' AS urgent
UNION
SELECT '1' AS is_urgent,'Urgent' AS urgent"
        viewSearchLookupQuery(SLEUrgency, query, "is_urgent", "urgent", "is_urgent")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If MENote.Text = "" Then
            warningCustom("Please describe the problem simple and clear.")
        Else
            If id_wo = "-1" Then 'new
                'search rmt
                Dim q_rmt As String = "SELECT report_mark_type FROM tb_lookup_work_order_type WHERE id_work_order_type='" & SLEType.EditValue.ToString & "'"
                rmt = execute_query(q_rmt, 0, True, "", "", "", "")

                Dim query As String = "INSERT INTO tb_work_order(id_work_order_type,is_urgent,created_date,created_by,id_departement_created,note,report_mark_type) VALUES('" & SLEType.EditValue.ToString & "','" & SLEUrgency.EditValue.ToString & "',NOW(),'" & id_user & "','" & id_departement_user & "','" & addSlashes(MENote.Text.ToString) & "','" & rmt & "'); SELECT LAST_INSERT_ID(); "
                id_wo = execute_query(query, 0, True, "", "", "", "")
                '
                query = "CALL gen_number('" & id_wo & "','" & rmt & "')"
                execute_non_query(query, True, "", "", "", "")
                '
                submit_who_prepared(rmt, id_wo, id_user)
                '
                infoCustom("Work order submitted")
                load_form()
            Else 'edit
                Dim query As String = "UPDATE tb_work_order SET is_urgent='" & SLEUrgency.EditValue.ToString & "',update_date=NOW(),update_by='" & id_user & "',note='" & addSlashes(MENote.Text.ToString) & "' WHERE id_work_order='" & id_wo & "'; "
                execute_non_query(query, True, "", "", "", "")
                '
                infoCustom("Work order updated")
                load_form()
            End If
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormWorkOrderDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_wo
        FormReportMark.report_mark_type = rmt
        If is_view = "1" Then
            FormReportMark.is_view = "1"
        End If
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BUpdateUrgency_Click(sender As Object, e As EventArgs) Handles BUpdateUrgency.Click
        If Not id_wo = "-1" Then 'edit
            Dim query As String = "UPDATE tb_work_order SET is_urgent='" & SLEUrgency.EditValue.ToString & "' WHERE id_work_order='" & id_wo & "'"
            execute_query(query, -1, True, "", "", "", "")
            infoCustom("Urgency updated")
            load_form()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim query As String = "SELECT IF(wo.is_urgent = 2, 'Not Urgent', 'Urgent') AS urgent,wo.id_report_status,wot.`work_order_type`,wo.`number`,wo.`note`,DATE_FORMAT(wo.`created_date`, '%e %M %Y') AS created_date,emp.`employee_name`,dep.`departement` FROM tb_work_order wo
        INNER JOIN tb_m_user usr ON usr.`id_user`=wo.`created_by`
        INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
        INNER JOIN tb_m_departement dep ON dep.`id_departement`=wo.`id_departement_created`
        INNER jOIN tb_lookup_work_order_type wot ON wot.id_work_order_type=wo.id_work_order_type
        WHERE wo.`id_work_order`='" & id_wo & "'"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        ReportWorkOrder.id_pre = If(data.Rows(0)("id_report_status") = "6", "-1", "1")
        ReportWorkOrder.id_wo = id_wo
        ReportWorkOrder.rmt = rmt
        ReportWorkOrder.data = data

        Dim Report As New ReportWorkOrder()

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BAttachment_Click(sender As Object, e As EventArgs) Handles BAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_wo
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class