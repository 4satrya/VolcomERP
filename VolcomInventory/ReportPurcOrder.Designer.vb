﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportPurcOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportPurcOrder))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCSummary = New DevExpress.XtraGrid.GridControl()
        Me.GVSummary = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnPOIdItem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPOItemDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtyPO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPOUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnValQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPOSubTot = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPOVal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RITEVal = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumnDiscPercent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDisc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RepositoryItemSearchLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.LPoNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LCreateDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LTo = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LShipToAddress = New DevExpress.XtraReports.UI.XRLabel()
        Me.LShipTo = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelAttn = New DevExpress.XtraReports.UI.XRLabel()
        Me.LToAdress = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.LTerm = New DevExpress.XtraReports.UI.XRTableCell()
        Me.LPaymentDueDate = New DevExpress.XtraReports.UI.XRTableCell()
        Me.LTermOrder = New DevExpress.XtraReports.UI.XRTableCell()
        Me.LEstRecDate = New DevExpress.XtraReports.UI.XRTableCell()
        Me.LShipVia = New DevExpress.XtraReports.UI.XRTableCell()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.LTotal = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable4 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.LDiscount = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable5 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow6 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.LVat = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable6 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow7 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.LGrandTotal = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LNote = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.GCSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEVal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 129.1667!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(627.0001!, 129.1667!)
        Me.WinControlContainer1.WinControl = Me.GCSummary
        '
        'GCSummary
        '
        Me.GCSummary.Location = New System.Drawing.Point(0, 0)
        Me.GCSummary.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCSummary.MainView = Me.GVSummary
        Me.GCSummary.Name = "GCSummary"
        Me.GCSummary.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit2, Me.RepositoryItemSearchLookUpEdit1, Me.RITEVal})
        Me.GCSummary.Size = New System.Drawing.Size(602, 124)
        Me.GCSummary.TabIndex = 5
        Me.GCSummary.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSummary})
        '
        'GVSummary
        '
        Me.GVSummary.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnPOIdItem, Me.GridColumnPOItemDesc, Me.GridColumnQtyPO, Me.GridColumnPOUOM, Me.GridColumnValQty, Me.GridColumnPOSubTot, Me.GridColumnPOVal, Me.GridColumnDiscPercent, Me.GridColumnDisc})
        Me.GVSummary.GridControl = Me.GCSummary
        Me.GVSummary.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sub_tot", Nothing, "{0:N2}")})
        Me.GVSummary.Name = "GVSummary"
        Me.GVSummary.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVSummary.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVSummary.OptionsCustomization.AllowGroup = False
        Me.GVSummary.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVSummary.OptionsCustomization.AllowSort = False
        Me.GVSummary.OptionsFilter.AllowFilterEditor = False
        Me.GVSummary.OptionsView.ShowFooter = True
        Me.GVSummary.OptionsView.ShowGroupPanel = False
        '
        'GridColumnPOIdItem
        '
        Me.GridColumnPOIdItem.Caption = "ID Item"
        Me.GridColumnPOIdItem.FieldName = "id_item"
        Me.GridColumnPOIdItem.Name = "GridColumnPOIdItem"
        Me.GridColumnPOIdItem.OptionsColumn.AllowEdit = False
        '
        'GridColumnPOItemDesc
        '
        Me.GridColumnPOItemDesc.Caption = "Item"
        Me.GridColumnPOItemDesc.FieldName = "item_desc"
        Me.GridColumnPOItemDesc.Name = "GridColumnPOItemDesc"
        Me.GridColumnPOItemDesc.OptionsColumn.AllowEdit = False
        Me.GridColumnPOItemDesc.Visible = True
        Me.GridColumnPOItemDesc.VisibleIndex = 0
        Me.GridColumnPOItemDesc.Width = 157
        '
        'GridColumnQtyPO
        '
        Me.GridColumnQtyPO.Caption = "Qty"
        Me.GridColumnQtyPO.DisplayFormat.FormatString = "N2"
        Me.GridColumnQtyPO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyPO.FieldName = "qty_po"
        Me.GridColumnQtyPO.Name = "GridColumnQtyPO"
        Me.GridColumnQtyPO.OptionsColumn.AllowEdit = False
        Me.GridColumnQtyPO.Visible = True
        Me.GridColumnQtyPO.VisibleIndex = 1
        Me.GridColumnQtyPO.Width = 72
        '
        'GridColumnPOUOM
        '
        Me.GridColumnPOUOM.Caption = "UOM"
        Me.GridColumnPOUOM.FieldName = "uom"
        Me.GridColumnPOUOM.Name = "GridColumnPOUOM"
        Me.GridColumnPOUOM.OptionsColumn.AllowEdit = False
        Me.GridColumnPOUOM.Visible = True
        Me.GridColumnPOUOM.VisibleIndex = 2
        Me.GridColumnPOUOM.Width = 48
        '
        'GridColumnValQty
        '
        Me.GridColumnValQty.Caption = "Value x Qty"
        Me.GridColumnValQty.DisplayFormat.FormatString = "N2"
        Me.GridColumnValQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnValQty.FieldName = "sub_tot_before"
        Me.GridColumnValQty.Name = "GridColumnValQty"
        Me.GridColumnValQty.OptionsColumn.AllowEdit = False
        Me.GridColumnValQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sub_tot_before", "{0:N2}")})
        Me.GridColumnValQty.UnboundExpression = "[qty_po] * [val_po]"
        Me.GridColumnValQty.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        '
        'GridColumnPOSubTot
        '
        Me.GridColumnPOSubTot.Caption = "Sub Total"
        Me.GridColumnPOSubTot.DisplayFormat.FormatString = "N2"
        Me.GridColumnPOSubTot.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPOSubTot.FieldName = "sub_total"
        Me.GridColumnPOSubTot.Name = "GridColumnPOSubTot"
        Me.GridColumnPOSubTot.OptionsColumn.AllowEdit = False
        Me.GridColumnPOSubTot.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sub_total", "{0:N2}")})
        Me.GridColumnPOSubTot.UnboundExpression = "([val_po] - [discount]) * [qty_po]"
        Me.GridColumnPOSubTot.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnPOSubTot.Visible = True
        Me.GridColumnPOSubTot.VisibleIndex = 6
        Me.GridColumnPOSubTot.Width = 239
        '
        'GridColumnPOVal
        '
        Me.GridColumnPOVal.Caption = "Value"
        Me.GridColumnPOVal.ColumnEdit = Me.RITEVal
        Me.GridColumnPOVal.DisplayFormat.FormatString = "N2"
        Me.GridColumnPOVal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPOVal.FieldName = "val_po"
        Me.GridColumnPOVal.Name = "GridColumnPOVal"
        Me.GridColumnPOVal.Visible = True
        Me.GridColumnPOVal.VisibleIndex = 3
        Me.GridColumnPOVal.Width = 174
        '
        'RITEVal
        '
        Me.RITEVal.AutoHeight = False
        Me.RITEVal.DisplayFormat.FormatString = "N2"
        Me.RITEVal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITEVal.Mask.EditMask = "N2"
        Me.RITEVal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RITEVal.Name = "RITEVal"
        '
        'GridColumnDiscPercent
        '
        Me.GridColumnDiscPercent.Caption = "Discount (%)"
        Me.GridColumnDiscPercent.ColumnEdit = Me.RITEVal
        Me.GridColumnDiscPercent.DisplayFormat.FormatString = "N2"
        Me.GridColumnDiscPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDiscPercent.FieldName = "discount_percent"
        Me.GridColumnDiscPercent.Name = "GridColumnDiscPercent"
        Me.GridColumnDiscPercent.Visible = True
        Me.GridColumnDiscPercent.VisibleIndex = 4
        Me.GridColumnDiscPercent.Width = 78
        '
        'GridColumnDisc
        '
        Me.GridColumnDisc.Caption = "Discount"
        Me.GridColumnDisc.ColumnEdit = Me.RITEVal
        Me.GridColumnDisc.DisplayFormat.FormatString = "N2"
        Me.GridColumnDisc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDisc.FieldName = "discount"
        Me.GridColumnDisc.Name = "GridColumnDisc"
        Me.GridColumnDisc.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "discount", "{0:N2}")})
        Me.GridColumnDisc.Visible = True
        Me.GridColumnDisc.VisibleIndex = 5
        Me.GridColumnDisc.Width = 161
        '
        'RepositoryItemSpinEdit2
        '
        Me.RepositoryItemSpinEdit2.AutoHeight = False
        Me.RepositoryItemSpinEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit2.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit2.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit2.Name = "RepositoryItemSpinEdit2"
        '
        'RepositoryItemSearchLookUpEdit1
        '
        Me.RepositoryItemSearchLookUpEdit1.AutoHeight = False
        Me.RepositoryItemSearchLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSearchLookUpEdit1.Name = "RepositoryItemSearchLookUpEdit1"
        Me.RepositoryItemSearchLookUpEdit1.NullText = "-- Choose item --"
        Me.RepositoryItemSearchLookUpEdit1.View = Me.GridView3
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "ID Item"
        Me.GridColumn16.FieldName = "id_item"
        Me.GridColumn16.Name = "GridColumn16"
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Category"
        Me.GridColumn17.FieldName = "item_cat"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 1
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Item Description"
        Me.GridColumn18.FieldName = "item_desc"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 0
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "UOM"
        Me.GridColumn19.FieldName = "uom"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 3
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Budget Remaining"
        Me.GridColumn20.DisplayFormat.FormatString = "N0"
        Me.GridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn20.FieldName = "budget_remaining"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 2
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0002543131!, 79.58336!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(626.9999!, 25.0!)
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
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBox1, Me.XrLabel7, Me.XrLine1, Me.LPoNumber})
        Me.TopMargin.HeightF = 56.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 6.610268!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(210.4167!, 39.58334!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLabel7
        '
        Me.XrLabel7.Font = New System.Drawing.Font("Franklin Gothic Demi", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(282.2917!, 6.19356!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(344.7085!, 26.4167!)
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "Purchase Order"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0002617929!, 46.19361!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(626.9999!, 9.458328!)
        '
        'LPoNumber
        '
        Me.LPoNumber.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.LPoNumber.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LPoNumber.LocationFloat = New DevExpress.Utils.PointFloat(442.6248!, 32.61026!)
        Me.LPoNumber.Name = "LPoNumber"
        Me.LPoNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LPoNumber.SizeF = New System.Drawing.SizeF(184.3751!, 13.58335!)
        Me.LPoNumber.StylePriority.UseBorders = False
        Me.LPoNumber.StylePriority.UseFont = False
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1, Me.XrLabel22, Me.LCreateDate})
        Me.BottomMargin.HeightF = 20.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(477.0001!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 19.7596!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel22
        '
        Me.XrLabel22.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel22.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel22.Name = "XrLabel22"
        Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel22.SizeF = New System.Drawing.SizeF(59.37467!, 20.0!)
        Me.XrLabel22.StylePriority.UseBorders = False
        Me.XrLabel22.StylePriority.UseFont = False
        Me.XrLabel22.Text = "PO Date :"
        '
        'LCreateDate
        '
        Me.LCreateDate.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LCreateDate.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCreateDate.LocationFloat = New DevExpress.Utils.PointFloat(59.37465!, 0!)
        Me.LCreateDate.Name = "LCreateDate"
        Me.LCreateDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LCreateDate.SizeF = New System.Drawing.SizeF(169.7918!, 19.7596!)
        Me.LCreateDate.StylePriority.UseBorders = False
        Me.LCreateDate.StylePriority.UseFont = False
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine2, Me.XrLabel16, Me.LTo, Me.XrLabel1, Me.LShipToAddress, Me.LShipTo, Me.LabelAttn, Me.LToAdress, Me.XrTable2})
        Me.ReportHeader.HeightF = 119.7085!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrLine2
        '
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 110.2502!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(626.9999!, 9.458328!)
        '
        'XrLabel16
        '
        Me.XrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel16.Font = New System.Drawing.Font("Segoe UI", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel16.Name = "XrLabel16"
        Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel16.SizeF = New System.Drawing.SizeF(33.33327!, 17.08342!)
        Me.XrLabel16.StylePriority.UseBorders = False
        Me.XrLabel16.StylePriority.UseFont = False
        Me.XrLabel16.Text = "To :"
        '
        'LTo
        '
        Me.LTo.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LTo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTo.LocationFloat = New DevExpress.Utils.PointFloat(0!, 30.66677!)
        Me.LTo.Name = "LTo"
        Me.LTo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTo.SizeF = New System.Drawing.SizeF(267.7084!, 13.58335!)
        Me.LTo.StylePriority.UseBorders = False
        Me.LTo.StylePriority.UseFont = False
        '
        'XrLabel1
        '
        Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(347.8331!, 0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(55.20828!, 20.00001!)
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.Text = "Ship To :"
        '
        'LShipToAddress
        '
        Me.LShipToAddress.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LShipToAddress.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LShipToAddress.LocationFloat = New DevExpress.Utils.PointFloat(347.8331!, 33.58335!)
        Me.LShipToAddress.Name = "LShipToAddress"
        Me.LShipToAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100.0!)
        Me.LShipToAddress.SizeF = New System.Drawing.SizeF(279.1668!, 40.66676!)
        Me.LShipToAddress.StylePriority.UseBorders = False
        Me.LShipToAddress.StylePriority.UseFont = False
        Me.LShipToAddress.StylePriority.UsePadding = False
        '
        'LShipTo
        '
        Me.LShipTo.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LShipTo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LShipTo.LocationFloat = New DevExpress.Utils.PointFloat(347.8331!, 20.00001!)
        Me.LShipTo.Name = "LShipTo"
        Me.LShipTo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LShipTo.SizeF = New System.Drawing.SizeF(279.1667!, 13.58335!)
        Me.LShipTo.StylePriority.UseBorders = False
        Me.LShipTo.StylePriority.UseFont = False
        '
        'LabelAttn
        '
        Me.LabelAttn.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelAttn.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAttn.LocationFloat = New DevExpress.Utils.PointFloat(0.0002543131!, 17.08342!)
        Me.LabelAttn.Name = "LabelAttn"
        Me.LabelAttn.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelAttn.SizeF = New System.Drawing.SizeF(267.7081!, 13.58335!)
        Me.LabelAttn.StylePriority.UseBorders = False
        Me.LabelAttn.StylePriority.UseFont = False
        '
        'LToAdress
        '
        Me.LToAdress.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LToAdress.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LToAdress.LocationFloat = New DevExpress.Utils.PointFloat(0!, 44.25011!)
        Me.LToAdress.Name = "LToAdress"
        Me.LToAdress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100.0!)
        Me.LToAdress.SizeF = New System.Drawing.SizeF(267.7084!, 30.0!)
        Me.LToAdress.StylePriority.UseBorders = False
        Me.LToAdress.StylePriority.UseFont = False
        Me.LToAdress.StylePriority.UsePadding = False
        '
        'XrTable2
        '
        Me.XrTable2.BorderColor = System.Drawing.Color.Black
        Me.XrTable2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTable2.Font = New System.Drawing.Font("Segoe UI", 7.5!)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(0.0002543131!, 74.25012!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100.0!)
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2, Me.XrTableRow3})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(626.9997!, 30.00002!)
        Me.XrTable2.StylePriority.UseBorderColor = False
        Me.XrTable2.StylePriority.UseBorders = False
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.StylePriority.UsePadding = False
        Me.XrTable2.StylePriority.UseTextAlignment = False
        Me.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell2, Me.XrTableCell3, Me.XrTableCell4, Me.XrTableCell5, Me.XrTableCell6})
        Me.XrTableRow2.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Underline)
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.StylePriority.UseFont = False
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Font = New System.Drawing.Font("Segoe UI", 7.5!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.StylePriority.UseFont = False
        Me.XrTableCell2.Text = "Term of payment"
        Me.XrTableCell2.Weight = 1.3907644762237288R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Font = New System.Drawing.Font("Segoe UI", 7.5!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.StylePriority.UseFont = False
        Me.XrTableCell3.Text = "Payment Due Date"
        Me.XrTableCell3.Weight = 1.4422742508780717R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Font = New System.Drawing.Font("Segoe UI", 7.5!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.StylePriority.UseFont = False
        Me.XrTableCell4.Text = "Term of order"
        Me.XrTableCell4.Weight = 1.3392546616124403R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Font = New System.Drawing.Font("Segoe UI", 7.5!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.StylePriority.UseFont = False
        Me.XrTableCell5.Text = "ETA Date"
        Me.XrTableCell5.Weight = 1.2362351188190641R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Font = New System.Drawing.Font("Segoe UI", 7.5!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.StylePriority.UseFont = False
        Me.XrTableCell6.Text = "Ship Via"
        Me.XrTableCell6.Weight = 1.6686443016134729R
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.LTerm, Me.LPaymentDueDate, Me.LTermOrder, Me.LEstRecDate, Me.LShipVia})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.0R
        '
        'LTerm
        '
        Me.LTerm.BorderColor = System.Drawing.Color.LightGray
        Me.LTerm.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LTerm.BorderWidth = 1.0!
        Me.LTerm.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Italic)
        Me.LTerm.Name = "LTerm"
        Me.LTerm.StylePriority.UseBorderColor = False
        Me.LTerm.StylePriority.UseBorders = False
        Me.LTerm.StylePriority.UseBorderWidth = False
        Me.LTerm.StylePriority.UseFont = False
        Me.LTerm.Text = "LTerm"
        Me.LTerm.Weight = 1.3907645691086596R
        '
        'LPaymentDueDate
        '
        Me.LPaymentDueDate.BorderColor = System.Drawing.Color.LightGray
        Me.LPaymentDueDate.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LPaymentDueDate.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Italic)
        Me.LPaymentDueDate.Name = "LPaymentDueDate"
        Me.LPaymentDueDate.StylePriority.UseBorderColor = False
        Me.LPaymentDueDate.StylePriority.UseBorders = False
        Me.LPaymentDueDate.StylePriority.UseFont = False
        Me.LPaymentDueDate.Text = "LPaymentDueDate"
        Me.LPaymentDueDate.Weight = 1.4422743210066287R
        '
        'LTermOrder
        '
        Me.LTermOrder.BorderColor = System.Drawing.Color.LightGray
        Me.LTermOrder.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LTermOrder.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Italic)
        Me.LTermOrder.Name = "LTermOrder"
        Me.LTermOrder.StylePriority.UseBorderColor = False
        Me.LTermOrder.StylePriority.UseBorders = False
        Me.LTermOrder.StylePriority.UseFont = False
        Me.LTermOrder.Text = "LTermOrder"
        Me.LTermOrder.Weight = 1.3392547179066019R
        '
        'LEstRecDate
        '
        Me.LEstRecDate.BorderColor = System.Drawing.Color.LightGray
        Me.LEstRecDate.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LEstRecDate.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Italic)
        Me.LEstRecDate.Name = "LEstRecDate"
        Me.LEstRecDate.StylePriority.UseBorderColor = False
        Me.LEstRecDate.StylePriority.UseBorders = False
        Me.LEstRecDate.StylePriority.UseFont = False
        Me.LEstRecDate.Text = "LEstRecDate"
        Me.LEstRecDate.Weight = 1.2362351602535013R
        '
        'LShipVia
        '
        Me.LShipVia.BorderColor = System.Drawing.Color.LightGray
        Me.LShipVia.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LShipVia.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Italic)
        Me.LShipVia.Name = "LShipVia"
        Me.LShipVia.StylePriority.UseBorderColor = False
        Me.LShipVia.StylePriority.UseBorders = False
        Me.LShipVia.StylePriority.UseFont = False
        Me.LShipVia.Text = "LShipVia"
        Me.LShipVia.Weight = 1.6686443627121017R
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LNote, Me.XrLabel2, Me.XrTable4, Me.XrTable3, Me.XrTable1, Me.XrTable5, Me.XrTable6})
        Me.ReportFooter.HeightF = 104.5834!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrTable3
        '
        Me.XrTable3.LocationFloat = New DevExpress.Utils.PointFloat(347.8329!, 0!)
        Me.XrTable3.Name = "XrTable3"
        Me.XrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow4})
        Me.XrTable3.SizeF = New System.Drawing.SizeF(279.1668!, 19.79166!)
        Me.XrTable3.StylePriority.UseTextAlignment = False
        Me.XrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell7, Me.LTotal})
        Me.XrTableRow4.Name = "XrTableRow4"
        Me.XrTableRow4.Weight = 1.0R
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.Text = "Total"
        Me.XrTableCell7.Weight = 1.3133413696289062R
        '
        'LTotal
        '
        Me.LTotal.Name = "LTotal"
        Me.LTotal.StylePriority.UseTextAlignment = False
        Me.LTotal.Text = "LTotal"
        Me.LTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.LTotal.Weight = 1.4783270263671873R
        '
        'XrTable4
        '
        Me.XrTable4.LocationFloat = New DevExpress.Utils.PointFloat(347.8331!, 19.79167!)
        Me.XrTable4.Name = "XrTable4"
        Me.XrTable4.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow5})
        Me.XrTable4.SizeF = New System.Drawing.SizeF(279.1671!, 19.79166!)
        Me.XrTable4.StylePriority.UseTextAlignment = False
        Me.XrTable4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow5
        '
        Me.XrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell8, Me.LDiscount})
        Me.XrTableRow5.Name = "XrTableRow5"
        Me.XrTableRow5.Weight = 1.0R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.Text = "Discount"
        Me.XrTableCell8.Weight = 1.3133386230468749R
        '
        'LDiscount
        '
        Me.LDiscount.Name = "LDiscount"
        Me.LDiscount.StylePriority.UseTextAlignment = False
        Me.LDiscount.Text = "LTotal"
        Me.LDiscount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.LDiscount.Weight = 1.4783319091796876R
        '
        'XrTable5
        '
        Me.XrTable5.LocationFloat = New DevExpress.Utils.PointFloat(347.8331!, 39.58333!)
        Me.XrTable5.Name = "XrTable5"
        Me.XrTable5.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow6})
        Me.XrTable5.SizeF = New System.Drawing.SizeF(279.1666!, 19.79166!)
        Me.XrTable5.StylePriority.UseTextAlignment = False
        Me.XrTable5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow6
        '
        Me.XrTableRow6.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell10, Me.LVat})
        Me.XrTableRow6.Name = "XrTableRow6"
        Me.XrTableRow6.Weight = 1.0R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.Text = "VAT"
        Me.XrTableCell10.Weight = 1.3133383178710938R
        '
        'LVat
        '
        Me.LVat.Name = "LVat"
        Me.LVat.StylePriority.UseTextAlignment = False
        Me.LVat.Text = "LTotal"
        Me.LVat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.LVat.Weight = 1.47832763671875R
        '
        'XrTable6
        '
        Me.XrTable6.LocationFloat = New DevExpress.Utils.PointFloat(347.8331!, 59.375!)
        Me.XrTable6.Name = "XrTable6"
        Me.XrTable6.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow7})
        Me.XrTable6.SizeF = New System.Drawing.SizeF(279.1671!, 19.79166!)
        Me.XrTable6.StylePriority.UseTextAlignment = False
        Me.XrTable6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow7
        '
        Me.XrTableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell12, Me.LGrandTotal})
        Me.XrTableRow7.Name = "XrTableRow7"
        Me.XrTableRow7.Weight = 1.0R
        '
        'XrTableCell12
        '
        Me.XrTableCell12.Name = "XrTableCell12"
        Me.XrTableCell12.Text = "GRAND TOTAL"
        Me.XrTableCell12.Weight = 1.3133395385742186R
        '
        'LGrandTotal
        '
        Me.LGrandTotal.Name = "LGrandTotal"
        Me.LGrandTotal.StylePriority.UseTextAlignment = False
        Me.LGrandTotal.Text = "LTotal"
        Me.LGrandTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.LGrandTotal.Weight = 1.478331298828125R
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.0002861023!, 0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(347.8329!, 13.58335!)
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Note :"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'LNote
        '
        Me.LNote.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LNote.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LNote.LocationFloat = New DevExpress.Utils.PointFloat(0!, 13.58337!)
        Me.LNote.Name = "LNote"
        Me.LNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100.0!)
        Me.LNote.SizeF = New System.Drawing.SizeF(347.8329!, 65.58329!)
        Me.LNote.StylePriority.UseBorders = False
        Me.LNote.StylePriority.UseFont = False
        Me.LNote.StylePriority.UsePadding = False
        Me.LNote.StylePriority.UseTextAlignment = False
        Me.LNote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportPurcOrder
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter})
        Me.Margins = New System.Drawing.Printing.Margins(100, 100, 56, 20)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEVal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCSummary As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSummary As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnPOIdItem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPOItemDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyPO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPOUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnValQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPOSubTot As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPOVal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RITEVal As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumnDiscPercent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDisc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents LabelAttn As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LToAdress As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LShipToAddress As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LShipTo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LCreateDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LPoNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents LTerm As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents LPaymentDueDate As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents LTermOrder As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents LEstRecDate As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents LShipVia As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable4 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents LDiscount As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable3 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents LTotal As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable5 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow6 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents LVat As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable6 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow7 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents LGrandTotal As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LNote As DevExpress.XtraReports.UI.XRLabel
End Class
