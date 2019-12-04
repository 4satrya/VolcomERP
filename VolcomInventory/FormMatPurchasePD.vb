Public Class FormMatPurchasePD
    Public id_list As String = "-1"

    Private Sub FormMatPurchasePD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
        load_mat()
        load_break_down()
        '
        load_view()
    End Sub

    Sub load_break_down()
        Dim query As String = "SELECT '2' AS id,'Normal' as description
UNION
SELECT '1' AS id,'Breakdown Size' as description"
        viewSearchLookupQuery(SLEBreakDown, query, "id", "description", "id")
    End Sub

    Sub load_view()
        If Not id_list = "-1" Then 'view
            BCancel.Visible = True
            Dim query As String = "SELECT p.is_breakdown,p.id_mat_det,p.qty_consumption,p.tolerance,p.note,uom.uom,p.id_mat_purc,p.is_cancel,LPAD(p.`id_mat_purc_list`,6,'0') AS number
FROM tb_mat_purc_list p
INNER JOIN tb_m_mat_det md ON md.id_mat_det=p.id_mat_det
INNER JOIN tb_m_mat m ON m.id_mat=md.id_mat
INNER JOIN tb_m_uom uom ON uom.id_uom=m.id_uom
WHERE p.id_mat_purc_list='" & id_list & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                LNumber.Text = "Number : " & data.Rows(0)("number").ToString
                SLEMaterial.EditValue = data.Rows(0)("id_mat_det").ToString
                TEConsumption.EditValue = data.Rows(0)("qty_consumption")
                TEToleransi.EditValue = data.Rows(0)("tolerance")
                MENote.EditValue = data.Rows(0)("note").ToString
                TEUOM.Text = data.Rows(0)("uom").ToString

                SLEBreakDown.EditValue = data.Rows(0)("is_breakdown").ToString
                If SLEBreakDown.EditValue.ToString = "1" Then
                    GridColumnSize.VisibleIndex = "4"
                Else
                    GridColumnSize.VisibleIndex = "-1"
                End If

                If Not data.Rows(0)("id_mat_purc").ToString = "" Or data.Rows(0)("is_cancel").ToString = "1" Then
                    load_pd_view()

                    BCancel.Enabled = False
                    BSetConsumption.Enabled = False
                    BCalculate.Enabled = False
                    TEToleransi.Enabled = False
                    '
                    BSave.Visible = False
                Else
                    load_pd_view_edit()
                End If
                set_calculate()
            End If
            BDuplicate.Visible = True
        Else
            LNumber.Text = "Number : -"
            BSetConsumption.Enabled = True
            TEToleransi.Enabled = True
            BCalculate.Enabled = True
            BSave.Visible = True
            BCancel.Visible = False
            BDuplicate.Visible = False
        End If
    End Sub

    Sub load_head()
        TEConsumption.EditValue = 0.00
        TEToleransi.EditValue = 0.00
        TEToleransiAmount.EditValue = 0.00
        TETotal.EditValue = 0.00
        TETotalAmount.EditValue = 0.00
    End Sub

    Sub load_mat()
        Dim query As String = "SELECT md.`id_mat_det`,md.`id_mat`,md.`mat_det_code`,md.`mat_det_display_name` ,uom.`uom`
FROM tb_m_mat_det md
INNER JOIN tb_m_mat mat ON mat.`id_mat`=md.`id_mat`
INNER JOIN tb_m_uom uom ON uom.`id_uom`=mat.`id_uom`"
        viewSearchLookupQuery(SLEMaterial, query, "id_mat_det", "mat_det_display_name", "id_mat_det")
        SLEMaterial.EditValue = Nothing
    End Sub

    Sub load_pd()
        Dim query As String = ""
        If SLEBreakDown.EditValue.ToString = "1" Then
            'breakdown
            query = "SELECT 'no' AS is_check,pdp.size,'' AS note,pdp.id_prod_demand_design,pdp.id_prod_demand_product,pdp.id_design,pdp.qty,dsg.design_display_name,dsg.design_code,pdp.prod_demand_number,pdp.qty,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*pdp.qty) AS qty_order 
