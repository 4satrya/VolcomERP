Public Class FormBOMDuplicateDesign
    Public id_design As String = "-1"
    Public id_bom_approve As String = "-1"
    Public id_design_to As String = "-1"

    Private Sub FormBOMDuplicateDesign_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormBOMDuplicateDesign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEProduct.Text = FormBOM.GVDesign.GetFocusedRowCellValue("design_display_name").ToString
        show_design()
    End Sub
    Sub show_design()
        Try
            Dim query As String = "CALL view_bom_design()"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDesign.DataSource = data
            If data.Rows.Count > 0 Then
                GVDesign.ExpandAllGroups()
                GVDesign.FocusedRowHandle = 0
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub BDuplicate_Click(sender As Object, e As EventArgs) Handles BDuplicate.Click
        If GVDesign.GetFocusedRowCellValue("jml_po") > 0 Then
            warningCustom("PO already processed for this design")
        Else
            id_design = FormBOMDesignSingle.id_design
            id_bom_approve = FormBOMDesignSingle.id_bom_approve
            '
            id_design_to = GVDesign.GetFocusedRowCellValue("id_design").ToString
            '
            act_dupe()
            Close()
        End If
    End Sub

    Sub act_dupe()
        Dim query As String = ""
        Dim id_bom_approve_new As String = ""
        'new id_bom_approve
        query = "INSERT INTO tb_bom_approve(id_report_status) VALUES(1); SELECT LAST_INSERT_ID();"
        id_bom_approve_new = execute_query(query, 0, True, "", "", "", "")
        'update default=2 (replace default)
        'update default bom
        query = "UPDATE "
        query += " tb_bom bom "
        query += " INNER JOIN tb_m_product m_p ON m_p.id_product = bom.id_product"
        query += " SET bom.is_default = 2"
        query += " WHERE m_p.id_design='" & id_design_to & "'"
        execute_non_query(query, True, "", "", "", "")
        'INSERT BOM
        query = "INSERT INTO tb_bom(id_product,id_term_production,bom_name,id_currency,kurs,bom_unit_price,bom_date_created,bom_date_updated,id_report_status,is_default,bom_note,id_user_last_update,id_bom_approve)
                SELECT mprod.id_product,bom.*,'" & id_user & "' AS id_user_last_update,'" & id_bom_approve_new & "' AS id_bom_approve FROM tb_m_product mprod 
                JOIN 
                (
	                SELECT bom.id_term_production,bom.bom_name,bom.id_currency,bom.kurs,bom.bom_unit_price,DATE(NOW()),NOW(),'1' AS id_report_status,1 AS is_default,bom.bom_note 
	                FROM tb_bom bom
	                INNER JOIN tb_m_product prod ON prod.id_product=bom.id_product
	                WHERE bom.id_bom_approve='" & id_bom_approve & "' GROUP BY bom.id_bom_approve
                ) bom
                WHERE mprod.id_design='" & id_design_to & "'"
        execute_non_query(query, True, "", "", "", "")
        'Insert detail
        query = "INSERT INTO tb_bom_det(id_bom,id_component_category,id_mat_det_price,id_ovh_price,id_product_price,kurs,bom_price,component_qty,is_cost,is_ovh_main) "
        query += " SELECT bom_b.id_bom_new,bomd.id_component_category,bomd.id_mat_det_price,bomd.id_ovh_price,bomd.id_product_price,bomd.kurs,bomd.bom_price,bomd.component_qty,bomd.is_cost,bomd.is_ovh_main FROM tb_bom_det bomd"
        query += " INNER JOIN tb_bom bom On bom.id_bom=bomd.id_bom"
        query += " INNER JOIN tb_m_product prod ON prod.id_product=bom.id_product"
        query += " INNER JOIN"
        query += " ( SELECT id_bom AS id_bom_new FROM tb_bom WHERE id_bom_approve='" + id_bom_approve_new + "' ) bom_b"
        query += " WHERE bom.id_bom=(SELECT id_bom FROM tb_bom WHERE id_bom_approve='" + id_bom_approve + "' LIMIT 1)"
        execute_non_query(query, True, "", "", "", "")
        infoCustom("BOM duplicate success.")
    End Sub
End Class