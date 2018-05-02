Public Class FormMasterAssetLog
    Public id_asset_log As String = "-1"
    Public id_asset As String = "-1"
    '
    Public departement As String = ""

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormMasterAssetLog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterAssetLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_cat()
        load_dept_old()
        load_user_old()
        load_dept_new()
        load_user_new()
        '
        DEMovingDate.EditValue = Now
        '
        DECreatedBy.EditValue = Now
        '
        Dim query As String = "SELECT ass.id_asset,pod.vendor_sku AS vendor_code,ass.asset_code,ass.asset_code_old,pod.id_asset_cat,ass.asset_desc
                                ,IF(ISNULL(cur_user.id_asset),emp.employee_name,cur_user.employee_name) AS employee_name
                                ,IF(ISNULL(cur_user.id_asset),emp.id_employee,cur_user.id_employee) AS id_employee
                                ,IF(ISNULL(cur_user.id_asset),dep.departement,cur_user.departement) AS departement
                                ,IF(ISNULL(cur_user.id_asset),dep.id_departement,cur_user.id_departement) AS id_departement
                                ,ass.asset_location
                                FROM tb_a_asset ass
                                INNER JOIN tb_a_asset_rec_det recd ON recd.id_asset_rec_det=ass.id_asset_rec_det
                                INNER JOIN tb_a_asset_rec rec ON rec.id_asset_rec=recd.id_asset_rec
                                INNER JOIN tb_a_asset_po_det pod ON pod.id_asset_po_det=recd.`id_asset_po_det`
                                INNER JOIN tb_a_asset_po po ON po.id_asset_po=pod.id_asset_po 
                                LEFT JOIN
                                (
                                    SELECT a.id_asset,emp.`employee_name`,emp.`id_employee`,dep.`departement`,dep.`id_departement` FROM
                                    (
	                                    SELECT * FROM tb_a_asset_log WHERE id_asset='" & id_asset & "' ORDER BY `date` DESC 
                                    )a 
                                    LEFT JOIN tb_m_employee emp ON emp.`id_employee`=a.id_employee
                                    INNER JOIN tb_m_departement dep ON dep.`id_departement`=a.id_departement
                                    GROUP BY a.id_asset
                                )cur_user ON cur_user.id_asset=ass.id_asset
                                LEFT JOIN tb_m_employee emp ON emp.`id_employee`=ass.id_employee
                                INNER JOIN tb_m_user usr ON usr.id_user=ass.id_user_created
                                INNER JOIN tb_m_departement dep ON dep.`id_departement`=pod.id_departement
                                WHERE ass.id_asset='" & id_asset & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TECode.Text = data.Rows(0)("asset_code").ToString
        TEOldCode.Text = data.Rows(0)("asset_code_old").ToString
        TEOldLocation.Text = data.Rows(0)("asset_location").ToString
        TEDesc.Text = data.Rows(0)("asset_desc").ToString

        LEAssetCat.ItemIndex = LEAssetCat.Properties.GetDataSourceRowIndex("id_asset_cat", data.Rows(0)("id_asset_cat").ToString)

        If id_asset_log = "-1" Then 'new
            TECreatedBy.Text = name_user

            LECurDep.ItemIndex = LECurDep.Properties.GetDataSourceRowIndex("id_departement", data.Rows(0)("id_departement").ToString)

            If Not data.Rows(0)("id_employee").ToString = "" Then
                LECurUser.ItemIndex = LECurUser.Properties.GetDataSourceRowIndex("id_employee", data.Rows(0)("id_employee").ToString)
            End If
            BSave.Visible = True
            BPrint.Visible = False
        Else 'edit
            '
            Dim query_view As String = "SELECT a.*,LPAD(a.id_asset_log,5,'0') AS move_no,emp.employee_name,dep.departement
                                        FROM tb_a_asset_log a 
                                        INNER JOIN tb_m_user usr ON usr.id_user=a.id_user_created
                                        INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
                                        INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                        WHERE a.id_asset_log='" & id_asset_log & "'"
            Dim data_view As DataTable = execute_query(query_view, -1, True, "", "", "", "")
            '
            LECurDep.ItemIndex = LECurDep.Properties.GetDataSourceRowIndex("id_departement", data_view.Rows(0)("id_departement_old").ToString)
            LENewDep.ItemIndex = LENewDep.Properties.GetDataSourceRowIndex("id_departement", data_view.Rows(0)("id_departement").ToString)

            If Not data_view.Rows(0)("id_employee_old").ToString = "" Then
                LECurUser.ItemIndex = LECurUser.Properties.GetDataSourceRowIndex("id_employee", data_view.Rows(0)("id_employee_old").ToString)
            End If

            If Not data_view.Rows(0)("id_employee").ToString = "" Then
                LENewUser.ItemIndex = LENewUser.Properties.GetDataSourceRowIndex("id_employee", data_view.Rows(0)("id_employee").ToString)
            End If
            '
            MENote.Text = data_view.Rows(0)("note").ToString
            DEMovingDate.EditValue = data_view.Rows(0)("date")
            DECreatedBy.EditValue = data_view.Rows(0)("date_created")
            '
            TEMoveNo.Text = "IAMA" & data_view.Rows(0)("move_no").ToString
            departement = data_view(0)("departement").ToString
            TECreatedBy.Text = data_view(0)("employee_name").ToString
            TEOldLocation.Text = data_view(0)("location_old").ToString
            TENewLocation.Text = data_view(0)("location").ToString
            '
            BSave.Visible = False
            BPrint.Visible = True
        End If
    End Sub
    Sub load_cat()
        Dim query As String = "SELECT id_asset_cat,asset_cat_code,asset_cat FROM tb_a_asset_cat"
        viewLookupQuery(LEAssetCat, query, 0, "asset_cat", "id_asset_cat")
    End Sub

    Sub load_dept_old()
        Dim query As String = "SELECT id_departement,departement_code,departement FROM tb_m_departement"
        viewLookupQuery(LECurDep, query, 0, "departement", "id_departement")
    End Sub

    Sub load_user_old()
        Dim query As String = "SELECT '' AS id_employee,'-' AS employee_code,'-' AS employee_name FROM tb_m_employee
                                UNION 
                               SELECT id_employee,employee_code,employee_name FROM tb_m_employee"
        viewLookupQuery(LECurUser, query, 0, "employee_name", "id_employee")
    End Sub

    Sub load_dept_new()
        Dim query As String = "SELECT id_departement,departement_code,departement FROM tb_m_departement"
        viewLookupQuery(LENewDep, query, 0, "departement", "id_departement")
    End Sub

    Sub load_user_new()
        Dim query As String = "SELECT '' AS id_employee,'-' AS employee_code,'-' AS employee_name FROM tb_m_employee
                                UNION 
                               SELECT id_employee,employee_code,employee_name FROM tb_m_employee"
        viewLookupQuery(LENewUser, query, 0, "employee_name", "id_employee")
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim id_emp_old As String = "NULL"
        If LECurUser.Text = "" Then
            id_emp_old = "NULL"
        Else
            id_emp_old = "'" & LECurUser.EditValue.ToString & "'"
        End If
        Dim id_emp_new As String = "NULL"
        '
        If LENewUser.Text = "" Then
            id_emp_new = "NULL"
        Else
            id_emp_new = "'" & LENewUser.EditValue.ToString & "'"
        End If

        Dim query As String = "INSERT INTO tb_a_asset_log(id_asset,id_departement_old,id_employee_old,id_departement,id_employee,location_old,location,note,date,id_user_created,date_created)
                                VALUES('" & id_asset & "','" & LECurDep.EditValue.ToString & "'," & id_emp_old & ",'" & LENewDep.EditValue.ToString & "'," & id_emp_new & ",'" & addSlashes(TEOldLocation.Text) & "','" & addSlashes(TENewLocation.Text) & "','" & addSlashes(MENote.Text) & "','" & Date.Parse(DEMovingDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & id_user & "',NOW()); SELECT LAST_INSERT_ID(); "
        id_asset_log = execute_query(query, 0, True, "", "", "", "")

        FormMasterAsset.load_moving_log()
        FormMasterAsset.GVAssetMovingLog.FocusedRowHandle = find_row(FormMasterAsset.GVAssetMovingLog, "id_asset_log", id_asset_log)
        Close()
    End Sub

    Private Sub BNothingUser_Click(sender As Object, e As EventArgs) Handles BNothingUser.Click
        LENewUser.ItemIndex = 0
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Dim Report As New ReportMasterAssetLog()
        '
        Report.LabelNumber.Text = TEMoveNo.Text
        Report.LDate.Text = Date.Parse(DEMovingDate.EditValue.ToString).ToString("dd MMM yyyy")
        '
        Report.CAssetCode.Text = TECode.Text
        Report.CAssetDesc.Text = TEDesc.Text
        Report.CAssetCat.Text = LEAssetCat.Text
        '
        Report.CNewDep.Text = LENewDep.Text
        Report.CNewUser.Text = LENewUser.Text
        Report.CSignNew.Text = If(LENewUser.Text = "", LENewDep.Text, LENewUser.Text)
        '
        Report.COldDept.Text = LECurDep.Text
        Report.COldUser.Text = LECurUser.Text
        Report.CSignOld.Text = If(LECurUser.Text = "", LECurDep.Text, LECurUser.Text)
        '
        If TECreatedBy.Text = "" Then
            Report.CSignIA.Text = name_user
            Report.CSignDept.Text = get_departement_x(id_departement_user, "1")
        Else
            Report.CSignIA.Text = TECreatedBy.Text
            Report.CSignDept.Text = departement
        End If

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
End Class