FROM (
	SELECT pd_dsg.id_prod_demand_design, pd_prd.`id_prod_demand_product`, pd_dsg.id_prod_demand, pd.prod_demand_number, pd_dsg.id_design, 
	pd_dsg.prod_demand_design_propose_price, pd_dsg.prod_demand_design_total_cost, pd_dsg.msrp,
	(SUM(pd_prd.prod_demand_product_qty)) AS qty
	,pc.size,pd_prd.id_product
	FROM  tb_prod_demand_design pd_dsg
	INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pd_dsg.id_prod_demand
	LEFT JOIN tb_prod_demand_product pd_prd ON pd_prd.id_prod_demand_design = pd_dsg.id_prod_demand_design 
	INNER JOIN 
	(
		SELECT pc.`id_product`,cd.`code_detail_name` AS size FROM 
		tb_m_product_code pc 
		INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail` AND cd.`id_code`='33'
	)pc ON pc.`id_product`=pd_prd.`id_product`
	WHERE pd.id_report_status = '6' AND pd_dsg.is_void=2
	GROUP BY pd_prd.id_prod_demand_product
	ORDER BY pd_prd.id_prod_demand_product DESC
) pdp
INNER JOIN tb_m_design dsg ON dsg.id_design=pdp.id_design
LEFT JOIN
(
	SELECT id_prod_demand_product FROM `tb_mat_purc_list_pd` plp
	INNER JOIN tb_mat_purc_list pl ON pl.`id_mat_purc_list`=plp.`id_mat_purc_list` AND pl.`is_cancel`=2 AND pl.id_mat_det='" & SLEMaterial.EditValue.ToString & "'
) pl ON pl.id_prod_demand_product=pdp.id_prod_demand_product
WHERE ISNULL(pl.id_prod_demand_product)
GROUP BY pdp.id_product
ORDER BY pdp.id_prod_demand_design DESC"
        Else
            'normal
            query = "SELECT 'no' AS is_check,'' AS note,pdd.id_prod_demand_design,pdd.id_design,pdd.qty,dsg.design_display_name,dsg.design_code,pdd.prod_demand_number,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*pdd.qty) AS qty_order 
FROM (
	SELECT pd_dsg.id_prod_demand_design, pd_dsg.id_prod_demand, pd.prod_demand_number, pd_dsg.id_design, 
	pd_dsg.prod_demand_design_propose_price, pd_dsg.prod_demand_design_total_cost, pd_dsg.msrp,
	(SUM(pd_prd.prod_demand_product_qty)) AS qty
	FROM  tb_prod_demand_design pd_dsg
	INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pd_dsg.id_prod_demand
	LEFT JOIN tb_prod_demand_product pd_prd ON pd_prd.id_prod_demand_design = pd_dsg.id_prod_demand_design 
	WHERE pd.id_report_status = '6' AND pd_dsg.is_void=2
	GROUP BY pd_dsg.id_prod_demand_design
	ORDER BY pd_dsg.id_prod_demand_design DESC
) pdd
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
LEFT JOIN
(
	SELECT id_prod_demand_design FROM `tb_mat_purc_list_pd` plp
	INNER JOIN tb_mat_purc_list pl ON pl.`id_mat_purc_list`=plp.`id_mat_purc_list` AND pl.`is_cancel`=2 AND pl.id_mat_det='" & SLEMaterial.EditValue.ToString & "'
) pl ON pl.id_prod_demand_design=pdd.id_prod_demand_design
WHERE ISNULL(pl.id_prod_demand_design)
GROUP BY pdd.id_design
ORDER BY pdd.id_prod_demand_design DESC"
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPD.DataSource = data
    End Sub

    Sub load_pd_view()
        Dim query As String = ""
        If SLEBreakDown.EditValue.ToString = "1" Then
            'breakdown
            query = "SELECT 'yes' AS is_check,pc.size,lp.note AS note,lp.id_prod_demand_design,lp.id_prod_demand_product,pdd.id_design,lp.total_qty_pd AS qty,dsg.design_display_name,dsg.design_code,pd.prod_demand_number,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*lp.total_qty_pd) AS qty_order 
FROM tb_mat_purc_list_pd lp
INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_product=lp.id_prod_demand_product
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=pdp.id_prod_demand_design
INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
INNER JOIN 
(
	SELECT pc.`id_product`,cd.`code_detail_name` AS size FROM 
	tb_m_product_code pc 
	INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail` AND cd.`id_code`='33'
)pc ON pc.`id_product`=pdp.`id_product`
WHERE lp.id_mat_purc_list='" & id_list & "'
ORDER BY pdd.id_prod_demand_design DESC"
        Else
            'normal
            query = "SELECT 'yes' AS is_check,lp.note AS note,lp.id_prod_demand_design,pdd.id_design,lp.total_qty_pd AS qty,dsg.design_display_name,dsg.design_code,pd.prod_demand_number,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*lp.total_qty_pd) AS qty_order 
FROM tb_mat_purc_list_pd lp
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=lp.id_prod_demand_design
INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
WHERE lp.id_mat_purc_list='" & id_list & "'
ORDER BY pdd.id_prod_demand_design DESC"
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPD.DataSource = data
    End Sub

    Sub load_pd_view_edit()
        Dim query As String = ""
        If SLEBreakDown.EditValue.ToString = "1" Then
            'breakdown
            query = "SELECT 'yes' AS is_check,pc.size,lp.note AS note,lp.id_prod_demand_design,lp.id_prod_demand_product,pdd.id_design,lp.total_qty_pd AS qty,dsg.design_display_name,dsg.design_code,pd.prod_demand_number,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*lp.total_qty_pd) AS qty_order 
FROM tb_mat_purc_list_pd lp
INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_product=lp.id_prod_demand_product
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=pdp.id_prod_demand_design
INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
INNER JOIN 
(
	SELECT pc.`id_product`,cd.`code_detail_name` AS size FROM 
	tb_m_product_code pc 
	INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail` AND cd.`id_code`='33'
)pc ON pc.`id_product`=pdp.`id_product`
WHERE lp.id_mat_purc_list='" & id_list & "'
UNION
SELECT 'no' AS is_check,pdp.size,'' AS note,pdp.id_prod_demand_design,pdp.id_prod_demand_product,pdp.id_design,pdp.qty,dsg.design_display_name,dsg.design_code,pdp.prod_demand_number,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*pdp.qty) AS qty_order 
FROM (
	SELECT pd_dsg.id_prod_demand_design, pd_prd.`id_prod_demand_product`, pd_dsg.id_prod_demand, pd.prod_demand_number, pd_dsg.id_design, 
	pd_dsg.prod_demand_design_propose_price, pd_dsg.prod_demand_design_total_cost, pd_dsg.msrp,
	(SUM(pd_prd.prod_demand_product_qty)) AS qty
	,pc.size,pd_prd.id_product
	FROM  tb_prod_demand_design pd_dsg
	INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pd_dsg.id_prod_demand
	LEFT JOIN tb_prod_demand_product pd_prd ON pd_prd.id_prod_demand_design = pd_dsg.id_prod_demand_design 
	INNER JOIN 
	(
		SELECT pc.`id_product`,cd.`code_detail_name` AS size FROM 
		tb_m_product_code pc 
		INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail` AND cd.`id_code`='33'
	)pc ON pc.`id_product`=pd_prd.`id_product`
	WHERE pd.id_report_status = '6' AND pd_dsg.is_void=2
	GROUP BY pd_prd.id_prod_demand_product
	ORDER BY pd_prd.id_prod_demand_product DESC
) pdp
INNER JOIN tb_m_design dsg ON dsg.id_design=pdp.id_design
LEFT JOIN
(
	SELECT id_prod_demand_product FROM `tb_mat_purc_list_pd` plp
	INNER JOIN tb_mat_purc_list pl ON pl.`id_mat_purc_list`=plp.`id_mat_purc_list` AND pl.`is_cancel`=2 AND pl.id_mat_det='" & SLEMaterial.EditValue.ToString & "'
) pl ON pl.id_prod_demand_product=pdp.id_prod_demand_product
WHERE ISNULL(pl.id_prod_demand_product)
GROUP BY pdp.id_product
ORDER BY is_check DESC,id_prod_demand_design DESC"
        Else
            'normal
            query = "SELECT 'yes' AS is_check,lp.note AS note,lp.id_prod_demand_design,pdd.id_design,lp.total_qty_pd AS qty,dsg.design_display_name,dsg.design_code,pd.prod_demand_number,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*lp.total_qty_pd) AS qty_order 
