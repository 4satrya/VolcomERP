Public Class FormAccountingAcc 
    Public id_acc As String = "-1"
    Public id_parent As String = "-1"
    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormAccountingAcc_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormAccountingAcc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewParent(SLEParentAccount)
        view_acc_category(LEAccCat)
        view_active(LEActive)
        view_is_det(LEDetail)

        If id_acc = "-1" Then
            'new
            If Not id_parent = "0" And Not id_parent = "-1" Then
                SLEParentAccount.EditValue = id_parent
                TEAccount.Text = SLEParentAccount.Text
            End If
        Else
            'edit
            Dim query As String = String.Format("SELECT * FROM tb_a_acc WHERE id_acc = '{0}'", id_acc)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            Dim acc_name As String = ""

            id_parent = data.Rows(0)("id_acc_parent").ToString
            acc_name = data.Rows(0)("acc_name").ToString
            TEAccount.Text = acc_name

            If id_parent = "" Then
                SLEParentAccount.EditValue = "-1"
                TEAccountDetail.Text = acc_name
            Else
                SLEParentAccount.EditValue = id_parent
                TEAccountDetail.Text = acc_name.Substring(SLEParentAccount.Text.Length, acc_name.Length - SLEParentAccount.Text.Length)
            End If

            LEAccCat.ItemIndex = LEAccCat.Properties.GetDataSourceRowIndex("id_acc_cat", data.Rows(0)("id_acc_cat").ToString)
            LEActive.ItemIndex = LEActive.Properties.GetDataSourceRowIndex("id_status", data.Rows(0)("id_status").ToString)
            LEDetail.ItemIndex = LEDetail.Properties.GetDataSourceRowIndex("id_is_det", data.Rows(0)("id_is_det").ToString)
            MEAccDesc.Text = data.Rows(0)("acc_description").ToString

            SLEParentAccount.Properties.ReadOnly = True
            LEAccCat.Properties.ReadOnly = True
            MEAccDesc.Properties.ReadOnly = True
            LEDetail.Properties.ReadOnly = True
        End If
    End Sub



    Private Sub view_acc_category(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_acc_cat,acc_cat FROM tb_lookup_acc_cat"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "acc_cat"
        lookup.Properties.ValueMember = "id_acc_cat"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_active(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_status,status FROM tb_lookup_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "status"
        lookup.Properties.ValueMember = "id_status"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_is_det(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_is_det,is_det FROM tb_lookup_is_det"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "is_det"
        lookup.Properties.ValueMember = "id_is_det"
        lookup.ItemIndex = 0
    End Sub

    'View Parent
    Private Sub viewParent(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT '-1' AS id_acc,'No Parent Account' AS acc_name,'' AS acc_description,'-1' AS id_acc_cat,'' AS acc_cat UNION "
        query += "SELECT a.id_acc,acc_name,a.acc_description,a.id_acc_cat,b.acc_cat FROM tb_a_acc a "
        query += "INNER JOIN tb_lookup_acc_cat b ON a.id_acc_cat=b.id_acc_cat "
        query += "WHERE a.id_is_det='1' AND a.id_status='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        If data.Rows.Count > 0 Then
            lookup.Properties.DisplayMember = "acc_name"
            lookup.Properties.ValueMember = "id_acc"
            lookup.EditValue = data.Rows(0)("id_acc").ToString
        End If
    End Sub
    Private Sub SLEParentAccount_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEParentAccount.EditValueChanged
        If Not SLEParentAccount.EditValue = "-1" Then
            Dim id_acc_cat As String = SLEParentAccount.Properties.View.GetFocusedRowCellValue("id_acc_cat")
            MEAccDesc.Text = SLEParentAccount.Properties.View.GetFocusedRowCellValue("acc_description")
            LEAccCat.EditValue = Nothing
            LEAccCat.ItemIndex = LEAccCat.Properties.GetDataSourceRowIndex("id_acc_cat", id_acc_cat)
        Else
            LEAccCat.ItemIndex = 0
        End If
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim query As String = ""

        ValidateChildren()
        If Not formIsValidInPanel(EPACC, PanelControl3) Then
            errorInput()
        Else
            If id_acc = "-1" Then
                'new
                If SLEParentAccount.EditValue = "-1" Then
                    query = String.Format("INSERT INTO tb_a_acc(acc_name,acc_description,id_acc_cat,id_is_det,id_status) VALUES('{0}','{1}','{2}','{3}','{4}');SELECT LAST_INSERT_ID()", TEAccount.Text, MEAccDesc.Text, LEAccCat.EditValue.ToString, LEDetail.EditValue.ToString, LEActive.EditValue.ToString)
                Else
                    query = String.Format("INSERT INTO tb_a_acc(acc_name,acc_description,id_acc_parent,id_acc_cat,id_is_det,id_status) VALUES('{0}','{1}','{2}','{3}','{4}','{5}');SELECT LAST_INSERT_ID()", TEAccount.Text, MEAccDesc.Text, SLEParentAccount.Properties.View.GetFocusedRowCellValue("id_acc").ToString, LEAccCat.EditValue.ToString, LEDetail.EditValue.ToString, LEActive.EditValue.ToString)
                End If

                id_acc = execute_query(query, 0, True, "", "", "", "")

                FormAccounting.view_acc()
                FormAccounting.CreateNodes(FormAccounting.TreeList1)
                FormAccounting.XTCGeneral.SelectedTabPageIndex = 0

                FormAccounting.GVAcc.FocusedRowHandle = find_row(FormAccounting.GVAcc, "id_acc", id_acc)

                Close()
            Else
                'edit
                query = String.Format("UPDATE tb_a_acc SET acc_description='{0}',id_acc_cat='{1}',id_is_det='{2}',id_status='{3}' WHERE id_acc='{4}'", MEAccDesc.Text, LEAccCat.EditValue.ToString, LEDetail.EditValue.ToString, LEActive.EditValue.ToString, id_acc)
                execute_non_query(query, True, "", "", "", "")
                FormAccounting.view_acc()
                FormAccounting.CreateNodes(FormAccounting.TreeList1)

                FormAccounting.TreeList1.FocusedNode = FormAccounting.TreeList1.FindNodeByKeyID(id_acc)

                'FormAccounting.XTCGeneral.SelectedTabPageIndex = 0
                FormAccounting.GVAcc.FocusedRowHandle = find_row(FormAccounting.GVAcc, "id_acc", id_acc)

                Close()
            End If
        End If
    End Sub

    Private Sub TEAccountDetail_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEAccountDetail.EditValueChanged
        combine_acc()
    End Sub
    Sub combine_acc()
        Try
            Dim parent, acc As String

            If Not SLEParentAccount.EditValue = "-1" Then
                parent = SLEParentAccount.Text
            Else
                parent = ""
            End If

            acc = TEAccountDetail.Text

            TEAccount.Text = parent & TEAccountDetail.Text

        Catch ex As Exception
        End Try
    End Sub

    Private Sub TEAccount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEAccount.Validating
        check()
    End Sub

    Sub check()
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_acc) FROM tb_a_acc WHERE acc_name='{0}' AND id_acc!='{1}'", TEAccount.Text, id_acc)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPACC, TEAccountDetail, "1")
        Else
            EP_TE_cant_blank(EPACC, TEAccountDetail)
        End If
    End Sub

    Private Sub BPickCompTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormPopUpContact.id_pop_up = "58"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub TEAccountDetail_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TEAccountDetail.Validating
        check()
    End Sub
End Class