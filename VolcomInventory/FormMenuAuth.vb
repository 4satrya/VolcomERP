Public Class FormMenuAuth
    Public type As String = "-1"

    Private Sub FormMenuAuth_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim username As String = addSlashes(TxtUsername.Text.ToString)
        Dim password As String = addSlashes(TxtPass.Text.ToString)

        Dim query As String = "SELECT * FROM tb_m_user u 
        INNER JOIN tb_menu_single_acc ms ON ms.id_user = u.id_user AND ms.type=" + type + "
        WHERE u.username='" + username + "' AND password=MD5('" + password + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            If type = "1" Then
                'return non stock
                FormSalesReturnDetNew.allow = True
            ElseIf type = "2" Then
                'show cost - report stock
                If FormFGStock.XTCSOH.SelectedTabPageIndex = 0 Then
                    If FormFGStock.BGVFGStock.RowCount > 0 Then
                        FormFGStock.show_cost = True
                        FormFGStock.BGVFGStock.Columns("Unit Cost").VisibleIndex = 8
                        FormFGStock.BGVFGStock.Columns("Unit Cost").OptionsColumn.ShowInCustomizationForm = True
                        FormFGStock.BGVFGStock.Columns("Amount Cost Total").VisibleIndex = 70
                        FormFGStock.BGVFGStock.Columns("Amount Cost Total").OptionsColumn.ShowInCustomizationForm = True
                    Else
                        FormFGStock.show_cost = True
                    End If
                ElseIf FormFGStock.XTCSOH.SelectedTabPageIndex = 1 Then
                    If FormFGStock.BGVStockBarcode.RowCount > 0 Then
                        FormFGStock.show_cost = True
                        FormFGStock.BGVStockBarcode.Columns("design_cop").VisibleIndex = 6
                        FormFGStock.BGVStockBarcode.Columns("design_cop").OptionsColumn.ShowInCustomizationForm = True
                    Else
                        FormFGStock.show_cost = True
                    End If
                End If
            ElseIf type = "3" Then
                'cancell order by MD
                FormSalesOrder.id_user_special = data.Rows(0)("id_user").ToString
                FormSalesOrderPacking.id_pop_up = "6"
                FormSalesOrderPacking.ShowDialog()
            End If
            Close()
        Else
            stopCustom("You do not have access for this menu")
            rejected()
            Close()
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        rejected()
        Close()
    End Sub


    Sub rejected()
        If type = "1" Then
            'return non stock
            FormSalesReturnDetNew.allow = False
        ElseIf type = "2" Then
            'show cost - report stock
            'no action
        End If
    End Sub

    Private Sub FormMenuAuth_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class