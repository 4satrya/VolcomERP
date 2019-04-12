Public Class FormFGLineListQuickUpdDel
    Private Sub FormFGLineListQuickUpdDel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDel()
        viewRetCode()
        viewData()
    End Sub

    Private Sub FormFGLineListQuickUpdDel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewDel()
        Dim query As String = "SELECT * FROM tb_season_delivery WHERE id_season='" + FormFGLineList.SLESeason.EditValue.ToString + "' ORDER BY id_delivery ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepoDel.DataSource = Nothing
        RepoDel.DataSource = data
        RepoDel.DisplayMember = "delivery"
        RepoDel.ValueMember = "id_delivery"
    End Sub

    Sub viewRetCode()
        Dim query As String = "SELECT * FROM tb_lookup_ret_code ORDER BY id_ret_code ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepoRetCode.DataSource = Nothing
        RepoRetCode.DataSource = data
        RepoRetCode.DisplayMember = "ret_code"
        RepoRetCode.ValueMember = "id_ret_code"
    End Sub

    Sub viewData()
        Dim query As String = "SELECT d.id_design, d.design_code AS `code`, d.design_display_name AS `name`, 
        d.id_delivery, del.delivery, NULL AS `id_delivery_new`,
        d.id_ret_code , ret.ret_code, NULL AS `id_ret_code_new`,
        cls.class, dv.division
        FROM tb_m_design d
        INNER JOIN tb_season_delivery del ON del.id_delivery = d.id_delivery
        INNER JOIN tb_lookup_ret_code ret ON ret.id_ret_code = d.id_ret_code
        LEFT JOIN (
            SELECT d.id_design, cls.id_code_detail AS `id_class`, cls.display_name AS `class` 
            FROM tb_m_design d
            INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
            INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=30
            GROUP BY d.id_design
        ) cls ON cls.id_design = d.id_design
        LEFT JOIN (
            SELECT d.id_design, cls.id_code_detail AS `id_class`, cls.display_name AS `division` 
            FROM tb_m_design d
            INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
            INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=32
            GROUP BY d.id_design
        ) dv ON dv.id_design = d.id_design
        WHERE d.id_season='" + FormFGLineList.SLESeason.EditValue.ToString + "'
        ORDER BY d.design_display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
    End Sub

    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        'filter save
        Dim fs As String = GVData.ActiveFilterString

        makeSafeGV(GVData)
        GVData.ActiveFilterString = "Not IsNullOrEmpty([id_delivery_new]) OR Not IsNullOrEmpty([id_ret_code_new])"
        If GVData.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            For i As Integer = 0 To GVData.RowCount - 1
                Dim id_design As String = GVData.GetRowCellValue(i, "id_design").ToString

                'new
                Dim id_delivery_new As String = GVData.GetRowCellValue(i, "id_delivery_new").ToString
                Dim id_ret_code_new As String = GVData.GetRowCellValue(i, "id_ret_code_new").ToString

                'old
                Dim id_delivery_old As String = GVData.GetRowCellValue(i, "id_delivery").ToString
                Dim id_ret_code_old As String = GVData.GetRowCellValue(i, "id_ret_code").ToString
                If id_ret_code_old = "" Then
                    id_ret_code_old = "0"
                End If

                Dim id_del As String = ""
                Dim id_ret As String = ""
                If id_delivery_new = "" Then
                    id_del = id_delivery_old
                Else
                    id_del = id_delivery_new
                End If
                If id_ret_code_new = "" Then
                    id_ret = id_ret_code_old
                Else
                    id_ret = id_ret_code_new
                End If

                Dim query As String = "UPDATE tb_m_design SET id_delivery=" + id_del + ", id_ret_code=" + id_ret + " 
                WHERE id_design ='" + id_design + "' "
                execute_non_query(query, True, "", "", "", "")
            Next

            FormFGLineList.viewLineList()
            Cursor = Cursors.Default
            Close()
        Else
            stopCustom("No data selected")
            GVData.ActiveFilterString = fs
        End If
    End Sub

    Private Sub BtnDiscardDel_Click(sender As Object, e As EventArgs) Handles BtnDiscardDel.Click

    End Sub

    Private Sub BtnDiscardRetCode_Click(sender As Object, e As EventArgs) Handles BtnDiscardRetCode.Click

    End Sub

    Private Sub BtnDiscardDel_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BtnDiscardDel.ButtonClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            GVData.SetFocusedRowCellValue("id_delivery_new", Nothing)
        End If
    End Sub

    Private Sub BtnDiscardRetCode_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BtnDiscardRetCode.ButtonClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            GVData.SetFocusedRowCellValue("id_ret_code_new", Nothing)
        End If

    End Sub
End Class