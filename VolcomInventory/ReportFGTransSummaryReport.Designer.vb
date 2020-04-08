<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ReportFGTransSummaryReport
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
        Me.WCDesign = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCDesign = New DevExpress.XtraGrid.GridControl()
        Me.GVDesign = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.WCData = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XLTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelCompany = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WCDesign, Me.WCData})
        Me.Detail.HeightF = 266.3333!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WCDesign
        '
        Me.WCDesign.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 0!)
        Me.WCDesign.Name = "WCDesign"
        Me.WCDesign.SizeF = New System.Drawing.SizeF(1118.0!, 266.3333!)
        Me.WCDesign.WinControl = Me.GCDesign
        '
        'GCDesign
        '
        Me.GCDesign.Location = New System.Drawing.Point(0, 0)
        Me.GCDesign.MainView = Me.GVDesign
        Me.GCDesign.Name = "GCDesign"
        Me.GCDesign.Size = New System.Drawing.Size(1073, 256)
        Me.GCDesign.TabIndex = 5
        Me.GCDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDesign})
        '
        'GVDesign
        '
        Me.GVDesign.AppearancePrint.BandPanel.BackColor = System.Drawing.Color.White
        Me.GVDesign.AppearancePrint.BandPanel.BorderColor = System.Drawing.Color.Black
        Me.GVDesign.AppearancePrint.BandPanel.Options.UseBackColor = True
        Me.GVDesign.AppearancePrint.BandPanel.Options.UseBorderColor = True
        Me.GVDesign.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVDesign.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVDesign.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVDesign.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVDesign.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVDesign.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVDesign.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVDesign.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVDesign.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVDesign.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVDesign.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVDesign.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVDesign.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVDesign.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVDesign.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVDesign.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVDesign.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVDesign.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVDesign.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVDesign.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVDesign.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVDesign.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVDesign.GridControl = Me.GCDesign
        Me.GVDesign.Name = "GVDesign"
        Me.GVDesign.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDesign.OptionsBehavior.ReadOnly = True
        Me.GVDesign.OptionsView.ColumnAutoWidth = False
        Me.GVDesign.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVDesign.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVDesign.OptionsView.ShowFooter = True
        Me.GVDesign.OptionsView.ShowGroupPanel = False
        '
        'WCData
        '
        Me.WCData.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 0!)
        Me.WCData.Name = "WCData"
        Me.WCData.SizeF = New System.Drawing.SizeF(1118.0!, 266.3333!)
        Me.WCData.WinControl = Me.GCData
        '
        'GCData
        '
        Me.GCData.Location = New System.Drawing.Point(0, 39)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(1073, 256)
        Me.GCData.TabIndex = 5
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVData.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 24.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel5, Me.XrLabel3, Me.XrLabel2, Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 49.25963!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel5
        '
        Me.XrLabel5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(288.5416!, 0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(337.4583!, 18.71793!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "Printed By : [printed_by]"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(151.0417!, 0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(137.5!, 18.71793!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "Date : [printed_date]"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(151.0417!, 18.71793!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "X = Sales againts stock"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(968.0!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 18.71793!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XLTitle, Me.XrLabel7, Me.XrLabel8, Me.LabelPeriod, Me.XrLabelCompany})
        Me.PageHeader.HeightF = 63.14526!
        Me.PageHeader.Name = "PageHeader"
        '
        'XLTitle
        '
        Me.XLTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XLTitle.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XLTitle.Name = "XLTitle"
        Me.XLTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLTitle.SizeF = New System.Drawing.SizeF(407.2499!, 25.08334!)
        Me.XLTitle.StylePriority.UseFont = False
        Me.XLTitle.StylePriority.UseTextAlignment = False
        Me.XLTitle.Text = "TRANSACTION SUMMARY"
        Me.XLTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel7
        '
        Me.XrLabel7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(0!, 25.08334!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(65.62499!, 16.18692!)
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "PERIOD"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel8
        '
        Me.XrLabel8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(65.625!, 25.08334!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(12.49999!, 16.18693!)
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = ":"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelPeriod
        '
        Me.LabelPeriod.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPeriod.LocationFloat = New DevExpress.Utils.PointFloat(78.125!, 25.08335!)
        Me.LabelPeriod.Name = "LabelPeriod"
        Me.LabelPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelPeriod.SizeF = New System.Drawing.SizeF(175.0!, 16.18691!)
        Me.LabelPeriod.StylePriority.UseFont = False
        Me.LabelPeriod.StylePriority.UseTextAlignment = False
        Me.LabelPeriod.Text = "-"
        Me.LabelPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabelCompany
        '
        Me.XrLabelCompany.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabelCompany.LocationFloat = New DevExpress.Utils.PointFloat(749.2499!, 0!)
        Me.XrLabelCompany.Name = "XrLabelCompany"
        Me.XrLabelCompany.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelCompany.SizeF = New System.Drawing.SizeF(368.7501!, 22.99999!)
        Me.XrLabelCompany.StylePriority.UseFont = False
        Me.XrLabelCompany.StylePriority.UseTextAlignment = False
        Me.XrLabelCompany.Text = "PT VOLCOM INDONESIA"
        Me.XrLabelCompany.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'ReportFGTransSummaryReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(29, 22, 24, 49)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents XLTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelCompany As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WCData As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents WCDesign As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDesign As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
End Class