FROM tb_mat_purc_list_pd lp
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=lp.id_prod_demand_design
INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
WHERE lp.id_mat_purc_list='" & id_list & "'
UNION
SELECT 'no' AS is_check,'' AS note,pdd.id_prod_demand_design,pdd.id_design,pdd.qty,dsg.design_display_name,dsg.design_code,pdd.prod_demand_number,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*pdd.qty) AS qty_order 
FROM (
	SELECT pd_dsg.id_prod_demand_design, pd_dsg.id_prod_demand, pd.prod_demand_number, pd_dsg.id_design, 
	pd_dsg.prod_demand_design_propose_price, pd_dsg.prod_demand_design_total_cost, pd_dsg.msrp,
	(SUM(pd_prd.prod_demand_product_qty)) AS qty
	FROM  tb_prod_demand_design pd_dsg
	INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pd_dsg.id_prod_demand
	LEFT JOIN tb_prod_demand_product pd_prd ON pd_prd.id_prod_demand_design = pd_dsg.id_prod_demand_design 
	WHERE pd.id_report_status = '6' AND pd_dsg.is_void=2
	GROUP BY pd_dsg.id_prod_demand_design
	ORDER BY pd_dsg.id_prod_demand_design DESC
) pdd
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
LEFT JOIN
(
	SELECT id_prod_demand_design FROM `tb_mat_purc_list_pd` plp
	INNER JOIN tb_mat_purc_list pl ON pl.`id_mat_purc_list`=plp.`id_mat_purc_list` AND pl.`is_cancel`=2 AND pl.id_mat_det='" & SLEMaterial.EditValue.ToString & "'
) pl ON pl.id_prod_demand_design=pdd.id_prod_demand_design
WHERE ISNULL(pl.id_prod_demand_design)
GROUP BY pdd.id_design
ORDER BY is_check DESC,id_prod_demand_design DESC"
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPD.DataSource = data
    End Sub

    Private Sub FormMatPurchasePD_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub BSetConsumption_Click(sender As Object, e As EventArgs) Handles BSetConsumption.Click
        If TEConsumption.EditValue <= 0 Then
            warningCustom("Please input consumption quantity.")
        Else
            load_pd()
            If SLEBreakDown.EditValue.ToString = "1" Then
                GridColumnSize.VisibleIndex = "4"
            Else
                GridColumnSize.VisibleIndex = "-1"
            End If
        End If
    End Sub

    Sub calculate()
        Dim total_qty As Decimal = 0.00
        Dim toleransi As Decimal = 0.00

        For i As Integer = 0 To GVPD.RowCount - 1
            total_qty += GVPD.GetRowCellValue(i, "qty_order")
        Next
        'calculate
        toleransi = TEToleransi.EditValue
        TETotal.EditValue = total_qty
        '
        TEToleransiAmount.EditValue = Math.Ceiling((toleransi / 100) * total_qty)
        TETotalAmount.EditValue = TETotal.EditValue + TEToleransiAmount.EditValue
    End Sub

    Private Sub BCalculate_Click(sender As Object, e As EventArgs) Handles BCalculate.Click
        set_calculate()
    End Sub

    Sub set_calculate()
        If BCalculate.Text = "Calculate" Then
            GVPD.ApplyFindFilter("")
            GVPD.ActiveFilterString = "[is_check] = 'yes'"
            calculate()
            '
            GridColumnCheck.Visible = False
            SLEMaterial.Enabled = False
            TEConsumption.Enabled = False
            BSetConsumption.Enabled = False
            TEToleransi.Enabled = False
            '
            SLEBreakDown.Enabled = False
            '
            GVPD.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
            '
            BCalculate.Text = "Unlock"
        ElseIf BCalculate.Text = "Unlock" Then
            GVPD.ActiveFilterString = ""
            '
            GridColumnCheck.Visible = True
            SLEMaterial.Enabled = True
            TEConsumption.Enabled = True
            BSetConsumption.Enabled = True
            TEToleransi.Enabled = True
            '
            SLEBreakDown.Enabled = True
            '
            GVPD.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default
            '
            BCalculate.Text = "Calculate"
        End If
    End Sub

    Private Sub SLEMaterial_EditValueChanged(sender As Object, e As EventArgs) Handles SLEMaterial.EditValueChanged
        Try
            If Not SLEMaterial.EditValue = Nothing Then
                TEUOM.Text = SLEMaterial.Properties.View.GetFocusedRowCellValue("uom").ToString
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim query As String = ""
        'cek first
        Dim already As Boolean = False
        Dim pd_note As String = ""

        If Not BCalculate.Text = "Unlock" Then
            warningCustom("Please press calculate")
        Else
            If id_list = "-1" Then
                'new
                For i As Integer = 0 To GVPD.RowCount - 1
                    Dim query_cek As String = "SELECT dsg.`design_code`,dsg.`design_display_name`,LPAD(l.`id_mat_purc`,6,'0') AS number FROM `tb_mat_purc_list_pd` lp
