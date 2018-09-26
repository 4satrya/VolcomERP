Public Class FormProdDemandRevNew
    Dim id_prod_demand As String = "-1"
    Private Sub FormProdDemandRevNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
        view_division_fg(LESampleDivision)
    End Sub

    Sub view_division_fg(ByVal SLE As DevExpress.XtraEditors.LookUpEdit)
        Dim id_code As String = get_setup_field("id_code_fg_division")
        Dim query As String = "SELECT id_code_detail,code_detail_name,display_name FROM tb_m_code_detail a WHERE a.id_code='" + id_code + "' ORDER BY a.id_code_detail "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(SLE, query, 0, "display_name", "id_code_detail")
    End Sub

    Sub viewSeason()
        Dim query As String = "(SELECT a.id_season,a.season,b.range AS `range` FROM tb_season a 
                                INNER JOIN tb_range b ON a.id_range = b.id_range 
                                ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim cond_view As String = "AND pd.id_season=" + SLESeason.EditValue.ToString + " AND pd.id_division=" + LESampleDivision.EditValue.ToString + " AND pd.id_report_status=6 "
        Dim query_c As ClassProdDemand = New ClassProdDemand()
        Dim query As String = query_c.queryMain(cond_view, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdDemand.DataSource = data
        If GVProdDemand.RowCount > 0 Then
            GVProdDemand.FocusedRowHandle = 0
        End If
        focusrow()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormProdDemandRevNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        viewData()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Cursor = Cursors.WaitCursor
        Dim cond_process As Boolean = False
        Dim query_cek As String = "SELECT * FROM tb_prod_demand_rev r WHERE r.id_prod_demand=" + id_prod_demand + " AND r.id_report_status<5 "
        Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
        If data_cek.Rows.Count > 0 Then
            cond_process = True
        End If

        If id_prod_demand = "-1" Then
            stopCustom("Please select PD")
        ElseIf MENote.Text = "" Then
            stopCustom("Note can't blank")
        ElseIf cond_process Then
            stopCustom("Cannot make revisions. PD is being processed")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create PD revison for " + TxtProdDemandNumber.Text + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim note As String = addSlashes(MENote.Text)
                Dim query As String = "INSERT INTO tb_prod_demand_rev(id_prod_demand, rev_count, id_report_status, created_date,note) 
                VALUES('" + id_prod_demand + "', getRevPD(" + id_prod_demand + "),1, NOW(),'" + note + "'); SELECT LAST_INSERT_ID(); "
                Dim id As String = execute_query(query, 0, True, "", "", "", "")
                FormProdDemandRev.viewData()
                FormProdDemandRev.GVData.FocusedRowHandle = find_row(FormProdDemandRev.GVData, "id_prod_demand_rev", id)
                Close()
                FormProdDemandRevDet.id = id
                FormProdDemandRevDet.ShowDialog()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub GVProdDemand_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdDemand.FocusedRowChanged
        focusrow()
    End Sub

    Private Sub GVProdDemand_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVProdDemand.ColumnFilterChanged
        focusrow()
    End Sub

    Sub focusrow()
        If GVProdDemand.RowCount > 0 And GVProdDemand.FocusedRowHandle >= 0 Then
            id_prod_demand = GVProdDemand.GetFocusedRowCellValue("id_prod_demand").ToString
            TxtProdDemandNumber.Text = GVProdDemand.GetFocusedRowCellValue("prod_demand_number").ToString
        Else
            id_prod_demand = "-1"
            TxtProdDemandNumber.Text = ""
        End If
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If GVProdDemand.RowCount > 0 And GVProdDemand.FocusedRowHandle >= 0 Then
            Dim p As New ClassShowPopUp()
            p.id_report = GVProdDemand.GetFocusedRowCellValue("id_prod_demand").ToString
            Dim id_pd_kind As String = GVProdDemand.GetFocusedRowCellValue("id_pd_kind").ToString
            Dim rmt As String = ""
            If id_pd_kind = "1" Then
                rmt = "9"
            ElseIf id_pd_kind = "2" Then
                rmt = "80"
            Else
                rmt = "81"
            End If
            p.report_mark_type = rmt
            p.show()
        End If
        Cursor = Cursors.Default
    End Sub
End Class