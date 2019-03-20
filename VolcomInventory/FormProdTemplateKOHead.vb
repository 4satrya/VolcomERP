Public Class FormProdTemplateKOHead
    Public id_template As String = "-1"

    Private Sub FormProdTemplateKOHead_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEYearBudget.EditValue = Now
        DEActiveUntil.EditValue = Now

        If id_template = "-1" Then 'new

        Else 'edit
            Dim query As String = "SELECT ko.`id_ko_template`,ko.`date_created`,ko.`description`,ko.`last_upd`,ko.`year`,ko.active_until FROM `tb_ko_template` WHERE ko.id_ko_template='" & id_template & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TEDescription.Text = data.Rows(0)("description")
                DEYearBudget.EditValue = data.Rows(0)("year")
                DEActiveUntil.EditValue = data.Rows(0)("active_until")
            End If
        End If
    End Sub

    Private Sub FormProdTemplateKOHead_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If id_template = "-1" Then 'new
            Dim query_ins As String = "INSERT INTO tb_ko_template(`date_created`,`description`,`last_upd`,`last_upd_by`,`year`,active_until) 
VALUES(NOW(),'" & addSlashes(TEDescription.Text) & "',NOW(),'" & id_user & "','" & Date.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy") & "','" & Date.Parse(DEActiveUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "'); SELECT LAST_INSERT_ID(); "
            id_template = execute_query(query_ins, 0, True, "", "", "", "")
            infoCustom("Template created")
            '
            FormProdTemplateKO.load_template()
            FormProdTemplateKO.GVKOHead.FocusedRowHandle = find_row(FormProdTemplateKO.GVKOHead, "id_ko_template", id_template)
            '
            Close()
        Else
            Dim query_upd As String = "UPDATE tb_ko_template SET `description`='" & addSlashes(TEDescription.Text) & "',`last_upd`=NOW(),`last_upd_by`='" & id_user & "',`year`='" & Date.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy") & "',active_until='" & Date.Parse(DEActiveUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "' WHERE id_ko_template='" & id_template & "'"
            execute_non_query(query_upd, True, "", "", "", "")
            infoCustom("Template updated")
            '
            FormProdTemplateKO.load_template()
            FormProdTemplateKO.GVKOHead.FocusedRowHandle = find_row(FormProdTemplateKO.GVKOHead, "id_ko_template", id_template)
            '
            Close()
        End If
    End Sub
End Class