INNER JOIN `tb_mat_purc_list` l ON l.`id_mat_purc_list`=lp.`id_mat_purc_list`
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=lp.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
WHERE l.`is_cancel`=2 AND lp.`id_prod_demand_design`='" & GVPD.GetRowCellValue(i, "id_prod_demand_design").ToString & "'"
                    Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
                    If data_cek.Rows.Count > 0 Then
                        pd_note = data_cek.Rows(0)("design_code").ToString & " - " & data_cek.Rows(0)("design_display_name").ToString & " already listed on list no : " & data_cek.Rows(0)("number").ToString
                        already = False
                        Exit For
                    End If
                Next

                If already = True Then
                    warningCustom(pd_note)
                ElseIf GVPD.RowCount <= 0 Then
                    warningCustom("Please select at least 1 PD Design")
                Else
                    'header
                    query = "INSERT INTO tb_mat_purc_list(id_mat_det,created_by,created_date,qty_consumption,tolerance,note,is_breakdown) VALUES
('" & SLEMaterial.EditValue.ToString & "','" & id_user & "',NOW(),'" & decimalSQL(TEConsumption.EditValue.ToString) & "','" & decimalSQL(TEToleransi.EditValue.ToString) & "','" & addSlashes(MENote.Text) & "','" & SLEBreakDown.EditValue.ToString & "'); SELECT LAST_INSERT_ID()"
                    id_list = execute_query(query, 0, True, "", "", "", "")

                    'pd list
                    query = ""
                    For i As Integer = 0 To GVPD.RowCount - 1
                        If Not i = 0 Then
                            query += ","
                        End If

                        query += "('" & id_list & "','" & GVPD.GetRowCellValue(i, "id_prod_demand_design").ToString & "','" & GVPD.GetRowCellValue(i, "id_prod_demand_product").ToString & "','" & decimalSQL(GVPD.GetRowCellValue(i, "qty").ToString) & "','" & GVPD.GetRowCellValue(i, "note").ToString & "')"
                    Next

                    query = "INSERT INTO tb_mat_purc_list_pd(id_mat_purc_list,id_prod_demand_design,id_prod_demand_product,total_qty_pd,note) VALUES " & query
                    execute_non_query(query, True, "", "", "", "")

                    FormMatPurchase.load_list_mat_from_pd()
                    Close()
                End If
            Else
                'edit
                For i As Integer = 0 To GVPD.RowCount - 1
                    Dim query_cek As String = "SELECT dsg.`design_code`,dsg.`design_display_name`,LPAD(l.`id_mat_purc`,6,'0') AS number FROM `tb_mat_purc_list_pd` lp
