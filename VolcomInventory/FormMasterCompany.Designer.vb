<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterCompany
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
        Me.GCCompany = New DevExpress.XtraGrid.GridControl()
        Me.GVCompany = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.id_company = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CompanyCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.company = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.address_primary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.is_active = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GCStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Category = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.is_active_company = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCCompany
        '
        Me.GCCompany.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCompany.Location = New System.Drawing.Point(0, 0)
        Me.GCCompany.MainView = Me.GVCompany
        Me.GCCompany.Name = "GCCompany"
        Me.GCCompany.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.is_active_company, Me.RepositoryItemCheckEdit1})
        Me.GCCompany.Size = New System.Drawing.Size(1008, 729)
        Me.GCCompany.TabIndex = 3
        Me.GCCompany.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCompany})
        '
        'GVCompany
        '
        Me.GVCompany.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.id_company, Me.CompanyCode, Me.company, Me.address_primary, Me.is_active, Me.Category, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GCStatus})
        Me.GVCompany.GridControl = Me.GCCompany
        Me.GVCompany.Name = "GVCompany"
        Me.GVCompany.OptionsBehavior.Editable = False
        Me.GVCompany.OptionsView.ShowGroupPanel = False
        '
        'id_company
        '
        Me.id_company.Caption = "ID"
        Me.id_company.FieldName = "id_comp"
        Me.id_company.Name = "id_company"
        '
        'CompanyCode
        '
        Me.CompanyCode.Caption = "Code"
        Me.CompanyCode.FieldName = "comp_number"
        Me.CompanyCode.Name = "CompanyCode"
        Me.CompanyCode.Visible = True
        Me.CompanyCode.VisibleIndex = 1
        Me.CompanyCode.Width = 79
        '
        'company
        '
        Me.company.Caption = "Company"
        Me.company.FieldName = "comp_name"
        Me.company.Name = "company"
        Me.company.Visible = True
        Me.company.VisibleIndex = 0
        Me.company.Width = 105
        '
        'address_primary
        '
        Me.address_primary.Caption = "Address"
        Me.address_primary.FieldName = "address_primary"
        Me.address_primary.Name = "address_primary"
        Me.address_primary.Visible = True
        Me.address_primary.VisibleIndex = 3
        Me.address_primary.Width = 289
        '
        'is_active
        '
        Me.is_active.AppearanceHeader.Options.UseTextOptions = True
        Me.is_active.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.is_active.Caption = "Active"
        Me.is_active.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.is_active.FieldName = "is_active"
        Me.is_active.Name = "is_active"
        Me.is_active.Width = 52
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit1.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'GCStatus
        '
        Me.GCStatus.Caption = "Status"
        Me.GCStatus.FieldName = "comp_status"
        Me.GCStatus.Name = "GCStatus"
        Me.GCStatus.Visible = True
        Me.GCStatus.VisibleIndex = 7
        '
        'Category
        '
        Me.Category.Caption = "Category"
        Me.Category.FieldName = "company_category"
        Me.Category.Name = "Category"
        Me.Category.Visible = True
        Me.Category.VisibleIndex = 2
        Me.Category.Width = 80
        '
        'is_active_company
        '
        Me.is_active_company.AutoHeight = False
        Me.is_active_company.DisplayValueChecked = "1"
        Me.is_active_company.DisplayValueUnchecked = "0"
        Me.is_active_company.Name = "is_active_company"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Contact Person"
        Me.GridColumn1.FieldName = "contact_person"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 4
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Number"
        Me.GridColumn2.FieldName = "contact_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 5
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Email"
        Me.GridColumn3.FieldName = "contact_email"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 6
        '
        'FormMasterCompany
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.GCCompany)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterCompany"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Company"
        CType(Me.GCCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCCompany As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCompany As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents id_company As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CompanyCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents company As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents address_primary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents is_active As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Category As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents is_active_company As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GCStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
