﻿Public Class FormOutlet
    Private Sub FormOutlet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT sc.id_store_conn, sc.id_outlet, sc.outlet_name AS `outlet`, sc.host, sc.username, sc.pass, sc.db 
        FROM tb_store_conn sc "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOutlet.DataSource = data
    End Sub

    Private Sub CloneCompanyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloneCompanyToolStripMenuItem.Click
        FormPopUpContact.id_pop_up = "73"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub CloneEmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloneEmployeeToolStripMenuItem.Click
        FormMasterEmployee.BAccept.Visible = False
        FormMasterEmployee.PanelControl1.Visible = False
        FormMasterEmployee.BClone.Visible = True
        FormMasterEmployee.ShowDialog()
    End Sub
End Class