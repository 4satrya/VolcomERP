Public Class FormOpt
    Private dataOpt As New DataTable
    Private dataOptAcc As New DataTable
    Private dataOptEmp As New DataTable
    Private dataOptGen As New DataTable
    Private dataOptMat As New DataTable
    Private dataOptPro As New DataTable
    Private dataOptPur As New DataTable
    Private dataOptSal As New DataTable
    Private dataOptSch As New DataTable

    Private dataCColumn As New DataTable
    Private dataCAll As New DataTable

    Private dataOColumn As New DataTable
    Private dataOAll As New DataTable

    Private dataAColumn As New DataTable
    Private dataAAll As New DataTable

    Private dataEColumn As New DataTable
    Private dataEAll As New DataTable

    Private dataGColumn As New DataTable
    Private dataGAll As New DataTable

    Private dataMColumn As New DataTable
    Private dataMAll As New DataTable

    Private dataPRColumn As New DataTable
    Private dataPRAll As New DataTable

    Private dataPUColumn As New DataTable
    Private dataPUAll As New DataTable

    Private dataSAColumn As New DataTable
    Private dataSAAll As New DataTable

    Private dataSCColumn As New DataTable
    Private dataSCAll As New DataTable

    Private optChange As New DataTable
    Public id_store As String = "-1"

    Private Sub FormOpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_data()
    End Sub

    Private Sub FormOpt_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormOpt_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        'reset
        optChange = New DataTable

        optChange.Columns.Add("name")
        optChange.Columns.Add("value_from")
        optChange.Columns.Add("value_to")
        optChange.Columns.Add("type")
        optChange.Columns.Add("data")

        'opt
        For i = 0 To GVCode.RowCount - 1
            If Not dataOpt.Rows(0)(GVCode.GetRowCellValue(i, "name")).ToString = GVCode.GetRowCellValue(i, "value").ToString Then
                optChange.Rows.Add(GVCode.GetRowCellValue(i, "name"), dataOpt.Rows(0)(GVCode.GetRowCellValue(i, "name")), GVCode.GetRowCellValue(i, "value"), "opt", GVCode.GetRowCellValue(i, "type"))
            End If
        Next

        For i = 0 To GVOther.RowCount - 1
            If Not dataOpt.Rows(0)(GVOther.GetRowCellValue(i, "name")).ToString = GVOther.GetRowCellValue(i, "value").ToString Then
                optChange.Rows.Add(GVOther.GetRowCellValue(i, "name"), dataOpt.Rows(0)(GVOther.GetRowCellValue(i, "name")), GVOther.GetRowCellValue(i, "value"), "opt", GVOther.GetRowCellValue(i, "type"))
            End If
        Next

        'accounting
        For i = 0 To GVAccounting.RowCount - 1
            If Not dataOptAcc.Rows(0)(GVAccounting.GetRowCellValue(i, "name")).ToString = GVAccounting.GetRowCellValue(i, "value").ToString Then
                optChange.Rows.Add(GVAccounting.GetRowCellValue(i, "name"), dataOptAcc.Rows(0)(GVAccounting.GetRowCellValue(i, "name")), GVAccounting.GetRowCellValue(i, "value"), "accounting", GVAccounting.GetRowCellValue(i, "type"))
            End If
        Next

        'employee
        For i = 0 To GVEmployee.RowCount - 1
            If Not dataOptEmp.Rows(0)(GVEmployee.GetRowCellValue(i, "name")).ToString = GVEmployee.GetRowCellValue(i, "value").ToString Then
                optChange.Rows.Add(GVEmployee.GetRowCellValue(i, "name"), dataOptEmp.Rows(0)(GVEmployee.GetRowCellValue(i, "name")), GVEmployee.GetRowCellValue(i, "value"), "employee", GVEmployee.GetRowCellValue(i, "type"))
            End If
        Next

        'general
        For i = 0 To GVGeneral.RowCount - 1
            If Not dataOptGen.Rows(0)(GVGeneral.GetRowCellValue(i, "name")).ToString = GVGeneral.GetRowCellValue(i, "value").ToString Then
                optChange.Rows.Add(GVGeneral.GetRowCellValue(i, "name"), dataOptGen.Rows(0)(GVGeneral.GetRowCellValue(i, "name")), GVGeneral.GetRowCellValue(i, "value"), "general", GVGeneral.GetRowCellValue(i, "type"))
            End If
        Next

        'material
        For i = 0 To GVMaterial.RowCount - 1
            If Not dataOptMat.Rows(0)(GVMaterial.GetRowCellValue(i, "name")).ToString = GVMaterial.GetRowCellValue(i, "value").ToString Then
                optChange.Rows.Add(GVMaterial.GetRowCellValue(i, "name"), dataOptMat.Rows(0)(GVMaterial.GetRowCellValue(i, "name")), GVMaterial.GetRowCellValue(i, "value"), "material", GVMaterial.GetRowCellValue(i, "type"))
            End If
        Next

        'production
        For i = 0 To GVProduction.RowCount - 1
            If Not dataOptPro.Rows(0)(GVProduction.GetRowCellValue(i, "name")).ToString = GVProduction.GetRowCellValue(i, "value").ToString Then
                optChange.Rows.Add(GVProduction.GetRowCellValue(i, "name"), dataOptPro.Rows(0)(GVProduction.GetRowCellValue(i, "name")), GVProduction.GetRowCellValue(i, "value"), "production", GVProduction.GetRowCellValue(i, "type"))
            End If
        Next

        'purchasing
        For i = 0 To GVPurchasing.RowCount - 1
            If Not dataOptPur.Rows(0)(GVPurchasing.GetRowCellValue(i, "name")).ToString = GVPurchasing.GetRowCellValue(i, "value").ToString Then
                optChange.Rows.Add(GVPurchasing.GetRowCellValue(i, "name"), dataOptPur.Rows(0)(GVPurchasing.GetRowCellValue(i, "name")), GVPurchasing.GetRowCellValue(i, "value"), "purchasing", GVPurchasing.GetRowCellValue(i, "type"))
            End If
        Next

        'sales
        For i = 0 To GVSales.RowCount - 1
            If Not dataOptSal.Rows(0)(GVSales.GetRowCellValue(i, "name")).ToString = GVSales.GetRowCellValue(i, "value").ToString Then
                optChange.Rows.Add(GVSales.GetRowCellValue(i, "name"), dataOptSal.Rows(0)(GVSales.GetRowCellValue(i, "name")), GVSales.GetRowCellValue(i, "value"), "sales", GVSales.GetRowCellValue(i, "type"))
            End If
        Next

        'scheduler
        For i = 0 To GVScheduler.RowCount - 1
            If Not dataOptSch.Rows(0)(GVScheduler.GetRowCellValue(i, "name")).ToString = GVScheduler.GetRowCellValue(i, "value").ToString Then
                optChange.Rows.Add(GVScheduler.GetRowCellValue(i, "name"), dataOptSch.Rows(0)(GVScheduler.GetRowCellValue(i, "name")), GVScheduler.GetRowCellValue(i, "value"), "scheduler", GVScheduler.GetRowCellValue(i, "type"))
            End If
        Next

        Dim queryOpt As String = ""
        Dim queryAcc As String = ""
        Dim queryEmp As String = ""
        Dim queryGen As String = ""
        Dim queryMat As String = ""
        Dim queryPro As String = ""
        Dim queryPur As String = ""
        Dim querySal As String = ""
        Dim querySch As String = ""

        Dim message As String = ""

        Try
            For i = 0 To optChange.Rows.Count - 1
                'query opt
                If optChange.Rows(i)("type") = "opt" Then
                    If queryOpt = "" Then
                        queryOpt = "UPDATE tb_opt SET "
                    End If

                    If optChange.Rows(i)("data") = "integer" Then
                        queryOpt += optChange.Rows(i)("name") + " = '" + Convert.ToInt32(optChange.Rows(i)("value_to")).ToString + "', "
                    ElseIf optChange.Rows(i)("data") = "decimal" Then
                        queryOpt += optChange.Rows(i)("name") + " = '" + decimalSQL(optChange.Rows(i)("value_to")) + "', "
                    Else
                        queryOpt += optChange.Rows(i)("name") + " = '" + addSlashes(optChange.Rows(i)("value_to")) + "', "
                    End If
                End If

                'query accounting
                If optChange.Rows(i)("type") = "accounting" Then
                    If queryAcc = "" Then
                        queryAcc = "UPDATE tb_opt_accounting SET "
                    End If

                    If optChange.Rows(i)("data") = "integer" Then
                        queryAcc += optChange.Rows(i)("name") + " = '" + Convert.ToInt32(optChange.Rows(i)("value_to")).ToString + "', "
                    ElseIf optChange.Rows(i)("data") = "decimal" Then
                        queryAcc += optChange.Rows(i)("name") + " = '" + decimalSQL(optChange.Rows(i)("value_to")) + "', "
                    Else
                        queryAcc += optChange.Rows(i)("name") + " = '" + addSlashes(optChange.Rows(i)("value_to")) + "', "
                    End If
                End If

                'query employee
                If optChange.Rows(i)("type") = "employee" Then
                    If queryEmp = "" Then
                        queryEmp = "UPDATE tb_opt_emp SET "
                    End If

                    If optChange.Rows(i)("data") = "integer" Then
                        queryEmp += optChange.Rows(i)("name") + " = '" + Convert.ToInt32(optChange.Rows(i)("value_to")).ToString + "', "
                    ElseIf optChange.Rows(i)("data") = "decimal" Then
                        queryEmp += optChange.Rows(i)("name") + " = '" + decimalSQL(optChange.Rows(i)("value_to")) + "', "
                    Else
                        queryEmp += optChange.Rows(i)("name") + " = '" + addSlashes(optChange.Rows(i)("value_to")) + "', "
                    End If
                End If

                'query general
                If optChange.Rows(i)("type") = "general" Then
                    If queryGen = "" Then
                        queryGen = "UPDATE tb_opt_general SET "
                    End If

                    If optChange.Rows(i)("data") = "integer" Then
                        queryGen += optChange.Rows(i)("name") + " = '" + Convert.ToInt32(optChange.Rows(i)("value_to")).ToString + "', "
                    ElseIf optChange.Rows(i)("data") = "decimal" Then
                        queryGen += optChange.Rows(i)("name") + " = '" + decimalSQL(optChange.Rows(i)("value_to")) + "', "
                    Else
                        queryGen += optChange.Rows(i)("name") + " = '" + addSlashes(optChange.Rows(i)("value_to")) + "', "
                    End If
                End If

                'query material
                If optChange.Rows(i)("type") = "material" Then
                    If queryMat = "" Then
                        queryMat = "UPDATE tb_opt_mat SET "
                    End If

                    If optChange.Rows(i)("data") = "integer" Then
                        queryMat += optChange.Rows(i)("name") + " = '" + Convert.ToInt32(optChange.Rows(i)("value_to")).ToString + "', "
                    ElseIf optChange.Rows(i)("data") = "decimal" Then
                        queryMat += optChange.Rows(i)("name") + " = '" + decimalSQL(optChange.Rows(i)("value_to")) + "', "
                    Else
                        queryMat += optChange.Rows(i)("name") + " = '" + addSlashes(optChange.Rows(i)("value_to")) + "', "
                    End If
                End If

                'query production
                If optChange.Rows(i)("type") = "production" Then
                    If queryPro = "" Then
                        queryPro = "UPDATE tb_opt_prod SET "
                    End If

                    If optChange.Rows(i)("data") = "integer" Then
                        queryPro += optChange.Rows(i)("name") + " = '" + Convert.ToInt32(optChange.Rows(i)("value_to")).ToString + "', "
                    ElseIf optChange.Rows(i)("data") = "decimal" Then
                        queryPro += optChange.Rows(i)("name") + " = '" + decimalSQL(optChange.Rows(i)("value_to")) + "', "
                    Else
                        queryPro += optChange.Rows(i)("name") + " = '" + addSlashes(optChange.Rows(i)("value_to")) + "', "
                    End If
                End If

                'query purchasing
                If optChange.Rows(i)("type") = "purchasing" Then
                    If queryPur = "" Then
                        queryPur = "UPDATE tb_opt_purchasing SET "
                    End If

                    If optChange.Rows(i)("data") = "integer" Then
                        queryPur += optChange.Rows(i)("name") + " = '" + Convert.ToInt32(optChange.Rows(i)("value_to")).ToString + "', "
                    ElseIf optChange.Rows(i)("data") = "decimal" Then
                        queryPur += optChange.Rows(i)("name") + " = '" + decimalSQL(optChange.Rows(i)("value_to")) + "', "
                    Else
                        queryPur += optChange.Rows(i)("name") + " = '" + addSlashes(optChange.Rows(i)("value_to")) + "', "
                    End If
                End If

                'query sales
                If optChange.Rows(i)("type") = "sales" Then
                    If querySal = "" Then
                        querySal = "UPDATE tb_opt_sales SET "
                    End If

                    If optChange.Rows(i)("data") = "integer" Then
                        querySal += optChange.Rows(i)("name") + " = '" + Convert.ToInt32(optChange.Rows(i)("value_to")).ToString + "', "
                    ElseIf optChange.Rows(i)("data") = "decimal" Then
                        querySal += optChange.Rows(i)("name") + " = '" + decimalSQL(optChange.Rows(i)("value_to")) + "', "
                    Else
                        querySal += optChange.Rows(i)("name") + " = '" + addSlashes(optChange.Rows(i)("value_to")) + "', "
                    End If
                End If

                'query scheduler
                If optChange.Rows(i)("type") = "scheduler" Then
                    If querySch = "" Then
                        querySch = "UPDATE tb_opt_scheduler SET "
                    End If

                    If optChange.Rows(i)("data") = "integer" Then
                        querySch += optChange.Rows(i)("name") + " = '" + Convert.ToInt32(optChange.Rows(i)("value_to")).ToString + "', "
                    ElseIf optChange.Rows(i)("data") = "decimal" Then
                        querySch += optChange.Rows(i)("name") + " = '" + decimalSQL(optChange.Rows(i)("value_to")) + "', "
                    Else
                        querySch += optChange.Rows(i)("name") + " = '" + addSlashes(optChange.Rows(i)("value_to")) + "', "
                    End If
                End If

                'message
                If i = 0 Then
                    message = "Changes: " + Environment.NewLine
                End If

                message += optChange.Rows(i)("name") + ": " + optChange.Rows(i)("value_from") + " => " + optChange.Rows(i)("value_to") + Environment.NewLine
            Next

            'message += queryOpt + Environment.NewLine
            'message += queryAcc + Environment.NewLine
            'message += queryEmp + Environment.NewLine
            'message += queryGen + Environment.NewLine
            'message += queryMat + Environment.NewLine
            'message += queryPro + Environment.NewLine
            'message += queryPur + Environment.NewLine
            'message += querySal + Environment.NewLine
            'message += querySch + Environment.NewLine

            If message = "" Then
                errorCustom("Nothing has changed.")
            Else
                Dim confirm As DialogResult
                confirm = DevExpress.XtraEditors.XtraMessageBox.Show(message, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                If confirm = Windows.Forms.DialogResult.Yes Then
                    If Not queryOpt = "" Then
                        queryOpt = queryOpt.TrimEnd(",", " ")
                        execute_non_query(queryOpt, True, "", "", "", "")
                        'Console.WriteLine(queryOpt)
                    End If

                    If Not queryAcc = "" Then
                        queryAcc = queryAcc.TrimEnd(",", " ")
                        execute_non_query(queryAcc, True, "", "", "", "")
                        'Console.WriteLine(queryAcc)
                    End If

                    If Not queryEmp = "" Then
                        queryEmp = queryEmp.TrimEnd(",", " ")
                        execute_non_query(queryEmp, True, "", "", "", "")
                        'Console.WriteLine(queryEmp)
                    End If

                    If Not queryGen = "" Then
                        queryGen = queryGen.TrimEnd(",", " ")
                        execute_non_query(queryGen, True, "", "", "", "")
                        'Console.WriteLine(queryGen)
                    End If

                    If Not queryMat = "" Then
                        queryMat = queryMat.TrimEnd(",", " ")
                        execute_non_query(queryMat, True, "", "", "", "")
                        'Console.WriteLine(queryMat)
                    End If

                    If Not queryPro = "" Then
                        queryPro = queryPro.TrimEnd(",", " ")
                        execute_non_query(queryPro, True, "", "", "", "")
                        'Console.WriteLine(queryPro)
                    End If

                    If Not queryPur = "" Then
                        queryPur = queryPur.TrimEnd(",", " ")
                        execute_non_query(queryPur, True, "", "", "", "")
                        'Console.WriteLine(queryPur)
                    End If

                    If Not querySal = "" Then
                        querySal = querySal.TrimEnd(",", " ")
                        execute_non_query(querySal, True, "", "", "", "")
                        'Console.WriteLine(querySal)
                    End If

                    If Not querySch = "" Then
                        querySch = querySch.TrimEnd(",", " ")
                        execute_non_query(querySch, True, "", "", "", "")
                        'Console.WriteLine(querySch)
                    End If

                    infoCustom("Changes has been saved.")

                    load_data()
                End If
            End If
        Catch ex As Exception
            errorCustom("Please check your input.")
        End Try
    End Sub

    Sub load_data()
        Dim type As String = ""

        'reset data
        dataOpt = New DataTable
        dataOptAcc = New DataTable

        dataCColumn = New DataTable
        dataCAll = New DataTable

        dataOColumn = New DataTable
        dataOAll = New DataTable

        dataAColumn = New DataTable
        dataAAll = New DataTable

        dataEColumn = New DataTable
        dataEAll = New DataTable

        dataGColumn = New DataTable
        dataGAll = New DataTable

        dataMColumn = New DataTable
        dataMAll = New DataTable

        dataPRColumn = New DataTable
        dataPRAll = New DataTable

        dataPUColumn = New DataTable
        dataPUAll = New DataTable

        dataSAColumn = New DataTable
        dataSAAll = New DataTable

        dataSCColumn = New DataTable
        dataSCAll = New DataTable

        'value
        Dim queryOpt As String = "SELECT * FROM tb_opt"
        dataOpt = execute_query(queryOpt, -1, True, "", "", "", "")

        Dim queryOptAcc As String = "SELECT * FROM tb_opt_accounting"
        dataOptAcc = execute_query(queryOptAcc, -1, True, "", "", "", "")

        Dim queryOptEmp As String = "SELECT * FROM tb_opt_emp"
        dataOptEmp = execute_query(queryOptEmp, -1, True, "", "", "", "")

        Dim queryOptGen As String = "SELECT * FROM tb_opt_general"
        dataOptGen = execute_query(queryOptGen, -1, True, "", "", "", "")

        Dim queryOptMat As String = "SELECT * FROM tb_opt_mat"
        dataOptMat = execute_query(queryOptMat, -1, True, "", "", "", "")

        Dim queryOptPro As String = "SELECT * FROM tb_opt_prod"
        dataOptPro = execute_query(queryOptPro, -1, True, "", "", "", "")

        Dim queryOptPur As String = "SELECT * FROM tb_opt_purchasing"
        dataOptPur = execute_query(queryOptPur, -1, True, "", "", "", "")

        Dim queryOptSal As String = "SELECT * FROM tb_opt_sales"
        dataOptSal = execute_query(queryOptSal, -1, True, "", "", "", "")

        Dim queryOptSch As String = "SELECT * FROM tb_opt_scheduler"
        dataOptSch = execute_query(queryOptSch, -1, True, "", "", "", "")

        'code
        Dim queryCColumn As String = "SHOW COLUMNS FROM tb_opt WHERE `Field` REGEXP 'code_head|code_inc|code_digit'"
        dataCColumn = execute_query(queryCColumn, -1, True, "", "", "", "")

        dataCAll.Columns.Add("name", GetType(String))
        dataCAll.Columns.Add("value", GetType(String))
        dataCAll.Columns.Add("type", GetType(String))

        For i = 0 To dataCColumn.Rows.Count - 1
            type = "string"

            If dataCColumn.Rows(i)("Type").ToString.Contains("int") Then
                type = "integer"
            End If

            If dataCColumn.Rows(i)("Type").ToString.Contains("decimal") Then
                type = "decimal"
            End If

            dataCAll.Rows.Add(dataCColumn.Rows(i)("Field"), dataOpt.Rows(0)(dataCColumn.Rows(i)("Field")), type)
        Next

        GCCode.DataSource = dataCAll

        GVCode.BestFitColumns()

        'other
        Dim queryOColumn As String = "SHOW COLUMNS FROM tb_opt WHERE `Field` NOT REGEXP 'code_head|code_inc|code_digit'"
        dataOColumn = execute_query(queryOColumn, -1, True, "", "", "", "")

        dataOAll.Columns.Add("name", GetType(String))
        dataOAll.Columns.Add("value", GetType(String))
        dataOAll.Columns.Add("type", GetType(String))

        For i = 0 To dataOColumn.Rows.Count - 1
            type = "string"

            If dataOColumn.Rows(i)("Type").ToString.Contains("int") Then
                type = "integer"
            End If

            If dataOColumn.Rows(i)("Type").ToString.Contains("decimal") Then
                type = "decimal"
            End If

            dataOAll.Rows.Add(dataOColumn.Rows(i)("Field"), dataOpt.Rows(0)(dataOColumn.Rows(i)("Field")), type)
        Next

        GCOther.DataSource = dataOAll

        GVOther.BestFitColumns()

        'accounting
        Dim queryAColumn As String = "SHOW COLUMNS FROM tb_opt_accounting"
        dataAColumn = execute_query(queryAColumn, -1, True, "", "", "", "")

        dataAAll.Columns.Add("name", GetType(String))
        dataAAll.Columns.Add("value", GetType(String))
        dataAAll.Columns.Add("type", GetType(String))

        For i = 0 To dataAColumn.Rows.Count - 1
            type = "string"

            If dataAColumn.Rows(i)("Type").ToString.Contains("int") Then
                type = "integer"
            End If

            If dataAColumn.Rows(i)("Type").ToString.Contains("decimal") Then
                type = "decimal"
            End If

            dataAAll.Rows.Add(dataAColumn.Rows(i)("Field"), dataOptAcc.Rows(0)(dataAColumn.Rows(i)("Field")), type)
        Next

        GCAccounting.DataSource = dataAAll

        GVAccounting.BestFitColumns()

        'employee
        Dim queryEColumn As String = "SHOW COLUMNS FROM tb_opt_emp"
        dataEColumn = execute_query(queryEColumn, -1, True, "", "", "", "")

        dataEAll.Columns.Add("name", GetType(String))
        dataEAll.Columns.Add("value", GetType(String))
        dataEAll.Columns.Add("type", GetType(String))

        For i = 0 To dataEColumn.Rows.Count - 1
            type = "string"

            If dataEColumn.Rows(i)("Type").ToString.Contains("int") Then
                type = "integer"
            End If

            If dataEColumn.Rows(i)("Type").ToString.Contains("decimal") Then
                type = "decimal"
            End If

            dataEAll.Rows.Add(dataEColumn.Rows(i)("Field"), dataOptEmp.Rows(0)(dataEColumn.Rows(i)("Field")), type)
        Next

        GCEmployee.DataSource = dataEAll

        GVEmployee.BestFitColumns()

        'general
        Dim queryGColumn As String = "SHOW COLUMNS FROM tb_opt_general"
        dataGColumn = execute_query(queryGColumn, -1, True, "", "", "", "")

        dataGAll.Columns.Add("name", GetType(String))
        dataGAll.Columns.Add("value", GetType(String))
        dataGAll.Columns.Add("type", GetType(String))

        For i = 0 To dataGColumn.Rows.Count - 1
            type = "string"

            If dataGColumn.Rows(i)("Type").ToString.Contains("int") Then
                type = "integer"
            End If

            If dataGColumn.Rows(i)("Type").ToString.Contains("decimal") Then
                type = "decimal"
            End If

            dataGAll.Rows.Add(dataGColumn.Rows(i)("Field"), dataOptGen.Rows(0)(dataGColumn.Rows(i)("Field")), type)
        Next

        GCGeneral.DataSource = dataGAll

        GVGeneral.BestFitColumns()

        'material
        Dim queryMColumn As String = "SHOW COLUMNS FROM tb_opt_mat"
        dataMColumn = execute_query(queryMColumn, -1, True, "", "", "", "")

        dataMAll.Columns.Add("name", GetType(String))
        dataMAll.Columns.Add("value", GetType(String))
        dataMAll.Columns.Add("type", GetType(String))

        For i = 0 To dataMColumn.Rows.Count - 1
            type = "string"

            If dataMColumn.Rows(i)("Type").ToString.Contains("int") Then
                type = "integer"
            End If

            If dataMColumn.Rows(i)("Type").ToString.Contains("decimal") Then
                type = "decimal"
            End If

            dataMAll.Rows.Add(dataMColumn.Rows(i)("Field"), dataOptMat.Rows(0)(dataMColumn.Rows(i)("Field")), type)
        Next

        GCMaterial.DataSource = dataMAll

        GVMaterial.BestFitColumns()

        'production
        Dim queryPRColumn As String = "SHOW COLUMNS FROM tb_opt_prod"
        dataPRColumn = execute_query(queryPRColumn, -1, True, "", "", "", "")

        dataPRAll.Columns.Add("name", GetType(String))
        dataPRAll.Columns.Add("value", GetType(String))
        dataPRAll.Columns.Add("type", GetType(String))

        For i = 0 To dataPRColumn.Rows.Count - 1
            type = "string"

            If dataPRColumn.Rows(i)("Type").ToString.Contains("int") Then
                type = "integer"
            End If

            If dataPRColumn.Rows(i)("Type").ToString.Contains("decimal") Then
                type = "decimal"
            End If

            dataPRAll.Rows.Add(dataPRColumn.Rows(i)("Field"), dataOptPro.Rows(0)(dataPRColumn.Rows(i)("Field")), type)
        Next

        GCProduction.DataSource = dataPRAll

        GVProduction.BestFitColumns()

        'purchasing
        Dim queryPUColumn As String = "SHOW COLUMNS FROM tb_opt_purchasing"
        dataPUColumn = execute_query(queryPUColumn, -1, True, "", "", "", "")

        dataPUAll.Columns.Add("name", GetType(String))
        dataPUAll.Columns.Add("value", GetType(String))
        dataPUAll.Columns.Add("type", GetType(String))

        For i = 0 To dataPUColumn.Rows.Count - 1
            type = "string"

            If dataPUColumn.Rows(i)("Type").ToString.Contains("int") Then
                type = "integer"
            End If

            If dataPUColumn.Rows(i)("Type").ToString.Contains("decimal") Then
                type = "decimal"
            End If

            dataPUAll.Rows.Add(dataPUColumn.Rows(i)("Field"), dataOptPur.Rows(0)(dataPUColumn.Rows(i)("Field")), type)
        Next

        GCPurchasing.DataSource = dataPUAll

        GVPurchasing.BestFitColumns()

        'sales
        Dim querySAColumn As String = "SHOW COLUMNS FROM tb_opt_sales"
        dataSAColumn = execute_query(querySAColumn, -1, True, "", "", "", "")

        dataSAAll.Columns.Add("name", GetType(String))
        dataSAAll.Columns.Add("value", GetType(String))
        dataSAAll.Columns.Add("type", GetType(String))

        For i = 0 To dataSAColumn.Rows.Count - 1
            type = "string"

            If dataSAColumn.Rows(i)("Type").ToString.Contains("int") Then
                type = "integer"
            End If

            If dataSAColumn.Rows(i)("Type").ToString.Contains("decimal") Then
                type = "decimal"
            End If

            dataSAAll.Rows.Add(dataSAColumn.Rows(i)("Field"), dataOptSal.Rows(0)(dataSAColumn.Rows(i)("Field")), type)
        Next

        GCSales.DataSource = dataSAAll

        GVSales.BestFitColumns()

        'scheduler
        Dim querySCColumn As String = "SHOW COLUMNS FROM tb_opt_scheduler"
        dataSCColumn = execute_query(querySCColumn, -1, True, "", "", "", "")

        dataSCAll.Columns.Add("name", GetType(String))
        dataSCAll.Columns.Add("value", GetType(String))
        dataSCAll.Columns.Add("type", GetType(String))

        For i = 0 To dataSCColumn.Rows.Count - 1
            type = "string"

            If dataSCColumn.Rows(i)("Type").ToString.Contains("int") Then
                type = "integer"
            End If

            If dataSCColumn.Rows(i)("Type").ToString.Contains("decimal") Then
                type = "decimal"
            End If

            dataSCAll.Rows.Add(dataSCColumn.Rows(i)("Field"), dataOptSch.Rows(0)(dataSCColumn.Rows(i)("Field")), type)
        Next

        GCScheduler.DataSource = dataSCAll

        GVScheduler.BestFitColumns()
    End Sub



    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "91"
        FormPopUpContact.id_cat = "6"
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnLoadUniqueCode_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If id_store = "-1" Then
            BtnSet.Enabled = False
            stopCustom("Please select store first")
        Else
            Dim query As String = "CALL view_stock_fg_unique_ret(0, " + id_store + ", 0, 0)"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                GCCodeList.DataSource = data
                GVCodeList.BestFitColumns()
                BtnSet.Enabled = True
            Else
                BtnSet.Enabled = False
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs)
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Transaksi ini sekaligus melakukan migrasi kode unik yang sudah pernah terkirim di toko " + TxtCompName.Text + ". Yakin kamu mau aktifin?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            makeSafeGV(GVCodeList)
            For i As Integer = 0 To GVCodeList.RowCount - 1
                If GVCodeList.GetRowCellValue(i, "stt").ToString = "" Then
                    Dim query As String = "INSERT IGNORE INTO tb_m_unique_code(id_type, unique_code, id_design_price, design_price, qty, is_unique_report)
                    VALUES(5, '" + GVCodeList.GetRowCellValue(i, "product_full_code").ToString + "','" + GVCodeList.GetRowCellValue(i, "id_design_price").ToString + "', '" + decimalSQL(GVCodeList.GetRowCellValue(i, "design_price").ToString) + "', 1, 2); "
                    execute_non_query(query, True, "", "", "", "")
                    GVCodeList.SetRowCellValue(i, "stt", "OK")
                End If

            Next

            'jika ssudah semua 
            Dim query_upd As String = "UPDATE tb_m_comp SET is_use_unique_code='1' WHERE id_comp='" + id_store + "' "
            execute_non_query(query_upd, True, "", "", "", "")
            reset()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Yakin mau reset?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            reset()
        End If
    End Sub

    Sub reset()
        id_store = "-1"
        TxtCompName.Text = ""
        TxtCompNumber.Text = ""
        TxtUseUniqueCode.Text = ""
        GCCodeList.DataSource = Nothing
    End Sub

    Private Sub BtnSet_Click(sender As Object, e As EventArgs) Handles BtnSet.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Transaksi ini sekaligus melakukan migrasi kode unik yang sudah pernah terkirim di toko " + TxtCompName.Text + ". Yakin kamu mau aktifin?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            'generate
            Dim query As String = "CALL ins_unique_code_migration(" + id_store + "); UPDATE tb_m_comp SET is_use_unique_code=1 WHERE id_comp=" + id_store + ";"
            execute_non_query(query, True, "", "", "", "")
            TxtUseUniqueCode.Text = "Yes"
            BtnSet.Enabled = False
            infoCustom("Aktifasi sukses")
            Cursor = Cursors.Default
        End If
    End Sub

    Sub loadUniqueCode()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT u.id_unique_code, u.id_comp, u.id_product, p.product_display_name, u.id_pl_sales_order_del_det, d.pl_sales_order_del_number, 
        u.id_sales_pos_det, sal.sales_pos_number AS `sal_number`,
        u.id_sales_pos_cn_det, cn.sales_pos_number AS `cn_number`, 
        u.id_sales_return_det, r.sales_return_number,
        u.id_type, u.unique_code, 
        u.id_design_price, u.design_price, u.qty, u.is_unique_report, u.input_date
        FROM tb_m_unique_code u
        INNER JOIN tb_m_product p ON p.id_product = u.id_product
        LEFT JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del_det = u.id_pl_sales_order_del_det
        LEFT JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del
        LEFT JOIN tb_sales_pos_det sald ON sald.id_sales_pos_det = u.id_sales_pos_det
        LEFT JOIN tb_sales_pos sal ON sal.id_sales_pos = sald.id_sales_pos
        LEFT JOIN tb_sales_pos_det cnd ON cnd.id_sales_pos_det = u.id_sales_pos_cn_det
        LEFT JOIN tb_sales_pos cn ON cn.id_sales_pos = cnd.id_sales_pos
        LEFT JOIN tb_sales_return_det rd ON rd.id_sales_return_det = u.id_sales_return_det
        LEFT JOIN tb_sales_return r ON r.id_sales_return = rd.id_sales_return
        WHERE u.id_comp=" + id_store + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCodeList.DataSource = data
        GVCodeList.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnLoad_Click(sender As Object, e As EventArgs) Handles BtnLoad.Click
        loadUniqueCode()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCCodeList, "")
        Cursor = Cursors.Default
    End Sub
End Class