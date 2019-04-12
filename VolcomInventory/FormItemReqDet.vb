Public Class FormItemReqDet
    Public id As String = "-1"
    Public action As String = ""
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim created_date As String = ""
    Public is_for_store As String = "2"
    Dim rmt As String = ""


    Private Sub FormItemReqDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            'REQ detail
            TxtNumber.Text = "[auto generate]"
            DECreated.EditValue = getTimeDB()
            TxtDept.Text = get_departement_x(id_departement_user, "1")
            TxtRequestedBy.Text = get_user_identify(id_user, "1")

            'menu
            If is_for_store = "1" Then
                XTPDetail.PageVisible = True
                PanelControlNav.Visible = False
                viewDetailAlloc()
                XTCRequest.SelectedTabPageIndex = 1
                GridColumnQty.OptionsColumn.AllowEdit = False
                rmt = "163"
            ElseIf is_for_store = "2" Then
                XTPDetail.PageVisible = False
                rmt = "154"
            End If
            viewDetail()
        Else
            Dim r As New ClassItemRequest()
            Dim query As String = r.queryMain("AND r.id_item_req='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtNumber.Text = data.Rows(0)("number").ToString
            created_date = DateTime.Parse(data.Rows(0)("created_date")).ToString("yyyy-MM-dd HH:mm:ss")
            DECreated.EditValue = data.Rows(0)("created_date")
            MENote.Text = data.Rows(0)("note").ToString
            TxtDept.Text = data.Rows(0)("departement").ToString
            TxtRequestedBy.Text = data.Rows(0)("created_by_name").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            is_for_store = data.Rows(0)("is_for_store").ToString
            If is_for_store = "1" Then
                XTPDetail.PageVisible = True
                XTCRequest.SelectedTabPageIndex = 1
                rmt = "163"
                viewDetailAlloc()
            ElseIf is_for_store = "2" Then
                XTPDetail.PageVisible = False
                rmt = "154"
            End If

            viewDetail()
            allow_status()
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = "SELECT rd.id_item_req_det, rd.id_item_req, rd.id_item, i.item_desc, u.uom, rd.qty, rd.remark 
        FROM tb_item_req_det rd
        INNER JOIN tb_item i ON i.id_item = rd.id_item
        INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
        WHERE rd.id_item_req=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
    End Sub

    Sub viewDetailAlloc()
        Dim query As String = "SELECT a.id_item_req_det_alloc, a.id_item_req, a.id_item, i.item_desc, a.id_comp,c.comp_number, c.comp_name, a.qty, a.remark 
        FROM tb_item_req_det_alloc a
        INNER JOIN tb_item i ON i.id_item = a.id_item
        INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
        INNER JOIN tb_m_comp c ON c.id_comp = a.id_comp
        WHERE a.id_item_req=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
    End Sub

    Sub generateSummary()
        Cursor = Cursors.WaitCursor
        viewDetail()
        makeSafeGV(GVDetail)

        If GVDetail.RowCount > 0 Then
            'default view
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVDetail.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'group
            GridColumnCombine.GroupIndex = 0
            GVDetail.CollapseAllGroups()

            'isi summary
            For i As Integer = 1 To GetGroupRowCount(GVDetail)
                Dim rh As Integer = i * -1
                Dim val1 As Decimal = Convert.ToDecimal(GVDetail.GetGroupSummaryValue(rh, TryCast(GVDetail.GroupSummary(0), DevExpress.XtraGrid.GridGroupSummaryItem)))
                Dim head() As String = Split(GVDetail.GetGroupRowValue(rh).ToString, "#*mt*#")
                Dim newRow As DataRow = (TryCast(GCData.DataSource, DataTable)).NewRow()
                newRow("id_item") = head(0)
                newRow("item_desc") = head(1)
                newRow("qty") = val1
                newRow("remark") = ""
                TryCast(GCData.DataSource, DataTable).Rows.Add(newRow)
                GCData.RefreshDataSource()
                GVData.RefreshData()
            Next

            ''restore to default view
            GVDetail.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
        End If
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnCancell.Visible = True
        BtnMark.Visible = True
        BtnAttachment.Visible = True
        BtnPrint.Visible = True
        GVData.OptionsBehavior.Editable = False
        PanelControlNav.Visible = False
        PanelControlNavDetail.Visible = False

        If check_edit_report_status(id_report_status, rmt, id) Then
            BtnSave.Visible = False
            MENote.Enabled = True
        Else
            BtnSave.Visible = False
            MENote.Enabled = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = True
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
        End If
    End Sub

    Private Sub FormItemReqDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Function checkDel() As Boolean
        Dim query As String = "SELECT * FROM tb_item_del d WHERE d.id_item_req=" + id + " AND d.id_report_status!=5"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim is_delivery As Boolean = checkDel()
        If Not is_delivery Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancell this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update status
                Dim query As String = "UPDATE tb_item_req SET id_report_status=5 WHERE id_item_req='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'nonaktif mark
                Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id, "5")
                execute_non_query(queryrm, True, "", "", "", "")

                'cancell out stock (in stock)
                Dim rs As New ClassItemRequest()
                rs.updateStock(id, 1, rmt)

                'refresh
                FormItemReq.viewData()
                FormItemReq.GVData.FocusedRowHandle = find_row(FormItemReq.GVData, "id_item_req", id)
                actionLoad()
                Cursor = Cursors.Default
            End If
        Else
            warningCustom("Cannot cancel this request because this request has been processed")
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        If id_report_status = "6" Then
            Dim title As String = ""
            Dim gcx As DevExpress.XtraGrid.GridControl = Nothing
            Dim gvx As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            If XTCRequest.SelectedTabPageIndex = 0 Then
                gcx = GCData
                gvx = GVData
                title = "ITEM REQUEST"
            ElseIf XTCRequest.SelectedTabPageIndex = 1 Then
                gcx = GCDetail
                gvx = GVDetail
                title = "ITEM REQUEST FOR STORE"
            End If
            ReportItemReq.rmt = rmt
            ReportItemReq.id = id
            ReportItemReq.dt = gcx.DataSource
            Dim Report As New ReportItemReq()

            '' '... 
            '' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            gvx.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            ''Grid Detail
            ReportStyleGridview(Report.GVData)

            ''    'Parse val
            Report.LabelTitle.Text = title
            Report.LabelNumber.Text = TxtNumber.Text.ToUpper
            Report.LabelDept.Text = TxtDept.Text.ToUpper
            Report.LabelDate.Text = DECreated.Text.ToString
            Report.LNote.Text = MENote.Text.ToString


            ''    'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        Else
            If XTCRequest.SelectedTabPageIndex = 0 Then
                print_raw_no_export(GCData)
            ElseIf XTCRequest.SelectedTabPageIndex = 1 Then
                print_raw_no_export(GCDetail)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        attach
    End Sub

    Sub attach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id
        Dim is_delivery As Boolean = checkDel()
        If is_delivery Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = rmt
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'cek stok
        Cursor = Cursors.WaitCursor
        XTCRequest.SelectedTabPageIndex = 0
        GridColumnStt.Visible = False
        makeSafeGV(GVData)
        Dim cond_data As Boolean = True
        Dim st As New ClassPurcItemStock()
        Dim qst As String = st.queryGetStock("AND i.id_departement='" + id_departement_user + "' ", "9999-12-31")
        Dim dst As DataTable = execute_query(qst, -1, True, "", "", "", "")
        For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
            Dim id_item_cek As String = GVData.GetRowCellValue(i, "id_item").ToString
            Dim dt As DataRow() = dst.Select("[id_item]='" + id_item_cek + "' ")
            If dt.Length <= 0 Then
                GVData.SetRowCellValue(i, "stt", "Product not found;")
                cond_data = False
            Else
                If GVData.GetRowCellValue(i, "qty") > dt(0)("qty") Then
                    GVData.SetRowCellValue(i, "stt", "Qty can't exceed " + dt(0)("qty").ToString + ";")
                    cond_data = False
                Else
                    GVData.SetRowCellValue(i, "stt", "")
                End If
            End If
        Next
        makeSafeGV(GVData)
        GCData.RefreshDataSource()
        GVData.RefreshData()
        Cursor = Cursors.Default

        If GVData.Columns("qty").SummaryItem.SummaryValue <= 0 Then
            warningCustom("Please complete all data")
        ElseIf Not cond_data Then
            GridColumnStt.VisibleIndex = 20
            GVData.BestFitColumns()
            warningCustom("Can't save, some item exceed limit qty")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                BtnSave.Enabled = False
                Dim note As String = addSlashes(MENote.Text)

                'query main
                Dim qm As String = "INSERT INTO tb_item_req(id_departement, created_date, created_by, note, id_report_status, is_for_store) VALUES
                (" + id_departement_user + ", NOW(), " + id_user + ", '" + note + "', 6, '" + is_for_store + "'); SELECT LAST_INSERT_ID(); "
                id = execute_query(qm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id + "," + rmt + "); ", True, "", "", "", "")

                'query det
                Dim qd As String = "INSERT INTO tb_item_req_det(id_item_req, id_item, qty, remark) VALUES "
                For d As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                    Dim id_item As String = GVData.GetRowCellValue(d, "id_item").ToString
                    Dim qty As String = decimalSQL(GVData.GetRowCellValue(d, "qty").ToString)
                    Dim remark As String = addSlashes(GVData.GetRowCellValue(d, "remark").ToString)

                    If d > 0 Then
                        qd += ", "
                    End If
                    qd += "(" + id + ", " + id_item + ", '" + qty + "', '" + remark + "') "
                Next
                If GVData.RowCount > 0 Then
                    execute_non_query(qd, True, "", "", "", "")
                End If

                'query allocation
                If is_for_store = "1" Then
                    Dim qa As String = "INSERT INTO tb_item_req_det_alloc(id_item_req, id_item, id_comp, qty, remark) VALUES "
                    For a As Integer = 0 To ((GVDetail.RowCount - 1) - GetGroupRowCount(GVDetail))
                        Dim id_item As String = GVDetail.GetRowCellValue(a, "id_item").ToString
                        Dim id_comp As String = GVDetail.GetRowCellValue(a, "id_comp").ToString
                        Dim qty As String = decimalSQL(GVDetail.GetRowCellValue(a, "qty").ToString)
                        Dim remark As String = addSlashes(GVDetail.GetRowCellValue(a, "remark").ToString)

                        If a > 0 Then
                            qa += ", "
                        End If
                        qa += "(" + id + ", " + id_item + ",'" + id_comp + "', '" + qty + "', '" + remark + "') "
                    Next
                    If GVDetail.RowCount > 0 Then
                        execute_non_query(qa, True, "", "", "", "")
                    End If
                End If


                'out stock
                Dim rs As New ClassItemRequest()
                rs.updateStock(id, 2, rmt)

                'submit
                submit_who_prepared(rmt, id, id_user)

                'refresh
                FormItemReq.viewData()
                GVData.FocusedRowHandle = find_row(FormItemReq.GVData, "id_item_req", id)
                action = "upd"
                actionLoad()
                infoCustom("Item Request : " + TxtNumber.Text.ToString + " was created successfully")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormItemReqAdd.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this item ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVData.DeleteRow(GVData.FocusedRowHandle)
                CType(GCData.DataSource, DataTable).AcceptChanges()
                GCData.RefreshDataSource()
                GVData.RefreshData()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnDelDetail_Click(sender As Object, e As EventArgs) Handles BtnDelDetail.Click
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this item ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVDetail.DeleteRow(GVDetail.FocusedRowHandle)
                CType(GCDetail.DataSource, DataTable).AcceptChanges()
                GCDetail.RefreshDataSource()
                GVDetail.RefreshData()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnAddDetail_Click(sender As Object, e As EventArgs) Handles BtnAddDetail.Click
        Cursor = Cursors.WaitCursor
        FormItemReqAddStore.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub XTCRequest_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCRequest.SelectedPageChanged
        If XTCRequest.SelectedTabPageIndex = 0 And action = "ins" And is_for_store = "1" Then
            generateSummary()
        End If
    End Sub
End Class