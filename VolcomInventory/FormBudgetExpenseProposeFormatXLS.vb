Public Class FormBudgetExpenseProposeFormatXLS
    Dim konfirmasi As Boolean = True
    Public id_dept As String = "-1"

    Private Sub FormBudgetExpenseProposeFormatXLS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        id_dept = id_departement_user
        If FormBudgetExpensePropose.is_admin = "-1" Then
            id_dept = id_departement_user
        Else
            Cursor = Cursors.WaitCursor
            FormPopUpDept.id_pop_up = "2"
            FormPopUpDept.ControlBox = False
            FormPopUpDept.ShowDialog()
            Cursor = Cursors.Default
        End If

        'load column & data
        Dim query As String = "SELECT 
        coa.acc_name AS `exp_acc`,coa.acc_description AS `exp_description`, cat.item_cat,
        NULL AS `1`,
        NULL AS `2`,
        NULL AS `3`,
        NULL AS `4`,
        NULL AS `5`,
        NULL AS `6`,
        NULL AS `7`,
        NULL AS `8`,
        NULL AS `9`,
        NULL AS `10`,
        NULL AS `11`,
        NULL AS `12`
        FROM tb_item_coa c
        INNER JOIN tb_item_cat cat ON cat.id_item_cat = c.id_item_cat
        INNER JOIN tb_a_acc coa ON coa.id_acc = c.id_coa_out
        WHERE c.id_departement=" + id_dept + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMonthly.DataSource = data
        GVMonthly.BestFitColumns()

        'export
        'save tampilan awal
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVMonthly.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'custom column
        GVMonthly.Columns("1").Caption = "1"
        GVMonthly.Columns("2").Caption = "2"
        GVMonthly.Columns("3").Caption = "3"
        GVMonthly.Columns("4").Caption = "4"
        GVMonthly.Columns("5").Caption = "5"
        GVMonthly.Columns("6").Caption = "6"
        GVMonthly.Columns("7").Caption = "7"
        GVMonthly.Columns("8").Caption = "8"
        GVMonthly.Columns("9").Caption = "9"
        GVMonthly.Columns("10").Caption = "10"
        GVMonthly.Columns("11").Caption = "11"
        GVMonthly.Columns("12").Caption = "12"
        GVMonthly.Columns("total_input").Visible = False

        'export excel
        GVMonthly.OptionsPrint.PrintFooter = False
        Dim printableComponentLink1 As New DevExpress.XtraPrinting.PrintableComponentLink(New DevExpress.XtraPrinting.PrintingSystem())
        Dim path_root As String = Application.StartupPath & "\download\"
        'create directory if not exist
        If Not IO.Directory.Exists(path_root) Then
            System.IO.Directory.CreateDirectory(path_root)
        End If
        Dim fileName As String = "formatxls_expense_budget_" + id_dept + ".xlsx"
        Dim exp As String = IO.Path.Combine(path_root, fileName)
        printableComponentLink1.Component = GCMonthly
        printableComponentLink1.CreateDocument()
        printableComponentLink1.ExportToXlsx(exp)
        If konfirmasi Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to open file?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Process.Start(exp)
            End If
        Else
            Process.Start(exp)
        End If

        'reset tampilan awal
        GVMonthly.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'exit
        Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormBudgetExpenseProposeFormatXLS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class