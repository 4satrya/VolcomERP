Public Class FormCardView
    Private Sub FormCardView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT dd.`no`, dd.`point`, d.design_code AS `code`, d.design_display_name AS `name`,
        GROUP_CONCAT(DISTINCT cd.code_detail_name ORDER BY cd.id_code_detail ASC SEPARATOR ',') AS `size_chart`
        FROM tb_emp_uni_design_det dd
        INNER JOIN tb_m_design d ON d.id_design = dd.id_design
        INNER JOIN tb_m_product p ON p.id_design = d.id_design
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        WHERE dd.id_emp_uni_design=16
        GROUP BY dd.id_design
        ORDER BY dd.`no` ASC LIMIT 25"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GridControl1.DataSource = data
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        print_raw(GridControl1, "")
    End Sub
End Class