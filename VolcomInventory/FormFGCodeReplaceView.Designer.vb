<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGCodeReplaceView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFGCodeReplaceView))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BViewUnique = New DevExpress.XtraEditors.SimpleButton()
        Me.GCBarcode = New DevExpress.XtraGrid.GridControl()
        Me.GVBarcode = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnReportNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUnqueCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncounting = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BViewUnique)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(889, 43)
        Me.PanelControl1.TabIndex = 2
        '
        'BViewUnique
        '
        Me.BViewUnique.Dock = System.Windows.Forms.DockStyle.Right
        Me.BViewUnique.Image = CType(resources.GetObject("BViewUnique.Image"), System.Drawing.Image)
        Me.BViewUnique.ImageIndex = 13
        Me.BViewUnique.Location = New System.Drawing.Point(774, 2)
        Me.BViewUnique.Name = "BViewUnique"
        Me.BViewUnique.Size = New System.Drawing.Size(113, 39)
        Me.BViewUnique.TabIndex = 25
        Me.BViewUnique.Text = "Print"
        '
        'GCBarcode
        '
        Me.GCBarcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBarcode.Location = New System.Drawing.Point(0, 43)
        Me.GCBarcode.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCBarcode.MainView = Me.GVBarcode
        Me.GCBarcode.Name = "GCBarcode"
        Me.GCBarcode.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit2})
        Me.GCBarcode.Size = New System.Drawing.Size(889, 455)
        Me.GCBarcode.TabIndex = 5
        Me.GCBarcode.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBarcode})
        '
        'GVBarcode
        '
        Me.GVBarcode.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnReportNumber, Me.GridColumn3, Me.GridColumnUnqueCode, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumnCost, Me.GridColumnPrice, Me.GridColumncounting})
        Me.GVBarcode.GridControl = Me.GCBarcode
        Me.GVBarcode.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "fg_code_replace_store_det_qty", Nothing, "{0:n0}")})
        Me.GVBarcode.Name = "GVBarcode"
        Me.GVBarcode.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVBarcode.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVBarcode.OptionsBehavior.ReadOnly = True
        Me.GVBarcode.OptionsCustomization.AllowGroup = False
        Me.GVBarcode.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVBarcode.OptionsView.ShowFooter = True
        Me.GVBarcode.OptionsView.ShowGroupPanel = False
        '
        'GridColumnReportNumber
        '
        Me.GridColumnReportNumber.Caption = "Report Number"
        Me.GridColumnReportNumber.FieldName = "fg_code_replace_store_number"
        Me.GridColumnReportNumber.Name = "GridColumnReportNumber"
        Me.GridColumnReportNumber.Visible = True
        Me.GridColumnReportNumber.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Code"
        Me.GridColumn3.FieldName = "code"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 4
        Me.GridColumn3.Width = 136
        '
        'GridColumnUnqueCode
        '
        Me.GridColumnUnqueCode.Caption = "Unique Code"
        Me.GridColumnUnqueCode.FieldName = "unique_code"
        Me.GridColumnUnqueCode.Name = "GridColumnUnqueCode"
        Me.GridColumnUnqueCode.Visible = True
        Me.GridColumnUnqueCode.VisibleIndex = 5
        Me.GridColumnUnqueCode.Width = 303
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Description"
        Me.GridColumn4.FieldName = "name"
        Me.GridColumn4.FieldNameSortGroup = "id_design"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 6
        Me.GridColumn4.Width = 389
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
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 7
        Me.GridColumn5.Width = 109
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Color"
        Me.GridColumn6.FieldName = "color"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        Me.GridColumn6.Width = 124
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "DO Number"
        Me.GridColumn7.FieldName = "pl_sales_order_del_number"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Account Name"
        Me.GridColumn8.FieldName = "comp_name"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 3
        Me.GridColumn8.Width = 204
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Account#"
        Me.GridColumn9.FieldName = "comp_number"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 2
        Me.GridColumn9.Width = 64
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Id Product"
        Me.GridColumn14.FieldName = "id_product"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Id Det"
        Me.GridColumn15.FieldName = "id_fg_code_replace_store_det"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Id Comp"
        Me.GridColumn16.FieldName = "id_comp"
        Me.GridColumn16.Name = "GridColumn16"
        '
        'GridColumnCost
        '
        Me.GridColumnCost.Caption = "Cost"
        Me.GridColumnCost.DisplayFormat.FormatString = "N0"
        Me.GridColumnCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCost.FieldName = "design_cop"
        Me.GridColumnCost.Name = "GridColumnCost"
        Me.GridColumnCost.OptionsColumn.AllowEdit = False
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Price On Tag"
        Me.GridColumnPrice.DisplayFormat.FormatString = "n2"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 8
        Me.GridColumnPrice.Width = 234
        '
        'GridColumncounting
        '
        Me.GridColumncounting.Caption = "counting"
        Me.GridColumncounting.FieldName = "counting"
        Me.GridColumncounting.Name = "GridColumncounting"
        '
        'RepositoryItemSpinEdit2
        '
        Me.RepositoryItemSpinEdit2.AutoHeight = False
        Me.RepositoryItemSpinEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit2.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit2.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit2.Name = "RepositoryItemSpinEdit2"
        '
        'FormFGCodeReplaceView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 498)
        Me.Controls.Add(Me.GCBarcode)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormFGCodeReplaceView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Unique"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BViewUnique As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCBarcode As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBarcode As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnReportNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUnqueCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncounting As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
End Class
