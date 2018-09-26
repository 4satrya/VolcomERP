<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBudgetExpenseProposeFormatXLS
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GCMonthly = New DevExpress.XtraGrid.GridControl()
        Me.GVMonthly = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnJan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumnFeb = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMarch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnApril = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMay = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnJune = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnJuly = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAugust = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNov = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1Dec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotalInput = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAcc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnYear = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.GCMonthly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMonthly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCMonthly
        '
        Me.GCMonthly.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMonthly.Location = New System.Drawing.Point(0, 0)
        Me.GCMonthly.MainView = Me.GVMonthly
        Me.GCMonthly.Name = "GCMonthly"
        Me.GCMonthly.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemTextEdit1})
        Me.GCMonthly.Size = New System.Drawing.Size(675, 486)
        Me.GCMonthly.TabIndex = 13
        Me.GCMonthly.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMonthly})
        '
        'GVMonthly
        '
        Me.GVMonthly.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnno, Me.GridColumnJan, Me.GridColumnFeb, Me.GridColumnMarch, Me.GridColumnApril, Me.GridColumnMay, Me.GridColumnJune, Me.GridColumnJuly, Me.GridColumnAugust, Me.GridColumnSept, Me.GridColumnOct, Me.GridColumnNov, Me.GridColumn1Dec, Me.GridColumnTotalInput, Me.GridColumnAcc, Me.GridColumn6, Me.GridColumnCat, Me.GridColumnYear})
        Me.GVMonthly.GridControl = Me.GCMonthly
        Me.GVMonthly.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "1", Me.GridColumnJan, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "2", Me.GridColumnFeb, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "3", Me.GridColumnMarch, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "4", Me.GridColumnApril, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "5", Me.GridColumnMay, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "6", Me.GridColumnJune, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "7", Me.GridColumnJuly, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "8", Me.GridColumnAugust, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "9", Me.GridColumnSept, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "10", Me.GridColumnOct, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "11", Me.GridColumnNov, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "12", Me.GridColumn1Dec, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_input", Me.GridColumnTotalInput, "{0:N2}")})
        Me.GVMonthly.Name = "GVMonthly"
        Me.GVMonthly.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVMonthly.OptionsView.ColumnAutoWidth = False
        Me.GVMonthly.OptionsView.ShowFooter = True
        Me.GVMonthly.OptionsView.ShowGroupedColumns = True
        Me.GVMonthly.OptionsView.ShowGroupPanel = False
        '
        'GridColumnno
        '
        Me.GridColumnno.Caption = "No"
        Me.GridColumnno.FieldName = "no"
        Me.GridColumnno.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnno.Name = "GridColumnno"
        Me.GridColumnno.OptionsColumn.AllowEdit = False
        Me.GridColumnno.Width = 48
        '
        'GridColumnJan
        '
        Me.GridColumnJan.Caption = "January"
        Me.GridColumnJan.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnJan.DisplayFormat.FormatString = "n2"
        Me.GridColumnJan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnJan.FieldName = "1"
        Me.GridColumnJan.Name = "GridColumnJan"
        Me.GridColumnJan.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "1", "{0:n2}")})
        Me.GridColumnJan.Visible = True
        Me.GridColumnJan.VisibleIndex = 3
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "-"
        '
        'GridColumnFeb
        '
        Me.GridColumnFeb.Caption = "February"
        Me.GridColumnFeb.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnFeb.DisplayFormat.FormatString = "n2"
        Me.GridColumnFeb.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnFeb.FieldName = "2"
        Me.GridColumnFeb.Name = "GridColumnFeb"
        Me.GridColumnFeb.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "2", "{0:n2}")})
        Me.GridColumnFeb.Visible = True
        Me.GridColumnFeb.VisibleIndex = 4
        '
        'GridColumnMarch
        '
        Me.GridColumnMarch.Caption = "March"
        Me.GridColumnMarch.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnMarch.DisplayFormat.FormatString = "n2"
        Me.GridColumnMarch.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnMarch.FieldName = "3"
        Me.GridColumnMarch.Name = "GridColumnMarch"
        Me.GridColumnMarch.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "3", "{0:n2}")})
        Me.GridColumnMarch.Visible = True
        Me.GridColumnMarch.VisibleIndex = 5
        '
        'GridColumnApril
        '
        Me.GridColumnApril.Caption = "April"
        Me.GridColumnApril.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnApril.DisplayFormat.FormatString = "n2"
        Me.GridColumnApril.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnApril.FieldName = "4"
        Me.GridColumnApril.Name = "GridColumnApril"
        Me.GridColumnApril.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "4", "{0:n2}")})
        Me.GridColumnApril.Visible = True
        Me.GridColumnApril.VisibleIndex = 6
        '
        'GridColumnMay
        '
        Me.GridColumnMay.Caption = "May"
        Me.GridColumnMay.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnMay.DisplayFormat.FormatString = "n2"
        Me.GridColumnMay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnMay.FieldName = "5"
        Me.GridColumnMay.Name = "GridColumnMay"
        Me.GridColumnMay.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "5", "{0:n2}")})
        Me.GridColumnMay.Visible = True
        Me.GridColumnMay.VisibleIndex = 7
        '
        'GridColumnJune
        '
        Me.GridColumnJune.Caption = "June"
        Me.GridColumnJune.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnJune.DisplayFormat.FormatString = "n2"
        Me.GridColumnJune.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnJune.FieldName = "6"
        Me.GridColumnJune.Name = "GridColumnJune"
        Me.GridColumnJune.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "6", "{0:n2}")})
        Me.GridColumnJune.Visible = True
        Me.GridColumnJune.VisibleIndex = 8
        '
        'GridColumnJuly
        '
        Me.GridColumnJuly.Caption = "July"
        Me.GridColumnJuly.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnJuly.DisplayFormat.FormatString = "n2"
        Me.GridColumnJuly.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnJuly.FieldName = "7"
        Me.GridColumnJuly.Name = "GridColumnJuly"
        Me.GridColumnJuly.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "7", "{0:n2}")})
        Me.GridColumnJuly.Visible = True
        Me.GridColumnJuly.VisibleIndex = 9
        '
        'GridColumnAugust
        '
        Me.GridColumnAugust.Caption = "August"
        Me.GridColumnAugust.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnAugust.DisplayFormat.FormatString = "n2"
        Me.GridColumnAugust.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAugust.FieldName = "8"
        Me.GridColumnAugust.Name = "GridColumnAugust"
        Me.GridColumnAugust.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "8", "{0:n2}")})
        Me.GridColumnAugust.Visible = True
        Me.GridColumnAugust.VisibleIndex = 10
        '
        'GridColumnSept
        '
        Me.GridColumnSept.Caption = "September"
        Me.GridColumnSept.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnSept.DisplayFormat.FormatString = "n2"
        Me.GridColumnSept.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnSept.FieldName = "9"
        Me.GridColumnSept.Name = "GridColumnSept"
        Me.GridColumnSept.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "9", "{0:n2}")})
        Me.GridColumnSept.Visible = True
        Me.GridColumnSept.VisibleIndex = 11
        '
        'GridColumnOct
        '
        Me.GridColumnOct.Caption = "October"
        Me.GridColumnOct.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnOct.DisplayFormat.FormatString = "n2"
        Me.GridColumnOct.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOct.FieldName = "10"
        Me.GridColumnOct.Name = "GridColumnOct"
        Me.GridColumnOct.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "10", "{0:n2}")})
        Me.GridColumnOct.Visible = True
        Me.GridColumnOct.VisibleIndex = 12
        '
        'GridColumnNov
        '
        Me.GridColumnNov.Caption = "November"
        Me.GridColumnNov.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnNov.DisplayFormat.FormatString = "n2"
        Me.GridColumnNov.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnNov.FieldName = "11"
        Me.GridColumnNov.Name = "GridColumnNov"
        Me.GridColumnNov.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "11", "{0:n2}")})
        Me.GridColumnNov.Visible = True
        Me.GridColumnNov.VisibleIndex = 13
        '
        'GridColumn1Dec
        '
        Me.GridColumn1Dec.Caption = "December"
        Me.GridColumn1Dec.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumn1Dec.DisplayFormat.FormatString = "n2"
        Me.GridColumn1Dec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn1Dec.FieldName = "12"
        Me.GridColumn1Dec.Name = "GridColumn1Dec"
        Me.GridColumn1Dec.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "12", "{0:n2}")})
        Me.GridColumn1Dec.Visible = True
        Me.GridColumn1Dec.VisibleIndex = 14
        '
        'GridColumnTotalInput
        '
        Me.GridColumnTotalInput.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnTotalInput.AppearanceCell.Options.UseFont = True
        Me.GridColumnTotalInput.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnTotalInput.AppearanceHeader.Options.UseFont = True
        Me.GridColumnTotalInput.Caption = "Total"
        Me.GridColumnTotalInput.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotalInput.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotalInput.FieldName = "total_input"
        Me.GridColumnTotalInput.Name = "GridColumnTotalInput"
        Me.GridColumnTotalInput.OptionsColumn.AllowEdit = False
        Me.GridColumnTotalInput.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_input", "{0:N2}")})
        Me.GridColumnTotalInput.UnboundExpression = "[1] + [2] + [3] + [4] + [5] + [6] + [7] + [8] + [9] + [10] + [11] + [12]"
        Me.GridColumnTotalInput.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnTotalInput.Visible = True
        Me.GridColumnTotalInput.VisibleIndex = 15
        '
        'GridColumnAcc
        '
        Me.GridColumnAcc.Caption = "Code"
        Me.GridColumnAcc.FieldName = "exp_acc"
        Me.GridColumnAcc.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnAcc.Name = "GridColumnAcc"
        Me.GridColumnAcc.OptionsColumn.AllowEdit = False
        Me.GridColumnAcc.Visible = True
        Me.GridColumnAcc.VisibleIndex = 0
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Description"
        Me.GridColumn6.FieldName = "exp_description"
        Me.GridColumn6.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        '
        'GridColumnCat
        '
        Me.GridColumnCat.Caption = "Category"
        Me.GridColumnCat.FieldName = "item_cat"
        Me.GridColumnCat.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnCat.Name = "GridColumnCat"
        Me.GridColumnCat.OptionsColumn.AllowEdit = False
        Me.GridColumnCat.Visible = True
        Me.GridColumnCat.VisibleIndex = 2
        '
        'GridColumnYear
        '
        Me.GridColumnYear.Caption = "GridColumn7"
        Me.GridColumnYear.FieldName = "year"
        Me.GridColumnYear.Name = "GridColumnYear"
        Me.GridColumnYear.OptionsColumn.AllowEdit = False
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullText = "-"
        '
        'FormBudgetExpenseProposeFormatXLS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 486)
        Me.Controls.Add(Me.GCMonthly)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormBudgetExpenseProposeFormatXLS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exporting to XLS . . ."
        CType(Me.GCMonthly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMonthly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCMonthly As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMonthly As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnJan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumnFeb As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMarch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnApril As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMay As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnJune As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnJuly As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAugust As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNov As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1Dec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotalInput As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAcc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnYear As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
