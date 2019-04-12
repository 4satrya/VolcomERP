Public Class FormEmpUniSuggest
    Public id_emp_uni_period As String = "-1"
    Public id_sex As String = "-1"
    Public is_dept_head As String = "-1"

    Private Sub FormEmpUniSuggest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDesignList()
        ActiveControl = TxtDesign
    End Sub

    Sub viewDesignList()
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_emp_uni_design(" + id_emp_uni_period + "," + id_sex + ", " + is_dept_head + ") "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesignList.DataSource = data
        GVDesignList.Columns("1").Caption = "1" + System.Environment.NewLine + "XXS"
        GVDesignList.Columns("2").Caption = "2" + System.Environment.NewLine + "XS"
        GVDesignList.Columns("3").Caption = "3" + System.Environment.NewLine + "S"
        GVDesignList.Columns("4").Caption = "4" + System.Environment.NewLine + "M"
        GVDesignList.Columns("5").Caption = "5" + System.Environment.NewLine + "ML"
        GVDesignList.Columns("6").Caption = "6" + System.Environment.NewLine + "L"
        GVDesignList.Columns("7").Caption = "7" + System.Environment.NewLine + "XL"
        GVDesignList.Columns("8").Caption = "8" + System.Environment.NewLine + "XXL"
        GVDesignList.Columns("9").Caption = "9" + System.Environment.NewLine + "ALL"
        GVDesignList.Columns("0").Caption = "0" + System.Environment.NewLine + "SM"
        GVDesignList.RefreshData()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        GVDesignList.ActiveFilterString = ""
        TxtDesign.Text = ""
        viewDesignList()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCDesignList, "Suggested Design")
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtDesign_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDesign.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtDesign.Text.ToString = "" Then
                GVDesignList.ActiveFilterString = ""
            Else
                GVDesignList.ActiveFilterString = "[no]='" + addSlashes(TxtDesign.Text.ToString) + "'"
            End If
        End If
    End Sub

    Private Sub FormEmpUniSuggest_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnSug_Click(sender As Object, e As EventArgs) Handles BtnSug.Click
        Cursor = Cursors.WaitCursor
        GVDesignList.ActiveFilterString = "[point]<=" + decimalSQL(FormEmpUniOrderDet.TxtDiff.EditValue.ToString) + ""
        Cursor = Cursors.Default
    End Sub
End Class