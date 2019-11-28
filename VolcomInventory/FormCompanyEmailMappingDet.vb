﻿Public Class FormCompanyEmailMappingDet
    Public tab As String = ""

    Public id As String = "0"

    Private Sub FormCompanyEmailMappingDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'generate type
        Dim location As Integer = 0

        Dim report_mark_types As DataTable = execute_query("SELECT report_mark_type, report_mark_type_name FROM tb_lookup_report_mark_type WHERE is_mail_acc = 1", -1, True, "", "", "", "")

        Dim i As Integer = 0

        For i = 0 To report_mark_types.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.CheckEdit = New DevExpress.XtraEditors.CheckEdit

            c.Text = report_mark_types.Rows(i)("report_mark_type_name").ToString
            c.Name = "CheckEdit" + report_mark_types.Rows(i)("report_mark_type").ToString
            c.CheckState = CheckState.Unchecked
            c.Size = New Size(400, 19)
            c.Location = New Point(20, location)

            PCCheck.Controls.Add(c)

            location = location + 25
        Next

        Size = New Size(550, Size.Height + (i * 19))

        'tab
        Dim query_name As String = ""

        If tab = "store_group" Then
            LCName.Text = "Store Group"
            query_name = "SELECT id_comp_group AS id, comp_group AS `name`, description AS detail, CONCAT(comp_group, ' | ', description) AS description FROM tb_m_comp_group WHERE id_comp IS NOT NULL"
            GridColumnVName.Caption = "Store Group"
            GridColumnVDetail.Caption = "Description"
        Else
            LCName.Text = "Employee"
            query_name = "
                SELECT usr.id_user AS id, emp.employee_code AS `name`, CONCAT(emp.employee_name, ' | ', emp.email_external) AS detail, CONCAT(emp.employee_code, ' | ', emp.employee_name, ' | ', emp.email_external) AS description
                FROM tb_m_user AS usr
                LEFT JOIN tb_m_employee AS emp ON usr.id_employee = emp.id_employee
                WHERE emp.id_employee_active = 1
            "
            GridColumnVName.Caption = "Code"
            GridColumnVDetail.Caption = "Name"
            LCContact.Visible = False
            SLUEContact.Visible = False
            LCType.Location = New Point(21, 50)
            SLUEType.Location = New Point(106, 49)
            PCDetail.Size = New Size(534, PCDetail.Size.Height - 25)
            Size = New Size(550, Size.Height - 25)
        End If

        viewSearchLookupQuery(SLUEName, query_name, "id", "description", "id")
        viewSearchLookupQuery(SLUEType, "SELECT id_mail_member_type, mail_member_type FROM tb_lookup_mail_member_type", "id_mail_member_type", "mail_member_type", "id_mail_member_type")
    End Sub

    Private Sub FormCompanyEmailMappingDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormCompanyEmailMapping.form_load()

        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SLUEName_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEName.EditValueChanged
        viewSearchLookupQuery(SLUEContact, "SELECT id_comp_contact, contact_person, position, email, CONCAT(contact_person, ' | ', IFNULL(position, '-'), ' | ', IFNULL(email, '-')) AS description FROM tb_m_comp_contact WHERE id_comp = (SELECT id_comp FROM tb_m_comp_group WHERE id_comp_group = " + SLUEName.EditValue.ToString + ")", "id_comp_contact", "description", "id_comp_contact")
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        If tab = "store_group" Then
            If Not SLUEContact.EditValue Is Nothing Then
                For i = 0 To PCCheck.Controls.Count - 1
                    Dim c As DevExpress.XtraEditors.CheckEdit = CType(PCCheck.Controls.Item(i), DevExpress.XtraEditors.CheckEdit)

                    If c.EditValue Then
                        Dim query As String = "INSERT INTO tb_mail_manage_mapping (id_comp_group, id_comp_contact, report_mark_type, id_mail_member_type) VALUES (" + SLUEName.EditValue.ToString + ", " + SLUEContact.EditValue.ToString + ", " + c.Name.ToString.Replace("CheckEdit", "") + ", " + SLUEType.EditValue.ToString + ")"

                        execute_non_query(query, True, "", "", "", "")
                    End If
                Next

                Close()
            Else
                errorCustom("Contact cannot be blank.")
            End If
        Else
            For i = 0 To PCCheck.Controls.Count - 1
                Dim c As DevExpress.XtraEditors.CheckEdit = CType(PCCheck.Controls.Item(i), DevExpress.XtraEditors.CheckEdit)

                If c.EditValue Then
                    Dim query As String = "INSERT INTO tb_mail_manage_mapping_intern (id_user, report_mark_type, id_mail_member_type) VALUES (" + SLUEName.EditValue.ToString + ", " + c.Name.ToString.Replace("CheckEdit", "") + ", " + SLUEType.EditValue.ToString + ")"

                    execute_non_query(query, True, "", "", "", "")
                End If
            Next

            Close()
        End If
    End Sub
End Class