Public Class FormProductionAssemblyNew
    Public id_design As String = "-1"

    Private Sub FormProductionAssemblyNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormProductionAssemblyNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub ButtonEdit1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ButtonEdit1.ButtonClick
        FormPopUpDesign.id_pop_up = "2"
        FormPopUpDesign.ShowDialog()
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create new assembly product : " + System.Environment.NewLine + ButtonEdit1.Text + " - " + TxtDesign.Text + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            'main
            Dim numberx As String = header_number_prod("13")
            Dim query As String = "INSERT INTO tb_prod_ass(prod_ass_number, prod_ass_date, id_design, prod_ass_note, id_report_status) "
            query += "VALUES('" + numberx + "', NOW(), '" + id_design + "', '', '1'); SELECT LAST_INSERT_ID(); "
            Dim id_prod_ass As String = execute_query(query, 0, True, "", "", "", "")
            increase_inc_prod("13")

            'detail
            Dim query_det As String = "INSERT INTO tb_prod_ass_det(id_prod_ass, id_product, prod_ass_det_qty, prod_ass_det_note) 
            SELECT '" + id_prod_ass + "', p.id_product,0, '' FROM tb_m_product p WHERE p.id_design=" + id_design + " "
            execute_non_query(query_det, True, "", "", "", "")
            FormProductionAssembly.viewData()

            infoCustom(numberx + " was created successfully, please input components product. ")
            Close()
            FormProductionAssemblySingle.id_prod_ass = id_prod_ass
            FormProductionAssemblySingle.action = "upd"
            FormProductionAssemblySingle.ShowDialog()
        End If
    End Sub
End Class