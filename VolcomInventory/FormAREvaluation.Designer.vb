﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAREvaluation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAREvaluation))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.PanelNav = New DevExpress.XtraEditors.PanelControl()
        Me.BtnLog = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnViewData = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnBrowseEval = New DevExpress.XtraEditors.ButtonEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPInvoiceDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.GCInvoiceDetail = New DevExpress.XtraGrid.GridControl()
        Me.GVInvoiceDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngroup_store = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_inv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumninv_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoLinkInvoice = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.GridColumninv_rmt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumninv_amount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpaid_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnrelease_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnactive_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnbtn_bbm = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoBtnBBM = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GridColumnid_propose_delay_payment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnmemo_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoLinkMemo = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.XTPNewEval = New DevExpress.XtraTab.XtraTabPage()
        Me.XTCCreateNewEval = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPInvoiceList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCActiveList = New DevExpress.XtraGrid.GridControl()
        Me.GVActiveList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_sales_pos = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstore = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_due_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_propose_delay_payment_eval = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnmemo_number_eval = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoLinkMemoEval = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.GridColumnpropose_delay_payment_due_date_eval = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndue_days = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnaging = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnperiod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnamount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_select = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnid_store_company_active = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPGroupStoreList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCGroupStoreList = New DevExpress.XtraGrid.GridControl()
        Me.GVGroupStoreList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp_group_eval = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngroup_eval = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_ho = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnho = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnemail_ho = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDiscardMemo = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCreateMemo = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnActivateMemoPenangguhan = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCreateEvaluation = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControlCreateEval = New DevExpress.XtraEditors.PanelControl()
        Me.BtnViewOverdue = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPGroupStore = New DevExpress.XtraTab.XtraTabPage()
        Me.GCGroup = New DevExpress.XtraGrid.GridControl()
        Me.GVGroup = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumninv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpaid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndiff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.VolcomMRP.WaitForm), True, True)
        CType(Me.PanelNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelNav.SuspendLayout()
        CType(Me.BtnBrowseEval.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPInvoiceDetail.SuspendLayout()
        CType(Me.GCInvoiceDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVInvoiceDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoBtnBBM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkMemo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPNewEval.SuspendLayout()
        CType(Me.XTCCreateNewEval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCCreateNewEval.SuspendLayout()
        Me.XTPInvoiceList.SuspendLayout()
        CType(Me.GCActiveList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVActiveList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkMemoEval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPGroupStoreList.SuspendLayout()
        CType(Me.GCGroupStoreList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVGroupStoreList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControlCreateEval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlCreateEval.SuspendLayout()
        Me.XTPGroupStore.SuspendLayout()
        CType(Me.GCGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelNav
        '
        Me.PanelNav.Controls.Add(Me.BtnLog)
        Me.PanelNav.Controls.Add(Me.BtnViewData)
        Me.PanelNav.Controls.Add(Me.BtnBrowseEval)
        Me.PanelNav.Controls.Add(Me.LabelControl1)
        Me.PanelNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelNav.Location = New System.Drawing.Point(0, 0)
        Me.PanelNav.Name = "PanelNav"
        Me.PanelNav.Size = New System.Drawing.Size(798, 50)
        Me.PanelNav.TabIndex = 0
        '
        'BtnLog
        '
        Me.BtnLog.Image = CType(resources.GetObject("BtnLog.Image"), System.Drawing.Image)
        Me.BtnLog.Location = New System.Drawing.Point(444, 13)
        Me.BtnLog.Name = "BtnLog"
        Me.BtnLog.Size = New System.Drawing.Size(104, 23)
        Me.BtnLog.TabIndex = 3
        Me.BtnLog.Text = "Execution Log"
        '
        'BtnViewData
        '
        Me.BtnViewData.Image = CType(resources.GetObject("BtnViewData.Image"), System.Drawing.Image)
        Me.BtnViewData.Location = New System.Drawing.Point(347, 13)
        Me.BtnViewData.Name = "BtnViewData"
        Me.BtnViewData.Size = New System.Drawing.Size(91, 23)
        Me.BtnViewData.TabIndex = 2
        Me.BtnViewData.Text = "View Data"
        '
        'BtnBrowseEval
        '
        Me.BtnBrowseEval.Location = New System.Drawing.Point(96, 15)
        Me.BtnBrowseEval.Name = "BtnBrowseEval"
        Me.BtnBrowseEval.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.BtnBrowseEval.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.BtnBrowseEval.Size = New System.Drawing.Size(245, 20)
        Me.BtnBrowseEval.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(14, 18)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(76, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Evaluation Date"
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCData.Location = New System.Drawing.Point(0, 50)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPInvoiceDetail
        Me.XTCData.Size = New System.Drawing.Size(798, 414)
        Me.XTCData.TabIndex = 1
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPNewEval, Me.XTPInvoiceDetail, Me.XTPGroupStore})
        '
        'XTPInvoiceDetail
        '
        Me.XTPInvoiceDetail.Controls.Add(Me.GCInvoiceDetail)
        Me.XTPInvoiceDetail.Name = "XTPInvoiceDetail"
        Me.XTPInvoiceDetail.Size = New System.Drawing.Size(792, 386)
        Me.XTPInvoiceDetail.Text = "History (Invoice)"
        '
        'GCInvoiceDetail
        '
        Me.GCInvoiceDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCInvoiceDetail.Location = New System.Drawing.Point(0, 0)
        Me.GCInvoiceDetail.MainView = Me.GVInvoiceDetail
        Me.GCInvoiceDetail.Name = "GCInvoiceDetail"
        Me.GCInvoiceDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoBtnBBM, Me.RepoLinkInvoice, Me.RepoLinkMemo})
        Me.GCInvoiceDetail.Size = New System.Drawing.Size(792, 386)
        Me.GCInvoiceDetail.TabIndex = 0
        Me.GCInvoiceDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInvoiceDetail})
        '
        'GVInvoiceDetail
        '
        Me.GVInvoiceDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp_group, Me.GridColumngroup_store, Me.GridColumnid_inv, Me.GridColumninv_number, Me.GridColumninv_rmt, Me.GridColumninv_amount, Me.GridColumnpaid_status, Me.GridColumnrelease_date, Me.GridColumnote, Me.GridColumnactive_status, Me.GridColumnbtn_bbm, Me.GridColumnid_propose_delay_payment, Me.GridColumnmemo_number})
        Me.GVInvoiceDetail.GridControl = Me.GCInvoiceDetail
        Me.GVInvoiceDetail.GroupCount = 1
        Me.GVInvoiceDetail.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "inv_amount", Me.GridColumninv_amount, "{0:N2}")})
        Me.GVInvoiceDetail.Name = "GVInvoiceDetail"
        Me.GVInvoiceDetail.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVInvoiceDetail.OptionsView.ColumnAutoWidth = False
        Me.GVInvoiceDetail.OptionsView.ShowFooter = True
        Me.GVInvoiceDetail.OptionsView.ShowGroupedColumns = True
        Me.GVInvoiceDetail.OptionsView.ShowGroupPanel = False
        Me.GVInvoiceDetail.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumngroup_store, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnid_comp_group
        '
        Me.GridColumnid_comp_group.Caption = "id_comp_group"
        Me.GridColumnid_comp_group.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group.Name = "GridColumnid_comp_group"
        Me.GridColumnid_comp_group.OptionsColumn.AllowEdit = False
        '
        'GridColumngroup_store
        '
        Me.GridColumngroup_store.Caption = "Group Store"
        Me.GridColumngroup_store.FieldName = "group_store"
        Me.GridColumngroup_store.Name = "GridColumngroup_store"
        Me.GridColumngroup_store.OptionsColumn.AllowEdit = False
        Me.GridColumngroup_store.Visible = True
        Me.GridColumngroup_store.VisibleIndex = 0
        '
        'GridColumnid_inv
        '
        Me.GridColumnid_inv.Caption = "id_inv"
        Me.GridColumnid_inv.FieldName = "id_inv"
        Me.GridColumnid_inv.Name = "GridColumnid_inv"
        Me.GridColumnid_inv.OptionsColumn.AllowEdit = False
        '
        'GridColumninv_number
        '
        Me.GridColumninv_number.Caption = "Invoice No"
        Me.GridColumninv_number.ColumnEdit = Me.RepoLinkInvoice
        Me.GridColumninv_number.FieldName = "inv_number"
        Me.GridColumninv_number.Name = "GridColumninv_number"
        Me.GridColumninv_number.OptionsColumn.ReadOnly = True
        Me.GridColumninv_number.Visible = True
        Me.GridColumninv_number.VisibleIndex = 1
        '
        'RepoLinkInvoice
        '
        Me.RepoLinkInvoice.AutoHeight = False
        Me.RepoLinkInvoice.Name = "RepoLinkInvoice"
        '
        'GridColumninv_rmt
        '
        Me.GridColumninv_rmt.Caption = "inv_rmt"
        Me.GridColumninv_rmt.FieldName = "inv_rmt"
        Me.GridColumninv_rmt.Name = "GridColumninv_rmt"
        Me.GridColumninv_rmt.OptionsColumn.AllowEdit = False
        '
        'GridColumninv_amount
        '
        Me.GridColumninv_amount.Caption = "Invoice Amount"
        Me.GridColumninv_amount.DisplayFormat.FormatString = "N2"
        Me.GridColumninv_amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumninv_amount.FieldName = "inv_amount"
        Me.GridColumninv_amount.Name = "GridColumninv_amount"
        Me.GridColumninv_amount.OptionsColumn.AllowEdit = False
        Me.GridColumninv_amount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "inv_amount", "{0:N2}")})
        Me.GridColumninv_amount.Visible = True
        Me.GridColumninv_amount.VisibleIndex = 2
        '
        'GridColumnpaid_status
        '
        Me.GridColumnpaid_status.Caption = "Paid Status"
        Me.GridColumnpaid_status.FieldName = "paid_status"
        Me.GridColumnpaid_status.Name = "GridColumnpaid_status"
        Me.GridColumnpaid_status.OptionsColumn.AllowEdit = False
        Me.GridColumnpaid_status.Visible = True
        Me.GridColumnpaid_status.VisibleIndex = 3
        '
        'GridColumnrelease_date
        '
        Me.GridColumnrelease_date.Caption = "Release Date"
        Me.GridColumnrelease_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumnrelease_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnrelease_date.FieldName = "release_date"
        Me.GridColumnrelease_date.Name = "GridColumnrelease_date"
        Me.GridColumnrelease_date.OptionsColumn.AllowEdit = False
        Me.GridColumnrelease_date.Visible = True
        Me.GridColumnrelease_date.VisibleIndex = 6
        '
        'GridColumnote
        '
        Me.GridColumnote.Caption = "Note"
        Me.GridColumnote.FieldName = "note"
        Me.GridColumnote.Name = "GridColumnote"
        Me.GridColumnote.OptionsColumn.AllowEdit = False
        Me.GridColumnote.Visible = True
        Me.GridColumnote.VisibleIndex = 7
        '
        'GridColumnactive_status
        '
        Me.GridColumnactive_status.Caption = "Status"
        Me.GridColumnactive_status.FieldName = "active_status"
        Me.GridColumnactive_status.Name = "GridColumnactive_status"
        Me.GridColumnactive_status.OptionsColumn.AllowEdit = False
        Me.GridColumnactive_status.Visible = True
        Me.GridColumnactive_status.VisibleIndex = 8
        '
        'GridColumnbtn_bbm
        '
        Me.GridColumnbtn_bbm.Caption = "Payment"
        Me.GridColumnbtn_bbm.ColumnEdit = Me.RepoBtnBBM
        Me.GridColumnbtn_bbm.FieldName = "btn_bbm"
        Me.GridColumnbtn_bbm.Name = "GridColumnbtn_bbm"
        Me.GridColumnbtn_bbm.Visible = True
        Me.GridColumnbtn_bbm.VisibleIndex = 4
        '
        'RepoBtnBBM
        '
        Me.RepoBtnBBM.AutoHeight = False
        SerializableAppearanceObject1.BackColor = System.Drawing.Color.Teal
        SerializableAppearanceObject1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject1.ForeColor = System.Drawing.Color.White
        SerializableAppearanceObject1.Options.UseBackColor = True
        SerializableAppearanceObject1.Options.UseFont = True
        SerializableAppearanceObject1.Options.UseForeColor = True
        Me.RepoBtnBBM.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "View BBM", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.RepoBtnBBM.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.RepoBtnBBM.Name = "RepoBtnBBM"
        Me.RepoBtnBBM.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'GridColumnid_propose_delay_payment
        '
        Me.GridColumnid_propose_delay_payment.Caption = "Id Memo Penangguhan"
        Me.GridColumnid_propose_delay_payment.FieldName = "tb_propose_delay_payment"
        Me.GridColumnid_propose_delay_payment.Name = "GridColumnid_propose_delay_payment"
        Me.GridColumnid_propose_delay_payment.OptionsColumn.AllowEdit = False
        '
        'GridColumnmemo_number
        '
        Me.GridColumnmemo_number.Caption = "Memo Penangguhan"
        Me.GridColumnmemo_number.ColumnEdit = Me.RepoLinkMemo
        Me.GridColumnmemo_number.FieldName = "memo_number"
        Me.GridColumnmemo_number.Name = "GridColumnmemo_number"
        Me.GridColumnmemo_number.OptionsColumn.ReadOnly = True
        Me.GridColumnmemo_number.Visible = True
        Me.GridColumnmemo_number.VisibleIndex = 5
        Me.GridColumnmemo_number.Width = 131
        '
        'RepoLinkMemo
        '
        Me.RepoLinkMemo.AutoHeight = False
        Me.RepoLinkMemo.Name = "RepoLinkMemo"
        '
        'XTPNewEval
        '
        Me.XTPNewEval.Controls.Add(Me.XTCCreateNewEval)
        Me.XTPNewEval.Controls.Add(Me.PanelControl1)
        Me.XTPNewEval.Controls.Add(Me.PanelControlCreateEval)
        Me.XTPNewEval.Name = "XTPNewEval"
        Me.XTPNewEval.Size = New System.Drawing.Size(792, 386)
        Me.XTPNewEval.Text = "Create New Evaluation"
        '
        'XTCCreateNewEval
        '
        Me.XTCCreateNewEval.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCCreateNewEval.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCCreateNewEval.Location = New System.Drawing.Point(0, 28)
        Me.XTCCreateNewEval.Name = "XTCCreateNewEval"
        Me.XTCCreateNewEval.SelectedTabPage = Me.XTPInvoiceList
        Me.XTCCreateNewEval.Size = New System.Drawing.Size(792, 314)
        Me.XTCCreateNewEval.TabIndex = 5
        Me.XTCCreateNewEval.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPInvoiceList, Me.XTPGroupStoreList})
        '
        'XTPInvoiceList
        '
        Me.XTPInvoiceList.Controls.Add(Me.GCActiveList)
        Me.XTPInvoiceList.Name = "XTPInvoiceList"
        Me.XTPInvoiceList.Size = New System.Drawing.Size(763, 308)
        Me.XTPInvoiceList.Text = "Invoice List"
        '
        'GCActiveList
        '
        Me.GCActiveList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCActiveList.Location = New System.Drawing.Point(0, 0)
        Me.GCActiveList.MainView = Me.GVActiveList
        Me.GCActiveList.Name = "GCActiveList"
        Me.GCActiveList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepoLinkMemoEval})
        Me.GCActiveList.Size = New System.Drawing.Size(763, 308)
        Me.GCActiveList.TabIndex = 0
        Me.GCActiveList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVActiveList})
        '
        'GVActiveList
        '
        Me.GVActiveList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_sales_pos, Me.GridColumnsales_pos_number, Me.GridColumnstore, Me.GridColumnsales_pos_date, Me.GridColumnsales_pos_due_date, Me.GridColumnid_propose_delay_payment_eval, Me.GridColumnmemo_number_eval, Me.GridColumnpropose_delay_payment_due_date_eval, Me.GridColumndue_days, Me.GridColumnaging, Me.GridColumnperiod, Me.GridColumnamount, Me.GridColumngroup, Me.GridColumnis_select, Me.GridColumnid_store_company_active})
        Me.GVActiveList.GridControl = Me.GCActiveList
        Me.GVActiveList.GroupCount = 1
        Me.GVActiveList.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", Me.GridColumnamount, "{0:N2}")})
        Me.GVActiveList.Name = "GVActiveList"
        Me.GVActiveList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVActiveList.OptionsFind.AlwaysVisible = True
        Me.GVActiveList.OptionsView.ColumnAutoWidth = False
        Me.GVActiveList.OptionsView.ShowFooter = True
        Me.GVActiveList.OptionsView.ShowGroupedColumns = True
        Me.GVActiveList.OptionsView.ShowGroupPanel = False
        Me.GVActiveList.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumngroup, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnid_sales_pos
        '
        Me.GridColumnid_sales_pos.Caption = "id_sales_pos"
        Me.GridColumnid_sales_pos.FieldName = "id_sales_pos"
        Me.GridColumnid_sales_pos.Name = "GridColumnid_sales_pos"
        Me.GridColumnid_sales_pos.OptionsColumn.AllowEdit = False
        '
        'GridColumnsales_pos_number
        '
        Me.GridColumnsales_pos_number.Caption = "Invoice No."
        Me.GridColumnsales_pos_number.FieldName = "sales_pos_number"
        Me.GridColumnsales_pos_number.Name = "GridColumnsales_pos_number"
        Me.GridColumnsales_pos_number.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_pos_number.Visible = True
        Me.GridColumnsales_pos_number.VisibleIndex = 0
        '
        'GridColumnstore
        '
        Me.GridColumnstore.Caption = "Store"
        Me.GridColumnstore.FieldName = "store"
        Me.GridColumnstore.Name = "GridColumnstore"
        Me.GridColumnstore.OptionsColumn.AllowEdit = False
        Me.GridColumnstore.Visible = True
        Me.GridColumnstore.VisibleIndex = 2
        '
        'GridColumnsales_pos_date
        '
        Me.GridColumnsales_pos_date.Caption = "Created Date"
        Me.GridColumnsales_pos_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_pos_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_date.FieldName = "sales_pos_date"
        Me.GridColumnsales_pos_date.Name = "GridColumnsales_pos_date"
        Me.GridColumnsales_pos_date.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_pos_date.Visible = True
        Me.GridColumnsales_pos_date.VisibleIndex = 3
        '
        'GridColumnsales_pos_due_date
        '
        Me.GridColumnsales_pos_due_date.Caption = "Due Date"
        Me.GridColumnsales_pos_due_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_pos_due_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_due_date.FieldName = "sales_pos_due_date"
        Me.GridColumnsales_pos_due_date.Name = "GridColumnsales_pos_due_date"
        Me.GridColumnsales_pos_due_date.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_pos_due_date.Visible = True
        Me.GridColumnsales_pos_due_date.VisibleIndex = 5
        '
        'GridColumnid_propose_delay_payment_eval
        '
        Me.GridColumnid_propose_delay_payment_eval.Caption = "id_propose_delay_payment"
        Me.GridColumnid_propose_delay_payment_eval.FieldName = "id_propose_delay_payment"
        Me.GridColumnid_propose_delay_payment_eval.Name = "GridColumnid_propose_delay_payment_eval"
        Me.GridColumnid_propose_delay_payment_eval.OptionsColumn.AllowEdit = False
        '
        'GridColumnmemo_number_eval
        '
        Me.GridColumnmemo_number_eval.Caption = "Memo Penangguhan"
        Me.GridColumnmemo_number_eval.ColumnEdit = Me.RepoLinkMemoEval
        Me.GridColumnmemo_number_eval.FieldName = "memo_number"
        Me.GridColumnmemo_number_eval.Name = "GridColumnmemo_number_eval"
        Me.GridColumnmemo_number_eval.OptionsColumn.ReadOnly = True
        Me.GridColumnmemo_number_eval.Visible = True
        Me.GridColumnmemo_number_eval.VisibleIndex = 6
        Me.GridColumnmemo_number_eval.Width = 120
        '
        'RepoLinkMemoEval
        '
        Me.RepoLinkMemoEval.AutoHeight = False
        Me.RepoLinkMemoEval.Name = "RepoLinkMemoEval"
        '
        'GridColumnpropose_delay_payment_due_date_eval
        '
        Me.GridColumnpropose_delay_payment_due_date_eval.Caption = "Tgl. Penangguhan"
        Me.GridColumnpropose_delay_payment_due_date_eval.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnpropose_delay_payment_due_date_eval.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnpropose_delay_payment_due_date_eval.FieldName = "propose_delay_payment_due_date"
        Me.GridColumnpropose_delay_payment_due_date_eval.Name = "GridColumnpropose_delay_payment_due_date_eval"
        Me.GridColumnpropose_delay_payment_due_date_eval.OptionsColumn.AllowEdit = False
        Me.GridColumnpropose_delay_payment_due_date_eval.Visible = True
        Me.GridColumnpropose_delay_payment_due_date_eval.VisibleIndex = 7
        Me.GridColumnpropose_delay_payment_due_date_eval.Width = 114
        '
        'GridColumndue_days
        '
        Me.GridColumndue_days.Caption = "due_days"
        Me.GridColumndue_days.FieldName = "due_days"
        Me.GridColumndue_days.Name = "GridColumndue_days"
        Me.GridColumndue_days.OptionsColumn.AllowEdit = False
        '
        'GridColumnaging
        '
        Me.GridColumnaging.Caption = "Aging"
        Me.GridColumnaging.FieldName = "aging"
        Me.GridColumnaging.Name = "GridColumnaging"
        Me.GridColumnaging.UnboundExpression = "Iif([due_days] = 0, [due_days], Iif([due_days] < 0, [due_days], Concat('+', [due_" &
    "days])))"
        Me.GridColumnaging.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.GridColumnaging.Visible = True
        Me.GridColumnaging.VisibleIndex = 8
        '
        'GridColumnperiod
        '
        Me.GridColumnperiod.Caption = "Period"
        Me.GridColumnperiod.FieldName = "period"
        Me.GridColumnperiod.Name = "GridColumnperiod"
        Me.GridColumnperiod.OptionsColumn.AllowEdit = False
        Me.GridColumnperiod.Visible = True
        Me.GridColumnperiod.VisibleIndex = 4
        '
        'GridColumnamount
        '
        Me.GridColumnamount.Caption = "Amount"
        Me.GridColumnamount.DisplayFormat.FormatString = "N2"
        Me.GridColumnamount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnamount.FieldName = "amount"
        Me.GridColumnamount.Name = "GridColumnamount"
        Me.GridColumnamount.OptionsColumn.AllowEdit = False
        Me.GridColumnamount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnamount.Visible = True
        Me.GridColumnamount.VisibleIndex = 9
        '
        'GridColumngroup
        '
        Me.GridColumngroup.Caption = "Store Group"
        Me.GridColumngroup.FieldName = "group"
        Me.GridColumngroup.Name = "GridColumngroup"
        Me.GridColumngroup.OptionsColumn.AllowEdit = False
        Me.GridColumngroup.Visible = True
        Me.GridColumngroup.VisibleIndex = 1
        '
        'GridColumnis_select
        '
        Me.GridColumnis_select.Caption = "Select"
        Me.GridColumnis_select.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnis_select.FieldName = "is_select"
        Me.GridColumnis_select.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnis_select.Name = "GridColumnis_select"
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'GridColumnid_store_company_active
        '
        Me.GridColumnid_store_company_active.Caption = "id_store_company"
        Me.GridColumnid_store_company_active.FieldName = "id_store_company"
        Me.GridColumnid_store_company_active.Name = "GridColumnid_store_company_active"
        '
        'XTPGroupStoreList
        '
        Me.XTPGroupStoreList.Controls.Add(Me.GCGroupStoreList)
        Me.XTPGroupStoreList.Name = "XTPGroupStoreList"
        Me.XTPGroupStoreList.Size = New System.Drawing.Size(763, 308)
        Me.XTPGroupStoreList.Text = "Store Company List"
        '
        'GCGroupStoreList
        '
        Me.GCGroupStoreList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCGroupStoreList.Location = New System.Drawing.Point(0, 0)
        Me.GCGroupStoreList.MainView = Me.GVGroupStoreList
        Me.GCGroupStoreList.Name = "GCGroupStoreList"
        Me.GCGroupStoreList.Size = New System.Drawing.Size(763, 308)
        Me.GCGroupStoreList.TabIndex = 1
        Me.GCGroupStoreList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVGroupStoreList})
        '
        'GVGroupStoreList
        '
        Me.GVGroupStoreList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp_group_eval, Me.GridColumngroup_eval, Me.GridColumnid_ho, Me.GridColumnho, Me.GridColumnemail_ho})
        Me.GVGroupStoreList.GridControl = Me.GCGroupStoreList
        Me.GVGroupStoreList.Name = "GVGroupStoreList"
        Me.GVGroupStoreList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVGroupStoreList.OptionsBehavior.Editable = False
        Me.GVGroupStoreList.OptionsFind.AlwaysVisible = True
        Me.GVGroupStoreList.OptionsView.ColumnAutoWidth = False
        Me.GVGroupStoreList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_comp_group_eval
        '
        Me.GridColumnid_comp_group_eval.Caption = "id_comp_group"
        Me.GridColumnid_comp_group_eval.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group_eval.Name = "GridColumnid_comp_group_eval"
        Me.GridColumnid_comp_group_eval.OptionsColumn.AllowEdit = False
        '
        'GridColumngroup_eval
        '
        Me.GridColumngroup_eval.Caption = "Store Group"
        Me.GridColumngroup_eval.FieldName = "group"
        Me.GridColumngroup_eval.Name = "GridColumngroup_eval"
        Me.GridColumngroup_eval.Visible = True
        Me.GridColumngroup_eval.VisibleIndex = 0
        '
        'GridColumnid_ho
        '
        Me.GridColumnid_ho.Caption = "id_ho"
        Me.GridColumnid_ho.FieldName = "id_ho"
        Me.GridColumnid_ho.Name = "GridColumnid_ho"
        Me.GridColumnid_ho.OptionsColumn.AllowEdit = False
        '
        'GridColumnho
        '
        Me.GridColumnho.Caption = "Store Company"
        Me.GridColumnho.FieldName = "ho"
        Me.GridColumnho.Name = "GridColumnho"
        Me.GridColumnho.OptionsColumn.AllowEdit = False
        Me.GridColumnho.Visible = True
        Me.GridColumnho.VisibleIndex = 1
        Me.GridColumnho.Width = 148
        '
        'GridColumnemail_ho
        '
        Me.GridColumnemail_ho.Caption = "Email Address"
        Me.GridColumnemail_ho.FieldName = "email_ho"
        Me.GridColumnemail_ho.Name = "GridColumnemail_ho"
        Me.GridColumnemail_ho.Visible = True
        Me.GridColumnemail_ho.VisibleIndex = 2
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnDiscardMemo)
        Me.PanelControl1.Controls.Add(Me.BtnCreateMemo)
        Me.PanelControl1.Controls.Add(Me.BtnActivateMemoPenangguhan)
        Me.PanelControl1.Controls.Add(Me.BtnCreateEvaluation)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 342)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(792, 44)
        Me.PanelControl1.TabIndex = 1
        '
        'BtnDiscardMemo
        '
        Me.BtnDiscardMemo.Appearance.BackColor = System.Drawing.Color.Crimson
        Me.BtnDiscardMemo.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDiscardMemo.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnDiscardMemo.Appearance.Options.UseBackColor = True
        Me.BtnDiscardMemo.Appearance.Options.UseFont = True
        Me.BtnDiscardMemo.Appearance.Options.UseForeColor = True
        Me.BtnDiscardMemo.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscardMemo.Location = New System.Drawing.Point(232, 2)
        Me.BtnDiscardMemo.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnDiscardMemo.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnDiscardMemo.Name = "BtnDiscardMemo"
        Me.BtnDiscardMemo.Size = New System.Drawing.Size(114, 40)
        Me.BtnDiscardMemo.TabIndex = 5
        Me.BtnDiscardMemo.Text = "Discard Memo"
        Me.BtnDiscardMemo.Visible = False
        '
        'BtnCreateMemo
        '
        Me.BtnCreateMemo.Appearance.BackColor = System.Drawing.Color.Teal
        Me.BtnCreateMemo.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCreateMemo.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnCreateMemo.Appearance.Options.UseBackColor = True
        Me.BtnCreateMemo.Appearance.Options.UseFont = True
        Me.BtnCreateMemo.Appearance.Options.UseForeColor = True
        Me.BtnCreateMemo.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCreateMemo.Location = New System.Drawing.Point(346, 2)
        Me.BtnCreateMemo.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnCreateMemo.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnCreateMemo.Name = "BtnCreateMemo"
        Me.BtnCreateMemo.Size = New System.Drawing.Size(191, 40)
        Me.BtnCreateMemo.TabIndex = 4
        Me.BtnCreateMemo.Text = "Create Memo Penangguhan"
        Me.BtnCreateMemo.Visible = False
        '
        'BtnActivateMemoPenangguhan
        '
        Me.BtnActivateMemoPenangguhan.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.BtnActivateMemoPenangguhan.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnActivateMemoPenangguhan.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnActivateMemoPenangguhan.Appearance.Options.UseBackColor = True
        Me.BtnActivateMemoPenangguhan.Appearance.Options.UseFont = True
        Me.BtnActivateMemoPenangguhan.Appearance.Options.UseForeColor = True
        Me.BtnActivateMemoPenangguhan.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnActivateMemoPenangguhan.Location = New System.Drawing.Point(537, 2)
        Me.BtnActivateMemoPenangguhan.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnActivateMemoPenangguhan.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnActivateMemoPenangguhan.Name = "BtnActivateMemoPenangguhan"
        Me.BtnActivateMemoPenangguhan.Size = New System.Drawing.Size(134, 40)
        Me.BtnActivateMemoPenangguhan.TabIndex = 6
        Me.BtnActivateMemoPenangguhan.Text = "Memo Penangguhan"
        Me.BtnActivateMemoPenangguhan.Visible = False
        '
        'BtnCreateEvaluation
        '
        Me.BtnCreateEvaluation.Appearance.BackColor = System.Drawing.Color.OrangeRed
        Me.BtnCreateEvaluation.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCreateEvaluation.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnCreateEvaluation.Appearance.Options.UseBackColor = True
        Me.BtnCreateEvaluation.Appearance.Options.UseFont = True
        Me.BtnCreateEvaluation.Appearance.Options.UseForeColor = True
        Me.BtnCreateEvaluation.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCreateEvaluation.Location = New System.Drawing.Point(671, 2)
        Me.BtnCreateEvaluation.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnCreateEvaluation.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnCreateEvaluation.Name = "BtnCreateEvaluation"
        Me.BtnCreateEvaluation.Size = New System.Drawing.Size(119, 40)
        Me.BtnCreateEvaluation.TabIndex = 3
        Me.BtnCreateEvaluation.Text = "Hold Delivery"
        Me.BtnCreateEvaluation.Visible = False
        '
        'PanelControlCreateEval
        '
        Me.PanelControlCreateEval.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlCreateEval.Controls.Add(Me.BtnViewOverdue)
        Me.PanelControlCreateEval.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlCreateEval.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlCreateEval.Name = "PanelControlCreateEval"
        Me.PanelControlCreateEval.Size = New System.Drawing.Size(792, 28)
        Me.PanelControlCreateEval.TabIndex = 6
        Me.PanelControlCreateEval.Visible = False
        '
        'BtnViewOverdue
        '
        Me.BtnViewOverdue.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BtnViewOverdue.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnViewOverdue.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnViewOverdue.Appearance.Options.UseBackColor = True
        Me.BtnViewOverdue.Appearance.Options.UseFont = True
        Me.BtnViewOverdue.Appearance.Options.UseForeColor = True
        Me.BtnViewOverdue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnViewOverdue.Location = New System.Drawing.Point(0, 0)
        Me.BtnViewOverdue.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnViewOverdue.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnViewOverdue.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnViewOverdue.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnViewOverdue.Name = "BtnViewOverdue"
        Me.BtnViewOverdue.Size = New System.Drawing.Size(792, 28)
        Me.BtnViewOverdue.TabIndex = 19
        Me.BtnViewOverdue.Text = "View Overdue Invoice"
        '
        'XTPGroupStore
        '
        Me.XTPGroupStore.Controls.Add(Me.GCGroup)
        Me.XTPGroupStore.Name = "XTPGroupStore"
        Me.XTPGroupStore.Size = New System.Drawing.Size(792, 386)
        Me.XTPGroupStore.Text = "History (Group Store)"
        '
        'GCGroup
        '
        Me.GCGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCGroup.Location = New System.Drawing.Point(0, 0)
        Me.GCGroup.MainView = Me.GVGroup
        Me.GCGroup.Name = "GCGroup"
        Me.GCGroup.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1})
        Me.GCGroup.Size = New System.Drawing.Size(792, 386)
        Me.GCGroup.TabIndex = 1
        Me.GCGroup.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVGroup})
        '
        'GVGroup
        '
        Me.GVGroup.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumninv, Me.GridColumnpaid, Me.GridColumndiff})
        Me.GVGroup.GridControl = Me.GCGroup
        Me.GVGroup.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "inv", Me.GridColumninv, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "paid", Me.GridColumnpaid, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff", Me.GridColumndiff, "{0:N0}")})
        Me.GVGroup.Name = "GVGroup"
        Me.GVGroup.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVGroup.OptionsView.ColumnAutoWidth = False
        Me.GVGroup.OptionsView.ShowFooter = True
        Me.GVGroup.OptionsView.ShowGroupedColumns = True
        Me.GVGroup.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "id_comp_group"
        Me.GridColumn1.FieldName = "id_comp_group"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Group Store"
        Me.GridColumn2.FieldName = "group_store"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumninv
        '
        Me.GridColumninv.Caption = "Invoice Overdue"
        Me.GridColumninv.DisplayFormat.FormatString = "N0"
        Me.GridColumninv.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumninv.FieldName = "inv"
        Me.GridColumninv.Name = "GridColumninv"
        Me.GridColumninv.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "inv", "{0:N0}")})
        Me.GridColumninv.Visible = True
        Me.GridColumninv.VisibleIndex = 1
        '
        'GridColumnpaid
        '
        Me.GridColumnpaid.Caption = "Paid"
        Me.GridColumnpaid.DisplayFormat.FormatString = "N0"
        Me.GridColumnpaid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnpaid.FieldName = "paid"
        Me.GridColumnpaid.Name = "GridColumnpaid"
        Me.GridColumnpaid.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "paid", "{0:N0}")})
        Me.GridColumnpaid.Visible = True
        Me.GridColumnpaid.VisibleIndex = 2
        '
        'GridColumndiff
        '
        Me.GridColumndiff.Caption = "Diff"
        Me.GridColumndiff.DisplayFormat.FormatString = "N0"
        Me.GridColumndiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndiff.FieldName = "diff"
        Me.GridColumndiff.Name = "GridColumndiff"
        Me.GridColumndiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff", "{0:N0}")})
        Me.GridColumndiff.UnboundExpression = "[paid] - [inv]"
        Me.GridColumndiff.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GridColumndiff.Visible = True
        Me.GridColumndiff.VisibleIndex = 3
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        SerializableAppearanceObject2.BackColor = System.Drawing.Color.Teal
        SerializableAppearanceObject2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject2.ForeColor = System.Drawing.Color.White
        SerializableAppearanceObject2.Options.UseBackColor = True
        SerializableAppearanceObject2.Options.UseFont = True
        SerializableAppearanceObject2.Options.UseForeColor = True
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "BBM", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        Me.RepositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'FormAREvaluation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 464)
        Me.Controls.Add(Me.XTCData)
        Me.Controls.Add(Me.PanelNav)
        Me.MinimizeBox = False
        Me.Name = "FormAREvaluation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AR Evaluation"
        CType(Me.PanelNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelNav.ResumeLayout(False)
        Me.PanelNav.PerformLayout()
        CType(Me.BtnBrowseEval.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPInvoiceDetail.ResumeLayout(False)
        CType(Me.GCInvoiceDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVInvoiceDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoBtnBBM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkMemo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPNewEval.ResumeLayout(False)
        CType(Me.XTCCreateNewEval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCCreateNewEval.ResumeLayout(False)
        Me.XTPInvoiceList.ResumeLayout(False)
        CType(Me.GCActiveList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVActiveList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkMemoEval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPGroupStoreList.ResumeLayout(False)
        CType(Me.GCGroupStoreList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVGroupStoreList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControlCreateEval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlCreateEval.ResumeLayout(False)
        Me.XTPGroupStore.ResumeLayout(False)
        CType(Me.GCGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPInvoiceDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPGroupStore As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents BtnViewData As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnBrowseEval As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCInvoiceDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVInvoiceDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngroup_store As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_inv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumninv_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumninv_rmt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumninv_amount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpaid_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnrelease_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnactive_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnbtn_bbm As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoBtnBBM As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GCGroup As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVGroup As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepoLinkInvoice As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents GridColumninv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpaid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndiff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPNewEval As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCreateEvaluation As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTCCreateNewEval As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPInvoiceList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCActiveList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVActiveList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_propose_delay_payment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnmemo_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoLinkMemo As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents XTPGroupStoreList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCGroupStoreList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVGroupStoreList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_sales_pos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstore As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_due_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_propose_delay_payment_eval As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnmemo_number_eval As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpropose_delay_payment_due_date_eval As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndue_days As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnaging As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnperiod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnamount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnViewOverdue As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControlCreateEval As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumnid_comp_group_eval As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngroup_eval As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnCreateMemo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDiscardMemo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnActivateMemoPenangguhan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnis_select As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents BtnLog As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_ho As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoLinkMemoEval As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents GridColumnho As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnemail_ho As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_store_company_active As DevExpress.XtraGrid.Columns.GridColumn
End Class
