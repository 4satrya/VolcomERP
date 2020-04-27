Public Class FormAccountingLedger
    Private Sub FormAccountingLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = Now
        DETo.EditValue = Now

        DETo.Properties.MinValue = Now

        viewSearchLookupQuery(SLUEFrom, "SELECT acc_name, acc_description, CONCAT(acc_name, ' - ', acc_description) AS acc_name_description FROM tb_a_acc ORDER BY acc_name ASC", "acc_name", "acc_name_description", "acc_name")

        view_acc_to()
    End Sub

    Private Sub FormAccountingLedger_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormAccountingLedger_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormAccountingLedger_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub view_form()
        Cursor = Cursors.WaitCursor

        'clear group
        GVAccountingLedger.ClearGrouping()

        'clear datasource
        GCAccountingLedger.DataSource = Nothing

        'remove column
        For i = GVAccountingLedger.Columns.Count - 1 To 0 Step -1
            If GVAccountingLedger.Columns.Item(i).FieldName.Contains("group_") Then
                GVAccountingLedger.Columns.Remove(GVAccountingLedger.Columns.Item(i))
            End If
        Next

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
            Dim acc_range As DataTable = execute_query("SELECT acc_name FROM tb_a_acc WHERE CAST(acc_name AS UNSIGNED) >= " + SLUEFrom.EditValue.ToString + " AND CAST(acc_name AS UNSIGNED) <= " + SLUETo.EditValue.ToString + "", -1, True, "", "", "", "")

            For i = 0 To acc_range.Rows.Count - 1
                acc_name += "acc.acc_name LIKE \'" + acc_range.Rows(i)("acc_name").ToString + "%\' OR "
            Next

            acc_name = "(" + acc_name.Substring(0, acc_name.Length - 4) + ")"
        End If

        Dim query As String = "CALL view_acc_ledger('" + Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + Date.Parse(DETo.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + acc_name + "')"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'last balance
        data.Columns.Add("last_balance", GetType(Decimal))

        Dim last_acc As String = data.Rows(0)("acc_name").ToString

        For i = 0 To data.Rows.Count - 1
            If Not last_acc = data.Rows(i)("acc_name").ToString Then
                data.Rows(i - 1)("last_balance") = data.Rows(i - 1)("balance")
            End If

            last_acc = data.Rows(i)("acc_name").ToString

            'last loop
            If i = data.Rows.Count - 1 Then
                data.Rows(i)("last_balance") = data.Rows(i)("balance")
            End If
        Next

        'parent
        Dim query_parent As String = "SELECT id_acc, id_acc_parent, acc_name, acc_description FROM tb_a_acc"

        Dim data_parent As DataTable = execute_query(query_parent, -1, True, "", "", "", "")

        Dim last_added As String = ""

        Dim last_g As Integer = 0

        'check is detail
        Dim id_is_det As String = execute_query("SELECT id_is_det FROM tb_a_acc WHERE acc_name = '" + SLUEFrom.EditValue.ToString + "'", 0, True, "", "", "", "")

        'single group
        If id_is_det = "2" Then
            GVAccountingLedger.Columns("acc_name").GroupIndex = 0
        Else
            'multi group
            'add column
            For g = 0 To 100
                Dim group_i As String = "group_" + g.ToString
                Dim parent_group_i As String = "parent_group_" + g.ToString

                'add column to datatable
                data.Columns.Add(group_i, GetType(String))
                data.Columns.Add(parent_group_i, GetType(String))

                'add column to gridview
                Dim col As DevExpress.XtraGrid.Columns.GridColumn = GVAccountingLedger.Columns.Add()

                col.Caption = "Account"
                col.FieldName = group_i

                For i = 0 To data.Rows.Count - 1
                    For j = 0 To data_parent.Rows.Count - 1
                        If g = 0 Then
                            If data.Rows(i)("id_acc_parent").ToString = data_parent.Rows(j)("id_acc").ToString Then
                                data.Rows(i)(group_i) = data_parent.Rows(j)("acc_name").ToString + " - " + data_parent.Rows(j)("acc_description").ToString
                                data.Rows(i)(parent_group_i) = data_parent.Rows(j)("id_acc_parent").ToString

                                last_added = data_parent.Rows(j)("acc_name").ToString
                            End If
                        Else
                            If data.Rows(i)("parent_group_" + (g - 1).ToString).ToString = data_parent.Rows(j)("id_acc").ToString Then
                                data.Rows(i)(group_i) = data_parent.Rows(j)("acc_name").ToString + " - " + data_parent.Rows(j)("acc_description").ToString
                                data.Rows(i)(parent_group_i) = data_parent.Rows(j)("id_acc_parent").ToString

                                last_added = data_parent.Rows(j)("acc_name").ToString
                            End If
                        End If
                    Next
                Next

                last_g = g

                If SLUETo.EditValue.ToString = last_added Then
                    Exit For
                End If
            Next

            'group index
            For i = last_g To 0 Step -1
                Dim group_i As String = "group_" + i.ToString

                GVAccountingLedger.Columns(group_i).GroupIndex = last_g - i
            Next

            GVAccountingLedger.Columns("acc_name").GroupIndex = last_g + 1
        End If

        GCAccountingLedger.DataSource = data

        GVAccountingLedger.BestFitColumns()

        Cursor = Cursors.Default
    End Sub

    Sub print_form()
        Try
            Dim report As ReportAccountingLedger = New ReportAccountingLedger

            report.data = GCAccountingLedger.DataSource
            report.id_is_det = execute_query("SELECT id_is_det FROM tb_a_acc WHERE acc_name = '" + SLUEFrom.EditValue.ToString + "'", 0, True, "", "", "", "")

            report.XLPeriod.Text = DEFrom.Text + " - " + DETo.Text
            report.XLAccount.Text = SLUEFrom.Text + " - " + SLUETo.Text

            Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

            tool.ShowPreview()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        view_form()
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        DETo.Properties.MinValue = DEFrom.EditValue
    End Sub

    Sub view_acc_to()
        Dim is_char As Boolean = False

        For i = 0 To SLUEFrom.EditValue.ToString.Length - 1
            If Char.IsLetter(SLUEFrom.EditValue.ToString.Chars(i)) Then
                is_char = True
            End If
        Next

        If is_char Then
            viewSearchLookupQuery(SLUETo, "SELECT acc_name, acc_description, CONCAT(acc_name, ' - ', acc_description) AS acc_name_description FROM tb_a_acc WHERE acc_name = '" + SLUEFrom.EditValue.ToString + "'", "acc_name", "acc_name_description", "acc_name")
        Else
            viewSearchLookupQuery(SLUETo, "SELECT acc_name, acc_description, CONCAT(acc_name, ' - ', acc_description) AS acc_name_description FROM tb_a_acc WHERE CAST(acc_name AS UNSIGNED) >= " + SLUEFrom.EditValue.ToString + " AND CHAR_LENGTH(acc_name) = " + SLUEFrom.EditValue.ToString.Length.ToString + " ORDER BY acc_name ASC", "acc_name", "acc_name_description", "acc_name")
        End If
    End Sub

    Private Sub SLUEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEFrom.EditValueChanged
        view_acc_to()
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor

        Try
            Dim showpopup As ClassShowPopUp = New ClassShowPopUp()

            showpopup.report_mark_type = GVAccountingLedger.GetFocusedRowCellValue("report_mark_type").ToString
            showpopup.id_report = GVAccountingLedger.GetFocusedRowCellValue("id_report").ToString
            showpopup.show()
        Catch ex As Exception
            stopCustom("Document Not Found")
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub ViewReffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewReffToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor

        Dim showpopup As ClassShowPopUp = New ClassShowPopUp()

        showpopup.report_mark_type = GVAccountingLedger.GetFocusedRowCellValue("report_mark_type_ref").ToString
        showpopup.id_report = GVAccountingLedger.GetFocusedRowCellValue("id_report_ref").ToString
        showpopup.show()

        Cursor = Cursors.Default
    End Sub

    Private Sub GVAccountingLedger_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVAccountingLedger.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "number" Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                e.TotalValue = "Sub Total" + GVAccountingLedger.GetGroupRowDisplayText(e.GroupRowHandle).Replace("Account", "")
            End If
        End If
    End Sub
End Class