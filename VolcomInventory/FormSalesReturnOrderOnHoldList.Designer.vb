<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesReturnOrderOnHoldList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesReturnOrderOnHoldList))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GCOnHold = New DevExpress.XtraGrid.GridControl()
        Me.GVOnHold = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_sales_return_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_sales_return_order_det = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_return_order_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_return_order_est_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1sales_return_order_est_del_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstore = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_product = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_return_order_det_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_cat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_return_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancell = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumnqty_soh = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty_ror = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCOnHold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOnHold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancell)
        Me.PanelControl1.Controls.Add(Me.BtnAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 424)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(750, 43)
        Me.PanelControl1.TabIndex = 0
        '
        'GCOnHold
        '
        Me.GCOnHold.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOnHold.Location = New System.Drawing.Point(0, 0)
        Me.GCOnHold.MainView = Me.GVOnHold
        Me.GCOnHold.Name = "GCOnHold"
        Me.GCOnHold.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.GCOnHold.Size = New System.Drawing.Size(750, 424)
        Me.GCOnHold.TabIndex = 2
        Me.GCOnHold.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOnHold})
        '
        'GVOnHold
        '
        Me.GVOnHold.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_sales_return_order, Me.GridColumnid_sales_return_order_det, Me.GridColumnsales_return_order_date, Me.GridColumnsales_return_order_est_date, Me.GridColumn1sales_return_order_est_del_date, Me.GridColumnstore, Me.GridColumnid_product, Me.GridColumncode, Me.GridColumnname, Me.GridColumnsize, Me.GridColumnsales_return_order_det_qty, Me.GridColumndesign_price, Me.GridColumndesign_cat, Me.GridColumnsales_return_order_number, Me.GridColumnqty_soh, Me.GridColumnqty_ror})
        Me.GVOnHold.GridControl = Me.GCOnHold
        Me.GVOnHold.Name = "GVOnHold"
        Me.GVOnHold.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVOnHold.OptionsFind.AlwaysVisible = True
        Me.GVOnHold.OptionsView.ColumnAutoWidth = False
        Me.GVOnHold.OptionsView.ShowFooter = True
        Me.GVOnHold.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_sales_return_order
        '
        Me.GridColumnid_sales_return_order.Caption = "Id "
        Me.GridColumnid_sales_return_order.FieldName = "id_sales_return_order"
        Me.GridColumnid_sales_return_order.Name = "GridColumnid_sales_return_order"
        Me.GridColumnid_sales_return_order.OptionsColumn.AllowEdit = False
        '
        'GridColumnid_sales_return_order_det
        '
        Me.GridColumnid_sales_return_order_det.Caption = "Id Detail"
        Me.GridColumnid_sales_return_order_det.FieldName = "id_sales_return_order_det"
        Me.GridColumnid_sales_return_order_det.Name = "GridColumnid_sales_return_order_det"
        Me.GridColumnid_sales_return_order_det.OptionsColumn.AllowEdit = False
        '
        'GridColumnsales_return_order_date
        '
        Me.GridColumnsales_return_order_date.Caption = "Created Date"
        Me.GridColumnsales_return_order_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_return_order_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_return_order_date.FieldName = "sales_return_order_date"
        Me.GridColumnsales_return_order_date.Name = "GridColumnsales_return_order_date"
        Me.GridColumnsales_return_order_date.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_return_order_date.Visible = True
        Me.GridColumnsales_return_order_date.VisibleIndex = 0
        '
        'GridColumnsales_return_order_est_date
        '
        Me.GridColumnsales_return_order_est_date.Caption = "Est. Return Date"
        Me.GridColumnsales_return_order_est_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_return_order_est_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_return_order_est_date.FieldName = "sales_return_order_est_date"
        Me.GridColumnsales_return_order_est_date.Name = "GridColumnsales_return_order_est_date"
        Me.GridColumnsales_return_order_est_date.OptionsColumn.AllowEdit = False
        '
        'GridColumn1sales_return_order_est_del_date
        '
        Me.GridColumn1sales_return_order_est_del_date.Caption = "Est. Delivery Date"
        Me.GridColumn1sales_return_order_est_del_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn1sales_return_order_est_del_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn1sales_return_order_est_del_date.FieldName = "sales_return_order_est_del_date"
        Me.GridColumn1sales_return_order_est_del_date.Name = "GridColumn1sales_return_order_est_del_date"
        Me.GridColumn1sales_return_order_est_del_date.OptionsColumn.AllowEdit = False
        '
        'GridColumnstore
        '
        Me.GridColumnstore.Caption = "Store"
        Me.GridColumnstore.FieldName = "store"
        Me.GridColumnstore.Name = "GridColumnstore"
        Me.GridColumnstore.OptionsColumn.AllowEdit = False
        '
        'GridColumnid_product
        '
        Me.GridColumnid_product.Caption = "Id Product"
        Me.GridColumnid_product.FieldName = "id_product"
        Me.GridColumnid_product.Name = "GridColumnid_product"
        Me.GridColumnid_product.OptionsColumn.AllowEdit = False
        '
        'GridColumncode
        '
        Me.GridColumncode.Caption = "Code"
        Me.GridColumncode.FieldName = "code"
        Me.GridColumncode.Name = "GridColumncode"
        Me.GridColumncode.OptionsColumn.AllowEdit = False
        Me.GridColumncode.Visible = True
        Me.GridColumncode.VisibleIndex = 1
        '
        'GridColumnname
        '
        Me.GridColumnname.Caption = "Description"
        Me.GridColumnname.FieldName = "name"
        Me.GridColumnname.Name = "GridColumnname"
        Me.GridColumnname.OptionsColumn.AllowEdit = False
        Me.GridColumnname.Visible = True
        Me.GridColumnname.VisibleIndex = 2
        '
        'GridColumnsize
        '
        Me.GridColumnsize.Caption = "Size"
        Me.GridColumnsize.FieldName = "size"
        Me.GridColumnsize.Name = "GridColumnsize"
        Me.GridColumnsize.OptionsColumn.AllowEdit = False
        Me.GridColumnsize.Visible = True
        Me.GridColumnsize.VisibleIndex = 3
        '
        'GridColumnsales_return_order_det_qty
        '
        Me.GridColumnsales_return_order_det_qty.Caption = "On Hold Qty"
        Me.GridColumnsales_return_order_det_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumnsales_return_order_det_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsales_return_order_det_qty.FieldName = "sales_return_order_det_qty"
        Me.GridColumnsales_return_order_det_qty.Name = "GridColumnsales_return_order_det_qty"
        Me.GridColumnsales_return_order_det_qty.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_return_order_det_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_return_order_det_qty", "{0:N0}")})
        Me.GridColumnsales_return_order_det_qty.Visible = True
        Me.GridColumnsales_return_order_det_qty.VisibleIndex = 6
        '
        'GridColumndesign_price
        '
        Me.GridColumndesign_price.Caption = "Price"
        Me.GridColumndesign_price.DisplayFormat.FormatString = "N0"
        Me.GridColumndesign_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndesign_price.FieldName = "design_price"
        Me.GridColumndesign_price.Name = "GridColumndesign_price"
        Me.GridColumndesign_price.OptionsColumn.AllowEdit = False
        Me.GridColumndesign_price.Visible = True
        Me.GridColumndesign_price.VisibleIndex = 4
        '
        'GridColumndesign_cat
        '
        Me.GridColumndesign_cat.Caption = "Price Status"
        Me.GridColumndesign_cat.FieldName = "design_cat"
        Me.GridColumndesign_cat.Name = "GridColumndesign_cat"
        Me.GridColumndesign_cat.OptionsColumn.AllowEdit = False
        Me.GridColumndesign_cat.Visible = True
        Me.GridColumndesign_cat.VisibleIndex = 5
        '
        'GridColumnsales_return_order_number
        '
        Me.GridColumnsales_return_order_number.Caption = "ROR#"
        Me.GridColumnsales_return_order_number.FieldName = "sales_return_order_number"
        Me.GridColumnsales_return_order_number.Name = "GridColumnsales_return_order_number"
        Me.GridColumnsales_return_order_number.OptionsColumn.AllowEdit = False
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(664, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(84, 39)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "Add"
        '
        'BtnCancell
        '
        Me.BtnCancell.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancell.Image = CType(resources.GetObject("BtnCancell.Image"), System.Drawing.Image)
        Me.BtnCancell.Location = New System.Drawing.Point(578, 2)
        Me.BtnCancell.Name = "BtnCancell"
        Me.BtnCancell.Size = New System.Drawing.Size(86, 39)
        Me.BtnCancell.TabIndex = 1
        Me.BtnCancell.Text = "Cancell"
        '
        'GridColumnqty_soh
        '
        Me.GridColumnqty_soh.Caption = "SOH Qty"
        Me.GridColumnqty_soh.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty_soh.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty_soh.FieldName = "qty_soh"
        Me.GridColumnqty_soh.Name = "GridColumnqty_soh"
        Me.GridColumnqty_soh.OptionsColumn.AllowEdit = False
        Me.GridColumnqty_soh.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_soh", "{0:N0}")})
        Me.GridColumnqty_soh.Visible = True
        Me.GridColumnqty_soh.VisibleIndex = 7
        '
        'GridColumnqty_ror
        '
        Me.GridColumnqty_ror.Caption = "ROR Qty"
        Me.GridColumnqty_ror.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnqty_ror.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty_ror.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty_ror.FieldName = "qty_ror"
        Me.GridColumnqty_ror.Name = "GridColumnqty_ror"
        Me.GridColumnqty_ror.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ror", "{0:N0}")})
        Me.GridColumnqty_ror.Visible = True
        Me.GridColumnqty_ror.VisibleIndex = 8
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatString = "n0"
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.Mask.EditMask = "n0"
        Me.RepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'FormSalesReturnOrderOnHoldList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(750, 467)
        Me.Controls.Add(Me.GCOnHold)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormSalesReturnOrderOnHoldList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "On Hold List"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCOnHold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOnHold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancell As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCOnHold As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOnHold As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_sales_return_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_sales_return_order_det As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_return_order_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_return_order_est_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1sales_return_order_est_del_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstore As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_product As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_return_order_det_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_cat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_return_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty_soh As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty_ror As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
