<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDocumentUpload
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDocumentUpload))
        Me.PCNav = New DevExpress.XtraEditors.PanelControl()
        Me.BDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.Bupload = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BClose = New DevExpress.XtraEditors.SimpleButton()
        Me.GCFileList = New DevExpress.XtraGrid.GridControl()
        Me.GVFileList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdUpload = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUploadBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFile = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOpt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICE = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnFilename = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BScanAndUpload = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PCNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCNav.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCFileList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFileList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PCNav
        '
        Me.PCNav.Controls.Add(Me.BDelete)
        Me.PCNav.Controls.Add(Me.BScanAndUpload)
        Me.PCNav.Controls.Add(Me.Bupload)
        Me.PCNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCNav.Location = New System.Drawing.Point(0, 0)
        Me.PCNav.Name = "PCNav"
        Me.PCNav.Size = New System.Drawing.Size(760, 40)
        Me.PCNav.TabIndex = 0
        '
        'BDelete
        '
        Me.BDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDelete.ImageIndex = 4
        Me.BDelete.ImageList = Me.LargeImageCollection
        Me.BDelete.Location = New System.Drawing.Point(427, 2)
        Me.BDelete.Name = "BDelete"
        Me.BDelete.Size = New System.Drawing.Size(102, 36)
        Me.BDelete.TabIndex = 5
        Me.BDelete.Text = "Delete"
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "1415874002_download.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "1415874519_arrow_up.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "1415874551_bullet_deny.png")
        '
        'Bupload
        '
        Me.Bupload.Dock = System.Windows.Forms.DockStyle.Right
        Me.Bupload.ImageIndex = 3
        Me.Bupload.ImageList = Me.LargeImageCollection
        Me.Bupload.Location = New System.Drawing.Point(660, 2)
        Me.Bupload.Name = "Bupload"
        Me.Bupload.Size = New System.Drawing.Size(98, 36)
        Me.Bupload.TabIndex = 4
        Me.Bupload.Text = "Upload"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BClose)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 312)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(760, 36)
        Me.PanelControl2.TabIndex = 1
        '
        'BClose
        '
        Me.BClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BClose.Location = New System.Drawing.Point(683, 2)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(75, 32)
        Me.BClose.TabIndex = 3
        Me.BClose.Text = "Close"
        '
        'GCFileList
        '
        Me.GCFileList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFileList.Location = New System.Drawing.Point(0, 40)
        Me.GCFileList.MainView = Me.GVFileList
        Me.GCFileList.Name = "GCFileList"
        Me.GCFileList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICE})
        Me.GCFileList.Size = New System.Drawing.Size(760, 272)
        Me.GCFileList.TabIndex = 2
        Me.GCFileList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFileList, Me.GridView2})
        '
        'GVFileList
        '
        Me.GVFileList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnIdUpload, Me.GridColumnUploadBy, Me.GridColumnFile, Me.GridColumnDate, Me.GridColumnOpt, Me.GridColumnFilename})
        Me.GVFileList.GridControl = Me.GCFileList
        Me.GVFileList.Name = "GVFileList"
        Me.GVFileList.OptionsBehavior.ReadOnly = True
        Me.GVFileList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.Caption = "No."
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 56
        '
        'GridColumnIdUpload
        '
        Me.GridColumnIdUpload.Caption = "Id Upload"
        Me.GridColumnIdUpload.FieldName = "id_doc"
        Me.GridColumnIdUpload.Name = "GridColumnIdUpload"
        Me.GridColumnIdUpload.Width = 181
        '
        'GridColumnUploadBy
        '
        Me.GridColumnUploadBy.Caption = "Upload By"
        Me.GridColumnUploadBy.FieldName = "employee_name"
        Me.GridColumnUploadBy.Name = "GridColumnUploadBy"
        Me.GridColumnUploadBy.Visible = True
        Me.GridColumnUploadBy.VisibleIndex = 1
        '
        'GridColumnFile
        '
        Me.GridColumnFile.Caption = "File Description"
        Me.GridColumnFile.FieldName = "doc_desc"
        Me.GridColumnFile.Name = "GridColumnFile"
        Me.GridColumnFile.Visible = True
        Me.GridColumnFile.VisibleIndex = 2
        Me.GridColumnFile.Width = 365
        '
        'GridColumnDate
        '
        Me.GridColumnDate.Caption = "Date"
        Me.GridColumnDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDate.FieldName = "datetime"
        Me.GridColumnDate.Name = "GridColumnDate"
        Me.GridColumnDate.Visible = True
        Me.GridColumnDate.VisibleIndex = 3
        Me.GridColumnDate.Width = 115
        '
        'GridColumnOpt
        '
        Me.GridColumnOpt.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOpt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnOpt.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOpt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnOpt.Caption = "Option"
        Me.GridColumnOpt.ColumnEdit = Me.RICE
        Me.GridColumnOpt.FieldName = "is_download"
        Me.GridColumnOpt.Name = "GridColumnOpt"
        Me.GridColumnOpt.Visible = True
        Me.GridColumnOpt.VisibleIndex = 4
        Me.GridColumnOpt.Width = 67
        '
        'RICE
        '
        Me.RICE.AutoHeight = False
        Me.RICE.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.RICE.ImageIndexChecked = 2
        Me.RICE.ImageIndexGrayed = 2
        Me.RICE.ImageIndexUnchecked = 2
        Me.RICE.Images = Me.LargeImageCollection
        Me.RICE.Name = "RICE"
        '
        'GridColumnFilename
        '
        Me.GridColumnFilename.Caption = "GridColumn6"
        Me.GridColumnFilename.FieldName = "filename"
        Me.GridColumnFilename.Name = "GridColumnFilename"
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCFileList
        Me.GridView2.Name = "GridView2"
        '
        'BScanAndUpload
        '
        Me.BScanAndUpload.Dock = System.Windows.Forms.DockStyle.Right
        Me.BScanAndUpload.ImageIndex = 3
        Me.BScanAndUpload.ImageList = Me.LargeImageCollection
        Me.BScanAndUpload.Location = New System.Drawing.Point(529, 2)
        Me.BScanAndUpload.Name = "BScanAndUpload"
        Me.BScanAndUpload.Size = New System.Drawing.Size(131, 36)
        Me.BScanAndUpload.TabIndex = 6
        Me.BScanAndUpload.Text = "Scan and Upload"
        '
        'FormDocumentUpload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 348)
        Me.Controls.Add(Me.GCFileList)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PCNav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDocumentUpload"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Document Upload"
        CType(Me.PCNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCNav.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCFileList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFileList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PCNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCFileList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFileList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdUpload As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFile As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOpt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICE As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents BClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Bupload As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFilename As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUploadBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BScanAndUpload As DevExpress.XtraEditors.SimpleButton
End Class
