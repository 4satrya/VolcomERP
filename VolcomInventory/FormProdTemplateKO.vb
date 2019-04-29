Public Class FormProdTemplateKO
    Private Sub FormProdTemplateKO_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormProdTemplateKO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_template()
    End Sub

    Sub load_template()
        Dim query As String = "SELECT ko.`id_ko_template`,ko.`date_created`,ko.`description`,ko.`last_upd`,ko.`year`,emp.`employee_name` FROM `tb_ko_template` ko
INNER JOIN tb_m_user usr ON ko.`last_upd_by`=usr.`id_user`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCKOHead.DataSource = data
        GVKOHead.BestFitColumns()
        If GVKOHead.RowCount > 0 Then
            load_content()
            check_but()
        End If
    End Sub

    Sub load_content()
        Dim query As String = "SELECT upper_part,bottom_part FROM tb_ko_template WHERE id_ko_template='" & GVKOHead.GetFocusedRowCellValue("id_ko_template").ToString & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Try
            REUpperPart.RtfText = data.Rows(0)("upper_part").ToString
            REBottomPart.RtfText = data.Rows(0)("bottom_part").ToString
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try

    End Sub

    Sub check_but()
        If GVKOHead.RowCount > 0 Then
            BDelHead.Visible = True
            BEditHead.Visible = True
        Else
            BDelHead.Visible = False
            BEditHead.Visible = False
        End If
        '
    End Sub

    Private Sub GVKOHead_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVKOHead.FocusedRowChanged
        load_content()
    End Sub

    Private Sub BDelHead_Click(sender As Object, e As EventArgs) Handles BDelHead.Click
        'check on company and FGPO
        Dim query_check As String = "SELECT id_ko_template FROM tb_prod_order WHERE id_ko_template = '" & GVKOHead.GetFocusedRowCellValue("id_ko_template").ToStrings & "' 
UNION
SELECT id_ko_template FROM tb_m_comp WHERE id_ko_template= '" & GVKOHead.GetFocusedRowCellValue("id_ko_template").ToStrings & "'"
        Dim data As DataTable = execute_query(query_check, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            stopCustom("This template already used")
        Else
            'delete
            Dim query As String = "DELETE FROM tb_ko_template WHERE id_ko_template = '" & GVKOHead.GetFocusedRowCellValue("id_ko_template").ToStrings & "'"
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Template deleted")
            load_template()
        End If
    End Sub

    Private Sub BEditHead_Click(sender As Object, e As EventArgs) Handles BEditHead.Click
        'check on company and FGPO
        Dim query_check As String = "SELECT id_ko_template FROM tb_prod_order WHERE id_ko_template = '" & GVKOHead.GetFocusedRowCellValue("id_ko_template").ToString & "' 
UNION
SELECT id_ko_template FROM tb_m_comp WHERE id_ko_template= '" & GVKOHead.GetFocusedRowCellValue("id_ko_template").ToStrings & "'"
        Dim data As DataTable = execute_query(query_check, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            stopCustom("This template already used")
        Else
            FormProdTemplateKOHead.id_template = GVKOHead.GetFocusedRowCellValue("id_ko_template").ToStrings
            FormProdTemplateKOHead.ShowDialog()
        End If
    End Sub

    Private Sub BAddHead_Click(sender As Object, e As EventArgs) Handles BAddHead.Click
        FormProdTemplateKOHead.id_template = "-1"
        FormProdTemplateKOHead.ShowDialog()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim query As String = String.Format("UPDATE tb_ko_template SET upper_part='{0}',bottom_part='{2}' WHERE id_ko_template = '{1}'", addSlashes(REUpperPart.RtfText.ToString), GVKOHead.GetFocusedRowCellValue("id_ko_template").ToString, addSlashes(REBottomPart.RtfText.ToString))
        execute_non_query(query, True, "", "", "", "")
    End Sub
End Class