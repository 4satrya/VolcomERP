Public Class FormBankWithdrawalDet
    Public report_mark_type As String = "-1"
    Public id_pay_type As String = "-1"
    Public id_payment As String = "-1"
    '
    Public is_view As String = "-1"
    '
    Private Sub FormBankWithdrawalDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub form_load()
        TEKurs.EditValue = 1.0
        TETotal.EditValue = 0.00
        DEDateCreated.EditValue = Now
        TEPayNumber.Text = "[Auto generate]"

        load_pay_from()
        load_vendor()
        load_trans_type()
        load_report_type()
        '
        If id_payment = "-1" Then
            load_det()
            BtnPrint.Visible = False
            BMark.Visible = False
            BtnSave.Visible = True
            '
            If report_mark_type = "159" Then 'BBK umum
                'load header
                Try
                    SLEVendor.EditValue = FormBankWithdrawal.SLEVendorPayment.EditValue
                    SLEPayType.EditValue = "2"
                    '
                    SLEReportType.EditValue = report_mark_type
                    '
                    calculate_amount()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf report_mark_type = "139" Or report_mark_type = "202" Then 'purchasing
                'load header
                Try
                    SLEVendor.EditValue = FormBankWithdrawal.SLEVendor.EditValue
                    SLEPayType.EditValue = id_pay_type
                    '
                    SLEReportType.EditValue = report_mark_type
                    'load detail
                    For i As Integer = 0 To FormBankWithdrawal.GVPOList.RowCount - 1
                        'due
                        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                        newRow("id_report") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "id_purc_order").ToString
                        newRow("report_mark_type") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "report_mark_type").ToString
                        newRow("id_acc") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "id_acc").ToString
                        newRow("acc_name") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "acc_name").ToString
                        newRow("acc_description") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "acc_description").ToString
                        newRow("vendor") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "comp_number").ToString
                        newRow("id_dc") = "1"
                        newRow("dc_code") = "D"
                        newRow("id_comp") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "id_comp_default").ToString
                        newRow("comp_number") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "comp_number_default").ToString
                        newRow("number") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "purc_order_number").ToString
                        newRow("total_pay") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_dp")
                        newRow("kurs") = 0
                        newRow("id_currency") = "1"
                        newRow("val_bef_kurs") = 0
                        newRow("value") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_due")
                        newRow("value_view") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_due")
                        newRow("balance_due") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_due")
                        newRow("note") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "acc_name").ToString
                        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                        If FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_total") > 0 Then
                            'pph
                            Dim newRow_pph As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                            newRow_pph("id_report") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "id_purc_order").ToString
                            newRow_pph("report_mark_type") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "report_mark_type").ToString
                            newRow_pph("id_acc") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_account").ToString
                            newRow_pph("acc_name") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_acc_name").ToString
                            newRow_pph("acc_description") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_acc_description").ToString
                            newRow_pph("vendor") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "comp_number").ToString
                            newRow_pph("id_dc") = "1"
                            newRow_pph("dc_code") = "D"
                            newRow_pph("id_comp") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "id_comp_default").ToString
                            newRow_pph("comp_number") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "comp_number_default").ToString
                            newRow_pph("number") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "purc_order_number").ToString
                            newRow_pph("total_pay") = 0
                            newRow_pph("kurs") = 0
                            newRow_pph("id_currency") = "1"
                            newRow_pph("val_bef_kurs") = 0
                            newRow_pph("value") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_total")
                            newRow_pph("value_view") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_total")
                            newRow_pph("balance_due") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_total")
                            newRow_pph("note") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "acc_name").ToString
                            TryCast(GCList.DataSource, DataTable).Rows.Add(newRow_pph)
                        End If
                    Next
                    '
                    calculate_amount()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf report_mark_type = "157" Then 'expense
                'load header
                Dim id_comp As String = FormBankWithdrawal.SLEVendorExpense.EditValue
                Dim id_comp_contact As String = get_company_x(id_comp, 6)
                SLEVendor.EditValue = id_comp_contact
                SLEPayType.EditValue = id_pay_type
                SLEReportType.EditValue = report_mark_type

                If id_pay_type = "2" Then 'Payment
                    GridColumnPayment.OptionsColumn.AllowEdit = False
                Else
                    GridColumnPayment.OptionsColumn.AllowEdit = True
                End If

                'load detail
                For i As Integer = 0 To FormBankWithdrawal.GVExpense.RowCount - 1
                    'id_report,number,total,balance due
                    Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                    newRow("id_report") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "id_item_expense").ToString
                    newRow("report_mark_type") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "report_mark_type").ToString
                    newRow("id_acc") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "id_acc").ToString
                    newRow("acc_name") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "acc_name").ToString
                    newRow("acc_description") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "acc_description").ToString
                    newRow("vendor") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "comp_number").ToString
                    newRow("id_dc") = "1"
                    newRow("dc_code") = "D"
                    newRow("id_comp") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "id_comp_default").ToString
                    newRow("comp_number") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "comp_number_default").ToString
                    newRow("number") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "number").ToString
                    newRow("total_pay") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "total_dp")
                    newRow("kurs") = 0
                    newRow("id_currency") = "1"
                    newRow("val_bef_kurs") = 0
                    newRow("value") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "balance")
                    newRow("value_view") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "balance")
                    newRow("balance_due") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "balance")
                    newRow("note") = ""
                    TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                Next
                calculate_amount()
            ElseIf report_mark_type = "189" Then 'BPL
                'load header
                Dim id_comp As String = FormBankWithdrawal.SLEFGPOVendor.EditValue
                Dim id_comp_contact As String = get_company_x(id_comp, 6)
                SLEVendor.EditValue = id_comp_contact
                SLEReportType.EditValue = report_mark_type
                SLEPayType.Visible = False
                Dim selisih_kurs As Decimal = 0.00
                'load detail
                For i As Integer = 0 To FormBankWithdrawal.GVFGPO.RowCount - 1
                    'id_report, number, total, balance due
                    Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                    newRow("id_report") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "id_report").ToString
                    newRow("report_mark_type") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "report_mark_type").ToString
                    newRow("id_acc") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "id_acc").ToString
                    newRow("acc_name") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "acc_name").ToString
                    newRow("acc_description") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "acc_description").ToString
                    newRow("vendor") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "comp_number").ToString
                    newRow("id_dc") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "is_dc").ToString
                    newRow("dc_code") = If(FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "is_dc").ToString = "1", "D", "K")
                    newRow("id_comp") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "id_comp_default").ToString
                    newRow("comp_number") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "comp_number_default").ToString
                    newRow("number") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "number").ToString
                    newRow("total_pay") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "total_paid")
                    newRow("value") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "balance")
                    newRow("kurs") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "kurs")
                    newRow("id_currency") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "id_currency").ToString
                    newRow("val_bef_kurs") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "value_bef_kurs")
                    newRow("value_view") = If(FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "balance") < 0, -FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "balance"), FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "balance"))
                    newRow("balance_due") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "balance")
                    newRow("note") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "acc_name").ToString
                    TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                    If FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "total_paid") = 0 Then
                        selisih_kurs += FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "total") - FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "total_bpl")
                    End If
                Next
                'selisih kurs
                If Not selisih_kurs = 0 Then
                    Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                    newRow("id_report") = 0
                    newRow("report_mark_type") = 0
                    Dim q_acc As String = ""
                    If selisih_kurs > 0 Then
                        'kerugian kurs
                        q_acc = "SELECT id_acc,acc_name,acc_description FROM tb_a_acc WHERE id_acc=(SELECT id_acc_rugi_kurs FROM tb_opt_accounting LIMIT 1)"
                    Else
                        'keuntungan kurs
                        q_acc = "SELECT id_acc,acc_name,acc_description FROM tb_a_acc WHERE id_acc=(SELECT id_acc_untung_kurs FROM tb_opt_accounting LIMIT 1)"
                    End If
                    Dim dt_acc As DataTable = execute_query(q_acc, -1, True, "", "", "", "")

                    newRow("id_acc") = dt_acc.Rows(0)("id_acc").ToString
                    newRow("acc_name") = dt_acc.Rows(0)("acc_name").ToString
                    newRow("acc_description") = dt_acc.Rows(0)("acc_description").ToString
                    newRow("note") = dt_acc.Rows(0)("acc_description").ToString

                    newRow("vendor") = FormBankWithdrawal.GVFGPO.GetRowCellValue(0, "comp_number").ToString

                    newRow("id_comp") = FormBankWithdrawal.GVFGPO.GetRowCellValue(0, "id_comp_default").ToString
                    newRow("comp_number") = FormBankWithdrawal.GVFGPO.GetRowCellValue(0, "comp_number_default").ToString
                    newRow("total_pay") = 0
                    newRow("kurs") = 0
                    newRow("id_currency") = "1"
                    newRow("val_bef_kurs") = 0
                    newRow("value") = selisih_kurs
                    newRow("value_view") = selisih_kurs
                    If selisih_kurs > 0 Then 'kerugian kurs
                        newRow("id_dc") = 1
                        newRow("dc_code") = "D"
                        newRow("balance_due") = selisih_kurs
                    Else 'keuntungan kurs
                        newRow("id_dc") = 2
                        newRow("dc_code") = "K"
                        newRow("balance_due") = -selisih_kurs
                    End If

                    TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                End If
                calculate_amount()
                TEKurs.EditValue = FormBankWithdrawal.TEKurs.EditValue
            ElseIf report_mark_type = "223" Then 'BPJS Kesehatan
                'load header
                SLEVendor.EditValue = 1
                SLEPayType.EditValue = id_pay_type
                SLEReportType.EditValue = report_mark_type
                'load detail
                Dim data_map As DataTable = execute_query("
                    SELECT map.id_departement, map.id_departement_sub, map.id_acc, acc.acc_name, acc.acc_description, comp.comp_name AS vendor, map.id_comp, comp.comp_number
                    FROM tb_coa_map_departement AS map
                    LEFT JOIN tb_a_acc AS acc ON map.id_acc = acc.id_acc
                    LEFT JOIN tb_m_comp AS comp ON map.id_comp = comp.id_comp
                    WHERE type = 3
                ", -1, True, "", "", "", "")

                For i As Integer = 0 To FormBankWithdrawal.GVBPJSKesehatan.RowCount - 1
                    'id_report,number,total,balance due
                    Dim query As String = "
                        SELECT id_departement, id_departement_sub, is_store, SUM(ROUND(bpjs_kesehatan_contribution)) AS contribution_karyawan, SUM(ROUND(bpjs_kesehatan_contribution * 100 * 0.04)) AS contribution_perusahaan, periode, departement_display
	                    FROM (
	                        SELECT id_departement, IF(id_departement = 17, id_departement_sub, id_departement) AS id_departement_sub, (SELECT is_store FROM tb_m_departement WHERE id_departement = tb_pay_bpjs_kesehatan_det.id_departement) AS is_store, bpjs_kesehatan_contribution, (SELECT DATE_FORMAT(periode_end, '%M %Y') FROM tb_emp_payroll WHERE id_payroll = (SELECT id_payroll FROM tb_pay_bpjs_kesehatan WHERE id_pay_bpjs_kesehatan = tb_pay_bpjs_kesehatan_det.id_pay_bpjs_kesehatan)) AS periode, (SELECT departement_display FROM tb_m_departement WHERE id_departement = tb_pay_bpjs_kesehatan_det.id_departement) AS departement_display
	                        FROM tb_pay_bpjs_kesehatan_det
	                        WHERE id_pay_bpjs_kesehatan = " + FormBankWithdrawal.GVBPJSKesehatan.GetRowCellValue(i, "id_pay_bpjs_kesehatan").ToString + "
	                    ) AS tb
                        GROUP BY id_departement_sub
                    "

                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                    Dim total_office As Decimal = 0.00

                    For j = 0 To data.Rows.Count - 1
                        'get id_acc, acc_name, acc_description, vendor, id_comp, comp_number
                        Dim id_acc As Integer = 0
                        Dim acc_name As String = ""
                        Dim acc_description As String = ""
                        Dim vendor As String = ""
                        Dim id_comp As Integer = 0
                        Dim comp_number As String = ""
                        Dim balance As Decimal = 0.00
                        Dim note As String = "BPJS " + data.Rows(j)("periode").ToString + " (dibayar perusahaan)"

                        If data.Rows(j)("is_store").ToString = "2" Or data.Rows(j)("id_departement").ToString = "17" Then
                            total_office = total_office + data.Rows(j)("contribution_karyawan")
                        End If

                        For k = 0 To data_map.Rows.Count - 1
                            'office
                            If data.Rows(j)("is_store").ToString = "2" Then
                                If data.Rows(j)("id_departement").ToString = data_map.Rows(k)("id_departement").ToString Then
                                    id_acc = data_map.Rows(k)("id_acc")
                                    acc_name = data_map.Rows(k)("acc_name").ToString
                                    acc_description = data_map.Rows(k)("acc_description").ToString
                                    vendor = data_map.Rows(k)("vendor").ToString
                                    id_comp = data_map.Rows(k)("id_comp")
                                    comp_number = data_map.Rows(k)("comp_number").ToString
                                    balance = data.Rows(j)("contribution_perusahaan")

                                    Exit For
                                End If
                            Else
                                If data.Rows(j)("id_departement").ToString = "17" Then
                                    'store sogo
                                    If data.Rows(j)("id_departement_sub").ToString = data_map.Rows(k)("id_departement_sub").ToString Then
                                        id_acc = data_map.Rows(k)("id_acc")
                                        acc_name = data_map.Rows(k)("acc_name").ToString
                                        acc_description = data_map.Rows(k)("acc_description").ToString
                                        vendor = data_map.Rows(k)("vendor").ToString
                                        id_comp = data_map.Rows(k)("id_comp")
                                        comp_number = data_map.Rows(k)("comp_number").ToString
                                        balance = data.Rows(j)("contribution_perusahaan")

                                        Exit For
                                    End If
                                Else
                                    'store volcom
                                    If data.Rows(j)("id_departement").ToString = data_map.Rows(k)("id_departement").ToString Then
                                        id_acc = data_map.Rows(k)("id_acc")
                                        acc_name = data_map.Rows(k)("acc_name").ToString
                                        acc_description = data_map.Rows(k)("acc_description").ToString
                                        vendor = data_map.Rows(k)("vendor").ToString
                                        id_comp = data_map.Rows(k)("id_comp")
                                        comp_number = data_map.Rows(k)("comp_number").ToString
                                        balance = data.Rows(j)("contribution_karyawan") + data.Rows(j)("contribution_perusahaan")
                                        note = "BPJS " + data.Rows(j)("periode").ToString + " " + data.Rows(j)("departement_display").ToString

                                        Exit For
                                    End If
                                End If
                            End If
                        Next

                        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                        newRow("id_report") = FormBankWithdrawal.GVBPJSKesehatan.GetRowCellValue(i, "id_pay_bpjs_kesehatan").ToString
                        newRow("report_mark_type") = "223"
                        newRow("id_acc") = id_acc
                        newRow("acc_name") = acc_name
                        newRow("acc_description") = acc_description
                        newRow("vendor") = vendor
                        newRow("id_dc") = "1"
                        newRow("dc_code") = "D"
                        newRow("id_comp") = id_comp
                        newRow("comp_number") = comp_number
                        newRow("number") = FormBankWithdrawal.GVBPJSKesehatan.GetRowCellValue(i, "number").ToString
                        newRow("total_pay") = 0
                        newRow("value") = balance
                        newRow("kurs") = 0
                        newRow("id_currency") = "1"
                        newRow("val_bef_kurs") = 0
                        newRow("value_view") = balance
                        newRow("balance_due") = balance
                        newRow("note") = note
                        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)

                        If j = data.Rows.Count - 1 Then
                            If total_office > 0 Then
                                Dim query_last As String = "
                                    SELECT acc.id_acc, acc.acc_name, acc.acc_description, comp.id_comp, comp.comp_number, comp.comp_name AS vendor
                                    FROM tb_a_acc AS acc
                                    LEFT JOIN tb_m_comp AS comp ON comp.id_comp = 1
                                    WHERE acc.id_acc = 1153
                                "

                                Dim data_last As DataTable = execute_query(query_last, -1, True, "", "", "", "")

                                Dim newRow2 As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                                newRow2("id_report") = FormBankWithdrawal.GVBPJSKesehatan.GetRowCellValue(i, "id_pay_bpjs_kesehatan").ToString
                                newRow2("report_mark_type") = "223"
                                newRow2("id_acc") = data_last.Rows(0)("id_acc")
                                newRow2("acc_name") = data_last.Rows(0)("acc_name").ToString
                                newRow2("acc_description") = data_last.Rows(0)("acc_description").ToString
                                newRow2("vendor") = data_last.Rows(0)("vendor").ToString
                                newRow2("id_dc") = "1"
                                newRow2("dc_code") = "D"
                                newRow2("id_comp") = data_last.Rows(0)("id_comp")
                                newRow2("comp_number") = data_last.Rows(0)("comp_number").ToString
                                newRow2("number") = FormBankWithdrawal.GVBPJSKesehatan.GetRowCellValue(i, "number").ToString
                                newRow2("total_pay") = 0
                                newRow2("value") = total_office
                                newRow2("kurs") = 0
                                newRow2("id_currency") = "1"
                                newRow2("val_bef_kurs") = 0
                                newRow2("value_view") = total_office
                                newRow2("balance_due") = total_office
                                newRow2("note") = "BPJS " + data.Rows(j)("periode").ToString + " (dibayar karyawan)"
                                TryCast(GCList.DataSource, DataTable).Rows.Add(newRow2)
                            End If
                        End If
                    Next
                Next
                calculate_amount()
            ElseIf report_mark_type = "192" Then 'payroll
                'load header
                SLEVendor.EditValue = 1
                SLEPayType.EditValue = id_pay_type
                SLEReportType.EditValue = report_mark_type

                Dim me_note As String = ""

                'load detail
                Dim is_thr As String = execute_query("SELECT is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = (SELECT id_payroll_type FROM tb_emp_payroll WHERE id_payroll = " + FormBankWithdrawal.GVTHR.GetRowCellValue(0, "id_payroll").ToString + ")", 0, True, "", "", "", "")

                'thr
                If is_thr = "1" Then
                    Dim data_map As DataTable = execute_query("
                        SELECT map.id_departement, map.id_departement_sub, map.id_acc, acc.acc_name, acc.acc_description, comp.comp_name AS vendor, map.id_comp, comp.comp_number
                        FROM tb_coa_map_departement AS map
                        LEFT JOIN tb_a_acc AS acc ON map.id_acc = acc.id_acc
                        LEFT JOIN tb_m_comp AS comp ON map.id_comp = comp.id_comp
                        WHERE type = 4
                    ", -1, True, "", "", "", "")

                    For i As Integer = 0 To FormBankWithdrawal.GVTHR.RowCount - 1
                        Dim query As String = "CALL view_payroll_sum(" + FormBankWithdrawal.GVTHR.GetRowCellValue(i, "id_payroll").ToString + ")"

                        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                        Dim note As String = execute_query("SELECT payroll_type FROM tb_emp_payroll_type WHERE id_payroll_type = (SELECT id_payroll_type FROM tb_emp_payroll WHERE id_payroll = " + FormBankWithdrawal.GVTHR.GetRowCellValue(i, "id_payroll").ToString + ")", 0, True, "", "", "", "")

                        me_note = note.Replace("Daily Worker", "").Trim

                        For j = 0 To data.Rows.Count - 1
                            For k = 0 To data_map.Rows.Count - 1
                                If data.Rows(j)("is_store").ToString = "2" Then
                                    If data.Rows(j)("id_departement").ToString = data_map.Rows(k)("id_departement").ToString Then
                                        Dim id_acc As Integer = data_map.Rows(k)("id_acc")
                                        Dim acc_name As String = data_map.Rows(k)("acc_name").ToString
                                        Dim acc_description As String = data_map.Rows(k)("acc_description").ToString
                                        Dim vendor As String = data_map.Rows(k)("vendor").ToString
                                        Dim id_comp As Integer = data_map.Rows(k)("id_comp")
                                        Dim comp_number As String = data_map.Rows(k)("comp_number").ToString
                                        Dim balance As Decimal = data.Rows(j)("salary")

                                        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                                        newRow("id_report") = FormBankWithdrawal.GVTHR.GetRowCellValue(i, "id_payroll").ToString
                                        newRow("report_mark_type") = "192"
                                        newRow("id_acc") = id_acc
                                        newRow("acc_name") = acc_name
                                        newRow("acc_description") = acc_description
                                        newRow("vendor") = vendor
                                        newRow("id_dc") = "1"
                                        newRow("dc_code") = "D"
                                        newRow("id_comp") = id_comp
                                        newRow("comp_number") = comp_number
                                        newRow("number") = FormBankWithdrawal.GVTHR.GetRowCellValue(i, "report_number").ToString
                                        newRow("total_pay") = 0
                                        newRow("value") = balance
                                        newRow("kurs") = 0
                                        newRow("id_currency") = "1"
                                        newRow("val_bef_kurs") = 0
                                        newRow("value_view") = balance
                                        newRow("balance_due") = balance
                                        newRow("note") = note
                                        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)

                                        Exit For
                                    End If
                                End If
                            Next
                        Next
                    Next

                    MENote.Text = me_note

                    calculate_amount()
                End If
            End If
        Else
            PCAddDel.Visible = False
            '
            BtnPrint.Visible = True
            BMark.Visible = True
            BtnSave.Visible = False
            SLEPayFrom.Enabled = False
            MENote.Enabled = False
            '
            Dim query As String = "SELECT * FROM tb_pn WHERE id_pn='" & id_payment & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TEPayNumber.Text = data.Rows(0)("number").ToString
                TEKurs.EditValue = data.Rows(0)("kurs")
                report_mark_type = data.Rows(0)("report_mark_type").ToString
                SLEVendor.EditValue = data.Rows(0)("id_comp_contact").ToString
                SLEPayType.EditValue = data.Rows(0)("id_pay_type").ToString
                SLEReportType.EditValue = data.Rows(0)("report_mark_type").ToString
                '
                If data.Rows(0)("id_report_status").ToString = "6" Then
                    BtnViewJournal.Visible = True
                Else
                    BtnViewJournal.Visible = False
                End If
                '
                DEDateCreated.EditValue = data.Rows(0)("date_created")
                SLEPayFrom.EditValue = data.Rows(0)("id_acc_payfrom").ToString
                MENote.EditValue = data.Rows(0)("note").ToString
            End If
            '
            load_det()
            GridColumnPayment.OptionsColumn.AllowEdit = False
            GridColumnNote.OptionsColumn.AllowEdit = False
        End If
    End Sub

    Private Sub XTCBBM_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCBBK.SelectedPageChanged
        If XTCBBK.SelectedTabPageIndex = 1 Then
            viewBlankJournal()
            viewDraftJournal()
        End If
    End Sub

    Sub viewBlankJournal()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `no`, '' AS acc_name, '' AS acc_description, '' AS `cc`, '' AS report_number, '' AS note, 0.00 AS `debit`, 0.00 AS `credit` "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDraft.DataSource = data
        GVDraft.DeleteSelectedRows()
        GVDraft.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDraftJournal()
        Cursor = Cursors.WaitCursor
        If GVList.RowCount > 0 Then
            makeSafeGV(GVList)
            Dim jum_row As Integer = 0

            'header
            jum_row += 1
            Dim qh As String = "SELECT * FROM tb_a_acc WHERE id_acc='" + SLEPayFrom.EditValue.ToString + "' "
            Dim dh As DataTable = execute_query(qh, -1, True, "", "", "", "")
            Dim newRowh As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
            newRowh("no") = jum_row
            newRowh("acc_name") = dh.Rows(0)("acc_name").ToString
            newRowh("acc_description") = dh.Rows(0)("acc_description").ToString
            newRowh("cc") = "000"
            newRowh("report_number") = ""
            newRowh("note") = MENote.Text
            newRowh("debit") = 0
            newRowh("credit") = TETotal.EditValue
            TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowh)
            GCDraft.RefreshDataSource()
            GVDraft.RefreshData()

            'detil
            For i As Integer = 0 To GVList.RowCount - 1
                jum_row += 1
                Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                newRow("no") = jum_row
                newRow("acc_name") = GVList.GetRowCellValue(i, "acc_name").ToString
                newRow("acc_description") = GVList.GetRowCellValue(i, "acc_description").ToString
                newRow("cc") = GVList.GetRowCellValue(i, "comp_number").ToString
                newRow("report_number") = GVList.GetRowCellValue(i, "number").ToString
                newRow("note") = GVList.GetRowCellValue(i, "note").ToString
                If GVList.GetRowCellValue(i, "id_dc").ToString = "1" Then
                    newRow("debit") = Math.Abs(GVList.GetRowCellValue(i, "value"))
                    newRow("credit") = 0
                Else
                    newRow("debit") = 0
                    newRow("credit") = Math.Abs(GVList.GetRowCellValue(i, "value"))
                End If
                TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                GCDraft.RefreshDataSource()
                GVDraft.RefreshData()
            Next
            GVDraft.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormBankWithdrawalDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Sub load_det()
        Dim query As String = ""
        'If report_mark_type = "139" Then
        '    query = "SELECT pyd.*,po.purc_order_number as number FROM tb_payment_det pyd INNER JOIN tb_purc_order po ON po.id_purc_order=pyd.id_report WHERE pyd.id_payment='" & id_payment & "'"
        'ElseIf report_mark_type = "157" Then
        '    query = "SELECT pyd.*,e.number AS `number` FROM tb_payment_det pyd INNER JOIN tb_item_expense e ON e.id_item_expense=pyd.id_report WHERE pyd.id_payment='" + id_payment + "'"
        'ElseIf report_mark_type = "189" Then
        '    query = "SELECT pyd.*,po.number as number FROM tb_payment_det pyd INNER JOIN tb_pn_fgpo po ON po.id_pn_fgpo=pyd.id_report WHERE pyd.id_payment='" & id_payment & "'"
        'End If

        query = "SELECT ''AS `no`,pnd.id_pn_det,pnd.id_report,pnd.report_mark_type,comp.comp_number,pnd.number,pnd.vendor
