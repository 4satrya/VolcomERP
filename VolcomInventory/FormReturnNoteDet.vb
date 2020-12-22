Public Class FormReturnNoteDet
    Public id_return_note As String = "-1"
    Dim id_inbound_awb As String = "-1"

    Private Sub FormReturnNoteDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_store()
        Dim q As String = "SELECT id_comp
FROM `tb_return_note_store`
WHERE id_return_note='" & id_return_note & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCStore.DataSource = dt
        GVStore.BestFitColumns()
        check_but()
    End Sub

    Sub load_store_from_awb()
        Dim q As String = "SELECT id_comp
FROM `tb_inbound_store`
WHERE id_inbound_awb='" & id_inbound_awb & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCStore.DataSource = dt
        GVStore.BestFitColumns()
        check_but()
    End Sub

    Sub empty_store()
        For i = GVStore.RowCount - 1 To 0 Step -1
            GVStore.DeleteRow(i)
        Next
    End Sub

    Private Sub BDelStore_Click_1(sender As Object, e As EventArgs) Handles BDelStore.Click
        If GVStore.RowCount > 0 Then
            GVStore.DeleteSelectedRows()
            check_but()
        End If
    End Sub

    Private Sub BAddStore_Click_1(sender As Object, e As EventArgs) Handles BAddStore.Click
        GVStore.AddNewRow()
        GVStore.SetRowCellValue(GVStore.RowCount - 1, "id_comp", 388)
        GVStore.RefreshData()
        check_but()
    End Sub

    Sub load_repo_store()
        Dim q As String = "SELECT id_comp,comp_number,CONCAT(comp_number, ' - ',comp_name) AS comp_name
FROM tb_m_comp 
WHERE id_comp_cat='6' AND is_active='1'"
        viewSearchLookupRepositoryQuery(RISLECompany, q, 1, "comp_name", "id_comp")
    End Sub

    Private Sub FormReturnNoteDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_Form()
    End Sub

    Sub load_Form()
        TEReturnNoteNumber.Text = ""
        DEReturnNote.EditValue = Now
        '
        load_emp()
        load_type()
        load_store()
        load_repo_store()
        '
        If Not id_return_note = "-1" Then
            Dim q As String = "SELECT rn.is_lock,rn.id_type,awb.awb_number,rn.id_emp_driver,rn.id_inbound_awb,rn.label_number,rn.date_created,rn.number_return_note,rn.qty,rn.date_return_note
