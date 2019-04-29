Public Class FormMatPLSingle
    Public action As String
    Public id_pl_mrs As String
    Public id_comp_contact_from, id_comp_from As String
    Public id_comp_contact_to, id_comp_to As String
    Public code_list, code_list_drawer, id_mat_list As New List(Of String)
    Dim id_pl_mrs_det_list As New List(Of String)
    Dim test_old As String
    Public id_report_status As String
    Public id_mrs As String = "-1"
    Public id_prod_order_mrs_det_style As String
    Dim qty_process As Decimal
    Dim based_on_srs As Boolean = False
    Public cond_check As Boolean = True
    Public mat_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal
    Public id_wo As String

    Public is_other As String = "-1"

    'Form Load
    Private Sub FormMatPLSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        checkFormAccessSingle(Name) 'check access
        viewReportStatus() 'get report status
        viewPLType() 'get PL Type
        actionLoad()
    End Sub
    Sub actionLoad()
        If action = "ins" Then
            id_comp_contact_from = get_company_x(id_comp_from, 6)
            TxtCodeCompFrom.Text = get_company_x(id_comp_from, 2)
            TxtNameCompFrom.Text = get_company_x(id_comp_from, 1)
            If id_mrs <> "-1" Then
                id_comp_to = get_id_company(id_comp_contact_to)
                TxtCodeCompTo.Text = get_company_x(id_comp_to, 2)
                TxtNameCompTo.Text = get_company_x(id_comp_to, 1)
                viewFillEmptyData()
                GroupControlDrawer.Enabled = True
                GroupControlDetailSingle.Enabled = True
                based_on_srs = True
                BtnInfoSrs.Enabled = True
            End If
            TxtPLNumber.Text = header_number_mat("11")
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BAttach.Enabled = False
            DEPL.Text = view_date(0)
            id_report_status = "2"
            If is_other = "1" Then
                LEPLType.ItemIndex = LEPLType.Properties.GetDataSourceRowIndex("id_pl_mat_type", "2")
                LEPLType.Enabled = False
            End If
        ElseIf action = "upd" Then
            BtnCancel.Text = "Close"
            BtnInfoSrs.Enabled = True
            LEPLType.Enabled = False
            'Fetch from db main
            Dim query As String = "SELECT a.id_pl_mat_type,a.id_currency,i.prod_order_mrs_number,a.id_prod_order_mrs, a.id_pl_mrs ,a.id_comp_contact_from , a.id_comp_contact_to,a.pl_mrs_date, a.pl_mrs_note, a.pl_mrs_number, (d.comp_name) AS comp_name_from, (d.comp_number) AS comp_code_from, (d.id_comp) AS id_comp_from, (f.comp_name) AS comp_name_to, (f.comp_number) AS comp_code_to, (f.id_comp) AS id_comp_to,(f.address_primary) AS comp_address_t, a.id_report_status, "
            query += "DATE_FORMAT(a.pl_mrs_date,'%Y-%m-%d') as pl_mrs_datex "
            query += "FROM tb_pl_mrs a "
            query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
            query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
            query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
            query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
            query += "INNER JOIN tb_prod_order_mrs i ON a.id_prod_order_mrs = i.id_prod_order_mrs "
            query += "LEFT JOIN tb_prod_order k ON i.id_prod_order = k.id_prod_order "
            query += "WHERE a.id_pl_mrs = '" + id_pl_mrs + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            'tampung ke form
            BtnPopSRS.Enabled = False
            BtnPopSource.Enabled = False
            TxtSRSNumber.Text = data.Rows(0)("prod_order_mrs_number").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_code_from").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
            id_comp_from = data.Rows(0)("id_comp_from").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_code_to").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
            id_comp_to = data.Rows(0)("id_comp_to").ToString
            TxtPLNumber.Text = data.Rows(0)("pl_mrs_number").ToString
            DEPL.Text = view_date_from(data.Rows(0)("pl_mrs_datex").ToString(), 0)
            MENote.Text = data.Rows(0)("pl_mrs_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LEPLType.ItemIndex = LEPLType.Properties.GetDataSourceRowIndex("id_pl_mat_type", data.Rows(0)("id_pl_mat_type").ToString)
            id_mrs = data.Rows(0)("id_prod_order_mrs").ToString

            'Group Control
            GroupControlDetailSingle.Enabled = True
            GroupControlDrawer.Enabled = True

            'based on status
            id_report_status = data.Rows(0)("id_report_status").ToString

            BtnAdd.Enabled = False
            BtnDel.Enabled = False
            '
            BDelRoll.Enabled = False
            BAddRoll.Enabled = False
            GVRoll.Columns("piece").OptionsColumn.ReadOnly = True
            GVRoll.Columns("qty").OptionsColumn.ReadOnly = True
            '

            If id_report_status = "5" Then
                BtnSave.Enabled = False
                BtnPrint.Enabled = False
                BtnPopTo.Enabled = False
                BtnPopFrom.Enabled = False
                BAdd.Enabled = False
                Bdel.Enabled = False
                MENote.Properties.ReadOnly = True
                GridColumnQtyNeed.Visible = False
                GroupControlDetailSingle.Enabled = False
                GroupControlDrawer.Enabled = False
            Else
                If check_edit_report_status(id_report_status, "30", id_pl_mrs) Then
                    'can edit note
                    BtnSave.Enabled = True
                    BtnPopTo.Enabled = False
                    BtnPopFrom.Enabled = False
                    BAdd.Enabled = False
                    Bdel.Enabled = False
                    MENote.Properties.ReadOnly = False
                Else
                    'can not edit note
                    BtnSave.Enabled = False
                    BtnPopTo.Enabled = False
                    BtnPopFrom.Enabled = False
                    BAdd.Enabled = False
                    Bdel.Enabled = False
                    MENote.Properties.ReadOnly = True
                End If
            End If
            'Fetch db detail
            viewFillEmptyData()
        End If
        view_list_pcs()
    End Sub
    'View PL Type
    Sub viewPLType()
        Dim query As String = "SELECT id_pl_mat_type,pl_mat_type FROM tb_pl_mat_type a ORDER BY a.id_pl_mat_Type "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEPLType, query, 0, "pl_mat_type", "id_pl_mat_type")
    End Sub
    'View Report Status
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub
    Sub viewFillEmptyData()
        Dim query As String = "CALL view_prod_order_mrs('" + id_mrs + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        If action = "ins" Then
            viewFillEmptyDrawer()
            id_mat_list.Clear()
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_mat_list.Add(data.Rows(i)("id_mat_det").ToString)
            Next
        ElseIf action = "upd" Then
            viewPLSample()
            id_mat_list.Clear()
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_mat_list.Add(data.Rows(i)("id_mat_det").ToString)
                If action = "upd" Then
                    getAmountReq(data.Rows(i)("id_prod_order_mrs_det").ToString, False)
                End If
            Next
            GVDetail.FocusedRowHandle = 0
        End If
    End Sub
    Sub viewFillEmptyDrawer()
        Dim query As String = "SELECT ('0') AS id_pl_mrs_det, ('0') AS id_mat_det,('') AS code, ('') AS name, ('0') AS id_wh_drawer, ('') AS wh_locator, ('') AS wh_rack,  ('') AS wh_drawer, ('0') AS pl_mrs_det_qty, ('') AS pl_mrs_det_note, ('0') AS qty_all_mat, ('0') AS id_prod_order_mrs_det, ('') AS uom, ('0') AS id_wh_locator, ('0') AS id_wh_rack ,(0.00) AS pl_mrs_det_price, (0.00) AS total_price, ('') AS id_mat_det_price"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDrawer.DataSource = data
        deleteRows()

        view_list_pcs_empty()
    End Sub
    'View PL Sample
    Sub viewPLSample()
        Dim query As String = "CALL view_pl_mrs('" + id_pl_mrs + "', '1')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            code_list.Add(data.Rows(i)("id_mat_det").ToString)
            code_list_drawer.Add(data.Rows(i)("id_wh_drawer").ToString)
            id_pl_mrs_det_list.Add(data.Rows(i)("id_pl_mrs_det").ToString)
        Next
        GCDrawer.DataSource = data
    End Sub
    'Gridcontrol Detail EVENT
    'Press Key On Grid Control Detail
    Private Sub GCDetail_ProcessGridKey(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If id_report_status = "1" Or id_report_status = "2" Then
            If e.KeyCode = Keys.Escape Then
                Dim grid As DevExpress.XtraGrid.GridControl = sender
                grid.FocusedView.CloseEditor()
                e.Handled = True
            ElseIf e.KeyCode = Keys.F5 Then
                Dim grid As DevExpress.XtraGrid.GridControl = sender
                grid.FocusedView.CloseEditor()
                e.Handled = True
                newRows()
            ElseIf e.KeyCode = Keys.F6 Then
                Dim grid As DevExpress.XtraGrid.GridControl = sender
                grid.FocusedView.CloseEditor()
                e.Handled = True
                If (MessageBox.Show("Are you sure to delete this row?", "Delete Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
                deleteRows()
            End If
        End If
    End Sub

    'Row Manipulation
    Sub focusColumnCode()
        GVDrawer.FocusedColumn = GVDrawer.VisibleColumns(0)
        GVDrawer.ShowEditor()
    End Sub
    Sub newRows()
        GVDrawer.AddNewRow()
        cantEdit()
    End Sub
    Sub deleteRows()
        GVDrawer.DeleteRow(GVDrawer.FocusedRowHandle)
        cantEdit()
    End Sub
    Sub cantEdit()
        If GVDrawer.RowCount < 1 Then
            'BtnEdit.Enabled = False
            BtnDel.Enabled = False
        Else
            'BtnEdit.Enabled = True
            BtnDel.Enabled = True
        End If
    End Sub

    'Company
    Private Sub BtnPopFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPopFrom.Click
        FormPopUpContact.id_comp_contact = id_comp_contact_from
        FormPopUpContact.id_pop_up = "9"
        FormPopUpContact.ShowDialog()
    End Sub
    Private Sub BtnPopTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPopTo.Click
        FormPopUpContact.id_comp_contact = id_comp_contact_to
        FormPopUpContact.id_pop_up = "10"
        FormPopUpContact.ShowDialog()
    End Sub
    'Validating
    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(ErrorProviderPL, TxtNameCompFrom)
        ErrorProviderPL.SetIconPadding(TxtNameCompFrom, 30)
    End Sub
    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(ErrorProviderPL, TxtNameCompTo)
        ErrorProviderPL.SetIconPadding(TxtNameCompTo, 5)
    End Sub
    'Navigation Button
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        ValidateChildren()
        '
        Dim is_over_qty As Boolean = False
        'cek dengan requisition di DB
        For i As Integer = 0 To GVDetail.RowCount - 1
            Dim id_prod_order_mrs_det_cekya As String = GVDetail.GetRowCellValue(i, "id_prod_order_mrs_det").ToString
            Dim qty_plya As String = GVDetail.GetRowCellValue(i, "qty_real_mat").ToString
            Dim mat_checkya As String = GVDetail.GetRowCellValue(i, "name").ToString
            isAllowRequisition(mat_checkya, id_prod_order_mrs_det_cekya, qty_plya)
            If Not cond_check Then
                Exit For
            End If
        Next

        For i As Integer = 0 To GVDrawer.RowCount - 1
            If Decimal.Parse(GVDrawer.GetRowCellValue(i, "qty_all_mat").ToString) < Decimal.Parse(GVDrawer.GetRowCellValue(i, "pl_mrs_det_qty").ToString) Then
                is_over_qty = True
                Exit For
            End If
        Next

        If Not formIsValidInGroup(ErrorProviderPL, GroupGeneralHeader) Then
            errorInput()
        ElseIf Not cond_check Then
            errorCustom("Material : '" + mat_check + "' cannot exceed " + allow_sum.ToString("N2") + ", please check in Info MRS ! ")
            infoSrs()
        ElseIf is_over_qty Then
            stopCustom("Material is over quantity. Please check again your material quantity.")
            XTCDrawer.SelectedTabPageIndex = 1
        Else
            'Main var
            Dim query As String = ""
            Dim query2 As String = ""
            Dim query_upd_storage As String = ""
            Dim pl_mrs_number As String = addSlashes(TxtPLNumber.Text)
            Dim pl_mrs_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim id_pl_mat_Type As String = LEPLType.EditValue

            'detail var
            Dim pl_mrs_det_note As String
            Dim id_pl_mrs_det As String = ""
            Dim id_prod_order_mrs_det As String
            Dim pl_mrs_det_qty As String
            Dim id_mat_det As String
            Dim id_mat_det_pricex As String
            Dim pl_mrs_det_price As Decimal
            Dim id_wh_drawer As String
            Dim succes As Boolean = False

            'roll var
            Dim pl_mrs_pcs As String = ""
            Dim id_pl_mrs_pcs As String = ""
            Dim pl_mrs_pcs_qty As String = ""

            If action = "ins" Then
                'Main table
                query = "INSERT INTO tb_pl_mrs(id_prod_order_mrs, pl_mrs_number, id_comp_contact_from, id_pl_mat_type, id_comp_contact_to, pl_mrs_date, pl_mrs_note, id_report_status) "
                query += "VALUES('" + id_mrs + "','" + pl_mrs_number + "', '" + id_comp_contact_from + "','" + id_pl_mat_Type + "', '" + id_comp_contact_to + "', NOW(), '" + pl_mrs_note + "', '" + id_report_status + "');SELECT LAST_INSERT_ID() "
                id_pl_mrs = execute_query(query, 0, True, "", "", "", "")
                increase_inc_mat("11")

                'preapred default
                insert_who_prepared("30", id_pl_mrs, id_user)
                'detail table
                For i As Integer = 0 To GVDrawer.RowCount - 1
                    Try
                        pl_mrs_det_note = GVDrawer.GetRowCellValue(i, "pl_mrs_det_note").ToString
                        id_prod_order_mrs_det = GVDrawer.GetRowCellValue(i, "id_prod_order_mrs_det").ToString
                        pl_mrs_det_qty = GVDrawer.GetRowCellValue(i, "pl_mrs_det_qty").ToString
                        id_wh_drawer = GVDrawer.GetRowCellValue(i, "id_wh_drawer").ToString
                        id_mat_det = GVDrawer.GetRowCellValue(i, "id_mat_det").ToString
                        id_mat_det_pricex = GVDrawer.GetRowCellValue(i, "id_mat_det_price").ToString
                        pl_mrs_det_price = GVDrawer.GetRowCellValue(i, "pl_mrs_det_price")
                        'INSERT TB PL mat DETAIL
                        query = "INSERT INTO tb_pl_mrs_det(id_pl_mrs,pl_mrs_det_note, id_prod_order_mrs_det, id_mat_det_price, pl_mrs_det_qty,  pl_mrs_det_price, id_wh_drawer) "
                        query += "VALUES('" + id_pl_mrs + "','" + pl_mrs_det_note + "', '" + id_prod_order_mrs_det + "','" + id_mat_det_pricex + "', '" + decimalSQL(pl_mrs_det_qty) + "','" + decimalSQL(pl_mrs_det_price.ToString) + "', '" + id_wh_drawer + "') "
                        execute_non_query(query, True, "", "", "", "")

                        'INSERT TB PL STORAGE
                        query_upd_storage = "INSERT INTO tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det,id_mat_det_price,price, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_stock_status,report_mark_type,id_report) "
                        query_upd_storage += "VALUES('" + id_wh_drawer + "', '2', '" + id_mat_det + "','" + id_mat_det_pricex + "','" + decimalSQL(pl_mrs_det_price.ToString) + "', '" + decimalSQL(pl_mrs_det_qty) + "', NOW(), 'Prepare PL : " + pl_mrs_number + "','2','30','" + id_pl_mrs + "')"
                        execute_non_query(query_upd_storage, True, "", "", "", "")

                        succes = True
                    Catch ex As Exception
                    End Try
                Next
                'roll
                For i As Integer = 0 To GVRoll.RowCount - 1
                    Try
                        pl_mrs_pcs = GVRoll.GetRowCellValue(i, "piece").ToString
                        id_mat_det_pricex = GVRoll.GetRowCellValue(i, "id_mat_det_price").ToString
                        id_wh_drawer = GVRoll.GetRowCellValue(i, "id_wh_drawer").ToString
                        pl_mrs_pcs_qty = GVRoll.GetRowCellValue(i, "qty")

                        'INSERT TB PL mat pcs
                        query = "INSERT INTO tb_pl_mrs_pcs(id_pl_mrs,piece,id_mat_det_price,id_wh_drawer,qty) "
                        query += "VALUES('" + id_pl_mrs + "','" + pl_mrs_pcs + "','" + id_mat_det_pricex + "','" + id_wh_drawer + "','" + decimalSQL(pl_mrs_pcs_qty.ToString) + "') "
                        execute_non_query(query, True, "", "", "", "")
                    Catch ex As Exception
                    End Try
                Next
                '
                If FormMatPL.XTCPL.SelectedTabPageIndex = 0 Then 'production
                    FormMatPL.viewPL()
                    FormMatPL.GVProdPL.FocusedRowHandle = find_row(FormMatPL.GVProdPL, "id_pl_mrs", id_pl_mrs)
                    FormMatPL.XTCPL.SelectedTabPageIndex = 0
                    FormMatPL.XTCTabProduction.SelectedTabPageIndex = 0
                ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 1 Then 'wo
                    FormMatPL.viewPLWO()
                    FormMatPL.GVPLWO.FocusedRowHandle = find_row(FormMatPL.GVPLWO, "id_pl_mrs", id_pl_mrs)
                    FormMatPL.XTCPL.SelectedTabPageIndex = 1
                    FormMatPL.XTCPLWO.SelectedTabPageIndex = 0
                ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 2 Then 'other
                    FormMatPL.viewPLOther()
                    FormMatPL.GVPLOther.FocusedRowHandle = find_row(FormMatPL.GVPLOther, "id_pl_mrs", id_pl_mrs)
                    FormMatPL.XTCPL.SelectedTabPageIndex = 2
                    FormMatPL.XTCPLOther.SelectedTabPageIndex = 0
                End If
                Close()
            ElseIf action = "upd" Then
                'update main table
                query = "UPDATE tb_pl_mrs SET pl_mrs_note = '" + pl_mrs_note + "' WHERE id_pl_mrs = '" + id_pl_mrs + "'"
                execute_non_query(query, True, "", "", "", "")
                'update detail and stock
                '
                'Dim sp_check As Boolean = False
                'Dim query_del As String = "SELECT a.id_pl_mrs_det,a.id_wh_drawer,a.id_mat_det_price,b.id_mat_det,a.pl_mrs_det_price,a.pl_mrs_det_qty FROM tb_pl_mrs_det a LEFT JOIN tb_m_mat_det_price b ON a.id_mat_det_price=b.id_mat_det_price WHERE a.id_pl_mrs='" & id_pl_mrs & "'"
                'Dim data_del As DataTable = execute_query(query_del, -1, True, "", "", "", "")
                'If data_del.Rows.Count > 0 Then
                '    For i As Integer = 0 To data_del.Rows.Count - 1
                '        sp_check = False
                '        ' false mean not found, believe me
                '        For j As Integer = 0 To GVDrawer.RowCount - 1
                '            If Not GVDrawer.GetRowCellValue(j, "id_pl_mrs_det").ToString = "" Then
                '                '
                '                If GVDrawer.GetRowCellValue(j, "id_pl_mrs_det").ToString = data_del.Rows(i)("id_pl_mrs_det").ToString() Then
                '                    sp_check = True
                '                End If
                '            End If
                '        Next
                '        'end loop check on gv
                '        If sp_check = False Then
                '            'Because not found, it's only mean already deleted
                '            id_wh_drawer = data_del.Rows(i)("id_wh_drawer").ToString
                '            id_mat_det = data_del.Rows(i)("id_mat_det").ToString
                '            id_mat_det_pricex = data_del.Rows(i)("id_mat_det_price").ToString
                '            pl_mrs_det_price = data_del.Rows(i)("pl_mrs_det_price")
                '            pl_mrs_det_qty = data_del.Rows(i)("pl_mrs_det_qty").ToString
                '            'cancel out storage
                '            query_upd_storage = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det,id_mat_det_price,price, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_stock_status,report_mark_type,id_report) "
                '            query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "','" + id_mat_det_pricex + "','" + decimalSQL(pl_mrs_det_price.ToString) + "', '" + decimalSQL(pl_mrs_det_qty) + "', NOW(), 'PL Edited, PL : " + pl_mrs_number + "','2','30','" + id_pl_mrs + "')"
                '            execute_non_query(query_upd_storage, True, "", "", "", "")
                '            'delete
                '            query = String.Format("DELETE FROM tb_pl_mrs_det WHERE id_pl_mrs_det='{0}'", data_del.Rows(i)("id_pl_mrs_det").ToString())
                '            execute_non_query(query, True, "", "", "", "")
                '        End If
                '    Next
                'End If
                'For i As Integer = 0 To GVDrawer.RowCount - 1
                '    If Not GVDrawer.GetRowCellValue(i, "id_mat_det_price").ToString = "" Then
                '        pl_mrs_det_note = GVDrawer.GetRowCellValue(i, "pl_mrs_det_note").ToString
                '        id_prod_order_mrs_det = GVDrawer.GetRowCellValue(i, "id_prod_order_mrs_det").ToString
                '        pl_mrs_det_qty = GVDrawer.GetRowCellValue(i, "pl_mrs_det_qty").ToString
                '        id_wh_drawer = GVDrawer.GetRowCellValue(i, "id_wh_drawer").ToString
                '        id_mat_det = GVDrawer.GetRowCellValue(i, "id_mat_det").ToString
                '        id_mat_det_pricex = GVDrawer.GetRowCellValue(i, "id_mat_det_price").ToString
                '        pl_mrs_det_price = GVDrawer.GetRowCellValue(i, "pl_mrs_det_price")
                '        If GVDrawer.GetRowCellValue(i, "id_pl_mrs_det").ToString = "" Then
                '            'insert new
                '            'storage
                '            query_upd_storage = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det,id_mat_det_price,price, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_stock_status,report_mark_type,id_report) "
                '            query_upd_storage += "VALUES('" + id_wh_drawer + "', '2', '" + id_mat_det + "','" + id_mat_det_pricex + "','" + decimalSQL(pl_mrs_det_price.ToString) + "', '" + pl_mrs_det_qty + "', NOW(), 'PL Edited, PL : " + pl_mrs_number + "','2','30','" + id_pl_mrs + "')"
                '            execute_non_query(query_upd_storage, True, "", "", "", "")
                '            '
                '            query = String.Format("INSERT INTO tb_pl_mrs_det(id_pl_mrs, pl_mrs_det_note, id_prod_order_mrs_det, pl_mrs_det_qty, id_wh_drawer, pl_mrs_det_price,id_mat_det_price) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_pl_mrs, GVDrawer.GetRowCellValue(i, "pl_mrs_det_note").ToString, GVDrawer.GetRowCellValue(i, "id_prod_order_mrs_det").ToString, decimalSQL(GVDrawer.GetRowCellValue(i, "pl_mrs_det_qty").ToString), GVDrawer.GetRowCellValue(i, "id_wh_drawer").ToString, decimalSQL(GVDrawer.GetRowCellValue(i, "pl_mrs_det_price").ToString), GVDrawer.GetRowCellValue(i, "id_mat_det_price").ToString)
                '            execute_non_query(query, True, "", "", "", "")
                '        Else
                '            'update
                '            'storage cancel first
                '            Dim query_upd As String = "SELECT a.id_pl_mrs_det,a.id_wh_drawer,a.id_mat_det_price,b.id_mat_det,a.pl_mrs_det_price,a.pl_mrs_det_qty FROM tb_pl_mrs_det a LEFT JOIN tb_m_mat_det_price b ON a.id_mat_det_price=b.id_mat_det_price WHERE a.id_pl_mrs_det='" & GVDrawer.GetRowCellValue(i, "id_pl_mrs_det").ToString & "' LIMIT 1"
                '            Dim data_upd As DataTable = execute_query(query_upd, -1, True, "", "", "", "")
                '            query_upd_storage = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det,id_mat_det_price,price, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_stock_status,report_mark_type,id_report) "
                '            query_upd_storage += "VALUES('" + data_upd.Rows(0)("id_wh_drawer").ToString + "', '1', '" + data_upd.Rows(0)("id_mat_det").ToString + "','" + data_upd.Rows(0)("id_mat_det_price").ToString + "','" + decimalSQL(data_upd.Rows(0)("pl_mrs_det_price").ToString) + "', '" + decimalSQL(data_upd.Rows(0)("pl_mrs_det_qty").ToString) + "', NOW(), 'PL Edited, PL : " + pl_mrs_number + "','2','30','" + id_pl_mrs + "')"
                '            execute_non_query(query_upd_storage, True, "", "", "", "")
                '            data_upd.Dispose()
                '            'storage insert out
                '            query_upd_storage = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det,id_mat_det_price,price, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_stock_status,report_mark_type,id_report) "
                '            query_upd_storage += "VALUES('" + id_wh_drawer + "', '2', '" + id_mat_det + "','" + id_mat_det_pricex + "','" + decimalSQL(pl_mrs_det_price.ToString) + "', '" + pl_mrs_det_qty + "', NOW(), 'PL Edited, PL : " + pl_mrs_number + "','2','30','" + id_pl_mrs + "')"
                '            execute_non_query(query_upd_storage, True, "", "", "", "")
                '            '
                '            query = String.Format("UPDATE tb_pl_mrs_det SET pl_mrs_det_note='{0}', pl_mrs_det_qty='{1}', id_wh_drawer='{2}', pl_mrs_det_price='{3}',id_mat_det_price='{4}',id_prod_order_mrs_det='{5}' WHERE id_pl_mrs_det='{6}'", GVDrawer.GetRowCellValue(i, "pl_mrs_det_note").ToString, decimalSQL(GVDrawer.GetRowCellValue(i, "pl_mrs_det_qty").ToString), GVDrawer.GetRowCellValue(i, "id_wh_drawer").ToString, decimalSQL(GVDrawer.GetRowCellValue(i, "pl_mrs_det_price").ToString), GVDrawer.GetRowCellValue(i, "id_mat_det_price").ToString, GVDrawer.GetRowCellValue(i, "id_prod_order_mrs_det").ToString, GVDrawer.GetRowCellValue(i, "id_pl_mrs_det").ToString)
                '            execute_non_query(query, True, "", "", "", "")
                '        End If
                '    End If
                'Next

                infoCustom("PL Updated")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSamplePLDelSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_pl_mrs
        FormReportMark.report_mark_type = "30"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnPopSRS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPopSRS.Click
        FormPopUpMatReq.id_pop_up = "1"
        FormPopUpMatReq.is_other = is_other
        FormPopUpMatReq.ShowDialog()
    End Sub
    'Add Sample based on drawer
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor

        FormPopUpStorageMat.id_wh = id_comp_from
        FormPopUpStorageMat.id_pop_up = "1"
        FormPopUpStorageMat.action = "ins"
        FormPopUpStorageMat.SLEWH.Enabled = False
        FormPopUpStorageMat.SLELocator.Enabled = True
        FormPopUpStorageMat.SLERack.Enabled = True
        FormPopUpStorageMat.SLEDrawer.Enabled = True
        FormPopUpStorageMat.allow_all_locator = True
        FormPopUpStorageMat.allow_all_rack = True
        FormPopUpStorageMat.allow_all_drawer = True
        FormPopUpStorageMat.allow_all_wh = True
        FormPopUpStorageMat.GroupControlInput.Visible = True
        If action = "ins" Then
            FormPopUpStorageMat.id_pl_mrs_det = "0"
        Else
            FormPopUpStorageMat.id_pl_mrs_det = "-1"
        End If
        FormPopUpStorageMat.ShowDialog()
        Cursor = Cursors.Default
    End Sub
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim confirm As String = ""
        confirm = "Are you sure to delete this data?"
        If (MessageBox.Show(confirm, "Delete Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
        Dim id_mat_det As String = GVDrawer.GetFocusedRowCellDisplayText("id_mat_det").ToString
        Dim id_mat_det_price As String = GVDrawer.GetFocusedRowCellDisplayText("id_mat_det_price").ToString
        Dim id_wh_drawer As String = GVDrawer.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
        Dim id_prod_order_mrs_det As String = GVDrawer.GetFocusedRowCellDisplayText("id_prod_order_mrs_det").ToString
        Dim id_pl_mrs_det As String = GVDrawer.GetFocusedRowCellDisplayText("id_pl_mrs_det").ToString
        Dim pl_mrs_det_qty As String = GVDrawer.GetFocusedRowCellDisplayText("pl_mrs_det_qty").ToString
        code_list.Remove(id_mat_det)
        code_list_drawer.Remove(id_wh_drawer)
        deleteRows()

        If GVRoll.RowCount > 0 Then
            For i As Integer = GVRoll.RowCount - 1 To 0 Step -1
                If GVRoll.GetRowCellValue(i, "id_wh_drawer").ToString = id_wh_drawer And GVRoll.GetRowCellValue(i, "id_mat_det_price").ToString = id_mat_det_price Then
                    GVRoll.DeleteRow(i)
                End If
            Next
        End If

        getAmountReq(id_prod_order_mrs_det, False)
    End Sub
    'Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
    'Dim id_wh_locator_curr As String = GVDrawer.GetFocusedRowCellDisplayText("id_wh_locator").ToString
    'Dim id_wh_rack_curr As String = GVDrawer.GetFocusedRowCellDisplayText("id_wh_rack").ToString
    'Dim id_wh_drawer_curr As String = GVDrawer.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
    'Dim id_mat_det_edit As String = GVDrawer.GetFocusedRowCellDisplayText("id_mat_det").ToString
    'Dim qty As Decimal = GVDrawer.GetFocusedRowCellValue("pl_mrs_det_qty")
    'Dim remark As String = GVDrawer.GetFocusedRowCellDisplayText("pl_mrs_det_note").ToString
    'Dim id_pl_mrs_det As String = GVDrawer.GetFocusedRowCellDisplayText("id_pl_mrs_det").ToString
    'FormPopUpStorageMat.TEUnitPrice.EditValue = GVDrawer.GetFocusedRowCellValue("pl_mrs_det_price")
    'FormPopUpStorageMat.id_mat_edit = id_mat_det_edit
    'FormPopUpStorageMat.pl_mrs_det_qty = qty
    'FormPopUpStorageMat.pl_mrs_det_note = remark
    'FormPopUpStorageMat.id_wh_locator_edit = id_wh_locator_curr
    'FormPopUpStorageMat.id_wh_rack_edit = id_wh_rack_curr
    'FormPopUpStorageMat.id_wh_drawer_edit = id_wh_drawer_curr
    'FormPopUpStorageMat.id_wh = id_comp_from
    'FormPopUpStorageMat.id_pop_up = "1"
    'FormPopUpStorageMat.action = "upd"
    'FormPopUpStorageMat.SLEWH.Enabled = False
    'FormPopUpStorageMat.SLELocator.Enabled = True
    'FormPopUpStorageMat.SLERack.Enabled = True
    'FormPopUpStorageMat.SLEDrawer.Enabled = True
    'FormPopUpStorageMat.allow_all_locator = True
    'FormPopUpStorageMat.allow_all_rack = True
    'FormPopUpStorageMat.allow_all_drawer = True
    'FormPopUpStorageMat.allow_all_wh = False
    'FormPopUpStorageMat.GroupControlInput.Visible = True
    'FormPopUpStorageMat.id_pl_mrs_det = id_pl_mrs_det
    'FormPopUpStorageMat.BtnChoose.Text = "Update"
    'FormPopUpStorageMat.ShowDialog()
    'End Sub
    'Color Cell
    Public Sub test_aw(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White

        id_prod_order_mrs_det_style = GVDetail.GetFocusedRowCellValue("id_prod_order_mrs_det").ToString
        Dim id_prod_order_mrs_det_check As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("id_prod_order_mrs_det"))
        If id_prod_order_mrs_det_check = id_prod_order_mrs_det_style Then
            e.Appearance.BackColor = Color.SpringGreen
            e.Appearance.BackColor2 = Color.White
        End If
    End Sub
    Private Sub RepositoryItemSpinEdit2_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim SpQty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
            Dim qty_rec As Decimal = Decimal.Parse(SpQty.Text.ToString)
            Dim qty_limit As Decimal = Decimal.Parse(GVDrawer.GetFocusedRowCellDisplayText("qty_all_mat").ToString)
            Dim current_name As String = GVDrawer.GetFocusedRowCellDisplayText("name").ToString
            Dim current_uom As String = GVDrawer.GetFocusedRowCellDisplayText("uom").ToString
            If qty_rec > qty_limit Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Material : '" + current_name + "', cannot exceed " + qty_limit.ToString + " " + current_uom + " ! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                GVDrawer.SetFocusedRowCellValue("pl_mrs_det_qty", 0.0)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub getAmountReq(ByVal id_prod_order_mrs_det As String, ByVal is_sum_req As Boolean) 'get amount to detail
        Dim qty_sum As Decimal = 0
        For i As Integer = 0 To (GVDrawer.RowCount - 1)
            Try
                Dim qty As Decimal = Decimal.Parse(GVDrawer.GetRowCellValue(i, "pl_mrs_det_qty").ToString)
                Dim id_prod_order_mrs_det_data As String = GVDrawer.GetRowCellValue(i, "id_prod_order_mrs_det").ToString
                If id_prod_order_mrs_det_data = id_prod_order_mrs_det Then
                    qty_sum = qty + qty_sum
                End If
            Catch ex As Exception

            End Try
        Next
        GVDetail.FocusedRowHandle = find_row(GVDetail, "id_prod_order_mrs_det", id_prod_order_mrs_det)
        If Not is_sum_req Then
            GVDetail.SetFocusedRowCellValue("qty_real_mat", qty_sum)
        Else
            Dim qty_requisition As Decimal = Decimal.Parse(GVDetail.GetFocusedRowCellDisplayText("prod_order_mrs_det_qty").ToString)
            Dim tot As Decimal = qty_requisition + qty_sum
            GVDetail.SetFocusedRowCellValue("qty_real_mat", qty_sum)
            GVDetail.SetFocusedRowCellValue("prod_order_mrs_det_qty", tot)
        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        ReportPLMat.id_pl_mrs = id_pl_mrs
        Dim Report As New ReportPLMat()
        '
        If Not id_report_status = "6" Then
            Report.is_pre = "1"
        End If
        '
        If LEPLType.EditValue.ToString = "2" Then
            Report.is_sell = "1"
        End If
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub RepositoryItemSpinEdit1_EditValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepositoryItemSpinEdit1.EditValueChanged
        Try
            Dim SpQty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
            Dim qty_rec As Decimal = Decimal.Parse(SpQty.Text.ToString)
            Dim qty_requisition As Decimal = Decimal.Parse(GVDrawer.GetFocusedRowCellDisplayText("prod_order_mrs_det_qty").ToString)
            Dim qty_available As Decimal = Decimal.Parse(GVDrawer.GetFocusedRowCellDisplayText("qty_all_mat").ToString)
            Dim current_name As String = GVDrawer.GetFocusedRowCellDisplayText("name").ToString
            Dim uom As String = GVDrawer.GetFocusedRowCellDisplayText("uom").ToString
            If qty_rec > qty_requisition Or qty_rec > qty_available Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Error : " + vbNewLine + "- Qty cannot exceed qty requisition " + vbNewLine + "- Qty cannot exceed qty available ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                GVDrawer.SetFocusedRowCellValue("pl_mrs_det_qty", 0.0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GVDrawer_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs)
        cantEdit()
    End Sub

    Private Sub GVDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDetail.FocusedRowChanged
        AddHandler GVDrawer.RowCellStyle, AddressOf test_aw
        GCDrawer.RefreshDataSource()
        GVDrawer.RefreshData()
    End Sub

    Private Sub GVDetail_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVDetail.RowClick
        AddHandler GVDrawer.RowCellStyle, AddressOf test_aw
        GCDrawer.RefreshDataSource()
        GVDrawer.RefreshData()
    End Sub

    Private Sub BtnPopSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPopSource.Click
        FormPopUpContact.id_pop_up = "28"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnInfoSrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInfoSrs.Click
        infoSrs()
    End Sub

    Sub isAllowRequisition(ByVal mat_det_name As String, ByVal id_prod_order_mrs_det_cek As String, ByVal qty_plx As String)
        cond_check = True
        qty_pl = Decimal.Parse(qty_plx.ToString)
        qty_pl = Decimal.Parse(qty_plx.ToString)
        mat_check = mat_det_name
        Dim query_check As String = ""
        query_check += "  SELECT (a.prod_order_mrs_det_qty - COALESCE((SELECT SUM(pl_mrs_det_qty) FROM tb_pl_mrs_det pld INNER JOIN tb_pl_mrs pl ON pl.id_pl_mrs=pld.id_pl_mrs WHERE pld.id_prod_order_mrs_det=a.id_prod_order_mrs_det AND pl.id_report_status!='5' "
        If action = "upd" Then
            query_check += " AND pl.id_pl_mrs !='" + id_pl_mrs + "' "
        End If
        query_check += " ),0)) AS jml FROM "
        query_check += " tb_prod_order_mrs_det a "
        query_check += " INNER JOIN tb_prod_order_mrs b ON a.id_prod_order_mrs=b.id_prod_order_mrs "
        query_check += " WHERE a.id_prod_order_mrs_det = '" + id_prod_order_mrs_det_cek + "'"

        allow_sum = Decimal.Parse(execute_query(query_check, 0, True, "", "", "", ""))
        If qty_pl > allow_sum Then
            cond_check = False
        End If
    End Sub

    Sub infoSrs()
        Cursor = Cursors.WaitCursor
        FormInfoMRSPord.id_mrs = id_mrs
        FormInfoMRSPord.LabelSubTitle.Text = "MRS No : " + TxtSRSNumber.Text + ""
        FormInfoMRSPord.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_mrs
        FormDocumentUpload.report_mark_type = "30"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddRoll.Click
        If GVDrawer.RowCount > 0 Then
            Dim newRow As DataRow = (TryCast(GCRoll.DataSource, DataTable)).NewRow()
            newRow("id_mat_det_price") = GVDrawer.GetFocusedRowCellValue("id_mat_det_price").ToString
            newRow("id_wh_drawer") = GVDrawer.GetFocusedRowCellValue("id_wh_drawer").ToString
            newRow("wh_drawer") = GVDrawer.GetFocusedRowCellValue("wh_drawer").ToString
            newRow("name") = GVDrawer.GetFocusedRowCellValue("name").ToString
            newRow("code") = GVDrawer.GetFocusedRowCellValue("code").ToString
            newRow("qty") = 0.0
            TryCast(GCRoll.DataSource, DataTable).Rows.Add(newRow)
            GCRoll.RefreshDataSource()
            GVRoll.RefreshData()
            GVRoll.FocusedRowHandle = GVRoll.RowCount - 1
            GVRoll.FocusedColumn = GVRoll.Columns("piece")
            GVRoll.ShowEditor()
        End If
    End Sub
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelRoll.Click
        If GVRoll.RowCount > 0 Then
            GVRoll.DeleteSelectedRows()
            calculate_qty_rec()
        End If
    End Sub

    Sub calculate_qty_rec()
        If GVDetail.RowCount > 0 Then
            For i As Integer = 0 To GVDrawer.RowCount - 1
                Dim qty_rec As Decimal = 0.0
                Dim unit_price As Decimal = 0.0

                unit_price = GVDrawer.GetRowCellValue(i, "pl_mrs_det_price")

                For j As Integer = 0 To GVRoll.RowCount - 1
                    If GVDrawer.GetRowCellValue(i, "id_mat_det_price").ToString = GVRoll.GetRowCellValue(j, "id_mat_det_price").ToString And GVDrawer.GetRowCellValue(i, "id_wh_drawer").ToString = GVRoll.GetRowCellValue(j, "id_wh_drawer").ToString Then
                        qty_rec += GVRoll.GetRowCellValue(j, "qty")
                    End If
                Next
                GVDrawer.SetRowCellValue(i, "total_price", qty_rec * unit_price)
                GVDrawer.SetRowCellValue(i, "pl_mrs_det_qty", qty_rec)
                getAmountReq(GVDrawer.GetRowCellValue(i, "id_prod_order_mrs_det").ToString, False)
            Next
        End If

        If GVRoll.RowCount > 0 Then
            BDelRoll.Visible = True
        Else
            BDelRoll.Visible = False
        End If
    End Sub

    Sub view_list_pcs()
        Dim query = "CALL view_pl_mrs_pcs('" & id_pl_mrs & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRoll.DataSource = data
        calculate_qty_rec()
    End Sub

    Sub view_list_pcs_empty()
        Dim query = "CALL view_pl_mrs_pcs(-1)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRoll.DataSource = data

        BDelRoll.Visible = False
    End Sub

    Private Sub GVRoll_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVRoll.CellValueChanged
        calculate_qty_rec()
    End Sub

    Private Sub GVRoll_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRoll.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class