,pnd.id_comp,pnd.id_acc,dc.dc_code,acc.acc_name,acc.acc_description,pnd.id_dc,pnd.total_pay,pnd.value,pnd.value AS value_view,pnd.balance_due,pnd.note
,pnd.id_currency,pnd.val_bef_kurs,pnd.kurs
FROM tb_pn_det pnd
INNER JOIN tb_a_acc acc ON acc.id_acc=pnd.id_acc
INNER JOIN tb_m_comp comp ON comp.id_comp=pnd.id_comp
INNER JOIN tb_lookup_dc dc ON dc.id_dc=pnd.id_dc
WHERE pnd.id_pn='" & id_payment & "'"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        calculate_amount()
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name 
                                FROM tb_m_comp c
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'"
        viewSearchLookupQuery(SLEVendor, query, "id_comp_contact", "comp_name", "id_comp_contact")
    End Sub

    Sub load_pay_from()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub load_trans_type()
        Dim query As String = "SELECT id_pay_type,pay_type FROM tb_lookup_pay_type"
        viewSearchLookupQuery(SLEPayType, query, "id_pay_type", "pay_type", "id_pay_type")
    End Sub

    Sub load_report_type()
        Dim query As String = "SELECT report_mark_type,report_mark_type_name FROM `tb_lookup_report_mark_type` WHERE is_payable='1'"
        viewSearchLookupQuery(SLEReportType, query, "report_mark_type", "report_mark_type_name", "report_mark_type")
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportBankWithdrawal.id_withdrawal = id_payment
        ReportBankWithdrawal.dt = GCList.DataSource
        Dim Report As New ReportBankWithdrawal()
        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVList)

        'Parse val
        Dim query As String = "SELECT py.number,acc.acc_description as acc_payfrom,py.`id_report_status`,sts.report_status,emp.employee_name AS created_by, DATE_FORMAT(py.date_created,'%d %M %Y') as date_created, py.`id_pn`,FORMAT(py.`value`,2,'id_ID') as total_amount,CONCAT(c.`comp_number`,' - ',c.`comp_name`) AS comp_name,rm.`report_mark_type_name`,pt.`pay_type`,py.note
