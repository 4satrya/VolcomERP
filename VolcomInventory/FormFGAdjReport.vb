Public Class FormFGAdjReport
    Public is_out As Boolean = False

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = ""
        If is_out Then 'adj out
            query = "SELECT o.id_adj_out_fg AS `id`, o.adj_out_fg_number AS `number`, o.adj_out_fg_date AS `date`, c.comp_number AS `acc_no`, c.comp_name AS `acc_name`, CONCAT(c.comp_number,' - ', c.comp_name) AS `acc`,
            od.adj_out_fg_det_note AS `note`, SUM(od.adj_out_fg_det_qty) AS `qty` 
            FROM tb_adj_out_fg o
            INNER JOIN tb_adj_out_fg_det od ON od.id_adj_out_fg = o.id_adj_out_fg
            INNER JOIN tb_m_comp c ON c.id_drawer_def = od.id_wh_drawer
            WHERE (o.adj_out_fg_date>='" + date_from_selected + "' AND o.adj_out_fg_date<='" + date_until_selected + "')
            GROUP BY o.id_adj_out_fg, od.id_wh_drawer "
        Else
            query = "SELECT i.id_adj_in_fg AS `id`, i.adj_in_fg_number AS `number`, i.adj_in_fg_date AS `date`, c.comp_number AS `acc_no`, c.comp_name AS `acc_name`, CONCAT(c.comp_number,' - ', c.comp_name) AS `acc`,
            id.adj_in_fg_det_note AS `note`, SUM(id.adj_in_fg_det_qty) AS `qty` 
            FROM tb_adj_in_fg i
            INNER JOIN tb_adj_in_fg_det id ON id.id_adj_in_fg = i.id_adj_in_fg
            INNER JOIN tb_m_comp c ON c.id_drawer_def = id.id_wh_drawer
            WHERE (i.adj_in_fg_date>='" + date_from_selected + "' AND i.adj_in_fg_date<='" + date_until_selected + "')
            GROUP BY i.id_adj_in_fg, id.id_wh_drawer "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub FormFGAdjReport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormFGAdjReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
    End Sub

    Private Sub DEFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntil.Focus()
        End If
    End Sub

    Private Sub DEUntil_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntil.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnView.Focus()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCData, "Period :" + DEFrom.Text + " - " + DEUntil.Text)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class