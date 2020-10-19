Public Class FormLetterOfStatementEmployee
    Private Sub FormLetterOfStatementEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            SELECT e.id_employee, e.id_departement, d.departement, e.employee_code, e.employee_name, e.address_primary, e.start_period, e.end_period, e.employee_position, e.id_employee_status, st.employee_status, e.id_employee_active, la.employee_active, ROUND(e.basic_salary) AS basic_salary, ROUND(e.allow_job) AS allow_job, ROUND(e.allow_meal) AS allow_meal, ROUND(e.allow_trans) AS allow_trans, ROUND(e.allow_house) AS allow_house, ROUND(e.allow_car) AS allow_car
            FROM tb_m_employee AS e
            LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement 
            LEFT JOIN tb_lookup_employee_status AS st ON e.id_employee_status = st.id_employee_status
            LEFT JOIN tb_lookup_employee_active AS la ON e.id_employee_active = la.id_employee_active
            ORDER BY d.departement ASC, e.id_employee_level ASC, e.employee_code ASC
        "

        GCList.DataSource = execute_query(query, -1, True, "", "", "", "")

        GVList.BestFitColumns()
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        FormLetterOfStatementDet.TEEmployee.EditValue = GVList.GetFocusedRowCellValue("employee_name").ToString
        FormLetterOfStatementDet.TEPosition.EditValue = GVList.GetFocusedRowCellValue("employee_position").ToString
        FormLetterOfStatementDet.SLUEDepartement.EditValue = GVList.GetFocusedRowCellValue("id_departement").ToString
        FormLetterOfStatementDet.TEAddress.EditValue = GVList.GetFocusedRowCellValue("address_primary").ToString
        FormLetterOfStatementDet.DEStartDate.EditValue = GVList.GetFocusedRowCellValue("start_period").ToString
        FormLetterOfStatementDet.DEEndDate.EditValue = GVList.GetFocusedRowCellValue("end_period").ToString
        FormLetterOfStatementDet.TEBasicSalary.EditValue = GVList.GetFocusedRowCellValue("basic_salary")
        FormLetterOfStatementDet.TEAllowJob.EditValue = GVList.GetFocusedRowCellValue("allow_job")
        FormLetterOfStatementDet.TEAllowMeal.EditValue = GVList.GetFocusedRowCellValue("allow_meal")
        FormLetterOfStatementDet.TEAllowTrans.EditValue = GVList.GetFocusedRowCellValue("allow_trans")
        FormLetterOfStatementDet.TEAllowHouse.EditValue = GVList.GetFocusedRowCellValue("allow_house")
        FormLetterOfStatementDet.TEAllowCar.EditValue = GVList.GetFocusedRowCellValue("allow_car")

        FormLetterOfStatementDet.basic_salary = GVList.GetFocusedRowCellValue("basic_salary").ToString
        FormLetterOfStatementDet.allow_job = GVList.GetFocusedRowCellValue("allow_job").ToString
        FormLetterOfStatementDet.allow_meal = GVList.GetFocusedRowCellValue("allow_meal").ToString
        FormLetterOfStatementDet.allow_trans = GVList.GetFocusedRowCellValue("allow_trans").ToString
        FormLetterOfStatementDet.allow_house = GVList.GetFocusedRowCellValue("allow_house").ToString
        FormLetterOfStatementDet.allow_car = GVList.GetFocusedRowCellValue("allow_car").ToString

        Close()
    End Sub

    Private Sub FormLetterOfStatementEmployee_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class