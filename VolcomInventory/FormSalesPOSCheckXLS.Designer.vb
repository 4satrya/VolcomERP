<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesPOSCheckXLS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesPOSCheckXLS))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSkip = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnERPOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnItemId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOLStoreId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRetOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnComp = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Controls.Add(Me.BtnDiscard)
        Me.PanelControl1.Controls.Add(Me.BtnSkip)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 413)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(891, 47)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(2, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(88, 43)
        Me.BtnPrint.TabIndex = 2
        Me.BtnPrint.Text = "Print"
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Image = CType(resources.GetObject("BtnDiscard.Image"), System.Drawing.Image)
        Me.BtnDiscard.Location = New System.Drawing.Point(674, 2)
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(88, 43)
        Me.BtnDiscard.TabIndex = 1
        Me.BtnDiscard.Text = "Discard"
        '
        'BtnSkip
        '
        Me.BtnSkip.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSkip.Image = CType(resources.GetObject("BtnSkip.Image"), System.Drawing.Image)
        Me.BtnSkip.Location = New System.Drawing.Point(762, 2)
        Me.BtnSkip.Name = "BtnSkip"
        Me.BtnSkip.Size = New System.Drawing.Size(127, 43)
        Me.BtnSkip.TabIndex = 0
        Me.BtnSkip.Text = "Skip these orders"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(891, 413)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnOrder, Me.GridColumnERPOrder, Me.GridColumn1, Me.GridColumnQty, Me.GridColumnStatus, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumnItemId, Me.GridColumnOLStoreId, Me.GridColumnRetOrder, Me.GridColumnComp})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        Me.GVData.RowHeight = 22
        '
        'GridColumnOrder
        '
        Me.GridColumnOrder.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnOrder.AppearanceHeader.Options.UseFont = True
        Me.GridColumnOrder.Caption = "Order"
        Me.GridColumnOrder.FieldName = "order"
        Me.GridColumnOrder.Name = "GridColumnOrder"
        Me.GridColumnOrder.Visible = True
        Me.GridColumnOrder.VisibleIndex = 0
        '
        'GridColumnERPOrder
        '
        Me.GridColumnERPOrder.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnERPOrder.AppearanceHeader.Options.UseFont = True
        Me.GridColumnERPOrder.Caption = "ERP Order#"
        Me.GridColumnERPOrder.FieldName = "sales_order_number"
        Me.GridColumnERPOrder.Name = "GridColumnERPOrder"
        Me.GridColumnERPOrder.Visible = True
        Me.GridColumnERPOrder.VisibleIndex = 1
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn1.AppearanceHeader.Options.UseFont = True
        Me.GridColumn1.Caption = "Delivery#"
        Me.GridColumn1.FieldName = "del_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 3
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnQty.AppearanceHeader.Options.UseFont = True
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 11
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnStatus.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnStatus.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnStatus.AppearanceHeader.Options.UseFont = True
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 12
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn2.AppearanceHeader.Options.UseFont = True
        Me.GridColumn2.Caption = "Invoice#"
        Me.GridColumn2.FieldName = "sales_pos_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 4
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn3.AppearanceHeader.Options.UseFont = True
        Me.GridColumn3.Caption = "Code"
        Me.GridColumn3.FieldName = "code"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 8
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn4.AppearanceHeader.Options.UseFont = True
        Me.GridColumn4.Caption = "Description"
        Me.GridColumn4.FieldName = "name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 9
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn5.AppearanceHeader.Options.UseFont = True
        Me.GridColumn5.Caption = "Size"
        Me.GridColumn5.FieldName = "size"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 10
        '
        'GridColumnItemId
        '
        Me.GridColumnItemId.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnItemId.AppearanceHeader.Options.UseFont = True
        Me.GridColumnItemId.Caption = "Item Id"
        Me.GridColumnItemId.FieldName = "item_id"
        Me.GridColumnItemId.Name = "GridColumnItemId"
        Me.GridColumnItemId.Visible = True
        Me.GridColumnItemId.VisibleIndex = 6
        '
        'GridColumnOLStoreId
        '
        Me.GridColumnOLStoreId.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnOLStoreId.AppearanceHeader.Options.UseFont = True
        Me.GridColumnOLStoreId.Caption = "OL Store Id"
        Me.GridColumnOLStoreId.FieldName = "ol_store_id"
        Me.GridColumnOLStoreId.Name = "GridColumnOLStoreId"
        Me.GridColumnOLStoreId.Visible = True
        Me.GridColumnOLStoreId.VisibleIndex = 7
        '
        'GridColumnRetOrder
        '
        Me.GridColumnRetOrder.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnRetOrder.AppearanceHeader.Options.UseFont = True
        Me.GridColumnRetOrder.Caption = "Return Order#"
        Me.GridColumnRetOrder.FieldName = "sales_return_order_number"
        Me.GridColumnRetOrder.Name = "GridColumnRetOrder"
        Me.GridColumnRetOrder.Visible = True
        Me.GridColumnRetOrder.VisibleIndex = 5
        '
        'GridColumnComp
        '
        Me.GridColumnComp.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnComp.AppearanceHeader.Options.UseFont = True
        Me.GridColumnComp.Caption = "ERP Order - Store"
        Me.GridColumnComp.FieldName = "comp"
        Me.GridColumnComp.Name = "GridColumnComp"
        Me.GridColumnComp.Visible = True
        Me.GridColumnComp.VisibleIndex = 2
        '
        'FormSalesPOSCheckXLS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 460)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormSalesPOSCheckXLS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orders that cannot be processed"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSkip As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnERPOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnItemId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOLStoreId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRetOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnComp As DevExpress.XtraGrid.Columns.GridColumn
End Class