FROM `tb_return_note` rn
LEFT JOIN tb_inbound_awb awb ON rn.id_inbound_awb=awb.id_inbound_awb
WHERE rn.id_return_note='" & id_return_note & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                SLEType.EditValue = dt.Rows(0)("id_type").ToString
                '
                If dt.Rows(0)("id_type").ToString = "2" Then
                    id_inbound_awb = dt.Rows(0)("id_inbound_awb").ToString
                End If
                SLEEmp.EditValue = dt.Rows(0)("id_emp_driver").ToString
                TEAWB.Text = dt.Rows(0)("awb_number").ToString
                load_store()
                '
                TEReturnNoteNumber.Text = dt.Rows(0)("number_return_note").ToString
                DEReturnNote.EditValue = dt.Rows(0)("date_return_note")
                TEQtyReturnNote.EditValue = dt.Rows(0)("qty")
                TELabelNumber.Text = dt.Rows(0)("label_number").ToString
                '
                If dt.Rows(0)("is_lock").ToString = "1" Then
                    BPrint.Visible = True
                    BSaveAndPrint.Visible = False
                Else
                    BPrint.Visible = False
                    BSaveAndPrint.Visible = True
                End If
            End If
        End If
    End Sub

    Sub load_type()
        Dim q As String = "SELECT '1' AS id_type,'WH INBOUND DELIVERY' AS type UNION ALL SELECT '2' AS id_type,'3PL OFFLINE' AS type"
        viewSearchLookupQuery(SLEType, q, "id_type", "type", "id_type")
    End Sub

    Sub load_emp()
        Dim q As String = "SELECT id_employee,employee_code,employee_name FROM tb_m_employee WHERE id_employee_active='1' AND id_departement='6'"
        viewSearchLookupQuery(SLEEmp, q, "id_employee", "employee_name", "id_employee")
    End Sub

    Sub check_but()
        If SLEType.EditValue.ToString = "1" Then 'lokal
            PCReturnStaff.Visible = True
            PCButton.Visible = True
            PCAWB.Visible = False
        Else
            PCReturnStaff.Visible = False
            PCButton.Visible = False
            PCAWB.Visible = True
        End If
        '
        If GVStore.RowCount > 0 Then
            BDelStore.Visible = True
        Else
            BDelStore.Visible = False
        End If
        '
        If id_return_note = "-1" Then
            BNextReturnNote.Visible = False
        Else
            BNextReturnNote.Visible = True
        End If
    End Sub

    Sub check_but_type()
        If SLEType.EditValue.ToString = "1" Then
            'wh inbound
            empty_store()
            PCReturnStaff.Visible = True
            PCAWB.Visible = False
            PCButton.Visible = True
            id_inbound_awb = "-1"
            '
            GVStore.OptionsBehavior.ReadOnly = False
            GVStore.OptionsBehavior.Editable = True
        Else
            '3pl offline
            empty_store()
            PCReturnStaff.Visible = False
            PCAWB.Visible = True
            PCButton.Visible = False
            '
            GVStore.OptionsBehavior.ReadOnly = True
            GVStore.OptionsBehavior.Editable = False
        End If
    End Sub

    Private Sub BResetAWB_Click(sender As Object, e As EventArgs) Handles BResetAWB.Click
        TEAWB.Enabled = True
        TEAWB.Text = ""
        id_inbound_awb = "-1"
        check_but_type()
        check_but()
    End Sub

    Private Sub TEAWB_KeyDown(sender As Object, e As KeyEventArgs) Handles TEAWB.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TEAWB.Text = "" Then
                warningCustom("Please scan AWB")
            Else
                Dim is_ok As Boolean = False
                'check
                Dim qc As String = "SELECT id_inbound_awb FROM tb_inbound_awb WHERE awb_number='" & addSlashes(TEAWB.Text) & "'"
                Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                If dtc.Rows.Count <= 0 Then
                    warningCustom("AWB not found")
                Else
                    id_inbound_awb = dtc.Rows(0)("id_inbound_awb").ToString
                    TEAWB.Enabled = False
                    load_store_from_awb()
                    check_but()
                End If
            End If
        End If
    End Sub

    Private Sub SLEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEType.EditValueChanged
        check_but_type()
        check_but()
    End Sub

    Private Sub BSaveAndPrint_Click(sender As Object, e As EventArgs) Handles BSaveAndPrint.Click
        Dim q As String = ""
        '
        GVStore.ActiveFilterString = "Not IsNullOrEmpty([id_comp])"
        '
        If GVStore.RowCount = 0 Then
            warningCustom("Please input store first")
        ElseIf TEQtyReturnNote.EditValue = 0 Or TEReturnNoteNumber.Text = "" Then
            warningCustom("Please fill return note detail")
        ElseIf SLEType.EditValue.ToString = "2" And id_inbound_awb = "-1" Then
            warningCustom("Please scan awb first")
        Else
            If id_return_note = "-1" Then
                'new
                q = "INSERT INTO tb_return_note(`id_type`,`id_emp_driver`,`id_inbound_awb`,`date_created`,`number_return_note`,`qty`,`date_return_note`,`created_by`
) VALUES('" & SLEType.EditValue.ToString & "','" & If(SLEType.EditValue.ToString = "1", SLEEmp.EditValue.ToString, "0") & "','" & id_inbound_awb & "',NOW(),'" & addSlashes(TEReturnNoteNumber.Text) & "','" & TEQtyReturnNote.EditValue.ToString & "','" & Date.Parse(DEReturnNote.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & id_user & "'); SELECT LAST_INSERT_ID();"
                id_return_note = execute_query(q, 0, True, "", "", "", "")
                '
                q = "CALL gen_label_return_note('" & id_return_note & "')"
                execute_non_query(q, True, "", "", "", "")
                'store
                q = "DELETE FROM tb_return_note_store WHERE id_return_note='" & id_return_note & "'"
                execute_non_query(q, True, "", "", "", "")
                q = "INSERT INTO tb_return_note_store(id_return_note,id_comp) VALUES"
                For i As Integer = 0 To GVStore.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id_return_note & "','" & GVStore.GetRowCellValue(i, "id_comp").ToString & "')"
                Next
                execute_non_query(q, True, "", "", "", "")
                'print
                print()
                infoCustom("Return label saved.")
            Else
                'update
                q = "UPDATE tb_return_note SET `id_type`='" & SLEType.EditValue.ToString & "',`id_emp_driver`='" & If(SLEType.EditValue.ToString = "1", SLEEmp.EditValue.ToString, "0") & "',`id_inbound_awb`='" & id_inbound_awb & "',`number_return_note`='" & addSlashes(TEReturnNoteNumber.Text) & "',`qty`='" & TEQtyReturnNote.EditValue.ToString & "',`date_return_note`='" & Date.Parse(DEReturnNote.EditValue.ToString).ToString("yyyy-MM-dd") & "',update_by='" & id_user & "',update_date=NOW() WHERE id_return_note='" & id_return_note & "'"
                execute_non_query(q, True, "", "", "", "")
                'store
                q = "DELETE FROM tb_return_note_store WHERE id_return_note='" & id_return_note & "'"
                execute_non_query(q, True, "", "", "", "")
                q = "INSERT INTO tb_return_note_store(id_return_note,id_comp) VALUES"
                For i As Integer = 0 To GVStore.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id_return_note & "','" & GVStore.GetRowCellValue(i, "id_comp").ToString & "')"
                Next
                execute_non_query(q, True, "", "", "", "")
                'print
                print()
                infoCustom("Return label updated.")
            End If
        End If
        check_but()
        GVStore.ActiveFilterString = ""
    End Sub

    Sub print()
        Cursor = Cursors.WaitCursor

        Dim q As String = "SELECT DATE_FORMAT(rn.date_created,'%d %M %Y') AS date_created,GROUP_CONCAT(DISTINCT(CONCAT(cst.`comp_number`,' - ',cst.comp_name)) ORDER BY cst.`comp_number` SEPARATOR '\n') AS store_list,emp.employee_name,rn.label_number,rn.number_return_note,FORMAT(rn.qty, 0, 'id_ID') AS qty,DATE_FORMAT(rn.date_return_note,'%d %M %Y') AS date_return_note,DATE_FORMAT(NOW(),'%d %M %Y %H:%i') as printed_date 
FROM tb_return_note rn
INNER JOIN tb_m_user usr ON usr.id_user='" & id_user & "'
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_return_note_store st ON st.id_return_note=rn.id_return_note
INNER JOIN tb_m_comp cst ON cst.id_comp=st.id_comp
WHERE rn.id_return_note='" & id_return_note & "'
GROUP BY rn.id_return_note"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

        ReportReturnNote.dt = dt
        Dim Report As New ReportReturnNote()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BReset_Click(sender As Object, e As EventArgs) Handles BReset.Click
        check_but_type()
    End Sub

    Private Sub BNextReturnNote_Click(sender As Object, e As EventArgs) Handles BNextReturnNote.Click
        TELabelNumber.Text = "[Auto Generate]"
        TEReturnNoteNumber.Text = ""
        DEReturnNote.EditValue = Now
        TEQtyReturnNote.EditValue = 0
        id_return_note = "-1"
        check_but()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        'print
        print()
    End Sub
End Class