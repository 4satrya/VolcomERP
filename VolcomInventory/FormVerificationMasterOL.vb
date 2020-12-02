Public Class FormVerificationMasterOL
    Private Sub FormVerificationMasterOL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormVerificationMasterOL_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub form_load()
        Dim query_in As String = ""

        If id_departement_user = "11" Then
            query_in = "653, 1177, 1286"
        ElseIf id_departement_user = "9" Then
            query_in = "1212"
        Else
            query_in = "0"
        End If

        If id_role_login = "1" Then
            query_in = "653, 1177, 1286, 1212"
        End If

        Dim query As String = "
            SELECT vm.id_verification_master, REPLACE(REPLACE(c.comp_name, 'NORMAL', ''), '()', '') AS comp_name, cd.display_name, vm.file_name, IF(m.is_match = 0, 'Not Matched', 'Matched') AS is_match, vm.created_date, e.employee_name AS created_by
            FROM tb_verification_master AS vm
            LEFT JOIN tb_m_comp AS c ON vm.id_comp = c.id_comp
            LEFT JOIN tb_m_code_detail AS cd ON vm.id_code_detail = cd.id_code_detail
            LEFT JOIN tb_m_employee AS e ON vm.created_by = e.id_employee
            LEFT JOIN (
                (SELECT id_verification_master, LEAST(
                    MIN(IF(NamaProduk <> NamaProduk_erp, 0, 1)),
                    MIN(IF(SellerSKU <> SellerSKU_erp, 0, 1)),
                    MIN(IF(Ukuran <> Ukuran_erp, 0, 1)),
                    MIN(IF(Warna <> Warna_erp, 0, 1)),
                    MIN(IF(Parent <> Parent_erp, 0, 1)),
                    MIN(IF(KodeTokoGudang <> KodeTokoGudang_erp, 0, 1)),
                    MIN(IF(HargaRp <> HargaRp_erp, 0, 1)),
                    MIN(IF(HargaPenjualanRp <> HargaPenjualanRp_erp, 0, 1))
                ) AS is_match
                FROM tb_verification_master_blibli
                GROUP BY id_verification_master)

                UNION ALL

                (SELECT id_verification_master, LEAST(
                    MIN(IF(SkuSupplierConfig <> SkuSupplierConfig_erp, 0, 1)),
                    MIN(IF(Name <> Name_erp, 0, 1)),
                    MIN(IF(Brand <> Brand_erp, 0, 1)),
                    MIN(IF(Color <> Color_erp, 0, 1)),
                    MIN(IF(ParentSku <> ParentSku_erp, 0, 1)),
                    MIN(IF(SellerSku <> SellerSku_erp, 0, 1)),
                    MIN(IF(Price <> Price_erp, 0, 1)),
                    MIN(IF(SalePrice <> SalePrice_erp, 0, 1)),
                    MIN(IF(Variation <> Variation_erp, 0, 1))
                ) AS is_match
                FROM tb_verification_master_zalora
                GROUP BY id_verification_master)
                
                UNION ALL

                (SELECT id_verification_master, LEAST(
                    MIN(IF(Option1Value <> Option1Value_erp, 0, 1)),
                    MIN(IF(VariantSKU <> VariantSKU_erp, 0, 1)),
                    MIN(IF(VariantPrice <> VariantPrice_erp, 0, 1)),
                    MIN(IF(VariantCompareAtPrice <> VariantCompareAtPrice_erp, 0, 1)),
                    MIN(IF(VariantBarcode <> VariantBarcode_erp, 0, 1))
                ) AS is_match
                FROM tb_verification_master_volcom
                GROUP BY id_verification_master)   
            ) AS m ON vm.id_verification_master = m.id_verification_master
            WHERE vm.id_comp IN (" + query_in + ")
            ORDER BY vm.created_date DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCVerification.DataSource = data

        GVVerification.BestFitColumns()
    End Sub

    Private Sub GVVerification_DoubleClick(sender As Object, e As EventArgs) Handles GVVerification.DoubleClick
        FormVerificationMasterOLDet.id_verification_master = GVVerification.GetFocusedRowCellValue("id_verification_master")

        FormVerificationMasterOLDet.ShowDialog()
    End Sub

    Private Sub SBNew_Click(sender As Object, e As EventArgs) Handles SBNew.Click
        FormVerificationMasterOLDet.ShowDialog()
    End Sub

    Private Sub FormVerificationMasterOL_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormVerificationMasterOL_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class