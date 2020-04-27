Public Class FormWHAwbillTrackCollection
    Private Sub FormWHAwbillTrackCollection_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormWHAwbillTrackCollection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()
    End Sub

    Sub load_vendor()
        Dim q As String = "SELECT id_comp,comp_name FROM tb_m_comp WHERE id_comp_cat='7' AND is_active='1'"
        viewSearchLookupQuery(SLECargo, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_collection()
    End Sub

    Sub load_collection()
        Dim q As String = "SELECT 3n.`id_track_no`,3n.`track_no`,IF(3n.is_use=1,'-','Used') AS used,c.`comp_name`
FROM tb_3pl_track_no 3n
INNER JOIN tb_m_comp c ON c.id_comp=3n.id_comp
WHERE 3n.id_comp='" & SLECargo.EditValue.ToString & "'
ORDER BY 3n.track_no DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCCollection.DataSource = dt
        GVCollection.BestFitColumns()
    End Sub

    Private Sub Bimport_Click(sender As Object, e As EventArgs) Handles Bimport.Click
        FormImportExcel.id_pop_up = "49"
        FormImportExcel.ShowDialog()
    End Sub
End Class