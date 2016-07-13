﻿Public Class FormMasterEmployeeNewDet
    Public action As String = "-1"
    Public id_employee As String = "-1"
    Dim data_dt As DataTable = Nothing
    Dim id_marriage_stattus_db As String = "-1"



    Sub viewSex()
        Dim query As String = "SELECT * FROM tb_lookup_sex a ORDER BY a.id_sex "
        viewLookupQuery(LESex, query, 0, "sex", "id_sex")
    End Sub

    Sub viewBloodType()
        Dim query As String = "SELECT * FROM tb_lookup_blood_type bld ORDER BY bld.id_blood_type ASC "
        viewLookupQuery(LEBloodType, query, 0, "blood_type", "id_blood_type")
    End Sub

    Sub viewReligion()
        Dim query As String = "SELECT * FROM tb_lookup_religion rlg ORDER BY rlg.id_religion ASC "
        viewLookupQuery(LEReligion, query, 0, "religion", "id_religion")
    End Sub

    Sub viewCountry()
        Dim query As String = "SELECT * FROM tb_m_country cty ORDER BY cty.id_country ASC "
        viewLookupQuery(LECountry, query, 0, "country", "id_country")
    End Sub

    Sub viewActive()
        Dim query As String = "SELECT * FROM tb_lookup_employee_active act ORDER BY act.id_employee_active ASC "
        viewLookupQuery(LEActive, query, 0, "employee_active", "id_employee_active")
    End Sub

    Sub viewDegree()
        Dim query As String = "SELECT * FROM tb_lookup_education a ORDER BY a.id_education ASC "
        viewLookupQuery(LEDegree, query, 0, "education", "id_education")
    End Sub

    Sub viewMarriageStatus()
        Dim query As String = "SELECT * FROM tb_lookup_marriage_status a ORDER BY a.id_marriage_status ASC "
        viewLookupQuery(LEMarriageStatus, query, 0, "marriage_status", "id_marriage_status")
    End Sub

    Sub viewEmployeeStatus()
        Dim query As String = "SELECT * FROM tb_m_employee_status_det a INNER JOIN tb_lookup_employee_status b on b.id_employee_status=a.id_employee_status WHERE a.id_employee='" + id_employee + "' ORDER BY a.id_employee_status_det DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCStatus.DataSource = data
        If GVStatus.RowCount > 0 Then
            BtnDeleteStatus.Enabled = True
        Else
            BtnDeleteStatus.Enabled = False
        End If
    End Sub

    Sub viewEmployeePosition()
        Dim query As String = "SELECT pos.id_employee_position, pos.id_employee,  "
        query += "pos.id_departement_origin, IFNULL(org_dpt.departement, '-') AS `departement_origin`, "
        query += "pos.id_employee_level_origin, IFNULL(org_lvl.employee_level,'-') AS `employee_level_origin`, IFNULL(pos.employee_position_origin,'-') AS `employee_position_origin`, "
        query += "pos.id_departement, dpt.departement, "
        query += "pos.id_employee_level, lvl.employee_level, pos.employee_position, pos.employee_position_date "
        query += "FROM tb_m_employee_position pos  "
        query += "LEFT JOIN tb_m_departement org_dpt ON org_dpt.id_departement = pos.id_departement_origin  "
        query += "LEFT JOIN tb_lookup_employee_level org_lvl ON org_lvl.id_employee_level = pos.id_employee_level_origin "
        query += "INNER JOIN tb_m_departement dpt ON dpt.id_departement = pos.id_departement  "
        query += "INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level = pos.id_employee_level "
        query += "WHERE pos.id_employee='" + id_employee + "'  "
        query += "ORDER BY pos.id_employee_position DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPosition.DataSource = data
        If GVPosition.RowCount > 0 Then
            BtnDeletePosition.Enabled = True
        Else
            BtnDeletePosition.Enabled = False
        End If
    End Sub


    Private Sub FormMasterEmployeeNewDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        data_dt = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEJoinDate.EditValue = data_dt.Rows(0)("dt")
        TxtCode.Focus()
        viewSex()
        viewBloodType()
        viewReligion()
        viewCountry()
        viewActive()
        viewDegree()
        viewMarriageStatus()
        viewEmployeeStatus()
        viewEmployeePosition()
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            XTPDependent.PageEnabled = False
            XTPStatus.PageEnabled = False
            XTPPosition.PageEnabled = False

            'load img
            pre_viewImages("4", PEEmployee, id_employee, False)
        Else
            BtnSaveChanges.Text = "Save Changes"
            XTPDependent.PageEnabled = True
            XTPStatus.PageEnabled = True
            XTPPosition.PageEnabled = True

            Dim query As String = "CALL view_employee('AND emp.id_employee=" + id_employee + " ', 1)"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim datarow As DataRow = data.Rows(0)
            'general tab
            TxtCode.Text = datarow("employee_code").ToString
            TxtFullName.Text = datarow("employee_name").ToString
            TxtNickName.Text = datarow("employee_nick_name").ToString
            TxtInitialName.Text = datarow("employee_initial_name").ToString
            DEJoinDate.EditValue = datarow("employee_join_date")
            DELastDay.EditValue = datarow("employee_last_date")
            LEActive.ItemIndex = LEActive.Properties.GetDataSourceRowIndex("id_employee_active", data.Rows(0)("id_employee_active").ToString)
            LESex.ItemIndex = LESex.Properties.GetDataSourceRowIndex("id_sex", data.Rows(0)("id_sex").ToString)
            LEBloodType.ItemIndex = LEBloodType.Properties.GetDataSourceRowIndex("id_blood_type", data.Rows(0)("id_blood_type").ToString)
            TxtPOB.Text = datarow("employee_pob").ToString
            DEDOB.EditValue = datarow("employee_dob")
            LEReligion.ItemIndex = LEReligion.Properties.GetDataSourceRowIndex("id_religion", data.Rows(0)("id_religion").ToString)
            LECountry.ItemIndex = LECountry.Properties.GetDataSourceRowIndex("id_country", data.Rows(0)("id_country").ToString)
            TxtEthnic.Text = datarow("employee_ethnic").ToString
            LEDegree.ItemIndex = LEDegree.Properties.GetDataSourceRowIndex("id_education", data.Rows(0)("id_education").ToString)
            TxtKTP.Text = datarow("employee_ktp").ToString
            DEKTP.EditValue = datarow("employee_ktp_period")
            TxtPassport.Text = datarow("employee_passport").ToString
            DEPassport.EditValue = datarow("employee_passport_period")
            TxtBPJSTK.Text = datarow("employee_bpjs_tk").ToString
            TxtBPJSSehat.Text = datarow("employee_bpjs_kesehatan").ToString
            TxtNpwp.Text = datarow("employee_npwp").ToString
            TxtPhone.Text = datarow("phone").ToString
            TxtMobilePhone.Text = datarow("phone_mobile").ToString
            TxtPhoneExt.Text = datarow("phone_ext").ToString
            TxtEmailLocal.Text = datarow("email_lokal").ToString
            TxtEmailExternal.Text = datarow("email_external").ToString
            TxtOtherEmail.Text = datarow("email_other").ToString
            MEAddress.Text = datarow("address_primary").ToString
            MEAddressBoarding.Text = datarow("address_additional").ToString
            id_marriage_stattus_db = data.Rows(0)("id_marriage_status").ToString
            TxtHusband.Text = data.Rows(0)("husband").ToString
            TxtWife.Text = data.Rows(0)("wife").ToString
            TxtChild1.Text = data.Rows(0)("child1").ToString
            TxtChild2.Text = data.Rows(0)("child2").ToString
            TxtChild3.Text = data.Rows(0)("child3").ToString

            'load img
            pre_viewImages("4", PEEmployee, id_employee, False)
        End If
    End Sub



    Sub save()

    End Sub

    Private Sub XTPEmployee_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTPEmployee.SelectedPageChanged
        If XTPEmployee.TabPages.Item(XTPEmployee.SelectedTabPageIndex).Name.ToString = "XTPDependent" Then
            LEMarriageStatus.ItemIndex = LEMarriageStatus.Properties.GetDataSourceRowIndex("id_marriage_status", id_marriage_stattus_db)
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        XTPEmployee.TabPages.Item(XTPEmployee.SelectedTabPageIndex + 1).PageEnabled = True
        XTPEmployee.SelectedTabPageIndex = XTPEmployee.SelectedTabPageIndex + 1
        XTPEmployee.TabPages.Item(XTPEmployee.SelectedTabPageIndex - 1).PageEnabled = False
    End Sub

    Sub saveTab()

    End Sub

    Private Sub BtnPrevious_Click(sender As Object, e As EventArgs) Handles BtnPrevious.Click
        XTPEmployee.TabPages.Item(XTPEmployee.SelectedTabPageIndex - 1).PageEnabled = True
        XTPEmployee.SelectedTabPageIndex = XTPEmployee.SelectedTabPageIndex - 1
        XTPEmployee.TabPages.Item(XTPEmployee.SelectedTabPageIndex + 1).PageEnabled = False
    End Sub

    Private Sub TxtCode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtCode.Validating
        EP_TE_cant_blank(ErrorProvider1, TxtCode)
    End Sub

    Private Sub TxtFullName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtFullName.Validating
        EP_TE_cant_blank(ErrorProvider1, TxtFullName)
    End Sub

    Private Sub TxtNickName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtNickName.Validating
        EP_TE_cant_blank(ErrorProvider1, TxtNickName)
    End Sub

    Private Sub TxtInitialName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtInitialName.Validating
        EP_TE_cant_blank(ErrorProvider1, TxtInitialName)
    End Sub

    Private Sub PEEmployee_DoubleClick(sender As Object, e As EventArgs) Handles PEEmployee.DoubleClick
        Cursor = Cursors.WaitCursor
        pre_viewImages("4", PEEmployee, id_employee, True)
        Cursor = Cursors.Default
    End Sub



    Private Sub TxtFocus_Enter(sender As Object, e As EventArgs) Handles TxtFocus.Enter
        LESex.Focus()
    End Sub

    Private Sub TxtPOB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtPOB.Validating
        EP_TE_cant_blank(ErrorProvider1, TxtPOB)
    End Sub

    Private Sub DEDOB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DEDOB.Validating
        EP_DE_cant_blank(ErrorProvider1, DEDOB)
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        ValidateChildren()
        EP_TE_cant_blank(ErrorProvider1, TxtPOB)
        EP_DE_cant_blank(ErrorProvider1, DEDOB)
        EP_ME_cant_blank(ErrorProvider1, MEAddress)

        If Not formIsValidInPanel(ErrorProvider1, PanelControlTop) Or Not formIsValidInXTP(ErrorProvider1, XTPGeneral) Then
            errorInput()
        Else
            Dim id_employee_active As String = addSlashes(LEActive.EditValue.ToString)
            Dim employee_code As String = addSlashes(TxtCode.Text)
            Dim employee_name As String = addSlashes(TxtFullName.Text)
            Dim employee_nick_name As String = addSlashes(TxtNickName.Text)
            Dim employee_initial_name As String = addSlashes(TxtInitialName.Text)
            Dim employee_join_date As String = addSlashes(DateTime.Parse(DEJoinDate.EditValue.ToString).ToString("yyyy-MM-dd"))
            Dim employee_last_date As String = "NULL"
            Try
                employee_last_date = checkNullInput(DateTime.Parse(DELastDay.EditValue.ToString).ToString("yyyy-MM-dd"))
            Catch ex As Exception
            End Try
            Dim id_sex As String = addSlashes(LESex.EditValue.ToString)
            Dim id_blood_type As String = addSlashes(LEBloodType.EditValue.ToString)
            Dim employee_pob As String = addSlashes(TxtPOB.Text)
            Dim employee_dob As String = addSlashes(DateTime.Parse(DEDOB.EditValue.ToString).ToString("yyyy-MM-dd"))
            Dim id_religion As String = addSlashes(LEReligion.EditValue.ToString)
            Dim id_country As String = addSlashes(LECountry.EditValue.ToString)
            Dim employee_ethnic As String = addSlashes(addSlashes(TxtEthnic.Text))
            Dim id_education As String = addSlashes(LEDegree.EditValue.ToString)
            Dim employee_ktp As String = addSlashes(TxtKTP.Text)
            Dim employee_ktp_period As String = "NULL"
            Try
                employee_ktp_period = checkNullInput(DateTime.Parse(DEKTP.EditValue.ToString).ToString("yyyy-MM-dd"))
            Catch ex As Exception
            End Try
            Dim employee_passport As String = addSlashes(TxtPassport.Text)
            Dim employee_passport_period As String = "NULL"
            Try
                employee_passport_period = checkNullInput(DateTime.Parse(DEPassport.EditValue.ToString).ToString("yyyy-MM-dd"))
            Catch ex As Exception
            End Try
            Dim employee_bpjs_tk As String = addSlashes(TxtBPJSTK.Text)
            Dim employee_bpjs_kesehatan As String = addSlashes(TxtBPJSSehat.Text)
            Dim employee_npwp As String = addSlashes(TxtNpwp.Text)
            Dim phone As String = TxtPhone.Text
            Dim phone_mobile As String = TxtMobilePhone.Text
            Dim phone_ext As String = TxtPhoneExt.Text
            Dim email_lokal As String = TxtEmailLocal.Text
            Dim email_external As String = TxtEmailExternal.Text
            Dim email_other As String = TxtOtherEmail.Text
            Dim address_primary As String = addSlashes(MEAddress.Text)
            Dim address_additional As String = addSlashes(MEAddressBoarding.Text)
            Dim id_marriage_status As String = "NULL"
            Try
                id_marriage_status = LEMarriageStatus.EditValue.ToString
            Catch ex As Exception
            End Try
            Dim husband As String = TxtHusband.Text
            Dim wife As String = TxtWife.Text
            Dim child1 As String = TxtChild1.Text
            Dim child2 As String = TxtChild2.Text
            Dim child3 As String = TxtChild3.Text

            If action = "ins" Then
                'main
                Dim query As String = "INSERT INTO tb_m_employee(employee_code, employee_name, employee_nick_name, employee_initial_name, employee_join_date, employee_last_date, id_employee_active, id_sex, id_blood_type, employee_pob, employee_dob, id_religion, id_country, employee_ethnic, id_education, employee_ktp, employee_ktp_period, employee_passport, employee_passport_period, employee_bpjs_tk, employee_bpjs_kesehatan, employee_npwp, address_primary, address_additional, phone, phone_mobile, phone_ext, email_lokal, email_external, email_other) "
                query += "VALUES('" + employee_code + "', '" + employee_name + "', '" + employee_nick_name + "', '" + employee_initial_name + "', '" + employee_join_date + "', " + employee_last_date + ", '" + id_employee_active + "', '" + id_sex + "', '" + id_blood_type + "', '" + employee_pob + "', '" + employee_dob + "', '" + id_religion + "', '" + id_country + "', '" + employee_ethnic + "', '" + id_education + "', '" + employee_ktp + "', " + employee_ktp_period + ", '" + employee_passport + "', " + employee_passport_period + ", '" + employee_bpjs_tk + "', '" + employee_bpjs_kesehatan + "', '" + employee_npwp + "', '" + address_primary + "', '" + address_additional + "', '" + phone + "', '" + phone_mobile + "', '" + phone_ext + "', '" + email_lokal + "', '" + email_external + "', '" + email_other + "'); SELECT LAST_INSERT_ID(); "
                id_employee = execute_query(query, 0, True, "", "", "", "")

                'pic
                save_image_ori(PEEmployee, emp_image_path, id_employee & ".jpg")

                'info & refresh
                FormMasterEmployee.viewEmployee()
                FormMasterEmployee.GVEmployee.FocusedRowHandle = find_row(FormMasterEmployee.GVEmployee, "id_employee", id_employee)
                action = "upd"
                actionLoad()
                infoCustom("Created successfully, please add some information detail.")
            Else
                'main
                Dim query As String = "UPDATE tb_m_employee SET "
                query += "employee_code='" + employee_code + "', "
                query += "employee_name='" + employee_name + "', "
                query += "employee_nick_name='" + employee_nick_name + "', "
                query += "employee_initial_name='" + employee_initial_name + "', "
                query += "employee_join_date='" + employee_join_date + "', "
                query += "employee_last_date=" + employee_last_date + ", "
                query += "id_employee_active='" + id_employee_active + "', "
                query += "id_sex='" + id_sex + "', "
                query += "id_blood_type='" + id_blood_type + "', "
                query += "employee_pob='" + employee_pob + "', "
                query += "employee_dob='" + employee_dob + "', "
                query += "id_religion='" + id_religion + "', "
                query += "id_country='" + id_country + "', "
                query += "employee_ethnic='" + employee_ethnic + "', "
                query += "id_education='" + id_education + "', "
                query += "id_marriage_status=" + id_marriage_status + ", "
                query += "employee_ktp='" + employee_ktp + "', "
                query += "employee_ktp_period=" + employee_ktp_period + ", "
                query += "employee_passport='" + employee_passport + "', "
                query += "employee_passport_period=" + employee_passport_period + ", "
                query += "employee_bpjs_tk='" + employee_bpjs_tk + "', "
                query += "employee_bpjs_kesehatan='" + employee_bpjs_kesehatan + "', "
                query += "employee_npwp='" + employee_npwp + "', "
                query += "phone='" + phone + "', "
                query += "phone_mobile='" + phone_mobile + "', "
                query += "phone_ext='" + phone_ext + "', "
                query += "email_lokal='" + email_lokal + "', "
                query += "email_external='" + email_external + "', "
                query += "email_other='" + email_other + "', "
                query += "address_primary='" + address_primary + "', "
                query += "address_additional='" + address_additional + "', "
                query += "husband='" + husband + "', "
                query += "wife='" + wife + "', "
                query += "child1='" + child1 + "', "
                query += "child2='" + child2 + "', "
                query += "child3='" + child3 + "' "
                query += "WHERE id_employee=" + id_employee + " "
                execute_non_query(query, True, "", "", "", "")

                'pic
                save_image_ori(PEEmployee, emp_image_path, id_employee & ".jpg")

                'info & refresh
                FormMasterEmployee.viewEmployee()
                FormMasterEmployee.GVEmployee.FocusedRowHandle = find_row(FormMasterEmployee.GVEmployee, "id_employee", id_employee)
                action = "upd"
                actionLoad()
                infoCustom("Edited successfully.")
            End If
        End If
    End Sub



    Private Sub BtnAddNationality_Click(sender As Object, e As EventArgs) Handles BtnAddNationality.Click
        Cursor = Cursors.WaitCursor
        FormMasterArea.quick_edit = "1"
        FormMasterArea.id_pop_up = "1"
        FormMasterArea.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub MEAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles MEAddress.KeyDown
        EP_ME_cant_blank(ErrorProvider1, MEAddress)
    End Sub

    Private Sub DEDOB_EditValueChanged(sender As Object, e As EventArgs) Handles DEDOB.EditValueChanged
        Dim age As Long = 0
        Try
            age = DateDiff(DateInterval.Year, DEDOB.EditValue, data_dt.Rows(0)("dt"))
        Catch ex As Exception
        End Try
        TxtAge.Text = age.ToString + " years old"
    End Sub

    Private Sub LEMarriageStatus_EditValueChanged(sender As Object, e As EventArgs) Handles LEMarriageStatus.EditValueChanged
        'Try
        '    Dim stt As String = LEMarriageStatus.EditValue.ToString
        '    execute_non_query("UPDATE tb_m_employee SET id_marriage_status='" + stt + "' WHERE id_employee='" + id_employee + "'", True, "", "", "", "")
        '    infoCustom("Status changed successfully.")
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub FormMasterEmployeeNewDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAddDependent_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        FormMasterEmployeeDependent.action = "ins"
        FormMasterEmployeeDependent.id_employee = id_employee
        FormMasterEmployeeDependent.ShowDialog()
        Cursor = Cursors.Default
    End Sub


    Private Sub LEActive_EditValueChanged(sender As Object, e As EventArgs) Handles LEActive.EditValueChanged
        If LEActive.EditValue.ToString > 1 Then
            DELastDay.Enabled = True
        Else
            DELastDay.EditValue = Nothing
            DELastDay.Enabled = False
        End If
    End Sub

    Private Sub BtnAddStatus_Click(sender As Object, e As EventArgs) Handles BtnAddStatus.Click
        Cursor = Cursors.WaitCursor
        FormMasterEmployeeStatus.id_employee = id_employee
        FormMasterEmployeeStatus.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDeleteStatus_Click(sender As Object, e As EventArgs) Handles BtnDeleteStatus.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        Dim id_employee_status_det As String = GVStatus.GetFocusedRowCellDisplayText("id_employee_status_det").ToString
        If confirm = Windows.Forms.DialogResult.Yes Then
            Try
                Dim query As String = "DELETE FROM tb_m_employee_status_det WHERE id_employee_status_det='" + id_employee_status_det + "'"
                execute_non_query(query, True, "", "", "", "")
                viewEmployeeStatus()

                If GVStatus.RowCount > 0 Then
                    Dim query_upd As String = "UPDATE tb_m_employee emp "
                    query_upd += "INNER JOIN ( "
                    query_upd += "SELECT a.id_employee_status, a.id_employee FROM tb_m_employee_status_det a  "
                    query_upd += "INNER JOIN ( "
                    query_upd += "SELECT MAX(id_employee_status_det) AS id_employee_status_det "
                    query_upd += "FROM tb_m_employee_status_det b  "
                    query_upd += "WHERE b.id_employee='" + id_employee + "' "
                    query_upd += ") mx ON mx.id_employee_status_det = a.id_employee_status_det "
                    query_upd += "WHERE a.id_employee='" + id_employee + "' ORDER BY a.id_employee_status_det DESC "
                    query_upd += ") dt ON dt.id_employee = emp.id_employee "
                    query_upd += "SET emp.id_employee_status = dt.id_employee_status "
                    execute_non_query(query_upd, True, "", "", "", "")
                Else
                    Dim query_upd As String = "UPDATE tb_m_employee emp "
                    query_upd += "SET emp.id_employee_status =0 "
                    query_upd += "WHERE emp.id_employee='" + id_employee + "' "
                    execute_non_query(query_upd, True, "", "", "", "")
                End If
            Catch ex As Exception
                errorDelete()
            End Try
        End If
    End Sub

    Private Sub BtnAddPosition_Click(sender As Object, e As EventArgs) Handles BtnAddPosition.Click
        Cursor = Cursors.WaitCursor
        FormMasterEmployeePosition.id_employee = id_employee
        FormMasterEmployeePosition.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDeletePosition_Click(sender As Object, e As EventArgs) Handles BtnDeletePosition.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        Dim id_employee_position As String = GVPosition.GetFocusedRowCellDisplayText("id_employee_position").ToString
        If confirm = Windows.Forms.DialogResult.Yes Then
            Try
                Dim query As String = "DELETE FROM tb_m_employee_position WHERE id_employee_position='" + id_employee_position + "'"
                execute_non_query(query, True, "", "", "", "")
                viewEmployeePosition()

                If GVPosition.RowCount > 0 Then
                    Dim query_upd As String = "UPDATE tb_m_employee emp "
                    query_upd += "INNER JOIN ( "
                    query_upd += "SELECT a.id_employee_position, a.id_departement, a.id_employee, a.id_employee_level, a.employee_position FROM tb_m_employee_position a  "
                    query_upd += "INNER JOIN ( "
                    query_upd += "SELECT MAX(id_employee_position) AS id_employee_position "
                    query_upd += "FROM tb_m_employee_position b  "
                    query_upd += "WHERE b.id_employee='" + id_employee + "' "
                    query_upd += ") mx ON mx.id_employee_position = a.id_employee_position "
                    query_upd += "WHERE a.id_employee='" + id_employee + "' ORDER BY a.id_employee_position DESC "
                    query_upd += ") dt ON dt.id_employee = emp.id_employee "
                    query_upd += "SET emp.id_departement = dt.id_departement, "
                    query_upd += "emp.id_employee_level = dt.id_employee_level, "
                    query_upd += "emp.employee_position = dt.employee_position "
                    execute_non_query(query_upd, True, "", "", "", "")
                Else
                    Dim query_upd As String = "UPDATE tb_m_employee emp "
                    query_upd += "SET emp.id_departement=NULL, emp.id_employee_level =NULL, emp.employee_position=NULL "
                    query_upd += "WHERE emp.id_employee='" + id_employee + "' "
                    execute_non_query(query_upd, True, "", "", "", "")
                End If
            Catch ex As Exception
                errorDelete()
            End Try
        End If
    End Sub

    Private Sub DEJoinDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DEJoinDate.Validating
        EP_DE_cant_blank(ErrorProvider1, DEJoinDate)
    End Sub
End Class