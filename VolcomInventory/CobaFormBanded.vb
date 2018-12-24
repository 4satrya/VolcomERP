Public Class CobaFormBanded
    Private Sub CobaFormBanded_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT * FROM `tb_cargo_rate`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            BGVList.ApplyFindFilter("")
            BGVList.ColumnPanelRowHeight = 40
            BGVList.Columns.Clear()
            BGVList.GroupSummary.Clear()
            BGVList.Bands.Clear()
            BGVList.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVList.Bands.AddBand("GridBand1")
            band.AppearanceHeader.Font = New Font(BGVList.Appearance.Row.Font.FontFamily, BGVList.Appearance.Row.Font.Size, FontStyle.Bold)

            BGVList.BeginUpdate()

            For i As Integer = 0 To data.Columns.Count - 1
                band.Columns.Add(BGVList.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))

                BGVList.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Next

            BGVList.EndUpdate()

            GCView.DataSource = data

            BGVList.BestFitColumns()
        End If
    End Sub
End Class