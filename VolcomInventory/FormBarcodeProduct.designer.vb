<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBarcodeProduct
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
        Me.GCProdList = New DevExpress.XtraGrid.GridControl()
        Me.GVProdList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnDesignCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesignDisplayName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProductCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVendorCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProductOrigin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDivision = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProdSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastDigit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControlNavLineList = New DevExpress.XtraEditors.PanelControl()
        Me.PCNavLineList = New DevExpress.XtraEditors.PanelControl()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRange = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCProdList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProdList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNavLineList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNavLineList.SuspendLayout()
        CType(Me.PCNavLineList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCNavLineList.SuspendLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCProdList
        '
        Me.GCProdList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProdList.Location = New System.Drawing.Point(0, 39)
        Me.GCProdList.MainView = Me.GVProdList
        Me.GCProdList.Name = "GCProdList"
        Me.GCProdList.Size = New System.Drawing.Size(802, 323)
        Me.GCProdList.TabIndex = 4
        Me.GCProdList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProdList})
        '
        'GVProdList
        '
        Me.GVProdList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnDesignCode, Me.GridColumnDesignDisplayName, Me.GridColumnProductCode, Me.GridColumnVendorCode, Me.GridColumnProductOrigin, Me.GridColumnDivision, Me.GridColumnProdSize, Me.GridColumnColod, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn8, Me.GridColumn7, Me.GridColumnLastDigit})
        Me.GVProdList.GridControl = Me.GCProdList
        Me.GVProdList.GroupCount = 1
        Me.GVProdList.Name = "GVProdList"
        Me.GVProdList.OptionsBehavior.Editable = False
        Me.GVProdList.OptionsBehavior.ReadOnly = True
        Me.GVProdList.OptionsView.ShowGroupPanel = False
        Me.GVProdList.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDesignDisplayName, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnDesignCode
        '
        Me.GridColumnDesignCode.Caption = "Design Code"
        Me.GridColumnDesignCode.FieldName = "design_code"
        Me.GridColumnDesignCode.Name = "GridColumnDesignCode"
        Me.GridColumnDesignCode.Visible = True
        Me.GridColumnDesignCode.VisibleIndex = 0
        '
        'GridColumnDesignDisplayName
        '
        Me.GridColumnDesignDisplayName.Caption = "Design"
        Me.GridColumnDesignDisplayName.FieldName = "design_display_name"
        Me.GridColumnDesignDisplayName.FieldNameSortGroup = "id_design"
        Me.GridColumnDesignDisplayName.Name = "GridColumnDesignDisplayName"
        '
        'GridColumnProductCode
        '
        Me.GridColumnProductCode.Caption = "Product Code"
        Me.GridColumnProductCode.FieldName = "product_full_code"
        Me.GridColumnProductCode.Name = "GridColumnProductCode"
        Me.GridColumnProductCode.Visible = True
        Me.GridColumnProductCode.VisibleIndex = 1
        '
        'GridColumnVendorCode
        '
        Me.GridColumnVendorCode.Caption = "Vendor/UPC Code"
        Me.GridColumnVendorCode.FieldName = "product_ean_code"
        Me.GridColumnVendorCode.Name = "GridColumnVendorCode"
        Me.GridColumnVendorCode.Visible = True
        Me.GridColumnVendorCode.VisibleIndex = 2
        '
        'GridColumnProductOrigin
        '
        Me.GridColumnProductOrigin.Caption = "Product Origin"
        Me.GridColumnProductOrigin.FieldName = "Product Source_display"
        Me.GridColumnProductOrigin.Name = "GridColumnProductOrigin"
        '
        'GridColumnDivision
        '
        Me.GridColumnDivision.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDivision.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnDivision.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnDivision.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnDivision.Caption = "Division"
        Me.GridColumnDivision.FieldName = "Product Division_display"
        Me.GridColumnDivision.Name = "GridColumnDivision"
        Me.GridColumnDivision.Visible = True
        Me.GridColumnDivision.VisibleIndex = 3
        '
        'GridColumnProdSize
        '
        Me.GridColumnProdSize.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnProdSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnProdSize.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnProdSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnProdSize.Caption = "Size"
        Me.GridColumnProdSize.FieldName = "Size"
        Me.GridColumnProdSize.Name = "GridColumnProdSize"
        Me.GridColumnProdSize.Visible = True
        Me.GridColumnProdSize.VisibleIndex = 5
        '
        'GridColumnColod
        '
        Me.GridColumnColod.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnColod.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColod.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnColod.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColod.Caption = "Color"
        Me.GridColumnColod.FieldName = "Color_display"
        Me.GridColumnColod.Name = "GridColumnColod"
        Me.GridColumnColod.Visible = True
        Me.GridColumnColod.VisibleIndex = 4
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.Caption = "Range Awal"
        Me.GridColumn1.FieldName = "range_awal"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "Range Akhir"
        Me.GridColumn2.FieldName = "range_akhir"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.Caption = "Currency"
        Me.GridColumn3.FieldName = "currency"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 7
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.Caption = "Price"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "design_price"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 8
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.Caption = "Return Code"
        Me.GridColumn5.FieldName = "ret_code"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 6
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Digit Code"
        Me.GridColumn6.FieldName = "digit_code"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumnLastDigit
        '
        Me.GridColumnLastDigit.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnLastDigit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnLastDigit.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnLastDigit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnLastDigit.Caption = "Last Unique Print"
        Me.GridColumnLastDigit.FieldName = "last_unique"
        Me.GridColumnLastDigit.Name = "GridColumnLastDigit"
        Me.GridColumnLastDigit.Visible = True
        Me.GridColumnLastDigit.VisibleIndex = 11
        '
        'PanelControlNavLineList
        '
        Me.PanelControlNavLineList.Controls.Add(Me.PCNavLineList)
        Me.PanelControlNavLineList.Controls.Add(Me.BtnView)
        Me.PanelControlNavLineList.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNavLineList.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlNavLineList.Name = "PanelControlNavLineList"
        Me.PanelControlNavLineList.Size = New System.Drawing.Size(802, 39)
        Me.PanelControlNavLineList.TabIndex = 3
        '
        'PCNavLineList
        '
        Me.PCNavLineList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCNavLineList.Controls.Add(Me.SLESeason)
        Me.PCNavLineList.Controls.Add(Me.LabelControl4)
        Me.PCNavLineList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PCNavLineList.Location = New System.Drawing.Point(2, 2)
        Me.PCNavLineList.Name = "PCNavLineList"
        Me.PCNavLineList.Size = New System.Drawing.Size(694, 35)
        Me.PCNavLineList.TabIndex = 105
        '
        'SLESeason
        '
        Me.SLESeason.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SLESeason.Location = New System.Drawing.Point(55, 7)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(627, 20)
        Me.SLESeason.TabIndex = 95
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
        Me.LabelControl4.Location = New System.Drawing.Point(14, 10)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl4.TabIndex = 90
        Me.LabelControl4.Text = "Season"
        '
        'BtnView
        '
        Me.BtnView.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnView.ImageIndex = 15
        Me.BtnView.Location = New System.Drawing.Point(696, 2)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(104, 35)
        Me.BtnView.TabIndex = 94
        Me.BtnView.Text = "View List"
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn7.Caption = "Qty Receiving"
        Me.GridColumn7.DisplayFormat.FormatString = "N0"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "qty_rec"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 10
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn8.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn8.Caption = "Qty FGPO"
        Me.GridColumn8.DisplayFormat.FormatString = "N0"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn8.FieldName = "qty_order"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 9
        '
        'FormBarcodeProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 362)
        Me.Controls.Add(Me.GCProdList)
        Me.Controls.Add(Me.PanelControlNavLineList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBarcodeProduct"
        Me.Text = "Barcode Product"
        CType(Me.GCProdList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProdList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNavLineList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNavLineList.ResumeLayout(False)
        CType(Me.PCNavLineList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCNavLineList.ResumeLayout(False)
        Me.PCNavLineList.PerformLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCProdList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProdList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnDesignCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignDisplayName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProductCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVendorCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProductOrigin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProdSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControlNavLineList As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PCNavLineList As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRange As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastDigit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
End Class