FROM tb_pn py
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=py.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN `tb_lookup_report_mark_type` rm ON rm.`report_mark_type`=py.`report_mark_type`
INNER JOIN `tb_lookup_pay_type` pt ON pt.`id_pay_type`=py.`id_pay_type`
INNER JOIN tb_m_user usr ON usr.id_user=py.id_user_created
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=py.id_report_status
INNER JOIN tb_a_acc acc ON acc.id_acc=py.id_acc_payfrom
WHERE py.`id_pn`='" & id_payment & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Report.DataSource = data

        If Not data.Rows(0)("id_report_status").ToString = "6" Then
            Report.id_pre = "2"
        Else
            Report.id_pre = "1"
        End If

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub calculate_amount()
        GVList.RefreshData()
        Dim gross_total As Double = 0.0
        Try
            gross_total = Double.Parse(GVList.Columns("value").SummaryItem.SummaryValue.ToString)
        Catch ex As Exception
        End Try

        TETotal.EditValue = gross_total
        '
        GVList.BestFitColumns()
    End Sub

    Private Sub GVList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVList.CellValueChanged
        If e.Column.FieldName.ToString = "value" Then
            'set value
            calculate_amount()
        ElseIf e.Column.FieldName.ToString = "value_view" Then
            Dim rh As Integer = e.RowHandle
            Dim val As Decimal = 0
            Dim id_dc As String = GVList.GetRowCellValue(rh, "id_dc").ToString
            If id_dc = "2" Then 'credit
                val = e.Value * -1
            Else
                val = e.Value
            End If
            GVList.SetRowCellValue(rh, "value", val)
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If id_payment = "-1" Then
            'cek value 0
            Dim value_is_zero As Boolean = False
            For i As Integer = 0 To GVList.RowCount - 1
                If GVList.GetRowCellValue(i, "value") = 0 Then
                    value_is_zero = True
                End If
            Next
            'cek paid no exceed balance
            Dim paid_more As Boolean = False
            For i As Integer = 0 To GVList.RowCount - 1
                If GVList.GetRowCellValue(i, "value") > GVList.GetRowCellValue(i, "balance_due") Then
                    paid_more = True
                End If
            Next
            '
            If GVList.RowCount = 0 Then
                warningCustom("No item listed.")
            ElseIf value_is_zero = True Then
                warningCustom("You must fill value.")
            ElseIf paid_more = True Then
                warningCustom("You pay more than balance due.")
            Else
                'header
                Dim query As String = "INSERT INTO tb_pn(report_mark_type,kurs,id_acc_payfrom,id_comp_contact,id_pay_type,id_user_created,date_created,value,note,id_report_status) 
