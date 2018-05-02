Public Class FormMasterEmployee
    Public contract_rvw_date As String = "-1"
    Public is_salary As String = "-1"

    Private Sub FormMasterEmployee_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormMasterEmployee_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewEmployee(ByVal cond_param As String)
        Dim query As String = "CALL view_employee('" + cond_param + "', '2')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmployee.DataSource = data
        '
        If Not is_salary = "1" Then
            GVEmployee.Columns("basic_salary").Visible = False
            GVEmployee.Columns("basic_salary").OptionsColumn.ShowInCustomizationForm = False
            '
            GVEmployee.Columns("allow_job").Visible = False
            GVEmployee.Columns("allow_job").OptionsColumn.ShowInCustomizationForm = False
            '
            GVEmployee.Columns("allow_meal").Visible = False
            GVEmployee.Columns("allow_meal").OptionsColumn.ShowInCustomizationForm = False
            '
            GVEmployee.Columns("allow_trans").Visible = False
            GVEmployee.Columns("allow_trans").OptionsColumn.ShowInCustomizationForm = False
            '
            GVEmployee.Columns("allow_car").Visible = False
            GVEmployee.Columns("allow_car").OptionsColumn.ShowInCustomizationForm = False
            '
            GVEmployee.Columns("allow_house").Visible = False
            GVEmployee.Columns("allow_house").OptionsColumn.ShowInCustomizationForm = False

            gridBandSalary.Visible = False
        End If
    End Sub

    Sub viewEmployeeAge(ByVal cond_param As String, ByVal date_param As String)
        Dim query As String = "CALL view_employee_age('" + cond_param + "', '2', '" + date_param + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmployee.DataSource = data
    End Sub

    Private Sub FormMasterEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewEmployee("-1")
    End Sub

    Private Sub CheckImg_CheckedChanged(sender As Object, e As EventArgs) Handles CheckImg.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim val As String = CheckImg.EditValue.ToString
        If val = "True" Then
            GVEmployee.RowHeight = 100
            GVEmployee.Columns("img").Visible = True
        Else
            GVEmployee.RowHeight = 10
            GVEmployee.Columns("img").Visible = False
        End If
        GCEmployee.RefreshDataSource()
        GVEmployee.RefreshData()
        Cursor = Cursors.Default
    End Sub

    Private ImageDir As String = emp_image_path
    Private Images As Hashtable = New Hashtable()
    Private Sub GVEmployee_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVEmployee.CustomUnboundColumnData
        If e.Column.FieldName = "img" AndAlso e.IsGetData And CheckImg.EditValue.ToString = "True" Then
            Images = Nothing
            Images = New Hashtable()
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim id As String = CStr(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "id_employee"))

            Dim fileName As String = id & ".jpg".ToLower

            If (Not Images.ContainsKey(fileName)) Then
                Dim img As Image = Nothing
                Dim resizeImg As Image = Nothing

                Try

                    Dim filePath As String = DevExpress.Utils.FilesHelper.FindingFileName(ImageDir, fileName, False)
                    img = Image.FromFile(filePath)
                    resizeImg = img.GetThumbnailImage(100, 100, Nothing, Nothing)
                Catch

                End Try

                Images.Add(fileName, resizeImg)

            End If

            e.Value = Images(fileName)
        End If
    End Sub

    Private Sub GVEmployee_DoubleClick(sender As Object, e As EventArgs) Handles GVEmployee.DoubleClick
        If GVEmployee.RowCount > 0 And GVEmployee.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Sub freeze(ByVal check As Boolean)
        If check Then
            GridColumnPic.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            GridColumn2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            GridColumn1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Else
            GridColumnPic.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            GridColumn1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            GridColumn2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            If CheckImg.EditValue = True Then
                GridColumnPic.VisibleIndex = 0
            End If
            GridColumn2.VisibleIndex = 1
            GridColumn1.VisibleIndex = 2
        End If
    End Sub

    Private Sub CheckEditFreeze_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditFreeze.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim val As String = CheckEditFreeze.EditValue.ToString
        If val = "True" Then
            freeze(True)
        Else
            freeze(False)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BAccept_Click(sender As Object, e As EventArgs) Handles BAccept.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to sync all machine?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim fp As New ClassFingerPrint()
            fp.sync_all()
        End If
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        FormMasterEmployeeCustom.ShowDialog()
    End Sub

    Private Sub BClone_Click(sender As Object, e As EventArgs) Handles BClone.Click
        SplashScreenManager1.ShowWaitForm()
        Dim host As String = FormOutlet.GVOutlet.GetFocusedRowCellValue("host").ToString
        Dim username As String = FormOutlet.GVOutlet.GetFocusedRowCellValue("username").ToString
        Dim pass As String = FormOutlet.GVOutlet.GetFocusedRowCellValue("pass").ToString
        Dim db As String = FormOutlet.GVOutlet.GetFocusedRowCellValue("db").ToString

        Try
            'emp
            Dim id_employee As String = GVEmployee.GetFocusedRowCellValue("id_employee").ToString
            Dim dtemp As DataTable = execute_query("SELECT * FROM tb_m_employee WHERE id_employee=" + id_employee + "", -1, True, "", "", "", "")
            Dim qinsemp As String = "INSERT INTO tb_m_employee(id_employee, id_sex, id_departement, id_blood_type, id_religion, id_country, id_education, id_employee_status, start_period, end_period, id_employee_active, employee_code, employee_name, employee_nick_name, employee_initial_name, employee_pob, employee_dob, employee_ethnic, employee_join_date, employee_last_date, employee_position, id_employee_level, email_lokal, email_lokal_pass, email_external, email_external_pass, email_other, email_other_pass, phone, phone_mobile, phone_ext, employee_ktp, employee_ktp_period, employee_passport, employee_passport_period, employee_bpjs_tk, employee_bpjs_tk_date, employee_bpjs_kesehatan, employee_bpjs_kesehatan_date, employee_npwp, address_primary, address_additional, id_marriage_status, husband, wife, child1, child2, child3, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car) "
            qinsemp += "SELECT " + checkNullInput(addSlashes(dtemp.Rows(0)("id_employee").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("id_sex").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("id_departement").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("id_blood_type").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("id_religion").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("id_country").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("id_education").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("id_employee_status").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("start_period").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("end_period").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("id_employee_active").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_code").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_name").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_nick_name").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_initial_name").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_pob").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_dob").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_ethnic").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_join_date").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_last_date").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_position").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("id_employee_level").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("email_lokal").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("email_lokal_pass").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("email_external").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("email_external_pass").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("email_other").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("email_other_pass").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("phone").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("phone_mobile").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("phone_ext").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_ktp").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_ktp_period").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_passport").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_passport_period").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_bpjs_tk").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_bpjs_tk_date").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_bpjs_kesehatan").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_bpjs_kesehatan_date").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("employee_npwp").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("address_primary").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("address_additional").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("id_marriage_status").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("husband").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("wife").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("child1").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("child2").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("child3").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("basic_salary").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("allow_job").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("allow_meal").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("allow_trans").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("allow_house").ToString)) + ", " + checkNullInput(addSlashes(dtemp.Rows(0)("allow_car").ToString)) + ""
            execute_non_query(qinsemp, False, host, username, pass, db)
            SplashScreenManager1.CloseWaitForm()
            infoCustom("Clone data success")
            Close()
        Catch ex As Exception
            SplashScreenManager1.CloseWaitForm()
            stopCustom(ex.ToString)
            Close()
        End Try
    End Sub

    Private Sub FormMasterEmployee_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BImportSalary_Click(sender As Object, e As EventArgs) Handles BImportSalary.Click
        FormImportExcel.id_pop_up = "34"
        FormImportExcel.ShowDialog()
    End Sub
End Class