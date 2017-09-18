<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesReturn
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
        Me.components = New System.ComponentModel.Container()
        Me.XTCSalesReturn = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPSalesReturnList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCSalesReturn = New DevExpress.XtraGrid.GridControl()
        Me.GVSalesReturn = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnSalesReturnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReturnOrderNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStore = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompNameTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStoreRetNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUpdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotalNonStock = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCFilter = New DevExpress.XtraEditors.GroupControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BHide = New DevExpress.XtraEditors.SimpleButton()
        Me.BExpand = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPSalesReturnWaiting = New DevExpress.XtraTab.XtraTabPage()
        Me.SCCWaitingReturn = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControlSalesReturnOrder = New DevExpress.XtraEditors.GroupControl()
        Me.GCSalesReturnOrder = New DevExpress.XtraGrid.GridControl()
        Me.GVSalesReturnOrder = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnSalesTargetNumb = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSalesTargetDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEstDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDSalesTargetNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTimeRemaining = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReturnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOrderQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCurrDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrepareStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSvcLevel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControlSalesReturnOrderDetail = New DevExpress.XtraEditors.GroupControl()
        Me.GCSalesReturnOrderDetail = New DevExpress.XtraGrid.GridControl()
        Me.GVSalesReturnOrderDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSalesTarget = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumnQtyReturn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReturnCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSample = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSalesOrderDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProductName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdReturnCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDesignPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemaining = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrintDetail = New DevExpress.XtraEditors.SimpleButton()
        Me.BAccept = New DevExpress.XtraEditors.SimpleButton()
        Me.ViewMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMPrePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.SMPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridColumnRty = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCSalesReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCSalesReturn.SuspendLayout()
        Me.XTPSalesReturnList.SuspendLayout()
        CType(Me.GCSalesReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalesReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCFilter.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPSalesReturnWaiting.SuspendLayout()
        CType(Me.SCCWaitingReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCCWaitingReturn.SuspendLayout()
        CType(Me.GroupControlSalesReturnOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSalesReturnOrder.SuspendLayout()
        CType(Me.GCSalesReturnOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalesReturnOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlSalesReturnOrderDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSalesReturnOrderDetail.SuspendLayout()
        CType(Me.GCSalesReturnOrderDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalesReturnOrderDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.ViewMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCSalesReturn
        '
        Me.XTCSalesReturn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCSalesReturn.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCSalesReturn.Location = New System.Drawing.Point(0, 0)
        Me.XTCSalesReturn.Name = "XTCSalesReturn"
        Me.XTCSalesReturn.SelectedTabPage = Me.XTPSalesReturnList
        Me.XTCSalesReturn.Size = New System.Drawing.Size(735, 505)
        Me.XTCSalesReturn.TabIndex = 0
        Me.XTCSalesReturn.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPSalesReturnList, Me.XTPSalesReturnWaiting})
        '
        'XTPSalesReturnList
        '
        Me.XTPSalesReturnList.Controls.Add(Me.GCSalesReturn)
        Me.XTPSalesReturnList.Controls.Add(Me.GCFilter)
        Me.XTPSalesReturnList.Name = "XTPSalesReturnList"
        Me.XTPSalesReturnList.Size = New System.Drawing.Size(729, 477)
        Me.XTPSalesReturnList.Text = "List Return"
        '
        'GCSalesReturn
        '
        Me.GCSalesReturn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesReturn.Location = New System.Drawing.Point(0, 39)
        Me.GCSalesReturn.MainView = Me.GVSalesReturn
        Me.GCSalesReturn.Name = "GCSalesReturn"
        Me.GCSalesReturn.Size = New System.Drawing.Size(729, 438)
        Me.GCSalesReturn.TabIndex = 0
        Me.GCSalesReturn.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalesReturn})
        '
        'GVSalesReturn
        '
        Me.GVSalesReturn.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnSalesReturnNumber, Me.GridColumnReturnOrderNumber, Me.GridColumnStore, Me.GridColumnCompNameTo, Me.GridColumnStoreRetNumber, Me.GridColumnCreatedDate, Me.GridColumnStatus, Me.GridColumnLastUpdate, Me.GridColumnLastUser, Me.GridColumnTotal, Me.GridColumnTotalNonStock, Me.GridColumnRty})
        Me.GVSalesReturn.GridControl = Me.GCSalesReturn
        Me.GVSalesReturn.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", Me.GridColumnTotal, "{0:n0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_nsi", Me.GridColumnTotalNonStock, "{0:n0}")})
        Me.GVSalesReturn.Name = "GVSalesReturn"
        Me.GVSalesReturn.OptionsBehavior.ReadOnly = True
        Me.GVSalesReturn.OptionsView.ShowFooter = True
        Me.GVSalesReturn.OptionsView.ShowGroupPanel = False
        '
        'GridColumnSalesReturnNumber
        '
        Me.GridColumnSalesReturnNumber.Caption = "Number"
        Me.GridColumnSalesReturnNumber.FieldName = "sales_return_number"
        Me.GridColumnSalesReturnNumber.Name = "GridColumnSalesReturnNumber"
        Me.GridColumnSalesReturnNumber.Visible = True
        Me.GridColumnSalesReturnNumber.VisibleIndex = 0
        Me.GridColumnSalesReturnNumber.Width = 93
        '
        'GridColumnReturnOrderNumber
        '
        Me.GridColumnReturnOrderNumber.Caption = "Return Order"
        Me.GridColumnReturnOrderNumber.FieldName = "sales_return_order_number"
        Me.GridColumnReturnOrderNumber.Name = "GridColumnReturnOrderNumber"
        Me.GridColumnReturnOrderNumber.Visible = True
        Me.GridColumnReturnOrderNumber.VisibleIndex = 2
        Me.GridColumnReturnOrderNumber.Width = 92
        '
        'GridColumnStore
        '
        Me.GridColumnStore.Caption = "From"
        Me.GridColumnStore.FieldName = "store_name_from"
        Me.GridColumnStore.Name = "GridColumnStore"
        Me.GridColumnStore.Visible = True
        Me.GridColumnStore.VisibleIndex = 3
        Me.GridColumnStore.Width = 92
        '
        'GridColumnCompNameTo
        '
        Me.GridColumnCompNameTo.Caption = "To"
        Me.GridColumnCompNameTo.FieldName = "comp_name_to"
        Me.GridColumnCompNameTo.Name = "GridColumnCompNameTo"
        Me.GridColumnCompNameTo.Visible = True
        Me.GridColumnCompNameTo.VisibleIndex = 4
        Me.GridColumnCompNameTo.Width = 92
        '
        'GridColumnStoreRetNumber
        '
        Me.GridColumnStoreRetNumber.Caption = "Store Return Number"
        Me.GridColumnStoreRetNumber.FieldName = "sales_return_store_number"
        Me.GridColumnStoreRetNumber.Name = "GridColumnStoreRetNumber"
        Me.GridColumnStoreRetNumber.Visible = True
        Me.GridColumnStoreRetNumber.VisibleIndex = 5
        Me.GridColumnStoreRetNumber.Width = 92
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "sales_return_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 8
        Me.GridColumnCreatedDate.Width = 94
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 11
        Me.GridColumnStatus.Width = 110
        '
        'GridColumnLastUpdate
        '
        Me.GridColumnLastUpdate.Caption = "Last Updated"
        Me.GridColumnLastUpdate.DisplayFormat.FormatString = "dd MMMM yyyy'/'hh:mm tt"
        Me.GridColumnLastUpdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnLastUpdate.FieldName = "last_update"
        Me.GridColumnLastUpdate.Name = "GridColumnLastUpdate"
        Me.GridColumnLastUpdate.Visible = True
        Me.GridColumnLastUpdate.VisibleIndex = 9
        Me.GridColumnLastUpdate.Width = 94
        '
        'GridColumnLastUser
        '
        Me.GridColumnLastUser.Caption = "Updated By"
        Me.GridColumnLastUser.FieldName = "last_user"
        Me.GridColumnLastUser.Name = "GridColumnLastUser"
        Me.GridColumnLastUser.Visible = True
        Me.GridColumnLastUser.VisibleIndex = 10
        Me.GridColumnLastUser.Width = 94
        '
        'GridColumnTotal
        '
        Me.GridColumnTotal.Caption = "Total"
        Me.GridColumnTotal.DisplayFormat.FormatString = "{0:n0}"
        Me.GridColumnTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotal.FieldName = "total"
        Me.GridColumnTotal.Name = "GridColumnTotal"
        Me.GridColumnTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:n0}")})
        Me.GridColumnTotal.Visible = True
        Me.GridColumnTotal.VisibleIndex = 6
        Me.GridColumnTotal.Width = 67
        '
        'GridColumnTotalNonStock
        '
        Me.GridColumnTotalNonStock.Caption = "Total Non Stock"
        Me.GridColumnTotalNonStock.DisplayFormat.FormatString = "N0"
        Me.GridColumnTotalNonStock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotalNonStock.FieldName = "total_nsi"
        Me.GridColumnTotalNonStock.Name = "GridColumnTotalNonStock"
        Me.GridColumnTotalNonStock.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_nsi", "{0:N0}")})
        Me.GridColumnTotalNonStock.Visible = True
        Me.GridColumnTotalNonStock.VisibleIndex = 7
        Me.GridColumnTotalNonStock.Width = 79
        '
        'GCFilter
        '
        Me.GCFilter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCFilter.Controls.Add(Me.BtnView)
        Me.GCFilter.Controls.Add(Me.BHide)
        Me.GCFilter.Controls.Add(Me.BExpand)
        Me.GCFilter.Controls.Add(Me.DEUntil)
        Me.GCFilter.Controls.Add(Me.DEFrom)
        Me.GCFilter.Controls.Add(Me.LabelControl2)
        Me.GCFilter.Controls.Add(Me.LabelControl3)
        Me.GCFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCFilter.Location = New System.Drawing.Point(0, 0)
        Me.GCFilter.Name = "GCFilter"
        Me.GCFilter.Size = New System.Drawing.Size(729, 39)
        Me.GCFilter.TabIndex = 5
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(317, 9)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 20)
        Me.BtnView.TabIndex = 8896
        Me.BtnView.Text = "View"
        '
        'BHide
        '
        Me.BHide.ImageIndex = 9
        Me.BHide.Location = New System.Drawing.Point(938, 14)
        Me.BHide.Name = "BHide"
        Me.BHide.Size = New System.Drawing.Size(104, 20)
        Me.BHide.TabIndex = 8898
        Me.BHide.Text = "Hide All Detail"
        Me.BHide.Visible = False
        '
        'BExpand
        '
        Me.BExpand.ImageIndex = 8
        Me.BExpand.Location = New System.Drawing.Point(835, 14)
        Me.BExpand.Name = "BExpand"
        Me.BExpand.Size = New System.Drawing.Size(99, 20)
        Me.BExpand.TabIndex = 8897
        Me.BExpand.Text = "Expand All Detail"
        Me.BExpand.Visible = False
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(202, 9)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(111, 20)
        Me.DEUntil.TabIndex = 8895
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(58, 9)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEFrom.TabIndex = 8894
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(175, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8893
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(28, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8892
        Me.LabelControl3.Text = "From"
        '
        'XTPSalesReturnWaiting
        '
        Me.XTPSalesReturnWaiting.Controls.Add(Me.SCCWaitingReturn)
        Me.XTPSalesReturnWaiting.Name = "XTPSalesReturnWaiting"
        Me.XTPSalesReturnWaiting.Size = New System.Drawing.Size(729, 477)
        Me.XTPSalesReturnWaiting.Text = "Waiting to Return"
        '
        'SCCWaitingReturn
        '
        Me.SCCWaitingReturn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCCWaitingReturn.Horizontal = False
        Me.SCCWaitingReturn.Location = New System.Drawing.Point(0, 0)
        Me.SCCWaitingReturn.Name = "SCCWaitingReturn"
        Me.SCCWaitingReturn.Panel1.Controls.Add(Me.GroupControlSalesReturnOrder)
        Me.SCCWaitingReturn.Panel1.Text = "Panel1"
        Me.SCCWaitingReturn.Panel2.Controls.Add(Me.GroupControlSalesReturnOrderDetail)
        Me.SCCWaitingReturn.Panel2.Text = "Panel2"
        Me.SCCWaitingReturn.Size = New System.Drawing.Size(729, 477)
        Me.SCCWaitingReturn.SplitterPosition = 253
        Me.SCCWaitingReturn.TabIndex = 0
        Me.SCCWaitingReturn.Text = "SplitContainerControl1"
        '
        'GroupControlSalesReturnOrder
        '
        Me.GroupControlSalesReturnOrder.Controls.Add(Me.GCSalesReturnOrder)
        Me.GroupControlSalesReturnOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlSalesReturnOrder.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlSalesReturnOrder.Name = "GroupControlSalesReturnOrder"
        Me.GroupControlSalesReturnOrder.Size = New System.Drawing.Size(729, 253)
        Me.GroupControlSalesReturnOrder.TabIndex = 0
        Me.GroupControlSalesReturnOrder.Text = "Return Order"
        '
        'GCSalesReturnOrder
        '
        Me.GCSalesReturnOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesReturnOrder.Location = New System.Drawing.Point(2, 20)
        Me.GCSalesReturnOrder.MainView = Me.GVSalesReturnOrder
        Me.GCSalesReturnOrder.Name = "GCSalesReturnOrder"
        Me.GCSalesReturnOrder.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemProgressBar1})
        Me.GCSalesReturnOrder.Size = New System.Drawing.Size(725, 231)
        Me.GCSalesReturnOrder.TabIndex = 3
        Me.GCSalesReturnOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalesReturnOrder, Me.GridView2})
        '
        'GVSalesReturnOrder
        '
        Me.GVSalesReturnOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnSalesTargetNumb, Me.GridColumnTo, Me.GridColumnSalesTargetDate, Me.GridColumnEstDate, Me.GridColumnDSalesTargetNote, Me.GridColumn1, Me.GridColumnTimeRemaining, Me.GridColumnReturnQty, Me.GridColumnOrderQty, Me.GridColumnReportStatus, Me.GridColumnCurrDate, Me.GridColumnPrepareStatus, Me.GridColumnSvcLevel})
        Me.GVSalesReturnOrder.GridControl = Me.GCSalesReturnOrder
        Me.GVSalesReturnOrder.Name = "GVSalesReturnOrder"
        Me.GVSalesReturnOrder.OptionsBehavior.ReadOnly = True
        Me.GVSalesReturnOrder.OptionsView.ShowGroupPanel = False
        '
        'GridColumnSalesTargetNumb
        '
        Me.GridColumnSalesTargetNumb.Caption = "Number"
        Me.GridColumnSalesTargetNumb.FieldName = "sales_return_order_number"
        Me.GridColumnSalesTargetNumb.Name = "GridColumnSalesTargetNumb"
        Me.GridColumnSalesTargetNumb.Visible = True
        Me.GridColumnSalesTargetNumb.VisibleIndex = 0
        Me.GridColumnSalesTargetNumb.Width = 83
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "Store/Destination"
        Me.GridColumnTo.FieldName = "store_name_to"
        Me.GridColumnTo.Name = "GridColumnTo"
        Me.GridColumnTo.Visible = True
        Me.GridColumnTo.VisibleIndex = 1
        '
        'GridColumnSalesTargetDate
        '
        Me.GridColumnSalesTargetDate.Caption = "Created Date"
        Me.GridColumnSalesTargetDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnSalesTargetDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnSalesTargetDate.FieldName = "sales_return_order_date"
        Me.GridColumnSalesTargetDate.Name = "GridColumnSalesTargetDate"
        '
        'GridColumnEstDate
        '
        Me.GridColumnEstDate.Caption = "Estimate Return"
        Me.GridColumnEstDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnEstDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnEstDate.FieldName = "sales_return_order_est_date"
        Me.GridColumnEstDate.Name = "GridColumnEstDate"
        '
        'GridColumnDSalesTargetNote
        '
        Me.GridColumnDSalesTargetNote.Caption = "Note"
        Me.GridColumnDSalesTargetNote.FieldName = "sales_return_order_note"
        Me.GridColumnDSalesTargetNote.Name = "GridColumnDSalesTargetNote"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Created Return"
        Me.GridColumn1.FieldName = "created_return"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 4
        '
        'GridColumnTimeRemaining
        '
        Me.GridColumnTimeRemaining.Caption = "Time Remaining"
        Me.GridColumnTimeRemaining.FieldName = "time_remaining"
        Me.GridColumnTimeRemaining.Name = "GridColumnTimeRemaining"
        '
        'GridColumnReturnQty
        '
        Me.GridColumnReturnQty.Caption = "Total Return Qty"
        Me.GridColumnReturnQty.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnReturnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnReturnQty.FieldName = "return_qty"
        Me.GridColumnReturnQty.Name = "GridColumnReturnQty"
        Me.GridColumnReturnQty.Visible = True
        Me.GridColumnReturnQty.VisibleIndex = 3
        '
        'GridColumnOrderQty
        '
        Me.GridColumnOrderQty.Caption = "Total Return Order Qty"
        Me.GridColumnOrderQty.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnOrderQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOrderQty.FieldName = "order_qty"
        Me.GridColumnOrderQty.Name = "GridColumnOrderQty"
        Me.GridColumnOrderQty.Visible = True
        Me.GridColumnOrderQty.VisibleIndex = 2
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        '
        'GridColumnCurrDate
        '
        Me.GridColumnCurrDate.Caption = "Current Date"
        Me.GridColumnCurrDate.FieldName = "sales_return_order_date_current"
        Me.GridColumnCurrDate.Name = "GridColumnCurrDate"
        '
        'GridColumnPrepareStatus
        '
        Me.GridColumnPrepareStatus.Caption = "Status"
        Me.GridColumnPrepareStatus.FieldName = "prepare_status"
        Me.GridColumnPrepareStatus.Name = "GridColumnPrepareStatus"
        '
        'GridColumnSvcLevel
        '
        Me.GridColumnSvcLevel.Caption = "Service Level"
        Me.GridColumnSvcLevel.ColumnEdit = Me.RepositoryItemProgressBar1
        Me.GridColumnSvcLevel.FieldName = "svc_level"
        Me.GridColumnSvcLevel.Name = "GridColumnSvcLevel"
        '
        'RepositoryItemProgressBar1
        '
        Me.RepositoryItemProgressBar1.Name = "RepositoryItemProgressBar1"
        Me.RepositoryItemProgressBar1.ReadOnly = True
        Me.RepositoryItemProgressBar1.ShowTitle = True
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCSalesReturnOrder
        Me.GridView2.Name = "GridView2"
        '
        'GroupControlSalesReturnOrderDetail
        '
        Me.GroupControlSalesReturnOrderDetail.Controls.Add(Me.GCSalesReturnOrderDetail)
        Me.GroupControlSalesReturnOrderDetail.Controls.Add(Me.PanelControl1)
        Me.GroupControlSalesReturnOrderDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlSalesReturnOrderDetail.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlSalesReturnOrderDetail.Name = "GroupControlSalesReturnOrderDetail"
        Me.GroupControlSalesReturnOrderDetail.Size = New System.Drawing.Size(729, 219)
        Me.GroupControlSalesReturnOrderDetail.TabIndex = 0
        Me.GroupControlSalesReturnOrderDetail.Text = "Item Detail"
        '
        'GCSalesReturnOrderDetail
        '
        Me.GCSalesReturnOrderDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesReturnOrderDetail.Location = New System.Drawing.Point(2, 52)
        Me.GCSalesReturnOrderDetail.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCSalesReturnOrderDetail.MainView = Me.GVSalesReturnOrderDetail
        Me.GCSalesReturnOrderDetail.Name = "GCSalesReturnOrderDetail"
        Me.GCSalesReturnOrderDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCSalesReturnOrderDetail.Size = New System.Drawing.Size(725, 165)
        Me.GCSalesReturnOrderDetail.TabIndex = 3
        Me.GCSalesReturnOrderDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalesReturnOrderDetail})
        '
        'GVSalesReturnOrderDetail
        '
        Me.GVSalesReturnOrderDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnIdSalesTarget, Me.GridColumnCode, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnUOM, Me.GridColumnQty, Me.GridColumnQtyReturn, Me.GridColumnPrice, Me.GridColumnAmount, Me.GridColumnRemark, Me.GridColumnReturnCategory, Me.GridColumnIdDesign, Me.GridColumnIdProduct, Me.GridColumnIdSample, Me.GridColumnIdSalesOrderDet, Me.GridColumnProductName, Me.GridColumnIdReturnCat, Me.GridColumnIdDesignPrice, Me.GridColumnPriceType, Me.GridColumn2, Me.GridColumnRemaining})
        Me.GVSalesReturnOrderDetail.CustomizationFormBounds = New System.Drawing.Rectangle(739, 187, 216, 178)
        Me.GVSalesReturnOrderDetail.GridControl = Me.GCSalesReturnOrderDetail
        Me.GVSalesReturnOrderDetail.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_return_order_det_qty", Me.GridColumnQty, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_return_det_qty", Me.GridColumnQtyReturn, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", Me.GridColumnAmount, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "remaining", Me.GridColumnRemaining, "{0:N0}")})
        Me.GVSalesReturnOrderDetail.Name = "GVSalesReturnOrderDetail"
        Me.GVSalesReturnOrderDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVSalesReturnOrderDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVSalesReturnOrderDetail.OptionsBehavior.ReadOnly = True
        Me.GVSalesReturnOrderDetail.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVSalesReturnOrderDetail.OptionsView.ShowFooter = True
        Me.GVSalesReturnOrderDetail.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 41
        '
        'GridColumnIdSalesTarget
        '
        Me.GridColumnIdSalesTarget.Caption = "ID Sales Target"
        Me.GridColumnIdSalesTarget.FieldName = "id_sales_return_order"
        Me.GridColumnIdSalesTarget.Name = "GridColumnIdSalesTarget"
        Me.GridColumnIdSalesTarget.OptionsColumn.AllowEdit = False
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.AllowEdit = False
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 48
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.FieldNameSortGroup = "id_design"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 2
        Me.GridColumnName.Width = 103
        '
        'GridColumnSize
        '
        Me.GridColumnSize.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 3
        Me.GridColumnSize.Width = 38
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.OptionsColumn.AllowEdit = False
        Me.GridColumnUOM.Width = 71
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Ordered Qty"
        Me.GridColumnQty.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "sales_return_order_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_return_order_det_qty", "{0:n0}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 4
        Me.GridColumnQty.Width = 65
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumnQtyReturn
        '
        Me.GridColumnQtyReturn.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyReturn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyReturn.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyReturn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyReturn.Caption = "Returned Qty"
        Me.GridColumnQtyReturn.DisplayFormat.FormatString = "N0"
        Me.GridColumnQtyReturn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyReturn.FieldName = "sales_return_det_qty_view"
        Me.GridColumnQtyReturn.Name = "GridColumnQtyReturn"
        Me.GridColumnQtyReturn.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_return_det_qty_view", "{0:n0}")})
        Me.GridColumnQtyReturn.Visible = True
        Me.GridColumnQtyReturn.VisibleIndex = 5
        Me.GridColumnQtyReturn.Width = 84
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 7
        Me.GridColumnPrice.Width = 73
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:n2}")})
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 8
        Me.GridColumnAmount.Width = 86
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "sales_return_order_det_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.Width = 134
        '
        'GridColumnReturnCategory
        '
        Me.GridColumnReturnCategory.Caption = "Return Category"
        Me.GridColumnReturnCategory.FieldName = "return_cat"
        Me.GridColumnReturnCategory.Name = "GridColumnReturnCategory"
        Me.GridColumnReturnCategory.Width = 74
        '
        'GridColumnIdDesign
        '
        Me.GridColumnIdDesign.Caption = "id design"
        Me.GridColumnIdDesign.FieldName = "id_design"
        Me.GridColumnIdDesign.Name = "GridColumnIdDesign"
        Me.GridColumnIdDesign.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdProduct
        '
        Me.GridColumnIdProduct.Caption = "Id Product"
        Me.GridColumnIdProduct.FieldName = "id_product"
        Me.GridColumnIdProduct.Name = "GridColumnIdProduct"
        Me.GridColumnIdProduct.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSample
        '
        Me.GridColumnIdSample.Caption = "Id Sample"
        Me.GridColumnIdSample.FieldName = "id_sample"
        Me.GridColumnIdSample.Name = "GridColumnIdSample"
        Me.GridColumnIdSample.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdSample.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSalesOrderDet
        '
        Me.GridColumnIdSalesOrderDet.Caption = "Id Sales Order Det"
        Me.GridColumnIdSalesOrderDet.FieldName = "id_sales_return_order_det"
        Me.GridColumnIdSalesOrderDet.Name = "GridColumnIdSalesOrderDet"
        Me.GridColumnIdSalesOrderDet.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdSalesOrderDet.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnProductName
        '
        Me.GridColumnProductName.Caption = "Product Name"
        Me.GridColumnProductName.FieldName = "product_name"
        Me.GridColumnProductName.Name = "GridColumnProductName"
        '
        'GridColumnIdReturnCat
        '
        Me.GridColumnIdReturnCat.Caption = "GridColumnIdReturnCat"
        Me.GridColumnIdReturnCat.FieldName = "id_return_cat"
        Me.GridColumnIdReturnCat.Name = "GridColumnIdReturnCat"
        '
        'GridColumnIdDesignPrice
        '
        Me.GridColumnIdDesignPrice.Caption = "Id Design Price"
        Me.GridColumnIdDesignPrice.FieldName = "id_design_price"
        Me.GridColumnIdDesignPrice.Name = "GridColumnIdDesignPrice"
        '
        'GridColumnPriceType
        '
        Me.GridColumnPriceType.Caption = "Price Type"
        Me.GridColumnPriceType.FieldName = "design_price_type"
        Me.GridColumnPriceType.Name = "GridColumnPriceType"
        Me.GridColumnPriceType.Width = 66
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.Caption = "SOH"
        Me.GridColumn2.DisplayFormat.FormatString = "N0"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "soh"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "soh", "{0:N0}")})
        '
        'GridColumnRemaining
        '
        Me.GridColumnRemaining.Caption = "Remaining"
        Me.GridColumnRemaining.DisplayFormat.FormatString = "{0:N0}"
        Me.GridColumnRemaining.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRemaining.FieldName = "remaining"
        Me.GridColumnRemaining.Name = "GridColumnRemaining"
        Me.GridColumnRemaining.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "remaining", "{0:N0}")})
        Me.GridColumnRemaining.UnboundExpression = "[sales_return_order_det_qty] - [sales_return_det_qty_view]"
        Me.GridColumnRemaining.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GridColumnRemaining.Visible = True
        Me.GridColumnRemaining.VisibleIndex = 6
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.BtnPrintDetail)
        Me.PanelControl1.Controls.Add(Me.BAccept)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(2, 20)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(725, 32)
        Me.PanelControl1.TabIndex = 140
        '
        'BtnPrintDetail
        '
        Me.BtnPrintDetail.Appearance.BackColor = System.Drawing.Color.Teal
        Me.BtnPrintDetail.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrintDetail.Appearance.Options.UseBackColor = True
        Me.BtnPrintDetail.Appearance.Options.UseFont = True
        Me.BtnPrintDetail.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrintDetail.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BtnPrintDetail.Location = New System.Drawing.Point(541, 0)
        Me.BtnPrintDetail.LookAndFeel.SkinName = "Metropolis"
        Me.BtnPrintDetail.Name = "BtnPrintDetail"
        Me.BtnPrintDetail.Size = New System.Drawing.Size(92, 32)
        Me.BtnPrintDetail.TabIndex = 140
        Me.BtnPrintDetail.Text = "Print Detail"
        Me.BtnPrintDetail.Visible = False
        '
        'BAccept
        '
        Me.BAccept.Appearance.BackColor = System.Drawing.SystemColors.Highlight
        Me.BAccept.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BAccept.Appearance.Options.UseBackColor = True
        Me.BAccept.Appearance.Options.UseFont = True
        Me.BAccept.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAccept.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BAccept.Location = New System.Drawing.Point(633, 0)
        Me.BAccept.LookAndFeel.SkinName = "Metropolis"
        Me.BAccept.Name = "BAccept"
        Me.BAccept.Size = New System.Drawing.Size(92, 32)
        Me.BAccept.TabIndex = 139
        Me.BAccept.Text = "View Detail"
        '
        'ViewMenu
        '
        Me.ViewMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMPrePrint, Me.SMPrint})
        Me.ViewMenu.Name = "ContextMenuStripYM"
        Me.ViewMenu.Size = New System.Drawing.Size(137, 48)
        '
        'SMPrePrint
        '
        Me.SMPrePrint.Name = "SMPrePrint"
        Me.SMPrePrint.Size = New System.Drawing.Size(136, 22)
        Me.SMPrePrint.Text = "Pre Printing"
        '
        'SMPrint
        '
        Me.SMPrint.Name = "SMPrint"
        Me.SMPrint.Size = New System.Drawing.Size(136, 22)
        Me.SMPrint.Text = "Print"
        '
        'GridColumnRty
        '
        Me.GridColumnRty.Caption = "Type"
        Me.GridColumnRty.FieldName = "ret_type"
        Me.GridColumnRty.Name = "GridColumnRty"
        Me.GridColumnRty.Visible = True
        Me.GridColumnRty.VisibleIndex = 1
        Me.GridColumnRty.Width = 79
        '
        'FormSalesReturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 505)
        Me.Controls.Add(Me.XTCSalesReturn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesReturn"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Return"
        CType(Me.XTCSalesReturn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCSalesReturn.ResumeLayout(False)
        Me.XTPSalesReturnList.ResumeLayout(False)
        CType(Me.GCSalesReturn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalesReturn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCFilter.ResumeLayout(False)
        Me.GCFilter.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPSalesReturnWaiting.ResumeLayout(False)
        CType(Me.SCCWaitingReturn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCCWaitingReturn.ResumeLayout(False)
        CType(Me.GroupControlSalesReturnOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSalesReturnOrder.ResumeLayout(False)
        CType(Me.GCSalesReturnOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalesReturnOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlSalesReturnOrderDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSalesReturnOrderDetail.ResumeLayout(False)
        CType(Me.GCSalesReturnOrderDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalesReturnOrderDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ViewMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCSalesReturn As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPSalesReturnList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPSalesReturnWaiting As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCSalesReturn As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSalesReturn As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnSalesReturnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStore As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompNameTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStoreRetNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReturnOrderNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SCCWaitingReturn As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlSalesReturnOrder As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlSalesReturnOrderDetail As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCSalesReturnOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSalesReturnOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnSalesTargetNumb As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSalesTargetDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEstDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDSalesTargetNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCSalesReturnOrderDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSalesReturnOrderDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSalesTarget As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReturnCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSalesOrderDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProductName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReturnCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDesignPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyReturn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTimeRemaining As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReturnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOrderQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCurrDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ViewMenu As ContextMenuStrip
    Friend WithEvents SMPrePrint As ToolStripMenuItem
    Friend WithEvents SMPrint As ToolStripMenuItem
    Friend WithEvents GridColumnPrepareStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSvcLevel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemProgressBar1 As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastUpdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BAccept As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnPrintDetail As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCFilter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BHide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BExpand As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemaining As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotalNonStock As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRty As DevExpress.XtraGrid.Columns.GridColumn
End Class
