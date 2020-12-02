Public Class FormScanReturnBAPProduct
    Public id_product As String = "-1"

    Private Sub FormScanReturnBAPProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_product()
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub FormScanReturnBAPProduct_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_product()
        Dim q As String = "SELECT p.id_product,p.product_full_code,p.`product_display_name`,cd.`code_detail_name` AS size 
FROM tb_m_product p 
INNER JOIN tb_m_design dsg ON dsg.id_design=p.`id_design` AND dsg.`id_lookup_status_order`!=2
INNER JOIN tb_m_product_code pc ON pc.`id_product`=p.`id_product`
INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail` AND cd.`id_code`='33'"
        viewSearchLookupQuery(SLEDesign, q, "id_product", "product_display_name", "id_product")
        SLEDesign.EditValue = Nothing
    End Sub

    '    Private Sub TECode_KeyUp(sender As Object, e As KeyEventArgs)
    '        If e.KeyCode = Keys.Enter Then
    '            Dim q As String = "SELECT p.id_product,p.product_full_code,p.`product_display_name`,cd.`code_detail_name` AS size 
    'FROM tb_m_product p 
    'INNER JOIN tb_m_design dsg ON dsg.id_design=p.`id_design` AND dsg.`id_lookup_status_order`!=2
    'INNER JOIN tb_m_product_code pc ON pc.`id_product`=p.`id_product`
    'INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail` AND cd.`id_code`='33'
    'WHERE p.product_full_code='" & addSlashes(TECode.Text) & "'"
    '            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
    '            If dt.Rows.Count > 0 Then
    '                SLEDesign.EditValue = dt.Rows(0)("id_product").ToString
    '                SLEDesign.Enabled = False
    '                TECode.Enabled = False
    '                id_product = dt.Rows(0)("id_product").ToString
    '            Else
    '                stopCustomDialog("Code not found.")
    '            End If
    '        End If
    '    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If Not SLEDesign.EditValue = Nothing Then
            FormScanReturnBAP.GVListProduct.SetRowCellValue(FormScanReturnBAP.GVListProduct.FocusedRowHandle, "id_product", SearchLookUpEdit1View.GetFocusedRowCellValue("id_product").ToString())
            FormScanReturnBAP.GVListProduct.SetRowCellValue(FormScanReturnBAP.GVListProduct.FocusedRowHandle, "code", SearchLookUpEdit1View.GetFocusedRowCellValue("product_full_code").ToString())
            FormScanReturnBAP.GVListProduct.SetRowCellValue(FormScanReturnBAP.GVListProduct.FocusedRowHandle, "description", SearchLookUpEdit1View.GetFocusedRowCellValue("product_display_name").ToString())
            FormScanReturnBAP.GVListProduct.SetRowCellValue(FormScanReturnBAP.GVListProduct.FocusedRowHandle, "size", SearchLookUpEdit1View.GetFocusedRowCellValue("size").ToString())

            Close()
        Else
            warningCustom("Please choose product.")
        End If
    End Sub
End Class