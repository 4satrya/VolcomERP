Public Class FormAccountingListPRPay 
    Public id_trans As String = "-1"
    Public id_report_status_g As String = "1"
    Public is_pr_check As String = "-1"

    Public is_payment As String = "-1"

    Dim regDate As Date = Date.Now()
    Dim strDate As String = regDate.ToString("yyyy\-MM\-dd")

    Private Sub BAddMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddMat.Click
        FormPopUpAccountMap.ShowDialog()
    End Sub

    Private Sub FormAccountingListPRPay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BMark.Visible = False
        Bprint.Visible = False
        TEUserEntry.Text = get_user_identify(id_user, 1)
        TENumber.Text = "Auto number"
        TEDate.Text = view_date_from(strDate, 0)

        If id_trans = "-1" Then 'new

        Else 'edit
            BMark.Visible = True
            Bprint.Visible = True

            'id_report_status_g = data.Rows(0)("id_report_status").ToString

            'TEUserEntry.Text = get_user_identify(data.Rows(0)("id_user").ToString, 1)

            'TENumber.Text = data.Rows(0)("acc_trans_number").ToString
            'strDate = data.Rows(0)("date_created").ToString
            'TEDate.Text = view_date_from(strDate, 0)
            'MENote.Text = data.Rows(0)("acc_trans_note").ToString
        End If
        view_det()
        show_but()
    End Sub
    Sub view_det()
        Dim query As String = "SELECT a.id_acc_trans_det,a.id_acc,b.acc_name,b.acc_description,CAST(a.debit AS DECIMAL(13,2)) as debit,CAST(a.credit AS DECIMAL(13,2)) as credit,a.acc_trans_det_note as note,a.report_number,a.report_mark_type,a.id_report,a.id_comp,m_comp.comp_name FROM tb_a_acc_trans_det a INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc LEFT JOIN tb_a_acc_trans_det d ON a.id_acc_src=d.id_acc_trans_det LEFT JOIN tb_m_comp m_comp ON m_comp.id_comp=a.id_comp WHERE a.id_acc_trans='" & id_trans & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCJournalDet.DataSource = data
        GVJournalDet.BestFitColumns()
    End Sub
    Private Sub BDelMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelMat.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this entry ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            GVJournalDet.DeleteSelectedRows()
        End If
        GVJournalDet.RefreshData()
        show_but()
    End Sub

    Sub show_but()
        If GVJournalDet.RowCount > 0 Then
            BDelMat.Visible = True
        Else
            BDelMat.Visible = False
        End If
    End Sub
End Class