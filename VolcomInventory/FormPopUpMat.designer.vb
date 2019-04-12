<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpMat
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
        Me.GroupGeneral = New DevExpress.XtraEditors.GroupControl()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.GCMat = New DevExpress.XtraGrid.GridControl()
        Me.GVMat = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.GCMatPrice = New DevExpress.XtraGrid.GridControl()
        Me.GVMatPrice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPriceStockQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControlButton = New DevExpress.XtraEditors.PanelControl()
        Me.BShowBOM = New DevExpress.XtraEditors.SimpleButton()
        Me.CEBOM = New DevExpress.XtraEditors.CheckEdit()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneral.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GCMatPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMatPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlButton.SuspendLayout()
        CType(Me.CEBOM.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupGeneral
        '
        Me.GroupGeneral.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupGeneral.Controls.Add(Me.PictureEdit1)
        Me.GroupGeneral.Controls.Add(Me.BView)
        Me.GroupGeneral.Controls.Add(Me.GCMat)
        Me.GroupGeneral.Controls.Add(Me.GroupControl3)
        Me.GroupGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupGeneral.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneral.Name = "GroupGeneral"
        Me.GroupGeneral.Size = New System.Drawing.Size(867, 405)
        Me.GroupGeneral.TabIndex = 39
        Me.GroupGeneral.Text = "Material"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit1.Location = New System.Drawing.Point(2, 20)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.Image
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(233, 226)
        Me.PictureEdit1.TabIndex = 97
        '
        'BView
        '
        Me.BView.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BView.Location = New System.Drawing.Point(2, 246)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(233, 23)
        Me.BView.TabIndex = 96
        Me.BView.Text = "View"
        '
        'GCMat
        '
        Me.GCMat.Dock = System.Windows.Forms.DockStyle.Right
        Me.GCMat.Location = New System.Drawing.Point(235, 20)
        Me.GCMat.MainView = Me.GVMat
        Me.GCMat.Name = "GCMat"
        Me.GCMat.Size = New System.Drawing.Size(630, 249)
        Me.GCMat.TabIndex = 11
        Me.GCMat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMat, Me.GridView3})
        '
        'GVMat
        '
        Me.GVMat.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn5, Me.GridColumn3, Me.GridColumn4, Me.ColSize, Me.GridColumnQty, Me.GridColumnColor, Me.GridColumn2, Me.GridColumn6})
        Me.GVMat.GridControl = Me.GCMat
        Me.GVMat.Name = "GVMat"
        Me.GVMat.OptionsBehavior.Editable = False
        Me.GVMat.OptionsFind.AlwaysVisible = True
        Me.GVMat.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVMat.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Mat Det"
        Me.GridColumn1.FieldName = "id_mat_det"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Code"
        Me.GridColumn5.FieldName = "mat_det_code"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        Me.GridColumn5.Width = 148
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Material"
        Me.GridColumn3.FieldName = "mat_det_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 242
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.Caption = "UOM"
        Me.GridColumn4.FieldName = "uom"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 4
        Me.GridColumn4.Width = 74
        '
        'ColSize
        '
        Me.ColSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 3
        Me.ColSize.Width = 74
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N2"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty_all_mat"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 5
        Me.GridColumnQty.Width = 100
        '
        'GridColumnColor
        '
        Me.GridColumnColor.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 2
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Qty MRS"
        Me.GridColumn2.FieldName = "qty_mrs"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 6
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Qty Free"
        Me.GridColumn6.FieldName = "qty_left"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 7
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GCMat
        Me.GridView3.Name = "GridView3"
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControl3.Controls.Add(Me.GCMatPrice)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl3.Location = New System.Drawing.Point(2, 269)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(863, 134)
        Me.GroupControl3.TabIndex = 98
        Me.GroupControl3.Text = "Price"
        '
        'GCMatPrice
        '
        Me.GCMatPrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMatPrice.Location = New System.Drawing.Point(2, 20)
        Me.GCMatPrice.MainView = Me.GVMatPrice
        Me.GCMatPrice.Name = "GCMatPrice"
        Me.GCMatPrice.Size = New System.Drawing.Size(859, 112)
        Me.GCMatPrice.TabIndex = 3
        Me.GCMatPrice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMatPrice, Me.GridView5})
        '
        'GVMatPrice
        '
        Me.GVMatPrice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.ColPriceStockQty})
        Me.GVMatPrice.GridControl = Me.GCMatPrice
        Me.GVMatPrice.Name = "GVMatPrice"
        Me.GVMatPrice.OptionsBehavior.Editable = False
        Me.GVMatPrice.OptionsView.ShowGroupPanel = False
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Id Price"
        Me.GridColumn16.FieldName = "id_mat_det_price"
        Me.GridColumn16.Name = "GridColumn16"
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Name"
        Me.GridColumn17.FieldName = "mat_det_price_name"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 0
        Me.GridColumn17.Width = 174
        '
        'GridColumn18
        '
        Me.GridColumn18.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn18.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn18.Caption = "Price"
        Me.GridColumn18.DisplayFormat.FormatString = "N2"
        Me.GridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn18.FieldName = "mat_det_price"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 2
        Me.GridColumn18.Width = 174
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Date"
        Me.GridColumn19.FieldName = "mat_det_price_date"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 3
        Me.GridColumn19.Width = 174
        '
        'GridColumn20
        '
        Me.GridColumn20.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn20.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn20.Caption = "Currency"
        Me.GridColumn20.FieldName = "currency"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 1
        Me.GridColumn20.Width = 60
        '
        'ColPriceStockQty
        '
        Me.ColPriceStockQty.Caption = "Stock Qty"
        Me.ColPriceStockQty.DisplayFormat.FormatString = "N2"
        Me.ColPriceStockQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPriceStockQty.FieldName = "qty_all_mat"
        Me.ColPriceStockQty.Name = "ColPriceStockQty"
        '
        'GridView5
        '
        Me.GridView5.GridControl = Me.GCMatPrice
        Me.GridView5.Name = "GridView5"
        '
        'PanelControlButton
        '
        Me.PanelControlButton.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlButton.Controls.Add(Me.BShowBOM)
        Me.PanelControlButton.Controls.Add(Me.CEBOM)
        Me.PanelControlButton.Controls.Add(Me.BCancel)
        Me.PanelControlButton.Controls.Add(Me.BSave)
        Me.PanelControlButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlButton.Location = New System.Drawing.Point(0, 405)
        Me.PanelControlButton.Name = "PanelControlButton"
        Me.PanelControlButton.Size = New System.Drawing.Size(867, 38)
        Me.PanelControlButton.TabIndex = 38
        '
        'BShowBOM
        '
        Me.BShowBOM.Enabled = False
        Me.BShowBOM.Location = New System.Drawing.Point(187, 8)
        Me.BShowBOM.Name = "BShowBOM"
        Me.BShowBOM.Size = New System.Drawing.Size(75, 23)
        Me.BShowBOM.TabIndex = 4
        Me.BShowBOM.Text = "Show Material"
        '
        'CEBOM
        '
        Me.CEBOM.Location = New System.Drawing.Point(12, 10)
        Me.CEBOM.Name = "CEBOM"
        Me.CEBOM.Properties.Caption = "Show Only Material From BOM"
        Me.CEBOM.Size = New System.Drawing.Size(175, 19)
        Me.CEBOM.TabIndex = 3
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(710, 7)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(70, 23)
        Me.BCancel.TabIndex = 2
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(786, 7)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 23)
        Me.BSave.TabIndex = 1
        Me.BSave.Text = "Save"
        '
        'FormPopUpMat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 443)
        Me.Controls.Add(Me.GroupGeneral)
        Me.Controls.Add(Me.PanelControlButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpMat"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Material"
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneral.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.GCMatPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMatPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlButton.ResumeLayout(False)
        CType(Me.CEBOM.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupGeneral As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCMat As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMat As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControlButton As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CEBOM As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCMatPrice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMatPrice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColPriceStockQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BShowBOM As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
End Class
