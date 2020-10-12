Public Class FormVerifyECOP
    Private Sub FormVerifyECOP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewDesign()
        Dim query As String = ""
        query = "CALL view_design_order(TRUE)"
        viewSearchLookupQuery(SLEDesign, query, "id_design", "design_display_name", "id_design")
    End Sub

    Sub view_pps()
        Dim q_where As String = ""

        If Not SLEDesign.EditValue.ToString = "0" Then
            q_where = " AND pps.id_design='" & SLEDesign.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT 'no' AS is_check,pps.id_design,pps.id_design_ecop_pps,pps.number,dsg.design_code,dsg.design_display_name,SUM(IF(id_currency=1,ppsd.`before_kurs`,ppsd.`before_kurs`*ppsd.`kurs`)) AS total_ecop_purc,SUM(ppsd.`additional`) AS total_additional_purc
,(fg_lp.`target_price`/fg_lp.`mark_up`) AS target_cost
,cop_sample.total_sample,cop_sample.total_additional_sample
,IFNULL(jml_cal.jml,0) AS jml_recal
FROM `tb_design_ecop_pps_det` ppsd
INNER JOIN `tb_design_ecop_pps` pps ON pps.`id_design_ecop_pps`=ppsd.`id_design_ecop_pps`
LEFT JOIN(
	SELECT cop.`id_design`,SUM(IF(cop.id_currency=1,cop.before_kurs,(cop.before_kurs*cop.kurs))) AS total_sample,SUM(cop.`additional`) AS total_additional_sample
	FROM tb_m_design_cop cop
	WHERE cop.is_active=1 AND cop.`is_production_dept`=2
	GROUP BY cop.id_design
) cop_sample ON cop_sample.id_design = pps.id_design
LEFT JOIN (
	SELECT id_design,COUNT(id_design_ecop_pps) AS jml FROM `tb_design_ecop_pps`
	WHERE is_need_recalculate='1' AND id_report_status!=5
	GROUP BY id_design
) jml_cal ON jml_cal.id_design=pps.`id_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pps.`id_design`
INNER JOIN tb_fg_line_plan fg_lp ON fg_lp.`id_fg_line_plan`=dsg.`id_fg_line_plan`
WHERE pps.need_verify=1 AND pps.verify_status=0 AND pps.id_report_status=6 " & q_where & " HAVING NOT ISNULL(id_design_ecop_pps)"
        Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEcopPPS.DataSource = dt
        GVEcopPPS.BestFitColumns()
    End Sub

    Private Sub BSearchProposeECOP_Click(sender As Object, e As EventArgs) Handles BSearchProposeECOP.Click
        view_pps()
    End Sub

    Private Sub FormVerifyECOP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDesign()
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVEcopPPS.RowCount > 0 Then
            Dim cek As String = CheckEditSelAll.EditValue.ToString
            For i As Integer = 0 To ((GVEcopPPS.RowCount - 1) - GetGroupRowCount(GVEcopPPS))
                If cek Then
                    GVEcopPPS.SetRowCellValue(i, "is_check", "yes")
                Else
                    GVEcopPPS.SetRowCellValue(i, "is_check", "no")
                End If
            Next
        End If
    End Sub

    Private Sub BRecalculate_Click(sender As Object, e As EventArgs) Handles BRecalculate.Click
        GVEcopPPS.ActiveFilterString = "[is_check]='yes'"

        If TEComment.Text = "" Then
            warningCustom("Please put some comment.")
        ElseIf GVEcopPPS.RowCount = 0 Then
            warningCustom("Please pick ECOP to continue.")
        Else
            Try
                Dim number_error As String = ""
                Dim suc As Integer = 0
                FormMain.SplashScreenManager1.ShowWaitForm()
                FormMain.SplashScreenManager1.SetWaitFormDescription("Get all proposal")

                For i As Integer = 0 To GVEcopPPS.RowCount - 1
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Processing ECOP : " + (i + 1).ToString + " of " + GVEcopPPS.RowCount.ToString)

                    If GVEcopPPS.GetRowCellValue(i, "jml_recal") < Integer.Parse(get_opt_prod_field("ecop_limit_recalculate")) Then
                        Dim qu As String = ""
                        'update continue
                        qu = String.Format("UPDATE tb_design_ecop_pps SET is_need_recalculate=1,verify_status='2',verify_by='{1}',verify_date=NOW(),verify_comment='{2}' WHERE id_design_ecop_pps='{0}'", GVEcopPPS.GetRowCellValue(i, "id_design_ecop_pps").ToString, id_user, addSlashes(TEComment.Text))
                        execute_non_query(qu, True, "", "", "", "")
                        '
                        qu = String.Format("UPDATE tb_m_design_cop SET is_active='2' WHERE id_design='{0}'", GVEcopPPS.GetRowCellValue(i, "id_design").ToString)
                        execute_non_query(qu, True, "", "", "", "")
                        '
                        suc += 1
                    Else
                        'tidak bisa karena limit
                        If Not number_error = "" Then
                            number_error += vbNewLine
                        End If
                        number_error += "- " & GVEcopPPS.GetRowCellValue(i, "number").ToString
                    End If
                Next

                FormMain.SplashScreenManager1.CloseWaitForm()
                '
                If Not number_error = "" Then
                    warningCustom("Total ECOP recalculate issued : " & suc.ToString & "
Failed to update this propose because already hit reclaculation limit : " & vbNewLine & number_error)
                Else
                    infoCustom("Total ECOP recalculate issued : " & suc.ToString & "")
                End If

                If suc > 0 Then
                    'email need recalculate
                    For i As Integer = 0 To GVEcopPPS.RowCount - 1
                        Dim mail As ClassSendEmail = New ClassSendEmail()
                        mail.id_report = GVEcopPPS.GetRowCellValue(i, "id_design_ecop_pps").ToString
                        mail.report_mark_type = "271"
                        mail.send_email()
                    Next
                End If

                view_pps()
            Catch ex As Exception
                warningCustom(ex.ToString)
            End Try
        End If

        GVEcopPPS.ActiveFilterString = ""
    End Sub

    Private Sub BContinue_Click(sender As Object, e As EventArgs) Handles BContinue.Click
        GVEcopPPS.ActiveFilterString = "[is_check]='yes'"

        If TEComment.Text = "" Then
            warningCustom("Please put some comment.")
        ElseIf GVEcopPPS.RowCount = 0 Then
            warningCustom("Please pick ECOP to continue.")
        Else
            Try
                FormMain.SplashScreenManager1.ShowWaitForm()
                FormMain.SplashScreenManager1.SetWaitFormDescription("Get all proposal")

                For i As Integer = 0 To GVEcopPPS.RowCount - 1
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Processing ECOP : " + (i + 1).ToString + " of " + GVEcopPPS.RowCount.ToString)
                    'insert to m_design
                    Dim q As String = "SELECT pps.is_cool_storage,pps.is_production_dept,ppsd.kurs,pps.id_design,SUM(IF(ppsd.id_currency=1,ppsd.before_kurs,ppsd.before_kurs*ppsd.kurs)) AS cop,SUM(ppsd.additional) AS additional_cop,pps.id_comp_contact
FROM tb_design_ecop_pps_det ppsd
INNER JOIN tb_design_ecop_pps pps ON pps.id_design_ecop_pps=ppsd.id_design_ecop_pps AND pps.id_design_ecop_pps='" & GVEcopPPS.GetRowCellValue(i, "id_design_ecop_pps").ToString & "'
GROUP BY pps.id_design"
                    Dim dtq As DataTable = execute_query(q, -1, True, "", "", "", "")
                    '
                    Dim qu As String = ""
                    qu = String.Format("UPDATE tb_m_design SET prod_order_cop_pd='{1}',prod_order_cop_pd_addcost='{5}',prod_order_cop_kurs_pd='{2}',prod_order_cop_pd_vendor={3},prod_order_cop_pd_curr='{4}',is_cold_storage='{6}' WHERE id_design='{0}'", dtq.Rows(0)("id_design").ToString, decimalSQL((dtq.Rows(0)("cop") + dtq.Rows(0)("additional_cop")).ToString), decimalSQL(dtq.Rows(0)("kurs").ToString), dtq.Rows(0)("id_comp_contact").ToString, "1", decimalSQL(dtq.Rows(0)("additional_cop").ToString), dtq.Rows(0)("is_cool_storage").ToString)
                    execute_non_query(qu, True, "", "", "", "")
                    'email ECOP

                    'update continue
                    qu = String.Format("UPDATE tb_design_ecop_pps SET verify_status='1',verify_by='{1}',verify_date=NOW(),verify_comment='{2}' WHERE id_design_ecop_pps='{0}'", GVEcopPPS.GetRowCellValue(i, "id_design_ecop_pps").ToString, id_user, addSlashes(TEComment.Text))
                    execute_non_query(qu, True, "", "", "", "")
                Next

                FormMain.SplashScreenManager1.CloseWaitForm()
                view_pps()
            Catch ex As Exception

            End Try
        End If

        GVEcopPPS.ActiveFilterString = ""
    End Sub
End Class