Public Class FormViewJournal
    Public id_trans As String = "-1"
    Public is_enable_view_doc As Boolean = True

    Private Sub FormViewJournal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_billing_type(LEBilling)
        Dim query As String = "SELECT a.id_user,a.acc_trans_number,DATE_FORMAT(a.date_created,'%Y-%m-%d') as date_created,a.acc_trans_note,id_report_status, a.id_bill_type FROM tb_a_acc_trans a WHERE a.id_acc_trans='" & id_trans & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEUserEntry.Text = get_user_identify(data.Rows(0)("id_user").ToString, 1)
        TENumber.Text = data.Rows(0)("acc_trans_number").ToString
        Dim strDate As String = data.Rows(0)("date_created").ToString
        TEDate.Text = view_date_from(strDate, 0)
        MENote.Text = data.Rows(0)("acc_trans_note").ToString
        MENote.Enabled = False
        LEBilling.ItemIndex = LEBilling.Properties.GetDataSourceRowIndex("id_bill_type", data.Rows(0)("id_bill_type").ToString)
        view_det()

        If is_enable_view_doc Then
            GCJournalDet.ContextMenuStrip = BalanceMenu
        Else
            GCJournalDet.ContextMenuStrip = Nothing
        End If
    End Sub

    Sub load_billing_type(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_bill_type,bill_type FROM tb_lookup_bill_type WHERE is_active='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "bill_type"
        lookup.Properties.ValueMember = "id_bill_type"
        lookup.ItemIndex = 0
    End Sub

    Sub view_det()
        Dim query As String = "SELECT a.id_acc_trans_det,a.id_acc,b.acc_name,b.acc_description,CAST(a.debit AS DECIMAL(13,2)) as debit,CAST(a.credit AS DECIMAL(13,2)) as credit,a.acc_trans_det_note as note,a.report_mark_type,a.id_report FROM tb_a_acc_trans_det a INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc WHERE a.id_acc_trans='" & id_trans & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCJournalDet.DataSource = data
        GVJournalDet.BestFitColumns()
    End Sub
    Private Sub GVJournalDet_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVJournalDet.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_trans
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "36"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub FormViewJournal_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SMViewTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMViewTransaction.Click
        If Not GVJournalDet.GetFocusedRowCellValue("report_mark_type").ToString = "" And Not GVJournalDet.GetFocusedRowCellValue("id_report").ToString = "" Then
            Dim show_popup As ClassShowPopUp = New ClassShowPopUp()
            show_popup.id_report = GVJournalDet.GetFocusedRowCellValue("id_report").ToString
            show_popup.report_mark_type = GVJournalDet.GetFocusedRowCellValue("report_mark_type").ToString
            show_popup.is_payment = "1"
            show_popup.show()
        End If
    End Sub

    Private Sub GVJournalDet_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVJournalDet.PopupMenuShowing
        If GVJournalDet.RowCount > 0 Then
            If GVJournalDet.IsGroupRow(GVJournalDet.FocusedRowHandle) Or GVJournalDet.GetFocusedRowCellValue("id_report").ToString = "" Or GVJournalDet.GetFocusedRowCellValue("report_mark_type").ToString = "" Then
                SMViewTransaction.Enabled = False
            Else
                SMViewTransaction.Enabled = True
            End If
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow Then
                view.FocusedRowHandle = hitInfo.RowHandle
                BalanceMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub
End Class