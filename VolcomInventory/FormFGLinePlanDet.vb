Public Class FormFGLinePlanDet
    Public id As String = "-1"
    Public action As String = "-1"

    Private Sub FormFGLinePlanDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCode(SLESex, "1")
        viewCode(SLECat, "2")
        viewCode(SLESource, "3")
        viewCode(SLEClass, "4")
        viewCode(SLEColor, "5")
        viewDel()
        actionLoad()
    End Sub

    Sub actionLoad()
        TxtQty.EditValue = 0.00
        TxtMarkUp.EditValue = 0.00
        TxtTargetPrice.EditValue = 0.00
        TxtTargetCost.EditValue = 0.00
        TxtTotalCost.EditValue = 0.00
        TxtTotalValue.EditValue = 0.00
        SLESex.Focus()

        If action = "upd" Then
            Dim query As String = "SELECT * 
            FROM tb_fg_line_plan WHERE id_fg_line_plan='" + id + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LEDelivery.ItemIndex = LEDelivery.Properties.GetDataSourceRowIndex("id_delivery", data.Rows(0)("id_delivery").ToString)
            SLESex.EditValue = data.Rows(0)("id_division").ToString
            SLECat.EditValue = data.Rows(0)("id_category").ToString
            SLESource.EditValue = data.Rows(0)("id_source").ToString
            SLEClass.EditValue = data.Rows(0)("id_class").ToString
            If data.Rows(0)("id_color").ToString = "" Then
                SLEColor.EditValue = Nothing
            Else
                SLEColor.EditValue = data.Rows(0)("id_color").ToString
            End If
            TxtDescription.Text = data.Rows(0)("description").ToString
            TxtBenchmark.Text = data.Rows(0)("benchmark").ToString
            TxtQty.EditValue = data.Rows(0)("qty")
            TxtMarkUp.EditValue = data.Rows(0)("mark_up")
            TxtTargetPrice.EditValue = data.Rows(0)("target_price")
            getTargetCost()
            getTotalCost()
            getTotalValue()
        End If
    End Sub

    Sub getTargetCost()
        TxtTargetCost.EditValue = TxtTargetPrice.EditValue / TxtMarkUp.EditValue
    End Sub

    Sub getTotalCost()
        TxtTotalCost.EditValue = TxtQty.EditValue * TxtTargetCost.EditValue
    End Sub


    Sub getTotalValue()
        TxtTotalValue.EditValue = TxtQty.EditValue * TxtTargetPrice.EditValue
    End Sub


    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormFGLinePlanDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewCode(ByVal SLE As DevExpress.XtraEditors.SearchLookUpEdit, ByVal id_type As String)
        Dim query As String = "SELECT cd.id_code_detail, cd.display_name, cd.code_detail_name FROM tb_m_code_detail cd WHERE cd.id_code_detail>0 "
        If id_type = "1" Then
            query += "AND cd.id_code=32; "
        ElseIf id_type = "2" Then
            query += "AND cd.id_code=4; "
        ElseIf id_type = "3" Then
            query += "AND cd.id_code=5; "
        ElseIf id_type = "4" Then
            query += "AND cd.id_code=30; "
        ElseIf id_type = "5" Then
            query += "AND cd.id_code=14;  "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLE.Properties.DataSource = Nothing
        SLE.Properties.DataSource = data
        SLE.Properties.DisplayMember = "display_name"
        SLE.Properties.ValueMember = "id_code_detail"
        If data.Rows.Count.ToString >= 1 Then
            SLE.EditValue = data.Rows(0)("id_code_detail").ToString
        Else
            SLE.EditValue = Nothing
        End If
    End Sub

    Sub viewDel()
        Dim query As String = "SELECT * FROM tb_season_delivery d WHERE d.id_season=" + FormFGLinePlan.SLESeason.EditValue.ToString + " "
        viewLookupQuery(LEDelivery, query, 0, "delivery", "id_delivery")
    End Sub

    Private Sub TxtQty_EditValueChanged(sender As Object, e As EventArgs) Handles TxtQty.EditValueChanged
        getTotalCost()
        getTotalValue()
    End Sub

    Private Sub TxtMarkUp_EditValueChanged(sender As Object, e As EventArgs) Handles TxtMarkUp.EditValueChanged
        getTargetCost()
    End Sub

    Private Sub TxtTargetPrice_EditValueChanged(sender As Object, e As EventArgs) Handles TxtTargetPrice.EditValueChanged
        getTargetCost()
        getTotalValue()
    End Sub

    Private Sub TxtTargetCost_EditValueChanged(sender As Object, e As EventArgs) Handles TxtTargetCost.EditValueChanged
        getTotalCost()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim id_season As String = FormFGLinePlan.SLESeason.EditValue.ToString
        Dim id_delivery As String = LEDelivery.EditValue.ToString
        Dim id_division As String = SLESex.EditValue.ToString
        Dim id_category As String = SLECat.EditValue.ToString
        Dim id_source As String = SLESource.EditValue.ToString
        Dim id_class As String = SLEClass.EditValue.ToString
        Dim id_color As String = ""
        If SLEColor.EditValue = Nothing Then
            id_color = "NULL "
        Else
            id_color = SLEColor.EditValue.ToString
        End If
        Dim description As String = addSlashes(TxtDescription.Text)
        Dim benchmark As String = addSlashes(TxtBenchmark.Text)
        Dim qty As String = decimalSQL(TxtQty.EditValue.ToString)
        Dim mark_up As String = decimalSQL(TxtMarkUp.EditValue.ToString)
        Dim target_price As String = decimalSQL(TxtTargetPrice.EditValue.ToString)

        If action = "upd" Then
            Dim query As String = "UPDATE tb_fg_line_plan SET id_delivery='" + id_delivery + "', id_division='" + id_division + "', 
            id_category=" + id_category + ", id_source=" + id_source + ", id_class=" + id_class + ", id_color=" + id_color + ",
            description='" + description + "', benchmark='" + benchmark + "', qty='" + qty + "', mark_up='" + mark_up + "', target_price='" + target_price + "'
            WHERE id_fg_line_plan='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
            FormFGLinePlan.viewData()
            FormFGLinePlan.GVData.FocusedRowHandle = find_row(FormFGLinePlan.GVData, "id_fg_line_plan", id)
            Close()
        ElseIf action = "ins" Then
            Dim query As String = "INSERT INTO tb_fg_line_plan(id_season,id_delivery, id_division, id_category, id_source, id_class, id_color, 
            description,benchmark, qty, mark_up, target_price, input_date) 
            VALUES('" + id_season + "','" + id_delivery + "', " + id_division + ", " + id_category + ", " + id_source + ", " + id_class + ", " + id_color + ",
            '" + description + "', '" + benchmark + "', '" + qty + "', '" + mark_up + "', " + target_price + ", NOW()
            ); SELECT LAST_INSERT_ID(); "
            Dim id_new As String = execute_query(query, 0, True, "", "", "", "")
            FormFGLinePlan.viewData()
            FormFGLinePlan.GVData.FocusedRowHandle = find_row(FormFGLinePlan.GVData, "id_fg_line_plan", id_new)
            actionLoad()
        End If
    End Sub
End Class