Public Class FormWHAWBillDetDO
    Public store_number As String = "-1"
    Private Sub FormWHAWBillDetDO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_do()
    End Sub
    Sub view_do()
        Dim query As String = ""

        query = "SELECT awbdo.*,awb.awbill_no,awb.awbill_inv_no,'no' AS is_check FROM tb_wh_awb_do awbdo 
        LEFT JOIN tb_wh_awbill_det det ON awbdo.do_no=det.do_no 
        LEFT JOIN tb_wh_awbill awb ON awb.id_awbill=det.id_awbill 
        WHERE store_number='" & store_number.ToString & "' AND ISNULL(awb.id_awbill)"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim data_par As DataTable = FormWHAWBillDet.GCDO.DataSource

        If data_par.Rows.Count = 0 Then
            GCDO.DataSource = data
        Else
            If data.Rows.Count > 0 Then
                Dim t1 = data.AsEnumerable()
                Dim t2 = data_par.AsEnumerable()
                Dim result = From _t1 In t1
                             Group Join _t2 In t2
                                            On _t1("do_no") Equals _t2("do_no") Into Group
                             From _t3 In Group.DefaultIfEmpty()
                             Where _t3 Is Nothing
                             Select _t1
                If result.Count > 0 Then
                    Dim except As DataTable = result.CopyToDataTable
                    GCDO.DataSource = except
                Else
                    GCDO.DataSource = Nothing
                End If
            Else
                GCDO.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub FormWHAWBillDetDO_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BBrowse_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        If GVDO.RowCount > 0 Then
            GVDO.ActiveFilterString = "[is_check]='yes'"
            If GVDO.RowCount > 0 Then
                For i As Integer = 0 To GVDO.RowCount - 1
                    Dim newRow As DataRow = (TryCast(FormWHAWBillDet.GCDO.DataSource, DataTable)).NewRow()
                    newRow("do_no") = GVDO.GetRowCellValue(i, "do_no").ToString
                    newRow("qty") = GVDO.GetRowCellValue(i, "qty").ToString

                    TryCast(FormWHAWBillDet.GCDO.DataSource, DataTable).Rows.Add(newRow)
                    FormWHAWBillDet.GCDO.RefreshDataSource()
                Next
            End If
        End If
        Close()
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVDO.RowCount > 0 Then
            Dim cek As String = CheckEditSelAll.EditValue.ToString
            For i As Integer = 0 To ((GVDO.RowCount - 1) - GetGroupRowCount(GVDO))
                If cek Then
                    GVDO.SetRowCellValue(i, "is_check", "yes")
                Else
                    GVDO.SetRowCellValue(i, "is_check", "no")
                End If
            Next
        End If
    End Sub
End Class