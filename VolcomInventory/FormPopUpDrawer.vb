Public Class FormPopUpDrawer
    Public id_comp As String = "-1"
    Public id_pop_up As String = "-1"
    Public include_all As Boolean = True

    Private Sub FormPopUpDrawer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewWHStockFG()
    End Sub

    Sub viewWHStockFG()
        Dim query As String = ""
        query += "SELECT e.id_comp, e.comp_number, e.comp_name "
        query += "FROM tb_m_comp e "
        If id_comp <> "-1" Then
            query += "WHERE e.id_comp = '" + id_comp + "' "
        End If
        viewSearchLookupQuery(SLEWH, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub viewWHLocatorSLEFG()
        Dim id_comp As String = "0"
        Try
            id_comp = SLEWH.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim query As String = ""
        If include_all Then
            query += "SELECT ('0') AS id_comp, ('0') AS id_wh_locator, ('-') AS wh_locator_code, ('All Loactor') AS wh_locator, ('-') AS wh_locator_description UNION ALL "
        End If

        query += "SELECT a.id_comp, a.id_wh_locator, a.wh_locator_code, a.wh_locator, a.wh_locator_description FROM tb_m_wh_locator a WHERE a.id_comp = '" + id_comp + "' "
        viewSearchLookupQuery(SLELocator, query, "id_wh_locator", "wh_locator_code", "id_wh_locator")
    End Sub

    Sub viewWHRackStockFG()
        Dim id_locator As String = "0"
        Try
            id_locator = SLELocator.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim query As String = ""
        If include_all Then
            query = "SELECT ('0') AS id_locator, ('0') AS id_wh_rack, ('-') AS wh_rack_code, ('All Rack') AS wh_rack, ('-') AS wh_rack_description UNION ALL "
        End If
        query += "SELECT a.id_wh_locator, a.id_wh_rack, a.wh_rack_code, a.wh_rack, a.wh_rack_description FROM tb_m_wh_rack a WHERE a.id_wh_locator = '" + id_locator + "' "
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack_code", "id_wh_rack")
    End Sub

    Sub viewWHDrawerStockFG()
        Dim id_rack As String = "0"
        Try
            id_rack = SLERack.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim query As String = ""
        If include_all Then
            query = "SELECT ('0') AS id_rack, ('0') AS id_wh_drawer, ('-') AS wh_drawer_code, ('All Drawer') AS wh_drawer, ('-') AS wh_drawer_description UNION ALL "
        End If
        query += "SELECT a.id_wh_rack, a.id_wh_drawer, a.wh_drawer_code, a.wh_drawer, a.wh_drawer_description FROM tb_m_wh_drawer a WHERE a.id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer_code", "id_wh_drawer")
    End Sub

    Private Sub SLEWH_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEWH.EditValueChanged
        viewWHLocatorSLEFG()
    End Sub

    Private Sub SLELocator_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocator.EditValueChanged
        viewWHRackStockFG()
    End Sub

    Private Sub SLERack_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERack.EditValueChanged
        viewWHDrawerStockFG()
    End Sub

    Private Sub FormPopUpDrawer_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        If id_pop_up = "1" Then
            Dim val_cek As String = "-1"
            Try
                val_cek = SLEDrawer.EditValue.ToString
                If val_cek = "" Or val_cek = "0" Then
                    val_cek = "-1"
                End If
            Catch ex As Exception
            End Try
            If val_cek = "-1" Then
                stopCustom("Please choose the drawer first.")
            Else
                FormSalesReturnDet.TEDrawer.Text = SLEDrawer.Text
                FormSalesReturnDet.id_drawer = SLEDrawer.EditValue
                Close()
            End If
        ElseIf id_pop_up = "2" Then
            Dim val_cek As String = "-1"
            Try
                val_cek = SLEDrawer.EditValue.ToString
                If val_cek = "" Or val_cek = "0" Then
                    val_cek = "-1"
                End If
            Catch ex As Exception
            End Try
            If val_cek = "-1" Then
                stopCustom("Please choose the drawer first.")
            Else
                FormSalesReturnQCDet.TEDrawer.Text = SLEDrawer.Text
                FormSalesReturnQCDet.id_wh_drawer_to = SLEDrawer.EditValue
                Close()
            End If
        ElseIf id_pop_up = "3" Then
            Dim val_cek As String = "-1"
            Try
                val_cek = SLEDrawer.EditValue.ToString
                If val_cek = "" Or val_cek = "0" Then
                    val_cek = "-1"
                End If
            Catch ex As Exception
            End Try
            If val_cek = "-1" Then
                stopCustom("Please choose the drawer first.")
            Else
                FormFGTrfDet.TxtDrawerCode.Text = SLEDrawer.Text
                FormFGTrfDet.TEDrawer.Text = SLEDrawer.Properties.View.GetFocusedRowCellValue("wh_drawer").ToString
                FormFGTrfDet.id_wh_drawer_to = SLEDrawer.EditValue
                Close()
            End If
        ElseIf id_pop_up = "4" Then
            Dim val_cek As String = "-1"
            Try
                val_cek = SLEDrawer.EditValue.ToString
                If val_cek = "" Or val_cek = "0" Then
                    val_cek = "-1"
                End If
            Catch ex As Exception
            End Try
            If val_cek = "-1" Then
                stopCustom("Please choose the drawer first.")
            Else
                FormMasterCompanySingle.TEDefDrawer.Text = SLEDrawer.Properties.View.GetFocusedRowCellValue("wh_drawer").ToString
                FormMasterCompanySingle.id_def_drawer = SLEDrawer.EditValue
                Close()
            End If
        ElseIf id_pop_up = "5" Then
            Dim val_cek As String = "-1"
            Try
                val_cek = SLEDrawer.EditValue.ToString
                If val_cek = "" Or val_cek = "0" Then
                    val_cek = "-1"
                End If
            Catch ex As Exception
            End Try
            If val_cek = "-1" Then
                stopCustom("Please choose the drawer first.")
            Else
                FormFGStockOpnameWHDet.TEDrawerCode.Text = SLEDrawer.Properties.View.GetFocusedRowCellValue("wh_drawer").ToString
                FormFGStockOpnameWHDet.TEDrawerName.Text = SLEDrawer.Text
                FormFGStockOpnameWHDet.id_drawer = SLEDrawer.EditValue
                Close()
            End If
        ElseIf id_pop_up = "6" Then
            Dim val_cek As String = "-1"
            Try
                val_cek = SLEDrawer.EditValue.ToString
                If val_cek = "" Or val_cek = "0" Then
                    val_cek = "-1"
                End If
            Catch ex As Exception
            End Try
            If val_cek = "-1" Then
                stopCustom("Please choose the drawer first.")
            Else
                FormSamplePLToWHDet.TxtCodeDrawer.Text = SLEDrawer.Text
                FormSamplePLToWHDet.TxtNameDrawer.Text = SLEDrawer.Properties.View.GetFocusedRowCellValue("wh_drawer").ToString
                FormSamplePLToWHDet.id_wh_locator = SLELocator.EditValue.ToString
                FormSamplePLToWHDet.id_wh_rack = SLERack.EditValue.ToString
                FormSamplePLToWHDet.id_wh_drawer = SLEDrawer.EditValue.ToString
                FormSamplePLToWHDet.codeAvailableIns()
                Close()
            End If
        ElseIf id_pop_up = "7" Then 'adj in import
            Dim val_cek As String = "-1"
            Try
                val_cek = SLEDrawer.EditValue.ToString
                If val_cek = "" Or val_cek = "0" Then
                    val_cek = "-1"
                End If
            Catch ex As Exception
            End Try
            If val_cek = "-1" Then
                stopCustom("Please choose the drawer first.")
            Else
                FormFGAdjInDet.comp_name = SLEWH.Text
                FormFGAdjInDet.id_comp = SLEWH.EditValue.ToString

                FormFGAdjInDet.id_drawer = SLEDrawer.EditValue.ToString
                FormFGAdjInDet.drawer_name = SLEDrawer.Text

                FormFGAdjInDet.id_locator = SLELocator.EditValue.ToString
                FormFGAdjInDet.locator_name = SLELocator.Text

                FormFGAdjInDet.id_rack = SLERack.EditValue.ToString
                FormFGAdjInDet.rack_name = SLERack.Text

                FormImportExcel.id_pop_up = "47"
                FormImportExcel.ShowDialog()
                Close()
            End If
        ElseIf id_pop_up = "8" Then 'adj out import
            Dim val_cek As String = "-1"
            Try
                val_cek = SLEDrawer.EditValue.ToString
                If val_cek = "" Or val_cek = "0" Then
                    val_cek = "-1"
                End If
            Catch ex As Exception
            End Try
            If val_cek = "-1" Then
                stopCustom("Please choose the drawer first.")
            Else
                FormFGAdjOutDet.comp_name = SLEWH.Text
                FormFGAdjOutDet.id_comp = SLEWH.EditValue.ToString

                FormFGAdjOutDet.id_drawer = SLEDrawer.EditValue.ToString
                FormFGAdjOutDet.drawer_name = SLEDrawer.Text

                FormFGAdjOutDet.id_locator = SLELocator.EditValue.ToString
                FormFGAdjOutDet.locator_name = SLELocator.Text

                FormFGAdjOutDet.id_rack = SLERack.EditValue.ToString
                FormFGAdjOutDet.rack_name = SLERack.Text

                FormImportExcel.id_pop_up = "48"
                FormImportExcel.ShowDialog()
                Close()
            End If
        End If
    End Sub
End Class