<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductionHO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProductionHO))
        Me.XTCHO = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPRegisterList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_pl_prod_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpl_prod_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstep = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpl_category = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnprod_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvendor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnho_notif_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnho_notif_by_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpl_prod_order_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_qty_all = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_bal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_qty_rec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnho_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_select = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnid_ho_status_input = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoHOStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumnqty_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_qty_bal_rec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControlSendEmail = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.CESelAll = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnSendEmail = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControlDate = New DevExpress.XtraEditors.PanelControl()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnViewPending = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.GCDetail = New DevExpress.XtraGrid.GridControl()
        Me.GVDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnDetCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDetDEFromDetail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDetName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetdesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDetsize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetqty_po = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetqty_rec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDetqty_pl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetqty_pl_total = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetbalance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetremark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetpl_prod_order_rec_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetprod_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetpl_prod_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetvendor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetpl_category = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetseason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetdelivery = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetstep = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetpl_prod_order_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDetho_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnbalance_rec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.DEUntilDetail = New DevExpress.XtraEditors.DateEdit()
        Me.DEFromDetail = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnViewDetail = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPSummary = New DevExpress.XtraTab.XtraTabPage()
        Me.GCSummary = New DevExpress.XtraGrid.GridControl()
        Me.GVSummary = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.BandedGridColumnbarcode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumncode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnname = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnsize = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnseason = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumndelivery = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumntotal_order = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumntotal_rec = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumndiff_order = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnnormal_pl = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnreject_minor_pl = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnreject_major_pl = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnafkir_pl = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumntotal_pl = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumndiff_rec = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnnormal_rw = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnreject_minor_rw = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnreject_major_rw = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnafkir_rw = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumntotal_rw = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumndiff_ho = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_season = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnrange = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnseason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DEUntilSummary = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnViewSummary = New DevExpress.XtraEditors.SimpleButton()
        Me.BandedGridColumnCLass = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandStyle = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBandOrder = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBandRecQC = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBandHO = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBandRecInWH = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.XTCHO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCHO.SuspendLayout()
        Me.XTPRegisterList.SuspendLayout()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoHOStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlSendEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlSendEmail.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CESelAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.PanelControlDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlDate.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPDetail.SuspendLayout()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.DEUntilDetail.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilDetail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromDetail.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromDetail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPSummary.SuspendLayout()
        CType(Me.GCSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl5.SuspendLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilSummary.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilSummary.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCHO
        '
        Me.XTCHO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCHO.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCHO.Location = New System.Drawing.Point(0, 0)
        Me.XTCHO.Name = "XTCHO"
        Me.XTCHO.SelectedTabPage = Me.XTPRegisterList
        Me.XTCHO.Size = New System.Drawing.Size(810, 500)
        Me.XTCHO.TabIndex = 0
        Me.XTCHO.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPRegisterList, Me.XTPDetail, Me.XTPSummary})
        '
        'XTPRegisterList
        '
        Me.XTPRegisterList.Controls.Add(Me.GCList)
        Me.XTPRegisterList.Controls.Add(Me.PanelControlSendEmail)
        Me.XTPRegisterList.Controls.Add(Me.PanelControlNav)
        Me.XTPRegisterList.Name = "XTPRegisterList"
        Me.XTPRegisterList.Size = New System.Drawing.Size(804, 472)
        Me.XTPRegisterList.Text = "Register List"
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 43)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit, Me.RepoHOStatus})
        Me.GCList.Size = New System.Drawing.Size(804, 397)
        Me.GCList.TabIndex = 1
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_pl_prod_order, Me.GridColumncode, Me.GridColumnName, Me.GridColumnpl_prod_order_number, Me.GridColumnstep, Me.GridColumnpl_category, Me.GridColumntotal_qty, Me.GridColumnprod_order_number, Me.GridColumnvendor, Me.GridColumnho_notif_date, Me.GridColumnho_notif_by_name, Me.GridColumnNo, Me.GridColumnpl_prod_order_date, Me.GridColumntotal_qty_all, Me.GridColumntotal_bal, Me.GridColumntotal_qty_rec, Me.GridColumnho_status, Me.GridColumnis_select, Me.GridColumnid_ho_status_input, Me.GridColumnqty_order, Me.GridColumntotal_qty_bal_rec})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsFind.AlwaysVisible = True
        Me.GVList.OptionsView.ColumnAutoWidth = False
        Me.GVList.OptionsView.ShowFooter = True
        Me.GVList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_pl_prod_order
        '
        Me.GridColumnid_pl_prod_order.Caption = "ID PL"
        Me.GridColumnid_pl_prod_order.FieldName = "id_pl_prod_order"
        Me.GridColumnid_pl_prod_order.Name = "GridColumnid_pl_prod_order"
        Me.GridColumnid_pl_prod_order.OptionsColumn.AllowEdit = False
        '
        'GridColumncode
        '
        Me.GridColumncode.Caption = "Design Code"
        Me.GridColumncode.FieldName = "code"
        Me.GridColumncode.Name = "GridColumncode"
        Me.GridColumncode.OptionsColumn.AllowEdit = False
        Me.GridColumncode.Visible = True
        Me.GridColumncode.VisibleIndex = 3
        Me.GridColumncode.Width = 150
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Design"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 4
        Me.GridColumnName.Width = 150
        '
        'GridColumnpl_prod_order_number
        '
        Me.GridColumnpl_prod_order_number.Caption = "PL Number"
        Me.GridColumnpl_prod_order_number.FieldName = "pl_prod_order_number"
        Me.GridColumnpl_prod_order_number.Name = "GridColumnpl_prod_order_number"
        Me.GridColumnpl_prod_order_number.OptionsColumn.AllowEdit = False
        Me.GridColumnpl_prod_order_number.Visible = True
        Me.GridColumnpl_prod_order_number.VisibleIndex = 5
        Me.GridColumnpl_prod_order_number.Width = 150
        '
        'GridColumnstep
        '
        Me.GridColumnstep.Caption = "Step Handover"
        Me.GridColumnstep.FieldName = "step"
        Me.GridColumnstep.Name = "GridColumnstep"
        Me.GridColumnstep.OptionsColumn.AllowEdit = False
        Me.GridColumnstep.Visible = True
        Me.GridColumnstep.VisibleIndex = 7
        Me.GridColumnstep.Width = 150
        '
        'GridColumnpl_category
        '
        Me.GridColumnpl_category.Caption = "PL Category"
        Me.GridColumnpl_category.FieldName = "pl_category"
        Me.GridColumnpl_category.Name = "GridColumnpl_category"
        Me.GridColumnpl_category.OptionsColumn.AllowEdit = False
        Me.GridColumnpl_category.Visible = True
        Me.GridColumnpl_category.VisibleIndex = 8
        Me.GridColumnpl_category.Width = 150
        '
        'GridColumntotal_qty
        '
        Me.GridColumntotal_qty.Caption = "Handover Qty"
        Me.GridColumntotal_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_qty.FieldName = "total_qty"
        Me.GridColumntotal_qty.Name = "GridColumntotal_qty"
        Me.GridColumntotal_qty.OptionsColumn.AllowEdit = False
        Me.GridColumntotal_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_qty", "{0:N0}")})
        Me.GridColumntotal_qty.Visible = True
        Me.GridColumntotal_qty.VisibleIndex = 12
        Me.GridColumntotal_qty.Width = 150
        '
        'GridColumnprod_order_number
        '
        Me.GridColumnprod_order_number.Caption = "FGPO Number"
        Me.GridColumnprod_order_number.FieldName = "prod_order_number"
        Me.GridColumnprod_order_number.Name = "GridColumnprod_order_number"
        Me.GridColumnprod_order_number.OptionsColumn.AllowEdit = False
        Me.GridColumnprod_order_number.Visible = True
        Me.GridColumnprod_order_number.VisibleIndex = 15
        Me.GridColumnprod_order_number.Width = 150
        '
        'GridColumnvendor
        '
        Me.GridColumnvendor.Caption = "Vendor"
        Me.GridColumnvendor.FieldName = "vendor"
        Me.GridColumnvendor.Name = "GridColumnvendor"
        Me.GridColumnvendor.OptionsColumn.AllowEdit = False
        Me.GridColumnvendor.Visible = True
        Me.GridColumnvendor.VisibleIndex = 16
        Me.GridColumnvendor.Width = 150
        '
        'GridColumnho_notif_date
        '
        Me.GridColumnho_notif_date.Caption = "Notification Sent"
        Me.GridColumnho_notif_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnho_notif_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnho_notif_date.FieldName = "ho_notif_date"
        Me.GridColumnho_notif_date.Name = "GridColumnho_notif_date"
        Me.GridColumnho_notif_date.OptionsColumn.AllowEdit = False
        Me.GridColumnho_notif_date.Visible = True
        Me.GridColumnho_notif_date.VisibleIndex = 18
        Me.GridColumnho_notif_date.Width = 150
        '
        'GridColumnho_notif_by_name
        '
        Me.GridColumnho_notif_by_name.Caption = "Sent by"
        Me.GridColumnho_notif_by_name.FieldName = "ho_notif_by_name"
        Me.GridColumnho_notif_by_name.Name = "GridColumnho_notif_by_name"
        Me.GridColumnho_notif_by_name.OptionsColumn.AllowEdit = False
        Me.GridColumnho_notif_by_name.Visible = True
        Me.GridColumnho_notif_by_name.VisibleIndex = 19
        Me.GridColumnho_notif_by_name.Width = 158
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 2
        Me.GridColumnNo.Width = 61
        '
        'GridColumnpl_prod_order_date
        '
        Me.GridColumnpl_prod_order_date.Caption = "PL Date"
        Me.GridColumnpl_prod_order_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnpl_prod_order_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnpl_prod_order_date.FieldName = "pl_prod_order_date"
        Me.GridColumnpl_prod_order_date.Name = "GridColumnpl_prod_order_date"
        Me.GridColumnpl_prod_order_date.Visible = True
        Me.GridColumnpl_prod_order_date.VisibleIndex = 6
        '
        'GridColumntotal_qty_all
        '
        Me.GridColumntotal_qty_all.Caption = "Handover Total Qty"
        Me.GridColumntotal_qty_all.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_qty_all.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_qty_all.FieldName = "total_qty_all"
        Me.GridColumntotal_qty_all.Name = "GridColumntotal_qty_all"
        Me.GridColumntotal_qty_all.OptionsColumn.AllowEdit = False
        Me.GridColumntotal_qty_all.Visible = True
        Me.GridColumntotal_qty_all.VisibleIndex = 13
        Me.GridColumntotal_qty_all.Width = 116
        '
        'GridColumntotal_bal
        '
        Me.GridColumntotal_bal.Caption = "Balance HO"
        Me.GridColumntotal_bal.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_bal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_bal.FieldName = "total_qty_bal"
        Me.GridColumntotal_bal.Name = "GridColumntotal_bal"
        Me.GridColumntotal_bal.OptionsColumn.AllowEdit = False
        Me.GridColumntotal_bal.UnboundExpression = "[total_qty_rec] - [total_qty_all]"
        Me.GridColumntotal_bal.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumntotal_bal.Visible = True
        Me.GridColumntotal_bal.VisibleIndex = 14
        '
        'GridColumntotal_qty_rec
        '
        Me.GridColumntotal_qty_rec.Caption = "Received Qty"
        Me.GridColumntotal_qty_rec.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_qty_rec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_qty_rec.FieldName = "total_qty_rec"
        Me.GridColumntotal_qty_rec.Name = "GridColumntotal_qty_rec"
        Me.GridColumntotal_qty_rec.OptionsColumn.AllowEdit = False
        Me.GridColumntotal_qty_rec.Visible = True
        Me.GridColumntotal_qty_rec.VisibleIndex = 10
        '
        'GridColumnho_status
        '
        Me.GridColumnho_status.Caption = "HO Status"
        Me.GridColumnho_status.FieldName = "ho_status"
        Me.GridColumnho_status.Name = "GridColumnho_status"
        Me.GridColumnho_status.OptionsColumn.AllowEdit = False
        Me.GridColumnho_status.Visible = True
        Me.GridColumnho_status.VisibleIndex = 17
        '
        'GridColumnis_select
        '
        Me.GridColumnis_select.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnis_select.AppearanceCell.ForeColor = System.Drawing.Color.DimGray
        Me.GridColumnis_select.AppearanceCell.Options.UseFont = True
        Me.GridColumnis_select.AppearanceCell.Options.UseForeColor = True
        Me.GridColumnis_select.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnis_select.AppearanceHeader.ForeColor = System.Drawing.Color.DimGray
        Me.GridColumnis_select.AppearanceHeader.Options.UseFont = True
        Me.GridColumnis_select.AppearanceHeader.Options.UseForeColor = True
        Me.GridColumnis_select.Caption = "Select"
        Me.GridColumnis_select.ColumnEdit = Me.RepositoryItemCheckEdit
        Me.GridColumnis_select.FieldName = "is_select"
        Me.GridColumnis_select.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnis_select.Name = "GridColumnis_select"
        Me.GridColumnis_select.Visible = True
        Me.GridColumnis_select.VisibleIndex = 0
        Me.GridColumnis_select.Width = 63
        '
        'RepositoryItemCheckEdit
        '
        Me.RepositoryItemCheckEdit.AutoHeight = False
        Me.RepositoryItemCheckEdit.Name = "RepositoryItemCheckEdit"
        Me.RepositoryItemCheckEdit.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit.ValueUnchecked = "No"
        '
        'GridColumnid_ho_status_input
        '
        Me.GridColumnid_ho_status_input.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnid_ho_status_input.AppearanceCell.ForeColor = System.Drawing.Color.DimGray
        Me.GridColumnid_ho_status_input.AppearanceCell.Options.UseFont = True
        Me.GridColumnid_ho_status_input.AppearanceCell.Options.UseForeColor = True
        Me.GridColumnid_ho_status_input.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnid_ho_status_input.AppearanceHeader.ForeColor = System.Drawing.Color.DimGray
        Me.GridColumnid_ho_status_input.AppearanceHeader.Options.UseFont = True
        Me.GridColumnid_ho_status_input.AppearanceHeader.Options.UseForeColor = True
        Me.GridColumnid_ho_status_input.Caption = "Set Status"
        Me.GridColumnid_ho_status_input.ColumnEdit = Me.RepoHOStatus
        Me.GridColumnid_ho_status_input.FieldName = "id_ho_status_input"
        Me.GridColumnid_ho_status_input.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnid_ho_status_input.Name = "GridColumnid_ho_status_input"
        Me.GridColumnid_ho_status_input.Visible = True
        Me.GridColumnid_ho_status_input.VisibleIndex = 1
        '
        'RepoHOStatus
        '
        Me.RepoHOStatus.AutoHeight = False
        Me.RepoHOStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoHOStatus.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_ho_status_input", "id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ho_status", "Status")})
        Me.RepoHOStatus.Name = "RepoHOStatus"
        '
        'GridColumnqty_order
        '
        Me.GridColumnqty_order.Caption = "Order Qty"
        Me.GridColumnqty_order.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty_order.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty_order.FieldName = "qty_po"
        Me.GridColumnqty_order.Name = "GridColumnqty_order"
        Me.GridColumnqty_order.OptionsColumn.AllowEdit = False
        Me.GridColumnqty_order.Visible = True
        Me.GridColumnqty_order.VisibleIndex = 9
        '
        'GridColumntotal_qty_bal_rec
        '
        Me.GridColumntotal_qty_bal_rec.Caption = "Balance Rec"
        Me.GridColumntotal_qty_bal_rec.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_qty_bal_rec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_qty_bal_rec.FieldName = "total_qty_bal_rec"
        Me.GridColumntotal_qty_bal_rec.Name = "GridColumntotal_qty_bal_rec"
        Me.GridColumntotal_qty_bal_rec.OptionsColumn.AllowEdit = False
        Me.GridColumntotal_qty_bal_rec.UnboundExpression = "[qty_po] - [total_qty_rec]"
        Me.GridColumntotal_qty_bal_rec.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumntotal_qty_bal_rec.Visible = True
        Me.GridColumntotal_qty_bal_rec.VisibleIndex = 11
        '
        'PanelControlSendEmail
        '
        Me.PanelControlSendEmail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlSendEmail.Controls.Add(Me.PanelControl1)
        Me.PanelControlSendEmail.Controls.Add(Me.BtnSendEmail)
        Me.PanelControlSendEmail.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlSendEmail.Location = New System.Drawing.Point(0, 440)
        Me.PanelControlSendEmail.Name = "PanelControlSendEmail"
        Me.PanelControlSendEmail.Size = New System.Drawing.Size(804, 32)
        Me.PanelControlSendEmail.TabIndex = 140
        Me.PanelControlSendEmail.Visible = False
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.CESelAll)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(99, 32)
        Me.PanelControl1.TabIndex = 141
        '
        'CESelAll
        '
        Me.CESelAll.Location = New System.Drawing.Point(4, 6)
        Me.CESelAll.Name = "CESelAll"
        Me.CESelAll.Properties.Caption = "Select All"
        Me.CESelAll.Size = New System.Drawing.Size(75, 19)
        Me.CESelAll.TabIndex = 140
        '
        'BtnSendEmail
        '
        Me.BtnSendEmail.Appearance.BackColor = System.Drawing.SystemColors.Highlight
        Me.BtnSendEmail.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSendEmail.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnSendEmail.Appearance.Options.UseBackColor = True
        Me.BtnSendEmail.Appearance.Options.UseFont = True
        Me.BtnSendEmail.Appearance.Options.UseForeColor = True
        Me.BtnSendEmail.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSendEmail.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BtnSendEmail.Location = New System.Drawing.Point(643, 0)
        Me.BtnSendEmail.LookAndFeel.SkinName = "Metropolis"
        Me.BtnSendEmail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnSendEmail.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnSendEmail.Name = "BtnSendEmail"
        Me.BtnSendEmail.Size = New System.Drawing.Size(161, 32)
        Me.BtnSendEmail.TabIndex = 139
        Me.BtnSendEmail.Text = "Send Notification Email"
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.PanelControlDate)
        Me.PanelControlNav.Controls.Add(Me.BtnView)
        Me.PanelControlNav.Controls.Add(Me.BtnViewPending)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(804, 43)
        Me.PanelControlNav.TabIndex = 0
        '
        'PanelControlDate
        '
        Me.PanelControlDate.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlDate.Controls.Add(Me.DEUntil)
        Me.PanelControlDate.Controls.Add(Me.DEFrom)
        Me.PanelControlDate.Controls.Add(Me.LabelControl2)
        Me.PanelControlDate.Controls.Add(Me.LabelControl3)
        Me.PanelControlDate.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlDate.Location = New System.Drawing.Point(245, 2)
        Me.PanelControlDate.Name = "PanelControlDate"
        Me.PanelControlDate.Size = New System.Drawing.Size(299, 39)
        Me.PanelControlDate.TabIndex = 2
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(181, 9)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(111, 20)
        Me.DEUntil.TabIndex = 8899
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(37, 9)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEFrom.TabIndex = 8898
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(154, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8897
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(7, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8896
        Me.LabelControl3.Text = "From"
        '
        'BtnView
        '
        Me.BtnView.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(544, 2)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(84, 39)
        Me.BtnView.TabIndex = 0
        Me.BtnView.Text = "View"
        '
        'BtnViewPending
        '
        Me.BtnViewPending.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnViewPending.Image = CType(resources.GetObject("BtnViewPending.Image"), System.Drawing.Image)
        Me.BtnViewPending.Location = New System.Drawing.Point(628, 2)
        Me.BtnViewPending.Name = "BtnViewPending"
        Me.BtnViewPending.Size = New System.Drawing.Size(174, 39)
        Me.BtnViewPending.TabIndex = 1
        Me.BtnViewPending.Text = "View Pending Notification"
        '
        'XTPDetail
        '
        Me.XTPDetail.Controls.Add(Me.GCDetail)
        Me.XTPDetail.Controls.Add(Me.PanelControl2)
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.Size = New System.Drawing.Size(804, 472)
        Me.XTPDetail.Text = "Packing List Detail"
        '
        'GCDetail
        '
        Me.GCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetail.Location = New System.Drawing.Point(0, 43)
        Me.GCDetail.MainView = Me.GVDetail
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2})
        Me.GCDetail.Size = New System.Drawing.Size(804, 429)
        Me.GCDetail.TabIndex = 2
        Me.GCDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetail})
        '
        'GVDetail
        '
        Me.GVDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnDetCode, Me.GridColumnDetDEFromDetail, Me.GridColumnDetName, Me.GridColumndetdesign, Me.GridColumnDetsize, Me.GridColumndetqty_po, Me.GridColumndetqty_rec, Me.GridColumnDetqty_pl, Me.GridColumndetqty_pl_total, Me.GridColumndetbalance, Me.GridColumndetremark, Me.GridColumndetpl_prod_order_rec_number, Me.GridColumndetreport_status, Me.GridColumndetprod_order_number, Me.GridColumndetpl_prod_order_number, Me.GridColumndetvendor, Me.GridColumndetpl_category, Me.GridColumndetseason, Me.GridColumndetdelivery, Me.GridColumndetstep, Me.GridColumndetpl_prod_order_date, Me.GridColumnDetho_status, Me.GridColumnbalance_rec})
        Me.GVDetail.GridControl = Me.GCDetail
        Me.GVDetail.GroupCount = 1
        Me.GVDetail.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_po", Me.GridColumndetqty_po, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec", Me.GridColumndetqty_rec, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl", Me.GridColumnDetqty_pl, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl_total", Me.GridColumndetqty_pl_total, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "balance", Me.GridColumndetbalance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "balance_rec", Me.GridColumnbalance_rec, "{0:N0}")})
        Me.GVDetail.Name = "GVDetail"
        Me.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDetail.OptionsBehavior.Editable = False
        Me.GVDetail.OptionsFind.AlwaysVisible = True
        Me.GVDetail.OptionsView.ColumnAutoWidth = False
        Me.GVDetail.OptionsView.ShowFooter = True
        Me.GVDetail.OptionsView.ShowGroupedColumns = True
        Me.GVDetail.OptionsView.ShowGroupPanel = False
        Me.GVDetail.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumndetpl_prod_order_number, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnDetCode
        '
        Me.GridColumnDetCode.Caption = "Code"
        Me.GridColumnDetCode.FieldName = "code"
        Me.GridColumnDetCode.Name = "GridColumnDetCode"
        Me.GridColumnDetCode.Visible = True
        Me.GridColumnDetCode.VisibleIndex = 1
        '
        'GridColumnDetDEFromDetail
        '
        Me.GridColumnDetDEFromDetail.Caption = "Barcode"
        Me.GridColumnDetDEFromDetail.FieldName = "barcode"
        Me.GridColumnDetDEFromDetail.Name = "GridColumnDetDEFromDetail"
        Me.GridColumnDetDEFromDetail.Visible = True
        Me.GridColumnDetDEFromDetail.VisibleIndex = 0
        '
        'GridColumnDetName
        '
        Me.GridColumnDetName.Caption = "Design"
        Me.GridColumnDetName.FieldName = "name"
        Me.GridColumnDetName.Name = "GridColumnDetName"
        Me.GridColumnDetName.Visible = True
        Me.GridColumnDetName.VisibleIndex = 2
        '
        'GridColumndetdesign
        '
        Me.GridColumndetdesign.Caption = "Design"
        Me.GridColumndetdesign.FieldName = "design"
        Me.GridColumndetdesign.Name = "GridColumndetdesign"
        Me.GridColumndetdesign.UnboundExpression = "Concat([code], ' - ', [name])"
        Me.GridColumndetdesign.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'GridColumnDetsize
        '
        Me.GridColumnDetsize.Caption = "Size"
        Me.GridColumnDetsize.FieldName = "size"
        Me.GridColumnDetsize.Name = "GridColumnDetsize"
        Me.GridColumnDetsize.Visible = True
        Me.GridColumnDetsize.VisibleIndex = 3
        '
        'GridColumndetqty_po
        '
        Me.GridColumndetqty_po.Caption = "Order Total"
        Me.GridColumndetqty_po.DisplayFormat.FormatString = "N0"
        Me.GridColumndetqty_po.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndetqty_po.FieldName = "qty_po"
        Me.GridColumndetqty_po.Name = "GridColumndetqty_po"
        Me.GridColumndetqty_po.Visible = True
        Me.GridColumndetqty_po.VisibleIndex = 12
        '
        'GridColumndetqty_rec
        '
        Me.GridColumndetqty_rec.Caption = "Received Total"
        Me.GridColumndetqty_rec.DisplayFormat.FormatString = "N0"
        Me.GridColumndetqty_rec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndetqty_rec.FieldName = "qty_rec"
        Me.GridColumndetqty_rec.Name = "GridColumndetqty_rec"
        Me.GridColumndetqty_rec.Visible = True
        Me.GridColumndetqty_rec.VisibleIndex = 13
        Me.GridColumndetqty_rec.Width = 105
        '
        'GridColumnDetqty_pl
        '
        Me.GridColumnDetqty_pl.Caption = "Handover"
        Me.GridColumnDetqty_pl.DisplayFormat.FormatString = "N0"
        Me.GridColumnDetqty_pl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDetqty_pl.FieldName = "qty_pl"
        Me.GridColumnDetqty_pl.Name = "GridColumnDetqty_pl"
        Me.GridColumnDetqty_pl.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl", "{0:N0}")})
        Me.GridColumnDetqty_pl.Visible = True
        Me.GridColumnDetqty_pl.VisibleIndex = 15
        Me.GridColumnDetqty_pl.Width = 115
        '
        'GridColumndetqty_pl_total
        '
        Me.GridColumndetqty_pl_total.Caption = "Handover Total"
        Me.GridColumndetqty_pl_total.DisplayFormat.FormatString = "N0"
        Me.GridColumndetqty_pl_total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndetqty_pl_total.FieldName = "qty_pl_total"
        Me.GridColumndetqty_pl_total.Name = "GridColumndetqty_pl_total"
        Me.GridColumndetqty_pl_total.Visible = True
        Me.GridColumndetqty_pl_total.VisibleIndex = 16
        Me.GridColumndetqty_pl_total.Width = 109
        '
        'GridColumndetbalance
        '
        Me.GridColumndetbalance.Caption = "Balance HO"
        Me.GridColumndetbalance.DisplayFormat.FormatString = "N0"
        Me.GridColumndetbalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndetbalance.FieldName = "balance"
        Me.GridColumndetbalance.Name = "GridColumndetbalance"
        Me.GridColumndetbalance.Visible = True
        Me.GridColumndetbalance.VisibleIndex = 17
        Me.GridColumndetbalance.Width = 103
        '
        'GridColumndetremark
        '
        Me.GridColumndetremark.Caption = "Remark"
        Me.GridColumndetremark.FieldName = "remark"
        Me.GridColumndetremark.Name = "GridColumndetremark"
        Me.GridColumndetremark.Visible = True
        Me.GridColumndetremark.VisibleIndex = 18
        '
        'GridColumndetpl_prod_order_rec_number
        '
        Me.GridColumndetpl_prod_order_rec_number.Caption = "Received WH#"
        Me.GridColumndetpl_prod_order_rec_number.FieldName = "pl_prod_order_rec_number"
        Me.GridColumndetpl_prod_order_rec_number.Name = "GridColumndetpl_prod_order_rec_number"
        Me.GridColumndetpl_prod_order_rec_number.Visible = True
        Me.GridColumndetpl_prod_order_rec_number.VisibleIndex = 20
        Me.GridColumndetpl_prod_order_rec_number.Width = 106
        '
        'GridColumndetreport_status
        '
        Me.GridColumndetreport_status.Caption = "Received WH Status"
        Me.GridColumndetreport_status.FieldName = "report_status"
        Me.GridColumndetreport_status.Name = "GridColumndetreport_status"
        Me.GridColumndetreport_status.Visible = True
        Me.GridColumndetreport_status.VisibleIndex = 21
        Me.GridColumndetreport_status.Width = 125
        '
        'GridColumndetprod_order_number
        '
        Me.GridColumndetprod_order_number.Caption = "FG. PO #"
        Me.GridColumndetprod_order_number.FieldName = "prod_order_number"
        Me.GridColumndetprod_order_number.Name = "GridColumndetprod_order_number"
        Me.GridColumndetprod_order_number.Visible = True
        Me.GridColumndetprod_order_number.VisibleIndex = 7
        '
        'GridColumndetpl_prod_order_number
        '
        Me.GridColumndetpl_prod_order_number.Caption = "PL#"
        Me.GridColumndetpl_prod_order_number.FieldName = "pl_prod_order_number"
        Me.GridColumndetpl_prod_order_number.Name = "GridColumndetpl_prod_order_number"
        Me.GridColumndetpl_prod_order_number.Visible = True
        Me.GridColumndetpl_prod_order_number.VisibleIndex = 8
        '
        'GridColumndetvendor
        '
        Me.GridColumndetvendor.Caption = "Vendor"
        Me.GridColumndetvendor.FieldName = "vendor"
        Me.GridColumndetvendor.Name = "GridColumndetvendor"
        Me.GridColumndetvendor.Visible = True
        Me.GridColumndetvendor.VisibleIndex = 6
        '
        'GridColumndetpl_category
        '
        Me.GridColumndetpl_category.Caption = "Handover Category"
        Me.GridColumndetpl_category.FieldName = "pl_category"
        Me.GridColumndetpl_category.Name = "GridColumndetpl_category"
        Me.GridColumndetpl_category.Visible = True
        Me.GridColumndetpl_category.VisibleIndex = 11
        Me.GridColumndetpl_category.Width = 127
        '
        'GridColumndetseason
        '
        Me.GridColumndetseason.Caption = "Season"
        Me.GridColumndetseason.FieldName = "season"
        Me.GridColumndetseason.Name = "GridColumndetseason"
        Me.GridColumndetseason.Visible = True
        Me.GridColumndetseason.VisibleIndex = 4
        '
        'GridColumndetdelivery
        '
        Me.GridColumndetdelivery.Caption = "Del"
        Me.GridColumndetdelivery.FieldName = "delivery"
        Me.GridColumndetdelivery.Name = "GridColumndetdelivery"
        Me.GridColumndetdelivery.Visible = True
        Me.GridColumndetdelivery.VisibleIndex = 5
        '
        'GridColumndetstep
        '
        Me.GridColumndetstep.Caption = "Handover Step"
        Me.GridColumndetstep.FieldName = "step"
        Me.GridColumndetstep.Name = "GridColumndetstep"
        Me.GridColumndetstep.Visible = True
        Me.GridColumndetstep.VisibleIndex = 10
        Me.GridColumndetstep.Width = 111
        '
        'GridColumndetpl_prod_order_date
        '
        Me.GridColumndetpl_prod_order_date.Caption = "Created PL Date"
        Me.GridColumndetpl_prod_order_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumndetpl_prod_order_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumndetpl_prod_order_date.FieldName = "pl_prod_order_date"
        Me.GridColumndetpl_prod_order_date.Name = "GridColumndetpl_prod_order_date"
        Me.GridColumndetpl_prod_order_date.Visible = True
        Me.GridColumndetpl_prod_order_date.VisibleIndex = 9
        Me.GridColumndetpl_prod_order_date.Width = 112
        '
        'GridColumnDetho_status
        '
        Me.GridColumnDetho_status.Caption = "HO Status"
        Me.GridColumnDetho_status.FieldName = "ho_status"
        Me.GridColumnDetho_status.Name = "GridColumnDetho_status"
        Me.GridColumnDetho_status.OptionsColumn.AllowEdit = False
        Me.GridColumnDetho_status.Visible = True
        Me.GridColumnDetho_status.VisibleIndex = 19
        '
        'GridColumnbalance_rec
        '
        Me.GridColumnbalance_rec.Caption = "Balance Rec"
        Me.GridColumnbalance_rec.DisplayFormat.FormatString = "N0"
        Me.GridColumnbalance_rec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnbalance_rec.FieldName = "balance_rec"
        Me.GridColumnbalance_rec.Name = "GridColumnbalance_rec"
        Me.GridColumnbalance_rec.UnboundExpression = "[qty_po] - [qty_rec]"
        Me.GridColumnbalance_rec.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnbalance_rec.Visible = True
        Me.GridColumnbalance_rec.VisibleIndex = 14
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit2.ValueUnchecked = "No"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.PanelControl3)
        Me.PanelControl2.Controls.Add(Me.BtnViewDetail)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(804, 43)
        Me.PanelControl2.TabIndex = 1
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.DEUntilDetail)
        Me.PanelControl3.Controls.Add(Me.DEFromDetail)
        Me.PanelControl3.Controls.Add(Me.LabelControl1)
        Me.PanelControl3.Controls.Add(Me.LabelControl4)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl3.Location = New System.Drawing.Point(419, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(299, 39)
        Me.PanelControl3.TabIndex = 2
        '
        'DEUntilDetail
        '
        Me.DEUntilDetail.EditValue = Nothing
        Me.DEUntilDetail.Location = New System.Drawing.Point(181, 9)
        Me.DEUntilDetail.Name = "DEUntilDetail"
        Me.DEUntilDetail.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilDetail.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilDetail.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilDetail.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilDetail.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilDetail.Size = New System.Drawing.Size(111, 20)
        Me.DEUntilDetail.TabIndex = 8899
        '
        'DEFromDetail
        '
        Me.DEFromDetail.EditValue = Nothing
        Me.DEFromDetail.Location = New System.Drawing.Point(37, 9)
        Me.DEFromDetail.Name = "DEFromDetail"
        Me.DEFromDetail.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromDetail.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFromDetail.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromDetail.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromDetail.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFromDetail.Size = New System.Drawing.Size(111, 20)
        Me.DEFromDetail.TabIndex = 8898
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(154, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl1.TabIndex = 8897
        Me.LabelControl1.Text = "Until"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(7, 12)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl4.TabIndex = 8896
        Me.LabelControl4.Text = "From"
        '
        'BtnViewDetail
        '
        Me.BtnViewDetail.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnViewDetail.Image = CType(resources.GetObject("BtnViewDetail.Image"), System.Drawing.Image)
        Me.BtnViewDetail.Location = New System.Drawing.Point(718, 2)
        Me.BtnViewDetail.Name = "BtnViewDetail"
        Me.BtnViewDetail.Size = New System.Drawing.Size(84, 39)
        Me.BtnViewDetail.TabIndex = 0
        Me.BtnViewDetail.Text = "View"
        '
        'XTPSummary
        '
        Me.XTPSummary.Controls.Add(Me.GCSummary)
        Me.XTPSummary.Controls.Add(Me.PanelControl4)
        Me.XTPSummary.Name = "XTPSummary"
        Me.XTPSummary.Size = New System.Drawing.Size(804, 472)
        Me.XTPSummary.Text = "Summary by Product"
        '
        'GCSummary
        '
        Me.GCSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSummary.Location = New System.Drawing.Point(0, 43)
        Me.GCSummary.MainView = Me.GVSummary
        Me.GCSummary.Name = "GCSummary"
        Me.GCSummary.Size = New System.Drawing.Size(804, 429)
        Me.GCSummary.TabIndex = 3
        Me.GCSummary.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSummary})
        '
        'GVSummary
        '
        Me.GVSummary.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBandStyle, Me.gridBandOrder, Me.gridBandRecQC, Me.gridBandHO, Me.gridBandRecInWH})
        Me.GVSummary.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumnbarcode, Me.BandedGridColumncode, Me.BandedGridColumnname, Me.BandedGridColumnsize, Me.BandedGridColumnseason, Me.BandedGridColumndelivery, Me.BandedGridColumntotal_order, Me.BandedGridColumntotal_rec, Me.BandedGridColumndiff_order, Me.BandedGridColumnnormal_pl, Me.BandedGridColumnreject_minor_pl, Me.BandedGridColumnreject_major_pl, Me.BandedGridColumnafkir_pl, Me.BandedGridColumntotal_pl, Me.BandedGridColumndiff_rec, Me.BandedGridColumnnormal_rw, Me.BandedGridColumnreject_minor_rw, Me.BandedGridColumnreject_major_rw, Me.BandedGridColumnafkir_rw, Me.BandedGridColumntotal_rw, Me.BandedGridColumndiff_ho, Me.BandedGridColumnCLass})
        Me.GVSummary.GridControl = Me.GCSummary
        Me.GVSummary.GroupCount = 1
        Me.GVSummary.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_order", Me.BandedGridColumntotal_order, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_rec", Me.BandedGridColumntotal_rec, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_order", Me.BandedGridColumndiff_order, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "normal_pl", Me.BandedGridColumnnormal_pl, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reject_minor_pl", Me.BandedGridColumnreject_minor_pl, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reject_major_pl", Me.BandedGridColumnreject_major_pl, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "afkir_pl", Me.BandedGridColumnafkir_pl, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_pl", Me.BandedGridColumntotal_pl, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_rec", Me.BandedGridColumndiff_rec, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "normal_rw", Me.BandedGridColumnnormal_rw, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reject_minor_rw", Me.BandedGridColumnreject_minor_rw, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reject_major_rw", Me.BandedGridColumnreject_major_rw, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "afkir_rw", Me.BandedGridColumnafkir_rw, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_rw", Me.BandedGridColumntotal_rw, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_ho", Me.BandedGridColumndiff_ho, "{0:N0}")})
        Me.GVSummary.Name = "GVSummary"
        Me.GVSummary.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSummary.OptionsBehavior.ReadOnly = True
        Me.GVSummary.OptionsFind.AlwaysVisible = True
        Me.GVSummary.OptionsView.ColumnAutoWidth = False
        Me.GVSummary.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVSummary.OptionsView.ShowFooter = True
        Me.GVSummary.OptionsView.ShowGroupPanel = False
        Me.GVSummary.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumnname, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'BandedGridColumnbarcode
        '
        Me.BandedGridColumnbarcode.Caption = "Barcode"
        Me.BandedGridColumnbarcode.FieldName = "barcode"
        Me.BandedGridColumnbarcode.Name = "BandedGridColumnbarcode"
        Me.BandedGridColumnbarcode.Visible = True
        '
        'BandedGridColumncode
        '
        Me.BandedGridColumncode.Caption = "Code"
        Me.BandedGridColumncode.FieldName = "code"
        Me.BandedGridColumncode.Name = "BandedGridColumncode"
        Me.BandedGridColumncode.Visible = True
        '
        'BandedGridColumnname
        '
        Me.BandedGridColumnname.Caption = "Style"
        Me.BandedGridColumnname.FieldName = "name"
        Me.BandedGridColumnname.Name = "BandedGridColumnname"
        Me.BandedGridColumnname.Visible = True
        '
        'BandedGridColumnsize
        '
        Me.BandedGridColumnsize.Caption = "Size"
        Me.BandedGridColumnsize.FieldName = "size"
        Me.BandedGridColumnsize.Name = "BandedGridColumnsize"
        Me.BandedGridColumnsize.Visible = True
        '
        'BandedGridColumnseason
        '
        Me.BandedGridColumnseason.Caption = "Season"
        Me.BandedGridColumnseason.FieldName = "season"
        Me.BandedGridColumnseason.Name = "BandedGridColumnseason"
        Me.BandedGridColumnseason.Visible = True
        '
        'BandedGridColumndelivery
        '
        Me.BandedGridColumndelivery.Caption = "Del"
        Me.BandedGridColumndelivery.FieldName = "delivery"
        Me.BandedGridColumndelivery.Name = "BandedGridColumndelivery"
        Me.BandedGridColumndelivery.Visible = True
        '
        'BandedGridColumntotal_order
        '
        Me.BandedGridColumntotal_order.Caption = "Order Qty"
        Me.BandedGridColumntotal_order.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumntotal_order.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumntotal_order.FieldName = "total_order"
        Me.BandedGridColumntotal_order.Name = "BandedGridColumntotal_order"
        Me.BandedGridColumntotal_order.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_order", "{0:N0}")})
        Me.BandedGridColumntotal_order.Visible = True
        '
        'BandedGridColumntotal_rec
        '
        Me.BandedGridColumntotal_rec.Caption = "Receive Qty"
        Me.BandedGridColumntotal_rec.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumntotal_rec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumntotal_rec.FieldName = "total_rec"
        Me.BandedGridColumntotal_rec.Name = "BandedGridColumntotal_rec"
        Me.BandedGridColumntotal_rec.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_rec", "{0:N0}")})
        Me.BandedGridColumntotal_rec.Visible = True
        '
        'BandedGridColumndiff_order
        '
        Me.BandedGridColumndiff_order.Caption = "Diff Order"
        Me.BandedGridColumndiff_order.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumndiff_order.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumndiff_order.FieldName = "diff_order"
        Me.BandedGridColumndiff_order.Name = "BandedGridColumndiff_order"
        Me.BandedGridColumndiff_order.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_order", "{0:N0}")})
        Me.BandedGridColumndiff_order.UnboundExpression = "[total_rec]-[total_order]"
        Me.BandedGridColumndiff_order.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumndiff_order.Visible = True
        '
        'BandedGridColumnnormal_pl
        '
        Me.BandedGridColumnnormal_pl.Caption = "Normal"
        Me.BandedGridColumnnormal_pl.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnnormal_pl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnnormal_pl.FieldName = "normal_pl"
        Me.BandedGridColumnnormal_pl.Name = "BandedGridColumnnormal_pl"
        Me.BandedGridColumnnormal_pl.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "normal_pl", "{0:N0}")})
        Me.BandedGridColumnnormal_pl.Visible = True
        '
        'BandedGridColumnreject_minor_pl
        '
        Me.BandedGridColumnreject_minor_pl.Caption = "Reject Minor"
        Me.BandedGridColumnreject_minor_pl.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnreject_minor_pl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnreject_minor_pl.FieldName = "reject_minor_pl"
        Me.BandedGridColumnreject_minor_pl.Name = "BandedGridColumnreject_minor_pl"
        Me.BandedGridColumnreject_minor_pl.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reject_minor_pl", "{0:N0}")})
        Me.BandedGridColumnreject_minor_pl.Visible = True
        Me.BandedGridColumnreject_minor_pl.Width = 109
        '
        'BandedGridColumnreject_major_pl
        '
        Me.BandedGridColumnreject_major_pl.Caption = "Reject Major"
        Me.BandedGridColumnreject_major_pl.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnreject_major_pl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnreject_major_pl.FieldName = "reject_major_pl"
        Me.BandedGridColumnreject_major_pl.Name = "BandedGridColumnreject_major_pl"
        Me.BandedGridColumnreject_major_pl.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reject_major_pl", "{0:N0}")})
        Me.BandedGridColumnreject_major_pl.Visible = True
        Me.BandedGridColumnreject_major_pl.Width = 114
        '
        'BandedGridColumnafkir_pl
        '
        Me.BandedGridColumnafkir_pl.Caption = "Afkir"
        Me.BandedGridColumnafkir_pl.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnafkir_pl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnafkir_pl.FieldName = "afkir_pl"
        Me.BandedGridColumnafkir_pl.Name = "BandedGridColumnafkir_pl"
        Me.BandedGridColumnafkir_pl.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "afkir_pl", "{0:N0}")})
        Me.BandedGridColumnafkir_pl.Visible = True
        '
        'BandedGridColumntotal_pl
        '
        Me.BandedGridColumntotal_pl.Caption = "Total"
        Me.BandedGridColumntotal_pl.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumntotal_pl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumntotal_pl.FieldName = "total_pl"
        Me.BandedGridColumntotal_pl.Name = "BandedGridColumntotal_pl"
        Me.BandedGridColumntotal_pl.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_pl", "{0:N0}")})
        Me.BandedGridColumntotal_pl.Visible = True
        '
        'BandedGridColumndiff_rec
        '
        Me.BandedGridColumndiff_rec.Caption = "Diff Rec"
        Me.BandedGridColumndiff_rec.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumndiff_rec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumndiff_rec.FieldName = "diff_rec"
        Me.BandedGridColumndiff_rec.Name = "BandedGridColumndiff_rec"
        Me.BandedGridColumndiff_rec.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_rec", "{0:N0}")})
        Me.BandedGridColumndiff_rec.UnboundExpression = "[total_pl]-[total_rec]"
        Me.BandedGridColumndiff_rec.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumndiff_rec.Visible = True
        '
        'BandedGridColumnnormal_rw
        '
        Me.BandedGridColumnnormal_rw.Caption = "Normal"
        Me.BandedGridColumnnormal_rw.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnnormal_rw.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnnormal_rw.FieldName = "normal_rw"
        Me.BandedGridColumnnormal_rw.Name = "BandedGridColumnnormal_rw"
        Me.BandedGridColumnnormal_rw.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "normal_rw", "{0:N0}")})
        Me.BandedGridColumnnormal_rw.Visible = True
        Me.BandedGridColumnnormal_rw.Width = 89
        '
        'BandedGridColumnreject_minor_rw
        '
        Me.BandedGridColumnreject_minor_rw.Caption = "Reject Minor"
        Me.BandedGridColumnreject_minor_rw.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnreject_minor_rw.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnreject_minor_rw.FieldName = "reject_minor_rw"
        Me.BandedGridColumnreject_minor_rw.Name = "BandedGridColumnreject_minor_rw"
        Me.BandedGridColumnreject_minor_rw.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reject_minor_rw", "{0:N0}")})
        Me.BandedGridColumnreject_minor_rw.Visible = True
        Me.BandedGridColumnreject_minor_rw.Width = 133
        '
        'BandedGridColumnreject_major_rw
        '
        Me.BandedGridColumnreject_major_rw.Caption = "Reject Major"
        Me.BandedGridColumnreject_major_rw.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnreject_major_rw.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnreject_major_rw.FieldName = "reject_major_rw"
        Me.BandedGridColumnreject_major_rw.Name = "BandedGridColumnreject_major_rw"
        Me.BandedGridColumnreject_major_rw.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reject_major_rw", "{0:N0}")})
        Me.BandedGridColumnreject_major_rw.Visible = True
        Me.BandedGridColumnreject_major_rw.Width = 91
        '
        'BandedGridColumnafkir_rw
        '
        Me.BandedGridColumnafkir_rw.Caption = "Afkir"
        Me.BandedGridColumnafkir_rw.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnafkir_rw.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnafkir_rw.FieldName = "afkir_rw"
        Me.BandedGridColumnafkir_rw.Name = "BandedGridColumnafkir_rw"
        Me.BandedGridColumnafkir_rw.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "afkir_rw", "{0:N0}")})
        Me.BandedGridColumnafkir_rw.Visible = True
        '
        'BandedGridColumntotal_rw
        '
        Me.BandedGridColumntotal_rw.Caption = "Total"
        Me.BandedGridColumntotal_rw.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumntotal_rw.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumntotal_rw.FieldName = "total_rw"
        Me.BandedGridColumntotal_rw.Name = "BandedGridColumntotal_rw"
        Me.BandedGridColumntotal_rw.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_rw", "{0:N0}")})
        Me.BandedGridColumntotal_rw.Visible = True
        '
        'BandedGridColumndiff_ho
        '
        Me.BandedGridColumndiff_ho.Caption = "Diff HO"
        Me.BandedGridColumndiff_ho.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumndiff_ho.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumndiff_ho.FieldName = "diff_ho"
        Me.BandedGridColumndiff_ho.Name = "BandedGridColumndiff_ho"
        Me.BandedGridColumndiff_ho.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_ho", "{0:N0}")})
        Me.BandedGridColumndiff_ho.UnboundExpression = "[total_rw]-[total_pl]"
        Me.BandedGridColumndiff_ho.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumndiff_ho.Visible = True
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.PanelControl5)
        Me.PanelControl4.Controls.Add(Me.BtnViewSummary)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl4.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(804, 43)
        Me.PanelControl4.TabIndex = 2
        '
        'PanelControl5
        '
        Me.PanelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl5.Controls.Add(Me.SLESeason)
        Me.PanelControl5.Controls.Add(Me.DEUntilSummary)
        Me.PanelControl5.Controls.Add(Me.LabelControl5)
        Me.PanelControl5.Controls.Add(Me.LabelControl6)
        Me.PanelControl5.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl5.Location = New System.Drawing.Point(340, 2)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(378, 39)
        Me.PanelControl5.TabIndex = 2
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(48, 9)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.ShowClearButton = False
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(177, 20)
        Me.SLESeason.TabIndex = 3
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_season, Me.GridColumnrange, Me.GridColumnseason})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_season
        '
        Me.GridColumnid_season.Caption = "Id"
        Me.GridColumnid_season.FieldName = "id_season"
        Me.GridColumnid_season.Name = "GridColumnid_season"
        '
        'GridColumnrange
        '
        Me.GridColumnrange.Caption = "Range"
        Me.GridColumnrange.FieldName = "range"
        Me.GridColumnrange.Name = "GridColumnrange"
        Me.GridColumnrange.Visible = True
        Me.GridColumnrange.VisibleIndex = 0
        '
        'GridColumnseason
        '
        Me.GridColumnseason.Caption = "Season"
        Me.GridColumnseason.FieldName = "season"
        Me.GridColumnseason.Name = "GridColumnseason"
        Me.GridColumnseason.Visible = True
        Me.GridColumnseason.VisibleIndex = 1
        '
        'DEUntilSummary
        '
        Me.DEUntilSummary.EditValue = Nothing
        Me.DEUntilSummary.Location = New System.Drawing.Point(258, 9)
        Me.DEUntilSummary.Name = "DEUntilSummary"
        Me.DEUntilSummary.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntilSummary.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilSummary.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilSummary.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilSummary.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilSummary.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilSummary.Size = New System.Drawing.Size(111, 20)
        Me.DEUntilSummary.TabIndex = 8899
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(231, 12)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl5.TabIndex = 8897
        Me.LabelControl5.Text = "Until"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(7, 12)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl6.TabIndex = 8896
        Me.LabelControl6.Text = "Season"
        '
        'BtnViewSummary
        '
        Me.BtnViewSummary.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnViewSummary.Image = CType(resources.GetObject("BtnViewSummary.Image"), System.Drawing.Image)
        Me.BtnViewSummary.Location = New System.Drawing.Point(718, 2)
        Me.BtnViewSummary.Name = "BtnViewSummary"
        Me.BtnViewSummary.Size = New System.Drawing.Size(84, 39)
        Me.BtnViewSummary.TabIndex = 0
        Me.BtnViewSummary.Text = "View"
        '
        'BandedGridColumnCLass
        '
        Me.BandedGridColumnCLass.Caption = "Class"
        Me.BandedGridColumnCLass.FieldName = "class"
        Me.BandedGridColumnCLass.Name = "BandedGridColumnCLass"
        Me.BandedGridColumnCLass.Visible = True
        '
        'gridBandStyle
        '
        Me.gridBandStyle.Columns.Add(Me.BandedGridColumnbarcode)
        Me.gridBandStyle.Columns.Add(Me.BandedGridColumncode)
        Me.gridBandStyle.Columns.Add(Me.BandedGridColumnname)
        Me.gridBandStyle.Columns.Add(Me.BandedGridColumnsize)
        Me.gridBandStyle.Columns.Add(Me.BandedGridColumnCLass)
        Me.gridBandStyle.Columns.Add(Me.BandedGridColumnseason)
        Me.gridBandStyle.Columns.Add(Me.BandedGridColumndelivery)
        Me.gridBandStyle.Name = "gridBandStyle"
        Me.gridBandStyle.VisibleIndex = 0
        Me.gridBandStyle.Width = 525
        '
        'gridBandOrder
        '
        Me.gridBandOrder.Caption = "ORDER"
        Me.gridBandOrder.Columns.Add(Me.BandedGridColumntotal_order)
        Me.gridBandOrder.Name = "gridBandOrder"
        Me.gridBandOrder.VisibleIndex = 1
        Me.gridBandOrder.Width = 75
        '
        'gridBandRecQC
        '
        Me.gridBandRecQC.Caption = "REC. IN QC"
        Me.gridBandRecQC.Columns.Add(Me.BandedGridColumntotal_rec)
        Me.gridBandRecQC.Columns.Add(Me.BandedGridColumndiff_order)
        Me.gridBandRecQC.Name = "gridBandRecQC"
        Me.gridBandRecQC.VisibleIndex = 2
        Me.gridBandRecQC.Width = 150
        '
        'gridBandHO
        '
        Me.gridBandHO.Caption = "HANDOVER"
        Me.gridBandHO.Columns.Add(Me.BandedGridColumnnormal_pl)
        Me.gridBandHO.Columns.Add(Me.BandedGridColumnreject_minor_pl)
        Me.gridBandHO.Columns.Add(Me.BandedGridColumnreject_major_pl)
        Me.gridBandHO.Columns.Add(Me.BandedGridColumnafkir_pl)
        Me.gridBandHO.Columns.Add(Me.BandedGridColumntotal_pl)
        Me.gridBandHO.Columns.Add(Me.BandedGridColumndiff_rec)
        Me.gridBandHO.Name = "gridBandHO"
        Me.gridBandHO.VisibleIndex = 3
        Me.gridBandHO.Width = 523
        '
        'gridBandRecInWH
        '
        Me.gridBandRecInWH.Caption = "REC. IN WAREHOUSE"
        Me.gridBandRecInWH.Columns.Add(Me.BandedGridColumnnormal_rw)
        Me.gridBandRecInWH.Columns.Add(Me.BandedGridColumnreject_minor_rw)
        Me.gridBandRecInWH.Columns.Add(Me.BandedGridColumnreject_major_rw)
        Me.gridBandRecInWH.Columns.Add(Me.BandedGridColumnafkir_rw)
        Me.gridBandRecInWH.Columns.Add(Me.BandedGridColumntotal_rw)
        Me.gridBandRecInWH.Columns.Add(Me.BandedGridColumndiff_ho)
        Me.gridBandRecInWH.Name = "gridBandRecInWH"
        Me.gridBandRecInWH.VisibleIndex = 4
        Me.gridBandRecInWH.Width = 538
        '
        'FormProductionHO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 500)
        Me.Controls.Add(Me.XTCHO)
        Me.MinimizeBox = False
        Me.Name = "FormProductionHO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Handover Report"
        CType(Me.XTCHO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCHO.ResumeLayout(False)
        Me.XTPRegisterList.ResumeLayout(False)
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoHOStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlSendEmail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlSendEmail.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.CESelAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        CType(Me.PanelControlDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlDate.ResumeLayout(False)
        Me.PanelControlDate.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPDetail.ResumeLayout(False)
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.DEUntilDetail.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilDetail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromDetail.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromDetail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPSummary.ResumeLayout(False)
        CType(Me.GCSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl5.ResumeLayout(False)
        Me.PanelControl5.PerformLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilSummary.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilSummary.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCHO As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPRegisterList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControlDate As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnViewPending As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnid_pl_prod_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpl_prod_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstep As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpl_category As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnprod_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvendor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnho_notif_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnho_notif_by_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_select As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpl_prod_order_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnSendEmail As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControlSendEmail As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CESelAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GCDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEUntilDetail As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromDetail As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnViewDetail As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnDetCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDetDEFromDetail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDetName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetdesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDetsize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetqty_po As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetqty_rec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDetqty_pl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetqty_pl_total As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetbalance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetremark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetpl_prod_order_rec_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetprod_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetpl_prod_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetvendor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetpl_category As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetseason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetdelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetstep As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetpl_prod_order_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_qty_all As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_bal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_qty_rec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnho_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_ho_status_input As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoHOStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumnDetho_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_qty_bal_rec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnbalance_rec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPSummary As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCSummary As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSummary As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl5 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEUntilSummary As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnViewSummary As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BandedGridColumnbarcode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumncode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnname As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnsize As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnseason As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumndelivery As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumntotal_order As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumntotal_rec As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumndiff_order As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnnormal_pl As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnreject_minor_pl As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnreject_major_pl As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnafkir_pl As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumntotal_pl As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumndiff_rec As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnnormal_rw As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnreject_minor_rw As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnreject_major_rw As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnafkir_rw As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumntotal_rw As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumndiff_ho As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnid_season As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnrange As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnseason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gridBandStyle As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnCLass As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBandOrder As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBandRecQC As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBandHO As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBandRecInWH As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
