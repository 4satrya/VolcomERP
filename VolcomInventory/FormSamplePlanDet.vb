Public Class FormSamplePlanDet
    Public id_sample_plan As String = "-1"
    Public id_comp_contact_to As String = "-1"
    Private Sub FormSamplePlanDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSeasonOrign(LESeason)
        view_report_status(LEReportStatus)

        If id_sample_plan = "-1" Then
            'new
            TEPONumber.Text = header_number("10")
            TEDate.Text = view_date(0)
            check_gv_but()
            BSave.Enabled = True
            'fill ds
            Dim query As String = "CALL view_plan_sample_det(-1)"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCListPurchase.DataSource = data
        Else
            'edit
            Dim query As String = "SELECT a.id_sample_plan,a.sample_plan_number,a.sample_plan_note,a.id_comp_contact_to,d.comp_name AS comp_name_to,a.id_season_orign,b.season_orign,a.sample_plan_date,DATE_FORMAT(a.sample_plan_date,'%d/%m/%y') AS date_view,a.id_report_status,e.report_status "
            query += "FROM tb_sample_plan a INNER JOIN tb_season_orign b ON a.id_season_orign=b.id_season_orign "
            query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=a.id_comp_contact_to "
            query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
            query += "INNER JOIN tb_lookup_report_status e ON e.id_report_status = a.id_report_status "
            query += "WHERE a.id_sample_plan='" & id_sample_plan & "'"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TEPONumber.Text = data.Rows(0)("sample_plan_number").ToString
            MENote.Text = data.Rows(0)("sample_plan_note").ToString
            LESeason.EditValue = data.Rows(0)("id_season_orign").ToString
            id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
            TEDate.Text = data.Rows(0)("date_view").ToString
            TECompName.Text = get_company_x(get_id_company(id_comp_contact_to), "1")
            TECompCode.Text = get_company_x(get_id_company(id_comp_contact_to), "2")
            MECompAddress.Text = get_company_x(get_id_company(id_comp_contact_to), "3")
            TECompAttn.Text = get_company_contact_x(id_comp_contact_to, "1")

            LEReportStatus.EditValue = Nothing
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            view_list_purchase()

            BSave.Enabled = True
            allow_status()
        End If
    End Sub
    Sub view_list_purchase()
        Dim query = "CALL view_plan_sample_det('" & id_sample_plan & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        If data.Rows.Count > 0 Then
            BAdd.Enabled = True
            Bdel.Enabled = True
            BEdit.Enabled = True
        Else
            BAdd.Enabled = True
            Bdel.Enabled = False
            BEdit.Enabled = False
        End If
    End Sub
    Sub check_gv_but()
        If GVListPurchase.RowCount > 0 Then
            BEdit.Enabled = True
            Bdel.Enabled = True
        Else
            BEdit.Enabled = False
            Bdel.Enabled = False
        End If
    End Sub

    Private Sub BSearchCompTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSearchCompTo.Click
        FormPopUpContact.id_pop_up = "13"
        FormPopUpContact.id_cat = get_setup_field("id_comp_cat_vendor")
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdd.Click
        FormPopUpSample.id_pop_up = "1"
        FormPopUpSample.ShowDialog()
    End Sub

    Private Sub viewSeasonOrign(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_season_orign,season_orign FROM tb_season_orign ORDER BY id_season_orign DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "season_orign"
        lookup.Properties.ValueMember = "id_season_orign"
        lookup.EditValue = data.Rows(0)("id_season_orign").ToString
    End Sub
    Private Sub view_report_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "report_status"
        lookup.Properties.ValueMember = "id_report_status"
        lookup.ItemIndex = 0
    End Sub

    Private Sub BEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEdit.Click
        If id_sample_plan = "-1" Then
            FormPopUpSample.id_pop_up = "1"
            FormPopUpSample.id_sample = GVListPurchase.GetFocusedRowCellDisplayText("id_sample").ToString
            FormPopUpSample.ShowDialog()
        Else
            FormPopUpSample.id_pop_up = "1"
            FormPopUpSample.id_sample = GVListPurchase.GetFocusedRowCellDisplayText("id_sample").ToString

            FormPopUpSample.ShowDialog()
        End If
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub Bdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bdel.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this sample on list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                GVListPurchase.DeleteSelectedRows()
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("This list item can't be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim query, sp_number, sp_note, sp_season, id_sp_new As String

        Dim valid As Boolean = True

        sp_number = TEPONumber.Text
        sp_note = MENote.Text
        sp_season = LESeason.EditValue

        If GVListPurchase.RowCount < 1 Or id_comp_contact_to = "-1" Then
            valid = False
        End If

        If formIsValidInGroup(EPSamplePurc, GroupGeneralHeader) And valid = True Then
            If id_sample_plan = "-1" Then
                'new
                Try
                    'insert sp
                    query = String.Format("INSERT INTO tb_sample_plan(sample_plan_number,sample_plan_note,id_season_orign,id_comp_contact_to,sample_plan_date) VALUES('{0}','{1}','{2}','{3}',DATE(NOW()));SELECT LAST_INSERT_ID()", sp_number, sp_note, sp_season, id_comp_contact_to)
                    id_sp_new = execute_query(query, 0, True, "", "", "", "")
                    'insert who prepared
                    insert_who_prepared("12", id_sp_new, id_user)

                    increase_inc("10")
                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        If Not GVListPurchase.GetRowCellValue(i, "id_sample").ToString = "" Then
                            'dp
                            query = String.Format("INSERT INTO tb_sample_plan_det(id_sample_plan,id_sample,sample_plan_det_qty,sample_plan_det_note) VALUES('{0}','{1}','{2}','{3}')", id_sp_new, GVListPurchase.GetRowCellValue(i, "id_sample").ToString, GVListPurchase.GetRowCellValue(i, "qty").ToString, GVListPurchase.GetRowCellValue(i, "sample_plan_det_note").ToString)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Next
                    FormSamplePlan.view_sample_plan()
                    FormSamplePlan.GVSamplePrePO.FocusedRowHandle = find_row(FormSamplePlan.GVSamplePrePO, "id_sample_plan", id_sp_new)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            Else
                'edit
                Try
                    query = String.Format("UPDATE tb_sample_plan SET sample_plan_number='{0}',sample_plan_note='{1}',id_season_orign='{2}',id_comp_contact_to='{3}' WHERE id_sample_plan='{4}'", sp_number, sp_note, sp_season, id_comp_contact_to, id_sample_plan)
                    execute_non_query(query, True, "", "", "", "")
                    'delete first
                    Dim sp_check As Boolean = False
                    Dim query_del As String = "SELECT id_sample_plan_det FROM tb_sample_plan_det WHERE id_sample_plan='" & id_sample_plan & "'"
                    Dim data_del As DataTable = execute_query(query_del, -1, True, "", "", "", "")
                    If data_del.Rows.Count > 0 Then
                        For i As Integer = 0 To data_del.Rows.Count - 1
                            sp_check = False
                            ' false mean not found, believe me
                            For j As Integer = 0 To GVListPurchase.RowCount - 1
                                If Not GVListPurchase.GetRowCellValue(j, "id_sample_plan_det").ToString = "" Then
                                    '
                                    If GVListPurchase.GetRowCellValue(j, "id_sample_plan_det").ToString = data_del.Rows(i)("id_sample_plan_det").ToString() Then
                                        sp_check = True
                                    End If
                                End If
                            Next
                            'end loop check on gv
                            If sp_check = False Then
                                'Because not found, it's only mean already deleted
                                query = String.Format("DELETE FROM tb_sample_plan_det WHERE id_sample_plan_det='{0}'", data_del.Rows(i)("id_sample_plan_det").ToString())
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Next
                    End If

                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        If Not GVListPurchase.GetRowCellValue(i, "id_sample").ToString = "" Then
                            If GVListPurchase.GetRowCellValue(i, "id_sample_plan_det").ToString = "" Then
                                'insert new
                                query = String.Format("INSERT INTO tb_sample_plan_det(id_sample_plan,id_sample,sample_plan_det_qty,sample_plan_det_note) VALUES('{0}','{1}','{2}','{3}')", id_sample_plan, GVListPurchase.GetRowCellValue(i, "id_sample").ToString, GVListPurchase.GetRowCellValue(i, "qty").ToString, GVListPurchase.GetRowCellValue(i, "sample_plan_det_note").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            Else
                                'update
                                query = String.Format("UPDATE tb_sample_plan_det SET id_sample='{0}',sample_plan_det_qty='{1}',sample_plan_det_note='{2}' WHERE id_sample_plan_det='{3}'", GVListPurchase.GetRowCellValue(i, "id_sample").ToString, GVListPurchase.GetRowCellValue(i, "qty").ToString, GVListPurchase.GetRowCellValue(i, "sample_plan_det_note").ToString, GVListPurchase.GetRowCellValue(i, "id_sample_plan_det").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        End If
                    Next
                    FormSamplePlan.view_sample_plan()
                    FormSamplePlan.GVSamplePrePO.FocusedRowHandle = find_row(FormSamplePlan.GVSamplePrePO, "id_sample_plan", id_sample_plan)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        Else
            errorInput()
        End If
    End Sub

    Private Sub TEPONumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPONumber.Validating
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_sample_plan) FROM tb_sample_plan WHERE sample_plan_number='{0}' AND id_sample_plan!='{1}'", TEPONumber.Text, id_sample_plan)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPSamplePurc, TEPONumber, "1")
        Else
            EP_TE_cant_blank(EPSamplePurc, TEPONumber)
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(LEReportStatus.EditValue, "12", id_sample_plan) Then
            BAdd.Enabled = True
            BEdit.Enabled = True
            Bdel.Enabled = True
            BSave.Enabled = True
            '
            'BImport.Enabled = True
            BSearchCompTo.Enabled = True
        Else
            BAdd.Enabled = False
            BEdit.Enabled = False
            Bdel.Enabled = False
            BSave.Enabled = False
            '
            'BImport.Enabled = False
            BSearchCompTo.Enabled = False
        End If

        If check_print_report_status(LEReportStatus.EditValue) Then
            BPrint.Enabled = True
        Else
            BPrint.Enabled = False
        End If
    End Sub

    Private Sub FormSamplePlanDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_sample_plan
        FormReportMark.report_mark_type = "12"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        ReportSamplePlan.id_sample_plan = id_sample_plan

        Dim Report As New ReportSamplePlan()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImport.Click
        FormImportExcel.id_pop_up = "2"
        FormImportExcel.ShowDialog()
    End Sub
End Class