INNER JOIN `tb_mat_purc_list` l ON l.`id_mat_purc_list`=lp.`id_mat_purc_list`
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=lp.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
WHERE l.`is_cancel`=2 AND lp.id_mat_purc_list='" & id_list & "' AND lp.`id_prod_demand_design`='" & GVPD.GetRowCellValue(i, "id_prod_demand_design").ToString & "'"
                    Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
                    If data_cek.Rows.Count > 0 Then
                        pd_note = data_cek.Rows(0)("design_code").ToString & " - " & data_cek.Rows(0)("design_display_name").ToString & " already listed on list no : " & data_cek.Rows(0)("number").ToString
                        already = False
                        Exit For
                    End If
                Next

                If already = True Then
                    warningCustom(pd_note)
                ElseIf GVPD.RowCount <= 0 Then
                    warningCustom("Please select at least 1 PD Design")
                Else
                    'header
                    query = "UPDATE tb_mat_purc_list SET id_mat_det='" & SLEMaterial.EditValue.ToString & "',created_by='" & id_user & "',created_date=NOW(),qty_consumption='" & decimalSQL(TEConsumption.EditValue.ToString) & "',tolerance='" & decimalSQL(TEToleransi.EditValue.ToString) & "',note='" & addSlashes(MENote.Text) & "',is_breakdow='" & SLEBreakDown.EditValue.ToString & "' WHERE id_mat_purc_list='" & id_list & "'"
                    execute_non_query(query, True, "", "", "", "")

                    'pd list
                    query = ""
                    For i As Integer = 0 To GVPD.RowCount - 1
                        If Not i = 0 Then
                            query += ","
                        End If

                        query += "('" & id_list & "','" & GVPD.GetRowCellValue(i, "id_prod_demand_design").ToString & "','" & GVPD.GetRowCellValue(i, "id_prod_demand_product").ToString & "','" & decimalSQL(GVPD.GetRowCellValue(i, "qty").ToString) & "','" & GVPD.GetRowCellValue(i, "note").ToString & "')"
                    Next

                    query = "DELETE FROM tb_mat_purc_list_pd WHERE id_mat_purc_list='" & id_list & "';INSERT INTO tb_mat_purc_list_pd(id_mat_purc_list,id_prod_demand_design,id_prod_demand_product,total_qty_pd,note) VALUES " & query
                    execute_non_query(query, True, "", "", "", "")

                    FormMatPurchase.load_list_mat_from_pd()
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to cancel this list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim is_ok As Boolean = False
            Dim q As String = "SELECT id_mat_purc,is_cancel FROM `tb_mat_purc_list` WHERE id_mat_purc_list='" & id_list & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("id_mat_purc").ToString = "" And dt.Rows(0)("is_cancel").ToString = "2" Then
                    is_ok = True
                End If
            End If
            '
            If is_ok Then
                q = "UPDATE tb_mat_purc_list SET is_cancel='1' WHERE id_mat_purc_list='" & id_list & "'"
                execute_non_query(q, True, "", "", "", "")
                '
                load_view()
                stopCustom("List canceled")
            Else
                stopCustom("Already cancelled or PO already created !")
            End If
        End If
    End Sub

    Private Sub BDuplicate_Click(sender As Object, e As EventArgs) Handles BDuplicate.Click
        FormMatPurchasePDDup.ShowDialog()
    End Sub

    Sub select_all()
        If GVPD.RowCount > 0 Then
            For i As Integer = 0 To ((GVPD.RowCount - 1) - GetGroupRowCount(GVPD))
                GVPD.SetRowCellValue(i, "is_select", "yes")
            Next
        End If
    End Sub

    Sub unselect_all()
        If GVPD.RowCount > 0 Then
            For i As Integer = 0 To ((GVPD.RowCount - 1) - GetGroupRowCount(GVPD))
                GVPD.SetRowCellValue(i, "is_select", "no")
            Next
        End If
    End Sub

    Private Sub SMView_Click(sender As Object, e As EventArgs) Handles SMView.Click
        select_all()
    End Sub

    Private Sub UnselectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem.Click
        unselect_all()
    End Sub
End Class