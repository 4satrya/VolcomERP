Public Class FormAccountingWorksheet
    Private Sub FormAccountingWorksheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = Now
        DETo.EditValue = Now

        DETo.Properties.MinValue = Now

        load_unit()

        view_acc_from()

        view_acc_to()
    End Sub

    Private Sub FormAccountingWorksheet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormAccountingWorksheet_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormAccountingWorksheet_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub view_form()
        Cursor = Cursors.WaitCursor

        'clear datasource
        GCAccountingWorksheet.DataSource = Nothing
        '
        Dim where_coa_type As String = ""

        If SLEUnit.EditValue.ToString = "0" Then
            where_coa_type = ""
        ElseIf SLEUnit.EditValue.ToString = "1" Then
            where_coa_type = " id_coa_type = 1 AND "
        Else
            where_coa_type = " id_coa_type = 2 AND "
        End If

        Dim is_char As Boolean = False

        For i = 0 To SLUEFrom.EditValue.ToString.Length - 1
            If Char.IsLetter(SLUEFrom.EditValue.ToString.Chars(i)) Then
                is_char = True
            End If
        Next

        Dim acc_name As String = ""

        If is_char Then
            acc_name += "acc.acc_name LIKE \'" + SLUEFrom.EditValue.ToString + "\'"
        Else
            Dim acc_range As DataTable = execute_query("SELECT acc_name FROM tb_a_acc WHERE " & where_coa_type & " CAST(acc_name AS UNSIGNED) >= " + SLUEFrom.EditValue.ToString + " AND CAST(acc_name AS UNSIGNED) <= " + SLUETo.EditValue.ToString + "", -1, True, "", "", "", "")

            For i = 0 To acc_range.Rows.Count - 1
                acc_name += "acc.acc_name LIKE \'" + acc_range.Rows(i)("acc_name").ToString + "%\' OR "
            Next

            acc_name = "(" + acc_name.Substring(0, acc_name.Length - 4) + ")"
        End If

        Dim query As String = "CALL view_acc_worksheet('" + Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + Date.Parse(DETo.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + acc_name + "', '" + SLEUnit.EditValue.ToString + "')"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'parent
        Dim query_parent As String = "SELECT id_acc, id_acc_parent, acc_name, acc_description FROM tb_a_acc WHERE " & where_coa_type & " CHAR_LENGTH(acc_name) IN (2, 4) ORDER BY acc_name ASC"

        Dim data_parent As DataTable = execute_query(query_parent, -1, True, "", "", "", "")

        'insert parent
        For i = 0 To data.Rows.Count - 1
            For j = 0 To data_parent.Rows.Count - 1
                'parent 1
                If data_parent.Rows(j)("acc_name").ToString.Length = 2 Then
                    If data.Rows(i)("acc_name").ToString.Substring(0, 2) = data_parent.Rows(j)("acc_name").ToString Then
                        data.Rows(i)("acc_name_1") = data_parent.Rows(j)("acc_name").ToString + " - " + data_parent.Rows(j)("acc_description").ToString
                    End If
                End If

                'parent 2
                If data_parent.Rows(j)("acc_name").ToString.Length = 4 Then
                    If data.Rows(i)("acc_name").ToString.Substring(0, 4) = data_parent.Rows(j)("acc_name").ToString Then
                        data.Rows(i)("acc_name_2") = data_parent.Rows(j)("acc_name").ToString + " - " + data_parent.Rows(j)("acc_description").ToString
                    End If
                End If
            Next
        Next

        'numbering
        Dim number As Integer = 1
        Dim last_parent_2 As String = ""

        For i = 0 To data.Rows.Count - 1
            If Not last_parent_2 = data.Rows(i)("acc_name_2").ToString Then
                number = 1
            End If

            If i = 0 Then
                last_parent_2 = data.Rows(i)("acc_name_2").ToString
            End If

            data.Rows(i)("number") = number

            last_parent_2 = data.Rows(i)("acc_name_2").ToString

            number = number + 1
        Next

        GCAccountingWorksheet.DataSource = data

        GVAccountingWorksheet.BestFitColumns()

        Cursor = Cursors.Default
    End Sub

    Sub print_form()
        Try
            Dim report As ReportAccountingWorksheet = New ReportAccountingWorksheet

            report.data = GCAccountingWorksheet.DataSource

            report.XLPeriod.Text = DEFrom.Text + " - " + DETo.Text
            report.XLAccount.Text = SLUEFrom.Text + " - " + SLUETo.Text
            report.LUnit.Text = SLEUnit.Text

            Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

            tool.ShowPreview()
        Catch ex As Exception
        End Try
    End Sub

    Sub view_acc_from()
        Dim where_coa_type As String = ""

        If SLEUnit.EditValue.ToString = "0" Then
            where_coa_type = ""
        ElseIf SLEUnit.EditValue.ToString = "1" Then
            where_coa_type = " WHERE id_coa_type = 1 "
        Else
            where_coa_type = " WHERE id_coa_type = 2 "
        End If

        viewSearchLookupQuery(SLUEFrom, "SELECT acc_name, acc_description, CONCAT(acc_name, ' - ', acc_description) AS acc_name_description FROM tb_a_acc " & where_coa_type & " ORDER BY acc_name ASC", "acc_name", "acc_name_description", "acc_name")
    End Sub

    Sub view_acc_to()
        Try
            Dim is_char As Boolean = False

            For i = 0 To SLUEFrom.EditValue.ToString.Length - 1
                If Char.IsLetter(SLUEFrom.EditValue.ToString.Chars(i)) Then
                    is_char = True
                End If
            Next

            Dim where_coa_type As String = ""

            If SLEUnit.EditValue.ToString = "0" Then
                where_coa_type = ""
            ElseIf SLEUnit.EditValue.ToString = "1" Then
                where_coa_type = " id_coa_type = 1 AND "
            Else
                where_coa_type = " id_coa_type = 2 AND "
            End If

            If is_char Then
                viewSearchLookupQuery(SLUETo, "SELECT acc_name, acc_description, CONCAT(acc_name, ' - ', acc_description) AS acc_name_description FROM tb_a_acc WHERE " & where_coa_type & " acc_name = '" + SLUEFrom.EditValue.ToString + "'", "acc_name", "acc_name_description", "acc_name")
            Else
                viewSearchLookupQuery(SLUETo, "SELECT acc_name, acc_description, CONCAT(acc_name, ' - ', acc_description) AS acc_name_description FROM tb_a_acc WHERE " & where_coa_type & " CAST(acc_name AS UNSIGNED) >= " + SLUEFrom.EditValue.ToString + " AND CHAR_LENGTH(acc_name) = " + SLUEFrom.EditValue.ToString.Length.ToString + " ORDER BY acc_name ASC", "acc_name", "acc_name_description", "acc_name")
            End If
        Catch ex As Exception
            SLUETo.Properties.DataSource = Nothing
        End Try
    End Sub

    Private Sub SLUEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEFrom.EditValueChanged
        view_acc_to()
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        If Not SLUEFrom.EditValue Is Nothing Then
            view_form()
        Else
            stopCustom("Please select account.")
        End If
    End Sub

    Private Sub GVAccountingLedger_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVAccountingWorksheet.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "acc_name" Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                e.TotalValue = "Sub Total: " + GVAccountingWorksheet.GetGroupRowDisplayText(e.GroupRowHandle).Replace("Account", "")
            End If
        End If
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        DETo.Properties.MinValue = DEFrom.EditValue
    End Sub

    Sub load_unit()
        Dim query As String = "SELECT 0 AS id_coa_tag,'ALL' AS tag_code,'ALL' AS tag_description 
UNION ALL
SELECT id_coa_tag,tag_code,tag_description FROM `tb_coa_tag`"
        '        query = "SELECT '0' AS id_comp,'-' AS comp_number, 'All Unit' AS comp_name
        'UNION ALL
        'SELECT ad.`id_comp`,c.`comp_number`,c.`comp_name` FROM `tb_a_acc_trans_det` ad
        'INNER JOIN tb_m_comp c ON c.`id_comp`=ad.`id_comp`
        'GROUP BY ad.id_comp"
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
        SLEUnit.EditValue = "1"
    End Sub

    Private Sub SLUEType_EditValueChanged(sender As Object, e As EventArgs)
        view_acc_from()

        view_acc_to()
    End Sub

    Private Sub SLEUnit_EditValueChanged(sender As Object, e As EventArgs) Handles SLEUnit.EditValueChanged
        Try
            view_acc_from()
            view_acc_to()
        Catch ex As Exception
        End Try
    End Sub
End Class