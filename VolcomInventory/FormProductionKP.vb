Public Class FormProductionKP
    Public id_kp As String = "-1"
    Public is_locked As String = "2"
    Public is_purc_mat As String = "2"
    Dim is_void As String = "2"

    Private Sub FormProductionkp_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormProductionkp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        action_load()
    End Sub
    '
    Sub action_load()
        load_revision()

        load_head()
    End Sub

    Sub load_revision()
        Dim query As String = "SELECT id_prod_order_kp,LPAD(revision,2,'0') as revision,id_prod_order_kp_reff FROM tb_prod_order_kp WHERE id_prod_order_kp_reff=(SELECT id_prod_order_kp_reff FROM tb_prod_order_kp WHERE id_prod_order_kp='" & id_kp & "' LIMIT 1) ORDER BY id_prod_order_kp DESC"
        viewSearchLookupQuery(SLERevision, query, "id_prod_order_kp", "revision", "id_prod_order_kp")
    End Sub

    Sub load_head()
        'view yang revisi terakhir
        Dim query As String = "SELECT kp.is_locked,kp.is_void,kp.is_purc_mat,c.phone,c.fax,kp.number,cc.`contact_person`,c.`comp_number`,c.`comp_name`,c.`address_primary`,kp.`date_created`,LPAD(kp.`revision`,2,'0') AS revision
FROM tb_prod_order_kp kp
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=kp.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
WHERE id_prod_order_kp='" & id_kp & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            is_purc_mat = data.Rows(0)("is_purc_mat").ToString
            is_void = data.Rows(0)("is_void").ToString
            '
            TEKPNumber.Text = data.Rows(0)("number").ToString
            TECompCode.Text = data.Rows(0)("comp_number").ToString
            TECompName.Text = data.Rows(0)("comp_name").ToString
            MECompAddress.Text = data.Rows(0)("address_primary").ToString
            TECompAttn.Text = data.Rows(0)("contact_person").ToString
            '
            DEDateCreated.EditValue = data.Rows(0)("date_created")
            '
            TETelp.EditValue = data.Rows(0)("phone")
            TEFax.EditValue = data.Rows(0)("fax")

            is_locked = data.Rows(0)("is_locked").ToString
            'load_det
            load_det()
            '
        End If

        If is_locked = "1" Then
            'locked
            BLock.Visible = False
            BUpdate.Visible = False
            BRevise.Visible = True
            Bdel.Enabled = False
            PCDel.Visible = False
        Else
            BLock.Visible = True
            BUpdate.Visible = True
            BRevise.Visible = False
            Bdel.Enabled = True
            PCDel.Visible = True
        End If

        'void
        If is_void = "1" Then
            PCDel.Visible = False
            PCControl.Visible = False
        End If

        'prevent edit lead time
        If is_locked = "1" Then
            GridColumnProto2Sample.OptionsColumn.ReadOnly = True
        Else
            GridColumnProto2Sample.OptionsColumn.ReadOnly = False
        End If
    End Sub

    Sub load_det()
        Dim query As String = ""

        If is_purc_mat = "1" Then
            query = "SELECT kpd.sample_proto_2,kpd.revision,kpd.id_prod_order_kp_det,'' AS `no`,po.`mat_purc_number` AS prod_order_number,md.mat_det_display_name AS class_dsg,cd.`display_name` AS color
