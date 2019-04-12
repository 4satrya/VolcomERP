<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesDelOrderCancellCombine
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesDelOrderCancellCombine))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelCombineNumber = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MemoEdit1 = New DevExpress.XtraEditors.MemoEdit()
        Me.GCSalesDelOrder = New DevExpress.XtraGrid.GridControl()
        Me.GVSalesDelOrder = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSalesDelOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnWHName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUpdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUpdBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelStore = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSalesDelOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalesDelOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelStore)
        Me.PanelControl1.Controls.Add(Me.LabelCombineNumber)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(768, 65)
        Me.PanelControl1.TabIndex = 0
        '
        'LabelCombineNumber
        '
        Me.LabelCombineNumber.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCombineNumber.Location = New System.Drawing.Point(14, 12)
        Me.LabelCombineNumber.Name = "LabelCombineNumber"
        Me.LabelCombineNumber.Size = New System.Drawing.Size(167, 19)
        Me.LabelCombineNumber.TabIndex = 3
        Me.LabelCombineNumber.Text = "[COMBINE NUMBER]"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnDiscard)
        Me.PanelControl2.Controls.Add(Me.BtnConfirm)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 492)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(768, 45)
        Me.PanelControl2.TabIndex = 2
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Image = CType(resources.GetObject("BtnDiscard.Image"), System.Drawing.Image)
        Me.BtnDiscard.Location = New System.Drawing.Point(589, 2)
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(86, 41)
        Me.BtnDiscard.TabIndex = 1
        Me.BtnDiscard.Text = "Discard"
        '
        'BtnConfirm
        '
        Me.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnConfirm.Image = CType(resources.GetObject("BtnConfirm.Image"), System.Drawing.Image)
        Me.BtnConfirm.Location = New System.Drawing.Point(675, 2)
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Size = New System.Drawing.Size(91, 41)
        Me.BtnConfirm.TabIndex = 0
        Me.BtnConfirm.Text = "Confirm"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.MemoEdit1)
        Me.PanelControl3.Controls.Add(Me.Label1)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 417)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(768, 75)
        Me.PanelControl3.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Note"
        '
        'MemoEdit1
        '
        Me.MemoEdit1.Location = New System.Drawing.Point(52, 10)
        Me.MemoEdit1.Name = "MemoEdit1"
        Me.MemoEdit1.Size = New System.Drawing.Size(687, 51)
        Me.MemoEdit1.TabIndex = 1
        '
        'GCSalesDelOrder
        '
        Me.GCSalesDelOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesDelOrder.Location = New System.Drawing.Point(0, 65)
        Me.GCSalesDelOrder.MainView = Me.GVSalesDelOrder
        Me.GCSalesDelOrder.Name = "GCSalesDelOrder"
        Me.GCSalesDelOrder.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCSalesDelOrder.Size = New System.Drawing.Size(768, 352)
        Me.GCSalesDelOrder.TabIndex = 110
        Me.GCSalesDelOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalesDelOrder, Me.GridView3})
        '
        'GVSalesDelOrder
        '
        Me.GVSalesDelOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn8, Me.GridColumnIdSalesDelOrder, Me.GridColumnWHName, Me.GridColumnCategory, Me.GridColumnLastUpdate, Me.GridColumnUpdBy, Me.GridColumnTotal})
        Me.GVSalesDelOrder.GridControl = Me.GCSalesDelOrder
        Me.GVSalesDelOrder.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", Me.GridColumnTotal, "{0:n0}")})
        Me.GVSalesDelOrder.Name = "GVSalesDelOrder"
        Me.GVSalesDelOrder.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSalesDelOrder.OptionsView.ShowFooter = True
        Me.GVSalesDelOrder.OptionsView.ShowGroupPanel = False
        Me.GVSalesDelOrder.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnIdSalesDelOrder, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Number"
        Me.GridColumn1.FieldName = "pl_sales_order_del_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 179
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Store"
        Me.GridColumn2.FieldName = "store"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Created Date"
        Me.GridColumn3.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn3.FieldName = "pl_sales_order_del_date"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        Me.GridColumn3.Width = 212
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Note"
        Me.GridColumn4.FieldName = "pl_sales_order_del_note"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Status"
        Me.GridColumn5.FieldName = "report_status"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Prepare Order"
        Me.GridColumn8.FieldName = "sales_order_number"
        Me.GridColumn8.FieldNameSortGroup = "id_pl_sales_order_del"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        Me.GridColumn8.Width = 131
        '
        'GridColumnIdSalesDelOrder
        '
        Me.GridColumnIdSalesDelOrder.Caption = "Id Sales Del Order"
        Me.GridColumnIdSalesDelOrder.FieldName = "id_pl_sales_order_del"
        Me.GridColumnIdSalesDelOrder.Name = "GridColumnIdSalesDelOrder"
        Me.GridColumnIdSalesDelOrder.OptionsColumn.AllowEdit = False
        Me.GridColumnIdSalesDelOrder.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnWHName
        '
        Me.GridColumnWHName.Caption = "Warehouse"
        Me.GridColumnWHName.FieldName = "wh"
        Me.GridColumnWHName.FieldNameSortGroup = "id_wh"
        Me.GridColumnWHName.Name = "GridColumnWHName"
        Me.GridColumnWHName.OptionsColumn.AllowEdit = False
        '
        'GridColumnCategory
        '
        Me.GridColumnCategory.Caption = "Category"
        Me.GridColumnCategory.FieldName = "so_status"
        Me.GridColumnCategory.FieldNameSortGroup = "id_so_status"
        Me.GridColumnCategory.Name = "GridColumnCategory"
        Me.GridColumnCategory.OptionsColumn.AllowEdit = False
        Me.GridColumnCategory.Visible = True
        Me.GridColumnCategory.VisibleIndex = 2
        Me.GridColumnCategory.Width = 152
        '
        'GridColumnLastUpdate
        '
        Me.GridColumnLastUpdate.Caption = "Last Updated"
        Me.GridColumnLastUpdate.DisplayFormat.FormatString = "dd MMMM yyyy'/'hh:mm tt"
        Me.GridColumnLastUpdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnLastUpdate.FieldName = "last_update"
        Me.GridColumnLastUpdate.Name = "GridColumnLastUpdate"
        Me.GridColumnLastUpdate.OptionsColumn.AllowEdit = False
        '
        'GridColumnUpdBy
        '
        Me.GridColumnUpdBy.Caption = "Updated By"
        Me.GridColumnUpdBy.FieldName = "last_user"
        Me.GridColumnUpdBy.Name = "GridColumnUpdBy"
        Me.GridColumnUpdBy.OptionsColumn.AllowEdit = False
        '
        'GridColumnTotal
        '
        Me.GridColumnTotal.Caption = "Total"
        Me.GridColumnTotal.DisplayFormat.FormatString = "N0"
        Me.GridColumnTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotal.FieldName = "total"
        Me.GridColumnTotal.Name = "GridColumnTotal"
        Me.GridColumnTotal.OptionsColumn.AllowEdit = False
        Me.GridColumnTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N0}")})
        Me.GridColumnTotal.Visible = True
        Me.GridColumnTotal.VisibleIndex = 4
        Me.GridColumnTotal.Width = 137
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GCSalesDelOrder
        Me.GridView3.Name = "GridView3"
        '
        'LabelStore
        '
        Me.LabelStore.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStore.Location = New System.Drawing.Point(14, 35)
        Me.LabelStore.Name = "LabelStore"
        Me.LabelStore.Size = New System.Drawing.Size(133, 16)
        Me.LabelStore.TabIndex = 4
        Me.LabelStore.Text = "[STORE DESCRIPTION]"
        '
        'FormSalesDelOrderCancellCombine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 537)
        Me.Controls.Add(Me.GCSalesDelOrder)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormSalesDelOrderCancellCombine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancell Combine"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCSalesDelOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalesDelOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelCombineNumber As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents MemoEdit1 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelStore As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCSalesDelOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSalesDelOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSalesDelOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWHName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastUpdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUpdBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
