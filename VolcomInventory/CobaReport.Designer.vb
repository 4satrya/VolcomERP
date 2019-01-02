<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class CobaReport
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
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCIdProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCProductName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCProductFullCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCodeDetailName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCQuantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XLNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 100.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(650.0!, 100.0!)
        Me.WinControlContainer1.WinControl = Me.GCList
        '
        'GCList
        '
        Me.GCList.Location = New System.Drawing.Point(0, 0)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.Size = New System.Drawing.Size(624, 96)
        Me.GCList.TabIndex = 0
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCIdProduct, Me.GCProductName, Me.GCProductFullCode, Me.GCCodeDetailName, Me.GCQuantity})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "quantity", Me.GCQuantity, "{0:N0}")})
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsBehavior.Editable = False
        Me.GVList.OptionsView.ShowFooter = True
        '
        'GCIdProduct
        '
        Me.GCIdProduct.Caption = "Id"
        Me.GCIdProduct.FieldName = "id_product"
        Me.GCIdProduct.Name = "GCIdProduct"
        Me.GCIdProduct.Visible = True
        Me.GCIdProduct.VisibleIndex = 0
        '
        'GCProductName
        '
        Me.GCProductName.Caption = "Name"
        Me.GCProductName.FieldName = "product_name"
        Me.GCProductName.Name = "GCProductName"
        Me.GCProductName.Visible = True
        Me.GCProductName.VisibleIndex = 1
        '
        'GCProductFullCode
        '
        Me.GCProductFullCode.Caption = "Code"
        Me.GCProductFullCode.FieldName = "product_full_code"
        Me.GCProductFullCode.Name = "GCProductFullCode"
        Me.GCProductFullCode.Visible = True
        Me.GCProductFullCode.VisibleIndex = 2
        '
        'GCCodeDetailName
        '
        Me.GCCodeDetailName.Caption = "Size"
        Me.GCCodeDetailName.FieldName = "code_detail_name"
        Me.GCCodeDetailName.Name = "GCCodeDetailName"
        Me.GCCodeDetailName.Visible = True
        Me.GCCodeDetailName.VisibleIndex = 3
        '
        'GCQuantity
        '
        Me.GCQuantity.Caption = "Quantity"
        Me.GCQuantity.DisplayFormat.FormatString = "N0"
        Me.GCQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCQuantity.FieldName = "quantity"
        Me.GCQuantity.Name = "GCQuantity"
        Me.GCQuantity.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "quantity", "{0:N0}")})
        Me.GCQuantity.Visible = True
        Me.GCQuantity.VisibleIndex = 4
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XLNo, Me.XrLabel1})
        Me.TopMargin.HeightF = 100.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XLNo
        '
        Me.XLNo.LocationFloat = New DevExpress.Utils.PointFloat(128.125!, 29.12501!)
        Me.XLNo.Name = "XLNo"
        Me.XLNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLNo.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        '
        'XrLabel1
        '
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(28.125!, 29.12501!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel1.Text = "NO"
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 100.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.PageFooter.HeightF = 24.79169!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(650.0!, 24.79169!)
        Me.XrTable1.StylePriority.UseFont = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Font = New System.Drawing.Font("Lucida Console", 8.0!)
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.Text = "Here Table Mark Goes, Please Ignore This"
        Me.XrTableCell1.Visible = False
        Me.XrTableCell1.Weight = 2.99999986405489R
        '
        'CobaReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter})
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCProductName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCProductFullCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCodeDetailName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCQuantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XLNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
End Class
