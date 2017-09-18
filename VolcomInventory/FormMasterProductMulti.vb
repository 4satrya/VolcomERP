Public Class FormMasterProductMulti 
    Public id_popup As String = "-1"

    Private Sub FormMasterProductMulti_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub view_code_detail()
        Dim id_code_par As String = get_setup_field("id_code_product_size")
        Dim data As DataTable = execute_query("SELECT id_code_detail,code,display_name,code_detail_name, ('No') As `is_select` FROM tb_m_code_detail WHERE id_code='" & id_code_par & "' ORDER BY code ASC", -1, True, "", "", "", "")
        GCCodeDetail.DataSource = data
    End Sub

    Private Sub FormMasterProductMulti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_code_detail()
    End Sub

    Private Sub CheckEdit1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEdit1.CheckedChanged
        If GVCodeDetail.RowCount > 0 Then
            Dim cek As String = CheckEdit1.EditValue.ToString
            For i As Integer = 0 To ((GVCodeDetail.RowCount - 1) - GetGroupRowCount(GVCodeDetail))
                If cek Then
                    GVCodeDetail.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVCodeDetail.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Cursor = Cursors.WaitCursor
        Dim jum_tot As Integer = 0
        Dim cond_same As Boolean = False
        Dim string_same As String = "-1"
        Dim id_design_same As String = "-1"
        Dim idx_same As Integer = 0
        For i As Integer = 0 To ((GVCodeDetail.RowCount - 1) - GetGroupRowCount(GVCodeDetail))
            If GVCodeDetail.GetRowCellValue(i, "is_select") = "Yes" Then
                jum_tot += 1
                For j As Integer = 0 To ((FormMasterDesignSingle.GVProduct.RowCount - 1) - GetGroupRowCount(FormMasterDesignSingle.GVProduct))
                    If FormMasterDesignSingle.GVProduct.GetRowCellValue(j, "Size").ToString = GVCodeDetail.GetRowCellValue(i, "display_name").ToString Then
                        string_same = "Size : " + GVCodeDetail.GetRowCellValue(i, "display_name").ToString + ", already exist. "
                        idx_same = i
                        cond_same = True
                        Exit For
                    End If
                Next
               
                If cond_same Then
                    Exit For
                End If
            End If
        Next

        Dim id_str As String = ""
        Dim jum_str As Integer = 0
        Dim name As String = ""
        Dim design_code As String = ""
        If FormMasterDesignSingle.id_pop_up = "3" Then 'non MD
            name = addSlashes(FormMasterDesignSingle.TEDisplayNameNonMD.Text)
            design_code = addSlashes(FormMasterDesignSingle.TECodeNonMD.Text)
        Else 'MD
            name = addSlashes(FormMasterDesignSingle.TEDisplayName.Text)
            design_code = addSlashes(FormMasterDesignSingle.TECode.Text)
        End If
        If jum_tot > 0 Then
            If cond_same Then
                stopCustom(string_same)
                GVCodeDetail.FocusedRowHandle = idx_same
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to choose size?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor

                    'prepare query
                    Dim query_ins As String = ""
                    For l As Integer = 0 To ((GVCodeDetail.RowCount - 1) - GetGroupRowCount(GVCodeDetail))
                        If GVCodeDetail.GetRowCellValue(l, "is_select") = "Yes" Then
                            If jum_str = 0 Then
                                query_ins += "BEGIN; "
                                query_ins += "SET @my_id=NULL; "
                            End If
                            query_ins += "INSERT INTO tb_m_product(id_design, product_display_name, product_name, product_code, product_full_code, product_ean_code, inv_min_stock, inv_max_stock, id_method, order_min, order_max) VALUES "
                            query_ins += "('" + FormMasterDesignSingle.id_design + "', '" + name + "', '" + name + "', '" + GVCodeDetail.GetRowCellValue(l, "code").ToString + "', '" + design_code + GVCodeDetail.GetRowCellValue(l, "code").ToString + "', '-', 0.00, 0.00, '1', 0.00, 0.00); "
                            query_ins += "SET @my_id=LAST_INSERT_ID(); "
                            query_ins += "CALL generate_vendor_code('" + FormMasterDesignSingle.id_range_par + "', @my_id); "
                            query_ins += "CALL ins_line_list_alloc('" + FormMasterDesignSingle.id_design + "', @my_id); "
                            query_ins += "INSERT INTO tb_m_product_code(id_product, id_code_detail) VALUES(@my_id, '" + GVCodeDetail.GetRowCellValue(l, "id_code_detail").ToString + "'); "
                            jum_str += 1
                        End If
                    Next
                    If jum_str > 0 Then
                        query_ins += "COMMIT; "
                    End If
                    execute_non_query(query_ins, True, "", "", "", "")
                    FormMasterDesignSingle.view_product(FormMasterDesignSingle.id_design)
                    FormMasterDesignSingle.loadLineList(FormMasterDesignSingle.id_prod_demand_design_active)

                    'update design
                    Dim stt As New ClassDesign
                    stt.updatedTime(FormMasterDesignSingle.id_design)

                    Close()
                    Cursor = Cursors.Default
                End If
            End If
        Else
            stopCustom("Nothing item selected!")
        End If


        Cursor = Cursors.Default
    End Sub
End Class