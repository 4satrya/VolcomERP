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

                'new soh
                FormFGStock.GVSOH.Columns("unit_cost").VisibleIndex = FormFGStock.GVSOH.Columns("amount").VisibleIndex + 1
                FormFGStock.GVSOH.Columns("unit_cost").OptionsColumn.ShowInCustomizationForm = True
                FormFGStock.GVSOH.Columns("amount_cost").VisibleIndex = FormFGStock.GVSOH.Columns("unit_cost").VisibleIndex + 1
                FormFGStock.GVSOH.Columns("amount_cost").OptionsColumn.ShowInCustomizationForm = True
                FormFGStock.gridBandTotal.Columns.Add(FormFGStock.GVSOHCode.Columns("unit_cost"))
                FormFGStock.GVSOHCode.Columns("unit_cost").VisibleIndex = FormFGStock.GVSOHCode.Columns("amount").VisibleIndex + 1
                FormFGStock.GVSOHCode.Columns("unit_cost").OptionsColumn.ShowInCustomizationForm = True
                FormFGStock.gridBandTotal.Columns.Add(FormFGStock.GVSOHCode.Columns("amount_cost"))
                FormFGStock.GVSOHCode.Columns("amount_cost").VisibleIndex = FormFGStock.GVSOHCode.Columns("unit_cost").VisibleIndex + 1
                FormFGStock.GVSOHCode.Columns("amount_cost").OptionsColumn.ShowInCustomizationForm = True
            ElseIf type = "3" Then
                'cancell order by MD
                FormSalesOrder.id_user_special = data.Rows(0)("id_user").ToString
                FormSalesOrderPacking.id_pop_up = "6"
                FormSalesOrderPacking.ShowDialog()
            ElseIf type = "4" Then
                FormMasterPrice.GVHistSummary.Columns("cost").VisibleIndex = 8
                FormMasterPrice.GVHistSummary.Columns("cost").OptionsColumn.ShowInCustomizationForm = True
            ElseIf type = "5" Then
                'by prod
                FormSalesInv.GridBand1.Columns.Add(FormSalesInv.BandedGridColumndesign_cop_by_prod)
                FormSalesInv.GVByProduct.Columns("design_cop").VisibleIndex = FormSalesInv.GVByProduct.Columns("design_price").VisibleIndex + 1
                FormSalesInv.GVByProduct.Columns("design_cop").OptionsColumn.ShowInCustomizationForm = True
                'by acc
                FormSalesInv.GridBand3.Columns.Add(FormSalesInv.BandedGridColumndesign_cop_per_acc_per_prod)
                FormSalesInv.GVByAccount.Columns("design_cop").VisibleIndex = FormSalesInv.GVByAccount.Columns("design_price").VisibleIndex + 1
                FormSalesInv.GVByAccount.Columns("design_cop").OptionsColumn.ShowInCustomizationForm = True
            ElseIf type = "6" Then
                FormFGTransList.GridColumnunit_cost_sal.VisibleIndex = 100
                FormFGTransList.GridColumntotal_cost_sal.VisibleIndex = 101
                FormFGTransList.GridColumnunit_cost_sal_main.VisibleIndex = 100
                FormFGTransList.GridColumntotal_cost_sal_main.VisibleIndex = 101
            ElseIf type = "7" Then
                FormSalesReturnDet.BMark.Enabled = True
            ElseIf type = "8" Then
                FormSalesReturnQCDet.BMark.Enabled = True
            ElseIf type = "9" Then
                FormFGRepairDet.BMark.Enabled = True
            ElseIf type = "10" Then
                FormFGRepairReturnRecDet.BMark.Enabled = True
            ElseIf type = "11" Then
                FormProductionPLToWHRecDet.BMark.Enabled = True
            ElseIf type = "12" Then
                FormFGTrfNewDet.BMark.Enabled = True
            ElseIf type = "13" Then
                FormSalesDelOrderDet.BMark.Enabled = True
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