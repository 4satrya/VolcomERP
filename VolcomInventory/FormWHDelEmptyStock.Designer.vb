<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormWHDelEmptyStock
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
        Me.XTCStock = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPStock = New DevExpress.XtraTab.XtraTabPage()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBarcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAvl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReserved = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtStore = New DevExpress.XtraEditors.TextEdit()
        Me.TxtStoreCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.XTCStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCStock.SuspendLayout()
        Me.XTPStock.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TxtStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtStoreCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCStock
        '
        Me.XTCStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCStock.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCStock.Location = New System.Drawing.Point(0, 0)
        Me.XTCStock.Name = "XTCStock"
        Me.XTCStock.SelectedTabPage = Me.XTPStock
        Me.XTCStock.Size = New System.Drawing.Size(723, 325)
        Me.XTCStock.TabIndex = 0
        Me.XTCStock.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPStock})
        '
        'XTPStock
        '
        Me.XTPStock.Controls.Add(Me.GCData)
        Me.XTPStock.Controls.Add(Me.PanelControl1)
        Me.XTPStock.Name = "XTPStock"
        Me.XTPStock.Size = New System.Drawing.Size(717, 297)
        Me.XTPStock.Text = "Non Stock Inventory"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 39)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(717, 258)
        Me.GCData.TabIndex = 1
        Me.GCData.TabStop = False
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnDesign, Me.GridColumnCode, Me.GridColumnBarcode, Me.GridColumnSize, Me.GridColumnAvl, Me.GridColumnReserved, Me.GridColumnTotal, Me.GridColumnPrice})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.GroupCount = 1
        Me.GVData.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_avl", Me.GridColumnAvl, "{0:n0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rsv", Me.GridColumnReserved, "{0:n0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_total", Me.GridColumnTotal, "{0:n0}")})
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        Me.GVData.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDesign, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Design"
        Me.GridColumnDesign.FieldName = "name"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.Visible = True
        Me.GridColumnDesign.VisibleIndex = 2
        Me.GridColumnDesign.Width = 281
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "design_code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 0
        Me.GridColumnCode.Width = 134
        '
        'GridColumnBarcode
        '
        Me.GridColumnBarcode.Caption = "Barcode"
        Me.GridColumnBarcode.FieldName = "product_code"
        Me.GridColumnBarcode.Name = "GridColumnBarcode"
        Me.GridColumnBarcode.Visible = True
        Me.GridColumnBarcode.VisibleIndex = 1
        Me.GridColumnBarcode.Width = 154
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 2
        Me.GridColumnSize.Width = 44
        '
        'GridColumnAvl
        '
        Me.GridColumnAvl.Caption = "Available"
        Me.GridColumnAvl.DisplayFormat.FormatString = "N0"
        Me.GridColumnAvl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAvl.FieldName = "qty_avl"
        Me.GridColumnAvl.Name = "GridColumnAvl"
        Me.GridColumnAvl.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_avl", "{0:N0}")})
        Me.GridColumnAvl.Visible = True
        Me.GridColumnAvl.VisibleIndex = 4
        Me.GridColumnAvl.Width = 106
        '
        'GridColumnReserved
        '
        Me.GridColumnReserved.Caption = "Reserved"
        Me.GridColumnReserved.DisplayFormat.FormatString = "N0"
        Me.GridColumnReserved.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnReserved.FieldName = "qty_rsv"
        Me.GridColumnReserved.Name = "GridColumnReserved"
        Me.GridColumnReserved.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rsv", "{0:N0}")})
        Me.GridColumnReserved.Visible = True
        Me.GridColumnReserved.VisibleIndex = 5
        Me.GridColumnReserved.Width = 101
        '
        'GridColumnTotal
        '
        Me.GridColumnTotal.Caption = "Total"
        Me.GridColumnTotal.DisplayFormat.FormatString = "N0"
        Me.GridColumnTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotal.FieldName = "qty_total"
        Me.GridColumnTotal.Name = "GridColumnTotal"
        Me.GridColumnTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_total", "{0:N0}")})
        Me.GridColumnTotal.Visible = True
        Me.GridColumnTotal.VisibleIndex = 6
        Me.GridColumnTotal.Width = 141
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 3
        Me.GridColumnPrice.Width = 117
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.TxtStore)
        Me.PanelControl1.Controls.Add(Me.TxtStoreCode)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(717, 39)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(293, 10)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(61, 20)
        Me.BtnView.TabIndex = 3
        Me.BtnView.Text = "View"
        '
        'TxtStore
        '
        Me.TxtStore.Enabled = False
        Me.TxtStore.Location = New System.Drawing.Point(107, 11)
        Me.TxtStore.Name = "TxtStore"
        Me.TxtStore.Size = New System.Drawing.Size(182, 20)
        Me.TxtStore.TabIndex = 2
        '
        'TxtStoreCode
        '
        Me.TxtStoreCode.Location = New System.Drawing.Point(42, 11)
        Me.TxtStoreCode.Name = "TxtStoreCode"
        Me.TxtStoreCode.Size = New System.Drawing.Size(62, 20)
        Me.TxtStoreCode.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(10, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Store"
        '
        'FormWHDelEmptyStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 325)
        Me.Controls.Add(Me.XTCStock)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "FormWHDelEmptyStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Non Stock Inventory"
        CType(Me.XTCStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCStock.ResumeLayout(False)
        Me.XTPStock.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TxtStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtStoreCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCStock As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPStock As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TxtStore As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtStoreCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBarcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAvl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReserved As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
End Class
