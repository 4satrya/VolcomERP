Public Class FormSalesReturnOrderMailDet
    Public id_mail_3pl As String = "-1"

    Private loaded As Boolean = False

    Private data_from As DataTable = New DataTable
    Private data_to As DataTable = New DataTable
    Private data_cc As DataTable = New DataTable
    Private data_subject As DataTable = New DataTable

    Private Sub FormSalesReturnOrderMailDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_type()
        view_city()
        view_sub_district()
        view_status()
        view_store()
        view_del_type()
        view_3pl()
        view_employee()

        load_form()

        loaded = True
    End Sub

    Sub load_form()
        If id_mail_3pl = "-1" Then
            'head
            TxtNumber.EditValue = "[autogenerate]"
            DECreatedDate.EditValue = Now
            TxtCreatedBy.EditValue = get_emp(id_employee_user, "2")

            'detail
            GCDetail.DataSource = execute_query("
                SELECT s.id_sales_return_order, 0 AS `no`, s.sales_return_order_number, CONCAT(e.comp_number, ' - ', e.comp_name) AS store_name_to, IFNULL(i.return_qty, 0) AS return_qty, s.sales_return_order_note
                FROM tb_sales_return_order_mail_3pl_det AS d
                LEFT JOIN tb_sales_return_order AS s ON d.id_sales_order_return = s.id_sales_return_order
                LEFT JOIN tb_m_comp_contact AS c ON c.id_comp_contact = s.id_store_contact_to
                LEFT JOIN tb_m_comp AS e ON c.id_comp = e.id_comp 
                LEFT JOIN (
                    SELECT rt.id_sales_return_order, SUM(rt_det.sales_return_det_qty) AS return_qty 
                    FROM tb_sales_return AS rt
                    INNER JOIN tb_sales_return_det AS rt_det ON rt.id_sales_return = rt_det.id_sales_return 
                    WHERE rt.id_report_status = 6
                    GROUP BY rt.id_sales_return_order 
                ) AS i ON i.id_sales_return_order = s.id_sales_return_order
                WHERE s.id_sales_return_order = -1", -1, True, "", "", "", "")

            Dim in_store As String = CCBEStore.EditValue.ToString

            If in_store = "" Then
                in_store = "0"
            End If

            'from
            data_from = execute_query("
                SELECT e.employee_name AS name, e.employee_position AS `position`, e.email_external AS email
                FROM tb_mail_manage_mapping_intern AS m
                INNER JOIN tb_m_user AS u ON u.id_user = m.id_user
                INNER JOIN tb_m_employee AS e ON e.id_employee = u.id_employee
                WHERE m.report_mark_type = 276 AND m.id_mail_member_type = 1 AND (ISNULL(m.id_comp_group) OR m.id_comp_group IN (SELECT id_comp_group FROM tb_m_comp WHERE id_comp IN (" + in_store + ")))

                UNION

                SELECT c.contact_person AS name, c.position AS `position`, c.email
                FROM tb_mail_manage_mapping AS m
                INNER JOIN tb_m_comp_contact AS c ON c.id_comp_contact = m.id_comp_contact
                WHERE m.report_mark_type = 276 AND m.id_mail_member_type = 1 AND (ISNULL(m.id_comp_group) OR m.id_comp_group IN (SELECT id_comp_group FROM tb_m_comp WHERE id_comp IN (" + in_store + ")))
            ", -1, True, "", "", "", "")

            'to
            Dim id_3pl_rate As String = "0"

            Try
                id_3pl_rate = SLUE3PL.EditValue.ToString
            Catch ex As Exception
            End Try

            data_to = execute_query("
                SELECT c.comp_name AS name, cc.email
                FROM tb_m_comp_contact AS cc
                LEFT JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
                WHERE cc.id_comp = (SELECT id_comp FROM tb_3pl_rate WHERE id_3pl_rate = " + id_3pl_rate + ") AND cc.is_default = 1
            ", -1, True, "", "", "", "")

            'cc
            data_cc = execute_query("
                SELECT e.employee_name AS name, e.employee_position AS `position`, e.email_external AS email
                FROM tb_mail_manage_mapping_intern AS m
                INNER JOIN tb_m_user AS u ON u.id_user = m.id_user
                INNER JOIN tb_m_employee AS e ON e.id_employee = u.id_employee
                WHERE m.report_mark_type = 276 AND m.id_mail_member_type = 3 AND (ISNULL(m.id_comp_group) OR m.id_comp_group IN (SELECT id_comp_group FROM tb_m_comp WHERE id_comp IN (" + in_store + ")))

                UNION

                SELECT c.contact_person AS name, c.position AS `position`, c.email
                FROM tb_mail_manage_mapping AS m
                INNER JOIN tb_m_comp_contact AS c ON c.id_comp_contact = m.id_comp_contact
                WHERE m.report_mark_type = 276 AND m.id_mail_member_type = 3 AND (ISNULL(m.id_comp_group) OR m.id_comp_group IN (SELECT id_comp_group FROM tb_m_comp WHERE id_comp IN (" + in_store + ")))
            ", -1, True, "", "", "", "")

            'subject
            data_subject = New DataTable

            data_subject.Columns.Add("subject", GetType(String))

            data_subject.Rows.Add(get_setup_field("sales_return_order_3pl_subject"))

            'controls
            If SLUEType.EditValue.ToString = "1" Then
                SBAccept.Visible = False
                SBDecline.Visible = False
                SBSend.Visible = False
                SBOther3PL.Visible = False
                SBSendApprove.Visible = False
                SBCancel.Visible = False

                SBSubmit.Visible = True
                SBApprove.Visible = False
                SBPrint.Visible = False
            Else
                SBAccept.Visible = False
                SBDecline.Visible = False
                SBSend.Visible = True
                SBOther3PL.Visible = False
                SBSendApprove.Visible = False
                SBCancel.Visible = False

                SBSubmit.Visible = False
                SBApprove.Visible = False
                SBPrint.Visible = False
            End If
        Else
            'head
            Dim query As String = "
                SELECT m.number, m.id_status, m.created_date, ec.employee_name AS created_by, m.updated_date, eu.employee_name AS updated_by, s.id_store, m.id_city, m.id_sub_district, a.address_primary, m.estimate_weight, m.estimate_qty, m.pick_up_date, m.wh_receive_date, m.id_del_type, m.id_3pl_rate, r.cargo_rate, r.cargo_min_weight, m.subject_request, m.from_request, m.to_request, m.cc_request, m.body_request, m.subject_accept, m.from_accept, m.to_accept, m.cc_accept, m.body_accept
                FROM tb_sales_return_order_mail_3pl AS m
                LEFT JOIN tb_m_employee AS ec ON m.created_by = ec.id_employee
                LEFT JOIN tb_m_employee AS eu ON m.updated_by = eu.id_employee
                LEFT JOIN tb_3pl_rate AS r ON m.id_3pl_rate = r.id_3pl_rate
                LEFT JOIN (
                    SELECT address_primary
                    FROM tb_m_comp
                    WHERE id_comp = (
                        SELECT MIN(id_comp) AS id_store
                        FROM tb_sales_return_order_mail_3pl_store AS p
                        WHERE id_mail_3pl = " + id_mail_3pl + "
                    )
                ) AS a ON 1 = 1
                LEFT JOIN (
                    SELECT GROUP_CONCAT(id_comp SEPARATOR ', ') AS id_store
                    FROM tb_sales_return_order_mail_3pl_store
                    WHERE id_mail_3pl = " + id_mail_3pl + "
                ) AS s ON 1 = 1
                WHERE m.id_mail_3pl = " + id_mail_3pl + "
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TxtNumber.EditValue = data.Rows(0)("number").ToString
            SLUEStatus.EditValue = data.Rows(0)("id_status").ToString
            DECreatedDate.EditValue = data.Rows(0)("created_date")
            TxtCreatedBy.EditValue = data.Rows(0)("created_by").ToString
            DEUpdatedDate.EditValue = data.Rows(0)("updated_date")
            TxtUpdatedBy.EditValue = data.Rows(0)("updated_by").ToString
            CCBEStore.SetEditValue(data.Rows(0)("id_store").ToString)
            SLUECity.EditValue = data.Rows(0)("id_city").ToString
            SLUESubDistrict.EditValue = data.Rows(0)("id_sub_district").ToString
            TxtStoreAddress.EditValue = data.Rows(0)("address_primary").ToString
            TxtEstWeight.EditValue = data.Rows(0)("estimate_weight").ToString
            TxtPackageQty.EditValue = data.Rows(0)("estimate_qty").ToString
            DEPickupDate.EditValue = data.Rows(0)("pick_up_date")
            DEWHReceive.EditValue = data.Rows(0)("wh_receive_date")
            SLUEDelType.EditValue = data.Rows(0)("id_del_type").ToString
            SLUE3PL.EditValue = data.Rows(0)("id_3pl_rate").ToString
            Txt3PLRate.EditValue = data.Rows(0)("cargo_rate")
            Txt3PLMinWeight.EditValue = data.Rows(0)("cargo_min_weight")

            'detail
            Dim query_detail As String = "
                SELECT s.id_sales_return_order, 0 AS `no`, s.sales_return_order_number, CONCAT(e.comp_number, ' - ', e.comp_name) AS store_name_to, IFNULL(i.return_qty, 0) AS return_qty, s.sales_return_order_note
                FROM tb_sales_return_order_mail_3pl_det AS d
                LEFT JOIN tb_sales_return_order AS s ON d.id_sales_order_return = s.id_sales_return_order
                LEFT JOIN tb_m_comp_contact AS c ON c.id_comp_contact = s.id_store_contact_to
                LEFT JOIN tb_m_comp AS e ON c.id_comp = e.id_comp 
                LEFT JOIN (
                    SELECT rt.id_sales_return_order, SUM(rt_det.sales_return_det_qty) AS return_qty 
                    FROM tb_sales_return AS rt
                    INNER JOIN tb_sales_return_det AS rt_det ON rt.id_sales_return = rt_det.id_sales_return 
                    WHERE rt.id_report_status = 6
                    GROUP BY rt.id_sales_return_order 
                ) AS i ON i.id_sales_return_order = s.id_sales_return_order
                WHERE d.id_mail_3pl = " + id_mail_3pl + "
            "

            Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

            GCDetail.DataSource = data_detail

            GVDetail.BestFitColumns()

            'history
            Dim query_history As String = "
                SELECT d.del_type, c.comp_name AS cargo_name, r.cargo_rate, r.cargo_min_weight, s.status
                FROM tb_sales_return_order_mail_3pl_history AS h
                LEFT JOIN tb_lookup_del_type AS d ON h.id_del_type = d.id_del_type
                LEFT JOIN tb_m_comp AS c ON h.id_3pl = c.id_comp
                LEFT JOIN tb_lookup_ror_mail_3pl_status_lookup AS s ON h.id_status = s.id_status
                LEFT JOIN tb_3pl_rate AS r ON h.id_3pl_rate = r.id_3pl_rate
                WHERE h.id_mail_3pl = " + id_mail_3pl + "
                ORDER BY h.id_mail_3pl_history DESC
            "

            Dim data_history As DataTable = execute_query(query_history, -1, True, "", "", "", "")

            GCHistory.DataSource = data_history

            GVHistory.BestFitColumns()

            Dim type_email() As String = {"request", "accept"}

            For i = 0 To type_email.Length - 1
                Dim t As String = type_email(i)

                'from
                If Not data.Rows(0)("from_" + t).ToString = "" Then
                    data_from = New DataTable

                    data_from.Columns.Add("name", GetType(String))
                    data_from.Columns.Add("position", GetType(String))
                    data_from.Columns.Add("email", GetType(String))

                    Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(data.Rows(0)("from_" + t).ToString)

                    For Each row In json("data").ToList
                        data_from.Rows.Add(row("name").ToString, row("position").ToString, row("email").ToString)
                    Next
                End If

                'to
                If Not data.Rows(0)("to_" + t).ToString = "" Then
                    data_to = New DataTable

                    data_to.Columns.Add("name", GetType(String))
                    data_to.Columns.Add("email", GetType(String))

                    Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(data.Rows(0)("to_" + t).ToString)

                    For Each row In json("data").ToList
                        data_to.Rows.Add(row("name").ToString, row("email").ToString)
                    Next
                End If

                'cc
                If Not data.Rows(0)("cc_" + t).ToString = "" Then
                    data_cc = New DataTable

                    data_cc.Columns.Add("name", GetType(String))
                    data_cc.Columns.Add("email", GetType(String))

                    Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(data.Rows(0)("cc_" + t).ToString)

                    For Each row In json("data").ToList
                        data_cc.Rows.Add(row("name").ToString, row("email").ToString)
                    Next
                End If

                'subject
                If Not data.Rows(0)("subject_" + t).ToString = "" Then
                    data_subject = New DataTable

                    data_subject.Columns.Add("subject", GetType(String))

                    data_subject.Rows.Add(data.Rows(0)("subject_" + t).ToString)
                End If
            Next

            'body
            If Not data.Rows(0)("id_status").ToString = "7" Then
                If data.Rows(0)("body_accept").ToString = "" Then
                    WebBrowser.DocumentText = data.Rows(0)("body_request").ToString
                Else
                    WebBrowser.DocumentText = data.Rows(0)("body_accept").ToString
                End If
            End If

            'submitted
            If data.Rows(0)("id_status").ToString = "7" Then
                Dim in_store As String = CCBEStore.EditValue.ToString

                If in_store = "" Then
                    in_store = "0"
                End If

                'from
                data_from = execute_query("
                    SELECT e.employee_name AS name, e.employee_position AS `position`, e.email_external AS email
                    FROM tb_mail_manage_mapping_intern AS m
                    INNER JOIN tb_m_user AS u ON u.id_user = m.id_user
                    INNER JOIN tb_m_employee AS e ON e.id_employee = u.id_employee
                    WHERE m.report_mark_type = 275 AND m.id_mail_member_type = 1 AND (ISNULL(m.id_comp_group) OR m.id_comp_group IN (SELECT id_comp_group FROM tb_m_comp WHERE id_comp IN (" + in_store + ")))

                    UNION

                    SELECT c.contact_person AS name, c.position AS `position`, c.email
                    FROM tb_mail_manage_mapping AS m
                    INNER JOIN tb_m_comp_contact AS c ON c.id_comp_contact = m.id_comp_contact
                    WHERE m.report_mark_type = 275 AND m.id_mail_member_type = 1 AND (ISNULL(m.id_comp_group) OR m.id_comp_group IN (SELECT id_comp_group FROM tb_m_comp WHERE id_comp IN (" + in_store + ")))
                ", -1, True, "", "", "", "")

                'cc
                data_cc = execute_query("
                    SELECT e.employee_name AS name, e.employee_position AS `position`, e.email_external AS email
                    FROM tb_mail_manage_mapping_intern AS m
                    INNER JOIN tb_m_user AS u ON u.id_user = m.id_user
                    INNER JOIN tb_m_employee AS e ON e.id_employee = u.id_employee
                    WHERE m.report_mark_type = 275 AND m.id_mail_member_type = 3 AND (ISNULL(m.id_comp_group) OR m.id_comp_group IN (SELECT id_comp_group FROM tb_m_comp WHERE id_comp IN (" + in_store + ")))

                    UNION

                    SELECT c.contact_person AS name, c.position AS `position`, c.email
                    FROM tb_mail_manage_mapping AS m
                    INNER JOIN tb_m_comp_contact AS c ON c.id_comp_contact = m.id_comp_contact
                    WHERE m.report_mark_type = 275 AND m.id_mail_member_type = 3 AND (ISNULL(m.id_comp_group) OR m.id_comp_group IN (SELECT id_comp_group FROM tb_m_comp WHERE id_comp IN (" + in_store + ")))
                ", -1, True, "", "", "", "")

                'subject
                data_subject = New DataTable

                data_subject.Columns.Add("subject", GetType(String))

                data_subject.Rows.Add(get_setup_field("sales_return_order_skpp_subject"))

                display_html("app")
            End If

            'controls
            SBAccept.Visible = True
            SBDecline.Visible = True
            SBSend.Visible = False
            SBOther3PL.Visible = False
            SBSendApprove.Visible = False
            SBCancel.Visible = True

            SBAddROR.Enabled = False
            SBRemoveROR.Enabled = False

            SBAttachment.Visible = False

            TxtNumber.ReadOnly = True
            SLUEStatus.ReadOnly = True
            DECreatedDate.ReadOnly = True
            TxtCreatedBy.ReadOnly = True
            DEUpdatedDate.ReadOnly = True
            TxtUpdatedBy.ReadOnly = True
            CCBEStore.ReadOnly = True
            SLUECity.ReadOnly = True
            SLUESubDistrict.ReadOnly = True
            TxtStoreAddress.ReadOnly = True
            TxtEstWeight.ReadOnly = True
            TxtPackageQty.ReadOnly = True
            DEPickupDate.ReadOnly = True
            DEWHReceive.ReadOnly = True
            SLUEDelType.ReadOnly = True
            SLUE3PL.ReadOnly = True
            Txt3PLRate.ReadOnly = True
            Txt3PLMinWeight.ReadOnly = True

            If data.Rows(0)("id_status").ToString = "4" Then
                SBAccept.Visible = False
                SBDecline.Visible = False
                SBOther3PL.Visible = True
            End If

            If data.Rows(0)("id_status").ToString = "5" Then
                SBAccept.Visible = False
                SBDecline.Visible = False
                SBCancel.Visible = False
            End If

            If data.Rows(0)("id_status").ToString = "6" Then
                SBAccept.Visible = False
                SBDecline.Visible = False
                SBCancel.Visible = False

                SBAttachment.Visible = True
            End If

            If data.Rows(0)("id_status").ToString = "7" Then
                SBAccept.Visible = False
                SBDecline.Visible = False

                Dim is_user_approve As String = execute_query("
                    SELECT COUNT(*) AS total
                    FROM tb_report_mark
                    WHERE id_user = " + id_user + " AND report_mark_type = 275 AND id_report_status = 3 AND id_report = " + id_mail_3pl + "
                ", 0, True, "", "", "", "")

                If Not is_user_approve = "0" Then
                    SBSendApprove.Visible = True
                Else
                    SBCancel.Visible = False
                End If

                SBAttachment.Visible = True
            End If

            'controls
            If SLUEType.EditValue.ToString = "2" Then
                SBAccept.Visible = False
                SBDecline.Visible = False
                SBSend.Visible = False
                SBOther3PL.Visible = False
                SBSendApprove.Visible = False
                SBCancel.Visible = False

                SBSubmit.Visible = False
                SBApprove.Visible = False
                SBCancel.Visible = True
                SBPrint.Visible = False

                Dim is_user_approve As String = execute_query("
                    SELECT COUNT(*) AS total
                    FROM tb_report_mark
                    WHERE id_user = " + id_user + " AND report_mark_type = 279 AND id_report_status = 3 AND id_report = " + id_mail_3pl + "
                ", 0, True, "", "", "", "")

                If Not is_user_approve = "0" Then
                    SBApprove.Visible = True
                End If

                If data.Rows(0)("id_status").ToString = "6" Then
                    SBApprove.Visible = False
                    SBCancel.Visible = False
                    SBPrint.Visible = True
                End If
            End If
        End If

        display_recipient()
    End Sub

    Sub view_type()
        Dim query As String = "
            SELECT 1 AS id_type, 'Warehouse' AS `type`
            UNION ALL
            SELECT 2 AS id_type, '3PL' AS `type`
        "

        viewSearchLookupQuery(SLUEType, query, "id_type", "type", "id_type")
    End Sub

    Sub view_city()
        Dim query As String = "
            SELECT id_city, city
            FROM tb_m_city
            WHERE id_city IN (SELECT id_city FROM tb_m_sub_district WHERE id_sub_district IN (SELECT id_sub_district FROM tb_m_comp WHERE id_comp_cat = 6 AND is_active = 1))
            ORDER BY city ASC
        "

        If Not loaded And Not id_mail_3pl = "-1" Then
            query = "
                SELECT id_city, city
                FROM tb_m_city
                ORDER BY city ASC
            "
        End If

        viewSearchLookupQuery(SLUECity, query, "id_city", "city", "id_city")
    End Sub

    Sub view_sub_district()
        Dim id_city As String = "0"

        Try
            id_city = SLUECity.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim query As String = "
            SELECT id_sub_district, sub_district
            FROM tb_m_sub_district
            WHERE id_city = " + id_city + " AND id_sub_district IN (SELECT id_sub_district FROM tb_m_comp WHERE id_comp_cat = 6 AND is_active = 1)
            ORDER BY sub_district ASC
        "

        If Not loaded And Not id_mail_3pl = "-1" Then
            query = "
                SELECT id_sub_district, sub_district
                FROM tb_m_sub_district
                ORDER BY sub_district ASC
            "
        End If

        viewSearchLookupQuery(SLUESubDistrict, query, "id_sub_district", "sub_district", "id_sub_district")
    End Sub

    Sub view_status()
        Dim query As String = "
            SELECT id_status, `status`
            FROM tb_lookup_ror_mail_3pl_status_lookup
        "

        viewSearchLookupQuery(SLUEStatus, query, "id_status", "status", "id_status")
    End Sub

    Sub view_store()
        Dim id_sub_district As String = "0"

        Try
            id_sub_district = SLUESubDistrict.EditValue
        Catch ex As Exception
        End Try

        Dim query As String = "
            SELECT id_comp AS id_store, comp_number AS store_account, comp_name AS store_name
            FROM tb_m_comp
            WHERE id_comp_cat = 6 AND is_active = 1 AND id_sub_district = " + id_sub_district + "
            ORDER BY comp_number
        "

        If Not loaded And Not id_mail_3pl = "-1" Then
            query = "
                SELECT id_comp AS id_store, comp_number AS store_account, comp_name AS store_name
                FROM tb_m_comp
                ORDER BY comp_number
            "
        End If

        If SLUEType.EditValue.ToString = "1" Then
            query = "
                SELECT id_comp AS id_store, comp_number AS store_account, comp_name AS store_name
                FROM tb_m_comp
                WHERE is_active = 1
                ORDER BY comp_number
            "
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        CCBEStore.Properties.Items.Clear()

        For i = 0 To data.Rows.Count - 1
            CCBEStore.Properties.Items.Add(data.Rows(i)("id_store").ToString, data.Rows(i)("store_account").ToString + " - " + data.Rows(i)("store_name").ToString)
        Next

        CCBEStore.Properties.DropDownRows = data.Rows.Count + 1
    End Sub

    Sub view_del_type()
        Dim query As String = "
            SELECT id_del_type, del_type
            FROM tb_lookup_del_type
        "

        viewSearchLookupQuery(SLUEDelType, query, "id_del_type", "del_type", "id_del_type")
    End Sub

    Sub view_3pl()
        Dim est_weight As Decimal = 0.00

        Try
            est_weight = Decimal.Parse(TxtEstWeight.EditValue.ToString)
        Catch ex As Exception
        End Try

        Dim id_sub_district As String = "0"

        Try
            id_sub_district = SLUESubDistrict.EditValue
        Catch ex As Exception
        End Try

        Dim id_del_type As String = "0"

        Try
            id_del_type = SLUEDelType.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim query As String = "
            SELECT *
            FROM (
                SELECT r.id_3pl_rate, r.id_comp AS id_cargo, c.comp_name AS cargo_name, r.cargo_code, r.cargo_rate, r.cargo_min_weight, (IF(" + decimalSQL(est_weight) + " >= r.cargo_min_weight, " + decimalSQL(est_weight) + ", r.cargo_min_weight) * r.cargo_rate) AS total_price
                FROM tb_3pl_rate AS r
                LEFT JOIN tb_m_comp AS c ON r.id_comp = c.id_comp
                WHERE r.is_active = 1 AND r.id_type = 2 AND r.id_sub_district = " + id_sub_district + " AND r.id_del_type = " + id_del_type + "
            ) AS tb
        "

        If Not loaded And Not id_mail_3pl = "-1" Then
            query = "
                SELECT r.id_3pl_rate, r.id_comp AS id_cargo, c.comp_name AS cargo_name, r.cargo_code, r.cargo_rate, r.cargo_min_weight, NULL AS total_price
                FROM tb_3pl_rate AS r
                LEFT JOIN tb_m_comp AS c ON r.id_comp = c.id_comp
            "
        End If

        viewSearchLookupQuery(SLUE3PL, query, "id_3pl_rate", "cargo_name", "id_3pl_rate")

        view_3pl_detail()
    End Sub

    Sub view_employee()
        Dim query As String = "
            SELECT id_employee, CONCAT(employee_code, ' - ', employee_name) AS employee_name
            FROM tb_m_employee
            WHERE id_employee_active = 1 AND id_departement = 6
            ORDER BY id_employee_level ASC
        "

        If Not loaded And Not id_mail_3pl = "-1" Then
            query = "
                SELECT id_employee, CONCAT(employee_code, ' - ', employee_name) AS employee_name
                FROM tb_m_employee
            "
        End If

        viewSearchLookupQuery(SLUEEmployee, query, "id_employee", "employee_name", "id_employee")
    End Sub

    Sub display_html(type As String)
        validating_store()
        validating_city()
        validating_sub_district()
        validating_weight()
        validating_qty()
        validating_pickupdate()
        validating_receivedate()
        validating_service()
        validating_3pl()

        If formIsValidInPanel(ErrorProvider, PanelControl6) Then
            Dim html As String = execute_query("SELECT template FROM tb_sales_return_order_mail_3pl_template WHERE type = '" + type + "'", 0, True, "", "", "", "")

            Dim store_name As String = execute_query("
                SELECT comp_name
                FROM tb_m_comp
                WHERE id_comp = (
                    SELECT MIN(id_comp) AS id_store
                    FROM tb_m_comp
                    WHERE id_comp IN (" + CCBEStore.EditValue.ToString + ")
                )
            ", 0, True, "", "", "", "")

            html = html.Replace("[3pl]", SLUE3PL.Text)
            html = html.Replace("[store_name]", store_name)
            html = html.Replace("[store_address]", TxtStoreAddress.Text)
            html = html.Replace("[del_type]", SLUEDelType.Text)
            html = html.Replace("[cargo_rate]", Txt3PLRate.Text)
            html = html.Replace("[cargo_min_weight]", Txt3PLMinWeight.Text)
            html = html.Replace("[estimate_qty]", TxtPackageQty.Text)
            html = html.Replace("[pick_up_date]", DEPickupDate.Text)
            html = html.Replace("[wh_receive_date]", DEWHReceive.Text)

            If data_from.Rows.Count > 0 Then
                html = html.Replace("[employee_name]", data_from(0)("name").ToString)
                html = html.Replace("[employee_position]", data_from(0)("position").ToString)
            End If

            WebBrowser.DocumentText = html
        Else
            WebBrowser.DocumentText = ""
        End If
    End Sub

    Private Sub SBSend_Click(sender As Object, e As EventArgs) Handles SBSend.Click
        validating_store()
        validating_city()
        validating_sub_district()
        validating_weight()
        validating_qty()
        validating_pickupdate()
        validating_receivedate()
        validating_service()
        validating_3pl()
        validating_employee()

        If formIsValidInPanel(ErrorProvider, PanelControl6) Then
            If Not METo.Text.ToString = "" Then
                If GVDetail.RowCount > 0 Then
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to send this pickup order ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                    If confirm = DialogResult.Yes Then
                        FormMain.SplashScreenManager1.ShowWaitForm()

                        Dim sent_status As Boolean = True

                        'send mail
                        sent_status = send_mail()

                        If sent_status Then
                            'save
                            'from
                            Dim text_from As String = ""

                            For i = 0 To data_from.Rows.Count - 1
                                text_from += "{ 'name': '" + data_from.Rows(i)("name").ToString + "', 'position': '" + data_from.Rows(i)("position").ToString + "', 'email': '" + data_from.Rows(i)("email").ToString + "' }, "
                            Next

                            If Not text_from = "" Then
                                text_from = "{ 'data': [" + text_from.Substring(0, text_from.Length - 2) + "] }"
                            End If

                            'to
                            Dim text_to As String = ""

                            For i = 0 To data_to.Rows.Count - 1
                                text_to += "{ 'name': '" + data_to.Rows(i)("name").ToString + "', 'email': '" + data_to.Rows(i)("email").ToString + "' }, "
                            Next

                            If Not text_to = "" Then
                                text_to = "{ 'data': [" + text_to.Substring(0, text_to.Length - 2) + "] }"
                            End If

                            'cc
                            Dim text_cc As String = ""

                            For i = 0 To data_cc.Rows.Count - 1
                                text_cc += "{ 'name': '" + data_cc.Rows(i)("name").ToString + "', 'email': '" + data_cc.Rows(i)("email").ToString + "' }, "
                            Next

                            If Not text_cc = "" Then
                                text_cc = "{ 'data': [" + text_cc.Substring(0, text_cc.Length - 2) + "] }"
                            End If

                            Dim id_3pl As String = execute_query("SELECT id_comp FROM tb_3pl_rate WHERE id_3pl_rate = " + SLUE3PL.EditValue.ToString, 0, True, "", "", "", "")

                            If id_mail_3pl = "-1" Then
                                Dim query As String = "
                                    INSERT INTO tb_sales_return_order_mail_3pl (id_type, id_3pl, id_3pl_rate, id_city, id_sub_district, id_del_type, id_status, estimate_weight, estimate_qty, pick_up_date, wh_receive_date, subject_request, from_request, to_request, cc_request, body_request, created_date, created_by) VALUES (" + SLUEType.EditValue.ToString + ", " + id_3pl + ", " + SLUE3PL.EditValue.ToString + ", " + SLUECity.EditValue.ToString + ", " + SLUESubDistrict.EditValue.ToString + ", " + SLUEDelType.EditValue.ToString + ", 2, " + decimalSQL(TxtEstWeight.EditValue.ToString) + ", " + TxtPackageQty.EditValue.ToString + ", '" + Date.Parse(DEPickupDate.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + Date.Parse(DEWHReceive.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + addSlashes(MESubject.EditValue.ToString) + "', '" + addSlashes(text_from) + "', '" + addSlashes(text_to) + "', '" + addSlashes(text_cc) + "', '" + addSlashes(WebBrowser.DocumentText) + "', NOW(), " + id_employee_user + "); SELECT LAST_INSERT_ID();
                                "

                                id_mail_3pl = execute_query(query, 0, True, "", "", "", "")

                                execute_non_query("CALL gen_number(" + id_mail_3pl + ", 275)", True, "", "", "", "")

                                'store
                                Dim stores() As String = CCBEStore.EditValue.ToString.Split(",")

                                For i = 0 To stores.Length - 1
                                    execute_non_query("INSERT INTO tb_sales_return_order_mail_3pl_store (id_mail_3pl, id_comp) VALUES (" + id_mail_3pl + ", " + stores(i).Replace(" ", "") + ")", True, "", "", "", "")
                                Next

                                'detail
                                If GVDetail.RowCount > 0 Then
                                    Dim query_detail As String = "INSERT INTO tb_sales_return_order_mail_3pl_det (id_mail_3pl, id_sales_order_return) VALUES "

                                    For i = 0 To GVDetail.RowCount - 1
                                        query_detail += "(" + id_mail_3pl + ", " + GVDetail.GetRowCellValue(i, "id_sales_return_order").ToString + "), "
                                    Next

                                    query_detail = query_detail.Substring(0, query_detail.Length - 2)

                                    execute_non_query(query_detail, True, "", "", "", "")
                                End If
                            Else
                                'insert history
                                Dim id_mail_3pl_history As String = execute_query("
                                    INSERT INTO tb_sales_return_order_mail_3pl_history (id_mail_3pl, id_3pl, id_3pl_rate, id_city, id_sub_district, id_del_type, id_status, estimate_weight, estimate_qty, pick_up_date, wh_receive_date, subject_request, from_request, to_request, cc_request, body_request)
                                    SELECT id_mail_3pl, id_3pl, id_3pl_rate, id_city, id_sub_district, id_del_type, id_status, estimate_weight, estimate_qty, pick_up_date, wh_receive_date, subject_request, from_request, to_request, cc_request, body_request
                                    FROM tb_sales_return_order_mail_3pl
                                    WHERE id_mail_3pl = " + id_mail_3pl + "; SELECT LAST_INSERT_ID();
                                ", 0, True, "", "", "", "")

                                'insert history, store & delete
                                Dim stores() As String = CCBEStore.EditValue.ToString.Split(",")

                                For i = 0 To stores.Length - 1
                                    execute_non_query("INSERT INTO tb_sales_return_order_mail_3pl_store_history (id_mail_3pl_history, id_comp) VALUES (" + id_mail_3pl_history + ", " + stores(i).Replace(" ", "") + ")", True, "", "", "", "")
                                Next

                                execute_non_query("DELETE FROM tb_sales_return_order_mail_3pl_store WHERE id_mail_3pl = " + id_mail_3pl, True, "", "", "", "")

                                For i = 0 To stores.Length - 1
                                    execute_non_query("INSERT INTO tb_sales_return_order_mail_3pl_store (id_mail_3pl, id_comp) VALUES (" + id_mail_3pl + ", " + stores(i).Replace(" ", "") + ")", True, "", "", "", "")
                                Next

                                'update
                                Dim query As String = "UPDATE tb_sales_return_order_mail_3pl SET id_3pl = " + id_3pl + ", id_3pl_rate = " + SLUE3PL.EditValue.ToString + ", id_city = " + SLUECity.EditValue.ToString + ", id_sub_district = " + SLUESubDistrict.EditValue.ToString + ", id_del_type = " + SLUEDelType.EditValue.ToString + ", id_status = 2, estimate_weight = " + decimalSQL(TxtEstWeight.EditValue.ToString) + ", estimate_qty = " + TxtPackageQty.EditValue.ToString + ", pick_up_date = '" + Date.Parse(DEPickupDate.EditValue.ToString).ToString("yyyy-MM-dd") + "', wh_receive_date = '" + Date.Parse(DEWHReceive.EditValue.ToString).ToString("yyyy-MM-dd") + "', subject_request = '" + addSlashes(MESubject.EditValue.ToString) + "', from_request = '" + addSlashes(text_from) + "', to_request = '" + addSlashes(text_to) + "', cc_request = '" + addSlashes(text_cc) + "', body_request = '" + addSlashes(WebBrowser.DocumentText) + "', updated_date = NOW(), updated_by = " + id_employee_user + " WHERE id_mail_3pl = " + id_mail_3pl

                                execute_non_query(query, True, "", "", "", "")
                            End If

                            load_form()
                        Else
                            FormMain.SplashScreenManager1.CloseWaitForm()

                            stopCustom("Send email error please try again.")
                        End If

                        If FormMain.SplashScreenManager1.IsSplashFormVisible Then
                            FormMain.SplashScreenManager1.CloseWaitForm()
                        End If
                    End If
                Else
                    XTCMail.SelectedTabPage = XTPData

                    stopCustom("Please input ROR.")
                End If
            Else
                stopCustom("Please input 3PL email address.")
            End If
        Else
            stopCustom("Please check your input.")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub FormSalesReturnOrderMailDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            FormSalesReturnOrderMail.form_load()
            FormSalesOrderSvcLevel.viewReturnOrder()
        Catch ex As Exception
        End Try

        Dispose()
    End Sub

    Sub change_status(id_status As String)
        Dim status As String = execute_query("SELECT `status` FROM tb_lookup_ror_mail_3pl_status_lookup WHERE id_status = " + id_status, 0, True, "", "", "", "")

        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to " + status.ToLower.Replace("3pl ", "") + " this pickup order ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            FormMain.SplashScreenManager1.ShowWaitForm()

            Dim query As String = "UPDATE tb_sales_return_order_mail_3pl SET id_status = " + id_status + ", updated_date = NOW(), updated_by = " + id_employee_user + " WHERE id_mail_3pl = " + id_mail_3pl

            execute_non_query(query, True, "", "", "", "")

            FormMain.SplashScreenManager1.CloseWaitForm()

            If id_status = "4" Then
                Dim confirm_next As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to choose another 3PL ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                If confirm_next = DialogResult.Yes Then
                    load_form()

                    change_3pl()
                Else
                    load_form()
                End If
            ElseIf id_status = "5" Then
                If SLUEStatus.EditValue.ToString = "7" Then
                    'update report mark
                    Dim id_report_mark As String = execute_query("SELECT id_report_mark FROM tb_report_mark WHERE report_mark_type = 275 AND id_report = " + id_mail_3pl + " AND id_user = " + id_user + " AND id_report_status = 3", 0, True, "", "", "", "")

                    reset_is_use_mark(id_report_mark, "2")

                    execute_non_query("UPDATE tb_report_mark SET id_mark = 3, is_use = 1, report_mark_datetime = NOW() WHERE id_report_mark = " + id_report_mark, True, "", "", "", "")
                End If

                infoCustom("Pickup Order cancelled.")

                load_form()
            ElseIf id_status = "7" Then
                submit_who_prepared("275", id_mail_3pl, id_user)

                infoCustom("Pickup Order submitted.")

                load_form()
            End If
        End If
    End Sub

    Private Sub SBAccept_Click(sender As Object, e As EventArgs) Handles SBAccept.Click
        change_status("7")
    End Sub

    Private Sub SBDecline_Click(sender As Object, e As EventArgs) Handles SBDecline.Click
        change_status("4")
    End Sub

    Sub change_3pl()
        SLUEDelType.ReadOnly = False
        SLUE3PL.ReadOnly = False

        SBSend.Visible = True
        SBCancel.Visible = True

        SBOther3PL.Visible = False

        view_3pl()

        'select other 3pl
        Dim prev_id_3pl_rate As String = execute_query("SELECT id_3pl_rate FROM tb_sales_return_order_mail_3pl WHERE id_mail_3pl = " + id_mail_3pl, 0, True, "", "", "", "")
        Dim next_id_3pl_rate As String = prev_id_3pl_rate

        Dim is_stop As Boolean = False

        Dim data As DataTable = SLUE3PL.Properties.DataSource

        For i = 0 To data.Rows.Count - 1
            If is_stop Then
                next_id_3pl_rate = data.Rows(i)("id_3pl_rate").ToString

                Exit For
            End If

            If prev_id_3pl_rate = data.Rows(i)("id_3pl_rate").ToString Then
                is_stop = True
            End If
        Next

        SLUE3PL.EditValue = next_id_3pl_rate
    End Sub

    Private Sub SBOther3PL_Click(sender As Object, e As EventArgs) Handles SBOther3PL.Click
        Dim confirm_next As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to choose another 3PL ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm_next = DialogResult.Yes Then
            change_3pl()
        End If
    End Sub

    Sub display_recipient()
        'list from
        Dim list_from As String = ""

        For i = 0 To data_from.Rows.Count - 1
            If Not data_from(i)("email").ToString = "" Then
                list_from += data_from(i)("email").ToString + "; "
            End If
        Next

        If Not list_from = "" Then
            list_from = list_from.Substring(0, list_from.Length - 2)
        End If

        MEFrom.EditValue = list_from

        'list to
        Dim list_to As String = ""

        For i = 0 To data_to.Rows.Count - 1
            If Not data_to(i)("email").ToString = "" Then
                list_to += data_to(i)("email").ToString + "; "
            End If
        Next

        If Not list_to = "" Then
            list_to = list_to.Substring(0, list_to.Length - 2)
        End If

        METo.EditValue = list_to

        'list cc
        Dim list_cc As String = ""

        For i = 0 To data_cc.Rows.Count - 1
            If Not data_cc(i)("email").ToString = "" Then
                list_cc += data_cc(i)("email").ToString + "; "
            End If
        Next

        If Not list_cc = "" Then
            list_cc = list_cc.Substring(0, list_cc.Length - 2)
        End If

        MECC.EditValue = list_cc

        'list subject
        MESubject.EditValue = data_subject.Rows(0)("subject").ToString
    End Sub

    Function send_mail() As Boolean
        Dim is_ssl = get_setup_field("system_email_is_ssl").ToString

        Dim client As Net.Mail.SmtpClient = New Net.Mail.SmtpClient()

        If is_ssl = "1" Then
            client.Port = get_setup_field("system_email_ssl_port").ToString
            client.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = get_setup_field("system_email_ssl_server").ToString
            client.EnableSsl = True
            client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email_ssl").ToString, get_setup_field("system_email_ssl_pass").ToString)
        Else
            client.Port = get_setup_field("system_email_port").ToString
            client.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = get_setup_field("system_email_server").ToString
            client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email").ToString, get_setup_field("system_email_pass").ToString)
        End If

        'mail
        Dim mail As Net.Mail.MailMessage = New Net.Mail.MailMessage()

        'from
        Dim from_mail As Net.Mail.MailAddress = New Net.Mail.MailAddress(data_from.Rows(0)("email").ToString, data_from.Rows(0)("name").ToString)

        mail.From = from_mail

        'to
        For j = 0 To data_to.Rows.Count - 1
            If Not data_to.Rows(j)("email").ToString = "" Then
                Dim to_mail As Net.Mail.MailAddress = New Net.Mail.MailAddress(data_to.Rows(j)("email").ToString, data_to.Rows(j)("name").ToString)

                mail.To.Add(to_mail)
            End If
        Next

        'cc
        For j = 0 To data_cc.Rows.Count - 1
            If Not data_cc.Rows(j)("email").ToString = "" Then
                Dim cc_mail As Net.Mail.MailAddress = New Net.Mail.MailAddress(data_cc.Rows(j)("email").ToString, data_cc.Rows(j)("name").ToString)

                mail.CC.Add(cc_mail)
            End If
        Next

        'subject & body
        mail.Subject = data_subject.Rows(0)("subject").ToString

        mail.IsBodyHtml = True

        mail.Body = WebBrowser.DocumentText

        'attachment
        If SLUEStatus.EditValue.ToString = "7" Then
            Dim report As ReportSalesReturnOrderMailSKPP = New ReportSalesReturnOrderMailSKPP

            report.XrRichText.Html = get_attachment()

            Dim mem As IO.MemoryStream = New IO.MemoryStream()

            report.ExportToPdf(mem)

            mem.Seek(0, System.IO.SeekOrigin.Begin)

            Dim att = New Net.Mail.Attachment(mem, "Surat Kuasa Pengambilan Produk.pdf", "application/pdf")

            mail.Attachments.Add(att)
        End If

        Dim out As Boolean = True

        Try
            client.Send(mail)

            mail.Dispose()
        Catch ex As Exception
            out = False
        End Try

        Return out
    End Function

    Sub view_interfaces()
        If SLUEType.EditValue.ToString = "1" Then
            'visible
            LCity.Visible = False
            SLUECity.Visible = False
            LSubDistrict.Visible = False
            SLUESubDistrict.Visible = False
            LStoreAddress.Visible = False
            TxtStoreAddress.Visible = False
            LEstWeight.Visible = False
            TxtEstWeight.Visible = False
            LPackageQty.Visible = False
            TxtPackageQty.Visible = False
            LWHReceive.Visible = False
            DEWHReceive.Visible = False
            LDelType.Visible = False
            SLUEDelType.Visible = False
            L3PLRate.Visible = False
            Txt3PLRate.Visible = False
            L3PL.Visible = False
            SLUE3PL.Visible = False
            L3PLMinWeight.Visible = False
            Txt3PLMinWeight.Visible = False

            LStore.Visible = True
            CCBEStore.Visible = True
            LPickupDate.Visible = True
            DEPickupDate.Visible = True
            LEmployee.Visible = True
            SLUEEmployee.Visible = True

            PanelControl4.Visible = False

            XTPHistory.PageVisible = False

            'location
            LStore.Location = New Point(15, 19)
            CCBEStore.Location = New Point(110, 16)
            LPickupDate.Location = New Point(15, 45)
            DEPickupDate.Location = New Point(110, 42)
            LEmployee.Location = New Point(793, 19)
            SLUEEmployee.Location = New Point(892, 16)

            PanelControl6.Height = 74
        Else
            'visible
            LEmployee.Visible = False
            SLUEEmployee.Visible = False

            LCity.Visible = True
            SLUECity.Visible = True
            LSubDistrict.Visible = True
            SLUESubDistrict.Visible = True
            LStore.Visible = True
            CCBEStore.Visible = True
            LStoreAddress.Visible = True
            TxtStoreAddress.Visible = True
            LEstWeight.Visible = True
            TxtEstWeight.Visible = True
            LPackageQty.Visible = True
            TxtPackageQty.Visible = True
            LPickupDate.Visible = True
            DEPickupDate.Visible = True
            LWHReceive.Visible = True
            DEWHReceive.Visible = True
            LDelType.Visible = True
            SLUEDelType.Visible = True
            L3PLRate.Visible = True
            Txt3PLRate.Visible = True
            L3PL.Visible = True
            SLUE3PL.Visible = True
            L3PLMinWeight.Visible = True
            Txt3PLMinWeight.Visible = True

            PanelControl4.Visible = True

            XTPHistory.PageVisible = True

            'location
            LCity.Location = New Point(15, 19)
            SLUECity.Location = New Point(110, 16)
            LSubDistrict.Location = New Point(793, 19)
            SLUESubDistrict.Location = New Point(892, 16)
            LStore.Location = New Point(15, 45)
            CCBEStore.Location = New Point(110, 42)
            LStoreAddress.Location = New Point(793, 45)
            TxtStoreAddress.Location = New Point(892, 42)
            LEstWeight.Location = New Point(15, 71)
            TxtEstWeight.Location = New Point(110, 68)
            LPackageQty.Location = New Point(793, 71)
            TxtPackageQty.Location = New Point(892, 68)
            LPickupDate.Location = New Point(15, 97)
            DEPickupDate.Location = New Point(110, 94)
            LWHReceive.Location = New Point(793, 97)
            DEWHReceive.Location = New Point(892, 94)
            LDelType.Location = New Point(15, 123)
            SLUEDelType.Location = New Point(110, 120)
            L3PLRate.Location = New Point(793, 123)
            Txt3PLRate.Location = New Point(892, 120)
            L3PL.Location = New Point(15, 149)
            SLUE3PL.Location = New Point(110, 146)
            L3PLMinWeight.Location = New Point(793, 149)
            Txt3PLMinWeight.Location = New Point(892, 146)

            PanelControl6.Height = 177
        End If

        'controls
        If SLUEType.EditValue.ToString = "1" Then
            SBAccept.Visible = False
            SBDecline.Visible = False
            SBSend.Visible = False
            SBOther3PL.Visible = False
            SBSendApprove.Visible = False
            SBCancel.Visible = False

            SBSubmit.Visible = True
            SBApprove.Visible = False
            SBPrint.Visible = False
        Else
            SBAccept.Visible = False
            SBDecline.Visible = False
            SBSend.Visible = True
            SBOther3PL.Visible = False
            SBSendApprove.Visible = False
            SBCancel.Visible = False

            SBSubmit.Visible = False
            SBApprove.Visible = False
            SBPrint.Visible = False
        End If
    End Sub

    Private Sub SLUEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEType.EditValueChanged
        view_store()

        view_interfaces()
    End Sub

    Private Sub SLUECity_EditValueChanged(sender As Object, e As EventArgs) Handles SLUECity.EditValueChanged
        If loaded Then
            view_sub_district()
        End If
    End Sub

    Private Sub SLUESubDistrict_EditValueChanged(sender As Object, e As EventArgs) Handles SLUESubDistrict.EditValueChanged
        If loaded Then
            view_store()
        End If
    End Sub

    Private Sub CCBEStore_EditValueChanged(sender As Object, e As EventArgs) Handles CCBEStore.EditValueChanged
        If loaded Then
            'reset detail
            Dim query_detail As String = "
                SELECT s.id_sales_return_order, 0 AS `no`, s.sales_return_order_number, CONCAT(e.comp_number, ' - ', e.comp_name) AS store_name_to, IFNULL(i.return_qty, 0) AS return_qty, s.sales_return_order_note
                FROM tb_sales_return_order_mail_3pl_det AS d
                LEFT JOIN tb_sales_return_order AS s ON d.id_sales_order_return = s.id_sales_return_order
                LEFT JOIN tb_m_comp_contact AS c ON c.id_comp_contact = s.id_store_contact_to
                LEFT JOIN tb_m_comp AS e ON c.id_comp = e.id_comp 
                LEFT JOIN (
                    SELECT rt.id_sales_return_order, SUM(rt_det.sales_return_det_qty) AS return_qty 
                    FROM tb_sales_return AS rt
                    INNER JOIN tb_sales_return_det AS rt_det ON rt.id_sales_return = rt_det.id_sales_return 
                    WHERE rt.id_report_status = 6
                    GROUP BY rt.id_sales_return_order 
                ) AS i ON i.id_sales_return_order = s.id_sales_return_order
                WHERE s.id_sales_return_order = -1
            "

            Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

            GCDetail.DataSource = data_detail

            Dim in_store As String = CCBEStore.EditValue.ToString

            If in_store = "" Then
                in_store = "0"
            End If

            'from
            data_from = execute_query("
                SELECT e.employee_name AS name, e.employee_position AS `position`, e.email_external AS email
                FROM tb_mail_manage_mapping_intern AS m
                INNER JOIN tb_m_user AS u ON u.id_user = m.id_user
                INNER JOIN tb_m_employee AS e ON e.id_employee = u.id_employee
                WHERE m.report_mark_type = 276 AND m.id_mail_member_type = 1 AND (ISNULL(m.id_comp_group) OR m.id_comp_group IN (SELECT id_comp_group FROM tb_m_comp WHERE id_comp IN (" + in_store + ")))

                UNION

                SELECT c.contact_person AS name, c.position AS `position`, c.email
                FROM tb_mail_manage_mapping AS m
                INNER JOIN tb_m_comp_contact AS c ON c.id_comp_contact = m.id_comp_contact
                WHERE m.report_mark_type = 276 AND m.id_mail_member_type = 1 AND (ISNULL(m.id_comp_group) OR m.id_comp_group IN (SELECT id_comp_group FROM tb_m_comp WHERE id_comp IN (" + in_store + ")))
            ", -1, True, "", "", "", "")

            'cc
            data_cc = execute_query("
                SELECT e.employee_name AS name, e.employee_position AS `position`, e.email_external AS email
                FROM tb_mail_manage_mapping_intern AS m
                INNER JOIN tb_m_user AS u ON u.id_user = m.id_user
                INNER JOIN tb_m_employee AS e ON e.id_employee = u.id_employee
                WHERE m.report_mark_type = 276 AND m.id_mail_member_type = 3 AND (ISNULL(m.id_comp_group) OR m.id_comp_group IN (SELECT id_comp_group FROM tb_m_comp WHERE id_comp IN (" + in_store + ")))

                UNION

                SELECT c.contact_person AS name, c.position AS `position`, c.email
                FROM tb_mail_manage_mapping AS m
                INNER JOIN tb_m_comp_contact AS c ON c.id_comp_contact = m.id_comp_contact
                WHERE m.report_mark_type = 276 AND m.id_mail_member_type = 3 AND (ISNULL(m.id_comp_group) OR m.id_comp_group IN (SELECT id_comp_group FROM tb_m_comp WHERE id_comp IN (" + in_store + ")))
            ", -1, True, "", "", "", "")

            display_recipient()

            view_3pl()
            view_store_address()
            display_html("pps")
        End If
    End Sub

    Private Sub TxtEstWeight_EditValueChanged(sender As Object, e As EventArgs) Handles TxtEstWeight.EditValueChanged
        If loaded Then
            view_3pl()
            display_html("pps")
        End If
    End Sub

    Private Sub TxtPackageQty_EditValueChanged(sender As Object, e As EventArgs) Handles TxtPackageQty.EditValueChanged
        If loaded Then
            display_html("pps")
        End If
    End Sub

    Private Sub DEPickupDate_EditValueChanged(sender As Object, e As EventArgs) Handles DEPickupDate.EditValueChanged
        If loaded Then
            DEWHReceive.Properties.MinValue = DEPickupDate.EditValue

            display_html("pps")
        End If
    End Sub

    Private Sub DEWHReceive_EditValueChanged(sender As Object, e As EventArgs) Handles DEWHReceive.EditValueChanged
        If loaded Then
            display_html("pps")
        End If
    End Sub

    Private Sub SLUEDelType_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEDelType.EditValueChanged
        If loaded Then
            view_3pl()
            display_html("pps")
        End If
    End Sub

    Private Sub SLUE3PL_EditValueChanged(sender As Object, e As EventArgs) Handles SLUE3PL.EditValueChanged
        If loaded Then
            'to
            Dim id_3pl_rate As String = "0"

            Try
                id_3pl_rate = SLUE3PL.EditValue.ToString
            Catch ex As Exception
            End Try

            data_to = execute_query("
                SELECT c.comp_name AS name, cc.email
                FROM tb_m_comp_contact AS cc
                LEFT JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
                WHERE cc.id_comp = (SELECT id_comp FROM tb_3pl_rate WHERE id_3pl_rate = " + id_3pl_rate + ") AND cc.is_default = 1
            ", -1, True, "", "", "", "")

            display_recipient()

            display_html("pps")
            view_3pl_detail()
        End If
    End Sub

    Private Sub SBAddROR_Click(sender As Object, e As EventArgs) Handles SBAddROR.Click
        If Not CCBEStore.EditValue.ToString = "" Then
            XTCMail.SelectedTabPage = XTPData

            FormSalesReturnOrderMailPick.ShowDialog()
        Else
            stopCustom("Please select store.")

            CCBEStore.Focus()
        End If
    End Sub

    Private Sub SBRemoveROR_Click(sender As Object, e As EventArgs) Handles SBRemoveROR.Click
        GVDetail.DeleteSelectedRows()
    End Sub

    Private Sub SLUEEmployee_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SLUEEmployee.Validating
        validating_employee()
    End Sub

    Sub validating_employee()
        Dim id_employee As String = ""

        Try
            id_employee = SLUEEmployee.EditValue.ToString
        Catch ex As Exception
        End Try

        If id_employee = "" Then
            ErrorProvider.SetError(SLUECity, "Can't blank.")
        Else
            ErrorProvider.SetError(SLUECity, "")
        End If
    End Sub

    Private Sub CCBEStore_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CCBEStore.Validating
        validating_store()
    End Sub

    Sub validating_store()
        Dim id_comp As String = ""

        Try
            id_comp = CCBEStore.EditValue.ToString
        Catch ex As Exception
        End Try

        If id_comp = "" Then
            ErrorProvider.SetError(CCBEStore, "Can't blank.")
        Else
            ErrorProvider.SetError(CCBEStore, "")
        End If
    End Sub

    Private Sub SLUECity_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SLUECity.Validating
        validating_city()
    End Sub

    Sub validating_city()
        Dim id_city As String = ""

        Try
            id_city = SLUECity.EditValue.ToString
        Catch ex As Exception
        End Try

        If id_city = "" Then
            ErrorProvider.SetError(SLUECity, "Can't blank.")
        Else
            ErrorProvider.SetError(SLUECity, "")
        End If
    End Sub

    Private Sub SLUESubDistrict_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SLUESubDistrict.Validating
        validating_sub_district()
    End Sub

    Sub validating_sub_district()
        Dim id_sub_district As String = ""

        Try
            id_sub_district = SLUESubDistrict.EditValue.ToString
        Catch ex As Exception
        End Try

        If id_sub_district = "" Then
            ErrorProvider.SetError(SLUESubDistrict, "Can't blank.")
        Else
            ErrorProvider.SetError(SLUESubDistrict, "")
        End If
    End Sub

    Private Sub TxtEstWeight_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtEstWeight.Validating
        validating_weight()
    End Sub

    Sub validating_weight()
        If TxtEstWeight.Text = "" Then
            ErrorProvider.SetError(TxtEstWeight, "Can't blank.")
        Else
            ErrorProvider.SetError(TxtEstWeight, "")
        End If
    End Sub

    Private Sub TxtPackageQty_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtPackageQty.Validating
        validating_qty()
    End Sub

    Sub validating_qty()
        If TxtPackageQty.Text = "" Then
            ErrorProvider.SetError(TxtPackageQty, "Can't blank.")
        Else
            ErrorProvider.SetError(TxtPackageQty, "")
        End If
    End Sub

    Private Sub DEPickupDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DEPickupDate.Validating
        validating_pickupdate()
    End Sub

    Sub validating_pickupdate()
        If DEPickupDate.Text = "" Then
            ErrorProvider.SetError(DEPickupDate, "Can't blank.")
        Else
            ErrorProvider.SetError(DEPickupDate, "")
        End If
    End Sub

    Private Sub DEWHReceive_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DEWHReceive.Validating
        validating_receivedate()
    End Sub

    Sub validating_receivedate()
        If DEWHReceive.Text = "" Then
            ErrorProvider.SetError(DEWHReceive, "Can't blank.")
        Else
            ErrorProvider.SetError(DEWHReceive, "")
        End If
    End Sub

    Private Sub SLUEDelType_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SLUEDelType.Validating
        validating_service()
    End Sub

    Sub validating_service()
        Dim id_del As String = ""

        Try
            id_del = SLUEDelType.EditValue.ToString
        Catch ex As Exception
        End Try

        If id_del = "" Then
            ErrorProvider.SetError(SLUEDelType, "Can't blank.")
        Else
            ErrorProvider.SetError(SLUEDelType, "")
        End If
    End Sub

    Private Sub SLUE3PL_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SLUE3PL.Validating
        validating_3pl()
    End Sub

    Sub validating_3pl()
        Dim id_3pl As String = ""

        Try
            id_3pl = SLUE3PL.EditValue.ToString
        Catch ex As Exception
        End Try

        If id_3pl = "" Then
            ErrorProvider.SetError(SLUE3PL, "Can't blank.")
        Else
            ErrorProvider.SetError(SLUE3PL, "")
        End If
    End Sub

    Sub view_store_address()
        Dim data As DataTable = New DataTable

        data.Columns.Add("address_primary", GetType(String))

        data.Rows.Add("")

        Try
            data = execute_query("
                SELECT address_primary
                FROM tb_m_comp
                WHERE id_comp = (
                    SELECT MIN(id_comp) AS id_store
                    FROM tb_m_comp
                    WHERE id_comp IN (" + CCBEStore.EditValue.ToString + ")
                )
            ", -1, True, "", "", "", "")
        Catch ex As Exception
        End Try

        TxtStoreAddress.EditValue = data.Rows(0)("address_primary").ToString
    End Sub

    Sub view_3pl_detail()
        Dim id_3pl_rate As String = ""

        Try
            id_3pl_rate = SLUE3PL.EditValue.ToString
        Catch ex As Exception
        End Try

        If id_3pl_rate = "" Then
            Txt3PLRate.EditValue = ""
            Txt3PLMinWeight.EditValue = ""
        Else
            Dim data_3pl As DataTable = execute_query("
                SELECT cargo_rate, cargo_min_weight
                FROM tb_3pl_rate
                WHERE id_3pl_rate = " + id_3pl_rate + "
            ", -1, True, "", "", "", "")

            Txt3PLRate.EditValue = data_3pl.Rows(0)("cargo_rate")
            Txt3PLMinWeight.EditValue = data_3pl.Rows(0)("cargo_min_weight")
        End If
    End Sub

    Private Sub SBCancel_Click(sender As Object, e As EventArgs) Handles SBCancel.Click
        change_status("5")
    End Sub

    Private Sub SBAttachment_Click(sender As Object, e As EventArgs) Handles SBAttachment.Click
        'path
        Dim path As String = Application.StartupPath & "\download\"
        Dim filename As String = path + "\Surat Kuasa Pengambilan Produk.pdf"

        If Not IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If

        'report
        Dim report As ReportSalesReturnOrderMailSKPP = New ReportSalesReturnOrderMailSKPP

        report.XrRichText.Html = get_attachment()

        report.ExportToPdf(filename)

        'openfile
        Dim processinfo As ProcessStartInfo = New ProcessStartInfo()

        processinfo.FileName = filename
        processinfo.WorkingDirectory = path

        Process.Start(processinfo)
    End Sub

    Function get_attachment() As String
        Dim html As String = ""

        If SLUEStatus.EditValue.ToString = "6" Then
            html = execute_query("SELECT attachment FROM tb_sales_return_order_mail_3pl WHERE id_mail_3pl = " + id_mail_3pl, 0, True, "", "", "", "")
        Else
            html = execute_query("SELECT template FROM tb_sales_return_order_mail_3pl_template WHERE `type` = 'skpp'", 0, True, "", "", "", "")

            Dim data_3pl As DataTable = execute_query("SELECT DATE(NOW()) AS created_at, c.address_primary, c.phone, t.contact_person, t.position FROM tb_m_comp_contact AS t LEFT JOIN tb_m_comp AS c ON t.id_comp = c.id_comp WHERE t.id_comp = (SELECT id_comp FROM tb_3pl_rate WHERE id_3pl_rate = " + SLUE3PL.EditValue.ToString + ") AND t.is_default = 1", -1, True, "", "", "", "")

            Dim number_skpp As String = ""

            If SLUEStatus.EditValue.ToString = "6" Then
                number_skpp = execute_query("SELECT skpp_number FROM tb_sales_return_order_mail_3pl WHERE id_mail_3pl = " + id_mail_3pl, 0, True, "", "", "", "")
            Else
                number_skpp = execute_query("SELECT LPAD((COUNT(id_mail_3pl) + 1), 3, '0') AS number_skpp FROM tb_sales_return_order_mail_3pl WHERE id_status = 6 AND MONTH(updated_date) = MONTH(NOW()) AND YEAR(updated_date) = YEAR(NOW())", 0, True, "", "", "", "")
            End If

            Dim my As String = execute_query("SELECT CONCAT(`code`, '/', YEAR(NOW())) AS `number` FROM `tb_ot_memo_number_mon` WHERE `month` = MONTH(NOW())", 0, True, "", "", "", "")

            Dim store_name As String = execute_query("
                SELECT comp_name
                FROM tb_m_comp
                WHERE id_comp = (
                    SELECT MIN(id_comp) AS id_store
                    FROM tb_m_comp
                    WHERE id_comp IN (" + CCBEStore.EditValue.ToString + ")
                )
            ", 0, True, "", "", "", "")

            html = html.Replace("[number]", number_skpp + "/EXT/WHD-SKPP/" + my)
            html = html.Replace("[3pl]", SLUE3PL.Text)
            html = html.Replace("[3pl_address]", data_3pl.Rows(0)("address_primary").ToString)
            html = html.Replace("[3pl_phone]", data_3pl.Rows(0)("phone").ToString)
            html = html.Replace("[contact_person]", data_3pl.Rows(0)("contact_person").ToString)
            html = html.Replace("[position]", data_3pl.Rows(0)("position").ToString)
            html = html.Replace("[store_name]", store_name)
            html = html.Replace("[store_address]", TxtStoreAddress.Text)
            html = html.Replace("[del_type]", SLUEDelType.Text)
            html = html.Replace("[cargo_rate]", Txt3PLRate.Text)
            html = html.Replace("[cargo_min_weight]", Txt3PLMinWeight.Text)

            If (data_from.Rows.Count > 0) Then
                html = html.Replace("[employee_name]", data_from(0)("name").ToString)
                html = html.Replace("[employee_position]", data_from(0)("position").ToString)
            End If

            html = html.Replace("[created_at]", Date.Parse(data_3pl.Rows(0)("created_at").ToString).ToString("dd MMMM yyyy"))
        End If

        Return html
    End Function

    Private Sub SBSendApprove_Click(sender As Object, e As EventArgs) Handles SBSendApprove.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to approve & send this pickup order ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            FormMain.SplashScreenManager1.ShowWaitForm()

            Dim sent_status As Boolean = True

            'send mail
            sent_status = send_mail()

            If sent_status Then
                'from
                Dim text_from As String = ""

                For i = 0 To data_from.Rows.Count - 1
                    text_from += "{ 'name': '" + data_from.Rows(i)("name").ToString + "', 'position': '" + data_from.Rows(i)("position").ToString + "', 'email': '" + data_from.Rows(i)("email").ToString + "' }, "
                Next

                If Not text_from = "" Then
                    text_from = "{ 'data': [" + text_from.Substring(0, text_from.Length - 2) + "] }"
                End If

                'to
                Dim text_to As String = ""

                For i = 0 To data_to.Rows.Count - 1
                    text_to += "{ 'name': '" + data_to.Rows(i)("name").ToString + "', 'email': '" + data_to.Rows(i)("email").ToString + "' }, "
                Next

                If Not text_to = "" Then
                    text_to = "{ 'data': [" + text_to.Substring(0, text_to.Length - 2) + "] }"
                End If

                'cc
                Dim text_cc As String = ""

                For i = 0 To data_cc.Rows.Count - 1
                    text_cc += "{ 'name': '" + data_cc.Rows(i)("name").ToString + "', 'email': '" + data_cc.Rows(i)("email").ToString + "' }, "
                Next

                If Not text_cc = "" Then
                    text_cc = "{ 'data': [" + text_cc.Substring(0, text_cc.Length - 2) + "] }"
                End If

                Dim attachment As String = get_attachment()

                Dim number_skpp As String = execute_query("
                    SELECT LPAD((COUNT(id_mail_3pl) + 1), 3, '0') AS number_skpp
                    FROM tb_sales_return_order_mail_3pl
                    WHERE id_status = 6 AND id_type = 2 AND MONTH(updated_date) = MONTH(NOW()) AND YEAR(updated_date) = YEAR(NOW())
                ", 0, True, "", "", "", "")

                Dim query As String = "UPDATE tb_sales_return_order_mail_3pl SET skpp_number = '" + number_skpp + "', id_status = 6, subject_accept = '" + addSlashes(MESubject.EditValue.ToString) + "', from_accept = '" + addSlashes(text_from) + "', to_accept = '" + addSlashes(text_to) + "', cc_accept = '" + addSlashes(text_cc) + "', body_accept = '" + addSlashes(WebBrowser.DocumentText) + "', attachment = '" + addSlashes(attachment) + "', updated_date = NOW(), updated_by = " + id_employee_user + " WHERE id_mail_3pl = " + id_mail_3pl

                execute_non_query(query, True, "", "", "", "")

                'update report mark
                Dim id_report_mark As String = execute_query("SELECT id_report_mark FROM tb_report_mark WHERE report_mark_type = 275 AND id_report = " + id_mail_3pl + " AND id_user = " + id_user + " AND id_report_status = 3", 0, True, "", "", "", "")

                FormReportMarkDet.id_report_mark = id_report_mark
                FormReportMarkDet.accept("outside")

                infoCustom("Pickup Order completed.")

                Close()
            Else
                FormMain.SplashScreenManager1.CloseWaitForm()

                stopCustom("Send pickup order error please try again.")
            End If

            If FormMain.SplashScreenManager1.IsSplashFormVisible Then
                FormMain.SplashScreenManager1.CloseWaitForm()
            End If
        End If
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub GVDetail_RowCountChanged(sender As Object, e As EventArgs) Handles GVDetail.RowCountChanged
        For i = 0 To GVDetail.RowCount - 1
            GVDetail.SetRowCellValue(i, "no", i + 1)
        Next
    End Sub

    Private Sub SBSubmit_Click(sender As Object, e As EventArgs) Handles SBSubmit.Click
        validating_store()
        validating_city()
        validating_sub_district()
        validating_weight()
        validating_qty()
        validating_pickupdate()
        validating_receivedate()
        validating_service()
        validating_3pl()
        validating_employee()

        If formIsValidInPanel(ErrorProvider, PanelControl6) Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to submit this pickup order ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                FormMain.SplashScreenManager1.ShowWaitForm()

                Dim query As String = "
                    INSERT INTO tb_sales_return_order_mail_3pl (id_type, id_employee, id_status, pick_up_date, created_date, created_by) VALUES (" + SLUEType.EditValue.ToString + ", " + SLUEEmployee.EditValue.ToString + ", 7, '" + Date.Parse(DEPickupDate.EditValue.ToString).ToString("yyyy-MM-dd") + "', NOW(), " + id_employee_user + "); SELECT LAST_INSERT_ID();
                "

                id_mail_3pl = execute_query(query, 0, True, "", "", "", "")

                execute_non_query("CALL gen_number(" + id_mail_3pl + ", 279)", True, "", "", "", "")

                'store
                Dim stores() As String = CCBEStore.EditValue.ToString.Split(",")

                For i = 0 To stores.Length - 1
                    execute_non_query("INSERT INTO tb_sales_return_order_mail_3pl_store (id_mail_3pl, id_comp) VALUES (" + id_mail_3pl + ", " + stores(i).Replace(" ", "") + ")", True, "", "", "", "")
                Next

                'detail
                If GVDetail.RowCount > 0 Then
                    Dim query_detail As String = "INSERT INTO tb_sales_return_order_mail_3pl_det (id_mail_3pl, id_sales_order_return) VALUES "

                    For i = 0 To GVDetail.RowCount - 1
                        query_detail += "(" + id_mail_3pl + ", " + GVDetail.GetRowCellValue(i, "id_sales_return_order").ToString + "), "
                    Next

                    query_detail = query_detail.Substring(0, query_detail.Length - 2)

                    execute_non_query(query_detail, True, "", "", "", "")
                End If

                submit_who_prepared("279", id_mail_3pl, id_user)

                FormMain.SplashScreenManager1.CloseWaitForm()

                infoCustom("Pickup Order submitted.")
            End If
        Else
            stopCustom("Please check your input.")
        End If
    End Sub

    Private Sub SBApprove_Click(sender As Object, e As EventArgs) Handles SBApprove.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to approve & send this pickup order ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            FormMain.SplashScreenManager1.ShowWaitForm()

            Dim number_skpp As String = execute_query("
                SELECT LPAD((COUNT(id_mail_3pl) + 1), 3, '0') AS number_skpp
                FROM tb_sales_return_order_mail_3pl
                WHERE id_status = 6 AND id_type = 1 AND MONTH(updated_date) = MONTH(NOW()) AND YEAR(updated_date) = YEAR(NOW())
            ", 0, True, "", "", "", "")

            Dim query As String = "UPDATE tb_sales_return_order_mail_3pl SET skpp_number = '" + number_skpp + "', id_status = 6, updated_date = NOW(), updated_by = " + id_employee_user + " WHERE id_mail_3pl = " + id_mail_3pl

            execute_non_query(query, True, "", "", "", "")

            'update report mark
            Dim id_report_mark As String = execute_query("SELECT id_report_mark FROM tb_report_mark WHERE report_mark_type = 279 AND id_report = " + id_mail_3pl + " AND id_user = " + id_user + " AND id_report_status = 3", 0, True, "", "", "", "")

            FormReportMarkDet.id_report_mark = id_report_mark
            FormReportMarkDet.accept("outside")

            FormMain.SplashScreenManager1.CloseWaitForm()

            infoCustom("Pickup Order completed.")

            Close()
        End If
    End Sub
End Class