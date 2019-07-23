<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportProductionHOAttachment
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnbarcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty_po = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty_rec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty_pl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnbalance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpl_prod_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpl_category = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstep = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty_pl_total = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnho_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnbalance_rec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 258.3333!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(1120.0!, 237.5833!)
        Me.WinControlContainer1.WinControl = Me.GCList
        '
        'GCList
        '
        Me.GCList.Location = New System.Drawing.Point(0, 43)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCList.Size = New System.Drawing.Size(1075, 228)
        Me.GCList.TabIndex = 1
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVList.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVList.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVList.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVList.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVList.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnbarcode, Me.GridColumnName, Me.GridColumnqty_po, Me.GridColumnqty_rec, Me.GridColumnqty_pl, Me.GridColumnbalance, Me.GridColumnpl_prod_order_number, Me.GridColumnpl_category, Me.GridColumndesign, Me.GridColumnstep, Me.GridColumnCode, Me.GridColumnsize, Me.GridColumnqty_pl_total, Me.GridColumnho_status, Me.GridColumnbalance_rec})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.GroupCount = 1
        Me.GVList.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_po", Me.GridColumnqty_po, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec", Me.GridColumnqty_rec, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl", Me.GridColumnqty_pl, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "balance", Me.GridColumnbalance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl_total", Me.GridColumnqty_pl_total, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "balance_rec", Me.GridColumnbalance_rec, "{0:N0}")})
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsFind.AlwaysVisible = True
        Me.GVList.OptionsView.ShowFooter = True
        Me.GVList.OptionsView.ShowGroupPanel = False
        Me.GVList.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumndesign, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnbarcode
        '
        Me.GridColumnbarcode.Caption = "Barcode"
        Me.GridColumnbarcode.FieldName = "barcode"
        Me.GridColumnbarcode.Name = "GridColumnbarcode"
        Me.GridColumnbarcode.Visible = True
        Me.GridColumnbarcode.VisibleIndex = 0
        Me.GridColumnbarcode.Width = 189
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Design"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        '
        'GridColumnqty_po
        '
        Me.GridColumnqty_po.Caption = "Order Total"
        Me.GridColumnqty_po.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty_po.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty_po.FieldName = "qty_po"
        Me.GridColumnqty_po.Name = "GridColumnqty_po"
        Me.GridColumnqty_po.Visible = True
        Me.GridColumnqty_po.VisibleIndex = 5
        Me.GridColumnqty_po.Width = 130
        '
        'GridColumnqty_rec
        '
        Me.GridColumnqty_rec.Caption = "Rec. Total"
        Me.GridColumnqty_rec.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty_rec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty_rec.FieldName = "qty_rec"
        Me.GridColumnqty_rec.Name = "GridColumnqty_rec"
        Me.GridColumnqty_rec.Visible = True
        Me.GridColumnqty_rec.VisibleIndex = 6
        Me.GridColumnqty_rec.Width = 130
        '
        'GridColumnqty_pl
        '
        Me.GridColumnqty_pl.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridColumnqty_pl.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnqty_pl.AppearanceCell.Options.UseBackColor = True
        Me.GridColumnqty_pl.AppearanceCell.Options.UseFont = True
        Me.GridColumnqty_pl.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridColumnqty_pl.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnqty_pl.AppearanceHeader.Options.UseBackColor = True
        Me.GridColumnqty_pl.AppearanceHeader.Options.UseFont = True
        Me.GridColumnqty_pl.Caption = "Handover"
        Me.GridColumnqty_pl.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty_pl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty_pl.FieldName = "qty_pl"
        Me.GridColumnqty_pl.Name = "GridColumnqty_pl"
        Me.GridColumnqty_pl.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl", "{0:N0}")})
        Me.GridColumnqty_pl.Visible = True
        Me.GridColumnqty_pl.VisibleIndex = 8
        Me.GridColumnqty_pl.Width = 139
        '
        'GridColumnbalance
        '
        Me.GridColumnbalance.Caption = "Balance HO"
        Me.GridColumnbalance.DisplayFormat.FormatString = "N0"
        Me.GridColumnbalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnbalance.FieldName = "balance"
        Me.GridColumnbalance.Name = "GridColumnbalance"
        Me.GridColumnbalance.Visible = True
        Me.GridColumnbalance.VisibleIndex = 10
        Me.GridColumnbalance.Width = 136
        '
        'GridColumnpl_prod_order_number
        '
        Me.GridColumnpl_prod_order_number.Caption = "PL#"
        Me.GridColumnpl_prod_order_number.FieldName = "pl_prod_order_number"
        Me.GridColumnpl_prod_order_number.Name = "GridColumnpl_prod_order_number"
        Me.GridColumnpl_prod_order_number.Visible = True
        Me.GridColumnpl_prod_order_number.VisibleIndex = 2
        Me.GridColumnpl_prod_order_number.Width = 125
        '
        'GridColumnpl_category
        '
        Me.GridColumnpl_category.Caption = "Category"
        Me.GridColumnpl_category.FieldName = "pl_category"
        Me.GridColumnpl_category.Name = "GridColumnpl_category"
        Me.GridColumnpl_category.Visible = True
        Me.GridColumnpl_category.VisibleIndex = 3
        Me.GridColumnpl_category.Width = 85
        '
        'GridColumndesign
        '
        Me.GridColumndesign.Caption = "Design"
        Me.GridColumndesign.FieldName = "design"
        Me.GridColumndesign.Name = "GridColumndesign"
        Me.GridColumndesign.UnboundExpression = "Concat([code], ' - ', [name])"
        Me.GridColumndesign.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.GridColumndesign.Visible = True
        Me.GridColumndesign.VisibleIndex = 8
        '
        'GridColumnstep
        '
        Me.GridColumnstep.Caption = "Step HO"
        Me.GridColumnstep.FieldName = "step"
        Me.GridColumnstep.Name = "GridColumnstep"
        Me.GridColumnstep.Visible = True
        Me.GridColumnstep.VisibleIndex = 4
        Me.GridColumnstep.Width = 71
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        '
        'GridColumnsize
        '
        Me.GridColumnsize.Caption = "Size"
        Me.GridColumnsize.FieldName = "size"
        Me.GridColumnsize.Name = "GridColumnsize"
        Me.GridColumnsize.Visible = True
        Me.GridColumnsize.VisibleIndex = 1
        Me.GridColumnsize.Width = 39
        '
        'GridColumnqty_pl_total
        '
        Me.GridColumnqty_pl_total.Caption = "Handover Total"
        Me.GridColumnqty_pl_total.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty_pl_total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty_pl_total.FieldName = "qty_pl_total"
        Me.GridColumnqty_pl_total.Name = "GridColumnqty_pl_total"
        Me.GridColumnqty_pl_total.Visible = True
        Me.GridColumnqty_pl_total.VisibleIndex = 9
        Me.GridColumnqty_pl_total.Width = 144
        '
        'GridColumnho_status
        '
        Me.GridColumnho_status.Caption = "Status"
        Me.GridColumnho_status.FieldName = "ho_status"
        Me.GridColumnho_status.Name = "GridColumnho_status"
        Me.GridColumnho_status.Visible = True
        Me.GridColumnho_status.VisibleIndex = 11
        Me.GridColumnho_status.Width = 312
        '
        'GridColumnbalance_rec
        '
        Me.GridColumnbalance_rec.Caption = "Balance Rec"
        Me.GridColumnbalance_rec.DisplayFormat.FormatString = "N0"
        Me.GridColumnbalance_rec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnbalance_rec.FieldName = "balance_rec"
        Me.GridColumnbalance_rec.Name = "GridColumnbalance_rec"
        Me.GridColumnbalance_rec.UnboundExpression = "[qty_po] - [qty_rec]"
        Me.GridColumnbalance_rec.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnbalance_rec.Visible = True
        Me.GridColumnbalance_rec.VisibleIndex = 7
        Me.GridColumnbalance_rec.Width = 132
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 22.91667!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 23.95833!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1})
        Me.ReportHeader.HeightF = 37.5!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(279.1667!, 23.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.Text = "HANDOVER REPORT"
        '
        'ReportProductionHOAttachment
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(26, 23, 23, 24)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnbarcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty_po As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty_rec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty_pl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnbalance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpl_prod_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpl_category As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnstep As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty_pl_total As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnho_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnbalance_rec As DevExpress.XtraGrid.Columns.GridColumn
End Class
