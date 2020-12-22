<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOLStoreOOSDetail
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
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOLStoreOOSDetail))
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPProduct = New DevExpress.XtraTab.XtraTabPage()
        Me.SCCOOS = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControlProduct = New DevExpress.XtraEditors.GroupControl()
        Me.GCProduct = New DevExpress.XtraGrid.GridControl()
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_product = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnorder_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnso_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnno_stock_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnrsv_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_poss_replace = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_poss_replace_view = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_design_cat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnbtn_restock = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoBtnRestock = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.BtnPrintProduct = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControlRestock = New DevExpress.XtraEditors.GroupControl()
        Me.GCRestock = New DevExpress.XtraGrid.GridControl()
        Me.GVRestock = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_sales_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_number_restock = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_prepare_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty_too = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty_trf = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndiff_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnprepare_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnPrintSyncList = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPSync = New DevExpress.XtraTab.XtraTabPage()
        Me.GCVolcom = New DevExpress.XtraGrid.GridControl()
        Me.GVVolcom = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_ol_shop_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_ol_shop_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncustomer_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnshipping_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnshipping_address = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnshipping_phone = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnshipping_city = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnshipping_post_code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnshipping_region = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpayment_method = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntracking_code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnol_store_sku = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnol_store_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsku = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_det_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_process = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_design_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote_stock = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_report_trf_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnrmt_trf_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_report_trf = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnrmt_trf = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_report_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnrmt_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntrf_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LinkTrfOrder = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.GridColumntrf_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LinkTrf = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.GridColumnsales_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LinkSalesOrder = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFailReason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote_promo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICEIsCheck = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BtnPrintDetailOrder = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.TxtCustomer = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtOrderNo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtMarketplaceName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtOOSNo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnSendEmail = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnClosedOrder = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancellAllOrder = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLog = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnConfirmRestock = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumnacc_from = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnacc_to = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPProduct.SuspendLayout()
        CType(Me.SCCOOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCCOOS.SuspendLayout()
        CType(Me.GroupControlProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlProduct.SuspendLayout()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoBtnRestock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlRestock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlRestock.SuspendLayout()
        CType(Me.GCRestock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRestock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPSync.SuspendLayout()
        CType(Me.GCVolcom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVVolcom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LinkTrfOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LinkTrf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LinkSalesOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEIsCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.TxtCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOrderNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMarketplaceName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOOSNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCData.Location = New System.Drawing.Point(0, 87)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPProduct
        Me.XTCData.Size = New System.Drawing.Size(980, 429)
        Me.XTCData.TabIndex = 1
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPProduct, Me.XTPSync})
        '
        'XTPProduct
        '
        Me.XTPProduct.Controls.Add(Me.SCCOOS)
        Me.XTPProduct.Name = "XTPProduct"
        Me.XTPProduct.Size = New System.Drawing.Size(974, 401)
        Me.XTPProduct.Text = "Product Info"
        '
        'SCCOOS
        '
        Me.SCCOOS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCCOOS.Location = New System.Drawing.Point(0, 0)
        Me.SCCOOS.Name = "SCCOOS"
        Me.SCCOOS.Panel1.Controls.Add(Me.GroupControlProduct)
        Me.SCCOOS.Panel1.Text = "Panel1"
        Me.SCCOOS.Panel2.Controls.Add(Me.GroupControlRestock)
        Me.SCCOOS.Panel2.Text = "Panel2"
        Me.SCCOOS.Size = New System.Drawing.Size(974, 401)
        Me.SCCOOS.SplitterPosition = 610
        Me.SCCOOS.TabIndex = 0
        Me.SCCOOS.Text = "SplitContainerControl1"
        '
        'GroupControlProduct
        '
        Me.GroupControlProduct.Controls.Add(Me.GCProduct)
        Me.GroupControlProduct.Controls.Add(Me.BtnPrintProduct)
        Me.GroupControlProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlProduct.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlProduct.Name = "GroupControlProduct"
        Me.GroupControlProduct.Size = New System.Drawing.Size(610, 401)
        Me.GroupControlProduct.TabIndex = 0
        Me.GroupControlProduct.Text = "Product List"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(2, 20)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoBtnRestock})
        Me.GCProduct.Size = New System.Drawing.Size(606, 356)
        Me.GCProduct.TabIndex = 0
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_product, Me.GridColumncode, Me.GridColumnname, Me.GridColumnsize, Me.GridColumnorder_qty, Me.GridColumnso_qty, Me.GridColumnno_stock_qty, Me.GridColumnrsv_qty, Me.GridColumnis_poss_replace, Me.GridColumnis_poss_replace_view, Me.GridColumnid_design_cat, Me.GridColumnbtn_restock})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVProduct.OptionsBehavior.ReadOnly = True
        Me.GVProduct.OptionsFind.AlwaysVisible = True
        Me.GVProduct.OptionsView.ColumnAutoWidth = False
        Me.GVProduct.OptionsView.ShowFooter = True
        Me.GVProduct.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_product
        '
        Me.GridColumnid_product.Caption = "id_product"
        Me.GridColumnid_product.FieldName = "id_product"
        Me.GridColumnid_product.Name = "GridColumnid_product"
        '
        'GridColumncode
        '
        Me.GridColumncode.Caption = "Code"
        Me.GridColumncode.FieldName = "code"
        Me.GridColumncode.Name = "GridColumncode"
        Me.GridColumncode.Visible = True
        Me.GridColumncode.VisibleIndex = 1
        '
        'GridColumnname
        '
        Me.GridColumnname.Caption = "Description"
        Me.GridColumnname.FieldName = "name"
        Me.GridColumnname.Name = "GridColumnname"
        Me.GridColumnname.Visible = True
        Me.GridColumnname.VisibleIndex = 2
        '
        'GridColumnsize
        '
        Me.GridColumnsize.Caption = "Size"
        Me.GridColumnsize.FieldName = "size"
        Me.GridColumnsize.Name = "GridColumnsize"
        Me.GridColumnsize.Visible = True
        Me.GridColumnsize.VisibleIndex = 3
        '
        'GridColumnorder_qty
        '
        Me.GridColumnorder_qty.Caption = "Order Qty"
        Me.GridColumnorder_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumnorder_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnorder_qty.FieldName = "order_qty"
        Me.GridColumnorder_qty.Name = "GridColumnorder_qty"
        Me.GridColumnorder_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "order_qty", "{0:N0}")})
        Me.GridColumnorder_qty.Visible = True
        Me.GridColumnorder_qty.VisibleIndex = 4
        '
        'GridColumnso_qty
        '
        Me.GridColumnso_qty.Caption = "Fulfillment Qty"
        Me.GridColumnso_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumnso_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnso_qty.FieldName = "so_qty"
        Me.GridColumnso_qty.Name = "GridColumnso_qty"
        Me.GridColumnso_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "so_qty", "{0:N0}")})
        Me.GridColumnso_qty.Visible = True
        Me.GridColumnso_qty.VisibleIndex = 5
        '
        'GridColumnno_stock_qty
        '
        Me.GridColumnno_stock_qty.Caption = "No Stock Qty"
        Me.GridColumnno_stock_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumnno_stock_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnno_stock_qty.FieldName = "no_stock_qty"
        Me.GridColumnno_stock_qty.Name = "GridColumnno_stock_qty"
        Me.GridColumnno_stock_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "no_stock_qty", "{0:N0}")})
        Me.GridColumnno_stock_qty.Visible = True
        Me.GridColumnno_stock_qty.VisibleIndex = 6
        '
        'GridColumnrsv_qty
        '
        Me.GridColumnrsv_qty.Caption = "Booked Qty"
        Me.GridColumnrsv_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumnrsv_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnrsv_qty.FieldName = "rsv_qty"
        Me.GridColumnrsv_qty.Name = "GridColumnrsv_qty"
        Me.GridColumnrsv_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty", "{0:N0}")})
        '
        'GridColumnis_poss_replace
        '
        Me.GridColumnis_poss_replace.Caption = "is_poss_replace"
        Me.GridColumnis_poss_replace.FieldName = "is_poss_replace"
        Me.GridColumnis_poss_replace.Name = "GridColumnis_poss_replace"
        '
        'GridColumnis_poss_replace_view
        '
        Me.GridColumnis_poss_replace_view.Caption = "Restock Posibility"
        Me.GridColumnis_poss_replace_view.FieldName = "is_poss_replace_view"
        Me.GridColumnis_poss_replace_view.Name = "GridColumnis_poss_replace_view"
        Me.GridColumnis_poss_replace_view.UnboundExpression = "Iif([is_poss_replace] = 1, 'Yes', 'No')"
        Me.GridColumnis_poss_replace_view.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.GridColumnis_poss_replace_view.Visible = True
        Me.GridColumnis_poss_replace_view.VisibleIndex = 7
        Me.GridColumnis_poss_replace_view.Width = 142
        '
        'GridColumnid_design_cat
        '
        Me.GridColumnid_design_cat.Caption = "id_design_cat"
        Me.GridColumnid_design_cat.FieldName = "id_design_cat"
        Me.GridColumnid_design_cat.Name = "GridColumnid_design_cat"
        '
        'GridColumnbtn_restock
        '
        Me.GridColumnbtn_restock.Caption = "Action"
        Me.GridColumnbtn_restock.ColumnEdit = Me.RepoBtnRestock
        Me.GridColumnbtn_restock.FieldName = "btn_restock"
        Me.GridColumnbtn_restock.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnbtn_restock.Name = "GridColumnbtn_restock"
        Me.GridColumnbtn_restock.Visible = True
        Me.GridColumnbtn_restock.VisibleIndex = 0
        '
        'RepoBtnRestock
        '
        Me.RepoBtnRestock.AutoHeight = False
        SerializableAppearanceObject1.BackColor = System.Drawing.Color.DeepSkyBlue
        SerializableAppearanceObject1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject1.ForeColor = System.Drawing.Color.White
        SerializableAppearanceObject1.Options.UseBackColor = True
        SerializableAppearanceObject1.Options.UseFont = True
        SerializableAppearanceObject1.Options.UseForeColor = True
        Me.RepoBtnRestock.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Restock", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.RepoBtnRestock.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.RepoBtnRestock.Name = "RepoBtnRestock"
        Me.RepoBtnRestock.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'BtnPrintProduct
        '
        Me.BtnPrintProduct.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnPrintProduct.Location = New System.Drawing.Point(2, 376)
        Me.BtnPrintProduct.Name = "BtnPrintProduct"
        Me.BtnPrintProduct.Size = New System.Drawing.Size(606, 23)
        Me.BtnPrintProduct.TabIndex = 1
        Me.BtnPrintProduct.Text = "Print Product List"
        '
        'GroupControlRestock
        '
        Me.GroupControlRestock.Controls.Add(Me.GCRestock)
        Me.GroupControlRestock.Controls.Add(Me.BtnPrintSyncList)
        Me.GroupControlRestock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlRestock.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlRestock.Name = "GroupControlRestock"
        Me.GroupControlRestock.Size = New System.Drawing.Size(359, 401)
        Me.GroupControlRestock.TabIndex = 1
        Me.GroupControlRestock.Text = "Restock Detail"
        '
        'GCRestock
        '
        Me.GCRestock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRestock.Location = New System.Drawing.Point(2, 20)
        Me.GCRestock.MainView = Me.GVRestock
        Me.GCRestock.Name = "GCRestock"
        Me.GCRestock.Size = New System.Drawing.Size(355, 356)
        Me.GCRestock.TabIndex = 1
        Me.GCRestock.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRestock})
        '
        'GVRestock
        '
        Me.GVRestock.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_sales_order, Me.GridColumnsales_order_number_restock, Me.GridColumnid_prepare_status, Me.GridColumnqty_too, Me.GridColumnqty_trf, Me.GridColumndiff_qty, Me.GridColumnprepare_status, Me.GridColumnacc_from, Me.GridColumnacc_to})
        Me.GVRestock.GridControl = Me.GCRestock
        Me.GVRestock.Name = "GVRestock"
        Me.GVRestock.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVRestock.OptionsBehavior.ReadOnly = True
        Me.GVRestock.OptionsFind.AlwaysVisible = True
        Me.GVRestock.OptionsView.ColumnAutoWidth = False
        Me.GVRestock.OptionsView.ShowFooter = True
        Me.GVRestock.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_sales_order
        '
        Me.GridColumnid_sales_order.Caption = "id_sales_order"
        Me.GridColumnid_sales_order.FieldName = "id_sales_order"
        Me.GridColumnid_sales_order.Name = "GridColumnid_sales_order"
        '
        'GridColumnsales_order_number_restock
        '
        Me.GridColumnsales_order_number_restock.Caption = "TOO"
        Me.GridColumnsales_order_number_restock.FieldName = "sales_order_number"
        Me.GridColumnsales_order_number_restock.Name = "GridColumnsales_order_number_restock"
        Me.GridColumnsales_order_number_restock.Visible = True
        Me.GridColumnsales_order_number_restock.VisibleIndex = 0
        '
        'GridColumnid_prepare_status
        '
        Me.GridColumnid_prepare_status.Caption = "id_prepare_status"
        Me.GridColumnid_prepare_status.FieldName = "id_prepare_status"
        Me.GridColumnid_prepare_status.Name = "GridColumnid_prepare_status"
        '
        'GridColumnqty_too
        '
        Me.GridColumnqty_too.Caption = "TOO Qty"
        Me.GridColumnqty_too.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty_too.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty_too.FieldName = "qty_too"
        Me.GridColumnqty_too.Name = "GridColumnqty_too"
        Me.GridColumnqty_too.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_too", "{0:N0}")})
        Me.GridColumnqty_too.Visible = True
        Me.GridColumnqty_too.VisibleIndex = 3
        '
        'GridColumnqty_trf
        '
        Me.GridColumnqty_trf.Caption = "Trf Qty"
        Me.GridColumnqty_trf.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty_trf.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty_trf.FieldName = "qty_trf"
        Me.GridColumnqty_trf.Name = "GridColumnqty_trf"
        Me.GridColumnqty_trf.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_trf", "{0:N0}")})
        Me.GridColumnqty_trf.Visible = True
        Me.GridColumnqty_trf.VisibleIndex = 4
        '
        'GridColumndiff_qty
        '
        Me.GridColumndiff_qty.Caption = "Diff"
        Me.GridColumndiff_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumndiff_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndiff_qty.FieldName = "diff_qty"
        Me.GridColumndiff_qty.Name = "GridColumndiff_qty"
        Me.GridColumndiff_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_qty", "{0:N0}")})
        Me.GridColumndiff_qty.Visible = True
        Me.GridColumndiff_qty.VisibleIndex = 5
        '
        'GridColumnprepare_status
        '
        Me.GridColumnprepare_status.Caption = "Status"
        Me.GridColumnprepare_status.FieldName = "prepare_status"
        Me.GridColumnprepare_status.Name = "GridColumnprepare_status"
        Me.GridColumnprepare_status.Visible = True
        Me.GridColumnprepare_status.VisibleIndex = 6
        '
        'BtnPrintSyncList
        '
        Me.BtnPrintSyncList.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnPrintSyncList.Location = New System.Drawing.Point(2, 376)
        Me.BtnPrintSyncList.Name = "BtnPrintSyncList"
        Me.BtnPrintSyncList.Size = New System.Drawing.Size(355, 23)
        Me.BtnPrintSyncList.TabIndex = 2
        Me.BtnPrintSyncList.Text = "Print Restock Detail"
        '
        'XTPSync
        '
        Me.XTPSync.Controls.Add(Me.GCVolcom)
        Me.XTPSync.Controls.Add(Me.BtnPrintDetailOrder)
        Me.XTPSync.Name = "XTPSync"
        Me.XTPSync.Size = New System.Drawing.Size(974, 401)
        Me.XTPSync.Text = "Sync Info"
        '
        'GCVolcom
        '
        Me.GCVolcom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCVolcom.Location = New System.Drawing.Point(0, 0)
        Me.GCVolcom.MainView = Me.GVVolcom
        Me.GCVolcom.Name = "GCVolcom"
        Me.GCVolcom.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.LinkTrfOrder, Me.LinkTrf, Me.LinkSalesOrder, Me.RICEIsCheck})
        Me.GCVolcom.Size = New System.Drawing.Size(974, 378)
        Me.GCVolcom.TabIndex = 3
        Me.GCVolcom.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVVolcom})
        '
        'GVVolcom
        '
        Me.GVVolcom.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid, Me.GridColumnsales_order_ol_shop_number, Me.GridColumnsales_order_ol_shop_date, Me.GridColumncustomer_name, Me.GridColumnshipping_name, Me.GridColumnshipping_address, Me.GridColumnshipping_phone, Me.GridColumnshipping_city, Me.GridColumnshipping_post_code, Me.GridColumnshipping_region, Me.GridColumnpayment_method, Me.GridColumntracking_code, Me.GridColumnol_store_sku, Me.GridColumnol_store_id, Me.GridColumnsku, Me.GridColumndesign_price, Me.GridColumnsales_order_det_qty, Me.GridColumnis_process, Me.GridColumnnote_price, Me.GridColumn1, Me.GridColumnid_design_price, Me.GridColumn2, Me.GridColumnnote_stock, Me.GridColumnid_report_trf_order, Me.GridColumnrmt_trf_order, Me.GridColumnid_report_trf, Me.GridColumnrmt_trf, Me.GridColumnid_report_order, Me.GridColumnrmt_order, Me.GridColumntrf_order_number, Me.GridColumntrf_number, Me.GridColumnsales_order_number, Me.GridColumn39, Me.GridColumn, Me.GridColumnFailReason, Me.GridColumnnote_promo, Me.GridColumncomp_group_name})
        Me.GVVolcom.GridControl = Me.GCVolcom
        Me.GVVolcom.Name = "GVVolcom"
        Me.GVVolcom.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVVolcom.OptionsFind.AlwaysVisible = True
        Me.GVVolcom.OptionsView.ColumnAutoWidth = False
        Me.GVVolcom.OptionsView.ShowFooter = True
        Me.GVVolcom.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid
        '
        Me.GridColumnid.Caption = "id"
        Me.GridColumnid.FieldName = "id"
        Me.GridColumnid.Name = "GridColumnid"
        Me.GridColumnid.OptionsColumn.ReadOnly = True
        '
        'GridColumnsales_order_ol_shop_number
        '
        Me.GridColumnsales_order_ol_shop_number.Caption = "Order Number"
        Me.GridColumnsales_order_ol_shop_number.FieldName = "sales_order_ol_shop_number"
        Me.GridColumnsales_order_ol_shop_number.Name = "GridColumnsales_order_ol_shop_number"
        Me.GridColumnsales_order_ol_shop_number.OptionsColumn.ReadOnly = True
        Me.GridColumnsales_order_ol_shop_number.Visible = True
        Me.GridColumnsales_order_ol_shop_number.VisibleIndex = 1
        '
        'GridColumnsales_order_ol_shop_date
        '
        Me.GridColumnsales_order_ol_shop_date.Caption = "Order Date"
        Me.GridColumnsales_order_ol_shop_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnsales_order_ol_shop_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_order_ol_shop_date.FieldName = "sales_order_ol_shop_date"
        Me.GridColumnsales_order_ol_shop_date.Name = "GridColumnsales_order_ol_shop_date"
        Me.GridColumnsales_order_ol_shop_date.OptionsColumn.ReadOnly = True
        Me.GridColumnsales_order_ol_shop_date.Visible = True
        Me.GridColumnsales_order_ol_shop_date.VisibleIndex = 2
        '
        'GridColumncustomer_name
        '
        Me.GridColumncustomer_name.Caption = "Customer"
        Me.GridColumncustomer_name.FieldName = "customer_name"
        Me.GridColumncustomer_name.Name = "GridColumncustomer_name"
        Me.GridColumncustomer_name.OptionsColumn.ReadOnly = True
        Me.GridColumncustomer_name.Visible = True
        Me.GridColumncustomer_name.VisibleIndex = 3
        '
        'GridColumnshipping_name
        '
        Me.GridColumnshipping_name.Caption = "Shipping Name"
        Me.GridColumnshipping_name.FieldName = "shipping_name"
        Me.GridColumnshipping_name.Name = "GridColumnshipping_name"
        Me.GridColumnshipping_name.OptionsColumn.ReadOnly = True
        Me.GridColumnshipping_name.Visible = True
        Me.GridColumnshipping_name.VisibleIndex = 4
        '
        'GridColumnshipping_address
        '
        Me.GridColumnshipping_address.Caption = "Shipping Address"
        Me.GridColumnshipping_address.FieldName = "shipping_address"
        Me.GridColumnshipping_address.Name = "GridColumnshipping_address"
        Me.GridColumnshipping_address.OptionsColumn.ReadOnly = True
        Me.GridColumnshipping_address.Visible = True
        Me.GridColumnshipping_address.VisibleIndex = 5
        '
        'GridColumnshipping_phone
        '
        Me.GridColumnshipping_phone.Caption = "Shipping Phone"
        Me.GridColumnshipping_phone.FieldName = "shipping_phone"
        Me.GridColumnshipping_phone.Name = "GridColumnshipping_phone"
        Me.GridColumnshipping_phone.OptionsColumn.ReadOnly = True
        Me.GridColumnshipping_phone.Visible = True
        Me.GridColumnshipping_phone.VisibleIndex = 6
        '
        'GridColumnshipping_city
        '
        Me.GridColumnshipping_city.Caption = "Shipping City"
        Me.GridColumnshipping_city.FieldName = "shipping_city"
        Me.GridColumnshipping_city.Name = "GridColumnshipping_city"
        Me.GridColumnshipping_city.OptionsColumn.ReadOnly = True
        Me.GridColumnshipping_city.Visible = True
        Me.GridColumnshipping_city.VisibleIndex = 7
        '
        'GridColumnshipping_post_code
        '
        Me.GridColumnshipping_post_code.Caption = "Postal Code"
        Me.GridColumnshipping_post_code.FieldName = "shipping_post_code"
        Me.GridColumnshipping_post_code.Name = "GridColumnshipping_post_code"
        Me.GridColumnshipping_post_code.OptionsColumn.ReadOnly = True
        Me.GridColumnshipping_post_code.Visible = True
        Me.GridColumnshipping_post_code.VisibleIndex = 8
        '
        'GridColumnshipping_region
        '
        Me.GridColumnshipping_region.Caption = "Shipping Region"
        Me.GridColumnshipping_region.FieldName = "shipping_region"
        Me.GridColumnshipping_region.Name = "GridColumnshipping_region"
        Me.GridColumnshipping_region.OptionsColumn.ReadOnly = True
        Me.GridColumnshipping_region.Visible = True
        Me.GridColumnshipping_region.VisibleIndex = 9
        '
        'GridColumnpayment_method
        '
        Me.GridColumnpayment_method.Caption = "Payment Method"
        Me.GridColumnpayment_method.FieldName = "payment_method"
        Me.GridColumnpayment_method.Name = "GridColumnpayment_method"
        Me.GridColumnpayment_method.OptionsColumn.ReadOnly = True
        Me.GridColumnpayment_method.Visible = True
        Me.GridColumnpayment_method.VisibleIndex = 10
        '
        'GridColumntracking_code
        '
        Me.GridColumntracking_code.Caption = "Tracking Code"
        Me.GridColumntracking_code.FieldName = "tracking_code"
        Me.GridColumntracking_code.Name = "GridColumntracking_code"
        Me.GridColumntracking_code.OptionsColumn.ReadOnly = True
        Me.GridColumntracking_code.Visible = True
        Me.GridColumntracking_code.VisibleIndex = 11
        '
        'GridColumnol_store_sku
        '
        Me.GridColumnol_store_sku.Caption = "ID SKU"
        Me.GridColumnol_store_sku.FieldName = "ol_store_sku"
        Me.GridColumnol_store_sku.Name = "GridColumnol_store_sku"
        Me.GridColumnol_store_sku.OptionsColumn.ReadOnly = True
        Me.GridColumnol_store_sku.Visible = True
        Me.GridColumnol_store_sku.VisibleIndex = 12
        '
        'GridColumnol_store_id
        '
        Me.GridColumnol_store_id.Caption = "OL Store ID"
        Me.GridColumnol_store_id.FieldName = "ol_store_id"
        Me.GridColumnol_store_id.Name = "GridColumnol_store_id"
        Me.GridColumnol_store_id.OptionsColumn.ReadOnly = True
        Me.GridColumnol_store_id.Visible = True
        Me.GridColumnol_store_id.VisibleIndex = 13
        '
        'GridColumnsku
        '
        Me.GridColumnsku.Caption = "SKU"
        Me.GridColumnsku.FieldName = "sku"
        Me.GridColumnsku.Name = "GridColumnsku"
        Me.GridColumnsku.OptionsColumn.ReadOnly = True
        Me.GridColumnsku.Visible = True
        Me.GridColumnsku.VisibleIndex = 14
        '
        'GridColumndesign_price
        '
        Me.GridColumndesign_price.Caption = "Price"
        Me.GridColumndesign_price.DisplayFormat.FormatString = "N0"
        Me.GridColumndesign_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndesign_price.FieldName = "design_price"
        Me.GridColumndesign_price.Name = "GridColumndesign_price"
        Me.GridColumndesign_price.OptionsColumn.ReadOnly = True
        Me.GridColumndesign_price.Visible = True
        Me.GridColumndesign_price.VisibleIndex = 15
        '
        'GridColumnsales_order_det_qty
        '
        Me.GridColumnsales_order_det_qty.Caption = "Qty"
        Me.GridColumnsales_order_det_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumnsales_order_det_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsales_order_det_qty.FieldName = "sales_order_det_qty"
        Me.GridColumnsales_order_det_qty.Name = "GridColumnsales_order_det_qty"
        Me.GridColumnsales_order_det_qty.OptionsColumn.ReadOnly = True
        Me.GridColumnsales_order_det_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_order_det_qty", "{0:N0}")})
        Me.GridColumnsales_order_det_qty.Visible = True
        Me.GridColumnsales_order_det_qty.VisibleIndex = 16
        '
        'GridColumnis_process
        '
        Me.GridColumnis_process.Caption = "Processed"
        Me.GridColumnis_process.FieldName = "is_process"
        Me.GridColumnis_process.Name = "GridColumnis_process"
        Me.GridColumnis_process.OptionsColumn.ReadOnly = True
        '
        'GridColumnnote_price
        '
        Me.GridColumnnote_price.Caption = "Note Price"
        Me.GridColumnnote_price.FieldName = "note_price"
        Me.GridColumnnote_price.Name = "GridColumnnote_price"
        Me.GridColumnnote_price.OptionsColumn.ReadOnly = True
        Me.GridColumnnote_price.Visible = True
        Me.GridColumnnote_price.VisibleIndex = 18
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "id_design_cat"
        Me.GridColumn1.FieldName = "id_design_cat"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        '
        'GridColumnid_design_price
        '
        Me.GridColumnid_design_price.Caption = "id_design_price"
        Me.GridColumnid_design_price.FieldName = "id_design_price"
        Me.GridColumnid_design_price.Name = "GridColumnid_design_price"
        Me.GridColumnid_design_price.OptionsColumn.ReadOnly = True
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "id_product"
        Me.GridColumn2.FieldName = "id_product"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        '
        'GridColumnnote_stock
        '
        Me.GridColumnnote_stock.Caption = "Note Stock"
        Me.GridColumnnote_stock.FieldName = "note_stock"
        Me.GridColumnnote_stock.Name = "GridColumnnote_stock"
        Me.GridColumnnote_stock.OptionsColumn.ReadOnly = True
        Me.GridColumnnote_stock.Visible = True
        Me.GridColumnnote_stock.VisibleIndex = 19
        '
        'GridColumnid_report_trf_order
        '
        Me.GridColumnid_report_trf_order.Caption = "id_report_trf_order"
        Me.GridColumnid_report_trf_order.FieldName = "id_report_trf_order"
        Me.GridColumnid_report_trf_order.Name = "GridColumnid_report_trf_order"
        Me.GridColumnid_report_trf_order.OptionsColumn.ReadOnly = True
        '
        'GridColumnrmt_trf_order
        '
        Me.GridColumnrmt_trf_order.Caption = "rmt_trf_order"
        Me.GridColumnrmt_trf_order.FieldName = "rmt_trf_order"
        Me.GridColumnrmt_trf_order.Name = "GridColumnrmt_trf_order"
        Me.GridColumnrmt_trf_order.OptionsColumn.ReadOnly = True
        '
        'GridColumnid_report_trf
        '
        Me.GridColumnid_report_trf.Caption = "id_report_trf"
        Me.GridColumnid_report_trf.FieldName = "id_report_trf"
        Me.GridColumnid_report_trf.Name = "GridColumnid_report_trf"
        Me.GridColumnid_report_trf.OptionsColumn.ReadOnly = True
        '
        'GridColumnrmt_trf
        '
        Me.GridColumnrmt_trf.Caption = "rmt_trf"
        Me.GridColumnrmt_trf.FieldName = "rmt_trf"
        Me.GridColumnrmt_trf.Name = "GridColumnrmt_trf"
        Me.GridColumnrmt_trf.OptionsColumn.ReadOnly = True
        '
        'GridColumnid_report_order
        '
        Me.GridColumnid_report_order.Caption = "id_report_order"
        Me.GridColumnid_report_order.FieldName = "id_report_order"
        Me.GridColumnid_report_order.Name = "GridColumnid_report_order"
        Me.GridColumnid_report_order.OptionsColumn.ReadOnly = True
        '
        'GridColumnrmt_order
        '
        Me.GridColumnrmt_order.Caption = "rmt_order"
        Me.GridColumnrmt_order.FieldName = "rmt_order"
        Me.GridColumnrmt_order.Name = "GridColumnrmt_order"
        Me.GridColumnrmt_order.OptionsColumn.ReadOnly = True
        '
        'GridColumntrf_order_number
        '
        Me.GridColumntrf_order_number.Caption = "Transfer Order"
        Me.GridColumntrf_order_number.ColumnEdit = Me.LinkTrfOrder
        Me.GridColumntrf_order_number.FieldName = "trf_order_number"
        Me.GridColumntrf_order_number.Name = "GridColumntrf_order_number"
        Me.GridColumntrf_order_number.OptionsColumn.ReadOnly = True
        Me.GridColumntrf_order_number.Visible = True
        Me.GridColumntrf_order_number.VisibleIndex = 21
        '
        'LinkTrfOrder
        '
        Me.LinkTrfOrder.AutoHeight = False
        Me.LinkTrfOrder.Name = "LinkTrfOrder"
        '
        'GridColumntrf_number
        '
        Me.GridColumntrf_number.Caption = "Transfer"
        Me.GridColumntrf_number.ColumnEdit = Me.LinkTrf
        Me.GridColumntrf_number.FieldName = "trf_number"
        Me.GridColumntrf_number.Name = "GridColumntrf_number"
        Me.GridColumntrf_number.OptionsColumn.ReadOnly = True
        Me.GridColumntrf_number.Visible = True
        Me.GridColumntrf_number.VisibleIndex = 22
        '
        'LinkTrf
        '
        Me.LinkTrf.AutoHeight = False
        Me.LinkTrf.Name = "LinkTrf"
        '
        'GridColumnsales_order_number
        '
        Me.GridColumnsales_order_number.Caption = "Sales Order"
        Me.GridColumnsales_order_number.ColumnEdit = Me.LinkSalesOrder
        Me.GridColumnsales_order_number.FieldName = "sales_order_number"
        Me.GridColumnsales_order_number.Name = "GridColumnsales_order_number"
        Me.GridColumnsales_order_number.OptionsColumn.ReadOnly = True
        Me.GridColumnsales_order_number.Visible = True
        Me.GridColumnsales_order_number.VisibleIndex = 23
        '
        'LinkSalesOrder
        '
        Me.LinkSalesOrder.AutoHeight = False
        Me.LinkSalesOrder.Name = "LinkSalesOrder"
        '
        'GridColumn39
        '
        Me.GridColumn39.Caption = "Confirmed Order"
        Me.GridColumn39.FieldName = "is_process_view"
        Me.GridColumn39.Name = "GridColumn39"
        Me.GridColumn39.OptionsColumn.ReadOnly = True
        Me.GridColumn39.Visible = True
        Me.GridColumn39.VisibleIndex = 24
        '
        'GridColumn
        '
        Me.GridColumn.Caption = "Financial Status"
        Me.GridColumn.Name = "GridColumn"
        Me.GridColumn.OptionsColumn.ReadOnly = True
        Me.GridColumn.Visible = True
        Me.GridColumn.VisibleIndex = 17
        '
        'GridColumnFailReason
        '
        Me.GridColumnFailReason.Caption = "Fail Reason"
        Me.GridColumnFailReason.FieldName = "fail_reason"
        Me.GridColumnFailReason.Name = "GridColumnFailReason"
        Me.GridColumnFailReason.OptionsColumn.ReadOnly = True
        Me.GridColumnFailReason.Visible = True
        Me.GridColumnFailReason.VisibleIndex = 25
        '
        'GridColumnnote_promo
        '
        Me.GridColumnnote_promo.Caption = "Note Promo"
        Me.GridColumnnote_promo.FieldName = "note_promo"
        Me.GridColumnnote_promo.Name = "GridColumnnote_promo"
        Me.GridColumnnote_promo.Visible = True
        Me.GridColumnnote_promo.VisibleIndex = 20
        '
        'GridColumncomp_group_name
        '
        Me.GridColumncomp_group_name.Caption = "Store"
        Me.GridColumncomp_group_name.FieldName = "comp_group_name"
        Me.GridColumncomp_group_name.Name = "GridColumncomp_group_name"
        Me.GridColumncomp_group_name.OptionsColumn.ReadOnly = True
        Me.GridColumncomp_group_name.Visible = True
        Me.GridColumncomp_group_name.VisibleIndex = 0
        '
        'RICEIsCheck
        '
        Me.RICEIsCheck.AutoHeight = False
        Me.RICEIsCheck.Name = "RICEIsCheck"
        Me.RICEIsCheck.ValueChecked = "yes"
        Me.RICEIsCheck.ValueUnchecked = "no"
        '
        'BtnPrintDetailOrder
        '
        Me.BtnPrintDetailOrder.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnPrintDetailOrder.Location = New System.Drawing.Point(0, 378)
        Me.BtnPrintDetailOrder.Name = "BtnPrintDetailOrder"
        Me.BtnPrintDetailOrder.Size = New System.Drawing.Size(974, 23)
        Me.BtnPrintDetailOrder.TabIndex = 2
        Me.BtnPrintDetailOrder.Text = "Print List"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.TxtCustomer)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Controls.Add(Me.TxtOrderNo)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.TxtMarketplaceName)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.TxtOOSNo)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(980, 87)
        Me.PanelControl2.TabIndex = 2
        '
        'TxtCustomer
        '
        Me.TxtCustomer.EditValue = ""
        Me.TxtCustomer.Location = New System.Drawing.Point(459, 42)
        Me.TxtCustomer.Name = "TxtCustomer"
        Me.TxtCustomer.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCustomer.Properties.Appearance.Options.UseFont = True
        Me.TxtCustomer.Properties.ReadOnly = True
        Me.TxtCustomer.Size = New System.Drawing.Size(283, 22)
        Me.TxtCustomer.TabIndex = 7
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(369, 45)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(55, 16)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "Customer"
        '
        'TxtOrderNo
        '
        Me.TxtOrderNo.EditValue = ""
        Me.TxtOrderNo.Location = New System.Drawing.Point(89, 42)
        Me.TxtOrderNo.Name = "TxtOrderNo"
        Me.TxtOrderNo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOrderNo.Properties.Appearance.Options.UseFont = True
        Me.TxtOrderNo.Properties.ReadOnly = True
        Me.TxtOrderNo.Size = New System.Drawing.Size(269, 22)
        Me.TxtOrderNo.TabIndex = 5
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(19, 45)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(56, 16)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Order No."
        '
        'TxtMarketplaceName
        '
        Me.TxtMarketplaceName.EditValue = ""
        Me.TxtMarketplaceName.Location = New System.Drawing.Point(459, 14)
        Me.TxtMarketplaceName.Name = "TxtMarketplaceName"
        Me.TxtMarketplaceName.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMarketplaceName.Properties.Appearance.Options.UseFont = True
        Me.TxtMarketplaceName.Properties.ReadOnly = True
        Me.TxtMarketplaceName.Size = New System.Drawing.Size(283, 22)
        Me.TxtMarketplaceName.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(369, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(80, 16)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Marketplace"
        '
        'TxtOOSNo
        '
        Me.TxtOOSNo.EditValue = ""
        Me.TxtOOSNo.Location = New System.Drawing.Point(89, 14)
        Me.TxtOOSNo.Name = "TxtOOSNo"
        Me.TxtOOSNo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOOSNo.Properties.Appearance.Options.UseFont = True
        Me.TxtOOSNo.Properties.ReadOnly = True
        Me.TxtOOSNo.Size = New System.Drawing.Size(269, 22)
        Me.TxtOOSNo.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(19, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(50, 16)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "OOS No."
        '
        'BtnSendEmail
        '
        Me.BtnSendEmail.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSendEmail.Image = CType(resources.GetObject("BtnSendEmail.Image"), System.Drawing.Image)
        Me.BtnSendEmail.Location = New System.Drawing.Point(826, 2)
        Me.BtnSendEmail.Name = "BtnSendEmail"
        Me.BtnSendEmail.Size = New System.Drawing.Size(152, 41)
        Me.BtnSendEmail.TabIndex = 0
        Me.BtnSendEmail.Text = "Manually Send Email"
        Me.BtnSendEmail.Visible = False
        '
        'BtnClosedOrder
        '
        Me.BtnClosedOrder.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClosedOrder.Appearance.Options.UseFont = True
        Me.BtnClosedOrder.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClosedOrder.Image = CType(resources.GetObject("BtnClosedOrder.Image"), System.Drawing.Image)
        Me.BtnClosedOrder.Location = New System.Drawing.Point(553, 2)
        Me.BtnClosedOrder.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnClosedOrder.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnClosedOrder.Name = "BtnClosedOrder"
        Me.BtnClosedOrder.Size = New System.Drawing.Size(185, 41)
        Me.BtnClosedOrder.TabIndex = 1
        Me.BtnClosedOrder.Text = "Confirm as Partial Order"
        Me.BtnClosedOrder.Visible = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnAttachment)
        Me.PanelControl1.Controls.Add(Me.BtnCancellAllOrder)
        Me.PanelControl1.Controls.Add(Me.BtnLog)
        Me.PanelControl1.Controls.Add(Me.BtnClosedOrder)
        Me.PanelControl1.Controls.Add(Me.BtnConfirmRestock)
        Me.PanelControl1.Controls.Add(Me.BtnSendEmail)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 516)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(980, 45)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnAttachment
        '
        Me.BtnAttachment.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnAttachment.Image = CType(resources.GetObject("BtnAttachment.Image"), System.Drawing.Image)
        Me.BtnAttachment.Location = New System.Drawing.Point(83, 2)
        Me.BtnAttachment.Name = "BtnAttachment"
        Me.BtnAttachment.Size = New System.Drawing.Size(108, 41)
        Me.BtnAttachment.TabIndex = 5
        Me.BtnAttachment.Text = "Attachment"
        '
        'BtnCancellAllOrder
        '
        Me.BtnCancellAllOrder.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancellAllOrder.Appearance.Options.UseFont = True
        Me.BtnCancellAllOrder.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancellAllOrder.Image = CType(resources.GetObject("BtnCancellAllOrder.Image"), System.Drawing.Image)
        Me.BtnCancellAllOrder.Location = New System.Drawing.Point(430, 2)
        Me.BtnCancellAllOrder.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnCancellAllOrder.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnCancellAllOrder.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnCancellAllOrder.Name = "BtnCancellAllOrder"
        Me.BtnCancellAllOrder.Size = New System.Drawing.Size(123, 41)
        Me.BtnCancellAllOrder.TabIndex = 4
        Me.BtnCancellAllOrder.Text = "Cancel Order"
        Me.BtnCancellAllOrder.Visible = False
        '
        'BtnLog
        '
        Me.BtnLog.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnLog.Image = CType(resources.GetObject("BtnLog.Image"), System.Drawing.Image)
        Me.BtnLog.Location = New System.Drawing.Point(2, 2)
        Me.BtnLog.Name = "BtnLog"
        Me.BtnLog.Size = New System.Drawing.Size(81, 41)
        Me.BtnLog.TabIndex = 2
        Me.BtnLog.Text = "Log"
        '
        'BtnConfirmRestock
        '
        Me.BtnConfirmRestock.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnConfirmRestock.Image = CType(resources.GetObject("BtnConfirmRestock.Image"), System.Drawing.Image)
        Me.BtnConfirmRestock.Location = New System.Drawing.Point(738, 2)
        Me.BtnConfirmRestock.Name = "BtnConfirmRestock"
        Me.BtnConfirmRestock.Size = New System.Drawing.Size(88, 41)
        Me.BtnConfirmRestock.TabIndex = 3
        Me.BtnConfirmRestock.Text = "Confirm"
        Me.BtnConfirmRestock.Visible = False
        '
        'GridColumnacc_from
        '
        Me.GridColumnacc_from.Caption = "From"
        Me.GridColumnacc_from.FieldName = "acc_from"
        Me.GridColumnacc_from.Name = "GridColumnacc_from"
        Me.GridColumnacc_from.Visible = True
        Me.GridColumnacc_from.VisibleIndex = 1
        '
        'GridColumnacc_to
        '
        Me.GridColumnacc_to.Caption = "To"
        Me.GridColumnacc_to.FieldName = "acc_to"
        Me.GridColumnacc_to.Name = "GridColumnacc_to"
        Me.GridColumnacc_to.Visible = True
        Me.GridColumnacc_to.VisibleIndex = 2
        '
        'FormOLStoreOOSDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 561)
        Me.Controls.Add(Me.XTCData)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "FormOLStoreOOSDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OOS - Detail Information"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPProduct.ResumeLayout(False)
        CType(Me.SCCOOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCCOOS.ResumeLayout(False)
        CType(Me.GroupControlProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlProduct.ResumeLayout(False)
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoBtnRestock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlRestock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlRestock.ResumeLayout(False)
        CType(Me.GCRestock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRestock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPSync.ResumeLayout(False)
        CType(Me.GCVolcom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVVolcom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LinkTrfOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LinkTrf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LinkSalesOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEIsCheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.TxtCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOrderNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMarketplaceName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOOSNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPProduct As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPSync As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents SCCOOS As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlProduct As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControlRestock As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCRestock As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRestock As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnPrintProduct As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrintSyncList As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TxtMarketplaceName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtOOSNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnSendEmail As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnClosedOrder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TxtCustomer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtOrderNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnLog As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_product As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnorder_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnso_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnno_stock_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnrsv_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_poss_replace As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_poss_replace_view As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_design_cat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnbtn_restock As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoBtnRestock As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents BtnConfirmRestock As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrintDetailOrder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCVolcom As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVVolcom As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_ol_shop_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_ol_shop_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncustomer_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnshipping_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnshipping_address As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnshipping_phone As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnshipping_city As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnshipping_post_code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnshipping_region As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpayment_method As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntracking_code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnol_store_sku As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnol_store_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsku As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_det_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_process As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_design_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote_stock As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_report_trf_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnrmt_trf_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_report_trf As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnrmt_trf As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_report_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnrmt_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntrf_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LinkTrfOrder As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents GridColumntrf_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LinkTrf As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents GridColumnsales_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LinkSalesOrder As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFailReason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote_promo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICEIsCheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnid_sales_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_number_restock As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_prepare_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty_too As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty_trf As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndiff_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnprepare_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnCancellAllOrder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnacc_from As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnacc_to As DevExpress.XtraGrid.Columns.GridColumn
End Class
