<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterCompanyContact
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterCompanyContact))
        Me.EPContact = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.GCCommand = New DevExpress.XtraEditors.GroupControl()
        Me.PDetail = New DevExpress.XtraEditors.PanelControl()
        Me.TEEmail = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPosition = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.LEDefault = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TEContactNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TECP = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.BEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.BNew = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCCompanyContactList = New DevExpress.XtraGrid.GridControl()
        Me.GVCompanyContactList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.id_contact = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.contact_person = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.default_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckedComboBoxEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit()
        CType(Me.EPContact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCCommand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCCommand.SuspendLayout()
        CType(Me.PDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PDetail.SuspendLayout()
        CType(Me.TEEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDefault.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEContactNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCCompanyContactList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCompanyContactList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckedComboBoxEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EPContact
        '
        Me.EPContact.ContainerControl = Me
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(32, 32)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "Package-Add256.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "document_add_32.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "Edits.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "7_64x64.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "8_64x64.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "9_64x64.png")
        Me.LargeImageCollection.Images.SetKeyName(6, "23-Full Trash_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "27-Edit Text_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "document_add_32.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "printer-blue32.png")
        Me.LargeImageCollection.Images.SetKeyName(10, "Error (2).png")
        Me.LargeImageCollection.Images.SetKeyName(11, "volcom.jpg")
        '
        'GCCommand
        '
        Me.GCCommand.Controls.Add(Me.PDetail)
        Me.GCCommand.Controls.Add(Me.PanelControl1)
        Me.GCCommand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCommand.Location = New System.Drawing.Point(0, 228)
        Me.GCCommand.Name = "GCCommand"
        Me.GCCommand.Size = New System.Drawing.Size(605, 224)
        Me.GCCommand.TabIndex = 3
        Me.GCCommand.Text = "Command"
        '
        'PDetail
        '
        Me.PDetail.Controls.Add(Me.TEEmail)
        Me.PDetail.Controls.Add(Me.LabelControl4)
        Me.PDetail.Controls.Add(Me.TEPosition)
        Me.PDetail.Controls.Add(Me.LabelControl5)
        Me.PDetail.Controls.Add(Me.BSave)
        Me.PDetail.Controls.Add(Me.BCancel)
        Me.PDetail.Controls.Add(Me.LEDefault)
        Me.PDetail.Controls.Add(Me.LabelControl3)
        Me.PDetail.Controls.Add(Me.TEContactNumber)
        Me.PDetail.Controls.Add(Me.LabelControl2)
        Me.PDetail.Controls.Add(Me.TECP)
        Me.PDetail.Controls.Add(Me.LabelControl1)
        Me.PDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PDetail.Enabled = False
        Me.PDetail.Location = New System.Drawing.Point(2, 20)
        Me.PDetail.Name = "PDetail"
        Me.PDetail.Size = New System.Drawing.Size(456, 202)
        Me.PDetail.TabIndex = 9
        '
        'TEEmail
        '
        Me.TEEmail.Location = New System.Drawing.Point(231, 85)
        Me.TEEmail.Name = "TEEmail"
        Me.TEEmail.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TEEmail.Properties.Appearance.Options.UseFont = True
        Me.TEEmail.Size = New System.Drawing.Size(205, 22)
        Me.TEEmail.TabIndex = 21
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl4.Location = New System.Drawing.Point(231, 61)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(31, 15)
        Me.LabelControl4.TabIndex = 20
        Me.LabelControl4.Text = "Email"
        '
        'TEPosition
        '
        Me.TEPosition.Location = New System.Drawing.Point(231, 32)
        Me.TEPosition.Name = "TEPosition"
        Me.TEPosition.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TEPosition.Properties.Appearance.Options.UseFont = True
        Me.TEPosition.Size = New System.Drawing.Size(205, 22)
        Me.TEPosition.TabIndex = 19
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl5.Location = New System.Drawing.Point(231, 8)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(46, 15)
        Me.LabelControl5.TabIndex = 18
        Me.LabelControl5.Text = "Position"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(351, 167)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(85, 23)
        Me.BSave.TabIndex = 17
        Me.BSave.Text = "Save"
        '
        'BCancel
        '
        Me.BCancel.Location = New System.Drawing.Point(266, 167)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(79, 23)
        Me.BCancel.TabIndex = 16
        Me.BCancel.Text = "Cancel"
        '
        'LEDefault
        '
        Me.LEDefault.Location = New System.Drawing.Point(10, 135)
        Me.LEDefault.Name = "LEDefault"
        Me.LEDefault.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDefault.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_default", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("default_name", "Status")})
        Me.LEDefault.Properties.NullText = ""
        Me.LEDefault.Size = New System.Drawing.Size(215, 20)
        Me.LEDefault.TabIndex = 14
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl3.Location = New System.Drawing.Point(10, 114)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(85, 15)
        Me.LabelControl3.TabIndex = 13
        Me.LabelControl3.Text = "Default Contact"
        '
        'TEContactNumber
        '
        Me.TEContactNumber.Location = New System.Drawing.Point(10, 85)
        Me.TEContactNumber.Name = "TEContactNumber"
        Me.TEContactNumber.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TEContactNumber.Properties.Appearance.Options.UseFont = True
        Me.TEContactNumber.Size = New System.Drawing.Size(215, 22)
        Me.TEContactNumber.TabIndex = 12
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl2.Location = New System.Drawing.Point(10, 61)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(88, 15)
        Me.LabelControl2.TabIndex = 11
        Me.LabelControl2.Text = "Contact Number"
        '
        'TECP
        '
        Me.TECP.Location = New System.Drawing.Point(12, 32)
        Me.TECP.Name = "TECP"
        Me.TECP.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TECP.Properties.Appearance.Options.UseFont = True
        Me.TECP.Size = New System.Drawing.Size(213, 22)
        Me.TECP.TabIndex = 10
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl1.Location = New System.Drawing.Point(12, 8)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(83, 15)
        Me.LabelControl1.TabIndex = 9
        Me.LabelControl1.Text = "Contact Person"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BDelete)
        Me.PanelControl1.Controls.Add(Me.BEdit)
        Me.PanelControl1.Controls.Add(Me.BNew)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl1.Location = New System.Drawing.Point(458, 20)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(145, 202)
        Me.PanelControl1.TabIndex = 6
        '
        'BDelete
        '
        Me.BDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BDelete.ImageIndex = 6
        Me.BDelete.ImageList = Me.LargeImageCollection
        Me.BDelete.Location = New System.Drawing.Point(2, 136)
        Me.BDelete.Name = "BDelete"
        Me.BDelete.Size = New System.Drawing.Size(141, 64)
        Me.BDelete.TabIndex = 10
        Me.BDelete.Text = "Delete"
        Me.BDelete.Visible = False
        '
        'BEdit
        '
        Me.BEdit.Dock = System.Windows.Forms.DockStyle.Top
        Me.BEdit.ImageIndex = 7
        Me.BEdit.ImageList = Me.LargeImageCollection
        Me.BEdit.Location = New System.Drawing.Point(2, 69)
        Me.BEdit.Name = "BEdit"
        Me.BEdit.Size = New System.Drawing.Size(141, 67)
        Me.BEdit.TabIndex = 9
        Me.BEdit.Text = "Edit"
        Me.BEdit.Visible = False
        '
        'BNew
        '
        Me.BNew.Dock = System.Windows.Forms.DockStyle.Top
        Me.BNew.ImageIndex = 1
        Me.BNew.ImageList = Me.LargeImageCollection
        Me.BNew.Location = New System.Drawing.Point(2, 2)
        Me.BNew.Name = "BNew"
        Me.BNew.Size = New System.Drawing.Size(141, 67)
        Me.BNew.TabIndex = 8
        Me.BNew.Text = "New"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GCCompanyContactList)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(605, 228)
        Me.GroupControl1.TabIndex = 2
        Me.GroupControl1.Text = "Contact List"
        '
        'GCCompanyContactList
        '
        Me.GCCompanyContactList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCompanyContactList.Location = New System.Drawing.Point(2, 20)
        Me.GCCompanyContactList.MainView = Me.GVCompanyContactList
        Me.GCCompanyContactList.Name = "GCCompanyContactList"
        Me.GCCompanyContactList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckedComboBoxEdit1, Me.RepositoryItemCheckEdit1})
        Me.GCCompanyContactList.Size = New System.Drawing.Size(601, 206)
        Me.GCCompanyContactList.TabIndex = 0
        Me.GCCompanyContactList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCompanyContactList})
        '
        'GVCompanyContactList
        '
        Me.GVCompanyContactList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.id_contact, Me.contact_person, Me.number, Me.GridColumn2, Me.GridColumn1, Me.default_status})
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
        Me.contact_person.Width = 521
        '
        'number
        '
        Me.number.Caption = "Contact Number"
        Me.number.FieldName = "contact_number"
        Me.number.Name = "number"
        Me.number.Visible = True
        Me.number.VisibleIndex = 2
        Me.number.Width = 313
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Position"
        Me.GridColumn2.FieldName = "position"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 168
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Email"
        Me.GridColumn1.FieldName = "email"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 3
        Me.GridColumn1.Width = 465
        '
        'default_status
        '
        Me.default_status.AppearanceHeader.Options.UseTextOptions = True
        Me.default_status.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.default_status.Caption = "Default"
        Me.default_status.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.default_status.FieldName = "is_default"
        Me.default_status.Name = "default_status"
        Me.default_status.Tag = True
        Me.default_status.Visible = True
        Me.default_status.VisibleIndex = 4
        Me.default_status.Width = 165
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'RepositoryItemCheckedComboBoxEdit1
        '
        Me.RepositoryItemCheckedComboBoxEdit1.AutoHeight = False
        Me.RepositoryItemCheckedComboBoxEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemCheckedComboBoxEdit1.Name = "RepositoryItemCheckedComboBoxEdit1"
        '
        'FormMasterCompanyContact
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 452)
        Me.Controls.Add(Me.GCCommand)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterCompanyContact"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contact"
        CType(Me.EPContact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCCommand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCCommand.ResumeLayout(False)
        CType(Me.PDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PDetail.ResumeLayout(False)
        Me.PDetail.PerformLayout()
        CType(Me.TEEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDefault.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEContactNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCCompanyContactList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCompanyContactList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckedComboBoxEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EPContact As System.Windows.Forms.ErrorProvider
    Friend WithEvents GCCommand As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PDetail As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LEDefault As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEContactNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECP As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BDelete As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents BEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCCompanyContactList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCompanyContactList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents id_contact As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents contact_person As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents default_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckedComboBoxEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEEmail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPosition As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
