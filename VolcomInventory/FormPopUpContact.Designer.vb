<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpContact
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPopUpContact))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupGeneral = New DevExpress.XtraEditors.GroupControl()
        Me.GCCompany = New DevExpress.XtraGrid.GridControl()
        Me.GVCompany = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.id_company = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CompanyCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.company = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.address_primary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.is_active = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Category = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.is_active_company = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BContact = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BDelComp = New DevExpress.XtraEditors.SimpleButton()
        Me.BEditComp = New DevExpress.XtraEditors.SimpleButton()
        Me.BAddComp = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCCompanyContactList = New DevExpress.XtraGrid.GridControl()
        Me.GVCompanyContactList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.id_contact = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.contact_person = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.default_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnDrawer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRack = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLocaltor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckedComboBoxEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneral.SuspendLayout()
        CType(Me.GCCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCCompanyContactList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCompanyContactList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckedComboBoxEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupGeneral)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(829, 399)
        Me.SplitContainerControl1.SplitterPosition = 257
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupGeneral
        '
        Me.GroupGeneral.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupGeneral.Controls.Add(Me.GCCompany)
        Me.GroupGeneral.Controls.Add(Me.PanelControl3)
        Me.GroupGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupGeneral.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneral.Name = "GroupGeneral"
        Me.GroupGeneral.Size = New System.Drawing.Size(829, 257)
        Me.GroupGeneral.TabIndex = 15
        Me.GroupGeneral.Text = "Company"
        '
        'GCCompany
        '
        Me.GCCompany.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCompany.Location = New System.Drawing.Point(2, 56)
        Me.GCCompany.MainView = Me.GVCompany
        Me.GCCompany.Name = "GCCompany"
        Me.GCCompany.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.is_active_company, Me.RepositoryItemCheckEdit1})
        Me.GCCompany.Size = New System.Drawing.Size(825, 199)
        Me.GCCompany.TabIndex = 4
        Me.GCCompany.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCompany})
        '
        'GVCompany
        '
        Me.GVCompany.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.id_company, Me.CompanyCode, Me.company, Me.address_primary, Me.is_active, Me.Category})
        Me.GVCompany.GridControl = Me.GCCompany
        Me.GVCompany.GroupCount = 1
        Me.GVCompany.Name = "GVCompany"
        Me.GVCompany.OptionsBehavior.Editable = False
        Me.GVCompany.OptionsFind.AlwaysVisible = True
        Me.GVCompany.OptionsView.ShowGroupPanel = False
        Me.GVCompany.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.Category, DevExpress.Data.ColumnSortOrder.Ascending)})
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
        Me.CompanyCode.VisibleIndex = 0
        Me.CompanyCode.Width = 79
        '
        'company
        '
        Me.company.Caption = "Company"
        Me.company.FieldName = "comp_name"
        Me.company.Name = "company"
        Me.company.Visible = True
        Me.company.VisibleIndex = 1
        Me.company.Width = 105
        '
        'address_primary
        '
        Me.address_primary.Caption = "Address"
        Me.address_primary.FieldName = "address_primary"
        Me.address_primary.Name = "address_primary"
        Me.address_primary.Visible = True
        Me.address_primary.VisibleIndex = 2
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
        Me.is_active.Visible = True
        Me.is_active.VisibleIndex = 3
        Me.is_active.Width = 52
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit1.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Category
        '
        Me.Category.Caption = "Category"
        Me.Category.FieldName = "company_category"
        Me.Category.Name = "Category"
        Me.Category.Width = 80
        '
        'is_active_company
        '
        Me.is_active_company.AutoHeight = False
        Me.is_active_company.DisplayValueChecked = "1"
        Me.is_active_company.DisplayValueUnchecked = "0"
        Me.is_active_company.Name = "is_active_company"
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.BContact)
        Me.PanelControl3.Controls.Add(Me.BDelComp)
        Me.PanelControl3.Controls.Add(Me.BEditComp)
        Me.PanelControl3.Controls.Add(Me.BAddComp)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(2, 20)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(825, 36)
        Me.PanelControl3.TabIndex = 30
        '
        'BContact
        '
        Me.BContact.Dock = System.Windows.Forms.DockStyle.Left
        Me.BContact.ImageIndex = 3
        Me.BContact.ImageList = Me.LargeImageCollection
        Me.BContact.Location = New System.Drawing.Point(0, 0)
        Me.BContact.Name = "BContact"
        Me.BContact.Size = New System.Drawing.Size(93, 36)
        Me.BContact.TabIndex = 4
        Me.BContact.Text = "Contact"
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "contact32.png")
        '
        'BDelComp
        '
        Me.BDelComp.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDelComp.ImageIndex = 1
        Me.BDelComp.ImageList = Me.LargeImageCollection
        Me.BDelComp.Location = New System.Drawing.Point(578, 0)
        Me.BDelComp.Name = "BDelComp"
        Me.BDelComp.Size = New System.Drawing.Size(85, 36)
        Me.BDelComp.TabIndex = 3
        Me.BDelComp.Text = "Delete"
        '
        'BEditComp
        '
        Me.BEditComp.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEditComp.ImageIndex = 2
        Me.BEditComp.ImageList = Me.LargeImageCollection
        Me.BEditComp.Location = New System.Drawing.Point(663, 0)
        Me.BEditComp.Name = "BEditComp"
        Me.BEditComp.Size = New System.Drawing.Size(82, 36)
        Me.BEditComp.TabIndex = 2
        Me.BEditComp.Text = "Edit"
        '
        'BAddComp
        '
        Me.BAddComp.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAddComp.ImageIndex = 0
        Me.BAddComp.ImageList = Me.LargeImageCollection
        Me.BAddComp.Location = New System.Drawing.Point(745, 0)
        Me.BAddComp.Name = "BAddComp"
        Me.BAddComp.Size = New System.Drawing.Size(80, 36)
        Me.BAddComp.TabIndex = 1
        Me.BAddComp.Text = "Add"
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControl1.Controls.Add(Me.GCCompanyContactList)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(829, 137)
        Me.GroupControl1.TabIndex = 16
        Me.GroupControl1.Text = "Contact"
        '
        'GCCompanyContactList
        '
        Me.GCCompanyContactList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCompanyContactList.Location = New System.Drawing.Point(2, 20)
        Me.GCCompanyContactList.MainView = Me.GVCompanyContactList
        Me.GCCompanyContactList.Name = "GCCompanyContactList"
        Me.GCCompanyContactList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckedComboBoxEdit1, Me.RepositoryItemCheckEdit2})
        Me.GCCompanyContactList.Size = New System.Drawing.Size(825, 115)
        Me.GCCompanyContactList.TabIndex = 1
        Me.GCCompanyContactList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCompanyContactList})
        '
        'GVCompanyContactList
        '
        Me.GVCompanyContactList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.id_contact, Me.contact_person, Me.number, Me.default_status, Me.GridColumnDrawer, Me.GridColumnRack, Me.GridColumnLocaltor})
        Me.GVCompanyContactList.GridControl = Me.GCCompanyContactList
        Me.GVCompanyContactList.Name = "GVCompanyContactList"
        Me.GVCompanyContactList.OptionsBehavior.Editable = False
        Me.GVCompanyContactList.OptionsView.ShowGroupPanel = False
        '
        'id_contact
        '
        Me.id_contact.AppearanceCell.Options.UseTextOptions = True
        Me.id_contact.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.id_contact.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.id_contact.Caption = "ID"
        Me.id_contact.FieldName = "id_comp_contact"
        Me.id_contact.Name = "id_contact"
        '
        'contact_person
        '
        Me.contact_person.Caption = "Contact Name"
        Me.contact_person.FieldName = "contact_person"
        Me.contact_person.MinWidth = 50
        Me.contact_person.Name = "contact_person"
        Me.contact_person.Visible = True
        Me.contact_person.VisibleIndex = 0
        Me.contact_person.Width = 400
        '
        'number
        '
        Me.number.Caption = "Contact Number"
        Me.number.FieldName = "contact_number"
        Me.number.Name = "number"
        Me.number.Visible = True
        Me.number.VisibleIndex = 1
        Me.number.Width = 266
        '
        'default_status
        '
        Me.default_status.AppearanceHeader.Options.UseTextOptions = True
        Me.default_status.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.default_status.Caption = "Default"
        Me.default_status.ColumnEdit = Me.RepositoryItemCheckEdit2
        Me.default_status.FieldName = "is_default"
        Me.default_status.Name = "default_status"
        Me.default_status.Tag = True
        Me.default_status.Visible = True
        Me.default_status.VisibleIndex = 2
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        '
        'GridColumnDrawer
        '
        Me.GridColumnDrawer.Caption = "Drawer"
        Me.GridColumnDrawer.FieldName = "id_wh_drawer"
        Me.GridColumnDrawer.Name = "GridColumnDrawer"
        Me.GridColumnDrawer.OptionsColumn.AllowEdit = False
        '
        'GridColumnRack
        '
        Me.GridColumnRack.Caption = "Rack"
        Me.GridColumnRack.FieldName = "id_wh_rack"
        Me.GridColumnRack.Name = "GridColumnRack"
        Me.GridColumnRack.OptionsColumn.AllowEdit = False
        '
        'GridColumnLocaltor
        '
        Me.GridColumnLocaltor.Caption = "Locator"
        Me.GridColumnLocaltor.FieldName = "id_wh_locator"
        Me.GridColumnLocaltor.Name = "GridColumnLocaltor"
        Me.GridColumnLocaltor.OptionsColumn.AllowEdit = False
        '
        'RepositoryItemCheckedComboBoxEdit1
        '
        Me.RepositoryItemCheckedComboBoxEdit1.AutoHeight = False
        Me.RepositoryItemCheckedComboBoxEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemCheckedComboBoxEdit1.Name = "RepositoryItemCheckedComboBoxEdit1"
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(671, 9)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(70, 23)
        Me.BCancel.TabIndex = 2
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(747, 9)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 23)
        Me.BSave.TabIndex = 1
        Me.BSave.Text = "Choose"
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.BtnCancel)
        Me.PanelControl2.Controls.Add(Me.BtnSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 399)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(829, 37)
        Me.PanelControl2.TabIndex = 27
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(632, 0)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(94, 37)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(726, 0)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(103, 37)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Choose"
        '
        'FormPopUpContact
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 436)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpContact"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Contact"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneral.ResumeLayout(False)
        CType(Me.GCCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCCompanyContactList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCompanyContactList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckedComboBoxEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupGeneral As DevExpress.XtraEditors.GroupControl
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
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCCompanyContactList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCompanyContactList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents id_contact As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents contact_person As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents default_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckedComboBoxEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BContact As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents BDelComp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BEditComp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAddComp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnDrawer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRack As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLocaltor As DevExpress.XtraGrid.Columns.GridColumn
End Class
