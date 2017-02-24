Public Class FormMatRetInProd 
    Public action As String = ""
    Public id_mat_prod_ret_in As String = ""
    Public id_prod_order As String = ""
    Public id_prod_order_wo As String = ""
    Public id_comp_contact_to As String = ""
    Public id_comp_contact_from As String = ""
    Public id_mat_purc_det_list, id_mat_purc_ret_in_det_list As New List(Of String)
    Dim date_start As Date
    Public id_report_status As String = ""
    Private Sub FormMatRetInProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus() 'get report status
        viewComp()
        '
        Try
            SLEStorage.EditValue = get_opt_mat_field("id_wh_def")
            SLELocator.EditValue = get_opt_mat_field("id_loc_def")
            SLERack.EditValue = get_opt_mat_field("id_rack_def")
            SLEDrawer.EditValue = get_opt_mat_field("id_drawer_def")
        Catch ex As Exception
        End Try
        '
        actionLoad()
    End Sub
    Sub actionLoad()
        If action = "ins" Then
            TxtRetOutNumber.Text = header_number_mat("6")
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BAttach.Enabled = False
            DERet.Text = view_date(0)
            viewDetailReturn()
        ElseIf action = "upd" Then
            'Enable/Disable
            BtnBrowsePO.Enabled = False
            GroupControlRet.Enabled = True

            'View data
            Try
                Dim query As String = "SELECT a.id_report_status,i.report_status,a.id_mat_prod_ret_in,b.id_prod_order_wo,h.id_prod_order, a.mat_prod_ret_in_date, a.mat_prod_ret_in_note,h.prod_order_number,b.prod_order_wo_number,desg.design_name,e.comp_name,e.comp_number,e.address_primary,a.id_comp_contact_from, "
                query += "a.mat_prod_ret_in_number  "
                query += ",drw.id_wh_drawer,rck.id_wh_rack,loc.id_wh_locator,comp.id_comp "
                query += "FROM tb_mat_prod_ret_in a "
                query += "INNER JOIN tb_prod_order_wo b ON a.id_prod_order_wo = b.id_prod_order_wo "
                query += "INNER JOIN tb_prod_order h ON b.id_prod_order = h.id_prod_order "
                query += "INNER JOIN tb_prod_demand_design pd_desg ON pd_desg.id_prod_demand_design = h.id_prod_demand_design "
                query += "INNER JOIN tb_m_design desg ON desg.id_design = pd_desg.id_design "
                query += "INNER JOIN tb_m_comp_contact d ON d.id_comp_contact = a.id_comp_contact_from "
                query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
                query += "INNER JOIN tb_lookup_report_status i ON i.id_report_status = a.id_report_status "
                query += "LEFT JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = a.id_wh_drawer "
                query += "LEFT JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
                query += "LEFT JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
                query += "LEFT JOIN tb_m_comp comp ON comp.id_comp = loc.id_comp "
                query += "WHERE a.id_mat_prod_ret_in = '" & id_mat_prod_ret_in & "'"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                Try
                    SLEStorage.EditValue = data.Rows(0)("id_comp").ToString
                    SLELocator.EditValue = data.Rows(0)("id_wh_locator").ToString
                    SLERack.EditValue = data.Rows(0)("id_wh_rack").ToString
                    SLEDrawer.EditValue = data.Rows(0)("id_wh_drawer").ToString
                Catch ex As Exception
                End Try

                id_prod_order = data.Rows(0)("id_prod_order").ToString
                id_prod_order_wo = data.Rows(0)("id_prod_order_wo").ToString
                'TEWONumber.Text = data.Rows(0)("prod_order_number").ToString
                TEPONumber.Text = data.Rows(0)("prod_order_wo_number").ToString
                id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
                MEAdrressCompFrom.Text = data.Rows(0)("address_primary").ToString
                TEDesign.Text = data.Rows(0)("design_name").ToString
                Dim start_date_arr() As String = data.Rows(0)("mat_prod_ret_in_date").ToString.Split(" ")
                DERet.Text = start_date_arr(0).ToString
                TxtRetOutNumber.Text = data.Rows(0)("mat_prod_ret_in_number").ToString
                MENote.Text = data.Rows(0)("mat_prod_ret_in_note").ToString
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
                id_report_status = data.Rows(0)("id_report_status").ToString
                'Constraint Status
            Catch ex As Exception
                errorConnection()
            End Try
            viewDetailReturn()
            allow_status()
        End If
        check_but()
    End Sub
    Sub allow_status()
        If check_edit_report_status(id_report_status, "47", id_mat_prod_ret_in) Then
            GVRetDetail.OptionsBehavior.Editable = True
            BtnAdd.Enabled = True
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = True
            '
            SLEDrawer.Enabled = True
            SLERack.Enabled = True
            SLELocator.Enabled = True
            SLEStorage.Enabled = True
        Else
            GVRetDetail.OptionsBehavior.Editable = False
            BtnAdd.Enabled = False
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
            MENote.Properties.ReadOnly = True
            DERet.Properties.ReadOnly = True
            BtnSave.Enabled = False
            '
            SLEDrawer.Enabled = False
            SLERack.Enabled = False
            SLELocator.Enabled = False
            SLEStorage.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
    End Sub
    Sub check_but()
        If GVRetDetail.RowCount > 0 Then
            BtnEdit.Visible = True
            BtnDel.Visible = True
        Else
            BtnEdit.Visible = False
            BtnDel.Visible = False
        End If
    End Sub
    'view company
    Sub viewComp()
        Dim query As String = "SELECT * FROM tb_m_comp a "
        query += "INNER JOIN tb_m_comp_cat b ON a.id_comp_cat = b.id_comp_cat "
        query += "INNER JOIN tb_m_wh_locator c ON a.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_wh_rack d ON c.id_wh_locator = d.id_wh_locator "
        query += "INNER JOIN tb_m_wh_drawer e ON e.id_wh_rack = d.id_wh_rack "
        query += "GROUP BY a.id_comp ORDER BY comp_number ASC "
        viewSearchLookupQuery(SLEStorage, query, "id_comp", "comp_name", "id_comp")
    End Sub
    'Rekursif Comp-Locator
    Private Sub SLEStorage_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEStorage.EditValueChanged
        viewLoactor()
    End Sub
    Private Sub SLELocator_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocator.EditValueChanged
        viewRack()
    End Sub
    Private Sub SLERack_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERack.EditValueChanged
        viewDrawer()
    End Sub
    'View Locator
    Sub viewLoactor()
        Dim id_comp As String = ""
        Try
            id_comp = SLEStorage.EditValue.ToString
        Catch ex As Exception
            id_comp = "-1"
        End Try
        Dim query As String = ""
        query = "SELECT * FROM tb_m_wh_locator a WHERE id_comp = '" + id_comp + "'"
        viewSearchLookupQuery(SLELocator, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub
    'View Rack
    Sub viewRack()
        Dim id_locator As String = ""
        Try
            id_locator = SLELocator.EditValue.ToString
        Catch ex As Exception
            id_locator = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_rack a WHERE id_wh_locator = '" + id_locator + "'"
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub
    'View Drawer
    Sub viewDrawer()
        Dim id_rack As String = ""
        Try
            id_rack = SLERack.EditValue.ToString
        Catch ex As Exception
            id_rack = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_drawer a WHERE id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub
    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub
    Sub viewDetailReturn()
        Dim query As String = "CALL view_mat_prod_ret('" + id_mat_prod_ret_in + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
    End Sub
    Sub viewDetailReturnExt(ByVal ext As String)
        Dim query As String = "CALL view_mat_prod_ret('" + ext + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
    End Sub
    'Button
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        'Cek isi qty
        Dim cond_qty As Boolean = True
        Dim qty As String
        For i As Integer = 0 To (GVRetDetail.RowCount - 1)
            qty = GVRetDetail.GetRowCellValue(i, "mat_prod_ret_in_det_qty").ToString
            If qty = "" Or qty = "0" Or qty Is Nothing Then
                cond_qty = False
            End If
        Next
        If Not formIsValidInGroup(EPRet, GroupGeneralHeader) Then
            errorInput()
        ElseIf Not cond_qty Or GVRetDetail.RowCount = 0 Then
            errorCustom("Qty can't blank or zero value !")
        Else
            Dim query As String
            Dim mat_prod_ret_in_number As String = addSlashes(TxtRetOutNumber.Text)
            Dim mat_prod_ret_in_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim mat_purc_ret_in_det_qty, mat_purc_ret_in_det_price As Decimal
            Dim id_pl_mrs_det, mat_purc_ret_in_det_note, id_wh_drawer As String
            id_wh_drawer = ""
            Try
                id_wh_drawer = SLEDrawer.EditValue.ToString
            Catch ex As Exception
            End Try
            If action = "ins" Then
                Try
                    'Main tbale
                    query = "INSERT INTO tb_mat_prod_ret_in(id_prod_order_wo, mat_prod_ret_in_number, id_comp_contact_from, mat_prod_ret_in_date, mat_prod_ret_in_note, id_report_status, id_wh_drawer);SELECT LAST_INSERT_ID() "
                    query += "VALUES('" + id_prod_order_wo + "', '" + mat_prod_ret_in_number + "', '" + id_comp_contact_from + "', NOW(), '" + mat_prod_ret_in_note + "', '" + id_report_status + "','" + id_wh_drawer + "') "
                    id_mat_prod_ret_in = execute_query(query, 0, True, "", "", "", "")
                    increase_inc_mat("6")

                    'insert who prepared
                    insert_who_prepared("47", id_mat_prod_ret_in, id_user)

                    'Detail return
                    For j As Integer = 0 To (GVRetDetail.RowCount - 1)
                        'Try
                        id_pl_mrs_det = GVRetDetail.GetRowCellValue(j, "id_pl_mrs_det").ToString
                        mat_purc_ret_in_det_qty = GVRetDetail.GetRowCellValue(j, "mat_prod_ret_in_det_qty")
                        mat_purc_ret_in_det_price = GVRetDetail.GetRowCellValue(j, "pl_mrs_det_price")
                        mat_purc_ret_in_det_note = GVRetDetail.GetRowCellValue(j, "mat_prod_ret_in_det_note").ToString
                        query = "INSERT tb_mat_prod_ret_in_det(id_mat_prod_ret_in, id_pl_mrs_det, mat_prod_ret_in_det_qty,mat_prod_ret_in_det_price, mat_prod_ret_in_det_note) "
                        query += "VALUES('" + id_mat_prod_ret_in + "', '" + id_pl_mrs_det + "', '" + decimalSQL(mat_purc_ret_in_det_qty.ToString) + "','" + decimalSQL(mat_purc_ret_in_det_price.ToString) + "', '" + mat_purc_ret_in_det_note + "') "
                        execute_non_query(query, True, "", "", "", "")
                        'Catch ex As Exception

                        'End Try
                    Next
                    FormMatRet.viewRetInProd()
                    FormMatRet.GVRetInProd.FocusedRowHandle = find_row(FormMatRet.GVRetInProd, "id_mat_prod_ret_in", id_mat_prod_ret_in)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                'Try
                'edit main table
                query = "UPDATE tb_mat_prod_ret_in SET mat_prod_ret_in_note = '" + mat_prod_ret_in_note + "', id_wh_drawer='" + id_wh_drawer + "' WHERE id_mat_prod_ret_in = '" + id_mat_prod_ret_in + "' "
                execute_non_query(query, True, "", "", "", "")
                'update detail and stock
                'delete first
                Dim sp_check As Boolean = False
                Dim query_del As String = "SELECT id_mat_prod_ret_in_det FROM tb_mat_prod_ret_in_det WHERE id_mat_prod_ret_in='" & id_mat_prod_ret_in & "'"
                Dim data_del As DataTable = execute_query(query_del, -1, True, "", "", "", "")
                If data_del.Rows.Count > 0 Then
                    For i As Integer = 0 To data_del.Rows.Count - 1
                        sp_check = False
                        ' false mean not found
                        For j As Integer = 0 To GVRetDetail.RowCount - 1
                            If Not GVRetDetail.GetRowCellValue(j, "id_mat_prod_ret_in_det").ToString = "" Then
                                '
                                If GVRetDetail.GetRowCellValue(j, "id_mat_prod_ret_in_det").ToString = data_del.Rows(i)("id_mat_prod_ret_in_det").ToString() Then
                                    sp_check = True
                                End If
                            End If
                        Next
                        'end loop check on gv
                        If sp_check = False Then
                            'Because not found, it's only mean already deleted
                            query = String.Format("DELETE FROM tb_mat_prod_ret_in_det WHERE id_mat_prod_ret_in_det='{0}'", data_del.Rows(i)("id_mat_prod_ret_in_det").ToString())
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Next
                End If
                For i As Integer = 0 To GVRetDetail.RowCount - 1
                    If Not GVRetDetail.GetRowCellValue(i, "id_pl_mrs_det").ToString = "" Then
                        If GVRetDetail.GetRowCellValue(i, "id_mat_prod_ret_in_det").ToString = "" Then
                            'insert new
                            query = String.Format("INSERT INTO tb_mat_prod_ret_in_det(id_mat_prod_ret_in, id_pl_mrs_det, mat_prod_ret_in_det_qty,mat_prod_ret_in_det_price, mat_prod_ret_in_det_note) VALUES('{0}','{1}','{2}','{3}','{4}')", id_mat_prod_ret_in, GVRetDetail.GetRowCellValue(i, "id_pl_mrs_det").ToString, decimalSQL(GVRetDetail.GetRowCellValue(i, "mat_prod_ret_in_det_qty").ToString), decimalSQL(GVRetDetail.GetRowCellValue(i, "pl_mrs_det_price").ToString), GVRetDetail.GetRowCellValue(i, "mat_prod_ret_in_det_note").ToString)
                            execute_non_query(query, True, "", "", "", "")
                        Else
                            'update
                            query = String.Format("UPDATE tb_mat_prod_ret_in_det SET id_pl_mrs_det='{0}', mat_prod_ret_in_det_qty='{1}', mat_prod_ret_in_det_price='{2}', mat_prod_ret_in_det_note='{3}' WHERE id_mat_prod_ret_in_det='{4}'", GVRetDetail.GetRowCellValue(i, "id_pl_mrs_det").ToString, decimalSQL(GVRetDetail.GetRowCellValue(i, "mat_prod_ret_in_det_qty").ToString), decimalSQL(GVRetDetail.GetRowCellValue(i, "pl_mrs_det_price").ToString), GVRetDetail.GetRowCellValue(i, "mat_prod_ret_in_det_note").ToString, GVRetDetail.GetRowCellValue(i, "id_mat_prod_ret_in_det").ToString)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    End If
                Next

                FormMatRet.viewRetInProd()
                FormMatRet.GVRetInProd.FocusedRowHandle = find_row(FormMatRet.GVRetInProd, "id_mat_prod_ret_in", id_mat_prod_ret_in)
                Close()
                'Catch ex As Exception
                '    errorConnection()
                'End Try
            End If
        End If
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormPopUpMatRetProd.id_pop_up = "1"
        FormPopUpMatRetProd.id_prod_order_wo = id_prod_order_wo
        FormPopUpMatRetProd.ShowDialog()
    End Sub
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If (MessageBox.Show("Are you sure to delete this ?", "Delete Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
        deleteRows()
        check_but()
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        FormPopUpMatRetProd.id_pop_up = "1"
        FormPopUpMatRetProd.id_pl_mrs_det = GVRetDetail.GetFocusedRowCellValue("id_pl_mrs_det").ToString
        FormPopUpMatRetProd.id_prod_order_wo = id_prod_order_wo
        FormPopUpMatRetProd.ShowDialog()
    End Sub
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        ReportMatRetInProd.id_mat_prod_ret_in = id_mat_prod_ret_in
        Dim Report As New ReportMatRetInProd()
        'Show the report's preview 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
    'Row Manipulation
    Sub focusColumnCode()
        GVRetDetail.FocusedColumn = GVRetDetail.VisibleColumns(0)
        GVRetDetail.ShowEditor()
    End Sub
    Sub newRows()
        GVRetDetail.AddNewRow()
    End Sub
    Sub deleteRows()
        GVRetDetail.DeleteRow(GVRetDetail.FocusedRowHandle)
    End Sub
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_mat_prod_ret_in
        FormReportMark.report_mark_type = "47"
        FormReportMark.ShowDialog()
    End Sub
    Private Sub FormMatRetInDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Private Sub BtnBrowsePO_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowsePO.Click
        FormPopUpWOProdMat.id_pop_up = "1"
        FormPopUpWOProdMat.ShowDialog()
    End Sub
    Private Sub GVRetDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRetDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_mat_prod_ret_in
        FormDocumentUpload.report_mark_type = "47"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class