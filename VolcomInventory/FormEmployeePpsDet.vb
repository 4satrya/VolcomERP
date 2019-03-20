Public Class FormEmployeePpsDet
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

    Sub viewSubDepartement(ByVal id_departement As String, ByVal id_departement_sub As String)
        Dim query As String = "SELECT * FROM tb_m_departement_sub"
        Dim index As Integer = 0

        If Not id_departement = "0" And Not id_departement_sub = "0" Then
            query = "SELECT * FROM tb_m_departement_sub WHERE id_departement = '" + id_departement + "'"

            ' check index
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i = 0 To data.Rows.Count - 1
                If data.Rows(i)("id_departement_sub").ToString = id_departement_sub Then
                    index = i
                End If
            Next
        End If

        viewLookupQuery(LESubDepartement, query, index, "departement_sub", "id_departement_sub")
    End Sub

    Sub viewSubDepartementB(ByVal id_departement As String, ByVal id_departement_sub As String)
        Dim query As String = "SELECT * FROM tb_m_departement_sub"
        Dim index As Integer = 0

        If Not id_departement = "0" And Not id_departement_sub = "0" Then
            query = "SELECT * FROM tb_m_departement_sub WHERE id_departement = '" + id_departement + "'"

            ' check index
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i = 0 To data.Rows.Count - 1
                If data.Rows(i)("id_departement_sub").ToString = id_departement_sub Then
                    index = i
                End If
            Next
        End If

        viewLookupQuery(LESubDepartementB, query, index, "departement_sub", "id_departement_sub")

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
        viewSubDepartement("0", "0")
        viewSubDepartementB("0", "0")
        viewLevel()

        ' load propose
        loadPropose()

        ' load before
        If is_new = "-1" Then
            loadBefore()
        End If

        ' load number & note & name & date
        If Not id_pps = "-1" Then
            Dim data_report As DataTable = execute_query("SELECT number, (SELECT employee_name FROM tb_m_employee WHERE id_employee = created_by) AS created_by, DATE_FORMAT(created_date, '%d %M %Y %H:%i:%s') AS created_date, note FROM tb_employee_pps WHERE id_employee_pps = '" + id_pps + "'", -1, True, "", "", "", "")

            TxtNumber.EditValue = data_report.Rows(0)("number").ToString
            TxtProposedBy.EditValue = data_report.Rows(0)("created_by").ToString
            TxtProposedDate.EditValue = data_report.Rows(0)("created_date").ToString
            MENote.EditValue = data_report.Rows(0)("note").ToString
        End If

        ' load image
        pre_viewImages("4", PE, id_employee, False)
        pre_viewImages("4", PEKTP, id_employee + "_ktp", False)
        pre_viewImages("4", PEKK, id_employee + "_kk", False)

        ' position
        For i = 1 To 100
            If System.IO.File.Exists(emp_image_path + id_employee + "_position_" + i.ToString + ".jpg") Then
                Dim PEPosition As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

                PCPosAtt.Controls.Add(PEPosition)

                pre_viewImages("4", PEPosition, id_employee + "_position_" + i.ToString, False)
            Else
                Exit For
            End If
        Next

        If Not PCPosAtt.HasChildren Then
            Dim PEPosition As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

            PCPosAtt.Controls.Add(PEPosition)

            pre_viewImages("4", PEPosition, "default", False)
        End If

        If Not id_pps = "-1" Then
            viewImages(PE, pps_path, id_pps + "_ava", False)
            viewImages(PEKTP, pps_path, id_pps + "_ktp", False)
            viewImages(PEKK, pps_path, id_pps + "_kk", False)

            ' position
            PCPosAtt.Controls.Clear()

            For i = 1 To 100
                If System.IO.File.Exists(pps_path + id_pps + "_position_" + i.ToString + ".jpg") Then
                    Dim PEPosition As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

                    PCPosAtt.Controls.Add(PEPosition)

                    viewImages(PEPosition, pps_path, id_pps + "_position_" + i.ToString, False)
                Else
                    Exit For
                End If
            Next

            If Not PCPosAtt.HasChildren Then
                Dim PEPosition As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

                PCPosAtt.Controls.Add(PEPosition)

                viewImages(PEPosition, pps_path, "default", False)
            End If

            PE.ReadOnly = True
            SBPicWebcam.Enabled = False
        End If

        If is_new = "-1" Then
            pre_viewImages("4", PEB, id_employee, False)
            pre_viewImages("4", PEKTPB, id_employee + "_ktp", False)
            pre_viewImages("4", PEKKB, id_employee + "_kk", False)

            ' position
            For i = 1 To 100
                If System.IO.File.Exists(emp_image_path + id_employee + "_position_" + i.ToString + ".jpg") Then
                    Dim PEPositionB As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

                    PCPosAttB.Controls.Add(PEPositionB)

                    pre_viewImages("4", PEPositionB, id_employee + "_position_" + i.ToString, False)
                Else
                    Exit For
                End If
            Next

            If Not PCPosAttB.HasChildren Then
                Dim PEPositionB As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

                PCPosAttB.Controls.Add(PEPositionB)

                pre_viewImages("4", PEPositionB, "default", False)
            End If

            If Not id_pps = "-1" Then
                viewImages(PEB, pps_path, id_pps + "_ava_old", False)
                viewImages(PEKTPB, pps_path, id_pps + "_ktp_old", False)
                viewImages(PEKKB, pps_path, id_pps + "_kk_old", False)

                ' position
                PCPosAttB.Controls.Clear()

                For i = 1 To 100
                    If System.IO.File.Exists(pps_path + id_pps + "_position_" + i.ToString + "_old.jpg") Then
                        Dim PEPositionB As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

                        PCPosAttB.Controls.Add(PEPositionB)

                        viewImages(PEPositionB, pps_path, id_pps + "_position_" + i.ToString + "_old", False)
                    Else
                        Exit For
                    End If
                Next

                If Not PCPosAttB.HasChildren Then
                    Dim PEPositionB As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

                    PCPosAttB.Controls.Add(PEPositionB)

                    viewImages(PEPositionB, pps_path, "default", False)
                End If
            End If
        End If

        ' check changes
        If Not id_pps = "-1" And is_new = "-1" Then
            viewChanges()
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
        TxtProposedDate.EditValue = execute_query("SELECT DATE_FORMAT(NOW(), '%d %M %Y %H:%i:%s') AS created_date", 0, True, "", "", "", "")
        LEDepartement_EditValueChanged(LEDepartement, New EventArgs())
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
        TxtBasicSalary.EditValue = "0,00"
        TxtAllowJob.EditValue = "0,00"
        TxtAllowMeal.EditValue = "0,00"
        TxtAllowTrans.EditValue = "0,00"
        TxtAllowHouse.EditValue = "0,00"
        TxtAllowCar.EditValue = "0,00"
        TETotal.EditValue = "0,00"

        ' load from db
        Dim query As String = ""

        If is_new = "-1" Then
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
            LESubDepartement.ItemIndex = LESubDepartement.Properties.GetDataSourceRowIndex("id_departement_sub", data.Rows(0)("id_departement_sub").ToString)
            LEDepartement.ItemIndex = LEDepartement.Properties.GetDataSourceRowIndex("id_departement", data.Rows(0)("id_departement").ToString)
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
            TxtBasicSalary.EditValue = If(data.Rows(0)("basic_salary").ToString = "", "0,00", data.Rows(0)("basic_salary").ToString)
            TxtAllowJob.EditValue = If(data.Rows(0)("allow_job").ToString = "", "0,00", data.Rows(0)("allow_job").ToString)
            TxtAllowMeal.EditValue = If(data.Rows(0)("allow_meal").ToString = "", "0,00", data.Rows(0)("allow_meal").ToString)
            TxtAllowTrans.EditValue = If(data.Rows(0)("allow_trans").ToString = "", "0,00", data.Rows(0)("allow_trans").ToString)
            TxtAllowHouse.EditValue = If(data.Rows(0)("allow_house").ToString = "", "0,00", data.Rows(0)("allow_house").ToString)
            TxtAllowCar.EditValue = If(data.Rows(0)("allow_car").ToString = "", "0,00", data.Rows(0)("allow_car").ToString)
            TETotal.EditValue = Decimal.Parse(If(data.Rows(0)("basic_salary").ToString = "", "0", data.Rows(0)("basic_salary").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_job").ToString = "", "0", data.Rows(0)("allow_job").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_meal").ToString = "", "0", data.Rows(0)("allow_meal").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_trans").ToString = "", "0", data.Rows(0)("allow_trans").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_house").ToString = "", "0", data.Rows(0)("allow_house").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_car").ToString = "", "0", data.Rows(0)("allow_car").ToString))
        Else
            If Not id_pps = "-1" Then
                query = "SELECT *, TIMESTAMPDIFF(YEAR, employee_dob, DATE(NOW())) AS age FROM tb_employee_pps WHERE id_employee_pps = '" + id_pps + "'"

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
                LESubDepartement.ItemIndex = LESubDepartement.Properties.GetDataSourceRowIndex("id_departement_sub", data.Rows(0)("id_departement_sub").ToString)
                LEDepartement.ItemIndex = LEDepartement.Properties.GetDataSourceRowIndex("id_departement", data.Rows(0)("id_departement").ToString)
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
                TxtBasicSalary.EditValue = If(data.Rows(0)("basic_salary").ToString = "", "0,00", data.Rows(0)("basic_salary").ToString)
                TxtAllowJob.EditValue = If(data.Rows(0)("allow_job").ToString = "", "0,00", data.Rows(0)("allow_job").ToString)
                TxtAllowMeal.EditValue = If(data.Rows(0)("allow_meal").ToString = "", "0,00", data.Rows(0)("allow_meal").ToString)
                TxtAllowTrans.EditValue = If(data.Rows(0)("allow_trans").ToString = "", "0,00", data.Rows(0)("allow_trans").ToString)
                TxtAllowHouse.EditValue = If(data.Rows(0)("allow_house").ToString = "", "0,00", data.Rows(0)("allow_house").ToString)
                TxtAllowCar.EditValue = If(data.Rows(0)("allow_car").ToString = "", "0,00", data.Rows(0)("allow_car").ToString)
                TETotal.EditValue = Decimal.Parse(If(data.Rows(0)("basic_salary").ToString = "", "0", data.Rows(0)("basic_salary").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_job").ToString = "", "0", data.Rows(0)("allow_job").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_meal").ToString = "", "0", data.Rows(0)("allow_meal").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_trans").ToString = "", "0", data.Rows(0)("allow_trans").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_house").ToString = "", "0", data.Rows(0)("allow_house").ToString)) + Decimal.Parse(If(data.Rows(0)("allow_car").ToString = "", "0", data.Rows(0)("allow_car").ToString))
            End If
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
            LESubDepartementB.ItemIndex = LESubDepartementB.Properties.GetDataSourceRowIndex("id_departement_sub", data.Rows(0)("id_departement_sub").ToString)
            LESubDepartementB.ReadOnly = True
            LEDepartementB.ItemIndex = LEDepartementB.Properties.GetDataSourceRowIndex("id_departement", data.Rows(0)("id_departement").ToString)
            LEDepartementB.ReadOnly = True
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
            TxtBasicSalaryB.EditValue = If(data.Rows(0)("basic_salary").ToString = "", "0,00", data.Rows(0)("basic_salary").ToString)
            TxtAllowJobB.EditValue = If(data.Rows(0)("allow_job").ToString = "", "0,00", data.Rows(0)("allow_job").ToString)
            TxtAllowMealB.EditValue = If(data.Rows(0)("allow_meal").ToString = "", "0,00", data.Rows(0)("allow_meal").ToString)
            TxtAllowTransB.EditValue = If(data.Rows(0)("allow_trans").ToString = "", "0,00", data.Rows(0)("allow_trans").ToString)
            TxtAllowHouseB.EditValue = If(data.Rows(0)("allow_house").ToString = "", "0,00", data.Rows(0)("allow_house").ToString)
            TxtAllowCarB.EditValue = If(data.Rows(0)("allow_car").ToString = "", "0,00", data.Rows(0)("allow_car").ToString)
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

        Dim query_cek As String = ""
        Dim data_cek As String = ""

        If is_new = "1" Then
            ' check in tb_m_employee
            query_cek = "SELECT IFNULL((SELECT COUNT(employee_code) FROM tb_m_employee WHERE employee_code = '" + addSlashes(TxtCode.Text) + "' GROUP BY employee_code), 0)"

            data_cek = execute_query(query_cek, 0, True, "", "", "", "")

            If Not data_cek = "0" Then
                data_cek = "Employee code is already exist !"
            Else
                ' check in tb_employee_propose
                query_cek = "SELECT IFNULL((SELECT COUNT(employee_code) FROM tb_employee_pps WHERE employee_code = '" + addSlashes(TxtCode.Text) + "' AND id_report_status NOT IN (5, 6) GROUP BY employee_code), 0)"

                data_cek = execute_query(query_cek, 0, True, "", "", "", "")

                If Not data_cek = "0" Then
                    data_cek = "Employee code is still in proposed !"
                Else
                    data_cek = ""
                End If
            End If
        End If

        If Not formIsValidInGroup(ErrorProvider1, GCGeneralPropose) Or Not formIsValidInGroup(ErrorProvider1, GCDetailPropose) Or Not formIsValidInGroup(ErrorProvider1, GCContractPropose) Then
            errorInput()
        ElseIf Not data_cek = "" Then
            stopCustom(data_cek)
        Else
            ' store
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit propose " + If(is_new = "-1", "changes", "new") + " employee ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor

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

                Dim query As String = "INSERT INTO tb_employee_pps(id_type, number, created_by, created_date, id_report_status, note, id_employee, id_employee_active, employee_code, employee_name, employee_nick_name, employee_initial_name, id_departement, id_departement_sub, id_sex, id_blood_type, id_religion, id_country, id_education, id_employee_status, start_period, end_period, employee_position_date, employee_pob, employee_dob, employee_ethnic, employee_join_date, employee_last_date, employee_position, id_employee_level, phone, phone_mobile, employee_ktp, employee_ktp_period, employee_passport, employee_passport_period, employee_bpjs_tk, employee_bpjs_tk_date, is_jp, is_jht, employee_bpjs_kesehatan, is_bpjs_volcom, employee_bpjs_kesehatan_date, employee_npwp, employee_no_rek, employee_rek_name, address_primary, address_additional, id_marriage_status, husband, wife, child1, child2, child3, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car, note_bpjs_kesehatan, is_koperasi, is_pic) VALUES('" + id_type + "', '" + number + "', '" + id_employee_user + "', NOW(), '" + id_report_status + "', '" + note + "', " + id_employee_store + ", '" + id_employee_active + "', '" + employee_code + "', '" + employee_name + "', '" + employee_nick_name + "', '" + employee_initial_name + "', '" + id_departement + "', '" + id_departement_sub + "', '" + id_sex + "', '" + id_blood_type + "', '" + id_religion + "', '" + id_country + "', '" + id_education + "', '" + id_employee_status + "', " + start_period + ", " + end_period + ", " + employee_position_date + ", '" + employee_pob + "', " + employee_dob + ", '" + employee_ethnic + "', " + employee_join_date + ", " + employee_last_date + ", '" + employee_position + "', '" + id_employee_level + "', '" + phone + "', '" + phone_mobile + "', '" + employee_ktp + "', " + employee_ktp_period + ", '" + employee_passport + "', " + employee_passport_period + ", '" + employee_bpjs_tk + "', " + employee_bpjs_tk_date + ", '" + is_jp + "', '" + is_jht + "', '" + employee_bpjs_kesehatan + "', '" + is_bpjs_volcom + "', " + employee_bpjs_kesehatan_date + ", '" + employee_npwp + "', '" + employee_no_rek + "', '" + employee_rek_name + "', '" + address_primary + "', '" + address_additional + "', '" + id_marriage_status + "', '" + husband + "', '" + wife + "', '" + child1 + "', '" + child2 + "', '" + child3 + "', '" + basic_salary + "', '" + allow_job + "', '" + allow_meal + "', '" + allow_trans + "', '" + allow_house + "', '" + allow_car + "', '" + note_bpjs_kesehatan + "', '" + is_koperasi + "', '" + is_pic + "'); SELECT LAST_INSERT_ID();"

                Dim id_pps As String = execute_query(query, 0, True, "", "", "", "")

                'image
                If Not PE.EditValue Is Nothing Then
                    save_image_ori(PE, pps_path, id_pps & "_ava.jpg")
                Else
                    System.IO.File.Copy(pps_path + "default.jpg", pps_path + id_pps + "_ava.jpg", True)

                    System.IO.File.SetAttributes(pps_path + id_pps + "_ava.jpg", System.IO.FileAttributes.Normal)
                End If

                ' att
                save_image_ori(PEKTP, pps_path, id_pps & "_ktp.jpg")
                save_image_ori(PEKK, pps_path, id_pps & "_kk.jpg")

                If PCPosAtt.HasChildren Then
                    Dim no As Integer = 1

                    For Each i As Control In PCPosAtt.Controls
                        Dim ic As DevExpress.XtraEditors.PictureEdit = CType(i, DevExpress.XtraEditors.PictureEdit)

                        save_image_ori(ic, pps_path, id_pps & "_position_" + no.ToString + ".jpg")

                        no += 1
                    Next
                End If

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
                    If Not PEB.EditValue Is Nothing Then
                        save_image_ori(PEB, pps_path, id_pps & "_ava_old.jpg")
                    Else
                        System.IO.File.Copy(pps_path + "default.jpg", pps_path + id_pps + "_ava_old.jpg", True)

                        System.IO.File.SetAttributes(pps_path + id_pps + "_ava_old.jpg", System.IO.FileAttributes.Normal)
                    End If

                    ' att
                    save_image_ori(PEKTPB, pps_path, id_pps & "_ktp_old.jpg")
                    save_image_ori(PEKKB, pps_path, id_pps & "_kk_old.jpg")

                    If PCPosAttB.HasChildren Then
                        Dim no As Integer = 1

                        For Each i As Control In PCPosAttB.Controls
                            Dim ic As DevExpress.XtraEditors.PictureEdit = CType(i, DevExpress.XtraEditors.PictureEdit)

                            save_image_ori(ic, pps_path, id_pps & "_position_" + no.ToString + "_old.jpg")

                            no += 1
                        Next
                    End If
                End If

                'number
                execute_non_query("CALL gen_number(" + id_pps + ", '180')", True, "", "", "", "")

                'submit
                submit_who_prepared("180", id_pps, id_user)

                Cursor = Cursors.Default

                FormEmloyeePps.load_pps()

                Close()
            End If
        End If
    End Sub

    Function checkChanges() As DataTable
        Dim changes As New DataTable

        changes.Columns.Add("name", GetType(String))

        Dim query As String = "
            SELECT '1' AS no, id_employee_active, employee_code, employee_name, employee_nick_name, employee_initial_name, id_departement, id_departement_sub, id_sex, id_blood_type, id_religion, id_country, id_education, id_employee_status, start_period, end_period, employee_position_date, employee_pob, employee_dob, employee_ethnic, employee_join_date, employee_last_date, employee_position, id_employee_level, phone, phone_mobile, employee_ktp, employee_ktp_period, employee_passport, employee_passport_period, employee_bpjs_tk, employee_bpjs_tk_date, is_jp, is_jht, employee_bpjs_kesehatan, is_bpjs_volcom, employee_bpjs_kesehatan_date, employee_npwp, employee_no_rek, employee_rek_name, address_primary, address_additional, id_marriage_status, husband, wife, child1, child2, child3, IFNULL(basic_salary, 0.00) AS basic_salary, IFNULL(allow_job, 0.00) AS allow_job, IFNULL(allow_meal, 0.00) AS allow_meal, IFNULL(allow_trans, 0.00) AS allow_trans, IFNULL(allow_house, 0.00) AS allow_house, IFNULL(allow_car, 0.00) AS allow_car, note_bpjs_kesehatan, is_koperasi, is_pic, TIMESTAMPDIFF(YEAR, employee_dob, DATE(NOW())) AS age FROM tb_employee_pps_old WHERE id_employee_pps = '" + id_pps + "'
            UNION
            SELECT '2' AS no, id_employee_active, employee_code, employee_name, employee_nick_name, employee_initial_name, id_departement, id_departement_sub, id_sex, id_blood_type, id_religion, id_country, id_education, id_employee_status, start_period, end_period, employee_position_date, employee_pob, employee_dob, employee_ethnic, employee_join_date, employee_last_date, employee_position, id_employee_level, phone, phone_mobile, employee_ktp, employee_ktp_period, employee_passport, employee_passport_period, employee_bpjs_tk, employee_bpjs_tk_date, is_jp, is_jht, employee_bpjs_kesehatan, is_bpjs_volcom, employee_bpjs_kesehatan_date, employee_npwp, employee_no_rek, employee_rek_name, address_primary, address_additional, id_marriage_status, husband, wife, child1, child2, child3, IFNULL(basic_salary, 0.00) AS basic_salary, IFNULL(allow_job, 0.00) AS allow_job, IFNULL(allow_meal, 0.00) AS allow_meal, IFNULL(allow_trans, 0.00) AS allow_trans, IFNULL(allow_house, 0.00) AS allow_house, IFNULL(allow_car, 0.00) AS allow_car, note_bpjs_kesehatan, is_koperasi, is_pic, TIMESTAMPDIFF(YEAR, employee_dob, DATE(NOW())) AS age FROM tb_employee_pps WHERE id_employee_pps = '" + id_pps + "'
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
            If Not data.Rows(0)(column.Rows(i)("name")).ToString = data.Rows(1)(column.Rows(i)("name")).ToString Then
                changes.Rows.Add(column.Rows(i)("name"))
            End If
        Next

        Return changes
    End Function

    Sub viewChanges()
        Dim changes As DataTable = checkChanges()

        For i = 0 To changes.Rows.Count - 1
            If changes.Rows(i)("name") = "employee_code" Then
                ChangesProvider1.SetError(TxtCode, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_name" Then
                ChangesProvider1.SetError(TxtFullName, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_nick_name" Then
                ChangesProvider1.SetError(TxtNickName, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_initial_name" Then
                ChangesProvider1.SetError(TxtInitialName, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_join_date" Then
                ChangesProvider1.SetError(DEJoinDate, "Changed")
            End If

            If changes.Rows(i)("name") = "id_employee_active" Then
                ChangesProvider1.SetError(LEActive, "Changed")
            End If

            If changes.Rows(i)("name") = "is_pic" Then
                ChangesProvider1.SetError(CEPIC, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_last_date" Then
                ChangesProvider1.SetError(DELastDay, "Changed")
            End If

            If changes.Rows(i)("name") = "id_sex" Then
                ChangesProvider1.SetError(LESex, "Changed")
            End If

            If changes.Rows(i)("name") = "id_blood_type" Then
                ChangesProvider1.SetError(LEBloodType, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_pob" Then
                ChangesProvider1.SetError(TxtPOB, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_dob" Then
                ChangesProvider1.SetError(DEDOB, "Changed")
            End If

            If changes.Rows(i)("name") = "age" Then
                ChangesProvider1.SetError(TxtAge, "Changed")
            End If

            If changes.Rows(i)("name") = "id_religion" Then
                ChangesProvider1.SetError(LEReligion, "Changed")
            End If

            If changes.Rows(i)("name") = "id_country" Then
                ChangesProvider1.SetError(LECountry, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_ethnic" Then
                ChangesProvider1.SetError(TxtEthnic, "Changed")
            End If

            If changes.Rows(i)("name") = "id_education" Then
                ChangesProvider1.SetError(LEDegree, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_ktp" Then
                ChangesProvider1.SetError(TxtKTP, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_ktp_period" Then
                ChangesProvider1.SetError(DEKTP, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_passport" Then
                ChangesProvider1.SetError(TxtPassport, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_passport_period" Then
                ChangesProvider1.SetError(DEPassport, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_npwp" Then
                ChangesProvider1.SetError(TxtNpwp, "Changed")
            End If

            If changes.Rows(i)("name") = "phone" Then
                ChangesProvider1.SetError(TxtPhone, "Changed")
            End If

            If changes.Rows(i)("name") = "phone_mobile" Then
                ChangesProvider1.SetError(TxtMobilePhone, "Changed")
            End If

            If changes.Rows(i)("name") = "address_primary" Then
                ChangesProvider1.SetError(MEAddress, "Changed")
            End If

            If changes.Rows(i)("name") = "address_additional" Then
                ChangesProvider1.SetError(MEAddressBoarding, "Changed")
            End If

            If changes.Rows(i)("name") = "id_marriage_status" Then
                ChangesProvider1.SetError(LEMarriageStatus, "Changed")
            End If

            If changes.Rows(i)("name") = "husband" Then
                ChangesProvider1.SetError(TxtHusband, "Changed")
            End If

            If changes.Rows(i)("name") = "wife" Then
                ChangesProvider1.SetError(TxtWife, "Changed")
            End If

            If changes.Rows(i)("name") = "child1" Then
                ChangesProvider1.SetError(TxtChild1, "Changed")
            End If

            If changes.Rows(i)("name") = "child2" Then
                ChangesProvider1.SetError(TxtChild2, "Changed")
            End If

            If changes.Rows(i)("name") = "child3" Then
                ChangesProvider1.SetError(TxtChild3, "Changed")
            End If

            If changes.Rows(i)("name") = "id_employee_status" Then
                ChangesProvider1.SetError(LEEmployeeStatus, "Changed")
            End If

            If changes.Rows(i)("name") = "start_period" Then
                ChangesProvider1.SetError(DEEmployeeStatusStart, "Changed")
            End If

            If changes.Rows(i)("name") = "end_period" Then
                ChangesProvider1.SetError(DEEmployeeStatusEnd, "Changed")
            End If

            If changes.Rows(i)("name") = "id_departement" Then
                ChangesProvider1.SetError(LEDepartement, "Changed")
            End If

            If changes.Rows(i)("name") = "id_departement_sub" Then
                ChangesProvider1.SetError(LESubDepartement, "Changed")
            End If

            If changes.Rows(i)("name") = "id_employee_level" Then
                ChangesProvider1.SetError(LELevel, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_position" Then
                ChangesProvider1.SetError(TxtPosition, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_position_date" Then
                ChangesProvider1.SetError(DEEffectiveDate, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_no_rek" Then
                ChangesProvider1.SetError(TENoRek, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_rek_name" Then
                ChangesProvider1.SetError(TERekeningName, "Changed")
            End If

            If changes.Rows(i)("name") = "is_koperasi" Then
                ChangesProvider1.SetError(CEKoperasi, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_bpjs_tk" Then
                ChangesProvider1.SetError(TxtBPJSTK, "Changed")
            End If

            If changes.Rows(i)("name") = "is_jp" Then
                ChangesProvider1.SetError(CEJP, "Changed")
            End If

            If changes.Rows(i)("name") = "is_jht" Then
                ChangesProvider1.SetError(CEJHT, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_bpjs_tk_date" Then
                ChangesProvider1.SetError(DERegBPJSTK, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_bpjs_kesehatan" Then
                ChangesProvider1.SetError(TxtBPJSSehat, "Changed")
            End If

            If changes.Rows(i)("name") = "is_bpjs_volcom" Then
                ChangesProvider1.SetError(CEBPJS, "Changed")
            End If

            If changes.Rows(i)("name") = "employee_bpjs_kesehatan_date" Then
                ChangesProvider1.SetError(DERegBPJSKes, "Changed")
            End If

            If changes.Rows(i)("name") = "basic_salary" Then
                ChangesProvider1.SetError(TxtBasicSalary, "Changed")
            End If

            If changes.Rows(i)("name") = "allow_job" Then
                ChangesProvider1.SetError(TxtAllowJob, "Changed")
            End If

            If changes.Rows(i)("name") = "allow_meal" Then
                ChangesProvider1.SetError(TxtAllowMeal, "Changed")
            End If

            If changes.Rows(i)("name") = "allow_trans" Then
                ChangesProvider1.SetError(TxtAllowTrans, "Changed")
            End If

            If changes.Rows(i)("name") = "allow_house" Then
                ChangesProvider1.SetError(TxtAllowHouse, "Changed")
            End If

            If changes.Rows(i)("name") = "allow_car" Then
                ChangesProvider1.SetError(TxtAllowCar, "Changed")
            End If
        Next

        If Not TETotal.EditValue.ToString = TETotalB.EditValue.ToString Then
            ChangesProvider1.SetError(TETotal, "Changed")
        End If
    End Sub

    Sub updateChanges()
        Dim query As String = ""

        ' edited else new
        If is_new = "-1" Then
            Dim changes As DataTable = checkChanges()

            If changes.Rows.Count > 0 Then
                Dim status_changed As Boolean = False
                Dim position_changed As Boolean = False
                Dim salary_changed As Boolean = False

                For i = 0 To changes.Rows.Count - 1
                    ' skip employee_position_date
                    If Not changes.Rows(i)("name") = "employee_position_date" Then
                        query += changes.Rows(i)("name") + " = (SELECT " + changes.Rows(i)("name") + " FROM tb_employee_pps WHERE id_employee_pps = '" + id_pps + "'), "
                    End If

                    If changes.Rows(i)("name") = "id_employee_status" Or changes.Rows(i)("name") = "start_period" Or changes.Rows(i)("name") = "end_period" Then
                        status_changed = True
                    End If

                    If changes.Rows(i)("name") = "id_departement" Or changes.Rows(i)("name") = "id_departement_sub" Or changes.Rows(i)("name") = "id_employee_level" Or changes.Rows(i)("name") = "employee_position" Or changes.Rows(i)("name") = "employee_position_date" Then
                        position_changed = True
                    End If

                    If changes.Rows(i)("name") = "basic_salary" Or changes.Rows(i)("name") = "allow_job" Or changes.Rows(i)("name") = "allow_meal" Or changes.Rows(i)("name") = "allow_trans" Or changes.Rows(i)("name") = "allow_house" Or changes.Rows(i)("name") = "allow_car" Then
                        salary_changed = True
                    End If
                Next

                If Not query = "" Then
                    ' trim last ,
                    query = query.Substring(0, query.Length - 2)

                    query = "UPDATE tb_m_employee SET " + query + " WHERE id_employee = '" + id_employee + "'"

                    execute_non_query(query, True, "", "", "", "")
                End If

                If status_changed Then
                    query = "
                        INSERT INTO tb_m_employee_status_det(id_employee, id_employee_status, start_period, end_period) 
                        SELECT '" + id_employee + "' AS id_employee, id_employee_status, start_period, end_period 
                        FROM tb_employee_pps 
                        WHERE id_employee_pps = '" + id_pps + "'
                    "

                    execute_non_query(query, True, "", "", "", "")
                End If

                If position_changed Then
                    query = "
                        INSERT INTO tb_m_employee_position(id_employee, id_departement_origin, id_departement_sub_origin, id_employee_level_origin, employee_position_origin, id_departement, id_departement_sub, id_employee_level, employee_position, employee_position_date)
                        SELECT '" + id_employee + "' AS id_employee, (SELECT id_departement FROM tb_employee_pps_old WHERE id_employee_pps = '" + id_pps + "') AS id_departement_origin, (SELECT id_departement_sub FROM tb_employee_pps_old WHERE id_employee_pps = '" + id_pps + "') AS id_departement_sub_origin, (SELECT id_employee_level FROM tb_employee_pps_old WHERE id_employee_pps = '" + id_pps + "') AS id_employee_level_origin, (SELECT employee_position FROM tb_employee_pps_old WHERE id_employee_pps = '" + id_pps + "') AS employee_position_origin, id_departement, id_departement_sub, id_employee_level, employee_position, employee_position_date
                        FROM tb_employee_pps 
                        WHERE id_employee_pps = '" + id_pps + "'
                    "

                    execute_non_query(query, True, "", "", "", "")
                End If

                If salary_changed Then
                    query = "
                        INSERT INTO tb_m_employee_salary(id_employee, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car, effective_date, is_cancel)
                        SELECT '" + id_employee + "' AS id_employee, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car, NOW() AS effective_date, '2' AS is_cancel
                        FROM tb_employee_pps 
                        WHERE id_employee_pps = '" + id_pps + "'
                    "

                    execute_non_query(query, True, "", "", "", "")
                End If
            End If
        Else
            query = "
                INSERT INTO tb_m_employee(id_sex, id_departement, id_departement_sub, id_blood_type, id_religion, id_country, id_education, id_employee_status, start_period, end_period, id_employee_active, employee_code, employee_name, employee_nick_name, employee_initial_name, employee_pob, employee_dob, employee_ethnic, employee_join_date, employee_last_date, employee_position, id_employee_level, phone, phone_mobile, employee_ktp, employee_ktp_period, employee_passport, employee_passport_period, employee_bpjs_tk, employee_bpjs_tk_date, is_jp, is_jht, employee_bpjs_kesehatan, is_bpjs_volcom, employee_bpjs_kesehatan_date, employee_npwp, employee_no_rek, employee_rek_name, address_primary, address_additional, id_marriage_status, husband, wife, child1, child2, child3, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car, is_active, note_bpjs_kesehatan, is_koperasi, is_pic)
                SELECT id_sex, id_departement, id_departement_sub, id_blood_type, id_religion, id_country, id_education, id_employee_status, start_period, end_period, id_employee_active, employee_code, employee_name, employee_nick_name, employee_initial_name, employee_pob, employee_dob, employee_ethnic, employee_join_date, employee_last_date, employee_position, id_employee_level, phone, phone_mobile, employee_ktp, employee_ktp_period, employee_passport, employee_passport_period, employee_bpjs_tk, employee_bpjs_tk_date, is_jp, is_jht, employee_bpjs_kesehatan, is_bpjs_volcom, employee_bpjs_kesehatan_date, employee_npwp, employee_no_rek, employee_rek_name, address_primary, address_additional, id_marriage_status, husband, wife, child1, child2, child3, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car, '1' AS is_active, note_bpjs_kesehatan, is_koperasi, is_pic
                FROM tb_employee_pps 
                WHERE id_employee_pps = '" + id_pps + "';
                SELECT LAST_INSERT_ID();
            "

            id_employee = execute_query(query, 0, True, "", "", "", "")

            ' status
            query = "
                INSERT INTO tb_m_employee_status_det(id_employee, id_employee_status, start_period, end_period) 
                SELECT '" + id_employee + "' AS id_employee, id_employee_status, start_period, end_period 
                FROM tb_employee_pps 
                WHERE id_employee_pps = '" + id_pps + "'
            "

            execute_non_query(query, True, "", "", "", "")

            ' position
            query = "
                INSERT INTO tb_m_employee_position(id_employee, id_departement_origin, id_departement_sub_origin, id_employee_level_origin, employee_position_origin, id_departement, id_departement_sub, id_employee_level, employee_position, employee_position_date)
                SELECT '" + id_employee + "' AS id_employee, NULL AS id_departement_origin, NULL AS id_departement_sub_origin, NULL AS id_employee_level_origin, NULL AS employee_position_origin, id_departement, id_departement_sub, id_employee_level, employee_position, employee_position_date
                FROM tb_employee_pps 
                WHERE id_employee_pps = '" + id_pps + "'
            "

            execute_non_query(query, True, "", "", "", "")

            ' salary
            query = "
                INSERT INTO tb_m_employee_salary(id_employee, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car, effective_date, is_cancel)
                SELECT '" + id_employee + "' AS id_employee, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car, NOW() AS effective_date, '2' AS is_cancel
                FROM tb_employee_pps 
                WHERE id_employee_pps = '" + id_pps + "'
            "

            execute_non_query(query, True, "", "", "", "")
        End If

        ' image
        If System.IO.File.Exists(pps_path + id_pps + "_ava.jpg") Then
            System.IO.File.Copy(pps_path + id_pps + "_ava.jpg", emp_image_path + id_employee + ".jpg", True)
        End If

        ' att
        If System.IO.File.Exists(pps_path + id_pps + "_ktp.jpg") Then
            System.IO.File.Copy(pps_path + id_pps + "_ktp.jpg", emp_image_path + id_employee + "_ktp.jpg", True)
        End If

        If System.IO.File.Exists(pps_path + id_pps + "_kk.jpg") Then
            System.IO.File.Copy(pps_path + id_pps + "_kk.jpg", emp_image_path + id_employee + "_kk.jpg", True)
        End If

        For i = 1 To 100
            If System.IO.File.Exists(emp_image_path + id_employee + "_position_" + i.ToString + ".jpg") Then
                System.IO.File.Delete(emp_image_path + id_employee + "_position_" + i.ToString + ".jpg")
            Else
                Exit For
            End If
        Next

        For i = 1 To 100
            If System.IO.File.Exists(pps_path + id_pps + "_position_" + i.ToString + ".jpg") Then
                System.IO.File.Copy(pps_path + id_pps + "_position_" + i.ToString + ".jpg", emp_image_path + id_employee + "_position_" + i.ToString + ".jpg", True)
            Else
                Exit For
            End If
        Next
    End Sub

    Sub updateSalary()
        TETotal.EditValue = Convert.ToDecimal(TxtBasicSalary.EditValue) + Convert.ToDecimal(TxtAllowJob.EditValue) + Convert.ToDecimal(TxtAllowMeal.EditValue) + Convert.ToDecimal(TxtAllowTrans.EditValue) + Convert.ToDecimal(TxtAllowHouse.EditValue) + Convert.ToDecimal(TxtAllowCar.EditValue)
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
        Dim images As DataTable = New DataTable

        images.Columns.Add("image", GetType(Byte()))

        Dim con As ImageConverter = New ImageConverter

        images.Rows.Add(con.ConvertTo(PEKTP.EditValue, GetType(Byte())))

        FormEmployeePpsAtt.type = "ktp"
        FormEmployeePpsAtt.images = images
        FormEmployeePpsAtt.read_only = If(id_pps = "-1", False, True)
        FormEmployeePpsAtt.is_single = True

        FormEmployeePpsAtt.ShowDialog()
    End Sub

    Private Sub SBKtpAttB_Click(sender As Object, e As EventArgs) Handles SBKtpAttB.Click
        Dim images As DataTable = New DataTable

        images.Columns.Add("image", GetType(Byte()))

        Dim con As ImageConverter = New ImageConverter

        images.Rows.Add(con.ConvertTo(PEKTPB.EditValue, GetType(Byte())))

        FormEmployeePpsAtt.type = "ktp"
        FormEmployeePpsAtt.images = images
        FormEmployeePpsAtt.read_only = True
        FormEmployeePpsAtt.is_single = True

        FormEmployeePpsAtt.ShowDialog()
    End Sub

    Private Sub SBKkAtt_Click(sender As Object, e As EventArgs) Handles SBKkAtt.Click
        Dim images As DataTable = New DataTable

        images.Columns.Add("image", GetType(Byte()))

        Dim con As ImageConverter = New ImageConverter

        images.Rows.Add(con.ConvertTo(PEKK.EditValue, GetType(Byte())))

        FormEmployeePpsAtt.type = "kk"
        FormEmployeePpsAtt.images = images
        FormEmployeePpsAtt.read_only = If(id_pps = "-1", False, True)
        FormEmployeePpsAtt.is_single = True

        FormEmployeePpsAtt.ShowDialog()
    End Sub

    Private Sub SBKkAttB_Click(sender As Object, e As EventArgs) Handles SBKkAttB.Click
        Dim images As DataTable = New DataTable

        images.Columns.Add("image", GetType(Byte()))

        Dim con As ImageConverter = New ImageConverter

        images.Rows.Add(con.ConvertTo(PEKKB.EditValue, GetType(Byte())))

        FormEmployeePpsAtt.type = "kk"
        FormEmployeePpsAtt.images = images
        FormEmployeePpsAtt.read_only = True
        FormEmployeePpsAtt.is_single = True

        FormEmployeePpsAtt.ShowDialog()
    End Sub

    Private Sub SBPosAtt_Click(sender As Object, e As EventArgs) Handles SBPosAtt.Click
        Dim images As DataTable = New DataTable

        images.Columns.Add("image", GetType(Byte()))

        For Each i As Control In PCPosAtt.Controls
            Dim ic As DevExpress.XtraEditors.PictureEdit = CType(i, DevExpress.XtraEditors.PictureEdit)

            Dim con As ImageConverter = New ImageConverter

            images.Rows.Add(con.ConvertTo(ic.EditValue, GetType(Byte())))
        Next

        FormEmployeePpsAtt.type = "position"
        FormEmployeePpsAtt.images = images
        FormEmployeePpsAtt.read_only = If(id_pps = "-1", False, True)
        FormEmployeePpsAtt.is_single = False

        FormEmployeePpsAtt.ShowDialog()
    End Sub

    Private Sub SBPosAttB_Click(sender As Object, e As EventArgs) Handles SBPosAttB.Click
        Dim images As DataTable = New DataTable

        images.Columns.Add("image", GetType(Byte()))

        For Each i As Control In PCPosAttB.Controls
            Dim ic As DevExpress.XtraEditors.PictureEdit = CType(i, DevExpress.XtraEditors.PictureEdit)

            Dim con As ImageConverter = New ImageConverter

            images.Rows.Add(con.ConvertTo(ic.EditValue, GetType(Byte())))
        Next

        FormEmployeePpsAtt.type = "position"
        FormEmployeePpsAtt.images = images
        FormEmployeePpsAtt.read_only = True
        FormEmployeePpsAtt.is_single = False

        FormEmployeePpsAtt.ShowDialog()
    End Sub

    Private Sub TxtBasicSalary_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtBasicSalary.KeyUp
        updateSalary()
    End Sub

    Private Sub TxtAllowJob_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtAllowJob.KeyUp
        updateSalary()
    End Sub

    Private Sub TxtAllowMeal_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtAllowMeal.KeyUp
        updateSalary()
    End Sub

    Private Sub TxtAllowTrans_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtAllowTrans.KeyUp
        updateSalary()
    End Sub

    Private Sub TxtAllowHouse_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtAllowHouse.KeyUp
        updateSalary()
    End Sub

    Private Sub TxtAllowCar_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtAllowCar.KeyUp
        updateSalary()
    End Sub

    Private Sub LEActive_EditValueChanged(sender As Object, e As EventArgs) Handles LEActive.EditValueChanged
        If LEActive.EditValue.ToString > 1 Then
            DELastDay.Enabled = True
        Else
            DELastDay.EditValue = Nothing
            DELastDay.Enabled = False
        End If
    End Sub

    Private Sub LEDepartement_EditValueChanged(sender As Object, e As EventArgs) Handles LEDepartement.EditValueChanged
        If Not LEDepartement.EditValue Is Nothing And Not LESubDepartement.EditValue Is Nothing Then
            viewSubDepartement(LEDepartement.EditValue, LESubDepartement.EditValue)
        End If
    End Sub

    Private Sub LEDepartementB_EditValueChanged(sender As Object, e As EventArgs) Handles LEDepartementB.EditValueChanged
        If Not LEDepartementB.EditValue Is Nothing And Not LESubDepartementB.EditValue Is Nothing Then
            viewSubDepartementB(LEDepartementB.EditValue, LESubDepartementB.EditValue)
        End If
    End Sub

    Private Sub SBPicWebcam_Click(sender As Object, e As EventArgs) Handles SBPicWebcam.Click

    End Sub
End Class