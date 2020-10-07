<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ReportCashAdvanceSummary
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XTCLabelSaldoAwal = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XTCSaldoAwal = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XTCLabelExpense = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XTCExpense = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XTCLabelSaldoAkhir = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XTCSaldoAkhir = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XTCLabelAdvance = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XTCAdvance = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow6 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XTCLabelCashOnHand = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell17 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XTCCashOnHand = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XLPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrTable = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow7 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.Detail.HeightF = 175.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable1
        '
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1, Me.XrTableRow2, Me.XrTableRow3, Me.XrTableRow4, Me.XrTableRow5, Me.XrTableRow6})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(649.5833!, 150.0!)
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XTCLabelSaldoAwal, Me.XrTableCell2, Me.XTCSaldoAwal})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XTCLabelSaldoAwal
        '
        Me.XTCLabelSaldoAwal.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.XTCLabelSaldoAwal.Name = "XTCLabelSaldoAwal"
        Me.XTCLabelSaldoAwal.StylePriority.UseFont = False
        Me.XTCLabelSaldoAwal.Text = "Saldo Awal"
        Me.XTCLabelSaldoAwal.Weight = 1.97596174747988R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.StylePriority.UseFont = False
        Me.XrTableCell2.StylePriority.UseTextAlignment = False
        Me.XrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell2.Weight = 0.514422773101598R
        '
        'XTCSaldoAwal
        '
        Me.XTCSaldoAwal.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.XTCSaldoAwal.Name = "XTCSaldoAwal"
        Me.XTCSaldoAwal.StylePriority.UseFont = False
        Me.XTCSaldoAwal.StylePriority.UseTextAlignment = False
        Me.XTCSaldoAwal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XTCSaldoAwal.Weight = 0.507692308414617R
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XTCLabelExpense, Me.XTCExpense, Me.XrTableCell6})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XTCLabelExpense
        '
        Me.XTCLabelExpense.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.XTCLabelExpense.Name = "XTCLabelExpense"
        Me.XTCLabelExpense.StylePriority.UseFont = False
        Me.XTCLabelExpense.Text = "Expense"
        Me.XTCLabelExpense.Weight = 1.97596174747988R
        '
        'XTCExpense
        '
        Me.XTCExpense.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XTCExpense.Name = "XTCExpense"
        Me.XTCExpense.StylePriority.UseFont = False
        Me.XTCExpense.StylePriority.UseTextAlignment = False
        Me.XTCExpense.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XTCExpense.Weight = 0.514422773101598R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.StylePriority.UseFont = False
        Me.XrTableCell6.StylePriority.UseTextAlignment = False
        Me.XrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell6.Weight = 0.507692308414617R
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XTCLabelSaldoAkhir, Me.XrTableCell8, Me.XTCSaldoAkhir})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.0R
        '
        'XTCLabelSaldoAkhir
        '
        Me.XTCLabelSaldoAkhir.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.XTCLabelSaldoAkhir.Name = "XTCLabelSaldoAkhir"
        Me.XTCLabelSaldoAkhir.StylePriority.UseFont = False
        Me.XTCLabelSaldoAkhir.Text = "Saldo Akhir Sampai tgl [period_end]"
        Me.XTCLabelSaldoAkhir.Weight = 1.97596174747988R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.StylePriority.UseFont = False
        Me.XrTableCell8.StylePriority.UseTextAlignment = False
        Me.XrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell8.Weight = 0.514422773101598R
        '
        'XTCSaldoAkhir
        '
        Me.XTCSaldoAkhir.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.XTCSaldoAkhir.Multiline = True
        Me.XTCSaldoAkhir.Name = "XTCSaldoAkhir"
        Me.XTCSaldoAkhir.StylePriority.UseFont = False
        Me.XTCSaldoAkhir.StylePriority.UseTextAlignment = False
        Me.XTCSaldoAkhir.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XTCSaldoAkhir.Weight = 0.507692308414617R
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell10, Me.XrTableCell11, Me.XrTableCell12})
        Me.XrTableRow4.Name = "XrTableRow4"
        Me.XrTableRow4.Weight = 1.0R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.Weight = 1.97596202918063R
        '
        'XrTableCell11
        '
        Me.XrTableCell11.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.XrTableCell11.Name = "XrTableCell11"
        Me.XrTableCell11.StylePriority.UseFont = False
        Me.XrTableCell11.StylePriority.UseTextAlignment = False
        Me.XrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell11.Weight = 0.51442249140085R
        '
        'XrTableCell12
        '
        Me.XrTableCell12.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.XrTableCell12.Name = "XrTableCell12"
        Me.XrTableCell12.StylePriority.UseFont = False
        Me.XrTableCell12.StylePriority.UseTextAlignment = False
        Me.XrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell12.Weight = 0.507692308414617R
        '
        'XrTableRow5
        '
        Me.XrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XTCLabelAdvance, Me.XTCAdvance, Me.XrTableCell15})
        Me.XrTableRow5.Name = "XrTableRow5"
        Me.XrTableRow5.Weight = 1.0R
        '
        'XTCLabelAdvance
        '
        Me.XTCLabelAdvance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.XTCLabelAdvance.Name = "XTCLabelAdvance"
        Me.XTCLabelAdvance.StylePriority.UseFont = False
        Me.XTCLabelAdvance.Text = "Advance"
        Me.XTCLabelAdvance.Weight = 1.97596231088138R
        '
        'XTCAdvance
        '
        Me.XTCAdvance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.XTCAdvance.Name = "XTCAdvance"
        Me.XTCAdvance.StylePriority.UseFont = False
        Me.XTCAdvance.StylePriority.UseTextAlignment = False
        Me.XTCAdvance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XTCAdvance.Weight = 0.514422209700102R
        '
        'XrTableCell15
        '
        Me.XrTableCell15.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.XrTableCell15.Name = "XrTableCell15"
        Me.XrTableCell15.StylePriority.UseFont = False
        Me.XrTableCell15.StylePriority.UseTextAlignment = False
        Me.XrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell15.Weight = 0.507692308414617R
        '
        'XrTableRow6
        '
        Me.XrTableRow6.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XTCLabelCashOnHand, Me.XrTableCell17, Me.XTCCashOnHand})
        Me.XrTableRow6.Name = "XrTableRow6"
        Me.XrTableRow6.Weight = 1.0R
        '
        'XTCLabelCashOnHand
        '
        Me.XTCLabelCashOnHand.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.XTCLabelCashOnHand.Name = "XTCLabelCashOnHand"
        Me.XTCLabelCashOnHand.StylePriority.UseFont = False
        Me.XTCLabelCashOnHand.Text = "Cash on Hand"
        Me.XTCLabelCashOnHand.Weight = 1.97596174747988R
        '
        'XrTableCell17
        '
        Me.XrTableCell17.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.XrTableCell17.Name = "XrTableCell17"
        Me.XrTableCell17.StylePriority.UseFont = False
        Me.XrTableCell17.StylePriority.UseTextAlignment = False
        Me.XrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell17.Weight = 0.514422773101598R
        '
        'XTCCashOnHand
        '
        Me.XTCCashOnHand.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.XTCCashOnHand.Multiline = True
        Me.XTCCashOnHand.Name = "XTCCashOnHand"
        Me.XTCCashOnHand.StylePriority.UseFont = False
        Me.XTCCashOnHand.StylePriority.UseTextAlignment = False
        Me.XTCCashOnHand.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XTCCashOnHand.Weight = 0.507692308414617R
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 100.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 100.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XLPeriod, Me.XLNumber, Me.XrLabel1})
        Me.ReportHeader.HeightF = 125.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XLPeriod
        '
        Me.XLPeriod.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.XLPeriod.LocationFloat = New DevExpress.Utils.PointFloat(0.4167239!, 49.99997!)
        Me.XLPeriod.Name = "XLPeriod"
        Me.XLPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLPeriod.SizeF = New System.Drawing.SizeF(649.5833!, 23.0!)
        Me.XLPeriod.StylePriority.UseFont = False
        Me.XLPeriod.StylePriority.UseTextAlignment = False
        Me.XLPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XLNumber
        '
        Me.XLNumber.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.XLNumber.LocationFloat = New DevExpress.Utils.PointFloat(0!, 26.99998!)
        Me.XLNumber.Name = "XLNumber"
        Me.XLNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLNumber.SizeF = New System.Drawing.SizeF(649.5833!, 23.0!)
        Me.XLNumber.StylePriority.UseFont = False
        Me.XLNumber.StylePriority.UseTextAlignment = False
        Me.XLNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.4167239!, 0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(649.5833!, 27.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "PERMOHONAN PENGGANTIAN PETTY CASH"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable})
        Me.ReportFooter.HeightF = 25.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrTable
        '
        Me.XrTable.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.XrTable.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrTable.Name = "XrTable"
        Me.XrTable.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow7})
        Me.XrTable.SizeF = New System.Drawing.SizeF(650.0001!, 25.0!)
        Me.XrTable.StylePriority.UseFont = False
        '
        'XrTableRow7
        '
        Me.XrTableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1})
        Me.XrTableRow7.Name = "XrTableRow7"
        Me.XrTableRow7.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.Text = "Here Table Mark Goes, Please Ignore This"
        Me.XrTableCell1.Visible = False
        Me.XrTableCell1.Weight = 2.99999986405489R
        '
        'ReportCashAdvanceSummary
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter})
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XTCLabelSaldoAwal As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XTCSaldoAwal As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XTCLabelExpense As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XTCExpense As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XTCLabelSaldoAkhir As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XTCSaldoAkhir As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XTCLabelAdvance As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XTCAdvance As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell15 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow6 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XTCLabelCashOnHand As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell17 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XTCCashOnHand As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrTable As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow7 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
End Class
