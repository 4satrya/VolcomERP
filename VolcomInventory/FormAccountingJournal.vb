Public Class FormAccountingJournal
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormAccountingJournal_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormAccountingJournal_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormAccountingJournal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dispose()
    End Sub
    Sub check_but()
        If XTCJurnal.SelectedTabPageIndex = 0 Then
            If GVAccTrans.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0" 'you will never delete journal, use adjustment.
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        Else
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
        End If
        
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormAccountingJournal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_unit()
        load_billing_type(LEBilling)
        load_billing_type(LEBillingView)
        check_but()
    End Sub

    Sub load_unit()
        Dim query As String = "SELECT 0 AS id_coa_tag,'ALL' AS tag_code,'ALL' AS tag_description 
UNION ALL
SELECT id_coa_tag,tag_code,tag_description FROM `tb_coa_tag`"
        '        query = "SELECT '0' AS id_comp,'-' AS comp_number, 'All Unit' AS comp_name
        'UNION ALL
        'SELECT ad.`id_comp`,c.`comp_number`,c.`comp_name` FROM `tb_a_acc_trans_det` ad
        'INNER JOIN tb_m_comp c ON c.`id_comp`=ad.`id_comp`
        'GROUP BY ad.id_comp"
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
        SLEUnit.EditValue = "1"
    End Sub

    Sub view_det(ByVal start_date As String, ByVal end_date As String, ByVal opt As String)

        Dim query As String = "SELECT c.id_acc_trans,c.acc_trans_number,c.date_created,a.id_acc_trans_det,a.id_acc,b.acc_name,b.acc_description
,a.debit,a.credit,a.acc_trans_det_note AS note 
,comp.comp_number,a.`report_mark_type`,a.`id_report`,a.`report_number`,a.`report_mark_type_ref`,a.`id_report_ref`,a.`report_number_ref`
FROM tb_a_acc_trans_det a 
INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc 
INNER JOIN tb_a_acc_trans c ON c.id_acc_trans=a.id_acc_trans 
LEFT JOIN tb_m_comp comp ON comp.id_comp=a.id_comp"

        If opt = "1" Then
            query += " WHERE (DATE(c.date_created) <= '" & end_date & "') AND (DATE(c.date_created) >= '" & start_date & "')"
        ElseIf opt = "2" Then
            query += " WHERE (DATE(c.date_reference) <= '" & end_date & "') AND (DATE(c.date_reference) >= '" & start_date & "')"
        End If

        If Not LEBillingView.EditValue.ToString = "ALL" Then
            query += " AND c.id_bill_type='" & LEBillingView.EditValue.ToString & "'"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCJournalDet.DataSource = data
        GVJournalDet.ExpandAllGroups()
    End Sub

    Private Sub BView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BView.Click
        Dim fromdate As String = ""
        Dim enddate As String = ""

        If DEFrom.Text = "" Then
            DEFrom.DateTime = Now
            fromdate = Now.ToString("yyy-MM-dd")
        Else
            fromdate = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyy-MM-dd")
        End If

        If DETo.Text = "" Then
            DETo.DateTime = Now
            enddate = Now.ToString("yyy-MM-dd")
        Else
            enddate = DateTime.Parse(DETo.EditValue.ToString).ToString("yyy-MM-dd")
        End If

        If LEBillingView.Text = "" Then
            warningCustom("Please choose type first")
        Else
            view_det(fromdate, enddate, "1")
        End If
    End Sub

    Private Sub XTCJurnal_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCJurnal.SelectedPageChanged
        check_but()
    End Sub

    Sub view_entry()
        Dim id_type As String = LEBilling.EditValue.ToString
        Dim fromdate As String = ""
        Dim enddate As String = ""

        If DEFromViewJournal.Text = "" Then
            DEFromViewJournal.DateTime = Now
            fromdate = Now.ToString("yyy-MM-dd")
        Else
            fromdate = DateTime.Parse(DEFromViewJournal.EditValue.ToString).ToString("yyy-MM-dd")
        End If

        If DEToViewJournal.Text = "" Then
            DEToViewJournal.DateTime = Now
            enddate = Now.ToString("yyy-MM-dd")
        Else
            enddate = DateTime.Parse(DEToViewJournal.EditValue.ToString).ToString("yyy-MM-dd")
        End If
        Dim query As String = ""
        query = "SELECT ct.id_coa_tag,ct.unit,bill.bill_type,bill.id_bill_type,t.id_report_status,f.report_status,t.id_acc_trans,t.acc_trans_number,t.acc_trans_note,i.employee_name,  DATE_FORMAT(t.date_created, '%d %M %Y') AS date_created FROM tb_a_acc_trans t "
        query += "INNER JOIN tb_m_user h ON t.id_user = h.id_user "
        query += "INNER JOIN tb_m_employee i ON h.id_employee = i.id_employee "
        query += "INNER JOIN tb_lookup_report_status f ON t.id_report_status = f.id_report_status "
        query += "INNER JOIN tb_lookup_bill_type bill ON bill.id_bill_type=t.id_bill_type "
        query += " LEFT JOIN
