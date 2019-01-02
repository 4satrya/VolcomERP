Imports DevExpress.XtraEditors

Public Class FormSalesReturnRecDet
    Public id As String = "-1"

    Private Sub FormSalesReturnRecDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = ""
        Dim TENumberValue As String = ""
        Dim DECreatedDateValue As String = ""
        Dim TEDONumberValue As String = ""
        Dim MENoteValue As String = ""

        If id <> "-1" Then
            query = "SELECT * FROM `tb_sales_return_rec` WHERE `id_sales_return_rec` = '" + id + "'"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TENumber.EditValue = data.Rows(0)("number")
            DECreatedDate.EditValue = data.Rows(0)("created_date")
            TEDONumber.EditValue = data.Rows(0)("do_number")
            MENote.Text = data.Rows(0)("note")

            query = "
                SELECT rd.id_product, p.product_name, p.product_full_code, cd.code_detail_name, rd.qty quantity
                FROM tb_sales_return_rec_det rd
                INNER JOIN tb_m_product p ON rd.id_product = p.id_product
                INNER JOIN tb_m_product_code pc ON p.id_product = pc.id_product
                INNER JOIN tb_m_code_detail cd ON pc.id_code_detail = cd.id_code_detail
                WHERE rd.id_sales_return_rec = '" + id + "'
            "

            Dim dataDet As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCList.DataSource = dataDet

            TEProductCode.Enabled = False
            TEDONumber.Enabled = False
            MENote.Enabled = False
        Else
            TEProductCode.Enabled = True
            TEDONumber.Enabled = True
            MENote.Enabled = True

            GCList.DataSource = getProduct("-1")
        End If
    End Sub

    Private Function getProduct(ByVal product_full_code As String) As DataTable
        Dim query As String = "
            SELECT `p`.`id_product`, `p`.`product_name`, `p`.`product_full_code`, `cd`.`code_detail_name`, (1) `quantity`
            FROM `tb_m_product` `p`
            INNER JOIN `tb_m_product_code` `pc` ON `p`.`id_product` = `pc`.`id_product`
            INNER JOIN `tb_m_code_detail` `cd` ON `pc`.`id_code_detail` = `cd`.`id_code_detail`
            WHERE `p`.`product_full_code` = '" + product_full_code + "'
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Return data
    End Function

    Sub checkProduct()
        Dim data As DataTable = getProduct(TEProductCode.EditValue.ToString)

        If data.Rows.Count > 0 Then
            Dim already As Boolean = False
            Dim i As Integer = 0

            For i = 0 To GVList.RowCount - 1
                If GVList.GetRowCellValue(i, "id_product") = data.Rows(0)("id_product").ToString Then
                    already = True

                    Exit For
                End If
            Next

            If already Then
                Dim quantity As Integer = GVList.GetRowCellValue(i, "quantity") + 1

                GVList.SetRowCellValue(i, "quantity", quantity)

                GVList.RefreshData()
            Else
                Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()

                newRow("id_product") = data.Rows(0)("id_product").ToString
                newRow("product_name") = data.Rows(0)("product_name").ToString
                newRow("product_full_code") = data.Rows(0)("product_full_code").ToString
                newRow("code_detail_name") = data.Rows(0)("code_detail_name").ToString
                newRow("quantity") = data.Rows(0)("quantity").ToString

                TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)

                GCList.RefreshDataSource()

                GVList.RefreshData()

                GVList.BestFitColumns()
            End If

            SBSave.Enabled = True
        Else
            XtraMessageBox.Show("Product not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        TEProductCode.EditValue = ""
    End Sub

    Private Sub TEProductCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TEProductCode.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            checkProduct()
        End If
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        Cursor = Cursors.WaitCursor

        Dim query As String = ""

        query = "
            INSERT INTO `tb_sales_return_rec` (`created_date`, `do_number`, `note`, `id_report_status`) VALUES (NOW(), '" + TEDONumber.EditValue.ToString + "', '" + MENote.Text.ToString + "', '1'); SELECT LAST_INSERT_ID();
        "

        Dim id_sales_return_rec As String = execute_query(query, 0, True, "", "", "", "")

        For i = 0 To GVList.RowCount - 1
            query = "
                INSERT INTO `tb_sales_return_rec_det` (`id_sales_return_rec`, `id_product`, `qty`) VALUES ('" + id_sales_return_rec + "', '" + GVList.GetRowCellValue(i, "id_product").ToString + "', '" + GVList.GetRowCellValue(i, "quantity").ToString + "');
            "

            execute_non_query(query, True, "", "", "", "")
        Next

        query = "CALL gen_number(" + id_sales_return_rec + ", 168)"

        execute_non_query(query, True, "", "", "", "")

        submit_who_prepared("168", id_sales_return_rec, id_user)

        Cursor = Cursors.Default

        FormSalesReturnRec.load_list()

        Dispose()
    End Sub

    Private Sub SBCancel_Click(sender As Object, e As EventArgs) Handles SBCancel.Click
        Dispose()
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        FormReportMark.id_report = id
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "168"
        FormReportMark.ShowDialog()
    End Sub
End Class