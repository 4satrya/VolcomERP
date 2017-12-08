Public Class FormFGBackupStockDet
    Public id_st_period As String = "-1"
    Public action As String = "ins"

    Private Sub FormFGBackupStockDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActiveControl = TxtDescription
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            Dim dt As DataTable = execute_query("SELECT DATE_SUB(DATE(NOW()),INTERVAL 1 DAY) AS `date_now` ", -1, True, "", "", "", "")
            DEStock.EditValue = dt.Rows(0)("date_now")
        ElseIf action = "upd" Then
            BtnOpenFileLoc.Visible = True
            BtnPrint.Visible = True
            BtnSave.Visible = False

            'header
            Dim st As New ClassStockTake()
            Dim query As String = st.queryMain("AND st.id_st_period=" + id_st_period + " ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtDescription.Text = data.Rows(0)("st_period_description").ToString
            DEStock.EditValue = data.Rows(0)("st_period_date")
            DECreated.EditValue = data.Rows(0)("st_period_created_date")

            'detail
            viewComp()
        End If
    End Sub

    Sub viewComp()
        Dim query As String = "SELECT c.id_comp, c.comp_number, c.comp_name, ('No') AS `is_select`, "
        If action = "upd" Then
            query += "st.qty_soh 
            FROM tb_m_comp c 
            INNER JOIN tb_st_period_det st ON st.id_comp = c.id_comp AND st.id_st_period='" + id_st_period + "' "
        ElseIf action = "ins" Then
            Dim date_until_selected As String = "1997-01-01"
            Try
                date_until_selected = DateTime.Parse(DEStock.EditValue.ToString).ToString("yyyy-MM-dd")
            Catch ex As Exception
            End Try
            query += " IFNULL(stc.qty,0) AS `qty_soh` 
            FROM tb_m_comp c 
            LEFT JOIN (
	            SELECT f.id_wh_drawer,
	            SUM(IF(f.id_stock_status=1, (IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)),0)) AS qty
	            FROM tb_storage_fg f 
	            WHERE DATE(f.storage_product_datetime)<=DATE('" + date_until_selected + "')
	            GROUP BY f.id_wh_drawer
            ) stc ON stc.id_wh_drawer = c.id_drawer_def "
        End If
        query += "WHERE (c.id_comp_cat=5 Or c.id_comp_cat=6)
        ORDER BY c.comp_number  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
    End Sub

    Private Sub DEStock_EditValueChanged(sender As Object, e As EventArgs) Handles DEStock.EditValueChanged
        MsgBox(action)
        viewComp()
    End Sub

    Private Sub CESelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelectAll.CheckedChanged
        If GVData.RowCount > 0 Then
            Dim cek As String = CESelectAll.EditValue.ToString
            For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                If cek Then
                    GVData.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVData.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to generate database for these data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            'insert head
            Dim st_period_date As String = DateTime.Parse(DEStock.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim st_period_description As String = addSlashes(TxtDescription.Text)
            Dim query_head As String = "INSERT INTO tb_st_period(st_period_date, st_period_created_date, st_period_description) VALUES('" + st_period_date + "', DATE(NOW()), '" + st_period_description + "'); SELECT LAST_INSERT_ID(); "
            id_st_period = execute_query(query_head, 0, True, "", "", "", "")

            'insert detail
            Dim query_det As String = "INSERT INTO tb_st_period_det(id_st_period, id_comp, qty_soh) VALUES "
            Dim jum_i As Integer = 0
            Dim comp As String = ""
            For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                If i > 0 Then
                    query_det += ", "
                    comp += "OR "
                End If
                query_det += "('" + id_st_period + "', '" + GVData.GetRowCellValue(i, "id_comp").ToString + "', '" + decimalSQL(GVData.GetRowCellValue(i, "qty_soh").ToString) + "') "
                comp += "c.id_comp='" + GVData.GetRowCellValue(i, "id_comp").ToString + "' "
                jum_i += 1
            Next
            If jum_i > 0 Then
                execute_non_query(query_det, True, "", "", "", "")
            End If

            'connection string
            Dim constring As String = "server=" + app_host + ";user=" + app_username + ";pwd=" + app_password + ";database=" + app_database + ";"
            Dim path_root As String = Application.StartupPath + "\download"
            Dim fileName As String = "stp_" + id_st_period + ".sql"
            Dim file As String = IO.Path.Combine(path_root, fileName)
            '-- company/store/wh
            Dim dic As New Dictionary(Of String, String)()
            dic.Add("tb_m_comp", "SELECT * FROM tb_m_comp c WHERE (" + comp + ") ")
            '-- code
            dic.Add("tb_m_code", "SELECT c.* FROM tb_m_code c 
            INNER JOIN tb_template_code_det tc ON tc.id_code = c.id_code AND (tc.id_template_code=7 OR tc.id_template_code=8 OR tc.id_template_code=12 OR tc.id_template_code=13)
            ORDER BY c.id_code ASC ")
            dic.Add("tb_m_code_detail", "SELECT cd.* 
            FROM tb_m_code c 
            INNER JOIN tb_template_code_det tc ON tc.id_code = c.id_code AND (tc.id_template_code=7 OR tc.id_template_code=8 OR tc.id_template_code=12 OR tc.id_template_code=13)
            INNER JOIN tb_m_code_detail cd ON cd.id_code = c.id_code
            ORDER BY cd.id_code_detail ASC ")
            '-- range & season
            dic.Add("tb_range", "SELECT r.* FROM tb_range r ORDER BY r.id_range ASC ")
            dic.Add("tb_season", "SELECT * FROM tb_season s ORDER BY s.id_season ASC ")
            'dump



            action = "upd"
            actionLoad()
        End If
    End Sub

    Private Sub XTCDetail_Click(sender As Object, e As EventArgs) Handles XTCDetail.Click

    End Sub
End Class