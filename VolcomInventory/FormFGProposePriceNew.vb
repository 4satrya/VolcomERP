Public Class FormFGProposePriceNew
    Dim markup_local As Decimal = 0.00
    Dim markup_import As Decimal = 0.00

    Private Sub FormFGProposePriceNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtMarkup.EditValue = 0.00
        viewType()
        viewSeason()
        view_division_fg()
        view_source_fg()

        Dim qm As String = "SELECT o.markup_import, o.markup_local FROM tb_opt o "
        Dim dm As DataTable = execute_query(qm, -1, True, "", "", "", "")
        markup_local = dm.Rows(0)("markup_local")
        markup_import = dm.Rows(0)("markup_import")
        getMarkup()
    End Sub

    Sub viewType()
        Dim query As String = "SELECT * FROM tb_lookup_pp_type typ ORDER BY typ.id_pp_type ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEType, query, 0, "pp_type", "id_pp_type")
    End Sub


    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub FormFGProposePriceNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
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

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        If LESource.EditValue = Nothing Then
            warningCustom("Please select product source first!")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create new propose price ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_season As String = SLESeason.EditValue.ToString
                Dim id_source As String = LESource.EditValue.ToString
                Dim id_division As String = LEDivision.EditValue.ToString
                Dim fg_propose_price_note As String = addSlashes(MENote.Text)
                Dim markup_target As String = decimalSQL(TxtMarkup.EditValue.ToString)
                Dim id_pp_type As String = LEType.EditValue.ToString

                Dim query As String = "INSERT INTO tb_fg_propose_price(id_season, fg_propose_price_number, fg_propose_price_date, fg_propose_price_note, id_report_status, id_source, id_division, markup_target, id_pp_type) 
                VALUES('" + id_season + "', gen_pp_number('" + id_season + "', '" + id_division + "'), NOW(), '" + fg_propose_price_note + "', '1', '" + id_source + "', '" + id_division + "', '" + markup_target + "', '" + id_pp_type + "'); SELECT LAST_INSERT_ID(); "
                Dim id As String = execute_query(query, 0, True, "", "", "", "")
                FormFGProposePrice.viewPropose()
                FormFGProposePrice.GVFGPropose.FocusedRowHandle = find_row(FormFGProposePrice.GVFGPropose, "id_fg_propose_price", id)
                Close()

                'detail
                FormFGProposePriceDetail.id = id
                FormFGProposePriceDetail.ShowDialog()
            End If
        End If
    End Sub

    Private Sub LESource_EditValueChanged(sender As Object, e As EventArgs) Handles LESource.EditValueChanged
        getMarkup()
    End Sub

    Sub getMarkup()
        Dim id_src As String = "0"
        Try
            id_src = LESource.EditValue.ToString
        Catch ex As Exception
        End Try
        If id_src = "205" Then
            TxtMarkup.EditValue = markup_local
        ElseIf id_src = "206" Then
            TxtMarkup.EditValue = markup_import
        Else
            TxtMarkup.EditValue = 0.00
        End If
    End Sub
End Class