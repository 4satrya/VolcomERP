﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPSync = New DevExpress.XtraTab.XtraTabPage()
        Me.GCOrder = New DevExpress.XtraGrid.GridControl()
        Me.GVOrder = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.BtnLog = New DevExpress.XtraEditors.SimpleButton()
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
        CType(Me.GCOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOrder, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupControlRestock.Controls.Add(Me.SimpleButton1)
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
        Me.GVRestock.GridControl = Me.GCRestock
        Me.GVRestock.Name = "GVRestock"
        Me.GVRestock.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVRestock.OptionsBehavior.ReadOnly = True
        Me.GVRestock.OptionsFind.AlwaysVisible = True
        Me.GVRestock.OptionsView.ColumnAutoWidth = False
        Me.GVRestock.OptionsView.ShowFooter = True
        Me.GVRestock.OptionsView.ShowGroupPanel = False
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SimpleButton1.Location = New System.Drawing.Point(2, 376)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(355, 23)
        Me.SimpleButton1.TabIndex = 2
        Me.SimpleButton1.Text = "Print Restock Detail"
        '
        'XTPSync
        '
        Me.XTPSync.Controls.Add(Me.GCOrder)
        Me.XTPSync.Name = "XTPSync"
        Me.XTPSync.Size = New System.Drawing.Size(974, 401)
        Me.XTPSync.Text = "Sync Info"
        '
        'GCOrder
        '
        Me.GCOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOrder.Location = New System.Drawing.Point(0, 0)
        Me.GCOrder.MainView = Me.GVOrder
        Me.GCOrder.Name = "GCOrder"
        Me.GCOrder.Size = New System.Drawing.Size(974, 401)
        Me.GCOrder.TabIndex = 1
        Me.GCOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOrder})
        '
        'GVOrder
        '
        Me.GVOrder.GridControl = Me.GCOrder
        Me.GVOrder.Name = "GVOrder"
        Me.GVOrder.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVOrder.OptionsBehavior.ReadOnly = True
        Me.GVOrder.OptionsFind.AlwaysVisible = True
        Me.GVOrder.OptionsView.ColumnAutoWidth = False
        Me.GVOrder.OptionsView.ShowFooter = True
        Me.GVOrder.OptionsView.ShowGroupPanel = False
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
        Me.BtnClosedOrder.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClosedOrder.Image = CType(resources.GetObject("BtnClosedOrder.Image"), System.Drawing.Image)
        Me.BtnClosedOrder.Location = New System.Drawing.Point(723, 2)
        Me.BtnClosedOrder.Name = "BtnClosedOrder"
        Me.BtnClosedOrder.Size = New System.Drawing.Size(103, 41)
        Me.BtnClosedOrder.TabIndex = 1
        Me.BtnClosedOrder.Text = "Close Order"
        Me.BtnClosedOrder.Visible = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnLog)
        Me.PanelControl1.Controls.Add(Me.BtnClosedOrder)
        Me.PanelControl1.Controls.Add(Me.BtnSendEmail)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 516)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(980, 45)
        Me.PanelControl1.TabIndex = 0
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
        'FormOLStoreOOSDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 561)
        Me.Controls.Add(Me.XTCData)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
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
        CType(Me.GCOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOrder, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOrder As DevExpress.XtraGrid.Views.Grid.GridView
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
End Class
