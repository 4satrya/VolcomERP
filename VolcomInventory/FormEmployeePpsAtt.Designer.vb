<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmployeePpsAtt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmployeePpsAtt))
        Me.PictureEdit = New DevExpress.XtraEditors.PictureEdit()
        Me.PCAction = New DevExpress.XtraEditors.PanelControl()
        Me.SBDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SBScanUpload = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SBAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.XSCImageList = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.PictureEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCAction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCAction.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureEdit
        '
        Me.PictureEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit.Name = "PictureEdit"
        Me.PictureEdit.Properties.ReadOnly = True
        Me.PictureEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit.Properties.ShowScrollBars = True
        Me.PictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        Me.PictureEdit.Properties.ZoomingOperationMode = DevExpress.XtraEditors.Repository.ZoomingOperationMode.MouseWheel
        Me.PictureEdit.Size = New System.Drawing.Size(584, 468)
        Me.PictureEdit.TabIndex = 0
        '
        'PCAction
        '
        Me.PCAction.Controls.Add(Me.SBDelete)
        Me.PCAction.Controls.Add(Me.SBClose)
        Me.PCAction.Controls.Add(Me.SBScanUpload)
        Me.PCAction.Controls.Add(Me.SBSave)
        Me.PCAction.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCAction.Location = New System.Drawing.Point(0, 520)
        Me.PCAction.Name = "PCAction"
        Me.PCAction.Size = New System.Drawing.Size(584, 41)
        Me.PCAction.TabIndex = 1
        '
        'SBDelete
        '
        Me.SBDelete.Image = CType(resources.GetObject("SBDelete.Image"), System.Drawing.Image)
        Me.SBDelete.Location = New System.Drawing.Point(111, 5)
        Me.SBDelete.Name = "SBDelete"
        Me.SBDelete.Size = New System.Drawing.Size(72, 29)
        Me.SBDelete.TabIndex = 4
        Me.SBDelete.Text = "Delete"
        '
        'SBClose
        '
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(441, 6)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(67, 29)
        Me.SBClose.TabIndex = 3
        Me.SBClose.Text = "Close"
        '
        'SBScanUpload
        '
        Me.SBScanUpload.Image = CType(resources.GetObject("SBScanUpload.Image"), System.Drawing.Image)
        Me.SBScanUpload.Location = New System.Drawing.Point(5, 5)
        Me.SBScanUpload.Name = "SBScanUpload"
        Me.SBScanUpload.Size = New System.Drawing.Size(100, 29)
        Me.SBScanUpload.TabIndex = 2
        Me.SBScanUpload.Text = "Scan && Upload"
        '
        'SBSave
        '
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(514, 6)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(65, 29)
        Me.SBSave.TabIndex = 1
        Me.SBSave.Text = "Save"
        '
        'SBAdd
        '
        Me.SBAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SBAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBAdd.Image = CType(resources.GetObject("SBAdd.Image"), System.Drawing.Image)
        Me.SBAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.SBAdd.Location = New System.Drawing.Point(532, 2)
        Me.SBAdd.Name = "SBAdd"
        Me.SBAdd.Size = New System.Drawing.Size(50, 48)
        Me.SBAdd.TabIndex = 0
        '
        'XSCImageList
        '
        Me.XSCImageList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XSCImageList.Location = New System.Drawing.Point(2, 2)
        Me.XSCImageList.Name = "XSCImageList"
        Me.XSCImageList.Size = New System.Drawing.Size(530, 48)
        Me.XSCImageList.TabIndex = 2
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.XSCImageList)
        Me.PanelControl1.Controls.Add(Me.SBAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 468)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(584, 52)
        Me.PanelControl1.TabIndex = 1
        '
        'FormEmployeePpsAtt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 561)
        Me.Controls.Add(Me.PictureEdit)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PCAction)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmployeePpsAtt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Attachment"
        CType(Me.PictureEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCAction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCAction.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureEdit As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PCAction As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBScanUpload As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XSCImageList As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents SBDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
End Class
