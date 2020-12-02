<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ReportAccountingLedger
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportAccountingLedger))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XLAccount = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCellNo = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCellReportNumber = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCellCompany = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCellJournalDate = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCellReff = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCellDescription = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCellQty = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCellDebit = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCellCredit = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCellBalance = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XLTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrTableCellVendor = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.XrTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XLAccount, Me.XrLabel4, Me.XrLabel2, Me.XrLabel1, Me.XrLabel3, Me.XLPeriod, Me.XrTable})
        Me.Detail.HeightF = 106.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XLAccount
        '
        Me.XLAccount.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLAccount.LocationFloat = New DevExpress.Utils.PointFloat(75.00003!, 28.00001!)
        Me.XLAccount.Name = "XLAccount"
        Me.XLAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLAccount.SizeF = New System.Drawing.SizeF(1000.0!, 23.0!)
        Me.XLAccount.StylePriority.UseFont = False
        Me.XLAccount.StylePriority.UseTextAlignment = False
        Me.XLAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(60.00001!, 27.99999!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = ":"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 27.99999!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(60.0!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Account"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 5.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(60.0!, 23.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Period"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(60.00001!, 5.0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = ":"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XLPeriod
        '
        Me.XLPeriod.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLPeriod.LocationFloat = New DevExpress.Utils.PointFloat(75.0!, 4.999987!)
        Me.XLPeriod.Name = "XLPeriod"
        Me.XLPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLPeriod.SizeF = New System.Drawing.SizeF(1000.0!, 23.0!)
        Me.XLPeriod.StylePriority.UseFont = False
        Me.XLPeriod.StylePriority.UseTextAlignment = False
        Me.XLPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable
        '
        Me.XrTable.LocationFloat = New DevExpress.Utils.PointFloat(0.00006357829!, 66.00002!)
        Me.XrTable.Name = "XrTable"
        Me.XrTable.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow})
        Me.XrTable.SizeF = New System.Drawing.SizeF(1075.0!, 40.0!)
        '
        'XrTableRow
        '
        Me.XrTableRow.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellNo, Me.XrTableCellReportNumber, Me.XrTableCellCompany, Me.XrTableCellVendor, Me.XrTableCellJournalDate, Me.XrTableCellReff, Me.XrTableCellDescription, Me.XrTableCellQty, Me.XrTableCellDebit, Me.XrTableCellCredit, Me.XrTableCellBalance})
        Me.XrTableRow.Font = New System.Drawing.Font("Tahoma", 8.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableRow.Name = "XrTableRow"
        Me.XrTableRow.StylePriority.UseFont = False
        Me.XrTableRow.StylePriority.UseTextAlignment = False
        Me.XrTableRow.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableRow.Weight = 1.6R
        '
        'XrTableCellNo
        '
        Me.XrTableCellNo.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCellNo.Name = "XrTableCellNo"
        Me.XrTableCellNo.StylePriority.UseBorders = False
        Me.XrTableCellNo.StylePriority.UsePadding = False
        Me.XrTableCellNo.Text = "No"
        Me.XrTableCellNo.Weight = 0.190728478581579R
        '
        'XrTableCellReportNumber
        '
        Me.XrTableCellReportNumber.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCellReportNumber.Name = "XrTableCellReportNumber"
        Me.XrTableCellReportNumber.StylePriority.UseBorders = False
        Me.XrTableCellReportNumber.StylePriority.UsePadding = False
        Me.XrTableCellReportNumber.Text = "Report Number"
        Me.XrTableCellReportNumber.Weight = 0.55494216032102861R
        '
        'XrTableCellCompany
        '
        Me.XrTableCellCompany.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCellCompany.Name = "XrTableCellCompany"
        Me.XrTableCellCompany.StylePriority.UseBorders = False
        Me.XrTableCellCompany.StylePriority.UsePadding = False
        Me.XrTableCellCompany.Text = "CC"
        Me.XrTableCellCompany.Weight = 0.28420767267469471R
        '
        'XrTableCellJournalDate
        '
        Me.XrTableCellJournalDate.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCellJournalDate.Name = "XrTableCellJournalDate"
        Me.XrTableCellJournalDate.StylePriority.UseBorders = False
        Me.XrTableCellJournalDate.StylePriority.UsePadding = False
        Me.XrTableCellJournalDate.Text = "Journal Date"
        Me.XrTableCellJournalDate.Weight = 0.54039732357912873R
        '
        'XrTableCellReff
        '
        Me.XrTableCellReff.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCellReff.Name = "XrTableCellReff"
        Me.XrTableCellReff.StylePriority.UseBorders = False
        Me.XrTableCellReff.StylePriority.UsePadding = False
        Me.XrTableCellReff.Text = "Reff"
        Me.XrTableCellReff.Weight = 0.4026488569653312R
        '
        'XrTableCellDescription
        '
        Me.XrTableCellDescription.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCellDescription.Name = "XrTableCellDescription"
        Me.XrTableCellDescription.StylePriority.UseBorders = False
        Me.XrTableCellDescription.StylePriority.UsePadding = False
        Me.XrTableCellDescription.Text = "Description"
        Me.XrTableCellDescription.Weight = 2.0563374574540449R
        '
        'XrTableCellQty
        '
        Me.XrTableCellQty.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCellQty.Name = "XrTableCellQty"
        Me.XrTableCellQty.StylePriority.UseBorders = False
        Me.XrTableCellQty.StylePriority.UsePadding = False
        Me.XrTableCellQty.Text = "Qty"
        Me.XrTableCellQty.Weight = 0.34449408851993568R
        '
        'XrTableCellDebit
        '
        Me.XrTableCellDebit.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCellDebit.Name = "XrTableCellDebit"
        Me.XrTableCellDebit.StylePriority.UseBorders = False
        Me.XrTableCellDebit.StylePriority.UsePadding = False
        Me.XrTableCellDebit.Text = "Debit"
        Me.XrTableCellDebit.Weight = 0.7578870150194732R
        '
        'XrTableCellCredit
        '
        Me.XrTableCellCredit.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCellCredit.Name = "XrTableCellCredit"
        Me.XrTableCellCredit.StylePriority.UseBorders = False
        Me.XrTableCellCredit.StylePriority.UsePadding = False
        Me.XrTableCellCredit.Text = "Credit"
        Me.XrTableCellCredit.Weight = 0.75788701501947342R
        '
        'XrTableCellBalance
        '
        Me.XrTableCellBalance.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCellBalance.Name = "XrTableCellBalance"
        Me.XrTableCellBalance.StylePriority.UseBorders = False
        Me.XrTableCellBalance.StylePriority.UsePadding = False
        Me.XrTableCellBalance.Text = "Balance"
        Me.XrTableCellBalance.Weight = 0.72490965364309146R
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 50.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 50.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(924.9999!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 18.71793!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBox1, Me.XLTitle, Me.XrLine1})
        Me.ReportHeader.HeightF = 91.15003!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0.00006357829!, 15.0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(220.0!, 41.15!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XLTitle
        '
        Me.XLTitle.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.XLTitle.LocationFloat = New DevExpress.Utils.PointFloat(220.0001!, 14.99999!)
        Me.XLTitle.Multiline = True
        Me.XLTitle.Name = "XLTitle"
        Me.XLTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLTitle.SizeF = New System.Drawing.SizeF(634.9997!, 41.15001!)
        Me.XLTitle.StylePriority.UseFont = False
        Me.XLTitle.StylePriority.UseTextAlignment = False
        Me.XLTitle.Text = "Buku Besar"
        Me.XLTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 71.15002!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(1075.0!, 20.00001!)
        '
        'XrTableCellVendor
        '
        Me.XrTableCellVendor.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCellVendor.Name = "XrTableCellVendor"
        Me.XrTableCellVendor.StylePriority.UseBorders = False
        Me.XrTableCellVendor.Text = "Vendor"
        Me.XrTableCellVendor.Weight = 0.81383019965923642R
        '
        'ReportAccountingLedger
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 69, 50, 50)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.XrTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLAccount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCellNo As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCellReportNumber As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCellCompany As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCellJournalDate As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCellReff As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCellDescription As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCellQty As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCellDebit As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCellCredit As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCellBalance As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCellVendor As DevExpress.XtraReports.UI.XRTableCell
End Class
