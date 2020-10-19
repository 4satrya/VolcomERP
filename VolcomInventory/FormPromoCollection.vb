Public Class FormPromoCollection
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim id_role_admin As String = get_setup_field("id_role_super_admin")

    Private Sub FormPromoCollection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt_now As DataTable = execute_query("SELECT DATE(NOW()) as tgl", -1, True, "", "", "", "")
        DEFromList.EditValue = dt_now.Rows(0)("tgl")
        DEUntilList.EditValue = dt_now.Rows(0)("tgl")

        'discount code list
        If id_role_login = id_role_admin Then
            BtnSync.Visible = True
        End If
    End Sub

    Sub viewPropose()
        Cursor = Cursors.WaitCursor

        'date
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromList.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilList.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim cond As String = "AND (p.created_date>='" + date_from_selected + "' AND p.created_date<='" + date_until_selected + "') "

        Dim query_c As ClassPromoCollection = New ClassPromoCollection()
        Dim query As String = query_c.queryMain(cond, "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Sub check_menu()
        If GVData.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            noManipulating()
        End If
    End Sub

    Sub noManipulating()
        Dim indeks As Integer = -1
        Try
            indeks = GVData.FocusedRowHandle
        Catch ex As Exception
        End Try
        If indeks < 0 Then
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        Else
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormPromoCollection_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormPromoCollection_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnViewList_Click(sender As Object, e As EventArgs) Handles BtnViewList.Click
        viewPropose()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub XTCPromo_Click(sender As Object, e As EventArgs) Handles XTCPromo.Click

    End Sub

    Private Sub BtnSync_Click(sender As Object, e As EventArgs) Handles BtnSync.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim s As New ClassShopifyApi()
            s.get_discount_code()
            infoCustom("Sync completed")
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        viewDiscountList()
    End Sub

    Sub viewDiscountList()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT c.id_ol_promo_collection,c.discount_title, dc.disc_code, c.start_period, c.end_period ,
        IF(NOW()>=c.start_period AND NOW()<=c.end_period,'Active','Expired') AS `status`
        FROM tb_ol_promo_collection c 
        INNER JOIN tb_ol_promo_collection_disc_code dc ON dc.id_ol_promo_collection = c.id_ol_promo_collection
        WHERE c.is_use_discount_code=1 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDC.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print(GCDC, "Discount Code List")
    End Sub

    Private Sub BtnCreateUseDiscount_Click(sender As Object, e As EventArgs) Handles BtnCreateUseDiscount.Click
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        Try
            FormMain.SplashScreenManager1.SetWaitFormDescription("Sync group discount")
            Dim s As New ClassShopifyApi()
            s.get_discount_code()
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default

        'pilih discount code
        Cursor = Cursors.WaitCursor
        FormPromoCollectionDiscCode.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class