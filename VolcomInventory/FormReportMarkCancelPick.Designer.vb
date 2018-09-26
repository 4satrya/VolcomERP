<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportMarkCancelPick
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormReportMarkCancelPick))
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PCSelAll = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEditSelAll = New DevExpress.XtraEditors.CheckEdit()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BPick = New DevExpress.XtraEditors.SimpleButton()
        Me.GCReportList = New DevExpress.XtraGrid.GridControl()
        Me.GVReportList = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PCSelAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCSelAll.SuspendLayout()
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCReportList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVReportList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.LargeImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "save.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(10, "10_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "18_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "31_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "folder-documents-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "mail_attachment.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "1417618546_Blue tag.png")
        Me.LargeImageCollection.Images.SetKeyName(16, "attachment-icon.png")
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.PCSelAll)
        Me.PanelControl1.Controls.Add(Me.BCancel)
        Me.PanelControl1.Controls.Add(Me.BPick)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 399)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(743, 38)
        Me.PanelControl1.TabIndex = 5
        '
        'PCSelAll
        '
        Me.PCSelAll.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCSelAll.Controls.Add(Me.CheckEditSelAll)
        Me.PCSelAll.Dock = System.Windows.Forms.DockStyle.Left
        Me.PCSelAll.Location = New System.Drawing.Point(2, 2)
        Me.PCSelAll.Name = "PCSelAll"
        Me.PCSelAll.Size = New System.Drawing.Size(99, 34)
        Me.PCSelAll.TabIndex = 106
        '
        'CheckEditSelAll
        '
        Me.CheckEditSelAll.Location = New System.Drawing.Point(5, 7)
        Me.CheckEditSelAll.Name = "CheckEditSelAll"
        Me.CheckEditSelAll.Properties.Caption = "Select All"
        Me.CheckEditSelAll.Size = New System.Drawing.Size(92, 19)
        Me.CheckEditSelAll.TabIndex = 102
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.ImageIndex = 5
        Me.BCancel.ImageList = Me.LargeImageCollection
        Me.BCancel.Location = New System.Drawing.Point(561, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(90, 34)
        Me.BCancel.TabIndex = 92
        Me.BCancel.Text = "Close"
        '
        'BPick
        '
        Me.BPick.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPick.ImageIndex = 4
        Me.BPick.ImageList = Me.LargeImageCollection
        Me.BPick.Location = New System.Drawing.Point(651, 2)
        Me.BPick.Name = "BPick"
        Me.BPick.Size = New System.Drawing.Size(90, 34)
        Me.BPick.TabIndex = 91
        Me.BPick.Text = "Pick"
        '
        'GCReportList
        '
        Me.GCReportList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCReportList.Location = New System.Drawing.Point(0, 0)
        Me.GCReportList.MainView = Me.GVReportList
        Me.GCReportList.Name = "GCReportList"
        Me.GCReportList.Size = New System.Drawing.Size(743, 399)
        Me.GCReportList.TabIndex = 6
        Me.GCReportList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVReportList})
        '
        'GVReportList
        '
        Me.GVReportList.GridControl = Me.GCReportList
        Me.GVReportList.Name = "GVReportList"
        Me.GVReportList.OptionsView.ShowGroupPanel = False
        '
        'FormReportMarkCancelPick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 437)
        Me.Controls.Add(Me.GCReportList)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormReportMarkCancelPick"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Report"
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PCSelAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCSelAll.ResumeLayout(False)
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCReportList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVReportList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPick As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCReportList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVReportList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PCSelAll As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEditSelAll As DevExpress.XtraEditors.CheckEdit
End Class
