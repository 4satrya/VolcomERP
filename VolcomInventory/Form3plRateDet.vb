Public Class Form3plRateDet
    Public id_rate As String = "-1"

    Private Sub Form3plRateDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If TECargoCode.Text = "" Or TERate.EditValue < 0 Or TEMinWeight.EditValue < 1 Or TELeadTime.EditValue < 1 Then
            warningCustom("Please make sure your input right")
        Else
            If id_rate = "-1" Then
                Dim q As String = "INSERT INTO tb_3pl_rate(`id_type`,`id_city`,`id_comp`,`cargo_code`,`cargo_rate`,`cargo_lead_time`,`cargo_min_weight`,`input_datetime`,`created_by`)
VALUES('" & SLEInboundOutbound.EditValue.ToString & "','" & SLECity.EditValue.ToString & "','" & SLECargo.EditValue.ToString & "','" & addSlashes(TECargoCode.Text) & "','" & decimalSQL(TERate.EditValue.ToString) & "','" & decimalSQL(TELeadTime.EditValue.ToString) & "','" & decimalSQL(TEMinWeight.EditValue.ToString) & "',NOW(),'" & id_user & "')"
                execute_non_query(q, True, "", "", "", "")
                Form3plRate.load_list()
                Close()
            Else
                Dim q As String = "UPDATE tb_3pl_rate SET `id_type`='" & SLEInboundOutbound.EditValue.ToString & "',`id_city`='" & SLECity.EditValue.ToString & "',`id_comp`='" & SLECargo.EditValue.ToString & "',`cargo_code`='" & addSlashes(TECargoCode.Text) & "',`cargo_rate`='" & decimalSQL(TERate.EditValue.ToString) & "',`cargo_lead_time`='" & decimalSQL(TELeadTime.EditValue.ToString) & "',`cargo_min_weight`='" & decimalSQL(TEMinWeight.EditValue.ToString) & "',`input_datetime`=NOW(),`created_by`='" & id_user & "'
WHERE id_3pl_rate='" & id_rate & "'"
                execute_non_query(q, True, "", "", "", "")
                Form3plRate.load_list()
                Close()
            End If
        End If
    End Sub

    Private Sub Form3plRateDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_city()
        load_type()
        load_vendor()
        load_det()
    End Sub

    Sub load_vendor()
        Dim q As String = "SELECT id_comp,comp_name FROM tb_m_comp WHERE id_comp_cat='7' AND is_active='1'"
        viewSearchLookupQuery(SLECargo, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_city()
        Dim q As String = "SELECT ct.id_city,ct.`city`,ct.`island`,reg.`region`,st.`state`,c.`country`
FROM tb_m_city ct
INNER JOIN tb_m_state st ON st.`id_state`=ct.`id_state`
INNER JOIN tb_m_region reg ON reg.`id_region`=st.`id_region`
INNER JOIN tb_m_country c ON c.`id_country`=reg.`id_country`"
        viewSearchLookupQuery(SLECity, q, "id_city", "city", "id_city")
    End Sub

    Sub load_type()
        Dim q As String = "SELECT 1 AS id_type,'Outbound' AS type
UNION
SELECT 2 AS id_type,'Inbound' AS type"
        viewSearchLookupQuery(SLEInboundOutbound, q, "id_type", "type", "id_type")
    End Sub

    Sub load_det()
        Dim q As String = "SELECT * FROM tb_3pl_rate WHERE id_3pl_rate='" & id_rate & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            SLECity.EditValue = dt.Rows(0)("id_city").ToString
            SLECargo.EditValue = dt.Rows(0)("id_comp").ToString
            SLEInboundOutbound.EditValue = dt.Rows(0)("id_type").ToString
            TECargoCode.EditValue = dt.Rows(0)("cargo_code").ToString
            TERate.EditValue = dt.Rows(0)("cargo_rate").ToString
            TELeadTime.EditValue = dt.Rows(0)("cargo_lead_time").ToString
            TEMinWeight.EditValue = dt.Rows(0)("cargo_min_weight").ToString
        Else
            TELeadTime.EditValue = 1
            TEMinWeight.EditValue = 1
            TERate.EditValue = 1
        End If
    End Sub
End Class