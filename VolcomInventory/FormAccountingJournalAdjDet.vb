Public Class FormAccountingJournalAdjDet
    Public id_trans_adj As String = "-1"
    Public id_trans As String = "-1"
    '
    Public report_mark_type As String = ""
    Public report_number As String = ""
    Public id_report As String = "-1"
    '
    Public id_report_status_g As String = "1"
    '
    Public is_view As String = "-1"
    '
    Private Sub FormAccountingJournalAdjDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DERefDate.EditValue = Now()

        If id_trans_adj = "-1" Then 'new
            TEUserEntry.Text = get_user_identify(id_user, 1)
            TENumber.Text = "Auto number"
            Dim regDate As Date = Date.Now()
            Dim strDate As String = regDate.ToString("yyyy\-MM\-dd")
            TEDate.Text = view_date_from(strDate, 0)

            BPickJournal.Enabled = True
            Bprint.Visible = False
            BMark.Visible = False
            '
            PCButton.Visible = True
            '
            BSave.Visible = True
        Else 'edit
            Dim query As String = "SELECT a.acc_trans_adj_number,a.id_acc_trans,a.date_reffrence,DATE_FORMAT(a.date_created,'%Y-%m-%d') as date_created,a.id_user,a.acc_trans_adj_note,id_report_status FROM tb_a_acc_trans_adj a WHERE a.id_acc_trans_adj='" & id_trans_adj & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            id_trans = data.Rows(0)("id_acc_trans").ToString

            id_report_status_g = data.Rows(0)("id_report_status").ToString
            TEUserEntry.Text = get_user_identify(data.Rows(0)("id_user").ToString, 1)
            TENumber.Text = data.Rows(0)("acc_trans_adj_number").ToString

            DERefDate.EditValue = data.Rows(0)("date_reffrence")

            Dim strDate As String = data.Rows(0)("date_created").ToString
            TEDate.Text = view_date_from(strDate, 0)
            MENote.Text = data.Rows(0)("acc_trans_adj_note").ToString

            BPickJournal.Enabled = False
            allow_status()
            '

            BMark.Visible = True
            '
            PCButton.Visible = False
            '
            If id_report_status_g = "6" Then
                BViewJournal.Visible = True
                Bprint.Visible = True
            Else
                BViewJournal.Visible = False
                Bprint.Visible = False
            End If
            '
            BSave.Visible = False
        End If
        '
        view_det()
        view_reverse()
        view_draft()
        '
        but_check()
    End Sub
    Private Sub BAddMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddMat.Click
        FormPopUpCOA.id_pop_up = "3"
        FormPopUpCOA.ShowDialog()
        view_draft()
    End Sub

    Sub view_reverse()
        Dim query As String = "SELECT a.id_acc_trans_det,a.id_acc,b.acc_name,b.acc_description
,a.debit as credit,a.credit as debit
,a.acc_trans_det_note as note 
FROM tb_a_acc_trans_det a 
INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc 
WHERE a.id_acc_trans='" & id_trans & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRevJournal.DataSource = data
        '
        view_draft()
    End Sub

    Sub view_draft()
        Dim query As String = "SELECT a.id_acc_trans_det,a.id_acc,b.acc_name,b.acc_description
,a.debit as credit,a.credit as debit
,a.acc_trans_det_note as note 
FROM tb_a_acc_trans_det a 
INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc 
WHERE a.id_acc_trans='" & id_trans & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDraftJournal.DataSource = data
        'add
        For i As Integer = 0 To GVJournalDet.RowCount - 1
            Dim newRow As DataRow = (TryCast(GCDraftJournal.DataSource, DataTable)).NewRow()
            newRow("id_acc") = GVJournalDet.GetRowCellValue(i, "id_acc").ToString
            newRow("acc_name") = GVJournalDet.GetRowCellValue(i, "acc_name").ToString
            newRow("note") = GVJournalDet.GetRowCellValue(i, "note").ToString
            newRow("debit") = GVJournalDet.GetRowCellValue(i, "debit")
            newRow("credit") = GVJournalDet.GetRowCellValue(i, "credit")

            TryCast(GCDraftJournal.DataSource, DataTable).Rows.Add(newRow)
        Next
    End Sub

    Sub view_det()
        Dim query As String = "SELECT a.id_acc_trans_adj_det,a.id_acc,b.acc_name,b.acc_description
