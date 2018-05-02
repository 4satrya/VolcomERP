Public Class FormFGLineListPrepPrice
    Public id_type As String = "-1"
    Public id_season As String = "-1"

    Private Sub FormFGLineListPrepPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDesign()
    End Sub

    Sub viewDesign()
        Dim query As String = "SELECT dsg.design_display_name AS `name`, det.color, dv.division, pd_dsg.id_prod_demand_design AS `id`, dsg.design_code as `code`, pd_dsg.prod_demand_design_propose_price AS `est_price`, "
        query += "pd_dsg.rate_current, pd_dsg.msrp, dsg.id_delivery, del.delivery, del.delivery_date, dsg.id_ret_code, rc.ret_code, rc.ret_date, dsg.design_eos "
        query += "FROM tb_m_design dsg "
        query += "LEFT JOIN tb_season_delivery del ON del.id_delivery = dsg.id_delivery "
        query += "LEFT JOIN tb_lookup_ret_code rc ON rc.id_ret_code = dsg.id_ret_code "
        query += "INNER JOIN tb_prod_demand_design pd_dsg ON pd_dsg.id_prod_demand_design = "
        If id_type = "1" Then
            query += "id_prod_demand_design_line "
        ElseIf id_type = "2" Then
            query += "id_prod_demand_design_line_upd "
        ElseIf id_type = "3" Then
            query += "id_prod_demand_design_line_final "
        End If
        query += "Left Join( "
        query += "Select b.code_detail_name As color, a.id_design FROM tb_m_design_code a "
        query += "INNER Join tb_m_code_detail b ON a.id_code_detail = b.id_code_detail And b.id_code = '14' "
        query += "GROUP BY a.id_design "
        query += ") det ON det.id_design = dsg.id_design "
        query += "Left Join( "
        query += "Select b.code_detail_name As division, a.id_design FROM tb_m_design_code a "
        query += "INNER Join tb_m_code_detail b ON a.id_code_detail = b.id_code_detail And b.id_code = '32' "
        query += "GROUP BY a.id_design "
        query += ") dv ON dv.id_design = dsg.id_design "
        query += "WHERE dsg.id_season = '" + id_season + "' AND dsg.id_active=1 "
        query += "ORDER BY dsg.id_design ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        Cursor = Cursors.WaitCursor
        'export excel
        Dim printableComponentLink1 As New DevExpress.XtraPrinting.PrintableComponentLink(New DevExpress.XtraPrinting.PrintingSystem())
        Dim path_root As String = Application.StartupPath & "\download\"
        'create directory if not exist
        If Not IO.Directory.Exists(path_root) Then
            System.IO.Directory.CreateDirectory(path_root)
        End If
        Dim fileName As String = "llprice_" + id_season + id_type + ".xls"
        Dim exp As String = IO.Path.Combine(path_root, fileName)
        Dim opt As DevExpress.XtraPrinting.XlsExportOptions = New DevExpress.XtraPrinting.XlsExportOptions()
        opt.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Value
        printableComponentLink1.Component = GCData
        printableComponentLink1.CreateDocument()
        printableComponentLink1.ExportToXls(exp, opt)
        Process.Start(exp)
        Cursor = Cursors.Default
    End Sub
End Class