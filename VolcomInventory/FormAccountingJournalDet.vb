Public Class FormAccountingJournalDet
    Public id_trans As String = "-1"
    Public id_report_status_g As String = "1"
    Public is_pr_check As String = "-1"

    Public is_payment As String = "-1"

    Private Sub FormAccountingJournalDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_status()
        BMark.Visible = False
        Bprint.Visible = False
        TEUserEntry.Text = get_user_identify(id_user, 1)
        TENumber.Text = "Auto number"
        Dim regDate As Date = Date.Now()
        Dim strDate As String = regDate.ToString("yyyy\-MM\-dd")
        TEDate.Text = view_date_from(strDate, 0)

        If is_pr_check = "1" Then
            'post from PR

        Else
            If id_trans = "-1" Then 'new

            Else 'edit
                BMark.Visible = True
                Bprint.Visible = True
                Dim query As String = "SELECT a.acc_trans_number,DATE_FORMAT(a.date_created,'%Y-%m-%d') as date_created,a.id_user,a.acc_trans_note,id_report_status FROM tb_a_acc_trans a WHERE a.id_acc_trans='" & id_trans & "'"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                id_report_status_g = data.Rows(0)("id_report_status").ToString

                TEUserEntry.Text = get_user_identify(data.Rows(0)("id_user").ToString, 1)

                TENumber.Text = data.Rows(0)("acc_trans_number").ToString
                strDate = data.Rows(0)("date_created").ToString
                TEDate.Text = view_date_from(strDate, 0)
                MENote.Text = data.Rows(0)("acc_trans_note").ToString
            End If
            view_det()
            allow_status()
        End If
        
        but_check()
    End Sub

    Private Sub BAddMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddMat.Click
        FormPopUpCOA.id_pop_up = "1"
        FormPopUpCOA.ShowDialog()
    End Sub

    Sub view_det()
        Dim query As String = "SELECT a.id_acc_trans_det,a.id_acc,b.acc_name,b.acc_description,CAST(a.debit AS DECIMAL(13,2)) as debit,CAST(a.credit AS DECIMAL(13,2)) as credit,a.acc_trans_det_note as note,a.id_status_open,a.id_acc_src FROM tb_a_acc_trans_det a INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc LEFT JOIN tb_a_acc_trans_det d ON a.id_acc_src=d.id_acc_trans_det WHERE a.id_acc_trans='" & id_trans & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCJournalDet.DataSource = data
    End Sub

    Sub view_status()
        Dim query As String = "SELECT id_status_open,status_open FROM tb_lookup_status_open"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RSLEStatusOpen.DataSource = data
        RSLEStatusOpen.DisplayMember = "status_open"
        RSLEStatusOpen.ValueMember = "id_status_open"
        RSLEStatusOpen.PopulateViewColumns()
        RSLEStatusOpen.NullText = ""
        RSLEStatusOpen.View.Columns("id_status_open").Visible = False
        RSLEStatusOpen.View.Columns("status_open").Caption = "Status"

        If data.Rows.Count > 0 Then
            RSLEStatusOpen.View.FocusedRowHandle = 0
        End If
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
        'validates
        ValidateChildren()
        If Not formIsValidInPanel(EPJournal, PCGeneralheader) Then
            stopCustom("Please check your input.")
        ElseIf GVJournalDet.Columns("debit").SummaryItem.SummaryValue = 0 And GVJournalDet.Columns("credit").SummaryItem.SummaryValue = 0 Then
            stopCustom("Please input debit/credit value.")
        ElseIf Not GVJournalDet.Columns("debit").SummaryItem.SummaryValue = GVJournalDet.Columns("credit").SummaryItem.SummaryValue Then
            stopCustom("Debit and credit must balance.")
        Else
            If id_trans = "-1" Then
                'new
                Dim query As String = String.Format("INSERT INTO tb_a_acc_trans(acc_trans_number,date_created,id_user,acc_trans_note) VALUES('{0}',NOW(),'{1}','{2}');SELECT LAST_INSERT_ID(); ", "", id_user, MENote.Text)

                id_trans = execute_query(query, 0, True, "", "", "", "")

                execute_non_query("CALL gen_number(" + id_trans + ",36)", True, "", "", "", "")
                'insert who prepared
                insert_who_prepared("36", id_trans, id_user)

                'entry detail
                For i As Integer = 0 To GVJournalDet.RowCount - 1
                    Try
                        If Not GVJournalDet.GetRowCellValue(i, "id_acc").ToString = "" Then
                            query = String.Format("INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,id_status_open) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id_trans, GVJournalDet.GetRowCellValue(i, "id_acc").ToString, decimalSQL(GVJournalDet.GetRowCellValue(i, "debit").ToString), decimalSQL(GVJournalDet.GetRowCellValue(i, "credit").ToString), GVJournalDet.GetRowCellValue(i, "note").ToString, GVJournalDet.GetRowCellValue(i, "id_status_open").ToString)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Catch ex As Exception
                    End Try

                    infoCustom("Journal saved.")
                    'FormAccountingJournal.view_jurnal()
                    ' FormAccountingJournal.GVAccTrans.FocusedRowHandle = find_row(FormAccountingJournal.GVAccTrans, "id_acc_trans", id_trans)
                    Close()
                Next
            Else
                'edit
                Dim query As String = String.Format("UPDATE tb_a_acc_trans SET acc_trans_note='{0}' WHERE id_acc_trans='{1}'", MENote.Text, id_trans)
                execute_non_query(query, True, "", "", "", "")

                'delete first
                Dim sp_check As Boolean = False
                Dim query_del As String = "SELECT id_acc_trans_det FROM tb_a_acc_trans_det WHERE id_acc_trans='" & id_trans & "'"
                Dim data_del As DataTable = execute_query(query_del, -1, True, "", "", "", "")
                If data_del.Rows.Count > 0 Then
                    For i As Integer = 0 To data_del.Rows.Count - 1
                        sp_check = False
                        ' false mean not found, believe me
                        For j As Integer = 0 To GVJournalDet.RowCount - 1
                            If Not GVJournalDet.GetRowCellValue(j, "id_acc_trans_det").ToString = "" Then
                                '
                                If GVJournalDet.GetRowCellValue(j, "id_acc_trans_det").ToString = data_del.Rows(i)("id_acc_trans_det").ToString() Then
                                    sp_check = True
                                End If
                            End If
                        Next
                        'end loop check on gv
                        If sp_check = False Then
                            'Because not found, it's only mean already deleted
                            query = String.Format("DELETE FROM tb_a_acc_trans_det WHERE id_acc_trans_det='{0}'", data_del.Rows(i)("id_acc_trans_det").ToString())
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Next
                End If

                For i As Integer = 0 To GVJournalDet.RowCount - 1
                    If Not GVJournalDet.GetRowCellValue(i, "id_acc").ToString = "" Then
                        If GVJournalDet.GetRowCellValue(i, "id_acc_trans_det").ToString = "" Then
                            'insert new
                            query = String.Format("INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,id_status_open) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id_trans, GVJournalDet.GetRowCellValue(i, "id_acc").ToString, decimalSQL(GVJournalDet.GetRowCellValue(i, "debit").ToString), decimalSQL(GVJournalDet.GetRowCellValue(i, "credit").ToString), GVJournalDet.GetRowCellValue(i, "note").ToString, GVJournalDet.GetRowCellValue(i, "id_status_open").ToString)
                            execute_non_query(query, True, "", "", "", "")
                        Else
                            'update
                            query = String.Format("UPDATE tb_a_acc_trans_det SET id_acc='{0}',debit='{1}',credit='{2}',acc_trans_det_note='{3}',id_status_open='{5}' WHERE id_acc_trans_det='{4}'", GVJournalDet.GetRowCellValue(i, "id_acc").ToString, decimalSQL(GVJournalDet.GetRowCellValue(i, "debit").ToString), decimalSQL(GVJournalDet.GetRowCellValue(i, "credit").ToString), GVJournalDet.GetRowCellValue(i, "note").ToString, GVJournalDet.GetRowCellValue(i, "id_acc_trans_det").ToString, GVJournalDet.GetRowCellValue(i, "id_status_open").ToString)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    End If
                Next

                infoCustom("Journal updated.")
                'FormAccountingJournal.view_jurnal()
                'FormAccountingJournal.GVAccTrans.FocusedRowHandle = find_row(FormAccountingJournal.GVAccTrans, "id_acc_trans", id_trans)
                Close()
            End If
        End If
    End Sub

    Private Sub BDelMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelMat.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this entry ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            GVJournalDet.DeleteSelectedRows()
        End If
        GVJournalDet.RefreshData()
        but_check()
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
        FormReportMark.id_report = id_trans
        FormReportMark.report_mark_type = "36"
        FormReportMark.ShowDialog()
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status_g, "36", id_trans) Then
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
        ReportAccountingJournal.id_trans = id_trans

        Dim Report As New ReportAccountingJournal()
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
End Class