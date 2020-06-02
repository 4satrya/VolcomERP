Public Class FormCollie
    Public id_koli As String = "-1"
    Public id_comp As String = ""
    Public opt As String = ""
    Public is_view As String = "-1"

    Private Sub FormCollie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_sub_dsitrict()
        TEPanjang.EditValue = 0.00
        TELebar.EditValue = 0.00
        TETinggi.EditValue = 0.00
        TEVolume.EditValue = 0.00
        TEBerat.EditValue = 0.00

        TEBeratFinal.EditValue = 0

        view_do()

        If id_koli = "-1" Then
            If opt = "From DO" Then
                id_comp = FormWHAWBill.GVDOERP.GetRowCellValue(0, "id_comp").ToString
                SLESubDistrict.EditValue = FormWHAWBill.GVDOERP.GetRowCellValue(0, "id_sub_district").ToString
                TECompName.Text = FormWHAWBill.GVDOERP.GetRowCellValue(0, "store_name").ToString
                TECompCode.Text = FormWHAWBill.GVDOERP.GetRowCellValue(0, "store_number").ToString
                '
                If FormWHAWBill.GVDOERP.GetRowCellValue(0, "id_commerce_type").ToString = "2" Then
                    SLESubDistrict.Enabled = True
                Else
                    SLESubDistrict.Enabled = False
                End If
                '
                clear_do()

                'masukkan DO
                For i As Integer = 0 To FormWHAWBill.GVDOERP.RowCount - 1
                    Dim newRow As DataRow = (TryCast(GCDO.DataSource, DataTable)).NewRow()
                    newRow("id_pl_sales_order_del") = FormWHAWBill.GVDOERP.GetRowCellValue(i, "id_pl_sales_order_del").ToString
                    newRow("do_no") = FormWHAWBill.GVDOERP.GetRowCellValue(i, "do_no").ToString
                    newRow("qty") = FormWHAWBill.GVDOERP.GetRowCellValue(i, "qty")

                    TryCast(GCDO.DataSource, DataTable).Rows.Add(newRow)
                    GCDO.RefreshDataSource()
                Next
                '
            ElseIf opt = "From DO AWB" Then
                id_comp = FormWHAWBillReff.GVDOERP.GetRowCellValue(0, "id_comp").ToString
                TECompName.Text = FormWHAWBillReff.GVDOERP.GetRowCellValue(0, "store_name").ToString
                TECompCode.Text = FormWHAWBillReff.GVDOERP.GetRowCellValue(0, "store_number").ToString
                '
                load_sub_dsitrict_filter(" WHERE ct.city='" & FormWHAWBillReff.GVDOERP.GetRowCellValue(0, "shipping_city").ToString & "' ")
                '
                If FormWHAWBillReff.GVDOERP.GetRowCellValue(0, "id_commerce_type").ToString = "2" Then
                    SLESubDistrict.Enabled = True
                Else
                    SLESubDistrict.Enabled = False
                End If
                '
                clear_do()

                'masukkan DO
                For i As Integer = 0 To FormWHAWBillReff.GVDOERP.RowCount - 1
                    Dim newRow As DataRow = (TryCast(GCDO.DataSource, DataTable)).NewRow()
                    newRow("id_pl_sales_order_del") = FormWHAWBillReff.GVDOERP.GetRowCellValue(i, "id_pl_sales_order_del").ToString
                    newRow("do_no") = FormWHAWBillReff.GVDOERP.GetRowCellValue(i, "do_no").ToString
                    newRow("qty") = FormWHAWBillReff.GVDOERP.GetRowCellValue(i, "qty")

                    TryCast(GCDO.DataSource, DataTable).Rows.Add(newRow)
                    GCDO.RefreshDataSource()
                Next
                '
            ElseIf opt = "From Return Customer" Then
                id_comp = FormWHAWBill.GVRet.GetRowCellValue(0, "id_comp").ToString
                TECompName.Text = FormWHAWBill.GVRet.GetRowCellValue(0, "comp_name").ToString
                TECompCode.Text = FormWHAWBill.GVRet.GetRowCellValue(0, "comp_number").ToString
                '
                load_sub_dsitrict_filter(" WHERE ct.city='" & FormWHAWBill.GVRet.GetRowCellValue(0, "shipping_city").ToString & "' ")
                '
                If FormWHAWBill.GVRet.GetRowCellValue(0, "id_commerce_type").ToString = "2" Then
                    SLESubDistrict.Enabled = True
                Else
                    SLESubDistrict.Enabled = False
                End If
                '
                clear_do()

                'masukkan DO
                For i As Integer = 0 To FormWHAWBill.GVRet.RowCount - 1
                    Dim newRow As DataRow = (TryCast(GCDO.DataSource, DataTable)).NewRow()
                    newRow("id_ol_store_cust_ret") = FormWHAWBill.GVRet.GetRowCellValue(i, "id_ol_store_cust_ret").ToString
                    newRow("do_no") = FormWHAWBill.GVRet.GetRowCellValue(i, "number").ToString
                    newRow("qty") = FormWHAWBill.GVRet.GetRowCellValue(i, "qty")

                    TryCast(GCDO.DataSource, DataTable).Rows.Add(newRow)
                    GCDO.RefreshDataSource()
                Next
                '
            ElseIf opt = "From AWB Reff" Then

            End If
        Else 'edit

        End If
    End Sub

    Sub view_do()
        Dim query As String = "SELECT * FROM tb_wh_awbill_det WHERE id_awbill='" + id_koli + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCDO.DataSource = data
    End Sub

    Sub clear_do()
        For i As Integer = GVDO.RowCount To 0 Step -1
            GVDO.DeleteRow(i)
        Next
    End Sub

    Sub load_sub_dsitrict()
        Dim q As String = "SELECT dis.id_sub_district,dis.`sub_district`,ct.city,ct.`island`,reg.`region`,st.`state`,c.`country`
FROM tb_m_sub_district dis
INNER JOIN tb_m_city ct ON dis.id_city=ct.id_city
INNER JOIN tb_m_state st ON st.`id_state`=ct.`id_state`
INNER JOIN tb_m_region reg ON reg.`id_region`=st.`id_region`
INNER JOIN tb_m_country c ON c.`id_country`=reg.`id_country`"
        viewSearchLookupQuery(SLESubDistrict, q, "id_sub_district", "sub_district", "id_sub_district")
    End Sub

    Sub load_sub_dsitrict_filter(ByVal filter As String)
        Dim q As String = "SELECT dis.id_sub_district,dis.`sub_district`,ct.city,ct.`island`,reg.`region`,st.`state`,c.`country`
FROM tb_m_sub_district dis
INNER JOIN tb_m_city ct ON dis.id_city=ct.id_city
INNER JOIN tb_m_state st ON st.`id_state`=ct.`id_state`
INNER JOIN tb_m_region reg ON reg.`id_region`=st.`id_region`
INNER JOIN tb_m_country c ON c.`id_country`=reg.`id_country` " & filter
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            viewSearchLookupQuery(SLESubDistrict, q, "id_sub_district", "sub_district", "id_sub_district")
        Else
            warningCustom("Shipping district not found, please choose shipping district correctly !")
            load_sub_dsitrict()
        End If
    End Sub

    Private Sub FormCollie_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSubmit_Click(sender As Object, e As EventArgs) Handles BSubmit.Click

    End Sub
End Class