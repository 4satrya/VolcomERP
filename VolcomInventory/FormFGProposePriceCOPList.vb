Public Class FormFGProposePriceCOPList
    Private Sub FormFGProposePriceCOPList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
        view_division_fg()
        view_source_fg()
    End Sub

    Private Sub FormFGProposePriceCOPList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Sub viewSeason()
        Dim query As String = "(SELECT a.id_season, a.season, b.range AS `range` FROM tb_season a 
                                INNER JOIN tb_range b ON a.id_range = b.id_range 
                                ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub view_division_fg()
        Dim id_code As String = get_setup_field("id_code_fg_division")
        Dim query As String = "SELECT id_code_detail,code_detail_name,display_name 
        FROM tb_m_code_detail a WHERE a.id_code='" + id_code + "' ORDER BY id_code_detail ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEDivision, query, 0, "display_name", "id_code_detail")
    End Sub

    Sub view_source_fg()
        Dim id_code As String = get_setup_field("id_code_fg_source")
        Dim query As String = "SELECT (id_code_detail) AS id_source, (code_detail_name) AS source, display_name FROM tb_m_code_detail a WHERE a.id_code='" + id_code + "' HAVING source<>'-' ORDER BY a.id_code_detail "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LESource, query, 0, "display_name", "id_source")
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim pp As New ClassFGProposePrice()
        Dim data As DataTable = pp.dataCOPList(SLESeason.EditValue.ToString, LESource.EditValue.ToString, LEDivision.EditValue.ToString, False)
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewList_Click(sender As Object, e As EventArgs) Handles BtnViewList.Click
        viewData()
    End Sub

    Private Sub SLESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLESeason.EditValueChanged
        GCData.DataSource = Nothing
    End Sub

    Private Sub LESource_EditValueChanged(sender As Object, e As EventArgs) Handles LESource.EditValueChanged
        GCData.DataSource = Nothing
    End Sub

    Private Sub LEDivision_EditValueChanged(sender As Object, e As EventArgs) Handles LEDivision.EditValueChanged
        GCData.DataSource = Nothing
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw(GCData, "")
    End Sub
End Class