,SUM(pod.mat_purc_det_qty) AS qty_order,pod.mat_purc_det_price AS bom_unit,SUM(pod.mat_purc_det_price*pod.mat_purc_det_qty) AS po_amount_rp
,kpd.lead_time_prod AS lead_time,po.mat_purc_date AS prod_order_wo_del_date,DATE_ADD(po.mat_purc_date,INTERVAL kpd.lead_time_prod DAY) AS esti_del_date
,IFNULL(revtimes.revision_times,0) AS revision_times
FROM `tb_prod_order_kp_det` kpd
INNER JOIN tb_mat_purc po ON po.id_mat_purc=kpd.id_purc_order
INNER JOIN  tb_mat_purc_det pod ON po.id_mat_purc=pod.id_mat_purc
INNER JOIN tb_m_mat_det_price mdp ON mdp.`id_mat_det_price`=pod.`id_mat_det_price`
INNER JOIN tb_m_mat_det md ON md.`id_mat_det`=mdp.`id_mat_det`
INNER JOIN `tb_m_mat_det_code` mdc ON mdc.id_mat_det = md.id_mat_det
INNER JOIN `tb_m_code_detail` cd ON cd.id_code_detail=mdc.id_code_detail AND cd.id_code='1'
LEFT JOIN(
    SELECT revtimes.id_purc_order,COUNT(DISTINCT revtimes.revision) AS revision_times FROM
    (
	    SELECT kpd.id_purc_order,kpd.revision FROM tb_prod_order_kp_det kpd
	    INNER JOIN tb_prod_order_kp kp ON kp.`id_prod_order_kp`=kpd.`id_prod_order_kp`
	    WHERE kpd.revision!=0 AND kpd.id_prod_order_kp<='" & id_kp & "' AND kp.`id_prod_order_kp_reff`=(SELECT id_prod_order_kp_reff FROM tb_prod_order_kp WHERE id_prod_order_kp='" & id_kp & "' LIMIT 1)
	    GROUP BY kpd.id_purc_order,kpd.revision
    ) revtimes GROUP BY revtimes.id_purc_order
)revtimes ON revtimes.id_purc_order=po.id_mat_purc
WHERE kpd.id_prod_order_kp='" & id_kp & "'
GROUP BY po.id_mat_purc
ORDER BY po.`id_mat_purc` ASC"
        Else
            query = "SELECT kpd.sample_proto_2,kpd.revision,kpd.id_prod_order_kp_det,'' AS `no`,po.`prod_order_number`,LEFT(dsg.design_display_name,LENGTH(dsg.design_display_name)-3) AS class_dsg,RIGHT(dsg.design_display_name,3) AS color
,wo_price.qty_po AS qty_order,wo_price.prod_order_wo_det_price AS bom_unit,wo_price.price_amount AS po_amount_rp
,kpd.lead_time_prod AS lead_time,wo_price.prod_order_wo_del_date,DATE_ADD(wo_price.prod_order_wo_del_date,INTERVAL kpd.lead_time_prod DAY) AS esti_del_date
,IFNULL(revtimes.revision_times,0) AS revision_times
FROM `tb_prod_order_kp_det` kpd
INNER JOIN tb_prod_order po ON po.id_prod_order=kpd.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON po.`id_prod_demand_design`=pdd.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
LEFT JOIN (
	SELECT wo.id_prod_order, wo.id_ovh_price, wo.prod_order_wo_kurs, cur.currency,wo.prod_order_wo_vat,wod.prod_order_wo_det_price
	,(SUM(wod.prod_order_wo_det_price * pod.prod_order_qty) * wo.prod_order_wo_kurs * (100 + wo.prod_order_wo_vat)/100) AS `wo_price`
	,(SUM(wod.prod_order_wo_det_price * pod.prod_order_qty) * (100 + wo.prod_order_wo_vat)/100) AS `wo_price_no_kurs`
	,(SUM(wod.prod_order_wo_det_price * pod.prod_order_qty) * wo.prod_order_wo_kurs) AS `price_amount`
	,SUM(pod.prod_order_qty) AS qty_po
    ,wo.prod_order_wo_del_date,wo.prod_order_wo_lead_time
	FROM tb_prod_order_wo wo
	INNER JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo = wo.id_prod_order_wo
	INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = wod.id_prod_order_det
    INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
	WHERE wo.is_main_vendor=1 
	GROUP BY wo.id_prod_order_wo
) wo_price ON wo_price.id_prod_order= po.id_prod_order
LEFT JOIN(
    SELECT revtimes.id_prod_order,COUNT(DISTINCT revtimes.revision) AS revision_times FROM
    (
	    SELECT kpd.id_prod_order,kpd.revision FROM tb_prod_order_kp_det kpd
	    INNER JOIN tb_prod_order_kp kp ON kp.`id_prod_order_kp`=kpd.`id_prod_order_kp`
	    WHERE kpd.revision!=0 AND kpd.id_prod_order_kp<='3' AND kp.`id_prod_order_kp_reff`=(SELECT id_prod_order_kp_reff FROM tb_prod_order_kp WHERE id_prod_order_kp='" & id_kp & "' LIMIT 1)
	    GROUP BY kpd.id_prod_order,kpd.revision
    ) revtimes GROUP BY revtimes.id_prod_order
)revtimes ON revtimes.id_prod_order=po.id_prod_order
WHERE kpd.id_prod_order_kp='" & id_kp & "'
ORDER BY po.`id_prod_order` ASC"
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "'")
        GCProd.DataSource = data
        GVProd.BestFitColumns()
    End Sub

    Private Sub BUpdate_Click(sender As Object, e As EventArgs) Handles BUpdate.Click
        'update lead time
        Dim query As String = ""
        For i As Integer = 0 To GVProd.RowCount - 1
            Dim date_proto_2 As String = Date.Parse(GVProd.GetRowCellValue(i, "sample_proto_2").ToString).ToString("yyyy-MM-dd")
            query = "UPDATE tb_prod_order_kp_det SET sample_proto_2='" & date_proto_2 & "' WHERE id_prod_order_kp_det='" & GVProd.GetRowCellValue(i, "id_prod_order_kp_det").ToString & "'"
            execute_non_query(query, True, "", "", "", "")
        Next
        infoCustom("KP updated")
        load_head()
    End Sub

    Private Sub Bdel_Click(sender As Object, e As EventArgs) Handles Bdel.Click
        If is_locked = "2" Then
            Dim query As String = "DELETE FROM tb_prod_order_kp_det WHERE id_prod_order_kp_det='" & GVProd.GetFocusedRowCellValue("id_prod_order_kp_det").ToString & "'"
            execute_non_query(query, True, "", "", "", "")
            infoCustom("KP updated")
            load_head()
        Else
            warningCustom("KP locked")
        End If
    End Sub

    Private Sub BLock_Click(sender As Object, e As EventArgs) Handles BLock.Click
        Dim query As String = "UPDATE tb_prod_order_kp SET is_locked='1' WHERE id_prod_order_kp='" & id_kp & "'"
        execute_non_query(query, True, "", "", "", "")
        infoCustom("KP locked")
        load_head()
    End Sub

    Private Sub BPrintkp_Click(sender As Object, e As EventArgs) Handles BPrintKP.Click
        'check copy proto 2 first
        Dim q As String = "SELECT po.cps2_verify 
