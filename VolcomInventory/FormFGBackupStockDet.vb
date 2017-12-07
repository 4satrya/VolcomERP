Public Class FormFGBackupStockDet
    Public id_st_period As String = "-1"
    Public action As String = ""

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
            XTPDetailStock.PageVisible = True

            'header
            Dim st As New ClassStockTake()
            Dim query As String = st.queryMain("AND st.id_st_period=" + id_st_period + " ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtDescription.Text = data.Rows(0)("st_period_description").ToString
            DEStock.EditValue = data.Rows(0)("st_period_date")
            DECreated.EditValue = data.Rows(0)("st_period_created_date")

            'detail
            viewComp()
            viewDetailStock()
        End If
    End Sub

    Sub viewComp()
        If action = "ins" Then
            Dim date_until_selected As String = "1997-01-01"
            Try
                date_until_selected = DateTime.Parse(DEStock.EditValue.ToString).ToString("yyyy-MM-dd")
            Catch ex As Exception
            End Try
            Dim query As String = "SELECT c.id_comp, c.comp_number, c.comp_name, IFNULL(stc.qty,0) AS `qty_soh` ,('No') AS `is_select`
            FROM tb_m_comp c
            LEFT JOIN (
	            SELECT f.id_wh_drawer,
	            SUM(IF(f.id_stock_status=1, (IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)),0)) AS qty
	            FROM tb_storage_fg f 
	            WHERE DATE(f.storage_product_datetime)<=DATE('" + date_until_selected + "')
	            GROUP BY f.id_wh_drawer
            ) stc ON stc.id_wh_drawer = c.id_drawer_def
            WHERE (c.id_comp_cat=5 OR c.id_comp_cat=6)
            ORDER BY c.comp_number  "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCData.DataSource = data
        ElseIf action = "upd" Then

        End If
    End Sub

    Sub viewDetailStock()

    End Sub

    Private Sub DEStock_EditValueChanged(sender As Object, e As EventArgs) Handles DEStock.EditValueChanged
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

        End If
    End Sub
End Class