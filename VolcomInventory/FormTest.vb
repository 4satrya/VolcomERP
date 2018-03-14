Imports Microsoft.Office.Interop

Public Class FormTest
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        fBuildArray()
        fBuildFlowchart()
    End Sub

    Public aryValues(5, 2) As String
    Sub fBuildArray()
        aryValues(0, 0) = "Terminator"
        aryValues(1, 0) = "Document"
        aryValues(2, 0) = "Decision"
        aryValues(3, 0) = "Process"
        aryValues(4, 0) = "Terminator"

        aryValues(0, 1) = "Begin Routing Process"
        aryValues(1, 1) = "Gather Customer Data"
        aryValues(2, 1) = "Supported Issue?"
        aryValues(3, 1) = "Dispatch to Queue"
        aryValues(4, 1) = "End Routing Process"
    End Sub

    Sub fBuildFlowchart()
        Dim vApp As Visio.Application
        Dim vDoc As Visio.Document
        Dim vFromShape As Visio.Shape
        Dim vToShape As Visio.Shape
        Dim vConnector As Visio.Shape
        Dim vFlowChartMaster As Visio.Master
        Dim vConnectorMaster As Visio.Master
        Dim vStencil As Visio.Document
        Dim dblXLocation As Double
        Dim dblYLocation As Double
        Dim vBeginCell As Visio.Cell
        Dim vEndCell As Visio.Cell
        Dim iCount As Integer
        Const TEMPLATEPATH = "C:\Program Files\Microsoft Office\Visio10\1033\" _
           & "Solutions\Flowchart\Basic Flowchart Shapes (US units).vss"

        ' Change this constant to match your choice of location and file name.
        Const SAVENEWFILE = "C:\Simpleflowchart.vsd"

        ' Start point measured from the bottom left corner.
        dblXLocation = 4.25
        dblYLocation = 8.5

        vApp = New Visio.Application()
        'Create a new document; note the empty string.
        vDoc = vApp.Documents.Add("")
        vStencil = vApp.Documents.OpenEx(TEMPLATEPATH, 4)

        For iCount = LBound(aryValues) To UBound(aryValues) - 1
            vFlowChartMaster = vStencil.Masters(aryValues(iCount, 0))
            vToShape = vApp.ActivePage.Drop(vFlowChartMaster,
               dblXLocation, dblYLocation)
            vToShape.Text = aryValues(iCount, 1)
            If Not vFromShape Is Nothing Then
                If vConnectorMaster Is Nothing Then
                    vConnectorMaster = vStencil.Masters("Dynamic Connector")
                End If
                vConnector = vApp.ActivePage.Drop(vConnectorMaster, 0, 0)
                vBeginCell = vConnector.Cells("BeginX")
                vBeginCell.GlueTo(vFromShape.Cells("AlignBottom"))
                vEndCell = vConnector.Cells("EndX")
                vEndCell.GlueTo(vToShape.Cells("AlignTop"))
                vConnector.SendToBack()
            End If
            vFromShape = vToShape
            vToShape = Nothing
            dblYLocation = dblYLocation - 1.5
        Next
        vDoc.Pages(1).Name = "Flowchart Example"
        Try
            ' Delete the previous version of the file.
            Kill(SAVENEWFILE)
        Catch
        End Try
        vDoc.SaveAs(SAVENEWFILE)
        vDoc.Close()
        vApp.Quit()
        vDoc = Nothing
        vApp = Nothing
        GC.Collect()
    End Sub
End Class