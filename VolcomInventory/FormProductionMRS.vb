Public Class FormProductionMRS
    Public id_pop_up As String = "-1"

    Public id_mrs As String = "-1"
    Public id_prod_order As String = "-1"
    Public id_comp_req_from As String = "-1"
    Public id_comp_req_to As String = "-1"
    Public id_report_status_g As String = "-1"
    Dim is_freeze As String = get_opt_mat_field("is_freeze_mat_storage")
    '
    Private Sub FormProductionMRS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If is_freeze = "1" Then
            warningCustom("Material storage still on hold")
        Else
            load_mrs()
        End If
    End Sub

    Sub load_mrs()
        view_mrs()
        If id_mrs = "-1" Then
            'new
            TEMRSNumber.Text = header_number_prod("6")
            TEDate.Text = view_date(0)
            id_report_status_g = 1
            BSave.Enabled = True
            BMark.Enabled = False
            BPrint.Visible = False
            BtnAttachment.Visible = False
        Else
            Dim query As String = String.Format("SELECT *,DATE_FORMAT(prod_order_mrs_date,'%Y-%m-%d') as prod_order_mrs_datex FROM tb_prod_order_mrs WHERE id_prod_order_mrs = '{0}'", id_mrs)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TECompName.Text = get_company_x(get_id_company(id_comp_req_from), "1")
            TECompCode.Text = get_company_x(get_id_company(id_comp_req_from), "2")
            TECompToName.Text = get_company_x(get_id_company(id_comp_req_to), "1")
            TECompToCode.Text = get_company_x(get_id_company(id_comp_req_to), "2")

            id_report_status_g = data.Rows(0)("id_report_status").ToString
            TEDate.Text = view_date_from(data.Rows(0)("prod_order_mrs_datex").ToString, 0)

            MENote.Text = data.Rows(0)("prod_order_mrs_note").ToString

            allow_status()
            BMark.Enabled = True

        End If
        check_but()
    End Sub

    Sub check_but()
        If GVMat.RowCount > 0 Then
            BEditMat.Visible = True
            BDelMat.Visible = True
        Else
            BEditMat.Visible = False
            BDelMat.Visible = False
        End If

        If id_report_status_g = "5" Then
            PCAddDel.Visible = False
            BCancel.Visible = False
            BSave.Visible = False
        Else
            PCAddDel.Visible = True
            BCancel.Visible = True
            BSave.Visible = True
        End If

        If id_report_status_g = "6" Then
            PCAddDel.Visible = False
            BSave.Visible = False
        Else
            PCAddDel.Visible = True
            BSave.Visible = True
        End If

        If id_pop_up = "1" Then
            If id_report_status_g = "1" Then
                BPickPO.Enabled = True
            Else
                BPickPO.Enabled = False
            End If
        Else
            BPickPO.Enabled = False
        End If
    End Sub
    Sub allow_status()
        If check_edit_report_status(id_report_status_g, "29", id_mrs) Then
            BSave.Enabled = True
            '
            BPickWO.Enabled = True
            BPickCompTo.Enabled = True
        Else
            BSave.Enabled = False
            '
            BPickWO.Enabled = False
            BPickCompTo.Enabled = False
        End If
        'If check_print_report_status(id_report_status_g) Then
        '    BPrint.Enabled = True
        'Else
        '    BPrint.Enabled = False
        'End If
    End Sub
    'Private Sub BPickWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickWO.Click
    '    FormPopUpWOProd.id_prod_order = id_prod_order
    '    FormPopUpWOProd.id_wo = id_wo
    '    FormPopUpWOProd.id_popup = "1"
    '    FormPopUpWOProd.ShowDialog()
    'End Sub

    Private Sub BPickCompTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickCompTo.Click
        FormPopUpContact.id_pop_up = "22"
        FormPopUpContact.id_cat = "5"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BAddMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddMat.Click
        FormPopUpMat.id_pop_up = "1"
        FormPopUpMat.id_po = id_prod_order
        FormPopUpMat.ShowDialog()
    End Sub
    Sub view_mrs()
        Try
            Dim query As String
            query = "CALL view_prod_order_mrs('" & id_mrs & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMat.DataSource = data
            '
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub GVMat_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMat.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BEditMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditMat.Click
        FormPopUpMat.id_pop_up = "1"
        FormPopUpMat.id_mat = GVMat.GetFocusedRowCellValue("id_mat_det").ToString
        FormPopUpMat.id_po = id_prod_order
        FormPopUpMat.ShowDialog()
    End Sub

    Private Sub BDelMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelMat.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this material on list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                GVMat.DeleteSelectedRows()
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("This material can't be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim cnt As Boolean = True

        If id_pop_up = "1" And id_prod_order = "-1" Then
            cnt = False
        End If

        If cnt Then
            Dim query As String = ""

            'check first
            Dim more_qty As Boolean = False
            Dim proceed As Boolean = True
            For i As Integer = 0 To GVMat.RowCount - 1
                If GVMat.GetRowCellValue(i, "qty") > GVMat.GetRowCellValue(i, "qty_all_mat") Then
                    more_qty = True
                End If
            Next

            ValidateChildren()

            If id_mrs = "-1" Then
                'new
                TEPONumber.Text = header_number_prod("6")

                If Not formIsValidInGroup(EPProdOrderMRS, GroupGeneralHeader) Or id_comp_req_to = "-1" Or id_comp_req_from = "-1" Then
                    stopCustom("Please make sure that : " & vbNewLine & "- MRS number is correct" & vbNewLine & "- Request From not blank" & vbNewLine & "- Request To not blank")
                Else
                    If more_qty = True Then
                        'warn
                        Dim confirm As DialogResult
                        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Insufficient quantity on some material, do you want to proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                        If confirm = Windows.Forms.DialogResult.Yes Then
                            proceed = True
                        Else
                            proceed = False
                        End If
                        'end warn
                    End If

                    If proceed = True Then
                        query = String.Format("INSERT INTO tb_prod_order_mrs(id_prod_order,prod_order_mrs_number,id_comp_contact_req_to,id_comp_contact_req_from,prod_order_mrs_date,prod_order_mrs_note) VALUES('{0}','{1}','{2}','{3}',NOW(),'{4}');SELECT LAST_INSERT_ID()", id_prod_order, TEMRSNumber.Text, id_comp_req_to, id_comp_req_from, MENote.Text)
                        Dim last_id As String = execute_query(query, 0, True, "", "", "", "")

                        If GVMat.RowCount > 0 Then
                            For i As Integer = 0 To GVMat.RowCount - 1
                                If Not GVMat.GetRowCellValue(i, "id_mat_det").ToString = "" Then
                                    'dp
                                    query = String.Format("INSERT INTO tb_prod_order_mrs_det(id_prod_order_mrs,id_mat_det,prod_order_mrs_det_qty,prod_order_mrs_det_note,id_mat_det_price) VALUES('{0}','{1}','{2}','{3}','{4}')", last_id, GVMat.GetRowCellValue(i, "id_mat_det").ToString(), decimalSQL(GVMat.GetRowCellValue(i, "qty").ToString()), GVMat.GetRowCellValue(i, "note").ToString(), GVMat.GetRowCellValue(i, "id_mat_det_price").ToString())
                                    execute_non_query(query, True, "", "", "", "")
                                End If
                            Next
                        End If

                        'insert who prepared
                        insert_who_prepared("29", last_id, id_user)
                        'end insert who prepared
                        increase_inc_prod("6")

                        FormMaterialRequisition.view_mrs()

                        FormProductionDet.XTCPageProduction.SelectedTabPageIndex = 2
                        FormProductionDet.view_mrs()
                        FormProductionDet.GVMRS.FocusedRowHandle = find_row(FormProductionDet.GVMRS, "id_prod_order_mrs", last_id)
                        Close()
                    End If
                End If
            Else
                'edit
                If Not formIsValidInGroup(EPProdOrderMRS, GroupGeneralHeader) Or id_comp_req_from = "-1" Or id_comp_req_to = "-1" Then
                    stopCustom("Please make sure that : " & vbNewLine & "- MRS number is correct" & vbNewLine & "- Request From not blank" & vbNewLine & "- Request To not blank")
                Else
                    If more_qty = True Then
                        'warn
                        Dim confirm As DialogResult
                        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Insufficient quantity on some material, do you want to proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                        If confirm = Windows.Forms.DialogResult.Yes Then
                            proceed = True
                        Else
                            proceed = False
                        End If
                        'end warn
                    End If

                    If proceed = True Then
                        query = String.Format("UPDATE tb_prod_order_mrs SET prod_order_mrs_number='{0}',id_comp_contact_req_to='{1}',id_comp_contact_req_from='{2}',prod_order_mrs_note='{3}' WHERE id_prod_order_mrs='{4}'", TEMRSNumber.Text, id_comp_req_to, id_comp_req_from, MENote.Text, id_mrs)
                        execute_non_query(query, True, "", "", "", "")

                        'delete first
                        Dim sp_check As Boolean = False
                        Dim query_del As String = "SELECT id_prod_order_mrs_det FROM tb_prod_order_mrs_det WHERE id_prod_order_mrs='" & id_mrs & "'"
                        Dim data_del As DataTable = execute_query(query_del, -1, True, "", "", "", "")
                        If data_del.Rows.Count > 0 Then
                            For i As Integer = 0 To data_del.Rows.Count - 1
                                sp_check = False
                                ' false mean not found, believe me
                                For j As Integer = 0 To GVMat.RowCount - 1
                                    If Not GVMat.GetRowCellValue(j, "id_prod_order_mrs_det").ToString = "" Then
                                        '
                                        If GVMat.GetRowCellValue(j, "id_prod_order_mrs_det").ToString = data_del.Rows(i)("id_prod_order_mrs_det").ToString() Then
                                            sp_check = True
                                        End If
                                    End If
                                Next
                                'end loop check on gv
                                If sp_check = False Then
                                    'Because not found, it's only mean already deleted
                                    query = String.Format("DELETE FROM tb_prod_order_mrs_det WHERE id_prod_order_mrs_det='{0}'", data_del.Rows(i)("id_prod_order_mrs_det").ToString())
                                    execute_non_query(query, True, "", "", "", "")
                                End If
                            Next
                        End If

                        For i As Integer = 0 To GVMat.RowCount - 1
                            If Not GVMat.GetRowCellValue(i, "id_mat_det").ToString = "" Then
                                If GVMat.GetRowCellValue(i, "id_prod_order_mrs_det").ToString = "" Then
                                    'insert new
                                    query = String.Format("INSERT INTO tb_prod_order_mrs_det(id_prod_order_mrs,id_mat_det,prod_order_mrs_det_qty,prod_order_mrs_det_note,id_mat_det_price) VALUES('{0}','{1}','{2}','{3}','{4}')", id_mrs, GVMat.GetRowCellValue(i, "id_mat_det").ToString(), decimalSQL(GVMat.GetRowCellValue(i, "qty").ToString()), GVMat.GetRowCellValue(i, "note").ToString(), GVMat.GetRowCellValue(i, "id_mat_det_price").ToString())
                                    execute_non_query(query, True, "", "", "", "")
                                Else
                                    'update
                                    query = String.Format("UPDATE tb_prod_order_mrs_det SET id_mat_det='{0}',prod_order_mrs_det_qty='{1}',prod_order_mrs_det_note='{2}',id_mat_det_price='{4}' WHERE id_prod_order_mrs_det='{3}'", GVMat.GetRowCellValue(i, "id_mat_det").ToString(), decimalSQL(GVMat.GetRowCellValue(i, "qty").ToString()), GVMat.GetRowCellValue(i, "note").ToString(), GVMat.GetRowCellValue(i, "id_prod_order_mrs_det").ToString(), GVMat.GetRowCellValue(i, "id_mat_det_price").ToString())
                                    execute_non_query(query, True, "", "", "", "")
                                End If
                            End If
                        Next

                        FormMaterialRequisition.view_mrs()

                        FormProductionDet.XTCPageProduction.SelectedTabPageIndex = 2
                        FormProductionDet.view_mrs()
                        FormProductionDet.GVMRS.FocusedRowHandle = find_row(FormProductionDet.GVMRS, "id_prod_order_mrs", id_mrs)
                        Close()
                    End If
                End If
            End If
        Else
            stopCustom("Please select PO.")
        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormProductionMRS_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVMat_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVMat.RowStyle
        If GVMat.RowCount > 0 Then
            If GVMat.GetRowCellValue(e.RowHandle, "qty") > GVMat.GetRowCellValue(e.RowHandle, "qty_left") Then
                'GVMat.FocusedRowHandle()
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.Salmon
                e.Appearance.Font = New Font(GVMat.Appearance.Row.Font, FontStyle.Bold)
            Else
                e.Appearance.BackColor = Color.White
                e.Appearance.BackColor2 = Color.White
                e.Appearance.Font = New Font(GVMat.Appearance.Row.Font, FontStyle.Regular)
            End If
        End If
    End Sub

    Private Sub TEMRSNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEMRSNumber.Validating
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_prod_order_mrs) FROM tb_prod_order_mrs WHERE prod_order_mrs_number='{0}' AND id_prod_order_mrs!='{1}'", TEMRSNumber.Text, id_mrs)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPProdOrderMRS, TEMRSNumber, "1")
        Else
            EP_TE_cant_blank(EPProdOrderMRS, TEMRSNumber)
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_mrs
        FormReportMark.report_mark_type = "29"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        ReportProductionMRS.id_mrs = id_mrs
        If check_print_report_status(id_report_status_g) Then
            ReportProductionMRS.is_pre = "-1"
        Else
            ReportProductionMRS.is_pre = "1"
        End If

        Dim Report As New ReportProductionMRS()
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BShowBOM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BShowBOM.Click
        FormInfoBOMMat.id_pd_design = get_prod_order_x(id_prod_order, "1")
        FormInfoBOMMat.ShowDialog()
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_mrs
        FormDocumentUpload.report_mark_type = "29"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BReqFrom_Click(sender As Object, e As EventArgs) Handles BReqFrom.Click
        FormPopUpContact.id_pop_up = "22f"
        FormPopUpContact.id_cat = "5"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BCancelReport_Click(sender As Object, e As EventArgs) Handles BCancelReport.Click
        'cek PL
        Dim q As String = "SELECT * FROM tb_pl_mrs WHERE id_prod_order_mrs='" & id_mrs & "' AND id_report_status!=5"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            stopCustom("Please cancel packing list with this MRS")
        Else
            Dim q_upd As String = "UPDATE tb_prod_order_mrs SET id_report_status=5 WHERE id_prod_order_mrs='" & id_mrs & "'"
            execute_non_query(q_upd, True, "", "", "", "")
            delete_all_mark_related("29", id_mrs)
            load_mrs()
        End If
    End Sub

    Private Sub BPickPO_Click(sender As Object, e As EventArgs) Handles BPickPO.Click
        FormProductionMRSPickPO.ShowDialog()
    End Sub
End Class