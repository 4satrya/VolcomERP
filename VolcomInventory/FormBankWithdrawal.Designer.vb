<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBankWithdrawal
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
        Me.XTCPO = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPO = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPOList = New DevExpress.XtraGrid.GridControl()
        Me.GVPOList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICECheckReceive = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnIdRec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOrderNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUpdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUpdatedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVendor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BCreatePO = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SLEStatusPayment = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEPayType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEVendor = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPPayment = New DevExpress.XtraTab.XtraTabPage()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SLEPayTypePayment = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEVendorPayment = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BViewPayment = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPExpense = New DevExpress.XtraTab.XtraTabPage()
        Me.GCExpense = New DevExpress.XtraGrid.GridControl()
        Me.GVExpense = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedByName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReortStt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPaidStt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotalExpense = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdComp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBeneficiary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumnSelectExpense = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CESelectExpense = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnTotalExpenseDP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotalExpensePaid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPaymentPendingExpense = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDueDateExpense = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDiffExpense = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl()
        Me.SLEPayTypeExpense = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView7 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.BCreateExpense = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.SLEStatusPaymentExpense = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnViewExpense = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEVendorExpense = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView8 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn38 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.GridColumnDueDays = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsOpenExpense = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPO.SuspendLayout()
        Me.XTPPO.SuspendLayout()
        CType(Me.GCPOList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPOList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICECheckReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEStatusPayment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEPayType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPPayment.SuspendLayout()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SLEPayTypePayment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEVendorPayment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPExpense.SuspendLayout()
        CType(Me.GCExpense, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVExpense, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CESelectExpense, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl5.SuspendLayout()
        CType(Me.SLEPayTypeExpense.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.SLEStatusPaymentExpense.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEVendorExpense.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCPO
        '
        Me.XTCPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPO.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCPO.Location = New System.Drawing.Point(0, 0)
        Me.XTCPO.Name = "XTCPO"
        Me.XTCPO.SelectedTabPage = Me.XTPPO
        Me.XTCPO.Size = New System.Drawing.Size(1097, 513)
        Me.XTCPO.TabIndex = 2
        Me.XTCPO.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPayment, Me.XTPPO, Me.XTPExpense})
        '
        'XTPPO
        '
        Me.XTPPO.Controls.Add(Me.GCPOList)
        Me.XTPPO.Controls.Add(Me.BCreatePO)
        Me.XTPPO.Controls.Add(Me.PanelControl1)
        Me.XTPPO.Name = "XTPPO"
        Me.XTPPO.Size = New System.Drawing.Size(1091, 485)
        Me.XTPPO.Text = "PO List"
        '
        'GCPOList
        '
        Me.GCPOList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPOList.Location = New System.Drawing.Point(0, 42)
        Me.GCPOList.MainView = Me.GVPOList
        Me.GCPOList.Name = "GCPOList"
        Me.GCPOList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICECheckReceive})
        Me.GCPOList.Size = New System.Drawing.Size(1091, 411)
        Me.GCPOList.TabIndex = 17
        Me.GCPOList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPOList})
        '
        'GVPOList
        '
        Me.GVPOList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumnIdRec, Me.GridColumnOrderNumber, Me.GridColumnCreatedDate, Me.GridColumnCreatedBy, Me.GridColumnLastUpdate, Me.GridColumnUpdatedBy, Me.GridColumnNote, Me.GridColumn4, Me.GridColumn3, Me.GridColumn24, Me.GridColumn23, Me.GridColumn19, Me.GridColumn27, Me.GridColumn28, Me.GridColumnVendor, Me.GridColumn32, Me.GridColumn25, Me.GridColumn26, Me.GridColumn12})
        Me.GVPOList.GridControl = Me.GCPOList
        Me.GVPOList.Name = "GVPOList"
        Me.GVPOList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPOList.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GVPOList.OptionsView.ColumnAutoWidth = False
        Me.GVPOList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "*"
        Me.GridColumn2.ColumnEdit = Me.RICECheckReceive
        Me.GridColumn2.FieldName = "is_check"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'RICECheckReceive
        '
        Me.RICECheckReceive.AutoHeight = False
        Me.RICECheckReceive.Name = "RICECheckReceive"
        Me.RICECheckReceive.ValueChecked = "yes"
        Me.RICECheckReceive.ValueUnchecked = "no"
        '
        'GridColumnIdRec
        '
        Me.GridColumnIdRec.Caption = "ID"
        Me.GridColumnIdRec.FieldName = "id_purc_rec"
        Me.GridColumnIdRec.Name = "GridColumnIdRec"
        Me.GridColumnIdRec.OptionsColumn.AllowEdit = False
        '
        'GridColumnOrderNumber
        '
        Me.GridColumnOrderNumber.Caption = "PO Number"
        Me.GridColumnOrderNumber.FieldName = "purc_order_number"
        Me.GridColumnOrderNumber.Name = "GridColumnOrderNumber"
        Me.GridColumnOrderNumber.OptionsColumn.AllowEdit = False
        Me.GridColumnOrderNumber.Visible = True
        Me.GridColumnOrderNumber.VisibleIndex = 2
        Me.GridColumnOrderNumber.Width = 165
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy \/ HH:mm"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "date_created"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.OptionsColumn.AllowEdit = False
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 4
        Me.GridColumnCreatedDate.Width = 92
        '
        'GridColumnCreatedBy
        '
        Me.GridColumnCreatedBy.Caption = "Created By"
        Me.GridColumnCreatedBy.FieldName = "created_by_name"
        Me.GridColumnCreatedBy.Name = "GridColumnCreatedBy"
        Me.GridColumnCreatedBy.OptionsColumn.AllowEdit = False
        '
        'GridColumnLastUpdate
        '
        Me.GridColumnLastUpdate.Caption = "Last Updated"
        Me.GridColumnLastUpdate.DisplayFormat.FormatString = "dd MMMM yyyy \/ HH:mm"
        Me.GridColumnLastUpdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnLastUpdate.FieldName = "last_update"
        Me.GridColumnLastUpdate.Name = "GridColumnLastUpdate"
        Me.GridColumnLastUpdate.OptionsColumn.AllowEdit = False
        '
        'GridColumnUpdatedBy
        '
        Me.GridColumnUpdatedBy.Caption = "Updated By"
        Me.GridColumnUpdatedBy.FieldName = "last_update_by_name"
        Me.GridColumnUpdatedBy.Name = "GridColumnUpdatedBy"
        Me.GridColumnUpdatedBy.OptionsColumn.AllowEdit = False
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "PO Note"
        Me.GridColumnNote.FieldName = "note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.OptionsColumn.AllowEdit = False
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 9
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.Caption = "Qty PO"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "qty_po"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 5
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.Caption = "Amount PO (After discount + VAT)"
        Me.GridColumn3.DisplayFormat.FormatString = "N2"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.FieldName = "total_po"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 6
        '
        'GridColumn24
        '
        Me.GridColumn24.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn24.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn24.Caption = "Qty Receiving"
        Me.GridColumn24.DisplayFormat.FormatString = "N2"
        Me.GridColumn24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn24.FieldName = "qty_rec"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsColumn.AllowEdit = False
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 7
        Me.GridColumn24.Width = 113
        '
        'GridColumn23
        '
        Me.GridColumn23.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn23.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn23.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn23.Caption = "Amount Receiving (After discount + VAT)"
        Me.GridColumn23.DisplayFormat.FormatString = "N2"
        Me.GridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn23.FieldName = "total_rec"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsColumn.AllowEdit = False
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 8
        Me.GridColumn23.Width = 118
        '
        'GridColumn19
        '
        Me.GridColumn19.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn19.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn19.Caption = "DP Amount"
        Me.GridColumn19.DisplayFormat.FormatString = "N2"
        Me.GridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn19.FieldName = "total_dp"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsColumn.AllowEdit = False
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 12
        '
        'GridColumn27
        '
        Me.GridColumn27.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn27.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn27.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn27.Caption = "Total Paid (Include DP)"
        Me.GridColumn27.DisplayFormat.FormatString = "N2"
        Me.GridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn27.FieldName = "val_pay"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.OptionsColumn.AllowEdit = False
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 13
        Me.GridColumn27.Width = 153
        '
        'GridColumn28
        '
        Me.GridColumn28.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn28.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn28.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn28.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn28.Caption = "Balance Due"
        Me.GridColumn28.DisplayFormat.FormatString = "N2"
        Me.GridColumn28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn28.FieldName = "total_due"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.OptionsColumn.AllowEdit = False
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 14
        '
        'GridColumnVendor
        '
        Me.GridColumnVendor.Caption = "Vendor"
        Me.GridColumnVendor.FieldName = "comp_name"
        Me.GridColumnVendor.Name = "GridColumnVendor"
        Me.GridColumnVendor.OptionsColumn.AllowEdit = False
        Me.GridColumnVendor.Visible = True
        Me.GridColumnVendor.VisibleIndex = 1
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "Payment Pending"
        Me.GridColumn32.DisplayFormat.FormatString = "N0"
        Me.GridColumn32.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn32.FieldName = "total_pending"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.OptionsColumn.AllowEdit = False
        Me.GridColumn32.Visible = True
        Me.GridColumn32.VisibleIndex = 3
        Me.GridColumn32.Width = 107
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Status Receiving"
        Me.GridColumn25.FieldName = "rec_status"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.OptionsColumn.AllowEdit = False
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 10
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "Close Reason"
        Me.GridColumn26.FieldName = "close_rec_reason"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.OptionsColumn.AllowEdit = False
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 11
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Due Date"
        Me.GridColumn12.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn12.FieldName = "pay_due_date"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 15
        '
        'BCreatePO
        '
        Me.BCreatePO.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BCreatePO.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BCreatePO.Appearance.ForeColor = System.Drawing.Color.White
        Me.BCreatePO.Appearance.Options.UseBackColor = True
        Me.BCreatePO.Appearance.Options.UseFont = True
        Me.BCreatePO.Appearance.Options.UseForeColor = True
        Me.BCreatePO.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BCreatePO.Location = New System.Drawing.Point(0, 453)
        Me.BCreatePO.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BCreatePO.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BCreatePO.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BCreatePO.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BCreatePO.Name = "BCreatePO"
        Me.BCreatePO.Size = New System.Drawing.Size(1091, 32)
        Me.BCreatePO.TabIndex = 18
        Me.BCreatePO.Text = "Create Payment"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLEStatusPayment)
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Controls.Add(Me.SLEPayType)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.SLEVendor)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1091, 42)
        Me.PanelControl1.TabIndex = 2
        '
        'SLEStatusPayment
        '
        Me.SLEStatusPayment.Location = New System.Drawing.Point(520, 11)
        Me.SLEStatusPayment.Name = "SLEStatusPayment"
        Me.SLEStatusPayment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStatusPayment.Properties.View = Me.GridView5
        Me.SLEStatusPayment.Size = New System.Drawing.Size(123, 20)
        Me.SLEStatusPayment.TabIndex = 8919
        '
        'GridView5
        '
        Me.GridView5.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn16, Me.GridColumn17})
        Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView5.OptionsView.ShowGroupPanel = False
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "ID Status payment"
        Me.GridColumn16.FieldName = "id_status_payment"
        Me.GridColumn16.Name = "GridColumn16"
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Status"
        Me.GridColumn17.FieldName = "status_payment"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 0
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(438, 14)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(76, 13)
        Me.LabelControl5.TabIndex = 8918
        Me.LabelControl5.Text = "Status Payment"
        '
        'SLEPayType
        '
        Me.SLEPayType.Location = New System.Drawing.Point(86, 11)
        Me.SLEPayType.Name = "SLEPayType"
        Me.SLEPayType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEPayType.Properties.View = Me.GridView3
        Me.SLEPayType.Size = New System.Drawing.Size(123, 20)
        Me.SLEPayType.TabIndex = 8917
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn5, Me.GridColumn6})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "ID Payment Type"
        Me.GridColumn5.FieldName = "id_pay_type"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Type"
        Me.GridColumn6.FieldName = "pay_type"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(11, 14)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl3.TabIndex = 8914
        Me.LabelControl3.Text = "Payment Type"
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(649, 9)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(60, 23)
        Me.BView.TabIndex = 8913
        Me.BView.Text = "view"
        '
        'SLEVendor
        '
        Me.SLEVendor.Location = New System.Drawing.Point(255, 11)
        Me.SLEVendor.Name = "SLEVendor"
        Me.SLEVendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEVendor.Properties.View = Me.GridView2
        Me.SLEVendor.Size = New System.Drawing.Size(177, 20)
        Me.SLEVendor.TabIndex = 8912
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumn14})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "ID Comp Contact"
        Me.GridColumn13.FieldName = "id_comp_contact"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Vendor"
        Me.GridColumn14.FieldName = "comp_name"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(215, 14)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl2.TabIndex = 8911
        Me.LabelControl2.Text = "Vendor"
        '
        'XTPPayment
        '
        Me.XTPPayment.Controls.Add(Me.GCList)
        Me.XTPPayment.Controls.Add(Me.PanelControl2)
        Me.XTPPayment.Name = "XTPPayment"
        Me.XTPPayment.Size = New System.Drawing.Size(1091, 485)
        Me.XTPPayment.Text = "Payment List"
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 44)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCList.Size = New System.Drawing.Size(1091, 441)
        Me.GCList.TabIndex = 18
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn8, Me.GridColumn9, Me.GridColumn11, Me.GridColumn15, Me.GridColumn20, Me.GridColumn22, Me.GridColumn18, Me.GridColumn21, Me.GridColumn7, Me.GridColumn10})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVList.OptionsView.ColumnAutoWidth = False
        Me.GVList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "ID"
        Me.GridColumn8.FieldName = "id_payment"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Number"
        Me.GridColumn9.FieldName = "number"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 1
        Me.GridColumn9.Width = 117
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Created Date"
        Me.GridColumn11.DisplayFormat.FormatString = "dd MMMM yyyy \/ HH:mm"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn11.FieldName = "date_created"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 4
        Me.GridColumn11.Width = 107
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Created By"
        Me.GridColumn15.FieldName = "created_by"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 5
        Me.GridColumn15.Width = 109
        '
        'GridColumn20
        '
        Me.GridColumn20.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn20.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn20.Caption = "Value"
        Me.GridColumn20.DisplayFormat.FormatString = "N2"
        Me.GridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn20.FieldName = "value"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsColumn.AllowEdit = False
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 6
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Approval Status"
        Me.GridColumn22.FieldName = "report_status"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsColumn.AllowEdit = False
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 8
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Note"
        Me.GridColumn18.FieldName = "note"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 7
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Vendor"
        Me.GridColumn21.FieldName = "comp_name"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.OptionsColumn.AllowEdit = False
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 0
        Me.GridColumn21.Width = 103
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Payment Type"
        Me.GridColumn7.FieldName = "pay_type"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 3
        Me.GridColumn7.Width = 92
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Report Type"
        Me.GridColumn10.FieldName = "report_mark_type_name"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 2
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SLEPayTypePayment)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Controls.Add(Me.SLEVendorPayment)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.BViewPayment)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1091, 44)
        Me.PanelControl2.TabIndex = 14
        '
        'SLEPayTypePayment
        '
        Me.SLEPayTypePayment.Location = New System.Drawing.Point(86, 13)
        Me.SLEPayTypePayment.Name = "SLEPayTypePayment"
        Me.SLEPayTypePayment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEPayTypePayment.Properties.View = Me.GridView4
        Me.SLEPayTypePayment.Size = New System.Drawing.Size(123, 20)
        Me.SLEPayTypePayment.TabIndex = 8920
        '
        'GridView4
        '
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn30, Me.GridColumn31})
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "ID Payment Type"
        Me.GridColumn30.FieldName = "id_pay_type"
        Me.GridColumn30.Name = "GridColumn30"
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "Type"
        Me.GridColumn31.FieldName = "pay_type"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 0
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(11, 16)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl4.TabIndex = 8919
        Me.LabelControl4.Text = "Payment Type"
        '
        'SLEVendorPayment
        '
        Me.SLEVendorPayment.Location = New System.Drawing.Point(261, 13)
        Me.SLEVendorPayment.Name = "SLEVendorPayment"
        Me.SLEVendorPayment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEVendorPayment.Properties.View = Me.GridView1
        Me.SLEVendorPayment.Size = New System.Drawing.Size(177, 20)
        Me.SLEVendorPayment.TabIndex = 8918
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn29})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID Comp Contact"
        Me.GridColumn1.FieldName = "id_comp_contact"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Vendor"
        Me.GridColumn29.FieldName = "comp_name"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(221, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl1.TabIndex = 8917
        Me.LabelControl1.Text = "Vendor"
        '
        'BViewPayment
        '
        Me.BViewPayment.Location = New System.Drawing.Point(444, 11)
        Me.BViewPayment.Name = "BViewPayment"
        Me.BViewPayment.Size = New System.Drawing.Size(60, 23)
        Me.BViewPayment.TabIndex = 8916
        Me.BViewPayment.Text = "view"
        '
        'XTPExpense
        '
        Me.XTPExpense.Controls.Add(Me.GCExpense)
        Me.XTPExpense.Controls.Add(Me.PanelControl4)
        Me.XTPExpense.Controls.Add(Me.PanelControl3)
        Me.XTPExpense.Name = "XTPExpense"
        Me.XTPExpense.Size = New System.Drawing.Size(1091, 485)
        Me.XTPExpense.Text = "Expense List"
        '
        'GCExpense
        '
        Me.GCExpense.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCExpense.Location = New System.Drawing.Point(0, 42)
        Me.GCExpense.MainView = Me.GVExpense
        Me.GCExpense.Name = "GCExpense"
        Me.GCExpense.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.CESelectExpense})
        Me.GCExpense.Size = New System.Drawing.Size(1091, 400)
        Me.GCExpense.TabIndex = 20
        Me.GCExpense.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVExpense})
        '
        'GVExpense
        '
        Me.GVExpense.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumnNumber, Me.GridColumn39, Me.GridColumnCreatedByName, Me.GridColumnReortStt, Me.GridColumnPaidStt, Me.GridColumnBal, Me.GridColumntotalExpense, Me.GridColumnIdComp, Me.GridColumnBeneficiary, Me.GridColumnSelectExpense, Me.GridColumnTotalExpenseDP, Me.GridColumnTotalExpensePaid, Me.GridColumnPaymentPendingExpense, Me.GridColumnDueDateExpense, Me.GridColumnDiffExpense, Me.GridColumnDueDays, Me.GridColumnIsOpenExpense})
        Me.GVExpense.GridControl = Me.GCExpense
        Me.GVExpense.Name = "GVExpense"
        Me.GVExpense.OptionsFind.AlwaysVisible = True
        Me.GVExpense.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GVExpense.OptionsView.ColumnAutoWidth = False
        Me.GVExpense.OptionsView.ShowFooter = True
        Me.GVExpense.OptionsView.ShowGroupPanel = False
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_item_expense"
        Me.GridColumnId.Name = "GridColumnId"
        Me.GridColumnId.OptionsColumn.AllowEdit = False
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.OptionsColumn.AllowEdit = False
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 2
        '
        'GridColumn39
        '
        Me.GridColumn39.Caption = "Created Date"
        Me.GridColumn39.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn39.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn39.FieldName = "created_date"
        Me.GridColumn39.Name = "GridColumn39"
        Me.GridColumn39.OptionsColumn.AllowEdit = False
        Me.GridColumn39.Visible = True
        Me.GridColumn39.VisibleIndex = 4
        '
        'GridColumnCreatedByName
        '
        Me.GridColumnCreatedByName.Caption = "Created by"
        Me.GridColumnCreatedByName.FieldName = "created_by_name"
        Me.GridColumnCreatedByName.Name = "GridColumnCreatedByName"
        Me.GridColumnCreatedByName.OptionsColumn.AllowEdit = False
        '
        'GridColumnReortStt
        '
        Me.GridColumnReortStt.Caption = "Approval Status"
        Me.GridColumnReortStt.FieldName = "report_status"
        Me.GridColumnReortStt.Name = "GridColumnReortStt"
        Me.GridColumnReortStt.OptionsColumn.AllowEdit = False
        '
        'GridColumnPaidStt
        '
        Me.GridColumnPaidStt.Caption = "Payment Status"
        Me.GridColumnPaidStt.FieldName = "paid_status"
        Me.GridColumnPaidStt.Name = "GridColumnPaidStt"
        Me.GridColumnPaidStt.OptionsColumn.AllowEdit = False
        Me.GridColumnPaidStt.Visible = True
        Me.GridColumnPaidStt.VisibleIndex = 6
        '
        'GridColumnBal
        '
        Me.GridColumnBal.Caption = "Balance Due"
        Me.GridColumnBal.DisplayFormat.FormatString = "N2"
        Me.GridColumnBal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBal.FieldName = "balance"
        Me.GridColumnBal.Name = "GridColumnBal"
        Me.GridColumnBal.OptionsColumn.AllowEdit = False
        Me.GridColumnBal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "balance", "{0:N2}")})
        Me.GridColumnBal.Visible = True
        Me.GridColumnBal.VisibleIndex = 7
        '
        'GridColumntotalExpense
        '
        Me.GridColumntotalExpense.Caption = "Total Expense"
        Me.GridColumntotalExpense.DisplayFormat.FormatString = "N2"
        Me.GridColumntotalExpense.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotalExpense.FieldName = "total"
        Me.GridColumntotalExpense.Name = "GridColumntotalExpense"
        Me.GridColumntotalExpense.OptionsColumn.AllowEdit = False
        Me.GridColumntotalExpense.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.GridColumntotalExpense.Visible = True
        Me.GridColumntotalExpense.VisibleIndex = 8
        '
        'GridColumnIdComp
        '
        Me.GridColumnIdComp.Caption = "Id Comp"
        Me.GridColumnIdComp.FieldName = "id_comp"
        Me.GridColumnIdComp.Name = "GridColumnIdComp"
        Me.GridColumnIdComp.OptionsColumn.AllowEdit = False
        '
        'GridColumnBeneficiary
        '
        Me.GridColumnBeneficiary.Caption = "Vendor"
        Me.GridColumnBeneficiary.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnBeneficiary.FieldName = "comp"
        Me.GridColumnBeneficiary.Name = "GridColumnBeneficiary"
        Me.GridColumnBeneficiary.OptionsColumn.AllowEdit = False
        Me.GridColumnBeneficiary.Visible = True
        Me.GridColumnBeneficiary.VisibleIndex = 1
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "-"
        '
        'GridColumnSelectExpense
        '
        Me.GridColumnSelectExpense.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSelectExpense.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelectExpense.Caption = "*"
        Me.GridColumnSelectExpense.ColumnEdit = Me.CESelectExpense
        Me.GridColumnSelectExpense.FieldName = "is_select"
        Me.GridColumnSelectExpense.Name = "GridColumnSelectExpense"
        Me.GridColumnSelectExpense.Visible = True
        Me.GridColumnSelectExpense.VisibleIndex = 0
        '
        'CESelectExpense
        '
        Me.CESelectExpense.AutoHeight = False
        Me.CESelectExpense.Name = "CESelectExpense"
        Me.CESelectExpense.ValueChecked = "Yes"
        Me.CESelectExpense.ValueUnchecked = "No"
        '
        'GridColumnTotalExpenseDP
        '
        Me.GridColumnTotalExpenseDP.Caption = "Total DP"
        Me.GridColumnTotalExpenseDP.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotalExpenseDP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotalExpenseDP.FieldName = "total_dp"
        Me.GridColumnTotalExpenseDP.Name = "GridColumnTotalExpenseDP"
        Me.GridColumnTotalExpenseDP.OptionsColumn.AllowEdit = False
        Me.GridColumnTotalExpenseDP.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_dp", "{0:N2}")})
        Me.GridColumnTotalExpenseDP.Visible = True
        Me.GridColumnTotalExpenseDP.VisibleIndex = 9
        '
        'GridColumnTotalExpensePaid
        '
        Me.GridColumnTotalExpensePaid.Caption = "Total Paid"
        Me.GridColumnTotalExpensePaid.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotalExpensePaid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotalExpensePaid.FieldName = "total_paid"
        Me.GridColumnTotalExpensePaid.Name = "GridColumnTotalExpensePaid"
        Me.GridColumnTotalExpensePaid.OptionsColumn.AllowEdit = False
        Me.GridColumnTotalExpensePaid.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_paid", "{0:N2}")})
        Me.GridColumnTotalExpensePaid.Visible = True
        Me.GridColumnTotalExpensePaid.VisibleIndex = 10
        '
        'GridColumnPaymentPendingExpense
        '
        Me.GridColumnPaymentPendingExpense.Caption = "Payment Pending"
        Me.GridColumnPaymentPendingExpense.DisplayFormat.FormatString = "N0"
        Me.GridColumnPaymentPendingExpense.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPaymentPendingExpense.FieldName = "total_pending"
        Me.GridColumnPaymentPendingExpense.Name = "GridColumnPaymentPendingExpense"
        Me.GridColumnPaymentPendingExpense.OptionsColumn.AllowEdit = False
        Me.GridColumnPaymentPendingExpense.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_pending", "{0:N0}")})
        Me.GridColumnPaymentPendingExpense.Visible = True
        Me.GridColumnPaymentPendingExpense.VisibleIndex = 3
        Me.GridColumnPaymentPendingExpense.Width = 101
        '
        'GridColumnDueDateExpense
        '
        Me.GridColumnDueDateExpense.Caption = "Due Date"
        Me.GridColumnDueDateExpense.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnDueDateExpense.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDueDateExpense.FieldName = "due_date"
        Me.GridColumnDueDateExpense.Name = "GridColumnDueDateExpense"
        Me.GridColumnDueDateExpense.Visible = True
        Me.GridColumnDueDateExpense.VisibleIndex = 5
        '
        'GridColumnDiffExpense
        '
        Me.GridColumnDiffExpense.Caption = "Diff"
        Me.GridColumnDiffExpense.DisplayFormat.FormatString = "N2"
        Me.GridColumnDiffExpense.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDiffExpense.FieldName = "diff"
        Me.GridColumnDiffExpense.Name = "GridColumnDiffExpense"
        Me.GridColumnDiffExpense.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff", "{0:N2}")})
        Me.GridColumnDiffExpense.UnboundExpression = "[total] - [total_paid]"
        Me.GridColumnDiffExpense.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnDiffExpense.Visible = True
        Me.GridColumnDiffExpense.VisibleIndex = 11
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.PanelControl5)
        Me.PanelControl4.Controls.Add(Me.BCreateExpense)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl4.Location = New System.Drawing.Point(0, 442)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(1091, 43)
        Me.PanelControl4.TabIndex = 21
        '
        'PanelControl5
        '
        Me.PanelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl5.Controls.Add(Me.SLEPayTypeExpense)
        Me.PanelControl5.Controls.Add(Me.LabelControl7)
        Me.PanelControl5.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl5.Location = New System.Drawing.Point(741, 2)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(210, 39)
        Me.PanelControl5.TabIndex = 8918
        '
        'SLEPayTypeExpense
        '
        Me.SLEPayTypeExpense.Location = New System.Drawing.Point(76, 10)
        Me.SLEPayTypeExpense.Name = "SLEPayTypeExpense"
        Me.SLEPayTypeExpense.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEPayTypeExpense.Properties.Appearance.Options.UseFont = True
        Me.SLEPayTypeExpense.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEPayTypeExpense.Properties.View = Me.GridView7
        Me.SLEPayTypeExpense.Size = New System.Drawing.Size(123, 20)
        Me.SLEPayTypeExpense.TabIndex = 8917
        '
        'GridView7
        '
        Me.GridView7.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn35, Me.GridColumn36})
        Me.GridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView7.Name = "GridView7"
        Me.GridView7.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView7.OptionsView.ShowGroupPanel = False
        '
        'GridColumn35
        '
        Me.GridColumn35.Caption = "ID Payment Type"
        Me.GridColumn35.FieldName = "id_pay_type"
        Me.GridColumn35.Name = "GridColumn35"
        '
        'GridColumn36
        '
        Me.GridColumn36.Caption = "Type"
        Me.GridColumn36.FieldName = "pay_type"
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.Visible = True
        Me.GridColumn36.VisibleIndex = 0
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(8, 13)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl7.TabIndex = 8914
        Me.LabelControl7.Text = "Select Type"
        '
        'BCreateExpense
        '
        Me.BCreateExpense.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BCreateExpense.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BCreateExpense.Appearance.ForeColor = System.Drawing.Color.White
        Me.BCreateExpense.Appearance.Options.UseBackColor = True
        Me.BCreateExpense.Appearance.Options.UseFont = True
        Me.BCreateExpense.Appearance.Options.UseForeColor = True
        Me.BCreateExpense.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCreateExpense.Location = New System.Drawing.Point(951, 2)
        Me.BCreateExpense.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BCreateExpense.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BCreateExpense.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BCreateExpense.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BCreateExpense.Name = "BCreateExpense"
        Me.BCreateExpense.Size = New System.Drawing.Size(138, 39)
        Me.BCreateExpense.TabIndex = 19
        Me.BCreateExpense.Text = "Create Payment"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.SLEStatusPaymentExpense)
        Me.PanelControl3.Controls.Add(Me.LabelControl6)
        Me.PanelControl3.Controls.Add(Me.BtnViewExpense)
        Me.PanelControl3.Controls.Add(Me.SLEVendorExpense)
        Me.PanelControl3.Controls.Add(Me.LabelControl8)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(1091, 42)
        Me.PanelControl3.TabIndex = 3
        '
        'SLEStatusPaymentExpense
        '
        Me.SLEStatusPaymentExpense.Location = New System.Drawing.Point(322, 11)
        Me.SLEStatusPaymentExpense.Name = "SLEStatusPaymentExpense"
        Me.SLEStatusPaymentExpense.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStatusPaymentExpense.Properties.View = Me.GridView6
        Me.SLEStatusPaymentExpense.Size = New System.Drawing.Size(123, 20)
        Me.SLEStatusPaymentExpense.TabIndex = 8919
        '
        'GridView6
        '
        Me.GridView6.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn33, Me.GridColumn34})
        Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView6.Name = "GridView6"
        Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView6.OptionsView.ShowGroupPanel = False
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "ID Status payment"
        Me.GridColumn33.FieldName = "id_status_payment"
        Me.GridColumn33.Name = "GridColumn33"
        '
        'GridColumn34
        '
        Me.GridColumn34.Caption = "Status"
        Me.GridColumn34.FieldName = "status_payment"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.Visible = True
        Me.GridColumn34.VisibleIndex = 0
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(240, 14)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(76, 13)
        Me.LabelControl6.TabIndex = 8918
        Me.LabelControl6.Text = "Status Payment"
        '
        'BtnViewExpense
        '
        Me.BtnViewExpense.Location = New System.Drawing.Point(451, 9)
        Me.BtnViewExpense.Name = "BtnViewExpense"
        Me.BtnViewExpense.Size = New System.Drawing.Size(60, 23)
        Me.BtnViewExpense.TabIndex = 8913
        Me.BtnViewExpense.Text = "view"
        '
        'SLEVendorExpense
        '
        Me.SLEVendorExpense.Location = New System.Drawing.Point(57, 11)
        Me.SLEVendorExpense.Name = "SLEVendorExpense"
        Me.SLEVendorExpense.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEVendorExpense.Properties.View = Me.GridView8
        Me.SLEVendorExpense.Size = New System.Drawing.Size(177, 20)
        Me.SLEVendorExpense.TabIndex = 8912
        '
        'GridView8
        '
        Me.GridView8.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn37, Me.GridColumn38})
        Me.GridView8.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView8.Name = "GridView8"
        Me.GridView8.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView8.OptionsView.ShowGroupPanel = False
        '
        'GridColumn37
        '
        Me.GridColumn37.Caption = "ID Comp Contact"
        Me.GridColumn37.FieldName = "id_comp_contact"
        Me.GridColumn37.Name = "GridColumn37"
        '
        'GridColumn38
        '
        Me.GridColumn38.Caption = "Vendor"
        Me.GridColumn38.FieldName = "comp_name"
        Me.GridColumn38.Name = "GridColumn38"
        Me.GridColumn38.Visible = True
        Me.GridColumn38.VisibleIndex = 0
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(17, 14)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl8.TabIndex = 8911
        Me.LabelControl8.Text = "Vendor"
        '
        'GridColumnDueDays
        '
        Me.GridColumnDueDays.Caption = "Diif Due Date"
        Me.GridColumnDueDays.FieldName = "due_days"
        Me.GridColumnDueDays.Name = "GridColumnDueDays"
        '
        'GridColumnIsOpenExpense
        '
        Me.GridColumnIsOpenExpense.Caption = "Is Open"
        Me.GridColumnIsOpenExpense.FieldName = "is_open"
        Me.GridColumnIsOpenExpense.Name = "GridColumnIsOpenExpense"
        '
        'FormBankWithdrawal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1097, 513)
        Me.Controls.Add(Me.XTCPO)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBankWithdrawal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Bank Withdrawal"
        CType(Me.XTCPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPO.ResumeLayout(False)
        Me.XTPPO.ResumeLayout(False)
        CType(Me.GCPOList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPOList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICECheckReceive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEStatusPayment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEPayType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPPayment.ResumeLayout(False)
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.SLEPayTypePayment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEVendorPayment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPExpense.ResumeLayout(False)
        CType(Me.GCExpense, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVExpense, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CESelectExpense, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl5.ResumeLayout(False)
        Me.PanelControl5.PerformLayout()
        CType(Me.SLEPayTypeExpense.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.SLEStatusPaymentExpense.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEVendorExpense.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCPO As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPO As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPPayment As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents BCreatePO As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEVendor As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BViewPayment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCPOList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPOList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICECheckReceive As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnIdRec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOrderNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastUpdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUpdatedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVendor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEPayType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEVendorPayment As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEPayTypePayment As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEStatusPayment As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPExpense As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents BCreateExpense As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEStatusPaymentExpense As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEPayTypeExpense As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnViewExpense As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEVendorExpense As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView8 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn38 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCExpense As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVExpense As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedByName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReortStt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPaidStt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotalExpense As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBeneficiary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumnSelectExpense As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumnTotalExpenseDP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotalExpensePaid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl5 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CESelectExpense As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnPaymentPendingExpense As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDueDateExpense As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDiffExpense As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDueDays As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsOpenExpense As DevExpress.XtraGrid.Columns.GridColumn
End Class