FROM `tb_prod_order_kp_det` kpd
INNER JOIN tb_prod_order po ON po.`id_prod_order`=kpd.`id_prod_order`
WHERE po.cps2_verify=2 AND kpd.`id_prod_order_kp`='" & SLERevision.EditValue.ToString & "' AND po.is_need_cps2_verify=1"
        Dim dtc As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dtc.Rows.Count > 0 Then
            warningCustom("Copy Proto 2 belum terverifikasi.")
        Else
            Dim query As String = "SELECT c.phone,c.fax,kp.number,cc.`contact_person`,c.`comp_number`,c.`comp_name`,c.`address_primary`,DATE_FORMAT(kp.`date_created`,'%d %M %Y') AS date_created,LPAD(kp.`revision`,2,'0') AS revision
,emp_created.employee_name AS emp_name_created,emp_created.`employee_position` AS created_pos
,emp_purc_mngr.employee_name AS emp_name_purc_mngr,rl_purc_mngr.`role` AS purc_mngr_pos
,emp_ast_mngr.employee_name AS emp_name_asst_prod_mngr,rl_asst_mngr.`role` AS asst_prod_mngr_pos
FROM tb_prod_order_kp kp
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=kp.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
INNER JOIN tb_m_user usr_created ON usr_created.`id_user`=kp.`created_by`
INNER JOIN tb_m_user usr_purc_mngr ON usr_purc_mngr.`id_user`=kp.`id_user_purc_mngr`
INNER JOIN tb_m_user usr_ast_mngr ON usr_ast_mngr.`id_user`=kp.`id_user_asst_prod_mngr`
INNER JOIN tb_m_employee emp_created ON emp_created.`id_employee`=usr_created.`id_employee`
INNER JOIN tb_m_employee emp_purc_mngr ON emp_purc_mngr.`id_employee`=usr_purc_mngr.`id_employee`
INNER JOIN tb_m_employee emp_ast_mngr ON emp_ast_mngr.`id_employee`=usr_ast_mngr.`id_employee`
INNER JOIN tb_m_role rl_purc_mngr ON rl_purc_mngr.id_role=usr_purc_mngr.id_role
INNER JOIN tb_m_role rl_asst_mngr ON rl_asst_mngr.id_role=usr_ast_mngr.id_role
WHERE id_prod_order_kp='" & SLERevision.EditValue.ToString & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            ReportProductionKP.dt_head = data
            '
            ReportProductionKP.dt_det = GCProd.DataSource


            Dim Report As New ReportProductionKP()
            Report.LQtyOrder.Text = Decimal.Parse(GVProd.Columns("qty_order").SummaryItem.SummaryValue.ToString).ToString("N0")
            '
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            If Not is_locked = "1" Then
                Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.Print, DevExpress.XtraPrinting.CommandVisibility.None)
                Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect, DevExpress.XtraPrinting.CommandVisibility.None)
                Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
            End If
            Tool.ShowPreview()
        End If
    End Sub

    Private Sub BRevise_Click(sender As Object, e As EventArgs) Handles BRevise.Click
        Dim check As String = "SELECT * FROM tb_prod_order_kp WHERE number='" & addSlashes(TEKPNumber.Text) & "' ORDER BY id_prod_order_kp DESC"
        Dim data_check As DataTable = execute_query(check, -1, True, "", "", "", "")
        If id_kp = data_check.Rows(0)("id_prod_order_kp").ToString Then
            'check attachment
            Dim qc As String = "SELECT * FROM `tb_doc` WHERE id_report='" & id_kp & "' AND report_mark_type='253'"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                Dim query As String = "INSERT INTO tb_prod_order_kp(`id_prod_order_kp_reff`,`number`,`revision`,`id_comp_contact`,`date_created`,`created_by`,`id_user_purc_mngr`,`id_user_asst_prod_mngr`,`is_purc_mat`)
