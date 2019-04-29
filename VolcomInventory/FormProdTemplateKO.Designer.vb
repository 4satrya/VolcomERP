<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdTemplateKO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProdTemplateKO))
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPUpper = New DevExpress.XtraTab.XtraTabPage()
        Me.REUpperPart = New DevExpress.XtraRichEdit.RichEditControl()
        Me.XTPBottom = New DevExpress.XtraTab.XtraTabPage()
        Me.REBottomPart = New DevExpress.XtraRichEdit.RichEditControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GCKOHead = New DevExpress.XtraGrid.GridControl()
        Me.GVKOHead = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.BDelHead = New DevExpress.XtraEditors.SimpleButton()
        Me.BEditHead = New DevExpress.XtraEditors.SimpleButton()
        Me.BAddHead = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPUpper.SuspendLayout()
        Me.XTPBottom.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GCKOHead, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVKOHead, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 482)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(875, 38)
        Me.PanelControl2.TabIndex = 1
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.ImageIndex = 7
        Me.BSave.ImageList = Me.ImageCollection
        Me.BSave.Location = New System.Drawing.Point(766, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(107, 34)
        Me.BSave.TabIndex = 8908
        Me.BSave.Text = "Save"
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.XtraTabControl1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 215)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(875, 267)
        Me.GroupControl1.TabIndex = 8907
        Me.GroupControl1.Text = "Detail"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl1.Location = New System.Drawing.Point(20, 2)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPUpper
        Me.XtraTabControl1.Size = New System.Drawing.Size(853, 263)
        Me.XtraTabControl1.TabIndex = 26
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPUpper, Me.XTPBottom})
        '
        'XTPUpper
        '
        Me.XTPUpper.Controls.Add(Me.REUpperPart)
        Me.XTPUpper.Name = "XTPUpper"
        Me.XTPUpper.Size = New System.Drawing.Size(847, 235)
        Me.XTPUpper.Text = "Upper Part"
        '
        'REUpperPart
        '
        Me.REUpperPart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.REUpperPart.EnableToolTips = True
        Me.REUpperPart.Location = New System.Drawing.Point(0, 0)
        Me.REUpperPart.Name = "REUpperPart"
        Me.REUpperPart.Options.Bookmarks.AllowNameResolution = False
        Me.REUpperPart.Size = New System.Drawing.Size(847, 235)
        Me.REUpperPart.TabIndex = 25
        '
        'XTPBottom
        '
        Me.XTPBottom.Controls.Add(Me.REBottomPart)
        Me.XTPBottom.Name = "XTPBottom"
        Me.XTPBottom.Size = New System.Drawing.Size(847, 235)
        Me.XTPBottom.Text = "Bottom Part"
        '
        'REBottomPart
        '
        Me.REBottomPart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.REBottomPart.EnableToolTips = True
        Me.REBottomPart.Location = New System.Drawing.Point(0, 0)
        Me.REBottomPart.Name = "REBottomPart"
        Me.REBottomPart.Options.Bookmarks.AllowNameResolution = False
        Me.REBottomPart.Size = New System.Drawing.Size(847, 235)
        Me.REBottomPart.TabIndex = 26
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.GCKOHead)
        Me.GroupControl2.Controls.Add(Me.PanelControl4)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(875, 215)
        Me.GroupControl2.TabIndex = 8908
        Me.GroupControl2.Text = "Template KO"
        '
        'GCKOHead
        '
        Me.GCKOHead.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCKOHead.Location = New System.Drawing.Point(20, 39)
        Me.GCKOHead.MainView = Me.GVKOHead
        Me.GCKOHead.Name = "GCKOHead"
        Me.GCKOHead.Size = New System.Drawing.Size(853, 174)
        Me.GCKOHead.TabIndex = 2
        Me.GCKOHead.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVKOHead})
        '
        'GVKOHead
        '
        Me.GVKOHead.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn11, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8})
        Me.GVKOHead.GridControl = Me.GCKOHead
        Me.GVKOHead.Name = "GVKOHead"
        Me.GVKOHead.OptionsView.ShowGroupPanel = False
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "ID Template"
        Me.GridColumn9.FieldName = "id_ko_template"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Description"
        Me.GridColumn11.FieldName = "description"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 1
        Me.GridColumn11.Width = 857
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Year"
        Me.GridColumn5.FieldName = "year"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        Me.GridColumn5.Width = 93
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Date Created"
        Me.GridColumn6.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn6.FieldName = "date_created"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        Me.GridColumn6.Width = 221
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Last Update By"
        Me.GridColumn7.FieldName = "last_upd_by"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 3
        Me.GridColumn7.Width = 221
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Last Update"
        Me.GridColumn8.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn8.FieldName = "last_upd"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 4
        Me.GridColumn8.Width = 240
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.BDelHead)
        Me.PanelControl4.Controls.Add(Me.BEditHead)
        Me.PanelControl4.Controls.Add(Me.BAddHead)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl4.Location = New System.Drawing.Point(20, 2)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(853, 37)
        Me.PanelControl4.TabIndex = 3
        '
        'BDelHead
        '
        Me.BDelHead.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDelHead.ImageIndex = 1
        Me.BDelHead.Location = New System.Drawing.Point(578, 2)
        Me.BDelHead.Name = "BDelHead"
        Me.BDelHead.Size = New System.Drawing.Size(91, 33)
        Me.BDelHead.TabIndex = 17
        Me.BDelHead.Text = "Delete"
        '
        'BEditHead
        '
        Me.BEditHead.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEditHead.ImageIndex = 2
        Me.BEditHead.Location = New System.Drawing.Point(669, 2)
        Me.BEditHead.Name = "BEditHead"
        Me.BEditHead.Size = New System.Drawing.Size(91, 33)
        Me.BEditHead.TabIndex = 19
        Me.BEditHead.Text = "Edit"
        '
        'BAddHead
        '
        Me.BAddHead.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAddHead.ImageIndex = 0
        Me.BAddHead.Location = New System.Drawing.Point(760, 2)
        Me.BAddHead.Name = "BAddHead"
        Me.BAddHead.Size = New System.Drawing.Size(91, 33)
        Me.BAddHead.TabIndex = 18
        Me.BAddHead.Text = "Add"
        '
        'ImageCollection
        '
        Me.ImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.ImageCollection.ImageStream = CType(resources.GetObject("ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.ImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.ImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.ImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.ImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.ImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.ImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.ImageCollection.Images.SetKeyName(7, "save.png")
        Me.ImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.ImageCollection.Images.SetKeyName(9, "18_24x24.png")
        Me.ImageCollection.Images.SetKeyName(10, "10_32x32.png")
        Me.ImageCollection.Images.SetKeyName(11, "18_32x32.png")
        Me.ImageCollection.Images.SetKeyName(12, "31_32x32.png")
        Me.ImageCollection.Images.SetKeyName(13, "folder-documents-icon.png")
        Me.ImageCollection.Images.SetKeyName(14, "mail_attachment.png")
        Me.ImageCollection.Images.SetKeyName(15, "attachment-icon.png")
        '
        'FormProdTemplateKO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(875, 520)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormProdTemplateKO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Template Konfirmasi Order"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPUpper.ResumeLayout(False)
        Me.XTPBottom.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCKOHead, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVKOHead, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCKOHead As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVKOHead As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BDelHead As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BEditHead As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAddHead As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents REUpperPart As DevExpress.XtraRichEdit.RichEditControl
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPUpper As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPBottom As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents REBottomPart As DevExpress.XtraRichEdit.RichEditControl
    Public WithEvents ImageCollection As DevExpress.Utils.ImageCollection
End Class
