Public Class FormSampleDevelopmentDet
    Private Sub FormSampleDevelopmentDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_dev()
        view_progress()
    End Sub

    Sub view_dev()
        Dim query As String = "SELECT `id_sample_dev_stage`,sample_dev_stage FROM `tb_lookup_sample_dev_stage` WHERE is_active='1'"
        viewSearchLookupQuery(SLEStatus, query, "id_sample_dev_stage", "sample_dev_stage", "id_sample_dev_stage")
    End Sub

    Sub view_progress()
        Dim query As String = "SELECT `id_sample_dev_progress`,`sample_dev_progress` FROM `tb_lookup_sample_dev_progress` WHERE is_active='1'"
        viewSearchLookupQuery(SLEProgress, query, "id_sample_dev_progress", "sample_dev_progress", "id_sample_dev_progress")
    End Sub

    Private Sub FormSampleDevelopmentDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class