SELECT `id_prod_order_kp_reff`,`number`,(SELECT COUNT(id_prod_order_kp) FROM tb_prod_order_kp WHERE id_prod_order_kp_reff=(SELECT id_prod_order_kp_reff FROM tb_prod_order_kp WHERE id_prod_order_kp='" & id_kp & "')),`id_comp_contact`,`date_created`,`created_by`,`id_user_purc_mngr`,`id_user_asst_prod_mngr`,`is_purc_mat` FROM tb_prod_order_kp WHERE id_prod_order_kp='" & id_kp & "'; SELECT LAST_INSERT_ID(); "
                Dim new_id_kp As String = execute_query(query, 0, True, "", "", "", "")
                'det
                'loop
                Dim q_det As String = "SELECT kpd.`revision`,kpd.`id_prod_order`,kpd.`id_purc_order`,IF(ISNULL(kpd.id_prod_order),IFNULL(kopurc.lead_time_prod,kpd.lead_time_prod),IFNULL(koprod.lead_time_prod,kpd.lead_time_prod)) AS lead_time_prod,kpd.`sample_proto_2`
FROM tb_prod_order_kp_det kpd
LEFT JOIN (
	SELECT lead_time_prod,id_prod_order FROM (
	    SELECT * FROM tb_prod_order_ko_det
	    ORDER BY id_prod_order_ko_det DESC
	)ko GROUP BY ko.id_prod_order
)koprod ON koprod.id_prod_order=kpd.id_prod_order
LEFT JOIN (
	SELECT lead_time_prod,id_purc_order FROM (
	    SELECT * FROM tb_prod_order_ko_det
	    ORDER BY id_prod_order_ko_det DESC
	)ko GROUP BY ko.id_purc_order
)kopurc ON kopurc.id_purc_order=kpd.id_purc_order
WHERE id_prod_order_kp='" & id_kp & "'"
                Dim data_det As DataTable = execute_query(q_det, -1, True, "", "", "", "")
                query = ""
                For i As Integer = 0 To data_det.Rows.Count - 1
                    If Not i = 0 Then
                        query += ","
                    End If
                    query += "('" & new_id_kp & "','" & data_det.Rows(i)("revision").ToString & "','" & data_det.Rows(i)("id_prod_order").ToString & "','" & data_det.Rows(i)("id_purc_order").ToString & "','" & data_det.Rows(i)("lead_time_prod").ToString & "','" & Date.Parse(data_det.Rows(i)("sample_proto_2").ToString).ToString("yyyy-MM-dd") & "')"
                Next

                If Not query = "" Then
                    query = "INSERT INTO tb_prod_order_kp_det(`id_prod_order_kp`,`revision`,`id_prod_order`,`id_purc_order`,`lead_time_prod`,`sample_proto_2`)
VALUES" + query
                    execute_non_query(query, True, "", "", "", "")
                End If
                '
                infoCustom("kp revised")
                id_kp = new_id_kp
                action_load()
            Else
                warningCustom("Please attach SKP file first")
            End If
        Else
            warningCustom("This is not the latest revision")
        End If
    End Sub

    Private Sub SLERevision_EditValueChanged(sender As Object, e As EventArgs) Handles SLERevision.EditValueChanged
        SLERevision.Refresh()
        id_kp = SLERevision.EditValue.ToString
        load_head()
    End Sub

    Private Sub BAttachment_Click(sender As Object, e As EventArgs) Handles BAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_kp
        FormDocumentUpload.report_mark_type = "253"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class