,CAST(a.debit AS DECIMAL(13,2)) as debit,CAST(a.credit AS DECIMAL(13,2)) as credit
,a.acc_trans_adj_det_note as note 
FROM tb_a_acc_trans_adj_det a 
INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc 
WHERE a.id_acc_trans_adj='" & id_trans_adj & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCJournalDet.DataSource = data
    End Sub

    Private Sub GVJournalDet_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVJournalDet.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub but_check()
        If GVJournalDet.RowCount > 0 Then
            BDelMat.Visible = True
        Else
            BDelMat.Visible = False
        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormAccountingJournalDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        'validate
        Dim dc_is_ok As Boolean = True
        '
        For i As Integer = 0 To GVDraftJournal.RowCount - 1
            If GVDraftJournal.GetRowCellValue(i, "debit") > 0 And GVDraftJournal.GetRowCellValue(i, "credit") > 0 Then
                dc_is_ok = False
            End If
        Next
        '
        ValidateChildren()
        If id_trans = "-1" Then
            stopCustom("Please choose entry to adjust.")
        ElseIf Not formIsValidInPanel(EPJournal, PCGeneralheader) Then
            stopCustom("Please check your input.")
        ElseIf GVJournalDet.Columns("debit").SummaryItem.SummaryValue = 0 And GVJournalDet.Columns("credit").SummaryItem.SummaryValue = 0 Then
            stopCustom("Please input debit/credit value.")
        ElseIf Not GVJournalDet.Columns("debit").SummaryItem.SummaryValue = GVJournalDet.Columns("credit").SummaryItem.SummaryValue Then
            stopCustom("Debit and credit must balance.")
        ElseIf Not dc_is_ok Then
            stopCustom("Please make sure only put value on debit or credit only")
        Else
            If id_trans_adj = "-1" Then
                'new
                Dim query As String = String.Format("INSERT INTO tb_a_acc_trans_adj(id_acc_trans,acc_trans_adj_number,date_created,id_user,acc_trans_adj_note,date_reffrence,id_report,report_mark_type,report_number) VALUES('{3}','{0}',NOW(),'{1}','{2}','{4}','{5}','{6}','{7}');SELECT LAST_INSERT_ID(); ", "", id_user, addSlashes(MENote.Text), id_trans, Date.Parse(DERefDate.EditValue.ToString).ToString("yyyy-MM-dd"), id_report, report_mark_type, report_number)
                id_trans_adj = execute_query(query, 0, True, "", "", "", "")

                'entry detail
                For i As Integer = 0 To GVJournalDet.RowCount - 1
                    Try
                        If Not GVJournalDet.GetRowCellValue(i, "id_acc").ToString = "" Then
                            query = String.Format("INSERT INTO tb_a_acc_trans_adj_det(id_acc_trans_adj,id_acc,debit,credit,acc_trans_adj_det_note) VALUES('{0}','{1}','{2}','{3}','{4}')", id_trans_adj, GVJournalDet.GetRowCellValue(i, "id_acc").ToString, decimalSQL(GVJournalDet.GetRowCellValue(i, "debit").ToString), decimalSQL(GVJournalDet.GetRowCellValue(i, "credit").ToString), GVJournalDet.GetRowCellValue(i, "note").ToString)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Catch ex As Exception
                    End Try
                Next

                FormAccountingJournalAdj.view_jurnal()
                FormAccountingJournalAdj.GVAccTrans.FocusedRowHandle = find_row(FormAccountingJournalAdj.GVAccTrans, "id_acc_trans_adj", id_trans_adj)

                execute_non_query("CALL gen_number(" + id_trans_adj + ",40)", True, "", "", "", "")

                'insert who prepared
                submit_who_prepared("40", id_trans_adj, id_user)
                Close()
            Else
                'edit
                Dim query As String = String.Format("UPDATE tb_a_acc_trans_adj SET acc_trans_adj_note='{0}' WHERE id_acc_trans_adj='{1}'", MENote.Text, id_trans_adj)
                execute_non_query(query, True, "", "", "", "")

                'delete first
                Dim sp_check As Boolean = False
                Dim query_del As String = "SELECT id_acc_trans_adj_det FROM tb_a_acc_trans_adj_det WHERE id_acc_trans_adj='" & id_trans_adj & "'"
                Dim data_del As DataTable = execute_query(query_del, -1, True, "", "", "", "")
                If data_del.Rows.Count > 0 Then
                    For i As Integer = 0 To data_del.Rows.Count - 1
                        sp_check = False
                        ' false mean not found, believe me
                        For j As Integer = 0 To GVJournalDet.RowCount - 1
                            If Not GVJournalDet.GetRowCellValue(j, "id_acc_trans_adj_det").ToString = "" Then
                                '
                                If GVJournalDet.GetRowCellValue(j, "id_acc_trans_adj_det").ToString = data_del.Rows(i)("id_acc_trans_adj_det").ToString() Then
                                    sp_check = True
                                End If
                            End If
                        Next
                        'end loop check on gv
                        If sp_check = False Then
                            'Because not found, it's only mean already deleted
                            query = String.Format("DELETE FROM tb_a_acc_trans_adj_det WHERE id_acc_trans_adj_det='{0}'", data_del.Rows(i)("id_acc_trans_adj_det").ToString())
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Next
                End If

                For i As Integer = 0 To GVJournalDet.RowCount - 1
                    If Not GVJournalDet.GetRowCellValue(i, "id_acc").ToString = "" Then
                        If GVJournalDet.GetRowCellValue(i, "id_acc_trans_adj_det").ToString = "" Then
                            'insert new
                            query = String.Format("INSERT INTO tb_a_acc_trans_adj_det(id_acc_trans_adj,id_acc,debit,credit,acc_trans_adj_det_note) VALUES('{0}','{1}','{2}','{3}','{4}')", id_trans_adj, GVJournalDet.GetRowCellValue(i, "id_acc").ToString, decimalSQL(GVJournalDet.GetRowCellValue(i, "debit").ToString), decimalSQL(GVJournalDet.GetRowCellValue(i, "credit").ToString), GVJournalDet.GetRowCellValue(i, "note").ToString)
                            execute_non_query(query, True, "", "", "", "")
                        Else
                            'update
                            query = String.Format("UPDATE tb_a_acc_trans_adj_det SET id_acc='{0}',debit='{1}',credit='{2}',acc_trans_adj_det_note='{3}' WHERE id_acc_trans_adj_det='{4}'", GVJournalDet.GetRowCellValue(i, "id_acc").ToString, decimalSQL(GVJournalDet.GetRowCellValue(i, "debit").ToString), decimalSQL(GVJournalDet.GetRowCellValue(i, "credit").ToString), GVJournalDet.GetRowCellValue(i, "note").ToString, GVJournalDet.GetRowCellValue(i, "id_acc_trans_adj_det").ToString)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    End If
                Next

                FormAccountingJournalAdj.view_jurnal()
                FormAccountingJournalAdj.GVAccTrans.FocusedRowHandle = find_row(FormAccountingJournalAdj.GVAccTrans, "id_acc_trans_adj", id_trans_adj)
                Close()
            End If
        End If
    End Sub

    Private Sub BDelMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelMat.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this entry ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            GVJournalDet.DeleteSelectedRows()
            view_draft()
        End If
        GVJournalDet.RefreshData()
    End Sub

    Private Sub TENumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TENumber.Validating
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_acc_trans_adj) FROM tb_a_acc_trans_adj WHERE acc_trans_adj_number='{0}' AND id_acc_trans_adj !='{1}'", TENumber.Text, id_trans_adj)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPJournal, TENumber, "1")
        Else
            EP_TE_cant_blank(EPJournal, TENumber)
        End If
    End Sub

    Private Sub GVJournalDet_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVJournalDet.PopupMenuShowing
        If GVJournalDet.RowCount > 0 Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow Then
                view.FocusedRowHandle = hitInfo.RowHandle
                BalanceMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_trans_adj
        FormReportMark.report_mark_type = "40"
        FormReportMark.is_view = is_view
        FormReportMark.ShowDialog()
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status_g, "40", id_trans_adj) Then
            BAddMat.Enabled = True
            BDelMat.Enabled = True
            GVJournalDet.OptionsBehavior.Editable = True
            BSave.Enabled = True
            MENote.Properties.ReadOnly = False
        Else
            BAddMat.Enabled = False
            BDelMat.Enabled = False
            GVJournalDet.OptionsBehavior.Editable = False
            BSave.Enabled = False
            MENote.Properties.ReadOnly = True
        End If

        If check_print_report_status(id_report_status_g) Then
            Bprint.Enabled = True
        Else
            Bprint.Enabled = False
        End If
    End Sub

    Private Sub Bprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bprint.Click
        ReportAccountingJournalAdj.id_trans_adj = id_trans_adj

        Dim Report As New ReportAccountingJournalAdj()
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub SMBalance_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMBalance.Click
        If GVJournalDet.RowCount > 0 Then
            If Not GVJournalDet.Columns("debit").SummaryItem.SummaryValue = GVJournalDet.Columns("credit").SummaryItem.SummaryValue Then
                Dim debit, credit As Decimal
                debit = GVJournalDet.Columns("debit").SummaryItem.SummaryValue
                credit = GVJournalDet.Columns("credit").SummaryItem.SummaryValue
                If debit > credit Then
                    GVJournalDet.SetRowCellValue(GVJournalDet.FocusedRowHandle, "credit", (GVJournalDet.GetFocusedRowCellValue("credit") + (debit - credit)))
                Else
                    GVJournalDet.SetRowCellValue(GVJournalDet.FocusedRowHandle, "debit", (GVJournalDet.GetFocusedRowCellValue("debit") + (credit - debit)))
                End If
            End If
        End If
    End Sub

    Private Sub BPickJournal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickJournal.Click
        FormPopUpJournal.id_acc_trans = id_trans
        FormPopUpJournal.ShowDialog()
    End Sub

    Private Sub GVRevJournal_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRevJournal.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVDraftJournal_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDraftJournal.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVJournalDet_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVJournalDet.CellValueChanged
        If e.Column.FieldName = "debit" Or e.Column.FieldName = "credit" Then
            view_draft()
        End If
    End Sub

    Private Sub BViewJournal_Click(sender As Object, e As EventArgs) Handles BViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=40 AND ad.id_report=" + id_trans_adj + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            s.id_report = id_acc_trans
            s.report_mark_type = "40"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub
End Class