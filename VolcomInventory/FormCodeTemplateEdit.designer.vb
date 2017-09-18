<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCodeTemplateEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCodeTemplateEdit))
        Me.BDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.XTCCode = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPCode = New DevExpress.XtraTab.XtraTabPage()
        Me.GCCode = New DevExpress.XtraGrid.GridControl()
        Me.GVCode = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColumnIdCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCodeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCodeDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIsIncludeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.ColIsIncludeCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.XTPCodeDet = New DevExpress.XtraTab.XtraTabPage()
        Me.GCCodeDetail = New DevExpress.XtraGrid.GridControl()
        Me.GVCodeDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColumnIdCodeDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColumnCodeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColumnDisplayName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PCDeliveryTitle = New DevExpress.XtraEditors.PanelControl()
        Me.LabelCodeContent = New DevExpress.XtraEditors.LabelControl()
        Me.LabelCodeTitle = New DevExpress.XtraEditors.LabelControl()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCCode.SuspendLayout()
        Me.XTPCode.SuspendLayout()
        CType(Me.GCCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPCodeDet.SuspendLayout()
        CType(Me.GCCodeDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCodeDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCDeliveryTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCDeliveryTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'BDelete
        '
        Me.BDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDelete.ImageIndex = 1
        Me.BDelete.ImageList = Me.LargeImageCollection
        Me.BDelete.Location = New System.Drawing.Point(449, 2)
        Me.BDelete.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BDelete.Name = "BDelete"
        Me.BDelete.Size = New System.Drawing.Size(81, 42)
        Me.BDelete.TabIndex = 2
        Me.BDelete.Text = "Delete"
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        '
        'BEdit
        '
        Me.BEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEdit.ImageIndex = 2
        Me.BEdit.ImageList = Me.LargeImageCollection
        Me.BEdit.Location = New System.Drawing.Point(530, 2)
        Me.BEdit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BEdit.Name = "BEdit"
        Me.BEdit.Size = New System.Drawing.Size(81, 42)
        Me.BEdit.TabIndex = 1
        Me.BEdit.Text = "Edit"
        '
        'BAdd
        '
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAdd.ImageIndex = 0
        Me.BAdd.ImageList = Me.LargeImageCollection
        Me.BAdd.Location = New System.Drawing.Point(611, 2)
        Me.BAdd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(81, 42)
        Me.BAdd.TabIndex = 0
        Me.BAdd.Text = "Add"
        '
        'XTCCode
        '
        Me.XTCCode.AppearancePage.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTCCode.AppearancePage.Header.Options.UseFont = True
        Me.XTCCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCCode.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left
        Me.XTCCode.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Vertical
        Me.XTCCode.Location = New System.Drawing.Point(0, 0)
        Me.XTCCode.Name = "XTCCode"
        Me.XTCCode.SelectedTabPage = Me.XTPCode
        Me.XTCCode.Size = New System.Drawing.Size(723, 330)
        Me.XTCCode.TabIndex = 4
        Me.XTCCode.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPCode, Me.XTPCodeDet})
        '
        'XTPCode
        '
        Me.XTPCode.Controls.Add(Me.GCCode)
        Me.XTPCode.Name = "XTPCode"
        Me.XTPCode.Size = New System.Drawing.Size(694, 324)
        Me.XTPCode.Text = "Code"
        '
        'GCCode
        '
        Me.GCCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCode.Location = New System.Drawing.Point(0, 0)
        Me.GCCode.MainView = Me.GVCode
        Me.GCCode.Name = "GCCode"
        Me.GCCode.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemCheckEdit3, Me.RepositoryItemCheckEdit4})
        Me.GCCode.Size = New System.Drawing.Size(694, 324)
        Me.GCCode.TabIndex = 0
        Me.GCCode.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCode})
        '
        'GVCode
        '
        Me.GVCode.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColumnIdCode, Me.GCCodeName, Me.GCCodeDesc, Me.ColIsIncludeName, Me.ColIsIncludeCode})
        Me.GVCode.GridControl = Me.GCCode
        Me.GVCode.Name = "GVCode"
        Me.GVCode.OptionsBehavior.Editable = False
        Me.GVCode.OptionsView.ShowGroupPanel = False
        '
        'ColumnIdCode
        '
        Me.ColumnIdCode.Caption = "Id Code"
        Me.ColumnIdCode.FieldName = "id_code"
        Me.ColumnIdCode.Name = "ColumnIdCode"
        '
        'GCCodeName
        '
        Me.GCCodeName.Caption = "Code"
        Me.GCCodeName.FieldName = "code_name"
        Me.GCCodeName.Name = "GCCodeName"
        Me.GCCodeName.Visible = True
        Me.GCCodeName.VisibleIndex = 0
        Me.GCCodeName.Width = 132
        '
        'GCCodeDesc
        '
        Me.GCCodeDesc.Caption = "Description"
        Me.GCCodeDesc.FieldName = "description"
        Me.GCCodeDesc.Name = "GCCodeDesc"
        Me.GCCodeDesc.Visible = True
        Me.GCCodeDesc.VisibleIndex = 1
        Me.GCCodeDesc.Width = 210
        '
        'ColIsIncludeName
        '
        Me.ColIsIncludeName.AppearanceHeader.Options.UseTextOptions = True
        Me.ColIsIncludeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColIsIncludeName.Caption = "Include in Name"
        Me.ColIsIncludeName.ColumnEdit = Me.RepositoryItemCheckEdit3
        Me.ColIsIncludeName.FieldName = "is_include_name"
        Me.ColIsIncludeName.Name = "ColIsIncludeName"
        Me.ColIsIncludeName.Visible = True
        Me.ColIsIncludeName.VisibleIndex = 2
        Me.ColIsIncludeName.Width = 74
        '
        'RepositoryItemCheckEdit3
        '
        Me.RepositoryItemCheckEdit3.AutoHeight = False
        Me.RepositoryItemCheckEdit3.Name = "RepositoryItemCheckEdit3"
        '
        'ColIsIncludeCode
        '
        Me.ColIsIncludeCode.AppearanceHeader.Options.UseTextOptions = True
        Me.ColIsIncludeCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColIsIncludeCode.Caption = "Include in Code"
        Me.ColIsIncludeCode.ColumnEdit = Me.RepositoryItemCheckEdit4
        Me.ColIsIncludeCode.FieldName = "is_include_code"
        Me.ColIsIncludeCode.Name = "ColIsIncludeCode"
        Me.ColIsIncludeCode.Visible = True
        Me.ColIsIncludeCode.VisibleIndex = 3
        Me.ColIsIncludeCode.Width = 80
        '
        'RepositoryItemCheckEdit4
        '
        Me.RepositoryItemCheckEdit4.AutoHeight = False
        Me.RepositoryItemCheckEdit4.Name = "RepositoryItemCheckEdit4"
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit1.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'XTPCodeDet
        '
        Me.XTPCodeDet.Controls.Add(Me.GCCodeDetail)
        Me.XTPCodeDet.Controls.Add(Me.PCDeliveryTitle)
        Me.XTPCodeDet.Name = "XTPCodeDet"
        Me.XTPCodeDet.Size = New System.Drawing.Size(694, 324)
        Me.XTPCodeDet.Text = "Detail"
        '
        'GCCodeDetail
        '
        Me.GCCodeDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCodeDetail.Location = New System.Drawing.Point(0, 46)
        Me.GCCodeDetail.MainView = Me.GVCodeDetail
        Me.GCCodeDetail.Name = "GCCodeDetail"
        Me.GCCodeDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2})
        Me.GCCodeDetail.Size = New System.Drawing.Size(694, 278)
        Me.GCCodeDetail.TabIndex = 6
        Me.GCCodeDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCodeDetail})
        '
        'GVCodeDetail
        '
        Me.GVCodeDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColumnIdCodeDet, Me.ColumnCode, Me.ColumnCodeName, Me.ColumnDisplayName})
        Me.GVCodeDetail.GridControl = Me.GCCodeDetail
        Me.GVCodeDetail.Name = "GVCodeDetail"
        Me.GVCodeDetail.OptionsBehavior.Editable = False
        Me.GVCodeDetail.OptionsView.ShowGroupPanel = False
        '
        'ColumnIdCodeDet
        '
        Me.ColumnIdCodeDet.Caption = "Id Code Detail"
        Me.ColumnIdCodeDet.FieldName = "id_code_detail"
        Me.ColumnIdCodeDet.Name = "ColumnIdCodeDet"
        '
        'ColumnCode
        '
        Me.ColumnCode.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColumnCode.AppearanceCell.Options.UseFont = True
        Me.ColumnCode.AppearanceCell.Options.UseTextOptions = True
        Me.ColumnCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColumnCode.Caption = "Code"
        Me.ColumnCode.FieldName = "code"
        Me.ColumnCode.Name = "ColumnCode"
        Me.ColumnCode.Visible = True
        Me.ColumnCode.VisibleIndex = 0
        Me.ColumnCode.Width = 100
        '
        'ColumnCodeName
        '
        Me.ColumnCodeName.Caption = "Name"
        Me.ColumnCodeName.FieldName = "code_detail_name"
        Me.ColumnCodeName.Name = "ColumnCodeName"
        Me.ColumnCodeName.Visible = True
        Me.ColumnCodeName.VisibleIndex = 2
        Me.ColumnCodeName.Width = 150
        '
        'ColumnDisplayName
        '
        Me.ColumnDisplayName.Caption = "Printed Name"
        Me.ColumnDisplayName.FieldName = "display_name"
        Me.ColumnDisplayName.Name = "ColumnDisplayName"
        Me.ColumnDisplayName.Visible = True
        Me.ColumnDisplayName.VisibleIndex = 1
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit2.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'PCDeliveryTitle
        '
        Me.PCDeliveryTitle.Appearance.BackColor = System.Drawing.Color.White
        Me.PCDeliveryTitle.Appearance.Options.UseBackColor = True
        Me.PCDeliveryTitle.Controls.Add(Me.BDelete)
        Me.PCDeliveryTitle.Controls.Add(Me.LabelCodeContent)
        Me.PCDeliveryTitle.Controls.Add(Me.BEdit)
        Me.PCDeliveryTitle.Controls.Add(Me.LabelCodeTitle)
        Me.PCDeliveryTitle.Controls.Add(Me.BAdd)
        Me.PCDeliveryTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCDeliveryTitle.Location = New System.Drawing.Point(0, 0)
        Me.PCDeliveryTitle.LookAndFeel.SkinName = "iMaginary"
        Me.PCDeliveryTitle.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PCDeliveryTitle.Name = "PCDeliveryTitle"
        Me.PCDeliveryTitle.Size = New System.Drawing.Size(694, 46)
        Me.PCDeliveryTitle.TabIndex = 5
        '
        'LabelCodeContent
        '
        Me.LabelCodeContent.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCodeContent.Location = New System.Drawing.Point(70, 10)
        Me.LabelCodeContent.Name = "LabelCodeContent"
        Me.LabelCodeContent.Size = New System.Drawing.Size(6, 26)
        Me.LabelCodeContent.TabIndex = 4
        Me.LabelCodeContent.Text = "-"
        '
        'LabelCodeTitle
        '
        Me.LabelCodeTitle.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCodeTitle.Location = New System.Drawing.Point(6, 10)
        Me.LabelCodeTitle.Name = "LabelCodeTitle"
        Me.LabelCodeTitle.Size = New System.Drawing.Size(54, 26)
        Me.LabelCodeTitle.TabIndex = 3
        Me.LabelCodeTitle.Text = "Code :"
        '
        'FormCodeTemplateEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 330)
        Me.Controls.Add(Me.XTCCode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCodeTemplateEdit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Code"
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCCode.ResumeLayout(False)
        Me.XTPCode.ResumeLayout(False)
        CType(Me.GCCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPCodeDet.ResumeLayout(False)
        CType(Me.GCCodeDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCodeDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCDeliveryTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCDeliveryTitle.ResumeLayout(False)
        Me.PCDeliveryTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCCode As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPCode As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCCode As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCode As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColumnIdCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCodeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCodeDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIsIncludeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents ColIsIncludeCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents XTPCodeDet As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCCodeDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCodeDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColumnIdCodeDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnCodeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnDisplayName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents PCDeliveryTitle As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelCodeContent As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelCodeTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
End Class
