Public Class FormMailManageReturn
    Public already_open_invoice As Boolean = False

    Private Sub FormMailManageReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_group_store()
    End Sub

    Sub load_group_store()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS id_comp_group, 'Select Group' AS comp_group, 'Select Group' AS description 
        UNION
        SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg "
        viewSearchLookupQuery(SLEStoreGroup, query, "id_comp_group", "comp_group", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub load_store_company()
        Cursor = Cursors.WaitCursor
        Dim id_comp_group As String = "-1"
        Try
            id_comp_group = SLEStoreGroup.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT cg.id_comp_group, c.id_comp,c.comp_name 
        FROM tb_m_comp_group cg 
        INNER JOIN tb_m_comp c ON c.id_comp = cg.id_comp 
        WHERE cg.id_comp_group=" + id_comp_group + " 
        UNION ALL 
        SELECT cg.id_comp_group, c.id_comp,c.comp_name 
        FROM tb_m_comp_group_other cg INNER JOIN tb_m_comp c ON c.id_comp = cg.id_comp 
        WHERE cg.id_comp_group=" + id_comp_group + " "
        viewSearchLookupQuery(SLEStoreCompany, query, "id_comp", "comp_name", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEStoreGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreGroup.EditValueChanged
        load_store_company()
        GCReturnOrder.DataSource = Nothing
        BCreatePO.Visible = False
    End Sub

    Private Sub SLEStoreCompany_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreCompany.EditValueChanged
        GCReturnOrder.DataSource = Nothing
        BCreatePO.Visible = False
    End Sub

    Sub loadDateNow()
        Dim dt_now As DataTable = execute_query("SELECT DATE(NOW()) AS tgl", -1, True, "", "", "", "")

        DEFromList.EditValue = dt_now.Rows(0)("tgl")
        DEUntilList.EditValue = dt_now.Rows(0)("tgl")
    End Sub

    Private Sub BViewPayment_Click(sender As Object, e As EventArgs) Handles BViewPayment.Click
        viewMailManage()
    End Sub

    Sub viewMailManage()
        Cursor = Cursors.WaitCursor

        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromList.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilList.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim mm As New ClassMailManageReturn()
        Dim query As String = mm.queryMain("AND (DATE(m.created_date)>='" + date_from_selected + "' AND DATE(m.created_date)<='" + date_until_selected + "') ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPending_Click(sender As Object, e As EventArgs) Handles BtnPending.Click
        viewPendingInvoice()
    End Sub

    Sub viewPendingInvoice()
        GVReturnOrder.Columns("mail_number").Visible = False
        GVReturnOrder.Columns("mail_date").Visible = False
        GVReturnOrder.Columns("mail_status").Visible = False
        loadInvoice("AND a.is_pending_mail=1 ")
        BCreatePO.Visible = True
    End Sub

    Sub loadInvoice(ByVal cond As String)
        Cursor = Cursors.WaitCursor
        Dim id_comp_group As String = SLEStoreGroup.EditValue.ToString
        Dim id_store_company As String = SLEStoreCompany.EditValue.ToString

        If id_comp_group = "0" Then
            stopCustom("Please select store group first")
        Else
            Dim query As String = "
                SELECT 'no' AS is_check, a.id_sales_return_order, a.id_store_contact_to, CONCAT(d.comp_number, ' - ', d.comp_name) AS store_name_to, a.sales_return_order_note, a.sales_return_order_note, a.sales_return_order_number, DATE_FORMAT(a.sales_return_order_date, '%d %M %Y') AS sales_return_order_date, DATE_FORMAT(a.sales_return_order_est_date,'%d %M %Y') AS sales_return_order_est_date, ot.order_type, em.id_mail_manage, em.mail_number, em.mail_date, em.mail_status, SUM(b.design_price * b.sales_return_order_det_qty) AS amount
                FROM tb_sales_return_order a
                INNER JOIN tb_sales_return_order_det b ON a.id_sales_return_order = b.id_sales_return_order
                INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to 
                INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
                LEFT JOIN tb_lookup_order_type ot ON ot.id_order_type = a.id_order_type
                LEFT JOIN (
                    SELECT m.id_mail_manage, m.number AS mail_number, m.updated_date AS mail_date, md.id_report, stt.mail_status
                    FROM tb_mail_manage_det md
                    INNER JOIN tb_mail_manage m ON m.id_mail_manage = md.id_mail_manage
                    INNER JOIN tb_lookup_mail_status stt ON stt.id_mail_status = m.id_mail_status
                    WHERE m.report_mark_type = 45 AND m.id_mail_status != 4
                    GROUP BY md.id_report
                ) em ON em.id_report = a.id_sales_return_order
                WHERE ISNULL(a.id_sales_order) AND a.is_on_hold = 2 AND a.id_report_status = 6 AND d.id_comp_group='" + id_comp_group + "' AND d.id_store_company='" + id_store_company + "'
                " + cond + "
                GROUP BY a.id_sales_return_order
                ORDER BY a.id_sales_return_order ASC
            "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCReturnOrder.DataSource = data
            GVReturnOrder.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAlreadyProcessed_Click(sender As Object, e As EventArgs) Handles BtnAlreadyProcessed.Click
        GVReturnOrder.Columns("mail_number").VisibleIndex = 1
        GVReturnOrder.Columns("mail_date").VisibleIndex = 2
        GVReturnOrder.Columns("mail_status").VisibleIndex = 3
        loadInvoice("AND a.is_pending_mail=2 ")
        BCreatePO.Visible = False
    End Sub

    Private Sub BtnPendingGroup_Click(sender As Object, e As EventArgs) Handles BtnPendingGroup.Click
        viewPendingMailGroup()
    End Sub

    Sub viewPendingMailGroup()
        Cursor = Cursors.WaitCursor
        FormMailManageReturnPendingInvoice.rmt = "45"
        FormMailManageReturnPendingInvoice.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BCreatePO_Click(sender As Object, e As EventArgs) Handles BCreatePO.Click
        Dim id_comp_group As String = SLEStoreGroup.EditValue.ToString
        Dim id_store_company As String = SLEStoreCompany.EditValue.ToString
        If id_comp_group <> "0" Then
            Cursor = Cursors.WaitCursor
            '--- check email group
            Dim qcg As String = "-- cari to untuk group toko
            SELECT cc.email AS `email_group`
            FROM tb_mail_manage_mapping m
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = m.id_comp_contact
            WHERE m.id_comp_group=" + id_comp_group + " AND cc.id_comp='" + id_store_company + "' AND m.report_mark_type=45 AND m.id_mail_member_type=2 AND cc.email!='' "
            Dim dcg As DataTable = execute_query(qcg, -1, True, "", "", "", "")
            If dcg.Rows.Count <= 0 Then
                Cursor = Cursors.Default
                stopCustom("Email store group not found. Please mapping email first.")
                Exit Sub
            End If

            '-- check email from (internal)
            Dim qci As String = "-- cari internal from
            SELECT e.email_external
            FROM tb_mail_manage_mapping_intern i
            INNER JOIN tb_m_user u ON u.id_user = i.id_user
            INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
            WHERE i.report_mark_type=45 AND i.id_mail_member_type=1 AND e.email_external!='' "
            Dim dci As DataTable = execute_query(qci, -1, True, "", "", "", "")
            If dci.Rows.Count <= 0 Then
                Cursor = Cursors.Default
                stopCustom("Email from not found. Please mapping email first.")
                Exit Sub
            End If


            '---filter check
            makeSafeGV(GVReturnOrder)
            GVReturnOrder.ActiveFilterString = "[is_check]='yes'"
            If GVReturnOrder.RowCount > 0 Then
                'load detil form
                FormMailManageReturnDet.rmt = "45"
                FormMailManageReturnDet.action = "ins"
                FormMailManageReturnDet.ShowDialog()
            Else
                stopCustom("No data selected")
            End If


            GVReturnOrder.ActiveFilterString = ""
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormMailManageReturn_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormMailManageReturn_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub XTCMailManage_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCMailManage.SelectedPageChanged
        If XTCMailManage.SelectedTabPageIndex = 1 Then
            If Not already_open_invoice Then
                'load pending invoice
                FormMailManageReturnPendingInvoice.show_direct = True
                viewPendingMailGroup()
            End If
        End If
    End Sub

    Private Sub CESelectAllInvoice_CheckedChanged(sender As Object, e As EventArgs) Handles CESelectAllInvoice.CheckedChanged
        Dim val As String = ""
        If CESelectAllInvoice.EditValue = True Then
            val = "yes"
        Else
            val = "no"
        End If

        For i As Integer = 0 To GVReturnOrder.RowCount - 1
            GVReturnOrder.SetRowCellValue(i, "is_check", val)
        Next
    End Sub

    Private Sub GCData_DoubleClick(sender As Object, e As EventArgs) Handles GCData.DoubleClick
        FormMain.but_edit()
    End Sub
End Class