VALUES('" & report_mark_type & "','" & Decimal.Parse(TEKurs.EditValue.ToString) & "','" & SLEPayFrom.EditValue.ToString & "','" & SLEVendor.EditValue.ToString & "','" & SLEPayType.EditValue.ToString & "','" & id_user & "',NOW(),'" & decimalSQL(TETotal.EditValue.ToString) & "','" & addSlashes(MENote.Text) & "','1'); SELECT LAST_INSERT_ID(); "
                id_payment = execute_query(query, 0, True, "", "", "", "")
                'detail
                Dim id_currency, kurs, val_bef_kurs As String
                id_currency = "1"
                kurs = "0"
                val_bef_kurs = "0"

                query = "INSERT INTO tb_pn_det(id_pn,id_report,report_mark_type,number,vendor,id_comp,id_acc,id_dc,total_pay,value,id_currency,kurs,val_bef_kurs,balance_due,note) VALUES"
                For i As Integer = 0 To GVList.RowCount - 1
                    If Not i = 0 Then
                        query += ","
                    End If
                    '
                    If GVList.GetRowCellValue(i, "id_currency").ToString = "" Or GVList.GetRowCellValue(i, "id_currency").ToString = "0" Then
                        id_currency = "1"
                    Else
                        id_currency = GVList.GetRowCellValue(i, "id_currency").ToString
                    End If
                    If GVList.GetRowCellValue(i, "kurs").ToString = "" Or GVList.GetRowCellValue(i, "kurs") = 0 Then
                        kurs = "0"
                    Else
                        kurs = decimalSQL(GVList.GetRowCellValue(i, "kurs").ToString)
                    End If
                    If GVList.GetRowCellValue(i, "val_bef_kurs").ToString = "" Or GVList.GetRowCellValue(i, "val_bef_kurs") = 0 Then
                        val_bef_kurs = "0"
                    Else
                        val_bef_kurs = decimalSQL(GVList.GetRowCellValue(i, "val_bef_kurs").ToString)
                    End If

                    query += "('" & id_payment & "','" & GVList.GetRowCellValue(i, "id_report").ToString & "','" & GVList.GetRowCellValue(i, "report_mark_type").ToString & "','" & GVList.GetRowCellValue(i, "number").ToString & "','" & GVList.GetRowCellValue(i, "vendor").ToString & "','" & GVList.GetRowCellValue(i, "id_comp").ToString & "','" & GVList.GetRowCellValue(i, "id_acc").ToString & "','" & GVList.GetRowCellValue(i, "id_dc").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "total_pay").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "value").ToString) & "','" & id_currency & "','" & kurs & "','" & val_bef_kurs & "','" & decimalSQL(GVList.GetRowCellValue(i, "balance_due").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "')"
                Next
                execute_non_query(query, True, "", "", "", "")
                'generate number
                query = "CALL gen_number('" & id_payment & "','159')"
                execute_non_query(query, True, "", "", "", "")
                'add journal + mark
                submit_who_prepared("159", id_payment, id_user)

                'done
                infoCustom("Payment created")
                If FormBankWithdrawal.XTCPO.SelectedTabPageIndex = 1 Then
                    FormBankWithdrawal.load_po()
                ElseIf FormBankWithdrawal.XTCPO.SelectedTabPageIndex = 2 Then
                    FormBankWithdrawal.load_expense()
                End If

                FormBankWithdrawal.load_payment()
                FormBankWithdrawal.GVList.FocusedRowHandle = find_row(FormBankWithdrawal.GVList, "id_pn", id_payment)
                FormBankWithdrawal.XTCPO.SelectedTabPageIndex = 0
                Close()
            End If
        End If
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=159 AND ad.id_report=" + id_payment + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "159"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_payment
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If GVList.RowCount > 0 And GVList.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this detail ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVList.DeleteSelectedRows()
                GCList.RefreshDataSource()
                GVList.RefreshData()
                calculate_amount()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub GVList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If id_payment = "-1" Then
            FormBankWithdrawalAdd.action = "ins"
            FormBankWithdrawalAdd.ShowDialog()
        End If
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        If id_payment = "-1" And GVList.FocusedRowHandle >= 0 Then
            If GVList.GetFocusedRowCellValue("id_report") = "0" Then
                Cursor = Cursors.WaitCursor
                FormBankWithdrawalAdd.action = "upd"
                FormBankWithdrawalAdd.ShowDialog()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BGenerateSelisihKurs_Click(sender As Object, e As EventArgs)
        Dim id_pn As String = ""
        For i As Integer = 0 To GVList.RowCount - 1
            If GVList.GetRowCellValue(i, "report_mark_type").ToString = "189" Then
                If Not i = 0 Then
                    id_pn = ","
                End If
                id_pn += GVList.GetRowCellValue(i, "id_report").ToString
            End If
        Next

        Dim query As String = ""

        'Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
        'newRow("id_report") = "0"
        'newRow("report_mark_type") = "0"

        'newRow("id_acc") = SLECOA.EditValue.ToString
        'newRow("vendor") = TxtSupplier.Text

        'newRow("id_comp") = "1"
        'newRow("comp_number") = "000"

        'newRow("acc_name") = TxtCOA.Text
        'newRow("acc_description") = SLECOA.Text
        'newRow("number") = addSlashes(TxtReff.Text)
        'newRow("total_pay") = 0

        'If LEDK.EditValue.ToString = "2" Then
        '    newRow("value") = TxtAmount.EditValue * -1
        '    newRow("balance_due") = TxtAmount.EditValue * -1
        'Else
        '    newRow("value") = TxtAmount.EditValue
        '    newRow("balance_due") = TxtAmount.EditValue
        'End If

        'newRow("note") = addSlashes(TxtDescription.Text)
        'newRow("id_dc") = LEDK.EditValue.ToString
        'newRow("dc_code") = LEDK.Text
        'newRow("value_view") = TxtAmount.EditValue
        'TryCast(FormBankWithdrawalDet.GCList.DataSource, DataTable).Rows.Add(newRow)
        'FormBankWithdrawalDet.GCList.RefreshDataSource()
        'FormBankWithdrawalDet.GVList.RefreshData()
        'FormBankWithdrawalDet.calculate_amount()
        'actionLoad()
    End Sub
End Class