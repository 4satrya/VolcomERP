Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportAccountingJournal
    Public Shared id_trans As String = "-1"
    Public Shared is_pre As String = "-1"
    Sub view_trans()
        Dim query As String = "SELECT a.id_acc_trans_det,a.id_acc,b.acc_name,b.acc_description,CAST(a.debit AS DECIMAL(13,2)) as debit,CAST(a.credit AS DECIMAL(13,2)) as credit,a.acc_trans_det_note as note,c.comp_number FROM tb_a_acc_trans_det a INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc INNER JOIN tb_m_comp c ON c.id_comp=a.id_comp WHERE a.id_acc_trans='" & id_trans & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCJournalDet.DataSource = data
    End Sub

    Private Sub GVJournalDet_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVJournalDet.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        view_trans()
    End Sub

    Private Sub ReportAccountingJournal_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        If is_pre = "1" Then
            pre_load_mark_horz("36", id_trans, "2", "2", XrTable1)
        Else
            load_mark_horz("36", id_trans, "2", "1", XrTable1)
        End If
    End Sub

    Private Sub TopMargin_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles TopMargin.BeforePrint
        Dim query As String = "SELECT a.id_user,a.acc_trans_number,DATE_FORMAT(a.date_created,'%Y-%m-%d') as date_created,a.acc_trans_note,id_report_status,bt.bill_type FROM tb_a_acc_trans a INNER JOIN tb_lookup_bill_type bt ON bt.id_bilL_type=a.id_bill_type WHERE a.id_acc_trans='" & id_trans & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        LNumber.Text = data.Rows(0)("acc_trans_number").ToString
        LUserEntry.Text = get_user_identify(data.Rows(0)("id_user").ToString, 1)
        LVoucherType.Text = data.Rows(0)("bill_type").ToString
        Dim strDate As String = data.Rows(0)("date_created").ToString
        LDate.Text = view_date_from(strDate, 0)
        LNote.Text = data.Rows(0)("acc_trans_note").ToString
    End Sub
End Class