﻿Public Class FormProductionPrint
    Public dt As DataTable
    Private Sub FormProductionPrint_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormProductionPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LSeason.Text = FormProduction.SLESeason.Text
        LPeriod.Text = Date.Parse(FormProduction.DEStart.EditValue.ToString).ToString("dd MMMM yyyy") & " - " & Date.Parse(FormProduction.DEStart.EditValue.ToString).ToString("dd MMMM yyyy")
        '
        GCProd.DataSource = dt

        Dim string_awal As String = ""
        string_awal = GVProd.ActiveFilterString
        If string_awal = "" Then
            GVProd.ActiveFilterString += "[po_kurs] > 1"
        Else
            GVProd.ActiveFilterString += " AND [po_kurs] > 1"
        End If

        If GVProd.RowCount > 0 Then
            GridColumnPOAmount.Visible = True
            GridColumnPOCurr.Visible = True
            GridColumnPOKurs.Visible = True
        Else
            GridColumnPOAmount.Visible = False
            GridColumnPOCurr.Visible = False
            GridColumnPOKurs.Visible = False
        End If
        GVProd.ActiveFilterString = string_awal

        GVProd.BestFitColumns()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Cursor = Cursors.WaitCursor
        '
        GridColumnNo.VisibleIndex = 0
        For i As Integer = 0 To GVProd.RowCount - 1
            GVProd.SetRowCellValue(i, "no", (i + 1).ToString)
        Next
        ReportListProd.dt = GCProd.DataSource
        Dim Report As New ReportListProd()
        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVProd.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVProd.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVProd)
        Report.GVProd.AppearancePrint.Row.Font = New Font("Tahoma", 5.3, FontStyle.Regular)
        Report.GVProd.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 7, FontStyle.Regular)
        Report.GVProd.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 5.3, FontStyle.Regular)
        '
        'Parse val
        Report.LSeason.Text = LSeason.Text
        Report.LPeriod.Text = LPeriod.Text

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        GridColumnNo.Visible = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BGenKO_Click(sender As Object, e As EventArgs) Handles BGenKO.Click
        'infoCustom("Still on progress")
        Dim is_ok As Boolean = True

        If GVProd.RowCount > 1 Then
            For i As Integer = 0 To GVProd.RowCount - 1
                If Not GVProd.GetRowCellValue(0, "id_comp_contact").ToString = GVProd.GetRowCellValue(i, "id_comp_contact").ToString Then
                    is_ok = False
                    warningCustom("Different vendor contact selected")
                    Exit For
                End If
                If Not GVProd.GetRowCellValue(0, "id_term_production").ToString = GVProd.GetRowCellValue(i, "id_term_production").ToString Then
                    is_ok = False
                    warningCustom("Different term of production selected")
                    Exit For
                End If
            Next
            '
        ElseIf GVProd.RowCount < 1 Then
            is_ok = False
            warningCustom("No FGPO selected")
        End If
        '
        If is_ok Then
            Dim query_ko As String = "INSERT INTO tb_prod_order_ko(`revision`,`id_comp_contact`,`id_term_production`,`date_created`,`created_by`) VALUES('0','" & GVProd.GetFocusedRowCellValue("id_comp_contact").ToString & "','" & GVProd.GetFocusedRowCellValue("id_term_production").ToString & "',NOW(),'" & id_user & "'); SELECT LAST_INSERT_ID(); "
            Dim id_ko As String = execute_query(query_ko, 0, True, "", "", "", "")
            'insert po
            Dim query_kod As String = "INSERT INTO tb_prod_order_ko_det(`id_prod_order_ko`,`revision`,`id_prod_order`,`lead_time_prod`,`lead_time_payment`) VALUES"
            For i As Integer = 0 To GVProd.RowCount - 1
                If Not i = 0 Then
                    query_kod += ","
                End If
                query_kod += "('" & id_ko & "','0','" & GVProd.GetRowCellValue(i, "id_prod_order").ToString & "','" & GVProd.GetRowCellValue(i, "id_prod_order").ToString & "','')"
            Next
            'generate KO number

            'show KO form

        End If
    End Sub
End Class