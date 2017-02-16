<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSalesReturnOrderSingleV2
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEditSelAll = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton()
        Me.GCProduct = New DevExpress.XtraGrid.GridControl()
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtyQC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumnIdProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesignPriceType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSelect = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnSOH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRange = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.CheckEditSelAll)
        Me.PanelControl1.Controls.Add(Me.BtnChoose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 320)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(736, 37)
        Me.PanelControl1.TabIndex = 0
        '
        'CheckEditSelAll
        '
        Me.CheckEditSelAll.Location = New System.Drawing.Point(12, 9)
        Me.CheckEditSelAll.Name = "CheckEditSelAll"
        Me.CheckEditSelAll.Properties.Caption = "Select All"
        Me.CheckEditSelAll.Size = New System.Drawing.Size(92, 19)
        Me.CheckEditSelAll.TabIndex = 103
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Location = New System.Drawing.Point(659, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 33)
        Me.BtnChoose.TabIndex = 0
        Me.BtnChoose.Text = "Choose"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(0, 41)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1, Me.RepositoryItemCheckEdit1})
        Me.GCProduct.Size = New System.Drawing.Size(736, 279)
        Me.GCProduct.TabIndex = 2
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCode, Me.GridColumnColor, Me.GridColumnSize, Me.GridColumnDesign, Me.GridColumn2, Me.GridColumnQtyQC, Me.GridColumnIdProduct, Me.GridColumnDesignPriceType, Me.GridColumnPrice, Me.GridColumnSelect, Me.GridColumnSOH})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.GroupCount = 2
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVProduct.OptionsView.ShowGroupPanel = False
        Me.GVProduct.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn2, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDesign, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnCode, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.AllowEdit = False
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 0
        '
        'GridColumnColor
        '
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.OptionsColumn.AllowEdit = False
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 1
        Me.GridColumnColor.Width = 83
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 2
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Style"
        Me.GridColumnDesign.FieldName = "design_display_name"
        Me.GridColumnDesign.FieldNameSortGroup = "id_design"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.OptionsColumn.AllowEdit = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Season"
        Me.GridColumn2.FieldName = "season"
        Me.GridColumn2.FieldNameSortGroup = "id_season"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        '
        'GridColumnQtyQC
        '
        Me.GridColumnQtyQC.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyQC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyQC.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyQC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyQC.Caption = "Qty"
        Me.GridColumnQtyQC.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumnQtyQC.DisplayFormat.FormatString = "{0:n0}"
        Me.GridColumnQtyQC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyQC.FieldName = "qty_ord"
        Me.GridColumnQtyQC.Name = "GridColumnQtyQC"
        Me.GridColumnQtyQC.Visible = True
        Me.GridColumnQtyQC.VisibleIndex = 5
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit1.IsFloatValue = False
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "N0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {1316134911, 2328, 0, 0})
        Me.RepositoryItemSpinEdit1.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumnIdProduct
        '
        Me.GridColumnIdProduct.Caption = "Id Product"
        Me.GridColumnIdProduct.FieldName = "id_product"
        Me.GridColumnIdProduct.Name = "GridColumnIdProduct"
        Me.GridColumnIdProduct.OptionsColumn.AllowEdit = False
        '
        'GridColumnDesignPriceType
        '
        Me.GridColumnDesignPriceType.Caption = "Price Type"
        Me.GridColumnDesignPriceType.FieldName = "design_price_type"
        Me.GridColumnDesignPriceType.Name = "GridColumnDesignPriceType"
        Me.GridColumnDesignPriceType.OptionsColumn.AllowEdit = False
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price_retail"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.OptionsColumn.AllowEdit = False
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 3
        '
        'GridColumnSelect
        '
        Me.GridColumnSelect.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSelect.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelect.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelect.Caption = "Select"
        Me.GridColumnSelect.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnSelect.FieldName = "is_select"
        Me.GridColumnSelect.Name = "GridColumnSelect"
        Me.GridColumnSelect.Visible = True
        Me.GridColumnSelect.VisibleIndex = 6
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnSOH
        '
        Me.GridColumnSOH.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSOH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnSOH.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSOH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnSOH.Caption = "SOH"
        Me.GridColumnSOH.DisplayFormat.FormatString = "N0"
        Me.GridColumnSOH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnSOH.FieldName = "qty_all_product"
        Me.GridColumnSOH.Name = "GridColumnSOH"
        Me.GridColumnSOH.OptionsColumn.AllowEdit = False
        Me.GridColumnSOH.Visible = True
        Me.GridColumnSOH.VisibleIndex = 4
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SLESeason)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Controls.Add(Me.BtnView)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.LookAndFeel.SkinName = "Blue"
        Me.PanelControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(736, 41)
        Me.PanelControl2.TabIndex = 3
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(52, 12)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(191, 20)
        Me.SLESeason.TabIndex = 97
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdSeason, Me.GridColumnRange, Me.GridColumnSeason})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Id Season"
        Me.GridColumnIdSeason.FieldName = "id_season"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'GridColumnRange
        '
        Me.GridColumnRange.Caption = "Range"
        Me.GridColumnRange.FieldName = "range"
        Me.GridColumnRange.Name = "GridColumnRange"
        Me.GridColumnRange.Visible = True
        Me.GridColumnRange.VisibleIndex = 0
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.Visible = True
        Me.GridColumnSeason.VisibleIndex = 1
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(11, 15)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl4.TabIndex = 99
        Me.LabelControl4.Text = "Season"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(248, 12)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(70, 20)
        Me.BtnView.TabIndex = 98
        Me.BtnView.TabStop = False
        Me.BtnView.Text = "View"
        '
        'FormSalesReturnOrderSingleV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 357)
        Me.Controls.Add(Me.GCProduct)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormSalesReturnOrderSingleV2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Multiple Product in Store"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyQC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignPriceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSOH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents CheckEditSelAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRange As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
End Class
