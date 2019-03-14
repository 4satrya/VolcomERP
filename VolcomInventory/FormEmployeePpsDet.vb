﻿Public Class FormEmployeePpsDet
    Public id_pps As String = "-1"
    Public is_new As String = "-1"
    Public id_employee As String = "-1"
    Public pps_path As String = "\\192.168.1.2\dataapp$\emp_pps\"

    Sub viewSex()
        Dim query As String = "SELECT * FROM tb_lookup_sex a ORDER BY a.id_sex "
        viewLookupQuery(LESex, query, 0, "sex", "id_sex")
        viewLookupQuery(LESexB, query, 0, "sex", "id_sex")
        LESexB.Properties.ForceInitialize()
    End Sub

    Sub viewBloodType()
        Dim query As String = "SELECT * FROM tb_lookup_blood_type bld ORDER BY bld.id_blood_type ASC "
        viewLookupQuery(LEBloodType, query, 0, "blood_type", "id_blood_type")
        viewLookupQuery(LEBloodTypeB, query, 0, "blood_type", "id_blood_type")
        LEBloodTypeB.Properties.ForceInitialize()
    End Sub

    Sub viewReligion()
        Dim query As String = "SELECT * FROM tb_lookup_religion rlg ORDER BY rlg.id_religion ASC "
        viewLookupQuery(LEReligion, query, 0, "religion", "id_religion")
        viewLookupQuery(LEReligionB, query, 0, "religion", "id_religion")
        LEReligionB.Properties.ForceInitialize()
    End Sub

    Sub viewCountry()
        Dim query As String = "SELECT * FROM tb_m_country cty ORDER BY cty.id_country ASC "
        viewLookupQuery(LECountry, query, 0, "country", "id_country")
        viewLookupQuery(LECountryB, query, 0, "country", "id_country")
        LECountryB.Properties.ForceInitialize()
    End Sub

    Sub viewActive()
        Dim query As String = "SELECT * FROM tb_lookup_employee_active act ORDER BY act.id_employee_active ASC "
        viewLookupQuery(LEActive, query, 0, "employee_active", "id_employee_active")
        viewLookupQuery(LEActiveB, query, 0, "employee_active", "id_employee_active")
        LEActiveB.Properties.ForceInitialize()
    End Sub

    Sub viewDegree()
        Dim query As String = "SELECT * FROM tb_lookup_education a ORDER BY a.id_education ASC "
        viewLookupQuery(LEDegree, query, 0, "education", "id_education")
        viewLookupQuery(LEDegreeB, query, 0, "education", "id_education")
        LEDegreeB.Properties.ForceInitialize()
    End Sub

    Sub viewMarriageStatus()
        Dim query As String = "SELECT * FROM tb_lookup_marriage_status a ORDER BY a.id_marriage_status ASC "
        viewLookupQuery(LEMarriageStatus, query, 0, "marriage_status", "id_marriage_status")
        viewLookupQuery(LEMarriageStatusB, query, 0, "marriage_status", "id_marriage_status")
        LEMarriageStatusB.Properties.ForceInitialize()
    End Sub

    Sub viewEmployeeStatus()
        Dim query As String = "SELECT * FROM tb_lookup_employee_status a WHERE a.id_employee_status>0 ORDER BY a.id_employee_status ASC "
        viewLookupQuery(LEEmployeeStatus, query, 0, "employee_status", "id_employee_status")
        viewLookupQuery(LEEmployeeStatusB, query, 0, "employee_status", "id_employee_status")
        LEEmployeeStatusB.Properties.ForceInitialize()
    End Sub

    Sub viewDepartement()
        Dim query As String = "SELECT * FROM tb_m_departement"
        viewLookupQuery(LEDepartement, query, 0, "departement", "id_departement")
        viewLookupQuery(LEDepartementB, query, 0, "departement", "id_departement")
        LEDepartementB.Properties.ForceInitialize()
    End Sub

    Sub viewSubDepartement()
        Dim query As String = "SELECT * FROM tb_m_departement_sub"
        viewLookupQuery(LESubDepartement, query, 0, "departement_sub", "id_departement_sub")
        viewLookupQuery(LESubDepartementB, query, 0, "departement_sub", "id_departement_sub")
        LESubDepartementB.Properties.ForceInitialize()
    End Sub

    Sub viewLevel()
        Dim query As String = "SELECT * FROM tb_lookup_employee_level"
        viewLookupQuery(LELevel, query, 0, "employee_level", "id_employee_level")
        viewLookupQuery(LELevelB, query, 0, "employee_level", "id_employee_level")
        LELevelB.Properties.ForceInitialize()
    End Sub

    Private Sub FormEmployeePpsDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            FormEmloyeePps.load_pps()
        Catch ex As Exception
        End Try

        Dispose()
    End Sub

    Private Sub FormEmployeePpsDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initLoad()
    End Sub

    Sub initLoad()
        ' load lookup edit
        viewSex()
        viewBloodType()
        viewReligion()
        viewCountry()
        viewActive()
        viewDegree()
        viewMarriageStatus()
        viewEmployeeStatus()
        viewDepartement()
        viewSubDepartement()
        viewLevel()

        ' load propose
        loadPropose()

        ' load before
        If is_new = "-1" Then
            loadBefore()
        End If

        ' load number & note
        If Not id_pps = "-1" Then
            Dim data_report As DataTable = execute_query("SELECT number, note FROM tb_employee_pps WHERE id_employee_pps = '" + id_pps + "'", -1, True, "", "", "", "")

            TxtNumber.EditValue = data_report.Rows(0)("number").ToString
            MENote.EditValue = data_report.Rows(0)("note").ToString
        End If

        ' load image
        pre_viewImages("4", PE, id_employee, False)

        If Not id_pps = "-1" Then
            viewImages(PE, pps_path, id_pps + "_ava", False)
        End If

        If is_new = "-1" Then
            pre_viewImages("4", PEB, id_employee, False)

            If Not id_pps = "-1" Then
                viewImages(PEB, pps_path, id_pps + "_ava_old", False)
            End If
        End If

        ' check changes
        If Not id_pps = "-1" Then
            checkChanges()
        End If

        ' check control
        If is_new = "1" Then
            XTPBefore.PageVisible = False
        End If

        If is_new = "-1" Then
            TxtCode.ReadOnly = True
        End If

        If Not id_pps = "-1" Then
            TxtCode.ReadOnly = True
            TxtFullName.ReadOnly = True
            TxtNickName.ReadOnly = True
            TxtInitialName.ReadOnly = True
            DEJoinDate.ReadOnly = True
            LEActive.ReadOnly = True
            CEPIC.ReadOnly = True
            DELastDay.ReadOnly = True
            LESex.ReadOnly = True
            LEBloodType.ReadOnly = True
            TxtPOB.ReadOnly = True
            DEDOB.ReadOnly = True
            TxtAge.ReadOnly = True
            LEReligion.ReadOnly = True
            LECountry.ReadOnly = True
            BtnAddNationality.Enabled = False
            TxtEthnic.ReadOnly = True
            LEDegree.ReadOnly = True
            TxtKTP.ReadOnly = True
            DEKTP.ReadOnly = True
            TxtPassport.ReadOnly = True
            DEPassport.ReadOnly = True
            TxtNpwp.ReadOnly = True
            TxtPhone.ReadOnly = True
            TxtMobilePhone.ReadOnly = True
            MEAddress.ReadOnly = True
            MEAddressBoarding.ReadOnly = True
            LEMarriageStatus.ReadOnly = True
            TxtHusband.ReadOnly = True
            TxtWife.ReadOnly = True
            TxtChild1.ReadOnly = True
            TxtChild2.ReadOnly = True
            TxtChild3.ReadOnly = True
            LEEmployeeStatus.ReadOnly = True
            DEEmployeeStatusStart.ReadOnly = True
            DEEmployeeStatusEnd.ReadOnly = True
            LEDepartement.ReadOnly = True
            LESubDepartement.ReadOnly = True
            LELevel.ReadOnly = True
            TxtPosition.ReadOnly = True
            DEEffectiveDate.ReadOnly = True
            TENoRek.ReadOnly = True
            TERekeningName.ReadOnly = True
            CEKoperasi.ReadOnly = True
            TxtBPJSTK.ReadOnly = True
            CEJP.ReadOnly = True
            CEJHT.ReadOnly = True
            DERegBPJSTK.ReadOnly = True
            TxtBPJSSehat.ReadOnly = True
            CEBPJS.ReadOnly = True
            DERegBPJSKes.ReadOnly = True
            TxtBasicSalary.ReadOnly = True
            TxtAllowJob.ReadOnly = True
            TxtAllowMeal.ReadOnly = True
            TxtAllowTrans.ReadOnly = True
            TxtAllowHouse.ReadOnly = True
            TxtAllowCar.ReadOnly = True

            MENote.ReadOnly = True
            SBSave.Enabled = False
            BMark.Enabled = True
        End If
    End Sub

    Sub loadPropose()
        ' default
        TxtProposedBy.EditValue = get_emp(id_employee_user, "2")
        TxtProposedDate.EditValue = Now
        DEEmployeeStatusStart.EditValue = ""
        DEEmployeeStatusEnd.EditValue = ""
        DEEffectiveDate.EditValue = ""
        DEDOB.EditValue = ""
        DEJoinDate.EditValue = ""
        DELastDay.EditValue = ""
        DEKTP.EditValue = ""
        DEPassport.EditValue = ""
        DERegBPJSTK.EditValue = ""
        DERegBPJSKes.EditValue = ""

        ' load from db
        If is_new = "-1" Then
            Dim query As String = ""

            If Not id_pps = "-1" Then
                query = "SELECT *, TIMESTAMPDIFF(YEAR, employee_dob, DATE(NOW())) AS age FROM tb_employee_pps WHERE id_employee_pps = '" + id_pps + "'"
            Else
                query = "CALL view_employee('AND emp.id_employee=" + id_employee + " ', 1)"
            End If

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TxtCode.EditValue = data.Rows(0)("employee_code").ToString
            TxtFullName.EditValue = data.Rows(0)("employee_name").ToString
            TxtNickName.EditValue = data.Rows(0)("employee_nick_name").ToString
            TxtInitialName.EditValue = data.Rows(0)("employee_initial_name").ToString
            DEJoinDate.EditValue = data.Rows(0)("employee_join_date")
            LEActive.ItemIndex = LEActive.Properties.GetDataSourceRowIndex("id_employee_active", data.Rows(0)("id_employee_active").ToString)
            CEPIC.Checked = If(data.Rows(0)("is_pic").ToString = "1", True, False)
            DELastDay.EditValue = data.Rows(0)("employee_last_date")
            LESex.ItemIndex = LESex.Properties.GetDataSourceRowIndex("id_sex", data.Rows(0)("id_sex").ToString)
            LEBloodType.ItemIndex = LEBloodType.Properties.GetDataSourceRowIndex("id_blood_type", data.Rows(0)("id_blood_type").ToString)
            TxtPOB.EditValue = data.Rows(0)("employee_pob").ToString
            DEDOB.EditValue = data.Rows(0)("employee_dob")
            TxtAge.EditValue = data.Rows(0)("age").ToString
            LEReligion.ItemIndex = LEReligion.Properties.GetDataSourceRowIndex("id_religion", data.Rows(0)("id_religion").ToString)
            LECountry.ItemIndex = LECountry.Properties.GetDataSourceRowIndex("id_country", data.Rows(0)("id_country").ToString)
            'BtnAddNationality
            TxtEthnic.EditValue = data.Rows(0)("employee_ethnic").ToString
            LEDegree.ItemIndex = LEDegree.Properties.GetDataSourceRowIndex("id_education", data.Rows(0)("id_education").ToString)
            TxtKTP.EditValue = data.Rows(0)("employee_ktp").ToString
            DEKTP.EditValue = data.Rows(0)("employee_ktp_period")
            TxtPassport.EditValue = data.Rows(0)("employee_passport").ToString
            DEPassport.EditValue = data.Rows(0)("employee_passport_period")
            TxtNpwp.EditValue = data.Rows(0)("employee_npwp").ToString
            TxtPhone.EditValue = data.Rows(0)("phone").ToString
            TxtMobilePhone.EditValue = data.Rows(0)("phone_mobile").ToString
            MEAddress.EditValue = data.Rows(0)("address_primary").ToString
            MEAddressBoarding.EditValue = data.Rows(0)("address_additional").ToString
            LEMarriageStatus.ItemIndex = LEMarriageStatusB.Properties.GetDataSourceRowIndex("id_marriage_status", data.Rows(0)("id_marriage_status").ToString)
            TxtHusband.EditValue = data.Rows(0)("husband").ToString
            TxtWife.EditValue = data.Rows(0)("wife").ToString
            TxtChild1.EditValue = data.Rows(0)("child1").ToString
            TxtChild2.EditValue = data.Rows(0)("child2").ToString
            TxtChild3.EditValue = data.Rows(0)("child3").ToString
            LEEmployeeStatus.ItemIndex = LEEmployeeStatus.Properties.GetDataSourceRowIndex("id_employee_status", data.Rows(0)("id_employee_status").ToString)
            DEEmployeeStatusStart.EditValue = data.Rows(0)("start_period")
            DEEmployeeStatusEnd.EditValue = data.Rows(0)("end_period")
            LEDepartement.ItemIndex = LEDepartement.Properties.GetDataSourceRowIndex("id_departement", data.Rows(0)("id_departement").ToString)
            LESubDepartement.ItemIndex = LESubDepartement.Properties.GetDataSourceRowIndex("id_departement_sub", data.Rows(0)("id_departement_sub").ToString)
            LELevel.ItemIndex = LELevel.Properties.GetDataSourceRowIndex("id_employee_level", data.Rows(0)("id_employee_level").ToString)
            TxtPosition.EditValue = data.Rows(0)("employee_position").ToString
            DEEffectiveDate.EditValue = data.Rows(0)("employee_position_date")
            TENoRek.EditValue = data.Rows(0)("employee_no_rek").ToString
            TERekeningName.EditValue = data.Rows(0)("employee_rek_name").ToString
            CEKoperasi.Checked = If(data.Rows(0)("is_koperasi").ToString = "yes", True, False)
            TxtBPJSTK.EditValue = data.Rows(0)("employee_bpjs_tk").ToString
            CEJP.Checked = If(data.Rows(0)("is_jp").ToString = "yes", True, False)
            CEJHT.Checked = If(data.Rows(0)("is_jht").ToString = "yes", True, False)
            DERegBPJSTK.EditValue = data.Rows(0)("employee_bpjs_tk_date")
            TxtBPJSSehat.EditValue = data.Rows(0)("employee_bpjs_kesehatan").ToString
            CEBPJS.Checked = If(data.Rows(0)("is_bpjs_volcom").ToString = "yes", True, False)
            DERegBPJSKes.EditValue = data.Rows(0)("employee_bpjs_kesehatan_date")
            TxtBasicSalary.EditValue = data.Rows(0)("basic_salary").ToString
            TxtAllowJob.EditValue = data.Rows(0)("allow_job").ToString
            TxtAllowMeal.EditValue = data.Rows(0)("allow_meal").ToString
            TxtAllowTrans.EditValue = data.Rows(0)("allow_trans").ToString
            TxtAllowHouse.EditValue = data.Rows(0)("allow_house").ToString
            TxtAllowCar.EditValue = data.Rows(0)("allow_car").ToString
            TETotal.EditValue = Decimal.Parse(If(data.Rows(0)("basic_salary").ToString = "", "0", data.Rows(0)("basic_salary").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_job").ToString = "", "0", data.Rows(0)("allow_job").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_meal").ToString = "", "0", data.Rows(0)("allow_meal").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_trans").ToString = "", "0", data.Rows(0)("allow_trans").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_house").ToString = "", "0", data.Rows(0)("allow_house").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_car").ToString = "", "0", data.Rows(0)("allow_car").ToString))
        End If
    End Sub

    Sub loadBefore()
        ' load from db
        If is_new = "-1" Then
            Dim query As String = ""

            If Not id_pps = "-1" Then
                query = "SELECT *, TIMESTAMPDIFF(YEAR, employee_dob, DATE(NOW())) AS age FROM tb_employee_pps_old WHERE id_employee_pps = '" + id_pps + "'"
            Else
                query = "CALL view_employee('AND emp.id_employee=" + id_employee + " ', 1)"
            End If

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TxtCodeB.EditValue = data.Rows(0)("employee_code").ToString
            TxtFullNameB.EditValue = data.Rows(0)("employee_name").ToString
            TxtNickNameB.EditValue = data.Rows(0)("employee_nick_name").ToString
            TxtInitialNameB.EditValue = data.Rows(0)("employee_initial_name").ToString
            DEJoinDateB.EditValue = data.Rows(0)("employee_join_date")
            LEActiveB.ItemIndex = LEActiveB.Properties.GetDataSourceRowIndex("id_employee_active", data.Rows(0)("id_employee_active").ToString)
            LEActiveB.ReadOnly = True
            CEPICB.Checked = If(data.Rows(0)("is_pic").ToString = "1", True, False)
            DELastDayB.EditValue = data.Rows(0)("employee_last_date")
            LESexB.ItemIndex = LESexB.Properties.GetDataSourceRowIndex("id_sex", data.Rows(0)("id_sex").ToString)
            LESexB.ReadOnly = True
            LEBloodTypeB.ItemIndex = LEBloodTypeB.Properties.GetDataSourceRowIndex("id_blood_type", data.Rows(0)("id_blood_type").ToString)
            LEBloodTypeB.ReadOnly = True
            TxtPOBB.EditValue = data.Rows(0)("employee_pob").ToString
            DEDOBB.EditValue = data.Rows(0)("employee_dob")
            TxtAgeB.EditValue = data.Rows(0)("age").ToString
            LEReligionB.ItemIndex = LEReligionB.Properties.GetDataSourceRowIndex("id_religion", data.Rows(0)("id_religion").ToString)
            LEReligionB.ReadOnly = True
            LECountryB.ItemIndex = LECountryB.Properties.GetDataSourceRowIndex("id_country", data.Rows(0)("id_country").ToString)
            LECountryB.ReadOnly = True
            'BtnAddNationalityB
            TxtEthnicB.EditValue = data.Rows(0)("employee_ethnic").ToString
            LEDegreeB.ItemIndex = LEDegreeB.Properties.GetDataSourceRowIndex("id_education", data.Rows(0)("id_education").ToString)
            LEDegreeB.ReadOnly = True
            TxtKTPB.EditValue = data.Rows(0)("employee_ktp").ToString
            DEKTPB.EditValue = data.Rows(0)("employee_ktp_period")
            TxtPassportB.EditValue = data.Rows(0)("employee_passport").ToString
            DEPassportB.EditValue = data.Rows(0)("employee_passport_period")
            TxtNpwpB.EditValue = data.Rows(0)("employee_npwp").ToString
            TxtPhoneB.EditValue = data.Rows(0)("phone").ToString
            TxtMobilePhoneB.EditValue = data.Rows(0)("phone_mobile").ToString
            MEAddressB.EditValue = data.Rows(0)("address_primary").ToString
            MEAddressBoardingB.EditValue = data.Rows(0)("address_additional").ToString
            LEMarriageStatusB.ItemIndex = LEMarriageStatusB.Properties.GetDataSourceRowIndex("id_marriage_status", data.Rows(0)("id_marriage_status").ToString)
            LEMarriageStatusB.ReadOnly = True
            TxtHusbandB.EditValue = data.Rows(0)("husband").ToString
            TxtWifeB.EditValue = data.Rows(0)("wife").ToString
            TxtChild1B.EditValue = data.Rows(0)("child1").ToString
            TxtChild2B.EditValue = data.Rows(0)("child2").ToString
            TxtChild3B.EditValue = data.Rows(0)("child3").ToString
            LEEmployeeStatusB.ItemIndex = LEEmployeeStatusB.Properties.GetDataSourceRowIndex("id_employee_status", data.Rows(0)("id_employee_status").ToString)
            LEEmployeeStatusB.ReadOnly = True
            DEEmployeeStatusStartB.EditValue = data.Rows(0)("start_period")
            DEEmployeeStatusEndB.EditValue = data.Rows(0)("end_period")
            LEDepartementB.ItemIndex = LEDepartementB.Properties.GetDataSourceRowIndex("id_departement", data.Rows(0)("id_departement").ToString)
            LEDepartementB.ReadOnly = True
            LESubDepartementB.ItemIndex = LESubDepartementB.Properties.GetDataSourceRowIndex("id_departement_sub", data.Rows(0)("id_departement_sub").ToString)
            LESubDepartementB.ReadOnly = True
            LELevelB.ItemIndex = LELevelB.Properties.GetDataSourceRowIndex("id_employee_level", data.Rows(0)("id_employee_level").ToString)
            LELevelB.ReadOnly = True
            TxtPositionB.EditValue = data.Rows(0)("employee_position").ToString
            DEEffectiveDateB.EditValue = data.Rows(0)("employee_position_date")
            TENoRekB.EditValue = data.Rows(0)("employee_no_rek").ToString
            TERekeningNameB.EditValue = data.Rows(0)("employee_rek_name").ToString
            CEKoperasiB.Checked = If(data.Rows(0)("is_koperasi").ToString = "yes", True, False)
            TxtBPJSTKB.EditValue = data.Rows(0)("employee_bpjs_tk").ToString
            CEJPB.Checked = If(data.Rows(0)("is_jp").ToString = "yes", True, False)
            CEJHTB.Checked = If(data.Rows(0)("is_jht").ToString = "yes", True, False)
            DERegBPJSTKB.EditValue = data.Rows(0)("employee_bpjs_tk_date")
            TxtBPJSSehatB.EditValue = data.Rows(0)("employee_bpjs_kesehatan").ToString
            CEBPJSB.Checked = If(data.Rows(0)("is_bpjs_volcom").ToString = "yes", True, False)
            DERegBPJSKesB.EditValue = data.Rows(0)("employee_bpjs_kesehatan_date")
            TxtBasicSalaryB.EditValue = data.Rows(0)("basic_salary").ToString
            TxtAllowJobB.EditValue = data.Rows(0)("allow_job").ToString
            TxtAllowMealB.EditValue = data.Rows(0)("allow_meal").ToString
            TxtAllowTransB.EditValue = data.Rows(0)("allow_trans").ToString
            TxtAllowHouseB.EditValue = data.Rows(0)("allow_house").ToString
            TxtAllowCarB.EditValue = data.Rows(0)("allow_car").ToString
            TETotalB.EditValue = Decimal.Parse(If(data.Rows(0)("basic_salary").ToString = "", "0", data.Rows(0)("basic_salary").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_job").ToString = "", "0", data.Rows(0)("allow_job").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_meal").ToString = "", "0", data.Rows(0)("allow_meal").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_trans").ToString = "", "0", data.Rows(0)("allow_trans").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_house").ToString = "", "0", data.Rows(0)("allow_house").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_car").ToString = "", "0", data.Rows(0)("allow_car").ToString))
        End If
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        EP_TE_cant_blank(ErrorProvider1, TxtCode)
        EP_TE_cant_blank(ErrorProvider1, TxtPOB)
        EP_DE_cant_blank(ErrorProvider1, DEDOB)
        EP_ME_cant_blank(ErrorProvider1, MEAddress)
        EP_DE_cant_blank(ErrorProvider1, DEEmployeeStatusStart)
        EP_DE_cant_blank(ErrorProvider1, DEEffectiveDate)

        ' check code
        Dim query_cek As String = "SELECT COUNT(*) as `jum` FROM tb_m_employee e WHERE e.employee_code='" + addSlashes(TxtCode.Text) + "' "

        If is_new = "-1" Then
            query_cek += "AND e.id_employee!='" + id_employee + "' "
        End If

        Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")

        If Not formIsValidInGroup(ErrorProvider1, GCGeneralPropose) Or Not formIsValidInGroup(ErrorProvider1, GCDetailPropose) Or Not formIsValidInGroup(ErrorProvider1, GCContractPropose) Then
            errorInput()
        ElseIf data_cek.Rows(0)("jum") > 0 Then
            stopCustom("Employee code is already exist !")
        Else
            ' store
            Dim id_type As String = If(is_new = "-1", "1", "2")
            Dim number As String = "0"
            Dim id_report_status As String = "1"
            Dim note As String = addSlashes(MENote.Text)
            Dim id_employee_store As String = If(id_employee = "-1", "NULL", "'" + id_employee + "'")
            Dim id_employee_active As String = LEActive.EditValue.ToString
            Dim employee_code As String = addSlashes(TxtCode.Text)
            Dim employee_name As String = addSlashes(TxtFullName.Text)
            Dim employee_nick_name As String = addSlashes(TxtNickName.Text)
            Dim employee_initial_name As String = addSlashes(TxtInitialName.Text)
            Dim id_departement As String = LEDepartement.EditValue.ToString
            Dim id_departement_sub As String = LESubDepartement.EditValue.ToString
            Dim id_sex As String = LESex.EditValue.ToString
            Dim id_blood_type As String = LEBloodType.EditValue.ToString
            Dim id_religion As String = LEReligion.EditValue.ToString
            Dim id_country As String = LECountry.EditValue.ToString
            Dim id_education As String = LEDegree.EditValue.ToString
            Dim id_employee_status As String = LEEmployeeStatus.EditValue.ToString
            Dim start_period As String = If(DEEmployeeStatusStart.EditValue.ToString = "", "NULL", "'" + DateTime.Parse(DEEmployeeStatusStart.EditValue.ToString).ToString("yyyy-MM-dd") + "'")
            Dim end_period As String = If(DEEmployeeStatusEnd.EditValue.ToString = "", "NULL", "'" + DateTime.Parse(DEEmployeeStatusEnd.EditValue.ToString).ToString("yyyy-MM-dd") + "'")
            Dim employee_position_date As String = If(DEEffectiveDate.EditValue.ToString = "", "NULL", "'" + DateTime.Parse(DEEffectiveDate.EditValue.ToString).ToString("yyyy-MM-dd") + "'")
            Dim employee_pob As String = addSlashes(TxtPOB.Text)
            Dim employee_dob As String = If(DEDOB.EditValue.ToString = "", "NULL", "'" + DateTime.Parse(DEDOB.EditValue.ToString).ToString("yyyy-MM-dd") + "'")
            Dim employee_ethnic As String = addSlashes(TxtEthnic.Text)
            Dim employee_join_date As String = If(DEJoinDate.EditValue.ToString = "", "NULL", "'" + DateTime.Parse(DEJoinDate.EditValue.ToString).ToString("yyyy-MM-dd") + "'")
            Dim employee_last_date As String = If(DELastDay.EditValue.ToString = "", "NULL", "'" + DateTime.Parse(DELastDay.EditValue.ToString).ToString("yyyy-MM-dd") + "'")
            Dim employee_position As String = addSlashes(TxtPosition.Text)
            Dim id_employee_level As String = LELevel.EditValue.ToString
            Dim phone As String = addSlashes(TxtPhone.Text)
            Dim phone_mobile As String = addSlashes(TxtMobilePhone.Text)
            Dim employee_ktp As String = addSlashes(TxtKTP.Text)
            Dim employee_ktp_period As String = If(DEKTP.EditValue.ToString = "", "NULL", "'" + DateTime.Parse(DEKTP.EditValue.ToString).ToString("yyyy-MM-dd") + "'")
            Dim employee_passport As String = addSlashes(TxtPassport.Text)
            Dim employee_passport_period As String = If(DEPassport.EditValue.ToString = "", "NULL", "'" + DateTime.Parse(DEPassport.EditValue.ToString).ToString("yyyy-MM-dd") + "'")
            Dim employee_bpjs_tk As String = addSlashes(TxtBPJSTK.Text)
            Dim employee_bpjs_tk_date As String = If(DERegBPJSTK.EditValue.ToString = "", "NULL", "'" + DateTime.Parse(DERegBPJSTK.EditValue.ToString).ToString("yyyy-MM-dd") + "'")
            Dim is_jp As String = If(CEJP.Checked, "1", "2")
            Dim is_jht As String = If(CEJHT.Checked, "1", "2")
            Dim employee_bpjs_kesehatan As String = addSlashes(TxtBPJSSehat.Text)
            Dim is_bpjs_volcom As String = If(CEBPJS.Checked, "1", "2")
            Dim employee_bpjs_kesehatan_date As String = If(DERegBPJSKes.EditValue.ToString = "", "NULL", "'" + DateTime.Parse(DERegBPJSKes.EditValue.ToString).ToString("yyyy-MM-dd") + "'")
            Dim employee_npwp As String = addSlashes(TxtNpwp.Text)
            Dim employee_no_rek As String = addSlashes(TENoRek.Text)
            Dim employee_rek_name As String = addSlashes(TERekeningName.Text)
            Dim address_primary As String = addSlashes(MEAddress.Text)
            Dim address_additional As String = addSlashes(MEAddressBoarding.Text)
            Dim id_marriage_status As String = LEMarriageStatus.EditValue.ToString
            Dim husband As String = addSlashes(TxtHusband.Text)
            Dim wife As String = addSlashes(TxtWife.Text)
            Dim child1 As String = addSlashes(TxtChild1.Text)
            Dim child2 As String = addSlashes(TxtChild2.Text)
            Dim child3 As String = addSlashes(TxtChild3.Text)
            Dim basic_salary As String = decimalSQL(TxtBasicSalary.EditValue.ToString)
            Dim allow_job As String = decimalSQL(TxtAllowJob.EditValue.ToString)
            Dim allow_meal As String = decimalSQL(TxtAllowMeal.EditValue.ToString)
            Dim allow_trans As String = decimalSQL(TxtAllowTrans.EditValue.ToString)
            Dim allow_house As String = decimalSQL(TxtAllowHouse.EditValue.ToString)
            Dim allow_car As String = decimalSQL(TxtAllowCar.EditValue.ToString)
            Dim note_bpjs_kesehatan As String = ""
            Dim is_koperasi As String = If(CEKoperasi.Checked, "1", "2")
            Dim is_pic As String = If(CEPIC.Checked, "1", "2")

            Dim query As String = "INSERT INTO tb_employee_pps(id_type, number, id_report_status, note, id_employee, id_employee_active, employee_code, employee_name, employee_nick_name, employee_initial_name, id_departement, id_departement_sub, id_sex, id_blood_type, id_religion, id_country, id_education, id_employee_status, start_period, end_period, employee_position_date, employee_pob, employee_dob, employee_ethnic, employee_join_date, employee_last_date, employee_position, id_employee_level, phone, phone_mobile, employee_ktp, employee_ktp_period, employee_passport, employee_passport_period, employee_bpjs_tk, employee_bpjs_tk_date, is_jp, is_jht, employee_bpjs_kesehatan, is_bpjs_volcom, employee_bpjs_kesehatan_date, employee_npwp, employee_no_rek, employee_rek_name, address_primary, address_additional, id_marriage_status, husband, wife, child1, child2, child3, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car, note_bpjs_kesehatan, is_koperasi, is_pic) VALUES('" + id_type + "', '" + number + "', '" + id_report_status + "', '" + note + "', " + id_employee_store + ", '" + id_employee_active + "', '" + employee_code + "', '" + employee_name + "', '" + employee_nick_name + "', '" + employee_initial_name + "', '" + id_departement + "', '" + id_departement_sub + "', '" + id_sex + "', '" + id_blood_type + "', '" + id_religion + "', '" + id_country + "', '" + id_education + "', '" + id_employee_status + "', " + start_period + ", " + end_period + ", " + employee_position_date + ", '" + employee_pob + "', " + employee_dob + ", '" + employee_ethnic + "', " + employee_join_date + ", " + employee_last_date + ", '" + employee_position + "', '" + id_employee_level + "', '" + phone + "', '" + phone_mobile + "', '" + employee_ktp + "', " + employee_ktp_period + ", '" + employee_passport + "', " + employee_passport_period + ", '" + employee_bpjs_tk + "', " + employee_bpjs_tk_date + ", '" + is_jp + "', '" + is_jht + "', '" + employee_bpjs_kesehatan + "', '" + is_bpjs_volcom + "', " + employee_bpjs_kesehatan_date + ", '" + employee_npwp + "', '" + employee_no_rek + "', '" + employee_rek_name + "', '" + address_primary + "', '" + address_additional + "', '" + id_marriage_status + "', '" + husband + "', '" + wife + "', '" + child1 + "', '" + child2 + "', '" + child3 + "', '" + basic_salary + "', '" + allow_job + "', '" + allow_meal + "', '" + allow_trans + "', '" + allow_house + "', '" + allow_car + "', '" + note_bpjs_kesehatan + "', '" + is_koperasi + "', '" + is_pic + "'); SELECT LAST_INSERT_ID();"

            Dim id_pps As String = execute_query(query, 0, True, "", "", "", "")

            'image
            Try
                save_image_ori(PE, pps_path, id_pps & "_ava.jpg")
            Catch ex As Exception
                infoCustom(ex.ToString)
            End Try

            ' store old
            If is_new = "-1" Then
                Dim query_old As String = "
                    INSERT INTO tb_employee_pps_old(id_employee_pps, id_employee, id_employee_active, employee_code, employee_name, employee_nick_name, employee_initial_name, id_departement, id_departement_sub, id_sex, id_blood_type, id_religion, id_country, id_education, id_employee_status, start_period, end_period, employee_position_date, employee_pob, employee_dob, employee_ethnic, employee_join_date, employee_last_date, employee_position, id_employee_level, phone, phone_mobile, employee_ktp, employee_ktp_period, employee_passport, employee_passport_period, employee_bpjs_tk, employee_bpjs_tk_date, is_jp, is_jht, employee_bpjs_kesehatan, is_bpjs_volcom, employee_bpjs_kesehatan_date, employee_npwp, employee_no_rek, employee_rek_name, address_primary, address_additional, id_marriage_status, husband, wife, child1, child2, child3, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car, note_bpjs_kesehatan, is_koperasi, is_pic)
                    SELECT '" + id_pps + "' AS id_employee_pps, emp.id_employee, emp.id_employee_active, emp.employee_code, emp.employee_name, emp.employee_nick_name, emp.employee_initial_name, emp.id_departement, emp.id_departement_sub, emp.id_sex, emp.id_blood_type, emp.id_religion, emp.id_country, emp.id_education, emp.id_employee_status, emp.start_period, emp.end_period, pos.employee_position_date, emp.employee_pob, emp.employee_dob, emp.employee_ethnic, emp.employee_join_date, emp.employee_last_date, emp.employee_position, emp.id_employee_level, emp.phone, emp.phone_mobile, emp.employee_ktp, emp.employee_ktp_period, emp.employee_passport, emp.employee_passport_period, emp.employee_bpjs_tk, emp.employee_bpjs_tk_date, emp.is_jp, emp.is_jht, emp.employee_bpjs_kesehatan, emp.is_bpjs_volcom, emp.employee_bpjs_kesehatan_date, emp.employee_npwp, emp.employee_no_rek, emp.employee_rek_name, emp.address_primary, emp.address_additional, emp.id_marriage_status, emp.husband, emp.wife, emp.child1, emp.child2, emp.child3, sal.basic_salary, sal.allow_job, sal.allow_meal, sal.allow_trans, sal.allow_house, sal.allow_car, '' AS note_bpjs_kesehatan, emp.is_koperasi, emp.is_pic
                    FROM tb_m_employee AS emp 
                    LEFT JOIN (SELECT * FROM tb_m_employee_position WHERE id_employee_position IN (SELECT MAX(id_employee_position) FROM tb_m_employee_position GROUP BY id_employee)) AS pos ON emp.id_employee = pos.id_employee
                    LEFT JOIN (
	                    SELECT * FROM (
                            SELECT id_employee, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car
                            FROM tb_m_employee_salary AS slr
                            WHERE slr.is_cancel = '2' AND slr.effective_date <= NOW()
                            ORDER BY effective_date DESC
	                    ) AS sal
	                    GROUP BY sal.id_employee
                    ) AS sal ON sal.id_employee = emp.id_employee
                    WHERE emp.id_employee = '" + id_employee + "'
                "

                execute_non_query(query_old, True, "", "", "", "")

                'image
                Try
                    save_image_ori(PEB, pps_path, id_pps & "_ava_old.jpg")
                Catch ex As Exception
                    infoCustom(ex.ToString)
                End Try
            End If

            'number
            execute_non_query("CALL gen_number(" + id_pps + ", '180')", True, "", "", "", "")

            'submit
            submit_who_prepared("180", id_pps, id_user)

            FormEmloyeePps.load_pps()

            Close()
        End If
    End Sub

    Sub checkChanges()
        Dim query As String = "
            SELECT id_employee_active, employee_code, employee_name, employee_nick_name, employee_initial_name, id_departement, id_departement_sub, id_sex, id_blood_type, id_religion, id_country, id_education, id_employee_status, start_period, end_period, employee_position_date, employee_pob, employee_dob, employee_ethnic, employee_join_date, employee_last_date, employee_position, id_employee_level, phone, phone_mobile, employee_ktp, employee_ktp_period, employee_passport, employee_passport_period, employee_bpjs_tk, employee_bpjs_tk_date, is_jp, is_jht, employee_bpjs_kesehatan, is_bpjs_volcom, employee_bpjs_kesehatan_date, employee_npwp, employee_no_rek, employee_rek_name, address_primary, address_additional, id_marriage_status, husband, wife, child1, child2, child3, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car, note_bpjs_kesehatan, is_koperasi, is_pic, TIMESTAMPDIFF(YEAR, employee_dob, DATE(NOW())) AS age FROM tb_employee_pps_old WHERE id_employee_pps = '" + id_pps + "'
            UNION
            SELECT id_employee_active, employee_code, employee_name, employee_nick_name, employee_initial_name, id_departement, id_departement_sub, id_sex, id_blood_type, id_religion, id_country, id_education, id_employee_status, start_period, end_period, employee_position_date, employee_pob, employee_dob, employee_ethnic, employee_join_date, employee_last_date, employee_position, id_employee_level, phone, phone_mobile, employee_ktp, employee_ktp_period, employee_passport, employee_passport_period, employee_bpjs_tk, employee_bpjs_tk_date, is_jp, is_jht, employee_bpjs_kesehatan, is_bpjs_volcom, employee_bpjs_kesehatan_date, employee_npwp, employee_no_rek, employee_rek_name, address_primary, address_additional, id_marriage_status, husband, wife, child1, child2, child3, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car, note_bpjs_kesehatan, is_koperasi, is_pic, TIMESTAMPDIFF(YEAR, employee_dob, DATE(NOW())) AS age FROM tb_employee_pps WHERE id_employee_pps = '" + id_pps + "'
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim column As DataTable = New DataTable

        column.Columns.Add("name", GetType(String))

        column.Rows.Add("id_employee_active")
        column.Rows.Add("employee_code")
        column.Rows.Add("employee_name")
        column.Rows.Add("employee_nick_name")
        column.Rows.Add("employee_initial_name")
        column.Rows.Add("id_departement")
        column.Rows.Add("id_departement_sub")
        column.Rows.Add("id_sex")
        column.Rows.Add("id_blood_type")
        column.Rows.Add("id_religion")
        column.Rows.Add("id_country")
        column.Rows.Add("id_education")
        column.Rows.Add("id_employee_status")
        column.Rows.Add("start_period")
        column.Rows.Add("end_period")
        column.Rows.Add("employee_position_date")
        column.Rows.Add("employee_pob")
        column.Rows.Add("employee_dob")
        column.Rows.Add("employee_ethnic")
        column.Rows.Add("employee_join_date")
        column.Rows.Add("employee_last_date")
        column.Rows.Add("employee_position")
        column.Rows.Add("id_employee_level")
        column.Rows.Add("phone")
        column.Rows.Add("phone_mobile")
        column.Rows.Add("employee_ktp")
        column.Rows.Add("employee_ktp_period")
        column.Rows.Add("employee_passport")
        column.Rows.Add("employee_passport_period")
        column.Rows.Add("employee_bpjs_tk")
        column.Rows.Add("employee_bpjs_tk_date")
        column.Rows.Add("is_jp")
        column.Rows.Add("is_jht")
        column.Rows.Add("employee_bpjs_kesehatan")
        column.Rows.Add("is_bpjs_volcom")
        column.Rows.Add("employee_bpjs_kesehatan_date")
        column.Rows.Add("employee_npwp")
        column.Rows.Add("employee_no_rek")
        column.Rows.Add("employee_rek_name")
        column.Rows.Add("address_primary")
        column.Rows.Add("address_additional")
        column.Rows.Add("id_marriage_status")
        column.Rows.Add("husband")
        column.Rows.Add("wife")
        column.Rows.Add("child1")
        column.Rows.Add("child2")
        column.Rows.Add("child3")
        column.Rows.Add("basic_salary")
        column.Rows.Add("allow_job")
        column.Rows.Add("allow_meal")
        column.Rows.Add("allow_trans")
        column.Rows.Add("allow_house")
        column.Rows.Add("allow_car")
        column.Rows.Add("note_bpjs_kesehatan")
        column.Rows.Add("is_koperasi")
        column.Rows.Add("is_pic")

        For i = 0 To column.Rows.Count - 1
            If (column.Rows(i)("name") = "basic_salary" Or column.Rows(i)("name") = "allow_job" Or column.Rows(i)("name") = "allow_meal" Or column.Rows(i)("name") = "allow_trans" Or column.Rows(i)("name") = "allow_house" Or column.Rows(i)("name") = "allow_car") And data.Rows(0)(column.Rows(i)("name")).ToString = "" Then
                data.Rows(0)(column.Rows(i)("name")) = "0,00"
            End If

            If Not data.Rows(0)(column.Rows(i)("name")).ToString = data.Rows(1)(column.Rows(i)("name")).ToString Then
                If column.Rows(i)("name") = "employee_code" Then
                    ChangesProvider1.SetError(TxtCode, "Changed")
                End If

                If column.Rows(i)("name") = "employee_name" Then
                    ChangesProvider1.SetError(TxtFullName, "Changed")
                End If

                If column.Rows(i)("name") = "employee_nick_name" Then
                    ChangesProvider1.SetError(TxtNickName, "Changed")
                End If

                If column.Rows(i)("name") = "employee_initial_name" Then
                    ChangesProvider1.SetError(TxtInitialName, "Changed")
                End If

                If column.Rows(i)("name") = "employee_join_date" Then
                    ChangesProvider1.SetError(DEJoinDate, "Changed")
                End If

                If column.Rows(i)("name") = "id_employee_active" Then
                    ChangesProvider1.SetError(LEActive, "Changed")
                End If

                If column.Rows(i)("name") = "is_pic" Then
                    ChangesProvider1.SetError(CEPIC, "Changed")
                End If

                If column.Rows(i)("name") = "employee_last_date" Then
                    ChangesProvider1.SetError(DELastDay, "Changed")
                End If

                If column.Rows(i)("name") = "id_sex" Then
                    ChangesProvider1.SetError(LESex, "Changed")
                End If

                If column.Rows(i)("name") = "id_blood_type" Then
                    ChangesProvider1.SetError(LEBloodType, "Changed")
                End If

                If column.Rows(i)("name") = "employee_pob" Then
                    ChangesProvider1.SetError(TxtPOB, "Changed")
                End If

                If column.Rows(i)("name") = "employee_dob" Then
                    ChangesProvider1.SetError(DEDOB, "Changed")
                End If

                If column.Rows(i)("name") = "age" Then
                    ChangesProvider1.SetError(TxtAge, "Changed")
                End If

                If column.Rows(i)("name") = "id_religion" Then
                    ChangesProvider1.SetError(LEReligion, "Changed")
                End If

                If column.Rows(i)("name") = "id_country" Then
                    ChangesProvider1.SetError(LECountry, "Changed")
                End If

                If column.Rows(i)("name") = "employee_ethnic" Then
                    ChangesProvider1.SetError(TxtEthnic, "Changed")
                End If

                If column.Rows(i)("name") = "id_education" Then
                    ChangesProvider1.SetError(LEDegree, "Changed")
                End If

                If column.Rows(i)("name") = "employee_ktp" Then
                    ChangesProvider1.SetError(TxtKTP, "Changed")
                End If

                If column.Rows(i)("name") = "employee_ktp_period" Then
                    ChangesProvider1.SetError(DEKTP, "Changed")
                End If

                If column.Rows(i)("name") = "employee_passport" Then
                    ChangesProvider1.SetError(TxtPassport, "Changed")
                End If

                If column.Rows(i)("name") = "employee_passport_period" Then
                    ChangesProvider1.SetError(DEPassport, "Changed")
                End If

                If column.Rows(i)("name") = "employee_npwp" Then
                    ChangesProvider1.SetError(TxtNpwp, "Changed")
                End If

                If column.Rows(i)("name") = "phone" Then
                    ChangesProvider1.SetError(TxtPhone, "Changed")
                End If

                If column.Rows(i)("name") = "phone_mobile" Then
                    ChangesProvider1.SetError(TxtMobilePhone, "Changed")
                End If

                If column.Rows(i)("name") = "address_primary" Then
                    ChangesProvider1.SetError(MEAddress, "Changed")
                End If

                If column.Rows(i)("name") = "address_additional" Then
                    ChangesProvider1.SetError(MEAddressBoarding, "Changed")
                End If

                If column.Rows(i)("name") = "id_marriage_status" Then
                    ChangesProvider1.SetError(LEMarriageStatus, "Changed")
                End If

                If column.Rows(i)("name") = "husband" Then
                    ChangesProvider1.SetError(TxtHusband, "Changed")
                End If

                If column.Rows(i)("name") = "wife" Then
                    ChangesProvider1.SetError(TxtWife, "Changed")
                End If

                If column.Rows(i)("name") = "child1" Then
                    ChangesProvider1.SetError(TxtChild1, "Changed")
                End If

                If column.Rows(i)("name") = "child2" Then
                    ChangesProvider1.SetError(TxtChild2, "Changed")
                End If

                If column.Rows(i)("name") = "child3" Then
                    ChangesProvider1.SetError(TxtChild3, "Changed")
                End If

                If column.Rows(i)("name") = "id_employee_status" Then
                    ChangesProvider1.SetError(LEEmployeeStatus, "Changed")
                End If

                If column.Rows(i)("name") = "start_period" Then
                    ChangesProvider1.SetError(DEEmployeeStatusStart, "Changed")
                End If

                If column.Rows(i)("name") = "end_period" Then
                    ChangesProvider1.SetError(DEEmployeeStatusEnd, "Changed")
                End If

                If column.Rows(i)("name") = "id_departement" Then
                    ChangesProvider1.SetError(LEDepartement, "Changed")
                End If

                If column.Rows(i)("name") = "id_departement_sub" Then
                    ChangesProvider1.SetError(LESubDepartement, "Changed")
                End If

                If column.Rows(i)("name") = "id_employee_level" Then
                    ChangesProvider1.SetError(LELevel, "Changed")
                End If

                If column.Rows(i)("name") = "employee_position" Then
                    ChangesProvider1.SetError(TxtPosition, "Changed")
                End If

                If column.Rows(i)("name") = "employee_position_date" Then
                    ChangesProvider1.SetError(DEEffectiveDate, "Changed")
                End If

                If column.Rows(i)("name") = "employee_no_rek" Then
                    ChangesProvider1.SetError(TENoRek, "Changed")
                End If

                If column.Rows(i)("name") = "employee_rek_name" Then
                    ChangesProvider1.SetError(TERekeningName, "Changed")
                End If

                If column.Rows(i)("name") = "is_koperasi" Then
                    ChangesProvider1.SetError(CEKoperasi, "Changed")
                End If

                If column.Rows(i)("name") = "employee_bpjs_tk" Then
                    ChangesProvider1.SetError(TxtBPJSTK, "Changed")
                End If

                If column.Rows(i)("name") = "is_jp" Then
                    ChangesProvider1.SetError(CEJP, "Changed")
                End If

                If column.Rows(i)("name") = "is_jht" Then
                    ChangesProvider1.SetError(CEJHT, "Changed")
                End If

                If column.Rows(i)("name") = "employee_bpjs_tk_date" Then
                    ChangesProvider1.SetError(DERegBPJSTK, "Changed")
                End If

                If column.Rows(i)("name") = "employee_bpjs_kesehatan" Then
                    ChangesProvider1.SetError(TxtBPJSSehat, "Changed")
                End If

                If column.Rows(i)("name") = "is_bpjs_volcom" Then
                    ChangesProvider1.SetError(CEBPJS, "Changed")
                End If

                If column.Rows(i)("name") = "employee_bpjs_kesehatan_date" Then
                    ChangesProvider1.SetError(DERegBPJSKes, "Changed")
                End If

                If column.Rows(i)("name") = "basic_salary" Then
                    ChangesProvider1.SetError(TxtBasicSalary, "Changed")
                End If

                If column.Rows(i)("name") = "allow_job" Then
                    ChangesProvider1.SetError(TxtAllowJob, "Changed")
                End If

                If column.Rows(i)("name") = "allow_meal" Then
                    ChangesProvider1.SetError(TxtAllowMeal, "Changed")
                End If

                If column.Rows(i)("name") = "allow_trans" Then
                    ChangesProvider1.SetError(TxtAllowTrans, "Changed")
                End If

                If column.Rows(i)("name") = "allow_house" Then
                    ChangesProvider1.SetError(TxtAllowHouse, "Changed")
                End If

                If column.Rows(i)("name") = "allow_car" Then
                    ChangesProvider1.SetError(TxtAllowCar, "Changed")
                End If
            End If
        Next
    End Sub

    Private Sub TxtCode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtCode.Validating
        EP_TE_cant_blank(ErrorProvider1, TxtCode)
    End Sub

    Private Sub TxtPOB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtPOB.Validating
        EP_TE_cant_blank(ErrorProvider1, TxtPOB)
    End Sub

    Private Sub DEDOB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DEDOB.Validating
        EP_DE_cant_blank(ErrorProvider1, DEDOB)
    End Sub

    Private Sub MEAddress_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MEAddress.Validating
        EP_ME_cant_blank(ErrorProvider1, MEAddress)
    End Sub

    Private Sub DEEmployeeStatusStart_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DEEmployeeStatusStart.Validating
        EP_DE_cant_blank(ErrorProvider1, DEEmployeeStatusStart)
    End Sub

    Private Sub DEEffectiveDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DEEffectiveDate.Validating
        EP_DE_cant_blank(ErrorProvider1, DEEffectiveDate)
    End Sub

    Private Sub BtnAddNationality_Click(sender As Object, e As EventArgs) Handles BtnAddNationality.Click
        Cursor = Cursors.WaitCursor

        FormMasterArea.quick_edit = "1"
        FormMasterArea.id_pop_up = "2"

        FormMasterArea.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "180"
        FormReportMark.id_report = id_pps
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SBKtpAtt_Click(sender As Object, e As EventArgs) Handles SBKtpAtt.Click
        FormEmployeePpsAtt.ShowDialog()
    End Sub
End Class