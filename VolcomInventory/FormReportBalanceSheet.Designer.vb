<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEUnit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.BandedGridColumn26 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn29 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn23 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn24 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn25 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
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
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BPrint)
        Me.PanelControl1.Controls.Add(Me.SLEUnit)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.DEUntil)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(900, 48)
        Me.PanelControl1.TabIndex = 0
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
        Me.TLBalanceSheet.Size = New System.Drawing.Size(888, 416)
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
        Me.XTCBalanceSheet.Size = New System.Drawing.Size(900, 472)
        Me.XTCBalanceSheet.TabIndex = 2
        Me.XTCBalanceSheet.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPGeneralLedger, Me.XTPBalanceSheet, Me.XTPProfitAndLoss})
        '
        'XTPGeneralLedger
        '
        Me.XTPGeneralLedger.Controls.Add(Me.TLLedger)
        Me.XTPGeneralLedger.Name = "XTPGeneralLedger"
        Me.XTPGeneralLedger.Size = New System.Drawing.Size(894, 444)
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
        Me.TLLedger.Size = New System.Drawing.Size(894, 444)
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
        Me.XTPBalanceSheet.Size = New System.Drawing.Size(894, 444)
        Me.XTPBalanceSheet.Text = "Balance Sheet"
        '
        'XTCBS
        '
        Me.XTCBS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCBS.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCBS.Location = New System.Drawing.Point(0, 0)
        Me.XTCBS.Name = "XTCBS"
        Me.XTCBS.SelectedTabPage = Me.XTPBSLedger
        Me.XTCBS.Size = New System.Drawing.Size(894, 444)
        Me.XTCBS.TabIndex = 2
        Me.XTCBS.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPBSLedger, Me.XTPBSReport})
        '
        'XTPBSLedger
        '
        Me.XTPBSLedger.Controls.Add(Me.TLBalanceSheet)
        Me.XTPBSLedger.Name = "XTPBSLedger"
        Me.XTPBSLedger.Size = New System.Drawing.Size(888, 416)
        Me.XTPBSLedger.Text = "Tree View"
        '
        'XTPBSReport
        '
        Me.XTPBSReport.Controls.Add(Me.SplitterBS)
        Me.XTPBSReport.Name = "XTPBSReport"
        Me.XTPBSReport.Size = New System.Drawing.Size(888, 416)
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
        Me.SplitterBS.Size = New System.Drawing.Size(888, 416)
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
        Me.GroupControl2.Size = New System.Drawing.Size(461, 416)
        Me.GroupControl2.TabIndex = 2
        Me.GroupControl2.Text = "Liability And Equity"
        '
        'GCPasiva
        '
        Me.GCPasiva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPasiva.Location = New System.Drawing.Point(2, 20)
        Me.GCPasiva.MainView = Me.GVPasiva
        Me.GCPasiva.Name = "GCPasiva"
        Me.GCPasiva.Size = New System.Drawing.Size(457, 394)
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
        Me.XTPProfitAndLoss.Size = New System.Drawing.Size(894, 444)
        Me.XTPProfitAndLoss.Text = "Profit And Loss"
        '
        'XTCProfitAndLoss
        '
        Me.XTCProfitAndLoss.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCProfitAndLoss.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCProfitAndLoss.Location = New System.Drawing.Point(0, 0)
        Me.XTCProfitAndLoss.Name = "XTCProfitAndLoss"
        Me.XTCProfitAndLoss.SelectedTabPage = Me.XTPPATreeView
        Me.XTCProfitAndLoss.Size = New System.Drawing.Size(894, 444)
        Me.XTCProfitAndLoss.TabIndex = 0
        Me.XTCProfitAndLoss.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPATreeView, Me.XTPPLReportView})
        '
        'XTPPATreeView
        '
        Me.XTPPATreeView.Controls.Add(Me.TLProfitAndLoss)
        Me.XTPPATreeView.Name = "XTPPATreeView"
        Me.XTPPATreeView.Size = New System.Drawing.Size(888, 416)
        Me.XTPPATreeView.Text = "Tree View"
        '
        'TLProfitAndLoss
        '
        Me.TLProfitAndLoss.Bands.AddRange(New DevExpress.XtraTreeList.Columns.TreeListBand() {Me.treeListBand7, Me.treeListBand8})
        Me.TLProfitAndLoss.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TCPLIdAcc, Me.TCPLIdAccParent, Me.TCPLAccount, Me.TCPLDescription, Me.TCPLDebit, Me.TCPLCredit, Me.TCPLIdAllChild, Me.TCPLPrevMonth, Me.TCPLThisMonth})
        Me.TLProfitAndLoss.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLProfitAndLoss.Location = New System.Drawing.Point(0, 0)
        Me.TLProfitAndLoss.Name = "TLProfitAndLoss"
        Me.TLProfitAndLoss.Size = New System.Drawing.Size(888, 416)
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
        Me.XTPPLReportView.Size = New System.Drawing.Size(888, 416)
        Me.XTPPLReportView.Text = "Report View"
        '
        'GCProfitAndLoss
        '
        Me.GCProfitAndLoss.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProfitAndLoss.Location = New System.Drawing.Point(0, 0)
        Me.GCProfitAndLoss.MainView = Me.GVProfitAndLoss
        Me.GCProfitAndLoss.Name = "GCProfitAndLoss"
        Me.GCProfitAndLoss.Size = New System.Drawing.Size(888, 416)
        Me.GCProfitAndLoss.TabIndex = 1
        Me.GCProfitAndLoss.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProfitAndLoss})
        '
        'GVProfitAndLoss
        '
        Me.GVProfitAndLoss.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand5, Me.GridBand6})
        Me.GVProfitAndLoss.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn23, Me.BandedGridColumn4, Me.BandedGridColumn24, Me.BandedGridColumn5, Me.BandedGridColumn25, Me.BandedGridColumn19, Me.BandedGridColumn20, Me.BandedGridColumn22, Me.BandedGridColumn21, Me.BandedGridColumn26, Me.BandedGridColumn27, Me.BandedGridColumn28, Me.BandedGridColumn29})
        Me.GVProfitAndLoss.GridControl = Me.GCProfitAndLoss
        Me.GVProfitAndLoss.GroupCount = 2
        Me.GVProfitAndLoss.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", Me.BandedGridColumn22, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", Me.BandedGridColumn21, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_year_to_date", Me.BandedGridColumn23, "{0:N2}")})
        Me.GVProfitAndLoss.Name = "GVProfitAndLoss"
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
        Me.GridBand6.Columns.Add(Me.BandedGridColumn26)
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
        'BandedGridColumn26
        '
        Me.BandedGridColumn26.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn26.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn26.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn26.Caption = "Year to Date"
        Me.BandedGridColumn26.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn26.FieldName = "this_year_to_date"
        Me.BandedGridColumn26.Name = "BandedGridColumn26"
        Me.BandedGridColumn26.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_year_to_date", "{0:N2}")})
        Me.BandedGridColumn26.Visible = True
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
        'GridColumn1
        '
        Me.GridColumn1.Caption = "id_comp"
        Me.GridColumn1.FieldName = "id_comp"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Unit"
        Me.GridColumn2.FieldName = "comp_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 1351
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.Caption = "Number"
        Me.GridColumn3.FieldName = "comp_number"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 281
        '
        'FormReportBalanceSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 520)
        Me.Controls.Add(Me.XTCBalanceSheet)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormReportBalanceSheet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Accounting Report"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
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
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
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
    Friend WithEvents BandedGridColumn26 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn29 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn23 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn24 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn25 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
