<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ReportItemExpense
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportItemExpense))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdAcc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnaccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSearchLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GCCC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RISLECC = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBudgetType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RISLEType = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RepositoryItemSearchLookUpEdit2View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBudget = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RISLECatExpense = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBefKurs = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumnCurr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RISLECurrency = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnKurs = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTaxPercent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumnTaxValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPPHCOA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RISLECOAPPH = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPPHPercent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumnPPH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPPHDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GridColumnAccountDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBudgetTypeDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBudgetDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GCCCDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCurrView = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.LabelNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.LpayFromMark = New DevExpress.XtraReports.UI.XRLabel()
        Me.LpayFromTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.LPayFrom = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelPaymentStatus = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelBeneficiary = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelDotBeneficiary = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelTitleBeneficiary = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelTitleDueDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelDotDueDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelDUelDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelPaymentMethod = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.LSay = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.LNotex = New DevExpress.XtraReports.UI.XRLabel()
        Me.LNote = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelTotalPayment = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.LInvNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.LUnit = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RISLECC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RISLEType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit2View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RISLECatExpense, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RISLECurrency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RISLECOAPPH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 145.9166!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(772.9999!, 145.9166!)
        Me.WinControlContainer1.WinControl = Me.GCData
        '
        'GCData
        '
        Me.GCData.Location = New System.Drawing.Point(0, 38)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSearchLookUpEdit1, Me.RepositoryItemTextEdit1, Me.RepositoryItemSpinEdit1, Me.RISLEType, Me.RISLECatExpense, Me.RISLECC, Me.RISLECOAPPH, Me.RepositoryItemTextEdit2, Me.RepositoryItemTextEdit3, Me.RISLECurrency, Me.RepositoryItemMemoEdit1, Me.RepositoryItemMemoEdit2, Me.RepositoryItemMemoEdit3})
        Me.GCData.Size = New System.Drawing.Size(742, 140)
        Me.GCData.TabIndex = 18
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.AppearancePrint.HeaderPanel.Options.UseTextOptions = True
        Me.GVData.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GVData.ColumnPanelRowHeight = 20
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdAcc, Me.GridColumnNo, Me.GridColumnaccount, Me.GridColumnDescription, Me.GCCC, Me.GridColumnBudgetType, Me.GridColumnBudget, Me.GridColumnBefKurs, Me.GridColumnCurr, Me.GridColumnKurs, Me.GridColumnTaxPercent, Me.GridColumnTaxValue, Me.GridColumnAmount, Me.GridColumnPPHCOA, Me.GridColumnPPHPercent, Me.GridColumnPPH, Me.GridColumnPPHDesc, Me.GridColumnAccountDescription, Me.GridColumnBudgetTypeDesc, Me.GridColumnBudgetDesc, Me.GCCCDesc, Me.GridColumnCurrView})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsPrint.AllowMultilineHeaders = True
        Me.GVData.OptionsPrint.AutoWidth = False
        Me.GVData.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVData.OptionsView.RowAutoHeight = True
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdAcc
        '
        Me.GridColumnIdAcc.Caption = "Id"
        Me.GridColumnIdAcc.FieldName = "id_acc"
        Me.GridColumnIdAcc.Name = "GridColumnIdAcc"
        '
        'GridColumnNo
        '
        Me.GridColumnNo.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.MaxWidth = 30
        Me.GridColumnNo.MinWidth = 30
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 30
        '
        'GridColumnaccount
        '
        Me.GridColumnaccount.Caption = "Account"
        Me.GridColumnaccount.ColumnEdit = Me.RepositoryItemSearchLookUpEdit1
        Me.GridColumnaccount.FieldName = "id_acc"
        Me.GridColumnaccount.Name = "GridColumnaccount"
        Me.GridColumnaccount.Visible = True
        Me.GridColumnaccount.VisibleIndex = 1
        Me.GridColumnaccount.Width = 56
        '
        'RepositoryItemSearchLookUpEdit1
        '
        Me.RepositoryItemSearchLookUpEdit1.AutoHeight = False
        Me.RepositoryItemSearchLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSearchLookUpEdit1.Name = "RepositoryItemSearchLookUpEdit1"
        Me.RepositoryItemSearchLookUpEdit1.NullText = "- Select Account -"
        Me.RepositoryItemSearchLookUpEdit1.View = Me.GridView1
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Id"
        Me.GridColumn2.FieldName = "id_acc"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Account"
        Me.GridColumn3.FieldName = "acc_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Description"
        Me.GridColumn4.FieldName = "acc_description"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        '
        'GridColumnDescription
        '
        Me.GridColumnDescription.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDescription.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridColumnDescription.Caption = "Description"
        Me.GridColumnDescription.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.GridColumnDescription.FieldName = "description"
        Me.GridColumnDescription.MinWidth = 100
        Me.GridColumnDescription.Name = "GridColumnDescription"
        Me.GridColumnDescription.Visible = True
        Me.GridColumnDescription.VisibleIndex = 5
        Me.GridColumnDescription.Width = 117
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemMemoEdit1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'GCCC
        '
        Me.GCCC.Caption = "CC"
        Me.GCCC.ColumnEdit = Me.RISLECC
        Me.GCCC.FieldName = "cc"
        Me.GCCC.Name = "GCCC"
        Me.GCCC.Visible = True
        Me.GCCC.VisibleIndex = 2
        Me.GCCC.Width = 30
        '
        'RISLECC
        '
        Me.RISLECC.AutoHeight = False
        Me.RISLECC.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RISLECC.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText
        Me.RISLECC.Name = "RISLECC"
        Me.RISLECC.View = Me.GridView3
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn8, Me.GridColumn14, Me.GridColumn15})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "id"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Code"
        Me.GridColumn14.FieldName = "comp_number"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        Me.GridColumn14.Width = 327
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Company"
        Me.GridColumn15.FieldName = "comp_name"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 1
        Me.GridColumn15.Width = 1305
        '
        'GridColumnBudgetType
        '
        Me.GridColumnBudgetType.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnBudgetType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnBudgetType.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnBudgetType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnBudgetType.Caption = "Budget Type"
        Me.GridColumnBudgetType.ColumnEdit = Me.RISLEType
        Me.GridColumnBudgetType.FieldName = "id_expense_type"
        Me.GridColumnBudgetType.Name = "GridColumnBudgetType"
        Me.GridColumnBudgetType.Visible = True
        Me.GridColumnBudgetType.VisibleIndex = 3
        Me.GridColumnBudgetType.Width = 56
        '
        'RISLEType
        '
        Me.RISLEType.AutoHeight = False
        Me.RISLEType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RISLEType.Name = "RISLEType"
        Me.RISLEType.View = Me.RepositoryItemSearchLookUpEdit2View
        '
        'RepositoryItemSearchLookUpEdit2View
        '
        Me.RepositoryItemSearchLookUpEdit2View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn10})
        Me.RepositoryItemSearchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit2View.Name = "RepositoryItemSearchLookUpEdit2View"
        Me.RepositoryItemSearchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit2View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Id"
        Me.GridColumn9.FieldName = "id_expense_type"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Type"
        Me.GridColumn10.FieldName = "expense_type"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        '
        'GridColumnBudget
        '
        Me.GridColumnBudget.Caption = "Budget"
        Me.GridColumnBudget.ColumnEdit = Me.RISLECatExpense
        Me.GridColumnBudget.FieldName = "id_b_expense"
        Me.GridColumnBudget.Name = "GridColumnBudget"
        Me.GridColumnBudget.Visible = True
        Me.GridColumnBudget.VisibleIndex = 4
        Me.GridColumnBudget.Width = 56
        '
        'RISLECatExpense
        '
        Me.RISLECatExpense.AutoHeight = False
        Me.RISLECatExpense.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RISLECatExpense.Name = "RISLECatExpense"
        Me.RISLECatExpense.View = Me.GridView2
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn11, Me.GridColumn13, Me.GridColumn12})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "ID Expense"
        Me.GridColumn11.FieldName = "id_b_expense"
        Me.GridColumn11.Name = "GridColumn11"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "ID type"
        Me.GridColumn13.FieldName = "id_expense_type"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Category"
        Me.GridColumn12.FieldName = "item_cat_main"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 0
        '
        'GridColumnBefKurs
        '
        Me.GridColumnBefKurs.Caption = "Before Kurs"
        Me.GridColumnBefKurs.ColumnEdit = Me.RepositoryItemTextEdit3
        Me.GridColumnBefKurs.DisplayFormat.FormatString = "N2"
        Me.GridColumnBefKurs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBefKurs.FieldName = "amount_before"
        Me.GridColumnBefKurs.MaxWidth = 80
        Me.GridColumnBefKurs.MinWidth = 80
        Me.GridColumnBefKurs.Name = "GridColumnBefKurs"
        Me.GridColumnBefKurs.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_before", "{0:N2}")})
        Me.GridColumnBefKurs.Visible = True
        Me.GridColumnBefKurs.VisibleIndex = 7
        Me.GridColumnBefKurs.Width = 80
        '
        'RepositoryItemTextEdit3
        '
        Me.RepositoryItemTextEdit3.AutoHeight = False
        Me.RepositoryItemTextEdit3.Mask.EditMask = "N2"
        Me.RepositoryItemTextEdit3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit3.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
        '
        'GridColumnCurr
        '
        Me.GridColumnCurr.Caption = "Curr"
        Me.GridColumnCurr.ColumnEdit = Me.RISLECurrency
        Me.GridColumnCurr.FieldName = "id_currency"
        Me.GridColumnCurr.MaxWidth = 30
        Me.GridColumnCurr.MinWidth = 30
        Me.GridColumnCurr.Name = "GridColumnCurr"
        Me.GridColumnCurr.Visible = True
        Me.GridColumnCurr.VisibleIndex = 6
        Me.GridColumnCurr.Width = 30
        '
        'RISLECurrency
        '
        Me.RISLECurrency.AutoHeight = False
        Me.RISLECurrency.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RISLECurrency.Name = "RISLECurrency"
        Me.RISLECurrency.View = Me.GridView5
        '
        'GridView5
        '
        Me.GridView5.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn23, Me.GridColumn24})
        Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView5.OptionsView.ShowGroupPanel = False
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "ID"
        Me.GridColumn23.FieldName = "id_currency"
        Me.GridColumn23.Name = "GridColumn23"
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "Currency"
        Me.GridColumn24.FieldName = "currency"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 0
        '
        'GridColumnKurs
        '
        Me.GridColumnKurs.Caption = "Kurs"
        Me.GridColumnKurs.ColumnEdit = Me.RepositoryItemTextEdit3
        Me.GridColumnKurs.DisplayFormat.FormatString = "N2"
        Me.GridColumnKurs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnKurs.FieldName = "kurs"
        Me.GridColumnKurs.MaxWidth = 50
        Me.GridColumnKurs.MinWidth = 50
        Me.GridColumnKurs.Name = "GridColumnKurs"
        Me.GridColumnKurs.Visible = True
        Me.GridColumnKurs.VisibleIndex = 8
        Me.GridColumnKurs.Width = 50
        '
        'GridColumnTaxPercent
        '
        Me.GridColumnTaxPercent.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.GridColumnTaxPercent.AppearanceHeader.Options.UseFont = True
        Me.GridColumnTaxPercent.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTaxPercent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnTaxPercent.Caption = "PPN (%)"
        Me.GridColumnTaxPercent.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnTaxPercent.DisplayFormat.FormatString = "N2"
        Me.GridColumnTaxPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTaxPercent.FieldName = "tax_percent"
        Me.GridColumnTaxPercent.MaxWidth = 40
        Me.GridColumnTaxPercent.MinWidth = 40
        Me.GridColumnTaxPercent.Name = "GridColumnTaxPercent"
        Me.GridColumnTaxPercent.Visible = True
        Me.GridColumnTaxPercent.VisibleIndex = 10
        Me.GridColumnTaxPercent.Width = 40
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatString = "N2"
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.Mask.EditMask = "N2"
        Me.RepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'GridColumnTaxValue
        '
        Me.GridColumnTaxValue.Caption = "PPN"
        Me.GridColumnTaxValue.DisplayFormat.FormatString = "N2"
        Me.GridColumnTaxValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTaxValue.FieldName = "tax_value"
        Me.GridColumnTaxValue.MaxWidth = 70
        Me.GridColumnTaxValue.MinWidth = 70
        Me.GridColumnTaxValue.Name = "GridColumnTaxValue"
        Me.GridColumnTaxValue.OptionsColumn.AllowEdit = False
        Me.GridColumnTaxValue.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tax_value", "{0:N2}")})
        Me.GridColumnTaxValue.UnboundExpression = "[tax_percent] / 100 * [amount]"
        Me.GridColumnTaxValue.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnTaxValue.Visible = True
        Me.GridColumnTaxValue.VisibleIndex = 11
        Me.GridColumnTaxValue.Width = 70
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.Caption = "Amount in Rp"
        Me.GridColumnAmount.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnAmount.DisplayFormat.FormatString = "N2"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "amount"
        Me.GridColumnAmount.MaxWidth = 80
        Me.GridColumnAmount.MinWidth = 80
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.OptionsColumn.AllowEdit = False
        Me.GridColumnAmount.OptionsColumn.ReadOnly = True
        Me.GridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 9
        Me.GridColumnAmount.Width = 80
        '
        'GridColumnPPHCOA
        '
        Me.GridColumnPPHCOA.Caption = "PPH COA"
        Me.GridColumnPPHCOA.ColumnEdit = Me.RISLECOAPPH
        Me.GridColumnPPHCOA.FieldName = "id_acc_pph"
        Me.GridColumnPPHCOA.Name = "GridColumnPPHCOA"
        Me.GridColumnPPHCOA.Visible = True
        Me.GridColumnPPHCOA.VisibleIndex = 12
        Me.GridColumnPPHCOA.Width = 228
        '
        'RISLECOAPPH
        '
        Me.RISLECOAPPH.AutoHeight = False
        Me.RISLECOAPPH.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RISLECOAPPH.Name = "RISLECOAPPH"
        Me.RISLECOAPPH.NullText = "- No PPH -"
        Me.RISLECOAPPH.View = Me.GridView4
        '
        'GridView4
        '
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn18, Me.GridColumn19, Me.GridColumn20})
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Id"
        Me.GridColumn18.FieldName = "id_acc"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Account"
        Me.GridColumn19.FieldName = "acc_name"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 0
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Description"
        Me.GridColumn20.FieldName = "acc_description"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 1
        '
        'GridColumnPPHPercent
        '
        Me.GridColumnPPHPercent.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.GridColumnPPHPercent.AppearanceHeader.Options.UseFont = True
        Me.GridColumnPPHPercent.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPPHPercent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnPPHPercent.Caption = "PPH (%)"
        Me.GridColumnPPHPercent.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumnPPHPercent.FieldName = "pph_percent"
        Me.GridColumnPPHPercent.MaxWidth = 40
        Me.GridColumnPPHPercent.MinWidth = 40
        Me.GridColumnPPHPercent.Name = "GridColumnPPHPercent"
        Me.GridColumnPPHPercent.Visible = True
        Me.GridColumnPPHPercent.VisibleIndex = 13
        Me.GridColumnPPHPercent.Width = 40
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.Mask.EditMask = "N2"
        Me.RepositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit2.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'GridColumnPPH
        '
        Me.GridColumnPPH.Caption = "PPH"
        Me.GridColumnPPH.ColumnEdit = Me.RepositoryItemTextEdit3
        Me.GridColumnPPH.DisplayFormat.FormatString = "N2"
        Me.GridColumnPPH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPPH.FieldName = "pph_value"
        Me.GridColumnPPH.MaxWidth = 80
        Me.GridColumnPPH.MinWidth = 80
        Me.GridColumnPPH.Name = "GridColumnPPH"
        Me.GridColumnPPH.OptionsColumn.AllowEdit = False
        Me.GridColumnPPH.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pph_value", "{0:N2}")})
        Me.GridColumnPPH.UnboundExpression = "Iif([id_acc_pph] = 948, 0, Floor([pph_percent] / 100 * [amount]))"
        Me.GridColumnPPH.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnPPH.Visible = True
        Me.GridColumnPPH.VisibleIndex = 14
        Me.GridColumnPPH.Width = 80
        '
        'GridColumnPPHDesc
        '
        Me.GridColumnPPHDesc.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPPHDesc.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridColumnPPHDesc.Caption = "PPH COA"
        Me.GridColumnPPHDesc.ColumnEdit = Me.RepositoryItemMemoEdit2
        Me.GridColumnPPHDesc.FieldName = "coa_desc_pph"
        Me.GridColumnPPHDesc.MinWidth = 80
        Me.GridColumnPPHDesc.Name = "GridColumnPPHDesc"
        Me.GridColumnPPHDesc.Width = 60
        '
        'RepositoryItemMemoEdit2
        '
        Me.RepositoryItemMemoEdit2.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemMemoEdit2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.RepositoryItemMemoEdit2.Name = "RepositoryItemMemoEdit2"
        '
        'GridColumnAccountDescription
        '
        Me.GridColumnAccountDescription.Caption = "Account"
        Me.GridColumnAccountDescription.FieldName = "coa_desc"
        Me.GridColumnAccountDescription.Name = "GridColumnAccountDescription"
        '
        'GridColumnBudgetTypeDesc
        '
        Me.GridColumnBudgetTypeDesc.Caption = "Budget Type"
        Me.GridColumnBudgetTypeDesc.FieldName = "expense_type"
        Me.GridColumnBudgetTypeDesc.Name = "GridColumnBudgetTypeDesc"
        '
        'GridColumnBudgetDesc
        '
        Me.GridColumnBudgetDesc.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnBudgetDesc.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridColumnBudgetDesc.Caption = "Budget"
        Me.GridColumnBudgetDesc.ColumnEdit = Me.RepositoryItemMemoEdit3
        Me.GridColumnBudgetDesc.FieldName = "item_cat_main"
        Me.GridColumnBudgetDesc.Name = "GridColumnBudgetDesc"
        Me.GridColumnBudgetDesc.Width = 50
        '
        'RepositoryItemMemoEdit3
        '
        Me.RepositoryItemMemoEdit3.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemMemoEdit3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.RepositoryItemMemoEdit3.Name = "RepositoryItemMemoEdit3"
        '
        'GCCCDesc
        '
        Me.GCCCDesc.AppearanceCell.Options.UseTextOptions = True
        Me.GCCCDesc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GCCCDesc.AppearanceHeader.Options.UseTextOptions = True
        Me.GCCCDesc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GCCCDesc.Caption = "CC"
        Me.GCCCDesc.FieldName = "cc_desc"
        Me.GCCCDesc.Name = "GCCCDesc"
        '
        'GridColumnCurrView
        '
        Me.GridColumnCurrView.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCurrView.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnCurrView.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCurrView.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnCurrView.Caption = "Curr"
        Me.GridColumnCurrView.FieldName = "currency"
        Me.GridColumnCurrView.MaxWidth = 30
        Me.GridColumnCurrView.MinWidth = 30
        Me.GridColumnCurrView.Name = "GridColumnCurrView"
        Me.GridColumnCurrView.Width = 30
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit1.EditFormat.FormatString = "N2"
        Me.RepositoryItemSpinEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "N2"
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 8.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'LabelNumber
        '
        Me.LabelNumber.Font = New System.Drawing.Font("Segoe UI Emoji", 12.0!)
        Me.LabelNumber.LocationFloat = New DevExpress.Utils.PointFloat(456.1702!, 20.0!)
        Me.LabelNumber.Name = "LabelNumber"
        Me.LabelNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelNumber.SizeF = New System.Drawing.SizeF(316.4521!, 19.58334!)
        Me.LabelNumber.StylePriority.UseFont = False
        Me.LabelNumber.StylePriority.UseTextAlignment = False
        Me.LabelNumber.Text = "0000000"
        Me.LabelNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'LabelTitle
        '
        Me.LabelTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.LocationFloat = New DevExpress.Utils.PointFloat(606.8243!, 0!)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelTitle.SizeF = New System.Drawing.SizeF(165.7978!, 20.0!)
        Me.LabelTitle.StylePriority.UseFont = False
        Me.LabelTitle.StylePriority.UseTextAlignment = False
        Me.LabelTitle.Text = "EXPENSE"
        Me.LabelTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(1.00015!, 0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(210.4167!, 39.58334!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 22.53202!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(622.6221!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 18.71793!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'LpayFromMark
        '
        Me.LpayFromMark.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LpayFromMark.LocationFloat = New DevExpress.Utils.PointFloat(125.6116!, 80.18694!)
        Me.LpayFromMark.Name = "LpayFromMark"
        Me.LpayFromMark.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LpayFromMark.SizeF = New System.Drawing.SizeF(17.82407!, 16.18692!)
        Me.LpayFromMark.StylePriority.UseFont = False
        Me.LpayFromMark.StylePriority.UseTextAlignment = False
        Me.LpayFromMark.Text = ":"
        Me.LpayFromMark.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LpayFromTitle
        '
        Me.LpayFromTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LpayFromTitle.LocationFloat = New DevExpress.Utils.PointFloat(2.000427!, 80.18694!)
        Me.LpayFromTitle.Name = "LpayFromTitle"
        Me.LpayFromTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LpayFromTitle.SizeF = New System.Drawing.SizeF(123.6111!, 16.18693!)
        Me.LpayFromTitle.StylePriority.UseFont = False
        Me.LpayFromTitle.StylePriority.UseTextAlignment = False
        Me.LpayFromTitle.Text = "PAY FROM"
        Me.LpayFromTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LPayFrom
        '
        Me.LPayFrom.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LPayFrom.LocationFloat = New DevExpress.Utils.PointFloat(143.4355!, 80.18694!)
        Me.LPayFrom.Name = "LPayFrom"
        Me.LPayFrom.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LPayFrom.SizeF = New System.Drawing.SizeF(258.6063!, 16.18693!)
        Me.LPayFrom.StylePriority.UseFont = False
        Me.LPayFrom.StylePriority.UseTextAlignment = False
        Me.LPayFrom.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel8
        '
        Me.XrLabel8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(525.6539!, 96.37386!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(17.82407!, 16.18692!)
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = ":"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelDate
        '
        Me.LabelDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDate.LocationFloat = New DevExpress.Utils.PointFloat(543.478!, 96.37386!)
        Me.LabelDate.Name = "LabelDate"
        Me.LabelDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDate.SizeF = New System.Drawing.SizeF(229.1444!, 16.18693!)
        Me.LabelDate.StylePriority.UseFont = False
        Me.LabelDate.StylePriority.UseTextAlignment = False
        Me.LabelDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel7
        '
        Me.XrLabel7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(402.0428!, 96.37386!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(123.6111!, 16.18693!)
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "CREATED DATE"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelPaymentStatus
        '
        Me.LabelPaymentStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPaymentStatus.LocationFloat = New DevExpress.Utils.PointFloat(543.4772!, 64.0!)
        Me.LabelPaymentStatus.Name = "LabelPaymentStatus"
        Me.LabelPaymentStatus.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelPaymentStatus.SizeF = New System.Drawing.SizeF(229.1449!, 16.18692!)
        Me.LabelPaymentStatus.StylePriority.UseFont = False
        Me.LabelPaymentStatus.StylePriority.UseTextAlignment = False
        Me.LabelPaymentStatus.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel5
        '
        Me.XrLabel5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(525.653!, 63.99998!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(17.82407!, 16.18692!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = ":"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(402.042!, 64.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(123.6111!, 16.18693!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "PAYMENT STATUS"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelBeneficiary
        '
        Me.LabelBeneficiary.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBeneficiary.LocationFloat = New DevExpress.Utils.PointFloat(143.4357!, 96.37386!)
        Me.LabelBeneficiary.Name = "LabelBeneficiary"
        Me.LabelBeneficiary.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelBeneficiary.SizeF = New System.Drawing.SizeF(258.6063!, 16.18694!)
        Me.LabelBeneficiary.StylePriority.UseFont = False
        Me.LabelBeneficiary.StylePriority.UseTextAlignment = False
        Me.LabelBeneficiary.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelDotBeneficiary
        '
        Me.LabelDotBeneficiary.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDotBeneficiary.LocationFloat = New DevExpress.Utils.PointFloat(125.6116!, 96.37386!)
        Me.LabelDotBeneficiary.Name = "LabelDotBeneficiary"
        Me.LabelDotBeneficiary.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDotBeneficiary.SizeF = New System.Drawing.SizeF(17.82406!, 16.18693!)
        Me.LabelDotBeneficiary.StylePriority.UseFont = False
        Me.LabelDotBeneficiary.StylePriority.UseTextAlignment = False
        Me.LabelDotBeneficiary.Text = ":"
        Me.LabelDotBeneficiary.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelTitleBeneficiary
        '
        Me.LabelTitleBeneficiary.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitleBeneficiary.LocationFloat = New DevExpress.Utils.PointFloat(2.000427!, 96.37387!)
        Me.LabelTitleBeneficiary.Name = "LabelTitleBeneficiary"
        Me.LabelTitleBeneficiary.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelTitleBeneficiary.SizeF = New System.Drawing.SizeF(123.6111!, 16.18693!)
        Me.LabelTitleBeneficiary.StylePriority.UseFont = False
        Me.LabelTitleBeneficiary.StylePriority.UseTextAlignment = False
        Me.LabelTitleBeneficiary.Text = "BENEFICIARY"
        Me.LabelTitleBeneficiary.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelTitleDueDate
        '
        Me.LabelTitleDueDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitleDueDate.LocationFloat = New DevExpress.Utils.PointFloat(402.0428!, 112.5608!)
        Me.LabelTitleDueDate.Name = "LabelTitleDueDate"
        Me.LabelTitleDueDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelTitleDueDate.SizeF = New System.Drawing.SizeF(123.6111!, 16.18693!)
        Me.LabelTitleDueDate.StylePriority.UseFont = False
        Me.LabelTitleDueDate.StylePriority.UseTextAlignment = False
        Me.LabelTitleDueDate.Text = "DUE DATE"
        Me.LabelTitleDueDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelDotDueDate
        '
        Me.LabelDotDueDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDotDueDate.LocationFloat = New DevExpress.Utils.PointFloat(525.6539!, 112.5608!)
        Me.LabelDotDueDate.Name = "LabelDotDueDate"
        Me.LabelDotDueDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDotDueDate.SizeF = New System.Drawing.SizeF(17.82407!, 16.18692!)
        Me.LabelDotDueDate.StylePriority.UseFont = False
        Me.LabelDotDueDate.StylePriority.UseTextAlignment = False
        Me.LabelDotDueDate.Text = ":"
        Me.LabelDotDueDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelDUelDate
        '
        Me.LabelDUelDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDUelDate.LocationFloat = New DevExpress.Utils.PointFloat(543.478!, 112.5608!)
        Me.LabelDUelDate.Name = "LabelDUelDate"
        Me.LabelDUelDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDUelDate.SizeF = New System.Drawing.SizeF(229.1444!, 16.18693!)
        Me.LabelDUelDate.StylePriority.UseFont = False
        Me.LabelDUelDate.StylePriority.UseTextAlignment = False
        Me.LabelDUelDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'LabelPaymentMethod
        '
        Me.LabelPaymentMethod.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPaymentMethod.LocationFloat = New DevExpress.Utils.PointFloat(143.4357!, 64.0!)
        Me.LabelPaymentMethod.Name = "LabelPaymentMethod"
        Me.LabelPaymentMethod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelPaymentMethod.SizeF = New System.Drawing.SizeF(258.6063!, 16.18693!)
        Me.LabelPaymentMethod.StylePriority.UseFont = False
        Me.LabelPaymentMethod.StylePriority.UseTextAlignment = False
        Me.LabelPaymentMethod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(2.000336!, 64.0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(123.6111!, 16.18693!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "PAYMENT METHOD"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(125.6114!, 64.0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(17.82407!, 16.18692!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = ":"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LSay, Me.XrLabel10, Me.XrTable1, Me.LNotex, Me.LNote, Me.XrLabel6, Me.LabelTotalPayment, Me.XrLabel16})
        Me.ReportFooter.HeightF = 106.9583!
        Me.ReportFooter.KeepTogether = True
        Me.ReportFooter.Name = "ReportFooter"
        '
        'LSay
        '
        Me.LSay.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.LSay.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSay.LocationFloat = New DevExpress.Utils.PointFloat(47.87486!, 33.66661!)
        Me.LSay.Name = "LSay"
        Me.LSay.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100.0!)
        Me.LSay.SizeF = New System.Drawing.SizeF(724.7472!, 21.83329!)
        Me.LSay.StylePriority.UseBorders = False
        Me.LSay.StylePriority.UseFont = False
        Me.LSay.StylePriority.UsePadding = False
        Me.LSay.StylePriority.UseTextAlignment = False
        Me.LSay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel10
        '
        Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.XrLabel10.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(0!, 33.66658!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(47.8749!, 21.83329!)
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UsePadding = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = "SAY : "
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(1.000627!, 81.95826!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(771.6216!, 25.0!)
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
        'LNotex
        '
        Me.LNotex.BorderColor = System.Drawing.Color.DimGray
        Me.LNotex.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.LNotex.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LNotex.LocationFloat = New DevExpress.Utils.PointFloat(0.9998639!, 55.4999!)
        Me.LNotex.Name = "LNotex"
        Me.LNotex.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LNotex.SizeF = New System.Drawing.SizeF(46.87503!, 26.45835!)
        Me.LNotex.StylePriority.UseBorderColor = False
        Me.LNotex.StylePriority.UseBorders = False
        Me.LNotex.StylePriority.UseFont = False
        Me.LNotex.Text = "NOTE "
        '
        'LNote
        '
        Me.LNote.BorderColor = System.Drawing.Color.DimGray
        Me.LNote.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.LNote.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LNote.LocationFloat = New DevExpress.Utils.PointFloat(58.20824!, 55.4999!)
        Me.LNote.Name = "LNote"
        Me.LNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LNote.SizeF = New System.Drawing.SizeF(714.4139!, 26.45835!)
        Me.LNote.StylePriority.UseBorderColor = False
        Me.LNote.StylePriority.UseBorders = False
        Me.LNote.StylePriority.UseFont = False
        '
        'XrLabel6
        '
        Me.XrLabel6.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel6.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel6.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(47.87486!, 55.4999!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(10.3334!, 26.45831!)
        Me.XrLabel6.StylePriority.UseBorderColor = False
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.Text = ":"
        '
        'LabelTotalPayment
        '
        Me.LabelTotalPayment.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.LabelTotalPayment.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalPayment.LocationFloat = New DevExpress.Utils.PointFloat(137.4999!, 11.83332!)
        Me.LabelTotalPayment.Name = "LabelTotalPayment"
        Me.LabelTotalPayment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100.0!)
        Me.LabelTotalPayment.SizeF = New System.Drawing.SizeF(635.1223!, 21.83329!)
        Me.LabelTotalPayment.StylePriority.UseBorders = False
        Me.LabelTotalPayment.StylePriority.UseFont = False
        Me.LabelTotalPayment.StylePriority.UsePadding = False
        Me.LabelTotalPayment.StylePriority.UseTextAlignment = False
        Me.LabelTotalPayment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel16
        '
        Me.XrLabel16.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel16.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 11.83329!)
        Me.XrLabel16.Name = "XrLabel16"
        Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100.0!)
        Me.XrLabel16.SizeF = New System.Drawing.SizeF(137.4998!, 21.83329!)
        Me.XrLabel16.StylePriority.UseBorders = False
        Me.XrLabel16.StylePriority.UseFont = False
        Me.XrLabel16.StylePriority.UsePadding = False
        Me.XrLabel16.StylePriority.UseTextAlignment = False
        Me.XrLabel16.Text = "TOTAL PAYMENT"
        Me.XrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LUnit, Me.XrLabel9, Me.XrLabel11, Me.LInvNo, Me.XrLabel12, Me.XrLabel13, Me.LabelTitle, Me.LabelNumber, Me.XrPictureBox1, Me.XrLabel3, Me.XrLabel2, Me.LabelPaymentMethod, Me.LabelDUelDate, Me.LabelDotDueDate, Me.LabelTitleDueDate, Me.LabelTitleBeneficiary, Me.LabelDotBeneficiary, Me.LabelBeneficiary, Me.XrLabel1, Me.XrLabel5, Me.LabelPaymentStatus, Me.XrLabel7, Me.LabelDate, Me.XrLabel8, Me.LPayFrom, Me.LpayFromTitle, Me.LpayFromMark})
        Me.PageHeader.HeightF = 137.5618!
        Me.PageHeader.Name = "PageHeader"
        '
        'LInvNo
        '
        Me.LInvNo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LInvNo.LocationFloat = New DevExpress.Utils.PointFloat(143.4357!, 112.5608!)
        Me.LInvNo.Name = "LInvNo"
        Me.LInvNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LInvNo.SizeF = New System.Drawing.SizeF(258.6063!, 16.18694!)
        Me.LInvNo.StylePriority.UseFont = False
        Me.LInvNo.StylePriority.UseTextAlignment = False
        Me.LInvNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel12
        '
        Me.XrLabel12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(125.6116!, 112.5608!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(17.82406!, 16.18693!)
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = ":"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel13
        '
        Me.XrLabel13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(2.000442!, 112.5608!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(123.6111!, 16.18693!)
        Me.XrLabel13.StylePriority.UseFont = False
        Me.XrLabel13.StylePriority.UseTextAlignment = False
        Me.XrLabel13.Text = "INVOICE NO"
        Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.PageFooter.HeightF = 18.71793!
        Me.PageFooter.Name = "PageFooter"
        '
        'LUnit
        '
        Me.LUnit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LUnit.LocationFloat = New DevExpress.Utils.PointFloat(543.4772!, 80.18694!)
        Me.LUnit.Name = "LUnit"
        Me.LUnit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LUnit.SizeF = New System.Drawing.SizeF(229.1449!, 16.18692!)
        Me.LUnit.StylePriority.UseFont = False
        Me.LUnit.StylePriority.UseTextAlignment = False
        Me.LUnit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel9
        '
        Me.XrLabel9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(525.653!, 80.18693!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(17.82407!, 16.18692!)
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = ":"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel11
        '
        Me.XrLabel11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(402.042!, 80.18694!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(123.6111!, 16.18693!)
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = "UNIT"
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'ReportItemExpense
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportFooter, Me.PageHeader, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(30, 47, 8, 23)
        Me.PageHeight = 550
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RISLECC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RISLEType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit2View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RISLECatExpense, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RISLECurrency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RISLECOAPPH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents LabelNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelPaymentMethod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelTitleBeneficiary As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelTitleDueDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelDotDueDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelDUelDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelBeneficiary As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelDotBeneficiary As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents LabelTotalPayment As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents LNotex As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelPaymentStatus As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LpayFromMark As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LpayFromTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LPayFrom As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LSay As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents LInvNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdAcc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnaccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSearchLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents GCCC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RISLECC As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBudgetType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RISLEType As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit2View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBudget As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RISLECatExpense As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBefKurs As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumnCurr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RISLECurrency As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnKurs As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTaxPercent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumnTaxValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPPHCOA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RISLECOAPPH As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPPHPercent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumnPPH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPPHDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents GridColumnAccountDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBudgetTypeDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBudgetDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents GCCCDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCurrView As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents LUnit As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
End Class
