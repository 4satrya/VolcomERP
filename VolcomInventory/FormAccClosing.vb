Public Class FormAccClosing
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"

    Private Sub FormReportAccClosing_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormReportAccClosing_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormAccClosing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEUntil.EditValue = New DateTime(Now.Year, Now.Month, Date.DaysInMonth(Now.Year, Now.Month))
        set_min_date_reference(DEUntil)
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        Try
            DEUntil.EditValue = New DateTime(DEUntil.EditValue.Year, DEUntil.EditValue.Month, Date.DaysInMonth(DEUntil.EditValue.Year, DEUntil.EditValue.Month))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        Dim query As String = "SELECT trx.id_acc_trans,trxd.id_report,trxd.report_number,trxd.report_mark_type,emp.`employee_name`,trx.`date_created`,trx.`date_reference`,bt.`bill_type`,trx.`acc_trans_number`,SUM(trxd.`debit`) AS debit,SUM(trxd.credit) AS credit,IF(SUM(trxd.`debit`)!=SUM(trxd.credit),'Not Balance',IF(SUM(trxd.`debit`)<=0,'Value zero','Ok')) AS sts 
FROM tb_a_acc_trans_det trxd
INNER JOIN tb_a_acc_trans trx ON trxd.`id_acc_trans`=trx.`id_acc_trans`
INNER JOIN `tb_lookup_bill_type` bt ON bt.`id_bill_type`=trx.`id_bill_type`
INNER JOIN tb_m_user usr ON usr.`id_user`=trx.`id_user`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE trx.`is_close`='2' AND trx.`date_reference`<='" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "'
GROUP BY trxd.`id_acc_trans`
HAVING NOT sts='Ok'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCClosing.DataSource = data
        GVClosing.BestFitColumns()

        If Not data.Rows.Count > 0 Then
            infoCustom("No transaction problem, click closing to do monthly posting.")
            DEUntil.Enabled = False
            BClosing.Visible = True
        Else
            DEUntil.Enabled = True
            BClosing.Visible = False
        End If
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        If GVClosing.RowCount > 0 Then
            Dim p As ClassShowPopUp = New ClassShowPopUp()
            p.id_report = GVClosing.GetFocusedRowCellValue("id_acc_trans").ToString
            p.report_mark_type = "36"
            p.show()
        End If
    End Sub

    Private Sub ViewReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewReportToolStripMenuItem.Click
        If GVClosing.RowCount > 0 Then
            Dim p As ClassShowPopUp = New ClassShowPopUp()
            p.id_report = GVClosing.GetFocusedRowCellValue("id_report").ToString
            p.report_mark_type = GVClosing.GetFocusedRowCellValue("report_mark_type").ToString
            p.show()
        End If
    End Sub

    Private Sub BClosing_Click(sender As Object, e As EventArgs) Handles BClosing.Click
        'log start
        Dim month_str = Date.Parse(DEUntil.EditValue.ToString).ToString("MM")
        Dim query As String = "INSERT INTO `tb_closing_log`(date_until,date_closing,note) VALUES('" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "',NOW(),'Closing Start')"
        execute_non_query(query, True, "", "", "", "")

        'pindah saldo profit and loss ke laba tahun berjalan (kredit), jika akhir tahun pindah ke laba ditahan
        'bulanan
        Dim id_user_prepared As String = id_user
        Dim report_number As String = "Closing Posting " & Date.Parse(DEUntil.EditValue.ToString).ToString("MMM - yyyy")

        'main journal bulanan
        Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created,date_reference, acc_trans_note, id_report_status, is_close)
                        VALUES ('" + header_number_acc("1") + "','" + report_number + "','0','" + id_user_prepared + "', NOW(), '" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "', 'Auto Posting', '6', '1'); SELECT LAST_INSERT_ID(); "
        Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
        increase_inc_acc("1")

        'det journal bulanan
        Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number,id_comp)
                            SELECT " + id_acc_trans + " AS `id_trans`,coal.`id_acc`,1 AS qty,0 AS debit,SUM((IF(acc.id_dc=1,1,-1)*trxd.debit)+(IF(acc.id_dc=1,-1,1)*trxd.credit)) AS credit,'' AS note,0 AS rmt,0 AS id_report,'' AS number, trxd.id_comp
        FROM tb_a_acc_trans_det trxd
        INNER JOIN tb_a_acc_trans trx ON trx.`id_acc_trans`=trxd.`id_acc_trans`
        INNER JOIN tb_a_acc acc ON acc.id_acc=trxd.id_acc AND (LEFT(acc.acc_name,1)='3' OR LEFT(acc.acc_name,1)='4')
        INNER JOIN tb_lookup_coa_laba coal ON coal.id_month=MONTH('" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-01") & "')
        WHERE trx.`is_close`='2' AND trx.id_report_status!=5 AND DATE(trx.`date_reference`)<='" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(trx.`date_reference`)>='" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-01") & "' 
        GROUP BY trxd.id_comp
        HAVING credit>0"
        execute_non_query(qjd, True, "", "", "", "")
        'posting tahunan
        If month_str = "12" Then
            'create coa laba ditahan tahun ini if not exist
            Dim id_acc_laba As String = "-1"
            Dim q As String = "SELECT * FROM tb_a_acc WHERE acc_name='22121110" & Date.Parse(DEUntil.EditValue.ToString).ToString("yy") & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If Not dt.Rows.Count > 0 Then
                q = "INSERT INTO tb_a_acc(acc_name,acc_description,id_acc_parent,id_acc_cat,id_is_det,id_status,id_dc) VALUES('22121110" & Date.Parse(DEUntil.EditValue.ToString).ToString("yy") & "','Tahun 20" & Date.Parse(DEUntil.EditValue.ToString).ToString("yy") & "','1523','2','2','1','2'); SELECT LAST_INSERT_ID(); "
                id_acc_laba = execute_query(q, 0, True, "", "", "", "")
            Else
                id_acc_laba = dt.Rows(0)("id_acc").ToString
            End If
            'pindah laba berjalan ke ditahan
            qjm = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created,date_reference, acc_trans_note, id_report_status, is_close)
                        VALUES ('" + header_number_acc("1") + "','" + report_number + "','0','" + id_user_prepared + "', NOW(), DATE_ADD('" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "',INTERVAL 1 DAY), 'Auto Posting', '6', '1'); SELECT LAST_INSERT_ID(); "
            id_acc_trans = execute_query(qjm, 0, True, "", "", "", "")
            increase_inc_acc("1")
            '
            q = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number,id_comp)
                 SELECT " + id_acc_trans + " AS `id_trans`," + id_acc_laba + ",1 AS qty,0 AS debit,SUM((IF(acc.id_dc=1,1,-1)*trxd.debit)+(IF(acc.id_dc=1,-1,1)*trxd.credit)) AS credit,'Pindah laba berjalan ke laba ditahan' AS note,0 AS rmt,0 AS id_report,'' AS number, trxd.id_comp
FROM tb_a_acc_trans_det trxd
INNER JOIN tb_a_acc_trans trx ON trx.id_acc_trans=trxd.id_acc_trans
INNER JOIN tb_a_acc acc ON acc.id_acc=trxd.id_acc AND LEFT(acc.acc_name,7)='2214111'
WHERE YEAR(trx.date_reference)='" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy") & "'
GROUP BY trxd.id_comp"
            execute_non_query(q, True, "", "", "", "")
        End If

        'closing
        query = "UPDATE tb_a_acc_trans trx SET trx.is_close='1' WHERE trx.`is_close`='2' AND trx.`date_reference`<='" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "'  AND DATE(trx.`date_reference`)>='" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-01") & "'"
        execute_non_query(query, True, "", "", "", "")

        'log end
        query = "INSERT INTO `tb_closing_log`(date_until,date_closing,note) VALUES('" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "',NOW(),'Closing End')"
        execute_non_query(query, True, "", "", "", "")

        '
        infoCustom("Closing complete")
        DEUntil.Enabled = True
        set_min_date_reference(DEUntil)
        BClosing.Visible = False
    End Sub
End Class