(
	SELECT actd.id_acc_trans,actd.id_coa_tag,ct.tag_description AS unit 
	FROM tb_a_acc_trans_det actd
	INNER JOIN `tb_coa_tag` ct ON ct.id_coa_tag=actd.id_coa_tag
	GROUP BY actd.id_acc_trans
)ct ON ct.id_acc_trans=t.id_acc_trans "
        query += "WHERE (DATE(t.date_created) <= '" & enddate & "') AND (DATE(t.date_created) >= '" & fromdate & "')"

        If Not SLEUnit.EditValue.ToString = "0" Then
            query += " AND ct.id_coa_tag='" & SLEUnit.EditValue.ToString & "' "
        End If

        If Not LEBilling.EditValue.ToString = "ALL" Then
            query += " AND t.id_bill_type = '" + id_type + "' "
        End If
        query += "ORDER BY t.id_acc_trans DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAccTrans.DataSource = data
        check_but()
    End Sub

    Private Sub BViewJournal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewJournal.Click
        view_entry()
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
        showpopup.report_mark_type = GVJournalDet.GetFocusedRowCellValue("report_mark_type").ToString
        showpopup.id_report = GVJournalDet.GetFocusedRowCellValue("id_report").ToString
        showpopup.show()
        Cursor = Cursors.Default
    End Sub

    Private Sub SMEditEcopPD_Click(sender As Object, e As EventArgs) Handles SMEditEcopPD.Click
        Cursor = Cursors.WaitCursor
        Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
        showpopup.report_mark_type = GVJournalDet.GetFocusedRowCellValue("report_mark_type_ref").ToString
        showpopup.id_report = GVJournalDet.GetFocusedRowCellValue("id_report_ref").ToString
        showpopup.show()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVAccTrans_DoubleClick(sender As Object, e As EventArgs) Handles GVAccTrans.DoubleClick
        FormMain.but_edit()
    End Sub

    Private Sub BViewReff_Click(sender As Object, e As EventArgs) Handles BViewReff.Click
        Dim fromdate As String = ""
        Dim enddate As String = ""

        If DEFrom.Text = "" Then
            DEFrom.DateTime = Now
            fromdate = Now.ToString("yyy-MM-dd")
        Else
            fromdate = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyy-MM-dd")
        End If

        If DETo.Text = "" Then
            DETo.DateTime = Now
            enddate = Now.ToString("yyy-MM-dd")
        Else
            enddate = DateTime.Parse(DETo.EditValue.ToString).ToString("yyy-MM-dd")
        End If

        If LEBillingView.Text = "" Then
            warningCustom("Please choose type first")
        Else
            view_det(fromdate, enddate, "2")
        End If
    End Sub
End Class