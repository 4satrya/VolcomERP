﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBudgetExpenseView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBudgetExpenseView))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LEYear = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.LECat = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LEDeptSum = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBandGeneral = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDescription = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCat = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnExpType = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnJanBudget = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJanActual = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJanDiff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnFebBudget = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnFebActual = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnFebDiff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnMarBudget = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnMarActual = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnMarDiff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnAprBudget = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnAprActual = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnAprDiff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnMayBudget = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnMayActual = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnMayDiff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnJuneBudget = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJuneActual = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJuneDiff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand7 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnJulyBudget = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJulyActual = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJulyDiff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand8 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnAugBUdget = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnAugActual = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnAugDiff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand9 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnSepBudget = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSePActual = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSeptDiff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand10 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnOctBudget = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnOctActual = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnOctDiff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand11 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnNovBudget = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnNovActual = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnNovFiff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand12 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnDecBudget = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDecActual = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDecDiff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand13 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnTotalBudget = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalActual = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalDiff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnIdItemCOA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PanelMain = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.CEBudgetHistory = New DevExpress.XtraEditors.CheckEdit()
        Me.GroupControlBudgetRevision = New DevExpress.XtraEditors.GroupControl()
        Me.GCBudgetHist = New DevExpress.XtraGrid.GridControl()
        Me.GVBudgetHist = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LEYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMain.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.CEBudgetHistory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlBudgetRevision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlBudgetRevision.SuspendLayout()
        CType(Me.GCBudgetHist, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBudgetHist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LEYear)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.LECat)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.LEDeptSum)
        Me.PanelControl1.Controls.Add(Me.LabelControl6)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(781, 51)
        Me.PanelControl1.TabIndex = 4
        '
        'LEYear
        '
        Me.LEYear.Location = New System.Drawing.Point(294, 14)
        Me.LEYear.Name = "LEYear"
        Me.LEYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEYear.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("year", "Year")})
        Me.LEYear.Size = New System.Drawing.Size(125, 20)
        Me.LEYear.TabIndex = 22
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(267, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl2.TabIndex = 21
        Me.LabelControl2.Text = "Year"
        '
        'BtnView
        '
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(658, 12)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 23)
        Me.BtnView.TabIndex = 20
        Me.BtnView.Text = "View"
        '
        'LECat
        '
        Me.LECat.Location = New System.Drawing.Point(477, 14)
        Me.LECat.Name = "LECat"
        Me.LECat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECat.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_item_cat", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("item_cat", "Category")})
        Me.LECat.Size = New System.Drawing.Size(175, 20)
        Me.LECat.TabIndex = 19
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(426, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl1.TabIndex = 18
        Me.LabelControl1.Text = "Category"
        '
        'LEDeptSum
        '
        Me.LEDeptSum.Location = New System.Drawing.Point(83, 14)
        Me.LEDeptSum.Name = "LEDeptSum"
        Me.LEDeptSum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDeptSum.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement", "Id Departement", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement", "Departemen")})
        Me.LEDeptSum.Size = New System.Drawing.Size(175, 20)
        Me.LEDeptSum.TabIndex = 17
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(14, 17)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl6.TabIndex = 16
        Me.LabelControl6.Text = "Departement"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 51)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(781, 523)
        Me.GCData.TabIndex = 5
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBandGeneral, Me.gridBand1, Me.gridBand2, Me.gridBand3, Me.gridBand4, Me.gridBand5, Me.gridBand6, Me.gridBand7, Me.gridBand8, Me.gridBand9, Me.gridBand10, Me.gridBand11, Me.gridBand12, Me.gridBand13})
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumnCode, Me.BandedGridColumnDescription, Me.BandedGridColumnCat, Me.BandedGridColumnExpType, Me.BandedGridColumnJanBudget, Me.BandedGridColumnJanActual, Me.BandedGridColumnJanDiff, Me.BandedGridColumnFebBudget, Me.BandedGridColumnFebActual, Me.BandedGridColumnFebDiff, Me.BandedGridColumnMarBudget, Me.BandedGridColumnMarActual, Me.BandedGridColumnMarDiff, Me.BandedGridColumnAprBudget, Me.BandedGridColumnAprActual, Me.BandedGridColumnAprDiff, Me.BandedGridColumnMayBudget, Me.BandedGridColumnMayActual, Me.BandedGridColumnMayDiff, Me.BandedGridColumnJuneBudget, Me.BandedGridColumnJuneActual, Me.BandedGridColumnJuneDiff, Me.BandedGridColumnJulyBudget, Me.BandedGridColumnJulyActual, Me.BandedGridColumnJulyDiff, Me.BandedGridColumnAugBUdget, Me.BandedGridColumnAugActual, Me.BandedGridColumnAugDiff, Me.BandedGridColumnSepBudget, Me.BandedGridColumnSePActual, Me.BandedGridColumnSeptDiff, Me.BandedGridColumnOctBudget, Me.BandedGridColumnOctActual, Me.BandedGridColumnOctDiff, Me.BandedGridColumnNovBudget, Me.BandedGridColumnNovActual, Me.BandedGridColumnNovFiff, Me.BandedGridColumnDecBudget, Me.BandedGridColumnDecActual, Me.BandedGridColumnDecDiff, Me.BandedGridColumnTotalBudget, Me.BandedGridColumnTotalActual, Me.BandedGridColumnTotalDiff, Me.BandedGridColumnIdItemCOA})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "1_budget", Me.BandedGridColumnJanBudget, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "1_actual", Me.BandedGridColumnJanActual, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "1_diff", Me.BandedGridColumnJanDiff, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "2_budget", Me.BandedGridColumnFebBudget, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "2_actual", Me.BandedGridColumnFebActual, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "2_diff", Me.BandedGridColumnFebDiff, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "3_budget", Me.BandedGridColumnMarBudget, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "3_actual", Me.BandedGridColumnMarActual, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "3_diff", Me.BandedGridColumnMarDiff, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "4_budget", Me.BandedGridColumnAprBudget, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "4_actual", Me.BandedGridColumnAprActual, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "4_diff", Me.BandedGridColumnAprDiff, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "5_budget", Me.BandedGridColumnMayBudget, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "5_actual", Me.BandedGridColumnMayActual, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "5_diff", Me.BandedGridColumnMayDiff, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "6_budget", Me.BandedGridColumnJuneBudget, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "6_actual", Me.BandedGridColumnJuneActual, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "6_diff", Me.BandedGridColumnJuneDiff, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "7_budget", Me.BandedGridColumnJulyBudget, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "7_actual", Me.BandedGridColumnJulyActual, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "7_diff", Me.BandedGridColumnJulyDiff, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "8_budget", Me.BandedGridColumnAugBUdget, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "8_actual", Me.BandedGridColumnAugActual, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "8_diff", Me.BandedGridColumnAugDiff, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "9_budget", Me.BandedGridColumnSepBudget, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "9_actual", Me.BandedGridColumnSePActual, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "9_diff", Me.BandedGridColumnSeptDiff, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "10_budget", Me.BandedGridColumnOctBudget, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "10_actual", Me.BandedGridColumnOctActual, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "10_diff", Me.BandedGridColumnOctDiff, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "11_budget", Me.BandedGridColumnNovBudget, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "11_actual", Me.BandedGridColumnNovActual, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "11_diff", Me.BandedGridColumnNovFiff, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "12_budget", Me.BandedGridColumnDecBudget, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "12_actual", Me.BandedGridColumnDecActual, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "12_diff", Me.BandedGridColumnDecDiff, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_budget", Me.BandedGridColumnTotalBudget, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_actual", Me.BandedGridColumnTotalActual, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_diff", Me.BandedGridColumnTotalDiff, "{0:N2}")})
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridBandGeneral
        '
        Me.GridBandGeneral.Columns.Add(Me.BandedGridColumnCode)
        Me.GridBandGeneral.Columns.Add(Me.BandedGridColumnDescription)
        Me.GridBandGeneral.Columns.Add(Me.BandedGridColumnCat)
        Me.GridBandGeneral.Columns.Add(Me.BandedGridColumnExpType)
        Me.GridBandGeneral.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridBandGeneral.Name = "GridBandGeneral"
        Me.GridBandGeneral.VisibleIndex = 0
        Me.GridBandGeneral.Width = 300
        '
        'BandedGridColumnCode
        '
        Me.BandedGridColumnCode.Caption = "Code"
        Me.BandedGridColumnCode.FieldName = "exp_acc"
        Me.BandedGridColumnCode.Name = "BandedGridColumnCode"
        Me.BandedGridColumnCode.Visible = True
        '
        'BandedGridColumnDescription
        '
        Me.BandedGridColumnDescription.Caption = "Description"
        Me.BandedGridColumnDescription.FieldName = "exp_description"
        Me.BandedGridColumnDescription.Name = "BandedGridColumnDescription"
        Me.BandedGridColumnDescription.Visible = True
        '
        'BandedGridColumnCat
        '
        Me.BandedGridColumnCat.Caption = "Category"
        Me.BandedGridColumnCat.FieldName = "item_cat"
        Me.BandedGridColumnCat.Name = "BandedGridColumnCat"
        Me.BandedGridColumnCat.Visible = True
        '
        'BandedGridColumnExpType
        '
        Me.BandedGridColumnExpType.Caption = "Type"
        Me.BandedGridColumnExpType.FieldName = "expense_type"
        Me.BandedGridColumnExpType.Name = "BandedGridColumnExpType"
        Me.BandedGridColumnExpType.Visible = True
        '
        'gridBand1
        '
        Me.gridBand1.Caption = "January"
        Me.gridBand1.Columns.Add(Me.BandedGridColumnJanBudget)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnJanActual)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnJanDiff)
        Me.gridBand1.Name = "gridBand1"
        Me.gridBand1.VisibleIndex = 1
        Me.gridBand1.Width = 225
        '
        'BandedGridColumnJanBudget
        '
        Me.BandedGridColumnJanBudget.Caption = "Budget"
        Me.BandedGridColumnJanBudget.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnJanBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJanBudget.FieldName = "1_budget"
        Me.BandedGridColumnJanBudget.Name = "BandedGridColumnJanBudget"
        Me.BandedGridColumnJanBudget.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "1_budget", "{0:N2}")})
        Me.BandedGridColumnJanBudget.Visible = True
        '
        'BandedGridColumnJanActual
        '
        Me.BandedGridColumnJanActual.Caption = "Actual"
        Me.BandedGridColumnJanActual.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnJanActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJanActual.FieldName = "1_actual"
        Me.BandedGridColumnJanActual.Name = "BandedGridColumnJanActual"
        Me.BandedGridColumnJanActual.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "1_actual", "{0:N2}")})
        Me.BandedGridColumnJanActual.Visible = True
        '
        'BandedGridColumnJanDiff
        '
        Me.BandedGridColumnJanDiff.Caption = "Remaining"
        Me.BandedGridColumnJanDiff.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnJanDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJanDiff.FieldName = "1_diff"
        Me.BandedGridColumnJanDiff.Name = "BandedGridColumnJanDiff"
        Me.BandedGridColumnJanDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "1_diff", "{0:N2}")})
        Me.BandedGridColumnJanDiff.UnboundExpression = "[1_budget] - [1_actual]"
        Me.BandedGridColumnJanDiff.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnJanDiff.Visible = True
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "February"
        Me.gridBand2.Columns.Add(Me.BandedGridColumnFebBudget)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnFebActual)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnFebDiff)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 2
        Me.gridBand2.Width = 225
        '
        'BandedGridColumnFebBudget
        '
        Me.BandedGridColumnFebBudget.Caption = "Budget"
        Me.BandedGridColumnFebBudget.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumnFebBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnFebBudget.FieldName = "2_budget"
        Me.BandedGridColumnFebBudget.Name = "BandedGridColumnFebBudget"
        Me.BandedGridColumnFebBudget.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "2_budget", "{0:n2}")})
        Me.BandedGridColumnFebBudget.Visible = True
        '
        'BandedGridColumnFebActual
        '
        Me.BandedGridColumnFebActual.Caption = "Actual"
        Me.BandedGridColumnFebActual.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnFebActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnFebActual.FieldName = "2_actual"
        Me.BandedGridColumnFebActual.Name = "BandedGridColumnFebActual"
        Me.BandedGridColumnFebActual.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "2_actual", "{0:N2}")})
        Me.BandedGridColumnFebActual.Visible = True
        '
        'BandedGridColumnFebDiff
        '
        Me.BandedGridColumnFebDiff.Caption = "Remaining"
        Me.BandedGridColumnFebDiff.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnFebDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnFebDiff.FieldName = "2_diff"
        Me.BandedGridColumnFebDiff.Name = "BandedGridColumnFebDiff"
        Me.BandedGridColumnFebDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "2_diff", "{0:N2}")})
        Me.BandedGridColumnFebDiff.UnboundExpression = "[2_budget] - [2_actual]"
        Me.BandedGridColumnFebDiff.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnFebDiff.Visible = True
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "March"
        Me.gridBand3.Columns.Add(Me.BandedGridColumnMarBudget)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnMarActual)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnMarDiff)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 3
        Me.gridBand3.Width = 225
        '
        'BandedGridColumnMarBudget
        '
        Me.BandedGridColumnMarBudget.Caption = "Budget"
        Me.BandedGridColumnMarBudget.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnMarBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnMarBudget.FieldName = "3_budget"
        Me.BandedGridColumnMarBudget.Name = "BandedGridColumnMarBudget"
        Me.BandedGridColumnMarBudget.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "3_budget", "{0:N2}")})
        Me.BandedGridColumnMarBudget.Visible = True
        '
        'BandedGridColumnMarActual
        '
        Me.BandedGridColumnMarActual.Caption = "Actual"
        Me.BandedGridColumnMarActual.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnMarActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnMarActual.FieldName = "3_actual"
        Me.BandedGridColumnMarActual.Name = "BandedGridColumnMarActual"
        Me.BandedGridColumnMarActual.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "3_actual", "{0:N2}")})
        Me.BandedGridColumnMarActual.Visible = True
        '
        'BandedGridColumnMarDiff
        '
        Me.BandedGridColumnMarDiff.Caption = "Remaining"
        Me.BandedGridColumnMarDiff.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumnMarDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnMarDiff.FieldName = "3_diff"
        Me.BandedGridColumnMarDiff.Name = "BandedGridColumnMarDiff"
        Me.BandedGridColumnMarDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "3_remaining", "{0:n2}")})
        Me.BandedGridColumnMarDiff.UnboundExpression = "[3_budget] - [3_actual]"
        Me.BandedGridColumnMarDiff.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnMarDiff.Visible = True
        '
        'gridBand4
        '
        Me.gridBand4.Caption = "April"
        Me.gridBand4.Columns.Add(Me.BandedGridColumnAprBudget)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnAprActual)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnAprDiff)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 4
        Me.gridBand4.Width = 225
        '
        'BandedGridColumnAprBudget
        '
        Me.BandedGridColumnAprBudget.Caption = "Budget"
        Me.BandedGridColumnAprBudget.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnAprBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnAprBudget.FieldName = "4_budget"
        Me.BandedGridColumnAprBudget.Name = "BandedGridColumnAprBudget"
        Me.BandedGridColumnAprBudget.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "4_budget", "{0:N2}")})
        Me.BandedGridColumnAprBudget.Visible = True
        '
        'BandedGridColumnAprActual
        '
        Me.BandedGridColumnAprActual.Caption = "Actual"
        Me.BandedGridColumnAprActual.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnAprActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnAprActual.FieldName = "4_actual"
        Me.BandedGridColumnAprActual.Name = "BandedGridColumnAprActual"
        Me.BandedGridColumnAprActual.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "4_actual", "{0:N2}")})
        Me.BandedGridColumnAprActual.Visible = True
        '
        'BandedGridColumnAprDiff
        '
        Me.BandedGridColumnAprDiff.Caption = "Remaining"
        Me.BandedGridColumnAprDiff.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnAprDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnAprDiff.FieldName = "4_diff"
        Me.BandedGridColumnAprDiff.Name = "BandedGridColumnAprDiff"
        Me.BandedGridColumnAprDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "4_diff", "{0:N2}")})
        Me.BandedGridColumnAprDiff.UnboundExpression = "[4_budget] - [4_actual]"
        Me.BandedGridColumnAprDiff.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnAprDiff.Visible = True
        '
        'gridBand5
        '
        Me.gridBand5.Caption = "May"
        Me.gridBand5.Columns.Add(Me.BandedGridColumnMayBudget)
        Me.gridBand5.Columns.Add(Me.BandedGridColumnMayActual)
        Me.gridBand5.Columns.Add(Me.BandedGridColumnMayDiff)
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.VisibleIndex = 5
        Me.gridBand5.Width = 225
        '
        'BandedGridColumnMayBudget
        '
        Me.BandedGridColumnMayBudget.Caption = "Budget"
        Me.BandedGridColumnMayBudget.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnMayBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnMayBudget.FieldName = "5_budget"
        Me.BandedGridColumnMayBudget.Name = "BandedGridColumnMayBudget"
        Me.BandedGridColumnMayBudget.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "5_budget", "{0:N2}")})
        Me.BandedGridColumnMayBudget.Visible = True
        '
        'BandedGridColumnMayActual
        '
        Me.BandedGridColumnMayActual.Caption = "Actual"
        Me.BandedGridColumnMayActual.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnMayActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnMayActual.FieldName = "5_actual"
        Me.BandedGridColumnMayActual.Name = "BandedGridColumnMayActual"
        Me.BandedGridColumnMayActual.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "5_actual", "{0:N2}")})
        Me.BandedGridColumnMayActual.Visible = True
        '
        'BandedGridColumnMayDiff
        '
        Me.BandedGridColumnMayDiff.Caption = "Remaining"
        Me.BandedGridColumnMayDiff.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnMayDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnMayDiff.FieldName = "5_diff"
        Me.BandedGridColumnMayDiff.Name = "BandedGridColumnMayDiff"
        Me.BandedGridColumnMayDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "5_diff", "{0:N2}")})
        Me.BandedGridColumnMayDiff.UnboundExpression = "[5_budget] - [5_actual]"
        Me.BandedGridColumnMayDiff.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnMayDiff.Visible = True
        '
        'gridBand6
        '
        Me.gridBand6.Caption = "June"
        Me.gridBand6.Columns.Add(Me.BandedGridColumnJuneBudget)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnJuneActual)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnJuneDiff)
        Me.gridBand6.Name = "gridBand6"
        Me.gridBand6.VisibleIndex = 6
        Me.gridBand6.Width = 225
        '
        'BandedGridColumnJuneBudget
        '
        Me.BandedGridColumnJuneBudget.Caption = "Budget"
        Me.BandedGridColumnJuneBudget.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnJuneBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJuneBudget.FieldName = "6_budget"
        Me.BandedGridColumnJuneBudget.Name = "BandedGridColumnJuneBudget"
        Me.BandedGridColumnJuneBudget.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "6_budget", "{0:N2}")})
        Me.BandedGridColumnJuneBudget.Visible = True
        '
        'BandedGridColumnJuneActual
        '
        Me.BandedGridColumnJuneActual.Caption = "Actual"
        Me.BandedGridColumnJuneActual.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnJuneActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJuneActual.FieldName = "6_actual"
        Me.BandedGridColumnJuneActual.Name = "BandedGridColumnJuneActual"
        Me.BandedGridColumnJuneActual.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "6_actual", "{0:N2}")})
        Me.BandedGridColumnJuneActual.Visible = True
        '
        'BandedGridColumnJuneDiff
        '
        Me.BandedGridColumnJuneDiff.Caption = "Remaining"
        Me.BandedGridColumnJuneDiff.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnJuneDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJuneDiff.FieldName = "6_diff"
        Me.BandedGridColumnJuneDiff.Name = "BandedGridColumnJuneDiff"
        Me.BandedGridColumnJuneDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "6_diff", "{0:N2}")})
        Me.BandedGridColumnJuneDiff.UnboundExpression = "[6_budget] - [6_actual]"
        Me.BandedGridColumnJuneDiff.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnJuneDiff.Visible = True
        '
        'gridBand7
        '
        Me.gridBand7.Caption = "July"
        Me.gridBand7.Columns.Add(Me.BandedGridColumnJulyBudget)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnJulyActual)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnJulyDiff)
        Me.gridBand7.Name = "gridBand7"
        Me.gridBand7.VisibleIndex = 7
        Me.gridBand7.Width = 225
        '
        'BandedGridColumnJulyBudget
        '
        Me.BandedGridColumnJulyBudget.Caption = "Budget"
        Me.BandedGridColumnJulyBudget.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnJulyBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJulyBudget.FieldName = "7_budget"
        Me.BandedGridColumnJulyBudget.Name = "BandedGridColumnJulyBudget"
        Me.BandedGridColumnJulyBudget.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "7_budget", "{0:N2}")})
        Me.BandedGridColumnJulyBudget.Visible = True
        '
        'BandedGridColumnJulyActual
        '
        Me.BandedGridColumnJulyActual.Caption = "Actual"
        Me.BandedGridColumnJulyActual.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnJulyActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJulyActual.FieldName = "7_actual"
        Me.BandedGridColumnJulyActual.Name = "BandedGridColumnJulyActual"
        Me.BandedGridColumnJulyActual.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "7_actual", "{0:N2}")})
        Me.BandedGridColumnJulyActual.Visible = True
        '
        'BandedGridColumnJulyDiff
        '
        Me.BandedGridColumnJulyDiff.Caption = "Remaining"
        Me.BandedGridColumnJulyDiff.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumnJulyDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJulyDiff.FieldName = "7_diff"
        Me.BandedGridColumnJulyDiff.Name = "BandedGridColumnJulyDiff"
        Me.BandedGridColumnJulyDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "7_diff", "{0:n2}")})
        Me.BandedGridColumnJulyDiff.UnboundExpression = "[7_budget] - [7_actual]"
        Me.BandedGridColumnJulyDiff.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnJulyDiff.Visible = True
        '
        'gridBand8
        '
        Me.gridBand8.Caption = "August"
        Me.gridBand8.Columns.Add(Me.BandedGridColumnAugBUdget)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnAugActual)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnAugDiff)
        Me.gridBand8.Name = "gridBand8"
        Me.gridBand8.VisibleIndex = 8
        Me.gridBand8.Width = 225
        '
        'BandedGridColumnAugBUdget
        '
        Me.BandedGridColumnAugBUdget.Caption = "Budget"
        Me.BandedGridColumnAugBUdget.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnAugBUdget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnAugBUdget.FieldName = "8_budget"
        Me.BandedGridColumnAugBUdget.Name = "BandedGridColumnAugBUdget"
        Me.BandedGridColumnAugBUdget.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "8_budget", "{0:N2}")})
        Me.BandedGridColumnAugBUdget.Visible = True
        '
        'BandedGridColumnAugActual
        '
        Me.BandedGridColumnAugActual.Caption = "Actual"
        Me.BandedGridColumnAugActual.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnAugActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnAugActual.FieldName = "8_actual"
        Me.BandedGridColumnAugActual.Name = "BandedGridColumnAugActual"
        Me.BandedGridColumnAugActual.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "8_actual", "{0:N2}")})
        Me.BandedGridColumnAugActual.Visible = True
        '
        'BandedGridColumnAugDiff
        '
        Me.BandedGridColumnAugDiff.Caption = "Remaining"
        Me.BandedGridColumnAugDiff.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnAugDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnAugDiff.FieldName = "8_diff"
        Me.BandedGridColumnAugDiff.Name = "BandedGridColumnAugDiff"
        Me.BandedGridColumnAugDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "8_diff", "{0:N2}")})
        Me.BandedGridColumnAugDiff.UnboundExpression = "[8_budget] - [8_actual]"
        Me.BandedGridColumnAugDiff.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnAugDiff.Visible = True
        '
        'gridBand9
        '
        Me.gridBand9.Caption = "September"
        Me.gridBand9.Columns.Add(Me.BandedGridColumnSepBudget)
        Me.gridBand9.Columns.Add(Me.BandedGridColumnSePActual)
        Me.gridBand9.Columns.Add(Me.BandedGridColumnSeptDiff)
        Me.gridBand9.Name = "gridBand9"
        Me.gridBand9.VisibleIndex = 9
        Me.gridBand9.Width = 225
        '
        'BandedGridColumnSepBudget
        '
        Me.BandedGridColumnSepBudget.Caption = "Budget"
        Me.BandedGridColumnSepBudget.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnSepBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnSepBudget.FieldName = "9_budget"
        Me.BandedGridColumnSepBudget.Name = "BandedGridColumnSepBudget"
        Me.BandedGridColumnSepBudget.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "9_budget", "{0:N2}")})
        Me.BandedGridColumnSepBudget.Visible = True
        '
        'BandedGridColumnSePActual
        '
        Me.BandedGridColumnSePActual.Caption = "Actual"
        Me.BandedGridColumnSePActual.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnSePActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnSePActual.FieldName = "9_actual"
        Me.BandedGridColumnSePActual.Name = "BandedGridColumnSePActual"
        Me.BandedGridColumnSePActual.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "9_actual", "{0:N2}")})
        Me.BandedGridColumnSePActual.Visible = True
        '
        'BandedGridColumnSeptDiff
        '
        Me.BandedGridColumnSeptDiff.Caption = "Remaining"
        Me.BandedGridColumnSeptDiff.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnSeptDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnSeptDiff.FieldName = "9_diff"
        Me.BandedGridColumnSeptDiff.Name = "BandedGridColumnSeptDiff"
        Me.BandedGridColumnSeptDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "9_diff", "{0:N2}")})
        Me.BandedGridColumnSeptDiff.UnboundExpression = "[9_budget] - [9_actual]"
        Me.BandedGridColumnSeptDiff.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnSeptDiff.Visible = True
        '
        'gridBand10
        '
        Me.gridBand10.Caption = "October"
        Me.gridBand10.Columns.Add(Me.BandedGridColumnOctBudget)
        Me.gridBand10.Columns.Add(Me.BandedGridColumnOctActual)
        Me.gridBand10.Columns.Add(Me.BandedGridColumnOctDiff)
        Me.gridBand10.Name = "gridBand10"
        Me.gridBand10.VisibleIndex = 10
        Me.gridBand10.Width = 225
        '
        'BandedGridColumnOctBudget
        '
        Me.BandedGridColumnOctBudget.Caption = "Budget"
        Me.BandedGridColumnOctBudget.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnOctBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnOctBudget.FieldName = "10_budget"
        Me.BandedGridColumnOctBudget.Name = "BandedGridColumnOctBudget"
        Me.BandedGridColumnOctBudget.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "10_budget", "{0:N2}")})
        Me.BandedGridColumnOctBudget.Visible = True
        '
        'BandedGridColumnOctActual
        '
        Me.BandedGridColumnOctActual.Caption = "Actual"
        Me.BandedGridColumnOctActual.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnOctActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnOctActual.FieldName = "10_actual"
        Me.BandedGridColumnOctActual.Name = "BandedGridColumnOctActual"
        Me.BandedGridColumnOctActual.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "10_actual", "{0:N2}")})
        Me.BandedGridColumnOctActual.Visible = True
        '
        'BandedGridColumnOctDiff
        '
        Me.BandedGridColumnOctDiff.Caption = "Remaining"
        Me.BandedGridColumnOctDiff.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnOctDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnOctDiff.FieldName = "10_diff"
        Me.BandedGridColumnOctDiff.Name = "BandedGridColumnOctDiff"
        Me.BandedGridColumnOctDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "10_diff", "{0:N2}")})
        Me.BandedGridColumnOctDiff.UnboundExpression = "[10_budget] - [10_actual]"
        Me.BandedGridColumnOctDiff.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnOctDiff.Visible = True
        '
        'gridBand11
        '
        Me.gridBand11.Caption = "November"
        Me.gridBand11.Columns.Add(Me.BandedGridColumnNovBudget)
        Me.gridBand11.Columns.Add(Me.BandedGridColumnNovActual)
        Me.gridBand11.Columns.Add(Me.BandedGridColumnNovFiff)
        Me.gridBand11.Name = "gridBand11"
        Me.gridBand11.VisibleIndex = 11
        Me.gridBand11.Width = 225
        '
        'BandedGridColumnNovBudget
        '
        Me.BandedGridColumnNovBudget.Caption = "Budget"
        Me.BandedGridColumnNovBudget.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnNovBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnNovBudget.FieldName = "11_budget"
        Me.BandedGridColumnNovBudget.Name = "BandedGridColumnNovBudget"
        Me.BandedGridColumnNovBudget.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "11_budget", "{0:N2}")})
        Me.BandedGridColumnNovBudget.Visible = True
        '
        'BandedGridColumnNovActual
        '
        Me.BandedGridColumnNovActual.Caption = "Actual"
        Me.BandedGridColumnNovActual.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnNovActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnNovActual.FieldName = "11_actual"
        Me.BandedGridColumnNovActual.Name = "BandedGridColumnNovActual"
        Me.BandedGridColumnNovActual.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "11_actual", "{0:N2}")})
        Me.BandedGridColumnNovActual.Visible = True
        '
        'BandedGridColumnNovFiff
        '
        Me.BandedGridColumnNovFiff.Caption = "Remaining"
        Me.BandedGridColumnNovFiff.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnNovFiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnNovFiff.FieldName = "11_diff"
        Me.BandedGridColumnNovFiff.Name = "BandedGridColumnNovFiff"
        Me.BandedGridColumnNovFiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "11_diff", "{0:N2}")})
        Me.BandedGridColumnNovFiff.UnboundExpression = "[11_budget] - [11_actual]"
        Me.BandedGridColumnNovFiff.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnNovFiff.Visible = True
        '
        'gridBand12
        '
        Me.gridBand12.Caption = "December"
        Me.gridBand12.Columns.Add(Me.BandedGridColumnDecBudget)
        Me.gridBand12.Columns.Add(Me.BandedGridColumnDecActual)
        Me.gridBand12.Columns.Add(Me.BandedGridColumnDecDiff)
        Me.gridBand12.Name = "gridBand12"
        Me.gridBand12.VisibleIndex = 12
        Me.gridBand12.Width = 225
        '
        'BandedGridColumnDecBudget
        '
        Me.BandedGridColumnDecBudget.Caption = "Budget"
        Me.BandedGridColumnDecBudget.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnDecBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDecBudget.FieldName = "12_budget"
        Me.BandedGridColumnDecBudget.Name = "BandedGridColumnDecBudget"
        Me.BandedGridColumnDecBudget.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "12_budget", "{0:N2}")})
        Me.BandedGridColumnDecBudget.Visible = True
        '
        'BandedGridColumnDecActual
        '
        Me.BandedGridColumnDecActual.Caption = "Actual"
        Me.BandedGridColumnDecActual.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnDecActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDecActual.FieldName = "12_actual"
        Me.BandedGridColumnDecActual.Name = "BandedGridColumnDecActual"
        Me.BandedGridColumnDecActual.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "12_actual", "{0:N2}")})
        Me.BandedGridColumnDecActual.Visible = True
        '
        'BandedGridColumnDecDiff
        '
        Me.BandedGridColumnDecDiff.Caption = "Remaining"
        Me.BandedGridColumnDecDiff.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnDecDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDecDiff.FieldName = "12_diff"
        Me.BandedGridColumnDecDiff.Name = "BandedGridColumnDecDiff"
        Me.BandedGridColumnDecDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "12_diff", "{0:N2}")})
        Me.BandedGridColumnDecDiff.UnboundExpression = "[12_budget] - [12_actual]"
        Me.BandedGridColumnDecDiff.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnDecDiff.Visible = True
        '
        'gridBand13
        '
        Me.gridBand13.Caption = "Total"
        Me.gridBand13.Columns.Add(Me.BandedGridColumnTotalBudget)
        Me.gridBand13.Columns.Add(Me.BandedGridColumnTotalActual)
        Me.gridBand13.Columns.Add(Me.BandedGridColumnTotalDiff)
        Me.gridBand13.Name = "gridBand13"
        Me.gridBand13.VisibleIndex = 13
        Me.gridBand13.Width = 225
        '
        'BandedGridColumnTotalBudget
        '
        Me.BandedGridColumnTotalBudget.Caption = "Budget"
        Me.BandedGridColumnTotalBudget.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnTotalBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalBudget.FieldName = "total_budget"
        Me.BandedGridColumnTotalBudget.Name = "BandedGridColumnTotalBudget"
        Me.BandedGridColumnTotalBudget.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_budget", "{0:N2}")})
        Me.BandedGridColumnTotalBudget.UnboundExpression = "[1_budget] + [2_budget] + [3_budget] + [4_budget] + [5_budget] + [6_budget] + [7_" &
    "budget] + [8_budget] + [9_budget] + [10_budget] + [11_budget] + [12_budget]"
        Me.BandedGridColumnTotalBudget.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnTotalBudget.Visible = True
        '
        'BandedGridColumnTotalActual
        '
        Me.BandedGridColumnTotalActual.Caption = "Actual"
        Me.BandedGridColumnTotalActual.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnTotalActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalActual.FieldName = "total_actual"
        Me.BandedGridColumnTotalActual.Name = "BandedGridColumnTotalActual"
        Me.BandedGridColumnTotalActual.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_actual", "{0:N2}")})
        Me.BandedGridColumnTotalActual.UnboundExpression = "[1_actual] + [2_actual] + [3_actual] + [4_actual] + [5_actual] + [6_actual] + [7_" &
    "actual] + [8_actual] + [9_actual] + [10_actual] + [11_actual] + [12_actual]"
        Me.BandedGridColumnTotalActual.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnTotalActual.Visible = True
        '
        'BandedGridColumnTotalDiff
        '
        Me.BandedGridColumnTotalDiff.Caption = "Remaining"
        Me.BandedGridColumnTotalDiff.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnTotalDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalDiff.FieldName = "total_diff"
        Me.BandedGridColumnTotalDiff.Name = "BandedGridColumnTotalDiff"
        Me.BandedGridColumnTotalDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_diff", "{0:N2}")})
        Me.BandedGridColumnTotalDiff.UnboundExpression = "[1_diff] + [2_diff] + [3_diff] + [4_diff] + [5_diff] + [6_diff] + [7_diff] + [8_d" &
    "iff] + [9_diff] + [10_diff] + [11_diff] + [12_diff]"
        Me.BandedGridColumnTotalDiff.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnTotalDiff.Visible = True
        '
        'BandedGridColumnIdItemCOA
        '
        Me.BandedGridColumnIdItemCOA.Caption = "id_item_coa"
        Me.BandedGridColumnIdItemCOA.FieldName = "id_item_coa"
        Me.BandedGridColumnIdItemCOA.Name = "BandedGridColumnIdItemCOA"
        Me.BandedGridColumnIdItemCOA.OptionsColumn.ShowInCustomizationForm = False
        '
        'PanelMain
        '
        Me.PanelMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelMain.Controls.Add(Me.GCData)
        Me.PanelMain.Controls.Add(Me.PanelControl2)
        Me.PanelMain.Controls.Add(Me.PanelControl1)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(781, 617)
        Me.PanelMain.TabIndex = 6
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.CEBudgetHistory)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 574)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(781, 43)
        Me.PanelControl2.TabIndex = 5
        '
        'CEBudgetHistory
        '
        Me.CEBudgetHistory.Location = New System.Drawing.Point(14, 12)
        Me.CEBudgetHistory.Name = "CEBudgetHistory"
        Me.CEBudgetHistory.Properties.Caption = "Show budget history"
        Me.CEBudgetHistory.Size = New System.Drawing.Size(128, 19)
        Me.CEBudgetHistory.TabIndex = 0
        '
        'GroupControlBudgetRevision
        '
        Me.GroupControlBudgetRevision.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControlBudgetRevision.Appearance.Options.UseFont = True
        Me.GroupControlBudgetRevision.Controls.Add(Me.GCBudgetHist)
        Me.GroupControlBudgetRevision.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupControlBudgetRevision.Location = New System.Drawing.Point(781, 0)
        Me.GroupControlBudgetRevision.LookAndFeel.SkinName = "Office 2007 Silver"
        Me.GroupControlBudgetRevision.Name = "GroupControlBudgetRevision"
        Me.GroupControlBudgetRevision.Size = New System.Drawing.Size(452, 617)
        Me.GroupControlBudgetRevision.TabIndex = 9
        Me.GroupControlBudgetRevision.Text = "Budget Transaction History"
        Me.GroupControlBudgetRevision.Visible = False
        '
        'GCBudgetHist
        '
        Me.GCBudgetHist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBudgetHist.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GCBudgetHist.Location = New System.Drawing.Point(2, 20)
        Me.GCBudgetHist.LookAndFeel.SkinName = "Visual Studio 2013 Light"
        Me.GCBudgetHist.MainView = Me.GVBudgetHist
        Me.GCBudgetHist.Name = "GCBudgetHist"
        Me.GCBudgetHist.Size = New System.Drawing.Size(448, 595)
        Me.GCBudgetHist.TabIndex = 0
        Me.GCBudgetHist.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBudgetHist})
        '
        'GVBudgetHist
        '
        Me.GVBudgetHist.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GVBudgetHist.GridControl = Me.GCBudgetHist
        Me.GVBudgetHist.Name = "GVBudgetHist"
        Me.GVBudgetHist.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVBudgetHist.OptionsBehavior.Editable = False
        Me.GVBudgetHist.OptionsCustomization.AllowSort = False
        Me.GVBudgetHist.OptionsView.ColumnAutoWidth = False
        Me.GVBudgetHist.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Transaction#"
        Me.GridColumn1.FieldName = "trans_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Date"
        Me.GridColumn2.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn2.FieldName = "trans_date"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Before"
        Me.GridColumn3.DisplayFormat.FormatString = "N2"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.FieldName = "trans_before_value"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "After"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "trans_after_value"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Id report"
        Me.GridColumn5.FieldName = "id_report"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "rmt"
        Me.GridColumn6.FieldName = "report_mark_type"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.ShowInCustomizationForm = False
        '
        'FormBudgetExpenseView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1233, 617)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.GroupControlBudgetRevision)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBudgetExpenseView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Expense Budget"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LEYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMain.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.CEBudgetHistory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlBudgetRevision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlBudgetRevision.ResumeLayout(False)
        CType(Me.GCBudgetHist, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBudgetHist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LECat As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEDeptSum As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BandedGridColumnCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDescription As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCat As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnExpType As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJanBudget As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJanActual As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJanDiff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnFebBudget As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnFebActual As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnFebDiff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnMarBudget As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnMarActual As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnMarDiff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnAprBudget As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnAprActual As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnAprDiff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnMayBudget As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnMayActual As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnMayDiff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJuneBudget As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJuneActual As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJuneDiff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJulyBudget As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJulyActual As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJulyDiff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnAugBUdget As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnAugActual As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnAugDiff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSepBudget As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSePActual As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSeptDiff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnOctBudget As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnOctActual As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnOctDiff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnNovBudget As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnNovActual As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnNovFiff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDecBudget As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDecActual As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDecDiff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalBudget As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalActual As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalDiff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LEYear As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GridBandGeneral As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand7 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand8 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand9 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand10 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand11 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand12 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand13 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents PanelMain As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CEBudgetHistory As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GroupControlBudgetRevision As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCBudgetHist As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBudgetHist As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumnIdItemCOA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
End Class
