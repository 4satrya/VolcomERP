﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStockUniS78New
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GCDesignList = New DevExpress.XtraGrid.GridControl()
        Me.GVDesignList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCurPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCurStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPoint = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GCDesignList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDesignList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCDesignList
        '
        Me.GCDesignList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDesignList.Location = New System.Drawing.Point(0, 0)
        Me.GCDesignList.MainView = Me.GVDesignList
        Me.GCDesignList.Name = "GCDesignList"
        Me.GCDesignList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit2})
        Me.GCDesignList.Size = New System.Drawing.Size(777, 413)
        Me.GCDesignList.TabIndex = 6
        Me.GCDesignList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDesignList})
        '
        'GVDesignList
        '
        Me.GVDesignList.ColumnPanelRowHeight = 40
        Me.GVDesignList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn8, Me.GridColumn14, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30, Me.GridColumnCurPrice, Me.GridColumnPriceType, Me.GridColumnCurStatus, Me.GridColumnNo, Me.GridColumnPoint})
        Me.GVDesignList.GridControl = Me.GCDesignList
        Me.GVDesignList.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "1", Me.GridColumn20, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "2", Me.GridColumn21, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "3", Me.GridColumn22, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "4", Me.GridColumn23, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "5", Me.GridColumn24, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "6", Me.GridColumn25, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "7", Me.GridColumn26, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "8", Me.GridColumn27, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "9", Me.GridColumn28, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "0", Me.GridColumn29, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_qty", Me.GridColumn30, "{0:N0}")})
        Me.GVDesignList.Name = "GVDesignList"
        Me.GVDesignList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDesignList.OptionsFind.AlwaysVisible = True
        Me.GVDesignList.OptionsPrint.AllowMultilineHeaders = True
        Me.GVDesignList.OptionsView.ColumnAutoWidth = False
        Me.GVDesignList.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVDesignList.OptionsView.ShowFooter = True
        Me.GVDesignList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "CODE"
        Me.GridColumn2.FieldName = "code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 122
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "STYLE"
        Me.GridColumn8.FieldName = "name"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 2
        Me.GridColumn8.Width = 258
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "SIZETYPE"
        Me.GridColumn14.FieldName = "sizetype"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 4
        Me.GridColumn14.Width = 124
        '
        'GridColumn20
        '
        Me.GridColumn20.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn20.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn20.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn20.DisplayFormat.FormatString = "N0"
        Me.GridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn20.FieldName = "1"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "1", "{0:N0}")})
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 5
        Me.GridColumn20.Width = 68
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        Me.RepositoryItemTextEdit2.NullText = "-"
        '
        'GridColumn21
        '
        Me.GridColumn21.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn21.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn21.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn21.DisplayFormat.FormatString = "N0"
        Me.GridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn21.FieldName = "2"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "2", "{0:N0}")})
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 6
        Me.GridColumn21.Width = 64
        '
        'GridColumn22
        '
        Me.GridColumn22.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn22.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn22.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn22.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn22.DisplayFormat.FormatString = "N0"
        Me.GridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn22.FieldName = "3"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "3", "{0:N0}")})
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 7
        Me.GridColumn22.Width = 60
        '
        'GridColumn23
        '
        Me.GridColumn23.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn23.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn23.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn23.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn23.DisplayFormat.FormatString = "N0"
        Me.GridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn23.FieldName = "4"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "4", "{0:N0}")})
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 8
        Me.GridColumn23.Width = 59
        '
        'GridColumn24
        '
        Me.GridColumn24.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn24.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn24.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn24.DisplayFormat.FormatString = "N0"
        Me.GridColumn24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn24.FieldName = "5"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "5", "{0:N0}")})
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 9
        Me.GridColumn24.Width = 63
        '
        'GridColumn25
        '
        Me.GridColumn25.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn25.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn25.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn25.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn25.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn25.DisplayFormat.FormatString = "N0"
        Me.GridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn25.FieldName = "6"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "6", "{0:N0}")})
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 10
        Me.GridColumn25.Width = 57
        '
        'GridColumn26
        '
        Me.GridColumn26.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn26.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn26.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn26.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn26.DisplayFormat.FormatString = "N0"
        Me.GridColumn26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn26.FieldName = "7"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "7", "{0:N0}")})
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 11
        Me.GridColumn26.Width = 64
        '
        'GridColumn27
        '
        Me.GridColumn27.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn27.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn27.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn27.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn27.DisplayFormat.FormatString = "N0"
        Me.GridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn27.FieldName = "8"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "8", "{0:N0}")})
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 12
        '
        'GridColumn28
        '
        Me.GridColumn28.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn28.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn28.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn28.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn28.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn28.DisplayFormat.FormatString = "N0"
        Me.GridColumn28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn28.FieldName = "9"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "9", "{0:N0}")})
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 13
        Me.GridColumn28.Width = 72
        '
        'GridColumn29
        '
        Me.GridColumn29.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn29.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn29.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn29.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn29.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn29.DisplayFormat.FormatString = "N0"
        Me.GridColumn29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn29.FieldName = "0"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "0", "{0:N0}")})
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 14
        Me.GridColumn29.Width = 79
        '
        'GridColumn30
        '
        Me.GridColumn30.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn30.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn30.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn30.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn30.Caption = "TTL"
        Me.GridColumn30.DisplayFormat.FormatString = "N0"
        Me.GridColumn30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn30.FieldName = "total_qty"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_qty", "{0:N0}")})
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 15
        Me.GridColumn30.Width = 106
        '
        'GridColumnCurPrice
        '
        Me.GridColumnCurPrice.Caption = "CURRENT PRICE"
        Me.GridColumnCurPrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnCurPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCurPrice.FieldName = "design_price"
        Me.GridColumnCurPrice.Name = "GridColumnCurPrice"
        Me.GridColumnCurPrice.Width = 106
        '
        'GridColumnPriceType
        '
        Me.GridColumnPriceType.Caption = "CURRENT PRICE TYPE"
        Me.GridColumnPriceType.FieldName = "design_price_type"
        Me.GridColumnPriceType.Name = "GridColumnPriceType"
        Me.GridColumnPriceType.Width = 106
        '
        'GridColumnCurStatus
        '
        Me.GridColumnCurStatus.Caption = "CURRENT STATUS"
        Me.GridColumnCurStatus.FieldName = "design_cat"
        Me.GridColumnCurStatus.Name = "GridColumnCurStatus"
        Me.GridColumnCurStatus.Width = 106
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "NO"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 43
        '
        'GridColumnPoint
        '
        Me.GridColumnPoint.Caption = "POINT"
        Me.GridColumnPoint.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumnPoint.DisplayFormat.FormatString = "N2"
        Me.GridColumnPoint.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPoint.FieldName = "point"
        Me.GridColumnPoint.Name = "GridColumnPoint"
        Me.GridColumnPoint.Visible = True
        Me.GridColumnPoint.VisibleIndex = 3
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 413)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(777, 43)
        Me.PanelControl1.TabIndex = 7
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton1.Location = New System.Drawing.Point(700, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 39)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "SimpleButton1"
        '
        'FormStockUniS78New
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 456)
        Me.Controls.Add(Me.GCDesignList)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormStockUniS78New"
        Me.Text = "FormStockUniS78New"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GCDesignList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDesignList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCDesignList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDesignList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCurPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCurStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPoint As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
