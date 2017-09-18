Public Class FormCodeTemplateEdit 
    Public id_template_code As String = "-1"
    Public id_pop_up As String = "-1"

    Private Sub FormCodeTemplateEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_code()
    End Sub

    Sub view_code()
        Dim query As String = "SELECT codex.id_code,codex.code_name,codex.description,codex.is_include_name,codex.is_include_code "
        query += " FROM tb_template_code_det tc_d"
        query += " LEFT JOIN tb_m_code codex ON tc_d.id_code=codex.id_code"
        query += " WHERE tc_d.id_template_code='" & id_template_code & "'"
        query += " ORDER BY codex.code_name"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCode.DataSource = data
        If data.Rows.Count > 0 Then
            XTPCodeDet.PageEnabled = True
            view_code_detail(GVCode.GetFocusedRowCellDisplayText("id_code").ToString)
            LabelCodeContent.Text = GVCode.GetFocusedRowCellDisplayText("code_name").ToString
        Else
            XTPCodeDet.PageEnabled = False
        End If
    End Sub
    Sub view_code_detail(ByVal id_code As String)
        Dim data As DataTable = execute_query("SELECT id_code_detail,code,display_name,code_detail_name FROM tb_m_code_detail WHERE id_code='" & id_code & "' ORDER BY code", -1, True, "", "", "", "")
        GCCodeDetail.DataSource = data
        check_menu()
    End Sub
    Sub check_menu()
        If GVCodeDetail.RowCount < 1 Then
            'hide all except new
            BAdd.Visible = True
            BEdit.Visible = False
            BDelete.Visible = False
            '
        Else
            'show all
            BAdd.Visible = True
            BEdit.Visible = True
            BDelete.Visible = True
        End If
    End Sub

    Private Sub GVCode_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVCode.FocusedRowChanged
        If GVCode.RowCount > 0 Then
            view_code_detail(GVCode.GetFocusedRowCellDisplayText("id_code").ToString)
            LabelCodeContent.Text = GVCode.GetFocusedRowCellDisplayText("code_name").ToString
        Else
            XTPCodeDet.PageEnabled = False
        End If
    End Sub

    Private Sub BAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdd.Click
        FormMasterCodeDetSingle.id_code_det = "-1"
        FormMasterCodeDetSingle.id_pop_up = id_pop_up
        FormMasterCodeDetSingle.id_code = GVCode.GetFocusedRowCellDisplayText("id_code").ToString
        FormMasterCodeDetSingle.ShowDialog()
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        Dim query As String = ""
        Dim data_insert_parameter_temp As DataTable
        If confirm = Windows.Forms.DialogResult.Yes Then
            Try
                Dim id_code_detail As String = GVCodeDetail.GetFocusedRowCellDisplayText("id_code_detail").ToString
                query = String.Format("DELETE FROM tb_m_code_detail WHERE id_code_detail='{0}'", id_code_detail)
                execute_non_query(query, True, "", "", "", "")
                view_code_detail(GVCode.GetFocusedRowCellDisplayText("id_code").ToString)
                'FormMasterSampleDet.load_isi_param()
                'FormMasterSampleDet.load_template(FormMasterSampleDet.LETemplate.EditValue)
                If id_pop_up = "1" Then
                    data_insert_parameter_temp = FormMasterSampleDet.data_insert_parameter.Copy()

                    FormMasterSampleDet.load_isi_param()
                    FormMasterSampleDet.load_template(FormMasterSampleDet.LETemplate.EditValue)

                    FormMasterSampleDet.data_insert_parameter.Clear()
                    If Not data_insert_parameter_temp.Rows.Count = 0 Then
                        For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                            FormMasterSampleDet.data_insert_parameter.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                        Next
                    End If
                ElseIf id_pop_up = "2" Then
                    'FormMasterDesignSingle.load_isi_param()
                    'FormMasterDesignSingle.load_template(FormMasterDesignSingle.LETemplate.EditValue)
                    data_insert_parameter_temp = FormMasterDesignSingle.data_insert_parameter.Copy()

                    FormMasterDesignSingle.load_isi_param("1")
                    FormMasterDesignSingle.load_template(FormMasterDesignSingle.LETemplate.EditValue)

                    FormMasterDesignSingle.data_insert_parameter.Clear()
                    If Not data_insert_parameter_temp.Rows.Count = 0 Then
                        For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                            FormMasterDesignSingle.data_insert_parameter.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                        Next
                    End If
                ElseIf id_pop_up = "3" Then
                    data_insert_parameter_temp = FormMasterProductDet.data_insert_parameter.Copy()

                    FormMasterProductDet.load_isi_param()
                    FormMasterProductDet.load_template(FormMasterProductDet.LETemplate.EditValue)

                    FormMasterProductDet.data_insert_parameter.Clear()
                    If Not data_insert_parameter_temp.Rows.Count = 0 Then
                        For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                            FormMasterProductDet.data_insert_parameter.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                        Next
                    End If
                ElseIf id_pop_up = "4" Then
                    data_insert_parameter_temp = FormMasterRawMaterialDetSingle.data_insert_parameter.Copy()

                    FormMasterRawMaterialDetSingle.loadIsiParam()
                    FormMasterRawMaterialDetSingle.load_template(FormMasterRawMaterialDetSingle.LETemplate.EditValue)

                    FormMasterRawMaterialDetSingle.data_insert_parameter.Clear()
                    If Not data_insert_parameter_temp.Rows.Count = 0 Then
                        For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                            FormMasterRawMaterialDetSingle.data_insert_parameter.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                        Next
                    End If
                ElseIf id_pop_up = "5" Then 'raw mat

                    data_insert_parameter_temp = FormMasterRawMaterialSingle.data_insert_parameter.Copy()

                    FormMasterRawMaterialSingle.loadIsiParam()
                    FormMasterRawMaterialSingle.load_template(FormMasterRawMaterialSingle.LETemplate.EditValue)

                    FormMasterRawMaterialSingle.data_insert_parameter.Clear()
                    If Not data_insert_parameter_temp.Rows.Count = 0 Then
                        For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                            FormMasterRawMaterialSingle.data_insert_parameter.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                        Next
                    End If
                ElseIf id_pop_up = "6" Then
                    data_insert_parameter_temp = FormMasterDesignSingle.data_insert_parameter_dsg.Copy()

                    FormMasterDesignSingle.load_isi_param("2")
                    FormMasterDesignSingle.load_template_dsg(FormMasterDesignSingle.LETemplateDsg.EditValue)

                    FormMasterDesignSingle.data_insert_parameter_dsg.Clear()
                    If Not data_insert_parameter_temp.Rows.Count = 0 Then
                        For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                            FormMasterDesignSingle.data_insert_parameter_dsg.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                        Next
                    End If
                ElseIf id_pop_up = "7" Then
                    data_insert_parameter_temp = FormMasterDesignSingle.data_insert_parameter_non_md.Copy()

                    FormMasterDesignSingle.load_isi_param("3")
                    FormMasterDesignSingle.load_template_non_md(FormMasterDesignSingle.LETemplateNonMD.EditValue)

                    FormMasterDesignSingle.data_insert_parameter_non_md.Clear()
                    If Not data_insert_parameter_temp.Rows.Count = 0 Then
                        For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                            FormMasterDesignSingle.data_insert_parameter_non_md.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                        Next
                    End If
                End If
            Catch ex As Exception
                stopCustom("Code already used.")
            End Try
        End If
    End Sub

    Private Sub BEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEdit.Click
        Dim query As String = "SELECT * FROM tb_m_design_code WHERE id_code_detail='" & GVCodeDetail.GetFocusedRowCellDisplayText("id_code_detail").ToString & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            stopCustom("Code already used.")
        Else
            FormMasterCodeDetSingle.id_code_det = GVCodeDetail.GetFocusedRowCellDisplayText("id_code_detail").ToString
            FormMasterCodeDetSingle.id_code = GVCode.GetFocusedRowCellDisplayText("id_code").ToString
            FormMasterCodeDetSingle.id_pop_up = id_pop_up
            FormMasterCodeDetSingle.ShowDialog()
        End If
    End Sub

    Private Sub FormCodeTemplateEdit_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class