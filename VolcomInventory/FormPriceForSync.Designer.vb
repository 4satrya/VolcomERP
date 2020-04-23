<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPriceForSync
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPriceForSync))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelLastSync = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SBSync = New DevExpress.XtraEditors.SimpleButton()
        Me.SBUpdate = New DevExpress.XtraEditors.SimpleButton()
        Me.GCBrowsePrice = New DevExpress.XtraGrid.GridControl()
        Me.GVBrowsePrice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnFullCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNormalPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceWeb = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNormalPriceWeb = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMatch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsize = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCBrowsePrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBrowsePrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelLastSync)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SBSync)
        Me.PanelControl1.Controls.Add(Me.SBUpdate)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 52)
        Me.PanelControl1.TabIndex = 0
        '
        'LabelLastSync
        '
        Me.LabelLastSync.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLastSync.Location = New System.Drawing.Point(158, 19)
        Me.LabelLastSync.Name = "LabelLastSync"
        Me.LabelLastSync.Size = New System.Drawing.Size(105, 13)
        Me.LabelLastSync.TabIndex = 3
        Me.LabelLastSync.Text = "23/04/2020 10:19:53"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(96, 19)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Last Sync : "
        '
        'SBSync
        '
        Me.SBSync.Image = CType(resources.GetObject("SBSync.Image"), System.Drawing.Image)
        Me.SBSync.Location = New System.Drawing.Point(5, 5)
        Me.SBSync.Name = "SBSync"
        Me.SBSync.Size = New System.Drawing.Size(85, 41)
        Me.SBSync.TabIndex = 1
        Me.SBSync.Text = "Sync"
        '
        'SBUpdate
        '
        Me.SBUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBUpdate.Image = CType(resources.GetObject("SBUpdate.Image"), System.Drawing.Image)
        Me.SBUpdate.Location = New System.Drawing.Point(645, 5)
        Me.SBUpdate.Name = "SBUpdate"
        Me.SBUpdate.Size = New System.Drawing.Size(134, 41)
        Me.SBUpdate.TabIndex = 0
        Me.SBUpdate.Text = "Update to Web"
        '
        'GCBrowsePrice
        '
        Me.GCBrowsePrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBrowsePrice.Location = New System.Drawing.Point(0, 52)
        Me.GCBrowsePrice.MainView = Me.GVBrowsePrice
        Me.GCBrowsePrice.Name = "GCBrowsePrice"
        Me.GCBrowsePrice.Size = New System.Drawing.Size(784, 509)
        Me.GCBrowsePrice.TabIndex = 91
        Me.GCBrowsePrice.TabStop = False
        Me.GCBrowsePrice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBrowsePrice})
        '
        'GVBrowsePrice
        '
        Me.GVBrowsePrice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnFullCode, Me.GridColumnDescription, Me.GridColumnPrice, Me.GridColumnNormalPrice, Me.GridColumnPriceWeb, Me.GridColumnNormalPriceWeb, Me.GridColumnMatch, Me.GridColumnsize})
        Me.GVBrowsePrice.GridControl = Me.GCBrowsePrice
        Me.GVBrowsePrice.Name = "GVBrowsePrice"
        Me.GVBrowsePrice.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVBrowsePrice.OptionsBehavior.Editable = False
        Me.GVBrowsePrice.OptionsSelection.MultiSelect = True
        Me.GVBrowsePrice.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GVBrowsePrice.OptionsView.ShowGroupPanel = False
        '
        'GridColumnFullCode
        '
        Me.GridColumnFullCode.Caption = "Full Code"
        Me.GridColumnFullCode.FieldName = "product_full_code"
        Me.GridColumnFullCode.Name = "GridColumnFullCode"
        Me.GridColumnFullCode.Visible = True
        Me.GridColumnFullCode.VisibleIndex = 1
        Me.GridColumnFullCode.Width = 125
        '
        'GridColumnDescription
        '
        Me.GridColumnDescription.Caption = "Description"
        Me.GridColumnDescription.FieldName = "product_display_name"
        Me.GridColumnDescription.Name = "GridColumnDescription"
        Me.GridColumnDescription.Visible = True
        Me.GridColumnDescription.VisibleIndex = 2
        Me.GridColumnDescription.Width = 125
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Price (ERP)"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 4
        Me.GridColumnPrice.Width = 138
        '
        'GridColumnNormalPrice
        '
        Me.GridColumnNormalPrice.Caption = "Normal Price (ERP)"
        Me.GridColumnNormalPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnNormalPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnNormalPrice.FieldName = "compare_price"
        Me.GridColumnNormalPrice.Name = "GridColumnNormalPrice"
        Me.GridColumnNormalPrice.Width = 183
        '
        'GridColumnPriceWeb
        '
        Me.GridColumnPriceWeb.Caption = "Price (Web)"
        Me.GridColumnPriceWeb.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPriceWeb.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPriceWeb.FieldName = "design_price_web"
        Me.GridColumnPriceWeb.Name = "GridColumnPriceWeb"
        Me.GridColumnPriceWeb.Visible = True
        Me.GridColumnPriceWeb.VisibleIndex = 5
        Me.GridColumnPriceWeb.Width = 138
        '
        'GridColumnNormalPriceWeb
        '
        Me.GridColumnNormalPriceWeb.Caption = "Normal Price (Web)"
        Me.GridColumnNormalPriceWeb.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnNormalPriceWeb.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnNormalPriceWeb.FieldName = "compare_price_web"
        Me.GridColumnNormalPriceWeb.Name = "GridColumnNormalPriceWeb"
        Me.GridColumnNormalPriceWeb.Width = 102
        '
        'GridColumnMatch
        '
        Me.GridColumnMatch.Caption = "Match"
        Me.GridColumnMatch.FieldName = "match"
        Me.GridColumnMatch.Name = "GridColumnMatch"
        Me.GridColumnMatch.Visible = True
        Me.GridColumnMatch.VisibleIndex = 6
        Me.GridColumnMatch.Width = 145
        '
        'GridColumnsize
        '
        Me.GridColumnsize.Caption = "Size"
        Me.GridColumnsize.FieldName = "size"
        Me.GridColumnsize.Name = "GridColumnsize"
        Me.GridColumnsize.Visible = True
        Me.GridColumnsize.VisibleIndex = 3
        Me.GridColumnsize.Width = 65
        '
        'FormPriceForSync
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCBrowsePrice)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormPriceForSync"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Price for Sync"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.GCBrowsePrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBrowsePrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCBrowsePrice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBrowsePrice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnFullCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SBUpdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNormalPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SBSync As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnPriceWeb As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNormalPriceWeb As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMatch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelLastSync As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
