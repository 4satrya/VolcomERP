<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCoba
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCoba))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BId = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdComp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdProdOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProdOrderNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDeliveryOrderDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnArriveDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnunbound = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.DateEditTo = New DevExpress.XtraEditors.DateEdit()
        Me.DateEditFrom = New DevExpress.XtraEditors.DateEdit()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.SearchLookUpEditVendor = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnFilterIdComp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFilterCompNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFilterCompName = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.DateEditTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEditVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BId)
        Me.PanelControl1.Controls.Add(Me.BSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 287)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(736, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'BId
        '
        Me.BId.Dock = System.Windows.Forms.DockStyle.Left
        Me.BId.Image = CType(resources.GetObject("BId.Image"), System.Drawing.Image)
        Me.BId.Location = New System.Drawing.Point(2, 2)
        Me.BId.Name = "BId"
        Me.BId.Size = New System.Drawing.Size(120, 42)
        Me.BId.TabIndex = 1
        Me.BId.Text = "Show Id"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Location = New System.Drawing.Point(632, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(102, 42)
        Me.BSave.TabIndex = 0
        Me.BSave.Text = "Save"
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 108)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.Size = New System.Drawing.Size(736, 179)
        Me.GCList.TabIndex = 1
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumnNumber, Me.GridColumnValue, Me.GridColumnIdComp, Me.GridColumnCompName, Me.GridColumnIdProdOrder, Me.GridColumnProdOrderNumber, Me.GridColumnDeliveryOrderDate, Me.GridColumnArriveDate, Me.GridColumnunbound})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsView.ColumnAutoWidth = False
        Me.GVList.OptionsView.ShowGroupPanel = False
        Me.GVList.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[True]
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_prod_order_rec"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Order Rec Number"
        Me.GridColumnNumber.FieldName = "prod_order_rec_number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 0
        '
        'GridColumnValue
        '
        Me.GridColumnValue.Caption = "Value"
        Me.GridColumnValue.DisplayFormat.FormatString = "N2"
        Me.GridColumnValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnValue.FieldName = "val_rec"
        Me.GridColumnValue.Name = "GridColumnValue"
        Me.GridColumnValue.OptionsColumn.AllowEdit = False
        Me.GridColumnValue.Visible = True
        Me.GridColumnValue.VisibleIndex = 1
        '
        'GridColumnIdComp
        '
        Me.GridColumnIdComp.Caption = "Id Company"
        Me.GridColumnIdComp.FieldName = "id_comp"
        Me.GridColumnIdComp.Name = "GridColumnIdComp"
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "Company Name"
        Me.GridColumnCompName.FieldName = "comp_name"
        Me.GridColumnCompName.Name = "GridColumnCompName"
        Me.GridColumnCompName.Visible = True
        Me.GridColumnCompName.VisibleIndex = 2
        '
        'GridColumnIdProdOrder
        '
        Me.GridColumnIdProdOrder.Caption = "Id  Prod Order"
        Me.GridColumnIdProdOrder.FieldName = "id_prod_order"
        Me.GridColumnIdProdOrder.Name = "GridColumnIdProdOrder"
        '
        'GridColumnProdOrderNumber
        '
        Me.GridColumnProdOrderNumber.Caption = "Prod  Order Number"
        Me.GridColumnProdOrderNumber.FieldName = "prod_order_number"
        Me.GridColumnProdOrderNumber.Name = "GridColumnProdOrderNumber"
        Me.GridColumnProdOrderNumber.Visible = True
        Me.GridColumnProdOrderNumber.VisibleIndex = 3
        '
        'GridColumnDeliveryOrderDate
        '
        Me.GridColumnDeliveryOrderDate.Caption = "Delivery Order Date"
        Me.GridColumnDeliveryOrderDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnDeliveryOrderDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDeliveryOrderDate.FieldName = "delivery_order_date"
        Me.GridColumnDeliveryOrderDate.Name = "GridColumnDeliveryOrderDate"
        Me.GridColumnDeliveryOrderDate.Visible = True
        Me.GridColumnDeliveryOrderDate.VisibleIndex = 4
        '
        'GridColumnArriveDate
        '
        Me.GridColumnArriveDate.Caption = "Arrive Date"
        Me.GridColumnArriveDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnArriveDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnArriveDate.FieldName = "arrive_date"
        Me.GridColumnArriveDate.Name = "GridColumnArriveDate"
        Me.GridColumnArriveDate.Visible = True
        Me.GridColumnArriveDate.VisibleIndex = 5
        '
        'GridColumnunbound
        '
        Me.GridColumnunbound.Caption = "value + 1"
        Me.GridColumnunbound.FieldName = "testunbound"
        Me.GridColumnunbound.Name = "GridColumnunbound"
        Me.GridColumnunbound.UnboundExpression = "[val_rec] + 1"
        Me.GridColumnunbound.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnunbound.Visible = True
        Me.GridColumnunbound.VisibleIndex = 6
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.DateEditTo)
        Me.PanelControl2.Controls.Add(Me.DateEditFrom)
        Me.PanelControl2.Controls.Add(Me.BSearch)
        Me.PanelControl2.Controls.Add(Me.SearchLookUpEditVendor)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(736, 108)
        Me.PanelControl2.TabIndex = 2
        '
        'DateEditTo
        '
        Me.DateEditTo.EditValue = New Date(2018, 12, 31, 0, 0, 0, 0)
        Me.DateEditTo.Location = New System.Drawing.Point(224, 12)
        Me.DateEditTo.Name = "DateEditTo"
        Me.DateEditTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditTo.Size = New System.Drawing.Size(100, 20)
        Me.DateEditTo.TabIndex = 3
        '
        'DateEditFrom
        '
        Me.DateEditFrom.EditValue = New Date(2018, 1, 1, 15, 59, 48, 0)
        Me.DateEditFrom.Location = New System.Drawing.Point(118, 12)
        Me.DateEditFrom.Name = "DateEditFrom"
        Me.DateEditFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditFrom.Size = New System.Drawing.Size(100, 20)
        Me.DateEditFrom.TabIndex = 2
        '
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(330, 10)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(100, 23)
        Me.BSearch.TabIndex = 1
        Me.BSearch.Text = "View"
        '
        'SearchLookUpEditVendor
        '
        Me.SearchLookUpEditVendor.Location = New System.Drawing.Point(12, 12)
        Me.SearchLookUpEditVendor.Name = "SearchLookUpEditVendor"
        Me.SearchLookUpEditVendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookUpEditVendor.Properties.View = Me.SearchLookUpEdit1View
        Me.SearchLookUpEditVendor.Size = New System.Drawing.Size(100, 20)
        Me.SearchLookUpEditVendor.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnFilterIdComp, Me.GridColumnFilterCompNumber, Me.GridColumnFilterCompName})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnFilterIdComp
        '
        Me.GridColumnFilterIdComp.Caption = "Id"
        Me.GridColumnFilterIdComp.FieldName = "id_comp"
        Me.GridColumnFilterIdComp.Name = "GridColumnFilterIdComp"
        Me.GridColumnFilterIdComp.Visible = True
        Me.GridColumnFilterIdComp.VisibleIndex = 0
        '
        'GridColumnFilterCompNumber
        '
        Me.GridColumnFilterCompNumber.Caption = "Comp Number"
        Me.GridColumnFilterCompNumber.FieldName = "comp_number"
        Me.GridColumnFilterCompNumber.Name = "GridColumnFilterCompNumber"
        Me.GridColumnFilterCompNumber.Visible = True
        Me.GridColumnFilterCompNumber.VisibleIndex = 1
        '
        'GridColumnFilterCompName
        '
        Me.GridColumnFilterCompName.Caption = "Comp Name"
        Me.GridColumnFilterCompName.FieldName = "comp_name"
        Me.GridColumnFilterCompName.Name = "GridColumnFilterCompName"
        Me.GridColumnFilterCompName.Visible = True
        Me.GridColumnFilterCompName.VisibleIndex = 2
        '
        'FormCoba
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 333)
        Me.Controls.Add(Me.GCList)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCoba"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormCoba"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.DateEditTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEditVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProdOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProdOrderNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDeliveryOrderDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnArriveDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnunbound As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BId As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SearchLookUpEditVendor As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnFilterIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFilterCompNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFilterCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateEditTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEditFrom As DevExpress.XtraEditors.DateEdit
End Class
