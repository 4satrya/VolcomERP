﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportBalanceSheet
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
        Me.PCFilterUpper = New DevExpress.XtraEditors.PanelControl()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEUnit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.TLBalanceSheet = New DevExpress.XtraTreeList.TreeList()
        Me.treeListBand3 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.TCLAccount = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLDescription = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.treeListBand4 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.TCLPrevMonth = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLThisMonth = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCIDAcc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCIDAccParent = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLDebit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLCredit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCAllChild = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.treeListBand1 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.treeListBand2 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.XTCBalanceSheet = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPGeneralLedger = New DevExpress.XtraTab.XtraTabPage()
        Me.TLLedger = New DevExpress.XtraTreeList.TreeList()
        Me.treeListBand5 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.TCLAccName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLAccDescription = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.treeListBand6 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.TCLedDebit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLedCredit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLIDAcc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLIdAccParent = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLedIDAllChild = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.XTPBalanceSheet = New DevExpress.XtraTab.XtraTabPage()
        Me.XTCBS = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPBSLedger = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPBSReport = New DevExpress.XtraTab.XtraTabPage()
        Me.SplitterBS = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCAktiva = New DevExpress.XtraGrid.GridControl()
        Me.GVAktiva = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn13 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnPrevMonth = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnThisMonth = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn12 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn14 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GCPasiva = New DevExpress.XtraGrid.GridControl()
        Me.GVPasiva = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn15 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn16 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn17 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn18 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.XTPProfitAndLoss = New DevExpress.XtraTab.XtraTabPage()
        Me.XTCProfitAndLoss = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPATreeView = New DevExpress.XtraTab.XtraTabPage()
        Me.TLProfitAndLoss = New DevExpress.XtraTreeList.TreeList()
        Me.treeListBand7 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.TCPLAccount = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCPLDescription = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.treeListBand8 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.TCPLPrevMonth = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCPLThisMonth = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCPLIdAcc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCPLIdAccParent = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCPLDebit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCPLCredit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCPLIdAllChild = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.XTPPLReportView = New DevExpress.XtraTab.XtraTabPage()
        Me.GCProfitAndLoss = New DevExpress.XtraGrid.GridControl()
        Me.GVProfitAndLoss = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn19 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn20 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn21 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn28 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn22 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn27 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnYTD = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn29 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn23 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn24 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn25 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.XTPPajak = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPTaxDetail = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPendingLapor = New DevExpress.XtraTab.XtraTabPage()
        Me.GCTaxReport = New DevExpress.XtraGrid.GridControl()
        Me.ViewMenu = New System.Windows.Forms.ContextMenuStrip()
        Me.ViewDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewJournalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVTaxReport = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn52 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICETaxReport = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnTaxCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVendorCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPPNPPH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTarif = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDPP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAlamatNPWP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BReported = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEditSelAll = New DevExpress.XtraEditors.CheckEdit()
        Me.XTPPendingTransaction = New DevExpress.XtraTab.XtraTabPage()
        Me.GCTaxPending = New DevExpress.XtraGrid.GridControl()
        Me.GVTaxPending = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPLapor = New DevExpress.XtraTab.XtraTabPage()
        Me.GCActiveTax = New DevExpress.XtraGrid.GridControl()
        Me.GVActiveTax = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICEActiveTax = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnActiveTaxCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn38 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn46 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn48 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn49 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn50 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn51 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BMoveActiveTax = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.CESelAllActiveTax = New DevExpress.XtraEditors.CheckEdit()
        Me.PCPajak = New DevExpress.XtraEditors.PanelControl()
        Me.XtraScrollableControl1 = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.SBSetup = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.SBSummary = New DevExpress.XtraEditors.SimpleButton()
        Me.DETaxFrom = New DevExpress.XtraEditors.DateEdit()
        Me.SLETaxCat = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BViewPajak = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.BPrintPajak = New DevExpress.XtraEditors.SimpleButton()
        Me.SLETaxTagCOA = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.DETaxUntil = New DevExpress.XtraEditors.DateEdit()
        Me.SBSummaryPpn = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PCFilterUpper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCFilterUpper.SuspendLayout()
        CType(Me.SLEUnit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TLBalanceSheet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCBalanceSheet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCBalanceSheet.SuspendLayout()
        Me.XTPGeneralLedger.SuspendLayout()
        CType(Me.TLLedger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPBalanceSheet.SuspendLayout()
        CType(Me.XTCBS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCBS.SuspendLayout()
        Me.XTPBSLedger.SuspendLayout()
        Me.XTPBSReport.SuspendLayout()
        CType(Me.SplitterBS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitterBS.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCAktiva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAktiva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GCPasiva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPasiva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPProfitAndLoss.SuspendLayout()
        CType(Me.XTCProfitAndLoss, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCProfitAndLoss.SuspendLayout()
        Me.XTPPATreeView.SuspendLayout()
        CType(Me.TLProfitAndLoss, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPPLReportView.SuspendLayout()
        CType(Me.GCProfitAndLoss, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProfitAndLoss, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPPajak.SuspendLayout()
        CType(Me.XTPTaxDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPTaxDetail.SuspendLayout()
        Me.XTPPendingLapor.SuspendLayout()
        CType(Me.GCTaxReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewMenu.SuspendLayout()
        CType(Me.GVTaxReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICETaxReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPPendingTransaction.SuspendLayout()
        CType(Me.GCTaxPending, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVTaxPending, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPLapor.SuspendLayout()
        CType(Me.GCActiveTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVActiveTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEActiveTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.CESelAllActiveTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCPajak, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCPajak.SuspendLayout()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.DETaxFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETaxFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLETaxCat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLETaxTagCOA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETaxUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETaxUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PCFilterUpper
        '
        Me.PCFilterUpper.Controls.Add(Me.BPrint)
        Me.PCFilterUpper.Controls.Add(Me.SLEUnit)
        Me.PCFilterUpper.Controls.Add(Me.LabelControl2)
        Me.PCFilterUpper.Controls.Add(Me.BView)
        Me.PCFilterUpper.Controls.Add(Me.LabelControl1)
        Me.PCFilterUpper.Controls.Add(Me.DEUntil)
        Me.PCFilterUpper.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCFilterUpper.Location = New System.Drawing.Point(0, 0)
        Me.PCFilterUpper.Name = "PCFilterUpper"
        Me.PCFilterUpper.Size = New System.Drawing.Size(1021, 48)
        Me.PCFilterUpper.TabIndex = 0
        '
        'BPrint
        '
        Me.BPrint.Location = New System.Drawing.Point(500, 14)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(50, 23)
        Me.BPrint.TabIndex = 6
        Me.BPrint.Text = "print"
        '
        'SLEUnit
        '
        Me.SLEUnit.Location = New System.Drawing.Point(37, 16)
        Me.SLEUnit.Name = "SLEUnit"
        Me.SLEUnit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEUnit.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEUnit.Size = New System.Drawing.Size(193, 20)
        Me.SLEUnit.TabIndex = 5
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn3, Me.GridColumn2})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "id_coa_tag"
        Me.GridColumn1.FieldName = "id_comp"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.Caption = "Number"
        Me.GridColumn3.FieldName = "tag_code"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 281
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Unit"
        Me.GridColumn2.FieldName = "tag_description"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 1351
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 19)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Unit"
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(444, 14)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(50, 23)
        Me.BView.TabIndex = 3
        Me.BView.Text = "view"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(236, 19)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Date"
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(265, 16)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Size = New System.Drawing.Size(173, 20)
        Me.DEUntil.TabIndex = 1
        '
        'TLBalanceSheet
        '
        Me.TLBalanceSheet.Bands.AddRange(New DevExpress.XtraTreeList.Columns.TreeListBand() {Me.treeListBand3, Me.treeListBand4})
        Me.TLBalanceSheet.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TCIDAcc, Me.TCIDAccParent, Me.TCLAccount, Me.TCLDescription, Me.TCLDebit, Me.TCLCredit, Me.TCAllChild, Me.TCLPrevMonth, Me.TCLThisMonth})
        Me.TLBalanceSheet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLBalanceSheet.Location = New System.Drawing.Point(0, 0)
        Me.TLBalanceSheet.Name = "TLBalanceSheet"
        Me.TLBalanceSheet.OptionsBehavior.EnableFiltering = True
        Me.TLBalanceSheet.OptionsBehavior.PopulateServiceColumns = True
        Me.TLBalanceSheet.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart
        Me.TLBalanceSheet.OptionsFilter.ShowAllValuesInFilterPopup = True
        Me.TLBalanceSheet.OptionsFind.AllowFindPanel = True
        Me.TLBalanceSheet.OptionsView.ShowBandsMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.TLBalanceSheet.Size = New System.Drawing.Size(1009, 416)
        Me.TLBalanceSheet.TabIndex = 1
        '
        'treeListBand3
        '
        Me.treeListBand3.Caption = "Chart Of Account"
        Me.treeListBand3.Columns.Add(Me.TCLAccount)
        Me.treeListBand3.Columns.Add(Me.TCLDescription)
        Me.treeListBand3.Name = "treeListBand3"
        Me.treeListBand3.Width = 423
        '
        'TCLAccount
        '
        Me.TCLAccount.Caption = "Account"
        Me.TCLAccount.FieldName = "acc_name"
        Me.TCLAccount.Name = "TCLAccount"
        Me.TCLAccount.Visible = True
        Me.TCLAccount.VisibleIndex = 0
        Me.TCLAccount.Width = 212
        '
        'TCLDescription
        '
        Me.TCLDescription.Caption = "Description"
        Me.TCLDescription.FieldName = "acc_description"
        Me.TCLDescription.Name = "TCLDescription"
        Me.TCLDescription.Visible = True
        Me.TCLDescription.VisibleIndex = 1
        Me.TCLDescription.Width = 211
        '
        'treeListBand4
        '
        Me.treeListBand4.Caption = "Amount"
        Me.treeListBand4.Columns.Add(Me.TCLPrevMonth)
        Me.treeListBand4.Columns.Add(Me.TCLThisMonth)
        Me.treeListBand4.Name = "treeListBand4"
        Me.treeListBand4.Width = 453
        '
        'TCLPrevMonth
        '
        Me.TCLPrevMonth.Caption = "Previous Month"
        Me.TCLPrevMonth.FieldName = "prev_month"
        Me.TCLPrevMonth.Format.FormatString = "N2"
        Me.TCLPrevMonth.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TCLPrevMonth.Name = "TCLPrevMonth"
        Me.TCLPrevMonth.Visible = True
        Me.TCLPrevMonth.VisibleIndex = 2
        Me.TCLPrevMonth.Width = 227
        '
        'TCLThisMonth
        '
        Me.TCLThisMonth.Caption = "This Month"
        Me.TCLThisMonth.FieldName = "this_month"
        Me.TCLThisMonth.Format.FormatString = "N2"
        Me.TCLThisMonth.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TCLThisMonth.Name = "TCLThisMonth"
        Me.TCLThisMonth.Visible = True
        Me.TCLThisMonth.VisibleIndex = 3
        Me.TCLThisMonth.Width = 226
        '
        'TCIDAcc
        '
        Me.TCIDAcc.Caption = "ID"
        Me.TCIDAcc.FieldName = "id_acc"
        Me.TCIDAcc.Name = "TCIDAcc"
        '
        'TCIDAccParent
        '
        Me.TCIDAccParent.Caption = "ID Acc Parent"
        Me.TCIDAccParent.FieldName = "id_acc_parent"
        Me.TCIDAccParent.Name = "TCIDAccParent"
        '
        'TCLDebit
        '
        Me.TCLDebit.Caption = "Debit"
        Me.TCLDebit.FieldName = "debit"
        Me.TCLDebit.Name = "TCLDebit"
        '
        'TCLCredit
        '
        Me.TCLCredit.Caption = "Credit"
        Me.TCLCredit.FieldName = "credit"
        Me.TCLCredit.Name = "TCLCredit"
        '
        'TCAllChild
        '
        Me.TCAllChild.Caption = "ID All Child"
        Me.TCAllChild.FieldName = "id_all_child"
        Me.TCAllChild.Name = "TCAllChild"
        '
        'treeListBand1
        '
        Me.treeListBand1.Caption = "Account"
        Me.treeListBand1.Name = "treeListBand1"
        '
        'treeListBand2
        '
        Me.treeListBand2.Caption = "Amount"
        Me.treeListBand2.Name = "treeListBand2"
        '
        'XTCBalanceSheet
        '
        Me.XTCBalanceSheet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCBalanceSheet.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCBalanceSheet.Location = New System.Drawing.Point(0, 48)
        Me.XTCBalanceSheet.Name = "XTCBalanceSheet"
        Me.XTCBalanceSheet.SelectedTabPage = Me.XTPGeneralLedger
        Me.XTCBalanceSheet.Size = New System.Drawing.Size(1021, 472)
        Me.XTCBalanceSheet.TabIndex = 2
        Me.XTCBalanceSheet.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPGeneralLedger, Me.XTPBalanceSheet, Me.XTPProfitAndLoss, Me.XTPPajak})
        '
        'XTPGeneralLedger
        '
        Me.XTPGeneralLedger.Controls.Add(Me.TLLedger)
        Me.XTPGeneralLedger.Name = "XTPGeneralLedger"
        Me.XTPGeneralLedger.Size = New System.Drawing.Size(1015, 444)
        Me.XTPGeneralLedger.Text = "Ledger"
        '
        'TLLedger
        '
        Me.TLLedger.Bands.AddRange(New DevExpress.XtraTreeList.Columns.TreeListBand() {Me.treeListBand5, Me.treeListBand6})
        Me.TLLedger.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TCLIDAcc, Me.TCLIdAccParent, Me.TCLAccName, Me.TCLAccDescription, Me.TCLedDebit, Me.TCLedCredit, Me.TCLedIDAllChild})
        Me.TLLedger.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLLedger.Location = New System.Drawing.Point(0, 0)
        Me.TLLedger.Name = "TLLedger"
        Me.TLLedger.OptionsBehavior.EnableFiltering = True
        Me.TLLedger.OptionsFind.AllowFindPanel = True
        Me.TLLedger.Size = New System.Drawing.Size(1015, 444)
        Me.TLLedger.TabIndex = 0
        '
        'treeListBand5
        '
        Me.treeListBand5.Caption = "Account"
        Me.treeListBand5.Columns.Add(Me.TCLAccName)
        Me.treeListBand5.Columns.Add(Me.TCLAccDescription)
        Me.treeListBand5.Name = "treeListBand5"
        Me.treeListBand5.Width = 427
        '
        'TCLAccName
        '
        Me.TCLAccName.Caption = "Account"
        Me.TCLAccName.FieldName = "acc_name"
        Me.TCLAccName.Name = "TCLAccName"
        Me.TCLAccName.Visible = True
        Me.TCLAccName.VisibleIndex = 0
        Me.TCLAccName.Width = 213
        '
        'TCLAccDescription
        '
        Me.TCLAccDescription.Caption = "Description"
        Me.TCLAccDescription.FieldName = "acc_description"
        Me.TCLAccDescription.Name = "TCLAccDescription"
        Me.TCLAccDescription.Visible = True
        Me.TCLAccDescription.VisibleIndex = 1
        Me.TCLAccDescription.Width = 214
        '
        'treeListBand6
        '
        Me.treeListBand6.Caption = "Amount"
        Me.treeListBand6.Columns.Add(Me.TCLedDebit)
        Me.treeListBand6.Columns.Add(Me.TCLedCredit)
        Me.treeListBand6.Name = "treeListBand6"
        Me.treeListBand6.Width = 449
        '
        'TCLedDebit
        '
        Me.TCLedDebit.Caption = "Debit"
        Me.TCLedDebit.FieldName = "debit"
        Me.TCLedDebit.Format.FormatString = "N2"
        Me.TCLedDebit.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TCLedDebit.Name = "TCLedDebit"
        Me.TCLedDebit.Visible = True
        Me.TCLedDebit.VisibleIndex = 2
        Me.TCLedDebit.Width = 226
        '
        'TCLedCredit
        '
        Me.TCLedCredit.Caption = "Credit"
        Me.TCLedCredit.FieldName = "credit"
        Me.TCLedCredit.Format.FormatString = "N2"
        Me.TCLedCredit.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TCLedCredit.Name = "TCLedCredit"
        Me.TCLedCredit.Visible = True
        Me.TCLedCredit.VisibleIndex = 3
        Me.TCLedCredit.Width = 223
        '
        'TCLIDAcc
        '
        Me.TCLIDAcc.Caption = "ID Acc"
        Me.TCLIDAcc.FieldName = "id_acc"
        Me.TCLIDAcc.Name = "TCLIDAcc"
        '
        'TCLIdAccParent
        '
        Me.TCLIdAccParent.Caption = "ID Acc Parent"
        Me.TCLIdAccParent.FieldName = "id_acc_parent"
        Me.TCLIdAccParent.Name = "TCLIdAccParent"
        '
        'TCLedIDAllChild
        '
        Me.TCLedIDAllChild.Caption = "ID All Child"
        Me.TCLedIDAllChild.FieldName = "id_all_child"
        Me.TCLedIDAllChild.Name = "TCLedIDAllChild"
        '
        'XTPBalanceSheet
        '
        Me.XTPBalanceSheet.Controls.Add(Me.XTCBS)
        Me.XTPBalanceSheet.Name = "XTPBalanceSheet"
        Me.XTPBalanceSheet.Size = New System.Drawing.Size(1015, 444)
        Me.XTPBalanceSheet.Text = "Balance Sheet"
        '
        'XTCBS
        '
        Me.XTCBS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCBS.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCBS.Location = New System.Drawing.Point(0, 0)
        Me.XTCBS.Name = "XTCBS"
        Me.XTCBS.SelectedTabPage = Me.XTPBSLedger
        Me.XTCBS.Size = New System.Drawing.Size(1015, 444)
        Me.XTCBS.TabIndex = 2
        Me.XTCBS.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPBSLedger, Me.XTPBSReport})
        '
        'XTPBSLedger
        '
        Me.XTPBSLedger.Controls.Add(Me.TLBalanceSheet)
        Me.XTPBSLedger.Name = "XTPBSLedger"
        Me.XTPBSLedger.Size = New System.Drawing.Size(1009, 416)
        Me.XTPBSLedger.Text = "Tree View"
        '
        'XTPBSReport
        '
        Me.XTPBSReport.Controls.Add(Me.SplitterBS)
        Me.XTPBSReport.Name = "XTPBSReport"
        Me.XTPBSReport.Size = New System.Drawing.Size(1009, 416)
        Me.XTPBSReport.Text = "Report View"
        '
        'SplitterBS
        '
        Me.SplitterBS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitterBS.Location = New System.Drawing.Point(0, 0)
        Me.SplitterBS.Name = "SplitterBS"
        Me.SplitterBS.Panel1.Controls.Add(Me.GroupControl1)
        Me.SplitterBS.Panel1.Text = "Panel1"
        Me.SplitterBS.Panel2.Controls.Add(Me.GroupControl2)
        Me.SplitterBS.Panel2.Text = "Panel2"
        Me.SplitterBS.Size = New System.Drawing.Size(1009, 416)
        Me.SplitterBS.SplitterPosition = 422
        Me.SplitterBS.TabIndex = 0
        Me.SplitterBS.Text = "SplitContainerControl1"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GCAktiva)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(422, 416)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Asset"
        '
        'GCAktiva
        '
        Me.GCAktiva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAktiva.Location = New System.Drawing.Point(2, 20)
        Me.GCAktiva.MainView = Me.GVAktiva
        Me.GCAktiva.Name = "GCAktiva"
        Me.GCAktiva.Size = New System.Drawing.Size(418, 394)
        Me.GCAktiva.TabIndex = 0
        Me.GCAktiva.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAktiva})
        '
        'GVAktiva
        '
        Me.GVAktiva.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand3})
        Me.GVAktiva.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn12, Me.BandedGridColumn11, Me.BandedGridColumn14, Me.BandedGridColumn13, Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumnThisMonth, Me.BandedGridColumnPrevMonth})
        Me.GVAktiva.GridControl = Me.GCAktiva
        Me.GVAktiva.GroupCount = 2
        Me.GVAktiva.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", Me.BandedGridColumnThisMonth, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", Me.BandedGridColumnPrevMonth, "{0:N2}")})
        Me.GVAktiva.Name = "GVAktiva"
        Me.GVAktiva.OptionsView.ShowFooter = True
        Me.GVAktiva.OptionsView.ShowGroupPanel = False
        Me.GVAktiva.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn11, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn13, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "Account"
        Me.GridBand1.Columns.Add(Me.BandedGridColumn11)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn13)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn2)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn3)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 150
        '
        'BandedGridColumn11
        '
        Me.BandedGridColumn11.Caption = "Head"
        Me.BandedGridColumn11.FieldName = "head_desc"
        Me.BandedGridColumn11.FieldNameSortGroup = "head_name"
        Me.BandedGridColumn11.Name = "BandedGridColumn11"
        '
        'BandedGridColumn13
        '
        Me.BandedGridColumn13.Caption = "Sub"
        Me.BandedGridColumn13.FieldName = "sub_desc"
        Me.BandedGridColumn13.FieldNameSortGroup = "sub_name"
        Me.BandedGridColumn13.Name = "BandedGridColumn13"
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "No"
        Me.BandedGridColumn2.FieldName = "acc_name"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "Name"
        Me.BandedGridColumn3.FieldName = "acc_description"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.Visible = True
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "Amount"
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPrevMonth)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnThisMonth)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 1
        Me.gridBand3.Width = 150
        '
        'BandedGridColumnPrevMonth
        '
        Me.BandedGridColumnPrevMonth.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnPrevMonth.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPrevMonth.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnPrevMonth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPrevMonth.Caption = "Prev Month"
        Me.BandedGridColumnPrevMonth.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnPrevMonth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnPrevMonth.FieldName = "prev_month"
        Me.BandedGridColumnPrevMonth.Name = "BandedGridColumnPrevMonth"
        Me.BandedGridColumnPrevMonth.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", "{0:N2}")})
        Me.BandedGridColumnPrevMonth.Visible = True
        '
        'BandedGridColumnThisMonth
        '
        Me.BandedGridColumnThisMonth.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnThisMonth.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnThisMonth.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnThisMonth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnThisMonth.Caption = "This Month"
        Me.BandedGridColumnThisMonth.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnThisMonth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnThisMonth.FieldName = "this_month"
        Me.BandedGridColumnThisMonth.Name = "BandedGridColumnThisMonth"
        Me.BandedGridColumnThisMonth.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", "{0:N2}")})
        Me.BandedGridColumnThisMonth.Visible = True
        '
        'BandedGridColumn12
        '
        Me.BandedGridColumn12.Caption = "Head Name"
        Me.BandedGridColumn12.FieldName = "head_name"
        Me.BandedGridColumn12.Name = "BandedGridColumn12"
        Me.BandedGridColumn12.Visible = True
        '
        'BandedGridColumn14
        '
        Me.BandedGridColumn14.Caption = "Sub Name"
        Me.BandedGridColumn14.FieldName = "sub_name"
        Me.BandedGridColumn14.Name = "BandedGridColumn14"
        Me.BandedGridColumn14.Visible = True
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "ID Acc"
        Me.BandedGridColumn1.FieldName = "id_acc"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GCPasiva)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(582, 416)
        Me.GroupControl2.TabIndex = 2
        Me.GroupControl2.Text = "Liability And Equity"
        '
        'GCPasiva
        '
        Me.GCPasiva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPasiva.Location = New System.Drawing.Point(2, 20)
        Me.GCPasiva.MainView = Me.GVPasiva
        Me.GCPasiva.Name = "GCPasiva"
        Me.GCPasiva.Size = New System.Drawing.Size(578, 394)
        Me.GCPasiva.TabIndex = 1
        Me.GCPasiva.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPasiva})
        '
        'GVPasiva
        '
        Me.GVPasiva.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand2, Me.GridBand4})
        Me.GVPasiva.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn16, Me.BandedGridColumn6, Me.BandedGridColumn17, Me.BandedGridColumn7, Me.BandedGridColumn18, Me.BandedGridColumn8, Me.BandedGridColumn9, Me.BandedGridColumn15, Me.BandedGridColumn10})
        Me.GVPasiva.GridControl = Me.GCPasiva
        Me.GVPasiva.GroupCount = 2
        Me.GVPasiva.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", Me.BandedGridColumn15, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", Me.BandedGridColumn10, "{0:N2}")})
        Me.GVPasiva.Name = "GVPasiva"
        Me.GVPasiva.OptionsView.ShowFooter = True
        Me.GVPasiva.OptionsView.ShowGroupPanel = False
        Me.GVPasiva.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn6, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn7, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand2
        '
        Me.GridBand2.Caption = "Account"
        Me.GridBand2.Columns.Add(Me.BandedGridColumn6)
        Me.GridBand2.Columns.Add(Me.BandedGridColumn7)
        Me.GridBand2.Columns.Add(Me.BandedGridColumn8)
        Me.GridBand2.Columns.Add(Me.BandedGridColumn9)
        Me.GridBand2.Name = "GridBand2"
        Me.GridBand2.VisibleIndex = 0
        Me.GridBand2.Width = 150
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.Caption = "Head"
        Me.BandedGridColumn6.FieldName = "head_desc"
        Me.BandedGridColumn6.FieldNameSortGroup = "head_name"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.Caption = "Sub"
        Me.BandedGridColumn7.FieldName = "sub_desc"
        Me.BandedGridColumn7.FieldNameSortGroup = "sub_name"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.Caption = "No"
        Me.BandedGridColumn8.FieldName = "acc_name"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.Visible = True
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.Caption = "Name"
        Me.BandedGridColumn9.FieldName = "acc_description"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        Me.BandedGridColumn9.Visible = True
        '
        'GridBand4
        '
        Me.GridBand4.Caption = "Amount"
        Me.GridBand4.Columns.Add(Me.BandedGridColumn10)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn15)
        Me.GridBand4.Name = "GridBand4"
        Me.GridBand4.VisibleIndex = 1
        Me.GridBand4.Width = 150
        '
        'BandedGridColumn10
        '
        Me.BandedGridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn10.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn10.Caption = "Prev Month"
        Me.BandedGridColumn10.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn10.FieldName = "prev_month"
        Me.BandedGridColumn10.Name = "BandedGridColumn10"
        Me.BandedGridColumn10.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", "{0:N2}")})
        Me.BandedGridColumn10.Visible = True
        '
        'BandedGridColumn15
        '
        Me.BandedGridColumn15.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn15.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn15.Caption = "This Month"
        Me.BandedGridColumn15.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn15.FieldName = "this_month"
        Me.BandedGridColumn15.Name = "BandedGridColumn15"
        Me.BandedGridColumn15.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", "{0:N2}")})
        Me.BandedGridColumn15.Visible = True
        '
        'BandedGridColumn16
        '
        Me.BandedGridColumn16.Caption = "Head Name"
        Me.BandedGridColumn16.FieldName = "head_name"
        Me.BandedGridColumn16.Name = "BandedGridColumn16"
        Me.BandedGridColumn16.Visible = True
        '
        'BandedGridColumn17
        '
        Me.BandedGridColumn17.Caption = "Sub Name"
        Me.BandedGridColumn17.FieldName = "sub_name"
        Me.BandedGridColumn17.Name = "BandedGridColumn17"
        Me.BandedGridColumn17.Visible = True
        '
        'BandedGridColumn18
        '
        Me.BandedGridColumn18.Caption = "ID Acc"
        Me.BandedGridColumn18.FieldName = "id_acc"
        Me.BandedGridColumn18.Name = "BandedGridColumn18"
        '
        'XTPProfitAndLoss
        '
        Me.XTPProfitAndLoss.Controls.Add(Me.XTCProfitAndLoss)
        Me.XTPProfitAndLoss.Name = "XTPProfitAndLoss"
        Me.XTPProfitAndLoss.Size = New System.Drawing.Size(1015, 444)
        Me.XTPProfitAndLoss.Text = "Profit And Loss"
        '
        'XTCProfitAndLoss
        '
        Me.XTCProfitAndLoss.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCProfitAndLoss.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCProfitAndLoss.Location = New System.Drawing.Point(0, 0)
        Me.XTCProfitAndLoss.Name = "XTCProfitAndLoss"
        Me.XTCProfitAndLoss.SelectedTabPage = Me.XTPPATreeView
        Me.XTCProfitAndLoss.Size = New System.Drawing.Size(1015, 444)
        Me.XTCProfitAndLoss.TabIndex = 0
        Me.XTCProfitAndLoss.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPATreeView, Me.XTPPLReportView})
        '
        'XTPPATreeView
        '
        Me.XTPPATreeView.Controls.Add(Me.TLProfitAndLoss)
        Me.XTPPATreeView.Name = "XTPPATreeView"
        Me.XTPPATreeView.Size = New System.Drawing.Size(1009, 416)
        Me.XTPPATreeView.Text = "Tree View"
        '
        'TLProfitAndLoss
        '
        Me.TLProfitAndLoss.Bands.AddRange(New DevExpress.XtraTreeList.Columns.TreeListBand() {Me.treeListBand7, Me.treeListBand8})
        Me.TLProfitAndLoss.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TCPLIdAcc, Me.TCPLIdAccParent, Me.TCPLAccount, Me.TCPLDescription, Me.TCPLDebit, Me.TCPLCredit, Me.TCPLIdAllChild, Me.TCPLPrevMonth, Me.TCPLThisMonth})
        Me.TLProfitAndLoss.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLProfitAndLoss.Location = New System.Drawing.Point(0, 0)
        Me.TLProfitAndLoss.Name = "TLProfitAndLoss"
        Me.TLProfitAndLoss.Size = New System.Drawing.Size(1009, 416)
        Me.TLProfitAndLoss.TabIndex = 0
        '
        'treeListBand7
        '
        Me.treeListBand7.Caption = "Account"
        Me.treeListBand7.Columns.Add(Me.TCPLAccount)
        Me.treeListBand7.Columns.Add(Me.TCPLDescription)
        Me.treeListBand7.Name = "treeListBand7"
        '
        'TCPLAccount
        '
        Me.TCPLAccount.Caption = "Account"
        Me.TCPLAccount.FieldName = "coa_name"
        Me.TCPLAccount.Name = "TCPLAccount"
        Me.TCPLAccount.Visible = True
        Me.TCPLAccount.VisibleIndex = 0
        '
        'TCPLDescription
        '
        Me.TCPLDescription.Caption = "Description"
        Me.TCPLDescription.FieldName = "coa_description"
        Me.TCPLDescription.Name = "TCPLDescription"
        Me.TCPLDescription.Visible = True
        Me.TCPLDescription.VisibleIndex = 1
        '
        'treeListBand8
        '
        Me.treeListBand8.Caption = "Amount"
        Me.treeListBand8.Columns.Add(Me.TCPLPrevMonth)
        Me.treeListBand8.Columns.Add(Me.TCPLThisMonth)
        Me.treeListBand8.Name = "treeListBand8"
        '
        'TCPLPrevMonth
        '
        Me.TCPLPrevMonth.Caption = "Previous Month"
        Me.TCPLPrevMonth.FieldName = "prev_month"
        Me.TCPLPrevMonth.Format.FormatString = "N2"
        Me.TCPLPrevMonth.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TCPLPrevMonth.Name = "TCPLPrevMonth"
        Me.TCPLPrevMonth.Visible = True
        Me.TCPLPrevMonth.VisibleIndex = 2
        '
        'TCPLThisMonth
        '
        Me.TCPLThisMonth.Caption = "This Month"
        Me.TCPLThisMonth.FieldName = "this_month"
        Me.TCPLThisMonth.Format.FormatString = "N2"
        Me.TCPLThisMonth.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TCPLThisMonth.Name = "TCPLThisMonth"
        Me.TCPLThisMonth.Visible = True
        Me.TCPLThisMonth.VisibleIndex = 3
        '
        'TCPLIdAcc
        '
        Me.TCPLIdAcc.Caption = "ID Acc"
        Me.TCPLIdAcc.FieldName = "id_acc"
        Me.TCPLIdAcc.Name = "TCPLIdAcc"
        Me.TCPLIdAcc.Visible = True
        Me.TCPLIdAcc.VisibleIndex = 0
        '
        'TCPLIdAccParent
        '
        Me.TCPLIdAccParent.Caption = "ID Acc Parent"
        Me.TCPLIdAccParent.FieldName = "id_acc_parent"
        Me.TCPLIdAccParent.Name = "TCPLIdAccParent"
        Me.TCPLIdAccParent.Visible = True
        Me.TCPLIdAccParent.VisibleIndex = 1
        '
        'TCPLDebit
        '
        Me.TCPLDebit.Caption = "Debit"
        Me.TCPLDebit.FieldName = "debit"
        Me.TCPLDebit.Name = "TCPLDebit"
        Me.TCPLDebit.Visible = True
        Me.TCPLDebit.VisibleIndex = 7
        '
        'TCPLCredit
        '
        Me.TCPLCredit.Caption = "Credit"
        Me.TCPLCredit.FieldName = "credit"
        Me.TCPLCredit.Name = "TCPLCredit"
        Me.TCPLCredit.Visible = True
        Me.TCPLCredit.VisibleIndex = 8
        '
        'TCPLIdAllChild
        '
        Me.TCPLIdAllChild.Caption = "ID All Child"
        Me.TCPLIdAllChild.FieldName = "id_all_child"
        Me.TCPLIdAllChild.Name = "TCPLIdAllChild"
        Me.TCPLIdAllChild.Visible = True
        Me.TCPLIdAllChild.VisibleIndex = 6
        '
        'XTPPLReportView
        '
        Me.XTPPLReportView.Controls.Add(Me.GCProfitAndLoss)
        Me.XTPPLReportView.Name = "XTPPLReportView"
        Me.XTPPLReportView.Size = New System.Drawing.Size(1009, 416)
        Me.XTPPLReportView.Text = "Report View"
        '
        'GCProfitAndLoss
        '
        Me.GCProfitAndLoss.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProfitAndLoss.Location = New System.Drawing.Point(0, 0)
        Me.GCProfitAndLoss.MainView = Me.GVProfitAndLoss
        Me.GCProfitAndLoss.Name = "GCProfitAndLoss"
        Me.GCProfitAndLoss.Size = New System.Drawing.Size(1009, 416)
        Me.GCProfitAndLoss.TabIndex = 1
        Me.GCProfitAndLoss.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProfitAndLoss})
        '
        'GVProfitAndLoss
        '
        Me.GVProfitAndLoss.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand5, Me.GridBand6})
        Me.GVProfitAndLoss.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn23, Me.BandedGridColumn4, Me.BandedGridColumn24, Me.BandedGridColumn5, Me.BandedGridColumn25, Me.BandedGridColumn19, Me.BandedGridColumn20, Me.BandedGridColumn22, Me.BandedGridColumn21, Me.BandedGridColumnYTD, Me.BandedGridColumn27, Me.BandedGridColumn28, Me.BandedGridColumn29})
        Me.GVProfitAndLoss.GridControl = Me.GCProfitAndLoss
        Me.GVProfitAndLoss.GroupCount = 2
        Me.GVProfitAndLoss.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", Me.BandedGridColumn22, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", Me.BandedGridColumn21, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_year_to_date", Me.BandedGridColumnYTD, "{0:N2}")})
        Me.GVProfitAndLoss.Name = "GVProfitAndLoss"
        Me.GVProfitAndLoss.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVProfitAndLoss.OptionsView.ShowFooter = True
        Me.GVProfitAndLoss.OptionsView.ShowGroupPanel = False
        Me.GVProfitAndLoss.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn4, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn5, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand5
        '
        Me.GridBand5.Caption = "Account"
        Me.GridBand5.Columns.Add(Me.BandedGridColumn4)
        Me.GridBand5.Columns.Add(Me.BandedGridColumn5)
        Me.GridBand5.Columns.Add(Me.BandedGridColumn19)
        Me.GridBand5.Columns.Add(Me.BandedGridColumn20)
        Me.GridBand5.Name = "GridBand5"
        Me.GridBand5.VisibleIndex = 0
        Me.GridBand5.Width = 150
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "Head"
        Me.BandedGridColumn4.FieldName = "head_desc"
        Me.BandedGridColumn4.FieldNameSortGroup = "head_name"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "Sub"
        Me.BandedGridColumn5.FieldName = "sub_desc"
        Me.BandedGridColumn5.FieldNameSortGroup = "sub_name"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        '
        'BandedGridColumn19
        '
        Me.BandedGridColumn19.Caption = "No"
        Me.BandedGridColumn19.FieldName = "acc_name"
        Me.BandedGridColumn19.Name = "BandedGridColumn19"
        Me.BandedGridColumn19.Visible = True
        '
        'BandedGridColumn20
        '
        Me.BandedGridColumn20.Caption = "Name"
        Me.BandedGridColumn20.FieldName = "acc_description"
        Me.BandedGridColumn20.Name = "BandedGridColumn20"
        Me.BandedGridColumn20.Visible = True
        '
        'GridBand6
        '
        Me.GridBand6.Caption = "Amount"
        Me.GridBand6.Columns.Add(Me.BandedGridColumn21)
        Me.GridBand6.Columns.Add(Me.BandedGridColumn28)
        Me.GridBand6.Columns.Add(Me.BandedGridColumn22)
        Me.GridBand6.Columns.Add(Me.BandedGridColumn27)
        Me.GridBand6.Columns.Add(Me.BandedGridColumnYTD)
        Me.GridBand6.Columns.Add(Me.BandedGridColumn29)
        Me.GridBand6.Name = "GridBand6"
        Me.GridBand6.VisibleIndex = 1
        Me.GridBand6.Width = 450
        '
        'BandedGridColumn21
        '
        Me.BandedGridColumn21.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn21.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn21.Caption = "Prev Month"
        Me.BandedGridColumn21.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn21.FieldName = "prev_month"
        Me.BandedGridColumn21.Name = "BandedGridColumn21"
        Me.BandedGridColumn21.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", "{0:N2}")})
        Me.BandedGridColumn21.Visible = True
        '
        'BandedGridColumn28
        '
        Me.BandedGridColumn28.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn28.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn28.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn28.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn28.Caption = "%"
        Me.BandedGridColumn28.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn28.FieldName = "percent_prev_month"
        Me.BandedGridColumn28.Name = "BandedGridColumn28"
        Me.BandedGridColumn28.Visible = True
        '
        'BandedGridColumn22
        '
        Me.BandedGridColumn22.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn22.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn22.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn22.Caption = "This Month"
        Me.BandedGridColumn22.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn22.FieldName = "this_month"
        Me.BandedGridColumn22.Name = "BandedGridColumn22"
        Me.BandedGridColumn22.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", "{0:N2}")})
        Me.BandedGridColumn22.Visible = True
        '
        'BandedGridColumn27
        '
        Me.BandedGridColumn27.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn27.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn27.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn27.Caption = "%"
        Me.BandedGridColumn27.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn27.FieldName = "percent_this_month"
        Me.BandedGridColumn27.Name = "BandedGridColumn27"
        Me.BandedGridColumn27.Visible = True
        '
        'BandedGridColumnYTD
        '
        Me.BandedGridColumnYTD.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnYTD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnYTD.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnYTD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnYTD.Caption = "Year to Date"
        Me.BandedGridColumnYTD.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnYTD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnYTD.FieldName = "this_year_to_date"
        Me.BandedGridColumnYTD.Name = "BandedGridColumnYTD"
        Me.BandedGridColumnYTD.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_year_to_date", "{0:N2}")})
        Me.BandedGridColumnYTD.Visible = True
        '
        'BandedGridColumn29
        '
        Me.BandedGridColumn29.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn29.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn29.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn29.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn29.Caption = "%"
        Me.BandedGridColumn29.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn29.FieldName = "percent_this_year_to_date"
        Me.BandedGridColumn29.Name = "BandedGridColumn29"
        Me.BandedGridColumn29.Visible = True
        '
        'BandedGridColumn23
        '
        Me.BandedGridColumn23.Caption = "Head Name"
        Me.BandedGridColumn23.FieldName = "head_name"
        Me.BandedGridColumn23.Name = "BandedGridColumn23"
        Me.BandedGridColumn23.Visible = True
        '
        'BandedGridColumn24
        '
        Me.BandedGridColumn24.Caption = "Sub Name"
        Me.BandedGridColumn24.FieldName = "sub_name"
        Me.BandedGridColumn24.Name = "BandedGridColumn24"
        Me.BandedGridColumn24.Visible = True
        '
        'BandedGridColumn25
        '
        Me.BandedGridColumn25.Caption = "ID Acc"
        Me.BandedGridColumn25.FieldName = "id_acc"
        Me.BandedGridColumn25.Name = "BandedGridColumn25"
        '
        'XTPPajak
        '
        Me.XTPPajak.Controls.Add(Me.XTPTaxDetail)
        Me.XTPPajak.Controls.Add(Me.PCPajak)
        Me.XTPPajak.Name = "XTPPajak"
        Me.XTPPajak.Size = New System.Drawing.Size(1015, 444)
        Me.XTPPajak.Text = "Tax Report"
        '
        'XTPTaxDetail
        '
        Me.XTPTaxDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTPTaxDetail.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTPTaxDetail.Location = New System.Drawing.Point(0, 78)
        Me.XTPTaxDetail.Name = "XTPTaxDetail"
        Me.XTPTaxDetail.SelectedTabPage = Me.XTPPendingLapor
        Me.XTPTaxDetail.Size = New System.Drawing.Size(1015, 366)
        Me.XTPTaxDetail.TabIndex = 3
        Me.XTPTaxDetail.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPendingLapor, Me.XTPPendingTransaction, Me.XTPLapor})
        '
        'XTPPendingLapor
        '
        Me.XTPPendingLapor.Controls.Add(Me.GCTaxReport)
        Me.XTPPendingLapor.Controls.Add(Me.PanelControl1)
        Me.XTPPendingLapor.Name = "XTPPendingLapor"
        Me.XTPPendingLapor.Size = New System.Drawing.Size(1009, 338)
        Me.XTPPendingLapor.Text = "Pending Lapor"
        '
        'GCTaxReport
        '
        Me.GCTaxReport.ContextMenuStrip = Me.ViewMenu
        Me.GCTaxReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCTaxReport.Location = New System.Drawing.Point(0, 0)
        Me.GCTaxReport.MainView = Me.GVTaxReport
        Me.GCTaxReport.Name = "GCTaxReport"
        Me.GCTaxReport.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICETaxReport})
        Me.GCTaxReport.Size = New System.Drawing.Size(1009, 298)
        Me.GCTaxReport.TabIndex = 2
        Me.GCTaxReport.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVTaxReport})
        '
        'ViewMenu
        '
        Me.ViewMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDetailToolStripMenuItem, Me.ViewJournalToolStripMenuItem})
        Me.ViewMenu.Name = "ContextMenuStripYM"
        Me.ViewMenu.Size = New System.Drawing.Size(141, 48)
        '
        'ViewDetailToolStripMenuItem
        '
        Me.ViewDetailToolStripMenuItem.Name = "ViewDetailToolStripMenuItem"
        Me.ViewDetailToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ViewDetailToolStripMenuItem.Text = "View Report"
        '
        'ViewJournalToolStripMenuItem
        '
        Me.ViewJournalToolStripMenuItem.Name = "ViewJournalToolStripMenuItem"
        Me.ViewJournalToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ViewJournalToolStripMenuItem.Text = "View Journal"
        '
        'GVTaxReport
        '
        Me.GVTaxReport.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn52, Me.GridColumnTaxCat, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn24, Me.GridColumnDesc, Me.GridColumnVendorCode, Me.GridColumn23, Me.GridColumnPPNPPH, Me.GridColumnTarif, Me.GridColumnDPP, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumnAlamatNPWP, Me.GridColumn17})
        Me.GVTaxReport.GridControl = Me.GCTaxReport
        Me.GVTaxReport.GroupCount = 1
        Me.GVTaxReport.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pph", Me.GridColumnTarif, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dpp", Me.GridColumnDPP, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Max, "tax_report", Me.GridColumnDesc, "Total {0} :")})
        Me.GVTaxReport.LevelIndent = 0
        Me.GVTaxReport.Name = "GVTaxReport"
        Me.GVTaxReport.OptionsView.ColumnAutoWidth = False
        Me.GVTaxReport.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVTaxReport.OptionsView.ShowFooter = True
        Me.GVTaxReport.OptionsView.ShowGroupPanel = False
        Me.GVTaxReport.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnTaxCat, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn52
        '
        Me.GridColumn52.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn52.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn52.Caption = "*"
        Me.GridColumn52.ColumnEdit = Me.RICETaxReport
        Me.GridColumn52.FieldName = "is_check"
        Me.GridColumn52.Name = "GridColumn52"
        Me.GridColumn52.Visible = True
        Me.GridColumn52.VisibleIndex = 0
        Me.GridColumn52.Width = 55
        '
        'RICETaxReport
        '
        Me.RICETaxReport.AutoHeight = False
        Me.RICETaxReport.Name = "RICETaxReport"
        Me.RICETaxReport.ValueChecked = "yes"
        Me.RICETaxReport.ValueUnchecked = "no"
        '
        'GridColumnTaxCat
        '
        Me.GridColumnTaxCat.Caption = "Tax Category"
        Me.GridColumnTaxCat.FieldName = "tax_report"
        Me.GridColumnTaxCat.MinWidth = 55
        Me.GridColumnTaxCat.Name = "GridColumnTaxCat"
        Me.GridColumnTaxCat.OptionsColumn.AllowEdit = False
        Me.GridColumnTaxCat.OptionsColumn.ReadOnly = True
        Me.GridColumnTaxCat.Visible = True
        Me.GridColumnTaxCat.VisibleIndex = 0
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "ID"
        Me.GridColumn4.FieldName = "id_acc_trans_det"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Journal No."
        Me.GridColumn5.FieldName = "jurnal_no"
        Me.GridColumn5.MinWidth = 55
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        Me.GridColumn5.Width = 81
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Date Reff"
        Me.GridColumn6.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn6.FieldName = "date_reference"
        Me.GridColumn6.MinWidth = 70
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        Me.GridColumn6.Width = 80
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Reff"
        Me.GridColumn7.FieldName = "number"
        Me.GridColumn7.MinWidth = 60
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 3
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "Inv Number"
        Me.GridColumn24.FieldName = "inv_number"
        Me.GridColumn24.MinWidth = 100
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsColumn.AllowEdit = False
        Me.GridColumn24.OptionsColumn.ReadOnly = True
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 4
        Me.GridColumn24.Width = 100
        '
        'GridColumnDesc
        '
        Me.GridColumnDesc.Caption = "Description"
        Me.GridColumnDesc.FieldName = "description"
        Me.GridColumnDesc.Name = "GridColumnDesc"
        Me.GridColumnDesc.OptionsColumn.AllowEdit = False
        Me.GridColumnDesc.OptionsColumn.ReadOnly = True
        Me.GridColumnDesc.Visible = True
        Me.GridColumnDesc.VisibleIndex = 5
        '
        'GridColumnVendorCode
        '
        Me.GridColumnVendorCode.Caption = "Vendor Code"
        Me.GridColumnVendorCode.FieldName = "comp_number"
        Me.GridColumnVendorCode.Name = "GridColumnVendorCode"
        Me.GridColumnVendorCode.OptionsColumn.AllowEdit = False
        Me.GridColumnVendorCode.OptionsColumn.ReadOnly = True
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Vendor"
        Me.GridColumn23.FieldName = "comp_name"
        Me.GridColumn23.MinWidth = 70
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsColumn.AllowEdit = False
        Me.GridColumn23.OptionsColumn.ReadOnly = True
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 6
        Me.GridColumn23.Width = 160
        '
        'GridColumnPPNPPH
        '
        Me.GridColumnPPNPPH.Caption = "(%)"
        Me.GridColumnPPNPPH.DisplayFormat.FormatString = "{0:N1} %"
        Me.GridColumnPPNPPH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPPNPPH.FieldName = "pph_percent"
        Me.GridColumnPPNPPH.MinWidth = 35
        Me.GridColumnPPNPPH.Name = "GridColumnPPNPPH"
        Me.GridColumnPPNPPH.OptionsColumn.AllowEdit = False
        Me.GridColumnPPNPPH.OptionsColumn.ReadOnly = True
        Me.GridColumnPPNPPH.Visible = True
        Me.GridColumnPPNPPH.VisibleIndex = 7
        '
        'GridColumnTarif
        '
        Me.GridColumnTarif.Caption = "Tarif"
        Me.GridColumnTarif.DisplayFormat.FormatString = "N2"
        Me.GridColumnTarif.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTarif.FieldName = "pph"
        Me.GridColumnTarif.MinWidth = 70
        Me.GridColumnTarif.Name = "GridColumnTarif"
        Me.GridColumnTarif.OptionsColumn.AllowEdit = False
        Me.GridColumnTarif.OptionsColumn.ReadOnly = True
        Me.GridColumnTarif.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pph", "{0:N2}")})
        Me.GridColumnTarif.Visible = True
        Me.GridColumnTarif.VisibleIndex = 8
        Me.GridColumnTarif.Width = 80
        '
        'GridColumnDPP
        '
        Me.GridColumnDPP.Caption = "DPP"
        Me.GridColumnDPP.DisplayFormat.FormatString = "N2"
        Me.GridColumnDPP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDPP.FieldName = "dpp"
        Me.GridColumnDPP.MinWidth = 70
        Me.GridColumnDPP.Name = "GridColumnDPP"
        Me.GridColumnDPP.OptionsColumn.AllowEdit = False
        Me.GridColumnDPP.OptionsColumn.ReadOnly = True
        Me.GridColumnDPP.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dpp", "{0:N2}")})
        Me.GridColumnDPP.Visible = True
        Me.GridColumnDPP.VisibleIndex = 9
        Me.GridColumnDPP.Width = 80
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "NPWP"
        Me.GridColumn13.FieldName = "npwp"
        Me.GridColumn13.MinWidth = 80
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.OptionsColumn.ReadOnly = True
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 10
        Me.GridColumn13.Width = 80
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Kitas"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.OptionsColumn.ReadOnly = True
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Nama di Identitas"
        Me.GridColumn15.FieldName = "npwp_name"
        Me.GridColumn15.MinWidth = 110
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.OptionsColumn.ReadOnly = True
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 11
        Me.GridColumn15.Width = 140
        '
        'GridColumnAlamatNPWP
        '
        Me.GridColumnAlamatNPWP.Caption = "Alamat"
        Me.GridColumnAlamatNPWP.FieldName = "npwp_address"
        Me.GridColumnAlamatNPWP.Name = "GridColumnAlamatNPWP"
        Me.GridColumnAlamatNPWP.OptionsColumn.AllowEdit = False
        Me.GridColumnAlamatNPWP.OptionsColumn.ReadOnly = True
        Me.GridColumnAlamatNPWP.Visible = True
        Me.GridColumnAlamatNPWP.VisibleIndex = 12
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "No Bukti Potong"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowEdit = False
        Me.GridColumn17.OptionsColumn.ReadOnly = True
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BReported)
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 298)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1009, 40)
        Me.PanelControl1.TabIndex = 5
        '
        'BReported
        '
        Me.BReported.Appearance.BackColor = System.Drawing.Color.Blue
        Me.BReported.Appearance.ForeColor = System.Drawing.Color.White
        Me.BReported.Appearance.Options.UseBackColor = True
        Me.BReported.Appearance.Options.UseForeColor = True
        Me.BReported.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BReported.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BReported.Location = New System.Drawing.Point(118, 2)
        Me.BReported.Name = "BReported"
        Me.BReported.Size = New System.Drawing.Size(889, 36)
        Me.BReported.TabIndex = 4
        Me.BReported.Text = "Rekap"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.CheckEditSelAll)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl2.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(116, 36)
        Me.PanelControl2.TabIndex = 0
        '
        'CheckEditSelAll
        '
        Me.CheckEditSelAll.Location = New System.Drawing.Point(8, 8)
        Me.CheckEditSelAll.Name = "CheckEditSelAll"
        Me.CheckEditSelAll.Properties.Caption = "Select All Item"
        Me.CheckEditSelAll.Size = New System.Drawing.Size(109, 19)
        Me.CheckEditSelAll.TabIndex = 103
        '
        'XTPPendingTransaction
        '
        Me.XTPPendingTransaction.Controls.Add(Me.GCTaxPending)
        Me.XTPPendingTransaction.Name = "XTPPendingTransaction"
        Me.XTPPendingTransaction.Size = New System.Drawing.Size(1009, 338)
        Me.XTPPendingTransaction.Text = "Pending Tax Transaction"
        '
        'GCTaxPending
        '
        Me.GCTaxPending.ContextMenuStrip = Me.ViewMenu
        Me.GCTaxPending.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCTaxPending.Location = New System.Drawing.Point(0, 0)
        Me.GCTaxPending.MainView = Me.GVTaxPending
        Me.GCTaxPending.Name = "GCTaxPending"
        Me.GCTaxPending.Size = New System.Drawing.Size(1009, 338)
        Me.GCTaxPending.TabIndex = 3
        Me.GCTaxPending.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVTaxPending})
        '
        'GVTaxPending
        '
        Me.GVTaxPending.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn8, Me.GridColumn9, Me.GridColumn11, Me.GridColumn12, Me.GridColumn16, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30, Me.GridColumn31, Me.GridColumn32, Me.GridColumn33, Me.GridColumn34, Me.GridColumn35})
        Me.GVTaxPending.GridControl = Me.GCTaxPending
        Me.GVTaxPending.GroupCount = 1
        Me.GVTaxPending.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pph", Me.GridColumn29, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dpp", Me.GridColumn30, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Max, "tax_report", Me.GridColumn25, "Total {0} :")})
        Me.GVTaxPending.LevelIndent = 0
        Me.GVTaxPending.Name = "GVTaxPending"
        Me.GVTaxPending.OptionsView.ColumnAutoWidth = False
        Me.GVTaxPending.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVTaxPending.OptionsView.ShowFooter = True
        Me.GVTaxPending.OptionsView.ShowGroupPanel = False
        Me.GVTaxPending.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn8, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Tax Category"
        Me.GridColumn8.FieldName = "tax_report"
        Me.GridColumn8.MinWidth = 55
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.ReadOnly = True
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 0
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "ID"
        Me.GridColumn9.FieldName = "id_acc_trans_det"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.OptionsColumn.ReadOnly = True
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Date Reff"
        Me.GridColumn11.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn11.FieldName = "date_reference"
        Me.GridColumn11.MinWidth = 70
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.ReadOnly = True
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        Me.GridColumn11.Width = 80
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Reff"
        Me.GridColumn12.FieldName = "number"
        Me.GridColumn12.MinWidth = 60
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.OptionsColumn.ReadOnly = True
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 1
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Inv Number"
        Me.GridColumn16.FieldName = "inv_number"
        Me.GridColumn16.MinWidth = 100
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.AllowEdit = False
        Me.GridColumn16.OptionsColumn.ReadOnly = True
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 2
        Me.GridColumn16.Width = 100
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Description"
        Me.GridColumn25.FieldName = "description"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.OptionsColumn.AllowEdit = False
        Me.GridColumn25.OptionsColumn.ReadOnly = True
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 3
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "Vendor Code"
        Me.GridColumn26.FieldName = "comp_number"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.OptionsColumn.AllowEdit = False
        Me.GridColumn26.OptionsColumn.ReadOnly = True
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "Vendor"
        Me.GridColumn27.FieldName = "comp_name"
        Me.GridColumn27.MinWidth = 70
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.OptionsColumn.AllowEdit = False
        Me.GridColumn27.OptionsColumn.ReadOnly = True
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 4
        Me.GridColumn27.Width = 160
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "(%)"
        Me.GridColumn28.DisplayFormat.FormatString = "{0:N1} %"
        Me.GridColumn28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn28.FieldName = "pph_percent"
        Me.GridColumn28.MinWidth = 35
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.OptionsColumn.AllowEdit = False
        Me.GridColumn28.OptionsColumn.ReadOnly = True
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 5
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Tarif"
        Me.GridColumn29.DisplayFormat.FormatString = "N2"
        Me.GridColumn29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn29.FieldName = "pph"
        Me.GridColumn29.MinWidth = 70
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.OptionsColumn.AllowEdit = False
        Me.GridColumn29.OptionsColumn.ReadOnly = True
        Me.GridColumn29.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pph", "{0:N2}")})
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 6
        Me.GridColumn29.Width = 80
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "DPP"
        Me.GridColumn30.DisplayFormat.FormatString = "N2"
        Me.GridColumn30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn30.FieldName = "dpp"
        Me.GridColumn30.MinWidth = 70
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.OptionsColumn.AllowEdit = False
        Me.GridColumn30.OptionsColumn.ReadOnly = True
        Me.GridColumn30.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dpp", "{0:N2}")})
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 7
        Me.GridColumn30.Width = 80
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "NPWP"
        Me.GridColumn31.FieldName = "npwp"
        Me.GridColumn31.MinWidth = 80
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.OptionsColumn.AllowEdit = False
        Me.GridColumn31.OptionsColumn.ReadOnly = True
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 8
        Me.GridColumn31.Width = 80
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "Kitas"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.OptionsColumn.AllowEdit = False
        Me.GridColumn32.OptionsColumn.ReadOnly = True
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Nama di Identitas"
        Me.GridColumn33.FieldName = "npwp_name"
        Me.GridColumn33.MinWidth = 110
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.OptionsColumn.AllowEdit = False
        Me.GridColumn33.OptionsColumn.ReadOnly = True
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 9
        Me.GridColumn33.Width = 140
        '
        'GridColumn34
        '
        Me.GridColumn34.Caption = "Alamat"
        Me.GridColumn34.FieldName = "npwp_address"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.OptionsColumn.AllowEdit = False
        Me.GridColumn34.OptionsColumn.ReadOnly = True
        Me.GridColumn34.Visible = True
        Me.GridColumn34.VisibleIndex = 10
        '
        'GridColumn35
        '
        Me.GridColumn35.Caption = "No Bukti Potong"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.OptionsColumn.AllowEdit = False
        Me.GridColumn35.OptionsColumn.ReadOnly = True
        '
        'XTPLapor
        '
        Me.XTPLapor.Controls.Add(Me.GCActiveTax)
        Me.XTPLapor.Controls.Add(Me.PanelControl3)
        Me.XTPLapor.Name = "XTPLapor"
        Me.XTPLapor.Size = New System.Drawing.Size(1009, 338)
        Me.XTPLapor.Text = "Rekap Tax"
        '
        'GCActiveTax
        '
        Me.GCActiveTax.ContextMenuStrip = Me.ViewMenu
        Me.GCActiveTax.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCActiveTax.Location = New System.Drawing.Point(0, 0)
        Me.GCActiveTax.MainView = Me.GVActiveTax
        Me.GCActiveTax.Name = "GCActiveTax"
        Me.GCActiveTax.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEActiveTax})
        Me.GCActiveTax.Size = New System.Drawing.Size(1009, 298)
        Me.GCActiveTax.TabIndex = 3
        Me.GCActiveTax.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVActiveTax})
        '
        'GVActiveTax
        '
        Me.GVActiveTax.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumnActiveTaxCat, Me.GridColumn36, Me.GridColumn37, Me.GridColumn38, Me.GridColumn39, Me.GridColumn40, Me.GridColumn41, Me.GridColumn42, Me.GridColumn43, Me.GridColumn44, Me.GridColumn45, Me.GridColumn46, Me.GridColumn47, Me.GridColumn48, Me.GridColumn49, Me.GridColumn50, Me.GridColumn51})
        Me.GVActiveTax.GridControl = Me.GCActiveTax
        Me.GVActiveTax.GroupCount = 1
        Me.GVActiveTax.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pph", Me.GridColumn45, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dpp", Me.GridColumn46, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Max, "tax_report", Me.GridColumn41, "Total {0} :")})
        Me.GVActiveTax.LevelIndent = 0
        Me.GVActiveTax.Name = "GVActiveTax"
        Me.GVActiveTax.OptionsView.ColumnAutoWidth = False
        Me.GVActiveTax.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVActiveTax.OptionsView.ShowFooter = True
        Me.GVActiveTax.OptionsView.ShowGroupPanel = False
        Me.GVActiveTax.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnActiveTaxCat, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn10
        '
        Me.GridColumn10.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn10.Caption = "*"
        Me.GridColumn10.ColumnEdit = Me.RICEActiveTax
        Me.GridColumn10.FieldName = "is_check"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        '
        'RICEActiveTax
        '
        Me.RICEActiveTax.AutoHeight = False
        Me.RICEActiveTax.Name = "RICEActiveTax"
        Me.RICEActiveTax.ValueChecked = "yes"
        Me.RICEActiveTax.ValueUnchecked = "no"
        '
        'GridColumnActiveTaxCat
        '
        Me.GridColumnActiveTaxCat.Caption = "Tax Category"
        Me.GridColumnActiveTaxCat.FieldName = "tax_report"
        Me.GridColumnActiveTaxCat.MinWidth = 55
        Me.GridColumnActiveTaxCat.Name = "GridColumnActiveTaxCat"
        Me.GridColumnActiveTaxCat.OptionsColumn.AllowEdit = False
        Me.GridColumnActiveTaxCat.OptionsColumn.ReadOnly = True
        Me.GridColumnActiveTaxCat.Visible = True
        Me.GridColumnActiveTaxCat.VisibleIndex = 0
        '
        'GridColumn36
        '
        Me.GridColumn36.Caption = "ID"
        Me.GridColumn36.FieldName = "id_acc_trans_det"
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.OptionsColumn.AllowEdit = False
        Me.GridColumn36.OptionsColumn.ReadOnly = True
        '
        'GridColumn37
        '
        Me.GridColumn37.Caption = "Journal No."
        Me.GridColumn37.FieldName = "jurnal_no"
        Me.GridColumn37.MinWidth = 55
        Me.GridColumn37.Name = "GridColumn37"
        Me.GridColumn37.OptionsColumn.AllowEdit = False
        Me.GridColumn37.OptionsColumn.ReadOnly = True
        Me.GridColumn37.Visible = True
        Me.GridColumn37.VisibleIndex = 1
        Me.GridColumn37.Width = 81
        '
        'GridColumn38
        '
        Me.GridColumn38.Caption = "Date Reff"
        Me.GridColumn38.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn38.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn38.FieldName = "date_reference"
        Me.GridColumn38.MinWidth = 70
        Me.GridColumn38.Name = "GridColumn38"
        Me.GridColumn38.OptionsColumn.AllowEdit = False
        Me.GridColumn38.OptionsColumn.ReadOnly = True
        Me.GridColumn38.Visible = True
        Me.GridColumn38.VisibleIndex = 2
        Me.GridColumn38.Width = 80
        '
        'GridColumn39
        '
        Me.GridColumn39.Caption = "Reff"
        Me.GridColumn39.FieldName = "number"
        Me.GridColumn39.MinWidth = 60
        Me.GridColumn39.Name = "GridColumn39"
        Me.GridColumn39.OptionsColumn.AllowEdit = False
        Me.GridColumn39.OptionsColumn.ReadOnly = True
        Me.GridColumn39.Visible = True
        Me.GridColumn39.VisibleIndex = 3
        '
        'GridColumn40
        '
        Me.GridColumn40.Caption = "Inv Number"
        Me.GridColumn40.FieldName = "inv_number"
        Me.GridColumn40.MinWidth = 100
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.OptionsColumn.AllowEdit = False
        Me.GridColumn40.OptionsColumn.ReadOnly = True
        Me.GridColumn40.Visible = True
        Me.GridColumn40.VisibleIndex = 4
        Me.GridColumn40.Width = 100
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "Description"
        Me.GridColumn41.FieldName = "description"
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.OptionsColumn.AllowEdit = False
        Me.GridColumn41.OptionsColumn.ReadOnly = True
        Me.GridColumn41.Visible = True
        Me.GridColumn41.VisibleIndex = 5
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "Vendor Code"
        Me.GridColumn42.FieldName = "comp_number"
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.OptionsColumn.AllowEdit = False
        Me.GridColumn42.OptionsColumn.ReadOnly = True
        '
        'GridColumn43
        '
        Me.GridColumn43.Caption = "Vendor"
        Me.GridColumn43.FieldName = "comp_name"
        Me.GridColumn43.MinWidth = 70
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.OptionsColumn.AllowEdit = False
        Me.GridColumn43.OptionsColumn.ReadOnly = True
        Me.GridColumn43.Visible = True
        Me.GridColumn43.VisibleIndex = 6
        Me.GridColumn43.Width = 160
        '
        'GridColumn44
        '
        Me.GridColumn44.Caption = "(%)"
        Me.GridColumn44.DisplayFormat.FormatString = "{0:N1} %"
        Me.GridColumn44.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn44.FieldName = "pph_percent"
        Me.GridColumn44.MinWidth = 35
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.OptionsColumn.AllowEdit = False
        Me.GridColumn44.OptionsColumn.ReadOnly = True
        Me.GridColumn44.Visible = True
        Me.GridColumn44.VisibleIndex = 7
        '
        'GridColumn45
        '
        Me.GridColumn45.Caption = "Tarif"
        Me.GridColumn45.DisplayFormat.FormatString = "N0"
        Me.GridColumn45.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn45.FieldName = "pph"
        Me.GridColumn45.MinWidth = 70
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.OptionsColumn.AllowEdit = False
        Me.GridColumn45.OptionsColumn.ReadOnly = True
        Me.GridColumn45.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pph", "{0:N2}")})
        Me.GridColumn45.Visible = True
        Me.GridColumn45.VisibleIndex = 8
        Me.GridColumn45.Width = 80
        '
        'GridColumn46
        '
        Me.GridColumn46.Caption = "DPP"
        Me.GridColumn46.DisplayFormat.FormatString = "N0"
        Me.GridColumn46.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn46.FieldName = "dpp"
        Me.GridColumn46.MinWidth = 70
        Me.GridColumn46.Name = "GridColumn46"
        Me.GridColumn46.OptionsColumn.AllowEdit = False
        Me.GridColumn46.OptionsColumn.ReadOnly = True
        Me.GridColumn46.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dpp", "{0:N2}")})
        Me.GridColumn46.Visible = True
        Me.GridColumn46.VisibleIndex = 9
        Me.GridColumn46.Width = 80
        '
        'GridColumn47
        '
        Me.GridColumn47.Caption = "NPWP"
        Me.GridColumn47.FieldName = "npwp"
        Me.GridColumn47.MinWidth = 80
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.OptionsColumn.AllowEdit = False
        Me.GridColumn47.OptionsColumn.ReadOnly = True
        Me.GridColumn47.Visible = True
        Me.GridColumn47.VisibleIndex = 10
        Me.GridColumn47.Width = 80
        '
        'GridColumn48
        '
        Me.GridColumn48.Caption = "Kitas"
        Me.GridColumn48.Name = "GridColumn48"
        Me.GridColumn48.OptionsColumn.AllowEdit = False
        Me.GridColumn48.OptionsColumn.ReadOnly = True
        '
        'GridColumn49
        '
        Me.GridColumn49.Caption = "Nama di Identitas"
        Me.GridColumn49.FieldName = "npwp_name"
        Me.GridColumn49.MinWidth = 110
        Me.GridColumn49.Name = "GridColumn49"
        Me.GridColumn49.OptionsColumn.AllowEdit = False
        Me.GridColumn49.OptionsColumn.ReadOnly = True
        Me.GridColumn49.Visible = True
        Me.GridColumn49.VisibleIndex = 11
        Me.GridColumn49.Width = 140
        '
        'GridColumn50
        '
        Me.GridColumn50.Caption = "Alamat"
        Me.GridColumn50.FieldName = "npwp_address"
        Me.GridColumn50.Name = "GridColumn50"
        Me.GridColumn50.OptionsColumn.AllowEdit = False
        Me.GridColumn50.OptionsColumn.ReadOnly = True
        Me.GridColumn50.Visible = True
        Me.GridColumn50.VisibleIndex = 12
        '
        'GridColumn51
        '
        Me.GridColumn51.Caption = "No Bukti Potong"
        Me.GridColumn51.Name = "GridColumn51"
        Me.GridColumn51.OptionsColumn.AllowEdit = False
        Me.GridColumn51.OptionsColumn.ReadOnly = True
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BMoveActiveTax)
        Me.PanelControl3.Controls.Add(Me.PanelControl4)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 298)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(1009, 40)
        Me.PanelControl3.TabIndex = 6
        '
        'BMoveActiveTax
        '
        Me.BMoveActiveTax.Appearance.BackColor = System.Drawing.Color.Blue
        Me.BMoveActiveTax.Appearance.ForeColor = System.Drawing.Color.White
        Me.BMoveActiveTax.Appearance.Options.UseBackColor = True
        Me.BMoveActiveTax.Appearance.Options.UseForeColor = True
        Me.BMoveActiveTax.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BMoveActiveTax.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BMoveActiveTax.Location = New System.Drawing.Point(118, 2)
        Me.BMoveActiveTax.Name = "BMoveActiveTax"
        Me.BMoveActiveTax.Size = New System.Drawing.Size(889, 36)
        Me.BMoveActiveTax.TabIndex = 4
        Me.BMoveActiveTax.Text = "Move"
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.CESelAllActiveTax)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl4.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(116, 36)
        Me.PanelControl4.TabIndex = 0
        '
        'CESelAllActiveTax
        '
        Me.CESelAllActiveTax.Location = New System.Drawing.Point(8, 8)
        Me.CESelAllActiveTax.Name = "CESelAllActiveTax"
        Me.CESelAllActiveTax.Properties.Caption = "Select All Item"
        Me.CESelAllActiveTax.Size = New System.Drawing.Size(109, 19)
        Me.CESelAllActiveTax.TabIndex = 103
        '
        'PCPajak
        '
        Me.PCPajak.Controls.Add(Me.XtraScrollableControl1)
        Me.PCPajak.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCPajak.Location = New System.Drawing.Point(0, 0)
        Me.PCPajak.Name = "PCPajak"
        Me.PCPajak.Size = New System.Drawing.Size(1015, 78)
        Me.PCPajak.TabIndex = 1
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.SBSummaryPpn)
        Me.XtraScrollableControl1.Controls.Add(Me.SBSetup)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl4)
        Me.XtraScrollableControl1.Controls.Add(Me.SBSummary)
        Me.XtraScrollableControl1.Controls.Add(Me.DETaxFrom)
        Me.XtraScrollableControl1.Controls.Add(Me.SLETaxCat)
        Me.XtraScrollableControl1.Controls.Add(Me.BViewPajak)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl6)
        Me.XtraScrollableControl1.Controls.Add(Me.BPrintPajak)
        Me.XtraScrollableControl1.Controls.Add(Me.SLETaxTagCOA)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl3)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl5)
        Me.XtraScrollableControl1.Controls.Add(Me.DETaxUntil)
        Me.XtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraScrollableControl1.Location = New System.Drawing.Point(2, 2)
        Me.XtraScrollableControl1.Name = "XtraScrollableControl1"
        Me.XtraScrollableControl1.Size = New System.Drawing.Size(1011, 74)
        Me.XtraScrollableControl1.TabIndex = 14
        '
        'SBSetup
        '
        Me.SBSetup.Location = New System.Drawing.Point(894, 12)
        Me.SBSetup.Name = "SBSetup"
        Me.SBSetup.Size = New System.Drawing.Size(79, 23)
        Me.SBSetup.TabIndex = 14
        Me.SBSetup.Text = "setup tax"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(11, 17)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl4.TabIndex = 2
        Me.LabelControl4.Text = "Date"
        '
        'SBSummary
        '
        Me.SBSummary.Location = New System.Drawing.Point(979, 12)
        Me.SBSummary.Name = "SBSummary"
        Me.SBSummary.Size = New System.Drawing.Size(79, 23)
        Me.SBSummary.TabIndex = 13
        Me.SBSummary.Text = "summary pph"
        '
        'DETaxFrom
        '
        Me.DETaxFrom.EditValue = Nothing
        Me.DETaxFrom.Location = New System.Drawing.Point(40, 14)
        Me.DETaxFrom.Name = "DETaxFrom"
        Me.DETaxFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETaxFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETaxFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DETaxFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DETaxFrom.Size = New System.Drawing.Size(173, 20)
        Me.DETaxFrom.TabIndex = 1
        '
        'SLETaxCat
        '
        Me.SLETaxCat.Location = New System.Drawing.Point(653, 14)
        Me.SLETaxCat.Name = "SLETaxCat"
        Me.SLETaxCat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLETaxCat.Properties.View = Me.GridView2
        Me.SLETaxCat.Size = New System.Drawing.Size(123, 20)
        Me.SLETaxCat.TabIndex = 12
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn21, Me.GridColumn22})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "id_tax_report"
        Me.GridColumn21.FieldName = "id_tax_report"
        Me.GridColumn21.Name = "GridColumn21"
        '
        'GridColumn22
        '
        Me.GridColumn22.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn22.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn22.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn22.Caption = "Tax Type"
        Me.GridColumn22.FieldName = "tax_report"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 0
        Me.GridColumn22.Width = 281
        '
        'BViewPajak
        '
        Me.BViewPajak.Location = New System.Drawing.Point(782, 12)
        Me.BViewPajak.Name = "BViewPajak"
        Me.BViewPajak.Size = New System.Drawing.Size(50, 23)
        Me.BViewPajak.TabIndex = 3
        Me.BViewPajak.Text = "view"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(623, 17)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl6.TabIndex = 11
        Me.LabelControl6.Text = "Type"
        '
        'BPrintPajak
        '
        Me.BPrintPajak.Location = New System.Drawing.Point(838, 12)
        Me.BPrintPajak.Name = "BPrintPajak"
        Me.BPrintPajak.Size = New System.Drawing.Size(50, 23)
        Me.BPrintPajak.TabIndex = 6
        Me.BPrintPajak.Text = "print"
        '
        'SLETaxTagCOA
        '
        Me.SLETaxTagCOA.Location = New System.Drawing.Point(449, 14)
        Me.SLETaxTagCOA.Name = "SLETaxTagCOA"
        Me.SLETaxTagCOA.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLETaxTagCOA.Properties.View = Me.GridView1
        Me.SLETaxTagCOA.Size = New System.Drawing.Size(168, 20)
        Me.SLETaxTagCOA.TabIndex = 10
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn18, Me.GridColumn19, Me.GridColumn20})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "id_coa_tag"
        Me.GridColumn18.FieldName = "id_comp"
        Me.GridColumn18.Name = "GridColumn18"
        '
        'GridColumn19
        '
        Me.GridColumn19.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn19.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn19.Caption = "Tag Code"
        Me.GridColumn19.FieldName = "tag_code"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 0
        Me.GridColumn19.Width = 281
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Description"
        Me.GridColumn20.FieldName = "tag_description"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 1
        Me.GridColumn20.Width = 1351
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(219, 17)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(20, 13)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "until"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(424, 17)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl5.TabIndex = 9
        Me.LabelControl5.Text = "Tag"
        '
        'DETaxUntil
        '
        Me.DETaxUntil.EditValue = Nothing
        Me.DETaxUntil.Location = New System.Drawing.Point(245, 14)
        Me.DETaxUntil.Name = "DETaxUntil"
        Me.DETaxUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETaxUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETaxUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DETaxUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DETaxUntil.Size = New System.Drawing.Size(173, 20)
        Me.DETaxUntil.TabIndex = 8
        '
        'SBSummaryPpn
        '
        Me.SBSummaryPpn.Location = New System.Drawing.Point(1064, 12)
        Me.SBSummaryPpn.Name = "SBSummaryPpn"
        Me.SBSummaryPpn.Size = New System.Drawing.Size(79, 23)
        Me.SBSummaryPpn.TabIndex = 15
        Me.SBSummaryPpn.Text = "summary ppn"
        '
        'FormReportBalanceSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1021, 520)
        Me.Controls.Add(Me.XTCBalanceSheet)
        Me.Controls.Add(Me.PCFilterUpper)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormReportBalanceSheet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Accounting Report"
        CType(Me.PCFilterUpper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCFilterUpper.ResumeLayout(False)
        Me.PCFilterUpper.PerformLayout()
        CType(Me.SLEUnit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TLBalanceSheet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCBalanceSheet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCBalanceSheet.ResumeLayout(False)
        Me.XTPGeneralLedger.ResumeLayout(False)
        CType(Me.TLLedger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPBalanceSheet.ResumeLayout(False)
        CType(Me.XTCBS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCBS.ResumeLayout(False)
        Me.XTPBSLedger.ResumeLayout(False)
        Me.XTPBSReport.ResumeLayout(False)
        CType(Me.SplitterBS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitterBS.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCAktiva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAktiva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCPasiva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPasiva, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPProfitAndLoss.ResumeLayout(False)
        CType(Me.XTCProfitAndLoss, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCProfitAndLoss.ResumeLayout(False)
        Me.XTPPATreeView.ResumeLayout(False)
        CType(Me.TLProfitAndLoss, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPPLReportView.ResumeLayout(False)
        CType(Me.GCProfitAndLoss, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProfitAndLoss, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPPajak.ResumeLayout(False)
        CType(Me.XTPTaxDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPTaxDetail.ResumeLayout(False)
        Me.XTPPendingLapor.ResumeLayout(False)
        CType(Me.GCTaxReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewMenu.ResumeLayout(False)
        CType(Me.GVTaxReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICETaxReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPPendingTransaction.ResumeLayout(False)
        CType(Me.GCTaxPending, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVTaxPending, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPLapor.ResumeLayout(False)
        CType(Me.GCActiveTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVActiveTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEActiveTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.CESelAllActiveTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCPajak, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCPajak.ResumeLayout(False)
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.DETaxFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETaxFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLETaxCat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLETaxTagCOA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETaxUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETaxUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PCFilterUpper As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TLBalanceSheet As DevExpress.XtraTreeList.TreeList
    Friend WithEvents XTCBalanceSheet As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPGeneralLedger As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPBalanceSheet As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents treeListBand1 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCLAccount As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLDescription As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents treeListBand2 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCLPrevMonth As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLThisMonth As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCIDAcc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCIDAccParent As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCAllChild As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TLLedger As DevExpress.XtraTreeList.TreeList
    Friend WithEvents treeListBand5 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCLAccName As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLAccDescription As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents treeListBand6 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCLedDebit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLedCredit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLIDAcc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLIdAccParent As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLedIDAllChild As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents treeListBand3 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents treeListBand4 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEUnit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XTPProfitAndLoss As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTCBS As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPBSLedger As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPBSReport As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTCProfitAndLoss As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPATreeView As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPPLReportView As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TLProfitAndLoss As DevExpress.XtraTreeList.TreeList
    Friend WithEvents treeListBand7 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCPLAccount As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCPLDescription As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents treeListBand8 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCPLPrevMonth As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCPLThisMonth As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCPLIdAcc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCPLIdAccParent As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCPLIdAllChild As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents SplitterBS As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GCAktiva As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAktiva As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPrevMonth As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnThisMonth As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn13 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn12 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn14 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCPasiva As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPasiva As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn15 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn16 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn17 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn18 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents TCLDebit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLCredit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCPLDebit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCPLCredit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents GCProfitAndLoss As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProfitAndLoss As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn19 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn20 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn21 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn28 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn22 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn27 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnYTD As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn29 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn23 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn24 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn25 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPPajak As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PCPajak As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DETaxUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BPrintPajak As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BViewPajak As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DETaxFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GCTaxReport As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVTaxReport As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XTPTaxDetail As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPendingLapor As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVendorCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPPNPPH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTarif As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDPP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAlamatNPWP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLETaxTagCOA As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLETaxCat As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ViewMenu As ContextMenuStrip
    Friend WithEvents ViewDetailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewJournalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumnTaxCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPPendingTransaction As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCTaxPending As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVTaxPending As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPLapor As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridColumn52 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICETaxReport As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GCActiveTax As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVActiveTax As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnActiveTaxCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn38 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn46 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn48 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn49 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn50 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn51 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BReported As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEditSelAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BMoveActiveTax As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CESelAllActiveTax As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICEActiveTax As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents SBSummary As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XtraScrollableControl1 As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents SBSetup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBSummaryPpn As DevExpress.XtraEditors.SimpleButton
End Class
