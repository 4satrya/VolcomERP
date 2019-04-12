<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGProposePriceRevAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFGProposePriceRevAdd))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumncode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdPPDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_design = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_prod_demand_design = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMSRP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnadditional_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 365)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(734, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(564, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(86, 42)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Close"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(650, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(82, 42)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "Add"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCData.Size = New System.Drawing.Size(734, 365)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumncode, Me.GridColumnName, Me.GridColumnPrice, Me.GridColumnIdPPDet, Me.GridColumnid_design, Me.GridColumnid_prod_demand_design, Me.GridColumnMSRP, Me.GridColumnadditional_price})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumncode
        '
        Me.GridColumncode.Caption = "Code"
        Me.GridColumncode.FieldName = "code"
        Me.GridColumncode.Name = "GridColumncode"
        Me.GridColumncode.OptionsColumn.AllowEdit = False
        Me.GridColumncode.Visible = True
        Me.GridColumncode.VisibleIndex = 0
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Style"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 1
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Current Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "N0"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.OptionsColumn.AllowEdit = False
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 2
        '
        'GridColumnIdPPDet
        '
        Me.GridColumnIdPPDet.Caption = "id_fg_propose_price_detail"
        Me.GridColumnIdPPDet.FieldName = "id_fg_propose_price_detail"
        Me.GridColumnIdPPDet.Name = "GridColumnIdPPDet"
        Me.GridColumnIdPPDet.OptionsColumn.AllowEdit = False
        '
        'GridColumnid_design
        '
        Me.GridColumnid_design.Caption = "id_design"
        Me.GridColumnid_design.FieldName = "id_design"
        Me.GridColumnid_design.Name = "GridColumnid_design"
        Me.GridColumnid_design.OptionsColumn.AllowEdit = False
        '
        'GridColumnid_prod_demand_design
        '
        Me.GridColumnid_prod_demand_design.Caption = "id_prod_demand_design"
        Me.GridColumnid_prod_demand_design.FieldName = "id_prod_demand_design"
        Me.GridColumnid_prod_demand_design.Name = "GridColumnid_prod_demand_design"
        Me.GridColumnid_prod_demand_design.OptionsColumn.AllowEdit = False
        '
        'GridColumnMSRP
        '
        Me.GridColumnMSRP.Caption = "MSRP"
        Me.GridColumnMSRP.DisplayFormat.FormatString = "N2"
        Me.GridColumnMSRP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnMSRP.FieldName = "msrp"
        Me.GridColumnMSRP.Name = "GridColumnMSRP"
        Me.GridColumnMSRP.OptionsColumn.AllowEdit = False
        '
        'GridColumnadditional_price
        '
        Me.GridColumnadditional_price.Caption = "Additional Price"
        Me.GridColumnadditional_price.FieldName = "additional_price"
        Me.GridColumnadditional_price.Name = "GridColumnadditional_price"
        Me.GridColumnadditional_price.OptionsColumn.AllowEdit = False
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'FormFGProposePriceRevAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 411)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormFGProposePriceRevAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Items"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumncode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPPDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnid_design As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_prod_demand_design As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMSRP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnadditional_price As DevExpress.XtraGrid.Columns.GridColumn
End Class
