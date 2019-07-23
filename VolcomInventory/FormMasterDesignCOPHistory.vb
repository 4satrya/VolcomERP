Public Class FormMasterDesignCOPHistory
    Public id_class As String = "0"
    Public id_source As String = "0"

    Private Sub FormMasterDesignCOPHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_class()
        view_source()

        SLEClass.EditValue = id_class
        SLESource.EditValue = id_source
        '
        load_history()
    End Sub

    Sub load_history()
        Dim q_where As String = ""
        Dim query As String = ""

        If Not SLEClass.EditValue.ToString = "-1" Then
            q_where += " And IFNULL(dcc.id_code_detail, 0) = " & SLEClass.EditValue.ToString
        End If

        If Not SLESource.EditValue.ToString = "-1" Then
            q_where += " AND IFNULL(dcs.id_code_detail,0)=" & SLESource.EditValue.ToString
        End If

        query = "Select dsg.`id_design`,dsg.`design_code`,dsg.`design_display_name`,(dsg.`prod_order_cop_pd`-dsg.`prod_order_cop_pd_addcost`) As cop_pd
,dsg.`prod_order_cop_pd_addcost` AS cop_pd_addcost,dsg.`design_code`,dsg.`design_display_name`
,IFNULL(dcs.id_code_detail,0) AS id_code_class,IFNULL(dcc.id_code_detail,0) AS id_code_source
,IFNULL(dcs.`display_name`,'Not assigned') AS source,IFNULL(dcc.`display_name`,'Not assigned') AS class 
,c.comp_name,ssn.`season`
FROM tb_m_design dsg
LEFT JOIN 
(
	SELECT dcs.`id_design`,dcs.`id_code_detail`,cds.`display_name` FROM 
	tb_m_design_code dcs
	INNER JOIN tb_m_code_detail cds ON cds.`id_code_detail`=dcs.`id_code_detail` AND cds.`id_code`='5'
) dcs ON dcs.`id_design`=dsg.`id_design`
LEFT JOIN 
(
	SELECT dcs.`id_design`,dcs.`id_code_detail`,cds.`display_name` FROM 
	tb_m_design_code dcs
	INNER JOIN tb_m_code_detail cds ON cds.`id_code_detail`=dcs.`id_code_detail` AND cds.`id_code`='30'
) dcc ON dcc.`id_design`=dsg.`id_design`
LEFT JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=dsg.`prod_order_cop_pd_vendor`
LEFT JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN tb_season_delivery del ON del.`id_delivery`=dsg.`id_delivery`
INNER JOIN tb_season ssn ON ssn.`id_season`=del.`id_season`
WHERE dsg.`prod_order_cop_pd`>0" & q_where

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCOPHistory.DataSource = data
        GVCOPHistory.BestFitColumns()
    End Sub

    Sub view_class()
        Dim query As String = "SELECT '-1' AS id_code_detail,'ALL' AS code_detail_name
UNION
SELECT '0' AS id_code_detail,'Not Assigned' AS code_detail_name
UNION
SELECT id_code_detail,code_detail_name FROM `tb_m_code_detail` cd
WHERE cd.id_code='30'"
        viewSearchLookupQuery(SLEClass, query, "id_code_detail", "code_detail_name", "id_code_detail")
    End Sub

    Sub view_source()
        Dim query As String = "SELECT '-1' AS id_code_detail,'ALL' AS code_detail_name
UNION
SELECT '0' AS id_code_detail,'Not Assigned' AS code_detail_name
UNION
SELECT id_code_detail,code_detail_name FROM `tb_m_code_detail` cd
WHERE cd.id_code='5'"
        viewSearchLookupQuery(SLESource, query, "id_code_detail", "code_detail_name", "id_code_detail")
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        load_history()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        print(GCCOPHistory, "COP History (Class : " & SLEClass.Text & ", Source : " & SLESource.Text & ")")
    End Sub
End Class