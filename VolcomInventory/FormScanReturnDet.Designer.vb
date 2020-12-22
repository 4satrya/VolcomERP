<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormScanReturnDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormScanReturnDet))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TEReturnNote = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.MEListStore = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BReset = New DevExpress.XtraEditors.SimpleButton()
        Me.TEQty = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TEReturnLabel = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PCButton = New DevExpress.XtraEditors.PanelControl()
        Me.BClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.PCAddDel = New DevExpress.XtraEditors.PanelControl()
        Me.BDeleteScan = New DevExpress.XtraEditors.SimpleButton()
        Me.BInputManual = New DevExpress.XtraEditors.SimpleButton()
        Me.TEScan = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GCListProduct = New DevExpress.XtraGrid.GridControl()
        Me.GVListProduct = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TEReturnNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEListStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEReturnLabel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCButton.SuspendLayout()
        CType(Me.PCAddDel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCAddDel.SuspendLayout()
        CType(Me.TEScan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCListProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.TEReturnNote)
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Controls.Add(Me.MEListStore)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.BReset)
        Me.PanelControl1.Controls.Add(Me.TEQty)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.TEReturnLabel)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(821, 117)
        Me.PanelControl1.TabIndex = 0
        '
        'TEReturnNote
        '
        Me.TEReturnNote.Location = New System.Drawing.Point(123, 38)
        Me.TEReturnNote.Name = "TEReturnNote"
        Me.TEReturnNote.Properties.ReadOnly = True
        Me.TEReturnNote.Size = New System.Drawing.Size(428, 20)
        Me.TEReturnNote.TabIndex = 7
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(16, 41)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl5.TabIndex = 6
        Me.LabelControl5.Text = "Return Note"
        '
        'MEListStore
        '
        Me.MEListStore.Location = New System.Drawing.Point(123, 64)
        Me.MEListStore.Name = "MEListStore"
        Me.MEListStore.Properties.ReadOnly = True
        Me.MEListStore.Size = New System.Drawing.Size(686, 43)
        Me.MEListStore.TabIndex = 5
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(16, 64)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl4.TabIndex = 4
        Me.LabelControl4.Text = "List Store"
        '
        'BReset
        '
        Me.BReset.Location = New System.Drawing.Point(734, 36)
        Me.BReset.Name = "BReset"
        Me.BReset.Size = New System.Drawing.Size(75, 23)
        Me.BReset.TabIndex = 3
        Me.BReset.Text = "Reset"
        '
        'TEQty
        '
        Me.TEQty.Enabled = False
        Me.TEQty.Location = New System.Drawing.Point(608, 38)
        Me.TEQty.Name = "TEQty"
        Me.TEQty.Properties.ReadOnly = True
        Me.TEQty.Size = New System.Drawing.Size(120, 20)
        Me.TEQty.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(557, 41)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Total Qty"
        '
        'TEReturnLabel
        '
        Me.TEReturnLabel.Location = New System.Drawing.Point(123, 12)
        Me.TEReturnLabel.Name = "TEReturnLabel"
        Me.TEReturnLabel.Size = New System.Drawing.Size(686, 20)
        Me.TEReturnLabel.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(16, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(101, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Return Label Number"
        '
        'PCButton
        '
        Me.PCButton.Controls.Add(Me.BClose)
        Me.PCButton.Controls.Add(Me.BSave)
        Me.PCButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCButton.Location = New System.Drawing.Point(0, 508)
        Me.PCButton.Name = "PCButton"
        Me.PCButton.Size = New System.Drawing.Size(821, 45)
        Me.PCButton.TabIndex = 1
        '
        'BClose
        '
        Me.BClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BClose.Image = CType(resources.GetObject("BClose.Image"), System.Drawing.Image)
        Me.BClose.Location = New System.Drawing.Point(585, 2)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(109, 41)
        Me.BClose.TabIndex = 5
        Me.BClose.Text = "Close"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Image = CType(resources.GetObject("BSave.Image"), System.Drawing.Image)
        Me.BSave.Location = New System.Drawing.Point(694, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(125, 41)
        Me.BSave.TabIndex = 3
        Me.BSave.Text = "Finish Scan"
        '
        'PCAddDel
        '
        Me.PCAddDel.Controls.Add(Me.BDeleteScan)
        Me.PCAddDel.Controls.Add(Me.BInputManual)
        Me.PCAddDel.Controls.Add(Me.TEScan)
        Me.PCAddDel.Controls.Add(Me.LabelControl3)
        Me.PCAddDel.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCAddDel.Location = New System.Drawing.Point(0, 117)
        Me.PCAddDel.Name = "PCAddDel"
        Me.PCAddDel.Size = New System.Drawing.Size(821, 43)
        Me.PCAddDel.TabIndex = 2
        '
        'BDeleteScan
        '
        Me.BDeleteScan.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDeleteScan.Image = CType(resources.GetObject("BDeleteScan.Image"), System.Drawing.Image)
        Me.BDeleteScan.Location = New System.Drawing.Point(601, 2)
        Me.BDeleteScan.Name = "BDeleteScan"
        Me.BDeleteScan.Size = New System.Drawing.Size(93, 39)
        Me.BDeleteScan.TabIndex = 5
        Me.BDeleteScan.Text = "Delete"
        '
        'BInputManual
        '
        Me.BInputManual.Dock = System.Windows.Forms.DockStyle.Right
        Me.BInputManual.Image = CType(resources.GetObject("BInputManual.Image"), System.Drawing.Image)
        Me.BInputManual.Location = New System.Drawing.Point(694, 2)
        Me.BInputManual.Name = "BInputManual"
        Me.BInputManual.Size = New System.Drawing.Size(125, 39)
        Me.BInputManual.TabIndex = 4
        Me.BInputManual.Text = "No Tag"
        '
        'TEScan
        '
        Me.TEScan.Location = New System.Drawing.Point(123, 12)
        Me.TEScan.Name = "TEScan"
        Me.TEScan.Size = New System.Drawing.Size(219, 20)
        Me.TEScan.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(16, 15)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl3.TabIndex = 1
        Me.LabelControl3.Text = "Scan Product"
        '
        'GCListProduct
        '
        Me.GCListProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListProduct.Location = New System.Drawing.Point(0, 160)
        Me.GCListProduct.MainView = Me.GVListProduct
        Me.GCListProduct.Name = "GCListProduct"
        Me.GCListProduct.Size = New System.Drawing.Size(821, 348)
        Me.GCListProduct.TabIndex = 3
        Me.GCListProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListProduct})
        '
        'GVListProduct
        '
        Me.GVListProduct.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.GVListProduct.Appearance.FooterPanel.Options.UseFont = True
        Me.GVListProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn7, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GVListProduct.GridControl = Me.GCListProduct
        Me.GVListProduct.Name = "GVListProduct"
        Me.GVListProduct.OptionsBehavior.Editable = False
        Me.GVListProduct.OptionsBehavior.ReadOnly = True
        Me.GVListProduct.OptionsView.ShowFooter = True
        Me.GVListProduct.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_scan_return_det"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Type"
        Me.GridColumn7.FieldName = "type"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ID Product"
        Me.GridColumn2.FieldName = "id_product"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Code"
        Me.GridColumn3.FieldName = "product_full_code"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 200
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Product"
        Me.GridColumn4.FieldName = "product_display_name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "product_display_name", "Total Qty Scan")})
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        Me.GridColumn4.Width = 278
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.Caption = "Size"
        Me.GridColumn5.FieldName = "size"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "size", "{0}")})
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        Me.GridColumn5.Width = 69
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Note"
        Me.GridColumn6.FieldName = "notes"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        Me.GridColumn6.Width = 256
        '
        'FormScanReturnDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 553)
        Me.Controls.Add(Me.GCListProduct)
        Me.Controls.Add(Me.PCAddDel)
        Me.Controls.Add(Me.PCButton)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormScanReturnDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Scan Return"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TEReturnNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEListStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEReturnLabel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCButton.ResumeLayout(False)
        CType(Me.PCAddDel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCAddDel.ResumeLayout(False)
        Me.PCAddDel.PerformLayout()
        CType(Me.TEScan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCListProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEQty As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEReturnLabel As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BReset As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PCButton As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PCAddDel As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEScan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCListProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents MEListStore As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BInputManual As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BDeleteScan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEReturnNote As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
End Class
