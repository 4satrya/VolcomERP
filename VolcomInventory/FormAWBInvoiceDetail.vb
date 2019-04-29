Public Class FormAWBInvoiceDetail
    Public awbill_no As String = ""
    Private Sub FormAWBInvoiceDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = ""
        gridBandDO.Visible = True
        query = "SELECT 'no' AS is_check,IF(awb.is_lock=2,'no','yes') AS is_lock,awb.awbill_no,awb.awbill_inv_no,IF(is_paid_by_store='2','no','yes') as is_cod,do.do_no,do.qty,do.reff, do.scan_date, grp.comp_group,comp_store.comp_number as account,comp_store.comp_name as account_name,comp_cargo.comp_name as cargo,comp_store.awb_cargo_code AS awb_cargo_code,comp_store.awb_zone AS awb_zone,comp_store.awb_destination AS awb_destination,awb.*, ((awb.height*awb.length*awb.width)/6000) as volume,"
        query += " DATE_ADD(awb.pick_up_date, INTERVAL awb.cargo_lead_time DAY) AS eta_date,"
        query += " DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) AS del_time,"
        query += " (DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time) AS lead_time_diff,"
        query += " (IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time=0, 'ON TIME', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time>0, 'LATE', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time<0, 'EARLY', 'ON DELIVERY')))) AS time_remark,"
        query += " (awb.c_weight-awb.a_weight) as weight_diff,(awb.c_tot_price-awb.a_tot_price) as amount_diff, ('') AS `rmk`, ('') AS `no`"
        query += " ,IF(ISNULL(head.id_wh_awb_det),1,2) AS penanda"
        query += " FROM tb_wh_awbill awb"
        query += " inner join tb_m_comp comp_store On comp_store.id_comp=awb.id_store"
        query += " inner join tb_m_comp comp_cargo On comp_cargo.id_comp=awb.id_cargo"
        query += " left join tb_m_comp_group grp ON grp.id_comp_group = comp_store.id_comp_group"
        query += " inner join tb_wh_awbill_det awbd ON awbd.id_awbill=awb.id_awbill"
        query += " inner join tb_wh_awb_do do ON do.do_no=awbd.do_no"
        query += " LEFT JOIN
                            (
	                            SELECT id_wh_awb_det
	                            FROM tb_wh_awbill_det awbd
	                            INNER JOIN tb_wh_awbill awb ON awb.`id_awbill`=awbd.`id_awbill`
	                            INNER JOIN tb_wh_awb_do `do` ON `do`.`do_no`=awbd.`do_no`
	                            WHERE awb.awbill_no = '" & awbill_no & "' 
	                            GROUP BY awbd.id_awbill
                            ) head ON head.id_wh_awb_det=awbd.id_wh_awb_det"
        query += " WHERE awb.awbill_type='1' AND awb.awbill_no = '" & awbill_no & "' "
        query += " UNION ALL "
        query += "SELECT 'no' AS is_check,IF(awb.is_lock=2,'no','yes') AS is_lock,awb.awbill_no,awb.awbill_inv_no,IF(is_paid_by_store='2','no','yes') as is_cod,awbd.do_no,awbd.qty, UPPER(sos.so_status) AS `reff`,do.pl_sales_order_del_date AS `scan_date`, grp.comp_group,comp_store.comp_number as account,comp_store.comp_name as account_name,comp_cargo.comp_name as cargo,comp_store.awb_cargo_code AS awb_cargo_code,comp_store.awb_zone AS awb_zone,comp_store.awb_destination AS awb_destination,awb.*, ((awb.height*awb.length*awb.width)/6000) as volume,"
        query += " DATE_ADD(awb.pick_up_date, INTERVAL awb.cargo_lead_time DAY) AS eta_date,"
        query += " DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) AS del_time,"
        query += " (DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time) AS lead_time_diff,"
        query += " (IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time=0, 'ON TIME', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time>0, 'LATE', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time<0, 'EARLY', 'ON DELIVERY')))) AS time_remark,"
        query += " (awb.c_weight-awb.a_weight) as weight_diff,(awb.c_tot_price-awb.a_tot_price) as amount_diff, ('') AS `rmk`, ('') AS `no`"
        query += " ,IF(ISNULL(head.id_wh_awb_det),1,2) AS penanda"
        query += " FROM tb_wh_awbill awb"
        query += " inner join tb_m_comp comp_store On comp_store.id_comp=awb.id_store"
        query += " inner join tb_m_comp comp_cargo On comp_cargo.id_comp=awb.id_cargo"
        query += " left join tb_m_comp_group grp ON grp.id_comp_group = comp_store.id_comp_group"
        query += " inner join tb_wh_awbill_det awbd ON awbd.id_awbill=awb.id_awbill"
        query += " LEFT JOIN
                            (
	                            SELECT id_wh_awb_det
	                            FROM tb_wh_awbill_det awbd
	                            INNER JOIN tb_wh_awbill awb ON awb.`id_awbill`=awbd.`id_awbill`
	                            WHERE awb.awbill_no = '" & awbill_no & "' 
	                            GROUP BY awbd.id_awbill
                            ) head ON head.id_wh_awb_det=awbd.id_wh_awb_det
                        inner join tb_pl_sales_order_del do ON do.id_pl_sales_order_del =awbd.id_pl_sales_order_del
				        INNER JOIN tb_sales_order so ON so.id_sales_order = do.id_sales_order
				        INNER JOIN tb_lookup_so_status sos ON sos.id_so_status = so.id_so_status"
        query += " WHERE awb.awbill_type='1' AND awb.awbill_no = '" & awbill_no & "'"
        query += " ORDER BY id_awbill,do_no ASC "
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCAWBill.DataSource = data
        GVAWBill.BestFitColumns()
        gridBandCalcDetail.Visible = False
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Dim Report As New ReportDynamic
        ReportDynamic.dt = GCAWBill.DataSource
        'header
        Report.LTitle.Text = "AWBill Collie List"
        Report.XCHead1.Text = "Awbill Number "
        Report.XCHead1Val.Text = awbill_no
        'datatable
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVAWBill.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVDetail.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVDetail)

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
End Class